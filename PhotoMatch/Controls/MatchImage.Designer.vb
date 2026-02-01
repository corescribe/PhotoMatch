<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MatchImage
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
        pbImage = New PictureBox()
        pContent = New Panel()
        pImgBorder = New Panel()
        pData = New Panel()
        pBackgroundImg = New Panel()
        lblWeightTitle = New Label()
        lblWeight = New Label()
        lblSizeTitle = New Label()
        lblSize = New Label()
        lblFileTitle = New Label()
        lblFile = New Label()
        lblPathTitle = New Label()
        lblPath = New Label()
        pSeparator = New Panel()
        CType(pbImage, ComponentModel.ISupportInitialize).BeginInit()
        pContent.SuspendLayout()
        pImgBorder.SuspendLayout()
        pData.SuspendLayout()
        SuspendLayout()
        ' 
        ' pbImage
        ' 
        pbImage.BackColor = Color.WhiteSmoke
        pbImage.Dock = DockStyle.Fill
        pbImage.Enabled = False
        pbImage.Location = New Point(1, 1)
        pbImage.Margin = New Padding(0)
        pbImage.Name = "pbImage"
        pbImage.Size = New Size(107, 107)
        pbImage.SizeMode = PictureBoxSizeMode.Zoom
        pbImage.TabIndex = 0
        pbImage.TabStop = False
        ' 
        ' pContent
        ' 
        pContent.Controls.Add(pImgBorder)
        pContent.Controls.Add(pData)
        pContent.Cursor = Cursors.Hand
        pContent.Dock = DockStyle.Fill
        pContent.Location = New Point(0, 0)
        pContent.Name = "pContent"
        pContent.Size = New Size(594, 130)
        pContent.TabIndex = 2
        ' 
        ' pImgBorder
        ' 
        pImgBorder.BackColor = Color.Gainsboro
        pImgBorder.Controls.Add(pbImage)
        pImgBorder.Enabled = False
        pImgBorder.Location = New Point(8, 9)
        pImgBorder.Margin = New Padding(0)
        pImgBorder.Name = "pImgBorder"
        pImgBorder.Padding = New Padding(1)
        pImgBorder.Size = New Size(109, 109)
        pImgBorder.TabIndex = 4
        ' 
        ' pData
        ' 
        pData.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pData.BackColor = Color.Transparent
        pData.BackgroundImageLayout = ImageLayout.Center
        pData.Controls.Add(pBackgroundImg)
        pData.Controls.Add(lblWeightTitle)
        pData.Controls.Add(lblWeight)
        pData.Controls.Add(lblSizeTitle)
        pData.Controls.Add(lblSize)
        pData.Controls.Add(lblFileTitle)
        pData.Controls.Add(lblFile)
        pData.Controls.Add(lblPathTitle)
        pData.Controls.Add(lblPath)
        pData.Enabled = False
        pData.Location = New Point(123, 7)
        pData.Name = "pData"
        pData.Size = New Size(465, 116)
        pData.TabIndex = 3
        ' 
        ' pBackgroundImg
        ' 
        pBackgroundImg.BackColor = Color.Transparent
        pBackgroundImg.BackgroundImageLayout = ImageLayout.Center
        pBackgroundImg.Dock = DockStyle.Right
        pBackgroundImg.Enabled = False
        pBackgroundImg.Location = New Point(377, 0)
        pBackgroundImg.Name = "pBackgroundImg"
        pBackgroundImg.Size = New Size(88, 116)
        pBackgroundImg.TabIndex = 9
        ' 
        ' lblWeightTitle
        ' 
        lblWeightTitle.AutoSize = True
        lblWeightTitle.Enabled = False
        lblWeightTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblWeightTitle.ForeColor = SystemColors.ControlDarkDark
        lblWeightTitle.Location = New Point(3, 95)
        lblWeightTitle.Name = "lblWeightTitle"
        lblWeightTitle.Size = New Size(53, 15)
        lblWeightTitle.TabIndex = 7
        lblWeightTitle.Text = "Tamaño:"
        ' 
        ' lblWeight
        ' 
        lblWeight.AutoSize = True
        lblWeight.Enabled = False
        lblWeight.ForeColor = Color.DarkGray
        lblWeight.Location = New Point(54, 95)
        lblWeight.Name = "lblWeight"
        lblWeight.Size = New Size(58, 15)
        lblWeight.TabIndex = 8
        lblWeight.Text = "lblWeight"
        ' 
        ' lblSizeTitle
        ' 
        lblSizeTitle.AutoSize = True
        lblSizeTitle.Enabled = False
        lblSizeTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblSizeTitle.ForeColor = SystemColors.ControlDarkDark
        lblSizeTitle.Location = New Point(3, 64)
        lblSizeTitle.Name = "lblSizeTitle"
        lblSizeTitle.Size = New Size(81, 15)
        lblSizeTitle.TabIndex = 5
        lblSizeTitle.Text = "Dimensiones:"
        ' 
        ' lblSize
        ' 
        lblSize.AutoSize = True
        lblSize.Enabled = False
        lblSize.ForeColor = Color.DarkGray
        lblSize.Location = New Point(82, 64)
        lblSize.Name = "lblSize"
        lblSize.Size = New Size(40, 15)
        lblSize.TabIndex = 6
        lblSize.Text = "lblSize"
        ' 
        ' lblFileTitle
        ' 
        lblFileTitle.AutoSize = True
        lblFileTitle.Enabled = False
        lblFileTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblFileTitle.ForeColor = SystemColors.ControlDarkDark
        lblFileTitle.Location = New Point(3, 3)
        lblFileTitle.Name = "lblFileTitle"
        lblFileTitle.Size = New Size(53, 15)
        lblFileTitle.TabIndex = 3
        lblFileTitle.Text = "Archivo:"
        ' 
        ' lblFile
        ' 
        lblFile.AutoSize = True
        lblFile.Enabled = False
        lblFile.ForeColor = Color.DarkGray
        lblFile.Location = New Point(54, 3)
        lblFile.Name = "lblFile"
        lblFile.Size = New Size(38, 15)
        lblFile.TabIndex = 4
        lblFile.Text = "lblFile"
        ' 
        ' lblPathTitle
        ' 
        lblPathTitle.AutoSize = True
        lblPathTitle.Enabled = False
        lblPathTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblPathTitle.ForeColor = SystemColors.ControlDarkDark
        lblPathTitle.Location = New Point(3, 33)
        lblPathTitle.Name = "lblPathTitle"
        lblPathTitle.Size = New Size(64, 15)
        lblPathTitle.TabIndex = 1
        lblPathTitle.Text = "Ubicación:"
        ' 
        ' lblPath
        ' 
        lblPath.AutoSize = True
        lblPath.Enabled = False
        lblPath.ForeColor = Color.DarkGray
        lblPath.Location = New Point(65, 33)
        lblPath.Name = "lblPath"
        lblPath.Size = New Size(44, 15)
        lblPath.TabIndex = 2
        lblPath.Text = "lblPath"
        ' 
        ' pSeparator
        ' 
        pSeparator.BackColor = Color.WhiteSmoke
        pSeparator.Dock = DockStyle.Bottom
        pSeparator.Location = New Point(0, 130)
        pSeparator.Name = "pSeparator"
        pSeparator.Size = New Size(594, 1)
        pSeparator.TabIndex = 3
        ' 
        ' Match
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(pContent)
        Controls.Add(pSeparator)
        Name = "Match"
        Size = New Size(594, 131)
        CType(pbImage, ComponentModel.ISupportInitialize).EndInit()
        pContent.ResumeLayout(False)
        pImgBorder.ResumeLayout(False)
        pData.ResumeLayout(False)
        pData.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pbImage As PictureBox
    Friend WithEvents pContent As Panel
    Friend WithEvents lblPathTitle As Label
    Friend WithEvents lblPath As Label
    Friend WithEvents pData As Panel
    Friend WithEvents lblSizeTitle As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblFileTitle As Label
    Friend WithEvents lblFile As Label
    Friend WithEvents lblWeightTitle As Label
    Friend WithEvents lblWeight As Label
    Friend WithEvents pSeparator As Panel
    Friend WithEvents pImgBorder As Panel
    Friend WithEvents pBackgroundImg As Panel

End Class
