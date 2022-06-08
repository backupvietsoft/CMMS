<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptPHIEU_CONG_VIEC
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
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaNhanVien = New System.Windows.Forms.Label()
        Me.lbaPhongban = New System.Windows.Forms.Label()
        Me.lbaDonVi = New System.Windows.Forms.Label()
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.lbaTuNgay = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbxNhanVien = New Commons.UtcComboBox()
        Me.cbxPhongban = New Commons.UtcComboBox()
        Me.cbxDonVi = New Commons.UtcComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTimNV = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(238, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(90, 23)
        Me.btnThucHien.TabIndex = 7
        Me.btnThucHien.Text = "btnThucHien"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lbaNhanVien
        '
        Me.lbaNhanVien.AutoSize = True
        Me.lbaNhanVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhanVien.Location = New System.Drawing.Point(3, 75)
        Me.lbaNhanVien.Name = "lbaNhanVien"
        Me.lbaNhanVien.Size = New System.Drawing.Size(73, 24)
        Me.lbaNhanVien.TabIndex = 26
        Me.lbaNhanVien.Text = "Nhân viên"
        Me.lbaNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaPhongban
        '
        Me.lbaPhongban.AutoSize = True
        Me.lbaPhongban.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaPhongban.Location = New System.Drawing.Point(3, 49)
        Me.lbaPhongban.Name = "lbaPhongban"
        Me.lbaPhongban.Size = New System.Drawing.Size(73, 26)
        Me.lbaPhongban.TabIndex = 25
        Me.lbaPhongban.Text = "Tổ phòng ban"
        Me.lbaPhongban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaDonVi
        '
        Me.lbaDonVi.AutoSize = True
        Me.lbaDonVi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDonVi.Location = New System.Drawing.Point(3, 25)
        Me.lbaDonVi.Name = "lbaDonVi"
        Me.lbaDonVi.Size = New System.Drawing.Size(73, 24)
        Me.lbaDonVi.TabIndex = 24
        Me.lbaDonVi.Text = "Đơn vị"
        Me.lbaDonVi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtDenNgay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.mtxtDenNgay, 2)
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(283, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(161, 21)
        Me.mtxtDenNgay.TabIndex = 2
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(82, 3)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(135, 21)
        Me.mtxtTuNgay.TabIndex = 1
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(223, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(54, 25)
        Me.lbaDenNgay.TabIndex = 21
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(3, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(73, 25)
        Me.lbaTuNgay.TabIndex = 20
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhanVien, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxPhongban, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxDonVi, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhanVien, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDonVi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaPhongban, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnTimNV, 4, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(447, 361)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cbxNhanVien
        '
        Me.cbxNhanVien.AssemblyName = ""
        Me.cbxNhanVien.BackColor = System.Drawing.Color.White
        Me.cbxNhanVien.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxNhanVien.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxNhanVien.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxNhanVien, 3)
        Me.cbxNhanVien.Display = ""
        Me.cbxNhanVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNhanVien.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxNhanVien.FormattingEnabled = True
        Me.cbxNhanVien.IsAll = False
        Me.cbxNhanVien.isInputNull = False
        Me.cbxNhanVien.IsNew = False
        Me.cbxNhanVien.IsNull = True
        Me.cbxNhanVien.ItemAll = " < ALL > "
        Me.cbxNhanVien.ItemNew = "...New"
        Me.cbxNhanVien.Location = New System.Drawing.Point(82, 78)
        Me.cbxNhanVien.MethodName = ""
        Me.cbxNhanVien.Name = "cbxNhanVien"
        Me.cbxNhanVien.Param = ""
        Me.cbxNhanVien.Param2 = ""
        Me.cbxNhanVien.Size = New System.Drawing.Size(336, 21)
        Me.cbxNhanVien.StoreName = ""
        Me.cbxNhanVien.TabIndex = 5
        Me.cbxNhanVien.Table = Nothing
        Me.cbxNhanVien.TextReadonly = False
        Me.cbxNhanVien.Value = ""
        '
        'cbxPhongban
        '
        Me.cbxPhongban.AssemblyName = ""
        Me.cbxPhongban.BackColor = System.Drawing.Color.White
        Me.cbxPhongban.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxPhongban.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxPhongban.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxPhongban, 4)
        Me.cbxPhongban.Display = ""
        Me.cbxPhongban.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxPhongban.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxPhongban.FormattingEnabled = True
        Me.cbxPhongban.IsAll = True
        Me.cbxPhongban.isInputNull = False
        Me.cbxPhongban.IsNew = False
        Me.cbxPhongban.IsNull = True
        Me.cbxPhongban.ItemAll = " < ALL > "
        Me.cbxPhongban.ItemNew = "...New"
        Me.cbxPhongban.Location = New System.Drawing.Point(82, 52)
        Me.cbxPhongban.MethodName = ""
        Me.cbxPhongban.Name = "cbxPhongban"
        Me.cbxPhongban.Param = ""
        Me.cbxPhongban.Param2 = ""
        Me.cbxPhongban.Size = New System.Drawing.Size(362, 21)
        Me.cbxPhongban.StoreName = ""
        Me.cbxPhongban.TabIndex = 4
        Me.cbxPhongban.Table = Nothing
        Me.cbxPhongban.TextReadonly = False
        Me.cbxPhongban.Value = ""
        '
        'cbxDonVi
        '
        Me.cbxDonVi.AssemblyName = ""
        Me.cbxDonVi.BackColor = System.Drawing.Color.White
        Me.cbxDonVi.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cbxDonVi.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cbxDonVi.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxDonVi, 4)
        Me.cbxDonVi.Display = ""
        Me.cbxDonVi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxDonVi.ErrorProviderControl = Me.ErrorProvider1
        Me.cbxDonVi.FormattingEnabled = True
        Me.cbxDonVi.IsAll = True
        Me.cbxDonVi.isInputNull = False
        Me.cbxDonVi.IsNew = False
        Me.cbxDonVi.IsNull = True
        Me.cbxDonVi.ItemAll = " < ALL > "
        Me.cbxDonVi.ItemNew = "...New"
        Me.cbxDonVi.Location = New System.Drawing.Point(82, 28)
        Me.cbxDonVi.MethodName = ""
        Me.cbxDonVi.Name = "cbxDonVi"
        Me.cbxDonVi.Param = ""
        Me.cbxDonVi.Param2 = ""
        Me.cbxDonVi.Size = New System.Drawing.Size(362, 21)
        Me.cbxDonVi.StoreName = ""
        Me.cbxDonVi.TabIndex = 3
        Me.cbxDonVi.Table = Nothing
        Me.cbxDonVi.TextReadonly = False
        Me.cbxDonVi.Value = ""
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 5)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 329)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(441, 29)
        Me.TableLayoutPanel2.TabIndex = 30
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(351, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(87, 23)
        Me.btnThoat.TabIndex = 8
        Me.btnThoat.Text = "btnThoat"
        '
        'btnTimNV
        '
        Me.btnTimNV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTimNV.Location = New System.Drawing.Point(424, 78)
        Me.btnTimNV.Name = "btnTimNV"
        Me.btnTimNV.Size = New System.Drawing.Size(20, 18)
        Me.btnTimNV.TabIndex = 6
        Me.btnTimNV.Text = "..."
        '
        'frmrptPHIEU_CONG_VIEC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptPHIEU_CONG_VIEC"
        Me.Size = New System.Drawing.Size(447, 361)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbxNhanVien As Commons.UtcComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cbxPhongban As Commons.UtcComboBox
    Friend WithEvents cbxDonVi As Commons.UtcComboBox
    Friend WithEvents lbaNhanVien As System.Windows.Forms.Label
    Friend WithEvents lbaPhongban As System.Windows.Forms.Label
    Friend WithEvents lbaDonVi As System.Windows.Forms.Label
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTimNV As DevExpress.XtraEditors.SimpleButton

End Class
