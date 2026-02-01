Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO

<TestClass>
    Public Class FileHelperTests

        <TestMethod>
        Public Sub GetHashMD5_SameContentDifferentFiles_ReturnsSameHash()
            ' Arrange
            Dim tempFile1 As String = Path.GetTempFileName()
            Dim tempFile2 As String = Path.GetTempFileName()
            Dim content As String = "Miguel González Fernández"
            File.WriteAllText(tempFile1, content)
            File.WriteAllText(tempFile2, content)

            ' Act
            Dim hash1 As String = GetHashMD5(tempFile1)
            Dim hash2 As String = GetHashMD5(tempFile2)

            ' Assert
            Assert.AreEqual(hash1, hash2)

            ' Clean
            File.Delete(tempFile1)
            File.Delete(tempFile2)
        End Sub

        <TestMethod>
        Public Sub GetHashMD5_DifferentContent_ReturnsDifferentHash()
            ' Arrange
            Dim tempFile1 As String = Path.GetTempFileName()
            Dim tempFile2 As String = Path.GetTempFileName()
            File.WriteAllText(tempFile1, "Miguel González Fernández")
            File.WriteAllText(tempFile2, "miguel gonzález fernández")

            ' Act
            Dim hash1 As String = GetHashMD5(tempFile1)
            Dim hash2 As String = GetHashMD5(tempFile2)

            ' Assert
            Assert.AreNotEqual(hash1, hash2)

            ' Clean
            File.Delete(tempFile1)
            File.Delete(tempFile2)
        End Sub

End Class