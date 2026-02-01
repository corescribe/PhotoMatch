Imports System.ComponentModel

Public Class Notification

#Region "Fields"

    Private _notificationType As NotificationType
    Private _message As String

#End Region

#Region "Properties"

    ' NotificationType property.
    <Category("Custom Properties"), Description("Establece o devuelve el tipo de notificación.")>
    Public Property NotificationType As NotificationType
        Get
            Return _notificationType
        End Get
        Set(value As NotificationType)
            _notificationType = value
            ' Update notification style when type changes.
            SetNotificationStyle()
        End Set
    End Property

    ' Message property.
    <Category("Custom Properties"), Description("Establece o devuelve el mensaje de la notificación.")>
    Public Property Message As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = value
            ' Update notification style when message changes.
            SetNotificationStyle()
        End Set
    End Property

#End Region

#Region "Contructor"

    Public Sub New(type As NotificationType, message As String)

        InitializeComponent()

        ' Set properties.
        _notificationType = type
        _message = message

        ' Update notification style.
        SetNotificationStyle()

        ' Fill the control area.
        Me.Dock = DockStyle.Fill

    End Sub

#End Region

#Region "Private Methods"

    ' Set notification style.
    Private Sub SetNotificationStyle()

        ' Update label text and color safely.
        If lblMessage.InvokeRequired Then

            ' Invoke update on the UI thread.
            lblMessage.Invoke(
                Sub()
                    lblMessage.Text = _message
                    lblMessage.ForeColor = GetForeColor(_notificationType)
                End Sub)

        Else

            ' Direct update if on the same thread.
            lblMessage.Text = _message
            lblMessage.ForeColor = GetForeColor(_notificationType)

        End If

        ' Update background color.
        Me.BackColor = GetBackgroundColor(_notificationType)

    End Sub

#End Region

End Class