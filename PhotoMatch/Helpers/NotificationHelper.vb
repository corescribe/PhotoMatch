''' <summary>
''' Helper module for notification color management.
''' </summary>
Public Module NotificationHelper

    ''' <summary>
    ''' Gets the background color for a given notification type.
    ''' </summary>
    ''' <param name="type">The notification type.</param>
    ''' <returns>The background color.</returns>
    Public Function GetBackgroundColor(type As NotificationType) As Color
        Select Case type
            Case NotificationType.Info
                Return COLOR_BACKGROUND_NOTIFICATION_INFO
            Case NotificationType.Success
                Return COLOR_BACKGROUND_NOTIFICATION_SUCCESS
            Case NotificationType.Warning
                Return COLOR_BACKGROUND_NOTIFICATION_WARNING
            Case NotificationType.Exception
                Return COLOR_BACKGROUND_NOTIFICATION_ERROR
            Case Else
                Return COLOR_BACKGROUND_NOTIFICATION_DEFAULT
        End Select
    End Function

    ''' <summary>
    ''' Gets the foreground color for a given notification type.
    ''' </summary>
    ''' <param name="type">The notification type.</param>
    ''' <returns>The foreground color.</returns>
    Public Function GetForeColor(type As NotificationType) As Color
        Select Case type
            Case NotificationType.Info
                Return COLOR_FONT_NOTIFICATION_INFO
            Case NotificationType.Success
                Return COLOR_FONT_NOTIFICATION_SUCCESS
            Case NotificationType.Warning
                Return COLOR_FONT_NOTIFICATION_WARNING
            Case NotificationType.Exception
                Return COLOR_FONT_NOTIFICATION_ERROR
            Case Else
                Return COLOR_FONT_NOTIFICATION_DEFAULT
        End Select
    End Function

End Module