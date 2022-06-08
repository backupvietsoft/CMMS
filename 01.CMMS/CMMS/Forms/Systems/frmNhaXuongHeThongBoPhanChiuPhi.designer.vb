<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNXHTBPCP
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
        Me.components = New System.ComponentModel.Container()
        Me.BtnThoat = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.grdNXuong = New DevExpress.XtraGrid.GridControl()
        Me.grvNXuong = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnSua = New DevExpress.XtraEditors.SimpleButton()
        Me.LblTieudeNXHTBPCP = New System.Windows.Forms.Label()
        Me.BtnGhi = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi = New DevExpress.XtraEditors.SimpleButton()
        Me.LblMS_THIET_BI = New System.Windows.Forms.Label()
        Me.GrpThietBi = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtMsMay = New DevExpress.XtraEditors.TextEdit()
        Me.grdHThong = New DevExpress.XtraGrid.GridControl()
        Me.grvHThong = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdBPCP = New DevExpress.XtraGrid.GridControl()
        Me.grvBPCP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnXoaBPCP = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoaHT = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXoaNX = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTroVe = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.grpNX = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbtNXuong = New MVControl.ucComboboxTreeList()
        Me.lblTenNX = New System.Windows.Forms.Label()
        Me.lblNgayNX = New System.Windows.Forms.Label()
        Me.datNgayNX = New DevExpress.XtraEditors.DateEdit()
        Me.grpHT = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbtHThong = New MVControl.ucComboboxTreeList()
        Me.lblTenHT = New System.Windows.Forms.Label()
        Me.lblNgayHT = New System.Windows.Forms.Label()
        Me.datNgayHT = New DevExpress.XtraEditors.DateEdit()
        Me.grpBPCP = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTenBPCP = New System.Windows.Forms.Label()
        Me.lblNgayBPCP = New System.Windows.Forms.Label()
        Me.cboTenBPCP = New DevExpress.XtraEditors.LookUpEdit()
        Me.datNgayBPCP = New DevExpress.XtraEditors.DateEdit()
        CType(Me.grdNXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvNXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpThietBi.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.txtMsMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHThong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvHThong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBPCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvBPCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.grpNX.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.datNgayNX.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datNgayNX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpHT.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.datNgayHT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datNgayHT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBPCP.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        CType(Me.cboTenBPCP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datNgayBPCP.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datNgayBPCP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnThoat
        '
        Me.BtnThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat.Location = New System.Drawing.Point(968, 1)
        Me.BtnThoat.LookAndFeel.SkinName = "Blue"
        Me.BtnThoat.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThoat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnThoat.Name = "BtnThoat"
        Me.BtnThoat.Size = New System.Drawing.Size(121, 37)
        Me.BtnThoat.TabIndex = 56
        Me.BtnThoat.Text = "T&hoát"
        '
        'BtnXoa
        '
        Me.BtnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoa.Location = New System.Drawing.Point(846, 1)
        Me.BtnXoa.LookAndFeel.SkinName = "Blue"
        Me.BtnXoa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnXoa.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnXoa.Name = "BtnXoa"
        Me.BtnXoa.Size = New System.Drawing.Size(121, 37)
        Me.BtnXoa.TabIndex = 55
        Me.BtnXoa.Text = "&Xóa"
        '
        'grdNXuong
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.grdNXuong, 2)
        Me.grdNXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNXuong.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdNXuong.Location = New System.Drawing.Point(3, 66)
        Me.grdNXuong.MainView = Me.grvNXuong
        Me.grdNXuong.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdNXuong.Name = "grdNXuong"
        Me.grdNXuong.Size = New System.Drawing.Size(347, 581)
        Me.grdNXuong.TabIndex = 3
        Me.grdNXuong.Tag = ""
        Me.grdNXuong.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvNXuong, Me.GridView2})
        '
        'grvNXuong
        '
        Me.grvNXuong.GridControl = Me.grdNXuong
        Me.grvNXuong.Name = "grvNXuong"
        Me.grvNXuong.OptionsLayout.Columns.StoreAllOptions = True
        Me.grvNXuong.OptionsLayout.StoreAllOptions = True
        Me.grvNXuong.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdNXuong
        Me.GridView2.Name = "GridView2"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BtnSua
        '
        Me.BtnSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSua.Location = New System.Drawing.Point(723, 1)
        Me.BtnSua.LookAndFeel.SkinName = "Blue"
        Me.BtnSua.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSua.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSua.Name = "BtnSua"
        Me.BtnSua.Size = New System.Drawing.Size(121, 37)
        Me.BtnSua.TabIndex = 52
        Me.BtnSua.Text = "BtnSua"
        '
        'LblTieudeNXHTBPCP
        '
        Me.LblTieudeNXHTBPCP.AutoSize = True
        Me.TableLayoutPanel4.SetColumnSpan(Me.LblTieudeNXHTBPCP, 3)
        Me.LblTieudeNXHTBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTieudeNXHTBPCP.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTieudeNXHTBPCP.ForeColor = System.Drawing.Color.Navy
        Me.LblTieudeNXHTBPCP.Location = New System.Drawing.Point(3, 10)
        Me.LblTieudeNXHTBPCP.Name = "LblTieudeNXHTBPCP"
        Me.LblTieudeNXHTBPCP.Size = New System.Drawing.Size(1091, 43)
        Me.LblTieudeNXHTBPCP.TabIndex = 51
        Me.LblTieudeNXHTBPCP.Text = "NHÀ XƯỞNG, HỆ THỐNG, BỘ PHẬN CHỊU PHÍ"
        Me.LblTieudeNXHTBPCP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnGhi
        '
        Me.BtnGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi.Location = New System.Drawing.Point(846, 1)
        Me.BtnGhi.LookAndFeel.SkinName = "Blue"
        Me.BtnGhi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnGhi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGhi.Name = "BtnGhi"
        Me.BtnGhi.Size = New System.Drawing.Size(121, 37)
        Me.BtnGhi.TabIndex = 58
        Me.BtnGhi.Text = "&Ghi"
        '
        'BtnKhongghi
        '
        Me.BtnKhongghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi.Location = New System.Drawing.Point(968, 1)
        Me.BtnKhongghi.LookAndFeel.SkinName = "Blue"
        Me.BtnKhongghi.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnKhongghi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnKhongghi.Name = "BtnKhongghi"
        Me.BtnKhongghi.Size = New System.Drawing.Size(121, 37)
        Me.BtnKhongghi.TabIndex = 59
        Me.BtnKhongghi.Text = "&Không"
        '
        'LblMS_THIET_BI
        '
        Me.LblMS_THIET_BI.AutoSize = True
        Me.LblMS_THIET_BI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblMS_THIET_BI.ForeColor = System.Drawing.Color.Black
        Me.LblMS_THIET_BI.Location = New System.Drawing.Point(3, 0)
        Me.LblMS_THIET_BI.Name = "LblMS_THIET_BI"
        Me.LblMS_THIET_BI.Size = New System.Drawing.Size(3, 6)
        Me.LblMS_THIET_BI.TabIndex = 5
        Me.LblMS_THIET_BI.Text = "Mã số thiết bị :"
        Me.LblMS_THIET_BI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GrpThietBi
        '
        Me.GrpThietBi.Controls.Add(Me.TableLayoutPanel9)
        Me.GrpThietBi.ForeColor = System.Drawing.Color.Maroon
        Me.GrpThietBi.Location = New System.Drawing.Point(7, 11)
        Me.GrpThietBi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpThietBi.Name = "GrpThietBi"
        Me.GrpThietBi.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpThietBi.Size = New System.Drawing.Size(34, 30)
        Me.GrpThietBi.TabIndex = 53
        Me.GrpThietBi.TabStop = False
        Me.GrpThietBi.Text = "Thiết bị"
        Me.GrpThietBi.Visible = False
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.22259!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.77741!))
        Me.TableLayoutPanel9.Controls.Add(Me.LblMS_THIET_BI, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.txtMsMay, 1, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(28, 6)
        Me.TableLayoutPanel9.TabIndex = 0
        '
        'txtMsMay
        '
        Me.txtMsMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMsMay.Location = New System.Drawing.Point(12, 4)
        Me.txtMsMay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMsMay.Name = "txtMsMay"
        Me.txtMsMay.Properties.ReadOnly = True
        Me.txtMsMay.Size = New System.Drawing.Size(13, 22)
        Me.txtMsMay.TabIndex = 6
        '
        'grdHThong
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.grdHThong, 2)
        Me.grdHThong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHThong.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdHThong.Location = New System.Drawing.Point(3, 66)
        Me.grdHThong.MainView = Me.grvHThong
        Me.grdHThong.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdHThong.Name = "grdHThong"
        Me.grdHThong.Size = New System.Drawing.Size(347, 581)
        Me.grdHThong.TabIndex = 3
        Me.grdHThong.Tag = ""
        Me.grdHThong.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvHThong, Me.GridView3})
        '
        'grvHThong
        '
        Me.grvHThong.GridControl = Me.grdHThong
        Me.grvHThong.Name = "grvHThong"
        Me.grvHThong.OptionsLayout.Columns.StoreAllOptions = True
        Me.grvHThong.OptionsLayout.StoreAllOptions = True
        Me.grvHThong.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdHThong
        Me.GridView3.Name = "GridView3"
        '
        'grdBPCP
        '
        Me.TableLayoutPanel8.SetColumnSpan(Me.grdBPCP, 2)
        Me.grdBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBPCP.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdBPCP.Location = New System.Drawing.Point(3, 66)
        Me.grdBPCP.MainView = Me.grvBPCP
        Me.grdBPCP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdBPCP.Name = "grdBPCP"
        Me.grdBPCP.Size = New System.Drawing.Size(349, 581)
        Me.grdBPCP.TabIndex = 3
        Me.grdBPCP.Tag = ""
        Me.grdBPCP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvBPCP, Me.GridView5})
        '
        'grvBPCP
        '
        Me.grvBPCP.GridControl = Me.grdBPCP
        Me.grvBPCP.Name = "grvBPCP"
        Me.grvBPCP.OptionsLayout.Columns.StoreAllOptions = True
        Me.grvBPCP.OptionsLayout.StoreAllOptions = True
        Me.grvBPCP.OptionsView.ShowGroupPanel = False
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.grdBPCP
        Me.GridView5.Name = "GridView5"
        '
        'BtnXoaBPCP
        '
        Me.BtnXoaBPCP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoaBPCP.Location = New System.Drawing.Point(820, 1)
        Me.BtnXoaBPCP.LookAndFeel.SkinName = "Blue"
        Me.BtnXoaBPCP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnXoaBPCP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnXoaBPCP.Name = "BtnXoaBPCP"
        Me.BtnXoaBPCP.Size = New System.Drawing.Size(134, 37)
        Me.BtnXoaBPCP.TabIndex = 60
        Me.BtnXoaBPCP.Text = "Xóa BPCP"
        Me.BtnXoaBPCP.Visible = False
        '
        'BtnXoaHT
        '
        Me.BtnXoaHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoaHT.Location = New System.Drawing.Point(685, 1)
        Me.BtnXoaHT.LookAndFeel.SkinName = "Blue"
        Me.BtnXoaHT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnXoaHT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnXoaHT.Name = "BtnXoaHT"
        Me.BtnXoaHT.Size = New System.Drawing.Size(134, 37)
        Me.BtnXoaHT.TabIndex = 61
        Me.BtnXoaHT.Text = "Xóa Hệ  Thống"
        Me.BtnXoaHT.Visible = False
        '
        'BtnXoaNX
        '
        Me.BtnXoaNX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXoaNX.Location = New System.Drawing.Point(549, 1)
        Me.BtnXoaNX.LookAndFeel.SkinName = "Blue"
        Me.BtnXoaNX.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnXoaNX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnXoaNX.Name = "BtnXoaNX"
        Me.BtnXoaNX.Size = New System.Drawing.Size(134, 37)
        Me.BtnXoaNX.TabIndex = 62
        Me.BtnXoaNX.Text = "Xóa Nhà Xưởng"
        Me.BtnXoaNX.Visible = False
        '
        'BtnTroVe
        '
        Me.BtnTroVe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTroVe.Location = New System.Drawing.Point(955, 1)
        Me.BtnTroVe.LookAndFeel.SkinName = "Blue"
        Me.BtnTroVe.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnTroVe.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnTroVe.Name = "BtnTroVe"
        Me.BtnTroVe.Size = New System.Drawing.Size(134, 37)
        Me.BtnTroVe.TabIndex = 63
        Me.BtnTroVe.Text = "Trở Về"
        Me.BtnTroVe.Visible = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel4.Controls.Add(Me.LblTieudeNXHTBPCP, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel5, 0, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.grpNX, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.grpHT, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.grpBPCP, 2, 3)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 5
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1097, 788)
        Me.TableLayoutPanel4.TabIndex = 64
        '
        'Panel5
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.Panel5, 3)
        Me.Panel5.Controls.Add(Me.GrpThietBi)
        Me.Panel5.Controls.Add(Me.BtnXoa)
        Me.Panel5.Controls.Add(Me.BtnThoat)
        Me.Panel5.Controls.Add(Me.BtnKhongghi)
        Me.Panel5.Controls.Add(Me.BtnGhi)
        Me.Panel5.Controls.Add(Me.BtnSua)
        Me.Panel5.Controls.Add(Me.btnThem)
        Me.Panel5.Controls.Add(Me.BtnTroVe)
        Me.Panel5.Controls.Add(Me.BtnXoaBPCP)
        Me.Panel5.Controls.Add(Me.BtnXoaHT)
        Me.Panel5.Controls.Add(Me.BtnXoaNX)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 745)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1091, 39)
        Me.Panel5.TabIndex = 58
        '
        'btnThem
        '
        Me.btnThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThem.Location = New System.Drawing.Point(601, 1)
        Me.btnThem.LookAndFeel.SkinName = "Blue"
        Me.btnThem.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(121, 37)
        Me.btnThem.TabIndex = 52
        Me.btnThem.Text = "&Thêm"
        '
        'grpNX
        '
        Me.grpNX.Controls.Add(Me.TableLayoutPanel6)
        Me.grpNX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNX.ForeColor = System.Drawing.Color.Maroon
        Me.grpNX.Location = New System.Drawing.Point(3, 62)
        Me.grpNX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpNX.Name = "grpNX"
        Me.grpNX.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpNX.Size = New System.Drawing.Size(359, 675)
        Me.grpNX.TabIndex = 53
        Me.grpNX.TabStop = False
        Me.grpNX.Text = "Thiết bị"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.2093!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.7907!))
        Me.TableLayoutPanel6.Controls.Add(Me.cbtNXuong, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.grdNXuong, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.lblTenNX, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblNgayNX, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.datNgayNX, 1, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(353, 651)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'cbtNXuong
        '
        Me.cbtNXuong.ColumnDisplayName = Nothing
        Me.cbtNXuong.DataSource = Nothing
        Me.cbtNXuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbtNXuong.EditValue = Nothing
        Me.cbtNXuong.Enabled = False
        Me.cbtNXuong.KeyFieldName = Nothing
        Me.cbtNXuong.Location = New System.Drawing.Point(134, 5)
        Me.cbtNXuong.LookAndFeel.SkinName = "Blue"
        Me.cbtNXuong.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cbtNXuong.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cbtNXuong.MaximumSize = New System.Drawing.Size(1167, 25)
        Me.cbtNXuong.MinimumSize = New System.Drawing.Size(12, 25)
        Me.cbtNXuong.Name = "cbtNXuong"
        Me.cbtNXuong.ParentFieldName = Nothing
        Me.cbtNXuong.ReadOnly = False
        Me.cbtNXuong.SelectedIndex = 0
        Me.cbtNXuong.Size = New System.Drawing.Size(216, 25)
        Me.cbtNXuong.TabIndex = 64
        Me.cbtNXuong.TextValue = Nothing
        '
        'lblTenNX
        '
        Me.lblTenNX.AutoSize = True
        Me.lblTenNX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenNX.ForeColor = System.Drawing.Color.Black
        Me.lblTenNX.Location = New System.Drawing.Point(3, 0)
        Me.lblTenNX.Name = "lblTenNX"
        Me.lblTenNX.Size = New System.Drawing.Size(125, 31)
        Me.lblTenNX.TabIndex = 5
        Me.lblTenNX.Text = "lblTenNX"
        Me.lblTenNX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayNX
        '
        Me.lblNgayNX.AutoSize = True
        Me.lblNgayNX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayNX.ForeColor = System.Drawing.Color.Black
        Me.lblNgayNX.Location = New System.Drawing.Point(3, 31)
        Me.lblNgayNX.Name = "lblNgayNX"
        Me.lblNgayNX.Size = New System.Drawing.Size(125, 31)
        Me.lblNgayNX.TabIndex = 5
        Me.lblNgayNX.Text = "Mã số thiết bị :"
        Me.lblNgayNX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'datNgayNX
        '
        Me.datNgayNX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datNgayNX.EditValue = New Date(2012, 6, 4, 15, 53, 55, 0)
        Me.datNgayNX.Enabled = False
        Me.datNgayNX.Location = New System.Drawing.Point(134, 35)
        Me.datNgayNX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.datNgayNX.Name = "datNgayNX"
        Me.datNgayNX.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datNgayNX.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datNgayNX.Size = New System.Drawing.Size(216, 22)
        Me.datNgayNX.TabIndex = 7
        '
        'grpHT
        '
        Me.grpHT.Controls.Add(Me.TableLayoutPanel7)
        Me.grpHT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpHT.ForeColor = System.Drawing.Color.Maroon
        Me.grpHT.Location = New System.Drawing.Point(368, 62)
        Me.grpHT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpHT.Name = "grpHT"
        Me.grpHT.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpHT.Size = New System.Drawing.Size(359, 675)
        Me.grpHT.TabIndex = 53
        Me.grpHT.TabStop = False
        Me.grpHT.Text = "Thiết bị"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.2093!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.7907!))
        Me.TableLayoutPanel7.Controls.Add(Me.cbtHThong, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.lblTenHT, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.lblNgayHT, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.datNgayHT, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.grdHThong, 0, 2)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 3
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(353, 651)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'cbtHThong
        '
        Me.cbtHThong.ColumnDisplayName = Nothing
        Me.cbtHThong.DataSource = Nothing
        Me.cbtHThong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbtHThong.EditValue = Nothing
        Me.cbtHThong.Enabled = False
        Me.cbtHThong.KeyFieldName = Nothing
        Me.cbtHThong.Location = New System.Drawing.Point(134, 5)
        Me.cbtHThong.LookAndFeel.SkinName = "Blue"
        Me.cbtHThong.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cbtHThong.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cbtHThong.MaximumSize = New System.Drawing.Size(1167, 25)
        Me.cbtHThong.MinimumSize = New System.Drawing.Size(12, 25)
        Me.cbtHThong.Name = "cbtHThong"
        Me.cbtHThong.ParentFieldName = Nothing
        Me.cbtHThong.ReadOnly = False
        Me.cbtHThong.SelectedIndex = 0
        Me.cbtHThong.Size = New System.Drawing.Size(216, 25)
        Me.cbtHThong.TabIndex = 64
        Me.cbtHThong.TextValue = Nothing
        '
        'lblTenHT
        '
        Me.lblTenHT.AutoSize = True
        Me.lblTenHT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenHT.ForeColor = System.Drawing.Color.Black
        Me.lblTenHT.Location = New System.Drawing.Point(3, 0)
        Me.lblTenHT.Name = "lblTenHT"
        Me.lblTenHT.Size = New System.Drawing.Size(125, 31)
        Me.lblTenHT.TabIndex = 5
        Me.lblTenHT.Text = "lblTenHT"
        Me.lblTenHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayHT
        '
        Me.lblNgayHT.AutoSize = True
        Me.lblNgayHT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayHT.ForeColor = System.Drawing.Color.Black
        Me.lblNgayHT.Location = New System.Drawing.Point(3, 31)
        Me.lblNgayHT.Name = "lblNgayHT"
        Me.lblNgayHT.Size = New System.Drawing.Size(125, 31)
        Me.lblNgayHT.TabIndex = 5
        Me.lblNgayHT.Text = "lblNgayHT"
        Me.lblNgayHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'datNgayHT
        '
        Me.datNgayHT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datNgayHT.EditValue = New Date(2012, 6, 4, 15, 53, 55, 0)
        Me.datNgayHT.Enabled = False
        Me.datNgayHT.Location = New System.Drawing.Point(134, 35)
        Me.datNgayHT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.datNgayHT.Name = "datNgayHT"
        Me.datNgayHT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datNgayHT.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datNgayHT.Size = New System.Drawing.Size(216, 22)
        Me.datNgayHT.TabIndex = 7
        '
        'grpBPCP
        '
        Me.grpBPCP.Controls.Add(Me.TableLayoutPanel8)
        Me.grpBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpBPCP.ForeColor = System.Drawing.Color.Maroon
        Me.grpBPCP.Location = New System.Drawing.Point(733, 62)
        Me.grpBPCP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpBPCP.Name = "grpBPCP"
        Me.grpBPCP.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpBPCP.Size = New System.Drawing.Size(361, 675)
        Me.grpBPCP.TabIndex = 53
        Me.grpBPCP.TabStop = False
        Me.grpBPCP.Text = "Thiết bị"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.2093!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.7907!))
        Me.TableLayoutPanel8.Controls.Add(Me.lblTenBPCP, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.lblNgayBPCP, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.cboTenBPCP, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.datNgayBPCP, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.grdBPCP, 0, 2)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 20)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 3
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(355, 651)
        Me.TableLayoutPanel8.TabIndex = 0
        '
        'lblTenBPCP
        '
        Me.lblTenBPCP.AutoSize = True
        Me.lblTenBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTenBPCP.ForeColor = System.Drawing.Color.Black
        Me.lblTenBPCP.Location = New System.Drawing.Point(3, 0)
        Me.lblTenBPCP.Name = "lblTenBPCP"
        Me.lblTenBPCP.Size = New System.Drawing.Size(126, 31)
        Me.lblTenBPCP.TabIndex = 5
        Me.lblTenBPCP.Text = "lblTenBPCP"
        Me.lblTenBPCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayBPCP
        '
        Me.lblNgayBPCP.AutoSize = True
        Me.lblNgayBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayBPCP.ForeColor = System.Drawing.Color.Black
        Me.lblNgayBPCP.Location = New System.Drawing.Point(3, 31)
        Me.lblNgayBPCP.Name = "lblNgayBPCP"
        Me.lblNgayBPCP.Size = New System.Drawing.Size(126, 31)
        Me.lblNgayBPCP.TabIndex = 5
        Me.lblNgayBPCP.Text = "lblNgayBPCP"
        Me.lblNgayBPCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTenBPCP
        '
        Me.cboTenBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTenBPCP.Enabled = False
        Me.cboTenBPCP.Location = New System.Drawing.Point(135, 4)
        Me.cboTenBPCP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTenBPCP.Name = "cboTenBPCP"
        Me.cboTenBPCP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTenBPCP.Size = New System.Drawing.Size(217, 22)
        Me.cboTenBPCP.TabIndex = 6
        '
        'datNgayBPCP
        '
        Me.datNgayBPCP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datNgayBPCP.EditValue = New Date(2012, 6, 4, 15, 53, 55, 0)
        Me.datNgayBPCP.Enabled = False
        Me.datNgayBPCP.Location = New System.Drawing.Point(135, 35)
        Me.datNgayBPCP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.datNgayBPCP.Name = "datNgayBPCP"
        Me.datNgayBPCP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datNgayBPCP.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datNgayBPCP.Size = New System.Drawing.Size(217, 22)
        Me.datNgayBPCP.TabIndex = 7
        '
        'FrmNXHTBPCP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 788)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmNXHTBPCP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nhà xưởng, chuyên môn, bộ phận chịu phí"
        CType(Me.grdNXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvNXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpThietBi.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        CType(Me.txtMsMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHThong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvHThong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBPCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvBPCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.grpNX.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.datNgayNX.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datNgayNX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpHT.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        CType(Me.datNgayHT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datNgayHT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBPCP.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        CType(Me.cboTenBPCP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datNgayBPCP.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datNgayBPCP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnThoat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblTieudeNXHTBPCP As System.Windows.Forms.Label
    Friend WithEvents BtnGhi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpThietBi As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMS_MAY As Commons.utcTextBox
    Friend WithEvents LblMS_THIET_BI As System.Windows.Forms.Label
    Friend WithEvents BtnTroVe As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoaNX As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoaHT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXoaBPCP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpNX As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTenNX As System.Windows.Forms.Label
    Friend WithEvents lblNgayNX As System.Windows.Forms.Label
    Friend WithEvents datNgayNX As DevExpress.XtraEditors.DateEdit
    Friend WithEvents grpHT As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTenHT As System.Windows.Forms.Label
    Friend WithEvents lblNgayHT As System.Windows.Forms.Label
    Friend WithEvents datNgayHT As DevExpress.XtraEditors.DateEdit
    Friend WithEvents grpBPCP As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTenBPCP As System.Windows.Forms.Label
    Friend WithEvents lblNgayBPCP As System.Windows.Forms.Label
    Friend WithEvents cboTenBPCP As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents datNgayBPCP As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtMsMay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdBPCP As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvBPCP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdHThong As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvHThong As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdNXuong As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvNXuong As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cbtNXuong As MVControl.ucComboboxTreeList
    Friend WithEvents cbtHThong As MVControl.ucComboboxTreeList
End Class
