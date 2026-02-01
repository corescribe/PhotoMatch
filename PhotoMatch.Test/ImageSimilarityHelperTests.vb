Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class ImageSimilarityHelperTests

    <TestMethod>
    Public Sub AreSimilar_ReturnsFalse_ForNullInput()
        Assert.IsFalse(AreSimilar(Nothing, Nothing))
    End Sub

    <TestMethod>
    Public Sub CalculateSSIM_ReturnsOne_ForIdenticalImages()
        ' Arrange
        Dim pixels = {0, 25, 50, 75, 100, 125, 150, 175, 200, 225}

        Dim mean = CalculateMean(pixels)
        Dim variance = CalculateVarianze(pixels)

        Dim imgA As New ImageData(1000, 1600, 800, mean, variance, pixels, "HashA")
        Dim imgB As New ImageData(500, 800, 400, mean, variance, pixels, "HashB")

        ' Act
        Dim ssim = CalculateSSIM(imgA, imgB)

        ' Assert
        Assert.AreEqual(1.0, ssim, 0.0001)
    End Sub

    <TestMethod>
    Public Sub AreSimilar_ReturnsTrue_ForSimilarImages()
        ' Arrange
        Dim pixelsA = {0, 25, 50, 75, 100, 125, 150, 175, 200, 255}
        Dim pixelsB = {0, 25, 50, 75, 100, 125, 150, 175, 200, 80}

        Dim meanA = CalculateMean(pixelsA)
        Dim varianceA = CalculateVarianze(pixelsA)
        Dim meanB = CalculateMean(pixelsB)
        Dim varianceB = CalculateVarianze(pixelsB)

        Dim imgA As New ImageData(1000, 1600, 800, meanA, varianceA, pixelsA, "HashA")
        Dim imgB As New ImageData(500, 800, 400, meanB, varianceB, pixelsB, "HashB")

        ' Act
        Dim result = AreSimilar(imgA, imgB)

        ' Assert
        Assert.IsTrue(result)
    End Sub

    <TestMethod>
    Public Sub AreSimilar_ReturnsFalse_ForDifferentImages()
        ' Arrange
        Dim pixelsA = {0, 25, 50, 75, 100, 125, 150, 175, 200, 255}
        Dim pixelsB = {0, 25, 50, 75, 100, 125, 150, 175, 200, 75}

        Dim meanA = CalculateMean(pixelsA)
        Dim varianceA = CalculateVarianze(pixelsA)
        Dim meanB = CalculateMean(pixelsB)
        Dim varianceB = CalculateVarianze(pixelsB)

        Dim imgA As New ImageData(1000, 1600, 800, meanA, varianceA, pixelsA, "HashA")
        Dim imgB As New ImageData(500, 800, 400, meanB, varianceB, pixelsB, "HashB")

        ' Act
        Dim result = AreSimilar(imgA, imgB)

        ' Assert
        Assert.IsFalse(result)
    End Sub

    Private Function CalculateMean(pixels As Integer()) As Double
        Return pixels.Average()
    End Function

    Private Function CalculateVarianze(pixels As Integer()) As Double
        Dim mean = CalculateMean(pixels)
        Return pixels.Select(Function(p) Math.Pow(p - mean, 2)).Average()
    End Function

End Class