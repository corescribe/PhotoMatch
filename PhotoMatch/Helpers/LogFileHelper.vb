Imports System.IO

''' <summary>
''' Helper module for log file operations.
''' </summary>
Public Module LogFileHelper

    ' Directory to store log files.
    Private ReadOnly _logDir As String = Path.Combine(GetUserAppDataPath(), APP_FOLDER_NAME, LOG_FOLDER_NAME)

    ' Unique session identifier for log files.
    Public ReadOnly _sessionId As String = DateTime.Now.ToString(LOG_DATETIME_FORMAT) & "_" & Guid.NewGuid().ToString("N") ' Without hyphens

    ''' <summary>
    ''' Appends a log line to a text file named by log type and session.
    ''' </summary>
    ''' <param name="logType">The type of log.</param>
    ''' <param name="logLine">The line to append.</param>
    Public Sub AppendLogLine(logType As LogType, logLine As String)

        ' Check if log directory exists, create if not.
        If Not Directory.Exists(_logDir) Then
            Directory.CreateDirectory(_logDir)
        End If

        ' Get the log file path.
        Dim filePath As String = BuildLogPath(logType)

        ' Append log line to file.
        File.AppendAllText(filePath, logLine & Environment.NewLine)

    End Sub

    ''' <summary>
    ''' Opens the log file in Notepad.
    ''' </summary>
    ''' <param name="logType">The type of log.</param>
    Public Sub OpenLogInNotepad(logType As LogType)

        ' Get the log file path.
        Dim filePath As String = BuildLogPath(logType)

        ' Check if log directory exists, create if not.
        If Not File.Exists(filePath) Then
            File.WriteAllText(filePath, "")
        End If

        ' Start Notepad with the log file maximized.
        Dim processStart As New ProcessStartInfo("notepad.exe", $"""{filePath}""")
        processStart.WindowStyle = ProcessWindowStyle.Maximized
        Process.Start(processStart)

    End Sub

    ''' <summary>
    ''' Gets the log file path for the specified log type and current session.
    ''' </summary>
    ''' <param name="logType">The type of log.</param>
    ''' <returns>The full path to the log file.</returns>
    Public Function GetLogFilePath(logType As LogType) As String
        Return BuildLogPath(logType)
    End Function

    Private Function BuildLogPath(logType As LogType) As String

        ' Build log file path.
        Dim fileName As String = $"{LOG_FILE_PREFIX}{logType}_{_sessionId}.txt"
        Return Path.Combine(_logDir, fileName)

    End Function
End Module