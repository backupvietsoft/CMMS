<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTSDMAY_NEW
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tlConten = New System.Windows.Forms.TableLayoutPanel
        Me.pUpdate = New System.Windows.Forms.Panel
        Me.chxChonTheoMay = New System.Windows.Forms.CheckBox
        Me.btThuchien = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btThoat = New System.Windows.Forms.Button
        Me.pSpace = New System.Windows.Forms.Panel
        Me.gTime = New System.Windows.Forms.GroupBox
        Me.tlSelectTime = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdoNgay = New System.Windows.Forms.RadioButton
        Me.rdoNam = New System.Windows.Forms.RadioButton
        Me.rdoQuy = New System.Windows.Forms.RadioButton
        Me.rdoThang = New System.Windows.Forms.RadioButton
        Me.rdoTuan = New System.Windows.Forms.RadioButton
        Me.dtDen = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtTu = New System.Windows.Forms.DateTimePicker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.gNhaxuong = New System.Windows.Forms.GroupBox
        Me.gvNhaxuong = New System.Windows.Forms.DataGridView
        Me.clChonnhaxuong = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.clMsnhaxuong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clNhaxuong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.gv_Maychon = New System.Windows.Forms.DataGridView
        Me.CHON_MAY = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MS_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cbxNhaxuong = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaNhaxuong = New System.Windows.Forms.Label
        Me.btnChonAll = New System.Windows.Forms.Button
        Me.btnBochon = New System.Windows.Forms.Button
        Me.gNguyennhan = New System.Windows.Forms.GroupBox
        Me.gvNguyennhan = New System.Windows.Forms.DataGridView
        Me.clChonnguyennhan = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.clMsnguyennhan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clNguyennhan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HU_HONG = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BTDK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tlConten.SuspendLayout()
        Me.pUpdate.SuspendLayout()
        Me.gTime.SuspendLayout()
        Me.tlSelectTime.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gNhaxuong.SuspendLayout()
        CType(Me.gvNhaxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gv_Maychon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gNguyennhan.SuspendLayout()
        CType(Me.gvNguyennhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlConten
        '
        Me.tlConten.ColumnCount = 2
        Me.tlConten.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlConten.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlConten.Controls.Add(Me.pUpdate, 0, 2)
        Me.tlConten.Controls.Add(Me.gTime, 0, 0)
        Me.tlConten.Controls.Add(Me.Panel2, 0, 1)
        Me.tlConten.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlConten.Location = New System.Drawing.Point(0, 0)
        Me.tlConten.Name = "tlConten"
        Me.tlConten.RowCount = 3
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlConten.Size = New System.Drawing.Size(614, 322)
        Me.tlConten.TabIndex = 0
        '
        'pUpdate
        '
        Me.tlConten.SetColumnSpan(Me.pUpdate, 2)
        Me.pUpdate.Controls.Add(Me.chxChonTheoMay)
        Me.pUpdate.Controls.Add(Me.btThuchien)
        Me.pUpdate.Controls.Add(Me.Panel1)
        Me.pUpdate.Controls.Add(Me.btThoat)
        Me.pUpdate.Controls.Add(Me.pSpace)
        Me.pUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pUpdate.Location = New System.Drawing.Point(3, 273)
        Me.pUpdate.Name = "pUpdate"
        Me.pUpdate.Size = New System.Drawing.Size(608, 46)
        Me.pUpdate.TabIndex = 0
        '
        'chxChonTheoMay
        '
        Me.chxChonTheoMay.AutoSize = True
        Me.chxChonTheoMay.Location = New System.Drawing.Point(8, 5)
        Me.chxChonTheoMay.Name = "chxChonTheoMay"
        Me.chxChonTheoMay.Size = New System.Drawing.Size(141, 18)
        Me.chxChonTheoMay.TabIndex = 4
        Me.chxChonTheoMay.Text = "Chọn theo từng máy"
        Me.chxChonTheoMay.UseVisualStyleBackColor = True
        '
        'btThuchien
        '
        Me.btThuchien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btThuchien.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btThuchien.Location = New System.Drawing.Point(411, 0)
        Me.btThuchien.Name = "btThuchien"
        Me.btThuchien.Size = New System.Drawing.Size(77, 46)
        Me.btThuchien.TabIndex = 3
        Me.btThuchien.Text = "Thực hiện"
        Me.btThuchien.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(488, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(17, 46)
        Me.Panel1.TabIndex = 2
        '
        'btThoat
        '
        Me.btThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btThoat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btThoat.Location = New System.Drawing.Point(505, 0)
        Me.btThoat.Name = "btThoat"
        Me.btThoat.Size = New System.Drawing.Size(77, 46)
        Me.btThoat.TabIndex = 1
        Me.btThoat.Text = "Th&oát"
        Me.btThoat.UseVisualStyleBackColor = True
        '
        'pSpace
        '
        Me.pSpace.Dock = System.Windows.Forms.DockStyle.Right
        Me.pSpace.Location = New System.Drawing.Point(582, 0)
        Me.pSpace.Name = "pSpace"
        Me.pSpace.Size = New System.Drawing.Size(26, 46)
        Me.pSpace.TabIndex = 0
        '
        'gTime
        '
        Me.tlConten.SetColumnSpan(Me.gTime, 2)
        Me.gTime.Controls.Add(Me.tlSelectTime)
        Me.gTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gTime.Location = New System.Drawing.Point(3, 3)
        Me.gTime.Name = "gTime"
        Me.gTime.Size = New System.Drawing.Size(608, 66)
        Me.gTime.TabIndex = 1
        Me.gTime.TabStop = False
        Me.gTime.Text = "Chọn khoảng thời gian"
        '
        'tlSelectTime
        '
        Me.tlSelectTime.ColumnCount = 10
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlSelectTime.Controls.Add(Me.Label1, 0, 0)
        Me.tlSelectTime.Controls.Add(Me.rdoNgay, 0, 1)
        Me.tlSelectTime.Controls.Add(Me.rdoNam, 8, 1)
        Me.tlSelectTime.Controls.Add(Me.rdoQuy, 6, 1)
        Me.tlSelectTime.Controls.Add(Me.rdoThang, 4, 1)
        Me.tlSelectTime.Controls.Add(Me.rdoTuan, 2, 1)
        Me.tlSelectTime.Controls.Add(Me.dtDen, 7, 0)
        Me.tlSelectTime.Controls.Add(Me.Label2, 5, 0)
        Me.tlSelectTime.Controls.Add(Me.dtTu, 2, 0)
        Me.tlSelectTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlSelectTime.Location = New System.Drawing.Point(3, 18)
        Me.tlSelectTime.Name = "tlSelectTime"
        Me.tlSelectTime.RowCount = 2
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlSelectTime.Size = New System.Drawing.Size(602, 45)
        Me.tlSelectTime.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 22)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Từ ngày"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoNgay
        '
        Me.rdoNgay.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNgay, 2)
        Me.rdoNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNgay.Location = New System.Drawing.Point(4, 26)
        Me.rdoNgay.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdoNgay.Name = "rdoNgay"
        Me.rdoNgay.Size = New System.Drawing.Size(112, 15)
        Me.rdoNgay.TabIndex = 0
        Me.rdoNgay.Text = "Theo ngày"
        Me.rdoNgay.UseVisualStyleBackColor = True
        '
        'rdoNam
        '
        Me.rdoNam.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNam, 2)
        Me.rdoNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNam.Location = New System.Drawing.Point(484, 26)
        Me.rdoNam.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdoNam.Name = "rdoNam"
        Me.rdoNam.Size = New System.Drawing.Size(114, 15)
        Me.rdoNam.TabIndex = 4
        Me.rdoNam.Text = "Theo năm"
        Me.rdoNam.UseVisualStyleBackColor = True
        '
        'rdoQuy
        '
        Me.rdoQuy.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoQuy, 2)
        Me.rdoQuy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoQuy.Location = New System.Drawing.Point(364, 26)
        Me.rdoQuy.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdoQuy.Name = "rdoQuy"
        Me.rdoQuy.Size = New System.Drawing.Size(112, 15)
        Me.rdoQuy.TabIndex = 3
        Me.rdoQuy.Text = "Theo quý"
        Me.rdoQuy.UseVisualStyleBackColor = True
        '
        'rdoThang
        '
        Me.rdoThang.AutoSize = True
        Me.rdoThang.Checked = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoThang, 2)
        Me.rdoThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoThang.Location = New System.Drawing.Point(244, 26)
        Me.rdoThang.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdoThang.Name = "rdoThang"
        Me.rdoThang.Size = New System.Drawing.Size(112, 15)
        Me.rdoThang.TabIndex = 2
        Me.rdoThang.TabStop = True
        Me.rdoThang.Text = "Theo tháng"
        Me.rdoThang.UseVisualStyleBackColor = True
        '
        'rdoTuan
        '
        Me.rdoTuan.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoTuan, 2)
        Me.rdoTuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoTuan.Location = New System.Drawing.Point(124, 26)
        Me.rdoTuan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdoTuan.Name = "rdoTuan"
        Me.rdoTuan.Size = New System.Drawing.Size(112, 15)
        Me.rdoTuan.TabIndex = 1
        Me.rdoTuan.Text = "Theo tuần"
        Me.rdoTuan.UseVisualStyleBackColor = True
        '
        'dtDen
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtDen, 3)
        Me.dtDen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDen.Location = New System.Drawing.Point(423, 3)
        Me.dtDen.Name = "dtDen"
        Me.dtDen.Size = New System.Drawing.Size(176, 21)
        Me.dtDen.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(303, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Đến ngày"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtTu
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtTu, 3)
        Me.dtTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTu.Location = New System.Drawing.Point(123, 3)
        Me.dtTu.Name = "dtTu"
        Me.dtTu.Size = New System.Drawing.Size(174, 21)
        Me.dtTu.TabIndex = 15
        '
        'Panel2
        '
        Me.tlConten.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.gNhaxuong)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.gNguyennhan)
        Me.Panel2.Location = New System.Drawing.Point(3, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(590, 192)
        Me.Panel2.TabIndex = 6
        '
        'gNhaxuong
        '
        Me.gNhaxuong.Controls.Add(Me.gvNhaxuong)
        Me.gNhaxuong.Location = New System.Drawing.Point(3, 14)
        Me.gNhaxuong.Name = "gNhaxuong"
        Me.gNhaxuong.Size = New System.Drawing.Size(258, 183)
        Me.gNhaxuong.TabIndex = 4
        Me.gNhaxuong.TabStop = False
        Me.gNhaxuong.Text = "Chọn xưởng"
        '
        'gvNhaxuong
        '
        Me.gvNhaxuong.AllowUserToAddRows = False
        Me.gvNhaxuong.AllowUserToDeleteRows = False
        Me.gvNhaxuong.AllowUserToResizeColumns = False
        Me.gvNhaxuong.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvNhaxuong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvNhaxuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvNhaxuong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnhaxuong, Me.clMsnhaxuong, Me.clNhaxuong})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvNhaxuong.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvNhaxuong.Location = New System.Drawing.Point(3, 18)
        Me.gvNhaxuong.Name = "gvNhaxuong"
        Me.gvNhaxuong.RowHeadersWidth = 28
        Me.gvNhaxuong.Size = New System.Drawing.Size(252, 162)
        Me.gvNhaxuong.TabIndex = 0
        '
        'clChonnhaxuong
        '
        Me.clChonnhaxuong.HeaderText = "Chọn"
        Me.clChonnhaxuong.MinimumWidth = 50
        Me.clChonnhaxuong.Name = "clChonnhaxuong"
        Me.clChonnhaxuong.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clChonnhaxuong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clChonnhaxuong.Width = 50
        '
        'clMsnhaxuong
        '
        Me.clMsnhaxuong.HeaderText = ""
        Me.clMsnhaxuong.Name = "clMsnhaxuong"
        Me.clMsnhaxuong.Visible = False
        '
        'clNhaxuong
        '
        Me.clNhaxuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clNhaxuong.HeaderText = "Nhà xưởng"
        Me.clNhaxuong.MinimumWidth = 150
        Me.clNhaxuong.Name = "clNhaxuong"
        Me.clNhaxuong.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(590, 191)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gv_Maychon, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaxuong, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaxuong, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnChonAll, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBochon, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.59459!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.40541!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(584, 170)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gv_Maychon
        '
        Me.gv_Maychon.AllowUserToAddRows = False
        Me.gv_Maychon.AllowUserToDeleteRows = False
        Me.gv_Maychon.AllowUserToResizeColumns = False
        Me.gv_Maychon.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_Maychon.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gv_Maychon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_Maychon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON_MAY, Me.MS_MAY, Me.TEN_MAY})
        Me.TableLayoutPanel1.SetColumnSpan(Me.gv_Maychon, 4)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gv_Maychon.DefaultCellStyle = DataGridViewCellStyle4
        Me.gv_Maychon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gv_Maychon.Location = New System.Drawing.Point(3, 27)
        Me.gv_Maychon.Name = "gv_Maychon"
        Me.gv_Maychon.Size = New System.Drawing.Size(578, 140)
        Me.gv_Maychon.TabIndex = 2
        '
        'CHON_MAY
        '
        Me.CHON_MAY.HeaderText = "Chọn"
        Me.CHON_MAY.Name = "CHON_MAY"
        Me.CHON_MAY.Width = 80
        '
        'MS_MAY
        '
        Me.MS_MAY.HeaderText = "MS máy"
        Me.MS_MAY.Name = "MS_MAY"
        Me.MS_MAY.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MS_MAY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MS_MAY.Width = 150
        '
        'TEN_MAY
        '
        Me.TEN_MAY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_MAY.HeaderText = "Tên máy"
        Me.TEN_MAY.MinimumWidth = 150
        Me.TEN_MAY.Name = "TEN_MAY"
        Me.TEN_MAY.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TEN_MAY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cbxNhaxuong
        '
        Me.cbxNhaxuong.AssemblyName = ""
        Me.cbxNhaxuong.BackColor = System.Drawing.Color.White
        Me.cbxNhaxuong.ClassName = ""
        Me.cbxNhaxuong.Display = ""
        Me.cbxNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNhaxuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNhaxuong.FormattingEnabled = True
        Me.cbxNhaxuong.IsAll = False
        Me.cbxNhaxuong.IsNew = False
        Me.cbxNhaxuong.ItemAll = " < ALL > "
        Me.cbxNhaxuong.ItemNew = "...New"
        Me.cbxNhaxuong.Location = New System.Drawing.Point(370, 3)
        Me.cbxNhaxuong.MethodName = ""
        Me.cbxNhaxuong.Name = "cbxNhaxuong"
        Me.cbxNhaxuong.Param = ""
        Me.cbxNhaxuong.Size = New System.Drawing.Size(211, 21)
        Me.cbxNhaxuong.StoreName = ""
        Me.cbxNhaxuong.TabIndex = 1
        Me.cbxNhaxuong.Table = Nothing
        Me.cbxNhaxuong.TextReadonly = False
        Me.cbxNhaxuong.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaNhaxuong
        '
        Me.lbaNhaxuong.AutoSize = True
        Me.lbaNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaxuong.Location = New System.Drawing.Point(293, 0)
        Me.lbaNhaxuong.Name = "lbaNhaxuong"
        Me.lbaNhaxuong.Size = New System.Drawing.Size(71, 24)
        Me.lbaNhaxuong.TabIndex = 0
        Me.lbaNhaxuong.Text = "Nhà xưởng"
        Me.lbaNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnChonAll
        '
        Me.btnChonAll.Location = New System.Drawing.Point(3, 3)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(65, 18)
        Me.btnChonAll.TabIndex = 3
        Me.btnChonAll.Text = "Chon het"
        Me.btnChonAll.UseVisualStyleBackColor = True
        '
        'btnBochon
        '
        Me.btnBochon.Location = New System.Drawing.Point(77, 3)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(65, 18)
        Me.btnBochon.TabIndex = 4
        Me.btnBochon.Text = "Bo chon"
        Me.btnBochon.UseVisualStyleBackColor = True
        '
        'gNguyennhan
        '
        Me.gNguyennhan.Controls.Add(Me.gvNguyennhan)
        Me.gNguyennhan.Location = New System.Drawing.Point(263, 14)
        Me.gNguyennhan.Name = "gNguyennhan"
        Me.gNguyennhan.Size = New System.Drawing.Size(324, 178)
        Me.gNguyennhan.TabIndex = 2
        Me.gNguyennhan.TabStop = False
        Me.gNguyennhan.Text = "Chọn nguyên nhân"
        '
        'gvNguyennhan
        '
        Me.gvNguyennhan.AllowUserToAddRows = False
        Me.gvNguyennhan.AllowUserToDeleteRows = False
        Me.gvNguyennhan.AllowUserToResizeColumns = False
        Me.gvNguyennhan.AllowUserToResizeRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvNguyennhan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gvNguyennhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvNguyennhan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnguyennhan, Me.clMsnguyennhan, Me.clNguyennhan, Me.HU_HONG, Me.BTDK})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvNguyennhan.DefaultCellStyle = DataGridViewCellStyle6
        Me.gvNguyennhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvNguyennhan.Location = New System.Drawing.Point(3, 18)
        Me.gvNguyennhan.Name = "gvNguyennhan"
        Me.gvNguyennhan.RowHeadersWidth = 28
        Me.gvNguyennhan.Size = New System.Drawing.Size(318, 157)
        Me.gvNguyennhan.TabIndex = 0
        '
        'clChonnguyennhan
        '
        Me.clChonnguyennhan.HeaderText = "Chọn"
        Me.clChonnguyennhan.MinimumWidth = 50
        Me.clChonnguyennhan.Name = "clChonnguyennhan"
        Me.clChonnguyennhan.Width = 50
        '
        'clMsnguyennhan
        '
        Me.clMsnguyennhan.HeaderText = ""
        Me.clMsnguyennhan.Name = "clMsnguyennhan"
        Me.clMsnguyennhan.Visible = False
        '
        'clNguyennhan
        '
        Me.clNguyennhan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clNguyennhan.HeaderText = "Nguyên nhân"
        Me.clNguyennhan.MinimumWidth = 150
        Me.clNguyennhan.Name = "clNguyennhan"
        Me.clNguyennhan.ReadOnly = True
        '
        'HU_HONG
        '
        Me.HU_HONG.HeaderText = "HU_HONG"
        Me.HU_HONG.Name = "HU_HONG"
        Me.HU_HONG.ReadOnly = True
        Me.HU_HONG.Width = 80
        '
        'BTDK
        '
        Me.BTDK.HeaderText = "BTDK"
        Me.BTDK.Name = "BTDK"
        Me.BTDK.ReadOnly = True
        Me.BTDK.Width = 50
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 50
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nguyên nhân"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn3.MinimumWidth = 50
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = ""
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "Nguyên nhân"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.HeaderText = "HU_HONG"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.ReadOnly = True
        Me.DataGridViewCheckBoxColumn4.Width = 80
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.HeaderText = "BTDK"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        Me.DataGridViewCheckBoxColumn5.ReadOnly = True
        Me.DataGridViewCheckBoxColumn5.Width = 50
        '
        'FrmTSDMAY_NEW
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 322)
        Me.Controls.Add(Me.tlConten)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(620, 350)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(532, 327)
        Me.Name = "FrmTSDMAY_NEW"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thống kê tần suất dừng máy"
        Me.tlConten.ResumeLayout(False)
        Me.pUpdate.ResumeLayout(False)
        Me.pUpdate.PerformLayout()
        Me.gTime.ResumeLayout(False)
        Me.tlSelectTime.ResumeLayout(False)
        Me.tlSelectTime.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.gNhaxuong.ResumeLayout(False)
        CType(Me.gvNhaxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gv_Maychon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gNguyennhan.ResumeLayout(False)
        CType(Me.gvNguyennhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlConten As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pUpdate As System.Windows.Forms.Panel
    Friend WithEvents btThuchien As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btThoat As System.Windows.Forms.Button
    Friend WithEvents pSpace As System.Windows.Forms.Panel
    Friend WithEvents gTime As System.Windows.Forms.GroupBox
    Friend WithEvents gNguyennhan As System.Windows.Forms.GroupBox
    Friend WithEvents gvNguyennhan As System.Windows.Forms.DataGridView
    Friend WithEvents gNhaxuong As System.Windows.Forms.GroupBox
    Friend WithEvents gvNhaxuong As System.Windows.Forms.DataGridView
    Friend WithEvents tlSelectTime As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdoNgay As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTuan As System.Windows.Forms.RadioButton
    Friend WithEvents rdoThang As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQuy As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNam As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDen As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTu As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clMsnhaxuong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNhaxuong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clChonnhaxuong As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaNhaxuong As System.Windows.Forms.Label
    Friend WithEvents cbxNhaxuong As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gv_Maychon As System.Windows.Forms.DataGridView
    Friend WithEvents CHON_MAY As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chxChonTheoMay As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clChonnguyennhan As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clMsnguyennhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNguyennhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HU_HONG As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BTDK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnChonAll As System.Windows.Forms.Button
    Friend WithEvents btnBochon As System.Windows.Forms.Button
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
