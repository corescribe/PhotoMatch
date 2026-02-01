Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class ImageValidationHelperTests

    <TestMethod>
    Public Sub IsValid_Accepts_ValidImageExtensions()
        Assert.IsTrue(IsValid("image.jpg"))
        Assert.IsTrue(IsValid("image.JPG"))
        Assert.IsTrue(IsValid("image.jpeg"))
        Assert.IsTrue(IsValid("image.JPEG"))
        Assert.IsTrue(IsValid("image.png"))
        Assert.IsTrue(IsValid("image.PNG"))
        Assert.IsTrue(IsValid("image.bmp"))
        Assert.IsTrue(IsValid("image.BMP"))
    End Sub

    <TestMethod>
    Public Sub IsValid_Rejects_InvalidImageExtensions()
        Assert.IsFalse(IsValid("document.pdf"))
        Assert.IsFalse(IsValid("image.tiff"))
        Assert.IsFalse(IsValid("file.txt"))
    End Sub

End Class

