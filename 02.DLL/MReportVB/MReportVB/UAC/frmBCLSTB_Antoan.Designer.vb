<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBCLSTB_Antoan
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblDenNgay = New System.Windows.Forms.Label()
        Me.cboDChuyen = New MVControl.ucComboboxTreeList()
        Me.lblDChuyen = New System.Windows.Forms.Label()
        Me.lblNhaXuong = New System.Windows.Forms.Label()
        Me.cboNhaXuong = New MVControl.ucComboboxTreeList()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExcute = New DevExpress.XtraEditors.SimpleButton()
        Me.lblLoaiMay = New System.Windows.Forms.Label()
        Me.cboLoaimay = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblTuNgay = New System.Windows.Forms.Label()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.prbIN = New DevExpress.XtraEditors.ProgressBarControl()
        Me.dtTuNgay = New DevExpress.XtraEditors.DateEdit()
        Me.dtDenNgay = New DevExpress.XtraEditors.DateEdit()
        Me.tableLayoutPanel2.SuspendLayout()
        CType(Me.cboLoaimay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tableLayoutPanel1.SuspendLayout()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTuNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDenNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDenNgay
        '
        Me.lblDenNgay.AutoSize = True
        Me.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNgay.Location = New System.Drawing.Point(377, 16)
        Me.lblDenNgay.Name = "lblDenNgay"
        Me.lblDenNgay.Size = New System.Drawing.Size(84, 25)
        Me.lblDenNgay.TabIndex = 48
        Me.lblDenNgay.Text = "Đến ngày"
        Me.lblDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDChuyen
        '
        Me.cboDChuyen.ColumnDisplayName = Nothing
        Me.cboDChuyen.DataSource = Nothing
        Me.cboDChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDChuyen.EditValue = Nothing
        Me.cboDChuyen.KeyFieldName = Nothing
        Me.cboDChuyen.Location = New System.Drawing.Point(205, 69)
        Me.cboDChuyen.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cboDChuyen.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cboDChuyen.Name = "cboDChuyen"
        Me.cboDChuyen.ParentFieldName = Nothing
        Me.cboDChuyen.ReadOnly = False
        Me.cboDChuyen.SelectedIndex = 0
        Me.cboDChuyen.Size = New System.Drawing.Size(166, 20)
        Me.cboDChuyen.TabIndex = 45
        Me.cboDChuyen.TextValue = Nothing
        '
        'lblDChuyen
        '
        Me.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDChuyen.Location = New System.Drawing.Point(115, 66)
        Me.lblDChuyen.Name = "lblDChuyen"
        Me.lblDChuyen.Size = New System.Drawing.Size(84, 25)
        Me.lblDChuyen.TabIndex = 46
        Me.lblDChuyen.Text = "Dây chuyền"
        Me.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNhaXuong
        '
        Me.lblNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNhaXuong.Location = New System.Drawing.Point(115, 41)
        Me.lblNhaXuong.Name = "lblNhaXuong"
        Me.lblNhaXuong.Size = New System.Drawing.Size(84, 25)
        Me.lblNhaXuong.TabIndex = 34
        Me.lblNhaXuong.Text = "Địa điểm"
        Me.lblNhaXuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNhaXuong
        '
        Me.cboNhaXuong.ColumnDisplayName = Nothing
        Me.cboNhaXuong.DataSource = Nothing
        Me.cboNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNhaXuong.EditValue = Nothing
        Me.cboNhaXuong.KeyFieldName = Nothing
        Me.cboNhaXuong.Location = New System.Drawing.Point(205, 44)
        Me.cboNhaXuong.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cboNhaXuong.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cboNhaXuong.Name = "cboNhaXuong"
        Me.cboNhaXuong.ParentFieldName = Nothing
        Me.cboNhaXuong.ReadOnly = False
        Me.cboNhaXuong.SelectedIndex = 0
        Me.cboNhaXuong.Size = New System.Drawing.Size(166, 20)
        Me.cboNhaXuong.TabIndex = 33
        Me.cboNhaXuong.TextValue = Nothing
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 3
        Me.tableLayoutPanel1.SetColumnSpan(Me.tableLayoutPanel2, 6)
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.tableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.btnExcute, 1, 0)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(3, 295)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 1
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(746, 37)
        Me.tableLayoutPanel2.TabIndex = 36
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(646, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(97, 31)
        Me.btnThoat.TabIndex = 35
        Me.btnThoat.Text = "Thoát"
        '
        'btnExcute
        '
        Me.btnExcute.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcute.Appearance.Options.UseFont = True
        Me.btnExcute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExcute.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnExcute.Location = New System.Drawing.Point(543, 3)
        Me.btnExcute.LookAndFeel.SkinName = "Blue"
        Me.btnExcute.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(97, 31)
        Me.btnExcute.TabIndex = 30
        Me.btnExcute.Text = "Thực hiện"
        '
        'lblLoaiMay
        '
        Me.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiMay.Location = New System.Drawing.Point(377, 41)
        Me.lblLoaiMay.Name = "lblLoaiMay"
        Me.lblLoaiMay.Size = New System.Drawing.Size(84, 25)
        Me.lblLoaiMay.TabIndex = 32
        Me.lblLoaiMay.Text = "Loại máy"
        Me.lblLoaiMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoaimay
        '
        Me.cboLoaimay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaimay.Location = New System.Drawing.Point(467, 44)
        Me.cboLoaimay.Name = "cboLoaimay"
        Me.cboLoaimay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaimay.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLoaimay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLoaimay.Properties.ShowHeader = False
        Me.cboLoaimay.Size = New System.Drawing.Size(166, 20)
        Me.cboLoaimay.TabIndex = 31
        '
        'lblTuNgay
        '
        Me.lblTuNgay.AutoSize = True
        Me.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuNgay.Location = New System.Drawing.Point(115, 16)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(84, 25)
        Me.lblTuNgay.TabIndex = 0
        Me.lblTuNgay.Text = "Từ ngày"
        Me.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdChung
        '
        Me.grdChung.Location = New System.Drawing.Point(3, 3)
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(64, 9)
        Me.grdChung.TabIndex = 99
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung, Me.GridView1})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        Me.grvChung.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdChung
        Me.GridView1.Name = "GridView1"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 6
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.prbIN, 0, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.grdChung, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.lblTuNgay, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.cboLoaimay, 4, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.lblLoaiMay, 3, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.tableLayoutPanel2, 0, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.cboNhaXuong, 2, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.lblNhaXuong, 1, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.lblDChuyen, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.cboDChuyen, 2, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.lblDenNgay, 3, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.dtTuNgay, 2, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.dtDenNgay, 4, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 6
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(752, 335)
        Me.tableLayoutPanel1.TabIndex = 1
        '
        'prbIN
        '
        Me.tableLayoutPanel1.SetColumnSpan(Me.prbIN, 6)
        Me.prbIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prbIN.Location = New System.Drawing.Point(3, 272)
        Me.prbIN.Name = "prbIN"
        Me.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.prbIN.Properties.LookAndFeel.SkinName = "Blue"
        Me.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.prbIN.Properties.Maximum = 0
        Me.prbIN.Properties.Step = 1
        Me.prbIN.Size = New System.Drawing.Size(746, 17)
        Me.prbIN.TabIndex = 102
        '
        'dtTuNgay
        '
        Me.dtTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtTuNgay.EditValue = Nothing
        Me.dtTuNgay.Location = New System.Drawing.Point(205, 19)
        Me.dtTuNgay.Name = "dtTuNgay"
        Me.dtTuNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTuNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtTuNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtTuNgay.Size = New System.Drawing.Size(166, 20)
        Me.dtTuNgay.TabIndex = 100
        '
        'dtDenNgay
        '
        Me.dtDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDenNgay.EditValue = Nothing
        Me.dtDenNgay.Location = New System.Drawing.Point(467, 19)
        Me.dtDenNgay.Name = "dtDenNgay"
        Me.dtDenNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDenNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtDenNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtDenNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDenNgay.Size = New System.Drawing.Size(166, 20)
        Me.dtDenNgay.TabIndex = 101
        '
        'frmBCLSTB_Antoan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmBCLSTB_Antoan"
        Me.Size = New System.Drawing.Size(752, 335)
        Me.tableLayoutPanel2.ResumeLayout(False)
        CType(Me.cboLoaimay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTuNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDenNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblDenNgay As Label
    Private WithEvents cboDChuyen As MVControl.ucComboboxTreeList
    Private WithEvents lblDChuyen As Label
    Private WithEvents lblNhaXuong As Label
    Private WithEvents cboNhaXuong As MVControl.ucComboboxTreeList
    Private WithEvents tableLayoutPanel2 As TableLayoutPanel
    Private WithEvents tableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents lblTuNgay As Label
    Private WithEvents cboLoaimay As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents lblLoaiMay As Label
    Private WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnExcute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtTuNgay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtDenNgay As DevExpress.XtraEditors.DateEdit
    Private WithEvents prbIN As DevExpress.XtraEditors.ProgressBarControl
End Class
