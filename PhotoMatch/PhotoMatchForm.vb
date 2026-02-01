Imports System.IO

Public Class PhotoMatchForm

#Region "Fields"

    Private _notification As Notification
    Private _totalProcessCount As Integer
    Private _currentProcessCount As Integer
    Private _totalMatchCount As Integer
    Private _currentMatchCount As Integer

#End Region

#Region "Control Events"

    Sub PhotoMatchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Subscribe to DropPanel events.
        AddHandler flpFolders.BubbleNotification, AddressOf OnNotificated
        AddHandler flpFolders.BubbleLog, AddressOf OnLogProcessed
        AddHandler flpFolders.IncrementMoved, AddressOf OnIncrementMoved
        AddHandler flpFolders.IncrementDeleted, AddressOf OnIncrementDeleted
        AddHandler flpFolders.IncrementMoveError, AddressOf OnIncrementMoveError
        AddHandler flpFolders.IncrementDeleteError, AddressOf OnIncrementDeleteError
        AddHandler flpFolders.ResetProcess, AddressOf OnResetProcess
        AddHandler flpFolders.IncrementProcessed, AddressOf OnIncrementProcessed
        AddHandler flpFolders.IncrementGrouped, AddressOf OnIncrementGrouped
        AddHandler flpFolders.IncrementCompared, AddressOf OnIncrementCompared
        AddHandler flpFolders.IncrementMatched, AddressOf OnIncrementMatched

        ' Subscribe to CounterDisplay MouseHover events.
        AddHandler counterImagesProcessed.Clicked, AddressOf OnClickDetail
        AddHandler counterImagesCompared.Clicked, AddressOf OnClickDetail
        AddHandler counterImagesMatched.Clicked, AddressOf OnClickDetail
        AddHandler counterImagesMoved.Clicked, AddressOf OnClickDetail
        AddHandler counterImagesDeleted.Clicked, AddressOf OnClickDetail
        AddHandler counterMoveErrors.Clicked, AddressOf OnClickDetail
        AddHandler counterDeleteErrors.Clicked, AddressOf OnClickDetail

        ' Initialize notification control.
        _notification = New Notification(NotificationType.Info, NOTIFICATION_DEFAULT_TEXT)
        pnlNotification.Controls.Add(_notification)

        ' Set default folder path to Desktop.
        Dim defaultPath = GetDesktopPath()
        lblFolderPath.Text = defaultPath
        flpFolders.SelectedPath = defaultPath

        ' Show default directory.
        ShowDirectory(flpFolders.SelectedPath)
    End Sub
    Private Sub btnBackFolder_Click(sender As Object, e As EventArgs) Handles btnBackFolder.Click

        ' Get parent directory.
        Dim parentPath As String = Directory.GetParent(flpFolders.SelectedPath)?.FullName

        ' Show parent directory or notify if at root.
        If Not String.IsNullOrEmpty(parentPath) Then
            ShowDirectory(parentPath)
        Else
            _notification.Message = NOTIFICATION_FOLDER_ARE_IN_ROOT_TEXT
            _notification.NotificationType = NotificationType.Exception
        End If

    End Sub

    Private Sub btnUpdateFolder_Click(sender As Object, e As EventArgs) Handles btnUpdateFolder.Click
        ShowDirectory(flpFolders.SelectedPath)
    End Sub

    Private Sub btnUpdateFolder_MouseEnter(sender As Object, e As EventArgs) Handles btnUpdateFolder.MouseEnter
        btnUpdateFolder.Image = My.Resources.updateOn
    End Sub

    Private Sub btnUpdateFolder_MouseLeave(sender As Object, e As EventArgs) Handles btnUpdateFolder.MouseLeave
        btnUpdateFolder.Image = My.Resources.updateOff
    End Sub

    Private Sub btnBackFolder_MouseEnter(sender As Object, e As EventArgs) Handles btnBackFolder.MouseEnter
        btnBackFolder.Image = My.Resources.backOn
    End Sub

    Private Sub btnBackFolder_MouseLeave(sender As Object, e As EventArgs) Handles btnBackFolder.MouseLeave
        btnBackFolder.Image = My.Resources.backOff
    End Sub

#End Region

#Region "Event Handlers"

    ' Handles the folder open event to display the selected directory.
    Private Sub OnFolderOpen(path)
        ShowDirectory(path)
    End Sub

    ' Handles notification events to update the notification control.
    Private Sub OnNotificated(ex As CustomException)

        ' Update notification control on the UI thread.
        If _notification.InvokeRequired Then
            _notification.Invoke(New Action(Of CustomException)(AddressOf OnNotificated), ex)
        Else
            ' Set notification message and type.
            _notification.Message = ex.Message
            _notification.NotificationType = ex.NotificationType
            ' Refresh the notification display.
            _notification.Refresh()
        End If

    End Sub

    ' Handles log events to append log entries and update log availability.
    Private Sub OnLogProcessed(log As LogEntry)

        ' Append line to the log file.
        AppendLogLine(log.LogType, log.LogMessage)

        ' Get log file path and corresponding counter display.
        Dim logFilePath As String = GetLogFilePath(log.LogType)
        Dim counterDisplay = GetCounterDisplayByLogType(log.LogType)

        ' Update counter display log availability.
        If counterDisplay IsNot Nothing Then
            counterDisplay.EnableLog = File.Exists(logFilePath)
        End If

    End Sub

    ' Handles the reset process event to initialize counters and progress bars.
    Private Sub OnResetProcess(totalProcessImages As Integer)

        ' Initialize counters.
        _totalProcessCount = totalProcessImages
        _currentProcessCount = 0
        _totalMatchCount = 0
        _currentMatchCount = 0

        ' Reset progress bars.
        ResetProgress(proBarProcessed, lblProBarProcessedCounter, totalProcessImages)
        ResetProgress(proBarGrouped, lblProBarGroupedCounter, _totalMatchCount)

    End Sub

    ' Handles the increment processed event to update counters and progress bar.
    Private Sub OnIncrementProcessed()

        ' Update processed image counters and progress bar.
        _currentProcessCount += 1
        IncrementCounterDisplay(counterImagesProcessed)
        IncrementProgress(proBarProcessed, lblProBarProcessedCounter, _currentProcessCount, _totalProcessCount)

    End Sub

    ' Handles the increment grouped event to update total match count and reset grouped progress bar.
    Private Sub OnIncrementGrouped()

        ' Update total match count and reset grouped progress bar.
        _totalMatchCount += 1
        ResetProgress(proBarGrouped, lblProBarGroupedCounter, _totalMatchCount)

    End Sub

    ' Handles the increment matched event to update counters and progress bar.
    Private Sub OnIncrementMatched()

        ' Update matched image counters and progress bar.
        _currentMatchCount += 1
        IncrementCounterDisplay(counterImagesMatched)
        IncrementProgress(proBarGrouped, lblProBarGroupedCounter, _currentMatchCount, _totalMatchCount)

    End Sub

    ' Handles the increment compared event to update the compared images counter.
    Private Sub OnIncrementCompared()
        IncrementCounterDisplay(counterImagesCompared)
    End Sub

    ' Handles the increment moved event to update the moved images counter.
    Private Sub OnIncrementMoved()
        IncrementCounterDisplay(counterImagesMoved)
    End Sub

    ' Handles the increment deleted event to update the deleted images counter.
    Private Sub OnIncrementDeleted()
        IncrementCounterDisplay(counterImagesDeleted)
    End Sub

    ' Handles the increment move error event to update the move errors counter.
    Private Sub OnIncrementMoveError()
        IncrementCounterDisplay(counterMoveErrors)
    End Sub

    ' Handles the increment delete error event to update the delete errors counter.
    Private Sub OnIncrementDeleteError()
        IncrementCounterDisplay(counterDeleteErrors)
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Increments the counter display by 1.
    ''' </summary>
    ''' <param name="counterDisplay">The CounterDisplay control to increment.</param>
    Private Sub IncrementCounterDisplay(counterDisplay As CounterDisplay)

        ' Check if invocation is required for thread safety.
        If counterDisplay.InvokeRequired Then
            counterDisplay.Invoke(New Action(Of CounterDisplay)(AddressOf IncrementCounterDisplay), counterDisplay)
        Else
            ' Increment the counter and refresh the display.
            counterDisplay.Counter += 1
            counterDisplay.Refresh()
        End If

    End Sub

    ''' <summary>
    ''' Resets the progress bar and label to initial state.
    ''' </summary>
    ''' <param name="progressBar">ProgressBar control to reset.</param>
    ''' <param name="counterLabel">Label control to reset.</param>
    ''' <param name="totalCount">Total count for the progress bar maximum and label.</param>
    Private Sub ResetProgress(progressBar As ProgressBar, counterLabel As Label, totalCount As Integer)

        ' Check if invocation is required for thread safety.
        If progressBar.InvokeRequired OrElse counterLabel.InvokeRequired Then
            progressBar.Invoke(New Action(Of ProgressBar, Label, Integer)(AddressOf ResetProgress), progressBar, counterLabel, totalCount)
        Else
            ' Reset progress bar and label.
            progressBar.Minimum = 0
            progressBar.Maximum = totalCount
            progressBar.Value = 0
            counterLabel.Text = String.Format(LABEL_COUNTER_PROCESSED_IMAGES, 0, totalCount)
            progressBar.Refresh()
            counterLabel.Refresh()
        End If
    End Sub

    ''' <summary>
    ''' Increments the progress bar and updates the label with the current count.
    ''' </summary>
    ''' <param name="progressBar">ProgressBar control to increment.</param>
    ''' <param name="counterLabel">Label control to increment.</param>
    ''' <param name="currentCount">Current iteration count.</param>
    ''' <param name="totalCount">Total count for the progress bar maximum and label.</param>
    Private Sub IncrementProgress(progressBar As ProgressBar, counterLabel As Label, currentCount As Integer, totalCount As Integer)

        ' Check if invocation is required for thread safety.
        If progressBar.InvokeRequired OrElse counterLabel.InvokeRequired Then
            progressBar.Invoke(New Action(Of ProgressBar, Label, Integer, Integer)(AddressOf IncrementProgress), progressBar, counterLabel, currentCount, totalCount)
        Else
            ' Increment progress bar and update label.
            progressBar.Value += 1
            counterLabel.Text = String.Format(LABEL_COUNTER_PROCESSED_IMAGES, currentCount, totalCount)
            progressBar.Refresh()
            counterLabel.Refresh()
        End If
    End Sub

    ''' <summary>
    ''' Displays the directories in the specified path.
    ''' </summary>
    ''' <param name="selectPath">The path of the directory to display subdirectories.</param>
    Private Sub ShowDirectory(selectPath As String)
        Try

            ' Iterate all controls in flow layout panel to remove event handlers.
            For Each control As Control In flpFolders.Controls

                ' Check if the control is a Folder type.
                Dim folder As Folder = TryCast(control, Folder)
                If folder IsNot Nothing Then
                    ' Remove event handlers to prevent memory leaks.
                    RemoveHandler folder.BubbleOpen, AddressOf OnFolderOpen
                    RemoveHandler folder.BubbleNotification, AddressOf OnNotificated
                End If

            Next

            ' Check if the directory exists.
            If Directory.Exists(selectPath) Then

                ' Clear existing controls.
                flpFolders.Controls.Clear()

                ' Get all subdirectories.
                Dim directories As String() = Directory.GetDirectories(selectPath)

                ' Iterate and add each subdirectory as a Folder control.
                For Each directory As String In directories
                    ' Get folder name from path.
                    Dim folder As String = Path.GetFileName(directory)
                    ' Add folder control.
                    AddFolder(selectPath, folder)
                Next

            Else

                ' Set default folder path to Desktop.
                ShowDirectory(GetDesktopPath())
                ' Notify that the folder does not exist.
                _notification.Message = NOTIFICATION_FOLDER_NOT_EXIST_TEXT
                _notification.NotificationType = NotificationType.Exception

                Return

            End If

            ' Update current folder path display.
            lblFolderPath.Text = selectPath
            flpFolders.SelectedPath = selectPath

        Catch ex As UnauthorizedAccessException

            ' Notify unauthorized access exception.
            _notification.Message = NOTIFICATION_FOLDER_UNAUTHORIZED_ACCESS_TEXT
            _notification.NotificationType = NotificationType.Exception

        Catch ex As Exception

            ' Notify general exceptions.
            _notification.Message = NOTIFICATION_GENERIC_EXCEPTION_TEXT
            _notification.NotificationType = NotificationType.Exception
        End Try

    End Sub

    ''' <summary>
    ''' Adds a Folder control to the flow layout panel.
    ''' </summary>
    ''' <param name="parentFolder">The parent folder path.</param>
    ''' <param name="folderName">The name of the folder to add.</param>
    Private Sub AddFolder(parentFolder As String, folderName As String)

        ' Validate input parameters.
        If parentFolder Is Nothing Then
            Throw New ArgumentNullException(NameOf(parentFolder))
        End If

        ' Check for null folder name.
        If folderName Is Nothing Then
            Throw New ArgumentNullException(NameOf(folderName))
        End If

        ' Create new Folder control.
        Dim folder As New Folder(parentFolder, folderName)

        ' Subscribe to Folder events.
        AddHandler folder.BubbleOpen, AddressOf OnFolderOpen
        AddHandler folder.BubbleNotification, AddressOf OnNotificated

        ' Add Folder control to flow layout panel.
        flpFolders.Controls.Add(folder)

    End Sub

    ''' <summary>
    ''' Handles the click event on a CounterDisplay to open the corresponding log file.
    ''' </summary>
    ''' <param name="control">The CounterDisplay control that was clicked.</param>
    Private Sub OnClickDetail(control As CounterDisplay)

        ' Check if log is enabled for the control.
        If control.EnableLog Then
            OpenLogInNotepad(control.LogType)
        End If

    End Sub

    ''' <summary>
    ''' Gets the CounterDisplay control corresponding to the specified LogType.
    ''' </summary>
    ''' <param name="logType">The type of log.</param>
    ''' <returns>The corresponding CounterDisplay control, or Nothing if not found.</returns>
    Private Function GetCounterDisplayByLogType(logType As LogType) As CounterDisplay

        ' Return the corresponding CounterDisplay based on LogType.
        Select Case logType
            Case LogType.ImageProcessed : Return counterImagesProcessed
            Case LogType.ImageCompared : Return counterImagesCompared
            Case LogType.ImageMatched : Return counterImagesMatched
            Case LogType.ImageMoved : Return counterImagesMoved
            Case LogType.ImageDeleted : Return counterImagesDeleted
            Case LogType.MoveError : Return counterMoveErrors
            Case LogType.DeleteError : Return counterDeleteErrors
            Case Else : Return Nothing
        End Select
    End Function

#End Region

End Class
