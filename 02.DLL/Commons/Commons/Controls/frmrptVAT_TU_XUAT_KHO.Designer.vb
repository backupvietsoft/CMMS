<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptVAT_TU_XUAT_KHO
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
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grbDangxuat = New System.Windows.Forms.GroupBox()
        Me.grdDangxuat = New DevExpress.XtraGrid.GridControl()
        Me.grvDangxuat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lbaKho = New System.Windows.Forms.Label()
        Me.lbadenNgay = New System.Windows.Forms.Label()
        Me.lbatuNgay = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboBPCP = New DevExpress.XtraEditors.LookUpEdit()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.prbIN = New DevExpress.XtraEditors.ProgressBarControl()
        Me.datTNgay = New DevExpress.XtraEditors.DateEdit()
        Me.datDNgay = New DevExpress.XtraEditors.DateEdit()
        Me.cboKho = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblBPCP = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbDangxuat.SuspendLayout()
        CType(Me.grdDangxuat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvDangxuat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cboBPCP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datTNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Chọn"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 110
        '
        'grbDangxuat
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grbDangxuat, 6)
        Me.grbDangxuat.Controls.Add(Me.grdDangxuat)
        Me.grbDangxuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbDangxuat.Location = New System.Drawing.Point(3, 106)
        Me.grbDangxuat.Name = "grbDangxuat"
        Me.grbDangxuat.Size = New System.Drawing.Size(835, 325)
        Me.grbDangxuat.TabIndex = 23
        Me.grbDangxuat.TabStop = False
        Me.grbDangxuat.Text = "Dạng xuất"
        '
        'grdDangxuat
        '
        Me.grdDangxuat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDangxuat.Location = New System.Drawing.Point(3, 17)
        Me.grdDangxuat.LookAndFeel.SkinName = "Blue"
        Me.grdDangxuat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdDangxuat.MainView = Me.grvDangxuat
        Me.grdDangxuat.Name = "grdDangxuat"
        Me.grdDangxuat.Size = New System.Drawing.Size(829, 305)
        Me.grdDangxuat.TabIndex = 16
        Me.grdDangxuat.Tag = ""
        Me.grdDangxuat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDangxuat, Me.GridView4})
        '
        'grvDangxuat
        '
        Me.grvDangxuat.GridControl = Me.grdDangxuat
        Me.grvDangxuat.Name = "grvDangxuat"
        Me.grvDangxuat.OptionsLayout.Columns.StoreAllOptions = True
        Me.grvDangxuat.OptionsLayout.StoreAllOptions = True
        Me.grvDangxuat.OptionsView.ColumnAutoWidth = False
        Me.grvDangxuat.OptionsView.ShowGroupPanel = False
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdDangxuat
        Me.GridView4.Name = "GridView4"
        '
        'lbaKho
        '
        Me.lbaKho.AutoSize = True
        Me.lbaKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbaKho.Location = New System.Drawing.Point(129, 45)
        Me.lbaKho.Name = "lbaKho"
        Me.lbaKho.Size = New System.Drawing.Size(94, 25)
        Me.lbaKho.TabIndex = 18
        Me.lbaKho.Text = "Kho"
        Me.lbaKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbadenNgay
        '
        Me.lbadenNgay.AutoSize = True
        Me.lbadenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbadenNgay.Location = New System.Drawing.Point(422, 20)
        Me.lbadenNgay.Name = "lbadenNgay"
        Me.lbadenNgay.Size = New System.Drawing.Size(94, 25)
        Me.lbadenNgay.TabIndex = 19
        Me.lbadenNgay.Text = "Đến ngày"
        Me.lbadenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbatuNgay
        '
        Me.lbatuNgay.AutoSize = True
        Me.lbatuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbatuNgay.Location = New System.Drawing.Point(129, 20)
        Me.lbatuNgay.Name = "lbatuNgay"
        Me.lbatuNgay.Size = New System.Drawing.Size(94, 25)
        Me.lbatuNgay.TabIndex = 17
        Me.lbatuNgay.Text = "Từ ngày"
        Me.lbatuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.cboBPCP, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.grdChung, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grbDangxuat, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lbatuNgay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbadenNgay, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbaKho, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GridControl1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.prbIN, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.datTNgay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.datDNgay, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboKho, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBPCP, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(841, 500)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'cboBPCP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboBPCP, 3)
        Me.cboBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboBPCP.EditValue = ""
        Me.cboBPCP.Location = New System.Drawing.Point(229, 73)
        Me.cboBPCP.Name = "cboBPCP"
        Me.cboBPCP.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboBPCP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBPCP.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboBPCP.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboBPCP.Properties.NullText = ""
        Me.cboBPCP.Size = New System.Drawing.Size(480, 20)
        Me.cboBPCP.TabIndex = 39
        '
        'grdChung
        '
        Me.grdChung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChung.Location = New System.Drawing.Point(3, 3)
        Me.grdChung.LookAndFeel.SkinName = "Blue"
        Me.grdChung.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(120, 14)
        Me.grdChung.TabIndex = 99
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        Me.grvChung.OptionsView.ShowGroupPanel = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnExport, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 461)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(835, 36)
        Me.TableLayoutPanel2.TabIndex = 25
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(728, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 36
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(618, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 24
        Me.btnThucHien.Text = "Thực hiện"
        '
        'btnExport
        '
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExport.Location = New System.Drawing.Point(508, 3)
        Me.btnExport.LookAndFeel.SkinName = "Blue"
        Me.btnExport.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(104, 30)
        Me.btnExport.TabIndex = 38
        Me.btnExport.Text = "Export ERP"
        Me.btnExport.Visible = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(3, 23)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(120, 19)
        Me.GridControl1.TabIndex = 99
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridControl1.Visible = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'prbIN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.prbIN, 6)
        Me.prbIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prbIN.Location = New System.Drawing.Point(3, 437)
        Me.prbIN.Name = "prbIN"
        Me.prbIN.Properties.LookAndFeel.SkinName = "Blue"
        Me.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.prbIN.Size = New System.Drawing.Size(835, 18)
        Me.prbIN.TabIndex = 100
        '
        'datTNgay
        '
        Me.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datTNgay.EditValue = Nothing
        Me.datTNgay.Location = New System.Drawing.Point(229, 23)
        Me.datTNgay.Name = "datTNgay"
        Me.datTNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datTNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.datTNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.datTNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datTNgay.Size = New System.Drawing.Size(187, 20)
        Me.datTNgay.TabIndex = 40
        '
        'datDNgay
        '
        Me.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datDNgay.EditValue = Nothing
        Me.datDNgay.Location = New System.Drawing.Point(522, 23)
        Me.datDNgay.Name = "datDNgay"
        Me.datDNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datDNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.datDNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.datDNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datDNgay.Size = New System.Drawing.Size(187, 20)
        Me.datDNgay.TabIndex = 40
        '
        'cboKho
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboKho, 3)
        Me.cboKho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboKho.EditValue = ""
        Me.cboKho.Location = New System.Drawing.Point(229, 48)
        Me.cboKho.Name = "cboKho"
        Me.cboKho.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboKho.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboKho.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboKho.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboKho.Properties.NullText = ""
        Me.cboKho.Size = New System.Drawing.Size(480, 20)
        Me.cboKho.TabIndex = 39
        '
        'lblBPCP
        '
        Me.lblBPCP.AutoSize = True
        Me.lblBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBPCP.Location = New System.Drawing.Point(129, 70)
        Me.lblBPCP.Name = "lblBPCP"
        Me.lblBPCP.Size = New System.Drawing.Size(94, 25)
        Me.lblBPCP.TabIndex = 18
        Me.lblBPCP.Text = "lblBPCP"
        Me.lblBPCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Dạng xuất"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 109
        '
        'frmrptVAT_TU_XUAT_KHO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptVAT_TU_XUAT_KHO"
        Me.Size = New System.Drawing.Size(841, 500)
        Me.grbDangxuat.ResumeLayout(False)
        CType(Me.grdDangxuat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvDangxuat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.cboBPCP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datTNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datTNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents grbDangxuat As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbaKho As System.Windows.Forms.Label
    Friend WithEvents lbadenNgay As System.Windows.Forms.Label
    Friend WithEvents lbatuNgay As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdDangxuat As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvDangxuat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents prbIN As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents datTNgay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboKho As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboBPCP As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents datDNgay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblBPCP As Windows.Forms.Label
End Class
