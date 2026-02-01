Imports Emgu.CV.CvEnum
Imports System.IO
Imports System.Runtime.InteropServices

''' <summary>
''' Helper module for image processing tasks.
''' </summary>
Public Module ImageProcessingHelper

    ''' <summary>
    ''' Normalizes the orientation of an image based on its EXIF data.
    ''' </summary>
    ''' <param name="img">The image to normalize.</param>
    ''' <returns>The normalized image.</returns>
    Public Function NormalizeExifOrientation(img As Image) As Image

        ' Constant property ID for the Orientation tag in EXIF data.
        Const OrientationId As Integer = &H112

        ' Clone the original image to liberate the original from modifications.
        Dim imgCloned As New Bitmap(img)

        ' Check if the image has the Orientation property.
        If Not img.PropertyIdList.Contains(OrientationId) Then
            Return imgCloned
        End If

        ' Get the orientation value from the EXIF data.
        Dim imgOrientation As Integer = img.GetPropertyItem(OrientationId).Value(0)

        ' Adjust the image based on the orientation value.
        Select Case imgOrientation
            Case 1 ' No rotation
            Case 2 : imgCloned.RotateFlip(RotateFlipType.RotateNoneFlipX)   ' Flip X
            Case 3 : imgCloned.RotateFlip(RotateFlipType.RotateNoneFlipY)   ' Flip Y
            Case 4 : imgCloned.RotateFlip(RotateFlipType.RotateNoneFlipXY)  ' Flip X and Flip Y
            Case 5 : imgCloned.RotateFlip(RotateFlipType.Rotate90FlipX)     ' Rotate 90 degrees ⭯ and flip X
            Case 6 : imgCloned.RotateFlip(RotateFlipType.Rotate90FlipNone)  ' Rotate 90 degrees ⭯
            Case 7 : imgCloned.RotateFlip(RotateFlipType.Rotate270FlipX)    ' Rotate 270 degrees ⭯ and flip X
            Case 8 : imgCloned.RotateFlip(RotateFlipType.Rotate270FlipNone) ' Rotate 270 degrees ⭯
        End Select

        ' Remove the orientation property from image exif data to prevent reapplication.
        imgCloned.RemovePropertyItem(OrientationId)

        Return imgCloned

    End Function

    ''' <summary>
    ''' Creates an ImageData object from the provided image file path.
    ''' </summary>
    ''' <param name="pathFile">The path to the image file.</param>
    ''' <param name="hash">The hash of the image file.</param>
    ''' <returns></returns>
    Public Async Function CreateImageDataAsync(pathFile As String, hash As String) As Task(Of ImageData)

        ' Validate file format.
        If Not IsValid(pathFile) Then Return Nothing

        ' File name and format.
        Dim fileName As String = Path.GetFileNameWithoutExtension(pathFile)
        Dim fileFormat As String = Path.GetExtension(pathFile).ToLower()

        ' Get weight in KB.
        Dim fileWeight As Long = New FileInfo(pathFile).Length \ 1024

        ' Measures and orientation.
        Dim imageWidth As Integer
        Dim imageHeight As Integer

        ' Loads the image and normalizes its orientation based on EXIF data.
        Using image As Image = Await Task.Run(Function() Image.FromFile(pathFile))

            ' Get image dimensions after normalizing orientation.
            Using orientedImage As Image = NormalizeExifOrientation(image)

                imageWidth = orientedImage.Width
                imageHeight = orientedImage.Height

            End Using
        End Using

        ' Loads the image in grayscale, resulting in a single channel.
        ' The channel has values from 0 to 255 (8 bits).
        ' Creates matrix with these pixel intensity values.
        Using pixelMatrix As Mat = CvInvoke.Imread(pathFile, ImreadModes.Grayscale)
            Using resizedPixelMatrix As New Mat()
                ' Resizes the image to 100x100 pixels, creating a new matrix for the resized image.
                CvInvoke.Resize(pixelMatrix, resizedPixelMatrix, New Size(100, 100))

                ' Creates a unidimensional byte array with pixel intensity values from the resized image.
                Dim pixelArray As Byte() = New Byte(resizedPixelMatrix.Rows * resizedPixelMatrix.Cols - 1) {}
                Marshal.Copy(resizedPixelMatrix.DataPointer, pixelArray, 0, pixelArray.Length)

                ' Convert to unidimensional double array to perform calculations such as mean and variance.
                Dim pixelData As Integer() = pixelArray.Select(Function(b) CInt(b)).ToArray()

                ' [LUMINANCE] Get mean of pixel values (μ -> mu)
                Dim mean As Double = pixelData.Average()

                ' [CONTRAST] Get variance of pixel values (σ² -> sigma squared)
                Dim variance As Double = pixelData.Select(Function(pixelValue) Math.Pow(pixelValue - mean, 2)).Average()

                Return New ImageData(fileWeight, imageWidth, imageHeight, mean, variance, pixelData, hash)
            End Using
        End Using

    End Function

End Module
