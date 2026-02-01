''' <summary>
''' This class is responsible for processing images by coordinating preprocessing, comparison, grouping, and file management.
''' </summary>
Public Class ImageProcessor

#Region "Public Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementMoveError()
    Public Event IncrementMoved()
    Public Event IncrementDeleteError()
    Public Event IncrementDeleted()
    Public Event IncrementProcessed()
    Public Event IncrementGrouped()
    Public Event IncrementMatched()
    Public Event IncrementCompared()

#End Region

#Region "Fields"

    Private _imageDataBuffer As New Dictionary(Of String, ImageData)
    Private _imageReferencesBuffer As New Dictionary(Of String, List(Of ImageReference))
    Private WithEvents _imageGrouper As New ImageGrouper()

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Starts the image processing workflow including preprocessing, comparison, grouping, and file management.
    ''' </summary>
    ''' <param name="draggedPaths">The file paths of the dragged images.</param>
    ''' <param name="targetFolderPath">The target folder path for processing.</param>
    ''' <returns>A task representing the asynchronous operation.</returns>
    Public Async Function InitProcess(draggedPaths As String(), targetFolderPath As String) As Task

        Try

            ' Instantiate the preprocessor with the buffers.
            Dim preprocessor = New ImagePreprocessor(_imageDataBuffer, _imageReferencesBuffer)

            ' Subscribe to preprocessor events.
            AddHandler preprocessor.BubbleNotification, AddressOf OnBubbleNotification
            AddHandler preprocessor.BubbleLog, AddressOf OnBubbleLog
            AddHandler preprocessor.IncrementProcessed, AddressOf OnIncrementProcessed

            ' Preprocess images from both sources.
            Await preprocessor.InitPreProcess(draggedPaths, ImageSource.Origin)
            Await preprocessor.InitPreProcess(GetValidFiles(targetFolderPath), ImageSource.Target)

            ' Instantiate the comparer.
            Dim imageComparer = New ImageComparer()

            ' Subscribe to comparer events.
            AddHandler imageComparer.BubbleNotification, AddressOf OnBubbleNotification
            AddHandler imageComparer.BubbleLog, AddressOf OnBubbleLog
            AddHandler imageComparer.IncrementCompared, AddressOf OnIncrementCompared

            ' Compare preprocessed image references.
            Await imageComparer.Compare(_imageReferencesBuffer)

            ' Unsubscribe from comparer events to avoid duplicate handlers in future calls.
            RemoveHandler _imageGrouper.IncrementGrouped, AddressOf OnIncrementGrouped
            ' Subscribe to grouper events.
            AddHandler _imageGrouper.IncrementGrouped, AddressOf OnIncrementGrouped

            ' Create groups from the image references.
            Dim groups As List(Of MatchGroup) = Await _imageGrouper.CreateGroups(_imageReferencesBuffer)

            ' Determine ungrouped dragged paths.
            Dim groupedSourcePaths As New HashSet(Of String)(groups.SelectMany(Function(g) g.SourceImages).Select(Function(c) c.FullPath))
            ' Get ungrouped dragged paths.
            Dim ungroupedDraggedPaths = draggedPaths.Where(Function(p) Not groupedSourcePaths.Contains(p)).ToList()

            ' Instantiate the ungrouped file mover.
            Dim ungroupedFileMover = New UngroupedFileMover()

            ' Subscribe to ungrouped file mover events.
            AddHandler ungroupedFileMover.BubbleLog, AddressOf OnBubbleLog
            AddHandler ungroupedFileMover.BubbleNotification, AddressOf OnBubbleNotification
            AddHandler ungroupedFileMover.IncrementMoved, AddressOf OnIncrementMoved
            AddHandler ungroupedFileMover.IncrementMoveError, AddressOf OnIncrementMoveError

            ' Move the ungrouped files.
            Await ungroupedFileMover.MoveFiles(ungroupedDraggedPaths, targetFolderPath)

            ' Instantiate the match group form manager.
            Dim groupFormManager As New MatchGroupFormManager()

            ' Subscribe to match group form manager events.
            AddHandler groupFormManager.BubbleNotification, AddressOf OnBubbleNotification
            AddHandler groupFormManager.BubbleLog, AddressOf OnBubbleLog
            AddHandler groupFormManager.IncrementMoved, AddressOf OnIncrementMoved
            AddHandler groupFormManager.IncrementMoveError, AddressOf OnIncrementMoveError
            AddHandler groupFormManager.IncrementDeleted, AddressOf OnIncrementDeleted
            AddHandler groupFormManager.IncrementDeleteError, AddressOf OnIncrementDeleteError
            AddHandler groupFormManager.IncrementMatched, AddressOf OnIncrementMatched

            ' Show the match group forms.
            Await groupFormManager.ShowGroupsAsync(groups, targetFolderPath)

            ' Clear reference buffers to free memory.
            _imageReferencesBuffer.Clear()

        Catch ex As Exception

            ' Propagate any exceptions as notifications.
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

    ' Event handlers to propagate increment moved images.
    Private Sub OnIncrementMoved()
        RaiseEvent IncrementMoved()
    End Sub

    ' Event handlers to propagate increment move errors.
    Private Sub OnIncrementMoveError()
        RaiseEvent IncrementMoveError()
    End Sub

    ' Event handlers to propagate increment deleted images.
    Private Sub OnIncrementDeleted()
        RaiseEvent IncrementDeleted()
    End Sub

    ' Event handlers to propagate increment delete errors.
    Private Sub OnIncrementDeleteError()
        RaiseEvent IncrementDeleteError()
    End Sub

    ' Event handlers to propagate increment processed images.
    Private Sub OnIncrementProcessed()
        RaiseEvent IncrementProcessed()
    End Sub

    ' Event handlers to propagate increment grouped images.
    Private Sub OnIncrementGrouped()
        RaiseEvent IncrementGrouped()
    End Sub

    ' Event handlers to propagate increment matched images.
    Private Sub OnIncrementMatched()
        RaiseEvent IncrementMatched()
    End Sub

    ' Event handlers to propagate increment compared images.
    Private Sub OnIncrementCompared()
        RaiseEvent IncrementCompared()
    End Sub

#End Region

End Class
