''' <summary>
''' Manager class to handle the display and interaction of MatchGroupForm windows.
''' </summary>
Public Class MatchGroupFormManager

#Region "Public Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementMoved()
    Public Event IncrementMoveError()
    Public Event IncrementDeleted()
    Public Event IncrementDeleteError()
    Public Event IncrementMatched()

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Asynchronously shows MatchGroupForm windows for each MatchGroup in the provided list.
    ''' </summary>
    ''' <param name="groups">List of MatchGroup objects to display.</param>
    ''' <param name="targetFolderPath">The target folder path for file operations.</param>
    ''' <returns>A Task representing the asynchronous operation.</returns>
    Public Async Function ShowGroupsAsync(groups As List(Of MatchGroup), targetFolderPath As String) As Task

        ' Prevent exceptions in integration tests without UI.
        If Application.OpenForms.Count = 0 Then
            Return
        End If

        ' Get the main application form to ensure UI thread context.
        Dim mainForm As Form = Application.OpenForms(0)

        ' Iterate through each MatchGroup for create and show a MatchGroupForm.
        For Each group In groups

            ' Create a new MatchGroupForm for the current group.
            Dim mathGroupForm As New MatchGroupForm(group, targetFolderPath)

            ' Subscribe to form events to propagate them.
            AddHandler mathGroupForm.BubbleNotification, AddressOf OnBubbleNotification
            AddHandler mathGroupForm.BubbleLog, AddressOf OnBubbleLog
            AddHandler mathGroupForm.IncrementMoved, AddressOf OnIncrementMoved
            AddHandler mathGroupForm.IncrementMoveError, AddressOf OnIncrementMoveError
            AddHandler mathGroupForm.IncrementDeleted, AddressOf OnIncrementDeleted
            AddHandler mathGroupForm.IncrementDeleteError, AddressOf OnIncrementDeleteError
            AddHandler mathGroupForm.IncrementMatched, AddressOf OnIncrementMatched

            ' Initially show the form minimized and in the taskbar.
            mathGroupForm.WindowState = FormWindowState.Minimized
            mathGroupForm.ShowInTaskbar = True

            ' Prepare the form asynchronously, load data and initialize UI.
            Await mathGroupForm.PrepareAsync()

            ' Invoke on the main form's UI thread to show in normal state.
            Await mainForm.InvokeAsync(
                Sub()
                    mathGroupForm.Show()
                    mathGroupForm.WindowState = FormWindowState.Normal
                End Sub)

            ' Small delay for avoiding UI thread congestion.
            Await Task.Delay(DELAY_FORM_CHILD_SHOW_MS)
        Next
    End Function
#End Region

#Region "Event Handlers"

    ' Event handler to propagate notifications.
    Private Sub OnBubbleNotification(ex As CustomException)
        RaiseEvent BubbleNotification(ex)
    End Sub

    ' Event handler to propagate log entries.
    Private Sub OnBubbleLog(log As LogEntry)
        RaiseEvent BubbleLog(log)
    End Sub

    ' Event handler to propagate increment events.
    Private Sub OnIncrementMoved()
        RaiseEvent IncrementMoved()
    End Sub

    ' Event handler to propagate increment error events.
    Private Sub OnIncrementMoveError()
        RaiseEvent IncrementMoveError()
    End Sub

    ' Event handler to propagate increment deleted events.
    Private Sub OnIncrementDeleted()
        RaiseEvent IncrementDeleted()
    End Sub

    ' Event handler to propagate increment delete error events.
    Private Sub OnIncrementDeleteError()
        RaiseEvent IncrementDeleteError()
    End Sub

    ' Event handler to propagate increment matched events.
    Private Sub OnIncrementMatched()
        RaiseEvent IncrementMatched()
    End Sub

#End Region

End Class
