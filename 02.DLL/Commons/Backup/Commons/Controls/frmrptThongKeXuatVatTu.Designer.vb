<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptThongKeXuatVatTu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptThongKeXuatVatTu))
        Me.labKho = New System.Windows.Forms.Label
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.labDenNgay = New System.Windows.Forms.Label
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.labTuNgay = New System.Windows.Forms.Label
        Me.cboKho = New System.Windows.Forms.ComboBox
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'labKho
        '
        Me.labKho.AutoSize = True
        Me.labKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labKho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labKho.Location = New System.Drawing.Point(73, 46)
        Me.labKho.Name = "labKho"
        Me.labKho.Size = New System.Drawing.Size(50, 31)
        Me.labKho.TabIndex = 6
        Me.labKho.Text = "Kho hàng"
        Me.labKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenNgay.Location = New System.Drawing.Point(292, 18)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(101, 23)
        Me.dtpDenNgay.TabIndex = 6
        '
        'labDenNgay
        '
        Me.labDenNgay.AutoSize = True
        Me.labDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labDenNgay.Location = New System.Drawing.Point(236, 15)
        Me.labDenNgay.Name = "labDenNgay"
        Me.labDenNgay.Size = New System.Drawing.Size(50, 31)
        Me.labDenNgay.TabIndex = 5
        Me.labDenNgay.Text = "Đến ngày:"
        Me.labDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTuNgay.Location = New System.Drawing.Point(129, 18)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(101, 23)
        Me.dtpTuNgay.TabIndex = 5
        '
        'labTuNgay
        '
        Me.labTuNgay.AutoSize = True
        Me.labTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labTuNgay.Location = New System.Drawing.Point(73, 15)
        Me.labTuNgay.Name = "labTuNgay"
        Me.labTuNgay.Size = New System.Drawing.Size(50, 31)
        Me.labTuNgay.TabIndex = 4
        Me.labTuNgay.Text = "Từ ngày:"
        Me.labTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboKho
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.cboKho, 3)
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.Location = New System.Drawing.Point(129, 49)
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Size = New System.Drawing.Size(264, 21)
        Me.cboKho.TabIndex = 18
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(353, 0)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(0)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(110, 31)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(243, 0)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(0)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(110, 31)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.labDenNgay, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpDenNgay, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.labKho, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.cboKho, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpTuNgay, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.labTuNgay, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 4)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(469, 408)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel3.SetColumnSpan(Me.TableLayoutPanel4, 6)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 374)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(463, 31)
        Me.TableLayoutPanel4.TabIndex = 19
        '
        'frmrptThongKeXuatVatTu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Name = "frmrptThongKeXuatVatTu"
        Me.Size = New System.Drawing.Size(469, 408)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents labTuNgay As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents labKho As System.Windows.Forms.Label
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents labDenNgay As System.Windows.Forms.Label
    Friend WithEvents cboKho As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents btnThoat As System.Windows.Forms.Button

End Class
