Imports System.IO


Public Class UngroupedFileMover

#Region "Fields"

    Private ReadOnly _fileManager As New FileManager()

#End Region

#Region "Public Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementMoved()
    Public Event IncrementMoveError()

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Asynchronously moves ungrouped files to the target folder.
    ''' </summary>
    ''' <param name="ungroupedPaths">The file paths to move.</param>
    ''' <param name="targetFolderPath">The target folder path.</param>
    ''' <returns></returns>
    Public Async Function MoveFiles(ungroupedPaths As IEnumerable(Of String), targetFolderPath As String) As Task

        ' Subscribe to FileManager events.
        AddHandler _fileManager.BubbleLog, AddressOf OnBubbleLog
        AddHandler _fileManager.BubbleNotification, AddressOf OnBubbleNotification
        AddHandler _fileManager.IncrementMoved, AddressOf OnIncrementMoved
        AddHandler _fileManager.IncrementMoveError, AddressOf OnIncrementMoveError

        Try

            ' Move each file asynchronously.
            For Each p In ungroupedPaths

                ' Determine destination path.
                Dim fileName = Path.GetFileName(p)
                Dim destinationPath = Path.Combine(targetFolderPath, fileName)

                ' Move the file.
                Await _fileManager.MoveFile(p, destinationPath)

            Next

        Finally

            ' Unsubscribe to avoid duplicate handlers in future calls
            RemoveHandler _fileManager.BubbleLog, AddressOf OnBubbleLog
            RemoveHandler _fileManager.BubbleNotification, AddressOf OnBubbleNotification
            RemoveHandler _fileManager.IncrementMoved, AddressOf OnIncrementMoved
            RemoveHandler _fileManager.IncrementMoveError, AddressOf OnIncrementMoveError

        End Try
    End Function

#End Region

#Region "Event Handlers"

    ' Event handlers to propagate notifications.
    Private Sub OnBubbleNotification(ex As CustomException)
        RaiseEvent BubbleNotification(ex)
    End Sub

    ' Event handlers to propagate log entries.
    Private Sub OnBubbleLog(log As LogEntry)
        RaiseEvent BubbleLog(log)
    End Sub

    ' Event handlers to propagate increment events.
    Private Sub OnIncrementMoved()
        RaiseEvent IncrementMoved()
    End Sub

    ' Event handlers to propagate increment error events.
    Private Sub OnIncrementMoveError()
        RaiseEvent IncrementMoveError()
    End Sub

#End Region

End Class