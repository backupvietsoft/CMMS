<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBaoTriDinhKyThang
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
        Me.lbaTuNgay = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.lbaNguoiLap = New System.Windows.Forms.Label()
        Me.lbaNgayLap = New System.Windows.Forms.Label()
        Me.lbaNguoiDuyet = New System.Windows.Forms.Label()
        Me.lbaNgayDuyet = New System.Windows.Forms.Label()
        Me.mtxtNgayLap = New System.Windows.Forms.MaskedTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.mtxtNgayDuyet = New System.Windows.Forms.MaskedTextBox()
        Me.cbxNguoiLap = New System.Windows.Forms.ComboBox()
        Me.cbxNguoiDuyet = New System.Windows.Forms.ComboBox()
        Me.lbaNhaXuong = New System.Windows.Forms.Label()
        Me.cbxNhaXuong = New Commons.UtcComboBox()
        Me.cbxTrangThai = New System.Windows.Forms.ComboBox()
        Me.lbaTrangThai = New System.Windows.Forms.Label()
        Me.cmbCity = New Commons.UtcComboBox()
        Me.cmbDistrict = New Commons.UtcComboBox()
        Me.cmbStreet = New Commons.UtcComboBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.lblDistrict = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(83, 58)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(104, 25)
        Me.lbaTuNgay.TabIndex = 0
        Me.lbaTuNgay.Text = "Từ ngày:"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(462, 58)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(104, 25)
        Me.lbaDenNgay.TabIndex = 1
        Me.lbaDenNgay.Text = "Đến ngày:"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(193, 61)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(263, 21)
        Me.mtxtTuNgay.TabIndex = 2
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(572, 61)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(263, 21)
        Me.mtxtDenNgay.TabIndex = 3
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'lbaNguoiLap
        '
        Me.lbaNguoiLap.AutoSize = True
        Me.lbaNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNguoiLap.Location = New System.Drawing.Point(83, 108)
        Me.lbaNguoiLap.Name = "lbaNguoiLap"
        Me.lbaNguoiLap.Size = New System.Drawing.Size(104, 25)
        Me.lbaNguoiLap.TabIndex = 6
        Me.lbaNguoiLap.Text = "Người lập:"
        Me.lbaNguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaNgayLap
        '
        Me.lbaNgayLap.AutoSize = True
        Me.lbaNgayLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNgayLap.Location = New System.Drawing.Point(462, 108)
        Me.lbaNgayLap.Name = "lbaNgayLap"
        Me.lbaNgayLap.Size = New System.Drawing.Size(104, 25)
        Me.lbaNgayLap.TabIndex = 7
        Me.lbaNgayLap.Text = "Ngày lập:"
        Me.lbaNgayLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaNguoiDuyet
        '
        Me.lbaNguoiDuyet.AutoSize = True
        Me.lbaNguoiDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNguoiDuyet.Location = New System.Drawing.Point(83, 133)
        Me.lbaNguoiDuyet.Name = "lbaNguoiDuyet"
        Me.lbaNguoiDuyet.Size = New System.Drawing.Size(104, 25)
        Me.lbaNguoiDuyet.TabIndex = 8
        Me.lbaNguoiDuyet.Text = "Người Duyệt"
        Me.lbaNguoiDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaNgayDuyet
        '
        Me.lbaNgayDuyet.AutoSize = True
        Me.lbaNgayDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNgayDuyet.Location = New System.Drawing.Point(462, 133)
        Me.lbaNgayDuyet.Name = "lbaNgayDuyet"
        Me.lbaNgayDuyet.Size = New System.Drawing.Size(104, 25)
        Me.lbaNgayDuyet.TabIndex = 9
        Me.lbaNgayDuyet.Text = "Ngày duyệt"
        Me.lbaNgayDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtNgayLap
        '
        Me.mtxtNgayLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtNgayLap.Location = New System.Drawing.Point(572, 111)
        Me.mtxtNgayLap.Mask = "00/00/0000"
        Me.mtxtNgayLap.Name = "mtxtNgayLap"
        Me.mtxtNgayLap.Size = New System.Drawing.Size(263, 21)
        Me.mtxtNgayLap.TabIndex = 10
        Me.mtxtNgayLap.ValidatingType = GetType(Date)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.53846!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.53846!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNguoiLap, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNgayLap, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNguoiDuyet, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNgayDuyet, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtNgayLap, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtNgayDuyet, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNguoiLap, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNguoiDuyet, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxTrangThai, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTrangThai, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbCity, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDistrict, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbStreet, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCity, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStreet, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDistrict, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 8)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(920, 547)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'mtxtNgayDuyet
        '
        Me.mtxtNgayDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtNgayDuyet.Location = New System.Drawing.Point(572, 136)
        Me.mtxtNgayDuyet.Mask = "00/00/0000"
        Me.mtxtNgayDuyet.Name = "mtxtNgayDuyet"
        Me.mtxtNgayDuyet.Size = New System.Drawing.Size(263, 21)
        Me.mtxtNgayDuyet.TabIndex = 11
        Me.mtxtNgayDuyet.ValidatingType = GetType(Date)
        '
        'cbxNguoiLap
        '
        Me.cbxNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNguoiLap.FormattingEnabled = True
        Me.cbxNguoiLap.Location = New System.Drawing.Point(193, 111)
        Me.cbxNguoiLap.Name = "cbxNguoiLap"
        Me.cbxNguoiLap.Size = New System.Drawing.Size(263, 21)
        Me.cbxNguoiLap.TabIndex = 12
        '
        'cbxNguoiDuyet
        '
        Me.cbxNguoiDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNguoiDuyet.FormattingEnabled = True
        Me.cbxNguoiDuyet.Location = New System.Drawing.Point(193, 136)
        Me.cbxNguoiDuyet.Name = "cbxNguoiDuyet"
        Me.cbxNguoiDuyet.Size = New System.Drawing.Size(263, 21)
        Me.cbxNguoiDuyet.TabIndex = 13
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Location = New System.Drawing.Point(83, 83)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(104, 25)
        Me.lbaNhaXuong.TabIndex = 17
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cbxNhaXuong.IsAll = False
        Me.cbxNhaXuong.isInputNull = False
        Me.cbxNhaXuong.IsNew = False
        Me.cbxNhaXuong.IsNull = True
        Me.cbxNhaXuong.ItemAll = " < ALL > "
        Me.cbxNhaXuong.ItemNew = "...New"
        Me.cbxNhaXuong.Location = New System.Drawing.Point(193, 86)
        Me.cbxNhaXuong.MethodName = ""
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.Param = ""
        Me.cbxNhaXuong.Param2 = ""
        Me.cbxNhaXuong.Size = New System.Drawing.Size(263, 21)
        Me.cbxNhaXuong.StoreName = ""
        Me.cbxNhaXuong.TabIndex = 20
        Me.cbxNhaXuong.Table = Nothing
        Me.cbxNhaXuong.TextReadonly = False
        Me.cbxNhaXuong.Value = ""
        '
        'cbxTrangThai
        '
        Me.cbxTrangThai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTrangThai.FormattingEnabled = True
        Me.cbxTrangThai.Items.AddRange(New Object() {"Bình thường", "An toàn", "All"})
        Me.cbxTrangThai.Location = New System.Drawing.Point(572, 86)
        Me.cbxTrangThai.Name = "cbxTrangThai"
        Me.cbxTrangThai.Size = New System.Drawing.Size(263, 21)
        Me.cbxTrangThai.TabIndex = 16
        '
        'lbaTrangThai
        '
        Me.lbaTrangThai.AutoSize = True
        Me.lbaTrangThai.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaTrangThai.Location = New System.Drawing.Point(462, 83)
        Me.lbaTrangThai.Name = "lbaTrangThai"
        Me.lbaTrangThai.Size = New System.Drawing.Size(0, 25)
        Me.lbaTrangThai.TabIndex = 15
        Me.lbaTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCity
        '
        Me.cmbCity.AssemblyName = ""
        Me.cmbCity.BackColor = System.Drawing.Color.White
        Me.cmbCity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmbCity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbCity.ClassName = ""
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
        Me.cmbCity.Location = New System.Drawing.Point(193, 11)
        Me.cmbCity.MethodName = ""
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Param = ""
        Me.cmbCity.Param2 = ""
        Me.cmbCity.Size = New System.Drawing.Size(263, 21)
        Me.cmbCity.StoreName = ""
        Me.cmbCity.TabIndex = 22
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
        Me.cmbDistrict.Location = New System.Drawing.Point(572, 11)
        Me.cmbDistrict.MethodName = ""
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Param = ""
        Me.cmbDistrict.Param2 = ""
        Me.cmbDistrict.Size = New System.Drawing.Size(263, 21)
        Me.cmbDistrict.StoreName = ""
        Me.cmbDistrict.TabIndex = 23
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbStreet, 3)
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
        Me.cmbStreet.Location = New System.Drawing.Point(193, 36)
        Me.cmbStreet.MethodName = ""
        Me.cmbStreet.Name = "cmbStreet"
        Me.cmbStreet.Param = ""
        Me.cmbStreet.Param2 = ""
        Me.cmbStreet.Size = New System.Drawing.Size(642, 21)
        Me.cmbStreet.StoreName = ""
        Me.cmbStreet.TabIndex = 24
        Me.cmbStreet.Table = Nothing
        Me.cmbStreet.TextReadonly = False
        Me.cmbStreet.Value = ""
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCity.Location = New System.Drawing.Point(83, 8)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(104, 25)
        Me.lblCity.TabIndex = 25
        Me.lblCity.Text = "Tỉnh"
        Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStreet.Location = New System.Drawing.Point(83, 33)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(104, 25)
        Me.lblStreet.TabIndex = 26
        Me.lblStreet.Text = "Đường"
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDistrict
        '
        Me.lblDistrict.AutoSize = True
        Me.lblDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDistrict.Location = New System.Drawing.Point(462, 8)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(104, 25)
        Me.lblDistrict.TabIndex = 27
        Me.lblDistrict.Text = "Huyện"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 508)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(914, 36)
        Me.TableLayoutPanel2.TabIndex = 29
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(807, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 28
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(697, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 21
        Me.btnThucHien.Text = "Thực hiện"
        '
        'frmrptBaoTriDinhKyThang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBaoTriDinhKyThang"
        Me.Size = New System.Drawing.Size(920, 547)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaNguoiLap As System.Windows.Forms.Label
    Friend WithEvents lbaNgayLap As System.Windows.Forms.Label
    Friend WithEvents lbaNguoiDuyet As System.Windows.Forms.Label
    Friend WithEvents lbaNgayDuyet As System.Windows.Forms.Label
    Friend WithEvents mtxtNgayLap As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtNgayDuyet As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxNguoiLap As System.Windows.Forms.ComboBox
    Friend WithEvents cbxNguoiDuyet As System.Windows.Forms.ComboBox
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents cbxNhaXuong As Commons.UtcComboBox
    Friend WithEvents cbxTrangThai As System.Windows.Forms.ComboBox
    Friend WithEvents lbaTrangThai As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbCity As Commons.UtcComboBox
    Friend WithEvents cmbDistrict As Commons.UtcComboBox
    Friend WithEvents cmbStreet As Commons.UtcComboBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
