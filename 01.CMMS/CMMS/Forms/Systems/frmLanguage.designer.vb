<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLanguage
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
        Me.grpDanhsachform = New System.Windows.Forms.GroupBox()
        Me.grdForm = New DevExpress.XtraGrid.GridControl()
        Me.grvForm = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grpThongtinchitiet = New System.Windows.Forms.GroupBox()
        Me.grdChiTiet = New DevExpress.XtraGrid.GridControl()
        Me.grvChiTiet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.optChon = New DevExpress.XtraEditors.RadioGroup()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblReplay = New DevExpress.XtraEditors.LabelControl()
        Me.txtChuoi = New DevExpress.XtraEditors.TextEdit()
        Me.txtReplay = New DevExpress.XtraEditors.TextEdit()
        Me.btnReplay = New DevExpress.XtraEditors.SimpleButton()
        Me.optCapNhap = New DevExpress.XtraEditors.RadioGroup()
        Me.lblDKien = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkChinhXac = New DevExpress.XtraEditors.CheckEdit()
        Me.btnNNGoc = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTim = New DevExpress.XtraEditors.TextEdit()
        Me.txtTK = New DevExpress.XtraEditors.TextEdit()
        Me.grpDanhsachform.SuspendLayout()
        CType(Me.grdForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpThongtinchitiet.SuspendLayout()
        CType(Me.grdChiTiet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChiTiet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.optChon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtChuoi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optCapNhap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.chkChinhXac.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTim.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDanhsachform
        '
        Me.grpDanhsachform.Controls.Add(Me.grdForm)
        Me.grpDanhsachform.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachform.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachform.Location = New System.Drawing.Point(0, 0)
        Me.grpDanhsachform.Name = "grpDanhsachform"
        Me.grpDanhsachform.Size = New System.Drawing.Size(352, 615)
        Me.grpDanhsachform.TabIndex = 1
        Me.grpDanhsachform.TabStop = False
        Me.grpDanhsachform.Text = "Danh sách form"
        '
        'grdForm
        '
        Me.grdForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdForm.Location = New System.Drawing.Point(3, 17)
        Me.grdForm.LookAndFeel.SkinName = "Blue"
        Me.grdForm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdForm.MainView = Me.grvForm
        Me.grdForm.Name = "grdForm"
        Me.grdForm.Size = New System.Drawing.Size(346, 595)
        Me.grdForm.TabIndex = 17
        Me.grdForm.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvForm, Me.GridView4})
        '
        'grvForm
        '
        Me.grvForm.GridControl = Me.grdForm
        Me.grvForm.Name = "grvForm"
        Me.grvForm.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvForm.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvForm.OptionsBehavior.Editable = False
        Me.grvForm.OptionsLayout.Columns.AddNewColumns = False
        Me.grvForm.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvForm.OptionsView.ColumnAutoWidth = False
        Me.grvForm.OptionsView.EnableAppearanceEvenRow = True
        Me.grvForm.OptionsView.EnableAppearanceOddRow = True
        Me.grvForm.OptionsView.ShowGroupPanel = False
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdForm
        Me.GridView4.Name = "GridView4"
        '
        'grpThongtinchitiet
        '
        Me.grpThongtinchitiet.Controls.Add(Me.grdChiTiet)
        Me.grpThongtinchitiet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpThongtinchitiet.ForeColor = System.Drawing.Color.Maroon
        Me.grpThongtinchitiet.Location = New System.Drawing.Point(0, 0)
        Me.grpThongtinchitiet.Name = "grpThongtinchitiet"
        Me.grpThongtinchitiet.Size = New System.Drawing.Size(942, 615)
        Me.grpThongtinchitiet.TabIndex = 2
        Me.grpThongtinchitiet.TabStop = False
        Me.grpThongtinchitiet.Text = "Thông tin chi tiết"
        '
        'grdChiTiet
        '
        Me.grdChiTiet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChiTiet.Location = New System.Drawing.Point(3, 17)
        Me.grdChiTiet.LookAndFeel.SkinName = "Blue"
        Me.grdChiTiet.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdChiTiet.MainView = Me.grvChiTiet
        Me.grdChiTiet.Name = "grdChiTiet"
        Me.grdChiTiet.Size = New System.Drawing.Size(936, 595)
        Me.grdChiTiet.TabIndex = 18
        Me.grdChiTiet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChiTiet, Me.GridView2})
        '
        'grvChiTiet
        '
        Me.grvChiTiet.GridControl = Me.grdChiTiet
        Me.grvChiTiet.Name = "grvChiTiet"
        Me.grvChiTiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvChiTiet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvChiTiet.OptionsBehavior.Editable = False
        Me.grvChiTiet.OptionsLayout.Columns.AddNewColumns = False
        Me.grvChiTiet.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvChiTiet.OptionsView.ColumnAutoWidth = False
        Me.grvChiTiet.OptionsView.EnableAppearanceEvenRow = True
        Me.grvChiTiet.OptionsView.EnableAppearanceOddRow = True
        Me.grvChiTiet.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdChiTiet
        Me.GridView2.Name = "GridView2"
        '
        'BtnSua
        '
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(908, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(98, 30)
        Me.BtnSua.TabIndex = 9
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(1202, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(98, 30)
        Me.BtnThoat.TabIndex = 12
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnGhi
        '
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(1006, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(98, 30)
        Me.BtnGhi.TabIndex = 14
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(1104, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(98, 30)
        Me.BtnKhongghi.TabIndex = 15
        Me.BtnKhongghi.Text = "&Không"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(297, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 47)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.optChon, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainerControl1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1306, 729)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'optChon
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.optChon, 3)
        Me.optChon.EditValue = "optALL"
        Me.optChon.Location = New System.Drawing.Point(3, 40)
        Me.optChon.Name = "optChon"
        Me.optChon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.optChon.Properties.Appearance.Options.UseBackColor = True
        Me.optChon.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("optALL", "optALL"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optForm", "optForm"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optReport", "optReport")})
        Me.optChon.Size = New System.Drawing.Size(351, 29)
        Me.optChon.TabIndex = 53
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblReplay, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtChuoi, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtReplay, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnReplay, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.optCapNhap, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDKien, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(360, 40)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(943, 29)
        Me.TableLayoutPanel2.TabIndex = 15
        '
        'lblReplay
        '
        Me.lblReplay.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblReplay.Appearance.Options.UseForeColor = True
        Me.lblReplay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblReplay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReplay.Location = New System.Drawing.Point(273, 3)
        Me.lblReplay.Name = "lblReplay"
        Me.lblReplay.Size = New System.Drawing.Size(84, 19)
        Me.lblReplay.TabIndex = 67
        Me.lblReplay.Text = "lblReplay"
        '
        'txtChuoi
        '
        Me.txtChuoi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChuoi.Location = New System.Drawing.Point(644, 3)
        Me.txtChuoi.Name = "txtChuoi"
        Me.txtChuoi.Size = New System.Drawing.Size(185, 20)
        Me.txtChuoi.TabIndex = 16
        '
        'txtReplay
        '
        Me.txtReplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtReplay.Location = New System.Drawing.Point(363, 3)
        Me.txtReplay.Name = "txtReplay"
        Me.txtReplay.Size = New System.Drawing.Size(185, 20)
        Me.txtReplay.TabIndex = 15
        '
        'btnReplay
        '
        Me.btnReplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnReplay.Location = New System.Drawing.Point(835, 3)
        Me.btnReplay.Name = "btnReplay"
        Me.btnReplay.Size = New System.Drawing.Size(105, 23)
        Me.btnReplay.TabIndex = 17
        Me.btnReplay.Text = "Replay"
        '
        'optCapNhap
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.optCapNhap, 3)
        Me.optCapNhap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.optCapNhap.EditValue = "optALL"
        Me.optCapNhap.Location = New System.Drawing.Point(3, 3)
        Me.optCapNhap.Name = "optCapNhap"
        Me.optCapNhap.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.optCapNhap.Properties.Appearance.Options.UseBackColor = True
        Me.optCapNhap.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("optALL", "optALL"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optViet", "optViet"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optAnh", "optAnh")})
        Me.optCapNhap.Size = New System.Drawing.Size(264, 23)
        Me.optCapNhap.TabIndex = 53
        '
        'lblDKien
        '
        Me.lblDKien.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblDKien.Appearance.Options.UseForeColor = True
        Me.lblDKien.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDKien.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDKien.Location = New System.Drawing.Point(554, 3)
        Me.lblDKien.Name = "lblDKien"
        Me.lblDKien.Size = New System.Drawing.Size(84, 19)
        Me.lblDKien.TabIndex = 67
        Me.lblDKien.Text = "lblDKien"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(1243, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(60, 31)
        Me.TableLayoutPanel3.TabIndex = 17
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(31, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(28, 29)
        Me.btnVideo.TabIndex = 102
        Me.btnVideo.Tag = "CMMS!frmLanguage"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 29)
        Me.btnHelp.TabIndex = 101
        Me.btnHelp.Tag = "CMMS!frmLanguage"
        '
        'SplitContainerControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.SplitContainerControl1, 4)
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(3, 75)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.grpDanhsachform)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.grpThongtinchitiet)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1300, 615)
        Me.SplitContainerControl1.SplitterPosition = 352
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.chkChinhXac)
        Me.Panel1.Controls.Add(Me.btnNNGoc)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.txtTim)
        Me.Panel1.Controls.Add(Me.txtTK)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 696)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1300, 30)
        Me.Panel1.TabIndex = 3
        '
        'chkChinhXac
        '
        Me.chkChinhXac.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkChinhXac.Location = New System.Drawing.Point(277, 12)
        Me.chkChinhXac.Name = "chkChinhXac"
        Me.chkChinhXac.Properties.Caption = "chkChinhXac"
        Me.chkChinhXac.Size = New System.Drawing.Size(75, 18)
        Me.chkChinhXac.TabIndex = 20
        '
        'btnNNGoc
        '
        Me.btnNNGoc.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnNNGoc.Location = New System.Drawing.Point(810, 0)
        Me.btnNNGoc.Name = "btnNNGoc"
        Me.btnNNGoc.Size = New System.Drawing.Size(98, 30)
        Me.btnNNGoc.TabIndex = 16
        Me.btnNNGoc.Text = "&NNGoc"
        '
        'txtTim
        '
        Me.txtTim.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTim.Location = New System.Drawing.Point(357, 10)
        Me.txtTim.Name = "txtTim"
        Me.txtTim.Size = New System.Drawing.Size(160, 20)
        Me.txtTim.TabIndex = 14
        '
        'txtTK
        '
        Me.txtTK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTK.Location = New System.Drawing.Point(3, 10)
        Me.txtTK.Name = "txtTK"
        Me.txtTK.Size = New System.Drawing.Size(144, 20)
        Me.txtTK.TabIndex = 14
        '
        'frmLanguage
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1306, 729)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimumSize = New System.Drawing.Size(686, 482)
        Me.Name = "frmLanguage"
        Me.Text = "Ngôn ngữ"
        Me.grpDanhsachform.ResumeLayout(False)
        CType(Me.grdForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpThongtinchitiet.ResumeLayout(False)
        CType(Me.grdChiTiet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChiTiet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.optChon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.txtChuoi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optCapNhap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.chkChinhXac.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTim.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDanhsachform As System.Windows.Forms.GroupBox
    Friend WithEvents grpThongtinchitiet As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtTK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtChuoi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnReplay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtReplay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnNNGoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdForm As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvForm As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtTim As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grdChiTiet As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChiTiet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents optChon As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents optCapNhap As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lblReplay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDKien As DevExpress.XtraEditors.LabelControl
    Private WithEvents chkChinhXac As DevExpress.XtraEditors.CheckEdit
End Class
