<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBangKeCTNhapKho
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdBoChon = New DevExpress.XtraEditors.SimpleButton()
        Me.txtMSMay = New DevExpress.XtraEditors.TextEdit()
        Me.lblLoaiVatTu = New DevExpress.XtraEditors.LabelControl()
        Me.lblThang = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbThang = New DevExpress.XtraEditors.DateEdit()
        Me.gridThietBi = New DevExpress.XtraGrid.GridControl()
        Me.GridViewTB = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblKho = New DevExpress.XtraEditors.LabelControl()
        Me.lblLoaiVT = New DevExpress.XtraEditors.LabelControl()
        Me.GridExport = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbKho = New DevExpress.XtraEditors.LookUpEdit()
        Me.Panel8.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtMSMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cmbThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbThang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridThietBi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbKho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel8
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel8, 6)
        Me.Panel8.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 354)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(751, 34)
        Me.Panel8.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThucHien, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThoat, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdTatCa, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdBoChon, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMSMay, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblLoaiVatTu, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(751, 34)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'cmdThucHien
        '
        Me.cmdThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThucHien.Image = Global.MReportVB.My.Resources.Resources.btnthuchien
        Me.cmdThucHien.Location = New System.Drawing.Point(554, 3)
        Me.cmdThucHien.LookAndFeel.SkinName = "Blue"
        Me.cmdThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThucHien.Name = "cmdThucHien"
        Me.cmdThucHien.Size = New System.Drawing.Size(94, 28)
        Me.cmdThucHien.TabIndex = 7
        Me.cmdThucHien.Text = "SimpleButton1"
        '
        'cmdThoat
        '
        Me.cmdThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThoat.Image = Global.MReportVB.My.Resources.Resources.btnthoat
        Me.cmdThoat.Location = New System.Drawing.Point(654, 3)
        Me.cmdThoat.LookAndFeel.SkinName = "Blue"
        Me.cmdThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(94, 28)
        Me.cmdThoat.TabIndex = 8
        Me.cmdThoat.Text = "SimpleButton2"
        '
        'cmdTatCa
        '
        Me.cmdTatCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdTatCa.Image = Global.MReportVB.My.Resources.Resources.btnall
        Me.cmdTatCa.Location = New System.Drawing.Point(203, 3)
        Me.cmdTatCa.LookAndFeel.SkinName = "Blue"
        Me.cmdTatCa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdTatCa.Name = "cmdTatCa"
        Me.cmdTatCa.Size = New System.Drawing.Size(94, 28)
        Me.cmdTatCa.TabIndex = 5
        Me.cmdTatCa.Text = "SimpleButton1"
        '
        'cmdBoChon
        '
        Me.cmdBoChon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdBoChon.Image = Global.MReportVB.My.Resources.Resources.btnuncheckall
        Me.cmdBoChon.Location = New System.Drawing.Point(303, 3)
        Me.cmdBoChon.LookAndFeel.SkinName = "Blue"
        Me.cmdBoChon.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdBoChon.Name = "cmdBoChon"
        Me.cmdBoChon.Size = New System.Drawing.Size(94, 28)
        Me.cmdBoChon.TabIndex = 6
        Me.cmdBoChon.Text = "SimpleButton2"
        '
        'txtMSMay
        '
        Me.txtMSMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMSMay.Location = New System.Drawing.Point(84, 8)
        Me.txtMSMay.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.txtMSMay.Name = "txtMSMay"
        Me.txtMSMay.Size = New System.Drawing.Size(113, 20)
        Me.txtMSMay.TabIndex = 4
        '
        'lblLoaiVatTu
        '
        Me.lblLoaiVatTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiVatTu.Location = New System.Drawing.Point(3, 11)
        Me.lblLoaiVatTu.Margin = New System.Windows.Forms.Padding(3, 11, 3, 3)
        Me.lblLoaiVatTu.Name = "lblLoaiVatTu"
        Me.lblLoaiVatTu.Size = New System.Drawing.Size(34, 13)
        Me.lblLoaiVatTu.TabIndex = 0
        Me.lblLoaiVatTu.Text = "Loại VT"
        '
        'lblThang
        '
        Me.lblThang.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblThang.Location = New System.Drawing.Point(131, 11)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(94, 20)
        Me.lblThang.TabIndex = 1
        Me.lblThang.Text = "Tháng"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmbThang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.gridThietBi, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblThang, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblKho, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiVT, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GridExport, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbKho, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(757, 391)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'cmbThang
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbThang, 3)
        Me.cmbThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbThang.EditValue = Nothing
        Me.cmbThang.Location = New System.Drawing.Point(231, 11)
        Me.cmbThang.Name = "cmbThang"
        Me.cmbThang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbThang.Properties.DisplayFormat.FormatString = "MM/yyyy"
        Me.cmbThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cmbThang.Properties.EditFormat.FormatString = "MM/yyyy"
        Me.cmbThang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cmbThang.Properties.LookAndFeel.SkinName = "Blue"
        Me.cmbThang.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbThang.Properties.Mask.EditMask = "MM/yyyy"
        Me.cmbThang.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cmbThang.Size = New System.Drawing.Size(394, 20)
        Me.cmbThang.TabIndex = 10
        '
        'gridThietBi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gridThietBi, 6)
        Me.gridThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridThietBi.Location = New System.Drawing.Point(3, 89)
        Me.gridThietBi.LookAndFeel.SkinName = "Blue"
        Me.gridThietBi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridThietBi.MainView = Me.GridViewTB
        Me.gridThietBi.Name = "gridThietBi"
        Me.gridThietBi.Size = New System.Drawing.Size(751, 259)
        Me.gridThietBi.TabIndex = 3
        Me.gridThietBi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTB, Me.GridView2})
        '
        'GridViewTB
        '
        Me.GridViewTB.GridControl = Me.gridThietBi
        Me.GridViewTB.Name = "GridViewTB"
        Me.GridViewTB.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridThietBi
        Me.GridView2.Name = "GridView2"
        '
        'lblKho
        '
        Me.lblKho.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKho.Location = New System.Drawing.Point(131, 37)
        Me.lblKho.Name = "lblKho"
        Me.lblKho.Size = New System.Drawing.Size(94, 20)
        Me.lblKho.TabIndex = 0
        Me.lblKho.Text = "Kho"
        '
        'lblLoaiVT
        '
        Me.lblLoaiVT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiVT.Location = New System.Drawing.Point(3, 63)
        Me.lblLoaiVT.Name = "lblLoaiVT"
        Me.lblLoaiVT.Size = New System.Drawing.Size(122, 20)
        Me.lblLoaiVT.TabIndex = 0
        Me.lblLoaiVT.Text = "Loại VT"
        '
        'GridExport
        '
        Me.GridExport.Location = New System.Drawing.Point(631, 11)
        Me.GridExport.MainView = Me.GridView1
        Me.GridExport.Name = "GridExport"
        Me.GridExport.Size = New System.Drawing.Size(123, 20)
        Me.GridExport.TabIndex = 6
        Me.GridExport.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridExport.Visible = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridExport
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'cmbKho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbKho, 3)
        Me.cmbKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbKho.Location = New System.Drawing.Point(231, 37)
        Me.cmbKho.Name = "cmbKho"
        Me.cmbKho.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbKho.Properties.LookAndFeel.SkinName = "Blue"
        Me.cmbKho.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbKho.Size = New System.Drawing.Size(394, 20)
        Me.cmbKho.TabIndex = 2
        '
        'ucBangKeCTNhapKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "ucBangKeCTNhapKho"
        Me.Size = New System.Drawing.Size(757, 391)
        Me.Panel8.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.txtMSMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.cmbThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbThang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridThietBi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbKho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbKho As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents gridThietBi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTB As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblThang As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblKho As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLoaiVT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridExport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdBoChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtMSMay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblLoaiVatTu As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbThang As DevExpress.XtraEditors.DateEdit

End Class
