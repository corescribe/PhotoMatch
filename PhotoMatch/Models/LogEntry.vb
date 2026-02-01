''' <summary>
''' Represents a log entry with type, timestamp, and message.
''' </summary>
Public Class LogEntry

#Region "Public Properties"

    Public ReadOnly Property LogType As LogType
    Public ReadOnly Property LogDateTime As DateTime
    Public ReadOnly Property LogMessage As String

#End Region

#Region "Constructor"

    Public Sub New(logType As LogType, message As String)
        Me.LogType = logType
        Me.LogDateTime = DateTime.Now
        Me.LogMessage = message
    End Sub

#End Region

End Class
