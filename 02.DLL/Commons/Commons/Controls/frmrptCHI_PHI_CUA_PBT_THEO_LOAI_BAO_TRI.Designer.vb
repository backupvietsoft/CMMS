﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI
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
        Me.dtpDenNam_TKCP = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDenNam_TKCP = New System.Windows.Forms.Label()
        Me.dtpTuNam_TKCP = New System.Windows.Forms.DateTimePicker()
        Me.lblLoaiTB_CP = New System.Windows.Forms.Label()
        Me.lblTuNam_TKCP = New System.Windows.Forms.Label()
        Me.lblLoaiBT_CP = New System.Windows.Forms.Label()
        Me.cboLoaiTB_CP = New System.Windows.Forms.ComboBox()
        Me.cboLoaiBT_CP = New System.Windows.Forms.ComboBox()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDenNam_TKCP, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenNam_TKCP, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTuNam_TKCP, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiTB_CP, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuNam_TKCP, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiBT_CP, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiTB_CP, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLoaiBT_CP, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThoat, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnThucHien, 3, 7)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1113, 547)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'dtpDenNam_TKCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpDenNam_TKCP, 2)
        Me.dtpDenNam_TKCP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpDenNam_TKCP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenNam_TKCP.Location = New System.Drawing.Point(223, 111)
        Me.dtpDenNam_TKCP.Name = "dtpDenNam_TKCP"
        Me.dtpDenNam_TKCP.Size = New System.Drawing.Size(777, 21)
        Me.dtpDenNam_TKCP.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 3)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(113, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(887, 25)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Thống kê chi phí theo giai đoạn"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDenNam_TKCP
        '
        Me.lblDenNam_TKCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNam_TKCP.ForeColor = System.Drawing.Color.Black
        Me.lblDenNam_TKCP.Location = New System.Drawing.Point(113, 108)
        Me.lblDenNam_TKCP.Name = "lblDenNam_TKCP"
        Me.lblDenNam_TKCP.Size = New System.Drawing.Size(104, 25)
        Me.lblDenNam_TKCP.TabIndex = 16
        Me.lblDenNam_TKCP.Text = "Đến ngày:"
        Me.lblDenNam_TKCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTuNam_TKCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dtpTuNam_TKCP, 2)
        Me.dtpTuNam_TKCP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtpTuNam_TKCP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNam_TKCP.Location = New System.Drawing.Point(223, 86)
        Me.dtpTuNam_TKCP.Name = "dtpTuNam_TKCP"
        Me.dtpTuNam_TKCP.Size = New System.Drawing.Size(777, 21)
        Me.dtpTuNam_TKCP.TabIndex = 17
        '
        'lblLoaiTB_CP
        '
        Me.lblLoaiTB_CP.AutoSize = True
        Me.lblLoaiTB_CP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiTB_CP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoaiTB_CP.Location = New System.Drawing.Point(113, 8)
        Me.lblLoaiTB_CP.Name = "lblLoaiTB_CP"
        Me.lblLoaiTB_CP.Size = New System.Drawing.Size(104, 25)
        Me.lblLoaiTB_CP.TabIndex = 8
        Me.lblLoaiTB_CP.Text = "Loại thiết bị"
        Me.lblLoaiTB_CP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTuNam_TKCP
        '
        Me.lblTuNam_TKCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuNam_TKCP.ForeColor = System.Drawing.Color.Black
        Me.lblTuNam_TKCP.Location = New System.Drawing.Point(113, 83)
        Me.lblTuNam_TKCP.Name = "lblTuNam_TKCP"
        Me.lblTuNam_TKCP.Size = New System.Drawing.Size(104, 25)
        Me.lblTuNam_TKCP.TabIndex = 15
        Me.lblTuNam_TKCP.Text = "Từ ngày:"
        Me.lblTuNam_TKCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoaiBT_CP
        '
        Me.lblLoaiBT_CP.AutoSize = True
        Me.lblLoaiBT_CP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiBT_CP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoaiBT_CP.Location = New System.Drawing.Point(113, 33)
        Me.lblLoaiBT_CP.Name = "lblLoaiBT_CP"
        Me.lblLoaiBT_CP.Size = New System.Drawing.Size(104, 25)
        Me.lblLoaiBT_CP.TabIndex = 12
        Me.lblLoaiBT_CP.Text = "Lọai bảo trì"
        Me.lblLoaiBT_CP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoaiTB_CP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboLoaiTB_CP, 2)
        Me.cboLoaiTB_CP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiTB_CP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiTB_CP.FormattingEnabled = True
        Me.cboLoaiTB_CP.Location = New System.Drawing.Point(223, 11)
        Me.cboLoaiTB_CP.Name = "cboLoaiTB_CP"
        Me.cboLoaiTB_CP.Size = New System.Drawing.Size(777, 21)
        Me.cboLoaiTB_CP.TabIndex = 21
        '
        'cboLoaiBT_CP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboLoaiBT_CP, 2)
        Me.cboLoaiBT_CP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiBT_CP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoaiBT_CP.FormattingEnabled = True
        Me.cboLoaiBT_CP.Location = New System.Drawing.Point(223, 36)
        Me.cboLoaiBT_CP.Name = "cboLoaiBT_CP"
        Me.cboLoaiBT_CP.Size = New System.Drawing.Size(777, 21)
        Me.cboLoaiBT_CP.TabIndex = 22
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(1006, 510)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 23
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(896, 510)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        '
        'frmrptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptCHI_PHI_CUA_PBT_THEO_LOAI_BAO_TRI"
        Me.Size = New System.Drawing.Size(1113, 547)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtpDenNam_TKCP As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDenNam_TKCP As System.Windows.Forms.Label
    Friend WithEvents dtpTuNam_TKCP As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLoaiTB_CP As System.Windows.Forms.Label
    Friend WithEvents lblTuNam_TKCP As System.Windows.Forms.Label
    Friend WithEvents lblLoaiBT_CP As System.Windows.Forms.Label
    Friend WithEvents cboLoaiTB_CP As System.Windows.Forms.ComboBox
    Friend WithEvents cboLoaiBT_CP As System.Windows.Forms.ComboBox
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
