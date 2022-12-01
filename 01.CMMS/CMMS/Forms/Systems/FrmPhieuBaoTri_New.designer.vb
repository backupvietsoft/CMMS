<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPhieuBaoTri_New
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        Catch ex As Exception
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer = Nothing

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPhieuBaoTri_New))
        Me.lblMaSoPBT = New System.Windows.Forms.Label()
        Me.lblMS_ThietBi = New System.Windows.Forms.Label()
        Me.lblNgayLap = New System.Windows.Forms.Label()
        Me.lblLyDo = New System.Windows.Forms.Label()
        Me.dtGioLap = New Commons.MaskedTextBoxNew()
        Me.txtGiohong = New Commons.MaskedTextBoxNew()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblGS_Vien = New System.Windows.Forms.Label()
        Me.lblTGNM = New System.Windows.Forms.Label()
        Me.lblKTTT = New System.Windows.Forms.Label()
        Me.lblNgayKTKH = New System.Windows.Forms.Label()
        Me.lblNguoiLap = New System.Windows.Forms.Label()
        Me.lblMucUuTien = New System.Windows.Forms.Label()
        Me.lblLoaiBT = New System.Windows.Forms.Label()
        Me.tabKetThucPhieuBaoTri = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainerControl5 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.grpPhutungthaythe = New System.Windows.Forms.GroupBox()
        Me.grdPTThayThe = New DevExpress.XtraGrid.GridControl()
        Me.grvPTThayThe = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SplitContainerControl4 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdPTTTChiTiet = New DevExpress.XtraGrid.GridControl()
        Me.grvPTTTChiTiet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdVatTuNT = New System.Windows.Forms.GroupBox()
        Me.grdVTNghiemThu = New DevExpress.XtraGrid.GridControl()
        Me.grvVTNghiemThu = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdChung = New DevExpress.XtraGrid.GridControl()
        Me.grvChung = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpThongtinthuchien = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNgayBatDau = New System.Windows.Forms.Label()
        Me.txtNgayBatDau = New Commons.utcTextBox()
        Me.txtNgayKetThuc = New Commons.utcTextBox()
        Me.lblNgayKetThuc = New System.Windows.Forms.Label()
        Me.txtTongGioCong = New Commons.utcTextBox()
        Me.lblTonggiocong = New System.Windows.Forms.Label()
        Me.grpThongtinnghiemthu = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNguoiNghiemThu_6 = New System.Windows.Forms.Label()
        Me.cboNguoiNghiemThu = New Commons.UtcComboBox()
        Me.txtUserName = New Commons.utcTextBox()
        Me.txtTinhTrangSauBaoTri = New DevExpress.XtraEditors.MemoEdit()
        Me.lblTinhTrangSauBT = New System.Windows.Forms.Label()
        Me.lblNgayNghiemThu = New System.Windows.Forms.Label()
        Me.txtNgayNghiemThu = New DevExpress.XtraEditors.DateEdit()
        Me.txtSGLuyKe = New DevExpress.XtraEditors.TextEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.btnIn_giaonhan = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.mnuBCCongViecNoiBo = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuBCCongViecDichVu = New DevExpress.XtraBars.BarButtonItem()
        Me.grpChiPhiPBT = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblChiPhiPT = New System.Windows.Forms.Label()
        Me.txtChiPhiTongCongUSD = New Commons.utcTextBox()
        Me.txtChiPhiKhacUSD = New Commons.utcTextBox()
        Me.txtChiPhiTongCongMacDinh = New Commons.utcTextBox()
        Me.lblUSD = New System.Windows.Forms.Label()
        Me.lblChiPhiTongCong = New System.Windows.Forms.Label()
        Me.txtChiPhiKhacMacDinh = New Commons.utcTextBox()
        Me.lblTienMD = New System.Windows.Forms.Label()
        Me.LblKhac = New System.Windows.Forms.Label()
        Me.txtChiPhiPhuTungMacDinh = New Commons.utcTextBox()
        Me.txtChiPhiPhuTungUSD = New Commons.utcTextBox()
        Me.lblChiPhiVatTu = New System.Windows.Forms.Label()
        Me.txtChiPhiVatTuMacDinh = New Commons.utcTextBox()
        Me.txtChiPhiThueNgoaiUSD = New Commons.utcTextBox()
        Me.txtChiPhiVatTuUSD = New Commons.utcTextBox()
        Me.txtChiPhiThueNgoaiMacDinh = New Commons.utcTextBox()
        Me.txtChiPhiNhanCongUSD = New Commons.utcTextBox()
        Me.lblChiPhiThueNgoai = New System.Windows.Forms.Label()
        Me.lblChiPhiNhanCong = New System.Windows.Forms.Label()
        Me.txtChiPhiNhanCongMacDinh = New Commons.utcTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnHThanhNT = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXacnhanNT = New DevExpress.XtraEditors.SimpleButton()
        Me.BT_CHECK_DL_KHO = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCapNhatTuDong = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaPBTK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat5 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTroVe5 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongGhi5 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaPTTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhi5 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAllocate = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPhanBoLai = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSua5 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoa5 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaTTNT = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLockPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTingTrangSauBaoTri_6 = New System.Windows.Forms.Label()
        Me.mbtnKHT_GET_Nam = New DevExpress.XtraBars.BarButtonItem()
        Me.mbtnKHT_GET_BTDK = New DevExpress.XtraBars.BarButtonItem()
        Me.mbtnKHT_GET_Thang = New DevExpress.XtraBars.BarButtonItem()
        Me.mbtnKHT_GET_CV = New DevExpress.XtraBars.BarButtonItem()
        Me.mbtnKHN_GET_BTDK = New DevExpress.XtraBars.BarButtonItem()
        Me.mbtnKHN_GET_Nam = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuOpt1 = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuOpt2 = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuOpt3 = New DevExpress.XtraBars.BarButtonItem()
        Me.mbtnKHT_GET_CV_TU_NAM = New DevExpress.XtraBars.BarButtonItem()
        Me.tabCongViecNoiBo = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.tabCViec = New DevExpress.XtraTab.XtraTabControl()
        Me.tabCVChinh = New DevExpress.XtraTab.XtraTabPage()
        Me.ucCongViecPBT = New MVControl.ucCongViecPBT()
        Me.tabCVPhu = New DevExpress.XtraTab.XtraTabPage()
        Me.ucCVPTro = New MVControl.ucCongViecPhuTro()
        Me.ucCongViecNS = New MVControl.ucNhanSuPBT()
        Me.menuThemViTri = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnThemViTri = New System.Windows.Forms.ToolStripMenuItem()
        Me.ucDichVu = New MVControl.ucDichVuPBT()
        Me.cboMAY = New DevExpress.XtraEditors.LookUpEdit()
        Me.tabDanhSachPhieuBaoTri = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdDanhSach_1 = New DevExpress.XtraGrid.GridControl()
        Me.grvDanhSach_1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnNHHTNTL = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBanGiao = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnXemtailieu = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnChonTaiLieu = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMucUuTien = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUnLock = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTimKiemTheoMaPBT_1 = New System.Windows.Forms.Label()
        Me.btnAuto = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoat_1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongGhi_1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThem_1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoa_1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSua_1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnIn_1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnInPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnKhoaPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTGNgungMay = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDuyetPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhi_1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.optNTHT = New DevExpress.XtraEditors.RadioGroup()
        Me.lblDenngay_1 = New System.Windows.Forms.Label()
        Me.lblTimKiem = New System.Windows.Forms.Label()
        Me.btnLocPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.dtDNgay_1 = New DevExpress.XtraEditors.DateEdit()
        Me.dtTNgay_1 = New DevExpress.XtraEditors.DateEdit()
        Me.txtTimKiemPBT = New DevExpress.XtraEditors.TextEdit()
        Me.grpChonXem_1 = New System.Windows.Forms.GroupBox()
        Me.menuTinhTrangPBTCT = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TabPhieuBaoTri = New DevExpress.XtraTab.XtraTabControl()
        Me.tabJobcard = New DevExpress.XtraTab.XtraTabPage()
        Me.btnCapnhatthoigiancongviec = New System.Windows.Forms.Button()
        Me.tabDichVuThueNgoai = New DevExpress.XtraTab.XtraTabPage()
        Me.tabHechuyengia = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl6 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.tvwCautrucTB1 = New DevExpress.XtraTreeList.TreeList()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel16 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.btnThemClass = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongghiClass = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSuaClass = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhiClass = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaClass = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoatClass = New DevExpress.XtraEditors.SimpleButton()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.lblProblem = New System.Windows.Forms.Label()
        Me.txtClass = New DevExpress.XtraEditors.TextEdit()
        Me.lblCause = New System.Windows.Forms.Label()
        Me.lblRemedy = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.txtNoteClass = New DevExpress.XtraEditors.MemoEdit()
        Me.cboProblem = New System.Windows.Forms.ComboBox()
        Me.cboCause = New System.Windows.Forms.ComboBox()
        Me.cboRemedy = New System.Windows.Forms.ComboBox()
        Me.txtBPLine = New DevExpress.XtraEditors.TextEdit()
        Me.grdProblem = New DevExpress.XtraGrid.GridControl()
        Me.grvProblem = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tabPHTT = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel22 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel23 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnThemPHTT = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnGhiPHTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaPHTT = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.btnKhongPHTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoatPHTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSuaPHTT = New DevExpress.XtraEditors.SimpleButton()
        Me.grdPHTT = New DevExpress.XtraGrid.GridControl()
        Me.grvPHTT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblNDungPHTT = New DevExpress.XtraEditors.LabelControl()
        Me.lblEmailPHTT = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmailPHTT = New DevExpress.XtraEditors.TextEdit()
        Me.txtNDungPHTT = New DevExpress.XtraEditors.TextEdit()
        Me.txtSTTPHTT = New DevExpress.XtraEditors.TextEdit()
        Me.tabYeuCauBT = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel24 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdYCBT = New DevExpress.XtraGrid.GridControl()
        Me.grvYCBT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.btnXoaYCBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoatYCBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThemSuaYCBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhiYCBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongGhiYCBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonYCSD = New DevExpress.XtraEditors.SimpleButton()
        Me.tabNguoiGiamSat = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel17 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdNGSat = New DevExpress.XtraGrid.GridControl()
        Me.grvNGSat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnThemSuaNGS = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaNGS = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoatNGS = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhiNGS = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongGhiNGS = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.tabTTBT = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel26 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdTTBT = New DevExpress.XtraGrid.GridControl()
        Me.grvTTBT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.btnThemSuaTTBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaTTBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThoatTTBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhiTTBT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongGhiTTBT = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton9 = New DevExpress.XtraEditors.SimpleButton()
        Me.tabPBTTinhTrang = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel28 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdTTPBT = New DevExpress.XtraGrid.GridControl()
        Me.grvTTPBT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel29 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.btnXoaPBTTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGhiPBTTT = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.btnThoatPBTTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhongPBTTT = New DevExpress.XtraEditors.SimpleButton()
        Me.btnThemPBTTT = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPBTTinhTrang = New DevExpress.XtraEditors.LabelControl()
        Me.lblGhiChu = New DevExpress.XtraEditors.LabelControl()
        Me.txtGhiChuPBTTT = New DevExpress.XtraEditors.TextEdit()
        Me.txtSTTPBTTT = New DevExpress.XtraEditors.TextEdit()
        Me.lblNgay = New DevExpress.XtraEditors.LabelControl()
        Me.cboPBTTTrang = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtNgay = New DevExpress.XtraEditors.DateEdit()
        Me.btnThemTTPBT = New DevExpress.XtraEditors.SimpleButton()
        Me.ofdDuongdan = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCa = New System.Windows.Forms.Label()
        Me.dtNgayKTKH1 = New DevExpress.XtraEditors.DateEdit()
        Me.cboNguyenNhan = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtMaSoPBT = New DevExpress.XtraEditors.TextEdit()
        Me.dtKTTT1 = New DevExpress.XtraEditors.DateEdit()
        Me.lblGiohong = New System.Windows.Forms.Label()
        Me.lblNgayBDKH = New System.Windows.Forms.Label()
        Me.lblGioLap = New System.Windows.Forms.Label()
        Me.txtDenGioHong = New Commons.MaskedTextBoxNew()
        Me.lblNguyenNhan = New System.Windows.Forms.Label()
        Me.lblNgayCNBDKH = New System.Windows.Forms.Label()
        Me.txtNgayhong = New Commons.MaskedTextBoxNew()
        Me.txtDenNgayHong = New Commons.MaskedTextBoxNew()
        Me.dtDenKTTT1 = New DevExpress.XtraEditors.DateEdit()
        Me.txtLydo_1 = New DevExpress.XtraEditors.TextEdit()
        Me.dtNgayLap1 = New DevExpress.XtraEditors.DateEdit()
        Me.dtpNgayCNBDKH1 = New DevExpress.XtraEditors.DateEdit()
        Me.dtNgayBDKH1 = New DevExpress.XtraEditors.DateEdit()
        Me.cboNguoiLap1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtUserNLap = New DevExpress.XtraEditors.TextEdit()
        Me.btnChonMay = New DevExpress.XtraEditors.SimpleButton()
        Me.cboLoaiBT = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabSoPhieuBaoTri = New System.Windows.Forms.Label()
        Me.txtSoPhieuBaoTri1 = New DevExpress.XtraEditors.TextEdit()
        Me.cboMucUuTien1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboGS_Vien1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboCa = New DevExpress.XtraEditors.LookUpEdit()
        Me.TableLayoutPanel27 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVideo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHelp = New DevExpress.XtraEditors.SimpleButton()
        Me.cboTinhTrangPBT = New Commons.UtcComboBox()
        Me.PopupMenu2 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabKetThucPhieuBaoTri.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl5.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        Me.grpPhutungthaythe.SuspendLayout()
        CType(Me.grdPTThayThe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvPTThayThe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPTTTChiTiet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvPTTTChiTiet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grdVatTuNT.SuspendLayout()
        CType(Me.grdVTNghiemThu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvVTNghiemThu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel14.SuspendLayout()
        Me.grpThongtinthuchien.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.txtNgayBatDau.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgayKetThuc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTongGioCong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpThongtinnghiemthu.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTinhTrangSauBaoTri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgayNghiemThu.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgayNghiemThu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSGLuyKe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpChiPhiPBT.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.txtChiPhiTongCongUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiKhacUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiTongCongMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiKhacMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiPhuTungMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiPhuTungUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiVatTuMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiThueNgoaiUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiVatTuUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiThueNgoaiMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiNhanCongUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiPhiNhanCongMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.tabCongViecNoiBo.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        CType(Me.tabCViec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCViec.SuspendLayout()
        Me.tabCVChinh.SuspendLayout()
        Me.tabCVPhu.SuspendLayout()
        Me.menuThemViTri.SuspendLayout()
        CType(Me.cboMAY.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDanhSachPhieuBaoTri.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        CType(Me.grdDanhSach_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvDanhSach_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.optNTHT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDNgay_1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDNgay_1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTNgay_1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTNgay_1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimKiemPBT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPhieuBaoTri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPhieuBaoTri.SuspendLayout()
        Me.tabJobcard.SuspendLayout()
        Me.tabDichVuThueNgoai.SuspendLayout()
        Me.tabHechuyengia.SuspendLayout()
        CType(Me.SplitContainerControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.tvwCautrucTB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.TableLayoutPanel16.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.txtClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoteClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBPLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProblem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvProblem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPHTT.SuspendLayout()
        Me.TableLayoutPanel22.SuspendLayout()
        Me.TableLayoutPanel23.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        CType(Me.grdPHTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvPHTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmailPHTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNDungPHTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSTTPHTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabYeuCauBT.SuspendLayout()
        Me.TableLayoutPanel24.SuspendLayout()
        CType(Me.grdYCBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvYCBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        Me.tabNguoiGiamSat.SuspendLayout()
        Me.TableLayoutPanel17.SuspendLayout()
        CType(Me.grdNGSat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvNGSat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.tabTTBT.SuspendLayout()
        Me.TableLayoutPanel26.SuspendLayout()
        CType(Me.grdTTBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvTTBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel18.SuspendLayout()
        Me.tabPBTTinhTrang.SuspendLayout()
        Me.TableLayoutPanel28.SuspendLayout()
        CType(Me.grdTTPBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvTTPBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel29.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel20.SuspendLayout()
        CType(Me.txtGhiChuPBTTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSTTPBTTT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPBTTTrang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dtNgayKTKH1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNgayKTKH1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNguyenNhan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaSoPBT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtKTTT1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtKTTT1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDenKTTT1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDenKTTT1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLydo_1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNgayLap1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNgayLap1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpNgayCNBDKH1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpNgayCNBDKH1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNgayBDKH1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNgayBDKH1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNguoiLap1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserNLap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLoaiBT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSoPhieuBaoTri1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMucUuTien1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGS_Vien1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel27.SuspendLayout()
        CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMaSoPBT
        '
        Me.lblMaSoPBT.AutoSize = True
        Me.lblMaSoPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaSoPBT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaSoPBT.ForeColor = System.Drawing.Color.Black
        Me.lblMaSoPBT.Location = New System.Drawing.Point(3, 0)
        Me.lblMaSoPBT.Name = "lblMaSoPBT"
        Me.lblMaSoPBT.Size = New System.Drawing.Size(74, 24)
        Me.lblMaSoPBT.TabIndex = 13
        Me.lblMaSoPBT.Text = "Mã số PBT"
        Me.lblMaSoPBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMS_ThietBi
        '
        Me.lblMS_ThietBi.AutoSize = True
        Me.lblMS_ThietBi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMS_ThietBi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMS_ThietBi.ForeColor = System.Drawing.Color.Black
        Me.lblMS_ThietBi.Location = New System.Drawing.Point(404, 0)
        Me.lblMS_ThietBi.Name = "lblMS_ThietBi"
        Me.lblMS_ThietBi.Size = New System.Drawing.Size(74, 24)
        Me.lblMS_ThietBi.TabIndex = 15
        Me.lblMS_ThietBi.Text = "MS thiết bị"
        Me.lblMS_ThietBi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayLap
        '
        Me.lblNgayLap.AutoSize = True
        Me.lblNgayLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayLap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayLap.ForeColor = System.Drawing.Color.Black
        Me.lblNgayLap.Location = New System.Drawing.Point(880, 0)
        Me.lblNgayLap.Name = "lblNgayLap"
        Me.lblNgayLap.Size = New System.Drawing.Size(74, 24)
        Me.lblNgayLap.TabIndex = 13
        Me.lblNgayLap.Text = "Ngày lập"
        Me.lblNgayLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLyDo
        '
        Me.lblLyDo.AutoSize = True
        Me.lblLyDo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLyDo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLyDo.ForeColor = System.Drawing.Color.Black
        Me.lblLyDo.Location = New System.Drawing.Point(3, 72)
        Me.lblLyDo.Name = "lblLyDo"
        Me.lblLyDo.Size = New System.Drawing.Size(74, 27)
        Me.lblLyDo.TabIndex = 13
        Me.lblLyDo.Text = "Lý do"
        Me.lblLyDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtGioLap
        '
        Me.dtGioLap.BackColor = System.Drawing.Color.White
        Me.dtGioLap.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.dtGioLap, 3)
        Me.dtGioLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtGioLap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtGioLap.Location = New System.Drawing.Point(723, 3)
        Me.dtGioLap.Mask = "00:00"
        Me.dtGioLap.Name = "dtGioLap"
        Me.dtGioLap.Size = New System.Drawing.Size(151, 21)
        Me.dtGioLap.TabIndex = 3
        Me.dtGioLap.ValidatingType = GetType(Date)
        '
        'txtGiohong
        '
        Me.txtGiohong.BackColor = System.Drawing.SystemColors.Window
        Me.txtGiohong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtGiohong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGiohong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiohong.Location = New System.Drawing.Point(723, 51)
        Me.txtGiohong.Mask = "00:00"
        Me.txtGiohong.Name = "txtGiohong"
        Me.txtGiohong.Size = New System.Drawing.Size(45, 21)
        Me.txtGiohong.TabIndex = 11
        Me.txtGiohong.ValidatingType = GetType(Date)
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblGS_Vien
        '
        Me.lblGS_Vien.AutoSize = True
        Me.lblGS_Vien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGS_Vien.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGS_Vien.ForeColor = System.Drawing.Color.Black
        Me.lblGS_Vien.Location = New System.Drawing.Point(404, 48)
        Me.lblGS_Vien.Name = "lblGS_Vien"
        Me.lblGS_Vien.Size = New System.Drawing.Size(74, 24)
        Me.lblGS_Vien.TabIndex = 13
        Me.lblGS_Vien.Text = "GS viên "
        Me.lblGS_Vien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTGNM
        '
        Me.lblTGNM.AutoSize = True
        Me.lblTGNM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTGNM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTGNM.ForeColor = System.Drawing.Color.Black
        Me.lblTGNM.Location = New System.Drawing.Point(211, 24)
        Me.lblTGNM.Name = "lblTGNM"
        Me.lblTGNM.Size = New System.Drawing.Size(59, 24)
        Me.lblTGNM.TabIndex = 13
        Me.lblTGNM.Text = "User name"
        Me.lblTGNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKTTT
        '
        Me.lblKTTT.AutoSize = True
        Me.lblKTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKTTT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKTTT.ForeColor = System.Drawing.Color.Black
        Me.lblKTTT.Location = New System.Drawing.Point(880, 48)
        Me.lblKTTT.Name = "lblKTTT"
        Me.lblKTTT.Size = New System.Drawing.Size(74, 24)
        Me.lblKTTT.TabIndex = 13
        Me.lblKTTT.Text = "Ngày "
        Me.lblKTTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayKTKH
        '
        Me.lblNgayKTKH.AutoSize = True
        Me.lblNgayKTKH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayKTKH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayKTKH.ForeColor = System.Drawing.Color.Black
        Me.lblNgayKTKH.Location = New System.Drawing.Point(880, 24)
        Me.lblNgayKTKH.Name = "lblNgayKTKH"
        Me.lblNgayKTKH.Size = New System.Drawing.Size(74, 24)
        Me.lblNgayKTKH.TabIndex = 13
        Me.lblNgayKTKH.Text = "KTKH"
        Me.lblNgayKTKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNguoiLap
        '
        Me.lblNguoiLap.AutoSize = True
        Me.lblNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNguoiLap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNguoiLap.ForeColor = System.Drawing.Color.Black
        Me.lblNguoiLap.Location = New System.Drawing.Point(3, 24)
        Me.lblNguoiLap.Name = "lblNguoiLap"
        Me.lblNguoiLap.Size = New System.Drawing.Size(74, 24)
        Me.lblNguoiLap.TabIndex = 13
        Me.lblNguoiLap.Text = "Người lập"
        Me.lblNguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMucUuTien
        '
        Me.lblMucUuTien.AutoSize = True
        Me.lblMucUuTien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMucUuTien.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMucUuTien.ForeColor = System.Drawing.Color.Black
        Me.lblMucUuTien.Location = New System.Drawing.Point(3, 48)
        Me.lblMucUuTien.Name = "lblMucUuTien"
        Me.lblMucUuTien.Size = New System.Drawing.Size(74, 24)
        Me.lblMucUuTien.TabIndex = 13
        Me.lblMucUuTien.Text = "Mức UT"
        Me.lblMucUuTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoaiBT
        '
        Me.lblLoaiBT.AutoSize = True
        Me.lblLoaiBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoaiBT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoaiBT.ForeColor = System.Drawing.Color.Black
        Me.lblLoaiBT.Location = New System.Drawing.Point(404, 24)
        Me.lblLoaiBT.Name = "lblLoaiBT"
        Me.lblLoaiBT.Size = New System.Drawing.Size(74, 24)
        Me.lblLoaiBT.TabIndex = 15
        Me.lblLoaiBT.Text = "Loại BT"
        Me.lblLoaiBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabKetThucPhieuBaoTri
        '
        Me.tabKetThucPhieuBaoTri.Controls.Add(Me.TableLayoutPanel3)
        Me.tabKetThucPhieuBaoTri.Controls.Add(Me.lblTingTrangSauBaoTri_6)
        Me.tabKetThucPhieuBaoTri.Name = "tabKetThucPhieuBaoTri"
        Me.tabKetThucPhieuBaoTri.Size = New System.Drawing.Size(1270, 545)
        Me.tabKetThucPhieuBaoTri.Text = "Kết thúc Phiếu bảo trì "
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.SplitContainerControl5, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 5)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.97095!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.02905!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1270, 545)
        Me.TableLayoutPanel3.TabIndex = 55
        '
        'SplitContainerControl5
        '
        Me.SplitContainerControl5.AutoSize = True
        Me.SplitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl5.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl5.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerControl5.LookAndFeel.SkinName = "Blue"
        Me.SplitContainerControl5.Name = "SplitContainerControl5"
        Me.SplitContainerControl5.Panel1.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl5.Panel1.Text = "Panel1"
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.TableLayoutPanel14)
        Me.SplitContainerControl5.Panel2.Text = "Panel2"
        Me.TableLayoutPanel3.SetRowSpan(Me.SplitContainerControl5, 5)
        Me.SplitContainerControl5.ScrollBarSmallChange = 1
        Me.SplitContainerControl5.Size = New System.Drawing.Size(1264, 501)
        Me.SplitContainerControl5.SplitterPosition = 762
        Me.SplitContainerControl5.TabIndex = 67
        Me.SplitContainerControl5.Text = "SplitContainerControl1"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.AutoSize = True
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.grpPhutungthaythe)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SplitContainerControl4)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(507, 501)
        Me.SplitContainerControl2.SplitterPosition = 168
        Me.SplitContainerControl2.TabIndex = 65
        Me.SplitContainerControl2.Text = "SplitContainerControl1"
        '
        'grpPhutungthaythe
        '
        Me.grpPhutungthaythe.Controls.Add(Me.grdPTThayThe)
        Me.grpPhutungthaythe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPhutungthaythe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPhutungthaythe.ForeColor = System.Drawing.Color.Maroon
        Me.grpPhutungthaythe.Location = New System.Drawing.Point(0, 0)
        Me.grpPhutungthaythe.Name = "grpPhutungthaythe"
        Me.grpPhutungthaythe.Size = New System.Drawing.Size(507, 114)
        Me.grpPhutungthaythe.TabIndex = 49
        Me.grpPhutungthaythe.TabStop = False
        Me.grpPhutungthaythe.Text = "Phụ tùng thay thế "
        '
        'grdPTThayThe
        '
        Me.grdPTThayThe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPTThayThe.Location = New System.Drawing.Point(3, 17)
        Me.grdPTThayThe.LookAndFeel.SkinName = "Blue"
        Me.grdPTThayThe.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdPTThayThe.MainView = Me.grvPTThayThe
        Me.grdPTThayThe.Name = "grdPTThayThe"
        Me.grdPTThayThe.Size = New System.Drawing.Size(501, 94)
        Me.grdPTThayThe.TabIndex = 26
        Me.grdPTThayThe.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPTThayThe, Me.GridView2})
        '
        'grvPTThayThe
        '
        Me.grvPTThayThe.GridControl = Me.grdPTThayThe
        Me.grvPTThayThe.Name = "grvPTThayThe"
        Me.grvPTThayThe.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvPTThayThe.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvPTThayThe.OptionsBehavior.Editable = False
        Me.grvPTThayThe.OptionsLayout.Columns.AddNewColumns = False
        Me.grvPTThayThe.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvPTThayThe.OptionsView.ColumnAutoWidth = False
        Me.grvPTThayThe.OptionsView.EnableAppearanceEvenRow = True
        Me.grvPTThayThe.OptionsView.EnableAppearanceOddRow = True
        Me.grvPTThayThe.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdPTThayThe
        Me.GridView2.Name = "GridView2"
        '
        'SplitContainerControl4
        '
        Me.SplitContainerControl4.AutoSize = True
        Me.SplitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl4.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl4.Horizontal = False
        Me.SplitContainerControl4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl4.LookAndFeel.SkinName = "Blue"
        Me.SplitContainerControl4.Name = "SplitContainerControl4"
        Me.SplitContainerControl4.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainerControl4.Panel1.Text = "Panel1"
        Me.SplitContainerControl4.Panel2.Controls.Add(Me.grdVatTuNT)
        Me.SplitContainerControl4.Panel2.Text = "Panel2"
        Me.SplitContainerControl4.Size = New System.Drawing.Size(507, 381)
        Me.SplitContainerControl4.SplitterPosition = 158
        Me.SplitContainerControl4.TabIndex = 66
        Me.SplitContainerControl4.Text = "SplitContainerControl1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdPTTTChiTiet)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 125)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chi tiết thay thế phụ tùng"
        '
        'grdPTTTChiTiet
        '
        Me.grdPTTTChiTiet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPTTTChiTiet.Location = New System.Drawing.Point(3, 17)
        Me.grdPTTTChiTiet.LookAndFeel.SkinName = "Blue"
        Me.grdPTTTChiTiet.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdPTTTChiTiet.MainView = Me.grvPTTTChiTiet
        Me.grdPTTTChiTiet.Name = "grdPTTTChiTiet"
        Me.grdPTTTChiTiet.Size = New System.Drawing.Size(501, 105)
        Me.grdPTTTChiTiet.TabIndex = 27
        Me.grdPTTTChiTiet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPTTTChiTiet, Me.GridView4})
        '
        'grvPTTTChiTiet
        '
        Me.grvPTTTChiTiet.GridControl = Me.grdPTTTChiTiet
        Me.grvPTTTChiTiet.Name = "grvPTTTChiTiet"
        Me.grvPTTTChiTiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvPTTTChiTiet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvPTTTChiTiet.OptionsBehavior.Editable = False
        Me.grvPTTTChiTiet.OptionsLayout.Columns.AddNewColumns = False
        Me.grvPTTTChiTiet.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvPTTTChiTiet.OptionsView.ColumnAutoWidth = False
        Me.grvPTTTChiTiet.OptionsView.EnableAppearanceEvenRow = True
        Me.grvPTTTChiTiet.OptionsView.EnableAppearanceOddRow = True
        Me.grvPTTTChiTiet.OptionsView.ShowGroupPanel = False
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdPTTTChiTiet
        Me.GridView4.Name = "GridView4"
        '
        'grdVatTuNT
        '
        Me.grdVatTuNT.Controls.Add(Me.grdVTNghiemThu)
        Me.grdVatTuNT.Controls.Add(Me.grdChung)
        Me.grdVatTuNT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVatTuNT.ForeColor = System.Drawing.Color.DarkRed
        Me.grdVatTuNT.Location = New System.Drawing.Point(0, 0)
        Me.grdVatTuNT.Name = "grdVatTuNT"
        Me.grdVatTuNT.Size = New System.Drawing.Size(507, 250)
        Me.grdVatTuNT.TabIndex = 54
        Me.grdVatTuNT.TabStop = False
        Me.grdVatTuNT.Text = "Vat Tu xuat"
        '
        'grdVTNghiemThu
        '
        Me.grdVTNghiemThu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVTNghiemThu.Location = New System.Drawing.Point(3, 17)
        Me.grdVTNghiemThu.LookAndFeel.SkinName = "Blue"
        Me.grdVTNghiemThu.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdVTNghiemThu.MainView = Me.grvVTNghiemThu
        Me.grdVTNghiemThu.Name = "grdVTNghiemThu"
        Me.grdVTNghiemThu.Size = New System.Drawing.Size(501, 230)
        Me.grdVTNghiemThu.TabIndex = 58
        Me.grdVTNghiemThu.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvVTNghiemThu, Me.GridView6})
        '
        'grvVTNghiemThu
        '
        Me.grvVTNghiemThu.GridControl = Me.grdVTNghiemThu
        Me.grvVTNghiemThu.Name = "grvVTNghiemThu"
        Me.grvVTNghiemThu.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvVTNghiemThu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvVTNghiemThu.OptionsBehavior.Editable = False
        Me.grvVTNghiemThu.OptionsLayout.Columns.AddNewColumns = False
        Me.grvVTNghiemThu.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvVTNghiemThu.OptionsView.ColumnAutoWidth = False
        Me.grvVTNghiemThu.OptionsView.EnableAppearanceEvenRow = True
        Me.grvVTNghiemThu.OptionsView.EnableAppearanceOddRow = True
        Me.grvVTNghiemThu.OptionsView.ShowGroupPanel = False
        '
        'GridView6
        '
        Me.GridView6.GridControl = Me.grdVTNghiemThu
        Me.GridView6.Name = "GridView6"
        '
        'grdChung
        '
        Me.grdChung.Location = New System.Drawing.Point(51, 78)
        Me.grdChung.MainView = Me.grvChung
        Me.grdChung.Name = "grdChung"
        Me.grdChung.Size = New System.Drawing.Size(13, 10)
        Me.grdChung.TabIndex = 57
        Me.grdChung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvChung})
        Me.grdChung.Visible = False
        '
        'grvChung
        '
        Me.grvChung.GridControl = Me.grdChung
        Me.grvChung.Name = "grvChung"
        Me.grvChung.OptionsView.ShowGroupPanel = False
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.ColumnCount = 1
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel14.Controls.Add(Me.grpThongtinthuchien, 0, 1)
        Me.TableLayoutPanel14.Controls.Add(Me.grpThongtinnghiemthu, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.grpChiPhiPBT, 0, 2)
        Me.TableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 3
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(751, 501)
        Me.TableLayoutPanel14.TabIndex = 57
        '
        'grpThongtinthuchien
        '
        Me.grpThongtinthuchien.Controls.Add(Me.TableLayoutPanel4)
        Me.grpThongtinthuchien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpThongtinthuchien.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpThongtinthuchien.ForeColor = System.Drawing.Color.Maroon
        Me.grpThongtinthuchien.Location = New System.Drawing.Point(3, 182)
        Me.grpThongtinthuchien.Name = "grpThongtinthuchien"
        Me.grpThongtinthuchien.Size = New System.Drawing.Size(745, 46)
        Me.grpThongtinthuchien.TabIndex = 51
        Me.grpThongtinthuchien.TabStop = False
        Me.grpThongtinthuchien.Text = "Thông tin thực hiện  "
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.Controls.Add(Me.lblNgayBatDau, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtNgayBatDau, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtNgayKetThuc, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblNgayKetThuc, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtTongGioCong, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lblTonggiocong, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(739, 26)
        Me.TableLayoutPanel4.TabIndex = 32
        '
        'lblNgayBatDau
        '
        Me.lblNgayBatDau.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayBatDau.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayBatDau.ForeColor = System.Drawing.Color.Black
        Me.lblNgayBatDau.Location = New System.Drawing.Point(3, 3)
        Me.lblNgayBatDau.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblNgayBatDau.Name = "lblNgayBatDau"
        Me.lblNgayBatDau.Size = New System.Drawing.Size(114, 19)
        Me.lblNgayBatDau.TabIndex = 19
        Me.lblNgayBatDau.Text = "Bắt đầu "
        Me.lblNgayBatDau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNgayBatDau
        '
        Me.txtNgayBatDau.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtNgayBatDau.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtNgayBatDau.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNgayBatDau.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNgayBatDau.FieldName = ""
        Me.txtNgayBatDau.IsNull = True
        Me.txtNgayBatDau.Location = New System.Drawing.Point(123, 3)
        Me.txtNgayBatDau.MaxLength = 0
        Me.txtNgayBatDau.Multiline = False
        Me.txtNgayBatDau.Name = "txtNgayBatDau"
        Me.txtNgayBatDau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNgayBatDau.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtNgayBatDau.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayBatDau.Properties.Appearance.Options.UseBackColor = True
        Me.txtNgayBatDau.Properties.Appearance.Options.UseFont = True
        Me.txtNgayBatDau.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNgayBatDau.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtNgayBatDau.Properties.ReadOnly = True
        Me.txtNgayBatDau.ReadOnly = True
        Me.txtNgayBatDau.Size = New System.Drawing.Size(200, 20)
        Me.txtNgayBatDau.TabIndex = 30
        Me.txtNgayBatDau.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNgayBatDau.TextTypeMode = Commons.TypeMode.None
        '
        'txtNgayKetThuc
        '
        Me.txtNgayKetThuc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtNgayKetThuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtNgayKetThuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNgayKetThuc.ErrorProviderControl = Me.ErrorProvider1
        Me.txtNgayKetThuc.FieldName = ""
        Me.txtNgayKetThuc.IsNull = True
        Me.txtNgayKetThuc.Location = New System.Drawing.Point(535, 3)
        Me.txtNgayKetThuc.MaxLength = 0
        Me.txtNgayKetThuc.Multiline = False
        Me.txtNgayKetThuc.Name = "txtNgayKetThuc"
        Me.txtNgayKetThuc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNgayKetThuc.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtNgayKetThuc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayKetThuc.Properties.Appearance.Options.UseBackColor = True
        Me.txtNgayKetThuc.Properties.Appearance.Options.UseFont = True
        Me.txtNgayKetThuc.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNgayKetThuc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtNgayKetThuc.Properties.ReadOnly = True
        Me.txtNgayKetThuc.ReadOnly = True
        Me.txtNgayKetThuc.Size = New System.Drawing.Size(201, 20)
        Me.txtNgayKetThuc.TabIndex = 31
        Me.txtNgayKetThuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNgayKetThuc.TextTypeMode = Commons.TypeMode.None
        '
        'lblNgayKetThuc
        '
        Me.lblNgayKetThuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayKetThuc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayKetThuc.ForeColor = System.Drawing.Color.Black
        Me.lblNgayKetThuc.Location = New System.Drawing.Point(329, 3)
        Me.lblNgayKetThuc.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblNgayKetThuc.Name = "lblNgayKetThuc"
        Me.lblNgayKetThuc.Size = New System.Drawing.Size(200, 19)
        Me.lblNgayKetThuc.TabIndex = 19
        Me.lblNgayKetThuc.Text = "Kết thúc "
        Me.lblNgayKetThuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTongGioCong
        '
        Me.txtTongGioCong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTongGioCong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableLayoutPanel4.SetColumnSpan(Me.txtTongGioCong, 3)
        Me.txtTongGioCong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTongGioCong.ErrorProviderControl = Me.ErrorProvider1
        Me.txtTongGioCong.FieldName = ""
        Me.txtTongGioCong.IsNull = True
        Me.txtTongGioCong.Location = New System.Drawing.Point(123, 28)
        Me.txtTongGioCong.MaxLength = 0
        Me.txtTongGioCong.Multiline = False
        Me.txtTongGioCong.Name = "txtTongGioCong"
        Me.txtTongGioCong.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTongGioCong.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtTongGioCong.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongGioCong.Properties.Appearance.Options.UseBackColor = True
        Me.txtTongGioCong.Properties.Appearance.Options.UseFont = True
        Me.txtTongGioCong.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTongGioCong.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtTongGioCong.Properties.ReadOnly = True
        Me.txtTongGioCong.ReadOnly = True
        Me.txtTongGioCong.Size = New System.Drawing.Size(613, 20)
        Me.txtTongGioCong.TabIndex = 29
        Me.txtTongGioCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTongGioCong.TextTypeMode = Commons.TypeMode.None
        '
        'lblTonggiocong
        '
        Me.lblTonggiocong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTonggiocong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTonggiocong.ForeColor = System.Drawing.Color.Black
        Me.lblTonggiocong.Location = New System.Drawing.Point(3, 28)
        Me.lblTonggiocong.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblTonggiocong.Name = "lblTonggiocong"
        Me.lblTonggiocong.Size = New System.Drawing.Size(114, 19)
        Me.lblTonggiocong.TabIndex = 28
        Me.lblTonggiocong.Text = "Tổng số giờ công "
        Me.lblTonggiocong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpThongtinnghiemthu
        '
        Me.grpThongtinnghiemthu.Controls.Add(Me.TableLayoutPanel5)
        Me.grpThongtinnghiemthu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpThongtinnghiemthu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpThongtinnghiemthu.ForeColor = System.Drawing.Color.Maroon
        Me.grpThongtinnghiemthu.Location = New System.Drawing.Point(3, 3)
        Me.grpThongtinnghiemthu.Name = "grpThongtinnghiemthu"
        Me.grpThongtinnghiemthu.Size = New System.Drawing.Size(745, 173)
        Me.grpThongtinnghiemthu.TabIndex = 52
        Me.grpThongtinnghiemthu.TabStop = False
        Me.grpThongtinnghiemthu.Text = "Thông tin nghiệm thu "
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 4
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.Controls.Add(Me.lblNguoiNghiemThu_6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cboNguoiNghiemThu, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtUserName, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtTinhTrangSauBaoTri, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.lblTinhTrangSauBT, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.lblNgayNghiemThu, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtNgayNghiemThu, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtSGLuyKe, 3, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(739, 153)
        Me.TableLayoutPanel5.TabIndex = 38
        '
        'lblNguoiNghiemThu_6
        '
        Me.lblNguoiNghiemThu_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNguoiNghiemThu_6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNguoiNghiemThu_6.ForeColor = System.Drawing.Color.Black
        Me.lblNguoiNghiemThu_6.Location = New System.Drawing.Point(3, 3)
        Me.lblNguoiNghiemThu_6.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblNguoiNghiemThu_6.Name = "lblNguoiNghiemThu_6"
        Me.lblNguoiNghiemThu_6.Size = New System.Drawing.Size(114, 19)
        Me.lblNguoiNghiemThu_6.TabIndex = 19
        Me.lblNguoiNghiemThu_6.Text = "Người nghiệm thu"
        Me.lblNguoiNghiemThu_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNguoiNghiemThu
        '
        Me.cboNguoiNghiemThu.AssemblyName = ""
        Me.cboNguoiNghiemThu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboNguoiNghiemThu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNguoiNghiemThu.BackColor = System.Drawing.Color.White
        Me.cboNguoiNghiemThu.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboNguoiNghiemThu.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboNguoiNghiemThu.ClassName = ""
        Me.TableLayoutPanel5.SetColumnSpan(Me.cboNguoiNghiemThu, 2)
        Me.cboNguoiNghiemThu.Display = ""
        Me.cboNguoiNghiemThu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNguoiNghiemThu.Enabled = False
        Me.cboNguoiNghiemThu.ErrorProviderControl = Me.ErrorProvider1
        Me.cboNguoiNghiemThu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNguoiNghiemThu.FormattingEnabled = True
        Me.cboNguoiNghiemThu.IsAll = False
        Me.cboNguoiNghiemThu.isInputNull = False
        Me.cboNguoiNghiemThu.IsNew = False
        Me.cboNguoiNghiemThu.IsNull = True
        Me.cboNguoiNghiemThu.ItemAll = " < ALL > "
        Me.cboNguoiNghiemThu.ItemNew = "...New"
        Me.cboNguoiNghiemThu.Location = New System.Drawing.Point(123, 3)
        Me.cboNguoiNghiemThu.MethodName = ""
        Me.cboNguoiNghiemThu.Name = "cboNguoiNghiemThu"
        Me.cboNguoiNghiemThu.Param = ""
        Me.cboNguoiNghiemThu.Param2 = ""
        Me.cboNguoiNghiemThu.Size = New System.Drawing.Size(406, 21)
        Me.cboNguoiNghiemThu.StoreName = ""
        Me.cboNguoiNghiemThu.TabIndex = 31
        Me.cboNguoiNghiemThu.Table = Nothing
        Me.cboNguoiNghiemThu.TextReadonly = False
        Me.cboNguoiNghiemThu.Value = ""
        '
        'txtUserName
        '
        Me.txtUserName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtUserName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtUserName.ErrorProviderControl = Me.ErrorProvider1
        Me.txtUserName.FieldName = ""
        Me.txtUserName.IsNull = True
        Me.txtUserName.Location = New System.Drawing.Point(535, 3)
        Me.txtUserName.MaxLength = 0
        Me.txtUserName.Multiline = False
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUserName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Properties.Appearance.Options.UseBackColor = True
        Me.txtUserName.Properties.Appearance.Options.UseFont = True
        Me.txtUserName.Properties.Appearance.Options.UseTextOptions = True
        Me.txtUserName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtUserName.Properties.ReadOnly = True
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(201, 20)
        Me.txtUserName.TabIndex = 32
        Me.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUserName.TextTypeMode = Commons.TypeMode.None
        '
        'txtTinhTrangSauBaoTri
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtTinhTrangSauBaoTri, 3)
        Me.txtTinhTrangSauBaoTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTinhTrangSauBaoTri.Location = New System.Drawing.Point(123, 53)
        Me.txtTinhTrangSauBaoTri.Name = "txtTinhTrangSauBaoTri"
        Me.txtTinhTrangSauBaoTri.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtTinhTrangSauBaoTri.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTinhTrangSauBaoTri.Properties.Appearance.Options.UseBackColor = True
        Me.txtTinhTrangSauBaoTri.Properties.Appearance.Options.UseFont = True
        Me.txtTinhTrangSauBaoTri.Properties.ReadOnly = True
        Me.txtTinhTrangSauBaoTri.Size = New System.Drawing.Size(613, 97)
        Me.txtTinhTrangSauBaoTri.TabIndex = 37
        '
        'lblTinhTrangSauBT
        '
        Me.lblTinhTrangSauBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTinhTrangSauBT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTinhTrangSauBT.ForeColor = System.Drawing.Color.Black
        Me.lblTinhTrangSauBT.Location = New System.Drawing.Point(3, 53)
        Me.lblTinhTrangSauBT.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblTinhTrangSauBT.Name = "lblTinhTrangSauBT"
        Me.lblTinhTrangSauBT.Size = New System.Drawing.Size(114, 97)
        Me.lblTinhTrangSauBT.TabIndex = 19
        Me.lblTinhTrangSauBT.Text = "Tình trạng sau bảo trì "
        Me.lblTinhTrangSauBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayNghiemThu
        '
        Me.lblNgayNghiemThu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayNghiemThu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayNghiemThu.ForeColor = System.Drawing.Color.Black
        Me.lblNgayNghiemThu.Location = New System.Drawing.Point(3, 28)
        Me.lblNgayNghiemThu.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblNgayNghiemThu.Name = "lblNgayNghiemThu"
        Me.lblNgayNghiemThu.Size = New System.Drawing.Size(114, 19)
        Me.lblNgayNghiemThu.TabIndex = 19
        Me.lblNgayNghiemThu.Text = "Ngày NT/SG lũy kế"
        Me.lblNgayNghiemThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNgayNghiemThu
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtNgayNghiemThu, 2)
        Me.txtNgayNghiemThu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNgayNghiemThu.EditValue = Nothing
        Me.txtNgayNghiemThu.Location = New System.Drawing.Point(123, 28)
        Me.txtNgayNghiemThu.Name = "txtNgayNghiemThu"
        Me.txtNgayNghiemThu.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtNgayNghiemThu.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtNgayNghiemThu.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNgayNghiemThu.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtNgayNghiemThu.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNgayNghiemThu.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtNgayNghiemThu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.txtNgayNghiemThu.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtNgayNghiemThu.Size = New System.Drawing.Size(406, 20)
        Me.txtNgayNghiemThu.TabIndex = 0
        '
        'txtSGLuyKe
        '
        Me.txtSGLuyKe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSGLuyKe.Location = New System.Drawing.Point(535, 28)
        Me.txtSGLuyKe.MenuManager = Me.BarManager1
        Me.txtSGLuyKe.Name = "txtSGLuyKe"
        Me.txtSGLuyKe.Properties.Mask.EditMask = "n"
        Me.txtSGLuyKe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSGLuyKe.Size = New System.Drawing.Size(201, 20)
        Me.txtSGLuyKe.TabIndex = 32
        '
        'BarManager1
        '
        Me.BarManager1.DockingEnabled = False
        Me.BarManager1.Form = Me.btnIn_giaonhan
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.mnuBCCongViecDichVu, Me.mnuBCCongViecNoiBo})
        Me.BarManager1.MaxItemId = 21
        '
        'btnIn_giaonhan
        '
        Me.btnIn_giaonhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnIn_giaonhan.DropDownControl = Me.PopupMenu1
        Me.btnIn_giaonhan.Location = New System.Drawing.Point(210, 1)
        Me.btnIn_giaonhan.LookAndFeel.SkinName = "Blue"
        Me.btnIn_giaonhan.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnIn_giaonhan.Name = "btnIn_giaonhan"
        Me.btnIn_giaonhan.Size = New System.Drawing.Size(120, 30)
        Me.btnIn_giaonhan.TabIndex = 60
        Me.btnIn_giaonhan.Text = "btnIn_giaonhan"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnuBCCongViecNoiBo), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuBCCongViecDichVu)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'mnuBCCongViecNoiBo
        '
        Me.mnuBCCongViecNoiBo.Caption = "mnuBCCongViecNoiBo"
        Me.mnuBCCongViecNoiBo.Id = 18
        Me.mnuBCCongViecNoiBo.Name = "mnuBCCongViecNoiBo"
        '
        'mnuBCCongViecDichVu
        '
        Me.mnuBCCongViecDichVu.Caption = "mnuBCCongViecDichVu"
        Me.mnuBCCongViecDichVu.Id = 20
        Me.mnuBCCongViecDichVu.Name = "mnuBCCongViecDichVu"
        '
        'grpChiPhiPBT
        '
        Me.grpChiPhiPBT.Controls.Add(Me.TableLayoutPanel6)
        Me.grpChiPhiPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpChiPhiPBT.ForeColor = System.Drawing.Color.Maroon
        Me.grpChiPhiPBT.Location = New System.Drawing.Point(3, 234)
        Me.grpChiPhiPBT.Name = "grpChiPhiPBT"
        Me.grpChiPhiPBT.Size = New System.Drawing.Size(745, 264)
        Me.grpChiPhiPBT.TabIndex = 48
        Me.grpChiPhiPBT.TabStop = False
        Me.grpChiPhiPBT.Text = "Chi phí phiếu bảo trì "
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.lblChiPhiPT, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiTongCongUSD, 2, 6)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiKhacUSD, 2, 5)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiTongCongMacDinh, 1, 6)
        Me.TableLayoutPanel6.Controls.Add(Me.lblUSD, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblChiPhiTongCong, 0, 6)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiKhacMacDinh, 1, 5)
        Me.TableLayoutPanel6.Controls.Add(Me.lblTienMD, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LblKhac, 0, 5)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiPhuTungMacDinh, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiPhuTungUSD, 2, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.lblChiPhiVatTu, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiVatTuMacDinh, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiThueNgoaiUSD, 2, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiVatTuUSD, 2, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiThueNgoaiMacDinh, 1, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiNhanCongUSD, 2, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.lblChiPhiThueNgoai, 0, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.lblChiPhiNhanCong, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.txtChiPhiNhanCongMacDinh, 1, 3)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 8
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(739, 244)
        Me.TableLayoutPanel6.TabIndex = 27
        '
        'lblChiPhiPT
        '
        Me.lblChiPhiPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiPhiPT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiPhiPT.ForeColor = System.Drawing.Color.Black
        Me.lblChiPhiPT.Location = New System.Drawing.Point(3, 17)
        Me.lblChiPhiPT.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblChiPhiPT.Name = "lblChiPhiPT"
        Me.lblChiPhiPT.Size = New System.Drawing.Size(114, 18)
        Me.lblChiPhiPT.TabIndex = 19
        Me.lblChiPhiPT.Text = "Phụ tùng"
        Me.lblChiPhiPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChiPhiTongCongUSD
        '
        Me.txtChiPhiTongCongUSD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiTongCongUSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiTongCongUSD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiTongCongUSD.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiTongCongUSD.FieldName = ""
        Me.txtChiPhiTongCongUSD.IsNull = True
        Me.txtChiPhiTongCongUSD.Location = New System.Drawing.Point(432, 132)
        Me.txtChiPhiTongCongUSD.MaxLength = 0
        Me.txtChiPhiTongCongUSD.Multiline = False
        Me.txtChiPhiTongCongUSD.Name = "txtChiPhiTongCongUSD"
        Me.txtChiPhiTongCongUSD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiTongCongUSD.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiTongCongUSD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiTongCongUSD.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.txtChiPhiTongCongUSD.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiTongCongUSD.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiTongCongUSD.Properties.Appearance.Options.UseForeColor = True
        Me.txtChiPhiTongCongUSD.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiTongCongUSD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiTongCongUSD.Properties.ReadOnly = True
        Me.txtChiPhiTongCongUSD.ReadOnly = True
        Me.txtChiPhiTongCongUSD.Size = New System.Drawing.Size(304, 20)
        Me.txtChiPhiTongCongUSD.TabIndex = 0
        Me.txtChiPhiTongCongUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiTongCongUSD.TextTypeMode = Commons.TypeMode.None
        '
        'txtChiPhiKhacUSD
        '
        Me.txtChiPhiKhacUSD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiKhacUSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiKhacUSD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiKhacUSD.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiKhacUSD.FieldName = ""
        Me.txtChiPhiKhacUSD.IsNull = True
        Me.txtChiPhiKhacUSD.Location = New System.Drawing.Point(432, 109)
        Me.txtChiPhiKhacUSD.MaxLength = 0
        Me.txtChiPhiKhacUSD.Multiline = False
        Me.txtChiPhiKhacUSD.Name = "txtChiPhiKhacUSD"
        Me.txtChiPhiKhacUSD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiKhacUSD.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiKhacUSD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiKhacUSD.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiKhacUSD.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiKhacUSD.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiKhacUSD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiKhacUSD.Properties.ReadOnly = True
        Me.txtChiPhiKhacUSD.ReadOnly = True
        Me.txtChiPhiKhacUSD.Size = New System.Drawing.Size(304, 20)
        Me.txtChiPhiKhacUSD.TabIndex = 24
        Me.txtChiPhiKhacUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiKhacUSD.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'txtChiPhiTongCongMacDinh
        '
        Me.txtChiPhiTongCongMacDinh.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiTongCongMacDinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiTongCongMacDinh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiTongCongMacDinh.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiTongCongMacDinh.FieldName = ""
        Me.txtChiPhiTongCongMacDinh.IsNull = True
        Me.txtChiPhiTongCongMacDinh.Location = New System.Drawing.Point(123, 132)
        Me.txtChiPhiTongCongMacDinh.MaxLength = 0
        Me.txtChiPhiTongCongMacDinh.Multiline = False
        Me.txtChiPhiTongCongMacDinh.Name = "txtChiPhiTongCongMacDinh"
        Me.txtChiPhiTongCongMacDinh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.Options.UseForeColor = True
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiTongCongMacDinh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiTongCongMacDinh.Properties.ReadOnly = True
        Me.txtChiPhiTongCongMacDinh.ReadOnly = True
        Me.txtChiPhiTongCongMacDinh.Size = New System.Drawing.Size(303, 20)
        Me.txtChiPhiTongCongMacDinh.TabIndex = 0
        Me.txtChiPhiTongCongMacDinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiTongCongMacDinh.TextTypeMode = Commons.TypeMode.None
        '
        'lblUSD
        '
        Me.lblUSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUSD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUSD.Location = New System.Drawing.Point(432, 0)
        Me.lblUSD.Name = "lblUSD"
        Me.lblUSD.Size = New System.Drawing.Size(304, 14)
        Me.lblUSD.TabIndex = 26
        Me.lblUSD.Text = "Số tiền USD"
        Me.lblUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChiPhiTongCong
        '
        Me.lblChiPhiTongCong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiPhiTongCong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiPhiTongCong.ForeColor = System.Drawing.Color.Navy
        Me.lblChiPhiTongCong.Location = New System.Drawing.Point(3, 129)
        Me.lblChiPhiTongCong.Name = "lblChiPhiTongCong"
        Me.lblChiPhiTongCong.Size = New System.Drawing.Size(114, 24)
        Me.lblChiPhiTongCong.TabIndex = 19
        Me.lblChiPhiTongCong.Text = "Tổng cộng "
        Me.lblChiPhiTongCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChiPhiKhacMacDinh
        '
        Me.txtChiPhiKhacMacDinh.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiKhacMacDinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiKhacMacDinh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiKhacMacDinh.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiKhacMacDinh.FieldName = ""
        Me.txtChiPhiKhacMacDinh.IsNull = True
        Me.txtChiPhiKhacMacDinh.Location = New System.Drawing.Point(123, 109)
        Me.txtChiPhiKhacMacDinh.MaxLength = 0
        Me.txtChiPhiKhacMacDinh.Multiline = False
        Me.txtChiPhiKhacMacDinh.Name = "txtChiPhiKhacMacDinh"
        Me.txtChiPhiKhacMacDinh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiKhacMacDinh.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiKhacMacDinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiKhacMacDinh.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiKhacMacDinh.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiKhacMacDinh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiKhacMacDinh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiKhacMacDinh.Properties.ReadOnly = True
        Me.txtChiPhiKhacMacDinh.ReadOnly = True
        Me.txtChiPhiKhacMacDinh.Size = New System.Drawing.Size(303, 20)
        Me.txtChiPhiKhacMacDinh.TabIndex = 23
        Me.txtChiPhiKhacMacDinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiKhacMacDinh.TextTypeMode = Commons.TypeMode.IsNumber
        '
        'lblTienMD
        '
        Me.lblTienMD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTienMD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTienMD.Location = New System.Drawing.Point(123, 0)
        Me.lblTienMD.Name = "lblTienMD"
        Me.lblTienMD.Size = New System.Drawing.Size(303, 14)
        Me.lblTienMD.TabIndex = 26
        Me.lblTienMD.Text = "Số tiền "
        Me.lblTienMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblKhac
        '
        Me.LblKhac.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblKhac.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKhac.ForeColor = System.Drawing.Color.Black
        Me.LblKhac.Location = New System.Drawing.Point(3, 106)
        Me.LblKhac.Name = "LblKhac"
        Me.LblKhac.Size = New System.Drawing.Size(114, 23)
        Me.LblKhac.TabIndex = 25
        Me.LblKhac.Text = "Chi phí khác"
        Me.LblKhac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChiPhiPhuTungMacDinh
        '
        Me.txtChiPhiPhuTungMacDinh.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtChiPhiPhuTungMacDinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiPhuTungMacDinh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiPhuTungMacDinh.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiPhuTungMacDinh.FieldName = ""
        Me.txtChiPhiPhuTungMacDinh.IsNull = True
        Me.txtChiPhiPhuTungMacDinh.Location = New System.Drawing.Point(123, 17)
        Me.txtChiPhiPhuTungMacDinh.MaxLength = 0
        Me.txtChiPhiPhuTungMacDinh.Multiline = False
        Me.txtChiPhiPhuTungMacDinh.Name = "txtChiPhiPhuTungMacDinh"
        Me.txtChiPhiPhuTungMacDinh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiPhuTungMacDinh.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiPhuTungMacDinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiPhuTungMacDinh.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiPhuTungMacDinh.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiPhuTungMacDinh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiPhuTungMacDinh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiPhuTungMacDinh.Properties.ReadOnly = True
        Me.txtChiPhiPhuTungMacDinh.ReadOnly = True
        Me.txtChiPhiPhuTungMacDinh.Size = New System.Drawing.Size(303, 20)
        Me.txtChiPhiPhuTungMacDinh.TabIndex = 0
        Me.txtChiPhiPhuTungMacDinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiPhuTungMacDinh.TextTypeMode = Commons.TypeMode.None
        '
        'txtChiPhiPhuTungUSD
        '
        Me.txtChiPhiPhuTungUSD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiPhuTungUSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiPhuTungUSD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiPhuTungUSD.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiPhuTungUSD.FieldName = ""
        Me.txtChiPhiPhuTungUSD.IsNull = True
        Me.txtChiPhiPhuTungUSD.Location = New System.Drawing.Point(432, 17)
        Me.txtChiPhiPhuTungUSD.MaxLength = 0
        Me.txtChiPhiPhuTungUSD.Multiline = False
        Me.txtChiPhiPhuTungUSD.Name = "txtChiPhiPhuTungUSD"
        Me.txtChiPhiPhuTungUSD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiPhuTungUSD.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiPhuTungUSD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiPhuTungUSD.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiPhuTungUSD.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiPhuTungUSD.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiPhuTungUSD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiPhuTungUSD.Properties.ReadOnly = True
        Me.txtChiPhiPhuTungUSD.ReadOnly = True
        Me.txtChiPhiPhuTungUSD.Size = New System.Drawing.Size(304, 20)
        Me.txtChiPhiPhuTungUSD.TabIndex = 0
        Me.txtChiPhiPhuTungUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiPhuTungUSD.TextTypeMode = Commons.TypeMode.None
        '
        'lblChiPhiVatTu
        '
        Me.lblChiPhiVatTu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiPhiVatTu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiPhiVatTu.ForeColor = System.Drawing.Color.Black
        Me.lblChiPhiVatTu.Location = New System.Drawing.Point(3, 41)
        Me.lblChiPhiVatTu.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.lblChiPhiVatTu.Name = "lblChiPhiVatTu"
        Me.lblChiPhiVatTu.Size = New System.Drawing.Size(114, 18)
        Me.lblChiPhiVatTu.TabIndex = 19
        Me.lblChiPhiVatTu.Text = "Vật tư khác"
        Me.lblChiPhiVatTu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChiPhiVatTuMacDinh
        '
        Me.txtChiPhiVatTuMacDinh.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiVatTuMacDinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiVatTuMacDinh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiVatTuMacDinh.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiVatTuMacDinh.FieldName = ""
        Me.txtChiPhiVatTuMacDinh.IsNull = True
        Me.txtChiPhiVatTuMacDinh.Location = New System.Drawing.Point(123, 41)
        Me.txtChiPhiVatTuMacDinh.MaxLength = 0
        Me.txtChiPhiVatTuMacDinh.Multiline = False
        Me.txtChiPhiVatTuMacDinh.Name = "txtChiPhiVatTuMacDinh"
        Me.txtChiPhiVatTuMacDinh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiVatTuMacDinh.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiVatTuMacDinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiVatTuMacDinh.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiVatTuMacDinh.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiVatTuMacDinh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiVatTuMacDinh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiVatTuMacDinh.Properties.ReadOnly = True
        Me.txtChiPhiVatTuMacDinh.ReadOnly = True
        Me.txtChiPhiVatTuMacDinh.Size = New System.Drawing.Size(303, 20)
        Me.txtChiPhiVatTuMacDinh.TabIndex = 0
        Me.txtChiPhiVatTuMacDinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiVatTuMacDinh.TextTypeMode = Commons.TypeMode.None
        '
        'txtChiPhiThueNgoaiUSD
        '
        Me.txtChiPhiThueNgoaiUSD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiThueNgoaiUSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiThueNgoaiUSD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiThueNgoaiUSD.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiThueNgoaiUSD.FieldName = ""
        Me.txtChiPhiThueNgoaiUSD.IsNull = True
        Me.txtChiPhiThueNgoaiUSD.Location = New System.Drawing.Point(432, 87)
        Me.txtChiPhiThueNgoaiUSD.MaxLength = 0
        Me.txtChiPhiThueNgoaiUSD.Multiline = False
        Me.txtChiPhiThueNgoaiUSD.Name = "txtChiPhiThueNgoaiUSD"
        Me.txtChiPhiThueNgoaiUSD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiThueNgoaiUSD.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiThueNgoaiUSD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiThueNgoaiUSD.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiThueNgoaiUSD.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiThueNgoaiUSD.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiThueNgoaiUSD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiThueNgoaiUSD.Properties.ReadOnly = True
        Me.txtChiPhiThueNgoaiUSD.ReadOnly = True
        Me.txtChiPhiThueNgoaiUSD.Size = New System.Drawing.Size(304, 20)
        Me.txtChiPhiThueNgoaiUSD.TabIndex = 0
        Me.txtChiPhiThueNgoaiUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiThueNgoaiUSD.TextTypeMode = Commons.TypeMode.None
        '
        'txtChiPhiVatTuUSD
        '
        Me.txtChiPhiVatTuUSD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiVatTuUSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiVatTuUSD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiVatTuUSD.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiVatTuUSD.FieldName = ""
        Me.txtChiPhiVatTuUSD.IsNull = True
        Me.txtChiPhiVatTuUSD.Location = New System.Drawing.Point(432, 41)
        Me.txtChiPhiVatTuUSD.MaxLength = 0
        Me.txtChiPhiVatTuUSD.Multiline = False
        Me.txtChiPhiVatTuUSD.Name = "txtChiPhiVatTuUSD"
        Me.txtChiPhiVatTuUSD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiVatTuUSD.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiVatTuUSD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiVatTuUSD.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiVatTuUSD.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiVatTuUSD.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiVatTuUSD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiVatTuUSD.Properties.ReadOnly = True
        Me.txtChiPhiVatTuUSD.ReadOnly = True
        Me.txtChiPhiVatTuUSD.Size = New System.Drawing.Size(304, 20)
        Me.txtChiPhiVatTuUSD.TabIndex = 0
        Me.txtChiPhiVatTuUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiVatTuUSD.TextTypeMode = Commons.TypeMode.None
        '
        'txtChiPhiThueNgoaiMacDinh
        '
        Me.txtChiPhiThueNgoaiMacDinh.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiThueNgoaiMacDinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiThueNgoaiMacDinh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiThueNgoaiMacDinh.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiThueNgoaiMacDinh.FieldName = ""
        Me.txtChiPhiThueNgoaiMacDinh.IsNull = True
        Me.txtChiPhiThueNgoaiMacDinh.Location = New System.Drawing.Point(123, 87)
        Me.txtChiPhiThueNgoaiMacDinh.MaxLength = 0
        Me.txtChiPhiThueNgoaiMacDinh.Multiline = False
        Me.txtChiPhiThueNgoaiMacDinh.Name = "txtChiPhiThueNgoaiMacDinh"
        Me.txtChiPhiThueNgoaiMacDinh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiThueNgoaiMacDinh.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiThueNgoaiMacDinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiThueNgoaiMacDinh.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiThueNgoaiMacDinh.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiThueNgoaiMacDinh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiThueNgoaiMacDinh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiThueNgoaiMacDinh.Properties.ReadOnly = True
        Me.txtChiPhiThueNgoaiMacDinh.ReadOnly = True
        Me.txtChiPhiThueNgoaiMacDinh.Size = New System.Drawing.Size(303, 20)
        Me.txtChiPhiThueNgoaiMacDinh.TabIndex = 0
        Me.txtChiPhiThueNgoaiMacDinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiThueNgoaiMacDinh.TextTypeMode = Commons.TypeMode.None
        '
        'txtChiPhiNhanCongUSD
        '
        Me.txtChiPhiNhanCongUSD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiNhanCongUSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiNhanCongUSD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiNhanCongUSD.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiNhanCongUSD.FieldName = ""
        Me.txtChiPhiNhanCongUSD.IsNull = True
        Me.txtChiPhiNhanCongUSD.Location = New System.Drawing.Point(432, 65)
        Me.txtChiPhiNhanCongUSD.MaxLength = 0
        Me.txtChiPhiNhanCongUSD.Multiline = False
        Me.txtChiPhiNhanCongUSD.Name = "txtChiPhiNhanCongUSD"
        Me.txtChiPhiNhanCongUSD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiNhanCongUSD.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiNhanCongUSD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiNhanCongUSD.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiNhanCongUSD.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiNhanCongUSD.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiNhanCongUSD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiNhanCongUSD.Properties.ReadOnly = True
        Me.txtChiPhiNhanCongUSD.ReadOnly = True
        Me.txtChiPhiNhanCongUSD.Size = New System.Drawing.Size(304, 20)
        Me.txtChiPhiNhanCongUSD.TabIndex = 0
        Me.txtChiPhiNhanCongUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiNhanCongUSD.TextTypeMode = Commons.TypeMode.None
        '
        'lblChiPhiThueNgoai
        '
        Me.lblChiPhiThueNgoai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiPhiThueNgoai.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiPhiThueNgoai.ForeColor = System.Drawing.Color.Black
        Me.lblChiPhiThueNgoai.Location = New System.Drawing.Point(3, 84)
        Me.lblChiPhiThueNgoai.Name = "lblChiPhiThueNgoai"
        Me.lblChiPhiThueNgoai.Size = New System.Drawing.Size(114, 22)
        Me.lblChiPhiThueNgoai.TabIndex = 19
        Me.lblChiPhiThueNgoai.Text = "Dịch vụ "
        Me.lblChiPhiThueNgoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChiPhiNhanCong
        '
        Me.lblChiPhiNhanCong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChiPhiNhanCong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiPhiNhanCong.ForeColor = System.Drawing.Color.Black
        Me.lblChiPhiNhanCong.Location = New System.Drawing.Point(3, 62)
        Me.lblChiPhiNhanCong.Name = "lblChiPhiNhanCong"
        Me.lblChiPhiNhanCong.Size = New System.Drawing.Size(114, 22)
        Me.lblChiPhiNhanCong.TabIndex = 19
        Me.lblChiPhiNhanCong.Text = "Nhân công "
        Me.lblChiPhiNhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChiPhiNhanCongMacDinh
        '
        Me.txtChiPhiNhanCongMacDinh.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtChiPhiNhanCongMacDinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtChiPhiNhanCongMacDinh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtChiPhiNhanCongMacDinh.ErrorProviderControl = Me.ErrorProvider1
        Me.txtChiPhiNhanCongMacDinh.FieldName = ""
        Me.txtChiPhiNhanCongMacDinh.IsNull = True
        Me.txtChiPhiNhanCongMacDinh.Location = New System.Drawing.Point(123, 65)
        Me.txtChiPhiNhanCongMacDinh.MaxLength = 0
        Me.txtChiPhiNhanCongMacDinh.Multiline = False
        Me.txtChiPhiNhanCongMacDinh.Name = "txtChiPhiNhanCongMacDinh"
        Me.txtChiPhiNhanCongMacDinh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChiPhiNhanCongMacDinh.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.txtChiPhiNhanCongMacDinh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChiPhiNhanCongMacDinh.Properties.Appearance.Options.UseBackColor = True
        Me.txtChiPhiNhanCongMacDinh.Properties.Appearance.Options.UseFont = True
        Me.txtChiPhiNhanCongMacDinh.Properties.Appearance.Options.UseTextOptions = True
        Me.txtChiPhiNhanCongMacDinh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtChiPhiNhanCongMacDinh.Properties.ReadOnly = True
        Me.txtChiPhiNhanCongMacDinh.ReadOnly = True
        Me.txtChiPhiNhanCongMacDinh.Size = New System.Drawing.Size(303, 20)
        Me.txtChiPhiNhanCongMacDinh.TabIndex = 0
        Me.txtChiPhiNhanCongMacDinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtChiPhiNhanCongMacDinh.TextTypeMode = Commons.TypeMode.None
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnHThanhNT)
        Me.Panel2.Controls.Add(Me.BtnXacnhanNT)
        Me.Panel2.Controls.Add(Me.btnIn_giaonhan)
        Me.Panel2.Controls.Add(Me.BT_CHECK_DL_KHO)
        Me.Panel2.Controls.Add(Me.btnCapNhatTuDong)
        Me.Panel2.Controls.Add(Me.btnXoaPBTK)
        Me.Panel2.Controls.Add(Me.btnThoat5)
        Me.Panel2.Controls.Add(Me.btnTroVe5)
        Me.Panel2.Controls.Add(Me.btnKhongGhi5)
        Me.Panel2.Controls.Add(Me.btnXoaPTTT)
        Me.Panel2.Controls.Add(Me.btnGhi5)
        Me.Panel2.Controls.Add(Me.btnAllocate)
        Me.Panel2.Controls.Add(Me.btnPhanBoLai)
        Me.Panel2.Controls.Add(Me.btnSua5)
        Me.Panel2.Controls.Add(Me.btnXoa5)
        Me.Panel2.Controls.Add(Me.btnXoaTTNT)
        Me.Panel2.Controls.Add(Me.BtnLockPBT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 510)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1264, 32)
        Me.Panel2.TabIndex = 53
        '
        'btnHThanhNT
        '
        Me.btnHThanhNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHThanhNT.Location = New System.Drawing.Point(739, 1)
        Me.btnHThanhNT.Name = "btnHThanhNT"
        Me.btnHThanhNT.Size = New System.Drawing.Size(104, 30)
        Me.btnHThanhNT.TabIndex = 58
        Me.btnHThanhNT.Text = "btnHThanhNT"
        '
        'BtnXacnhanNT
        '
        Me.BtnXacnhanNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXacnhanNT.Location = New System.Drawing.Point(634, 1)
        Me.BtnXacnhanNT.Name = "BtnXacnhanNT"
        Me.BtnXacnhanNT.Size = New System.Drawing.Size(104, 30)
        Me.BtnXacnhanNT.TabIndex = 43
        Me.BtnXacnhanNT.Text = "Xác nhận NT"
        '
        'BT_CHECK_DL_KHO
        '
        Me.BT_CHECK_DL_KHO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BT_CHECK_DL_KHO.Location = New System.Drawing.Point(3, 1)
        Me.BT_CHECK_DL_KHO.Name = "BT_CHECK_DL_KHO"
        Me.BT_CHECK_DL_KHO.Size = New System.Drawing.Size(101, 30)
        Me.BT_CHECK_DL_KHO.TabIndex = 54
        Me.BT_CHECK_DL_KHO.Text = "Kiểm tra SL xuất"
        '
        'btnCapNhatTuDong
        '
        Me.btnCapNhatTuDong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCapNhatTuDong.Location = New System.Drawing.Point(424, 1)
        Me.btnCapNhatTuDong.Name = "btnCapNhatTuDong"
        Me.btnCapNhatTuDong.Size = New System.Drawing.Size(104, 30)
        Me.btnCapNhatTuDong.TabIndex = 47
        Me.btnCapNhatTuDong.Text = "btnCapNhatTuDong"
        Me.btnCapNhatTuDong.Visible = False
        '
        'btnXoaPBTK
        '
        Me.btnXoaPBTK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaPBTK.Location = New System.Drawing.Point(530, 1)
        Me.btnXoaPBTK.Name = "btnXoaPBTK"
        Me.btnXoaPBTK.Size = New System.Drawing.Size(104, 30)
        Me.btnXoaPBTK.TabIndex = 47
        Me.btnXoaPBTK.Text = "btnXoaPBTK"
        '
        'btnThoat5
        '
        Me.btnThoat5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat5.Location = New System.Drawing.Point(1160, 1)
        Me.btnThoat5.Name = "btnThoat5"
        Me.btnThoat5.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat5.TabIndex = 42
        Me.btnThoat5.Text = "T&hoát"
        '
        'btnTroVe5
        '
        Me.btnTroVe5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroVe5.Location = New System.Drawing.Point(1160, 1)
        Me.btnTroVe5.Name = "btnTroVe5"
        Me.btnTroVe5.Size = New System.Drawing.Size(104, 30)
        Me.btnTroVe5.TabIndex = 42
        Me.btnTroVe5.Text = "Trở về "
        Me.btnTroVe5.Visible = False
        '
        'btnKhongGhi5
        '
        Me.btnKhongGhi5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhi5.Location = New System.Drawing.Point(1160, 1)
        Me.btnKhongGhi5.Name = "btnKhongGhi5"
        Me.btnKhongGhi5.Size = New System.Drawing.Size(104, 30)
        Me.btnKhongGhi5.TabIndex = 39
        Me.btnKhongGhi5.Text = "&Không ghi "
        Me.btnKhongGhi5.Visible = False
        '
        'btnXoaPTTT
        '
        Me.btnXoaPTTT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaPTTT.Location = New System.Drawing.Point(950, 1)
        Me.btnXoaPTTT.Name = "btnXoaPTTT"
        Me.btnXoaPTTT.Size = New System.Drawing.Size(104, 30)
        Me.btnXoaPTTT.TabIndex = 43
        Me.btnXoaPTTT.Text = "Xoá PTTT"
        Me.btnXoaPTTT.Visible = False
        '
        'btnGhi5
        '
        Me.btnGhi5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhi5.Location = New System.Drawing.Point(1055, 1)
        Me.btnGhi5.Name = "btnGhi5"
        Me.btnGhi5.Size = New System.Drawing.Size(104, 30)
        Me.btnGhi5.TabIndex = 38
        Me.btnGhi5.Text = "&Ghi "
        Me.btnGhi5.Visible = False
        '
        'btnAllocate
        '
        Me.btnAllocate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAllocate.Location = New System.Drawing.Point(105, 1)
        Me.btnAllocate.Name = "btnAllocate"
        Me.btnAllocate.Size = New System.Drawing.Size(104, 30)
        Me.btnAllocate.TabIndex = 59
        Me.btnAllocate.Text = "btnAllocate"
        Me.btnAllocate.Visible = False
        '
        'btnPhanBoLai
        '
        Me.btnPhanBoLai.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPhanBoLai.Location = New System.Drawing.Point(105, 1)
        Me.btnPhanBoLai.Name = "btnPhanBoLai"
        Me.btnPhanBoLai.Size = New System.Drawing.Size(104, 30)
        Me.btnPhanBoLai.TabIndex = 61
        Me.btnPhanBoLai.Text = "btnPhanBoLai"
        Me.btnPhanBoLai.Visible = False
        '
        'btnSua5
        '
        Me.btnSua5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSua5.Location = New System.Drawing.Point(950, 1)
        Me.btnSua5.Name = "btnSua5"
        Me.btnSua5.Size = New System.Drawing.Size(104, 30)
        Me.btnSua5.TabIndex = 41
        Me.btnSua5.Text = "Sửa"
        '
        'btnXoa5
        '
        Me.btnXoa5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoa5.Location = New System.Drawing.Point(1055, 1)
        Me.btnXoa5.Name = "btnXoa5"
        Me.btnXoa5.Size = New System.Drawing.Size(104, 30)
        Me.btnXoa5.TabIndex = 47
        Me.btnXoa5.Text = "&Xoá "
        '
        'btnXoaTTNT
        '
        Me.btnXoaTTNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaTTNT.Location = New System.Drawing.Point(1055, 1)
        Me.btnXoaTTNT.Name = "btnXoaTTNT"
        Me.btnXoaTTNT.Size = New System.Drawing.Size(104, 30)
        Me.btnXoaTTNT.TabIndex = 40
        Me.btnXoaTTNT.Text = "Xóa TTNT"
        Me.btnXoaTTNT.Visible = False
        '
        'BtnLockPBT
        '
        Me.BtnLockPBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLockPBT.Location = New System.Drawing.Point(844, 1)
        Me.BtnLockPBT.Name = "BtnLockPBT"
        Me.BtnLockPBT.Size = New System.Drawing.Size(104, 30)
        Me.BtnLockPBT.TabIndex = 44
        Me.BtnLockPBT.Text = "Lock PBT"
        '
        'lblTingTrangSauBaoTri_6
        '
        Me.lblTingTrangSauBaoTri_6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTingTrangSauBaoTri_6.AutoSize = True
        Me.lblTingTrangSauBaoTri_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTingTrangSauBaoTri_6.ForeColor = System.Drawing.Color.Black
        Me.lblTingTrangSauBaoTri_6.Location = New System.Drawing.Point(864, 248)
        Me.lblTingTrangSauBaoTri_6.Name = "lblTingTrangSauBaoTri_6"
        Me.lblTingTrangSauBaoTri_6.Size = New System.Drawing.Size(133, 13)
        Me.lblTingTrangSauBaoTri_6.TabIndex = 39
        Me.lblTingTrangSauBaoTri_6.Text = "Tình trạng sau bảo trì "
        Me.lblTingTrangSauBaoTri_6.Visible = False
        '
        'mbtnKHT_GET_Nam
        '
        Me.mbtnKHT_GET_Nam.Caption = "Chuyển từ kế hoạch năm"
        Me.mbtnKHT_GET_Nam.Id = 3
        Me.mbtnKHT_GET_Nam.Name = "mbtnKHT_GET_Nam"
        '
        'mbtnKHT_GET_BTDK
        '
        Me.mbtnKHT_GET_BTDK.Caption = "Chuyển từ bảo trì định kỳ"
        Me.mbtnKHT_GET_BTDK.Id = 4
        Me.mbtnKHT_GET_BTDK.Name = "mbtnKHT_GET_BTDK"
        '
        'mbtnKHT_GET_Thang
        '
        Me.mbtnKHT_GET_Thang.Caption = "Chuyển từ tháng khác"
        Me.mbtnKHT_GET_Thang.Id = 5
        Me.mbtnKHT_GET_Thang.Name = "mbtnKHT_GET_Thang"
        '
        'mbtnKHT_GET_CV
        '
        Me.mbtnKHT_GET_CV.Caption = "Chuyển công việc"
        Me.mbtnKHT_GET_CV.Id = 8
        Me.mbtnKHT_GET_CV.Name = "mbtnKHT_GET_CV"
        '
        'mbtnKHN_GET_BTDK
        '
        Me.mbtnKHN_GET_BTDK.Caption = "Chuyển từ BTDK"
        Me.mbtnKHN_GET_BTDK.Id = 9
        Me.mbtnKHN_GET_BTDK.Name = "mbtnKHN_GET_BTDK"
        '
        'mbtnKHN_GET_Nam
        '
        Me.mbtnKHN_GET_Nam.Caption = "Chuyển từ năm khác"
        Me.mbtnKHN_GET_Nam.Id = 10
        Me.mbtnKHN_GET_Nam.Name = "mbtnKHN_GET_Nam"
        '
        'mnuOpt1
        '
        Me.mnuOpt1.Caption = "In 1"
        Me.mnuOpt1.Id = 14
        Me.mnuOpt1.Name = "mnuOpt1"
        '
        'mnuOpt2
        '
        Me.mnuOpt2.Caption = "In 2"
        Me.mnuOpt2.Id = 15
        Me.mnuOpt2.Name = "mnuOpt2"
        '
        'mnuOpt3
        '
        Me.mnuOpt3.Caption = "In 3"
        Me.mnuOpt3.Id = 16
        Me.mnuOpt3.Name = "mnuOpt3"
        '
        'mbtnKHT_GET_CV_TU_NAM
        '
        Me.mbtnKHT_GET_CV_TU_NAM.Caption = "Chuyển công việc từ KH năm"
        Me.mbtnKHT_GET_CV_TU_NAM.Id = 17
        Me.mbtnKHT_GET_CV_TU_NAM.Name = "mbtnKHT_GET_CV_TU_NAM"
        '
        'tabCongViecNoiBo
        '
        Me.tabCongViecNoiBo.Controls.Add(Me.TableLayoutPanel13)
        Me.tabCongViecNoiBo.Name = "tabCongViecNoiBo"
        Me.tabCongViecNoiBo.Size = New System.Drawing.Size(1270, 545)
        Me.tabCongViecNoiBo.Text = "Công việc nội bộ "
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.ColumnCount = 1
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.tabCViec, 0, 1)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 2
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(1270, 545)
        Me.TableLayoutPanel13.TabIndex = 45
        '
        'tabCViec
        '
        Me.tabCViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCViec.Location = New System.Drawing.Point(3, 9)
        Me.tabCViec.Name = "tabCViec"
        Me.tabCViec.SelectedTabPage = Me.tabCVChinh
        Me.tabCViec.Size = New System.Drawing.Size(1264, 533)
        Me.tabCViec.TabIndex = 44
        Me.tabCViec.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabCVChinh, Me.tabCVPhu})
        '
        'tabCVChinh
        '
        Me.tabCVChinh.Controls.Add(Me.ucCongViecPBT)
        Me.tabCVChinh.Name = "tabCVChinh"
        Me.tabCVChinh.Size = New System.Drawing.Size(1257, 505)
        Me.tabCVChinh.Text = "tabCVChinh"
        '
        'ucCongViecPBT
        '
        Me.ucCongViecPBT._SynConnectionInfo = Nothing
        Me.ucCongViecPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucCongViecPBT.iTTPBTri = 0
        Me.ucCongViecPBT.Location = New System.Drawing.Point(0, 0)
        Me.ucCongViecPBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ucCongViecPBT.Name = "ucCongViecPBT"
        Me.ucCongViecPBT.ngayBDKH = New Date(CType(0, Long))
        Me.ucCongViecPBT.Size = New System.Drawing.Size(1257, 505)
        Me.ucCongViecPBT.sMsMay = Nothing
        Me.ucCongViecPBT.sMsPBT = Nothing
        Me.ucCongViecPBT.TabIndex = 0
        '
        'tabCVPhu
        '
        Me.tabCVPhu.Controls.Add(Me.ucCVPTro)
        Me.tabCVPhu.Name = "tabCVPhu"
        Me.tabCVPhu.Size = New System.Drawing.Size(1260, 509)
        Me.tabCVPhu.Text = "tabCVPhu"
        '
        'ucCVPTro
        '
        Me.ucCVPTro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucCVPTro.iTTPBTri = 0
        Me.ucCVPTro.Location = New System.Drawing.Point(0, 0)
        Me.ucCVPTro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ucCVPTro.Name = "ucCVPTro"
        Me.ucCVPTro.Size = New System.Drawing.Size(1260, 509)
        Me.ucCVPTro.sMsPBT = Nothing
        Me.ucCVPTro.TabIndex = 0
        '
        'ucCongViecNS
        '
        Me.ucCongViecNS.bLoadNS = False
        Me.ucCongViecNS.denNgayGioHong = New Date(CType(0, Long))
        Me.ucCongViecNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucCongViecNS.iTTPBTri = 0
        Me.ucCongViecNS.Location = New System.Drawing.Point(0, 0)
        Me.ucCongViecNS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucCongViecNS.Name = "ucCongViecNS"
        Me.ucCongViecNS.ngayBDKH = New Date(CType(0, Long))
        Me.ucCongViecNS.ngayKTKH = New Date(CType(0, Long))
        Me.ucCongViecNS.Size = New System.Drawing.Size(1270, 545)
        Me.ucCongViecNS.sMsMay = Nothing
        Me.ucCongViecNS.sMsPBT = Nothing
        Me.ucCongViecNS.TabIndex = 0
        Me.ucCongViecNS.tuNgayGioHong = New Date(CType(0, Long))
        '
        'menuThemViTri
        '
        Me.menuThemViTri.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.menuThemViTri.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnThemViTri})
        Me.menuThemViTri.Name = "menuThemViTri"
        Me.menuThemViTri.Size = New System.Drawing.Size(131, 26)
        '
        'mnThemViTri
        '
        Me.mnThemViTri.Name = "mnThemViTri"
        Me.mnThemViTri.Size = New System.Drawing.Size(130, 22)
        Me.mnThemViTri.Text = "Thêm vị trí"
        '
        'ucDichVu
        '
        Me.ucDichVu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucDichVu.iTTPBTri = 0
        Me.ucDichVu.Location = New System.Drawing.Point(0, 0)
        Me.ucDichVu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ucDichVu.Name = "ucDichVu"
        Me.ucDichVu.Size = New System.Drawing.Size(1270, 545)
        Me.ucDichVu.sMsMay = Nothing
        Me.ucDichVu.sMsPBT = Nothing
        Me.ucDichVu.TabIndex = 0
        '
        'cboMAY
        '
        Me.cboMAY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboMAY.Location = New System.Drawing.Point(484, 3)
        Me.cboMAY.Name = "cboMAY"
        Me.cboMAY.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboMAY.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMAY.Properties.DropDownRows = 3
        Me.cboMAY.Properties.NullText = ""
        Me.cboMAY.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.cboMAY.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboMAY.Size = New System.Drawing.Size(122, 20)
        Me.cboMAY.TabIndex = 39
        '
        'tabDanhSachPhieuBaoTri
        '
        Me.tabDanhSachPhieuBaoTri.Controls.Add(Me.TableLayoutPanel8)
        Me.tabDanhSachPhieuBaoTri.Controls.Add(Me.grpChonXem_1)
        Me.tabDanhSachPhieuBaoTri.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDanhSachPhieuBaoTri.Name = "tabDanhSachPhieuBaoTri"
        Me.tabDanhSachPhieuBaoTri.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.tabDanhSachPhieuBaoTri.Size = New System.Drawing.Size(1270, 544)
        Me.tabDanhSachPhieuBaoTri.Text = "Danh sách phiếu bảo trì "
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.grdDanhSach_1, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.Panel7, 0, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel9, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 3
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(1264, 538)
        Me.TableLayoutPanel8.TabIndex = 26
        '
        'grdDanhSach_1
        '
        Me.TableLayoutPanel8.SetColumnSpan(Me.grdDanhSach_1, 2)
        Me.grdDanhSach_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhSach_1.Location = New System.Drawing.Point(3, 39)
        Me.grdDanhSach_1.LookAndFeel.SkinName = "Blue"
        Me.grdDanhSach_1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdDanhSach_1.MainView = Me.grvDanhSach_1
        Me.grdDanhSach_1.Name = "grdDanhSach_1"
        Me.grdDanhSach_1.Size = New System.Drawing.Size(1258, 460)
        Me.grdDanhSach_1.TabIndex = 25
        Me.grdDanhSach_1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDanhSach_1, Me.GridView7})
        '
        'grvDanhSach_1
        '
        Me.grvDanhSach_1.GridControl = Me.grdDanhSach_1
        Me.grvDanhSach_1.Name = "grvDanhSach_1"
        Me.grvDanhSach_1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvDanhSach_1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvDanhSach_1.OptionsBehavior.Editable = False
        Me.grvDanhSach_1.OptionsLayout.Columns.AddNewColumns = False
        Me.grvDanhSach_1.OptionsLayout.Columns.RemoveOldColumns = False
        Me.grvDanhSach_1.OptionsView.ColumnAutoWidth = False
        Me.grvDanhSach_1.OptionsView.ShowGroupPanel = False
        '
        'GridView7
        '
        Me.GridView7.GridControl = Me.grdDanhSach_1
        Me.GridView7.Name = "GridView7"
        '
        'Panel7
        '
        Me.TableLayoutPanel8.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.btnNHHTNTL)
        Me.Panel7.Controls.Add(Me.btnBanGiao)
        Me.Panel7.Controls.Add(Me.BtnXemtailieu)
        Me.Panel7.Controls.Add(Me.btnPrint)
        Me.Panel7.Controls.Add(Me.BtnChonTaiLieu)
        Me.Panel7.Controls.Add(Me.btnMucUuTien)
        Me.Panel7.Controls.Add(Me.btnUnLock)
        Me.Panel7.Controls.Add(Me.lblTimKiemTheoMaPBT_1)
        Me.Panel7.Controls.Add(Me.btnAuto)
        Me.Panel7.Controls.Add(Me.btnThoat_1)
        Me.Panel7.Controls.Add(Me.btnKhongGhi_1)
        Me.Panel7.Controls.Add(Me.btnThem_1)
        Me.Panel7.Controls.Add(Me.btnXoa_1)
        Me.Panel7.Controls.Add(Me.btnSua_1)
        Me.Panel7.Controls.Add(Me.btnIn_1)
        Me.Panel7.Controls.Add(Me.btnInPBT)
        Me.Panel7.Controls.Add(Me.BtnKhoaPBT)
        Me.Panel7.Controls.Add(Me.btnTGNgungMay)
        Me.Panel7.Controls.Add(Me.BtnDuyetPBT)
        Me.Panel7.Controls.Add(Me.btnGhi_1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 505)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1258, 30)
        Me.Panel7.TabIndex = 23
        '
        'btnNHHTNTL
        '
        Me.btnNHHTNTL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNHHTNTL.Location = New System.Drawing.Point(420, 0)
        Me.btnNHHTNTL.Name = "btnNHHTNTL"
        Me.btnNHHTNTL.Size = New System.Drawing.Size(104, 30)
        Me.btnNHHTNTL.TabIndex = 32
        Me.btnNHHTNTL.Text = "btnNHHTNTL"
        '
        'btnBanGiao
        '
        Me.btnBanGiao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBanGiao.Location = New System.Drawing.Point(525, 0)
        Me.btnBanGiao.Name = "btnBanGiao"
        Me.btnBanGiao.Size = New System.Drawing.Size(104, 30)
        Me.btnBanGiao.TabIndex = 19
        Me.btnBanGiao.Text = "Bàn giao TB"
        '
        'BtnXemtailieu
        '
        Me.BtnXemtailieu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXemtailieu.Location = New System.Drawing.Point(629, 0)
        Me.BtnXemtailieu.Name = "BtnXemtailieu"
        Me.BtnXemtailieu.Size = New System.Drawing.Size(104, 30)
        Me.BtnXemtailieu.TabIndex = 19
        Me.BtnXemtailieu.Text = "Mở tài liệu"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(525, 0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 30)
        Me.btnPrint.TabIndex = 30
        Me.btnPrint.Text = "In"
        '
        'BtnChonTaiLieu
        '
        Me.BtnChonTaiLieu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChonTaiLieu.Location = New System.Drawing.Point(945, 0)
        Me.BtnChonTaiLieu.Name = "BtnChonTaiLieu"
        Me.BtnChonTaiLieu.Size = New System.Drawing.Size(104, 30)
        Me.BtnChonTaiLieu.TabIndex = 19
        Me.BtnChonTaiLieu.Text = "Chọn tài liệu "
        Me.BtnChonTaiLieu.Visible = False
        '
        'btnMucUuTien
        '
        Me.btnMucUuTien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMucUuTien.Location = New System.Drawing.Point(945, 0)
        Me.btnMucUuTien.Name = "btnMucUuTien"
        Me.btnMucUuTien.Size = New System.Drawing.Size(104, 30)
        Me.btnMucUuTien.TabIndex = 35
        Me.btnMucUuTien.Text = "Calc. imp. time"
        Me.btnMucUuTien.Visible = False
        '
        'btnUnLock
        '
        Me.btnUnLock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUnLock.Location = New System.Drawing.Point(0, 0)
        Me.btnUnLock.Name = "btnUnLock"
        Me.btnUnLock.Size = New System.Drawing.Size(104, 30)
        Me.btnUnLock.TabIndex = 33
        Me.btnUnLock.Text = "btnUnLock"
        Me.btnUnLock.Visible = False
        '
        'lblTimKiemTheoMaPBT_1
        '
        Me.lblTimKiemTheoMaPBT_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimKiemTheoMaPBT_1.ForeColor = System.Drawing.Color.Maroon
        Me.lblTimKiemTheoMaPBT_1.Location = New System.Drawing.Point(0, 1)
        Me.lblTimKiemTheoMaPBT_1.Name = "lblTimKiemTheoMaPBT_1"
        Me.lblTimKiemTheoMaPBT_1.Size = New System.Drawing.Size(62, 30)
        Me.lblTimKiemTheoMaPBT_1.TabIndex = 27
        Me.lblTimKiemTheoMaPBT_1.Text = "Tìm kiếm PBT"
        Me.lblTimKiemTheoMaPBT_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTimKiemTheoMaPBT_1.Visible = False
        '
        'btnAuto
        '
        Me.btnAuto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAuto.Location = New System.Drawing.Point(420, 0)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.Size = New System.Drawing.Size(104, 30)
        Me.btnAuto.TabIndex = 29
        Me.btnAuto.Text = "Lập PBT Tự động"
        '
        'btnThoat_1
        '
        Me.btnThoat_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoat_1.Image = CType(resources.GetObject("btnThoat_1.Image"), System.Drawing.Image)
        Me.btnThoat_1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnThoat_1.Location = New System.Drawing.Point(1154, 0)
        Me.btnThoat_1.Name = "btnThoat_1"
        Me.btnThoat_1.Size = New System.Drawing.Size(104, 30)
        Me.btnThoat_1.TabIndex = 21
        Me.btnThoat_1.Text = "T&hoát"
        '
        'btnKhongGhi_1
        '
        Me.btnKhongGhi_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhi_1.Location = New System.Drawing.Point(1154, 0)
        Me.btnKhongGhi_1.Name = "btnKhongGhi_1"
        Me.btnKhongGhi_1.Size = New System.Drawing.Size(104, 30)
        Me.btnKhongGhi_1.TabIndex = 20
        Me.btnKhongGhi_1.Text = "&Không ghi"
        '
        'btnThem_1
        '
        Me.btnThem_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThem_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnThem_1.Location = New System.Drawing.Point(734, 0)
        Me.btnThem_1.Name = "btnThem_1"
        Me.btnThem_1.Size = New System.Drawing.Size(104, 30)
        Me.btnThem_1.TabIndex = 19
        Me.btnThem_1.Text = "&Thêm "
        '
        'btnXoa_1
        '
        Me.btnXoa_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoa_1.Location = New System.Drawing.Point(945, 0)
        Me.btnXoa_1.Name = "btnXoa_1"
        Me.btnXoa_1.Size = New System.Drawing.Size(104, 30)
        Me.btnXoa_1.TabIndex = 19
        Me.btnXoa_1.Text = "&Xoá "
        '
        'btnSua_1
        '
        Me.btnSua_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSua_1.Location = New System.Drawing.Point(839, 0)
        Me.btnSua_1.Name = "btnSua_1"
        Me.btnSua_1.Size = New System.Drawing.Size(104, 30)
        Me.btnSua_1.TabIndex = 19
        Me.btnSua_1.Text = "&Sửa"
        '
        'btnIn_1
        '
        Me.btnIn_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIn_1.Location = New System.Drawing.Point(1049, 0)
        Me.btnIn_1.Name = "btnIn_1"
        Me.btnIn_1.Size = New System.Drawing.Size(104, 30)
        Me.btnIn_1.TabIndex = 19
        Me.btnIn_1.Text = "&In"
        '
        'btnInPBT
        '
        Me.btnInPBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInPBT.Location = New System.Drawing.Point(315, 0)
        Me.btnInPBT.Name = "btnInPBT"
        Me.btnInPBT.Size = New System.Drawing.Size(104, 30)
        Me.btnInPBT.TabIndex = 31
        Me.btnInPBT.Text = "btnInPBT"
        '
        'BtnKhoaPBT
        '
        Me.BtnKhoaPBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnKhoaPBT.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.BtnKhoaPBT.Location = New System.Drawing.Point(0, 0)
        Me.BtnKhoaPBT.Name = "BtnKhoaPBT"
        Me.BtnKhoaPBT.Size = New System.Drawing.Size(104, 30)
        Me.BtnKhoaPBT.TabIndex = 19
        Me.BtnKhoaPBT.Text = "Khóa  PBT"
        '
        'btnTGNgungMay
        '
        Me.btnTGNgungMay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTGNgungMay.Location = New System.Drawing.Point(210, 0)
        Me.btnTGNgungMay.Name = "btnTGNgungMay"
        Me.btnTGNgungMay.Size = New System.Drawing.Size(104, 30)
        Me.btnTGNgungMay.TabIndex = 26
        Me.btnTGNgungMay.Text = "TG Ngừng máy"
        '
        'BtnDuyetPBT
        '
        Me.BtnDuyetPBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDuyetPBT.Location = New System.Drawing.Point(105, 0)
        Me.BtnDuyetPBT.Name = "BtnDuyetPBT"
        Me.BtnDuyetPBT.Size = New System.Drawing.Size(104, 30)
        Me.BtnDuyetPBT.TabIndex = 19
        Me.BtnDuyetPBT.Text = "Duyệt  PBT"
        '
        'btnGhi_1
        '
        Me.btnGhi_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhi_1.Location = New System.Drawing.Point(1049, 0)
        Me.btnGhi_1.Name = "btnGhi_1"
        Me.btnGhi_1.Size = New System.Drawing.Size(104, 30)
        Me.btnGhi_1.TabIndex = 19
        Me.btnGhi_1.Text = "&Ghi "
        Me.btnGhi_1.Visible = False
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 8
        Me.TableLayoutPanel8.SetColumnSpan(Me.TableLayoutPanel9, 2)
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.22892!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.078313!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.47892!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.93072!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.174699!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.32162!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.376964!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.207831!))
        Me.TableLayoutPanel9.Controls.Add(Me.optNTHT, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.lblDenngay_1, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.lblTimKiem, 4, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btnLocPBT, 7, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.dtDNgay_1, 3, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.dtTNgay_1, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.txtTimKiemPBT, 5, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(1258, 30)
        Me.TableLayoutPanel9.TabIndex = 24
        '
        'optNTHT
        '
        Me.optNTHT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.optNTHT.EditValue = "optChuaNT"
        Me.optNTHT.Location = New System.Drawing.Point(3, 3)
        Me.optNTHT.Name = "optNTHT"
        Me.optNTHT.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.optNTHT.Properties.Appearance.Options.UseBackColor = True
        Me.optNTHT.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("optChuaNT", "optChuaNT"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optHoanThanh", "optHoanThanh"), New DevExpress.XtraEditors.Controls.RadioGroupItem("optLock", "optLock")})
        Me.optNTHT.Size = New System.Drawing.Size(400, 24)
        Me.optNTHT.TabIndex = 22
        '
        'lblDenngay_1
        '
        Me.lblDenngay_1.AutoSize = True
        Me.lblDenngay_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDenngay_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDenngay_1.ForeColor = System.Drawing.Color.Black
        Me.lblDenngay_1.Location = New System.Drawing.Point(409, 0)
        Me.lblDenngay_1.Name = "lblDenngay_1"
        Me.lblDenngay_1.Size = New System.Drawing.Size(83, 30)
        Me.lblDenngay_1.TabIndex = 13
        Me.lblDenngay_1.Text = "Đến ngày"
        Me.lblDenngay_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTimKiem
        '
        Me.lblTimKiem.AutoSize = True
        Me.lblTimKiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTimKiem.Location = New System.Drawing.Point(842, 0)
        Me.lblTimKiem.Name = "lblTimKiem"
        Me.lblTimKiem.Size = New System.Drawing.Size(71, 30)
        Me.lblTimKiem.TabIndex = 31
        Me.lblTimKiem.Text = "Tìm kiếm"
        Me.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLocPBT
        '
        Me.btnLocPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLocPBT.Location = New System.Drawing.Point(1154, 3)
        Me.btnLocPBT.Name = "btnLocPBT"
        Me.btnLocPBT.Size = New System.Drawing.Size(101, 24)
        Me.btnLocPBT.TabIndex = 31
        Me.btnLocPBT.Text = "btnLocPBT"
        '
        'dtDNgay_1
        '
        Me.dtDNgay_1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtDNgay_1.EditValue = Nothing
        Me.dtDNgay_1.Location = New System.Drawing.Point(667, 7)
        Me.dtDNgay_1.Name = "dtDNgay_1"
        Me.dtDNgay_1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDNgay_1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtDNgay_1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDNgay_1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtDNgay_1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDNgay_1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtDNgay_1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtDNgay_1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtDNgay_1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtDNgay_1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDNgay_1.Size = New System.Drawing.Size(169, 20)
        Me.dtDNgay_1.TabIndex = 38
        '
        'dtTNgay_1
        '
        Me.dtTNgay_1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtTNgay_1.EditValue = Nothing
        Me.dtTNgay_1.Location = New System.Drawing.Point(498, 7)
        Me.dtTNgay_1.Name = "dtTNgay_1"
        Me.dtTNgay_1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTNgay_1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtTNgay_1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtTNgay_1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtTNgay_1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtTNgay_1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtTNgay_1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtTNgay_1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtTNgay_1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtTNgay_1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtTNgay_1.Size = New System.Drawing.Size(163, 20)
        Me.dtTNgay_1.TabIndex = 39
        '
        'txtTimKiemPBT
        '
        Me.TableLayoutPanel9.SetColumnSpan(Me.txtTimKiemPBT, 2)
        Me.txtTimKiemPBT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTimKiemPBT.Location = New System.Drawing.Point(919, 7)
        Me.txtTimKiemPBT.Name = "txtTimKiemPBT"
        Me.txtTimKiemPBT.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtTimKiemPBT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtTimKiemPBT.Size = New System.Drawing.Size(229, 20)
        Me.txtTimKiemPBT.TabIndex = 73
        '
        'grpChonXem_1
        '
        Me.grpChonXem_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpChonXem_1.ForeColor = System.Drawing.Color.Maroon
        Me.grpChonXem_1.Location = New System.Drawing.Point(17, 6)
        Me.grpChonXem_1.Name = "grpChonXem_1"
        Me.grpChonXem_1.Size = New System.Drawing.Size(204, 65)
        Me.grpChonXem_1.TabIndex = 0
        Me.grpChonXem_1.TabStop = False
        Me.grpChonXem_1.Text = "Chọn xem "
        '
        'menuTinhTrangPBTCT
        '
        Me.menuTinhTrangPBTCT.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.menuTinhTrangPBTCT.Name = "menuTinhTrangPBTCT"
        Me.menuTinhTrangPBTCT.Size = New System.Drawing.Size(61, 4)
        '
        'TabPhieuBaoTri
        '
        Me.TabPhieuBaoTri.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPhieuBaoTri.Appearance.Options.UseBackColor = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabPhieuBaoTri, 3)
        Me.TabPhieuBaoTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPhieuBaoTri.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPhieuBaoTri.Location = New System.Drawing.Point(3, 143)
        Me.TabPhieuBaoTri.LookAndFeel.SkinName = "Blue"
        Me.TabPhieuBaoTri.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TabPhieuBaoTri.Name = "TabPhieuBaoTri"
        Me.TabPhieuBaoTri.SelectedTabPage = Me.tabDanhSachPhieuBaoTri
        Me.TabPhieuBaoTri.Size = New System.Drawing.Size(1277, 572)
        Me.TabPhieuBaoTri.TabIndex = 20
        Me.TabPhieuBaoTri.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabDanhSachPhieuBaoTri, Me.tabCongViecNoiBo, Me.tabJobcard, Me.tabDichVuThueNgoai, Me.tabKetThucPhieuBaoTri, Me.tabHechuyengia, Me.tabPHTT, Me.tabYeuCauBT, Me.tabNguoiGiamSat, Me.tabTTBT, Me.tabPBTTinhTrang})
        '
        'tabJobcard
        '
        Me.tabJobcard.Controls.Add(Me.ucCongViecNS)
        Me.tabJobcard.Controls.Add(Me.btnCapnhatthoigiancongviec)
        Me.tabJobcard.Name = "tabJobcard"
        Me.tabJobcard.Size = New System.Drawing.Size(1270, 545)
        Me.tabJobcard.Text = "Phân công nhân sự"
        '
        'btnCapnhatthoigiancongviec
        '
        Me.btnCapnhatthoigiancongviec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCapnhatthoigiancongviec.Location = New System.Drawing.Point(1747, 574)
        Me.btnCapnhatthoigiancongviec.Name = "btnCapnhatthoigiancongviec"
        Me.btnCapnhatthoigiancongviec.Size = New System.Drawing.Size(148, 25)
        Me.btnCapnhatthoigiancongviec.TabIndex = 37
        Me.btnCapnhatthoigiancongviec.Text = "Cập nhật thời gian cho CV"
        Me.btnCapnhatthoigiancongviec.UseVisualStyleBackColor = True
        Me.btnCapnhatthoigiancongviec.Visible = False
        '
        'tabDichVuThueNgoai
        '
        Me.tabDichVuThueNgoai.Controls.Add(Me.ucDichVu)
        Me.tabDichVuThueNgoai.Name = "tabDichVuThueNgoai"
        Me.tabDichVuThueNgoai.Size = New System.Drawing.Size(1270, 545)
        Me.tabDichVuThueNgoai.Text = "Dịch vụ thuê ngoài"
        '
        'tabHechuyengia
        '
        Me.tabHechuyengia.Controls.Add(Me.SplitContainerControl6)
        Me.tabHechuyengia.Name = "tabHechuyengia"
        Me.tabHechuyengia.Size = New System.Drawing.Size(1270, 545)
        Me.tabHechuyengia.Text = "Class"
        '
        'SplitContainerControl6
        '
        Me.SplitContainerControl6.AutoSize = True
        Me.SplitContainerControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl6.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl6.Name = "SplitContainerControl6"
        Me.SplitContainerControl6.Panel1.Controls.Add(Me.GroupBox7)
        Me.SplitContainerControl6.Panel1.Text = "Panel1"
        Me.SplitContainerControl6.Panel2.Controls.Add(Me.GroupBox8)
        Me.SplitContainerControl6.Panel2.Text = "Panel2"
        Me.SplitContainerControl6.Size = New System.Drawing.Size(1270, 545)
        Me.SplitContainerControl6.SplitterPosition = 318
        Me.SplitContainerControl6.TabIndex = 65
        Me.SplitContainerControl6.Text = "SplitContainerControl6"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tvwCautrucTB1)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(212, 545)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Danh sách bo phan"
        '
        'tvwCautrucTB1
        '
        Me.tvwCautrucTB1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.tvwCautrucTB1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White
        Me.tvwCautrucTB1.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.tvwCautrucTB1.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.tvwCautrucTB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwCautrucTB1.Location = New System.Drawing.Point(3, 17)
        Me.tvwCautrucTB1.Name = "tvwCautrucTB1"
        Me.tvwCautrucTB1.OptionsBehavior.Editable = False
        Me.tvwCautrucTB1.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.tvwCautrucTB1.OptionsView.ShowVertLines = False
        Me.tvwCautrucTB1.Size = New System.Drawing.Size(206, 525)
        Me.tvwCautrucTB1.TabIndex = 1
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TableLayoutPanel16)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(1052, 545)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Danh sách vật tư, phụ tùng cần sử dụng "
        '
        'TableLayoutPanel16
        '
        Me.TableLayoutPanel16.ColumnCount = 2
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel16.Controls.Add(Me.Panel12, 0, 7)
        Me.TableLayoutPanel16.Controls.Add(Me.lblClass, 0, 1)
        Me.TableLayoutPanel16.Controls.Add(Me.lblProblem, 0, 2)
        Me.TableLayoutPanel16.Controls.Add(Me.txtClass, 1, 1)
        Me.TableLayoutPanel16.Controls.Add(Me.lblCause, 0, 3)
        Me.TableLayoutPanel16.Controls.Add(Me.lblRemedy, 0, 4)
        Me.TableLayoutPanel16.Controls.Add(Me.lblNote, 0, 5)
        Me.TableLayoutPanel16.Controls.Add(Me.txtNoteClass, 1, 5)
        Me.TableLayoutPanel16.Controls.Add(Me.cboProblem, 1, 2)
        Me.TableLayoutPanel16.Controls.Add(Me.cboCause, 1, 3)
        Me.TableLayoutPanel16.Controls.Add(Me.cboRemedy, 1, 4)
        Me.TableLayoutPanel16.Controls.Add(Me.txtBPLine, 0, 0)
        Me.TableLayoutPanel16.Controls.Add(Me.grdProblem, 0, 6)
        Me.TableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel16.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel16.Name = "TableLayoutPanel16"
        Me.TableLayoutPanel16.RowCount = 8
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel16.Size = New System.Drawing.Size(1046, 525)
        Me.TableLayoutPanel16.TabIndex = 28
        '
        'Panel12
        '
        Me.TableLayoutPanel16.SetColumnSpan(Me.Panel12, 2)
        Me.Panel12.Controls.Add(Me.btnThemClass)
        Me.Panel12.Controls.Add(Me.btnKhongghiClass)
        Me.Panel12.Controls.Add(Me.btnSuaClass)
        Me.Panel12.Controls.Add(Me.btnGhiClass)
        Me.Panel12.Controls.Add(Me.btnXoaClass)
        Me.Panel12.Controls.Add(Me.btnThoatClass)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 488)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1040, 34)
        Me.Panel12.TabIndex = 0
        '
        'btnThemClass
        '
        Me.btnThemClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThemClass.Location = New System.Drawing.Point(658, 2)
        Me.btnThemClass.Name = "btnThemClass"
        Me.btnThemClass.Size = New System.Drawing.Size(95, 30)
        Me.btnThemClass.TabIndex = 20
        Me.btnThemClass.Text = "&Thêm"
        '
        'btnKhongghiClass
        '
        Me.btnKhongghiClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongghiClass.Location = New System.Drawing.Point(946, 2)
        Me.btnKhongghiClass.Name = "btnKhongghiClass"
        Me.btnKhongghiClass.Size = New System.Drawing.Size(95, 30)
        Me.btnKhongghiClass.TabIndex = 20
        Me.btnKhongghiClass.Text = "&Không ghi"
        Me.btnKhongghiClass.Visible = False
        '
        'btnSuaClass
        '
        Me.btnSuaClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSuaClass.Location = New System.Drawing.Point(754, 2)
        Me.btnSuaClass.Name = "btnSuaClass"
        Me.btnSuaClass.Size = New System.Drawing.Size(95, 30)
        Me.btnSuaClass.TabIndex = 20
        Me.btnSuaClass.Text = "&Sua"
        '
        'btnGhiClass
        '
        Me.btnGhiClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhiClass.Location = New System.Drawing.Point(850, 2)
        Me.btnGhiClass.Name = "btnGhiClass"
        Me.btnGhiClass.Size = New System.Drawing.Size(95, 30)
        Me.btnGhiClass.TabIndex = 20
        Me.btnGhiClass.Text = "&Ghi"
        Me.btnGhiClass.Visible = False
        '
        'btnXoaClass
        '
        Me.btnXoaClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaClass.Location = New System.Drawing.Point(850, 2)
        Me.btnXoaClass.Name = "btnXoaClass"
        Me.btnXoaClass.Size = New System.Drawing.Size(95, 30)
        Me.btnXoaClass.TabIndex = 20
        Me.btnXoaClass.Text = "Xoa"
        '
        'btnThoatClass
        '
        Me.btnThoatClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoatClass.Location = New System.Drawing.Point(946, 2)
        Me.btnThoatClass.Name = "btnThoatClass"
        Me.btnThoatClass.Size = New System.Drawing.Size(95, 30)
        Me.btnThoatClass.TabIndex = 20
        Me.btnThoatClass.Text = "T&hoát "
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClass.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClass.ForeColor = System.Drawing.Color.Black
        Me.lblClass.Location = New System.Drawing.Point(3, 26)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(99, 26)
        Me.lblClass.TabIndex = 13
        Me.lblClass.Text = "Class"
        Me.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProblem
        '
        Me.lblProblem.AutoSize = True
        Me.lblProblem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProblem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProblem.ForeColor = System.Drawing.Color.Black
        Me.lblProblem.Location = New System.Drawing.Point(3, 52)
        Me.lblProblem.Name = "lblProblem"
        Me.lblProblem.Size = New System.Drawing.Size(99, 26)
        Me.lblProblem.TabIndex = 13
        Me.lblProblem.Text = "Problem"
        Me.lblProblem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClass
        '
        Me.txtClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClass.Location = New System.Drawing.Point(108, 29)
        Me.txtClass.Name = "txtClass"
        Me.txtClass.Size = New System.Drawing.Size(935, 20)
        Me.txtClass.TabIndex = 30
        '
        'lblCause
        '
        Me.lblCause.AutoSize = True
        Me.lblCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCause.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCause.ForeColor = System.Drawing.Color.Black
        Me.lblCause.Location = New System.Drawing.Point(3, 78)
        Me.lblCause.Name = "lblCause"
        Me.lblCause.Size = New System.Drawing.Size(99, 26)
        Me.lblCause.TabIndex = 13
        Me.lblCause.Text = "Cause"
        Me.lblCause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemedy
        '
        Me.lblRemedy.AutoSize = True
        Me.lblRemedy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRemedy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemedy.ForeColor = System.Drawing.Color.Black
        Me.lblRemedy.Location = New System.Drawing.Point(3, 104)
        Me.lblRemedy.Name = "lblRemedy"
        Me.lblRemedy.Size = New System.Drawing.Size(99, 26)
        Me.lblRemedy.TabIndex = 13
        Me.lblRemedy.Text = "Remedy"
        Me.lblRemedy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.Color.Black
        Me.lblNote.Location = New System.Drawing.Point(3, 130)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(99, 51)
        Me.lblNote.TabIndex = 13
        Me.lblNote.Text = "Note"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNoteClass
        '
        Me.txtNoteClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNoteClass.Location = New System.Drawing.Point(108, 133)
        Me.txtNoteClass.Name = "txtNoteClass"
        Me.txtNoteClass.Size = New System.Drawing.Size(935, 45)
        Me.txtNoteClass.TabIndex = 30
        '
        'cboProblem
        '
        Me.cboProblem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProblem.FormattingEnabled = True
        Me.cboProblem.Location = New System.Drawing.Point(108, 55)
        Me.cboProblem.Name = "cboProblem"
        Me.cboProblem.Size = New System.Drawing.Size(935, 21)
        Me.cboProblem.TabIndex = 31
        '
        'cboCause
        '
        Me.cboCause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCause.FormattingEnabled = True
        Me.cboCause.Location = New System.Drawing.Point(108, 81)
        Me.cboCause.Name = "cboCause"
        Me.cboCause.Size = New System.Drawing.Size(935, 21)
        Me.cboCause.TabIndex = 31
        '
        'cboRemedy
        '
        Me.cboRemedy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboRemedy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRemedy.FormattingEnabled = True
        Me.cboRemedy.Location = New System.Drawing.Point(108, 107)
        Me.cboRemedy.Name = "cboRemedy"
        Me.cboRemedy.Size = New System.Drawing.Size(935, 21)
        Me.cboRemedy.TabIndex = 31
        '
        'txtBPLine
        '
        Me.TableLayoutPanel16.SetColumnSpan(Me.txtBPLine, 2)
        Me.txtBPLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBPLine.Location = New System.Drawing.Point(3, 3)
        Me.txtBPLine.Name = "txtBPLine"
        Me.txtBPLine.Properties.ReadOnly = True
        Me.txtBPLine.Size = New System.Drawing.Size(1040, 20)
        Me.txtBPLine.TabIndex = 33
        '
        'grdProblem
        '
        Me.TableLayoutPanel16.SetColumnSpan(Me.grdProblem, 2)
        Me.grdProblem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProblem.Location = New System.Drawing.Point(3, 184)
        Me.grdProblem.MainView = Me.grvProblem
        Me.grdProblem.Name = "grdProblem"
        Me.grdProblem.Size = New System.Drawing.Size(1040, 298)
        Me.grdProblem.TabIndex = 34
        Me.grdProblem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvProblem})
        '
        'grvProblem
        '
        Me.grvProblem.GridControl = Me.grdProblem
        Me.grvProblem.Name = "grvProblem"
        Me.grvProblem.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.grvProblem.OptionsView.ShowGroupPanel = False
        '
        'tabPHTT
        '
        Me.tabPHTT.Controls.Add(Me.TableLayoutPanel22)
        Me.tabPHTT.Name = "tabPHTT"
        Me.tabPHTT.Size = New System.Drawing.Size(1270, 545)
        Me.tabPHTT.Text = "tabPHTT"
        '
        'TableLayoutPanel22
        '
        Me.TableLayoutPanel22.ColumnCount = 4
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel22.Controls.Add(Me.TableLayoutPanel23, 0, 3)
        Me.TableLayoutPanel22.Controls.Add(Me.grdPHTT, 0, 2)
        Me.TableLayoutPanel22.Controls.Add(Me.lblNDungPHTT, 1, 0)
        Me.TableLayoutPanel22.Controls.Add(Me.lblEmailPHTT, 1, 1)
        Me.TableLayoutPanel22.Controls.Add(Me.txtEmailPHTT, 2, 1)
        Me.TableLayoutPanel22.Controls.Add(Me.txtNDungPHTT, 2, 0)
        Me.TableLayoutPanel22.Controls.Add(Me.txtSTTPHTT, 0, 0)
        Me.TableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel22.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel22.Name = "TableLayoutPanel22"
        Me.TableLayoutPanel22.RowCount = 4
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel22.Size = New System.Drawing.Size(1270, 545)
        Me.TableLayoutPanel22.TabIndex = 0
        '
        'TableLayoutPanel23
        '
        Me.TableLayoutPanel23.ColumnCount = 7
        Me.TableLayoutPanel22.SetColumnSpan(Me.TableLayoutPanel23, 4)
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel23.Controls.Add(Me.btnThemPHTT, 3, 0)
        Me.TableLayoutPanel23.Controls.Add(Me.Panel14, 5, 0)
        Me.TableLayoutPanel23.Controls.Add(Me.Panel15, 6, 0)
        Me.TableLayoutPanel23.Controls.Add(Me.btnSuaPHTT, 4, 0)
        Me.TableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel23.Location = New System.Drawing.Point(3, 506)
        Me.TableLayoutPanel23.Name = "TableLayoutPanel23"
        Me.TableLayoutPanel23.RowCount = 1
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel23.Size = New System.Drawing.Size(1264, 36)
        Me.TableLayoutPanel23.TabIndex = 4
        '
        'btnThemPHTT
        '
        Me.btnThemPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThemPHTT.Location = New System.Drawing.Point(867, 3)
        Me.btnThemPHTT.Name = "btnThemPHTT"
        Me.btnThemPHTT.Size = New System.Drawing.Size(94, 30)
        Me.btnThemPHTT.TabIndex = 5
        Me.btnThemPHTT.Text = "btnThemPHTT"
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.btnGhiPHTT)
        Me.Panel14.Controls.Add(Me.btnXoaPHTT)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(1067, 3)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(94, 30)
        Me.Panel14.TabIndex = 0
        '
        'btnGhiPHTT
        '
        Me.btnGhiPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGhiPHTT.Location = New System.Drawing.Point(0, 0)
        Me.btnGhiPHTT.Name = "btnGhiPHTT"
        Me.btnGhiPHTT.Size = New System.Drawing.Size(94, 30)
        Me.btnGhiPHTT.TabIndex = 9
        Me.btnGhiPHTT.Text = "btnGhiPHTT"
        Me.btnGhiPHTT.Visible = False
        '
        'btnXoaPHTT
        '
        Me.btnXoaPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnXoaPHTT.Location = New System.Drawing.Point(0, 0)
        Me.btnXoaPHTT.Name = "btnXoaPHTT"
        Me.btnXoaPHTT.Size = New System.Drawing.Size(94, 30)
        Me.btnXoaPHTT.TabIndex = 7
        Me.btnXoaPHTT.Text = "btnXoaPHTT"
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.btnKhongPHTT)
        Me.Panel15.Controls.Add(Me.btnThoatPHTT)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(1167, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(94, 30)
        Me.Panel15.TabIndex = 1
        '
        'btnKhongPHTT
        '
        Me.btnKhongPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKhongPHTT.Location = New System.Drawing.Point(0, 0)
        Me.btnKhongPHTT.LookAndFeel.SkinName = "Blue"
        Me.btnKhongPHTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnKhongPHTT.Name = "btnKhongPHTT"
        Me.btnKhongPHTT.Size = New System.Drawing.Size(94, 30)
        Me.btnKhongPHTT.TabIndex = 10
        Me.btnKhongPHTT.Text = "btnKhongPHTT"
        '
        'btnThoatPHTT
        '
        Me.btnThoatPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoatPHTT.Location = New System.Drawing.Point(0, 0)
        Me.btnThoatPHTT.Name = "btnThoatPHTT"
        Me.btnThoatPHTT.Size = New System.Drawing.Size(94, 30)
        Me.btnThoatPHTT.TabIndex = 8
        Me.btnThoatPHTT.Text = "btnThoatPHTT"
        '
        'btnSuaPHTT
        '
        Me.btnSuaPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSuaPHTT.Location = New System.Drawing.Point(967, 3)
        Me.btnSuaPHTT.Name = "btnSuaPHTT"
        Me.btnSuaPHTT.Size = New System.Drawing.Size(94, 30)
        Me.btnSuaPHTT.TabIndex = 6
        Me.btnSuaPHTT.Text = "btnSuaPHTT"
        '
        'grdPHTT
        '
        Me.TableLayoutPanel22.SetColumnSpan(Me.grdPHTT, 4)
        Me.grdPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPHTT.Location = New System.Drawing.Point(3, 53)
        Me.grdPHTT.MainView = Me.grvPHTT
        Me.grdPHTT.Name = "grdPHTT"
        Me.grdPHTT.Size = New System.Drawing.Size(1264, 447)
        Me.grdPHTT.TabIndex = 3
        Me.grdPHTT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPHTT})
        '
        'grvPHTT
        '
        Me.grvPHTT.GridControl = Me.grdPHTT
        Me.grvPHTT.Name = "grvPHTT"
        Me.grvPHTT.OptionsView.ShowGroupPanel = False
        '
        'lblNDungPHTT
        '
        Me.lblNDungPHTT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNDungPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNDungPHTT.Location = New System.Drawing.Point(123, 3)
        Me.lblNDungPHTT.Name = "lblNDungPHTT"
        Me.lblNDungPHTT.Size = New System.Drawing.Size(137, 19)
        Me.lblNDungPHTT.TabIndex = 14
        Me.lblNDungPHTT.Text = "lblNDungPHTT"
        '
        'lblEmailPHTT
        '
        Me.lblEmailPHTT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblEmailPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEmailPHTT.Location = New System.Drawing.Point(123, 28)
        Me.lblEmailPHTT.Name = "lblEmailPHTT"
        Me.lblEmailPHTT.Size = New System.Drawing.Size(137, 19)
        Me.lblEmailPHTT.TabIndex = 14
        Me.lblEmailPHTT.Text = "lblEmailPHTT"
        '
        'txtEmailPHTT
        '
        Me.txtEmailPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmailPHTT.Location = New System.Drawing.Point(266, 28)
        Me.txtEmailPHTT.Name = "txtEmailPHTT"
        Me.txtEmailPHTT.Size = New System.Drawing.Size(881, 20)
        Me.txtEmailPHTT.TabIndex = 2
        '
        'txtNDungPHTT
        '
        Me.txtNDungPHTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNDungPHTT.Location = New System.Drawing.Point(266, 3)
        Me.txtNDungPHTT.Name = "txtNDungPHTT"
        Me.txtNDungPHTT.Size = New System.Drawing.Size(881, 20)
        Me.txtNDungPHTT.TabIndex = 1
        '
        'txtSTTPHTT
        '
        Me.txtSTTPHTT.Location = New System.Drawing.Point(3, 3)
        Me.txtSTTPHTT.Name = "txtSTTPHTT"
        Me.txtSTTPHTT.Size = New System.Drawing.Size(114, 20)
        Me.txtSTTPHTT.TabIndex = 20
        Me.txtSTTPHTT.Visible = False
        '
        'tabYeuCauBT
        '
        Me.tabYeuCauBT.Controls.Add(Me.TableLayoutPanel24)
        Me.tabYeuCauBT.Name = "tabYeuCauBT"
        Me.tabYeuCauBT.Size = New System.Drawing.Size(1270, 545)
        Me.tabYeuCauBT.Text = "tabYeuCauBT"
        '
        'TableLayoutPanel24
        '
        Me.TableLayoutPanel24.ColumnCount = 4
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel24.Controls.Add(Me.grdYCBT, 0, 0)
        Me.TableLayoutPanel24.Controls.Add(Me.Panel16, 0, 1)
        Me.TableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel24.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel24.Name = "TableLayoutPanel24"
        Me.TableLayoutPanel24.RowCount = 2
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel24.Size = New System.Drawing.Size(1270, 545)
        Me.TableLayoutPanel24.TabIndex = 1
        '
        'grdYCBT
        '
        Me.TableLayoutPanel24.SetColumnSpan(Me.grdYCBT, 4)
        Me.grdYCBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdYCBT.Location = New System.Drawing.Point(3, 3)
        Me.grdYCBT.MainView = Me.grvYCBT
        Me.grdYCBT.Name = "grdYCBT"
        Me.grdYCBT.Size = New System.Drawing.Size(1264, 496)
        Me.grdYCBT.TabIndex = 1
        Me.grdYCBT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvYCBT})
        '
        'grvYCBT
        '
        Me.grvYCBT.GridControl = Me.grdYCBT
        Me.grvYCBT.Name = "grvYCBT"
        Me.grvYCBT.OptionsView.ShowGroupPanel = False
        '
        'Panel16
        '
        Me.TableLayoutPanel24.SetColumnSpan(Me.Panel16, 4)
        Me.Panel16.Controls.Add(Me.btnXoaYCBT)
        Me.Panel16.Controls.Add(Me.btnThoatYCBT)
        Me.Panel16.Controls.Add(Me.btnThemSuaYCBT)
        Me.Panel16.Controls.Add(Me.btnGhiYCBT)
        Me.Panel16.Controls.Add(Me.btnKhongGhiYCBT)
        Me.Panel16.Controls.Add(Me.btnChonYCSD)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(3, 505)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(1264, 37)
        Me.Panel16.TabIndex = 0
        '
        'btnXoaYCBT
        '
        Me.btnXoaYCBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaYCBT.Location = New System.Drawing.Point(1075, 2)
        Me.btnXoaYCBT.LookAndFeel.SkinName = "Blue"
        Me.btnXoaYCBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXoaYCBT.Name = "btnXoaYCBT"
        Me.btnXoaYCBT.Size = New System.Drawing.Size(94, 31)
        Me.btnXoaYCBT.TabIndex = 4
        Me.btnXoaYCBT.Text = "btnXoaYCBT"
        '
        'btnThoatYCBT
        '
        Me.btnThoatYCBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoatYCBT.Image = CType(resources.GetObject("btnThoatYCBT.Image"), System.Drawing.Image)
        Me.btnThoatYCBT.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnThoatYCBT.Location = New System.Drawing.Point(1170, 2)
        Me.btnThoatYCBT.LookAndFeel.SkinName = "Blue"
        Me.btnThoatYCBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoatYCBT.Name = "btnThoatYCBT"
        Me.btnThoatYCBT.Size = New System.Drawing.Size(94, 31)
        Me.btnThoatYCBT.TabIndex = 5
        Me.btnThoatYCBT.Text = "btnThoatYCBT"
        '
        'btnThemSuaYCBT
        '
        Me.btnThemSuaYCBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThemSuaYCBT.Location = New System.Drawing.Point(980, 2)
        Me.btnThemSuaYCBT.LookAndFeel.SkinName = "Blue"
        Me.btnThemSuaYCBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThemSuaYCBT.Name = "btnThemSuaYCBT"
        Me.btnThemSuaYCBT.Size = New System.Drawing.Size(94, 31)
        Me.btnThemSuaYCBT.TabIndex = 3
        Me.btnThemSuaYCBT.Text = "btnThemSuaYCBT"
        '
        'btnGhiYCBT
        '
        Me.btnGhiYCBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhiYCBT.Location = New System.Drawing.Point(1075, 2)
        Me.btnGhiYCBT.LookAndFeel.SkinName = "Blue"
        Me.btnGhiYCBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnGhiYCBT.Name = "btnGhiYCBT"
        Me.btnGhiYCBT.Size = New System.Drawing.Size(94, 31)
        Me.btnGhiYCBT.TabIndex = 6
        Me.btnGhiYCBT.Text = "btnGhiYCBT"
        Me.btnGhiYCBT.Visible = False
        '
        'btnKhongGhiYCBT
        '
        Me.btnKhongGhiYCBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhiYCBT.Location = New System.Drawing.Point(1170, 2)
        Me.btnKhongGhiYCBT.LookAndFeel.SkinName = "Blue"
        Me.btnKhongGhiYCBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnKhongGhiYCBT.Name = "btnKhongGhiYCBT"
        Me.btnKhongGhiYCBT.Size = New System.Drawing.Size(94, 31)
        Me.btnKhongGhiYCBT.TabIndex = 7
        Me.btnKhongGhiYCBT.Text = "btnKhongGhiYCBT"
        Me.btnKhongGhiYCBT.Visible = False
        '
        'btnChonYCSD
        '
        Me.btnChonYCSD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChonYCSD.Location = New System.Drawing.Point(980, 2)
        Me.btnChonYCSD.LookAndFeel.SkinName = "Blue"
        Me.btnChonYCSD.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnChonYCSD.Name = "btnChonYCSD"
        Me.btnChonYCSD.Size = New System.Drawing.Size(94, 31)
        Me.btnChonYCSD.TabIndex = 8
        Me.btnChonYCSD.Text = "btnChonYCSD"
        Me.btnChonYCSD.Visible = False
        '
        'tabNguoiGiamSat
        '
        Me.tabNguoiGiamSat.Controls.Add(Me.TableLayoutPanel17)
        Me.tabNguoiGiamSat.Name = "tabNguoiGiamSat"
        Me.tabNguoiGiamSat.Size = New System.Drawing.Size(1270, 545)
        Me.tabNguoiGiamSat.Text = "tabNguoiGiamSat"
        '
        'TableLayoutPanel17
        '
        Me.TableLayoutPanel17.ColumnCount = 4
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel17.Controls.Add(Me.grdNGSat, 0, 0)
        Me.TableLayoutPanel17.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel17.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel17.Name = "TableLayoutPanel17"
        Me.TableLayoutPanel17.RowCount = 2
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel17.Size = New System.Drawing.Size(1270, 545)
        Me.TableLayoutPanel17.TabIndex = 2
        '
        'grdNGSat
        '
        Me.TableLayoutPanel17.SetColumnSpan(Me.grdNGSat, 4)
        Me.grdNGSat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNGSat.Location = New System.Drawing.Point(3, 3)
        Me.grdNGSat.MainView = Me.grvNGSat
        Me.grdNGSat.Name = "grdNGSat"
        Me.grdNGSat.Size = New System.Drawing.Size(1264, 496)
        Me.grdNGSat.TabIndex = 1
        Me.grdNGSat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvNGSat})
        '
        'grvNGSat
        '
        Me.grvNGSat.GridControl = Me.grdNGSat
        Me.grvNGSat.Name = "grvNGSat"
        Me.grvNGSat.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.grvNGSat.OptionsView.ShowGroupPanel = False
        '
        'Panel4
        '
        Me.TableLayoutPanel17.SetColumnSpan(Me.Panel4, 4)
        Me.Panel4.Controls.Add(Me.btnThemSuaNGS)
        Me.Panel4.Controls.Add(Me.btnXoaNGS)
        Me.Panel4.Controls.Add(Me.btnThoatNGS)
        Me.Panel4.Controls.Add(Me.btnGhiNGS)
        Me.Panel4.Controls.Add(Me.btnKhongGhiNGS)
        Me.Panel4.Controls.Add(Me.SimpleButton6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 505)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1264, 37)
        Me.Panel4.TabIndex = 0
        '
        'btnThemSuaNGS
        '
        Me.btnThemSuaNGS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThemSuaNGS.Location = New System.Drawing.Point(980, 2)
        Me.btnThemSuaNGS.LookAndFeel.SkinName = "Blue"
        Me.btnThemSuaNGS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThemSuaNGS.Name = "btnThemSuaNGS"
        Me.btnThemSuaNGS.Size = New System.Drawing.Size(94, 31)
        Me.btnThemSuaNGS.TabIndex = 3
        Me.btnThemSuaNGS.Text = "btnThemSuaNGS"
        '
        'btnXoaNGS
        '
        Me.btnXoaNGS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaNGS.Location = New System.Drawing.Point(1075, 2)
        Me.btnXoaNGS.LookAndFeel.SkinName = "Blue"
        Me.btnXoaNGS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXoaNGS.Name = "btnXoaNGS"
        Me.btnXoaNGS.Size = New System.Drawing.Size(94, 31)
        Me.btnXoaNGS.TabIndex = 4
        Me.btnXoaNGS.Text = "btnXoaNGS"
        '
        'btnThoatNGS
        '
        Me.btnThoatNGS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoatNGS.Location = New System.Drawing.Point(1170, 2)
        Me.btnThoatNGS.LookAndFeel.SkinName = "Blue"
        Me.btnThoatNGS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoatNGS.Name = "btnThoatNGS"
        Me.btnThoatNGS.Size = New System.Drawing.Size(94, 31)
        Me.btnThoatNGS.TabIndex = 5
        Me.btnThoatNGS.Text = "btnThoatNGS"
        '
        'btnGhiNGS
        '
        Me.btnGhiNGS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhiNGS.Location = New System.Drawing.Point(1075, 2)
        Me.btnGhiNGS.LookAndFeel.SkinName = "Blue"
        Me.btnGhiNGS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnGhiNGS.Name = "btnGhiNGS"
        Me.btnGhiNGS.Size = New System.Drawing.Size(94, 31)
        Me.btnGhiNGS.TabIndex = 6
        Me.btnGhiNGS.Text = "btnGhiNGS"
        Me.btnGhiNGS.Visible = False
        '
        'btnKhongGhiNGS
        '
        Me.btnKhongGhiNGS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhiNGS.Location = New System.Drawing.Point(1170, 2)
        Me.btnKhongGhiNGS.LookAndFeel.SkinName = "Blue"
        Me.btnKhongGhiNGS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnKhongGhiNGS.Name = "btnKhongGhiNGS"
        Me.btnKhongGhiNGS.Size = New System.Drawing.Size(94, 31)
        Me.btnKhongGhiNGS.TabIndex = 7
        Me.btnKhongGhiNGS.Text = "btnKhongGhiNGS"
        Me.btnKhongGhiNGS.Visible = False
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton6.Location = New System.Drawing.Point(980, 2)
        Me.SimpleButton6.LookAndFeel.SkinName = "Blue"
        Me.SimpleButton6.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(94, 31)
        Me.SimpleButton6.TabIndex = 8
        Me.SimpleButton6.Text = "SimpleButton6"
        Me.SimpleButton6.Visible = False
        '
        'tabTTBT
        '
        Me.tabTTBT.Controls.Add(Me.TableLayoutPanel26)
        Me.tabTTBT.Name = "tabTTBT"
        Me.tabTTBT.Size = New System.Drawing.Size(1270, 545)
        Me.tabTTBT.Text = "tabTTBT"
        '
        'TableLayoutPanel26
        '
        Me.TableLayoutPanel26.ColumnCount = 4
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel26.Controls.Add(Me.grdTTBT, 0, 0)
        Me.TableLayoutPanel26.Controls.Add(Me.Panel18, 0, 1)
        Me.TableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel26.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel26.Name = "TableLayoutPanel26"
        Me.TableLayoutPanel26.RowCount = 2
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel26.Size = New System.Drawing.Size(1270, 545)
        Me.TableLayoutPanel26.TabIndex = 3
        '
        'grdTTBT
        '
        Me.TableLayoutPanel26.SetColumnSpan(Me.grdTTBT, 4)
        Me.grdTTBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTTBT.Location = New System.Drawing.Point(3, 3)
        Me.grdTTBT.MainView = Me.grvTTBT
        Me.grdTTBT.Name = "grdTTBT"
        Me.grdTTBT.Size = New System.Drawing.Size(1264, 496)
        Me.grdTTBT.TabIndex = 1
        Me.grdTTBT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTTBT})
        '
        'grvTTBT
        '
        Me.grvTTBT.GridControl = Me.grdTTBT
        Me.grvTTBT.Name = "grvTTBT"
        Me.grvTTBT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.grvTTBT.OptionsView.ShowGroupPanel = False
        '
        'Panel18
        '
        Me.TableLayoutPanel26.SetColumnSpan(Me.Panel18, 4)
        Me.Panel18.Controls.Add(Me.btnThemSuaTTBT)
        Me.Panel18.Controls.Add(Me.btnXoaTTBT)
        Me.Panel18.Controls.Add(Me.btnThoatTTBT)
        Me.Panel18.Controls.Add(Me.btnGhiTTBT)
        Me.Panel18.Controls.Add(Me.btnKhongGhiTTBT)
        Me.Panel18.Controls.Add(Me.SimpleButton9)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel18.Location = New System.Drawing.Point(3, 505)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(1264, 37)
        Me.Panel18.TabIndex = 0
        '
        'btnThemSuaTTBT
        '
        Me.btnThemSuaTTBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThemSuaTTBT.Location = New System.Drawing.Point(980, 2)
        Me.btnThemSuaTTBT.LookAndFeel.SkinName = "Blue"
        Me.btnThemSuaTTBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThemSuaTTBT.Name = "btnThemSuaTTBT"
        Me.btnThemSuaTTBT.Size = New System.Drawing.Size(94, 31)
        Me.btnThemSuaTTBT.TabIndex = 3
        Me.btnThemSuaTTBT.Text = "btnThemSuaTTBT"
        '
        'btnXoaTTBT
        '
        Me.btnXoaTTBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXoaTTBT.Location = New System.Drawing.Point(1075, 2)
        Me.btnXoaTTBT.LookAndFeel.SkinName = "Blue"
        Me.btnXoaTTBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXoaTTBT.Name = "btnXoaTTBT"
        Me.btnXoaTTBT.Size = New System.Drawing.Size(94, 31)
        Me.btnXoaTTBT.TabIndex = 4
        Me.btnXoaTTBT.Text = "btnXoaTTBT"
        '
        'btnThoatTTBT
        '
        Me.btnThoatTTBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThoatTTBT.Location = New System.Drawing.Point(1170, 2)
        Me.btnThoatTTBT.LookAndFeel.SkinName = "Blue"
        Me.btnThoatTTBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoatTTBT.Name = "btnThoatTTBT"
        Me.btnThoatTTBT.Size = New System.Drawing.Size(94, 31)
        Me.btnThoatTTBT.TabIndex = 5
        Me.btnThoatTTBT.Text = "btnThoatTTBT"
        '
        'btnGhiTTBT
        '
        Me.btnGhiTTBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhiTTBT.Location = New System.Drawing.Point(1075, 2)
        Me.btnGhiTTBT.LookAndFeel.SkinName = "Blue"
        Me.btnGhiTTBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnGhiTTBT.Name = "btnGhiTTBT"
        Me.btnGhiTTBT.Size = New System.Drawing.Size(94, 31)
        Me.btnGhiTTBT.TabIndex = 6
        Me.btnGhiTTBT.Text = "btnGhiTTBT"
        Me.btnGhiTTBT.Visible = False
        '
        'btnKhongGhiTTBT
        '
        Me.btnKhongGhiTTBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKhongGhiTTBT.Location = New System.Drawing.Point(1170, 2)
        Me.btnKhongGhiTTBT.LookAndFeel.SkinName = "Blue"
        Me.btnKhongGhiTTBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnKhongGhiTTBT.Name = "btnKhongGhiTTBT"
        Me.btnKhongGhiTTBT.Size = New System.Drawing.Size(94, 31)
        Me.btnKhongGhiTTBT.TabIndex = 7
        Me.btnKhongGhiTTBT.Text = "btnKhongGhiTTBT"
        Me.btnKhongGhiTTBT.Visible = False
        '
        'SimpleButton9
        '
        Me.SimpleButton9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton9.Location = New System.Drawing.Point(980, 2)
        Me.SimpleButton9.LookAndFeel.SkinName = "Blue"
        Me.SimpleButton9.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton9.Name = "SimpleButton9"
        Me.SimpleButton9.Size = New System.Drawing.Size(94, 31)
        Me.SimpleButton9.TabIndex = 8
        Me.SimpleButton9.Text = "SimpleButton9"
        Me.SimpleButton9.Visible = False
        '
        'tabPBTTinhTrang
        '
        Me.tabPBTTinhTrang.Controls.Add(Me.TableLayoutPanel28)
        Me.tabPBTTinhTrang.Name = "tabPBTTinhTrang"
        Me.tabPBTTinhTrang.Size = New System.Drawing.Size(1270, 545)
        Me.tabPBTTinhTrang.Text = "tabPBTTinhTrang"
        '
        'TableLayoutPanel28
        '
        Me.TableLayoutPanel28.ColumnCount = 7
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.TableLayoutPanel28.Controls.Add(Me.grdTTPBT, 0, 2)
        Me.TableLayoutPanel28.Controls.Add(Me.TableLayoutPanel29, 0, 3)
        Me.TableLayoutPanel28.Controls.Add(Me.lblPBTTinhTrang, 1, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.lblGhiChu, 1, 1)
        Me.TableLayoutPanel28.Controls.Add(Me.txtGhiChuPBTTT, 2, 1)
        Me.TableLayoutPanel28.Controls.Add(Me.txtSTTPBTTT, 0, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.lblNgay, 4, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.cboPBTTTrang, 2, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.dtNgay, 5, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.btnThemTTPBT, 3, 0)
        Me.TableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel28.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel28.Name = "TableLayoutPanel28"
        Me.TableLayoutPanel28.RowCount = 4
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel28.Size = New System.Drawing.Size(1270, 545)
        Me.TableLayoutPanel28.TabIndex = 2
        '
        'grdTTPBT
        '
        Me.TableLayoutPanel28.SetColumnSpan(Me.grdTTPBT, 7)
        Me.grdTTPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTTPBT.Location = New System.Drawing.Point(3, 53)
        Me.grdTTPBT.LookAndFeel.SkinName = "Blue"
        Me.grdTTPBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdTTPBT.MainView = Me.grvTTPBT
        Me.grdTTPBT.Name = "grdTTPBT"
        Me.grdTTPBT.Size = New System.Drawing.Size(1264, 446)
        Me.grdTTPBT.TabIndex = 21
        Me.grdTTPBT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTTPBT})
        '
        'grvTTPBT
        '
        Me.grvTTPBT.GridControl = Me.grdTTPBT
        Me.grvTTPBT.Name = "grvTTPBT"
        Me.grvTTPBT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.grvTTPBT.OptionsView.ShowGroupPanel = False
        '
        'TableLayoutPanel29
        '
        Me.TableLayoutPanel29.ColumnCount = 4
        Me.TableLayoutPanel28.SetColumnSpan(Me.TableLayoutPanel29, 7)
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel29.Controls.Add(Me.Panel19, 2, 0)
        Me.TableLayoutPanel29.Controls.Add(Me.Panel20, 3, 0)
        Me.TableLayoutPanel29.Controls.Add(Me.btnThemPBTTT, 1, 0)
        Me.TableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel29.Location = New System.Drawing.Point(3, 505)
        Me.TableLayoutPanel29.Name = "TableLayoutPanel29"
        Me.TableLayoutPanel29.RowCount = 1
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel29.Size = New System.Drawing.Size(1264, 37)
        Me.TableLayoutPanel29.TabIndex = 4
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.btnXoaPBTTT)
        Me.Panel19.Controls.Add(Me.btnGhiPBTTT)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel19.Location = New System.Drawing.Point(1047, 3)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(104, 31)
        Me.Panel19.TabIndex = 0
        '
        'btnXoaPBTTT
        '
        Me.btnXoaPBTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnXoaPBTTT.Location = New System.Drawing.Point(0, 0)
        Me.btnXoaPBTTT.LookAndFeel.SkinName = "Blue"
        Me.btnXoaPBTTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnXoaPBTTT.Name = "btnXoaPBTTT"
        Me.btnXoaPBTTT.Size = New System.Drawing.Size(104, 31)
        Me.btnXoaPBTTT.TabIndex = 7
        Me.btnXoaPBTTT.Text = "btnXoaPBTTT"
        '
        'btnGhiPBTTT
        '
        Me.btnGhiPBTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGhiPBTTT.Location = New System.Drawing.Point(0, 0)
        Me.btnGhiPBTTT.Name = "btnGhiPBTTT"
        Me.btnGhiPBTTT.Size = New System.Drawing.Size(104, 31)
        Me.btnGhiPBTTT.TabIndex = 9
        Me.btnGhiPBTTT.Text = "btnGhiPBTTT"
        Me.btnGhiPBTTT.Visible = False
        '
        'Panel20
        '
        Me.Panel20.Controls.Add(Me.btnThoatPBTTT)
        Me.Panel20.Controls.Add(Me.btnKhongPBTTT)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel20.Location = New System.Drawing.Point(1157, 3)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(104, 31)
        Me.Panel20.TabIndex = 1
        '
        'btnThoatPBTTT
        '
        Me.btnThoatPBTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThoatPBTTT.Location = New System.Drawing.Point(0, 0)
        Me.btnThoatPBTTT.LookAndFeel.SkinName = "Blue"
        Me.btnThoatPBTTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThoatPBTTT.Name = "btnThoatPBTTT"
        Me.btnThoatPBTTT.Size = New System.Drawing.Size(104, 31)
        Me.btnThoatPBTTT.TabIndex = 8
        Me.btnThoatPBTTT.Text = "btnThoatPBTTT"
        '
        'btnKhongPBTTT
        '
        Me.btnKhongPBTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKhongPBTTT.Location = New System.Drawing.Point(0, 0)
        Me.btnKhongPBTTT.LookAndFeel.SkinName = "Blue"
        Me.btnKhongPBTTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnKhongPBTTT.Name = "btnKhongPBTTT"
        Me.btnKhongPBTTT.Size = New System.Drawing.Size(104, 31)
        Me.btnKhongPBTTT.TabIndex = 10
        Me.btnKhongPBTTT.Text = "btnKhongPBTTT"
        '
        'btnThemPBTTT
        '
        Me.btnThemPBTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThemPBTTT.Location = New System.Drawing.Point(937, 3)
        Me.btnThemPBTTT.LookAndFeel.SkinName = "Blue"
        Me.btnThemPBTTT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThemPBTTT.Name = "btnThemPBTTT"
        Me.btnThemPBTTT.Size = New System.Drawing.Size(104, 31)
        Me.btnThemPBTTT.TabIndex = 5
        Me.btnThemPBTTT.Text = "btnThemPBTTT"
        '
        'lblPBTTinhTrang
        '
        Me.lblPBTTinhTrang.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPBTTinhTrang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPBTTinhTrang.Location = New System.Drawing.Point(123, 3)
        Me.lblPBTTinhTrang.Name = "lblPBTTinhTrang"
        Me.lblPBTTinhTrang.Size = New System.Drawing.Size(137, 19)
        Me.lblPBTTinhTrang.TabIndex = 14
        Me.lblPBTTinhTrang.Text = "lblPBTTinhTrang"
        '
        'lblGhiChu
        '
        Me.lblGhiChu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGhiChu.Location = New System.Drawing.Point(123, 28)
        Me.lblGhiChu.LookAndFeel.SkinName = "Blue"
        Me.lblGhiChu.LookAndFeel.UseDefaultLookAndFeel = False
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(137, 19)
        Me.lblGhiChu.TabIndex = 14
        Me.lblGhiChu.Text = "lblGhiChu"
        '
        'txtGhiChuPBTTT
        '
        Me.TableLayoutPanel28.SetColumnSpan(Me.txtGhiChuPBTTT, 4)
        Me.txtGhiChuPBTTT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGhiChuPBTTT.Enabled = False
        Me.txtGhiChuPBTTT.Location = New System.Drawing.Point(266, 28)
        Me.txtGhiChuPBTTT.Name = "txtGhiChuPBTTT"
        Me.txtGhiChuPBTTT.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtGhiChuPBTTT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtGhiChuPBTTT.Size = New System.Drawing.Size(866, 20)
        Me.txtGhiChuPBTTT.TabIndex = 2
        '
        'txtSTTPBTTT
        '
        Me.txtSTTPBTTT.Location = New System.Drawing.Point(3, 3)
        Me.txtSTTPBTTT.Name = "txtSTTPBTTT"
        Me.txtSTTPBTTT.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtSTTPBTTT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtSTTPBTTT.Size = New System.Drawing.Size(114, 20)
        Me.txtSTTPBTTT.TabIndex = 20
        Me.txtSTTPBTTT.Visible = False
        '
        'lblNgay
        '
        Me.lblNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgay.Location = New System.Drawing.Point(666, 3)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(103, 19)
        Me.lblNgay.TabIndex = 14
        Me.lblNgay.Text = "lblNgay"
        '
        'cboPBTTTrang
        '
        Me.cboPBTTTrang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPBTTTrang.EditValue = ""
        Me.cboPBTTTrang.Enabled = False
        Me.cboPBTTTrang.Location = New System.Drawing.Point(266, 3)
        Me.cboPBTTTrang.Name = "cboPBTTTrang"
        Me.cboPBTTTrang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPBTTTrang.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboPBTTTrang.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cboPBTTTrang.Properties.NullText = ""
        Me.cboPBTTTrang.Size = New System.Drawing.Size(357, 20)
        Me.cboPBTTTrang.TabIndex = 25
        '
        'dtNgay
        '
        Me.dtNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtNgay.EditValue = New Date(2013, 9, 26, 16, 58, 29, 0)
        Me.dtNgay.Enabled = False
        Me.dtNgay.Location = New System.Drawing.Point(775, 3)
        Me.dtNgay.Name = "dtNgay"
        Me.dtNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtNgay.Properties.DisplayFormat.FormatString = "G"
        Me.dtNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtNgay.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtNgay.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtNgay.Properties.Mask.EditMask = "G"
        Me.dtNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtNgay.Size = New System.Drawing.Size(357, 20)
        Me.dtNgay.TabIndex = 26
        '
        'btnThemTTPBT
        '
        Me.btnThemTTPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThemTTPBT.Location = New System.Drawing.Point(629, 3)
        Me.btnThemTTPBT.LookAndFeel.SkinName = "Blue"
        Me.btnThemTTPBT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnThemTTPBT.Name = "btnThemTTPBT"
        Me.btnThemTTPBT.Size = New System.Drawing.Size(31, 19)
        Me.btnThemTTPBT.TabIndex = 27
        Me.btnThemTTPBT.Text = "..."
        '
        'ofdDuongdan
        '
        Me.ofdDuongdan.Filter = "(All file)|*.*|(*.gif)|*.gif|(*.jpg)|*.jpg|(*.bmp)|*.bmp"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabPhieuBaoTri, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel27, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTinhTrangPBT, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1283, 718)
        Me.TableLayoutPanel1.TabIndex = 37
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 15
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 3)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.373786!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.52913!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblCa, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.dtNgayKTKH1, 12, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboNguyenNhan, 12, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMaSoPBT, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtKTTT1, 10, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.dtGioLap, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMaSoPBT, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNgayKTKH, 11, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNgayLap, 11, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblGiohong, 7, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNgayBDKH, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblGioLap, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblLyDo, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDenGioHong, 12, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNguyenNhan, 11, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblKTTT, 11, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNgayCNBDKH, 7, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtGiohong, 8, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNgayhong, 9, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDenNgayHong, 13, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.dtDenKTTT1, 14, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtLydo_1, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.dtNgayLap1, 12, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpNgayCNBDKH1, 8, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.dtNgayBDKH1, 8, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNguoiLap, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboNguoiLap1, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTGNM, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtUserNLap, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnChonMay, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMS_ThietBi, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboMAY, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblLoaiBT, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboLoaiBT, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabSoPhieuBaoTri, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSoPhieuBaoTri1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMucUuTien, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cboMucUuTien1, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cboGS_Vien1, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblGS_Vien, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cboCa, 3, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 38)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1277, 99)
        Me.TableLayoutPanel2.TabIndex = 21
        '
        'lblCa
        '
        Me.lblCa.AutoSize = True
        Me.lblCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCa.ForeColor = System.Drawing.Color.Black
        Me.lblCa.Location = New System.Drawing.Point(211, 48)
        Me.lblCa.Name = "lblCa"
        Me.lblCa.Size = New System.Drawing.Size(59, 24)
        Me.lblCa.TabIndex = 78
        Me.lblCa.Text = "Ca"
        Me.lblCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtNgayKTKH1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.dtNgayKTKH1, 3)
        Me.dtNgayKTKH1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtNgayKTKH1.EditValue = Nothing
        Me.dtNgayKTKH1.Location = New System.Drawing.Point(960, 27)
        Me.dtNgayKTKH1.Name = "dtNgayKTKH1"
        Me.dtNgayKTKH1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtNgayKTKH1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtNgayKTKH1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtNgayKTKH1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtNgayKTKH1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtNgayKTKH1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtNgayKTKH1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtNgayKTKH1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtNgayKTKH1.Size = New System.Drawing.Size(314, 20)
        Me.dtNgayKTKH1.TabIndex = 76
        '
        'cboNguyenNhan
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboNguyenNhan, 3)
        Me.cboNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNguyenNhan.Location = New System.Drawing.Point(960, 75)
        Me.cboNguyenNhan.Name = "cboNguyenNhan"
        Me.cboNguyenNhan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboNguyenNhan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
        Me.cboNguyenNhan.Properties.BestFitRowCount = 10
        Me.cboNguyenNhan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNguyenNhan.Properties.DropDownRows = 10
        Me.cboNguyenNhan.Properties.NullText = ""
        Me.cboNguyenNhan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup
        Me.cboNguyenNhan.Size = New System.Drawing.Size(314, 20)
        Me.cboNguyenNhan.TabIndex = 40
        '
        'txtMaSoPBT
        '
        Me.txtMaSoPBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMaSoPBT.Location = New System.Drawing.Point(83, 3)
        Me.txtMaSoPBT.Name = "txtMaSoPBT"
        Me.txtMaSoPBT.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtMaSoPBT.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtMaSoPBT.Properties.ReadOnly = True
        Me.txtMaSoPBT.Size = New System.Drawing.Size(122, 20)
        Me.txtMaSoPBT.TabIndex = 75
        '
        'dtKTTT1
        '
        Me.dtKTTT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtKTTT1.EditValue = Nothing
        Me.dtKTTT1.Location = New System.Drawing.Point(850, 51)
        Me.dtKTTT1.Name = "dtKTTT1"
        Me.dtKTTT1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtKTTT1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtKTTT1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtKTTT1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtKTTT1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtKTTT1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtKTTT1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtKTTT1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtKTTT1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtKTTT1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.dtKTTT1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtKTTT1.Size = New System.Drawing.Size(24, 20)
        Me.dtKTTT1.TabIndex = 37
        '
        'lblGiohong
        '
        Me.lblGiohong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGiohong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiohong.ForeColor = System.Drawing.Color.Black
        Me.lblGiohong.Location = New System.Drawing.Point(643, 48)
        Me.lblGiohong.Name = "lblGiohong"
        Me.lblGiohong.Size = New System.Drawing.Size(74, 24)
        Me.lblGiohong.TabIndex = 13
        Me.lblGiohong.Text = "Giờ hỏng"
        Me.lblGiohong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayBDKH
        '
        Me.lblNgayBDKH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayBDKH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayBDKH.ForeColor = System.Drawing.Color.Black
        Me.lblNgayBDKH.Location = New System.Drawing.Point(643, 24)
        Me.lblNgayBDKH.Name = "lblNgayBDKH"
        Me.lblNgayBDKH.Size = New System.Drawing.Size(74, 24)
        Me.lblNgayBDKH.TabIndex = 13
        Me.lblNgayBDKH.Text = "Ngày BĐ KH"
        Me.lblNgayBDKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGioLap
        '
        Me.lblGioLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGioLap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGioLap.ForeColor = System.Drawing.Color.Black
        Me.lblGioLap.Location = New System.Drawing.Point(643, 0)
        Me.lblGioLap.Name = "lblGioLap"
        Me.lblGioLap.Size = New System.Drawing.Size(74, 24)
        Me.lblGioLap.TabIndex = 13
        Me.lblGioLap.Text = "Giờ lập"
        Me.lblGioLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDenGioHong
        '
        Me.txtDenGioHong.BackColor = System.Drawing.SystemColors.Window
        Me.txtDenGioHong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDenGioHong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDenGioHong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDenGioHong.Location = New System.Drawing.Point(960, 51)
        Me.txtDenGioHong.Mask = "00:00"
        Me.txtDenGioHong.Name = "txtDenGioHong"
        Me.txtDenGioHong.Size = New System.Drawing.Size(47, 21)
        Me.txtDenGioHong.TabIndex = 14
        Me.txtDenGioHong.ValidatingType = GetType(Date)
        '
        'lblNguyenNhan
        '
        Me.lblNguyenNhan.AutoSize = True
        Me.lblNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNguyenNhan.Location = New System.Drawing.Point(880, 72)
        Me.lblNguyenNhan.Name = "lblNguyenNhan"
        Me.lblNguyenNhan.Size = New System.Drawing.Size(74, 27)
        Me.lblNguyenNhan.TabIndex = 18
        Me.lblNguyenNhan.Text = "Nguyên nhân"
        Me.lblNguyenNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayCNBDKH
        '
        Me.lblNgayCNBDKH.AutoSize = True
        Me.lblNgayCNBDKH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNgayCNBDKH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayCNBDKH.ForeColor = System.Drawing.Color.Black
        Me.lblNgayCNBDKH.Location = New System.Drawing.Point(643, 72)
        Me.lblNgayCNBDKH.Name = "lblNgayCNBDKH"
        Me.lblNgayCNBDKH.Size = New System.Drawing.Size(74, 27)
        Me.lblNgayCNBDKH.TabIndex = 13
        Me.lblNgayCNBDKH.Text = "Ngày "
        Me.lblNgayCNBDKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNgayhong
        '
        Me.txtNgayhong.BackColor = System.Drawing.Color.White
        Me.txtNgayhong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtNgayhong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNgayhong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayhong.Location = New System.Drawing.Point(774, 51)
        Me.txtNgayhong.Mask = "00/00/0000"
        Me.txtNgayhong.Name = "txtNgayhong"
        Me.txtNgayhong.Size = New System.Drawing.Size(70, 21)
        Me.txtNgayhong.TabIndex = 40
        Me.txtNgayhong.ValidatingType = GetType(Date)
        '
        'txtDenNgayHong
        '
        Me.txtDenNgayHong.BackColor = System.Drawing.Color.White
        Me.txtDenNgayHong.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDenNgayHong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDenNgayHong.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDenNgayHong.Location = New System.Drawing.Point(1013, 51)
        Me.txtDenNgayHong.Mask = "00/00/0000"
        Me.txtDenNgayHong.Name = "txtDenNgayHong"
        Me.txtDenNgayHong.Size = New System.Drawing.Size(67, 21)
        Me.txtDenNgayHong.TabIndex = 40
        Me.txtDenNgayHong.ValidatingType = GetType(Date)
        '
        'dtDenKTTT1
        '
        Me.dtDenKTTT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDenKTTT1.EditValue = Nothing
        Me.dtDenKTTT1.Location = New System.Drawing.Point(1086, 51)
        Me.dtDenKTTT1.Name = "dtDenKTTT1"
        Me.dtDenKTTT1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDenKTTT1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtDenKTTT1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDenKTTT1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtDenKTTT1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDenKTTT1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtDenKTTT1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtDenKTTT1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtDenKTTT1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtDenKTTT1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.dtDenKTTT1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDenKTTT1.Size = New System.Drawing.Size(188, 20)
        Me.dtDenKTTT1.TabIndex = 37
        '
        'txtLydo_1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtLydo_1, 6)
        Me.txtLydo_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLydo_1.Location = New System.Drawing.Point(83, 75)
        Me.txtLydo_1.Name = "txtLydo_1"
        Me.txtLydo_1.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtLydo_1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtLydo_1.Size = New System.Drawing.Size(554, 20)
        Me.txtLydo_1.TabIndex = 74
        '
        'dtNgayLap1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.dtNgayLap1, 3)
        Me.dtNgayLap1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtNgayLap1.EditValue = Nothing
        Me.dtNgayLap1.Location = New System.Drawing.Point(960, 3)
        Me.dtNgayLap1.Name = "dtNgayLap1"
        Me.dtNgayLap1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtNgayLap1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtNgayLap1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtNgayLap1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtNgayLap1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtNgayLap1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtNgayLap1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtNgayLap1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtNgayLap1.Size = New System.Drawing.Size(314, 20)
        Me.dtNgayLap1.TabIndex = 37
        '
        'dtpNgayCNBDKH1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.dtpNgayCNBDKH1, 3)
        Me.dtpNgayCNBDKH1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpNgayCNBDKH1.EditValue = Nothing
        Me.dtpNgayCNBDKH1.Enabled = False
        Me.dtpNgayCNBDKH1.Location = New System.Drawing.Point(723, 75)
        Me.dtpNgayCNBDKH1.Name = "dtpNgayCNBDKH1"
        Me.dtpNgayCNBDKH1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpNgayCNBDKH1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtpNgayCNBDKH1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtpNgayCNBDKH1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtpNgayCNBDKH1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtpNgayCNBDKH1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtpNgayCNBDKH1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtpNgayCNBDKH1.Properties.NullDate = """"""
        Me.dtpNgayCNBDKH1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpNgayCNBDKH1.Size = New System.Drawing.Size(151, 20)
        Me.dtpNgayCNBDKH1.TabIndex = 38
        '
        'dtNgayBDKH1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.dtNgayBDKH1, 3)
        Me.dtNgayBDKH1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtNgayBDKH1.EditValue = Nothing
        Me.dtNgayBDKH1.Location = New System.Drawing.Point(723, 27)
        Me.dtNgayBDKH1.Name = "dtNgayBDKH1"
        Me.dtNgayBDKH1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtNgayBDKH1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtNgayBDKH1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.dtNgayBDKH1.Properties.LookAndFeel.SkinName = "Blue"
        Me.dtNgayBDKH1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dtNgayBDKH1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtNgayBDKH1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dtNgayBDKH1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtNgayBDKH1.Size = New System.Drawing.Size(151, 20)
        Me.dtNgayBDKH1.TabIndex = 76
        '
        'cboNguoiLap1
        '
        Me.cboNguoiLap1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboNguoiLap1.Location = New System.Drawing.Point(83, 27)
        Me.cboNguoiLap1.Name = "cboNguoiLap1"
        Me.cboNguoiLap1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboNguoiLap1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
        Me.cboNguoiLap1.Properties.BestFitRowCount = 10
        Me.cboNguoiLap1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNguoiLap1.Properties.DropDownRows = 10
        Me.cboNguoiLap1.Properties.NullText = ""
        Me.cboNguoiLap1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboNguoiLap1.Size = New System.Drawing.Size(122, 20)
        Me.cboNguoiLap1.TabIndex = 42
        '
        'txtUserNLap
        '
        Me.txtUserNLap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUserNLap.Enabled = False
        Me.txtUserNLap.Location = New System.Drawing.Point(276, 27)
        Me.txtUserNLap.Name = "txtUserNLap"
        Me.txtUserNLap.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtUserNLap.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtUserNLap.Properties.ReadOnly = True
        Me.txtUserNLap.Size = New System.Drawing.Size(122, 20)
        Me.txtUserNLap.TabIndex = 75
        '
        'btnChonMay
        '
        Me.btnChonMay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChonMay.Location = New System.Drawing.Point(612, 3)
        Me.btnChonMay.Name = "btnChonMay"
        Me.btnChonMay.Size = New System.Drawing.Size(25, 18)
        Me.btnChonMay.TabIndex = 30
        Me.btnChonMay.Text = "..."
        '
        'cboLoaiBT
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboLoaiBT, 2)
        Me.cboLoaiBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoaiBT.Location = New System.Drawing.Point(484, 27)
        Me.cboLoaiBT.Name = "cboLoaiBT"
        Me.cboLoaiBT.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboLoaiBT.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
        Me.cboLoaiBT.Properties.BestFitRowCount = 10
        Me.cboLoaiBT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLoaiBT.Properties.DropDownRows = 10
        Me.cboLoaiBT.Properties.NullText = ""
        Me.cboLoaiBT.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup
        Me.cboLoaiBT.Size = New System.Drawing.Size(153, 20)
        Me.cboLoaiBT.TabIndex = 42
        '
        'LabSoPhieuBaoTri
        '
        Me.LabSoPhieuBaoTri.AutoSize = True
        Me.LabSoPhieuBaoTri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabSoPhieuBaoTri.Location = New System.Drawing.Point(211, 0)
        Me.LabSoPhieuBaoTri.Name = "LabSoPhieuBaoTri"
        Me.LabSoPhieuBaoTri.Size = New System.Drawing.Size(59, 24)
        Me.LabSoPhieuBaoTri.TabIndex = 16
        Me.LabSoPhieuBaoTri.Text = "Số phiếu"
        Me.LabSoPhieuBaoTri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSoPhieuBaoTri1
        '
        Me.txtSoPhieuBaoTri1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSoPhieuBaoTri1.Enabled = False
        Me.txtSoPhieuBaoTri1.Location = New System.Drawing.Point(276, 3)
        Me.txtSoPhieuBaoTri1.Name = "txtSoPhieuBaoTri1"
        Me.txtSoPhieuBaoTri1.Properties.LookAndFeel.SkinName = "Blue"
        Me.txtSoPhieuBaoTri1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtSoPhieuBaoTri1.Size = New System.Drawing.Size(122, 20)
        Me.txtSoPhieuBaoTri1.TabIndex = 75
        '
        'cboMucUuTien1
        '
        Me.cboMucUuTien1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboMucUuTien1.Location = New System.Drawing.Point(83, 51)
        Me.cboMucUuTien1.Name = "cboMucUuTien1"
        Me.cboMucUuTien1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboMucUuTien1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
        Me.cboMucUuTien1.Properties.BestFitRowCount = 10
        Me.cboMucUuTien1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMucUuTien1.Properties.DropDownRows = 10
        Me.cboMucUuTien1.Properties.NullText = ""
        Me.cboMucUuTien1.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup
        Me.cboMucUuTien1.Size = New System.Drawing.Size(122, 20)
        Me.cboMucUuTien1.TabIndex = 42
        '
        'cboGS_Vien1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cboGS_Vien1, 2)
        Me.cboGS_Vien1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboGS_Vien1.Location = New System.Drawing.Point(484, 51)
        Me.cboGS_Vien1.Name = "cboGS_Vien1"
        Me.cboGS_Vien1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboGS_Vien1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
        Me.cboGS_Vien1.Properties.BestFitRowCount = 10
        Me.cboGS_Vien1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboGS_Vien1.Properties.DropDownRows = 10
        Me.cboGS_Vien1.Properties.NullText = ""
        Me.cboGS_Vien1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboGS_Vien1.Size = New System.Drawing.Size(153, 20)
        Me.cboGS_Vien1.TabIndex = 41
        '
        'cboCa
        '
        Me.cboCa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCa.Location = New System.Drawing.Point(276, 51)
        Me.cboCa.Name = "cboCa"
        Me.cboCa.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboCa.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
        Me.cboCa.Properties.BestFitRowCount = 10
        Me.cboCa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCa.Properties.DropDownRows = 10
        Me.cboCa.Properties.NullText = ""
        Me.cboCa.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup
        Me.cboCa.Size = New System.Drawing.Size(122, 20)
        Me.cboCa.TabIndex = 77
        '
        'TableLayoutPanel27
        '
        Me.TableLayoutPanel27.ColumnCount = 2
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel27.Controls.Add(Me.btnVideo, 0, 0)
        Me.TableLayoutPanel27.Controls.Add(Me.btnHelp, 0, 0)
        Me.TableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel27.Location = New System.Drawing.Point(1219, 3)
        Me.TableLayoutPanel27.Name = "TableLayoutPanel27"
        Me.TableLayoutPanel27.RowCount = 1
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel27.Size = New System.Drawing.Size(61, 29)
        Me.TableLayoutPanel27.TabIndex = 22
        '
        'btnVideo
        '
        Me.btnVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnVideo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnVideo.Location = New System.Drawing.Point(31, 1)
        Me.btnVideo.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.btnVideo.Name = "btnVideo"
        Me.btnVideo.Size = New System.Drawing.Size(29, 27)
        Me.btnVideo.TabIndex = 98
        Me.btnVideo.Tag = "CMMS!FrmPhieuBaoTri_New"
        '
        'btnHelp
        '
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHelp.Location = New System.Drawing.Point(1, 1)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 27)
        Me.btnHelp.TabIndex = 97
        Me.btnHelp.Tag = "CMMS!FrmPhieuBaoTri_New"
        '
        'cboTinhTrangPBT
        '
        Me.cboTinhTrangPBT.AssemblyName = ""
        Me.cboTinhTrangPBT.BackColor = System.Drawing.SystemColors.Window
        Me.cboTinhTrangPBT.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cboTinhTrangPBT.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.cboTinhTrangPBT.ClassName = ""
        Me.cboTinhTrangPBT.Display = ""
        Me.cboTinhTrangPBT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTinhTrangPBT.Enabled = False
        Me.cboTinhTrangPBT.ErrorProviderControl = Me.ErrorProvider1
        Me.cboTinhTrangPBT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTinhTrangPBT.ForeColor = System.Drawing.Color.Red
        Me.cboTinhTrangPBT.FormattingEnabled = True
        Me.cboTinhTrangPBT.IsAll = False
        Me.cboTinhTrangPBT.isInputNull = False
        Me.cboTinhTrangPBT.IsNew = False
        Me.cboTinhTrangPBT.IsNull = True
        Me.cboTinhTrangPBT.ItemAll = " < ALL > "
        Me.cboTinhTrangPBT.ItemNew = "...New"
        Me.cboTinhTrangPBT.Location = New System.Drawing.Point(3, 3)
        Me.cboTinhTrangPBT.MethodName = ""
        Me.cboTinhTrangPBT.Name = "cboTinhTrangPBT"
        Me.cboTinhTrangPBT.Param = ""
        Me.cboTinhTrangPBT.Param2 = ""
        Me.cboTinhTrangPBT.Size = New System.Drawing.Size(82, 21)
        Me.cboTinhTrangPBT.StoreName = ""
        Me.cboTinhTrangPBT.TabIndex = 65
        Me.cboTinhTrangPBT.Table = Nothing
        Me.cboTinhTrangPBT.TextReadonly = False
        Me.cboTinhTrangPBT.Value = ""
        Me.cboTinhTrangPBT.Visible = False
        '
        'PopupMenu2
        '
        Me.PopupMenu2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnuBCCongViecNoiBo), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuBCCongViecDichVu)})
        Me.PopupMenu2.Name = "PopupMenu2"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(1252, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "1000 phiếu"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmPhieuBaoTri_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 718)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.LookAndFeel.SkinName = "Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FrmPhieuBaoTri_New"
        Me.Text = "Phiếu bảo trì"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabKetThucPhieuBaoTri.ResumeLayout(False)
        Me.tabKetThucPhieuBaoTri.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl5.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        Me.grpPhutungthaythe.ResumeLayout(False)
        CType(Me.grdPTThayThe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvPTThayThe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPTTTChiTiet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvPTTTChiTiet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grdVatTuNT.ResumeLayout(False)
        CType(Me.grdVTNghiemThu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvVTNghiemThu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvChung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel14.ResumeLayout(False)
        Me.grpThongtinthuchien.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.txtNgayBatDau.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgayKetThuc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTongGioCong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpThongtinnghiemthu.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(false)
        CType(Me.txtUserName.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTinhTrangSauBaoTri.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNgayNghiemThu.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNgayNghiemThu.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtSGLuyKe.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PopupMenu1,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpChiPhiPBT.ResumeLayout(false)
        Me.TableLayoutPanel6.ResumeLayout(false)
        CType(Me.txtChiPhiTongCongUSD.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiKhacUSD.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiTongCongMacDinh.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiKhacMacDinh.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiPhuTungMacDinh.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiPhuTungUSD.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiVatTuMacDinh.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiThueNgoaiUSD.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiVatTuUSD.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiThueNgoaiMacDinh.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiNhanCongUSD.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtChiPhiNhanCongMacDinh.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(false)
        Me.tabCongViecNoiBo.ResumeLayout(false)
        Me.TableLayoutPanel13.ResumeLayout(false)
        CType(Me.tabCViec,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabCViec.ResumeLayout(false)
        Me.tabCVChinh.ResumeLayout(false)
        Me.tabCVPhu.ResumeLayout(false)
        Me.menuThemViTri.ResumeLayout(false)
        CType(Me.cboMAY.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabDanhSachPhieuBaoTri.ResumeLayout(false)
        Me.TableLayoutPanel8.ResumeLayout(false)
        CType(Me.grdDanhSach_1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvDanhSach_1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView7,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel7.ResumeLayout(false)
        Me.TableLayoutPanel9.ResumeLayout(false)
        Me.TableLayoutPanel9.PerformLayout
        CType(Me.optNTHT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtDNgay_1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtDNgay_1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtTNgay_1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtTNgay_1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTimKiemPBT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TabPhieuBaoTri,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPhieuBaoTri.ResumeLayout(false)
        Me.tabJobcard.ResumeLayout(false)
        Me.tabDichVuThueNgoai.ResumeLayout(false)
        Me.tabHechuyengia.ResumeLayout(false)
        Me.tabHechuyengia.PerformLayout
        CType(Me.SplitContainerControl6,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainerControl6.ResumeLayout(false)
        Me.GroupBox7.ResumeLayout(false)
        CType(Me.tvwCautrucTB1,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox8.ResumeLayout(false)
        Me.TableLayoutPanel16.ResumeLayout(false)
        Me.TableLayoutPanel16.PerformLayout
        Me.Panel12.ResumeLayout(false)
        CType(Me.txtClass.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNoteClass.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtBPLine.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grdProblem,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvProblem,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPHTT.ResumeLayout(false)
        Me.TableLayoutPanel22.ResumeLayout(false)
        Me.TableLayoutPanel23.ResumeLayout(false)
        Me.Panel14.ResumeLayout(false)
        Me.Panel15.ResumeLayout(false)
        CType(Me.grdPHTT,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvPHTT,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtEmailPHTT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNDungPHTT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtSTTPHTT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabYeuCauBT.ResumeLayout(false)
        Me.TableLayoutPanel24.ResumeLayout(false)
        CType(Me.grdYCBT,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvYCBT,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel16.ResumeLayout(false)
        Me.tabNguoiGiamSat.ResumeLayout(false)
        Me.TableLayoutPanel17.ResumeLayout(false)
        CType(Me.grdNGSat,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvNGSat,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel4.ResumeLayout(false)
        Me.tabTTBT.ResumeLayout(false)
        Me.TableLayoutPanel26.ResumeLayout(false)
        CType(Me.grdTTBT,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvTTBT,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel18.ResumeLayout(false)
        Me.tabPBTTinhTrang.ResumeLayout(false)
        Me.TableLayoutPanel28.ResumeLayout(false)
        CType(Me.grdTTPBT,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grvTTPBT,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel29.ResumeLayout(false)
        Me.Panel19.ResumeLayout(false)
        Me.Panel20.ResumeLayout(false)
        CType(Me.txtGhiChuPBTTT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtSTTPBTTT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboPBTTTrang.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtNgay.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtNgay.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        CType(Me.dtNgayKTKH1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtNgayKTKH1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboNguyenNhan.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtMaSoPBT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtKTTT1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtKTTT1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtDenKTTT1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtDenKTTT1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtLydo_1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtNgayLap1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtNgayLap1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtpNgayCNBDKH1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtpNgayCNBDKH1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtNgayBDKH1.Properties.VistaTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtNgayBDKH1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboNguoiLap1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtUserNLap.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboLoaiBT.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtSoPhieuBaoTri1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboMucUuTien1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboGS_Vien1.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cboCa.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel27.ResumeLayout(false)
        CType(Me.PopupMenu2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents lblMaSoPBT As System.Windows.Forms.Label
    Friend WithEvents lblMS_ThietBi As System.Windows.Forms.Label
    Friend WithEvents lblNgayLap As System.Windows.Forms.Label
    Friend WithEvents lblLyDo As System.Windows.Forms.Label
    Friend WithEvents lblNgayKTKH As System.Windows.Forms.Label
    Friend WithEvents lblKTTT As System.Windows.Forms.Label
    Friend WithEvents lblTGNM As System.Windows.Forms.Label
    Friend WithEvents lblMucUuTien As System.Windows.Forms.Label
    Friend WithEvents lblLoaiBT As System.Windows.Forms.Label
    Friend WithEvents lblGS_Vien As System.Windows.Forms.Label
    Friend WithEvents lblNguoiLap As System.Windows.Forms.Label
    Friend WithEvents tabKetThucPhieuBaoTri As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabCongViecNoiBo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabDanhSachPhieuBaoTri As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnGhi_1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongGhi_1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoa_1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSua_1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThem_1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpChonXem_1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDenngay_1 As System.Windows.Forms.Label
    Friend WithEvents TabPhieuBaoTri As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents btnThoat_1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnIn_1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnDuyetPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnKhoaPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXemtailieu As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChonTaiLieu As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtGiohong As Commons.MaskedTextBoxNew
    Friend WithEvents ofdDuongdan As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dtGioLap As Commons.MaskedTextBoxNew

    Friend WithEvents grpThongtinnghiemthu As System.Windows.Forms.GroupBox
    Friend WithEvents txtTinhTrangSauBaoTri As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cboNguoiNghiemThu As Commons.UtcComboBox
    Friend WithEvents txtUserName As Commons.utcTextBox
    Friend WithEvents lblTinhTrangSauBT As System.Windows.Forms.Label
    Friend WithEvents lblNgayNghiemThu As System.Windows.Forms.Label
    Friend WithEvents lblNguoiNghiemThu_6 As System.Windows.Forms.Label
    Friend WithEvents grpThongtinthuchien As System.Windows.Forms.GroupBox
    Friend WithEvents txtNgayKetThuc As Commons.utcTextBox
    Friend WithEvents txtNgayBatDau As Commons.utcTextBox
    Friend WithEvents lblTonggiocong As System.Windows.Forms.Label
    Friend WithEvents txtTongGioCong As Commons.utcTextBox
    Friend WithEvents lblNgayKetThuc As System.Windows.Forms.Label
    Friend WithEvents lblNgayBatDau As System.Windows.Forms.Label
    Friend WithEvents grpPhutungthaythe As System.Windows.Forms.GroupBox

    Friend WithEvents grpChiPhiPBT As System.Windows.Forms.GroupBox
    Friend WithEvents txtChiPhiTongCongUSD As Commons.utcTextBox
    Friend WithEvents txtChiPhiTongCongMacDinh As Commons.utcTextBox
    Friend WithEvents lblChiPhiTongCong As System.Windows.Forms.Label
    Friend WithEvents txtChiPhiThueNgoaiUSD As Commons.utcTextBox
    Friend WithEvents txtChiPhiNhanCongUSD As Commons.utcTextBox
    Friend WithEvents txtChiPhiThueNgoaiMacDinh As Commons.utcTextBox
    Friend WithEvents txtChiPhiNhanCongMacDinh As Commons.utcTextBox
    Friend WithEvents lblChiPhiThueNgoai As System.Windows.Forms.Label
    Friend WithEvents txtChiPhiVatTuUSD As Commons.utcTextBox
    Friend WithEvents lblChiPhiNhanCong As System.Windows.Forms.Label
    Friend WithEvents txtChiPhiVatTuMacDinh As Commons.utcTextBox
    Friend WithEvents txtChiPhiPhuTungUSD As Commons.utcTextBox
    Friend WithEvents lblChiPhiVatTu As System.Windows.Forms.Label
    Friend WithEvents txtChiPhiPhuTungMacDinh As Commons.utcTextBox
    Friend WithEvents lblChiPhiPT As System.Windows.Forms.Label

    Friend WithEvents btnXoa5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaPBTK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSua5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoat5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongGhi5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGhi5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTingTrangSauBaoTri_6 As System.Windows.Forms.Label
    Friend WithEvents BtnLockPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnXacnhanNT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaPTTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTroVe5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaTTNT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtChiPhiKhacUSD As Commons.utcTextBox
    Friend WithEvents txtChiPhiKhacMacDinh As Commons.utcTextBox
    Friend WithEvents LblKhac As System.Windows.Forms.Label
    Friend WithEvents tabJobcard As DevExpress.XtraTab.XtraTabPage

    Friend WithEvents btnCapnhatthoigiancongviec As System.Windows.Forms.Button

    Friend WithEvents tabDichVuThueNgoai As DevExpress.XtraTab.XtraTabPage

    Friend WithEvents lblTienMD As System.Windows.Forms.Label
    Friend WithEvents lblUSD As System.Windows.Forms.Label
    Friend WithEvents grdVatTuNT As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucCVPTro As MVControl.ucCongViecPhuTro
    Friend WithEvents ucDichVu As MVControl.ucDichVuPBT
    Friend WithEvents ucCongViecPBT As MVControl.ucCongViecPBT
    Friend WithEvents BT_CHECK_DL_KHO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabSoPhieuBaoTri As System.Windows.Forms.Label

    Friend WithEvents tabHechuyengia As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel16 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblClass As System.Windows.Forms.Label
    Friend WithEvents txtClass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblProblem As System.Windows.Forms.Label
    Friend WithEvents lblCause As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel

    Friend WithEvents btnThoatClass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongghiClass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSuaClass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGhiClass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaClass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThemClass As DevExpress.XtraEditors.SimpleButton

    Friend WithEvents lblRemedy As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNoteClass As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cboRemedy As System.Windows.Forms.ComboBox

    Friend WithEvents cboProblem As System.Windows.Forms.ComboBox
    Friend WithEvents cboCause As System.Windows.Forms.ComboBox

    Friend WithEvents txtBPLine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblTimKiemTheoMaPBT_1 As System.Windows.Forms.Label
    Friend WithEvents btnTGNgungMay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAuto As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNgayNghiemThu As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblTimKiem As System.Windows.Forms.Label
    Friend WithEvents btnChonMay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdChung As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvChung As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tabPHTT As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel22 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNDungPHTT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel23 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSuaPHTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThemPHTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents btnGhiPHTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaPHTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents btnThoatPHTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongPHTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdPHTT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvPHTT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblEmailPHTT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmailPHTT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNDungPHTT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSTTPHTT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnHThanhNT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents optNTHT As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents btnInPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabYeuCauBT As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel24 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnThemSuaYCBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents btnGhiYCBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaYCBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoatYCBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongGhiYCBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdYCBT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvYCBT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnChonYCSD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblGiohong As System.Windows.Forms.Label
    Friend WithEvents lblNgayBDKH As System.Windows.Forms.Label
    Friend WithEvents lblGioLap As System.Windows.Forms.Label
    Friend WithEvents lblNguyenNhan As System.Windows.Forms.Label
    Friend WithEvents txtDenGioHong As Commons.MaskedTextBoxNew
    Friend WithEvents btnNHHTNTL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLocPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAllocate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnIn_giaonhan As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents mbtnKHT_GET_Nam As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mbtnKHT_GET_BTDK As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mbtnKHT_GET_Thang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mbtnKHT_GET_CV As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mbtnKHN_GET_BTDK As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mbtnKHN_GET_Nam As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuOpt1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuOpt2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuOpt3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mbtnKHT_GET_CV_TU_NAM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBCCongViecNoiBo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBCCongViecDichVu As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu2 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents tabNguoiGiamSat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel17 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdNGSat As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvNGSat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnXoaNGS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoatNGS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGhiNGS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongGhiNGS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThemSuaNGS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUnLock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabTTBT As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel26 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdTTBT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvTTBT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents btnThemSuaTTBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton9 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaTTBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThoatTTBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGhiTTBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongGhiTTBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPhanBoLai As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSGLuyKe As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TableLayoutPanel27 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHelp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVideo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabPBTTinhTrang As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel28 As TableLayoutPanel
    Friend WithEvents grdTTPBT As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvTTPBT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel29 As TableLayoutPanel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents btnXoaPBTTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGhiPBTTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel20 As Panel
    Friend WithEvents btnThoatPBTTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhongPBTTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnThemPBTTT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPBTTinhTrang As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblGhiChu As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGhiChuPBTTT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSTTPBTTT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNgay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPBTTTrang As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtNgay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents menuTinhTrangPBTCT As ContextMenuStrip
    Friend WithEvents btnThemTTPBT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents menuThemViTri As ContextMenuStrip
    Friend WithEvents mnThemViTri As ToolStripMenuItem

    Friend WithEvents cboMAY As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblNgayCNBDKH As Label
    Friend WithEvents txtNgayhong As Commons.MaskedTextBoxNew
    Friend WithEvents txtDenNgayHong As Commons.MaskedTextBoxNew
    Friend WithEvents btnMucUuTien As DevExpress.XtraEditors.SimpleButton
    Private WithEvents dtKTTT1 As DevExpress.XtraEditors.DateEdit
    Private WithEvents dtDenKTTT1 As DevExpress.XtraEditors.DateEdit
    Private WithEvents dtDNgay_1 As DevExpress.XtraEditors.DateEdit
    Private WithEvents dtTNgay_1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtTimKiemPBT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLydo_1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMaSoPBT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSoPhieuBaoTri1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUserNLap As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboNguyenNhan As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboGS_Vien1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboMucUuTien1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboLoaiBT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboNguoiLap1 As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents dtNgayLap1 As DevExpress.XtraEditors.DateEdit
    Private WithEvents dtpNgayCNBDKH1 As DevExpress.XtraEditors.DateEdit
    Private WithEvents dtNgayKTKH1 As DevExpress.XtraEditors.DateEdit
    Private WithEvents dtNgayBDKH1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblCa As Label
    Friend WithEvents cboCa As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents tabCViec As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabCVChinh As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabCVPhu As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents cboTinhTrangPBT As Commons.UtcComboBox
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl4 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grdPTThayThe As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvPTThayThe As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdPTTTChiTiet As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvPTTTChiTiet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdVTNghiemThu As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvVTNghiemThu As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl5 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents tvwCautrucTB1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents grdProblem As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvProblem As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl6 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents btnCapNhatTuDong As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdDanhSach_1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvDanhSach_1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel13 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel14 As TableLayoutPanel
    Friend WithEvents ucCongViecNS As MVControl.ucNhanSuPBT
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBanGiao As DevExpress.XtraEditors.SimpleButton
End Class
