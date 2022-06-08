<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmChonPTchoBTPN
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
        Me.LblChonPT = New System.Windows.Forms.Label()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblLOAI_VT = New System.Windows.Forms.Label()
        Me.BtnChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBoChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdPT = New DevExpress.XtraGrid.GridControl()
        Me.grvPT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grdVT = New DevExpress.XtraGrid.GridControl()
        Me.grvVT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cboLOAI_VT = New DevExpress.XtraEditors.LookUpEdit()
        Me.CboLoaiPT = New DevExpress.XtraEditors.LookUpEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTimVT = New DevExpress.XtraEditors.TextEdit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdVT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvVT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLOAI_VT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboLoaiPT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtTimVT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblChonPT
        '
        Me.LblChonPT.AutoSize = True
        Me.LblChonPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblChonPT.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LblChonPT.Location = New System.Drawing.Point(139, 8)
        Me.LblChonPT.Name = "LblChonPT"
        Me.LblChonPT.Size = New System.Drawing.Size(104, 25)
        Me.LblChonPT.TabIndex = 26
        Me.LblChonPT.Text = "Loại phụ tùng"
        Me.LblChonPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(789, 3)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 85
        Me.BtnThoat.Text = "Thoát"
        '
        'BtnThucHien
        '
        Me.BtnThucHien.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThucHien.Location = New System.Drawing.Point(684, 3)
        Me.BtnThucHien.Name = "BtnThucHien"
        Me.BtnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.BtnThucHien.TabIndex = 84
        Me.BtnThucHien.Text = "Thực hiện"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'lblLOAI_VT
        '
        Me.lblLOAI_VT.AutoSize = True
        Me.lblLOAI_VT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLOAI_VT.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblLOAI_VT.Location = New System.Drawing.Point(453, 8)
        Me.lblLOAI_VT.Name = "lblLOAI_VT"
        Me.lblLOAI_VT.Size = New System.Drawing.Size(104, 25)
        Me.lblLOAI_VT.TabIndex = 87
        Me.lblLOAI_VT.Text = "Loại vật tư"
        Me.lblLOAI_VT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Location = New System.Drawing.Point(474, 3)
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnChonTatCa.TabIndex = 88
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        Me.BtnChonTatCa.Visible = False
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(579, 3)
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnBoChonTatCa.TabIndex = 89
        Me.BtnBoChonTatCa.Text = "Bỏ chọn tất cả"
        Me.BtnBoChonTatCa.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdPT)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 478)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh sách cấu trúc thiết bị phụ tùng"
        '
        'grdPT
        '
        Me.grdPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPT.Location = New System.Drawing.Point(3, 17)
        Me.grdPT.MainView = Me.grvPT
        Me.grdPT.Name = "grdPT"
        Me.grdPT.Size = New System.Drawing.Size(438, 458)
        Me.grdPT.TabIndex = 91
        Me.grdPT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPT})
        '
        'grvPT
        '
        Me.grvPT.GridControl = Me.grdPT
        Me.grvPT.Name = "grvPT"
        Me.grvPT.OptionsView.ColumnAutoWidth = False
        Me.grvPT.OptionsView.EnableAppearanceEvenRow = True
        Me.grvPT.OptionsView.EnableAppearanceOddRow = True
        Me.grvPT.OptionsView.ShowGroupPanel = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdVT)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(445, 478)
        Me.GroupBox2.TabIndex = 91
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Danh sách thiết bị vật tư"
        '
        'grdVT
        '
        Me.grdVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVT.Location = New System.Drawing.Point(3, 17)
        Me.grdVT.MainView = Me.grvVT
        Me.grdVT.Name = "grdVT"
        Me.grdVT.Size = New System.Drawing.Size(439, 458)
        Me.grdVT.TabIndex = 92
        Me.grdVT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvVT})
        '
        'grvVT
        '
        Me.grvVT.GridControl = Me.grdVT
        Me.grvVT.Name = "grvVT"
        Me.grvVT.OptionsView.ColumnAutoWidth = False
        Me.grvVT.OptionsView.EnableAppearanceEvenRow = True
        Me.grvVT.OptionsView.EnableAppearanceOddRow = True
        Me.grvVT.OptionsView.ShowGroupPanel = False
        '
        'cboLOAI_VT
        '
        Me.cboLOAI_VT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLOAI_VT.Location = New System.Drawing.Point(563, 11)
        Me.cboLOAI_VT.Name = "cboLOAI_VT"
        Me.cboLOAI_VT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLOAI_VT.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLOAI_VT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLOAI_VT.Properties.NullText = ""
        Me.cboLOAI_VT.Size = New System.Drawing.Size(198, 20)
        Me.cboLOAI_VT.TabIndex = 86
        '
        'CboLoaiPT
        '
        Me.CboLoaiPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CboLoaiPT.Location = New System.Drawing.Point(249, 11)
        Me.CboLoaiPT.Name = "CboLoaiPT"
        Me.CboLoaiPT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CboLoaiPT.Properties.LookAndFeel.SkinName = "Blue"
        Me.CboLoaiPT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.CboLoaiPT.Properties.NullText = ""
        Me.CboLoaiPT.Size = New System.Drawing.Size(198, 20)
        Me.CboLoaiPT.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainerControl1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LblChonPT, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CboLoaiPT, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLOAI_VT, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLOAI_VT, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(901, 561)
        Me.TableLayoutPanel1.TabIndex = 92
        '
        'SplitContainerControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.SplitContainerControl1, 6)
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl1.Location = New System.Drawing.Point(3, 40)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainerControl1.Panel1.ShowCaption = True
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainerControl1.Panel2.ShowCaption = True
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(895, 478)
        Me.SplitContainerControl1.SplitterPosition = 444
        Me.SplitContainerControl1.TabIndex = 92
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 6)
        Me.Panel1.Controls.Add(Me.txtTimVT)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnThucHien)
        Me.Panel1.Controls.Add(Me.BtnBoChonTatCa)
        Me.Panel1.Controls.Add(Me.BtnChonTatCa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 524)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(895, 34)
        Me.Panel1.TabIndex = 93
        '
        'txtTimVT
        '
        Me.txtTimVT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTimVT.Location = New System.Drawing.Point(3, 13)
        Me.txtTimVT.Name = "txtTimVT"
        Me.txtTimVT.Size = New System.Drawing.Size(158, 20)
        Me.txtTimVT.TabIndex = 91
        '
        'FrmChonPTchoBTPN
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmChonPTchoBTPN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn công việc cho bảo trì phòng ngừa"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdVT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvVT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLOAI_VT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboLoaiPT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtTimVT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CboLoaiPT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LblChonPT As System.Windows.Forms.Label
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblLOAI_VT As System.Windows.Forms.Label
    Friend WithEvents cboLOAI_VT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BtnBoChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTimVT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grdPT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvPT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdVT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvVT As DevExpress.XtraGrid.Views.Grid.GridView
End Class
