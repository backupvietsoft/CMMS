Imports MVControl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKehoachtongthe_odd
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
        Dim XyDiagram4 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series7 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel10 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim Series8 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel11 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim SideBySideBarSeriesLabel12 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim XyDiagram5 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series9 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel13 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim Series10 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel14 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim SideBySideBarSeriesLabel15 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim XyDiagram6 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series11 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel16 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim Series12 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel17 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim SideBySideBarSeriesLabel18 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Me.BtnIn = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThem1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGhi1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThoat1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhongghi1 = New DevExpress.XtraEditors.SimpleButton()
        Me.tabKeHoachTongThe = New DevExpress.XtraTab.XtraTabControl()
        Me.tabKeHoachTT = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDieuKienLoc1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.radChuaGiaiQuyet1 = New System.Windows.Forms.RadioButton()
        Me.cboNTHien = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtpDNKHTT = New DevExpress.XtraEditors.DateEdit()
        Me.lblNTHien = New System.Windows.Forms.Label()
        Me.RadBoQua1 = New System.Windows.Forms.RadioButton()
        Me.dtpTNKHTT = New DevExpress.XtraEditors.DateEdit()
        Me.lblDenNgay1 = New System.Windows.Forms.Label()
        Me.radDaGiaiQuyet1 = New System.Windows.Forms.RadioButton()
        Me.lblTuNgay1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnBoChonTatCa1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnChonTatCa1 = New DevExpress.XtraEditors.SimpleButton()
        Me.NONN = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLydosuachua = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTroVe = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXemNguyenNhan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCapNhatMUT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonCV = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonMay = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonPT = New DevExpress.XtraEditors.SimpleButton()
        Me.prbLapPhieuBaoTri = New DevExpress.XtraEditors.ProgressBarControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.grpKehoachtongthe = New DevExpress.XtraEditors.GroupControl()
        Me.lblTong = New System.Windows.Forms.Label()
        Me.gdKHTT = New DevExpress.XtraGrid.GridControl()
        Me.gvKHTT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chxChoose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cboMay = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_MAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboNgayLap = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboNgayDKHT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TONG_THOI_GIAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CBOLYDOSUACHUA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HANG_MUC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboMS_UU_TIEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboMS_CN_PT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHI_CHU1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.YC_CHUNG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.YC_MO_TA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.YC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_CN_GS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.grpKehoachtongcongviec = New DevExpress.XtraEditors.GroupControl()
        Me.gdCVTT = New DevExpress.XtraGrid.GridControl()
        Me.gvCVTT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TEN_BO_PHAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_CONG_VIEC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_UU_TIEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_PHIEU_BAO_TRI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.THUE_NGOAI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KHONG_GQ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me._GHI_CHU = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_CV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MS_BO_PHAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me._HANG_MUC_ID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.THOI_GIAN_DU_KIEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SNGUOI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.YCAU_NS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.YCAU_DC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.THAO_TAC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TIEU_CHUAN_KT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_TINH_TRANG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grpKehoachtongcongviecVT = New DevExpress.XtraEditors.GroupControl()
        Me.gdVTTT = New DevExpress.XtraGrid.GridControl()
        Me.gvVTTT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MS_PT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_PT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.QUY_CACH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SO_LUONG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEN_DVT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHI_CHU2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DON_GIA_KH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TIEN_TE_KH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TY_GIA_KH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TY_GIA_USD_KH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DON_GIA_CUOI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NGAY_LAY_DG_KH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tabGSTT = New DevExpress.XtraTab.XtraTabPage()
        Me.TabYeucaunguoisudung = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDieuKienLoc3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.radChuaGiaiQuyet3 = New System.Windows.Forms.RadioButton()
        Me.RadBoQua3 = New System.Windows.Forms.RadioButton()
        Me.lblDenNgay3 = New System.Windows.Forms.Label()
        Me.radDaGiaiQuyet3 = New System.Windows.Forms.RadioButton()
        Me.lblTuNgay3 = New System.Windows.Forms.Label()
        Me.dtpDNYCSD = New DevExpress.XtraEditors.DateEdit()
        Me.dtpTNYCSD = New DevExpress.XtraEditors.DateEdit()
        Me.grpYEU_CAU_NSD = New System.Windows.Forms.GroupBox()
        Me.gdYCNSD = New DevExpress.XtraGrid.GridControl()
        Me.gvYCNSD = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnThoat3 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThucHien2 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXemBangChung2 = New DevExpress.XtraEditors.SimpleButton()
        Me.TabBaotridinhky = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cboNGSat = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblNGSat = New System.Windows.Forms.Label()
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker()
        Me.lblDenNgayBTDK = New System.Windows.Forms.Label()
        Me.chkDuGio = New DevExpress.XtraEditors.CheckEdit()
        Me.btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTuNgay = New System.Windows.Forms.Label()
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker()
        Me.lblDenNgay = New System.Windows.Forms.Label()
        Me.cboNguoiLap = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblNguoiLap = New System.Windows.Forms.Label()
        Me.BtnThoatBTDK = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLapKHTT = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLapPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnInBTDK = New DevExpress.XtraEditors.SimpleButton()
        Me.grpDanhsachBTDKcanthuchien = New DevExpress.XtraEditors.GroupControl()
        Me.lblChon = New System.Windows.Forms.Label()
        Me.gdBTDK = New DevExpress.XtraGrid.GridControl()
        Me.gvBTDK = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnBoChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnChonTatCa = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTKiemBTDK = New DevExpress.XtraEditors.TextEdit()
        Me.LblThongBao = New System.Windows.Forms.Label()
        Me.dtpDenNgayBTDK1 = New System.Windows.Forms.MaskedTextBox()
        Me.TabBaoTriTheoGio = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnThoat5 = New DevExpress.XtraEditors.SimpleButton()
        Me.grpBaotritheothoigian = New System.Windows.Forms.GroupBox()
        Me.gdBTDK_Gio = New DevExpress.XtraGrid.GridControl()
        Me.gvBTDK_Gio = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnLapPBT1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnInGio = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLapKHTT1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTKiemBTDKGio = New DevExpress.XtraEditors.TextEdit()
        Me.btnAllBTDKTheoGio = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNotAllBTDKTheoGio = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNguoiLap1 = New System.Windows.Forms.Label()
        Me.cboNguoiLap1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.TabMonitoring = New DevExpress.XtraTab.XtraTabPage()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.gdTSGSTT1 = New DevExpress.XtraGrid.GridControl()
        Me.gvTSGSTT1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDiaDiem_1 = New System.Windows.Forms.Label()
        Me.cboLoaiThietBiBTDK = New DevExpress.XtraEditors.LookUpEdit()
        Me.CboNhomThietBiBTDK = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblDChuyen = New System.Windows.Forms.Label()
        Me.cboDiaDiem_1 = New MVControl.ucComboboxTreeList()
        Me.CboMaSoThietBiBTDK = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboHThong = New DevExpress.XtraEditors.LookUpEdit()
        Me.LblMaSoThietBiBTDK = New System.Windows.Forms.Label()
        Me.lblLoaiThietBiBTDK = New System.Windows.Forms.Label()
        Me.LblNhomThietBiBTDK = New System.Windows.Forms.Label()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.btnViewMonitoring = New DevExpress.XtraCharts.ChartControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.ChartWeeksMonitoring = New DevExpress.XtraCharts.ChartControl()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.ChartMonthsMonitoring = New DevExpress.XtraCharts.ChartControl()
        Me.btnSelectAllForMonitoring = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDeselectAllForMonitoring = New DevExpress.XtraEditors.SimpleButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAllGSTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNotAllGSTT = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTimGSTT = New DevExpress.XtraEditors.TextEdit()
        Me.grpDieuKienLoc2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.radChuaGiaiQuyet2 = New System.Windows.Forms.RadioButton()
        Me.RadBoQua2 = New System.Windows.Forms.RadioButton()
        Me.radDaGiaiQuyet2 = New System.Windows.Forms.RadioButton()
        Me.lblTungay2 = New System.Windows.Forms.Label()
        Me.dtpTNGSTT = New DevExpress.XtraEditors.DateEdit()
        Me.lblDenNgay2 = New System.Windows.Forms.Label()
        Me.dtpDNGSTT = New DevExpress.XtraEditors.DateEdit()
        Me.btnThucHien1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHuy = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat2 = New DevExpress.XtraEditors.SimpleButton()
        Me.grpGSTT = New System.Windows.Forms.GroupBox()
        Me.gdTSGSTT = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gvTSGSTT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnXemBangChung1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.tabKeHoachTongThe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabKeHoachTongThe.SuspendLayout()
        Me.tabKeHoachTT.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.grpDieuKienLoc1.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        CType(Me.cboNTHien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDNKHTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDNKHTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTNKHTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTNKHTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.prbLapPhieuBaoTri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.grpKehoachtongthe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpKehoachtongthe.SuspendLayout()
        CType(Me.gdKHTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvKHTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.grpKehoachtongcongviec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpKehoachtongcongviec.SuspendLayout()
        CType(Me.gdCVTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCVTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpKehoachtongcongviecVT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpKehoachtongcongviecVT.SuspendLayout()
        CType(Me.gdVTTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvVTTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGSTT.SuspendLayout()
        Me.TabYeucaunguoisudung.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.grpDieuKienLoc3.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        CType(Me.dtpDNYCSD.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDNYCSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTNYCSD.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTNYCSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpYEU_CAU_NSD.SuspendLayout()
        CType(Me.gdYCNSD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvYCNSD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabBaotridinhky.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNGSat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDuGio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNguoiLap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpDanhsachBTDKcanthuchien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDanhsachBTDKcanthuchien.SuspendLayout()
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTKiemBTDK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabBaoTriTheoGio.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.grpBaotritheothoigian.SuspendLayout()
        CType(Me.gdBTDK_Gio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvBTDK_Gio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTKiemBTDKGio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNguoiLap1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.gdTSGSTT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvTSGSTT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.cboLoaiThietBiBTDK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboNhomThietBiBTDK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboMaSoThietBiBTDK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboHThong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.btnViewMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.ChartWeeksMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.ChartMonthsMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimGSTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDieuKienLoc2.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        CType(Me.dtpTNGSTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTNGSTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDNGSTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDNGSTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGSTT.SuspendLayout()
        CType(Me.gdTSGSTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvTSGSTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnIn
        '
        Me.BtnIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIn.Location = New System.Drawing.Point(1130, 3)
        Me.BtnIn.LookAndFeel.SkinName = "Blue"
        Me.BtnIn.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnIn.Name = "BtnIn"
        Me.BtnIn.Size = New System.Drawing.Size(104, 30)
        Me.BtnIn.TabIndex = 19
        Me.BtnIn.Text = "In"
        '
        'BtnThem1
        '
        Me.BtnThem1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThem1.Location = New System.Drawing.Point(920, 3)
        Me.BtnThem1.LookAndFeel.SkinName = "Blue"
        Me.BtnThem1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThem1.Name = "BtnThem1"
        Me.BtnThem1.Size = New System.Drawing.Size(104, 30)
        Me.BtnThem1.TabIndex = 15
        Me.BtnThem1.Text = "&Thêm / Sửa "
        '
        'BtnGhi1
        '
        Me.BtnGhi1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGhi1.Location = New System.Drawing.Point(1130, 3)
        Me.BtnGhi1.LookAndFeel.SkinName = "Blue"
        Me.BtnGhi1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnGhi1.Name = "BtnGhi1"
        Me.BtnGhi1.Size = New System.Drawing.Size(104, 30)
        Me.BtnGhi1.TabIndex = 18
        Me.BtnGhi1.Text = "&Ghi"
        Me.BtnGhi1.Visible = False
        '
        'BtnThoat1
        '
        Me.BtnThoat1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnThoat1.Location = New System.Drawing.Point(1235, 3)
        Me.BtnThoat1.LookAndFeel.SkinName = "Blue"
        Me.BtnThoat1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThoat1.Name = "BtnThoat1"
        Me.BtnThoat1.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat1.TabIndex = 17
        Me.BtnThoat1.Text = "T&hoát"
        '
        'BtnKhongghi1
        '
        Me.BtnKhongghi1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnKhongghi1.Location = New System.Drawing.Point(1235, 3)
        Me.BtnKhongghi1.LookAndFeel.SkinName = "Blue"
        Me.BtnKhongghi1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnKhongghi1.Name = "BtnKhongghi1"
        Me.BtnKhongghi1.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhongghi1.TabIndex = 21
        Me.BtnKhongghi1.Text = "&Không"
        Me.BtnKhongghi1.Visible = False
        '
        'tabKeHoachTongThe
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tabKeHoachTongThe, 5)
        Me.tabKeHoachTongThe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabKeHoachTongThe.Location = New System.Drawing.Point(3, 43)
        Me.tabKeHoachTongThe.LookAndFeel.SkinName = "Blue"
        Me.tabKeHoachTongThe.LookAndFeel.UseDefaultLookAndFeel = False
        Me.tabKeHoachTongThe.Name = "tabKeHoachTongThe"
        Me.tabKeHoachTongThe.SelectedTabPage = Me.tabKeHoachTT
        Me.tabKeHoachTongThe.Size = New System.Drawing.Size(1358, 683)
        Me.tabKeHoachTongThe.TabIndex = 22
        Me.tabKeHoachTongThe.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabKeHoachTT, Me.tabGSTT, Me.TabYeucaunguoisudung, Me.TabBaotridinhky, Me.TabBaoTriTheoGio, Me.TabMonitoring})
        '
        'tabKeHoachTT
        '
        Me.tabKeHoachTT.Controls.Add(Me.TableLayoutPanel4)
        Me.tabKeHoachTT.Name = "tabKeHoachTT"
        Me.tabKeHoachTT.Padding = New System.Windows.Forms.Padding(3)
        Me.tabKeHoachTT.Size = New System.Drawing.Size(1351, 655)
        Me.tabKeHoachTT.Text = "Kế hoạch tổng thể"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.71486!))
        Me.TableLayoutPanel4.Controls.Add(Me.grpDieuKienLoc1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel4, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.prbLapPhieuBaoTri, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.SplitContainerControl1, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1345, 649)
        Me.TableLayoutPanel4.TabIndex = 31
        '
        'grpDieuKienLoc1
        '
        Me.grpDieuKienLoc1.Controls.Add(Me.TableLayoutPanel8)
        Me.grpDieuKienLoc1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.grpDieuKienLoc1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDieuKienLoc1.ForeColor = System.Drawing.Color.Maroon
        Me.grpDieuKienLoc1.Location = New System.Drawing.Point(3, 3)
        Me.grpDieuKienLoc1.Name = "grpDieuKienLoc1"
        Me.grpDieuKienLoc1.Size = New System.Drawing.Size(1339, 46)
        Me.grpDieuKienLoc1.TabIndex = 24
        Me.grpDieuKienLoc1.TabStop = False
        Me.grpDieuKienLoc1.Text = "Điều kiện lọc"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 11
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.radChuaGiaiQuyet1, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.cboNTHien, 9, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.dtpDNKHTT, 7, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.lblNTHien, 8, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.RadBoQua1, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.dtpTNKHTT, 5, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.lblDenNgay1, 6, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.radDaGiaiQuyet1, 3, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.lblTuNgay1, 4, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(1333, 26)
        Me.TableLayoutPanel8.TabIndex = 30
        '
        'radChuaGiaiQuyet1
        '
        Me.radChuaGiaiQuyet1.AutoSize = True
        Me.radChuaGiaiQuyet1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radChuaGiaiQuyet1.ForeColor = System.Drawing.Color.Black
        Me.radChuaGiaiQuyet1.Location = New System.Drawing.Point(129, 3)
        Me.radChuaGiaiQuyet1.Name = "radChuaGiaiQuyet1"
        Me.radChuaGiaiQuyet1.Size = New System.Drawing.Size(104, 20)
        Me.radChuaGiaiQuyet1.TabIndex = 0
        Me.radChuaGiaiQuyet1.Text = "Chưa giải quyết"
        Me.radChuaGiaiQuyet1.UseVisualStyleBackColor = True
        '
        'cboNTHien
        '
        Me.cboNTHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNTHien.Location = New System.Drawing.Point(1009, 3)
        Me.cboNTHien.Name = "cboNTHien"
        Me.cboNTHien.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNTHien.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboNTHien.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboNTHien.Properties.NullText = ""
        Me.cboNTHien.Size = New System.Drawing.Size(194, 20)
        Me.cboNTHien.TabIndex = 28
        '
        'dtpDNKHTT
        '
        Me.dtpDNKHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDNKHTT.EditValue = Nothing
        Me.dtpDNKHTT.Location = New System.Drawing.Point(789, 3)
        Me.dtpDNKHTT.Name = "dtpDNKHTT"
        Me.dtpDNKHTT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDNKHTT.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpDNKHTT.Size = New System.Drawing.Size(104, 20)
        Me.dtpDNKHTT.TabIndex = 29
        '
        'lblNTHien
        '
        Me.lblNTHien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNTHien.ForeColor = System.Drawing.Color.Black
        Me.lblNTHien.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNTHien.Location = New System.Drawing.Point(899, 0)
        Me.lblNTHien.Name = "lblNTHien"
        Me.lblNTHien.Size = New System.Drawing.Size(104, 26)
        Me.lblNTHien.TabIndex = 27
        Me.lblNTHien.Text = "Nguoi Thuc hien"
        Me.lblNTHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadBoQua1
        '
        Me.RadBoQua1.AutoSize = True
        Me.RadBoQua1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadBoQua1.ForeColor = System.Drawing.Color.Black
        Me.RadBoQua1.Location = New System.Drawing.Point(239, 3)
        Me.RadBoQua1.Name = "RadBoQua1"
        Me.RadBoQua1.Size = New System.Drawing.Size(104, 20)
        Me.RadBoQua1.TabIndex = 7
        Me.RadBoQua1.Text = "KHTT bị bỏ qua "
        Me.RadBoQua1.UseVisualStyleBackColor = True
        '
        'dtpTNKHTT
        '
        Me.dtpTNKHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTNKHTT.EditValue = Nothing
        Me.dtpTNKHTT.Location = New System.Drawing.Point(569, 3)
        Me.dtpTNKHTT.Name = "dtpTNKHTT"
        Me.dtpTNKHTT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpTNKHTT.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpTNKHTT.Size = New System.Drawing.Size(104, 20)
        Me.dtpTNKHTT.TabIndex = 29
        '
        'lblDenNgay1
        '
        Me.lblDenNgay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNgay1.ForeColor = System.Drawing.Color.Black
        Me.lblDenNgay1.Location = New System.Drawing.Point(679, 0)
        Me.lblDenNgay1.Name = "lblDenNgay1"
        Me.lblDenNgay1.Size = New System.Drawing.Size(104, 26)
        Me.lblDenNgay1.TabIndex = 3
        Me.lblDenNgay1.Text = "Đến ngày"
        Me.lblDenNgay1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'radDaGiaiQuyet1
        '
        Me.radDaGiaiQuyet1.AutoSize = True
        Me.radDaGiaiQuyet1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDaGiaiQuyet1.ForeColor = System.Drawing.Color.Black
        Me.radDaGiaiQuyet1.Location = New System.Drawing.Point(349, 3)
        Me.radDaGiaiQuyet1.Name = "radDaGiaiQuyet1"
        Me.radDaGiaiQuyet1.Size = New System.Drawing.Size(104, 20)
        Me.radDaGiaiQuyet1.TabIndex = 1
        Me.radDaGiaiQuyet1.Text = "Đã giải quyết"
        Me.radDaGiaiQuyet1.UseVisualStyleBackColor = True
        '
        'lblTuNgay1
        '
        Me.lblTuNgay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuNgay1.ForeColor = System.Drawing.Color.Black
        Me.lblTuNgay1.Location = New System.Drawing.Point(459, 0)
        Me.lblTuNgay1.Name = "lblTuNgay1"
        Me.lblTuNgay1.Size = New System.Drawing.Size(104, 26)
        Me.lblTuNgay1.TabIndex = 2
        Me.lblTuNgay1.Text = "Từ ngày"
        Me.lblTuNgay1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.BtnThoat1)
        Me.Panel4.Controls.Add(Me.BtnBoChonTatCa1)
        Me.Panel4.Controls.Add(Me.BtnChonTatCa1)
        Me.Panel4.Controls.Add(Me.NONN)
        Me.Panel4.Controls.Add(Me.btnLydosuachua)
        Me.Panel4.Controls.Add(Me.BtnKhongghi1)
        Me.Panel4.Controls.Add(Me.BtnTroVe)
        Me.Panel4.Controls.Add(Me.btnXemNguyenNhan)
        Me.Panel4.Controls.Add(Me.BtnThem1)
        Me.Panel4.Controls.Add(Me.btnXoa)
        Me.Panel4.Controls.Add(Me.btnLPBT)
        Me.Panel4.Controls.Add(Me.BtnIn)
        Me.Panel4.Controls.Add(Me.btnCapNhatMUT)
        Me.Panel4.Controls.Add(Me.btnChonCV)
        Me.Panel4.Controls.Add(Me.btnChonMay)
        Me.Panel4.Controls.Add(Me.btnChonPT)
        Me.Panel4.Controls.Add(Me.BtnGhi1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 613)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1339, 33)
        Me.Panel4.TabIndex = 25
        '
        'BtnBoChonTatCa1
        '
        Me.BtnBoChonTatCa1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBoChonTatCa1.Location = New System.Drawing.Point(139, 3)
        Me.BtnBoChonTatCa1.LookAndFeel.SkinName = "Blue"
        Me.BtnBoChonTatCa1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnBoChonTatCa1.Name = "BtnBoChonTatCa1"
        Me.BtnBoChonTatCa1.Size = New System.Drawing.Size(104, 30)
        Me.BtnBoChonTatCa1.TabIndex = 95
        Me.BtnBoChonTatCa1.Text = "Bỏ chọn tất cả"
        '
        'BtnChonTatCa1
        '
        Me.BtnChonTatCa1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnChonTatCa1.Location = New System.Drawing.Point(34, 3)
        Me.BtnChonTatCa1.LookAndFeel.SkinName = "Blue"
        Me.BtnChonTatCa1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnChonTatCa1.Name = "BtnChonTatCa1"
        Me.BtnChonTatCa1.Size = New System.Drawing.Size(104, 30)
        Me.BtnChonTatCa1.TabIndex = 94
        Me.BtnChonTatCa1.Text = "Chọn tất cả"
        '
        'NONN
        '
        Me.NONN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NONN.Image = Global.My.Resources.Resources.activity_monitor
        Me.NONN.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter
        Me.NONN.Location = New System.Drawing.Point(3, 3)
        Me.NONN.LookAndFeel.SkinName = "Blue"
        Me.NONN.LookAndFeel.UseDefaultLookAndFeel = False
        Me.NONN.Name = "NONN"
        Me.NONN.Size = New System.Drawing.Size(30, 30)
        Me.NONN.TabIndex = 41
        '
        'btnLydosuachua
        '
        Me.btnLydosuachua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLydosuachua.Location = New System.Drawing.Point(244, 3)
        Me.btnLydosuachua.LookAndFeel.SkinName = "Blue"
        Me.btnLydosuachua.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnLydosuachua.Name = "btnLydosuachua"
        Me.btnLydosuachua.Size = New System.Drawing.Size(104, 30)
        Me.btnLydosuachua.TabIndex = 30
        Me.btnLydosuachua.Text = "Lý do sửa chữa"
        '
        'BtnTroVe
        '
        Me.BtnTroVe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTroVe.Location = New System.Drawing.Point(1235, 3)
        Me.BtnTroVe.LookAndFeel.SkinName = "Blue"
        Me.BtnTroVe.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnTroVe.Name = "BtnTroVe"
        Me.BtnTroVe.Size = New System.Drawing.Size(104, 30)
        Me.BtnTroVe.TabIndex = 28
        Me.BtnTroVe.Text = "Trở về "
        Me.BtnTroVe.Visible = False
        '
        'btnXemNguyenNhan
        '
        Me.btnXemNguyenNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnXemNguyenNhan.Location = New System.Drawing.Point(349, 3)
        Me.btnXemNguyenNhan.LookAndFeel.SkinName = "Blue"
        Me.btnXemNguyenNhan.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXemNguyenNhan.Name = "btnXemNguyenNhan"
        Me.btnXemNguyenNhan.Size = New System.Drawing.Size(104, 30)
        Me.btnXemNguyenNhan.TabIndex = 23
        Me.btnXemNguyenNhan.Text = "Xem nguyên nhân"
        Me.btnXemNguyenNhan.Visible = False
        '
        'btnXoa
        '
        Me.btnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoa.Location = New System.Drawing.Point(1025, 3)
        Me.btnXoa.LookAndFeel.SkinName = "Blue"
        Me.btnXoa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(104, 30)
        Me.btnXoa.TabIndex = 19
        Me.btnXoa.Text = "Xóa"
        '
        'btnLPBT
        '
        Me.btnLPBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLPBT.Location = New System.Drawing.Point(815, 3)
        Me.btnLPBT.LookAndFeel.SkinName = "Blue"
        Me.btnLPBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnLPBT.Name = "btnLPBT"
        Me.btnLPBT.Size = New System.Drawing.Size(104, 30)
        Me.btnLPBT.TabIndex = 40
        Me.btnLPBT.Text = "Lập &phiếu BT"
        '
        'btnCapNhatMUT
        '
        Me.btnCapNhatMUT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCapNhatMUT.Location = New System.Drawing.Point(710, 3)
        Me.btnCapNhatMUT.LookAndFeel.SkinName = "Blue"
        Me.btnCapNhatMUT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnCapNhatMUT.Name = "btnCapNhatMUT"
        Me.btnCapNhatMUT.Size = New System.Drawing.Size(104, 30)
        Me.btnCapNhatMUT.TabIndex = 15
        Me.btnCapNhatMUT.Text = "btnCapNhatMUT"
        Me.btnCapNhatMUT.Visible = False
        '
        'btnChonCV
        '
        Me.btnChonCV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChonCV.Location = New System.Drawing.Point(920, 3)
        Me.btnChonCV.LookAndFeel.SkinName = "Blue"
        Me.btnChonCV.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnChonCV.Name = "btnChonCV"
        Me.btnChonCV.Size = New System.Drawing.Size(104, 30)
        Me.btnChonCV.TabIndex = 23
        Me.btnChonCV.Text = "Chọn công việc "
        '
        'btnChonMay
        '
        Me.btnChonMay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChonMay.Location = New System.Drawing.Point(1025, 3)
        Me.btnChonMay.LookAndFeel.SkinName = "Blue"
        Me.btnChonMay.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnChonMay.Name = "btnChonMay"
        Me.btnChonMay.Size = New System.Drawing.Size(104, 30)
        Me.btnChonMay.TabIndex = 31
        Me.btnChonMay.Text = "btnChonMay"
        '
        'btnChonPT
        '
        Me.btnChonPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChonPT.Location = New System.Drawing.Point(815, 3)
        Me.btnChonPT.LookAndFeel.SkinName = "Blue"
        Me.btnChonPT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnChonPT.Name = "btnChonPT"
        Me.btnChonPT.Size = New System.Drawing.Size(104, 30)
        Me.btnChonPT.TabIndex = 23
        Me.btnChonPT.Text = "Chọn phụ tùng "
        '
        'prbLapPhieuBaoTri
        '
        Me.prbLapPhieuBaoTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prbLapPhieuBaoTri.Location = New System.Drawing.Point(3, 589)
        Me.prbLapPhieuBaoTri.Name = "prbLapPhieuBaoTri"
        Me.prbLapPhieuBaoTri.Size = New System.Drawing.Size(1339, 18)
        Me.prbLapPhieuBaoTri.TabIndex = 26
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl1.Location = New System.Drawing.Point(3, 55)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.grpKehoachtongthe)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1339, 528)
        Me.SplitContainerControl1.SplitterPosition = 610
        Me.SplitContainerControl1.TabIndex = 27
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'grpKehoachtongthe
        '
        Me.grpKehoachtongthe.Controls.Add(Me.lblTong)
        Me.grpKehoachtongthe.Controls.Add(Me.gdKHTT)
        Me.grpKehoachtongthe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpKehoachtongthe.Location = New System.Drawing.Point(0, 0)
        Me.grpKehoachtongthe.Name = "grpKehoachtongthe"
        Me.grpKehoachtongthe.Size = New System.Drawing.Size(611, 528)
        Me.grpKehoachtongthe.TabIndex = 0
        Me.grpKehoachtongthe.Text = "grpKehoachtongthe"
        '
        'lblTong
        '
        Me.lblTong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTong.ForeColor = System.Drawing.Color.Navy
        Me.lblTong.Location = New System.Drawing.Point(457, 1)
        Me.lblTong.Name = "lblTong"
        Me.lblTong.Size = New System.Drawing.Size(148, 16)
        Me.lblTong.TabIndex = 1
        Me.lblTong.Text = "Tổng: 340"
        Me.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gdKHTT
        '
        Me.gdKHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdKHTT.Location = New System.Drawing.Point(2, 22)
        Me.gdKHTT.MainView = Me.gvKHTT
        Me.gdKHTT.Name = "gdKHTT"
        Me.gdKHTT.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gdKHTT.Size = New System.Drawing.Size(607, 504)
        Me.gdKHTT.TabIndex = 0
        Me.gdKHTT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvKHTT})
        '
        'gvKHTT
        '
        Me.gvKHTT.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.chxChoose, Me.cboMay, Me.TEN_MAY, Me.GridColumn2, Me.cboNgayLap, Me.cboNgayDKHT, Me.TONG_THOI_GIAN, Me.CBOLYDOSUACHUA, Me.HANG_MUC_ID, Me.cboMS_UU_TIEN, Me.cboMS_CN_PT, Me.GHI_CHU1, Me.YC_CHUNG, Me.YC_MO_TA, Me.YC, Me.MS_CN_GS})
        Me.gvKHTT.CustomizationFormBounds = New System.Drawing.Rectangle(1144, 408, 216, 183)
        Me.gvKHTT.GridControl = Me.gdKHTT
        Me.gvKHTT.Name = "gvKHTT"
        Me.gvKHTT.OptionsView.ColumnAutoWidth = False
        Me.gvKHTT.OptionsView.EnableAppearanceEvenRow = True
        Me.gvKHTT.OptionsView.EnableAppearanceOddRow = True
        Me.gvKHTT.OptionsView.ShowGroupPanel = False
        '
        'chxChoose
        '
        Me.chxChoose.Caption = "Choose"
        Me.chxChoose.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.chxChoose.FieldName = "Choose"
        Me.chxChoose.Name = "chxChoose"
        Me.chxChoose.Visible = True
        Me.chxChoose.VisibleIndex = 0
        Me.chxChoose.Width = 50
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AllowFocused = False
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'cboMay
        '
        Me.cboMay.AppearanceHeader.Options.UseFont = True
        Me.cboMay.AppearanceHeader.Options.UseTextOptions = True
        Me.cboMay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cboMay.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.cboMay.Caption = "cboMay"
        Me.cboMay.FieldName = "MS_MAY"
        Me.cboMay.Name = "cboMay"
        Me.cboMay.OptionsColumn.AllowEdit = False
        Me.cboMay.Visible = True
        Me.cboMay.VisibleIndex = 1
        Me.cboMay.Width = 160
        '
        'TEN_MAY
        '
        Me.TEN_MAY.AppearanceHeader.Options.UseFont = True
        Me.TEN_MAY.AppearanceHeader.Options.UseTextOptions = True
        Me.TEN_MAY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEN_MAY.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TEN_MAY.Caption = "TEN_MAY"
        Me.TEN_MAY.FieldName = "TEN_MAY"
        Me.TEN_MAY.Name = "TEN_MAY"
        Me.TEN_MAY.OptionsColumn.AllowEdit = False
        Me.TEN_MAY.OptionsColumn.FixedWidth = True
        Me.TEN_MAY.Visible = True
        Me.TEN_MAY.VisibleIndex = 2
        Me.TEN_MAY.Width = 197
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseFont = True
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridColumn2.Caption = "TEN_HANG_MUC"
        Me.GridColumn2.FieldName = "TEN_HANG_MUC"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        Me.GridColumn2.Width = 295
        '
        'cboNgayLap
        '
        Me.cboNgayLap.AppearanceHeader.Options.UseFont = True
        Me.cboNgayLap.AppearanceHeader.Options.UseTextOptions = True
        Me.cboNgayLap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cboNgayLap.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.cboNgayLap.Caption = "cboNgayLap"
        Me.cboNgayLap.FieldName = "NGAY"
        Me.cboNgayLap.Name = "cboNgayLap"
        Me.cboNgayLap.OptionsColumn.AllowEdit = False
        Me.cboNgayLap.Visible = True
        Me.cboNgayLap.VisibleIndex = 4
        Me.cboNgayLap.Width = 110
        '
        'cboNgayDKHT
        '
        Me.cboNgayDKHT.AppearanceHeader.Options.UseFont = True
        Me.cboNgayDKHT.AppearanceHeader.Options.UseTextOptions = True
        Me.cboNgayDKHT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cboNgayDKHT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.cboNgayDKHT.Caption = "cboNgayDKHT"
        Me.cboNgayDKHT.FieldName = "NGAY_DK_HT"
        Me.cboNgayDKHT.Name = "cboNgayDKHT"
        Me.cboNgayDKHT.OptionsColumn.AllowEdit = False
        Me.cboNgayDKHT.Visible = True
        Me.cboNgayDKHT.VisibleIndex = 5
        Me.cboNgayDKHT.Width = 105
        '
        'TONG_THOI_GIAN
        '
        Me.TONG_THOI_GIAN.AppearanceHeader.Options.UseFont = True
        Me.TONG_THOI_GIAN.AppearanceHeader.Options.UseTextOptions = True
        Me.TONG_THOI_GIAN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TONG_THOI_GIAN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TONG_THOI_GIAN.Caption = "Tổng thời gian"
        Me.TONG_THOI_GIAN.FieldName = "TONG_THOI_GIAN"
        Me.TONG_THOI_GIAN.Name = "TONG_THOI_GIAN"
        Me.TONG_THOI_GIAN.OptionsColumn.AllowEdit = False
        Me.TONG_THOI_GIAN.Visible = True
        Me.TONG_THOI_GIAN.VisibleIndex = 6
        Me.TONG_THOI_GIAN.Width = 60
        '
        'CBOLYDOSUACHUA
        '
        Me.CBOLYDOSUACHUA.AppearanceHeader.Options.UseFont = True
        Me.CBOLYDOSUACHUA.AppearanceHeader.Options.UseTextOptions = True
        Me.CBOLYDOSUACHUA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CBOLYDOSUACHUA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CBOLYDOSUACHUA.Caption = "CBOLYDOSUACHUA"
        Me.CBOLYDOSUACHUA.FieldName = "LY_DO_SC"
        Me.CBOLYDOSUACHUA.Name = "CBOLYDOSUACHUA"
        Me.CBOLYDOSUACHUA.OptionsColumn.AllowEdit = False
        Me.CBOLYDOSUACHUA.Visible = True
        Me.CBOLYDOSUACHUA.VisibleIndex = 7
        Me.CBOLYDOSUACHUA.Width = 250
        '
        'HANG_MUC_ID
        '
        Me.HANG_MUC_ID.AppearanceHeader.Options.UseFont = True
        Me.HANG_MUC_ID.AppearanceHeader.Options.UseTextOptions = True
        Me.HANG_MUC_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.HANG_MUC_ID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.HANG_MUC_ID.Caption = "HANG_MUC_ID"
        Me.HANG_MUC_ID.FieldName = "HANG_MUC_ID"
        Me.HANG_MUC_ID.Name = "HANG_MUC_ID"
        Me.HANG_MUC_ID.OptionsColumn.AllowEdit = False
        '
        'cboMS_UU_TIEN
        '
        Me.cboMS_UU_TIEN.AppearanceHeader.Options.UseFont = True
        Me.cboMS_UU_TIEN.AppearanceHeader.Options.UseTextOptions = True
        Me.cboMS_UU_TIEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cboMS_UU_TIEN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.cboMS_UU_TIEN.Caption = "MS_UU_TIEN"
        Me.cboMS_UU_TIEN.FieldName = "MS_UU_TIEN"
        Me.cboMS_UU_TIEN.Name = "cboMS_UU_TIEN"
        Me.cboMS_UU_TIEN.OptionsColumn.AllowEdit = False
        Me.cboMS_UU_TIEN.Visible = True
        Me.cboMS_UU_TIEN.VisibleIndex = 8
        Me.cboMS_UU_TIEN.Width = 136
        '
        'cboMS_CN_PT
        '
        Me.cboMS_CN_PT.AppearanceHeader.Options.UseFont = True
        Me.cboMS_CN_PT.AppearanceHeader.Options.UseTextOptions = True
        Me.cboMS_CN_PT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cboMS_CN_PT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.cboMS_CN_PT.Caption = "MS_CONG_NHAN"
        Me.cboMS_CN_PT.FieldName = "MS_CONG_NHAN"
        Me.cboMS_CN_PT.Name = "cboMS_CN_PT"
        Me.cboMS_CN_PT.OptionsColumn.AllowEdit = False
        Me.cboMS_CN_PT.Visible = True
        Me.cboMS_CN_PT.VisibleIndex = 9
        Me.cboMS_CN_PT.Width = 200
        '
        'GHI_CHU1
        '
        Me.GHI_CHU1.AppearanceHeader.Options.UseFont = True
        Me.GHI_CHU1.AppearanceHeader.Options.UseTextOptions = True
        Me.GHI_CHU1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GHI_CHU1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GHI_CHU1.Caption = "GHI_CHU"
        Me.GHI_CHU1.FieldName = "GHI_CHU"
        Me.GHI_CHU1.Name = "GHI_CHU1"
        Me.GHI_CHU1.OptionsColumn.AllowEdit = False
        Me.GHI_CHU1.Visible = True
        Me.GHI_CHU1.VisibleIndex = 10
        Me.GHI_CHU1.Width = 359
        '
        'YC_CHUNG
        '
        Me.YC_CHUNG.AppearanceHeader.Options.UseFont = True
        Me.YC_CHUNG.AppearanceHeader.Options.UseTextOptions = True
        Me.YC_CHUNG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.YC_CHUNG.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.YC_CHUNG.Caption = "YC_CHUNG"
        Me.YC_CHUNG.FieldName = "YC_CHUNG"
        Me.YC_CHUNG.Name = "YC_CHUNG"
        Me.YC_CHUNG.Visible = True
        Me.YC_CHUNG.VisibleIndex = 11
        Me.YC_CHUNG.Width = 300
        '
        'YC_MO_TA
        '
        Me.YC_MO_TA.AppearanceHeader.Options.UseFont = True
        Me.YC_MO_TA.AppearanceHeader.Options.UseTextOptions = True
        Me.YC_MO_TA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.YC_MO_TA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.YC_MO_TA.Caption = "YC_MO_TA"
        Me.YC_MO_TA.FieldName = "YC_MO_TA"
        Me.YC_MO_TA.Name = "YC_MO_TA"
        Me.YC_MO_TA.Visible = True
        Me.YC_MO_TA.VisibleIndex = 12
        Me.YC_MO_TA.Width = 300
        '
        'YC
        '
        Me.YC.AppearanceHeader.Options.UseFont = True
        Me.YC.AppearanceHeader.Options.UseTextOptions = True
        Me.YC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.YC.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.YC.Caption = "YC"
        Me.YC.FieldName = "YC"
        Me.YC.Name = "YC"
        Me.YC.Visible = True
        Me.YC.VisibleIndex = 13
        Me.YC.Width = 300
        '
        'MS_CN_GS
        '
        Me.MS_CN_GS.Caption = "MS_CN_GS"
        Me.MS_CN_GS.FieldName = "MS_CN_GS"
        Me.MS_CN_GS.Name = "MS_CN_GS"
        Me.MS_CN_GS.OptionsColumn.ReadOnly = True
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.grpKehoachtongcongviec)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.grpKehoachtongcongviecVT)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(722, 528)
        Me.SplitContainerControl2.SplitterPosition = 269
        Me.SplitContainerControl2.TabIndex = 28
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'grpKehoachtongcongviec
        '
        Me.grpKehoachtongcongviec.Controls.Add(Me.gdCVTT)
        Me.grpKehoachtongcongviec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpKehoachtongcongviec.Location = New System.Drawing.Point(0, 0)
        Me.grpKehoachtongcongviec.Name = "grpKehoachtongcongviec"
        Me.grpKehoachtongcongviec.Size = New System.Drawing.Size(722, 269)
        Me.grpKehoachtongcongviec.TabIndex = 0
        Me.grpKehoachtongcongviec.Text = "grpKehoachtongcongviec"
        '
        'gdCVTT
        '
        Me.gdCVTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdCVTT.Location = New System.Drawing.Point(2, 22)
        Me.gdCVTT.MainView = Me.gvCVTT
        Me.gdCVTT.Name = "gdCVTT"
        Me.gdCVTT.Size = New System.Drawing.Size(718, 245)
        Me.gdCVTT.TabIndex = 1
        Me.gdCVTT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCVTT})
        '
        'gvCVTT
        '
        Me.gvCVTT.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TEN_BO_PHAN, Me.TEN_CONG_VIEC, Me.MS_UU_TIEN, Me.MS_PHIEU_BAO_TRI, Me.THUE_NGOAI, Me.KHONG_GQ, Me._GHI_CHU, Me.MS_CV, Me.MS_BO_PHAN, Me._HANG_MUC_ID1, Me.THOI_GIAN_DU_KIEN, Me.SNGUOI, Me.YCAU_NS, Me.YCAU_DC, Me.THAO_TAC, Me.TIEU_CHUAN_KT, Me.TEN_TINH_TRANG})
        Me.gvCVTT.GridControl = Me.gdCVTT
        Me.gvCVTT.Name = "gvCVTT"
        Me.gvCVTT.OptionsView.ColumnAutoWidth = False
        Me.gvCVTT.OptionsView.EnableAppearanceEvenRow = True
        Me.gvCVTT.OptionsView.EnableAppearanceOddRow = True
        Me.gvCVTT.OptionsView.ShowGroupPanel = False
        '
        'TEN_BO_PHAN
        '
        Me.TEN_BO_PHAN.AppearanceHeader.Options.UseFont = True
        Me.TEN_BO_PHAN.AppearanceHeader.Options.UseTextOptions = True
        Me.TEN_BO_PHAN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEN_BO_PHAN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TEN_BO_PHAN.Caption = "TEN_BO_PHAN"
        Me.TEN_BO_PHAN.FieldName = "TEN_BO_PHAN"
        Me.TEN_BO_PHAN.Name = "TEN_BO_PHAN"
        Me.TEN_BO_PHAN.OptionsColumn.AllowEdit = False
        Me.TEN_BO_PHAN.Visible = True
        Me.TEN_BO_PHAN.VisibleIndex = 0
        Me.TEN_BO_PHAN.Width = 187
        '
        'TEN_CONG_VIEC
        '
        Me.TEN_CONG_VIEC.AppearanceHeader.Options.UseFont = True
        Me.TEN_CONG_VIEC.AppearanceHeader.Options.UseTextOptions = True
        Me.TEN_CONG_VIEC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEN_CONG_VIEC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TEN_CONG_VIEC.Caption = "TEN_CONG_VIEC"
        Me.TEN_CONG_VIEC.FieldName = "MO_TA_CV"
        Me.TEN_CONG_VIEC.Name = "TEN_CONG_VIEC"
        Me.TEN_CONG_VIEC.OptionsColumn.AllowEdit = False
        Me.TEN_CONG_VIEC.Visible = True
        Me.TEN_CONG_VIEC.VisibleIndex = 1
        Me.TEN_CONG_VIEC.Width = 207
        '
        'MS_UU_TIEN
        '
        Me.MS_UU_TIEN.AppearanceHeader.Options.UseFont = True
        Me.MS_UU_TIEN.AppearanceHeader.Options.UseTextOptions = True
        Me.MS_UU_TIEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MS_UU_TIEN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MS_UU_TIEN.Caption = "cboMucUuTien"
        Me.MS_UU_TIEN.FieldName = "MS_UU_TIEN"
        Me.MS_UU_TIEN.Name = "MS_UU_TIEN"
        Me.MS_UU_TIEN.OptionsColumn.AllowEdit = False
        Me.MS_UU_TIEN.Visible = True
        Me.MS_UU_TIEN.VisibleIndex = 8
        Me.MS_UU_TIEN.Width = 91
        '
        'MS_PHIEU_BAO_TRI
        '
        Me.MS_PHIEU_BAO_TRI.AppearanceHeader.Options.UseFont = True
        Me.MS_PHIEU_BAO_TRI.AppearanceHeader.Options.UseTextOptions = True
        Me.MS_PHIEU_BAO_TRI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MS_PHIEU_BAO_TRI.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MS_PHIEU_BAO_TRI.Caption = "MS_PHIEU_BAO_TRI"
        Me.MS_PHIEU_BAO_TRI.FieldName = "MS_PHIEU_BAO_TRI"
        Me.MS_PHIEU_BAO_TRI.Name = "MS_PHIEU_BAO_TRI"
        Me.MS_PHIEU_BAO_TRI.OptionsColumn.AllowEdit = False
        Me.MS_PHIEU_BAO_TRI.Visible = True
        Me.MS_PHIEU_BAO_TRI.VisibleIndex = 9
        Me.MS_PHIEU_BAO_TRI.Width = 97
        '
        'THUE_NGOAI
        '
        Me.THUE_NGOAI.AppearanceHeader.Options.UseFont = True
        Me.THUE_NGOAI.AppearanceHeader.Options.UseTextOptions = True
        Me.THUE_NGOAI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.THUE_NGOAI.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.THUE_NGOAI.Caption = "THUE_NGOAI"
        Me.THUE_NGOAI.FieldName = "THUE_NGOAI"
        Me.THUE_NGOAI.Name = "THUE_NGOAI"
        Me.THUE_NGOAI.OptionsColumn.AllowEdit = False
        Me.THUE_NGOAI.Visible = True
        Me.THUE_NGOAI.VisibleIndex = 11
        '
        'KHONG_GQ
        '
        Me.KHONG_GQ.AppearanceHeader.Options.UseFont = True
        Me.KHONG_GQ.AppearanceHeader.Options.UseTextOptions = True
        Me.KHONG_GQ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.KHONG_GQ.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.KHONG_GQ.Caption = "KHONG_GQ"
        Me.KHONG_GQ.FieldName = "KHONG_GQ"
        Me.KHONG_GQ.Name = "KHONG_GQ"
        Me.KHONG_GQ.OptionsColumn.AllowEdit = False
        Me.KHONG_GQ.Visible = True
        Me.KHONG_GQ.VisibleIndex = 12
        '
        '_GHI_CHU
        '
        Me._GHI_CHU.AppearanceHeader.Options.UseFont = True
        Me._GHI_CHU.AppearanceHeader.Options.UseTextOptions = True
        Me._GHI_CHU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me._GHI_CHU.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me._GHI_CHU.Caption = "GHI_CHU"
        Me._GHI_CHU.FieldName = "GHI_CHU"
        Me._GHI_CHU.Name = "_GHI_CHU"
        Me._GHI_CHU.OptionsColumn.AllowEdit = False
        Me._GHI_CHU.Visible = True
        Me._GHI_CHU.VisibleIndex = 13
        '
        'MS_CV
        '
        Me.MS_CV.AppearanceHeader.Options.UseFont = True
        Me.MS_CV.Caption = "GridColumn7"
        Me.MS_CV.FieldName = "MS_CV"
        Me.MS_CV.Name = "MS_CV"
        '
        'MS_BO_PHAN
        '
        Me.MS_BO_PHAN.AppearanceHeader.Options.UseFont = True
        Me.MS_BO_PHAN.Caption = "GridColumn8"
        Me.MS_BO_PHAN.FieldName = "MS_BO_PHAN"
        Me.MS_BO_PHAN.Name = "MS_BO_PHAN"
        '
        '_HANG_MUC_ID1
        '
        Me._HANG_MUC_ID1.AppearanceHeader.Options.UseFont = True
        Me._HANG_MUC_ID1.Caption = "HANG_MUC_ID"
        Me._HANG_MUC_ID1.FieldName = "HANG_MUC_ID"
        Me._HANG_MUC_ID1.Name = "_HANG_MUC_ID1"
        '
        'THOI_GIAN_DU_KIEN
        '
        Me.THOI_GIAN_DU_KIEN.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.THOI_GIAN_DU_KIEN.AppearanceHeader.Options.UseFont = True
        Me.THOI_GIAN_DU_KIEN.Caption = "THOI_GIAN_DU_KIEN"
        Me.THOI_GIAN_DU_KIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.THOI_GIAN_DU_KIEN.FieldName = "THOI_GIAN_DU_KIEN"
        Me.THOI_GIAN_DU_KIEN.Name = "THOI_GIAN_DU_KIEN"
        Me.THOI_GIAN_DU_KIEN.Visible = True
        Me.THOI_GIAN_DU_KIEN.VisibleIndex = 2
        '
        'SNGUOI
        '
        Me.SNGUOI.AppearanceHeader.Options.UseFont = True
        Me.SNGUOI.AppearanceHeader.Options.UseTextOptions = True
        Me.SNGUOI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SNGUOI.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SNGUOI.Caption = "SNGUOI"
        Me.SNGUOI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SNGUOI.FieldName = "SNGUOI"
        Me.SNGUOI.Name = "SNGUOI"
        Me.SNGUOI.Visible = True
        Me.SNGUOI.VisibleIndex = 3
        '
        'YCAU_NS
        '
        Me.YCAU_NS.AppearanceHeader.Options.UseFont = True
        Me.YCAU_NS.AppearanceHeader.Options.UseTextOptions = True
        Me.YCAU_NS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.YCAU_NS.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.YCAU_NS.Caption = "YCAU_NS"
        Me.YCAU_NS.FieldName = "YCAU_NS"
        Me.YCAU_NS.Name = "YCAU_NS"
        Me.YCAU_NS.Visible = True
        Me.YCAU_NS.VisibleIndex = 4
        '
        'YCAU_DC
        '
        Me.YCAU_DC.AppearanceHeader.Options.UseFont = True
        Me.YCAU_DC.AppearanceHeader.Options.UseTextOptions = True
        Me.YCAU_DC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.YCAU_DC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.YCAU_DC.Caption = "YCAU_DC"
        Me.YCAU_DC.FieldName = "YCAU_DC"
        Me.YCAU_DC.Name = "YCAU_DC"
        Me.YCAU_DC.Visible = True
        Me.YCAU_DC.VisibleIndex = 5
        '
        'THAO_TAC
        '
        Me.THAO_TAC.AppearanceHeader.Options.UseFont = True
        Me.THAO_TAC.AppearanceHeader.Options.UseTextOptions = True
        Me.THAO_TAC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.THAO_TAC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.THAO_TAC.Caption = "THAO_TAC"
        Me.THAO_TAC.FieldName = "THAO_TAC"
        Me.THAO_TAC.Name = "THAO_TAC"
        Me.THAO_TAC.Visible = True
        Me.THAO_TAC.VisibleIndex = 6
        '
        'TIEU_CHUAN_KT
        '
        Me.TIEU_CHUAN_KT.AppearanceHeader.Options.UseFont = True
        Me.TIEU_CHUAN_KT.AppearanceHeader.Options.UseTextOptions = True
        Me.TIEU_CHUAN_KT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TIEU_CHUAN_KT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TIEU_CHUAN_KT.Caption = "TIEU_CHUAN_KT"
        Me.TIEU_CHUAN_KT.FieldName = "TIEU_CHUAN_KT"
        Me.TIEU_CHUAN_KT.Name = "TIEU_CHUAN_KT"
        Me.TIEU_CHUAN_KT.Visible = True
        Me.TIEU_CHUAN_KT.VisibleIndex = 7
        '
        'TEN_TINH_TRANG
        '
        Me.TEN_TINH_TRANG.AppearanceHeader.Options.UseFont = True
        Me.TEN_TINH_TRANG.AppearanceHeader.Options.UseTextOptions = True
        Me.TEN_TINH_TRANG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEN_TINH_TRANG.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TEN_TINH_TRANG.Caption = "TEN_TINH_TRANG"
        Me.TEN_TINH_TRANG.FieldName = "TEN_TINH_TRANG"
        Me.TEN_TINH_TRANG.Name = "TEN_TINH_TRANG"
        Me.TEN_TINH_TRANG.OptionsColumn.AllowEdit = False
        Me.TEN_TINH_TRANG.Visible = True
        Me.TEN_TINH_TRANG.VisibleIndex = 10
        '
        'grpKehoachtongcongviecVT
        '
        Me.grpKehoachtongcongviecVT.Controls.Add(Me.gdVTTT)
        Me.grpKehoachtongcongviecVT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpKehoachtongcongviecVT.Location = New System.Drawing.Point(0, 0)
        Me.grpKehoachtongcongviecVT.Name = "grpKehoachtongcongviecVT"
        Me.grpKehoachtongcongviecVT.Size = New System.Drawing.Size(722, 253)
        Me.grpKehoachtongcongviecVT.TabIndex = 0
        Me.grpKehoachtongcongviecVT.Text = "grpKehoachtongcongviecVT"
        '
        'gdVTTT
        '
        Me.gdVTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdVTTT.Location = New System.Drawing.Point(2, 22)
        Me.gdVTTT.MainView = Me.gvVTTT
        Me.gdVTTT.Name = "gdVTTT"
        Me.gdVTTT.Size = New System.Drawing.Size(718, 229)
        Me.gdVTTT.TabIndex = 0
        Me.gdVTTT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvVTTT})
        '
        'gvVTTT
        '
        Me.gvVTTT.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MS_PT, Me.TEN_PT, Me.QUY_CACH, Me.SO_LUONG, Me.TEN_DVT, Me.GHI_CHU2, Me.DON_GIA_KH, Me.TIEN_TE_KH, Me.TY_GIA_KH, Me.TY_GIA_USD_KH, Me.DON_GIA_CUOI, Me.NGAY_LAY_DG_KH})
        Me.gvVTTT.GridControl = Me.gdVTTT
        Me.gvVTTT.Name = "gvVTTT"
        Me.gvVTTT.OptionsView.ColumnAutoWidth = False
        Me.gvVTTT.OptionsView.EnableAppearanceEvenRow = True
        Me.gvVTTT.OptionsView.EnableAppearanceOddRow = True
        Me.gvVTTT.OptionsView.ShowGroupPanel = False
        '
        'MS_PT
        '
        Me.MS_PT.AppearanceHeader.Options.UseFont = True
        Me.MS_PT.AppearanceHeader.Options.UseTextOptions = True
        Me.MS_PT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MS_PT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MS_PT.Caption = "MS_PT"
        Me.MS_PT.FieldName = "MS_PT"
        Me.MS_PT.Name = "MS_PT"
        Me.MS_PT.OptionsColumn.AllowEdit = False
        Me.MS_PT.Visible = True
        Me.MS_PT.VisibleIndex = 0
        Me.MS_PT.Width = 135
        '
        'TEN_PT
        '
        Me.TEN_PT.AppearanceHeader.Options.UseFont = True
        Me.TEN_PT.AppearanceHeader.Options.UseTextOptions = True
        Me.TEN_PT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEN_PT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TEN_PT.Caption = "TEN_PT"
        Me.TEN_PT.FieldName = "TEN_PT"
        Me.TEN_PT.Name = "TEN_PT"
        Me.TEN_PT.OptionsColumn.AllowEdit = False
        Me.TEN_PT.Visible = True
        Me.TEN_PT.VisibleIndex = 1
        Me.TEN_PT.Width = 167
        '
        'QUY_CACH
        '
        Me.QUY_CACH.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUY_CACH.AppearanceHeader.Options.UseFont = True
        Me.QUY_CACH.Caption = "QUY_CACH"
        Me.QUY_CACH.FieldName = "QUY_CACH"
        Me.QUY_CACH.Name = "QUY_CACH"
        Me.QUY_CACH.OptionsColumn.AllowEdit = False
        Me.QUY_CACH.Visible = True
        Me.QUY_CACH.VisibleIndex = 2
        '
        'SO_LUONG
        '
        Me.SO_LUONG.AppearanceHeader.Options.UseFont = True
        Me.SO_LUONG.AppearanceHeader.Options.UseTextOptions = True
        Me.SO_LUONG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SO_LUONG.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SO_LUONG.Caption = "SO_LUONG"
        Me.SO_LUONG.FieldName = "SO_LUONG"
        Me.SO_LUONG.Name = "SO_LUONG"
        Me.SO_LUONG.OptionsColumn.AllowEdit = False
        Me.SO_LUONG.Visible = True
        Me.SO_LUONG.VisibleIndex = 3
        Me.SO_LUONG.Width = 79
        '
        'TEN_DVT
        '
        Me.TEN_DVT.AppearanceHeader.Options.UseFont = True
        Me.TEN_DVT.AppearanceHeader.Options.UseTextOptions = True
        Me.TEN_DVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEN_DVT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TEN_DVT.Caption = "TEN_DVT"
        Me.TEN_DVT.FieldName = "TEN_DVT"
        Me.TEN_DVT.Name = "TEN_DVT"
        Me.TEN_DVT.OptionsColumn.AllowEdit = False
        Me.TEN_DVT.Visible = True
        Me.TEN_DVT.VisibleIndex = 4
        '
        'GHI_CHU2
        '
        Me.GHI_CHU2.AppearanceHeader.Options.UseFont = True
        Me.GHI_CHU2.AppearanceHeader.Options.UseTextOptions = True
        Me.GHI_CHU2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GHI_CHU2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GHI_CHU2.Caption = "GHI_CHU"
        Me.GHI_CHU2.FieldName = "GHI_CHU"
        Me.GHI_CHU2.Name = "GHI_CHU2"
        Me.GHI_CHU2.OptionsColumn.AllowEdit = False
        Me.GHI_CHU2.Visible = True
        Me.GHI_CHU2.VisibleIndex = 5
        '
        'DON_GIA_KH
        '
        Me.DON_GIA_KH.Caption = "DON_GIA_KH"
        Me.DON_GIA_KH.FieldName = "DON_GIA_KH"
        Me.DON_GIA_KH.Name = "DON_GIA_KH"
        Me.DON_GIA_KH.Visible = True
        Me.DON_GIA_KH.VisibleIndex = 6
        '
        'TIEN_TE_KH
        '
        Me.TIEN_TE_KH.Caption = "TIEN_TE_KH"
        Me.TIEN_TE_KH.FieldName = "TIEN_TE_KH"
        Me.TIEN_TE_KH.Name = "TIEN_TE_KH"
        Me.TIEN_TE_KH.Visible = True
        Me.TIEN_TE_KH.VisibleIndex = 7
        '
        'TY_GIA_KH
        '
        Me.TY_GIA_KH.Caption = "TY_GIA_KH"
        Me.TY_GIA_KH.FieldName = "TY_GIA_KH"
        Me.TY_GIA_KH.Name = "TY_GIA_KH"
        Me.TY_GIA_KH.Visible = True
        Me.TY_GIA_KH.VisibleIndex = 8
        '
        'TY_GIA_USD_KH
        '
        Me.TY_GIA_USD_KH.Caption = "TY_GIA_USD_KH"
        Me.TY_GIA_USD_KH.FieldName = "TY_GIA_USD_KH"
        Me.TY_GIA_USD_KH.Name = "TY_GIA_USD_KH"
        Me.TY_GIA_USD_KH.Visible = True
        Me.TY_GIA_USD_KH.VisibleIndex = 9
        '
        'DON_GIA_CUOI
        '
        Me.DON_GIA_CUOI.Caption = "DON_GIA_CUOI"
        Me.DON_GIA_CUOI.FieldName = "DON_GIA_CUOI"
        Me.DON_GIA_CUOI.Name = "DON_GIA_CUOI"
        Me.DON_GIA_CUOI.OptionsColumn.AllowEdit = False
        Me.DON_GIA_CUOI.OptionsColumn.ReadOnly = True
        Me.DON_GIA_CUOI.Visible = True
        Me.DON_GIA_CUOI.VisibleIndex = 10
        '
        'NGAY_LAY_DG_KH
        '
        Me.NGAY_LAY_DG_KH.Caption = "NGAY_LAY_DG_KH"
        Me.NGAY_LAY_DG_KH.FieldName = "NGAY_LAY_DG_KH"
        Me.NGAY_LAY_DG_KH.Name = "NGAY_LAY_DG_KH"
        Me.NGAY_LAY_DG_KH.OptionsColumn.AllowEdit = False
        Me.NGAY_LAY_DG_KH.OptionsColumn.ReadOnly = True
        Me.NGAY_LAY_DG_KH.Visible = True
        Me.NGAY_LAY_DG_KH.VisibleIndex = 11
        '
        'tabGSTT
        '
        Me.tabGSTT.Controls.Add(Me.TableLayoutPanel5)
        Me.tabGSTT.Name = "tabGSTT"
        Me.tabGSTT.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGSTT.Size = New System.Drawing.Size(1351, 655)
        Me.tabGSTT.Text = "Thiết bị có TSGSTT không đạt"
        '
        'TabYeucaunguoisudung
        '
        Me.TabYeucaunguoisudung.Controls.Add(Me.TableLayoutPanel7)
        Me.TabYeucaunguoisudung.Name = "TabYeucaunguoisudung"
        Me.TabYeucaunguoisudung.Padding = New System.Windows.Forms.Padding(3)
        Me.TabYeucaunguoisudung.Size = New System.Drawing.Size(1351, 655)
        Me.TabYeucaunguoisudung.Text = "Yêu cầu người sử dụng"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 4
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.grpDieuKienLoc3, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.grpYEU_CAU_NSD, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.btnThoat3, 3, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.btnThucHien2, 2, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.btnXemBangChung2, 1, 2)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 3
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(1345, 649)
        Me.TableLayoutPanel7.TabIndex = 1
        '
        'grpDieuKienLoc3
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.grpDieuKienLoc3, 4)
        Me.grpDieuKienLoc3.Controls.Add(Me.TableLayoutPanel11)
        Me.grpDieuKienLoc3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDieuKienLoc3.ForeColor = System.Drawing.Color.Maroon
        Me.grpDieuKienLoc3.Location = New System.Drawing.Point(3, 3)
        Me.grpDieuKienLoc3.Name = "grpDieuKienLoc3"
        Me.grpDieuKienLoc3.Size = New System.Drawing.Size(1339, 46)
        Me.grpDieuKienLoc3.TabIndex = 0
        Me.grpDieuKienLoc3.TabStop = False
        Me.grpDieuKienLoc3.Text = "Điều kiện lọc"
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 9
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.radChuaGiaiQuyet3, 1, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.RadBoQua3, 2, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.lblDenNgay3, 6, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.radDaGiaiQuyet3, 3, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.lblTuNgay3, 4, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.dtpDNYCSD, 7, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.dtpTNYCSD, 5, 0)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(1333, 26)
        Me.TableLayoutPanel11.TabIndex = 13
        '
        'radChuaGiaiQuyet3
        '
        Me.radChuaGiaiQuyet3.AutoSize = True
        Me.radChuaGiaiQuyet3.Checked = True
        Me.radChuaGiaiQuyet3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radChuaGiaiQuyet3.ForeColor = System.Drawing.Color.Black
        Me.radChuaGiaiQuyet3.Location = New System.Drawing.Point(284, 3)
        Me.radChuaGiaiQuyet3.Name = "radChuaGiaiQuyet3"
        Me.radChuaGiaiQuyet3.Size = New System.Drawing.Size(104, 20)
        Me.radChuaGiaiQuyet3.TabIndex = 6
        Me.radChuaGiaiQuyet3.TabStop = True
        Me.radChuaGiaiQuyet3.Text = "Chưa giải quyết"
        Me.radChuaGiaiQuyet3.UseVisualStyleBackColor = True
        '
        'RadBoQua3
        '
        Me.RadBoQua3.AutoSize = True
        Me.RadBoQua3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadBoQua3.ForeColor = System.Drawing.Color.Black
        Me.RadBoQua3.Location = New System.Drawing.Point(394, 3)
        Me.RadBoQua3.Name = "RadBoQua3"
        Me.RadBoQua3.Size = New System.Drawing.Size(104, 20)
        Me.RadBoQua3.TabIndex = 12
        Me.RadBoQua3.Text = "YC bị bỏ qua "
        Me.RadBoQua3.UseVisualStyleBackColor = True
        '
        'lblDenNgay3
        '
        Me.lblDenNgay3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNgay3.ForeColor = System.Drawing.Color.Black
        Me.lblDenNgay3.Location = New System.Drawing.Point(834, 0)
        Me.lblDenNgay3.Name = "lblDenNgay3"
        Me.lblDenNgay3.Size = New System.Drawing.Size(104, 26)
        Me.lblDenNgay3.TabIndex = 9
        Me.lblDenNgay3.Text = "Đến ngày"
        Me.lblDenNgay3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'radDaGiaiQuyet3
        '
        Me.radDaGiaiQuyet3.AutoSize = True
        Me.radDaGiaiQuyet3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDaGiaiQuyet3.ForeColor = System.Drawing.Color.Black
        Me.radDaGiaiQuyet3.Location = New System.Drawing.Point(504, 3)
        Me.radDaGiaiQuyet3.Name = "radDaGiaiQuyet3"
        Me.radDaGiaiQuyet3.Size = New System.Drawing.Size(104, 20)
        Me.radDaGiaiQuyet3.TabIndex = 7
        Me.radDaGiaiQuyet3.Text = "Đã giải quyết"
        Me.radDaGiaiQuyet3.UseVisualStyleBackColor = True
        '
        'lblTuNgay3
        '
        Me.lblTuNgay3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTuNgay3.ForeColor = System.Drawing.Color.Black
        Me.lblTuNgay3.Location = New System.Drawing.Point(614, 0)
        Me.lblTuNgay3.Name = "lblTuNgay3"
        Me.lblTuNgay3.Size = New System.Drawing.Size(104, 26)
        Me.lblTuNgay3.TabIndex = 8
        Me.lblTuNgay3.Text = "Từ ngày"
        Me.lblTuNgay3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDNYCSD
        '
        Me.dtpDNYCSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDNYCSD.EditValue = Nothing
        Me.dtpDNYCSD.Location = New System.Drawing.Point(944, 3)
        Me.dtpDNYCSD.Name = "dtpDNYCSD"
        Me.dtpDNYCSD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDNYCSD.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpDNYCSD.Size = New System.Drawing.Size(104, 20)
        Me.dtpDNYCSD.TabIndex = 13
        '
        'dtpTNYCSD
        '
        Me.dtpTNYCSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTNYCSD.EditValue = Nothing
        Me.dtpTNYCSD.Location = New System.Drawing.Point(724, 3)
        Me.dtpTNYCSD.Name = "dtpTNYCSD"
        Me.dtpTNYCSD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpTNYCSD.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpTNYCSD.Size = New System.Drawing.Size(104, 20)
        Me.dtpTNYCSD.TabIndex = 13
        '
        'grpYEU_CAU_NSD
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.grpYEU_CAU_NSD, 4)
        Me.grpYEU_CAU_NSD.Controls.Add(Me.gdYCNSD)
        Me.grpYEU_CAU_NSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpYEU_CAU_NSD.ForeColor = System.Drawing.Color.Navy
        Me.grpYEU_CAU_NSD.Location = New System.Drawing.Point(3, 55)
        Me.grpYEU_CAU_NSD.Name = "grpYEU_CAU_NSD"
        Me.grpYEU_CAU_NSD.Size = New System.Drawing.Size(1339, 555)
        Me.grpYEU_CAU_NSD.TabIndex = 2
        Me.grpYEU_CAU_NSD.TabStop = False
        Me.grpYEU_CAU_NSD.Text = "DS yêu cầu của người sử dụng "
        '
        'gdYCNSD
        '
        Me.gdYCNSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdYCNSD.Location = New System.Drawing.Point(3, 17)
        Me.gdYCNSD.MainView = Me.gvYCNSD
        Me.gdYCNSD.Name = "gdYCNSD"
        Me.gdYCNSD.Size = New System.Drawing.Size(1333, 535)
        Me.gdYCNSD.TabIndex = 1
        Me.gdYCNSD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvYCNSD})
        '
        'gvYCNSD
        '
        Me.gvYCNSD.GridControl = Me.gdYCNSD
        Me.gvYCNSD.Name = "gvYCNSD"
        Me.gvYCNSD.OptionsView.ColumnAutoWidth = False
        Me.gvYCNSD.OptionsView.ShowGroupPanel = False
        '
        'btnThoat3
        '
        Me.btnThoat3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat3.Location = New System.Drawing.Point(1238, 616)
        Me.btnThoat3.LookAndFeel.SkinName = "Blue"
        Me.btnThoat3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat3.Name = "btnThoat3"
        Me.btnThoat3.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat3.TabIndex = 34
        Me.btnThoat3.Text = "T&hoát"
        '
        'btnThucHien2
        '
        Me.btnThucHien2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien2.Location = New System.Drawing.Point(1128, 616)
        Me.btnThucHien2.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien2.Name = "btnThucHien2"
        Me.btnThucHien2.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien2.TabIndex = 34
        Me.btnThucHien2.Text = "Thực hiện "
        '
        'btnXemBangChung2
        '
        Me.btnXemBangChung2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnXemBangChung2.Location = New System.Drawing.Point(988, 616)
        Me.btnXemBangChung2.LookAndFeel.SkinName = "Blue"
        Me.btnXemBangChung2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXemBangChung2.Name = "btnXemBangChung2"
        Me.btnXemBangChung2.Size = New System.Drawing.Size(134, 30)
        Me.btnXemBangChung2.TabIndex = 36
        Me.btnXemBangChung2.Text = "Xem bằng chứng (hình)"
        '
        'TabBaotridinhky
        '
        Me.TabBaotridinhky.Controls.Add(Me.TableLayoutPanel3)
        Me.TabBaotridinhky.Controls.Add(Me.LblThongBao)
        Me.TabBaotridinhky.Controls.Add(Me.dtpDenNgayBTDK1)
        Me.TabBaotridinhky.Name = "TabBaotridinhky"
        Me.TabBaotridinhky.Padding = New System.Windows.Forms.Padding(3)
        Me.TabBaotridinhky.Size = New System.Drawing.Size(1351, 655)
        Me.TabBaotridinhky.Text = "Bảo trì định kỳ"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnThoatBTDK, 7, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnLapKHTT, 4, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnLapPBT, 5, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnInBTDK, 6, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.grpDanhsachBTDKcanthuchien, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnBoChonTatCa, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.BtnChonTatCa, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtTKiemBTDK, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1345, 649)
        Me.TableLayoutPanel3.TabIndex = 95
        '
        'Panel2
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.Panel2, 8)
        Me.Panel2.Controls.Add(Me.grdChung)
        Me.Panel2.Controls.Add(Me.cboNGSat)
        Me.Panel2.Controls.Add(Me.lblNGSat)
        Me.Panel2.Controls.Add(Me.dtpTuNgay)
        Me.Panel2.Controls.Add(Me.lblDenNgayBTDK)
        Me.Panel2.Controls.Add(Me.chkDuGio)
        Me.Panel2.Controls.Add(Me.btnThucHien)
        Me.Panel2.Controls.Add(Me.lblTuNgay)
        Me.Panel2.Controls.Add(Me.dtpDenNgay)
        Me.Panel2.Controls.Add(Me.lblDenNgay)
        Me.Panel2.Controls.Add(Me.cboNguoiLap)
        Me.Panel2.Controls.Add(Me.lblNguoiLap)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1339, 66)
        Me.Panel2.TabIndex = 96
        '
        'grdChung
        '
        Me.grdChung.Location = New System.Drawing.Point(1010, 15)
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(10, 32)
        Me.grdChung.TabIndex = 55
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        Me.grvChung.OptionsView.ColumnAutoWidth = False
        Me.grvChung.OptionsView.EnableAppearanceEvenRow = True
        Me.grvChung.OptionsView.EnableAppearanceOddRow = True
        Me.grvChung.OptionsView.ShowGroupPanel = False
        '
        'cboNGSat
        '
        Me.cboNGSat.Location = New System.Drawing.Point(669, 39)
        Me.cboNGSat.Name = "cboNGSat"
        Me.cboNGSat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNGSat.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboNGSat.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboNGSat.Properties.NullText = ""
        Me.cboNGSat.Size = New System.Drawing.Size(175, 20)
        Me.cboNGSat.TabIndex = 53
        '
        'lblNGSat
        '
        Me.lblNGSat.Location = New System.Drawing.Point(578, 37)
        Me.lblNGSat.Name = "lblNGSat"
        Me.lblNGSat.Size = New System.Drawing.Size(85, 20)
        Me.lblNGSat.TabIndex = 54
        Me.lblNGSat.Text = "lblNGSat"
        Me.lblNGSat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNgay.Location = New System.Drawing.Point(395, 9)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(83, 21)
        Me.dtpTuNgay.TabIndex = 49
        '
        'lblDenNgayBTDK
        '
        Me.lblDenNgayBTDK.Location = New System.Drawing.Point(24, 24)
        Me.lblDenNgayBTDK.Name = "lblDenNgayBTDK"
        Me.lblDenNgayBTDK.Size = New System.Drawing.Size(280, 20)
        Me.lblDenNgayBTDK.TabIndex = 0
        Me.lblDenNgayBTDK.Text = "Bảo trì định kỳ cần thực hiện trong giai đoạn:"
        Me.lblDenNgayBTDK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkDuGio
        '
        Me.chkDuGio.Location = New System.Drawing.Point(875, 27)
        Me.chkDuGio.Name = "chkDuGio"
        Me.chkDuGio.Properties.Caption = "Đủ giờ"
        Me.chkDuGio.Size = New System.Drawing.Size(57, 18)
        Me.chkDuGio.TabIndex = 47
        '
        'btnThucHien
        '
        Me.btnThucHien.Location = New System.Drawing.Point(482, 9)
        Me.btnThucHien.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien.Name = "btnThucHien"
        Me.btnThucHien.Size = New System.Drawing.Size(83, 48)
        Me.btnThucHien.TabIndex = 52
        Me.btnThucHien.Text = "Thực hiện"
        '
        'lblTuNgay
        '
        Me.lblTuNgay.Location = New System.Drawing.Point(314, 9)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(78, 20)
        Me.lblTuNgay.TabIndex = 48
        Me.lblTuNgay.Text = "Từ ngày"
        Me.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDenNgay.Location = New System.Drawing.Point(395, 36)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(83, 21)
        Me.dtpDenNgay.TabIndex = 51
        '
        'lblDenNgay
        '
        Me.lblDenNgay.Location = New System.Drawing.Point(307, 37)
        Me.lblDenNgay.Name = "lblDenNgay"
        Me.lblDenNgay.Size = New System.Drawing.Size(85, 20)
        Me.lblDenNgay.TabIndex = 50
        Me.lblDenNgay.Text = "Đến ngày"
        Me.lblDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboNguoiLap
        '
        Me.cboNguoiLap.Location = New System.Drawing.Point(669, 9)
        Me.cboNguoiLap.Name = "cboNguoiLap"
        Me.cboNguoiLap.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNguoiLap.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboNguoiLap.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboNguoiLap.Properties.NullText = ""
        Me.cboNguoiLap.Size = New System.Drawing.Size(175, 20)
        Me.cboNguoiLap.TabIndex = 44
        '
        'lblNguoiLap
        '
        Me.lblNguoiLap.Location = New System.Drawing.Point(578, 9)
        Me.lblNguoiLap.Name = "lblNguoiLap"
        Me.lblNguoiLap.Size = New System.Drawing.Size(85, 20)
        Me.lblNguoiLap.TabIndex = 45
        Me.lblNguoiLap.Text = "Người lập"
        Me.lblNguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnThoatBTDK
        '
        Me.BtnThoatBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnThoatBTDK.Location = New System.Drawing.Point(1238, 616)
        Me.BtnThoatBTDK.LookAndFeel.SkinName = "Blue"
        Me.BtnThoatBTDK.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThoatBTDK.Name = "BtnThoatBTDK"
        Me.BtnThoatBTDK.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoatBTDK.TabIndex = 49
        Me.BtnThoatBTDK.Text = "T&hoát"
        '
        'BtnLapKHTT
        '
        Me.BtnLapKHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnLapKHTT.Location = New System.Drawing.Point(848, 616)
        Me.BtnLapKHTT.LookAndFeel.SkinName = "Blue"
        Me.BtnLapKHTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnLapKHTT.Name = "BtnLapKHTT"
        Me.BtnLapKHTT.Size = New System.Drawing.Size(134, 30)
        Me.BtnLapKHTT.TabIndex = 47
        Me.BtnLapKHTT.Text = "&Lập KH tổng thể"
        '
        'BtnLapPBT
        '
        Me.BtnLapPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnLapPBT.Location = New System.Drawing.Point(988, 616)
        Me.BtnLapPBT.LookAndFeel.SkinName = "Blue"
        Me.BtnLapPBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnLapPBT.Name = "BtnLapPBT"
        Me.BtnLapPBT.Size = New System.Drawing.Size(134, 30)
        Me.BtnLapPBT.TabIndex = 48
        Me.BtnLapPBT.Text = "Lập &phiếu BT"
        '
        'btnInBTDK
        '
        Me.btnInBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInBTDK.Location = New System.Drawing.Point(1128, 616)
        Me.btnInBTDK.LookAndFeel.SkinName = "Blue"
        Me.btnInBTDK.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnInBTDK.Name = "btnInBTDK"
        Me.btnInBTDK.Size = New System.Drawing.Size(104, 30)
        Me.btnInBTDK.TabIndex = 46
        Me.btnInBTDK.Text = "&In"
        '
        'grpDanhsachBTDKcanthuchien
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.grpDanhsachBTDKcanthuchien, 8)
        Me.grpDanhsachBTDKcanthuchien.Controls.Add(Me.lblChon)
        Me.grpDanhsachBTDKcanthuchien.Controls.Add(Me.gdBTDK)
        Me.grpDanhsachBTDKcanthuchien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDanhsachBTDKcanthuchien.Location = New System.Drawing.Point(3, 75)
        Me.grpDanhsachBTDKcanthuchien.Name = "grpDanhsachBTDKcanthuchien"
        Me.grpDanhsachBTDKcanthuchien.Size = New System.Drawing.Size(1339, 535)
        Me.grpDanhsachBTDKcanthuchien.TabIndex = 97
        Me.grpDanhsachBTDKcanthuchien.Text = "Danh sách BTDK cần thực hiện"
        '
        'lblChon
        '
        Me.lblChon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChon.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblChon.ForeColor = System.Drawing.Color.Navy
        Me.lblChon.Location = New System.Drawing.Point(1257, 2)
        Me.lblChon.Name = "lblChon"
        Me.lblChon.Size = New System.Drawing.Size(78, 17)
        Me.lblChon.TabIndex = 2
        Me.lblChon.Text = "Chọn: 0"
        Me.lblChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gdBTDK
        '
        Me.gdBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdBTDK.Location = New System.Drawing.Point(2, 22)
        Me.gdBTDK.MainView = Me.gvBTDK
        Me.gdBTDK.Name = "gdBTDK"
        Me.gdBTDK.Size = New System.Drawing.Size(1335, 511)
        Me.gdBTDK.TabIndex = 0
        Me.gdBTDK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK})
        '
        'gvBTDK
        '
        Me.gvBTDK.GridControl = Me.gdBTDK
        Me.gvBTDK.Name = "gvBTDK"
        Me.gvBTDK.OptionsView.ColumnAutoWidth = False
        Me.gvBTDK.OptionsView.EnableAppearanceEvenRow = True
        Me.gvBTDK.OptionsView.EnableAppearanceOddRow = True
        Me.gvBTDK.OptionsView.ShowGroupPanel = False
        '
        'BtnBoChonTatCa
        '
        Me.BtnBoChonTatCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnBoChonTatCa.Location = New System.Drawing.Point(258, 616)
        Me.BtnBoChonTatCa.LookAndFeel.SkinName = "Blue"
        Me.BtnBoChonTatCa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnBoChonTatCa.Name = "BtnBoChonTatCa"
        Me.BtnBoChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnBoChonTatCa.TabIndex = 93
        Me.BtnBoChonTatCa.Text = "Bỏ chọn tất cả"
        '
        'BtnChonTatCa
        '
        Me.BtnChonTatCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnChonTatCa.Location = New System.Drawing.Point(148, 616)
        Me.BtnChonTatCa.LookAndFeel.SkinName = "Blue"
        Me.BtnChonTatCa.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnChonTatCa.Name = "BtnChonTatCa"
        Me.BtnChonTatCa.Size = New System.Drawing.Size(104, 30)
        Me.BtnChonTatCa.TabIndex = 92
        Me.BtnChonTatCa.Text = "Chọn tất cả"
        '
        'txtTKiemBTDK
        '
        Me.txtTKiemBTDK.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTKiemBTDK.Location = New System.Drawing.Point(3, 626)
        Me.txtTKiemBTDK.Name = "txtTKiemBTDK"
        Me.txtTKiemBTDK.Size = New System.Drawing.Size(139, 20)
        Me.txtTKiemBTDK.TabIndex = 94
        '
        'LblThongBao
        '
        Me.LblThongBao.AutoSize = True
        Me.LblThongBao.ForeColor = System.Drawing.Color.Navy
        Me.LblThongBao.Location = New System.Drawing.Point(406, 102)
        Me.LblThongBao.Name = "LblThongBao"
        Me.LblThongBao.Size = New System.Drawing.Size(195, 13)
        Me.LblThongBao.TabIndex = 42
        Me.LblThongBao.Text = "Nhấn Enter sau mỗi lần nhập đến ngày "
        Me.LblThongBao.Visible = False
        '
        'dtpDenNgayBTDK1
        '
        Me.dtpDenNgayBTDK1.Location = New System.Drawing.Point(333, 97)
        Me.dtpDenNgayBTDK1.Mask = "00/00/0000"
        Me.dtpDenNgayBTDK1.Name = "dtpDenNgayBTDK1"
        Me.dtpDenNgayBTDK1.Size = New System.Drawing.Size(65, 21)
        Me.dtpDenNgayBTDK1.TabIndex = 43
        Me.dtpDenNgayBTDK1.TabStop = False
        Me.dtpDenNgayBTDK1.ValidatingType = GetType(Date)
        Me.dtpDenNgayBTDK1.Visible = False
        '
        'TabBaoTriTheoGio
        '
        Me.TabBaoTriTheoGio.Controls.Add(Me.TableLayoutPanel2)
        Me.TabBaoTriTheoGio.Name = "TabBaoTriTheoGio"
        Me.TabBaoTriTheoGio.Padding = New System.Windows.Forms.Padding(3)
        Me.TabBaoTriTheoGio.Size = New System.Drawing.Size(1351, 655)
        Me.TabBaoTriTheoGio.Text = "Bào trỉ định kỳ  theo giờ"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnThoat5, 8, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.grpBaotritheothoigian, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnLapPBT1, 6, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnInGio, 7, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnLapKHTT1, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTKiemBTDKGio, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAllBTDKTheoGio, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnNotAllBTDKTheoGio, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNguoiLap1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboNguoiLap1, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1345, 649)
        Me.TableLayoutPanel2.TabIndex = 52
        '
        'BtnThoat5
        '
        Me.BtnThoat5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnThoat5.Location = New System.Drawing.Point(1238, 616)
        Me.BtnThoat5.LookAndFeel.SkinName = "Blue"
        Me.BtnThoat5.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnThoat5.Name = "BtnThoat5"
        Me.BtnThoat5.Size = New System.Drawing.Size(104, 30)
        Me.BtnThoat5.TabIndex = 49
        Me.BtnThoat5.Text = "T&hoát"
        '
        'grpBaotritheothoigian
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.grpBaotritheothoigian, 9)
        Me.grpBaotritheothoigian.Controls.Add(Me.gdBTDK_Gio)
        Me.grpBaotritheothoigian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpBaotritheothoigian.ForeColor = System.Drawing.Color.Navy
        Me.grpBaotritheothoigian.Location = New System.Drawing.Point(3, 39)
        Me.grpBaotritheothoigian.Name = "grpBaotritheothoigian"
        Me.grpBaotritheothoigian.Size = New System.Drawing.Size(1339, 571)
        Me.grpBaotritheothoigian.TabIndex = 48
        Me.grpBaotritheothoigian.TabStop = False
        Me.grpBaotritheothoigian.Text = "Danh sách thiết bị bảo trì định kỳ cần thực hiện"
        '
        'gdBTDK_Gio
        '
        Me.gdBTDK_Gio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdBTDK_Gio.Location = New System.Drawing.Point(3, 17)
        Me.gdBTDK_Gio.MainView = Me.gvBTDK_Gio
        Me.gdBTDK_Gio.Name = "gdBTDK_Gio"
        Me.gdBTDK_Gio.Size = New System.Drawing.Size(1333, 551)
        Me.gdBTDK_Gio.TabIndex = 0
        Me.gdBTDK_Gio.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBTDK_Gio})
        '
        'gvBTDK_Gio
        '
        Me.gvBTDK_Gio.GridControl = Me.gdBTDK_Gio
        Me.gvBTDK_Gio.Name = "gvBTDK_Gio"
        Me.gvBTDK_Gio.OptionsView.ColumnAutoWidth = False
        Me.gvBTDK_Gio.OptionsView.EnableAppearanceEvenRow = True
        Me.gvBTDK_Gio.OptionsView.EnableAppearanceOddRow = True
        Me.gvBTDK_Gio.OptionsView.ShowGroupPanel = False
        '
        'BtnLapPBT1
        '
        Me.BtnLapPBT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnLapPBT1.Location = New System.Drawing.Point(988, 616)
        Me.BtnLapPBT1.LookAndFeel.SkinName = "Blue"
        Me.BtnLapPBT1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnLapPBT1.Name = "BtnLapPBT1"
        Me.BtnLapPBT1.Size = New System.Drawing.Size(134, 30)
        Me.BtnLapPBT1.TabIndex = 50
        Me.BtnLapPBT1.Text = "Lập &phiếu BT"
        '
        'btnInGio
        '
        Me.btnInGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInGio.Location = New System.Drawing.Point(1128, 616)
        Me.btnInGio.LookAndFeel.SkinName = "Blue"
        Me.btnInGio.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnInGio.Name = "btnInGio"
        Me.btnInGio.Size = New System.Drawing.Size(104, 30)
        Me.btnInGio.TabIndex = 52
        Me.btnInGio.Text = "&In"
        '
        'BtnLapKHTT1
        '
        Me.BtnLapKHTT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnLapKHTT1.Location = New System.Drawing.Point(848, 616)
        Me.BtnLapKHTT1.LookAndFeel.SkinName = "Blue"
        Me.BtnLapKHTT1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnLapKHTT1.Name = "BtnLapKHTT1"
        Me.BtnLapKHTT1.Size = New System.Drawing.Size(134, 30)
        Me.BtnLapKHTT1.TabIndex = 51
        Me.BtnLapKHTT1.Text = "&Lập KH tổng thể"
        '
        'txtTKiemBTDKGio
        '
        Me.txtTKiemBTDKGio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTKiemBTDKGio.Location = New System.Drawing.Point(3, 626)
        Me.txtTKiemBTDKGio.Name = "txtTKiemBTDKGio"
        Me.txtTKiemBTDKGio.Size = New System.Drawing.Size(134, 20)
        Me.txtTKiemBTDKGio.TabIndex = 95
        '
        'btnAllBTDKTheoGio
        '
        Me.btnAllBTDKTheoGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAllBTDKTheoGio.Location = New System.Drawing.Point(143, 616)
        Me.btnAllBTDKTheoGio.LookAndFeel.SkinName = "Blue"
        Me.btnAllBTDKTheoGio.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnAllBTDKTheoGio.Name = "btnAllBTDKTheoGio"
        Me.btnAllBTDKTheoGio.Size = New System.Drawing.Size(104, 30)
        Me.btnAllBTDKTheoGio.TabIndex = 96
        Me.btnAllBTDKTheoGio.Text = "Chọn tất cả"
        '
        'btnNotAllBTDKTheoGio
        '
        Me.btnNotAllBTDKTheoGio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNotAllBTDKTheoGio.Location = New System.Drawing.Point(253, 616)
        Me.btnNotAllBTDKTheoGio.Name = "btnNotAllBTDKTheoGio"
        Me.btnNotAllBTDKTheoGio.Size = New System.Drawing.Size(104, 30)
        Me.btnNotAllBTDKTheoGio.TabIndex = 97
        Me.btnNotAllBTDKTheoGio.Text = "Bỏ chọn tất cả"
        '
        'lblNguoiLap1
        '
        Me.lblNguoiLap1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNguoiLap1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblNguoiLap1.ForeColor = System.Drawing.Color.Black
        Me.lblNguoiLap1.Location = New System.Drawing.Point(363, 10)
        Me.lblNguoiLap1.Name = "lblNguoiLap1"
        Me.lblNguoiLap1.Size = New System.Drawing.Size(134, 26)
        Me.lblNguoiLap1.TabIndex = 47
        Me.lblNguoiLap1.Text = "Người lập"
        Me.lblNguoiLap1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboNguoiLap1
        '
        Me.cboNguoiLap1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboNguoiLap1.Location = New System.Drawing.Point(503, 13)
        Me.cboNguoiLap1.Name = "cboNguoiLap1"
        Me.cboNguoiLap1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNguoiLap1.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboNguoiLap1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboNguoiLap1.Properties.NullText = ""
        Me.cboNguoiLap1.Size = New System.Drawing.Size(339, 20)
        Me.cboNguoiLap1.TabIndex = 46
        '
        'TabMonitoring
        '
        Me.TabMonitoring.Name = "TabMonitoring"
        Me.TabMonitoring.PageVisible = False
        Me.TabMonitoring.Size = New System.Drawing.Size(1351, 655)
        Me.TabMonitoring.Text = "TabMonitoring"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnVideo, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHelp, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.gdTSGSTT1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tabKeHoachTongThe, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 326.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1364, 729)
        Me.TableLayoutPanel1.TabIndex = 27
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(1324, 9)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(33, 30)
        Me.btnVideo.TabIndex = 96
        Me.btnVideo.Tag = "CMMS!frmKehoachtongthe_odd"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1289, 9)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(33, 30)
        Me.btnHelp.TabIndex = 97
        Me.btnHelp.Tag = "CMMS!frmKehoachtongthe_odd"
        '
        'gdTSGSTT1
        '
        Me.gdTSGSTT1.Location = New System.Drawing.Point(7, 3)
        Me.gdTSGSTT1.MainView = Me.gvTSGSTT1
        Me.gdTSGSTT1.Name = "gdTSGSTT1"
        Me.gdTSGSTT1.Size = New System.Drawing.Size(69, 2)
        Me.gdTSGSTT1.TabIndex = 1
        Me.gdTSGSTT1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTSGSTT1, Me.GridView2})
        Me.gdTSGSTT1.Visible = False
        '
        'gvTSGSTT1
        '
        Me.gvTSGSTT1.GridControl = Me.gdTSGSTT1
        Me.gvTSGSTT1.Name = "gvTSGSTT1"
        Me.gvTSGSTT1.OptionsView.ColumnAutoWidth = False
        Me.gvTSGSTT1.OptionsView.EnableAppearanceEvenRow = True
        Me.gvTSGSTT1.OptionsView.EnableAppearanceOddRow = True
        Me.gvTSGSTT1.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gdTSGSTT1
        Me.GridView2.Name = "GridView2"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 10
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel6, 2)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.lblDiaDiem_1, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cboLoaiThietBiBTDK, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.CboNhomThietBiBTDK, 7, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblDChuyen, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cboDiaDiem_1, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.CboMaSoThietBiBTDK, 9, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cboHThong, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LblMaSoThietBiBTDK, 8, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblLoaiThietBiBTDK, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LblNhomThietBiBTDK, 6, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 11)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1282, 26)
        Me.TableLayoutPanel6.TabIndex = 98
        '
        'lblDiaDiem_1
        '
        Me.lblDiaDiem_1.AutoSize = True
        Me.lblDiaDiem_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiaDiem_1.ForeColor = System.Drawing.Color.Black
        Me.lblDiaDiem_1.Location = New System.Drawing.Point(3, 0)
        Me.lblDiaDiem_1.Name = "lblDiaDiem_1"
        Me.lblDiaDiem_1.Size = New System.Drawing.Size(72, 26)
        Me.lblDiaDiem_1.TabIndex = 1
        Me.lblDiaDiem_1.Text = "Địa điểm"
        Me.lblDiaDiem_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLoaiThietBiBTDK
        '
        Me.cboLoaiThietBiBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiThietBiBTDK.Location = New System.Drawing.Point(593, 3)
        Me.cboLoaiThietBiBTDK.Name = "cboLoaiThietBiBTDK"
        Me.cboLoaiThietBiBTDK.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaiThietBiBTDK.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboLoaiThietBiBTDK.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboLoaiThietBiBTDK.Properties.NullText = ""
        Me.cboLoaiThietBiBTDK.Size = New System.Drawing.Size(172, 20)
        Me.cboLoaiThietBiBTDK.TabIndex = 24
        '
        'CboNhomThietBiBTDK
        '
        Me.CboNhomThietBiBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CboNhomThietBiBTDK.Location = New System.Drawing.Point(849, 3)
        Me.CboNhomThietBiBTDK.Name = "CboNhomThietBiBTDK"
        Me.CboNhomThietBiBTDK.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CboNhomThietBiBTDK.Properties.LookAndFeel.SkinName = "Blue"
        Me.CboNhomThietBiBTDK.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.CboNhomThietBiBTDK.Properties.NullText = ""
        Me.CboNhomThietBiBTDK.Size = New System.Drawing.Size(172, 20)
        Me.CboNhomThietBiBTDK.TabIndex = 25
        '
        'lblDChuyen
        '
        Me.lblDChuyen.AutoSize = True
        Me.lblDChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDChuyen.ForeColor = System.Drawing.Color.Black
        Me.lblDChuyen.Location = New System.Drawing.Point(259, 0)
        Me.lblDChuyen.Name = "lblDChuyen"
        Me.lblDChuyen.Size = New System.Drawing.Size(72, 26)
        Me.lblDChuyen.TabIndex = 1
        Me.lblDChuyen.Text = "lblDChuyen"
        Me.lblDChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDiaDiem_1
        '
        Me.cboDiaDiem_1.ColumnDisplayName = Nothing
        Me.cboDiaDiem_1.DataSource = Nothing
        Me.cboDiaDiem_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDiaDiem_1.EditValue = Nothing
        Me.cboDiaDiem_1.KeyFieldName = Nothing
        Me.cboDiaDiem_1.Location = New System.Drawing.Point(81, 3)
        Me.cboDiaDiem_1.LookAndFeel.SkinName = "Blue"
        Me.cboDiaDiem_1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboDiaDiem_1.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.cboDiaDiem_1.MinimumSize = New System.Drawing.Size(10, 20)
        Me.cboDiaDiem_1.Name = "cboDiaDiem_1"
        Me.cboDiaDiem_1.ParentFieldName = Nothing
        Me.cboDiaDiem_1.ReadOnly = False
        Me.cboDiaDiem_1.SelectedIndex = 0
        Me.cboDiaDiem_1.Size = New System.Drawing.Size(172, 20)
        Me.cboDiaDiem_1.TabIndex = 24
        Me.cboDiaDiem_1.TextValue = Nothing
        '
        'CboMaSoThietBiBTDK
        '
        Me.CboMaSoThietBiBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CboMaSoThietBiBTDK.Location = New System.Drawing.Point(1105, 3)
        Me.CboMaSoThietBiBTDK.Name = "CboMaSoThietBiBTDK"
        Me.CboMaSoThietBiBTDK.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CboMaSoThietBiBTDK.Properties.LookAndFeel.SkinName = "Blue"
        Me.CboMaSoThietBiBTDK.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.CboMaSoThietBiBTDK.Properties.NullText = ""
        Me.CboMaSoThietBiBTDK.Size = New System.Drawing.Size(174, 20)
        Me.CboMaSoThietBiBTDK.TabIndex = 26
        '
        'cboHThong
        '
        Me.cboHThong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboHThong.Location = New System.Drawing.Point(337, 3)
        Me.cboHThong.Name = "cboHThong"
        Me.cboHThong.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboHThong.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboHThong.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboHThong.Properties.NullText = ""
        Me.cboHThong.Size = New System.Drawing.Size(172, 20)
        Me.cboHThong.TabIndex = 24
        '
        'LblMaSoThietBiBTDK
        '
        Me.LblMaSoThietBiBTDK.AutoSize = True
        Me.LblMaSoThietBiBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblMaSoThietBiBTDK.ForeColor = System.Drawing.Color.Black
        Me.LblMaSoThietBiBTDK.Location = New System.Drawing.Point(1027, 0)
        Me.LblMaSoThietBiBTDK.Name = "LblMaSoThietBiBTDK"
        Me.LblMaSoThietBiBTDK.Size = New System.Drawing.Size(72, 26)
        Me.LblMaSoThietBiBTDK.TabIndex = 7
        Me.LblMaSoThietBiBTDK.Text = "Mã số thiết bị"
        Me.LblMaSoThietBiBTDK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoaiThietBiBTDK
        '
        Me.lblLoaiThietBiBTDK.AutoSize = True
        Me.lblLoaiThietBiBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiThietBiBTDK.ForeColor = System.Drawing.Color.Black
        Me.lblLoaiThietBiBTDK.Location = New System.Drawing.Point(515, 0)
        Me.lblLoaiThietBiBTDK.Name = "lblLoaiThietBiBTDK"
        Me.lblLoaiThietBiBTDK.Size = New System.Drawing.Size(72, 26)
        Me.lblLoaiThietBiBTDK.TabIndex = 1
        Me.lblLoaiThietBiBTDK.Text = "Loại thiết bị"
        Me.lblLoaiThietBiBTDK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNhomThietBiBTDK
        '
        Me.LblNhomThietBiBTDK.AutoSize = True
        Me.LblNhomThietBiBTDK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblNhomThietBiBTDK.ForeColor = System.Drawing.Color.Black
        Me.LblNhomThietBiBTDK.Location = New System.Drawing.Point(771, 0)
        Me.LblNhomThietBiBTDK.Name = "LblNhomThietBiBTDK"
        Me.LblNhomThietBiBTDK.Size = New System.Drawing.Size(72, 26)
        Me.LblNhomThietBiBTDK.TabIndex = 5
        Me.LblNhomThietBiBTDK.Text = "Nhóm thiết bị"
        Me.LblNhomThietBiBTDK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "CHON"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "TÊn vật tư"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 87
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Số lượng "
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 150
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Đơn vị tính"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 87
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ghi chú"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 86
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 61.54822!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Tên phụ tùng"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 85
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.FillWeight = 61.54822!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Số lượng "
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 86
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 61.54822!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Đơn vị tính"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 85
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.FillWeight = 61.54822!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Ghi chú"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 85
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.FillWeight = 57.44501!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Tên công việc"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 108
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.FillWeight = 57.44501!
        Me.DataGridViewTextBoxColumn10.HeaderText = "Ưu tiên"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 109
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.FillWeight = 355.33!
        Me.DataGridViewTextBoxColumn11.HeaderText = "ROA No"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 108
        '
        'DataGridViewComboBoxColumn5
        '
        Me.DataGridViewComboBoxColumn5.FillWeight = 253.8071!
        Me.DataGridViewComboBoxColumn5.HeaderText = "Hạng mục KH"
        Me.DataGridViewComboBoxColumn5.Name = "DataGridViewComboBoxColumn5"
        Me.DataGridViewComboBoxColumn5.ReadOnly = True
        Me.DataGridViewComboBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn5.Width = 110
        '
        'DataGridViewComboBoxColumn6
        '
        Me.DataGridViewComboBoxColumn6.FillWeight = 253.8071!
        Me.DataGridViewComboBoxColumn6.HeaderText = "Người xử lý"
        Me.DataGridViewComboBoxColumn6.Name = "DataGridViewComboBoxColumn6"
        Me.DataGridViewComboBoxColumn6.ReadOnly = True
        Me.DataGridViewComboBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn6.Width = 130
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.FillWeight = 57.44501!
        Me.DataGridViewTextBoxColumn12.HeaderText = "Ngày"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn12.Width = 108
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.FillWeight = 57.44501!
        Me.DataGridViewTextBoxColumn13.HeaderText = "Ngày"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn13.Width = 132
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.FillWeight = 57.44501!
        Me.DataGridViewTextBoxColumn14.HeaderText = "Tên hạng mục"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.Width = 132
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.FillWeight = 57.44501!
        Me.DataGridViewTextBoxColumn15.HeaderText = "Ngày ĐK_HT"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn15.Width = 131
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn16.HeaderText = "Ghi chú"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn16.Width = 132
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.FillWeight = 720.8955!
        Me.DataGridViewTextBoxColumn17.HeaderText = "Loại BTPN"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn17.Width = 131
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn18.HeaderText = "Ngày BTPN"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn18.Width = 132
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn19.HeaderText = "MS_Thiết bị"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 62
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn20.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn20.HeaderText = "Giá trị DL"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn20.Width = 63
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn21.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn21.HeaderText = "DVT"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn21.Width = 62
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn22.HeaderText = "Giá trị ĐT"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn22.Width = 63
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn23.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn23.HeaderText = "Ngày kiểm tra"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 62
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.FillWeight = 52.23881!
        Me.DataGridViewTextBoxColumn24.HeaderText = "Người kiểm tra"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn24.Width = 63
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "Có hình"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn25.Width = 62
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "Thông số kiểm tra"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn26.Width = 63
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.HeaderText = "Đề nghị"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn32.Width = 72
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.HeaderText = "Người yêu cầu"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn33.Width = 72
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.HeaderText = "Username"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        Me.DataGridViewTextBoxColumn38.Width = 72
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.HeaderText = "MS thiết bị"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.Width = 167
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.HeaderText = "Loại bảo trì"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.Width = 167
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.HeaderText = "Thời gian cần thực hiện"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.Width = 168
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.HeaderText = "Thời gian chạy máy kể từ lần bảo trì trước"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.Width = 167
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.HiddenPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        Me.DockManager1.ValidateFloatFormChildrenOnDeactivate = False
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float
        Me.DockPanel1.FloatLocation = New System.Drawing.Point(212, 241)
        Me.DockPanel1.FloatSize = New System.Drawing.Size(820, 371)
        Me.DockPanel1.ID = New System.Guid("d910c8ba-8d56-4f16-8434-8c166fda0518")
        Me.DockPanel1.Location = New System.Drawing.Point(-32768, -32768)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.AllowDockBottom = False
        Me.DockPanel1.Options.AllowDockFill = False
        Me.DockPanel1.Options.AllowDockLeft = False
        Me.DockPanel1.Options.AllowDockRight = False
        Me.DockPanel1.Options.AllowDockTop = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(820, 371)
        Me.DockPanel1.SavedIndex = 0
        Me.DockPanel1.Size = New System.Drawing.Size(820, 371)
        Me.DockPanel1.Text = "Monitoring"
        Me.DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.TableLayoutPanel9)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(2, 24)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(816, 345)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.XtraTabControl1, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btnSelectAllForMonitoring, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btnDeselectAllForMonitoring, 1, 1)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 3
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(816, 345)
        Me.TableLayoutPanel9.TabIndex = 1
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(3, 3)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.TableLayoutPanel9.SetRowSpan(Me.XtraTabControl1, 3)
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(720, 339)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.btnViewMonitoring)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(713, 310)
        Me.XtraTabPage1.Text = "Days"
        '
        'btnViewMonitoring
        '
        XyDiagram4.AxisX.Label.Angle = -45
        XyDiagram4.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram4.AxisX.Range.SideMarginsEnabled = True
        XyDiagram4.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram4.AxisY.Label.Antialiasing = True
        XyDiagram4.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram4.AxisY.Range.SideMarginsEnabled = True
        XyDiagram4.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram4.EnableScrolling = True
        XyDiagram4.EnableZooming = True
        Me.btnViewMonitoring.Diagram = XyDiagram4
        Me.btnViewMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnViewMonitoring.Legend.Visible = False
        Me.btnViewMonitoring.Location = New System.Drawing.Point(0, 0)
        Me.btnViewMonitoring.Name = "btnViewMonitoring"
        SideBySideBarSeriesLabel10.LineVisible = True
        Series7.Label = SideBySideBarSeriesLabel10
        Series7.Name = "Series 1"
        SideBySideBarSeriesLabel11.LineVisible = True
        Series8.Label = SideBySideBarSeriesLabel11
        Series8.Name = "Series 2"
        Me.btnViewMonitoring.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series7, Series8}
        SideBySideBarSeriesLabel12.LineVisible = True
        Me.btnViewMonitoring.SeriesTemplate.Label = SideBySideBarSeriesLabel12
        Me.btnViewMonitoring.Size = New System.Drawing.Size(713, 310)
        Me.btnViewMonitoring.TabIndex = 0
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.ChartWeeksMonitoring)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(713, 310)
        Me.XtraTabPage2.Text = "Weeks"
        '
        'ChartWeeksMonitoring
        '
        XyDiagram5.AxisX.Label.Angle = -45
        XyDiagram5.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram5.AxisX.Range.SideMarginsEnabled = True
        XyDiagram5.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram5.AxisY.Label.Antialiasing = True
        XyDiagram5.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram5.AxisY.Range.SideMarginsEnabled = True
        XyDiagram5.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram5.EnableScrolling = True
        XyDiagram5.EnableZooming = True
        Me.ChartWeeksMonitoring.Diagram = XyDiagram5
        Me.ChartWeeksMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartWeeksMonitoring.Legend.Visible = False
        Me.ChartWeeksMonitoring.Location = New System.Drawing.Point(0, 0)
        Me.ChartWeeksMonitoring.Name = "ChartWeeksMonitoring"
        SideBySideBarSeriesLabel13.LineVisible = True
        Series9.Label = SideBySideBarSeriesLabel13
        Series9.Name = "Series 1"
        SideBySideBarSeriesLabel14.LineVisible = True
        Series10.Label = SideBySideBarSeriesLabel14
        Series10.Name = "Series 2"
        Me.ChartWeeksMonitoring.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series9, Series10}
        SideBySideBarSeriesLabel15.LineVisible = True
        Me.ChartWeeksMonitoring.SeriesTemplate.Label = SideBySideBarSeriesLabel15
        Me.ChartWeeksMonitoring.Size = New System.Drawing.Size(713, 310)
        Me.ChartWeeksMonitoring.TabIndex = 1
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.ChartMonthsMonitoring)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(713, 310)
        Me.XtraTabPage3.Text = "Months"
        '
        'ChartMonthsMonitoring
        '
        XyDiagram6.AxisX.Label.Angle = -45
        XyDiagram6.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram6.AxisX.Range.SideMarginsEnabled = True
        XyDiagram6.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram6.AxisY.Label.Antialiasing = True
        XyDiagram6.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram6.AxisY.Range.SideMarginsEnabled = True
        XyDiagram6.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram6.EnableScrolling = True
        XyDiagram6.EnableZooming = True
        Me.ChartMonthsMonitoring.Diagram = XyDiagram6
        Me.ChartMonthsMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartMonthsMonitoring.Legend.Visible = False
        Me.ChartMonthsMonitoring.Location = New System.Drawing.Point(0, 0)
        Me.ChartMonthsMonitoring.Name = "ChartMonthsMonitoring"
        SideBySideBarSeriesLabel16.LineVisible = True
        Series11.Label = SideBySideBarSeriesLabel16
        Series11.Name = "Series 1"
        SideBySideBarSeriesLabel17.LineVisible = True
        Series12.Label = SideBySideBarSeriesLabel17
        Series12.Name = "Series 2"
        Me.ChartMonthsMonitoring.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series11, Series12}
        SideBySideBarSeriesLabel18.LineVisible = True
        Me.ChartMonthsMonitoring.SeriesTemplate.Label = SideBySideBarSeriesLabel18
        Me.ChartMonthsMonitoring.Size = New System.Drawing.Size(713, 310)
        Me.ChartMonthsMonitoring.TabIndex = 1
        '
        'btnSelectAllForMonitoring
        '
        Me.btnSelectAllForMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelectAllForMonitoring.Location = New System.Drawing.Point(729, 3)
        Me.btnSelectAllForMonitoring.LookAndFeel.SkinName = "Blue"
        Me.btnSelectAllForMonitoring.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnSelectAllForMonitoring.Name = "btnSelectAllForMonitoring"
        Me.btnSelectAllForMonitoring.Size = New System.Drawing.Size(84, 21)
        Me.btnSelectAllForMonitoring.TabIndex = 1
        Me.btnSelectAllForMonitoring.Text = "Select all"
        '
        'btnDeselectAllForMonitoring
        '
        Me.btnDeselectAllForMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeselectAllForMonitoring.Location = New System.Drawing.Point(729, 30)
        Me.btnDeselectAllForMonitoring.LookAndFeel.SkinName = "Blue"
        Me.btnDeselectAllForMonitoring.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnDeselectAllForMonitoring.Name = "btnDeselectAllForMonitoring"
        Me.btnDeselectAllForMonitoring.Size = New System.Drawing.Size(84, 21)
        Me.btnDeselectAllForMonitoring.TabIndex = 2
        Me.btnDeselectAllForMonitoring.Text = "Deselect all"
        '
        'BackgroundWorker1
        '
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gdTSGSTT
        Me.GridView1.Name = "GridView1"
        '
        'btnAllGSTT
        '
        Me.btnAllGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAllGSTT.Location = New System.Drawing.Point(148, 616)
        Me.btnAllGSTT.LookAndFeel.SkinName = "Blue"
        Me.btnAllGSTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnAllGSTT.Name = "btnAllGSTT"
        Me.btnAllGSTT.Size = New System.Drawing.Size(104, 30)
        Me.btnAllGSTT.TabIndex = 96
        Me.btnAllGSTT.Text = "Chọn tất cả"
        '
        'btnNotAllGSTT
        '
        Me.btnNotAllGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNotAllGSTT.Location = New System.Drawing.Point(258, 616)
        Me.btnNotAllGSTT.LookAndFeel.SkinName = "Blue"
        Me.btnNotAllGSTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnNotAllGSTT.Name = "btnNotAllGSTT"
        Me.btnNotAllGSTT.Size = New System.Drawing.Size(104, 30)
        Me.btnNotAllGSTT.TabIndex = 97
        Me.btnNotAllGSTT.Text = "Bỏ chọn tất cả"
        '
        'txtTimGSTT
        '
        Me.txtTimGSTT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTimGSTT.Location = New System.Drawing.Point(3, 626)
        Me.txtTimGSTT.Name = "txtTimGSTT"
        Me.txtTimGSTT.Size = New System.Drawing.Size(139, 20)
        Me.txtTimGSTT.TabIndex = 95
        '
        'grpDieuKienLoc2
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.grpDieuKienLoc2, 8)
        Me.grpDieuKienLoc2.Controls.Add(Me.TableLayoutPanel10)
        Me.grpDieuKienLoc2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDieuKienLoc2.ForeColor = System.Drawing.Color.Maroon
        Me.grpDieuKienLoc2.Location = New System.Drawing.Point(3, 3)
        Me.grpDieuKienLoc2.Name = "grpDieuKienLoc2"
        Me.grpDieuKienLoc2.Size = New System.Drawing.Size(1339, 46)
        Me.grpDieuKienLoc2.TabIndex = 0
        Me.grpDieuKienLoc2.TabStop = False
        Me.grpDieuKienLoc2.Text = "Điều kiện lọc"
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 9
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.dtpDNGSTT, 7, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.lblDenNgay2, 6, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.dtpTNGSTT, 5, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.lblTungay2, 4, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.radDaGiaiQuyet2, 3, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.RadBoQua2, 2, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.radChuaGiaiQuyet2, 1, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(1333, 26)
        Me.TableLayoutPanel10.TabIndex = 8
        '
        'radChuaGiaiQuyet2
        '
        Me.radChuaGiaiQuyet2.AutoSize = True
        Me.radChuaGiaiQuyet2.Checked = True
        Me.radChuaGiaiQuyet2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radChuaGiaiQuyet2.ForeColor = System.Drawing.Color.Black
        Me.radChuaGiaiQuyet2.Location = New System.Drawing.Point(284, 3)
        Me.radChuaGiaiQuyet2.Name = "radChuaGiaiQuyet2"
        Me.radChuaGiaiQuyet2.Size = New System.Drawing.Size(104, 20)
        Me.radChuaGiaiQuyet2.TabIndex = 0
        Me.radChuaGiaiQuyet2.TabStop = True
        Me.radChuaGiaiQuyet2.Text = "Chưa giải quyết"
        Me.radChuaGiaiQuyet2.UseVisualStyleBackColor = True
        '
        'RadBoQua2
        '
        Me.RadBoQua2.AutoSize = True
        Me.RadBoQua2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadBoQua2.ForeColor = System.Drawing.Color.Black
        Me.RadBoQua2.Location = New System.Drawing.Point(394, 3)
        Me.RadBoQua2.Name = "RadBoQua2"
        Me.RadBoQua2.Size = New System.Drawing.Size(104, 20)
        Me.RadBoQua2.TabIndex = 6
        Me.RadBoQua2.Text = "GSTT bị bỏ qua "
        Me.RadBoQua2.UseVisualStyleBackColor = True
        '
        'radDaGiaiQuyet2
        '
        Me.radDaGiaiQuyet2.AutoSize = True
        Me.radDaGiaiQuyet2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radDaGiaiQuyet2.ForeColor = System.Drawing.Color.Black
        Me.radDaGiaiQuyet2.Location = New System.Drawing.Point(504, 3)
        Me.radDaGiaiQuyet2.Name = "radDaGiaiQuyet2"
        Me.radDaGiaiQuyet2.Size = New System.Drawing.Size(104, 20)
        Me.radDaGiaiQuyet2.TabIndex = 1
        Me.radDaGiaiQuyet2.Text = "Đã giải quyết"
        Me.radDaGiaiQuyet2.UseVisualStyleBackColor = True
        '
        'lblTungay2
        '
        Me.lblTungay2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTungay2.ForeColor = System.Drawing.Color.Black
        Me.lblTungay2.Location = New System.Drawing.Point(614, 0)
        Me.lblTungay2.Name = "lblTungay2"
        Me.lblTungay2.Size = New System.Drawing.Size(104, 26)
        Me.lblTungay2.TabIndex = 2
        Me.lblTungay2.Text = "Từ ngày"
        Me.lblTungay2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTNGSTT
        '
        Me.dtpTNGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpTNGSTT.EditValue = Nothing
        Me.dtpTNGSTT.Location = New System.Drawing.Point(724, 3)
        Me.dtpTNGSTT.Name = "dtpTNGSTT"
        Me.dtpTNGSTT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpTNGSTT.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpTNGSTT.Size = New System.Drawing.Size(104, 20)
        Me.dtpTNGSTT.TabIndex = 7
        '
        'lblDenNgay2
        '
        Me.lblDenNgay2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenNgay2.ForeColor = System.Drawing.Color.Black
        Me.lblDenNgay2.Location = New System.Drawing.Point(834, 0)
        Me.lblDenNgay2.Name = "lblDenNgay2"
        Me.lblDenNgay2.Size = New System.Drawing.Size(104, 26)
        Me.lblDenNgay2.TabIndex = 3
        Me.lblDenNgay2.Text = "Đến ngày"
        Me.lblDenNgay2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDNGSTT
        '
        Me.dtpDNGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDNGSTT.EditValue = Nothing
        Me.dtpDNGSTT.Location = New System.Drawing.Point(944, 3)
        Me.dtpDNGSTT.Name = "dtpDNGSTT"
        Me.dtpDNGSTT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDNGSTT.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpDNGSTT.Size = New System.Drawing.Size(104, 20)
        Me.dtpDNGSTT.TabIndex = 7
        '
        'btnThucHien1
        '
        Me.btnThucHien1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThucHien1.Location = New System.Drawing.Point(1128, 616)
        Me.btnThucHien1.LookAndFeel.SkinName = "Blue"
        Me.btnThucHien1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThucHien1.Name = "btnThucHien1"
        Me.btnThucHien1.Size = New System.Drawing.Size(104, 30)
        Me.btnThucHien1.TabIndex = 36
        Me.btnThucHien1.Text = "Thực hiện "
        '
        'btnHuy
        '
        Me.btnHuy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHuy.Enabled = False
        Me.btnHuy.Location = New System.Drawing.Point(1018, 616)
        Me.btnHuy.LookAndFeel.SkinName = "Blue"
        Me.btnHuy.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnHuy.Name = "btnHuy"
        Me.btnHuy.Size = New System.Drawing.Size(104, 30)
        Me.btnHuy.TabIndex = 36
        Me.btnHuy.Text = "btnHuy"
        '
        'btnThoat2
        '
        Me.btnThoat2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoat2.Location = New System.Drawing.Point(1238, 616)
        Me.btnThoat2.LookAndFeel.SkinName = "Blue"
        Me.btnThoat2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoat2.Name = "btnThoat2"
        Me.btnThoat2.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat2.TabIndex = 28
        Me.btnThoat2.Text = "T&hoát"
        '
        'grpGSTT
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.grpGSTT, 8)
        Me.grpGSTT.Controls.Add(Me.gdTSGSTT)
        Me.grpGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpGSTT.Location = New System.Drawing.Point(3, 55)
        Me.grpGSTT.Name = "grpGSTT"
        Me.grpGSTT.Size = New System.Drawing.Size(1339, 555)
        Me.grpGSTT.TabIndex = 1
        Me.grpGSTT.TabStop = False
        Me.grpGSTT.Text = "DS thiết bị có thông số không đạt"
        '
        'gdTSGSTT
        '
        Me.gdTSGSTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdTSGSTT.Location = New System.Drawing.Point(3, 17)
        Me.gdTSGSTT.MainView = Me.gvTSGSTT
        Me.gdTSGSTT.Name = "gdTSGSTT"
        Me.gdTSGSTT.Size = New System.Drawing.Size(1333, 535)
        Me.gdTSGSTT.TabIndex = 1
        Me.gdTSGSTT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTSGSTT})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gdTSGSTT
        Me.GridView3.Name = "GridView3"
        '
        'gvTSGSTT
        '
        Me.gvTSGSTT.GridControl = Me.gdTSGSTT
        Me.gvTSGSTT.HorzScrollStep = 5
        Me.gvTSGSTT.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gvTSGSTT.Name = "gvTSGSTT"
        Me.gvTSGSTT.OptionsView.ColumnAutoWidth = False
        Me.gvTSGSTT.OptionsView.EnableAppearanceEvenRow = True
        Me.gvTSGSTT.OptionsView.EnableAppearanceOddRow = True
        Me.gvTSGSTT.OptionsView.ShowGroupPanel = False
        '
        'btnXemBangChung1
        '
        Me.btnXemBangChung1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnXemBangChung1.Location = New System.Drawing.Point(878, 616)
        Me.btnXemBangChung1.LookAndFeel.SkinName = "Blue"
        Me.btnXemBangChung1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXemBangChung1.Name = "btnXemBangChung1"
        Me.btnXemBangChung1.Size = New System.Drawing.Size(134, 30)
        Me.btnXemBangChung1.TabIndex = 33
        Me.btnXemBangChung1.Text = "Xem bằng chứng (hình)"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 8
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnXemBangChung1, 4, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.grpGSTT, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.btnThoat2, 7, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.btnHuy, 5, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.btnThucHien1, 6, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.grpDieuKienLoc2, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtTimGSTT, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.btnNotAllGSTT, 2, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.btnAllGSTT, 1, 2)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1345, 649)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'frmKehoachtongthe_odd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 729)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmKehoachtongthe_odd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kế hoạch tổng thể"
        CType(Me.tabKeHoachTongThe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabKeHoachTongThe.ResumeLayout(False)
        Me.tabKeHoachTT.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.grpDieuKienLoc1.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        CType(Me.cboNTHien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDNKHTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDNKHTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTNKHTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTNKHTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.prbLapPhieuBaoTri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.grpKehoachtongthe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpKehoachtongthe.ResumeLayout(False)
        CType(Me.gdKHTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvKHTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.grpKehoachtongcongviec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpKehoachtongcongviec.ResumeLayout(False)
        CType(Me.gdCVTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCVTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpKehoachtongcongviecVT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpKehoachtongcongviecVT.ResumeLayout(False)
        CType(Me.gdVTTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvVTTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGSTT.ResumeLayout(False)
        Me.TabYeucaunguoisudung.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.grpDieuKienLoc3.ResumeLayout(False)
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.TableLayoutPanel11.PerformLayout()
        CType(Me.dtpDNYCSD.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDNYCSD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTNYCSD.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTNYCSD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpYEU_CAU_NSD.ResumeLayout(False)
        CType(Me.gdYCNSD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvYCNSD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabBaotridinhky.ResumeLayout(False)
        Me.TabBaotridinhky.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNGSat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDuGio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNguoiLap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpDanhsachBTDKcanthuchien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDanhsachBTDKcanthuchien.ResumeLayout(False)
        CType(Me.gdBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvBTDK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTKiemBTDK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabBaoTriTheoGio.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.grpBaotritheothoigian.ResumeLayout(False)
        CType(Me.gdBTDK_Gio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvBTDK_Gio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTKiemBTDKGio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNguoiLap1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.gdTSGSTT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvTSGSTT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.cboLoaiThietBiBTDK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboNhomThietBiBTDK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboMaSoThietBiBTDK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboHThong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(XyDiagram4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnViewMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(XyDiagram5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartWeeksMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(XyDiagram6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartMonthsMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimGSTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDieuKienLoc2.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        CType(Me.dtpTNGSTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTNGSTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDNGSTT.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDNGSTT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGSTT.ResumeLayout(False)
        CType(Me.gdTSGSTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvTSGSTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnIn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThem1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGhi1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhongghi1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabKeHoachTongThe As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabKeHoachTT As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabGSTT As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabYeucaunguoisudung As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabBaotridinhky As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpDieuKienLoc3 As System.Windows.Forms.GroupBox
    Friend WithEvents grpYEU_CAU_NSD As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnThoat3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnInBTDK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLapKHTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLapPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoatBTDK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDenNgayBTDK As System.Windows.Forms.Label
    Friend WithEvents lblDenNgay3 As System.Windows.Forms.Label
    Friend WithEvents lblTuNgay3 As System.Windows.Forms.Label
    Friend WithEvents radDaGiaiQuyet3 As System.Windows.Forms.RadioButton
    Friend WithEvents radChuaGiaiQuyet3 As System.Windows.Forms.RadioButton
    Friend WithEvents btnThucHien2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXemBangChung2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonCV As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXemNguyenNhan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDieuKienLoc1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDenNgay1 As System.Windows.Forms.Label
    Friend WithEvents lblTuNgay1 As System.Windows.Forms.Label
    Friend WithEvents radDaGiaiQuyet1 As System.Windows.Forms.RadioButton
    Friend WithEvents radChuaGiaiQuyet1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnChonPT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadBoQua3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadBoQua1 As System.Windows.Forms.RadioButton
    Friend WithEvents BtnTroVe As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblThongBao As System.Windows.Forms.Label
    Friend WithEvents dtpDenNgayBTDK1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents lblNguoiLap As System.Windows.Forms.Label
    Friend WithEvents cboNguoiLap As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnLydosuachua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TabBaoTriTheoGio As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grpBaotritheothoigian As System.Windows.Forms.GroupBox
    Friend WithEvents lblNguoiLap1 As System.Windows.Forms.Label
    Friend WithEvents cboNguoiLap1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BtnLapKHTT1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLapPBT1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnThoat5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkDuGio As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnThucHien As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDenNgay As System.Windows.Forms.Label
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTuNgay As System.Windows.Forms.Label
    Friend WithEvents BtnBoChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChonTatCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gdKHTT As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvKHTT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboMay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboNgayLap As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboNgayDKHT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CBOLYDOSUACHUA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HANG_MUC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdCVTT As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCVTT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TEN_BO_PHAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_CONG_VIEC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_UU_TIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents THUE_NGOAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHI_CHU1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_PHIEU_BAO_TRI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KHONG_GQ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _GHI_CHU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdVTTT As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvVTTT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MS_PT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_PT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SO_LUONG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_DVT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHI_CHU2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_CV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MS_BO_PHAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _HANG_MUC_ID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnChonMay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gdBTDK As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvBTDK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gdBTDK_Gio As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvBTDK_Gio As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gdYCNSD As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvYCNSD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TEN_MAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnLPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboNGSat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblNGSat As System.Windows.Forms.Label
    Friend WithEvents DON_GIA_KH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TIEN_TE_KH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TY_GIA_KH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TY_GIA_USD_KH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DON_GIA_CUOI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NGAY_LAY_DG_KH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboMS_UU_TIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboMS_CN_PT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SNGUOI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents YCAU_NS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents YCAU_DC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents THAO_TAC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TIEU_CHUAN_KT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEN_TINH_TRANG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents THOI_GIAN_DU_KIEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents QUY_CACH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents YC_CHUNG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents YC_MO_TA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents YC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblNTHien As System.Windows.Forms.Label
    Friend WithEvents cboNTHien As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents MS_CN_GS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnViewMonitoring As DevExpress.XtraCharts.ChartControl
    Friend WithEvents chxChoose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ChartWeeksMonitoring As DevExpress.XtraCharts.ChartControl
    Friend WithEvents ChartMonthsMonitoring As DevExpress.XtraCharts.ChartControl
    Friend WithEvents NONN As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSelectAllForMonitoring As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDeselectAllForMonitoring As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TONG_THOI_GIAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnInGio As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents prbLapPhieuBaoTri As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BtnBoChonTatCa1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChonTatCa1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtTKiemBTDK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTKiemBTDKGio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnNotAllBTDKTheoGio As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAllBTDKTheoGio As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCapNhatMUT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gdTSGSTT1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTSGSTT1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents lblDiaDiem_1 As Label
    Friend WithEvents cboLoaiThietBiBTDK As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents CboNhomThietBiBTDK As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblDChuyen As Label
    Friend WithEvents cboDiaDiem_1 As MVControl.ucComboboxTreeList
    Friend WithEvents CboMaSoThietBiBTDK As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboHThong As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LblMaSoThietBiBTDK As Label
    Friend WithEvents lblLoaiThietBiBTDK As Label
    Friend WithEvents LblNhomThietBiBTDK As Label
    Friend WithEvents dtpTNKHTT As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtpDNKHTT As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel11 As TableLayoutPanel
    Friend WithEvents dtpTNYCSD As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtpDNYCSD As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDanhsachBTDKcanthuchien As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grpKehoachtongthe As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblTong As Label
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grpKehoachtongcongviec As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grpKehoachtongcongviecVT As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblChon As Label
    Friend WithEvents TabMonitoring As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents btnXemBangChung1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpGSTT As GroupBox
    Friend WithEvents gdTSGSTT As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTSGSTT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnThoat2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHuy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThucHien1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpDieuKienLoc2 As GroupBox
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents dtpDNGSTT As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblDenNgay2 As Label
    Friend WithEvents dtpTNGSTT As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblTungay2 As Label
    Friend WithEvents radDaGiaiQuyet2 As RadioButton
    Friend WithEvents RadBoQua2 As RadioButton
    Friend WithEvents radChuaGiaiQuyet2 As RadioButton
    Friend WithEvents txtTimGSTT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnNotAllGSTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAllGSTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    'Friend WithEvents ucMonitor As MVControl.ucMonitoring

End Class

