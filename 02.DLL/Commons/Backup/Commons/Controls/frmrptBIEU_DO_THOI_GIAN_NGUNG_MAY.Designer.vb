<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBIEU_DO_THOI_GIAN_NGUNG_MAY
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
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbxNhaXuong = New Commons.UtcComboBox
        Me.lbaNhaXuong = New System.Windows.Forms.Label
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.cmbCity = New Commons.UtcComboBox
        Me.cmbDistrict = New Commons.UtcComboBox
        Me.cmbStreet = New Commons.UtcComboBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.lblStreet = New System.Windows.Forms.Label
        Me.lblDistrict = New System.Windows.Forms.Label
        Me.btnThoat = New System.Windows.Forms.Button
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cbxNhaXuong
        '
        Me.cbxNhaXuong.AssemblyName = ""
        Me.cbxNhaXuong.BackColor = System.Drawing.Color.White
        Me.cbxNhaXuong.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxNhaXuong, 2)
        Me.cbxNhaXuong.Display = ""
        Me.cbxNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNhaXuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNhaXuong.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNhaXuong.FormattingEnabled = True
        Me.cbxNhaXuong.IsAll = True
        Me.cbxNhaXuong.isInputNull = False
        Me.cbxNhaXuong.IsNew = False
        Me.cbxNhaXuong.IsNull = True
        Me.cbxNhaXuong.ItemAll = " < ALL > "
        Me.cbxNhaXuong.ItemNew = "...New"
        Me.cbxNhaXuong.Location = New System.Drawing.Point(314, 60)
        Me.cbxNhaXuong.MethodName = ""
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.Param = ""
        Me.cbxNhaXuong.Param2 = ""
        Me.cbxNhaXuong.Size = New System.Drawing.Size(289, 21)
        Me.cbxNhaXuong.StoreName = ""
        Me.cbxNhaXuong.TabIndex = 13
        Me.cbxNhaXuong.Table = Nothing
        Me.cbxNhaXuong.TextReadonly = False
        Me.cbxNhaXuong.Value = ""
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Location = New System.Drawing.Point(249, 57)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(59, 28)
        Me.lbaNhaXuong.TabIndex = 12
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxtDenNgay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.mtxtDenNgay, 2)
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(314, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(289, 20)
        Me.mtxtDenNgay.TabIndex = 11
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(55, 3)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(188, 20)
        Me.mtxtTuNgay.TabIndex = 10
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(249, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(59, 29)
        Me.lbaDenNgay.TabIndex = 9
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(3, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(46, 29)
        Me.lbaTuNgay.TabIndex = 8
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(405, 457)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 14
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbCity, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDistrict, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbStreet, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCity, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStreet, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDistrict, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 4, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(606, 484)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'cmbCity
        '
        Me.cmbCity.AssemblyName = ""
        Me.cmbCity.BackColor = System.Drawing.Color.White
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
        Me.cmbCity.Location = New System.Drawing.Point(55, 32)
        Me.cmbCity.MethodName = ""
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Param = ""
        Me.cmbCity.Param2 = ""
        Me.cmbCity.Size = New System.Drawing.Size(188, 21)
        Me.cmbCity.StoreName = ""
        Me.cmbCity.TabIndex = 15
        Me.cmbCity.Table = Nothing
        Me.cmbCity.TextReadonly = False
        Me.cmbCity.Value = ""
        '
        'cmbDistrict
        '
        Me.cmbDistrict.AssemblyName = ""
        Me.cmbDistrict.BackColor = System.Drawing.Color.White
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
        Me.cmbDistrict.Location = New System.Drawing.Point(314, 32)
        Me.cmbDistrict.MethodName = ""
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Param = ""
        Me.cmbDistrict.Param2 = ""
        Me.cmbDistrict.Size = New System.Drawing.Size(289, 21)
        Me.cmbDistrict.StoreName = ""
        Me.cmbDistrict.TabIndex = 16
        Me.cmbDistrict.Table = Nothing
        Me.cmbDistrict.TextReadonly = False
        Me.cmbDistrict.Value = ""
        '
        'cmbStreet
        '
        Me.cmbStreet.AssemblyName = ""
        Me.cmbStreet.BackColor = System.Drawing.Color.White
        Me.cmbStreet.ClassName = ""
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
        Me.cmbStreet.Location = New System.Drawing.Point(55, 60)
        Me.cmbStreet.MethodName = ""
        Me.cmbStreet.Name = "cmbStreet"
        Me.cmbStreet.Param = ""
        Me.cmbStreet.Param2 = ""
        Me.cmbStreet.Size = New System.Drawing.Size(188, 21)
        Me.cmbStreet.StoreName = ""
        Me.cmbStreet.TabIndex = 17
        Me.cmbStreet.Table = Nothing
        Me.cmbStreet.TextReadonly = False
        Me.cmbStreet.Value = ""
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCity.Location = New System.Drawing.Point(3, 29)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(46, 28)
        Me.lblCity.TabIndex = 18
        Me.lblCity.Text = "Tỉnh"
        Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStreet.Location = New System.Drawing.Point(3, 57)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(46, 28)
        Me.lblStreet.TabIndex = 19
        Me.lblStreet.Text = "Đường"
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDistrict
        '
        Me.lblDistrict.AutoSize = True
        Me.lblDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDistrict.Location = New System.Drawing.Point(249, 29)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(59, 28)
        Me.lblDistrict.TabIndex = 20
        Me.lblDistrict.Text = "Huyện"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = Global.Commons.My.Resources.Resources.Thoat
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Location = New System.Drawing.Point(508, 457)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(88, 24)
        Me.btnThoat.TabIndex = 21
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptBIEU_DO_THOI_GIAN_NGUNG_MAY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptBIEU_DO_THOI_GIAN_NGUNG_MAY"
        Me.Size = New System.Drawing.Size(606, 484)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cbxNhaXuong As Commons.UtcComboBox
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbCity As Commons.UtcComboBox
    Friend WithEvents cmbDistrict As Commons.UtcComboBox
    Friend WithEvents cmbStreet As Commons.UtcComboBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
