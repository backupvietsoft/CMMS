<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCongViecHangNgay
    Inherits DevExpress.XtraEditors.XtraForm
    'Inherits DevExpress.XtraEditors.XtraForm

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
        Me.lblTieude = New System.Windows.Forms.Label()
        Me.lblNgay = New System.Windows.Forms.Label()
        Me.dtNgay = New System.Windows.Forms.DateTimePicker()
        Me.lblNoidung = New System.Windows.Forms.Label()
        Me.rtxtNoidung = New System.Windows.Forms.RichTextBox()
        Me.grpNhanvien = New System.Windows.Forms.GroupBox()
        Me.grdNhanvien = New System.Windows.Forms.DataGridView()
        Me.grdDanhsachvattu = New System.Windows.Forms.DataGridView()
        Me.grpVattu = New System.Windows.Forms.GroupBox()
        Me.grdDanhsachthietbi = New System.Windows.Forms.DataGridView()
        Me.grpDanhsachthietbi = New System.Windows.Forms.GroupBox()
        Me.lblTongCPCN = New System.Windows.Forms.Label()
        Me.lblTongCPVT = New System.Windows.Forms.Label()
        Me.BtnSua = New System.Windows.Forms.Button()
        Me.BtnXoa = New System.Windows.Forms.Button()
        Me.BtnThem = New System.Windows.Forms.Button()
        Me.BtnThoat = New System.Windows.Forms.Button()
        Me.BtnKhongghi = New System.Windows.Forms.Button()
        Me.BtnGhi = New System.Windows.Forms.Button()
        Me.BtnPBdenNC = New System.Windows.Forms.Button()
        Me.BtnPBdeuCPVT = New System.Windows.Forms.Button()
        Me.BtnPBVT = New System.Windows.Forms.Button()
        Me.BtnNVBD = New System.Windows.Forms.Button()
        Me.BtnVTBD = New System.Windows.Forms.Button()
        Me.BtnTBBD = New System.Windows.Forms.Button()
        Me.BtnXemPBVT = New System.Windows.Forms.Button()
        Me.lblSTT_CV = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDanhsachvattu = New System.Windows.Forms.GroupBox()
        Me.grdPhanBoVatTu = New System.Windows.Forms.DataGridView()
        Me.lblPhanBoChitiet = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTongCPCT = New Commons.utcTextBox()
        Me.txtTongCPVT = New Commons.utcTextBox()
        Me.cboLan = New Commons.UtcComboBox()
        Me.txtTongCPNC = New Commons.utcTextBox()
        Me.txtTongCPNV1 = New Commons.utcTextBox()
        Me.txtTongCPVT1 = New Commons.utcTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpNhanvien.SuspendLayout()
        CType(Me.grdNhanvien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVattu.SuspendLayout()
        CType(Me.grdDanhsachthietbi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachthietbi.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachvattu.SuspendLayout()
        CType(Me.grdPhanBoVatTu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.txtTongCPCT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTongCPVT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTongCPNC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTongCPNV1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTongCPVT1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTieude
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTieude, 9)
        Me.lblTieude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieude.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieude.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTieude.Location = New System.Drawing.Point(3, 0)
        Me.lblTieude.Name = "lblTieude"
        Me.lblTieude.Size = New System.Drawing.Size(1022, 55)
        Me.lblTieude.TabIndex = 0
        Me.lblTieude.Text = "CÔNG VIỆC HẰNG NGÀY"
        Me.lblTieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgay.Location = New System.Drawing.Point(3, 55)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(133, 29)
        Me.lblNgay.TabIndex = 1
        Me.lblNgay.Text = "Ngày"
        Me.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtNgay
        '
        Me.dtNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtNgay.Location = New System.Drawing.Point(142, 58)
        Me.dtNgay.Name = "dtNgay"
        Me.dtNgay.Size = New System.Drawing.Size(147, 21)
        Me.dtNgay.TabIndex = 1
        '
        'lblNoidung
        '
        Me.lblNoidung.AutoSize = True
        Me.lblNoidung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoidung.Location = New System.Drawing.Point(568, 55)
        Me.lblNoidung.Name = "lblNoidung"
        Me.lblNoidung.Size = New System.Drawing.Size(130, 29)
        Me.lblNoidung.TabIndex = 3
        Me.lblNoidung.Text = "Nội dụng"
        Me.lblNoidung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtxtNoidung
        '
        Me.rtxtNoidung.BackColor = System.Drawing.Color.White
        Me.rtxtNoidung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxtNoidung.Location = New System.Drawing.Point(704, 58)
        Me.rtxtNoidung.Name = "rtxtNoidung"
        Me.rtxtNoidung.Size = New System.Drawing.Size(225, 23)
        Me.rtxtNoidung.TabIndex = 3
        Me.rtxtNoidung.Text = ""
        '
        'grpNhanvien
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpNhanvien, 4)
        Me.grpNhanvien.Controls.Add(Me.grdNhanvien)
        Me.grpNhanvien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNhanvien.ForeColor = System.Drawing.Color.Maroon
        Me.grpNhanvien.Location = New System.Drawing.Point(3, 107)
        Me.grpNhanvien.Name = "grpNhanvien"
        Me.grpNhanvien.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grpNhanvien.Size = New System.Drawing.Size(545, 152)
        Me.grpNhanvien.TabIndex = 5
        Me.grpNhanvien.TabStop = False
        Me.grpNhanvien.Text = "Danh sách nhân viên thực hiện"
        '
        'grdNhanvien
        '
        Me.grdNhanvien.AllowUserToAddRows = False
        Me.grdNhanvien.AllowUserToDeleteRows = False
        Me.grdNhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNhanvien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNhanvien.Location = New System.Drawing.Point(3, 20)
        Me.grdNhanvien.MultiSelect = False
        Me.grdNhanvien.Name = "grdNhanvien"
        Me.grdNhanvien.ReadOnly = True
        Me.grdNhanvien.RowHeadersWidth = 25
        Me.grdNhanvien.Size = New System.Drawing.Size(539, 129)
        Me.grdNhanvien.TabIndex = 0
        '
        'grdDanhsachvattu
        '
        Me.grdDanhsachvattu.AllowUserToAddRows = False
        Me.grdDanhsachvattu.AllowUserToDeleteRows = False
        Me.grdDanhsachvattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachvattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachvattu.Location = New System.Drawing.Point(3, 20)
        Me.grdDanhsachvattu.MultiSelect = False
        Me.grdDanhsachvattu.Name = "grdDanhsachvattu"
        Me.grdDanhsachvattu.ReadOnly = True
        Me.grdDanhsachvattu.RowHeadersWidth = 25
        Me.grdDanhsachvattu.Size = New System.Drawing.Size(539, 129)
        Me.grdDanhsachvattu.TabIndex = 0
        '
        'grpVattu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpVattu, 4)
        Me.grpVattu.Controls.Add(Me.grdDanhsachvattu)
        Me.grpVattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpVattu.ForeColor = System.Drawing.Color.Maroon
        Me.grpVattu.Location = New System.Drawing.Point(3, 302)
        Me.grpVattu.Name = "grpVattu"
        Me.grpVattu.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grpVattu.Size = New System.Drawing.Size(545, 152)
        Me.grpVattu.TabIndex = 6
        Me.grpVattu.TabStop = False
        Me.grpVattu.Text = "Danh sách vật tư bảo dưỡng"
        '
        'grdDanhsachthietbi
        '
        Me.grdDanhsachthietbi.AllowUserToAddRows = False
        Me.grdDanhsachthietbi.AllowUserToDeleteRows = False
        Me.grdDanhsachthietbi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachthietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachthietbi.Location = New System.Drawing.Point(3, 20)
        Me.grdDanhsachthietbi.MultiSelect = False
        Me.grdDanhsachthietbi.Name = "grdDanhsachthietbi"
        Me.grdDanhsachthietbi.ReadOnly = True
        Me.grdDanhsachthietbi.RowHeadersWidth = 25
        Me.grdDanhsachthietbi.Size = New System.Drawing.Size(451, 129)
        Me.grdDanhsachthietbi.TabIndex = 0
        '
        'grpDanhsachthietbi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachthietbi, 4)
        Me.grpDanhsachthietbi.Controls.Add(Me.grdDanhsachthietbi)
        Me.grpDanhsachthietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachthietbi.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachthietbi.Location = New System.Drawing.Point(568, 107)
        Me.grpDanhsachthietbi.Name = "grpDanhsachthietbi"
        Me.grpDanhsachthietbi.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grpDanhsachthietbi.Size = New System.Drawing.Size(457, 152)
        Me.grpDanhsachthietbi.TabIndex = 7
        Me.grpDanhsachthietbi.TabStop = False
        Me.grpDanhsachthietbi.Text = "Danh sách thiết bị bảo dưỡng"
        '
        'lblTongCPCN
        '
        Me.lblTongCPCN.AutoSize = True
        Me.lblTongCPCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTongCPCN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTongCPCN.Location = New System.Drawing.Point(142, 262)
        Me.lblTongCPCN.Name = "lblTongCPCN"
        Me.lblTongCPCN.Size = New System.Drawing.Size(147, 26)
        Me.lblTongCPCN.TabIndex = 8
        Me.lblTongCPCN.Text = "Tổng chi phí nhân công"
        Me.lblTongCPCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTongCPVT
        '
        Me.lblTongCPVT.AutoSize = True
        Me.lblTongCPVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTongCPVT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTongCPVT.Location = New System.Drawing.Point(142, 457)
        Me.lblTongCPVT.Name = "lblTongCPVT"
        Me.lblTongCPVT.Size = New System.Drawing.Size(147, 29)
        Me.lblTongCPVT.TabIndex = 8
        Me.lblTongCPVT.Text = "Tổng chi phí vật tư"
        Me.lblTongCPVT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSua.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnSua.Location = New System.Drawing.Point(775, 2)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(81, 25)
        Me.BtnSua.TabIndex = 6
        Me.BtnSua.Text = "&Sửa"
        Me.BtnSua.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(857, 2)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 7
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(694, 2)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(81, 25)
        Me.BtnThem.TabIndex = 5
        Me.BtnThem.Text = "&Thêm"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(938, 2)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 8
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(938, 2)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 16
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(857, 2)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 15
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnPBdenNC
        '
        Me.BtnPBdenNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPBdenNC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPBdenNC.ForeColor = System.Drawing.Color.Blue
        Me.BtnPBdenNC.Location = New System.Drawing.Point(405, 2)
        Me.BtnPBdenNC.Name = "BtnPBdenNC"
        Me.BtnPBdenNC.Size = New System.Drawing.Size(200, 25)
        Me.BtnPBdenNC.TabIndex = 12
        Me.BtnPBdenNC.Text = "Phân bố đều chi phí nhân công"
        Me.BtnPBdenNC.UseVisualStyleBackColor = True
        '
        'BtnPBdeuCPVT
        '
        Me.BtnPBdeuCPVT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPBdeuCPVT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPBdeuCPVT.ForeColor = System.Drawing.Color.Blue
        Me.BtnPBdeuCPVT.Location = New System.Drawing.Point(611, 2)
        Me.BtnPBdeuCPVT.Name = "BtnPBdeuCPVT"
        Me.BtnPBdeuCPVT.Size = New System.Drawing.Size(196, 25)
        Me.BtnPBdeuCPVT.TabIndex = 13
        Me.BtnPBdeuCPVT.Text = "Phân bố đều chi phí vật tư"
        Me.BtnPBdeuCPVT.UseVisualStyleBackColor = True
        '
        'BtnPBVT
        '
        Me.BtnPBVT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPBVT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPBVT.ForeColor = System.Drawing.Color.Blue
        Me.BtnPBVT.Location = New System.Drawing.Point(462, 2)
        Me.BtnPBVT.Name = "BtnPBVT"
        Me.BtnPBVT.Size = New System.Drawing.Size(151, 25)
        Me.BtnPBVT.TabIndex = 14
        Me.BtnPBVT.Text = "Phân bố vật tư"
        Me.BtnPBVT.UseVisualStyleBackColor = True
        '
        'BtnNVBD
        '
        Me.BtnNVBD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNVBD.ForeColor = System.Drawing.Color.Blue
        Me.BtnNVBD.Location = New System.Drawing.Point(3, 265)
        Me.BtnNVBD.Name = "BtnNVBD"
        Me.BtnNVBD.Size = New System.Drawing.Size(132, 20)
        Me.BtnNVBD.TabIndex = 9
        Me.BtnNVBD.Text = "Chọn NV bảo dưỡng"
        Me.BtnNVBD.UseVisualStyleBackColor = True
        '
        'BtnVTBD
        '
        Me.BtnVTBD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVTBD.ForeColor = System.Drawing.Color.Blue
        Me.BtnVTBD.Location = New System.Drawing.Point(3, 460)
        Me.BtnVTBD.Name = "BtnVTBD"
        Me.BtnVTBD.Size = New System.Drawing.Size(133, 23)
        Me.BtnVTBD.TabIndex = 10
        Me.BtnVTBD.Text = "Chọn VT bảo dưỡng"
        Me.BtnVTBD.UseVisualStyleBackColor = True
        '
        'BtnTBBD
        '
        Me.BtnTBBD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTBBD.ForeColor = System.Drawing.Color.Blue
        Me.BtnTBBD.Location = New System.Drawing.Point(568, 265)
        Me.BtnTBBD.Name = "BtnTBBD"
        Me.BtnTBBD.Size = New System.Drawing.Size(126, 20)
        Me.BtnTBBD.TabIndex = 11
        Me.BtnTBBD.Text = "Chọn TB bảo dưỡng"
        Me.BtnTBBD.UseVisualStyleBackColor = True
        '
        'BtnXemPBVT
        '
        Me.BtnXemPBVT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXemPBVT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXemPBVT.ForeColor = System.Drawing.Color.Blue
        Me.BtnXemPBVT.Location = New System.Drawing.Point(445, 2)
        Me.BtnXemPBVT.Name = "BtnXemPBVT"
        Me.BtnXemPBVT.Size = New System.Drawing.Size(178, 25)
        Me.BtnXemPBVT.TabIndex = 4
        Me.BtnXemPBVT.Text = "Xem phân bố vật tư chi tiết"
        Me.BtnXemPBVT.UseVisualStyleBackColor = True
        '
        'lblSTT_CV
        '
        Me.lblSTT_CV.AutoSize = True
        Me.lblSTT_CV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSTT_CV.Location = New System.Drawing.Point(295, 55)
        Me.lblSTT_CV.Name = "lblSTT_CV"
        Me.lblSTT_CV.Size = New System.Drawing.Size(107, 29)
        Me.lblSTT_CV.TabIndex = 106
        Me.lblSTT_CV.Text = "Thứ tự công việc"
        Me.lblSTT_CV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grpDanhsachvattu
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDanhsachvattu, 4)
        Me.grpDanhsachvattu.Controls.Add(Me.grdPhanBoVatTu)
        Me.grpDanhsachvattu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachvattu.ForeColor = System.Drawing.Color.Maroon
        Me.grpDanhsachvattu.Location = New System.Drawing.Point(568, 302)
        Me.grpDanhsachvattu.Name = "grpDanhsachvattu"
        Me.grpDanhsachvattu.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grpDanhsachvattu.Size = New System.Drawing.Size(457, 152)
        Me.grpDanhsachvattu.TabIndex = 107
        Me.grpDanhsachvattu.TabStop = False
        Me.grpDanhsachvattu.Text = "Phân bổ chi tiết vật tư cho thiết bị"
        '
        'grdPhanBoVatTu
        '
        Me.grdPhanBoVatTu.AllowUserToAddRows = False
        Me.grdPhanBoVatTu.AllowUserToDeleteRows = False
        Me.grdPhanBoVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPhanBoVatTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPhanBoVatTu.Location = New System.Drawing.Point(3, 20)
        Me.grdPhanBoVatTu.MultiSelect = False
        Me.grdPhanBoVatTu.Name = "grdPhanBoVatTu"
        Me.grdPhanBoVatTu.RowHeadersWidth = 25
        Me.grdPhanBoVatTu.Size = New System.Drawing.Size(451, 129)
        Me.grdPhanBoVatTu.TabIndex = 0
        '
        'lblPhanBoChitiet
        '
        Me.lblPhanBoChitiet.AutoSize = True
        Me.lblPhanBoChitiet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPhanBoChitiet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhanBoChitiet.Location = New System.Drawing.Point(568, 457)
        Me.lblPhanBoChitiet.Name = "lblPhanBoChitiet"
        Me.lblPhanBoChitiet.Size = New System.Drawing.Size(130, 29)
        Me.lblPhanBoChitiet.TabIndex = 109
        Me.lblPhanBoChitiet.Text = "Tổng chi phí vật tư chi tiết cho thiết bị"
        Me.lblPhanBoChitiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTieude, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTongCPCT, 7, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPhanBoChitiet, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNgay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnVTBD, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTongCPVT, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachvattu, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTongCPVT, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSTT_CV, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnTBBD, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLan, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNoidung, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnNVBD, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.grpVattu, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.grpNhanvien, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDanhsachthietbi, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTongCPCN, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTongCPNC, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.rtxtNoidung, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTongCPNV1, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTongCPVT1, 7, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 8)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1028, 521)
        Me.TableLayoutPanel1.TabIndex = 110
        '
        'txtTongCPCT
        '
        Me.txtTongCPCT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTongCPCT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtTongCPCT, 2)
        Me.txtTongCPCT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTongCPCT.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongCPCT.FieldName = ""
        Me.txtTongCPCT.IsNull = True
        Me.txtTongCPCT.Location = New System.Drawing.Point(935, 460)
        Me.txtTongCPCT.MaxLength = 0
        Me.txtTongCPCT.Multiline = False
        Me.txtTongCPCT.Name = "txtTongCPCT"
        Me.txtTongCPCT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTongCPCT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTongCPCT.Properties.Appearance.Options.UseBackColor = True
        Me.txtTongCPCT.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTongCPCT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTongCPCT.Properties.ReadOnly = True
        Me.txtTongCPCT.ReadOnly = True
        Me.txtTongCPCT.Size = New System.Drawing.Size(90, 20)
        Me.txtTongCPCT.TabIndex = 108
        Me.txtTongCPCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTongCPCT.TextTypeMode = Commons.TypeMode.None
        '
        'txtTongCPVT
        '
        Me.txtTongCPVT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTongCPVT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtTongCPVT, 2)
        Me.txtTongCPVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTongCPVT.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongCPVT.FieldName = ""
        Me.txtTongCPVT.IsNull = True
        Me.txtTongCPVT.Location = New System.Drawing.Point(295, 460)
        Me.txtTongCPVT.MaxLength = 0
        Me.txtTongCPVT.Multiline = False
        Me.txtTongCPVT.Name = "txtTongCPVT"
        Me.txtTongCPVT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTongCPVT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTongCPVT.Properties.Appearance.Options.UseBackColor = True
        Me.txtTongCPVT.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTongCPVT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTongCPVT.Properties.ReadOnly = True
        Me.txtTongCPVT.ReadOnly = True
        Me.txtTongCPVT.Size = New System.Drawing.Size(253, 20)
        Me.txtTongCPVT.TabIndex = 0
        Me.txtTongCPVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTongCPVT.TextTypeMode = Commons.TypeMode.None
        '
        'cboLan
        '
        Me.cboLan.AssemblyName = ""
        Me.cboLan.BackColor = System.Drawing.Color.White
        Me.cboLan.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboLan.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboLan.ClassName = ""
        Me.cboLan.Display = ""
        Me.cboLan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLan.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLan.FormattingEnabled = True
        Me.cboLan.IsAll = False
        Me.cboLan.isInputNull = False
        Me.cboLan.IsNew = False
        Me.cboLan.IsNull = True
        Me.cboLan.ItemAll = " < ALL > "
        Me.cboLan.ItemNew = "...New"
        Me.cboLan.Location = New System.Drawing.Point(408, 58)
        Me.cboLan.MethodName = ""
        Me.cboLan.Name = "cboLan"
        Me.cboLan.Param = ""
        Me.cboLan.Param2 = ""
        Me.cboLan.Size = New System.Drawing.Size(140, 21)
        Me.cboLan.StoreName = ""
        Me.cboLan.TabIndex = 2
        Me.cboLan.Table = Nothing
        Me.cboLan.TextReadonly = False
        Me.cboLan.Value = ""
        '
        'txtTongCPNC
        '
        Me.txtTongCPNC.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTongCPNC.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtTongCPNC, 2)
        Me.txtTongCPNC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTongCPNC.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongCPNC.FieldName = ""
        Me.txtTongCPNC.IsNull = True
        Me.txtTongCPNC.Location = New System.Drawing.Point(295, 265)
        Me.txtTongCPNC.MaxLength = 0
        Me.txtTongCPNC.Multiline = False
        Me.txtTongCPNC.Name = "txtTongCPNC"
        Me.txtTongCPNC.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTongCPNC.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTongCPNC.Properties.Appearance.Options.UseBackColor = True
        Me.txtTongCPNC.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTongCPNC.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTongCPNC.Properties.ReadOnly = True
        Me.txtTongCPNC.ReadOnly = True
        Me.txtTongCPNC.Size = New System.Drawing.Size(253, 20)
        Me.txtTongCPNC.TabIndex = 0
        Me.txtTongCPNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTongCPNC.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'txtTongCPNV1
        '
        Me.txtTongCPNV1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTongCPNV1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtTongCPNV1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTongCPNV1.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongCPNV1.FieldName = ""
        Me.txtTongCPNV1.IsNull = True
        Me.txtTongCPNV1.Location = New System.Drawing.Point(704, 265)
        Me.txtTongCPNV1.MaxLength = 0
        Me.txtTongCPNV1.Multiline = False
        Me.txtTongCPNV1.Name = "txtTongCPNV1"
        Me.txtTongCPNV1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTongCPNV1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTongCPNV1.Properties.Appearance.Options.UseBackColor = True
        Me.txtTongCPNV1.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTongCPNV1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTongCPNV1.Properties.ReadOnly = True
        Me.txtTongCPNV1.ReadOnly = True
        Me.txtTongCPNV1.Size = New System.Drawing.Size(225, 20)
        Me.txtTongCPNV1.TabIndex = 0
        Me.txtTongCPNV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTongCPNV1.TextTypeMode = Commons.TypeMode.None
        '
        'txtTongCPVT1
        '
        Me.txtTongCPVT1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTongCPVT1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtTongCPVT1, 2)
        Me.txtTongCPVT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTongCPVT1.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongCPVT1.FieldName = ""
        Me.txtTongCPVT1.IsNull = True
        Me.txtTongCPVT1.Location = New System.Drawing.Point(935, 265)
        Me.txtTongCPVT1.MaxLength = 0
        Me.txtTongCPVT1.Multiline = False
        Me.txtTongCPVT1.Name = "txtTongCPVT1"
        Me.txtTongCPVT1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTongCPVT1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtTongCPVT1.Properties.Appearance.Options.UseBackColor = True
        Me.txtTongCPVT1.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTongCPVT1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTongCPVT1.Properties.ReadOnly = True
        Me.txtTongCPVT1.ReadOnly = True
        Me.txtTongCPVT1.Size = New System.Drawing.Size(90, 20)
        Me.txtTongCPVT1.TabIndex = 0
        Me.txtTongCPVT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTongCPVT1.TextTypeMode = Commons.TypeMode.None
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 9)
        Me.Panel1.Controls.Add(Me.BtnPBdenNC)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Controls.Add(Me.BtnPBVT)
        Me.Panel1.Controls.Add(Me.BtnSua)
        Me.Panel1.Controls.Add(Me.BtnXemPBVT)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnPBdeuCPVT)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 489)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 29)
        Me.Panel1.TabIndex = 110
        '
        'frmCongViecHangNgay
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 521)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmCongViecHangNgay"
        Me.Text = "frmCongViecHangNgay"
        Me.grpNhanvien.ResumeLayout(False)
        CType(Me.grdNhanvien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDanhsachvattu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVattu.ResumeLayout(False)
        CType(Me.grdDanhsachthietbi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachthietbi.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachvattu.ResumeLayout(False)
        CType(Me.grdPhanBoVatTu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.txtTongCPCT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTongCPVT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTongCPNC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTongCPNV1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTongCPVT1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTieude As System.Windows.Forms.Label
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents dtNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNoidung As System.Windows.Forms.Label
    Friend WithEvents rtxtNoidung As System.Windows.Forms.RichTextBox
    Friend WithEvents grpNhanvien As System.Windows.Forms.GroupBox
    Friend WithEvents grdNhanvien As System.Windows.Forms.DataGridView
    Friend WithEvents grdDanhsachvattu As System.Windows.Forms.DataGridView
    Friend WithEvents grpVattu As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachthietbi As System.Windows.Forms.DataGridView
    Friend WithEvents grpDanhsachthietbi As System.Windows.Forms.GroupBox
    Friend WithEvents lblTongCPCN As System.Windows.Forms.Label
    Friend WithEvents txtTongCPNC As Commons.utcTextBox
    Friend WithEvents lblTongCPVT As System.Windows.Forms.Label
    Friend WithEvents txtTongCPVT As Commons.utcTextBox
    Friend WithEvents BtnSua As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents txtTongCPNV1 As Commons.utcTextBox
    Friend WithEvents txtTongCPVT1 As Commons.utcTextBox
    Friend WithEvents BtnPBdenNC As System.Windows.Forms.Button
    Friend WithEvents BtnPBdeuCPVT As System.Windows.Forms.Button
    Friend WithEvents BtnPBVT As System.Windows.Forms.Button
    Friend WithEvents BtnNVBD As System.Windows.Forms.Button
    Friend WithEvents BtnVTBD As System.Windows.Forms.Button
    Friend WithEvents BtnTBBD As System.Windows.Forms.Button
    Friend WithEvents BtnXemPBVT As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboLan As Commons.UtcComboBox
    Friend WithEvents lblSTT_CV As System.Windows.Forms.Label
    Friend WithEvents txtTongCPCT As Commons.utcTextBox
    Friend WithEvents grpDanhsachvattu As System.Windows.Forms.GroupBox
    Friend WithEvents grdPhanBoVatTu As System.Windows.Forms.DataGridView
    Friend WithEvents lblPhanBoChitiet As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
