<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.XtraTabbedMdiManager = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.BarAndDockingController = New DevExpress.XtraBars.BarAndDockingController(Me.components)
        Me.DockManager = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarMenu = New DevExpress.XtraBars.Bar()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.BarUserName = New DevExpress.XtraBars.BarStaticItem()
        Me.barLog = New DevExpress.XtraBars.BarStaticItem()
        Me.BarCompanyInfo = New DevExpress.XtraBars.BarStaticItem()
        Me.BarVersion = New DevExpress.XtraBars.BarStaticItem()
        Me.BarDateUpdate = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarDateServer = New DevExpress.XtraBars.BarStaticItem()
        Me.BarMdiChildrenListItem1 = New DevExpress.XtraBars.BarMdiChildrenListItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.XtraTabbedMdiManager,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BarAndDockingController,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DockManager,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BarManager,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureEdit1.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'XtraTabbedMdiManager
        '
        Me.XtraTabbedMdiManager.AppearancePage.Header.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XtraTabbedMdiManager.AppearancePage.Header.Options.UseFont = true
        Me.XtraTabbedMdiManager.AppearancePage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XtraTabbedMdiManager.AppearancePage.HeaderActive.Options.UseFont = true
        Me.XtraTabbedMdiManager.AppearancePage.HeaderDisabled.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XtraTabbedMdiManager.AppearancePage.HeaderDisabled.Options.UseFont = true
        Me.XtraTabbedMdiManager.Controller = Me.BarAndDockingController
        Me.XtraTabbedMdiManager.MdiParent = Me
        '
        'BarAndDockingController
        '
        Me.BarAndDockingController.AppearancesBar.Bar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarAndDockingController.AppearancesBar.Bar.Options.UseFont = true
        Me.BarAndDockingController.AppearancesBar.Dock.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarAndDockingController.AppearancesBar.Dock.Options.UseFont = true
        Me.BarAndDockingController.AppearancesBar.MainMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarAndDockingController.AppearancesBar.MainMenu.Options.UseFont = true
        Me.BarAndDockingController.AppearancesDocking.ActiveTab.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarAndDockingController.AppearancesDocking.ActiveTab.Options.UseFont = true
        Me.BarAndDockingController.AppearancesDocking.PanelCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarAndDockingController.AppearancesDocking.PanelCaption.Options.UseFont = true
        Me.BarAndDockingController.AppearancesDocking.PanelCaptionActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarAndDockingController.AppearancesDocking.PanelCaptionActive.Options.UseFont = true
        Me.BarAndDockingController.AppearancesRibbon.FormCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarAndDockingController.AppearancesRibbon.FormCaption.Options.UseFont = true
        Me.BarAndDockingController.LookAndFeel.SkinName = "Blue"
        Me.BarAndDockingController.LookAndFeel.UseDefaultLookAndFeel = false
        Me.BarAndDockingController.PropertiesBar.AllowLinkLighting = false
        '
        'DockManager
        '
        Me.DockManager.Controller = Me.BarAndDockingController
        Me.DockManager.Form = Me
        Me.DockManager.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = false
        Me.BarManager.AllowMoveBarOnToolbar = false
        Me.BarManager.AllowQuickCustomization = false
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.BarMenu, Me.Bar3})
        Me.BarManager.Controller = Me.BarAndDockingController
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.DockManager = Me.DockManager
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarUserName, Me.BarCompanyInfo, Me.BarVersion, Me.BarDateUpdate, Me.BarDateServer, Me.BarMdiChildrenListItem1, Me.barLog})
        Me.BarManager.MainMenu = Me.BarMenu
        Me.BarManager.MaxItemId = 11
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.BarManager.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 1
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.OptionsBar.AllowQuickCustomization = false
        Me.Bar1.OptionsBar.DisableClose = true
        Me.Bar1.OptionsBar.DisableCustomization = true
        Me.Bar1.Text = "Tools"
        Me.Bar1.Visible = false
        '
        'BarMenu
        '
        Me.BarMenu.BarName = "Main menu"
        Me.BarMenu.DockCol = 0
        Me.BarMenu.DockRow = 0
        Me.BarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.BarMenu.FloatLocation = New System.Drawing.Point(46, 179)
        Me.BarMenu.OptionsBar.AllowQuickCustomization = false
        Me.BarMenu.OptionsBar.DisableClose = true
        Me.BarMenu.OptionsBar.DisableCustomization = true
        Me.BarMenu.OptionsBar.MultiLine = true
        Me.BarMenu.OptionsBar.UseWholeRow = true
        Me.BarMenu.Text = "Main menu"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarUserName), New DevExpress.XtraBars.LinkPersistInfo(Me.barLog), New DevExpress.XtraBars.LinkPersistInfo(Me.BarCompanyInfo), New DevExpress.XtraBars.LinkPersistInfo(Me.BarVersion), New DevExpress.XtraBars.LinkPersistInfo(Me.BarDateUpdate)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = false
        Me.Bar3.OptionsBar.DrawDragBorder = false
        Me.Bar3.Text = "Status bar"
        '
        'BarUserName
        '
        Me.BarUserName.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarUserName.Appearance.Options.UseFont = true
        Me.BarUserName.Caption = "  "
        Me.BarUserName.Id = 2
        Me.BarUserName.Name = "BarUserName"
        Me.BarUserName.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'barLog
        '
        Me.barLog.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.barLog.Appearance.Options.UseFont = true
        Me.barLog.Id = 10
        Me.barLog.Name = "barLog"
        Me.barLog.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarCompanyInfo
        '
        Me.BarCompanyInfo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarCompanyInfo.Appearance.Options.UseFont = true
        Me.BarCompanyInfo.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.BarCompanyInfo.Caption = "  "
        Me.BarCompanyInfo.Id = 3
        Me.BarCompanyInfo.Name = "BarCompanyInfo"
        Me.BarCompanyInfo.TextAlignment = System.Drawing.StringAlignment.Center
        Me.BarCompanyInfo.Width = 32
        '
        'BarVersion
        '
        Me.BarVersion.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarVersion.Appearance.Options.UseFont = true
        Me.BarVersion.Caption = "  "
        Me.BarVersion.Id = 4
        Me.BarVersion.Name = "BarVersion"
        Me.BarVersion.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarDateUpdate
        '
        Me.BarDateUpdate.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BarDateUpdate.Appearance.Options.UseFont = true
        Me.BarDateUpdate.Caption = "  "
        Me.BarDateUpdate.Id = 5
        Me.BarDateUpdate.Name = "BarDateUpdate"
        Me.BarDateUpdate.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarDateServer
        '
        Me.BarDateServer.Id = 6
        Me.BarDateServer.Name = "BarDateServer"
        Me.BarDateServer.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarMdiChildrenListItem1
        '
        Me.BarMdiChildrenListItem1.Caption = "BarMdiChildrenListItem1"
        Me.BarMdiChildrenListItem1.Id = 7
        Me.BarMdiChildrenListItem1.Name = "BarMdiChildrenListItem1"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = false
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = false
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.EditValue = Global.My.Resources.Resources.Eco_VICT
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 50)
        Me.PictureEdit1.MenuManager = Me.BarManager
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(1085, 597)
        Me.PictureEdit1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1079, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 6
        '
        'frmMain
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 671)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.DoubleBuffered = true
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.IsMdiContainer = true
        Me.KeyPreview = true
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.Name = "frmMain"
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XtraTabbedMdiManager,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BarAndDockingController,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DockManager,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BarManager,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureEdit1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents XtraTabbedMdiManager As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents DockManager As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents BarAndDockingController As DevExpress.XtraBars.BarAndDockingController
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Public WithEvents BarUserName As DevExpress.XtraBars.BarStaticItem
    Public WithEvents BarCompanyInfo As DevExpress.XtraBars.BarStaticItem
    Public WithEvents BarVersion As DevExpress.XtraBars.BarStaticItem
    Public WithEvents BarDateUpdate As DevExpress.XtraBars.BarStaticItem
    Public WithEvents BarMenu As DevExpress.XtraBars.Bar
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BarDateServer As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarMdiChildrenListItem1 As DevExpress.XtraBars.BarMdiChildrenListItem
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Public WithEvents barLog As DevExpress.XtraBars.BarStaticItem
End Class
