<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhSachPhieuXuatKho
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDanhSachPhieuXuatKho))
        Me.labNhapKho = New System.Windows.Forms.Label()
        Me.labTuNgay = New System.Windows.Forms.Label()
        Me.gvPhieuXuatKho = New System.Windows.Forms.DataGridView()
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MS_DANG_XUAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DANG_XUAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HU_HONG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.labDenNgay = New System.Windows.Forms.Label()
        Me.cmbKho = New System.Windows.Forms.ComboBox()
        Me.daTimeTuNgay = New System.Windows.Forms.DateTimePicker()
        Me.daTimeDenNgay = New System.Windows.Forms.DateTimePicker()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvPhieuXuatKho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'labNhapKho
        '
        Me.labNhapKho.AutoSize = True
        Me.labNhapKho.Dock = System.Windows.Forms.DockStyle.Left
        Me.labNhapKho.Location = New System.Drawing.Point(73, 31)
        Me.labNhapKho.Name = "labNhapKho"
        Me.labNhapKho.Size = New System.Drawing.Size(26, 31)
        Me.labNhapKho.TabIndex = 0
        Me.labNhapKho.Text = "Kho"
        Me.labNhapKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labTuNgay
        '
        Me.labTuNgay.AutoSize = True
        Me.labTuNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.labTuNgay.Location = New System.Drawing.Point(73, 0)
        Me.labTuNgay.Name = "labTuNgay"
        Me.labTuNgay.Size = New System.Drawing.Size(46, 31)
        Me.labTuNgay.TabIndex = 1
        Me.labTuNgay.Text = "Từ ngày"
        Me.labTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gvPhieuXuatKho
        '
        Me.gvPhieuXuatKho.AllowUserToAddRows = False
        Me.gvPhieuXuatKho.AllowUserToDeleteRows = False
        Me.gvPhieuXuatKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvPhieuXuatKho.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvPhieuXuatKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvPhieuXuatKho.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON, Me.MS_DANG_XUAT, Me.DANG_XUAT, Me.HU_HONG})
        Me.TableLayoutPanel4.SetColumnSpan(Me.gvPhieuXuatKho, 6)
        Me.gvPhieuXuatKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvPhieuXuatKho.Location = New System.Drawing.Point(3, 65)
        Me.gvPhieuXuatKho.Name = "gvPhieuXuatKho"
        Me.gvPhieuXuatKho.Size = New System.Drawing.Size(464, 270)
        Me.gvPhieuXuatKho.TabIndex = 3
        '
        'CHON
        '
        Me.CHON.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CHON.FillWeight = 1.0!
        Me.CHON.HeaderText = "Chọn"
        Me.CHON.Name = "CHON"
        Me.CHON.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHON.Width = 110
        '
        'MS_DANG_XUAT
        '
        Me.MS_DANG_XUAT.HeaderText = "MS dang xuat"
        Me.MS_DANG_XUAT.Name = "MS_DANG_XUAT"
        Me.MS_DANG_XUAT.Visible = False
        '
        'DANG_XUAT
        '
        Me.DANG_XUAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DANG_XUAT.FillWeight = 1.0!
        Me.DANG_XUAT.HeaderText = "Dạng xuất"
        Me.DANG_XUAT.Name = "DANG_XUAT"
        '
        'HU_HONG
        '
        Me.HU_HONG.HeaderText = "HU HONG"
        Me.HU_HONG.Name = "HU_HONG"
        Me.HU_HONG.Visible = False
        '
        'labDenNgay
        '
        Me.labDenNgay.AutoSize = True
        Me.labDenNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.labDenNgay.Location = New System.Drawing.Point(237, 0)
        Me.labDenNgay.Name = "labDenNgay"
        Me.labDenNgay.Size = New System.Drawing.Size(30, 31)
        Me.labDenNgay.TabIndex = 2
        Me.labDenNgay.Text = "Đến ngày"
        Me.labDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbKho
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.cmbKho, 3)
        Me.cmbKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbKho.FormattingEnabled = True
        Me.cmbKho.Location = New System.Drawing.Point(129, 34)
        Me.cmbKho.Name = "cmbKho"
        Me.cmbKho.Size = New System.Drawing.Size(266, 21)
        Me.cmbKho.TabIndex = 3
        '
        'daTimeTuNgay
        '
        Me.daTimeTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.daTimeTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.daTimeTuNgay.Location = New System.Drawing.Point(129, 3)
        Me.daTimeTuNgay.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.daTimeTuNgay.Name = "daTimeTuNgay"
        Me.daTimeTuNgay.ShowUpDown = True
        Me.daTimeTuNgay.Size = New System.Drawing.Size(102, 20)
        Me.daTimeTuNgay.TabIndex = 4
        '
        'daTimeDenNgay
        '
        Me.daTimeDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.daTimeDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.daTimeDenNgay.Location = New System.Drawing.Point(293, 3)
        Me.daTimeDenNgay.Name = "daTimeDenNgay"
        Me.daTimeDenNgay.Size = New System.Drawing.Size(102, 20)
        Me.daTimeDenNgay.TabIndex = 5
        '
        'btnThoat
        '


        Me.btnThoat.Location = New System.Drawing.Point(374, 0)

        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False

        Me.btnThoat.Size = New System.Drawing.Size(90, 31)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"


        '
        'btnThucHien
        '


        Me.btnThucHien.Location = New System.Drawing.Point(284, 0)

        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False

        Me.btnThucHien.Size = New System.Drawing.Size(90, 31)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"


        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.gvPhieuXuatKho, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbKho, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.labDenNgay, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.daTimeDenNgay, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.labTuNgay, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.labNhapKho, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.daTimeTuNgay, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel5, 0, 3)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(470, 375)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel4.SetColumnSpan(Me.TableLayoutPanel5, 6)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 341)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(464, 31)
        Me.TableLayoutPanel5.TabIndex = 6
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS dang xuat"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.FillWeight = 1.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Dạng xuất"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'frmrptDanhSachPhieuXuatKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Name = "frmrptDanhSachPhieuXuatKho"
        Me.Size = New System.Drawing.Size(470, 375)
        CType(Me.gvPhieuXuatKho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labNhapKho As System.Windows.Forms.Label
    Friend WithEvents labTuNgay As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvPhieuXuatKho As System.Windows.Forms.DataGridView
    Friend WithEvents labDenNgay As System.Windows.Forms.Label
    Friend WithEvents cmbKho As System.Windows.Forms.ComboBox
    Friend WithEvents daTimeTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents daTimeDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CHON As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MS_DANG_XUAT As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DANG_XUAT As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HU_HONG As Windows.Forms.DataGridViewCheckBoxColumn
End Class
