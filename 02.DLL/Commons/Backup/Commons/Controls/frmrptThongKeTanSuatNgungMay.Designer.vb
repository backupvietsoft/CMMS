<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptThongKeTanSuatNgungMay
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptThongKeTanSuatNgungMay))
        Me.tlConten = New System.Windows.Forms.TableLayoutPanel
        Me.pUpdate = New System.Windows.Forms.Panel
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.chxChonTheoMay = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
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
        Me.cmbCity = New Commons.UtcComboBox
        Me.cmbDistrict = New Commons.UtcComboBox
        Me.cmbStreet = New Commons.UtcComboBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.lblDistrict = New System.Windows.Forms.Label
        Me.lblStreet = New System.Windows.Forms.Label
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
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
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
        Me.TableLayoutPanel2.SuspendLayout()
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
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.tlConten.Size = New System.Drawing.Size(715, 507)
        Me.tlConten.TabIndex = 1
        '
        'pUpdate
        '
        Me.tlConten.SetColumnSpan(Me.pUpdate, 2)
        Me.pUpdate.Controls.Add(Me.TableLayoutPanel2)
        Me.pUpdate.Controls.Add(Me.Panel1)
        Me.pUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pUpdate.Location = New System.Drawing.Point(3, 473)
        Me.pUpdate.Name = "pUpdate"
        Me.pUpdate.Size = New System.Drawing.Size(709, 31)
        Me.pUpdate.TabIndex = 0
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(502, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 25)
        Me.btnThucHien.TabIndex = 5
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'chxChonTheoMay
        '
        Me.chxChonTheoMay.AutoSize = True
        Me.chxChonTheoMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chxChonTheoMay.Location = New System.Drawing.Point(3, 3)
        Me.chxChonTheoMay.Name = "chxChonTheoMay"
        Me.chxChonTheoMay.Size = New System.Drawing.Size(121, 25)
        Me.chxChonTheoMay.TabIndex = 4
        Me.chxChonTheoMay.Text = "Chọn theo từng máy"
        Me.chxChonTheoMay.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(695, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(14, 31)
        Me.Panel1.TabIndex = 2
        '
        'gTime
        '
        Me.tlConten.SetColumnSpan(Me.gTime, 2)
        Me.gTime.Controls.Add(Me.tlSelectTime)
        Me.gTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gTime.Location = New System.Drawing.Point(3, 3)
        Me.gTime.Name = "gTime"
        Me.gTime.Size = New System.Drawing.Size(709, 144)
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
        Me.tlSelectTime.Controls.Add(Me.rdoNgay, 0, 4)
        Me.tlSelectTime.Controls.Add(Me.rdoNam, 8, 4)
        Me.tlSelectTime.Controls.Add(Me.rdoQuy, 6, 4)
        Me.tlSelectTime.Controls.Add(Me.rdoThang, 4, 4)
        Me.tlSelectTime.Controls.Add(Me.rdoTuan, 2, 4)
        Me.tlSelectTime.Controls.Add(Me.dtDen, 7, 0)
        Me.tlSelectTime.Controls.Add(Me.Label2, 5, 0)
        Me.tlSelectTime.Controls.Add(Me.dtTu, 2, 0)
        Me.tlSelectTime.Controls.Add(Me.cmbCity, 2, 1)
        Me.tlSelectTime.Controls.Add(Me.cmbDistrict, 2, 2)
        Me.tlSelectTime.Controls.Add(Me.cmbStreet, 2, 3)
        Me.tlSelectTime.Controls.Add(Me.lblCity, 0, 1)
        Me.tlSelectTime.Controls.Add(Me.lblDistrict, 0, 2)
        Me.tlSelectTime.Controls.Add(Me.lblStreet, 0, 3)
        Me.tlSelectTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlSelectTime.Location = New System.Drawing.Point(3, 16)
        Me.tlSelectTime.Name = "tlSelectTime"
        Me.tlSelectTime.RowCount = 5
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.Size = New System.Drawing.Size(703, 125)
        Me.tlSelectTime.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Từ ngày"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoNgay
        '
        Me.rdoNgay.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNgay, 2)
        Me.rdoNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNgay.Location = New System.Drawing.Point(5, 104)
        Me.rdoNgay.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoNgay.Name = "rdoNgay"
        Me.rdoNgay.Size = New System.Drawing.Size(130, 17)
        Me.rdoNgay.TabIndex = 0
        Me.rdoNgay.Text = "Theo ngày"
        Me.rdoNgay.UseVisualStyleBackColor = True
        '
        'rdoNam
        '
        Me.rdoNam.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNam, 2)
        Me.rdoNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNam.Location = New System.Drawing.Point(565, 104)
        Me.rdoNam.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoNam.Name = "rdoNam"
        Me.rdoNam.Size = New System.Drawing.Size(133, 17)
        Me.rdoNam.TabIndex = 4
        Me.rdoNam.Text = "Theo năm"
        Me.rdoNam.UseVisualStyleBackColor = True
        '
        'rdoQuy
        '
        Me.rdoQuy.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoQuy, 2)
        Me.rdoQuy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoQuy.Location = New System.Drawing.Point(425, 104)
        Me.rdoQuy.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoQuy.Name = "rdoQuy"
        Me.rdoQuy.Size = New System.Drawing.Size(130, 17)
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
        Me.rdoThang.Location = New System.Drawing.Point(285, 104)
        Me.rdoThang.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoThang.Name = "rdoThang"
        Me.rdoThang.Size = New System.Drawing.Size(130, 17)
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
        Me.rdoTuan.Location = New System.Drawing.Point(145, 104)
        Me.rdoTuan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rdoTuan.Name = "rdoTuan"
        Me.rdoTuan.Size = New System.Drawing.Size(130, 17)
        Me.rdoTuan.TabIndex = 1
        Me.rdoTuan.Text = "Theo tuần"
        Me.rdoTuan.UseVisualStyleBackColor = True
        '
        'dtDen
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtDen, 3)
        Me.dtDen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDen.Location = New System.Drawing.Point(493, 3)
        Me.dtDen.Name = "dtDen"
        Me.dtDen.Size = New System.Drawing.Size(207, 20)
        Me.dtDen.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(353, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Đến ngày"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtTu
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtTu, 3)
        Me.dtTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTu.Location = New System.Drawing.Point(143, 3)
        Me.dtTu.Name = "dtTu"
        Me.dtTu.Size = New System.Drawing.Size(204, 20)
        Me.dtTu.TabIndex = 15
        '
        'cmbCity
        '
        Me.cmbCity.AssemblyName = ""
        Me.cmbCity.BackColor = System.Drawing.Color.White
        Me.cmbCity.ClassName = ""
        Me.tlSelectTime.SetColumnSpan(Me.cmbCity, 8)
        Me.cmbCity.Display = ""
        Me.cmbCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCity.ErrorProviderControl = Nothing
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.IsAll = False
        Me.cmbCity.IsNew = False
        Me.cmbCity.ItemAll = " < ALL > "
        Me.cmbCity.ItemNew = "...New"
        Me.cmbCity.Location = New System.Drawing.Point(143, 28)
        Me.cmbCity.MethodName = ""
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Param = ""
        Me.cmbCity.Size = New System.Drawing.Size(557, 21)
        Me.cmbCity.StoreName = ""
        Me.cmbCity.TabIndex = 17
        Me.cmbCity.Table = Nothing
        Me.cmbCity.TextReadonly = False
        Me.cmbCity.Value = ""
        '
        'cmbDistrict
        '
        Me.cmbDistrict.AssemblyName = ""
        Me.cmbDistrict.BackColor = System.Drawing.Color.White
        Me.cmbDistrict.ClassName = ""
        Me.tlSelectTime.SetColumnSpan(Me.cmbDistrict, 8)
        Me.cmbDistrict.Display = ""
        Me.cmbDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrict.ErrorProviderControl = Nothing
        Me.cmbDistrict.FormattingEnabled = True
        Me.cmbDistrict.IsAll = False
        Me.cmbDistrict.IsNew = False
        Me.cmbDistrict.ItemAll = " < ALL > "
        Me.cmbDistrict.ItemNew = "...New"
        Me.cmbDistrict.Location = New System.Drawing.Point(143, 53)
        Me.cmbDistrict.MethodName = ""
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Param = ""
        Me.cmbDistrict.Size = New System.Drawing.Size(557, 21)
        Me.cmbDistrict.StoreName = ""
        Me.cmbDistrict.TabIndex = 19
        Me.cmbDistrict.Table = Nothing
        Me.cmbDistrict.TextReadonly = False
        Me.cmbDistrict.Value = ""
        '
        'cmbStreet
        '
        Me.cmbStreet.AssemblyName = ""
        Me.cmbStreet.BackColor = System.Drawing.Color.White
        Me.cmbStreet.ClassName = ""
        Me.tlSelectTime.SetColumnSpan(Me.cmbStreet, 8)
        Me.cmbStreet.Display = ""
        Me.cmbStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbStreet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStreet.ErrorProviderControl = Nothing
        Me.cmbStreet.FormattingEnabled = True
        Me.cmbStreet.IsAll = False
        Me.cmbStreet.IsNew = False
        Me.cmbStreet.ItemAll = " < ALL > "
        Me.cmbStreet.ItemNew = "...New"
        Me.cmbStreet.Location = New System.Drawing.Point(143, 78)
        Me.cmbStreet.MethodName = ""
        Me.cmbStreet.Name = "cmbStreet"
        Me.cmbStreet.Param = ""
        Me.cmbStreet.Size = New System.Drawing.Size(557, 21)
        Me.cmbStreet.StoreName = ""
        Me.cmbStreet.TabIndex = 18
        Me.cmbStreet.Table = Nothing
        Me.cmbStreet.TextReadonly = False
        Me.cmbStreet.Value = ""
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.lblCity, 2)
        Me.lblCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCity.Location = New System.Drawing.Point(3, 25)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(134, 25)
        Me.lblCity.TabIndex = 20
        Me.lblCity.Text = "Tỉnh"
        Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDistrict
        '
        Me.lblDistrict.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.lblDistrict, 2)
        Me.lblDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDistrict.Location = New System.Drawing.Point(3, 50)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(134, 25)
        Me.lblDistrict.TabIndex = 21
        Me.lblDistrict.Text = "Huyện"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.lblStreet, 2)
        Me.lblStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStreet.Location = New System.Drawing.Point(3, 75)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(134, 25)
        Me.lblStreet.TabIndex = 22
        Me.lblStreet.Text = "Đường"
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.tlConten.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.gNhaxuong)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.gNguyennhan)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(709, 314)
        Me.Panel2.TabIndex = 6
        '
        'gNhaxuong
        '
        Me.gNhaxuong.Controls.Add(Me.gvNhaxuong)
        Me.gNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gNhaxuong.Location = New System.Drawing.Point(0, 0)
        Me.gNhaxuong.Name = "gNhaxuong"
        Me.gNhaxuong.Size = New System.Drawing.Size(331, 314)
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
        Me.gvNhaxuong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvNhaxuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvNhaxuong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnhaxuong, Me.clMsnhaxuong, Me.clNhaxuong})
        Me.gvNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvNhaxuong.Location = New System.Drawing.Point(3, 16)
        Me.gvNhaxuong.Name = "gvNhaxuong"
        Me.gvNhaxuong.RowHeadersWidth = 28
        Me.gvNhaxuong.Size = New System.Drawing.Size(325, 295)
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
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 314)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gv_Maychon, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaxuong, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaxuong, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnChonAll, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBochon, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(325, 295)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gv_Maychon
        '
        Me.gv_Maychon.AllowUserToAddRows = False
        Me.gv_Maychon.AllowUserToDeleteRows = False
        Me.gv_Maychon.AllowUserToResizeColumns = False
        Me.gv_Maychon.AllowUserToResizeRows = False
        Me.gv_Maychon.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gv_Maychon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_Maychon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON_MAY, Me.MS_MAY, Me.TEN_MAY})
        Me.TableLayoutPanel1.SetColumnSpan(Me.gv_Maychon, 4)
        Me.gv_Maychon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gv_Maychon.Location = New System.Drawing.Point(3, 30)
        Me.gv_Maychon.Name = "gv_Maychon"
        Me.gv_Maychon.Size = New System.Drawing.Size(319, 262)
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
        Me.cbxNhaxuong.Location = New System.Drawing.Point(253, 3)
        Me.cbxNhaxuong.MethodName = ""
        Me.cbxNhaxuong.Name = "cbxNhaxuong"
        Me.cbxNhaxuong.Param = ""
        Me.cbxNhaxuong.Size = New System.Drawing.Size(69, 21)
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
        Me.lbaNhaxuong.Location = New System.Drawing.Point(163, 0)
        Me.lbaNhaxuong.Name = "lbaNhaxuong"
        Me.lbaNhaxuong.Size = New System.Drawing.Size(84, 27)
        Me.lbaNhaxuong.TabIndex = 0
        Me.lbaNhaxuong.Text = "Nhà xưởng"
        Me.lbaNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnChonAll
        '
        Me.btnChonAll.Location = New System.Drawing.Point(3, 3)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(76, 21)
        Me.btnChonAll.TabIndex = 3
        Me.btnChonAll.Text = "Chon het"
        Me.btnChonAll.UseVisualStyleBackColor = True
        '
        'btnBochon
        '
        Me.btnBochon.Location = New System.Drawing.Point(89, 3)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(68, 21)
        Me.btnBochon.TabIndex = 4
        Me.btnBochon.Text = "Bo chon"
        Me.btnBochon.UseVisualStyleBackColor = True
        '
        'gNguyennhan
        '
        Me.gNguyennhan.Controls.Add(Me.gvNguyennhan)
        Me.gNguyennhan.Dock = System.Windows.Forms.DockStyle.Right
        Me.gNguyennhan.Location = New System.Drawing.Point(331, 0)
        Me.gNguyennhan.Name = "gNguyennhan"
        Me.gNguyennhan.Size = New System.Drawing.Size(378, 314)
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvNguyennhan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvNguyennhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvNguyennhan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnguyennhan, Me.clMsnguyennhan, Me.clNguyennhan, Me.HU_HONG, Me.BTDK})
        Me.gvNguyennhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvNguyennhan.Location = New System.Drawing.Point(3, 16)
        Me.gvNguyennhan.Name = "gvNguyennhan"
        Me.gvNguyennhan.RowHeadersWidth = 28
        Me.gvNguyennhan.Size = New System.Drawing.Size(372, 295)
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
        Me.HU_HONG.Width = 80
        '
        'BTDK
        '
        Me.BTDK.HeaderText = "BTDK"
        Me.BTDK.Name = "BTDK"
        Me.BTDK.ReadOnly = True
        Me.BTDK.Width = 50
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn3.MinimumWidth = 50
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Width = 50
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.HeaderText = "HU_HONG"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.ReadOnly = True
        Me.DataGridViewCheckBoxColumn4.Width = 80
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
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 80
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.HeaderText = "BTDK"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        Me.DataGridViewCheckBoxColumn5.ReadOnly = True
        Me.DataGridViewCheckBoxColumn5.Width = 50
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.chxChonTheoMay, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(695, 31)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(598, 3)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 25)
        Me.btnThoat.TabIndex = 38
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptThongKeTanSuatNgungMay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlConten)
        Me.Name = "frmrptThongKeTanSuatNgungMay"
        Me.Size = New System.Drawing.Size(715, 507)
        Me.tlConten.ResumeLayout(False)
        Me.pUpdate.ResumeLayout(False)
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
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlConten As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pUpdate As System.Windows.Forms.Panel
    Friend WithEvents chxChonTheoMay As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
    Friend WithEvents gNhaxuong As System.Windows.Forms.GroupBox
    Friend WithEvents gvNhaxuong As System.Windows.Forms.DataGridView
    Friend WithEvents clChonnhaxuong As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clMsnhaxuong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNhaxuong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gv_Maychon As System.Windows.Forms.DataGridView
    Friend WithEvents CHON_MAY As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxNhaxuong As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbaNhaxuong As System.Windows.Forms.Label
    Friend WithEvents btnChonAll As System.Windows.Forms.Button
    Friend WithEvents btnBochon As System.Windows.Forms.Button
    Friend WithEvents gNguyennhan As System.Windows.Forms.GroupBox
    Friend WithEvents gvNguyennhan As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents clChonnguyennhan As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clMsnguyennhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNguyennhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HU_HONG As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BTDK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmbCity As Commons.UtcComboBox
    Friend WithEvents cmbStreet As Commons.UtcComboBox
    Friend WithEvents cmbDistrict As Commons.UtcComboBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
