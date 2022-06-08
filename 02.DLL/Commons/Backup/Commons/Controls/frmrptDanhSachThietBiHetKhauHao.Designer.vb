<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhSachThietBiHetKhauHao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDanhSachThietBiHetKhauHao))
        Me.lblLoaiTB = New System.Windows.Forms.Label
        Me.lblNhaxuong = New System.Windows.Forms.Label
        Me.cboNhaxuong = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.cboLoaiThietBi = New System.Windows.Forms.ComboBox
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLoaiTB
        '
        Me.lblLoaiTB.AutoSize = True
        Me.lblLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiTB.Location = New System.Drawing.Point(73, 0)
        Me.lblLoaiTB.Name = "lblLoaiTB"
        Me.lblLoaiTB.Size = New System.Drawing.Size(50, 25)
        Me.lblLoaiTB.TabIndex = 1
        Me.lblLoaiTB.Text = "Loại thiết bị"
        Me.lblLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.AutoSize = True
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(236, 0)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(50, 25)
        Me.lblNhaxuong.TabIndex = 2
        Me.lblNhaxuong.Text = "Nơi sử dụng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.Location = New System.Drawing.Point(292, 3)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Size = New System.Drawing.Size(101, 21)
        Me.cboNhaxuong.TabIndex = 6
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
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiThietBi, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiTB, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(467, 370)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(374, 3)
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
        Me.cboLoaiThietBi.Location = New System.Drawing.Point(129, 3)
        Me.cboLoaiThietBi.Name = "cboLoaiThietBi"
        Me.cboLoaiThietBi.Size = New System.Drawing.Size(101, 21)
        Me.cboLoaiThietBi.TabIndex = 5
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(284, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 19
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 331)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(461, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'frmrptDanhSachThietBiHetKhauHao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDanhSachThietBiHetKhauHao"
        Me.Size = New System.Drawing.Size(467, 370)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLoaiTB As System.Windows.Forms.Label
    Friend WithEvents lblNhaxuong As System.Windows.Forms.Label
    Friend WithEvents cboNhaxuong As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboLoaiThietBi As System.Windows.Forms.ComboBox
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
