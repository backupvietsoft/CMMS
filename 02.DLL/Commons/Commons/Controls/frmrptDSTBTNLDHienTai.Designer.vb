﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDSTBTNLDHienTai
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
        Me.lblNhaxuong = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboNhaxuong = New MVControl.ucComboboxTreeList()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNhaxuong
        '
        Me.lblNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaxuong.Location = New System.Drawing.Point(123, 15)
        Me.lblNhaxuong.Name = "lblNhaxuong"
        Me.lblNhaxuong.Size = New System.Drawing.Size(90, 25)
        Me.lblNhaxuong.TabIndex = 2
        Me.lblNhaxuong.Text = "Nơi sử dụng"
        Me.lblNhaxuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblNhaxuong, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNhaxuong, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(801, 574)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'cboNhaxuong
        '
        Me.cboNhaxuong.ColumnDisplayName = Nothing
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboNhaxuong, 3)
        Me.cboNhaxuong.DataSource = Nothing
        Me.cboNhaxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaxuong.EditValue = Nothing
        Me.cboNhaxuong.KeyFieldName = Nothing
        Me.cboNhaxuong.Location = New System.Drawing.Point(219, 18)
        Me.cboNhaxuong.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cboNhaxuong.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cboNhaxuong.Name = "cboNhaxuong"
        Me.cboNhaxuong.ParentFieldName = Nothing
        Me.cboNhaxuong.SelectedIndex = 0
        Me.cboNhaxuong.Size = New System.Drawing.Size(458, 20)
        Me.cboNhaxuong.TabIndex = 6
        Me.cboNhaxuong.TextValue = Nothing
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 535)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(795, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(578, 3)
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 19
        Me.btnThucHien.Text = "Thực hiện"
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(688, 3)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        '
        'frmrptDSTBTNLDHienTai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmrptDSTBTNLDHienTai"
        Me.Size = New System.Drawing.Size(801, 574)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNhaxuong As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboNhaxuong As MVControl.ucComboboxTreeList
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel

End Class
