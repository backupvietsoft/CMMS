<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeHoachSanXuat
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.tbl = New System.Windows.Forms.TabControl
        Me.tpagTheoLine = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.lbaChonThang = New System.Windows.Forms.Label
        Me.lbaTieuDeLine = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnKhongGhi = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnThoat = New System.Windows.Forms.Button
        Me.gv_TheoLine = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.mtxtThang = New System.Windows.Forms.MaskedTextBox
        Me.cbxChonThang = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tpagTheoMay = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnThemMay = New System.Windows.Forms.Button
        Me.btnGhiMay = New System.Windows.Forms.Button
        Me.btnKhongGhiMay = New System.Windows.Forms.Button
        Me.btnSuaMay = New System.Windows.Forms.Button
        Me.btnXoaMay = New System.Windows.Forms.Button
        Me.btnThoatMay = New System.Windows.Forms.Button
        Me.lbaKhSXMay = New System.Windows.Forms.Label
        Me.lbaLoaiMay = New System.Windows.Forms.Label
        Me.cbxLoaiMay = New Commons.UtcComboBox
        Me.gv_May = New System.Windows.Forms.DataGridView
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.mtxtThangMay = New System.Windows.Forms.MaskedTextBox
        Me.bcxThangMay = New Commons.UtcComboBox
        Me.lbaChonThangMay = New System.Windows.Forms.Label
        Me.lbaTieuDe = New System.Windows.Forms.Label
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tbl.SuspendLayout()
        Me.tpagTheoLine.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gv_TheoLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpagTheoMay.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gv_May, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbl, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTieuDe, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(790, 440)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tbl
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbl, 2)
        Me.tbl.Controls.Add(Me.tpagTheoLine)
        Me.tbl.Controls.Add(Me.tpagTheoMay)
        Me.tbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbl.Location = New System.Drawing.Point(3, 41)
        Me.tbl.Name = "tbl"
        Me.tbl.SelectedIndex = 0
        Me.tbl.Size = New System.Drawing.Size(784, 396)
        Me.tbl.TabIndex = 0
        '
        'tpagTheoLine
        '
        Me.tpagTheoLine.Controls.Add(Me.TableLayoutPanel2)
        Me.tpagTheoLine.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tpagTheoLine.Location = New System.Drawing.Point(4, 22)
        Me.tpagTheoLine.Name = "tpagTheoLine"
        Me.tpagTheoLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tpagTheoLine.Size = New System.Drawing.Size(776, 370)
        Me.tpagTheoLine.TabIndex = 0
        Me.tpagTheoLine.Text = "Theo Line"
        Me.tpagTheoLine.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 441.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lbaChonThang, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaTieuDeLine, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.gv_TheoLine, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(770, 364)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lbaChonThang
        '
        Me.lbaChonThang.AutoSize = True
        Me.lbaChonThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaChonThang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaChonThang.Location = New System.Drawing.Point(444, 0)
        Me.lbaChonThang.Name = "lbaChonThang"
        Me.lbaChonThang.Size = New System.Drawing.Size(104, 33)
        Me.lbaChonThang.TabIndex = 1
        Me.lbaChonThang.Text = "Chọn tháng"
        Me.lbaChonThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbaTieuDeLine
        '
        Me.lbaTieuDeLine.AutoSize = True
        Me.lbaTieuDeLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTieuDeLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaTieuDeLine.Location = New System.Drawing.Point(3, 0)
        Me.lbaTieuDeLine.Name = "lbaTieuDeLine"
        Me.lbaTieuDeLine.Size = New System.Drawing.Size(435, 33)
        Me.lbaTieuDeLine.TabIndex = 3
        Me.lbaTieuDeLine.Text = "Nhập kế hoạch sản xuất theo dây chuyền"
        Me.lbaTieuDeLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.btnThem)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Controls.Add(Me.btnKhongGhi)
        Me.Panel1.Controls.Add(Me.btnSua)
        Me.Panel1.Controls.Add(Me.btnXoa)
        Me.Panel1.Controls.Add(Me.btnThoat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 331)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(764, 30)
        Me.Panel1.TabIndex = 4
        '
        'btnThem
        '
        Me.btnThem.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnThem.Location = New System.Drawing.Point(314, 0)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(75, 30)
        Me.btnThem.TabIndex = 5
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGhi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnGhi.Location = New System.Drawing.Point(389, 0)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(75, 30)
        Me.btnGhi.TabIndex = 4
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnKhongGhi
        '
        Me.btnKhongGhi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnKhongGhi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhi.ForeColor = System.Drawing.Color.Red
        Me.btnKhongGhi.Location = New System.Drawing.Point(464, 0)
        Me.btnKhongGhi.Name = "btnKhongGhi"
        Me.btnKhongGhi.Size = New System.Drawing.Size(75, 30)
        Me.btnKhongGhi.TabIndex = 3
        Me.btnKhongGhi.Text = "không ghi"
        Me.btnKhongGhi.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSua.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSua.ForeColor = System.Drawing.Color.Teal
        Me.btnSua.Location = New System.Drawing.Point(539, 0)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(75, 30)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnXoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoa.ForeColor = System.Drawing.Color.Red
        Me.btnXoa.Location = New System.Drawing.Point(614, 0)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 30)
        Me.btnXoa.TabIndex = 1
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(689, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(75, 30)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'gv_TheoLine
        '
        Me.gv_TheoLine.AllowUserToAddRows = False
        Me.gv_TheoLine.AllowUserToDeleteRows = False
        Me.gv_TheoLine.AllowUserToResizeColumns = False
        Me.gv_TheoLine.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.gv_TheoLine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gv_TheoLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel2.SetColumnSpan(Me.gv_TheoLine, 4)
        Me.gv_TheoLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gv_TheoLine.Location = New System.Drawing.Point(3, 36)
        Me.gv_TheoLine.Name = "gv_TheoLine"
        Me.gv_TheoLine.Size = New System.Drawing.Size(764, 289)
        Me.gv_TheoLine.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.mtxtThang)
        Me.Panel2.Controls.Add(Me.cbxChonThang)
        Me.Panel2.Location = New System.Drawing.Point(554, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(127, 27)
        Me.Panel2.TabIndex = 6
        '
        'mtxtThang
        '
        Me.mtxtThang.Location = New System.Drawing.Point(1, 4)
        Me.mtxtThang.Mask = "00/0000"
        Me.mtxtThang.Name = "mtxtThang"
        Me.mtxtThang.Size = New System.Drawing.Size(126, 21)
        Me.mtxtThang.TabIndex = 3
        '
        'cbxChonThang
        '
        Me.cbxChonThang.AssemblyName = ""
        Me.cbxChonThang.BackColor = System.Drawing.Color.White
        Me.cbxChonThang.ClassName = ""
        Me.cbxChonThang.Display = ""
        Me.cbxChonThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxChonThang.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxChonThang.FormattingEnabled = True
        Me.cbxChonThang.IsAll = False
        Me.cbxChonThang.isInputNull = False
        Me.cbxChonThang.IsNew = False
        Me.cbxChonThang.IsNull = True
        Me.cbxChonThang.ItemAll = " < ALL > "
        Me.cbxChonThang.ItemNew = "...New"
        Me.cbxChonThang.Location = New System.Drawing.Point(3, 3)
        Me.cbxChonThang.MethodName = ""
        Me.cbxChonThang.Name = "cbxChonThang"
        Me.cbxChonThang.Param = ""
        Me.cbxChonThang.Param2 = ""
        Me.cbxChonThang.Size = New System.Drawing.Size(124, 21)
        Me.cbxChonThang.StoreName = ""
        Me.cbxChonThang.TabIndex = 2
        Me.cbxChonThang.Table = Nothing
        Me.cbxChonThang.TextReadonly = False
        Me.cbxChonThang.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tpagTheoMay
        '
        Me.tpagTheoMay.Controls.Add(Me.TableLayoutPanel3)
        Me.tpagTheoMay.Location = New System.Drawing.Point(4, 22)
        Me.tpagTheoMay.Name = "tpagTheoMay"
        Me.tpagTheoMay.Padding = New System.Windows.Forms.Padding(3)
        Me.tpagTheoMay.Size = New System.Drawing.Size(776, 370)
        Me.tpagTheoMay.TabIndex = 1
        Me.tpagTheoMay.Text = "Theo máy"
        Me.tpagTheoMay.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lbaKhSXMay, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lbaLoaiMay, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxLoaiMay, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.gv_May, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lbaChonThangMay, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(770, 364)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Panel3
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel3, 5)
        Me.Panel3.Controls.Add(Me.btnThemMay)
        Me.Panel3.Controls.Add(Me.btnGhiMay)
        Me.Panel3.Controls.Add(Me.btnKhongGhiMay)
        Me.Panel3.Controls.Add(Me.btnSuaMay)
        Me.Panel3.Controls.Add(Me.btnXoaMay)
        Me.Panel3.Controls.Add(Me.btnThoatMay)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 331)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(764, 30)
        Me.Panel3.TabIndex = 0
        '
        'btnThemMay
        '
        Me.btnThemMay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThemMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThemMay.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnThemMay.Location = New System.Drawing.Point(314, 0)
        Me.btnThemMay.Name = "btnThemMay"
        Me.btnThemMay.Size = New System.Drawing.Size(75, 30)
        Me.btnThemMay.TabIndex = 5
        Me.btnThemMay.Text = "Thêm"
        Me.btnThemMay.UseVisualStyleBackColor = True
        Me.btnThemMay.Visible = False
        '
        'btnGhiMay
        '
        Me.btnGhiMay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGhiMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhiMay.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnGhiMay.Location = New System.Drawing.Point(389, 0)
        Me.btnGhiMay.Name = "btnGhiMay"
        Me.btnGhiMay.Size = New System.Drawing.Size(75, 30)
        Me.btnGhiMay.TabIndex = 4
        Me.btnGhiMay.Text = "Ghi"
        Me.btnGhiMay.UseVisualStyleBackColor = True
        '
        'btnKhongGhiMay
        '
        Me.btnKhongGhiMay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnKhongGhiMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhiMay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnKhongGhiMay.Location = New System.Drawing.Point(464, 0)
        Me.btnKhongGhiMay.Name = "btnKhongGhiMay"
        Me.btnKhongGhiMay.Size = New System.Drawing.Size(75, 30)
        Me.btnKhongGhiMay.TabIndex = 3
        Me.btnKhongGhiMay.Text = "Không Ghi"
        Me.btnKhongGhiMay.UseVisualStyleBackColor = True
        '
        'btnSuaMay
        '
        Me.btnSuaMay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSuaMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSuaMay.ForeColor = System.Drawing.Color.Teal
        Me.btnSuaMay.Location = New System.Drawing.Point(539, 0)
        Me.btnSuaMay.Name = "btnSuaMay"
        Me.btnSuaMay.Size = New System.Drawing.Size(75, 30)
        Me.btnSuaMay.TabIndex = 2
        Me.btnSuaMay.Text = "Sửa"
        Me.btnSuaMay.UseVisualStyleBackColor = True
        '
        'btnXoaMay
        '
        Me.btnXoaMay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnXoaMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoaMay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnXoaMay.Location = New System.Drawing.Point(614, 0)
        Me.btnXoaMay.Name = "btnXoaMay"
        Me.btnXoaMay.Size = New System.Drawing.Size(75, 30)
        Me.btnXoaMay.TabIndex = 1
        Me.btnXoaMay.Text = "Xóa"
        Me.btnXoaMay.UseVisualStyleBackColor = True
        '
        'btnThoatMay
        '
        Me.btnThoatMay.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoatMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoatMay.Location = New System.Drawing.Point(689, 0)
        Me.btnThoatMay.Name = "btnThoatMay"
        Me.btnThoatMay.Size = New System.Drawing.Size(75, 30)
        Me.btnThoatMay.TabIndex = 0
        Me.btnThoatMay.Text = "Thoát"
        Me.btnThoatMay.UseVisualStyleBackColor = True
        '
        'lbaKhSXMay
        '
        Me.lbaKhSXMay.AutoSize = True
        Me.lbaKhSXMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaKhSXMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaKhSXMay.Location = New System.Drawing.Point(3, 0)
        Me.lbaKhSXMay.Name = "lbaKhSXMay"
        Me.lbaKhSXMay.Size = New System.Drawing.Size(232, 34)
        Me.lbaKhSXMay.TabIndex = 1
        Me.lbaKhSXMay.Text = "Kế hoạch sản xuất máy"
        Me.lbaKhSXMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaLoaiMay
        '
        Me.lbaLoaiMay.AutoSize = True
        Me.lbaLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaLoaiMay.Location = New System.Drawing.Point(473, 0)
        Me.lbaLoaiMay.Name = "lbaLoaiMay"
        Me.lbaLoaiMay.Size = New System.Drawing.Size(134, 34)
        Me.lbaLoaiMay.TabIndex = 4
        Me.lbaLoaiMay.Text = "Loại máy"
        Me.lbaLoaiMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxLoaiMay
        '
        Me.cbxLoaiMay.AssemblyName = ""
        Me.cbxLoaiMay.BackColor = System.Drawing.Color.White
        Me.cbxLoaiMay.ClassName = ""
        Me.cbxLoaiMay.Display = ""
        Me.cbxLoaiMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxLoaiMay.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxLoaiMay.FormattingEnabled = True
        Me.cbxLoaiMay.IsAll = True
        Me.cbxLoaiMay.isInputNull = False
        Me.cbxLoaiMay.IsNew = False
        Me.cbxLoaiMay.IsNull = True
        Me.cbxLoaiMay.ItemAll = " < ALL > "
        Me.cbxLoaiMay.ItemNew = "...New"
        Me.cbxLoaiMay.Location = New System.Drawing.Point(613, 3)
        Me.cbxLoaiMay.MethodName = ""
        Me.cbxLoaiMay.Name = "cbxLoaiMay"
        Me.cbxLoaiMay.Param = ""
        Me.cbxLoaiMay.Param2 = ""
        Me.cbxLoaiMay.Size = New System.Drawing.Size(121, 21)
        Me.cbxLoaiMay.StoreName = ""
        Me.cbxLoaiMay.TabIndex = 5
        Me.cbxLoaiMay.Table = Nothing
        Me.cbxLoaiMay.TextReadonly = False
        Me.cbxLoaiMay.Value = ""
        '
        'gv_May
        '
        Me.gv_May.AllowUserToAddRows = False
        Me.gv_May.AllowUserToDeleteRows = False
        Me.gv_May.AllowUserToResizeColumns = False
        Me.gv_May.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.Format = "N2"
        Me.gv_May.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gv_May.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel3.SetColumnSpan(Me.gv_May, 5)
        Me.gv_May.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gv_May.Location = New System.Drawing.Point(3, 37)
        Me.gv_May.Name = "gv_May"
        Me.gv_May.Size = New System.Drawing.Size(764, 288)
        Me.gv_May.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.mtxtThangMay)
        Me.Panel4.Controls.Add(Me.bcxThangMay)
        Me.Panel4.Location = New System.Drawing.Point(345, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(122, 28)
        Me.Panel4.TabIndex = 7
        '
        'mtxtThangMay
        '
        Me.mtxtThangMay.Location = New System.Drawing.Point(0, 5)
        Me.mtxtThangMay.Mask = "00/0000"
        Me.mtxtThangMay.Name = "mtxtThangMay"
        Me.mtxtThangMay.Size = New System.Drawing.Size(122, 21)
        Me.mtxtThangMay.TabIndex = 1
        '
        'bcxThangMay
        '
        Me.bcxThangMay.AssemblyName = ""
        Me.bcxThangMay.BackColor = System.Drawing.Color.White
        Me.bcxThangMay.ClassName = ""
        Me.bcxThangMay.Display = ""
        Me.bcxThangMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.bcxThangMay.ErrorProviderControl = Me.ErrorProvider1
        Me.bcxThangMay.FormattingEnabled = True
        Me.bcxThangMay.IsAll = False
        Me.bcxThangMay.isInputNull = False
        Me.bcxThangMay.IsNew = False
        Me.bcxThangMay.IsNull = True
        Me.bcxThangMay.ItemAll = " < ALL > "
        Me.bcxThangMay.ItemNew = "...New"
        Me.bcxThangMay.Location = New System.Drawing.Point(0, 4)
        Me.bcxThangMay.MethodName = ""
        Me.bcxThangMay.Name = "bcxThangMay"
        Me.bcxThangMay.Param = ""
        Me.bcxThangMay.Param2 = ""
        Me.bcxThangMay.Size = New System.Drawing.Size(122, 21)
        Me.bcxThangMay.StoreName = ""
        Me.bcxThangMay.TabIndex = 0
        Me.bcxThangMay.Table = Nothing
        Me.bcxThangMay.TextReadonly = False
        Me.bcxThangMay.Value = ""
        '
        'lbaChonThangMay
        '
        Me.lbaChonThangMay.AutoSize = True
        Me.lbaChonThangMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaChonThangMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaChonThangMay.Location = New System.Drawing.Point(241, 0)
        Me.lbaChonThangMay.Name = "lbaChonThangMay"
        Me.lbaChonThangMay.Size = New System.Drawing.Size(98, 34)
        Me.lbaChonThangMay.TabIndex = 8
        Me.lbaChonThangMay.Text = "Chọn tháng"
        Me.lbaChonThangMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaTieuDe
        '
        Me.lbaTieuDe.AutoSize = True
        Me.lbaTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTieuDe.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaTieuDe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbaTieuDe.Location = New System.Drawing.Point(3, 0)
        Me.lbaTieuDe.Name = "lbaTieuDe"
        Me.lbaTieuDe.Size = New System.Drawing.Size(715, 38)
        Me.lbaTieuDe.TabIndex = 1
        Me.lbaTieuDe.Text = "KẾ HOẠCH SẢN XUẤT"
        Me.lbaTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(724, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(63, 32)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(32, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(30, 30)
        Me.btnHelp.TabIndex = 105
        Me.btnHelp.Tag = "CMMS!frmKeHoachSanXuat"
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(1, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(29, 30)
        Me.btnVideo.TabIndex = 104
        Me.btnVideo.Tag = "CMMS!frmKeHoachSanXuat"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_HE_THONG"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "TEN_HE_THONG"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle3.Format = "MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "THANG"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "SO_GIO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'frmKeHoachSanXuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 440)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmKeHoachSanXuat"
        Me.Text = "frmKeHoachSanXuat"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tbl.ResumeLayout(False)
        Me.tpagTheoLine.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gv_TheoLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpagTheoMay.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.gv_May, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbl As System.Windows.Forms.TabControl
    Friend WithEvents tpagTheoLine As System.Windows.Forms.TabPage
    Friend WithEvents tpagTheoMay As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaTieuDe As System.Windows.Forms.Label
    Friend WithEvents cbxChonThang As Commons.UtcComboBox
    Friend WithEvents lbaChonThang As System.Windows.Forms.Label
    Friend WithEvents lbaTieuDeLine As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnKhongGhi As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents gv_TheoLine As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents mtxtThang As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbaKhSXMay As System.Windows.Forms.Label
    Friend WithEvents lbaLoaiMay As System.Windows.Forms.Label
    Friend WithEvents cbxLoaiMay As Commons.UtcComboBox
    Friend WithEvents gv_May As System.Windows.Forms.DataGridView
    Friend WithEvents btnThemMay As System.Windows.Forms.Button
    Friend WithEvents btnGhiMay As System.Windows.Forms.Button
    Friend WithEvents btnKhongGhiMay As System.Windows.Forms.Button
    Friend WithEvents btnSuaMay As System.Windows.Forms.Button
    Friend WithEvents btnXoaMay As System.Windows.Forms.Button
    Friend WithEvents btnThoatMay As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents mtxtThangMay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents bcxThangMay As Commons.UtcComboBox
    Friend WithEvents lbaChonThangMay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
End Class
