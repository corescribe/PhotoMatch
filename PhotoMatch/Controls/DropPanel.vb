Imports System.ComponentModel

Public Class DropPanel
    Inherits FlowLayoutPanel

#Region "Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleLog(log As LogEntry)
    Public Event IncrementMoveError()
    Public Event IncrementMoved()
    Public Event IncrementDeleteError()
    Public Event IncrementDeleted()
    Public Event ResetProcess(totalImages As Integer)
    Public Event IncrementProcessed()
    Public Event IncrementGrouped()
    Public Event IncrementMatched()
    Public Event IncrementCompared()

#End Region

#Region "Fields"

    Private _borderColor As Color = COLOR_BORDER_OFF
    Private _foreColor As Color = COLOR_FONT_WATER_MARK
    Private _text As String = DROP_PANEL_DEFAULT_TEXT
    Private _selectedPath As String
    Private WithEvents _imageProcessor As New ImageProcessor()

#End Region

#Region "Properties"

    ' SelectedPath property.
    <Category("Propiedades"), Description("Establece o devuelve la carpeta actual seleccionada.")>
    Public Property SelectedPath As String
        Get
            Return _selectedPath
        End Get
        Set(value As String)
            _selectedPath = value
        End Set
    End Property

#End Region

#Region "Constructor"
    Public Sub New()
        Me.AllowDrop = True
        ' Subscribe to validation failed event from ImageHelper.
        AddHandler BubbleValidation, AddressOf OnBubbleValidation
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Process images from the provided file paths.
    ''' </summary>
    ''' <param name="paths">Array of file paths to process.</param>
    ''' <returns>Async Task.</returns>
    Private Async Function ProcessImages(paths As String()) As Task

        ' Get valid image files from the provided paths.
        Dim validSourceFiles = GetValidFiles(paths)
        ' Count valid images in source and target directories.
        Dim countValidImagesSource As Integer = validSourceFiles.Count()
        Dim countValidImagesTarget As Integer = GetValidFiles(_selectedPath).Count()
        Dim totalImages As Integer = countValidImagesTarget + countValidImagesSource

        ' Check if there are valid images to process.
        If countValidImagesSource = 0 Then
            ' No valid images found, reset UI and notify.
            ResetUIAndNotify(NotificationType.Warning, NOTIFICATION_ZERO_FILES_TEXT)
            Return
        End If

        ' Notify total images to process.
        RaiseEvent ResetProcess(totalImages)

        ' Delete previous handlers to avoid multiple subscriptions.
        RemoveHandler _imageProcessor.IncrementGrouped, AddressOf OnIncrementGrouped
        RemoveHandler _imageProcessor.IncrementMatched, AddressOf OnIncrementMatched
        RemoveHandler _imageProcessor.IncrementCompared, AddressOf OnIncrementCompared

        ' Add event handlers for image processing events.
        AddHandler _imageProcessor.IncrementGrouped, AddressOf OnIncrementGrouped
        AddHandler _imageProcessor.IncrementMatched, AddressOf OnIncrementMatched
        AddHandler _imageProcessor.IncrementCompared, AddressOf OnIncrementCompared

        ' Start processing images asynchronously.
        Await _imageProcessor.InitProcess(validSourceFiles, _selectedPath)

    End Function

#End Region

#Region "Private Methods UI"

    ' Draw dashed border around the FlowLayoutPanel.
    Private Sub DrawDashedBorder(e As PaintEventArgs)

        ' Create pen with specified border color and thickness.
        Dim pen As New Pen(_borderColor, BORDER_THICKNESS)

        ' Set pen dash style to dotted.
        pen.DashStyle = Drawing2D.DashStyle.Dot

        ' Draw rectangle border.
        e.Graphics.DrawRectangle(pen,
            CSng(BORDER_THICKNESS / 2),
            CSng(BORDER_THICKNESS / 2),
            Me.Width - BORDER_THICKNESS,
            Me.Height - BORDER_THICKNESS)
    End Sub

    ' Draw centered text within the FlowLayoutPanel.
    Private Sub DrawCenteredText(e As PaintEventArgs)

        ' Measure the size of the text to be drawn.
        Dim textSize As SizeF = e.Graphics.MeasureString(_text, Me.Font)

        ' Calculate position to center the text.
        Dim x As Single = (Me.ClientSize.Width - textSize.Width) / 2
        Dim y As Single = (Me.ClientSize.Height - textSize.Height) / 2

        ' Draw the text at the calculated position.
        e.Graphics.DrawString(_text, Me.Font, New SolidBrush(_foreColor), x, y)
    End Sub

    ' Reset UI to default state and notify via event.
    Private Sub ResetUIAndNotify(notificationType As NotificationType, message As String)
        ChangeUI(DROP_PANEL_DEFAULT_TEXT, COLOR_FONT_OFF, COLOR_BORDER_OFF)
        ' Trigger the event and send data to [PhotoMatchForm].
        RaiseEvent BubbleNotification(New CustomException(notificationType, message))
    End Sub

    ' Change UI elements and invalidate to trigger repaint.
    Private Sub ChangeUI(text As String, foreColor As Color, borderColor As Color)
        _text = text
        _foreColor = foreColor
        _borderColor = borderColor
        Me.Invalidate()
    End Sub

#End Region

#Region "Drag and Drop Overrides"

    ' Override OnPaint to draw custom border and text.
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        DrawDashedBorder(e)
        DrawCenteredText(e)
    End Sub

    ' Override drag enter event to handle file drop validation.
    Protected Overrides Sub OnDragEnter(e As DragEventArgs)
        MyBase.OnDragEnter(e)

        Try
            ' Disable drop by default.
            e.Effect = DragDropEffects.None

            ' Validate if dropped files are valid.
            If InvalidFiles(e) Then Return

            ' Get dropped file paths.
            Dim paths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            ' Validate if dropped paths are the same as the selected path.
            If paths.Any(Function(p) SamePath(p, _selectedPath)) Then
                ResetUIAndNotify(NotificationType.Exception, NOTIFICATION_EQUALS_PATHS_TEXT)
                Return
            End If

            ' Validate if folders are included.
            If ContainsFolders(paths) Then
                ResetUIAndNotify(NotificationType.Exception, NOTIFICATION_NO_FOLDERS_TEXT)
                Return
            End If

            ' Validate if there are files to process.
            If FileListIsEmpty(paths) Then
                ResetUIAndNotify(NotificationType.Exception, NOTIFICATION_ZERO_FILES_TEXT)
                Return
            End If

            ' Validate if selected path exists.
            If SelectedPathNotExist(_selectedPath) Then
                ResetUIAndNotify(NotificationType.Exception, NOTIFICATION_PATH_NOT_EXIST_TEXT)
                Return
            End If

            ' Validate if selected path is empty.
            If SelectedPathIsEmpty(_selectedPath) Then
                ResetUIAndNotify(NotificationType.Exception, NOTIFICATION_PATH_EMPTY_TEXT)
                Return
            End If

            ' All validations passed, enable drop.
            Dim folderName As String = IO.Path.GetFileName(_selectedPath)
            e.Effect = DragDropEffects.Copy

            ' Update UI to indicate valid drop target.
            ChangeUI(String.Format(DROP_PANEL_MOVE_TEXT, paths.Length, folderName), COLOR_FONT_ON, COLOR_BORDER_ON)

        Catch ex As Exception
            ResetUIAndNotify(NotificationType.Exception, String.Format(NOTIFICATION_GENERIC_EXCEPTION_TEXT, ex.Message))
        End Try

    End Sub

    ' Override drag leave event to reset UI.
    Protected Overrides Sub OnDragLeave(e As EventArgs)
        MyBase.OnDragLeave(e)
        ResetUIAndNotify(NotificationType.Info, NOTIFICATION_DEFAULT_TEXT)
    End Sub

    ' Override drag drop event to process images.
    Protected Overrides Async Sub OnDragDrop(e As DragEventArgs)
        MyBase.OnDragDrop(e)

        ' Reset UI after drop.
        ChangeUI(DROP_PANEL_DEFAULT_TEXT, COLOR_FONT_OFF, COLOR_BORDER_OFF)

        ' Get dropped file paths.
        Dim paths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

        ' Process images asynchronously.
        Await ProcessImages(paths)
    End Sub

#End Region

#Region "Controls Events"

    ' Handle right-click event to open selected folder.
    Private Sub Control_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.Click

        ' Check if right mouse button was clicked.
        If (e.Button = MouseButtons.Right) Then
            ' Open the selected folder using FileManager.
            Dim fileManager As New FileManager()
            AddHandler fileManager.BubbleNotification, AddressOf OnBubbleNotification
            fileManager.OpenFolder(_selectedPath)
        End If

    End Sub

#End Region

#Region "Event Handlers"

    ' Handle event notification from [ImageProcessor] to [PhotoMatchForm].
    Private Sub OnBubbleNotification(ex As CustomException) Handles _imageProcessor.BubbleNotification
        RaiseEvent BubbleNotification(ex)
    End Sub

    ' Handle event log process from [ImageProcessor] to [PhotoMatchForm].
    Private Sub OnBubbleLog(log As LogEntry) Handles _imageProcessor.BubbleLog
        RaiseEvent BubbleLog(log)
    End Sub

    ' Handle event increment moved from [ImageProcessor] to [PhotoMatchForm].
    Private Sub OnIncrementMoved() Handles _imageProcessor.IncrementMoved
        RaiseEvent IncrementMoved()
    End Sub

    ' Handle event increment move error from [ImageProcessor] to [PhotoMatchForm].
    Private Sub OnIncrementMoveError() Handles _imageProcessor.IncrementMoveError
        RaiseEvent IncrementMoveError()
    End Sub

    ' Handle event increment deleted from [ImageProcessor] to [PhotoMatchForm].
    Private Sub OnIncrementDeleted() Handles _imageProcessor.IncrementDeleted
        RaiseEvent IncrementDeleted()
    End Sub

    ' Handle event increment delete error from [ImageProcessor] to [PhotoMatchForm].
    Private Sub OnIncrementDeleteError() Handles _imageProcessor.IncrementDeleteError
        RaiseEvent IncrementDeleteError()
    End Sub

    ' Handle event increment processed from [ImageProcessor] to [PhotoMatchForm].
    Private Sub OnIncrementProcessed() Handles _imageProcessor.IncrementProcessed
        RaiseEvent IncrementProcessed()
    End Sub

    ' Handle event processed image from [ImagePreprocessor] to [DropPanel] user control.
    Private Sub OnIncrementGrouped()
        RaiseEvent IncrementGrouped()
    End Sub

    ' Handle event processed image from [ImagePreprocessor] to [DropPanel] user control.
    Private Sub OnIncrementMatched()
        RaiseEvent IncrementMatched()
    End Sub

    ' Handle event processed image from [ImagePreprocessor] to [DropPanel] user control.
    Private Sub OnIncrementCompared()
        RaiseEvent IncrementCompared()
    End Sub

    ' Handle validation failed event from ImageHelper.
    Private Sub OnBubbleValidation(errorMessage As String, notificationType As NotificationType)
        ResetUIAndNotify(notificationType, errorMessage)
    End Sub

#End Region

End Class
