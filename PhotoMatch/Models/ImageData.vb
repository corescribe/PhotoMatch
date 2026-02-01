''' <summary>
''' Represents image data including dimensions, statistics, pixel data, and hash.
''' </summary>
Public Class ImageData

#Region "Public Properties"

    Public ReadOnly Property FileWeight As Long
    Public ReadOnly Property ImageWidth As Integer
    Public ReadOnly Property ImageHeight As Integer
    Public ReadOnly Property Mean As Double
    Public ReadOnly Property Variance As Double
    Public ReadOnly Property PixelData As Integer()
    Public ReadOnly Property Hash As String

#End Region

#Region "Constructor"

    Public Sub New(fileWeight As Long, imageWidth As Integer, imageHeight As Integer, mean As Double, variance As Double, pixelData As Integer(), hash As String)
        Me.FileWeight = fileWeight
        Me.ImageWidth = imageWidth
        Me.ImageHeight = imageHeight
        Me.Mean = mean
        Me.Variance = variance
        Me.PixelData = pixelData
        Me.Hash = hash
    End Sub

#End Region

End Class