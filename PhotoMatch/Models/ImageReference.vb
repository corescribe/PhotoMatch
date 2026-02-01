Imports System.IO

''' <summary>
''' Represents a reference to an image, including its path, data, and source.
''' </summary>
Public Class ImageReference

#Region "Public Properties"

    Public ReadOnly Property FullPath As String
    Public ReadOnly Property ImageData As ImageData
    Public ReadOnly Property Source As ImageSource

    Public ReadOnly Property FileName As String
        Get
            Return Path.GetFileName(FullPath)
        End Get
    End Property

    Public ReadOnly Property FileFormat As String
        Get
            Return Path.GetExtension(FullPath).TrimStart("."c).ToLower()
        End Get
    End Property

#End Region

#Region "Constructor"

    Public Sub New(fullPath As String, imageData As ImageData, source As ImageSource)
        Me.FullPath = fullPath
        Me.ImageData = imageData
        Me.Source = source
    End Sub

#End Region

End Class