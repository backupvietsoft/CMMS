<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmThoiGianNgungMay
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbaTieuDe = New System.Windows.Forms.Label()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabEdit = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbxLoaiMay = New Commons.UtcComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaLoaiMay = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGhi = New System.Windows.Forms.Button()
        Me.btnKhongGhi = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnNguyenNhan = New System.Windows.Forms.Button()
        Me.btnThem = New System.Windows.Forms.Button()
        Me.BtnXoa = New System.Windows.Forms.Button()
        Me.btnThoat = New System.Windows.Forms.Button()
        Me.lbaTuNgay = New System.Windows.Forms.Label()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.grdNgungMay = New System.Windows.Forms.DataGridView()
        Me.MS_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STT_NGUNG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TU_NGAY = New Commons.QLGridMaskedTextBoxColumn()
        Me.TU_GIO = New Commons.QLGridMaskedTextBoxColumn()
        Me.DEN_NGAY = New Commons.QLGridMaskedTextBoxColumn()
        Me.DEN_GIO = New Commons.QLGridMaskedTextBoxColumn()
        Me.DIA_DIEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DAY_CHUYEN = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.LOAI_DUNG_MAY = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.THOI_GIAN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NGUYEN_NHAN = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NGUYEN_NHAN_CGQ = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NGUOI_GIAI_QUYET = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabView = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.vlbaDiaDiem = New System.Windows.Forms.Label()
        Me.vlabThietBi = New System.Windows.Forms.Label()
        Me.vlbaLoaiTB = New System.Windows.Forms.Label()
        Me.vlabTuNgay = New System.Windows.Forms.Label()
        Me.lbaNhomTB = New System.Windows.Forms.Label()
        Me.vlabDenNgay = New System.Windows.Forms.Label()
        Me.vcboDiaDiem = New Commons.UtcComboBox()
        Me.vcboLoaiTB = New Commons.UtcComboBox()
        Me.vcboNhomTB = New Commons.UtcComboBox()
        Me.vcboThietbi = New Commons.UtcComboBox()
        Me.vmtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.vmtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCanDoi = New System.Windows.Forms.Button()
        Me.vbtnThoat = New System.Windows.Forms.Button()
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.vMS_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vSTT_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vTU_NGAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vTU_GIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vDEN_NGAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vDEN_GIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vDIA_DIEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vDAY_CHUYEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vLOAI_DM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vTG_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vNGUYEN_NHAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vNN_CGQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vNGUOI_GQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QlGridMaskedTextBoxColumn1 = New Commons.QLGridMaskedTextBoxColumn()
        Me.QlGridMaskedTextBoxColumn2 = New Commons.QLGridMaskedTextBoxColumn()
        Me.QlGridMaskedTextBoxColumn3 = New Commons.QLGridMaskedTextBoxColumn()
        Me.QlGridMaskedTextBoxColumn4 = New Commons.QLGridMaskedTextBoxColumn()
        Me.QlGridMaskedTextBoxColumn5 = New Commons.QLGridMaskedTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabEdit.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdNgungMay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabView.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTieuDe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabMain, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(967, 458)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbaTieuDe
        '
        Me.lbaTieuDe.AutoSize = True
        Me.lbaTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTieuDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.lbaTieuDe.Location = New System.Drawing.Point(3, 0)
        Me.lbaTieuDe.Name = "lbaTieuDe"
        Me.lbaTieuDe.Size = New System.Drawing.Size(961, 46)
        Me.lbaTieuDe.TabIndex = 0
        Me.lbaTieuDe.Text = "THOI GIAN NGUNG MAY "
        Me.lbaTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabEdit)
        Me.TabMain.Controls.Add(Me.TabView)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(3, 49)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(961, 406)
        Me.TabMain.TabIndex = 1
        '
        'TabEdit
        '
        Me.TabEdit.Controls.Add(Me.TableLayoutPanel2)
        Me.TabEdit.Location = New System.Drawing.Point(4, 22)
        Me.TabEdit.Name = "TabEdit"
        Me.TabEdit.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEdit.Size = New System.Drawing.Size(953, 380)
        Me.TabEdit.TabIndex = 0
        Me.TabEdit.Text = "Nhap thoi gian ngung may"
        Me.TabEdit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cbxLoaiMay, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaLoaiMay, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaTuNgay, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaDenNgay, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.mtxtTuNgay, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.mtxtDenNgay, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.grdNgungMay, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(947, 374)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'cbxLoaiMay
        '
        Me.cbxLoaiMay.AssemblyName = ""
        Me.cbxLoaiMay.BackColor = System.Drawing.Color.White
        Me.cbxLoaiMay.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxLoaiMay.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxLoaiMay.ClassName = ""
        Me.cbxLoaiMay.Display = ""
        Me.cbxLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxLoaiMay.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxLoaiMay.FormattingEnabled = True
        Me.cbxLoaiMay.IsAll = True
        Me.cbxLoaiMay.isInputNull = False
        Me.cbxLoaiMay.IsNew = False
        Me.cbxLoaiMay.IsNull = True
        Me.cbxLoaiMay.ItemAll = " < ALL > "
        Me.cbxLoaiMay.ItemNew = "...New"
        Me.cbxLoaiMay.Location = New System.Drawing.Point(144, 3)
        Me.cbxLoaiMay.MethodName = ""
        Me.cbxLoaiMay.Name = "cbxLoaiMay"
        Me.cbxLoaiMay.Param = ""
        Me.cbxLoaiMay.Param2 = ""
        Me.cbxLoaiMay.Size = New System.Drawing.Size(228, 21)
        Me.cbxLoaiMay.StoreName = ""
        Me.cbxLoaiMay.TabIndex = 0
        Me.cbxLoaiMay.Table = Nothing
        Me.cbxLoaiMay.TextReadonly = False
        Me.cbxLoaiMay.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaLoaiMay
        '
        Me.lbaLoaiMay.AutoSize = True
        Me.lbaLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaLoaiMay.Location = New System.Drawing.Point(47, 0)
        Me.lbaLoaiMay.Name = "lbaLoaiMay"
        Me.lbaLoaiMay.Size = New System.Drawing.Size(91, 28)
        Me.lbaLoaiMay.TabIndex = 1
        Me.lbaLoaiMay.Text = "Loai may"
        Me.lbaLoaiMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel1, 8)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Controls.Add(Me.btnKhongGhi)
        Me.Panel1.Controls.Add(Me.btnCopy)
        Me.Panel1.Controls.Add(Me.btnNguyenNhan)
        Me.Panel1.Controls.Add(Me.btnThem)
        Me.Panel1.Controls.Add(Me.BtnXoa)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Location = New System.Drawing.Point(3, 345)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(941, 26)
        Me.Panel1.TabIndex = 2
        '
        'btnGhi
        '
        Me.btnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGhi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.Location = New System.Drawing.Point(500, 0)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(75, 26)
        Me.btnGhi.TabIndex = 6
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnKhongGhi
        '
        Me.btnKhongGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnKhongGhi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhi.Location = New System.Drawing.Point(575, 0)
        Me.btnKhongGhi.Name = "btnKhongGhi"
        Me.btnKhongGhi.Size = New System.Drawing.Size(75, 26)
        Me.btnKhongGhi.TabIndex = 5
        Me.btnKhongGhi.Text = "Khong ghi"
        Me.btnKhongGhi.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(118, 0)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(100, 26)
        Me.btnCopy.TabIndex = 4
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnNguyenNhan
        '
        Me.btnNguyenNhan.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnNguyenNhan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNguyenNhan.Location = New System.Drawing.Point(0, 0)
        Me.btnNguyenNhan.Name = "btnNguyenNhan"
        Me.btnNguyenNhan.Size = New System.Drawing.Size(118, 26)
        Me.btnNguyenNhan.TabIndex = 3
        Me.btnNguyenNhan.Text = "Nguyen Nhan NM"
        Me.btnNguyenNhan.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThem.Location = New System.Drawing.Point(650, 0)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(104, 26)
        Me.btnThem.TabIndex = 2
        Me.btnThem.Text = "Them/sua"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'BtnXoa
        '
        Me.BtnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnXoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnXoa.Location = New System.Drawing.Point(754, 0)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(94, 26)
        Me.BtnXoa.TabIndex = 1
        Me.BtnXoa.Text = "Xoa"
        Me.BtnXoa.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(848, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(93, 26)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoat"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(378, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(121, 28)
        Me.lbaTuNgay.TabIndex = 2
        Me.lbaTuNgay.Text = "Tu ngay"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(660, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(119, 28)
        Me.lbaDenNgay.TabIndex = 3
        Me.lbaDenNgay.Text = "Den Ngay"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Location = New System.Drawing.Point(505, 3)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(100, 21)
        Me.mtxtTuNgay.TabIndex = 4
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Location = New System.Drawing.Point(785, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(100, 21)
        Me.mtxtDenNgay.TabIndex = 5
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'grdNgungMay
        '
        Me.grdNgungMay.AllowUserToAddRows = False
        Me.grdNgungMay.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdNgungMay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdNgungMay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNgungMay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MS_MAY, Me.STT_NGUNG, Me.TU_NGAY, Me.TU_GIO, Me.DEN_NGAY, Me.DEN_GIO, Me.DIA_DIEM, Me.DAY_CHUYEN, Me.LOAI_DUNG_MAY, Me.THOI_GIAN_NM, Me.NGUYEN_NHAN, Me.NGUYEN_NHAN_CGQ, Me.NGUOI_GIAI_QUYET})
        Me.TableLayoutPanel2.SetColumnSpan(Me.grdNgungMay, 8)
        Me.grdNgungMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNgungMay.Location = New System.Drawing.Point(3, 31)
        Me.grdNgungMay.Name = "grdNgungMay"
        Me.grdNgungMay.RowHeadersVisible = False
        Me.grdNgungMay.Size = New System.Drawing.Size(941, 308)
        Me.grdNgungMay.TabIndex = 6
        '
        'MS_MAY
        '
        Me.MS_MAY.HeaderText = "MS_MAY"
        Me.MS_MAY.MinimumWidth = 120
        Me.MS_MAY.Name = "MS_MAY"
        Me.MS_MAY.Width = 120
        '
        'STT_NGUNG
        '
        Me.STT_NGUNG.HeaderText = "STT_NGUNG"
        Me.STT_NGUNG.Name = "STT_NGUNG"
        Me.STT_NGUNG.Visible = False
        '
        'TU_NGAY
        '
        Me.TU_NGAY.HeaderText = "TU_NGAY"
        Me.TU_NGAY.Mask = ""
        Me.TU_NGAY.MinimumWidth = 100
        Me.TU_NGAY.Name = "TU_NGAY"
        Me.TU_NGAY.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TU_NGAY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TU_GIO
        '
        Me.TU_GIO.HeaderText = "TU_GIO"
        Me.TU_GIO.Mask = ""
        Me.TU_GIO.MinimumWidth = 80
        Me.TU_GIO.Name = "TU_GIO"
        Me.TU_GIO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TU_GIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TU_GIO.Width = 80
        '
        'DEN_NGAY
        '
        Me.DEN_NGAY.HeaderText = "DEN_NGAY"
        Me.DEN_NGAY.Mask = ""
        Me.DEN_NGAY.MinimumWidth = 100
        Me.DEN_NGAY.Name = "DEN_NGAY"
        '
        'DEN_GIO
        '
        Me.DEN_GIO.HeaderText = "DEN_GIO"
        Me.DEN_GIO.Mask = ""
        Me.DEN_GIO.MinimumWidth = 80
        Me.DEN_GIO.Name = "DEN_GIO"
        Me.DEN_GIO.Width = 80
        '
        'DIA_DIEM
        '
        Me.DIA_DIEM.HeaderText = "DIA_DIEM"
        Me.DIA_DIEM.MinimumWidth = 120
        Me.DIA_DIEM.Name = "DIA_DIEM"
        Me.DIA_DIEM.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DIA_DIEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DIA_DIEM.Width = 120
        '
        'DAY_CHUYEN
        '
        Me.DAY_CHUYEN.HeaderText = "DAY_CHUYEN"
        Me.DAY_CHUYEN.MinimumWidth = 100
        Me.DAY_CHUYEN.Name = "DAY_CHUYEN"
        '
        'LOAI_DUNG_MAY
        '
        Me.LOAI_DUNG_MAY.HeaderText = "LOAI_DUNG_MAY"
        Me.LOAI_DUNG_MAY.MinimumWidth = 100
        Me.LOAI_DUNG_MAY.Name = "LOAI_DUNG_MAY"
        '
        'THOI_GIAN_NM
        '
        Me.THOI_GIAN_NM.HeaderText = "THOI_GIAN_NM"
        Me.THOI_GIAN_NM.MinimumWidth = 100
        Me.THOI_GIAN_NM.Name = "THOI_GIAN_NM"
        '
        'NGUYEN_NHAN
        '
        Me.NGUYEN_NHAN.HeaderText = "NGUYEN_NHAN"
        Me.NGUYEN_NHAN.MinimumWidth = 100
        Me.NGUYEN_NHAN.Name = "NGUYEN_NHAN"
        '
        'NGUYEN_NHAN_CGQ
        '
        Me.NGUYEN_NHAN_CGQ.HeaderText = "NGUYEN_NHAN_CGQ"
        Me.NGUYEN_NHAN_CGQ.MinimumWidth = 100
        Me.NGUYEN_NHAN_CGQ.Name = "NGUYEN_NHAN_CGQ"
        '
        'NGUOI_GIAI_QUYET
        '
        Me.NGUOI_GIAI_QUYET.HeaderText = "NGUOI_GIAI_QUYET"
        Me.NGUOI_GIAI_QUYET.MinimumWidth = 100
        Me.NGUOI_GIAI_QUYET.Name = "NGUOI_GIAI_QUYET"
        '
        'TabView
        '
        Me.TabView.Controls.Add(Me.TableLayoutPanel3)
        Me.TabView.Location = New System.Drawing.Point(4, 22)
        Me.TabView.Name = "TabView"
        Me.TabView.Padding = New System.Windows.Forms.Padding(3)
        Me.TabView.Size = New System.Drawing.Size(953, 380)
        Me.TabView.TabIndex = 1
        Me.TabView.Text = "Thong tin ngung may"
        Me.TabView.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.grdView, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(947, 374)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 8
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.vlbaDiaDiem, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.vlabThietBi, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.vlbaLoaiTB, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.vlabTuNgay, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lbaNhomTB, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.vlabDenNgay, 5, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.vcboDiaDiem, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.vcboLoaiTB, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.vcboNhomTB, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.vcboThietbi, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.vmtxtTuNgay, 4, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.vmtxtDenNgay, 6, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(941, 54)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'vlbaDiaDiem
        '
        Me.vlbaDiaDiem.AutoSize = True
        Me.vlbaDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vlbaDiaDiem.Location = New System.Drawing.Point(22, 0)
        Me.vlbaDiaDiem.Name = "vlbaDiaDiem"
        Me.vlbaDiaDiem.Size = New System.Drawing.Size(135, 27)
        Me.vlbaDiaDiem.TabIndex = 0
        Me.vlbaDiaDiem.Text = "Dia diem"
        Me.vlbaDiaDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vlabThietBi
        '
        Me.vlabThietBi.AutoSize = True
        Me.vlabThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vlabThietBi.Location = New System.Drawing.Point(22, 27)
        Me.vlabThietBi.Name = "vlabThietBi"
        Me.vlabThietBi.Size = New System.Drawing.Size(135, 27)
        Me.vlabThietBi.TabIndex = 1
        Me.vlabThietBi.Text = "Thiet bi"
        Me.vlabThietBi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vlbaLoaiTB
        '
        Me.vlbaLoaiTB.AutoSize = True
        Me.vlbaLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vlbaLoaiTB.Location = New System.Drawing.Point(313, 0)
        Me.vlbaLoaiTB.Name = "vlbaLoaiTB"
        Me.vlbaLoaiTB.Size = New System.Drawing.Size(119, 27)
        Me.vlbaLoaiTB.TabIndex = 2
        Me.vlbaLoaiTB.Text = "Loai TB"
        Me.vlbaLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vlabTuNgay
        '
        Me.vlabTuNgay.AutoSize = True
        Me.vlabTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vlabTuNgay.Location = New System.Drawing.Point(313, 27)
        Me.vlabTuNgay.Name = "vlabTuNgay"
        Me.vlabTuNgay.Size = New System.Drawing.Size(119, 27)
        Me.vlabTuNgay.TabIndex = 3
        Me.vlabTuNgay.Text = "Tu ngay"
        Me.vlabTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaNhomTB
        '
        Me.lbaNhomTB.AutoSize = True
        Me.lbaNhomTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhomTB.Location = New System.Drawing.Point(621, 0)
        Me.lbaNhomTB.Name = "lbaNhomTB"
        Me.lbaNhomTB.Size = New System.Drawing.Size(127, 27)
        Me.lbaNhomTB.TabIndex = 4
        Me.lbaNhomTB.Text = "Nhom TB"
        Me.lbaNhomTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vlabDenNgay
        '
        Me.vlabDenNgay.AutoSize = True
        Me.vlabDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vlabDenNgay.Location = New System.Drawing.Point(621, 27)
        Me.vlabDenNgay.Name = "vlabDenNgay"
        Me.vlabDenNgay.Size = New System.Drawing.Size(127, 27)
        Me.vlabDenNgay.TabIndex = 5
        Me.vlabDenNgay.Text = "Den ngay"
        Me.vlabDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vcboDiaDiem
        '
        Me.vcboDiaDiem.AssemblyName = ""
        Me.vcboDiaDiem.BackColor = System.Drawing.Color.White
        Me.vcboDiaDiem.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.vcboDiaDiem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.vcboDiaDiem.ClassName = ""
        Me.vcboDiaDiem.Display = ""
        Me.vcboDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vcboDiaDiem.ErrorProviderControl = Me.ErrorProvider1
        Me.vcboDiaDiem.FormattingEnabled = True
        Me.vcboDiaDiem.IsAll = False
        Me.vcboDiaDiem.isInputNull = False
        Me.vcboDiaDiem.IsNew = False
        Me.vcboDiaDiem.IsNull = True
        Me.vcboDiaDiem.ItemAll = " < ALL > "
        Me.vcboDiaDiem.ItemNew = "...New"
        Me.vcboDiaDiem.Location = New System.Drawing.Point(163, 3)
        Me.vcboDiaDiem.MethodName = ""
        Me.vcboDiaDiem.Name = "vcboDiaDiem"
        Me.vcboDiaDiem.Param = ""
        Me.vcboDiaDiem.Param2 = ""
        Me.vcboDiaDiem.Size = New System.Drawing.Size(144, 21)
        Me.vcboDiaDiem.StoreName = ""
        Me.vcboDiaDiem.TabIndex = 6
        Me.vcboDiaDiem.Table = Nothing
        Me.vcboDiaDiem.TextReadonly = False
        Me.vcboDiaDiem.Value = ""
        '
        'vcboLoaiTB
        '
        Me.vcboLoaiTB.AssemblyName = ""
        Me.vcboLoaiTB.BackColor = System.Drawing.Color.White
        Me.vcboLoaiTB.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.vcboLoaiTB.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.vcboLoaiTB.ClassName = ""
        Me.vcboLoaiTB.Display = ""
        Me.vcboLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vcboLoaiTB.ErrorProviderControl = Me.ErrorProvider1
        Me.vcboLoaiTB.FormattingEnabled = True
        Me.vcboLoaiTB.IsAll = False
        Me.vcboLoaiTB.isInputNull = False
        Me.vcboLoaiTB.IsNew = False
        Me.vcboLoaiTB.IsNull = True
        Me.vcboLoaiTB.ItemAll = " < ALL > "
        Me.vcboLoaiTB.ItemNew = "...New"
        Me.vcboLoaiTB.Location = New System.Drawing.Point(438, 3)
        Me.vcboLoaiTB.MethodName = ""
        Me.vcboLoaiTB.Name = "vcboLoaiTB"
        Me.vcboLoaiTB.Param = ""
        Me.vcboLoaiTB.Param2 = ""
        Me.vcboLoaiTB.Size = New System.Drawing.Size(177, 21)
        Me.vcboLoaiTB.StoreName = ""
        Me.vcboLoaiTB.TabIndex = 7
        Me.vcboLoaiTB.Table = Nothing
        Me.vcboLoaiTB.TextReadonly = False
        Me.vcboLoaiTB.Value = ""
        '
        'vcboNhomTB
        '
        Me.vcboNhomTB.AssemblyName = ""
        Me.vcboNhomTB.BackColor = System.Drawing.Color.White
        Me.vcboNhomTB.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.vcboNhomTB.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.vcboNhomTB.ClassName = ""
        Me.vcboNhomTB.Display = ""
        Me.vcboNhomTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vcboNhomTB.ErrorProviderControl = Me.ErrorProvider1
        Me.vcboNhomTB.FormattingEnabled = True
        Me.vcboNhomTB.IsAll = False
        Me.vcboNhomTB.isInputNull = False
        Me.vcboNhomTB.IsNew = False
        Me.vcboNhomTB.IsNull = True
        Me.vcboNhomTB.ItemAll = " < ALL > "
        Me.vcboNhomTB.ItemNew = "...New"
        Me.vcboNhomTB.Location = New System.Drawing.Point(754, 3)
        Me.vcboNhomTB.MethodName = ""
        Me.vcboNhomTB.Name = "vcboNhomTB"
        Me.vcboNhomTB.Param = ""
        Me.vcboNhomTB.Param2 = ""
        Me.vcboNhomTB.Size = New System.Drawing.Size(164, 21)
        Me.vcboNhomTB.StoreName = ""
        Me.vcboNhomTB.TabIndex = 8
        Me.vcboNhomTB.Table = Nothing
        Me.vcboNhomTB.TextReadonly = False
        Me.vcboNhomTB.Value = ""
        '
        'vcboThietbi
        '
        Me.vcboThietbi.AssemblyName = ""
        Me.vcboThietbi.BackColor = System.Drawing.Color.White
        Me.vcboThietbi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.vcboThietbi.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.vcboThietbi.ClassName = ""
        Me.vcboThietbi.Display = ""
        Me.vcboThietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vcboThietbi.ErrorProviderControl = Me.ErrorProvider1
        Me.vcboThietbi.FormattingEnabled = True
        Me.vcboThietbi.IsAll = False
        Me.vcboThietbi.isInputNull = False
        Me.vcboThietbi.IsNew = False
        Me.vcboThietbi.IsNull = True
        Me.vcboThietbi.ItemAll = " < ALL > "
        Me.vcboThietbi.ItemNew = "...New"
        Me.vcboThietbi.Location = New System.Drawing.Point(163, 30)
        Me.vcboThietbi.MethodName = ""
        Me.vcboThietbi.Name = "vcboThietbi"
        Me.vcboThietbi.Param = ""
        Me.vcboThietbi.Param2 = ""
        Me.vcboThietbi.Size = New System.Drawing.Size(144, 21)
        Me.vcboThietbi.StoreName = ""
        Me.vcboThietbi.TabIndex = 9
        Me.vcboThietbi.Table = Nothing
        Me.vcboThietbi.TextReadonly = False
        Me.vcboThietbi.Value = ""
        '
        'vmtxtTuNgay
        '
        Me.vmtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vmtxtTuNgay.Location = New System.Drawing.Point(438, 30)
        Me.vmtxtTuNgay.Name = "vmtxtTuNgay"
        Me.vmtxtTuNgay.Size = New System.Drawing.Size(177, 21)
        Me.vmtxtTuNgay.TabIndex = 10
        '
        'vmtxtDenNgay
        '
        Me.vmtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vmtxtDenNgay.Location = New System.Drawing.Point(754, 30)
        Me.vmtxtDenNgay.Name = "vmtxtDenNgay"
        Me.vmtxtDenNgay.Size = New System.Drawing.Size(164, 21)
        Me.vmtxtDenNgay.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCanDoi)
        Me.Panel2.Controls.Add(Me.vbtnThoat)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 342)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(941, 29)
        Me.Panel2.TabIndex = 2
        '
        'btnCanDoi
        '
        Me.btnCanDoi.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCanDoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCanDoi.Location = New System.Drawing.Point(0, 0)
        Me.btnCanDoi.Name = "btnCanDoi"
        Me.btnCanDoi.Size = New System.Drawing.Size(127, 29)
        Me.btnCanDoi.TabIndex = 1
        Me.btnCanDoi.Text = "Doi chieu TG CM"
        Me.btnCanDoi.UseVisualStyleBackColor = True
        '
        'vbtnThoat
        '
        Me.vbtnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.vbtnThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vbtnThoat.Location = New System.Drawing.Point(829, 0)
        Me.vbtnThoat.Name = "vbtnThoat"
        Me.vbtnThoat.Size = New System.Drawing.Size(112, 29)
        Me.vbtnThoat.TabIndex = 0
        Me.vbtnThoat.Text = "Thoat"
        Me.vbtnThoat.UseVisualStyleBackColor = True
        '
        'grdView
        '
        Me.grdView.AllowUserToAddRows = False
        Me.grdView.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.Format = "N2"
        Me.grdView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vMS_MAY, Me.vSTT_NM, Me.vTU_NGAY, Me.vTU_GIO, Me.vDEN_NGAY, Me.vDEN_GIO, Me.vDIA_DIEM, Me.vDAY_CHUYEN, Me.vLOAI_DM, Me.vTG_NM, Me.vNGUYEN_NHAN, Me.vNN_CGQ, Me.vNGUOI_GQ})
        Me.grdView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdView.Location = New System.Drawing.Point(3, 63)
        Me.grdView.Name = "grdView"
        Me.grdView.RowHeadersVisible = False
        Me.grdView.Size = New System.Drawing.Size(941, 273)
        Me.grdView.TabIndex = 3
        '
        'vMS_MAY
        '
        Me.vMS_MAY.HeaderText = "vMS_MAY"
        Me.vMS_MAY.MinimumWidth = 100
        Me.vMS_MAY.Name = "vMS_MAY"
        '
        'vSTT_NM
        '
        Me.vSTT_NM.HeaderText = "vSTT_NM"
        Me.vSTT_NM.Name = "vSTT_NM"
        Me.vSTT_NM.Visible = False
        '
        'vTU_NGAY
        '
        Me.vTU_NGAY.HeaderText = "vTU_NGAY"
        Me.vTU_NGAY.MinimumWidth = 100
        Me.vTU_NGAY.Name = "vTU_NGAY"
        '
        'vTU_GIO
        '
        Me.vTU_GIO.HeaderText = "vTU_GIO"
        Me.vTU_GIO.MinimumWidth = 80
        Me.vTU_GIO.Name = "vTU_GIO"
        Me.vTU_GIO.Width = 80
        '
        'vDEN_NGAY
        '
        Me.vDEN_NGAY.HeaderText = "vDEN_NGAY"
        Me.vDEN_NGAY.MinimumWidth = 100
        Me.vDEN_NGAY.Name = "vDEN_NGAY"
        '
        'vDEN_GIO
        '
        Me.vDEN_GIO.HeaderText = "vDEN_GIO"
        Me.vDEN_GIO.MinimumWidth = 80
        Me.vDEN_GIO.Name = "vDEN_GIO"
        Me.vDEN_GIO.Width = 80
        '
        'vDIA_DIEM
        '
        Me.vDIA_DIEM.HeaderText = "vDIA_DIEM"
        Me.vDIA_DIEM.MinimumWidth = 120
        Me.vDIA_DIEM.Name = "vDIA_DIEM"
        Me.vDIA_DIEM.Width = 120
        '
        'vDAY_CHUYEN
        '
        Me.vDAY_CHUYEN.HeaderText = "vDAY_CHUYEN"
        Me.vDAY_CHUYEN.MinimumWidth = 120
        Me.vDAY_CHUYEN.Name = "vDAY_CHUYEN"
        Me.vDAY_CHUYEN.Width = 120
        '
        'vLOAI_DM
        '
        Me.vLOAI_DM.HeaderText = "vLOAI_DM"
        Me.vLOAI_DM.MinimumWidth = 100
        Me.vLOAI_DM.Name = "vLOAI_DM"
        '
        'vTG_NM
        '
        Me.vTG_NM.HeaderText = "vTG_NM"
        Me.vTG_NM.MinimumWidth = 100
        Me.vTG_NM.Name = "vTG_NM"
        '
        'vNGUYEN_NHAN
        '
        Me.vNGUYEN_NHAN.HeaderText = "vNGUYEN_NHAN"
        Me.vNGUYEN_NHAN.MinimumWidth = 100
        Me.vNGUYEN_NHAN.Name = "vNGUYEN_NHAN"
        '
        'vNN_CGQ
        '
        Me.vNN_CGQ.HeaderText = "vNN_CGQ"
        Me.vNN_CGQ.MinimumWidth = 100
        Me.vNN_CGQ.Name = "vNN_CGQ"
        '
        'vNGUOI_GQ
        '
        Me.vNGUOI_GQ.HeaderText = "vNGUOI_GQ"
        Me.vNGUOI_GQ.MinimumWidth = 100
        Me.vNGUOI_GQ.Name = "vNGUOI_GQ"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_MAY"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'QlGridMaskedTextBoxColumn1
        '
        Me.QlGridMaskedTextBoxColumn1.HeaderText = "TU_NGAY"
        Me.QlGridMaskedTextBoxColumn1.Mask = ""
        Me.QlGridMaskedTextBoxColumn1.MinimumWidth = 100
        Me.QlGridMaskedTextBoxColumn1.Name = "QlGridMaskedTextBoxColumn1"
        Me.QlGridMaskedTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QlGridMaskedTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'QlGridMaskedTextBoxColumn2
        '
        Me.QlGridMaskedTextBoxColumn2.HeaderText = "TU_GIO"
        Me.QlGridMaskedTextBoxColumn2.Mask = ""
        Me.QlGridMaskedTextBoxColumn2.MinimumWidth = 80
        Me.QlGridMaskedTextBoxColumn2.Name = "QlGridMaskedTextBoxColumn2"
        Me.QlGridMaskedTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QlGridMaskedTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QlGridMaskedTextBoxColumn2.Width = 80
        '
        'QlGridMaskedTextBoxColumn3
        '
        Me.QlGridMaskedTextBoxColumn3.HeaderText = "DEN_NGAY"
        Me.QlGridMaskedTextBoxColumn3.Mask = ""
        Me.QlGridMaskedTextBoxColumn3.MinimumWidth = 100
        Me.QlGridMaskedTextBoxColumn3.Name = "QlGridMaskedTextBoxColumn3"
        '
        'QlGridMaskedTextBoxColumn4
        '
        Me.QlGridMaskedTextBoxColumn4.HeaderText = "DEN_GIO"
        Me.QlGridMaskedTextBoxColumn4.Mask = ""
        Me.QlGridMaskedTextBoxColumn4.MinimumWidth = 80
        Me.QlGridMaskedTextBoxColumn4.Name = "QlGridMaskedTextBoxColumn4"
        Me.QlGridMaskedTextBoxColumn4.Width = 80
        '
        'QlGridMaskedTextBoxColumn5
        '
        Me.QlGridMaskedTextBoxColumn5.HeaderText = "DIA_DIEM"
        Me.QlGridMaskedTextBoxColumn5.Mask = ""
        Me.QlGridMaskedTextBoxColumn5.MinimumWidth = 100
        Me.QlGridMaskedTextBoxColumn5.Name = "QlGridMaskedTextBoxColumn5"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "DAY_CHUYEN"
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.HeaderText = "LOAI_DUNG_MAY"
        Me.DataGridViewComboBoxColumn2.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "THOI_GIAN_NM"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.HeaderText = "NGUYEN_NHAN"
        Me.DataGridViewComboBoxColumn3.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        '
        'DataGridViewComboBoxColumn4
        '
        Me.DataGridViewComboBoxColumn4.HeaderText = "NGUYEN_NHAN_CGQ"
        Me.DataGridViewComboBoxColumn4.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn4.Name = "DataGridViewComboBoxColumn4"
        '
        'DataGridViewComboBoxColumn5
        '
        Me.DataGridViewComboBoxColumn5.HeaderText = "NGUOI_GIAI_QUYET"
        Me.DataGridViewComboBoxColumn5.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn5.Name = "DataGridViewComboBoxColumn5"
        '
        'FrmThoiGianNgungMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 458)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmThoiGianNgungMay"
        Me.Text = "FrmThoiGianNgungMay"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabEdit.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdNgungMay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabView.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaTieuDe As System.Windows.Forms.Label
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabEdit As System.Windows.Forms.TabPage
    Friend WithEvents TabView As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbxLoaiMay As Commons.UtcComboBox
    Friend WithEvents lbaLoaiMay As System.Windows.Forms.Label
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grdNgungMay As System.Windows.Forms.DataGridView
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents BtnXoa As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnNguyenNhan As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QlGridMaskedTextBoxColumn1 As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents QlGridMaskedTextBoxColumn2 As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents QlGridMaskedTextBoxColumn3 As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents QlGridMaskedTextBoxColumn4 As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents QlGridMaskedTextBoxColumn5 As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents vlbaDiaDiem As System.Windows.Forms.Label
    Friend WithEvents vlabThietBi As System.Windows.Forms.Label
    Friend WithEvents vlbaLoaiTB As System.Windows.Forms.Label
    Friend WithEvents vlabTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaNhomTB As System.Windows.Forms.Label
    Friend WithEvents vlabDenNgay As System.Windows.Forms.Label
    Friend WithEvents vcboDiaDiem As Commons.UtcComboBox
    Friend WithEvents vcboLoaiTB As Commons.UtcComboBox
    Friend WithEvents vcboNhomTB As Commons.UtcComboBox
    Friend WithEvents vcboThietbi As Commons.UtcComboBox
    Friend WithEvents vmtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents vmtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCanDoi As System.Windows.Forms.Button
    Friend WithEvents vbtnThoat As System.Windows.Forms.Button
    Friend WithEvents grdView As System.Windows.Forms.DataGridView
    Friend WithEvents vMS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vSTT_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vTU_NGAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vTU_GIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vDEN_NGAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vDEN_GIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vDIA_DIEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vDAY_CHUYEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vLOAI_DM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vTG_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vNGUYEN_NHAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vNN_CGQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vNGUOI_GQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STT_NGUNG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TU_NGAY As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents TU_GIO As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents DEN_NGAY As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents DEN_GIO As Commons.QLGridMaskedTextBoxColumn
    Friend WithEvents DIA_DIEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DAY_CHUYEN As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents LOAI_DUNG_MAY As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents THOI_GIAN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NGUYEN_NHAN As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NGUYEN_NHAN_CGQ As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NGUOI_GIAI_QUYET As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnKhongGhi As System.Windows.Forms.Button
End Class
