﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptKehoachbaotriduphong
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptKehoachbaotriduphong))
        Me.lblTrangthai = New System.Windows.Forms.Label
        Me.lblNhaxuong = New System.Windows.Forms.Label
        Me.lblDenngay = New System.Windows.Forms.Label
        Me.lblTungay = New System.Windows.Forms.Label
        Me.cboTrangthai = New System.Windows.Forms.ComboBox
        Me.cboNhaxuong = New System.Windows.Forms.ComboBox
        Me.dtpDN = New System.Windows.Forms.DateTimePicker
        Me.dtpTN = New System.Windows.Forms.DateTimePicker
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTrangthai
        '
        Me.lblTrangthai.AutoSize = True
        Me.lblTrangthai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTrangthai.Location = New System.Drawing.Point(220, 25)
        Me.lblTrangthai.Name = "lblTrangthai"
        Me.lblTrangthai.Size = New System.Drawing.Size(46, 25)
        Me.lblTrangthai.TabIndex = 8
        Me.lblTrangthai.Text = "Trạng thái"
        Me.lblTrangthai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.AutoSize = True
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(68, 25)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(46, 25)
        Me.lblNhaxuong.TabIndex = 9
        Me.lblNhaxuong.Text = "Nhà xưởng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay.Location = New System.Drawing.Point(220, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(46, 25)
        Me.lblDenngay.TabIndex = 10
        Me.lblDenngay.Text = "Đến tháng"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay.Location = New System.Drawing.Point(68, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(46, 25)
        Me.lblTungay.TabIndex = 11
        Me.lblTungay.Text = "Từ tháng"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTrangthai
        '
        Me.cboTrangthai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrangthai.FormattingEnabled = True
        Me.cboTrangthai.Items.AddRange(New Object() {"Bình thường", "An toàn", "All"})
        Me.cboTrangthai.Location = New System.Drawing.Point(272, 28)
        Me.cboTrangthai.Name = "cboTrangthai"
        Me.cboTrangthai.Size = New System.Drawing.Size(94, 21)
        Me.cboTrangthai.TabIndex = 7
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNhaxuong.FormattingEnabled = True
        Me.cboNhaxuong.Location = New System.Drawing.Point(120, 28)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.Size = New System.Drawing.Size(94, 21)
        Me.cboNhaxuong.TabIndex = 6
        '
        'dtpDN
        '
        Me.dtpDN.CustomFormat = "MM/yyyy"
        Me.dtpDN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDN.Location = New System.Drawing.Point(272, 3)
        Me.dtpDN.Name = "dtpDN"
        Me.dtpDN.Size = New System.Drawing.Size(94, 20)
        Me.dtpDN.TabIndex = 4
        Me.dtpDN.Value = New Date(2010, 6, 14, 13, 30, 9, 0)
        '
        'dtpTN
        '
        Me.dtpTN.CustomFormat = "MM/yyyy"
        Me.dtpTN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTN.Location = New System.Drawing.Point(120, 3)
        Me.dtpTN.Name = "dtpTN"
        Me.dtpTN.Size = New System.Drawing.Size(94, 20)
        Me.dtpTN.TabIndex = 5
        Me.dtpTN.Value = New Date(2010, 6, 14, 13, 30, 9, 0)
        '
        'btnThucHien
        '


        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(256, 3)
        Me.btnThucHien.Name = "btnThucHien"

        Me.btnThucHien.Size = New System.Drawing.Size(84, 30)
        Me.btnThucHien.TabIndex = 17
        Me.btnThucHien.Text = "Thực hiện"


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
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTrangthai, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTrangthai, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDN, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenngay, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTN, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTungay, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 7)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(439, 356)
        Me.TableLayoutPanel1.TabIndex = 18
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 317)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(433, 36)
        Me.TableLayoutPanel2.TabIndex = 34
        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(346, 3)
        Me.btnThoat.Name = "btnThoat"

        Me.btnThoat.Size = New System.Drawing.Size(84, 30)
        Me.btnThoat.TabIndex = 33
        Me.btnThoat.Text = "Thoát"


        '
        'frmrptKehoachbaotriduphong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptKehoachbaotriduphong"
        Me.Size = New System.Drawing.Size(439, 356)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTrangthai As System.Windows.Forms.Label
    Friend WithEvents lblNhaxuong As System.Windows.Forms.Label
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents cboTrangthai As System.Windows.Forms.ComboBox
    Friend WithEvents cboNhaxuong As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDN As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTN As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
