''' <summary>
''' Module containing UI message constants.
''' </summary>
Public Module UIMessages

    ' Drop panel messages.
    Public Const DROP_PANEL_DEFAULT_TEXT As String = "Arrastra aquí los archivos."
    Public Const DROP_PANEL_MOVE_TEXT As String = "Mover {0} archivos a {1}."

    ' Label messages.
    Public Const LABEL_COUNTER_PROCESSED_IMAGES As String = "{0} de {1}"

    ' Notification messages.
    Public Const NOTIFICATION_DEFAULT_TEXT As String = "Arrastra uno o más archivos para iniciar la comparación."
    Public Const NOTIFICATION_ONLY_FILES_TEXT As String = "Arrastra únicamente archivos para que el sistema pueda procesarlos."
    Public Const NOTIFICATION_ZERO_FILES_TEXT As String = "Arrastra como mínimo un archivo con formato válido."
    Public Const NOTIFICATION_NO_FOLDERS_TEXT As String = "No arrastres carpetas."
    Public Const NOTIFICATION_PATH_EMPTY_TEXT As String = "No hay ninguna carpeta seleccionada."
    Public Const NOTIFICATION_PATH_NOT_EXIST_TEXT As String = "La carpeta seleccionada no existe actualmente en el sistema."
    Public Const NOTIFICATION_EQUALS_PATHS_TEXT As String = "La carpeta de origen y destino son la misma carpeta."
    Public Const NOTIFICATION_INVALID_FORMAT_TEXT As String = "El archivo {0}{1} no tiene un formato válido y se ha descartado del procesamiento."
    Public Const NOTIFICATION_IMG_MOVE_SUCCESS_TEXT As String = "Archivo {0} movido con éxito a {1}."
    Public Const NOTIFICATION_IMG_MOVE_ERROR_NOT_EXIST_TEXT As String = "El archivo {0} no se ha podido mover porque no existe."
    Public Const NOTIFICATION_IMG_MOVE_ERROR_PERMISSION_TEXT As String = "No tienes permiso para mover el archivo {0}."
    Public Const NOTIFICATION_IMG_MOVE_ERROR_IO_TEXT As String = "Se produjo un error al intentar mover el archivo {0}."
    Public Const NOTIFICATION_IMG_PROCESSED_TEXT As String = "Archivo {0} procesado con éxito."
    Public Const NOTIFICATION_IMG_DELETE_SUCCESS_TEXT As String = "Archivo {0} eliminado con éxito."
    Public Const NOTIFICATION_IMG_DELETE_ERROR_NOT_EXIST_TEXT As String = "El archivo {0} no se ha podido eliminar porque no existe."
    Public Const NOTIFICATION_IMG_DELETE_ERROR_PERMISSION_TEXT As String = "No tienes permiso para eliminar el archivo {0}."
    Public Const NOTIFICATION_IMG_DELETE_ERROR_IO_TEXT As String = "Se produjo un error al intentar eliminar el archivo {0}."
    Public Const NOTIFICATION_GENERIC_EXCEPTION_TEXT As String = "Excepción genérica: {0}."
    Public Const NOTIFICATION_IMG_MATCHED_TEXT As String = "Se han encontrado coincidencias con {0}."
    Public Const NOTIFICATION_FOLDER_NOT_EXIST_TEXT As String = "El directorio especificado no existe."
    Public Const NOTIFICATION_FOLDER_UNAUTHORIZED_OPEN_TEXT As String = "No tienes permiso para abrir esta carpeta."
    Public Const NOTIFICATION_FOLDER_UNAUTHORIZED_ACCESS_TEXT As String = "No tienes permiso para acceder a esta carpeta."
    Public Const NOTIFICATION_FOLDER_ARE_IN_ROOT_TEXT As String = "Ya te encuentras en la raíz del sistema."
    Public Const NOTIFICATION_IMG_COMPARED_TEXT As String = "Se ha comparado {0} con {1}."
    Public Const LOG_FILES_COMPARED_TEXT As String = "Se ha comparado {0} con {1}"

End Module

