<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptPhanTichChiPhi
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbaTuNgay = New System.Windows.Forms.Label()
        Me.btnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.lbaDenNgay = New System.Windows.Forms.Label()
        Me.gvData = New H.UserControl.HGridViewMulti()
        Me.clImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.clNhaxuong = New H.UserControl.TreeGridColumn()
        Me.clPhuTung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clVatTu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clNhanCong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clDichVu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clHangNgay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clKhac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clTong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtxtTuNgay = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtDenNgay = New System.Windows.Forms.MaskedTextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.lbaTuNgay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLoad, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaDenNgay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gvData, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTuNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtDenNgay, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(817, 555)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lbaTuNgay
        '
        Me.lbaTuNgay.AutoSize = True
        Me.lbaTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaTuNgay.Location = New System.Drawing.Point(125, 0)
        Me.lbaTuNgay.Name = "lbaTuNgay"
        Me.lbaTuNgay.Size = New System.Drawing.Size(92, 26)
        Me.lbaTuNgay.TabIndex = 2
        Me.lbaTuNgay.Text = "Từ ngày"
        Me.lbaTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoad
        '
        Me.btnLoad.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLoad.Location = New System.Drawing.Point(695, 3)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(90, 20)
        Me.btnLoad.TabIndex = 16
        Me.btnLoad.Text = "btnLoad"
        '
        'lbaDenNgay
        '
        Me.lbaDenNgay.AutoSize = True
        Me.lbaDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaDenNgay.Location = New System.Drawing.Point(410, 0)
        Me.lbaDenNgay.Name = "lbaDenNgay"
        Me.lbaDenNgay.Size = New System.Drawing.Size(92, 26)
        Me.lbaDenNgay.TabIndex = 3
        Me.lbaDenNgay.Text = "Đến ngày"
        Me.lbaDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvData
        '
        Me.gvData.AllowUserToAddRows = False
        Me.gvData.AllowUserToDeleteRows = False
        Me.gvData.AllowUserToOrderColumns = True
        Me.gvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.gvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clImage, Me.clNhaxuong, Me.clPhuTung, Me.clVatTu, Me.clNhanCong, Me.clDichVu, Me.clHangNgay, Me.clKhac, Me.clTong})
        Me.TableLayoutPanel1.SetColumnSpan(Me.gvData, 6)
        Me.gvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gvData.ImageList = Nothing
        Me.gvData.Location = New System.Drawing.Point(3, 29)
        Me.gvData.Name = "gvData"
        Me.gvData.RowHeadersVisible = False
        Me.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvData.Size = New System.Drawing.Size(811, 489)
        Me.gvData.TabIndex = 5
        '
        'clImage
        '
        Me.clImage.HeaderText = ""
        Me.clImage.Name = "clImage"
        Me.clImage.Width = 20
        '
        'clNhaxuong
        '
        Me.clNhaxuong.DefaultNodeImage = Nothing
        Me.clNhaxuong.HeaderText = "Nhà xưởng"
        Me.clNhaxuong.MinimumWidth = 200
        Me.clNhaxuong.Name = "clNhaxuong"
        Me.clNhaxuong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clNhaxuong.Width = 200
        '
        'clPhuTung
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.clPhuTung.DefaultCellStyle = DataGridViewCellStyle2
        Me.clPhuTung.HeaderText = "CP phụ tùng"
        Me.clPhuTung.Name = "clPhuTung"
        Me.clPhuTung.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clVatTu
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.clVatTu.DefaultCellStyle = DataGridViewCellStyle3
        Me.clVatTu.HeaderText = "CP vật tư"
        Me.clVatTu.Name = "clVatTu"
        Me.clVatTu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clNhanCong
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.clNhanCong.DefaultCellStyle = DataGridViewCellStyle4
        Me.clNhanCong.HeaderText = "CP nhân công"
        Me.clNhanCong.Name = "clNhanCong"
        Me.clNhanCong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clDichVu
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clDichVu.DefaultCellStyle = DataGridViewCellStyle5
        Me.clDichVu.HeaderText = "CP dịch vụ"
        Me.clDichVu.Name = "clDichVu"
        Me.clDichVu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clHangNgay
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.clHangNgay.DefaultCellStyle = DataGridViewCellStyle6
        Me.clHangNgay.HeaderText = "CP Khác"
        Me.clHangNgay.Name = "clHangNgay"
        Me.clHangNgay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clKhac
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.clKhac.DefaultCellStyle = DataGridViewCellStyle7
        Me.clKhac.HeaderText = "CP Hàng Ngày"
        Me.clKhac.Name = "clKhac"
        Me.clKhac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clTong
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.clTong.DefaultCellStyle = DataGridViewCellStyle8
        Me.clTong.HeaderText = "CP tổng"
        Me.clTong.Name = "clTong"
        Me.clTong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clTong.Width = 150
        '
        'mtxtTuNgay
        '
        Me.mtxtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTuNgay.Location = New System.Drawing.Point(223, 3)
        Me.mtxtTuNgay.Mask = "00/00/0000"
        Me.mtxtTuNgay.Name = "mtxtTuNgay"
        Me.mtxtTuNgay.Size = New System.Drawing.Size(181, 21)
        Me.mtxtTuNgay.TabIndex = 6
        Me.mtxtTuNgay.ValidatingType = GetType(Date)
        '
        'mtxtDenNgay
        '
        Me.mtxtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtDenNgay.Location = New System.Drawing.Point(508, 3)
        Me.mtxtDenNgay.Mask = "00/00/0000"
        Me.mtxtDenNgay.Name = "mtxtDenNgay"
        Me.mtxtDenNgay.Size = New System.Drawing.Size(181, 21)
        Me.mtxtDenNgay.TabIndex = 7
        Me.mtxtDenNgay.ValidatingType = GetType(Date)
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 524)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(811, 28)
        Me.TableLayoutPanel2.TabIndex = 17
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(721, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(87, 22)
        Me.btnThoat.TabIndex = 35
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(608, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(90, 22)
        Me.btnThucHien.TabIndex = 16
        Me.btnThucHien.Text = "Thực hiện"
        '
        'imgList
        '
        Me.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgList.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmrptPhanTichChiPhi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptPhanTichChiPhi"
        Me.Size = New System.Drawing.Size(817, 555)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaTuNgay As System.Windows.Forms.Label
    Friend WithEvents lbaDenNgay As System.Windows.Forms.Label
    Friend WithEvents gvData As H.UserControl.HGridViewMulti
    Friend WithEvents mtxtTuNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtDenNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents clImage As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents clNhaxuong As H.UserControl.TreeGridColumn
    Friend WithEvents clPhuTung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clVatTu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNhanCong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clDichVu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clHangNgay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clKhac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clTong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnLoad As DevExpress.XtraEditors.SimpleButton

End Class
