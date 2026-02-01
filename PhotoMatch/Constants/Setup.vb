''' <summary>
''' Module containing setup constants.
''' </summary>
Public Module Setup

    ' Default similarity percentage for image comparison SSIM.
    Public MIN_PERCENTAGE_SIMILARITY As Double = 70.0

    ' Valid image file extensions.
    Public ReadOnly Property VALID_IMAGE_EXTENSIONS As String() = {".jpg", ".jpeg", ".png", ".bmp"}

    ' Processing speed in milliseconds (0 for maximum speed).
    Public ReadOnly PROCESSING_SPEED_MS As Integer = 0

    ' Delay in milliseconds for showing child forms and avoiding UI freezing.
    Public ReadOnly DELAY_FORM_CHILD_SHOW_MS As Integer = 200

    ' Border size.
    Public ReadOnly BORDER_THICKNESS As Integer = 2

    ' Application folder name.
    Public ReadOnly APP_FOLDER_NAME As String = "PhotoMatch"

    ' Log datetime format.
    Public ReadOnly LOG_FOLDER_NAME As String = "Log"

    ' Log file prefix.
    Public ReadOnly LOG_FILE_PREFIX As String = "Log_"

    ' Log datetime format.
    Public ReadOnly LOG_DATETIME_FORMAT As String = "yyyyMMdd_HHmmss"

End Module
