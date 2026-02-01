Imports System.IO

''' <summary>
''' Helper module for image validation tasks.
''' </summary>
Public Module ImageValidationHelper

#Region "Events"

    Public Event BubbleValidation(errorMessage As String, notificationType As NotificationType)

#End Region

#Region "Constants"

    ' Get valid image extensions from application settings.
    Private ReadOnly GetValidExtensions As HashSet(Of String) = New HashSet(Of String)(VALID_IMAGE_EXTENSIONS, StringComparer.OrdinalIgnoreCase)

#End Region

#Region "Get Methods"

    ''' <summary>
    ''' Return array of valid files from provided directory path.
    ''' </summary>
    ''' <param name="directoryPath">The directory path to search for valid files.</param>
    ''' <returns>An array of valid file paths.</returns>
    Public Function GetValidFiles(directoryPath As String) As String()

        ' Check if the directory exists.
        If Not Directory.Exists(directoryPath) Then Return Array.Empty(Of String)()

        ' Return only files with valid extensions from the directory.
        Return Directory.GetFiles(directoryPath).Where(Function(file) GetValidExtensions.Contains(Path.GetExtension(file))).ToArray()

    End Function

    ''' <summary>
    ''' Return array of valid files from provided file paths array.
    ''' </summary>
    ''' <param name="filePaths">The array of file paths to filter.</param>
    ''' <returns>An array of valid file paths.</returns>
    Public Function GetValidFiles(filePaths As String()) As String()

        ' Return only files with valid extensions from the provided file paths array.
        Return filePaths.Where(Function(file) GetValidExtensions.Contains(Path.GetExtension(file))).ToArray()

    End Function

#End Region

#Region "Validation Methods"

    ''' <summary>
    ''' Validate if the file format is valid.
    ''' </summary>
    ''' <param name="filePath">The file path to validate.</param>
    ''' <returns>True if the file format is valid, otherwise false.</returns>
    Public Function IsValid(filePath As String) As Boolean

        ' Get file name and extension.
        Dim fileName As String = Path.GetFileNameWithoutExtension(filePath)
        Dim extension As String = Path.GetExtension(filePath).ToLower()

        ' Call InvalidFormat to check validity.
        Return Not InvalidFormat(fileName, extension)

    End Function

    ''' <summary>
    ''' Validate if the dragged data contains only files.
    ''' </summary>
    ''' <param name="dragged">The DragEventArgs containing the dragged data.</param>
    ''' <returns>True if the dragged data contains only files, otherwise false.</returns>
    Public Function InvalidFiles(dragged As DragEventArgs) As Boolean

        ' Check if the dragged data contains file drop data.
        Dim isValid As Boolean = dragged.Data.GetDataPresent(DataFormats.FileDrop)

        ' Call ValidationError to raise notification if invalid.
        Return ValidationError(isValid, NOTIFICATION_ONLY_FILES_TEXT, NotificationType.Exception)

    End Function

    ''' <summary>
    ''' Validate if the provided paths contain any folders.
    ''' </summary>
    ''' <param name="paths">The array of paths to validate.</param>
    ''' <returns>True if no folders are present, otherwise false.</returns>
    Public Function ContainsFolders(paths As String()) As Boolean

        ' Check if any of the provided paths is a directory.
        Dim isValid As Boolean = Not paths.Any(Function(path) Directory.Exists(path))

        ' Call ValidationError to raise notification if folders are present.
        Return ValidationError(isValid, NOTIFICATION_NO_FOLDERS_TEXT, NotificationType.Exception)

    End Function

    ''' <summary>
    ''' Validate if the provided file list is empty.
    ''' </summary>
    ''' <param name="paths">The array of file paths to validate.</param>
    ''' <returns>True if the file list is empty, otherwise false.</returns>
    Public Function FileListIsEmpty(paths As String()) As Boolean

        ' Count valid files based on extensions.
        Dim validCount As Integer = paths.Count(Function(file) GetValidExtensions.Contains(Path.GetExtension(file)))
        Dim isValid As Boolean = validCount > 0

        ' Call ValidationError to raise notification if no valid files are found.
        Return ValidationError(isValid, NOTIFICATION_ZERO_FILES_TEXT, NotificationType.Exception)

    End Function

    ''' <summary>
    ''' Validate if the selected path is empty.
    ''' </summary>
    ''' <param name="path">The path to validate.</param>
    ''' <returns>True if the path is empty, otherwise false.</returns>
    Public Function SelectedPathIsEmpty(path As String) As Boolean

        ' Check if the path is null, empty, or whitespace.
        Dim isValid As Boolean = Not String.IsNullOrWhiteSpace(path)

        ' Call ValidationError to raise notification if the path is empty.
        Return ValidationError(isValid, NOTIFICATION_PATH_EMPTY_TEXT, NotificationType.Exception)

    End Function

    ''' <summary>
    ''' Validate if the selected path does not exist.
    ''' </summary>
    ''' <param name="path">The path to validate.</param>
    ''' <returns>True if the path does not exist, otherwise false.</returns>
    Public Function SelectedPathNotExist(path As String) As Boolean

        ' Check if the directory exists.
        Dim isValid As Boolean = Directory.Exists(path)

        ' Call ValidationError to raise notification if the path does not exist.
        Return ValidationError(isValid, NOTIFICATION_PATH_NOT_EXIST_TEXT, NotificationType.Exception)

    End Function

    ''' <summary>
    ''' Validate if the dragged path and target path are the same.
    ''' </summary>
    ''' <param name="draggedPath">The dragged file path.</param>
    ''' <param name="targetPath">The target directory path.</param>
    ''' <returns>True if the paths are the same, otherwise false.</returns>
    Public Function SamePath(draggedPath As String, targetPath As String) As Boolean

        ' Check if the directory of the dragged path equals the target path.
        Dim isValid As Boolean = Not Path.GetDirectoryName(draggedPath).Equals(targetPath)

        ' Call ValidationError to raise notification if the paths are the same.
        Return ValidationError(isValid, NOTIFICATION_EQUALS_PATHS_TEXT, NotificationType.Warning)

    End Function

    ''' <summary>
    ''' Validate if the file format is invalid.
    ''' </summary>
    ''' <param name="fileName">The name of the file.</param>
    ''' <param name="fileFormat">The file format/extension.</param>
    ''' <returns>True if the file format is invalid, otherwise false.</returns>
    Public Function InvalidFormat(fileName As String, fileFormat As String) As Boolean

        ' Check if the file format is in the list of valid extensions.
        Dim isValid As Boolean = GetValidExtensions.Contains(fileFormat)

        ' Call ValidationError to raise notification if the format is invalid.
        Return ValidationError(isValid, String.Format(NOTIFICATION_INVALID_FORMAT_TEXT, fileName, fileFormat), NotificationType.Warning)

    End Function

    ''' <summary>
    ''' Raise notification if validation fails.
    ''' </summary>
    ''' <param name="validResult">The result of the validation.</param>
    ''' <param name="errorMessage">The error message to display.</param>
    ''' <param name="notificationType">The type of notification.</param>
    ''' <returns>True if validation failed, otherwise false.</returns>
    Private Function ValidationError(validResult As Boolean, errorMessage As String, notificationType As NotificationType) As Boolean

        ' Raise notification if validation failed.
        If Not validResult Then
            RaiseEvent BubbleValidation(errorMessage, notificationType)
            Return True
        End If

        Return False
    End Function

#End Region

End Module
