<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoaivattu
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.GrpDanhsachloaivattu = New System.Windows.Forms.GroupBox()
        Me.GrdDanhsachloaivattu = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrLoaivattu = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.chkVatTu = New System.Windows.Forms.CheckBox()
        Me.lblDVT_VN = New System.Windows.Forms.Label()
        Me.txtDVT_CHINA = New Commons.utcTextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtDVT_VN = New Commons.utcTextBox()
        Me.lblDVT_CHINA = New System.Windows.Forms.Label()
        Me.lblDVT_EN = New System.Windows.Forms.Label()
        Me.txtDVT_EN = New Commons.utcTextBox()
        Me.BtnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMaLoaiVT = New Commons.utcTextBox()
        Me.GrpDanhsachloaivattu.SuspendLayout
        CType(Me.GrdDanhsachloaivattu,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GrLoaivattu.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        CType(Me.txtDVT_CHINA.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtDVT_VN.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtDVT_EN.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.Panel1.SuspendLayout
        CType(Me.txtMaLoaiVT.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'BtnSua
        '
        Me.BtnSua.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.BtnSua.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.BtnSua.Appearance.Options.UseFont = true
        Me.BtnSua.Appearance.Options.UseForeColor = true
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Location = New System.Drawing.Point(368, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(90, 32)
        Me.BtnSua.TabIndex = 38
        Me.BtnSua.Text = "&Sửa"
        '
        'GrpDanhsachloaivattu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrpDanhsachloaivattu, 2)
        Me.GrpDanhsachloaivattu.Controls.Add(Me.GrdDanhsachloaivattu)
        Me.GrpDanhsachloaivattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDanhsachloaivattu.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GrpDanhsachloaivattu.ForeColor = System.Drawing.Color.Maroon
        Me.GrpDanhsachloaivattu.Location = New System.Drawing.Point(3, 113)
        Me.GrpDanhsachloaivattu.Name = "GrpDanhsachloaivattu"
        Me.GrpDanhsachloaivattu.Size = New System.Drawing.Size(728, 307)
        Me.GrpDanhsachloaivattu.TabIndex = 44
        Me.GrpDanhsachloaivattu.TabStop = false
        Me.GrpDanhsachloaivattu.Text = "Danh sách lọai vật tư"
        '
        'GrdDanhsachloaivattu
        '
        Me.GrdDanhsachloaivattu.AllowUserToAddRows = false
        Me.GrdDanhsachloaivattu.AllowUserToDeleteRows = false
        Me.GrdDanhsachloaivattu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(206,Byte),Integer), CType(CType(228,Byte),Integer), CType(CType(253,Byte),Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.GrdDanhsachloaivattu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdDanhsachloaivattu.ColumnHeadersHeight = 25
        Me.GrdDanhsachloaivattu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.GrdDanhsachloaivattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDanhsachloaivattu.EnableHeadersVisualStyles = false
        Me.GrdDanhsachloaivattu.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.GrdDanhsachloaivattu.Location = New System.Drawing.Point(3, 18)
        Me.GrdDanhsachloaivattu.MultiSelect = false
        Me.GrdDanhsachloaivattu.Name = "GrdDanhsachloaivattu"
        Me.GrdDanhsachloaivattu.ReadOnly = true
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdDanhsachloaivattu.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GrdDanhsachloaivattu.RowHeadersWidth = 25
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.Format = "N2"
        Me.GrdDanhsachloaivattu.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.GrdDanhsachloaivattu.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrdDanhsachloaivattu.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrdDanhsachloaivattu.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrdDanhsachloaivattu.Size = New System.Drawing.Size(722, 286)
        Me.GrdDanhsachloaivattu.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = true
        '
        'GrLoaivattu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GrLoaivattu, 2)
        Me.GrLoaivattu.Controls.Add(Me.TableLayoutPanel2)
        Me.GrLoaivattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrLoaivattu.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GrLoaivattu.ForeColor = System.Drawing.Color.DarkRed
        Me.GrLoaivattu.Location = New System.Drawing.Point(3, 23)
        Me.GrLoaivattu.Name = "GrLoaivattu"
        Me.GrLoaivattu.Size = New System.Drawing.Size(728, 84)
        Me.GrLoaivattu.TabIndex = 43
        Me.GrLoaivattu.TabStop = false
        Me.GrLoaivattu.Text = "Nhập lọai vật tư"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.Controls.Add(Me.chkVatTu, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDVT_VN, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDVT_CHINA, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDVT_VN, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDVT_CHINA, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDVT_EN, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDVT_EN, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(722, 63)
        Me.TableLayoutPanel2.TabIndex = 46
        '
        'chkVatTu
        '
        Me.chkVatTu.AutoSize = true
        Me.chkVatTu.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TableLayoutPanel2.SetColumnSpan(Me.chkVatTu, 2)
        Me.chkVatTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkVatTu.ForeColor = System.Drawing.Color.Black
        Me.chkVatTu.Location = New System.Drawing.Point(364, 33)
        Me.chkVatTu.Name = "chkVatTu"
        Me.chkVatTu.Size = New System.Drawing.Size(355, 24)
        Me.chkVatTu.TabIndex = 11
        Me.chkVatTu.Text = "Vật tư"
        Me.chkVatTu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkVatTu.UseVisualStyleBackColor = true
        '
        'lblDVT_VN
        '
        Me.lblDVT_VN.AutoSize = true
        Me.lblDVT_VN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDVT_VN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDVT_VN.ForeColor = System.Drawing.Color.Black
        Me.lblDVT_VN.Location = New System.Drawing.Point(3, 0)
        Me.lblDVT_VN.Name = "lblDVT_VN"
        Me.lblDVT_VN.Size = New System.Drawing.Size(104, 30)
        Me.lblDVT_VN.TabIndex = 5
        Me.lblDVT_VN.Text = "Tên tiếng Việt"
        Me.lblDVT_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDVT_CHINA
        '
        Me.txtDVT_CHINA.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171,Byte),Integer), CType(CType(193,Byte),Integer), CType(CType(222,Byte),Integer))
        Me.txtDVT_CHINA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDVT_CHINA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDVT_CHINA.ErrorProviderControl = Me.ErrorProvider1
        Me.txtDVT_CHINA.FieldName = ""
        Me.txtDVT_CHINA.IsNull = true
        Me.txtDVT_CHINA.Location = New System.Drawing.Point(113, 33)
        Me.txtDVT_CHINA.MaxLength = 0
        Me.txtDVT_CHINA.Multiline = false
        Me.txtDVT_CHINA.Name = "txtDVT_CHINA"
        Me.txtDVT_CHINA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDVT_CHINA.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDVT_CHINA.Properties.Appearance.Options.UseBackColor = true
        Me.txtDVT_CHINA.Properties.Appearance.Options.UseTextOptions = true
        Me.txtDVT_CHINA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDVT_CHINA.Properties.ReadOnly = true
        Me.txtDVT_CHINA.ReadOnly = true
        Me.txtDVT_CHINA.Size = New System.Drawing.Size(245, 20)
        Me.txtDVT_CHINA.TabIndex = 9
        Me.txtDVT_CHINA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDVT_CHINA.TextTypeMode = Commons.TypeMode.None
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtDVT_VN
        '
        Me.txtDVT_VN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171,Byte),Integer), CType(CType(193,Byte),Integer), CType(CType(222,Byte),Integer))
        Me.txtDVT_VN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDVT_VN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDVT_VN.ErrorProviderControl = Me.ErrorProvider1
        Me.txtDVT_VN.FieldName = ""
        Me.txtDVT_VN.IsNull = false
        Me.txtDVT_VN.Location = New System.Drawing.Point(113, 3)
        Me.txtDVT_VN.MaxLength = 0
        Me.txtDVT_VN.Multiline = false
        Me.txtDVT_VN.Name = "txtDVT_VN"
        Me.txtDVT_VN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDVT_VN.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDVT_VN.Properties.Appearance.Options.UseBackColor = true
        Me.txtDVT_VN.Properties.Appearance.Options.UseTextOptions = true
        Me.txtDVT_VN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDVT_VN.Properties.ReadOnly = true
        Me.txtDVT_VN.ReadOnly = true
        Me.txtDVT_VN.Size = New System.Drawing.Size(245, 20)
        Me.txtDVT_VN.TabIndex = 2
        Me.txtDVT_VN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDVT_VN.TextTypeMode = Commons.TypeMode.None
        '
        'lblDVT_CHINA
        '
        Me.lblDVT_CHINA.AutoSize = true
        Me.lblDVT_CHINA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDVT_CHINA.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblDVT_CHINA.ForeColor = System.Drawing.Color.Black
        Me.lblDVT_CHINA.Location = New System.Drawing.Point(3, 30)
        Me.lblDVT_CHINA.Name = "lblDVT_CHINA"
        Me.lblDVT_CHINA.Size = New System.Drawing.Size(104, 30)
        Me.lblDVT_CHINA.TabIndex = 8
        Me.lblDVT_CHINA.Text = "Tên tiếng Hoa"
        Me.lblDVT_CHINA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDVT_EN
        '
        Me.lblDVT_EN.AutoSize = true
        Me.lblDVT_EN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDVT_EN.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblDVT_EN.ForeColor = System.Drawing.Color.Black
        Me.lblDVT_EN.Location = New System.Drawing.Point(364, 0)
        Me.lblDVT_EN.Name = "lblDVT_EN"
        Me.lblDVT_EN.Size = New System.Drawing.Size(104, 30)
        Me.lblDVT_EN.TabIndex = 6
        Me.lblDVT_EN.Text = "Tên tiếng Anh"
        Me.lblDVT_EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDVT_EN
        '
        Me.txtDVT_EN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171,Byte),Integer), CType(CType(193,Byte),Integer), CType(CType(222,Byte),Integer))
        Me.txtDVT_EN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtDVT_EN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDVT_EN.ErrorProviderControl = Me.ErrorProvider1
        Me.txtDVT_EN.FieldName = ""
        Me.txtDVT_EN.IsNull = true
        Me.txtDVT_EN.Location = New System.Drawing.Point(474, 3)
        Me.txtDVT_EN.MaxLength = 0
        Me.txtDVT_EN.Multiline = false
        Me.txtDVT_EN.Name = "txtDVT_EN"
        Me.txtDVT_EN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDVT_EN.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtDVT_EN.Properties.Appearance.Options.UseBackColor = true
        Me.txtDVT_EN.Properties.Appearance.Options.UseTextOptions = true
        Me.txtDVT_EN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDVT_EN.Properties.ReadOnly = true
        Me.txtDVT_EN.ReadOnly = true
        Me.txtDVT_EN.Size = New System.Drawing.Size(245, 20)
        Me.txtDVT_EN.TabIndex = 7
        Me.txtDVT_EN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDVT_EN.TextTypeMode = Commons.TypeMode.None
        '
        'BtnThem
        '
        Me.BtnThem.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.BtnThem.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.BtnThem.Appearance.Options.UseFont = true
        Me.BtnThem.Appearance.Options.UseForeColor = true
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Location = New System.Drawing.Point(178, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(100, 32)
        Me.BtnThem.TabIndex = 37
        Me.BtnThem.Text = "&Thêm"
        '
        'BtnThoat
        '
        Me.BtnThoat.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.BtnThoat.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnThoat.Appearance.Options.UseFont = true
        Me.BtnThoat.Appearance.Options.UseForeColor = true
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Location = New System.Drawing.Point(638, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(90, 32)
        Me.BtnThoat.TabIndex = 40
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.BtnKhongghi.Appearance.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Appearance.Options.UseFont = true
        Me.BtnKhongghi.Appearance.Options.UseForeColor = true
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Location = New System.Drawing.Point(548, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(90, 32)
        Me.BtnKhongghi.TabIndex = 42
        Me.BtnKhongghi.Text = "&Không"
        '
        'BtnXoa
        '
        Me.BtnXoa.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.BtnXoa.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.BtnXoa.Appearance.Options.UseFont = true
        Me.BtnXoa.Appearance.Options.UseForeColor = true
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Location = New System.Drawing.Point(458, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(90, 32)
        Me.BtnXoa.TabIndex = 39
        Me.BtnXoa.Text = "&Xóa"
        '
        'BtnGhi
        '
        Me.BtnGhi.Appearance.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Bold)
        Me.BtnGhi.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.BtnGhi.Appearance.Options.UseFont = true
        Me.BtnGhi.Appearance.Options.UseForeColor = true
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Location = New System.Drawing.Point(278, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(90, 32)
        Me.BtnGhi.TabIndex = 41
        Me.BtnGhi.Text = "&Ghi"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GrpDanhsachloaivattu, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GrLoaivattu, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 461)
        Me.TableLayoutPanel1.TabIndex = 45
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.txtMaLoaiVT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 426)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 32)
        Me.Panel1.TabIndex = 46
        '
        'txtMaLoaiVT
        '
        Me.txtMaLoaiVT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtMaLoaiVT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171,Byte),Integer), CType(CType(193,Byte),Integer), CType(CType(222,Byte),Integer))
        Me.txtMaLoaiVT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtMaLoaiVT.ErrorProviderControl = Me.ErrorProvider1
        Me.txtMaLoaiVT.FieldName = ""
        Me.txtMaLoaiVT.IsNull = true
        Me.txtMaLoaiVT.Location = New System.Drawing.Point(12, 13)
        Me.txtMaLoaiVT.MaxLength = 0
        Me.txtMaLoaiVT.Multiline = false
        Me.txtMaLoaiVT.Name = "txtMaLoaiVT"
        Me.txtMaLoaiVT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMaLoaiVT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtMaLoaiVT.Properties.Appearance.Options.UseBackColor = true
        Me.txtMaLoaiVT.Properties.Appearance.Options.UseTextOptions = true
        Me.txtMaLoaiVT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtMaLoaiVT.Properties.ReadOnly = true
        Me.txtMaLoaiVT.ReadOnly = true
        Me.txtMaLoaiVT.Size = New System.Drawing.Size(204, 20)
        Me.txtMaLoaiVT.TabIndex = 10
        Me.txtMaLoaiVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMaLoaiVT.TextTypeMode = Commons.TypeMode.None
        Me.txtMaLoaiVT.Visible = false
        '
        'frmLoaivattu
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Appearance.Options.UseFont = true
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = false
        Me.Name = "frmLoaivattu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLoaivattu"
        Me.GrpDanhsachloaivattu.ResumeLayout(false)
        CType(Me.GrdDanhsachloaivattu,System.ComponentModel.ISupportInitialize).EndInit
        Me.GrLoaivattu.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        CType(Me.txtDVT_CHINA.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtDVT_VN.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtDVT_EN.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.Panel1.ResumeLayout(false)
        CType(Me.txtMaLoaiVT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GrpDanhsachloaivattu As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDanhsachloaivattu As System.Windows.Forms.DataGridView
    Friend WithEvents GrLoaivattu As System.Windows.Forms.GroupBox
    Friend WithEvents txtDVT_CHINA As Commons.utcTextBox
    Friend WithEvents lblDVT_CHINA As System.Windows.Forms.Label
    Friend WithEvents txtDVT_EN As Commons.utcTextBox
    Friend WithEvents lblDVT_EN As System.Windows.Forms.Label
    Friend WithEvents txtDVT_VN As Commons.utcTextBox
    Friend WithEvents lblDVT_VN As System.Windows.Forms.Label
    Friend WithEvents BtnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMaLoaiVT As Commons.utcTextBox
    Friend WithEvents chkVatTu As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
