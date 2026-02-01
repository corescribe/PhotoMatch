<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CounterDisplay
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
        lblTitle = New Label()
        lblCounter = New Label()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        pbDetail = New PictureBox()
        FlowLayoutPanel1.SuspendLayout()
        CType(pbDetail, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.ForeColor = SystemColors.ControlDarkDark
        lblTitle.Location = New Point(30, 3)
        lblTitle.Margin = New Padding(0, 3, 0, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(41, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Label1"
        ' 
        ' lblCounter
        ' 
        lblCounter.AutoSize = True
        lblCounter.Location = New Point(75, 3)
        lblCounter.Margin = New Padding(4, 3, 0, 0)
        lblCounter.Name = "lblCounter"
        lblCounter.Size = New Size(13, 15)
        lblCounter.TabIndex = 1
        lblCounter.Text = "0"
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        FlowLayoutPanel1.Controls.Add(pbDetail)
        FlowLayoutPanel1.Controls.Add(lblTitle)
        FlowLayoutPanel1.Controls.Add(lblCounter)
        FlowLayoutPanel1.Dock = DockStyle.Fill
        FlowLayoutPanel1.Location = New Point(0, 0)
        FlowLayoutPanel1.Margin = New Padding(3, 2, 3, 2)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(88, 22)
        FlowLayoutPanel1.TabIndex = 3
        FlowLayoutPanel1.WrapContents = False
        ' 
        ' pbDetail
        ' 
        pbDetail.Image = My.Resources.Resources.listOff
        pbDetail.Location = New Point(0, 0)
        pbDetail.Margin = New Padding(0, 0, 4, 0)
        pbDetail.Name = "pbDetail"
        pbDetail.Size = New Size(26, 22)
        pbDetail.SizeMode = PictureBoxSizeMode.Zoom
        pbDetail.TabIndex = 0
        pbDetail.TabStop = False
        ' 
        ' CounterDisplay
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        BackColor = SystemColors.Control
        Controls.Add(FlowLayoutPanel1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "CounterDisplay"
        Size = New Size(88, 22)
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        CType(pbDetail, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblCounter As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents pbDetail As PictureBox

End Class
