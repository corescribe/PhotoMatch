Imports System.IO
Imports System.Security.Cryptography

''' <summary>
''' Helper module for file operations.
''' </summary>
Public Module FileHelper

    ''' <summary>
    ''' Computes the MD5 hash of a file.
    ''' </summary>
    ''' <param name="filePath">The path to the file.</param>
    ''' <returns>The MD5 hash as a hexadecimal string.</returns>
    Public Function GetHashMD5(filePath As String) As String

        ' Create an MD5 instance and compute the hash.
        Using md5 As MD5 = MD5.Create()

            ' Open the file stream for reading.
            Using stream As FileStream = File.OpenRead(filePath)

                ' Compute the hash and convert it to a hexadecimal string.
                Dim hashBytes = md5.ComputeHash(stream)

                ' BitConverter returns the hash in the format "XX-XX-XX...", so we replace "-" and convert to lowercase invariant for format consistency.
                Return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant()

            End Using

        End Using

    End Function

End Module