﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBieuDoTGNMTheoNNHours
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.lbaTuThang = New System.Windows.Forms.Label()
        Me.cboNhaXuong = New Commons.UtcComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaNhaXuong = New System.Windows.Forms.Label()
        Me.cmbCity = New Commons.UtcComboBox()
        Me.cmbDistrict = New Commons.UtcComboBox()
        Me.cmbStreet = New Commons.UtcComboBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblDistrict = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.grdNguyenNhan = New System.Windows.Forms.DataGridView()
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MS_NGUYEN_NHAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEN_NGUYEN_NHAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HU_HONG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BTDK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNguyenNhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuThang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaXuong, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbCity, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDistrict, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbStreet, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCity, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDistrict, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStreet, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 7, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 6, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.grdNguyenNhan, 0, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(976, 619)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'mtxtTuNgay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.mtxtTuNgay, 2)
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(223, 11)
        Me.mtxtTuNgay.Mask = "00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(262, 21)
        Me.mtxtTuNgay.TabIndex = 6
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(491, 8)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(104, 25)
        Me.lbaDenNgay.TabIndex = 7
        Me.lbaDenNgay.Text = "Đến tháng"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtDenNgay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.mtxtDenNgay, 2)
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(601, 11)
        Me.mtxtDenNgay.Mask = "00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(262, 21)
        Me.mtxtDenNgay.TabIndex = 8
        '
        'lbaTuThang
        '
        Me.lbaTuThang.AutoSize = True
        Me.lbaTuThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuThang.Location = New System.Drawing.Point(113, 8)
        Me.lbaTuThang.Name = "lbaTuThang"
        Me.lbaTuThang.Size = New System.Drawing.Size(104, 25)
        Me.lbaTuThang.TabIndex = 9
        Me.lbaTuThang.Text = "Từ tháng"
        Me.lbaTuThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhaXuong
        '
        Me.cboNhaXuong.AssemblyName = ""
        Me.cboNhaXuong.BackColor = System.Drawing.Color.White
        Me.cboNhaXuong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboNhaXuong.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboNhaXuong.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhaXuong, 2)
        Me.cboNhaXuong.Display = ""
        Me.cboNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaXuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cboNhaXuong.FormattingEnabled = True
        Me.cboNhaXuong.IsAll = True
        Me.cboNhaXuong.isInputNull = False
        Me.cboNhaXuong.IsNew = False
        Me.cboNhaXuong.IsNull = True
        Me.cboNhaXuong.ItemAll = " < ALL > "
        Me.cboNhaXuong.ItemNew = "...New"
        Me.cboNhaXuong.Location = New System.Drawing.Point(601, 61)
        Me.cboNhaXuong.MethodName = ""
        Me.cboNhaXuong.Name = "cboNhaXuong"
        Me.cboNhaXuong.Param = ""
        Me.cboNhaXuong.Param2 = ""
        Me.cboNhaXuong.Size = New System.Drawing.Size(262, 21)
        Me.cboNhaXuong.StoreName = ""
        Me.cboNhaXuong.TabIndex = 3
        Me.cboNhaXuong.Table = Nothing
        Me.cboNhaXuong.TextReadonly = False
        Me.cboNhaXuong.Value = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Location = New System.Drawing.Point(491, 58)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(104, 25)
        Me.lbaNhaXuong.TabIndex = 1
        Me.lbaNhaXuong.Text = "Địa điểm"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCity
        '
        Me.cmbCity.AssemblyName = ""
        Me.cmbCity.BackColor = System.Drawing.Color.White
        Me.cmbCity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmbCity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cmbCity.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbCity, 2)
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
        Me.cmbCity.Location = New System.Drawing.Point(223, 36)
        Me.cmbCity.MethodName = ""
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Param = ""
        Me.cmbCity.Param2 = ""
        Me.cmbCity.Size = New System.Drawing.Size(262, 21)
        Me.cmbCity.StoreName = ""
        Me.cmbCity.TabIndex = 11
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbDistrict, 2)
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
        Me.cmbDistrict.Location = New System.Drawing.Point(601, 36)
        Me.cmbDistrict.MethodName = ""
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Param = ""
        Me.cmbDistrict.Param2 = ""
        Me.cmbDistrict.Size = New System.Drawing.Size(262, 21)
        Me.cmbDistrict.StoreName = ""
        Me.cmbDistrict.TabIndex = 12
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbStreet, 2)
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
        Me.cmbStreet.Location = New System.Drawing.Point(223, 61)
        Me.cmbStreet.MethodName = ""
        Me.cmbStreet.Name = "cmbStreet"
        Me.cmbStreet.Param = ""
        Me.cmbStreet.Param2 = ""
        Me.cmbStreet.Size = New System.Drawing.Size(262, 21)
        Me.cmbStreet.StoreName = ""
        Me.cmbStreet.TabIndex = 13
        Me.cmbStreet.Table = Nothing
        Me.cmbStreet.TextReadonly = False
        Me.cmbStreet.Value = ""
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCity.Location = New System.Drawing.Point(113, 33)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(104, 25)
        Me.lblCity.TabIndex = 14
        Me.lblCity.Text = "Tỉnh"
        Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDistrict
        '
        Me.lblDistrict.AutoSize = True
        Me.lblDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDistrict.Location = New System.Drawing.Point(491, 33)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(104, 25)
        Me.lblDistrict.TabIndex = 15
        Me.lblDistrict.Text = "Huyện"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStreet.Location = New System.Drawing.Point(113, 58)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(104, 25)
        Me.lblStreet.TabIndex = 16
        Me.lblStreet.Text = "Đường"
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(869, 582)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 17
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(759, 582)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 10
        Me.btnThucHien.Text = "Thực hiện"
        '
        'grdNguyenNhan
        '
        Me.grdNguyenNhan.AllowUserToAddRows = False
        Me.grdNguyenNhan.AllowUserToDeleteRows = False
        Me.grdNguyenNhan.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdNguyenNhan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdNguyenNhan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdNguyenNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNguyenNhan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON, Me.MS_NGUYEN_NHAN, Me.TEN_NGUYEN_NHAN, Me.HU_HONG, Me.BTDK})
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdNguyenNhan, 8)
        Me.grdNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNguyenNhan.Location = New System.Drawing.Point(3, 90)
        Me.grdNguyenNhan.Name = "grdNguyenNhan"
        Me.grdNguyenNhan.RowHeadersWidth = 25
        Me.grdNguyenNhan.Size = New System.Drawing.Size(970, 486)
        Me.grdNguyenNhan.TabIndex = 4
        '
        'CHON
        '
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.MinimumWidth = 50
        Me.CHON.Name = "CHON"
        Me.CHON.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHON.Width = 50
        '
        'MS_NGUYEN_NHAN
        '
        Me.MS_NGUYEN_NHAN.HeaderText = "MS Nguyên Nhân"
        Me.MS_NGUYEN_NHAN.MinimumWidth = 200
        Me.MS_NGUYEN_NHAN.Name = "MS_NGUYEN_NHAN"
        Me.MS_NGUYEN_NHAN.Visible = False
        Me.MS_NGUYEN_NHAN.Width = 200
        '
        'TEN_NGUYEN_NHAN
        '
        Me.TEN_NGUYEN_NHAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEN_NGUYEN_NHAN.HeaderText = "Tên Nguyên Nhân"
        Me.TEN_NGUYEN_NHAN.MinimumWidth = 200
        Me.TEN_NGUYEN_NHAN.Name = "TEN_NGUYEN_NHAN"
        Me.TEN_NGUYEN_NHAN.ReadOnly = True
        '
        'HU_HONG
        '
        Me.HU_HONG.HeaderText = "Hư hỏng"
        Me.HU_HONG.MinimumWidth = 50
        Me.HU_HONG.Name = "HU_HONG"
        Me.HU_HONG.ReadOnly = True
        Me.HU_HONG.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HU_HONG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.HU_HONG.Width = 50
        '
        'BTDK
        '
        Me.BTDK.HeaderText = "BTDK"
        Me.BTDK.MinimumWidth = 60
        Me.BTDK.Name = "BTDK"
        Me.BTDK.ReadOnly = True
        Me.BTDK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BTDK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.BTDK.Width = 60
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_NGUYEN_NHAN"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = "HU_HONG"
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        Me.DataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "TEN_NGUYEN_NHAN"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.HeaderText = "BTDK"
        Me.DataGridViewCheckBoxColumn3.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ReadOnly = True
        Me.DataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn3.Width = 60
        '
        'frmrptBieuDoTGNMTheoNNHours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBieuDoTGNMTheoNNHours"
        Me.Size = New System.Drawing.Size(976, 619)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNguyenNhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents cboNhaXuong As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grdNguyenNhan As System.Windows.Forms.DataGridView
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaTuThang As System.Windows.Forms.Label
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_NGUYEN_NHAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEN_NGUYEN_NHAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HU_HONG As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BTDK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmbCity As Commons.UtcComboBox
    Friend WithEvents cmbDistrict As Commons.UtcComboBox
    Friend WithEvents cmbStreet As Commons.UtcComboBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
