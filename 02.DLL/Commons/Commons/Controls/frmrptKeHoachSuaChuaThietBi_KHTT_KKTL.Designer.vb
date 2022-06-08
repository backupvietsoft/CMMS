<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptKeHoachSuaChuaThietBi_KHTT_KKTL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptKeHoachSuaChuaThietBi_KHTT_KKTL))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.dtpDN = New System.Windows.Forms.DateTimePicker
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.dtpTN = New System.Windows.Forms.DateTimePicker
        Me.lblTungay = New System.Windows.Forms.Label
        Me.cboDiadiem = New System.Windows.Forms.ComboBox
        Me.lblDiaDiem = New System.Windows.Forms.Label
        Me.lblNhaxuong = New System.Windows.Forms.Label
        Me.cboNhaxuong = New System.Windows.Forms.ComboBox
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
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDN, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTN, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDiadiem, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDiaDiem, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(416, 354)
        Me.TableLayoutPanel1.TabIndex = 19
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 315)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(410, 36)
        Me.TableLayoutPanel2.TabIndex = 20
        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(323, 3)
        Me.btnThoat.Name = "btnThoat"

        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 33
        Me.btnThoat.Text = "Thoát"


        '
        'btnThucHien
        '


        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(233, 3)
        Me.btnThucHien.Name = "btnThucHien"

        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"


        '
        'dtpDN
        '
        Me.dtpDN.CustomFormat = "dd/MM/yyyy"
        Me.dtpDN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDN.Location = New System.Drawing.Point(258, 3)
        Me.dtpDN.Name = "dtpDN"
        Me.dtpDN.Size = New System.Drawing.Size(89, 20)
        Me.dtpDN.TabIndex = 4
        Me.dtpDN.Value = New Date(2010, 6, 14, 13, 30, 9, 0)
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(209, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(43, 25)
        Me.lblDenngay.TabIndex = 10
        Me.lblDenngay.Text = "Đến ngày"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTN
        '
        Me.dtpTN.CustomFormat = "dd/MM/yyyy"
        Me.dtpTN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTN.Location = New System.Drawing.Point(114, 3)
        Me.dtpTN.Name = "dtpTN"
        Me.dtpTN.Size = New System.Drawing.Size(89, 20)
        Me.dtpTN.TabIndex = 5
        Me.dtpTN.Value = New Date(2010, 6, 14, 13, 30, 9, 0)
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(65, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(43, 25)
        Me.lblTungay.TabIndex = 11
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDiadiem
        '
        Me.cboDiadiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiadiem.FormattingEnabled = True
        Me.cboDiadiem.Location = New System.Drawing.Point(114, 28)
        Me.cboDiadiem.Name = "cboDiadiem"
        Me.cboDiadiem.Size = New System.Drawing.Size(89, 21)
        Me.cboDiadiem.TabIndex = 19
        '
        'lblDiaDiem
        '
        Me.lblDiaDiem.AutoSize = True
        Me.lblDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiaDiem.Location = New System.Drawing.Point(65, 25)
        Me.lblDiaDiem.Name = "lblDiaDiem"
        Me.lblDiaDiem.Size = New System.Drawing.Size(43, 25)
        Me.lblDiaDiem.TabIndex = 18
        Me.lblDiaDiem.Text = "Địa điểm"
        Me.lblDiaDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.AutoSize = True
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(209, 25)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(43, 25)
        Me.lblNhaxuong.TabIndex = 9
        Me.lblNhaxuong.Text = "Nhà xưởng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.Location = New System.Drawing.Point(258, 28)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Size = New System.Drawing.Size(89, 21)
        Me.cboNhaxuong.TabIndex = 6
        '
        'frmrptKeHoachSuaChuaThietBi_KHTT_KKTL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptKeHoachSuaChuaThietBi_KHTT_KKTL"
        Me.Size = New System.Drawing.Size(416, 354)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents lblNhaxuong As System.Windows.Forms.Label
    Friend WithEvents cboNhaxuong As System.Windows.Forms.ComboBox
    Friend WithEvents dtpTN As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents dtpDN As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDiaDiem As System.Windows.Forms.Label
    Friend WithEvents cboDiadiem As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
