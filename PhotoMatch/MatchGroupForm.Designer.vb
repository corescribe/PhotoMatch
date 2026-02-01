<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MatchGroupForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MatchGroupForm))
        flpGroup = New FlowLayoutPanel()
        pHead = New Panel()
        lblCounter = New Label()
        lblHeadTitle = New Label()
        pBody = New Panel()
        pHeadSeparator = New Panel()
        pFooter = New Panel()
        btnApply = New Label()
        pFooterSeparator = New Panel()
        pSubHead = New Panel()
        lblSubHeadTitle = New Label()
        pSubHeadSeparator = New Panel()
        pWindowSeparator = New Panel()
        pHead.SuspendLayout()
        pBody.SuspendLayout()
        pFooter.SuspendLayout()
        pSubHead.SuspendLayout()
        SuspendLayout()
        ' 
        ' flpGroup
        ' 
        flpGroup.AutoScroll = True
        flpGroup.Dock = DockStyle.Fill
        flpGroup.FlowDirection = FlowDirection.TopDown
        flpGroup.Location = New Point(0, 0)
        flpGroup.Name = "flpGroup"
        flpGroup.Size = New Size(584, 518)
        flpGroup.TabIndex = 0
        flpGroup.WrapContents = False
        ' 
        ' pHead
        ' 
        pHead.BackColor = Color.WhiteSmoke
        pHead.Controls.Add(lblCounter)
        pHead.Controls.Add(lblHeadTitle)
        pHead.Dock = DockStyle.Top
        pHead.Location = New Point(0, 1)
        pHead.Name = "pHead"
        pHead.Size = New Size(584, 46)
        pHead.TabIndex = 1
        ' 
        ' lblCounter
        ' 
        lblCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblCounter.Font = New Font("Arial", 18F)
        lblCounter.ForeColor = Color.Silver
        lblCounter.Location = New Point(384, 9)
        lblCounter.Name = "lblCounter"
        lblCounter.Size = New Size(192, 28)
        lblCounter.TabIndex = 1
        lblCounter.Text = "10"
        lblCounter.TextAlign = ContentAlignment.MiddleRight
        lblCounter.Visible = False
        ' 
        ' lblHeadTitle
        ' 
        lblHeadTitle.AutoSize = True
        lblHeadTitle.Font = New Font("Segoe UI", 15F)
        lblHeadTitle.ForeColor = Color.DarkGray
        lblHeadTitle.Location = New Point(7, 6)
        lblHeadTitle.Name = "lblHeadTitle"
        lblHeadTitle.Size = New Size(359, 28)
        lblHeadTitle.TabIndex = 0
        lblHeadTitle.Text = "Imagenes iguales o similares agrupadas:"
        lblHeadTitle.Visible = False
        ' 
        ' pBody
        ' 
        pBody.Controls.Add(flpGroup)
        pBody.Dock = DockStyle.Fill
        pBody.Location = New Point(0, 76)
        pBody.Name = "pBody"
        pBody.Size = New Size(584, 518)
        pBody.TabIndex = 2
        ' 
        ' pHeadSeparator
        ' 
        pHeadSeparator.BackColor = Color.LightGray
        pHeadSeparator.Dock = DockStyle.Top
        pHeadSeparator.Location = New Point(0, 47)
        pHeadSeparator.Name = "pHeadSeparator"
        pHeadSeparator.Size = New Size(584, 1)
        pHeadSeparator.TabIndex = 3
        ' 
        ' pFooter
        ' 
        pFooter.BackColor = Color.WhiteSmoke
        pFooter.Controls.Add(btnApply)
        pFooter.Dock = DockStyle.Bottom
        pFooter.Location = New Point(0, 595)
        pFooter.Name = "pFooter"
        pFooter.Size = New Size(584, 46)
        pFooter.TabIndex = 2
        ' 
        ' btnApply
        ' 
        btnApply.Cursor = Cursors.Hand
        btnApply.Dock = DockStyle.Fill
        btnApply.Font = New Font("Segoe UI", 13F)
        btnApply.ForeColor = Color.DarkGray
        btnApply.Location = New Point(0, 0)
        btnApply.Name = "btnApply"
        btnApply.Padding = New Padding(0, 0, 0, 3)
        btnApply.Size = New Size(584, 46)
        btnApply.TabIndex = 1
        btnApply.Text = "Aplicar Selección"
        btnApply.TextAlign = ContentAlignment.MiddleCenter
        btnApply.Visible = False
        ' 
        ' pFooterSeparator
        ' 
        pFooterSeparator.BackColor = Color.LightGray
        pFooterSeparator.Dock = DockStyle.Bottom
        pFooterSeparator.Location = New Point(0, 594)
        pFooterSeparator.Name = "pFooterSeparator"
        pFooterSeparator.Size = New Size(584, 1)
        pFooterSeparator.TabIndex = 4
        ' 
        ' pSubHead
        ' 
        pSubHead.BackColor = Color.GhostWhite
        pSubHead.Controls.Add(lblSubHeadTitle)
        pSubHead.Dock = DockStyle.Top
        pSubHead.Location = New Point(0, 48)
        pSubHead.Name = "pSubHead"
        pSubHead.Size = New Size(584, 27)
        pSubHead.TabIndex = 5
        ' 
        ' lblSubHeadTitle
        ' 
        lblSubHeadTitle.AutoSize = True
        lblSubHeadTitle.Font = New Font("Segoe UI", 9F, FontStyle.Italic)
        lblSubHeadTitle.ForeColor = Color.CornflowerBlue
        lblSubHeadTitle.Location = New Point(8, 6)
        lblSubHeadTitle.Name = "lblSubHeadTitle"
        lblSubHeadTitle.Size = New Size(537, 15)
        lblSubHeadTitle.TabIndex = 0
        lblSubHeadTitle.Text = "Selecciona las imágenes que quieres conservar o mover a la carpeta de destino, el resto se eliminarán."
        lblSubHeadTitle.Visible = False
        ' 
        ' pSubHeadSeparator
        ' 
        pSubHeadSeparator.BackColor = Color.LightGray
        pSubHeadSeparator.Dock = DockStyle.Top
        pSubHeadSeparator.Location = New Point(0, 75)
        pSubHeadSeparator.Name = "pSubHeadSeparator"
        pSubHeadSeparator.Size = New Size(584, 1)
        pSubHeadSeparator.TabIndex = 6
        ' 
        ' pWindowSeparator
        ' 
        pWindowSeparator.BackColor = Color.LightGray
        pWindowSeparator.Dock = DockStyle.Top
        pWindowSeparator.Location = New Point(0, 0)
        pWindowSeparator.Name = "pWindowSeparator"
        pWindowSeparator.Size = New Size(584, 1)
        pWindowSeparator.TabIndex = 7
        ' 
        ' MatchGroupForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(584, 641)
        Controls.Add(pBody)
        Controls.Add(pSubHeadSeparator)
        Controls.Add(pSubHead)
        Controls.Add(pHeadSeparator)
        Controls.Add(pHead)
        Controls.Add(pWindowSeparator)
        Controls.Add(pFooterSeparator)
        Controls.Add(pFooter)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(600, 680)
        Name = "MatchGroupForm"
        Text = "Photo Match - Coincidencias encontradas"
        pHead.ResumeLayout(False)
        pHead.PerformLayout()
        pBody.ResumeLayout(False)
        pFooter.ResumeLayout(False)
        pSubHead.ResumeLayout(False)
        pSubHead.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents flpGroup As FlowLayoutPanel
    Friend WithEvents pHead As Panel
    Friend WithEvents lblHeadTitle As Label
    Friend WithEvents pBody As Panel
    Friend WithEvents pHeadSeparator As Panel
    Friend WithEvents pFooter As Panel
    Friend WithEvents pFooterSeparator As Panel
    Friend WithEvents lblCounter As Label
    Friend WithEvents pSubHead As Panel
    Friend WithEvents lblSubHeadTitle As Label
    Friend WithEvents pSubHeadSeparator As Panel
    Friend WithEvents pWindowSeparator As Panel
    Friend WithEvents btnApply As Label
End Class
