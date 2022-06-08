<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBoPhanChiPhiReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptBoPhanChiPhiReport))
        Me.cbxNgoaiTe = New System.Windows.Forms.ComboBox
        Me.lblNgoaiTe = New System.Windows.Forms.Label
        Me.cbxLoaiChiuPhi = New System.Windows.Forms.ComboBox
        Me.dtpThang = New System.Windows.Forms.DateTimePicker
        Me.lblLoaiChiPhi = New System.Windows.Forms.Label
        Me.lblThang = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New System.Windows.Forms.Button
        Me.btnThucHien = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbxNgoaiTe
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxNgoaiTe, 2)
        Me.cbxNgoaiTe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxNgoaiTe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNgoaiTe.FormattingEnabled = True
        Me.cbxNgoaiTe.Items.AddRange(New Object() {"USD", "VND"})
        Me.cbxNgoaiTe.Location = New System.Drawing.Point(72, 58)
        Me.cbxNgoaiTe.Name = "cbxNgoaiTe"
        Me.cbxNgoaiTe.Size = New System.Drawing.Size(526, 21)
        Me.cbxNgoaiTe.TabIndex = 13
        '
        'lblNgoaiTe
        '
        Me.lblNgoaiTe.AutoSize = True
        Me.lblNgoaiTe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgoaiTe.Location = New System.Drawing.Point(3, 55)
        Me.lblNgoaiTe.Name = "lblNgoaiTe"
        Me.lblNgoaiTe.Size = New System.Drawing.Size(63, 28)
        Me.lblNgoaiTe.TabIndex = 12
        Me.lblNgoaiTe.Text = "Ngoại tệ"
        Me.lblNgoaiTe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxLoaiChiuPhi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxLoaiChiuPhi, 2)
        Me.cbxLoaiChiuPhi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxLoaiChiuPhi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxLoaiChiuPhi.FormattingEnabled = True
        Me.cbxLoaiChiuPhi.Location = New System.Drawing.Point(72, 30)
        Me.cbxLoaiChiuPhi.Name = "cbxLoaiChiuPhi"
        Me.cbxLoaiChiuPhi.Size = New System.Drawing.Size(526, 21)
        Me.cbxLoaiChiuPhi.TabIndex = 11
        '
        'dtpThang
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpThang, 2)
        Me.dtpThang.CustomFormat = "MM/yyyy"
        Me.dtpThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpThang.Location = New System.Drawing.Point(72, 3)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(526, 20)
        Me.dtpThang.TabIndex = 10
        '
        'lblLoaiChiPhi
        '
        Me.lblLoaiChiPhi.AutoSize = True
        Me.lblLoaiChiPhi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiChiPhi.Location = New System.Drawing.Point(3, 27)
        Me.lblLoaiChiPhi.Name = "lblLoaiChiPhi"
        Me.lblLoaiChiPhi.Size = New System.Drawing.Size(63, 28)
        Me.lblLoaiChiPhi.TabIndex = 9
        Me.lblLoaiChiPhi.Text = "Loại chi phí"
        Me.lblLoaiChiPhi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblThang
        '
        Me.lblThang.AutoSize = True
        Me.lblThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThang.Location = New System.Drawing.Point(3, 0)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(63, 27)
        Me.lblThang.TabIndex = 8
        Me.lblThang.Text = "Tháng"
        Me.lblThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblThang, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiChiPhi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNgoaiTe, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNgoaiTe, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxLoaiChiuPhi, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpThang, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(601, 454)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'btnThoat
        '
        Me.btnThoat.BackgroundImage = CType(resources.GetObject("btnThoat.BackgroundImage"), System.Drawing.Image)
        Me.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(504, 427)
        Me.btnThoat.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThoat.Size = New System.Drawing.Size(87, 24)
        Me.btnThoat.TabIndex = 15
        Me.btnThoat.Text = "Thoát"
        Me.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'btnThucHien
        '
        Me.btnThucHien.BackgroundImage = Global.Commons.My.Resources.Resources.ThucHien
        Me.btnThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(401, 427)
        Me.btnThucHien.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Padding = New System.Windows.Forms.Padding(23, 0, 0, 0)
        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 14
        Me.btnThucHien.Text = "Thực hiện"
        Me.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnThucHien.UseVisualStyleBackColor = True
        '
        'frmrptBoPhanChiPhiReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptBoPhanChiPhiReport"
        Me.Size = New System.Drawing.Size(601, 454)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbxNgoaiTe As System.Windows.Forms.ComboBox
    Friend WithEvents lblNgoaiTe As System.Windows.Forms.Label
    Friend WithEvents cbxLoaiChiuPhi As System.Windows.Forms.ComboBox
    Friend WithEvents dtpThang As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLoaiChiPhi As System.Windows.Forms.Label
    Friend WithEvents lblThang As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As System.Windows.Forms.Button

End Class
