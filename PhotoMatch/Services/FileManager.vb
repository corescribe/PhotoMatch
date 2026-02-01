Imports System.IO

''' <summary>
''' Manages file operations such as moving and deleting files.
''' </summary>
Public Class FileManager

#Region "Public Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementMoveError()
    Public Event IncrementMoved()
    Public Event IncrementDeleteError()
    Public Event IncrementDeleted()

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Moves a file from one path to another.
    ''' </summary>
    ''' <param name="fromPath">The source file path.</param>
    ''' <param name="toPath">The destination file path.</param>
    ''' <returns>Returns True if the file was moved successfully, otherwise False.</returns>
    Public Async Function MoveFile(fromPath As String, toPath As String) As Task(Of Boolean)

        Try

            ' Simulate processing delay.
            Await Task.Delay(PROCESSING_SPEED_MS)

            ' Check if the source file exists.
            If File.Exists(fromPath) Then

                Dim counter As Integer = 0

                ' If the destination file already exists, modify the filename to avoid overwriting.
                If File.Exists(toPath) Then

                    ' Create a new filename with a counter suffix.
                    Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(toPath)
                    ' Get the file extension.
                    Dim fileExtension As String = Path.GetExtension(toPath)
                    ' Get the directory of the destination file.
                    Dim directory As String = Path.GetDirectoryName(toPath)

                    ' Generate a new file path with an incremented counter until a unique name is found.
                    Dim newToPathFile As String

                    Do
                        counter += 1
                        ' Construct the new file path with the counter.
                        newToPathFile = Path.Combine(directory, $"{fileNameWithoutExtension}({counter}){fileExtension}")
                        ' Continue looping if the new file path already exists.
                    Loop While File.Exists(newToPathFile)

                    toPath = newToPathFile
                End If

                ' Move the file asynchronously.
                Await Task.Run(Sub() File.Move(fromPath, toPath))

                ' Propagate success log and notification.
                PropagateLog(LogType.ImageMoved, String.Format(NOTIFICATION_IMG_MOVE_SUCCESS_TEXT, fromPath, toPath))
                PropagateNotification(NotificationType.Success, String.Format(NOTIFICATION_IMG_MOVE_SUCCESS_TEXT, fromPath, toPath))

                ' Raise event to increment moved files count.
                RaiseEvent IncrementMoved()

                Return True

            Else

                ' Propagate error log and notification if source file does not exist.
                PropagateLog(LogType.MoveError, String.Format(NOTIFICATION_IMG_MOVE_ERROR_NOT_EXIST_TEXT, fromPath))
                PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_IMG_MOVE_ERROR_NOT_EXIST_TEXT, fromPath))

                ' Raise event to increment move error count.
                RaiseEvent IncrementMoveError()

                Return False

            End If

        Catch ex As UnauthorizedAccessException

            ' Propagate error log and notification for permission issues.
            PropagateLog(LogType.MoveError, String.Format(NOTIFICATION_IMG_MOVE_ERROR_PERMISSION_TEXT, fromPath))
            PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_IMG_MOVE_ERROR_PERMISSION_TEXT, fromPath))

            ' Raise event to increment move error count.
            RaiseEvent IncrementMoveError()

            Return False

        Catch ex As IOException

            ' Propagate error log and notification for IO issues.
            PropagateLog(LogType.MoveError, String.Format(NOTIFICATION_IMG_MOVE_ERROR_IO_TEXT, fromPath & " " & ex.Message))
            PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_IMG_MOVE_ERROR_IO_TEXT, fromPath & " " & ex.Message))

            ' Raise event to increment move error count.
            RaiseEvent IncrementMoveError()

            Return False

        Catch ex As Exception

            ' Propagate generic error log and notification.
            PropagateLog(LogType.MoveError, String.Format(NOTIFICATION_GENERIC_EXCEPTION_TEXT, ex.Message))
            PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_GENERIC_EXCEPTION_TEXT, ex.Message))

            ' Raise event to increment move error count.
            RaiseEvent IncrementMoveError()

            Return False

        End Try

    End Function

    ''' <summary>
    ''' Deletes a file.
    ''' </summary>
    ''' <param name="filePath">The path to the file to be deleted.</param>
    ''' <returns></returns>
    Public Async Function DeleteFile(filePath As String) As Task(Of Boolean)
        Try

            ' Simulate processing delay.
            Await Task.Delay(PROCESSING_SPEED_MS)

            ' Check if the file exists.
            If File.Exists(filePath) Then

                ' Delete the file asynchronously.
                Await Task.Run(Sub() File.Delete(filePath))

                ' Propagate success log and notification.
                PropagateLog(LogType.ImageDeleted, String.Format(NOTIFICATION_IMG_DELETE_SUCCESS_TEXT, filePath))
                PropagateNotification(NotificationType.Success, String.Format(NOTIFICATION_IMG_DELETE_SUCCESS_TEXT, filePath))

                ' Raise event to increment deleted files count.
                RaiseEvent IncrementDeleted()

                Return True

            Else

                ' Propagate error log and notification if file does not exist.
                PropagateLog(LogType.DeleteError, String.Format(NOTIFICATION_IMG_DELETE_ERROR_NOT_EXIST_TEXT, filePath))
                PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_IMG_DELETE_ERROR_NOT_EXIST_TEXT, filePath))

                ' Raise event to increment delete error count.
                RaiseEvent IncrementDeleteError()

                Return False

            End If

        Catch ex As UnauthorizedAccessException

            ' Propagate error log and notification for permission issues.
            PropagateLog(LogType.DeleteError, String.Format(NOTIFICATION_IMG_DELETE_ERROR_PERMISSION_TEXT, filePath))
            PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_IMG_DELETE_ERROR_PERMISSION_TEXT, filePath))

            ' Raise event to increment delete error count.
            RaiseEvent IncrementDeleteError()

            Return False

        Catch ex As IOException

            ' Propagate error log and notification for IO issues.
            PropagateLog(LogType.DeleteError, String.Format(NOTIFICATION_IMG_DELETE_ERROR_IO_TEXT, filePath))
            PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_IMG_DELETE_ERROR_IO_TEXT, filePath))

            ' Raise event to increment delete error count.
            RaiseEvent IncrementDeleteError()

            Return False

        Catch ex As Exception

            ' Propagate generic error log and notification.
            PropagateLog(LogType.MoveError, String.Format(NOTIFICATION_GENERIC_EXCEPTION_TEXT, ex.Message))
            PropagateNotification(NotificationType.Exception, String.Format(NOTIFICATION_GENERIC_EXCEPTION_TEXT, ex.Message))

            ' Raise event to increment delete error count.
            RaiseEvent IncrementDeleteError()

            Return False

        End Try
    End Function

    ''' <summary>
    ''' Opens a folder in the default file explorer.
    ''' </summary>
    ''' <param name="folderPath">The path to the folder to be opened.</param>
    Public Sub OpenFolder(folderPath As String)

        ' Check if the application has access to the folder.
        If CanAccessFolder(folderPath) Then

            ' Check if the folder exists.
            If Directory.Exists(folderPath) Then

                ' Open the folder using the default file explorer.
                Process.Start(New ProcessStartInfo() With {
                    .FileName = folderPath,
                    .UseShellExecute = True,
                    .Verb = "open"
                })
                RaiseEvent BubbleNotification(New CustomException(NotificationType.Info, NOTIFICATION_DEFAULT_TEXT))
            Else

                ' Raise a notification event if the folder does not exist.
                RaiseEvent BubbleNotification(New CustomException(NotificationType.Exception, NOTIFICATION_FOLDER_NOT_EXIST_TEXT))

            End If

        End If


    End Sub

    Public Function CanAccessFolder(folderPath As String) As Boolean
        Try
            ' Attempt to enumerate the file system entries in the specified path to check for access.
            Using enumerator = Directory.EnumerateFileSystemEntries(folderPath).GetEnumerator()
                Return True
            End Using

        Catch ex As UnauthorizedAccessException

            RaiseEvent BubbleNotification(New CustomException(NotificationType.Exception, NOTIFICATION_FOLDER_UNAUTHORIZED_OPEN_TEXT))
            Return False

        Catch ex As Exception

            RaiseEvent BubbleNotification(New CustomException(NotificationType.Exception, NOTIFICATION_GENERIC_EXCEPTION_TEXT))
            Return False

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
