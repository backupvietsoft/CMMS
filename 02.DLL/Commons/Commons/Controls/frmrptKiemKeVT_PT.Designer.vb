<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptKiemKeVT_PT
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
        Me.mtxtNgay = New System.Windows.Forms.MaskedTextBox()
        Me.cbxKho = New System.Windows.Forms.ComboBox()
        Me.lbaKho = New System.Windows.Forms.Label()
        Me.lbaNgay = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPN = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'mtxtNgay
        '
        Me.mtxtNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mtxtNgay.Location = New System.Drawing.Point(136, 18)
        Me.mtxtNgay.Mask = "00/00/0000"
        Me.mtxtNgay.Name = "mtxtNgay"
        Me.mtxtNgay.Size = New System.Drawing.Size(108, 21)
        Me.mtxtNgay.TabIndex = 7
        Me.mtxtNgay.ValidatingType = GetType(Date)
        '
        'cbxKho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxKho, 2)
        Me.cbxKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxKho.FormattingEnabled = True
        Me.cbxKho.Location = New System.Drawing.Point(136, 49)
        Me.cbxKho.Name = "cbxKho"
        Me.cbxKho.Size = New System.Drawing.Size(167, 21)
        Me.cbxKho.TabIndex = 6
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaKho.Location = New System.Drawing.Point(77, 46)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(25, 31)
        Me.lbaKho.TabIndex = 5
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbaNgay
        '
        Me.lbaNgay.AutoSize = True
        Me.lbaNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbaNgay.Location = New System.Drawing.Point(77, 15)
        Me.lbaNgay.Name = "lbaNgay"
        Me.lbaNgay.Size = New System.Drawing.Size(32, 31)
        Me.lbaNgay.TabIndex = 4
        Me.lbaNgay.Text = "Ngày"
        Me.lbaNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPN, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.mtxtNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxKho, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(496, 356)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 322)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(490, 31)
        Me.TableLayoutPanel2.TabIndex = 18
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(383, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 25)
        Me.btnThoat.TabIndex = 34
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(273, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 25)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"
        '
        'chkPN
        '
        Me.chkPN.AutoSize = True
        Me.chkPN.Checked = True
        Me.chkPN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkPN.Location = New System.Drawing.Point(309, 49)
        Me.chkPN.Name = "chkPN"
        Me.chkPN.Size = New System.Drawing.Size(108, 25)
        Me.chkPN.TabIndex = 19
        Me.chkPN.Text = "CheckBox1"
        Me.chkPN.UseVisualStyleBackColor = True
        '
        'frmrptKiemKeVT_PT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptKiemKeVT_PT"
        Me.Size = New System.Drawing.Size(496, 356)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mtxtNgay As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxKho As System.Windows.Forms.ComboBox
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents lbaNgay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPN As System.Windows.Forms.CheckBox

End Class
