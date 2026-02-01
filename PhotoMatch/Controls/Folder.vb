Imports System.ComponentModel
Public Class Folder
    Inherits UserControl

#Region "Events"

    Public Event BubbleNotification(ex As CustomException)
    Public Event BubbleOpen(path As String)

#End Region

#Region "Fields"

    Private _folderName As String
    Private _parentFolder As String

#End Region

#Region "Properties"

    ' Folder name property
    <Category("Propiedades"), Description("Establece o devuelve el nombre de la carpeta.")>
    Public Property FolderName As String
        Get
            Return _folderName
        End Get
        Set(value As String)
            _folderName = value
            lblName.Text = _folderName
        End Set
    End Property

    ' Parent folder property
    <Category("Propiedades"), Description("Establece o devuelve la carpeta padre.")>
    Public Property ParentFolder As String
        Get
            Return _parentFolder
        End Get
        Set(value As String)
            _parentFolder = value
        End Set
    End Property

#End Region

#Region "Constructor"

    Public Sub New(parentFolder As String, folderName As String)
        InitializeComponent()
        _folderName = folderName
        _parentFolder = parentFolder
        lblName.Text = _folderName
    End Sub

#End Region

#Region "Control Events"

    Private Sub Control_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.Click, pbFolder.Click, lblName.Click

        ' Create a FileManager instance to handle folder operations.
        Dim fileManager As New FileManager()
        AddHandler fileManager.BubbleNotification, AddressOf OnBubbleNotification

        ' Construct the full path to the folder.
        Dim accessToPath As String
        ' Check if the parent folder is the root drive path to avoid double backslashes.
        If _parentFolder.Equals(GetRootDrivePath) Then
            accessToPath = $"{_parentFolder}{_folderName}"
        Else
            accessToPath = $"{_parentFolder}\{_folderName}"
        End If

        ' Verify access to the folder.
        If Not fileManager.CanAccessFolder(accessToPath) Then
            RaiseEvent BubbleNotification(New CustomException(NotificationType.Exception, NOTIFICATION_FOLDER_UNAUTHORIZED_OPEN_TEXT))
            Return
        End If

        ' Open the folder in explorer if right-clicked.
        If (e.Button = MouseButtons.Right) Then
            fileManager.OpenFolder(accessToPath)
        End If

        ' Notify that the folder has been accessed.
        RaiseEvent BubbleNotification(New CustomException(NotificationType.Info, NOTIFICATION_DEFAULT_TEXT))
        RaiseEvent BubbleOpen(accessToPath)

    End Sub

#End Region

#Region "Event Handlers"

    ' Handle event notification from [MathGroupForm] to [DropPanel] user control.
    Private Sub OnBubbleNotification(ex As CustomException)
        RaiseEvent BubbleNotification(ex)
    End Sub

#End Region

End Class
