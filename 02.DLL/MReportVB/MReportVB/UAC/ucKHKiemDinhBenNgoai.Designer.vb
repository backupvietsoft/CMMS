<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucKHKiemDinhBenNgoai
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
        Me.cmbNam = New ReportMain.MMonthYearEdit()
        Me.lblNam = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLoaiVT = New DevExpress.XtraEditors.LabelControl()
        Me.cmbLoaiVT = New DevExpress.XtraEditors.LookUpEdit()
        Me.gridThietBi = New DevExpress.XtraGrid.GridControl()
        Me.GridViewTB = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdBoChon = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lblMSMay = New DevExpress.XtraEditors.LabelControl()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtMSMay = New DevExpress.XtraEditors.TextEdit()
        Me.GridExport = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbLoaiMay = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblLoaiMay = New DevExpress.XtraEditors.LabelControl()
        Me.lblThietBi = New DevExpress.XtraEditors.LabelControl()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.cmbNam.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbNam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cmbLoaiVT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridThietBi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.txtMSMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLoaiMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbNam
        '
        Me.cmbNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbNam.EditValue = Nothing
        Me.cmbNam.Location = New System.Drawing.Point(239, 11)
        Me.cmbNam.MMonthYear = False
        Me.cmbNam.Name = "cmbNam"
        Me.cmbNam.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmbNam.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbNam.Properties.DisplayFormat.FormatString = "yyyy"
        Me.cmbNam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cmbNam.Properties.EditFormat.FormatString = "yyyy"
        Me.cmbNam.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cmbNam.Properties.LookAndFeel.SkinName = "Blue"
        Me.cmbNam.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbNam.Properties.Mask.EditMask = "yyyy"
        Me.cmbNam.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cmbNam.Size = New System.Drawing.Size(195, 20)
        Me.cmbNam.TabIndex = 0
        '
        'lblNam
        '
        Me.lblNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNam.Location = New System.Drawing.Point(134, 11)
        Me.lblNam.Name = "lblNam"
        Me.lblNam.Size = New System.Drawing.Size(21, 13)
        Me.lblNam.TabIndex = 1
        Me.lblNam.Text = "Năm"
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiVT, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbLoaiVT, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.gridThietBi, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.GridExport, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbNam, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbLoaiMay, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiMay, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNam, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblThietBi, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(878, 520)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lblLoaiVT
        '
        Me.lblLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiVT.Location = New System.Drawing.Point(440, 36)
        Me.lblLoaiVT.Name = "lblLoaiVT"
        Me.lblLoaiVT.Size = New System.Drawing.Size(34, 13)
        Me.lblLoaiVT.TabIndex = 0
        Me.lblLoaiVT.Text = "Loại VT"
        '
        'cmbLoaiVT
        '
        Me.cmbLoaiVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLoaiVT.Location = New System.Drawing.Point(545, 36)
        Me.cmbLoaiVT.Name = "cmbLoaiVT"
        Me.cmbLoaiVT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbLoaiVT.Properties.LookAndFeel.SkinName = "Blue"
        Me.cmbLoaiVT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbLoaiVT.Size = New System.Drawing.Size(195, 20)
        Me.cmbLoaiVT.TabIndex = 0
        '
        'gridThietBi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gridThietBi, 6)
        Me.gridThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridThietBi.Location = New System.Drawing.Point(3, 86)
        Me.gridThietBi.LookAndFeel.SkinName = "Blue"
        Me.gridThietBi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridThietBi.MainView = Me.GridViewTB
        Me.gridThietBi.Name = "gridThietBi"
        Me.gridThietBi.Size = New System.Drawing.Size(872, 389)
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
        Me.Panel8.Location = New System.Drawing.Point(3, 481)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(872, 36)
        Me.Panel8.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThucHien, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThoat, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdTatCa, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdBoChon, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel9, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel10, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(872, 36)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'cmdThucHien
        '
        Me.cmdThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThucHien.Image = Global.MReportVB.My.Resources.Resources.btnthuchien
        Me.cmdThucHien.Location = New System.Drawing.Point(693, 3)
        Me.cmdThucHien.LookAndFeel.SkinName = "Blue"
        Me.cmdThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThucHien.Name = "cmdThucHien"
        Me.cmdThucHien.Size = New System.Drawing.Size(84, 30)
        Me.cmdThucHien.TabIndex = 0
        Me.cmdThucHien.Text = "SimpleButton1"
        '
        'cmdThoat
        '
        Me.cmdThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThoat.Image = Global.MReportVB.My.Resources.Resources.btnthoat
        Me.cmdThoat.Location = New System.Drawing.Point(783, 3)
        Me.cmdThoat.LookAndFeel.SkinName = "Blue"
        Me.cmdThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(86, 30)
        Me.cmdThoat.TabIndex = 1
        Me.cmdThoat.Text = "SimpleButton2"
        '
        'cmdTatCa
        '
        Me.cmdTatCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdTatCa.Image = Global.MReportVB.My.Resources.Resources.btnall
        Me.cmdTatCa.Location = New System.Drawing.Point(349, 3)
        Me.cmdTatCa.LookAndFeel.SkinName = "Blue"
        Me.cmdTatCa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdTatCa.Name = "cmdTatCa"
        Me.cmdTatCa.Size = New System.Drawing.Size(84, 30)
        Me.cmdTatCa.TabIndex = 2
        Me.cmdTatCa.Text = "SimpleButton1"
        '
        'cmdBoChon
        '
        Me.cmdBoChon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdBoChon.Image = Global.MReportVB.My.Resources.Resources.btnuncheckall
        Me.cmdBoChon.Location = New System.Drawing.Point(439, 3)
        Me.cmdBoChon.LookAndFeel.SkinName = "Blue"
        Me.cmdBoChon.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdBoChon.Name = "cmdBoChon"
        Me.cmdBoChon.Size = New System.Drawing.Size(84, 30)
        Me.cmdBoChon.TabIndex = 3
        Me.cmdBoChon.Text = "SimpleButton2"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.lblMSMay)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(44, 30)
        Me.Panel9.TabIndex = 4
        '
        'lblMSMay
        '
        Me.lblMSMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMSMay.Location = New System.Drawing.Point(0, 0)
        Me.lblMSMay.Name = "lblMSMay"
        Me.lblMSMay.Size = New System.Drawing.Size(51, 13)
        Me.lblMSMay.TabIndex = 0
        Me.lblMSMay.Text = "Mã số máy"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.txtMSMay)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(53, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(290, 30)
        Me.Panel10.TabIndex = 5
        '
        'txtMSMay
        '
        Me.txtMSMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMSMay.Location = New System.Drawing.Point(0, 0)
        Me.txtMSMay.Name = "txtMSMay"
        Me.txtMSMay.Size = New System.Drawing.Size(290, 20)
        Me.txtMSMay.TabIndex = 0
        '
        'GridExport
        '
        Me.GridExport.Location = New System.Drawing.Point(746, 11)
        Me.GridExport.MainView = Me.GridView1
        Me.GridExport.Name = "GridExport"
        Me.GridExport.Size = New System.Drawing.Size(54, 19)
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
        'cmbLoaiMay
        '
        Me.cmbLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLoaiMay.Location = New System.Drawing.Point(239, 36)
        Me.cmbLoaiMay.Name = "cmbLoaiMay"
        Me.cmbLoaiMay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbLoaiMay.Properties.LookAndFeel.SkinName = "Blue"
        Me.cmbLoaiMay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbLoaiMay.Size = New System.Drawing.Size(195, 20)
        Me.cmbLoaiMay.TabIndex = 0
        '
        'lblLoaiMay
        '
        Me.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiMay.Location = New System.Drawing.Point(134, 36)
        Me.lblLoaiMay.Name = "lblLoaiMay"
        Me.lblLoaiMay.Size = New System.Drawing.Size(42, 13)
        Me.lblLoaiMay.TabIndex = 0
        Me.lblLoaiMay.Text = "Loại máy"
        '
        'lblThietBi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblThietBi, 2)
        Me.lblThietBi.Location = New System.Drawing.Point(3, 61)
        Me.lblThietBi.Name = "lblThietBi"
        Me.lblThietBi.Size = New System.Drawing.Size(35, 13)
        Me.lblThietBi.TabIndex = 7
        Me.lblThietBi.Text = "Thiết bị"
        '
        'ucKHKiemDinhBenNgoai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "ucKHKiemDinhBenNgoai"
        Me.Size = New System.Drawing.Size(878, 520)
        CType(Me.cmbNam.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbNam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.cmbLoaiVT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridThietBi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        CType(Me.txtMSMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLoaiMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbNam As ReportMain.MMonthYearEdit 'DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblNam As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLoaiMay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLoaiVT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbLoaiMay As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmbLoaiVT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblThietBi As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gridThietBi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTB As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdBoChon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents lblMSMay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents txtMSMay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridExport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
