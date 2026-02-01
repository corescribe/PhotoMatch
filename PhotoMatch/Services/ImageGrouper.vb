''' <summary>
''' This class is responsible for grouping similar images based on their image data.
''' </summary>
Public Class ImageGrouper

#Region "Public Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementGrouped()

#End Region

#Region "Constructor"

    Public Sub New()

    End Sub

#End Region

#Region "Public Functions"

    ''' <summary>
    ''' Asynchronously creates match groups from the provided image references.
    ''' </summary>
    ''' <param name="imageReferencesBuffer">Dictionary mapping image hashes to lists of image references.</param>
    ''' <returns>A task that represents the asynchronous operation. The task result contains a list of match groups.</returns>
    Public Async Function CreateGroups(imageReferencesBuffer As Dictionary(Of String, List(Of ImageReference))) As Task(Of List(Of MatchGroup))
        ' Run the grouping logic on a background thread.
        Return Await Task.Run(
            Async Function()

                ' List to hold the created match groups.
                Dim groups = New List(Of MatchGroup)
                ' Flatten all image references from the dictionary into a single list.
                Dim allReferences = imageReferencesBuffer.Values.SelectMany(Function(c) c).ToList()

                Dim counter = 0

                ' Iterate through each image reference to group them.
                For Each reference In allReferences
                    ' Flag to track if the reference was added to an existing group.
                    Dim added As Boolean = False

                    ' Iterate through existing groups to find a match.
                    For Each group In groups
                        ' Check if the reference can join the current group.
                        If CanJoinGroup(reference, group) Then
                            ' Add the reference to the group.
                            AddImgReferenceToGroup(reference, group)
                            added = True
                            Exit For

                        End If

                    Next

                    ' If the reference was not added to any group, create a new group for it.
                    If Not added Then
                        ' Create a new match group and add the reference.
                        Dim newGroup As New MatchGroup(New List(Of ImageReference), New List(Of ImageReference))
                        AddImgReferenceToGroup(reference, newGroup)
                        groups.Add(newGroup)

                    End If

                Next

                ' Filter out invalid groups calling IsValidGroup with LINQ.
                Dim validGroups = groups.Where(Function(g) g.IsValidGroup).ToList()

                ' Iterate through valid groups to raise increment events.
                For Each group In validGroups

                    ' Flatten all image references in the group.
                    Dim allImgReferenceGroup = group.SourceImages.Concat(group.TargetImages).ToList()

                    For Each ImgReferenceGroup In allImgReferenceGroup
                        Await Task.Delay(PROCESSING_SPEED_MS)
                        RaiseEvent IncrementGrouped()
                    Next

                Next

                Return validGroups

            End Function)
    End Function

#End Region

#Region "Private Functions"

    ''' <summary>
    ''' Determines if a new image reference can join an existing match group based on similarity.
    ''' </summary>
    ''' <param name="newImgReference">The new image reference to evaluate.</param>
    ''' <param name="group">The existing match group.</param>
    ''' <returns>True if the new image reference can join the group; otherwise, false.</returns>
    Private Function CanJoinGroup(newImgReference As ImageReference, group As MatchGroup) As Boolean

        ' Combine all image references from both source and target lists in the group.
        Dim allImgReferences = group.SourceImages.Concat(group.TargetImages)

        ' Return true if any existing image reference in the group is similar to the new image reference.
        Return allImgReferences.Any(
            Function(oldImgReference) AreSimilar(newImgReference.ImageData, oldImgReference.ImageData)
        )
    End Function

    ''' <summary>
    ''' Adds an image reference to the appropriate list in the match group based on its source.
    ''' </summary>
    ''' <param name="imgReference">The image reference to add.</param>
    ''' <param name="group">The match group to which the image reference will be added.</param>
    Private Sub AddImgReferenceToGroup(imgReference As ImageReference, group As MatchGroup)

        ' Add the image reference to the source or target list based on its source type.
        If imgReference.Source = ImageSource.Origin Then
            group.SourceImages.Add(imgReference)
        Else
            group.TargetImages.Add(imgReference)
        End If

    End Sub

#End Region

End Class
