Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

<DoNotParallelize>
<TestClass>
Public Class IntegrationTests

    <TestMethod>
    Public Async Function WhenNoMatchingImageInDestination_SourceImageIsMovedAutomatically() As Task

        ' [Arrange]

        ' Create temporary source and target folders.
        Dim sourceFolder As String = Path.Combine(Path.GetTempPath(), "sourceFolder")
        Dim targetFolder As String = Path.Combine(Path.GetTempPath(), "targetFolder")

        ' Clean up any existing folders.
        If Directory.Exists(sourceFolder) Then Directory.Delete(sourceFolder, True)
        If Directory.Exists(targetFolder) Then Directory.Delete(targetFolder, True)

        ' Create source and target folders.
        Directory.CreateDirectory(sourceFolder)
        Directory.CreateDirectory(targetFolder)

        ' Create a source images and a different target image.
        Dim sourceImage1 As String = Path.Combine(sourceFolder, "imgSource1.jpg")
        Dim sourceImage2 As String = Path.Combine(sourceFolder, "imgSource2.jpg")
        Dim targetImage As String = Path.Combine(targetFolder, "imgTarget.jpg")

        ' Create simple images.
        CreateTwoColorImage(sourceImage1, Color.FromArgb(255, 230, 0), Color.FromArgb(255, 7, 0), rotation:=90)
        CreateTwoColorImage(sourceImage2, Color.FromArgb(255, 0, 23), Color.FromArgb(255, 218, 0))
        CreateTwoColorImage(targetImage, Color.FromArgb(0, 255, 174), Color.FromArgb(255, 0, 206))

        ' Prepare the ImageProcessor with the source image.
        Dim draggedPaths As String() = {sourceImage1, sourceImage2}
        Dim processor As New ImageProcessor()

        ' Subscribe to notifications to catch unexpected errors.
        AddHandler processor.BubbleNotification,
            Sub(ex)
                If ex.NotificationType = NotificationType.Exception Then
                    Assert.Fail("No se esperaba notificación de error: " & ex.Message)
                End If
            End Sub

        ' [Act]
        Await processor.InitProcess(draggedPaths, targetFolder)

        ' [Assert]
        Dim movedImage1 As String = Path.Combine(targetFolder, "imgSource1.jpg")
        Dim movedImage2 As String = Path.Combine(targetFolder, "imgSource2.jpg")

        Assert.IsTrue(File.Exists(movedImage1), "La imagen 1 de origen debe haberse movido a destino automáticamente.")
        Assert.IsTrue(File.Exists(movedImage2), "La imagen 2 de origen debe haberse movido a destino automáticamente.")
        Assert.IsFalse(File.Exists(sourceImage1), "La imagen 1 de origen ya no debe estar en origen.")
        Assert.IsFalse(File.Exists(sourceImage2), "La imagen 2 de origen ya no debe estar en origen.")
        Assert.IsTrue(File.Exists(targetImage), "La imagen original de destino debe seguir existiendo.")

        ' Clean
        If File.Exists(movedImage1) Then File.Delete(movedImage1)
        If File.Exists(movedImage2) Then File.Delete(movedImage2)
        If File.Exists(targetImage) Then File.Delete(targetImage)

        Directory.Delete(sourceFolder, True)
        Directory.Delete(targetFolder, True)

    End Function

    <TestMethod>
    Public Async Function WhenExactImageMatchingDetects_SourceImageIsNotMovedAutomatically() As Task

        ' [Arrange]

        ' Create temporary source and target folders.
        Dim sourceFolder As String = Path.Combine(Path.GetTempPath(), "sourceFolder")
        Dim targetFolder As String = Path.Combine(Path.GetTempPath(), "targetFolder")

        ' Clean up any existing folders.
        If Directory.Exists(sourceFolder) Then Directory.Delete(sourceFolder, True)
        If Directory.Exists(targetFolder) Then Directory.Delete(targetFolder, True)

        ' Create source and target folders.
        Directory.CreateDirectory(sourceFolder)
        Directory.CreateDirectory(targetFolder)

        ' Create a source image and an identical target image.
        Dim sourceImage As String = Path.Combine(sourceFolder, "imgSource.jpg")
        Dim targetImage As String = Path.Combine(targetFolder, "imgTarget.jpg")

        ' Create identical images.
        CreateTwoColorImage(sourceImage, Color.FromArgb(255, 230, 0), Color.FromArgb(255, 177, 0))
        File.Copy(sourceImage, targetImage, True)

        ' Prepare the ImageProcessor with the source image.
        Dim draggedPaths As String() = {sourceImage}
        Dim processor As New ImageProcessor()

        ' Subscribe to notifications to catch unexpected errors.
        AddHandler processor.BubbleNotification,
        Sub(ex)
            If ex.NotificationType = NotificationType.Exception Then
                Assert.Fail("No se esperaba notificación de error: " & ex.Message)
            End If
        End Sub

        ' [Act]
        Await processor.InitProcess(draggedPaths, targetFolder)

        ' [Assert]
        Assert.IsTrue(File.Exists(sourceImage), "La imagen de origen debe seguir existiendo hasta que el usuario decida.")
        Assert.IsTrue(File.Exists(targetImage), "La imagen de destino debe seguir existiendo hasta que el usuario decida.")

        ' Clean
        If File.Exists(sourceImage) Then File.Delete(sourceImage)
        If File.Exists(targetImage) Then File.Delete(targetImage)

        Directory.Delete(sourceFolder, True)
        Directory.Delete(targetFolder, True)

    End Function

    <TestMethod>
    Public Async Function WhenSimilarImageMatchingDetects_SourceImageIsNotMovedAutomatically() As Task

        ' [Arrange]

        ' Create temporary source and target folders.
        Dim sourceFolder As String = Path.Combine(Path.GetTempPath(), "sourceFolder")
        Dim targetFolder As String = Path.Combine(Path.GetTempPath(), "targetFolder")

        ' Clean up any existing folders.
        If Directory.Exists(sourceFolder) Then Directory.Delete(sourceFolder, True)
        If Directory.Exists(targetFolder) Then Directory.Delete(targetFolder, True)

        ' Create source and target folders.
        Directory.CreateDirectory(sourceFolder)
        Directory.CreateDirectory(targetFolder)

        ' Create a source image and a similar target image.
        Dim sourceImage As String = Path.Combine(sourceFolder, "imgSource.jpg")
        Dim targetImage As String = Path.Combine(targetFolder, "imgTarget.jpg")

        CreateTwoColorImage(sourceImage, Color.FromArgb(255, 200, 0, 0), Color.FromArgb(255, 60, 140, 0))
        CreateTwoColorImage(targetImage, Color.FromArgb(255, 210, 110, 110), Color.FromArgb(255, 60, 250, 110))

        ' Prepare the ImageProcessor with the source image.
        Dim draggedPaths As String() = {sourceImage}
        Dim processor As New ImageProcessor()

        ' Subscribe to notifications to catch unexpected errors.
        AddHandler processor.BubbleNotification,
        Sub(ex)
            If ex.NotificationType = NotificationType.Exception Then
                Assert.Fail("No se esperaba notificación de error: " & ex.Message)
            End If
        End Sub

        ' [Act]
        Await processor.InitProcess(draggedPaths, targetFolder)

        ' [Assert]
        Assert.IsTrue(File.Exists(sourceImage), "La imagen de origen debe seguir existiendo hasta que el usuario decida.")
        Assert.IsTrue(File.Exists(targetImage), "La imagen de destino debe seguir existiendo hasta que el usuario decida.")

        ' Clean
        If File.Exists(sourceImage) Then File.Delete(sourceImage)
        If File.Exists(targetImage) Then File.Delete(targetImage)

        Directory.Delete(sourceFolder, True)
        Directory.Delete(targetFolder, True)

    End Function


    Private Sub CreateTwoColorImage(path As String, color1 As Color, color2 As Color, Optional rotation As Integer = 0)
        ' Creates an image split vertically into two solid colors.
        Using bmp As New Bitmap(1000, 1000)
            Using g = Graphics.FromImage(bmp)
                ' Left half
                Using brush1 As New SolidBrush(color1)
                    g.FillRectangle(brush1, 0, 0, bmp.Width \ 2, bmp.Height)
                    g.RotateTransform(rotation)
                End Using

                ' Right half
                Using brush2 As New SolidBrush(color2)
                    g.FillRectangle(brush2, bmp.Width \ 2, 0, bmp.Width \ 2, bmp.Height)
                    g.RotateTransform(rotation)
                End Using
            End Using

            bmp.Save(path, ImageFormat.Jpeg)
        End Using
    End Sub

End Class