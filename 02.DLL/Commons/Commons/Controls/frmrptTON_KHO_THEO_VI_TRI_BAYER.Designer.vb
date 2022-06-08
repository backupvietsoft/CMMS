<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptTON_KHO_THEO_VI_TRI_BAYER
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
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDenngay = New System.Windows.Forms.Label()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.lblKho = New System.Windows.Forms.Label()
        Me.cboKho = New System.Windows.Forms.ComboBox()
        Me.dtTuNgay_Kho = New System.Windows.Forms.DateTimePicker()
        Me.dtDenNgay_Kho = New System.Windows.Forms.DateTimePicker()
        Me.lblTungay = New System.Windows.Forms.Label()
        Me.cbxClass = New System.Windows.Forms.ComboBox()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblKho, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboKho, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtTuNgay_Kho, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtDenNgay_Kho, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxClass, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblClass, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(463, 390)
        Me.TableLayoutPanel1.TabIndex = 23
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(373, 363)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(87, 24)
        Me.btnThoat.TabIndex = 37
        Me.btnThoat.Text = "Thoát"
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(3, 50)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(54, 25)
        Me.lblDenngay.TabIndex = 34
        Me.lblDenngay.Text = "Đến ngày"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(260, 363)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(90, 24)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        '
        'lblKho
        '
        Me.lblKho.AutoSize = True
        Me.lblKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKho.Location = New System.Drawing.Point(3, 0)
        Me.lblKho.Name = "lblKho"
        Me.lblKho.Size = New System.Drawing.Size(54, 25)
        Me.lblKho.TabIndex = 29
        Me.lblKho.Text = "Kho"
        Me.lblKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboKho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboKho, 2)
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKho.FormattingEnabled = True
        Me.cboKho.Location = New System.Drawing.Point(63, 3)
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Size = New System.Drawing.Size(397, 21)
        Me.cboKho.TabIndex = 30
        '
        'dtTuNgay_Kho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtTuNgay_Kho, 2)
        Me.dtTuNgay_Kho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTuNgay_Kho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTuNgay_Kho.Location = New System.Drawing.Point(63, 28)
        Me.dtTuNgay_Kho.Name = "dtTuNgay_Kho"
        Me.dtTuNgay_Kho.Size = New System.Drawing.Size(397, 21)
        Me.dtTuNgay_Kho.TabIndex = 31
        '
        'dtDenNgay_Kho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtDenNgay_Kho, 2)
        Me.dtDenNgay_Kho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDenNgay_Kho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenNgay_Kho.Location = New System.Drawing.Point(63, 53)
        Me.dtDenNgay_Kho.Name = "dtDenNgay_Kho"
        Me.dtDenNgay_Kho.Size = New System.Drawing.Size(397, 21)
        Me.dtDenNgay_Kho.TabIndex = 32
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(3, 25)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(54, 25)
        Me.lblTungay.TabIndex = 33
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxClass
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbxClass, 2)
        Me.cbxClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxClass.FormattingEnabled = True
        Me.cbxClass.Location = New System.Drawing.Point(63, 78)
        Me.cbxClass.Name = "cbxClass"
        Me.cbxClass.Size = New System.Drawing.Size(397, 21)
        Me.cbxClass.TabIndex = 35
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClass.Location = New System.Drawing.Point(3, 75)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(54, 25)
        Me.lblClass.TabIndex = 36
        Me.lblClass.Text = "Class"
        Me.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmrptTON_KHO_THEO_VI_TRI_BAYER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptTON_KHO_THEO_VI_TRI_BAYER"
        Me.Size = New System.Drawing.Size(463, 390)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
    Friend WithEvents cbxClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblClass As System.Windows.Forms.Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
