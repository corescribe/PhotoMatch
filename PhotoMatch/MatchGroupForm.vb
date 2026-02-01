Imports System.IO
Public Class MatchGroupForm

#Region "Public Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementMoveError()
    Public Event IncrementMoved()
    Public Event IncrementDeleteError()
    Public Event IncrementDeleted()
    Public Event IncrementMatched()

#End Region

#Region "Fields"

    Private _group As MatchGroup
    Private _successAction As Boolean = False
    Private WithEvents _fileManager As FileManager
    Private _destinationPath As String

#End Region

#Region "Constructor"

    Public Sub New(group As MatchGroup, destinationPath As String)

        InitializeComponent()

        _group = group
        _destinationPath = destinationPath
        _fileManager = New FileManager()

    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Asynchronously prepares the MatchGroupForm by loading images and initializing UI components.
    ''' </summary>
    ''' <returns></returns>
    Public Async Function PrepareAsync() As Task

        Dim counter As Integer = 0
        ' Sort images by file size in descending order
        Dim sortedImgReferences = _group.SourceImages.Concat(_group.TargetImages).OrderByDescending(Function(c) c.ImageData.FileWeight).ToList()

        ' Iterate through each image reference in the sorted list
        For Each imgReference In sortedImgReferences

            ' Create MatchImage control on a background thread
            Dim imgReferenceUC As MatchImage = Nothing
            Await Task.Run(
                Sub()
                    imgReferenceUC = New MatchImage(imgReference)
                    imgReferenceUC.Width = flpGroup.ClientSize.Width
                    imgReferenceUC.Margin = New Padding(0)
                End Sub)

            ' Raise event to increment matched counter.
            RaiseEvent IncrementMatched()

            ' Propagate success log and notification.
            PropagateLog(LogType.ImageMatched, String.Format(NOTIFICATION_IMG_MATCHED_TEXT, imgReference.FullPath))
            PropagateNotification(NotificationType.Success, String.Format(NOTIFICATION_IMG_MATCHED_TEXT, imgReference.FullPath))

            ' Add the control to the flow layout panel.
            flpGroup.Controls.Add(imgReferenceUC)
            counter += 1
        Next

        ' Update the counter label.
        lblCounter.Text = counter.ToString()
    End Function

#End Region

#Region "Form Events"

    Private Sub MatchGroupForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        ' Make controls visible after form is shown to avoid flickering.
        lblHeadTitle.Visible = True
        lblCounter.Visible = True
        lblSubHeadTitle.Visible = True
        btnApply.Visible = True

    End Sub

    Private Sub MatchGroupForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        ' Dispose images and controls to free resources.
        For Each control As MatchImage In flpGroup.Controls

            ' Release image resources.
            control.ReleaseImage()

            ' Dispose control.
            control.Dispose()

        Next

        ' Clear the controls from the flow layout panel.
        flpGroup.Controls.Clear()

    End Sub

#End Region

#Region "Control Events"

    Private Async Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        ' Ensure the action is only performed once.
        If Not _successAction Then
            _successAction = True

            ' Process each MatchImage user control in the flow layout panel.
            For Each control As MatchImage In flpGroup.Controls

                ' Get the source file path.
                Dim fromPath = control.GetPath

                ' Release image resources.
                control.ReleaseImage()

                ' Check if the control is selected.
                If control.GetSelection Then

                    ' If selected, move the file if it is from the origin source.
                    If control.GetSource = ImageSource.Origin Then

                        ' Get the destination file path.
                        Dim toPath = Path.Combine(_destinationPath, Path.GetFileName(control.GetPath))
                        ' Move the file.
                        Await _fileManager.MoveFile(fromPath, toPath)

                    End If

                Else

                    ' If not selected, delete the file.
                    Await _fileManager.DeleteFile(fromPath)

                End If

            Next

            ' Dispose images and controls to free resources.
            For Each control As MatchImage In flpGroup.Controls
                control.Dispose()
            Next

            ' Clear the controls from the flow layout panel.
            flpGroup.Controls.Clear()

            ' Close the form.
            Close()
        End If

    End Sub

    Private Sub btnApply_MouseLeave(sender As Object, e As EventArgs) Handles btnApply.MouseLeave
        btnApply.BackColor = Color.WhiteSmoke
        btnApply.ForeColor = Color.DarkGray
    End Sub

    Private Sub btnApply_MouseEnter(sender As Object, e As EventArgs) Handles btnApply.MouseEnter
        btnApply.BackColor = Color.FromArgb(59, 41, 255)
        btnApply.ForeColor = Color.White
    End Sub

    Private Sub flpGroup_SizeChanged(sender As Object, e As EventArgs) Handles flpGroup.SizeChanged

        ' Adjust the width of each control in the flow layout panel when its size changes.
        For Each control As Control In flpGroup.Controls
            control.Width = flpGroup.ClientSize.Width - control.Margin.Horizontal
        Next

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Adds a MatchImage user control to the flow layout panel for the given image reference.
    ''' </summary>
    ''' <param name="imgReference">The image reference to display.</param>
    Private Sub AddMatchImageUC(imgReference As ImageReference)

        ' Create a new MatchImage control.
        Dim matchImageUC As New MatchImage(imgReference)

        ' Set the width and margin.
        matchImageUC.Width = flpGroup.ClientSize.Width
        matchImageUC.Margin = New Padding(0)

        ' Add the control to the flow layout panel.
        flpGroup.Controls.Add(matchImageUC)

        ' Raise event to increment matched counter.
        RaiseEvent IncrementMatched()

        ' Propagate success log and notification.
        PropagateLog(LogType.ImageMatched, String.Format(NOTIFICATION_IMG_MATCHED_TEXT, imgReference.FullPath))
        PropagateNotification(NotificationType.Success, String.Format(NOTIFICATION_IMG_MATCHED_TEXT, imgReference.FullPath))

    End Sub

#End Region

#Region "FileManager Event Handlers"

    ' Event handler to propagate notifications.
    Private Sub OnBubbleNotification(ex As CustomException) Handles _fileManager.BubbleNotification
        RaiseEvent BubbleNotification(ex)
    End Sub

    ' Event handler to propagate log entries.
    Private Sub OnBubbleLog(log As LogEntry) Handles _fileManager.BubbleLog
        RaiseEvent BubbleLog(log)
    End Sub

    ' Event handlers to propagate moved images increment.
    Private Sub OnIncrementMoved() Handles _fileManager.IncrementMoved
        RaiseEvent IncrementMoved()
    End Sub

    ' Event handlers to propagate move error increment.
    Private Sub OnIncrementMoveError() Handles _fileManager.IncrementMoveError
        RaiseEvent IncrementMoveError()
    End Sub

    ' Event handlers to propagate deleted images increment.
    Private Sub OnIncrementDeleted() Handles _fileManager.IncrementDeleted
        RaiseEvent IncrementDeleted()
    End Sub

    ' Event handlers to propagate delete error increment.
    Private Sub OnIncrementDeleteError() Handles _fileManager.IncrementDeleteError
        RaiseEvent IncrementDeleteError()
    End Sub


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

