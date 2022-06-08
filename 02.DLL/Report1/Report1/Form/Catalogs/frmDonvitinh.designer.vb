<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDonvitinh
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachdonvitinh = New System.Windows.Forms.GroupBox()
        Me.GrdDanhsachloaivattu = New System.Windows.Forms.DataGridView()
        Me.GrpNhapdonvitinh = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblMadonvitinh = New System.Windows.Forms.Label()
        Me.txtDVT_CHINA = New Commons.utcTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtMadonvitinh = New Commons.utcTextBox()
        Me.lblDVT_CHINA = New System.Windows.Forms.Label()
        Me.lblDVT_VN = New System.Windows.Forms.Label()
        Me.txtDVT_EN = New Commons.utcTextBox()
        Me.txtDVT_VN = New Commons.utcTextBox()
        Me.lblDVT_EN = New System.Windows.Forms.Label()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachdonvitinh.SuspendLayout()
        CType(Me.GrdDanhsachloaivattu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpNhapdonvitinh.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtDVT_CHINA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMadonvitinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDVT_EN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDVT_VN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSua
        '
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSua.Appearance.Options.UseFont = True
        Me.BtnSua.Appearance.Options.UseForeColor = True
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(336, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(98, 32)
        Me.BtnSua.TabIndex = 5
        Me.BtnSua.Text = "&Sửa"
        '
        'BtnThoat
        '
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Appearance.Options.UseFont = True
        Me.BtnThoat.Appearance.Options.UseForeColor = True
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(630, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(98, 32)
        Me.BtnThoat.TabIndex = 7
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnXoa.Appearance.Options.UseFont = True
        Me.BtnXoa.Appearance.Options.UseForeColor = True
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Location = New System.Drawing.Point(434, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(98, 32)
        Me.BtnXoa.TabIndex = 6
        Me.BtnXoa.Text = "&Xóa"
        '
        'GrpDanhsachdonvitinh
        '
        Me.GrpDanhsachdonvitinh.Controls.Add(Me.GrdDanhsachloaivattu)
        Me.GrpDanhsachdonvitinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhsachdonvitinh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDanhsachdonvitinh.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachdonvitinh.Location = New System.Drawing.Point(0, 0)
        Me.GrpDanhsachdonvitinh.Name = "GrpDanhsachdonvitinh"
        Me.GrpDanhsachdonvitinh.Size = New System.Drawing.Size(380, 380)
        Me.GrpDanhsachdonvitinh.TabIndex = 36
        Me.GrpDanhsachdonvitinh.TabStop = False
        Me.GrpDanhsachdonvitinh.Text = "Danh sách đơn vị tính"
        '
        'GrdDanhsachloaivattu
        '
        Me.GrdDanhsachloaivattu.AllowUserToAddRows = False
        Me.GrdDanhsachloaivattu.AllowUserToDeleteRows = False
        Me.GrdDanhsachloaivattu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDanhsachloaivattu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhsachloaivattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDanhsachloaivattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsachloaivattu.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.GrdDanhsachloaivattu.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsachloaivattu.MultiSelect = False
        Me.GrdDanhsachloaivattu.Name = "GrdDanhsachloaivattu"
        Me.GrdDanhsachloaivattu.ReadOnly = True
        Me.GrdDanhsachloaivattu.RowHeadersWidth = 25
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.Format = "N2"
        Me.GrdDanhsachloaivattu.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GrdDanhsachloaivattu.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrdDanhsachloaivattu.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrdDanhsachloaivattu.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrdDanhsachloaivattu.Size = New System.Drawing.Size(374, 359)
        Me.GrdDanhsachloaivattu.TabIndex = 3
        '
        'GrpNhapdonvitinh
        '
        Me.GrpNhapdonvitinh.Controls.Add(Me.TableLayoutPanel2)
        Me.GrpNhapdonvitinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpNhapdonvitinh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNhapdonvitinh.ForeColor = System.Drawing.Color.Maroon
        Me.GrpNhapdonvitinh.Location = New System.Drawing.Point(0, 0)
        Me.GrpNhapdonvitinh.Name = "GrpNhapdonvitinh"
        Me.GrpNhapdonvitinh.Size = New System.Drawing.Size(344, 380)
        Me.GrpNhapdonvitinh.TabIndex = 35
        Me.GrpNhapdonvitinh.TabStop = False
        Me.GrpNhapdonvitinh.Text = "Nhập đơn vị tính"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LblMadonvitinh, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDVT_CHINA, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TxtMadonvitinh, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDVT_CHINA, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDVT_VN, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDVT_EN, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDVT_VN, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDVT_EN, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(338, 359)
        Me.TableLayoutPanel2.TabIndex = 10
        '
        'LblMadonvitinh
        '
        Me.LblMadonvitinh.AutoSize = True
        Me.LblMadonvitinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblMadonvitinh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMadonvitinh.ForeColor = System.Drawing.Color.Black
        Me.LblMadonvitinh.Location = New System.Drawing.Point(3, 0)
        Me.LblMadonvitinh.Name = "LblMadonvitinh"
        Me.LblMadonvitinh.Size = New System.Drawing.Size(127, 30)
        Me.LblMadonvitinh.TabIndex = 3
        Me.LblMadonvitinh.Text = "Mã số"
        Me.LblMadonvitinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDVT_CHINA
        '
        Me.txtDVT_CHINA.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDVT_CHINA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDVT_CHINA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDVT_CHINA.ErrorProviderControl = Me.ErrorProvider
        Me.txtDVT_CHINA.FieldName = ""
        Me.txtDVT_CHINA.IsNull = True
        Me.txtDVT_CHINA.Location = New System.Drawing.Point(141, 96)
        Me.txtDVT_CHINA.Margin = New System.Windows.Forms.Padding(8)
        Me.txtDVT_CHINA.MaxLength = 0
        Me.txtDVT_CHINA.Multiline = False
        Me.txtDVT_CHINA.Name = "txtDVT_CHINA"
        Me.txtDVT_CHINA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDVT_CHINA.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDVT_CHINA.Properties.Appearance.Options.UseBackColor = True
        Me.txtDVT_CHINA.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDVT_CHINA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDVT_CHINA.Properties.ReadOnly = True
        Me.txtDVT_CHINA.ReadOnly = True
        Me.txtDVT_CHINA.Size = New System.Drawing.Size(189, 20)
        Me.txtDVT_CHINA.TabIndex = 9
        Me.txtDVT_CHINA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDVT_CHINA.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtMadonvitinh
        '
        Me.TxtMadonvitinh.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TxtMadonvitinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtMadonvitinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtMadonvitinh.ErrorProviderControl = Me.ErrorProvider
        Me.TxtMadonvitinh.FieldName = ""
        Me.TxtMadonvitinh.IsNull = False
        Me.TxtMadonvitinh.Location = New System.Drawing.Point(141, 8)
        Me.TxtMadonvitinh.Margin = New System.Windows.Forms.Padding(8)
        Me.TxtMadonvitinh.MaxLength = 0
        Me.TxtMadonvitinh.Multiline = False
        Me.TxtMadonvitinh.Name = "TxtMadonvitinh"
        Me.TxtMadonvitinh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtMadonvitinh.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMadonvitinh.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMadonvitinh.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtMadonvitinh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TxtMadonvitinh.Properties.ReadOnly = True
        Me.TxtMadonvitinh.ReadOnly = True
        Me.TxtMadonvitinh.Size = New System.Drawing.Size(189, 20)
        Me.TxtMadonvitinh.TabIndex = 1
        Me.TxtMadonvitinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtMadonvitinh.TextTypeMode = Commons.TypeMode.None
        '
        'lblDVT_CHINA
        '
        Me.lblDVT_CHINA.AutoSize = True
        Me.lblDVT_CHINA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDVT_CHINA.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblDVT_CHINA.ForeColor = System.Drawing.Color.Black
        Me.lblDVT_CHINA.Location = New System.Drawing.Point(3, 88)
        Me.lblDVT_CHINA.Name = "lblDVT_CHINA"
        Me.lblDVT_CHINA.Size = New System.Drawing.Size(127, 29)
        Me.lblDVT_CHINA.TabIndex = 8
        Me.lblDVT_CHINA.Text = "Tên tiếng Hoa"
        Me.lblDVT_CHINA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDVT_VN
        '
        Me.lblDVT_VN.AutoSize = True
        Me.lblDVT_VN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDVT_VN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDVT_VN.ForeColor = System.Drawing.Color.Black
        Me.lblDVT_VN.Location = New System.Drawing.Point(3, 30)
        Me.lblDVT_VN.Name = "lblDVT_VN"
        Me.lblDVT_VN.Size = New System.Drawing.Size(127, 28)
        Me.lblDVT_VN.TabIndex = 5
        Me.lblDVT_VN.Text = "Tên tiếng Việt"
        Me.lblDVT_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDVT_EN
        '
        Me.txtDVT_EN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDVT_EN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDVT_EN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDVT_EN.ErrorProviderControl = Me.ErrorProvider
        Me.txtDVT_EN.FieldName = ""
        Me.txtDVT_EN.IsNull = True
        Me.txtDVT_EN.Location = New System.Drawing.Point(141, 66)
        Me.txtDVT_EN.Margin = New System.Windows.Forms.Padding(8)
        Me.txtDVT_EN.MaxLength = 0
        Me.txtDVT_EN.Multiline = False
        Me.txtDVT_EN.Name = "txtDVT_EN"
        Me.txtDVT_EN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDVT_EN.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDVT_EN.Properties.Appearance.Options.UseBackColor = True
        Me.txtDVT_EN.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDVT_EN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDVT_EN.Properties.ReadOnly = True
        Me.txtDVT_EN.ReadOnly = True
        Me.txtDVT_EN.Size = New System.Drawing.Size(189, 20)
        Me.txtDVT_EN.TabIndex = 7
        Me.txtDVT_EN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDVT_EN.TextTypeMode = Commons.TypeMode.None
        '
        'txtDVT_VN
        '
        Me.txtDVT_VN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDVT_VN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDVT_VN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDVT_VN.ErrorProviderControl = Me.ErrorProvider
        Me.txtDVT_VN.FieldName = ""
        Me.txtDVT_VN.IsNull = False
        Me.txtDVT_VN.Location = New System.Drawing.Point(141, 38)
        Me.txtDVT_VN.Margin = New System.Windows.Forms.Padding(8)
        Me.txtDVT_VN.MaxLength = 0
        Me.txtDVT_VN.Multiline = False
        Me.txtDVT_VN.Name = "txtDVT_VN"
        Me.txtDVT_VN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDVT_VN.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDVT_VN.Properties.Appearance.Options.UseBackColor = True
        Me.txtDVT_VN.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDVT_VN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDVT_VN.Properties.ReadOnly = True
        Me.txtDVT_VN.ReadOnly = True
        Me.txtDVT_VN.Size = New System.Drawing.Size(189, 20)
        Me.txtDVT_VN.TabIndex = 2
        Me.txtDVT_VN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDVT_VN.TextTypeMode = Commons.TypeMode.None
        '
        'lblDVT_EN
        '
        Me.lblDVT_EN.AutoSize = True
        Me.lblDVT_EN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDVT_EN.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblDVT_EN.ForeColor = System.Drawing.Color.Black
        Me.lblDVT_EN.Location = New System.Drawing.Point(3, 58)
        Me.lblDVT_EN.Name = "lblDVT_EN"
        Me.lblDVT_EN.Size = New System.Drawing.Size(127, 30)
        Me.lblDVT_EN.TabIndex = 6
        Me.lblDVT_EN.Text = "Tên tiếng Anh"
        Me.lblDVT_EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnThem
        '
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnThem.Appearance.Options.UseFont = True
        Me.BtnThem.Appearance.Options.UseForeColor = True
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Location = New System.Drawing.Point(140, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(98, 32)
        Me.BtnThem.TabIndex = 4
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnGhi
        '
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnGhi.Appearance.Options.UseFont = True
        Me.BtnGhi.Appearance.Options.UseForeColor = True
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(238, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(98, 32)
        Me.BtnGhi.TabIndex = 8
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = True
        Me.BtnKhongghi.Appearance.Options.UseForeColor = True
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(532, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(98, 32)
        Me.BtnKhongghi.TabIndex = 9
        Me.BtnKhongghi.Text = "&Không"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 40)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GrpDanhsachdonvitinh)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GrpNhapdonvitinh)
        Me.SplitContainer1.Size = New System.Drawing.Size(728, 380)
        Me.SplitContainer1.SplitterDistance = 380
        Me.SplitContainer1.TabIndex = 44
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 380)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 426)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 32)
        Me.Panel1.TabIndex = 45
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 46
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel3.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(676, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(55, 31)
        Me.TableLayoutPanel3.TabIndex = 46
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(28, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(26, 29)
        Me.btnVideo.TabIndex = 101
        Me.btnVideo.Tag = "CMMS!frmDonvitinh"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(25, 29)
        Me.btnHelp.TabIndex = 100
        Me.btnHelp.Tag = "CMMS!frmDonvitinh"
        '
        'frmDonvitinh
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDonvitinh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đơn vị tính"
        Me.GrpDanhsachdonvitinh.ResumeLayout(False)
        CType(Me.GrdDanhsachloaivattu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpNhapdonvitinh.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.txtDVT_CHINA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMadonvitinh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDVT_EN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDVT_VN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachdonvitinh As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsachloaivattu As System.Windows.Forms.DataGridView
    Friend WithEvents GrpNhapdonvitinh As System.Windows.Forms.GroupBox
    Friend WithEvents LblMadonvitinh As System.Windows.Forms.Label
    Friend WithEvents lblDVT_VN As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDVT_VN As Commons.utcTextBox
    Friend WithEvents TxtMadonvitinh As Commons.utcTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtDVT_CHINA As Commons.utcTextBox
    Friend WithEvents lblDVT_CHINA As System.Windows.Forms.Label
    Friend WithEvents txtDVT_EN As Commons.utcTextBox
    Friend WithEvents lblDVT_EN As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
End Class
