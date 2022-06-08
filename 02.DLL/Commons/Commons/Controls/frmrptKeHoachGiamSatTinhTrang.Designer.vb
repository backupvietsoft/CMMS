<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptKeHoachGiamSatTinhTrang
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptKeHoachGiamSatTinhTrang))
        Me.lbaTuNgay = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox
        Me.lbaDenNgay = New System.Windows.Forms.Label
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox
        Me.mtxtNgayLap = New System.Windows.Forms.MaskedTextBox
        Me.lbaNgayLap = New System.Windows.Forms.Label
        Me.cbxNguoiLap = New System.Windows.Forms.ComboBox
        Me.lbaNguoiLap = New System.Windows.Forms.Label
        Me.mtxtNgayDuyet = New System.Windows.Forms.MaskedTextBox
        Me.lbaNgayDuyet = New System.Windows.Forms.Label
        Me.cbxNguoiDuyet = New System.Windows.Forms.ComboBox
        Me.lbaNguoiDuyet = New System.Windows.Forms.Label
        Me.cbxNhaXuong = New Commons.UtcComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbaNhaXuong = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Location = New System.Drawing.Point(88, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(62, 25)
        Me.lbaTuNgay.TabIndex = 0
        Me.lbaTuNgay.Text = "Từ ngày:"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtNgayLap, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNgayLap, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNguoiLap, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNguoiLap, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtNgayDuyet, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNgayDuyet, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNguoiDuyet, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNguoiDuyet, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNhaXuong, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNhaXuong, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(567, 472)
        Me.TableLayoutPanel1.TabIndex = 1
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 433)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(561, 36)
        Me.TableLayoutPanel2.TabIndex = 32
        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(474, 3)
        Me.btnThoat.Name = "btnThoat"

        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 33
        Me.btnThoat.Text = "Thoát"


        '
        'btnThucHien
        '


        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(384, 3)
        Me.btnThucHien.Name = "btnThucHien"

        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 25
        Me.btnThucHien.Text = "Thực hiện"


        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(354, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(124, 20)
        Me.mtxtDenNgay.TabIndex = 3
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Location = New System.Drawing.Point(286, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(62, 25)
        Me.lbaDenNgay.TabIndex = 1
        Me.lbaDenNgay.Text = "Đến ngày:"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(156, 3)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(124, 20)
        Me.mtxtTuNgay.TabIndex = 2
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtNgayLap
        '
        Me.mtxtNgayLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtNgayLap.Location = New System.Drawing.Point(354, 28)
        Me.mtxtNgayLap.Mask = "00/00/0000"
        Me.mtxtNgayLap.Name = "mtxtNgayLap"
        Me.mtxtNgayLap.Size = New System.Drawing.Size(124, 20)
        Me.mtxtNgayLap.TabIndex = 10
        Me.mtxtNgayLap.ValidatingType = GetType(Date)
        '
        'lbaNgayLap
        '
        Me.lbaNgayLap.AutoSize = True
        Me.lbaNgayLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNgayLap.Location = New System.Drawing.Point(286, 25)
        Me.lbaNgayLap.Name = "lbaNgayLap"
        Me.lbaNgayLap.Size = New System.Drawing.Size(62, 25)
        Me.lbaNgayLap.TabIndex = 7
        Me.lbaNgayLap.Text = "Ngày lập:"
        Me.lbaNgayLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxNguoiLap
        '
        Me.cbxNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNguoiLap.FormattingEnabled = True
        Me.cbxNguoiLap.Location = New System.Drawing.Point(156, 28)
        Me.cbxNguoiLap.Name = "cbxNguoiLap"
        Me.cbxNguoiLap.Size = New System.Drawing.Size(124, 21)
        Me.cbxNguoiLap.TabIndex = 12
        '
        'lbaNguoiLap
        '
        Me.lbaNguoiLap.AutoSize = True
        Me.lbaNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNguoiLap.Location = New System.Drawing.Point(88, 25)
        Me.lbaNguoiLap.Name = "lbaNguoiLap"
        Me.lbaNguoiLap.Size = New System.Drawing.Size(62, 25)
        Me.lbaNguoiLap.TabIndex = 6
        Me.lbaNguoiLap.Text = "Người lập:"
        Me.lbaNguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtNgayDuyet
        '
        Me.mtxtNgayDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtNgayDuyet.Location = New System.Drawing.Point(354, 53)
        Me.mtxtNgayDuyet.Mask = "00/00/0000"
        Me.mtxtNgayDuyet.Name = "mtxtNgayDuyet"
        Me.mtxtNgayDuyet.Size = New System.Drawing.Size(124, 20)
        Me.mtxtNgayDuyet.TabIndex = 11
        Me.mtxtNgayDuyet.ValidatingType = GetType(Date)
        '
        'lbaNgayDuyet
        '
        Me.lbaNgayDuyet.AutoSize = True
        Me.lbaNgayDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNgayDuyet.Location = New System.Drawing.Point(286, 50)
        Me.lbaNgayDuyet.Name = "lbaNgayDuyet"
        Me.lbaNgayDuyet.Size = New System.Drawing.Size(62, 25)
        Me.lbaNgayDuyet.TabIndex = 9
        Me.lbaNgayDuyet.Text = "Ngày duyệt"
        Me.lbaNgayDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxNguoiDuyet
        '
        Me.cbxNguoiDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNguoiDuyet.FormattingEnabled = True
        Me.cbxNguoiDuyet.Location = New System.Drawing.Point(156, 53)
        Me.cbxNguoiDuyet.Name = "cbxNguoiDuyet"
        Me.cbxNguoiDuyet.Size = New System.Drawing.Size(124, 21)
        Me.cbxNguoiDuyet.TabIndex = 13
        '
        'lbaNguoiDuyet
        '
        Me.lbaNguoiDuyet.AutoSize = True
        Me.lbaNguoiDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaNguoiDuyet.Location = New System.Drawing.Point(88, 50)
        Me.lbaNguoiDuyet.Name = "lbaNguoiDuyet"
        Me.lbaNguoiDuyet.Size = New System.Drawing.Size(62, 25)
        Me.lbaNguoiDuyet.TabIndex = 8
        Me.lbaNguoiDuyet.Text = "Người Duyệt"
        Me.lbaNguoiDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxNhaXuong
        '
        Me.cbxNhaXuong.AssemblyName = ""
        Me.cbxNhaXuong.BackColor = System.Drawing.Color.White
        Me.cbxNhaXuong.ClassName = ""
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxNhaXuong, 3)
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
        Me.cbxNhaXuong.Location = New System.Drawing.Point(156, 78)
        Me.cbxNhaXuong.MethodName = ""
        Me.cbxNhaXuong.Name = "cbxNhaXuong"
        Me.cbxNhaXuong.Param = ""
        Me.cbxNhaXuong.Param2 = ""
        Me.cbxNhaXuong.Size = New System.Drawing.Size(322, 21)
        Me.cbxNhaXuong.StoreName = ""
        Me.cbxNhaXuong.TabIndex = 16
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
        Me.lbaNhaXuong.Location = New System.Drawing.Point(88, 75)
        Me.lbaNhaXuong.Name = "lbaNhaXuong"
        Me.lbaNhaXuong.Size = New System.Drawing.Size(62, 25)
        Me.lbaNhaXuong.TabIndex = 15
        Me.lbaNhaXuong.Text = "Địa điểm"
        Me.lbaNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmrptKeHoachGiamSatTinhTrang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptKeHoachGiamSatTinhTrang"
        Me.Size = New System.Drawing.Size(567, 472)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbxNhaXuong As Commons.UtcComboBox
    Friend WithEvents lbaNhaXuong As System.Windows.Forms.Label

End Class
