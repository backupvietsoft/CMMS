<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeHoachSX
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblTieuDe = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThem = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnKhongGhi = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.tabKHSX = New System.Windows.Forms.TabControl
        Me.tabTheoLine = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.grdKH_SX_LINE = New Commons.QLGrid
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.lblTieuDeDayChuyen = New System.Windows.Forms.Label
        Me.tabTheoMay = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.lblTieuDeMay = New System.Windows.Forms.Label
        Me.lblLoaiMay = New System.Windows.Forms.Label
        Me.cboLoaiMay = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDayChuyenSX = New System.Windows.Forms.Label
        Me.cboDayChuyenSX = New Commons.UtcComboBox
        Me.grdKH_SX_MAY = New Commons.QLGrid
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tabKHSX.SuspendLayout()
        Me.tabTheoLine.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.grdKH_SX_LINE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.tabTheoMay.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdKH_SX_MAY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTieuDe)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(588, 397)
        Me.SplitContainer1.SplitterDistance = 37
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'lblTieuDe
        '
        Me.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieuDe.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTieuDe.ForeColor = System.Drawing.Color.Navy
        Me.lblTieuDe.Location = New System.Drawing.Point(0, 0)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(588, 37)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "KẾ HOẠCH SẢN XUẤT"
        Me.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tabKHSX, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(588, 356)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThem, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSua, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 321)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(582, 32)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnThem
        '
        Me.btnThem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThem.ForeColor = System.Drawing.Color.Blue
        Me.btnThem.Location = New System.Drawing.Point(215, 3)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(94, 26)
        Me.btnThem.TabIndex = 1
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnXoa)
        Me.Panel1.Controls.Add(Me.btnGhi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(405, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(84, 26)
        Me.Panel1.TabIndex = 3
        '
        'btnXoa
        '
        Me.btnXoa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnXoa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoa.ForeColor = System.Drawing.Color.DarkRed
        Me.btnXoa.Location = New System.Drawing.Point(0, 0)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(84, 26)
        Me.btnXoa.TabIndex = 1
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGhi.Location = New System.Drawing.Point(0, 0)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(84, 26)
        Me.btnGhi.TabIndex = 2
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        Me.btnGhi.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnThoat)
        Me.Panel2.Controls.Add(Me.btnKhongGhi)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(495, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(84, 26)
        Me.Panel2.TabIndex = 4
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Location = New System.Drawing.Point(0, 0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(84, 26)
        Me.btnThoat.TabIndex = 0
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnKhongGhi
        '
        Me.btnKhongGhi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKhongGhi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhi.Location = New System.Drawing.Point(0, 0)
        Me.btnKhongGhi.Name = "btnKhongGhi"
        Me.btnKhongGhi.Size = New System.Drawing.Size(84, 26)
        Me.btnKhongGhi.TabIndex = 0
        Me.btnKhongGhi.Text = "Không ghi"
        Me.btnKhongGhi.UseVisualStyleBackColor = True
        Me.btnKhongGhi.Visible = False
        '
        'btnSua
        '
        Me.btnSua.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSua.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSua.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSua.Location = New System.Drawing.Point(315, 3)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(84, 26)
        Me.btnSua.TabIndex = 5
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'tabKHSX
        '
        Me.tabKHSX.Controls.Add(Me.tabTheoLine)
        Me.tabKHSX.Controls.Add(Me.tabTheoMay)
        Me.tabKHSX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabKHSX.Location = New System.Drawing.Point(3, 3)
        Me.tabKHSX.Name = "tabKHSX"
        Me.tabKHSX.SelectedIndex = 0
        Me.tabKHSX.Size = New System.Drawing.Size(582, 312)
        Me.tabKHSX.TabIndex = 0
        '
        'tabTheoLine
        '
        Me.tabTheoLine.Controls.Add(Me.TableLayoutPanel3)
        Me.tabTheoLine.Location = New System.Drawing.Point(4, 22)
        Me.tabTheoLine.Name = "tabTheoLine"
        Me.tabTheoLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTheoLine.Size = New System.Drawing.Size(574, 286)
        Me.tabTheoLine.TabIndex = 0
        Me.tabTheoLine.Text = "Theo Line"
        Me.tabTheoLine.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.grdKH_SX_LINE, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(568, 280)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'grdKH_SX_LINE
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdKH_SX_LINE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdKH_SX_LINE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdKH_SX_LINE.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdKH_SX_LINE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdKH_SX_LINE.Location = New System.Drawing.Point(3, 30)
        Me.grdKH_SX_LINE.Name = "grdKH_SX_LINE"
        Me.grdKH_SX_LINE.Size = New System.Drawing.Size(562, 247)
        Me.grdKH_SX_LINE.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.lblTieuDeDayChuyen, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(562, 21)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'lblTieuDeDayChuyen
        '
        Me.lblTieuDeDayChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieuDeDayChuyen.Location = New System.Drawing.Point(3, 0)
        Me.lblTieuDeDayChuyen.Name = "lblTieuDeDayChuyen"
        Me.lblTieuDeDayChuyen.Size = New System.Drawing.Size(275, 21)
        Me.lblTieuDeDayChuyen.TabIndex = 0
        Me.lblTieuDeDayChuyen.Text = "Nhập kế hoạch sản xuất theo dây chuyền"
        Me.lblTieuDeDayChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabTheoMay
        '
        Me.tabTheoMay.Controls.Add(Me.TableLayoutPanel5)
        Me.tabTheoMay.Location = New System.Drawing.Point(4, 22)
        Me.tabTheoMay.Name = "tabTheoMay"
        Me.tabTheoMay.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTheoMay.Size = New System.Drawing.Size(574, 286)
        Me.tabTheoMay.TabIndex = 1
        Me.tabTheoMay.Text = "Theo Máy"
        Me.tabTheoMay.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.grdKH_SX_MAY, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(568, 280)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 7
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.lblTieuDeMay, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblLoaiMay, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cboLoaiMay, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblDayChuyenSX, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cboDayChuyenSX, 3, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(562, 26)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'lblTieuDeMay
        '
        Me.lblTieuDeMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTieuDeMay.Location = New System.Drawing.Point(3, 0)
        Me.lblTieuDeMay.Name = "lblTieuDeMay"
        Me.lblTieuDeMay.Size = New System.Drawing.Size(163, 26)
        Me.lblTieuDeMay.TabIndex = 0
        Me.lblTieuDeMay.Text = "Nhập kế hoạch sản xuất máy"
        Me.lblTieuDeMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoaiMay
        '
        Me.lblLoaiMay.AutoSize = True
        Me.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiMay.Location = New System.Drawing.Point(366, 0)
        Me.lblLoaiMay.Name = "lblLoaiMay"
        Me.lblLoaiMay.Size = New System.Drawing.Size(70, 26)
        Me.lblLoaiMay.TabIndex = 1
        Me.lblLoaiMay.Text = "Loại máy:"
        Me.lblLoaiMay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboLoaiMay
        '
        Me.cboLoaiMay.AssemblyName = ""
        Me.cboLoaiMay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLoaiMay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoaiMay.BackColor = System.Drawing.Color.White
        Me.cboLoaiMay.ClassName = ""
        Me.cboLoaiMay.Display = ""
        Me.cboLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiMay.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiMay.FormattingEnabled = True
        Me.cboLoaiMay.IsAll = False
        Me.cboLoaiMay.IsNew = False
        Me.cboLoaiMay.ItemAll = " < ALL > "
        Me.cboLoaiMay.ItemNew = "...New"
        Me.cboLoaiMay.Location = New System.Drawing.Point(442, 3)
        Me.cboLoaiMay.MethodName = ""
        Me.cboLoaiMay.Name = "cboLoaiMay"
        Me.cboLoaiMay.Param = ""
        Me.cboLoaiMay.Size = New System.Drawing.Size(103, 21)
        Me.cboLoaiMay.StoreName = ""
        Me.cboLoaiMay.TabIndex = 2
        Me.cboLoaiMay.Table = Nothing
        Me.cboLoaiMay.TextReadonly = False
        Me.cboLoaiMay.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblDayChuyenSX
        '
        Me.lblDayChuyenSX.AutoSize = True
        Me.lblDayChuyenSX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDayChuyenSX.Location = New System.Drawing.Point(180, 0)
        Me.lblDayChuyenSX.Name = "lblDayChuyenSX"
        Me.lblDayChuyenSX.Size = New System.Drawing.Size(71, 26)
        Me.lblDayChuyenSX.TabIndex = 3
        Me.lblDayChuyenSX.Text = "Dây chuyền:"
        Me.lblDayChuyenSX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDayChuyenSX
        '
        Me.cboDayChuyenSX.AssemblyName = ""
        Me.cboDayChuyenSX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDayChuyenSX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDayChuyenSX.BackColor = System.Drawing.Color.White
        Me.cboDayChuyenSX.ClassName = ""
        Me.cboDayChuyenSX.Display = ""
        Me.cboDayChuyenSX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDayChuyenSX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDayChuyenSX.ErrorProviderControl = Me.ErrorProvider1
        Me.cboDayChuyenSX.FormattingEnabled = True
        Me.cboDayChuyenSX.IsAll = False
        Me.cboDayChuyenSX.IsNew = False
        Me.cboDayChuyenSX.ItemAll = " < ALL > "
        Me.cboDayChuyenSX.ItemNew = "...New"
        Me.cboDayChuyenSX.Location = New System.Drawing.Point(257, 3)
        Me.cboDayChuyenSX.MethodName = ""
        Me.cboDayChuyenSX.Name = "cboDayChuyenSX"
        Me.cboDayChuyenSX.Param = ""
        Me.cboDayChuyenSX.Size = New System.Drawing.Size(103, 21)
        Me.cboDayChuyenSX.StoreName = ""
        Me.cboDayChuyenSX.TabIndex = 4
        Me.cboDayChuyenSX.Table = Nothing
        Me.cboDayChuyenSX.TextReadonly = False
        Me.cboDayChuyenSX.Value = ""
        '
        'grdKH_SX_MAY
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdKH_SX_MAY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdKH_SX_MAY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdKH_SX_MAY.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdKH_SX_MAY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdKH_SX_MAY.Location = New System.Drawing.Point(3, 35)
        Me.grdKH_SX_MAY.Name = "grdKH_SX_MAY"
        Me.grdKH_SX_MAY.Size = New System.Drawing.Size(562, 242)
        Me.grdKH_SX_MAY.TabIndex = 1
        '
        'frmKeHoachSX
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 397)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKeHoachSX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kế hoạch sản xuất"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.tabKHSX.ResumeLayout(False)
        Me.tabTheoLine.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.grdKH_SX_LINE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.tabTheoMay.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdKH_SX_MAY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTieuDe As System.Windows.Forms.Label
    Friend WithEvents tabKHSX As System.Windows.Forms.TabControl
    Friend WithEvents tabTheoLine As System.Windows.Forms.TabPage
    Friend WithEvents tabTheoMay As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdKH_SX_LINE As Commons.QLGrid
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTieuDeDayChuyen As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTieuDeMay As System.Windows.Forms.Label
    Friend WithEvents lblLoaiMay As System.Windows.Forms.Label
    Friend WithEvents cboLoaiMay As Commons.UtcComboBox
    Friend WithEvents grdKH_SX_MAY As Commons.QLGrid
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnKhongGhi As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents lblDayChuyenSX As System.Windows.Forms.Label
    Friend WithEvents cboDayChuyenSX As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
