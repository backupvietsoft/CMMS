<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackLog
    Inherits DevExpress.XtraEditors.XtraForm
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnBacklog = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.grdHangMuc = New DevExpress.XtraGrid.GridControl()
        Me.grvHangMuc = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdCongViec = New DevExpress.XtraGrid.GridControl()
        Me.grvCongViec = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.grdHangMuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvHangMuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCongViec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvCongViec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnBacklog)
        Me.PanelControl1.Controls.Add(Me.btnExit)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 729)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Padding = New System.Windows.Forms.Padding(0, 8, 124, 8)
        Me.PanelControl1.Size = New System.Drawing.Size(1263, 56)
        Me.PanelControl1.TabIndex = 1
        '
        'btnBacklog
        '
        Me.btnBacklog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBacklog.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBacklog.Appearance.Options.UseFont = True
        Me.btnBacklog.Image = Global.My.Resources.Resources.btnthuchien
        Me.btnBacklog.Location = New System.Drawing.Point(960, 8)
        Me.btnBacklog.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBacklog.Name = "btnBacklog"
        Me.btnBacklog.Size = New System.Drawing.Size(149, 42)
        Me.btnBacklog.TabIndex = 3
        Me.btnBacklog.Text = "&Thực hiện"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Appearance.Options.UseFont = True
        Me.btnExit.Image = Global.My.Resources.Resources.btnthoat
        Me.btnExit.Location = New System.Drawing.Point(1111, 8)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(149, 42)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Th&oát"
        '
        'grdHangMuc
        '
        Me.grdHangMuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHangMuc.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdHangMuc.Location = New System.Drawing.Point(2, 29)
        Me.grdHangMuc.MainView = Me.grvHangMuc
        Me.grdHangMuc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdHangMuc.Name = "grdHangMuc"
        Me.grdHangMuc.Size = New System.Drawing.Size(1800, 393)
        Me.grdHangMuc.TabIndex = 1
        Me.grdHangMuc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvHangMuc})
        '
        'grvHangMuc
        '
        Me.grvHangMuc.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvHangMuc.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvHangMuc.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grvHangMuc.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvHangMuc.GridControl = Me.grdHangMuc
        Me.grvHangMuc.Name = "grvHangMuc"
        Me.grvHangMuc.OptionsView.ColumnAutoWidth = False
        Me.grvHangMuc.OptionsView.EnableAppearanceEvenRow = True
        Me.grvHangMuc.OptionsView.EnableAppearanceOddRow = True
        Me.grvHangMuc.OptionsView.ShowGroupPanel = False
        '
        'grdCongViec
        '
        Me.grdCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCongViec.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        GridLevelNode1.RelationName = "Level1"
        Me.grdCongViec.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdCongViec.Location = New System.Drawing.Point(2, 29)
        Me.grdCongViec.MainView = Me.grvCongViec
        Me.grdCongViec.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdCongViec.Name = "grdCongViec"
        Me.grdCongViec.Size = New System.Drawing.Size(1800, 557)
        Me.grdCongViec.TabIndex = 2
        Me.grdCongViec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCongViec})
        '
        'grvCongViec
        '
        Me.grvCongViec.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvCongViec.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvCongViec.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grvCongViec.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvCongViec.GridControl = Me.grdCongViec
        Me.grvCongViec.Name = "grvCongViec"
        Me.grvCongViec.OptionsCustomization.AllowRowSizing = True
        Me.grvCongViec.OptionsView.ColumnAutoWidth = False
        Me.grvCongViec.OptionsView.EnableAppearanceEvenRow = True
        Me.grvCongViec.OptionsView.EnableAppearanceOddRow = True
        Me.grvCongViec.OptionsView.ShowGroupPanel = False
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.grdHangMuc)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1804, 424)
        Me.GroupControl1.TabIndex = 3
        Me.GroupControl1.Text = "Hạng mục kế hoạch"
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.Controls.Add(Me.grdCongViec)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1804, 588)
        Me.GroupControl2.TabIndex = 4
        Me.GroupControl2.Text = "Công việc backlog"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1263, 729)
        Me.SplitContainerControl1.SplitterPosition = 216
        Me.SplitContainerControl1.TabIndex = 107
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'frmBackLog
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1263, 785)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Backlog"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.grdHangMuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvHangMuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCongViec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvCongViec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnBacklog As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdHangMuc As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvHangMuc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdCongViec As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvCongViec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
End Class
