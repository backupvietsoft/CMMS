﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptKHA_NANG_SAN_SANG_THEO_THIET_BI_BREAKDOWN
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptKHA_NANG_SAN_SANG_THEO_THIET_BI_BREAKDOWN))
        Me.mskTu = New System.Windows.Forms.MaskedTextBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.gDaychuyen = New System.Windows.Forms.GroupBox
        Me.gvDaychuyen = New System.Windows.Forms.DataGridView
        Me.clChonDaychuyen = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.clMsDaychuyen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clDaychuyen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gDieuKien = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.mskDen = New System.Windows.Forms.MaskedTextBox
        Me.labThang = New System.Windows.Forms.Label
        Me.labDenthang = New System.Windows.Forms.Label
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gDaychuyen.SuspendLayout()
        CType(Me.gvDaychuyen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDieuKien.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'mskTu
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.mskTu, 2)
        Me.mskTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mskTu.Location = New System.Drawing.Point(123, 3)
        Me.mskTu.Mask = "00/0000"
        Me.mskTu.Name = "mskTu"
        Me.mskTu.Size = New System.Drawing.Size(173, 20)
        Me.mskTu.TabIndex = 5
        Me.mskTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gDaychuyen, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.gDieuKien, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(610, 499)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'gDaychuyen
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gDaychuyen, 4)
        Me.gDaychuyen.Controls.Add(Me.gvDaychuyen)
        Me.gDaychuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gDaychuyen.Location = New System.Drawing.Point(3, 57)
        Me.gDaychuyen.Name = "gDaychuyen"
        Me.gDaychuyen.Size = New System.Drawing.Size(604, 405)
        Me.gDaychuyen.TabIndex = 2
        Me.gDaychuyen.TabStop = False
        Me.gDaychuyen.Text = "Chọn dậy chuyền"
        '
        'gvDaychuyen
        '
        Me.gvDaychuyen.AllowUserToAddRows = False
        Me.gvDaychuyen.AllowUserToDeleteRows = False
        Me.gvDaychuyen.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvDaychuyen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvDaychuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDaychuyen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clChonDaychuyen, Me.clMsDaychuyen, Me.clDaychuyen})
        Me.gvDaychuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvDaychuyen.Location = New System.Drawing.Point(3, 16)
        Me.gvDaychuyen.Name = "gvDaychuyen"
        Me.gvDaychuyen.RowHeadersVisible = False
        Me.gvDaychuyen.RowHeadersWidth = 30
        Me.gvDaychuyen.Size = New System.Drawing.Size(598, 386)
        Me.gvDaychuyen.TabIndex = 0
        '
        'clChonDaychuyen
        '
        Me.clChonDaychuyen.HeaderText = "Chọn"
        Me.clChonDaychuyen.MinimumWidth = 50
        Me.clChonDaychuyen.Name = "clChonDaychuyen"
        Me.clChonDaychuyen.Width = 50
        '
        'clMsDaychuyen
        '
        Me.clMsDaychuyen.HeaderText = ""
        Me.clMsDaychuyen.Name = "clMsDaychuyen"
        Me.clMsDaychuyen.ReadOnly = True
        Me.clMsDaychuyen.Visible = False
        '
        'clDaychuyen
        '
        Me.clDaychuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clDaychuyen.HeaderText = "Dây chuyền"
        Me.clDaychuyen.Name = "clDaychuyen"
        Me.clDaychuyen.ReadOnly = True
        '
        'gDieuKien
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gDieuKien, 4)
        Me.gDieuKien.Controls.Add(Me.TableLayoutPanel2)
        Me.gDieuKien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gDieuKien.Location = New System.Drawing.Point(3, 3)
        Me.gDieuKien.Name = "gDieuKien"
        Me.gDieuKien.Size = New System.Drawing.Size(604, 48)
        Me.gDieuKien.TabIndex = 5
        Me.gDieuKien.TabStop = False
        Me.gDieuKien.Text = "Điều kiện lọc"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.mskDen, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.labThang, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.labDenthang, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.mskTu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(598, 29)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'mskDen
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.mskDen, 2)
        Me.mskDen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mskDen.Location = New System.Drawing.Point(422, 3)
        Me.mskDen.Mask = "00/0000"
        Me.mskDen.Name = "mskDen"
        Me.mskDen.Size = New System.Drawing.Size(173, 20)
        Me.mskDen.TabIndex = 6
        Me.mskDen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labThang
        '
        Me.labThang.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.labThang, 2)
        Me.labThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labThang.Location = New System.Drawing.Point(3, 0)
        Me.labThang.Name = "labThang"
        Me.labThang.Size = New System.Drawing.Size(114, 29)
        Me.labThang.TabIndex = 2
        Me.labThang.Text = "Từ tháng"
        Me.labThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labDenthang
        '
        Me.labDenthang.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.labDenthang, 2)
        Me.labDenthang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labDenthang.Location = New System.Drawing.Point(302, 0)
        Me.labDenthang.Name = "labDenthang"
        Me.labDenthang.Size = New System.Drawing.Size(114, 29)
        Me.labDenthang.TabIndex = 4
        Me.labDenthang.Text = "Đến tháng"
        Me.labDenthang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnThucHien
        '


        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThucHien.Location = New System.Drawing.Point(411, 3)
        Me.btnThucHien.Name = "btnThucHien"

        Me.btnThucHien.Size = New System.Drawing.Size(90, 22)
        Me.btnThucHien.TabIndex = 6
        Me.btnThucHien.Text = "Thực hiện"


        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nhà xưởng"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = ""
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Loại thiết bị"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 4)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnThoat, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnThucHien, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 468)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(604, 28)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'btnThoat
        '


        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnThoat.Location = New System.Drawing.Point(507, 3)
        
        Me.btnThoat.Name = "btnThoat"

        Me.btnThoat.Size = New System.Drawing.Size(87, 22)
        Me.btnThoat.TabIndex = 34
        Me.btnThoat.Text = "Thoát"


        '
        'frmrptKHA_NANG_SAN_SANG_THEO_THIET_BI_BREAKDOWN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptKHA_NANG_SAN_SANG_THEO_THIET_BI_BREAKDOWN"
        Me.Size = New System.Drawing.Size(610, 499)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.gDaychuyen.ResumeLayout(False)
        CType(Me.gvDaychuyen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDieuKien.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mskTu As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents mskDen As System.Windows.Forms.MaskedTextBox
    Friend WithEvents labThang As System.Windows.Forms.Label
    Friend WithEvents labDenthang As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gDaychuyen As System.Windows.Forms.GroupBox
    Friend WithEvents gvDaychuyen As System.Windows.Forms.DataGridView
    Friend WithEvents clChonDaychuyen As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clMsDaychuyen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clDaychuyen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gDieuKien As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton

End Class
