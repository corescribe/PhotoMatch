''' <summary>
''' Represents a group of matched images from source and target collections.
''' </summary>
Public Class MatchGroup

#Region "Public Properties"

    Public ReadOnly Property SourceImages As List(Of ImageReference)
    Public ReadOnly Property TargetImages As List(Of ImageReference)

    Public ReadOnly Property TotalImages As Integer
        Get
            Return SourceImages.Count + TargetImages.Count
        End Get
    End Property

    Public ReadOnly Property IsValidGroup As Boolean
        Get
            Return TotalImages > 1
        End Get
    End Property

#End Region

#Region "Constructor"

    Public Sub New(sourceImages As List(Of ImageReference), targetImages As List(Of ImageReference))
        Me.SourceImages = sourceImages
        Me.TargetImages = targetImages
    End Sub

#End Region

End Class

