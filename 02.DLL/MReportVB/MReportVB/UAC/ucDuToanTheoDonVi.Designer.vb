<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDuToanTheoDonVi
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
        Me.cmbThang = New DevExpress.XtraEditors.DateEdit()
        Me.cmbDonVi = New DevExpress.XtraEditors.LookUpEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNam = New DevExpress.XtraEditors.LabelControl()
        Me.lblDonVi = New DevExpress.XtraEditors.LabelControl()
        Me.GridExport = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.cmbThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbThang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDonVi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbThang
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbThang, 3)
        Me.cmbThang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbThang.EditValue = Nothing
        Me.cmbThang.Location = New System.Drawing.Point(139, 18)
        Me.cmbThang.Name = "cmbThang"
        Me.cmbThang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
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
        Me.cmbThang.TabIndex = 0
        '
        'cmbDonVi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbDonVi, 3)
        Me.cmbDonVi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDonVi.Location = New System.Drawing.Point(139, 43)
        Me.cmbDonVi.Name = "cmbDonVi"
        Me.cmbDonVi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbDonVi.Properties.LookAndFeel.SkinName = "Blue"
        Me.cmbDonVi.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbDonVi.Size = New System.Drawing.Size(394, 20)
        Me.cmbDonVi.TabIndex = 0
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
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNam, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDonVi, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GridExport, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbThang, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDonVi, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(573, 369)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Panel8
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel8, 6)
        Me.Panel8.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 330)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(567, 36)
        Me.Panel8.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThucHien, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdThoat, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(567, 36)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'cmdThucHien
        '
        Me.cmdThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdThucHien.Image = Global.MReportVB.My.Resources.Resources.btnthuchien
        Me.cmdThucHien.Location = New System.Drawing.Point(350, 3)
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
        Me.cmdThoat.Location = New System.Drawing.Point(460, 3)
        Me.cmdThoat.LookAndFeel.SkinName = "Blue"
        Me.cmdThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(104, 30)
        Me.cmdThoat.TabIndex = 1
        Me.cmdThoat.Text = "SimpleButton2"
        '
        'lblNam
        '
        Me.lblNam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNam.Location = New System.Drawing.Point(39, 18)
        Me.lblNam.Name = "lblNam"
        Me.lblNam.Size = New System.Drawing.Size(94, 19)
        Me.lblNam.TabIndex = 1
        Me.lblNam.Text = "Tháng"
        '
        'lblDonVi
        '
        Me.lblDonVi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDonVi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDonVi.Location = New System.Drawing.Point(39, 43)
        Me.lblDonVi.Name = "lblDonVi"
        Me.lblDonVi.Size = New System.Drawing.Size(94, 19)
        Me.lblDonVi.TabIndex = 0
        Me.lblDonVi.Text = "Đơn vị"
        '
        'GridExport
        '
        Me.GridExport.Location = New System.Drawing.Point(539, 18)
        Me.GridExport.MainView = Me.GridView1
        Me.GridExport.Name = "GridExport"
        Me.GridExport.Size = New System.Drawing.Size(31, 19)
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
        'ucDuToanTheoDonVi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "ucDuToanTheoDonVi"
        Me.Size = New System.Drawing.Size(573, 369)
        CType(Me.cmbThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbThang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDonVi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GridExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbThang As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbDonVi As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNam As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDonVi As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridExport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView

End Class
