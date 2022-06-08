<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptDanhsach_VTPT
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
        Me.lblLoaithietbi = New System.Windows.Forms.Label()
        Me.lblNoiSD = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.repositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.repositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.repositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.repositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.repositoryItemImageComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.gridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.prbIN = New DevExpress.XtraEditors.ProgressBarControl()
        Me.lblLoaiVT = New System.Windows.Forms.Label()
        Me.cboLVT = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboLMay = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboNSD = New DevExpress.XtraEditors.LookUpEdit()
        Me.optBCao = New DevExpress.XtraEditors.RadioGroup()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLVT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optBCao.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLoaithietbi
        '
        Me.lblLoaithietbi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaithietbi.Location = New System.Drawing.Point(164, 44)
        Me.lblLoaithietbi.Name = "lblLoaithietbi"
        Me.lblLoaithietbi.Size = New System.Drawing.Size(123, 25)
        Me.lblLoaithietbi.TabIndex = 1
        Me.lblLoaithietbi.Text = "Loại thiết bị"
        Me.lblLoaithietbi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNoiSD
        '
        Me.lblNoiSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoiSD.Location = New System.Drawing.Point(540, 44)
        Me.lblNoiSD.Name = "lblNoiSD"
        Me.lblNoiSD.Size = New System.Drawing.Size(123, 25)
        Me.lblNoiSD.TabIndex = 1
        Me.lblNoiSD.Text = "Nơi sử dụng"
        Me.lblNoiSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel1.Controls.Add(Me.grdChung, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.prbIN, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaiVT, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLVT, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLMay, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLoaithietbi, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNoiSD, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboNSD, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.optBCao, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1078, 619)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'grdChung
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grdChung, 6)
        Me.grdChung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChung.Location = New System.Drawing.Point(3, 72)
        Me.grdChung.LookAndFeel.SkinName = "Blue"
        Me.grdChung.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemLookUpEdit1, Me.repositoryItemLookUpEdit2, Me.repositoryItemImageComboBox1, Me.repositoryItemImageComboBox2, Me.repositoryItemImageComboBox3})
        Me.grdChung.Size = New System.Drawing.Size(1072, 480)
        Me.grdChung.TabIndex = 33
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung, Me.gridView2})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        Me.grvChung.OptionsView.ShowGroupPanel = False
        Me.grvChung.PreviewFieldName = "Description"
        '
        'repositoryItemLookUpEdit1
        '
        Me.repositoryItemLookUpEdit1.AutoHeight = False
        Me.repositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 38, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.repositoryItemLookUpEdit1.DisplayMember = "Name"
        Me.repositoryItemLookUpEdit1.DropDownRows = 3
        Me.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1"
        Me.repositoryItemLookUpEdit1.PopupWidth = 200
        Me.repositoryItemLookUpEdit1.ShowFooter = False
        Me.repositoryItemLookUpEdit1.ShowHeader = False
        Me.repositoryItemLookUpEdit1.ValueMember = "ID"
        '
        'repositoryItemLookUpEdit2
        '
        Me.repositoryItemLookUpEdit2.AutoHeight = False
        Me.repositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemLookUpEdit2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Full Name", 56, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.repositoryItemLookUpEdit2.DisplayMember = "FullName"
        Me.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2"
        Me.repositoryItemLookUpEdit2.ShowFooter = False
        Me.repositoryItemLookUpEdit2.ShowHeader = False
        Me.repositoryItemLookUpEdit2.ValueMember = "ID"
        '
        'repositoryItemImageComboBox1
        '
        Me.repositoryItemImageComboBox1.AutoHeight = False
        Me.repositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("New", 1, 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Postponed", 2, 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Fixed", 3, 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 4, 5)})
        Me.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1"
        '
        'repositoryItemImageComboBox2
        '
        Me.repositoryItemImageComboBox2.AutoHeight = False
        Me.repositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 1, 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", 2, 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 3, 8)})
        Me.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2"
        '
        'repositoryItemImageComboBox3
        '
        Me.repositoryItemImageComboBox3.AutoHeight = False
        Me.repositoryItemImageComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemImageComboBox3.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Bug", True, 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Request", False, 1)})
        Me.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3"
        '
        'gridView2
        '
        Me.gridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gridColumn1, Me.gridColumn2, Me.gridColumn3, Me.gridColumn4, Me.gridColumn5, Me.gridColumn6, Me.gridColumn7, Me.gridColumn8, Me.gridColumn9, Me.gridColumn10})
        Me.gridView2.GridControl = Me.grdChung
        Me.gridView2.Name = "gridView2"
        Me.gridView2.OptionsView.AllowCellMerge = True
        Me.gridView2.OptionsView.ShowGroupPanel = False
        Me.gridView2.PreviewFieldName = "Description"
        Me.gridView2.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.gridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'gridColumn1
        '
        Me.gridColumn1.Caption = "Project Name"
        Me.gridColumn1.ColumnEdit = Me.repositoryItemLookUpEdit1
        Me.gridColumn1.FieldName = "ProjectID"
        Me.gridColumn1.Name = "gridColumn1"
        Me.gridColumn1.Visible = True
        Me.gridColumn1.VisibleIndex = 0
        Me.gridColumn1.Width = 172
        '
        'gridColumn2
        '
        Me.gridColumn2.Caption = "Type"
        Me.gridColumn2.ColumnEdit = Me.repositoryItemImageComboBox3
        Me.gridColumn2.FieldName = "Type"
        Me.gridColumn2.Name = "gridColumn2"
        Me.gridColumn2.Visible = True
        Me.gridColumn2.VisibleIndex = 1
        Me.gridColumn2.Width = 83
        '
        'gridColumn3
        '
        Me.gridColumn3.Caption = "Name"
        Me.gridColumn3.FieldName = "Name"
        Me.gridColumn3.Name = "gridColumn3"
        Me.gridColumn3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Me.gridColumn3.Visible = True
        Me.gridColumn3.VisibleIndex = 4
        Me.gridColumn3.Width = 137
        '
        'gridColumn4
        '
        Me.gridColumn4.Caption = "Priority"
        Me.gridColumn4.ColumnEdit = Me.repositoryItemImageComboBox2
        Me.gridColumn4.FieldName = "Priority"
        Me.gridColumn4.Name = "gridColumn4"
        Me.gridColumn4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.gridColumn4.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.gridColumn4.Visible = True
        Me.gridColumn4.VisibleIndex = 2
        Me.gridColumn4.Width = 80
        '
        'gridColumn5
        '
        Me.gridColumn5.Caption = "Status"
        Me.gridColumn5.ColumnEdit = Me.repositoryItemImageComboBox1
        Me.gridColumn5.FieldName = "Status"
        Me.gridColumn5.Name = "gridColumn5"
        Me.gridColumn5.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.gridColumn5.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.gridColumn5.Visible = True
        Me.gridColumn5.VisibleIndex = 3
        Me.gridColumn5.Width = 90
        '
        'gridColumn6
        '
        Me.gridColumn6.Caption = "Created Date"
        Me.gridColumn6.FieldName = "CreatedDate"
        Me.gridColumn6.Name = "gridColumn6"
        Me.gridColumn6.SummaryItem.DisplayFormat = "MAX={0}"
        Me.gridColumn6.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max
        Me.gridColumn6.Visible = True
        Me.gridColumn6.VisibleIndex = 5
        Me.gridColumn6.Width = 70
        '
        'gridColumn7
        '
        Me.gridColumn7.Caption = "Owner"
        Me.gridColumn7.ColumnEdit = Me.repositoryItemLookUpEdit2
        Me.gridColumn7.FieldName = "OwnerID"
        Me.gridColumn7.Name = "gridColumn7"
        Me.gridColumn7.Visible = True
        Me.gridColumn7.VisibleIndex = 6
        Me.gridColumn7.Width = 120
        '
        'gridColumn8
        '
        Me.gridColumn8.Caption = "Fixed Date"
        Me.gridColumn8.FieldName = "FixedDate"
        Me.gridColumn8.Name = "gridColumn8"
        '
        'gridColumn9
        '
        Me.gridColumn9.Caption = "Creator"
        Me.gridColumn9.ColumnEdit = Me.repositoryItemLookUpEdit2
        Me.gridColumn9.FieldName = "CreatorID"
        Me.gridColumn9.Name = "gridColumn9"
        '
        'gridColumn10
        '
        Me.gridColumn10.Caption = "Modified Date"
        Me.gridColumn10.FieldName = "ModifiedDate"
        Me.gridColumn10.Name = "gridColumn10"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 6)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnThoat, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnThucHien, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 580)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1072, 36)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'btnThoat
        '
        Me.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat.Location = New System.Drawing.Point(965, 3)
        Me.btnThoat.LookAndFeel.SkinName = "Blue"
        Me.btnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat.TabIndex = 32
        Me.btnThoat.Text = "Thoát"
        '
        'btnThucHien
        '
        Me.btnThucHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien.Location = New System.Drawing.Point(855, 3)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien.TabIndex = 18
        Me.btnThucHien.Text = "Thực hiện"
        '
        'prbIN
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.prbIN, 6)
        Me.prbIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prbIN.Location = New System.Drawing.Point(3, 558)
        Me.prbIN.Name = "prbIN"
        Me.prbIN.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.prbIN.Properties.LookAndFeel.SkinName = "Blue"
        Me.prbIN.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.prbIN.Properties.Maximum = 0
        Me.prbIN.Properties.Step = 1
        Me.prbIN.Size = New System.Drawing.Size(1072, 16)
        Me.prbIN.TabIndex = 35
        '
        'lblLoaiVT
        '
        Me.lblLoaiVT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblLoaiVT.Location = New System.Drawing.Point(164, 19)
        Me.lblLoaiVT.Name = "lblLoaiVT"
        Me.lblLoaiVT.Size = New System.Drawing.Size(123, 25)
        Me.lblLoaiVT.TabIndex = 1
        Me.lblLoaiVT.Text = "lblLoaiVT"
        Me.lblLoaiVT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLVT
        '
        Me.cboLVT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboLVT.Location = New System.Drawing.Point(293, 21)
        Me.cboLVT.Name = "cboLVT"
        Me.cboLVT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLVT.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLVT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLVT.Properties.NullText = ""
        Me.cboLVT.Size = New System.Drawing.Size(241, 20)
        Me.cboLVT.TabIndex = 33
        '
        'cboLMay
        '
        Me.cboLMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLMay.Location = New System.Drawing.Point(293, 47)
        Me.cboLMay.Name = "cboLMay"
        Me.cboLMay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLMay.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLMay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLMay.Properties.NullText = ""
        Me.cboLMay.Size = New System.Drawing.Size(241, 20)
        Me.cboLMay.TabIndex = 33
        '
        'cboNSD
        '
        Me.cboNSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNSD.Location = New System.Drawing.Point(669, 47)
        Me.cboNSD.Name = "cboNSD"
        Me.cboNSD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNSD.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboNSD.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboNSD.Properties.NullText = ""
        Me.cboNSD.Size = New System.Drawing.Size(241, 20)
        Me.cboNSD.TabIndex = 33
        '
        'optBCao
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.optBCao, 2)
        Me.optBCao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.optBCao.EditValue = "optExcel"
        Me.optBCao.Location = New System.Drawing.Point(540, 18)
        Me.optBCao.Name = "optBCao"
        Me.optBCao.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.optBCao.Properties.Appearance.Options.UseBackColor = True
        Me.optBCao.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.optBCao.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("optAll", "optAll"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optReport", "optReport"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optExcel", "optExcel")})
        Me.optBCao.Properties.LookAndFeel.SkinName = "Blue"
        Me.optBCao.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.optBCao.Size = New System.Drawing.Size(370, 23)
        Me.optBCao.TabIndex = 36
        '
        'frmrptDanhsach_VTPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmrptDanhsach_VTPT"
        Me.Size = New System.Drawing.Size(1078, 619)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.prbIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLVT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNSD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optBCao.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLoaithietbi As System.Windows.Forms.Label
    Friend WithEvents lblNoiSD As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cboLMay As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents cboNSD As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents prbIN As DevExpress.XtraEditors.ProgressBarControl
    Private WithEvents cboLVT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblLoaiVT As Windows.Forms.Label
    Private WithEvents optBCao As DevExpress.XtraEditors.RadioGroup
    Private WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Private WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents repositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private WithEvents repositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private WithEvents repositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Private WithEvents repositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Private WithEvents repositoryItemImageComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Private WithEvents gridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
