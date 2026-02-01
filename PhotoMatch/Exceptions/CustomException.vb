''' <summary>
''' Custom exception that includes a notification type.
''' </summary>
Public NotInheritable Class CustomException
    Inherits Exception

    ' The type of notification associated with this exception.
    Public ReadOnly Property NotificationType As NotificationType

    ' Constructor to initialize the custom exception with a notification type and message.
    Public Sub New(type As NotificationType, message As String)
        MyBase.New(message)
        Me.NotificationType = type
    End Sub

End Class