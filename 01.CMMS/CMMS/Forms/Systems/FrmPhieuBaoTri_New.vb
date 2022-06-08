Imports Commons.VS.Classes.Catalogue
Imports Commons.Modules
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.VisualBasic.DateAndTime
Imports DevExpress.XtraEditors
Imports Commons
Imports DevExpress.XtraEditors.Repository
Imports System.Threading
Imports System.Globalization
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmPhieuBaoTri_New
    Dim sMsTinh As String = "-1"
    Dim sMsQuan As String = "-1"
    Dim sMsDuong As String = "-1"
    Dim sDiaDiem As String = "-1"
    Dim iDayChuyen As Integer = -1
    Dim sLoaiMay As String = "-1"
    Dim sNhomMay As String = "-1"
    Dim sMsMay As String = "-1"
    Dim iLoaiBaoTri As Integer = -1
    Dim msPBT_Old As String = "-1"
    Dim sNguoiLap As String = "-1"
    Dim sNGSat As String = "-1"
    Dim iNNhan As Integer = -1

    Dim sBTPT As String = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & UserName
    Dim sBTPTCT As String = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & UserName
    Dim regPBT As String = "DevExpress\XtraGrid\Layouts\GridPBT"


    Public sMsPBTLink As String = "-1"


#Region "Variable 5"
    Dim intTabChanged As Integer = -1
    Dim intUserChucNang As Integer
    Dim intRowCountDVTN, intRowCountDCBP As Integer
    Dim intCurrentRowDCBP As Integer = -1
    Dim blnLoiGhiDuLieu, blnLoiDCBP As Boolean
    Dim strArrMSMay(50) As String
    Dim strArrMSBoPhan(50) As String
    Dim strArrMSBoPhanThayThe(50) As String
    Dim blnUserCN As Boolean = False
    Dim cb As System.Windows.Forms.ComboBox
    Dim TB_PHU_TUNG_THAY_THE_CHI_TIET As DataTable = New DataTable()
#End Region
#Region "Variable "
    Private bThem As Integer = -1
    Private intRowPBT As Integer = 0
    Private TBHinh As New DataTable()
    Private intSTT As Integer = 0
    Private intRowPT As Integer = 0, intRowPT_VT As Integer = 0, intRowCV As Integer = 0, intRowCV_TN As Integer = 0
    Private intRowPT_TN As Integer = 0, intRowHinh As Integer = 0, intRowCVP As Integer = 0, intRowKHNV As Integer = 0

    Private bPBT As Boolean = False
    Dim blnDv As Boolean
    Dim bGhi As Integer = -1
    Dim TBDichVu As New DataTable()
    Dim dtTable3 As DataTable
    Dim intRowIndexCV As Integer = -1, intRowIndexCVP As Integer = -1, intRowIndex As Integer = 0
    Dim bCoQuyen As Boolean = False
    Private bThoat As Boolean
    Private bThemSua As Boolean
    Private bChangce As Boolean = True
    Private PBTOut As String = ""
    Dim TBNhanVien As New DataTable()
    Dim txtBaoTri As TextBox
#End Region
    Private isfirst As Boolean = False
    Dim tb_cv_pt As New DataTable
    Dim _mytable As DataTable = New DataTable()
    Dim _tableMay As DataTable = New DataTable()
    Dim dtPBT As New DataTable
    Dim delete As Boolean = False
    Private isAutoPBT1 As Boolean = False
    Private isPrint1 As Boolean = False
    Private addCV As Boolean = False
    Dim dtTable_tmp As New DataTable
    Public MS_MAY As String = Nothing
    Private tbNULL As New DataTable()
    Private PATH_SERVER As String = ""
    Private bCapnhat1 As Boolean = True
    Private sNNThu As String = ""
    Public bLoad As Boolean
    'SYN 
    Dim isSynData As Boolean = False
    Private _DataAllocatedVTPT As New DataTable()
    Private _SynConnectionInfo As String = ""
    Private flag As Boolean = False 'Kiểm check group radio button thay đổi
    Private Sub loadSynData()
        Try
            Dim str As String = ""
            Dim objreader As SqlDataReader
            str = "SELECT ISNULL(SYN_DATA,CONVERT(BIT,0)) AS SYN_DATA , SYN_INFO FROM THONG_TIN_CHUNG"
            objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objreader.Read
                Try
                    If CType(objreader.Item("SYN_DATA"), Boolean) Then
                        isSynData = True
                        _SynConnectionInfo = Commons.clsXuLy.GiaiMaDL(objreader.Item("SYN_INFO").ToString)
                    Else
                        isSynData = False
                    End If
                Catch ex As Exception

                End Try
            End While
            Try
                objreader.Close()
            Catch ex As Exception
            End Try

            If sPrivate = "BARIA" Then
                isSynData = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    'END SYN

    'USE_KHBT
    Dim isUseKHBT As Boolean = True
    Private Sub loadKHBTInfo()
        Try
            Dim str As String = ""
            Dim objreader As SqlDataReader
            str = "SELECT ISNULL(ISUSE_KHBT,CONVERT(BIT,0)) AS ISUSE_KHBT  FROM THONG_TIN_CHUNG"
            objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objreader.Read
                Try
                    If CType(objreader.Item("ISUSE_KHBT"), Boolean) Then
                        isUseKHBT = True
                    Else
                        isUseKHBT = False
                    End If
                Catch ex As Exception
                End Try
            End While
            Try
                objreader.Close()
            Catch ex As Exception
            End Try

        Catch ex As Exception
        End Try
    End Sub

    Dim dtYCSD As DataTable
    Public Property dtYCSDung() As DataTable
        Get
            Return dtYCSD
        End Get
        Set(ByVal value As DataTable)
            dtYCSD = value
        End Set
    End Property

    Private Sub FrmPhieuBaoTri_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        Try

            Dim Str As String = ""
            DropTable()
            DropTable4()
            ObjSystems.XoaTable("PHU_TU_XK" + UserName)
            ObjSystems.XoaTable("BO_PHAN_DI_CHUYEN_TMP" & UserName)
            ObjSystems.XoaTable("PHIEU_BAO_TRI_SERVICE_TMP" & UserName)
            ObjSystems.XoaTable("PTB_DANH_GIA_SERVICE" & UserName)
            ObjSystems.XoaTable("PBTCVNSCT" & UserName)
            ObjSystems.XoaTable("GSTT_PBT" & UserName)
            ObjSystems.XoaTable("rptTieuDe_PT_BT")
            ObjSystems.XoaTable("rptTieuDe_VT_BT")

            Try
                Str = "DROP PROC [dbo].InsertTAM181" & UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str)
            Catch ex As Exception

            End Try
            Try
                Str = "drop PROC [dbo].InsertTAM18" & UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str)
            Catch ex As Exception
            End Try
            Try
                e.Cancel = Not bThoat
                If bThoat = False Then btnThoat_Click(sender, e)
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try

    End Sub

    Private Sub FrmPhieuBaoTri_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''Nếu là greenfeed thì bật lên
        If Modules.sPrivate = "GREENFEED" Then btnBanGiao.Visible = True Else btnBanGiao.Visible = False


        menuTinhTrangPBTCT.Visible = False
        Me.Cursor = Cursors.WaitCursor
        If sPrivate.ToUpper() <> "BARIA" Then txtSGLuyKe.Properties.ReadOnly = True

        loadSynData()
        loadKHBTInfo()
        SQLString = "0LOAD"
        TabPhieuBaoTri.SelectedTabPageIndex = 0

        bLoad = True
        txtSTTPHTT.Visible = False
        AnHienNutPHTT(True)
        LoadNguyenNhan()
        If IsAutoPBT() Then
            isAutoPBT1 = True
            btnAuto.Visible = True
            btnPrint.Visible = False
        ElseIf IsPrint() Then
            isPrint1 = True
            btnPrint.Visible = True
            btnAuto.Visible = False
        Else
            btnPrint.Visible = False
            btnAuto.Visible = False
        End If
        Dim str As String = ""
        Dim objreader As SqlDataReader

        str = "SELECT * FROM THONG_TIN_CHUNG"
        objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While objreader.Read
            Try
                If CType(objreader.Item("HCG"), Boolean) Then
                Else
                    TabPhieuBaoTri.TabPages.Remove(tabHechuyengia)
                End If
            Catch ex As Exception

            End Try

            Try
                If CType(objreader.Item("YEU_CAU_BT"), Boolean) Then
                    LoadYCNSD("-1")
                Else
                    TabPhieuBaoTri.TabPages.Remove(tabYeuCauBT)
                End If
            Catch ex As Exception
            End Try

            Try
                If CType(objreader.Item("NGUOI_GIAM_SAT"), Boolean) Then
                    LoadNGS("-1", "-1")
                    ObjSystems.MLoadNNXtraGrid(grvNGSat, Me.Name.ToString())
                Else
                    TabPhieuBaoTri.TabPages.Remove(tabNguoiGiamSat)
                End If
            Catch ex As Exception
                TabPhieuBaoTri.TabPages.Remove(tabNguoiGiamSat)
            End Try

            Try
                If CType(objreader.Item("TTBT"), Boolean) Then
                    ' tabTTBT.Show()
                    LoadTTBT("-1")
                    ObjSystems.MLoadNNXtraGrid(grvTTBT, Me.Name.ToString())
                Else
                    TabPhieuBaoTri.TabPages.Remove(tabTTBT)
                End If
            Catch ex As Exception
                TabPhieuBaoTri.TabPages.Remove(tabTTBT)
            End Try
            Try
                If CType(objreader.Item("TTCT"), Boolean) = False Then
                    TabPhieuBaoTri.TabPages.Remove(tabPBTTinhTrang)
                Else
                    TaoLuoiCmbPBTCT()
                End If
            Catch ex As Exception
                TabPhieuBaoTri.TabPages.Remove(tabPBTTinhTrang)
            End Try
        End While


        Try
            objreader.Close()
        Catch ex As Exception
        End Try

        addCV = False
        If PermisString.Equals("Read only") Then
            ObjSystems.DinhDang()
            EnableControl(False)
            btnGhi_1.Visible = False
            HideButton1(True)

            VisibleButtonGhi(False)
            'LoadcboDiadiem()
            dtTNgay_1.EditValue = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), 1)
            dtDNgay_1.EditValue = dtTNgay_1.DateTime.AddMonths(1).AddDays(-1)
            RefreshData5()



            str = "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME ='" & UserName & "' AND STT in(7,8,9)"
            objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objreader.Read
                If objreader.Item("STT") = 7 Then
                    BtnDuyetPBT.Enabled = True
                ElseIf objreader.Item("STT") = 9 Then
                    BtnKhoaPBT.Enabled = True
                    BtnLockPBT.Enabled = True
                    btnHThanhNT.Enabled = True
                    If isAutoPBT1 Then
                        btnAuto.Enabled = True
                    End If
                    If isPrint1 Then
                        btnPrint.Enabled = True
                    End If
                ElseIf objreader.Item("STT") = 8 Then
                    BtnXacnhanNT.Enabled = True
                    btnThemPHTT.Enabled = True
                    btnSuaPHTT.Enabled = True
                    btnXoaPHTT.Enabled = True
                Else

                End If
            End While
            objreader.Close()
            If cboTinhTrangPBT.SelectedValue = 5 Then
                EnableButton5(False)
            End If
            LoadCombo()

            LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
            LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            EnableButton(False)
            TinhtrangPBT_Lock(False)


            btnXoaPBTK.Visible = False
            BtnXacnhanNT.Visible = False
            btnHThanhNT.Visible = False
            btnSua5.Visible = False
            btnXoa5.Visible = False
            BT_CHECK_DL_KHO.Visible = False


            BtnDuyetPBT.Visible = False
            btnTGNgungMay.Visible = False
            btnNHHTNTL.Visible = False
            btnPrint.Visible = False
            btnInPBT.Visible = False

            BtnLockPBT.Visible = False
            btnHThanhNT.Visible = False
            BtnXacnhanNT.Visible = False
            btnSuaPHTT.Visible = False
            btnXoaPHTT.Visible = False
            btnThemPHTT.Visible = False
            btnIn_1.Visible = False

            BtnXemtailieu.Visible = False
            btnThem_1.Visible = False
            btnSua_1.Visible = False
            btnXoa_1.Visible = False
            btnIn_1.Visible = False

            btnThemClass.Visible = False
            btnXoaClass.Visible = False
            btnSuaClass.Visible = False
            btnBanGiao.Visible = False

        Else
            EnableButton(True)
            ObjSystems.DinhDang()
            EnableControl(False)
            btnGhi_1.Visible = False
            HideButton1(True)

            VisibleButtonGhi(False)
            dtTNgay_1.EditValue = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), 1)
            dtDNgay_1.EditValue = dtTNgay_1.DateTime.AddMonths(1).AddDays(-1)
            LoadCombo()
            RefreshData5()
            BtnLockPBT.Enabled = False
            BtnXacnhanNT.Enabled = False

            btnSuaPHTT.Enabled = False
            btnXoaPHTT.Enabled = False
            btnThemPHTT.Enabled = False
            str = "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME ='" & UserName & "' AND STT in(7,8,9)"
            objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objreader.Read
                If objreader.Item("STT") = 7 Then
                    BtnDuyetPBT.Enabled = True
                ElseIf objreader.Item("STT") = 9 Then
                    BtnKhoaPBT.Enabled = True
                    BtnLockPBT.Enabled = True
                    If isAutoPBT1 Then
                        btnAuto.Enabled = True
                    End If
                    If isPrint1 Then
                        btnPrint.Enabled = True
                    End If
                ElseIf objreader.Item("STT") = 8 Then
                    BtnXacnhanNT.Enabled = True
                    btnSuaPHTT.Enabled = True
                    btnXoaPHTT.Enabled = True
                    btnThemPHTT.Enabled = True
                Else

                End If
            End While
            objreader.Close()
            If cboTinhTrangPBT.SelectedValue = 5 Then
                EnableButton5(False)
            End If

            LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
            LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            'end tab 5
            'VisibleButtonXoa1(False)
            'VisibleButtonThem1(True)
            'VisibleButtonGhi1(False)
            'job card
            txtNgayNghiemThu.Enabled = False
            ' AddHandler radCongviecchinh.CheckedChanged, AddressOf Me.radCongviecchinh_CheckedChanged
        End If

        Try


            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetLoaiBaoTriHinhThuc", cboMAY.EditValue))

            cboLoaiBT.Properties.DataSource = Nothing
            cboLoaiBT.Properties.DataSource = dt
            cboLoaiBT.Properties.DisplayMember = "TEN_LOAI_BT"
            cboLoaiBT.Properties.ValueMember = "MS_LOAI_BT"
            cboLoaiBT.Properties.PopulateColumns()
            cboLoaiBT.Properties.Columns("MS_LOAI_BT").Visible = False
            cboLoaiBT.Properties.Columns("HU_HONG").Visible = False

            cboLoaiBT.Properties.Columns("TEN_LOAI_BT").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "TEN_LOAI_BT", TypeLanguage)

            dt = New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT, (CASE " & TypeLanguage & " WHEN 0 THEN CA ELSE CA_ANH END) + ' (' + CONVERT(NVARCHAR(5),CAST(TU_GIO AS TIME),108) + ' - ' +  CONVERT(NVARCHAR(5),CAST(DEN_GIO AS TIME),108) + ')' AS TEN_CA FROM CA  ORDER BY TU_GIO, DEN_GIO"))

            Dim dr As DataRow = dt.NewRow()

            dr("STT") = "10000"
            dr("TEN_CA") = "...New..."
            dt.Rows.Add(dr)

            cboCa.Properties.DataSource = Nothing
            cboCa.Properties.DataSource = dt
            cboCa.Properties.DisplayMember = "TEN_CA"
            cboCa.Properties.ValueMember = "STT"
            cboCa.Properties.PopulateColumns()
            cboCa.Properties.Columns("STT").Visible = False
            cboCa.Properties.Columns("TEN_CA").Caption = ObjLanguages.GetLanguage(ModuleName, "frmCa", "lblTenCa", TypeLanguage)

        Catch ex As Exception
        End Try

        objreader.Close()
        objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH=1")
        While objreader.Read
            lblTienMD.Text = lblTienMD.Text & " " & objreader.Item("NGOAI_TE")
        End While
        objreader.Close()

        isfirst = True
        Me.Cursor = Cursors.Default
        If (MS_MAY <> Nothing) Then
            btnThem_1_Click(btnThem_1, EventArgs.Empty)
            cboMAY.EditValue = MS_MAY
        End If

        bLoad = False

        SQLString = ""
        BindData()

        If (sPrivate <> "" And sPrivate = "KKTL") Or sPrivate = "HUDA" Then
            btnIn_giaonhan.Visible = True
            mnuBCCongViecNoiBo.Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "mnuBCCongViecNoiBo", TypeLanguage)
            mnuBCCongViecDichVu.Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "mnuBCCongViecDichVu", TypeLanguage)
            btnIn_giaonhan.Text = ObjLanguages.GetLanguage(ModuleName, Me.Name, "btnIn_giaonhan", TypeLanguage)
            If sPrivate = "HUDA" Then
                btnIn_giaonhan.ShowArrowButton = False
                btnIn_giaonhan.DropDownControl = PopupMenu2
            End If
        Else
            btnIn_giaonhan.Visible = False
        End If

        'LoadNN()
        ObjSystems.ThayDoiNN(Me)

        If LicID <> 0 Then LoadVersion()



        If sPrivate = "BARIA" Then
            btnPhanBoLai.Visible = True
            dtNgay.DateTime = Now
        Else
            btnPhanBoLai.Visible = False
        End If

        Try
            Dim str1 As String = "SELECT ISNULL(MUC_UU_TIEN, 0) AS MUC_UU_TIEN FROM THONG_TIN_CHUNG"
            btnMucUuTienFlag = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str1))
        Catch ex As Exception
        End Try

        TableLayoutPanel2.ColumnStyles(10).SizeType = SizeType.Absolute
        TableLayoutPanel2.ColumnStyles(14).SizeType = SizeType.Absolute


        TableLayoutPanel2.ColumnStyles(10).Width = 23
        TableLayoutPanel2.ColumnStyles(14).Width = 21


        Dim ToolTip1 As System.Windows.Forms.ToolTip = New System.Windows.Forms.ToolTip()
        ToolTip1.SetToolTip(btnMucUuTien, ObjLanguages.GetLanguage(ModuleName, Me.Name,
                        "MucUuTienHint", TypeLanguage))


        Try

            AddHandler ucCVPTro.btnThemSua.Click, AddressOf Me.ThayDoiTinhTrangPBT
            AddHandler ucCVPTro.btnXoa.Click, AddressOf Me.XoaPhuTro
            AddHandler ucCVPTro.Load, AddressOf ucCVPTro.LoadFormCVPT
        Catch ex As Exception

        End Try
        Try
            AddHandler ucDichVu.btnChonCongViec.Click, AddressOf Me.ChonCongViecDichVu
            AddHandler ucDichVu.btnPTThayThe.Click, AddressOf Me.ChonPhuTungCVDichVu
            AddHandler ucDichVu.btnXoa.Click, AddressOf Me.XoaDichVu
            AddHandler ucDichVu.btnThemSuaCV.Click, AddressOf Me.ThemSuaCV
            AddHandler ucDichVu.btnThemSuaDV.Click, AddressOf Me.ThemSuaDV
            AddHandler ucDichVu.Load, AddressOf ucDichVu.LoadFormDVPBT
        Catch ex As Exception

        End Try

        Try

            AddHandler ucCongViecPBT.btnBackLog.Click, AddressOf Me.BackLog
            AddHandler ucCongViecPBT.btnThem.Click, AddressOf Me.ThemCongViecChinh
            AddHandler ucCongViecPBT.btnChonCongViec.Click, AddressOf Me.ChonCongViecChinh
            AddHandler ucCongViecPBT.btnChonVTPT.Click, AddressOf Me.ChonPhuTungCongViecChinh
            AddHandler ucCongViecPBT.Load, AddressOf ucCongViecPBT.LoadFormCVPBT
        Catch ex As Exception

        End Try
        Try

            AddHandler ucCongViecNS.btnThemsua.Click, AddressOf Me.btnThemsuaNSClick
            AddHandler ucCongViecNS.btnHThanhNS.Click, AddressOf Me.btnHoanThanhClick
            AddHandler ucCongViecNS.btnXoa.Click, AddressOf Me.XoaCongViecNS
            AddHandler ucCongViecNS.grvKHNhanVien.DoubleClick, AddressOf Me.grvKeHoachNS_DoubleClick
            'AddHandler ucCongViecNS.Load, AddressOf LoadFormNhanSuPBT
        Catch ex As Exception

        End Try


        If sMsPBTLink = "-1" Then Exit Sub
        txtTimKiemPBT.Text = sMsPBTLink
        txtTimKiemPBT_KeyDown(txtTimKiemPBT.Text, New KeyEventArgs(Keys.Enter))
        sMsPBTLink = "-1"
        SplitContainerControl4.FixedPanel = SplitFixedPanel.None
        SplitContainerControl2.FixedPanel = SplitFixedPanel.None


        Try
            Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grdDanhSach_1.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
            AddHandler grv.ShowGridMenu, AddressOf grvDanhSach_1_ShowGridMenu
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnThemsuaNSClick(sender As Object, e As EventArgs)
        If KiemHoanThanh() = False Then
            Exit Sub
        Else
            ucCongViecNS.btnHThanhNS.Enabled = True
            btnHThanhNT.Enabled = True
            ucCongViecNS.iTTPBTri = 2
            CapNhapPBTCT(2)
        End If
        ucCongViecNS.ThemNhanSuPBT()
        BarManagerNS = ucCongViecNS.BarManagerNS
    End Sub
    Private Sub btnHoanThanhClick(sender As Object, e As EventArgs)
        HoanThanhPBT()
    End Sub
    'CVC

    Private Sub BackLog()
        If (Not txtMaSoPBT.Text.Trim().Equals(String.Empty)) Then
            Dim frmBacklog As frmBackLog = New frmBackLog()
            frmBacklog.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
            If (frmBacklog.ShowDialog(Me) = DialogResult.OK) Then
                ucCongViecPBT.LoadCongViec()
            End If
        End If
    End Sub
    Private Sub ThemCongViecChinh()
        If KiemHoanThanh() = False Then Exit Sub Else CapNhapPBTCT(2)
        addCV = True
        ucCongViecPBT.ThemSuaCV()

        Dim dtTmp As New DataTable
        Dim sBTVTX As String = "PHU_TU_XK" + UserName
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVatTuPhieuBaoTri", "-1", -1, "-1"))
        ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTVTX, dtTmp, "")

        'btnSynDNXK.Visible = False
        'btnTraKho.Visible = False
    End Sub
    Private Sub ChonCongViecChinh()
        Try

            Dim str As String = ""
            Dim frm As New frmChonCongViecChoPBT
            frm.MS_MAY = cboMAY.EditValue
            frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
            If isUseKHBT Then
                frm.KHBT_NEW = "frmKehoachtongtheNew"
            Else
                frm.KHBT_NEW = ""
            End If

            If frm.ShowDialog() = DialogResult.OK Then
                Dim tb As New DataTable
                str = "Select DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN FROM " & sBTPT & " WHERE MS_PT_CHA='Y'" ',MS_PT,SL_KH
                tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                For i As Integer = 0 To tb.Rows.Count - 1
                    str = "INSERT INTO " & sBTPTCT & " Select DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV, " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                                    " CASE WHEN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH IS NULL THEN CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ELSE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH END AS SL_KH , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG,   " &
                                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.DON_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGOAI_TE,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA_USD " &
                                    " FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "'" &
                                    " WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_MAY=N'" & cboMAY.EditValue & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT IS NOT NULL "
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Next

                '05.05.2016
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_TMP" & UserName & " SET NGAY_BDCV = N'" & dtNgayBDKH1.DateTime.ToString("yyyy/MM/dd") & "', NGAY_KTCV = N'" & dtNgayKTKH1.DateTime.ToString("yyyy/MM/dd") & "' WHERE NGAY_BDCV IS NULL AND NGAY_KTCV IS NULL"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                ucCongViecPBT.LoadCongViec()
            Else
                Try
                    Dim lstMSCV As String = ""
                    Dim DT As DataTable = CType(ucCongViecPBT.grdCongviec.DataSource, DataTable)
                    If DT.Rows.Count > 0 Then

                        lstMSCV = String.Join(", ", DT.Select().AsEnumerable().Select(Function(x) "'" & x("MS_CV").ToString() & "!" & x("MS_BO_PHAN").ToString() & "'").ToArray())

                        str = "DELETE PHIEU_BAO_TRI_CONG_VIEC_TMP" & UserName & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND (Convert(nvarchar(10), MS_CV) + '!' + Convert(nvarchar(10), MS_BO_PHAN)) NOT IN (" & lstMSCV & ")"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                        str = "DELETE " & sBTPTCT & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND (Convert(nvarchar(10), MS_CV) + '!' + Convert(nvarchar(10), MS_BO_PHAN)) NOT IN (" & lstMSCV & ")"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                        str = "DELETE " & sBTPT & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND (Convert(nvarchar(10), MS_CV) + '!' + Convert(nvarchar(10), MS_BO_PHAN)) NOT IN (" & lstMSCV & ")"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    Else
                        str = "DELETE PHIEU_BAO_TRI_CONG_VIEC_TMP" & UserName & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                        str = "DELETE " & sBTPTCT & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                        str = "DELETE " & sBTPT & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                    End If

                Catch ex As Exception
                End Try

            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChonPhuTungCongViecChinh()
        If ucCongViecPBT.grvCongViec.RowCount = 0 Then
            Exit Sub
        End If
        Dim frm As New ReportMain.frmChonPhuTungcho_PBT()
        frm.MS_MAY = cboMAY.EditValue
        frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text


        frm.MS_CVBT = ucCongViecPBT.grvCongViec.GetFocusedDataRow()("MS_CV").ToString() & ucCongViecPBT.grvCongViec.GetFocusedDataRow()("MS_BO_PHAN").ToString()

        Dim str As String = ""
        Dim sBTVTX As String = "PHU_TU_XK" + UserName
        str = " INSERT INTO [" & sBTVTX & "] ([CHON],[MS_PHIEU_BAO_TRI],[MS_PT],[TEN_PT],[MS_PT_NCC],[SL_VT], " &
                    " [MS_DH_XUAT_PT],[MS_DH_NHAP_PT],[TEN_VI_TRI],[MS_BO_PHAN],[MS_CV]) " &
                    " SELECT CONVERT(BIT,0) AS CHON,T1.MS_PHIEU_BAO_TRI, T3.MS_PT, T4.TEN_PT, T4.MS_PT_NCC, " &
                    " T3.SL_VT, T1.MS_DH_XUAT_PT, T3.MS_DH_NHAP_PT, T5.TEN_VI_TRI, A.MS_BO_PHAN, A.MS_CV " &
                    " FROM IC_DON_HANG_XUAT AS T1 INNER JOIN IC_DON_HANG_XUAT_VAT_TU AS T2 ON   T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT " &
                    " INNER JOIN IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T3 ON   T2.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT AND T2.MS_PT = T3.MS_PT " &
                    " INNER JOIN IC_PHU_TUNG AS T4 ON   T3.MS_PT = T4.MS_PT INNER JOIN VI_TRI_KHO AS T5 ON T1.MS_KHO = T5.MS_KHO " &
                    " AND T3.MS_VI_TRI = T5.MS_VI_TRI, " &
                    " (SELECT DISTINCT MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" + UserName + ") A " &
                    " WHERE (T1.MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "')  " &
                    " AND NOT EXISTS " &
                    " (SELECT * FROM " & sBTPT & " X WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "'  " &
                    " AND X.MS_PT = T3.MS_PT AND X.MS_BO_PHAN = A.MS_BO_PHAN AND X.MS_CV = A.MS_CV)  " &
                    " AND NOT EXISTS " &
                    " (SELECT * FROM " & sBTVTX & " X WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "'  " &
                    " AND X.MS_PT = T3.MS_PT AND X.MS_BO_PHAN = A.MS_BO_PHAN AND X.MS_CV = A.MS_CV) "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        If frm.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Dim tb, dtT As New DataTable


        SQLString = " UPDATE " & sBTPTCT & " SET MS_VI_TRI_PT = '' WHERE ISNULL(MS_VI_TRI_PT,'') = '' "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQLString)


        str = " DELETE FROM " & sBTPTCT & " WHERE MS_PT IN (SELECT DISTINCT MS_PT FROM " & sBTPT & " WHERE TU_XUAT = 1)"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        str = " DELETE FROM " & sBTPT & " WHERE TU_XUAT = 1 "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        str = " INSERT INTO " & sBTPT & " (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, TEN_PT, MS_PT_NCC, MS_PT_CTY, SL_KH, SL_TT, MS_PT_CHA, TON_TAI, TU_XUAT) " &
                " SELECT A.MS_PHIEU_BAO_TRI, A.MS_CV, A.MS_BO_PHAN, A.MS_PT, A.TEN_PT, A.MS_PT_NCC, B.MS_PT_CTY, SUM(A.SL_VT) AS SL_KH, NULL AS SL_TT, 'YN' AS MS_PT_CHA, NULL AS TON_TAI,  " &
                " 1 AS TU_XUAT " &
                " FROM PHU_TU_XK" & UserName & " AS A INNER JOIN " &
                " IC_PHU_TUNG AS B ON A.MS_PT = B.MS_PT " &
                " WHERE (A.CHON = 1) " &
                " GROUP BY A.MS_PHIEU_BAO_TRI, A.MS_CV, A.MS_BO_PHAN, A.MS_PT, A.TEN_PT, A.MS_PT_NCC, B.MS_PT_CTY "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        tb = New DataTable
        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_PT_CHA FROM " & sBTPT & " WHERE MS_PT_CHA LIKE '%Y%'"
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

        Dim dtReader As SqlDataReader, bPT_CHA As Boolean = False
        Dim dtTam As SqlDataReader, strTam As String = ""

        For i As Integer = 0 To tb.Rows.Count - 1
            strTam = "SELECT * FROM " & sBTPT & " WHERE MS_PT IN (SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & cboMAY.EditValue & "' AND MS_BO_PHAN ='" & tb.Rows(i).Item("MS_BO_PHAN") & "') AND MS_PT_CHA = 'Y' AND MS_PT = '" & tb.Rows(i).Item("MS_PT") & "' AND (TON_TAI = 0 OR TON_TAI IS NULL )"
            dtTam = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strTam)
            If dtTam.Read = True Then

                str = " SELECT * FROM " & sBTPTCT & " where  MS_PT = '" & tb.Rows(i).Item("MS_PT") & "' AND MS_CV = " & dtTam.Item("MS_CV") & " AND MS_BO_PHAN = '" & dtTam.Item("MS_BO_PHAN") & "' and ms_phieu_bao_tri = '" & txtMaSoPBT.Text & "'AND STT IS NOT NULL "
                Dim DT As New DataTable()
                DT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                If (DT.Rows.Count > 0) Then Continue For
                str = "INSERT INTO " & sBTPTCT & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,SL_CUM) " &
                    "VALUES(N'" & txtMaSoPBT.Text & "'," & dtTam.Item("MS_CV") & ",'" & dtTam.Item("MS_BO_PHAN") & "','" & tb.Rows(i).Item("MS_PT") & "'," &
                    "NULL," & dtTam.Item("SL_KH") & "," & IIf(IsDBNull(dtTam.Item("SL_TT")), "NULL", dtTam.Item("SL_TT")) & "," & IIf(IsDBNull(dtTam.Item("SL_KH")), "NULL", dtTam.Item("SL_KH")) & ")"
            Else
                str = "SELECT COUNT(*) FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & tb.Rows(i).Item("MS_CV") & " AND MS_BO_PHAN='" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_PT='" & tb.Rows(i).Item("MS_PT") & "'"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)

                str = "INSERT INTO " & sBTPTCT & " Select DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV, " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                                    " CASE WHEN ISNULL(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH,0)<=0 THEN CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ELSE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH END AS SL_KH, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ,  " &
                                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.DON_GIA, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGOAI_TE, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA_USD " &
                                    " FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT  " &
                                    " WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
                                    " AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "' " &
                                    " AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT='" & tb.Rows(i).Item("MS_PT") & "' " &
                                    " AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' " &
                                    " AND MS_MAY=N'" & cboMAY.EditValue & "' " &
                                    " AND NOT EXISTS (SELECT  * FROM " & sBTPTCT & " T1 " &
                                    " WHERE T1.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT AND T1.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV " &
                                    " AND T1.MS_BO_PHAN = CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN " &
                                    " AND T1.MS_VI_TRI_PT =  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT ) "
                While dtReader.Read
                    If dtReader.Item(0) > 0 Then
                        str += " AND STT IS NOT NULL"
                    Else
                        str += " AND STT IS NULL"
                    End If
                End While
                dtReader.Close()
            End If
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch EX As Exception
                XtraMessageBox.Show(EX.Message)
            End Try
        Next
        tb = New DataTable
        str = " SELECT * FROM " & sBTPT & " T1 INNER JOIN IC_PHU_TUNG AS B ON T1.MS_PT = B.MS_PT INNER JOIN " &
                        " LOAI_VT AS C ON B.MS_LOAI_VT = C.MS_LOAI_VT WHERE     " &
                        " NOT EXISTS  (SELECT     * FROM " & sBTPTCT & " AS A WHERE " &
                        " A.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI AND A.MS_CV = T1.MS_CV AND A.MS_BO_PHAN = T1.MS_BO_PHAN " &
                        " AND A.MS_PT = T1.MS_PT )-- AND ISNULL(VAT_TU,0) = 0 "
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If tb.Rows.Count > 0 Then
            For i As Integer = 0 To tb.Rows.Count - 1
                Dim dt As New DataTable
                str = " SELECT N'" & txtMaSoPBT.Text & "'," & tb.Rows(i).Item("MS_CV") & ",MS_BO_PHAN, MS_PT, MS_VI_TRI_PT, SO_LUONG, NULL, SO_LUONG
                    FROM         dbo.CAU_TRUC_THIET_BI_PHU_TUNG WHERE ACTIVE = 1 AND MS_MAY = N'" & cboMAY.EditValue & "' 
                    AND MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_PT = '" & tb.Rows(i).Item("MS_PT") & "' "

                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                If (dt.Rows.Count > 0) Then
                    str = "INSERT INTO " & sBTPTCT & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,SL_CUM) 
                                    SELECT N'" & txtMaSoPBT.Text & "'," & tb.Rows(i).Item("MS_CV") & ",MS_BO_PHAN, MS_PT, MS_VI_TRI_PT, SO_LUONG, NULL, SO_LUONG
                                        FROM         dbo.CAU_TRUC_THIET_BI_PHU_TUNG WHERE ACTIVE = 1 AND MS_MAY = N'" & cboMAY.EditValue & "' 
                                        AND MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_PT = '" & tb.Rows(i).Item("MS_PT") & "' "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Else
                    str = "INSERT INTO " & sBTPTCT & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,SL_CUM) " &
                       "VALUES(N'" & txtMaSoPBT.Text & "'," & tb.Rows(i).Item("MS_CV") & ",'" & tb.Rows(i).Item("MS_BO_PHAN") & "','" & tb.Rows(i).Item("MS_PT") & "'," &
                        "N'A'," & tb.Rows(i).Item("SL_KH") & "," & IIf(IsDBNull(tb.Rows(i).Item("SL_TT")), "NULL", tb.Rows(i).Item("SL_TT")) & "," & IIf(IsDBNull(tb.Rows(i).Item("SL_KH")), "NULL", tb.Rows(i).Item("SL_KH")) & ")"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
            Next
        End If


        Dim dtTmp As New DataTable
        Dim dtCT As New DataTable
        str = "SELECT DISTINCT * FROM " & sBTPT & " WHERE ISNULL(TU_XUAT,0) = 1"
        tb = New DataTable
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If tb.Rows.Count > 0 Then
            For i As Integer = 0 To tb.Rows.Count - 1
                dtTmp = New DataTable
                str = " SELECT ISNULL(SUM(SL_KH),0) AS SL_CT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & UserName &
                        " WHERE MS_PHIEU_BAO_TRI = N'" & tb.Rows(i)("MS_PHIEU_BAO_TRI").ToString() & "'  " &
                        " AND MS_CV = " & tb.Rows(i)("MS_CV").ToString() & "  " &
                        " AND MS_BO_PHAN = N'" & tb.Rows(i)("MS_BO_PHAN").ToString() & "'  " &
                        " AND MS_PT = N'" & tb.Rows(i)("MS_PT").ToString() & "'  "
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                If dtTmp.Rows.Count > 0 Then
                    If Double.Parse(dtTmp.Rows(0)("SL_CT").ToString()) > Double.Parse(tb.Rows(i)("SL_KH").ToString()) Then
                        str = " SELECT *  FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & UserName &
                                " WHERE MS_PHIEU_BAO_TRI = N'" & tb.Rows(i)("MS_PHIEU_BAO_TRI").ToString() & "'  " &
                                " AND MS_CV = " & tb.Rows(i)("MS_CV").ToString() & "  " &
                                " AND MS_BO_PHAN = N'" & tb.Rows(i)("MS_BO_PHAN").ToString() & "'  " &
                                " AND MS_PT = N'" & tb.Rows(i)("MS_PT").ToString() & "'  "
                        dtCT = New DataTable
                        dtCT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                        Dim iTSL, iSLHT, iSLCT As Double
                        iTSL = Double.Parse(tb.Rows(i)("SL_KH").ToString())
                        iSLCT = 0
                        iSLHT = iTSL
                        For j As Integer = 0 To dtCT.Rows.Count - 1

                            If iTSL = 0 Then
                                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & UserName &
                                        " SET SL_KH = 0 " &
                                        " WHERE MS_PHIEU_BAO_TRI = N'" & tb.Rows(i)("MS_PHIEU_BAO_TRI").ToString() & "'  " &
                                " AND MS_CV = " & tb.Rows(i)("MS_CV").ToString() & "  " &
                                " AND MS_BO_PHAN = N'" & tb.Rows(i)("MS_BO_PHAN").ToString() & "'  " &
                                " AND MS_PT = N'" & tb.Rows(i)("MS_PT").ToString() & "'  " &
                                " AND MS_VI_TRI_PT = N'" & dtCT.Rows(j)("MS_VI_TRI_PT").ToString() & "'  "
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            Else

                                iSLHT = iSLHT - Convert.ToDouble(dtCT.Rows(j)("SL_KH").ToString())

                                If iSLHT < 0 Then
                                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & UserName &
                                            " SET SL_KH = " & iTSL - iSLCT &
                                            " WHERE MS_PHIEU_BAO_TRI = N'" & tb.Rows(i)("MS_PHIEU_BAO_TRI").ToString() & "'  " &
                                    " AND MS_CV = " & tb.Rows(i)("MS_CV").ToString() & "  " &
                                    " AND MS_BO_PHAN = N'" & tb.Rows(i)("MS_BO_PHAN").ToString() & "'  " &
                                    " AND MS_PT = N'" & tb.Rows(i)("MS_PT").ToString() & "'  " &
                                    " AND MS_VI_TRI_PT = N'" & dtCT.Rows(j)("MS_VI_TRI_PT").ToString() & "'  "
                                    iTSL = 0
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                End If
                                If iSLHT = 0 Then iTSL = 0
                                iSLCT = iSLCT + Convert.ToDouble(dtCT.Rows(j)("SL_KH").ToString())
                            End If
                        Next

                    End If
                End If
            Next

        End If
        Dim temp As String = "ChonVTPT_TEMP" & UserName
        Try

            ObjSystems.XoaTable(temp)

            str = "SELECT * INTO " + temp + " FROM " + sBTPT
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

            str = "DELETE " & sBTPT
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

            str = " INSERT " + sBTPT + " (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, TEN_PT, SL_KH, MS_PT_CHA, TON_TAI, TU_XUAT, VTPT) " &
                    " Select T.MS_PHIEU_BAO_TRI , MS_CV, T.MS_BO_PHAN, T.MS_PT, T3.TEN_PT, SUM(SL_KH) As SL_KH " &
                    " ,'' AS MS_PT_CHA " &
                    " , 1 AS TON_TAI, 0 AS TU_XUAT, 0 AS VTPT FROM " & sBTPTCT & " T " & "INNER Join PHIEU_BAO_TRI ON T.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI LEFT OUTER JOIN " &
                    " CAU_TRUC_THIET_BI ON T.MS_PT = CAU_TRUC_THIET_BI.MS_PT And " &
                    " PHIEU_BAO_TRI.MS_MAY = CAU_TRUC_THIET_BI.MS_MAY AND " &
                    " T.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN " &
                    " INNER JOIN IC_PHU_TUNG T3 On T3.MS_PT = T.MS_PT " &
                    "  GROUP BY  T.MS_PHIEU_BAO_TRI , MS_CV, T.MS_BO_PHAN, T.MS_PT, T3.TEN_PT, CAU_TRUC_THIET_BI.MS_PT"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

            str = "UPDATE " & sBTPT &
                " SET TON_TAI = T1.TON_TAI, MS_PT_CHA = T1.MS_PT_CHA, TU_XUAT = T1.TU_XUAT, VTPT = T1.VTPT " &
                " FROM " & sBTPT & " T INNER JOIN " & temp & " T1 ON T.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI AND T1.MS_PT = T.MS_PT AND T1.MS_BO_PHAN = T.MS_BO_PHAN AND T1.MS_CV = T.MS_CV"

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

        ObjSystems.XoaTable(temp)
        str = " DELETE T FROM " & sBTPTCT & " AS T INNER JOIN " &
              " dbo.IC_PHU_TUNG AS T1 ON T.MS_PT = T1.MS_PT INNER JOIN " &
              " dbo.LOAI_VT As T2 On T1.MS_LOAI_VT = T2.MS_LOAI_VT " &
              "	WHERE T2.VAT_TU = 1 "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        ucCongViecPBT.BindPhuTung()

    End Sub
    Private Sub LoadVersion()
        Dim sSql As String
        Dim dtTmp As New DataTable
        Try
            sSql = "SELECT TYPE" + LicID.ToString() + " FROM LIC_ID " &
                        " WHERE (ID_NAME <> N'" + ObjSystems.MaHoaDL("MnuPhieuBaoTri").ToString() + "') " &
                        " AND (ID_NAME LIKE N'" + ObjSystems.MaHoaDL("MnuPhieuBaoTri").ToString() + "%')"

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count = 0 Then
                TableLayoutPanel1.Visible = False
                Exit Sub
            Else
                For Each dr As DataRow In dtTmp.Rows
                    sSql = ObjSystems.GiaiMaDL(dr(0).ToString())
                    sSql = sSql.Replace("MnuPhieuBaoTri", "")
                    If Microsoft.VisualBasic.Strings.Left(Microsoft.VisualBasic.Strings.Right(sSql, 2), 1) <> LicID Then
                        For Each tb As DevExpress.XtraTab.XtraTabPage In TabPhieuBaoTri.TabPages
                            If tb.Name.ToUpper() = sSql.Substring(0, sSql.Length - 2).ToUpper() Then
                                TabPhieuBaoTri.TabPages.Remove(tb)
                            End If
                        Next
                    Else
                        If Microsoft.VisualBasic.Strings.Right(sSql, 1) <> 1 Then
                            For Each tb As DevExpress.XtraTab.XtraTabPage In TabPhieuBaoTri.TabPages
                                If tb.Name.ToUpper() = sSql.Substring(0, sSql.Length - 2).ToUpper() Then
                                    TabPhieuBaoTri.TabPages.Remove(tb)
                                End If
                            Next
                        End If
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub


    Sub EnableButton(ByVal chon As Boolean)
        BtnKhoaPBT.Enabled = chon
        If isAutoPBT1 Then
            btnAuto.Enabled = chon
        End If
        If isPrint1 Then
            btnPrint.Enabled = chon
        End If

        BtnDuyetPBT.Enabled = chon
        btnThem_1.Enabled = chon
        btnNHHTNTL.Enabled = chon
        btnSua_1.Enabled = chon
        btnXoa_1.Enabled = chon

        btnHThanhNT.Enabled = chon

        ucCongViecNS.btnThemsua.Enabled = chon
        ucCongViecNS.btnHThanhNS.Enabled = chon
        ucCongViecNS.btnTinhcuasobaotri.Enabled = chon
        ucCongViecNS.btnXoa.Enabled = chon

        ucCongViecPBT.btnBackLog.Enabled = chon
        ucCongViecPBT.btnSynDNXK.Enabled = chon
        ucCongViecPBT.btnTraKho.Enabled = chon
        ucCongViecPBT.btnThem.Enabled = chon
        'ucCongViecPBT.btnXoa.Enabled = chon

        ucDichVu.btnThemSuaDV.Enabled = chon
        ucDichVu.btnThemSuaCV.Enabled = chon
        ucDichVu.btnXoa.Enabled = chon

        BtnLockPBT.Enabled = chon
        btnSua5.Enabled = chon
        btnXoa5.Enabled = chon

        btnSua_1.Enabled = chon
        btnPhanBoLai.Enabled = chon
    End Sub
#Region "ptivate tab1"
    Sub BindDataHinh()

    End Sub
    Sub LoadCombo()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTINH_TRANG_PBT", TypeLanguage))
        cboTinhTrangPBT.DataSource = dtTable
        cboTinhTrangPBT.ValueMember = "STT"
        cboTinhTrangPBT.DisplayMember = "TEN_TINH_TRANG"

        ObjSystems.MLoadLookUpEdit(cboMAY, "GetMAY_PQ", "MS_MAY", "MS_MAY", lblMS_ThietBi.Text, True, UserName)


        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))

        cboMucUuTien1.Properties.DataSource = Nothing
        cboMucUuTien1.Properties.DataSource = dt
        cboMucUuTien1.Properties.DisplayMember = "TEN_UU_TIEN"
        cboMucUuTien1.Properties.ValueMember = "MS_UU_TIEN"
        cboMucUuTien1.Properties.PopulateColumns()
        cboMucUuTien1.Properties.Columns("MS_UU_TIEN").Visible = False
        cboMucUuTien1.Properties.Columns("TEN_UU_TIEN").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "TEN_UU_TIEN", TypeLanguage)
        cboMucUuTien1.Properties.Columns("SO_NGAY_PHAI_BD").Visible = False
        cboMucUuTien1.Properties.Columns("SO_NGAY_PHAI_KT").Visible = False
        cboMucUuTien1.Properties.Columns("TEN_TA").Visible = False



    End Sub
    Sub LoadcmbCNPBT()
        'nguoi lap

        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 2, UserName))
        cboNguoiLap1.Properties.DataSource = Nothing
        cboNguoiLap1.Properties.DataSource = dtTable
        cboNguoiLap1.Properties.DisplayMember = "HO_TEN_CONG_NHAN"
        cboNguoiLap1.Properties.ValueMember = "MS_CONG_NHAN"
        cboNguoiLap1.Properties.PopulateColumns()
        cboNguoiLap1.Properties.Columns("MS_CONG_NHAN").Visible = False
        cboNguoiLap1.Properties.Columns("HO_TEN_CONG_NHAN").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "HO_TEN_CONG_NHAN", TypeLanguage)
        cboNguoiLap1.EditValue = -1

        ' giam sat     
        dtTable = New DataTable()
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, UserName))
        cboGS_Vien1.Properties.DataSource = Nothing
        cboGS_Vien1.Properties.DataSource = dtTable
        cboGS_Vien1.Properties.DisplayMember = "HO_TEN_CONG_NHAN"
        cboGS_Vien1.Properties.ValueMember = "MS_CONG_NHAN"
        cboGS_Vien1.Properties.PopulateColumns()
        cboGS_Vien1.Properties.Columns("MS_CONG_NHAN").Visible = False
        cboGS_Vien1.Properties.Columns("HO_TEN_CONG_NHAN").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "HO_TEN_CONG_NHAN", TypeLanguage)
        cboGS_Vien1.EditValue = "-1"

        ' giam sat     
        dtTable = New DataTable()
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 1, UserName))
        cboNguoiNghiemThu.ValueMember = "MS_CONG_NHAN"
        cboNguoiNghiemThu.DisplayMember = "HO_TEN_CONG_NHAN"
        cboNguoiNghiemThu.DataSource = dtTable
        cboNguoiNghiemThu.DropDownWidth = 200

    End Sub

    Sub DropTable()
        ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_TMP" & UserName)
        ObjSystems.XoaTable("PHIEU_BAO_TRI_CV_PHU_TRO_TMP" & UserName)
        ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & UserName)
        ObjSystems.XoaTable(sBTPTCT)
    End Sub
    Sub DropTable4()
        ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_TMP1" & UserName)
        ObjSystems.XoaTable("PHIEU_BAO_TRI_CV_PHU_TRO_TMP1" & UserName)
        ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & UserName)
        ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & UserName)

    End Sub
    Sub RefreshData()
        txtMaSoPBT.Text = ""
        txtLydo_1.Text = ""

        txtUserNLap.Text = ""
        cboGS_Vien1.EditValue = "-1"
        txtGiohong.Text = ""
        txtNgayhong.Text = ""

        txtDenGioHong.Text = ""
        txtDenNgayHong.Text = ""


    End Sub

    Function isValidated() As Boolean
        If txtSoPhieuBaoTri1.Text.Trim() <> "" Then
            Dim sophieu As DataTable = New DataTable()
            sophieu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI WHERE SO_PHIEU_BAO_TRI = '" & txtSoPhieuBaoTri1.Text.Trim() & "' AND MS_PHIEU_BAO_TRI <> '" + txtMaSoPBT.Text + "' "))
            If (sophieu.Rows.Count > 0) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "Sophieubaotridatontai", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSoPhieuBaoTri1.Focus()
                Return False
            End If
        End If
        If cboMAY.EditValue = Nothing Then
            cboMAY.Focus()
            Return False
        End If

        Dim dtTmp As DataTable
        Dim sTmp As String = ""

        dtTmp = CType(cboMAY.Properties.DataSource, DataTable)
        Try
            sTmp = CType(dtTmp.Select("MSMAY = '" & cboMAY.EditValue & "'"), DataRow())(0)(1).ToString()
        Catch ex As Exception
            cboMAY.Focus()
            Return False
        End Try
        If cboLoaiBT.EditValue = Nothing Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgChonLoaiBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboLoaiBT.Focus()
            Return False
        End If

        If cboLoaiBT.EditValue.ToString() = "-1" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgChonLoaiBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboLoaiBT.Focus()
            Return False
        End If


        If cboMucUuTien1.EditValue = Nothing Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgChonMucUuTien", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboMucUuTien1.Focus()
            Return False
        End If

        If cboMucUuTien1.EditValue.ToString() = "-1" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgChonMucUuTien", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboMucUuTien1.Focus()
            Return False
        End If

        If cboNguoiLap1.EditValue = Nothing Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgChonNguoiLap", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboNguoiLap1.Focus()
            Return False
        End If

        If cboNguoiLap1.EditValue.ToString() = "-1" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgChonNguoiLap", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboNguoiLap1.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(txtLydo_1.Text.Trim()) = True Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNhapLyDo", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLydo_1.Focus()
            Return False
        End If

        Try
            Dim dt As New DataTable()
            dt.Columns.Add("NGAY_HONG")

            Dim dr As DataRow = dt.NewRow()
            dr("NGAY_HONG") = txtGiohong.Text
            dt.Rows.Add(dr)
            dr = dt.NewRow()
            dr("NGAY_HONG") = txtNgayhong.Text
            dt.Rows.Add(dr)
            dr = dt.NewRow()
            dr("NGAY_HONG") = txtDenGioHong.Text
            dt.Rows.Add(dr)
            dr = dt.NewRow()
            dr("NGAY_HONG") = txtDenNgayHong.Text
            dt.Rows.Add(dr)

            Dim count As Integer = 0
            For Each dr1 In dt.Rows
                Try
                    Convert.ToDateTime(dr1("NGAY_HONG").ToString())
                Catch ex As Exception
                    count = count + 1
                End Try
            Next


            If (count <> 4 And count <> 0) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNhapNgayGioHongFull", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtGiohong.Focus()
                Return False
            End If
        Catch ex As Exception

        End Try
        If Date.Parse(dtNgayLap1.EditValue) > Now() Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                        "MsgNgayLap", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then

                dtNgayLap1.Focus()
                Return False
            End If
        End If

        If dtGioLap.Text <> "  :" Then
            If Not IsDate(dtGioLap.Text) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgGioLap", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtGioLap.Text = "  :"
                dtGioLap.Focus()
                Return False
            End If
        End If
        If dtNgayKTKH1.DateTime.Date < Date.Parse(dtNgayBDKH1.DateTime.Date) Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayKTKH", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtNgayKTKH1.Focus()
            Return False
        End If

        If txtNgayhong.Text <> "  /  /" Then
            If Not IsDate(txtNgayhong.Text) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNgayhong.Text = "  /  /"
                txtNgayhong.Focus()
                Return False

            ElseIf Date.Parse(txtNgayhong.Text) < Date.Parse("01/01/1900") Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNgayhong.Text = "  /  /"
                txtNgayhong.Focus()
                Return False
            Else
                If Date.Parse(txtNgayhong.Text) > Date.Parse(dtNgayLap1.EditValue) Then ' Date.Parse(dtNgayLap.Value) Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                                "MsgNgayHongLonHonHienTai1", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then
                        txtNgayhong.Text = "  /  /"
                        txtNgayhong.Focus()
                        Return False
                    End If
                Else
                    Try
                        If Date.Parse(txtDenNgayHong.Text) < Date.Parse(txtNgayhong.Text) Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgTuNgayHongLonHonDenNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtNgayhong.Text = "  /  /"
                            txtNgayhong.Focus()
                            Return False
                        End If
                    Catch ex As Exception
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgTuNgayHongLonHonDenNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End Try
                End If
            End If
        End If
        If txtGiohong.Text <> "  :" Then
            If Not IsDate(txtGiohong.Text) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgGioHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtGiohong.Text = "  :"
                txtGiohong.Focus()
                Return False
            End If
        End If

        If txtDenNgayHong.Text <> "  /  /" Then
            If Not IsDate(txtDenNgayHong.Text) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgDenNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDenNgayHong.Text = "  /  /"

                txtDenNgayHong.Focus()
                Return False
            ElseIf Date.Parse(txtDenNgayHong.Text) < Date.Parse("01/01/1900") Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgDenNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDenNgayHong.Text = "  /  /"
                txtDenNgayHong.Focus()
                Return False
            Else
                If Date.Parse(txtDenNgayHong.Text) > Date.Parse(dtNgayLap1.EditValue) Then ' Date.Parse(dtNgayLap.Value) Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                                "MsgDenNgayHongLonHonNgayLap", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then
                        txtDenNgayHong.Text = "  /  /"
                        txtDenNgayHong.Focus()
                        Return False
                    End If
                Else
                    Try

                        If Date.Parse(txtDenNgayHong.Text) < Date.Parse(txtNgayhong.Text) Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgDenNgayHongNhoHonTuNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtDenNgayHong.Text = "  /  /"
                            txtDenNgayHong.Focus()
                            Return False
                        End If
                    Catch ex As Exception
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgDenNgayHongNhoHonTuNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End Try
                End If
            End If
        End If
        If txtDenGioHong.Text <> "  :" Then
            If Not IsDate(txtDenGioHong.Text) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgDenGioHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDenGioHong.Text = "  :"
                txtDenGioHong.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Sub EnableControl(ByVal chon As Boolean)
        txtSoPhieuBaoTri1.Enabled = chon
        cboMAY.Enabled = chon
        btnChonMay.Enabled = chon
        cboNguyenNhan.Enabled = chon
        cboLoaiBT.Enabled = chon
        dtNgayLap1.Enabled = chon
        cboCa.Enabled = chon
        'txtLydo_1.Enabled = chon
        txtLydo_1.Properties.ReadOnly = Not chon
        If chon Then
            Commons.Modules.ObjSystems.MAutoCompleteTextEdit(txtLydo_1, "SELECT DISTINCT LY_DO_BT FROM dbo.PHIEU_BAO_TRI ORDER BY LY_DO_BT", "LY_DO_BT")
        Else
            txtLydo_1.MaskBox.AutoCompleteCustomSource = Nothing
        End If


        cboMucUuTien1.Enabled = chon

        dtNgayBDKH1.Enabled = chon
        dtNgayKTKH1.Enabled = chon
        cboNguoiLap1.Enabled = chon

        txtUserNLap.Enabled = chon
        cboGS_Vien1.Enabled = chon
        dtKTTT1.Enabled = chon
        dtpNgayCNBDKH1.Enabled = False

        dtDenKTTT1.Enabled = chon
        txtTimKiemPBT.Properties.Enabled = Not chon
        btnLocPBT.Enabled = Not chon

        txtDenGioHong.Enabled = chon
        txtDenNgayHong.Enabled = chon
        txtGiohong.Enabled = chon
        txtNgayhong.Enabled = chon
        dtGioLap.Enabled = chon

        If (chon = False) Then
            dtGioLap.BackColor = ColorTranslator.FromHtml("#E3EFFF")
            dtGioLap.ForeColor = ColorTranslator.FromHtml("#93ADC6")
            txtDenGioHong.BackColor = ColorTranslator.FromHtml("#E3EFFF")
            txtDenGioHong.ForeColor = ColorTranslator.FromHtml("#93ADC6")
            txtDenNgayHong.BackColor = ColorTranslator.FromHtml("#E3EFFF")
            txtDenNgayHong.ForeColor = ColorTranslator.FromHtml("#93ADC6")
            txtNgayhong.BackColor = ColorTranslator.FromHtml("#E3EFFF")
            txtNgayhong.ForeColor = ColorTranslator.FromHtml("#93ADC6")
            txtGiohong.BackColor = ColorTranslator.FromHtml("#E3EFFF")
            txtGiohong.ForeColor = ColorTranslator.FromHtml("#93ADC6")
        Else
            dtGioLap.BackColor = Color.White
            dtGioLap.ForeColor = Color.Black
            txtDenGioHong.BackColor = Color.White
            txtDenGioHong.ForeColor = Color.Black
            txtDenNgayHong.BackColor = Color.White
            txtDenNgayHong.ForeColor = Color.Black
            txtNgayhong.BackColor = Color.White
            txtNgayhong.ForeColor = Color.Black
            txtGiohong.BackColor = Color.White
            txtGiohong.ForeColor = Color.Black
        End If
    End Sub
    Sub ShowData()
        Try

            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetLoaiBaoTriHinhThuc", cboMAY.EditValue))

            cboLoaiBT.Properties.DataSource = Nothing
            cboLoaiBT.Properties.DataSource = dt
            cboLoaiBT.Properties.DisplayMember = "TEN_LOAI_BT"
            cboLoaiBT.Properties.ValueMember = "MS_LOAI_BT"
            cboLoaiBT.Properties.PopulateColumns()
            cboLoaiBT.Properties.Columns("MS_LOAI_BT").Visible = False
            cboLoaiBT.Properties.Columns("HU_HONG").Visible = False
            cboLoaiBT.Properties.Columns("PHONG_NGUA").Visible = False
            cboLoaiBT.Properties.Columns("TEN_LOAI_BT").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "TEN_LOAI_BT", TypeLanguage)

            txtMaSoPBT.Text = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_PHIEU_BAO_TRI")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_PHIEU_BAO_TRI"))

            txtSoPhieuBaoTri1.Text = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "SO_PHIEU_BAO_TRI")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "SO_PHIEU_BAO_TRI"))

            ''nếu bàn giao bằng 1 thì enable bàn giao = false
            If Modules.sPrivate = "GREENFEED" Then
                Try
                    If Not String.IsNullOrEmpty(txtMaSoPBT.Text) Then
                        Dim bBanGiao As Boolean = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 ISNULL(BAN_GIAO,0) FROM dbo.PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI ='" & txtMaSoPBT.Text & "'"))
                        btnBanGiao.Enabled = Not bBanGiao
                    Else
                        btnBanGiao.Enabled = False
                    End If
                Catch
                    btnBanGiao.Enabled = False
                End Try
            End If
            cboMAY.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_MAY")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_MAY"))
            'cboMAY.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_MAY")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_MAY"))
            If cboMAY.Text = "" Then
                ObjSystems.MLoadLookUpEdit(cboMAY, "GetMAY_PQ", "MS_MAY", "MS_MAY", lblMS_ThietBi.Text, True, UserName)
                cboMAY.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_MAY")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_MAY"))
            End If

            cboLoaiBT.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_LOAI_BT")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_LOAI_BT"))


            cboTinhTrangPBT.SelectedValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "TINH_TRANG_PBT")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "TINH_TRANG_PBT"))

            txtLydo_1.Text = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "LY_DO_BT")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "LY_DO_BT"))

            Dim sTooltip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
            ' Create an object to initialize the SuperToolTip.
            Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs
            args.Title.Text = lblLyDo.Text
            args.Contents.Text = txtLydo_1.Text
            sTooltip2.Setup(args)


            txtLydo_1.SuperTip = sTooltip2

            cboMucUuTien1.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_UU_TIEN")) = True, "-1", grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_UU_TIEN"))

            cboNguoiLap1.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGUOI_LAP")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "NGUOI_LAP"))
            txtUserNLap.Text = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "USERNAME_NGUOI_LAP")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "USERNAME_NGUOI_LAP"))
            If IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGUOI_GIAM_SAT")) Then
                cboGS_Vien1.EditValue = "-1"
            Else
                cboGS_Vien1.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGUOI_GIAM_SAT")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "NGUOI_GIAM_SAT"))
            End If
            If IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_NGUYEN_NHAN")) Then
                cboNguyenNhan.EditValue = -1
            Else
                cboNguyenNhan.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_NGUYEN_NHAN")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "MS_NGUYEN_NHAN"))
            End If
            dtNgayLap1.DateTime = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGAY_LAP")) = True, "", Convert.ToDateTime(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGAY_LAP")).ToString("dd/MM/yyyy"))
            dtGioLap.Text = Format(If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "GIO_LAP")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "GIO_LAP").ToString()), "Long time")

            dtNgayBDKH1.DateTime = Convert.ToDateTime(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGAY_BD_KH")).ToString("dd/MM/yyyy")
            dtNgayKTKH1.DateTime = Convert.ToDateTime(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGAY_KT_KH")).ToString("dd/MM/yyyy")
            Try
                If (String.IsNullOrEmpty(grvDanhSach_1.GetRowCellValue(intRowPBT, "UPDATE_NGAY_CUOI"))) Then
                    dtpNgayCNBDKH1.EditValue = ""
                Else
                    dtpNgayCNBDKH1.DateTime = Convert.ToDateTime(grvDanhSach_1.GetRowCellValue(intRowPBT, "UPDATE_NGAY_CUOI")).ToString("dd/MM/yyyy")
                End If
            Catch
                dtpNgayCNBDKH1.EditValue = ""
            End Try
            txtGiohong.Text = Format(If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "GIO_HONG")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "GIO_HONG").ToString()), "Long time")
            txtNgayhong.Text = Format(If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "NGAY_HONG")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "NGAY_HONG").ToString()), "Short date")
            txtDenGioHong.Text = Format(If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "DEN_GIO_HONG")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "DEN_GIO_HONG").ToString()), "Long time")
            txtDenNgayHong.Text = Format(If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "DEN_NGAY_HONG")) = True, "", grvDanhSach_1.GetRowCellValue(intRowPBT, "DEN_NGAY_HONG").ToString()), "Short date")
            Try
                cboCa.EditValue = If(IsDBNull(grvDanhSach_1.GetRowCellValue(intRowPBT, "STT_CA")) = True, -1, Convert.ToInt32(grvDanhSach_1.GetRowCellValue(intRowPBT, "STT_CA").ToString()))
            Catch ex As Exception
                cboCa.EditValue = -1
            End Try
            BtnKhoaPBT.Enabled = True
            If cboTinhTrangPBT.SelectedValue = 5 Then
                BtnKhoaPBT.Enabled = False
                btnAuto.Enabled = False
                TinhtrangPBT_Lock(False)
            Else
                BtnKhoaPBT.Enabled = True
                If isAutoPBT1 Then
                    btnAuto.Enabled = True
                End If
                If isPrint1 Then
                    btnPrint.Enabled = True
                End If
                If Not PermisString.Equals("Read only") Then TinhtrangPBT_Lock(True)
                If cboTinhTrangPBT.SelectedValue = 2 Then
                    BtnDuyetPBT.Enabled = False
                ElseIf cboTinhTrangPBT.SelectedValue = 3 Then
                    BtnDuyetPBT.Enabled = False
                ElseIf cboTinhTrangPBT.SelectedValue = 4 Then
                    BtnDuyetPBT.Enabled = False
                End If
                If cboTinhTrangPBT.SelectedValue = 4 Then
                    BtnKhoaPBT.Enabled = True
                Else
                    BtnKhoaPBT.Enabled = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub BindData()
        If SQLString = "0LOAD" Then Exit Sub
        If bLoad = True Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Try
            RefreshData()
            Dim iNT As Integer
            iNT = 0
            If optNTHT.SelectedIndex = 1 Then
                iNT = 1
            End If
            If optNTHT.SelectedIndex = 2 Then
                iNT = 2
            End If
            Dim img As Byte() = ObjSystems.MImageToByteArray(Global.Commons.My.Resources.Resources.attachment)
            dtPBT = New DataTable
            dtPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_PHIEU_BAO_TRI_NEW", Modules.UserName, dtTNgay_1.DateTime.ToString("MM-dd-yyyy"),
                    dtDNgay_1.DateTime.ToString("MM-dd-yyyy"), iNT, sLoaiMay, sNhomMay, sMsMay, sDiaDiem,
                    iDayChuyen, iLoaiBaoTri, sNguoiLap, sNGSat, iNNhan, img, TypeLanguage))
            'dtPBT.Columns("USERNAME_BG").ReadOnly =False
            Try
                If (grvDanhSach_1.Columns.Count > 0) Then
                    If grvDanhSach_1.Columns("TEN_MAY").Width < 50 Then
                        ObjSystems.MLoadXtraGrid(grdDanhSach_1, grvDanhSach_1, dtPBT, False, False, False, True)
                    Else
                        ObjSystems.MLoadXtraGrid(grdDanhSach_1, grvDanhSach_1, dtPBT, False, False, False, False)
                    End If
                Else
                    ObjSystems.MLoadXtraGrid(grdDanhSach_1, grvDanhSach_1, dtPBT, False, True, False, True)
                    Dim imgTaiLieu As RepositoryItemPictureEdit = New RepositoryItemPictureEdit()
                    imgTaiLieu.NullText = " "
                    grvDanhSach_1.Columns("TAI_LIEU").ColumnEdit = imgTaiLieu
                    grvDanhSach_1.Columns("TAI_LIEU").OptionsColumn.AllowEdit = False
                    grvDanhSach_1.Columns("TAI_LIEU").OptionsColumn.AllowFocus = False
                    grvDanhSach_1.Columns("TAI_LIEU").OptionsColumn.AllowSize = False

                    Dim rkSubKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regPBT, False)
                    If rkSubKey Is Nothing Then
                        ObjSystems.MLoadNNXtraGrid(grvDanhSach_1, Me.Name)
                        TaoLuoiPBT()
                        grdDanhSach_1.MainView.SaveLayoutToRegistry(regPBT)
                    Else
                        Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
                        opts.Columns.StoreAllOptions = True
                        grdDanhSach_1.MainView.RestoreLayoutFromRegistry(regPBT)
                    End If
                End If
            Catch ex As Exception
            End Try

            If grvDanhSach_1.RowCount = 0 Then
                TinhtrangPBT_Lock(False)
                BtnDuyetPBT.Enabled = False
                BtnKhoaPBT.Enabled = False
                btnAuto.Enabled = False
                btnThem_1.Enabled = True
                btnNHHTNTL.Enabled = True
            Else
                If cboTinhTrangPBT.SelectedValue = 5 Then
                    TinhtrangPBT_Lock(False)
                Else
                    TinhtrangPBT_Lock(True)
                    If cboTinhTrangPBT.SelectedValue = 3 Or cboTinhTrangPBT.SelectedValue = 2 Or cboTinhTrangPBT.SelectedValue = 4 Then
                        BtnDuyetPBT.Enabled = False
                    End If
                    BtnKhoaPBT.Enabled = True
                    If cboTinhTrangPBT.SelectedValue = 3 Or cboTinhTrangPBT.SelectedValue = 2 Then
                        BtnKhoaPBT.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TaoLuoiPBT()
#Region "Visible cột"
        grvDanhSach_1.Columns("HO_TEN").OptionsColumn.FixedWidth = True
        grvDanhSach_1.Columns("MS_PHIEU_BAO_TRI").OptionsColumn.FixedWidth = True
        grvDanhSach_1.Columns("TEN_N_XUONG").OptionsColumn.FixedWidth = True
        grvDanhSach_1.Columns("TAI_LIEU").Width = 45
        grvDanhSach_1.Columns("MS_YEU_CAU").Width = 150
        grvDanhSach_1.Columns("TEN_TIENG_VIET").Visible = False
        grvDanhSach_1.Columns("TINH_TRANG_PBT").Visible = False
        grvDanhSach_1.Columns("MS_LOAI_BT").Visible = False
        grvDanhSach_1.Columns("GIO_LAP").Visible = False
        grvDanhSach_1.Columns("LY_DO_BT").Visible = False
        grvDanhSach_1.Columns("MS_UU_TIEN").Visible = False
        grvDanhSach_1.Columns("NGAY_KT_KH").Visible = False
        grvDanhSach_1.Columns("USERNAME_NGUOI_LAP").Visible = False
        grvDanhSach_1.Columns("NGUOI_GIAM_SAT").Visible = False
        grvDanhSach_1.Columns("GIO_HONG").Visible = False
        grvDanhSach_1.Columns("NGAY_HONG").Visible = False
        grvDanhSach_1.Columns("DEN_GIO_HONG").Visible = False
        grvDanhSach_1.Columns("DEN_NGAY_HONG").Visible = False
        grvDanhSach_1.Columns("NGUOI_LAP").Visible = False
        grvDanhSach_1.Columns("HO_TEN").Visible = True
        grvDanhSach_1.Columns("MS_N_XUONG").Visible = False
        grvDanhSach_1.Columns("MS_LOAI_MAY").Visible = False
        grvDanhSach_1.Columns("MS_NHOM_MAY").Visible = False
        grvDanhSach_1.Columns("TINH_TRANG_PBT").Visible = False
        grvDanhSach_1.Columns("MS_HT").Visible = False
        grvDanhSach_1.Columns("MS_NGUYEN_NHAN").Visible = False
        Dim index As Integer = grvDanhSach_1.Columns("NGAY_LAP").VisibleIndex
        grvDanhSach_1.Columns("NGAY_LAP").VisibleIndex = grvDanhSach_1.Columns("NGAY_BD_KH").VisibleIndex
        grvDanhSach_1.Columns("NGAY_BD_KH").VisibleIndex = index
        If (menuTinhTrangPBTCT.Items.Count > 0) Then
            grvDanhSach_1.Columns("TEN_TIENG_VIET").Visible = True

        End If
        grvDanhSach_1.Columns("STT_CA").Visible = False
        grvDanhSach_1.Columns("UPDATE_NGAY_CUOI").Visible = False
        grvDanhSach_1.Columns("LY_DO_TT_PBT_CT").Visible = False


        If Privates() = "BARIA" Then
            index = grvDanhSach_1.Columns("TEN_TIENG_VIET").VisibleIndex
            grvDanhSach_1.Columns("TEN_TIENG_VIET").VisibleIndex = grvDanhSach_1.Columns("NGAY_BD_KH").VisibleIndex
            grvDanhSach_1.Columns("NGAY_BD_KH").VisibleIndex = index

            index = grvDanhSach_1.Columns("TEN_N_XUONG").VisibleIndex
            grvDanhSach_1.Columns("TEN_N_XUONG").VisibleIndex = grvDanhSach_1.Columns("LY_DO_TT_PBT_CT").VisibleIndex
            grvDanhSach_1.Columns("LY_DO_TT_PBT_CT").VisibleIndex = index

            grvDanhSach_1.Columns("SO_PHIEU_BAO_TRI").Visible = False
            grvDanhSach_1.Columns("MS_MAY").Visible = False
            grvDanhSach_1.Columns("DHX").Visible = False
            grvDanhSach_1.Columns("LY_DO_TT_PBT_CT").Visible = True
            grvDanhSach_1.Columns("LY_DO_TT_PBT_CT").Width = 150
        End If
        If Privates() = "VECO" Then
            grvDanhSach_1.Columns("DHX").Visible = False
        End If
#End Region
    End Sub
    Private Sub grvDanhSach_1_ShowGridMenu(sender As Object, e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs) Handles grvDanhSach_1.ShowGridMenu
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then Exit Sub
        Try
            Dim headerMenu As DevExpress.XtraGrid.Menu.GridViewMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewMenu)
            'menu reset grid resert
            Dim menuItem As New DevExpress.Utils.Menu.DXMenuItem("Reset Grid", New EventHandler(AddressOf ResertGrid))
            menuItem.BeginGroup = True
            menuItem.Tag = e.Menu
            headerMenu.Items.Add(menuItem)
            'menu Save grid
            Dim menuSave As New DevExpress.Utils.Menu.DXMenuItem("Save Grid", New EventHandler(AddressOf SaveGrid))
            'menuSave.BeginGroup = True
            menuSave.Tag = e.Menu
            headerMenu.Items.Add(menuSave)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveGrid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grdDanhSach_1.MainView.SaveLayoutToRegistry(regPBT)
    End Sub

    Private Sub ResertGrid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To grvDanhSach_1.Columns.Count - 1
            Try
                grvDanhSach_1.Columns(i).Visible = True
            Catch ex As Exception

            End Try
        Next
        Try
            Dim rkSubKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("DevExpress\XtraGrid\Layouts", True)
            rkSubKey.DeleteSubKeyTree("GridPBT")
            grdDanhSach_1.DataSource = Nothing
            grvDanhSach_1.Columns.Clear()
            BindData()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnXemtailieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemtailieu.Click
        Try
            Dim frm As ReportMain.frmPBTTaiLieu = New ReportMain.frmPBTTaiLieu()
            ReportMain.frmPBTTaiLieu.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
            frm.ShowDialog()
            BindData()
            intRowPBT = grvDanhSach_1.FocusedRowHandle
            ShowData()
        Catch ex As Exception

        End Try
    End Sub
    Sub TinhtrangPBT_Lock(ByVal chon As Boolean)
        btnSua_1.Enabled = chon
        btnThem_1.Enabled = chon
        'btnThem_2.Enabled = chon
        'BT_BACKLOG.Enabled = chon
        'btnXoa_2.Enabled = chon
        BtnXemtailieu.Enabled = chon
        BtnDuyetPBT.Enabled = chon
        BtnKhoaPBT.Enabled = chon

        If isAutoPBT1 Then
            btnAuto.Enabled = chon
        End If
        If isPrint1 Then
            btnPrint.Enabled = chon
        End If
        If ObjSystems.MGetQuyenChucNang(UserName, 55) Then
            If (grvDanhSach_1.RowCount > 0) Then
                btnUnLock.Visible = Not chon
                btnUnLock.BringToFront()
            End If
        Else
            BtnKhoaPBT.Visible = True
            btnUnLock.Visible = False
        End If
        If PermisString.Equals("Read only") Then
            BtnKhoaPBT.Visible = False
            btnUnLock.Visible = False
        End If


    End Sub
    Sub HideButton1(ByVal flg As Boolean)
        btnXoa_1.Visible = flg
        btnIn_1.Visible = flg
        btnThem_1.Visible = flg
        btnNHHTNTL.Visible = flg
        btnTGNgungMay.Visible = flg
        btnSua_1.Visible = flg
        btnThoat_1.Visible = flg
        BtnKhoaPBT.Visible = flg
        ''Nếu là greenfeed thì bật lên
        If Modules.sPrivate = "GREENFEED" Then btnBanGiao.Visible = flg Else btnBanGiao.Visible = False

        If isAutoPBT1 Then
            btnAuto.Visible = flg
        End If
        If isPrint1 Then
            btnPrint.Visible = flg
        End If
        btnInPBT.Visible = flg
        BtnDuyetPBT.Visible = flg
        BtnXemtailieu.Visible = flg
        optNTHT.Enabled = flg
        dtTNgay_1.Properties.Enabled = flg
        dtDNgay_1.Properties.Enabled = flg


    End Sub
    Dim btnMucUuTienFlag = False

    Sub VisibleButtonGhi(ByVal chon As Boolean)
        btnGhi_1.Visible = chon
        btnKhongGhi_1.Visible = chon

        If (btnMucUuTienFlag = True) Then
            btnMucUuTien.Visible = chon
        Else
            btnMucUuTien.Visible = False
        End If

        grdDanhSach_1.Enabled = Not chon
    End Sub
#End Region
#Region "Thong Tin sua phieu bao tri dang soan"
    'MS_PHIEU_BAO_TRI   cu 
    Private vMs_PBT As String = ""
    Private vEvent As String = "N"
    Private vThangBDKH As DateTime

#End Region
#Region "event tab1"

    Private Sub btnSua_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua_1.Click
        If grvDanhSach_1.RowCount = 0 Then
            Exit Sub
        End If
        Dim str As String = ""
        If CheckNghiemThuPBT() Then Exit Sub
        bThem = 1
        bPBT = False
        EnableControl(True)
        HideButton1(False)
        btnGhi_1.Visible = False
        VisibleButtonGhi(True)
        Dim iPNgua As Boolean = False
        Try
            iPNgua = Boolean.Parse(cboLoaiBT.GetColumnValue("PHONG_NGUA").ToString())
        Catch ex As Exception
            iPNgua = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT PHONG_NGUA FROM HINH_THUC_BAO_TRI T1 INNER JOIN LOAI_BAO_TRI T2 ON T1.MS_HT_BT = T2.MS_HT_BT WHERE MS_LOAI_BT = " & cboLoaiBT.EditValue.ToString)
        End Try

        If (iPNgua = False) Then
            dtpNgayCNBDKH1.Enabled = False
        Else
            dtpNgayCNBDKH1.Enabled = True
        End If

        str = "Select MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "'" &
                   " UNION SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "'" &
                   " UNION SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "'"
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim cTong As Boolean = False
        While objReader.Read
            If objReader.Item("MS_PHIEU_BAO_TRI").ToString <> "" Then
                cTong = True
                Exit While
            End If
        End While
        objReader.Close()
        If cTong Then
            cboMAY.Enabled = False
            btnChonMay.Enabled = False
            cboLoaiBT.Enabled = False
        Else
            cboMAY.Enabled = True
            btnChonMay.Enabled = True
            cboLoaiBT.Enabled = True
        End If
        Try
            str = "DROP TABLE TAM12" & UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "create TABLE [dbo].TAM12" & UserName & " (STT INT,DUONG_DAN NVARCHAR(255),TEN_TAI_LIEU NVARCHAR(255),STT_YC_NSD INT,STT_GSTT INT,HINH NVARCHAR(150))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "SELECT DUONG_DAN FROM PHIEU_BAO_TRI_HINH WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        intSTT = ObjSystems.LaySTTChoTaiLieu(str)
        LoadcmbCNPBT()
        ShowData()
        cboMAY.Focus()
        dtNgayBDKH1.Enabled = False
        If cboTinhTrangPBT.SelectedValue = 1 Then
            vMs_PBT = txtMaSoPBT.Text.Trim
            vEvent = "E"
            vThangBDKH = dtNgayBDKH1.DateTime.Date
            dtNgayBDKH1.Enabled = True
        Else
            vMs_PBT = ""
            vEvent = "N"
            vThangBDKH = New DateTime
            dtNgayBDKH1.Enabled = True
            dtNgayLap1.Enabled = False
        End If
        bThemSua = False
    End Sub
    Private Sub BtnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        HideButton1(True)
        btnGhi_1.Visible = False
        VisibleButtonGhi(False)
        intTabChanged = -1
    End Sub
    Private Sub btnThem_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem_1.Click
        Try
            bThem = 1
            bPBT = True
            LoadcmbCNPBT()
            cboTinhTrangPBT.SelectedValue = 1
            dtGioLap.Text = Format(Now(), "Long time")
            dtNgayLap1.DateTime = Now()
            dtNgayBDKH1.DateTime = Now()
            dtNgayKTKH1.DateTime = dtNgayLap1.DateTime.AddMinutes(2)
            dtpNgayCNBDKH1.EditValue = ""
            HideButton1(False)
            btnGhi_1.Visible = False
            VisibleButtonGhi(True)
            RefreshData()
            EnableControl(True)
            bThem = 1
            cboMAY.EditValue = "-1"
            cboLoaiBT.EditValue = -1
            cboMucUuTien1.EditValue = "-1"
            cboNguoiLap1.EditValue = -1
            cboNguyenNhan.EditValue = -1
            Dim str As String = ""
            Try
                str = "DROP TABLE TAM12" & UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception

            End Try
            str = "create TABLE [dbo].TAM12" & UserName & " (STT INT,DUONG_DAN NVARCHAR(255),TEN_TAI_LIEU NVARCHAR(255),STT_YC_NSD INT,STT_GSTT INT,HINH NVARCHAR(150))"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "SELECT DUONG_DAN FROM PHIEU_BAO_TRI_HINH WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            intSTT = ObjSystems.LaySTTChoTaiLieu(str)
            txtMaSoPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI()
            txtUserNLap.Text = UserName
            txtSoPhieuBaoTri1.Text = String.Empty
            BindDataHinh()

            bThemSua = True
            If iDefault = 1 Then
                txtSoPhieuBaoTri1.Text = txtMaSoPBT.Text
            End If
            If iDefault = 2 Then
                txtSoPhieuBaoTri1.Text = txtMaSoPBT.Text
                txtSoPhieuBaoTri1.Enabled = False
            End If


            dtDenKTTT1.EditValue = Now.Date
            dtKTTT1.EditValue = Now.Date

            txtGiohong.Text = "  :"
            txtDenNgayHong.Text = "  /  /"
            txtDenGioHong.Text = "  :"
            txtNgayhong.Text = "  /  /"

            str = "SELECT MS_CONG_NHAN FROM USERS WHERE USERNAME = '" & UserName & "'"
            Dim dtTmp As New DataTable
            Try
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                Try
                    cboNguoiLap1.EditValue = Convert.ToInt32(dtTmp.Rows(0)(0).ToString())
                Catch ex As Exception
                    cboNguoiLap1.EditValue = dtTmp.Rows(0)(0).ToString()
                End Try
            Catch ex As Exception

            End Try
            txtSoPhieuBaoTri1.Focus()

            vEvent = ""
            cboMucUuTien1.EditValue = cboMAY.GetColumnValue("MUC_UU_TIEN")
        Catch ex As Exception
        End Try
    End Sub
    Function isOk() As Boolean
        If (IsAuto()) Then
            If (IsDinhKy()) Then
                Return True
            End If
        End If
        Return False
    End Function
    Private Sub btnGhi_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi_1.Click
        Try
            If Not isValidated() Then Exit Sub
            If dtGioLap.Text = "  :" And Not IsDate(dtGioLap.Text) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgGio", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtGioLap.Text = "  :"
                dtGioLap.Focus()
                Exit Sub
            End If
            If txtGiohong.Text <> "  :" Or txtDenGioHong.Text <> "  :" Then
                If txtGiohong.Text = "  :" And Not IsDate(txtGiohong.Text) Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgGioHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtGiohong.Text = "  :"
                    txtGiohong.Focus()
                    Exit Sub
                End If
                If txtNgayhong.Text = "  /  /" And Not IsDate(txtNgayhong.Text) Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNgayhong.Text = "  /  /"
                    txtNgayhong.Focus()
                    Exit Sub
                End If
                If txtDenGioHong.Text = "  :" And Not IsDate(txtDenGioHong.Text) Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgDenGioHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDenGioHong.Text = "  :"
                    txtDenGioHong.Focus()
                    Exit Sub
                End If
                If txtDenNgayHong.Text = "  /  /" And Not IsDate(txtDenNgayHong.Text) Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgDenNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDenNgayHong.Text = "  /  /"
                    txtDenNgayHong.Focus()
                    Exit Sub
                End If
                If Convert.ToDateTime(txtNgayhong.Text + " " + txtGiohong.Text) > Convert.ToDateTime(txtDenNgayHong.Text + " " + txtDenGioHong.Text) Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgTuNgayHongLonHonDenNgayHong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDenNgayHong.Focus()
                    Exit Sub
                End If

            End If

            If dtNgayBDKH1.DateTime > dtNgayKTKH1.DateTime Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayKTKH", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtNgayKTKH1.Focus()
                Exit Sub
            End If
            '-----------------------------------------
            Dim iPNgua As Boolean = False
            Try
                iPNgua = Boolean.Parse(cboLoaiBT.GetColumnValue("PHONG_NGUA").ToString())
            Catch ex As Exception
                iPNgua = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT PHONG_NGUA FROM HINH_THUC_BAO_TRI T1 INNER JOIN LOAI_BAO_TRI T2 ON T1.MS_HT_BT = T2.MS_HT_BT WHERE MS_LOAI_BT = " & cboLoaiBT.EditValue.ToString)
            End Try

            If (iPNgua) Then
                If (bPBT) Then
                    If dtpNgayCNBDKH1.DateTime.Date < dtNgayBDKH1.DateTime.Date Then
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayCNBDKH", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtpNgayCNBDKH1.Focus()
                        Exit Sub
                    End If

                    If dtpNgayCNBDKH1.DateTime.Date > dtNgayKTKH1.DateTime.Date Then
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayCNBDKH", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtpNgayCNBDKH1.Focus()
                        Exit Sub
                    End If
                Else
                    Dim str1 As String = "SELECT ISNULL(MAX(NGAY_HOAN_THANH), '') AS NGAY_HOAN_THANH  FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' GROUP BY MS_PHIEU_BAO_TRI "
                    Dim dt1 As New DataTable()
                    dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str1))
                    Dim ngayHoanThanh As DateTime = Convert.ToDateTime("1900/01/01 00:00:00")
                    Try
                        ngayHoanThanh = Convert.ToDateTime(dt1.Rows(0)("NGAY_HOAN_THANH").ToString, New CultureInfo("vi-vn")).ToString("yyy/MM/dd")
                    Catch
                    End Try
                    If (dt1.Rows.Count = 1 And Not ngayHoanThanh.Date.ToString("yyyy/MM/dd").Equals("1900/01/01")) Then
                        If dtpNgayCNBDKH1.DateTime.Date < dtNgayBDKH1.DateTime.Date Or dtpNgayCNBDKH1.DateTime.Date > ngayHoanThanh.Date Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayCNBDKH1", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            dtpNgayCNBDKH1.Focus()
                            Exit Sub
                        End If
                    Else
                        If dtpNgayCNBDKH1.DateTime.Date < dtNgayBDKH1.DateTime.Date Or dtpNgayCNBDKH1.DateTime.Date > dtNgayKTKH1.DateTime.Date Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayCNBDKH", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            dtpNgayCNBDKH1.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            '-----------------------------------------
            If bPBT Then
                Dim sMSPBTText As String
                Dim dNgayTest As Date
                Dim sTmp As String
                Try
                    sTmp = txtMaSoPBT.Text.Substring(0, txtMaSoPBT.Text.Length - 12)
                    sTmp = txtMaSoPBT.Text.Replace(sTmp, "")
                    dNgayTest = Convert.ToDateTime(dtNgayBDKH1.DateTime.Day.ToString() + "/" + sTmp.Substring(4, 2) + "/" + sTmp.Substring(0, 4))
                Catch ex As Exception
                End Try

                If dNgayTest <> dtNgayBDKH1.DateTime.Date Then
                    sMSPBTText = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(dtNgayBDKH1.DateTime.Year, dtNgayBDKH1.DateTime.Month)
                    If txtMaSoPBT.Text = txtSoPhieuBaoTri1.Text Then
                        txtMaSoPBT.Text = sMSPBTText
                        txtSoPhieuBaoTri1.Text = sMSPBTText
                    Else
                        txtMaSoPBT.Text = sMSPBTText
                    End If
                End If
            End If

            Dim objPHIEU_BAO_TRIInfo As New clsPHIEU_BAO_TRIInfo()
            objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
            objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI = txtSoPhieuBaoTri1.Text
            objPHIEU_BAO_TRIInfo.TINH_TRANG_PBT = cboTinhTrangPBT.SelectedValue
            objPHIEU_BAO_TRIInfo.MS_MAY = cboMAY.EditValue
            objPHIEU_BAO_TRIInfo.MS_LOAI_BT = cboLoaiBT.EditValue
            objPHIEU_BAO_TRIInfo.NGAY_LAP = dtNgayLap1.DateTime.ToString("dd/MM/yyyy")
            objPHIEU_BAO_TRIInfo.GIO_LAP = Format(dtGioLap.Text, "Long time")
            objPHIEU_BAO_TRIInfo.LY_DO_BT = txtLydo_1.Text
            objPHIEU_BAO_TRIInfo.MS_UU_TIEN = cboMucUuTien1.EditValue
            objPHIEU_BAO_TRIInfo.NGAY_BD_KH = dtNgayBDKH1.DateTime.ToString("dd/MM/yyyy")
            objPHIEU_BAO_TRIInfo.NGAY_KT_KH = dtNgayKTKH1.DateTime.ToString("dd/MM/yyyy")
            objPHIEU_BAO_TRIInfo.NGUOI_LAP = cboNguoiLap1.EditValue
            objPHIEU_BAO_TRIInfo.USERNAME_NGUOI_LAP = txtUserNLap.Text
            objPHIEU_BAO_TRIInfo.NGUOI_GIAM_SAT = If(cboGS_Vien1.Text.ToString() = "", Nothing, cboGS_Vien1.EditValue.ToString())
            objPHIEU_BAO_TRIInfo.GIO_HONG = txtGiohong.Text
            objPHIEU_BAO_TRIInfo.NGAY_HONG = txtNgayhong.Text
            objPHIEU_BAO_TRIInfo.DEN_GIO_HONG = txtDenGioHong.Text
            objPHIEU_BAO_TRIInfo.DEN_NGAY_HONG = txtDenNgayHong.Text
            Dim _nn As String = Convert.ToString(cboNguyenNhan.EditValue)
            If _nn = "" Or _nn = "10000" Then
                _nn = "-1"
            End If
            objPHIEU_BAO_TRIInfo.NGUYEN_NHAN = Convert.ToInt32(_nn)
            Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
            Dim MS_PBT As String = ""
            Dim str As String = ""


            Dim sSql As String
            Dim dtTmp = New DataTable
            If bThemSua = True Then
                sSql = " SELECT * FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = '" + txtMaSoPBT.Text + "' "
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                If dtTmp.Rows.Count > 0 Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MSPBTDaCoBanCoMuonThayDoi", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then GoTo 2
                    txtMaSoPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI()
                    objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
                End If
            End If


            If bPBT Then
                If isOk() = False Then
                    txtMaSoPBT.Text = objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI(objPHIEU_BAO_TRIInfo)
                Else
                    Dim _table_cv As DataTable = New DataTable()
                    _table_cv.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DSCV_PBT", objPHIEU_BAO_TRIInfo.MS_MAY, objPHIEU_BAO_TRIInfo.MS_LOAI_BT))
                    Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
                    objConnection.Open()
                    Dim objTrans As SqlTransaction = objConnection.BeginTransaction()


                    Dim MS_PHIEU_BAO_TRI As String = ""

                    If Not objPHIEU_BAO_TRIController.CheckPHIEU_BAO_TRI(objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI) Then
                        MS_PHIEU_BAO_TRI = objPHIEU_BAO_TRIController.Create_MS_PHIEU_BAO_TRI()
                        If objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI = objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI Then
                            objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI
                        End If
                    Else
                        MS_PHIEU_BAO_TRI = objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI
                    End If
                    Dim sSql1 As String
                    Try
                        SqlHelper.ExecuteNonQuery(objTrans, "AddPHIEU_BAO_TRI1",
                           MS_PHIEU_BAO_TRI, objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI, objPHIEU_BAO_TRIInfo.TINH_TRANG_PBT, objPHIEU_BAO_TRIInfo.MS_MAY, objPHIEU_BAO_TRIInfo.MS_LOAI_BT,
                           objPHIEU_BAO_TRIInfo.NGAY_LAP, objPHIEU_BAO_TRIInfo.GIO_LAP, objPHIEU_BAO_TRIInfo.LY_DO_BT, objPHIEU_BAO_TRIInfo.MS_UU_TIEN,
                           objPHIEU_BAO_TRIInfo.NGAY_BD_KH, objPHIEU_BAO_TRIInfo.NGAY_KT_KH, objPHIEU_BAO_TRIInfo.NGUOI_LAP, objPHIEU_BAO_TRIInfo.USERNAME_NGUOI_LAP,
                           objPHIEU_BAO_TRIInfo.NGUOI_GIAM_SAT, objPHIEU_BAO_TRIInfo.GIO_HONG, objPHIEU_BAO_TRIInfo.NGAY_HONG,
                           objPHIEU_BAO_TRIInfo.NGUYEN_NHAN, objPHIEU_BAO_TRIInfo.DEN_GIO_HONG, objPHIEU_BAO_TRIInfo.DEN_NGAY_HONG)

                        Dim _dt_Phu_tung As DataTable = New DataTable()
                        Dim so_phut_kh As Double
                        Dim ngay_bd_kh As Date
                        Dim ngay_kt_kh As Date
                        Dim gio_bd_kh As Date
                        ngay_bd_kh = dtNgayBDKH1.DateTime.Date
                        gio_bd_kh = ngay_bd_kh.AddHours(8)
                        Dim ngay_temp As String = ngay_bd_kh
                        Dim gio_bd_temp As String = Format(gio_bd_kh, "Long time")
                        Dim ngay_kt_temp As String
                        Dim gio_kt_temp As String
                        Dim _dt_Phu_tung_chi_tiet As DataTable = New DataTable()
                        Dim Count As Integer = 0
                        For Each _rowCv As DataRow In _table_cv.Rows
                            so_phut_kh = Convert.ToDouble(_rowCv("THOI_GIAN_DU_KIEN"))
                            If so_phut_kh = 0 Then
                                so_phut_kh = 5
                            End If
                            ngay_kt_kh = gio_bd_kh.AddMinutes(so_phut_kh)
                            ngay_kt_temp = Format(ngay_kt_kh, "Short date")
                            gio_kt_temp = Format(ngay_kt_kh, "Long time")
                            SqlHelper.ExecuteNonQuery(objTrans, "SP_NHU_Y_ADD_AUTO_CV", MS_PHIEU_BAO_TRI, _rowCv("MS_CV"), _rowCv("MS_BO_PHAN"), _rowCv("THOI_GIAN_DU_KIEN"),
                                _rowCv("THOI_GIAN_DU_KIEN"), 0, _rowCv("SO_NGUOI"), _rowCv("YEU_CAU_NS"), _rowCv("YEU_CAU_DUNG_CU"))

                        Next

                        Dim dt As New DataTable
                        Dim iSL_BTPN As Integer = 0, iSL_CTTB As Integer = 0
                        Dim iSL_KH As Integer = 0

                        Dim S As String = "SELECT MS_PT, MS_CV, MS_BO_PHAN, ISNULL(SO_LUONG,0) AS SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY = N'" & cboMAY.EditValue() & "' AND MS_LOAI_BT = " + Convert.ToInt32(cboLoaiBT.EditValue).ToString()
                        dt.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, S))
                        For Each row As DataRow In dt.Rows
                            iSL_BTPN = row("SO_LUONG")

                            sSql1 = " INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, SL_KH) VALUES('" & MS_PHIEU_BAO_TRI & "'," & row("MS_CV") & ",'" & row("MS_BO_PHAN") & "','" & row("MS_PT") & "'," & row("SO_LUONG") & ")"
                            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql1)

                            Dim dttmp1 As New DataTable
                            'lay so luong tren tung vi tri cua phu tung trong cau truc thiet bi
                            SQLString = "SELECT SUM(SO_LUONG) AS SL_TAT_CA_VI_TRI FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & cboMAY.EditValue & "' AND MS_BO_PHAN='" & row("MS_BO_PHAN") & "' AND MS_PT='" & row("MS_PT") & "' GROUP BY MS_MAY,MS_BO_PHAN,MS_PT"
                            dttmp1.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, SQLString))

                            If (dttmp1.Rows.Count = 1) Then
                                iSL_CTTB = dttmp1.Rows(0)("SL_TAT_CA_VI_TRI")
                            End If

                            dttmp1 = New DataTable()
                            'tim so luong tren tung vi tri co bao nhieu do so luong ben btnpn sang cho hop le
                            dttmp1.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, "SELECT * FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE ACTIVE = 1 AND MS_MAY=N'" & cboMAY.EditValue &
                                        "' AND MS_BO_PHAN='" & row("MS_BO_PHAN") & "' AND MS_PT='" & row("MS_PT") & "'"))

                            For Each row1 As DataRow In dttmp1.Rows
                                If (iSL_BTPN < 0) Then Exit For
                                iSL_KH = iSL_BTPN - row1.Item("SO_LUONG")
                                If iSL_KH <= 0 Then
                                    iSL_KH = iSL_BTPN
                                ElseIf iSL_KH > row1.Item("SO_LUONG") Then
                                    iSL_KH = row1.Item("SO_LUONG")
                                Else
                                    iSL_KH = row1.Item("SO_LUONG")
                                End If
                                sSql1 = " INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, SL_KH, MS_VI_TRI_PT) VALUES('" & MS_PHIEU_BAO_TRI & "'," & row("MS_CV") & ",'" & row("MS_BO_PHAN") & "','" & row("MS_PT") & "'," & iSL_KH & ",'" & row1.Item("MS_VI_TRI_PT") & "')"
                                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql1)
                                iSL_BTPN -= row1.Item("SO_LUONG")
                            Next
                        Next

                        SQLString = "SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SUM(SL_KH) AS SL_TONG FROM " &
                                          " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' " &
                                          " GROUP BY MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT"
                        dtTmp = New DataTable
                        dtTmp.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, SQLString))
                        For Each dr2 As DataRow In dtTmp.Rows
                            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH=" & dr2("SL_TONG") &
                                    " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' AND MS_CV=" & dr2("MS_CV") &
                                    " AND MS_BO_PHAN='" & dr2("MS_BO_PHAN") & "' AND MS_PT='" & dr2("MS_PT") & "'")
                        Next
                        Try
                            SqlHelper.ExecuteNonQuery(objTrans, "InsertCongNhanPBT", MS_PHIEU_BAO_TRI)
                        Catch ex As Exception
                        End Try
                        objTrans.Commit()
                    Catch ex As Exception
                        XtraMessageBox.Show(ex.ToString)
                        objTrans.Rollback()
                        Exit Sub
                    Finally
                        objConnection.Close()
                    End Try
                End If

            Else
                objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI(objPHIEU_BAO_TRIInfo)
            End If
            If (iPNgua) Then
                str = "UPDATE PHIEU_BAO_TRI SET UPDATE_NGAY_CUOI = '" & dtpNgayCNBDKH1.DateTime.ToString("yyy/MM/dd") & "' WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            Else
                str = "UPDATE PHIEU_BAO_TRI SET UPDATE_NGAY_CUOI = NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            End If

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Try
                str = "UPDATE PHIEU_BAO_TRI SET STT_CA = " & If(cboCa.EditValue Is Nothing, Nothing, cboCa.EditValue.ToString()) & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception

            End Try
2:
            Dim tb As New DataTable()
            str = "SELECT DUONG_DAN,HINH FROM TAM12" & UserName & " WHERE STT_YC_NSD =0 AND STT_GSTT=0"
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            For i As Integer = 0 To tb.Rows.Count - 1
                ObjSystems.LuuDuongDan(tb.Rows(i).Item("HINH"), tb.Rows(i).Item("DUONG_DAN"))
            Next
            str = "DELETE FROM TAM12" & UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Try
                str = "DROP TABLE TAM12" & UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try

            str = txtMaSoPBT.Text
            HideButton1(True)
            btnGhi_1.Visible = False
            VisibleButtonGhi(False)
            EnableControl(False)
            BindData()
            For i As Integer = 0 To grvDanhSach_1.RowCount - 1
                If grvDanhSach_1.GetRowCellValue(i, "MS_PHIEU_BAO_TRI") = objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI Then
                    grvDanhSach_1.FocusedRowHandle = i
                    intRowPBT = i
                    ShowData()
                    Exit For
                End If
            Next
            bThem = -1
            bPBT = False
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ResetData()
        Dim str As String = ""
        Dim sPBT As String = ""
        Try
            sPBT = grvDanhSach_1.GetFocusedDataRow()("MS_PHIEU_BAO_TRI")
        Catch ex As Exception
        End Try

        Try
            str = "DROP TABLE TAM12" & UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        LoadcmbCNPBT()
        HideButton1(True)
        btnGhi_1.Visible = False
        VisibleButtonGhi(False)
        RefreshData()
        ErrorProvider1.Clear()
        BindData()
        EnableControl(False)
        If bPBT = False Then
            For i As Integer = 0 To grvDanhSach_1.RowCount - 1
                If grvDanhSach_1.GetRowCellValue(i, "MS_PHIEU_BAO_TRI") = sPBT Then
                    grvDanhSach_1.FocusedRowHandle = i
                    intRowPBT = i
                    Exit For
                End If
            Next
        End If
        ShowData()
        bThem = -1
        bPBT = False
    End Sub
    Private Sub btnKhongGhi_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi_1.Click
        Try
            ResetData()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoat_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat_1.Click
        Try
            bThoat = True
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnXoa_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa_1.Click
        Dim str As String = ""
        If cboTinhTrangPBT.SelectedValue = 4 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "DaNgiemThuKhongDuocXoa", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CheckNghiemThuPBT() Then Exit Sub

        intTabChanged = 0

        If Not ObjSystems.MGetQuyenChucNang(UserName, 16) Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongCoQuyenXoaPBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ObjSystems.MGetQuyenChucNang(UserName, 16)

        str = " SELECT MS_PBT FROM GIAM_SAT_TINH_TRANG_TS WHERE  MS_PBT =  N'" & txtMaSoPBT.Text & "' UNION
                    SELECT MS_PBT FROM GIAM_SAT_TINH_TRANG_TS_DT WHERE  MS_PBT =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PHIEU_BAO_TRI FROM IC_DON_HANG_XUAT WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PHIEU_BAO_TRI FROM IC_DON_HANG_XUAT_X WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PHIEU_BAO_TRI FROM KE_HOACH_TONG_CONG_VIEC WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PHIEU_BAO_TRI FROM THOI_GIAN_NGUNG_MAY_SO_LAN WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PBT FROM THOI_GIAN_CHAY_MAY WHERE  MS_PBT =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PBT FROM YEU_CAU_NSD_CHI_TIET WHERE  MS_PBT =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PHIEU_BAO_TRI FROM TB_PHU_TUNG_BAO_TRI WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'  UNION
                    SELECT MS_PHIEU_BAO_TRI FROM TB_VAT_TU_BAO_TRI WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'  "
        If sPrivate = "BARIA" Then
            str = str & " UNION SELECT MS_PHIEU_BAO_TRI FROM PSDV_PHIEU_BT WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM SYN_NAV_REQUEST_SERVICE_CMMS WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM SYN_NAV_REQUEST_SERVICE_INTEGRATION WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM SYN_TB_IC_DON_HANG_XUAT_VAT_TU_CMMS WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM SYN_TB_IC_DON_HANG_XUAT_VAT_TU_INTEGRATION WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM SYN_TB_TRA_KHO_CMMS WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM SYN_TB_XUAT_KHO_CMMS WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM SYN_TB_XUAT_KHO_INTEGRATION WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM NAV_REQUEST WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM NAV_REQUEST_SERVICE WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'
                        UNION SELECT MS_PHIEU_BAO_TRI FROM NAV_REQUEST_SERVICE_RETURN WHERE  MS_PHIEU_BAO_TRI =  N'" & txtMaSoPBT.Text & "'"
        End If

        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If dtTmp.Rows.Count > 0 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBoxPBTDangSuDungKhongTheXoa", TypeLanguage), Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = "-1"
        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
        If Not objPHIEU_BAO_TRIController.CheckPHIEU_BAO_TRI(txtMaSoPBT.Text.Trim) Then
            If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgPBTConTonTaiChiTietBanCoMuonXoaHet", TypeLanguage), Me.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Traloi = "PBTCV"
            GoTo 1
        End If
        'XoaAllCVPBT
        If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgXoaPBT", TypeLanguage), Me.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
1:
        Dim tran As SqlTransaction
        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        tran = con.BeginTransaction()
        Try
            If Traloi = "PBTCV" Then
                'Xoa CV NS Chinh -- STT = -1
                SqlHelper.ExecuteNonQuery(tran, "XoaAllCVPBT", txtMaSoPBT.Text, -1, "-1", -1)
                'Xoa CV NS Phu -- STT = 0
                SqlHelper.ExecuteNonQuery(tran, "XoaAllCVPBT", txtMaSoPBT.Text, -1, "-1", 0)
            End If
            SQLString = "UPDATE EOR_SERVICE_CHUNG Set MS_PHIEU_BAO_TRI=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteScalar(tran, CommandType.Text, SQLString)

            SQLString = "UPDATE EOR_SERVICE_MNR SET MS_PHIEU_BAO_TRI=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteScalar(tran, CommandType.Text, SQLString)

            SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT=NULL WHERE MS_PBT='" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteScalar(tran, CommandType.Text, SQLString)

            SQLString = "UPDATE GIAM_SAT_TINH_tranG_TS_DT SET MS_PBT=NULL WHERE MS_PBT='" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteScalar(tran, CommandType.Text, SQLString)

            SQLString = "UPDATE GIAM_SAT_TINH_tranG_TS SET MS_PBT=NULL WHERE MS_PBT='" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SQLString)

            SQLString = "UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteScalar(tran, CommandType.Text, SQLString)


            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "XoaKhongThanhCong", TypeLanguage), Me.Text)
            Exit Sub
        End Try
        objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI(txtMaSoPBT.Text)
        RefreshData()
        BindData()

        If grvDanhSach_1.RowCount = 0 Then
            cboMAY.EditValue = -1
            cboLoaiBT.EditValue = -1
            cboMucUuTien1.EditValue = "-1"
            cboNguoiLap1.EditValue = -1
        End If
        intRowPBT = grvDanhSach_1.FocusedRowHandle
        ShowData()

    End Sub

    Private Sub BtnDuyetPBT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDuyetPBT.Click
        Dim str As String = ""
        str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
        " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=7 "
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While objReader.Read
            If objReader.Item("STT").ToString <> "" Then
                Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 2)
                CapNhapPBTCT(2)

                grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Đang thực hiện")
                grvDanhSach_1.SetFocusedRowCellValue("TINH_TRANG_PBT", 2)

                Dim index As Integer = dtPBT.Rows.IndexOf(grvDanhSach_1.GetFocusedDataRow())
                dtPBT.Columns("TEN_TIENG_VIET").ReadOnly = False
                dtPBT.Rows(index)("TEN_TIENG_VIET") = "In Progress"
                dtPBT.Columns("TEN_TIENG_VIET").ReadOnly = True

                dtPBT.Columns("TEN_TINH_TRANG").ReadOnly = False
                dtPBT.Rows(index)("TEN_TINH_TRANG") = "Đang thực hiện"
                dtPBT.Columns("TEN_TINH_TRANG").ReadOnly = True

                dtPBT.AcceptChanges()


                BtnDuyetPBT.Enabled = False
                cboTinhTrangPBT.SelectedValue = 2
                BanHanhPBT()
                'SYN'
                If isSynData Then
                    Try
                        Dim _DataSynInfo As New DataTable
                        _DataSynInfo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_FOR_DNXK_SYN", txtMaSoPBT.Text.Trim()))
                        If _DataSynInfo.Rows.Count > 0 Then
                            Dim scon As New SqlConnection(_SynConnectionInfo)
                            Try
                                scon.Open()
                            Catch ex As Exception
                                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgConnectKhongThanhCong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End Try

                            Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
                            Try
                                'Them du lieu vao Allocated
                                For i As Integer = 0 To _DataSynInfo.Rows.Count - 1
                                    Dim command As SqlCommand = scon.CreateCommand()
                                    command.Connection = scon
                                    command.CommandTimeout = 9999
                                    command.Transaction = sqlTrans
                                    command.CommandType = CommandType.StoredProcedure
                                    command.CommandText = "INTEGRATION_INSERT_DNXK_FOR_SYN"

                                    command.Parameters.Add("@MAKHO", SqlDbType.NVarChar)
                                    command.Parameters("@MAKHO").Value = _DataSynInfo.Rows(i)("MAKHO").ToString()

                                    command.Parameters.Add("@MASOYC", SqlDbType.NVarChar)
                                    command.Parameters("@MASOYC").Value = _DataSynInfo.Rows(i)("MASOYC").ToString()

                                    command.Parameters.Add("@GIOLAP", SqlDbType.DateTime)
                                    command.Parameters("@GIOLAP").Value = _DataSynInfo.Rows(i)("GIOLAP").ToString

                                    command.Parameters.Add("@NGAYLAP", SqlDbType.DateTime)
                                    command.Parameters("@NGAYLAP").Value = _DataSynInfo.Rows(i)("NGAYLAP").ToString()

                                    command.Parameters.Add("@MASOPB", SqlDbType.NVarChar)
                                    command.Parameters("@MASOPB").Value = _DataSynInfo.Rows(i)("MASOPB").ToString()

                                    command.Parameters.Add("@TENPB", SqlDbType.NVarChar)
                                    command.Parameters("@TENPB").Value = _DataSynInfo.Rows(i)("TENPB").ToString()

                                    command.Parameters.Add("@TENNVYC", SqlDbType.NVarChar)
                                    command.Parameters("@TENNVYC").Value = _DataSynInfo.Rows(i)("TENNVYC").ToString()

                                    command.Parameters.Add("@NOIDUNG", SqlDbType.NVarChar)
                                    command.Parameters("@NOIDUNG").Value = _DataSynInfo.Rows(i)("NOIDUNG").ToString()

                                    command.Parameters.Add("@MAVT", SqlDbType.NVarChar)
                                    command.Parameters("@MAVT").Value = _DataSynInfo.Rows(i)("MAVT").ToString()

                                    command.Parameters.Add("@MAHANGMUC", SqlDbType.NVarChar)
                                    command.Parameters("@MAHANGMUC").Value = _DataSynInfo.Rows(i)("MAHANGMUC").ToString()

                                    command.Parameters.Add("@MALYDOXUAT", SqlDbType.NVarChar)
                                    command.Parameters("@MALYDOXUAT").Value = _DataSynInfo.Rows(i)("MALYDOXUAT").ToString()

                                    command.Parameters.Add("@SOLUONG", SqlDbType.Float)
                                    command.Parameters("@SOLUONG").Value = _DataSynInfo.Rows(i)("SOLUONG").ToString()

                                    command.Parameters.Add("@INSERT_DATE", SqlDbType.DateTime)
                                    command.Parameters("@INSERT_DATE").Value = _DataSynInfo.Rows(i)("INSERT_DATE").ToString

                                    command.ExecuteNonQuery()
                                Next


                                sqlTrans.Commit()
                                scon.Close()


                            Catch ex As Exception
                                XtraMessageBox.Show(ex.ToString)
                                sqlTrans.Rollback()
                                scon.Close()
                            End Try

                        End If

                    Catch ex As Exception
                    End Try
                End If
                'END SYN

                'BindData()
            End If
            objReader.Close()
            If sPrivate = "BARIA" And cboTinhTrangPBT.SelectedValue = 1 Then btnIn_1.Enabled = False Else btnIn_1.Enabled = True
            Exit Sub
        End While

        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPheDuyet", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        objReader.Close()
    End Sub

    Private Sub BanHanhPBT()
        If GoiMail = False Then Exit Sub
        Dim frm = New ReportMain.frmPBTBanHanh
        frm.iLoai = 1
        frm.MsPBT = txtMaSoPBT.Text
        frm.ShowDialog()
    End Sub

    Private Sub BtnKhoaPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhoaPBT.Click
        If cboTinhTrangPBT.SelectedValue <> 4 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPBTChuaNT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(dtpNgayCNBDKH1.Text) Then
            dtpNgayCNBDKH1.DateTime = Now
        End If
        If cboTinhTrangPBT.SelectedValue = 4 Then
            Dim str As String = ""
            str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
            " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=9 "
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                If objReader.Item("STT").ToString <> "" Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhoaPBT", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
                        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                        objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 5)
                        CapNhapPBTCT(5)
                        Dim objReader1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHinhThucBT", cboLoaiBT.EditValue)
                        Try
                            While objReader1.Read
                                If objReader1.Item("MS_HT_BT") = 1 Then
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN", cboMAY.EditValue, cboLoaiBT.EditValue, Format(dtpNgayCNBDKH1.DateTime, "Short date"))
                                End If
                            End While
                            objReader1.Close()
                        Catch ex As Exception
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN", cboMAY.EditValue, cboLoaiBT.EditValue, Format(dtpNgayCNBDKH1.DateTime, "Short date"))
                        End Try
                        str = txtMaSoPBT.Text
                        BindData()
                        For i As Integer = 0 To grvDanhSach_1.RowCount - 1
                            If grvDanhSach_1.GetRowCellValue(i, "MS_PHIEU_BAO_TRI") = str Then
                                grvDanhSach_1.FocusedRowHandle = i
                                intRowPBT = i
                                ShowData()
                                Exit For
                            End If
                        Next
                    End If
                End If
                objReader.Close()
                If PermisString.Equals("Read only") Then
                    EnableButton(False)
                Else
                    If cboTinhTrangPBT.SelectedValue < 5 Then
                        EnableButton(True)
                        If optNTHT.SelectedIndex = 0 Or optNTHT.SelectedIndex = 1 Then
                            If cboTinhTrangPBT.SelectedValue = 2 Or cboTinhTrangPBT.SelectedValue = 3 Then
                                BtnDuyetPBT.Enabled = False
                            Else
                                BtnDuyetPBT.Enabled = True
                            End If
                        Else
                            BtnDuyetPBT.Enabled = False
                        End If
                    Else
                        EnableButton(False)
                    End If
                End If
                Exit Sub
            End While
            objReader.Close()
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgLockPBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region
    Private Sub ChonCongViecDichVu(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ucDichVu.grvDichVu.RowCount = 0 Then Exit Sub
        Dim frm As New frmChonCongViecChoPBT_ThueNgoai
        frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
        frm.MS_MAY = cboMAY.EditValue
        frm.STT_EOR = ucDichVu.grvDichVu.GetFocusedDataRow()("STT")
        frm.CONG_VIEC_DV_THUE_NGOAI = True
        Try
            Dim dtTmp As New DataTable()
            Dim sBTam As String = "PHIEU_BAO_TRI_CONG_VIEC_TMP1" + Commons.Modules.UserName
            dtTmp = DirectCast(ucDichVu.grdCongViec.DataSource, DataTable)
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "")
            frm.ShowDialog()
            ucDichVu.grvDichVu_FocusedRowChanged(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ThemSuaDV()
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If CheckNghiemThuPBT() Then Exit Sub
        ucDichVu.ThemSuaDV()
    End Sub
    Private Sub ThemSuaCV()
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If CheckNghiemThuPBT() Then Exit Sub
        ucDichVu.ThemSuaCV()

    End Sub
    Private Sub XoaDichVu()
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If CheckNghiemThuPBT() Then Exit Sub
        ucDichVu.ShowButtonXoa()
    End Sub
#Region "private tab2"
    Dim rowCountCVPT As Integer
    Dim TBPhuTro As New DataTable()
    Private Sub ChonPhuTungCVDichVu(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ucDichVu.grvDichVu.RowCount > 0 Then
            Dim frm As New frmChonPhuTungThaySua
            frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
            frm.MS_MAY = cboMAY.EditValue
            frm.STT_EOR = ucDichVu.grvDichVu.GetFocusedDataRow()("STT")
            frm.ShowDialog()

            Dim str As String = ""
            Dim tb As New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN , MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & UserName & " WHERE MS_PT_CHA='Y'"
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            For i As Integer = 0 To tb.Rows.Count - 1
                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & UserName & " Select DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV, " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH , " &
                                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA " &
                                    " FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "'" &
                                    " WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_MAY=N'" & cboMAY.EditValue & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = '" & tb.Rows(i).Item("MS_PT") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Next
            ucDichVu.grvDichVu_FocusedRowChanged(Nothing, Nothing)
        End If
    End Sub


#Region "Tab5"
    Sub HideButton5(ByVal An As Boolean)
        btnSua5.Visible = Not An
        btnXoa5.Visible = Not An
        btnThoat5.Visible = Not An
        btnGhi5.Visible = An
        btnKhongGhi5.Visible = An
        btnHThanhNT.Visible = Not An
        If sPrivate = "BARIA" Then btnPhanBoLai.Visible = Not An Else btnPhanBoLai.Visible = False
        BtnLockPBT.Visible = Not An
        BtnXacnhanNT.Visible = Not An
        If optNTHT.SelectedIndex = 2 Then
            btnXoaPBTK.Visible = False
        Else
            btnXoaPBTK.Visible = Not An
        End If


    End Sub

    Sub EnableButton5(ByVal Khoa As Boolean)
        btnSua5.Enabled = Khoa

        btnXoa5.Enabled = Khoa

        BtnLockPBT.Enabled = Khoa
        BtnXacnhanNT.Enabled = Khoa
        btnHThanhNT.Enabled = Khoa

        If Khoa = True Then

            BtnLockPBT.Enabled = False
            BtnXacnhanNT.Enabled = False
            btnSua5.Enabled = False
            btnHThanhNT.Enabled = False

            Dim objreader As SqlDataReader
            Dim Str As String = "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME ='" & UserName & "' AND STT in(7,8,9)"
            objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str)
            While objreader.Read
                If objreader.Item("STT") = 7 Then

                ElseIf objreader.Item("STT") = 9 Then
                    BtnLockPBT.Enabled = True
                Else
                    If objreader.Item("STT") = 8 Then
                        BtnXacnhanNT.Enabled = True
                        btnSua5.Enabled = True
                        btnHThanhNT.Enabled = True
                    Else

                    End If
                End If
            End While
        End If


    End Sub

    Sub LockData5(ByVal btnKhoa As Boolean)

        If isSynData = True Then grvPTTTChiTiet.Columns("SL_TT").OptionsColumn.AllowEdit = False
        cboNguoiNghiemThu.Enabled = Not btnKhoa
        txtNgayNghiemThu.Enabled = Not btnKhoa

        txtChiPhiKhacMacDinh.ReadOnly = btnKhoa
        txtTinhTrangSauBaoTri.Properties.ReadOnly = btnKhoa
        If sPrivate.Equals("BARIA") Then txtSGLuyKe.Properties.ReadOnly = btnKhoa Else txtSGLuyKe.Properties.ReadOnly = True
    End Sub

    Private Sub btnSua5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua5.Click
        Dim str As String = ""

        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If CheckNghiemThuPBT() Then Exit Sub
        Dim msPT As String
        Dim focus As Integer

        Try
            'msPT = grdPhuTungThayThe.Rows(grdPhuTungThayThe.CurrentRow.Index).Cells("MS_PT").Value.ToString
            msPT = grvPTThayThe.GetFocusedDataRow("MS_PT").ToString()
            focus = grvPTThayThe.FocusedRowHandle
        Catch ex As Exception
            msPT = -1
        End Try

        bThem = 5
        SQLString = "0LOAD"
        BindData5()
        If txtMaSoPBT.Text = "" Then Exit Sub
        HideButton5(True)
        LockData5(False)
        intTabChanged = 4



        ' intRowCountDVTN = grdDichVuThueNgoai.RowCount
        AddHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged
        SQLString = ""
        BindDataPTThayThe()
        Try
            str = "DROP TABLE BO_PHAN_DI_CHUYEN_TMP" & UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE,MS_MAY,MS_BO_PHAN,CONVERT(int,1) AS TON_TAI " &
        " INTO BO_PHAN_DI_CHUYEN_TMP" & UserName & " FROM PHIEU_BAO_TRI_DI_CHUYEN_BP PBTDC INNER JOIN PHIEU_BAO_TRI PBT ON PBTDC.MS_PHIEU_BAO_TRI=PBT.MS_PHIEU_BAO_TRI WHERE NGAY_TRA_TT IS NULL and PBT.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        If txtNgayNghiemThu.Text = "" Then txtNgayNghiemThu.DateTime = Date.Now

        For i = 0 To CType(grdPTThayThe.DataSource, DataTable).Rows.Count - 1
            If String.IsNullOrEmpty(grvPTThayThe.GetDataRow(i)("NGUOI_THAY_THE").ToString) Then
                grvPTThayThe.SetRowCellValue(i, "NGUOI_THAY_THE", sNNThu)
                grdPTThayThe.Update()
            End If
        Next

        If btnGhi5.Visible Then
            grvPTThayThe.OptionsBehavior.Editable = True
            For i As Integer = 0 To grvPTThayThe.Columns.Count - 1
                grvPTThayThe.Columns(i).OptionsColumn.AllowEdit = False
                grvPTThayThe.Columns(i).OptionsColumn.ReadOnly = True
            Next
            grvPTThayThe.Columns("NGUOI_THAY_THE").OptionsColumn.ReadOnly = False
            grvPTThayThe.Columns("GHI_CHU").OptionsColumn.ReadOnly = False
            grvPTThayThe.Columns("LOAI").OptionsColumn.ReadOnly = False
            grvPTThayThe.Columns("NGUOI_THAY_THE").OptionsColumn.AllowEdit = True
            grvPTThayThe.Columns("GHI_CHU").OptionsColumn.AllowEdit = True
            grvPTThayThe.Columns("LOAI").OptionsColumn.AllowEdit = True
        End If




        str = "SELECT ISNULL(MS_CONG_NHAN,'') FROM USERS WHERE USERNAME  = N'" & UserName & "' "
        str = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str))


        If cboNguoiNghiemThu.Text = "" Then cboNguoiNghiemThu.SelectedValue = str


        'SYN
        If sPrivate = "BARIA" Then

            If grvPTThayThe.RowCount > 0 Then
                btnAllocate.Visible = True
            Else
                btnAllocate.Visible = False
            End If

        Else
            If isSynData = True Then
                btnAllocate.Visible = True
            Else
                btnAllocate.Visible = False
            End If


        End If
        Try
            If Commons.Modules.sPrivate = "VIFON" And txtTinhTrangSauBaoTri.Text.Trim = "" Then
                txtTinhTrangSauBaoTri.Text = "Máy hoạt động tốt, vệ sinh máy sạch sẽ."
            End If

            If msPT = "-1" Then Exit Sub
            'END SYN

            grvPTThayThe.FocusedRowHandle = focus
            grvPTThayThe_FocusedRowChanged(grvPTThayThe, Nothing)


        Catch ex As Exception

        End Try
    End Sub

    'SYN
    Private Function CheckSLAllocated() As Boolean
        Try
            ' _DataAllocatedVTPT
            Dim _dataPTAllocatetmp As New DataTable()
            _dataPTAllocatetmp = CType(grdPTThayThe.DataSource, DataTable)
            Dim _ListPTtmpF As DataTable = _dataPTAllocatetmp.DefaultView.ToTable(True, "MS_PT", "MS_PT1")

            For i As Integer = 0 To _ListPTtmpF.Rows.Count - 1
                Dim _totalSLAllocatePTtmpF As Double = 0
                Dim _totalSLAllocatePTtmpA As Double = 0
                For j As Integer = 0 To _dataPTAllocatetmp.Rows.Count - 1
                    If _ListPTtmpF.Rows(i)("MS_PT").ToString() = _dataPTAllocatetmp.Rows(j)("MS_PT").ToString() Then
                        Dim _sltmp As Double = 0
                        Double.TryParse(_dataPTAllocatetmp.Rows(j)("SL_ALLOCATED").ToString(), _sltmp)
                        _totalSLAllocatePTtmpF = _totalSLAllocatePTtmpF + _sltmp
                    End If
                Next

                For j As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1
                    If _ListPTtmpF.Rows(i)("MS_PT").ToString() = _DataAllocatedVTPT.Rows(j)("MS_PT").ToString() Then
                        Dim _sltmp As Double = 0
                        Double.TryParse(_DataAllocatedVTPT.Rows(j)("SL_YEU_CAU").ToString(), _sltmp)
                        _totalSLAllocatePTtmpA = _totalSLAllocatePTtmpA + _sltmp
                    End If
                Next
                If _totalSLAllocatePTtmpF <> _totalSLAllocatePTtmpA Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "SL_ALLOCATED_KHONG_CAN", TypeLanguage))
                    Return False
                End If
            Next
        Catch ex As Exception
        End Try

        Return True
    End Function
    Private Function getSLDaPBTrenPhieuXuat(ByVal _MS_PT As String, ByVal _MS_CV As String, ByVal _MS_BO_PHAN As String, ByVal _STT As String) As Double
        Dim _dtaview As New DataView(TB_PHU_TUNG_THAY_THE_CHI_TIET, "MS_PT = '" + _MS_PT + "' AND MS_BO_PHAN = '" + _MS_PT + "' AND MS_CV = '" + _MS_PT + "' AND STT = '" + _STT + "'", "MS_PT", DataViewRowState.CurrentRows)
        Dim _totalSL As Double = 0

        For i As Integer = 0 To _dtaview.ToTable().Rows.Count - 1
            Dim _sl_vt As Double = 0
            Double.TryParse(_dtaview.ToTable().Rows(i)("SL_TT").ToString, _sl_vt)
            _totalSL = _totalSL + _sl_vt
        Next

        Return _totalSL
    End Function


    Private Function CreatePhieuNHAP_XUAT_AUTO() As Boolean

        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()

        'insert sl allocate to tablse allocated
        Try
            'xoa du lieu cu 

            Dim commanddel As SqlCommand = scon.CreateCommand()
            commanddel.Connection = scon
            commanddel.CommandTimeout = 9999
            commanddel.Transaction = sqlTrans
            commanddel.CommandType = CommandType.Text
            commanddel.CommandText = "Delete SYN_TB_ALLOCATION_VTPT_FOR_PBT where MS_PHIEU_BT = '" + txtMaSoPBT.Text.Trim().ToString() + "'"
            commanddel.ExecuteNonQuery()

            Dim commandDeletePX As SqlCommand = scon.CreateCommand()
            commandDeletePX.Connection = scon
            commandDeletePX.CommandTimeout = 9999
            commandDeletePX.Transaction = sqlTrans
            commandDeletePX.CommandType = CommandType.StoredProcedure
            commandDeletePX.CommandText = "INTEGRATION_DELETE_XUAT_VT_PT_FOR_PBT"
            commandDeletePX.Parameters.Add("@MS_PHIEU_BT", SqlDbType.NVarChar)
            commandDeletePX.Parameters("@MS_PHIEU_BT").Value = txtMaSoPBT.Text.Trim().ToString()
            commandDeletePX.ExecuteNonQuery()

            'sqlTrans.Commit()
            'Add du lieu moi
            For i As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1
                Dim command As SqlCommand = scon.CreateCommand()
                command.Connection = scon
                command.CommandTimeout = 9999
                command.Transaction = sqlTrans
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "INTEGRATION_SYN_TB_ALLOCATION_VTPT_FOR_PBT_INSERT"

                command.Parameters.Add("@MS_DH_XUAT_PT", SqlDbType.NVarChar)
                command.Parameters("@MS_DH_XUAT_PT").Value = _DataAllocatedVTPT.Rows(i)("MS_DH_XUAT_PT").ToString()

                command.Parameters.Add("@ROW_ID_XUAT", SqlDbType.BigInt)
                command.Parameters("@ROW_ID_XUAT").Value = _DataAllocatedVTPT.Rows(i)("ID_XUAT").ToString()

                command.Parameters.Add("@MS_PT", SqlDbType.NVarChar)
                command.Parameters("@MS_PT").Value = _DataAllocatedVTPT.Rows(i)("MS_PT").ToString()

                command.Parameters.Add("@MS_DH_NHAP_PT", SqlDbType.NVarChar)
                command.Parameters("@MS_DH_NHAP_PT").Value = _DataAllocatedVTPT.Rows(i)("MS_DH_NHAP_PT").ToString()

                command.Parameters.Add("@ROW_ID_NHAP", SqlDbType.BigInt)
                command.Parameters("@ROW_ID_NHAP").Value = _DataAllocatedVTPT.Rows(i)("ID_NHAP").ToString()

                command.Parameters.Add("@MS_PHIEU_BT", SqlDbType.NVarChar)
                command.Parameters("@MS_PHIEU_BT").Value = txtMaSoPBT.Text.Trim().ToString()

                command.Parameters.Add("@SO_LUONG_PHAN_BO", SqlDbType.Float)
                command.Parameters("@SO_LUONG_PHAN_BO").Value = _DataAllocatedVTPT.Rows(i)("SL_YEU_CAU").ToString()
                command.ExecuteNonQuery()
            Next

            'kiem tra so luong nhap
            Dim commandcheck As SqlCommand = scon.CreateCommand()
            commandcheck.Connection = scon
            commandcheck.CommandTimeout = 9999
            commandcheck.Transaction = sqlTrans
            commandcheck.CommandType = CommandType.StoredProcedure
            commandcheck.CommandText = "INTEGRATION_CHECK_SO_LUONG_ALLOCATED_PBT"
            'commandcheck.ExecuteNonQuery()
            commandcheck.Parameters.Add("@MS_PHIEU_BT", SqlDbType.NVarChar)
            commandcheck.Parameters("@MS_PHIEU_BT").Value = txtMaSoPBT.Text.Trim().ToString()

            Dim da As New SqlDataAdapter(commandcheck)
            Dim ds As New DataSet()
            da.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "DA_PB_DU_SL_KTRA_LAI", TypeLanguage))
                sqlTrans.Rollback()
                scon.Close()
                Return False
            End If

            'sqlTrans.Commit()
            'scon.Close()
            'Return False
            'Tao phieu nhap phieu xuat
            sqlTrans.Commit()


            Dim commandCreateNX As SqlCommand = scon.CreateCommand()
            commandCreateNX.Connection = scon
            commandCreateNX.CommandTimeout = 9999
            commandCreateNX.Transaction = sqlTrans
            commandCreateNX.CommandType = CommandType.StoredProcedure
            commandCreateNX.CommandText = "INTEGRATION_CREATE_PHIEU_NHAP_XUAT_FOR_PBT_AUTO"
            commandCreateNX.Parameters.Add("@MS_PHIEU_BT", SqlDbType.NVarChar)
            commandCreateNX.Parameters("@MS_PHIEU_BT").Value = txtMaSoPBT.Text.Trim().ToString()
            commandCreateNX.ExecuteNonQuery()

            'Cap nhat thong tin vao phieu bao tri.
            TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows.Clear()

            Dim commandGetCTNX As SqlCommand = scon.CreateCommand()
            commandGetCTNX.Connection = scon
            commandGetCTNX.CommandTimeout = 9999
            commandGetCTNX.Transaction = sqlTrans
            commandGetCTNX.CommandType = CommandType.StoredProcedure
            commandGetCTNX.CommandText = "INTEGRATION_SP_GET_PTSD_PBT_CHI_TIET"
            commandGetCTNX.Parameters.Add("@MS_PHIEU_BAO_TRI", SqlDbType.NVarChar)
            commandGetCTNX.Parameters("@MS_PHIEU_BAO_TRI").Value = txtMaSoPBT.Text.Trim().ToString()
            'commandGetCTNX.ExecuteNonQuery()

            Dim daGetCTNX As New SqlDataAdapter(commandGetCTNX)
            Dim dsGetCTNX As New DataSet()
            daGetCTNX.Fill(dsGetCTNX)

            Dim _tbDSPX As New DataTable()

            TB_PHU_TUNG_THAY_THE_CHI_TIET = dsGetCTNX.Tables(0)
            _tbDSPX = dsGetCTNX.Tables(1)


            Dim dtresult As DataTable = TB_PHU_TUNG_THAY_THE_CHI_TIET.Copy()
            dtresult.Rows.Clear()
            TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows.Clear()


            'Phan bo so luong cho tung bo phan. vi tri
            Dim vtbVTPTAllocated As New DataTable()
            ' vtbVTPTAllocated = CType(grdPhuTungThayThe.DataSource, DataTable)
            vtbVTPTAllocated = CType(grdPTThayThe.DataSource, DataTable)

            Dim dtVTPTView As New DataView(vtbVTPTAllocated, "ISNULL(SL_ALLOCATED,0) > 0", "MS_PT, MS_CV , MS_BO_PHAN", DataViewRowState.CurrentRows)


            For i As Integer = 0 To _tbDSPX.Rows.Count - 1
                Dim _slXuat As Double = 0
                Double.TryParse(_tbDSPX.Rows(i)("SL_VT").ToString, _slXuat)
                For j As Integer = 0 To dtVTPTView.ToTable().Rows.Count - 1
                    Dim _slAllocated As Double = 0
                    Double.TryParse(dtVTPTView.ToTable().Rows(j)("SL_ALLOCATED").ToString, _slAllocated)

                    If _slXuat > 0 Then
                        If (dtVTPTView.ToTable().Rows(j)("MS_PT").ToString = _tbDSPX.Rows(i)("MS_PT").ToString) Then

                            Dim _sl_da_pb As Double = getSLDaPBTrenPhieuXuat(_tbDSPX.Rows(i)("MS_PT").ToString, dtVTPTView.ToTable().Rows(j)("MS_CV").ToString, dtVTPTView.ToTable().Rows(j)("MS_BO_PHAN").ToString,
                                                                               dtVTPTView.ToTable().Rows(j)("STT").ToString)
                            If _slAllocated > _sl_da_pb Then
                                Dim _sl_can As Double = _slAllocated - _sl_da_pb
                                If _sl_can > 0 Then
                                    If _slXuat > _sl_can Then

                                        Dim _BAO_HANH_DEN_NGAY As DateTime = Nothing
                                        Dim _Ghi_chu As String = ""

                                        If dtVTPTView.ToTable().Rows(j)("GHI_CHU").ToString().Trim = "" Then
                                            _Ghi_chu = "Allocated from Synchronize"
                                        Else
                                            _Ghi_chu = dtVTPTView.ToTable().Rows(j)("GHI_CHU").ToString().Trim
                                        End If

                                        If _tbDSPX.Rows(i)("BAO_HANH_DEN_NGAY").ToString.Trim = "" Then
                                            _BAO_HANH_DEN_NGAY = Nothing
                                        Else
                                            _BAO_HANH_DEN_NGAY = CType(_tbDSPX.Rows(i)("BAO_HANH_DEN_NGAY").ToString, DateTime)
                                        End If

                                        TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows.Add(_tbDSPX.Rows(i)("MS_DH_XUAT_PT").ToString, _tbDSPX.Rows(i)("MS_DH_NHAP_PT").ToString,
                                                                              _tbDSPX.Rows(i)("MS_PT").ToString, _tbDSPX.Rows(i)("MS_PT").ToString, _tbDSPX.Rows(i)("XUAT_XU").ToString,
                                                                              _sl_can, _tbDSPX.Rows(i)("DON_GIA").ToString, _tbDSPX.Rows(i)("NGOAI_TE").ToString, _tbDSPX.Rows(i)("TY_GIA").ToString, _tbDSPX.Rows(i)("TY_GIA_USD").ToString, _BAO_HANH_DEN_NGAY,
                                                                              _tbDSPX.Rows(i)("MS_PHIEU_BAO_TRI").ToString, dtVTPTView.ToTable().Rows(j)("MS_CV").ToString, dtVTPTView.ToTable().Rows(j)("MS_BO_PHAN").ToString,
                                                                              dtVTPTView.ToTable().Rows(j)("STT").ToString, _Ghi_chu, dtVTPTView.ToTable().Rows(j)("ID_XUAT").ToString)


                                        _slXuat = _slXuat - _sl_can
                                    Else
                                        Dim _BAO_HANH_DEN_NGAY As DateTime = Nothing
                                        Dim _Ghi_chu As String = ""

                                        If dtVTPTView.ToTable().Rows(j)("GHI_CHU").ToString().Trim = "" Then
                                            _Ghi_chu = "Allocated from Synchronize"
                                        Else
                                            _Ghi_chu = dtVTPTView.ToTable().Rows(j)("GHI_CHU").ToString().Trim
                                        End If

                                        If _tbDSPX.Rows(i)("BAO_HANH_DEN_NGAY").ToString.Trim = "" Then
                                            _BAO_HANH_DEN_NGAY = Nothing
                                        Else
                                            _BAO_HANH_DEN_NGAY = CType(_tbDSPX.Rows(i)("BAO_HANH_DEN_NGAY").ToString, DateTime)
                                        End If

                                        TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows.Add(_tbDSPX.Rows(i)("MS_DH_XUAT_PT").ToString, _tbDSPX.Rows(i)("MS_DH_NHAP_PT").ToString, _tbDSPX.Rows(i)("MS_PT").ToString, _tbDSPX.Rows(i)("MS_PT").ToString, _tbDSPX.Rows(i)("XUAT_XU").ToString, _slXuat, _tbDSPX.Rows(i)("DON_GIA").ToString, _tbDSPX.Rows(i)("NGOAI_TE").ToString, _tbDSPX.Rows(i)("TY_GIA").ToString, _tbDSPX.Rows(i)("TY_GIA_USD").ToString, _BAO_HANH_DEN_NGAY, _tbDSPX.Rows(i)("MS_PHIEU_BAO_TRI").ToString, dtVTPTView.ToTable().Rows(j)("MS_CV").ToString, dtVTPTView.ToTable().Rows(j)("MS_BO_PHAN").ToString, dtVTPTView.ToTable().Rows(j)("STT").ToString, _Ghi_chu, _tbDSPX.Rows(i)("ID_XUAT").ToString)

                                        _slXuat = 0
                                    End If

                                End If
                            End If
                        End If
                    End If

                Next
            Next

            ' Add vat tu 
            sqlTrans.Commit()
            scon.Close()
        Catch ex As Exception
            sqlTrans.Rollback()
            scon.Close()
            XtraMessageBox.Show(ex.ToString())
            Return False

        End Try

        Return True
    End Function

    Private Function ISCreatePieuNHAP_auto() As Boolean
        Dim _dataOld As New DataTable()
        _dataOld.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_TO_CHECK_ALLOCATED_VTPT_PBT", txtMaSoPBT.Text.Trim.ToString))
        Dim _equal As Boolean = False

        If _DataAllocatedVTPT.Rows.Count <> _dataOld.Rows.Count Then
            Return True
        End If

        For i As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1
            _equal = False
            For j As Integer = 0 To _dataOld.Rows.Count - 1
                If _DataAllocatedVTPT.Rows(i)("MS_DH_XUAT_PT").ToString = _dataOld.Rows(j)("MS_DH_XUAT_PT").ToString And
                _DataAllocatedVTPT.Rows(i)("MS_DH_NHAP_PT").ToString = _dataOld.Rows(j)("MS_DH_NHAP_PT").ToString And
                _DataAllocatedVTPT.Rows(i)("ID_NHAP").ToString = _dataOld.Rows(j)("ROW_ID_NHAP").ToString And
                _DataAllocatedVTPT.Rows(i)("ID_XUAT").ToString = _dataOld.Rows(j)("ROW_ID_XUAT").ToString And
                _DataAllocatedVTPT.Rows(i)("MS_PT").ToString = _dataOld.Rows(j)("MS_PT").ToString And
                _DataAllocatedVTPT.Rows(i)("SL_YEU_CAU").ToString = _dataOld.Rows(j)("SL_VT").ToString Then
                    _equal = True
                End If
            Next
            If _equal = False Then
                Return True
            End If
        Next

        Return False
    End Function

    'END SYN

    Private Sub btnGhi5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi5.Click
        Dim i As Integer = 0
        grvPTTTChiTiet.UpdateCurrentRow()
        grdPTTTChiTiet.RefreshDataSource()
        blnLoiGhiDuLieu = False
        If txtNgayNghiemThu.Text = "" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgChuaNhapNgayNThu", TypeLanguage))
            Exit Sub
        Else
            'Kiem tra ngay nghiem thu
            Try
                Dim vNNT As System.DateTime
                vNNT = txtNgayNghiemThu.DateTime.Date

                If sPrivate = "BARIA" Then
                    If vNNT.Date > Now.Date Then
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgNgayNghiemThuKhongTheLonHonHientai", TypeLanguage))
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
            End Try

        End If

        If Not txtChiPhiKhacMacDinh.IsValidated Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT20", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtChiPhiKhacMacDinh.Focus()
            Exit Sub
        End If


        Try
            If sPrivate.Equals("BARIA") Then
                If txtSGLuyKe.Text = "" Then Me.txtSGLuyKe.Text = 0
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePhieuBaoTriNghiemThu",
                        Me.txtMaSoPBT.Text, IIf(IsDBNull(Me.txtTinhTrangSauBaoTri.Text), Nothing, Me.txtTinhTrangSauBaoTri.Text),
                        IIf(IsDBNull(Me.cboNguoiNghiemThu.SelectedValue), Nothing, Me.cboNguoiNghiemThu.SelectedValue),
                        IIf(IsDBNull(Me.txtNgayNghiemThu.Text) Or txtNgayNghiemThu.Text = "  /  /", Nothing, txtNgayNghiemThu.Text),
                        UserName, IIf(IsDBNull(Me.txtSGLuyKe.Text), Nothing, Me.txtSGLuyKe.Text))
            Else
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePhieuBaoTriNghiemThu",
                        Me.txtMaSoPBT.Text, IIf(IsDBNull(Me.txtTinhTrangSauBaoTri.Text), Nothing, Me.txtTinhTrangSauBaoTri.Text),
                        IIf(IsDBNull(Me.cboNguoiNghiemThu.SelectedValue), Nothing, Me.cboNguoiNghiemThu.SelectedValue),
                        IIf(IsDBNull(Me.txtNgayNghiemThu.Text) Or txtNgayNghiemThu.Text = "  /  /", Nothing, txtNgayNghiemThu.Text), UserName)
            End If
        Catch
        End Try

        'SYN
        If sPrivate <> "BARIA" Then
            If isSynData = True Then
                If CheckSLAllocated() = False Then
                    Exit Sub
                End If
                If ISCreatePieuNHAP_auto() = True Then
                    If CreatePhieuNHAP_XUAT_AUTO() = False Then
                        Exit Sub
                    End If
                End If
            End If
        End If
        ' Exit Sub

        'END SYN

        'Ghi PT Thay the

        If Convert.ToBoolean(ObjSystems.PBTKho) Then
            Dim sqlUpdate As DataVietsoft.Sqlvs = New DataVietsoft.Sqlvs(Commons.IConnections.ConnectionString())
            If sqlUpdate.OpenConnecTion() Then
                Dim TB_TMP As DataTable = TB_PHU_TUNG_THAY_THE_CHI_TIET.Copy()
                TB_TMP.Columns.Remove("XUAT_XU")
                TB_TMP.Columns.Remove("BAO_HANH_DEN_NGAY")
                TB_TMP.Columns.Remove("SO_LUONG_THUC_XUAT")
                TB_TMP.Columns.Remove("MS_DH_NHAP_TRA")
                TB_TMP.Columns.Remove("SL_TRA")
                TB_TMP.Columns.Remove("SL_TAICHE")
                TB_TMP.Columns.Remove("MS_DH_NHAP_TC")
                TB_TMP.Columns.Remove("DG_TAICHE")
                TB_TMP.Columns.Remove("TAI_SD")

                Dim TB_TMP_1 As DataTable = CType(grdPTThayThe.DataSource, DataTable).Copy()
                Dim sBTTT As String = "PPTT_TMP" & UserName

                ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTTT, TB_TMP_1, "")

                TB_TMP_1.DefaultView.RowFilter = "LOAI = 0"
                TB_TMP_1 = (TB_TMP_1.DefaultView.ToTable).Copy
                sqlUpdate.BeginTransacTion()

#Region "insert phu tùng chi tết kho"
                Try

                    If ObjSystems.KhoMoi = True Then
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", TB_TMP, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT", "MS_DH_XUAT_PT", "MS_DH_NHAP_PT", "MS_PT1", "ID")
                    Else
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", TB_TMP, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT", "MS_DH_XUAT_PT", "MS_DH_NHAP_PT", "MS_PT1")
                    End If
                    TB_TMP_1.Columns.Remove("TEN_BO_PHAN")
                    TB_TMP_1.Columns.Remove("TEN_PT")
                    TB_TMP_1.Columns.Remove("XUAT_XU")
                    TB_TMP_1.Columns.Remove("BAO_HANH_DEN_NGAY")
                    TB_TMP_1.Columns.Remove("LOAI")
                    TB_TMP_1.Columns.Add("MS_PHIEU_BAO_TRI")
                    For Each rUp As DataRow In TB_TMP_1.Rows
                        rUp("MS_PHIEU_BAO_TRI") = Me.txtMaSoPBT.Text.Trim()
                    Next
                    'SYN

                    If isSynData = True Then
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "INTEGRATION_insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "INTEGRATION_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_2", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "INTEGRATION_insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "INTEGRATION_update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_3", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")

                    Else
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_2", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_3", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                    End If
                    'END SYN

                    sqlUpdate.ExecuteNonQuery(CommandType.StoredProcedure, "CapNhapPBTPTroNghiemThu", Me.txtMaSoPBT.Text.Trim(), sBTTT)

                    sqlUpdate.CommitTransacTion()
                Catch ex As Exception
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgUPDATE_ERROR", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    sqlUpdate.RollbackTransacTion()
                    Exit Sub
                End Try
#End Region

            Else
                Exit Sub
            End If
        Else
            Dim sqlUpdate As DataVietsoft.Sqlvs = New DataVietsoft.Sqlvs(Commons.IConnections.ConnectionString())
            If sqlUpdate.OpenConnecTion() Then
                'Dim TB_TMP As DataTable = CType(grdPhuTungThayThe.DataSource, DataTable).Copy()
                Dim TB_TMP As DataTable = CType(grdPTThayThe.DataSource, DataTable).Copy()

                TB_TMP.Columns.Remove("TEN_BO_PHAN")
                TB_TMP.Columns.Remove("TEN_PT")
                TB_TMP.Columns.Remove("XUAT_XU")
                TB_TMP.Columns.Remove("BAO_HANH_DEN_NGAY")
                TB_TMP.Columns.Remove("LOAI")

                TB_TMP.Columns.Add("MS_PHIEU_BAO_TRI")
                For Each rUp As DataRow In TB_TMP.Rows
                    rUp("MS_PHIEU_BAO_TRI") = Me.txtMaSoPBT.Text.Trim()
                    If (Not rUp.IsNull("SL_TT")) Then
                        If Convert.ToDouble(rUp("SL_TT")) > 0 Then
                            If Convert.ToBoolean(ObjSystems.PBTKho) Then
                                If (rUp.IsNull("DON_GIA")) Then
                                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNullDON_GIA", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                                If (rUp.IsNull("NGOAI_TE")) Then
                                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNullNGOAI_TE", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                                If (rUp.IsNull("TY_GIA")) Then
                                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNullTY_GIA", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                                If (rUp.IsNull("TY_GIA_USD")) Then
                                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNullTY_GIA_USD", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                            End If
                        Else
                            rUp("DON_GIA") = DBNull.Value
                            rUp("NGOAI_TE") = DBNull.Value
                            rUp("TY_GIA") = DBNull.Value
                            rUp("TY_GIA_USD") = DBNull.Value
                        End If
                    Else
                        rUp("DON_GIA") = DBNull.Value
                        rUp("NGOAI_TE") = DBNull.Value
                        rUp("TY_GIA") = DBNull.Value
                        rUp("TY_GIA_USD") = DBNull.Value
                    End If
                Next
                'SYN
                If isSynData = True Then
                    DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "INTEGRATION_insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "INTEGRAION_update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                Else
                    DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                End If
            Else
                Exit Sub
            End If

            Dim TB As New DataTable()
            TB = grdPTThayThe.DataSource
            Dim str As String = ""
            For i = 0 To CType(grdPTThayThe.DataSource, DataTable).Rows.Count - 1
                Dim SL_TT As Double = 0
                For j As Integer = 0 To grvPTThayThe.RowCount - 1
                    If grvPTThayThe.GetDataRow(j)("MS_PT").ToString().Equals(grvPTThayThe.GetDataRow(i)("MS_PT").ToString) And grvPTThayThe.GetDataRow(j)("MS_BO_PHAN").ToString().Equals(grvPTThayThe.GetDataRow(i)("MS_BO_PHAN").ToString) And grvPTThayThe.GetDataRow(j)("MS_CV").ToString().Equals(grvPTThayThe.GetDataRow(i)("MS_CV").ToString) Then
                        Try
                            SL_TT = SL_TT + Convert.ToDouble(grvPTThayThe.GetDataRow(j)("SL_TT").ToString)
                        Catch ex As Exception
                        End Try
                    End If
                Next
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_TT=" & SL_TT &
                   " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_PT='" & grvPTThayThe.GetDataRow(i)("MS_PT").ToString & "' AND MS_BO_PHAN = '" & grvPTThayThe.GetDataRow(i)("MS_BO_PHAN").ToString & "' AND MS_CV = " & grvPTThayThe.GetDataRow(i)("MS_CV").ToString & ""
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Next
        End If
        i = 0
        'intRowCount = grdDichVuThueNgoai.RowCount - 1
        Try
            SQLString = "INSERT INTO PHIEU_BAO_TRI_CHI_PHI(MS_PHIEU_BAO_TRI,CHI_PHI_KHAC,CHI_PHI_KHAC_USD) VALUES(N'" & txtMaSoPBT.Text & "','" & Val(IIf(IsDBNull(txtChiPhiKhacMacDinh.Text.ToString), 0, txtChiPhiKhacMacDinh.Text.ToString.Replace(",", ""))) & "','" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SQLString)
        Catch ex As Exception
            Try
                SQLString = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacMacDinh.Text), 0, txtChiPhiKhacMacDinh.Text.Replace(",", ""))) & "', CHI_PHI_KHAC_USD ='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & "' WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SQLString)
            Catch ex1 As Exception
                SQLString = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacMacDinh.Text), 0, txtChiPhiKhacMacDinh.Text.Replace(",", ""))) & "', CHI_PHI_KHAC_USD ='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & "' WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SQLString)

            End Try
        End Try

        BindData5()
        HideButton5(False)
        LockData5(True)
        intTabChanged = -1
        bThem = -1
        BtnXacnhanNT.Enabled = True
        'grdDichVuThueNgoai.AllowUserToAddRows = False

        RemoveHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged
        RemoveHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged

        'SYN
        If sPrivate = "BARIA" Then
            btnAllocate.Visible = False
        Else
            If isSynData = True Then
                DataGridViewVTAllocate.Visible = False
                '@Edit
                grdVTNghiemThu.Visible = True

                btnAllocate.Visible = False


            End If
        End If
        'END SYN
    End Sub

    Sub ThucHienGhiPTThayThe()
        Dim intRowCount As Integer = grvPTThayThe.RowCount
        Dim i As Integer = 0

        While i < intRowCount
            If Not IsDBNull(grvPTThayThe.GetDataRow(i)("MS_PT1").Value) And IsDBNull(Me.grvPTThayThe.GetDataRow(i)("SL_TT").Value) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT13", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                grvPTThayThe.FocusedRowHandle = i
                grvPTThayThe.FocusedColumn = grvPTThayThe.Columns("SL_TT")

                blnLoiGhiDuLieu = True
                Exit Sub
            End If
            i = i + 1
        End While
    End Sub


    Sub ThucHienGhiThongTinNghiemThu()
        blnLoiGhiDuLieu = False
        If cboNguoiNghiemThu.SelectedValue Is Nothing Then
            blnLoiGhiDuLieu = True
            Exit Sub
        End If
        If txtNgayNghiemThu.Text = "" Or txtNgayNghiemThu.Text = "  /  /" Then
            blnLoiGhiDuLieu = True
            Exit Sub
        End If
        If Privates() <> "KIDO" Then
            If txtTinhTrangSauBaoTri.Text.Trim = "" Then
                blnLoiGhiDuLieu = True
                Exit Sub
            End If
        End If
        If Not IsDate(txtNgayNghiemThu.Text) Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNgayNghiemThu", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNgayNghiemThu.Focus()
            Exit Sub
        End If
        If Not sPrivate.Equals("BARIA") Then
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePhieuBaoTriNghiemThu", Me.txtMaSoPBT.Text, IIf(IsDBNull(Me.txtTinhTrangSauBaoTri.Text), Nothing, Me.txtTinhTrangSauBaoTri.Text), IIf(IsDBNull(Me.cboNguoiNghiemThu.SelectedValue), Nothing, Me.cboNguoiNghiemThu.SelectedValue), IIf(IsDBNull(Me.txtNgayNghiemThu.Text) Or txtNgayNghiemThu.Text = "  /  /", Nothing, txtNgayNghiemThu.Text), UserName)
        End If
    End Sub

    Private Sub btnKhongGhi5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi5.Click
        HideButton5(False)
        LockData5(True)
        BtnXacnhanNT.Enabled = True
        intTabChanged = -1
        bThem = -1
        BindData5()

        RemoveHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged


        Dim str As String = ""
        Try
            str = "DROP TABLE BO_PHAN_DI_CHUYEN_TMP" & UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        'SYN
        If sPrivate = "BARIA" Then
            btnAllocate.Visible = False
        Else
            If isSynData = True Then
                DataGridViewVTAllocate.Visible = False
                ' grdVatTuNghienThu.Visible = True
                btnAllocate.Visible = False

                '@Edit
                grdVTNghiemThu.Visible = True
            End If
        End If
        'END SYN

    End Sub


    Private Sub LoadNgayBatDauBaoTri(ByVal MS_PBT As String)
        Try

            Dim dtReader As SqlDataReader
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNgayBatDauPBT", MS_PBT)
            While dtReader.Read
                txtNgayBatDau.Text = dtReader.Item(0)
            End While
            dtReader.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadNgayKetThucBaoTri(ByVal MS_PBT As String, ByVal TINH_TRANG_PBT As Integer)
        Dim dtReader As SqlDataReader
        Try
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNgayKetThucPBT", MS_PBT, TINH_TRANG_PBT)
            While dtReader.Read
                txtNgayKetThuc.Text = dtReader.Item(0)
            End While
            dtReader.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadTongGioCong(ByVal MS_PBT As String, ByVal TINH_TRANG_PBT As Integer)
        Dim dtReader As SqlDataReader
        Dim intTongGioCong As Double
        Dim intSoGio, intSoPhut As Integer
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTongGioCong", MS_PBT, TINH_TRANG_PBT)
        While dtReader.Read
            intTongGioCong = intTongGioCong + dtReader.Item(0)
        End While
        intSoGio = Int(intTongGioCong / 60)
        intSoPhut = Int(intTongGioCong Mod 60)
        If intSoGio <> 0 Or intSoPhut <> 0 Then
            If TypeLanguage = 0 Then ' Tiếng Việt 
                txtTongGioCong.Text = intSoGio & " Giờ " & intSoPhut & " Phút"
            ElseIf TypeLanguage = 1 Then ' Tiếng Anh
                txtTongGioCong.Text = intSoGio & " Hour " & intSoPhut & " Minute"
            Else ' Tiếng Hoa
                txtTongGioCong.Text = intSoGio & " Giờ " & intSoPhut & " Phút"
            End If
        Else
            txtTongGioCong.Text = ""
        End If
        dtReader.Close()
    End Sub

    Private Sub RefreshData5()
        txtNgayBatDau.Text = ""
        txtNgayKetThuc.Text = ""
        txtTongGioCong.Text = ""

        txtUserName.Text = ""
        txtNgayNghiemThu.Text = ""

        cboNguoiNghiemThu.SelectedIndex = -1
        txtTinhTrangSauBaoTri.Text = ""
        txtSGLuyKe.Text = ""
        txtChiPhiNhanCongMacDinh.Text = ""
        txtChiPhiNhanCongUSD.Text = ""
        txtChiPhiPhuTungMacDinh.Text = ""
        txtChiPhiPhuTungUSD.Text = ""
        txtChiPhiThueNgoaiMacDinh.Text = ""
        txtChiPhiThueNgoaiUSD.Text = ""
        txtChiPhiTongCongMacDinh.Text = ""
        txtChiPhiTongCongUSD.Text = ""
        txtChiPhiVatTuMacDinh.Text = ""
        txtChiPhiVatTuUSD.Text = ""

    End Sub

    Sub BindData5()
        Application.DoEvents()
        RefreshData5()
        LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
        LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        BindDataThongTinNghiemThu(Me.txtMaSoPBT.Text)
        BindDataThongTinChiPhi(Me.txtMaSoPBT.Text)


        SQLString = "0LoadCT"
        BindDataPTThayThe()
        SQLString = ""
        Try
            BindDataPTThayTheChiTiet(Me.txtMaSoPBT.Text, grvPTThayThe.GetFocusedDataRow()("MS_BO_PHAN").ToString().Trim(),
                        grvPTThayThe.GetFocusedDataRow()("MS_CV"),
                        grvPTThayThe.GetFocusedDataRow()("MS_PT").ToString().Trim(),
                       grvPTThayThe.GetFocusedDataRow()("STT"))

        Catch ex As Exception
            BindDataPTThayTheChiTiet(String.Empty, String.Empty, -1, String.Empty, -1)
        End Try

        SQLString = ""
    End Sub
    Dim rowCount As Integer = 0

    Sub BindDataVaTuBtri()
        Dim vtbVatu As New DataTable()

        'SYN
        If isSynData = True Then
            vtbVatu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GetDanhSachVatTuXuatBaoTri", txtMaSoPBT.Text))
        Else
            vtbVatu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetDanhSachVatTuXuatBaoTri", txtMaSoPBT.Text))
        End If



        '@Edit
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdVTNghiemThu, grvVTNghiemThu, vtbVatu.Copy(), False, False, False, False, True, Name)
        Try
            grvVTNghiemThu.Columns("TY_GIA").Visible = False
            grvVTNghiemThu.Columns("TY_GIA_USD").Visible = False
            grvVTNghiemThu.Columns("NGOAI_TE").Visible = False
            grvVTNghiemThu.Columns("SL_KH").Visible = False
        Catch ex As Exception

        End Try



        grvVTNghiemThu.Columns("TEN_PT").MinWidth = 160

        grvVTNghiemThu.Columns("MS_DH_NHAP_PT").MinWidth = 120
        grvVTNghiemThu.Columns("MS_PT").MinWidth = 120
        grvVTNghiemThu.Columns("MS_DH_NHAP_TRA").BestFit()
        grvVTNghiemThu.Columns("SL_KH").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL)
        grvVTNghiemThu.Columns("SL_KH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        grvVTNghiemThu.Columns("MS_DH_XUAT_PT").MinWidth = 120
        grvVTNghiemThu.Columns("SO_LUONG_THUC_XUAT").MinWidth = 90
        grvVTNghiemThu.Columns("SO_LUONG_THUC_XUAT").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL)
        grvVTNghiemThu.Columns("SO_LUONG_THUC_XUAT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        grvVTNghiemThu.Columns("DON_GIA").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeDG)
        grvVTNghiemThu.Columns("DON_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grvVTNghiemThu.Columns("TY_GIA").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeDG)
        grvVTNghiemThu.Columns("TY_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        grvVTNghiemThu.Columns("TY_GIA_USD").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeDG)
        grvVTNghiemThu.Columns("TY_GIA_USD").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        If isSynData = True Then
            grvVTNghiemThu.Columns("SL_ALLOCATED").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "SL_ALLOCATED", TypeLanguage)
            grvVTNghiemThu.Columns("SL_ALLOCATED").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL) '"#,###,###,###,##0.0"
            grvVTNghiemThu.Columns("SL_ALLOCATED").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            grvVTNghiemThu.Columns("SL_ALLOCATED").Visible = False
        End If

        'END SYN
    End Sub

    Sub BindDataPTThayThe()
        If SQLString = "0LOAD" Then Exit Sub
        Dim dtTable As New DataTable
        If Convert.ToBoolean(ObjSystems.PBTKho) Then
            TB_PHU_TUNG_THAY_THE_CHI_TIET = New DataTable()
            Try
                TB_PHU_TUNG_THAY_THE_CHI_TIET.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_PTSD_PBT_CHI_TIET", Me.txtMaSoPBT.Text))
            Catch ex As Exception
                TB_PHU_TUNG_THAY_THE_CHI_TIET.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_PTSD_PBT_CHI_TIET", String.Empty))
            End Try
        End If
        'SYN
        If isSynData = True Then
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GetPTThayThe", Me.txtMaSoPBT.Text))
            dtTable.Columns("SL_ALLOCATED").ReadOnly = False
        Else
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPTThayThe", Me.txtMaSoPBT.Text))
        End If

        'END SYN

        dtTable.Columns("SL_TT").ReadOnly = False

        Try
            grvPTThayThe.Columns.Clear()
        Catch
        End Try

        Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTThayThe, grvPTThayThe, dtTable, False, False, False, False, True, Name)
        grvPTThayThe.Columns("MS_BO_PHAN").Visible = False
        grvPTThayThe.Columns("MS_CV").Visible = False
        grvPTThayThe.Columns("NGAY_THAY_THE").Visible = False
        grvPTThayThe.Columns("MS_DH_NHAP_PT").Visible = False
        grvPTThayThe.Columns("NGOAI_TE").Visible = False
        grvPTThayThe.Columns("VICT_NHA_THAU").Visible = False
        grvPTThayThe.Columns("XUAT_XU").Visible = False
        grvPTThayThe.Columns("SL_TT").Visible = False
        grvPTThayThe.Columns("DON_GIA").Visible = False
        grvPTThayThe.Columns("NGOAI_TE").Visible = False
        grvPTThayThe.Columns("MS_PT1").Visible = False
        grvPTThayThe.Columns("TY_GIA").Visible = False
        grvPTThayThe.Columns("TY_GIA_USD").Visible = False
        grvPTThayThe.Columns("STT").Visible = False
        grvPTThayThe.Columns("LOAI").Visible = False
        grvPTThayThe.Columns("BAO_HANH_DEN_NGAY").Visible = False



        Dim cboNguoiThayThe As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim dtNguoiThayThe As DataTable = New DataTable()
        dtNguoiThayThe = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCongNhanThayThePT", txtMaSoPBT.Text).Tables(0)
        cboNguoiThayThe.Name = "cboNguoiThayThe"
        cboNguoiThayThe.DisplayMember = "HO_TEN_CONG_NHAN"
        cboNguoiThayThe.ValueMember = "MS_CONG_NHAN"
        cboNguoiThayThe.DataSource = dtNguoiThayThe
        cboNguoiThayThe.PopulateColumns()
        cboNguoiThayThe.Columns(0).Visible = False
        cboNguoiThayThe.Columns(1).Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "HO_TEN_CONG_NHAN", TypeLanguage)
        cboNguoiThayThe.NullText = ""


        grdPTThayThe.RepositoryItems.Add(cboNguoiThayThe)
        grvPTThayThe.Columns("NGUOI_THAY_THE").ColumnEdit = cboNguoiThayThe

        Try
            If dtTable.Rows.Count = 0 Then sNNThu = "" Else sNNThu = dtNguoiThayThe.Rows(0)("MS_CONG_NHAN")

        Catch ex As Exception

        End Try



        grvPTThayThe.Columns("MS_PT").OptionsColumn.ReadOnly = True
        grvPTThayThe.Columns("TEN_PT").OptionsColumn.ReadOnly = True
        grvPTThayThe.Columns("TEN_BO_PHAN").OptionsColumn.ReadOnly = True
        grvPTThayThe.Columns("MS_VI_TRI_PT").OptionsColumn.ReadOnly = True
        grvPTThayThe.Columns("SL_KH").OptionsColumn.ReadOnly = True
        grvPTThayThe.Columns("GHI_CHU").OptionsColumn.ReadOnly = True
        grvPTThayThe.Columns("SL_KH").OptionsColumn.ReadOnly = True


        grvPTThayThe.Columns("SL_KH").OptionsColumn.ReadOnly = True




        If (btnSua5.Visible) Then
            grvPTThayThe.Columns("GHI_CHU").OptionsColumn.ReadOnly = True
            Try
                grvPTThayThe.Columns("NGUOI_THAY_THE").OptionsColumn.ReadOnly = True

            Catch ex As Exception

            End Try
        Else
            grvPTThayThe.Columns("GHI_CHU").OptionsColumn.ReadOnly = False
            Try
                grvPTThayThe.Columns("NGUOI_THAY_THE").OptionsColumn.ReadOnly = False

            Catch ex As Exception

            End Try
        End If
        Try
            With grvPTThayThe
                .Columns("TEN_PT").Width = 200
                .Columns("TEN_BO_PHAN").MinWidth = 150
                .Columns("SL_KH").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL)
                .Columns("SL_KH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                .Columns("GHI_CHU").MinWidth = 180
                .Columns("SL_KH").MinWidth = 100
                .Columns("NGUOI_THAY_THE").MinWidth = 160
                .Columns("NGUOI_THAY_THE").Width = 180

            End With
        Catch ex As Exception

        End Try


        Dim Dtt As New DataTable()
        Dtt = CType(grdPTThayThe.DataSource, DataTable).Copy()

        Try
            grvPTThayThe.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

        Dim Dt As New DataTable()
        Dt = CType(grdPTThayThe.DataSource, DataTable).Copy()
        BindDataVaTuBtri()

        'grvPTThayThe.Columns("MS_PT").OptionsColumn.
        grvPTThayThe.BestFitColumns()
        grvPTThayThe.Columns("MS_PT").BestFit()
    End Sub

    Sub BindDataThongTinChiPhi(ByVal strMS_PBT As String)
        Dim dtReader As SqlDataReader

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongTinChiPhi", strMS_PBT)
        txtChiPhiKhacMacDinh.Text = 0
        txtChiPhiKhacUSD.Text = 0
        txtChiPhiNhanCongMacDinh.Text = 0
        txtChiPhiNhanCongUSD.Text = 0
        txtChiPhiPhuTungMacDinh.Text = 0
        txtChiPhiPhuTungUSD.Text = 0
        txtChiPhiThueNgoaiMacDinh.Text = 0
        txtChiPhiThueNgoaiUSD.Text = 0
        txtChiPhiVatTuMacDinh.Text = 0
        txtChiPhiVatTuUSD.Text = 0
        While dtReader.Read
            If IsDBNull(dtReader.Item("CHI_PHI_PHU_TUNG")) Then txtChiPhiPhuTungMacDinh.Text = 0 Else txtChiPhiPhuTungMacDinh.Text = Format(dtReader.Item("CHI_PHI_PHU_TUNG"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_PHU_TUNG_USD")) Then txtChiPhiPhuTungUSD.Text = 0 Else txtChiPhiPhuTungUSD.Text = Format(dtReader.Item("CHI_PHI_PHU_TUNG_USD"), "0")

            If IsDBNull(dtReader.Item("CHI_PHI_VAT_TU")) Then txtChiPhiVatTuMacDinh.Text = 0 Else txtChiPhiVatTuMacDinh.Text = Format(dtReader.Item("CHI_PHI_VAT_TU"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_VAT_TU_USD")) Then txtChiPhiVatTuUSD.Text = 0 Else txtChiPhiVatTuUSD.Text = Format(dtReader.Item("CHI_PHI_VAT_TU_USD"), "0")

            If IsDBNull(dtReader.Item("CHI_PHI_NHAN_CONG")) Then txtChiPhiNhanCongMacDinh.Text = 0 Else txtChiPhiNhanCongMacDinh.Text = Format(dtReader.Item("CHI_PHI_NHAN_CONG"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_NHAN_CONG_USD")) Then txtChiPhiNhanCongUSD.Text = 0 Else txtChiPhiNhanCongUSD.Text = Format(dtReader.Item("CHI_PHI_NHAN_CONG_USD"), "0")

            If IsDBNull(dtReader.Item("CHI_PHI_DV")) Then txtChiPhiThueNgoaiMacDinh.Text = 0 Else txtChiPhiThueNgoaiMacDinh.Text = Format(dtReader.Item("CHI_PHI_DV"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_DV_USD")) Then txtChiPhiThueNgoaiUSD.Text = 0 Else txtChiPhiThueNgoaiUSD.Text = Format(dtReader.Item("CHI_PHI_DV_USD"), "0")

            If IsDBNull(dtReader.Item("CHI_PHI_KHAC")) Then txtChiPhiKhacMacDinh.Text = 0 Else txtChiPhiKhacMacDinh.Text = Format(dtReader.Item("CHI_PHI_KHAC"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_KHAC_USD")) Then txtChiPhiKhacUSD.Text = 0 Else txtChiPhiKhacUSD.Text = Format(dtReader.Item("CHI_PHI_KHAC_USD"), "0")
        End While
        dtReader.Close()
        Try
            txtChiPhiTongCongMacDinh.Text = CType(txtChiPhiKhacMacDinh.Text, Double) + CType(txtChiPhiNhanCongMacDinh.Text, Double) + CType(txtChiPhiPhuTungMacDinh.Text, Double) + CType(txtChiPhiThueNgoaiMacDinh.Text, Double) + CType(txtChiPhiVatTuMacDinh.Text, Double)
        Catch ex As Exception
            txtChiPhiTongCongMacDinh.Text = 0
        End Try
        Try
            txtChiPhiTongCongUSD.Text = CType(txtChiPhiKhacUSD.Text, Double) + CType(txtChiPhiNhanCongUSD.Text, Double) + CType(txtChiPhiPhuTungUSD.Text, Double) + CType(txtChiPhiThueNgoaiUSD.Text, Double) + CType(txtChiPhiVatTuUSD.Text, Double)
        Catch ex As Exception
            txtChiPhiTongCongUSD.Text = 0
        End Try

        txtChiPhiPhuTungMacDinh.Text = SetCurrentcy(txtChiPhiPhuTungMacDinh.Text)
        txtChiPhiPhuTungUSD.Text = SetCurrentcy(txtChiPhiPhuTungUSD.Text, False)
        txtChiPhiVatTuMacDinh.Text = SetCurrentcy(txtChiPhiVatTuMacDinh.Text)
        txtChiPhiVatTuUSD.Text = SetCurrentcy(txtChiPhiVatTuUSD.Text, False)
        txtChiPhiNhanCongMacDinh.Text = SetCurrentcy(txtChiPhiNhanCongMacDinh.Text)
        txtChiPhiNhanCongUSD.Text = SetCurrentcy(txtChiPhiNhanCongUSD.Text, False)
        txtChiPhiThueNgoaiMacDinh.Text = SetCurrentcy(txtChiPhiThueNgoaiMacDinh.Text)
        txtChiPhiThueNgoaiUSD.Text = SetCurrentcy(txtChiPhiThueNgoaiUSD.Text, False)
        txtChiPhiKhacMacDinh.Text = SetCurrentcy(txtChiPhiKhacMacDinh.Text)
        txtChiPhiKhacUSD.Text = SetCurrentcy(txtChiPhiKhacUSD.Text, False)
        txtChiPhiTongCongMacDinh.Text = SetCurrentcy(txtChiPhiTongCongMacDinh.Text)
        txtChiPhiTongCongUSD.Text = SetCurrentcy(txtChiPhiTongCongUSD.Text, False)
    End Sub

    Private Function SetCurrentcy(ByVal str As String, Optional ByVal bVND As Boolean = True) As String
        If IsNumeric(str) Then
            If Val(str) <> 0 Then
                If bVND = True Then
                    Return Format(Val(Replace$(str, ", ", "")), "N0").ToString
                Else
                    Return Format(Val(Replace$(str, ", ", "")), "N2").ToString
                End If
            Else
                Return "0"
            End If
        Else
            Return str
        End If
    End Function

    Sub BindDataThongTinNghiemThu(ByVal strMS_PBT As String)
        Dim dtReader As SqlDataReader
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongTinNghiemThuPBT", strMS_PBT)
        While dtReader.Read
            txtNgayNghiemThu.Text = IIf(IsDBNull(dtReader.Item("NGAY_NGHIEM_THU")), Nothing, dtReader.Item("NGAY_NGHIEM_THU"))

            If IsDBNull(dtReader.Item("NGUOI_NGHIEM_THU")) Then
                cboNguoiNghiemThu.SelectedIndex = -1
            Else
                cboNguoiNghiemThu.SelectedValue = dtReader.Item("NGUOI_NGHIEM_THU")
            End If
            txtUserName.Text = IIf(IsDBNull(dtReader.Item("USERNAME_NGUOI_NT")), Nothing, dtReader.Item("USERNAME_NGUOI_NT"))
            txtTinhTrangSauBaoTri.Text = IIf(IsDBNull(dtReader.Item("TT_SAU_BT")), Nothing, dtReader.Item("TT_SAU_BT"))

            If sPrivate.Equals("BARIA") Then txtSGLuyKe.Text = IIf(IsDBNull(dtReader.Item("SO_GIO_LUY_KE")), Nothing, dtReader.Item("SO_GIO_LUY_KE")) Else txtSGLuyKe.Text = 0
        End While
        dtReader.Close()
    End Sub

    Private Sub cboNguoiNghiemThu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtUserName.Text = UserName
    End Sub



    Private Sub btnXoa5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa5.Click

        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If CheckNghiemThuPBT() Then Exit Sub

        bThem = 5
        BindData5()
        HideXoa5(True)
        'BtnXoaDVTN.Visible = False
    End Sub

    Sub HideXoa5(ByVal An As Boolean)
        btnSua5.Visible = Not An
        btnXoa5.Visible = Not An
        btnThoat5.Visible = Not An
        btnGhi5.Visible = Not An
        btnHThanhNT.Visible = Not An
        If sPrivate = "BARIA" Then btnPhanBoLai.Visible = Not An Else btnPhanBoLai.Visible = False
        btnPhanBoLai.Visible = Not An
        btnKhongGhi5.Visible = Not An
        BtnLockPBT.Visible = Not An
        BtnXacnhanNT.Visible = Not An
        'BtnXoaDVTN.Visible = An
        btnXoaPTTT.Visible = An
        btnXoaTTNT.Visible = An
        btnTroVe5.Visible = An
        btnXoaPBTK.Visible = Not An
    End Sub

    Private Sub btnTroVe5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe5.Click
        HideXoa5(False)
        bThem = -1
        BtnXacnhanNT.Enabled = True
        btnGhi5.Visible = False
    End Sub

    Private Sub btnXoaTTNT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaTTNT.Click

        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT9", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then Exit Sub

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_TTNT", Me.txtMaSoPBT.Text)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CHI_PHI WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'")
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePBT_THOI_GIAN_CHAY_MAY", Me.cboMAY.EditValue, Format(Me.txtNgayNghiemThu.Text, "short date"))
        Catch ex As Exception
        End Try
        BindData5()
        LoadNgayBatDauBaoTri(Me.txtMaSoPBT.Text)
        LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        If cboTinhTrangPBT.SelectedValue = 5 Or (optNTHT.SelectedIndex = 2 And bCoQuyen = False) Then
            EnableButton5(False)
        Else
            EnableButton5(True)
            If cboTinhTrangPBT.SelectedValue = 4 Then
                BtnXacnhanNT.Enabled = False
            End If
            If cboTinhTrangPBT.SelectedValue = 3 Then
                btnHThanhNT.Enabled = False
            End If

        End If
    End Sub



    Private Sub btnThoat5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat5.Click
        Try
            bThoat = True
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


    Dim cbNgoaiTe As System.Windows.Forms.ComboBox
    Dim autoCompleteSource As New AutoCompleteStringCollection()
    Dim txt As TextBox()

    'kiểm tra phụ tùng xuất có phải là phụ tùng tái sử dụng nếu phụ tùng tái sử dụng có nhập chưa nếu chưa thì lên form nhập phiếu
    Function KiemtraPhuTungTaiSuDung() As Boolean
        Try

            Dim tbVT As DataTable = TB_PHU_TUNG_THAY_THE_CHI_TIET.AsEnumerable().Where(Function(x) x.Field(Of Boolean)("TAI_SD") = True And x.Field(Of Double)("SL_TT") = (x.Field(Of Double)("SO_LUONG_THUC_XUAT") - x.Field(Of Double)("SL_TRA")) And x.Field(Of Double)("SL_TAICHE") = 0).CopyToDataTable()
            If tbVT.Rows.Count > 0 Then
                If tbVT.AsEnumerable().Count(Function(x) x.Field(Of Double)("SL_TAICHE") = 0) = 0 Then
                    Return True
                    Exit Function
                End If
                Dim subset As DataTable = New DataView(tbVT).ToTable(True, "MS_DH_XUAT_PT", "MS_DH_NHAP_PT", "MS_PT", "SO_LUONG_THUC_XUAT", "SL_TRA", "SL_TT", "DON_GIA", "SL_TAICHE", "DG_TAICHE")
                Dim frmNTC As New frmNhapTaiChe()
                frmNTC.dtTaiChe = subset
                If frmNTC.ShowDialog() = DialogResult.OK Then
                    TB_PHU_TUNG_THAY_THE_CHI_TIET.Columns("DG_TAICHE").ReadOnly = False
                    TB_PHU_TUNG_THAY_THE_CHI_TIET.Columns("SL_TAICHE").ReadOnly = False
                    ''cập nhật lại số lượng đơn giá
                    For Each row As DataRow In TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows
                        If Convert.ToBoolean(row("TAI_SD")) = False Then
                            Continue For
                        End If
                        Dim rowsl As DataRow = frmNTC.dtTaiChe.AsEnumerable().Where(Function(x) x.Field(Of String)("MS_DH_XUAT_PT").Equals(row("MS_DH_XUAT_PT")) And x.Field(Of String)("MS_DH_NHAP_PT").Equals(row("MS_DH_NHAP_PT")) And x.Field(Of String)("MS_PT").Equals(row("MS_PT"))).FirstOrDefault()
                        Try
                            row("DG_TAICHE") = Math.Abs(rowsl("DON_GIA") - rowsl("DG_TAICHE"))
                        Catch ex As Exception
                        End Try
                        row("SL_TAICHE") = rowsl("SL_TAICHE")
                        'If String.IsNullOrEmpty(row("SL_TRA").ToString()) Then
                        '    row("SL_TAICHE") = row("SO_LUONG_THUC_XUAT")
                        'Else
                        '    row("SL_TAICHE") = row("SO_LUONG_THUC_XUAT") - row("SL_TRA")
                        'End If
                    Next
                    TB_PHU_TUNG_THAY_THE_CHI_TIET.Columns("DG_TAICHE").ReadOnly = True
                    TB_PHU_TUNG_THAY_THE_CHI_TIET.Columns("SL_TAICHE").ReadOnly = True
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

    Function KiemPhieuBaoTriCongViecNhanSu() As Boolean
        KiemPhieuBaoTriCongViecNhanSu = False
        Dim str As String = ""
        Dim iKT As Integer
        Try
            iKT = Integer.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spKiemNgiemThu", txtMaSoPBT.Text))

            ' Doi cach kiem, gio chi can kiem so gio trong cac table nhan su chi can 1 so gio day du coi nhu cho nghiem thu.
            If iKT <= 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "ChuaNhapNgayGioDuTrongPBTNS", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If

            If Modules.sPrivate = "GREENFEED" Then
                str = "SELECT ISNULL(COUNT(*),0) AS STT FROM (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "'  UNION " &
                            " SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "' UNION " &
                            " SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "' ) A "

                iKT = Int64.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str))
                If iKT > 0 Then
                    str = " SELECT ISNULL(COUNT(*),0) AS STT FROM (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "'  UNION SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "'  UNION SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "'  ) A "

                    iKT = Int64.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str))
                    If iKT = 0 Then
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgChuaNhapNhanSuChoCongViec", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Function
                    End If
                End If
            End If
            KiemPhieuBaoTriCongViecNhanSu = True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
        End Try
    End Function

    Private Sub BtnXacnhanNT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXacnhanNT.Click
        NghiemThuPBT()
    End Sub

    Private Sub XacNhanHTPBT(ByVal MsPBT As String)
        Dim stmp As String = ""
        Dim sDLMail As String = ""
        Dim sNXuong As String
        'lay user lap, user dsx, user dbt
        stmp = " DECLARE @sMail NVARCHAR(2000) " +
                    " SET @sMail = '' " +
                    " SELECT   @sMail = COALESCE(ISNULL(@sMail,'') + CASE LEN(@sMail) WHEN 0 THEN '' ELSE '; ' END , '') + ISNULL(MAIL_NSD,'')   " +
                    " FROM     (  SELECT    ISNULL(USERS.USER_MAIL,'') + CASE ISNULL(USERS_1.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  +  " +
                    " ISNULL(USERS_1.USER_MAIL,'') + CASE ISNULL(USERS_2.USER_MAIL,'') WHEN '' THEN '' ELSE + '; ' END  + " +
                    " ISNULL(USERS_2.USER_MAIL,'') AS MAIL_NSD   " +
                    " FROM         YEU_CAU_NSD_CHI_TIET AS A INNER JOIN " +
                    "                       PHIEU_BAO_TRI AS B ON  A.MS_PBT = B.MS_PHIEU_BAO_TRI INNER JOIN " +
                    "                       YEU_CAU_NSD AS C ON A.STT = C.STT LEFT OUTER JOIN " +
                    "                       USERS ON A.USERNAME_DBT = USERS.USERNAME LEFT OUTER JOIN " +
                    "                       USERS AS USERS_2 ON C.USER_LAP = USERS_2.USERNAME LEFT OUTER JOIN " +
                    "                       USERS AS USERS_1 ON A.USERNAME_DSX = USERS_1.USERNAME " +
                    " WHERE     (B.MS_PHIEU_BAO_TRI = N'" + txtMaSoPBT.Text + "')) A " +
                    " SELECT @sMail "

        stmp = "declare @sName nvarchar(4000) " &
                    " SET @sName = ''  " &
                    " SELECT @sName =  COALESCE(ISNULL(@sName,'') + CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE '; ' END  ,'') + USER_MAIL FROM  " &
                    " (
                            SELECT        
                            ISNULL(T3.USER_MAIL,'') + CASE ISNULL(T3.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T1.EMAIL_NSD,'') + CASE ISNULL(T1.EMAIL_NSD,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T5.USER_MAIL,'') + CASE ISNULL(T5.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T2.EMAIL_DSX,'') + CASE ISNULL(T2.EMAIL_DSX,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T4.USER_MAIL,'') + CASE ISNULL(T4.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T2.EMAIL_DBT,'') + CASE ISNULL(T2.EMAIL_DBT,'') WHEN '' THEN '' ELSE '; ' END  AS USER_MAIL
                            FROM            dbo.USERS AS T4 RIGHT OUTER JOIN
                                dbo.YEU_CAU_NSD_CHI_TIET AS T2 ON T4.USERNAME = T2.USERNAME_DBT LEFT OUTER JOIN
                                dbo.USERS AS T5 ON T2.USERNAME_DSX = T5.USERNAME RIGHT OUTER JOIN
                                dbo.YEU_CAU_NSD AS T1 LEFT OUTER JOIN
                                dbo.USERS AS T3 ON T1.USER_LAP = T3.USERNAME ON T2.STT = T1.STT 
                            WHERE        (T2.MS_PBT = '" & txtMaSoPBT.Text & "'  )                      
                        ) A   " &
                    " SELECT @sName "



        sNXuong = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, stmp))

        stmp = "SELECT     C.MS_N_XUONG FROM YEU_CAU_NSD_CHI_TIET AS A INNER JOIN YEU_CAU_NSD AS C ON A.STT = C.STT WHERE MS_PBT = N'" + txtMaSoPBT.Text + "'"
        stmp = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, stmp))
        stmp = ObjSystems.MLoadMailNX(stmp, sNXuong, 3)
        sDLMail = ObjSystems.MBoMailTrung(stmp)

        If sDLMail = "" Then
            Exit Sub
        End If
        stmp = ""
        Dim table1 As New DataTable()
        Dim table2 As New DataTable()
        Dim sFile As String = "XNHTPBT" + UserName + DateTime.Now.ToString("ddMMyyyHHmmsss") + ".xls"
        Dim sPath As String = Application.StartupPath + "\" + sFile
        If sPath = "" Then Exit Sub
        Try
            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            command.CommandText = "MXacNhanHTPBT"
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@MsPBT", MsPBT))

            Dim adapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet()
            adapter.Fill(dataSet)

            If dataSet.Tables.Count > 0 Then
                table1 = dataSet.Tables(0)
            End If
            If dataSet.Tables.Count > 1 Then
                table2 = dataSet.Tables(1)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
            Exit Sub
        End Try

        Me.Cursor = Cursors.WaitCursor

        For i As Integer = 0 To table2.Rows.Count - 1
            table2.Rows(i)(0) = (i + 1).ToString()
        Next

        ObjSystems.MLoadXtraGrid(grdChung, grvChung, table2, False, True, True, True)


        Dim TCot As Integer = grvChung.Columns.Count
        Dim TDong As Integer = grvChung.RowCount
        Dim iDong As Integer = 1
        Dim iCot As Integer = 1


        grdChung.ExportToXls(sPath)

        Dim excelApplication As Excel.Application = New Excel.Application()
        Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
        Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
        Dim xlWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)

        iDong = Commons.Modules.MExcel.TaoTTChung(xlWorkSheet, 1, 3, 1, TCot)
        Commons.Modules.MExcel.TaoLogo(xlWorkSheet, 0, 0, 100, 45, Application.StartupPath)
        Commons.Modules.MExcel.ThemDong(xlWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 8, iDong)

        iDong += 1
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, ObjLanguages.GetLanguage(ModuleName,
            "frmDuyetSanXuat", "XacNhanBaoTri", TypeLanguage), iDong, 1, "@", 16, True,
            Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, iDong, TCot - 6)
        iDong += 1
        iCot = 2

        stmp = lblMaSoPBT.Text + " : " + txtMaSoPBT.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iCot = 4
        stmp = LabSoPhieuBaoTri.Text + " : " + txtSoPhieuBaoTri1.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iCot = 6
        stmp = lblLoaiBT.Text + " : " + cboLoaiBT.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iDong += 1
        iCot = 2

        stmp = lblMS_ThietBi.Text + " : " + cboMAY.EditValue
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iCot = 4
        stmp = ObjLanguages.GetLanguage(ModuleName,
            "frmDuyetSanXuat", "TEN_MAY", TypeLanguage) + " : " + table1.Rows(0)("TEN_MAY").ToString()
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 3)

        iDong += 1
        iCot = 2

        stmp = lblNgayBDKH.Text + " : " + dtNgayBDKH1.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iCot = 4
        stmp = lblNgayNghiemThu.Text + " : " + txtNgayNghiemThu.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iCot = 6
        stmp = lblNguoiNghiemThu_6.Text + " : " + cboNguoiNghiemThu.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iDong += 1
        iCot = 2

        stmp = ObjLanguages.GetLanguage(ModuleName,
            "frmDuyetSanXuat", "GiamSatVien", TypeLanguage) + " : " + cboGS_Vien1.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 1)

        iCot = 4
        stmp = lblTinhTrangSauBT.Text + " : " + txtTinhTrangSauBaoTri.Text
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 3)

        iDong += 1
        iCot = 2

        stmp = ObjLanguages.GetLanguage(ModuleName,
            "frmDuyetSanXuat", "NguoiThucHien", TypeLanguage) + " : " + table1.Rows(0)("TEN_NTH").ToString()
        Commons.Modules.MExcel.DinhDang(xlWorkSheet, stmp, iDong, iCot, "@", 10, True, True, iDong, iCot + 5)

        iDong = iDong + 2

        Dim title As Excel.Range
        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iDong, 1, iDong + TDong, TCot)
        title.Borders.LineStyle = 1

        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iDong, 1, iDong, TCot)
        title.Font.Bold = True
        title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, xlWorkSheet, False, True, True,
    True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)

        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, 5, 1, 5, 1)
        title.RowHeight = 9

        title = Commons.Modules.MExcel.GetRange(xlWorkSheet, iDong - 1, 1, iDong - 1, 1)
        title.RowHeight = 9



        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 3, "##", True, iDong + 1, 1, TDong + iDong, 1)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", True, iDong + 1, 2, TDong + iDong, 2)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", True, iDong + 1, 3, TDong + iDong, 3)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "dd/MM/yyyy", True, iDong + 1, 4, TDong + iDong, 4)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 25, "@", True, iDong + 1, 5, TDong + iDong, 7)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "dd/MM/yyyy HH:mm:ss", True, iDong + 1, 8, TDong + iDong, 8)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", True, iDong + 1, 9, TDong + iDong, 9)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "dd/MM/yyyy", True, iDong + 1, 10, TDong + iDong, 10)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", True, iDong + 1, 11, TDong + iDong, 11)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 10, "dd/MM/yyyy", True, iDong + 1, 12, TDong + iDong, 12)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 15, "@", True, iDong + 1, 13, TDong + iDong, 13)
        Commons.Modules.MExcel.ColumnWidth(xlWorkSheet, 20, "@", True, iDong + 1, 14, TDong + iDong, 14)

        excelWorkbook.Save()
        excelApplication.DisplayAlerts = False
        If sDLMail <> "" Then
            sDLMail = ObjSystems.MBoMailUser(sDLMail)
            If iLoaiGoiMail = 1 Or iLoaiGoiMail = 3 Then
                If Commons.Modules.MMail.MGoiMail(excelWorkbook, sPath, Application.StartupPath + "\HoanTatBaotri" + ".xls",
                                sDLMail, "", ObjLanguages.GetLanguage(ModuleName,
                                        "FrmPhieuBaoTri_New", "TieuDeMail", TypeLanguage), ObjLanguages.GetLanguage(ModuleName,
                                        "FrmPhieuBaoTri_New", "BodyMail", TypeLanguage), stmp) = False Then


                    XtraMessageBox.Show(stmp)
                End If
            End If
            If iLoaiGoiMail = 2 Or iLoaiGoiMail = 3 Then
                If Commons.Modules.MMail.CapNhapMailVaoCSDL(sFile, sPath, sDLMail, "", "", ObjLanguages.GetLanguage(ModuleName,
                        "FrmPhieuBaoTri_New", "TieuDeMail", TypeLanguage), ObjLanguages.GetLanguage(ModuleName,
                        "FrmPhieuBaoTri_New", "BodyMail", TypeLanguage), stmp) = False Then
                    XtraMessageBox.Show(stmp)
                End If

            End If
        End If
        excelWorkbook.Close(True, Type.Missing, Type.Missing)
        excelApplication.Quit()
        ObjSystems.MReleaseObject(xlWorkSheet)
        ObjSystems.MReleaseObject(excelWorkbook)
        ObjSystems.MReleaseObject(excelApplication)
        ObjSystems.Xoahinh(sPath)
        Me.Cursor = Cursors.Default
    End Sub

    Function TinhSGLK(ByVal MsMay As String, ByVal NgaySGLK As Date) As Boolean
        Dim sSql As String
        Dim dNgay As Date
        Dim dSGLK As Double
        Dim sNgayWhere As String
        Dim bOk As Boolean = False
        If txtSGLuyKe.Text = "" Or Double.Parse(txtSGLuyKe.Text) = 0 Then txtSGLuyKe.Text = 0

        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        sNgayWhere = " CONVERT(DATETIME,CONVERT(NVARCHAR(10), NGAY, 101) + ' ' + CONVERT(NVARCHAR(8), NGAY, 108)) "

        Dim dtTmp As New DataTable
        sSql = "SELECT * FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY = '" & MsMay & "' AND " & sNgayWhere & " = '" & NgaySGLK.ToString("MM/dd/yyyy HH:mm:ss") & "' "
        dtTmp.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sSql))
        If dtTmp.Rows.Count <= 0 Then
            sSql = "INSERT INTO [THOI_GIAN_CHAY_MAY]([MS_MAY],[NGAY],[CHI_SO_DONG_HO],[MS_PBT],[SO_GIO_LUY_KE]) " &
                            " VALUES ( N'" & MsMay & "', N'" & NgaySGLK.ToString("MM/dd/yyyy HH:mm:ss") & "', 0 ,N'" & txtMaSoPBT.Text & "'," & txtSGLuyKe.Text & ")"
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
        Else
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgDuLieuCSDHDaTonTaiBanMuonCapNhap", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then
                objTrans.Rollback()
                Return False
            Else
                sSql = " UPDATE THOI_GIAN_CHAY_MAY SET SO_GIO_LUY_KE = " & txtSGLuyKe.Text & " WHERE MS_MAY = '" & MsMay & "' " &
                            " AND " & sNgayWhere & " = '" & NgaySGLK.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
            End If
        End If

        Try

            dNgay = NgaySGLK
            dSGLK = Double.Parse(txtSGLuyKe.Text)

            Dim dSGLKTruoc As Double
            'lay du lieu truoc
            sSql = "SELECT * FROM THOI_GIAN_CHAY_MAY T1 INNER JOIN  " &
                        " (SELECT MS_MAY, MAX(NGAY) NGAY_MAX FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY = '" & MsMay & "' AND " & sNgayWhere & " < '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' GROUP BY MS_MAY) T2 ON " &
                        " T1.MS_MAY = T2.MS_MAY And NGAY = NGAY_MAX "
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sSql))

            If dtTmp.Rows.Count > 0 Then
                dSGLKTruoc = Double.Parse(dtTmp.Rows(0)("SO_GIO_LUY_KE"))
                'CHI_SO_ONG_HO= chỉ số lũy kế n – chỉ số lũy kế (n-1)., 
                Dim dDSDH As Double
                dDSDH = dSGLK - dSGLKTruoc
                If dDSDH < 0 Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgDuLieuDongHoDoAmBanMuonTiepTuc", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then
                        objTrans.Rollback()
                        Return False
                    Else
                        bOk = True
                    End If
                    dDSDH = dSGLK
                End If
                'CHI_SO_ONG_HO= chỉ số lũy kế n – chỉ số lũy kế (n-1)., 
                sSql = " UPDATE THOI_GIAN_CHAY_MAY SET CHI_SO_DONG_HO = " & dDSDH.ToString & " WHERE MS_MAY = '" & MsMay & "' " &
                                " AND " & sNgayWhere & " = '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)

1:              'lay du lieu Ke
                sSql = " SELECT * FROM THOI_GIAN_CHAY_MAY T1 INNER JOIN " &
                                    " (SELECT MS_MAY, MIN(NGAY) NGAY_MIN FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY = '" & MsMay & "' AND " + sNgayWhere + " > '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' GROUP BY MS_MAY) T2 ON  " &
                                    " T1.MS_MAY = T2.MS_MAY AND NGAY = NGAY_MIN "
                dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sSql))
                If dtTmp.Rows.Count > 0 Then
                    dDSDH = Double.Parse(dtTmp.Rows(0)("SO_GIO_LUY_KE")) - dSGLK
                    If dDSDH < 0 Then
                        If bOk = False Then
                            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgDuLieuDongHoDoAmBanMuonTiepTuc", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then
                                objTrans.Rollback()
                                Return False
                            Else
                                bOk = True
                            End If
                            dDSDH = Double.Parse(dtTmp.Rows(0)("SO_GIO_LUY_KE"))
                        End If
                    End If

                    dNgay = dtTmp.Rows(0)("NGAY")
                    sSql = " UPDATE THOI_GIAN_CHAY_MAY SET CHI_SO_DONG_HO = " & dDSDH.ToString & " WHERE MS_MAY = '" & MsMay & "' " &
                                    " AND " & sNgayWhere & " = '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                    SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
                End If
            Else
                sSql = " UPDATE THOI_GIAN_CHAY_MAY SET CHI_SO_DONG_HO = " & txtSGLuyKe.Text & " WHERE MS_MAY = '" & MsMay & "' " &
                                " AND " & sNgayWhere & " = '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
                GoTo 1

            End If
            objTrans.Commit()
        Catch ex As Exception
            objTrans.Rollback()
            Return False
        End Try
        'Với CHI_SO_LUY_KE bằng số nhập, 
        'CHI_SO_ONG_HO= chỉ số lũy kế n – chỉ số lũy kế (n-1)., 
        'Update CHI_SO_DONG_HO n+1 = Chỉ số lũy kế n+1 trừ đi chỉ số lũy kế n. 
        'Nếu sau khi trừ mà chỉ số nhỏ hơn 0 thì mesagebox lên cho user chọn yes, no. 
        'Nếu yes thì lấy CHI_SO_DONG_HO bằng CHI_SO_LUY_KE, nếu no thì rrollback, k nhập. 
        Return True
    End Function
#Region "Dua File Vao CSDL"
    Private Sub CapNhapMailVaoCSDL(ByVal sFileName As String, ByVal sPath As String, ByVal sMailTo As String,
            ByVal sMailCC As String, ByVal sMailBCC As String, ByVal sTieuDe As String, ByVal sBody As String)
        Try

            If Not ObjSystems.KiemThuMucTonTai(sDDanMail) Then
                System.IO.Directory.CreateDirectory(sDDanMail)
            End If
            ObjSystems.LuuDuongDan(sPath, sDDanMail + "\" & sFileName)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "MAddMailSent", sFileName, sDDanMail + "\" & sFileName, sMailTo, sMailCC,
             sMailBCC, sTieuDe, sBody)
        Catch ex As Exception
            XtraMessageBox.Show((ObjLanguages.GetLanguage(ModuleName, "frmPBTBanHanh", "KhongThanhCong", TypeLanguage) & vbLf) + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

#End Region



    Public Function ExcelColName(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            Return Nothing
            Exit Function
        End If
        Dim i As Int16
        Dim r As Int16
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S
    End Function


    Private Sub KTThongTinNT()
        If cboNguoiNghiemThu.SelectedValue Is Nothing And txtNgayNghiemThu.Text = "  /  /" And txtTinhTrangSauBaoTri.Text = "" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT2", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnLoiGhiDuLieu = True
            Exit Sub
        End If

        If cboNguoiNghiemThu.SelectedValue = "" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT2", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnLoiGhiDuLieu = True
            Exit Sub
        End If

        If txtTinhTrangSauBaoTri.Text = "" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT2", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTinhTrangSauBaoTri.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If
    End Sub

    Private Sub BtnLockPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLockPBT.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If cboTinhTrangPBT.SelectedValue <> 4 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPBTChuaNT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrEmpty(dtpNgayCNBDKH1.Text) Then
            dtpNgayCNBDKH1.DateTime = Now
        End If
        If cboTinhTrangPBT.SelectedValue = 4 Then
            Dim str As String = ""
            str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
                    " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=9 "
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                If objReader.Item("STT").ToString <> "" Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhoaPBT", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
                        'Khoa PBT tinh trang = 5
                        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                        objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 5)
                        CapNhapPBTCT(5)
                        Dim i As Integer = grvDanhSach_1.FocusedRowHandle


                        Dim objReader1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHinhThucBT", cboLoaiBT.EditValue)
                        Dim dtReaderBTPT As SqlDataReader

                        'CAP NHAT CHO LOAI BT DOC LAP (THU_TU = 0)
                        Try
                            While objReader1.Read
                                If objReader1.Item("MS_HT_BT") = 1 Then
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN", cboMAY.EditValue, cboLoaiBT.EditValue, Format(dtpNgayCNBDKH1.DateTime, "Short date"))
                                End If
                            End While
                            objReader1.Close()
                        Catch ex As Exception
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN", cboMAY.EditValue, cboLoaiBT.EditValue, Format(dtpNgayCNBDKH1.DateTime, "Short date"))
                        End Try

                        Try
                            'CAP NHAT CHO LOAI BT PHU THUOC (THU_TU <> 0 VA CAC LOAI BT TRONG QUAN HE)
                            dtReaderBTPT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT=" & cboLoaiBT.EditValue)
                            While dtReaderBTPT.Read
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN", cboMAY.EditValue, dtReaderBTPT.Item("MS_LOAI_BT_CD"), Format(dtpNgayCNBDKH1.DateTime, "Short date"))
                            End While
                            dtReaderBTPT.Close()
                        Catch
                        End Try

                        optNTHT_SelectedIndexChanged(sender, e)
                        Try
                            grvDanhSach_1.FocusedRowHandle = i
                        Catch ex As Exception

                        End Try
                        ShowData()

                        BtnLockPBT.Enabled = False
                    End If
                End If
                objReader.Close()

                If PermisString.Equals("Read only") Then
                    EnableButton(False)
                Else
                    If cboTinhTrangPBT.SelectedValue < 5 Then
                        EnableButton(True)
                        If optNTHT.SelectedIndex = 0 Or optNTHT.SelectedIndex = 1 Then
                            If cboTinhTrangPBT.SelectedValue = 2 Then
                                BtnDuyetPBT.Enabled = False
                            Else
                                BtnDuyetPBT.Enabled = True
                            End If

                        Else
                            BtnDuyetPBT.Enabled = False
                        End If
                    Else
                        EnableButton(False)

                        BtnXacnhanNT.Enabled = False
                    End If
                End If

                Exit Sub
            End While
            objReader.Close()
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgLockPBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        EnableButton(False)

        BtnXacnhanNT.Enabled = False
    End Sub
    Private Function Privates() As String
        Return sPrivate
    End Function

    Private Function IsAutoPBT() As Boolean
        If Privates() = "KIDO" Then
            Return True
        End If
    End Function
    Private Function IsPrint() As Boolean
        If Privates() = "HUDA" Then
            Return True
        End If
    End Function
    Private Function InputNNHH() As Boolean
        Dim sqlString As String = "Select top 1 HCG from THONG_TIN_CHUNG"
        Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
        If (Not _count Is Nothing And Not _count.Equals(DBNull.Value)) Then
            If (CType(_count, Boolean)) Then

                sqlString = "SELECT     COUNT(PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI)" &
                    " FROM         PHIEU_BAO_TRI INNER JOIN " &
                    " LOAI_BAO_TRI ON PHIEU_BAO_TRI.MS_LOAI_BT = LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN" &
                    " HINH_THUC_BAO_TRI ON LOAI_BAO_TRI.MS_HT_BT = HINH_THUC_BAO_TRI.MS_HT_BT" &
                    " WHERE PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text.Trim() & "' AND  HINH_THUC_BAO_TRI.PHONG_NGUA=0"
                Dim result As Integer = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
                If result > 0 Then
                    sqlString = "SELECT     COUNT(MS_PHIEU_BAO_TRI)" &
                    " FROM         PHIEU_BAO_TRI_CLASS WHERE PHIEU_BAO_TRI_CLASS.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text.Trim() & "'"
                    result = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
                    If result <= 0 Then
                        Return True
                    End If
                End If
            End If
        End If
        Return False
    End Function

#End Region

#Region "Báo cáo"


    Function LanguageReportBHS() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PHIEU_BAO_TRI_BT"
        For i As Integer = 0 To 53
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "MAU_SO"
        vtbTitle.Columns(2).ColumnName = "PHIEU_BAO_TRI"
        vtbTitle.Columns(3).ColumnName = "NGUOI_LAP"
        vtbTitle.Columns(4).ColumnName = "NGAY_LAP"
        vtbTitle.Columns(5).ColumnName = "MS_MAY"
        vtbTitle.Columns(6).ColumnName = "TEN_MAY"
        vtbTitle.Columns(7).ColumnName = "TINH_TRANG"
        vtbTitle.Columns(8).ColumnName = "MO_TA"
        vtbTitle.Columns(9).ColumnName = "HINH_THUC_BT"
        vtbTitle.Columns(10).ColumnName = "LOAI_BT"
        vtbTitle.Columns(11).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(13).ColumnName = "KE_HOACH"
        vtbTitle.Columns(14).ColumnName = "NGAY_BD"
        vtbTitle.Columns(15).ColumnName = "NGAY_KT"
        vtbTitle.Columns(16).ColumnName = "BO_PHAN_CP"
        vtbTitle.Columns(17).ColumnName = "PHE_DUYET1"
        vtbTitle.Columns(18).ColumnName = "PHE_DUYET2"
        vtbTitle.Columns(19).ColumnName = "PHE_DUYET3"
        vtbTitle.Columns(20).ColumnName = "PHE_DUYET4"
        vtbTitle.Columns(21).ColumnName = "LY_DO_BT"
        vtbTitle.Columns(22).ColumnName = "GIAM_DOC_NHA_MAY"
        vtbTitle.Columns(23).ColumnName = "PHONG_CO_DIEN"
        vtbTitle.Columns(24).ColumnName = "SERIAL_NUMBER"
        vtbTitle.Columns(25).ColumnName = "TEN_NL"
        vtbTitle.Columns(26).ColumnName = "TMP1"
        vtbTitle.Columns(27).ColumnName = "TMP2"
        vtbTitle.Columns(28).ColumnName = "TMP3"
        vtbTitle.Columns(29).ColumnName = "TMP4"
        vtbTitle.Columns(30).ColumnName = "TMP5"
        vtbTitle.Columns(31).ColumnName = "USER_HT"

        vtbTitle.Columns(32).ColumnName = "DON_VI_YEU_CAU"
        vtbTitle.Columns(33).ColumnName = "MUC_DO_UU_TIEN"
        vtbTitle.Columns(34).ColumnName = "LOAI_CONG_TAC"
        vtbTitle.Columns(35).ColumnName = "DOT_XUAT"
        vtbTitle.Columns(36).ColumnName = "MA_HANG_MUC"
        vtbTitle.Columns(37).ColumnName = "TEN_HANG_MUC"
        vtbTitle.Columns(38).ColumnName = "NGAY_THUC_HIEN"
        vtbTitle.Columns(39).ColumnName = "NGAY_HOAN_THANH"
        vtbTitle.Columns(40).ColumnName = "MA_CONG_VIEC"
        vtbTitle.Columns(41).ColumnName = "SO_CONG_THUC_HIEN"
        vtbTitle.Columns(42).ColumnName = "UU_TIEN_1"
        vtbTitle.Columns(43).ColumnName = "UU_TIEN_2"
        vtbTitle.Columns(44).ColumnName = "UU_TIEN_3"
        vtbTitle.Columns(45).ColumnName = "THONG_TIN_PHAN_HOI"
        vtbTitle.Columns(46).ColumnName = "DON_VI_THUC_HIEN"
        vtbTitle.Columns(47).ColumnName = "DON_VI_GIAM_SAT"
        vtbTitle.Columns(48).ColumnName = "NHAN_XET_KET"
        vtbTitle.Columns(49).ColumnName = "DAT_YEU_CAU"
        vtbTitle.Columns(50).ColumnName = "CHUA_DAT_YEU_CAU"
        vtbTitle.Columns(51).ColumnName = "KHAC"
        vtbTitle.Columns(52).ColumnName = "GHI_CHU_KHAC"
        vtbTitle.Columns(53).ColumnName = "GIO_KH"


        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TIEU_DE") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "TIEU_DE", TypeLanguage)
        vRowTitle("MAU_SO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "MAU_SO", TypeLanguage)
        vRowTitle("PHIEU_BAO_TRI") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "PHIEU_BAO_TRI", TypeLanguage)
        vRowTitle("NGUOI_LAP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NGUOI_LAP", TypeLanguage)
        vRowTitle("NGAY_LAP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NGAY_LAP", TypeLanguage)
        vRowTitle("MS_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "MS_MAY", TypeLanguage)
        vRowTitle("TEN_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "TEN_MAY", TypeLanguage)
        vRowTitle("TINH_TRANG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "TINH_TRANG", TypeLanguage)
        vRowTitle("MO_TA") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "MO_TA", TypeLanguage)
        vRowTitle("HINH_THUC_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "HINH_THUC_BT", TypeLanguage)
        vRowTitle("LOAI_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "LOAI_BT", TypeLanguage)
        vRowTitle("DIA_DIEM") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DIA_DIEM", TypeLanguage)
        vRowTitle("KE_HOACH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "KE_HOACH", TypeLanguage)
        vRowTitle("NGAY_BD") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NGAY_BD", TypeLanguage)
        vRowTitle("NGAY_KT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NGAY_KT", TypeLanguage)
        vRowTitle("BO_PHAN_CP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "BO_PHAN_CP", TypeLanguage)
        vRowTitle("PHE_DUYET1") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "PHE_DUYET1", TypeLanguage)
        vRowTitle("PHE_DUYET2") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "PHE_DUYET2", TypeLanguage)
        vRowTitle("PHE_DUYET3") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "PHE_DUYET3", TypeLanguage)
        vRowTitle("PHE_DUYET4") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "PHE_DUYET4", TypeLanguage)
        vRowTitle("LY_DO_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "LY_DO_BT", TypeLanguage)
        vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NghiemThuCV", TypeLanguage)
        vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "GioKH", TypeLanguage)
        vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NoiDung", TypeLanguage)
        vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DVSuDung", TypeLanguage)
        vRowTitle("TMP5") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "SERIAL_NUMBER", TypeLanguage)

        vRowTitle("GIAM_DOC_NHA_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "TruongBoPhan", TypeLanguage)
        vRowTitle("PHONG_CO_DIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "PHONG_CO_DIEN", TypeLanguage)
        vRowTitle("SERIAL_NUMBER") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "SERIAL_NUMBER", TypeLanguage)
        vRowTitle("TEN_NL") = cboNguoiLap1.Text
        vRowTitle("USER_HT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "USER_IN", TypeLanguage)
        vRowTitle("DON_VI_YEU_CAU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DON_VI_YEU_CAU", TypeLanguage)
        vRowTitle("MUC_DO_UU_TIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "MUC_DO_UU_TIEN", TypeLanguage)
        vRowTitle("LOAI_CONG_TAC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "LOAI_CONG_TAC", TypeLanguage)
        vRowTitle("DOT_XUAT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DOT_XUAT", TypeLanguage)
        vRowTitle("MA_HANG_MUC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "MA_HANG_MUC", TypeLanguage)
        vRowTitle("TEN_HANG_MUC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "TEN_HANG_MUC", TypeLanguage)
        vRowTitle("NGAY_THUC_HIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NGAY_THUC_HIEN", TypeLanguage)
        vRowTitle("NGAY_HOAN_THANH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NGAY_HOAN_THANH", TypeLanguage)
        vRowTitle("MA_CONG_VIEC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "MA_CONG_VIEC", TypeLanguage)
        vRowTitle("SO_CONG_THUC_HIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "SO_CONG_THUC_HIEN", TypeLanguage)

        vRowTitle("UU_TIEN_1") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "UU_TIEN_1", TypeLanguage)
        vRowTitle("UU_TIEN_2") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "UU_TIEN_2", TypeLanguage)
        vRowTitle("UU_TIEN_3") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "UU_TIEN_3", TypeLanguage)
        vRowTitle("THONG_TIN_PHAN_HOI") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "THONG_TIN_PHAN_HOI", TypeLanguage)

        vRowTitle("DON_VI_THUC_HIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DON_VI_THUC_HIEN", TypeLanguage)
        vRowTitle("DON_VI_GIAM_SAT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DON_VI_GIAM_SAT", TypeLanguage)

        vRowTitle("NHAN_XET_KET") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NHAN_XET_KET", TypeLanguage)
        vRowTitle("DAT_YEU_CAU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DAT_YEU_CAU", TypeLanguage)

        vRowTitle("CHUA_DAT_YEU_CAU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "CHUA_DAT_YEU_CAU", TypeLanguage)
        vRowTitle("KHAC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "KHAC", TypeLanguage)
        vRowTitle("GHI_CHU_KHAC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "GHI_CHU_KHAC", TypeLanguage)
        vRowTitle("GIO_KH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "GIO_KH", TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageReport() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PHIEU_BAO_TRI_BT"
        For i As Integer = 0 To 31
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "MAU_SO"
        vtbTitle.Columns(2).ColumnName = "PHIEU_BAO_TRI"
        vtbTitle.Columns(3).ColumnName = "NGUOI_LAP"
        vtbTitle.Columns(4).ColumnName = "NGAY_LAP"
        vtbTitle.Columns(5).ColumnName = "MS_MAY"
        vtbTitle.Columns(6).ColumnName = "TEN_MAY"
        vtbTitle.Columns(7).ColumnName = "TINH_TRANG"
        vtbTitle.Columns(8).ColumnName = "MO_TA"
        vtbTitle.Columns(9).ColumnName = "HINH_THUC_BT"
        vtbTitle.Columns(10).ColumnName = "LOAI_BT"
        vtbTitle.Columns(11).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(13).ColumnName = "KE_HOACH"
        vtbTitle.Columns(14).ColumnName = "NGAY_BD"
        vtbTitle.Columns(15).ColumnName = "NGAY_KT"
        vtbTitle.Columns(16).ColumnName = "BO_PHAN_CP"
        vtbTitle.Columns(17).ColumnName = "PHE_DUYET1"
        vtbTitle.Columns(18).ColumnName = "PHE_DUYET2"
        vtbTitle.Columns(19).ColumnName = "PHE_DUYET3"
        vtbTitle.Columns(20).ColumnName = "PHE_DUYET4"
        vtbTitle.Columns(21).ColumnName = "LY_DO_BT"
        vtbTitle.Columns(22).ColumnName = "GIAM_DOC_NHA_MAY"
        vtbTitle.Columns(23).ColumnName = "PHONG_CO_DIEN"
        vtbTitle.Columns(24).ColumnName = "SERIAL_NUMBER"
        vtbTitle.Columns(25).ColumnName = "TEN_NL"
        vtbTitle.Columns(26).ColumnName = "TMP1"
        vtbTitle.Columns(27).ColumnName = "TMP2"
        vtbTitle.Columns(28).ColumnName = "TMP3"
        vtbTitle.Columns(29).ColumnName = "TMP4"
        vtbTitle.Columns(30).ColumnName = "TMP5"
        vtbTitle.Columns(31).ColumnName = "USER_HT"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TIEU_DE") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TIEU_DE", TypeLanguage)
        vRowTitle("MAU_SO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "MAU_SO", TypeLanguage)
        vRowTitle("PHIEU_BAO_TRI") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PHIEU_BAO_TRI", TypeLanguage)
        vRowTitle("NGUOI_LAP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NGUOI_LAP", TypeLanguage)
        vRowTitle("NGAY_LAP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_LAP", TypeLanguage)
        vRowTitle("MS_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "MS_MAY", TypeLanguage)
        vRowTitle("TEN_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TEN_MAY", TypeLanguage)
        vRowTitle("TINH_TRANG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TINH_TRANG", TypeLanguage)
        vRowTitle("MO_TA") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "MO_TA", TypeLanguage)
        vRowTitle("HINH_THUC_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "HINH_THUC_BT", TypeLanguage)
        vRowTitle("LOAI_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "LOAI_BT", TypeLanguage)
        vRowTitle("DIA_DIEM") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DIA_DIEM", TypeLanguage)
        vRowTitle("KE_HOACH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "KE_HOACH", TypeLanguage)
        vRowTitle("NGAY_BD") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_BD", TypeLanguage)
        vRowTitle("NGAY_KT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_KT", TypeLanguage)
        vRowTitle("BO_PHAN_CP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "BO_PHAN_CP", TypeLanguage)
        vRowTitle("PHE_DUYET1") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET1", TypeLanguage)
        vRowTitle("PHE_DUYET2") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET2", TypeLanguage)
        vRowTitle("PHE_DUYET3") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET3", TypeLanguage)
        vRowTitle("PHE_DUYET4") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET4", TypeLanguage)
        vRowTitle("LY_DO_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "LY_DO_BT", TypeLanguage)
        vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NghiemThuCV", TypeLanguage)
        vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TMP2", TypeLanguage)
        vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NoiDung", TypeLanguage)
        If (sPrivate = "VECO") Then
            vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_VECO", "Remark", TypeLanguage)
        Else
            vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DVSuDung", TypeLanguage)
        End If

        vRowTitle("GIAM_DOC_NHA_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TruongBoPhan", TypeLanguage)
        vRowTitle("PHONG_CO_DIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PHONG_CO_DIEN", TypeLanguage)
        vRowTitle("SERIAL_NUMBER") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "SERIAL_NUMBER", TypeLanguage)
        vRowTitle("TEN_NL") = cboNguoiLap1.Text
        vRowTitle("USER_HT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "USER_IN", TypeLanguage) & " : " & UserName

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageCongViecBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_CONG_VIEC_BT"
        For i As Integer = 0 To 11
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "DANH_SACH_CV"
        vtbTitle.Columns(1).ColumnName = "CV_CONG_VIEC"
        vtbTitle.Columns(2).ColumnName = "CV_BO_PHAN"
        vtbTitle.Columns(3).ColumnName = "CV_SPHUT_KH"
        vtbTitle.Columns(4).ColumnName = "CV_NGAY_HT"
        vtbTitle.Columns(5).ColumnName = "CV_LOAI_CV"
        vtbTitle.Columns(6).ColumnName = "TONG_PHUT_KH_CV"
        vtbTitle.Columns(7).ColumnName = "STT"
        vtbTitle.Columns(8).ColumnName = "TEN_BAC_THO"
        vtbTitle.Columns(9).ColumnName = "TONG_CONG"
        vtbTitle.Columns(10).ColumnName = "THAO_TAC"
        vtbTitle.Columns(11).ColumnName = "TIEU_CHUAN_KT"


        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("DANH_SACH_CV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DANH_SACH_CV", TypeLanguage)
        vRowTitle("CV_CONG_VIEC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_CONG_VIEC", TypeLanguage)
        vRowTitle("CV_BO_PHAN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_BO_PHAN", TypeLanguage)
        vRowTitle("CV_SPHUT_KH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_SPHUT_KH", TypeLanguage)
        vRowTitle("CV_NGAY_HT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_NGAY_HT", TypeLanguage)
        If sPrivate.ToUpper = "ACECOOK" Then
            vRowTitle("CV_LOAI_CV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "GHI_CHU", TypeLanguage)
        Else
            vRowTitle("CV_LOAI_CV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_LOAI_CV", TypeLanguage)
        End If

        vRowTitle("TONG_PHUT_KH_CV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TONG_PHUT_KH_CV", TypeLanguage)
        vRowTitle("STT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "STT", TypeLanguage)
        vRowTitle("TEN_BAC_THO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TEN_BAC_THO", TypeLanguage)
        vRowTitle("TONG_CONG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TONG_CONG", TypeLanguage)
        vRowTitle("THAO_TAC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "THAO_TAC", TypeLanguage)

        If sPrivate.ToUpper = "BHS" Then
            vRowTitle("TIEU_CHUAN_KT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_SPHUT_TT", TypeLanguage)
        Else
            vRowTitle("TIEU_CHUAN_KT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TIEU_CHUAN_KT", TypeLanguage)
        End If
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageNhanvienBT_BHS() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_NHAN_VIEN_BT"
        For i As Integer = 0 To 8
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "NV_DS_NV"
        vtbTitle.Columns(1).ColumnName = "NV_HO_TEN"
        vtbTitle.Columns(2).ColumnName = "NV_TO_PB"
        vtbTitle.Columns(3).ColumnName = "NV_TU_NGAY"
        vtbTitle.Columns(4).ColumnName = "NV_DEN_NGAY"
        vtbTitle.Columns(5).ColumnName = "NV_LOAI_VN"
        vtbTitle.Columns(6).ColumnName = "MS_CONG_NHAN"
        vtbTitle.Columns(7).ColumnName = "CHUC_VU"
        vtbTitle.Columns(8).ColumnName = "KY_XAC_NHAN"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("NV_DS_NV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NV_DS_NV", TypeLanguage)
        vRowTitle("NV_HO_TEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NV_HO_TEN", TypeLanguage)
        vRowTitle("NV_TO_PB") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NV_TO_PB", TypeLanguage)
        vRowTitle("NV_TU_NGAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NV_TU_NGAY", TypeLanguage)
        vRowTitle("NV_DEN_NGAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NV_DEN_NGAY", TypeLanguage)
        vRowTitle("NV_LOAI_VN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NV_LOAI_VN", TypeLanguage)
        vRowTitle("MS_CONG_NHAN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "MS_CONG_NHAN", TypeLanguage)
        vRowTitle("CHUC_VU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "CHUC_VU", TypeLanguage)
        vRowTitle("KY_XAC_NHAN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "KY_XAC_NHAN", TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)

        Return vtbTitle
    End Function
    Function LanguageNhanvienBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_NHAN_VIEN_BT"
        For i As Integer = 0 To 6
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "NV_DS_NV"
        vtbTitle.Columns(1).ColumnName = "NV_HO_TEN"
        vtbTitle.Columns(2).ColumnName = "NV_TO_PB"
        vtbTitle.Columns(3).ColumnName = "NV_TU_NGAY"
        vtbTitle.Columns(4).ColumnName = "NV_DEN_NGAY"
        vtbTitle.Columns(5).ColumnName = "NV_LOAI_VN"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("NV_DS_NV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_DS_NV", TypeLanguage)
        vRowTitle("NV_HO_TEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_HO_TEN", TypeLanguage)
        vRowTitle("NV_TO_PB") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_TO_PB", TypeLanguage)
        vRowTitle("NV_TU_NGAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_TU_NGAY", TypeLanguage)
        vRowTitle("NV_DEN_NGAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_DEN_NGAY", TypeLanguage)
        vRowTitle("NV_LOAI_VN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_LOAI_VN", TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)

        Return vtbTitle
    End Function

    Function LanguageDichVuBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_DICH_VU_BT"
        For i As Integer = 0 To 7
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "DV_DS_DV"
        vtbTitle.Columns(1).ColumnName = "DV_ND"
        vtbTitle.Columns(2).ColumnName = "DV_CTY"
        vtbTitle.Columns(3).ColumnName = "DV_SL"
        vtbTitle.Columns(4).ColumnName = "DV_DG"
        vtbTitle.Columns(5).ColumnName = "DV_TG"
        vtbTitle.Columns(6).ColumnName = "DV_TT"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("DV_DS_DV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_DS_DV", TypeLanguage)
        vRowTitle("DV_ND") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_ND", TypeLanguage)
        vRowTitle("DV_CTY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_CTY", TypeLanguage)
        vRowTitle("DV_SL") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_SL", TypeLanguage)
        vRowTitle("DV_DG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_DG", TypeLanguage)
        vRowTitle("DV_TG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_TG", TypeLanguage)
        vRowTitle("DV_TT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_TT", TypeLanguage)


        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguagePhuTungBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PHU_TUNG_BT"
        For i As Integer = 0 To 12
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "PT_DS_PT"
        vtbTitle.Columns(1).ColumnName = "PT_MS_PT"
        vtbTitle.Columns(2).ColumnName = "PT_MS_PTTT"
        vtbTitle.Columns(3).ColumnName = "PT_TEN_PT"
        vtbTitle.Columns(4).ColumnName = "PT_TEN_PTTT"
        vtbTitle.Columns(5).ColumnName = "PT_SL_KH"
        vtbTitle.Columns(6).ColumnName = "PT_SL_TT"
        vtbTitle.Columns(7).ColumnName = "PT_DVT"
        vtbTitle.Columns(8).ColumnName = "PT_GHI_CHU"
        vtbTitle.Columns(9).ColumnName = "QUY_CACH"
        vtbTitle.Columns(10).ColumnName = "PT_MS_PT_NCC"
        vtbTitle.Columns(11).ColumnName = "HANG_SX"
        vtbTitle.Columns(12).ColumnName = "MS_PT_TT"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("PT_DS_PT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_DS_PT", TypeLanguage)
        vRowTitle("PT_MS_PT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_MS_PT", TypeLanguage)
        vRowTitle("PT_MS_PTTT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_MS_PTTT", TypeLanguage)
        vRowTitle("PT_TEN_PT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_TEN_PT", TypeLanguage)
        vRowTitle("PT_TEN_PTTT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_TEN_PTTT", TypeLanguage)
        vRowTitle("PT_SL_KH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_SL_KH", TypeLanguage)
        vRowTitle("PT_SL_TT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_SL_TT", TypeLanguage)
        vRowTitle("PT_DVT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_DVT", TypeLanguage)
        vRowTitle("PT_GHI_CHU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_GHI_CHU", TypeLanguage)
        vRowTitle("QUY_CACH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "QUY_CACH", TypeLanguage)
        If sPrivate = "ACECOOK" Then
            vRowTitle("PT_MS_PT_NCC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DON_GIA", TypeLanguage)
        Else
            vRowTitle("PT_MS_PT_NCC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_MS_PT_NCC", TypeLanguage)
        End If
        vRowTitle("HANG_SX") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "HANG_SX", TypeLanguage)
        vRowTitle("MS_PT_TT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "MS_PT_TT", TypeLanguage)


        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageVatTuBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_VAT_TU_BT"
        For i As Integer = 0 To 9
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "VT_DS_VT"
        vtbTitle.Columns(1).ColumnName = "VT_MS_VT"
        vtbTitle.Columns(2).ColumnName = "VT_TEN_VT"
        vtbTitle.Columns(3).ColumnName = "VT_SL_KH"
        vtbTitle.Columns(4).ColumnName = "VT_SL_TT"
        vtbTitle.Columns(5).ColumnName = "VT_DVT"
        vtbTitle.Columns(6).ColumnName = "VT_GHI_CHU"
        vtbTitle.Columns(7).ColumnName = "QUY_CACH"
        vtbTitle.Columns(8).ColumnName = "VT_DS_VT_NCC"
        vtbTitle.Columns(9).ColumnName = "MS_PT_TT"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("VT_DS_VT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_DS_VT", TypeLanguage)
        vRowTitle("VT_MS_VT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_MS_VT", TypeLanguage)
        vRowTitle("VT_TEN_VT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_TEN_VT", TypeLanguage)
        vRowTitle("VT_SL_KH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_SL_KH", TypeLanguage)
        vRowTitle("VT_SL_TT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_SL_TT", TypeLanguage)
        vRowTitle("VT_DVT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_DVT", TypeLanguage)
        If sPrivate = "ACECOOK" Then
            vRowTitle("VT_GHI_CHU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "DON_GIA", TypeLanguage)
        Else
            vRowTitle("VT_GHI_CHU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_GHI_CHU", TypeLanguage)
        End If
        vRowTitle("QUY_CACH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "QUY_CACH", TypeLanguage)
        If sPrivate = "ACECOOK" Then
            vRowTitle("VT_DS_VT_NCC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "HANG_SX", TypeLanguage)
        Else
            vRowTitle("VT_DS_VT_NCC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_DS_VT_NCC", TypeLanguage)
        End If
        vRowTitle("MS_PT_TT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "MS_PT_TT", TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageNguoiGiamSat() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_VIEN_GIAM_SAT"
        For i As Integer = 0 To 4
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "NHAN_VIEN"
        vtbTitle.Columns(1).ColumnName = "DON_VI"
        vtbTitle.Columns(2).ColumnName = "XAC_NHAN"
        vtbTitle.Columns(3).ColumnName = "DS_NV_GIAM_SAT"
        vtbTitle.Columns(4).ColumnName = "HO_TEN"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("NHAN_VIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "NHAN_VIEN", TypeLanguage)
        vRowTitle("DON_VI") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DON_VI", TypeLanguage)
        vRowTitle("XAC_NHAN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "XAC_NHAN", TypeLanguage)
        vRowTitle("DS_NV_GIAM_SAT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "DS_NV_GIAM_SAT", TypeLanguage)
        vRowTitle("HO_TEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_BHS", "HO_TEN_GS", TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Function LanguageChiPhiBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_CHI_PHI_BT"
        For i As Integer = 0 To 13
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TONG_CHI_PHI"
        vtbTitle.Columns(1).ColumnName = "STT"
        vtbTitle.Columns(2).ColumnName = "CP_NOI_DUNG"
        vtbTitle.Columns(3).ColumnName = "CP_TIEN"
        vtbTitle.Columns(4).ColumnName = "CP_TONG"
        vtbTitle.Columns(5).ColumnName = "KQ_BAO_TRI"
        vtbTitle.Columns(6).ColumnName = "KQ_NGAY_NT"
        vtbTitle.Columns(7).ColumnName = "KQ_BT"
        vtbTitle.Columns(8).ColumnName = "NGUOI_NT"
        vtbTitle.Columns(9).ColumnName = "CP_PHU_TUNG"
        vtbTitle.Columns(10).ColumnName = "CP_VAT_TU"
        vtbTitle.Columns(11).ColumnName = "CP_NHAN_CONG"
        vtbTitle.Columns(12).ColumnName = "CP_DICH_VU"
        vtbTitle.Columns(13).ColumnName = "CP_KHAC"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TONG_CHI_PHI") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "TONG_CHI_PHI", TypeLanguage)
        vRowTitle("STT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "STT", TypeLanguage)
        vRowTitle("CP_NOI_DUNG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_NOI_DUNG", TypeLanguage)
        vRowTitle("CP_TIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_TIEN", TypeLanguage)
        vRowTitle("CP_TONG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_TONG", TypeLanguage)
        vRowTitle("KQ_BAO_TRI") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "KQ_BAO_TRI", TypeLanguage)
        vRowTitle("KQ_NGAY_NT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "KQ_NGAY_NT", TypeLanguage)
        vRowTitle("KQ_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "KQ_BT", TypeLanguage)
        vRowTitle("NGUOI_NT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "NGUOI_NT", TypeLanguage)
        vRowTitle("CP_PHU_TUNG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_PHU_TUNG", TypeLanguage)
        vRowTitle("CP_VAT_TU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_VAT_TU", TypeLanguage)
        vRowTitle("CP_NHAN_CONG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_NHAN_CONG", TypeLanguage)
        vRowTitle("CP_DICH_VU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_DICH_VU", TypeLanguage)
        vRowTitle("CP_KHAC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_KHAC", TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Private Sub btnIn_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn_1.Click
        If txtMaSoPBT.Text.Trim = "" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "ChuaChonPhieuBaotri", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try

            If SQLString <> "InNhieuPBT" And sPrivate.ToUpper = "VECO" Then
                Dim sBT As String = "PRINT_MU" + UserName
                ObjSystems.XoaTable(sBT)
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                                          "SELECT DISTINCT MS_PHIEU_BAO_TRI INTO " & sBT & " FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "' ")
            End If


            'Tinh trang Va hinh thuc phieu bao tri 
            Dim vtbTT As DataTable = New DataTable()
            vtbTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_TINH_TRANG_AND_HINH_THUC_PHIEU_BAO_TRI", txtMaSoPBT.Text))
            Try
                Dim vSDKho As Integer
                If Convert.ToBoolean(ObjSystems.PBTKho) Then
                    vSDKho = 1
                Else ' Khong su dung kho
                    vSDKho = 0
                End If
                Dim vtbPBT As New DataTable()
                Dim vtbCongViec As New DataTable()
                Dim vtbCongNhan As New DataTable()
                Dim vtbDichVu As New DataTable()
                Dim vtbVatTu As New DataTable()
                Dim vtbPhuTung As New DataTable()
                Dim vtbNumberRecord As New DataTable()
                Dim vtbTTPH As New DataTable()
                Dim vtbNGS As New DataTable()
                Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
                Select Case sPrivate
                    Case "BHS"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_BHS"
                        vtbPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_PHIEU_BAO_TRI_BHS", txtMaSoPBT.Text, TypeLanguage))
                        vtbPBT.TableName = "PBT_INFO"

                        vtbCongViec.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_VIEC_BAO_TRI_BHS", txtMaSoPBT.Text))
                        vtbCongViec.TableName = "PBT_CONG_VIEC"

                        vtbCongNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_NHAN_BAO_TRI_BHS", txtMaSoPBT.Text))
                        vtbCongNhan.TableName = "PBT_CONG_NHAN"

                        vtbDichVu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_DICH_VU_THUE_NGOAI", txtMaSoPBT.Text))
                        vtbDichVu.TableName = "PBT_DICH_VU"

                        vtbVatTu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VAT_TU_PHIEU_BAO_TRI", txtMaSoPBT.Text, vtbTT.Rows(0)("TINH_TRANG_PBT"), TypeLanguage, vSDKho))
                        vtbVatTu.TableName = "PBT_VAT_TU"

                        vtbPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VAT_TU_PHU_TUNG_PHIEU_BAO_TRI_BHS", txtMaSoPBT.Text, vtbTT.Rows(0)("TINH_TRANG_PBT"), TypeLanguage, vSDKho))
                        vtbPhuTung.TableName = "PBT_PHU_TUNG"

                        vtbTTPH.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_THONG_TIN_PHAN_HOI_BHS", txtMaSoPBT.Text))
                        vtbTTPH.TableName = "PBT_TTPH"

                        vtbNGS.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_NGUOI_GIAM_SAT_BHS", txtMaSoPBT.Text))
                        vtbNGS.TableName = "PBT_GIAM_SAT"


                        vtbNumberRecord.TableName = "BT_NUMBER_RECORD"
                        For i As Integer = 0 To 6
                            vtbNumberRecord.Columns.Add()
                        Next
                        vtbNumberRecord.Columns(0).ColumnName = "NR_CONG_VIEC"
                        vtbNumberRecord.Columns(1).ColumnName = "NR_CONG_NHAN"
                        vtbNumberRecord.Columns(2).ColumnName = "NR_DICH_VU"
                        vtbNumberRecord.Columns(3).ColumnName = "NR_PHU_TUNG"
                        vtbNumberRecord.Columns(4).ColumnName = "NR_VAT_TU"
                        vtbNumberRecord.Columns(5).ColumnName = "NR_TT"
                        vtbNumberRecord.Columns(6).ColumnName = "NR_TTPH"

                        Dim vRowTitle1 As DataRow = vtbNumberRecord.NewRow()

                        vRowTitle1("NR_CONG_VIEC") = vtbCongViec.Rows.Count
                        vRowTitle1("NR_CONG_NHAN") = vtbCongNhan.Rows.Count
                        vRowTitle1("NR_DICH_VU") = vtbDichVu.Rows.Count
                        vRowTitle1("NR_PHU_TUNG") = vtbPhuTung.Rows.Count
                        vRowTitle1("NR_VAT_TU") = vtbVatTu.Rows.Count
                        vRowTitle1("NR_TTPH") = vtbTTPH.Rows.Count
                        vRowTitle1("NR_TT") = vtbTT.Rows(0)("TINH_TRANG_PBT")
                        vtbNumberRecord.Rows.Add(vRowTitle1)

                        frmRpt.AddDataTableSource(vtbPBT)
                        frmRpt.AddDataTableSource(vtbCongViec)
                        frmRpt.AddDataTableSource(vtbCongNhan)
                        frmRpt.AddDataTableSource(vtbDichVu)
                        frmRpt.AddDataTableSource(vtbVatTu)
                        frmRpt.AddDataTableSource(vtbPhuTung)
                        frmRpt.AddDataTableSource(vtbNumberRecord)
                        frmRpt.AddDataTableSource(vtbTTPH)
                        frmRpt.AddDataTableSource(vtbNGS)

                        frmRpt.AddDataTableSource(LanguageReportBHS())
                        frmRpt.AddDataTableSource(LanguageCongViecBT())
                        frmRpt.AddDataTableSource(LanguageNhanvienBT_BHS())
                        frmRpt.AddDataTableSource(LanguageDichVuBT())
                        frmRpt.AddDataTableSource(LanguagePhuTungBT())
                        frmRpt.AddDataTableSource(LanguageVatTuBT())
                        frmRpt.AddDataTableSource(LanguageChiPhiBT())
                        frmRpt.AddDataTableSource(LanguageNguoiGiamSat())

                        frmRpt.ShowDialog()
                        Exit Sub

                    Case "VMPACK"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_NT_VMPACK"
                    Case "NUTIFOOD"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_NT_NUTIFOOD"
                    Case "KKTL"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_NT_KKTL"
                    Case "HUDA"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_NT_HUDA"
                    Case "COLGATE"
                        ReportHuda.Class.PrintExcel.Prints_PBT_KIDO(txtMaSoPBT.Text, vSDKho, vtbTT.Rows(0)("TINH_TRANG_PBT"))
                        Exit Sub
                    Case "MEKOPHAR"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_MEKOPHAR"
                        Dim Tb1 As New DataTable
                        Dim Tb2 As New DataTable
                        Tb1.TableName = "TIEUDE"
                        Tb2.TableName = "DULIEU"

                        Tb1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MRptPBT1", txtMaSoPBT.Text))
                        Tb2.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MRptPBT2", txtMaSoPBT.Text))
                        frmRpt.AddDataTableSource(Tb1)
                        frmRpt.AddDataTableSource(Tb2)
                        frmRpt.AddDataTableSource(LanRptMeko())
                        frmRpt.ShowDialog()
                        Exit Sub
                    Case "ACECOOK"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_AC"
                    Case "GREENFEED"
                        frmRpt.rptName = "rptPHIEU_BAO_TRI_GRE"
                    Case "SHISEIDO"
                        InPBTSSD()
                        Exit Sub
                    Case "ADC"
                        InPBTADC()
                        Exit Sub
                    Case "BARIA"
                        InPBTBARIA()
                        Exit Sub
                    Case "VINHHOAN"
                        InPBTVINHHOAN()
                        Exit Sub
                    Case "VINAONE"
                        InPBTVINAONE()
                        Exit Sub
                    Case Else
                        InPBTBARIA()
                        Exit Sub
                End Select




                vtbPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_PHIEU_BAO_TRI", txtMaSoPBT.Text, TypeLanguage))
                vtbPBT.TableName = "PBT_INFO"

                vtbCongViec.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_VIEC_BAO_TRI", txtMaSoPBT.Text))
                vtbCongViec.TableName = "PBT_CONG_VIEC"

                vtbCongNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_NHAN_BAO_TRI", txtMaSoPBT.Text))
                vtbCongNhan.TableName = "PBT_CONG_NHAN"

                vtbDichVu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_DICH_VU_THUE_NGOAI", txtMaSoPBT.Text))
                vtbDichVu.TableName = "PBT_DICH_VU"

                vtbVatTu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VAT_TU_PHIEU_BAO_TRI", txtMaSoPBT.Text, vtbTT.Rows(0)("TINH_TRANG_PBT"), TypeLanguage, vSDKho))
                vtbVatTu.TableName = "PBT_VAT_TU"

                If sPrivate = "GREENFEED" Then
                    vtbPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_PHU_TUNG_PHIEU_BAO_TRI", txtMaSoPBT.Text, vtbTT.Rows(0)("TINH_TRANG_PBT"), TypeLanguage, vSDKho))
                Else
                    vtbPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_PHU_TUNG_PHIEU_BAO_TRI", txtMaSoPBT.Text, vtbTT.Rows(0)("TINH_TRANG_PBT"), TypeLanguage, vSDKho))
                End If
                vtbPhuTung.TableName = "PBT_PHU_TUNG"
                vtbNumberRecord.TableName = "BT_NUMBER_RECORD"
                For i As Integer = 0 To 5
                    vtbNumberRecord.Columns.Add()
                Next
                vtbNumberRecord.Columns(0).ColumnName = "NR_CONG_VIEC"
                vtbNumberRecord.Columns(1).ColumnName = "NR_CONG_NHAN"
                vtbNumberRecord.Columns(2).ColumnName = "NR_DICH_VU"
                vtbNumberRecord.Columns(3).ColumnName = "NR_PHU_TUNG"
                vtbNumberRecord.Columns(4).ColumnName = "NR_VAT_TU"
                vtbNumberRecord.Columns(5).ColumnName = "NR_TT"
                Dim vRowTitle As DataRow = vtbNumberRecord.NewRow()
                vRowTitle("NR_CONG_VIEC") = vtbCongViec.Rows.Count
                vRowTitle("NR_CONG_NHAN") = vtbCongNhan.Rows.Count
                vRowTitle("NR_DICH_VU") = vtbDichVu.Rows.Count
                vRowTitle("NR_PHU_TUNG") = vtbPhuTung.Rows.Count
                vRowTitle("NR_VAT_TU") = vtbVatTu.Rows.Count
                vRowTitle("NR_TT") = vtbTT.Rows(0)("TINH_TRANG_PBT")
                vtbNumberRecord.Rows.Add(vRowTitle)
                frmRpt.AddDataTableSource(vtbPBT)
                frmRpt.AddDataTableSource(vtbCongViec)
                frmRpt.AddDataTableSource(vtbCongNhan)
                frmRpt.AddDataTableSource(vtbDichVu)
                frmRpt.AddDataTableSource(vtbVatTu)
                frmRpt.AddDataTableSource(vtbPhuTung)
                frmRpt.AddDataTableSource(vtbNumberRecord)
                frmRpt.AddDataTableSource(LanguageReport())
                frmRpt.AddDataTableSource(LanguageCongViecBT())
                frmRpt.AddDataTableSource(LanguageNhanvienBT())
                frmRpt.AddDataTableSource(LanguageDichVuBT())
                frmRpt.AddDataTableSource(LanguagePhuTungBT())
                frmRpt.AddDataTableSource(LanguageVatTuBT())
                frmRpt.AddDataTableSource(LanguageChiPhiBT())
                frmRpt.ShowDialog()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message)
            End Try
        Catch ex As Exception
        End Try

    End Sub
#Region " In PBT SSD"
    Private Sub InPBTSSD()
        Try
            Dim dtTmp = New DataTable
            Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
            Dim sDDHinh As String = ""
            Dim Hinh As Boolean = False
            Dim arrImage As Byte() = Nothing

            frmRpt.rptName = "rptPHIEU_BAO_TRI_SSD"
            Dim sSql As String = ""
            sSql = "SELECT * FROM MAY WHERE MS_MAY = '" & cboMAY.EditValue & "' "
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            sDDHinh = dtTmp.Rows(0)("Anh_TB").ToString()
            Try
                If sDDHinh <> "" Then
                    arrImage = ObjSystems.MChuyenFileHinhQuaByte(sDDHinh)
                    If arrImage Is Nothing Then Hinh = False Else Hinh = True
                End If
            Catch ex As Exception

            End Try

            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            command.CommandText = "GetBCPBTSSD"
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@UserName", UserName))
            command.Parameters.Add(New SqlParameter("@MsPBT", txtMaSoPBT.Text))
            command.Parameters.Add(New SqlParameter("@MsMay", cboMAY.EditValue))
            command.Parameters.Add(New SqlParameter("@NgayBDKH", dtNgayBDKH1.DateTime))
            command.Parameters.Add(New SqlParameter("@NNgu", TypeLanguage))
            If arrImage Is Nothing Then
                command.Parameters.Add("@HinhTB", SqlDbType.VarChar).Value = "NULL"
                command.Parameters.Add(New SqlParameter("@CoHinh", False))
            Else
                command.Parameters.Add(New SqlParameter("@HinhTB", arrImage))
                command.Parameters.Add(New SqlParameter("@CoHinh", True))
            End If


            Dim adapter As New SqlDataAdapter(command)
            Dim dsTmp As New DataSet()
            Try
                adapter.Fill(dsTmp)
            Catch ex As Exception

            End Try

            For i As Integer = 0 To dsTmp.Tables.Count - 1
                dtTmp = New DataTable
                dtTmp = dsTmp.Tables(i)
                Select Case i
                    Case 0
                        dtTmp.TableName = "PBT_INFO"
                    Case 1
                        dtTmp.TableName = "PBT_CV"
                    Case 2
                        dtTmp.TableName = "PBT_VTPT"
                    Case 3
                        dtTmp.TableName = "PBT_PH"
                End Select
                frmRpt.AddDataTableSource(dsTmp.Tables(i))
            Next
            frmRpt.AddDataTableSource(LanguageReportSSD())
            frmRpt.ShowDialog()

        Catch ex As Exception

        End Try

    End Sub

    Function LanguageReportSSD() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PBT_SSD"
        For i As Integer = 0 To 35
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE_PBT_SSD"
        vtbTitle.Columns(1).ColumnName = "MA_SO_PHIEU"
        vtbTitle.Columns(2).ColumnName = "TINH_TRANG_PBT"
        vtbTitle.Columns(3).ColumnName = "MS_MAY"
        vtbTitle.Columns(4).ColumnName = "TEN_MAY"
        vtbTitle.Columns(5).ColumnName = "LOAI_BT"
        vtbTitle.Columns(6).ColumnName = "MUC_UU_TIEN"
        vtbTitle.Columns(7).ColumnName = "TEN_LINE"
        vtbTitle.Columns(8).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(9).ColumnName = "NGAY_BT"
        vtbTitle.Columns(10).ColumnName = "NV_PT"
        vtbTitle.Columns(11).ColumnName = "HINH_TB"
        vtbTitle.Columns(13).ColumnName = "STT"
        vtbTitle.Columns(14).ColumnName = "NDCV"
        vtbTitle.Columns(15).ColumnName = "BO_PHAN"
        vtbTitle.Columns(16).ColumnName = "H_THANH"
        vtbTitle.Columns(17).ColumnName = "KET_QUA"
        vtbTitle.Columns(18).ColumnName = "MA_VT"
        vtbTitle.Columns(19).ColumnName = "TEN_QC"
        vtbTitle.Columns(20).ColumnName = "PART_NO"
        vtbTitle.Columns(21).ColumnName = "DVT"
        vtbTitle.Columns(22).ColumnName = "SLKH"
        vtbTitle.Columns(23).ColumnName = "SLTT"
        vtbTitle.Columns(24).ColumnName = "GHI_CHU"
        vtbTitle.Columns(25).ColumnName = "PHAN_NQL"
        vtbTitle.Columns(26).ColumnName = "TT_SBT"
        vtbTitle.Columns(27).ColumnName = "HANG_MUC_CAN"
        vtbTitle.Columns(28).ColumnName = "PHU_TRACH"
        vtbTitle.Columns(29).ColumnName = "QUAN_LY_TB"
        vtbTitle.Columns(30).ColumnName = "KY_HO_TEN"
        vtbTitle.Columns(31).ColumnName = "TMP1"
        vtbTitle.Columns(32).ColumnName = "TMP2"
        vtbTitle.Columns(33).ColumnName = "TMP3"
        vtbTitle.Columns(34).ColumnName = "TMP4"
        vtbTitle.Columns(35).ColumnName = "TMP5"


        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TIEU_DE_PBT_SSD") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "TIEU_DE_PBT_SSD", TypeLanguage)
        vRowTitle("MA_SO_PHIEU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "MA_SO_PHIEU", TypeLanguage) & " : "
        vRowTitle("TINH_TRANG_PBT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "TINH_TRANG_PBT", TypeLanguage) & " : "
        vRowTitle("MS_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "MS_MAY", TypeLanguage) & " : "
        vRowTitle("TEN_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "TEN_MAY", TypeLanguage) & " : "
        vRowTitle("LOAI_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "LOAI_BT", TypeLanguage) & " : "
        vRowTitle("MUC_UU_TIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "MUC_UU_TIEN", TypeLanguage) & " : "
        vRowTitle("TEN_LINE") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "TEN_LINE", TypeLanguage) & " : "
        vRowTitle("DIA_DIEM") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "DIA_DIEM", TypeLanguage) & " : "
        vRowTitle("NGAY_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "NGAY_BT", TypeLanguage) & " : "
        vRowTitle("NV_PT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "NV_PT", TypeLanguage) & " : "

        vRowTitle("HINH_TB") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "HINH_TB", TypeLanguage)
        vRowTitle("STT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "STT", TypeLanguage)
        vRowTitle("NDCV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "NDCV", TypeLanguage)
        vRowTitle("BO_PHAN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "TEN_BO_PHAN", TypeLanguage)
        vRowTitle("H_THANH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "H_THANH", TypeLanguage)
        vRowTitle("KET_QUA") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "KET_QUA", TypeLanguage)
        vRowTitle("MA_VT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "MA_PT", TypeLanguage)
        vRowTitle("TEN_QC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "TEN_QC", TypeLanguage)
        vRowTitle("PART_NO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "PART_NO", TypeLanguage)
        vRowTitle("DVT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "DVT", TypeLanguage)
        vRowTitle("SLKH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "R_SL_KH", TypeLanguage)
        vRowTitle("SLTT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "R_SL_TT", TypeLanguage)
        vRowTitle("GHI_CHU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "GHI_CHU", TypeLanguage) & " : "
        vRowTitle("PHAN_NQL") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "PHAN_NQL", TypeLanguage) & " : "
        vRowTitle("TT_SBT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "TT_SBT", TypeLanguage) & " : "
        vRowTitle("HANG_MUC_CAN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "HANG_MUC_CAN", TypeLanguage) & " : "
        vRowTitle("PHU_TRACH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "PHU_TRACH", TypeLanguage)
        vRowTitle("QUAN_LY_TB") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "QUAN_LY_TB", TypeLanguage)
        vRowTitle("KY_HO_TEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_SSD", "KY_HO_TEN", TypeLanguage)


        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
#End Region

#Region " In PBT ADC"
    Private Sub InPBTADC()
        Try
            Dim dtTmp = New DataTable
            Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
            Dim sDDHinh As String = ""
            Dim Hinh As Boolean = False


            frmRpt.rptName = "rptPHIEU_BAO_TRI_ADC"
            SQLString = "0Design"
            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            command.CommandText = "GetBCPBTADC"
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@UserName", UserName))
            command.Parameters.Add(New SqlParameter("@MsPBT", txtMaSoPBT.Text))
            command.Parameters.Add(New SqlParameter("@MsMay", cboMAY.EditValue))
            command.Parameters.Add(New SqlParameter("@NgayBDKH", dtNgayBDKH1.DateTime))
            command.Parameters.Add(New SqlParameter("@NNgu", TypeLanguage))

            Dim adapter As New SqlDataAdapter(command)
            Dim dsTmp As New DataSet()
            Try
                adapter.Fill(dsTmp)
            Catch ex As Exception

            End Try

            For i As Integer = 0 To dsTmp.Tables.Count - 1
                dtTmp = New DataTable
                dtTmp = dsTmp.Tables(i)
                Select Case i
                    Case 0
                        dtTmp.TableName = "PBT_ADC_INFO"
                    Case 1
                        dtTmp.TableName = "PBT_ADC_CV"
                    Case 2
                        dtTmp.TableName = "PBT_ADC_NS"
                    Case 3
                        dtTmp.TableName = "PBT_ADC_PTVT"
                    Case 4
                        dtTmp.TableName = "PBT_ADC_TTPBT"
                End Select
                frmRpt.AddDataTableSource(dsTmp.Tables(i))
            Next
            frmRpt.AddDataTableSource(LanguageReportADC())
            frmRpt.ShowDialog()

        Catch ex As Exception

        End Try

    End Sub

    Function LanguageReportADC() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PBT_ADC"
        For i As Integer = 0 To 52
            vtbTitle.Columns.Add()
        Next
        Try
            vtbTitle.Columns(0).ColumnName = "TIEU_DE_PBT_ADC"
            vtbTitle.Columns(1).ColumnName = "MAU_SO"
            vtbTitle.Columns(2).ColumnName = "LAN_BH"
            vtbTitle.Columns(3).ColumnName = "NGAY_BH"
            vtbTitle.Columns(4).ColumnName = "PHIEU_BT"
            vtbTitle.Columns(5).ColumnName = "NGUOI_LAP"
            vtbTitle.Columns(6).ColumnName = "NGAY_LAP"
            vtbTitle.Columns(7).ColumnName = "MS_MAY"
            vtbTitle.Columns(8).ColumnName = "TEN_MAY"
            vtbTitle.Columns(9).ColumnName = "TTRANG_BT"
            vtbTitle.Columns(10).ColumnName = "MO_TA"
            vtbTitle.Columns(11).ColumnName = "HINH_THUC_BT"
            vtbTitle.Columns(13).ColumnName = "LOAI_BT"
            vtbTitle.Columns(14).ColumnName = "DIA_DIEM"
            vtbTitle.Columns(15).ColumnName = "LY_DO"
            vtbTitle.Columns(16).ColumnName = "KE_HOACH"
            vtbTitle.Columns(17).ColumnName = "NGAY_BD"
            vtbTitle.Columns(18).ColumnName = "NGAY_KT"
            vtbTitle.Columns(19).ColumnName = "BO_PHAN_CP"
            vtbTitle.Columns(20).ColumnName = "DANH_SACH_CV"

            vtbTitle.Columns(21).ColumnName = "CONG_VIEC"
            vtbTitle.Columns(22).ColumnName = "BO_PHAN"
            vtbTitle.Columns(23).ColumnName = "CACH_THUC_HIEN"
            vtbTitle.Columns(24).ColumnName = "SP_KH"
            vtbTitle.Columns(25).ColumnName = "GHI_CHU"
            vtbTitle.Columns(26).ColumnName = "HOAN_THANH"
            vtbTitle.Columns(27).ColumnName = "DS_NVIEN"
            vtbTitle.Columns(28).ColumnName = "HO_TEN"
            vtbTitle.Columns(29).ColumnName = "BAN_TO"
            vtbTitle.Columns(30).ColumnName = "TU_NGAY"
            vtbTitle.Columns(31).ColumnName = "DEN_NGAY"
            vtbTitle.Columns(32).ColumnName = "DS_PHU_TUNG"
            vtbTitle.Columns(33).ColumnName = "MS_PT"
            vtbTitle.Columns(34).ColumnName = "TEN_PT"
            vtbTitle.Columns(35).ColumnName = "SL_KH"
            vtbTitle.Columns(36).ColumnName = "SL_TT"
            vtbTitle.Columns(37).ColumnName = "DVT"
            vtbTitle.Columns(38).ColumnName = "TT_TRUOC_SAU_BT"
            vtbTitle.Columns(39).ColumnName = "THONG_SO_DO"
            vtbTitle.Columns(40).ColumnName = "THIET_BI_DO"
            vtbTitle.Columns(41).ColumnName = "TT_TRUOC_BT"
            vtbTitle.Columns(42).ColumnName = "TT_SAU_BT"
            vtbTitle.Columns(43).ColumnName = "KY_TEN"
            vtbTitle.Columns(44).ColumnName = "GD_NM"
            vtbTitle.Columns(45).ColumnName = "TP_CD"

            vtbTitle.Columns(46).ColumnName = "SAN_XUAT"
            vtbTitle.Columns(47).ColumnName = "TMP"
            vtbTitle.Columns(48).ColumnName = "TMP1"
            vtbTitle.Columns(49).ColumnName = "TMP2"
            vtbTitle.Columns(50).ColumnName = "TMP3"
            vtbTitle.Columns(51).ColumnName = "TMP4"
            vtbTitle.Columns(52).ColumnName = "TMP5"


            Dim vRowTitle As DataRow = vtbTitle.NewRow()
            vRowTitle("TIEU_DE_PBT_ADC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TIEU_DE_PBT_ADC", TypeLanguage)
            vRowTitle("MAU_SO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "MAU_SO", TypeLanguage)
            vRowTitle("LAN_BH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "LAN_BH", TypeLanguage)
            vRowTitle("NGAY_BH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "NGAY_BH", TypeLanguage)
            vRowTitle("PHIEU_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "PHIEU_BT", TypeLanguage)
            vRowTitle("NGUOI_LAP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "NGUOI_LAP", TypeLanguage)
            vRowTitle("NGAY_LAP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "NGAY_LAP", TypeLanguage)
            vRowTitle("MS_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "MS_MAY", TypeLanguage)
            vRowTitle("TEN_MAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TEN_MAY", TypeLanguage)
            vRowTitle("TTRANG_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TTRANG_BT", TypeLanguage)
            vRowTitle("MO_TA") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "MO_TA", TypeLanguage)
            vRowTitle("HINH_THUC_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "HINH_THUC_BT", TypeLanguage)
            vRowTitle("LOAI_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "LOAI_BT", TypeLanguage)
            vRowTitle("DIA_DIEM") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "DIA_DIEM", TypeLanguage)
            vRowTitle("LY_DO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "LY_DO", TypeLanguage)
            vRowTitle("KE_HOACH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "KE_HOACH", TypeLanguage)
            vRowTitle("NGAY_BD") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "NGAY_BD", TypeLanguage)
            vRowTitle("NGAY_KT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "NGAY_KT", TypeLanguage)
            vRowTitle("BO_PHAN_CP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "BO_PHAN_CP", TypeLanguage)
            vRowTitle("DANH_SACH_CV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "DANH_SACH_CV", TypeLanguage)
            vRowTitle("CONG_VIEC") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "CONG_VIEC", TypeLanguage)
            vRowTitle("BO_PHAN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "BO_PHAN", TypeLanguage)
            vRowTitle("CACH_THUC_HIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "CACH_THUC_HIEN", TypeLanguage)
            vRowTitle("SP_KH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "SP_KH", TypeLanguage)
            vRowTitle("GHI_CHU") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "GHI_CHU", TypeLanguage)
            vRowTitle("HOAN_THANH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "HOAN_THANH", TypeLanguage)
            vRowTitle("DS_NVIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "DS_NVIEN", TypeLanguage)
            vRowTitle("HO_TEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "HO_TEN", TypeLanguage)
            vRowTitle("BAN_TO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "BAN_TO", TypeLanguage)
            vRowTitle("TU_NGAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TU_NGAY", TypeLanguage)
            vRowTitle("DEN_NGAY") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "DEN_NGAY", TypeLanguage)
            vRowTitle("DS_PHU_TUNG") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "DS_PHU_TUNG", TypeLanguage)
            vRowTitle("MS_PT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "MS_PT", TypeLanguage)
            vRowTitle("TEN_PT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TEN_PT", TypeLanguage)
            vRowTitle("SL_KH") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "SL_KH", TypeLanguage)
            vRowTitle("SL_TT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "SL_TT", TypeLanguage)
            vRowTitle("DVT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "DVT", TypeLanguage)
            vRowTitle("TT_TRUOC_SAU_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TT_TRUOC_SAU_BT", TypeLanguage)
            vRowTitle("THONG_SO_DO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "THONG_SO_DO", TypeLanguage)
            vRowTitle("THIET_BI_DO") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "THIET_BI_DO", TypeLanguage)
            vRowTitle("TT_TRUOC_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TT_TRUOC_BT", TypeLanguage)
            vRowTitle("TT_SAU_BT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TT_SAU_BT", TypeLanguage)
            vRowTitle("KY_TEN") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "KY_TEN", TypeLanguage)
            vRowTitle("GD_NM") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "GD_NM", TypeLanguage)
            vRowTitle("TP_CD") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TP_CD", TypeLanguage)
            vRowTitle("SAN_XUAT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "SAN_XUAT", TypeLanguage)
            vRowTitle("TMP") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TMP", TypeLanguage)
            vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TMP1", TypeLanguage)
            vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TMP2", TypeLanguage)
            vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TMP3", TypeLanguage)
            vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TMP4", TypeLanguage)
            vRowTitle("TMP5") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_ADC", "TMP5", TypeLanguage)

            vtbTitle.Rows.Add(vRowTitle)
        Catch ex As Exception

        End Try
        Return vtbTitle
    End Function
#End Region

    Dim _iLCV As Integer
    Public Property iLCV() As Integer
        Get
            Return _iLCV
        End Get
        Set(ByVal value As Integer)
            _iLCV = value
        End Set
    End Property
#Region " In PBT VINAONE"
    Private Sub InPBTVINAONE()
        Try
            Dim dtTmp = New DataTable
            Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
            Dim sDDHinh As String = ""
            Dim Hinh As Boolean = False
            Dim sLCV As String = ""
            _iLCV = 0


            frmRpt.rptName = "rptPHIEU_BAO_TRI_VNO"

            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            command.CommandText = "GetBCPBTriVNO"



            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@UserName", UserName))
            command.Parameters.Add(New SqlParameter("@MsPBT", txtMaSoPBT.Text))
            command.Parameters.Add(New SqlParameter("@NgayBDKH", dtNgayBDKH1.DateTime))
            command.Parameters.Add(New SqlParameter("@NNgu", TypeLanguage))

            Dim adapter As New SqlDataAdapter(command)
            Dim dsTmp As New DataSet()
            Try
                adapter.Fill(dsTmp)
            Catch ex As Exception

            End Try

            For i As Integer = 0 To dsTmp.Tables.Count - 1
                dtTmp = New DataTable
                dtTmp = dsTmp.Tables(i)
                Select Case i
                    Case 0
                        dtTmp.TableName = "PBT_BARIA_INFO"
                    Case 1
                        dtTmp.TableName = "PBT_BARIA_CV"
                    Case 2
                        dtTmp.TableName = "PBT_BARIA_CV_TRONG"
                    Case 3
                        dtTmp.TableName = "PBT_BARIA_PTVT"
                    Case 4
                        dtTmp.TableName = "PBT_BARIA_DV"
                End Select
                frmRpt.AddDataTableSource(dsTmp.Tables(i))
            Next
            frmRpt.AddDataTableSource(LanguageReportBARIA(sLCV))
            SQLString = "0Design"
            frmRpt.ShowDialog()
            SQLString = ""
        Catch ex As Exception

        End Try

    End Sub


#End Region

#Region " In PBT BARIA"
    Private Sub InPBTBARIA()
        Try
            Dim dtTmp = New DataTable
            Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
            Dim sDDHinh As String = ""
            Dim Hinh As Boolean = False
            Dim sLCV As String = ""
            _iLCV = 0

            If Modules.sPrivate = "BARIA" Then
                frmRpt.rptName = "rptPHIEU_BAO_TRI_BARIA"
            ElseIf Modules.sPrivate = "VECO" Then
                frmRpt.rptName = "rptPHIEU_BAO_TRI_VECO"
            ElseIf Modules.sPrivate = "TRUNGNGUYEN" Then
                frmRpt.rptName = "rptPHIEU_BAO_TRI_TN"
            ElseIf Modules.sPrivate = "VIETROLL" Then
                frmRpt.rptName = "rptPHIEU_BAO_TRI_VIETROLL"
            ElseIf Modules.sPrivate = "PILMICO" Then
                frmRpt.rptName = "rptPHIEU_BAO_TRI_PIL"
            Else
                frmRpt.rptName = "rptPHIEU_BAO_TRI_NT"
            End If


            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            If Modules.sPrivate = "VECO" Then
                command.CommandText = "GetBCPBTVECO"
            ElseIf Modules.sPrivate = "VIETROLL" Then
                command.CommandText = "GetBCPBTVIETROLL"
            ElseIf Modules.sPrivate = "BARIA" Then
                command.CommandText = "GetBCPBTBARIA"
            Else
                command.CommandText = "GetBCPBTri"
            End If


            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@UserName", UserName))
            command.Parameters.Add(New SqlParameter("@MsPBT", txtMaSoPBT.Text))
            command.Parameters.Add(New SqlParameter("@NgayBDKH", dtNgayBDKH1.DateTime))
            command.Parameters.Add(New SqlParameter("@NNgu", TypeLanguage))

            Dim adapter As New SqlDataAdapter(command)
            Dim dsTmp As New DataSet()
            Try
                adapter.Fill(dsTmp)
            Catch ex As Exception

            End Try
            'H_GET_TINH_TRANG_AND_HINH_THUC_PHIEU_BAO_TRI

            For i As Integer = 0 To dsTmp.Tables.Count - 1
                dtTmp = New DataTable
                dtTmp = dsTmp.Tables(i)
                Select Case i
                    Case 0
                        dtTmp.TableName = "PBT_BARIA_INFO"
                    Case 1
                        dtTmp.TableName = "PBT_BARIA_CV"
                    Case 2
                        dtTmp.TableName = "PBT_BARIA_CV_TRONG"
                    Case 3
                        dtTmp.TableName = "PBT_BARIA_PTVT"
                    Case 4
                        dtTmp.TableName = "PBT_BARIA_DV"
                End Select
                frmRpt.AddDataTableSource(dsTmp.Tables(i))
            Next
            frmRpt.AddDataTableSource(LanguageReportBARIA(sLCV))
            SQLString = "0Design"
            frmRpt.ShowDialog()
            SQLString = ""
        Catch ex As Exception
        End Try
    End Sub

    Function LanguageReportBARIA(sLCV As String) As DataTable
        Dim sBC As String = ""

        If Modules.sPrivate = "BARIA" Then
            sBC = "rptPHIEU_BAO_TRI_BARIA"
        Else
            sBC = "rptPHIEU_BAO_TRI_NT"
        End If

        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PBT_BARIA"
        For i As Integer = 0 To 62
            vtbTitle.Columns.Add()
        Next
        Try
            vtbTitle.Columns(0).ColumnName = "PHIEU_CONG_TAC"
            vtbTitle.Columns(1).ColumnName = "MAU_SO"
            vtbTitle.Columns(2).ColumnName = "MAU_SO1"
            vtbTitle.Columns(3).ColumnName = "LAN_BH"
            vtbTitle.Columns(4).ColumnName = "LAN_BH1"
            vtbTitle.Columns(5).ColumnName = "NGAY_BH"
            vtbTitle.Columns(6).ColumnName = "NGAY_BH1"
            vtbTitle.Columns(7).ColumnName = "PHIEU_CT"
            vtbTitle.Columns(8).ColumnName = "NGAY_LAP"
            vtbTitle.Columns(9).ColumnName = "LOAI_BT"
            vtbTitle.Columns(10).ColumnName = "PHIEU_YC"
            vtbTitle.Columns(11).ColumnName = "MUC_UT"
            vtbTitle.Columns(12).ColumnName = "NDYC"
            vtbTitle.Columns(13).ColumnName = "MS_TB"
            vtbTitle.Columns(14).ColumnName = "TEN_TB"
            vtbTitle.Columns(15).ColumnName = "DDIEM"
            vtbTitle.Columns(16).ColumnName = "BPCPHI"
            vtbTitle.Columns(17).ColumnName = "NGUOI_LAP"
            vtbTitle.Columns(18).ColumnName = "KE_HOACH_TH"
            vtbTitle.Columns(19).ColumnName = "STT"
            vtbTitle.Columns(20).ColumnName = "BPHAN"
            vtbTitle.Columns(21).ColumnName = "NDTHIEN"
            vtbTitle.Columns(22).ColumnName = "NHAN_SU"
            vtbTitle.Columns(23).ColumnName = "DUNG_CU"
            vtbTitle.Columns(24).ColumnName = "GIO"
            vtbTitle.Columns(25).ColumnName = "BAT_DAU"
            vtbTitle.Columns(26).ColumnName = "KET_THUC"
            vtbTitle.Columns(27).ColumnName = "THUC_TE_TH"
            vtbTitle.Columns(28).ColumnName = "VT_CAN_THIET"
            vtbTitle.Columns(29).ColumnName = "MA_VT"
            vtbTitle.Columns(30).ColumnName = "TEN_VT"
            vtbTitle.Columns(31).ColumnName = "PART_NO"
            vtbTitle.Columns(32).ColumnName = "QUI_CACH"
            vtbTitle.Columns(33).ColumnName = "DVT"
            vtbTitle.Columns(34).ColumnName = "SL_KH"
            vtbTitle.Columns(35).ColumnName = "SL_TT"
            vtbTitle.Columns(36).ColumnName = "DV_THUE_NGOAI"
            vtbTitle.Columns(37).ColumnName = "LOAI_DV"
            vtbTitle.Columns(38).ColumnName = "NOI_DUNG_DV"
            vtbTitle.Columns(39).ColumnName = "NCC"
            vtbTitle.Columns(40).ColumnName = "SLUONG"
            vtbTitle.Columns(41).ColumnName = "DON_GIA"
            vtbTitle.Columns(42).ColumnName = "THANH_TIEN"
            vtbTitle.Columns(43).ColumnName = "DE_XUAT_KHAC"
            vtbTitle.Columns(44).ColumnName = "KET_THUC1"
            vtbTitle.Columns(45).ColumnName = "NGUOI_TH"
            vtbTitle.Columns(46).ColumnName = "QL_THUC_THI"
            vtbTitle.Columns(47).ColumnName = "BEN_YC"
            vtbTitle.Columns(48).ColumnName = "BEN_KH"
            vtbTitle.Columns(49).ColumnName = "TMP1"
            vtbTitle.Columns(50).ColumnName = "TMP2"
            vtbTitle.Columns(51).ColumnName = "TMP3"
            vtbTitle.Columns(52).ColumnName = "TMP4"
            vtbTitle.Columns(53).ColumnName = "TMP5"
            vtbTitle.Columns(54).ColumnName = "NGAY_BD_TT"
            vtbTitle.Columns(55).ColumnName = "NGAY_KT_TT"
            vtbTitle.Columns(56).ColumnName = "SO_PHUT_TT"
            vtbTitle.Columns(57).ColumnName = "TMP6"
            vtbTitle.Columns(58).ColumnName = "TMP7"
            vtbTitle.Columns(59).ColumnName = "TMP8"
            vtbTitle.Columns(60).ColumnName = "TMP9"
            vtbTitle.Columns(61).ColumnName = "TMP10"
            vtbTitle.Columns(62).ColumnName = "TMP11"




            Dim vRowTitle As DataRow = vtbTitle.NewRow()
            vRowTitle("PHIEU_CONG_TAC") = ObjLanguages.GetLanguage(ModuleName, sBC, "PHIEU_CONG_TAC", TypeLanguage)
            vRowTitle("MAU_SO") = ObjLanguages.GetLanguage(ModuleName, sBC, "MAU_SO", TypeLanguage)
            vRowTitle("MAU_SO1") = ObjLanguages.GetLanguage(ModuleName, sBC, "MAU_SO1", TypeLanguage)
            vRowTitle("LAN_BH") = ObjLanguages.GetLanguage(ModuleName, sBC, "LAN_BH", TypeLanguage)
            vRowTitle("LAN_BH1") = ObjLanguages.GetLanguage(ModuleName, sBC, "LAN_BH1", TypeLanguage)
            vRowTitle("NGAY_BH") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_BH", TypeLanguage)
            vRowTitle("NGAY_BH1") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_BH1", TypeLanguage)
            vRowTitle("PHIEU_CT") = ObjLanguages.GetLanguage(ModuleName, sBC, "PHIEU_CT", TypeLanguage)
            vRowTitle("NGAY_LAP") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_LAP", TypeLanguage)
            vRowTitle("LOAI_BT") = ObjLanguages.GetLanguage(ModuleName, sBC, "LOAI_BT", TypeLanguage)
            vRowTitle("PHIEU_YC") = ObjLanguages.GetLanguage(ModuleName, sBC, "PHIEU_YC", TypeLanguage)
            vRowTitle("MUC_UT") = ObjLanguages.GetLanguage(ModuleName, sBC, "MUC_UT", TypeLanguage)
            vRowTitle("NDYC") = ObjLanguages.GetLanguage(ModuleName, sBC, "NDYC", TypeLanguage)
            vRowTitle("MS_TB") = ObjLanguages.GetLanguage(ModuleName, sBC, "MS_TB", TypeLanguage)
            vRowTitle("TEN_TB") = ObjLanguages.GetLanguage(ModuleName, sBC, "TEN_TB", TypeLanguage)
            vRowTitle("DDIEM") = ObjLanguages.GetLanguage(ModuleName, sBC, "DDIEM", TypeLanguage)
            vRowTitle("BPCPHI") = ObjLanguages.GetLanguage(ModuleName, sBC, "BPCPHI", TypeLanguage)
            vRowTitle("NGUOI_LAP") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGUOI_LAP", TypeLanguage)
            vRowTitle("KE_HOACH_TH") = ObjLanguages.GetLanguage(ModuleName, sBC, "KE_HOACH_TH", TypeLanguage)
            vRowTitle("STT") = ObjLanguages.GetLanguage(ModuleName, sBC, "STT", TypeLanguage)
            vRowTitle("BPHAN") = ObjLanguages.GetLanguage(ModuleName, sBC, "BPHAN", TypeLanguage)
            vRowTitle("NDTHIEN") = ObjLanguages.GetLanguage(ModuleName, sBC, "NDTHIEN", TypeLanguage)

            'If (Modules.sPrivate = "VECO") Then
            '    vRowTitle("NHAN_SU") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGUOI_THIEN", TypeLanguage)
            'Else
            vRowTitle("NHAN_SU") = ObjLanguages.GetLanguage(ModuleName, sBC, "NHAN_SU", TypeLanguage)
            'End If

            vRowTitle("DUNG_CU") = ObjLanguages.GetLanguage(ModuleName, sBC, "DUNG_CU", TypeLanguage)
            vRowTitle("GIO") = ObjLanguages.GetLanguage(ModuleName, sBC, "GIO", TypeLanguage)
            vRowTitle("BAT_DAU") = ObjLanguages.GetLanguage(ModuleName, sBC, "BAT_DAU", TypeLanguage)
            vRowTitle("KET_THUC") = ObjLanguages.GetLanguage(ModuleName, sBC, "KET_THUC", TypeLanguage)
            vRowTitle("THUC_TE_TH") = ObjLanguages.GetLanguage(ModuleName, sBC, "THUC_TE_TH", TypeLanguage)
            vRowTitle("VT_CAN_THIET") = ObjLanguages.GetLanguage(ModuleName, sBC, "VT_CAN_THIET", TypeLanguage)
            vRowTitle("MA_VT") = ObjLanguages.GetLanguage(ModuleName, sBC, "MA_VT", TypeLanguage)
            vRowTitle("TEN_VT") = ObjLanguages.GetLanguage(ModuleName, sBC, "TEN_VT", TypeLanguage)
            vRowTitle("PART_NO") = ObjLanguages.GetLanguage(ModuleName, sBC, "PART_NO", TypeLanguage)
            vRowTitle("QUI_CACH") = ObjLanguages.GetLanguage(ModuleName, sBC, "QUI_CACH", TypeLanguage)
            vRowTitle("DVT") = ObjLanguages.GetLanguage(ModuleName, sBC, "DVT", TypeLanguage)
            vRowTitle("SL_KH") = ObjLanguages.GetLanguage(ModuleName, sBC, "SL_KH", TypeLanguage)
            vRowTitle("SL_TT") = ObjLanguages.GetLanguage(ModuleName, sBC, "SL_TT", TypeLanguage)
            vRowTitle("DV_THUE_NGOAI") = ObjLanguages.GetLanguage(ModuleName, sBC, "DV_THUE_NGOAI", TypeLanguage)
            vRowTitle("LOAI_DV") = ObjLanguages.GetLanguage(ModuleName, sBC, "LOAI_DV", TypeLanguage)
            vRowTitle("NOI_DUNG_DV") = ObjLanguages.GetLanguage(ModuleName, sBC, "NOI_DUNG_DV", TypeLanguage)
            vRowTitle("NCC") = ObjLanguages.GetLanguage(ModuleName, sBC, "NCC", TypeLanguage)
            vRowTitle("SLUONG") = ObjLanguages.GetLanguage(ModuleName, sBC, "SLUONG", TypeLanguage)
            vRowTitle("DON_GIA") = ObjLanguages.GetLanguage(ModuleName, sBC, "DON_GIA", TypeLanguage)
            vRowTitle("THANH_TIEN") = ObjLanguages.GetLanguage(ModuleName, sBC, "THANH_TIEN", TypeLanguage)
            vRowTitle("DE_XUAT_KHAC") = ObjLanguages.GetLanguage(ModuleName, sBC, "DE_XUAT_KHAC", TypeLanguage)
            vRowTitle("KET_THUC1") = ObjLanguages.GetLanguage(ModuleName, sBC, "KET_THUC1", TypeLanguage)
            vRowTitle("NGUOI_TH") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGUOI_TH", TypeLanguage)
            vRowTitle("QL_THUC_THI") = ObjLanguages.GetLanguage(ModuleName, sBC, "QL_THUC_THI", TypeLanguage)
            vRowTitle("BEN_YC") = ObjLanguages.GetLanguage(ModuleName, sBC, "BEN_YC", TypeLanguage)
            vRowTitle("BEN_KH") = ObjLanguages.GetLanguage(ModuleName, sBC, "BEN_KH", TypeLanguage)
            vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGSAT", TypeLanguage)
            vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_BD_KH", TypeLanguage)
            vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_KT_KH", TypeLanguage)
            If (Modules.sPrivate = "VECO") Then
                vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, sBC, "Remark", TypeLanguage)
            Else
                vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP4", TypeLanguage)
            End If
            If (Modules.sPrivate = "VECO") Then
                vRowTitle("TMP5") = ObjLanguages.GetLanguage(ModuleName, sBC, "LblThuocloaicongviec", TypeLanguage) + " : " + sLCV
            Else
                vRowTitle("TMP5") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP5", TypeLanguage)
            End If


            vRowTitle("NGAY_BD_TT") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_BD_TT", TypeLanguage)
            vRowTitle("NGAY_KT_TT") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_KT_TT", TypeLanguage)
            vRowTitle("SO_PHUT_TT") = ObjLanguages.GetLanguage(ModuleName, sBC, "SO_PHUT_TT", TypeLanguage)



            vRowTitle("TMP6") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP6", TypeLanguage)
            vRowTitle("TMP7") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP7", TypeLanguage)
            vRowTitle("TMP8") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP8", TypeLanguage)
            vRowTitle("TMP9") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP9", TypeLanguage)
            vRowTitle("TMP10") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP10", TypeLanguage)
            vRowTitle("TMP11") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP11", TypeLanguage)





            vtbTitle.Rows.Add(vRowTitle)
        Catch ex As Exception

        End Try
        Return vtbTitle
    End Function
#End Region

#Region " In PBT VINHHOAN"
    Private Sub InPBTVINHHOAN()
        Try
            Dim dtTmp = New DataTable
            Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()


            frmRpt.rptName = "rptPHIEU_BAO_TRI_VH"
            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            command.CommandText = "GetBCPBTVinhHoan"
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@UserName", UserName))
            command.Parameters.Add(New SqlParameter("@MsPBT", txtMaSoPBT.Text))
            command.Parameters.Add(New SqlParameter("@NgayBDKH", dtNgayBDKH1.DateTime
                                                    ))
            command.Parameters.Add(New SqlParameter("@NNgu", TypeLanguage))

            Dim adapter As New SqlDataAdapter(command)
            Dim dsTmp As New DataSet()
            Try
                adapter.Fill(dsTmp)
            Catch ex As Exception

            End Try

            For i As Integer = 0 To dsTmp.Tables.Count - 1
                dtTmp = New DataTable
                dtTmp = dsTmp.Tables(i)
                Select Case i
                    Case 0
                        dtTmp.TableName = "PBT_VH_INFO"
                    Case 1
                        dtTmp.TableName = "PBT_VH_CV"
                    Case 2
                        dtTmp.TableName = "PBT_VH_PTVT"
                    Case 3
                        dtTmp.TableName = "PBT_VH_DV"
                End Select
                frmRpt.AddDataTableSource(dsTmp.Tables(i))
            Next
            frmRpt.AddDataTableSource(LanguageReportVINHHOAN())
            frmRpt.AddDataTableSource(LanguageChiPhiBT())

            SQLString = "0Design"
            frmRpt.ShowDialog()
            SQLString = ""
        Catch ex As Exception

        End Try

    End Sub

    Function LanguageReportVINHHOAN() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PBT_VH"
        For i As Integer = 0 To 53
            vtbTitle.Columns.Add()
        Next
        Try
            vtbTitle.Columns(0).ColumnName = "PHIEU_SUA_CHUA"
            vtbTitle.Columns(1).ColumnName = "MAU_SO"
            vtbTitle.Columns(2).ColumnName = "NGAY_HL"
            vtbTitle.Columns(3).ColumnName = "LAN_SOAT_XET"

            vtbTitle.Columns(4).ColumnName = "MS_PHIEU"
            vtbTitle.Columns(5).ColumnName = "MS_YC"
            vtbTitle.Columns(6).ColumnName = "NGAY_LAP"

            vtbTitle.Columns(7).ColumnName = "MS_TB"
            vtbTitle.Columns(8).ColumnName = "TEN_TB"

            vtbTitle.Columns(9).ColumnName = "MA_SCADA"
            vtbTitle.Columns(10).ColumnName = "TINH_TRANG"
            vtbTitle.Columns(11).ColumnName = "BPQL"
            vtbTitle.Columns(12).ColumnName = "LOAI_BT"

            vtbTitle.Columns(13).ColumnName = "LY_DO_BT"
            vtbTitle.Columns(14).ColumnName = "DIA_DIEM"

            vtbTitle.Columns(15).ColumnName = "NGAY_BD"
            vtbTitle.Columns(16).ColumnName = "NGAY_KT "


            vtbTitle.Columns(17).ColumnName = "MO_TA_TINH_TRANG"
            vtbTitle.Columns(18).ColumnName = "TINH_TRANG_THEO_YC"

            vtbTitle.Columns(19).ColumnName = "STT"
            vtbTitle.Columns(20).ColumnName = "BPHAN"
            vtbTitle.Columns(21).ColumnName = "NDTHIEN"
            vtbTitle.Columns(22).ColumnName = "NGUOI_THUC_HIEN"
            vtbTitle.Columns(23).ColumnName = "DUNG_CU"

            vtbTitle.Columns(24).ColumnName = "NOI_DUNG_SUA_CHUA"
            vtbTitle.Columns(25).ColumnName = "BIEN_PHAP_AN_TOAN"
            vtbTitle.Columns(26).ColumnName = "MO_TA_SUA_CHUA"


            vtbTitle.Columns(27).ColumnName = "TG_KH"
            vtbTitle.Columns(28).ColumnName = "TG_TT"



            vtbTitle.Columns(29).ColumnName = "MS_VT"
            vtbTitle.Columns(30).ColumnName = "TEN_VT"

            vtbTitle.Columns(31).ColumnName = "VAT_TU_PHU_TUNG_CAN_THIET"

            vtbTitle.Columns(32).ColumnName = "QUY_CACH"
            vtbTitle.Columns(33).ColumnName = "DVT"
            vtbTitle.Columns(34).ColumnName = "SL_KH"
            vtbTitle.Columns(35).ColumnName = "SL_TT"

            vtbTitle.Columns(36).ColumnName = "DV_THUE_NGOAI"

            vtbTitle.Columns(37).ColumnName = "NOI_DUNG"

            vtbTitle.Columns(38).ColumnName = "NOI_DUNG_DV"
            vtbTitle.Columns(39).ColumnName = "NCC"
            vtbTitle.Columns(40).ColumnName = "SLUONG"
            vtbTitle.Columns(41).ColumnName = "DON_GIA"
            vtbTitle.Columns(42).ColumnName = "THANH_TIEN"

            vtbTitle.Columns(43).ColumnName = "GHI_CHU"

            vtbTitle.Columns(44).ColumnName = "BIEN_PHAP_PHONG_NGUA"
            vtbTitle.Columns(45).ColumnName = "CHI_PHI"
            vtbTitle.Columns(46).ColumnName = "NV_SC"
            vtbTitle.Columns(47).ColumnName = "DV_SD"
            vtbTitle.Columns(48).ColumnName = "KY_TEN"
            vtbTitle.Columns(49).ColumnName = "TMP1"
            vtbTitle.Columns(50).ColumnName = "TMP2"
            vtbTitle.Columns(51).ColumnName = "TMP3"
            vtbTitle.Columns(52).ColumnName = "TMP4"
            vtbTitle.Columns(53).ColumnName = "TMP5"



            Dim vRowTitle As DataRow = vtbTitle.NewRow()
            Dim sBC As String = "rptPHIEU_BAO_TRI_VH"

            vRowTitle("PHIEU_SUA_CHUA") = ObjLanguages.GetLanguage(ModuleName, sBC, "PHIEU_SUA_CHUA", TypeLanguage)
            vRowTitle("MAU_SO") = ObjLanguages.GetLanguage(ModuleName, sBC, "MAU_SO", TypeLanguage)
            vRowTitle("NGAY_HL") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_HL", TypeLanguage)
            vRowTitle("LAN_SOAT_XET") = ObjLanguages.GetLanguage(ModuleName, sBC, "LAN_SOAT_XET", TypeLanguage)
            vRowTitle("MS_PHIEU") = ObjLanguages.GetLanguage(ModuleName, sBC, "MS_PHIEU", TypeLanguage)
            vRowTitle("MS_YC") = ObjLanguages.GetLanguage(ModuleName, sBC, "MS_YC", TypeLanguage)
            vRowTitle("NGAY_LAP") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_LAP", TypeLanguage)
            vRowTitle("MS_TB") = ObjLanguages.GetLanguage(ModuleName, sBC, "MS_TB", TypeLanguage)
            vRowTitle("TEN_TB") = ObjLanguages.GetLanguage(ModuleName, sBC, "TEN_TB", TypeLanguage)
            vRowTitle("MA_SCADA") = ObjLanguages.GetLanguage(ModuleName, sBC, "MA_SCADA", TypeLanguage)
            vRowTitle("TINH_TRANG") = ObjLanguages.GetLanguage(ModuleName, sBC, "TINH_TRANG", TypeLanguage)
            vRowTitle("BPQL") = ObjLanguages.GetLanguage(ModuleName, sBC, "BPQL", TypeLanguage)
            vRowTitle("LOAI_BT") = ObjLanguages.GetLanguage(ModuleName, sBC, "LOAI_BT", TypeLanguage)
            vRowTitle("LY_DO_BT") = ObjLanguages.GetLanguage(ModuleName, sBC, "LY_DO_BT", TypeLanguage)
            vRowTitle("DIA_DIEM") = ObjLanguages.GetLanguage(ModuleName, sBC, "DIA_DIEM", TypeLanguage)
            vRowTitle("NGAY_BD") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_BD", TypeLanguage)
            vRowTitle("NGAY_KT ") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGAY_KT ", TypeLanguage)
            vRowTitle("MO_TA_TINH_TRANG") = ObjLanguages.GetLanguage(ModuleName, sBC, "MO_TA_TINH_TRANG", TypeLanguage)
            vRowTitle("TINH_TRANG_THEO_YC") = ObjLanguages.GetLanguage(ModuleName, sBC, "TINH_TRANG_THEO_YC", TypeLanguage)
            vRowTitle("STT") = ObjLanguages.GetLanguage(ModuleName, sBC, "STT", TypeLanguage)
            vRowTitle("BPHAN") = ObjLanguages.GetLanguage(ModuleName, sBC, "BPHAN", TypeLanguage)
            vRowTitle("NDTHIEN") = ObjLanguages.GetLanguage(ModuleName, sBC, "NDTHIEN", TypeLanguage)
            vRowTitle("NGUOI_THUC_HIEN") = ObjLanguages.GetLanguage(ModuleName, sBC, "NGUOI_THUC_HIEN", TypeLanguage)
            vRowTitle("DUNG_CU") = ObjLanguages.GetLanguage(ModuleName, sBC, "DUNG_CU", TypeLanguage)
            vRowTitle("NOI_DUNG_SUA_CHUA") = ObjLanguages.GetLanguage(ModuleName, sBC, "NOI_DUNG_SUA_CHUA", TypeLanguage)
            vRowTitle("BIEN_PHAP_AN_TOAN") = ObjLanguages.GetLanguage(ModuleName, sBC, "BIEN_PHAP_AN_TOAN", TypeLanguage)
            vRowTitle("MO_TA_SUA_CHUA") = ObjLanguages.GetLanguage(ModuleName, sBC, "MO_TA_SUA_CHUA", TypeLanguage)
            vRowTitle("TG_KH") = ObjLanguages.GetLanguage(ModuleName, sBC, "TG_KH", TypeLanguage)
            vRowTitle("TG_TT") = ObjLanguages.GetLanguage(ModuleName, sBC, "TG_TT", TypeLanguage)
            vRowTitle("MS_VT") = ObjLanguages.GetLanguage(ModuleName, sBC, "MS_VT", TypeLanguage)
            vRowTitle("TEN_VT") = ObjLanguages.GetLanguage(ModuleName, sBC, "TEN_VT", TypeLanguage)
            vRowTitle("VAT_TU_PHU_TUNG_CAN_THIET") = ObjLanguages.GetLanguage(ModuleName, sBC, "VAT_TU_PHU_TUNG_CAN_THIET", TypeLanguage)

            vRowTitle("QUY_CACH") = ObjLanguages.GetLanguage(ModuleName, sBC, "QUY_CACH", TypeLanguage)
            vRowTitle("DVT") = ObjLanguages.GetLanguage(ModuleName, sBC, "DVT", TypeLanguage)
            vRowTitle("SL_KH") = ObjLanguages.GetLanguage(ModuleName, sBC, "SL_KH", TypeLanguage)
            vRowTitle("SL_TT") = ObjLanguages.GetLanguage(ModuleName, sBC, "SL_TT", TypeLanguage)
            vRowTitle("DV_THUE_NGOAI") = ObjLanguages.GetLanguage(ModuleName, sBC, "DV_THUE_NGOAI", TypeLanguage)
            vRowTitle("NOI_DUNG") = ObjLanguages.GetLanguage(ModuleName, sBC, "NOI_DUNG", TypeLanguage)
            vRowTitle("NOI_DUNG_DV") = ObjLanguages.GetLanguage(ModuleName, sBC, "NOI_DUNG_DV", TypeLanguage)
            vRowTitle("NCC") = ObjLanguages.GetLanguage(ModuleName, sBC, "NCC", TypeLanguage)
            vRowTitle("SLUONG") = ObjLanguages.GetLanguage(ModuleName, sBC, "SLUONG", TypeLanguage)
            vRowTitle("DON_GIA") = ObjLanguages.GetLanguage(ModuleName, sBC, "DON_GIA", TypeLanguage)
            vRowTitle("THANH_TIEN") = ObjLanguages.GetLanguage(ModuleName, sBC, "THANH_TIEN", TypeLanguage)
            vRowTitle("GHI_CHU") = ObjLanguages.GetLanguage(ModuleName, sBC, "GHI_CHU", TypeLanguage)
            vRowTitle("BIEN_PHAP_PHONG_NGUA") = ObjLanguages.GetLanguage(ModuleName, sBC, "BIEN_PHAP_PHONG_NGUA", TypeLanguage)
            vRowTitle("CHI_PHI") = ObjLanguages.GetLanguage(ModuleName, sBC, "CHI_PHI", TypeLanguage)
            vRowTitle("NV_SC") = ObjLanguages.GetLanguage(ModuleName, sBC, "NV_SC", TypeLanguage)
            vRowTitle("DV_SD") = ObjLanguages.GetLanguage(ModuleName, sBC, "DV_SD", TypeLanguage)
            vRowTitle("KY_TEN") = ObjLanguages.GetLanguage(ModuleName, sBC, "KY_TEN", TypeLanguage)
            vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP1", TypeLanguage)
            vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP2", TypeLanguage)
            vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP3", TypeLanguage)
            vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP4", TypeLanguage)
            vRowTitle("TMP5") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP5", TypeLanguage)



            vtbTitle.Rows.Add(vRowTitle)
        Catch ex As Exception

        End Try
        Return vtbTitle
    End Function
#End Region
    Private Sub btnXoaPTTT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaPTTT.Click
        If grvPTThayThe.RowCount <= 0 Then Exit Sub
        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT100", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then Exit Sub

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePBT_PhuTungThayTheNull", Me.grvPTThayThe.GetFocusedDataRow()("stt"))
        BindDataPTThayThe()

    End Sub

    Private Sub tabDanhSachPhieuBaoTri_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtMaSoPBT.Text <> PBTOut Then
            bChangce = True
            PBTOut = txtMaSoPBT.Text
        Else
            bChangce = False
        End If
    End Sub
#End Region



    Private Sub XoaCongViecNS()
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        Dim Str As String
        Dim bCapNhap As Boolean
        bCapNhap = False

        If cboTinhTrangPBT.SelectedValue = 3 Then
            If KiemHoanThanh() = False Then
                Exit Sub
            Else
                CapNhapPBTCT(2)
                If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 1 Then
                    Str = ""
                Else
                    bCapNhap = True
                End If
            End If
        End If


        Dim jobcardinfo As New clsJobCardInfo()
        Dim jobcardcontroller As New JOBCARD_Controller
        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgXoa_CNCV", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then

            If ucCongViecNS.grvKHNhanVien.RowCount > 0 Then
                jobcardinfo.PHIEU_BT = txtMaSoPBT.Text
                jobcardinfo.CONG_NHAN = ucCongViecNS.grvKHNhanVien.GetFocusedDataRow()("MS_CONG_NHAN")

                If ucCongViecNS.optOption.SelectedIndex = 1 Then
                    Try
                        Str = "DELETE FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' AND MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "' "
                        Try
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                        Catch ex As Exception
                        End Try
                    Catch ex As Exception

                    End Try
                Else
                    If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 0 Then
                        jobcardinfo.CONG_VIEC = ucCongViecNS.grvCVChinhNS.GetFocusedDataRow()("MS_CV")
                        jobcardinfo.BO_PHAN = ucCongViecNS.grvCVChinhNS.GetFocusedDataRow()("MS_BO_PHAN")

                        Str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' and MS_CV=" & jobcardinfo.CONG_VIEC & " and MS_BO_PHAN='" & jobcardinfo.BO_PHAN & "' AND MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "' and STT = " & ucCongViecNS.grvKHNhanVien.GetFocusedDataRow()("STT")
                        Try
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                        Catch ex As Exception
                        End Try

                        Str = "SELECT ISNULL(COUNT(*),0) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' " &
                                    " and MS_CV=" & jobcardinfo.CONG_VIEC & " and MS_BO_PHAN='" & jobcardinfo.BO_PHAN & "' " &
                                    " and MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "' "
                        Dim dtReader As SqlDataReader

                        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                        dtReader.Read()
                        If dtReader.Item(0) = 0 Then
                            Str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU  WHERE  MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' " &
                                        " and MS_CV=" & jobcardinfo.CONG_VIEC & " and MS_BO_PHAN='" & jobcardinfo.BO_PHAN & "' " &
                                        " and MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "' "
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                        End If
                    Else
                        jobcardinfo.STT = ucCongViecNS.grvCVPhuNS.GetFocusedDataRow()("STT")
                        Str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO " &
                                      "WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' AND STT=" & jobcardinfo.STT &
                                      " and MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "' " &
                                      " AND ID_STT = " & ucCongViecNS.grvKHNhanVien.GetFocusedDataRow()("ID_STT")
                        Try
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                        Catch ex As Exception
                        End Try
                        If bCapNhap Then
                            If ucCongViecNS.grvCVPhuNS.RowCount = 1 Then
                                Str = " UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH = NULL " &
                                                " WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "' AND STT=" & jobcardinfo.STT
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                            Else
                                Str = " UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH = NGAY_GIO FROM PHIEU_BAO_TRI_CV_PHU_TRO A INNER JOIN " &
                                                " (SELECT MS_PHIEU_BAO_TRI,STT,MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(10),DEN_NGAY,101) + ' ' + CONVERT(NVARCHAR(8),DEN_GIO,108))) AS NGAY_GIO " &
                                                "  FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "' AND STT = " & jobcardinfo.STT &
                                                " GROUP BY MS_PHIEU_BAO_TRI,STT) B ON  " &
                                                " A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI And A.STT = B.STT " &
                                                " WHERE A.MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "' AND A.STT=" & jobcardinfo.STT
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                            End If
                            ucCongViecNS.LoadCongViecPhuNS()

                        End If
                    End If
                End If
            End If
        Else
            Exit Sub
        End If

        Try
            ucCongViecNS.OptionChanged()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            bThoat = True
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub








    Dim cboCN As System.Windows.Forms.ComboBox




    Sub HandleKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
            End If
        End If
    End Sub








    Private intCongViecDaThucHien_4 As Integer

    Private intViTriPhuTung_4 As Integer

    Private Sub btnThoat_4_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txtChiPhiKhacMacDinh_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtReader As SqlDataReader

        If txtChiPhiKhacMacDinh.Text <> "" And IsNumeric(txtChiPhiKhacMacDinh.Text.Trim) = False Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "LOI_CHI_PHI_KHAC_MAC_DINH", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtChiPhiKhacMacDinh.Focus()
            Exit Sub
        End If

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGAY_NHAP,TI_GIA,TI_GIA_USD FROM TI_GIA_NT WHERE NGOAI_TE='USD' AND NGAY_NHAP >= ALL (SELECT NGAY_NHAP FROM TI_GIA_NT WHERE NGOAI_TE='USD')")
        While dtReader.Read
            Dim chiphiusd As Double = Convert.ToDouble(Val(Replace$(txtChiPhiKhacMacDinh.Text, ",", ""))) / Convert.ToDouble(dtReader.Item("TI_GIA"))
            txtChiPhiKhacUSD.Text = Format(chiphiusd, "N2")
        End While
        dtReader.Close()
    End Sub




    Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub


    Sub BindDataPTThayTheChiTiet(ByVal MS_PBT As String, ByVal MS_BP As String, ByVal MS_CV As Integer, ByVal MS_PT As String, ByVal STT As Integer)
        Try
            If SQLString = "0LoadCT" Then Exit Sub
            If Convert.ToBoolean(ObjSystems.PBTKho) Then


                Dim dtView As DataView
                Dim dtPTCTiet As New DataTable()

                dtPTCTiet = TB_PHU_TUNG_THAY_THE_CHI_TIET.Copy()
                If btnGhi5.Visible Then
                    TB_PHU_TUNG_THAY_THE_CHI_TIET.Columns("SL_TT").ReadOnly = False
                    dtView = New DataView(TB_PHU_TUNG_THAY_THE_CHI_TIET, "MS_PHIEU_BAO_TRI = '" & MS_PBT & "' AND MS_BO_PHAN = '" & MS_BP & "' AND MS_CV = " & MS_CV.ToString().Trim() & " AND MS_PT = '" & MS_PT & "' AND STT = " & STT.ToString(), "MS_BO_PHAN, MS_CV, MS_PT, STT", DataViewRowState.CurrentRows)


                Else
                    dtView = New DataView(TB_PHU_TUNG_THAY_THE_CHI_TIET, "MS_PHIEU_BAO_TRI = '" & MS_PBT & "' AND MS_BO_PHAN = '" & MS_BP & "' AND MS_CV = " & MS_CV.ToString().Trim() & " AND MS_PT = '" & MS_PT & "' AND STT = " & STT.ToString(), "MS_BO_PHAN, MS_CV, MS_PT, STT", DataViewRowState.CurrentRows)
                End If



                Try
                    grdPTTTChiTiet.DataSource = Nothing
                    grvPTTTChiTiet.Columns.Clear()

                Catch ex As Exception
                End Try

                Dim dt As DataTable = dtView.ToTable()


                If btnGhi5.Visible Then
                    dt.Columns("SL_TT").ReadOnly = False
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTTChiTiet, grvPTTTChiTiet, dt, True, False, False, False, True, Name)

                    grvPTTTChiTiet.OptionsBehavior.Editable = True
                    For i As Integer = 0 To grvPTTTChiTiet.Columns.Count - 1
                        grvPTTTChiTiet.Columns(i).OptionsColumn.AllowEdit = False
                        grvPTTTChiTiet.Columns(i).OptionsColumn.ReadOnly = True
                    Next

                    grvPTTTChiTiet.Columns("SL_TT").OptionsColumn.ReadOnly = False
                    grvPTTTChiTiet.Columns("SL_TT").OptionsColumn.AllowEdit = True
                    'grdPhuTungThayTheChiTiet.Columns("SL_TT").ReadOnly = False


                Else

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTTChiTiet, grvPTTTChiTiet, dt, False, False, False, False, True, Name)
                End If

                grvPTTTChiTiet.Columns("MS_PHIEU_BAO_TRI").Visible = False
                grvPTTTChiTiet.Columns("MS_CV").Visible = False
                grvPTTTChiTiet.Columns("MS_BO_PHAN").Visible = False
                grvPTTTChiTiet.Columns("GHI_CHU").Visible = False
                grvPTTTChiTiet.Columns("STT").Visible = False
                grvPTTTChiTiet.Columns("NGOAI_TE").Visible = False
                grvPTTTChiTiet.Columns("TY_GIA").Visible = False
                grvPTTTChiTiet.Columns("TY_GIA_USD").Visible = False
                grvPTTTChiTiet.Columns("TAI_SD").Visible = False
                grvPTTTChiTiet.Columns("MS_PT").Visible = False
                If Convert.ToBoolean(ObjSystems.KhoMoi) Then
                    grvPTTTChiTiet.Columns("ID").Visible = False
                End If
                With grvPTTTChiTiet
                    .Columns("MS_DH_XUAT_PT").MinWidth = 120
                    .Columns("MS_DH_NHAP_PT").MinWidth = 120
                    .Columns("MS_DH_NHAP_TRA").BestFit()
                    .Columns("MS_DH_NHAP_TC").BestFit()
                    .Columns("MS_PT1").MinWidth = 120
                    .Columns("XUAT_XU").MinWidth = 120
                    .Columns("DON_GIA").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeDG) '"#,###,###,###,##0.#00"
                    .Columns("DON_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"
                    .Columns("DON_GIA").MinWidth = 100
                    .Columns("DG_TAICHE").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeDG) '"#,###,###,###,##0.#00"
                    .Columns("DG_TAICHE").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"
                    .Columns("DG_TAICHE").MinWidth = 100
                    .Columns("BAO_HANH_DEN_NGAY").MinWidth = 100
                    .Columns("SL_TT").MinWidth = 100
                    .Columns("SL_TT").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL) '"#,###,###,###,##0.#00######"
                    .Columns("SL_TT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"
                    .Columns("SL_TAICHE").MinWidth = 100
                    .Columns("SL_TAICHE").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL) '"#,###,###,###,##0.#00######"
                    .Columns("SL_TAICHE").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"
                    .Columns("SO_LUONG_THUC_XUAT").MinWidth = 100
                    .Columns("SO_LUONG_THUC_XUAT").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL) '"#,###,###,###,##0.#00######"
                    .Columns("SO_LUONG_THUC_XUAT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"
                    .Columns("SL_TRA").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL) '"#,###,###,###,##0.#00######"
                    .Columns("SL_TRA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"
                    .Columns("GHI_CHU").MinWidth = 80
                End With
            Else
                Dim dtView As DataView = New DataView(grdPTThayThe.DataSource, "MS_BO_PHAN = '" & MS_BP & "' AND MS_CV = " & MS_CV.ToString() & " AND STT = " & STT.ToString(), "MS_BO_PHAN, MS_CV,MS_PT, STT", DataViewRowState.CurrentRows)
                Try
                    grdPTTTChiTiet.DataSource = Nothing
                    grvPTTTChiTiet.Columns.Clear()

                Catch ex As Exception
                End Try

                Dim dt As DataTable = dtView.ToTable()
                dt.Columns("SL_TT").ReadOnly = False


                If (btnGhi5.Visible = True) Then
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTTChiTiet, grvPTTTChiTiet, dt, True, False, True, True, True, Name)
                    grvPTTTChiTiet.Columns("SL_TT").OptionsColumn.AllowEdit = False
                    grvPTTTChiTiet.OptionsBehavior.Editable = True
                    For i As Integer = 0 To grvPTTTChiTiet.Columns.Count - 1
                        grvPTTTChiTiet.Columns(i).OptionsColumn.AllowEdit = True
                        grvPTTTChiTiet.Columns(i).OptionsColumn.ReadOnly = False
                    Next
                Else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTTChiTiet, grvPTTTChiTiet, dt, False, False, True, True, True, Name)
                    For i As Integer = 0 To grvPTTTChiTiet.Columns.Count - 1
                        grvPTTTChiTiet.Columns(i).OptionsColumn.AllowEdit = False
                        grvPTTTChiTiet.Columns(i).OptionsColumn.ReadOnly = True
                    Next
                End If



                grvPTTTChiTiet.Columns("MS_BO_PHAN").Visible = False
                grvPTTTChiTiet.Columns("MS_CV").Visible = False
                grvPTTTChiTiet.Columns("GHI_CHU").Visible = False
                grvPTTTChiTiet.Columns("NGUOI_THAY_THE").Visible = False
                grvPTTTChiTiet.Columns("SL_KH").Visible = False
                grvPTTTChiTiet.Columns("MS_DH_NHAP_PT").Visible = False
                grvPTTTChiTiet.Columns("VICT_NHA_THAU").Visible = False
                grvPTTTChiTiet.Columns("NGAY_THAY_THE").Visible = False
                grvPTTTChiTiet.Columns("STT").Visible = False
                grvPTTTChiTiet.Columns("MS_PT").Visible = False
                grvPTTTChiTiet.Columns("TEN_PT").Visible = False
                grvPTTTChiTiet.Columns("TEN_BO_PHAN").Visible = False
                grvPTTTChiTiet.Columns("MS_VI_TRI_PT").Visible = False
                grvPTTTChiTiet.Columns("MS_PT1").Visible = False
                grvPTTTChiTiet.Columns("XUAT_XU").Visible = False
                grvPTTTChiTiet.Columns("BAO_HANH_DEN_NGAY").Visible = False
                grvPTTTChiTiet.Columns("LOAI").Visible = False


                Dim cboNgoaiTe As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
                Dim dtNGOAI_TE As DataTable = New DataTable()
                dtNGOAI_TE.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "QL_LOAD_LIST_NGOAI_TE"))
                cboNgoaiTe.Name = "cboNgoaiTe"
                cboNgoaiTe.DisplayMember = "TEN_NGOAI_TE"
                cboNgoaiTe.ValueMember = "NGOAI_TE"
                cboNgoaiTe.NullText = ""
                cboNgoaiTe.DataSource = dtNGOAI_TE
                Dim colNgoaiTe As New GridColumn
                colNgoaiTe.Name = "cboNgoaiTe"
                colNgoaiTe.ColumnEdit = cboNgoaiTe

                grvPTTTChiTiet.Columns("NGOAI_TE").ColumnEdit = cboNgoaiTe
                grvPTTTChiTiet.Columns("NGOAI_TE").Visible = False
                grvPTTTChiTiet.Columns("TY_GIA").Visible = False
                grvPTTTChiTiet.Columns("TY_GIA_USD").Visible = False
                With grvPTTTChiTiet
                    .Columns("DON_GIA").MinWidth = 100
                    .Columns("DON_GIA").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeDG) '"#,###,###,###,##0.#00"
                    .Columns("DON_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"              
                    .Columns("SL_TT").MinWidth = 80
                    .Columns("SL_TT").DisplayFormat.FormatString = ObjSystems.sDinhDangSoLe(iSoLeSL) '"#,###,###,###,##0.#00######"
                    .Columns("SL_TT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom '"#,###,###,###,##0.#00"
                    .Columns("GHI_CHU").MinWidth = 80
                End With


            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub





    Private Sub BT_CHECK_DL_KHO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CHECK_DL_KHO.Click


        Try
            Try
                For Each frmChild As Form In frmMain.MdiChildren
                    If (frmChild.Name.Trim().Equals("frmCompareSLXuat")) Then
                        CType(frmChild, frmCompareSLXuat)._MS_PHIEU_BAO_TRI = txtMaSoPBT.Text.Trim()
                        CType(frmChild, frmCompareSLXuat).LoadData()
                        CType(frmChild, frmCompareSLXuat).Activate()
                        Exit Sub
                    End If
                Next
            Catch ex As Exception
            End Try

            frmMain.Cursor = Cursors.WaitCursor
            Dim frmSL As frmCompareSLXuat = New frmCompareSLXuat()
            frmSL._MS_PHIEU_BAO_TRI = txtMaSoPBT.Text.Trim()
            frmSL.MdiParent = frmMain
            frmSL.WindowState = FormWindowState.Maximized
            frmSL.Show()

        Catch ex As Exception
            frmMain.Cursor = Cursors.Default
            XtraMessageBox.Show("Load form error" + vbCrLf + ex.Message)
        End Try
        frmMain.Cursor = Cursors.Default
    End Sub

    Private Sub btnIn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn_giaonhan.Click
        If sPrivate <> "HUDA" Then Exit Sub
        InGiaoNhan(0)
    End Sub

    Private Sub InGiaoNhan(ByVal LoaiBC As Integer)
        '@LoaiBC = 0 IN all cua huda
        '@LoaiBC = 1 IN CONG VIEC AND (STT_SERVICE IS NULL)
        '@LoaiBC = 2 IN DICH VU AND (STT_SERVICE IS NOT NULL)
        If txtMaSoPBT.Text.Trim = "" Then
            Exit Sub
        End If

        Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()

        If sPrivate = "HUDA" Then
            Dim vtbPBT As New DataTable()
            vtbPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_PHIEU_BAO_TRI", txtMaSoPBT.Text, TypeLanguage))
            vtbPBT.TableName = "PBT_INFO"
            frmRpt.rptName = "rptBien_Ban_Nghiem_Thu"
            frmRpt.AddDataTableSource(RefeshLanguageBBNT())
            frmRpt.AddDataTableSource(vtbPBT)
            frmRpt.ShowDialog()
            Exit Sub
        End If

        Dim vtbData As DataTable = New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_rptBienBanGiaoNhanTaiSanCoDinh", txtMaSoPBT.Text.Trim(), LoaiBC))
        vtbData.TableName = "DATA_INFO"

        If vtbData.Rows.Count > 0 Then
            Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
            If LoaiBC = 1 Then
                frmRepot.rptName = "rptBienBanGiaoNhanTaiSanCoDinh"
            Else
                frmRepot.rptName = "rptBienBanGiaoNhanTaiSanCoDinhDV"
            End If
            frmRepot.AddDataTableSource(RefeshLanguage(LoaiBC))
            frmRepot.AddDataTableSource(vtbData)

            Dim vtbtmp As DataTable = New DataTable()
            Dim vtbBactho As DataTable = New DataTable()
            Dim vtbphanbo As DataTable = New DataTable()
            vtbBactho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_BAC_THO FROM BAC_THO ORDER BY MS_BAC_THO"))
            vtbtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_rptBienBanGiaoNhanTaiSanCoDinh_Congsuachua",
                                                txtMaSoPBT.Text.Trim(), LoaiBC))
            vtbphanbo.TableName = "DATA_PHAN_BO"
            For Each row As DataRow In vtbBactho.Rows
                vtbphanbo.Columns.Add(row(0).ToString())
            Next
            Dim dtRow As DataRow = vtbphanbo.NewRow()
            For Each row As DataRow In vtbBactho.Rows
                Dim rpb() As DataRow
                rpb = vtbtmp.Select("MS_BAC_THO = '" + row(0).ToString + "'")
                If rpb.Length > 0 Then
                    dtRow(row(0).ToString()) = rpb(0)(1)
                Else
                    dtRow(row(0).ToString()) = 0
                End If

            Next
            vtbphanbo.Rows.Add(dtRow)
            frmRepot.AddDataTableSource(vtbphanbo)
            frmRepot.ShowDialog()
        Else
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KoCoDuLieuDeIn", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Function RefeshLanguageBBNT() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 20
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TEN_TB"
        vtbTitle.Columns(2).ColumnName = "TEN_BO_PHAN"
        vtbTitle.Columns(3).ColumnName = "MS_PHIEU_BT"
        vtbTitle.Columns(4).ColumnName = "NGAY_LAP"
        vtbTitle.Columns(5).ColumnName = "HOM_NAY"
        vtbTitle.Columns(6).ColumnName = "NGAY"
        vtbTitle.Columns(7).ColumnName = "THANG"
        vtbTitle.Columns(8).ColumnName = "NAM"
        vtbTitle.Columns(9).ColumnName = "TAI"
        vtbTitle.Columns(10).ColumnName = "DAIDIENBPSUDUNGTBI"
        vtbTitle.Columns(11).ColumnName = "ONG/BA"
        vtbTitle.Columns(12).ColumnName = "CHUCVU"
        vtbTitle.Columns(13).ColumnName = "DAIDIENBPBT"
        vtbTitle.Columns(14).ColumnName = "NGHIEMTHU1"
        vtbTitle.Columns(15).ColumnName = "NGHIEMTHU2"
        vtbTitle.Columns(16).ColumnName = "KETLUAN"
        vtbTitle.Columns(17).ColumnName = "CACBENCUNGKYTEN"
        vtbTitle.Columns(18).ColumnName = "BPSDTB"
        vtbTitle.Columns(19).ColumnName = "BPBT"
        vtbTitle.Columns(20).ColumnName = "Print_Date"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TIEU_DE") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "TIEU_DE", TypeLanguage)
        vRowTitle("TEN_TB") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "TEN_TB", TypeLanguage)
        vRowTitle("TEN_BO_PHAN") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "TEN_BO_PHAN", TypeLanguage)
        vRowTitle("MS_PHIEU_BT") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "MS_PHIEU_BT", TypeLanguage)
        vRowTitle("NGAY_LAP") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "NGAY_LAP", TypeLanguage)
        vRowTitle("HOM_NAY") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "HOM_NAY", TypeLanguage)
        vRowTitle("NGAY") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "NGAY", TypeLanguage)
        vRowTitle("THANG") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "THANG", TypeLanguage)
        vRowTitle("NAM") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "NAM", TypeLanguage)
        vRowTitle("TAI") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "TAI", TypeLanguage)
        vRowTitle("DAIDIENBPSUDUNGTBI") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "DAIDIENBPSUDUNGTBI", TypeLanguage)
        vRowTitle("ONG/BA") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "ONG/BA", TypeLanguage)
        vRowTitle("CHUCVU") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "CHUCVU", TypeLanguage)
        vRowTitle("DAIDIENBPBT") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "DAIDIENBPBT", TypeLanguage)
        vRowTitle("NGHIEMTHU1") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "NGHIEMTHU1", TypeLanguage)
        vRowTitle("NGHIEMTHU2") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "NGHIEMTHU2", TypeLanguage)
        vRowTitle("KETLUAN") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "KETLUAN", TypeLanguage)
        vRowTitle("CACBENCUNGKYTEN") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "CACBENCUNGKYTEN", TypeLanguage)
        vRowTitle("BPSDTB") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "BPSDTB", TypeLanguage)
        vRowTitle("BPBT") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "BPBT", TypeLanguage)
        vRowTitle("Print_Date") = ObjLanguages.GetLanguage(ModuleName, "rptBienBanNghiemThu", "Print_Date", TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Function RefeshLanguage(ByVal LoaiBC As Integer) As DataTable
        Dim sBC As String = "rptBienBanGiaoNhanTaiSanCoDinh"
        If LoaiBC = 2 Then sBC = "rptBienBanGiaoNhanTaiSanCoDinhDV"

        Dim vtbTitle As New DataTable()
        If LoaiBC = 2 Then
            For i As Integer = 0 To 41
                vtbTitle.Columns.Add()
            Next
        Else
            For i As Integer = 0 To 40
                vtbTitle.Columns.Add()
            Next
        End If
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TUA_DE_SUB"
        vtbTitle.Columns(2).ColumnName = "MA_SO"
        vtbTitle.Columns(3).ColumnName = "LAN_BAN_HANH"
        vtbTitle.Columns(4).ColumnName = "lblNGAY_BAN_HANH"
        vtbTitle.Columns(5).ColumnName = "lblCAN_CU_THEO"
        vtbTitle.Columns(6).ColumnName = "lblDON_VI_DX"
        vtbTitle.Columns(7).ColumnName = "lblBankiemnghiem"
        vtbTitle.Columns(8).ColumnName = "lblDDNhamay"
        vtbTitle.Columns(9).ColumnName = "lblDDphongkt"
        vtbTitle.Columns(10).ColumnName = "lblDDDVSC"
        vtbTitle.Columns(11).ColumnName = "lblDDdonvisudungtaisancodinh"
        vtbTitle.Columns(12).ColumnName = "lblKiemnghiemcacnoidungsuachua"
        vtbTitle.Columns(13).ColumnName = "lblTenTSCD"
        vtbTitle.Columns(14).ColumnName = "lblSOKIEMKE"
        vtbTitle.Columns(15).ColumnName = "lblThuchientungay"
        vtbTitle.Columns(16).ColumnName = "CAC_BO_PHAN_SC"
        vtbTitle.Columns(17).ColumnName = "TEN_BO_PHAN"
        vtbTitle.Columns(18).ColumnName = "NOI_DUNG_CV"
        vtbTitle.Columns(19).ColumnName = "THONG_SO"
        vtbTitle.Columns(20).ColumnName = "TIEU_CHUAN"
        vtbTitle.Columns(21).ColumnName = "THUC_KIEM"
        vtbTitle.Columns(22).ColumnName = "KET_QUA_DANH_GIA"
        vtbTitle.Columns(23).ColumnName = "lblTongsocong"
        vtbTitle.Columns(24).ColumnName = "BAC"
        vtbTitle.Columns(25).ColumnName = "CONG"
        vtbTitle.Columns(26).ColumnName = "lblKetluan"
        vtbTitle.Columns(27).ColumnName = "DON_VI_NHAN"
        vtbTitle.Columns(28).ColumnName = "DON_VI_SUA_CHUA"
        vtbTitle.Columns(29).ColumnName = "PHONG_KY_THUAT"
        vtbTitle.Columns(30).ColumnName = "GIAM_DOC_NHA_MAY"
        vtbTitle.Columns(31).ColumnName = "PHONG_CO_DIEN"
        vtbTitle.Columns(32).ColumnName = "PHONG_KE_HOACH"
        vtbTitle.Columns(33).ColumnName = "KE_TOAN_TRUONG"
        vtbTitle.Columns(34).ColumnName = "SO_BBGN"
        vtbTitle.Columns(35).ColumnName = "BINHQUAN"
        vtbTitle.Columns(36).ColumnName = "TUA_DE_SUB1"
        vtbTitle.Columns(37).ColumnName = "TMP1"
        vtbTitle.Columns(38).ColumnName = "TMP2"
        vtbTitle.Columns(39).ColumnName = "TMP3"
        vtbTitle.Columns(40).ColumnName = "TMP4"
        If LoaiBC = 2 Then
            vtbTitle.Columns(41).ColumnName = "DON_VI_SC"
        End If
        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = ObjLanguages.GetLanguage(ModuleName, sBC, "TIEU_DE", TypeLanguage)
        vRowTitle("TUA_DE_SUB") = ObjLanguages.GetLanguage(ModuleName, sBC, "TUA_DE_SUB", TypeLanguage)
        vRowTitle("MA_SO") = ObjLanguages.GetLanguage(ModuleName, sBC, "MA_SO", TypeLanguage)
        vRowTitle("LAN_BAN_HANH") = ObjLanguages.GetLanguage(ModuleName, sBC, "LAN_BAN_HANH", TypeLanguage)
        vRowTitle("lblNGAY_BAN_HANH") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblNGAY_BAN_HANH", TypeLanguage)
        vRowTitle("lblCAN_CU_THEO") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblCAN_CU_THEO", TypeLanguage)
        vRowTitle("lblDON_VI_DX") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblDON_VI_DX", TypeLanguage)
        vRowTitle("lblBankiemnghiem") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblBankiemnghiem", TypeLanguage)
        vRowTitle("lblDDNhamay") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblDDNhamay", TypeLanguage)
        vRowTitle("lblDDphongkt") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblDDphongkt", TypeLanguage)
        vRowTitle("lblDDDVSC") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblDDDVSC", TypeLanguage)
        vRowTitle("lblDDdonvisudungtaisancodinh") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblDDdonvisudungtaisancodinh", TypeLanguage)
        vRowTitle("lblKiemnghiemcacnoidungsuachua") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblKiemnghiemcacnoidungsuachua", TypeLanguage)
        vRowTitle("lblTenTSCD") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblTenTSCD", TypeLanguage)
        vRowTitle("lblSOKIEMKE") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblSOKIEMKE", TypeLanguage)
        vRowTitle("lblThuchientungay") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblThuchientungay", TypeLanguage)
        vRowTitle("CAC_BO_PHAN_SC") = ObjLanguages.GetLanguage(ModuleName, sBC, "CAC_BO_PHAN_SC", TypeLanguage)
        vRowTitle("TEN_BO_PHAN") = ObjLanguages.GetLanguage(ModuleName, sBC, "TEN_BO_PHAN", TypeLanguage)
        vRowTitle("NOI_DUNG_CV") = ObjLanguages.GetLanguage(ModuleName, sBC, "NOI_DUNG_CV", TypeLanguage)
        vRowTitle("THONG_SO") = ObjLanguages.GetLanguage(ModuleName, sBC, "THONG_SO", TypeLanguage)
        vRowTitle("TIEU_CHUAN") = ObjLanguages.GetLanguage(ModuleName, sBC, "TIEU_CHUAN", TypeLanguage)
        vRowTitle("THUC_KIEM") = ObjLanguages.GetLanguage(ModuleName, sBC, "THUC_KIEM", TypeLanguage)
        vRowTitle("KET_QUA_DANH_GIA") = ObjLanguages.GetLanguage(ModuleName, sBC, "KET_QUA_DANH_GIA", TypeLanguage)
        vRowTitle("lblTongsocong") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblTongsocong", TypeLanguage)
        vRowTitle("BAC") = ObjLanguages.GetLanguage(ModuleName, sBC, "BAC", TypeLanguage)
        vRowTitle("CONG") = ObjLanguages.GetLanguage(ModuleName, sBC, "CONG", TypeLanguage)
        vRowTitle("lblKetluan") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblKetluan", TypeLanguage)
        vRowTitle("DON_VI_NHAN") = ObjLanguages.GetLanguage(ModuleName, sBC, "DON_VI_NHAN", TypeLanguage)
        vRowTitle("DON_VI_SUA_CHUA") = ObjLanguages.GetLanguage(ModuleName, sBC, "DON_VI_SUA_CHUA", TypeLanguage)
        vRowTitle("PHONG_KY_THUAT") = ObjLanguages.GetLanguage(ModuleName, sBC, "PHONG_KY_THUAT", TypeLanguage)
        vRowTitle("GIAM_DOC_NHA_MAY") = ObjLanguages.GetLanguage(ModuleName, sBC, "GIAM_DOC_NHA_MAY", TypeLanguage)
        vRowTitle("PHONG_CO_DIEN") = ObjLanguages.GetLanguage(ModuleName, sBC, "PHONG_CO_DIEN", TypeLanguage)
        vRowTitle("PHONG_KE_HOACH") = ObjLanguages.GetLanguage(ModuleName, sBC, "PHONG_KE_HOACH", TypeLanguage)
        vRowTitle("KE_TOAN_TRUONG") = ObjLanguages.GetLanguage(ModuleName, sBC, "KE_TOAN_TRUONG", TypeLanguage)
        vRowTitle("SO_BBGN") = ObjLanguages.GetLanguage(ModuleName, sBC, "SO_BBGN", TypeLanguage)
        vRowTitle("BINHQUAN") = ObjLanguages.GetLanguage(ModuleName, sBC, "BINHQUAN", TypeLanguage)
        vRowTitle("TUA_DE_SUB1") = ObjLanguages.GetLanguage(ModuleName, sBC, "HOAN_THANH", TypeLanguage)
        vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, sBC, "DON_VI_SC", TypeLanguage)
        vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, sBC, "DON_VI_NHAN", TypeLanguage)
        vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblDDNMNhan", TypeLanguage)
        vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, sBC, "lblPhanXuongThucHien", TypeLanguage)
        vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP1", TypeLanguage)
        vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP2", TypeLanguage)
        vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP3", TypeLanguage)
        vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, sBC, "TMP4", TypeLanguage)
        If LoaiBC = 2 Then
            vRowTitle("DON_VI_SC") = ObjLanguages.GetLanguage(ModuleName, sBC, "DON_VI_SC", TypeLanguage)
        End If


        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Sub LoadBophan()
        If cboMAY.EditValue = "" Then
            tvwCautrucTB1.Nodes.Clear()
        Else
            ShowTreeList(cboMAY.EditValue)
        End If
    End Sub
    Sub LoadHCG()
        Dim dtClass As New DataTable
        dtClass = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCLASS_LISTs").Tables(0)
        Dim dtProblem As New DataTable
        dtProblem = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_LISTs").Tables(0)
        cboProblem.DataSource = dtProblem
        cboProblem.DisplayMember = "PROBLEM_NAME"
        cboProblem.ValueMember = "PROBLEM_ID"
        classBinding = New BindingSource


    End Sub
    ' <summary>
    ' Thủ tục nạp dữ liệu lên Treeview theo mã máy
    ' </summary>
    ' <remarks></remarks>
    ' 

    Sub ShowTreeList(ByVal sMS_MAY As String)




        Dim SqlText As String = "SELECT MS_BO_PHAN, MS_BO_PHAN + ' - ' + TEN_BO_PHAN AS TEN_BO_PHAN, MS_BO_PHAN_CHA FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' order by isnull(stt,999)"

        tvwCautrucTB1.KeyFieldName = "MS_BO_PHAN"
        tvwCautrucTB1.ParentFieldName = "MS_BO_PHAN_CHA"

        Dim dtRoot1 As DataTable = New DataTable()
        dtRoot1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        tvwCautrucTB1.DataSource = dtRoot1
        tvwCautrucTB1.OptionsBehavior.Editable = False
        tvwCautrucTB1.Columns("TEN_BO_PHAN").Caption = cboMAY.EditValue
        tvwCautrucTB1.ExpandAll()
    End Sub

    Dim sClass As String
    Dim classBinding As BindingSource
    Dim dtRoot As DataTable
    Dim ttClass As String
    Dim curPro, curCause, curRemedy As String
    Private Sub dtRoot_TableNewRow(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        Try
            e.Row("CLASS_ID") = sClass
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboCause_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCause.SelectedIndexChanged
        Try
            Dim dtRemedy As New DataTable
            If (cboCause.SelectedValue Is Nothing) Then
                dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
            Else
                If (cboCause.SelectedValue.Equals(DBNull.Value)) Then
                    dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
                Else
                    dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", cboCause.SelectedValue.ToString).Tables(0)
                End If
            End If
            cboRemedy.DataSource = dtRemedy
            cboRemedy.DisplayMember = "REMEDY_NAME"
            cboRemedy.ValueMember = "REMEDY_ID"
            cboRemedy.DataBindings.Clear()
            cboRemedy.DataBindings.Add("SelectedValue", classBinding, "REMEDY_ID")
        Catch ex As Exception

        End Try
    End Sub
    Sub EnableButtonClass(ByVal flag As Boolean)
        If PermisString.Equals("Read only") Then Exit Sub
        btnThemClass.Visible = flag
        btnSuaClass.Visible = flag
        btnXoaClass.Visible = flag
        btnThoatClass.Visible = flag
        btnGhiClass.Visible = Not flag
        btnKhongghiClass.Visible = Not flag
        tvwCautrucTB1.Enabled = flag
        grdProblem.Enabled = flag
    End Sub
    Sub ReadOnlyControl(ByVal flag As Boolean)
        txtClass.Properties.ReadOnly = True
        cboCause.Enabled = Not flag
        cboProblem.Enabled = Not flag
        cboRemedy.Enabled = Not flag
        txtNoteClass.Properties.ReadOnly = flag
    End Sub

    Private Sub btnThemClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemClass.Click
        Try
            If CheckNghiemThuPBT() Then Exit Sub

            ttClass = "Add"
            EnableButtonClass(False)
            ReadOnlyControl(False)
            txtNoteClass.Text = ""
            cboCause.SelectedIndex = -1
            cboProblem.SelectedIndex = -1
            cboRemedy.SelectedIndex = -1

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGhiClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhiClass.Click
        Try

            If txtClass.Text.Length <= 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "Cautructbchuacoclass", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If cboProblem.SelectedIndex < 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "chuachonproblem", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboProblem.Focus()
                Exit Sub
            End If
            If cboCause.SelectedIndex < 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "chuachoncause", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboCause.Focus()
                Exit Sub
            End If
            If cboRemedy.SelectedIndex < 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "chuachonremedy", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboRemedy.Focus()
                Exit Sub
            End If
            If ttClass = "Add" Then
                Dim result As Integer = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "ADDPHIEU_BAO_TRI_CLASS", txtMaSoPBT.Text, tvwCautrucTB1.FocusedNode("MS_BO_PHAN"), sClass, cboProblem.SelectedValue.ToString, cboCause.SelectedValue.ToString, cboRemedy.SelectedValue.ToString, txtNoteClass.Text)
                If result <= 0 Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "tontaiclass", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            ElseIf ttClass = "Edit" Then
                Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
                objConnection.Open()
                Dim objTrans As SqlTransaction = objConnection.BeginTransaction
                Try
                    Dim result As Integer = SqlHelper.ExecuteNonQuery(objTrans, "DELETEPHIEU_BAO_TRI_CLASS", txtMaSoPBT.Text, tvwCautrucTB1.FocusedNode("MS_BO_PHAN"), curPro, curCause, curRemedy)
                    If result > 0 Then
                        result = SqlHelper.ExecuteNonQuery(objTrans, "ADDPHIEU_BAO_TRI_CLASS", txtMaSoPBT.Text, tvwCautrucTB1.FocusedNode("MS_BO_PHAN"), sClass, cboProblem.SelectedValue.ToString, cboCause.SelectedValue.ToString, cboRemedy.SelectedValue.ToString, txtNoteClass.Text)
                        If result <= 0 Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "tontaiclass", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        classBinding.RemoveCurrent()
                        objTrans.Commit()
                    End If
                Catch ex As Exception
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "tontaiclass", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    objTrans.Rollback()
                End Try
                If objConnection.State = ConnectionState.Open Then
                    objConnection.Close()
                End If
            End If
            EnableButtonClass(True)
            ReadOnlyControl(True)
            'classBinding.EndEdit()
            dtRoot = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GET_PHIEU_BAO_TRI_CLASSs").Tables(0)
            SqlText = "MS_BO_PHAN='" & tvwCautrucTB1.FocusedNode("MS_BO_PHAN") & "' AND MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            dtRoot.DefaultView.RowFilter = SqlText
            'classBinding.DataSource = dtRoot.DefaultView


            ObjSystems.MLoadXtraGrid(grdProblem, grvProblem, dtRoot.DefaultView.ToTable(), False, False, True, False, True, Name)
            grvProblem.Columns("CLASS_NAME").Visible = False
            grvProblem.Columns("NOTE").Visible = False
            grvProblem.Columns("MS_PHIEU_BAO_TRI").Visible = False
            grvProblem.Columns("MS_BO_PHAN").Visible = False
            grvProblem.Columns("CLASS_ID").Visible = False
            grvProblem.Columns("PROBLEM_ID").Visible = False
            grvProblem.Columns("CAUSE_ID").Visible = False
            grvProblem.Columns("REMEDY_ID").Visible = False


            If Not PermisString.Equals("Read only") Then
                If grvProblem.RowCount <= 0 Then

                    If tvwCautrucTB1.FocusedNode("MS_BO_PHAN") = cboMAY.EditValue() Or cboTinhTrangPBT.SelectedValue >= 5 Then
                        btnXoaClass.Enabled = False
                        btnSuaClass.Enabled = False
                        btnThemClass.Enabled = False
                    Else
                        btnXoaClass.Enabled = False
                        btnSuaClass.Enabled = False
                        btnThemClass.Enabled = True
                    End If
                Else
                    If tvwCautrucTB1.FocusedNode("MS_BO_PHAN") = cboMAY.EditValue() Or cboTinhTrangPBT.SelectedValue >= 5 Then
                        btnXoaClass.Enabled = False
                        btnSuaClass.Enabled = False
                        btnThemClass.Enabled = False
                    Else
                        btnThemClass.Enabled = True
                        btnXoaClass.Enabled = True
                        btnSuaClass.Enabled = True
                    End If
                End If
            Else
                btnXoaClass.Enabled = False
                btnSuaClass.Enabled = False
                btnThemClass.Enabled = False
            End If
            grvProblem_FocusedRowChanged(Nothing, Nothing)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKhongghiClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongghiClass.Click
        Try
            ttClass = "None"
            EnableButtonClass(True)
            ReadOnlyControl(True)


        Catch ex As Exception

        End Try

    End Sub
    Private Function CheckNghiemThuPBT() As Boolean

        If (cboTinhTrangPBT.SelectedValue = 4) Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgQuyenXoa3", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 3)
                cboTinhTrangPBT.SelectedValue = 3
                Dim str As String = ""
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
                Try
                    grvDanhSach_1.SetRowCellValue(intRowPBT, "TINH_TRANG_PBT", 3)
                Catch ex As Exception

                End Try
                cboTinhTrangPBT.SelectedValue = 3
                Return False
            Else
                Return True
                Exit Function
            End If
        End If
        Return False

    End Function

    Private Sub btnThoatClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatClass.Click
        Me.Close()
    End Sub

    Private Sub btnXoaClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaClass.Click
        If CheckNghiemThuPBT() Then Exit Sub
        Try
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "banmuonxoaclass", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
                Dim result As Integer = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DELETEPHIEU_BAO_TRI_CLASS", txtMaSoPBT.Text, tvwCautrucTB1.FocusedNode("MS_BO_PHAN"), cboProblem.SelectedValue.ToString, cboCause.SelectedValue.ToString, cboRemedy.SelectedValue.ToString)
                If result > 0 Then
                    tvwCautrucTB1_FocusedNodeChanged(Nothing, Nothing)
                    If (grvProblem.RowCount = 0) Then
                        btnSuaClass.Enabled = False
                        btnXoaClass.Enabled = False
                    End If
                Else
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "Khongthexoa", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSuaClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuaClass.Click
        Try
            If CheckNghiemThuPBT() Then Exit Sub

            ttClass = "Edit"
            EnableButtonClass(False)
            ReadOnlyControl(False)
            curPro = cboProblem.SelectedValue.ToString
            curCause = cboCause.SelectedValue.ToString
            curRemedy = cboRemedy.SelectedValue.ToString
            grvProblem_FocusedRowChanged(Nothing, Nothing)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboProblem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProblem.SelectedIndexChanged
        Try
            Dim dtCause As New DataTable
            If (cboProblem.SelectedValue Is Nothing) Then
                dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", " ").Tables(0)
            Else
                If (cboProblem.SelectedValue.Equals(DBNull.Value)) Then
                    dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", " ").Tables(0)
                Else
                    dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", cboProblem.SelectedValue.ToString).Tables(0)
                End If
            End If
            cboCause.DataSource = dtCause
            cboCause.DisplayMember = "CAUSE_NAME"
            cboCause.ValueMember = "CAUSE_ID"
            cboCause.DataBindings.Clear()
            cboCause.DataBindings.Add("SelectedValue", classBinding, "CAUSE_ID")

            Dim dtRemedy As New DataTable
            If (cboCause.SelectedValue Is Nothing) Then
                dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
            Else
                If (cboCause.SelectedValue.Equals(DBNull.Value)) Then
                    dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
                Else
                    dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", cboCause.SelectedValue.ToString).Tables(0)
                End If
            End If
            cboRemedy.DataSource = dtRemedy
            cboRemedy.DisplayMember = "REMEDY_NAME"
            cboRemedy.ValueMember = "REMEDY_ID"
            cboRemedy.DataBindings.Clear()
            cboRemedy.DataBindings.Add("SelectedValue", classBinding, "REMEDY_ID")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTGNgungMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTGNgungMay.Click
        Dim frmTGNgungMay As MVControl.frmThoigianngungmayNEW = New MVControl.frmThoigianngungmayNEW()
        Try
            If txtNgayhong.Text.Replace("/", "").Trim = "" Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhongcongayhong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNgayhong.Focus()
                Exit Sub
            End If
            If txtGiohong.Text.Replace(":", "").Trim = "" Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhongcoGiohong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtGiohong.Focus()
                Exit Sub
            End If

            If txtDenNgayHong.Text.Replace("/", "").Trim = "" Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhongCoDenNgayhong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDenNgayHong.Focus()
                Exit Sub
            End If
            If txtDenGioHong.Text.Replace(":", "").Trim = "" Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhongCoDenGiohong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDenGioHong.Focus()
                Exit Sub
            End If

            frmTGNgungMay.MsMay = cboMAY.EditValue.Trim()
            frmTGNgungMay.NGAY_BD = DateTime.ParseExact(txtNgayhong.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            frmTGNgungMay.GIO_BD = DateTime.ParseExact(txtGiohong.Text, "HH:mm", System.Globalization.CultureInfo.CurrentCulture)
            frmTGNgungMay.NGAY_KT = DateTime.ParseExact(txtDenNgayHong.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            frmTGNgungMay.GIO_KT = DateTime.ParseExact(txtDenGioHong.Text, "HH:mm", System.Globalization.CultureInfo.CurrentCulture)
            frmTGNgungMay.MS_NN = cboNguyenNhan.EditValue
            frmTGNgungMay.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text.Trim
            frmTGNgungMay.sNguyenNhanNgungMay = txtLydo_1.Text
            If Commons.Modules.sPrivate = "VIFON" Then
                Try
                    frmTGNgungMay.sGiaiPhapKhacPhuc = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 dbo.GetPBTBoPhanCV('" & txtMaSoPBT.Text & "'," & Commons.Modules.TypeLanguage.ToString & ") ")
                Catch ex As Exception

                End Try
            End If
            frmTGNgungMay.WindowState = FormWindowState.Maximized
            frmTGNgungMay.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub




    Private Sub LoadNguyenNhan()
        Dim sql As String = "select MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN from nguyen_nhan_Dung_may ORDER BY TEN_NGUYEN_NHAN"
        Dim _dataTable As DataTable = New DataTable()
        _dataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        Dim dr As DataRow = _dataTable.NewRow()
        dr("MS_NGUYEN_NHAN") = "-1"
        dr("TEN_NGUYEN_NHAN") = "....."
        _dataTable.Rows.InsertAt(dr, 0)
        dr = _dataTable.NewRow()
        dr("MS_NGUYEN_NHAN") = "10000"
        dr("TEN_NGUYEN_NHAN") = "...New..."
        _dataTable.Rows.Add(dr)

        cboNguyenNhan.Properties.DataSource = Nothing
        cboNguyenNhan.Properties.DataSource = _dataTable
        cboNguyenNhan.Properties.DisplayMember = "TEN_NGUYEN_NHAN"
        cboNguyenNhan.Properties.ValueMember = "MS_NGUYEN_NHAN"
        cboNguyenNhan.Properties.PopulateColumns()
        cboNguyenNhan.Properties.Columns("MS_NGUYEN_NHAN").Visible = False
        cboNguyenNhan.Properties.Columns("TEN_NGUYEN_NHAN").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "TEN_NGUYEN_NHAN", TypeLanguage)

        cboNguyenNhan.EditValue = -1
    End Sub

    Function IsDinhKy() As Boolean
        Dim sql As String = "SELECT MS_HT_BT FROM LOAI_BAO_TRI WHERE MS_LOAI_BT = " & cboLoaiBT.EditValue
        sql = "SELECT COUNT(*) FROM LOAI_BAO_TRI T2 INNER JOIN HINH_THUC_BAO_TRI T3 ON T2.MS_HT_BT = T3.MS_HT_BT WHERE PHONG_NGUA = 1 AND MS_LOAI_BT = " & cboLoaiBT.EditValue

        Dim res As Integer = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        If res > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function IsAuto() As Boolean
        Try
            Dim sql As String = "SELECT TOP 1 ISAUTO FROM THONG_TIN_CHUNG"
            Dim res As Boolean = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            Return res
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        Dim objFrm As ReportHuda.Kido.frmPhieuBaoTri_TuDong = New ReportHuda.Kido.frmPhieuBaoTri_TuDong()
        Dim _tbTemp As DataTable = New DataTable()
        _tbTemp = dtPBT.Copy()
        _tbTemp = _tbTemp.DefaultView.ToTable(True, "MS_PHIEU_BAO_TRI", "SO_PHIEU_BAO_TRI", "MS_MAY", "TEN_TINH_TRANG", "TEN_LOAI_BT", "TEN_UU_TIEN", "NGAY_LAP", "NGAY_BD_KH", "NGAY_KT_KH")

        _tbTemp.Columns.Add("Nguoi_Nghiem_Thu", Type.GetType("System.String"))
        _tbTemp.Columns.Add("Ngay_Nghiem_Thu", Type.GetType("System.DateTime"))
        _tbTemp.Columns.Add("Tinh_Trang_Sau_BT", Type.GetType("System.String"))
        _tbTemp.Columns.Add("Chon", Type.GetType("System.Boolean"))


        For Each row In _tbTemp.Rows
            row("Chon") = False

        Next
        objFrm._tableSource = _tbTemp
        objFrm.ShowDialog()
        If objFrm.isSuccess Then
            optNTHT.SelectedIndex = 2
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        ReportHuda.Class.PrintExcel.Prints(txtMaSoPBT.Text, cboMAY.EditValue, TypeLanguage)
        Me.Cursor = Cursors.Default
    End Sub









#End Region

    Function LanRptMeko() As DataTable
        Dim tbTitle As New DataTable()
        Try

            tbTitle.TableName = "TIEU_DE_PHIEU_BAO_TRI_MEKO"
            For i As Integer = 0 To 35
                tbTitle.Columns.Add()
            Next
            tbTitle.Columns(0).ColumnName = "PhanXuong"
            tbTitle.Columns(1).ColumnName = "So"
            tbTitle.Columns(2).ColumnName = "KSBT"
            tbTitle.Columns(3).ColumnName = "TenThietBi"
            tbTitle.Columns(4).ColumnName = "MaSo"
            tbTitle.Columns(5).ColumnName = "DinhKy"
            tbTitle.Columns(6).ColumnName = "TinhTrangMay"
            tbTitle.Columns(7).ColumnName = "DangSX"
            tbTitle.Columns(8).ColumnName = "NgoaiSX"
            tbTitle.Columns(9).ColumnName = "BaoTriDinhKy"
            tbTitle.Columns(10).ColumnName = "ViTriLapDat"
            tbTitle.Columns(11).ColumnName = "CTKiemTraBaoTri"
            tbTitle.Columns(12).ColumnName = "CongTacKiemTra"
            tbTitle.Columns(13).ColumnName = "ThongSo"
            tbTitle.Columns(14).ColumnName = "Dat"
            tbTitle.Columns(15).ColumnName = "KhongDat"
            tbTitle.Columns(16).ColumnName = "MoTaCV"
            tbTitle.Columns(17).ColumnName = "DeXuat"
            tbTitle.Columns(18).ColumnName = "ThucHienLuc"
            tbTitle.Columns(19).ColumnName = "Ngay"
            tbTitle.Columns(20).ColumnName = "HoanThanhLuc"
            tbTitle.Columns(21).ColumnName = "VatTuThayThe"
            tbTitle.Columns(22).ColumnName = "Co"
            tbTitle.Columns(23).ColumnName = "Khong"
            tbTitle.Columns(24).ColumnName = "TenVT"
            tbTitle.Columns(25).ColumnName = "MaVT"
            tbTitle.Columns(26).ColumnName = "SLuong"
            tbTitle.Columns(27).ColumnName = "KhoCoDien"
            tbTitle.Columns(28).ColumnName = "STT"
            tbTitle.Columns(29).ColumnName = "PhuTrachDVSD"
            tbTitle.Columns(30).ColumnName = "DanhGia"
            tbTitle.Columns(31).ColumnName = "ChuKy"
            tbTitle.Columns(32).ColumnName = "KyThuatVien"
            tbTitle.Columns(33).ColumnName = "PQDPX"
            tbTitle.Columns(34).ColumnName = "KyTen"
            tbTitle.Columns(35).ColumnName = "Mekophar"
            '

            Dim vRowTitle As DataRow = tbTitle.NewRow()
            vRowTitle("PhanXuong") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "PhanXuong", TypeLanguage)
            vRowTitle("So") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "So", TypeLanguage)
            vRowTitle("KSBT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "KSBT", TypeLanguage)
            vRowTitle("TenThietBi") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "TenThietBi", TypeLanguage)
            vRowTitle("MaSo") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "MaSo", TypeLanguage)
            vRowTitle("DinhKy") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "DinhKy", TypeLanguage)
            vRowTitle("TinhTrangMay") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "TinhTrangMay", TypeLanguage)
            vRowTitle("DangSX") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "DangSX", TypeLanguage)
            vRowTitle("NgoaiSX") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "NgoaiSX", TypeLanguage)
            vRowTitle("BaoTriDinhKy") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "BaoTriDinhKy", TypeLanguage)
            vRowTitle("ViTriLapDat") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "ViTriLapDat", TypeLanguage)
            vRowTitle("CongTacKiemTra") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "CongTacKiemTra", TypeLanguage)
            vRowTitle("CTKiemTraBaoTri") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "CTKiemTraBaoTri", TypeLanguage)
            vRowTitle("ThongSo") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "ThongSo", TypeLanguage)
            vRowTitle("Dat") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "Dat", TypeLanguage)
            vRowTitle("KhongDat") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "KhongDat", TypeLanguage)
            vRowTitle("MoTaCV") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "MoTaCV", TypeLanguage)
            vRowTitle("DeXuat") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "DeXuat", TypeLanguage)
            vRowTitle("ThucHienLuc") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "ThucHienLuc", TypeLanguage)
            vRowTitle("Ngay") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "Ngay", TypeLanguage)
            vRowTitle("HoanThanhLuc") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "HoanThanhLuc", TypeLanguage)
            vRowTitle("VatTuThayThe") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "VatTuThayThe", TypeLanguage)
            vRowTitle("Co") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "Co", TypeLanguage)
            vRowTitle("Khong") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "Khong", TypeLanguage)
            vRowTitle("TenVT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "TenVT", TypeLanguage)
            vRowTitle("MaVT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "MaVT", TypeLanguage)
            vRowTitle("SLuong") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "SLuong", TypeLanguage)
            vRowTitle("KhoCoDien") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "KhoCoDien", TypeLanguage)
            vRowTitle("PhuTrachDVSD") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "PhuTrachDVSD", TypeLanguage)
            vRowTitle("DanhGia") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "DanhGia", TypeLanguage)
            vRowTitle("ChuKy") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "ChuKy", TypeLanguage)
            vRowTitle("KyThuatVien") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "KyThuatVien", TypeLanguage)
            vRowTitle("PQDPX") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "PQDPX", TypeLanguage)
            vRowTitle("KyTen") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "ChuKy", TypeLanguage)
            vRowTitle("STT") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "STT", TypeLanguage)
            vRowTitle("Mekophar") = ObjLanguages.GetLanguage(ModuleName, "rptPHIEU_BAO_TRI_MEKOPHAR", "Mekophar", TypeLanguage)

            tbTitle.Rows.Add(vRowTitle)
        Catch ex As Exception

        End Try
        Return tbTitle

    End Function

    Private Sub btnChonMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonMay.Click
        Dim frm As New ReportMain.Forms.frmYCSDChonMay()
        frm.iLoai = 2
        If frm.ShowDialog() = DialogResult.Cancel Then Exit Sub
        cboMAY.EditValue = SQLString
    End Sub

    Private Sub btnXemTonKhoPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New ReportMain.Forms.frmChonKhoInDMTB()
        frm.iLBCao = 2
        frm.sMsPBT = txtMaSoPBT.Text
        frm.ShowDialog()
    End Sub

    Private Sub btnHThanhNS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHThanhNT.Click
        HoanThanhPBT()
    End Sub

    Private Sub GoiMailHoanThanhNT(Optional ByVal NThu As Object = False)

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf GoiMailHoanThanhNT), NThu)
        Else
            Dim sMailYC As String
            Dim sSql As String
            'sSql = "declare @sName nvarchar(4000) " &
            '        " SET @sName = ''  " &
            '        " SELECT @sName =  COALESCE(ISNULL(@sName,'') + CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE '; ' END  ,'') + USER_MAIL FROM  " &
            '        " (SELECT DISTINCT USER_MAIL  FROM YEU_CAU_NSD_CHI_TIET A INNER JOIN  YEU_CAU_NSD B ON A.STT = B.STT INNER JOIN USERS C ON B.USER_LAP = C.USERNAME WHERE MS_PBT = '" & txtMaSoPBT.Text & "'   " &
            '        " UNION SELECT USER_MAIL  	FROM YEU_CAU_NSD_CHI_TIET A INNER JOIN USERS C ON A.USERNAME_DSX = C.USERNAME WHERE MS_PBT = '" & txtMaSoPBT.Text & "'  " &
            '        " UNION SELECT USER_MAIL  	FROM YEU_CAU_NSD_CHI_TIET A INNER JOIN USERS C ON A.USERNAME_DBT = C.USERNAME WHERE MS_PBT = '" & txtMaSoPBT.Text & "'  ) A   " &
            '        " SELECT @sName "

            sSql = "declare @sName nvarchar(4000) " &
                    " SET @sName = ''  " &
                    " SELECT @sName =  COALESCE(ISNULL(@sName,'') + CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE '; ' END  ,'') + USER_MAIL FROM  " &
                    " (
                            SELECT        
                            ISNULL(T3.USER_MAIL,'') + CASE ISNULL(T3.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T1.EMAIL_NSD,'') + CASE ISNULL(T1.EMAIL_NSD,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T5.USER_MAIL,'') + CASE ISNULL(T5.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T2.EMAIL_DSX,'') + CASE ISNULL(T2.EMAIL_DSX,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T4.USER_MAIL,'') + CASE ISNULL(T4.USER_MAIL,'') WHEN '' THEN '' ELSE '; ' END  + 
                            ISNULL(T2.EMAIL_DBT,'') + CASE ISNULL(T2.EMAIL_DBT,'') WHEN '' THEN '' ELSE '; ' END  AS USER_MAIL
                            FROM            dbo.USERS AS T4 RIGHT OUTER JOIN
                                dbo.YEU_CAU_NSD_CHI_TIET AS T2 ON T4.USERNAME = T2.USERNAME_DBT LEFT OUTER JOIN
                                dbo.USERS AS T5 ON T2.USERNAME_DSX = T5.USERNAME RIGHT OUTER JOIN
                                dbo.YEU_CAU_NSD AS T1 LEFT OUTER JOIN
                                dbo.USERS AS T3 ON T1.USER_LAP = T3.USERNAME ON T2.STT = T1.STT 
                            WHERE        (T2.MS_PBT = '" & txtMaSoPBT.Text & "'  )                      
                        ) A   " &
                    " SELECT @sName "

            Try
                sMailYC = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            Catch ex As Exception
                sMailYC = ""
            End Try
            If sPrivate = "BARIA" Then
                Try
                    sSql = " SELECT TOP 1 USER_MAIL FROM PHIEU_BAO_TRI A INNER JOIN CONG_NHAN B ON A.NGUOI_LAP = B.MS_CONG_NHAN WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' "
                    sMailYC = IIf(sMailYC.Trim = "", "", sMailYC + ";") & Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                Catch ex As Exception
                End Try
            End If
            sMailYC = ObjSystems.MBoMailUser(sMailYC)

            Dim stmp As String
            stmp = "SELECT     C.MS_N_XUONG FROM YEU_CAU_NSD_CHI_TIET AS A INNER JOIN YEU_CAU_NSD AS C ON A.STT = C.STT WHERE MS_PBT = N'" + txtMaSoPBT.Text + "'"
            stmp = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, stmp))
            sMailYC = ObjSystems.MLoadMailNX(stmp, sMailYC, 3)
            sMailYC = ObjSystems.MBoMailTrung(sMailYC)
            'XtraMessageBox.Show(sMailYC)
            'XtraMessageBox.Show(iLoaiGoiMail.ToString())
            If sMailYC = "" Then
                Exit Sub
            End If
            Dim sGoi As String
            Dim sTieuDe As String
            If Convert.ToBoolean(NThu) Then
                sTieuDe = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sPBT", TypeLanguage) & " " & txtMaSoPBT.Text & " " & ObjLanguages.GetLanguage(ModuleName, Me.Name, "sDaNgiemThu", TypeLanguage)
            Else

                sTieuDe = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sPBT", TypeLanguage) + " " + txtMaSoPBT.Text + " " & ObjLanguages.GetLanguage(ModuleName, Me.Name, "sDaHoanThanh", TypeLanguage)
            End If
            Dim sPBT As String = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sPBT", TypeLanguage) + " : " + txtMaSoPBT.Text
            Dim cboNguoiLapText As String = ""
            cboNguoiLap1.Invoke(New MethodInvoker(Sub() cboNguoiLapText = cboNguoiLap1.Text))
            Dim sNgayLap As String = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sNgayLap", TypeLanguage) + " : " + dtNgayLap1.DateTime.ToString("dd/MM/yyyy") + " " & ObjLanguages.GetLanguage(ModuleName, Me.Name, "sNguoiLap", TypeLanguage) + " : " + cboNguoiLap1.Text

            Dim sMaThietBi As String = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sMaThietBi", TypeLanguage) + " : " + cboMAY.EditValue + " " & ObjLanguages.GetLanguage(ModuleName, Me.Name, "sTenThietBi", TypeLanguage) + " : " &
        Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TEN_MAY FROM MAY WHERE MS_MAY = '" & cboMAY.EditValue & "' "))

            Dim sMaYeuCau As String
            sSql = "declare @sName nvarchar(4000)  " &
                                           " SET @sName = ''" &
                                           " SELECT @sName =  COALESCE(ISNULL(@sName,'') + CASE LEN(ISNULL(@sName,'')) WHEN 0 THEN '' ELSE '; ' END  ,'') + B.MS_YEU_CAU " &
                                           " 	FROM YEU_CAU_NSD_CHI_TIET A INNER JOIN  YEU_CAU_NSD B ON A.STT = B.STT  WHERE MS_PBT = '" & txtMaSoPBT.Text & "'" &
                                           " SELECT @sName"

            Try
                sMaYeuCau = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sMaYeuCau", TypeLanguage) + " : " &
                            Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            Catch ex As Exception
                sMaYeuCau = ""
            End Try


            Dim sGhiChu As String = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sGhiChu", TypeLanguage) + " : " + txtLydo_1.Text

            'Tiêu đề: Phiếu bảo trì +MS_PHIEU_BAO_TRI đã nghiệm thu
            '        Nội(dung)
            'Phiếu bảo trì +MS_PHIEU_BAO_TRI 
            'Ngày lập:…. Người lập…..
            'Mã thiết bị:…….Tên thiết bị….
            'Mã yêu cầu: yêu cầu 1; yêu cầu 2
            '        Ghi(chú)
            'Ngày nghiệm thu:….Người nghiệm thu…..
            'Tình trạng sau bảo trì:…..

            sGoi = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sPBT + "<br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayLap + "<br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sMaThietBi + "<br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sMaYeuCau + "<br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sGhiChu + "<br>"
            If Convert.ToBoolean(NThu) Then
                Dim sNgayNT As String = ""
                Dim sTTSauBT As String = ""
                Try
                    sTTSauBT = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sTTSauBaoTri", TypeLanguage) + " : " + txtTinhTrangSauBaoTri.Text
                    sNgayNT = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sNgayNThu", TypeLanguage) + " : " + txtNgayNghiemThu.DateTime.Date.ToString("dd/MM/yyyy") + " " &
                            ObjLanguages.GetLanguage(ModuleName, Me.Name, "sNguoiNThu", TypeLanguage) + " : " + cboNguoiNghiemThu.Text
                    sGoi += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNgayNT + "<br>" +
                            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sTTSauBT + "<br>"
                Catch ex As Exception

                End Try
            End If
            sGoi += "<br>" + "<br>" + "<br>" + "</body>"

            stmp = ""
            stmp = ""
            If sMailYC <> "" Then
                If iLoaiGoiMail = 1 Or iLoaiGoiMail = 3 Then
                    If sMailFrom = "" Or sMailFromPort = "" Or sMailFromSmtp = "" Then GoTo 1
                    stmp = ""
                    stmp = Commons.Modules.MMail.MSendEmail(sMailYC, sMailFrom, sMailFromPass, sTieuDe, sGoi, "", sMailFromSmtp, sMailFromPort)
                    If stmp <> "" Then
                        'XtraMessageBox.Show(stmp)
                    End If
                End If
1:
            End If
        End If
    End Sub
#Region "Phan Hoi Thong Tin"



    Private Sub btnThemPHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemPHTT.Click
        Try

            If PermisString.Equals("Read only") Then If KiemNT() = False Then Exit Sub
            If txtMaSoPBT.Text = "" Then Exit Sub


            AnHienNutPHTT(False)
            txtNDungPHTT.Text = ""
            txtEmailPHTT.Text = ""
            txtSTTPHTT.Text = "-1"

            Dim sSql, sNXuong As String

            sSql = "SELECT TOP 1 MS_N_XUONG  FROM [dbo].[MashjGetMayNhaXuong]('" &
                        cboMAY.EditValue & "','-1', '" & dtNgayLap1.DateTime.ToString("MM/dd/yyyy") & "' )"
            sNXuong = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)


            sSql = "SELECT DBO.MGetNXuongCha( N'" + sNXuong + "')"
            sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            Dim sMsNx As String() = sSql.Split(New [Char]() {";"c})
            sSql = ""
            For i As Integer = 0 To sMsNx.Length - 1
                sSql = sSql & IIf(sSql = "", "", " UNION ") & "SELECT EMAIL FROM NHA_XUONG_EMAIL WHERE (MS_LOAI_EMAIL = 5) AND (MS_N_XUONG = N'" & sMsNx.GetValue(i).ToString() & "')"
            Next
            sSql = sSql & IIf(sSql = "", "", " UNION ") & " SELECT EMAIL FROM NHA_XUONG_EMAIL WHERE (MS_LOAI_EMAIL = 5) AND (MS_N_XUONG = N'" & sNXuong & "')"



            sSql = sSql & IIf(sSql = "", "", " UNION ") &
                    " SELECT DISTINCT B.USER_MAIL " &
                    " FROM         PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU AS A INNER JOIN" &
                    "                       CONG_NHAN AS B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN " &
                    " WHERE     (A.MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "') " &
                    " UNION " &
                    " SELECT DISTINCT B.USER_MAIL " &
                    " FROM         CONG_NHAN AS B INNER JOIN " &
                    "                       PHIEU_BAO_TRI AS A ON B.MS_CONG_NHAN = A.NGUOI_GIAM_SAT " &
                    " WHERE     (A.MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "') " &
                    " UNION " &
                    " SELECT     USERS.USER_MAIL " &
                    " FROM         PHIEU_BAO_TRI INNER JOIN " &
                    "                       USERS ON PHIEU_BAO_TRI.USERNAME_NGUOI_LAP = USERS.USERNAME " &
                    " WHERE     (PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "') " &
                    " AND (USERS.USERNAME <> '" & UserName & "') "

            sSql = " DECLARE @listStr1 VARCHAR(1000) " &
                            " SELECT @listStr1 = COALESCE(ISNULL( RTRIM(LTRIM(@listStr1)),'') ,'') +  " &
                            " + CASE LEN(ISNULL(RTRIM(LTRIM(@listStr1)),'')) WHEN 0 THEN '' ELSE '; ' END + " &
                            " ISNULL(EMAIL,'')  " &
                            " FROM (" + sSql + ") A  " &
                            " SELECT ISNULL(@listStr1,'') AS EMAIL "

            sNXuong = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

            txtEmailPHTT.Text = sNXuong
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSuaPHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuaPHTT.Click
        If PermisString.Equals("Read only") Then If KiemNT() = False Then Exit Sub
        Try

            If CheckNghiemThuPBT() Then Exit Sub

            If grvPHTT.RowCount = 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongCoDuLieuSua", TypeLanguage), Me.Text)
                Exit Sub
            End If
            If grvPHTT.GetFocusedRowCellValue("USERNAME").ToString().ToUpper() <> UserName.ToUpper() Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhacUserKhongSuaDuoc", TypeLanguage), Me.Text)
                Exit Sub
            End If
            AnHienNutPHTT(False)
            txtSTTPHTT.Text = grvPHTT.GetFocusedRowCellValue("STT").ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnXoaPHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaPHTT.Click
        Try

            If PermisString.Equals("Read only") Then If KiemNT() = False Then Exit Sub

            If grvPHTT.RowCount = 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongCoDuLieuXoa", TypeLanguage), Me.Text)
                Exit Sub
            End If
            If CheckNghiemThuPBT() Then Exit Sub


            If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                        "CoChacXoaPHTT", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim sSql As String
            Try

                sSql = "DELETE FROM [PHIEU_BAO_TRI_PHAN_HOI_THONG_TIN] WHERE MS_PHIEU_BAO_TRI = N'" + txtMaSoPBT.Text + "' AND STT = " + grvPHTT.GetFocusedRowCellValue("STT").ToString
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Catch ex As Exception
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "XoaPHTTKhongThanhCong", TypeLanguage), Me.Text)
            End Try

            LoadLuoiPHTT(txtMaSoPBT.Text, Integer.Parse(-1))
            If grvPHTT.RowCount = 0 Then
                txtNDungPHTT.Text = ""
                txtEmailPHTT.Text = ""
                txtSTTPHTT.Text = "-1"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGhiPHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhiPHTT.Click
        Try
            If txtNDungPHTT.Text.Trim = "" Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "ChuaNhapNDungPHTT", TypeLanguage), Me.Text)
                txtNDungPHTT.Focus()
                Exit Sub
            End If
            If txtEmailPHTT.Text.Length <> 0 Then
                Dim sChuoi As String
                Dim sMail() As String = Split(txtEmailPHTT.Text, ";")
                sChuoi = ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongPhaiMail", TypeLanguage)
                For i As Integer = 0 To sMail.Length - 1
                    If ObjSystems.MCheckEmail(sMail(i)) = False Then
                        XtraMessageBox.Show(sMail(i) + " " + sChuoi, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtEmailPHTT.Focus()
                        Exit Sub
                    End If
                Next

            End If

            Dim iSTT As String
            iSTT = "-1"

            iSTT = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "INSPBTPhanHoiThongTin", txtMaSoPBT.Text,
                    Integer.Parse(txtSTTPHTT.Text), txtNDungPHTT.Text, txtEmailPHTT.Text, UserName.ToString()))
            AnHienNutPHTT(True)
            LoadLuoiPHTT(txtMaSoPBT.Text, Integer.Parse(iSTT))

            Dim sPhanHoi, sThietBi, sTenTBi, sSPhieu, sNgayPhanHoi, sUname, sNDung, sGoi, sMailSent, sMailCC As String
            sMailCC = ""
            sTenTBi = "SELECT TEN_MAY FROM MAY WHERE MS_MAY = N'" + cboMAY.EditValue + "' "
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTenTBi))
            If dtTmp.Rows.Count > 0 Then
                sTenTBi = dtTmp.Rows(0)("TEN_MAY").ToString()
            Else
                sTenTBi = ""
            End If

            sPhanHoi = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sPhanHoi", TypeLanguage) + " : " + txtMaSoPBT.Text
            sThietBi = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sThietBi", TypeLanguage) + " : " + cboMAY.EditValue
            sTenTBi = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sTenTBi", TypeLanguage) + " : " + sTenTBi
            sSPhieu = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sSPhieu", TypeLanguage) + " : " + txtSoPhieuBaoTri1.Text
            sNgayPhanHoi = ""
            Try
                sNgayPhanHoi = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sNgayPhanHoi", TypeLanguage) + " : " + grvPHTT.GetFocusedRowCellValue("THOI_GIAN").ToString()
            Catch ex As Exception

            End Try
            sUname = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sUname", TypeLanguage) + " : " + grvPHTT.GetFocusedRowCellValue("USERNAME").ToString()
            sNDung = ObjLanguages.GetLanguage(ModuleName, Me.Name, "sNDung", TypeLanguage) + " : " + grvPHTT.GetFocusedRowCellValue("NOI_DUNG").ToString()

            sMailSent = txtEmailPHTT.Text
            Dim ALL_EMAILS As [String]() = sMailSent.Split(";"c)
            For Each emailaddress As String In ALL_EMAILS
                sMailSent = emailaddress
                Exit For
            Next
            Try

                sMailCC = txtEmailPHTT.Text.Replace(sMailSent + ";", "").Trim
                If sMailCC.Substring(0, 1).Trim = ";" Then
                    sMailCC = sMailCC.Substring(1, sMailCC.Length - 1)
                End If
                If sMailCC.Substring(1, 1).Trim = ";" Then
                    sMailCC = sMailCC.Substring(2, sMailCC.Length - 2)
                End If
                If sMailCC.Substring(2, 1).Trim = ";" Then
                    sMailCC = sMailCC.Substring(3, sMailCC.Length - 3)
                End If
            Catch ex As Exception

            End Try


            sGoi = "<body>" + sThietBi + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + sTenTBi + "<br>" + sSPhieu +
                " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + sNgayPhanHoi +
                " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + sUname + "<br>" + sNDung + "</body>"

            Dim stmp As String
            stmp = ""
            If sMailSent <> "" And sMailCC <> "" Then
                If iLoaiGoiMail = 1 Or iLoaiGoiMail = 3 Then
                    If sMailFrom = "" Or sMailFromPort = "" Or sMailFromSmtp = "" Then GoTo 1
                    stmp = ""
                    stmp = Commons.Modules.MMail.MSendEmail(sMailSent, sMailFrom, sMailFromPass,
                                            sPhanHoi, sGoi, "", sMailFromSmtp, sMailFromPort)
                    If stmp <> "" Then
                        XtraMessageBox.Show(stmp)
                    End If
                End If
1:
                If iLoaiGoiMail = 2 Or iLoaiGoiMail = 3 Then
                    sGoi = sThietBi + "        " + sTenTBi + vbCrLf + sSPhieu +
                        "        " + sNgayPhanHoi +
                        "        " + sUname + vbCr + sNDung + ""
                    If Commons.Modules.MMail.CapNhapMailVaoCSDL("", "", sMailSent.Trim, sMailCC.Trim, "", sPhanHoi, sGoi, stmp) = False Then
                        XtraMessageBox.Show(stmp)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub btnKhongPHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            LoadLuoiPHTT(txtMaSoPBT.Text, Integer.Parse(grvPHTT.GetFocusedRowCellValue("STT").ToString))
        Catch ex As Exception
            LoadLuoiPHTT(txtMaSoPBT.Text, Integer.Parse(-1))
        End Try
        AnHienNutPHTT(True)
    End Sub

    Private Sub btnThoatPHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatPHTT.Click
        Me.Close()
    End Sub

    Private Sub LoadLuoiPHTT(ByVal sMsPBT As String, ByVal iSTT As Integer)
        Try

            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPBTPHTT", sMsPBT))
            If dtTmp.Rows.Count = 0 Then
                txtNDungPHTT.Text = ""
                txtEmailPHTT.Text = ""
            End If
            Dim vKey(1) As DataColumn
            vKey(0) = dtTmp.Columns("STT")
            dtTmp.PrimaryKey = vKey
            ObjSystems.MLoadXtraGrid(grdPHTT, grvPHTT, dtTmp, False, False, True, False, True, Me.Name)
            If iSTT <> -1 Then
                Dim index As Integer
                index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iSTT))
                grvPHTT.FocusedRowHandle = grvPHTT.GetRowHandle(index)
            End If

            If grvPHTT.Columns("STT").Visible = True Then
                grvPHTT.Columns("NOI_DUNG").Width = 500
                grvPHTT.Columns("EMAIL").Width = 300
            End If
            grvPHTT.Columns("NOI_DUNG").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "NOI_DUNG_PHTT", TypeLanguage)
            grvPHTT.Columns("STT").Visible = False

            grvPHTT.Columns("THOI_GIAN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            grvPHTT.Columns("THOI_GIAN").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            txtNDungPHTT.DataBindings.Clear()
            txtNDungPHTT.DataBindings.Add("Text", dtTmp, "NOI_DUNG")
            txtEmailPHTT.DataBindings.Clear()
            txtEmailPHTT.DataBindings.Add("Text", dtTmp, "EMAIL")
            txtSTTPHTT.DataBindings.Clear()
            txtSTTPHTT.DataBindings.Add("Text", dtTmp, "STT")



        Catch ex As Exception

        End Try

    End Sub

    Private Sub AnHienNutPHTT(ByVal bAn As Boolean)
        btnThemPHTT.Visible = bAn
        btnSuaPHTT.Visible = bAn
        btnXoaPHTT.Visible = bAn
        btnThoatPHTT.Visible = bAn
        btnGhiPHTT.Visible = Not bAn
        btnKhongPHTT.Visible = Not bAn
        txtNDungPHTT.Properties.ReadOnly = bAn
        txtEmailPHTT.Properties.ReadOnly = bAn
        If bAn = False Then
            txtNDungPHTT.DataBindings.Clear()
            txtEmailPHTT.DataBindings.Clear()
            txtSTTPHTT.DataBindings.Clear()
            txtNDungPHTT.Focus()
        End If
        grdPHTT.Enabled = bAn

    End Sub

    Function KiemNT() As Boolean
        If txtMaSoPBT.Text.Trim = "" Then
            Return True
            Exit Function
        End If

        Dim str As String = ""
        str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
        " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=8 "
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim tmp As Boolean = False
        While objReader.Read
            If objReader.Item("STT").ToString <> "" Then
                tmp = True
            End If
        End While
        objReader.Close()
        If Not tmp Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "BanKhongCoQuyenThemSuaPHTT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            Exit Function
        End If
        Return True
    End Function

    Function KiemHoanThanh() As Boolean
        If txtMaSoPBT.Text.Trim = "" Then
            Return True
            Exit Function
        End If
        If cboTinhTrangPBT.SelectedValue = 3 Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "DaHoanThanhMuonChinhSua", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                Try
                    grvDanhSach_1.SetRowCellValue(intRowPBT, "TINH_TRANG_PBT", 2)
                Catch ex As Exception
                End Try
                cboTinhTrangPBT.SelectedValue = 2
                bHuyHT = 1
            Else
                bHuyHT = 0
                Return False
                Exit Function
            End If

        End If
        Return True
    End Function

#End Region
    Private Sub optNTHT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNTHT.SelectedIndexChanged
        BindData()
        intRowPBT = grvDanhSach_1.FocusedRowHandle
        ShowData()
        Dim str As String = ""
        str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
        " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=8 "
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While objReader.Read
            If objReader.Item("STT").ToString <> "" Then
                bCoQuyen = True
            End If
        End While
        objReader.Close()
        If Not bCoQuyen Then
            TinhtrangPBT_Lock(False)
        End If
        If PermisString.Equals("Read only") Then
            TinhtrangPBT_Lock(False)
        Else
            If optNTHT.SelectedIndex = 2 Then
                btnIn_1.Enabled = True
                btnThem_1.Enabled = False
                btnXoaPBTK.Enabled = False
            Else
                btnIn_1.Enabled = True
                btnThem_1.Enabled = True
                btnXoaPBTK.Enabled = True
            End If
        End If

        If optNTHT.SelectedIndex = 0 Then
            btnInPBT.Enabled = True
        Else
            btnInPBT.Enabled = False
        End If

    End Sub


    Private Sub btnInPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInPBT.Click
        If grvDanhSach_1.RowCount = 0 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongCoDuLieuIn", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim frm As New ReportMain.frmChonInPhieuBaoTri
        frm.iLoaiIP = 0
        Dim dtTmp = New DataTable
        dtTmp = CType(grdDanhSach_1.DataSource, DataTable).Copy()
        Dim column As New DataColumn("CHON")
        column.DataType = GetType(Boolean)
        column.DefaultValue = "0"
        dtTmp.Columns.Add(column)
        column.SetOrdinal(0)
        frm.dtPhieuBaoTri = New System.Data.DataTable()
        frm.dtPhieuBaoTri = dtTmp
        If frm.dtPhieuBaoTri.Rows.Count = 0 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongCoDuLieuIn", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            frm.sNguoiLap = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT TOP 1 B.HO + '' + B.TEN FROM USERS A INNER JOIN CONG_NHAN B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN WHERE USERNAME = N'" & UserName & "'")
        Catch ex As Exception
            frm.sNguoiLap = ""
        End Try

        If Commons.Modules.sPrivate.ToUpper = "PILMICO" Then
            frm.sNgayLap = Now.ToString("HH:mm dd/MM/yyyy")
        Else
            frm.sNgayLap = Now.ToString
        End If

        If sDiaDiem = "-1" Then
            frm.ssDiaDiem = "ALL"
        Else
            Try
                frm.ssDiaDiem = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT TOP 1 CASE " & Modules.TypeLanguage & " WHEN 0 THEN TEN_N_XUONG WHEN 1 THEN TEN_N_XUONG_A ELSE TEN_N_XUONG_H END AS TNX FROM NHA_XUONG WHERE MS_N_XUONG = '" & sDiaDiem & "' ")
            Catch ex As Exception
                frm.sNguoiLap = ""
            End Try
        End If
        If iDayChuyen = -1 Then
            frm.sDayChuyen = "ALL"
        Else
            Try
                frm.sDayChuyen = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT TOP 1 TEN_HE_THONG FROM HE_THONG WHERE MS_HE_THONG = " & iDayChuyen.ToString & " ")
            Catch ex As Exception
                frm.sDayChuyen = ""
            End Try
        End If
        frm.sLyDo = lblLyDo.Text
        If frm.ShowDialog() = DialogResult.Cancel Then Exit Sub
        If sPrivate.ToUpper = "VECO" Then
            Dim sBT As String = "PRINT_MU" + UserName
            dtTmp = New DataTable()
            dtTmp = frm.dtPhieuBaoTri.Copy()
            ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, frm.dtPhieuBaoTri, "")
            SQLString = "InNhieuPBT"
            Try
                btnIn_1_Click(Nothing, Nothing)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message)
            End Try

            SQLString = ""
        End If


    End Sub

#Region "Yeu cau nguoi su dung"
    Private Sub LoadYCNSD(ByVal MsPBT As String)
        Try

            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYeuCauNSDBaoTri", MsPBT))
            ObjSystems.MLoadXtraGrid(grdYCBT, grvYCBT, dtTmp, False, False, True, False)
            If grvYCBT.Columns("STT_VAN_DE").Visible = False Then Exit Sub
            ObjSystems.MLoadNNXtraGrid(grvYCBT, Me.Name.ToString())

            grvYCBT.Columns("STT_VAN_DE").Visible = False
            grvYCBT.Columns("MS_MAY").Visible = False
            grvYCBT.Columns("STT").Visible = False
            grvYCBT.Columns("MS_PBT").Visible = False

            '          	SELECT B.MS_YEU_CAU, B.SO_YEU_CAU, A.MO_TA_TINH_TRANG, A.YEU_CAU, A.NGAY_XAY_RA, A.GIO_XAY_RA, A.THOI_GIAN_DSX, 
            'A.NGAY_DBT, A.MS_PBT, A.STT ,A.MS_MAY, A.STT_VAN_DE


            grvYCBT.Columns("GIO_XAY_RA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            grvYCBT.Columns("GIO_XAY_RA").DisplayFormat.FormatString = "HH:mm:ss"


            grvYCBT.Columns("THOI_GIAN_DSX").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            grvYCBT.Columns("THOI_GIAN_DSX").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            grvYCBT.Columns("NGAY_DBT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            grvYCBT.Columns("NGAY_DBT").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ThemSuaYCSD(ByVal ThemSua As Boolean)
        btnThemSuaYCBT.Visible = Not ThemSua
        btnXoaYCBT.Visible = Not ThemSua
        btnThoatYCBT.Visible = Not ThemSua
        btnGhiYCBT.Visible = ThemSua
        btnKhongGhiYCBT.Visible = ThemSua
        btnChonYCSD.Visible = ThemSua
    End Sub

    Private Sub btnThoatYCBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatYCBT.Click
        Me.Close()
    End Sub

    Private Sub btnXoaYCBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaYCBT.Click
        If KiemPQ(1) = False Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongCoQuyenXoaYCSD", TypeLanguage), Me.Text)
            Exit Sub
        End If
        If grvYCBT.RowCount = 0 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "KhongCoDuLieuXoa", TypeLanguage), Me.Text)
            Exit Sub
        End If
        If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "CoChacXoaYCBT", TypeLanguage),
                           Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        Dim sSql As String
        sSql = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT = NULL , MS_CACH_TH = '06' WHERE STT = " & grvYCBT.GetFocusedDataRow("STT").ToString &
                    " AND MS_MAY = '" & grvYCBT.GetFocusedDataRow("MS_MAY").ToString & "' " &
                    " AND STT_VAN_DE = " & grvYCBT.GetFocusedDataRow("STT_VAN_DE").ToString
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        LoadYCNSD(txtMaSoPBT.Text)
    End Sub

    Private Sub btnThemSuaYCBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemSuaYCBT.Click
        ThemSuaYCSD(True)
    End Sub

    Private Sub btnGhiYCBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhiYCBT.Click
        Dim sSql, sBT As String
        Dim dtTmp As New DataTable
        dtTmp = CType(grdYCBT.DataSource, DataTable)

        sBT = "SD" & UserName
        ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "")

        sSql = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT = '" & txtMaSoPBT.Text & "' , MS_CACH_TH = '04' " &
                    " FROM YEU_CAU_NSD_CHI_TIET A INNER JOIN " & sBT & " B ON A.STT = B.STT AND A.MS_MAY = B.MS_MAY AND A.STT_VAN_DE = B.STT_VAN_DE "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        ObjSystems.XoaTable(sBT)

        LoadYCNSD(txtMaSoPBT.Text)
        ThemSuaYCSD(False)
    End Sub

    Private Sub btnKhongGhiYCBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhiYCBT.Click
        LoadYCNSD(txtMaSoPBT.Text)
        ThemSuaYCSD(False)
    End Sub

    Private Sub btnChonYCSD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonYCSD.Click
        Dim frm As New frmChonYCSDPBT
        Dim dtTmp As New DataTable
        frm.sMS_MAY = cboMAY.EditValue
        frm.dNGAY_KTKH = dtNgayKTKH1.DateTime.Date
        dtYCSD = New DataTable
        dtTmp = CType(grdYCBT.DataSource, DataTable)
        Dim sBT As String = "SD_CHON" & UserName
        ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "")

        If frm.ShowDialog = DialogResult.Cancel Then Exit Sub
        dtYCSD.DefaultView.RowFilter = "CHON = 1"
        dtYCSD = dtYCSD.DefaultView.ToTable
        Dim dtRow As DataRow
        dtTmp = New DataTable
        dtTmp = CType(grdYCBT.DataSource, DataTable)
        For i As Integer = 0 To dtYCSD.Rows.Count - 1
            dtRow = dtTmp.NewRow
            dtRow.Item("MS_YEU_CAU") = dtYCSD.Rows(i)("MS_YEU_CAU")
            dtRow.Item("SO_YEU_CAU") = dtYCSD.Rows(i)("SO_YEU_CAU")
            dtRow.Item("MO_TA_TINH_TRANG") = dtYCSD.Rows(i)("MO_TA_TINH_TRANG")


            dtRow.Item("YEU_CAU") = dtYCSD.Rows(i)("YEU_CAU")
            dtRow.Item("NGAY_XAY_RA") = dtYCSD.Rows(i)("NGAY_XAY_RA")
            dtRow.Item("GIO_XAY_RA") = dtYCSD.Rows(i)("GIO_XAY_RA")
            dtRow.Item("THOI_GIAN_DSX") = dtYCSD.Rows(i)("THOI_GIAN_DSX")
            dtRow.Item("NGAY_DBT") = dtYCSD.Rows(i)("NGAY_DBT")
            dtRow.Item("MS_PBT") = txtMaSoPBT.Text
            dtRow.Item("STT") = dtYCSD.Rows(i)("STT")
            dtRow.Item("MS_MAY") = dtYCSD.Rows(i)("MS_MAY")
            dtRow.Item("STT_VAN_DE") = dtYCSD.Rows(i)("STT_VAN_DE")


            dtTmp.Rows.Add(dtRow)
        Next
    End Sub


    Private Function KiemPQ(ByVal iKiem As Integer) As Boolean
        Dim str As String = ""
        str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
        " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT = " & iKiem.ToString
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If dtTmp.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function
#End Region

    Private Sub btnNHHTNTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNHHTNTL.Click
        Try
            Dim frm As MReportVB.frmPhieuBaoTriBHNT = New MReportVB.frmPhieuBaoTriBHNT()
            If ObjSystems.check_permission(UserName, frm.Name) Then
                SQLString = "0LOAD"
                frm.dTNgay = dtTNgay_1.EditValue
                frm.dDNgay = dtDNgay_1.EditValue
                frm.ShowDialog()
                BindData()
                intRowPBT = grvDanhSach_1.FocusedRowHandle
                ShowData()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim DKLoc As String = ""
    Private Sub btnLocPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocPBT.Click
        Dim frm As ReportMain.frmTimPBT


        If DKLoc <> "" Then
            frm = New ReportMain.frmTimPBT(DKLoc)
        Else
            frm = New ReportMain.frmTimPBT()
        End If

        frm.TuNgay = dtTNgay_1.EditValue
        frm.DenNgay = dtDNgay_1.EditValue

        If frm.ShowDialog() = DialogResult.Cancel Then Exit Sub
        dtDNgay_1.Text = frm.DenNgay


        sDiaDiem = frm.DiaDiem
        iDayChuyen = frm.MsDayChuyen
        sLoaiMay = frm.LoaiMay
        sNhomMay = frm.NhomMay
        sMsMay = frm.MsMay
        iLoaiBaoTri = frm.LoaiBaoTri

        sNguoiLap = frm.NguoiLap
        sNGSat = frm.NguoiGSat
        iNNhan = frm.NguyenNhan
        Try
            DKLoc = ""
            DKLoc = frm.TuNgay.ToString() & "|" & frm.DenNgay.ToString() & "|" & frm.MsDayChuyen.ToString() & "|" & frm.LoaiMay.ToString() & "|" & frm.NhomMay.ToString() & "|" & frm.MsMay.ToString() & "|" & frm.LoaiBaoTri.ToString() & "|" & frm.NguoiLap.ToString() & "|" & frm.NguoiGSat.ToString() & "|" & frm.NguyenNhan.ToString() & "|" & frm.DiaDiem
        Catch ex As Exception

        End Try

        BindData()

        intRowPBT = grvDanhSach_1.FocusedRowHandle
        ShowData()

    End Sub

    'SYN
    Private Sub btnAllocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllocate.Click
        If txtMaSoPBT.Text = "" Then Exit Sub

        'Phan Bo
        If sPrivate = "BARIA" Then
            Dim frmBR As New ReportHuda.frmChonVTINTPBT
            frmBR.sPBT = txtMaSoPBT.Text
            frmBR.sMay = cboMAY.EditValue
            frmBR.iLoaiForm = 0
            If frmBR.ShowDialog = DialogResult.Cancel Then Exit Sub
            PhanBoBaria(txtMaSoPBT.Text)
            BindData5()
        Else

            Dim frm As New frmPhieuBaoTriAllocateVTPT
            frm.MS_PHIEU_BT = txtMaSoPBT.Text.ToString().Trim()
            frm.MS_MAY = cboMAY.EditValue().Trim()
            frm.DataAllocate = _DataAllocatedVTPT

            TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows.Clear()
            CreateDataGridViewVTAllocated()
            LoadDataAllocated()
            AllocateVTAfterChoose()

            If frm.ShowDialog() = DialogResult.OK Then
                _DataAllocatedVTPT = frm.DataAllocate
                XoaSL_Allocated_PT_notin_DTAllocated()
                AllocatePTAfterChoose()
                AllocateVTAfterChoose()
            End If
        End If
    End Sub

    Private Sub PhanBoBaria(ByVal MsPBT As String)
        Dim sSql As String
        Try
            SqlHelper.ExecuteNonQuery(IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_PHIEU_BAO_TRI = '" & MsPBT & "' ")

            sSql = " SELECT A.MS_PT, A.SPT, B.SPX, CASE WHEN A.SPT > 1 THEN 1 ELSE 0 END NHIEU " &
                        " FROM(SELECT MS_PT,COUNT(MS_PT) SPT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET  " &
                        " WHERE MS_PHIEU_BAO_TRI =  N'" & MsPBT & "' GROUP BY MS_PT ) A INNER JOIN  " &
                        " (SELECT T2.MS_PT, COUNT(T2.MS_PT) AS SPX FROM dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN dbo.IC_DON_HANG_XUAT_VAT_TU AS T2  " &
                        " ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT INNER JOIN dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T3  " &
                        " ON T2.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT AND T2.MS_PT = T3.MS_PT " &
                        " WHERE (T1.MS_PHIEU_BAO_TRI =  N'" & MsPBT & "')  " &
                        " GROUP	BY T2.MS_PT) B ON A.MS_PT = B.MS_PT " ' WHERE CASE WHEN A.SPT > 1 THEN 1 ELSE 0 END = 1"
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sSql))
            For Each dr As DataRow In dtTmp.Rows
                sSql = " SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI = '" & MsPBT & "' AND MS_PT = '" & dr("MS_PT").ToString & "'"
                Dim dtTmpBP As New DataTable
                dtTmpBP.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sSql))
                Dim i As Integer
                i = 0
                For Each drBP As DataRow In dtTmpBP.Rows

                    sSql = " SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI = '" & MsPBT & "' AND MS_PT = '" & dr("MS_PT").ToString & "' " &
                        " AND MS_BO_PHAN = '" & drBP("MS_BO_PHAN").ToString & "' AND MS_CV = " & drBP("MS_CV").ToString & " AND STT = " & drBP("STT").ToString & ""
                    Dim dtTmpPT As New DataTable
                    dtTmpPT.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sSql))
                    For Each drPT As DataRow In dtTmpPT.Rows
                        Dim dtTmpPX As New DataTable

                        sSql = " SELECT DISTINCT T1.MS_DH_XUAT_PT, T2.MS_PT, T2.SO_LUONG_THUC_XUAT AS SL_XUAT,T3.ID_XUAT, T3.MS_DH_NHAP_PT " &
                                    " FROM dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN " &
                                    " dbo.IC_DON_HANG_XUAT_VAT_TU AS T2 ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT INNER JOIN " &
                                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T3 ON T2.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT AND T2.MS_PT = T3.MS_PT " &
                                    " WHERE (T1.MS_PHIEU_BAO_TRI = N'" & MsPBT & "' )   AND (T2.MS_PT = '" & dr("MS_PT").ToString & "') "
                        dtTmpPX.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, CommandType.Text, sSql))
                        Dim SLPT As Double
                        SLPT = Double.Parse(drPT("SL_KH").ToString)
                        For Each drPX As DataRow In dtTmpPX.Rows

                            Try
                                sSql = " SELECT ISNULL(SUM(SL_TT),0) AS SL_DX " &
                                                " FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO " &
                                                " WHERE (MS_PT = N'" & dr("MS_PT").ToString & "') AND (MS_DH_XUAT_PT = N'" & drPX("MS_DH_XUAT_PT").ToString & "') " &
                                                " AND (MS_DH_NHAP_PT = N'" & drPX("MS_DH_NHAP_PT").ToString & "') AND (MS_PTTT = N'" & dr("MS_PT").ToString & "') " &
                                                " AND (ID = " & drPX("ID_XUAT").ToString & ") "
                            Catch ex As Exception

                            End Try
                            Dim SLXuat As Double
                            Dim SLDaXuat As Double
                            SLDaXuat = 0
                            SLXuat = 0
                            SLDaXuat = Convert.ToDouble(SqlHelper.ExecuteScalar(IConnections.ConnectionString, CommandType.Text, sSql))
                            SLXuat = Double.Parse(drPX("SL_XUAT").ToString)

                            If SLXuat = SLDaXuat Then
                                SLXuat = 0
                            Else
                                If SLXuat > SLDaXuat Then
                                    SLXuat = SLXuat - SLDaXuat
                                Else
                                    If SLXuat < SLDaXuat Then
                                        SLXuat = Double.Parse(drPX("SL_XUAT").ToString) - SLXuat
                                    End If
                                End If
                            End If


                            If SLPT < SLXuat Then
                                If dr("NHIEU").ToString = 1 And i < dtTmpBP.Rows.Count - 1 Then
                                    SLXuat = SLPT
                                End If
                            End If



                            'End If
                            sSql = " INSERT INTO [PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO]([MS_PHIEU_BAO_TRI],[MS_CV],[MS_BO_PHAN],[MS_PT],[STT],[MS_DH_XUAT_PT], " &
                                        " 	[MS_DH_NHAP_PT],[MS_PTTT],[ID],[SL_TT],[DON_GIA],[NGOAI_TE],[TI_GIA],[TI_GIA_USD]) " &
                                        " SELECT MS_PHIEU_BAO_TRI, " & drBP("MS_CV").ToString & " AS MS_CV, N'" & drBP("MS_BO_PHAN").ToString & "' AS MS_BO_PHAN, " &
                                        " T2.MS_PT, " & drBP("STT").ToString & " AS STT, T1.MS_DH_XUAT_PT,T3.MS_DH_NHAP_PT, T2.MS_PT, ID_XUAT, " & SLXuat & " AS SLTT, DON_GIA, NGOAI_TE, TY_GIA, TY_GIA_USD " &
                                        " FROM dbo.IC_DON_HANG_XUAT AS T1 INNER JOIN " &
                                        " dbo.IC_DON_HANG_XUAT_VAT_TU AS T2 ON T1.MS_DH_XUAT_PT = T2.MS_DH_XUAT_PT INNER JOIN " &
                                        " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS T3 ON T2.MS_DH_XUAT_PT = T3.MS_DH_XUAT_PT AND T2.MS_PT = T3.MS_PT INNER JOIN " &
                                        " dbo.IC_DON_HANG_NHAP_VAT_TU AS T6 ON T3.MS_DH_NHAP_PT = T6.MS_DH_NHAP_PT AND T3.ID_XUAT = T6.ID AND T3.MS_PT = T6.MS_PT " &
                                        " WHERE     (T1.MS_PHIEU_BAO_TRI = N'" & MsPBT & "') AND (T2.MS_PT = N'" & dr("MS_PT").ToString & "') " &
                                        " AND T1.MS_DH_XUAT_PT = '" & drPX("MS_DH_XUAT_PT").ToString & "' AND (T3.MS_DH_NHAP_PT = N'" & drPX("MS_DH_NHAP_PT").ToString & "') " &
                                        " AND (ID_XUAT = " & drPX("ID_XUAT").ToString & ")"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)


                            If SLPT > 0 Then SLPT = SLPT - SLXuat


                        Next
                    Next
                    i = i + 1
                Next
            Next


            sSql = " UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_TT = SL " &
                        " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T1 INNER JOIN " &
                        " (SELECT T1.MS_PHIEU_BAO_TRI, T1.MS_CV, T1.MS_BO_PHAN, T1.MS_PT, SUM(SL_TT) SL " &
                        " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T1 WHERE MS_PHIEU_BAO_TRI = N'" & MsPBT & "'  " &
                        " GROUP BY T1.MS_PHIEU_BAO_TRI, T1.MS_CV, T1.MS_BO_PHAN, T1.MS_PT) T2 ON  " &
                        "             T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI And T1.MS_CV = T2.MS_CV And T1.MS_BO_PHAN = T2.MS_BO_PHAN " &
                        " AND T1.MS_PT = T2.MS_PT "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            sSql = " UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET SET SL_TT = SL  " &
                        " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T1 INNER JOIN " &
                        " (SELECT T1.MS_PHIEU_BAO_TRI, T1.MS_CV, T1.MS_BO_PHAN, T1.MS_PT, T1.STT, SUM(SL_TT) SL " &
                        " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO T1 WHERE MS_PHIEU_BAO_TRI = N'" & MsPBT & "'  " &
                        " GROUP BY T1.MS_PHIEU_BAO_TRI, T1.MS_CV, T1.MS_BO_PHAN, T1.MS_PT, T1.STT) T2 ON  " &
                        "             T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI And T1.MS_CV = T2.MS_CV And T1.MS_BO_PHAN = T2.MS_BO_PHAN " &
                        " AND T1.MS_PT = T2.MS_PT AND T1.STT = T2.STT "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LoadDataAfterAllocated()
        Dim _dataCV_PT As New DataTable

        '_dataCV_PT = CType(grdPhuTungThayThe.DataSource, DataTable)
        _dataCV_PT = CType(grdPTThayThe.DataSource, DataTable)

        For i As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1

            Dim _CVPT As New DataView(_dataCV_PT, "MS_PT = '" + _DataAllocatedVTPT.Rows(i)("MS_PT").ToString() + "' ", "MS_CV", DataViewRowState.CurrentRows)
            Dim _SLYeuCau As Double = 0
            Double.TryParse(_DataAllocatedVTPT.Rows(i)("SL_YEU_CAU").ToString, _SLYeuCau)

            For j As Integer = 0 To _CVPT.ToTable().Rows.Count - 1

                Dim _newrow As DataRow = TB_PHU_TUNG_THAY_THE_CHI_TIET.NewRow()
                _newrow("MS_DH_XUAT_PT") = _DataAllocatedVTPT.Rows(i)("MS_DH_XUAT_PT").ToString()
                _newrow("MS_DH_NHAP_PT") = _DataAllocatedVTPT.Rows(i)("MS_DH_NHAP_PT").ToString()
                _newrow("MS_PT") = _DataAllocatedVTPT.Rows(i)("MS_PT").ToString()
                _newrow("MS_PT1") = _DataAllocatedVTPT.Rows(i)("MS_PT").ToString()
                _newrow("XUAT_XU") = ""

                _newrow("DON_GIA") = _DataAllocatedVTPT.Rows(i)("DON_GIA").ToString()
                Try
                    _newrow("NGOAI_TE") = _DataAllocatedVTPT.Rows(i)("NGOAI_TE").ToString()
                Catch ex As Exception

                End Try
                Try
                    _newrow("TY_GIA") = _DataAllocatedVTPT.Rows(i)("TY_GIA").ToString()
                Catch ex As Exception

                End Try
                Try
                    _newrow("TY_GIA_USD") = _DataAllocatedVTPT.Rows(i)("TY_GIA_USD").ToString()
                Catch ex As Exception

                End Try
                _newrow("BAO_HANH_DEN_NGAY") = DateTime.Now
                _newrow("MS_PHIEU_BAO_TRI") = txtMaSoPBT.Text.ToString()
                _newrow("MS_CV") = _CVPT.ToTable().Rows(j)("MS_CV").ToString()
                _newrow("MS_BO_PHAN") = _CVPT.ToTable().Rows(j)("MS_BO_PHAN").ToString()
                _newrow("STT") = _CVPT.ToTable().Rows(j)("STT").ToString()
                _newrow("GHI_CHU") = _CVPT.ToTable().Rows(j)("GHI_CHU").ToString()
                _newrow("ID") = _DataAllocatedVTPT.Rows(i)("ID_XUAT").ToString()

                Dim _slDaPB As Double = 0
                Dim _dataExist As New DataView(TB_PHU_TUNG_THAY_THE_CHI_TIET, "MS_DH_XUAT_PT = '" + _DataAllocatedVTPT.Rows(i)("MS_DH_XUAT_PT").ToString() + "' and MS_DH_NHAP_PT = '" + _DataAllocatedVTPT.Rows(i)("MS_DH_NHAP_PT").ToString() + "' and MS_PT = '" + _DataAllocatedVTPT.Rows(i)("MS_PT").ToString() + "' and ID = '" + _DataAllocatedVTPT.Rows(i)("ID_XUAT").ToString() + "' ", "MS_PT", DataViewRowState.CurrentRows)
                If _dataExist.ToTable().Rows.Count > 0 Then

                    For _re As Integer = 0 To _dataExist.ToTable().Rows.Count - 1
                        Dim _slpbtmp As Double = 0
                        Double.TryParse(_dataExist.ToTable().Rows(_re)("SL_TT").ToString, _slpbtmp)
                        _slDaPB = _slDaPB + _slpbtmp
                    Next
                End If


                Dim _slKH As Double = 0
                Double.TryParse(_CVPT.ToTable().Rows(j)("SL_KH").ToString, _slKH)
                If _SLYeuCau > 0 And _SLYeuCau <> _slDaPB Then

                    If _SLYeuCau > _slKH Then
                        _newrow("SL_TT") = _SLYeuCau - _slKH
                        _SLYeuCau = _SLYeuCau - _slKH
                    Else
                        _newrow("SL_TT") = _SLYeuCau
                        _SLYeuCau = 0
                    End If
                Else
                    _SLYeuCau = 0
                    _newrow("SL_TT") = 0
                End If
                Dim _dataExistTmp As New DataView(TB_PHU_TUNG_THAY_THE_CHI_TIET, "MS_DH_XUAT_PT = '" + _DataAllocatedVTPT.Rows(i)("MS_DH_XUAT_PT").ToString() +
                                                  "' and MS_DH_NHAP_PT = '" + _DataAllocatedVTPT.Rows(i)("MS_DH_NHAP_PT").ToString() + "' and MS_PT = '" +
                                                  _DataAllocatedVTPT.Rows(i)("MS_PT").ToString() + "' and ID = '" + _DataAllocatedVTPT.Rows(i)("ID_XUAT").ToString() +
                                                  "' AND  MS_BO_PHAN = '" + _CVPT.ToTable().Rows(j)("MS_BO_PHAN").ToString() + "' AND MS_CV = '" + _CVPT.ToTable().Rows(j)("MS_CV").ToString() + "' AND STT = '" + _CVPT.ToTable().Rows(j)("STT").ToString() + "' ", "MS_PT", DataViewRowState.CurrentRows)

                If _dataExistTmp.ToTable().Rows.Count <= 0 Then
                    TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows.Add(_newrow)
                End If

            Next
        Next
    End Sub

    Private Function TongSoLuongDaPhanBo(ByVal _MS_PT As String) As Double
        Dim _sluongPB As Double = 0
        Dim _dataTmp As New DataTable()
        '_dataTmp = CType(grdPhuTungThayThe.DataSource, DataTable)
        _dataTmp = CType(grvPTThayThe.DataSource, DataTable)

        Dim _dvPTtmp As New DataView(_dataTmp, "MS_PT = '" + _MS_PT + "'", "MS_PT", DataViewRowState.CurrentRows)
        For i As Integer = 0 To _dvPTtmp.ToTable().Rows.Count - 1
            Dim _sl As Double = 0
            Double.TryParse(_dvPTtmp.ToTable().Rows(i)("SL_ALLOCATED").ToString(), _sl)
            _sluongPB = _sluongPB + _sl
        Next
        Return _sluongPB
    End Function

    Dim _DTPTTuongDuong As New DataTable
    Private Sub GetDSPhuTungTuongDuong()
        _DTPTTuongDuong = New DataTable
        Dim _strSQLPTTT As String = "SELECT MS_PT, MS_PT1" &
        "FROM(IC_PHU_TUNG_THAY_THE)" &
        "WHERE MS_PT IN  (SELECT MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI = '" + txtMaSoPBT.Text.Trim + "')"
        _DTPTTuongDuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _strSQLPTTT))
    End Sub

    Private Function TongSoLuongDaPhanBoPTTuongDuong(ByVal _MS_PT As String) As Double

        Dim _sluongPB As Double = 0
        Dim _dataTmp As New DataTable()
        '_dataTmp = CType(grdPhuTungThayThe.DataSource, DataTable)
        _dataTmp = CType(grvPTThayThe.DataSource, DataTable)

        Dim _dvPTtmp As New DataView(_dataTmp, "MS_PT = '" + _MS_PT + "'", "MS_PT", DataViewRowState.CurrentRows)
        For i As Integer = 0 To _dvPTtmp.ToTable().Rows.Count - 1
            Dim _sl As Double = 0
            Double.TryParse(_dvPTtmp.ToTable().Rows(i)("SL_ALLOCATED").ToString(), _sl)
            _sluongPB = _sluongPB + _sl
        Next
        Return _sluongPB
    End Function

    Private Function TongSoLuongCanPhanBo(ByVal _MS_PT As String) As Double
        Dim _sluongCanPB As Double = 0
        Dim _dvPTtmp As New DataView(_DataAllocatedVTPT, "MS_PT = '" + _MS_PT + "'", "MS_PT", DataViewRowState.CurrentRows)
        For i As Integer = 0 To _dvPTtmp.ToTable().Rows.Count - 1
            Dim _sl As Double = 0
            Double.TryParse(_dvPTtmp.ToTable().Rows(i)("SL_YEU_CAU").ToString(), _sl)
            _sluongCanPB = _sluongCanPB + _sl
        Next

        Return _sluongCanPB
    End Function

    Private Sub PhanBoSL_CAN(ByVal _MS_PT As String, ByVal _soLuong As Double)
        Dim vitriCuoi As Integer = -1
        Dim slgvitriCuoi As Double = 0
        For i As Integer = 0 To grvPTThayThe.RowCount - 1
            If grvPTThayThe.GetDataRow(i)("MS_PT").ToString() = _MS_PT Then
                grvPTThayThe.GetDataRow(i)("SL_ALLOCATED") = 0
                If _soLuong > 0 Then
                    Dim _slkh As Double = 0
                    Double.TryParse(grvPTThayThe.GetDataRow(i)("SL_KH").ToString, _slkh)
                    If _soLuong >= _slkh Then
                        grvPTThayThe.GetDataRow(i)("SL_ALLOCATED") = _slkh
                        _soLuong = _soLuong - _slkh
                        vitriCuoi = i
                        slgvitriCuoi = _slkh
                    Else
                        grvPTThayThe.GetDataRow(i)("SL_ALLOCATED") = _soLuong
                        _soLuong = 0
                        vitriCuoi = i
                        slgvitriCuoi = _soLuong
                    End If
                End If
            End If
        Next

        If _soLuong <> 0 And vitriCuoi >= 0 Then
            grvPTThayThe.GetDataRow(vitriCuoi)("SL_ALLOCATED") = slgvitriCuoi + _soLuong
        End If
    End Sub

    Private Sub PhanBoSL_CAN_PHU_TUNG_TUONG_DUONG(ByVal _MS_PT As String, ByVal _soLuong As Double)
        'clear gia tri cu

        Dim _DTPTTT As New DataTable
        Dim _strSQLPTTT As String = "SELECT MS_PT, MS_PT1" &
                    "FROM(IC_PHU_TUNG_THAY_THE)" &
                    "WHERE MS_PT IN  (SELECT MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI = '" + txtMaSoPBT.Text.Trim + "')" &
                    "AND MS_PT1 = '" + _MS_PT + "'"

        _DTPTTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _strSQLPTTT))

        Dim vitriCuoi As Integer = -1
        Dim slgvitriCuoi As Double = 0
        For i As Integer = 0 To grvPTThayThe.RowCount - 1
            If grvPTThayThe.GetDataRow(i)("MS_PT").ToString() = _MS_PT Then
                grvPTThayThe.GetDataRow(i)("SL_ALLOCATED").Value = 0
                If _soLuong > 0 Then
                    Dim _slkh As Double = 0
                    Double.TryParse(grvPTThayThe.GetDataRow(i)("SL_KH").ToString, _slkh)
                    If _soLuong >= _slkh Then
                        grvPTThayThe.GetDataRow(i)("SL_ALLOCATED") = _slkh
                        _soLuong = _soLuong - _slkh
                        vitriCuoi = i
                        slgvitriCuoi = _slkh
                    Else
                        grvPTThayThe.GetDataRow(i)("SL_ALLOCATED") = _soLuong
                        _soLuong = 0
                        vitriCuoi = i
                        slgvitriCuoi = _soLuong
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub AllocateVTAfterChoose()

        Dim dataview As New DataView(_DataAllocatedVTPT, "VAT_TU = TRUE", "MS_PT", DataViewRowState.CurrentRows)

        DataVTAllocated.Rows.Clear()
        Dim Datatmp As New DataTable()
        Datatmp = dataview.ToTable(True, "MS_PT")
        For i As Integer = 0 To Datatmp.Rows.Count - 1
            Dim _tongSL As Double = 0
            For j As Integer = 0 To dataview.ToTable().Rows.Count - 1
                If dataview.ToTable().Rows(j)("MS_PT").ToString() = Datatmp.Rows(i)("MS_PT").ToString() Then
                    Dim _sl As Double = 0
                    Double.TryParse(dataview.ToTable().Rows(j)("SL_YEU_CAU").ToString(), _sl)
                    _tongSL = _tongSL + _sl
                End If
            Next
            DataVTAllocated.Rows.Add(Datatmp.Rows(i)("MS_PT").ToString(), _tongSL)
        Next

    End Sub

    Private DataGridViewVTAllocate As New DataGridView()
    Private DataVTAllocated As New DataTable()

    Private Sub CreateDataGridViewVTAllocated()
        ' grdVatTuNghienThu.Visible = False
        grdVTNghiemThu.Visible = False


        grdVatTuNT.Controls.Add(DataGridViewVTAllocate)
        DataGridViewVTAllocate.Dock = DockStyle.Fill

        DataVTAllocated = New DataTable()
        DataVTAllocated.Columns.Add("MS_PT", Type.GetType("System.String"))
        DataVTAllocated.Columns.Add("SL_ALLOCATED", Type.GetType("System.Double"))
        DataGridViewVTAllocate.DataSource = DataVTAllocated
        DataGridViewVTAllocate.AllowUserToAddRows = False

        DataGridViewVTAllocate.Columns("MS_PT").HeaderText = ObjLanguages.GetLanguage(ModuleName, Me.Name, "MS_PT", TypeLanguage)
        DataGridViewVTAllocate.Columns("MS_PT").MinimumWidth = 100
        DataGridViewVTAllocate.Columns("MS_PT").ReadOnly = True

        DataGridViewVTAllocate.Columns("SL_ALLOCATED").HeaderText = ObjLanguages.GetLanguage(ModuleName, Me.Name, "SL_ALLOCATED", TypeLanguage)
        DataGridViewVTAllocate.Columns("SL_ALLOCATED").MinimumWidth = 100
        DataGridViewVTAllocate.Columns("SL_ALLOCATED").DefaultCellStyle.Format = ObjSystems.sDinhDangSoLe(iSoLeSL) '"#,###,###,###,##0.#00######"
        DataGridViewVTAllocate.Columns("SL_ALLOCATED").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewVTAllocate.Columns("SL_ALLOCATED").ReadOnly = True

        DataGridViewVTAllocate.Visible = True
    End Sub
    Private Sub XoaSL_Allocated_PT_notin_DTAllocated()
        'Try
        '    For i As Integer = 0 To grdPhuTungThayThe.Rows.Count - 1
        '        Dim _isexist As Boolean = False
        '        For j As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1
        '            If grdPhuTungThayThe.Rows(i).Cells("MS_PT").Value.ToString() = _DataAllocatedVTPT.Rows(j)("MS_PT").ToString() Then
        '                _isexist = True
        '            End If
        '        Next
        '        If _isexist = False Then
        '            grdPhuTungThayThe.Rows(i).Cells("SL_ALLOCATED").Value = 0
        '        End If
        '    Next
        'Catch ex As Exception
        'End Try

        Try
            For i As Integer = 0 To grvPTThayThe.RowCount - 1
                Dim _isexist As Boolean = False
                For j As Integer = 0 To _DataAllocatedVTPT.Rows.Count - 1
                    If grvPTThayThe.GetDataRow(i)("MS_PT").ToString() = _DataAllocatedVTPT.Rows(j)("MS_PT").ToString() Then
                        _isexist = True
                    End If
                Next
                If _isexist = False Then
                    grvPTThayThe.GetDataRow(i)("SL_ALLOCATED") = 0
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AllocatePTAfterChoose()

        Dim dataview As New DataView(_DataAllocatedVTPT, "VAT_TU = FALSE", "MS_PT", DataViewRowState.CurrentRows)
        Dim _dataCV_PT As New DataTable
        '_dataCV_PT = CType(grdPhuTungThayThe.DataSource, DataTable)
        _dataCV_PT = CType(grvPTThayThe.DataSource, DataTable)

        Dim _DSPTPB As New DataTable
        _DSPTPB = dataview.ToTable().DefaultView.ToTable(True, "MS_PT")

        Dim _dtDSPTThayThe As New DataTable
        _dtDSPTThayThe.Columns.Add("MS_PT", Type.GetType("System.String"))
        Dim _dtDSPTTuongDuong As New DataTable
        _dtDSPTTuongDuong.Columns.Add("MS_PT", Type.GetType("System.String"))


        For i As Integer = 0 To _dataCV_PT.Rows.Count - 1
            Dim _isExistsMS_PT As Boolean = False
            For j As Integer = 0 To _DSPTPB.Rows.Count - 1
                If _dataCV_PT.Rows(i)("MS_PT").ToString = _DSPTPB.Rows(j)("MS_PT").ToString Then
                    _isExistsMS_PT = True
                End If
            Next
            If _isExistsMS_PT = True Then
                _dtDSPTThayThe.Rows.Add(_dataCV_PT.Rows(i)("MS_PT").ToString)
            Else
                _dtDSPTTuongDuong.Rows.Add(_dataCV_PT.Rows(i)("MS_PT").ToString)
            End If
        Next

        For i As Integer = 0 To _dtDSPTThayThe.Rows.Count - 1
            Dim _slCanPB As Double = TongSoLuongCanPhanBo(_dtDSPTThayThe.Rows(i)("MS_PT").ToString())
            Dim _sldaPB As Double = TongSoLuongDaPhanBo(_dtDSPTThayThe.Rows(i)("MS_PT").ToString())
            If _slCanPB <> _sldaPB Then
                PhanBoSL_CAN(_dtDSPTThayThe.Rows(i)("MS_PT").ToString(), _slCanPB)
            End If
        Next
    End Sub
    Private Sub LoadDataAllocated()
        _DataAllocatedVTPT = New DataTable()
        _DataAllocatedVTPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_ALLOCATED_FOR_PBT", cboMAY.EditValue().Trim(), txtMaSoPBT.Text.ToString().Trim()))
    End Sub

    Private Sub btnSynDNXK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'SYN'
        If sPrivate = "BARIA" Then
            Try
                Dim FRM As New ReportHuda.frmChonVTRequestPBT()
                FRM.sPBT = txtMaSoPBT.Text
                FRM.sMay = cboMAY.EditValue
                FRM.dNgayYC = Now.Date
                FRM.sCN = sMaNhanVienMD
                FRM.ShowDialog()
            Catch ex As Exception
            End Try

            Exit Sub
        End If
        If isSynData Then
            Try
                Dim _DataSynInfo As New DataTable
                _DataSynInfo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_FOR_DNXK_SYN", txtMaSoPBT.Text.Trim()))
                If _DataSynInfo.Rows.Count > 0 Then
                    Dim frm = New ReportHuda.frmDeNghiVatTuBHS()
                    frm.sMsPBT = txtMaSoPBT.Text
                    frm.dNgayBDKH = dtNgayBDKH1.DateTime

                    If frm.ShowDialog() = DialogResult.Cancel Then Exit Sub
                    Dim sMsKho As String = frm.sMsKho
                    Dim sMsPB As String = frm.sMsPhongBan
                    Dim sTenPB As String = frm.sTenPhongBan
                    Dim sMsLyDoXuatKT As String = frm.sMsLyDoXuat
                    Dim sNoiDung As String = frm.sNoiDung

                    Dim scon As New SqlConnection(_SynConnectionInfo)
                    Try
                        scon.Open()
                    Catch ex As Exception
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgConnectKhongThanhCong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End Try

                    Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
                    Try
                        Dim commanddel As SqlCommand = scon.CreateCommand()
                        commanddel.Connection = scon
                        commanddel.CommandTimeout = 9999
                        commanddel.Transaction = sqlTrans
                        commanddel.CommandType = CommandType.Text
                        commanddel.CommandText = "DELETE  TB_DNXK WHERE MASOYC = '" + txtMaSoPBT.Text.Trim() + "'"
                        commanddel.ExecuteNonQuery()

                        'Them du lieu vao Allocated
                        For i As Integer = 0 To _DataSynInfo.Rows.Count - 1
                            Dim command As SqlCommand = scon.CreateCommand()
                            command.Connection = scon
                            command.CommandTimeout = 9999
                            command.Transaction = sqlTrans
                            command.CommandType = CommandType.StoredProcedure
                            command.CommandText = "INTEGRATION_INSERT_DNXK_FOR_SYN"

                            command.Parameters.Add("@MAKHO", SqlDbType.NVarChar)
                            command.Parameters("@MAKHO").Value = sMsKho     '_DataSynInfo.Rows(i)("MAKHO").ToString()

                            command.Parameters.Add("@MASOYC", SqlDbType.NVarChar)
                            command.Parameters("@MASOYC").Value = _DataSynInfo.Rows(i)("MASOYC").ToString()

                            command.Parameters.Add("@GIOLAP", SqlDbType.DateTime)
                            command.Parameters("@GIOLAP").Value = _DataSynInfo.Rows(i)("GIOLAP").ToString

                            command.Parameters.Add("@NGAYLAP", SqlDbType.DateTime)
                            command.Parameters("@NGAYLAP").Value = _DataSynInfo.Rows(i)("NGAYLAP").ToString()

                            command.Parameters.Add("@MASOPB", SqlDbType.NVarChar)
                            command.Parameters("@MASOPB").Value = sMsPB  '_DataSynInfo.Rows(i)("MASOPB").ToString()

                            command.Parameters.Add("@TENPB", SqlDbType.NVarChar)
                            command.Parameters("@TENPB").Value = sTenPB     '_DataSynInfo.Rows(i)("TENPB").ToString()

                            command.Parameters.Add("@TENNVYC", SqlDbType.NVarChar)
                            command.Parameters("@TENNVYC").Value = _DataSynInfo.Rows(i)("TENNVYC").ToString()

                            command.Parameters.Add("@NOIDUNG", SqlDbType.NVarChar)
                            command.Parameters("@NOIDUNG").Value = sNoiDung '_DataSynInfo.Rows(i)("NOIDUNG").ToString()

                            command.Parameters.Add("@MAVT", SqlDbType.NVarChar)
                            command.Parameters("@MAVT").Value = _DataSynInfo.Rows(i)("MAVT").ToString()

                            command.Parameters.Add("@MAHANGMUC", SqlDbType.NVarChar)
                            command.Parameters("@MAHANGMUC").Value = _DataSynInfo.Rows(i)("MAHANGMUC").ToString()

                            command.Parameters.Add("@MALYDOXUAT", SqlDbType.NVarChar)
                            command.Parameters("@MALYDOXUAT").Value = sMsLyDoXuatKT '_DataSynInfo.Rows(i)("MALYDOXUAT").ToString()

                            command.Parameters.Add("@SOLUONG", SqlDbType.Float)
                            command.Parameters("@SOLUONG").Value = _DataSynInfo.Rows(i)("SOLUONG").ToString()

                            command.Parameters.Add("@INSERT_DATE", SqlDbType.DateTime)
                            command.Parameters("@INSERT_DATE").Value = _DataSynInfo.Rows(i)("INSERT_DATE").ToString

                            command.Parameters.Add("@UserLap", SqlDbType.NVarChar)
                            command.Parameters("@UserLap").Value = UserName

                            command.ExecuteNonQuery()
                        Next


                        sqlTrans.Commit()
                        scon.Close()
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "TAO_DNXK_THANH_CONG", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "TAO_DNXK_KHONG_THANH_CONG", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        sqlTrans.Rollback()
                        scon.Close()
                    End Try
                End If

            Catch ex As Exception
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "CONNECT_TO_DBSYN_UNSUCCESSFUL", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub dtGioLap_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtGioLap.Enter
        If dtGioLap.Enabled = False Then Exit Sub
        dtGioLap.SelectAll()
    End Sub

    Private Sub dtGioLap_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGioLap.MouseDown
        If dtGioLap.Enabled = False Then Exit Sub
        If dtGioLap.Focused Then dtGioLap.SelectAll()
    End Sub

    Private Sub txtGiohong_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGiohong.Enter
        If txtGiohong.Enabled = False Then Exit Sub
        txtGiohong.SelectAll()
    End Sub

    Private Sub txtGiohong_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtGiohong.MouseDown
        If txtGiohong.Enabled = False Then Exit Sub
        If txtGiohong.Focused Then txtGiohong.SelectAll()
    End Sub

    Private Sub txtDenGioHong_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDenGioHong.Enter
        If txtDenGioHong.Enabled = False Then Exit Sub
        txtDenGioHong.SelectAll()
    End Sub

    Private Sub txtDenGioHong_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDenGioHong.MouseDown
        If txtDenGioHong.Enabled = False Then Exit Sub
        If txtDenGioHong.Focused Then txtDenGioHong.SelectAll()
    End Sub




    Private Sub mnuBCCongViecNoiBo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuBCCongViecNoiBo.ItemClick
        InGiaoNhan(1)
    End Sub

    Private Sub mnuBCCongViecDichVu_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuBCCongViecDichVu.ItemClick
        InGiaoNhan(2)
    End Sub


#Region "Nguoi Giam Sat"
    Private Sub LoadNGS(ByVal MSPBT As String, ByVal sMSCN As String)
        Try
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPBTNguoiGiamSatNT", MSPBT))

            dtTmp.PrimaryKey = New DataColumn() {dtTmp.Columns("MS_CONG_NHAN")}
            ObjSystems.MLoadXtraGrid(grdNGSat, grvNGSat, dtTmp, False, False, True, False)

            Dim _table As New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCongNhanPhongBan", -1, -1))

            Dim cboCN As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
            Dim cboHT As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
            cboCN = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            cboCN.NullText = ""
            cboCN.DisplayMember = "MS_CONG_NHAN"
            cboCN.ValueMember = "MS_CONG_NHAN"
            cboCN.DataSource = _table
            cboCN.PopupWidth = 625
            grvNGSat.Columns("MS_CONG_NHAN").ColumnEdit = cboCN

            Try
                RemoveHandler cboCN.EditValueChanged, AddressOf Me.cboCN_EditValueChanged
            Catch ex As Exception
            End Try
            Try
                AddHandler cboCN.EditValueChanged, AddressOf Me.cboCN_EditValueChanged
            Catch ex As Exception
            End Try
            cboHT = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            cboHT.NullText = ""
            cboHT.DisplayMember = "HO_TEN"
            cboHT.ValueMember = "MS_CONG_NHAN"
            cboHT.DataSource = _table
            cboHT.PopupWidth = 625
            grvNGSat.Columns("HO_TEN").ColumnEdit = cboHT
            Try
                RemoveHandler cboHT.EditValueChanged, AddressOf Me.cboHT_EditValueChanged
            Catch ex As Exception
            End Try
            Try
                AddHandler cboHT.EditValueChanged, AddressOf Me.cboHT_EditValueChanged
            Catch ex As Exception
            End Try
            If sMSCN <> -1 Then
                Dim index As Integer
                index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(sMSCN))
                grvNGSat.FocusedRowHandle = grvNGSat.GetRowHandle(index)
            End If
            grvNGSat.Columns("TEN_TO").OptionsColumn.ReadOnly = True
            grvNGSat.Columns("USERNAME").OptionsColumn.ReadOnly = True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub cboCN_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Not btnGhiNGS.Visible Then Exit Sub
            SQLString = "00Load"
            Dim cbo As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(cbo.Properties.GetDataSourceRowByKeyValue(cbo.EditValue), DataRowView)
            grvNGSat.SetFocusedRowCellValue("HO_TEN", cbo.EditValue)
            grvNGSat.SetFocusedRowCellValue("TEN_TO", row("TEN_TO").ToString())
            SQLString = ""
        Catch
        End Try

    End Sub

    Private Sub cboHT_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Not btnGhiNGS.Visible Then Exit Sub
            SQLString = "00Load"
            Dim cbo As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
            grvNGSat.SetFocusedRowCellValue("MS_CONG_NHAN", cbo.EditValue)
            Dim row As DataRowView = CType(cbo.Properties.GetDataSourceRowByKeyValue(cbo.EditValue), DataRowView)
            grvNGSat.SetFocusedRowCellValue("TEN_TO", row("TEN_TO").ToString())
            SQLString = ""
        Catch
        End Try
    End Sub

    Private Sub ThemSuaNGS(ByVal ThemSua As Boolean)
        btnThemSuaNGS.Visible = Not ThemSua
        btnXoaNGS.Visible = Not ThemSua
        btnThoatNGS.Visible = Not ThemSua
        btnGhiNGS.Visible = ThemSua
        btnKhongGhiNGS.Visible = ThemSua
        btnChonYCSD.Visible = ThemSua
        If ThemSua Then
            grvNGSat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            grvNGSat.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        Else
            grvNGSat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            grvNGSat.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        End If

        grvNGSat.OptionsBehavior.Editable = ThemSua
    End Sub

    Private Sub btnGhiNGS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhiNGS.Click
        ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "NGS" + UserName, CType(grdNGSat.DataSource, DataTable), "")
        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()

        Try
            SqlHelper.ExecuteNonQuery(sqlTrans, "INSPBTNguoiGiamSatNT", txtMaSoPBT.Text, "NGS" + UserName)
            sqlTrans.Commit()
        Catch ex As Exception
            sqlTrans.Rollback()

            XtraMessageBox.Show(ex.Message)
        End Try

        scon.Close()
        ObjSystems.XoaTable("NGS" + UserName)

        ThemSuaNGS(False)
        Try
            LoadNGS(txtMaSoPBT.Text, grvNGSat.GetFocusedDataRow("MS_CONG_NHAN"))
        Catch ex As Exception
            LoadNGS(txtMaSoPBT.Text, "-1")
        End Try

    End Sub

    Private Sub btnKhongGhiNGS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhiNGS.Click
        ThemSuaNGS(False)
        Try
            LoadNGS(txtMaSoPBT.Text, grvNGSat.GetFocusedDataRow("MS_CONG_NHAN"))
        Catch ex As Exception
            LoadNGS(txtMaSoPBT.Text, "-1")
        End Try

    End Sub

    Private Sub btnThemSuaNGS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemSuaNGS.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        ThemSuaNGS(True)
    End Sub

    Private Sub btnXoaNGS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaNGS.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If grvNGSat.RowCount <= 0 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgKhongCoDuLieuDeXoa", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim iTL As Integer
        Try

            iTL = XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBanMuonXoa1CongNhan(Y)HayXoaHetCongNhan(N)HayKhongXoa(C)", TypeLanguage),
                    Me.Name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If iTL = vbCancel Then Exit Sub
            If iTL = vbYes Then XoaNguoiGiamSat(txtMaSoPBT.Text, grvNGSat.GetFocusedDataRow("MS_CONG_NHAN"))
            If iTL = vbNo Then XoaNguoiGiamSat(txtMaSoPBT.Text, "-1")
            LoadNGS(txtMaSoPBT.Text, "-1")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnThoatNGS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatNGS.Click
        Me.Close()
    End Sub

    Private Sub grvNGSat_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvNGSat.CellValueChanged
        If btnThem_1.Visible Then Exit Sub
        If SQLString = "00Load" Then Exit Sub
        Try
            If Convert.ToBoolean(grvNGSat.GetFocusedDataRow("APPROVE")) Then
                SQLString = "00Load"
                grvNGSat.SetFocusedRowCellValue("USERNAME", UserName)

            Else
                SQLString = "00Load"
                grvNGSat.SetFocusedRowCellValue("USERNAME", String.Empty)
            End If
            SQLString = ""
        Catch ex As Exception

        End Try


    End Sub

    Private Sub grvNGSat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvNGSat.KeyDown
        If e.KeyCode <> Keys.Delete Then Exit Sub
        If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgCoChacXoaCongNhanNay", TypeLanguage), Me.Name, MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub
        If btnGhiNGS.Visible = False Then
            XoaNguoiGiamSat(txtMaSoPBT.Text, grvNGSat.GetFocusedDataRow("MS_CONG_NHAN"))
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.DeleteRow(view.FocusedRowHandle)

    End Sub

    Private Sub XoaNguoiGiamSat(ByVal MSPBT As String, ByVal MSCN As String)
        Dim sSql As String
        sSql = "DELETE FROM PHIEU_BAO_TRI_GIAM_SAT_NGHIEM_THU WHERE (MS_PHIEU_BAO_TRI = N'" + MSPBT + "') " &
                    " AND ('-1' = '" + MSCN + "' OR MS_CONG_NHAN = '" + MSCN + "' )"
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub btnUnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnLock.Click
        If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBanCoMuonBoLockPhieuBaoTri", TypeLanguage), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim sSql As String = " UPDATE PHIEU_BAO_TRI SET TINH_TRANG_PBT = 4 WHERE MS_PHIEU_BAO_TRI = N'" + txtMaSoPBT.Text + "'  "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            CapNhapPBTCT(4)
            Dim i As Integer = grvDanhSach_1.FocusedRowHandle
            optNTHT_SelectedIndexChanged(sender, e)
            Try
                grvDanhSach_1.FocusedRowHandle = i
            Catch ex As Exception

            End Try

            Me.Cursor = Cursors.Default
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgUnlockThanhCong", TypeLanguage))

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgUnlockKhongThanhCong", TypeLanguage))
        End Try

    End Sub

    Private Sub btnIn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
        frmRpt.rptName = "rptPhieuBaoTriDichVu"
        Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
        connection.Open()
        Dim command As New System.Data.SqlClient.SqlCommand()
        command.Connection = connection
        command.CommandText = "GetBCPBTDichVu"
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add(New SqlParameter("@MsPhieuBT", txtMaSoPBT.Text))


        Dim adapter As New SqlDataAdapter(command)
        Dim dsTmp As New DataSet()
        Try
            adapter.Fill(dsTmp)
        Catch ex As Exception

        End Try
        Dim dtTMP = New DataTable
        For i As Integer = 0 To dsTmp.Tables.Count - 1
            dtTMP = New DataTable
            dtTMP = dsTmp.Tables(i)
            Select Case i
                Case 0
                    dtTMP.TableName = "PBT_DV_INFO"
                Case 1
                    dtTMP.TableName = "PBT_CV"
                Case 2
                    dtTMP.TableName = "PBT_VTPT"
                Case 3
                    dtTMP.TableName = "PBT_PH"
            End Select
            frmRpt.AddDataTableSource(dsTmp.Tables(i))
        Next
        frmRpt.AddDataTableSource(NNguPBTDV(dsTmp.Tables(0)))
        frmRpt.ShowDialog()

    End Sub

    Function NNguPBTDV(ByVal dtInfo As DataTable) As DataTable
        Try

            Dim dtNN As New DataTable()
            dtNN.TableName = "TIEU_DE_PBT_DV"
            For i As Integer = 0 To 30
                dtNN.Columns.Add()
            Next
            dtNN.Columns(0).ColumnName = "TIEU_DE_PBT_DV"
            dtNN.Columns(1).ColumnName = "SO_PHIEU"
            dtNN.Columns(2).ColumnName = "NGUOI_DE_NGHI"
            dtNN.Columns(3).ColumnName = "BO_PHAN"
            dtNN.Columns(4).ColumnName = "KHO_XUAT"
            dtNN.Columns(5).ColumnName = "DV_SUA_CHUA"
            dtNN.Columns(6).ColumnName = "DANG_XUAT"
            dtNN.Columns(7).ColumnName = "LY_DO_XUAT"
            dtNN.Columns(8).ColumnName = "BB_CHIU_PHI"
            dtNN.Columns(9).ColumnName = "THOI_GIAN"
            dtNN.Columns(10).ColumnName = "TG_DU_KIEN"
            dtNN.Columns(11).ColumnName = "THONG_TIN_TB"
            dtNN.Columns(13).ColumnName = "STT"
            dtNN.Columns(14).ColumnName = "TEN_TB"
            dtNN.Columns(15).ColumnName = "S_LUONG"
            dtNN.Columns(16).ColumnName = "CONG_VIEC"
            dtNN.Columns(17).ColumnName = "GHI_CHU"
            dtNN.Columns(18).ColumnName = "N_DE_NGHI"
            dtNN.Columns(19).ColumnName = "BAO_VE"
            dtNN.Columns(20).ColumnName = "DUYET"
            dtNN.Columns(21).ColumnName = "TMP1"
            dtNN.Columns(22).ColumnName = "TMP2"
            dtNN.Columns(23).ColumnName = "TMP3"
            dtNN.Columns(24).ColumnName = "TMP4"
            dtNN.Columns(25).ColumnName = "TMP5"
            dtNN.Columns(26).ColumnName = "TMP6"
            dtNN.Columns(27).ColumnName = "TMP7"
            dtNN.Columns(28).ColumnName = "TMP8"
            dtNN.Columns(29).ColumnName = "TMP9"

            Dim vRowTitle As DataRow = dtNN.NewRow()
            vRowTitle("TIEU_DE_PBT_DV") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TIEU_DE_PBT_DV", TypeLanguage)
            vRowTitle("SO_PHIEU") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "SO_PHIEU", TypeLanguage) & " : " & dtInfo.Rows(0)("MS_PHIEU_BAO_TRI").ToString
            vRowTitle("NGUOI_DE_NGHI") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "NGUOI_DE_NGHI", TypeLanguage) & " : " & dtInfo.Rows(0)("HT_NLAP").ToString
            vRowTitle("BO_PHAN") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "BO_PHAN", TypeLanguage) & " : " & dtInfo.Rows(0)("TEN_TO").ToString
            vRowTitle("KHO_XUAT") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "KHO_XUAT", TypeLanguage)
            vRowTitle("DV_SUA_CHUA") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "DV_SUA_CHUA", TypeLanguage) & " : " & dtInfo.Rows(0)("CTY").ToString
            vRowTitle("DANG_XUAT") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "DANG_XUAT", TypeLanguage)
            vRowTitle("LY_DO_XUAT") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "LY_DO_XUAT", TypeLanguage) & " : " & dtInfo.Rows(0)("LY_DO_BT").ToString
            vRowTitle("BB_CHIU_PHI") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "BB_CHIU_PHI", TypeLanguage) & " : " & dtInfo.Rows(0)("TEN_BP_CHIU_PHI").ToString
            vRowTitle("THOI_GIAN") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "THOI_GIAN", TypeLanguage) & " : " & dtInfo.Rows(0)("NGAY_BD_KH").ToString
            vRowTitle("TG_DU_KIEN") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TG_DU_KIEN", TypeLanguage)
            vRowTitle("THONG_TIN_TB") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "THONG_TIN_TB", TypeLanguage)
            vRowTitle("STT") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "STT", TypeLanguage)
            vRowTitle("TEN_TB") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TEN_TB", TypeLanguage)
            vRowTitle("S_LUONG") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "S_LUONG", TypeLanguage)
            vRowTitle("CONG_VIEC") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "CONG_VIEC", TypeLanguage)
            vRowTitle("GHI_CHU") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "GHI_CHU", TypeLanguage)
            vRowTitle("N_DE_NGHI") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "N_DE_NGHI", TypeLanguage)
            vRowTitle("BAO_VE") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "BAO_VE", TypeLanguage)
            vRowTitle("DUYET") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "DUYET", TypeLanguage)
            vRowTitle("TMP1") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP1", TypeLanguage)
            vRowTitle("TMP2") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP2", TypeLanguage)
            vRowTitle("TMP3") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP3", TypeLanguage)
            vRowTitle("TMP4") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP4", TypeLanguage)
            vRowTitle("TMP5") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP5", TypeLanguage)
            vRowTitle("TMP6") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP6", TypeLanguage)
            vRowTitle("TMP7") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP7", TypeLanguage)
            vRowTitle("TMP8") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP8", TypeLanguage)
            vRowTitle("TMP9") = ObjLanguages.GetLanguage(ModuleName, "rptPhieuBaoTriDichVu", "TMP9", TypeLanguage)
            dtNN.Rows.Add(vRowTitle)
            Return dtNN
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub btnXoaPBTK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaPBTK.Click
        Dim str As String = ""
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub

        If cboTinhTrangPBT.SelectedValue = 4 Then Exit Sub
        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBanCoMuonXoaPhieuBaoTriKho", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
            objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 3)
            CapNhapPBTCT(3)
            cboTinhTrangPBT.SelectedValue = 3
            str = "DELETE FROM  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Else
            Exit Sub
        End If
        BindDataPTThayThe()
    End Sub

#Region "Tinh Trang truoc sau Bao tri"
    Private Sub LoadTTBT(ByVal MSPBT As String)
        Try
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPBTTinhTrangTruocSau", MSPBT))

            ObjSystems.MLoadXtraGrid(grdTTBT, grvTTBT, dtTmp, False, False, True, False)

            Dim _table As New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select MS_DV_DO, TEN_DV_DO FROM DON_VI_DO ORDER BY TEN_DV_DO "))




            Dim cboTTBT As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
            cboTTBT = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            cboTTBT.NullText = ""
            cboTTBT.ValueMember = "MS_DV_DO"
            cboTTBT.DisplayMember = "TEN_DV_DO"
            cboTTBT.DataSource = _table
            cboTTBT.PopupWidth = 625
            grvTTBT.Columns("MS_DV_DO").ColumnEdit = cboTTBT

            grvTTBT.Columns("ID").Visible = False
            grvTTBT.Columns("MS_PHIEU_BAO_TRI").Visible = False

            grvTTBT.Columns("USER_XN").OptionsColumn.ReadOnly = True

            Try
                RemoveHandler cboTTBT.EditValueChanged, AddressOf Me.cboTTBT_EditValueChanged
            Catch ex As Exception
            End Try
            Try
                AddHandler cboTTBT.EditValueChanged, AddressOf Me.cboTTBT_EditValueChanged
            Catch ex As Exception
            End Try

            'grvTTBT.Columns("TEN_TO").OptionsColumn.ReadOnly = True
            'grvTTBT.Columns("USERNAME").OptionsColumn.ReadOnly = True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub cboTTBT_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Not btnGhiTTBT.Visible Then Exit Sub
            SQLString = "00Load"
            Dim cbo As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(cbo.Properties.GetDataSourceRowByKeyValue(cbo.EditValue), DataRowView)
            'grvTTBT.SetFocusedRowCellValue("HO_TEN", cbo.EditValue)
            'grvTTBT.SetFocusedRowCellValue("TEN_TO", row("TEN_TO").ToString())
            SQLString = ""
        Catch
        End Try

    End Sub

    Private Sub ThemSuaTTBT(ByVal ThemSua As Boolean)
        btnThemSuaTTBT.Visible = Not ThemSua
        btnXoaTTBT.Visible = Not ThemSua
        btnThoatTTBT.Visible = Not ThemSua
        btnGhiTTBT.Visible = ThemSua
        btnKhongGhiTTBT.Visible = ThemSua
        btnChonYCSD.Visible = ThemSua
        If ThemSua Then
            grvTTBT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            grvTTBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        Else
            grvTTBT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            grvTTBT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        End If

        grvTTBT.OptionsBehavior.Editable = ThemSua
    End Sub

    Private Sub btnGhiTTBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhiTTBT.Click
        ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "TTBT" + UserName, CType(grdTTBT.DataSource, DataTable), "")

        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()

        Try
            SqlHelper.ExecuteNonQuery(sqlTrans, "INSPBTTinhTrang", txtMaSoPBT.Text, "TTBT" + UserName)
            sqlTrans.Commit()
        Catch ex As Exception
            sqlTrans.Rollback()

            XtraMessageBox.Show(ex.Message)
        End Try

        scon.Close()
        ObjSystems.XoaTable("TTBT" + UserName)

        ThemSuaTTBT(False)
        Try
            LoadTTBT(txtMaSoPBT.Text)
        Catch ex As Exception
            LoadTTBT("-1")
        End Try

    End Sub

    Private Sub btnKhongGhiTTBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhiTTBT.Click
        ThemSuaTTBT(False)
        Try
            LoadTTBT(txtMaSoPBT.Text)
        Catch ex As Exception
            LoadTTBT("-1")
        End Try

    End Sub


    Private Sub btnThemSuaTTBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemSuaTTBT.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        ThemSuaTTBT(True)
    End Sub

    Private Sub btnXoaTTBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaTTBT.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If grvTTBT.RowCount <= 0 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgKhongCoDuLieuDeXoa", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim iTL As Integer
        Try
            iTL = XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBanMuonXoa1TT(Y)HayXoaHetTT(N)HayKhongXoa(C)", TypeLanguage), Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If iTL = vbCancel Then Exit Sub
            If iTL = vbYes Then XoaTTPBT(txtMaSoPBT.Text, grvTTBT.GetFocusedDataRow("ID"))
            If iTL = vbNo Then XoaTTPBT(txtMaSoPBT.Text, "-1")
            LoadTTBT(txtMaSoPBT.Text)
        Catch ex As Exception

        End Try

    End Sub



    Private Sub grvTTBT_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvTTBT.CellValueChanged
        If btnThemSuaTTBT.Visible Then Exit Sub
        If SQLString = "00Load" Then Exit Sub
        Try
            SQLString = "00Load"
            grvTTBT.SetFocusedRowCellValue("MS_PHIEU_BAO_TRI", txtMaSoPBT.Text)
            If grvTTBT.GetFocusedDataRow("ID").ToString = "" Then
                grvTTBT.SetFocusedRowCellValue("ID", -1)
            End If

            If grvTTBT.GetFocusedDataRow("XAC_NHAN").ToString = "True" Then
                grvTTBT.SetFocusedRowCellValue("USER_XN", UserName)
            Else
                grvTTBT.SetFocusedRowCellValue("USER_XN", "")
            End If

            SQLString = ""
        Catch ex As Exception

        End Try


    End Sub

    Private Sub grvTTBT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvTTBT.KeyDown
        If e.KeyCode <> Keys.Delete Then Exit Sub
        If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgCoChacXoaDongTTPBTNay", TypeLanguage), Me.Name, MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub
        If btnGhiTTBT.Visible = False Then
            XoaTTPBT(txtMaSoPBT.Text, grvTTBT.GetFocusedDataRow("ID"))
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.DeleteRow(view.FocusedRowHandle)

    End Sub

    Private Sub XoaTTPBT(ByVal MSPBT As String, ByVal MSCN As String)
        Dim sSql As String
        sSql = "DELETE FROM PHIEU_BAO_TRI_TINH_TRANG WHERE (MS_PHIEU_BAO_TRI = N'" + MSPBT + "') " &
                    " AND ('-1' = '" + MSCN + "' OR ID = " + MSCN + " )"
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub btnPhanBoLai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPhanBoLai.Click
        If txtMaSoPBT.Text = "" Then Exit Sub
        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
            "msgBanCoMuonPhanBoLai", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then Exit Sub
        Dim Cnn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
        If Cnn.State = ConnectionState.Closed Then Cnn.Open()
        Dim Tran As SqlClient.SqlTransaction = Cnn.BeginTransaction()

        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spPhanBoLaiBaria", txtMaSoPBT.Text)
            Tran.Commit()
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                    "msgPhanBoLaiThanhCong", TypeLanguage), Me.Text)
        Catch ex As Exception
            Tran.Rollback()
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                    "msgPhanBoLaiKhongThanhCong", TypeLanguage), Me.Text)
        End Try

        BindData5()


    End Sub

    Private Sub btnTraKho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim frmBR As New ReportHuda.frmChonVTINTPBT
        frmBR.sPBT = txtMaSoPBT.Text
        frmBR.sMay = cboMAY.EditValue
        frmBR.iLoaiForm = 1
        frmBR.ShowDialog()

    End Sub

    Private Sub btnCNhapGKH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If cboMAY.EditValue = "" Then Exit Sub
        If txtMaSoPBT.Text = "" Then Exit Sub

        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBanMuonCapNhapLaiSoGioKeHoach", TypeLanguage),
                Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then Exit Sub
        Dim sSql As String
        Try
            sSql = " UPDATE CAU_TRUC_THIET_BI_CONG_VIEC SET TG_KH = TGIO FROM CAU_TRUC_THIET_BI_CONG_VIEC T1 INNER JOIN " &
                        " (SELECT MS_BO_PHAN,MS_CV, N'" & cboMAY.EditValue & "' AS MS_MAY , SUM(SO_GIO) AS TGIO FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET  " &
                        " WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "'GROUP BY MS_BO_PHAN,MS_CV) T2 ON T1.MS_MAY = T2.MS_MAY  " &
                        " AND T1.MS_BO_PHAN = T2.MS_BO_PHAN AND T1.MS_CV = T2.MS_CV "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grvDanhSach_1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDanhSach_1.FocusedRowChanged
        If btnGhi_1.Visible = True Then Exit Sub
        intRowPBT = e.FocusedRowHandle
        LoadcmbCNPBT()
        ShowData()
        BindDataHinh()



        If grvDanhSach_1.RowCount = 0 Then
            TinhtrangPBT_Lock(False)
            BtnDuyetPBT.Enabled = False
            BtnKhoaPBT.Enabled = False
            btnAuto.Enabled = False
            btnThem_1.Enabled = True
            btnNHHTNTL.Enabled = True
        Else
            If cboTinhTrangPBT.SelectedValue = 5 Then
                TinhtrangPBT_Lock(False)
            Else
                TinhtrangPBT_Lock(True)
                If cboTinhTrangPBT.SelectedValue = 3 Or cboTinhTrangPBT.SelectedValue = 2 Or cboTinhTrangPBT.SelectedValue = 4 Then
                    BtnDuyetPBT.Enabled = False
                End If
                BtnKhoaPBT.Enabled = True
                If cboTinhTrangPBT.SelectedValue = 3 Or cboTinhTrangPBT.SelectedValue = 2 Then
                    BtnKhoaPBT.Enabled = False
                End If
            End If
        End If
        If sPrivate = "BARIA" And cboTinhTrangPBT.SelectedValue = 1 Then btnIn_1.Enabled = False Else btnIn_1.Enabled = True
        If PermisString.Equals("Read only") Then TinhtrangPBT_Lock(False)
    End Sub

    Private Sub TaoLuoiCmbPBTCT()
        Dim sSql As String = ""
        Try
            sSql = "SELECT DISTINCT MA_SO,CASE " & TypeLanguage.ToString & " WHEN 0 THEN  TEN_TIENG_VIET WHEN 1 THEN TEN_TIENG_ANH ELSE " &
                            " TEN_TIENG_HOA END AS TEN_CT, STT, MS_TT_CT FROM dbo.TINH_TRANG_PBT_CT AS T1 ORDER BY STT, TEN_CT"
            ObjSystems.MLoadLookUpEditNoRemove(cboPBTTTrang, sSql, "MS_TT_CT", "TEN_CT", Me.Name)
        Catch ex As Exception

        End Try

        cboPBTTTrang.Properties.Columns("STT").Visible = False
        cboPBTTTrang.Properties.Columns("MS_TT_CT").Visible = False


        Try
            dtTinhTrangPBTCT = New DataTable()
            menuTinhTrangPBTCT.Visible = True
            menuTinhTrangPBTCT.Items.Clear()
            dtTinhTrangPBTCT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            For Each row As DataRow In dtTinhTrangPBTCT.Rows
                Dim item As ToolStripMenuItem = New ToolStripMenuItem
                item.Text = row("TEN_CT").ToString()
                menuTinhTrangPBTCT.Items.Add(item)
                AddHandler item.Click, AddressOf myEventHandler
            Next
        Catch
        End Try

    End Sub
    Private Sub TaoLuoiPBTCT(iSTT As Integer)
        Dim sSql As String
        Dim dtTable As New DataTable
        Try
            sSql = "SELECT     T1.STT, CASE " & TypeLanguage.ToString & " WHEN 0 THEN T2.TEN_TIENG_VIET WHEN 1 THEN T2.TEN_TIENG_ANH ELSE T2.TEN_TIENG_HOA END AS TEN_TIENG_VIET, " &
                        " T1.THOI_GIAN, T1.GHI_CHU, T1.USERNAME, T1.MS_TT_CT FROM dbo.PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET As T1 INNER JOIN " &
                        "                       dbo.TINH_TRANG_PBT_CT AS T2 ON T1.MS_TT_CT = T2.MS_TT_CT " &
                        " WHERE     (T1.MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "')  " &
                        " ORDER BY  T1.THOI_GIAN DESC "
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))



        Catch ex As Exception
            sSql = "SELECT     T1.STT, CASE " & TypeLanguage.ToString & " WHEN 0 THEN T2.TEN_TIENG_VIET WHEN 1 THEN T2.TEN_TIENG_ANH ELSE T2.TEN_TIENG_HOA END AS TEN_TIENG_VIET, " &
                        " T1.THOI_GIAN, T1.GHI_CHU, T1.USERNAME, T1.MS_TT_CT FROM dbo.PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET As T1 INNER JOIN " &
                        "                       dbo.TINH_TRANG_PBT_CT AS T2 ON T1.MS_TT_CT = T2.MS_TT_CT " &
                        " WHERE     (T1.MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "') " &
                        " ORDER BY T1.THOI_GIAN DESC "
            dtTable = New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        End Try
        Dim vKey(1) As DataColumn
        vKey(0) = dtTable.Columns("STT")
        dtTable.PrimaryKey = vKey

        If grvTTPBT.Columns.Count = 0 Then
            ObjSystems.MLoadXtraGrid(grdTTPBT, grvTTPBT, dtTable, False, True, True, True, True, Me.Name)
            grvTTPBT.Columns("STT").Visible = False
            grvTTPBT.Columns("MS_TT_CT").Visible = False

            grvTTPBT.Columns("THOI_GIAN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            grvTTPBT.Columns("THOI_GIAN").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Else
            ObjSystems.MLoadXtraGrid(grdTTPBT, grvTTPBT, dtTable, False, False, True, False)
        End If

        If iSTT <> -1 Then
            Dim index As Integer
            index = dtTable.Rows.IndexOf(dtTable.Rows.Find(iSTT))
            grvTTPBT.FocusedRowHandle = grvTTPBT.GetRowHandle(index)
        End If

        LoadTextPBTTT()
    End Sub

    Private Sub LoadTextPBTTT()
        Try
            txtGhiChuPBTTT.Text = grvTTPBT.GetFocusedDataRow()("GHI_CHU")
            txtSTTPBTTT.Text = grvTTPBT.GetFocusedDataRow()("STT")
            cboPBTTTrang.EditValue = grvTTPBT.GetFocusedDataRow()("MS_TT_CT")
            dtNgay.DateTime = grvTTPBT.GetFocusedDataRow()("THOI_GIAN")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnThemPBTTT_Click(sender As Object, e As EventArgs) Handles btnThemPBTTT.Click
        LoadNutPBTTT(False)
        txtGhiChuPBTTT.Text = ""
        dtNgay.DateTime = Now
    End Sub

    Private Sub btnSuaPBTTT_Click(sender As Object, e As EventArgs)
        LoadNutPBTTT(False)
    End Sub

    Private Sub btnThoatPBTTT_Click(sender As Object, e As EventArgs) Handles btnThoatPBTTT.Click
        Me.Close()
    End Sub
    Dim dtTinhTrangPBTCT As DataTable
    Dim menuClick As Boolean = False
    Sub myEventHandler(sender As Object, e As System.EventArgs)
        menuClick = True
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim MS_PHIEU_BAO_TRI As String = grvDanhSach_1.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString()
        Dim TINH_TRANG_PBTCT_OLD As String = grvDanhSach_1.GetFocusedDataRow()("TEN_TIENG_VIET").ToString()
        Dim FocusedRow As DataRow = grvDanhSach_1.GetFocusedDataRow()
        Dim note As String = ""
        InputBoxTTPBT("", ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNhapNoteTTPBTCT", TypeLanguage), note)

        For Each row As DataRow In dtTinhTrangPBTCT.Rows
            If (row("TEN_CT").ToString() = item.Text) Then
                Dim index As Integer = dtPBT.Rows.IndexOf(FocusedRow)
                dtPBT.Columns("TEN_TIENG_VIET").ReadOnly = False
                dtPBT.Columns("LY_DO_TT_PBT_CT").ReadOnly = False
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spPBTTinhTrangChiTiet", MS_PHIEU_BAO_TRI, Convert.ToInt32(row("MS_TT_CT").ToString()), note, UserName, Now)
                Catch
                End Try
                If (KiemGhiPBTTT(Convert.ToInt32(grvDanhSach_1.GetFocusedDataRow()("TINH_TRANG_PBT")), Convert.ToInt32(row("STT").ToString())) = False) Then
                    Try


                        dtPBT.Rows(index)("TEN_TIENG_VIET") = If(tinhTrangPBT_Tmp = "", TINH_TRANG_PBTCT_OLD, tinhTrangPBT_Tmp)
                        dtPBT.Rows(index)("LY_DO_TT_PBT_CT") = note
                        tinhTrangPBT_Tmp = ""
                        dtPBT.AcceptChanges()
                    Catch
                        tinhTrangPBT_Tmp = ""
                    End Try
                    Exit Sub
                End If


                Try

                    dtPBT.Rows(index)("TEN_TIENG_VIET") = item.Text
                    dtPBT.Rows(index)("LY_DO_TT_PBT_CT") = note
                    ' dr("LY_DO_TT_PBT_CT") = note
                    dtPBT.AcceptChanges()
                Catch ex As Exception
                End Try
                If (flag = True) Then
                    If optNTHT.SelectedIndex = 1 Then
                        optNTHT.SelectedIndex = 0
                    End If
                    If optNTHT.SelectedIndex = 2 Then
                        optNTHT.SelectedIndex = 1
                    End If
                    For i As Integer = 0 To grvDanhSach_1.RowCount - 1
                        If grvDanhSach_1.GetRowCellValue(i, "MS_PHIEU_BAO_TRI") = MS_PHIEU_BAO_TRI Then
                            grvDanhSach_1.FocusedRowHandle = i
                            intRowPBT = i
                            grvDanhSach_1.SetFocusedRowCellValue("LY_DO_TT_PBT_CT", note)
                            ShowData()
                            Exit For
                        End If
                    Next
                End If

                flag = False
                Exit Sub
            End If

        Next
        menuClick = False
    End Sub
    Dim tinhTrangPBT_Tmp As String = ""
    Private Sub btnThemTTPBT_Click(sender As Object, e As EventArgs) Handles btnThemTTPBT.Click
        Try
            Dim frm As ReportMain.frmTinhTrangPBTCT = New ReportMain.frmTinhTrangPBTCT()
            frm.ShowDialog()
            If ReportMain.frmTinhTrangPBTCT.close = True Then
                Try
                    Dim sSql As String = "SELECT DISTINCT MA_SO,CASE " & TypeLanguage.ToString & " WHEN 0 THEN  TEN_TIENG_VIET WHEN 1 THEN TEN_TIENG_ANH ELSE " &
                                    " TEN_TIENG_HOA END AS TEN_CT, STT, MS_TT_CT FROM dbo.TINH_TRANG_PBT_CT AS T1 ORDER BY STT"
                    ObjSystems.MLoadLookUpEditNoRemove(cboPBTTTrang, sSql, "MS_TT_CT", "TEN_CT", Me.Name)
                Catch ex As Exception

                End Try

                cboPBTTTrang.Properties.Columns("STT").Visible = False
                cboPBTTTrang.Properties.Columns("MS_TT_CT").Visible = False

            End If


        Catch
        End Try
    End Sub

    Private Sub btnXoaPBTTT_Click(sender As Object, e As EventArgs) Handles btnXoaPBTTT.Click
        If txtMaSoPBT.Text = "" Then Exit Sub
        If UserName.ToUpper <> grvTTPBT.GetFocusedDataRow()("USERNAME").ToString.ToUpper Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgUserXoaKhongPhaiUserTao", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim sSql As String
        Dim dNgayMax As DateTime = Now
        sSql = "SELECT MAX(THOI_GIAN) FROM PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "' "
        Try
            dNgayMax = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception
        End Try
        If dtNgay.DateTime.ToString("dd/MM/yyyy HH:mm:ss") <> dNgayMax.ToString("dd/MM/yyyy HH:mm:ss") Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgPhaiChonTinhTrangPBTCuoiDeXoa", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If grvTTPBT.RowCount = 1 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgKhongTheXoaTinhTrang", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                        "msgBanCoChacXoaTinhTrangPBTNay", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then Exit Sub
        Try


            Dim iMS_TT_CT As Integer = 1
            'Lay trang thai phieu bao tri truoc
            sSql = "SELECT TOP 1 T2.STT, T1.MS_TT_CT   FROM PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET T1 INNER JOIN TINH_TRANG_PBT_CT T2 ON T1.MS_TT_CT = T2.MS_TT_CT  WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' " &
                            " AND CONVERT(DATETIME,CONVERT(NVARCHAR(10),THOI_GIAN,101) + ' ' + CONVERT(NVARCHAR(10),THOI_GIAN,108))  <> '" & dNgayMax.ToString("MM/dd/yyyy HH:mm:ss") & "' ORDER BY THOI_GIAN DESC"

            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            While objReader.Read
                If objReader.Item("STT").ToString <> "" Then
                    iMS_TT_CT = objReader.Item("STT")
                End If
            End While
            ''iSTT Trang thai PBT gan nhat
            ''iMS_TT_CT  trang thai chuyen iMS_TT_CT    =         Integer.Parse(cboPBTTTrang.GetColumnValue("STT").ToString())
            If KiemGhiPBTTT(Integer.Parse(cboPBTTTrang.GetColumnValue("STT").ToString()), iMS_TT_CT) = False Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgXoaKhongThanhCong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            Try
                sSql = "DELETE FROM PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET WHERE MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "' AND STT = " & grvTTPBT.GetFocusedDataRow()("STT").ToString
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Catch ex As Exception
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgXoaKhongThanhCong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgXoaKhongThanhCong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        TaoLuoiPBTCT(-1)
    End Sub



    Private Sub btnThoatTTBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoatTTBT.Click
        Me.Close()
    End Sub

    Private Function KiemGhiPBTTT(iSTT As Integer, iMS_TT_CT As Integer) As Boolean
        'iSTT trang thai PBT gan nhat
        'iMS_TT_CT  trang thai chuyen iMS_TT_CT             Integer.Parse(cboPBTTTrang.GetColumnValue("STT").ToString())
        If iSTT = 1 Then
            Select Case iMS_TT_CT
                Case 2
                    If Not DuyetPBT() Then Return False
                Case 3
                    If Not HoanThanhPBT() Then Return False
                Case 4
                    If Not NghiemThuPBT() Then Return False
                Case 5
                    If Not KhoaPBT() Then Return False
            End Select
        End If

        If iSTT = 2 Then
            Select Case iMS_TT_CT
                Case 1
                    Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                    objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 1)
                    If TypeLanguage = 0 Then
                        grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Đang soạn ")
                    Else
                        grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Planned")
                    End If
                    grvDanhSach_1.SetFocusedRowCellValue("TINH_TRANG_PBT", 1) 'dgrDanhSach_1.CurrentucCongViecPBT.grvCongViec.GetDataRow(i).Item("TINH_TRANG_PBT").Value = 1
                    BtnDuyetPBT.Enabled = True
                    cboTinhTrangPBT.SelectedValue = 1

                Case 3
                    If Not HoanThanhPBT() Then Return False
                Case 4
                    If Not NghiemThuPBT() Then Return False
                Case 5
                    If Not KhoaPBT() Then Return False

            End Select
        End If

        If iSTT = 3 Then
            Select Case iMS_TT_CT
                Case 1
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "DaHoanThanhMuonChinhSua", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
                        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                        objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 1)
                        Dim sPBT As String = txtMaSoPBT.Text
                        If TypeLanguage = 0 Then
                            grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Đang soạn ")
                        Else
                            grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Planned")
                        End If
                        grvDanhSach_1.SetFocusedRowCellValue("TINH_TRANG_PBT", 1) 'dgrDanhSach_1.CurrentucCongViecPBT.grvCongViec.GetDataRow(i).Item("TINH_TRANG_PBT").Value = 1
                        BtnDuyetPBT.Enabled = False
                        cboTinhTrangPBT.SelectedValue = 1
                        bHuyHT = 1
                        flag = True
                    Else
                        bHuyHT = 0
                        Return False
                    End If
                Case 2
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "DaHoanThanhMuonChinhSua", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
                        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                        objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 2)
                        If TypeLanguage = 0 Then
                            grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Đang thực hiện ")
                        Else
                            grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Released")
                        End If
                        grvDanhSach_1.SetFocusedRowCellValue("TINH_TRANG_PBT", 2)     'dgrDanhSach_1.CurrentucCongViecPBT.grvCongViec.GetDataRow(i).Item("TINH_TRANG_PBT").Value = 2
                        BtnDuyetPBT.Enabled = False
                        cboTinhTrangPBT.SelectedValue = 2
                        bHuyHT = 1
                        flag = True
                    Else
                        bHuyHT = 0
                        Return False
                    End If
                Case 4
                    If Not NghiemThuPBT() Then Return False
                Case 5
                    If Not KhoaPBT() Then Return False

            End Select
        End If

        If iSTT = 4 Then
            Select Case iMS_TT_CT
                Case 1, 2
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgPBTDaNghiemThuVuiLongBoNghiemThu", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Case 3
                    If KiemHoanThanh() = False Then Return False

                    If CheckNghiemThuPBT() Then Return False
                    flag = True

                Case 5
                    If Not KhoaPBT() Then Return False

            End Select
        End If

        If iSTT = 5 Then
            Select Case iMS_TT_CT
                Case 1, 2, 3
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgPBTDaNghiemThuVuiLongBoNghiemThu", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Case 4
                    If KiemNghiemThu() = False Then Return False
            End Select
        End If
        Return True

    End Function
    Private Sub btnGhiPBTTT_Click(sender As Object, e As EventArgs) Handles btnGhiPBTTT.Click
        If cboPBTTTrang.Text = "" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgPhaiChonTinhTrangPBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboPBTTTrang.Focus()
            Exit Sub
        End If

        Dim sSql As String
        Dim iSTT As Integer = 1
        Dim iMS_TT_CT As Integer = -1
        'Lay trang thai phieu bao tri truoc
        sSql = "SELECT TOP 1 T2.STT, T1.MS_TT_CT   FROM PHIEU_BAO_TRI_TINH_TRANG_CHI_TIET T1 INNER JOIN TINH_TRANG_PBT_CT T2 ON T1.MS_TT_CT = T2.MS_TT_CT  WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' ORDER BY THOI_GIAN DESC"
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While objReader.Read
            If objReader.Item("MS_TT_CT").ToString = "" Then
                Exit Sub
            Else
                iMS_TT_CT = objReader.Item("MS_TT_CT")
            End If
            If objReader.Item("STT").ToString = "" Then
                Exit Sub
            Else
                iSTT = objReader.Item("STT")
            End If
        End While
        If iMS_TT_CT = Integer.Parse(cboPBTTTrang.GetColumnValue("MS_TT_CT").ToString()) Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgTinhTrangNayGanNhatDaChon", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboPBTTTrang.Focus()
            Exit Sub
        End If
        If KiemGhiPBTTT(iSTT, Integer.Parse(cboPBTTTrang.GetColumnValue("STT").ToString())) = False Then Exit Sub

        iSTT = -1
        Try
            iSTT = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spPBTTinhTrangChiTiet", txtMaSoPBT.Text, cboPBTTTrang.EditValue, txtGhiChuPBTTT.Text, UserName, dtNgay.DateTime)
            LoadNutPBTTT(True)
            TaoLuoiPBTCT(iSTT)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnKhongPBTTT_Click(sender As Object, e As EventArgs) Handles btnKhongPBTTT.Click
        LoadNutPBTTT(True)
    End Sub

    Private Sub LoadNutPBTTT(ThemSua As Boolean)
        btnThemPBTTT.Visible = ThemSua
        btnXoaPBTTT.Visible = ThemSua
        btnThoatPBTTT.Visible = ThemSua
        btnGhiPBTTT.Visible = Not ThemSua
        btnKhongPBTTT.Visible = Not ThemSua
        cboPBTTTrang.Enabled = Not ThemSua
        dtNgay.Enabled = Not ThemSua
        txtGhiChuPBTTT.Enabled = Not ThemSua
        grdTTPBT.Enabled = ThemSua
    End Sub

#Region "Duyet PBT"
    Function DuyetPBT() As Boolean
        If ObjSystems.MGetQuyenChucNang(UserName, 7) Then
            Try
                Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 2)
                If TypeLanguage = 0 Then
                    grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Đang thực hiện ")
                Else
                    grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Released")
                End If
                grvDanhSach_1.SetFocusedRowCellValue("TINH_TRANG_PBT", 2)        'dgrDanhSach_1.CurrentucCongViecPBT.grvCongViec.GetDataRow(i).Item("TINH_TRANG_PBT").Value = 2
                BtnDuyetPBT.Enabled = False
                cboTinhTrangPBT.SelectedValue = 2
                BanHanhPBT()
                'SYN'
                'Region "Sync GF"
                If isSynData Then
                    Try
                        Dim _DataSynInfo As New DataTable
                        _DataSynInfo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_FOR_DNXK_SYN", txtMaSoPBT.Text.Trim()))
                        If _DataSynInfo.Rows.Count > 0 Then
                            Dim scon As New SqlConnection(_SynConnectionInfo)
                            Try
                                scon.Open()
                            Catch ex As Exception
                                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgConnectKhongThanhCong", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                'Exit Function
                                Return False
                            End Try

                            Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
                            Try
                                'Them du lieu vao Allocated
                                For i As Integer = 0 To _DataSynInfo.Rows.Count - 1
                                    Dim command As SqlCommand = scon.CreateCommand()
                                    command.Connection = scon
                                    command.CommandTimeout = 9999
                                    command.Transaction = sqlTrans
                                    command.CommandType = CommandType.StoredProcedure
                                    command.CommandText = "INTEGRATION_INSERT_DNXK_FOR_SYN"

                                    command.Parameters.Add("@MAKHO", SqlDbType.NVarChar)
                                    command.Parameters("@MAKHO").Value = _DataSynInfo.Rows(i)("MAKHO").ToString()

                                    command.Parameters.Add("@MASOYC", SqlDbType.NVarChar)
                                    command.Parameters("@MASOYC").Value = _DataSynInfo.Rows(i)("MASOYC").ToString()

                                    command.Parameters.Add("@GIOLAP", SqlDbType.DateTime)
                                    command.Parameters("@GIOLAP").Value = _DataSynInfo.Rows(i)("GIOLAP").ToString

                                    command.Parameters.Add("@NGAYLAP", SqlDbType.DateTime)
                                    command.Parameters("@NGAYLAP").Value = _DataSynInfo.Rows(i)("NGAYLAP").ToString()

                                    command.Parameters.Add("@MASOPB", SqlDbType.NVarChar)
                                    command.Parameters("@MASOPB").Value = _DataSynInfo.Rows(i)("MASOPB").ToString()

                                    command.Parameters.Add("@TENPB", SqlDbType.NVarChar)
                                    command.Parameters("@TENPB").Value = _DataSynInfo.Rows(i)("TENPB").ToString()

                                    command.Parameters.Add("@TENNVYC", SqlDbType.NVarChar)
                                    command.Parameters("@TENNVYC").Value = _DataSynInfo.Rows(i)("TENNVYC").ToString()

                                    command.Parameters.Add("@NOIDUNG", SqlDbType.NVarChar)
                                    command.Parameters("@NOIDUNG").Value = _DataSynInfo.Rows(i)("NOIDUNG").ToString()

                                    command.Parameters.Add("@MAVT", SqlDbType.NVarChar)
                                    command.Parameters("@MAVT").Value = _DataSynInfo.Rows(i)("MAVT").ToString()

                                    command.Parameters.Add("@MAHANGMUC", SqlDbType.NVarChar)
                                    command.Parameters("@MAHANGMUC").Value = _DataSynInfo.Rows(i)("MAHANGMUC").ToString()

                                    command.Parameters.Add("@MALYDOXUAT", SqlDbType.NVarChar)
                                    command.Parameters("@MALYDOXUAT").Value = _DataSynInfo.Rows(i)("MALYDOXUAT").ToString()

                                    command.Parameters.Add("@SOLUONG", SqlDbType.Float)
                                    command.Parameters("@SOLUONG").Value = _DataSynInfo.Rows(i)("SOLUONG").ToString()

                                    command.Parameters.Add("@INSERT_DATE", SqlDbType.DateTime)
                                    command.Parameters("@INSERT_DATE").Value = _DataSynInfo.Rows(i)("INSERT_DATE").ToString

                                    command.ExecuteNonQuery()
                                Next


                                sqlTrans.Commit()
                                scon.Close()


                            Catch ex As Exception
                                XtraMessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                sqlTrans.Rollback()
                                scon.Close()
                                Return False
                            End Try

                        End If

                    Catch ex As Exception
                        XtraMessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End Try
                End If
                'END SYN

                If sPrivate = "BARIA" And cboTinhTrangPBT.SelectedValue = 1 Then btnIn_1.Enabled = False Else btnIn_1.Enabled = True
                Return True
            Catch ex As Exception
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPheDuyet", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try

            'End While
        Else
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPheDuyet", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
            'objReader.Close()
        End If

    End Function



#End Region

#Region "Hoan Thanh"

    Function HoanThanhPBT() As Boolean
        If txtMaSoPBT.Text = "" Then Return False
        Dim Str As String = ""
        If Not KiemPhieuBaoTriCongViecNhanSu() Then Return False
        If cboTinhTrangPBT.SelectedValue = 1 Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPhieuBTChuaDuyet", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.Yes Then
                If ObjSystems.MGetQuyenChucNang(Modules.UserName, 7) = False Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPheDuyet", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                Str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
                " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=7 "
                Dim objReader22 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                While objReader22.Read
                    If objReader22.Item("STT").ToString <> "" Then
                        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                        objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 2)
                        If TypeLanguage = 0 Then
                            grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Đang thực hiện ")
                        Else
                            grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Released")
                        End If
                        grvDanhSach_1.SetFocusedRowCellValue("TINH_TRANG_PBT", 2)
                        BtnDuyetPBT.Enabled = False
                        'BindData()
                        Exit While
                    End If
                End While
                btnHThanhNT.Enabled = False
                objReader22.Close()
            Else
                Return False
            End If
        End If

        If cboTinhTrangPBT.SelectedValue = 4 Then
            'Dim Traloi As String = XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgQuyenXoa3", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgQuyenXoa3", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.Yes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 3)
                Str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                Str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                Str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str)
                cboTinhTrangPBT.SelectedValue = 3
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapNgayHThanhPBT", txtMaSoPBT.Text)

                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapHoanThanhKHTT", txtMaSoPBT.Text, "-1", "-1", 100)
                Catch ex As Exception
                    'XtraMessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End Try
                bHuyNT = 1
            Else
                Return False
            End If
        Else
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "CoChacHoanThanh", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then Return False
            Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
            objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 3)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapNgayHThanhPBT", txtMaSoPBT.Text)

            ucCongViecNS.iTTPBTri = 3
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapHoanThanhKHTT", txtMaSoPBT.Text, "-1", "-1", 100)
                If (menuClick = False) Then
                    CapNhapPBTCT(3)
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End Try
        End If
        Try
            Str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI=N'" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)

            Str = "UPDATE [PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET] SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI=N'" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)

            Str = "UPDATE [PHIEU_BAO_TRI_NHAN_SU] SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI=N'" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Str)
        Catch ex As Exception
        End Try
        Dim sPBT As String
        sPBT = txtMaSoPBT.Text
        If optNTHT.SelectedIndex <> 1 Then
            btnHThanhNT.Enabled = False
            ucCongViecNS.iTTPBTri = 3

            ucCongViecNS.btnHThanhNS.Enabled = False
            optNTHT.SelectedIndex = 1
        End If
        Try
            For i As Integer = 0 To grvDanhSach_1.RowCount - 1
                If grvDanhSach_1.GetRowCellValue(i, "MS_PHIEU_BAO_TRI") = sPBT Then
                    grvDanhSach_1.FocusedRowHandle = i
                    intRowPBT = i
                    ShowData()
                    Exit For
                End If
            Next
            cboTinhTrangPBT.SelectedValue = 3
            If (TabPhieuBaoTri.SelectedTabPageIndex = 2) Then
                If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 0 Then
                    ucCongViecNS.LoadCongViecChinhNS()
                Else
                    ucCongViecNS.LoadCongViecPhuNS()
                End If
            End If
        Catch ex As Exception
        End Try
        Dim t As Thread = New Thread(New ParameterizedThreadStart(AddressOf GoiMailHoanThanhNT))
        t.Start(True)
        Return True
    End Function

    Private Sub cboMAY_EditValueChanged(sender As Object, e As EventArgs) Handles cboMAY.EditValueChanged
        If cboMAY.Text = "" Then Exit Sub

        If isfirst = True Then

            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetLoaiBaoTriHinhThuc", cboMAY.EditValue))

            cboLoaiBT.Properties.DataSource = Nothing
            SQLString = "0Load"
            cboLoaiBT.Properties.DataSource = dt
            SQLString = ""
            cboLoaiBT.Properties.DisplayMember = "TEN_LOAI_BT"
            cboLoaiBT.Properties.ValueMember = "MS_LOAI_BT"
            cboLoaiBT.Properties.PopulateColumns()
            cboLoaiBT.Properties.Columns("MS_LOAI_BT").Visible = False
            cboLoaiBT.Properties.Columns("HU_HONG").Visible = False
            cboLoaiBT.Properties.Columns("PHONG_NGUA").Visible = False

            cboLoaiBT.Properties.Columns("TEN_LOAI_BT").Caption = ObjLanguages.GetLanguage(ModuleName, Me.Name, "TEN_LOAI_BT", TypeLanguage)

            cboLoaiBT.EditValue = -1


            If btnGhi_1.Visible = True Then
                Try
                    cboMucUuTien1.EditValue = Convert.ToInt32(cboMAY.GetColumnValue("MUC_UU_TIEN"))

                Catch ex As Exception
                    cboMucUuTien1.EditValue = -1
                End Try
            End If
            Try
                If Privates() = "KIDO" Then
                    Dim dr As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_CONG_NHAN_BTPT", cboMAY.EditValue)
                    dr.Read()
                    If dr.HasRows Then
                        Try
                            cboNguoiLap1.EditValue = Convert.ToInt32(dr("MS_CONG_NHAN"))
                        Catch ex As Exception
                            cboNguoiLap1.EditValue = dr("MS_CONG_NHAN")
                        End Try

                    Else
                        cboNguoiLap1.EditValue = -1
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub



#End Region

#Region "Ngiem Thu PBT"

    Sub CapNhatSLTTTuDong(ByVal MS_PHIEU_BAO_TRI As String)

        For i As Integer = 0 To grvPTThayThe.RowCount
            Dim slkh As Double = 0.0
            Try
                slkh = Convert.ToDouble(grvPTThayThe.GetDataRow(i)("SL_KH"))
            Catch ex As Exception
                Continue For
            End Try
            TB_PHU_TUNG_THAY_THE_CHI_TIET.Columns("SL_TT").ReadOnly = False
            For Each dr As DataRow In TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows
                If (dr("MS_BO_PHAN") = grvPTThayThe.GetDataRow(i)("MS_BO_PHAN") And
                    dr("MS_PT") = grvPTThayThe.GetDataRow(i)("MS_PT") And
                    dr("MS_CV") = grvPTThayThe.GetDataRow(i)("MS_CV") And
                    dr("STT") = grvPTThayThe.GetDataRow(i)("STT")) Then
                    If (slkh > Convert.ToDouble(dr("SO_LUONG_THUC_XUAT"))) Then
                        Try
                            dr("SL_TT") = dr("SO_LUONG_THUC_XUAT") - dr("SL_TRA")
                            If (Convert.ToDouble(dr("SL_TT")) < 0) Then
                                dr("SL_TT") = dr("SO_LUONG_THUC_XUAT")
                            End If
                        Catch ex As Exception
                            dr("SL_TT") = dr("SO_LUONG_THUC_XUAT")
                        End Try

                        slkh = slkh - Convert.ToDouble(dr("SO_LUONG_THUC_XUAT"))
                    ElseIf (slkh < Convert.ToDouble(dr("SO_LUONG_THUC_XUAT"))) Then
                        Try
                            dr("SL_TT") = slkh - dr("SL_TRA")
                            If (Convert.ToDouble(dr("SL_TT")) < 0) Then
                                dr("SL_TT") = slkh
                            End If
                        Catch ex As Exception
                            dr("SL_TT") = slkh
                        End Try
                        slkh = 0
                    Else
                        Try
                            dr("SL_TT") = slkh - dr("SL_TRA")
                            If (Convert.ToDouble(dr("SL_TT")) < 0) Then
                                dr("SL_TT") = slkh
                            End If
                        Catch ex As Exception
                            dr("SL_TT") = slkh
                        End Try
                        slkh = 0
                    End If
                End If
            Next
            TB_PHU_TUNG_THAY_THE_CHI_TIET.Columns("MS_PT").ReadOnly = True
        Next
        If Convert.ToBoolean(ObjSystems.PBTKho) Then
            Dim sqlUpdate As DataVietsoft.Sqlvs = New DataVietsoft.Sqlvs(Commons.IConnections.ConnectionString())
            If sqlUpdate.OpenConnecTion() Then
                Dim TB_TMP As DataTable = TB_PHU_TUNG_THAY_THE_CHI_TIET.Copy()
                TB_TMP.Columns.Remove("XUAT_XU")
                TB_TMP.Columns.Remove("BAO_HANH_DEN_NGAY")
                TB_TMP.Columns.Remove("SO_LUONG_THUC_XUAT")
                '----
                TB_TMP.Columns.Remove("MS_DH_NHAP_TRA")
                TB_TMP.Columns.Remove("SL_TRA")
                TB_TMP.Columns.Remove("SL_TAICHE")
                TB_TMP.Columns.Remove("MS_DH_NHAP_TC")
                TB_TMP.Columns.Remove("DG_TAICHE")
                TB_TMP.Columns.Remove("TAI_SD")




                'Dim TB_TMP_1 As DataTable = CType(grdPhuTungThayThe.DataSource, DataTable).Copy()
                Dim TB_TMP_1 As DataTable = CType(grdPTThayThe.DataSource, DataTable).Copy()
                Dim sBTTT As String = "PPTT_TMP" & UserName

                ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTTT, TB_TMP_1, "")

                TB_TMP_1.DefaultView.RowFilter = "LOAI = 0"
                TB_TMP_1 = (TB_TMP_1.DefaultView.ToTable).Copy


                sqlUpdate.BeginTransacTion()
                Try

                    If ObjSystems.KhoMoi = True Then
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", TB_TMP, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT", "MS_DH_XUAT_PT", "MS_DH_NHAP_PT", "MS_PT1", "ID")
                    Else
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO_1", TB_TMP, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT", "MS_DH_XUAT_PT", "MS_DH_NHAP_PT", "MS_PT1")
                    End If



                    TB_TMP_1.Columns.Remove("TEN_BO_PHAN")
                    TB_TMP_1.Columns.Remove("TEN_PT")
                    TB_TMP_1.Columns.Remove("XUAT_XU")
                    TB_TMP_1.Columns.Remove("BAO_HANH_DEN_NGAY")
                    TB_TMP_1.Columns.Remove("LOAI")
                    TB_TMP_1.Columns.Add("MS_PHIEU_BAO_TRI")
                    For Each rUp As DataRow In TB_TMP_1.Rows
                        rUp("MS_PHIEU_BAO_TRI") = Me.txtMaSoPBT.Text.Trim()
                    Next
                    'SYN


                    If isSynData = True Then
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "INTEGRATION_insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "INTEGRATION_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_2", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "INTEGRATION_insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "INTEGRATION_update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_3", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")

                    Else
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_2", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                        DataVietsoft.Datavs.UpdateMultiRecode(sqlUpdate, "insert_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", "update_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_3", "select_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_1", TB_TMP_1, "MS_PHIEU_BAO_TRI", "MS_CV", "MS_BO_PHAN", "MS_PT", "STT")
                    End If
                    sqlUpdate.ExecuteNonQuery(CommandType.StoredProcedure, "CapNhapPBTPTroNghiemThu", Me.txtMaSoPBT.Text.Trim(), sBTTT)

                    sqlUpdate.CommitTransacTion()
                Catch ex As Exception
                    sqlUpdate.RollbackTransacTion()
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnCapNhatTuDong.Click
        CapNhatSLTTTuDong(txtMaSoPBT.Text)
    End Sub

    Function NghiemThuPBT() As Boolean

        If txtMaSoPBT.Text.Trim = "" Then Return False
        blnLoiGhiDuLieu = False
        Dim sSql As String
        If Not KiemPhieuBaoTriCongViecNhanSu() Then Return False
        Dim dtTmp As New DataTable
        If sPrivate = "BARIA" Then
            dtTmp = New DataTable
            sSql = "SELECT * FROM PSDV_PHIEU_BT WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "' AND ISNULL(CHI_PHI_PB,0) = 0 "
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count > 0 Then
                Dim lstPSDV As String = ""
                lstPSDV = String.Join(vbCrLf, dtTmp.Select().AsEnumerable().Select(Function(x) x("MS_YEU_CAU").ToString()).ToArray())
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgPBTChuaPhanBoNenKhongTheNT", TypeLanguage) & vbCrLf & lstPSDV, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        If cboTinhTrangPBT.SelectedValue = 1 Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPhieuBTChuaDuyet", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.Yes Then
                If ObjSystems.MGetQuyenChucNang(UserName, 7) Then
                    sSql = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
                    " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=7 "
                    Dim objReader22 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                    While objReader22.Read
                        If objReader22.Item("STT").ToString <> "" Then
                            Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                            objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 2)
                            If TypeLanguage = 0 Then
                                grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Đang thực hiện ")
                            Else
                                grvDanhSach_1.SetFocusedRowCellValue("TEN_TINH_TRANG", "Released")
                            End If

                            Try
                                Dim index As Integer = dtPBT.Rows.IndexOf(grvDanhSach_1.GetFocusedDataRow())
                                dtPBT.Columns("TEN_TIENG_VIET").ReadOnly = False
                                dtPBT.Rows(index)("TEN_TIENG_VIET") = "In Progress"
                                tinhTrangPBT_Tmp = "In Progress"
                                dtPBT.AcceptChanges()
                            Catch
                            End Try

                            grvDanhSach_1.SetFocusedRowCellValue("TINH_TRANG_PBT", 2) 'dgrDanhSach_1.CurrentucCongViecPBT.grvCongViec.GetDataRow(i).Item("TINH_TRANG_PBT").Value = 2
                            BtnDuyetPBT.Enabled = False
                            'BindData()
                            Exit While
                        End If
                    End While
                    objReader22.Close()
                    'Nho cap nhap vao PBTTT
                Else
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPheDuyet", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Else
                Return False
            End If
        End If

        sSql = " SELECT MS_PHIEU_BAO_TRI,MS_CONG_NHAN, NGAY,TU_GIO,DEN_NGAY,DEN_GIO,SO_GIO, 1 AS LOAI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE ISNULL(SO_GIO,0) = 0 AND MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' UNION SELECT MS_PHIEU_BAO_TRI,MS_CONG_NHAN,NGAY,TU_GIO,DEN_NGAY,DEN_GIO,SO_GIO, 2 AS LOAI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE ISNULL(SO_GIO,0) = 0 AND MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' UNION SELECT MS_PHIEU_BAO_TRI,MS_CONG_NHAN,NGAY,TU_GIO,DEN_NGAY,DEN_GIO,SO_GIO, 3 AS LOAI FROM PHIEU_BAO_TRI_NHAN_SU WHERE ISNULL(SO_GIO,0) = 0 AND MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "'"

        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        If dtTmp.Rows.Count > 0 Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgConNhanSuChuaNhanThoiGianCoMuonXoa", TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbYes Then
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spDeleteChuaNhapNhanSu", txtMaSoPBT.Text)
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message.ToString())
                End Try
                ucCongViecNS.sMsPBT = ""
            End If
        End If
        ThucHienGhiThongTinNghiemThu()
        Dim PN As Integer
        If sPrivate.Equals("BARIA") And blnLoiGhiDuLieu = False Then
            sSql = "SELECT    CASE COUNT(*) WHEN NULL THEN 0 ELSE COUNT(*) END " &
                        " FROM dbo.PHIEU_BAO_TRI AS T1 INNER JOIN dbo.LOAI_BAO_TRI AS T2 ON T1.MS_LOAI_BT = T2.MS_LOAI_BT INNER JOIN " &
                        " dbo.HINH_THUC_BAO_TRI AS T3 ON T2.MS_HT_BT = T3.MS_HT_BT INNER JOIN (SELECT T1.* FROM MAY_LOAI_BTPN_CHU_KY T1 INNER JOIN " &
                        " (SELECT MS_MAY, MS_LOAI_BT , MAX(NGAY_AD) AS NGAY_MAX FROM dbo.MAY_LOAI_BTPN_CHU_KY GROUP BY MS_MAY, MS_LOAI_BT )T2 ON  " &
                        " T1.MS_MAY = T2.MS_MAY AND T1.NGAY_AD = T2.NGAY_MAX AND T1.MS_LOAI_BT = T2.MS_LOAI_BT) AS T4 ON  " &
                        "             T1.MS_MAY = T4.MS_MAY And T1.MS_LOAI_BT = T4.MS_LOAI_BT " &
                        " WHERE     (T1.MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "') AND (T3.PHONG_NGUA = 1) AND ISNULL(RUN_TIME,0) <> 0"
            Try
                If txtSGLuyKe.Text = "" Then txtSGLuyKe.Text = 0
                Try
                    PN = Integer.Parse(SqlHelper.ExecuteScalar(IConnections.ConnectionString, CommandType.Text, sSql))
                Catch ex As Exception
                    PN = 0
                End Try

                If PN <> 0 And Integer.Parse(txtSGLuyKe.Text) = 0 Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgChuaNhapSoGio", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.Yes Then
                        blnLoiGhiDuLieu = True
                        Return False
                    End If
                    PN = 0
                End If
            Catch ex As Exception

            End Try
            Try


                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdatePhieuBaoTriNghiemThu",
                        Me.txtMaSoPBT.Text, IIf(IsDBNull(Me.txtTinhTrangSauBaoTri.Text), Nothing, Me.txtTinhTrangSauBaoTri.Text),
                        IIf(IsDBNull(Me.cboNguoiNghiemThu.SelectedValue), Nothing, Me.cboNguoiNghiemThu.SelectedValue),
                        IIf(IsDBNull(Me.txtNgayNghiemThu.Text) Or txtNgayNghiemThu.Text = "  /  /", Nothing, txtNgayNghiemThu.Text),
                        UserName, IIf(IsDBNull(Me.txtSGLuyKe.Text), Nothing, Me.txtSGLuyKe.Text))
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message)
                blnLoiGhiDuLieu = True
                Return False
            End Try
        End If


        If blnLoiGhiDuLieu Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "CHINH_SUA_DL", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If Not ObjSystems.MGetQuyenChucNang(UserName, 8) Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgNghiemThu", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Try

            Dim res As String
            Try
                res = txtNgayNghiemThu.DateTime.ToString("yyyy-MM-dd hh:mm:ss")
            Catch ex As Exception
                res = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
            End Try

            If PN = 1 Then
                If Not TinhSGLK(cboMAY.EditValue, DateTime.Now.ToString(res)) Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgCapNhapGioLuyKeSai", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        Catch ex As Exception

        End Try


        Dim i As Integer
        i = i

        dtTable_tmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spKiemNTChuaNhapSoLuong", txtMaSoPBT.Text))
        If dtTable_tmp.Rows.Count > 0 Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgCapNhapSLTTTuDong", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then Return False
            CapNhatSLTTTuDong(txtMaSoPBT.Text)
            dtTable_tmp = New DataTable()
            dtTable_tmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spKiemNTChuaNhapSoLuong", txtMaSoPBT.Text))
        End If


        If dtTable_tmp.Rows.Count > 0 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "ConPhuTungChuaNhapSLTT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        'kiểm tra phụ tùng xuất có phải là phụ tùng tái sử dụng nếu có thì cho lên form nhập tái sử dụng từ phiếu bảo trì


        'hỏ có chắc nghiệm thu phiếu bảo trì này không
        If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgKT16", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then Return False
        Dim strPN As String = "", strPX As String = ""
        Dim dtReader As SqlDataReader
        Dim blnNT As Boolean = False
        KTThongTinNT()
        If blnLoiGhiDuLieu Then Return False
        If blnNT Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT14", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Dim check_cv As Integer = -1
        sSql = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "' AND NGAY_HOAN_THANH IS NULL"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            blnNT = True
            Exit While
        End While
        dtReader.Close()
        If blnNT Then
            If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKT15", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then Return False
            sSql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & txtNgayNghiemThu.Text & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND NGAY_HOAN_THANH IS NULL"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            sSql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET H_THANH = 1,PT_HOAN_THANH = 100 WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapHoanThanhKHTT", txtMaSoPBT.Text, "-1", "-1", 100)
            Catch ex As Exception

            End Try
        End If
        sSql = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & txtNgayNghiemThu.Text & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND NGAY_HOAN_THANH IS NULL"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        'GHI THONG TIN CHI PHI KHAC
        Try
            sSql = "INSERT INTO PHIEU_BAO_TRI_CHI_PHI(MS_PHIEU_BAO_TRI,CHI_PHI_KHAC,CHI_PHI_KHAC_USD) VALUES(N'" & txtMaSoPBT.Text & "'," & IIf(IsDBNull(txtChiPhiKhacMacDinh.Text), 0, txtChiPhiKhacMacDinh.Text.Replace(",", "")) & ", " & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & ")"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception
            Try
                sSql = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC=" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacMacDinh.Text, ",", ""))) & ", CHI_PHI_KHAC_USD =" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacUSD.Text, ",", ""))) & " WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Catch ex1 As Exception
                sSql = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC=" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacMacDinh.Text, ",", ""))) & ", CHI_PHI_KHAC_USD =" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacUSD.Text, ",", ""))) & " WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            End Try
        End Try
        Dim CHI_PHI_PHU_TUNG As Double = 0, CHI_PHI_PHU_TUNG_USD As Double = 0, CHI_PHI_VAT_TU As Double = 0, CHI_PHI_VAT_TU_USD As Double = 0, CHI_PHI_NHAN_CONG As Double = 0, CHI_PHI_NHAN_CONG_USD As Double = 0, CHI_PHI_DV As Double = 0, CHI_PHI_DV_USD As Double = 0, CHI_PHI_KHAC As Double = 0, CHI_PHI_KHAC_USD As Double = 0, dblTiGia As Double = 0, dblTiGiaUSD As Double


        If Convert.ToBoolean(ObjSystems.PBTKho) Then
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_TONG_CHI_PHI_VT", Me.txtMaSoPBT.Text)
        Else

            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_CHI_PHI_VT_PT_KHONG_SD_KHO", Me.txtMaSoPBT.Text, 1)
        End If
        Try

            While dtReader.Read
                CHI_PHI_VAT_TU = CHI_PHI_VAT_TU + IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
                CHI_PHI_VAT_TU_USD = CHI_PHI_VAT_TU_USD + IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
            End While
            dtReader.Close()
            CHI_PHI_KHAC = CLng(Val(txtChiPhiKhacMacDinh.Text))
            CHI_PHI_KHAC_USD = CLng(Val(txtChiPhiKhacUSD.Text))
            'history



            Dim bCoTmp As Boolean = False
            Dim tbTmp As New DataTable()
            sSql = "SELECT distinct MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND " &
            " (SELECT COUNT(*) FROM (SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE " &
            " FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
            " UNION SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE FROM PHIEU_BAO_TRI_DI_CHUYEN_BP  " &
            " INNER JOIN PHIEU_BAO_TRI ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
            " WHERE PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' AND DAI_HAN=1 AND (NGAY_TRA_TT IS NULL OR NGAY_TRA_TT>=NGAY_NGHIEM_THU)AND MS_MAY=N'" & cboMAY.EditValue & "' ) AS P1 " &
            " WHERE PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=P1.MS_BO_PHAN)>1"

            Dim objReader1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            While objReader1.Read
                If objReader1.Item("MS_BO_PHAN").ToString <> "" Then
                    bCoTmp = True
                End If
            End While
            objReader1.Close()
            If bCoTmp Then
                Try
                    sSql = "DROP TABLE TMP_CONG_VIEC" & UserName
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                Catch ex As Exception
                End Try
                Try
                    sSql = "DROP TABLE TMP_MAY_BO_PHAN" & UserName
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                Catch ex As Exception
                End Try
                sSql = "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN,CONG_VIEC.MS_CV ,MO_TA_CV into TMP_CONG_VIEC" & UserName & " FROM PHIEU_BAO_TRI_CONG_VIEC INNER JOIN PHIEU_BAO_TRI " &
                " ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI INNER JOIN " &
                " CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV WHERE PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND " &
                "((SELECT COUNT(*) FROM PHIEU_BAO_TRI_DI_CHUYEN_BP PBTDC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
                " AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=PBTDC.MS_BO_PHAN)+(select COUNT(*) FROM PHIEU_BAO_TRI_DI_CHUYEN_BP PBTDC1 " &
                " INNER JOIN PHIEU_BAO_TRI PBT ON PBTDC1.MS_PHIEU_BAO_TRI=PBT.MS_PHIEU_BAO_TRI " &
                " WHERE PBT.MS_PHIEU_BAO_TRI <> '" & txtMaSoPBT.Text & "' AND (NGAY_TRA_TT IS NULL " &
                " OR NGAY_TRA_TT>=NGAY_NGHIEM_THU) AND PBT.MS_MAY=N'" & cboMAY.EditValue & "' AND PBTDC1.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN))>1"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                sSql = "SELECT DISTINCT '" & cboMAY.EditValue & "' as MS_MAY,  MS_BO_PHAN,TEN_BO_PHAN,MS_MAY_THAY_THE AS MS_MAY_TT,MS_BO_PHAN_THAY_THE AS MS_BO_PHAN_TT,TEN_BO_PHAN_THAY_THE/*,NGAY_TRA_TT*/,CHON,MS_CV INTO TMP_MAY_BO_PHAN" & UserName & " FROM " &
                " (SELECT MS_BO_PHAN,TEN_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE,TEN_BO_PHAN_THAY_THE,NGAY_TRA_TT,CONVERT(BIT,0)AS CHON,CONVERT(INT,NULL)AS MS_CV FROM " &
                " (SELECT * FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'   " &
                " UNION SELECT PHIEU_BAO_TRI_DI_CHUYEN_BP.* FROM PHIEU_BAO_TRI_DI_CHUYEN_BP INNER JOIN PHIEU_BAO_TRI ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' AND (NGAY_TRA_TT IS NULL " &
                " OR NGAY_TRA_TT>=NGAY_NGHIEM_THU )AND MS_MAY=N'" & cboMAY.EditValue & "'/* AND MS_BO_PHAN NOT IN (SELECT DISTINCT MS_BO_PHAN FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' )*/) AS P2 " &
                " WHERE P2.MS_BO_PHAN IN (SELECT distinct MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND " &
                " (SELECT COUNT(*) FROM (SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE   " &
                " FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
                " UNION SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE FROM PHIEU_BAO_TRI_DI_CHUYEN_BP INNER JOIN " &
                " PHIEU_bAO_TRI ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_bAO_TRI.MS_PHIEU_BAO_TRI " &
                " WHERE PHIEU_bAO_TRI.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' AND (NGAY_TRA_TT IS NULL OR NGAY_TRA_TT>=NGAY_NGHIEM_THU) AND MS_MAY=N'" & cboMAY.EditValue & "') AS P1 " &
                " WHERE PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=P1.MS_BO_PHAN)>1))AS P3 "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                frmChonCongViecChoBoPhan.MS_MAY = cboMAY.EditValue
                frmChonCongViecChoBoPhan.ShowDialog()
            End If
            Dim bCoTmp1 As Boolean = False, bCoTmp2 As Boolean = False, bCoTmp3 As Boolean = False
            Dim objRead As SqlDataReader
            Dim strTmp As String = ""
            tbTmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_BO_PHAN,MS_CV FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'").Tables(0)
            For i = 0 To tbTmp.Rows.Count - 1

                If bCoTmp Then
                    sSql = "SELECT MS_MAY_TT,MS_BO_PHAN_TT FROM TMP_MAY_BO_PHAN" & UserName & " WHERE MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV=" & tbTmp.Rows(i).Item("MS_CV")
                    objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                    While objRead.Read
                        bCoTmp2 = True
                        sSql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT= N'" & objRead.Item("MS_MAY_TT") & "', MS_BO_PHAN_TT= N'" & objRead.Item("MS_BO_PHAN_TT") & "', PHU_TUNG_TT= N'" & strTmp & "' WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                    End While
                    objRead.Close()
                End If
                If Not bCoTmp2 Then
                    sSql = "SELECT MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE FROM PHIEU_BAO_TRI_DI_CHUYEN_BP INNER JOIN PHIEU_BAO_TRI " &
                    " ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
                    " WHERE (NGAY_TRA_TT IS NULL or NGAY_TRA_TT>=NGAY_NGHIEM_THU)AND DAI_HAN=1 AND MS_MAY=N'" & cboMAY.EditValue & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "'"
                    objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                    While objRead.Read
                        sSql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=N'" & objRead.Item("MS_MAY_THAY_THE") & "', MS_BO_PHAN_TT=N'" & objRead.Item("MS_BO_PHAN_THAY_THE") & "', PHU_TUNG_TT=N'" & strTmp & "' WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                        bCoTmp1 = True
                    End While
                    objRead.Close()
                    If Not bCoTmp1 Then
                        'trường hợp các bộ phận mượn đều đã trả
                        sSql = " select TOP 1 MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE from PHIEU_BAO_TRI_DI_CHUYEN_BP " &
                        "WHERE DAI_HAN=1 AND MS_PHIEU_bAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' ORDER BY NGAY_TRA_TT DESC"
                        objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                        While objRead.Read
                            If objRead.Item("MS_MAY_THAY_THE").ToString <> "" Then
                                sSql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=N'" & objRead.Item("MS_MAY_THAY_THE") & "', MS_BO_PHAN_TT=N'" & objRead.Item("MS_BO_PHAN_THAY_THE") & "', PHU_TUNG_TT=N'" & strTmp & "' WHERE MS_PHIEU_BAO_TRI=N'" & txtMaSoPBT.Text & "' AND MS_BO_PHAN=N'" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                                bCoTmp3 = True
                            End If
                        End While
                        objRead.Close()
                        If Not bCoTmp3 Then
                            sSql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=N'" & cboMAY.EditValue & "', MS_BO_PHAN_TT=N'" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "', PHU_TUNG_TT=N'" & strTmp & "' WHERE MS_PHIEU_BAO_TRI=N'" & txtMaSoPBT.Text & "' AND MS_BO_PHAN=N'" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                        End If
                    End If
                End If
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                bCoTmp3 = False
                bCoTmp2 = False
                bCoTmp1 = False
            Next
            'history

            'CHI PHI NHAN CONG
            sSql = "SELECT TI_GIA, TI_GIA_USD " &
                     "FROM TI_GIA_NT INNER JOIN NGOAI_TE ON TI_GIA_NT.NGOAI_TE=NGOAI_TE.NGOAI_TE " &
                     "WHERE NGOAI_TE.MAC_DINH=1 AND NGAY_NHAP >= (SELECT ISNULL(MAX(NGAY_NHAP),0) " &
                                                                 "FROM TI_GIA_NT INNER JOIN NGOAI_TE ON TI_GIA_NT.NGOAI_TE = NGOAI_TE.NGOAI_TE " &
                                                                 "WHERE DATEDIFF(DAY,NGAY_NHAP,'" & Format(CDate(txtNgayNghiemThu.Text), "dd/MMM/yyyy") & "')>=0)"

            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            While dtReader.Read
                dblTiGia = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
                dblTiGiaUSD = IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
            End While
            dtReader.Close()

            Dim inc As Boolean = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetPBT_CPNC")
            If inc Then
                Dim tCHIPHI As New DataTable
                tCHIPHI.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CPNC_NEW", txtMaSoPBT.Text, txtNgayNghiemThu.Text))
                If tCHIPHI.Rows.Count > 0 And tCHIPHI.Rows(0)("TI_GIA").ToString <> "" Then
                    CHI_PHI_NHAN_CONG = Double.Parse(tCHIPHI.Rows(0)("TI_GIA").ToString())
                    CHI_PHI_NHAN_CONG_USD = Double.Parse(tCHIPHI.Rows(0)("TI_GIA_USD").ToString())
                Else
                    CHI_PHI_NHAN_CONG = 0
                    CHI_PHI_NHAN_CONG_USD = 0
                End If
            Else
                Dim tCHIPHI As New DataTable
                tCHIPHI.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spChiPhiNhanCong", txtMaSoPBT.Text, dtNgayBDKH1.DateTime.Date))
                If tCHIPHI.Rows.Count > 0 Then
                    CHI_PHI_NHAN_CONG = IIf(IsDBNull(Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())), 0, Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())) * dblTiGia
                    CHI_PHI_NHAN_CONG_USD = IIf(IsDBNull(Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())), 0, Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())) * dblTiGiaUSD
                Else
                    CHI_PHI_NHAN_CONG = 0
                    CHI_PHI_NHAN_CONG_USD = 0
                End If
            End If
            'CHI PHI DICH VU
            sSql = "SELECT PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI, SUM(PHIEU_BAO_TRI_SERVICE.SO_LUONG * PHIEU_BAO_TRI_SERVICE.DON_GIA * TI_GIA_NT.TI_GIA) AS CHI_PHI_DV, " &
                          "SUM(PHIEU_BAO_TRI_SERVICE.SO_LUONG * PHIEU_BAO_TRI_SERVICE.DON_GIA * TI_GIA_NT.TI_GIA_USD) AS CHI_PHI_DV_USD " &
                     "FROM PHIEU_BAO_TRI_SERVICE INNER JOIN TI_GIA_NT ON PHIEU_BAO_TRI_SERVICE.NGOAI_TE = TI_GIA_NT.NGOAI_TE " &
                     "WHERE (TI_GIA_NT.NGAY_NHAP >= ALL (SELECT MAX(NGAY_NHAP) FROM TI_GIA_NT)) " &
                     "GROUP BY PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI HAVING (PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "')"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            While dtReader.Read
                CHI_PHI_DV = IIf(IsDBNull(dtReader.Item("CHI_PHI_DV")), 0, dtReader.Item("CHI_PHI_DV"))
                CHI_PHI_DV_USD = IIf(IsDBNull(dtReader.Item("CHI_PHI_DV_USD")), 0, dtReader.Item("CHI_PHI_DV_USD"))
            End While
            dtReader.Close()

            sSql = "SELECT TOP (1) T2.MS_PT,TEN_PT FROM dbo.IC_PHU_TUNG AS T2 INNER JOIN dbo.LOAI_VT AS T3 ON T2.MS_LOAI_VT = T3.MS_LOAI_VT INNER JOIN
                (SELECT A.MS_MAY, A.MS_BO_PHAN, A.MS_PT, A.MS_VI_TRI_PT, A.SO_LUONG, SUM(B.SL_TT) AS SL_TT 
                FROM dbo.CAU_TRUC_THIET_BI_PHU_TUNG AS A INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET AS B ON 
                A.MS_BO_PHAN = B.MS_BO_PHAN AND A.MS_PT = B.MS_PT AND A.MS_VI_TRI_PT = B.MS_VI_TRI_PT INNER JOIN dbo.PHIEU_BAO_TRI AS C ON 
                A.MS_MAY = C.MS_MAY AND B.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI WHERE (C.MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text.Trim() & "')
                GROUP BY A.MS_MAY, A.MS_BO_PHAN, A.MS_PT, A.MS_VI_TRI_PT, A.SO_LUONG) AS T1 ON T2.MS_PT = T1.MS_PT
                WHERE (T1.SL_TT > T1.SO_LUONG) AND (ISNULL(T3.VAT_TU, 0) = 0)"


            dtTmp = New DataTable()

            If Convert.ToBoolean(ObjSystems.PBTKho) Then
                dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, sSql))

                If dtTmp.Rows.Count > 0 Then
                    If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name,
                        "MsgSL_KHONG_CAN_TREN_CT", TypeLanguage) & vbCrLf & dtTmp.Rows(0)("MS_PT").ToString() & " - " & dtTmp.Rows(0)("TEN_PT").ToString(), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.No Then
                        Try
                            For j As Integer = 0 To grvPTThayThe.RowCount - 1
                                If (grvPTThayThe.GetDataRow(j)("MS_PT").ToString().Equals(dtTmp.Rows(0)("MS_PT").ToString())) Then
                                    grvPTThayThe.FocusedRowHandle = j
                                    grvPTThayThe.FocusedColumn = grvPTThayThe.Columns("MS_PT")
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception

                        End Try
                        Return False
                    End If
                End If

                'KIỂM TRA CÂN
                dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PT_XUAT_PTSD", txtMaSoPBT.Text.Trim()))
                For Each rSL As DataRow In dtTmp.Rows
                    If (Not rSL("SL_TT").Equals(rSL("SL_VT"))) Then
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgSL_PT_KHONG_CAN", TypeLanguage) & vbCrLf & rSL("MS_PT").ToString() & " - " & rSL("TEN_PT").ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Try
                            For j As Integer = 0 To grvPTThayThe.RowCount - 1
                                If (grvPTThayThe.GetDataRow(j)("MS_PT").ToString().Equals(dtTmp.Rows(0)("MS_PT").ToString())) Then
                                    grvPTThayThe.FocusedRowHandle = j
                                    grvPTThayThe.FocusedColumn = grvPTThayThe.Columns("MS_PT")
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                        End Try
                        Return False
                    End If
                Next
                dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "Select TOP 1 MS_DH_XUAT_PT FROM IC_DON_HANG_XUAT WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text.Trim() & "' AND  ( ISNULL(LOCK,0) = 0)  ORDER BY MS_DH_XUAT_PT "))

                If dtTmp.Rows.Count > 0 Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgSL_PXK_CHUA_LOCK", TypeLanguage) & vbCrLf & dtTmp.Rows(0)("MS_DH_XUAT_PT").ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Clipboard.SetText(dtTmp.Rows(0)("MS_DH_XUAT_PT").ToString())
                    Return False
                End If
                sSql = "SELECT SUM(SL_TT*ABS(A.DON_GIA - ISNULL(T.DON_GIA,0))) AS TONG_CP_PT, SUM(SL_TT*ABS(A.DON_GIA - ISNULL(T.DON_GIA,0))*TI_GIA_USD/TI_GIA) AS TONG_CP_PT_USD  FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO A INNER JOIN IC_PHU_TUNG B ON A.MS_PT = B.MS_PT  
INNER JOIN LOAI_VT C ON B.MS_LOAI_VT = C.MS_LOAI_VT LEFT JOIN (SELECT MS_PT,DON_GIA FROM dbo.IC_DON_HANG_NHAP_VAT_TU WHERE MS_DH_NHAP_PT in
(SELECT MS_DH_NHAP_PT FROM dbo.IC_DON_HANG_NHAP WHERE MS_DH_XUAT_PT IN (SELECT MS_DH_XUAT_PT   FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "'))) AS T ON T.MS_PT = B.MS_PT WHERE MS_PHIEU_BAO_TRI= '" & Me.txtMaSoPBT.Text & "' AND SL_TT IS NOT NULL AND SL_TT > 0 AND VAT_TU = 0 "
            Else
                sSql = "EXEC SP_NHU_Y_GET_CHI_PHI_VT_PT_KHONG_SD_KHO '" & Me.txtMaSoPBT.Text & "',0"
            End If

            ''kiểm tra phiếu xuất tái xuất được lock chưa
            Try
                dtTmp = New DataTable
                dtTmp = TB_PHU_TUNG_THAY_THE_CHI_TIET.AsEnumerable().Where(Function(x) x.Field(Of String)("MS_DH_NHAP_TC").Trim() <> "").CopyToDataTable()
                If dtTmp.Rows.Count > 0 Then
                    If Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 LOCK FROM  dbo.IC_DON_HANG_NHAP WHERE MS_DH_NHAP_PT = '" + dtTmp.Rows(0)("MS_DH_NHAP_TC") + "'")) = 0 Then
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgSL_PNTC_CHUA_LOCK", TypeLanguage) & vbCrLf & dtTmp.Rows(0)("MS_DH_NHAP_TC").ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If
            Catch ex As Exception
            End Try

            'kiểm tra phụ tùng xuất có phải là phụ tùng tái sử dụng nếu có thì cho lên form nhập tái sử dụng từ phiếu bảo trì
            If Not KiemtraPhuTungTaiSuDung() Then
                Return False
            End If

            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            While dtReader.Read
                CHI_PHI_PHU_TUNG = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
                CHI_PHI_PHU_TUNG_USD = IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
            End While
            dtReader.Close()
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI_CHI_PHI", Me.txtMaSoPBT.Text, CHI_PHI_PHU_TUNG, CHI_PHI_PHU_TUNG_USD, CHI_PHI_VAT_TU, CHI_PHI_VAT_TU_USD, CHI_PHI_NHAN_CONG, CHI_PHI_NHAN_CONG_USD, CHI_PHI_DV, CHI_PHI_DV_USD)
            Catch ex As Exception
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI_CHI_PHI", Me.txtMaSoPBT.Text, CHI_PHI_PHU_TUNG, CHI_PHI_PHU_TUNG_USD, CHI_PHI_VAT_TU, CHI_PHI_VAT_TU_USD, CHI_PHI_NHAN_CONG, CHI_PHI_NHAN_CONG_USD, CHI_PHI_DV, CHI_PHI_DV_USD)
            End Try
            'Nghiem thu tinh trang = 4
            Dim objPBT As New clsPHIEU_BAO_TRIController()
            objPBT.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 4)
            CapNhapPBTCT(4)
            If iLoaiGoiMail <> 0 Then
                If Commons.Modules.sPrivate = "REMINGTON" Then
                    GoiMailHoanThanhNT(True)
                Else
                    XacNhanHTPBT(txtMaSoPBT.Text)
                End If
            End If
            Dim MS_PBT As String = txtMaSoPBT.Text
            optNTHT.SelectedIndex = 3
            For J As Integer = 0 To grvDanhSach_1.RowCount - 1
                If grvDanhSach_1.GetRowCellValue(J, "MS_PHIEU_BAO_TRI") = MS_PBT Then
                    grvDanhSach_1.FocusedRowHandle = J
                    intRowPBT = J
                    ShowData()
                    Exit For
                End If
            Next
            bHuyNT = 2
            BindDataThongTinChiPhi(Me.txtMaSoPBT.Text)
            cboTinhTrangPBT.SelectedValue = 4
            LoadTongGioCong(txtMaSoPBT.Text, cboTinhTrangPBT.SelectedValue)
            LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
            LoadNgayKetThucBaoTri(txtMaSoPBT.Text, cboTinhTrangPBT.SelectedValue)
            BtnXacnhanNT.Enabled = False
            btnXoaPBTK.Enabled = False
            btnHThanhNT.Enabled = False
            ucCongViecNS.btnHThanhNS.Enabled = False
            BindData5()
            sSql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI=N'" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            sSql = "UPDATE [PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET] SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI=N'" & txtMaSoPBT.Text & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            sSql = "UPDATE PHIEU_BAO_TRI_NHAN_SU SET HOAN_THANH = 1 WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            Return True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
        End Try
    End Function
#End Region

#Region "Khoa PBT"
    Function KhoaPBT() As Boolean

        If cboTinhTrangPBT.SelectedValue <> 4 Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgPBTChuaNT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If cboTinhTrangPBT.SelectedValue = 4 Then
            If ObjSystems.MGetQuyenChucNang(UserName, 9) Then
                If (XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhoaPBT", TypeLanguage), Me.Text, MessageBoxButtons.YesNo)) = DialogResult.Yes Then
                    Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                    objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 5)
                    Dim objReader1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHinhThucBT", cboLoaiBT.EditValue)
                    Try
                        While objReader1.Read
                            If objReader1.Item("MS_HT_BT") = 1 Then
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN", cboMAY.EditValue, cboLoaiBT.EditValue, Format(dtNgayBDKH1.DateTime, "Short date"))
                            End If
                        End While
                        objReader1.Close()
                    Catch ex As Exception
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN", cboMAY.EditValue, cboLoaiBT.EditValue, Format(dtNgayBDKH1.DateTime, "Short date"))
                    End Try
                    Dim str = txtMaSoPBT.Text
                    BindData()
                    For i As Integer = 0 To grvDanhSach_1.RowCount - 1
                        If grvDanhSach_1.GetRowCellValue(i, "MS_PHIEU_BAO_TRI") = str Then
                            grvDanhSach_1.FocusedRowHandle = i
                            intRowPBT = i
                            ShowData()
                            Exit For
                        End If
                    Next
                Else
                    Return False
                End If


                If PermisString.Equals("Read only") Then
                    EnableButton(False)
                Else
                    If cboTinhTrangPBT.SelectedValue < 5 Then
                        EnableButton(True)
                        If optNTHT.SelectedIndex = 0 Or optNTHT.SelectedIndex = 1 Then
                            If cboTinhTrangPBT.SelectedValue = 2 Or cboTinhTrangPBT.SelectedValue = 3 Then
                                BtnDuyetPBT.Enabled = False
                            Else
                                BtnDuyetPBT.Enabled = True
                            End If

                        Else
                            BtnDuyetPBT.Enabled = False
                        End If
                    Else
                        EnableButton(False)
                    End If
                End If

                Return True
            Else
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgLockPBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        Else
            Return False
        End If
    End Function

#End Region

#Region "Kiem nghiem Thu"
    Private Function KiemNghiemThu() As Boolean
        If Not ObjSystems.MGetQuyenChucNang(UserName, 55) Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBanKhongCoQuyenUnLockPBT", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgBanCoMuonBoLockPhieuBaoTri", TypeLanguage), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return False
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim sSql As String = " UPDATE PHIEU_BAO_TRI SET TINH_TRANG_PBT = 4 WHERE MS_PHIEU_BAO_TRI = N'" + txtMaSoPBT.Text + "'  "

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Dim i As Integer = grvDanhSach_1.FocusedRowHandle()
            BindData()
            Dim str As String = ""
            str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
        " WHERE USERNAME='" & UserName & "' AND CHUC_NANG.STT=8 "
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                If objReader.Item("STT").ToString <> "" Then
                    bCoQuyen = True
                End If
            End While
            objReader.Close()
            If Not bCoQuyen Then
                TinhtrangPBT_Lock(False)
            End If
            If PermisString.Equals("Read only") Then
                TinhtrangPBT_Lock(False)
            Else
                If optNTHT.SelectedIndex = 2 Then
                    btnIn_1.Enabled = True
                    btnThem_1.Enabled = False
                    btnXoaPBTK.Enabled = False
                Else
                    btnIn_1.Enabled = True ' False
                    btnThem_1.Enabled = True
                    btnXoaPBTK.Enabled = True
                End If
            End If

            If optNTHT.SelectedIndex = 0 Then
                btnInPBT.Enabled = True
            Else
                btnInPBT.Enabled = False
            End If

            grvDanhSach_1.FocusedRowHandle = i

            Me.Cursor = Cursors.Default
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgUnlockThanhCong", TypeLanguage))
            Return True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "msgUnlockKhongThanhCong", TypeLanguage))
            Return False
        End Try

    End Function



    Private Sub btnMucUuTien_Click(sender As Object, e As EventArgs) Handles btnMucUuTien.Click

        Try
            Dim Str As String = "SELECT ISNULL(SO_NGAY_PHAI_BD, 0) AS SO_NGAY_PHAI_BD ,  ISNULL(SO_NGAY_PHAI_KT, 0) AS SO_NGAY_PHAI_KT FROM MUC_UU_TIEN WHERE MS_UU_TIEN = " & cboMucUuTien1.EditValue '.SelectedValue
            Dim dt As New DataTable(), dt1 As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))
            'dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetLoaiBaoTriHinhThuc", cboMAY.EditValue))
            'dt1.DefaultView.RowFilter = "MS_LOAI_BT = " & cboLoaiBT.EditValue
            'dt1 = dt1.DefaultView.ToTable()
            If (cboLoaiBT.GetColumnValue("PHONG_NGUA") = "1") Then
                dtNgayBDKH1.DateTime = dtNgayLap1.DateTime.AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
                dtNgayKTKH1.DateTime = dtNgayLap1.DateTime.AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
            End If
        Catch ex As Exception
            dtNgayBDKH1.DateTime = dtNgayLap1.DateTime
            dtNgayKTKH1.DateTime = dtNgayLap1.DateTime
        End Try

    End Sub

    Private Sub FrmPhieuBaoTri_New_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        TableLayoutPanel2.ColumnStyles(10).Width = 23
        TableLayoutPanel2.ColumnStyles(14).Width = 21

        TableLayoutPanel2.ColumnStyles(10).SizeType = SizeType.Absolute
        TableLayoutPanel2.ColumnStyles(14).SizeType = SizeType.Absolute
    End Sub

    Private Sub dtKTTT1_CloseUp(sender As Object, e As Controls.CloseUpEventArgs) Handles dtKTTT1.CloseUp
        Try
            If (dtKTTT1.EditValue = e.Value) Then
                Exit Sub
            End If
            txtNgayhong.Text = e.Value
            txtNgayhong.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtDenKTTT1_CloseUp(sender As Object, e As Controls.CloseUpEventArgs) Handles dtDenKTTT1.CloseUp
        Try
            If (dtDenKTTT1.EditValue = e.Value) Then
                Exit Sub
            End If
            txtDenNgayHong.Text = e.Value
            txtDenNgayHong.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Try
            Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
            If info.InRow OrElse info.InRowCell Then
                If info.Column.FieldName <> "MS_YEU_CAU" Then
                    Return
                Else
                    If (IsDBNull(grvDanhSach_1.GetFocusedDataRow()("MS_YEU_CAU"))) Then Exit Sub
                    If (grvDanhSach_1.GetFocusedDataRow()("MS_YEU_CAU").ToString().Contains(",")) Then
                        Dim menu As New ContextMenuStrip()
                        Dim dtTable As New DataTable
                        Dim spl As String() = grvDanhSach_1.GetFocusedDataRow()("MS_YEU_CAU").ToString().Split(",")
                        For i As Integer = 0 To spl.Length - 1
                            menu.Items.Add(spl(i).Trim())
                            AddHandler menu.Items(i).Click, AddressOf Me.menu_Click
                        Next
                        menu.Show(GetLocation(grdDanhSach_1, pt, menu))
                    ElseIf (grvDanhSach_1.GetFocusedDataRow()("MS_YEU_CAU").ToString().Contains("WR")) Then
                        Dim str As String = "SELECT TOP 1 STT FROM YEU_CAU_NSD WHERE MS_YEU_CAU = '" & grvDanhSach_1.GetFocusedDataRow()("MS_YEU_CAU").ToString() & "' ORDER BY NGAY, GIO_YEU_CAU DESC"
                        Dim dt As New DataTable()
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

                        Dim frm As New MVControl.frmShowThongTinYCNSD()
                        frm.MS_MAY = grvDanhSach_1.GetFocusedDataRow()("MS_MAY").ToString()
                        frm.STT = dt.Rows(0)("STT")
                        frm.MS_PBT = grvDanhSach_1.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString()
                        frm.STT_VAN_DE = -1
                        frm.StartPosition = FormStartPosition.CenterParent
                        frm.ShowDialog()
                        'ShowPanel(dt.Rows(0)("STT"))
                    End If

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub menu_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim str As String = "SELECT TOP 1 STT FROM YEU_CAU_NSD WHERE MS_YEU_CAU = '" & CType(sender, ToolStripMenuItem).Text & "' ORDER BY NGAY, GIO_YEU_CAU DESC"
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            Dim frm As New MVControl.frmShowThongTinYCNSD()
            frm.MS_MAY = grvDanhSach_1.GetFocusedDataRow()("MS_MAY").ToString()
            frm.STT = dt.Rows(0)("STT")
            frm.MS_PBT = grvDanhSach_1.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString()
            frm.STT_VAN_DE = -1
            frm.StartPosition = FormStartPosition.CenterParent

            frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Function GetLocation(ByVal gr As DevExpress.XtraGrid.GridControl, ByVal mousePosition As Point, ByVal menu As ContextMenuStrip)
        If (gr Is Nothing) Then Return mousePosition
        Return gr.PointToScreen(New Point(mousePosition.X - menu.Size.Width, mousePosition.Y))
    End Function


    Private Sub grvDanhSach_1_DoubleClick(sender As Object, e As EventArgs) Handles grvDanhSach_1.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowDoubleClick(view, pt)
    End Sub
    Private Sub grvDanhSach_1_MouseUp(sender As Object, e As MouseEventArgs) Handles grvDanhSach_1.MouseUp
        Try
            If (e.Button <> MouseButtons.Right) Then Return
            Dim view As GridView = CType(sender, GridView)
            Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

            Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
            If info.InRow OrElse info.InRowCell Then
                If info.Column.FieldName <> "TEN_TINH_TRANG" Then
                    Return
                Else
                    menuTinhTrangPBTCT.Show(GetLocation(grdDanhSach_1, pt, menuTinhTrangPBTCT))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CapNhapPBTCT(iTinhTrang As Integer)
        Try
            Dim iTTChiTiet As Integer
            Dim sSql As String
            sSql = "SELECT TOP 1 MS_TT_CT FROM TINH_TRANG_PBT_CT WHERE MAC_DINH = 1 AND STT = " & iTinhTrang.ToString()
            iTTChiTiet = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spPBTTinhTrangChiTiet", txtMaSoPBT.Text, iTTChiTiet, "", UserName, Now)
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Function InputBoxTTPBT(title As String, promptText As String, ByRef value As String) As DialogResult
        Dim form As New Form()
        Dim label As New Label()
        Dim textBox As New TextBox()
        Dim buttonCancel As New Button()

        form.Text = title
        label.Text = promptText
        textBox.Text = value

        buttonCancel.Text = "OK"
        buttonCancel.DialogResult = DialogResult.OK

        label.SetBounds(9, 20, 372, 13)
        textBox.SetBounds(12, 36, 372, 20)

        buttonCancel.SetBounds(309, 72, 75, 23)

        label.AutoSize = True
        textBox.Anchor = textBox.Anchor Or AnchorStyles.Right

        buttonCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right

        form.ClientSize = New Size(396, 107)
        form.Controls.AddRange(New Control() {label, textBox, buttonCancel})
        form.ClientSize = New Size(Math.Max(300, label.Right + 10), form.ClientSize.Height)
        form.FormBorderStyle = FormBorderStyle.FixedDialog
        form.StartPosition = FormStartPosition.CenterScreen
        form.MinimizeBox = False
        form.MaximizeBox = False

        form.AcceptButton = buttonCancel
        Commons.Modules.ObjSystems.ThayDoiNN(form)
        Dim dialogResult__1 As DialogResult = form.ShowDialog()
        value = textBox.Text
        Return dialogResult__1
    End Function

    Private bHuyNT As Byte = 0
    Private bHuyHT As Byte = 0

    Private Sub TabPhieuBaoTri_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabPhieuBaoTri.SelectedPageChanged
        If (SQLString = "0LOAD") Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If txtMaSoPBT.Text = "" And grvDanhSach_1.RowCount > 0 Then
            Try
                grvDanhSach_1.SelectRow(0)
                grvDanhSach_1_FocusedRowChanged(Nothing, Nothing)
            Catch ex As Exception
            End Try
        End If
        Try
            If Not PermisString.Equals("Read only") Then
                If TabPhieuBaoTri.SelectedTabPage.Name = "tabTTBT" Then
                    Try
                        LoadTTBT(txtMaSoPBT.Text)
                    Catch ex As Exception
                        LoadTTBT("-1")
                    End Try
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                If cboTinhTrangPBT.SelectedValue = 4 Then
                    BtnKhoaPBT.Enabled = True
                Else
                    BtnKhoaPBT.Enabled = False
                End If
            End If



            If PermisString.Equals("Read only") Then
                EnableButton(False)
            Else
                If cboTinhTrangPBT.SelectedValue < 5 Then
                    EnableButton(True)
                    If optNTHT.SelectedIndex = 0 Or optNTHT.SelectedIndex = 1 Then
                        If cboTinhTrangPBT.SelectedValue = 2 Then
                            BtnDuyetPBT.Enabled = False
                        Else
                            BtnDuyetPBT.Enabled = True
                        End If

                    Else
                        BtnDuyetPBT.Enabled = False
                    End If
                Else
                    EnableButton(False)

                    BtnXacnhanNT.Enabled = False
                End If
            End If

            If TabPhieuBaoTri.SelectedTabPage.Name = "tabPBTTinhTrang" Then
                TaoLuoiPBTCT(-1)
                If PermisString.Equals("Read only") Then
                    btnThemPBTTT.Visible = False
                    btnXoaPBTTT.Visible = False
                End If
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If TabPhieuBaoTri.SelectedTabPage.Name = "tabPHTT" Then
                LoadLuoiPHTT(txtMaSoPBT.Text, -1)
                If cboTinhTrangPBT.SelectedValue = 5 Then
                    btnThemPHTT.Enabled = False
                    btnSuaPHTT.Enabled = False
                    btnXoaPHTT.Enabled = False
                Else
                    btnThemPHTT.Enabled = True
                    btnSuaPHTT.Enabled = True
                    btnXoaPHTT.Enabled = True
                End If
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If TabPhieuBaoTri.SelectedTabPage.Name = "tabYeuCauBT" Then
                LoadYCNSD(txtMaSoPBT.Text)
                If PermisString.Equals("Read only") Then
                    btnThemSuaYCBT.Enabled = False
                    btnXoaYCBT.Enabled = False
                Else
                    If KiemPQ(1) = False Then
                        btnThemSuaYCBT.Enabled = False
                        btnXoaYCBT.Enabled = False
                    Else

                        If cboTinhTrangPBT.SelectedValue = 5 Then
                            btnThemSuaYCBT.Enabled = False
                            btnXoaYCBT.Enabled = False
                        Else
                            btnThemSuaYCBT.Enabled = True
                            btnXoaYCBT.Enabled = True
                        End If
                    End If
                End If
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If TabPhieuBaoTri.SelectedTabPage.Name = "tabNguoiGiamSat" Then
                LoadNGS(txtMaSoPBT.Text, "-1")
                If PermisString.Equals("Read only") Then
                    btnThemSuaNGS.Enabled = False
                    btnXoaNGS.Enabled = False
                Else

                    If cboTinhTrangPBT.SelectedValue = 5 Then
                        btnThemSuaNGS.Enabled = False
                        btnXoaNGS.Enabled = False
                    Else
                        btnThemSuaNGS.Enabled = True
                        btnXoaNGS.Enabled = True
                    End If
                End If
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            If bThem <> -1 Then

            Else
                If TabPhieuBaoTri.SelectedTabPageIndex = 0 Then
                    If bHuyNT > 0 Then
                        Dim tmpPBT As String = Me.txtMaSoPBT.Text
                        If bHuyNT = 1 Then
                            optNTHT.SelectedIndex = 1
                        Else
                            optNTHT.SelectedIndex = 2
                        End If
                        BindData()
                        For j As Integer = 0 To grvDanhSach_1.RowCount - 1
                            If grvDanhSach_1.GetRowCellValue(j, "MS_PHIEU_BAO_TRI") = tmpPBT Then
                                Try
                                    grvDanhSach_1.FocusedRowHandle = j
                                Catch ex As Exception
                                End Try
                                Exit For
                            End If
                        Next
                        bHuyNT = 0
                    End If
                    If bHuyHT > 0 Then
                        Dim tmpPBT As String = Me.txtMaSoPBT.Text
                        If bHuyHT = 1 Then
                            optNTHT.SelectedIndex = 0
                        Else
                            optNTHT.SelectedIndex = 1
                        End If
                        BindData()
                        For j As Integer = 0 To grvDanhSach_1.RowCount - 1
                            If grvDanhSach_1.GetRowCellValue(j, "MS_PHIEU_BAO_TRI") = tmpPBT Then
                                Try
                                    grvDanhSach_1.FocusedRowHandle = j
                                Catch ex As Exception
                                End Try
                                Exit For
                            End If
                        Next
                        bHuyHT = 0
                    End If
                ElseIf TabPhieuBaoTri.SelectedTabPageIndex = 1 Then
                    If tabCViec.SelectedTabPageIndex = 0 Then
                        ucCongViecPBT.iTTPBTri = cboTinhTrangPBT.SelectedValue
                        If (ucCongViecPBT.sMsPBT <> txtMaSoPBT.Text) Then
                            ucCongViecPBT.sMsMay = cboMAY.EditValue
                            ucCongViecPBT.sMsPBT = txtMaSoPBT.Text
                            ucCongViecPBT.isSynData = isSynData
                            ucCongViecPBT._SynConnectionInfo = _SynConnectionInfo
                            ucCongViecPBT.LoadFormCVPBT()
                            ucCongViecPBT.LoadCongViec()
                        End If
                        ucCongViecPBT.DieuKhienNutSyn()
                    ElseIf tabCViec.SelectedTabPageIndex = 1 Then
                        ucCVPTro.iTTPBTri = cboTinhTrangPBT.SelectedValue
                        If (ucCVPTro.sMsPBT <> txtMaSoPBT.Text) Then
                            ucCVPTro.sMsPBT = txtMaSoPBT.Text
                            ucCongViecPBT.DieuKhienNutSyn()
                            If cboTinhTrangPBT.SelectedValue > 4 Then
                                ucCVPTro.btnThemSua.Enabled = False
                                ucCVPTro.btnXoa.Enabled = False
                            Else
                                ucCVPTro.btnThemSua.Enabled = True
                                ucCVPTro.btnXoa.Enabled = True
                            End If
                            ucCVPTro.LoadPBTCVPhuTro(-1)
                            If PermisString.Equals("Read only") Then
                                ucCVPTro.btnThemSua.Enabled = False
                                ucCVPTro.btnXoa.Enabled = False
                            End If
                        End If
                    End If
                    CreateMenuCV(ucCongViecPBT.grdCongviec)
                    CreateMenuPT(ucCongViecPBT.grdPhuTung)
                    CreateMenuPT(ucCVPTro.grdVTu)
                Else
                    If TabPhieuBaoTri.SelectedTabPageIndex = 2 Then
                        Try
                            ucCongViecNS.ngayBDKH = dtNgayBDKH1.DateTime.Date
                            ucCongViecNS.ngayKTKH = dtNgayKTKH1.DateTime.Date
                            Try
                                ucCongViecNS.tuNgayGioHong = Convert.ToDateTime(txtNgayhong.Text + " " + txtGiohong.Text)
                                ucCongViecNS.denNgayGioHong = Convert.ToDateTime(txtDenNgayHong.Text + " " + txtDenGioHong.Text)

                            Catch ex As Exception
                                ucCongViecNS.tuNgayGioHong = Convert.ToDateTime("1900/01/01 00:00:00")
                                ucCongViecNS.denNgayGioHong = Convert.ToDateTime("1900/01/01 00:00:00")
                            End Try
                            ucCongViecNS.iTTPBTri = cboTinhTrangPBT.SelectedValue
                            Commons.Modules.SQLString = ""
                            'If (ucCongViecNS.sMsPBT <> txtMaSoPBT.Text) Then
                            ucCongViecNS.bLoadNS = True
                                ucCongViecNS.sMsPBT = txtMaSoPBT.Text
                                If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 0 Then
                                    ucCongViecNS.LoadCongViecChinhNS()
                                Else
                                    ucCongViecNS.LoadCongViecPhuNS()
                                End If
                                ucCongViecNS.KiemLoadCV()
                                ucCongViecNS.bLoadNS = False
                                If Commons.Modules.sPrivate <> "GREENFEED" Then
                                    CreateMenuNhanSu(ucCongViecNS.grdCVChinhNS)
                                    CreateMenuNhanSu(ucCongViecNS.grdCVPhuNS)
                                End If

                            'End If

                        Catch ex As Exception
                        End Try
                    Else
                        If TabPhieuBaoTri.SelectedTabPageIndex = 3 Then
                            ucDichVu.iTTPBTri = cboTinhTrangPBT.SelectedValue
                            If (ucDichVu.sMsPBT <> txtMaSoPBT.Text) Then
                                ucDichVu.sMsPBT = txtMaSoPBT.Text
                                ucDichVu.sMsMay = cboMAY.EditValue
                                ucDichVu.LoadDichVu()
                                CreateMenuPT(ucDichVu.grdPhuTung)
                            End If
                        Else
                            If TabPhieuBaoTri.SelectedTabPageIndex = 4 Then
                                BindData5()
                                LoadNgayBatDauBaoTri(Me.txtMaSoPBT.Text)
                                LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
                                LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
                                If cboTinhTrangPBT.SelectedValue = 5 Or (optNTHT.SelectedIndex = 2 And bCoQuyen = False) Then
                                    EnableButton5(False)
                                Else
                                    EnableButton5(True)
                                    If cboTinhTrangPBT.SelectedValue = 4 Then
                                        BtnXacnhanNT.Enabled = False
                                        btnXoa_1.Enabled = False
                                        btnHThanhNT.Enabled = False
                                    Else
                                        btnXoa_1.Enabled = True
                                    End If

                                    If cboTinhTrangPBT.SelectedValue = 3 Then
                                        btnHThanhNT.Enabled = False
                                    End If

                                End If
                                If sPrivate = "BARIA" Then btnPhanBoLai.Visible = True Else btnPhanBoLai.Visible = False
                                '  End If

                            Else
                                If TabPhieuBaoTri.SelectedTabPage.Equals(tabHechuyengia) Then
                                    If txtMaSoPBT.Text.Trim.Length > 0 Then
                                        'If (txtMaSoPBT.Text.Trim() <> msPBT_Old) Then
                                        LoadHCG()
                                        LoadBophan()
                                        EnableButtonClass(True)
                                        ReadOnlyControl(True)
                                        If cboTinhTrangPBT.SelectedValue >= 5 Then
                                            btnThemClass.Enabled = False
                                            btnSuaClass.Enabled = False
                                            btnXoaClass.Enabled = False
                                        Else
                                            If Not tvwCautrucTB1.FocusedNode("MS_BO_PHAN") Is Nothing Then
                                                If tvwCautrucTB1.FocusedNode("MS_BO_PHAN") = cboMAY.EditValue() Or cboTinhTrangPBT.SelectedValue >= 5 Then
                                                    btnXoaClass.Enabled = False
                                                    btnSuaClass.Enabled = False
                                                    btnThemClass.Enabled = False
                                                Else
                                                    btnThemClass.Enabled = True
                                                End If
                                            Else
                                                btnThemClass.Enabled = True
                                            End If
                                            If Not PermisString.Equals("Read only") Then
                                                If grvProblem.RowCount <= 0 Then
                                                    btnXoaClass.Enabled = False
                                                    btnSuaClass.Enabled = False
                                                Else
                                                    btnXoaClass.Enabled = True
                                                    btnSuaClass.Enabled = True
                                                End If
                                            Else
                                                btnXoaClass.Enabled = False
                                                btnSuaClass.Enabled = False
                                                btnThemClass.Enabled = False
                                            End If
                                        End If
                                    Else
                                        btnThemClass.Enabled = False
                                        btnSuaClass.Enabled = False
                                        btnXoaClass.Enabled = False
                                        btnGhiClass.Enabled = False
                                        btnKhongghiClass.Enabled = False
                                        ReadOnlyControl(True)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                If PermisString.Equals("Read only") Then
                    If TabPhieuBaoTri.SelectedTabPageIndex <> 4 Then EnableButton(False)
                Else
                    If cboTinhTrangPBT.SelectedValue < 5 Then
                        EnableButton(True)
                        If optNTHT.SelectedIndex = 0 Or optNTHT.SelectedIndex = 1 Then
                            If cboTinhTrangPBT.SelectedValue = 2 Or cboTinhTrangPBT.SelectedValue = 3 Then
                                BtnDuyetPBT.Enabled = False
                            Else
                                BtnDuyetPBT.Enabled = True
                            End If
                        Else
                            BtnDuyetPBT.Enabled = False
                        End If
                        If cboTinhTrangPBT.SelectedValue = 4 Then
                            BtnKhoaPBT.Enabled = True
                            BtnXacnhanNT.Enabled = False
                        Else
                            BtnKhoaPBT.Enabled = False
                        End If
                    Else
                        EnableButton(False)
                    End If
                End If
            End If

            If Not PermisString.Equals("Read only") Then
                If cboTinhTrangPBT.SelectedValue < 5 Then
                    If cboTinhTrangPBT.SelectedValue = 3 Then
                        btnHThanhNT.Enabled = False
                        ucCongViecNS.btnHThanhNS.Enabled = False
                    End If
                    If cboTinhTrangPBT.SelectedValue = 4 Then
                        BtnXacnhanNT.Enabled = False
                        btnXoa_1.Enabled = False
                        btnHThanhNT.Enabled = False
                    End If

                End If
                If cboTinhTrangPBT.SelectedValue = 4 Then
                    BtnKhoaPBT.Enabled = True
                Else
                    BtnKhoaPBT.Enabled = False
                End If

                If TabPhieuBaoTri.SelectedTabPage.Name = "tabJobcard" Then
                    If cboTinhTrangPBT.SelectedValue < 4 Then
                        ucCongViecNS.btnThemsua.Enabled = True
                        ucCongViecNS.btnXoa.Enabled = True
                        ucCongViecNS.btnHThanhNS.Enabled = True
                        ucCongViecNS.btnTinhcuasobaotri.Enabled = True
                        'btnSaoChep.Enabled = True
                        If cboTinhTrangPBT.SelectedValue = 3 Then
                            ucCongViecNS.btnHThanhNS.Enabled = False
                        End If
                    Else
                        ucCongViecNS.btnThemsua.Enabled = False
                        ucCongViecNS.btnXoa.Enabled = False
                        ucCongViecNS.btnHThanhNS.Enabled = False
                        ucCongViecNS.btnTinhcuasobaotri.Enabled = False
                        'btnSaoChep.Enabled = False

                    End If

                End If
            End If

            intRowPBT = grvDanhSach_1.FocusedRowHandle

            btnAllocate.Visible = False
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'XtraMessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtDNgay_1_EditValueChanged(sender As Object, e As EventArgs) Handles dtDNgay_1.EditValueChanged
        If SQLString = "0Load" Then Exit Sub
        intRowPBT = grvDanhSach_1.FocusedRowHandle
        BindData()
        ShowData()
    End Sub

    Private Sub dtTNgay_1_EditValueChanged(sender As Object, e As EventArgs) Handles dtTNgay_1.EditValueChanged
        If SQLString = "0Load" Then Exit Sub
        intRowPBT = grvDanhSach_1.FocusedRowHandle
        BindData()
        ShowData()
    End Sub

    Private Sub txtTimKiemPBT_TextChanged(sender As Object, e As EventArgs) Handles txtTimKiemPBT.TextChanged
        Dim dtTmp As New DataTable
        dtTmp = CType(grdDanhSach_1.DataSource, DataTable)
        If (dtTmp Is Nothing) Then Exit Sub
        Try
            dtTmp.DefaultView.RowFilter = "MS_PHIEU_BAO_TRI like '%" + txtTimKiemPBT.Text + "%' OR SO_PHIEU_BAO_TRI like '%" + txtTimKiemPBT.Text + "%'  OR MS_MAY like '%" + txtTimKiemPBT.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
            intRowPBT = grvDanhSach_1.FocusedRowHandle
            ShowData()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub

    Private Sub txtTimKiemPBT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTimKiemPBT.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub

        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grdDanhSach_1.DataSource, DataTable)
            If (Not dtTmp Is Nothing) Then
                dtTmp.DefaultView.RowFilter = "MS_PHIEU_BAO_TRI like '%" + txtTimKiemPBT.Text + "%'"
                dtTmp = dtTmp.DefaultView.ToTable()
            End If
        Catch ex As Exception
            If (Not dtTmp Is Nothing) Then
                dtTmp.DefaultView.RowFilter = ""
                dtTmp = dtTmp.DefaultView.ToTable()
            End If
        End Try



        Try
            If dtTmp Is Nothing Then GoTo 1
            If dtTmp.Rows.Count = 0 Or dtTmp Is Nothing Then
1:
                dtTmp = New DataTable()

                SQLString = "0LOAD"
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get1PBT", UserName, txtTimKiemPBT.Text))
                If dtTmp.Rows.Count > 0 Then
                    'dtTuNgay_1.Value = dtTmp.Rows(0)("NGAY_BD_KH")
                    dtTNgay_1.EditValue = dtTmp.Rows(0)("NGAY_BD_KH")
                    'dtDenNgay_1.Value = dtTmp.Rows(0)("NGAY_BD_KH")
                    dtDNgay_1.EditValue = dtTmp.Rows(0)("NGAY_BD_KH")

                    If dtTmp.Rows(0)("TINH_TRANG_PBT") < 3 Then
                        optNTHT.SelectedIndex = 0
                    Else
                        If dtTmp.Rows(0)("TINH_TRANG_PBT") = 3 Then
                            optNTHT.SelectedIndex = 1
                        Else
                            optNTHT.SelectedIndex = 2

                        End If
                    End If
                    SQLString = ""
                    BindData()
                    txtTimKiemPBT_TextChanged(sender, e)
                End If

            End If
        Catch ex As Exception
            txtTimKiemPBT_TextChanged(sender, e)
        End Try

        intRowPBT = grvDanhSach_1.FocusedRowHandle
        ShowData()

        SQLString = ""
        'grdDanhSach_1.DataSource = dtTmp

    End Sub
    Private Sub cboCa_EditValueChanged(sender As Object, e As EventArgs) Handles cboCa.EditValueChanged
        If cboCa.EditValue.ToString() = "10000" Then
            Try
                Dim frm As Report1.frmCa = New Report1.frmCa()
                If ObjSystems.check_permission(UserName, frm.Name) Then
                    frm.StartPosition = FormStartPosition.CenterParent
                    frm.ShowDialog()

                    Dim dt As New DataTable()
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT, (CASE " & TypeLanguage & " WHEN 0 THEN CA ELSE CA_ANH END) + ' (' + CONVERT(NVARCHAR(5),CAST(TU_GIO AS TIME),108) + ' - ' +  CONVERT(NVARCHAR(5),CAST(DEN_GIO AS TIME),108) + ')' AS TEN_CA FROM CA ORDER BY TU_GIO, DEN_GIO"))

                    Dim dr As DataRow = dt.NewRow()


                    dr("STT") = "10000"
                    dr("TEN_CA") = "...New..."
                    dt.Rows.Add(dr)

                    cboCa.Properties.DataSource = Nothing
                    cboCa.Properties.DataSource = dt
                    cboCa.Properties.DisplayMember = "TEN_CA"
                    cboCa.Properties.ValueMember = "STT"
                    cboCa.Properties.PopulateColumns()
                    cboCa.Properties.Columns("STT").Visible = False
                    cboCa.Properties.Columns("TEN_CA").Caption = ObjLanguages.GetLanguage(ModuleName, "frmCa", "lblTenCa", TypeLanguage)


                    cboCa.EditValue = -1



                End If

            Catch ex As Exception

            End Try
            PermisString = ObjGroups.GetNHOM_FORM_QUYEN(UserName, "FrmPhieuBaoTri_New")
        End If
    End Sub
    Private Sub cboNguyenNhan_EditValueChanged(sender As Object, e As EventArgs) Handles cboNguyenNhan.EditValueChanged
        If Not cboNguyenNhan.Enabled Then Exit Sub

        If cboNguyenNhan.EditValue.ToString() = "10000" Then
            Try


                Dim frm As Report1.frmNguyenNhanDungMay = New Report1.frmNguyenNhanDungMay()
                If ObjSystems.check_permission(UserName, frm.Name) Then
                    frm.baotri = "test"
                    frm.ShowDialog()
                    LoadNguyenNhan()
                    Try
                        cboNguyenNhan.EditValue = Convert.ToInt32(frm.baotri)
                    Catch ex As Exception
                        cboNguyenNhan.EditValue = -1

                    End Try

                End If

            Catch ex As Exception

            End Try
            PermisString = ObjGroups.GetNHOM_FORM_QUYEN(UserName, "FrmPhieuBaoTri_New")
        End If
    End Sub

    Private Sub TabPhieuBaoTri_SelectedPageChanging(sender As Object, e As DevExpress.XtraTab.TabPageChangingEventArgs) Handles TabPhieuBaoTri.SelectedPageChanging
        If (SQLString = "0LOAD") Then Exit Sub
        'kiểm tra nếu 2 mã khác nhau thì không cho chuyển tab
        'If txtMaSoPBT.EditValue.ToString().Trim() = "" And optNTHT.SelectedIndex <> -1 And optNTHT.SelectedIndex <> 0 Then
        '    e.Cancel = True
        '    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmMain", "msgChuaChonPBT", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If

        If btnGhi_1.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If ucCongViecPBT.btnGhi.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If ucCongViecNS.btnGhi.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If ucDichVu.btnGhiDanhGia.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If ucDichVu.btnGhi.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhi5.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhiClass.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If

        If btnGhiPHTT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhiYCBT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhiNGS.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhiTTBT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhiPBTTT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If ucCVPTro.btnGhi.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub cboLoaiBT_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaiBT.EditValueChanged
        If (SQLString = "0Load") Then Exit Sub
        If (btnGhi_1.Visible = False) Then Exit Sub
        If (cboLoaiBT.EditValue = Nothing) Then Exit Sub
        If (cboLoaiBT.EditValue.ToString() = "-1") Then Exit Sub
        Dim iPNgua As Boolean = False
        Try
            iPNgua = Boolean.Parse(cboLoaiBT.GetColumnValue("PHONG_NGUA").ToString())
        Catch ex As Exception
            iPNgua = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT PHONG_NGUA FROM HINH_THUC_BAO_TRI T1 INNER JOIN LOAI_BAO_TRI T2 ON T1.MS_HT_BT = T2.MS_HT_BT WHERE MS_LOAI_BT = " & cboLoaiBT.EditValue.ToString)
        End Try

        Try
            If (iPNgua = False) Then
                txtGiohong.Text = "  :"
                txtDenNgayHong.Text = "  /  /"
                txtDenGioHong.Text = "  :"
                txtNgayhong.Text = "  /  /"
                If (btnMucUuTienFlag = True) Then
                    btnMucUuTien.Visible = True
                Else
                    btnMucUuTien.Visible = False
                End If
                dtpNgayCNBDKH1.Enabled = False
                dtpNgayCNBDKH1.EditValue = ""
            Else

                btnMucUuTien.Visible = False
                dtpNgayCNBDKH1.Enabled = True
                If (Not bPBT) Then

                    txtGiohong.Text = Format(If(IsDBNull(grvDanhSach_1.GetFocusedDataRow()("GIO_HONG")) = True, dtGioLap.Text, grvDanhSach_1.GetFocusedDataRow()("GIO_HONG").ToString()), "Long time")
                    txtNgayhong.Text = Format(If(IsDBNull(grvDanhSach_1.GetFocusedDataRow()("NGAY_HONG")) = True, dtNgayLap1.DateTime.ToString("dd/MM/yyyy"), grvDanhSach_1.GetFocusedDataRow()("NGAY_HONG").ToString()), "Short date")
                    txtDenGioHong.Text = Format(If(IsDBNull(grvDanhSach_1.GetFocusedDataRow()("DEN_GIO_HONG")) = True, dtGioLap.Text, grvDanhSach_1.GetFocusedDataRow()("DEN_GIO_HONG").ToString()), "Long time")
                    txtDenNgayHong.Text = Format(If(IsDBNull(grvDanhSach_1.GetFocusedDataRow()("DEN_NGAY_HONG")) = True, dtNgayLap1.DateTime.ToString("dd/MM/yyyy"), grvDanhSach_1.GetFocusedDataRow()("DEN_NGAY_HONG").ToString()), "Short date")

                    Try
                        If (String.IsNullOrEmpty(grvDanhSach_1.GetFocusedDataRow()("UPDATE_NGAY_CUOI"))) Then
                            dtpNgayCNBDKH1.DateTime = dtNgayBDKH1.DateTime
                        Else
                            dtpNgayCNBDKH1.DateTime = Convert.ToDateTime(grvDanhSach_1.GetFocusedDataRow()("UPDATE_NGAY_CUOI")).ToString("dd/MM/yyyy")
                        End If
                    Catch
                        dtpNgayCNBDKH1.DateTime = dtNgayBDKH1.DateTime
                    End Try
                Else
                    txtGiohong.Text = dtGioLap.Text
                    txtDenNgayHong.Text = dtNgayLap1.DateTime.ToString("dd/MM/yyyy")
                    txtDenGioHong.Text = dtGioLap.Text
                    txtNgayhong.Text = dtNgayLap1.DateTime.ToString("dd/MM/yyyy")
                    dtpNgayCNBDKH1.DateTime = dtNgayBDKH1.DateTime
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dtNgayBDKH1_EditValueChanged(sender As Object, e As EventArgs) Handles dtNgayBDKH1.EditValueChanged
        Try
            If (btnGhi_1.Visible = True) Then
                dtpNgayCNBDKH1.DateTime = dtNgayBDKH1.DateTime.AddMinutes(2)
                dtNgayKTKH1.DateTime = dtpNgayCNBDKH1.DateTime.AddMinutes(4)
            End If
        Catch
        End Try
    End Sub

    Private Sub dtNgayBDKH1_Validated(sender As Object, e As EventArgs) Handles dtNgayBDKH1.Validated
        If btnGhi_1.Enabled = True Then
            If vEvent <> "E" Then
                If bThemSua = True Then
                    Try
                        If txtMaSoPBT.Text = txtSoPhieuBaoTri1.Text Then
                            txtMaSoPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(dtNgayBDKH1.DateTime.Year, dtNgayBDKH1.DateTime.Month)
                            txtSoPhieuBaoTri1.Text = txtMaSoPBT.Text
                        Else
                            txtMaSoPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(dtNgayBDKH1.DateTime.Year, dtNgayBDKH1.DateTime.Month)
                        End If

                    Catch ex As Exception
                        If txtMaSoPBT.Text = txtSoPhieuBaoTri1.Text Then
                            txtMaSoPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI()
                            txtSoPhieuBaoTri1.Text = txtMaSoPBT.Text
                        Else
                            txtMaSoPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI()
                        End If

                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub tabCViec_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tabCViec.SelectedPageChanged
        If tabCViec.SelectedTabPageIndex = 0 Then
            If (ucCongViecPBT.sMsPBT <> txtMaSoPBT.Text) Then
                ucCongViecPBT.sMsMay = cboMAY.EditValue
                ucCongViecPBT.sMsPBT = txtMaSoPBT.Text
                ucCongViecPBT.iTTPBTri = cboTinhTrangPBT.SelectedValue
                ucCongViecPBT.isSynData = isSynData
                ucCongViecPBT._SynConnectionInfo = _SynConnectionInfo
                Dim thread As Thread = New Thread(AddressOf ucCongViecPBT.LoadCongViec)
                thread.Start()
            End If
        ElseIf tabCViec.SelectedTabPageIndex = 1 Then
            If (ucCVPTro.sMsPBT <> txtMaSoPBT.Text) Then
                ucCVPTro.sMsPBT = txtMaSoPBT.Text
                ucCVPTro.iTTPBTri = cboTinhTrangPBT.SelectedValue
                ucCongViecPBT.DieuKhienNutSyn()
                If cboTinhTrangPBT.SelectedValue > 4 Then
                    ucCVPTro.btnThemSua.Enabled = False
                    ucCVPTro.btnXoa.Enabled = False
                Else
                    ucCVPTro.btnThemSua.Enabled = True
                    ucCVPTro.btnXoa.Enabled = True
                End If
                ucCVPTro.LoadPBTCVPhuTro(-1)
                If PermisString.Equals("Read only") Then
                    ucCVPTro.btnThemSua.Enabled = False
                    ucCVPTro.btnXoa.Enabled = False
                End If
            End If

        End If
    End Sub

    Private Sub tabCViec_SelectedPageChanging(sender As Object, e As DevExpress.XtraTab.TabPageChangingEventArgs) Handles tabCViec.SelectedPageChanging
        If ucCongViecPBT.btnGhi.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If ucCVPTro.btnGhi.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub grvPTTTChiTiet_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvPTTTChiTiet.CellValueChanged
        Try
            If Convert.ToBoolean(ObjSystems.PBTKho) Then
                For Each dr As DataRow In TB_PHU_TUNG_THAY_THE_CHI_TIET.Rows
                    If (dr("MS_DH_XUAT_PT").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("MS_DH_XUAT_PT") And
                        dr("MS_DH_NHAP_PT").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("MS_DH_NHAP_PT") And
                        dr("MS_PT").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("MS_PT") And
                        dr("STT").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("STT") And
                   dr("ID").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("ID")) Then
                        dr("SL_TT") = e.Value
                        Exit For
                    End If
                Next
            Else
                For i As Integer = 0 To grvPTThayThe.RowCount - 1
                    If (grvPTThayThe.GetDataRow(i)("MS_BO_PHAN").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("MS_BO_PHAN") And
                        grvPTThayThe.GetDataRow(i)("MS_CV").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("MS_CV") And
                        grvPTThayThe.GetDataRow(i)("MS_PT").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("MS_PT") And
                        grvPTThayThe.GetDataRow(i)("MS_VI_TRI_PT").ToString() = grvPTTTChiTiet.GetDataRow(e.RowHandle)("MS_VI_TRI_PT")) Then
                        grvPTThayThe.SetRowCellValue(i, "SL_TT", grvPTTTChiTiet.GetDataRow(e.RowHandle)("SL_TT"))
                        grvPTThayThe.SetRowCellValue(i, "DON_GIA", grvPTTTChiTiet.GetDataRow(e.RowHandle)("DON_GIA"))
                        grvPTThayThe.SetRowCellValue(i, "NGOAI_TE", grvPTTTChiTiet.GetDataRow(e.RowHandle)("NGOAI_TE"))
                        grvPTThayThe.SetRowCellValue(i, "TY_GIA", grvPTTTChiTiet.GetDataRow(e.RowHandle)("TY_GIA"))
                        grvPTThayThe.SetRowCellValue(i, "TY_GIA_USD", grvPTTTChiTiet.GetDataRow(e.RowHandle)("TY_GIA_USD"))
                        grdPTThayThe.Update()
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub grvPTThayThe_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvPTThayThe.FocusedRowChanged
        If SQLString = "0LoadCT" Then Exit Sub
        Try
            BindDataPTThayTheChiTiet(Me.txtMaSoPBT.Text, grvPTThayThe.GetFocusedDataRow()("MS_BO_PHAN").ToString().Trim(), grvPTThayThe.GetFocusedDataRow()("MS_CV"), grvPTThayThe.GetFocusedDataRow()("MS_PT").ToString().Trim(), grvPTThayThe.GetFocusedDataRow()("STT"))
        Catch ex As Exception
            BindDataPTThayTheChiTiet(String.Empty, String.Empty, -1, String.Empty, -1)
        End Try
    End Sub



#End Region
    Private Sub CreateMenuCV(ByVal grd As GridControl)
        Try
            For Each conTrol In grd.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    Exit Sub
                End If
            Next

        Catch ex As Exception
        End Try
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManagerGridControl_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = ObjLanguages.GetLanguage(ModuleName, "frmMain", "mnuHyperLinkCongViec", TypeLanguage)

        Dim mnuCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCongViec.Name = "mnuCongViec"

        sStr = ObjLanguages.GetLanguage(ModuleName, "frmMain", "mnuHyperLinkChuyenCongViec", TypeLanguage)

        Dim mnuChuyenCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuChuyenCongViec.Name = "mnuChuyenCongViec"


        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec, mnuChuyenCongViec})
        BarManager.EndUpdate()
    End Sub
    Public Function GetFullPath(ByVal node As TreeListNode, ByVal pathSeparator As String) As String
        If node Is Nothing Then
            Return ""
        End If
        Dim result As String = ""
        Do While node IsNot Nothing
            result = pathSeparator & node.GetDisplayText(0) & result
            node = node.ParentNode
        Loop
        Return cboMAY.EditValue + result
    End Function
    Private Sub tvwCautrucTB1_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvwCautrucTB1.FocusedNodeChanged
        Try
            If (tvwCautrucTB1.Nodes.Count < 0) Then
                Exit Sub
            End If
            txtBPLine.Text = GetFullPath(tvwCautrucTB1.FocusedNode, "\")

            If tvwCautrucTB1.FocusedNode("MS_BO_PHAN") = cboMAY.EditValue().Trim() Then
                txtClass.Text = ""
                sClass = ""
                cboProblem.SelectedIndex = -1
                cboCause.SelectedIndex = -1
                cboRemedy.SelectedIndex = -1
                txtNoteClass.Text = ""
            End If
            sVTBP1 = tvwCautrucTB1.FocusedNode
            Dim sMaBP As String = tvwCautrucTB1.FocusedNode("MS_BO_PHAN")
            Dim SqlText As String
            dtRoot = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GET_PHIEU_BAO_TRI_CLASSs").Tables(0)
            SqlText = "MS_BO_PHAN='" & sMaBP & "' AND MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
            dtRoot.DefaultView.RowFilter = SqlText
            classBinding = New BindingSource()
            classBinding.DataSource = dtRoot.DefaultView


            ObjSystems.MLoadXtraGrid(grdProblem, grvProblem, dtRoot.DefaultView.ToTable(), False, False, True, False, True, Name)
            grvProblem.Columns("CLASS_NAME").Visible = False
            grvProblem.Columns("NOTE").Visible = False
            grvProblem.Columns("MS_PHIEU_BAO_TRI").Visible = False
            grvProblem.Columns("MS_BO_PHAN").Visible = False
            grvProblem.Columns("CLASS_ID").Visible = False
            grvProblem.Columns("PROBLEM_ID").Visible = False
            grvProblem.Columns("CAUSE_ID").Visible = False
            grvProblem.Columns("REMEDY_ID").Visible = False

            AddHandler dtRoot.TableNewRow, AddressOf dtRoot_TableNewRow
            Dim dtClass As New DataTable
            dtClass.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT     CLASS_LIST.CLASS_ID, CLASS_LIST.CLASS_NAME FROM  CLASS_LIST INNER JOIN CAU_TRUC_THIET_BI ON CLASS_LIST.CLASS_ID = CAU_TRUC_THIET_BI.CLASS_ID WHERE MS_BO_PHAN=N'" & tvwCautrucTB1.FocusedNode("MS_BO_PHAN") & "' and MS_MAY=N'" & cboMAY.EditValue & "'"))
            If dtClass.Rows.Count > 0 Then
                sClass = dtClass.Rows(0)("CLASS_ID").ToString()
                CType(cboProblem.DataSource, DataTable).DefaultView.RowFilter = "CLASS_ID = '" + sClass + "'"
                cboProblem.DataBindings.Clear()
                cboProblem.DataBindings.Add("SelectedValue", classBinding, "PROBLEM_ID")
                If (classBinding.Current Is Nothing) Then
                    cboProblem.SelectedIndex = -1
                End If
                txtClass.Text = dtClass.Rows(0)("CLASS_NAME").ToString()
                Dim dtCause As New DataTable
                If (cboProblem.SelectedValue Is Nothing) Then
                    dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", " ").Tables(0)
                Else
                    If (cboProblem.SelectedValue.Equals(DBNull.Value)) Then
                        dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", " ").Tables(0)
                    Else
                        dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", cboProblem.SelectedValue.ToString).Tables(0)
                    End If
                End If
                cboCause.DataSource = dtCause
                cboCause.DisplayMember = "CAUSE_NAME"
                cboCause.ValueMember = "CAUSE_ID"
                cboCause.DataBindings.Clear()
                cboCause.DataBindings.Add("SelectedValue", classBinding, "CAUSE_ID")

                Dim dtRemedy As New DataTable
                If (cboCause.SelectedValue Is Nothing) Then
                    dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
                Else
                    If (cboCause.SelectedValue.Equals(DBNull.Value)) Then
                        dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
                    Else
                        dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", cboCause.SelectedValue.ToString).Tables(0)
                    End If
                End If
                cboRemedy.DataSource = dtRemedy
                cboRemedy.DisplayMember = "REMEDY_NAME"
                cboRemedy.ValueMember = "REMEDY_ID"
                cboRemedy.DataBindings.Clear()
                cboRemedy.DataBindings.Add("SelectedValue", classBinding, "REMEDY_ID")
            Else
                sClass = ""
                CType(cboProblem.DataSource, DataTable).DefaultView.RowFilter = "CLASS_ID IS NULL"
                txtClass.Text = ""
                Dim dtCause As New DataTable
                If (cboProblem.SelectedValue Is Nothing) Then
                    dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", " ").Tables(0)
                Else
                    If (cboProblem.SelectedValue.Equals(DBNull.Value)) Then
                        dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", " ").Tables(0)
                    Else
                        dtCause = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSE", cboProblem.SelectedValue.ToString).Tables(0)
                    End If
                End If
                cboCause.DataSource = dtCause
                cboCause.DisplayMember = "CAUSE_NAME"
                cboCause.ValueMember = "CAUSE_ID"

                Dim dtRemedy As New DataTable
                If (cboCause.SelectedValue Is Nothing) Then
                    dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
                Else
                    If (cboCause.SelectedValue.Equals(DBNull.Value)) Then
                        dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", " ").Tables(0)
                    Else
                        dtRemedy = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetREMEDY_CAUSEs", cboCause.SelectedValue.ToString).Tables(0)
                    End If
                End If
                cboRemedy.DataSource = dtRemedy
                cboRemedy.DisplayMember = "REMEDY_NAME"
                cboRemedy.ValueMember = "REMEDY_ID"
            End If
            If tvwCautrucTB1.FocusedNode("MS_BO_PHAN") Is Nothing Then

            End If
            If Not PermisString.Equals("Read only") Then
                If grvProblem.RowCount <= 0 Then

                    If tvwCautrucTB1.FocusedNode("MS_BO_PHAN") = cboMAY.EditValue() Or cboTinhTrangPBT.SelectedValue >= 5 Then
                        btnXoaClass.Enabled = False
                        btnSuaClass.Enabled = False
                        btnThemClass.Enabled = False
                    Else
                        btnXoaClass.Enabled = False
                        btnSuaClass.Enabled = False
                        btnThemClass.Enabled = True
                    End If


                Else


                    If tvwCautrucTB1.FocusedNode("MS_BO_PHAN") = cboMAY.EditValue() Or cboTinhTrangPBT.SelectedValue >= 5 Then
                        btnXoaClass.Enabled = False
                        btnSuaClass.Enabled = False
                        btnThemClass.Enabled = False
                    Else
                        btnThemClass.Enabled = True
                        btnXoaClass.Enabled = True
                        btnSuaClass.Enabled = True
                    End If
                End If
            Else
                btnXoaClass.Enabled = False
                btnSuaClass.Enabled = False
                btnThemClass.Enabled = False
            End If
            grvProblem_FocusedRowChanged(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grvProblem_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvProblem.FocusedRowChanged
        Try
            cboProblem.SelectedValue = grvProblem.GetFocusedDataRow()("PROBLEM_ID")
            cboCause.SelectedValue = grvProblem.GetFocusedDataRow()("CAUSE_ID")
            cboRemedy.SelectedValue = grvProblem.GetFocusedDataRow()("REMEDY_ID")
            txtNoteClass.Text = grvProblem.GetFocusedDataRow()("NOTE")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CreateMenuPT(ByVal grd As GridControl)
        Try
            For Each conTrol In grd.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    Exit Sub
                End If
            Next

        Catch ex As Exception
        End Try
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd

        AddHandler BarManager.ItemClick, AddressOf barManagerGridControl_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = ObjLanguages.GetLanguage(ModuleName, "frmMain", "mnuHyperLinkPhuTung", TypeLanguage)

        Dim mnuPhuTung As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuPhuTung.Name = "mnuPhuTung"


        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuPhuTung})

        BarManager.EndUpdate()
    End Sub


    Dim BarManagerNS As New DevExpress.XtraBars.BarManager

    Private Sub ucCongViecNS_Load(sender As Object, e As EventArgs) Handles ucCongViecNS.Load
        ucCongViecNS.LoadFormNSPBT()
    End Sub

    Private Sub grvKeHoachNS_DoubleClick(sender As Object, e As EventArgs)
        Try
            Dim view As GridView = CType(sender, GridView)
            Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
            DoRowNhanSuDoubleClick(view, pt)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DoRowNhanSuDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Try
            Dim info As GridHitInfo = view.CalcHitInfo(pt)
            If info.InRow OrElse info.InRowCell Then
                If info.Column.FieldName = "TEN_CONG_NHAN" Then
                    Try
                        FrmCongViecNhanVien.MS_PBT = txtMaSoPBT.Text.Trim()
                        FrmCongViecNhanVien.StartPosition = FormStartPosition.CenterParent
                        FrmCongViecNhanVien.MS_CONG_NHAN = ucCongViecNS.grvKHNhanVien.GetDataRow(info.RowHandle)("MS_CONG_NHAN").ToString().Trim()
                        FrmCongViecNhanVien.ShowDialog(Me)
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBanGiao_Click(sender As Object, e As EventArgs) Handles btnBanGiao.Click
        If txtMaSoPBT.Text.Trim = "" Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "ChuaChonPhieuBaotri", TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'Update BAN_GIAO PHIEU_BAO TRI
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.PHIEU_BAO_TRI SET BAN_GIAO  = 1 , USERNAME_BG = '" + Commons.Modules.UserName + "' WHERE MS_PHIEU_BAO_TRI ='" & txtMaSoPBT.Text.Trim & "'")
            grvDanhSach_1.SetFocusedRowCellValue("NGUOI_BAN_GIAO", SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ISNULL(FULL_NAME,USERNAME) FROM dbo.USERS WHERE USERNAME = '" + Commons.Modules.UserName + "'").ToString())
            btnBanGiao.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CapNhapNgayCuoi(ByVal NgayCuoi As Date)
        Dim sSql As String
        sSql = "UPDATE PHIEU_BAO_TRI SET UPDATE_NGAY_CUOI = '" & NgayCuoi.ToString("MM/dd/yyyy") & "'  WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "'  "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        dtpNgayCNBDKH1.DateTime = NgayCuoi
    End Sub
    Private Sub CreateMenuNhanSu(ByVal grd As GridControl)
        Try
            For Each conTrol In grd.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    Exit Sub
                End If
            Next

        Catch ex As Exception
        End Try
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManagerGridControl_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)



        Dim sStr As String
        sStr = ObjLanguages.GetLanguage(ModuleName, "frmMain", "mnuCapNhatNgayHoanThanh", TypeLanguage)
        Dim mnuCapNhatNgayHoanThanh As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCapNhatNgayHoanThanh.Name = "mnuCapNhatNgayHoanThanh"
        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCapNhatNgayHoanThanh})


        BarManager.EndUpdate()
    End Sub


    Dim frmDanhmuccongviec As MVControl.frmDanhmuccongviec

    Private Sub FormChuyenCongViecToDichVu(ByVal MS_PBT As String, ByRef msDichVu As String, ByRef checkAll As Boolean)
        Dim btnThucHien As DevExpress.XtraEditors.SimpleButton
        Dim btnHuy As DevExpress.XtraEditors.SimpleButton
        Dim lblDichVu As DevExpress.XtraEditors.LabelControl
        Dim cboDichVu As DevExpress.XtraEditors.LookUpEdit
        Dim ckAll As DevExpress.XtraEditors.CheckEdit
        Dim frm As DevExpress.XtraEditors.XtraForm

        btnThucHien = New DevExpress.XtraEditors.SimpleButton()
        btnHuy = New DevExpress.XtraEditors.SimpleButton()
        lblDichVu = New DevExpress.XtraEditors.LabelControl()
        cboDichVu = New LookUpEdit()
        frm = New XtraForm()
        frm.Controls.Clear()
        ckAll = New DevExpress.XtraEditors.CheckEdit()
        CType(cboDichVu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(ckAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        frm.SuspendLayout()
        '
        'btnThucHien
        '
        btnThucHien.Location = New System.Drawing.Point(196, 79)
        btnThucHien.LookAndFeel.SkinName = "Blue"
        btnThucHien.LookAndFeel.UseDefaultLookAndFeel = False
        btnThucHien.Name = "btnThucHien"
        btnThucHien.Size = New System.Drawing.Size(104, 32)
        btnThucHien.TabIndex = 0
        btnThucHien.Text = "btnThucHien"
        btnThucHien.DialogResult = DialogResult.OK
        '
        'btnHuy
        '
        btnHuy.Location = New System.Drawing.Point(306, 79)
        btnHuy.LookAndFeel.SkinName = "Blue"
        btnHuy.LookAndFeel.UseDefaultLookAndFeel = False
        btnHuy.Name = "btnCancel"
        btnHuy.Size = New System.Drawing.Size(104, 32)
        btnHuy.TabIndex = 1
        btnHuy.Text = "btnHuy"
        btnHuy.DialogResult = DialogResult.Cancel
        '
        'lblDichVu
        '
        lblDichVu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblDichVu.Location = New System.Drawing.Point(40, 22)
        lblDichVu.Name = "lblDichVu"
        lblDichVu.Size = New System.Drawing.Size(50, 19)
        lblDichVu.TabIndex = 1
        lblDichVu.Text = "lblDichVu"
        '
        'cboDichVu
        '
        cboDichVu.EditValue = Nothing
        cboDichVu.Location = New System.Drawing.Point(122, 22)
        cboDichVu.Name = "cboDichVu"
        cboDichVu.Properties.NullText = ""
        cboDichVu.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        cboDichVu.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        cboDichVu.Size = New System.Drawing.Size(288, 20)
        cboDichVu.TabIndex = 0
        '
        'ckAll lblDichVu
        '
        ckAll.Location = New System.Drawing.Point(120, 48)
        ckAll.Name = "ckAll"
        ckAll.Properties.Caption = "ckAll"
        ckAll.Size = New System.Drawing.Size(150, 19)
        ckAll.TabIndex = 16
        '
        'Form1
        '
        frm.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        frm.Appearance.Options.UseBackColor = True
        frm.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        frm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        frm.ClientSize = New System.Drawing.Size(449, 126)
        frm.Controls.Add(btnThucHien)
        frm.Controls.Add(btnHuy)
        frm.Controls.Add(lblDichVu)
        frm.Controls.Add(ckAll)
        frm.Controls.Add(cboDichVu)
        frm.Name = "frmChuyenCongViec"
        frm.Text = "frmChuyenCongViec"
        'ckAll lblDichVu lblChuyenCongViec
        CType(cboDichVu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(ckAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        frm.ResumeLayout(False)



        Dim str As String = "SELECT STT AS STT_SERVICE, NOI_DUNG_SERVICE FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI = '" & MS_PBT & "'"
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        ObjSystems.MLoadLookUpEdit(cboDichVu, dt, "STT_SERVICE", "NOI_DUNG_SERVICE", "")

        ObjSystems.ThayDoiNN(frm)
        frm.StartPosition = FormStartPosition.CenterParent
        frm.MaximizeBox = False
        frm.FormBorderStyle = FormBorderStyle.FixedSingle


        frm.AcceptButton = btnThucHien
        frm.CancelButton = btnHuy
        frm.ShowDialog()


        If (frm.DialogResult = DialogResult.OK) Then
            If (cboDichVu.EditValue Is Nothing) Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmMain", "MsgKhongCoDichVu", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                FormChuyenCongViecToDichVu(MS_PBT, msDichVu, checkAll)
            Else
                msDichVu = cboDichVu.EditValue
                checkAll = ckAll.EditValue
            End If

        Else
            msDichVu = "cancel"
        End If
    End Sub



    Private Sub InputBoxViTri(ByRef value As String, ByVal dt As DataTable)
        Dim lblViTri As Label
        Dim btnOK As Button
        Dim btnCancel As Button
        Dim txtTenViTri As TextBox
        Dim form As New Form()

        lblViTri = New System.Windows.Forms.Label()
        btnOK = New System.Windows.Forms.Button()
        btnCancel = New System.Windows.Forms.Button()
        txtTenViTri = New System.Windows.Forms.TextBox()
        form.SuspendLayout()

        lblViTri.AutoSize = True
        lblViTri.Location = New System.Drawing.Point(24, 16)
        lblViTri.Name = "lblViTri"
        lblViTri.Size = New System.Drawing.Size(50, 13)
        lblViTri.Text = "Tên vị trí"

        btnOK.Location = New System.Drawing.Point(142, 39)
        btnOK.Name = "btnOK"
        btnOK.Size = New System.Drawing.Size(75, 23)
        btnOK.Text = "OK"
        btnOK.DialogResult = DialogResult.OK

        btnCancel.Location = New System.Drawing.Point(223, 39)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New System.Drawing.Size(75, 23)
        btnCancel.Text = "Cancel"
        btnCancel.DialogResult = DialogResult.Cancel

        txtTenViTri.Location = New System.Drawing.Point(93, 13)
        txtTenViTri.Name = "txtTenViTri"
        txtTenViTri.Size = New System.Drawing.Size(205, 20)

        form.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        form.ClientSize = New System.Drawing.Size(323, 80)
        form.Controls.AddRange(New Control() {btnCancel, lblViTri, txtTenViTri, btnOK, btnCancel})
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.StartPosition = FormStartPosition.CenterParent
        form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        form.Name = "formThemViTri"
        form.ResumeLayout(False)
        form.PerformLayout()

        ObjSystems.ThayDoiNN(form)
        form.AcceptButton = btnOK
        form.CancelButton = btnCancel
        form.ShowDialog()
        If (txtTenViTri.Text.Trim() = "" And form.DialogResult = DialogResult.OK) Then
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, form.Name, "MsgTenViTriRong", TypeLanguage), form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            InputBoxViTri(value, dt)
            Return
        End If

        If (form.DialogResult = DialogResult.OK) Then

            For Each row As DataRow In dt.Rows
                If (row("MS_VI_TRI_PT").ToString() = txtTenViTri.Text.Trim()) Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, form.Name, "MsgTenViTriTonTai", TypeLanguage), form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    InputBoxViTri(value, dt)
                    Return
                End If
            Next
        End If
        value = txtTenViTri.Text
    End Sub




    Public Sub ThayDoiTinhTrangPBT()
        Try
            If KiemHoanThanh() = False Then Exit Sub Else CapNhapPBTCT(2)
            If grvDanhSach_1.RowCount = 0 Then Exit Sub
            If CheckNghiemThuPBT() Then Exit Sub

            ucCVPTro.bThemSua(True)

        Catch ex As Exception
        End Try
    End Sub
    Public Sub XoaPhuTro()
        Try

            If ucCVPTro.grvCViec.RowCount = 0 Then
                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", TypeLanguage), Me.Text)
                Exit Sub
            Else
                If CheckNghiemThuPBT() Then Exit Sub
                If KiemHoanThanh() = False Then Exit Sub


                Dim str As String = ""
                str = "select TOP 1  MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' and STT='" & ucCVPTro.grvCViec.GetFocusedRowCellValue("STT").ToString & "'"
                Dim dtTmp As New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                If dtTmp.Rows.Count > 0 Then
                    XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, Me.Name, "MsgTonTaiCVP", TypeLanguage), Me.Text)
                    Exit Sub
                End If
                ucCVPTro.AnXoa(True)
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub barManagerGridControl_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
        Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
        If Not subMenu Is Nothing Then Return

        Dim grd As DevExpress.XtraGrid.GridControl = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DevExpress.XtraGrid.GridControl)
        Dim grv As GridView = TryCast(grd.MainView, GridView)

        Try
            Dim dt As New DataTable()
            Select Case e.Item.Name.ToUpper
                Case "mnuCongViec".ToUpper
                    Commons.Hyperlink.ToCongViec(Me, grv.GetFocusedDataRow()("MS_CV").ToString())
                Case "mnuPhuTung".ToUpper
                    Commons.Hyperlink.ToPhuTung(Me, grv.GetFocusedDataRow()("MS_PT").ToString())
                Case "mnuChuyenCongViec".ToUpper
                    If (ucCongViecPBT.grvCongViec.RowCount = 0) Then
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmMain", "MsgKhongCoCongViecDeChuyen", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                        Return
                    End If
                    Dim msDichVu As String = ""
                    Dim checkAll As Boolean
                    If Convert.ToInt32(grvDanhSach_1.GetFocusedDataRow()("TINH_TRANG_PBT").ToString()) < 3 Then
                        Dim dtServices As New DataTable
                        dtServices.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "'"))
                        If (dtServices.Rows.Count = 0) Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmPhieuBaoTri_New", "msgDichVu_ChuaCoDichVu", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                            Return
                        End If
                        Dim dtCV As New DataTable
                        dtCV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND MS_CV = " & ucCongViecPBT.grvCongViec.GetFocusedDataRow()("MS_CV").ToString() & " AND MS_BO_PHAN = '" & ucCongViecPBT.grvCongViec.GetFocusedDataRow()("MS_BO_PHAN").ToString() & "'"))
                        If (dtCV.Rows.Count > 0) Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmPhieuBaoTri_New", "msgDichVu_ThongBao", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                            Return
                        End If
                    Else
                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmPhieuBaoTri_New", "msgDichVu_ThongBao", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                        Return
                    End If

                    FormChuyenCongViecToDichVu(txtMaSoPBT.Text, msDichVu, checkAll)
                    If (Not msDichVu.ToLower().Equals("cancel")) Then
                        If (checkAll = False) Then
                            Dim str As String = " UPDATE PHIEU_BAO_TRI_CONG_VIEC SET STT_SERVICE = " & msDichVu & " WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND MS_CV = " & ucCongViecPBT.grvCongViec.GetFocusedDataRow()("MS_CV").ToString() & " AND MS_BO_PHAN = '" & ucCongViecPBT.grvCongViec.GetFocusedDataRow()("MS_BO_PHAN").ToString() & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        Else
                            For i As Integer = 0 To ucCongViecPBT.grvCongViec.RowCount - 1
                                Dim dtCheck As New DataTable
                                dtCheck.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND MS_CV = " & ucCongViecPBT.grvCongViec.GetDataRow(i)("MS_CV").ToString() & " AND MS_BO_PHAN = '" & ucCongViecPBT.grvCongViec.GetDataRow(i)("MS_BO_PHAN").ToString() & "'"))
                                If (dtCheck.Rows.Count = 0) Then
                                    Dim str As String = " UPDATE PHIEU_BAO_TRI_CONG_VIEC SET STT_SERVICE = " & msDichVu & " WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND MS_CV = " & ucCongViecPBT.grvCongViec.GetDataRow(i)("MS_CV").ToString() & " AND MS_BO_PHAN = '" & ucCongViecPBT.grvCongViec.GetDataRow(i)("MS_BO_PHAN").ToString() & "'"
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                End If
                            Next

                        End If

                        XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmPhieuBaoTri_New", "msgDichVu_ThongBao2", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ucCongViecPBT.LoadCongViec()
                        ucDichVu.LoadDichVu()
                    End If
                Case "mnuCapNhatNgayHoanThanh".ToUpper
                    If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 0 Then

                        If (ucCongViecNS.grvCVChinhNS.RowCount = 0) Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmMain", "MsgKhongCoCongViec", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                            Return
                        End If

                    End If
                    If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 1 Then
                        If (ucCongViecNS.grvCVPhuNS.RowCount = 0) Then
                            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmMain", "MsgKhongCoCongViec", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                            Return
                        End If
                    End If

                    If (sPrivate <> "GREENFEED") Then
                        Dim str1 As String = "SELECT DISTINCT CONVERT(NVARCHAR(10), DEN_NGAY, 103) AS DEN_NGAY FROM " & If(ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 0, "PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET", "PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO") & " WHERE MS_PHIEU_BAO_TRI = '" & grvDanhSach_1.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString() & "' AND DEN_NGAY IS NOT NULL"
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str1))
                        Dim frm As New MVControl.frmCapNhatNgayHoanThanh()
                        frm.dt = dt
                        frm.ShowDialog()
                        If (frm.DialogResult = DialogResult.OK) Then
                            If (frm.msNgayHoanThanh.ToString("yyy/MM/dd") <> "1900/01/01") Then
                                If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 0 Then
                                    If (frm.check = 0) Then
                                        Dim str As String = " UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH = '" & frm.msNgayHoanThanh.ToString("yyyy/MM/dd") & "', H_THANH = 1, PT_HOAN_THANH = 100 WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND MS_CV = " & ucCongViecNS.grvCVChinhNS.GetFocusedDataRow()("MS_CV").ToString() & " AND MS_BO_PHAN = '" & ucCongViecNS.grvCVChinhNS.GetFocusedDataRow()("MS_BO_PHAN").ToString() & "'"
                                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                    ElseIf (frm.check = 1) Then
                                        For i As Integer = 0 To ucCongViecNS.grvCVChinhNS.RowCount - 1
                                            Dim dtCheck As New DataTable
                                            Dim str As String = " UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH =  '" & frm.msNgayHoanThanh.ToString("yyyy/MM/dd") & "', H_THANH = 1, PT_HOAN_THANH = 100  WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND MS_CV = " & ucCongViecNS.grvCVChinhNS.GetDataRow(i)("MS_CV").ToString() & " AND MS_BO_PHAN = '" & ucCongViecNS.grvCVChinhNS.GetDataRow(i)("MS_BO_PHAN").ToString() & "'  AND NGAY_HOAN_THANH IS NULL"
                                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                        Next
                                    Else
                                        For i As Integer = 0 To ucCongViecNS.grvCVChinhNS.RowCount - 1
                                            Dim dtCheck As New DataTable
                                            Dim str As String = " UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH =  '" & frm.msNgayHoanThanh.ToString("yyyy/MM/dd") & "', H_THANH = 1, PT_HOAN_THANH = 100  WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND MS_CV = " & ucCongViecNS.grvCVChinhNS.GetDataRow(i)("MS_CV").ToString() & " AND MS_BO_PHAN = '" & ucCongViecNS.grvCVChinhNS.GetDataRow(i)("MS_BO_PHAN").ToString() & "'"
                                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                        Next
                                    End If
                                    ucCongViecNS.LoadCongViecChinhNS()
                                End If
                                If ucCongViecNS.tabCVNhanSu.SelectedTabPageIndex = 1 Then
                                    If (frm.check = 0) Then
                                        Dim str As String = " UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH =  '" & frm.msNgayHoanThanh.ToString("yyyy/MM/dd") & "' WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND STT = " & ucCongViecNS.grvCVPhuNS.GetFocusedDataRow()("STT").ToString()
                                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                    ElseIf (frm.check = 1) Then

                                        For i As Integer = 0 To ucCongViecNS.grvCVPhuNS.RowCount - 1
                                            Dim str As String = " UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH =  '" & frm.msNgayHoanThanh.ToString("yyyy/MM/dd") & "' WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND STT = " & ucCongViecNS.grvCVPhuNS.GetFocusedDataRow()("STT").ToString() & " AND NGAY_HOAN_THANH IS NULL"
                                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                        Next
                                    Else
                                        For i As Integer = 0 To ucCongViecNS.grvCVPhuNS.RowCount - 1
                                            Dim str As String = " UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH =  '" & frm.msNgayHoanThanh.ToString("yyyy/MM/dd") & "' WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "' AND STT = " & ucCongViecNS.grvCVPhuNS.GetFocusedDataRow()("STT").ToString()
                                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                        Next
                                    End If
                                    ucCongViecNS.LoadCongViecPhuNS()
                                End If
                                If (frm.iNgayCuoi = 1) Then CapNhapNgayCuoi(frm.msNgayHoanThanh)
                                XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmPhieuBaoTri_New", "msgCapNhatNgayHTSuccess", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmPhieuBaoTri_New_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub


    Private Sub ReadOnlyForm()
        BtnLockPBT.Enabled = False
        btnHThanhNT.Enabled = False
        BtnXacnhanNT.Enabled = False
        btnSuaPHTT.Enabled = False
        btnXoaPHTT.Enabled = False
        btnThemPHTT.Enabled = False
    End Sub

    Private Sub FrmPhieuBaoTri_New_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If sMsPBTLink = "-1" Then Return
            If TabPhieuBaoTri.SelectedTabPageIndex <> 0 Then
                TabPhieuBaoTri.SelectedTabPageIndex = 0
                If TabPhieuBaoTri.SelectedTabPageIndex <> 0 Then GoTo ExitSub
            End If
            If btnGhi_1.Visible = True Then GoTo ExitSub
            txtTimKiemPBT.Text = sMsPBTLink
            txtTimKiemPBT_KeyDown(txtTimKiemPBT.Text, New KeyEventArgs(Keys.Enter))
            sMsPBTLink = "-1"
            Return
ExitSub:
            sMsPBTLink = "-1"
            XtraMessageBox.Show(ObjLanguages.GetLanguage(ModuleName, "frmPhieuBaoTri_New", "msgThoatChucNangGhi", TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            sMsPBTLink = "-1"
        End Try
    End Sub

    Private Sub FrmPhieuBaoTri_New_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        grdDanhSach_1.MainView.SaveLayoutToRegistry(regPBT)
    End Sub
End Class