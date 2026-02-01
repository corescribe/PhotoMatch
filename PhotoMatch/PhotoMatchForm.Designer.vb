<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PhotoMatchForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PhotoMatchForm))
        tlpContainer = New TableLayoutPanel()
        counterImagesCompared = New CounterDisplay()
        VerSeparator6 = New Panel()
        VerSeparator5 = New Panel()
        VerSeparator3 = New Panel()
        HorSeparator4 = New Panel()
        HorSeparator1 = New Panel()
        HorSeparator2 = New Panel()
        VerSeparator1 = New Panel()
        VerSeparator2 = New Panel()
        VerSeparator4 = New Panel()
        pnlFolderPath = New Panel()
        lblFolderPath = New Label()
        btnBackFolder = New PictureBox()
        lblFolderTitle = New Label()
        pFolderButtons = New Panel()
        btnUpdateFolder = New PictureBox()
        pnlNotification = New Panel()
        pProgressBar1 = New Panel()
        proBarProcessed = New ProgressBar()
        pProgressBar2 = New Panel()
        proBarGrouped = New ProgressBar()
        HorSeparator3 = New Panel()
        pProgressBar1Title = New Panel()
        lblProBarProcessedCounter = New Label()
        lblProBarProcessed = New Label()
        flpFolders = New DropPanel()
        counterImagesProcessed = New CounterDisplay()
        pProgressBar2Title = New Panel()
        lblProBarGroupedCounter = New Label()
        lblProBarGrouped = New Label()
        counterImagesMoved = New CounterDisplay()
        counterImagesMatched = New CounterDisplay()
        counterImagesDeleted = New CounterDisplay()
        counterMoveErrors = New CounterDisplay()
        counterDeleteErrors = New CounterDisplay()
        tlpContainer.SuspendLayout()
        pnlFolderPath.SuspendLayout()
        CType(btnBackFolder, ComponentModel.ISupportInitialize).BeginInit()
        pFolderButtons.SuspendLayout()
        CType(btnUpdateFolder, ComponentModel.ISupportInitialize).BeginInit()
        pProgressBar1.SuspendLayout()
        pProgressBar2.SuspendLayout()
        pProgressBar1Title.SuspendLayout()
        pProgressBar2Title.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpContainer
        ' 
        tlpContainer.AutoSize = True
        tlpContainer.BackColor = Color.White
        tlpContainer.ColumnCount = 13
        tlpContainer.ColumnStyles.Add(New ColumnStyle())
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle())
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle())
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle())
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle())
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle())
        tlpContainer.Controls.Add(counterImagesCompared, 2, 1)
        tlpContainer.Controls.Add(VerSeparator6, 11, 1)
        tlpContainer.Controls.Add(VerSeparator5, 9, 1)
        tlpContainer.Controls.Add(VerSeparator3, 5, 1)
        tlpContainer.Controls.Add(HorSeparator4, 0, 13)
        tlpContainer.Controls.Add(HorSeparator1, 0, 0)
        tlpContainer.Controls.Add(HorSeparator2, 0, 2)
        tlpContainer.Controls.Add(VerSeparator1, 1, 1)
        tlpContainer.Controls.Add(VerSeparator2, 3, 1)
        tlpContainer.Controls.Add(VerSeparator4, 7, 1)
        tlpContainer.Controls.Add(pnlFolderPath, 0, 3)
        tlpContainer.Controls.Add(pnlNotification, 0, 14)
        tlpContainer.Controls.Add(pProgressBar1, 0, 8)
        tlpContainer.Controls.Add(pProgressBar2, 0, 11)
        tlpContainer.Controls.Add(HorSeparator3, 0, 5)
        tlpContainer.Controls.Add(pProgressBar1Title, 0, 7)
        tlpContainer.Controls.Add(flpFolders, 0, 4)
        tlpContainer.Controls.Add(counterImagesProcessed, 0, 1)
        tlpContainer.Controls.Add(pProgressBar2Title, 0, 10)
        tlpContainer.Controls.Add(counterImagesMoved, 6, 1)
        tlpContainer.Controls.Add(counterImagesMatched, 4, 1)
        tlpContainer.Controls.Add(counterImagesDeleted, 8, 1)
        tlpContainer.Controls.Add(counterMoveErrors, 10, 1)
        tlpContainer.Controls.Add(counterDeleteErrors, 12, 1)
        tlpContainer.Dock = DockStyle.Fill
        tlpContainer.Location = New Point(0, 0)
        tlpContainer.Margin = New Padding(0)
        tlpContainer.Name = "tlpContainer"
        tlpContainer.RowCount = 15
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 15F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 15F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 15F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 15F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 15F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Absolute, 38F))
        tlpContainer.Size = New Size(1258, 921)
        tlpContainer.TabIndex = 1
        ' 
        ' counterImagesCompared
        ' 
        counterImagesCompared.AutoSize = True
        counterImagesCompared.AutoSizeMode = AutoSizeMode.GrowAndShrink
        counterImagesCompared.BackColor = Color.White
        counterImagesCompared.Counter = 0
        counterImagesCompared.EnableLog = False
        counterImagesCompared.Location = New Point(182, 1)
        counterImagesCompared.LogType = LogType.ImageCompared
        counterImagesCompared.Margin = New Padding(0)
        counterImagesCompared.Name = "counterImagesCompared"
        counterImagesCompared.Padding = New Padding(4, 4, 10, 0)
        counterImagesCompared.Size = New Size(187, 26)
        counterImagesCompared.TabIndex = 31
        counterImagesCompared.Title = "Imagenes comparadas"
        ' 
        ' VerSeparator6
        ' 
        VerSeparator6.BackColor = Color.LightGray
        VerSeparator6.ForeColor = SystemColors.Control
        VerSeparator6.Location = New Point(1090, 5)
        VerSeparator6.Margin = New Padding(0, 4, 0, 4)
        VerSeparator6.Name = "VerSeparator6"
        VerSeparator6.Size = New Size(1, 22)
        VerSeparator6.TabIndex = 9
        ' 
        ' VerSeparator5
        ' 
        VerSeparator5.BackColor = Color.LightGray
        VerSeparator5.ForeColor = SystemColors.Control
        VerSeparator5.Location = New Point(928, 5)
        VerSeparator5.Margin = New Padding(0, 4, 0, 4)
        VerSeparator5.Name = "VerSeparator5"
        VerSeparator5.Size = New Size(1, 22)
        VerSeparator5.TabIndex = 9
        ' 
        ' VerSeparator3
        ' 
        VerSeparator3.BackColor = Color.LightGray
        VerSeparator3.ForeColor = SystemColors.Control
        VerSeparator3.Location = New Point(580, 5)
        VerSeparator3.Margin = New Padding(0, 4, 0, 4)
        VerSeparator3.Name = "VerSeparator3"
        VerSeparator3.Size = New Size(1, 22)
        VerSeparator3.TabIndex = 7
        ' 
        ' HorSeparator4
        ' 
        HorSeparator4.BackColor = Color.LightGray
        tlpContainer.SetColumnSpan(HorSeparator4, 13)
        HorSeparator4.Dock = DockStyle.Fill
        HorSeparator4.ForeColor = SystemColors.Control
        HorSeparator4.Location = New Point(0, 882)
        HorSeparator4.Margin = New Padding(0)
        HorSeparator4.Name = "HorSeparator4"
        HorSeparator4.Size = New Size(1258, 1)
        HorSeparator4.TabIndex = 3
        ' 
        ' HorSeparator1
        ' 
        HorSeparator1.BackColor = Color.LightGray
        tlpContainer.SetColumnSpan(HorSeparator1, 13)
        HorSeparator1.Dock = DockStyle.Fill
        HorSeparator1.ForeColor = SystemColors.Control
        HorSeparator1.Location = New Point(0, 0)
        HorSeparator1.Margin = New Padding(0)
        HorSeparator1.Name = "HorSeparator1"
        HorSeparator1.Size = New Size(1258, 1)
        HorSeparator1.TabIndex = 1
        ' 
        ' HorSeparator2
        ' 
        HorSeparator2.BackColor = Color.LightGray
        tlpContainer.SetColumnSpan(HorSeparator2, 13)
        HorSeparator2.Dock = DockStyle.Fill
        HorSeparator2.ForeColor = SystemColors.Control
        HorSeparator2.Location = New Point(0, 31)
        HorSeparator2.Margin = New Padding(0)
        HorSeparator2.Name = "HorSeparator2"
        HorSeparator2.Size = New Size(1258, 1)
        HorSeparator2.TabIndex = 2
        ' 
        ' VerSeparator1
        ' 
        VerSeparator1.BackColor = Color.LightGray
        VerSeparator1.ForeColor = SystemColors.Control
        VerSeparator1.Location = New Point(181, 5)
        VerSeparator1.Margin = New Padding(0, 4, 0, 4)
        VerSeparator1.Name = "VerSeparator1"
        VerSeparator1.Size = New Size(1, 22)
        VerSeparator1.TabIndex = 5
        ' 
        ' VerSeparator2
        ' 
        VerSeparator2.BackColor = Color.LightGray
        VerSeparator2.ForeColor = SystemColors.Control
        VerSeparator2.Location = New Point(369, 5)
        VerSeparator2.Margin = New Padding(0, 4, 0, 4)
        VerSeparator2.Name = "VerSeparator2"
        VerSeparator2.Size = New Size(1, 22)
        VerSeparator2.TabIndex = 6
        ' 
        ' VerSeparator4
        ' 
        VerSeparator4.BackColor = Color.LightGray
        VerSeparator4.ForeColor = SystemColors.Control
        VerSeparator4.Location = New Point(748, 5)
        VerSeparator4.Margin = New Padding(0, 4, 0, 4)
        VerSeparator4.Name = "VerSeparator4"
        VerSeparator4.Size = New Size(1, 22)
        VerSeparator4.TabIndex = 8
        ' 
        ' pnlFolderPath
        ' 
        tlpContainer.SetColumnSpan(pnlFolderPath, 13)
        pnlFolderPath.Controls.Add(lblFolderPath)
        pnlFolderPath.Controls.Add(btnBackFolder)
        pnlFolderPath.Controls.Add(lblFolderTitle)
        pnlFolderPath.Controls.Add(pFolderButtons)
        pnlFolderPath.Dock = DockStyle.Fill
        pnlFolderPath.Location = New Point(0, 39)
        pnlFolderPath.Margin = New Padding(0, 7, 0, 0)
        pnlFolderPath.Name = "pnlFolderPath"
        pnlFolderPath.Padding = New Padding(48, 8, 18, 0)
        pnlFolderPath.Size = New Size(1258, 28)
        pnlFolderPath.TabIndex = 14
        ' 
        ' lblFolderPath
        ' 
        lblFolderPath.AutoSize = True
        lblFolderPath.Dock = DockStyle.Left
        lblFolderPath.Location = New Point(157, 8)
        lblFolderPath.Margin = New Padding(0)
        lblFolderPath.Name = "lblFolderPath"
        lblFolderPath.Size = New Size(16, 15)
        lblFolderPath.TabIndex = 2
        lblFolderPath.Text = "···"
        ' 
        ' btnBackFolder
        ' 
        btnBackFolder.Cursor = Cursors.Hand
        btnBackFolder.Image = My.Resources.Resources.backOff
        btnBackFolder.Location = New Point(19, 5)
        btnBackFolder.Margin = New Padding(0)
        btnBackFolder.Name = "btnBackFolder"
        btnBackFolder.Size = New Size(20, 20)
        btnBackFolder.SizeMode = PictureBoxSizeMode.Zoom
        btnBackFolder.TabIndex = 0
        btnBackFolder.TabStop = False
        ' 
        ' lblFolderTitle
        ' 
        lblFolderTitle.AutoSize = True
        lblFolderTitle.Dock = DockStyle.Left
        lblFolderTitle.ForeColor = SystemColors.ControlDarkDark
        lblFolderTitle.Location = New Point(48, 8)
        lblFolderTitle.Margin = New Padding(0)
        lblFolderTitle.Name = "lblFolderTitle"
        lblFolderTitle.Size = New Size(109, 15)
        lblFolderTitle.TabIndex = 1
        lblFolderTitle.Text = "Carpeta de destino:"
        ' 
        ' pFolderButtons
        ' 
        pFolderButtons.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pFolderButtons.Controls.Add(btnUpdateFolder)
        pFolderButtons.Location = New Point(1210, 2)
        pFolderButtons.Margin = New Padding(0)
        pFolderButtons.Name = "pFolderButtons"
        pFolderButtons.Padding = New Padding(0, 4, 0, 4)
        pFolderButtons.Size = New Size(30, 25)
        pFolderButtons.TabIndex = 30
        ' 
        ' btnUpdateFolder
        ' 
        btnUpdateFolder.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUpdateFolder.Cursor = Cursors.Hand
        btnUpdateFolder.Image = My.Resources.Resources.updateOff
        btnUpdateFolder.Location = New Point(5, 2)
        btnUpdateFolder.Margin = New Padding(0)
        btnUpdateFolder.Name = "btnUpdateFolder"
        btnUpdateFolder.Size = New Size(22, 22)
        btnUpdateFolder.SizeMode = PictureBoxSizeMode.Zoom
        btnUpdateFolder.TabIndex = 1
        btnUpdateFolder.TabStop = False
        ' 
        ' pnlNotification
        ' 
        pnlNotification.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        tlpContainer.SetColumnSpan(pnlNotification, 13)
        pnlNotification.Dock = DockStyle.Fill
        pnlNotification.Location = New Point(0, 883)
        pnlNotification.Margin = New Padding(0)
        pnlNotification.Name = "pnlNotification"
        pnlNotification.Size = New Size(1258, 38)
        pnlNotification.TabIndex = 15
        ' 
        ' pProgressBar1
        ' 
        tlpContainer.SetColumnSpan(pProgressBar1, 13)
        pProgressBar1.Controls.Add(proBarProcessed)
        pProgressBar1.Dock = DockStyle.Fill
        pProgressBar1.Location = New Point(0, 793)
        pProgressBar1.Margin = New Padding(0)
        pProgressBar1.Name = "pProgressBar1"
        pProgressBar1.Padding = New Padding(18, 8, 18, 8)
        pProgressBar1.Size = New Size(1258, 22)
        pProgressBar1.TabIndex = 19
        ' 
        ' proBarProcessed
        ' 
        proBarProcessed.BackColor = SystemColors.Control
        proBarProcessed.Dock = DockStyle.Fill
        proBarProcessed.Location = New Point(18, 8)
        proBarProcessed.Margin = New Padding(0)
        proBarProcessed.Name = "proBarProcessed"
        proBarProcessed.Size = New Size(1222, 6)
        proBarProcessed.TabIndex = 3
        ' 
        ' pProgressBar2
        ' 
        tlpContainer.SetColumnSpan(pProgressBar2, 13)
        pProgressBar2.Controls.Add(proBarGrouped)
        pProgressBar2.Dock = DockStyle.Fill
        pProgressBar2.Location = New Point(0, 845)
        pProgressBar2.Margin = New Padding(0)
        pProgressBar2.Name = "pProgressBar2"
        pProgressBar2.Padding = New Padding(18, 8, 18, 8)
        pProgressBar2.Size = New Size(1258, 22)
        pProgressBar2.TabIndex = 20
        ' 
        ' proBarGrouped
        ' 
        proBarGrouped.BackColor = SystemColors.Control
        proBarGrouped.Dock = DockStyle.Fill
        proBarGrouped.Location = New Point(18, 8)
        proBarGrouped.Margin = New Padding(0)
        proBarGrouped.Name = "proBarGrouped"
        proBarGrouped.Size = New Size(1222, 6)
        proBarGrouped.TabIndex = 3
        ' 
        ' HorSeparator3
        ' 
        HorSeparator3.BackColor = Color.LightGray
        tlpContainer.SetColumnSpan(HorSeparator3, 13)
        HorSeparator3.Dock = DockStyle.Fill
        HorSeparator3.ForeColor = SystemColors.Control
        HorSeparator3.Location = New Point(0, 762)
        HorSeparator3.Margin = New Padding(0)
        HorSeparator3.Name = "HorSeparator3"
        HorSeparator3.Size = New Size(1258, 1)
        HorSeparator3.TabIndex = 21
        ' 
        ' pProgressBar1Title
        ' 
        tlpContainer.SetColumnSpan(pProgressBar1Title, 13)
        pProgressBar1Title.Controls.Add(lblProBarProcessedCounter)
        pProgressBar1Title.Controls.Add(lblProBarProcessed)
        pProgressBar1Title.Dock = DockStyle.Fill
        pProgressBar1Title.Location = New Point(0, 778)
        pProgressBar1Title.Margin = New Padding(0)
        pProgressBar1Title.Name = "pProgressBar1Title"
        pProgressBar1Title.Padding = New Padding(7, 0, 0, 0)
        pProgressBar1Title.Size = New Size(1258, 15)
        pProgressBar1Title.TabIndex = 23
        ' 
        ' lblProBarProcessedCounter
        ' 
        lblProBarProcessedCounter.AutoSize = True
        lblProBarProcessedCounter.Dock = DockStyle.Left
        lblProBarProcessedCounter.ForeColor = Color.DarkGray
        lblProBarProcessedCounter.Location = New Point(142, 0)
        lblProBarProcessedCounter.Margin = New Padding(0)
        lblProBarProcessedCounter.Name = "lblProBarProcessedCounter"
        lblProBarProcessedCounter.Size = New Size(0, 15)
        lblProBarProcessedCounter.TabIndex = 3
        ' 
        ' lblProBarProcessed
        ' 
        lblProBarProcessed.AutoSize = True
        lblProBarProcessed.Dock = DockStyle.Left
        lblProBarProcessed.ForeColor = SystemColors.ControlDarkDark
        lblProBarProcessed.Location = New Point(7, 0)
        lblProBarProcessed.Margin = New Padding(0)
        lblProBarProcessed.Name = "lblProBarProcessed"
        lblProBarProcessed.Padding = New Padding(9, 0, 0, 0)
        lblProBarProcessed.Size = New Size(135, 15)
        lblProBarProcessed.TabIndex = 2
        lblProBarProcessed.Text = "Procesando imágenes:"
        ' 
        ' flpFolders
        ' 
        flpFolders.AllowDrop = True
        tlpContainer.SetColumnSpan(flpFolders, 13)
        flpFolders.Dock = DockStyle.Fill
        flpFolders.Location = New Point(19, 77)
        flpFolders.Margin = New Padding(19, 10, 19, 19)
        flpFolders.Name = "flpFolders"
        flpFolders.Padding = New Padding(10, 20, 0, 15)
        flpFolders.SelectedPath = Nothing
        flpFolders.Size = New Size(1220, 666)
        flpFolders.TabIndex = 24
        ' 
        ' counterImagesProcessed
        ' 
        counterImagesProcessed.AutoSize = True
        counterImagesProcessed.AutoSizeMode = AutoSizeMode.GrowAndShrink
        counterImagesProcessed.BackColor = Color.White
        counterImagesProcessed.Counter = 0
        counterImagesProcessed.EnableLog = False
        counterImagesProcessed.Location = New Point(0, 1)
        counterImagesProcessed.LogType = LogType.ImageProcessed
        counterImagesProcessed.Margin = New Padding(0)
        counterImagesProcessed.Name = "counterImagesProcessed"
        counterImagesProcessed.Padding = New Padding(4, 4, 10, 0)
        counterImagesProcessed.Size = New Size(181, 26)
        counterImagesProcessed.TabIndex = 25
        counterImagesProcessed.Title = "Imagenes procesadas"
        ' 
        ' pProgressBar2Title
        ' 
        tlpContainer.SetColumnSpan(pProgressBar2Title, 13)
        pProgressBar2Title.Controls.Add(lblProBarGroupedCounter)
        pProgressBar2Title.Controls.Add(lblProBarGrouped)
        pProgressBar2Title.Dock = DockStyle.Fill
        pProgressBar2Title.Location = New Point(0, 830)
        pProgressBar2Title.Margin = New Padding(0)
        pProgressBar2Title.Name = "pProgressBar2Title"
        pProgressBar2Title.Padding = New Padding(7, 0, 0, 0)
        pProgressBar2Title.Size = New Size(1258, 15)
        pProgressBar2Title.TabIndex = 28
        ' 
        ' lblProBarGroupedCounter
        ' 
        lblProBarGroupedCounter.AutoSize = True
        lblProBarGroupedCounter.Dock = DockStyle.Left
        lblProBarGroupedCounter.ForeColor = Color.DarkGray
        lblProBarGroupedCounter.Location = New Point(163, 0)
        lblProBarGroupedCounter.Margin = New Padding(0)
        lblProBarGroupedCounter.Name = "lblProBarGroupedCounter"
        lblProBarGroupedCounter.Size = New Size(0, 15)
        lblProBarGroupedCounter.TabIndex = 3
        ' 
        ' lblProBarGrouped
        ' 
        lblProBarGrouped.AutoSize = True
        lblProBarGrouped.Dock = DockStyle.Left
        lblProBarGrouped.ForeColor = SystemColors.ControlDarkDark
        lblProBarGrouped.Location = New Point(7, 0)
        lblProBarGrouped.Margin = New Padding(0)
        lblProBarGrouped.Name = "lblProBarGrouped"
        lblProBarGrouped.Padding = New Padding(9, 0, 0, 0)
        lblProBarGrouped.Size = New Size(156, 15)
        lblProBarGrouped.TabIndex = 2
        lblProBarGrouped.Text = "Procesando coincidencias:"
        ' 
        ' counterImagesMoved
        ' 
        counterImagesMoved.AutoSize = True
        counterImagesMoved.AutoSizeMode = AutoSizeMode.GrowAndShrink
        counterImagesMoved.BackColor = Color.White
        counterImagesMoved.Counter = 0
        counterImagesMoved.EnableLog = False
        counterImagesMoved.Location = New Point(581, 1)
        counterImagesMoved.LogType = LogType.ImageMoved
        counterImagesMoved.Margin = New Padding(0)
        counterImagesMoved.Name = "counterImagesMoved"
        counterImagesMoved.Padding = New Padding(4, 4, 10, 0)
        counterImagesMoved.Size = New Size(167, 26)
        counterImagesMoved.TabIndex = 26
        counterImagesMoved.Title = "Imagenes movidas"
        ' 
        ' counterImagesMatched
        ' 
        counterImagesMatched.AutoSize = True
        counterImagesMatched.AutoSizeMode = AutoSizeMode.GrowAndShrink
        counterImagesMatched.BackColor = Color.White
        counterImagesMatched.Counter = 0
        counterImagesMatched.EnableLog = False
        counterImagesMatched.Location = New Point(370, 1)
        counterImagesMatched.LogType = LogType.ImageMatched
        counterImagesMatched.Margin = New Padding(0)
        counterImagesMatched.Name = "counterImagesMatched"
        counterImagesMatched.Padding = New Padding(4, 4, 10, 0)
        counterImagesMatched.Size = New Size(210, 26)
        counterImagesMatched.TabIndex = 29
        counterImagesMatched.Title = "Coincidencias encontradas"
        ' 
        ' counterImagesDeleted
        ' 
        counterImagesDeleted.AutoSize = True
        counterImagesDeleted.AutoSizeMode = AutoSizeMode.GrowAndShrink
        counterImagesDeleted.BackColor = Color.White
        counterImagesDeleted.Counter = 0
        counterImagesDeleted.EnableLog = False
        counterImagesDeleted.Location = New Point(749, 1)
        counterImagesDeleted.LogType = LogType.ImageDeleted
        counterImagesDeleted.Margin = New Padding(0)
        counterImagesDeleted.Name = "counterImagesDeleted"
        counterImagesDeleted.Padding = New Padding(4, 4, 10, 0)
        counterImagesDeleted.Size = New Size(179, 26)
        counterImagesDeleted.TabIndex = 29
        counterImagesDeleted.Title = "Imagenes eliminadas"
        ' 
        ' counterMoveErrors
        ' 
        counterMoveErrors.AutoSize = True
        counterMoveErrors.AutoSizeMode = AutoSizeMode.GrowAndShrink
        counterMoveErrors.BackColor = Color.White
        counterMoveErrors.Counter = 0
        counterMoveErrors.EnableLog = False
        counterMoveErrors.Location = New Point(929, 1)
        counterMoveErrors.LogType = LogType.MoveError
        counterMoveErrors.Margin = New Padding(0)
        counterMoveErrors.Name = "counterMoveErrors"
        counterMoveErrors.Padding = New Padding(4, 4, 10, 0)
        counterMoveErrors.Size = New Size(161, 26)
        counterMoveErrors.TabIndex = 27
        counterMoveErrors.Title = "Errores moviendo"
        ' 
        ' counterDeleteErrors
        ' 
        counterDeleteErrors.AutoSize = True
        counterDeleteErrors.AutoSizeMode = AutoSizeMode.GrowAndShrink
        counterDeleteErrors.BackColor = Color.White
        counterDeleteErrors.Counter = 0
        counterDeleteErrors.EnableLog = False
        counterDeleteErrors.Location = New Point(1091, 1)
        counterDeleteErrors.LogType = LogType.DeleteError
        counterDeleteErrors.Margin = New Padding(0)
        counterDeleteErrors.Name = "counterDeleteErrors"
        counterDeleteErrors.Padding = New Padding(4, 4, 10, 0)
        counterDeleteErrors.Size = New Size(167, 26)
        counterDeleteErrors.TabIndex = 29
        counterDeleteErrors.Title = "Errores eliminando"
        ' 
        ' PhotoMatchForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(1258, 921)
        Controls.Add(tlpContainer)
        ForeColor = Color.DarkGray
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        Name = "PhotoMatchForm"
        RightToLeftLayout = True
        StartPosition = FormStartPosition.CenterScreen
        Text = "Photo Match"
        tlpContainer.ResumeLayout(False)
        tlpContainer.PerformLayout()
        pnlFolderPath.ResumeLayout(False)
        pnlFolderPath.PerformLayout()
        CType(btnBackFolder, ComponentModel.ISupportInitialize).EndInit()
        pFolderButtons.ResumeLayout(False)
        CType(btnUpdateFolder, ComponentModel.ISupportInitialize).EndInit()
        pProgressBar1.ResumeLayout(False)
        pProgressBar2.ResumeLayout(False)
        pProgressBar1Title.ResumeLayout(False)
        pProgressBar1Title.PerformLayout()
        pProgressBar2Title.ResumeLayout(False)
        pProgressBar2Title.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents tlpContainer As TableLayoutPanel
    Friend WithEvents HorSeparator4 As Panel
    Friend WithEvents HorSeparator1 As Panel
    Friend WithEvents HorSeparator2 As Panel
    Friend WithEvents VerSeparator1 As Panel
    Friend WithEvents VerSeparator5 As Panel
    Friend WithEvents VerSeparator3 As Panel
    Friend WithEvents VerSeparator2 As Panel
    Friend WithEvents VerSeparator4 As Panel
    Friend WithEvents pnlNotification As Panel
    Friend WithEvents pnlFolderPath As Panel
    Friend WithEvents lblFolderPath As Label
    Friend WithEvents lblFolderTitle As Label
    Friend WithEvents lblProBarProcessed As Label
    Private WithEvents proBarProcessed As ProgressBar
    Friend WithEvents pProgressBar1 As Panel
    Friend WithEvents pProgressBar2 As Panel
    Private WithEvents proBarGrouped As ProgressBar
    Friend WithEvents HorSeparator3 As Panel
    Friend WithEvents flpFolders As DropPanel
    Friend WithEvents pProgressBar1Title As Panel
    Friend WithEvents counterImagesProcessed As CounterDisplay
    Friend WithEvents counterImagesMoved As CounterDisplay
    Friend WithEvents counterMoveErrors As CounterDisplay
    Friend WithEvents pProgressBar2Title As Panel
    Friend WithEvents lblProBarGrouped As Label
    Friend WithEvents counterImagesMatched As CounterDisplay
    Friend WithEvents pFolderButtons As Panel
    Friend WithEvents btnBackFolder As PictureBox
    Friend WithEvents btnUpdateFolder As PictureBox
    Friend WithEvents counterImagesCompared As CounterDisplay
    Friend WithEvents counterImagesDeleted As CounterDisplay
    Friend WithEvents counterDeleteErrors As CounterDisplay
    Friend WithEvents VerSeparator6 As Panel
    Private WithEvents lblProBarGroupedCounter As Label
    Private WithEvents lblProBarProcessedCounter As Label

End Class
