<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDonDatHang
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.lblSoDDH = New System.Windows.Forms.Label
        Me.lblNgay = New System.Windows.Forms.Label
        Me.lblSoDeXuat = New System.Windows.Forms.Label
        Me.lblKhachHang = New System.Windows.Forms.Label
        Me.lblDiaChi = New System.Windows.Forms.Label
        Me.lblFax = New System.Windows.Forms.Label
        Me.grpGhiChu = New System.Windows.Forms.GroupBox
        Me.txtNguoiLienHe = New Commons.utcTextBox
        Me.txtThoiHan = New Commons.utcTextBox
        Me.txtDienThoai = New Commons.utcTextBox
        Me.txtDiaChi1 = New Commons.utcTextBox
        Me.txtFax1 = New Commons.utcTextBox
        Me.lblNguoiLienHe = New System.Windows.Forms.Label
        Me.lblThoiHan = New System.Windows.Forms.Label
        Me.lblDiaChi1 = New System.Windows.Forms.Label
        Me.lblDienThoai = New System.Windows.Forms.Label
        Me.lblFax1 = New System.Windows.Forms.Label
        Me.dtNgay = New System.Windows.Forms.DateTimePicker
        Me.grdDAnhsachPt = New System.Windows.Forms.DataGridView
        Me.BtnSua = New System.Windows.Forms.Button
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.lblTongTruocThue = New System.Windows.Forms.Label
        Me.lblThueVAT = New System.Windows.Forms.Label
        Me.lblTongSauThue = New System.Windows.Forms.Label
        Me.lblXacNhan = New System.Windows.Forms.Label
        Me.lblNguoiDuyet = New System.Windows.Forms.Label
        Me.lblNguoiDatHang = New System.Windows.Forms.Label
        Me.BtnChonVatTu = New System.Windows.Forms.Button
        Me.BtnIn = New System.Windows.Forms.Button
        Me.lblVat = New System.Windows.Forms.Label
        Me.lblPhanTram = New System.Windows.Forms.Label
        Me.chkDuyet = New System.Windows.Forms.CheckBox
        Me.BtnDuyet = New System.Windows.Forms.Button
        Me.TXTVat = New Commons.utcTextBox
        Me.txtNguoiDatHang = New Commons.utcTextBox
        Me.txtNguoiDuyet = New Commons.utcTextBox
        Me.txtXacNhan = New Commons.utcTextBox
        Me.txtTongST = New Commons.utcTextBox
        Me.txtThueVAT = New Commons.utcTextBox
        Me.txtTongTT = New Commons.utcTextBox
        Me.txtFax = New Commons.utcTextBox
        Me.txtDiaChi = New Commons.utcTextBox
        Me.cboKhachHang = New Commons.UtcComboBox
        Me.cboSoPR = New Commons.UtcComboBox
        Me.txtMS_DDH = New Commons.utcTextBox
        Me.cboMS_DDH = New Commons.UtcComboBox
        Me.txtSoPR = New Commons.utcTextBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGhiChu.SuspendLayout()
        CType(Me.grdDAnhsachPt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(5, 0)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(833, 34)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "ĐƠN ĐẶT HÀNG"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSoDDH
        '
        Me.lblSoDDH.AutoSize = True
        Me.lblSoDDH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoDDH.Location = New System.Drawing.Point(9, 45)
        Me.lblSoDDH.Name = "lblSoDDH"
        Me.lblSoDDH.Size = New System.Drawing.Size(49, 13)
        Me.lblSoDDH.TabIndex = 1
        Me.lblSoDDH.Text = "số ĐĐH"
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgay.Location = New System.Drawing.Point(247, 45)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(35, 13)
        Me.lblNgay.TabIndex = 2
        Me.lblNgay.Text = "Ngày"
        '
        'lblSoDeXuat
        '
        Me.lblSoDeXuat.AutoSize = True
        Me.lblSoDeXuat.Location = New System.Drawing.Point(475, 45)
        Me.lblSoDeXuat.Name = "lblSoDeXuat"
        Me.lblSoDeXuat.Size = New System.Drawing.Size(35, 13)
        Me.lblSoDeXuat.TabIndex = 3
        Me.lblSoDeXuat.Text = "Số PR"
        '
        'lblKhachHang
        '
        Me.lblKhachHang.AutoSize = True
        Me.lblKhachHang.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKhachHang.Location = New System.Drawing.Point(9, 68)
        Me.lblKhachHang.Name = "lblKhachHang"
        Me.lblKhachHang.Size = New System.Drawing.Size(70, 13)
        Me.lblKhachHang.TabIndex = 4
        Me.lblKhachHang.Text = "KhachHang"
        '
        'lblDiaChi
        '
        Me.lblDiaChi.AutoSize = True
        Me.lblDiaChi.Location = New System.Drawing.Point(475, 68)
        Me.lblDiaChi.Name = "lblDiaChi"
        Me.lblDiaChi.Size = New System.Drawing.Size(39, 13)
        Me.lblDiaChi.TabIndex = 5
        Me.lblDiaChi.Text = "Địa chỉ"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Location = New System.Drawing.Point(247, 68)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(25, 13)
        Me.lblFax.TabIndex = 6
        Me.lblFax.Text = "Fax"
        '
        'grpGhiChu
        '
        Me.grpGhiChu.Controls.Add(Me.txtNguoiLienHe)
        Me.grpGhiChu.Controls.Add(Me.txtThoiHan)
        Me.grpGhiChu.Controls.Add(Me.txtDienThoai)
        Me.grpGhiChu.Controls.Add(Me.txtDiaChi1)
        Me.grpGhiChu.Controls.Add(Me.txtFax1)
        Me.grpGhiChu.Controls.Add(Me.lblNguoiLienHe)
        Me.grpGhiChu.Controls.Add(Me.lblThoiHan)
        Me.grpGhiChu.Controls.Add(Me.lblDiaChi1)
        Me.grpGhiChu.Controls.Add(Me.lblDienThoai)
        Me.grpGhiChu.Controls.Add(Me.lblFax1)
        Me.grpGhiChu.ForeColor = System.Drawing.Color.Maroon
        Me.grpGhiChu.Location = New System.Drawing.Point(11, 119)
        Me.grpGhiChu.Name = "grpGhiChu"
        Me.grpGhiChu.Size = New System.Drawing.Size(825, 66)
        Me.grpGhiChu.TabIndex = 11
        Me.grpGhiChu.TabStop = False
        Me.grpGhiChu.Text = "Thông tin liên hệ"
        '
        'txtNguoiLienHe
        '
        Me.txtNguoiLienHe.BackColor = System.Drawing.Color.White
        Me.txtNguoiLienHe.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNguoiLienHe.FieldName = ""
        Me.txtNguoiLienHe.IsNull = True
        Me.txtNguoiLienHe.Location = New System.Drawing.Point(674, 35)
        Me.txtNguoiLienHe.Name = "txtNguoiLienHe"
        Me.txtNguoiLienHe.Size = New System.Drawing.Size(143, 21)
        Me.txtNguoiLienHe.TabIndex = 18
        Me.txtNguoiLienHe.TextTypeMode = Commons.TypeMode.None
        '
        'txtThoiHan
        '
        Me.txtThoiHan.BackColor = System.Drawing.Color.White
        Me.txtThoiHan.ErrorProviderControl = Me.ErrorProvider1
        Me.txtThoiHan.FieldName = ""
        Me.txtThoiHan.IsNull = True
        Me.txtThoiHan.Location = New System.Drawing.Point(397, 35)
        Me.txtThoiHan.Name = "txtThoiHan"
        Me.txtThoiHan.Size = New System.Drawing.Size(162, 21)
        Me.txtThoiHan.TabIndex = 17
        Me.txtThoiHan.TextTypeMode = Commons.TypeMode.None
        '
        'txtDienThoai
        '
        Me.txtDienThoai.BackColor = System.Drawing.Color.White
        Me.txtDienThoai.ErrorProviderControl = Me.ErrorProvider1
        Me.txtDienThoai.FieldName = ""
        Me.txtDienThoai.IsNull = True
        Me.txtDienThoai.Location = New System.Drawing.Point(101, 39)
        Me.txtDienThoai.Name = "txtDienThoai"
        Me.txtDienThoai.Size = New System.Drawing.Size(164, 21)
        Me.txtDienThoai.TabIndex = 16
        Me.txtDienThoai.TextTypeMode = Commons.TypeMode.None
        '
        'txtDiaChi1
        '
        Me.txtDiaChi1.BackColor = System.Drawing.Color.White
        Me.txtDiaChi1.ErrorProviderControl = Me.ErrorProvider1
        Me.txtDiaChi1.FieldName = ""
        Me.txtDiaChi1.IsNull = True
        Me.txtDiaChi1.Location = New System.Drawing.Point(397, 12)
        Me.txtDiaChi1.Name = "txtDiaChi1"
        Me.txtDiaChi1.Size = New System.Drawing.Size(422, 21)
        Me.txtDiaChi1.TabIndex = 15
        Me.txtDiaChi1.TextTypeMode = Commons.TypeMode.None
        '
        'txtFax1
        '
        Me.txtFax1.BackColor = System.Drawing.Color.White
        Me.txtFax1.ErrorProviderControl = Me.ErrorProvider1
        Me.txtFax1.FieldName = ""
        Me.txtFax1.IsNull = True
        Me.txtFax1.Location = New System.Drawing.Point(101, 16)
        Me.txtFax1.Name = "txtFax1"
        Me.txtFax1.Size = New System.Drawing.Size(164, 21)
        Me.txtFax1.TabIndex = 14
        Me.txtFax1.TextTypeMode = Commons.TypeMode.None
        '
        'lblNguoiLienHe
        '
        Me.lblNguoiLienHe.AutoSize = True
        Me.lblNguoiLienHe.ForeColor = System.Drawing.Color.Black
        Me.lblNguoiLienHe.Location = New System.Drawing.Point(564, 36)
        Me.lblNguoiLienHe.Name = "lblNguoiLienHe"
        Me.lblNguoiLienHe.Size = New System.Drawing.Size(69, 13)
        Me.lblNguoiLienHe.TabIndex = 12
        Me.lblNguoiLienHe.Text = "Người liên hệ"
        '
        'lblThoiHan
        '
        Me.lblThoiHan.AutoSize = True
        Me.lblThoiHan.ForeColor = System.Drawing.Color.Black
        Me.lblThoiHan.Location = New System.Drawing.Point(271, 35)
        Me.lblThoiHan.Name = "lblThoiHan"
        Me.lblThoiHan.Size = New System.Drawing.Size(104, 13)
        Me.lblThoiHan.TabIndex = 11
        Me.lblThoiHan.Text = "Thời hạn thanh tóan"
        '
        'lblDiaChi1
        '
        Me.lblDiaChi1.AutoSize = True
        Me.lblDiaChi1.ForeColor = System.Drawing.Color.Black
        Me.lblDiaChi1.Location = New System.Drawing.Point(271, 16)
        Me.lblDiaChi1.Name = "lblDiaChi1"
        Me.lblDiaChi1.Size = New System.Drawing.Size(89, 13)
        Me.lblDiaChi1.TabIndex = 10
        Me.lblDiaChi1.Text = "Địa chỉ giao hàng"
        '
        'lblDienThoai
        '
        Me.lblDienThoai.AutoSize = True
        Me.lblDienThoai.ForeColor = System.Drawing.Color.Black
        Me.lblDienThoai.Location = New System.Drawing.Point(6, 43)
        Me.lblDienThoai.Name = "lblDienThoai"
        Me.lblDienThoai.Size = New System.Drawing.Size(56, 13)
        Me.lblDienThoai.TabIndex = 9
        Me.lblDienThoai.Text = "Điện thọai"
        '
        'lblFax1
        '
        Me.lblFax1.AutoSize = True
        Me.lblFax1.ForeColor = System.Drawing.Color.Black
        Me.lblFax1.Location = New System.Drawing.Point(6, 20)
        Me.lblFax1.Name = "lblFax1"
        Me.lblFax1.Size = New System.Drawing.Size(25, 13)
        Me.lblFax1.TabIndex = 8
        Me.lblFax1.Text = "Fax"
        '
        'dtNgay
        '
        Me.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtNgay.Location = New System.Drawing.Point(327, 41)
        Me.dtNgay.Name = "dtNgay"
        Me.dtNgay.Size = New System.Drawing.Size(144, 21)
        Me.dtNgay.TabIndex = 2
        '
        'grdDAnhsachPt
        '
        Me.grdDAnhsachPt.AllowUserToAddRows = False
        Me.grdDAnhsachPt.AllowUserToDeleteRows = False
        Me.grdDAnhsachPt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDAnhsachPt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDAnhsachPt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDAnhsachPt.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDAnhsachPt.Location = New System.Drawing.Point(11, 214)
        Me.grdDAnhsachPt.Name = "grdDAnhsachPt"
        Me.grdDAnhsachPt.Size = New System.Drawing.Size(825, 248)
        Me.grdDAnhsachPt.TabIndex = 14
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Location = New System.Drawing.Point(512, 508)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 17
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(430, 508)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 16
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(676, 508)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 20
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(757, 508)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 21
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(676, 508)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 18
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(757, 508)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 19
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'lblTongTruocThue
        '
        Me.lblTongTruocThue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTongTruocThue.AutoSize = True
        Me.lblTongTruocThue.ForeColor = System.Drawing.Color.Black
        Me.lblTongTruocThue.Location = New System.Drawing.Point(2, 472)
        Me.lblTongTruocThue.Name = "lblTongTruocThue"
        Me.lblTongTruocThue.Size = New System.Drawing.Size(119, 13)
        Me.lblTongTruocThue.TabIndex = 19
        Me.lblTongTruocThue.Text = "Tổng cộng (trước thuế)"
        '
        'lblThueVAT
        '
        Me.lblThueVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblThueVAT.AutoSize = True
        Me.lblThueVAT.ForeColor = System.Drawing.Color.Black
        Me.lblThueVAT.Location = New System.Drawing.Point(2, 492)
        Me.lblThueVAT.Name = "lblThueVAT"
        Me.lblThueVAT.Size = New System.Drawing.Size(53, 13)
        Me.lblThueVAT.TabIndex = 22
        Me.lblThueVAT.Text = "Thuế VAT"
        '
        'lblTongSauThue
        '
        Me.lblTongSauThue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTongSauThue.AutoSize = True
        Me.lblTongSauThue.ForeColor = System.Drawing.Color.Black
        Me.lblTongSauThue.Location = New System.Drawing.Point(2, 514)
        Me.lblTongSauThue.Name = "lblTongSauThue"
        Me.lblTongSauThue.Size = New System.Drawing.Size(110, 13)
        Me.lblTongSauThue.TabIndex = 23
        Me.lblTongSauThue.Text = "Tổng cộng (sau thuế)"
        '
        'lblXacNhan
        '
        Me.lblXacNhan.AutoSize = True
        Me.lblXacNhan.Location = New System.Drawing.Point(9, 90)
        Me.lblXacNhan.Name = "lblXacNhan"
        Me.lblXacNhan.Size = New System.Drawing.Size(51, 13)
        Me.lblXacNhan.TabIndex = 26
        Me.lblXacNhan.Text = "Xác nhận"
        '
        'lblNguoiDuyet
        '
        Me.lblNguoiDuyet.AutoSize = True
        Me.lblNguoiDuyet.Location = New System.Drawing.Point(247, 90)
        Me.lblNguoiDuyet.Name = "lblNguoiDuyet"
        Me.lblNguoiDuyet.Size = New System.Drawing.Size(66, 13)
        Me.lblNguoiDuyet.TabIndex = 27
        Me.lblNguoiDuyet.Text = "Người duyệt"
        '
        'lblNguoiDatHang
        '
        Me.lblNguoiDatHang.AutoSize = True
        Me.lblNguoiDatHang.Location = New System.Drawing.Point(475, 90)
        Me.lblNguoiDatHang.Name = "lblNguoiDatHang"
        Me.lblNguoiDatHang.Size = New System.Drawing.Size(81, 13)
        Me.lblNguoiDatHang.TabIndex = 28
        Me.lblNguoiDatHang.Text = "Ngưởi đặt hàng"
        '
        'BtnChonVatTu
        '
        Me.BtnChonVatTu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonVatTu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChonVatTu.ForeColor = System.Drawing.Color.Blue
        Me.BtnChonVatTu.Location = New System.Drawing.Point(426, 472)
        Me.BtnChonVatTu.Name = "BtnChonVatTu"
        Me.BtnChonVatTu.Size = New System.Drawing.Size(130, 25)
        Me.BtnChonVatTu.TabIndex = 32
        Me.BtnChonVatTu.Text = "Chọn vật tư"
        Me.BtnChonVatTu.UseVisualStyleBackColor = True
        '
        'BtnIn
        '
        Me.BtnIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIn.ForeColor = System.Drawing.Color.Red
        Me.BtnIn.Location = New System.Drawing.Point(595, 508)
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(81, 25)
        Me.BtnIn.TabIndex = 33
        Me.BtnIn.Text = "&In"
        Me.BtnIn.UseVisualStyleBackColor = True
        '
        'lblVat
        '
        Me.lblVat.AutoSize = True
        Me.lblVat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVat.Location = New System.Drawing.Point(754, 45)
        Me.lblVat.Name = "lblVat"
        Me.lblVat.Size = New System.Drawing.Size(29, 13)
        Me.lblVat.TabIndex = 34
        Me.lblVat.Text = "VAT"
        '
        'lblPhanTram
        '
        Me.lblPhanTram.AutoSize = True
        Me.lblPhanTram.Location = New System.Drawing.Point(820, 45)
        Me.lblPhanTram.Name = "lblPhanTram"
        Me.lblPhanTram.Size = New System.Drawing.Size(18, 13)
        Me.lblPhanTram.TabIndex = 36
        Me.lblPhanTram.Text = "%"
        '
        'chkDuyet
        '
        Me.chkDuyet.AutoSize = True
        Me.chkDuyet.Checked = True
        Me.chkDuyet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDuyet.ForeColor = System.Drawing.Color.Maroon
        Me.chkDuyet.Location = New System.Drawing.Point(323, 191)
        Me.chkDuyet.Name = "chkDuyet"
        Me.chkDuyet.Size = New System.Drawing.Size(197, 17)
        Me.chkDuyet.TabIndex = 37
        Me.chkDuyet.Text = "Đơn đặt hàng chưa duyệt/đã duyệt"
        Me.chkDuyet.UseVisualStyleBackColor = True
        '
        'BtnDuyet
        '
        Me.BtnDuyet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDuyet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDuyet.ForeColor = System.Drawing.Color.Maroon
        Me.BtnDuyet.Location = New System.Drawing.Point(307, 508)
        Me.BtnDuyet.Name = "BtnDuyet"
        Me.BtnDuyet.Size = New System.Drawing.Size(98, 25)
        Me.BtnDuyet.TabIndex = 38
        Me.BtnDuyet.Text = "Duyệt"
        Me.BtnDuyet.UseVisualStyleBackColor = True
        '
        'TXTVat
        '
        Me.TXTVat.BackColor = System.Drawing.Color.White
        Me.TXTVat.ErrorProviderControl = Me.ErrorProvider1
        Me.TXTVat.FieldName = ""
        Me.TXTVat.IsNull = False
        Me.TXTVat.Location = New System.Drawing.Point(786, 41)
        Me.TXTVat.Name = "TXTVat"
        Me.TXTVat.Size = New System.Drawing.Size(30, 21)
        Me.TXTVat.TabIndex = 5
        Me.TXTVat.TextTypeMode = Commons.TypeMode.None
        '
        'txtNguoiDatHang
        '
        Me.txtNguoiDatHang.BackColor = System.Drawing.Color.White
        Me.txtNguoiDatHang.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNguoiDatHang.FieldName = ""
        Me.txtNguoiDatHang.IsNull = True
        Me.txtNguoiDatHang.Location = New System.Drawing.Point(562, 87)
        Me.txtNguoiDatHang.Name = "txtNguoiDatHang"
        Me.txtNguoiDatHang.Size = New System.Drawing.Size(274, 21)
        Me.txtNguoiDatHang.TabIndex = 10
        Me.txtNguoiDatHang.TextTypeMode = Commons.TypeMode.None
        '
        'txtNguoiDuyet
        '
        Me.txtNguoiDuyet.BackColor = System.Drawing.Color.White
        Me.txtNguoiDuyet.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNguoiDuyet.FieldName = ""
        Me.txtNguoiDuyet.IsNull = True
        Me.txtNguoiDuyet.Location = New System.Drawing.Point(327, 87)
        Me.txtNguoiDuyet.Name = "txtNguoiDuyet"
        Me.txtNguoiDuyet.Size = New System.Drawing.Size(144, 21)
        Me.txtNguoiDuyet.TabIndex = 9
        Me.txtNguoiDuyet.TextTypeMode = Commons.TypeMode.None
        '
        'txtXacNhan
        '
        Me.txtXacNhan.BackColor = System.Drawing.Color.White
        Me.txtXacNhan.ErrorProviderControl = Me.ErrorProvider1
        Me.txtXacNhan.FieldName = ""
        Me.txtXacNhan.IsNull = True
        Me.txtXacNhan.Location = New System.Drawing.Point(86, 87)
        Me.txtXacNhan.Name = "txtXacNhan"
        Me.txtXacNhan.Size = New System.Drawing.Size(154, 21)
        Me.txtXacNhan.TabIndex = 8
        Me.txtXacNhan.TextTypeMode = Commons.TypeMode.None
        '
        'txtTongST
        '
        Me.txtTongST.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTongST.BackColor = System.Drawing.Color.White
        Me.txtTongST.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongST.FieldName = ""
        Me.txtTongST.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongST.IsNull = True
        Me.txtTongST.Location = New System.Drawing.Point(155, 511)
        Me.txtTongST.Name = "txtTongST"
        Me.txtTongST.ReadOnly = True
        Me.txtTongST.Size = New System.Drawing.Size(146, 21)
        Me.txtTongST.TabIndex = 25
        Me.txtTongST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTongST.TextTypeMode = Commons.TypeMode.None
        '
        'txtThueVAT
        '
        Me.txtThueVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtThueVAT.BackColor = System.Drawing.Color.White
        Me.txtThueVAT.ErrorProviderControl = Me.ErrorProvider1
        Me.txtThueVAT.FieldName = ""
        Me.txtThueVAT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThueVAT.IsNull = True
        Me.txtThueVAT.Location = New System.Drawing.Point(155, 489)
        Me.txtThueVAT.Name = "txtThueVAT"
        Me.txtThueVAT.ReadOnly = True
        Me.txtThueVAT.Size = New System.Drawing.Size(146, 21)
        Me.txtThueVAT.TabIndex = 24
        Me.txtThueVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtThueVAT.TextTypeMode = Commons.TypeMode.None
        '
        'txtTongTT
        '
        Me.txtTongTT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTongTT.BackColor = System.Drawing.Color.White
        Me.txtTongTT.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongTT.FieldName = ""
        Me.txtTongTT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongTT.IsNull = True
        Me.txtTongTT.Location = New System.Drawing.Point(155, 467)
        Me.txtTongTT.Name = "txtTongTT"
        Me.txtTongTT.ReadOnly = True
        Me.txtTongTT.Size = New System.Drawing.Size(146, 21)
        Me.txtTongTT.TabIndex = 19
        Me.txtTongTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTongTT.TextTypeMode = Commons.TypeMode.None
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.Color.White
        Me.txtFax.ErrorProviderControl = Me.ErrorProvider1
        Me.txtFax.FieldName = ""
        Me.txtFax.IsNull = True
        Me.txtFax.Location = New System.Drawing.Point(327, 64)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.Size = New System.Drawing.Size(144, 21)
        Me.txtFax.TabIndex = 6
        Me.txtFax.TextTypeMode = Commons.TypeMode.None
        '
        'txtDiaChi
        '
        Me.txtDiaChi.BackColor = System.Drawing.Color.White
        Me.txtDiaChi.ErrorProviderControl = Me.ErrorProvider1
        Me.txtDiaChi.FieldName = ""
        Me.txtDiaChi.IsNull = True
        Me.txtDiaChi.Location = New System.Drawing.Point(562, 64)
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.ReadOnly = True
        Me.txtDiaChi.Size = New System.Drawing.Size(274, 21)
        Me.txtDiaChi.TabIndex = 7
        Me.txtDiaChi.TextTypeMode = Commons.TypeMode.None
        '
        'cboKhachHang
        '
        Me.cboKhachHang.AssemblyName = ""
        Me.cboKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKhachHang.BackColor = System.Drawing.Color.White
        Me.cboKhachHang.ClassName = ""
        Me.cboKhachHang.Display = ""
        Me.cboKhachHang.DropDownWidth = 250
        Me.cboKhachHang.ErrorProviderControl = Me.ErrorProvider1
        Me.cboKhachHang.FormattingEnabled = True
        Me.cboKhachHang.IsAll = False
        Me.cboKhachHang.IsNew = False
        Me.cboKhachHang.ItemAll = " < ALL > "
        Me.cboKhachHang.ItemNew = "...New"
        Me.cboKhachHang.Location = New System.Drawing.Point(86, 64)
        Me.cboKhachHang.MethodName = ""
        Me.cboKhachHang.Name = "cboKhachHang"
        Me.cboKhachHang.Param = ""
        Me.cboKhachHang.Size = New System.Drawing.Size(154, 21)
        Me.cboKhachHang.StoreName = ""
        Me.cboKhachHang.TabIndex = 5
        Me.cboKhachHang.Table = Nothing
        Me.cboKhachHang.TextReadonly = False
        Me.cboKhachHang.Value = ""
        '
        'cboSoPR
        '
        Me.cboSoPR.AssemblyName = ""
        Me.cboSoPR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSoPR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSoPR.BackColor = System.Drawing.Color.White
        Me.cboSoPR.ClassName = ""
        Me.cboSoPR.Display = ""
        Me.cboSoPR.ErrorProviderControl = Me.ErrorProvider1
        Me.cboSoPR.FormattingEnabled = True
        Me.cboSoPR.IsAll = False
        Me.cboSoPR.IsNew = False
        Me.cboSoPR.ItemAll = " < ALL > "
        Me.cboSoPR.ItemNew = "...New"
        Me.cboSoPR.Location = New System.Drawing.Point(562, 41)
        Me.cboSoPR.MethodName = ""
        Me.cboSoPR.Name = "cboSoPR"
        Me.cboSoPR.Param = ""
        Me.cboSoPR.Size = New System.Drawing.Size(186, 21)
        Me.cboSoPR.StoreName = ""
        Me.cboSoPR.TabIndex = 3
        Me.cboSoPR.Table = Nothing
        Me.cboSoPR.TextReadonly = False
        Me.cboSoPR.Value = ""
        '
        'txtMS_DDH
        '
        Me.txtMS_DDH.BackColor = System.Drawing.Color.White
        Me.txtMS_DDH.ErrorProviderControl = Me.ErrorProvider1
        Me.txtMS_DDH.FieldName = ""
        Me.txtMS_DDH.IsNull = False
        Me.txtMS_DDH.Location = New System.Drawing.Point(86, 41)
        Me.txtMS_DDH.Name = "txtMS_DDH"
        Me.txtMS_DDH.Size = New System.Drawing.Size(154, 21)
        Me.txtMS_DDH.TabIndex = 1
        Me.txtMS_DDH.TextTypeMode = Commons.TypeMode.None
        '
        'cboMS_DDH
        '
        Me.cboMS_DDH.AssemblyName = ""
        Me.cboMS_DDH.BackColor = System.Drawing.Color.White
        Me.cboMS_DDH.ClassName = ""
        Me.cboMS_DDH.Display = ""
        Me.cboMS_DDH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMS_DDH.ErrorProviderControl = Me.ErrorProvider1
        Me.cboMS_DDH.FormattingEnabled = True
        Me.cboMS_DDH.IsAll = False
        Me.cboMS_DDH.IsNew = False
        Me.cboMS_DDH.ItemAll = " < ALL > "
        Me.cboMS_DDH.ItemNew = "...New"
        Me.cboMS_DDH.Location = New System.Drawing.Point(86, 41)
        Me.cboMS_DDH.MethodName = ""
        Me.cboMS_DDH.Name = "cboMS_DDH"
        Me.cboMS_DDH.Param = ""
        Me.cboMS_DDH.Size = New System.Drawing.Size(154, 21)
        Me.cboMS_DDH.StoreName = ""
        Me.cboMS_DDH.TabIndex = 8
        Me.cboMS_DDH.Table = Nothing
        Me.cboMS_DDH.TextReadonly = False
        Me.cboMS_DDH.Value = ""
        '
        'txtSoPR
        '
        Me.txtSoPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSoPR.ErrorProviderControl = Me.ErrorProvider1
        Me.txtSoPR.FieldName = ""
        Me.txtSoPR.IsNull = False
        Me.txtSoPR.Location = New System.Drawing.Point(562, 41)
        Me.txtSoPR.Name = "txtSoPR"
        Me.txtSoPR.Size = New System.Drawing.Size(186, 21)
        Me.txtSoPR.TabIndex = 39
        Me.txtSoPR.TextTypeMode = Commons.TypeMode.None
        '
        'frmDonDatHang
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 534)
        Me.Controls.Add(Me.BtnDuyet)
        Me.Controls.Add(Me.chkDuyet)
        Me.Controls.Add(Me.lblPhanTram)
        Me.Controls.Add(Me.TXTVat)
        Me.Controls.Add(Me.lblVat)
        Me.Controls.Add(Me.BtnIn)
        Me.Controls.Add(Me.BtnChonVatTu)
        Me.Controls.Add(Me.txtNguoiDatHang)
        Me.Controls.Add(Me.txtNguoiDuyet)
        Me.Controls.Add(Me.txtXacNhan)
        Me.Controls.Add(Me.lblNguoiDatHang)
        Me.Controls.Add(Me.lblNguoiDuyet)
        Me.Controls.Add(Me.lblXacNhan)
        Me.Controls.Add(Me.txtTongST)
        Me.Controls.Add(Me.txtThueVAT)
        Me.Controls.Add(Me.txtTongTT)
        Me.Controls.Add(Me.lblTongSauThue)
        Me.Controls.Add(Me.lblThueVAT)
        Me.Controls.Add(Me.lblTongTruocThue)
        Me.Controls.Add(Me.BtnSua)
        Me.Controls.Add(Me.BtnThem)
        Me.Controls.Add(Me.BtnKhongghi)
        Me.Controls.Add(Me.BtnXoa)
        Me.Controls.Add(Me.BtnThoat)
        Me.Controls.Add(Me.grdDAnhsachPt)
        Me.Controls.Add(Me.dtNgay)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.txtDiaChi)
        Me.Controls.Add(Me.cboKhachHang)
        Me.Controls.Add(Me.cboSoPR)
        Me.Controls.Add(Me.grpGhiChu)
        Me.Controls.Add(Me.lblFax)
        Me.Controls.Add(Me.lblDiaChi)
        Me.Controls.Add(Me.lblKhachHang)
        Me.Controls.Add(Me.lblSoDeXuat)
        Me.Controls.Add(Me.lblNgay)
        Me.Controls.Add(Me.lblSoDDH)
        Me.Controls.Add(Me.lblTieuDe)
        Me.Controls.Add(Me.BtnGhi)
        Me.Controls.Add(Me.txtMS_DDH)
        Me.Controls.Add(Me.cboMS_DDH)
        Me.Controls.Add(Me.txtSoPR)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDonDatHang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDonDatHang"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGhiChu.ResumeLayout(False)
        Me.grpGhiChu.PerformLayout()
        CType(Me.grdDAnhsachPt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblSoDDH As System.Windows.Forms.Label
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblDiaChi As System.Windows.Forms.Label
    Friend WithEvents lblKhachHang As System.Windows.Forms.Label
    Friend WithEvents lblSoDeXuat As System.Windows.Forms.Label
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents grpGhiChu As System.Windows.Forms.GroupBox
    Friend WithEvents lblNguoiLienHe As System.Windows.Forms.Label
    Friend WithEvents lblThoiHan As System.Windows.Forms.Label
    Friend WithEvents lblDiaChi1 As System.Windows.Forms.Label
    Friend WithEvents lblDienThoai As System.Windows.Forms.Label
    Friend WithEvents lblFax1 As System.Windows.Forms.Label
    Friend WithEvents grdDAnhsachPt As System.Windows.Forms.DataGridView
    Friend WithEvents dtNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFax As Commons.utcTextBox
    Friend WithEvents txtDiaChi As Commons.utcTextBox
    Friend WithEvents cboKhachHang As Commons.UtcComboBox
    Friend WithEvents cboSoPR As Commons.UtcComboBox
    Friend WithEvents cboMS_DDH As Commons.UtcComboBox
    Friend WithEvents txtNguoiLienHe As Commons.utcTextBox
    Friend WithEvents txtThoiHan As Commons.utcTextBox
    Friend WithEvents txtDienThoai As Commons.utcTextBox
    Friend WithEvents txtDiaChi1 As Commons.utcTextBox
    Friend WithEvents txtFax1 As Commons.utcTextBox
    Friend WithEvents txtTongST As Commons.utcTextBox
    Friend WithEvents txtThueVAT As Commons.utcTextBox
    Friend WithEvents txtTongTT As Commons.utcTextBox
    Friend WithEvents lblTongSauThue As System.Windows.Forms.Label
    Friend WithEvents lblThueVAT As System.Windows.Forms.Label
    Friend WithEvents lblTongTruocThue As System.Windows.Forms.Label
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents txtMS_DDH As Commons.utcTextBox
    Friend WithEvents txtNguoiDatHang As Commons.utcTextBox
    Friend WithEvents txtNguoiDuyet As Commons.utcTextBox
    Friend WithEvents txtXacNhan As Commons.utcTextBox
    Friend WithEvents lblNguoiDatHang As System.Windows.Forms.Label
    Friend WithEvents lblNguoiDuyet As System.Windows.Forms.Label
    Friend WithEvents lblXacNhan As System.Windows.Forms.Label
    Friend WithEvents BtnChonVatTu As System.Windows.Forms.Button
    Friend WithEvents BtnIn As System.Windows.Forms.Button
    Friend WithEvents TXTVat As Commons.utcTextBox
    Friend WithEvents lblVat As System.Windows.Forms.Label
    Friend WithEvents lblPhanTram As System.Windows.Forms.Label
    Friend WithEvents chkDuyet As System.Windows.Forms.CheckBox
    Friend WithEvents BtnDuyet As System.Windows.Forms.Button
    Friend WithEvents txtSoPR As Commons.utcTextBox
End Class
