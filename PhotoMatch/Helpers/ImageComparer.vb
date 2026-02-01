''' <summary>
''' Class to compare images and calculate similarity metrics.
''' </summary>
Public Class ImageComparer

#Region "Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementCompared()

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Asynchronously calculates comparisons between image references.
    ''' </summary>
    ''' <param name="imgRefs">Dictionary of grouped image references.</param>
    ''' <returns>Task representing the asynchronous operation.</returns>
    Public Async Function Compare(imgRefs As Dictionary(Of String, List(Of ImageReference))) As Task

        ' Run the comparison simulation on a background thread.
        Await Task.Run(
            Sub()

                ' Iterate through each group of image references.
                Dim imgReferences As New List(Of ImageReference)
                For Each element In imgRefs
                    imgReferences.AddRange(element.Value)
                Next

                ' Simulate comparisons between each pair of images.
                For i = 0 To imgReferences.Count - 2
                    For j = i + 1 To imgReferences.Count - 1

                        ' Get filenames for logging.
                        Dim imageA = imgReferences(i).FileName
                        Dim imageB = imgReferences(j).FileName

                        ' Raise log and notification events for this comparison.
                        PropagateLog(LogType.ImageCompared, String.Format(NOTIFICATION_IMG_COMPARED_TEXT, imageA, imageB))
                        PropagateNotification(NotificationType.Info, String.Format(NOTIFICATION_IMG_COMPARED_TEXT, imageA, imageB))

                        ' Raise event to increment the comparison counter.
                        RaiseEvent IncrementCompared()

                        ' Delay to simulate processing speed (constant).
                        Threading.Thread.Sleep(PROCESSING_SPEED_MS)

                    Next
                Next

            End Sub)

    End Function

#End Region

#Region "Private Methods"

    ' Helper method to propagate notifications.
    Private Sub PropagateNotification(notificationType As NotificationType, message As String)
        RaiseEvent BubbleNotification(New CustomException(notificationType, message))
    End Sub

    ' Helper method to propagate logs.
    Private Sub PropagateLog(logType As LogType, message As String)
        RaiseEvent BubbleLog(New LogEntry(logType, message))
    End Sub

#End Region

End Class