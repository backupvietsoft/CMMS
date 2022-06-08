<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptChiPhiBaoTri
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlConten = New System.Windows.Forms.TableLayoutPanel()
        Me.pUpdate = New System.Windows.Forms.Panel()
        Me.chxChonTungMay = New System.Windows.Forms.CheckBox()
        Me.gTime = New System.Windows.Forms.GroupBox()
        Me.tlSelectTime = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdoNgay = New System.Windows.Forms.RadioButton()
        Me.rdoNam = New System.Windows.Forms.RadioButton()
        Me.rdoQuy = New System.Windows.Forms.RadioButton()
        Me.rdoThang = New System.Windows.Forms.RadioButton()
        Me.rdoTuan = New System.Windows.Forms.RadioButton()
        Me.dtDen = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtTu = New System.Windows.Forms.DateTimePicker()
        Me.cmbCity = New Commons.UtcComboBox()
        Me.cmbDistrict = New Commons.UtcComboBox()
        Me.cmbStreet = New Commons.UtcComboBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblDistrict = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gNhaxuong = New System.Windows.Forms.GroupBox()
        Me.gvNhaxuong = New System.Windows.Forms.DataGridView()
        Me.clChonnhaxuong = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clMsnhaxuong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clNhaxuong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbChonMay = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnChonAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBochon = New DevExpress.XtraEditors.SimpleButton()
        Me.grdDanhSachMay = New System.Windows.Forms.DataGridView()
        Me.CHON_MAY = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MS_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_MAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbxNhaXuong = New Commons.UtcComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaNhaXuong = New System.Windows.Forms.Label()
        Me.gNguyennhan = New System.Windows.Forms.GroupBox()
        Me.gvLoaiBT = New System.Windows.Forms.DataGridView()
        Me.clChonnguyennhan = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clMsLoaiBT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clLoaiBT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlConten.SuspendLayout()
        Me.pUpdate.SuspendLayout()
        Me.gTime.SuspendLayout()
        Me.tlSelectTime.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gNhaxuong.SuspendLayout()
        CType(Me.gvNhaxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbChonMay.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdDanhSachMay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gNguyennhan.SuspendLayout()
        CType(Me.gvLoaiBT, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tlConten.Controls.Add(Me.TableLayoutPanel2, 1, 2)
        Me.tlConten.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlConten.Location = New System.Drawing.Point(0, 0)
        Me.tlConten.Name = "tlConten"
        Me.tlConten.RowCount = 3
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlConten.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlConten.Size = New System.Drawing.Size(835, 674)
        Me.tlConten.TabIndex = 1
        '
        'pUpdate
        '
        Me.pUpdate.Controls.Add(Me.chxChonTungMay)
        Me.pUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pUpdate.Location = New System.Drawing.Point(3, 635)
        Me.pUpdate.Name = "pUpdate"
        Me.pUpdate.Size = New System.Drawing.Size(411, 36)
        Me.pUpdate.TabIndex = 0
        '
        'chxChonTungMay
        '
        Me.chxChonTungMay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chxChonTungMay.AutoSize = True
        Me.chxChonTungMay.Location = New System.Drawing.Point(3, 16)
        Me.chxChonTungMay.Name = "chxChonTungMay"
        Me.chxChonTungMay.Size = New System.Drawing.Size(100, 17)
        Me.chxChonTungMay.TabIndex = 4
        Me.chxChonTungMay.Text = "Chọn từng máy"
        Me.chxChonTungMay.UseVisualStyleBackColor = True
        '
        'gTime
        '
        Me.tlConten.SetColumnSpan(Me.gTime, 2)
        Me.gTime.Controls.Add(Me.tlSelectTime)
        Me.gTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gTime.Location = New System.Drawing.Point(3, 3)
        Me.gTime.Name = "gTime"
        Me.gTime.Size = New System.Drawing.Size(829, 144)
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
        Me.tlSelectTime.Location = New System.Drawing.Point(3, 17)
        Me.tlSelectTime.Name = "tlSelectTime"
        Me.tlSelectTime.RowCount = 5
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlSelectTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlSelectTime.Size = New System.Drawing.Size(823, 124)
        Me.tlSelectTime.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Từ ngày"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoNgay
        '
        Me.rdoNgay.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNgay, 2)
        Me.rdoNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNgay.Location = New System.Drawing.Point(5, 105)
        Me.rdoNgay.Margin = New System.Windows.Forms.Padding(5)
        Me.rdoNgay.Name = "rdoNgay"
        Me.rdoNgay.Size = New System.Drawing.Size(154, 18)
        Me.rdoNgay.TabIndex = 0
        Me.rdoNgay.Text = "Theo ngày"
        Me.rdoNgay.UseVisualStyleBackColor = True
        '
        'rdoNam
        '
        Me.rdoNam.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoNam, 2)
        Me.rdoNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoNam.Location = New System.Drawing.Point(661, 105)
        Me.rdoNam.Margin = New System.Windows.Forms.Padding(5)
        Me.rdoNam.Name = "rdoNam"
        Me.rdoNam.Size = New System.Drawing.Size(157, 18)
        Me.rdoNam.TabIndex = 4
        Me.rdoNam.Text = "Theo năm"
        Me.rdoNam.UseVisualStyleBackColor = True
        '
        'rdoQuy
        '
        Me.rdoQuy.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoQuy, 2)
        Me.rdoQuy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoQuy.Location = New System.Drawing.Point(497, 105)
        Me.rdoQuy.Margin = New System.Windows.Forms.Padding(5)
        Me.rdoQuy.Name = "rdoQuy"
        Me.rdoQuy.Size = New System.Drawing.Size(154, 18)
        Me.rdoQuy.TabIndex = 3
        Me.rdoQuy.Text = "Tỉnh"
        Me.rdoQuy.UseVisualStyleBackColor = True
        '
        'rdoThang
        '
        Me.rdoThang.AutoSize = True
        Me.rdoThang.Checked = True
        Me.tlSelectTime.SetColumnSpan(Me.rdoThang, 2)
        Me.rdoThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdoThang.Location = New System.Drawing.Point(333, 105)
        Me.rdoThang.Margin = New System.Windows.Forms.Padding(5)
        Me.rdoThang.Name = "rdoThang"
        Me.rdoThang.Size = New System.Drawing.Size(154, 18)
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
        Me.rdoTuan.Location = New System.Drawing.Point(169, 105)
        Me.rdoTuan.Margin = New System.Windows.Forms.Padding(5)
        Me.rdoTuan.Name = "rdoTuan"
        Me.rdoTuan.Size = New System.Drawing.Size(154, 18)
        Me.rdoTuan.TabIndex = 1
        Me.rdoTuan.Text = "Theo tuần"
        Me.rdoTuan.UseVisualStyleBackColor = True
        '
        'dtDen
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtDen, 3)
        Me.dtDen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDen.Location = New System.Drawing.Point(577, 3)
        Me.dtDen.Name = "dtDen"
        Me.dtDen.Size = New System.Drawing.Size(243, 21)
        Me.dtDen.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.tlSelectTime.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(413, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Đến ngày"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtTu
        '
        Me.tlSelectTime.SetColumnSpan(Me.dtTu, 3)
        Me.dtTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTu.Location = New System.Drawing.Point(167, 3)
        Me.dtTu.Name = "dtTu"
        Me.dtTu.Size = New System.Drawing.Size(240, 21)
        Me.dtTu.TabIndex = 15
        '
        'cmbCity
        '
        Me.cmbCity.AssemblyName = ""
        Me.cmbCity.BackColor = System.Drawing.Color.White
        Me.cmbCity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmbCity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbCity.ClassName = ""
        Me.tlSelectTime.SetColumnSpan(Me.cmbCity, 8)
        Me.cmbCity.Display = ""
        Me.cmbCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCity.ErrorProviderControl = Nothing
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.IsAll = False
        Me.cmbCity.isInputNull = False
        Me.cmbCity.IsNew = False
        Me.cmbCity.IsNull = True
        Me.cmbCity.ItemAll = " < ALL > "
        Me.cmbCity.ItemNew = "...New"
        Me.cmbCity.Location = New System.Drawing.Point(167, 28)
        Me.cmbCity.MethodName = ""
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Param = ""
        Me.cmbCity.Param2 = ""
        Me.cmbCity.Size = New System.Drawing.Size(653, 21)
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
        Me.cmbDistrict.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmbDistrict.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbDistrict.ClassName = ""
        Me.tlSelectTime.SetColumnSpan(Me.cmbDistrict, 8)
        Me.cmbDistrict.Display = ""
        Me.cmbDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistrict.ErrorProviderControl = Nothing
        Me.cmbDistrict.FormattingEnabled = True
        Me.cmbDistrict.IsAll = False
        Me.cmbDistrict.isInputNull = False
        Me.cmbDistrict.IsNew = False
        Me.cmbDistrict.IsNull = True
        Me.cmbDistrict.ItemAll = " < ALL > "
        Me.cmbDistrict.ItemNew = "...New"
        Me.cmbDistrict.Location = New System.Drawing.Point(167, 53)
        Me.cmbDistrict.MethodName = ""
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Param = ""
        Me.cmbDistrict.Param2 = ""
        Me.cmbDistrict.Size = New System.Drawing.Size(653, 21)
        Me.cmbDistrict.StoreName = ""
        Me.cmbDistrict.TabIndex = 18
        Me.cmbDistrict.Table = Nothing
        Me.cmbDistrict.TextReadonly = False
        Me.cmbDistrict.Value = ""
        '
        'cmbStreet
        '
        Me.cmbStreet.AssemblyName = ""
        Me.cmbStreet.BackColor = System.Drawing.Color.White
        Me.cmbStreet.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmbStreet.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbStreet.ClassName = ""
        Me.tlSelectTime.SetColumnSpan(Me.cmbStreet, 8)
        Me.cmbStreet.Display = ""
        Me.cmbStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbStreet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStreet.ErrorProviderControl = Nothing
        Me.cmbStreet.FormattingEnabled = True
        Me.cmbStreet.IsAll = False
        Me.cmbStreet.isInputNull = False
        Me.cmbStreet.IsNew = False
        Me.cmbStreet.IsNull = True
        Me.cmbStreet.ItemAll = " < ALL > "
        Me.cmbStreet.ItemNew = "...New"
        Me.cmbStreet.Location = New System.Drawing.Point(167, 78)
        Me.cmbStreet.MethodName = ""
        Me.cmbStreet.Name = "cmbStreet"
        Me.cmbStreet.Param = ""
        Me.cmbStreet.Param2 = ""
        Me.cmbStreet.Size = New System.Drawing.Size(653, 21)
        Me.cmbStreet.StoreName = ""
        Me.cmbStreet.TabIndex = 19
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
        Me.lblCity.Size = New System.Drawing.Size(158, 25)
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
        Me.lblDistrict.Size = New System.Drawing.Size(158, 25)
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
        Me.lblStreet.Size = New System.Drawing.Size(158, 25)
        Me.lblStreet.TabIndex = 22
        Me.lblStreet.Text = "Đường"
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.tlConten.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.gNhaxuong)
        Me.Panel2.Controls.Add(Me.grbChonMay)
        Me.Panel2.Controls.Add(Me.gNguyennhan)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(829, 476)
        Me.Panel2.TabIndex = 6
        '
        'gNhaxuong
        '
        Me.gNhaxuong.Controls.Add(Me.gvNhaxuong)
        Me.gNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gNhaxuong.Location = New System.Drawing.Point(0, 0)
        Me.gNhaxuong.Name = "gNhaxuong"
        Me.gNhaxuong.Size = New System.Drawing.Size(522, 476)
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.gvNhaxuong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvNhaxuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvNhaxuong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnhaxuong, Me.clMsnhaxuong, Me.clNhaxuong})
        Me.gvNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvNhaxuong.Location = New System.Drawing.Point(3, 17)
        Me.gvNhaxuong.Name = "gvNhaxuong"
        Me.gvNhaxuong.RowHeadersWidth = 28
        Me.gvNhaxuong.Size = New System.Drawing.Size(516, 456)
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
        'grbChonMay
        '
        Me.grbChonMay.Controls.Add(Me.TableLayoutPanel1)
        Me.grbChonMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbChonMay.Location = New System.Drawing.Point(0, 0)
        Me.grbChonMay.Name = "grbChonMay"
        Me.grbChonMay.Size = New System.Drawing.Size(522, 476)
        Me.grbChonMay.TabIndex = 5
        Me.grbChonMay.TabStop = False
        Me.grbChonMay.Text = "Chọn máy"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnChonAll, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBochon, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grdDanhSachMay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.18182!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.81818!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(516, 456)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'btnChonAll
        '
        Me.btnChonAll.Location = New System.Drawing.Point(3, 3)
        Me.btnChonAll.Name = "btnChonAll"
        Me.btnChonAll.Size = New System.Drawing.Size(76, 20)
        Me.btnChonAll.TabIndex = 4
        Me.btnChonAll.Text = "Chon het"
        '
        'btnBochon
        '
        Me.btnBochon.Location = New System.Drawing.Point(113, 3)
        Me.btnBochon.Name = "btnBochon"
        Me.btnBochon.Size = New System.Drawing.Size(48, 20)
        Me.btnBochon.TabIndex = 5
        Me.btnBochon.Text = "Bo chon"
        '
        'grdDanhSachMay
        '
        Me.grdDanhSachMay.AllowUserToAddRows = False
        Me.grdDanhSachMay.AllowUserToDeleteRows = False
        Me.grdDanhSachMay.AllowUserToResizeColumns = False
        Me.grdDanhSachMay.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grdDanhSachMay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhSachMay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhSachMay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON_MAY, Me.MS_MAY, Me.TEN_MAY})
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdDanhSachMay, 4)
        Me.grdDanhSachMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhSachMay.Location = New System.Drawing.Point(3, 63)
        Me.grdDanhSachMay.Name = "grdDanhSachMay"
        Me.grdDanhSachMay.Size = New System.Drawing.Size(510, 390)
        Me.grdDanhSachMay.TabIndex = 2
        '
        'CHON_MAY
        '
        Me.CHON_MAY.HeaderText = "Chọn"
        Me.CHON_MAY.Name = "CHON_MAY"
        '
        'MS_MAY
        '
        Me.MS_MAY.HeaderText = "MS MAY"
        Me.MS_MAY.Name = "MS_MAY"
        Me.MS_MAY.ReadOnly = True
        Me.MS_MAY.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MS_MAY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MS_MAY.Width = 150
        '
        'TEN_MAY
        '
        Me.TEN_MAY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_MAY.HeaderText = "Tên máy"
        Me.TEN_MAY.MinimumWidth = 120
        Me.TEN_MAY.Name = "TEN_MAY"
        Me.TEN_MAY.ReadOnly = True
        Me.TEN_MAY.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TEN_MAY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cbxNhaXuong
        '
        Me.cbxNhaXuong.AssemblyName = ""
        Me.cbxNhaXuong.BackColor = System.Drawing.Color.White
        Me.cbxNhaXuong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxNhaXuong.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxNhaXuong.ClassName = ""
        Me.cbxNhaXuong.Display = ""
        Me.cbxNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNhaXuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNhaXuong.FormattingEnabled = True
        Me.cbxNhaXuong.IsAll = True
        Me.cbxNhaXuong.isInputNull = False
        Me.cbxNhaXuong.IsNew = False
        Me.cbxNhaXuong.IsNull = True
        Me.cbxNhaXuong.ItemAll = " < ALL > "
        Me.cbxNhaXuong.ItemNew = "...New"
        Me.cbxNhaXuong.Location = New System.Drawing.Point(371, 3)
        Me.cbxNhaXuong.MethodName = ""
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.Param = ""
        Me.cbxNhaXuong.Param2 = ""
        Me.cbxNhaXuong.Size = New System.Drawing.Size(142, 21)
        Me.cbxNhaXuong.StoreName = ""
        Me.cbxNhaXuong.TabIndex = 1
        Me.cbxNhaXuong.Table = Nothing
        Me.cbxNhaXuong.TextReadonly = False
        Me.cbxNhaXuong.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Location = New System.Drawing.Point(261, 0)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(104, 60)
        Me.lbaNhaXuong.TabIndex = 0
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        '
        'gNguyennhan
        '
        Me.gNguyennhan.Controls.Add(Me.gvLoaiBT)
        Me.gNguyennhan.Dock = System.Windows.Forms.DockStyle.Right
        Me.gNguyennhan.Location = New System.Drawing.Point(522, 0)
        Me.gNguyennhan.Name = "gNguyennhan"
        Me.gNguyennhan.Size = New System.Drawing.Size(307, 476)
        Me.gNguyennhan.TabIndex = 2
        Me.gNguyennhan.TabStop = False
        Me.gNguyennhan.Text = "Chọn loại bảo trì"
        '
        'gvLoaiBT
        '
        Me.gvLoaiBT.AllowUserToAddRows = False
        Me.gvLoaiBT.AllowUserToDeleteRows = False
        Me.gvLoaiBT.AllowUserToResizeColumns = False
        Me.gvLoaiBT.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvLoaiBT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvLoaiBT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvLoaiBT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonnguyennhan, Me.clMsLoaiBT, Me.clLoaiBT})
        Me.gvLoaiBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvLoaiBT.Location = New System.Drawing.Point(3, 17)
        Me.gvLoaiBT.Name = "gvLoaiBT"
        Me.gvLoaiBT.RowHeadersWidth = 28
        Me.gvLoaiBT.Size = New System.Drawing.Size(301, 456)
        Me.gvLoaiBT.TabIndex = 0
        '
        'clChonnguyennhan
        '
        Me.clChonnguyennhan.HeaderText = "Chọn"
        Me.clChonnguyennhan.MinimumWidth = 50
        Me.clChonnguyennhan.Name = "clChonnguyennhan"
        Me.clChonnguyennhan.Width = 50
        '
        'clMsLoaiBT
        '
        Me.clMsLoaiBT.HeaderText = ""
        Me.clMsLoaiBT.Name = "clMsLoaiBT"
        Me.clMsLoaiBT.Visible = False
        '
        'clLoaiBT
        '
        Me.clLoaiBT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clLoaiBT.HeaderText = "Loại bảo trì"
        Me.clLoaiBT.MinimumWidth = 150
        Me.clLoaiBT.Name = "clLoaiBT"
        Me.clLoaiBT.ReadOnly = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(420, 635)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(412, 36)
        Me.TableLayoutPanel2.TabIndex = 12
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(305, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 12
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(195, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 11
        Me.btnThucHien.Text = "Thực hiện"
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn3.MinimumWidth = 50
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Width = 50
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
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
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nguyên nhân"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
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
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frmrptChiPhiBaoTri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlConten)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptChiPhiBaoTri"
        Me.Size = New System.Drawing.Size(835, 674)
        Me.tlConten.ResumeLayout(False)
        Me.pUpdate.ResumeLayout(False)
        Me.pUpdate.PerformLayout()
        Me.gTime.ResumeLayout(False)
        Me.tlSelectTime.ResumeLayout(False)
        Me.tlSelectTime.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.gNhaxuong.ResumeLayout(False)
        CType(Me.gvNhaxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbChonMay.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.grdDanhSachMay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gNguyennhan.ResumeLayout(False)
        CType(Me.gvLoaiBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlConten As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pUpdate As System.Windows.Forms.Panel
    Friend WithEvents chxChonTungMay As System.Windows.Forms.CheckBox
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
    Friend WithEvents grbChonMay As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnChonAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBochon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdDanhSachMay As System.Windows.Forms.DataGridView
    Friend WithEvents CHON_MAY As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_MAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxNhaXuong As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents gNguyennhan As System.Windows.Forms.GroupBox
    Friend WithEvents gvLoaiBT As System.Windows.Forms.DataGridView
    Friend WithEvents clChonnguyennhan As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clMsLoaiBT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clLoaiBT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbCity As Commons.UtcComboBox
    Friend WithEvents cmbDistrict As Commons.UtcComboBox
    Friend WithEvents cmbStreet As Commons.UtcComboBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
