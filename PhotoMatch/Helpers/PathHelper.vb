Imports System.IO

''' <summary>
''' Helper module for path operations.
''' </summary>
Public Module PathHelper

    ''' <summary>
    ''' Gets the root drive path (e.g., C:\).
    ''' </summary>
    ''' <returns></returns>
    Public Function GetRootDrivePath() As String
        Return Path.GetPathRoot(Environment.SystemDirectory)
    End Function

    ''' <summary>
    ''' Gets the user profile path (e.g., C:\Users\Username).
    ''' </summary>
    ''' <returns>Returns the user profile path.</returns>
    Public Function GetUserProfilePath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
    End Function

    ''' <summary>
    ''' Gets the desktop path (e.g., C:\Users\Username\Desktop).
    ''' </summary>
    ''' <returns>Returns the desktop path.</returns>
    Public Function GetDesktopPath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Function

    ''' <summary>
    ''' Gets the pictures path (e.g., C:\Users\Username\Pictures).
    ''' </summary>
    ''' <returns>Returns the pictures path.</returns>
    Public Function GetPicturesPath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
    End Function

    ''' <summary>
    ''' Gets the user application data path (e.g., C:\Users\Username\AppData\Local).
    ''' </summary>
    ''' <returns>Returns the local application data path.</returns>
    Public Function GetUserAppDataPath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    End Function

End Module