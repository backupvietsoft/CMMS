<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoaiphutung
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
        Me.components = New System.ComponentModel.Container()
        Me.grpDanhSach = New System.Windows.Forms.GroupBox()
        Me.grdLPT = New DevExpress.XtraGrid.GridControl()
        Me.grvLPT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grpNhapThongTin = New System.Windows.Forms.GroupBox()
        Me.lblTEN_LOAI_PT = New System.Windows.Forms.Label()
        Me.txtGHI_CHU = New Commons.utcTextBox()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtTEN_LOAI_PT = New Commons.utcTextBox()
        Me.lblGHI_CHU = New System.Windows.Forms.Label()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMS_LOAI_PT = New Commons.utcTextBox()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDanhSach.SuspendLayout()
        CType(Me.grdLPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvLPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNhapThongTin.SuspendLayout()
        CType(Me.txtGHI_CHU.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTEN_LOAI_PT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtMS_LOAI_PT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDanhSach
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.grpDanhSach, 5)
        Me.grpDanhSach.Controls.Add(Me.grdLPT)
        Me.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhSach.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhSach.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhSach.Location = New System.Drawing.Point(3, 131)
        Me.grpDanhSach.Name = "grpDanhSach"
        Me.grpDanhSach.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grpDanhSach.Size = New System.Drawing.Size(678, 287)
        Me.grpDanhSach.TabIndex = 6
        Me.grpDanhSach.TabStop = False
        Me.grpDanhSach.Text = "Danh mục"
        '
        'grdLPT
        '
        Me.grdLPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLPT.Location = New System.Drawing.Point(3, 21)
        Me.grdLPT.MainView = Me.grvLPT
        Me.grdLPT.Name = "grdLPT"
        Me.grdLPT.Size = New System.Drawing.Size(672, 263)
        Me.grdLPT.TabIndex = 100
        Me.grdLPT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvLPT})
        '
        'grvLPT
        '
        Me.grvLPT.GridControl = Me.grdLPT
        Me.grvLPT.Name = "grvLPT"
        Me.grvLPT.OptionsView.ShowGroupPanel = False
        '
        'grpNhapThongTin
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.grpNhapThongTin, 5)
        Me.grpNhapThongTin.Controls.Add(Me.lblTEN_LOAI_PT)
        Me.grpNhapThongTin.Controls.Add(Me.txtGHI_CHU)
        Me.grpNhapThongTin.Controls.Add(Me.txtTEN_LOAI_PT)
        Me.grpNhapThongTin.Controls.Add(Me.lblGHI_CHU)
        Me.grpNhapThongTin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNhapThongTin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhapThongTin.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapThongTin.Location = New System.Drawing.Point(3, 41)
        Me.grpNhapThongTin.Name = "grpNhapThongTin"
        Me.grpNhapThongTin.Size = New System.Drawing.Size(678, 80)
        Me.grpNhapThongTin.TabIndex = 1
        Me.grpNhapThongTin.TabStop = False
        Me.grpNhapThongTin.Text = "Nhập thông tin"
        '
        'lblTEN_LOAI_PT
        '
        Me.lblTEN_LOAI_PT.AutoSize = True
        Me.lblTEN_LOAI_PT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTEN_LOAI_PT.ForeColor = System.Drawing.Color.Black
        Me.lblTEN_LOAI_PT.Location = New System.Drawing.Point(13, 26)
        Me.lblTEN_LOAI_PT.Name = "lblTEN_LOAI_PT"
        Me.lblTEN_LOAI_PT.Size = New System.Drawing.Size(54, 14)
        Me.lblTEN_LOAI_PT.TabIndex = 2
        Me.lblTEN_LOAI_PT.Text = "Tên loại"
        '
        'txtGHI_CHU
        '
        Me.txtGHI_CHU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGHI_CHU.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtGHI_CHU.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtGHI_CHU.ErrorProviderControl = Me.errProvider
        Me.txtGHI_CHU.FieldName = ""
        Me.txtGHI_CHU.IsNull = True
        Me.txtGHI_CHU.Location = New System.Drawing.Point(141, 49)
        Me.txtGHI_CHU.MaxLength = 0
        Me.txtGHI_CHU.Multiline = False
        Me.txtGHI_CHU.Name = "txtGHI_CHU"
        Me.txtGHI_CHU.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtGHI_CHU.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtGHI_CHU.Properties.Appearance.Options.UseBackColor = True
        Me.txtGHI_CHU.Properties.Appearance.Options.UseTextOptions = True
        Me.txtGHI_CHU.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtGHI_CHU.Properties.ReadOnly = True
        Me.txtGHI_CHU.ReadOnly = True
        Me.txtGHI_CHU.Size = New System.Drawing.Size(524, 20)
        Me.txtGHI_CHU.TabIndex = 4
        Me.txtGHI_CHU.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtGHI_CHU.TextTypeMode = Commons.TypeMode.None
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'txtTEN_LOAI_PT
        '
        Me.txtTEN_LOAI_PT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTEN_LOAI_PT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_LOAI_PT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_LOAI_PT.ErrorProviderControl = Me.errProvider
        Me.txtTEN_LOAI_PT.FieldName = ""
        Me.txtTEN_LOAI_PT.IsNull = False
        Me.txtTEN_LOAI_PT.Location = New System.Drawing.Point(141, 23)
        Me.txtTEN_LOAI_PT.MaxLength = 0
        Me.txtTEN_LOAI_PT.Multiline = False
        Me.txtTEN_LOAI_PT.Name = "txtTEN_LOAI_PT"
        Me.txtTEN_LOAI_PT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_LOAI_PT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_LOAI_PT.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_LOAI_PT.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_LOAI_PT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_LOAI_PT.Properties.ReadOnly = True
        Me.txtTEN_LOAI_PT.ReadOnly = True
        Me.txtTEN_LOAI_PT.Size = New System.Drawing.Size(524, 20)
        Me.txtTEN_LOAI_PT.TabIndex = 3
        Me.txtTEN_LOAI_PT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_LOAI_PT.TextTypeMode = Commons.TypeMode.None
        '
        'lblGHI_CHU
        '
        Me.lblGHI_CHU.AutoSize = True
        Me.lblGHI_CHU.ForeColor = System.Drawing.Color.Black
        Me.lblGHI_CHU.Location = New System.Drawing.Point(13, 52)
        Me.lblGHI_CHU.Name = "lblGHI_CHU"
        Me.lblGHI_CHU.Size = New System.Drawing.Size(48, 14)
        Me.lblGHI_CHU.TabIndex = 4
        Me.lblGHI_CHU.Text = "Ghi chú"
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Location = New System.Drawing.Point(361, 2)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(104, 30)
        Me.BtnSua.TabIndex = 9
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Location = New System.Drawing.Point(571, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat.TabIndex = 11
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Location = New System.Drawing.Point(466, 2)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(104, 30)
        Me.BtnXoa.TabIndex = 10
        Me.BtnXoa.Text = "&Xóa"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Location = New System.Drawing.Point(256, 2)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem.TabIndex = 8
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Location = New System.Drawing.Point(466, 2)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi.TabIndex = 12
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Location = New System.Drawing.Point(571, 2)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi.TabIndex = 13
        Me.BtnKhongghi.Text = "&Không"
        '
        'Panel1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel1, 5)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 424)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(678, 34)
        Me.Panel1.TabIndex = 47
        '
        'txtMS_LOAI_PT
        '
        Me.txtMS_LOAI_PT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMS_LOAI_PT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMS_LOAI_PT.ErrorProviderControl = Nothing
        Me.txtMS_LOAI_PT.FieldName = ""
        Me.txtMS_LOAI_PT.IsNull = False
        Me.txtMS_LOAI_PT.Location = New System.Drawing.Point(667, 11)
        Me.txtMS_LOAI_PT.MaxLength = 0
        Me.txtMS_LOAI_PT.Multiline = False
        Me.txtMS_LOAI_PT.Name = "txtMS_LOAI_PT"
        Me.txtMS_LOAI_PT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMS_LOAI_PT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMS_LOAI_PT.Properties.Appearance.Options.UseBackColor = True
        Me.txtMS_LOAI_PT.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMS_LOAI_PT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMS_LOAI_PT.Properties.ReadOnly = True
        Me.txtMS_LOAI_PT.ReadOnly = True
        Me.txtMS_LOAI_PT.Size = New System.Drawing.Size(14, 20)
        Me.txtMS_LOAI_PT.TabIndex = 46
        Me.txtMS_LOAI_PT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMS_LOAI_PT.TextTypeMode = Commons.TypeMode.None
        Me.txtMS_LOAI_PT.Visible = False
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(635, 9)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(28, 28)
        Me.btnVideo.TabIndex = 99
        Me.btnVideo.Tag = "CMMS!frmLoaiphutung"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(605, 9)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 28)
        Me.btnHelp.TabIndex = 98
        Me.btnHelp.Tag = "CMMS!frmLoaiphutung"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtMS_LOAI_PT, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnVideo, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.grpNhapThongTin, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.grpDanhSach, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnHelp, 2, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(684, 461)
        Me.TableLayoutPanel2.TabIndex = 49
        '
        'frmLoaiphutung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 461)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmLoaiphutung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loại phụ tùng"
        Me.grpDanhSach.ResumeLayout(False)
        CType(Me.grdLPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvLPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNhapThongTin.ResumeLayout(False)
        Me.grpNhapThongTin.PerformLayout()
        CType(Me.txtGHI_CHU.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTEN_LOAI_PT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtMS_LOAI_PT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMS_LOAI_PT As Commons.utcTextBox
    Friend WithEvents grpDanhSach As System.Windows.Forms.GroupBox
    Friend WithEvents grpNhapThongTin As System.Windows.Forms.GroupBox
    Friend WithEvents txtGHI_CHU As Commons.utcTextBox
    Friend WithEvents txtTEN_LOAI_PT As Commons.utcTextBox
    Friend WithEvents lblGHI_CHU As System.Windows.Forms.Label
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTEN_LOAI_PT As System.Windows.Forms.Label
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdLPT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvLPT As DevExpress.XtraGrid.Views.Grid.GridView
End Class
