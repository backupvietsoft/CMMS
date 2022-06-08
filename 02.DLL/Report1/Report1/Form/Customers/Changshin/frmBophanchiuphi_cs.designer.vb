<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBophanchiuphi_cs
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTieuDe = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpNganSach = New System.Windows.Forms.GroupBox()
        Me.grdNganSach = New System.Windows.Forms.DataGridView()
        Me.grpDanhSach = New System.Windows.Forms.GroupBox()
        Me.grdDanhSach = New System.Windows.Forms.DataGridView()
        Me.grpThongTin = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblGHI_CHU = New System.Windows.Forms.Label()
        Me.txtTEN_BP_CHIU_PHI = New Commons.utcTextBox()
        Me.lblTEN_BP_CHIU_PHI = New System.Windows.Forms.Label()
        Me.cmbMSDV = New Commons.UtcComboBox()
        Me.txtGHI_CHU = New Commons.utcTextBox()
        Me.lblMSDV = New System.Windows.Forms.Label()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.lblQuyDoi = New System.Windows.Forms.Label()
        Me.lblCurrencyValue = New System.Windows.Forms.Label()
        Me.btnXOA_DANH_SACH = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXOA_NGAN_SACH = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTRO_VE = New DevExpress.XtraEditors.SimpleButton()
        Me.lblOLD_TEN_BP_CP = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMS_BP_CHIU_PHI = New Commons.utcTextBox()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNganSach.SuspendLayout()
        CType(Me.grdNganSach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhSach.SuspendLayout()
        CType(Me.grdDanhSach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpThongTin.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtTEN_BP_CHIU_PHI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGHI_CHU.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtMS_BP_CHIU_PHI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieuDe
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieuDe, 2)
        Me.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieuDe.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTieuDe.Location = New System.Drawing.Point(3, 0)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(786, 47)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "BỘ PHẬN CHỊU PHÍ"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'grpNganSach
        '
        Me.grpNganSach.Controls.Add(Me.grdNganSach)
        Me.grpNganSach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNganSach.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNganSach.ForeColor = System.Drawing.Color.Maroon
        Me.grpNganSach.Location = New System.Drawing.Point(253, 162)
        Me.grpNganSach.Name = "grpNganSach"
        Me.grpNganSach.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grpNganSach.Size = New System.Drawing.Size(536, 325)
        Me.grpNganSach.TabIndex = 12
        Me.grpNganSach.TabStop = False
        Me.grpNganSach.Text = "Ngân sách phân bổ"
        '
        'grdNganSach
        '
        Me.grdNganSach.AllowUserToAddRows = False
        Me.grdNganSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdNganSach.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdNganSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNganSach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNganSach.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.grdNganSach.Location = New System.Drawing.Point(3, 21)
        Me.grdNganSach.MultiSelect = False
        Me.grdNganSach.Name = "grdNganSach"
        Me.grdNganSach.ReadOnly = True
        Me.grdNganSach.RowHeadersWidth = 25
        Me.grdNganSach.Size = New System.Drawing.Size(530, 301)
        Me.grdNganSach.TabIndex = 13
        '
        'grpDanhSach
        '
        Me.grpDanhSach.Controls.Add(Me.grdDanhSach)
        Me.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhSach.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDanhSach.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhSach.Location = New System.Drawing.Point(3, 50)
        Me.grpDanhSach.Name = "grpDanhSach"
        Me.grpDanhSach.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.TableLayoutPanel1.SetRowSpan(Me.grpDanhSach, 2)
        Me.grpDanhSach.Size = New System.Drawing.Size(244, 437)
        Me.grpDanhSach.TabIndex = 1
        Me.grpDanhSach.TabStop = False
        Me.grpDanhSach.Text = "Danh sách"
        '
        'grdDanhSach
        '
        Me.grdDanhSach.AllowUserToAddRows = False
        Me.grdDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhSach.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhSach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhSach.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.grdDanhSach.Location = New System.Drawing.Point(3, 21)
        Me.grdDanhSach.MultiSelect = False
        Me.grdDanhSach.Name = "grdDanhSach"
        Me.grdDanhSach.ReadOnly = True
        Me.grdDanhSach.RowHeadersWidth = 25
        Me.grdDanhSach.Size = New System.Drawing.Size(238, 413)
        Me.grdDanhSach.TabIndex = 2
        Me.grdDanhSach.TabStop = False
        '
        'grpThongTin
        '
        Me.grpThongTin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpThongTin.Controls.Add(Me.TableLayoutPanel2)
        Me.grpThongTin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpThongTin.ForeColor = System.Drawing.Color.Maroon
        Me.grpThongTin.Location = New System.Drawing.Point(253, 50)
        Me.grpThongTin.Name = "grpThongTin"
        Me.grpThongTin.Size = New System.Drawing.Size(536, 106)
        Me.grpThongTin.TabIndex = 3
        Me.grpThongTin.TabStop = False
        Me.grpThongTin.Text = "Thông tin chung"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblGHI_CHU, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTEN_BP_CHIU_PHI, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTEN_BP_CHIU_PHI, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbMSDV, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtGHI_CHU, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMSDV, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(530, 85)
        Me.TableLayoutPanel2.TabIndex = 12
        '
        'lblGHI_CHU
        '
        Me.lblGHI_CHU.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGHI_CHU.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGHI_CHU.ForeColor = System.Drawing.Color.Black
        Me.lblGHI_CHU.Location = New System.Drawing.Point(3, 56)
        Me.lblGHI_CHU.Name = "lblGHI_CHU"
        Me.lblGHI_CHU.Size = New System.Drawing.Size(114, 26)
        Me.lblGHI_CHU.TabIndex = 10
        Me.lblGHI_CHU.Text = "Ghi chú"
        Me.lblGHI_CHU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTEN_BP_CHIU_PHI
        '
        Me.txtTEN_BP_CHIU_PHI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTEN_BP_CHIU_PHI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTEN_BP_CHIU_PHI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTEN_BP_CHIU_PHI.ErrorProviderControl = Me.ErrorProvider
        Me.txtTEN_BP_CHIU_PHI.FieldName = ""
        Me.txtTEN_BP_CHIU_PHI.IsNull = False
        Me.txtTEN_BP_CHIU_PHI.Location = New System.Drawing.Point(123, 3)
        Me.txtTEN_BP_CHIU_PHI.MaxLength = 0
        Me.txtTEN_BP_CHIU_PHI.Multiline = False
        Me.txtTEN_BP_CHIU_PHI.Name = "txtTEN_BP_CHIU_PHI"
        Me.txtTEN_BP_CHIU_PHI.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTEN_BP_CHIU_PHI.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTEN_BP_CHIU_PHI.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTEN_BP_CHIU_PHI.Properties.Appearance.Options.UseBackColor = True
        Me.txtTEN_BP_CHIU_PHI.Properties.Appearance.Options.UseFont = True
        Me.txtTEN_BP_CHIU_PHI.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTEN_BP_CHIU_PHI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTEN_BP_CHIU_PHI.Properties.ReadOnly = True
        Me.txtTEN_BP_CHIU_PHI.ReadOnly = True
        Me.txtTEN_BP_CHIU_PHI.Size = New System.Drawing.Size(404, 21)
        Me.txtTEN_BP_CHIU_PHI.TabIndex = 5
        Me.txtTEN_BP_CHIU_PHI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTEN_BP_CHIU_PHI.TextTypeMode = Commons.TypeMode.None
        '
        'lblTEN_BP_CHIU_PHI
        '
        Me.lblTEN_BP_CHIU_PHI.AutoSize = True
        Me.lblTEN_BP_CHIU_PHI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTEN_BP_CHIU_PHI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTEN_BP_CHIU_PHI.ForeColor = System.Drawing.Color.Black
        Me.lblTEN_BP_CHIU_PHI.Location = New System.Drawing.Point(3, 0)
        Me.lblTEN_BP_CHIU_PHI.Name = "lblTEN_BP_CHIU_PHI"
        Me.lblTEN_BP_CHIU_PHI.Size = New System.Drawing.Size(114, 28)
        Me.lblTEN_BP_CHIU_PHI.TabIndex = 4
        Me.lblTEN_BP_CHIU_PHI.Text = "Tên bộ phận"
        Me.lblTEN_BP_CHIU_PHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMSDV
        '
        Me.cmbMSDV.AssemblyName = ""
        Me.cmbMSDV.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMSDV.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmbMSDV.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbMSDV.ClassName = ""
        Me.cmbMSDV.Display = ""
        Me.cmbMSDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbMSDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMSDV.ErrorProviderControl = Me.ErrorProvider
        Me.cmbMSDV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMSDV.FormattingEnabled = True
        Me.cmbMSDV.IsAll = False
        Me.cmbMSDV.isInputNull = False
        Me.cmbMSDV.IsNew = True
        Me.cmbMSDV.IsNull = True
        Me.cmbMSDV.ItemAll = " < ALL > "
        Me.cmbMSDV.ItemNew = "...New"
        Me.cmbMSDV.Location = New System.Drawing.Point(123, 31)
        Me.cmbMSDV.MethodName = ""
        Me.cmbMSDV.Name = "cmbMSDV"
        Me.cmbMSDV.Param = ""
        Me.cmbMSDV.Param2 = ""
        Me.cmbMSDV.Size = New System.Drawing.Size(404, 22)
        Me.cmbMSDV.StoreName = ""
        Me.cmbMSDV.TabIndex = 9
        Me.cmbMSDV.Table = Nothing
        Me.cmbMSDV.TextReadonly = False
        Me.cmbMSDV.Value = ""
        '
        'txtGHI_CHU
        '
        Me.txtGHI_CHU.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtGHI_CHU.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGHI_CHU.ErrorProviderControl = Me.ErrorProvider
        Me.txtGHI_CHU.FieldName = ""
        Me.txtGHI_CHU.IsNull = False
        Me.txtGHI_CHU.Location = New System.Drawing.Point(123, 59)
        Me.txtGHI_CHU.MaxLength = 0
        Me.txtGHI_CHU.Multiline = True
        Me.txtGHI_CHU.Name = "txtGHI_CHU"
        Me.txtGHI_CHU.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtGHI_CHU.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtGHI_CHU.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGHI_CHU.Properties.Appearance.Options.UseBackColor = True
        Me.txtGHI_CHU.Properties.Appearance.Options.UseFont = True
        Me.txtGHI_CHU.Properties.Appearance.Options.UseTextOptions = True
        Me.txtGHI_CHU.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtGHI_CHU.Properties.ReadOnly = True
        Me.txtGHI_CHU.ReadOnly = True
        Me.txtGHI_CHU.Size = New System.Drawing.Size(404, 21)
        Me.txtGHI_CHU.TabIndex = 11
        Me.txtGHI_CHU.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtGHI_CHU.TextTypeMode = Commons.TypeMode.None
        '
        'lblMSDV
        '
        Me.lblMSDV.AutoSize = True
        Me.lblMSDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMSDV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSDV.ForeColor = System.Drawing.Color.Black
        Me.lblMSDV.Location = New System.Drawing.Point(3, 28)
        Me.lblMSDV.Name = "lblMSDV"
        Me.lblMSDV.Size = New System.Drawing.Size(114, 28)
        Me.lblMSDV.TabIndex = 8
        Me.lblMSDV.Text = "Đơn vị"
        Me.lblMSDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnGhi
        '
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(626, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(80, 26)
        Me.BtnGhi.TabIndex = 18
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(706, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(80, 26)
        Me.BtnKhongghi.TabIndex = 19
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnSua
        '
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(56, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(80, 26)
        Me.BtnSua.TabIndex = 15
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(216, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(80, 26)
        Me.BtnThoat.TabIndex = 17
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Location = New System.Drawing.Point(136, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(80, 26)
        Me.BtnXoa.TabIndex = 16
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.Visible = False
        '
        'BtnThem
        '
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Location = New System.Drawing.Point(-24, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(80, 26)
        Me.BtnThem.TabIndex = 14
        Me.BtnThem.Text = "&Thêm"
        '
        'lblQuyDoi
        '
        Me.lblQuyDoi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblQuyDoi.AutoSize = True
        Me.lblQuyDoi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuyDoi.ForeColor = System.Drawing.Color.Red
        Me.lblQuyDoi.Location = New System.Drawing.Point(688, 234)
        Me.lblQuyDoi.Name = "lblQuyDoi"
        Me.lblQuyDoi.Size = New System.Drawing.Size(118, 14)
        Me.lblQuyDoi.TabIndex = 12
        Me.lblQuyDoi.Text = "Đồng tiền quy đổi"
        Me.lblQuyDoi.Visible = False
        '
        'lblCurrencyValue
        '
        Me.lblCurrencyValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCurrencyValue.AutoSize = True
        Me.lblCurrencyValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyValue.ForeColor = System.Drawing.Color.Navy
        Me.lblCurrencyValue.Location = New System.Drawing.Point(564, 234)
        Me.lblCurrencyValue.Name = "lblCurrencyValue"
        Me.lblCurrencyValue.Size = New System.Drawing.Size(118, 14)
        Me.lblCurrencyValue.TabIndex = 21
        Me.lblCurrencyValue.Text = "Đồng tiền quy đổi"
        '
        'btnXOA_DANH_SACH
        '
        Me.btnXOA_DANH_SACH.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXOA_DANH_SACH.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnXOA_DANH_SACH.Appearance.Options.UseFont = True
        Me.btnXOA_DANH_SACH.Appearance.Options.UseForeColor = True
        Me.btnXOA_DANH_SACH.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnXOA_DANH_SACH.Location = New System.Drawing.Point(296, 0)
        Me.btnXOA_DANH_SACH.Name = "btnXOA_DANH_SACH"
        Me.btnXOA_DANH_SACH.Size = New System.Drawing.Size(110, 26)
        Me.btnXOA_DANH_SACH.TabIndex = 22
        Me.btnXOA_DANH_SACH.Text = "Xóa danh sách"
        '
        'btnXOA_NGAN_SACH
        '
        Me.btnXOA_NGAN_SACH.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXOA_NGAN_SACH.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnXOA_NGAN_SACH.Appearance.Options.UseFont = True
        Me.btnXOA_NGAN_SACH.Appearance.Options.UseForeColor = True
        Me.btnXOA_NGAN_SACH.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnXOA_NGAN_SACH.Location = New System.Drawing.Point(406, 0)
        Me.btnXOA_NGAN_SACH.Name = "btnXOA_NGAN_SACH"
        Me.btnXOA_NGAN_SACH.Size = New System.Drawing.Size(110, 26)
        Me.btnXOA_NGAN_SACH.TabIndex = 23
        Me.btnXOA_NGAN_SACH.Text = "Xóa ngân sách"
        '
        'btnTRO_VE
        '
        Me.btnTRO_VE.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTRO_VE.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnTRO_VE.Appearance.Options.UseFont = True
        Me.btnTRO_VE.Appearance.Options.UseForeColor = True
        Me.btnTRO_VE.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnTRO_VE.Location = New System.Drawing.Point(516, 0)
        Me.btnTRO_VE.Name = "btnTRO_VE"
        Me.btnTRO_VE.Size = New System.Drawing.Size(110, 26)
        Me.btnTRO_VE.TabIndex = 24
        Me.btnTRO_VE.Text = "Trở về"
        '
        'lblOLD_TEN_BP_CP
        '
        Me.lblOLD_TEN_BP_CP.AutoSize = True
        Me.lblOLD_TEN_BP_CP.Location = New System.Drawing.Point(71, 24)
        Me.lblOLD_TEN_BP_CP.Name = "lblOLD_TEN_BP_CP"
        Me.lblOLD_TEN_BP_CP.Size = New System.Drawing.Size(89, 13)
        Me.lblOLD_TEN_BP_CP.TabIndex = 25
        Me.lblOLD_TEN_BP_CP.Text = "OLD_TEN_BP_CP"
        Me.lblOLD_TEN_BP_CP.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhSach, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpNganSach, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grpThongTin, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieuDe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(792, 522)
        Me.TableLayoutPanel1.TabIndex = 26
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.btnXOA_DANH_SACH)
        Me.Panel1.Controls.Add(Me.btnXOA_NGAN_SACH)
        Me.Panel1.Controls.Add(Me.btnTRO_VE)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 493)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 26)
        Me.Panel1.TabIndex = 13
        '
        'txtMS_BP_CHIU_PHI
        '
        Me.txtMS_BP_CHIU_PHI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMS_BP_CHIU_PHI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMS_BP_CHIU_PHI.ErrorProviderControl = Me.ErrorProvider
        Me.txtMS_BP_CHIU_PHI.FieldName = ""
        Me.txtMS_BP_CHIU_PHI.IsNull = True
        Me.txtMS_BP_CHIU_PHI.Location = New System.Drawing.Point(42, 22)
        Me.txtMS_BP_CHIU_PHI.MaxLength = 0
        Me.txtMS_BP_CHIU_PHI.Multiline = False
        Me.txtMS_BP_CHIU_PHI.Name = "txtMS_BP_CHIU_PHI"
        Me.txtMS_BP_CHIU_PHI.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMS_BP_CHIU_PHI.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMS_BP_CHIU_PHI.Properties.Appearance.Options.UseBackColor = True
        Me.txtMS_BP_CHIU_PHI.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMS_BP_CHIU_PHI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMS_BP_CHIU_PHI.Properties.ReadOnly = True
        Me.txtMS_BP_CHIU_PHI.ReadOnly = True
        Me.txtMS_BP_CHIU_PHI.Size = New System.Drawing.Size(13, 20)
        Me.txtMS_BP_CHIU_PHI.TabIndex = 0
        Me.txtMS_BP_CHIU_PHI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMS_BP_CHIU_PHI.TextTypeMode = Commons.TypeMode.None
        Me.txtMS_BP_CHIU_PHI.Visible = False
        '
        'frmBophanchiuphi_cs
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 522)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblOLD_TEN_BP_CP)
        Me.Controls.Add(Me.lblCurrencyValue)
        Me.Controls.Add(Me.lblQuyDoi)
        Me.Controls.Add(Me.txtMS_BP_CHIU_PHI)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(798, 550)
        Me.Name = "frmBophanchiuphi_cs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bộ phận chịu phí"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNganSach.ResumeLayout(False)
        CType(Me.grdNganSach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhSach.ResumeLayout(False)
        CType(Me.grdDanhSach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpThongTin.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.txtTEN_BP_CHIU_PHI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGHI_CHU.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtMS_BP_CHIU_PHI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents txtMS_BP_CHIU_PHI As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpThongTin As System.Windows.Forms.GroupBox
    Friend WithEvents grpDanhSach As System.Windows.Forms.GroupBox
    Friend WithEvents grpNganSach As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtTEN_BP_CHIU_PHI As Commons.utcTextBox
    Friend WithEvents lblTEN_BP_CHIU_PHI As System.Windows.Forms.Label
    Friend WithEvents txtGHI_CHU As Commons.utcTextBox
    Friend WithEvents lblGHI_CHU As System.Windows.Forms.Label
    Friend WithEvents cmbMSDV As Commons.UtcComboBox
    Friend WithEvents lblMSDV As System.Windows.Forms.Label
    Friend WithEvents grdDanhSach As System.Windows.Forms.DataGridView
    Friend WithEvents grdNganSach As System.Windows.Forms.DataGridView
    Friend WithEvents lblQuyDoi As System.Windows.Forms.Label
    Friend WithEvents lblCurrencyValue As System.Windows.Forms.Label
    Friend WithEvents btnXOA_DANH_SACH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTRO_VE As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXOA_NGAN_SACH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblOLD_TEN_BP_CP As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
End Class
