<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBoPhanChiPhiReport
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
        Me.cbxNgoaiTe = New System.Windows.Forms.ComboBox()
        Me.lblNgoaiTe = New System.Windows.Forms.Label()
        Me.cbxLoaiChiuPhi = New System.Windows.Forms.ComboBox()
        Me.dtpThang = New System.Windows.Forms.DateTimePicker()
        Me.lblLoaiChiPhi = New System.Windows.Forms.Label()
        Me.lblThang = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
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
        Me.cbxNgoaiTe.Location = New System.Drawing.Point(223, 61)
        Me.cbxNgoaiTe.Name = "cbxNgoaiTe"
        Me.cbxNgoaiTe.Size = New System.Drawing.Size(265, 21)
        Me.cbxNgoaiTe.TabIndex = 13
        '
        'lblNgoaiTe
        '
        Me.lblNgoaiTe.AutoSize = True
        Me.lblNgoaiTe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgoaiTe.Location = New System.Drawing.Point(113, 58)
        Me.lblNgoaiTe.Name = "lblNgoaiTe"
        Me.lblNgoaiTe.Size = New System.Drawing.Size(104, 25)
        Me.lblNgoaiTe.TabIndex = 12
        Me.lblNgoaiTe.Text = "Ngoại tệ"
        Me.lblNgoaiTe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxLoaiChiuPhi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxLoaiChiuPhi, 2)
        Me.cbxLoaiChiuPhi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxLoaiChiuPhi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxLoaiChiuPhi.FormattingEnabled = True
        Me.cbxLoaiChiuPhi.Location = New System.Drawing.Point(223, 36)
        Me.cbxLoaiChiuPhi.Name = "cbxLoaiChiuPhi"
        Me.cbxLoaiChiuPhi.Size = New System.Drawing.Size(265, 21)
        Me.cbxLoaiChiuPhi.TabIndex = 11
        '
        'dtpThang
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpThang, 2)
        Me.dtpThang.CustomFormat = "MM/yyyy"
        Me.dtpThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpThang.Location = New System.Drawing.Point(223, 11)
        Me.dtpThang.Name = "dtpThang"
        Me.dtpThang.Size = New System.Drawing.Size(265, 21)
        Me.dtpThang.TabIndex = 10
        '
        'lblLoaiChiPhi
        '
        Me.lblLoaiChiPhi.AutoSize = True
        Me.lblLoaiChiPhi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiChiPhi.Location = New System.Drawing.Point(113, 33)
        Me.lblLoaiChiPhi.Name = "lblLoaiChiPhi"
        Me.lblLoaiChiPhi.Size = New System.Drawing.Size(104, 25)
        Me.lblLoaiChiPhi.TabIndex = 9
        Me.lblLoaiChiPhi.Text = "Loại chi phí"
        Me.lblLoaiChiPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblThang
        '
        Me.lblThang.AutoSize = True
        Me.lblThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThang.Location = New System.Drawing.Point(113, 8)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(104, 25)
        Me.lblThang.TabIndex = 8
        Me.lblThang.Text = "Tháng"
        Me.lblThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblThang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiChiPhi, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxNgoaiTe, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNgoaiTe, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxLoaiChiuPhi, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpThang, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(601, 454)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(494, 417)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 15
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(384, 417)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 14
        Me.btnThucHien.Text = "Thực hiện"
        '
        'frmrptBoPhanChiPhiReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
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
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
