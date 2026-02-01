''' <summary>
''' Helper module for image similarity calculations.
''' </summary>
Public Module ImageSimilarityHelper

    ''' <summary>
    ''' Minimum percentage similarity to consider two images as similar.
    ''' </summary>
    ''' <param name="imageA">The first image data.</param>
    ''' <param name="imageB">The second image data.</param>
    ''' <returns>True if images are similar, otherwise false.</returns>
    Public Function AreSimilar(imageA As ImageData, imageB As ImageData) As Boolean

        ' Validate inputs.
        If imageA Is Nothing OrElse imageB Is Nothing Then Return False

        ' Calculate SSIM and compare with threshold.
        Dim similarity As Double = CalculateSSIM(imageA, imageB) * 100
        Return similarity >= MIN_PERCENTAGE_SIMILARITY

    End Function

    ''' <summary>
    ''' Calculates the Structural Similarity Index (SSIM) between two images.
    ''' </summary>
    ''' <param name="imageA">The first image data.</param>
    ''' <param name="imageB">The second image data.</param>
    ''' <returns>The SSIM value between the two images.</returns>
    Public Function CalculateSSIM(imageA As ImageData, imageB As ImageData) As Double

        ' Get pixel data arrays, means and variances
        Dim dataX As Integer() = imageA.PixelData
        Dim meanX As Double = imageA.Mean
        Dim varianceX As Double = imageA.Variance
        Dim dataY As Integer() = imageB.PixelData
        Dim meanY As Double = imageB.Mean
        Dim varianceY As Double = imageB.Variance

        ' [8 bits] -> [0 to 255] -> [1 Channel] -> [GrayScale] 

        ' Stabilize luminance -> 6.5025 (Is a small constant to avoid instability when the means are close to zero)
        Dim C1 As Double = Math.Pow(0.01 * 255, 2)

        ' Stabilize contrast -> 58.5225 (Is a small constant to avoid instability when the variances are close to zero)
        Dim C2 As Double = Math.Pow(0.03 * 255, 2)

        ' Get covariance of pixel values (σxy) (Is a measure of how much the two variables change together)
        Dim covarianceXY As Double = dataX.Zip(dataY, Function(x, y) (x - meanX) * (y - meanY)).Average()

        ' SSIM numerator (Is a measure of similarity between two images)
        Dim numerator As Double = (2 * meanX * meanY + C1) * (2 * covarianceXY + C2)

        ' SSIM denominator (Is a measure of the combined luminance and contrast of the two images)
        Dim denominator As Double = (Math.Pow(meanX, 2) + Math.Pow(meanY, 2) + C1) * (varianceX + varianceY + C2)

        Return numerator / denominator
    End Function

End Module