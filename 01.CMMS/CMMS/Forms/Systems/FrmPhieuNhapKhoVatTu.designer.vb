<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPhieuNhapKhoVatTu
    'Inherits DevExpress.XtraEditors.XtraForm
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnXoa = New System.Windows.Forms.Button()
        Me.BtnIn = New System.Windows.Forms.Button()
        Me.btnGhi = New System.Windows.Forms.Button()
        Me.btnTRO_VE = New System.Windows.Forms.Button()
        Me.lblCURRENT_DATE = New System.Windows.Forms.Label()
        Me.lblLOCK = New System.Windows.Forms.Label()
        Me.btnKhongGhi = New System.Windows.Forms.Button()
        Me.lblTieude = New System.Windows.Forms.Label()
        Me.grpNhapkhoPTCT = New System.Windows.Forms.GroupBox()
        Me.grdNhapkhoPTCT = New Commons.QLGrid()
        Me.menuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuItemDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSua = New System.Windows.Forms.Button()
        Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTHOI_GIAN_NHAP = New System.Windows.Forms.Label()
        Me.lblDANH_GIA = New System.Windows.Forms.Label()
        Me.lbaDiem1 = New System.Windows.Forms.Label()
        Me.tabDanhSachPT = New System.Windows.Forms.TabPage()
        Me.rdbChuaLock = New System.Windows.Forms.RadioButton()
        Me.rdbDalock = New System.Windows.Forms.RadioButton()
        Me.grdDanhsachNhapkhoPT = New Commons.QLGrid()
        Me.cboFilter = New Commons.UtcComboBox()
        Me.lblDanhSachNhapKhoPT = New System.Windows.Forms.Label()
        Me.cboLockho = New Commons.UtcComboBox()
        Me.lblKHO_LOC = New System.Windows.Forms.Label()
        Me.BtnThem = New System.Windows.Forms.Button()
        Me.grpNhapphutung = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMS_DH_NHAP_PT = New System.Windows.Forms.Label()
        Me.cboDDH = New Commons.UtcComboBox()
        Me.lblDonDatHang = New System.Windows.Forms.Label()
        Me.cboNGUOI_NHAP = New System.Windows.Forms.ComboBox()
        Me.txtMS_DH_NHAP = New Commons.utcTextBox()
        Me.lblKho = New System.Windows.Forms.Label()
        Me.dtpNGAY_NHAP = New System.Windows.Forms.DateTimePicker()
        Me.txtGIO_NHAP = New System.Windows.Forms.MaskedTextBox()
        Me.cboKHO = New Commons.UtcComboBox()
        Me.lblNgaychungtu = New System.Windows.Forms.Label()
        Me.dtpNGAY_CHUNG_TU = New System.Windows.Forms.DateTimePicker()
        Me.lblNguoinhap = New System.Windows.Forms.Label()
        Me.cboDANG_NHAP = New Commons.UtcComboBox()
        Me.txtSO_CHUNG_TU = New Commons.utcTextBox()
        Me.lblSophieuXN = New System.Windows.Forms.Label()
        Me.txtSO_PHIEU_NHAP = New Commons.utcTextBox()
        Me.lblSochungtu = New System.Windows.Forms.Label()
        Me.lblDangNhap = New System.Windows.Forms.Label()
        Me.txtDANH_GIA = New Commons.utcTextBox()
        Me.lbaDiem2 = New System.Windows.Forms.Label()
        Me.lbaDiem3 = New System.Windows.Forms.Label()
        Me.cboDiem2 = New System.Windows.Forms.ComboBox()
        Me.cboDiem3 = New System.Windows.Forms.ComboBox()
        Me.cboDiem1 = New System.Windows.Forms.ComboBox()
        Me.lblGhichu = New System.Windows.Forms.Label()
        Me.txtGhi_Chu = New System.Windows.Forms.RichTextBox()
        Me.tabNhapkhoPT = New System.Windows.Forms.TabControl()
        Me.tabChiTietPT = New System.Windows.Forms.TabPage()
        Me.lblSHOW_TIEN_TE = New System.Windows.Forms.Label()
        Me.grpSLtheoViTri = New System.Windows.Forms.GroupBox()
        Me.grdSLtheoViTri = New Commons.QLGrid()
        Me.btnChonPT = New System.Windows.Forms.Button()
        Me.btnLock_PN = New System.Windows.Forms.Button()
        Me.lblTIEN_TE = New System.Windows.Forms.Label()
        Me.chkLock = New System.Windows.Forms.CheckBox()
        Me.lblCURRENT_DATE_VALUE = New System.Windows.Forms.Label()
        Me.txtTim = New System.Windows.Forms.TextBox()
        Me.lblTimPN = New System.Windows.Forms.Label()
        Me.utcTextTiGia = New Commons.utcTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpNhapkhoPTCT.SuspendLayout()
        CType(Me.grdNhapkhoPTCT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuContext.SuspendLayout()
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDanhSachPT.SuspendLayout()
        CType(Me.grdDanhsachNhapkhoPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNhapphutung.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tabNhapkhoPT.SuspendLayout()
        Me.tabChiTietPT.SuspendLayout()
        Me.grpSLtheoViTri.SuspendLayout()
        CType(Me.grdSLtheoViTri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(798, 5)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 21
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnIn
        '
        Me.BtnIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIn.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnIn.Location = New System.Drawing.Point(716, 5)
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(81, 25)
        Me.BtnIn.TabIndex = 20
        Me.BtnIn.Text = "&In"
        Me.BtnIn.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.ForeColor = System.Drawing.Color.Blue
        Me.btnGhi.Location = New System.Drawing.Point(798, 5)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(81, 25)
        Me.btnGhi.TabIndex = 23
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnTRO_VE
        '
        Me.btnTRO_VE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTRO_VE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTRO_VE.ForeColor = System.Drawing.Color.Black
        Me.btnTRO_VE.Location = New System.Drawing.Point(880, 5)
        Me.btnTRO_VE.Name = "btnTRO_VE"
        Me.btnTRO_VE.Size = New System.Drawing.Size(81, 25)
        Me.btnTRO_VE.TabIndex = 22
        Me.btnTRO_VE.Text = "Thoát "
        Me.btnTRO_VE.UseVisualStyleBackColor = True
        '
        'lblCURRENT_DATE
        '
        Me.lblCURRENT_DATE.AutoSize = True
        Me.lblCURRENT_DATE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCURRENT_DATE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCURRENT_DATE.ForeColor = System.Drawing.Color.Navy
        Me.lblCURRENT_DATE.Location = New System.Drawing.Point(30, 0)
        Me.lblCURRENT_DATE.Name = "lblCURRENT_DATE"
        Me.lblCURRENT_DATE.Size = New System.Drawing.Size(79, 21)
        Me.lblCURRENT_DATE.TabIndex = 14
        Me.lblCURRENT_DATE.Text = "Ngày hiện tại:"
        Me.lblCURRENT_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLOCK
        '
        Me.lblLOCK.AutoSize = True
        Me.lblLOCK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLOCK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOCK.ForeColor = System.Drawing.Color.Navy
        Me.lblLOCK.Location = New System.Drawing.Point(784, 0)
        Me.lblLOCK.Name = "lblLOCK"
        Me.lblLOCK.Size = New System.Drawing.Size(77, 21)
        Me.lblLOCK.TabIndex = 17
        Me.lblLOCK.Text = "Locked "
        Me.lblLOCK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLOCK.Visible = False
        '
        'btnKhongGhi
        '
        Me.btnKhongGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhi.ForeColor = System.Drawing.Color.Red
        Me.btnKhongGhi.Location = New System.Drawing.Point(880, 5)
        Me.btnKhongGhi.Name = "btnKhongGhi"
        Me.btnKhongGhi.Size = New System.Drawing.Size(81, 25)
        Me.btnKhongGhi.TabIndex = 24
        Me.btnKhongGhi.Text = "Không ghi"
        Me.btnKhongGhi.UseVisualStyleBackColor = True
        '
        'lblTieude
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieude, 3)
        Me.lblTieude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieude.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.Color.Navy
        Me.lblTieude.Location = New System.Drawing.Point(181, 0)
        Me.lblTieude.Name = "lblTieude"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblTieude, 2)
        Me.lblTieude.Size = New System.Drawing.Size(597, 49)
        Me.lblTieude.TabIndex = 12
        Me.lblTieude.Text = "PHIẾU NHẬP KHO VẬT TƯ "
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpNhapkhoPTCT
        '
        Me.grpNhapkhoPTCT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNhapkhoPTCT.Controls.Add(Me.grdNhapkhoPTCT)
        Me.grpNhapkhoPTCT.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.grpNhapkhoPTCT.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapkhoPTCT.Location = New System.Drawing.Point(6, 9)
        Me.grpNhapkhoPTCT.Name = "grpNhapkhoPTCT"
        Me.grpNhapkhoPTCT.Size = New System.Drawing.Size(694, 333)
        Me.grpNhapkhoPTCT.TabIndex = 59
        Me.grpNhapkhoPTCT.TabStop = False
        Me.grpNhapkhoPTCT.Text = "Danh sách vật tư nhập kho "
        '
        'grdNhapkhoPTCT
        '
        Me.grdNhapkhoPTCT.AllowUserToAddRows = False
        Me.grdNhapkhoPTCT.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.grdNhapkhoPTCT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdNhapkhoPTCT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.grdNhapkhoPTCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNhapkhoPTCT.ContextMenuStrip = Me.menuContext
        Me.grdNhapkhoPTCT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNhapkhoPTCT.Location = New System.Drawing.Point(3, 18)
        Me.grdNhapkhoPTCT.MultiSelect = False
        Me.grdNhapkhoPTCT.Name = "grdNhapkhoPTCT"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdNhapkhoPTCT.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdNhapkhoPTCT.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.grdNhapkhoPTCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdNhapkhoPTCT.ShowEditingIcon = False
        Me.grdNhapkhoPTCT.Size = New System.Drawing.Size(688, 312)
        Me.grdNhapkhoPTCT.TabIndex = 23
        Me.grdNhapkhoPTCT.TabStop = False
        '
        'menuContext
        '
        Me.menuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItemDelete})
        Me.menuContext.Name = "menuContext"
        Me.menuContext.Size = New System.Drawing.Size(132, 26)
        '
        'menuItemDelete
        '
        Me.menuItemDelete.Name = "menuItemDelete"
        Me.menuItemDelete.Size = New System.Drawing.Size(131, 22)
        Me.menuItemDelete.Text = "&Xóa Vật Tư"
        Me.menuItemDelete.Visible = False
        '
        'btnSua
        '
        Me.btnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSua.Location = New System.Drawing.Point(634, 5)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(81, 25)
        Me.btnSua.TabIndex = 19
        Me.btnSua.Text = "&Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'errProvider
        '
        Me.errProvider.ContainerControl = Me
        '
        'lblTHOI_GIAN_NHAP
        '
        Me.lblTHOI_GIAN_NHAP.AutoSize = True
        Me.lblTHOI_GIAN_NHAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTHOI_GIAN_NHAP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTHOI_GIAN_NHAP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTHOI_GIAN_NHAP.Location = New System.Drawing.Point(608, 0)
        Me.lblTHOI_GIAN_NHAP.Name = "lblTHOI_GIAN_NHAP"
        Me.lblTHOI_GIAN_NHAP.Size = New System.Drawing.Size(113, 29)
        Me.lblTHOI_GIAN_NHAP.TabIndex = 9
        Me.lblTHOI_GIAN_NHAP.Text = "Thời gian nhập"
        Me.lblTHOI_GIAN_NHAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDANH_GIA
        '
        Me.lblDANH_GIA.AutoSize = True
        Me.lblDANH_GIA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDANH_GIA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDANH_GIA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDANH_GIA.Location = New System.Drawing.Point(13, 109)
        Me.lblDANH_GIA.Name = "lblDANH_GIA"
        Me.lblDANH_GIA.Size = New System.Drawing.Size(119, 30)
        Me.lblDANH_GIA.TabIndex = 26
        Me.lblDANH_GIA.Text = "Đánh giá"
        Me.lblDANH_GIA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDiem1
        '
        Me.lbaDiem1.AutoSize = True
        Me.lbaDiem1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDiem1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaDiem1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbaDiem1.Location = New System.Drawing.Point(13, 83)
        Me.lbaDiem1.Name = "lbaDiem1"
        Me.lbaDiem1.Size = New System.Drawing.Size(119, 26)
        Me.lbaDiem1.TabIndex = 24
        Me.lbaDiem1.Text = "Điểm 1"
        Me.lbaDiem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabDanhSachPT
        '
        Me.tabDanhSachPT.Controls.Add(Me.rdbChuaLock)
        Me.tabDanhSachPT.Controls.Add(Me.rdbDalock)
        Me.tabDanhSachPT.Controls.Add(Me.grdDanhsachNhapkhoPT)
        Me.tabDanhSachPT.Controls.Add(Me.cboFilter)
        Me.tabDanhSachPT.Controls.Add(Me.lblDanhSachNhapKhoPT)
        Me.tabDanhSachPT.Controls.Add(Me.cboLockho)
        Me.tabDanhSachPT.Controls.Add(Me.lblKHO_LOC)
        Me.tabDanhSachPT.Location = New System.Drawing.Point(4, 23)
        Me.tabDanhSachPT.Name = "tabDanhSachPT"
        Me.tabDanhSachPT.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDanhSachPT.Size = New System.Drawing.Size(959, 351)
        Me.tabDanhSachPT.TabIndex = 0
        Me.tabDanhSachPT.Text = "Danh sách phiếu nhập kho"
        Me.tabDanhSachPT.UseVisualStyleBackColor = True
        '
        'rdbChuaLock
        '
        Me.rdbChuaLock.AutoSize = True
        Me.rdbChuaLock.Checked = True
        Me.rdbChuaLock.Location = New System.Drawing.Point(202, 11)
        Me.rdbChuaLock.Name = "rdbChuaLock"
        Me.rdbChuaLock.Size = New System.Drawing.Size(82, 18)
        Me.rdbChuaLock.TabIndex = 43
        Me.rdbChuaLock.TabStop = True
        Me.rdbChuaLock.Text = "Chưa Lock"
        Me.rdbChuaLock.UseVisualStyleBackColor = True
        '
        'rdbDalock
        '
        Me.rdbDalock.AutoSize = True
        Me.rdbDalock.Location = New System.Drawing.Point(89, 13)
        Me.rdbDalock.Name = "rdbDalock"
        Me.rdbDalock.Size = New System.Drawing.Size(68, 18)
        Me.rdbDalock.TabIndex = 42
        Me.rdbDalock.Text = "Đã Lock"
        Me.rdbDalock.UseVisualStyleBackColor = True
        '
        'grdDanhsachNhapkhoPT
        '
        Me.grdDanhsachNhapkhoPT.AllowUserToAddRows = False
        Me.grdDanhsachNhapkhoPT.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDanhsachNhapkhoPT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachNhapkhoPT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDanhsachNhapkhoPT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.Format = "N2"
        Me.grdDanhsachNhapkhoPT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachNhapkhoPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachNhapkhoPT.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdDanhsachNhapkhoPT.Location = New System.Drawing.Point(5, 36)
        Me.grdDanhsachNhapkhoPT.MultiSelect = False
        Me.grdDanhsachNhapkhoPT.Name = "grdDanhsachNhapkhoPT"
        Me.grdDanhsachNhapkhoPT.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdDanhsachNhapkhoPT.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdDanhsachNhapkhoPT.RowHeadersWidth = 25
        Me.grdDanhsachNhapkhoPT.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdDanhsachNhapkhoPT.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.grdDanhsachNhapkhoPT.ShowEditingIcon = False
        Me.grdDanhsachNhapkhoPT.Size = New System.Drawing.Size(949, 309)
        Me.grdDanhsachNhapkhoPT.TabIndex = 41
        '
        'cboFilter
        '
        Me.cboFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cboFilter.AssemblyName = ""
        Me.cboFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFilter.BackColor = System.Drawing.SystemColors.Window
        Me.cboFilter.ClassName = ""
        Me.cboFilter.Display = "MONTHYEAR"
        Me.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter.ErrorProviderControl = Me.errProvider
        Me.cboFilter.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.IsAll = False
        Me.cboFilter.isInputNull = False
        Me.cboFilter.IsNew = False
        Me.cboFilter.IsNull = True
        Me.cboFilter.ItemAll = " < ALL > "
        Me.cboFilter.ItemNew = "...New"
        Me.cboFilter.Location = New System.Drawing.Point(746, 7)
        Me.cboFilter.MethodName = ""
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Param = ""
        Me.cboFilter.Param2 = ""
        Me.cboFilter.Size = New System.Drawing.Size(130, 22)
        Me.cboFilter.StoreName = "QL_LOAD_MONTH_DON_HANG_NHAP"
        Me.cboFilter.TabIndex = 29
        Me.cboFilter.Table = Nothing
        Me.cboFilter.TextReadonly = True
        Me.cboFilter.Value = "MONTHYEAR"
        '
        'lblDanhSachNhapKhoPT
        '
        Me.lblDanhSachNhapKhoPT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDanhSachNhapKhoPT.AutoSize = True
        Me.lblDanhSachNhapKhoPT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDanhSachNhapKhoPT.ForeColor = System.Drawing.Color.Navy
        Me.lblDanhSachNhapKhoPT.Location = New System.Drawing.Point(600, 12)
        Me.lblDanhSachNhapKhoPT.Name = "lblDanhSachNhapKhoPT"
        Me.lblDanhSachNhapKhoPT.Size = New System.Drawing.Size(140, 13)
        Me.lblDanhSachNhapKhoPT.TabIndex = 28
        Me.lblDanhSachNhapKhoPT.Text = "Phiếu nhập kho trong tháng"
        Me.lblDanhSachNhapKhoPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboLockho
        '
        Me.cboLockho.AssemblyName = ""
        Me.cboLockho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLockho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLockho.BackColor = System.Drawing.SystemColors.Window
        Me.cboLockho.ClassName = ""
        Me.cboLockho.Display = "TEN_KHO"
        Me.cboLockho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLockho.ErrorProviderControl = Me.errProvider
        Me.cboLockho.FormattingEnabled = True
        Me.cboLockho.IsAll = False
        Me.cboLockho.isInputNull = False
        Me.cboLockho.IsNew = False
        Me.cboLockho.IsNull = True
        Me.cboLockho.ItemAll = " < ALL > "
        Me.cboLockho.ItemNew = "...New"
        Me.cboLockho.Items.AddRange(New Object() {""})
        Me.cboLockho.Location = New System.Drawing.Point(417, 7)
        Me.cboLockho.MethodName = ""
        Me.cboLockho.Name = "cboLockho"
        Me.cboLockho.Param = ""
        Me.cboLockho.Param2 = ""
        Me.cboLockho.Size = New System.Drawing.Size(170, 22)
        Me.cboLockho.StoreName = "QL_ListKho"
        Me.cboLockho.TabIndex = 13
        Me.cboLockho.Table = Nothing
        Me.cboLockho.TextReadonly = True
        Me.cboLockho.Value = "MS_KHO"
        '
        'lblKHO_LOC
        '
        Me.lblKHO_LOC.AutoSize = True
        Me.lblKHO_LOC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKHO_LOC.ForeColor = System.Drawing.Color.Navy
        Me.lblKHO_LOC.Location = New System.Drawing.Point(366, 16)
        Me.lblKHO_LOC.Name = "lblKHO_LOC"
        Me.lblKHO_LOC.Size = New System.Drawing.Size(25, 13)
        Me.lblKHO_LOC.TabIndex = 12
        Me.lblKHO_LOC.Text = "Kho"
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(552, 5)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 18
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'grpNhapphutung
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpNhapphutung, 9)
        Me.grpNhapphutung.Controls.Add(Me.TableLayoutPanel2)
        Me.grpNhapphutung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNhapphutung.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNhapphutung.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhapphutung.Location = New System.Drawing.Point(3, 52)
        Me.grpNhapphutung.Name = "grpNhapphutung"
        Me.grpNhapphutung.Size = New System.Drawing.Size(967, 160)
        Me.grpNhapphutung.TabIndex = 4
        Me.grpNhapphutung.TabStop = False
        Me.grpNhapphutung.Text = "Lập phiếu nhập kho vật tư"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblMS_DH_NHAP_PT, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDDH, 6, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDonDatHang, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cboNGUOI_NHAP, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMS_DH_NHAP, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblKho, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpNGAY_NHAP, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtGIO_NHAP, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboKHO, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNgaychungtu, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpNGAY_CHUNG_TU, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTHOI_GIAN_NHAP, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNguoinhap, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDANG_NHAP, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSO_CHUNG_TU, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSophieuXN, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSO_PHIEU_NHAP, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSochungtu, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDangNhap, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaDiem1, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDANH_GIA, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDANH_GIA, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaDiem2, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaDiem3, 5, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDiem2, 4, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDiem3, 6, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDiem1, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblGhichu, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtGhi_Chu, 4, 4)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(961, 139)
        Me.TableLayoutPanel2.TabIndex = 29
        '
        'lblMS_DH_NHAP_PT
        '
        Me.lblMS_DH_NHAP_PT.AutoSize = True
        Me.lblMS_DH_NHAP_PT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMS_DH_NHAP_PT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMS_DH_NHAP_PT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMS_DH_NHAP_PT.Location = New System.Drawing.Point(13, 0)
        Me.lblMS_DH_NHAP_PT.Name = "lblMS_DH_NHAP_PT"
        Me.lblMS_DH_NHAP_PT.Size = New System.Drawing.Size(119, 29)
        Me.lblMS_DH_NHAP_PT.TabIndex = 5
        Me.lblMS_DH_NHAP_PT.Text = "MS phiếu nhập "
        Me.lblMS_DH_NHAP_PT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDDH
        '
        Me.cboDDH.AssemblyName = ""
        Me.cboDDH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDDH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDDH.BackColor = System.Drawing.SystemColors.Window
        Me.cboDDH.ClassName = ""
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboDDH, 2)
        Me.cboDDH.Display = ""
        Me.cboDDH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDDH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDDH.ErrorProviderControl = Me.errProvider
        Me.cboDDH.FormattingEnabled = True
        Me.cboDDH.IsAll = False
        Me.cboDDH.isInputNull = False
        Me.cboDDH.IsNew = False
        Me.cboDDH.IsNull = True
        Me.cboDDH.ItemAll = ""
        Me.cboDDH.ItemNew = "...New"
        Me.cboDDH.Items.AddRange(New Object() {""})
        Me.cboDDH.Location = New System.Drawing.Point(727, 60)
        Me.cboDDH.MethodName = ""
        Me.cboDDH.Name = "cboDDH"
        Me.cboDDH.Param = ""
        Me.cboDDH.Param2 = ""
        Me.cboDDH.Size = New System.Drawing.Size(221, 22)
        Me.cboDDH.StoreName = ""
        Me.cboDDH.TabIndex = 15
        Me.cboDDH.Table = Nothing
        Me.cboDDH.TextReadonly = True
        Me.cboDDH.Value = ""
        '
        'lblDonDatHang
        '
        Me.lblDonDatHang.AutoSize = True
        Me.lblDonDatHang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDonDatHang.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDonDatHang.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDonDatHang.Location = New System.Drawing.Point(608, 57)
        Me.lblDonDatHang.Name = "lblDonDatHang"
        Me.lblDonDatHang.Size = New System.Drawing.Size(113, 26)
        Me.lblDonDatHang.TabIndex = 28
        Me.lblDonDatHang.Text = "Đơn đặt hàng"
        Me.lblDonDatHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNGUOI_NHAP
        '
        Me.cboNGUOI_NHAP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNGUOI_NHAP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboNGUOI_NHAP, 2)
        Me.cboNGUOI_NHAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNGUOI_NHAP.FormattingEnabled = True
        Me.cboNGUOI_NHAP.Location = New System.Drawing.Point(727, 32)
        Me.cboNGUOI_NHAP.Name = "cboNGUOI_NHAP"
        Me.cboNGUOI_NHAP.Size = New System.Drawing.Size(221, 22)
        Me.cboNGUOI_NHAP.TabIndex = 12
        '
        'txtMS_DH_NHAP
        '
        Me.txtMS_DH_NHAP.BackColor = System.Drawing.Color.White
        Me.txtMS_DH_NHAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMS_DH_NHAP.Enabled = False
        Me.txtMS_DH_NHAP.ErrorProviderControl = Me.errProvider
        Me.txtMS_DH_NHAP.FieldName = ""
        Me.txtMS_DH_NHAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMS_DH_NHAP.IsNull = False
        Me.txtMS_DH_NHAP.Location = New System.Drawing.Point(138, 3)
        Me.txtMS_DH_NHAP.Name = "txtMS_DH_NHAP"
        Me.txtMS_DH_NHAP.ReadOnly = True
        Me.txtMS_DH_NHAP.Size = New System.Drawing.Size(151, 22)
        Me.txtMS_DH_NHAP.TabIndex = 6
        Me.txtMS_DH_NHAP.TextTypeMode = Commons.TypeMode.None
        '
        'lblKho
        '
        Me.lblKho.AutoSize = True
        Me.lblKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKho.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKho.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblKho.Location = New System.Drawing.Point(13, 29)
        Me.lblKho.Name = "lblKho"
        Me.lblKho.Size = New System.Drawing.Size(119, 28)
        Me.lblKho.TabIndex = 12
        Me.lblKho.Text = "Kho"
        Me.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpNGAY_NHAP
        '
        Me.dtpNGAY_NHAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpNGAY_NHAP.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNGAY_NHAP.Location = New System.Drawing.Point(787, 3)
        Me.dtpNGAY_NHAP.Name = "dtpNGAY_NHAP"
        Me.dtpNGAY_NHAP.Size = New System.Drawing.Size(161, 22)
        Me.dtpNGAY_NHAP.TabIndex = 9
        Me.dtpNGAY_NHAP.Value = New Date(2007, 6, 25, 0, 0, 0, 0)
        '
        'txtGIO_NHAP
        '
        Me.txtGIO_NHAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGIO_NHAP.Location = New System.Drawing.Point(727, 3)
        Me.txtGIO_NHAP.Mask = "90:00"
        Me.txtGIO_NHAP.Name = "txtGIO_NHAP"
        Me.txtGIO_NHAP.Size = New System.Drawing.Size(54, 22)
        Me.txtGIO_NHAP.TabIndex = 8
        Me.txtGIO_NHAP.ValidatingType = GetType(Date)
        '
        'cboKHO
        '
        Me.cboKHO.AssemblyName = ""
        Me.cboKHO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKHO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKHO.BackColor = System.Drawing.SystemColors.Window
        Me.cboKHO.ClassName = ""
        Me.cboKHO.Display = "TEN_KHO"
        Me.cboKHO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKHO.ErrorProviderControl = Me.errProvider
        Me.cboKHO.FormattingEnabled = True
        Me.cboKHO.IsAll = False
        Me.cboKHO.isInputNull = False
        Me.cboKHO.IsNew = True
        Me.cboKHO.IsNull = True
        Me.cboKHO.ItemAll = ""
        Me.cboKHO.ItemNew = "...New"
        Me.cboKHO.Items.AddRange(New Object() {""})
        Me.cboKHO.Location = New System.Drawing.Point(138, 32)
        Me.cboKHO.MethodName = ""
        Me.cboKHO.Name = "cboKHO"
        Me.cboKHO.Param = ""
        Me.cboKHO.Param2 = ""
        Me.cboKHO.Size = New System.Drawing.Size(151, 22)
        Me.cboKHO.StoreName = "QL_LISTKHO"
        Me.cboKHO.TabIndex = 10
        Me.cboKHO.Table = Nothing
        Me.cboKHO.TextReadonly = True
        Me.cboKHO.Value = "MS_KHO"
        '
        'lblNgaychungtu
        '
        Me.lblNgaychungtu.AutoSize = True
        Me.lblNgaychungtu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgaychungtu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgaychungtu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNgaychungtu.Location = New System.Drawing.Point(13, 57)
        Me.lblNgaychungtu.Name = "lblNgaychungtu"
        Me.lblNgaychungtu.Size = New System.Drawing.Size(119, 26)
        Me.lblNgaychungtu.TabIndex = 18
        Me.lblNgaychungtu.Text = "Ngày chứng từ"
        Me.lblNgaychungtu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpNGAY_CHUNG_TU
        '
        Me.dtpNGAY_CHUNG_TU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpNGAY_CHUNG_TU.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNGAY_CHUNG_TU.Location = New System.Drawing.Point(138, 60)
        Me.dtpNGAY_CHUNG_TU.Name = "dtpNGAY_CHUNG_TU"
        Me.dtpNGAY_CHUNG_TU.Size = New System.Drawing.Size(151, 22)
        Me.dtpNGAY_CHUNG_TU.TabIndex = 13
        Me.dtpNGAY_CHUNG_TU.Value = New Date(2007, 6, 25, 0, 0, 0, 0)
        '
        'lblNguoinhap
        '
        Me.lblNguoinhap.AutoSize = True
        Me.lblNguoinhap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNguoinhap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNguoinhap.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNguoinhap.Location = New System.Drawing.Point(608, 29)
        Me.lblNguoinhap.Name = "lblNguoinhap"
        Me.lblNguoinhap.Size = New System.Drawing.Size(113, 28)
        Me.lblNguoinhap.TabIndex = 16
        Me.lblNguoinhap.Text = "Người nhập"
        Me.lblNguoinhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDANG_NHAP
        '
        Me.cboDANG_NHAP.AssemblyName = ""
        Me.cboDANG_NHAP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDANG_NHAP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDANG_NHAP.BackColor = System.Drawing.SystemColors.Window
        Me.cboDANG_NHAP.ClassName = ""
        Me.cboDANG_NHAP.Display = "DANG_NHAP_VIET"
        Me.cboDANG_NHAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDANG_NHAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDANG_NHAP.ErrorProviderControl = Me.errProvider
        Me.cboDANG_NHAP.FormattingEnabled = True
        Me.cboDANG_NHAP.IsAll = False
        Me.cboDANG_NHAP.isInputNull = False
        Me.cboDANG_NHAP.IsNew = False
        Me.cboDANG_NHAP.IsNull = True
        Me.cboDANG_NHAP.ItemAll = " < ALL > "
        Me.cboDANG_NHAP.ItemNew = "...New"
        Me.cboDANG_NHAP.Location = New System.Drawing.Point(424, 32)
        Me.cboDANG_NHAP.MethodName = ""
        Me.cboDANG_NHAP.Name = "cboDANG_NHAP"
        Me.cboDANG_NHAP.Param = ""
        Me.cboDANG_NHAP.Param2 = ""
        Me.cboDANG_NHAP.Size = New System.Drawing.Size(178, 22)
        Me.cboDANG_NHAP.StoreName = "QL_DANG_NHAP"
        Me.cboDANG_NHAP.TabIndex = 11
        Me.cboDANG_NHAP.Table = Nothing
        Me.cboDANG_NHAP.TextReadonly = True
        Me.cboDANG_NHAP.Value = "MS_DANG_NHAP"
        '
        'txtSO_CHUNG_TU
        '
        Me.txtSO_CHUNG_TU.BackColor = System.Drawing.Color.White
        Me.txtSO_CHUNG_TU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSO_CHUNG_TU.ErrorProviderControl = Me.errProvider
        Me.txtSO_CHUNG_TU.FieldName = ""
        Me.txtSO_CHUNG_TU.IsNull = False
        Me.txtSO_CHUNG_TU.Location = New System.Drawing.Point(424, 60)
        Me.txtSO_CHUNG_TU.Name = "txtSO_CHUNG_TU"
        Me.txtSO_CHUNG_TU.Size = New System.Drawing.Size(178, 22)
        Me.txtSO_CHUNG_TU.TabIndex = 14
        Me.txtSO_CHUNG_TU.TextTypeMode = Commons.TypeMode.None
        '
        'lblSophieuXN
        '
        Me.lblSophieuXN.AutoSize = True
        Me.lblSophieuXN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSophieuXN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSophieuXN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSophieuXN.Location = New System.Drawing.Point(295, 0)
        Me.lblSophieuXN.Name = "lblSophieuXN"
        Me.lblSophieuXN.Size = New System.Drawing.Size(123, 29)
        Me.lblSophieuXN.TabIndex = 7
        Me.lblSophieuXN.Text = "Số phiếu nhập"
        Me.lblSophieuXN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSO_PHIEU_NHAP
        '
        Me.txtSO_PHIEU_NHAP.BackColor = System.Drawing.Color.White
        Me.txtSO_PHIEU_NHAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSO_PHIEU_NHAP.ErrorProviderControl = Me.errProvider
        Me.txtSO_PHIEU_NHAP.FieldName = ""
        Me.txtSO_PHIEU_NHAP.IsNull = False
        Me.txtSO_PHIEU_NHAP.Location = New System.Drawing.Point(424, 3)
        Me.txtSO_PHIEU_NHAP.Name = "txtSO_PHIEU_NHAP"
        Me.txtSO_PHIEU_NHAP.Size = New System.Drawing.Size(178, 22)
        Me.txtSO_PHIEU_NHAP.TabIndex = 7
        Me.txtSO_PHIEU_NHAP.TextTypeMode = Commons.TypeMode.None
        '
        'lblSochungtu
        '
        Me.lblSochungtu.AutoSize = True
        Me.lblSochungtu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSochungtu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSochungtu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSochungtu.Location = New System.Drawing.Point(295, 57)
        Me.lblSochungtu.Name = "lblSochungtu"
        Me.lblSochungtu.Size = New System.Drawing.Size(123, 26)
        Me.lblSochungtu.TabIndex = 20
        Me.lblSochungtu.Text = "Số chứng từ"
        Me.lblSochungtu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDangNhap
        '
        Me.lblDangNhap.AutoSize = True
        Me.lblDangNhap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDangNhap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDangNhap.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDangNhap.Location = New System.Drawing.Point(295, 29)
        Me.lblDangNhap.Name = "lblDangNhap"
        Me.lblDangNhap.Size = New System.Drawing.Size(123, 28)
        Me.lblDangNhap.TabIndex = 14
        Me.lblDangNhap.Text = "Dạng nhập"
        Me.lblDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDANH_GIA
        '
        Me.txtDANH_GIA.BackColor = System.Drawing.Color.White
        Me.txtDANH_GIA.ErrorProviderControl = Me.errProvider
        Me.txtDANH_GIA.FieldName = ""
        Me.txtDANH_GIA.IsNull = False
        Me.txtDANH_GIA.Location = New System.Drawing.Point(138, 112)
        Me.txtDANH_GIA.Name = "txtDANH_GIA"
        Me.txtDANH_GIA.Size = New System.Drawing.Size(151, 22)
        Me.txtDANH_GIA.TabIndex = 17
        Me.txtDANH_GIA.TextTypeMode = Commons.TypeMode.None
        '
        'lbaDiem2
        '
        Me.lbaDiem2.AutoSize = True
        Me.lbaDiem2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDiem2.Location = New System.Drawing.Point(295, 83)
        Me.lbaDiem2.Name = "lbaDiem2"
        Me.lbaDiem2.Size = New System.Drawing.Size(123, 26)
        Me.lbaDiem2.TabIndex = 29
        Me.lbaDiem2.Text = "Diem 2"
        Me.lbaDiem2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDiem3
        '
        Me.lbaDiem3.AutoSize = True
        Me.lbaDiem3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDiem3.Location = New System.Drawing.Point(608, 83)
        Me.lbaDiem3.Name = "lbaDiem3"
        Me.lbaDiem3.Size = New System.Drawing.Size(113, 26)
        Me.lbaDiem3.TabIndex = 30
        Me.lbaDiem3.Text = "Diem 3"
        Me.lbaDiem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDiem2
        '
        Me.cboDiem2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiem2.FormattingEnabled = True
        Me.cboDiem2.Location = New System.Drawing.Point(424, 86)
        Me.cboDiem2.Name = "cboDiem2"
        Me.cboDiem2.Size = New System.Drawing.Size(178, 22)
        Me.cboDiem2.TabIndex = 31
        '
        'cboDiem3
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboDiem3, 2)
        Me.cboDiem3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiem3.FormattingEnabled = True
        Me.cboDiem3.Location = New System.Drawing.Point(727, 86)
        Me.cboDiem3.Name = "cboDiem3"
        Me.cboDiem3.Size = New System.Drawing.Size(221, 22)
        Me.cboDiem3.TabIndex = 32
        '
        'cboDiem1
        '
        Me.cboDiem1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiem1.FormattingEnabled = True
        Me.cboDiem1.Location = New System.Drawing.Point(138, 86)
        Me.cboDiem1.Name = "cboDiem1"
        Me.cboDiem1.Size = New System.Drawing.Size(151, 22)
        Me.cboDiem1.TabIndex = 33
        '
        'lblGhichu
        '
        Me.lblGhichu.AutoSize = True
        Me.lblGhichu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGhichu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGhichu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGhichu.Location = New System.Drawing.Point(295, 109)
        Me.lblGhichu.Name = "lblGhichu"
        Me.lblGhichu.Size = New System.Drawing.Size(123, 30)
        Me.lblGhichu.TabIndex = 22
        Me.lblGhichu.Text = "Ghi chú"
        Me.lblGhichu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGhi_Chu
        '
        Me.txtGhi_Chu.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtGhi_Chu, 4)
        Me.txtGhi_Chu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGhi_Chu.Location = New System.Drawing.Point(424, 112)
        Me.txtGhi_Chu.Name = "txtGhi_Chu"
        Me.txtGhi_Chu.Size = New System.Drawing.Size(524, 24)
        Me.txtGhi_Chu.TabIndex = 18
        Me.txtGhi_Chu.Text = ""
        '
        'tabNhapkhoPT
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tabNhapkhoPT, 9)
        Me.tabNhapkhoPT.Controls.Add(Me.tabDanhSachPT)
        Me.tabNhapkhoPT.Controls.Add(Me.tabChiTietPT)
        Me.tabNhapkhoPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabNhapkhoPT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabNhapkhoPT.Location = New System.Drawing.Point(3, 218)
        Me.tabNhapkhoPT.Name = "tabNhapkhoPT"
        Me.tabNhapkhoPT.SelectedIndex = 0
        Me.tabNhapkhoPT.Size = New System.Drawing.Size(967, 378)
        Me.tabNhapkhoPT.TabIndex = 30
        '
        'tabChiTietPT
        '
        Me.tabChiTietPT.Controls.Add(Me.lblSHOW_TIEN_TE)
        Me.tabChiTietPT.Controls.Add(Me.grpSLtheoViTri)
        Me.tabChiTietPT.Controls.Add(Me.grpNhapkhoPTCT)
        Me.tabChiTietPT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabChiTietPT.Location = New System.Drawing.Point(4, 23)
        Me.tabChiTietPT.Name = "tabChiTietPT"
        Me.tabChiTietPT.Padding = New System.Windows.Forms.Padding(3)
        Me.tabChiTietPT.Size = New System.Drawing.Size(959, 351)
        Me.tabChiTietPT.TabIndex = 1
        Me.tabChiTietPT.Text = "Chi tiết phiếu nhập kho"
        Me.tabChiTietPT.UseVisualStyleBackColor = True
        '
        'lblSHOW_TIEN_TE
        '
        Me.lblSHOW_TIEN_TE.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSHOW_TIEN_TE.AutoSize = True
        Me.lblSHOW_TIEN_TE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSHOW_TIEN_TE.ForeColor = System.Drawing.Color.Navy
        Me.lblSHOW_TIEN_TE.Location = New System.Drawing.Point(360, 3)
        Me.lblSHOW_TIEN_TE.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSHOW_TIEN_TE.Name = "lblSHOW_TIEN_TE"
        Me.lblSHOW_TIEN_TE.Size = New System.Drawing.Size(0, 14)
        Me.lblSHOW_TIEN_TE.TabIndex = 78
        Me.lblSHOW_TIEN_TE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpSLtheoViTri
        '
        Me.grpSLtheoViTri.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSLtheoViTri.Controls.Add(Me.grdSLtheoViTri)
        Me.grpSLtheoViTri.ForeColor = System.Drawing.Color.Maroon
        Me.grpSLtheoViTri.Location = New System.Drawing.Point(711, 9)
        Me.grpSLtheoViTri.Name = "grpSLtheoViTri"
        Me.grpSLtheoViTri.Size = New System.Drawing.Size(219, 339)
        Me.grpSLtheoViTri.TabIndex = 72
        Me.grpSLtheoViTri.TabStop = False
        Me.grpSLtheoViTri.Text = "Số lượng trong từng vị trí kho"
        '
        'grdSLtheoViTri
        '
        Me.grdSLtheoViTri.AllowUserToAddRows = False
        Me.grdSLtheoViTri.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.grdSLtheoViTri.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.grdSLtheoViTri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdSLtheoViTri.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdSLtheoViTri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSLtheoViTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSLtheoViTri.Location = New System.Drawing.Point(3, 18)
        Me.grdSLtheoViTri.MultiSelect = False
        Me.grdSLtheoViTri.Name = "grdSLtheoViTri"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdSLtheoViTri.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdSLtheoViTri.RowHeadersWidth = 25
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdSLtheoViTri.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grdSLtheoViTri.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdSLtheoViTri.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdSLtheoViTri.ShowEditingIcon = False
        Me.grdSLtheoViTri.Size = New System.Drawing.Size(213, 318)
        Me.grdSLtheoViTri.TabIndex = 24
        '
        'btnChonPT
        '
        Me.btnChonPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChonPT.Enabled = False
        Me.btnChonPT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChonPT.ForeColor = System.Drawing.Color.Maroon
        Me.btnChonPT.Location = New System.Drawing.Point(4, 5)
        Me.btnChonPT.Name = "btnChonPT"
        Me.btnChonPT.Size = New System.Drawing.Size(123, 25)
        Me.btnChonPT.TabIndex = 18
        Me.btnChonPT.Text = "Chọn vật tư"
        Me.btnChonPT.UseVisualStyleBackColor = True
        Me.btnChonPT.Visible = False
        '
        'btnLock_PN
        '
        Me.btnLock_PN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLock_PN.Enabled = False
        Me.btnLock_PN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLock_PN.ForeColor = System.Drawing.Color.Blue
        Me.btnLock_PN.Location = New System.Drawing.Point(4, 5)
        Me.btnLock_PN.Name = "btnLock_PN"
        Me.btnLock_PN.Size = New System.Drawing.Size(123, 25)
        Me.btnLock_PN.TabIndex = 53
        Me.btnLock_PN.Text = "Lock phiếu nhập"
        Me.btnLock_PN.UseVisualStyleBackColor = True
        '
        'lblTIEN_TE
        '
        Me.lblTIEN_TE.AutoSize = True
        Me.lblTIEN_TE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTIEN_TE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIEN_TE.ForeColor = System.Drawing.Color.Navy
        Me.lblTIEN_TE.Location = New System.Drawing.Point(783, 21)
        Me.lblTIEN_TE.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTIEN_TE.Name = "lblTIEN_TE"
        Me.lblTIEN_TE.Size = New System.Drawing.Size(79, 28)
        Me.lblTIEN_TE.TabIndex = 70
        Me.lblTIEN_TE.Text = "Tiền tệ quy đổi"
        Me.lblTIEN_TE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTIEN_TE.Visible = False
        '
        'chkLock
        '
        Me.chkLock.AutoSize = True
        Me.chkLock.Enabled = False
        Me.chkLock.Location = New System.Drawing.Point(867, 3)
        Me.chkLock.Name = "chkLock"
        Me.chkLock.Size = New System.Drawing.Size(15, 14)
        Me.chkLock.TabIndex = 71
        Me.chkLock.UseVisualStyleBackColor = True
        Me.chkLock.Visible = False
        '
        'lblCURRENT_DATE_VALUE
        '
        Me.lblCURRENT_DATE_VALUE.AutoSize = True
        Me.lblCURRENT_DATE_VALUE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCURRENT_DATE_VALUE.Location = New System.Drawing.Point(115, 0)
        Me.lblCURRENT_DATE_VALUE.Name = "lblCURRENT_DATE_VALUE"
        Me.lblCURRENT_DATE_VALUE.Size = New System.Drawing.Size(60, 21)
        Me.lblCURRENT_DATE_VALUE.TabIndex = 78
        Me.lblCURRENT_DATE_VALUE.Text = "1"
        Me.lblCURRENT_DATE_VALUE.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtTim
        '
        Me.txtTim.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTim.BackColor = System.Drawing.Color.White
        Me.txtTim.Location = New System.Drawing.Point(372, 5)
        Me.txtTim.Name = "txtTim"
        Me.txtTim.Size = New System.Drawing.Size(128, 21)
        Me.txtTim.TabIndex = 79
        '
        'lblTimPN
        '
        Me.lblTimPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTimPN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimPN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTimPN.Location = New System.Drawing.Point(287, 11)
        Me.lblTimPN.Name = "lblTimPN"
        Me.lblTimPN.Size = New System.Drawing.Size(79, 13)
        Me.lblTimPN.TabIndex = 80
        Me.lblTimPN.Text = "Tìm phiếu nhập"
        '
        'utcTextTiGia
        '
        Me.utcTextTiGia.BackColor = System.Drawing.Color.White
        Me.utcTextTiGia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.utcTextTiGia.Enabled = False
        Me.utcTextTiGia.ErrorProviderControl = Nothing
        Me.utcTextTiGia.FieldName = ""
        Me.utcTextTiGia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.utcTextTiGia.ForeColor = System.Drawing.Color.Blue
        Me.utcTextTiGia.IsNull = False
        Me.utcTextTiGia.Location = New System.Drawing.Point(867, 24)
        Me.utcTextTiGia.Name = "utcTextTiGia"
        Me.utcTextTiGia.ReadOnly = True
        Me.utcTextTiGia.Size = New System.Drawing.Size(76, 21)
        Me.utcTextTiGia.TabIndex = 6
        Me.utcTextTiGia.TextTypeMode = Commons.TypeMode.None
        Me.utcTextTiGia.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 282.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblCURRENT_DATE, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCURRENT_DATE_VALUE, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieude, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLOCK, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkLock, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTIEN_TE, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.utcTextTiGia, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpNhapphutung, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tabNhapkhoPT, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(973, 638)
        Me.TableLayoutPanel1.TabIndex = 81
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 9)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Controls.Add(Me.btnKhongGhi)
        Me.Panel1.Controls.Add(Me.btnChonPT)
        Me.Panel1.Controls.Add(Me.lblTimPN)
        Me.Panel1.Controls.Add(Me.btnLock_PN)
        Me.Panel1.Controls.Add(Me.txtTim)
        Me.Panel1.Controls.Add(Me.BtnIn)
        Me.Panel1.Controls.Add(Me.btnSua)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.btnTRO_VE)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 602)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(967, 33)
        Me.Panel1.TabIndex = 79
        '
        'FrmPhieuNhapKhoVatTu
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 638)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmPhieuNhapKhoVatTu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPhieuNhapKhoVatTu"
        Me.grpNhapkhoPTCT.ResumeLayout(False)
        CType(Me.grdNhapkhoPTCT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuContext.ResumeLayout(False)
        CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDanhSachPT.ResumeLayout(False)
        Me.tabDanhSachPT.PerformLayout()
        CType(Me.grdDanhsachNhapkhoPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNhapphutung.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.tabNhapkhoPT.ResumeLayout(False)
        Me.tabChiTietPT.ResumeLayout(False)
        Me.tabChiTietPT.PerformLayout()
        Me.grpSLtheoViTri.ResumeLayout(False)
        CType(Me.grdSLtheoViTri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnIn As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnTRO_VE As System.Windows.Forms.Button
    Friend WithEvents lblCURRENT_DATE As System.Windows.Forms.Label
    Friend WithEvents lblLOCK As System.Windows.Forms.Label
    Friend WithEvents btnKhongGhi As System.Windows.Forms.Button
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents grpNhapkhoPTCT As System.Windows.Forms.GroupBox
    Friend WithEvents grdNhapkhoPTCT As Commons.QLGrid
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents cboDANG_NHAP As Commons.UtcComboBox
    Friend WithEvents errProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents tabNhapkhoPT As System.Windows.Forms.TabControl
    Friend WithEvents tabDanhSachPT As System.Windows.Forms.TabPage
    Friend WithEvents grdDanhsachNhapkhoPT As Commons.QLGrid
    Friend WithEvents cboFilter As Commons.UtcComboBox
    Friend WithEvents lblDanhSachNhapKhoPT As System.Windows.Forms.Label
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents grpNhapphutung As System.Windows.Forms.GroupBox
    Friend WithEvents txtGIO_NHAP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblTHOI_GIAN_NHAP As System.Windows.Forms.Label
    Friend WithEvents txtDANH_GIA As Commons.utcTextBox
    Friend WithEvents lblDANH_GIA As System.Windows.Forms.Label
    Friend WithEvents lbaDiem1 As System.Windows.Forms.Label
    Friend WithEvents txtSO_CHUNG_TU As Commons.utcTextBox
    Friend WithEvents txtSO_PHIEU_NHAP As Commons.utcTextBox
    Friend WithEvents cboKHO As Commons.UtcComboBox
    Friend WithEvents txtMS_DH_NHAP As Commons.utcTextBox
    Friend WithEvents dtpNGAY_CHUNG_TU As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblGhichu As System.Windows.Forms.Label
    Friend WithEvents lblNgaychungtu As System.Windows.Forms.Label
    Friend WithEvents lblSochungtu As System.Windows.Forms.Label
    Friend WithEvents lblKho As System.Windows.Forms.Label
    Friend WithEvents lblNguoinhap As System.Windows.Forms.Label
    Friend WithEvents dtpNGAY_NHAP As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMS_DH_NHAP_PT As System.Windows.Forms.Label
    Friend WithEvents lblSophieuXN As System.Windows.Forms.Label
    Friend WithEvents lblDangNhap As System.Windows.Forms.Label
    Friend WithEvents tabChiTietPT As System.Windows.Forms.TabPage
    Friend WithEvents lblSHOW_TIEN_TE As System.Windows.Forms.Label
    Friend WithEvents btnChonPT As System.Windows.Forms.Button
    Friend WithEvents lblTIEN_TE As System.Windows.Forms.Label
    Friend WithEvents grpSLtheoViTri As System.Windows.Forms.GroupBox
    Friend WithEvents grdSLtheoViTri As Commons.QLGrid
    Friend WithEvents cboLockho As Commons.UtcComboBox
    Friend WithEvents lblKHO_LOC As System.Windows.Forms.Label
    Friend WithEvents utcTextTiGia As Commons.utcTextBox
    Friend WithEvents txtGhi_Chu As System.Windows.Forms.RichTextBox
    Friend WithEvents chkLock As System.Windows.Forms.CheckBox
    Friend WithEvents btnLock_PN As System.Windows.Forms.Button
    Friend WithEvents cboNGUOI_NHAP As System.Windows.Forms.ComboBox
    Friend WithEvents menuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuItemDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCURRENT_DATE_VALUE As System.Windows.Forms.Label
    Friend WithEvents txtTim As System.Windows.Forms.TextBox
    Friend WithEvents lblTimPN As System.Windows.Forms.Label
    Friend WithEvents lblDonDatHang As System.Windows.Forms.Label
    Friend WithEvents cboDDH As Commons.UtcComboBox
    Friend WithEvents rdbChuaLock As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDalock As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaDiem2 As System.Windows.Forms.Label
    Friend WithEvents lbaDiem3 As System.Windows.Forms.Label
    Friend WithEvents cboDiem2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiem3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiem1 As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
