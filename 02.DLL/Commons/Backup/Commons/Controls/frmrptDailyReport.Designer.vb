<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDailyReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptDailyReport))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lbaChonXuong = New System.Windows.Forms.Label
        Me.lbaChonNgay = New System.Windows.Forms.Label
        Me.mtxtChonNgay = New System.Windows.Forms.MaskedTextBox
        Me.cbxChonXuong = New System.Windows.Forms.ComboBox
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.btnThoat = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaChonXuong, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaChonNgay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtChonNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxChonXuong, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(543, 414)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lbaChonXuong
        '
        Me.lbaChonXuong.AutoSize = True
        Me.lbaChonXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaChonXuong.Location = New System.Drawing.Point(3, 0)
        Me.lbaChonXuong.Name = "lbaChonXuong"
        Me.lbaChonXuong.Size = New System.Drawing.Size(64, 31)
        Me.lbaChonXuong.TabIndex = 1
        Me.lbaChonXuong.Text = "Chọn xưởng"
        Me.lbaChonXuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbaChonNgay
        '
        Me.lbaChonNgay.AutoSize = True
        Me.lbaChonNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaChonNgay.Location = New System.Drawing.Point(3, 31)
        Me.lbaChonNgay.Name = "lbaChonNgay"
        Me.lbaChonNgay.Size = New System.Drawing.Size(64, 27)
        Me.lbaChonNgay.TabIndex = 2
        Me.lbaChonNgay.Text = "Chọn ngày:"
        Me.lbaChonNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mtxtChonNgay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.mtxtChonNgay, 2)
        Me.mtxtChonNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtChonNgay.Location = New System.Drawing.Point(73, 34)
        Me.mtxtChonNgay.Mask = "00/00/0000"
        Me.mtxtChonNgay.Name = "mtxtChonNgay"
        Me.mtxtChonNgay.Size = New System.Drawing.Size(467, 20)
        Me.mtxtChonNgay.TabIndex = 4
        Me.mtxtChonNgay.ValidatingType = GetType(Date)
        '
        'cbxChonXuong
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxChonXuong, 2)
        Me.cbxChonXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxChonXuong.FormattingEnabled = True
        Me.cbxChonXuong.Location = New System.Drawing.Point(73, 3)
        Me.cbxChonXuong.Name = "cbxChonXuong"
        Me.cbxChonXuong.Size = New System.Drawing.Size(467, 21)
        Me.cbxChonXuong.TabIndex = 3
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(343, 387)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 11
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(446, 387)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 24)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'frmrptDailyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDailyReport"
        Me.Size = New System.Drawing.Size(543, 414)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbaChonXuong As System.Windows.Forms.Label
    Friend WithEvents lbaChonNgay As System.Windows.Forms.Label
    Friend WithEvents mtxtChonNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxChonXuong As System.Windows.Forms.ComboBox
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
