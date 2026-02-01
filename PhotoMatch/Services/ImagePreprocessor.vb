''' <summary>
''' This class is responsible for preprocessing images by creating ImageData and ImageReference objects.
''' </summary>
Public Class ImagePreprocessor

#Region "Public Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementProcessed()

#End Region

#Region "Fields"

    Private ReadOnly _imageDataBuffer As Dictionary(Of String, ImageData)
    Private ReadOnly _imageReferencesBuffer As Dictionary(Of String, List(Of ImageReference))

#End Region

#Region "Constructor"

    Public Sub New(
        imageDataBuffer As Dictionary(Of String, ImageData),
        imageReferencesBuffer As Dictionary(Of String, List(Of ImageReference)))

        _imageDataBuffer = imageDataBuffer
        _imageReferencesBuffer = imageReferencesBuffer
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Asynchronously preprocesses images from the given paths and source.
    ''' </summary>
    ''' <param name="paths">The image file paths to preprocess.</param>
    ''' <param name="source">The source of the images.</param>
    ''' <returns>A task representing the asynchronous operation.</returns>
    Public Async Function InitPreProcess(paths As String(), source As ImageSource) As Task

        Try
            ' Run the preprocessing on a background thread.
            Await Task.Run(
                Async Function()

                    ' Process each image file path.
                    For Each filePath In paths

                        ' Compute the MD5 hash of the image file.
                        Dim hash As String = GetHashMD5(filePath)

                        ' Initialize ImageData variable.
                        Dim data As ImageData = Nothing

                        ' Check if ImageData is already cached.
                        If Not _imageDataBuffer.TryGetValue(hash, data) Then

                            ' Create ImageData for the image.
                            data = Await CreateImageDataAsync(filePath, hash)

                            ' If ImageData creation failed, skip to the next image.
                            If data Is Nothing Then Continue For
                            _imageDataBuffer(hash) = data
                        End If

                        ' Create ImageReference for the image.
                        Dim imageReference As New ImageReference(filePath, data, source)

                        ' Check if the hash entry exists in the dictionary.
                        If Not _imageReferencesBuffer.ContainsKey(hash) Then
                            _imageReferencesBuffer(hash) = New List(Of ImageReference)
                        End If

                        ' Add the ImageReference to the corresponding hash entry.
                        _imageReferencesBuffer(hash).Add(imageReference)

                        ' Increment processed counter.
                        RaiseEvent IncrementProcessed()

                        ' Propagate success log and notification.
                        PropagateLog(LogType.ImageProcessed, String.Format(NOTIFICATION_IMG_PROCESSED_TEXT, filePath))
                        PropagateNotification(NotificationType.Success, String.Format(NOTIFICATION_IMG_PROCESSED_TEXT, filePath))
                    Next

                End Function)

        Catch ex As Exception

            ' Propagate error log and notification.
            PropagateLog(LogType.MoveError, String.Format(NOTIFICATION_GENERIC_EXCEPTION_TEXT, ex.Message))
            PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_GENERIC_EXCEPTION_TEXT, ex.Message))

        End Try

    End Function

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Propagates a notification event to the parent.
    ''' </summary>
    ''' <param name="notificationType">The type of notification.</param>
    ''' <param name="message">The notification message.</param>
    Private Sub PropagateNotification(notificationType As NotificationType, message As String)
        RaiseEvent BubbleNotification(New CustomException(notificationType, message))
    End Sub

    ''' <summary>
    ''' Propagates a log event to the parent.
    ''' </summary>
    ''' <param name="logType">The type of log.</param>
    ''' <param name="message">The log message.</param>
    Private Sub PropagateLog(logType As LogType, message As String)
        RaiseEvent BubbleLog(New LogEntry(logType, message))
    End Sub
#End Region

End Class

