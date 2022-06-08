<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhSachHetHanBaoHanh
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDanhSachHetHanBaoHanh))
        Me.lblLoaiTB = New System.Windows.Forms.Label
        Me.lblTungay = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.cboLoaiThietBi = New System.Windows.Forms.ComboBox
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.txtTungay = New System.Windows.Forms.DateTimePicker
        Me.txtDenngay = New System.Windows.Forms.DateTimePicker
        Me.cboNhaxuong = New System.Windows.Forms.ComboBox
        Me.lblNoisudung = New System.Windows.Forms.Label
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLoaiTB
        '
        Me.lblLoaiTB.AutoSize = True
        Me.lblLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiTB.Location = New System.Drawing.Point(205, 25)
        Me.lblLoaiTB.Name = "lblLoaiTB"
        Me.lblLoaiTB.Size = New System.Drawing.Size(42, 25)
        Me.lblLoaiTB.TabIndex = 1
        Me.lblLoaiTB.Text = "Loai thiet bi"
        Me.lblLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(64, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(42, 25)
        Me.lblTungay.TabIndex = 2
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTungay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDenngay, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNoisudung, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiTB, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiThietBi, 4, 1)
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(408, 348)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(315, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'cboLoaiThietBi
        '
        Me.cboLoaiThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiThietBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiThietBi.FormattingEnabled = True
        Me.cboLoaiThietBi.Location = New System.Drawing.Point(253, 28)
        Me.cboLoaiThietBi.Name = "cboLoaiThietBi"
        Me.cboLoaiThietBi.Size = New System.Drawing.Size(87, 21)
        Me.cboLoaiThietBi.TabIndex = 5
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(225, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 19
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(205, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(42, 25)
        Me.lblDenngay.TabIndex = 20
        Me.lblDenngay.Text = "Đến ngày"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTungay
        '
        Me.txtTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTungay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtTungay.Location = New System.Drawing.Point(112, 3)
        Me.txtTungay.Name = "txtTungay"
        Me.txtTungay.Size = New System.Drawing.Size(87, 20)
        Me.txtTungay.TabIndex = 21
        '
        'txtDenngay
        '
        Me.txtDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDenngay.Location = New System.Drawing.Point(253, 3)
        Me.txtDenngay.Name = "txtDenngay"
        Me.txtDenngay.Size = New System.Drawing.Size(87, 20)
        Me.txtDenngay.TabIndex = 21
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.Location = New System.Drawing.Point(112, 28)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Size = New System.Drawing.Size(87, 21)
        Me.cboNhaxuong.TabIndex = 22
        '
        'lblNoisudung
        '
        Me.lblNoisudung.AutoSize = True
        Me.lblNoisudung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoisudung.Location = New System.Drawing.Point(64, 25)
        Me.lblNoisudung.Name = "lblNoisudung"
        Me.lblNoisudung.Size = New System.Drawing.Size(42, 25)
        Me.lblNoisudung.TabIndex = 23
        Me.lblNoisudung.Text = "Nơi sử dụng"
        Me.lblNoisudung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 309)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(402, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'frmrptDanhSachHetHanBaoHanh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDanhSachHetHanBaoHanh"
        Me.Size = New System.Drawing.Size(408, 348)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLoaiTB As System.Windows.Forms.Label
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboLoaiThietBi As System.Windows.Forms.ComboBox
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents txtTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboNhaxuong As System.Windows.Forms.ComboBox
    Friend WithEvents lblNoisudung As System.Windows.Forms.Label
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
