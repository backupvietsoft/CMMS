<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLuanChuyenVatTu
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
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridExport = New DevExpress.XtraGrid.GridControl()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdBoChon = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.gridThietBi = New DevExpress.XtraGrid.GridControl()
        Me.GridViewTB = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblTuNgay = New DevExpress.XtraEditors.LabelControl()
        Me.lblDenNgay = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTuNgay = New DevExpress.XtraEditors.DateEdit()
        Me.cmbDenNgay = New DevExpress.XtraEditors.DateEdit()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gridThietBi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        CType(Me.cmbTuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTuNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDenNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridExport
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridExport
        '
        Me.GridExport.Location = New System.Drawing.Point(826, 18)
        Me.GridExport.MainView = Me.GridView1
        Me.GridExport.Name = "GridExport"
        Me.GridExport.Size = New System.Drawing.Size(54, 19)
        Me.GridExport.TabIndex = 6
        Me.GridExport.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridExport.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThucHien, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThoat, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdTatCa, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdBoChon, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(967, 36)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'cmdThucHien
        '
        Me.cmdThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThucHien.Image = Global.MReportVB.My.Resources.Resources.btnthuchien
        Me.cmdThucHien.Location = New System.Drawing.Point(750, 3)
        Me.cmdThucHien.LookAndFeel.SkinName = "Blue"
        Me.cmdThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThucHien.Name = "cmdThucHien"
        Me.cmdThucHien.Size = New System.Drawing.Size(104, 30)
        Me.cmdThucHien.TabIndex = 0
        Me.cmdThucHien.Text = "SimpleButton1"
        '
        'cmdThoat
        '
        Me.cmdThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThoat.Image = Global.MReportVB.My.Resources.Resources.btnthoat
        Me.cmdThoat.Location = New System.Drawing.Point(860, 3)
        Me.cmdThoat.LookAndFeel.SkinName = "Blue"
        Me.cmdThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(104, 30)
        Me.cmdThoat.TabIndex = 1
        Me.cmdThoat.Text = "SimpleButton2"
        '
        'cmdTatCa
        '
        Me.cmdTatCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdTatCa.Image = Global.MReportVB.My.Resources.Resources.btnall
        Me.cmdTatCa.Location = New System.Drawing.Point(3, 3)
        Me.cmdTatCa.LookAndFeel.SkinName = "Blue"
        Me.cmdTatCa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdTatCa.Name = "cmdTatCa"
        Me.cmdTatCa.Size = New System.Drawing.Size(104, 30)
        Me.cmdTatCa.TabIndex = 2
        Me.cmdTatCa.Text = "SimpleButton1"
        '
        'cmdBoChon
        '
        Me.cmdBoChon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdBoChon.Image = Global.MReportVB.My.Resources.Resources.btnuncheckall
        Me.cmdBoChon.Location = New System.Drawing.Point(113, 3)
        Me.cmdBoChon.LookAndFeel.SkinName = "Blue"
        Me.cmdBoChon.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdBoChon.Name = "cmdBoChon"
        Me.cmdBoChon.Size = New System.Drawing.Size(104, 30)
        Me.cmdBoChon.TabIndex = 3
        Me.cmdBoChon.Text = "SimpleButton2"
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
        Me.TableLayoutPanel1.Controls.Add(Me.gridThietBi, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.GridExport, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbTuNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDenNgay, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(973, 597)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'gridThietBi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gridThietBi, 6)
        Me.gridThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridThietBi.Location = New System.Drawing.Point(3, 51)
        Me.gridThietBi.LookAndFeel.SkinName = "Blue"
        Me.gridThietBi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridThietBi.MainView = Me.GridViewTB
        Me.gridThietBi.Name = "gridThietBi"
        Me.gridThietBi.Size = New System.Drawing.Size(967, 501)
        Me.gridThietBi.TabIndex = 7
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
        'Panel8
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel8, 6)
        Me.Panel8.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 558)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(967, 36)
        Me.Panel8.TabIndex = 8
        '
        'lblTuNgay
        '
        Me.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTuNgay.Location = New System.Drawing.Point(148, 22)
        Me.lblTuNgay.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(40, 13)
        Me.lblTuNgay.TabIndex = 10
        Me.lblTuNgay.Text = "Từ ngày"
        '
        'lblDenNgay
        '
        Me.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblDenNgay.Location = New System.Drawing.Point(487, 22)
        Me.lblDenNgay.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblDenNgay.Name = "lblDenNgay"
        Me.lblDenNgay.Size = New System.Drawing.Size(47, 13)
        Me.lblDenNgay.TabIndex = 11
        Me.lblDenNgay.Text = "Đến ngày"
        '
        'cmbTuNgay
        '
        Me.cmbTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbTuNgay.EditValue = Nothing
        Me.cmbTuNgay.Location = New System.Drawing.Point(264, 18)
        Me.cmbTuNgay.Name = "cmbTuNgay"
        Me.cmbTuNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.cmbTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cmbTuNgay.Size = New System.Drawing.Size(217, 20)
        Me.cmbTuNgay.TabIndex = 12
        '
        'cmbDenNgay
        '
        Me.cmbDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDenNgay.EditValue = Nothing
        Me.cmbDenNgay.Location = New System.Drawing.Point(603, 18)
        Me.cmbDenNgay.Name = "cmbDenNgay"
        Me.cmbDenNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.cmbDenNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cmbDenNgay.Size = New System.Drawing.Size(217, 20)
        Me.cmbDenNgay.TabIndex = 13
        '
        'ucLuanChuyenVatTu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "ucLuanChuyenVatTu"
        Me.Size = New System.Drawing.Size(973, 597)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.gridThietBi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        CType(Me.cmbTuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTuNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDenNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdBoChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gridThietBi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTB As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridExport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblTuNgay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDenNgay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTuNgay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmbDenNgay As DevExpress.XtraEditors.DateEdit

End Class
