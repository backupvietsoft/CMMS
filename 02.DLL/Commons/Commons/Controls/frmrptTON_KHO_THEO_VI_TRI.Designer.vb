<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTON_KHO_THEO_VI_TRI
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtTuNgay_Kho = New System.Windows.Forms.DateTimePicker()
        Me.lblTungay = New System.Windows.Forms.Label()
        Me.lblDenngay = New System.Windows.Forms.Label()
        Me.dtDenNgay_Kho = New System.Windows.Forms.DateTimePicker()
        Me.cboKho = New System.Windows.Forms.ComboBox()
        Me.lblKho = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.dtTuNgay_Kho, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtDenNgay_Kho, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboKho, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblKho, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(377, 322)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'dtTuNgay_Kho
        '
        Me.dtTuNgay_Kho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTuNgay_Kho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTuNgay_Kho.Location = New System.Drawing.Point(104, 3)
        Me.dtTuNgay_Kho.Name = "dtTuNgay_Kho"
        Me.dtTuNgay_Kho.Size = New System.Drawing.Size(80, 21)
        Me.dtTuNgay_Kho.TabIndex = 31
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTungay.Location = New System.Drawing.Point(59, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(31, 31)
        Me.lblTungay.TabIndex = 33
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblDenngay.Location = New System.Drawing.Point(190, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(31, 31)
        Me.lblDenngay.TabIndex = 34
        Me.lblDenngay.Text = "Đến ngày"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtDenNgay_Kho
        '
        Me.dtDenNgay_Kho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDenNgay_Kho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenNgay_Kho.Location = New System.Drawing.Point(235, 3)
        Me.dtDenNgay_Kho.Name = "dtDenNgay_Kho"
        Me.dtDenNgay_Kho.Size = New System.Drawing.Size(80, 21)
        Me.dtDenNgay_Kho.TabIndex = 32
        '
        'cboKho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboKho, 3)
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.Location = New System.Drawing.Point(104, 34)
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Size = New System.Drawing.Size(211, 21)
        Me.cboKho.TabIndex = 30
        '
        'lblKho
        '
        Me.lblKho.AutoSize = True
        Me.lblKho.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblKho.Location = New System.Drawing.Point(59, 31)
        Me.lblKho.Name = "lblKho"
        Me.lblKho.Size = New System.Drawing.Size(25, 31)
        Me.lblKho.TabIndex = 29
        Me.lblKho.Text = "Kho"
        Me.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 288)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(371, 31)
        Me.TableLayoutPanel2.TabIndex = 37
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(154, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 25)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(264, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 25)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        '
        'frmrptTON_KHO_THEO_VI_TRI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptTON_KHO_THEO_VI_TRI"
        Me.Size = New System.Drawing.Size(377, 322)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblKho As System.Windows.Forms.Label
    Friend WithEvents cboKho As System.Windows.Forms.ComboBox
    Friend WithEvents dtTuNgay_Kho As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDenNgay_Kho As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
