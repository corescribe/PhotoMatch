<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Notification
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblMessage = New Label()
        SuspendLayout()
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Dock = DockStyle.Fill
        lblMessage.Font = New Font("Segoe UI", 9F, FontStyle.Italic)
        lblMessage.Location = New Point(18, 10)
        lblMessage.Margin = New Padding(0)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(117, 15)
        lblMessage.TabIndex = 0
        lblMessage.Text = "Notification Message"
        lblMessage.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Notification
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.Gainsboro
        Controls.Add(lblMessage)
        Margin = New Padding(0)
        Name = "Notification"
        Padding = New Padding(18, 10, 18, 8)
        Size = New Size(153, 33)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblMessage As Label

End Class
