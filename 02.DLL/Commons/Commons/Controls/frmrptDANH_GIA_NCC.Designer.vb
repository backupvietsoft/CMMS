﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDANH_GIA_NCC
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
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDenngay = New System.Windows.Forms.Label()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNhacungcap = New System.Windows.Forms.Label()
        Me.cboNCC = New System.Windows.Forms.ComboBox()
        Me.dtTuNgay_Kho = New System.Windows.Forms.DateTimePicker()
        Me.dtDenNgay_Kho = New System.Windows.Forms.DateTimePicker()
        Me.lblTungay = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdKH = New DevExpress.XtraGrid.GridControl()
        Me.grvKH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.grdKH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvKH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(308, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 25)
        Me.btnThoat.TabIndex = 35
        Me.btnThoat.Text = "Thoát"
        '
        'lblDenngay
        '
        Me.lblDenngay.AutoSize = True
        Me.lblDenngay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblDenngay.Location = New System.Drawing.Point(212, 0)
        Me.lblDenngay.Name = "lblDenngay"
        Me.lblDenngay.Size = New System.Drawing.Size(31, 31)
        Me.lblDenngay.TabIndex = 34
        Me.lblDenngay.Text = "Đến ngày"
        Me.lblDenngay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(198, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 25)
        Me.btnThucHien.TabIndex = 20
        Me.btnThucHien.Text = "Thực hiện"
        '
        'lblNhacungcap
        '
        Me.lblNhacungcap.AutoSize = True
        Me.lblNhacungcap.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblNhacungcap.Location = New System.Drawing.Point(66, 31)
        Me.lblNhacungcap.Name = "lblNhacungcap"
        Me.lblNhacungcap.Size = New System.Drawing.Size(33, 31)
        Me.lblNhacungcap.TabIndex = 29
        Me.lblNhacungcap.Text = "Nhà cung cấp"
        Me.lblNhacungcap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNCC
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboNCC, 3)
        Me.cboNCC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNCC.FormattingEnabled = True
        Me.cboNCC.Location = New System.Drawing.Point(116, 34)
        Me.cboNCC.Name = "cboNCC"
        Me.cboNCC.Size = New System.Drawing.Size(236, 21)
        Me.cboNCC.TabIndex = 30
        '
        'dtTuNgay_Kho
        '
        Me.dtTuNgay_Kho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTuNgay_Kho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTuNgay_Kho.Location = New System.Drawing.Point(116, 3)
        Me.dtTuNgay_Kho.Name = "dtTuNgay_Kho"
        Me.dtTuNgay_Kho.Size = New System.Drawing.Size(90, 21)
        Me.dtTuNgay_Kho.TabIndex = 31
        '
        'dtDenNgay_Kho
        '
        Me.dtDenNgay_Kho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDenNgay_Kho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDenNgay_Kho.Location = New System.Drawing.Point(262, 3)
        Me.dtDenNgay_Kho.Name = "dtDenNgay_Kho"
        Me.dtDenNgay_Kho.Size = New System.Drawing.Size(90, 21)
        Me.dtDenNgay_Kho.TabIndex = 32
        '
        'lblTungay
        '
        Me.lblTungay.AutoSize = True
        Me.lblTungay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTungay.Location = New System.Drawing.Point(66, 0)
        Me.lblTungay.Name = "lblTungay"
        Me.lblTungay.Size = New System.Drawing.Size(31, 31)
        Me.lblTungay.TabIndex = 33
        Me.lblTungay.Text = "Từ ngày"
        Me.lblTungay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.grdChung, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTungay, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDenngay, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboNCC, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dtTuNgay_Kho, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNhacungcap, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dtDenNgay_Kho, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.grdKH, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(421, 387)
        Me.TableLayoutPanel2.TabIndex = 21
        '
        'grdChung
        '
        Me.grdChung.Location = New System.Drawing.Point(3, 3)
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(53, 25)
        Me.grdChung.TabIndex = 39
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel3, 6)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 353)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(415, 31)
        Me.TableLayoutPanel3.TabIndex = 35
        '
        'grdKH
        '
        Me.grdKH.Location = New System.Drawing.Point(3, 34)
        Me.grdKH.MainView = Me.grvKH
        Me.grdKH.Name = "grdKH"
        Me.grdKH.Size = New System.Drawing.Size(53, 25)
        Me.grdKH.TabIndex = 39
        Me.grdKH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvKH})
        Me.grdKH.Visible = False
        '
        'grvKH
        '
        Me.grvKH.GridControl = Me.grdKH
        Me.grvKH.Name = "grvKH"
        '
        'frmrptDANH_GIA_NCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "frmrptDANH_GIA_NCC"
        Me.Size = New System.Drawing.Size(421, 387)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.grdKH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvKH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNhacungcap As System.Windows.Forms.Label
    Friend WithEvents cboNCC As System.Windows.Forms.ComboBox
    Friend WithEvents dtTuNgay_Kho As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenngay As System.Windows.Forms.Label
    Friend WithEvents dtDenNgay_Kho As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTungay As System.Windows.Forms.Label
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdKH As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvKH As DevExpress.XtraGrid.Views.Grid.GridView
End Class
