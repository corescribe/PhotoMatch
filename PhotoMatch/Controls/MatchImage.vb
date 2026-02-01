Imports System.IO

Public Class MatchImage

#Region "Fields"

    Private _imageData As ImageData
    Private _imagePath As String
    Private _imageSource As ImageSource
    Private _isSelected As Boolean = False

#End Region

#Region "Constructor"

    Public Sub New(imgReference As ImageReference)

        InitializeComponent()

        ' Set image data.
        _imageData = imgReference.ImageData
        _imagePath = imgReference.FullPath
        _imageSource = imgReference.Source

        ' Set labels.
        lblPath.Text = Directory.GetParent(_imagePath).FullName
        lblFile.Text = imgReference.FileName
        lblWeight.Text = $"{_imageData.FileWeight} Kb"
        lblSize.Text = $"{_imageData.ImageWidth}x{_imageData.ImageHeight}"

        ' Load image in picture box.
        LoadImage(_imagePath)

    End Sub

#End Region

#Region "Control Events"
    Private Sub Match_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegisterMouseEvents(pContent)
    End Sub

#End Region

#Region "Mouse Events"

    ''' <summary>
    ''' Handles click event to toggle selection state.
    ''' </summary>
    Private Sub Match_Click()

        ' Toggle selection state and update background image.
        If _isSelected Then
            pBackgroundImg.BackgroundImage = My.Resources.checkOn
            _isSelected = False
        Else
            pBackgroundImg.BackgroundImage = My.Resources.checkOff
            _isSelected = True
        End If

    End Sub

    ''' <summary>
    ''' Handles mouse enter event to update background image based on selection state.
    ''' </summary>
    Private Sub Match_MouseEnter(sender As Object, e As EventArgs)
        If _isSelected Then
            pBackgroundImg.BackgroundImage = My.Resources.checkOff
        Else
            pBackgroundImg.BackgroundImage = My.Resources.checkOn
        End If
    End Sub

    ''' <summary>
    ''' Handles mouse leave event to reset background image based on selection state.
    ''' </summary>
    Private Sub Match_MouseLeave(sender As Object, e As EventArgs)
        If _isSelected Then
            pBackgroundImg.BackgroundImage = My.Resources.checkHold
        Else
            pBackgroundImg.BackgroundImage = Nothing
        End If
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Loads an image from the specified path into the picture box.
    ''' </summary>
    ''' <param name="imagePath"></param>
    Private Sub LoadImage(imagePath As String)

        ' Load image from file stream to avoid locking the file.
        Using imageStream As New FileStream(imagePath, FileMode.Open, FileAccess.Read)

            ' Create image from stream.
            Using img As Image = Image.FromStream(imageStream)
                ' Set picture box image.
                pbImage.Image = New Bitmap(img)
            End Using

        End Using

    End Sub

    ''' <summary>
    ''' Registers mouse event handlers for the control and its children.
    ''' </summary>
    Private Sub RegisterMouseEvents(control As Control)

        ' Register mouse event handlers.
        AddHandler control.Click, AddressOf Match_Click
        AddHandler control.MouseEnter, AddressOf Match_MouseEnter
        AddHandler control.MouseLeave, AddressOf Match_MouseLeave

        ' Recursively register for child controls.
        For Each child As Control In control.Controls
            RegisterMouseEvents(child)
        Next

    End Sub

#End Region

#Region "Public Methods"

    ' Returns the selection state of the image.
    Public Function GetSelection() As Boolean
        Return _isSelected
    End Function

    ' Returns the image data.
    Public Function GetPath() As String
        Return _imagePath
    End Function

    ' Returns the image source.
    Public Function GetSource() As ImageSource
        Return _imageSource
    End Function

    ' Releases the image resource.
    Public Sub ReleaseImage()
        If pbImage.Image IsNot Nothing Then
            pbImage.Image.Dispose()
            pbImage.Image = Nothing
        End If
    End Sub

#End Region

End Class
