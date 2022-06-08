<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBIEU_DO_THOI_GIAN_NGUNG_MAY
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
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbxNhaXuong = New Commons.UtcComboBox()
        Me.lbaNhaXuong = New System.Windows.Forms.Label()
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.lbaTuNgay = New System.Windows.Forms.Label()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbCity = New Commons.UtcComboBox()
        Me.cmbDistrict = New Commons.UtcComboBox()
        Me.cmbStreet = New Commons.UtcComboBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.lblDistrict = New System.Windows.Forms.Label()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
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
        Me.cbxNhaXuong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxNhaXuong.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
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
        Me.cbxNhaXuong.Location = New System.Drawing.Point(516, 61)
        Me.cbxNhaXuong.MethodName = ""
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.Param = ""
        Me.cbxNhaXuong.Param2 = ""
        Me.cbxNhaXuong.Size = New System.Drawing.Size(287, 21)
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
        Me.lbaNhaXuong.Location = New System.Drawing.Point(406, 58)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(104, 25)
        Me.lbaNhaXuong.TabIndex = 12
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtDenNgay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.mtxtDenNgay, 2)
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(516, 11)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(287, 21)
        Me.mtxtDenNgay.TabIndex = 11
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(223, 11)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(177, 21)
        Me.mtxtTuNgay.TabIndex = 10
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(406, 8)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(104, 25)
        Me.lbaDenNgay.TabIndex = 9
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(113, 8)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(104, 25)
        Me.lbaTuNgay.TabIndex = 8
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(699, 569)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 14
        Me.btnThucHien.Text = "Thực hiện"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbCity, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDistrict, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbStreet, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCity, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStreet, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDistrict, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 5, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(916, 606)
        Me.TableLayoutPanel1.TabIndex = 15
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
        Me.cmbCity.Location = New System.Drawing.Point(223, 36)
        Me.cmbCity.MethodName = ""
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Param = ""
        Me.cmbCity.Param2 = ""
        Me.cmbCity.Size = New System.Drawing.Size(177, 21)
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
        Me.cmbDistrict.Location = New System.Drawing.Point(516, 36)
        Me.cmbDistrict.MethodName = ""
        Me.cmbDistrict.Name = "cmbDistrict"
        Me.cmbDistrict.Param = ""
        Me.cmbDistrict.Param2 = ""
        Me.cmbDistrict.Size = New System.Drawing.Size(287, 21)
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
        Me.cmbStreet.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmbStreet.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
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
        Me.cmbStreet.Location = New System.Drawing.Point(223, 61)
        Me.cmbStreet.MethodName = ""
        Me.cmbStreet.Name = "cmbStreet"
        Me.cmbStreet.Param = ""
        Me.cmbStreet.Param2 = ""
        Me.cmbStreet.Size = New System.Drawing.Size(177, 21)
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
        Me.lblCity.Location = New System.Drawing.Point(113, 33)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(104, 25)
        Me.lblCity.TabIndex = 18
        Me.lblCity.Text = "Tỉnh"
        Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStreet.Location = New System.Drawing.Point(113, 58)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(104, 25)
        Me.lblStreet.TabIndex = 19
        Me.lblStreet.Text = "Đường"
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDistrict
        '
        Me.lblDistrict.AutoSize = True
        Me.lblDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDistrict.Location = New System.Drawing.Point(406, 33)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(104, 25)
        Me.lblDistrict.TabIndex = 20
        Me.lblDistrict.Text = "Huyện"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = Global.Commons.My.Resources.Resources.Thoat
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(809, 569)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 21
        Me.btnThoat.Text = "Thoát"
        '
        'frmrptBIEU_DO_THOI_GIAN_NGUNG_MAY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBIEU_DO_THOI_GIAN_NGUNG_MAY"
        Me.Size = New System.Drawing.Size(916, 606)
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
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbCity As Commons.UtcComboBox
    Friend WithEvents cmbDistrict As Commons.UtcComboBox
    Friend WithEvents cmbStreet As Commons.UtcComboBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
