<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDSCPBTTLoaiMay_LoaiTB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDSCPBTTLoaiMay_LoaiTB))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.grLoaiMay = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.rdLMChuaNghiemThu = New System.Windows.Forms.RadioButton
        Me.rdLMDaNghiemThu = New System.Windows.Forms.RadioButton
        Me.cboLoaiTB1 = New System.Windows.Forms.ComboBox
        Me.cboDiaDiem1 = New System.Windows.Forms.ComboBox
        Me.lblDiadiem = New System.Windows.Forms.Label
        Me.lblLoaiTB = New System.Windows.Forms.Label
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.lblTungay = New System.Windows.Forms.Label
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grLoaiMay.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.grLoaiMay, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTuNgay, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenNgay, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDiadiem, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDiaDiem1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiTB, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiTB1, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(406, 345)
        Me.TableLayoutPanel1.TabIndex = 19
        '
        'grLoaiMay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grLoaiMay, 4)
        Me.grLoaiMay.Controls.Add(Me.TableLayoutPanel4)
        Me.grLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grLoaiMay.Location = New System.Drawing.Point(63, 53)
        Me.grLoaiMay.Name = "grLoaiMay"
        Me.grLoaiMay.Size = New System.Drawing.Size(276, 49)
        Me.grLoaiMay.TabIndex = 151
        Me.grLoaiMay.TabStop = False
        Me.grLoaiMay.Text = "Tình trạng"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.rdLMChuaNghiemThu, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.rdLMDaNghiemThu, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(270, 30)
        Me.TableLayoutPanel4.TabIndex = 25
        '
        'rdLMChuaNghiemThu
        '
        Me.rdLMChuaNghiemThu.AutoSize = True
        Me.rdLMChuaNghiemThu.Checked = True
        Me.rdLMChuaNghiemThu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdLMChuaNghiemThu.ForeColor = System.Drawing.Color.Black
        Me.rdLMChuaNghiemThu.Location = New System.Drawing.Point(3, 3)
        Me.rdLMChuaNghiemThu.Name = "rdLMChuaNghiemThu"
        Me.rdLMChuaNghiemThu.Size = New System.Drawing.Size(129, 22)
        Me.rdLMChuaNghiemThu.TabIndex = 21
        Me.rdLMChuaNghiemThu.TabStop = True
        Me.rdLMChuaNghiemThu.Text = "Chưa nghiệm thu"
        Me.rdLMChuaNghiemThu.UseVisualStyleBackColor = True
        '
        'rdLMDaNghiemThu
        '
        Me.rdLMDaNghiemThu.AutoSize = True
        Me.rdLMDaNghiemThu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rdLMDaNghiemThu.ForeColor = System.Drawing.Color.Black
        Me.rdLMDaNghiemThu.Location = New System.Drawing.Point(138, 3)
        Me.rdLMDaNghiemThu.Name = "rdLMDaNghiemThu"
        Me.rdLMDaNghiemThu.Size = New System.Drawing.Size(129, 22)
        Me.rdLMDaNghiemThu.TabIndex = 20
        Me.rdLMDaNghiemThu.TabStop = True
        Me.rdLMDaNghiemThu.Text = "Đã nghiệm thu"
        Me.rdLMDaNghiemThu.UseVisualStyleBackColor = True
        '
        'cboLoaiTB1
        '
        Me.cboLoaiTB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiTB1.FormattingEnabled = True
        Me.cboLoaiTB1.Location = New System.Drawing.Point(252, 28)
        Me.cboLoaiTB1.Name = "cboLoaiTB1"
        Me.cboLoaiTB1.Size = New System.Drawing.Size(87, 21)
        Me.cboLoaiTB1.TabIndex = 17
        '
        'cboDiaDiem1
        '
        Me.cboDiaDiem1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiaDiem1.FormattingEnabled = True
        Me.cboDiaDiem1.Location = New System.Drawing.Point(111, 28)
        Me.cboDiaDiem1.Name = "cboDiaDiem1"
        Me.cboDiaDiem1.Size = New System.Drawing.Size(87, 21)
        Me.cboDiaDiem1.TabIndex = 18
        '
        'lblDiadiem
        '
        Me.lblDiadiem.AutoSize = True
        Me.lblDiadiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiadiem.Location = New System.Drawing.Point(63, 25)
        Me.lblDiadiem.Name = "lblDiadiem"
        Me.lblDiadiem.Size = New System.Drawing.Size(42, 25)
        Me.lblDiadiem.TabIndex = 152
        Me.lblDiadiem.Text = "Địa điểm"
        Me.lblDiadiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoaiTB
        '
        Me.lblLoaiTB.AutoSize = True
        Me.lblLoaiTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiTB.Location = New System.Drawing.Point(204, 25)
        Me.lblLoaiTB.Name = "lblLoaiTB"
        Me.lblLoaiTB.Size = New System.Drawing.Size(42, 25)
        Me.lblLoaiTB.TabIndex = 152
        Me.lblLoaiTB.Text = "Loại thiết bị"
        Me.lblLoaiTB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenNgay.Location = New System.Drawing.Point(252, 3)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(87, 20)
        Me.dtpDenNgay.TabIndex = 28
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDenngay.Location = New System.Drawing.Point(204, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(42, 25)
        Me.lblDenngay.TabIndex = 8
        Me.lblDenngay.Text = "Đến ngày"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(63, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(42, 25)
        Me.lblTungay.TabIndex = 26
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNgay.Location = New System.Drawing.Point(111, 3)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(87, 20)
        Me.dtpTuNgay.TabIndex = 27
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 306)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(400, 36)
        Me.TableLayoutPanel2.TabIndex = 152
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(313, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(223, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'frmrptDSCPBTTLoaiMay_LoaiTB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDSCPBTTLoaiMay_LoaiTB"
        Me.Size = New System.Drawing.Size(406, 345)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grLoaiMay.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grLoaiMay As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdLMChuaNghiemThu As System.Windows.Forms.RadioButton
    Friend WithEvents rdLMDaNghiemThu As System.Windows.Forms.RadioButton
    Friend WithEvents cboLoaiTB1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiaDiem1 As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDiadiem As System.Windows.Forms.Label
    Friend WithEvents lblLoaiTB As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
