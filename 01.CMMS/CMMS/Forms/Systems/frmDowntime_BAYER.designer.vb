<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDowntime_BAYER
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
        Me.lbtTieuDe = New System.Windows.Forms.Label
        Me.dtNgay = New System.Windows.Forms.DateTimePicker
        Me.lblNgay = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabNguyennhandowntime = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblLoaiMay = New System.Windows.Forms.Label
        Me.dtDenNgay1 = New System.Windows.Forms.DateTimePicker
        Me.lblDenNgay1 = New System.Windows.Forms.Label
        Me.cboLoaiMay = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grdNhapthoigianngungmay = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnNguyenNhan = New System.Windows.Forms.Button
        Me.BtnXoa = New System.Windows.Forms.Button
        Me.BtnXoaAll = New System.Windows.Forms.Button
        Me.BtnThoat = New System.Windows.Forms.Button
        Me.BtnKhongghi = New System.Windows.Forms.Button
        Me.BtnXoaCT = New System.Windows.Forms.Button
        Me.BtnTroVe = New System.Windows.Forms.Button
        Me.BtnGhi = New System.Windows.Forms.Button
        Me.BtnThem = New System.Windows.Forms.Button
        Me.TabThongtinngungmay = New System.Windows.Forms.TabPage
        Me.cboNhomMay = New Commons.UtcComboBox
        Me.lblNhomTB = New System.Windows.Forms.Label
        Me.lblLoaiTB = New System.Windows.Forms.Label
        Me.lblDiaDiem = New System.Windows.Forms.Label
        Me.BtnIn = New System.Windows.Forms.Button
        Me.BtnThoat1 = New System.Windows.Forms.Button
        Me.grpThoigianngungmay = New System.Windows.Forms.GroupBox
        Me.grdDanhsachthoigianngungmay = New System.Windows.Forms.DataGridView
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.lblTungay = New System.Windows.Forms.Label
        Me.lblThietbi = New System.Windows.Forms.Label
        Me.dtDengnay = New System.Windows.Forms.DateTimePicker
        Me.dtTungay = New System.Windows.Forms.DateTimePicker
        Me.cboLoaiTB = New Commons.UtcComboBox
        Me.cboDiaDiem = New Commons.UtcComboBox
        Me.cboThietbi = New Commons.UtcComboBox
        Me.TabControl1.SuspendLayout()
        Me.TabNguyennhandowntime.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNhapthoigianngungmay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabThongtinngungmay.SuspendLayout()
        Me.grpThoigianngungmay.SuspendLayout()
        CType(Me.grdDanhsachthoigianngungmay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbtTieuDe
        '
        Me.lbtTieuDe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbtTieuDe.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.lbtTieuDe.Location = New System.Drawing.Point(12, 5)
        Me.lbtTieuDe.Name = "lbtTieuDe"
        Me.lbtTieuDe.Size = New System.Drawing.Size(829, 36)
        Me.lbtTieuDe.TabIndex = 0
        Me.lbtTieuDe.Text = "DOWN TIME"
        Me.lbtTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtNgay
        '
        Me.dtNgay.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtNgay.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtNgay.Location = New System.Drawing.Point(449, 3)
        Me.dtNgay.Name = "dtNgay"
        Me.dtNgay.Size = New System.Drawing.Size(125, 21)
        Me.dtNgay.TabIndex = 5
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgay.Location = New System.Drawing.Point(355, 0)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(88, 30)
        Me.lblNgay.TabIndex = 6
        Me.lblNgay.Text = "Ngày"
        Me.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabNguyennhandowntime)
        Me.TabControl1.Controls.Add(Me.TabThongtinngungmay)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(850, 543)
        Me.TabControl1.TabIndex = 17
        '
        'TabNguyennhandowntime
        '
        Me.TabNguyennhandowntime.Controls.Add(Me.TableLayoutPanel1)
        Me.TabNguyennhandowntime.Location = New System.Drawing.Point(4, 22)
        Me.TabNguyennhandowntime.Name = "TabNguyennhandowntime"
        Me.TabNguyennhandowntime.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNguyennhandowntime.Size = New System.Drawing.Size(842, 517)
        Me.TabNguyennhandowntime.TabIndex = 0
        Me.TabNguyennhandowntime.Text = "Nhập thời gian ngưng máy"
        Me.TabNguyennhandowntime.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiMay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtDenNgay1, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenNgay1, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiMay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNgay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtNgay, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grdNhapthoigianngungmay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(836, 511)
        Me.TableLayoutPanel1.TabIndex = 26
        '
        'lblLoaiMay
        '
        Me.lblLoaiMay.AutoSize = True
        Me.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiMay.Location = New System.Drawing.Point(40, 0)
        Me.lblLoaiMay.Name = "lblLoaiMay"
        Me.lblLoaiMay.Size = New System.Drawing.Size(103, 30)
        Me.lblLoaiMay.TabIndex = 19
        Me.lblLoaiMay.Text = "Loại máy"
        Me.lblLoaiMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtDenNgay1
        '
        Me.dtDenNgay1.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtDenNgay1.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtDenNgay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDenNgay1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenNgay1.Location = New System.Drawing.Point(681, 3)
        Me.dtDenNgay1.Name = "dtDenNgay1"
        Me.dtDenNgay1.Size = New System.Drawing.Size(115, 21)
        Me.dtDenNgay1.TabIndex = 24
        '
        'lblDenNgay1
        '
        Me.lblDenNgay1.AutoSize = True
        Me.lblDenNgay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNgay1.Location = New System.Drawing.Point(580, 0)
        Me.lblDenNgay1.Name = "lblDenNgay1"
        Me.lblDenNgay1.Size = New System.Drawing.Size(95, 30)
        Me.lblDenNgay1.TabIndex = 25
        Me.lblDenNgay1.Text = "Ngày"
        Me.lblDenNgay1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoaiMay
        '
        Me.cboLoaiMay.AssemblyName = ""
        Me.cboLoaiMay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLoaiMay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoaiMay.BackColor = System.Drawing.SystemColors.Window
        Me.cboLoaiMay.ClassName = ""
        Me.cboLoaiMay.Display = ""
        Me.cboLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiMay.DropDownWidth = 220
        Me.cboLoaiMay.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiMay.FormattingEnabled = True
        Me.cboLoaiMay.IsAll = True
        Me.cboLoaiMay.IsNew = False
        Me.cboLoaiMay.ItemAll = " < ALL > "
        Me.cboLoaiMay.ItemNew = "...New"
        Me.cboLoaiMay.Location = New System.Drawing.Point(149, 3)
        Me.cboLoaiMay.MethodName = ""
        Me.cboLoaiMay.Name = "cboLoaiMay"
        Me.cboLoaiMay.Param = ""
        Me.cboLoaiMay.Size = New System.Drawing.Size(200, 21)
        Me.cboLoaiMay.StoreName = ""
        Me.cboLoaiMay.TabIndex = 18
        Me.cboLoaiMay.Table = Nothing
        Me.cboLoaiMay.TextReadonly = False
        Me.cboLoaiMay.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grdNhapthoigianngungmay
        '
        Me.grdNhapthoigianngungmay.AllowUserToAddRows = False
        Me.grdNhapthoigianngungmay.AllowUserToDeleteRows = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdNhapthoigianngungmay, 8)
        Me.grdNhapthoigianngungmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNhapthoigianngungmay.Location = New System.Drawing.Point(3, 33)
        Me.grdNhapthoigianngungmay.MultiSelect = False
        Me.grdNhapthoigianngungmay.Name = "grdNhapthoigianngungmay"
        Me.grdNhapthoigianngungmay.Size = New System.Drawing.Size(830, 441)
        Me.grdNhapthoigianngungmay.TabIndex = 0
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 8)
        Me.Panel1.Controls.Add(Me.BtnNguyenNhan)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.BtnXoaAll)
        Me.Panel1.Controls.Add(Me.BtnThoat)
        Me.Panel1.Controls.Add(Me.BtnKhongghi)
        Me.Panel1.Controls.Add(Me.BtnXoaCT)
        Me.Panel1.Controls.Add(Me.BtnTroVe)
        Me.Panel1.Controls.Add(Me.BtnGhi)
        Me.Panel1.Controls.Add(Me.BtnThem)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 480)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 28)
        Me.Panel1.TabIndex = 26
        '
        'BtnNguyenNhan
        '
        Me.BtnNguyenNhan.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnNguyenNhan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNguyenNhan.ForeColor = System.Drawing.Color.Blue
        Me.BtnNguyenNhan.Location = New System.Drawing.Point(0, 0)
        Me.BtnNguyenNhan.Name = "BtnNguyenNhan"
        Me.BtnNguyenNhan.Size = New System.Drawing.Size(166, 28)
        Me.BtnNguyenNhan.TabIndex = 23
        Me.BtnNguyenNhan.Text = "Nguyên nhân ngừng máy"
        Me.BtnNguyenNhan.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.ForeColor = System.Drawing.Color.Red
        Me.BtnXoa.Location = New System.Drawing.Point(663, 1)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(81, 25)
        Me.BtnXoa.TabIndex = 11
        Me.BtnXoa.Text = "&Xóa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'BtnXoaAll
        '
        Me.BtnXoaAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoaAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoaAll.ForeColor = System.Drawing.Color.Red
        Me.BtnXoaAll.Location = New System.Drawing.Point(523, 1)
        Me.BtnXoaAll.Name = "BtnXoaAll"
        Me.BtnXoaAll.Size = New System.Drawing.Size(118, 25)
        Me.BtnXoaAll.TabIndex = 21
        Me.BtnXoaAll.Text = "Xóa tất cả"
        Me.BtnXoaAll.UseVisualStyleBackColor = True
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat.Location = New System.Drawing.Point(746, 1)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat.TabIndex = 12
        Me.BtnThoat.Text = "T&hoát"
        Me.BtnThoat.UseVisualStyleBackColor = True
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKhongghi.ForeColor = System.Drawing.Color.Red
        Me.BtnKhongghi.Location = New System.Drawing.Point(746, 1)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(81, 25)
        Me.BtnKhongghi.TabIndex = 19
        Me.BtnKhongghi.Text = "&Không"
        Me.BtnKhongghi.UseVisualStyleBackColor = True
        '
        'BtnXoaCT
        '
        Me.BtnXoaCT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoaCT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoaCT.ForeColor = System.Drawing.Color.Red
        Me.BtnXoaCT.Location = New System.Drawing.Point(643, 1)
        Me.BtnXoaCT.Name = "BtnXoaCT"
        Me.BtnXoaCT.Size = New System.Drawing.Size(101, 25)
        Me.BtnXoaCT.TabIndex = 20
        Me.BtnXoaCT.Text = "Xóa chi tiết"
        Me.BtnXoaCT.UseVisualStyleBackColor = True
        '
        'BtnTroVe
        '
        Me.BtnTroVe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTroVe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTroVe.Location = New System.Drawing.Point(747, 0)
        Me.BtnTroVe.Name = "BtnTroVe"
        Me.BtnTroVe.Size = New System.Drawing.Size(81, 25)
        Me.BtnTroVe.TabIndex = 22
        Me.BtnTroVe.Text = "Trở về"
        Me.BtnTroVe.UseVisualStyleBackColor = True
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGhi.ForeColor = System.Drawing.Color.Blue
        Me.BtnGhi.Location = New System.Drawing.Point(663, 1)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(81, 25)
        Me.BtnGhi.TabIndex = 18
        Me.BtnGhi.Text = "&Ghi"
        Me.BtnGhi.UseVisualStyleBackColor = True
        '
        'BtnThem
        '
        Me.BtnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThem.ForeColor = System.Drawing.Color.Blue
        Me.BtnThem.Location = New System.Drawing.Point(562, 1)
        Me.BtnThem.Name = "BtnThem"
        Me.BtnThem.Size = New System.Drawing.Size(99, 25)
        Me.BtnThem.TabIndex = 9
        Me.BtnThem.Text = "&Thêm/Sửa"
        Me.BtnThem.UseVisualStyleBackColor = True
        '
        'TabThongtinngungmay
        '
        Me.TabThongtinngungmay.Controls.Add(Me.cboNhomMay)
        Me.TabThongtinngungmay.Controls.Add(Me.lblNhomTB)
        Me.TabThongtinngungmay.Controls.Add(Me.lblLoaiTB)
        Me.TabThongtinngungmay.Controls.Add(Me.lblDiaDiem)
        Me.TabThongtinngungmay.Controls.Add(Me.BtnIn)
        Me.TabThongtinngungmay.Controls.Add(Me.BtnThoat1)
        Me.TabThongtinngungmay.Controls.Add(Me.grpThoigianngungmay)
        Me.TabThongtinngungmay.Controls.Add(Me.lblDenngay)
        Me.TabThongtinngungmay.Controls.Add(Me.lblTungay)
        Me.TabThongtinngungmay.Controls.Add(Me.lblThietbi)
        Me.TabThongtinngungmay.Controls.Add(Me.dtDengnay)
        Me.TabThongtinngungmay.Controls.Add(Me.dtTungay)
        Me.TabThongtinngungmay.Controls.Add(Me.cboLoaiTB)
        Me.TabThongtinngungmay.Controls.Add(Me.cboDiaDiem)
        Me.TabThongtinngungmay.Controls.Add(Me.cboThietbi)
        Me.TabThongtinngungmay.Location = New System.Drawing.Point(4, 22)
        Me.TabThongtinngungmay.Name = "TabThongtinngungmay"
        Me.TabThongtinngungmay.Padding = New System.Windows.Forms.Padding(3)
        Me.TabThongtinngungmay.Size = New System.Drawing.Size(842, 517)
        Me.TabThongtinngungmay.TabIndex = 1
        Me.TabThongtinngungmay.Text = "Thông tin thời gian ngưng máy"
        Me.TabThongtinngungmay.UseVisualStyleBackColor = True
        '
        'cboNhomMay
        '
        Me.cboNhomMay.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboNhomMay.AssemblyName = ""
        Me.cboNhomMay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNhomMay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNhomMay.BackColor = System.Drawing.Color.White
        Me.cboNhomMay.ClassName = ""
        Me.cboNhomMay.Display = ""
        Me.cboNhomMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNhomMay.ErrorProviderControl = Me.ErrorProvider1
        Me.cboNhomMay.FormattingEnabled = True
        Me.cboNhomMay.IsAll = True
        Me.cboNhomMay.IsNew = False
        Me.cboNhomMay.ItemAll = " < ALL > "
        Me.cboNhomMay.ItemNew = "...New"
        Me.cboNhomMay.Location = New System.Drawing.Point(660, 10)
        Me.cboNhomMay.MethodName = ""
        Me.cboNhomMay.Name = "cboNhomMay"
        Me.cboNhomMay.Param = ""
        Me.cboNhomMay.Size = New System.Drawing.Size(173, 21)
        Me.cboNhomMay.StoreName = ""
        Me.cboNhomMay.TabIndex = 31
        Me.cboNhomMay.Table = Nothing
        Me.cboNhomMay.TextReadonly = False
        Me.cboNhomMay.Value = ""
        '
        'lblNhomTB
        '
        Me.lblNhomTB.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNhomTB.AutoSize = True
        Me.lblNhomTB.Location = New System.Drawing.Point(546, 18)
        Me.lblNhomTB.Name = "lblNhomTB"
        Me.lblNhomTB.Size = New System.Drawing.Size(70, 13)
        Me.lblNhomTB.TabIndex = 30
        Me.lblNhomTB.Text = "Nhóm thiết bị"
        '
        'lblLoaiTB
        '
        Me.lblLoaiTB.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLoaiTB.AutoSize = True
        Me.lblLoaiTB.Location = New System.Drawing.Point(269, 18)
        Me.lblLoaiTB.Name = "lblLoaiTB"
        Me.lblLoaiTB.Size = New System.Drawing.Size(62, 13)
        Me.lblLoaiTB.TabIndex = 28
        Me.lblLoaiTB.Text = "Loại thiết bị"
        '
        'lblDiaDiem
        '
        Me.lblDiaDiem.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDiaDiem.AutoSize = True
        Me.lblDiaDiem.Location = New System.Drawing.Point(10, 18)
        Me.lblDiaDiem.Name = "lblDiaDiem"
        Me.lblDiaDiem.Size = New System.Drawing.Size(48, 13)
        Me.lblDiaDiem.TabIndex = 26
        Me.lblDiaDiem.Text = "Địa điểm"
        '
        'BtnIn
        '
        Me.BtnIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIn.ForeColor = System.Drawing.Color.Teal
        Me.BtnIn.Location = New System.Drawing.Point(674, 486)
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(81, 25)
        Me.BtnIn.TabIndex = 24
        Me.BtnIn.Text = "&In"
        Me.BtnIn.UseVisualStyleBackColor = True
        '
        'BtnThoat1
        '
        Me.BtnThoat1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThoat1.Location = New System.Drawing.Point(755, 486)
        Me.BtnThoat1.Name = "BtnThoat1"
        Me.BtnThoat1.Size = New System.Drawing.Size(81, 25)
        Me.BtnThoat1.TabIndex = 25
        Me.BtnThoat1.Text = "T&hoát"
        Me.BtnThoat1.UseVisualStyleBackColor = True
        '
        'grpThoigianngungmay
        '
        Me.grpThoigianngungmay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpThoigianngungmay.Controls.Add(Me.grdDanhsachthoigianngungmay)
        Me.grpThoigianngungmay.ForeColor = System.Drawing.Color.Maroon
        Me.grpThoigianngungmay.Location = New System.Drawing.Point(3, 64)
        Me.grpThoigianngungmay.Name = "grpThoigianngungmay"
        Me.grpThoigianngungmay.Size = New System.Drawing.Size(833, 416)
        Me.grpThoigianngungmay.TabIndex = 23
        Me.grpThoigianngungmay.TabStop = False
        Me.grpThoigianngungmay.Text = "Thời gian ngưng máy"
        '
        'grdDanhsachthoigianngungmay
        '
        Me.grdDanhsachthoigianngungmay.AllowUserToAddRows = False
        Me.grdDanhsachthoigianngungmay.AllowUserToDeleteRows = False
        Me.grdDanhsachthoigianngungmay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhsachthoigianngungmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhsachthoigianngungmay.Location = New System.Drawing.Point(3, 17)
        Me.grdDanhsachthoigianngungmay.Name = "grdDanhsachthoigianngungmay"
        Me.grdDanhsachthoigianngungmay.ReadOnly = True
        Me.grdDanhsachthoigianngungmay.Size = New System.Drawing.Size(827, 396)
        Me.grdDanhsachthoigianngungmay.TabIndex = 0
        '
        'lblDenngay
        '
        Me.lblDenngay.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Location = New System.Drawing.Point(546, 45)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(54, 13)
        Me.lblDenngay.TabIndex = 22
        Me.lblDenngay.Text = "Đến ngày"
        '
        'lblTungay
        '
        Me.lblTungay.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Location = New System.Drawing.Point(357, 45)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(32, 13)
        Me.lblTungay.TabIndex = 21
        Me.lblTungay.Text = "Ngày"
        '
        'lblThietbi
        '
        Me.lblThietbi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblThietbi.AutoSize = True
        Me.lblThietbi.Location = New System.Drawing.Point(10, 45)
        Me.lblThietbi.Name = "lblThietbi"
        Me.lblThietbi.Size = New System.Drawing.Size(42, 13)
        Me.lblThietbi.TabIndex = 20
        Me.lblThietbi.Text = "Thiết bị"
        '
        'dtDengnay
        '
        Me.dtDengnay.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtDengnay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDengnay.Location = New System.Drawing.Point(660, 40)
        Me.dtDengnay.Name = "dtDengnay"
        Me.dtDengnay.Size = New System.Drawing.Size(93, 21)
        Me.dtDengnay.TabIndex = 19
        '
        'dtTungay
        '
        Me.dtTungay.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtTungay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTungay.Location = New System.Drawing.Point(453, 41)
        Me.dtTungay.Name = "dtTungay"
        Me.dtTungay.Size = New System.Drawing.Size(84, 21)
        Me.dtTungay.TabIndex = 18
        '
        'cboLoaiTB
        '
        Me.cboLoaiTB.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboLoaiTB.AssemblyName = ""
        Me.cboLoaiTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLoaiTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoaiTB.BackColor = System.Drawing.Color.White
        Me.cboLoaiTB.ClassName = ""
        Me.cboLoaiTB.Display = ""
        Me.cboLoaiTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiTB.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiTB.FormattingEnabled = True
        Me.cboLoaiTB.IsAll = True
        Me.cboLoaiTB.IsNew = False
        Me.cboLoaiTB.ItemAll = " < ALL > "
        Me.cboLoaiTB.ItemNew = "...New"
        Me.cboLoaiTB.Location = New System.Drawing.Point(360, 10)
        Me.cboLoaiTB.MethodName = ""
        Me.cboLoaiTB.Name = "cboLoaiTB"
        Me.cboLoaiTB.Param = ""
        Me.cboLoaiTB.Size = New System.Drawing.Size(177, 21)
        Me.cboLoaiTB.StoreName = ""
        Me.cboLoaiTB.TabIndex = 29
        Me.cboLoaiTB.Table = Nothing
        Me.cboLoaiTB.TextReadonly = False
        Me.cboLoaiTB.Value = ""
        '
        'cboDiaDiem
        '
        Me.cboDiaDiem.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboDiaDiem.AssemblyName = ""
        Me.cboDiaDiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDiaDiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiaDiem.BackColor = System.Drawing.Color.White
        Me.cboDiaDiem.ClassName = ""
        Me.cboDiaDiem.Display = ""
        Me.cboDiaDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiaDiem.ErrorProviderControl = Me.ErrorProvider1
        Me.cboDiaDiem.FormattingEnabled = True
        Me.cboDiaDiem.IsAll = False
        Me.cboDiaDiem.IsNew = False
        Me.cboDiaDiem.ItemAll = " < ALL > "
        Me.cboDiaDiem.ItemNew = "...New"
        Me.cboDiaDiem.Location = New System.Drawing.Point(105, 10)
        Me.cboDiaDiem.MethodName = ""
        Me.cboDiaDiem.Name = "cboDiaDiem"
        Me.cboDiaDiem.Param = ""
        Me.cboDiaDiem.Size = New System.Drawing.Size(158, 21)
        Me.cboDiaDiem.StoreName = ""
        Me.cboDiaDiem.TabIndex = 27
        Me.cboDiaDiem.Table = Nothing
        Me.cboDiaDiem.TextReadonly = False
        Me.cboDiaDiem.Value = ""
        '
        'cboThietbi
        '
        Me.cboThietbi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboThietbi.AssemblyName = ""
        Me.cboThietbi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboThietbi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboThietbi.BackColor = System.Drawing.Color.White
        Me.cboThietbi.ClassName = ""
        Me.cboThietbi.Display = ""
        Me.cboThietbi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThietbi.ErrorProviderControl = Me.ErrorProvider1
        Me.cboThietbi.FormattingEnabled = True
        Me.cboThietbi.IsAll = True
        Me.cboThietbi.IsNew = False
        Me.cboThietbi.ItemAll = " < ALL > "
        Me.cboThietbi.ItemNew = "...New"
        Me.cboThietbi.Location = New System.Drawing.Point(105, 42)
        Me.cboThietbi.MethodName = ""
        Me.cboThietbi.Name = "cboThietbi"
        Me.cboThietbi.Param = ""
        Me.cboThietbi.Size = New System.Drawing.Size(158, 21)
        Me.cboThietbi.StoreName = ""
        Me.cboThietbi.TabIndex = 3
        Me.cboThietbi.Table = Nothing
        Me.cboThietbi.TextReadonly = False
        Me.cboThietbi.Value = ""
        '
        'frmDowntime_BAYER
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 595)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lbtTieuDe)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmDowntime_BAYER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDowntime"
        Me.TabControl1.ResumeLayout(False)
        Me.TabNguyennhandowntime.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNhapthoigianngungmay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TabThongtinngungmay.ResumeLayout(False)
        Me.TabThongtinngungmay.PerformLayout()
        Me.grpThoigianngungmay.ResumeLayout(False)
        CType(Me.grdDanhsachthoigianngungmay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbtTieuDe As System.Windows.Forms.Label
    Friend WithEvents dtNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabNguyennhandowntime As System.Windows.Forms.TabPage
    Friend WithEvents TabThongtinngungmay As System.Windows.Forms.TabPage
    Friend WithEvents grdNhapthoigianngungmay As System.Windows.Forms.DataGridView
    Friend WithEvents BtnThem As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents BtnThoat As System.Windows.Forms.Button
    Friend WithEvents grpThoigianngungmay As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhsachthoigianngungmay As System.Windows.Forms.DataGridView
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents lblThietbi As System.Windows.Forms.Label
    Friend WithEvents dtDengnay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboThietbi As Commons.UtcComboBox
    Friend WithEvents BtnIn As System.Windows.Forms.Button
    Friend WithEvents BtnThoat1 As System.Windows.Forms.Button
    Friend WithEvents BtnKhongghi As System.Windows.Forms.Button
    Friend WithEvents BtnGhi As System.Windows.Forms.Button
    Friend WithEvents BtnTroVe As System.Windows.Forms.Button
    Friend WithEvents BtnXoaAll As System.Windows.Forms.Button
    Friend WithEvents BtnXoaCT As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblLoaiMay As System.Windows.Forms.Label
    Friend WithEvents cboLoaiMay As Commons.UtcComboBox
    Friend WithEvents cboNhomMay As Commons.UtcComboBox
    Friend WithEvents lblNhomTB As System.Windows.Forms.Label
    Friend WithEvents cboLoaiTB As Commons.UtcComboBox
    Friend WithEvents lblLoaiTB As System.Windows.Forms.Label
    Friend WithEvents cboDiaDiem As Commons.UtcComboBox
    Friend WithEvents lblDiaDiem As System.Windows.Forms.Label
    Friend WithEvents BtnNguyenNhan As System.Windows.Forms.Button
    Friend WithEvents lblDenNgay1 As System.Windows.Forms.Label
    Friend WithEvents dtDenNgay1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboNguoiGiaiQuyet As Commons.UtcComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
