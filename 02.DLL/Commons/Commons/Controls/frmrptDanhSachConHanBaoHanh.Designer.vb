<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhSachConHanBaoHanh
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
        Me.lbaNhaXuong = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.lbaLoaiTB = New System.Windows.Forms.Label()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbxNhaXuong = New MVControl.ucComboboxTreeList()
        Me.cboLoaiTB = New Commons.UtcComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbaNhaXuong
        '
        Me.lbaNhaXuong.AutoSize = True
        Me.lbaNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNhaXuong.Location = New System.Drawing.Point(89, 25)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(63, 25)
        Me.lbaNhaXuong.TabIndex = 15
        Me.lbaNhaXuong.Text = "Nhà xưởng"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(158, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(126, 21)
        Me.mtxtDenNgay.TabIndex = 11
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(89, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(63, 25)
        Me.lbaDenNgay.TabIndex = 10
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaLoaiTB
        '
        Me.lbaLoaiTB.AutoSize = True
        Me.lbaLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaLoaiTB.Location = New System.Drawing.Point(290, 25)
        Me.lbaLoaiTB.Name = "lbaLoaiTB"
        Me.lbaLoaiTB.Size = New System.Drawing.Size(63, 25)
        Me.lbaLoaiTB.TabIndex = 9
        Me.lbaLoaiTB.Text = "Loại Thiết bị"
        Me.lbaLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(353, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 16
        Me.btnThucHien.Text = "Thực hiện"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaLoaiTB, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiTB, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(576, 449)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'cbxNhaXuong
        '
        Me.cbxNhaXuong.ColumnDisplayName = Nothing
        Me.cbxNhaXuong.DataSource = Nothing
        Me.cbxNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNhaXuong.EditValue = Nothing
        Me.cbxNhaXuong.KeyFieldName = Nothing
        Me.cbxNhaXuong.Location = New System.Drawing.Point(158, 28)
        Me.cbxNhaXuong.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cbxNhaXuong.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.ParentFieldName = Nothing
        Me.cbxNhaXuong.SelectedIndex = 0
        Me.cbxNhaXuong.Size = New System.Drawing.Size(126, 20)
        Me.cbxNhaXuong.TabIndex = 14
        Me.cbxNhaXuong.TextValue = Nothing
        '
        'cboLoaiTB
        '
        Me.cboLoaiTB.AssemblyName = ""
        Me.cboLoaiTB.BackColor = System.Drawing.Color.White
        Me.cboLoaiTB.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboLoaiTB.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboLoaiTB.ClassName = ""
        Me.cboLoaiTB.Display = ""
        Me.cboLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiTB.ErrorProviderControl = Me.ErrorProvider1
        Me.cboLoaiTB.FormattingEnabled = True
        Me.cboLoaiTB.IsAll = True
        Me.cboLoaiTB.isInputNull = False
        Me.cboLoaiTB.IsNew = False
        Me.cboLoaiTB.IsNull = True
        Me.cboLoaiTB.ItemAll = " < ALL > "
        Me.cboLoaiTB.ItemNew = "...New"
        Me.cboLoaiTB.Location = New System.Drawing.Point(359, 28)
        Me.cboLoaiTB.MethodName = ""
        Me.cboLoaiTB.Name = "cboLoaiTB"
        Me.cboLoaiTB.Param = ""
        Me.cboLoaiTB.Param2 = ""
        Me.cboLoaiTB.Size = New System.Drawing.Size(126, 21)
        Me.cboLoaiTB.StoreName = ""
        Me.cboLoaiTB.TabIndex = 8
        Me.cboLoaiTB.Table = Nothing
        Me.cboLoaiTB.TextReadonly = False
        Me.cboLoaiTB.Value = ""
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 410)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(570, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(463, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        '
        'frmrptDanhSachConHanBaoHanh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDanhSachConHanBaoHanh"
        Me.Size = New System.Drawing.Size(576, 449)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents lbaLoaiTB As System.Windows.Forms.Label
    Friend WithEvents cboLoaiTB As Commons.UtcComboBox
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbxNhaXuong As MVControl.ucComboboxTreeList
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
