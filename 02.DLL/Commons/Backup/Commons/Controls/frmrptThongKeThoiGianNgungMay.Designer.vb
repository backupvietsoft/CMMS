<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptThongKeThoiGianNgungMay
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptThongKeThoiGianNgungMay))
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.clChonnhaxuong = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.pUpdate = New System.Windows.Forms.Panel
        Me.chxChonTungMay = New System.Windows.Forms.CheckBox
        Me.gvNhaxuong = New System.Windows.Forms.DataGridView
        Me.clMsnhaxuong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clNhaxuong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gNhaxuong = New System.Windows.Forms.GroupBox
        Me.grbChonNN = New System.Windows.Forms.GroupBox
        Me.gvNguyennhan = New System.Windows.Forms.DataGridView
        Me.clChonnguyennhan = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.clMsnguyennhan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clNguyennhan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HU_HONG = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BTDK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnChonAll = New System.Windows.Forms.Button
        Me.grdDsMayChon = New System.Windows.Forms.DataGridView
        Me.CHON_MAY = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MS_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TEN_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cbxNhaxuong = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaNhaXuong = New System.Windows.Forms.Label
        Me.btnBochon = New System.Windows.Forms.Button
        Me.grbChonmay = New System.Windows.Forms.GroupBox
        Me.rdoNgay = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdoNam = New System.Windows.Forms.RadioButton
        Me.tlSelectTime = New System.Windows.Forms.TableLayoutPanel
        Me.rdoQuy = New System.Windows.Forms.RadioButton
        Me.rdoThang = New System.Windows.Forms.RadioButton
        Me.rdoTuan = New System.Windows.Forms.RadioButton
        Me.dtDen = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtTu = New System.Windows.Forms.DateTimePicker
        Me.tlConten = New System.Windows.Forms.TableLayoutPanel
        Me.gTime = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.pUpdate.SuspendLayout()
        CType(Me.gvNhaxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gNhaxuong.SuspendLayout()
        Me.grbChonNN.SuspendLayout()
        CType(Me.gvNguyennhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.grdDsMayChon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbChonmay.SuspendLayout()
        Me.tlSelectTime.SuspendLayout()
        Me.tlConten.SuspendLayout()
        Me.gTime.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(319, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 2
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
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
        'pUpdate
        '
        Me.tlConten.SetColumnSpan(Me.pUpdate, 2)
        Me.pUpdate.Controls.Add(Me.TableLayoutPanel1)
        Me.pUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pUpdate.Location = New System.Drawing.Point(3, 385)
        Me.pUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pUpdate.Name = "pUpdate"
        Me.pUpdate.Size = New System.Drawing.Size(512, 30)
        Me.pUpdate.TabIndex = 0
        '
        'chxChonTungMay
        '
        Me.chxChonTungMay.AutoSize = True
        Me.chxChonTungMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chxChonTungMay.Location = New System.Drawing.Point(3, 3)
        Me.chxChonTungMay.Name = "chxChonTungMay"
        Me.chxChonTungMay.Size = New System.Drawing.Size(97, 24)
        Me.chxChonTungMay.TabIndex = 4
        Me.chxChonTungMay.Text = "Chon tung may"
        Me.chxChonTungMay.UseVisualStyleBackColor = True
        '
        'gvNhaxuong
        '
        Me.gvNhaxuong.AllowUserToAddRows = False
        Me.gvNhaxuong.AllowUserToDeleteRows = False
        Me.gvNhaxuong.AllowUserToResizeColumns = False
        Me.gvNhaxuong.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvNhaxuong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvNhaxuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvNhaxuong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnhaxuong, Me.clMsnhaxuong, Me.clNhaxuong})
        Me.gvNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvNhaxuong.Location = New System.Drawing.Point(3, 15)
        Me.gvNhaxuong.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gvNhaxuong.Name = "gvNhaxuong"
        Me.gvNhaxuong.RowHeadersWidth = 28
        Me.gvNhaxuong.Size = New System.Drawing.Size(305, 282)
        Me.gvNhaxuong.TabIndex = 0
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
        'gNhaxuong
        '
        Me.gNhaxuong.Controls.Add(Me.gvNhaxuong)
        Me.gNhaxuong.Dock = System.Windows.Forms.DockStyle.Left
        Me.gNhaxuong.Location = New System.Drawing.Point(0, 0)
        Me.gNhaxuong.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gNhaxuong.Name = "gNhaxuong"
        Me.gNhaxuong.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gNhaxuong.Size = New System.Drawing.Size(311, 299)
        Me.gNhaxuong.TabIndex = 4
        Me.gNhaxuong.TabStop = False
        Me.gNhaxuong.Text = "Chọn xưởng"
        '
        'grbChonNN
        '
        Me.grbChonNN.Controls.Add(Me.gvNguyennhan)
        Me.grbChonNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbChonNN.Location = New System.Drawing.Point(311, 0)
        Me.grbChonNN.Name = "grbChonNN"
        Me.grbChonNN.Size = New System.Drawing.Size(201, 299)
        Me.grbChonNN.TabIndex = 5
        Me.grbChonNN.TabStop = False
        Me.grbChonNN.Text = "Chọn nguyên nhân"
        '
        'gvNguyennhan
        '
        Me.gvNguyennhan.AllowUserToAddRows = False
        Me.gvNguyennhan.AllowUserToDeleteRows = False
        Me.gvNguyennhan.AllowUserToResizeColumns = False
        Me.gvNguyennhan.AllowUserToResizeRows = False
        Me.gvNguyennhan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvNguyennhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvNguyennhan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnguyennhan, Me.clMsnguyennhan, Me.clNguyennhan, Me.HU_HONG, Me.BTDK})
        Me.gvNguyennhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvNguyennhan.Location = New System.Drawing.Point(3, 16)
        Me.gvNguyennhan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gvNguyennhan.Name = "gvNguyennhan"
        Me.gvNguyennhan.RowHeadersWidth = 28
        Me.gvNguyennhan.Size = New System.Drawing.Size(195, 280)
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
        Me.HU_HONG.HeaderText = "Hư hỏng"
        Me.HU_HONG.Name = "HU_HONG"
        Me.HU_HONG.ReadOnly = True
        Me.HU_HONG.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HU_HONG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.HU_HONG.Width = 50
        '
        'BTDK
        '
        Me.BTDK.HeaderText = "BTĐK"
        Me.BTDK.Name = "BTDK"
        Me.BTDK.ReadOnly = True
        Me.BTDK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BTDK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BTDK.Width = 50
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnChonAll, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.grdDsMayChon, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxNhaxuong, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbaNhaXuong, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBochon, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(195, 282)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnChonAll
        '
        Me.btnChonAll.Location = New System.Drawing.Point(3, 3)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(76, 20)
        Me.btnChonAll.TabIndex = 4
        Me.btnChonAll.Text = "Chon het"
        Me.btnChonAll.UseVisualStyleBackColor = True
        '
        'grdDsMayChon
        '
        Me.grdDsMayChon.AllowUserToAddRows = False
        Me.grdDsMayChon.AllowUserToDeleteRows = False
        Me.grdDsMayChon.AllowUserToResizeColumns = False
        Me.grdDsMayChon.AllowUserToResizeRows = False
        Me.grdDsMayChon.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDsMayChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDsMayChon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON_MAY, Me.MS_MAY, Me.TEN_MAY})
        Me.TableLayoutPanel2.SetColumnSpan(Me.grdDsMayChon, 4)
        Me.grdDsMayChon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDsMayChon.Location = New System.Drawing.Point(3, 31)
        Me.grdDsMayChon.Name = "grdDsMayChon"
        Me.grdDsMayChon.Size = New System.Drawing.Size(189, 248)
        Me.grdDsMayChon.TabIndex = 2
        '
        'CHON_MAY
        '
        Me.CHON_MAY.HeaderText = "Chọn"
        Me.CHON_MAY.Name = "CHON_MAY"
        Me.CHON_MAY.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHON_MAY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHON_MAY.Width = 80
        '
        'MS_MAY
        '
        Me.MS_MAY.HeaderText = "MS máy"
        Me.MS_MAY.Name = "MS_MAY"
        Me.MS_MAY.ReadOnly = True
        Me.MS_MAY.Width = 150
        '
        'TEN_MAY
        '
        Me.TEN_MAY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_MAY.HeaderText = "Tên máy"
        Me.TEN_MAY.MinimumWidth = 150
        Me.TEN_MAY.Name = "TEN_MAY"
        Me.TEN_MAY.ReadOnly = True
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
        Me.cbxNhaxuong.Location = New System.Drawing.Point(387, 3)
        Me.cbxNhaxuong.MethodName = ""
        Me.cbxNhaxuong.Name = "cbxNhaxuong"
        Me.cbxNhaxuong.Param = ""
        Me.cbxNhaxuong.Size = New System.Drawing.Size(1, 21)
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
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Location = New System.Drawing.Point(203, 0)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(178, 28)
        Me.lbaNhaXuong.TabIndex = 0
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBochon
        '
        Me.btnBochon.Location = New System.Drawing.Point(103, 3)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(68, 20)
        Me.btnBochon.TabIndex = 5
        Me.btnBochon.Text = "Bo chon"
        Me.btnBochon.UseVisualStyleBackColor = True
        '
        'grbChonmay
        '
        Me.grbChonmay.Controls.Add(Me.TableLayoutPanel2)
        Me.grbChonmay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbChonmay.Location = New System.Drawing.Point(311, 0)
        Me.grbChonmay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grbChonmay.Name = "grbChonmay"
        Me.grbChonmay.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grbChonmay.Size = New System.Drawing.Size(201, 299)
        Me.grbChonmay.TabIndex = 2
        Me.grbChonmay.TabStop = False
        Me.grbChonmay.Text = "Chọn máy"
        '
        'rdoNgay
        '
        Me.rdoNgay.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNgay, 2)
        Me.rdoNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNgay.Location = New System.Drawing.Point(5, 32)
        Me.rdoNgay.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoNgay.Name = "rdoNgay"
        Me.rdoNgay.Size = New System.Drawing.Size(90, 21)
        Me.rdoNgay.TabIndex = 0
        Me.rdoNgay.Text = "Theo ngày"
        Me.rdoNgay.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 28)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Từ ngày"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoNam
        '
        Me.rdoNam.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNam, 2)
        Me.rdoNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNam.Location = New System.Drawing.Point(405, 32)
        Me.rdoNam.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoNam.Name = "rdoNam"
        Me.rdoNam.Size = New System.Drawing.Size(96, 21)
        Me.rdoNam.TabIndex = 4
        Me.rdoNam.Text = "Theo năm"
        Me.rdoNam.UseVisualStyleBackColor = True
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
        Me.tlSelectTime.Location = New System.Drawing.Point(3, 15)
        Me.tlSelectTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tlSelectTime.Name = "tlSelectTime"
        Me.tlSelectTime.RowCount = 2
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlSelectTime.Size = New System.Drawing.Size(506, 57)
        Me.tlSelectTime.TabIndex = 0
        '
        'rdoQuy
        '
        Me.rdoQuy.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoQuy, 2)
        Me.rdoQuy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoQuy.Location = New System.Drawing.Point(305, 32)
        Me.rdoQuy.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoQuy.Name = "rdoQuy"
        Me.rdoQuy.Size = New System.Drawing.Size(90, 21)
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
        Me.rdoThang.Location = New System.Drawing.Point(205, 32)
        Me.rdoThang.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoThang.Name = "rdoThang"
        Me.rdoThang.Size = New System.Drawing.Size(90, 21)
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
        Me.rdoTuan.Location = New System.Drawing.Point(105, 32)
        Me.rdoTuan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoTuan.Name = "rdoTuan"
        Me.rdoTuan.Size = New System.Drawing.Size(90, 21)
        Me.rdoTuan.TabIndex = 1
        Me.rdoTuan.Text = "Theo tuần"
        Me.rdoTuan.UseVisualStyleBackColor = True
        '
        'dtDen
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtDen, 3)
        Me.dtDen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDen.Location = New System.Drawing.Point(353, 2)
        Me.dtDen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtDen.Name = "dtDen"
        Me.dtDen.Size = New System.Drawing.Size(150, 20)
        Me.dtDen.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(253, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 28)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Đến ngày"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtTu
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtTu, 3)
        Me.dtTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTu.Location = New System.Drawing.Point(103, 2)
        Me.dtTu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtTu.Name = "dtTu"
        Me.dtTu.Size = New System.Drawing.Size(144, 20)
        Me.dtTu.TabIndex = 15
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
        Me.tlConten.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tlConten.Name = "tlConten"
        Me.tlConten.RowCount = 3
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlConten.Size = New System.Drawing.Size(518, 417)
        Me.tlConten.TabIndex = 1
        '
        'gTime
        '
        Me.tlConten.SetColumnSpan(Me.gTime, 2)
        Me.gTime.Controls.Add(Me.tlSelectTime)
        Me.gTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gTime.Location = New System.Drawing.Point(3, 2)
        Me.gTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gTime.Name = "gTime"
        Me.gTime.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gTime.Size = New System.Drawing.Size(512, 74)
        Me.gTime.TabIndex = 1
        Me.gTime.TabStop = False
        Me.gTime.Text = "Chọn khoảng thời gian"
        '
        'Panel2
        '
        Me.tlConten.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.grbChonNN)
        Me.Panel2.Controls.Add(Me.grbChonmay)
        Me.Panel2.Controls.Add(Me.gNhaxuong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 81)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(512, 299)
        Me.Panel2.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nguyên nhân"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.HeaderText = "Nguyên nhân"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chxChonTungMay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(512, 30)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(415, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 24)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptThongKeThoiGianNgungMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlConten)
        Me.Name = "frmrptThongKeThoiGianNgungMay"
        Me.Size = New System.Drawing.Size(518, 417)
        Me.pUpdate.ResumeLayout(False)
        CType(Me.gvNhaxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gNhaxuong.ResumeLayout(False)
        Me.grbChonNN.ResumeLayout(False)
        CType(Me.gvNguyennhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.grdDsMayChon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbChonmay.ResumeLayout(False)
        Me.tlSelectTime.ResumeLayout(False)
        Me.tlSelectTime.PerformLayout()
        Me.tlConten.ResumeLayout(False)
        Me.gTime.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents clChonnhaxuong As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pUpdate As System.Windows.Forms.Panel
    Friend WithEvents tlConten As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gTime As System.Windows.Forms.GroupBox
    Friend WithEvents tlSelectTime As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdoNgay As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNam As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQuy As System.Windows.Forms.RadioButton
    Friend WithEvents rdoThang As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTuan As System.Windows.Forms.RadioButton
    Friend WithEvents dtDen As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtTu As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grbChonNN As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnChonAll As System.Windows.Forms.Button
    Friend WithEvents grdDsMayChon As System.Windows.Forms.DataGridView
    Friend WithEvents CHON_MAY As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxNhaxuong As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents btnBochon As System.Windows.Forms.Button
    Friend WithEvents gNhaxuong As System.Windows.Forms.GroupBox
    Friend WithEvents gvNhaxuong As System.Windows.Forms.DataGridView
    Friend WithEvents clMsnhaxuong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNhaxuong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grbChonmay As System.Windows.Forms.GroupBox
    Friend WithEvents gvNguyennhan As System.Windows.Forms.DataGridView
    Friend WithEvents clChonnguyennhan As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clMsnguyennhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNguyennhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HU_HONG As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BTDK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chxChonTungMay As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
