<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Folder
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Folder))
        pbFolder = New PictureBox()
        lblName = New Label()
        CType(pbFolder, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pbFolder
        ' 
        pbFolder.Anchor = AnchorStyles.None
        pbFolder.Image = CType(resources.GetObject("pbFolder.Image"), Image)
        pbFolder.InitialImage = Nothing
        pbFolder.Location = New Point(11, 1)
        pbFolder.Margin = New Padding(0)
        pbFolder.Name = "pbFolder"
        pbFolder.Size = New Size(56, 38)
        pbFolder.SizeMode = PictureBoxSizeMode.Zoom
        pbFolder.TabIndex = 0
        pbFolder.TabStop = False
        ' 
        ' lblName
        ' 
        lblName.Font = New Font("Segoe UI", 7F)
        lblName.Location = New Point(1, 45)
        lblName.Margin = New Padding(0)
        lblName.Name = "lblName"
        lblName.Size = New Size(74, 30)
        lblName.TabIndex = 1
        lblName.Text = "Folder"
        lblName.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Folder
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.Transparent
        Controls.Add(lblName)
        Controls.Add(pbFolder)
        Cursor = Cursors.Hand
        Margin = New Padding(0, 0, 18, 8)
        Name = "Folder"
        Size = New Size(75, 75)
        CType(pbFolder, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents pbFolder As PictureBox
    Friend WithEvents lblName As Label

End Class
