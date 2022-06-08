<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBangtygia
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Me.LblNgay = New System.Windows.Forms.Label()
        Me.DTP = New System.Windows.Forms.DateTimePicker()
        Me.grpTyGia = New DevExpress.XtraEditors.GroupControl()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdTiGia = New DevExpress.XtraGrid.GridControl()
        Me.grvTiGia = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NGAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NGOAI_TE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_NGOAI_TE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NGAY_NHAP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TI_GIA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.TI_GIA_USD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNgoaiTe = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongGhi = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.grpTyGia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTyGia.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.grdTiGia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvTiGia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblNgay
        '
        Me.LblNgay.AutoSize = True
        Me.LblNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblNgay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNgay.ForeColor = System.Drawing.Color.Black
        Me.LblNgay.Location = New System.Drawing.Point(3, 0)
        Me.LblNgay.Name = "LblNgay"
        Me.LblNgay.Size = New System.Drawing.Size(45, 35)
        Me.LblNgay.TabIndex = 0
        Me.LblNgay.Text = "Ngày :"
        Me.LblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DTP
        '
        Me.DTP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP.Location = New System.Drawing.Point(54, 3)
        Me.DTP.Name = "DTP"
        Me.DTP.Size = New System.Drawing.Size(114, 21)
        Me.DTP.TabIndex = 23
        '
        'grpTyGia
        '
        Me.grpTyGia.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTyGia.AppearanceCaption.Options.UseFont = True
        Me.grpTyGia.Controls.Add(Me.TableLayoutPanel3)
        Me.grpTyGia.Controls.Add(Me.PanelControl1)
        Me.grpTyGia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTyGia.Location = New System.Drawing.Point(0, 0)
        Me.grpTyGia.Name = "grpTyGia"
        Me.grpTyGia.Size = New System.Drawing.Size(915, 566)
        Me.grpTyGia.TabIndex = 24
        Me.grpTyGia.Text = "Tỉ giá ngoại tệ"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.DTP, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LblNgay, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.grdTiGia, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 22)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(911, 508)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'grdTiGia
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.grdTiGia, 3)
        Me.grdTiGia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTiGia.Location = New System.Drawing.Point(3, 38)
        Me.grdTiGia.MainView = Me.grvTiGia
        Me.grdTiGia.Name = "grdTiGia"
        Me.grdTiGia.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RepositoryItemSpinEdit2})
        Me.grdTiGia.Size = New System.Drawing.Size(905, 467)
        Me.grdTiGia.TabIndex = 24
        Me.grdTiGia.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTiGia})
        '
        'grvTiGia
        '
        Me.grvTiGia.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvTiGia.Appearance.HeaderPanel.Options.UseFont = True
        Me.grvTiGia.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grvTiGia.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grvTiGia.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NGAY, Me.NGOAI_TE, Me.TEN_NGOAI_TE, Me.NGAY_NHAP, Me.TI_GIA, Me.TI_GIA_USD})
        Me.grvTiGia.GridControl = Me.grdTiGia
        Me.grvTiGia.Name = "grvTiGia"
        Me.grvTiGia.OptionsView.ColumnAutoWidth = False
        Me.grvTiGia.OptionsView.EnableAppearanceEvenRow = True
        Me.grvTiGia.OptionsView.EnableAppearanceOddRow = True
        Me.grvTiGia.OptionsView.ShowGroupPanel = False
        '
        'NGAY
        '
        Me.NGAY.Caption = "GridColumn1"
        Me.NGAY.FieldName = "NGAY"
        Me.NGAY.Name = "NGAY"
        Me.NGAY.OptionsColumn.AllowEdit = False
        '
        'NGOAI_TE
        '
        Me.NGOAI_TE.Caption = "GridColumn1"
        Me.NGOAI_TE.FieldName = "NGOAI_TE"
        Me.NGOAI_TE.Name = "NGOAI_TE"
        Me.NGOAI_TE.OptionsColumn.AllowEdit = False
        Me.NGOAI_TE.Visible = True
        Me.NGOAI_TE.VisibleIndex = 0
        Me.NGOAI_TE.Width = 150
        '
        'TEN_NGOAI_TE
        '
        Me.TEN_NGOAI_TE.Caption = "GridColumn1"
        Me.TEN_NGOAI_TE.FieldName = "TEN_NGOAI_TE"
        Me.TEN_NGOAI_TE.Name = "TEN_NGOAI_TE"
        Me.TEN_NGOAI_TE.OptionsColumn.AllowEdit = False
        Me.TEN_NGOAI_TE.Visible = True
        Me.TEN_NGOAI_TE.VisibleIndex = 1
        Me.TEN_NGOAI_TE.Width = 250
        '
        'NGAY_NHAP
        '
        Me.NGAY_NHAP.Caption = "GridColumn1"
        Me.NGAY_NHAP.FieldName = "NGAY_NHAP"
        Me.NGAY_NHAP.Name = "NGAY_NHAP"
        Me.NGAY_NHAP.OptionsColumn.AllowEdit = False
        '
        'TI_GIA
        '
        Me.TI_GIA.Caption = "GridColumn1"
        Me.TI_GIA.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.TI_GIA.FieldName = "TI_GIA"
        Me.TI_GIA.Name = "TI_GIA"
        Me.TI_GIA.Visible = True
        Me.TI_GIA.VisibleIndex = 2
        Me.TI_GIA.Width = 120
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.EditFormat.FormatString = "N6"
        Me.RepositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "N6"
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'TI_GIA_USD
        '
        Me.TI_GIA_USD.Caption = "GridColumn1"
        Me.TI_GIA_USD.ColumnEdit = Me.RepositoryItemSpinEdit2
        Me.TI_GIA_USD.FieldName = "TI_GIA_USD"
        Me.TI_GIA_USD.Name = "TI_GIA_USD"
        Me.TI_GIA_USD.Width = 120
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.EditFormat.FormatString = "N6"
        Me.RepositoryItemSpinEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemSpinEdit2.Mask.EditMask = "N6"
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(853, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(55, 29)
        Me.TableLayoutPanel1.TabIndex = 25
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(28, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(26, 27)
        Me.btnVideo.TabIndex = 98
        Me.btnVideo.Tag = "CMMS!frmBangtygia"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(25, 27)
        Me.btnHelp.TabIndex = 97
        Me.btnHelp.Tag = "CMMS!frmBangtygia"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnThem)
        Me.PanelControl1.Controls.Add(Me.btnSua)
        Me.PanelControl1.Controls.Add(Me.btnNgoaiTe)
        Me.PanelControl1.Controls.Add(Me.btnXoa)
        Me.PanelControl1.Controls.Add(Me.btnThoat)
        Me.PanelControl1.Controls.Add(Me.btnGhi)
        Me.PanelControl1.Controls.Add(Me.btnKhongGhi)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(2, 530)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.PanelControl1.Size = New System.Drawing.Size(911, 34)
        Me.PanelControl1.TabIndex = 0
        '
        'btnThem
        '
        Me.btnThem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThem.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThem.Appearance.Options.UseFont = True
        Me.btnThem.Location = New System.Drawing.Point(489, 2)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(104, 30)
        Me.btnThem.TabIndex = 22
        Me.btnThem.Text = "&Thêm"
        '
        'btnSua
        '
        Me.btnSua.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSua.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSua.Appearance.Options.UseFont = True
        Me.btnSua.Location = New System.Drawing.Point(594, 2)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(104, 30)
        Me.btnSua.TabIndex = 25
        Me.btnSua.Text = "&Sửa"
        '
        'btnNgoaiTe
        '
        Me.btnNgoaiTe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNgoaiTe.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNgoaiTe.Appearance.Options.UseFont = True
        Me.btnNgoaiTe.Location = New System.Drawing.Point(2, 2)
        Me.btnNgoaiTe.Name = "btnNgoaiTe"
        Me.btnNgoaiTe.Size = New System.Drawing.Size(104, 30)
        Me.btnNgoaiTe.TabIndex = 27
        Me.btnNgoaiTe.Text = "&Ngoại tệ"
        '
        'btnXoa
        '
        Me.btnXoa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoa.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXoa.Appearance.Options.UseFont = True
        Me.btnXoa.Location = New System.Drawing.Point(699, 2)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(104, 30)
        Me.btnXoa.TabIndex = 26
        Me.btnXoa.Text = "&Xóa"
        '
        'btnThoat
        '
        Me.btnThoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThoat.Appearance.Options.UseFont = True
        Me.btnThoat.Location = New System.Drawing.Point(804, 2)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 28
        Me.btnThoat.Text = "Th&oát"
        '
        'btnGhi
        '
        Me.btnGhi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGhi.Appearance.Options.UseFont = True
        Me.btnGhi.Location = New System.Drawing.Point(699, 2)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(104, 30)
        Me.btnGhi.TabIndex = 23
        Me.btnGhi.Text = "&Ghi"
        '
        'btnKhongGhi
        '
        Me.btnKhongGhi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhi.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKhongGhi.Appearance.Options.UseFont = True
        Me.btnKhongGhi.Location = New System.Drawing.Point(804, 2)
        Me.btnKhongGhi.Name = "btnKhongGhi"
        Me.btnKhongGhi.Size = New System.Drawing.Size(104, 30)
        Me.btnKhongGhi.TabIndex = 24
        Me.btnKhongGhi.Text = "&Không ghi"
        '
        'frmBangtygia
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 566)
        Me.Controls.Add(Me.grpTyGia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmBangtygia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bảng tỷ giá"
        CType(Me.grpTyGia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTyGia.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.grdTiGia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvTiGia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblNgay As System.Windows.Forms.Label
    Friend WithEvents DTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpTyGia As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNgoaiTe As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdTiGia As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvTiGia As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NGAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NGOAI_TE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_NGOAI_TE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NGAY_NHAP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TI_GIA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents TI_GIA_USD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
End Class
