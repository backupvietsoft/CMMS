<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptBieudoTopTGNM
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
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mtxtTop = New System.Windows.Forms.MaskedTextBox()
        Me.lblNhaxuong = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblDenthang = New System.Windows.Forms.Label()
        Me.lblTuthang = New System.Windows.Forms.Label()
        Me.cboNhaxuong = New System.Windows.Forms.ComboBox()
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker()
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "CHON"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 125
        '
        'mtxtTop
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.mtxtTop, 2)
        Me.mtxtTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtTop.Location = New System.Drawing.Point(665, 36)
        Me.mtxtTop.Mask = "00"
        Me.mtxtTop.Name = "mtxtTop"
        Me.mtxtTop.Size = New System.Drawing.Size(326, 21)
        Me.mtxtTop.TabIndex = 14
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.AutoSize = True
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(113, 33)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(104, 25)
        Me.lblNhaxuong.TabIndex = 11
        Me.lblNhaxuong.Text = "Nhà xưởng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTop.Location = New System.Drawing.Point(555, 33)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(104, 25)
        Me.lblTop.TabIndex = 12
        Me.lblTop.Text = "Top"
        Me.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenthang
        '
        Me.lblDenthang.AutoSize = True
        Me.lblDenthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenthang.Location = New System.Drawing.Point(555, 8)
        Me.lblDenthang.Name = "lblDenthang"
        Me.lblDenthang.Size = New System.Drawing.Size(104, 25)
        Me.lblDenthang.TabIndex = 13
        Me.lblDenthang.Text = "Đến ngày"
        Me.lblDenthang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTuthang
        '
        Me.lblTuthang.AutoSize = True
        Me.lblTuthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuthang.Location = New System.Drawing.Point(113, 8)
        Me.lblTuthang.Name = "lblTuthang"
        Me.lblTuthang.Size = New System.Drawing.Size(104, 25)
        Me.lblTuthang.TabIndex = 10
        Me.lblTuthang.Text = "Từ ngày"
        Me.lblTuthang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhaxuong
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhaxuong, 2)
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.Location = New System.Drawing.Point(223, 36)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Size = New System.Drawing.Size(326, 21)
        Me.cboNhaxuong.TabIndex = 9
        '
        'dtpDenngay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpDenngay, 2)
        Me.dtpDenngay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngay.Location = New System.Drawing.Point(665, 11)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(326, 21)
        Me.dtpDenngay.TabIndex = 7
        '
        'dtpTungay
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpTungay, 2)
        Me.dtpTungay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungay.Location = New System.Drawing.Point(223, 11)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(326, 21)
        Me.dtpTungay.TabIndex = 8
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(887, 617)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 15
        Me.btnThucHien.Text = "Thực hiện"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtTop, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuthang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTop, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTungay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenthang, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenngay, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 7, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 6, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1104, 654)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(997, 617)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 16
        Me.btnThoat.Text = "Thoát"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MS_LOAI_MAY"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "TEN_LOAI_MAY"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 125
        '
        'frmrptBieudoTopTGNM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptBieudoTopTGNM"
        Me.Size = New System.Drawing.Size(1104, 654)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents mtxtTop As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNhaxuong As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents lblDenthang As System.Windows.Forms.Label
    Friend WithEvents lblTuthang As System.Windows.Forms.Label
    Friend WithEvents cboNhaxuong As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
