<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeXuatMuaHang_VMPACK
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
        Me.lblSoDeXuat = New System.Windows.Forms.Label
        Me.lblPhongYC = New System.Windows.Forms.Label
        Me.lblNgay = New System.Windows.Forms.Label
        Me.dtNgay = New System.Windows.Forms.DateTimePicker
        Me.grpDanhsachvattu = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.grdDanhsachvattu = New System.Windows.Forms.DataGridView
        Me.chkDuyet = New System.Windows.Forms.CheckBox
        Me.chxLapkehoach = New System.Windows.Forms.CheckBox
        Me.chxYeuCau = New System.Windows.Forms.CheckBox
        Me.lblGiaoCho = New System.Windows.Forms.Label
        Me.lblNguoiDuyet = New System.Windows.Forms.Label
        Me.lblNgayGiao = New System.Windows.Forms.Label
        Me.txtNgayGiao = New System.Windows.Forms.MaskedTextBox
        Me.BtnChonVatTu = New System.Windows.Forms.Button
        Me.BtnDuyet = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BtnThem = New System.Windows.Forms.Button
        Me.BtnSua = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.BtnIn = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtSoDeXuat = New Commons.utcTextBox
        Me.cbosoDeXuat = New Commons.UtcComboBox
        Me.cboPhongYC = New Commons.UtcComboBox
        Me.txtGiaoCho = New System.Windows.Forms.ComboBox
        Me.txtNguoiDuyet = New System.Windows.Forms.ComboBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachvattu.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblTieuDe
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieuDe, 6)
        Me.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTieuDe.Location = New System.Drawing.Point(3, 0)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(860, 42)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "ĐỀ XUẤT MUA HÀNG" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSoDeXuat
        '
        Me.lblSoDeXuat.AutoSize = True
        Me.lblSoDeXuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSoDeXuat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoDeXuat.Location = New System.Drawing.Point(3, 42)
        Me.lblSoDeXuat.Name = "lblSoDeXuat"
        Me.lblSoDeXuat.Size = New System.Drawing.Size(89, 27)
        Me.lblSoDeXuat.TabIndex = 1
        Me.lblSoDeXuat.Text = "Số đề xuất"
        Me.lblSoDeXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhongYC
        '
        Me.lblPhongYC.AutoSize = True
        Me.lblPhongYC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPhongYC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhongYC.Location = New System.Drawing.Point(261, 42)
        Me.lblPhongYC.Name = "lblPhongYC"
        Me.lblPhongYC.Size = New System.Drawing.Size(124, 27)
        Me.lblPhongYC.TabIndex = 2
        Me.lblPhongYC.Text = "Phòng yêu cầu"
        Me.lblPhongYC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgay.Location = New System.Drawing.Point(564, 42)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(100, 27)
        Me.lblNgay.TabIndex = 3
        Me.lblNgay.Text = "Ngày"
        Me.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtNgay
        '
        Me.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtNgay.Location = New System.Drawing.Point(670, 45)
        Me.dtNgay.Name = "dtNgay"
        Me.dtNgay.Size = New System.Drawing.Size(107, 21)
        Me.dtNgay.TabIndex = 3
        '
        'grpDanhsachvattu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachvattu, 6)
        Me.grpDanhsachvattu.Controls.Add(Me.TableLayoutPanel2)
        Me.grpDanhsachvattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachvattu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grpDanhsachvattu.Location = New System.Drawing.Point(3, 100)
        Me.grpDanhsachvattu.Name = "grpDanhsachvattu"
        Me.grpDanhsachvattu.Size = New System.Drawing.Size(860, 339)
        Me.grpDanhsachvattu.TabIndex = 7
        Me.grpDanhsachvattu.TabStop = False
        Me.grpDanhsachvattu.Text = "Danh sách phụ tùng"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.grdDanhsachvattu, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.chkDuyet, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.chxLapkehoach, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.chxYeuCau, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(854, 319)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'grdDanhsachvattu
        '
        Me.grdDanhsachvattu.AllowUserToAddRows = False
        Me.grdDanhsachvattu.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhsachvattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel2.SetColumnSpan(Me.grdDanhsachvattu, 5)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhsachvattu.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhsachvattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachvattu.Location = New System.Drawing.Point(3, 30)
        Me.grdDanhsachvattu.Name = "grdDanhsachvattu"
        Me.grdDanhsachvattu.Size = New System.Drawing.Size(848, 286)
        Me.grdDanhsachvattu.TabIndex = 0
        '
        'chkDuyet
        '
        Me.chkDuyet.AutoSize = True
        Me.chkDuyet.Checked = True
        Me.chkDuyet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDuyet.ForeColor = System.Drawing.Color.Maroon
        Me.chkDuyet.Location = New System.Drawing.Point(147, 3)
        Me.chkDuyet.Name = "chkDuyet"
        Me.chkDuyet.Size = New System.Drawing.Size(220, 17)
        Me.chkDuyet.TabIndex = 20
        Me.chkDuyet.Text = "Đề xuất mua hàng chưa duyệt/đã duyệt"
        Me.chkDuyet.UseVisualStyleBackColor = True
        '
        'chxLapkehoach
        '
        Me.chxLapkehoach.AutoSize = True
        Me.chxLapkehoach.Location = New System.Drawing.Point(388, 3)
        Me.chxLapkehoach.Name = "chxLapkehoach"
        Me.chxLapkehoach.Size = New System.Drawing.Size(112, 17)
        Me.chxLapkehoach.TabIndex = 21
        Me.chxLapkehoach.Text = "Lập kế hoạch mua"
        Me.chxLapkehoach.UseVisualStyleBackColor = True
        '
        'chxYeuCau
        '
        Me.chxYeuCau.AutoSize = True
        Me.chxYeuCau.Location = New System.Drawing.Point(567, 3)
        Me.chxYeuCau.Name = "chxYeuCau"
        Me.chxYeuCau.Size = New System.Drawing.Size(87, 17)
        Me.chxYeuCau.TabIndex = 22
        Me.chxYeuCau.Text = "Yêu cầu mua"
        Me.chxYeuCau.UseVisualStyleBackColor = True
        '
        'lblGiaoCho
        '
        Me.lblGiaoCho.AutoSize = True
        Me.lblGiaoCho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGiaoCho.Location = New System.Drawing.Point(3, 69)
        Me.lblGiaoCho.Name = "lblGiaoCho"
        Me.lblGiaoCho.Size = New System.Drawing.Size(89, 28)
        Me.lblGiaoCho.TabIndex = 16
        Me.lblGiaoCho.Text = "Giao cho"
        Me.lblGiaoCho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNguoiDuyet
        '
        Me.lblNguoiDuyet.AutoSize = True
        Me.lblNguoiDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNguoiDuyet.Location = New System.Drawing.Point(261, 69)
        Me.lblNguoiDuyet.Name = "lblNguoiDuyet"
        Me.lblNguoiDuyet.Size = New System.Drawing.Size(124, 28)
        Me.lblNguoiDuyet.TabIndex = 17
        Me.lblNguoiDuyet.Text = "Người duyệt"
        Me.lblNguoiDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayGiao
        '
        Me.lblNgayGiao.AutoSize = True
        Me.lblNgayGiao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayGiao.Location = New System.Drawing.Point(564, 69)
        Me.lblNgayGiao.Name = "lblNgayGiao"
        Me.lblNgayGiao.Size = New System.Drawing.Size(100, 28)
        Me.lblNgayGiao.TabIndex = 18
        Me.lblNgayGiao.Text = "Ngày giao"
        Me.lblNgayGiao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNgayGiao
        '
        Me.txtNgayGiao.BackColor = System.Drawing.Color.White
        Me.txtNgayGiao.Location = New System.Drawing.Point(670, 72)
        Me.txtNgayGiao.Mask = "00/00/0000"
        Me.txtNgayGiao.Name = "txtNgayGiao"
        Me.txtNgayGiao.Size = New System.Drawing.Size(107, 21)
        Me.txtNgayGiao.TabIndex = 6
        Me.txtNgayGiao.ValidatingType = GetType(Date)
        '
        'BtnChonVatTu
        '
        Me.BtnChonVatTu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonVatTu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChonVatTu.ForeColor = System.Drawing.Color.Blue
        Me.BtnChonVatTu.Location = New System.Drawing.Point(17, 5)
        Me.BtnChonVatTu.Name = "BtnChonVatTu"
        Me.BtnChonVatTu.Size = New System.Drawing.Size(130, 25)
        Me.BtnChonVatTu.TabIndex = 7
        Me.BtnChonVatTu.Text = "Chọn vật tư"
        Me.BtnChonVatTu.UseVisualStyleBackColor = True
        '
        'BtnDuyet
        '
        Me.BtnDuyet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDuyet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDuyet.ForeColor = System.Drawing.Color.Maroon
        Me.BtnDuyet.Location = New System.Drawing.Point(17, 4)
        Me.BtnDuyet.Name = "BtnDuyet"
        Me.BtnDuyet.Size = New System.Drawing.Size(130, 25)
        Me.BtnDuyet.TabIndex = 21
        Me.BtnDuyet.Text = "Duyệt"
        Me.BtnDuyet.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieuDe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSoDeXuat, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGiaoCho, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPhongYC, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPhongYC, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNguoiDuyet, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNgayGiao, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNgayGiao, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtNgay, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachvattu, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGiaoCho, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNguoiDuyet, 3, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(866, 481)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 445)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(860, 33)
        Me.Panel2.TabIndex = 23
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Controls.Add(Me.BtnThem)
        Me.Panel5.Controls.Add(Me.BtnSua)
        Me.Panel5.Controls.Add(Me.BtnXoa)
        Me.Panel5.Controls.Add(Me.BtnGhi)
        Me.Panel5.Controls.Add(Me.BtnKhongghi)
        Me.Panel5.Controls.Add(Me.BtnIn)
        Me.Panel5.Controls.Add(Me.BtnThoat)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(860, 33)
        Me.Panel5.TabIndex = 24
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BtnDuyet)
        Me.Panel3.Controls.Add(Me.BtnChonVatTu)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(208, 33)
        Me.Panel3.TabIndex = 22
        '
        'BtnThem
        '
        Me.BtnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnThem.Location = New System.Drawing.Point(335, 0)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(75, 33)
        Me.BtnThem.TabIndex = 6
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnSua
        '
        Me.BtnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.Color.Teal
        Me.BtnSua.Location = New System.Drawing.Point(410, 0)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(75, 33)
        Me.BtnSua.TabIndex = 5
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(485, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(75, 33)
        Me.BtnXoa.TabIndex = 4
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnGhi.Location = New System.Drawing.Point(560, 0)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(75, 33)
        Me.BtnGhi.TabIndex = 3
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(635, 0)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(75, 33)
        Me.BtnKhongghi.TabIndex = 2
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnIn
        '
        Me.BtnIn.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnIn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIn.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnIn.Location = New System.Drawing.Point(710, 0)
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(75, 33)
        Me.BtnIn.TabIndex = 1
        Me.BtnIn.Text = "&In"
        Me.BtnIn.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(785, 0)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(75, 33)
        Me.BtnThoat.TabIndex = 0
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSoDeXuat)
        Me.Panel1.Controls.Add(Me.cbosoDeXuat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(98, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 21)
        Me.Panel1.TabIndex = 1
        '
        'txtSoDeXuat
        '
        Me.txtSoDeXuat.BackColor = System.Drawing.Color.White
        Me.txtSoDeXuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSoDeXuat.ErrorProviderControl = Me.ErrorProvider1
        Me.txtSoDeXuat.FieldName = ""
        Me.txtSoDeXuat.IsNull = False
        Me.txtSoDeXuat.Location = New System.Drawing.Point(0, 0)
        Me.txtSoDeXuat.Name = "txtSoDeXuat"
        Me.txtSoDeXuat.Size = New System.Drawing.Size(157, 21)
        Me.txtSoDeXuat.TabIndex = 1
        Me.txtSoDeXuat.TextTypeMode = Commons.TypeMode.None
        '
        'cbosoDeXuat
        '
        Me.cbosoDeXuat.AssemblyName = ""
        Me.cbosoDeXuat.BackColor = System.Drawing.Color.White
        Me.cbosoDeXuat.ClassName = ""
        Me.cbosoDeXuat.Display = ""
        Me.cbosoDeXuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbosoDeXuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbosoDeXuat.ErrorProviderControl = Me.ErrorProvider1
        Me.cbosoDeXuat.FormattingEnabled = True
        Me.cbosoDeXuat.IsAll = False
        Me.cbosoDeXuat.IsNew = False
        Me.cbosoDeXuat.ItemAll = " < ALL > "
        Me.cbosoDeXuat.ItemNew = "...New"
        Me.cbosoDeXuat.Location = New System.Drawing.Point(0, 0)
        Me.cbosoDeXuat.MethodName = ""
        Me.cbosoDeXuat.Name = "cbosoDeXuat"
        Me.cbosoDeXuat.Param = ""
        Me.cbosoDeXuat.Size = New System.Drawing.Size(157, 21)
        Me.cbosoDeXuat.StoreName = ""
        Me.cbosoDeXuat.TabIndex = 0
        Me.cbosoDeXuat.Table = Nothing
        Me.cbosoDeXuat.TextReadonly = False
        Me.cbosoDeXuat.Value = ""
        '
        'cboPhongYC
        '
        Me.cboPhongYC.AssemblyName = ""
        Me.cboPhongYC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPhongYC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPhongYC.BackColor = System.Drawing.Color.White
        Me.cboPhongYC.ClassName = ""
        Me.cboPhongYC.Display = ""
        Me.cboPhongYC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPhongYC.ErrorProviderControl = Me.ErrorProvider1
        Me.cboPhongYC.FormattingEnabled = True
        Me.cboPhongYC.IsAll = False
        Me.cboPhongYC.IsNew = False
        Me.cboPhongYC.ItemAll = " < ALL > "
        Me.cboPhongYC.ItemNew = "...New"
        Me.cboPhongYC.Location = New System.Drawing.Point(391, 45)
        Me.cboPhongYC.MethodName = ""
        Me.cboPhongYC.Name = "cboPhongYC"
        Me.cboPhongYC.Param = ""
        Me.cboPhongYC.Size = New System.Drawing.Size(167, 21)
        Me.cboPhongYC.StoreName = ""
        Me.cboPhongYC.TabIndex = 2
        Me.cboPhongYC.Table = Nothing
        Me.cboPhongYC.TextReadonly = False
        Me.cboPhongYC.Value = ""
        '
        'txtGiaoCho
        '
        Me.txtGiaoCho.FormattingEnabled = True
        Me.txtGiaoCho.Location = New System.Drawing.Point(98, 72)
        Me.txtGiaoCho.Name = "txtGiaoCho"
        Me.txtGiaoCho.Size = New System.Drawing.Size(157, 21)
        Me.txtGiaoCho.TabIndex = 24
        '
        'txtNguoiDuyet
        '
        Me.txtNguoiDuyet.FormattingEnabled = True
        Me.txtNguoiDuyet.Location = New System.Drawing.Point(391, 72)
        Me.txtNguoiDuyet.Name = "txtNguoiDuyet"
        Me.txtNguoiDuyet.Size = New System.Drawing.Size(167, 21)
        Me.txtNguoiDuyet.TabIndex = 25
        '
        'frmDeXuatMuaHang_VMPACK
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 481)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDeXuatMuaHang_VMPACK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDeXuatMuaHang_VMPACK"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachvattu.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents dtNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboPhongYC As Commons.UtcComboBox
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents lblPhongYC As System.Windows.Forms.Label
    Friend WithEvents lblSoDeXuat As System.Windows.Forms.Label
    Friend WithEvents grpDanhsachvattu As System.Windows.Forms.GroupBox
    Friend WithEvents lblGiaoCho As System.Windows.Forms.Label
    Friend WithEvents txtNgayGiao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblNgayGiao As System.Windows.Forms.Label
    Friend WithEvents lblNguoiDuyet As System.Windows.Forms.Label
    Friend WithEvents BtnChonVatTu As System.Windows.Forms.Button
    Friend WithEvents grdDanhsachvattu As System.Windows.Forms.DataGridView
    Friend WithEvents cbosoDeXuat As Commons.UtcComboBox
    Friend WithEvents BtnDuyet As System.Windows.Forms.Button
    Friend WithEvents chkDuyet As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnIn As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtSoDeXuat As Commons.utcTextBox
    Friend WithEvents chxLapkehoach As System.Windows.Forms.CheckBox
    Friend WithEvents chxYeuCau As System.Windows.Forms.CheckBox
    Friend WithEvents txtGiaoCho As System.Windows.Forms.ComboBox
    Friend WithEvents txtNguoiDuyet As System.Windows.Forms.ComboBox
End Class
