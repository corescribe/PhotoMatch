Imports System.ComponentModel

''' <summary>
''' User control that displays a title and a counter, with an optional log detail button.
''' </summary>
Public Class CounterDisplay

#Region "Events"

    ' Event triggered when the detail button is clicked.
    Public Event Clicked(control As CounterDisplay)

#End Region

#Region "Fields"

    Private _title As String = "Title"
    Private _counter As Integer = 0
    Private _logType As LogType
    Private _enableLog As Boolean

#End Region

#Region "Properties"

    ' Counter property.
    <Category("Propiedades"), Description("Establece o devuelve el contador actual.")>
    Public Property Counter As Integer
        Get
            Return _counter
        End Get
        Set(value As Integer)
            _counter = value
            lblCounter.Text = _counter
        End Set
    End Property

    ' Title property.
    <Category("Propiedades"), Description("Establece o devuelve el título actual.")>
    Public Property Title As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
            lblTitle.Text = _title
        End Set
    End Property

    ' LogType property.
    <Category("Propiedades"), Description("Establece o devuelve el tipo de log en el que se guardara.")>
    Public Property LogType As LogType
        Get
            Return _logType
        End Get
        Set(value As LogType)
            _logType = value
        End Set
    End Property

    ' EnableLog property.
    <Category("Propiedades"), Description("Establece o devuelve si log esta activado o desactivado.")>
    Public Property EnableLog As Boolean
        Get
            Return _enableLog
        End Get
        Set(value As Boolean)
            _enableLog = value
        End Set
    End Property

#End Region

#Region "Constructor"

    Public Sub New()
        InitializeComponent()
        lblTitle.Text = _title
        lblCounter.Text = _counter
    End Sub

#End Region

#Region "Control Events"

    ' Handles mouse enter event for the detail picture box.
    Private Sub pbDetail_MouseEnter(sender As Object, e As EventArgs) Handles pbDetail.MouseEnter
        If _enableLog Then
            pbDetail.Cursor = Cursors.Hand
            pbDetail.Image = My.Resources.listOn
        End If
    End Sub

    ' Handles mouse leave event for the detail picture box.
    Private Sub pbDetail_MouseLeave(sender As Object, e As EventArgs) Handles pbDetail.MouseLeave
        pbDetail.Image = My.Resources.listOff
    End Sub

    ' Handles click event for the detail picture box.
    Private Sub pbDetail_Click(sender As Object, e As EventArgs) Handles pbDetail.Click
        If _enableLog Then
            RaiseEvent Clicked(Me)
        End If
    End Sub

#End Region

End Class
