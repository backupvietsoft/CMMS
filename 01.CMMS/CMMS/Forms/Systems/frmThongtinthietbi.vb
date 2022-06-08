Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.VisualBasic.DateAndTime
Imports Commons
Imports System.Linq
Imports DevExpress.XtraTab
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils

Public Class frmThongtinthietbi
    Public MS_MAY_CHOICE As String = Nothing
    Public TAB_INDEX_CHOICE As Integer = -1
    Public MSBP As String = Nothing
    Public MSPTVT As String = Nothing
    Public MSCV As String = Nothing
    Private _SourceProblem As BindingSource = New BindingSource()
    Private _SourceCause As BindingSource = New BindingSource()
    Private _SourceRemedy As BindingSource = New BindingSource()
    Dim dtTSBP As New DataTable()
    Public sLoaiMay As String = "", sNoiLapDat As String = "", sLine As String = "", sNhom As String = ""
    'Private sTSo As String
    Public MSMAY As String = "-1"
    Dim regMay As String = "DevExpress\XtraGrid\Layouts\GridMay"
    Dim regCTTB As String = "DevExpress\XtraGrid\Layouts\GridCTTB"

#Region "Private Member"
    Private blnThem, blnSua, blnThemSuaCauTrucSub As Boolean
    Private blnThoat As Boolean = False
    Private ID As Integer = 0
    Private SQL As String
    Private MS_MAY_TMP, MS_MAY_TMP_SET As String
    Private dtTableOne, dtTableTwo As DataTable
    Private rowCount, i, rowCount1, rowCount2, rowCount3, ind As Integer
    Private loi, capNhat, luuThanhCong, blnRefesh4, blnXoa3 As Boolean
    Private tmp_k As Integer = -1
    Private tmp_i As Integer = -1
    Public intViTriCongviec As Integer = -1
    Private intViTriLoaiBTPN As Integer = -1
    Private intViTriPhuTung As Integer = -1
    Private lstMayChange As Boolean = False
    Private DTVMAY As DataView
    Dim intSTT As Integer = 0
    Dim _firstTable As New DataTable
    Private strHinh As String = ""
    'Danh mục tài liệu
    Private MS_TAI_LIEU As Integer
    Private MS_MAY As String
    Private TEN_TAI_LIEU As String
    Private NOI_LUU_TRU As String
    Private OLD_NOI_LUU_TRU As String
    Private TEMP_PATH_UPDATE As String = "D:\HINH_TAI_LIEU_THIET_BI_VIETSOFT_CMMS_UPDATE"
    Private dtTAI_LIEU As New DataTable
    Private drTAI_LIEU As DataRow
    Private LAST_ROW As Integer
    Private SERVER_PATH As String
    'Hình thiết bị
    Private HINH_THIET_BI_PATH As String
    Private HINH_THIET_BI_UPDATE As String = "D:\HINH_THIET_BI_VIETSOFT_CMMS_UPDATE"
    Private HINH_THIET_BI As String
    Private ArrHieuChuanDongHo(250) As String
    Private ArrHieuChuanViTri(250) As String
    Private blnXoaCauTruc, blnThemSuaCauTruc As Boolean
    Private Shared SqlText As String = String.Empty
    Private blnLoiBTPN As Boolean = False
    Private sMS_BP_OLD As String = ""
    Public dtTableThongso As New DataTable
    Private _my_city As String = "-1"
    Private _my_district As String = "-1"
    Private _my_street As String = "-1"
    Private isFirst As Boolean = False
    Private flag_nhom As Boolean = True
    Private blnXoa_TS As Boolean = False
    Private intMS_LOAI_BT As Integer
    Private intRow As Integer = 0
    Private noDataToPrint As Boolean = True
    Private parentNodes() As String
    Private bThemBTPN As Boolean = False
    Private _MS_LOAI_MAY As String = ""
    Private _MS_NHOM_MAY As String = ""
#End Region

#Region "Control Event"
    Private Sub FrmThongtinthietbi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        grdMay.MainView.SaveLayoutToRegistry(regMay)
        grdCTTB_PT.MainView.SaveLayoutToRegistry(regCTTB)
        'grdMay.MainView.SaveLayoutToXml(Application.StartupPath + "\XML\GridTTTB.xml")
        'grdCTTB_PT.MainView.SaveLayoutToXml(Application.StartupPath + "\XML\GrdMayCTTBPT.xml")
        If BtnGhi.Visible = True Then
            e.Cancel = True
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "VuiLongBamGhiHayKhongGhi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            grdThongsoGSTTDL.DataSource = Nothing
            grdThongsochitiet.DataSource = Nothing
            grdHuHong.DataSource = Nothing
            grdNguyenNhan.DataSource = Nothing
            grdPP.DataSource = Nothing
            grdLichSuMay.DataSource = Nothing
            grdLichSuPTTThe.DataSource = Nothing
            grdLichSuMay.DataSource = Nothing
            grdLichSuMay.DataSource = Nothing
            grdLichSuPTTThe.DataSource = Nothing
            grdLoaiBTPN_PT.DataSource = Nothing
            grdThongSoMay.DataSource = Nothing
        Catch ex As Exception

        End Try
        grdLoaiBTPN.DataSource = Nothing
        grdThongsoGSTTDL.DataSource = Nothing

        Dim str As String = ""
        Commons.Modules.ObjSystems.XoaTable("MAY_LOAI_BTPN_CHU_KY_TMP1" & Commons.Modules.UserName)
        Commons.Modules.ObjSystems.XoaTable("MAY_LOAI_BTPN_CHU_KY_TMP" & Commons.Modules.UserName)
        Commons.Modules.ObjSystems.XoaTable("BO_PHAN" & Commons.Modules.UserName)
        Commons.Modules.ObjSystems.XoaTable("rptPHIEU_BAO_TRI")
        Commons.Modules.ObjSystems.XoaTable("rptPHU_TUNG_BAO_TRI")
        Commons.Modules.ObjSystems.XoaTable("rptDICH_VU_THUE_NGOAI")
        Commons.Modules.ObjSystems.XoaTable("rptNHAN_CONG")
        Commons.Modules.ObjSystems.XoaTable("rptCONG_VIEC_BAO_TRI")
        Commons.Modules.ObjSystems.XoaTable("rptDI_CHUYEN_BO_PHAN_BAO_TRI")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDePhuTungBaoTri")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDePhieuBaoTri")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeNhanCongBaoTri")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDedichvuThueNgoaiBaoTri")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeDiChuyenBoPhanBaoTri")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDeCongViecBaoTri")
        blnThoat = True
        Try
            GC.Collect()
            Me.Controls.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Sub EnableButton(ByVal bln As Boolean)
        Try

            Me.BtnThem.Enabled = bln
            Me.BtnXoa.Enabled = bln
            Me.BtnSua.Enabled = bln
            ucDMTBi.BtnLoaiTB.Enabled = bln
            ucDMTBi.BtnHangSX.Enabled = bln
            BtnTaoMoiTB.Enabled = bln
            btnCopyTB.Enabled = bln
            ucDMTBi.btnChenhinh.Enabled = bln
            ucDMTBi.btnXoahinh.Enabled = bln

            BtnThem4.Enabled = bln
            BtnSua4.Enabled = bln
            BtnXoa4.Enabled = bln
            BtnThemSuaTSvaPT.Enabled = bln
            BtnThemSuaCVBP.Enabled = bln
            BtnXoaCVBP.Enabled = bln
            BtnThemSuaTSGSTT_BP.Enabled = bln
            BtnXoaTSGSTT_BP.Enabled = bln

            btnChukyBTPN.Enabled = bln
            BtnChonCongViec.Enabled = bln
            btnThemsua3.Enabled = bln
            btnXoa3.Enabled = bln

            btnThemsua2.Enabled = bln
            btnXoa2.Enabled = bln
            BtnTSBP.Enabled = bln
            btnThemsua1.Enabled = bln
            btnXoa1.Enabled = bln
            chxAnToan.Enabled = Not bln

            BtnThemSuaPT.Enabled = bln
            BtnXoa43.Enabled = bln
            btnThemLichBTPN.Enabled = bln
        Catch ex As Exception

        End Try

    End Sub

    Sub InitMayHeThongBPCPNhaXuongTmp(ByVal MS_MAY As String)
        Dim dtReader As SqlDataReader
        ucDMTBi.TxtMS_HE_THONG.Text = ""
        SQL = "SELECT TEN_HE_THONG FROM HE_THONG INNER JOIN MAY_HE_THONG ON " &
                "HE_THONG.MS_HE_THONG = MAY_HE_THONG.MS_HE_THONG WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_HE_THONG WHERE MS_MAY=N'" & MS_MAY & "')"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ucDMTBi.TxtMS_HE_THONG.Text = dtReader.Item("TEN_HE_THONG")
        End While

        dtReader.Close()
        SQL = "SELECT TEN_N_XUONG + CASE WHEN GHI_CHU IS NULL OR GHI_CHU = '' THEN '' ELSE '(' + GHI_CHU + ')' END AS TEN_N_XUONG,NHA_XUONG.MS_N_XUONG FROM NHA_XUONG INNER JOIN MAY_NHA_XUONG ON " &
                "NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG.MS_N_XUONG WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_NHA_XUONG WHERE MS_MAY=N'" & MS_MAY & "')"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        ucDMTBi.TxtMS_NHA_XUONG.Text = ""
        While dtReader.Read
            ucDMTBi.TxtMS_NHA_XUONG.Text = dtReader.Item("TEN_N_XUONG")
        End While
        dtReader.Close()
        SQL = "SELECT TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI INNER JOIN MAY_BO_PHAN_CHIU_PHI ON " &
                        "BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI = MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                        "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY=N'" & MS_MAY & "')"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ucDMTBi.TxtMS_BP_CHIU_PHI.Text = dtReader.Item("TEN_BP_CHIU_PHI")
        End While
        dtReader.Close()
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Dim str As String = ""
        MS_MAY_TMP_SET = txtMS_MAY.Text
        Refesh()
        VisibleButton(False)
        LockData(False)
        'blnThem = True
        blnThongtintb = 1
        ucDMTBi.txtSO_NAM_KHAU_HAO.Text = 0
        ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text = 0
        ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text = 0
        ucDMTBi.txtSO_THANG_BH.Text = 0
        ucDMTBi.txtGIA_MUA.Text = 0
        ucDMTBi.txtTiGiaVND.Text = 0
        ucDMTBi.txtTiGiaUSD.Text = 0
        ucDMTBi.txtChukyHC.Text = 0
        ucDMTBi.txtCKHCTB_Ngoai.Text = 0
        ucDMTBi.txtCKKDTB.Text = 0
        ucDMTBi.txtSO_NAM_KHAU_HAO.Text = 0
        ucDMTBi.txtTY_LE_CON_LAI.Text = 100
        LockControl(True)
        ucDMTBi.cboMS_NCC.Text = String.Empty
        ucDMTBi.txtMS_MAY.Focus()
        MS_MAY_TMP = "-1"
        ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime = Now.Date
        ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime = Now.Date
        ucDMTBi.txtNGAY_SX.DateTime = Now.Date
    End Sub

    Sub LockControl(ByVal Khoa As Boolean)
        grdMay.Enabled = Not Khoa
        optHienTrang.Enabled = Not Khoa
        CboLoaithietbi.Enabled = Not Khoa
        CboNhomthietbi.Enabled = Not Khoa
        CboNLD.Enabled = Not Khoa
        cboLine.Enabled = Not Khoa
        ucDMTBi.BtnNoilapdat.Enabled = Khoa
        txtTimMay.Properties.ReadOnly = Khoa
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        'BtnLoaiTB.Enabled = False
        If txtMS_MAY.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenSua1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        blnSua = True
        blnThongtintb = 2
        ucDMTBi.txtMS_MAY.Focus()
        MS_MAY_TMP = ucDMTBi.txtMS_MAY.Text
        MS_MAY_TMP_SET = ucDMTBi.txtMS_MAY.Text
        VisibleButton(False)
        LockData(False)
        LockControl(True)
        Try
            Dim count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM SVM_TRANS_ACC WHERE IO_KEY=N''" + ucDMTBi.txtMS_MAY.Text + "')")

            If (Not count Is Nothing) Then
                If (CType(count, Integer) > 0) Then
                    ucDMTBi.txtMS_MAY.Enabled = False
                    ucDMTBi.txtSoCT.Properties.ReadOnly = True
                    ucDMTBi.txtNGAY_MUA.Enabled = False
                    ucDMTBi.txtGIA_MUA.Properties.ReadOnly = True
                    ucDMTBi.cboNGOAI_TE.Enabled = False
                    ucDMTBi.txtTiGiaVND.Properties.ReadOnly = True
                    ucDMTBi.txtTiGiaUSD.Properties.ReadOnly = True
                End If
            End If

        Catch ex As Exception

        End Try
        MS_MAY_TMP = ucDMTBi.txtMS_MAY.Text
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        'Phuc sua
        Try
            Dim count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM SVM_TRANS_ACC WHERE IO_KEY=N''" + ucDMTBi.txtMS_MAY.Text + "')")
            If (Not count Is Nothing) Then
                If (CType(count, Integer) > 0) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMayCloseDelete", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If

        Catch ex As Exception

        End Try
        Dim traloi As String
        Dim dtReader As SqlDataReader
        Dim objMAYController As New MAYController()
        If ucDMTBi.txtMS_MAY.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        SQL = "SELECT * FROM CONG_VIEC_HANG_NGAY_THIET_BI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa35", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        SQL = "SELECT * FROM LICH_TAU_THIET_BI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        SQL = "SELECT * FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Thiết bị này đang được sử dụng trong thời gian chạy máy ! bạn không thể xóa !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        '
        SQL = "SELECT * FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Thiết bị này đang được sử dụng trong phiếu bảo trì ! Bạn không thể xóa !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa23", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM KE_HOACH_TONG_THE WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Thiết bị này đang được sử dụng trong kế hoạch tổng thể ! Bạn không thể xóa !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa24", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        'SQL = "SELECT * FROM MAY_LOAI_BTPN WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        'dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        'While dtReader.Read
        '    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa25", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    dtReader.Close()
        '    Exit Sub
        'End While

        'dtReader.Close()
        SQL = "SELECT * FROM THONG_SO_CHINH_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa26", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'dữ liệu đang được sử dụng o table THONG_SO_CHINH_MAY
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM MAY_PHAN_BO_ATT WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa29", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CONG_VIEC
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        SQL = "SELECT * FROM MAY_ATTACHMENT WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa30", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        SQL = "SELECT * FROM TRUC_CA_CHI_TIET WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa31", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'dữ liệu đang được sử dụng o table TRUC_CA_CHI_TIET
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        SQL = "SELECT * FROM YEU_CAU_NSD_CHI_TIET WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa45", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ' Dữ liệu đang được sử dụng trong yêu cầu người sử dụng ! Bạn không thể xoá !
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        'SQL = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        'dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        'While dtReader.Read
        '    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa46", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    ' Dữ liệu đang được sử dụng trong cấu trúc thiết bị ! Bạn không thể xoá !
        '    dtReader.Close()
        '    Exit Sub
        'End While
        'dtReader.Close()
        SQL = "SELECT * FROM HIEU_CHUAN_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa47", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ' Dữ liệu đang được sử dụng trong hiệu chuẩn thiết bị ! Bạn không thể xoá !
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM THOI_GIAN_NGUNG_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa047", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ' Dữ liệu đang được sử dụng trong Downtime ! Bạn không thể xoá !
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa5", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If traloi = vbNo Then Exit Sub
        Dim sSql As String = ""
        sSql = "DELETE FROM MAY_NHA_XUONG WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        sSql = "DELETE FROM MAY_HE_THONG WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        sSql = "DELETE FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateMAY_LOG", ucDMTBi.txtMS_MAY.Text, Me.Name, Commons.Modules.UserName, 3)

        objMAYController.DeleteMAY(ucDMTBi.txtMS_MAY.Text)



        LoadMay()

    End Sub


    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If ucDMTBi.txtMS_MAY.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucDMTBi.txtMS_MAY.Focus()
            Exit Sub
        End If
        If blnThongtintb = 1 Then
            ucDMTBi.txtMS_MAY.Text = Commons.Modules.ObjSystems.SplitString(ucDMTBi.txtMS_MAY.Text)
            SQL = "SELECT * FROM MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
            Dim dtReader As New DataTable
            dtReader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
            If (dtReader.Rows.Count > 0) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenKT20", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ucDMTBi.txtMS_MAY.Focus()
                Exit Sub
            End If
        End If

        If ucDMTBi.txtTEN_MAY.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "msgChuaNhapTenMay", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucDMTBi.txtTEN_MAY.Focus()
            Exit Sub
        End If

        If ucDMTBi.cboMS_LOAI_MAY.EditValue = Nothing Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucDMTBi.cboMS_LOAI_MAY.Focus()
            Exit Sub
        End If
        If ucDMTBi.cboMS_NHOM_MAY.EditValue = Nothing Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.cboMS_NHOM_MAY.Focus()
            Exit Sub
        End If
        If ucDMTBi.txtNGAY_DUA_VAO_SD.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi4", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.txtNGAY_DUA_VAO_SD.Focus()
            Exit Sub
        End If
        If ucDMTBi.cboMS_HIEN_TRANG.EditValue = Nothing Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi5", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.cboMS_HIEN_TRANG.Focus()
            Exit Sub
        End If
        If ucDMTBi.cboMUC_UU_TIEN.EditValue = Nothing Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi6", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.cboMUC_UU_TIEN.Focus()
            Exit Sub
        End If
        Dim sSql As String
        If ucDMTBi.TxtMS_HE_THONG.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "ChuaNhapHeThong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.TxtMS_HE_THONG.Focus()
            Exit Sub
        End If
        If ucDMTBi.cboMS_DVT_RT.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "msgChuaNhapDonViThoiGian", Commons.Modules.TypeLanguage) + " runtime", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucDMTBi.cboMS_DVT_RT.Focus()
            Exit Sub
        End If

        If ucDMTBi.cmbDVTG.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "msgChuaNhapDonViThoiGian", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucDMTBi.tab.SelectedTabPageIndex = 1
            ucDMTBi.cmbDVTG.Focus()
            Exit Sub
        End If
        If MS_MAY_TMP = "" Then MS_MAY_TMP = ucDMTBi.txtMS_MAY.Text
        If MS_MAY_TMP = "-1" Then MS_MAY_TMP = ucDMTBi.txtMS_MAY.Text

        sSql = "SELECT COUNT(*) FROM  MAY_HE_THONG WHERE MS_MAY = N'" + MS_MAY_TMP + "'"

        sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        If Convert.ToInt16(sSql) = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "ChuaNhapHeThong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.TxtMS_HE_THONG.Focus()
            Exit Sub
        End If

        If ucDMTBi.TxtMS_NHA_XUONG.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi7", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.TxtMS_NHA_XUONG.Focus()
            Exit Sub
        End If

        sSql = "SELECT COUNT(*) FROM  MAY_NHA_XUONG WHERE MS_MAY = N'" + MS_MAY_TMP + "'"

        sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        If Convert.ToInt16(sSql) = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi7", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.TxtMS_NHA_XUONG.Focus()
            Exit Sub
        End If
        If ucDMTBi.TxtMS_BP_CHIU_PHI.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi8", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.TxtMS_BP_CHIU_PHI.Focus()
            Exit Sub
        End If
        sSql = "SELECT COUNT(*) FROM  MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY = N'" + MS_MAY_TMP + "'"
        sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        If Convert.ToInt16(sSql) = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenGhi8", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ucDMTBi.TxtMS_BP_CHIU_PHI.Focus()
            Exit Sub
        End If

        sLoaiMay = CboLoaithietbi.EditValue
        sNoiLapDat = CboNLD.EditValue
        sLine = cboLine.EditValue
        sNhom = CboNhomthietbi.EditValue
        AddMAY()
        capNhat = True
        LoadMay()
        capNhat = False
        blnThongtintb = 0
        VisibleButton(True)
        LockData(True)

        'End If

        LockControl(False)
        ' tab.SelectedTabPageIndex = 0
        ucDMTBi.BtnLoaiTB.Enabled = True
        MS_MAY_TMP = ""


    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        ucDMTBi.BtnLoaiTB.Enabled = True
        Dim sMsMay As String = ucDMTBi.txtMS_MAY.Text
        If grvMay.RowCount <= 0 Then
            LockControl(False)
            'Refesh()
            blnThongtintb = 0
            blnThem = False
            VisibleButton(True)
            LockData(True)
            capNhat = False
            Exit Sub
        End If
        If blnThongtintb = 1 Then
        Else

            If ucDMTBi.TxtMS_NHA_XUONG.Text = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi7", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ucDMTBi.TxtMS_NHA_XUONG.Focus()
                Exit Sub
            End If
            If ucDMTBi.TxtMS_BP_CHIU_PHI.Text = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi8", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ucDMTBi.TxtMS_BP_CHIU_PHI.Focus()
                Exit Sub
            End If

        End If
        sLoaiMay = CboLoaithietbi.EditValue
        sNhom = CboNhomthietbi.EditValue

        sNoiLapDat = CboNLD.EditValue
        sLine = cboLine.EditValue

        'Refesh()
        capNhat = True
        LoadMay()
        blnThongtintb = 0
        VisibleButton(True)
        LockData(True)
        capNhat = False
        Try
            ucDMTBi.txtNgayHHKH.Text = DateSerial(Year(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")) + IIf(IsDBNull(ucDMTBi.txtSO_NAM_KHAU_HAO.Text), 0, ucDMTBi.txtSO_NAM_KHAU_HAO.Text), Month(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")), Day(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")))
            ucDMTBi.txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(ucDMTBi.txtSO_THANG_BH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date)
        Catch ex As Exception
            ucDMTBi.txtNgayHHKH.Text = ""
            ucDMTBi.txtNgayKTBH.Text = ""
        End Try

        Try
            Dim ngay As Date
            ngay = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
            Dim i As Short = DateDiff(DateInterval.Month, ngay, Date.Now)
            Dim j As Short = i Mod 12
            Dim k As Short = (i - j) / 12
            If j > 0 Then
                ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage) & " " & j & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thang_sd", Commons.Modules.TypeLanguage)
            Else
                ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage)
            End If
        Catch ex As Exception
            ucDMTBi.txtSO_NAM_SD.Text = 0
        End Try
        LockControl(False)
        MS_MAY_TMP = ""
        XoaMayKhongCoTrongNXHT(sMsMay)
    End Sub
    Private Sub XoaMayKhongCoTrongNXHT(ByVal sMsMay As String)
        Dim str As String = ""
        str = "Delete A from MAY_NHA_XUONG A WHERE NOT EXISTS (SELECT MS_MAY FROM MAY B WHERE  ( A.MS_MAY = B.MS_MAY )) "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Delete A from MAY_HE_THONG A WHERE NOT EXISTS (SELECT MS_MAY FROM MAY B WHERE  ( A.MS_MAY = B.MS_MAY )) "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Delete A from MAY_BO_PHAN_CHIU_PHI A WHERE NOT EXISTS (SELECT MS_MAY FROM MAY B WHERE ( A.MS_MAY = B.MS_MAY )) "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

    End Sub
    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Application.DoEvents()
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region "Private Methods"
    Sub Refesh()
        ucDMTBi.txtMS_MAY.Text = ""
        ucDMTBi.txtSERIAL_NUMBER.Text = ""
        ucDMTBi.txtTEN_MAY.Text = ""
        ucDMTBi.txtMO_TA.Text = ""
        ucDMTBi.txtMODEL.Text = ""
        ucDMTBi.txtNGAY_SX.Text = ""
        ucDMTBi.txtNUOC_SX.Text = ""
        ucDMTBi.txtNHIEM_VU_THIET_BI.Text = ""
        ucDMTBi.txtNGAY_DUA_VAO_SD.Text = ""
        ucDMTBi.txtSO_NAM_SD.Text = ""
        ucDMTBi.TxtMS_BP_CHIU_PHI.Text = ""
        ucDMTBi.TxtMS_HE_THONG.Text = ""
        ucDMTBi.TxtMS_NHA_XUONG.Text = ""
        ucDMTBi.txtNGAY_BD_BAO_HANH.Text = ""
        ucDMTBi.txtSO_THANG_BH.Text = ""
        ucDMTBi.txtNgayKTBH.Text = ""
        ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text = ""
        ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text = ""
        ucDMTBi.txtSO_THE.Text = ""
        ucDMTBi.txtSoCT.Text = ""
        ucDMTBi.txtNGAY_MUA.Text = ""
        ucDMTBi.txtGIA_MUA.Text = ""
        ucDMTBi.txtTiGiaVND.Text = ""
        ucDMTBi.txtTiGiaUSD.Text = ""
        ucDMTBi.txtSO_NAM_KHAU_HAO.Text = ""
        ucDMTBi.txtNgayHHKH.Text = ""
        ucDMTBi.txtTY_LE_CON_LAI.Text = ""
        ucDMTBi.txtNgayHCtieptheo.Text = ""
        ucDMTBi.txtCKHCTB_Ngoai_Ngay_TT.Text = ""
        ucDMTBi.txtCKKDTB_NGAY_TT.Text = ""
        ucDMTBi.cboMS_HIEN_TRANG.EditValue = "-1"
        ucDMTBi.cboMS_NCC.EditValue = "-1"
        ucDMTBi.CboMS_HSX.EditValue = -1
        ucDMTBi.cboMUC_UU_TIEN.EditValue = "-1"
        txtMS_BO_PHAN.Text = ""
        txtTEN_BO_PHAN.Text = ""
        txtSO_LUONG.Text = 0
        txtGHI_CHU.Text = ""
        TxtHINH.Text = ""
        ucDMTBi.txtChukyHC.Text = ""
        grdThongSoBP.DataSource = System.DBNull.Value
        grdCTTB_PT.DataSource = System.DBNull.Value
        CboPT_BP.EditValue = "-1"
        cboClass.EditValue = -1
        ucDMTBi.txtUInsert.Text = ""
        ucDMTBi.txtUUpdate.Text = ""
        ucDMTBi.txtNInsert.Text = ""
        ucDMTBi.txtNUpdate.Text = ""
    End Sub

    Sub ShowMAY()
        If grvMay.RowCount <= 0 Then
            Dim str As String = ""
            Refesh()
            txtM0.Text = ""
            ucDMTBi.txtSO_NAM_KHAU_HAO.Text = 0
            ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text = 0
            ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text = 0
            ucDMTBi.txtSO_THANG_BH.Text = 0
            ucDMTBi.txtGIA_MUA.Text = 0
            ucDMTBi.txtTiGiaVND.Text = 0
            ucDMTBi.txtTiGiaUSD.Text = 0
            ucDMTBi.txtChukyHC.Text = 0
            ucDMTBi.txtCKHCTB_Ngoai.Text = 0
            ucDMTBi.txtCKKDTB.Text = 0
            ucDMTBi.txtSO_NAM_KHAU_HAO.Text = 0
            ucDMTBi.txtTY_LE_CON_LAI.Text = 100
            ucDMTBi.cboMS_NCC.Text = String.Empty
            ucDMTBi.LoadTextTrang()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        'If txtM0.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
        Try
            ucDMTBi.txtMS_MAY.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            txtM0.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            ucDMTBi.txtTEN_MAY.Text = grvMay.GetFocusedRowCellValue("TEN_MAY").ToString()
            Try
                ucDMTBi.cboMS_LOAI_MAY.EditValue = grvMay.GetFocusedRowCellValue("MS_LOAI_MAY").ToString()
                ucDMTBi.cboMS_NHOM_MAY.EditValue = grvMay.GetFocusedRowCellValue("MS_NHOM_MAY").ToString()

            Catch ex As Exception

            End Try
            If String.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("TEN_HSX").ToString()) Then ucDMTBi.CboMS_HSX.EditValue = -99 Else ucDMTBi.CboMS_HSX.Text = grvMay.GetFocusedRowCellValue("TEN_HSX").ToString()

            ucDMTBi.cboMS_HIEN_TRANG.EditValue = grvMay.GetFocusedRowCellValue("MS_HIEN_TRANG")

            If String.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("TEN_CONG_TY").ToString()) Then ucDMTBi.cboMS_NCC.EditValue = "-99" Else ucDMTBi.cboMS_NCC.Text = grvMay.GetFocusedRowCellValue("TEN_CONG_TY").ToString()

            ucDMTBi.txtSO_NAM_KHAU_HAO.Text = grvMay.GetFocusedRowCellValue("SO_NAM_KHAU_HAO").ToString()
            ucDMTBi.txtMO_TA.Text = grvMay.GetFocusedRowCellValue("MO_TA").ToString()
            ucDMTBi.txtNHIEM_VU_THIET_BI.Text = grvMay.GetFocusedRowCellValue("NHIEM_VU_THIET_BI").ToString()
            ucDMTBi.txtMODEL.Text = grvMay.GetFocusedRowCellValue("MODEL").ToString()
            ucDMTBi.txtSERIAL_NUMBER.Text = grvMay.GetFocusedRowCellValue("SERIAL_NUMBER").ToString()

            If grvMay.GetFocusedRowCellValue("NGAY_SX").ToString() <> "" Then ucDMTBi.txtNGAY_SX.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_SX").ToString()) Else ucDMTBi.txtNGAY_SX.Text = ""


            ucDMTBi.txtNUOC_SX.Text = grvMay.GetFocusedRowCellValue("NUOC_SX").ToString()

            If grvMay.GetFocusedRowCellValue("NGAY_BD_BAO_HANH").ToString() <> "" Then ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_BD_BAO_HANH").ToString()) Else ucDMTBi.txtNGAY_BD_BAO_HANH.Text = ""

            If grvMay.GetFocusedRowCellValue("NGAY_DUA_VAO_SD").ToString() <> "" Then ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_DUA_VAO_SD").ToString()) Else ucDMTBi.txtNGAY_DUA_VAO_SD.Text = ""


            ucDMTBi.txtSO_THE.Text = grvMay.GetFocusedRowCellValue("SO_THE").ToString()
            ucDMTBi.txtSoCT.Text = grvMay.GetFocusedRowCellValue("SO_CT").ToString()
            ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text = grvMay.GetFocusedRowCellValue("SO_NGAY_LV_TRONG_TUAN").ToString()
            ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text = grvMay.GetFocusedRowCellValue("SO_GIO_LV_TRONG_NGAY").ToString()
            'Row("MS_DVT_RT") = "-99"
            'Row("TEN_DVT_RT") = ""
            If grvMay.GetFocusedRowCellValue("TEN_DVT_RT").ToString() = "" Then
                ucDMTBi.cboMS_DVT_RT.EditValue = -99
            Else
                ucDMTBi.cboMS_DVT_RT.Text = grvMay.GetFocusedRowCellValue("TEN_DVT_RT").ToString()

            End If

            Try
                ucDMTBi.txtDinhMucSL.Text = grvMay.GetFocusedRowCellValue("DINH_MUC_SL").ToString()
                ucDMTBi.cmbDVTSL.Text = grvMay.GetFocusedRowCellValue("DVT_SL").ToString()
                ucDMTBi.cmbDVTG.EditValue = Convert.ToInt32(grvMay.GetFocusedRowCellValue("DON_VI_THOI_GIAN").ToString())

            Catch
                ucDMTBi.cmbDVTG.EditValue = 0

            End Try

            ucDMTBi.txtTY_LE_CON_LAI.Text = grvMay.GetFocusedRowCellValue("TY_LE_CON_LAI").ToString()
            ucDMTBi.cboMUC_UU_TIEN.Text = grvMay.GetFocusedRowCellValue("TEN_UU_TIEN").ToString()
            ucDMTBi.txtSO_THANG_BH.Text = grvMay.GetFocusedRowCellValue("SO_THANG_BH").ToString()
            ucDMTBi.txtGIA_MUA.Text = grvMay.GetFocusedRowCellValue("GIA_MUA").ToString()
            ucDMTBi.txtTiGiaVND.Text = grvMay.GetFocusedRowCellValue("TI_GIA_VND").ToString()
            If String.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("TI_GIA_USD").ToString()) = False Then
                ucDMTBi.txtTiGiaUSD.Text = CType(grvMay.GetFocusedRowCellValue("TI_GIA_USD").ToString(), Double).ToString("###,##0.######")
            Else
                ucDMTBi.txtTiGiaUSD.Text = String.Empty
            End If
            ucDMTBi.cboNGOAI_TE.Text = IIf(IsDBNull(grvMay.GetFocusedRowCellValue("NGOAI_TE").ToString()), "", grvMay.GetFocusedRowCellValue("NGOAI_TE").ToString())
            ucDMTBi.txtChukyHC.Text = grvMay.GetFocusedRowCellValue("CHU_KY_HC_TB").ToString()


            If Tabthietbi.SelectedTabPageIndex = 4 Then
                Dim dtRead As New DataTable
                Dim SQL As String = "Select ISNULL(LUU_Y_SU_DUNG, '') LUU_Y_SU_DUNG FROM MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
                dtRead.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
                txtLuuY.Text = IIf(dtRead.Rows.Count > 0, dtRead.Rows(0)("LUU_Y_SU_DUNG"), grvMay.GetFocusedDataRow()("LUU_Y_SU_DUNG"))
            End If




            ucDMTBi.txtCKHCTB_Ngoai.Text = grvMay.GetFocusedRowCellValue("CHU_KY_HIEU_CHUAN_TB_NGOAI").ToString()
            ucDMTBi.txtCKKDTB.Text = grvMay.GetFocusedRowCellValue("CHU_KY_KD_TB").ToString()
            If ucDMTBi.chkHienthihinhTB.Checked Then
                ucDMTBi.PtcAnhTB.ImageLocation = grvMay.GetFocusedRowCellValue("Anh_TB").ToString()
            Else
                ucDMTBi.PtcAnhTB.ImageLocation = ""
            End If
            InitMayHeThongBPCPNhaXuongTmp(ucDMTBi.txtMS_MAY.Text)
            Try
                If grvMay.GetFocusedRowCellValue("NGAY_DUA_VAO_SD").ToString() <> "" Then
                    dtpTuNgay1.DateTime = DateTime.Parse(grvMay.GetFocusedRowCellValue("NGAY_DUA_VAO_SD").ToString())
                    txtTu_Ngay7.DateTime = DateTime.Parse(grvMay.GetFocusedRowCellValue("NGAY_DUA_VAO_SD").ToString())
                End If
            Catch ex As Exception

            End Try
            Try
                _MS_LOAI_MAY = ucDMTBi.cboMS_LOAI_MAY.EditValue.ToString
            Catch ex As Exception

            End Try
            Try
                _MS_NHOM_MAY = ucDMTBi.cboMS_NHOM_MAY.EditValue.ToString
            Catch ex As Exception

            End Try
            If String.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("USER_INSERT").ToString()) Then _
                    ucDMTBi.txtUInsert.Text = "" Else ucDMTBi.txtUInsert.Text = grvMay.GetFocusedRowCellValue("USER_INSERT").ToString()
            If String.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("NGAY_INSERT").ToString()) Then _
                    ucDMTBi.txtNInsert.Text = "" Else ucDMTBi.txtNInsert.Text = grvMay.GetFocusedRowCellValue("NGAY_INSERT").ToString()


            If String.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("USER_UPDATE").ToString()) Then _
                    ucDMTBi.txtUUpdate.Text = "" Else ucDMTBi.txtUUpdate.Text = grvMay.GetFocusedRowCellValue("USER_UPDATE").ToString()
            If String.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("NGAY_UPDATE").ToString()) Then _
                    ucDMTBi.txtNUpdate.Text = "" Else ucDMTBi.txtNUpdate.Text = grvMay.GetFocusedRowCellValue("NGAY_UPDATE").ToString()


            If grvMay.GetFocusedRowCellValue("NGAY_MUA").ToString() <> "" Then ucDMTBi.txtNGAY_MUA.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_MUA").ToString()) Else ucDMTBi.txtNGAY_MUA.Text = ""

            Try
                ucDMTBi.txtNgayHHKH.Text = DateSerial(Year(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")) + CType(IIf(ucDMTBi.txtSO_NAM_KHAU_HAO.Text = "", 0, ucDMTBi.txtSO_NAM_KHAU_HAO.Text), Integer), Month(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")), Day(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")))
            Catch ex As Exception
                ucDMTBi.txtNgayHHKH.Text = ""
            End Try

            Try
                ucDMTBi.txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(ucDMTBi.txtSO_THANG_BH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date)
            Catch ex As Exception
                ucDMTBi.txtNgayKTBH.Text = ""
            End Try


            If grvMay.RowCount <= 0 Then
                tvwCTTBi.Nodes.Clear()
            End If

            Try
                Dim ngay As Date
                ngay = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
                Dim i As Short = DateDiff(DateInterval.Month, ngay, Date.Now)
                Dim j As Short = i Mod 12
                Dim k As Short = (i - j) / 12
                If j > 0 Then
                    ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage) & " " & j & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thang_sd", Commons.Modules.TypeLanguage)
                Else
                    ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage)
                End If
            Catch ex As Exception
                ucDMTBi.txtSO_NAM_SD.Text = 0
            End Try
            If Commons.Modules.sPrivate.ToUpper = "BHS" Then
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CMMS_PROC_INSERT_TB_MAY", ucDMTBi.txtMS_MAY.Text, ucDMTBi.txtTEN_MAY.Text,
                        ucDMTBi.txtMO_TA.Text, ucDMTBi.txtNHIEM_VU_THIET_BI.Text)
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception

        End Try
        ShowMayTab2()
        lblTongSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTongSo", Commons.Modules.TypeLanguage) & " : " & grvMay.RowCount
        Me.Cursor = Cursors.Default

    End Sub

    Sub ShowMayTab2()
        Try
            ucDMTBi.txtNgayHCtieptheo.Text = ""
            ucDMTBi.txtCKHCTB_Ngoai_Ngay_TT.Text = ""
            ucDMTBi.txtCKKDTB_NGAY_TT.Text = ""

            ucDMTBi.txtNgayHHKH.Text = DateSerial(Year(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")) + CType(IIf(ucDMTBi.txtSO_NAM_KHAU_HAO.Text = "", 0, ucDMTBi.txtSO_NAM_KHAU_HAO.Text), Integer), Month(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")), Day(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")))
            ucDMTBi.txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(ucDMTBi.txtSO_THANG_BH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date)
            ' Lấy ngày hiệu chuẩn gần nhất
            ucDMTBi.txtNgayHCCuoi.Text = Format(New MAYController().GetNGAY_HC_MAX_of_TB(ucDMTBi.txtMS_MAY.Text, 1), "short date")
            ucDMTBi.txtCKHCTB_Ngoai_Ngay_GN.Text = Format(New MAYController().GetNGAY_HC_MAX_of_TB(ucDMTBi.txtMS_MAY.Text, 2), "short date")
            ucDMTBi.txtCKKDTB_Ngay_GN.Text = Format(New MAYController().GetNGAY_HC_MAX_of_TB(ucDMTBi.txtMS_MAY.Text, 3), "short date")
            ' Lấy ngày hiệu chuẩn tiếp theo
            Dim intChuKyHC As Integer = 0
            Dim dvtg As Short = 1
            Dim dates As Date
            If ucDMTBi.txtNgayHCCuoi.Text <> "" Then
                If ucDMTBi.txtChukyHC.Text <> "" Then
                    intChuKyHC = CType(ucDMTBi.txtChukyHC.Text, Integer)
                End If
                dvtg = Convert.ToInt16(ucDMTBi.cmbDVTG.EditValue)
                Select Case dvtg
                    Case 1
                        dates = Convert.ToDateTime(ucDMTBi.txtNgayHCCuoi.Text).AddDays(intChuKyHC)
                    Case 2
                        dates = Convert.ToDateTime(ucDMTBi.txtNgayHCCuoi.Text).AddDays(intChuKyHC * 7)
                    Case 3
                        dates = Convert.ToDateTime(ucDMTBi.txtNgayHCCuoi.Text).AddMonths(intChuKyHC)
                    Case 4
                        dates = Convert.ToDateTime(ucDMTBi.txtNgayHCCuoi.Text).AddYears(intChuKyHC)
                End Select
                ucDMTBi.txtNgayHCtieptheo.Text = dates
            End If


            If ucDMTBi.txtCKHCTB_Ngoai_Ngay_GN.Text <> "" Then
                If ucDMTBi.txtCKHCTB_Ngoai.Text <> "" Then
                    intChuKyHC = CType(ucDMTBi.txtCKHCTB_Ngoai.Text, Integer)
                End If
                dvtg = Convert.ToInt16(ucDMTBi.cmbDVTG.EditValue)
                Select Case dvtg
                    Case 1
                        dates = Convert.ToDateTime(ucDMTBi.txtCKHCTB_Ngoai_Ngay_GN.Text).AddDays(intChuKyHC)
                    Case 2
                        dates = Convert.ToDateTime(ucDMTBi.txtCKHCTB_Ngoai_Ngay_GN.Text).AddDays(intChuKyHC * 7)
                    Case 3
                        dates = Convert.ToDateTime(ucDMTBi.txtCKHCTB_Ngoai_Ngay_GN.Text).AddMonths(intChuKyHC)
                    Case 4
                        dates = Convert.ToDateTime(ucDMTBi.txtCKHCTB_Ngoai_Ngay_GN.Text).AddYears(intChuKyHC)
                End Select
                ucDMTBi.txtCKHCTB_Ngoai_Ngay_TT.Text = dates
            End If

            If ucDMTBi.txtCKKDTB_Ngay_GN.Text <> "" Then
                If ucDMTBi.txtCKKDTB.Text <> "" Then
                    intChuKyHC = CType(ucDMTBi.txtCKKDTB.Text, Integer)
                End If
                dvtg = Convert.ToInt16(ucDMTBi.cmbDVTG.EditValue)
                Select Case dvtg
                    Case 1
                        dates = Convert.ToDateTime(ucDMTBi.txtCKKDTB_Ngay_GN.Text).AddDays(intChuKyHC)
                    Case 2
                        dates = Convert.ToDateTime(ucDMTBi.txtCKKDTB_Ngay_GN.Text).AddDays(intChuKyHC * 7)
                    Case 3
                        dates = Convert.ToDateTime(ucDMTBi.txtCKKDTB_Ngay_GN.Text).AddMonths(intChuKyHC)
                    Case 4
                        dates = Convert.ToDateTime(ucDMTBi.txtCKKDTB_Ngay_GN.Text).AddYears(intChuKyHC)
                End Select
                ucDMTBi.txtCKKDTB_NGAY_TT.Text = dates
            End If

            Try
                Dim ngay As Date
                ngay = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
                Dim i As Short = DateDiff(DateInterval.Month, ngay, Date.Now)
                Dim j As Short = i Mod 12
                Dim k As Short = (i - j) / 12
                If j > 0 Then
                    ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage) & " " & j & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thang_sd", Commons.Modules.TypeLanguage)
                Else
                    ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage)
                End If
            Catch ex As Exception
                ucDMTBi.txtSO_NAM_SD.Text = 0
            End Try
            lstMayChange = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadLoaiMay()
        Dim dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", Commons.Modules.UserName))
        Dim drRow As DataRow = dtTmp.NewRow
        drRow("MS_LOAI_MAY") = "-1"
        drRow("TEN_LOAI_MAY") = " < ALL > "
        drRow("USERNAME") = Commons.Modules.UserName
        dtTmp.Rows.Add(drRow)
        dtTmp.DefaultView.Sort = "TEN_LOAI_MAY"
        dtTmp = dtTmp.DefaultView.ToTable()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(CboLoaithietbi, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "")
    End Sub

    Public Sub LoadNLD()

        'Dim _table As DataTable = New DataTable()
        '_table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))

        ''Commons.Modules.ObjSystems.MLoadLookUpEdit(CboNLD, _table, "MS_N_XUONG", "TEN_N_XUONG", "")
        'Commons.Modules.ObjSystems.MLoadCboTreeList(CboNLD, _table, "MS_N_XUONG", "TEN_N_XUONG", "")
        If Not String.IsNullOrEmpty(CboNLD.TextValue) Then Exit Sub

        Dim dtTmp As New DataTable
        dtTmp = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", 1, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadCboTreeList(CboNLD, dtTmp, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
        CboNLD.SelectedIndex = 1
        loadCboHeThong()
    End Sub

    Public Sub LoadCLASS_HCG()
        Try
            Dim TB_CLASS As DataTable = New DataTable()
            TB_CLASS.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM CLASS_LIST ORDER BY CLASS_NAME "))
            Dim row As DataRow = TB_CLASS.NewRow()
            row("CLASS_ID") = "-1"
            row("CLASS_NAME") = ""
            row("CLASS_CODE") = ""
            TB_CLASS.Rows.InsertAt(row, 0)
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboClass, TB_CLASS, "CLASS_ID", "CLASS_NAME", "")
        Catch ex As Exception

        End Try

    End Sub

    Sub CreateData()
        Try
            LoadLoaiMay()
            ucDMTBi.LoadLoaiMay2()
            LoadNhomTB()
            ucDMTBi.LoadNhomMay()
            LoadNLD()
            ucDMTBi.LoadNCC()
            ucDMTBi.LoadNSX()
            ucDMTBi.LoadHIEN_TRANG_SD_MAY()
            ucDMTBi.LoadMUC_UU_TIEN()
            ucDMTBi.LoadDON_VI_TINH_RUN_TIME()
            ucDMTBi.LoadNGOAI_TE()
            LoadCLASS_HCG()
        Catch ex As Exception

        End Try

    End Sub

    Sub AddMAY()
        Dim objMAYInfo As New MAYInfo
        Dim objMAYController As New MAYController()
        Try

            objMAYInfo.MS_MAY = ucDMTBi.txtMS_MAY.Text
            objMAYInfo.TEN_MAY = ucDMTBi.txtTEN_MAY.Text
            objMAYInfo.MS_NHOM_MAY = ucDMTBi.cboMS_NHOM_MAY.EditValue
            objMAYInfo.MS_HSX = ucDMTBi.CboMS_HSX.EditValue
            objMAYInfo.MS_HIEN_TRANG = ucDMTBi.cboMS_HIEN_TRANG.EditValue
            objMAYInfo.MS_KH = ucDMTBi.cboMS_NCC.EditValue
            objMAYInfo.SO_NAM_KHAU_HAO = CType(IIf(ucDMTBi.txtSO_NAM_KHAU_HAO.Text = "", 0, ucDMTBi.txtSO_NAM_KHAU_HAO.Text), Integer)
            objMAYInfo.MO_TA = ucDMTBi.txtMO_TA.Text
            objMAYInfo.NHIEM_VU_THIET_BI = ucDMTBi.txtNHIEM_VU_THIET_BI.Text
            objMAYInfo.MODEL = ucDMTBi.txtMODEL.Text
            objMAYInfo.SERIAL_NUMBER = ucDMTBi.txtSERIAL_NUMBER.Text
            objMAYInfo.NGAY_SX = IIf(IsDate(ucDMTBi.txtNGAY_SX.Text), ucDMTBi.txtNGAY_SX.Text, Now.Date)
            objMAYInfo.NUOC_SX = ucDMTBi.txtNUOC_SX.Text
            objMAYInfo.NGAY_MUA = IIf(IsDate(ucDMTBi.txtNGAY_MUA.Text), ucDMTBi.txtNGAY_MUA.DateTime.Date, Now.Date)
            objMAYInfo.NGAY_BD_BAO_HANH = IIf(IsDate(ucDMTBi.txtNGAY_BD_BAO_HANH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date, Now.Date)
            objMAYInfo.NGAY_DUA_VAO_SD = IIf(IsDate(ucDMTBi.txtNGAY_DUA_VAO_SD.Text), ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, Now.Date)
            objMAYInfo.SO_THE = ucDMTBi.txtSO_THE.Text
            objMAYInfo.SO_CT = ucDMTBi.txtSoCT.Text
            objMAYInfo.SO_NGAY_LV_TRONG_TUAN = CType(IIf(ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text = "", 0, ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text), Integer)
            objMAYInfo.SO_GIO_LV_TRONG_NGAY = CType(IIf(ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text = "", 0, ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text), Integer)
            objMAYInfo.MS_DVT_RT = ucDMTBi.cboMS_DVT_RT.EditValue
            objMAYInfo.TY_LE_CON_LAI = ucDMTBi.txtTY_LE_CON_LAI.Text
            objMAYInfo.MUC_UU_TIEN = ucDMTBi.cboMUC_UU_TIEN.EditValue
            objMAYInfo.SO_THANG_BH = CType(IIf(ucDMTBi.txtSO_THANG_BH.Text = "", 0, ucDMTBi.txtSO_THANG_BH.Text), Integer)
            objMAYInfo.GIA_MUA = CType(IIf(ucDMTBi.txtGIA_MUA.Text = "", 0, ucDMTBi.txtGIA_MUA.Text), Double)
            objMAYInfo.TI_GIA_VND = CType(IIf(ucDMTBi.txtTiGiaVND.Text = "", 0, ucDMTBi.txtTiGiaVND.Text), Double)
            objMAYInfo.TI_GIA_USD = CType(IIf(ucDMTBi.txtTiGiaUSD.Text = "", 0, ucDMTBi.txtTiGiaUSD.Text), Double)
            objMAYInfo.NGOAI_TE = ucDMTBi.cboNGOAI_TE.EditValue
            objMAYInfo.MS_MAY_TMP = MS_MAY_TMP
            objMAYInfo.CHU_KY_HC_TB = IIf(ucDMTBi.txtChukyHC.Text = "", 0, ucDMTBi.txtChukyHC.Text)
            objMAYInfo.CHU_KY_HC_TB_NGOAI = IIf(ucDMTBi.txtCKHCTB_Ngoai.Text = "", 0, ucDMTBi.txtCKHCTB_Ngoai.Text)
            objMAYInfo.CHU_KY_KD_TB = IIf(ucDMTBi.txtCKKDTB.Text = "", 0, ucDMTBi.txtCKKDTB.Text)
            objMAYInfo.DON_VI_TG = ucDMTBi.cmbDVTG.EditValue

            If objMAYInfo.MS_HSX = "-1" Then objMAYInfo.MS_HSX = Nothing

            If blnThongtintb = 2 Then
                objMAYController.UpdateMAY(objMAYInfo)
            ElseIf blnThongtintb = 1 Then
                objMAYController.AddMAY(objMAYInfo)
            End If

            SQL = "UPDATE MAY SET DINH_MUC_SL=N'" & ucDMTBi.txtDinhMucSL.Text & "', DVT_SL= '" & ucDMTBi.cmbDVTSL.EditValue & "' WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

            SQL = "UPDATE MAY_HE_THONG SET MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' WHERE MS_MAY=N'" & MS_MAY_TMP & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

            SQL = "UPDATE MAY_NHA_XUONG SET MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' WHERE MS_MAY=N'" & MS_MAY_TMP & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

            SQL = "UPDATE MAY_BO_PHAN_CHIU_PHI SET MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' WHERE MS_MAY=N'" & MS_MAY_TMP & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

            SQL = "UPDATE CAU_TRUC_THIET_BI SET MS_BO_PHAN_CHA=N'" & ucDMTBi.txtMS_MAY.Text & "' WHERE MS_BO_PHAN_CHA=N'" & MS_MAY_TMP & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)


            InitMayHeThongBPCPNhaXuongTmp(ucDMTBi.txtMS_MAY.Text)

            'Cap nhap user update 
            Try
                If (Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu.Trim() <> "") Then
                    SQL = "update MAY set TEN_MAY_ANH = N'" + Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu + "' where MS_MAY =N'" + objMAYInfo.MS_MAY + "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
                End If

                If blnThongtintb = 2 Then
                    SQL = "UPDATE MAY SET USER_UPDATE = N'" & Commons.Modules.UserName & "' WHERE MS_MAY =N'" & objMAYInfo.MS_MAY & "'"
                ElseIf blnThongtintb = 1 Then
                    SQL = "UPDATE MAY SET USER_INSERT = N'" & Commons.Modules.UserName & "' WHERE MS_MAY =N'" & objMAYInfo.MS_MAY & "'"
                End If
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

            Catch ex As Exception

            End Try

            Try
                If blnThongtintb = 2 Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateMAY_LOG", objMAYInfo.MS_MAY, Me.Name, Commons.Modules.UserName, 2)
                ElseIf blnThongtintb = 1 Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateMAY_LOG", objMAYInfo.MS_MAY, Me.Name, Commons.Modules.UserName, 1)
                End If
            Catch ex As Exception

            End Try


            MS_MAY_TMP_SET = ucDMTBi.txtMS_MAY.Text
            XoaMayKhongCoTrongNXHT(ucDMTBi.txtMS_MAY.Text)

            Refesh()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
        BtnTaoMoiTB.Visible = blnVisible
        btnCopyTB.Visible = blnVisible
    End Sub

    Sub LockData(ByVal blnLock As Boolean)
        Dim TB_CHECK As DataTable = New DataTable()
        TB_CHECK.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text.Trim() & "'"))
        If (TB_CHECK.Rows.Count > 0) Then
            ucDMTBi.txtMS_MAY.Properties.ReadOnly = True
        Else
            ucDMTBi.txtMS_MAY.Properties.ReadOnly = blnLock
        End If
        'ucDMTBi.cboMS_NHOM_MAY.Properties.ReadOnly = blnLock
        'cboMS_LOAI_MAY.Properties.ReadOnly = blnLock

        ucDMTBi.cboMS_NHOM_MAY.Enabled = Not blnLock
        ucDMTBi.cboMS_LOAI_MAY.Enabled = Not blnLock

        ucDMTBi.cboNGOAI_TE.Enabled = Not blnLock
        ucDMTBi.cboMUC_UU_TIEN.Enabled = Not blnLock
        ucDMTBi.cmbDVTSL.Enabled = Not blnLock
        ucDMTBi.cmbDVTG.Enabled = Not blnLock
        ucDMTBi.CboMS_HSX.Enabled = Not blnLock
        ucDMTBi.cboMS_HIEN_TRANG.Enabled = Not blnLock
        ucDMTBi.cboMS_NCC.Enabled = Not blnLock
        ucDMTBi.cboMS_DVT_RT.Enabled = Not blnLock

        ucDMTBi.txtSO_NAM_KHAU_HAO.Properties.ReadOnly = blnLock
        ucDMTBi.txtTEN_MAY.Properties.ReadOnly = blnLock
        ucDMTBi.txtMO_TA.Properties.ReadOnly = blnLock
        ucDMTBi.txtNHIEM_VU_THIET_BI.Properties.ReadOnly = blnLock
        ucDMTBi.txtMODEL.Properties.ReadOnly = blnLock
        ucDMTBi.txtSERIAL_NUMBER.Properties.ReadOnly = blnLock

        ucDMTBi.btnChenhinh.Enabled = Not blnLock
        ucDMTBi.btnXoahinh.Enabled = Not blnLock

        ucDMTBi.txtNGAY_SX.Properties.ReadOnly = blnLock
        ucDMTBi.txtNGAY_SX.Properties.Buttons(0).Enabled = Not blnLock

        ucDMTBi.txtNUOC_SX.Properties.ReadOnly = blnLock
        ucDMTBi.txtNGAY_MUA.Properties.ReadOnly = blnLock
        ucDMTBi.txtNGAY_MUA.Properties.Buttons(0).Enabled = Not blnLock


        ucDMTBi.txtNGAY_BD_BAO_HANH.Properties.ReadOnly = blnLock
        ucDMTBi.txtNGAY_BD_BAO_HANH.Properties.Buttons(0).Enabled = Not blnLock

        ucDMTBi.txtNGAY_DUA_VAO_SD.Properties.ReadOnly = blnLock
        ucDMTBi.txtNGAY_DUA_VAO_SD.Properties.Buttons(0).Enabled = Not blnLock

        ucDMTBi.txtSO_THE.Properties.ReadOnly = blnLock
        ucDMTBi.txtSoCT.Properties.ReadOnly = blnLock
        ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Properties.ReadOnly = blnLock
        ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Properties.ReadOnly = blnLock

        ucDMTBi.txtDinhMucSL.Properties.ReadOnly = blnLock
        ucDMTBi.txtTY_LE_CON_LAI.Properties.ReadOnly = blnLock

        ucDMTBi.txtSO_THANG_BH.Properties.ReadOnly = blnLock
        ucDMTBi.txtGIA_MUA.Properties.ReadOnly = blnLock
        ucDMTBi.txtTiGiaVND.Properties.ReadOnly = blnLock
        ucDMTBi.txtTiGiaUSD.Properties.ReadOnly = blnLock

        ucDMTBi.txtChukyHC.Properties.ReadOnly = blnLock
        ucDMTBi.txtCKHCTB_Ngoai.Properties.ReadOnly = blnLock
        ucDMTBi.txtCKKDTB.Properties.ReadOnly = blnLock

    End Sub
#End Region

#Region "TAM"
    Private Function KiemTraSLDaSuDung() As String
        Dim dtReader As SqlDataReader
        SQL = "SELECT * FROM CONG_VIEC_HANG_NGAY_THIET_BI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa35", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM LICH_TAU_THIET_BI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Thiết bị này đang được sử dụng trong thời gian chạy máy ! bạn không thể xóa !
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        '
        SQL = "SELECT * FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Thiết bị này đang được sử dụng trong phiếu bảo trì ! Bạn không thể xóa !
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa23", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()

        SQL = "SELECT * FROM KE_HOACH_TONG_THE WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Thiết bị này đang được sử dụng trong kế hoạch tổng thể ! Bạn không thể xóa !
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa24", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()

        SQL = "SELECT * FROM MAY_LOAI_BTPN WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa25", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM THONG_SO_CHINH_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            'dữ liệu đang được sử dụng o table THONG_SO_CHINH_MAY
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa26", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM MAY_TAI_LIEU WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            'dữ liệu đang được sử dụng o table MAY_TAI_LIEU
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa27", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM THONG_SO_BO_PHAN WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            'dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CHU_KY
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa28", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM chu_ky_hieu_chuan WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            'dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CHU_KY
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa28", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM MAY_PHAN_BO_ATT WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            'dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CONG_VIEC
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa29", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM MAY_ATTACHMENT WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            'dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa30", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM TRUC_CA_CHI_TIET WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            'dữ liệu đang được sử dụng o table TRUC_CA_CHI_TIET
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa31", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM YEU_CAU_NSD_CHI_TIET WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Dữ liệu đang được sử dụng trong yêu cầu người sử dụng ! Bạn không thể xoá !
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa45", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Dữ liệu đang được sử dụng trong cấu trúc thiết bị ! Bạn không thể xoá !
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa46", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        SQL = "SELECT * FROM HIEU_CHUAN_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Dữ liệu đang được sử dụng trong hiệu chuẩn thiết bị ! Bạn không thể xoá !
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa47", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()

        SQL = "SELECT * FROM THOI_GIAN_NGUNG_MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Dữ liệu đang được sử dụng trong Downtime ! Bạn không thể xoá !
            dtReader.Close()
            Return Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa047", Commons.Modules.TypeLanguage)
        End While
        dtReader.Close()
        Return ""
    End Function


    Private Sub CboNhomthietbi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        'If RadLTB.Checked = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        LoadMay()
        If grvMay.RowCount <= 0 Then
            grdChuKiHC.DataSource = System.DBNull.Value
            grdLoaiBTPN_CV.DataSource = System.DBNull.Value
            grdTaiLieuTS.DataSource = System.DBNull.Value
            grdLoaiBTPN_PT.DataSource = System.DBNull.Value
            grdLoaiBTPN.DataSource = System.DBNull.Value
            grdThongSoBP.DataSource = System.DBNull.Value
            grdThongSoMay.DataSource = System.DBNull.Value
            grdCTTB_PT.DataSource = System.DBNull.Value
            tvwCTTBi.Nodes.Clear()
            tvwCTTBi.RefreshDataSource()
        End If
        flag_nhom = False
        Commons.Modules.SQLString = ""
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub btnXoahinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnXemlon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmXemHinh.Show()
        frmXemHinh.PctHinh.ImageLocation = ucDMTBi.PtcAnhTB.ImageLocation
    End Sub

    Private Sub chkHienthihinhTB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '''''If LstMAY.Items.Count <= 0 Then
        If grvMay.RowCount <= 0 Then Exit Sub
        If ucDMTBi.chkHienthihinhTB.Checked Then
            ucDMTBi.PtcAnhTB.ImageLocation = grvMay.GetFocusedRowCellValue("Anh_TB").ToString()   'LstMAY.SelectedItem("ANH_TB").ToString
        Else
            ucDMTBi.PtcAnhTB.ImageLocation = ""
        End If
    End Sub

    Private Sub btnThoat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat1.Click
        blnThoat = True
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub HideButton1(ByVal An As Boolean)
        btnThemsua1.Visible = Not An
        btnGhi1.Visible = An
        btnKhongghi1.Visible = An
        BtnXemTL.Visible = Not An
        btnOpen.Visible = Not An
        btnThoat1.Visible = Not An
        btnXoa1.Visible = Not An
        BtnTSBP.Visible = Not An
        chxAnToan.Enabled = An
        txtSearchTL.Visible = Not An
    End Sub


    Sub BindData1()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub


        grdThongSoMay.DataSource = Nothing
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongSoMay, grvThongSoMay, New MAYController().GetTHONG_SO_CHINH_MAYs(ucDMTBi.txtMS_MAY.Text), False, False, False, False, True, Me.Name)

        Dim cbo As New RepositoryItemLookUpEdit()
        cbo.Name = "cboThongSoTB"
        cbo.ValueMember = "MS_THONG_SO_MAY"
        cbo.NullText = ""
        cbo.DisplayMember = "TEN_THONG_SO_MAY"
        cbo.DataSource = New MAYController().GetTHONG_SO_MAYs
        cbo.PopulateColumns()
        cbo.Columns("MS_THONG_SO_MAY").Visible = False
        cbo.Columns("TEN_THONG_SO_MAY").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_THONG_SO_MAY", Commons.Modules.TypeLanguage)

        grvThongSoMay.Columns("MS_THONG_SO_MAY").ColumnEdit = cbo
        grvThongSoMay.Columns("MS_THONG_SO_MAY").OptionsColumn.ReadOnly = False
        grvThongSoMay.Columns("MS_THONG_SO_MAY").OptionsColumn.AllowEdit = True
        Me.grvThongSoMay.Columns("MS_MAY").Visible = False

        Bind_AnToan(ucDMTBi.txtMS_MAY.Text)

        Me.grvThongSoMay.Columns("MS_THONG_SO_MAY").Width = 200
        Me.grvThongSoMay.Columns("GIA_TRI").Width = 100
        Me.grvThongSoMay.Columns("TEN_DV_DO").Width = 100
        Me.grvThongSoMay.Columns("GHI_CHU").Width = 150
        Me.grvThongSoMay.Columns("GIA_TRI_MIN").Width = 100
        Me.grvThongSoMay.Columns("GIA_TRI_MAX").Width = 100


    End Sub

    Private Sub Bind_AnToan(ByVal MS_MAY As String)
        Try
            Dim vTbAT As DataTable = New DataTable()
            vTbAT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_MAY,AN_TOAN FROM MAY WHERE MS_MAY=N'" & MS_MAY & "'"))
            chxAnToan.DataBindings.Clear()
            chxAnToan.DataBindings.Add("checked", vTbAT, "AN_TOAN")
        Catch ex As Exception
        End Try
    End Sub




    Private Sub BtnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVe.Click
        HideButtonXoa1(False)
    End Sub

    Private Sub BtnXoaTSCTB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaTSCTB.Click
        Dim traloi As String
        If grvThongSoMay.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa9", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa10", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If traloi = vbNo Then Exit Sub
        Dim objMAYController As New MAYController()
        objMAYController.DeleteTHONG_SO_CHINH_MAY(ucDMTBi.txtMS_MAY.Text, grvThongSoMay.GetFocusedDataRow()(1))
        Dim tmp As Integer = intTab41
        grdThongSoMay.DataSource = New MAYController().GetTHONG_SO_CHINH_MAYs(ucDMTBi.txtMS_MAY.Text)
        If grvThongSoMay.RowCount > 0 Then
            If grvThongSoMay.RowCount = tmp Then
                grvThongSoMay.FocusedRowHandle = tmp - 1
                grvThongSoMay.FocusedColumn = grvThongSoMay.Columns("GIA_TRI")

            Else
                grvThongSoMay.FocusedRowHandle = tmp
                grvThongSoMay.FocusedColumn = grvThongSoMay.Columns("GIA_TRI")
            End If
        End If
    End Sub
#End Region

#Region "Lịch bảo trì định kỳ"
    Sub BindData3()
        Try
            If Commons.Modules.SQLString = "0Load" Then Exit Sub


            Try
                grdLoaiBTPN.DataSource = Nothing
                grdLoaiBTPN_CV.DataSource = Nothing
                grdLoaiBTPN_PT.DataSource = Nothing
            Catch ex As Exception

            End Try
            Dim tmp As New DataTable()
            tmp = New MAYController().GetMAY_LOAI_BTPN(ucDMTBi.txtMS_MAY.Text)
            Commons.Modules.SQLString = "0LOAD"
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBTPN, grvLoaiBTPN, tmp, False, False, False, True, True, "frmThongtinthietbi")
            Commons.Modules.SQLString = ""

            Dim comboBoxColumn As New RepositoryItemLookUpEdit()
            comboBoxColumn.Name = "MS_LOAI_BT"
            comboBoxColumn.ValueMember = "MS_LOAI_BT"
            comboBoxColumn.DisplayMember = "TEN_LOAI_BT"
            comboBoxColumn.NullText = ""
            comboBoxColumn.DataSource = New MAYController().GetLOAI_BAO_TRIs()
            comboBoxColumn.PopulateColumns()
            For i As Integer = 0 To comboBoxColumn.Columns.Count - 1
                comboBoxColumn.Columns(i).Visible = False
            Next
            comboBoxColumn.Columns("TEN_LOAI_BT").Visible = True
            grvLoaiBTPN.Columns("MS_LOAI_BT").ColumnEdit = comboBoxColumn

            grvLoaiBTPN.Columns("NGAY_CUOI").DisplayFormat.FormatString = "dd/MM/yyyy"
            grvLoaiBTPN.Columns("NGAY_CUOI").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

            grvLoaiBTPN.Columns("THU_TU").Visible = False
            grvLoaiBTPN.Columns("CHU_KYS").OptionsColumn.ReadOnly = True
            grvLoaiBTPN.Columns("RUN_TIMES").OptionsColumn.ReadOnly = True
            grvLoaiBTPN.Columns("MOVEMENT").Visible = False
            Try
                grvLoaiBTPN.Columns("MS_LOAI_BT").Width = 100
                grvLoaiBTPN.Columns("CHU_KYS").Width = 75
                grvLoaiBTPN.Columns("RUN_TIMES").Width = 80
                grvLoaiBTPN.Columns("NGAY_CUOI").Width = 80
                grvLoaiBTPN.Columns("SO_NGAY").Width = 71
                grvLoaiBTPN.Columns("MOVEMENT").Width = 80
                grvLoaiBTPN.Columns("MOVEMENT").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                grvLoaiBTPN.Columns("SO_NGAY").DisplayFormat.FormatString = "##,#0"
                grvLoaiBTPN.Columns("SO_NGAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                grvLoaiBTPN.Columns("MS_LOAI_BT_OLD").Visible = False
            Catch ex As Exception
            End Try
            grvLoaiBTPN_FocusedRowChanged(Nothing, Nothing)
        Catch ex As Exception

        End Try


    End Sub



    Private Sub btnThemsua3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemsua3.Click
        If ucDMTBi.txtMS_MAY.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenThem4", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If grvLoaiBTPN.RowCount = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT5", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            intViTriLoaiBTPN = grvLoaiBTPN.FocusedRowHandle
            intViTriCongviec = grvLoaiBTPN_CV.FocusedRowHandle
            intViTriPhuTung = grvLoaiBTPN_PT.FocusedRowHandle
        Catch ex As Exception

        End Try
        'tạo table tam chứa thông tin công việc
        Dim str As String = ""
        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.MAY_LOAI_BTPN_CONG_VIEC" & Commons.Modules.UserName & " (MS_MAY NVARCHAR(30),MS_LOAI_BT INT, MS_CV INT , MS_BO_PHAN NVARCHAR(50),TEN_BO_PHAN NVARCHAR(50),MO_TA_CV NVARCHAR(250),KY_HIEU_CV NVARCHAR(100),DA_CHON BIT,COUNT_ROW INT)"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        str = "CREATE TABLE DBO.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(30),MS_LOAI_BT INT, " &
                    " MS_CV INT, MS_BO_PHAN NVARCHAR(50),TEN_LOAI_VT NVARCHAR(50),MS_PT NVARCHAR(25), TEN_PT NVARCHAR(150), " &
                    " TEN_PT_VIET NVARCHAR(1000),SO_LUONG FLOAT, QUY_CACH NVARCHAR(250),DA_CHON BIT,COUNT_ROW INT, GHI_CHU_BTPN NVARCHAR(250) )"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        str = ""

        bThemBTPN = False
        HideButton12(True)
        grvLoaiBTPN_PT.OptionsBehavior.Editable = True



        grvLoaiBTPN.Columns("CHU_KYS").OptionsColumn.ReadOnly = True
        grvLoaiBTPN.Columns("MOVEMENT").OptionsColumn.ReadOnly = True
        grvLoaiBTPN.Columns("RUN_TIMES").OptionsColumn.ReadOnly = True
        rowCount = grvLoaiBTPN.RowCount - 1
        rowCount1 = grvLoaiBTPN_CV.RowCount
        rowCount2 = grvLoaiBTPN_PT.RowCount


        LockControl(True)

        Try
            Me.grvLoaiBTPN_PT.Columns("TEN_PT").OptionsColumn.ReadOnly = True
            Me.grvLoaiBTPN_PT.Columns("SL_MAX").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("DVT").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("QUY_CACH").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("TEN_LOAI_VT").OptionsColumn.ReadOnly = True

            Me.grvLoaiBTPN_PT.Columns("TEN_PT_VIET").Visible = False
            Me.grvLoaiBTPN_PT.Columns("GHI_CHU").Visible = False
        Catch ex As Exception

        End Try

        'str = "INSERT INTO  MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " (MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_LOAI_VT,MS_PT,TEN_PT,TEN_PT_VIET,SO_LUONG,QUY_CACH,DA_CHON)
        Try

            str = "
                INSERT INTO MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " (MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_LOAI_VT,MS_PT,TEN_PT,TEN_PT_VIET,SO_LUONG,QUY_CACH,DA_CHON)
                SELECT T1.MS_MAY, T1.MS_LOAI_BT, T1.MS_CV, T1.MS_BO_PHAN, T3.TEN_LOAI_VT_TV AS TEN_LOAI_VT, T2.MS_PT, T2.TEN_PT, TEN_PT_VIET,T1.SO_LUONG, T2.QUY_CACH, 1 AS DA_CHON
                FROM            dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG AS T1 INNER JOIN
                                            dbo.IC_PHU_TUNG AS T2 ON T1.MS_PT = T2.MS_PT INNER JOIN
                                            dbo.LOAI_VT AS T3 ON T2.MS_LOAI_VT = T3.MS_LOAI_VT INNER JOIN
                                            dbo.DON_VI_TINH AS T4 ON T2.DVT = T4.DVT LEFT OUTER JOIN
                                                (SELECT        MS_MAY, MS_BO_PHAN, SUM(ISNULL(SO_LUONG, 0)) AS SL_MAX, MS_PT
                                                FROM            dbo.CAU_TRUC_THIET_BI_PHU_TUNG
                                                WHERE        (ACTIVE = 1)
                                                GROUP BY MS_MAY, MS_BO_PHAN, MS_PT
                                                HAVING         (MS_MAY = '" & ucDMTBi.txtMS_MAY.Text & "')) AS A ON A.MS_MAY = T1.MS_MAY AND A.MS_PT = T1.MS_PT AND T1.MS_BO_PHAN = A.MS_BO_PHAN
                WHERE        (T1.MS_MAY = '" & ucDMTBi.txtMS_MAY.Text & "') AND (T1.MS_LOAI_BT = " & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_LOAI_BT") & ") 
ORDER BY TEN_LOAI_VT, T1.MS_PT, T2.TEN_PT

"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try


        If grvLoaiBTPN.RowCount > 0 Then
            grdLoaiBTPN.Enabled = False
            grdLoaiBTPN_CV.Enabled = True
            grdLoaiBTPN_PT.Enabled = True
        End If

    End Sub
    Sub HideButton12(ByVal an As Boolean)
        btnThemsua3.Visible = Not an
        btnXoa3.Visible = Not an
        btnThoat3.Visible = Not an
        btnGhi3.Visible = an
        btnKhongghi3.Visible = an
        BtnChonCongViec.Visible = an
        BtnChonPT.Visible = an
        btnCopyLoaiBT.Enabled = Not an
        btnChukyBTPN.Enabled = Not an
        btnThemLichBTPN.Visible = Not an
    End Sub

    Private Sub btnKhongghi3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongghi3.Click
        Dim str As String = ""
        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try


        bThemBTPN = False
        blnLoiBTPN = False

        grdLoaiBTPN.DataSource = New MAYController().GetMAY_LOAI_BTPN(ucDMTBi.txtMS_MAY.Text)

        grvLoaiBTPN.OptionsBehavior.Editable = False
        grvLoaiBTPN.OptionsBehavior.AllowAddRows = False
        grvLoaiBTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None


        grvLoaiBTPN_PT.OptionsBehavior.Editable = False




        HideButton12(False)

        LockControl(False)
        intViTriCongviec = -1
        intViTriLoaiBTPN = -1
        intViTriPhuTung = -1

        Try
            Me.grvLoaiBTPN_PT.Columns("TEN_PT").SortMode = DataGridViewColumnSortMode.Automatic
            Me.grvLoaiBTPN_PT.Columns("TEN_PT_VIET").SortMode = DataGridViewColumnSortMode.Automatic
            Me.grvLoaiBTPN_PT.Columns("SO_LUONG").SortMode = DataGridViewColumnSortMode.Automatic
            Me.grvLoaiBTPN_PT.Columns("SL_MAX").SortMode = DataGridViewColumnSortMode.Automatic
            Me.grvLoaiBTPN_PT.Columns("QUY_CACH").SortMode = DataGridViewColumnSortMode.Automatic
        Catch ex As Exception

        End Try
        If grvLoaiBTPN.RowCount > 0 Then
            grdLoaiBTPN.Enabled = True
            grdLoaiBTPN_CV.Enabled = True
            grdLoaiBTPN_PT.Enabled = True
        End If

        grvLoaiBTPN_CV_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub btnThoat3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat3.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub RefeshLanguage3()
        Try
            Me.grvLoaiBTPN.Columns("NGAY_CUOI").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.grvLoaiBTPN.Columns("CHU_KYS").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.grvLoaiBTPN.Columns("SO_NGAY").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.grvLoaiBTPN.Columns("RUN_TIMES").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.grvLoaiBTPN_CV.Columns("KY_HIEU_CV").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Try
                grvLoaiBTPN.Columns("MS_LOAI_BT_OLD").Visible = False
                grvLoaiBTPN.Columns("RUN_TIMES").Width = 150
                grvLoaiBTPN.Columns("SO_NGAY").Visible = False
                grvLoaiBTPN_CV.Columns("KY_HIEU_CV").Width = 80
                grvLoaiBTPN_CV.Columns("KY_HIEU_CV").Visible = False
                grvLoaiBTPN.Columns("THU_TU").Visible = False
            Catch ex As Exception
            End Try


            Try
                grvLoaiBTPN_PT.Columns("SO_LUONG").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                grvLoaiBTPN_PT.Columns("TEN_PT").Width = 180
                grvLoaiBTPN_PT.Columns("TEN_PT_VIET").Width = 180
                grvLoaiBTPN_PT.Columns("SO_LUONG").Width = 80
                grvLoaiBTPN_PT.Columns("SL_MAX").Width = 80
                grvLoaiBTPN_PT.Columns("DVT").Width = 90
                grvLoaiBTPN_PT.Columns("QUY_CACH").Width = 165
                grvLoaiBTPN_PT.Columns("MS_VI_TRI").Visible = False
                Me.grvLoaiBTPN_PT.Columns("TEN_PT_VIET").Visible = False
                Me.grvLoaiBTPN_PT.Columns("GHI_CHU").Visible = False
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnGhi3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi3.Click
        Dim sMsBP As String = "-1"
        Dim sMsCV As String = "-1"
        If bThemBTPN = False Then
            Try
                sMsBP = grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN").ToString()
            Catch ex As Exception
            End Try
            Try
                sMsCV = grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV").ToString()
            Catch ex As Exception
            End Try
        Else
            Try
                sMsBP = grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT").ToString()
            Catch ex As Exception

            End Try
        End If



        Try

            Dim str As String = ""
            If Not btnThemsua3.Visible Then
                Dim dtReader1 As SqlDataReader
                Dim bCo As Boolean = False
                For i As Integer = 0 To grvLoaiBTPN_PT.RowCount - 1
                    str = "Select MS_MAY FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_LOAI_BT") & "' AND MS_CV='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & "' AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetDataRow(i)("MS_PT") & "'"
                    dtReader1 = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While dtReader1.Read
                        bCo = True
                    End While
                    dtReader1.Close()
                    If bCo Then
                        str = "UPDATE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName &
                        " SET SO_LUONG = " & grvLoaiBTPN_PT.GetDataRow(i)("SO_LUONG") &
                        " , GHI_CHU_BTPN='" & grvLoaiBTPN_PT.GetDataRow(i)("GHI_CHU_BTPN") & "' " &
                        " WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT ='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_LOAI_BT") & "' " &
                        " AND MS_CV ='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & "' AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetDataRow(i)("MS_PT") & "'"
                    Else
                        str = "INSERT INTO  MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName &
                                " (MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_LOAI_VT,MS_PT,TEN_PT,TEN_PT_VIET,SO_LUONG,QUY_CACH,DA_CHON,GHI_CHU_BTPN) " &
                                " VALUES(N'" & ucDMTBi.txtMS_MAY.Text & "','" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_LOAI_BT") & "','" &
                                grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & "','" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "','" &
                                grvLoaiBTPN_PT.GetDataRow(i)("TEN_LOAI_VT") & "','" & grvLoaiBTPN_PT.GetDataRow(i)("MS_PT") & "','" &
                                grvLoaiBTPN_PT.GetDataRow(i)("TEN_PT") & "' ,'" & grvLoaiBTPN_PT.GetDataRow(i)("TEN_PT_VIET") & "','" &
                                grvLoaiBTPN_PT.GetDataRow(i)("SO_LUONG") & "','" & grvLoaiBTPN_PT.GetDataRow(i)("QUY_CACH") & "','" & 1 & "', " &
                                " '" & grvLoaiBTPN_PT.GetDataRow(i)("GHI_CHU_BTPN") & "' )"
                    End If
                    bCo = False
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Next
            End If

            Dim tam, loaiBTs As Integer
            Try
                loaiBTs = grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
            Catch ex As Exception
                loaiBTs = 0
            End Try


            If bThemBTPN = True Then

                Dim dtTmp As New DataTable
                Dim sBt As String = "MAY_BTPN_TMP" & Commons.Modules.UserName

                dtTmp = CType(grdLoaiBTPN.DataSource, DataTable).Copy
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBt, dtTmp, "")
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "
                        INSERT INTO MAY_LOAI_BTPN(MS_MAY ,MS_LOAI_BT ,NGAY_CUOI,SO_NGAY,THUC_HIEN_BOI, GHI_CHU)
                        SELECT N'" & ucDMTBi.txtMS_MAY.Text & "' AS MS_MAY ,MS_LOAI_BT ,NGAY_CUOI,SO_NGAY,THUC_HIEN_BOI, GHI_CHU 
                        FROM " & sBt & " T1 
                        WHERE ISNULL(MS_LOAI_BT_OLD,'') = ''


                        UPDATE MAY_LOAI_BTPN SET 
	                        NGAY_CUOI=T1.NGAY_CUOI ,SO_NGAY =T1.SO_NGAY,MS_LOAI_BT=T1.MS_LOAI_BT,
	                        THUC_HIEN_BOI = T1.THUC_HIEN_BOI, GHI_CHU = T1.GHI_CHU 
                        FROM " & sBt & " T1 INNER JOIN MAY_LOAI_BTPN T2 ON T1.MS_LOAI_BT_OLD = T2.MS_LOAI_BT
                        WHERE T2.MS_MAY = N'" & ucDMTBi.txtMS_MAY.Text & "'
                        AND  ISNULL(MS_LOAI_BT_OLD,'') <> ''

                        ")
                Commons.Modules.ObjSystems.XoaTable("MAY_BTPN_TMP" & Commons.Modules.UserName)

                GoTo TT
            End If

            i = 0
            Dim tb As New DataTable()
            Try
                str = "SELECT MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,COUNT_ROW FROM dbo.MAY_LOAI_BTPN_CONG_VIEC_TMP" & Commons.Modules.UserName &
                        " WHERE MS_MAY = N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "'"
                tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                tam = tb.Rows.Count
                While i < tam
                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN_CONG_VIEC",
                                        ucDMTBi.txtMS_MAY.Text, tb.Rows(i).Item("MS_LOAI_BT"), tb.Rows(i).Item("MS_CV"), tb.Rows(i).Item("MS_BO_PHAN"))
                    Catch ex As Exception

                    End Try
                    i = i + 1
                End While
                i = 0
            Catch ex As Exception

            End Try

            tb = New DataTable()
            str = "SELECT MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,QUY_CACH,COUNT_ROW,DA_CHON,GHI_CHU_BTPN " &
                        " FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " "
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            tam = tb.Rows.Count
            While i < tam
                If IsDBNull(tb.Rows(i).Item("COUNT_ROW")) And IsDBNull(tb.Rows(i).Item("DA_CHON")) Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG",
                        ucDMTBi.txtMS_MAY.Text, tb.Rows(i).Item("MS_LOAI_BT"), tb.Rows(i).Item("MS_CV"), tb.Rows(i).Item("MS_PT"),
                        tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("MS_BO_PHAN"), tb.Rows(i).Item("GHI_CHU_BTPN"), tb.Rows(i).Item("QUY_CACH"))
                Else
                    ''CẬP NHẬT LẠI GIÁ TRỊ THAY ĐỔI
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG",
                    ucDMTBi.txtMS_MAY.Text, tb.Rows(i).Item("MS_LOAI_BT"), tb.Rows(i).Item("MS_CV"), tb.Rows(i).Item("MS_PT"),
                    tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("QUY_CACH"), tb.Rows(i).Item("MS_BO_PHAN"), tb.Rows(i).Item("GHI_CHU_BTPN"))
                End If
                i = i + 1
            End While
TT:
            Try
                str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC" & Commons.Modules.UserName
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception

            End Try
            Try
                str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try

            grvLoaiBTPN.OptionsBehavior.Editable = False
            i = 0

            HideButton12(False)

            If bThemBTPN = True Then
                blnLoiBTPN = False
                grdLoaiBTPN.DataSource = New MAYController().GetMAY_LOAI_BTPN(ucDMTBi.txtMS_MAY.Text)
                grvLoaiBTPN.OptionsBehavior.Editable = False
                grvLoaiBTPN.OptionsBehavior.AllowAddRows = False
                grvLoaiBTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            End If

            LockControl(False)

            Try
                Me.grvLoaiBTPN_CV.Columns("MO_TA_CV").SortMode = DataGridViewColumnSortMode.Automatic
                Me.grvLoaiBTPN_PT.Columns("TEN_PT").SortMode = DataGridViewColumnSortMode.Automatic
                Me.grvLoaiBTPN_PT.Columns("TEN_PT_VIET").SortMode = DataGridViewColumnSortMode.Automatic
                Me.grvLoaiBTPN_PT.Columns("SO_LUONG").SortMode = DataGridViewColumnSortMode.Automatic
                Me.grvLoaiBTPN_PT.Columns("SL_MAX").SortMode = DataGridViewColumnSortMode.Automatic
                Me.grvLoaiBTPN_PT.Columns("QUY_CACH").SortMode = DataGridViewColumnSortMode.Automatic
                grvLoaiBTPN.Columns("MS_LOAI_BT_OLD").Visible = False
            Catch ex4 As Exception

            End Try

            If grvLoaiBTPN.RowCount > 0 Then
                grdLoaiBTPN.Enabled = True
                grdLoaiBTPN_CV.Enabled = True
                grdLoaiBTPN_PT.Enabled = True
            End If
        Catch ex As Exception

        End Try
        i = 0
        Try

            If bThemBTPN = False Then
                Dim dtTmp As New DataTable
                dtTmp = TryCast(grdLoaiBTPN_CV.DataSource, DataTable)
                If dtTmp IsNot Nothing Then
                    Dim result = If(dtTmp.[Select]().Where(Function(x) x("MS_BO_PHAN").ToString() = sMsBP AndAlso x("MS_CV").ToString() = sMsCV).Count() > 0, dtTmp.[Select]().Where(Function(x) x("MS_BO_PHAN").ToString() = sMsBP AndAlso x("MS_CV").ToString() = sMsCV).SingleOrDefault(), Nothing)


                    Dim drRow As DataRow
                    drRow = CType(result, DataRow)

                    ucDMTBi.GridView1.FocusedRowHandle = ucDMTBi.GridView1.GetRowHandle(dtTmp.Rows.IndexOf(drRow))
                End If

            Else
                i = grvLoaiBTPN.LocateByValue(0, grvLoaiBTPN.Columns("MS_LOAI_BT"), CInt(sMsBP))
                If i <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                    grvLoaiBTPN.FocusedRowHandle = i
                End If

            End If
        Catch ex As Exception

        End Try

        grvLoaiBTPN_CV_FocusedRowChanged(Nothing, Nothing)
    End Sub


    Public Sub FocusRow(view As GridView, rowHandle As Integer)
        view.FocusedRowHandle = rowHandle
    End Sub


    Private Sub btnChukyBTPN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChukyBTPN.Click
        If grvLoaiBTPN.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT4", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        frmMayloaiBTPNchuky.ATTACHMENT = False
        frmMayloaiBTPNchuky.ShowDialog()
    End Sub

    Private Sub BtnChonCongViec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonCongViec.Click
        If grvLoaiBTPN.RowCount = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT5", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        FrmChonCongViecChoBTPN.ShowDialog()
    End Sub
#End Region

#Region "tam 2"
    Private Sub LoadCmbPT_BP()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If grvMay.RowCount = 0 Then Exit Sub
        Dim dtTable As New DataTable
        Dim sSql As String = ""
        Dim sEdit As String = ""
        Dim sPT As String = ""
        If BtnGhi4.Visible Then sSql = " (ACTIVE_PT = 1) AND "

        If sTrangThaiTabThietbi = "E" Then
            sPT = CboPT_BP.Text
            sEdit = " UNION SELECT A.MS_PT, A.MS_PT + ' - ' + B.TEN_PT AS TEN_PT " &
                " FROM CAU_TRUC_THIET_BI A INNER JOIN IC_PHU_TUNG B ON A.MS_PT = B.MS_PT " &
                " WHERE MS_MAY = N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' " &
                " AND MS_BO_PHAN = N'" + Commons.Modules.ObjSystems.SplitString(txtMS_BO_PHAN.Text) + "' "
        End If


        sSql = "SELECT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_PT + ' - ' + IC_PHU_TUNG.TEN_PT AS TEN_PT " &
                 "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT INNER JOIN " &
                      "LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT INNER JOIN " &
                      "LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN " &
                      "MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY " &
                 "WHERE  " + sSql + "  (LOAI_MAY.MS_LOAI_MAY = '" & ucDMTBi.cboMS_LOAI_MAY.EditValue & "') AND (LOAI_VT.VAT_TU = 0) AND " &
                 " (MAY.MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "') " & sEdit &
                 " UNION SELECT '-1','' ORDER BY IC_PHU_TUNG.MS_PT"


        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(CboPT_BP, dtTable, "MS_PT", "TEN_PT", "")
        If sTrangThaiTabThietbi = "E" Then
            If sPT = "" Then CboPT_BP.EditValue = "-1" Else CboPT_BP.Text = sPT
        Else
            CboPT_BP.EditValue = "-1"
        End If

    End Sub


    Sub HideButton13(ByVal an As Boolean)
        BtnThem4.Visible = Not an
        BtnSua4.Visible = Not an
        BtnXoa4.Visible = Not an
        BtnGhi4.Visible = an
        BtnKhongGhi4.Visible = an
    End Sub

    Sub LockData1(ByVal Khoa As Boolean)
        tvwCTTBi.Enabled = Khoa
        txtMS_BO_PHAN.Properties.ReadOnly = Not Khoa
        txtTEN_BO_PHAN.Enabled = Khoa
        txtTEN_BO_PHAN.Properties.ReadOnly = Not Khoa
        txtSO_LUONG.Properties.ReadOnly = Not Khoa
        CboPT_BP.Enabled = Khoa
        BtnTimPTCmb.Enabled = Khoa
        cboClass.Enabled = Khoa
        txtGHI_CHU.Properties.ReadOnly = Not Khoa
        BtnTimPTCmb.Enabled = Khoa
    End Sub
    Dim blnThongtintb As Integer = 0
    ' 0 ~ nothing 1 ~ them  2 ~ sua
    Private Sub btnThemsua2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemsua2.Click
        Try

            If ucDMTBi.txtMS_MAY.Text = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenThem5", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            HideButton14(True)

            blnThem = True

            Dim hc As Integer = 0
            For hc = 0 To grvChuKiHC.RowCount - 1
                ArrHieuChuanDongHo(hc) = grvChuKiHC.GetDataRow(hc)("MS_PT")
                ArrHieuChuanViTri(hc) = grvChuKiHC.GetDataRow(hc)("MS_VI_TRI")
            Next

            LockControl(True)

            grvChuKiHC.OptionsBehavior.Editable = True
            grvChuKiHC.OptionsBehavior.AllowAddRows = True
            grvChuKiHC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            Try
                Me.grvChuKiHC.Columns("MS_VI_TRI").OptionsColumn.ReadOnly = False
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try


    End Sub


    Sub HideButton14(ByVal An As Boolean)
        btnThemsua2.Visible = Not An
        btnXoa2.Visible = Not An
        btnThoat2.Visible = Not An
        btnGhi2.Visible = An
        btnKhongghi2.Visible = An
    End Sub
    Sub BindData6()

    End Sub

    Sub BindData5()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Try

        Catch ex As Exception

        End Try

        Try
            Dim dtTmp = New DataTable
            dtTmp = New MAYController().GetCHU_KY_HIEU_CHUAN(ucDMTBi.txtMS_MAY.Text)
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChuKiHC, grvChuKiHC, dtTmp, False, False, False, False, True, Me.Name)
            Dim dt As New DataTable
            Dim obj As New MAYController
            Try
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_PT, MS_PT + ' - ' + TEN_PT AS TENPT FROM IC_PHU_TUNG WHERE DUNG_CU_DO = 1"))
                Dim cbo1 As New RepositoryItemLookUpEdit()
                cbo1.Name = "MS_PT"
                cbo1.DataSource = dt
                cbo1.ValueMember = "MS_PT"
                cbo1.DisplayMember = "TENPT"
                cbo1.NullText = ""
                cbo1.PopulateColumns()
                cbo1.Columns("MS_PT").Visible = False
                cbo1.Columns("TENPT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TENPT", Commons.Modules.TypeLanguage)
                grvChuKiHC.Columns("MS_PT").ColumnEdit = cbo1
                cbo1 = New RepositoryItemLookUpEdit()
                'cbo.Name = "cboDV_TG_HC"
                cbo1.ValueMember = "MS_DV_TG"
                cbo1.DisplayMember = "TEN_DV_TG"
                cbo1.DataSource = New MAYController().GetDON_VI_THOI_GIANs
                cbo1.NullText = ""
                cbo1.PopulateColumns()
                cbo1.Columns("MS_DV_TG").Visible = False
                cbo1.Columns("TEN_DV_TG").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DV_TG", Commons.Modules.TypeLanguage)
                grvChuKiHC.Columns("MS_DV_TG").ColumnEdit = cbo1

            Catch ex As Exception
            End Try
            grvChuKiHC.Columns("MS_VI_TRI").OptionsColumn.ReadOnly = False
            grvChuKiHC.Columns("CHU_KY_HC_NOI").Width = 100
            grvChuKiHC.Columns("CHU_KY_HC_NGOAI").Width = 100
            grvChuKiHC.Columns("CHU_KY_KD").Width = 150
            grvChuKiHC.Columns("CHU_KY_KT").Width = 150
            grvChuKiHC.Columns("MS_DV_TG").Width = 150
            grvChuKiHC.Columns("GHI_CHU").Width = 250
            grvChuKiHC.Columns("GHI_CHU").Visible = False
            grvChuKiHC.Columns("MS_VI_TRI").Width = 150
            grvChuKiHC.Columns("MS_PT").Width = 350
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnKhongghi2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongghi2.Click
        If grvChuKiHC.RowCount > 0 Then
            Try
                If CheckData(grvChuKiHC.FocusedRowHandle) = True Then Exit Sub
            Catch ex As Exception
            End Try
        End If


        HideButton14(False)
        BindData5()

        LockControl(False)
        blnThem = False
        grvChuKiHC.OptionsBehavior.Editable = False
        grvChuKiHC.OptionsBehavior.AllowAddRows = False
        grvChuKiHC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub btnThoat2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat2.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGhi2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi2.Click
        If grvChuKiHC.RowCount > 0 Then
            Try
                If CheckData(grvChuKiHC.FocusedRowHandle) = True Then Exit Sub
            Catch ex As Exception
            End Try
        End If
        i = 0
        While i < grvChuKiHC.RowCount - 1
            If grvChuKiHC.GetDataRow(i).RowState = DataRowState.Added Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddCHU_KY_HIEU_CHUAN",
                                  ucDMTBi.txtMS_MAY.Text, grvChuKiHC.GetDataRow(i)("MS_PT").ToString(),
                                 grvChuKiHC.GetDataRow(i)("MS_VI_TRI").ToString(), grvChuKiHC.GetDataRow(i)("TEN_VI_TRI").ToString(),
                                 grvChuKiHC.GetDataRow(i)("CHU_KY_HC_NOI"), grvChuKiHC.GetDataRow(i)("CHU_KY_HC_NGOAI"),
                                 grvChuKiHC.GetDataRow(i)("MS_DV_TG").ToString(), Nothing, grvChuKiHC.GetDataRow(i)("CHU_KY_KD"), grvChuKiHC.GetDataRow(i)("CHU_KY_KT"))
            Else
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateCHU_KY_HIEU_CHUAN",
                        ucDMTBi.txtMS_MAY.Text, grvChuKiHC.GetDataRow(i)("MS_PT").ToString(),
                       grvChuKiHC.GetDataRow(i)("MS_VI_TRI").ToString(), grvChuKiHC.GetDataRow(i)("TEN_VI_TRI").ToString(),
                       grvChuKiHC.GetDataRow(i)("CHU_KY_HC_NOI"), grvChuKiHC.GetDataRow(i)("CHU_KY_HC_NGOAI"),
                       grvChuKiHC.GetDataRow(i)("MS_DV_TG").ToString(), Nothing, ArrHieuChuanDongHo(i), ArrHieuChuanViTri(i),
                       grvChuKiHC.GetDataRow(i)("CHU_KY_KD"), grvChuKiHC.GetDataRow(i)("CHU_KY_KT"))

            End If
            i = i + 1
        End While
        grdChuKiHC.DataSource = New MAYController().GetCHU_KY_HIEU_CHUAN(ucDMTBi.txtMS_MAY.Text)
        i = 0
        Dim intInd As Integer = -1
        blnThem = False
        HideButton14(False)
        LockControl(False)
        grvChuKiHC.OptionsBehavior.Editable = False
        grvChuKiHC.OptionsBehavior.AllowAddRows = False
        grvChuKiHC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Function CheckData(ByVal RowIndex As Long) As Boolean
        If Tabthietbi.SelectedTabPageIndex <> 3 Then Exit Function
        'Kiem tra dl bac buoc nhap
        If RowIndex < grvChuKiHC.RowCount - 1 Then
            If IsDBNull(grvChuKiHC.GetDataRow(RowIndex)("MS_VI_TRI")) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvChuKiHC.FocusedColumn = grvChuKiHC.Columns("MS_VI_TRI")
                Return True
            ElseIf IsDBNull(grvChuKiHC.GetDataRow(RowIndex)("CHU_KY_HC_NOI")) And IsDBNull(grvChuKiHC.GetDataRow(RowIndex)("CHU_KY_HC_NGOAI")) And IsDBNull(grvChuKiHC.GetDataRow(RowIndex)("CHU_KY_KD")) And IsDBNull(grvChuKiHC.GetDataRow(RowIndex)("CHU_KY_KT")) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHU_KY_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvChuKiHC.FocusedColumn = grvChuKiHC.Columns("CHU_KY_HC_NOI")

                Return True
            ElseIf IsDBNull(grvChuKiHC.GetDataRow(RowIndex)("MS_DV_TG")) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DV_TG_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvChuKiHC.FocusedColumn = grvChuKiHC.Columns("MS_DV_TG")

                Return True
            End If
        End If
        grvChuKiHC.UpdateCurrentRow()
        grdChuKiHC.Update()

        Dim dt As New DataTable
        dt = CType(grdChuKiHC.DataSource, DataTable)
        If (grvChuKiHC.FocusedRowHandle < 0) Then
            If dt.Select().AsEnumerable().Any(Function(x) x("MS_PT").ToString().Trim().Equals(grvChuKiHC.GetFocusedDataRow()("MS_PT").ToString()) And x("MS_VI_TRI") = grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI").ToString()) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenkt56", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            End If
        Else
            Dim ckDuplicate = dt.Select().AsEnumerable().GroupBy(Function(x) New With {Key .MS_PT = x("MS_PT").ToString(), Key .MS_VI_TRI = x("MS_VI_TRI").ToString()}).Where(Function(x) x.Count() > 1).Select(Function(x) New With {Key .MS_PT = x.First()("MS_PT"), Key .MS_VI_TRI = x.First()("MS_VI_TRI")})
            If (ckDuplicate.Count() > 0) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenkt56", Commons.Modules.TypeLanguage) & Environment.NewLine & ckDuplicate.First().MS_PT & " - " & ckDuplicate.First().MS_VI_TRI, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            End If
        End If


    End Function

    Private Sub btnXoa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa2.Click
        Dim objMAYController As New MAYController()
        Dim dtReader As SqlDataReader
        If grvChuKiHC.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa15", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SQL = "select * from HIEU_CHUAN_DHD where MS_MAY = N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() &
                            "' AND MS_PT = N'" & Me.grvChuKiHC.GetFocusedDataRow()("MS_PT").ToString() &
                            "' AND MS_VI_TRI = N'" & Me.grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI").ToString() & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Dữ liệu đang được sử dụng trong lịch hiệu chuẩn đồng hồ đo ! Bạn không thể xoá !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT78", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        Dim traloi As String
        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa16", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If traloi = vbNo Then Exit Sub

        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteCHU_KY_HIEU_CHUAN", ucDMTBi.txtMS_MAY.Text, Me.grvChuKiHC.GetFocusedDataRow()("MS_PT").ToString(), Me.grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI"))
        Try

        Catch ex As Exception

        End Try


        grdChuKiHC.DataSource = New MAYController().GetCHU_KY_HIEU_CHUAN(ucDMTBi.txtMS_MAY.Text)


        Try
            grvChuKiHC.Columns("MS_DV_TG").Visible = False
            grvChuKiHC.Columns("MS_VI_TRI").OptionsColumn.ReadOnly = False


            grvChuKiHC.Columns("cboPhuTung").Width = 350
            grvChuKiHC.Columns("CHU_KY_HC_NOI").Width = 100
            grvChuKiHC.Columns("CHU_KY_HC_NGOAI").Width = 100
            grvChuKiHC.Columns("CHU_KY_KD").Width = 150
            grvChuKiHC.Columns("CHU_KY_KT").Width = 150

            grvChuKiHC.Columns("MS_DV_TG").Width = 150
            grvChuKiHC.Columns("GHI_CHU").Width = 250
            grvChuKiHC.Columns("MS_VI_TRI").Width = 120
        Catch ex As Exception

        End Try

    End Sub
    Sub HideXoa2(ByVal an As Boolean)
        btnThemsua2.Visible = Not an
        btnXoa2.Visible = Not an
        btnThoat2.Visible = Not an
        btnGhi2.Visible = Not an
        btnKhongghi2.Visible = Not an
        BtnXoaLichHieuChuanTB.Visible = an
        BtnTroVe2.Visible = an
    End Sub

    Private Sub BtnTroVe2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVe2.Click
        HideXoa2(False)
    End Sub

    Private Sub BtnXoaLichHieuChuanTB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaLichHieuChuanTB.Click
        Dim objMAYController As New MAYController()
        Dim dtReader As SqlDataReader
        If grvChuKiHC.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa15", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SQL = "select * from HIEU_CHUAN_DHD where MS_MAY = N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() &
                            "' AND MS_PT = N'" & Me.grvChuKiHC.GetFocusedDataRow()("MS_PT").ToString() &
                            "' AND MS_VI_TRI = N'" & Me.grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI").ToString() & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Dữ liệu đang được sử dụng trong lịch hiệu chuẩn đồng hồ đo ! Bạn không thể xoá !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT78", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        Dim traloi As String
        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa16", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If traloi = vbNo Then Exit Sub
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteCHU_KY_HIEU_CHUAN", ucDMTBi.txtMS_MAY.Text, grvChuKiHC.GetFocusedDataRow()("MS_PT").ToString(), grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI").ToString())
        Try

        Catch ex As Exception

        End Try

        grdChuKiHC.DataSource = New MAYController().GetCHU_KY_HIEU_CHUAN(ucDMTBi.txtMS_MAY.Text)


        Try
            grvChuKiHC.Columns("MS_VI_TRI").OptionsColumn.ReadOnly = False
            grvChuKiHC.Columns("MS_PT").Width = 230
            grvChuKiHC.Columns("MS_DV_TG").Width = 115
            grvChuKiHC.Columns("CHU_KY_HC_NOI").Width = 70
            grvChuKiHC.Columns("CHU_KY_HC_NGOAI").Width = 70
            grvChuKiHC.Columns("CHU_KY_KD").Width = 155
            grvChuKiHC.Columns("CHU_KY_KT").Width = 155
            grvChuKiHC.Columns("GHI_CHU").Width = 250
            grvChuKiHC.Columns("MS_VI_TRI").Width = 120
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnXoa3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa3.Click
        blnXoa3 = True
        HideButtonXoa3(True)
        LockControl(True)


    End Sub
    Sub HideButtonXoa3(ByVal an As Boolean)
        btnThemsua3.Visible = Not an
        btnXoa3.Visible = Not an
        btnThoat3.Visible = Not an
        BtnXoaLoaiBTPN.Visible = an
        BtnXoaCV.Visible = an
        BtnXoaPT.Visible = an
        BtnTroVeBTPN.Visible = an
        btnThemLichBTPN.Visible = Not an
    End Sub

    Private Sub BtnTroVeBTPN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVeBTPN.Click

        LockControl(False)
        HideButtonXoa3(False)
        blnXoa3 = False

    End Sub

    Private Sub BtnXoaLoaiBTPN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoaLoaiBTPN.Click
        If grvLoaiBTPN.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa17", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim traloi As String, strThongBao As String = ""
        If (grvLoaiBTPN_PT.RowCount > 0 Or grvLoaiBTPN_CV.RowCount > 0) Then
            traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaBaoTri", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If traloi = vbNo Then Exit Sub
        End If
        'chỉ làm cho kido, các nơi khác thì hiện thông báo không cho xóa
        If grvLoaiBTPN_CV.RowCount > 0 Then If Kiem_Tra_DS_CV_Lien_Quan(strThongBao) = False Then Exit Sub
        Dim sSql As String
        sSql = "DELETE FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        sSql = "DELETE FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        sSql = "DELETE FROM MAY_LOAI_BTPN_CHU_KY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteMAY_LOAI_BTPN", ucDMTBi.txtMS_MAY.Text, Me.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT"))
        grdLoaiBTPN_CV.DataSource = System.DBNull.Value
        grdLoaiBTPN_PT.DataSource = System.DBNull.Value
        Dim tmp As Integer = intMS_LOAI_BT
        grdLoaiBTPN.DataSource = New MAYController().GetMAY_LOAI_BTPN(ucDMTBi.txtMS_MAY.Text)

        RefeshLanguage3()
    End Sub

    Private Sub BtnXoaCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoaCV.Click
        If grvLoaiBTPN_CV.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa20", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim traloi As String
        Dim strThongBao As String = ""
        Dim sSql As String = ""

        If grvLoaiBTPN_PT.RowCount > 0 Then
            traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaCVBaoTri", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If traloi = vbNo Then
                Exit Sub
            Else
                'chỉ làm cho kido, các nơi khác hiện thông báo kg cho xóa
                Kiem_Tra_MS_CV_Lien_Quan(grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV"), strThongBao)
                If strThongBao.Trim <> "" Then
                    If XtraMessageBox.Show(strThongBao, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Exit Sub
                    Dim dtReader_tmp As SqlDataReader

                    If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)) > 0 Then
                        sSql = "SELECT * FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY IN (SELECT MS_MAY FROM KE_HOACH_TONG_THE " &
                                " WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") & ")"
                        dtReader_tmp = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                        While dtReader_tmp.Read
                            sSql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & dtReader_tmp.Item("MS_MAY") & "' AND MS_CV=" & dtReader_tmp.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                            sSql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY=N'" & dtReader_tmp.Item("MS_MAY") & "' AND MS_CV=" & dtReader_tmp.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                        End While
                        dtReader_tmp.Close()
                    End If

                    If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)) > 0 Then
                        sSql = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC WHERE STT_SERVICE IS NULL AND MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
                        dtReader_tmp = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                        While dtReader_tmp.Read
                            sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & dtReader_tmp.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & dtReader_tmp.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                            sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & dtReader_tmp.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & dtReader_tmp.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                            sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_KE_HOACH WHERE MS_PHIEU_BAO_TRI='" & dtReader_tmp.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & dtReader_tmp.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                            sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & dtReader_tmp.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & dtReader_tmp.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                            sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & dtReader_tmp.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & dtReader_tmp.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                            sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC WHERE STT_SERVICE IS NULL AND MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_PHIEU_BAO_TRI='" & dtReader_tmp.Item("MS_PHIEU_BAO_TRI") & "' AND MS_BO_PHAN='" & dtReader_tmp.Item("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                        End While
                        dtReader_tmp.Close()
                    End If
                End If

                sSql = "DELETE FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") & " AND MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                sSql = "DELETE FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") & " AND MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            End If
        Else
            traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa22", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If traloi = vbNo Then Exit Sub
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteMAY_LOAI_BTPN_CONG_VIEC", ucDMTBi.txtMS_MAY.Text, Me.grvLoaiBTPN_CV.GetFocusedDataRow()(1), Me.grvLoaiBTPN_CV.GetFocusedDataRow()(2), grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN"))
        End If

        grdLoaiBTPN_PT.DataSource = Nothing
        Try

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBTPN_CV, grvLoaiBTPN_CV, New MAYController().GetMAY_LOAI_BTPN_CONG_VIEC(ucDMTBi.txtMS_MAY.Text, grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")), False, True, True, True, True, "frmThongtinthietbi")


            grvLoaiBTPN_CV.Columns(0).Visible = False
            grvLoaiBTPN_CV.Columns(1).Visible = False
            grvLoaiBTPN_CV.Columns(2).Visible = False
            grvLoaiBTPN_CV.Columns("MS_BO_PHAN").Visible = False

            grvLoaiBTPN_CV.Columns("TEN_BO_PHAN").Width = 150
            grvLoaiBTPN_CV.Columns("MO_TA_CV").Width = 250
            grvLoaiBTPN_CV.Columns("KY_HIEU_CV").Width = 80
        Catch ex As Exception

        End Try

        RefeshLanguage3()
    End Sub

    Private Function Kiem_Tra_DS_CV_Lien_Quan(ByRef strThongBao As String) As Boolean
        Dim bKiemTra As Boolean = False
        Dim bHoi As Boolean = False
        Dim sSql As String = ""
        For i As Integer = 0 To grvLoaiBTPN_CV.RowCount - 1
            bKiemTra = Kiem_Tra_MS_CV_Lien_Quan(grvLoaiBTPN_CV.GetDataRow(i)("MS_CV"), strThongBao)
            If bHoi = False And strThongBao.Trim <> "" Then If XtraMessageBox.Show(strThongBao, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Return False
            bHoi = True
            If bKiemTra = True Then
                If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)) > 0 Then
                    If (grvLoaiBTPN_PT.RowCount <> 0) Then
                        sSql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "'"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                    End If
                End If

                If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)) > 0 Then
                    'XÓA DL CỦA BẢNG PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET
                    If (grvLoaiBTPN_PT.RowCount <> 0) Then
                        sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                        'XÓA DL PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG
                        sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                    End If

                End If
            End If
        Next
        Return True
    End Function

    Private Function Kiem_Tra_MS_CV_Lien_Quan(ByVal MS_CV As Integer, Optional ByRef strThongBao As String = "") As Boolean
        Dim bKHTT As Boolean = False, bPBT As Boolean = False
        Dim strTam As String = ""
        Dim dtReader As SqlDataReader
        Dim sSql As String = ""
        strThongBao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CONG_VIEC_DANG_DUOC_SU_DUNG", Commons.Modules.TypeLanguage).ToString.Trim

        sSql = "SELECT ISNULL(COUNT(*),0) AS TONG FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_CV=" & MS_CV & " AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") & ")"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bPBT = True
                strTam = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)
                Exit While
            End If
        End While
        dtReader.Close()

        sSql = "SELECT ISNULL(COUNT(*),0) AS TONG FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_CV=" & MS_CV
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bKHTT = True
                If bPBT = True Then
                    strTam = strTam & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "AND", Commons.Modules.TypeLanguage) & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)
                Else
                    strTam = strTam & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)
                End If
                Exit While
            End If
        End While
        dtReader.Close()

        If bKHTT = True Or bPBT = True Then
            strThongBao += " " & strTam + vbCrLf & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHAC_XOA_CV", Commons.Modules.TypeLanguage)

            Return True
        Else
            strThongBao = ""
            Return False
        End If
    End Function


    Private Sub grdTHONG_SO_GSTT_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        If blnThoat Then Exit Sub
        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "functionHamToanCuc", "MsgQuyenKT1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        e.Cancel = True
    End Sub

    Private Sub grdTHONG_SO_GSTT_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)

    End Sub

    Sub LoadMS_DV_TG1()
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.Name = "cboDV_TG"
        comboBoxColumn.ValueMember = "MS_DV_TG"
        comboBoxColumn.DisplayMember = "TEN_DV_TG"
        comboBoxColumn.DataPropertyName = "MS_DV_TG"
        comboBoxColumn.DataSource = New MAYController().GetDON_VI_THOI_GIANs
    End Sub





    Private Sub txtMS_MAY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtNgayKTBH_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        ucDMTBi.txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(ucDMTBi.txtSO_THANG_BH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date)
    End Sub

    Private Sub LstMAY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If grvMay.RowCount <= 0 Then
            grdChuKiHC.DataSource = System.DBNull.Value
            grdLoaiBTPN_CV.DataSource = System.DBNull.Value
            grdTaiLieuTS.DataSource = System.DBNull.Value
            grdLoaiBTPN_PT.DataSource = System.DBNull.Value
            grdLoaiBTPN.DataSource = System.DBNull.Value
            grdThongSoBP.DataSource = System.DBNull.Value
            grdThongSoMay.DataSource = System.DBNull.Value
            grdCTTB_PT.DataSource = System.DBNull.Value
        End If
    End Sub
#End Region

#Region "Tab Cấu trúc thiết bị"

    Dim XtraOldNode As DevExpress.XtraTreeList.Nodes.TreeListNode                         'Lưu dữ giá trị của node hiện tại lúc không lưu dữ liệu
    Dim XtraPrevOldNode As DevExpress.XtraTreeList.Nodes.TreeListNode                        'Lưu dữ giá trị của node trước trong trường hợp xóa

    Dim sTrangThaiTabThietbi As String = String.Empty   'Ghi nhận trạng thái là thêm hay sửa
    Dim sMA_BP_OLD As String = String.Empty
    Dim sTEN_BP_OLD As String = String.Empty

    Sub ShowTreeRootXtra(ByVal sMS_MAY As String)
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If
        tvwCTTBi.DataSource = Nothing
        Dim sSql As String = ""

        If optHL.SelectedIndex < 1 Then
            sSql = "SELECT DISTINCT MS_MAY, MS_BO_PHAN,TEN_BO_PHAN, MS_PT, SO_LUONG, MS_BO_PHAN_CHA, GHI_CHU,HIEU_LUC,RUN_TIME, MS_DVT_RT, HINH, CLASS_ID, ISNULL(STT, 999) As STT,(MS_BO_PHAN + ' - ' +  TEN_BO_PHAN) AS TEN_BO_PHAN_HT FROM dbo.CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "'  UNION SELECT DISTINCT N'" & sMS_MAY & "'  AS MS_MAY, N'" & sMS_MAY & "' AS  MS_BO_PHAN, N'" & sMS_MAY & "' AS TEN_BO_PHAN, NULL AS MS_PT, NULL AS SO_LUONG, NULL AS MS_BO_PHAN_CHA, NULL AS GHI_CHU,NULL AS HIEU_LUC, NULL AS RUN_TIME, NULL AS MS_DVT_RT, NULL AS HINH, NULL AS CLASS_ID, -1 As STT, N'" & sMS_MAY & "' AS TEN_BO_PHAN_HT  ORDER BY STT "
        End If

        If optHL.SelectedIndex = 1 Then
            sSql = "SELECT DISTINCT MS_MAY, MS_BO_PHAN,TEN_BO_PHAN, MS_PT, SO_LUONG, MS_BO_PHAN_CHA, GHI_CHU,HIEU_LUC,RUN_TIME, MS_DVT_RT, HINH, CLASS_ID, ISNULL(STT, 999) As STT,(MS_BO_PHAN + ' - ' +  TEN_BO_PHAN) AS TEN_BO_PHAN_HT FROM dbo.CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND HIEU_LUC = 1  UNION SELECT DISTINCT N'" & sMS_MAY & "'  AS MS_MAY, N'" & sMS_MAY & "' AS  MS_BO_PHAN, N'" & sMS_MAY & "' AS TEN_BO_PHAN, NULL AS MS_PT, NULL AS SO_LUONG, NULL AS MS_BO_PHAN_CHA, NULL AS GHI_CHU,NULL AS HIEU_LUC, NULL AS RUN_TIME, NULL AS MS_DVT_RT, NULL AS HINH, NULL AS CLASS_ID, -1 As STT, N'" & sMS_MAY & "' AS TEN_BO_PHAN_HT  ORDER BY STT "
        End If

        If optHL.SelectedIndex = 2 Then
            sSql = "SELECT DISTINCT MS_MAY, MS_BO_PHAN,TEN_BO_PHAN, MS_PT, SO_LUONG, MS_BO_PHAN_CHA, GHI_CHU,HIEU_LUC,RUN_TIME, MS_DVT_RT, HINH, CLASS_ID, ISNULL(STT, 999) As STT,(MS_BO_PHAN + ' - ' +  TEN_BO_PHAN) AS TEN_BO_PHAN_HT FROM dbo.CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND HIEU_LUC = 0  UNION SELECT DISTINCT N'" & sMS_MAY & "'  AS MS_MAY, N'" & sMS_MAY & "' AS  MS_BO_PHAN, N'" & sMS_MAY & "' AS TEN_BO_PHAN, NULL AS MS_PT, NULL AS SO_LUONG, NULL AS MS_BO_PHAN_CHA, NULL AS GHI_CHU,NULL AS HIEU_LUC, NULL AS RUN_TIME, NULL AS MS_DVT_RT, NULL AS HINH, NULL AS CLASS_ID, -1 As STT, N'" & sMS_MAY & "' AS TEN_BO_PHAN_HT  ORDER BY STT "
        End If

        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

        tvwCTTBi.BeginUpdate()
        tvwCTTBi.KeyFieldName = "MS_BO_PHAN"
        tvwCTTBi.ParentFieldName = "MS_BO_PHAN_CHA"
        tvwCTTBi.OptionsBehavior.Editable = False
        tvwCTTBi.DataSource = dtTmp

        For i = 0 To tvwCTTBi.Columns.Count - 1
            tvwCTTBi.Columns(i).Visible = False
            dtTmp.Columns(i).AllowDBNull = True
        Next
        tvwCTTBi.Columns("TEN_BO_PHAN_HT").Visible = True
        tvwCTTBi.Columns("TEN_BO_PHAN_HT").BestFit()
        tvwCTTBi.Columns("TEN_BO_PHAN_HT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        tvwCTTBi.ExpandAll()
        tvwCTTBi.EndUpdate()
        tvwCTTBi.Columns("TEN_BO_PHAN_HT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpDanhsachcautruc", Commons.Modules.TypeLanguage) '+ ": " + ucDMTBi.txtMS_MAY.Text
        tvwCTTBi.Columns("TEN_BO_PHAN_HT").BestFit()

        If tvwCTTBi.AllNodesCount <= 0 Then tvwCTTBi_FocusedNodeChanged(Nothing, Nothing)
    End Sub

    Dim MS_PT_CHA_CHECK As String = "-1"
    Sub BindTextValue()
        If tvwCTTBi.FocusedNode("MS_MAY").ToString().Trim().ToLower() = grvMay.GetFocusedRowCellValue("MS_MAY").ToString().Trim().ToLower() And
            tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString().Trim().ToLower() = grvMay.GetFocusedRowCellValue("MS_MAY").ToString().Trim().ToLower() And
            tvwCTTBi.FocusedNode("TEN_BO_PHAN").ToString().Trim().ToLower() = grvMay.GetFocusedRowCellValue("MS_MAY").ToString().Trim().ToLower() And
            Convert.ToInt16(tvwCTTBi.FocusedNode("STT").ToString()) = -1 Then
            refesh1()
        Else
            txtMS_BO_PHAN.Text = IIf(IsDBNull(tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString()), String.Empty, tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString())
            txtTEN_BO_PHAN.Text = IIf(IsDBNull(tvwCTTBi.FocusedNode("TEN_BO_PHAN").ToString()), String.Empty, tvwCTTBi.FocusedNode("TEN_BO_PHAN").ToString().ToString())
            txtSO_LUONG.Text = IIf(IsDBNull(tvwCTTBi.FocusedNode("SO_LUONG").ToString()), String.Empty, tvwCTTBi.FocusedNode("SO_LUONG").ToString())
            txtGHI_CHU.Text = IIf(IsDBNull(tvwCTTBi.FocusedNode("GHI_CHU").ToString()), String.Empty, tvwCTTBi.FocusedNode("GHI_CHU").ToString())
            chk_active.Checked = Convert.ToBoolean(tvwCTTBi.FocusedNode("HIEU_LUC"))
            txtSTT.Text = IIf(IsDBNull(tvwCTTBi.FocusedNode("STT").ToString()), String.Empty, tvwCTTBi.FocusedNode("STT").ToString())
            TxtHINH.Text = IIf(IsDBNull(tvwCTTBi.FocusedNode("HINH").ToString()), String.Empty, tvwCTTBi.FocusedNode("HINH").ToString())
            flagPTCha = True
            CboPT_BP.EditValue = IIf(IsDBNull(tvwCTTBi.FocusedNode("MS_PT").ToString()), "-1", tvwCTTBi.FocusedNode("MS_PT").ToString())
            If CboPT_BP.EditValue.ToString.Trim = "" Then
                CboPT_BP.Text = IIf(IsDBNull(tvwCTTBi.FocusedNode("MS_PT").ToString()), "-1", tvwCTTBi.FocusedNode("MS_PT").ToString())
            End If
            flagPTCha = False
            MS_PT_CHA_CHECK = IIf(IsDBNull(tvwCTTBi.FocusedNode("MS_PT").ToString()), "-1", tvwCTTBi.FocusedNode("MS_PT").ToString())
            cboClass.EditValue = -1
            cboClass.EditValue = IIf(IsDBNull(tvwCTTBi.FocusedNode("CLASS_ID").ToString()), String.Empty, tvwCTTBi.FocusedNode("CLASS_ID"))
        End If
    End Sub
    Sub ShowTHONG_SO_BP()
        'Xóa dữ liệu trên lưới grdThongsoBP
        Me.grdThongSoBP.DataSource = Nothing
        Try
            If grdMay.DataSource Is Nothing Then Exit Sub
            If grvMay.RowCount = 0 Then Exit Sub
        Catch ex As Exception
        End Try
        Dim oCTTBbase As New CAU_TRUC_THIET_BI
        dtTSBP = oCTTBbase.getThongSoBP(grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString())
        dtTSBP.Columns("TEN_THONG_SO").MaxLength = 250
        dtTSBP.Columns("GIA_TRI_THONG_SO").MaxLength = 250
        dtTSBP.Columns("GIA_TRI_THONG_SO").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongSoBP, grvThongSoBP, dtTSBP, False, True, True, True, True, "frmThongtinthietbi")
        grvThongSoBP.Columns("TEN_THONG_SO").Width = 400
        grvThongSoBP.Columns("STT").Visible = False
    End Sub
    Sub ShowTHONG_TIN_PT()
        'Xóa dữ liệu trên lưới grvPT
        Try
            Me.grdCTTB_PT.DataSource = Nothing
            Try
                If grdMay.DataSource Is Nothing Then Exit Sub
                If grvMay.RowCount = 0 Then Exit Sub
            Catch ex As Exception
            End Try
            Dim oCTTBbase As New CAU_TRUC_THIET_BI

            Dim dtTTPT As New DataTable
            If tvwCTTBi.Nodes(0)("MS_MAY").ToString().Trim().ToLower() = grvMay.GetFocusedRowCellValue("MS_MAY").ToString().Trim().ToLower() And
                tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString().Trim().ToLower() = grvMay.GetFocusedRowCellValue("MS_MAY").ToString().Trim().ToLower() And
                tvwCTTBi.FocusedNode("TEN_BO_PHAN").ToString().Trim().ToLower() = grvMay.GetFocusedRowCellValue("MS_MAY").ToString().Trim().ToLower() And
                Convert.ToInt16(tvwCTTBi.FocusedNode("STT").ToString()) = -1 Then
                dtTTPT = oCTTBbase.getThongTinPT("-1", "-1", Commons.Modules.TypeLanguage)
            Else
                dtTTPT = oCTTBbase.getThongTinPT(grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), txtMS_BO_PHAN.Text, Commons.Modules.TypeLanguage)
            End If
            dtTTPT.Columns("ACTIVE").ReadOnly = False
            dtTTPT.Columns("DGVND_MIN").ReadOnly = True
            dtTTPT.Columns("DGVND_MAX").ReadOnly = True
            dtTTPT.Columns("CHUC_NANG").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCTTB_PT, grvCTTB_PT, dtTTPT, False, False, False, True, True, "frmThongtinthietbi")
            FormatGridPT()
            Try
                grvCTTB_PT.Columns("ACTIVE").OptionsColumn.ReadOnly = False
                grvCTTB_PT.Columns("CHUC_NANG").OptionsColumn.ReadOnly = False
                grvCTTB_PT.Columns("PTVT").Visible = False
                grvCTTB_PT.Columns("TEN_PT_VIET").Visible = False
                grvCTTB_PT.Columns("MS_PT_CTY").Visible = False
                grvCTTB_PT.Columns("MS_PT").VisibleIndex = 1
                grvCTTB_PT.Columns("TEN_PT").VisibleIndex = 2
                grvCTTB_PT.Columns("MS_VI_TRI_PT").VisibleIndex = 3
                grvCTTB_PT.Columns("SO_LUONG").VisibleIndex = 4
                grvCTTB_PT.Columns("DVT").VisibleIndex = 5
                grvCTTB_PT.Columns("TUOI_THO").VisibleIndex = 6
                grvCTTB_PT.Columns("SL_TON").VisibleIndex = 7
                grvCTTB_PT.Columns("DGVND_MIN").VisibleIndex = 8
                grvCTTB_PT.Columns("DGVND_MAX").VisibleIndex = 9
                grvCTTB_PT.Columns("CHUC_NANG").VisibleIndex = 10
                grvCTTB_PT.Columns("MS_PT_NCC").VisibleIndex = 11
                grvCTTB_PT.Columns("QUY_CACH").VisibleIndex = 12
                grvCTTB_PT.Columns("ACTIVE").VisibleIndex = 13
            Catch ex As Exception
            End Try
            grvCTTB_PT.Columns("SL_TON").Visible = If(ShowTonKho = False, False, True)

        Catch ex As Exception
        End Try
        Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
        Try
            opts.Columns.StoreAllOptions = True
            'grvCTTB_PT.RestoreLayoutFromXml(Application.StartupPath + "\XML\GrdMayCTTBPT.xml", opts)
            'grdCTTB_PT.MainView.RestoreLayoutFromRegistry(regCTTB)
            grvCTTB_PT.Columns("SL_TON").Visible = If(ShowTonKho = False, False, True)
        Catch ex As Exception
        End Try
    End Sub

    Sub ObjectEnable(ByVal visible As Boolean)
        txtMS_BO_PHAN.Properties.ReadOnly = Not visible
        txtTEN_BO_PHAN.Properties.ReadOnly = Not visible
        chk_active.Properties.ReadOnly = Not visible
        txtSO_LUONG.Properties.ReadOnly = Not visible
        CboPT_BP.Properties.ReadOnly = Not visible
        txtSTT.Properties.ReadOnly = Not visible
        TxtHINH.Properties.ReadOnly = Not visible
        cboClass.Properties.ReadOnly = Not visible
        txtGHI_CHU.Properties.ReadOnly = Not visible

        BtnTimPTCmb.Enabled = visible
        BtnThem4.Visible = Not visible
        BtnSua4.Visible = Not visible
        BtnXoa4.Visible = Not visible
        BtnGhi4.Visible = visible
        BtnKhongGhi4.Visible = visible
        BtnThemSuaTSvaPT.Visible = Not visible
        BtnThemSuaCVBP.Visible = Not visible
        BtnXoaCVBP.Visible = Not visible
        BtnThemSuaTSGSTT_BP.Visible = Not visible
        BtnXoaTSGSTT_BP.Visible = Not visible
        'Gọi thủ tục định dạng lưới
        txtTimMay.Properties.ReadOnly = visible
        tvwCTTBi.Enabled = Not visible
        grdMay.Enabled = Not visible
    End Sub

    Sub FormatGridPT()
        Try
            With grvCTTB_PT
                .Columns("MS_PT").Width = 80
                .Columns("MS_PT").OptionsColumn.ReadOnly = True
                .Columns("MS_VI_TRI_PT").Width = 100
                .Columns("MS_VI_TRI_PT").OptionsColumn.ReadOnly = False
                .Columns("SO_LUONG").Width = 80
                .Columns("SO_LUONG").OptionsColumn.ReadOnly = False
                .Columns("SL_TON").Width = 80
                .Columns("SL_TON").OptionsColumn.ReadOnly = True
                .Columns("MS_PT_NCC").Width = 60
                .Columns("MS_PT_NCC").OptionsColumn.ReadOnly = True
                .Columns("MS_PT_CTY").Width = 60
                .Columns("MS_PT_CTY").OptionsColumn.ReadOnly = True
                .Columns("TEN_PT").Width = 150
                .Columns("TEN_PT").OptionsColumn.ReadOnly = True
                .Columns("TEN_PT_VIET").Width = 150
                .Columns("TEN_PT_VIET").OptionsColumn.ReadOnly = True
                .Columns("DVT").Width = 40
                .Columns("TUOI_THO").OptionsColumn.ReadOnly = True
                .Columns("TUOI_THO").Width = 80
                .Columns("DVT").OptionsColumn.ReadOnly = True
                .Columns("QUY_CACH").Width = 100
                .Columns("QUY_CACH").OptionsColumn.ReadOnly = True
                .Columns("CHUC_NANG").Width = 100
                .Columns("CHUC_NANG").OptionsColumn.ReadOnly = False
                .Columns("SL_TON").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
                .Columns("SL_TON").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                .Columns("SO_LUONG").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
                .Columns("SO_LUONG").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                .Columns("DGVND_MIN").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
                .Columns("DGVND_MIN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                .Columns("DGVND_MAX").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
                .Columns("DGVND_MAX").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                .Columns("TUOI_THO").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL)
                .Columns("TUOI_THO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            End With
        Catch ex As Exception

        End Try


        Try
            If ShowTonKho = False Then
                grvCTTB_PT.Columns("SL_TON").Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub ClearValue_AddNew()
        sMA_BP_OLD = txtMS_BO_PHAN.Text
        txtMS_BO_PHAN.Text = String.Empty
        txtTEN_BO_PHAN.Text = String.Empty
        txtSO_LUONG.Text = 1
        chk_active.Checked = True
        txtGHI_CHU.Text = String.Empty
        TxtHINH.Text = String.Empty
    End Sub

    ' <summary>
    ' Thủ tục lưu dữ liệu vào bảng của tab Cấu trúc thiết bị
    ' thủ tục này sẽ thực hiện việc lưu dữ liệu vào 3 bảng CAU_TRUC_THIET_BI,THONG_SO_BO_PHAN,CAU_TRUC_TB_PHU_TUNG
    ' </summary>
    ' <param name="sDK">A : Thêm, E : Sửa</param>
    ' <remarks></remarks>
    Sub Save_CAU_TRUC_TB(ByVal sDK As String)
        Dim i As Integer
        luuThanhCong = False
        i = 0
        Try

            'Xử lý việc lưu dữ liệu vào bảng CAU_TRUC_THIET_BI (Thêm và Sửa)
            Dim sMS_MAY As String = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            Dim sMS_BP As String = Commons.Modules.ObjSystems.SplitString(txtMS_BO_PHAN.Text.Trim())

            Dim sMS_BP_CHA As String
            If tvwCTTBi.AllNodesCount = 1 Then
                sMS_BP_CHA = ucDMTBi.txtMS_MAY.Text
            Else
                sMS_BP_CHA = tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString()
            End If
            If sMS_BP_CHA = "" Then sMS_BP_CHA = ucDMTBi.txtMS_MAY.Text
            Dim sTEN_BP As String = txtTEN_BO_PHAN.Text.Trim() 'Commons.Modules.ObjSystems.SplitString(txtTEN_BO_PHAN.Text.Trim())
            Dim nSO_LUONG As Integer = Convert.ToInt32(txtSO_LUONG.Text)    'Chưa kiểm tra phải nhập số
            Dim nSO_TT As Integer = Convert.ToInt32(txtSTT.Text)    'Chưa kiểm tra phải nhập số
            Dim sGHI_CHU As String = txtGHI_CHU.Text
            Dim bActive As Boolean = chk_active.EditValue
            Dim sHINH As String = TxtHINH.Text
            'Dim nRUN_TIME As Double = Convert.ToDouble(txtRUN_TIME.Text)    'Chưa kiểm tra phải nhập số
            Dim nRUN_TIME As Double = Convert.ToDouble(0)    'Chưa kiểm tra phải nhập số
            Dim nMS_DVT As Integer = Nothing
            Dim strPT_BP As String = ""
            If Not String.IsNullOrEmpty(CboPT_BP.Text) Then
                strPT_BP = IIf(IsDBNull(CboPT_BP.EditValue.ToString), Nothing, CboPT_BP.EditValue.ToString)
            End If

            Dim strClass As String = IIf(IsDBNull(cboClass.EditValue.ToString) Or cboClass.EditValue.ToString = "-1" Or cboClass.Text.Trim = "", Nothing, cboClass.EditValue.ToString)


            Dim SqlText As String
            'Kiểm tra trùng khóa
            If sDK.Trim().ToUpper() = "A" Then
                SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN=N'" & sMS_BP.Replace("'", "''") & "'"
            Else
                SqlText = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN=N'" & sMS_BP.Replace("'", "''") & "' AND MS_BO_PHAN <>N'" & sMA_BP_OLD.Replace("'", "''") & "'"
            End If

            Dim oExists As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            If oExists.Read Then
                'Trùng khóa
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT23", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            oExists.Close()
            Try
                If sDK.Trim().ToUpper() = "A" Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "sp_Insert_Cautructhietbi", sMS_MAY, sMS_BP, sTEN_BP, nSO_LUONG, nSO_TT, sMS_BP_CHA, sGHI_CHU, Convert.ToBoolean(chk_active.EditValue), nRUN_TIME, nMS_DVT, sHINH, strPT_BP.Trim(), strClass)
                    Commons.Modules.ObjSystems.LuuDuongDan(strHinhNguon, TxtHINH.Text)
                ElseIf sDK.Trim().ToUpper() = "E" Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE MAY_LOAI_BTPN_CONG_VIEC SET MS_BO_PHAN='" & sMS_BP & "' WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN= '" & sMS_BP_OLD & "'")
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE CAU_TRUC_THIET_BI_TS_GSTT SET MS_BO_PHAN='" & sMS_BP & "' WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN= '" & sMS_BP_OLD & "'")
                    If Convert.ToBoolean(tvwCTTBi.FocusedNode("HIEU_LUC")) <> Convert.ToBoolean(chk_active.EditValue) Then
                        'kiểm tra check thèn cha có trùng với những thèn con không
                        Dim dt As New DataTable
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM [dbo].[MGetAllChild_BOPHAN] ('" & sMS_MAY & "','" & sMS_BP & "')"))
                        If dt.Rows.Count > 0 Then
                            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgBanCoMuonCNBoPhanCon", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                                'nếu có thì cập nhật active hết thèn con theo thèn cha
                                Dim sSql = ""
                                For index = 0 To dt.Rows.Count - 1
                                    sSql = "UPDATE dbo.CAU_TRUC_THIET_BI SET HIEU_LUC = CASE '" & Convert.ToBoolean(chk_active.EditValue).ToString().ToUpper() & "' WHEN 'TRUE' THEN 1 ELSE 0 END WHERE MS_MAY ='" & sMS_MAY & "' AND MS_BO_PHAN ='" & dt.Rows(index)("MS_BO_PHAN") & "' "
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                                Next
                            End If
                        End If
                    End If
                    'ngược lại thì thôi
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "sp_Update_Cautructhietbi", sMS_MAY, sMS_BP, sTEN_BP, Convert.ToInt32(nSO_LUONG), nSO_TT, sGHI_CHU, Convert.ToBoolean(chk_active.EditValue), Convert.ToDouble(nRUN_TIME), Convert.ToInt32(nMS_DVT), sMA_BP_OLD, sHINH, strPT_BP, strClass)
                    Commons.Modules.ObjSystems.Xoahinh(strHinh)
                    Commons.Modules.ObjSystems.LuuDuongDan(strHinhNguon, TxtHINH.Text)
                End If


            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT24", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
            Try
                SqlText = "UPDATE CAU_TRUC_THIET_BI SET TEN_BO_PHAN_ANH = N'" + Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu + "' , STT = " & If(txtSTT.Text.Trim() = "", "NULL", txtSTT.Text.Trim()) & ", ACTIVE = " & IIf(bActive = True, 1, 0) & " WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN=N'" & sMS_BP.Replace("'", "''") & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


            Catch
            End Try

            Commons.Modules.SQLString = ""
            ShowTreeRootXtra(sMS_MAY)



            Commons.Modules.SQLString = "0Load"
            blnThemSuaCauTruc = False
            Call ObjectEnable(False)
            sTrangThaiTabThietbi = String.Empty
            luuThanhCong = True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub Delete_CAU_TRUC_TB()
        If txtMS_BO_PHAN.Text.Trim().Equals(String.Empty) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT25", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim sMS_MAY As String = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
        Dim sMS_BP As String = txtMS_BO_PHAN.Text
        Dim SqlText As String = "DELETE FROM dbo.THONG_SO_BO_PHAN WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN='" & sMS_BP & "'"
        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT34", Commons.Modules.TypeLanguage)
        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

            SqlText = "DELETE FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN='" & sMS_BP & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

            SqlText = "DELETE FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN='" & sMS_BP & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

            ShowTreeRootXtra(sMS_MAY)

            If tvwCTTBi.AllNodesCount > 0 Then

                Try
                    tvwCTTBi.Focus()
                    tvwCTTBi.SetFocusedNode(XtraPrevOldNode)
                Catch ex As Exception
                    tvwCTTBi.SetFocusedNode(tvwCTTBi.Nodes(0))
                End Try

            End If

            blnThemSuaCauTruc = False
            Call ObjectEnable(False)
            Refresh()
            If tvwCTTBi.AllNodesCount = 1 Then refesh1()

        End If
    End Sub

    Function Addnew_CAU_TRUC_TB() As Boolean

        If grvMay.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenKT26", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        'Phải định con trỏ vào node bất kỳ trong trường hợp người dùng chưa chọn

        Try
            If tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString().Trim = "" Then tvwCTTBi.SetFocusedNode(tvwCTTBi.Nodes(0))
        Catch ex As Exception
            If ucDMTBi.txtMS_MAY.Text = "" Then grvMay.FocusedRowHandle() = 0
        End Try


        Try
            If tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString() Is Nothing Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenKT27", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If

        Catch ex As Exception
            If ucDMTBi.txtMS_MAY.Text = "" Then XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    Me.Name, "MsgQuyenKT27", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        If txtSTT.EditValue = "" Then
            txtSTT.EditValue = 99
        End If


        blnThemSuaCauTruc = True
        Call ObjectEnable(True)
        Call ClearValue_AddNew()
        sTrangThaiTabThietbi = "A"
        Return True
    End Function

    Sub Edit_CAU_TRUC_TB()
        sTrangThaiTabThietbi = "E"
        sMA_BP_OLD = txtMS_BO_PHAN.Text
        sTEN_BP_OLD = txtTEN_BO_PHAN.Text
        If String.IsNullOrEmpty(txtMS_BO_PHAN.Text.Trim()) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT28", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        blnThemSuaCauTruc = True
        ObjectEnable(True)
    End Sub

    Sub Revert_CAU_TRUC_TB()
        ObjectEnable(False)
        'Chọn lại node trước đó
        tvwCTTBi.SetFocusedNode(XtraOldNode)
        BindTextValue()
        blnThemSuaCauTruc = False

    End Sub

    Private Sub BtnThem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem4.Click
        If Addnew_CAU_TRUC_TB() = False Then Exit Sub
        CboPT_BP.EditValue = ""

        Tab2Sub.Enabled = False
        txtMS_BO_PHAN.Focus()
        LockControl(True)
        cboClass.Properties.ReadOnly = False

        LoadCmbPT_BP()
    End Sub

    Private Sub BtnKhongGhi4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongGhi4.Click
        Call Revert_CAU_TRUC_TB()
        LockControl(False)
        Tab2Sub.Enabled = True
        cboClass.Properties.ReadOnly = True
    End Sub

    Private Sub BtnGhi4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi4.Click
        Try
            If txtMS_BO_PHAN.Text.Trim() = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        Me.Name, "msgChuaNhapMaSoPhuTung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMS_BO_PHAN.Focus()
                Exit Sub
            End If
            If txtTEN_BO_PHAN.Text = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        Me.Name, "msgChuaNhapTenPhuTung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTEN_BO_PHAN.Focus()
                Exit Sub
            End If
            If txtSO_LUONG.Text = "" Or Not IsNumeric(txtSO_LUONG.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        Me.Name, "msgChuaNhapSoLuong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSO_LUONG.Focus()
                Exit Sub
            End If
            If txtSTT.Text.Trim() <> "" And Not IsNumeric(txtSTT.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        Me.Name, "msgSTTLaSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSTT.Focus()
                Exit Sub
            End If

            If txtSTT.Text <= 0 And Not IsNumeric(txtSTT.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmMucUT", "MsgSoDuong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSTT.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try


        If (sTrangThaiTabThietbi = "E") Then
            Commons.Modules.SQLString = "0Load"
        End If

        Dim MS_BO_PHAN_TMP As String = txtMS_BO_PHAN.Text.Trim

        Call Save_CAU_TRUC_TB(sTrangThaiTabThietbi)
        If luuThanhCong = False Then Exit Sub
        '''''LstMAY.Enabled = True

        cboClass.Properties.ReadOnly = True
        LockControl(False)
        Tab2Sub.Enabled = True
        Try
            tvwCTTBi.SetFocusedNode(tvwCTTBi.FindNodeByFieldValue("MS_BO_PHAN", MS_BO_PHAN_TMP))
            Commons.Modules.SQLString = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnSua4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua4.Click
        If txtMS_BO_PHAN.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenSua2", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Ban vui long chon bo phan can sua
            Exit Sub
        End If

        sMS_BP_OLD = txtMS_BO_PHAN.Text
        Call Edit_CAU_TRUC_TB()
        LockControl(True)
        Tab2Sub.Enabled = False
        'LstMAY.Enabled = False

        If (Not cboClass.EditValue Is Nothing) Then
            If (Not cboClass.EditValue.Equals(DBNull.Value)) Then
                Dim _sqlstring As String = " SELECT COUNT(PHIEU_BAO_TRI_CLASS.MS_PHIEU_BAO_TRI) FROM  dbo.PHIEU_BAO_TRI INNER JOIN " &
                    " dbo.PHIEU_BAO_TRI_CLASS ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CLASS.MS_PHIEU_BAO_TRI " &
                    " WHERE  dbo.PHIEU_BAO_TRI.MS_MAY = N'" + grvMay.GetFocusedRowCellValue("MS_MAY").ToString() + "' AND dbo.PHIEU_BAO_TRI_CLASS.MS_BO_PHAN = N'" + Commons.Modules.ObjSystems.SplitString(txtMS_BO_PHAN.Text) + "' AND dbo.PHIEU_BAO_TRI_CLASS.CLASS_ID = N'" + cboClass.EditValue.ToString() + "'"
                Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, _sqlstring)
                If (_count Is Nothing) Then
                    cboClass.Properties.ReadOnly = False
                Else
                    If (CType(_count, Integer) > 0) Then
                        cboClass.Properties.ReadOnly = True
                    Else
                        cboClass.Properties.ReadOnly = False
                    End If
                End If
            Else
                cboClass.Properties.ReadOnly = False
            End If

        Else
            cboClass.Properties.ReadOnly = False
        End If


        If CheckMSBP() Then
            txtMS_BO_PHAN.Properties.ReadOnly = True
        Else
            txtMS_BO_PHAN.Properties.ReadOnly = False
        End If
        txtMS_BO_PHAN.Focus()

        flagPTCha = True
        LoadCmbPT_BP()
        flagPTCha = False
    End Sub
    Dim flagPTCha As Boolean = False
    Private Function CheckMSBP() As Boolean
        Try
            Dim sMS_MAY As String = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            Dim sMS_BP As String = Commons.Modules.ObjSystems.SplitString(txtMS_BO_PHAN.Text)
            Dim result As Integer = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_NHU_Y_CHECK_EXIST_PART", sMS_MAY, sMS_BP)
            If result <= 0 Then
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
        Return True
    End Function

    Private Sub BtnXoa4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa4.Click
        If txtMS_BO_PHAN.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT39", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim SqlText As String
        Dim sMS_MAY As String = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
        Dim sMS_BP As String = txtMS_BO_PHAN.Text
        Dim dtreader As SqlDataReader

        SqlText = "SELECT MS_BO_PHAN FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA = N'" & sMS_BP.Replace("'", "''") & "' AND MS_MAY=N'" & sMS_MAY & "'"

        dtreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        While dtreader.Read
            ' Bạn phải xóa các bộ phận con của của bộ phận này trước đã !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa50", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtreader.Close()
            Exit Sub
        End While
        dtreader.Close()

        If grvThongSoBP.RowCount > 0 Or grvCTTB_PT.RowCount > 0 Or grvCTTB_TS.RowCount > 0 Or grvCTTB_CV.RowCount > 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT40", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (Not cboClass.EditValue Is Nothing) Then
            If (Not IsDBNull(cboClass.EditValue)) Then
                Dim _sqlstring As String = "SELECT COUNT(PHIEU_BAO_TRI_CLASS.MS_PHIEU_BAO_TRI)FROM         dbo.PHIEU_BAO_TRI INNER JOIN " &
                  "dbo.PHIEU_BAO_TRI_CLASS ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CLASS.MS_PHIEU_BAO_TRI " &
                  "WHERE  dbo.PHIEU_BAO_TRI.MS_MAY = N'" + grvMay.GetFocusedRowCellValue("MS_MAY").ToString() + "' AND dbo.PHIEU_BAO_TRI_CLASS.MS_BO_PHAN = N'" + Commons.Modules.ObjSystems.SplitString(txtMS_BO_PHAN.Text) + "' AND dbo.PHIEU_BAO_TRI_CLASS.CLASS_ID = N'" + cboClass.EditValue.ToString() + "'"
                Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, _sqlstring)
                If (Not _count Is Nothing) Then
                    If (CType(_count, Integer) > 0) Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ClassInPBT", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                End If
            End If
        End If


        SqlText = ""
        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT34", Commons.Modules.TypeLanguage)
        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Try
            SqlText = "DELETE FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN=N'" & sMS_BP.Replace("'", "''") & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgDangSuDungKhongtheXoa", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        ShowTreeRootXtra(sMS_MAY)
        If Not XtraPrevOldNode Is Nothing Then
            If tvwCTTBi.AllNodesCount > 0 Then
                Try
                    tvwCTTBi.Focus()
                    tvwCTTBi.SetFocusedNode(XtraPrevOldNode)
                Catch ex As Exception
                    tvwCTTBi.SetFocusedNode(tvwCTTBi.Nodes(0))
                End Try
            End If
        End If
        Call ObjectEnable(False)
        Refresh()
        If tvwCTTBi.AllNodesCount = 1 Then refesh1()

    End Sub


    Private Sub btnThoat4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        blnThoat = True
        Me.Controls.Clear()
        Me.Close()
    End Sub
#End Region

#Region "TAM1"

    Sub refesh1()
        grdCTTB_PT.DataSource = System.DBNull.Value
        grdThongSoBP.DataSource = System.DBNull.Value
        txtMS_BO_PHAN.Text = ""
        txtTEN_BO_PHAN.Text = ""
        txtSO_LUONG.Text = ""
        txtGHI_CHU.Text = ""
        TxtHINH.Text = ""
        txtSTT.Text = ""
        CboPT_BP.EditValue = -1
        cboClass.EditValue = -1
    End Sub

    Private Sub btnDMThongso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmThongsoGSTT.Show()
    End Sub


    Private Sub BtnXoaPT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaPT.Click
        If grvLoaiBTPN_PT.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa32", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Không có dữ liệu để xóa 
            Exit Sub
        End If
        Dim traloi As String
        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaPTBaoTri", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        Dim strThongBao As String = ""
        Dim sSql As String = ""
        If traloi = vbCancel Then
            Exit Sub
        ElseIf traloi = vbNo Then
            'chỉ làm cho kido, các nơi khác thì thông báo kg xóa được
            Kiem_Tra_MS_VTPT_Lien_Quan(grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT"), strThongBao)
            If strThongBao.Trim <> "" Then
                If XtraMessageBox.Show(strThongBao, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Exit Sub

                If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)) > 0 Then
                    sSql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                End If

                If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)) > 0 Then
                    'XÓA DL CỦA BẢNG PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET
                    sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                    'XÓA DL PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG
                    sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                End If
            End If

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG", ucDMTBi.txtMS_MAY.Text, grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT"), grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV"), grvLoaiBTPN_PT.GetFocusedDataRow()(1), grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN"))
        Else
            If Kiem_Tra_DS_VTPT_Lien_Quan(strThongBao) = False Then Exit Sub
            sSql = "DELETE FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT=" & grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") & " AND MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        End If

        TaoLuoiBTPNPT(New MAYController().GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG(ucDMTBi.txtMS_MAY.Text, grvLoaiBTPN.GetFocusedDataRow("MS_LOAI_BT"), Me.grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV"), Commons.Modules.TypeLanguage, Me.grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN")))


    End Sub





    Function getMS_LOAI_MAY(ByVal sMsMAY As String) As String
        Dim KQ As String = String.Empty
        Dim oRead As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM MAY WHERE MS_MAY=N'" & sMsMAY & "'")
        While oRead.Read
            KQ = IIf(IsDBNull(oRead("MS_NHOM_MAY")), String.Empty, oRead("MS_NHOM_MAY").ToString())
        End While
        oRead.Close()
        Return KQ
    End Function

    Sub Select_TT_PT()
        Dim dtNew As New DataTable
        Dim drNew As DataRow
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim flag As Boolean = True
        dtNew = CType(grdCTTB_PT.DataSource, DataTable).Copy()

        Dim fPT As New frmChonPhuTung()
        fPT.MS_MAY = ucDMTBi.txtMS_MAY.Text
        fPT.MS_BP = txtMS_BO_PHAN.Text
        fPT.MS_LOAI_MAY = ucDMTBi.cboMS_LOAI_MAY.EditValue
        fPT.Size = New Size(900, 600)

        If fPT.ShowDialog() = Windows.Forms.DialogResult.OK Then

            dtNew.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT IC_PHU_TUNG.MS_PT,MS_VI_TRI_PT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG,MS_PT_NCC,MS_PT_CTY,TEN_PT,TEN_PT_VIET,DVT,QUY_CACH," &
                    " CHUC_NANG,ACTIVE FROM IC_PHU_TUNG LEFT JOIN CAU_TRUC_THIET_BI_PHU_TUNG ON IC_PHU_TUNG.MS_PT=CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT " &
                    " WHERE IC_PHU_TUNG.MS_PT='VietSoft'"))

            Dim dt As DataTable = CType(fPT.grdPT.DataSource, DataTable)
            dt.DefaultView.RowFilter = "chkChon = true"
            dt = dt.DefaultView.ToTable()
            For i = 0 To dt.Rows.Count - 1
                If fPT.grvPT.GetDataRow(i)("chkChon") = True Then
                    While j < IIf(fPT.grvPT.GetDataRow(i)("TxtSoDong") = 0, 1, fPT.grvPT.GetDataRow(i)("TxtSoDong"))
                        drNew = dtNew.NewRow
                        drNew.Item("MS_PT") = dt.Rows(i)("MS_PT")
                        drNew.Item("MS_VI_TRI_PT") = "A"
                        drNew.Item("SO_LUONG") = 1
                        drNew.Item("MS_PT_NCC") = dt.Rows(i)("MS_PT_NCC")
                        drNew.Item("MS_PT_CTY") = dt.Rows(i)("MS_PT_CTY")
                        drNew.Item("TEN_PT") = dt.Rows(i)("TEN_PT")
                        drNew.Item("TEN_PT_VIET") = dt.Rows(i)("TEN_PT_VIET")
                        drNew.Item("DVT") = dt.Rows(i)("DVT")
                        drNew.Item("QUY_CACH") = dt.Rows(i)("QUY_CACH")
                        drNew.Item("CHUC_NANG") = ""
                        drNew.Item("ACTIVE") = True
                        dtNew.Rows.Add(drNew)
                        j = j + 1
                    End While

                End If
                j = 0
            Next
            dtNew.Columns("ACTIVE").ReadOnly = False
            dtNew.Columns("CHUC_NANG").ReadOnly = False

            grdCTTB_PT.DataSource = dtNew
        End If
    End Sub

    Private Sub TxtHINH_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not BtnThem4.Visible Then
            strHinh = TxtHINH.Text
            OfdHInh.ShowDialog()
        End If
    End Sub

    Private strHinhNguon As String = ""

    Private Sub OfdHInh_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OfdHInh.FileOk
        Dim strDuongDan As String = ""
        strDuongDan = Commons.Modules.ObjSystems.CapnhatTL(False, ucDMTBi.txtMS_MAY.Text)
        Dim str As String = "", str1 As String = ""
        strHinhNguon = OfdHInh.FileName
        str = "SELECT ANH_TB FROM MAY WHERE ANH_TB<>'' AND MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        str = strDuongDan & "\" & "CTTB_" & ucDMTBi.txtMS_MAY.Text & "_" & txtMS_BO_PHAN.Text.Replace("/", "_") & "_" & IIf(Day(Now()).ToString.Length < 2, 0 & Day(Now()), Day(Now())) & IIf(Month(Now()).ToString.Length < 2, 0 & Month(Now()), Month(Now())) & Year(Now()) & Commons.Modules.ObjSystems.LayDuoiFile(OfdHInh.FileName)
        TxtHINH.Text = str
    End Sub

    Private Sub BtnTaoMoiTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTaoMoiTB.Click
        Dim frmNhapThietBiMoi As New frmNhapThietBiMoi()
        frmNhapThietBiMoi.MS_MAY = ucDMTBi.txtMS_MAY.Text
        frmNhapThietBiMoi.ATTACHMENT = False
        frmNhapThietBiMoi.StartPosition = FormStartPosition.CenterParent
        frmNhapThietBiMoi.ShowDialog()

        If Commons.Modules.SQLString = "" Then Exit Sub

        Dim sMsLuu As String
        sMsLuu = Commons.Modules.SQLString
        LoadMay()
        Try
            If sMsLuu <> "" Then
                'Dim dt As DataTable
                'dt = CType(grdMay.DataSource, DataTable)

                'Dim index As Integer = dt.Rows.IndexOf(dt.Rows.Find(sMsLuu))
                'grvMay.FocusedRowHandle = grvMay.GetRowHandle(index)

                Dim index As Integer
                index = grvMay.LocateByValue(0, grvMay.Columns("MS_MAY"), sMsLuu)
                If index <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                    If (index <> grvMay.FocusedRowHandle) Then
                        grvMay.FocusedRowHandle = index
                        grvMay.SelectRow(index)
                    Else
                        grvMay_FocusedRowChanged(Nothing, Nothing)
                    End If
                End If

            End If
        Catch ex As Exception
            Commons.Modules.SQLString = ""
        End Try
    End Sub

    Public Sub LocDuLieu()
        Dim dtTmp As New DataTable
        Try

            dtTmp = CType(grdMay.DataSource, DataTable)
            If (optHienTrang.SelectedIndex = 0) Then
                dtTmp.DefaultView.RowFilter = "MS_HIEN_TRANG = 2 AND MS_HT IS NOT NULL AND (MS_MAY like '%" + txtTimMay.Text + "%' OR TEN_MAY like '%" + txtTimMay.Text + "%' OR SERIAL_NUMBER like '%" + txtTimMay.Text + "%')"
            ElseIf (optHienTrang.SelectedIndex = 1) Then
                dtTmp.DefaultView.RowFilter = "MS_HIEN_TRANG <> 2 AND MS_HT IS NOT NULL AND (MS_MAY like '%" + txtTimMay.Text + "%' OR TEN_MAY like '%" + txtTimMay.Text + "%' OR SERIAL_NUMBER like '%" + txtTimMay.Text + "%')"
            Else
                dtTmp.DefaultView.RowFilter = "MS_HT IS NULL AND (MS_MAY like '%" + txtTimMay.Text + "%' OR TEN_MAY like '%" + txtTimMay.Text + "%' OR SERIAL_NUMBER like '%" + txtTimMay.Text + "%')"
            End If
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
        ThayDoiMay()
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub txtMS_BO_PHAN_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtSO_LUONG.Text = 1
    End Sub

    Private Sub BtnTSBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTSBP.Click
        frmThongsothietbi.ShowDialog()
        BindData1()
    End Sub

    Private Sub BtnXoa44_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa44.Click
        HideButtonXoaTSvaPT(False)
        blnXoa_TS = False
        LockControlSub(False)
    End Sub


    Private Sub BtnXoa43_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If grvCTTB_PT.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT39", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim dtReader As SqlDataReader
        SQL = "SELECT * FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_PT='" & grvCTTB_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT43", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End While
        dtReader.Close()
        Dim sMS_MAY As String = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
        Dim sMS_BP As String = txtMS_BO_PHAN.Text

        Dim SqlText As String
        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT42", Commons.Modules.TypeLanguage)
        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlText = "DELETE FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN='" & sMS_BP & "' AND MS_PT='" & grvCTTB_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_VI_TRI_PT='" & grvCTTB_PT.GetFocusedDataRow()("MS_VI_TRI_PT") & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            Call ShowTHONG_TIN_PT()
        End If

    End Sub

    Private Sub GrdTool_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        If blnThoat Then Exit Sub
    End Sub


    Private Sub txtMS_BO_PHAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMS_BO_PHAN.Validating
        If Not BtnGhi4.Visible Then Exit Sub
        If txtMS_BO_PHAN.Text.Trim = ucDMTBi.txtMS_MAY.Text.Trim Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT52", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If

        If sTrangThaiTabThietbi = "A" Or (sTrangThaiTabThietbi = "S" And txtMS_BO_PHAN.Text <> sMA_BP_OLD) Then
            SQL = "MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
            If Commons.Modules.ObjSystems.KiemTraTrung("CAU_TRUC_THIET_BI", "MS_BO_PHAN", SQL, txtMS_BO_PHAN.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "functionHamToanCuc", "MsgQuyenKT1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BtnChonPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonPT.Click
        If grvLoaiBTPN_CV.RowCount < 1 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT44", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim dtNew As New DataTable
        Dim drNew As DataRow
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim flag As Boolean = True

        Dim str As String = ""
        dtNew.Clear()
        dtNew.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG", ucDMTBi.txtMS_MAY.Text, grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT"), Me.grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV"), Commons.Modules.TypeLanguage, grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN")))

        Dim _MS_BO_PHAN As String = ""
        Dim dtReader_DVT As SqlDataReader
        _MS_BO_PHAN = grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN")
        Dim fPT As New FrmChonPTchoBTPN()
        fPT.MS_MAY = ucDMTBi.txtMS_MAY.Text
        fPT.MS_CV = grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV")
        fPT.MS_LOAI_BT = Convert.ToInt32(grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT"))
        fPT.MS_LOAI_TB = ucDMTBi.cboMS_LOAI_MAY.EditValue
        fPT.MS_BO_PHAN = _MS_BO_PHAN
        If fPT.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For i = 0 To fPT.grvPT.RowCount - 1
                If Convert.ToBoolean(fPT.grvPT.GetRowCellValue(i, "CHON").ToString) = True Then
                    drNew = dtNew.NewRow
                    For j = 0 To dtNew.Rows.Count - 1
                        If fPT.grvPT.GetRowCellValue(i, "MS_PT").ToString = dtNew.Rows(j).Item(1) Then
                            flag = False
                            Exit For
                        End If

                        flag = True
                    Next
                    If flag Then
                        drNew.Item("TEN_LOAI_VT") = fPT.grvPT.GetRowCellValue(i, "TEN_LOAI_VT").ToString
                        drNew.Item("MS_PT") = fPT.grvPT.GetRowCellValue(i, "MS_PT").ToString
                        drNew.Item("TEN_PT") = fPT.grvPT.GetRowCellValue(i, "TEN_PT").ToString
                        drNew.Item("TEN_PT_VIET") = fPT.grvPT.GetRowCellValue(i, "TEN_PT_VIET").ToString
                        drNew.Item("SO_LUONG") = 1
                        drNew.Item("QUY_CACH") = fPT.grvPT.GetRowCellValue(i, "QUY_CACH").ToString

                        dtReader_DVT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT " & IIf(Commons.Modules.TypeLanguage = 0, "TEN_1", "TEN_2") &
                                " FROM DON_VI_TINH WHERE DVT='" & fPT.grvPT.GetRowCellValue(i, "DVT").ToString & "'")
                        While dtReader_DVT.Read
                            drNew.Item("DVT") = dtReader_DVT(0)
                            dtReader_DVT.Close()
                            Exit While
                        End While

                        Dim sql As String
                        sql = "SELECT SUM(SO_LUONG) AS SL_MAX FROM dbo.CAU_TRUC_THIET_BI_PHU_TUNG WHERE ACTIVE = 1 GROUP BY MS_MAY, MS_PT, " &
                                " MS_BO_PHAN HAVING (MS_MAY = N'" + ucDMTBi.txtMS_MAY.Text + "') AND (MS_BO_PHAN = N'" + grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") + "') " &
                                " AND (MS_PT = N'" + drNew.Item("MS_PT") + "')"
                        Dim dttmp As New DataTable()


                        Dim SLuong As Double

                        dttmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                        If dttmp.Rows.Count > 0 Then
                            SLuong = Double.Parse(dttmp.Rows(0)(0).ToString())
                        Else
                            SLuong = 0
                        End If
                        drNew.Item("SL_MAX") = SLuong
                        drNew.Item("SO_LUONG") = SLuong
                        dtNew.Rows.Add(drNew)
                    End If
                End If
            Next

            For i = 0 To fPT.grvVT.RowCount - 1
                If Convert.ToBoolean(fPT.grvVT.GetRowCellValue(i, "CHON").ToString) = True Then
                    drNew = dtNew.NewRow
                    For j = 0 To dtNew.Rows.Count - 1
                        If fPT.grvVT.GetRowCellValue(i, "MS_PT").ToString = dtNew.Rows(j).Item(1) Then
                            flag = False
                            Exit For
                        End If

                        flag = True
                    Next
                    If flag Then

                        drNew.Item("TEN_LOAI_VT") = fPT.grvVT.GetRowCellValue(i, "TEN_LOAI_VT").ToString
                        drNew.Item("MS_PT") = fPT.grvVT.GetRowCellValue(i, "MS_PT").ToString
                        drNew.Item("TEN_PT") = fPT.grvVT.GetRowCellValue(i, "TEN_PT").ToString
                        drNew.Item("TEN_PT_VIET") = fPT.grvVT.GetRowCellValue(i, "TEN_PT_VIET").ToString
                        drNew.Item("SO_LUONG") = IIf(fPT.grvVT.GetRowCellValue(i, "SO_LUONG").ToString = 0, 1, fPT.grvVT.GetRowCellValue(i, "SO_LUONG").ToString)
                        drNew.Item("QUY_CACH") = fPT.grvVT.GetRowCellValue(i, "QUY_CACH").ToString

                        dtReader_DVT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT " & IIf(Commons.Modules.TypeLanguage = 0, "TEN_1", "TEN_2") & " FROM DON_VI_TINH WHERE DVT='" & fPT.grvVT.GetRowCellValue(i, "DVT").ToString & "'")
                        While dtReader_DVT.Read
                            drNew.Item("DVT") = dtReader_DVT(0)
                            dtReader_DVT.Close()
                            Exit While
                        End While
                        dtNew.Rows.Add(drNew)
                    End If
                End If
            Next
            TaoLuoiBTPNPT(dtNew)
        End If
    End Sub

#Region "Tìm kiếm"

    ' Hàm này dùng để tìm kiếm tự động khi người sử dụng nhập vào.
    Public Sub AutoCompleteCbo(ByRef cb As System.Windows.Forms.ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim strFindStr As String
        If e.KeyChar = Chr(8) Then  'Backspace
            If cb.SelectionStart <= 1 Then
                cb.Text = ""
                Exit Sub
            End If
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
            End If
        Else

            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text & e.KeyChar
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
            End If
        End If
        Dim intIdx As Integer = -1
        ' Search the string in the Combo Box List.
        intIdx = cb.FindString(strFindStr)

        If intIdx <> -1 Then ' String found in the List.
            cb.SelectedText = ""
            cb.SelectedIndex = intIdx
            cb.SelectionStart = strFindStr.Length
            cb.SelectionLength = cb.Text.Length
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub


#End Region
    Private Sub txtTY_LE_CON_LAI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not BtnGhi.Visible Then Exit Sub
        If IsNumeric(ucDMTBi.txtTY_LE_CON_LAI.Text) Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(ucDMTBi.txtTY_LE_CON_LAI.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ucDMTBi.txtTY_LE_CON_LAI.Focus()
                e.Cancel = True
            End If
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucDMTBi.txtTY_LE_CON_LAI.Focus()
            e.Cancel = True
        End If
    End Sub


    Private Sub txtSO_LUONG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSTT.Validating, txtSO_LUONG.Validating
        If Not BtnGhi4.Visible Then Exit Sub

        If txtSO_LUONG.Text = 0 Then txtSO_LUONG.Text = 1
        If IsNumeric(txtSO_LUONG.Text) Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(txtSO_LUONG.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtSO_LUONG.Focus()
                e.Cancel = True
            End If
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSO_LUONG.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnGiaTriTSGSTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmGiatrithongsoGSTT As Report1.frmGiatrithongsoGSTT = New Report1.frmGiatrithongsoGSTT()
        frmGiatrithongsoGSTT.ShowDialog()
    End Sub

#End Region

#Region "Document List Event"
    Private Sub btnThemsua1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemsua1.Click
        If ucDMTBi.txtMS_MAY.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenThem3", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'XtraMessageBox.Show("Bạn vui lòng tạo mới 1 thiết bị ", MsgBoxStyle.Information, "Thông báo ")
            Exit Sub
        End If
        SERVER_PATH = Commons.Modules.ObjSystems.CapnhatTL(True, ucDMTBi.txtMS_MAY.Text)

        grvTaiLieuTS.OptionsBehavior.Editable = True
        grvTaiLieuTS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        grvTaiLieuTS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        grvTaiLieuTS.Columns("MS_MAY").OptionsColumn.ReadOnly = True
        grvTaiLieuTS.Columns("NOI_LUU_TRU").OptionsColumn.ReadOnly = True
        grvTaiLieuTS.Columns("NOI_LUU_TRU").OptionsColumn.AllowEdit = False

        HideButton1(True)
        LockControl(True)
        rowCount = grvThongSoMay.RowCount - 1
        rowCount1 = grvTaiLieuTS.RowCount - 1
        grvThongSoMay.OptionsBehavior.Editable = True
        grvThongSoMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        grvThongSoMay.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

        txtLuuY.Properties.ReadOnly = False

        grvThongSoMay.Columns("MS_MAY").OptionsColumn.ReadOnly = True

        intSTT = Commons.Modules.ObjSystems.LaySTTChoTaiLieu("SELECT NOI_LUU_TRU FROM MAY_TAI_LIEU WHERE MS_MAY=N'" & Me.ucDMTBi.txtMS_MAY.Text & "'")
        grvThongSoMay.Columns("TEN_DV_DO").OptionsColumn.ReadOnly = True

    End Sub
    Private Sub btnXoa1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa1.Click
        If grvThongSoMay.RowCount <= 0 And grvTaiLieuTS.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa8", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        HideButton11(True)
    End Sub


    Private Sub btnGhi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi1.Click
        If loi Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi10", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'XtraMessageBox.Show("Có lỗi khi ghi dữ liệu, vui lòng kiểm tra lại ", MsgBoxStyle.Information, "Thông báo ")
            Exit Sub
        End If

        Dim j As Integer = 0
        While j < Me.grvTaiLieuTS.RowCount - 1
            If Me.grvTaiLieuTS.GetDataRow(j)("TEN_TAI_LIEU").ToString.Trim = "" Then
                ' Tên tài liệu không được rỗng, bạn vui lòng nhập tên tài liệu !
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTentailieurong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.grvTaiLieuTS.FocusedColumn = grvTaiLieuTS.Columns("TEN_TAI_LIEU")
                Exit Sub
            End If
            j = j + 1
        End While

        Dim str As String = "DELETE THONG_SO_CHINH_MAY WHERE MS_MAY = '" & ucDMTBi.txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            For i = 0 To grvThongSoMay.RowCount - 1
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddTHONG_SO_CHINH_MAY",
                          ucDMTBi.txtMS_MAY.Text, grvThongSoMay.GetDataRow(i)("MS_THONG_SO_MAY"),
                          grvThongSoMay.GetDataRow(i)("GIA_TRI"),
                          grvThongSoMay.GetDataRow(i)("GHI_CHU"),
                          grvThongSoMay.GetDataRow(i)("GIA_TRI_MIN"),
                          grvThongSoMay.GetDataRow(i)("GIA_TRI_MAX"))
            Next
        Catch ex As Exception
        End Try
        GhiTailieu()
        BindData2()

        SQL = "UPDATE MAY SET LUU_Y_SU_DUNG=N'" & txtLuuY.Text & "' WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        HideButton1(False)

        grvThongSoMay.OptionsBehavior.Editable = False
        grvThongSoMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        grvThongSoMay.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

        grvTaiLieuTS.OptionsBehavior.Editable = False
        grvTaiLieuTS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        grvTaiLieuTS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None


        txtLuuY.Properties.ReadOnly = True
        LockControl(False)
        UpdateAnToan(ucDMTBi.txtMS_MAY.Text)

    End Sub
    Private Sub UpdateAnToan(ByVal MS_MAY As String)
        Try
            If chxAnToan.Checked = True Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE MAY SET AN_TOAN = 1 WHERE MS_MAY=N'" & MS_MAY & "'")
            Else
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE MAY SET AN_TOAN = 0 WHERE MS_MAY=N'" & MS_MAY & "'")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKhongghi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongghi1.Click
        Dim dtReader As SqlDataReader
        HideButton1(False)

        grdThongSoMay.DataSource = New MAYController().GetTHONG_SO_CHINH_MAYs(ucDMTBi.txtMS_MAY.Text)
        BindData2()

        grvThongSoMay.OptionsBehavior.Editable = False
        grvThongSoMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        grvThongSoMay.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

        grvTaiLieuTS.OptionsBehavior.Editable = False
        grvTaiLieuTS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        grvTaiLieuTS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

        SQL = "SELECT LUU_Y_SU_DUNG FROM MAY WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        Try
            While dtReader.Read
                txtLuuY.Text = IIf(IsDBNull(dtReader.Item("LUU_Y_SU_DUNG")), String.Empty, dtReader.Item("LUU_Y_SU_DUNG"))
            End While
        Catch ex As Exception
            txtLuuY.Text = ""
        End Try
        dtReader.Close()
        txtLuuY.Properties.ReadOnly = True


        LockControl(False)

    End Sub



    Private Sub OFDTaiLieuMay_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OFDTaiLieuMay.FileOk
        LayDuongDan()
    End Sub
    Private Sub BtnXemTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemTL.Click
        If grvTaiLieuTS.RowCount < 1 Then
            Exit Sub
        End If
        Try
            System.Diagnostics.Process.Start(Me.grvTaiLieuTS.GetFocusedDataRow()("NOI_LUU_TRU").ToString)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT45", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub BtnXoaDMTL_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaDMTL.Click
        Dim traloi As String
        If grvTaiLieuTS.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa11", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa12", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If traloi = vbNo Then Exit Sub
        Dim objMAYController As New MAYController()
        Try

            objMAYController.DeleteMAY_TAI_LIEU(Convert.ToInt32(grvTaiLieuTS.GetFocusedDataRow()("MA_TAI_LIEU")), grvTaiLieuTS.GetFocusedDataRow()("MS_MAY"))
            If System.IO.File.Exists(grvTaiLieuTS.GetFocusedDataRow()("NOI_LUU_TRU").ToString()) Then
                System.IO.File.Delete(grvTaiLieuTS.GetFocusedDataRow()("NOI_LUU_TRU").ToString())
            End If
        Catch ex As Exception

        End Try

        Dim tmp As Integer = intTab42
        BindData2()
        If grvTaiLieuTS.RowCount > 0 Then
            If grvTaiLieuTS.RowCount = tmp Then
                grvTaiLieuTS.FocusedRowHandle = tmp - 1
            Else
                grvTaiLieuTS.FocusedRowHandle = tmp
            End If
        End If
    End Sub

#End Region

#Region "Document List Method"
    Sub GhiTailieu()
        For i As Integer = 0 To grvTaiLieuTS.RowCount - 2
            Dim objMAY_TAI_LIEUController As New MAY_TAI_LIEUController()
            Dim objMAY_TAI_LIEUInfo As New MAY_TAI_LIEUInfo()
            objMAY_TAI_LIEUInfo.MS_MAY = ucDMTBi.txtMS_MAY.Text  'LstMAY.Text
            objMAY_TAI_LIEUInfo.NOI_LUU_TRU = grvTaiLieuTS.GetDataRow(i)("NOI_LUU_TRU")
            objMAY_TAI_LIEUInfo.TEN_TAI_LIEU = grvTaiLieuTS.GetDataRow(i)("TEN_TAI_LIEU")
            Try
                objMAY_TAI_LIEUInfo.GHI_CHU = grvTaiLieuTS.GetDataRow(i)("GHI_CHU")

            Catch ex As Exception
                objMAY_TAI_LIEUInfo.GHI_CHU = ""
            End Try

            Try
                objMAY_TAI_LIEUInfo.SO_TAI_LIEU = grvTaiLieuTS.GetDataRow(i)("SO_TAI_LIEU")
            Catch ex As Exception
                objMAY_TAI_LIEUInfo.SO_TAI_LIEU = ""
            End Try



            If i < rowCount1 Then
                objMAY_TAI_LIEUInfo.MA_TAI_LIEU = grvTaiLieuTS.GetDataRow(i)("MA_TAI_LIEU")
                objMAY_TAI_LIEUController.UpdateMAY_TAI_LIEU(objMAY_TAI_LIEUInfo)
            Else
                objMAY_TAI_LIEUController.AddMAY_TAI_LIEU(objMAY_TAI_LIEUInfo)
                Commons.Modules.ObjSystems.LuuDuongDan(grvTaiLieuTS.GetDataRow(i)("HINH"), grvTaiLieuTS.GetDataRow(i)("NOI_LUU_TRU"))
            End If

        Next
    End Sub
    Sub LayDuongDan()

        Dim FILE_PATHs As String()
        Dim FILE_NAMEs As String()
        FILE_PATHs = OFDTaiLieuMay.FileNames()
        FILE_NAMEs = OFDTaiLieuMay.SafeFileNames()

        For i As Integer = 0 To FILE_PATHs.Length - 1
            Dim info As New System.IO.FileInfo(FILE_PATHs(i))
            If Commons.Modules.sPrivate <> "BARIA" Then
                If info.Length > 5242880 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgFileLonHon5Mb", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        Next

        Dim tmp As New DataTable()
        tmp = dtTAI_LIEU.Clone()
        tmp.Columns(2).AllowDBNull = True
        For i As Integer = 0 To grvTaiLieuTS.RowCount - 2
            Dim dr As DataRow
            dr = tmp.NewRow
            dr.Item("MS_MAY") = grvTaiLieuTS.GetDataRow(i)("MS_MAY") 'dtTAI_LIEU.Rows(i).Item(0)
            dr.Item("MA_TAI_LIEU") = grvTaiLieuTS.GetDataRow(i)("MA_TAI_LIEU")
            dr.Item("NOI_LUU_TRU") = grvTaiLieuTS.GetDataRow(i)("NOI_LUU_TRU").ToString
            dr.Item("TEN_TAI_LIEU") = grvTaiLieuTS.GetDataRow(i)("TEN_TAI_LIEU").ToString
            dr.Item("HINH") = grvTaiLieuTS.GetDataRow(i)("HINH").ToString
            dr.Item("SO_TAI_LIEU") = grvTaiLieuTS.GetDataRow(i)("SO_TAI_LIEU").ToString
            dr.Item("GHI_CHU") = grvTaiLieuTS.GetDataRow(i)("GHI_CHU").ToString
            tmp.Rows.Add(dr)
        Next
        Dim TenFile As String
        For i As Integer = 0 To FILE_PATHs.Length - 1
            Dim dr As DataRow
            dr = tmp.NewRow
            dr.Item(0) = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() 'LstMAY.Text
            dr.Item(1) = 0
            TenFile = FILE_NAMEs(i).Replace(Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs(i)), "")

            dr.Item(2) = SERVER_PATH & "\" & TenFile & "_" & IIf(Day(Now()).ToString.Length < 2, 0 & Day(Now()), Day(Now())) & IIf(Month(Now()).ToString.Length < 2, 0 & Month(Now()), Month(Now())) & Year(Now()) & "_" & intSTT & Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs(i))
            dr.Item(3) = ""
            dr.Item(4) = FILE_PATHs(i)
            tmp.Rows.Add(dr)
            intSTT = intSTT + 1
        Next
        dtTAI_LIEU = tmp

        grdTaiLieuTS.DataSource = dtTAI_LIEU
        Me.grvTaiLieuTS.Columns("MS_MAY").Visible = False
        grvTaiLieuTS.Columns("MA_TAI_LIEU").Visible = False
        grvTaiLieuTS.Columns("HINH").Visible = False
        grvTaiLieuTS.Columns("SO_TAI_LIEU").Width = 120
        grvTaiLieuTS.Columns("TEN_TAI_LIEU").Width = 150
        grvTaiLieuTS.Columns("GHI_CHU").Width = 150
    End Sub

    Sub BindData2()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        dtTAI_LIEU = New MAYController().GetMAY_TAI_LIEUs(ucDMTBi.txtMS_MAY.Text)
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdTaiLieuTS, grvTaiLieuTS, dtTAI_LIEU, False, True, True, True, True, Me.Name)

        Me.grvTaiLieuTS.Columns("MS_MAY").Visible = False
        grvTaiLieuTS.Columns("MA_TAI_LIEU").Visible = False
        grvTaiLieuTS.Columns("HINH").Visible = False

        grvTaiLieuTS.Columns("SO_TAI_LIEU").Width = 120
        grvTaiLieuTS.Columns("TEN_TAI_LIEU").Width = 150
        grvTaiLieuTS.Columns("GHI_CHU").Width = 150

    End Sub
    Private Sub HideButton11(ByVal an As Boolean)
        btnThemsua1.Visible = Not an
        btnXoa1.Visible = Not an
        btnThoat1.Visible = Not an
        btnGhi1.Visible = Not an
        btnKhongghi1.Visible = Not an
        BtnXoaTSCTB.Visible = an
        BtnXoaDMTL.Visible = an
        BtnTroVe.Visible = an

    End Sub
    Private Sub HideButtonXoa1(ByVal an As Boolean)
        btnThemsua1.Visible = Not an
        btnXoa1.Visible = Not an
        btnThoat1.Visible = Not an
        BtnXoaTSCTB.Visible = an
        BtnXoaDMTL.Visible = an
        BtnTroVe.Visible = an

    End Sub

#End Region

#Region "Equipment Picture Event"

#End Region

#Region "Equipment Picture Method"
    Sub SaveHINH_THIET_BI()
        'Lưu vào thư mục TEMP
        Dim FILE_PATH As String = String.Empty
        Dim FILE_NAME As String = String.Empty
        Dim FILE_NAMEArr, FILE_NAME_WITH_EXTENSIONArr As String()
        Dim NEW_FILE_PATH As String = ucDMTBi.ofdHinhTB.FileName
        Dim OLD_FILE_NAME As String = String.Empty
        Dim objMAYController As New MAYController
        Dim FILE_NAME_WITH_EXTENSION As String = String.Empty


        If TEN_TAI_LIEU.Equals(String.Empty) = False Then
            If System.IO.Directory.Exists(HINH_THIET_BI_PATH) Then
                'Xóa file cũ
                Dim OLD_FILEArr = System.IO.Directory.GetFiles(HINH_THIET_BI_PATH)
                'Lấy ra tên file và phần mở rộng
                FILE_NAMEArr = NEW_FILE_PATH.Split("\")
                FILE_NAME = FILE_NAMEArr(FILE_NAMEArr.Length - 1)
                'Lưu với tên file mới
                FILE_NAME_WITH_EXTENSIONArr = FILE_NAME.Split(".")
                FILE_NAME_WITH_EXTENSION = FILE_NAME_WITH_EXTENSIONArr(FILE_NAME_WITH_EXTENSIONArr.Length - 1)
                If System.IO.File.Exists(HINH_THIET_BI_PATH & "\" & Me.ucDMTBi.txtMS_MAY.Text & "." & FILE_NAME_WITH_EXTENSION) Then
                    System.IO.File.Delete(HINH_THIET_BI_PATH & "\" & Me.ucDMTBi.txtMS_MAY.Text & "." & FILE_NAME_WITH_EXTENSION)
                End If
            End If
            System.IO.File.Create(HINH_THIET_BI_PATH & "\" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "." & FILE_NAME_WITH_EXTENSION)
            System.IO.File.Copy(NEW_FILE_PATH, HINH_THIET_BI_PATH & "\" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "." & FILE_NAME_WITH_EXTENSION)
            HINH_THIET_BI = HINH_THIET_BI_PATH & "\" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "." & FILE_NAME_WITH_EXTENSION
        End If
    End Sub
#End Region

#Region "Report"
    Private Sub btnThoat__Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat_.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    Shared Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        Dim t As String = CStr(Now.Day) + "/" + CStr(Now.Month) + "/" + CStr(Now.Year)
        Try
            SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & t & "',tenngayin='" & ngayanh & "' INTO dbo.rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & t & "',tenngayin='" & ngay & "' INTO dbo.rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If

    End Sub
    Private Sub RefeshLanguageReport3()
        Dim TIEU_DE, MS_MAY, LOAI_MAY, NHOM_MAY, THONG_SO_DINH_TINH As String
        Dim THONG_SO_DINH_LUONG, STT, TEN_THONG_SO, GIA_TRI_TREN, GIA_TRI_DUOI, DVT, CHU_KI, DVT_TG, TRANG, GT As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage)
        MS_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "MS_MAY", Commons.Modules.TypeLanguage)
        LOAI_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "LOAI_MAY", Commons.Modules.TypeLanguage)
        NHOM_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "NHOM_MAY", Commons.Modules.TypeLanguage)
        THONG_SO_DINH_TINH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", " THONG_SO_DINH_TINH", Commons.Modules.TypeLanguage)
        THONG_SO_DINH_LUONG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "THONG_SO_DINH_LUONG", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "STT", Commons.Modules.TypeLanguage)
        TEN_THONG_SO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "TEN_THONG_SO", Commons.Modules.TypeLanguage)
        GIA_TRI_TREN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "GIA_TRI_TREN", Commons.Modules.TypeLanguage)
        GIA_TRI_DUOI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "GIA_TRI_DUOI", Commons.Modules.TypeLanguage)
        DVT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "DVT", Commons.Modules.TypeLanguage)
        CHU_KI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "CHU_KI", Commons.Modules.TypeLanguage)
        DVT_TG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "DVT_TG", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "TRANG", Commons.Modules.TypeLanguage)
        GT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI", "GT", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI_lbl_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI_lbl_TMP(TIEU_DE_ nvarchar(50),MS_MAY_ nvarchar(50),LOAI_MAY_ nvarchar(50),NHOM_MAY_ nvarchar(50),THONG_SO_DINH_TINH_ nvarchar (50),THONG_SO_DINH_LUONG_ nvarchar(50),STT_ nvarchar(50),TEN_THONG_SO_ nvarchar(50),GIA_TRI_TREN_ nvarchar(50),GIA_TRI_DUOI_ nvarchar(50),DVT_ nvarchar(50),CHU_KI_ nvarchar(50),DVT_TG_ nvarchar(50),TRANG_ nvarchar(50),GT_ nvarchar(50))"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "insert_rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI_lbl_TMP", TIEU_DE, MS_MAY, LOAI_MAY, NHOM_MAY, STT, TEN_THONG_SO, CHU_KI, DVT_TG, TRANG, GT)
    End Sub
    Sub CreateData3()

        RefeshHeaderReport()
        RefeshLanguageReport3()

        Try
            SqlText = "DROP TABLE dbo.THONG_SO_DINH_TINH_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        Try
            SqlText = "DROP TABLE dbo.SUB_THONG_TINH_DINH_TINH_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        'LAY THONG TIN DINH LUONG ,DINH TINH VAO 2 BANG'
        SqlText = "SELECT DISTINCT '" & ucDMTBi.txtMS_MAY.Text & "' AS MS_MAY,'" & ucDMTBi.cboMS_NHOM_MAY.Text & "' AS TEN_NHOM_MAY,'" & ucDMTBi.cboMS_LOAI_MAY.Text & "' AS TEN_LOAI_MAY, CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, THONG_SO_GSTT.TEN_TS_GSTT, " &
        " GIA_TRI_TS_GSTT.TEN_GIA_TRI + '_' + GIA_TRI_TS_GSTT.GHI_CHU AS TEN_GIA_TRI, CAU_TRUC_THIET_BI_TS_GSTT.CHU_KY_DO,  " &
        " CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN DON_VI_THOI_GIAN.TEN_DV_TG WHEN 1 THEN DON_VI_THOI_GIAN.TEN_DV_TG_ANH ELSE  " &
        " DON_VI_THOI_GIAN.TEN_DV_TG_HOA END AS TEN_DV_TG INTO dbo.SUB_THONG_TINH_DINH_TINH_TMP  " &
        " FROM CAU_TRUC_THIET_BI_TS_GSTT INNER JOIN THONG_SO_GSTT ON CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = THONG_SO_GSTT.MS_TS_GSTT INNER JOIN " &
        " GIA_TRI_TS_GSTT ON THONG_SO_GSTT.MS_TS_GSTT = GIA_TRI_TS_GSTT.MS_TS_GSTT inner JOIN " &
        " DON_VI_THOI_GIAN ON CAU_TRUC_THIET_BI_TS_GSTT.MS_DV_TG = DON_VI_THOI_GIAN.MS_DV_TG " &
        " WHERE     CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Sub Printpreview3()

        Call ReportPreview("reports\rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI.rpt")

        Try
            SqlText = "DROP TABLE dbo.SUB_THONG_TINH_DINH_TINH_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI_lbl_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Shared Sub RefeshLanguageReport1()
        Dim MS_MAY, TEN_MAY, LOAI_MAY, NHOM_MAY, NHA_CUNG_CAP, MO_TA, KIEU, HANG_SAN_XUAT, NGAY_SX, NUOC_SX, NHIEM_VU, NGAY_DUA_VAO_SD, HIEN_TRANG_SU_DUNG, SO_NAM_DA_SD As String
        Dim MUC_UU_TIEN, NOI_LAP_DAT, BO_PHAN_TRA_PHI, NGAY_BD_BAO_HANH, NGAY_HET_BAO_HANH, SO_NGAY_LAM_TB, SO_GIO_LAM_TB, SO_THE, PHAN_TRAM, NGAY_MUA As String
        Dim GIA_MUA, TIEN_TE, SO_NAM_KH, NGAY_HET_KH, TIEU_DE, TT_CO_BAN, TT_SU_DUNG, TT_KE_TOAN, THONG_SO_CHINH, STT As String
        Dim TEN_THONG_SO, GIA_TRI, DVT, GHI_CHU, TRANG As String
        MS_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "MS_MAY", Commons.Modules.TypeLanguage)
        TEN_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TEN_MAY", Commons.Modules.TypeLanguage)
        LOAI_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "LOAI_MAY", Commons.Modules.TypeLanguage)
        NHOM_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NHOM_MAY", Commons.Modules.TypeLanguage)
        NHA_CUNG_CAP = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NHA_CUNG_CAP", Commons.Modules.TypeLanguage)
        MO_TA = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "MO_TA", Commons.Modules.TypeLanguage)
        KIEU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "KIEU", Commons.Modules.TypeLanguage)
        HANG_SAN_XUAT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "HANG_SAN_XUAT", Commons.Modules.TypeLanguage)
        NGAY_SX = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_SX", Commons.Modules.TypeLanguage)
        NUOC_SX = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NUOC_SX", Commons.Modules.TypeLanguage)
        NHIEM_VU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NHIEM_VU", Commons.Modules.TypeLanguage)
        NGAY_DUA_VAO_SD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_DUA_VAO_SD", Commons.Modules.TypeLanguage)
        HIEN_TRANG_SU_DUNG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "HIEN_TRANG_SU_DUNG", Commons.Modules.TypeLanguage)
        SO_NAM_DA_SD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_NAM_DA_SD", Commons.Modules.TypeLanguage)
        MUC_UU_TIEN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "MUC_UU_TIEN", Commons.Modules.TypeLanguage)
        NOI_LAP_DAT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NOI_LAP_DAT", Commons.Modules.TypeLanguage)
        BO_PHAN_TRA_PHI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "BO_PHAN_TRA_PHI", Commons.Modules.TypeLanguage)
        NGAY_BD_BAO_HANH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_BD_BAO_HANH", Commons.Modules.TypeLanguage)
        NGAY_HET_BAO_HANH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_HET_BAO_HANH", Commons.Modules.TypeLanguage)
        SO_NGAY_LAM_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_NGAY_LAM_TB", Commons.Modules.TypeLanguage)
        SO_GIO_LAM_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_GIO_LAM_TB", Commons.Modules.TypeLanguage)
        SO_THE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_THE", Commons.Modules.TypeLanguage)
        PHAN_TRAM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "PHAN_TRAM", Commons.Modules.TypeLanguage)
        NGAY_MUA = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_MUA", Commons.Modules.TypeLanguage)
        GIA_MUA = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "GIA_MUA", Commons.Modules.TypeLanguage)
        TIEN_TE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TIEN_TE", Commons.Modules.TypeLanguage)
        SO_NAM_KH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_NAM_KH", Commons.Modules.TypeLanguage)
        NGAY_HET_KH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_HET_KH", Commons.Modules.TypeLanguage)
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TIEU_DE", Commons.Modules.TypeLanguage)
        TT_CO_BAN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TT_CO_BAN", Commons.Modules.TypeLanguage)
        TT_SU_DUNG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TT_SU_DUNG", Commons.Modules.TypeLanguage)
        TT_KE_TOAN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TT_KE_TOAN", Commons.Modules.TypeLanguage)
        THONG_SO_CHINH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "THONG_SO_CHINH", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "STT", Commons.Modules.TypeLanguage)
        GIA_TRI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "GIA_TRI", Commons.Modules.TypeLanguage)
        DVT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "DVT", Commons.Modules.TypeLanguage)
        GHI_CHU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "GHI_CHU", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TRANG", Commons.Modules.TypeLanguage)
        TEN_THONG_SO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TEN_THONG_SO", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_VA_THONG_SO_TB_lbl"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptTHONG_TIN_CHUNG_VA_THONG_SO_TB_lbl(MS_MAY_ nvarchar(150),TEN_MAY NVARCHAR (150) , LOAI_MAY_ nvarchar(150),NHOM_MAY_ nvarchar(150),NHA_CUNG_CAP_ nvarchar(150),MO_TA_ nvarchar (150),KIEU_ nvarchar(50),HANG_SAN_XUAT_ nvarchar(50),NGAY_SX_ nvarchar(50),NUOC_SX_ nvarchar(150),NHIEM_VU_ nvarchar(150),NGAY_DUA_VAO_SD_ nvarchar(50),HIEN_TRANG_SU_DUNG_ nvarchar(50),SO_NAM_DA_SD_ nvarchar(50),MUC_UU_TIEN_ nvarchar(50),NOI_LAP_DAT_ nvarchar(150),BO_PHAN_TRA_PHI_	nvarchar(150),NGAY_BD_BAO_HANH_ nvarchar (50),NGAY_HET_BAO_HANH_ nvarchar(50),SO_NGAY_LAM_TB_	nvarchar (50),SO_GIO_LAM_TB_	nvarchar (50),SO_THE_	nvarchar(150),PHAN_TRAM_ nvarchar(50),NGAY_MUA_ nvarchar(50),GIA_MUA_	nvarchar(50),TIEN_TE_	nvarchar(50),SO_NAM_KH_ nvarchar(150),NGAY_HET_KH_ nvarchar(50),TIEU_DE_ nvarchar(50),TT_CO_BAN_ nvarchar(150),TT_SU_DUNG_	nvarchar(150),TT_KE_TOAN_ nvarchar (50),THONG_SO_CHINH_ nvarchar(50),STT_	nvarchar (50),TEN_THONG_SO_	nvarchar (50),GIA_TRI_	nvarchar(150),DVT_ nvarchar(50),GHI_CHU_ nvarchar(50),TRANG_	nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Try

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptTHONG_TIN_CHUNG_VA_THONG_SO_TB_lbl", MS_MAY, TEN_MAY, LOAI_MAY, NHOM_MAY, NHA_CUNG_CAP, MO_TA, KIEU, HANG_SAN_XUAT, NGAY_SX, NUOC_SX, NHIEM_VU, NGAY_DUA_VAO_SD, HIEN_TRANG_SU_DUNG, SO_NAM_DA_SD, MUC_UU_TIEN, NOI_LAP_DAT, BO_PHAN_TRA_PHI, NGAY_BD_BAO_HANH, NGAY_HET_BAO_HANH, SO_NGAY_LAM_TB, SO_GIO_LAM_TB, SO_THE, PHAN_TRAM, NGAY_MUA, GIA_MUA, TIEN_TE, SO_NAM_KH, NGAY_HET_KH, TIEU_DE, TT_CO_BAN, TT_SU_DUNG, TT_KE_TOAN, THONG_SO_CHINH, STT, TEN_THONG_SO, GIA_TRI, DVT, GHI_CHU, TRANG, Nothing, Nothing, Nothing, Nothing, Nothing)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CreateData1()

        RefeshHeaderReport()
        RefeshLanguageReport1()


        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_VA_THONG_SO_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        SqlText = "CREATE TABLE dbo.rptTHONG_TIN_CHUNG_VA_THONG_SO_TB(MS_MAY nvarchar(150),TEN_MAY nvarchar(150),LOAI_MAY nvarchar(150),NHOM_MAY nvarchar(150),NHA_CUNG_CAP nvarchar(150),MO_TA nvarchar (150),KIEU nvarchar(150),HANG_SAN_XUAT nvarchar(150),NGAY_SX nvarchar(150),NUOC_SX nvarchar(150),NHIEM_VU nvarchar(150),NGAY_DUA_VAO_SD nvarchar(150),HIEN_TRANG_SU_DUNG nvarchar(150),SO_NAM_DA_SD nvarchar(150),MUC_UU_TIEN nvarchar(150),NOI_LAP_DAT nvarchar(150),BO_PHAN_TRA_PHI	nvarchar(150),NGAY_BD_BAO_HANH nvarchar (150),NGAY_HET_BAO_HANH nvarchar(50),SO_NGAY_LAM_TB	nvarchar (150),SO_GIO_LAM_TB	nvarchar (150),SO_THE	nvarchar(150),PHAN_TRAM nvarchar(50),NGAY_MUA nvarchar(50),GIA_MUA	nvarchar(50),TIEN_TE	nvarchar(50),SO_NAM_KH	nvarchar(150),NGAY_HET_KH nvarchar(150),DVT nvarchar(200))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


        SqlText = "INSERT INTO dbo.rptTHONG_TIN_CHUNG_VA_THONG_SO_TB VALUES ('" & ucDMTBi.txtMS_MAY.Text & "',N'" & ucDMTBi.txtTEN_MAY.Text & "','" & ucDMTBi.cboMS_LOAI_MAY.Text & "','" & ucDMTBi.cboMS_NHOM_MAY.Text & "','" & ucDMTBi.cboMS_NCC.Text & "','" & ucDMTBi.txtMO_TA.Text & "','" & ucDMTBi.txtMODEL.Text & "','" & ucDMTBi.CboMS_HSX.Text & "','" & ucDMTBi.txtNGAY_SX.Text & "','" & ucDMTBi.txtNUOC_SX.Text & "','" & ucDMTBi.txtNHIEM_VU_THIET_BI.Text & "','" & ucDMTBi.txtNGAY_DUA_VAO_SD.Text & "','" & ucDMTBi.cboMS_HIEN_TRANG.Text & "','" & ucDMTBi.txtSO_NAM_SD.Text & "','" & ucDMTBi.cboMUC_UU_TIEN.Text & "','" & ucDMTBi.TxtMS_NHA_XUONG.Text & "','" & ucDMTBi.TxtMS_BP_CHIU_PHI.Text & "','" & ucDMTBi.txtNGAY_BD_BAO_HANH.Text & "','" & ucDMTBi.txtNgayKTBH.Text & "','" & ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text & "','" & ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text & "','" & ucDMTBi.txtSO_THE.Text & "','" & ucDMTBi.txtTY_LE_CON_LAI.Text & "','" & ucDMTBi.txtNGAY_MUA.Text & "','" & ucDMTBi.txtGIA_MUA.Text & "','" & ucDMTBi.cboNGOAI_TE.Text & "','" & ucDMTBi.txtSO_NAM_KHAU_HAO.Text & "','" & ucDMTBi.txtNgayHHKH.Text & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", ucDMTBi.txtMS_MAY.Text, ucDMTBi.cboMS_LOAI_MAY.Text, ucDMTBi.txtTEN_MAY.Text, ucDMTBi.cboMS_NHOM_MAY.Text, ucDMTBi.cboMS_NCC.Text, ucDMTBi.txtMO_TA.Text, ucDMTBi.txtMODEL.Text, ucDMTBi.CboMS_HSX.Text, ucDMTBi.txtNGAY_SX.Text, ucDMTBi.txtNUOC_SX.Text, ucDMTBi.txtNHIEM_VU_THIET_BI.Text, ucDMTBi.txtNGAY_DUA_VAO_SD.Text, ucDMTBi.cboMS_HIEN_TRANG.Text, ucDMTBi.txtSO_NAM_SD.Text, ucDMTBi.cboMUC_UU_TIEN.Text, ucDMTBi.TxtMS_NHA_XUONG.Text, ucDMTBi.TxtMS_BP_CHIU_PHI.Text, ucDMTBi.txtNGAY_BD_BAO_HANH.Text, ucDMTBi.txtNgayKTBH.Text, ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text, ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text, ucDMTBi.txtSO_THE.Text, ucDMTBi.txtTY_LE_CON_LAI.Text, ucDMTBi.txtNGAY_MUA.Text, ucDMTBi.txtGIA_MUA.Text, ucDMTBi.cboNGOAI_TE.Text, ucDMTBi.txtSO_NAM_KHAU_HAO.Text, ucDMTBi.txtNgayHHKH.Text)

        Try
            SqlText = "DROP TABLE rptMAY_THONG_SO_CHINH_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "SELECT TEN_THONG_SO_MAY,THONG_SO_CHINH_MAY.GIA_TRI,TEN_DV_DO ,THONG_SO_CHINH_MAY.GHI_CHU into dbo.rptMAY_THONG_SO_CHINH_MAY FROM THONG_SO_CHINH_MAY INNER JOIN THONG_SO_MAY ON THONG_SO_CHINH_MAY.MS_THONG_SO_MAY=THONG_SO_MAY.MS_THONG_SO_MAY INNER JOIN DON_VI_DO ON THONG_SO_MAY.MS_DV_DO=DON_VI_DO.MS_DV_DO  WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Private Sub Printpreview1()

        Call ReportPreview("reports\rptTHONG_TIN_CHUNG_VA_THONG_SO_TB.rpt")
        Cursor = Cursors.Default

        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_VA_THONG_SO_TB"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.rptMAY_THONG_SO_CHINH_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_VA_THONG_SO_TB_lbl"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThuchien.Click

        If grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB" Then
            Me.Cursor = Cursors.WaitCursor
            HPrint("rptTHONG_TIN_CHUNG_VA_THONG_SO_TB")
            'Try
            '    clsXuLy.CreateTitleReport()
            '    Call CreateData1()
            '    Call Printpreview1()

            'Catch ex As Exception

            'End Try

            Me.Cursor = Cursors.Default

            '11
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptLICH_BAO_TRI_DINH_KI" Then
            Me.Cursor = Cursors.WaitCursor
            HPrint("rptLICH_BAO_TRI_DINH_KI")
            Me.Cursor = Cursors.Default
            '7
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptLICH_GIAM_SAT_TINH_TRANG_THIET_BI" Then
            Me.Cursor = Cursors.WaitCursor
            Call CreateData3()
            Call Printpreview3()
            Me.Cursor = Cursors.Default
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptQUI_DINH_VE_GSTT_THIET_BI" Then
            Me.Cursor = Cursors.WaitCursor
            Commons.clsXuLy.CreateTitleReport()
            ShowrptQUI_DINH_VE_GSTT_THIET_BI()
            Me.Cursor = Cursors.Default
            '10
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptLICH_HIEU_CHUAN_THIET_BI" Then
            Me.Cursor = Cursors.WaitCursor
            HPrint("rptLICH_HIEU_CHUAN_THIET_BI")
            Me.Cursor = Cursors.Default
            '8
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptDANH_SACH_TAI_LIEU_THIET_BI" Then

            Me.Cursor = Cursors.WaitCursor
            HPrint("rptDANH_SACH_TAI_LIEU_THIET_BI")
            Me.Cursor = Cursors.Default
            '5
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptDanhsach_VTPT_TheoMay" Then

            Me.Cursor = Cursors.WaitCursor
            HPrint("rptDanhsach_VTPT_TheoMay")
            Me.Cursor = Cursors.Default
            '6
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptDANH_SACH_NOI_LAP_DAT_THIET_BI" Then
            Me.Cursor = Cursors.WaitCursor
            HPrint("rptDANH_SACH_NOI_LAP_DAT_THIET_BI")
            Me.Cursor = Cursors.Default
            '4
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptDANH_SACH_BP_CP_THIET_BI" Then
            Me.Cursor = Cursors.WaitCursor
            HPrint("rptDANH_SACH_BP_CP_THIET_BI")
            Me.Cursor = Cursors.Default
            '2
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptDANH_SACH_DC_THIET_BI_DUOC_LAP_DAT" Then
            Me.Cursor = Cursors.WaitCursor
            HPrint("rptDANH_SACH_DC_THIET_BI_DUOC_LAP_DAT")
            Me.Cursor = Cursors.Default
            '3
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "rptLICH_SU_VAT_TU_SD_CHO_TB" Then
            Me.Cursor = Cursors.WaitCursor
            HPrint("rptLICH_SU_VAT_TU_SD_CHO_TB")
            Me.Cursor = Cursors.Default
            '9
        ElseIf grvReport.GetFocusedDataRow()("REPORT_NAME").ToString() = "frmChonKhoInDMTB" Then
            Me.Cursor = Cursors.WaitCursor
            Dim frmForm = New ReportMain.Forms.frmChonKhoInDMTB
            frmForm.MsMay = ucDMTBi.txtMS_MAY.Text
            frmForm.TenMay = ucDMTBi.txtTEN_MAY.Text
            frmForm.ShowDialog()
            Me.Cursor = Cursors.Default
            '1
        End If

    End Sub
    Sub HPrint(rptname As String)
        Dim vtbData As New DataTable()
        Dim GroupBy As Integer = 0
        Try
            If rptname = "rptDANH_SACH_BP_CP_THIET_BI" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_rptDANH_SACH_BP_CP_THIET_BI", grvMay.GetFocusedRowCellValue("MS_MAY").ToString()))
                '2
            ElseIf rptname = "rptDANH_SACH_DC_THIET_BI_DUOC_LAP_DAT" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_rptDANH_SACH_DC_THIET_BI_DUOC_LAP_DAT", grvMay.GetFocusedRowCellValue("MS_MAY").ToString()))
                '3
            ElseIf rptname = "rptDANH_SACH_NOI_LAP_DAT_THIET_BI" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_rptDANH_SACH_NOI_LAP_DAT_THIET_BI", grvMay.GetFocusedRowCellValue("MS_MAY").ToString()))
                '4
            ElseIf rptname = "rptDANH_SACH_TAI_LIEU_THIET_BI" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_rptDANH_SACH_TAI_LIEU_THIET_BI", grvMay.GetFocusedRowCellValue("MS_MAY").ToString()))
                '5
            ElseIf rptname = "rptDanhsach_VTPT_TheoMay" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_rptDanhsach_VTPT_TheoMay", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), Commons.Modules.TypeLanguage.ToString()))
                '6
            ElseIf rptname = "rptLICH_BAO_TRI_DINH_KI" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_rptLICH_BAO_TRI_DINH_KI", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), Commons.Modules.TypeLanguage.ToString()))
                GroupBy = 2
                '7
            ElseIf rptname = "rptLICH_HIEU_CHUAN_THIET_BI" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_rptLICH_HIEU_CHUAN_THIET_BI", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), Commons.Modules.TypeLanguage.ToString()))
                '8
            ElseIf rptname = "rptLICH_SU_VAT_TU_SD_CHO_TB" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_rptLICH_SU_VAT_TU_SD_CHO_TB", grvMay.GetFocusedRowCellValue("MS_MAY").ToString()))
                '9
            ElseIf rptname = "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_rptMAY_THONG_SO_CHINH_MAY", grvMay.GetFocusedRowCellValue("MS_MAY").ToString()))
                '11
            End If
        Catch ex As Exception
        End Try


        vtbData.TableName = "DATA_INFO"

        If vtbData.Rows.Count > 0 Then

            Dim vtbTitle As New DataTable()
            For i As Integer = 0 To 9
                vtbTitle.Columns.Add()
            Next

            Commons.Modules.ObjSystems.MLoadXtraGrid(ucDMTBi.grdChung, ucDMTBi.grvChung, vtbData, False, True, True, True, True, Me.Name.ToString)
            If rptname = "rptLICH_BAO_TRI_DINH_KI" Then
                ucDMTBi.grvChung.Columns("TEN_LOAI_BT").Group()
                ucDMTBi.grvChung.Columns("TEN_BO_PHAN").Group()
                ucDMTBi.grvChung.ExpandAllGroups()
            End If
            InVB(rptname, GroupBy)
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region

#Region "tam 3"

    Private Sub BtnThemSuaTSvaPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThemSuaTSvaPT.Click
        If txtMS_BO_PHAN.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT26", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        blnThemSuaCauTrucSub = True
        HideButtonSub(True)

        LockControlSub(True)


        grvThongSoBP.OptionsBehavior.Editable = True
        grvThongSoBP.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        grvThongSoBP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True


    End Sub

    Sub HideButtonSub(ByVal An As Boolean)
        BtnThemSuaTSvaPT.Visible = Not An
        btnChon_PT.Visible = An
        BtnGhiTSvaPT.Visible = An
        BtnKhongGhiTSvaPT.Visible = An
        BtnThem4.Enabled = Not An
        BtnSua4.Enabled = Not An
        BtnXoa4.Enabled = Not An
        BtnThemSuaCVBP.Visible = Not An
        BtnXoaCVBP.Visible = Not An
        BtnChonCV_BP.Visible = An
        BtnGhiCV_BP.Visible = An
        BtnKhongGhiCV_BP.Visible = An
        BtnThemSuaTSGSTT_BP.Visible = Not An
        BtnXoaTSGSTT_BP.Visible = Not An
        BtnChonTSGSTT_BP.Visible = An
        BtnKhongGhiTSGSTT_BP.Visible = An
        BtnGhiTSGSTT_BP.Visible = An
        BtnGhiPT.Visible = An
        BtnKhongghiPT.Visible = An
        BtnThemSuaPT.Visible = Not An
        BtnXoa42.Visible = Not An
        BtnXoa43.Visible = Not An
        BtnThoat41.Visible = Not An
        btnThoat42.Visible = Not An
        btnThoat43.Visible = Not An
        btnThoat44.Visible = Not An

        For i As Integer = 0 To grvCTTB_CV.Columns.Count - 1
            If An Then
                grvCTTB_CV.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Else
                grvCTTB_CV.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
            End If
        Next


    End Sub

    Sub LockControlSub(ByVal khoa As Boolean)
        grdMay.Enabled = Not khoa
        tvwCTTBi.Enabled = Not khoa
        CboNLD.Enabled = Not khoa
        CboNhomthietbi.Enabled = Not khoa
        CboLoaithietbi.Enabled = Not khoa
        optHienTrang.Enabled = Not khoa
        cboLine.Enabled = Not khoa
        txtTimThietBi.Enabled = Not khoa
        txtMS_BO_PHAN.Properties.ReadOnly = khoa
        txtTEN_BO_PHAN.Enabled = Not khoa
        txtTEN_BO_PHAN.Properties.ReadOnly = khoa
        txtSO_LUONG.Properties.ReadOnly = khoa
        CboPT_BP.Enabled = Not khoa
        BtnTimPTCmb.Enabled = Not khoa

        cboClass.Enabled = Not khoa
        txtGHI_CHU.Properties.ReadOnly = khoa
        'If Not blnXoa_TS Then
        '    grdThongsoBP.AllowUserToAddRows = khoa
        'End If
        txtTimMay.Properties.ReadOnly = khoa
    End Sub


    Private Sub BtnKhongGhiTSvaPT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongGhiTSvaPT.Click
        blnThemSuaCauTrucSub = False
        HideButtonSub(False)
        LockControlSub(False)
        ObjectEnable(False)
        Call ShowTHONG_SO_BP()

        grvThongSoBP.OptionsBehavior.Editable = False
        grvThongSoBP.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        grvThongSoBP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
    End Sub

    Private Sub BtnGhiTSvaPT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhiTSvaPT.Click

        '2.1/ Xóa dữ liệu cũ trước vì xử lý trong lưới
        SqlText = "DELETE FROM THONG_SO_BO_PHAN WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        '2.2/ Lưu dữ liệu

        i = 0
        For i As Integer = 0 To grvThongSoBP.RowCount - 2
            Try
                Dim sTEN_THONG_SO As String = Me.grvThongSoBP.GetDataRow(i)("TEN_THONG_SO").ToString
                Dim sGIA_TRI As String = Me.grvThongSoBP.GetDataRow(i)("GIA_TRI_THONG_SO").ToString
                Dim nSTT As Integer = i + 1
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "sp_Insert_Thongsobophan", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), txtMS_BO_PHAN.Text, nSTT, sTEN_THONG_SO, sGIA_TRI)
            Catch ex As Exception

            End Try

        Next i

        blnThemSuaCauTrucSub = False
        Call ShowTHONG_SO_BP()

        HideButtonSub(False)
        LockControlSub(False)
        ObjectEnable(False)

        grvThongSoBP.OptionsBehavior.Editable = False
        grvThongSoBP.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        grvThongSoBP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

    End Sub

    Private Sub BtnXoaTSvaPT_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        HideButtonXoaTSvaPT(True)
        blnXoa_TS = True
        LockControlSub(True)

    End Sub

    Sub HideButtonXoaTSvaPT(ByVal an As Boolean)
        BtnThemSuaTSvaPT.Visible = Not an
        BtnXoa42.Visible = Not an
        BtnXoa43.Visible = Not an
        BtnXoa44.Visible = an
        BtnThem4.Enabled = Not an
        BtnSua4.Enabled = Not an
        BtnXoa4.Enabled = Not an
    End Sub

    Private Sub BtnThemSuaCVBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThemSuaCVBP.Click
        Try

            If txtMS_BO_PHAN.Text = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT26", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            blnThemSuaCauTrucSub = True
            FrmChonCongViecBoPhan.lstMsCV = New List(Of FrmChonCongViecBoPhan.CV_TMP)

            HideButtonSub(True)
            LockControlSub(True)
            grvCTTB_CV.OptionsBehavior.Editable = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnKhongGhiCV_BP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongGhiCV_BP.Click
        blnThemSuaCauTrucSub = False
        HideButtonSub(False)
        LockControlSub(False)
        ObjectEnable(False)
        ShowCongviecBoPhan()

    End Sub

    Sub ShowCongviecBoPhan()
        Dim dtTable As New DataTable
        Dim sSql As String = ""
        grdCTTB_CV.DataSource = Nothing
        Try
            If grdMay.DataSource Is Nothing Then Exit Sub
            If grvMay.RowCount = 0 Then Exit Sub
        Catch ex As Exception
        End Try

        Try
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_BO_PHAN", ucDMTBi.txtMS_MAY.Text, txtMS_BO_PHAN.Text, Commons.Modules.TypeLanguage))
            dtTable.Columns("MO_TA_CV").ReadOnly = True
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCTTB_CV, grvCTTB_CV, dtTable, False, False, False, False, True, "frmThongtinthietbi")

            If grvCTTB_CV.Columns("MS_MAY").Visible = False Then Exit Sub
            grvCTTB_CV.Columns("MS_MAY").Visible = False
            grvCTTB_CV.Columns("MS_BO_PHAN").Visible = False
            grvCTTB_CV.Columns("MS_CV").Visible = False
            grvCTTB_CV.Columns("PATH_HD").OptionsColumn.ReadOnly = True
            grvCTTB_CV.Columns("PATH_HD").OptionsColumn.AllowEdit = False
            grvCTTB_CV.Columns("MO_TA_CV").OptionsColumn.ReadOnly = True
            grvCTTB_CV.Columns("MO_TA_CV").OptionsColumn.AllowEdit = False
            grvCTTB_CV.Columns("MO_TA_CV").Width = 200


            Me.grvCTTB_CV.Columns("ACTIVE").Width = 70
            Me.grvCTTB_CV.Columns("TG_KH").Width = 100
            Me.grvCTTB_CV.Columns("GHI_CHU").Width = 200
            grvCTTB_CV.Columns("PATH_HD").Width = 200
            Me.grvCTTB_CV.Columns("TG_KH").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            Me.grvCTTB_CV.Columns("THAO_TAC").Visible = False
            Me.grvCTTB_CV.Columns("TIEU_CHUAN_KT").Visible = False
            Me.grvCTTB_CV.Columns("YEU_CAU_NS").Visible = False
            Me.grvCTTB_CV.Columns("YEU_CAU_DUNG_CU").Visible = False

        Catch ex As Exception
        End Try


        Try
            'Dim column As DevExpress.XtraGrid.Columns.GridColumn = grvCTTB_CV.Columns.AddField("Button")
            Dim btnCTiet As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            btnCTiet.TextEditStyle = TextEditStyles.HideTextEditor
            btnCTiet.Buttons(0).Kind = ButtonPredefines.Glyph
            btnCTiet.Buttons(0).Caption = "..."
            btnCTiet.Buttons(0).Image = Global.Commons.My.Resources.Resources.attachment
            grvCTTB_CV.Columns("CT_CVIEC").ColumnEdit = btnCTiet
            grvCTTB_CV.Columns("CT_CVIEC").Visible = True
            grvCTTB_CV.Columns("CT_CVIEC").Width = 50
            Try
                Try
                    RemoveHandler btnCTiet.ButtonClick, AddressOf Me.btnCTiet_ButtonClick
                Catch ex As Exception
                End Try
                Try
                    AddHandler btnCTiet.ButtonClick, AddressOf Me.btnCTiet_ButtonClick
                Catch ex As Exception
                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCTiet_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim frmCTiet As New VietShape.frmChiTietCongViec
        Dim sTaiLieu As String = ""
        Dim sTenCV As String = ""
        Dim sThaoTac As String = ""
        Dim sTieuChuan As String = ""
        Dim sYeuCauDC As String = ""
        Dim sYeuCauNS As String = ""
        Try
            Select Case Tab2Sub.SelectedTabPageIndex
                Case 1
                    sTaiLieu = grvCTTB_CV.GetFocusedDataRow("PATH_HD").ToString
                    sTenCV = grvCTTB_CV.GetFocusedDataRow("MO_TA_CV").ToString
                    sThaoTac = grvCTTB_CV.GetFocusedDataRow("THAO_TAC").ToString
                    sTieuChuan = grvCTTB_CV.GetFocusedDataRow("TIEU_CHUAN_KT").ToString
                    sYeuCauDC = grvCTTB_CV.GetFocusedDataRow("YEU_CAU_DUNG_CU").ToString
                    sYeuCauNS = grvCTTB_CV.GetFocusedDataRow("YEU_CAU_NS").ToString
                Case 2
                    sTaiLieu = grvCTTB_TS.GetFocusedDataRow("PATH_HD").ToString
                    sTenCV = grvCTTB_TS.GetFocusedDataRow("TEN_TS_GSTT").ToString
                    sThaoTac = grvCTTB_TS.GetFocusedDataRow("CACH_THUC_HIEN").ToString
                    sTieuChuan = grvCTTB_TS.GetFocusedDataRow("TIEU_CHUAN_KT").ToString
                    sYeuCauDC = grvCTTB_TS.GetFocusedDataRow("YEU_CAU_DUNG_CU").ToString
                    sYeuCauNS = grvCTTB_TS.GetFocusedDataRow("YEU_CAU_NS").ToString
                Case 3
                    sTaiLieu = grvThongsoGSTTDL.GetFocusedDataRow("PATH_HD").ToString
                    sTenCV = grvThongsoGSTTDL.GetFocusedDataRow("TEN_TS_GSTT").ToString
                    sThaoTac = grvThongsoGSTTDL.GetFocusedDataRow("CACH_THUC_HIEN").ToString
                    sTieuChuan = grvThongsoGSTTDL.GetFocusedDataRow("TIEU_CHUAN_KT").ToString
                    sYeuCauDC = grvThongsoGSTTDL.GetFocusedDataRow("YEU_CAU_DUNG_CU").ToString
                    sYeuCauNS = grvThongsoGSTTDL.GetFocusedDataRow("YEU_CAU_NS").ToString
            End Select

            frmCTiet.sTaiLieu = sTaiLieu
            frmCTiet.sTenCV = sTenCV
            frmCTiet.sThaoTac = sThaoTac
            frmCTiet.sTieuChuan = sTieuChuan
            frmCTiet.sYeuCauDC = sYeuCauDC
            frmCTiet.sYeuCauNS = sYeuCauNS
            If frmCTiet.ShowDialog = DialogResult.Cancel Then Exit Sub



            Select Case Tab2Sub.SelectedTabPageIndex
                Case 1
                    grvCTTB_CV.SetFocusedRowCellValue("PATH_HD", frmCTiet.sTaiLieu)
                    grvCTTB_CV.SetFocusedRowCellValue("THAO_TAC", frmCTiet.sThaoTac)
                    grvCTTB_CV.SetFocusedRowCellValue("TIEU_CHUAN_KT", frmCTiet.sTieuChuan)
                    grvCTTB_CV.SetFocusedRowCellValue("YEU_CAU_DUNG_CU", frmCTiet.sYeuCauDC)
                    grvCTTB_CV.SetFocusedRowCellValue("YEU_CAU_NS", frmCTiet.sYeuCauNS)
                Case 2
                    grvCTTB_TS.SetFocusedRowCellValue("PATH_HD", frmCTiet.sTaiLieu)
                    grvCTTB_TS.SetFocusedRowCellValue("CACH_THUC_HIEN", frmCTiet.sThaoTac)
                    grvCTTB_TS.SetFocusedRowCellValue("TIEU_CHUAN_KT", frmCTiet.sTieuChuan)
                    grvCTTB_TS.SetFocusedRowCellValue("YEU_CAU_DUNG_CU", frmCTiet.sYeuCauDC)
                    grvCTTB_TS.SetFocusedRowCellValue("YEU_CAU_NS", frmCTiet.sYeuCauNS)
                Case 3
                    grvThongsoGSTTDL.SetFocusedRowCellValue("PATH_HD", frmCTiet.sTaiLieu)
                    grvThongsoGSTTDL.SetFocusedRowCellValue("CACH_THUC_HIEN", frmCTiet.sThaoTac)
                    grvThongsoGSTTDL.SetFocusedRowCellValue("TIEU_CHUAN_KT", frmCTiet.sTieuChuan)
                    grvThongsoGSTTDL.SetFocusedRowCellValue("YEU_CAU_DUNG_CU", frmCTiet.sYeuCauDC)
                    grvThongsoGSTTDL.SetFocusedRowCellValue("YEU_CAU_NS", frmCTiet.sYeuCauNS)
            End Select
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub BtnChonCV_BP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonCV_BP.Click
        Try

            FrmChonCongViecBoPhan.SO_DONG = grvCTTB_CV.RowCount
            FrmChonCongViecBoPhan.MS_BO_PHAN = txtMS_BO_PHAN.Text.Trim
            FrmChonCongViecBoPhan.MS_LOAI_MAY = ucDMTBi.cboMS_LOAI_MAY.EditValue.ToString
            FrmChonCongViecBoPhan.MS_MAY = ucDMTBi.txtMS_MAY.Text.Trim
            If FrmChonCongViecBoPhan.ShowDialog() = DialogResult.OK Then
                Dim dtTableOne As New DataTable
                Dim dtRow As DataRow
                Try
                    dtTableOne = CType(grdCTTB_CV.DataSource, DataTable).Copy()
                    i = 0
                    While i < FrmChonCongViecBoPhan.dtTableTam.Rows.Count
                        dtRow = dtTableOne.NewRow
                        dtRow("MS_MAY") = ucDMTBi.txtMS_MAY.Text.Trim
                        dtRow("MS_BO_PHAN") = txtMS_BO_PHAN.Text.Trim
                        dtRow("MS_CV") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("MS_CV").ToString
                        dtRow("ACTIVE") = True
                        Try
                            dtRow("TG_KH") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("THOI_GIAN_DU_KIEN").ToString
                        Catch ex As Exception
                        End Try
                        SQL = "SELECT MO_TA_CV FROM CONG_VIEC WHERE MS_CV=" & FrmChonCongViecBoPhan.dtTableTam.Rows(i)("MS_CV").ToString
                        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
                        While dtReader.Read
                            dtRow("MO_TA_CV") = dtReader.Item(0)
                        End While

                        dtRow("THAO_TAC") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("THAO_TAC").ToString
                        dtRow("TIEU_CHUAN_KT") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("TIEU_CHUAN_KT").ToString
                        dtRow("YEU_CAU_NS") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("YEU_CAU_NS").ToString
                        dtRow("YEU_CAU_DUNG_CU") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("YEU_CAU_DUNG_CU").ToString
                        dtRow("GHI_CHU") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("GHI_CHU").ToString
                        dtRow("PATH_HD") = FrmChonCongViecBoPhan.dtTableTam.Rows(i)("PATH_HD").ToString
                        dtTableOne.Rows.Add(dtRow)

                        i = i + 1
                    End While
                    Dim j As Integer
                    For i = 0 To dtTableOne.Rows.Count - 2
                        For j = i + 1 To dtTableOne.Rows.Count - 1
                            If dtTableOne.Rows(i).Item(2) = dtTableOne.Rows(j).Item(2) Then
                                dtTableOne.Rows.RemoveAt(j)
                                Exit For
                            End If
                        Next
                        j = 0
                    Next
                    grdCTTB_CV.DataSource = dtTableOne
                    grvCTTB_CV.Columns(0).Visible = False
                    grvCTTB_CV.Columns(1).Visible = False
                    grvCTTB_CV.Columns(2).Visible = False
                Catch
                End Try

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnGhiCV_BP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhiCV_BP.Click
        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim tran As SqlTransaction = con.BeginTransaction()
        Dim sSql As String = ""
        Try
            SqlText = "DELETE FROM CAU_TRUC_THIET_BI_CONG_VIEC WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "'"
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SqlText)
            Dim BActive As Boolean

            For i As Integer = 0 To grvCTTB_CV.RowCount - 1
                Try
                    BActive = grvCTTB_CV.GetDataRow(i)("ACTIVE")
                Catch ex As Exception
                    BActive = False
                End Try
                Try
                    If Not BActive Then
                        SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_DELETE_CONG_VIEC_ACTIVE", ucDMTBi.txtMS_MAY.Text, grvCTTB_CV.GetDataRow(i)("MS_CV").ToString())
                    End If
                Catch ex As Exception
                End Try
                Dim s As Integer = 0
                Dim iTG As Integer = 0
                If BActive Then s = 1
                Try
                    iTG = Convert.ToInt32(grvCTTB_CV.GetDataRow(i)("TG_KH"))
                Catch ex As Exception

                End Try
                Dim sLuu As String = ""
                Try
                    If IO.File.Exists(grvCTTB_CV.GetDataRow(i)("PATH_HD").ToString()) Then
                        If Commons.Modules.ObjSystems.LayDuoiFile(grvCTTB_CV.GetDataRow(i)("PATH_HD").ToString()) = "." Then
                            sLuu = ""
                        Else
                            Dim strduongDanTmp As String = Commons.Modules.ObjSystems.CapnhatTL(True, "MAY-CV")
                            sLuu = (strduongDanTmp & Convert.ToString("\")) + ucDMTBi.txtMS_MAY.Text & "-" & txtMS_BO_PHAN.Text & "-" & grvCTTB_CV.GetDataRow(i)("MS_CV").ToString() & Commons.Modules.ObjSystems.LayDuoiFile(grvCTTB_CV.GetDataRow(i)("PATH_HD").ToString())
                            Commons.Modules.ObjSystems.LuuDuongDan(grvCTTB_CV.GetDataRow(i)("PATH_HD").ToString(), sLuu)
                        End If
                    End If

                Catch ex As Exception
                    sLuu = ""
                End Try

                sSql = " INSERT INTO [dbo].[CAU_TRUC_THIET_BI_CONG_VIEC] ([MS_MAY],[MS_BO_PHAN],[MS_CV],[GHI_CHU],[ACTIVE], TG_KH, THAO_TAC, TIEU_CHUAN_KT, YEU_CAU_NS, YEU_CAU_DUNG_CU, PATH_HD) VALUES (N'" & txtMS_MAY.Text & "', N'" & txtMS_BO_PHAN.Text & "'," & grvCTTB_CV.GetDataRow(i)("MS_CV").ToString() & ",N'" & grvCTTB_CV.GetDataRow(i)("GHI_CHU").ToString() & "', " & s & ", " & IIf(iTG = 0, "NULL", iTG) & ",N'" & grvCTTB_CV.GetDataRow(i)("THAO_TAC").ToString() & "',N'" & grvCTTB_CV.GetDataRow(i)("TIEU_CHUAN_KT").ToString() & "',N'" & grvCTTB_CV.GetDataRow(i)("YEU_CAU_NS").ToString() & "',N'" & grvCTTB_CV.GetDataRow(i)("YEU_CAU_DUNG_CU").ToString() & "',N'" & sLuu & "')"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
            Next i
            blnThemSuaCauTrucSub = False
            HideButtonSub(False)
            LockControlSub(False)
            ObjectEnable(False)
            tran.Commit()
            con.Close()
            ShowCongviecBoPhan()
        Catch ex As Exception
            tran.Rollback()
            con.Close()
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnXoaCVBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoaCVBP.Click
        If grvCTTB_CV.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT39", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSGQUYENKT58", Commons.Modules.TypeLanguage)
        Dim tmp As Integer = intTab12
        Dim strThongBao As String = ""
        Kiem_tra_CauTrucThietBi_CV(tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString(), grvCTTB_CV.GetFocusedDataRow()("MS_CV"), strThongBao)
        If strThongBao.Trim <> "" Then
            XtraMessageBox.Show(strThongBao, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim tran As SqlTransaction = con.BeginTransaction()
            Try
                SqlText = "DELETE FROM CAU_TRUC_THIET_BI_CONG_VIEC WHERE MS_MAY=N'" & txtMS_MAY.Text & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "' AND MS_CV=" & grvCTTB_CV.GetFocusedDataRow()("MS_CV")
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SqlText)
                tran.Commit()
            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XoaKhongThanhCong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                tran.Rollback()
            End Try

            ShowCongviecBoPhan()
        End If

        Try
            If grvCTTB_CV.RowCount > 0 Then
                If grvCTTB_CV.RowCount = tmp Then
                    grvCTTB_CV.FocusedRowHandle = tmp - 1
                Else
                    grvCTTB_CV.FocusedRowHandle = tmp
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function Kiem_tra_CauTrucThietBi_CV(ByVal MS_BO_PHAN As String, ByVal MS_CV As String, Optional ByRef strThongBao As String = "") As Boolean
        Dim bKHTT As Boolean = False, bPBT As Boolean = False, bBTPN As Boolean = False
        Dim strTam As String = "", sBTPN As String = "", sPBT As String = "", sKHTT As String = ""
        Dim dtReader As SqlDataReader
        Dim sSql As String = ""

        strThongBao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CONG_VIEC_DANG_DUOC_SU_DUNG", Commons.Modules.TypeLanguage).ToString.Trim
        sSql = "SELECT ISNULL(COUNT(*),0) AS TONG FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_CV=" & grvCTTB_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & MS_BO_PHAN & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bBTPN = True
                sBTPN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_BTPN", Commons.Modules.TypeLanguage)
                Exit While
            End If
        End While
        dtReader.Close()

        sSql = "SELECT ISNULL(COUNT(*),0) AS TONG FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' )"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bPBT = True
                sPBT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)
            End If
            Exit While
        End While
        dtReader.Close()

        sSql = "SELECT ISNULL(COUNT(*),0) AS TONG FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bKHTT = True
                sKHTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)
                Exit While
            End If
        End While
        dtReader.Close()

        strTam = IIf(sBTPN.Trim = "", "", sBTPN & ", ") & IIf(sKHTT.Trim = "", "", sKHTT & ", ") & IIf(sPBT.Trim = "", "", sPBT)

        If bBTPN = True Or bKHTT = True Or bPBT = True Then
            strThongBao += " " & strTam + vbCrLf & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_XOA_DUOC_CV", Commons.Modules.TypeLanguage)
            Return True
        Else
            strThongBao = ""
            Return False
        End If
    End Function

    Private Function Kiem_tra_CauTrucThietBi_VTPT(ByVal MS_PT As String, Optional ByRef strThongBao As String = "") As Boolean
        Dim bKHTT As Boolean = False, bPBT As Boolean = False, bBTPN As Boolean = False
        Dim strTam As String = "", sBTPN As String = "", sKHTT As String = "", sPBT As String = ""
        Dim dtReader As SqlDataReader

        strThongBao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "VAT_TU_DANG_DUOC_SU_DUNG", Commons.Modules.TypeLanguage).ToString.Trim

        SQL = "SELECT ISNULL(COUNT(*),0) AS TONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_PT= N'" & MS_PT & "' AND MS_BO_PHAN= N'" & tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString() & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bBTPN = True
                sBTPN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_BTPN", Commons.Modules.TypeLanguage)
                Exit While
            End If
        End While
        dtReader.Close()

        SQL = "SELECT ISNULL(COUNT(*),0) AS TONG FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_PT= N'" & MS_PT & "' AND MS_BO_PHAN= N'" & tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString() & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bKHTT = True
                sKHTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)
                Exit While
            End If
        End While
        dtReader.Close()

        SQL = "SELECT ISNULL(COUNT(*),0) AS TONG FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PT= N'" & MS_PT & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_BO_PHAN= N'" & tvwCTTBi.FocusedNode("MS_BO_PHAN").ToString() & "')"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bPBT = True
                sPBT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)
                Exit While
            End If
        End While
        dtReader.Close()

        strTam = IIf(sBTPN.Trim = "", "", sBTPN & ", ") & IIf(sKHTT.Trim = "", "", sKHTT & ", ") & IIf(sPBT.Trim = "", "", sPBT)

        If bKHTT = True Or bPBT = True Or bBTPN = True Then
            strThongBao += " " & strTam + vbCrLf & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_XOA_DUOC_PT", Commons.Modules.TypeLanguage)
            Return True
        Else
            strThongBao = ""
            Return False
        End If
    End Function

    Private Sub BtnThemSuaTSGSTT_BP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThemSuaTSGSTT_BP.Click
        If txtMS_BO_PHAN.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT26", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        blnThemSuaCauTrucSub = True

        HideButtonSub(True)
        LockControlSub(True)
        rowCount = grvCTTB_TS.RowCount

        grvCTTB_TS.OptionsBehavior.Editable = True
        Try
            grvCTTB_TS.Columns("TEN_TS_GSTT").OptionsColumn.ReadOnly = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnKhongGhiTSGSTT_BP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongGhiTSGSTT_BP.Click
        blnThemSuaCauTrucSub = False
        HideButtonSub(False)
        LockControlSub(False)
        ObjectEnable(False)
        ShowTSGSTTBoPhan()

        grvCTTB_TS.OptionsBehavior.Editable = False
    End Sub

    Sub ShowTSGSTTBoPhan()
        Dim dtTable As New DataTable

        Try
            grdCTTB_TS.DataSource = Nothing
            If grdMay.DataSource Is Nothing Then Exit Sub
            If grvMay.RowCount = 0 Then Exit Sub
        Catch ex As Exception

        End Try

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_CAU_TRUC_THIET_BI_TS_GSTT_1", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), txtMS_BO_PHAN.Text, Commons.Modules.TypeLanguage))
        Try

            dtTable.Columns("THOI_GIAN").ReadOnly = False
            dtTable.Columns("CACH_THUC_HIEN").ReadOnly = False
            dtTable.Columns("THOI_GIAN").AllowDBNull = True
            dtTable.Columns("CACH_THUC_HIEN").AllowDBNull = True

            dtTable.Columns("MS_UU_TIEN").ReadOnly = False
            dtTable.Columns("MS_UU_TIEN").AllowDBNull = True
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdCTTB_TS, grvCTTB_TS, dtTable, False, False, False, True, True, "frmThongtinthietbi")

        Try
            Dim cbo As Repository.RepositoryItemLookUpEdit = New RepositoryItemLookUpEdit()
            cbo.Name = "MS_DV_TG"
            cbo.ValueMember = "MS_DV_TG"
            cbo.DisplayMember = "TEN_DV_TG"
            cbo.NullText = ""
            cbo.DataSource = New MAYController().GetDON_VI_THOI_GIANs
            cbo.PopulateColumns()
            cbo.Columns("TEN_DV_TG").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DV_TG", Commons.Modules.TypeLanguage)
            cbo.Columns("MS_DV_TG").Visible = False
            grvCTTB_TS.Columns("MS_DV_TG").ColumnEdit = cbo


            Dim str As String = " SELECT MS_UU_TIEN, " + If(Commons.Modules.TypeLanguage = 0, " TEN_UU_TIEN ", " TEN_TA ") & " AS TEN_UU_TIEN FROM MUC_UU_TIEN"
            dt = New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

            Dim cboMucUT As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            cboMucUT.Name = "cboMucUT"
            cboMucUT.ValueMember = "MS_UU_TIEN"
            cboMucUT.DisplayMember = "TEN_UU_TIEN"
            cboMucUT.DataSource = dt
            cboMucUT.PopulateColumns()
            cboMucUT.Columns("MS_UU_TIEN").Visible = False
            cboMucUT.NullText = ""
            grvCTTB_TS.Columns("MS_UU_TIEN").ColumnEdit = cboMucUT


            grvCTTB_TS.Columns("MS_MAY").Visible = False
            grvCTTB_TS.Columns("MS_BO_PHAN").Visible = False
            grvCTTB_TS.Columns("MS_TS_GSTT").Visible = False
            grvCTTB_TS.Columns("MS_TT").Visible = False
            grvCTTB_TS.Columns("TEN_GT").Visible = False
            grvCTTB_TS.Columns("DAT").Visible = False


            Me.grvCTTB_TS.Columns("CHU_KY_DO").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            grvCTTB_TS.Columns("TEN_TS_GSTT").OptionsColumn.ReadOnly = True






            Try
                grvCTTB_TS.Columns("TEN_TS_GSTT").Width = 300
                grvCTTB_TS.Columns("CHU_KY_DO").Width = 100
                grvCTTB_TS.Columns("GHI_CHU").Width = 200
                grvCTTB_TS.Columns("CT_CVIEC").Width = 50
                grvCTTB_TS.Columns("MS_DV_TG").Width = 60


                grvCTTB_TS.Columns("CACH_THUC_HIEN").Visible = False
                grvCTTB_TS.Columns("TIEU_CHUAN_KT").Visible = False
                grvCTTB_TS.Columns("YEU_CAU_NS").Visible = False
                grvCTTB_TS.Columns("YEU_CAU_DUNG_CU").Visible = False
                grvCTTB_TS.Columns("PATH_HD").Visible = False

                grvCTTB_TS.Columns("TEN_TS_GSTT").OptionsColumn.ReadOnly = True
            Catch ex As Exception
            End Try


            Try
                'Dim column As DevExpress.XtraGrid.Columns.GridColumn = grvCTTB_CV.Columns.AddField("Button")
                Dim btnCTiet As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
                btnCTiet.TextEditStyle = TextEditStyles.HideTextEditor
                btnCTiet.Buttons(0).Kind = ButtonPredefines.Glyph
                btnCTiet.Buttons(0).Caption = "..."
                btnCTiet.Buttons(0).Image = Global.Commons.My.Resources.Resources.attachment
                grvCTTB_TS.Columns("CT_CVIEC").ColumnEdit = btnCTiet
                grvCTTB_TS.Columns("CT_CVIEC").Visible = True
                'grvCTTB_CV.Columns("CT_CVIEC").Caption = "..."
                'grvCTTB_CV.Columns.Add(column)
                Try
                    Try
                        RemoveHandler btnCTiet.ButtonClick, AddressOf Me.btnCTiet_ButtonClick
                    Catch ex As Exception
                    End Try
                    Try
                        AddHandler btnCTiet.ButtonClick, AddressOf Me.btnCTiet_ButtonClick
                    Catch ex As Exception
                    End Try
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnChonTSGSTT_BP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTSGSTT_BP.Click
        Try

            Dim dtNew As New DataTable
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim flag As Boolean = True
            dtNew.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_CAU_TRUC_THIET_BI_TS_GSTT", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), txtMS_BO_PHAN.Text, Commons.Modules.TypeLanguage, 1))

            Dim fPT As New frmChonthongsoGSTT_BP()
            fPT.MS_MAY = txtMS_MAY.Text
            fPT.MS_BO_PHAN = txtMS_BO_PHAN.Text
            fPT.LOAI_TS = True
            fPT.ATTACHMENT = False
            fPT.DtThongso = CType(grdCTTB_TS.DataSource, DataTable)
            fPT.Size = New Size(900, 600)

            If fPT.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    Dim dt As DataTable = fPT.dtChonTS
                    If (dt.Rows.Count = 0) Then Exit Sub
                    '
                    dtNew = New DataTable

                    dtNew.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_CAU_TRUC_THIET_BI_TS_GSTT", txtMS_MAY.Text, txtMS_BO_PHAN.Text, Commons.Modules.TypeLanguage, 1))
                    dtNew.Columns("CACH_THUC_HIEN").AllowDBNull = True
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows(i)("CHON").Equals(True) Then
                            Dim drNew As DataRow = dtNew.NewRow
                            drNew("MS_MAY") = txtMS_MAY.Text
                            drNew("MS_BO_PHAN") = txtMS_BO_PHAN.Text
                            drNew("MS_TS_GSTT") = dt.Rows(i)("MS_TS_GSTT")
                            drNew("CHU_KY_DO") = 0
                            drNew("MS_UU_TIEN") = 2
                            drNew("MS_TT") = 0
                            drNew("TEN_GT") = DBNull.Value
                            drNew("TEN_TS_GSTT") = dt.Rows(i)("TEN_TS_GSTT")
                            drNew("ACTIVE") = True
                            drNew.Item("THOI_GIAN") = dt.Rows(i)("THOI_GIAN")
                            drNew.Item("CACH_THUC_HIEN") = dt.Rows(i)("CACH_THUC_HIEN")
                            drNew.Item("TIEU_CHUAN_KT") = dt.Rows(i)("TIEU_CHUAN_KT")
                            drNew.Item("YEU_CAU_NS") = dt.Rows(i)("YEU_CAU_NS")
                            drNew.Item("YEU_CAU_DUNG_CU") = dt.Rows(i)("YEU_CAU_DUNG_CU")
                            drNew.Item("PATH_HD") = dt.Rows(i)("DUONG_DAN")
                            dtNew.Rows.Add(drNew)
                        End If
                    Next
                    dtNew.Columns("MS_UU_TIEN").ReadOnly = False
                    dtNew.Columns("THOI_GIAN").ReadOnly = False
                    dtNew.Columns("CACH_THUC_HIEN").ReadOnly = False
                    grdCTTB_TS.DataSource = dtNew
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString())

        End Try

    End Sub

    Private Sub BtnGhiTSGSTT_BP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhiTSGSTT_BP.Click
        Dim i As Integer
        Try
            For i = 0 To grvCTTB_TS.RowCount - 1
                If IsDBNull(grvCTTB_TS.GetDataRow(i)("CHU_KY_DO").ToString()) Or grvCTTB_TS.GetDataRow(i)("CHU_KY_DO").ToString() = "0" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT47", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    grvCTTB_TS.FocusedRowHandle = i
                    grvCTTB_TS.FocusedColumn = grvCTTB_TS.Columns("CHU_KY_DO")
                    Exit Sub
                ElseIf grvCTTB_TS.GetDataRow(i)("CHU_KY_DO").ToString() > 0 And IsDBNull(grvCTTB_TS.GetDataRow(i)("MS_DV_TG").ToString()) = False Then
                Else
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgktdl", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Next i
            For i = 0 To grvCTTB_TS.RowCount - 1

                Dim sLuu As String = ""
                Try
                    If IO.File.Exists(grvCTTB_TS.GetDataRow(i)("PATH_HD").ToString()) Then
                        If Commons.Modules.ObjSystems.LayDuoiFile(grvCTTB_TS.GetDataRow(i)("PATH_HD").ToString()) = "." Then
                            sLuu = ""
                        Else
                            Dim strduongDanTmp As String = Commons.Modules.ObjSystems.CapnhatTL(True, "MAY-GSDT")
                            sLuu = (strduongDanTmp & Convert.ToString("\")) + txtMS_MAY.Text & "-" & txtMS_BO_PHAN.Text & "-" & grvCTTB_TS.GetDataRow(i)("MS_DV_TG").ToString() & Commons.Modules.ObjSystems.LayDuoiFile(grvCTTB_TS.GetDataRow(i)("PATH_HD").ToString())

                            Commons.Modules.ObjSystems.LuuDuongDan(grvCTTB_TS.GetDataRow(i)("PATH_HD").ToString(), sLuu)
                        End If
                    End If

                Catch ex As Exception
                    sLuu = ""
                End Try
                Dim Smsut As String
                If grvCTTB_TS.GetDataRow(i)("MS_UU_TIEN").ToString() = "" Then
                    Smsut = "2"
                Else
                    Smsut = grvCTTB_TS.GetDataRow(i)("MS_UU_TIEN").ToString()
                End If
                If (grvCTTB_TS.GetDataRow(i).RowState = DataRowState.Added) Then
                    Dim re As Integer = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddCAU_TRUC_THIET_BI_TS_GSTT", txtMS_MAY.Text, txtMS_BO_PHAN.Text, grvCTTB_TS.GetDataRow(i)("MS_TS_GSTT").ToString(), 1, DBNull.Value, DBNull.Value, DBNull.Value, grvCTTB_TS.GetDataRow(i)("CHU_KY_DO").ToString(), grvCTTB_TS.GetDataRow(i)("MS_DV_TG").ToString(), 1, 0, Smsut, grvCTTB_TS.GetDataRow(i)("GHI_CHU").ToString(), grvCTTB_TS.GetDataRow(i)("ACTIVE").ToString(), grvCTTB_TS.GetDataRow(i)("THOI_GIAN").ToString(), grvCTTB_TS.GetDataRow(i)("CACH_THUC_HIEN").ToString(), grvCTTB_TS.GetDataRow(i)("TIEU_CHUAN_KT").ToString(), grvCTTB_TS.GetDataRow(i)("YEU_CAU_NS").ToString(), grvCTTB_TS.GetDataRow(i)("YEU_CAU_DUNG_CU").ToString(), IIf(String.IsNullOrEmpty(sLuu), Nothing, sLuu))
                Else
                    Dim s As String = grvCTTB_TS.GetDataRow(i)("MS_DV_TG").ToString()
                    Dim re As Integer = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateCAU_TRUC_THIET_BI_TS_GSTT", txtMS_MAY.Text, txtMS_BO_PHAN.Text, grvCTTB_TS.GetDataRow(i)("MS_TS_GSTT").ToString(), 1, DBNull.Value, DBNull.Value, DBNull.Value, grvCTTB_TS.GetDataRow(i)("CHU_KY_DO").ToString(), grvCTTB_TS.GetDataRow(i)("MS_DV_TG").ToString(), 0, Smsut, grvCTTB_TS.GetDataRow(i)("GHI_CHU").ToString(), grvCTTB_TS.GetDataRow(i)("ACTIVE").ToString(), grvCTTB_TS.GetDataRow(i)("THOI_GIAN").ToString(), grvCTTB_TS.GetDataRow(i)("CACH_THUC_HIEN").ToString(), grvCTTB_TS.GetDataRow(i)("TIEU_CHUAN_KT").ToString(), grvCTTB_TS.GetDataRow(i)("YEU_CAU_NS").ToString(), grvCTTB_TS.GetDataRow(i)("YEU_CAU_DUNG_CU").ToString(), IIf(String.IsNullOrEmpty(sLuu), Nothing, sLuu))
                End If
            Next i
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString, Me.Text)
            Exit Sub
        End Try

        blnThemSuaCauTrucSub = False
        HideButtonSub(False)
        LockControlSub(False)
        ObjectEnable(False)
        ShowTSGSTTBoPhan()
        grvCTTB_TS.OptionsBehavior.Editable = False
    End Sub

    Private Sub BtnXoaTSGSTT_BP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaTSGSTT_BP.Click
        If grvCTTB_TS.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT39", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT50", Commons.Modules.TypeLanguage)
        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        Dim sSql As String = ""
        sSql = "SELECT * FROM GIAM_SAT_TINH_TRANG_TS WHERE MS_MAY=N'" & txtMS_MAY.Text & "' AND MS_BO_PHAN = '" & txtMS_BO_PHAN.Text & "' AND MS_TS_GSTT = '" & grvCTTB_TS.GetFocusedDataRow()("MS_TS_GSTT").ToString() & "'"
        Dim dtreader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

        While dtreader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_xoa_TSGSTT_BP", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtreader.Close()
            Exit Sub
        End While
        dtreader.Close()
        Dim tmp As Integer = intTab13
        sSql = "DELETE FROM CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY=N'" & txtMS_MAY.Text & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "' AND MS_TS_GSTT='" & grvCTTB_TS.GetFocusedDataRow()("MS_TS_GSTT").ToString() & "' AND MS_TT='" & grvCTTB_TS.GetFocusedDataRow()("MS_TT").ToString() & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        ShowTSGSTTBoPhan()
        Try
            If grvCTTB_TS.RowCount > 0 Then
                If grvCTTB_TS.RowCount = tmp Then
                    grvCTTB_TS.FocusedRowHandle() = tmp - 1
                Else
                    grvCTTB_TS.FocusedRowHandle() = tmp
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub




#End Region

#Region "history"
    Sub ClearHistory()
        Try
            tlHistory.DataSource = Nothing
            grdLichSuMay.DataSource = Nothing
            grdLichSuPTTThe.DataSource = Nothing
            txtMayTT.Text = ""
            txtBoPhanTT.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    '


    'Tạo table chưa bộ phận 
    Sub TaoTable(ByVal MS_MAY As String, ByVal MS_BO_PHAN As String)
        Dim str As String = ""
        Dim tmp As New DataTable()
        str = "SELECT MS_BO_PHAN FROM CAU_TRUC_THIET_BI WHERE  MS_MAY=N'" & MS_MAY & "' AND MS_BO_PHAN_CHA=N'" & MS_BO_PHAN & "'"
        tmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tmp.Rows.Count - 1
            str = "insert into dbo.BO_PHAN" & Commons.Modules.UserName & " VALUES(N'" & tmp.Rows(i).Item("MS_BO_PHAN") & "')"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            TaoTable(MS_MAY, tmp.Rows(i).Item("MS_BO_PHAN"))
        Next
    End Sub
    Sub RefreshHistory()
        Try
            With grvLichSuMay
                .Columns("NGAY_HOAN_THANH").Width = 130
                .Columns("MS_PHIEU_BAO_TRI").Width = 120
                .Columns("TT_SAU_BT").Width = 150
                .Columns("MO_TA_CV").Width = 80
                .Columns("MAY_TH").Width = 100
                .Columns("TEN_BP_TH").Width = 200
                .Columns("TEN_LOAI_BT").Width = 120
                .Columns("MO_TA_CV").Width = 200
                .Columns("GHI_CHU").Width = 150
            End With
        Catch ex As Exception

        End Try

    End Sub
    Sub RefreshHistoryPTThayThe()
        Try
            With grvLichSuPTTThe
                .Columns("VICT_NHA_THAU").Width = 100
                .Columns("NGUOI_THAY_THE").Width = 150
                .Columns("NGAY_THAY_THE").Width = 100
                .Columns("MS_PT").Width = 100
                .Columns("MS_VI_TRI_PT").Width = 80
                .Columns("SL_TT").Width = 80
                .Columns("MS_VI_TRI_PT").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("SL_TT").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("GHI_CHU").MinWidth = 150
            End With
        Catch ex As Exception

        End Try
        Try
            grvLichSuPTTThe.Columns("ID").Visible = False
        Catch ex As Exception
        End Try

    End Sub
    Sub ShowTreeRoot1(ByVal tvHistory As TreeList, ByVal sMS_MAY As String)
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If sMS_MAY.Trim().Length <= 0 Then
            Return
        End If

        tvHistory.DataSource = Nothing
        Dim sSql As String
        sSql = "SELECT DISTINCT MS_MAY, MS_BO_PHAN,(MS_BO_PHAN + ' - ' +  TEN_BO_PHAN) AS TEN_BO_PHAN, MS_PT, SO_LUONG, MS_BO_PHAN_CHA, GHI_CHU, RUN_TIME, MS_DVT_RT, HINH, CLASS_ID, ISNULL(STT, 999) As STT FROM dbo.CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & sMS_MAY & "' UNION SELECT DISTINCT N'" & sMS_MAY & "'  AS MS_MAY, N'" & sMS_MAY & "' AS  MS_BO_PHAN, N'" & sMS_MAY & "' AS TEN_BO_PHAN, NULL AS MS_PT, NULL AS SO_LUONG, NULL AS MS_BO_PHAN_CHA, NULL AS GHI_CHU, NULL AS RUN_TIME, NULL AS MS_DVT_RT, NULL AS HINH, NULL AS CLASS_ID, -1 As STT ORDER BY STT "
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

        tvHistory.BeginUpdate()
        tvHistory.KeyFieldName = "MS_BO_PHAN"
        tvHistory.ParentFieldName = "MS_BO_PHAN_CHA"
        tvHistory.OptionsBehavior.Editable = False
        tvHistory.DataSource = dtTmp

        For i = 0 To tvHistory.Columns.Count - 1
            tvHistory.Columns(i).Visible = False
            dtTmp.Columns(i).AllowDBNull = True
        Next
        tvHistory.Columns("TEN_BO_PHAN").Visible = True
        tvHistory.Columns("TEN_BO_PHAN").BestFit()
        tvHistory.Columns("TEN_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        tvHistory.ExpandAll()
        tvHistory.EndUpdate()
        tvHistory.Columns("TEN_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpDanhsachcautruc", Commons.Modules.TypeLanguage)
        tvHistory.Columns("TEN_BO_PHAN").BestFit()

        If tvHistory.AllNodesCount <= 0 Then
            If Tabthietbi.SelectedTabPageIndex = 5 Then
                tlHistory_FocusedNodeChanged(Nothing, Nothing)
            ElseIf Tabthietbi.SelectedTabPageIndex = 6 Then
                tlClass_FocusedNodeChanged(Nothing, Nothing)
            End If
        End If

    End Sub

    Sub ShowTreeNode1(ByVal SMS_MAY As String, ByVal sMS_BP As String, ByVal oNode As TreeNode)
        If sMS_BP.Trim().Length <= 0 Then
            Return
        End If

        Dim SqlTextNode As String = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN_CHA=N'" & sMS_BP & "' AND MS_MAY=N'" & SMS_MAY & "'"

        Dim dtNode As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlTextNode).Tables(0)
        If dtNode.Rows.Count <= 0 Then
            Return
        End If
        For Each drNode As DataRow In dtNode.Rows
            Dim sMaBP As String = drNode("MS_BO_PHAN").ToString()
            Dim sTenBP As String = drNode("MS_BO_PHAN").ToString() + " - " + drNode("TEN_BO_PHAN").ToString()
            Dim oChildNode As TreeNode = New TreeNode(sMaBP)
            oChildNode = oNode.Nodes.Add(sMaBP, sTenBP)
            Call ShowTreeNode1(SMS_MAY, sMaBP, oChildNode)

        Next
    End Sub
#End Region

#Region "he chuyen gian"
    Sub ClearHeChuyenGia()
        Try
            tlClass.DataSource = Nothing
            grdHuHong.DataSource = Nothing
            grdNguyenNhan.DataSource = Nothing
            grdPP.DataSource = Nothing

        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub BtnThemSuaPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThemSuaPT.Click
        If txtMS_BO_PHAN.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT26", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        blnThemSuaCauTrucSub = True
        HideButtonSub(True)
        LockControlSub(True)

        Try
            grvCTTB_PT.Columns("SL_TON").OptionsColumn.ReadOnly = True

        Catch ex As Exception
        End Try

        grvCTTB_PT.OptionsBehavior.Editable = True
        Try

            grvCTTB_PT.Columns("MS_VI_TRI_PT").OptionsColumn.ReadOnly = False
            grvCTTB_PT.Columns("SO_LUONG").OptionsColumn.ReadOnly = False
            grvCTTB_PT.Columns("TUOI_THO").OptionsColumn.ReadOnly = False
            grvCTTB_PT.Columns("ACTIVE").OptionsColumn.ReadOnly = False
            grvCTTB_PT.Columns("CHUC_NANG").OptionsColumn.ReadOnly = False
        Catch ex As Exception
        End Try


    End Sub

    Private Sub BtnGhiPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhiPT.Click

        Dim Co As Integer = -1
        Dim vtbTam As New DataTable
        i = 0
        If grvCTTB_PT.RowCount > 0 Then
            While i < Me.grvCTTB_PT.RowCount
                If IsDBNull(Me.grvCTTB_PT.GetDataRow(i)("MS_VI_TRI_PT")) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT35", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    grvCTTB_PT.GetDataRow(i)("MS_VI_TRI_PT").Selected = True
                    Exit Sub
                End If
                i = i + 1
            End While
        End If
        Dim dtmp As DataTable = CType(grdCTTB_PT.DataSource, DataTable).Copy()
        Try
            Dim ckDuplicate = dtmp.Select().AsEnumerable().GroupBy(Function(x) New With {Key .MS_PT = x("MS_PT").ToString(), Key .MS_VI_TRI_PT = x("MS_VI_TRI_PT").ToString()}).Where(Function(x) x.Count() > 1).Select(Function(x) New With {Key .MS_PT = x.First()("MS_PT"), Key .MS_VI_TRI_PT = x.First()("MS_VI_TRI_PT")})
            If (ckDuplicate.Count() > 0) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenkt56", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvCTTB_PT.Columns("MS_PT").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim tran As SqlTransaction = con.BeginTransaction()
        Try
            i = 0
            If grvCTTB_PT.RowCount > 0 Then
                While i < Me.grvCTTB_PT.RowCount
                    SQL = "SELECT MS_PT  FROM IC_PHU_TUNG_LOAI_MAY WHERE MS_LOAI_MAY =N'" & ucDMTBi.cboMS_LOAI_MAY.EditValue & "' and MS_PT=N'" & Me.grvCTTB_PT.GetDataRow(i)("MS_PT") & "'"
                    vtbTam = New DataTable
                    vtbTam.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, SQL))
                    If vtbTam.Rows.Count <= 0 Then
                        If Co = -1 Then
                            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Motsophutungchuatontai,Bancomuoncapnhattudongkhong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                                Co = 1
                            Else
                                Co = 2
                            End If
                        End If
                        If Co = 1 Then
                            SQL = "insert into IC_PHU_TUNG_LOAI_MAY (MS_PT,MS_LOAI_MAY) " &
                                 " values( N'" & grvCTTB_PT.GetDataRow(i)("MS_PT") & "' ,N'" & ucDMTBi.cboMS_LOAI_MAY.EditValue & "' )"
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SQL)
                        Else
                            grvCTTB_PT.FocusedRowHandle = i
                            tran.Commit()
                            con.Close()
                            Exit Sub
                        End If
                    End If
                    i = i + 1
                End While
            End If

            SqlText = "DELETE FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "'"
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SqlText)

            For i As Integer = 0 To grvCTTB_PT.RowCount - 1
                Dim sMS_PT As String = Me.grvCTTB_PT.GetDataRow(i)("MS_PT")
                Dim _chuc_nang As String = Convert.ToString(Me.grvCTTB_PT.GetDataRow(i)("CHUC_NANG"))
                Dim sMS_VI_TRI_PT As String = Me.grvCTTB_PT.GetDataRow(i)("MS_VI_TRI_PT")
                Dim sSO_LUONG As String = Me.grvCTTB_PT.GetDataRow(i)("SO_LUONG")
                Dim iTuoiTho As Int32
                Try
                    iTuoiTho = Me.grvCTTB_PT.GetDataRow(i)("TUOI_THO")
                Catch ex As Exception
                    iTuoiTho = 0
                End Try
                Dim active As Boolean = False
                Try
                    active = Me.grvCTTB_PT.GetDataRow(i)("ACTIVE")
                Catch
                End Try
                Dim dtTmp = New DataTable
                dtTmp = CType(grdCTTB_PT.DataSource, DataTable).Copy
                dtTmp.DefaultView.RowFilter = " MS_PT = '" + sMS_PT + "' AND ACTIVE = 1 "
                dtTmp = dtTmp.DefaultView.ToTable()

                'If active = False Then
                If dtTmp.Rows.Count = 0 Then
                    SqlText = "DELETE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY='" & txtMS_MAY.Text & "' AND MS_PT='" & grvCTTB_PT.GetDataRow(i)("MS_PT") & "'  AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "'  "
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SqlText)
                End If
                SqlHelper.ExecuteNonQuery(tran, "sp_Insert_Cautructhietbi_phutung", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), txtMS_BO_PHAN.Text, sMS_PT, sMS_VI_TRI_PT, sSO_LUONG, iTuoiTho, _chuc_nang, active)
            Next i

            Try
                SqlText = "UPDATE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG SET SO_LUONG = CASE  WHEN SO_LUONG > SL_CTTB THEN SL_CTTB ELSE SO_LUONG END FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG T1 
                            INNER JOIN(SELECT MS_PT,SUM(SO_LUONG) AS SL_CTTB FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "' AND ACTIVE = 1
                            GROUP BY MS_PT) T2 ON T1.MS_PT = T2.MS_PT WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "' "
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SqlText)
            Catch ex As Exception
            End Try

            Try
                Dim dt As New DataTable
                Dim sBt As String
                sBt = "CTTBTMP" & Commons.Modules.UserName

                dt = CType(grdCTTB_PT.DataSource, DataTable)
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBt, dt, "")
                SqlText = " UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET SET MS_VI_TRI_PT = T2.MS_VI_TRI_PT " &
                                " FROM         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET AS B INNER JOIN " &
                                " dbo.PHIEU_BAO_TRI AS A ON B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI INNER JOIN " &
                                " (SELECT     MS_PT, REPLACE(PTVT, MS_PT, '') AS MS_VTRI_OLD, MS_VI_TRI_PT " &
                                " FROM         " + sBt + ") AS T2 ON T2.MS_PT = B.MS_PT AND T2.MS_VTRI_OLD = B.MS_VI_TRI_PT " &
                                " WHERE     (A.MS_MAY = N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "') " &
                                " AND (B.MS_BO_PHAN = N'" & txtMS_BO_PHAN.Text & "')"

                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, SqlText)
            Catch ex As Exception

            End Try

            tran.Commit()
            con.Close()

            blnThemSuaCauTrucSub = False
            Call ShowTHONG_TIN_PT()
            FormatGridPT()
            HideButtonSub(False)
            LockControlSub(False)
            ObjectEnable(False)


            'RemoveHandler grdThongtinPT.CellValidating, AddressOf Me.grdThongtinPT_CellValidating
            'grdThongtinPT.ReadOnly = True
        Catch ex As Exception
            tran.Rollback()
            con.Close()
        End Try
        tvwCTTBi.Enabled = True
    End Sub



    Private Sub BtnKhongghiPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghiPT.Click

        blnThemSuaCauTrucSub = False
        HideButtonSub(False)
        LockControlSub(False)
        ObjectEnable(False)

        Call ShowTHONG_TIN_PT()
        FormatGridPT()

        grvCTTB_PT.OptionsBehavior.Editable = False
    End Sub

    Private Sub btnChon_PT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChon_PT.Click
        Call Select_TT_PT()
    End Sub

    Private Sub BtnXoa43_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa43.Click
        If grvCTTB_PT.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT39", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim sMS_PT As String = Me.grvCTTB_PT.GetFocusedDataRow()("MS_PT")
        Dim sMS_MAY As String = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
        Dim sMS_BP As String = txtMS_BO_PHAN.Text
        Dim sSql As String
        Dim sMS_VI_TRI_PT As String = Me.grvCTTB_PT.GetFocusedDataRow()("MS_VI_TRI_PT")
        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT42", Commons.Modules.TypeLanguage)
        Dim tmp As Integer = intTab11

        Dim strThongBao As String = ""
        Kiem_tra_CauTrucThietBi_VTPT(grvCTTB_PT.GetFocusedDataRow()("MS_PT").ToString(), strThongBao)
        If strThongBao.Trim <> "" Then
            XtraMessageBox.Show(strThongBao, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sSql = "DELETE FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY= N'" & sMS_MAY & "' AND MS_BO_PHAN= N'" & sMS_BP & "' " &
                            " AND MS_PT= N'" & sMS_PT & "' AND MS_VI_TRI_PT = N'" & sMS_VI_TRI_PT & "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Call ShowTHONG_TIN_PT()
            Call FormatGridPT()
        End If
TT:
        Try
            If grvCTTB_PT.RowCount > 0 Then
                If grvCTTB_PT.RowCount = tmp Then
                    grvCTTB_PT.FocusedRowHandle = tmp - 1
                Else
                    grvCTTB_PT.FocusedRowHandle = tmp
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Kiem_Tra_DS_VTPT_Lien_Quan(ByRef strThongBao As String) As Boolean
        Dim bKiemTra As Boolean = False
        Dim bHoi As Boolean = False
        Dim sSql As String = ""

        For i As Integer = 0 To grvLoaiBTPN_PT.RowCount - 1
            bKiemTra = Kiem_Tra_MS_VTPT_Lien_Quan(grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT"), strThongBao)
            If bHoi = False And strThongBao.Trim <> "" Then If XtraMessageBox.Show(strThongBao, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Return False
            bHoi = True
            If bKiemTra = True Then
                If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)) > 0 Then
                    sSql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                End If

                If InStr(strThongBao, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)) > 0 Then
                    'XÓA DL CỦA BẢNG PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET
                    sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                    'XÓA DL PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG
                    sSql = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_CV=" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT") & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                End If
            End If
        Next
        Return True
    End Function

    Private Function Kiem_Tra_MS_VTPT_Lien_Quan(ByVal MS_PT As String, Optional ByRef strThongBao As String = "") As Boolean
        Dim dtReader As SqlDataReader
        Dim bKHTT As Boolean = False, bPBT As Boolean = False
        Dim strTam As String = ""

        strThongBao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "VAT_TU_DANG_DUOC_SU_DUNG", Commons.Modules.TypeLanguage).ToString.Trim
        SQL = "SELECT ISNULL(COUNT(*),0) AS TONG FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "' AND MS_PT='" & MS_PT & "'" '"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bKHTT = True
                strTam = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_KHTT", Commons.Modules.TypeLanguage)
                Exit While
            End If
        End While
        dtReader.Close()

        SQL = "SELECT ISNULL(COUNT(*),0) AS TONG FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PT='" & MS_PT & "' AND MS_PHIEU_BAO_TRI IN (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "')"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            If dtReader.Item("TONG") > 0 Then
                bPBT = True
                If bKHTT = True Then
                    strTam = strTam & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "AND", Commons.Modules.TypeLanguage) & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)
                Else
                    strTam = strTam & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRONG_PBT", Commons.Modules.TypeLanguage)
                End If
                Exit While
            End If
        End While
        dtReader.Close()


        If bKHTT = True Or bPBT = True Then
            strThongBao += " " & strTam + vbCrLf & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHAC_XOA", Commons.Modules.TypeLanguage)
            Return True
        Else
            strThongBao = ""
            Return False
        End If
    End Function

    Private Sub tvwCautrucTB_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim strTraloi As String

        strTraloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenkt54", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If strTraloi = vbNo Then Exit Sub

        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = selectedTreeview.SelectedNode

        'Remove the drop node from its current location
        dropNode.Remove()

        'If there is no targetNode add dropNode to the bottom of the TreeView root
        'nodes, otherwise add it to the end of the dropNode child nodes
        If targetNode Is Nothing Then
            selectedTreeview.Nodes.Add(dropNode)
        Else
            targetNode.Nodes.Add(dropNode)
        End If

        'Ensure the newley created node is visible to the user and select it
        dropNode.EnsureVisible()
        selectedTreeview.SelectedNode = dropNode
        SQL = "UPDATE CAU_TRUC_THIET_BI SET MS_BO_PHAN_CHA=N'" & targetNode.Name & "' WHERE MS_BO_PHAN='" & dropNode.Name & "' AND MS_MAY=N'" & txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
    End Sub

    Private Sub tvwCautrucTB_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Move
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtNGAY_BD_BAO_HANH_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        ucDMTBi.txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(ucDMTBi.txtSO_THANG_BH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date)
    End Sub

    Private Sub txtNGAY_DUA_VAO_SD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim ngay As Date
            ngay = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
            Dim i As Short = DateDiff(DateInterval.Month, ngay, Date.Now)
            Dim j As Short = i Mod 12
            Dim k As Short = (i - j) / 12
            If j > 0 Then
                ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage) & " " & j & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thang_sd", Commons.Modules.TypeLanguage)
            Else
                ucDMTBi.txtSO_NAM_SD.Text = k & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Nam_sd", Commons.Modules.TypeLanguage)
            End If
        Catch ex As Exception
            ucDMTBi.txtSO_NAM_SD.Text = 0
        End Try
    End Sub

    Private Sub BtnXoa42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa42.Click
        If grvThongSoBP.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT39", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT57", Commons.Modules.TypeLanguage)
        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        Dim sSql As String = ""
        sSql = "DELETE FROM THONG_SO_BO_PHAN WHERE MS_MAY=N'" & txtMS_MAY.Text & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "' AND STT=" & grvThongSoBP.GetFocusedDataRow()("STT").ToString()
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Dim tmp As Integer = intTab15
        ShowTHONG_SO_BP()
        Try
            If grvThongSoBP.RowCount > 0 Then
                If grvThongSoBP.RowCount = tmp Then
                    grvThongSoBP.FocusedRowHandle = tmp - 1
                Else
                    grvThongSoBP.FocusedRowHandle = tmp
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BtnNhapHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPathAnh.Click
        If Not BtnThem4.Visible Then
            strHinh = TxtHINH.Text
            OfdHInh.Filter = "(All file)|*.*|(*.gif)|*.gif|(*.jpg)|*.jpg|(*.bmp)|*.bmp"
            OfdHInh.ShowDialog()
        Else
            Try
                If TxtHINH.Text.Trim <> "" Then System.Diagnostics.Process.Start(TxtHINH.Text)
            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT45", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub
    Private Sub BtnThoat41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat41.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoat42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat42.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThoat43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat43.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThoat44_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat44.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub CreaterptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI()
        Dim str As String = ""
        Try
            str = " DROP TABLE rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI(TypeLanguage int, TrangIn nvarchar(20),NgayIn nvarchar(20),TieuDe nvarchar(255)," &
            "sSTT nvarchar(5),ThietBi nvarchar(30),BoPhan nvarchar(50),ThongSo nvarchar(50),ChuKy nvarchar(50),NgayCuoi nvarchar(30),GiaTri nvarchar(2000),DonVi_TG nvarchar(30), TM1 nvarchar(250), TM2 nvarchar(250),TM3 nvarchar(250),TM4 nvarchar(250),TM5 nvarchar(250))"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TieuDeP", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngayin", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Trangin", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ThietBi", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BoPhan", Commons.Modules.TypeLanguage)
        Dim ThongSo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ThongSo", Commons.Modules.TypeLanguage)
        Dim ChuKy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuKy", Commons.Modules.TypeLanguage)
        Dim NgayCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NgayCuoi", Commons.Modules.TypeLanguage)
        Dim GiaTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GiaTri", Commons.Modules.TypeLanguage)
        Dim DonVi_TG As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DonVi_TG", Commons.Modules.TypeLanguage)

        Dim TM1, TM2, TM3, TM4, TM5 As String
        TM1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TM1", Commons.Modules.TypeLanguage)
        TM2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TM2", Commons.Modules.TypeLanguage)
        TM3 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TM3", Commons.Modules.TypeLanguage)
        TM4 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TM4", Commons.Modules.TypeLanguage)
        TM5 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TM5", Commons.Modules.TypeLanguage)

        str = "INSERT INTO rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,sSTT,ThietBi,BoPhan,ThongSo,ChuKy,NgayCuoi,GiaTri,DonVi_TG, TM1, TM2, TM3, TM4, TM5) values (" &
        Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & sSTT & "',N'" & ThietBi & "',N'" & BoPhan &
        "',N'" & ThongSo & "',N'" & ChuKy & "',N'" & NgayCuoi & "',N'" & GiaTri & "',N'" & DonVi_TG & "',N'" & TM1 & "',N'" & TM2 & "',N'" & TM3 & "',N'" & TM4 & "',N'" & TM5 & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub ShowrptQUI_DINH_VE_GSTT_THIET_BI()
        Dim str As String = ""

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptQUI_DINH_VE_GSTT_THIET_BI")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "Temp")
        'CreaterptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI()

        str = "SELECT DISTINCT dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN, dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN, dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT, dbo.THONG_SO_GSTT.TEN_TS_GSTT, " &
                     "CONVERT(NVARCHAR(10), CAU_TRUC_THIET_BI_TS_GSTT.CHU_KY_DO) + ' ' + (CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN  DON_VI_THOI_GIAN.TEN_DV_TG WHEN 1 THEN DON_VI_THOI_GIAN.TEN_DV_TG_ANH ELSE DON_VI_THOI_GIAN.TEN_DV_TG_HOA END) AS CHU_KY_DO,CONVERT(NVARCHAR(2000),NULL) AS THONG_SO_GSTT " &
              "INTO  [DBO].rptQUI_DINH_VE_GSTT_THIET_BI " &
              "FROM  dbo.CAU_TRUC_THIET_BI INNER JOIN dbo.CAU_TRUC_THIET_BI_TS_GSTT ON dbo.CAU_TRUC_THIET_BI.MS_MAY = dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY AND " &
                    "dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN INNER JOIN " &
                    "dbo.THONG_SO_GSTT ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT = dbo.THONG_SO_GSTT.MS_TS_GSTT INNER JOIN " &
                    "dbo.DON_VI_THOI_GIAN ON dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_DV_TG = dbo.DON_VI_THOI_GIAN.MS_DV_TG INNER JOIN " &
                    "dbo.CAU_TRUC_THIET_BI_TS_GSTT CAU_TRUC_THIET_BI_TS_GSTT_1 ON " &
                    "dbo.CAU_TRUC_THIET_BI.MS_MAY = CAU_TRUC_THIET_BI_TS_GSTT_1.MS_MAY AND " &
                    "dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN = CAU_TRUC_THIET_BI_TS_GSTT_1.MS_BO_PHAN AND " &
                    "dbo.THONG_SO_GSTT.MS_TS_GSTT = CAU_TRUC_THIET_BI_TS_GSTT_1.MS_TS_GSTT " &
              "WHERE CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY=N'" & txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)


        Dim dtReader As SqlDataReader, MS_TS_GSTT As Integer = -1
        Dim TEN_TS As String = ""

        str = "SELECT DISTINCT rptQUI_DINH_VE_GSTT_THIET_BI.MS_TS_GSTT, GIA_TRI_TS_GSTT.TEN_GIA_TRI " &
                "FROM rptQUI_DINH_VE_GSTT_THIET_BI INNER JOIN GIA_TRI_TS_GSTT ON rptQUI_DINH_VE_GSTT_THIET_BI.MS_TS_GSTT = GIA_TRI_TS_GSTT.MS_TS_GSTT " &
                "union all " &
                "SELECT DISTINCT rptQUI_DINH_VE_GSTT_THIET_BI.MS_TS_GSTT, dbo.CAU_TRUC_THIET_BI_TS_GSTT.TEN_GT + ' (' + CAST(dbo.CAU_TRUC_THIET_BI_TS_GSTT.GIA_TRI_DUOI AS VARCHAR(10)) + '~' + CAST(dbo.CAU_TRUC_THIET_BI_TS_GSTT.GIA_TRI_TREN AS VARCHAR(10)) + ')' AS TEN_GIA_TRI " &
                "FROM dbo.rptQUI_DINH_VE_GSTT_THIET_BI INNER JOIN  dbo.CAU_TRUC_THIET_BI_TS_GSTT ON dbo.rptQUI_DINH_VE_GSTT_THIET_BI.MS_MAY = dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_MAY AND  dbo.rptQUI_DINH_VE_GSTT_THIET_BI.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_BO_PHAN AND   dbo.rptQUI_DINH_VE_GSTT_THIET_BI.MS_TS_GSTT = dbo.CAU_TRUC_THIET_BI_TS_GSTT.MS_TS_GSTT where TEN_GT is not null"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            If MS_TS_GSTT <> dtReader.Item("MS_TS_GSTT") Then
                If MS_TS_GSTT <> -1 Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptQUI_DINH_VE_GSTT_THIET_BI SET THONG_SO_GSTT=N'" & TEN_TS.Substring(0, TEN_TS.Length - 2).ToString.Trim & ".' WHERE MS_TS_GSTT=" & MS_TS_GSTT)
                    TEN_TS = ""
                End If
                MS_TS_GSTT = dtReader.Item("MS_TS_GSTT")
            End If

            If MS_TS_GSTT = dtReader.Item("MS_TS_GSTT") Then TEN_TS += dtReader.Item("TEN_GIA_TRI").ToString.Trim & "; "
        End While
        If TEN_TS.Trim <> "" Then SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptQUI_DINH_VE_GSTT_THIET_BI SET THONG_SO_GSTT=N'" & TEN_TS.Substring(0, TEN_TS.Length - 1).ToString.Trim & "' WHERE MS_TS_GSTT=" & MS_TS_GSTT)

        dtReader.Close()
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ISNULL(COUNT(*),0) AS TONG FROM rptQUI_DINH_VE_GSTT_THIET_BI")
        While dtReader.Read
            If dtReader.Item("TONG") = 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtReader.Close()
                GoTo KET_THUC
            End If
        End While
        dtReader.Close()
        'Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
        'If Commons.Modules.sPrivate = "ADC" Then
        '    frmRepot.rptName = "rptQUI_DINH_VE_GSTT_THIET_BI_ADC"
        '    Commons.Modules.SQLString = "0Design"
        'Else
        '    frmRepot.rptName = "rptQUI_DINH_VE_GSTT_THIET_BI"
        'End If
        str = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY rptQUI_DINH_VE_GSTT_THIET_BI.TEN_BO_PHAN DESC) AS STT,rptQUI_DINH_VE_GSTT_THIET_BI.TEN_TS_GSTT,rptQUI_DINH_VE_GSTT_THIET_BI.TEN_BO_PHAN, rptQUI_DINH_VE_GSTT_THIET_BI.thong_so_gstt as TEN_GIA_TRI,rptQUI_DINH_VE_GSTT_THIET_BI.CHU_KY_DO " &
                "into Temp FROM rptQUI_DINH_VE_GSTT_THIET_BI "

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)


        dtReader.Close()
        Dim rptname = "rptQUI_DINH_VE_GSTT_THIET_BI"
        Dim vtbData As New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM Temp"))
        vtbData.TableName = "rptQUI_DINH_VE_GSTT_THIET_BI"
        If vtbData.Rows.Count > 0 Then

            Dim vtbTitle As New DataTable()
            For i As Integer = 0 To 9
                vtbTitle.Columns.Add()
            Next
            Commons.Modules.ObjSystems.MLoadXtraGrid(ucDMTBi.grdChung, ucDMTBi.grvChung, vtbData, False, True, True, True, True, Me.Name.ToString)
            ucDMTBi.grvChung.Columns("TEN_TS_GSTT").Group()
            ucDMTBi.grvChung.Columns("TEN_GIA_TRI").Group()
            ucDMTBi.grvChung.ExpandAllGroups()
        End If
        InVB(rptname, 1)



KET_THUC:

        Try
            str = "DROP TABLE rptQUI_DINH_VE_GSTT_THIET_BI"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = " DROP TABLE rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = " DROP TABLE Temp"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnLichSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If LstMAY.Items.Count <= 0 Then Exit Sub
        If grvMay.RowCount <= 0 Then Exit Sub
        frmHistory.MS_MAY = txtMS_MAY.Text
        frmHistory.Show()
    End Sub



    Private Sub BtnThoat6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat6.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnKhoiTaoLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhoiTaoLS.Click
        If dtpTuNgay1.Text = "" Or dtpDenNgay1.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBoxChuaChonTuNgayHoacDenNgay", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            tlHistory.DataSource = Nothing
            Exit Sub
        End If
        If txtMS_MAY.Text = "" Then
            tlHistory.DataSource = Nothing
        Else
            Me.Cursor = Cursors.WaitCursor
            ShowTreeRoot1(tlHistory, txtMS_MAY.Text)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Function tblCNFullName() As DataTable
        Dim dtCN As New DataTable
        Dim str As String = "SELECT * FROM CONG_NHAN"
        dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        Dim dtCNFullName As New DataTable
        dtCNFullName.Columns.Add("MS_CN")
        dtCNFullName.Columns.Add("HoTen")
        Dim rowFName, row As DataRow
        For Each row In dtCN.Rows
            rowFName = dtCNFullName.NewRow()
            rowFName("ms_cn") = row("MS_CONG_NHAN")
            rowFName("hoten") = row("ho").ToString() & " " & row("ten").ToString()
            dtCNFullName.Rows.Add(rowFName)
        Next
        Return dtCNFullName
    End Function


    Private Sub loadCboHeThong()

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLine, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", "")
    End Sub

    Sub CreateInLichSuCauTrucTB()
        exportToExcel2()
    End Sub

    Private Sub InLSCTTBTN()
        If tlHistory.Nodes.Count = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        'CreateInLichSuCauTrucTB()
        'DataTable dt = New DataTable();
        '    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spInLichSuThietBi", "-1", "01/01/2000", "01/01/2022"));

        '    ucInLSTB myUc = New ucInLSTB(DateTime.Parse("01/01/2000"), DateTime.Parse("01/01/2002"), "-1", "ten may", dt);
        '    myUc.Location = New Point(0, 0);
        '    myUc.Dock = DockStyle.Fill;
        '    this.Controls.Add(myUc);
        '    myUc.InReport();
        '    Commons.Modules.ObjSystems.ThayDoiNN(this);

        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spInLichSuThietBi", ucDMTBi.txtMS_MAY.Text, dtpTuNgay1.DateTime.Date, dtpDenNgay1.DateTime.Date))
        Dim myUc = New WareHouse.ucInLSTB(dtpTuNgay1.DateTime.Date, dtpDenNgay1.DateTime.Date, ucDMTBi.txtMS_MAY.Text, ucDMTBi.txtTEN_MAY.Text, dt)
        myUc.Visible = False
        Me.Controls.Add(myUc)
        myUc.InReport()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub InLichSuCTTB()
        If tlHistory.Nodes.Count = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        CreateInLichSuCauTrucTB()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function returnParentNode(ByVal nodeChild As String) As String

        Dim i As Integer = 0
        Dim parentNode As String, ten As String = ""
        Dim dt As New DataTable()

        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT distinct MS_BO_PHAN_CHA,(SELECT distinct TEN_BO_PHAN FROM CAU_TRUC_THIET_BI  A WHERE A.MS_BO_PHAN=CAU_TRUC_THIET_BI.MS_BO_PHAN_CHA and MS_MAY=N'" & txtMS_MAY.Text & "') FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN='" & nodeChild & "'AND MS_MAY=N'" & txtMayTT.Text & "'"))
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If

        parentNode = dt.Rows(0)(0).ToString()
        ten = dt.Rows(0)(1).ToString()
        If parentNode = txtMayTT.Text Then
            Return Nothing
        End If
        Return (ten & "<" & returnParentNode(parentNode))
    End Function


    Private Sub exportToExcel2()
        Dim str As String = ""
        If txtMayTT.Text = "" Then
            txtMayTT.Text = txtMS_MAY.Text
        End If

        Try
            SqlText = "DROP TABLE EXPORT_TO_EXCEL"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay1.DateTime.Date.ToString()).Day.ToString()
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay1.DateTime.Date.ToString()).Month.ToString()
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay1.DateTime.Date.ToString()).Year.ToString()
        Dim _date_TN As String = thang_TN & "/" & ngay_TN & "/" & nam_TN
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay1.DateTime.Date.ToString()).Day.ToString()
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay1.DateTime.Date.ToString()).Month.ToString()
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay1.DateTime.Date.ToString()).Year.ToString()
        Dim _date_DN As String = thang_DN & "/" & ngay_DN & "/" & nam_DN

        SqlText = ""

        If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then
            SqlText = " SELECT  DISTINCT   dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, dbo.CONG_VIEC.MO_TA_CV, dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN, " &
                          " dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, IC_PHU_TUNG_1.TEN_PT, " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT, " &
                          " dbo.IC_PHU_TUNG.TEN_PT AS Expr1, " &
                        " CASE WHEN dbo.PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL THEN  " &
                        " CASE WHEN (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,0)  = 0) AND ISNULL( dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU,'') <> '' THEN    dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH ELSE      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT END " &
                        " ELSE  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT END AS SL_TT , " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT, " &
                            " CASE WHEN  '" & Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi).ToString().ToUpper() & "' = 'TRUE' " &
                          " THEN DHG.XUAT_XU ELSE dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU END AS XUAT_XU, " &
                          " CASE WHEN  '" & Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi).ToString().ToUpper() & "' = 'TRUE' " &
                          " THEN  DHG.GHI_CHU " &
                          " ELSE case  when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU is null then  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU else dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU end END " &
                          " as GHI_CHU "
            If Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi) Then
                SqlText = SqlText & " , dbo.IC_DON_HANG_NHAP_VAT_TU.ID "
            Else
                SqlText = SqlText & " , CONVERT(INT,0) AS ID "
            End If


            SqlText = SqlText & " FROM         dbo.CONG_VIEC INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI ON " &
                          " dbo.CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV INNER JOIN " &
                          " dbo.CAU_TRUC_THIET_BI ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT "
            If Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi) Then
                SqlText = SqlText & " AND dbo.IC_DON_HANG_NHAP_VAT_TU.ID = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.ID "
            End If
            SqlText = SqlText & " INNER JOIN " &
                          " dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT = dbo.IC_PHU_TUNG.MS_PT RIGHT OUTER JOIN " &
                          " dbo.IC_PHU_TUNG IC_PHU_TUNG_1 INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                          " IC_PHU_TUNG_1.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE = dbo.CONG_NHAN.MS_CONG_NHAN "

            If Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi) Then
                SqlText = SqlText & " LEFT OUTER JOIN " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU AS DHG ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = DHG.MS_PT AND " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT_GOC = DHG.MS_DH_NHAP_PT AND dbo.IC_DON_HANG_NHAP_VAT_TU.ID_GOC = DHG.ID  "
            Else
                SqlText = SqlText & " LEFT OUTER JOIN " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU AS DHG ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = DHG.MS_PT AND " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = DHG.MS_DH_NHAP_PT "

            End If
            SqlText = SqlText & " WHERE (PHIEU_BAO_TRI.TINH_TRANG_PBT >= 4) AND (PHIEU_BAO_TRI.MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "') AND  " &
                          " (dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ")) " &
                          "  " &
                          " ORDER BY dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH DESC "

            '" AND ( (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT,0)  > 0)  " & _
            'OR  ( ISNULL( dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU,'') <> '' ) 
        Else
            'chu y IC_PHU_TUNG_1.TEN_PT ten la ten_pt nhung lay MS_PT_NCC 
            SqlText = " SELECT  DISTINCT   dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, dbo.CONG_VIEC.MO_TA_CV, dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN, " &
                          " dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, IC_PHU_TUNG_1.MS_PT_NCC AS TEN_PT , " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT, " &
                          " IC_PHU_TUNG_1.TEN_PT AS Expr1, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT, " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT, dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, " &
                          " case  when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU is null then  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU else dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU end as GHI_CHU , CONVERT(INT,0) AS ID " &
                          " FROM         dbo.CONG_VIEC INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI ON " &
                          " dbo.CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV INNER JOIN " &
                          " dbo.CAU_TRUC_THIET_BI ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT INNER JOIN " &
                          " dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT = dbo.IC_PHU_TUNG.MS_PT RIGHT OUTER JOIN " &
                          " dbo.IC_PHU_TUNG IC_PHU_TUNG_1 INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                          " IC_PHU_TUNG_1.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE = dbo.CONG_NHAN.MS_CONG_NHAN " &
                          " WHERE (PHIEU_BAO_TRI.TINH_TRANG_PBT >= 4) AND (PHIEU_BAO_TRI.MS_MAY=N'" & txtMS_MAY.Text & "') AND  " &
                          " (dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ")) " &
                          " ORDER BY dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH DESC"
            '(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT IS NOT NULL AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT >0 ) AND 
        End If

        Dim dt, dtFirst As New DataTable()
        dtFirst.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        If dtFirst.Rows.Count < 1 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If


        dt.TableName = "rptTIEU_DE_LICH_SU_TB"
        dt.Columns.Add("TIEU_DE")
        dt.Columns.Add("NGAY_HT")
        dt.Columns.Add("MO_TA_CV")
        dt.Columns.Add("TEN_BO_PHAN")
        dt.Columns.Add("MS_PHIEU_BAO_TRI")
        dt.Columns.Add("MS_PT")
        dt.Columns.Add("TEN_PT")
        dt.Columns.Add("MS_VI_TRI_PT")
        dt.Columns.Add("MS_PTTT")
        dt.Columns.Add("TEN_PTTT")
        dt.Columns.Add("SL_TT")
        dt.Columns.Add("MS_DH_NHAP_PT")
        dt.Columns.Add("XUAT_XU")
        dt.Columns.Add("GHI_CHU")
        dt.Columns.Add("MS_MAY")
        dt.Columns.Add("TEN_MAY")
        dt.Columns.Add("BO_PHAN")

        dt.Columns.Add("MS_BC")
        dt.Columns.Add("MS_BC1")
        dt.Columns.Add("NGAY_HL")
        dt.Columns.Add("NGAY_SX")

        If Commons.Modules.sPrivate = "ADC" Then
            dt.Columns.Add("TM1")
            dt.Columns.Add("TM2")
            dt.Columns.Add("TM3")
            dt.Columns.Add("TM4")
            dt.Columns.Add("TM5")
        End If


        Dim rDt As DataRow = dt.NewRow()

        rDt("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage)
        rDt("NGAY_HT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "NGAY_HT", Commons.Modules.TypeLanguage)
        rDt("MO_TA_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MO_TA_CV", Commons.Modules.TypeLanguage)
        rDt("TEN_BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        rDt("MS_PHIEU_BAO_TRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
        rDt("MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_PT", Commons.Modules.TypeLanguage)
        If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then
            rDt("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_PT", Commons.Modules.TypeLanguage)
        Else
            rDt("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_PT_NCC", Commons.Modules.TypeLanguage)
        End If
        rDt("MS_VI_TRI_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
        rDt("MS_PTTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_PTTT", Commons.Modules.TypeLanguage)
        rDt("TEN_PTTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_PTTT", Commons.Modules.TypeLanguage)
        rDt("SL_TT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "SL_TT", Commons.Modules.TypeLanguage)
        rDt("MS_DH_NHAP_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
        rDt("XUAT_XU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "XUAT_XU", Commons.Modules.TypeLanguage)
        rDt("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "GHI_CHU", Commons.Modules.TypeLanguage)

        rDt("MS_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_MAY", Commons.Modules.TypeLanguage) & "  " & txtMS_MAY.Text
        rDt("TEN_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TEN_MAY", Commons.Modules.TypeLanguage) & "  " & ucDMTBi.txtTEN_MAY.Text
        If txtMS_MAY.Text.Trim() = tlHistory.FocusedNode("MS_BO_PHAN").ToString().Trim() Then
            rDt("BO_PHAN") = ""
        Else
            rDt("BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "BO_PHAN", Commons.Modules.TypeLanguage) & "  " & tlHistory.FocusedNode("TEN_BO_PHAN").ToString()
        End If

        If Commons.Modules.sPrivate = "VINHHOAN" Then
            rDt("MS_BC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_BC", Commons.Modules.TypeLanguage)
            rDt("MS_BC1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "MS_BC1", Commons.Modules.TypeLanguage)
            rDt("NGAY_HL") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "NGAY_HL", Commons.Modules.TypeLanguage)
            rDt("NGAY_SX") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "NGAY_SX", Commons.Modules.TypeLanguage)
            Commons.Modules.SQLString = "0Design"
        ElseIf Commons.Modules.sPrivate = "ADC" Then
            rDt("TM1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TM1", Commons.Modules.TypeLanguage)
            rDt("TM2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TM2", Commons.Modules.TypeLanguage)
            rDt("TM3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TM3", Commons.Modules.TypeLanguage)
            rDt("TM4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TM4", Commons.Modules.TypeLanguage)
            rDt("TM5") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TM5", Commons.Modules.TypeLanguage)
            Commons.Modules.SQLString = "0Design"
        Else
            rDt("MS_BC") = "-1"
        End If

        dt.Rows.Add(rDt)

        dtFirst.TableName = "rptLICH_SU_THIET_BI"

        Dim frmLichsuTB As frmShowXMLReport = New frmShowXMLReport()
        frmLichsuTB.AddDataTableSource(dt)
        frmLichsuTB.AddDataTableSource(dtFirst)
        If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then
            If Commons.Modules.sPrivate = "ADC" Then
                frmLichsuTB.rptName = "rptLICH_SU_THIET_BI_ADC"
            Else
                frmLichsuTB.rptName = "rptLICH_SU_THIET_BI"
            End If
        Else
            If Commons.Modules.sPrivate = "ADC" Then
                frmLichsuTB.rptName = "rptLICH_SU_THIET_BI_KK_ADC"
            Else
                frmLichsuTB.rptName = "rptLICH_SU_THIET_BI_KK"
            End If
        End If
        frmLichsuTB.ShowDialog()


    End Sub


    Private Sub BtnXemPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemPBT.Click
        If grvLichSuMay.RowCount = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KO_DL_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        ShowReport()
    End Sub

    Sub CreaterptTieuDePhieuBaoTri()
        Dim str As String = ""
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TrangIn", Commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TieuDe", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ThietBi", Commons.Modules.TypeLanguage)
        Dim PhieuBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayLap", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim HinhThucBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "HinhThucBT", Commons.Modules.TypeLanguage)
        Dim LoaiBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "LoaiBt", Commons.Modules.TypeLanguage)
        Dim DiaDiem As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DiaDiem", Commons.Modules.TypeLanguage)
        Dim NgayBD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayBD", Commons.Modules.TypeLanguage)
        Dim NgayKT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayKT", Commons.Modules.TypeLanguage)
        Dim BoPhanCP As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BoPhanCP", Commons.Modules.TypeLanguage)
        Dim NgayNT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayNT", Commons.Modules.TypeLanguage)
        Dim NguoiNT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiNT", Commons.Modules.TypeLanguage)
        Dim KetQuaBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KetQuaBT", Commons.Modules.TypeLanguage)
        Dim ChiPhiPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiPhutung", Commons.Modules.TypeLanguage)
        Dim ChiPhiVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiVatTu", Commons.Modules.TypeLanguage)
        Dim chiPhiNhanCong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiNhanCong", Commons.Modules.TypeLanguage)
        Dim ChiPhiDichVu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiDichVu", Commons.Modules.TypeLanguage)
        Dim ChiPhiKhac As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhiKhac", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "STT", Commons.Modules.TypeLanguage)
        Dim NoiDung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NoiDung", Commons.Modules.TypeLanguage)
        Dim ChiPhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChiPhi", Commons.Modules.TypeLanguage)
        Dim TongChiPhi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TongChiPhi", Commons.Modules.TypeLanguage)
        Dim KetQuaBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KetQuaBaoTri", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "Tong", Commons.Modules.TypeLanguage)
        Dim MoTa As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MoTa", Commons.Modules.TypeLanguage)
        Dim KeHoachThucHien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KeHoachThucHien", Commons.Modules.TypeLanguage)
        Dim DanhSachCongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "KeHoachCongViec", Commons.Modules.TypeLanguage)
        Dim DanhSachNhanVien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DanhSachNhanVien", Commons.Modules.TypeLanguage)
        Dim DanhSachDichVu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DanhSachDichVu", Commons.Modules.TypeLanguage)
        Dim DanhSachPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DanhSachPhuTung", Commons.Modules.TypeLanguage)
        Dim DiChuyenBoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DiChuyenBoPhan", Commons.Modules.TypeLanguage)
        Dim TinhTrangPBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TinhTrangPBT", Commons.Modules.TypeLanguage)

        Dim TenThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenThietBi", Commons.Modules.TypeLanguage)
        Dim PheDuyet1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PheDuyet1", Commons.Modules.TypeLanguage)
        Dim PheDuyet2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PheDuyet2", Commons.Modules.TypeLanguage)
        Dim PheDuyet3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "PheDuyet3", Commons.Modules.TypeLanguage)
        Dim LY_DO_BT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "LY_DO_BT", Commons.Modules.TypeLanguage)

        Try
            str = "Drop table rptTieuDePhieuBaoTri"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "Create table dbo.rptTieuDePhieuBaoTri(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255),ThietBi nvarchar(50)," &
        " PhieuBaoTri nvarchar(60),NgayLap nvarchar(50),NguoiLap nvarchar(60),HinhThucBT nvarchar(100), LoaiBT nvarchar(80),DiaDiem nvarchar(50), " &
        " NgayBD nvarchar(80),NgayKT nvarchar(80),BoPhanCP nvarchar(50),NgayNT nvarchar(60),NguoiNT nvarchar(80),KetQuaBT nvarchar(80),ChiPhiPhuTung nvarchar(100), " &
        " ChiPhiVatTu nvarchar(100),ChiPhuNhanCong nvarchar(100),ChiPhiDichVu nvarchar(100),ChiPhiKhac nvarchar(100),STT nvarchar(5),NoiDung nvarchar(50), " &
        " ChiPhi nvarchar(50),TongChiPhi nvarchar(70),KetQuaBaoTri nvarchar(80),Tong nvarchar(20),MoTa nvarchar(50),KeHoachThuchien nvarchar(80), " &
        " DanhSachCongViec nvarchar(255),DanhSachNhanVien nvarchar(255),DanhSachDichVu nvarchar(80),DanhSachPhuTung nvarchar(80),DiChuyenBoPhan nvarchar(80),TinhTrangPBT nvarchar(50),TenThietBi nvarchar(50),PheDuyet1 nvarchar(50),PheDuyet2 nvarchar(50),PheDuyet3 nvarchar(50),LY_DO_BT NVARCHAR (256)) " &
        " Insert into rptTieuDePhieuBaoTri values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & ThietBi & "',N'" & PhieuBaoTri &
        "',N'" & NgayLap & "',N'" & NguoiLap & "',N'" & HinhThucBT & "',N'" & LoaiBT & "',N'" & DiaDiem & "',N'" & NgayBD & "',N'" & NgayKT & "',N'" & BoPhanCP &
        "',N'" & NgayNT & "',N'" & NguoiNT & "',N'" & KetQuaBT & "',N'" & ChiPhiPhuTung & "',N'" & ChiPhiVatTu & "',N'" & chiPhiNhanCong & "',N'" & ChiPhiDichVu &
        "',N'" & ChiPhiKhac & "',N'" & STT & "',N'" & NoiDung & "',N'" & ChiPhi & "',N'" & TongChiPhi & "',N'" & KetQuaBaoTri & "',N'" & Tong & "',N'" & MoTa & "',N'" &
        KeHoachThucHien & "',N'" & DanhSachCongViec & "',N'" & DanhSachNhanVien & "',N'" & DanhSachDichVu & "',N'" & DanhSachPhuTung & "',N'" & DiChuyenBoPhan & "',N'" & TinhTrangPBT &
        "',N'" & TenThietBi & "',N'" & PheDuyet1 & "',N'" & PheDuyet2 & "',N'" & PheDuyet3 & "',N'" & LY_DO_BT & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDeCongViecBaoTri"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "CongViec", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BoPhan", Commons.Modules.TypeLanguage)
        Dim SoGioKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SoGioKH", Commons.Modules.TypeLanguage)
        Dim NgayHoanThanh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayHoanThanh", Commons.Modules.TypeLanguage)
        Dim NoiNgoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NoiNgoai", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeCongViecBaoTri(TieuDe nvarchar(100),CongViec nvarchar(50),BoPhan nvarchar(50),SoGioKH nvarchar(50),NgayHoanThanh nvarchar(80),NoiNgoai nvarchar(50))" &
        " Insert into rptTieuDeCongViecBaoTri values(N'" & DanhSachCongViec & "',N'" & CongViec & "',N'" & BoPhan & "',N'" & SoGioKH & "',N'" & NgayHoanThanh & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDeNhanCongBaoTri"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim HoTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "HoTen", Commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TuNgay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DenNgay", Commons.Modules.TypeLanguage)
        Dim ChinhPhu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChinhPhu", Commons.Modules.TypeLanguage)
        Dim BanTo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BanTo", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeNhanCongBaoTri(TieuDe nvarchar(100),HoTen Nvarchar(50),BanTo nvarchar(50),TuNgay nvarchar(50),Dengay Nvarchar(50),ChinhPhu nvarchar(50))" &
        " Insert into rptTieuDeNhanCongBaoTri values(N'" & DanhSachNhanVien & "',N'" & HoTen & "',N'" & BanTo & "',N'" & TuNgay & "',N'" & DenNgay & "',N'" & ChinhPhu & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDedichvuThueNgoaiBaoTri"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim NoidungService As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NoiDungService", Commons.Modules.TypeLanguage)
        Dim TenCongTy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenCongTy", Commons.Modules.TypeLanguage)
        Dim NguoiDaiDien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiDaiDien", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SoLuong", Commons.Modules.TypeLanguage)
        Dim DonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DonGia", Commons.Modules.TypeLanguage)
        Dim TyGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TyGia", Commons.Modules.TypeLanguage)
        Dim ThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ThanhTien", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDedichvuThueNgoaiBaoTri(TieuDe nvarchar(100),NoiDungService nvarchar(80),TenCongTy nvarchar(50),NguoiDaiDien nvarchar(80),SoLuong nvarchar(40),Dongia nvarchar(50),TyGia nvarchar(30),ThanhTien nvarchar(40)) " &
        " Insert into rptTieuDedichvuThueNgoaiBaoTri values(N'" & DanhSachDichVu & "',N'" & NoidungService & "',N'" & TenCongTy & "',N'" & NguoiDaiDien & "',N'" & SoLuong & "',N'" & DonGia & "',N'" & TyGia & "',N'" & ThanhTien & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDePhuTungBaoTri"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim MaVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MaVatTu", Commons.Modules.TypeLanguage)
        Dim TenVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenVatTu", Commons.Modules.TypeLanguage)
        Dim SLKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLKH", Commons.Modules.TypeLanguage)
        Dim SLTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLTT", Commons.Modules.TypeLanguage)
        Dim DonVi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DonVi", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDePhuTungBaoTri(TieuDe nvarchar(100),MaVatTu nvarchar(50), TenVatTu nvarchar(50),SLKH nvarchar(60),SLTT nvarchar(60),DonVi nvarchar(10),NoiNgoai nvarchar(30))" &
        " Insert into rptTieuDePhuTungBaoTri values(N'" & DanhSachPhuTung & "',N'" & MaVatTu & "',N'" & TenVatTu & "',N'" & SLKH & "',N'" & SLTT & "',N'" & DonVi & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        ' tao tieu de Report cho Phu Tung
        Try
            str = "Drop table rptTieuDe_PT_BT"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TIEU_DE_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TIEU_DE_PT", Commons.Modules.TypeLanguage)
        Dim MS_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MS_PT", Commons.Modules.TypeLanguage)
        Dim TEN_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TEN_PT", Commons.Modules.TypeLanguage)
        Dim SLKH_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLKH_PT", Commons.Modules.TypeLanguage)
        Dim SLTT_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLTT_PT", Commons.Modules.TypeLanguage)
        Dim DVT_PT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DVT_PT", Commons.Modules.TypeLanguage)

        str = "Create table dbo.rptTieuDe_PT_BT(TIEU_DE_PT nvarchar(100),MS_PT nvarchar(50), TEN_PT nvarchar(50),SLKH_PT nvarchar(60),SLTT_PT nvarchar(60),DVT_PT nvarchar(10),NoiNgoai nvarchar(30))" &
        " Insert into rptTieuDe_PT_BT values(N'" & TIEU_DE_PT & "',N'" & MS_PT & "',N'" & TEN_PT & "',N'" & SLKH_PT & "',N'" & SLTT_PT & "',N'" & DVT_PT & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        ' tao tieu de Report cho Vat Tu

        Try
            str = "Drop table rptTieuDe_VT_BT"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TIEU_DE_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TIEU_DE_VT", Commons.Modules.TypeLanguage)
        Dim MS_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MS_VT", Commons.Modules.TypeLanguage)
        Dim TEN_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TEN_VT", Commons.Modules.TypeLanguage)
        Dim SLKH_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLKH_VT", Commons.Modules.TypeLanguage)
        Dim SLTT_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLTT_VT", Commons.Modules.TypeLanguage)
        Dim DVT_VT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DVT_VT", Commons.Modules.TypeLanguage)

        str = "Create table dbo.rptTieuDe_VT_BT(TIEU_DE_VT nvarchar(100),MS_VT nvarchar(50), TEN_VT nvarchar(50),SLKH_VT nvarchar(60),SLTT_VT nvarchar(60),DVT_VT nvarchar(10),NoiNgoai nvarchar(30))" &
        " Insert into rptTieuDe_VT_BT values(N'" & TIEU_DE_VT & "',N'" & MS_VT & "',N'" & TEN_VT & "',N'" & SLKH_VT & "',N'" & SLTT_VT & "',N'" & DVT_VT & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)



        Try
            str = "Drop table rptTieuDeDiChuyenBoPhanBaoTri"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TenBoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenBoPhan", Commons.Modules.TypeLanguage)
        Dim MayThayThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MayThayThe", Commons.Modules.TypeLanguage)
        Dim BoPhanTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BoPhanTT", Commons.Modules.TypeLanguage)
        Dim NguoiChoPhep As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NguoiChoPhep", Commons.Modules.TypeLanguage)
        Dim NgayThay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayThay", Commons.Modules.TypeLanguage)
        Dim NgayTra As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayTra", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeDiChuyenBoPhanBaoTri(TieuDe nvarchar(100),TenBoPhan nvarchar(50),MayThayThe nvarchar(80),BoPhanTT nvarchar(90),NguoichoPhep nvarchar(80),NgayThay nvarchar(50),NgayTra nvarchar(50)) " &
        " Insert into rptTieuDeDiChuyenBoPhanBaoTri values(N'" & DiChuyenBoPhan & "',N'" & TenBoPhan & "',N'" & MayThayThe & "',N'" & BoPhanTT & "',N'" & NguoiChoPhep & "',N'" & NgayThay & "',N'" & NgayTra & "')"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowReport()
        Me.Cursor = Cursors.WaitCursor
        CreaterptTieuDePhieuBaoTri()
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "GetrptCONG_VIEC_BAO_TRI", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "GetrptNHAN_CONG", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "GetrptDICH_VU_THUE_NGOAI", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "GetrptPHU_TUNG_BAO_TRI", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString(), Commons.Modules.TypeLanguage)
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "GetrptPHIEU_BAO_TRI1", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString(), Commons.Modules.TypeLanguage)
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "GetrptDI_CHUYEN_BO_PHAN_BAO_TRI", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "getPhieuBaoTriVatTu", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "getPhieuBaoTriPhuTung", grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())

        Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
        frmRepot.rptName = "rptPHIEU_BAO_TRI"

        Dim vtbData As New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptCONG_VIEC_BAO_TRI"))
        vtbData.TableName = "rptCONG_VIEC_BAO_TRI"
        frmRepot.AddDataTableSource(vtbData)
        '---
        vtbData = New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptNHAN_CONG"))
        vtbData.TableName = "rptNHAN_CONG"
        frmRepot.AddDataTableSource(vtbData)
        '---
        vtbData = New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptDICH_VU_THUE_NGOAI"))
        vtbData.TableName = "rptDICH_VU_THUE_NGOAI"
        frmRepot.AddDataTableSource(vtbData)
        '---
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptPHU_TUNG_BAO_TRI"))
        vtbData.TableName = "rptPHU_TUNG_BAO_TRI"
        frmRepot.AddDataTableSource(vtbData)
        '---
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptPHIEU_BAO_TRI"))
        vtbData.TableName = "rptPHIEU_BAO_TRI"
        frmRepot.AddDataTableSource(vtbData)
        '---
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM TB_PHU_TUNG_BAO_TRI"))
        vtbData.TableName = "TB_PHU_TUNG_BAO_TRI"
        frmRepot.AddDataTableSource(vtbData)
        '---
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptDI_CHUYEN_BO_PHAN_BAO_TRI"))
        vtbData.TableName = "rptDI_CHUYEN_BO_PHAN_BAO_TRI"
        frmRepot.AddDataTableSource(vtbData)
        '---
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM TB_VAT_TU_BAO_TRI"))
        vtbData.TableName = "TB_VAT_TU_BAO_TRI"
        frmRepot.AddDataTableSource(vtbData)

        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDePhieuBaoTri"))
        vtbData.TableName = "rptTieuDePhieuBaoTri"
        frmRepot.AddDataTableSource(vtbData)

        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDeDiChuyenBoPhanBaoTri"))
        vtbData.TableName = "rptTieuDeDiChuyenBoPhanBaoTri"
        frmRepot.AddDataTableSource(vtbData)
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDe_VT_BT"))
        vtbData.TableName = "rptTieuDe_VT_BT"
        frmRepot.AddDataTableSource(vtbData)
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDePhuTungBaoTri"))
        vtbData.TableName = "rptTieuDePhuTungBaoTri"
        frmRepot.AddDataTableSource(vtbData)
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDedichvuThueNgoaiBaoTri"))
        vtbData.TableName = "rptTieuDedichvuThueNgoaiBaoTri"
        frmRepot.AddDataTableSource(vtbData)
        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDeNhanCongBaoTri"))
        vtbData.TableName = "rptTieuDeNhanCongBaoTri"
        frmRepot.AddDataTableSource(vtbData)

        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDeCongViecBaoTri"))
        vtbData.TableName = "rptTieuDeCongViecBaoTri"
        frmRepot.AddDataTableSource(vtbData)

        vtbData = New DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTieuDe_PT_BT"))
        vtbData.TableName = "rptTieuDe_PT_BT"
        frmRepot.AddDataTableSource(vtbData)

        frmRepot.ShowDialog()

        Dim str As String = ""

        Me.Cursor = Cursors.Default
    End Sub



    Private Sub txtSO_NGAY_LV_TRONG_TUAN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 55) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtSO_GIO_LV_TRONG_NGAY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub txtGIA_MUA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txtSO_NAM_KHAU_HAO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtTY_LE_CON_LAI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub



    Private Sub txtSO_THANG_BH_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtSO_LUONG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Dim txtBaoTri As TextBox
    Sub HandleKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "." Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub GrdTSGSTT_BP_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        e.Row.Cells("CHU_KY_DO").Value = 0
    End Sub


    Dim cboHC As System.Windows.Forms.ComboBox



#Region "Thông số giám sát tình trạng định lượng"
    Private intRowGSTTDL As Integer = 0
    Sub VisibleButton15(ByVal chon As Boolean)
        BtnThemSua15.Visible = chon
        BtnXoa15.Visible = chon
        BtnThoat15.Visible = chon
        BtnGhi15.Visible = Not chon
        BtnKhongGhi15.Visible = Not chon
        BtnChonthongso15.Visible = Not chon
    End Sub

    Sub ShowThongSoGSTTDL()
        Try
            dtTableThongso = New DataTable
            grdThongsoGSTTDL.DataSource = Nothing
            grdThongsochitiet.DataSource = Nothing
            If grdMay.DataSource Is Nothing Then Exit Sub
            If grvMay.RowCount = 0 Then Exit Sub

        Catch ex As Exception

        End Try
        dtTableThongso.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_CAU_TRUC_THIET_BI_TS_GSTT_DL", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), txtMS_BO_PHAN.Text, Commons.Modules.TypeLanguage))
        ShowThongsoChitiet(-1)
        Dim dt As New DataTable

        dt = dtTableThongso.DefaultView.ToTable(True, "TEN_TS_GSTT", "TEN_DV_DO", "CHU_KY_DO", "MS_DV_TG", "THOI_GIAN", "MS_UU_TIEN", "GHI_CHU", "ACTIVE", "CACH_THUC_HIEN", "TIEU_CHUAN_KT", "YEU_CAU_NS", "YEU_CAU_DUNG_CU", "PATH_HD", "CT_CVIEC", "MS_MAY", "MS_BO_PHAN", "MS_TS_GSTT")


        dtTableThongso.Columns("MS_UU_TIEN").ReadOnly = False
        dtTableThongso.Columns("THOI_GIAN").ReadOnly = False
        dtTableThongso.Columns("CACH_THUC_HIEN").ReadOnly = False
        dtTableThongso.Columns("THOI_GIAN").AllowDBNull = True
        dtTableThongso.Columns("CACH_THUC_HIEN").AllowDBNull = True

        dt.Columns("MS_UU_TIEN").ReadOnly = False
        dt.Columns("THOI_GIAN").ReadOnly = False
        dt.Columns("CACH_THUC_HIEN").ReadOnly = False
        dt.Columns("TIEU_CHUAN_KT").ReadOnly = False
        dt.Columns("YEU_CAU_NS").ReadOnly = False
        dt.Columns("YEU_CAU_DUNG_CU").ReadOnly = False
        dt.Columns("PATH_HD").ReadOnly = False
        dt.Columns("CT_CVIEC").ReadOnly = False




        Commons.Modules.SQLString = "0L0AD"
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongsoGSTTDL, grvThongsoGSTTDL, dt, False, False, False, True, True, "frmThongtinthietbi")
        Commons.Modules.SQLString = ""

        Dim cbo As New Repository.RepositoryItemLookUpEdit()
        cbo.Name = "MS_DV_TG"
        cbo.ValueMember = "MS_DV_TG"
        cbo.DisplayMember = "TEN_DV_TG"
        cbo.NullText = ""
        cbo.DataSource = New MAYController().GetDON_VI_THOI_GIANs
        cbo.PopulateColumns()
        cbo.Columns("MS_DV_TG").Visible = False
        cbo.Columns("TEN_DV_TG").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DV_TG", Commons.Modules.TypeLanguage)

        Me.grvThongsoGSTTDL.Columns("MS_DV_TG").ColumnEdit = cbo


        Dim str As String = " SELECT MS_UU_TIEN, " + If(Commons.Modules.TypeLanguage = 0, " TEN_UU_TIEN ", " TEN_TA ") & " AS TEN_UU_TIEN FROM MUC_UU_TIEN"
        dt = New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

        Dim cboMucUT As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        cboMucUT.Name = "cboMucUT"
        cboMucUT.ValueMember = "MS_UU_TIEN"
        cboMucUT.DisplayMember = "TEN_UU_TIEN"
        cboMucUT.DataSource = dt
        cboMucUT.PopulateColumns()
        'cboMucUT.Columns("MS_UU_TIEN").Visible = False
        cboMucUT.NullText = ""
        grvThongsoGSTTDL.Columns("MS_UU_TIEN").ColumnEdit = cboMucUT



        Try
            grvThongsoGSTTDL.Columns("TEN_TS_GSTT").Width = 200
            grvThongsoGSTTDL.Columns("CHU_KY_DO").Width = 70
            grvThongsoGSTTDL.Columns("GHI_CHU").Width = 150
            grvThongsoGSTTDL.Columns("TEN_DV_DO").Width = 60
            grvThongsoGSTTDL.Columns("MS_DV_TG").Width = 60
            grvThongsoGSTTDL.Columns("CT_CVIEC").Width = 50

            grvThongsoGSTTDL.Columns("MS_MAY").Visible = False
            grvThongsoGSTTDL.Columns("MS_BO_PHAN").Visible = False
            grvThongsoGSTTDL.Columns("MS_TS_GSTT").Visible = False

            grvThongsoGSTTDL.Columns("CACH_THUC_HIEN").Visible = False
            grvThongsoGSTTDL.Columns("TIEU_CHUAN_KT").Visible = False
            grvThongsoGSTTDL.Columns("YEU_CAU_NS").Visible = False
            grvThongsoGSTTDL.Columns("YEU_CAU_DUNG_CU").Visible = False
            grvThongsoGSTTDL.Columns("PATH_HD").Visible = False

            grvThongsoGSTTDL.Columns("TEN_TS_GSTT").OptionsColumn.ReadOnly = True
            grvThongsoGSTTDL.Columns("TEN_DV_DO").OptionsColumn.ReadOnly = True
            grvThongsoGSTTDL.Columns("MS_TT").Visible = False
        Catch ex As Exception
        End Try


        Try
            'Dim column As DevExpress.XtraGrid.Columns.GridColumn = grvCTTB_CV.Columns.AddField("Button")
            Dim btnCTiet As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            btnCTiet.TextEditStyle = TextEditStyles.HideTextEditor
            btnCTiet.Buttons(0).Kind = ButtonPredefines.Glyph
            btnCTiet.Buttons(0).Caption = "..."
            btnCTiet.Buttons(0).Image = Global.Commons.My.Resources.Resources.attachment
            grvThongsoGSTTDL.Columns("CT_CVIEC").ColumnEdit = btnCTiet
            grvThongsoGSTTDL.Columns("CT_CVIEC").Visible = True
            'grvCTTB_CV.Columns("CT_CVIEC").Caption = "..."
            'grvCTTB_CV.Columns.Add(column)
            Try
                Try
                    RemoveHandler btnCTiet.ButtonClick, AddressOf Me.btnCTiet_ButtonClick
                Catch ex As Exception
                End Try
                Try
                    AddHandler btnCTiet.ButtonClick, AddressOf Me.btnCTiet_ButtonClick
                Catch ex As Exception
                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

        grvThongsoGSTTDL_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub TbChiTiet_TableNewRow(ByVal sender As System.Object, ByVal e As DataTableNewRowEventArgs)
        Try
            e.Row("TEN_TS_GSTT") = grvThongsoGSTTDL.GetFocusedDataRow()("TEN_TS_GSTT")
            e.Row("MS_MAY") = grvThongsoGSTTDL.GetFocusedDataRow()("MS_MAY")
            e.Row("MS_BO_PHAN") = grvThongsoGSTTDL.GetFocusedDataRow()("MS_BO_PHAN")
            e.Row("MS_TS_GSTT") = grvThongsoGSTTDL.GetFocusedDataRow()("MS_TS_GSTT")
            e.Row("CHU_KY_DO") = grvThongsoGSTTDL.GetFocusedDataRow()("CHU_KY_DO")
            e.Row("MS_DV_TG") = grvThongsoGSTTDL.GetFocusedDataRow()("MS_DV_TG")
            e.Row("MS_TT") = GetNum(dtTableThongso)
            e.Row("THOI_GIAN") = grvThongsoGSTTDL.GetFocusedDataRow()("THOI_GIAN")
            e.Row("CACH_THUC_HIEN") = grvThongsoGSTTDL.GetFocusedDataRow()("CACH_THUC_HIEN")
            e.Row("MS_UU_TIEN") = grvThongsoGSTTDL.GetFocusedDataRow()("MS_UU_TIEN")
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetNum(ByVal dt As DataTable) As Integer
        Dim index As Integer = 0
        For Each row As DataRow In dt.Select("MS_TT IS NOT NULL")
            If index < row("MS_TT") Then
                index = row("MS_TT")
            End If
        Next
        Return index + 1
    End Function

    Private Sub ShowThongsoChitiet(ByVal row As Integer)
        Try
            If row >= 0 Then
                AddHandler dtTableThongso.TableNewRow, AddressOf TbChiTiet_TableNewRow

                dtTableThongso.DefaultView.RowFilter = "MS_TS_GSTT='" + grvThongsoGSTTDL.GetFocusedDataRow()("MS_TS_GSTT").ToString() + "' AND GIA_TRI_TREN IS NOT NULL AND GIA_TRI_DUOI IS NOT NULL"
            End If
            Dim dt As New DataTable
            dt = dtTableThongso.DefaultView.ToTable
            dt.Columns("TEN_TS_GSTT").AllowDBNull = True
            dt.Columns("MS_MAY").AllowDBNull = True
            dt.Columns("MS_BO_PHAN").AllowDBNull = True
            dt.Columns("MS_TS_GSTT").AllowDBNull = True
            dt.Columns("ACTIVE").AllowDBNull = True
            dt.Columns("MS_DV_TG").AllowDBNull = True
            dt.Columns("MS_TT").AllowDBNull = True
            dt.Columns("GHI_CHU").AllowDBNull = True
            dt.Columns("CHU_KY_DO").AllowDBNull = True
            dt.Columns("TEN_DV_DO").AllowDBNull = True
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongsochitiet, grvThongsochitiet, dt, False, True, True, True, True, "frmThongtinthietbi")

            grvThongsochitiet.Columns("ACTIVE").Visible = False
            grvThongsochitiet.Columns("MS_MAY").Visible = False
            grvThongsochitiet.Columns("MS_BO_PHAN").Visible = False
            grvThongsochitiet.Columns("MS_TS_GSTT").Visible = False
            grvThongsochitiet.Columns("MS_DV_TG").Visible = False
            grvThongsochitiet.Columns("MS_TT").Visible = False
            grvThongsochitiet.Columns("TEN_TS_GSTT").Visible = False
            grvThongsochitiet.Columns("TEN_GT").Visible = True
            grvThongsochitiet.Columns("GIA_TRI_TREN").Visible = True
            grvThongsochitiet.Columns("GIA_TRI_TREN").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            grvThongsochitiet.Columns("GIA_TRI_DUOI").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            grvThongsochitiet.Columns("GIA_TRI_DUOI").Visible = True
            grvThongsochitiet.Columns("DAT").Visible = True
            grvThongsochitiet.Columns("GHI_CHU").Visible = False
            grvThongsochitiet.Columns("CHU_KY_DO").Visible = False
            grvThongsochitiet.Columns("THOI_GIAN").Visible = False
            grvThongsochitiet.Columns("CACH_THUC_HIEN").Visible = False
            grvThongsochitiet.Columns("TEN_DV_DO").Visible = False
            grvThongsochitiet.Columns("MS_UU_TIEN").Visible = False
            grvThongsochitiet.Columns("MS_UU_TIEN1").Visible = False
            grvThongsochitiet.Columns("TEN_GT").Width = 250
            grvThongsochitiet.Columns("DAT").Width = grvThongsochitiet.Columns("GIA_TRI_TREN").Width


            grvThongsochitiet.Columns("TIEU_CHUAN_KT").Visible = False
            grvThongsochitiet.Columns("YEU_CAU_NS").Visible = False
            grvThongsochitiet.Columns("YEU_CAU_DUNG_CU").Visible = False
            grvThongsochitiet.Columns("PATH_HD").Visible = False
            grvThongsochitiet.Columns("CT_CVIEC").Visible = False
            'Dim str As String = " SELECT MS_UU_TIEN, " + If(Commons.Modules.TypeLanguage = 0, " TEN_UU_TIEN ", " TEN_TA ") & " AS TEN_UU_TIEN FROM MUC_UU_TIEN"
            'dt = New DataTable()
            'dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            'Dim cboMucUT As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            'cboMucUT.Name = "cboMucUT"
            'cboMucUT.ValueMember = "MS_UU_TIEN"
            'cboMucUT.DisplayMember = "TEN_UU_TIEN"
            'cboMucUT.DataSource = dt
            'cboMucUT.PopulateColumns()
            ''cboMucUT.Columns("MS_UU_TIEN").Visible = False
            'cboMucUT.NullText = ""
            'grvThongsoGSTTDL.Columns("MS_UU_TIEN1").ColumnEdit = cboMucUT
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnChonthongso15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonthongso15.Click
        Dim fPT As New frmChonthongsoGSTT_BP()
        fPT.MS_MAY = ucDMTBi.txtMS_MAY.Text
        fPT.LOAI_TS = False
        fPT.MS_BO_PHAN = txtMS_BO_PHAN.Text
        fPT.ATTACHMENT = False
        fPT.DtThongso = grdThongsoGSTTDL.DataSource
        fPT.Size = New Size(900, 600)
        Dim dtNew As New DataTable
        If fPT.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim dt As DataTable = fPT.dtChonTS
            If (dt.Rows.Count = 0) Then Exit Sub
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("CHON").Equals(True) Then
                    Dim drNew As DataRow = dtTableThongso.NewRow
                    drNew("MS_MAY") = ucDMTBi.txtMS_MAY.Text
                    drNew("MS_BO_PHAN") = txtMS_BO_PHAN.Text
                    drNew("MS_TS_GSTT") = dt.Rows(i)("MS_TS_GSTT")
                    drNew("MS_TT") = GetNum(dtTableThongso)
                    drNew("CHU_KY_DO") = DBNull.Value
                    drNew("MS_DV_TG") = DBNull.Value
                    drNew.Item("TEN_DV_DO") = dt.Rows(i)("TEN_DV_DO")
                    drNew.Item("TEN_TS_GSTT") = dt.Rows(i)("TEN_TS_GSTT")
                    drNew.Item("ACTIVE") = True
                    drNew.Item("THOI_GIAN") = dt.Rows(i)("THOI_GIAN")
                    drNew.Item("CACH_THUC_HIEN") = dt.Rows(i)("CACH_THUC_HIEN")
                    drNew.Item("TIEU_CHUAN_KT") = dt.Rows(i)("TIEU_CHUAN_KT")
                    drNew.Item("YEU_CAU_NS") = dt.Rows(i)("YEU_CAU_NS")
                    drNew.Item("YEU_CAU_DUNG_CU") = dt.Rows(i)("YEU_CAU_DUNG_CU")
                    drNew.Item("PATH_HD") = dt.Rows(i)("DUONG_DAN")
                    drNew.Item("MS_UU_TIEN") = 2
                    dtTableThongso.Rows.Add(drNew)
                End If
            Next
            dtTableThongso.DefaultView.RowFilter = ""
            dt = New DataTable
            dt = dtTableThongso.DefaultView.ToTable(True, "TEN_TS_GSTT", "TEN_DV_DO", "CHU_KY_DO", "MS_DV_TG", "THOI_GIAN", "MS_UU_TIEN", "GHI_CHU", "ACTIVE", "CACH_THUC_HIEN", "TIEU_CHUAN_KT", "YEU_CAU_NS", "YEU_CAU_DUNG_CU", "PATH_HD", "CT_CVIEC", "MS_MAY", "MS_BO_PHAN", "MS_TS_GSTT")
            grdThongsoGSTTDL.DataSource = dt
            grvThongsoGSTTDL.Columns("TEN_TS_GSTT").Width = 200
            grvThongsoGSTTDL.Columns("CHU_KY_DO").Width = 70
            grvThongsoGSTTDL.Columns("GHI_CHU").Width = 150
            grvThongsoGSTTDL.Columns("TEN_DV_DO").Width = 60
            grvThongsoGSTTDL.Columns("MS_DV_TG").Width = 60
            grvThongsoGSTTDL.Columns("CT_CVIEC").Width = 50

        End If
    End Sub
    '

    Private Sub BtnThemSua15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThemSua15.Click
        If txtMS_BO_PHAN.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT26", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        VisibleButton15(False)
        HideButtonSub(True)
        LockControlSub(True)
        grvThongsoGSTTDL.OptionsBehavior.Editable = True
        grvThongsochitiet.OptionsBehavior.Editable = True
        grvThongsochitiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        grvThongsochitiet.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

    End Sub

    Private Sub BtnThoat15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat15.Click
        blnThoat = True
        Try
            Me.Controls.Clear()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnKhongGhi15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongGhi15.Click
        VisibleButton15(True)
        HideButtonSub(False)

        LockControlSub(False)
        ObjectEnable(False)
        ShowThongSoGSTTDL()
        grvThongsochitiet.OptionsBehavior.Editable = False
        grvThongsochitiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        grvThongsochitiet.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub BtnGhi15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi15.Click
        Try
            Dim sSql As String = ""

            If BtnThemSua15.Visible = False Then
                For i As Integer = 0 To grvThongsoGSTTDL.RowCount - 1
                    If grvThongsoGSTTDL.GetDataRow(i)("MS_DV_TG").ToString().Equals(String.Empty) Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDonvithoigiantrong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        If grvThongsoGSTTDL.GetDataRow(i)("CHU_KY_DO").ToString().Equals(String.Empty) Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChukydotrong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                Next

                dtTableThongso.DefaultView.Sort = "GIA_TRI_DUOI ASC"
                For ts As Integer = 0 To grvThongsoGSTTDL.RowCount - 1
                    Dim dtTmp() As DataRow
                    dtTmp = dtTableThongso.Select("GIA_TRI_TREN is not null and GIA_TRI_DUOI is not null AND TEN_GT IS NOT NULL and MS_TS_GSTT='" + grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString() + "'", "GIA_TRI_TREN")
                    If dtTmp.Length > 1 Then
                        For i As Integer = 1 To dtTmp.Length - 1
                            If dtTmp(i - 1)("TEN_GT").ToString().Equals(dtTmp(i)("TEN_GT").ToString()) Then
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTengiatritrung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'grdThongsochitiet.Sort(grdThongsochitiet.Columns("GIA_TRI_DUOI"), System.ComponentModel.ListSortDirection.Ascending)
                                For j As Integer = 0 To grvThongsochitiet.RowCount
                                    Try
                                        If grvThongsochitiet.GetDataRow(j)("MS_TT") = dtTmp(i)("MS_TT") Then
                                            grvThongsochitiet.FocusedRowHandle = j
                                            Exit Sub
                                        End If
                                    Catch ex As Exception
                                        Exit Sub
                                    End Try
                                Next
                            End If
                            If Double.Parse(dtTmp(i - 1)("GIA_TRI_TREN").ToString) > Double.Parse(dtTmp(i)("GIA_TRI_DUOI").ToString) Then
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhoanggiatrisai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                For j As Integer = 0 To grvThongsochitiet.RowCount - 1
                                    If grvThongsochitiet.GetDataRow(j)("MS_TT") = dtTmp(i)("MS_TT") Then
                                        grdThongsochitiet.Focus()

                                        If (i = 0) Then Exit Sub
                                        grvThongsochitiet.FocusedRowHandle = i - 1
                                        Exit Sub
                                    End If
                                Next
                            End If
                        Next
                    ElseIf dtTmp.Length > 0 Then
                        If Double.Parse(dtTmp(0)("GIA_TRI_DUOI").ToString) > Double.Parse(dtTmp(0)("GIA_TRI_TREN").ToString) Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhoanggiatrisai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            grvThongsochitiet.FocusedRowHandle = 0
                            Exit Sub
                        End If

                    Else
                        'khong co gia tri nao
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongcogiatrinao", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        grdThongsochitiet.Focus()
                        Exit Sub
                    End If
                Next
                Dim sqlTran As SqlTransaction
                Dim conn As New SqlConnection(Commons.IConnections.ConnectionString)
                conn.Open()
                sqlTran = conn.BeginTransaction()
                Try
                    Dim filter As String = ""
                    'lay table
                    Dim dtThongsotmp As New DataTable
                    dtThongsotmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_CAU_TRUC_THIET_BI_TS_GSTT", grvMay.GetFocusedRowCellValue("MS_MAY").ToString(), txtMS_BO_PHAN.Text, Commons.Modules.TypeLanguage, 0))



                    For ts As Integer = 0 To grvThongsoGSTTDL.RowCount - 1

                        'xoa nhung row da bi xoa
                        For Each rw As DataRow In dtThongsotmp.Rows
                            filter = "GIA_TRI_TREN is not null and GIA_TRI_DUOI is not null AND TEN_GT IS NOT NULL and MS_TT=" + rw("MS_TT").ToString() + " and MS_TS_GSTT='" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString & "'"
                            If dtTableThongso.Select(filter).Length <= 0 Then
                                sSql = "DELETE FROM CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "' AND MS_TS_GSTT='" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString & "' and MS_TT=" + rw("MS_TT").ToString
                                Dim re As Integer = SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, sSql)
                            End If
                        Next
                        'update nhung row con ton tai
                        For Each rw As DataRow In dtTableThongso.Select("GIA_TRI_TREN is not null and GIA_TRI_DUOI is not null AND TEN_GT IS NOT NULL and MS_TS_GSTT='" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString & "'")
                            filter = "GIA_TRI_TREN is not null and GIA_TRI_DUOI is not null AND TEN_GT IS NOT NULL and MS_TT=" + rw("MS_TT").ToString() + " and MS_TS_GSTT='" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString & "'"
                            If rw("MS_TS_GSTT").ToString().Equals(grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString) And dtThongsotmp.Select(filter).Length > 0 Then
                                Dim sLuu As String = ""
                                Try
                                    If IO.File.Exists(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString()) Then
                                        If Commons.Modules.ObjSystems.LayDuoiFile(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString()) = "." Then
                                            sLuu = ""
                                        Else
                                            Dim strduongDanTmp As String = Commons.Modules.ObjSystems.CapnhatTL(True, "MAY-GSDL")
                                            sLuu = (strduongDanTmp & Convert.ToString("\")) + ucDMTBi.txtMS_MAY.Text & "-" & txtMS_BO_PHAN.Text & "-" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString() + Commons.Modules.ObjSystems.LayDuoiFile(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString())
                                            Commons.Modules.ObjSystems.LuuDuongDan(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString(), sLuu)
                                        End If
                                    End If
                                Catch ex As Exception
                                    sLuu = ""
                                End Try
                                Dim stt As String = rw("TEN_GT").ToString
                                Dim ms As String = grvThongsoGSTTDL.GetDataRow(ts)("MS_DV_TG")
                                Dim _active As String = grvThongsoGSTTDL.GetDataRow(ts)("ACTIVE")
                                Dim re As Integer = SqlHelper.ExecuteNonQuery(sqlTran, "UpdateCAU_TRUC_THIET_BI_TS_GSTT", ucDMTBi.txtMS_MAY.Text, txtMS_BO_PHAN.Text, grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT"), rw("MS_TT").ToString, rw("TEN_GT").ToString, rw("GIA_TRI_TREN").ToString, rw("GIA_TRI_DUOI").ToString, grvThongsoGSTTDL.GetDataRow(ts)("CHU_KY_DO"), grvThongsoGSTTDL.GetDataRow(ts)("MS_DV_TG"), rw("DAT"), grvThongsoGSTTDL.GetDataRow(ts)("MS_UU_TIEN"), grvThongsoGSTTDL.GetDataRow(ts)("GHI_CHU"), _active, grvThongsoGSTTDL.GetDataRow(ts)("THOI_GIAN"), grvThongsoGSTTDL.GetDataRow(ts)("CACH_THUC_HIEN"),
                                    grvThongsoGSTTDL.GetDataRow(ts)("TIEU_CHUAN_KT"), grvThongsoGSTTDL.GetDataRow(ts)("YEU_CAU_NS"), grvThongsoGSTTDL.GetDataRow(ts)("YEU_CAU_DUNG_CU"), IIf(String.IsNullOrEmpty(sLuu), Nothing, sLuu))
                            End If
                        Next

                        'add nhung row chua co
                        For Each rw As DataRow In dtTableThongso.Select("GIA_TRI_TREN is not null and GIA_TRI_DUOI is not null AND TEN_GT IS NOT NULL and MS_TS_GSTT='" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString & "'")
                            filter = "MS_TT=" + rw("MS_TT").ToString() + " and MS_TS_GSTT='" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString & "'"
                            If dtThongsotmp.Select(filter).Length <= 0 Then
                                Dim _active As String = grvThongsoGSTTDL.GetDataRow(ts)("ACTIVE").ToString()

                                Dim sLuu As String = ""
                                Try
                                    If IO.File.Exists(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString()) Then
                                        If Commons.Modules.ObjSystems.LayDuoiFile(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString()) = "." Then
                                            sLuu = ""
                                        Else
                                            Dim strduongDanTmp As String = Commons.Modules.ObjSystems.CapnhatTL(True, "MAY-GSDL")
                                            sLuu = (strduongDanTmp & Convert.ToString("\")) + ucDMTBi.txtMS_MAY.Text & "-" & txtMS_BO_PHAN.Text & "-" & grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT").ToString() + Commons.Modules.ObjSystems.LayDuoiFile(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString())
                                            Commons.Modules.ObjSystems.LuuDuongDan(grvThongsoGSTTDL.GetDataRow(ts)("PATH_HD").ToString(), sLuu)
                                        End If
                                    End If
                                Catch ex As Exception
                                    sLuu = ""
                                End Try
                                Dim re As Integer = SqlHelper.ExecuteScalar(sqlTran, "AddCAU_TRUC_THIET_BI_TS_GSTT", ucDMTBi.txtMS_MAY.Text, txtMS_BO_PHAN.Text, grvThongsoGSTTDL.GetDataRow(ts)("MS_TS_GSTT"), rw("MS_TT").ToString, rw("TEN_GT").ToString, rw("GIA_TRI_TREN").ToString, rw("GIA_TRI_DUOI").ToString, grvThongsoGSTTDL.GetDataRow(ts)("CHU_KY_DO"), grvThongsoGSTTDL.GetDataRow(ts)("MS_DV_TG"), 0, rw("DAT"), grvThongsoGSTTDL.GetDataRow(ts)("MS_UU_TIEN"), grvThongsoGSTTDL.GetDataRow(ts)("GHI_CHU"), _active, grvThongsoGSTTDL.GetDataRow(ts)("THOI_GIAN"), grvThongsoGSTTDL.GetDataRow(ts)("CACH_THUC_HIEN"),
                                    grvThongsoGSTTDL.GetDataRow(ts)("TIEU_CHUAN_KT"), grvThongsoGSTTDL.GetDataRow(ts)("YEU_CAU_NS"), grvThongsoGSTTDL.GetDataRow(ts)("YEU_CAU_DUNG_CU"), IIf(String.IsNullOrEmpty(sLuu), Nothing, sLuu))
                            End If
                        Next
                    Next
                    sqlTran.Commit()
                Catch ex As Exception
                    sqlTran.Rollback()
                End Try
                conn.Close()
                VisibleButton15(True)
                HideButtonSub(False)
                LockControlSub(False)
                ObjectEnable(False)
                ShowThongSoGSTTDL()
                grvThongsochitiet.OptionsBehavior.Editable = False
                grvThongsochitiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                grvThongsochitiet.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub BtnXoa15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa15.Click
        If grvThongsoGSTTDL.RowCount <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT39", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim sMSS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT50", Commons.Modules.TypeLanguage)
        If XtraMessageBox.Show(sMSS, "Vietsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        Dim sqlTran As SqlTransaction
        Dim conn As New SqlConnection(Commons.IConnections.ConnectionString)
        conn.Open()
        sqlTran = conn.BeginTransaction()
        Dim sSql As String = ""
        Try
            For i As Integer = 0 To grvThongsochitiet.RowCount - 1
                sSql = "SELECT * FROM GIAM_SAT_TINH_TRANG_TS WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_BO_PHAN = '" & txtMS_BO_PHAN.Text & "' AND MS_TS_GSTT = '" & grvThongsoGSTTDL.GetFocusedDataRow()("MS_TS_GSTT") & "' and MS_TT=" & grvThongsochitiet.GetDataRow(i)("MS_TT").ToString
                Dim dtreader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

                While dtreader.Read
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_xoa_TSGSTT_BP", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dtreader.Close()
                    Exit Sub
                End While
                dtreader.Close()
                sSql = "DELETE FROM CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_BO_PHAN='" & txtMS_BO_PHAN.Text & "' AND MS_TS_GSTT='" & grvThongsoGSTTDL.GetFocusedDataRow()("MS_TS_GSTT") & "' and MS_TT=" & grvThongsochitiet.GetDataRow(i)("MS_TT").ToString
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, sSql)
            Next
            sqlTran.Commit()
        Catch ex As Exception
            sqlTran.Rollback()
        End Try
        conn.Close()
        ShowThongSoGSTTDL()
    End Sub
#End Region

#Region "OTHER"


    Dim intTab11 As Integer, intTab15 As Integer
    Dim intTab12 As Integer, intTab13 As Integer, intTab14 As Integer
    Private Sub grdThongtinPT_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        intTab11 = e.RowIndex
    End Sub

    Private Sub grvCTTB_CV_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        intTab12 = e.RowIndex
    End Sub

    Private Sub GrdTSGSTT_BP_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        intTab13 = e.RowIndex
    End Sub

    Private Sub grdThongsoBP_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        intTab14 = e.RowIndex
    End Sub

    Private Sub grdThongsoGSTTDL_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        intTab15 = e.RowIndex
    End Sub
    Dim intTab21 As Integer, intTab31 As Integer, intTab41 As Integer, intTab42 As Integer




    Private Sub txtMS_BO_PHAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        txtMS_BO_PHAN.Text = Commons.clsXuLy.LocBoDau(txtMS_BO_PHAN.Text)
        If BtnGhi4.Visible = True Then txtMS_BO_PHAN.Text = Commons.clsXuLy.LocBoDau(txtMS_BO_PHAN.Text)
    End Sub

    Private Sub TxtHINH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtHINH.SelectAll()
    End Sub

    Private Sub InRptLichSuPT()

        If Tabthietbi.SelectedTabPageIndex = 1 And BtnThemSuaPT.Visible = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim vMS_MAY As String = ""
            Dim vMs_Bp As String = ""
            Dim vMs_Pt As String = ""
            Dim vTen_pT As String = ""
            Try
                vMS_MAY = ucDMTBi.txtMS_MAY.Text.Trim()
                If Tabthietbi.SelectedTabPageIndex = 1 Then
                    vMs_Bp = txtMS_BO_PHAN.Text.Trim()
                    vMs_Pt = grvCTTB_PT.GetFocusedDataRow()("MS_PT").ToString().Trim()
                    vTen_pT = grvCTTB_PT.GetFocusedDataRow()("TEN_PT").ToString().Trim()
                End If
                If Tabthietbi.SelectedTabPageIndex = 5 Then
                    vMs_Bp = grvLichSuMay.GetFocusedDataRow()("MS_BO_PHAN").ToString().Trim() 'grvLichSuMay.Columns("MS_BO_PHAN").ToString
                    vMs_Pt = grvLichSuPTTThe.GetFocusedDataRow()("MS_PT").ToString().Trim()
                    vTen_pT = ""
                End If
            Catch ex As Exception
            End Try

            Dim ds As DataSet = New DataSet()
            Dim dtPT As DataTable = New DataTable()
            Dim SD_KHO As Boolean = Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho)
            dtPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_LICH_SU_PT", SD_KHO, vMS_MAY, vMs_Bp, vMs_Pt))
            dtPT.TableName = "TB_LICH_SU_PT"
            GetPTCha(SD_KHO, dtPT, vMs_Pt, vMS_MAY, vMs_Bp)
            If dtPT.Rows.Count = 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_CO_DL_IN", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim tbThongTinChung As DataTable = New DataTable()
            Dim str As String = "SELECT * FROM THONG_TIN_CHUNG"
            tbThongTinChung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            tbThongTinChung.TableName = "rpt_Thong_Tin_Chung"
            Dim vSort As DataView = New DataView(dtPT, "", "MS_VI_TRI_PT,NGAY_THAY_THE DESC", DataViewRowState.CurrentRows)
            dtPT = vSort.ToTable()
            dtPT.Columns("THOI_GIAN_SU_DUNG").ReadOnly = False
            dtPT.Columns("THOI_GIAN_SU_DUNG").AllowDBNull = True
            For i As Integer = dtPT.Rows.Count - 1 To 0 Step -1
                Dim vRow As DataRow = dtPT.Rows(i)
                If (i > 0) Then
                    Dim vRowNext As DataRow = dtPT.Rows(i - 1)
                    If vRow("MS_VI_TRI_PT").ToString().Trim().Equals(vRowNext("MS_VI_TRI_PT")) Then
                        Try
                            vRow("THOI_GIAN_SU_DUNG") = Convert.ToDateTime(vRowNext("NGAY_THAY_THE")).ToOADate() - Convert.ToDateTime(vRow("NGAY_THAY_THE")).ToOADate()
                        Catch ex As Exception

                        End Try
                    End If

                End If
                If i = 0 Then
                    vRow("THOI_GIAN_SU_DUNG") = DBNull.Value
                End If
            Next

            Dim dt As New DataTable()
            dt.TableName = "rptTIEU_DE_LICH_SU_PT"
            dt.Columns.Add("TIEU_DE")
            dt.Columns.Add("MAY")
            dt.Columns.Add("BO_PHAN")
            dt.Columns.Add("PHU_TUNG")
            dt.Columns.Add("NGAY_THAY_THE")
            dt.Columns.Add("PT_SD")
            dt.Columns.Add("SL_TT")
            dt.Columns.Add("NGUOI_THAY")
            dt.Columns.Add("MS_PHIEU_BAO_TRI")
            dt.Columns.Add("THAY_PT_CHA")
            dt.Columns.Add("XUAT_XU")
            dt.Columns.Add("GHI_CHU")
            dt.Columns.Add("TUOI_THO")
            dt.Columns.Add("VI_TRI")
            dt.Columns.Add("TUOI_THO_TB")
            Dim rDt As DataRow = dt.NewRow()

            rDt("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "TIEU_DE", Commons.Modules.TypeLanguage)
            rDt("MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "MAY", Commons.Modules.TypeLanguage)
            rDt("BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "BO_PHAN", Commons.Modules.TypeLanguage)
            rDt("PHU_TUNG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "PHU_TUNG", Commons.Modules.TypeLanguage)
            rDt("NGAY_THAY_THE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "NGAY_THAY_THE", Commons.Modules.TypeLanguage)
            rDt("PT_SD") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "PT_SD", Commons.Modules.TypeLanguage)
            rDt("SL_TT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "SL_TT", Commons.Modules.TypeLanguage)
            rDt("NGUOI_THAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "NGUOI_THAY", Commons.Modules.TypeLanguage)
            rDt("MS_PHIEU_BAO_TRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
            rDt("THAY_PT_CHA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "THAY_PT_CHA", Commons.Modules.TypeLanguage)
            rDt("XUAT_XU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "XUAT_XU", Commons.Modules.TypeLanguage)
            rDt("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "GHI_CHU", Commons.Modules.TypeLanguage)
            rDt("TUOI_THO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "TUOI_THO", Commons.Modules.TypeLanguage)
            rDt("VI_TRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "VI_TRI", Commons.Modules.TypeLanguage)
            rDt("TUOI_THO_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "TUOI_THO_TB", Commons.Modules.TypeLanguage)
            dt.Rows.Add(rDt)

            Dim frmShow As frmShowXMLReport = New frmShowXMLReport()
            frmShow.AddDataTableSource(dt)
            frmShow.AddDataTableSource(dtPT)
            frmShow.AddDataTableSource(tbThongTinChung)
            frmShow.rptName = "rpt_Lich_Su_PT"
            frmShow.ShowDialog(Me)

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub InLichSuPT()
        If Tabthietbi.SelectedTabPageIndex = 1 And BtnThemSuaPT.Visible = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim vMS_MAY As String = ""
            Dim vMs_Bp As String = ""
            Dim vMs_Pt As String = ""
            Dim vTen_pT As String = ""
            Try
                vMS_MAY = ucDMTBi.txtMS_MAY.Text.Trim()
                If Tabthietbi.SelectedTabPageIndex = 1 Then
                    vMs_Bp = txtMS_BO_PHAN.Text.Trim()
                    vMs_Pt = grvCTTB_PT.GetFocusedDataRow()("MS_PT").ToString().Trim()
                    vTen_pT = grvCTTB_PT.GetFocusedDataRow()("TEN_PT").ToString().Trim()
                End If
                If Tabthietbi.SelectedTabPageIndex = 5 Then
                    vMs_Bp = grvLichSuMay.GetFocusedDataRow()("MS_BO_PHAN").ToString().Trim() 'grvLichSuMay.Columns("MS_BO_PHAN").ToString
                    vMs_Pt = grvLichSuPTTThe.GetFocusedDataRow()("MS_PT").ToString().Trim()
                    vTen_pT = ""
                End If
            Catch ex As Exception
            End Try

            Dim ds As DataSet = New DataSet()
            Dim dtPT As DataTable = New DataTable()
            Dim SD_KHO As Boolean = Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho)
            dtPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_LICH_SU_VTPT", vMS_MAY, vMs_Bp, vMs_Pt))
            GetPTCha(SD_KHO, dtPT, vMs_Pt, vMS_MAY, vMs_Bp)
            ''nếu không có dữ liệu thì exit ngược lại cập nhật thời gian sử dụng
            If dtPT.Rows.Count = 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_CO_DL_IN", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                dtPT.Columns("THOI_GIAN_SU_DUNG").ReadOnly = False
                dtPT.Columns("THOI_GIAN_SU_DUNG").AllowDBNull = True
                For i As Integer = dtPT.Rows.Count - 1 To 0 Step -1
                    Dim vRow As DataRow = dtPT.Rows(i)
                    If (i > 0) Then
                        Dim vRowNext As DataRow = dtPT.Rows(i - 1)
                        If vRow("MS_VI_TRI_PT").ToString().Trim().Equals(vRowNext("MS_VI_TRI_PT")) Then
                            Try
                                vRow("THOI_GIAN_SU_DUNG") = Convert.ToInt32(Convert.ToDateTime(vRowNext("NGAY_THAY_THE")).ToOADate() - Convert.ToDateTime(vRow("NGAY_THAY_THE")).ToOADate())
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                    If i = 0 Then
                        vRow("THOI_GIAN_SU_DUNG") = DBNull.Value
                    End If
                Next
            End If
            GrdChungPT.DataSource = Nothing
            Commons.Modules.ObjSystems.MLoadXtraGrid(GrdChungPT, GrvChung1, dtPT, False, True, False, True, True, "frmThongtinthietbi")
            GrvChung1.Columns("MAY").Visible = False
            GrvChung1.Columns("TEN_BO_PHAN").Visible = False
            'GrvChung.Columns("NGAY_MUA").Visible = False
            GrvChung1.Columns("MS_PTTT").Visible = False
            GrvChung1.Columns("TEN_PT").Visible = False
            GrvChung1.Columns("TEN_BO_PHAN").Visible = False
            GrvChung1.Columns("MS_VI_TRI_PT").GroupIndex = 0
            GrvChung1.Columns("NGAY_THAY_THE").VisibleIndex = 0
            GrvChung1.Columns("NGAY_MUA").VisibleIndex = 1
            GrvChung1.Columns("PHU_TUNG").VisibleIndex = 2
            GrvChung1.Columns("SL_TT").VisibleIndex = 3
            GrvChung1.Columns("NGUOI_THAY").VisibleIndex = 4
            GrvChung1.Columns("MS_PHIEU_BAO_TRI").VisibleIndex = 5
            GrvChung1.Columns("PT_CHA").VisibleIndex = 6
            GrvChung1.Columns("XUAT_XU").VisibleIndex = 7
            GrvChung1.Columns("MS_DH_NHAP_PT").VisibleIndex = 8
            GrvChung1.Columns("BAO_HANH_DEN_NGAY").VisibleIndex = 9
            GrvChung1.Columns("TEN_CONG_TY").VisibleIndex = 10
            GrvChung1.Columns("DON_GIA").VisibleIndex = 11
            GrvChung1.Columns("GHI_CHU").VisibleIndex = 12
            GrvChung1.Columns("THOI_GIAN_SU_DUNG").VisibleIndex = 13
            InDuLieuPT(dtPT)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub InLichSuMH()
        Dim tab As New DataTable
        GrdChungMH.DataSource = Nothing
        tab.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGet_LICH_SU_MUA_HANG", grvCTTB_PT.GetFocusedRowCellValue("MS_PT")))
        Commons.Modules.ObjSystems.MLoadXtraGrid(GrdChungMH, GrvChungMH, tab, False, False, False, True, True, "frmThongtinthietbi")
        GrvChungMH.Columns("DON_GIA").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
        GrvChungMH.Columns("DON_GIA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GrvChungMH.Columns("THANH_TIENVND").DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT)
        GrvChungMH.Columns("THANH_TIENVND").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        If tab.Rows.Count = 0 Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucDSBaoTri", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
            Return
        End If

        InDuLieuMH(tab)
    End Sub
    Private Sub InDuLieuMH(ByVal dtTmp As DataTable)
        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
        If sPath = "" Then Return
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As Excel.Application = New Excel.Application()

        Try
            Dim TCot As Integer = dtTmp.Columns.Count
            Dim TDong As Integer = dtTmp.Rows.Count
            Dim Dong As Integer = 1
            GrdChungMH.ExportToXls(sPath)

            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)
            excelApplication.Cells.Font.Name = "Tahoma"
            excelApplication.Cells.Font.Size = 8
            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "TieuDeLichSuMuaHang", Commons.Modules.TypeLanguage).ToUpper(), Dong, 1, "@", 16, True, (Excel.XlHAlign.xlHAlignCenter), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1)
            title.RowHeight = 28

            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "ThietBi", Commons.Modules.TypeLanguage) & " :", Dong, 2, "@", 8, True, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, 2)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "-" & grvMay.GetFocusedRowCellValue("TEN_MAY").ToString(), Dong, 3, "@", 10, False, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)
            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "BoPhan", Commons.Modules.TypeLanguage) & " :", Dong, 2, "@", 8, True, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, 2)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, txtMS_BO_PHAN.Text & "-" & txtTEN_BO_PHAN.Text, Dong, 3, "@", 10, False, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)
            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "lbPhuTung", Commons.Modules.TypeLanguage) & " :", Dong, 2, "@", 8, True, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, 2)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, grvCTTB_PT.GetFocusedRowCellValue("MS_PT").ToString() & "-" & grvCTTB_PT.GetFocusedRowCellValue("TEN_PT").ToString(), Dong, 3, "@", 10, False, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

            excelApplication.ActiveWindow.DisplayGridlines = True
            excelWorkSheet.Columns.AutoFit()



            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, Dong + TDong, TCot)
            title.ColumnWidth = 12


            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 3, Dong + TDong, 3)
            title.ColumnWidth = 45




            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16, "#,##0", True, Dong + 1, TCot - 1, Dong + TDong, TCot)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "#,##0", True, Dong + 1, 4, Dong + TDong, 5)


            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong - 3)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 3, 1, Dong - 3, 1)
            title.RowHeight = 9

            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong - 1)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 9

            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong + 3)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 3, 1, Dong + 3, 1)
            title.RowHeight = 9

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 4, 1, Dong + TDong + 4, TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 4, 1, Dong + 4, TCot)
            title.Font.Bold = True
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            excelWorkbook.Save()
            excelApplication.Visible = True

            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        Catch ex As Exception
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) & vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Me.Cursor = Cursors.[Default]
    End Sub
    Private Sub InDuLieuPT(ByVal dtTmp As DataTable)
        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx")
        If sPath = "" Then Return
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As Excel.Application = New Excel.Application()
        Try
            Dim TCot As Integer = dtTmp.Columns.Count - 4
            Dim TDong As Integer = dtTmp.Rows.Count
            Dim Dong As Integer = 1
            GrdChungPT.ExportToXlsx(sPath)

            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)
            excelApplication.Cells.Font.Name = "Tahoma"
            excelApplication.Cells.Font.Size = 8
            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 4, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, True, (Excel.XlHAlign.xlHAlignCenter), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)
            'excelApplication.Visible = True
            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "ThietBi", Commons.Modules.TypeLanguage) & " :", Dong, 3, "@", 8, True, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, 3)

            Commons.Modules.MExcel.DinhDang(excelWorkSheet, grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "-" & grvMay.GetFocusedRowCellValue("TEN_MAY").ToString(), Dong, 4, "@", 10, False, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)
            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "BoPhan", Commons.Modules.TypeLanguage) & " :", Dong, 3, "@", 8, True, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, 3)

            Commons.Modules.MExcel.DinhDang(excelWorkSheet, txtMS_BO_PHAN.Text & "-" & txtTEN_BO_PHAN.Text, Dong, 4, "@", 10, False, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)
            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "lbPhuTung", Commons.Modules.TypeLanguage) & " :", Dong, 3, "@", 8, True, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, 3)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, grvCTTB_PT.GetFocusedRowCellValue("MS_PT").ToString() & "-" & grvCTTB_PT.GetFocusedRowCellValue("TEN_PT").ToString(), Dong, 4, "@", 10, False, (Excel.XlHAlign.xlHAlignLeft), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

            Dong += 3

            Commons.Modules.MExcel.MFuntion(excelWorkSheet, "AVERAGE", Dong + TDong + 1, TCot, Dong + TDong + 1, TCot,
                Dong, TCot, Dong + TDong, TCot, 8, False, 10, 0)
            'excelApplication.Visible = True
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong + 1, TCot, Dong + TDong + 1, TCot)
            title.Value2 = title.Value.ToString & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "NgayCuoi", Commons.Modules.TypeLanguage)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rpt_LICH_SU_PT", "TUOI_THO_TB", Commons.Modules.TypeLanguage) & " :", Dong + TDong + 1, TCot - 1)
            'Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True, True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)
            excelApplication.ActiveWindow.DisplayGridlines = True
            excelWorkSheet.Columns.AutoFit()

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, 1)
            title.ColumnWidth = 0

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong + TDong, 3)
            title.ColumnWidth = 12
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 5, Dong + TDong, 5)
            title.ColumnWidth = 10

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 8, Dong + TDong, TCot)
            title.ColumnWidth = 12
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 11, Dong + TDong, 12)
            title.ColumnWidth = 16


            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong - 5)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 5, 1, Dong - 5, 1)
            title.RowHeight = 9

            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong - 1)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 9

            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong - 6)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 6, 1, Dong - 6, 1)
            title.RowHeight = 9

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, Dong + TDong + 2, TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, Dong + 2, TCot)
            title.Font.Bold = True
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            excelWorkbook.Save()
            excelApplication.Visible = True


            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        Catch ex As Exception
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) & vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Me.Cursor = Cursors.[Default]
    End Sub

    Private Sub GetPTCha(ByVal SD_KHO As Boolean, ByVal dtDisk As DataTable, ByVal MS_PT As String, ByVal MS_MAY As String, ByVal MS_BO_PHAN As String)
        Dim MS_BO_PHAN_CHA As String = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT MS_BO_PHAN_CHA FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & MS_MAY & "' AND MS_BO_PHAN = '" & MS_BO_PHAN & "'")
        If (Not MS_BO_PHAN_CHA Is Nothing) Then
            Dim dtPTCHA As DataTable = New DataTable()
            dtPTCHA.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_LICH_SU_PT_CHA", SD_KHO, MS_MAY, MS_BO_PHAN_CHA))
            Dim Str As String = "SELECT MS_VI_TRI_PT FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & MS_MAY & "' AND MS_BO_PHAN = '" & MS_BO_PHAN & "' AND MS_PT = '" & MS_PT & "' "
            Dim TB As DataTable = New DataTable()
            TB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, Str))

            For Each vRow As DataRow In dtPTCHA.Rows
                For Each vRowvt As DataRow In TB.Rows
                    Dim vRowadd As DataRow = dtDisk.NewRow()
                    vRowadd("MAY") = vRow("MAY")
                    vRowadd("TEN_BO_PHAN") = vRow("TEN_BO_PHAN")
                    vRowadd("PHU_TUNG") = vRow("PHU_TUNG")
                    vRowadd("MS_VI_TRI_PT") = vRowvt("MS_VI_TRI_PT")
                    vRowadd("NGAY_THAY_THE") = vRow("NGAY_THAY_THE")
                    vRowadd("NGUOI_THAY") = vRow("NGUOI_THAY")
                    vRowadd("MS_PHIEU_BAO_TRI") = vRow("MS_PHIEU_BAO_TRI")
                    vRowadd("PT_CHA") = vRow("PT_CHA")
                    vRowadd("MS_PTTT") = vRow("MS_PTTT")
                    vRowadd("TEN_PT") = vRow("TEN_PT")
                    vRowadd("SL_TT") = vRow("SL_TT")
                    vRowadd("XUAT_XU") = vRow("SL_TT")
                    vRowadd("GHI_CHU") = vRow("GHI_CHU")
                    vRowadd("THOI_GIAN_SU_DUNG") = vRow("THOI_GIAN_SU_DUNG")
                    dtDisk.Rows.Add(vRowadd)
                Next
            Next
            GetPTCha(SD_KHO, dtDisk, MS_PT, MS_MAY, MS_BO_PHAN_CHA)
        End If
    End Sub

    Private Sub btnThemLichBTPN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemLichBTPN.Click
        'tạo table tam chứa thông tin công việc
        Dim str As String = ""
        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.MAY_LOAI_BTPN_CONG_VIEC" & Commons.Modules.UserName & " (MS_MAY NVARCHAR(30),MS_LOAI_BT INT, MS_CV INT , MS_BO_PHAN NVARCHAR(50),TEN_BO_PHAN NVARCHAR(50),MO_TA_CV NVARCHAR(250),KY_HIEU_CV NVARCHAR(100),DA_CHON BIT,COUNT_ROW INT )"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try

        str = "CREATE TABLE DBO.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName &
                    "(MS_MAY NVARCHAR(30),MS_LOAI_BT INT, MS_CV INT, MS_BO_PHAN NVARCHAR(50),TEN_LOAI_VT NVARCHAR(50),MS_PT NVARCHAR(25), " &
                    " TEN_PT NVARCHAR(150),TEN_PT_VIET NVARCHAR(150),SO_LUONG FLOAT, QUY_CACH NVARCHAR(250),DA_CHON BIT,COUNT_ROW INT,GHI_CHU_BTPN	nvarchar(250))"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

        If ucDMTBi.txtMS_MAY.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenThem4", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'XtraMessageBox.Show("Bạn vui lòng tạo mới 1 thiết bị ", MsgBoxStyle.Information, "Thông báo ")
            Exit Sub
        End If

        HideButton12(True)
        bThemBTPN = True
        grdLoaiBTPN_CV.Enabled = False
        grdLoaiBTPN_PT.Enabled = False
        BtnChonCongViec.Visible = False
        BtnChonPT.Visible = False
        grvLoaiBTPN.OptionsBehavior.Editable = True
        grvLoaiBTPN.OptionsBehavior.AllowAddRows = True
        grvLoaiBTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom


        grvLoaiBTPN.OptionsBehavior.Editable = True

        grvLoaiBTPN.Columns("CHU_KYS").OptionsColumn.ReadOnly = True
        grvLoaiBTPN.Columns("MOVEMENT").OptionsColumn.ReadOnly = True
        grvLoaiBTPN.Columns("RUN_TIMES").OptionsColumn.ReadOnly = True

        rowCount = grvLoaiBTPN.RowCount - 1
        rowCount1 = grvLoaiBTPN_CV.RowCount
        rowCount2 = grvLoaiBTPN_PT.RowCount

        LockControl(True)

        Try
            Me.grvLoaiBTPN_PT.Columns("TEN_PT").OptionsColumn.ReadOnly = True
            Me.grvLoaiBTPN_PT.Columns("SL_MAX").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("DVT").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("QUY_CACH").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("TEN_LOAI_VT").OptionsColumn.ReadOnly = True
        Catch ex As Exception
        End Try
    End Sub




    Sub LoadMay()
        ' If RadNLD.Checked = False Then Exit Sub
        If Commons.Modules.SQLString = "0load" Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Refesh()

        Dim dtTmp As New DataTable
        Try


            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spThongtinthietbi_GET", Commons.Modules.UserName, CboNLD.EditValue, cboLine.EditValue, CboLoaithietbi.EditValue, CboNhomthietbi.EditValue, "-1", Commons.Modules.TypeLanguage + 3))
            dtTmp.PrimaryKey = New DataColumn() {dtTmp.Columns("MS_MAY")}
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, False, False, False, True)
            LocDuLieu()
            If MS_MAY_TMP_SET <> "" And capNhat Then
                Dim index As Integer '= dtTmp.Rows.IndexOf(dtTmp.Rows.Find(MS_MAY_TMP_SET))
                index = grvMay.LocateByValue(0, grvMay.Columns("MS_MAY"), MS_MAY_TMP_SET)
                grvMay.FocusedRowHandle = index
                grvMay.SelectRow(index)
            End If
            ShowMAY()
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnCopyTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyTB.Click
        Try
            Dim frmCopyTB As FrmCopyDecive = New FrmCopyDecive()
            frmCopyTB.MS_MAY = ucDMTBi.txtMS_MAY.Text
            frmCopyTB.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

#End Region
    Private Sub txtTiGiaVND_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If ucDMTBi.txtTiGiaVND.Text.Trim() <> "" Then
            Try
                Double.Parse(ucDMTBi.txtTiGiaVND.Text)
            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTiGiaVNDKhongHopLe", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub txtTiGiaUSD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If ucDMTBi.txtTiGiaUSD.Text.Trim() <> "" Then
            Try
                Double.Parse(ucDMTBi.txtTiGiaUSD.Text)
            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTiGiaUSDKhongHopLe", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub cboNGOAI_TE_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objDonHangNhapPTController As New IC_DON_HANG_NHAP_Controller
            ucDMTBi.txtTiGiaVND.Text = objDonHangNhapPTController.Load_Ty_Gia_Theo_Ngoai_Te(ucDMTBi.cboNGOAI_TE.EditValue.ToString()).ToString()
            ucDMTBi.txtTiGiaUSD.Text = objDonHangNhapPTController.Load_Ty_Gia_USD_Theo_Ngoai_Te(ucDMTBi.cboNGOAI_TE.EditValue.ToString()).ToString()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCKKDTB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtCKHCTB_Ngoai_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtCKHCTB_Ngoai_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'If Not txtCKHCTB_Ngoai.IsValidated Then
        '    e.Cancel = True

        'End If
    End Sub

    Private Sub txtTiGiaVND_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub



    Private Sub txtChukyHC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyValue >= 17) Or (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If

    End Sub


    Private Sub txtChukyHC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'If Not ucDMTBi.txtChukyHC.IsValidated Then
        '    e.Cancel = True
        'Else
        If IsNumeric(ucDMTBi.txtChukyHC.Text) Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(ucDMTBi.txtChukyHC.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ucDMTBi.txtChukyHC.Focus()
                e.Cancel = True
            End If
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucDMTBi.txtChukyHC.Focus()
            e.Cancel = True
        End If
        'End If
    End Sub





    Private Sub btnKhoiTao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhoiTao.Click
        If ucDMTBi.txtMS_MAY.Text = "" Then
            tlClass.Nodes.Clear()
        ElseIf Convert.ToDateTime(txtTu_Ngay7.DateTime.Date) > Convert.ToDateTime((txtDen_Ngay7.DateTime.Date)) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TuNgayNhoHonDenNgay", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTu_Ngay7.Focus()
        Else

            Me.Cursor = Cursors.WaitCursor
            ShowTreeRoot1(tlClass, ucDMTBi.txtMS_MAY.Text)
            Me.Cursor = Cursors.Default

        End If
    End Sub



    Private Sub BindDataSource()
        Dim _tbHuHong As New DataTable
        Dim _tbNguyenNhan As New DataTable
        Dim _tbPhuongPhap As New DataTable

        If ucDMTBi.txtMS_MAY.Text = tlClass.FocusedNode("MS_BO_PHAN").ToString() Then
            _tbHuHong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_HU_HONG", ucDMTBi.txtMS_MAY.Text, txtTu_Ngay7.Text, txtDen_Ngay7.Text, "-1"))
            _tbNguyenNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_NGUYEN_NHAN", ucDMTBi.txtMS_MAY.Text, txtTu_Ngay7.Text, txtDen_Ngay7.Text, "-1"))
            _tbPhuongPhap.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_PHUONG_PHAP", ucDMTBi.txtMS_MAY.Text, txtTu_Ngay7.Text, txtDen_Ngay7.Text, "-1"))
        Else
            _tbHuHong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_HU_HONG", ucDMTBi.txtMS_MAY.Text, txtTu_Ngay7.Text, txtDen_Ngay7.Text, tlClass.FocusedNode("MS_BO_PHAN").ToString()))
            _tbNguyenNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_NGUYEN_NHAN", ucDMTBi.txtMS_MAY.Text, txtTu_Ngay7.Text, txtDen_Ngay7.Text, tlClass.FocusedNode("MS_BO_PHAN").ToString()))
            _tbPhuongPhap.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_PHUONG_PHAP", ucDMTBi.txtMS_MAY.Text, txtTu_Ngay7.Text, txtDen_Ngay7.Text, tlClass.FocusedNode("MS_BO_PHAN").ToString()))
        End If

        _SourceProblem.DataSource = _tbHuHong
        If _tbHuHong.Rows.Count > 0 Then
            'grdHuHong.DataSource = _SourceProblem
            Commons.Modules.SQLString = "0LOAD"
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdHuHong, grvHuHong, _tbHuHong, False, True, True, True, True, Me.Name)
            Commons.Modules.SQLString = ""
        Else
            grdHuHong.DataSource = DBNull.Value
        End If
        If grvHuHong.RowCount > 0 Then
            grvHuHong.Columns("PROBLEM_ID").Visible = False
            grvHuHong.Columns("MS_MAY").Visible = False
            grvHuHong.Columns("PROBLEM_CODE").Width = 150

            grvHuHong.Columns("NOTES").Width = 150
            grvHuHong.Columns("REQUENCY").Width = 70

        End If

        _SourceCause.DataSource = _tbNguyenNhan
        If grvHuHong.RowCount > 0 Then
            Commons.Modules.SQLString = "0LOAD"
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNguyenNhan, grvNguyenNhan, _tbNguyenNhan, False, True, True, True, True, Me.Name)
            Commons.Modules.SQLString = ""
            'grdNguyenNhan.DataSource = _SourceCause
            grvNguyenNhan.Columns("PROBLEM_ID").Visible = False
            grvNguyenNhan.Columns("CAUSE_ID").Visible = False

        Else
            grdNguyenNhan.DataSource = DBNull.Value
        End If


        _SourceRemedy.DataSource = _tbPhuongPhap
        If grvNguyenNhan.RowCount > 0 Then
            Commons.Modules.SQLString = "0LOAD"
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdPP, grvPP, _tbPhuongPhap, False, True, True, True, True, Me.Name)
            Commons.Modules.SQLString = ""
            'grdPP.DataSource = _SourceRemedy
            grvPP.Columns("PROBLEM_ID").Visible = False
            grvPP.Columns("CAUSE_ID").Visible = False
        Else
            grdPP.DataSource = DBNull.Value
        End If
        grvHuHong_FocusedRowChanged(Nothing, Nothing)
    End Sub




    Private Sub btnThoat7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat7.Click
        Me.Close()
    End Sub




    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        If grvTaiLieuTS.RowCount < 1 Then
            Exit Sub
        End If
        Try
            Dim str As String = Me.grvTaiLieuTS.GetFocusedDataRow()("NOI_LUU_TRU")
            Dim folder As String = IO.Path.GetDirectoryName(str)
            System.Diagnostics.Process.Start("explorer.exe", folder)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT45", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'File đã bị thay đổi đường dẫn! Vui lòng kiểm tra lại
        End Try
    End Sub

    Private Sub txtSearchTL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _dt_temp As New DataTable()
        _dt_temp = dtTAI_LIEU.Copy()
        _dt_temp.DefaultView.RowFilter = "SO_TAI_LIEU LIKE '%" + txtSearchTL.Text + "%' OR TEN_TAI_LIEU LIKE '%" + txtSearchTL.Text + "%'"
        _dt_temp = _dt_temp.DefaultView.ToTable()
        grdTaiLieuTS.DataSource = _dt_temp
        Me.grvTaiLieuTS.Columns("MS_MAY").Visible = False
        grvTaiLieuTS.Columns("MA_TAI_LIEU").Visible = False
        grvTaiLieuTS.Columns("HINH").Visible = False

        grvTaiLieuTS.Columns("SO_TAI_LIEU").Width = 120
        grvTaiLieuTS.Columns("TEN_TAI_LIEU").Width = 150
        grvTaiLieuTS.Columns("GHI_CHU").Width = 150

    End Sub
    Private ShowTonKho As Boolean = False
    Private Sub frmThongtinthietbi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Commons.Modules.SQLString = "00Load" Then Exit Sub
        Cursor = Cursors.WaitCursor
        Try
            TlbTT.ColumnStyles(0).Width = 0
            TlbTT.ColumnStyles(TlbTT.ColumnCount - 1).Width = 0

            TlbTT.ColumnStyles(0).Width = 0
            TlbTT.ColumnStyles(TlbTT.ColumnCount - 1).Width = 0
            isFirst = True
            optHienTrang.SelectedIndex = 0
            flag = True
            ucDMTBi.LoadDVTG()
            ucDMTBi.LoadDVTSL()
            refesh1()
            If Commons.Modules.PermisString.Equals("Read only") Then
                Cursor = Cursors.WaitCursor
                Dim ngay, ngayHT As Date
                Dim nam, thang As Integer
                Commons.Modules.ObjSystems.DinhDang()
                ucDMTBi.chkHienthihinhTB.Checked = True
                ObjectEnable(False)
                CreateData()
                TaoMay()

                VisibleButton(True)
                LockData(True)
                LockControl(False)
                isFirst = True
                Commons.Modules.SQLString = ""
                Try
                    ucDMTBi.txtNgayHHKH.Text = DateSerial(Year(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")) + CType(IIf(ucDMTBi.txtSO_NAM_KHAU_HAO.Text = "", 0, ucDMTBi.txtSO_NAM_KHAU_HAO.Text), Integer), Month(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")), Day(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")))
                Catch ex As Exception
                    ucDMTBi.txtNgayHHKH.Text = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
                End Try
                Try

                    ucDMTBi.txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(ucDMTBi.txtSO_THANG_BH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date)
                Catch ex As Exception
                    ucDMTBi.txtNgayKTBH.Text = ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date
                End Try
                Try
                    ngay = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
                    ngayHT = Format(Date.Now, "short date")
                    nam = DateDiff(DateInterval.Year, ngay, ngayHT)
                    thang = DateDiff(DateInterval.Month, ngay, ngayHT)

                Catch ex As Exception
                    ucDMTBi.txtSO_NAM_SD.Text = 0
                End Try
                CboNLD.Focus()

                If grvMay.RowCount > 0 Then ShowTreeRootXtra(ucDMTBi.txtMS_MAY.Text) Else ShowTreeRootXtra("-1")

                HideXoa2(False)
                HideButton14(False)

                EnableButton(False)
                BtnXoa42.Enabled = False
                btnGhi1.Visible = False
                btnKhongghi1.Visible = False

            Else
                CreateData()
                EnableButton(True)
                Dim ngay, ngayHT As Date
                Dim nam, thang As Integer


                Commons.Modules.ObjSystems.DinhDang()
                Commons.Modules.SQLString = ""
                TaoMay()
                Cursor = Cursors.WaitCursor
                ObjectEnable(False)
                VisibleButton(True)
                LockData(True)
                LockControl(False)
                isFirst = True
                Try
                    ucDMTBi.txtNgayHHKH.Text = DateSerial(Year(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")) + CType(IIf(ucDMTBi.txtSO_NAM_KHAU_HAO.Text = "", 0, ucDMTBi.txtSO_NAM_KHAU_HAO.Text), Integer), Month(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")), Day(Format(ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date, "short date")))
                Catch ex As Exception
                    ucDMTBi.txtNgayHHKH.Text = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
                End Try
                Try
                    ucDMTBi.txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(ucDMTBi.txtSO_THANG_BH.Text), ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date)
                Catch ex As Exception
                    ucDMTBi.txtNgayKTBH.Text = ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date
                End Try
                Try
                    ngay = ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
                    ngayHT = Format(Date.Now, "short date")
                    nam = DateDiff(DateInterval.Year, ngay, ngayHT)
                    thang = DateDiff(DateInterval.Month, ngay, ngayHT)
                Catch ex As Exception
                    ucDMTBi.txtSO_NAM_SD.Text = 0
                End Try

                HideXoa2(False)
                HideButton14(False)

                btnGhi1.Visible = False
                btnKhongghi1.Visible = False

            End If
            If grvMay.RowCount > 0 Then
                grvMay.FocusedRowHandle = grvMay.GetRowHandle(0)
            End If

            txtTu_Ngay7.DateTime = Convert.ToDateTime("01/" & Date.Now.Month & "/" & Date.Now.Year)
            txtDen_Ngay7.DateTime = Date.Now


            If Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 17) = False Then
                BtnThem.Enabled = False
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
                BtnTaoMoiTB.Enabled = False
                btnCopyTB.Enabled = False
                ucDMTBi.btnChenhinh.Enabled = False
                ucDMTBi.btnXoahinh.Enabled = False
            End If

            ' quyen tren cau truc thiet bi
            If Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 52) = False Then
                BtnThem4.Enabled = False
                BtnSua4.Enabled = False
                BtnXoa4.Enabled = False
            End If
        Catch ex As Exception

        End Try

        Try
            grvMay.Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Catch
        End Try

        Try
            grvMay.Columns("MS_MAY").BestFit()
            grvMay.Columns("TEN_MAY").BestFit()
        Catch ex As Exception

        End Try


        If (MS_MAY_CHOICE <> Nothing) Then
            txtTimMay.Text = MS_MAY_CHOICE
            txtTimMay_KeyDown(txtTimMay, New KeyEventArgs(Keys.Enter))
        End If

        If (TAB_INDEX_CHOICE >= 0) Then
            Tabthietbi.SelectedTabPageIndex = TAB_INDEX_CHOICE
        End If

        If (MSBP <> "") Then
            tvwCTTBi.SetFocusedNode(tvwCTTBi.FindNodeByFieldValue("MS_BO_PHAN", MSBP))
        End If
        If MSPTVT <> "" Then
            For i As Integer = 0 To grvCTTB_PT.RowCount - 1
                If grvCTTB_PT.GetDataRow(i)("PTVT") = MSPTVT Then
                    grvCTTB_PT.FocusedRowHandle = i
                    Exit For
                End If
            Next
        End If
        If MSCV <> "" Then
            Me.Tab2Sub.SelectedTabPageIndex = 1
            For i As Integer = 0 To grvCTTB_CV.RowCount - 1
                If grvCTTB_CV.GetDataRow(i)("MS_CV") = MSCV Then
                    grvCTTB_CV.FocusedRowHandle = i
                    Exit For
                End If
            Next
        End If


        Dim sSql As String
        Dim dtTmp As New DataTable

        Try
            If Commons.Modules.LicID <> 0 Then

                sSql = "SELECT TYPE" + Commons.Modules.LicID.ToString() + " FROM LIC_ID " &
                            " WHERE (ID_NAME <> N'" + Commons.Modules.ObjSystems.MaHoaDL("mnuEquipmentInformation").ToString() + "') " &
                            " AND (ID_NAME LIKE N'" + Commons.Modules.ObjSystems.MaHoaDL("mnuEquipmentInformation").ToString() + "%')"

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                If dtTmp.Rows.Count = 0 Then
                    GrpDanhsachTB.Visible = False
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    For Each dr As DataRow In dtTmp.Rows
                        sSql = Commons.Modules.ObjSystems.GiaiMaDL(dr(0).ToString())
                        sSql = sSql.Replace("mnuEquipmentInformation", "")
                        If Microsoft.VisualBasic.Strings.Left(Microsoft.VisualBasic.Strings.Right(sSql, 2), 1) <> Commons.Modules.LicID Then
                            For Each tb As XtraTabPage In Tabthietbi.TabPages
                                If tb.Name.ToUpper() = sSql.Substring(0, sSql.Length - 2).ToUpper() Then
                                    Tabthietbi.TabPages.Remove(tb)
                                End If
                            Next
                        Else
                            If Microsoft.VisualBasic.Strings.Right(sSql, 1) <> 1 Then
                                For Each tb As XtraTabPage In Tabthietbi.TabPages
                                    If tb.Name.ToUpper() = sSql.Substring(0, sSql.Length - 2).ToUpper() Then
                                        Tabthietbi.TabPages.Remove(tb)
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
        If (Not MSMAY.Equals("-1")) Then
            txtTimMay.Text = MSMAY
            LocDuLieu()
            MSMAY = "-1"
        End If
        Try
            CreateMenuPT(grdLoaiBTPN_PT)
            CreateMenuCV(grdLoaiBTPN_CV)
            CreateMenuPT(grdLichSuPTTThe)

            CreateMenuCV(grdCTTB_CV)
            CreateMenuPT(grdCTTB_PT)
            CreateMenuGSTT(grdCTTB_TS, grdThongsoGSTTDL)

            CreateMenuPBT(grdLichSuMay)
            CreateMenuNewPBT(grdMay)
        Catch ex As Exception

        End Try
        Try
            ShowTonKho = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT HIEN_TK_CT FROM THONG_TIN_CHUNG"))

        Catch ex As Exception

        End Try

        Try
            If grvMay.RowCount <= 0 Then ThayDoiMay()
        Catch ex As Exception
            ThayDoiMay()
        End Try
        isFirst = False
        flag = False
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        lblTongSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTongSo", Commons.Modules.TypeLanguage) & " : " & grvMay.RowCount
        dtpTuNgay1.DateTime = CDate(DateSerial(DateTime.Now.Year, DateTime.Now.Month, "01"))
        dtpDenNgay1.DateTime = dtpTuNgay1.DateTime.AddMonths(1).AddDays(-1)
        txtTu_Ngay7.DateTime = CDate(DateSerial(DateTime.Now.Year, DateTime.Now.Month, "01"))
        txtDen_Ngay7.DateTime = dtpDenNgay1.DateTime

        Cursor = Cursors.Default
        Try
            ' Method 1
            Dim sTooltip1 As SuperToolTip = New SuperToolTip
            ' Create a tooltip item that represents a header.
            Dim titleItem1 As ToolTipTitleItem = New ToolTipTitleItem
            'titleItem1.Text = optHienTrang.Properties.Items(0).Description & " : " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "optCoVanDeHint", Commons.Modules.TypeLanguage)
            ' Create a tooltip item that represents the SuperTooltip's contents.
            Dim item1 As ToolTipItem = New ToolTipItem
            item1.Text = optHienTrang.Properties.Items(0).Description & " : " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, optHienTrang.Properties.Items(0).Value, Commons.Modules.TypeLanguage) & vbCrLf &
            optHienTrang.Properties.Items(1).Description & " : " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, optHienTrang.Properties.Items(1).Value, Commons.Modules.TypeLanguage) & vbCrLf &
            optHienTrang.Properties.Items(2).Description & " : " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "optCoVanDeHint", Commons.Modules.TypeLanguage)
            ' Add the tooltip items to the SuperTooltip.
            sTooltip1.Items.Add(titleItem1)
            sTooltip1.Items.Add(item1)
            optHienTrang.SuperTip = sTooltip1
        Catch ex As Exception
        End Try

        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grdMay
        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick

        BarManager.BeginUpdate()
        AddHandler popup.BeforePopup, AddressOf PopupMenu_BeforePopup
        popup.BeginUpdate()

        'add sự kiện từ ucDMTBi
        AddHandler ucDMTBi.BtnNoilapdat.Click, AddressOf BtnNoilapdatCK
        AddHandler ucDMTBi.chkHienthihinhTB.CheckedChanged, AddressOf chkHienthihinhTBCkecKed
        'ofdHinhTB_FileOk()

        Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
        Try
            Commons.Modules.SQLString = "0Load"
            opts.Columns.StoreAllOptions = True
            grdMay.MainView.RestoreLayoutFromRegistry(regMay)
            Commons.Modules.SQLString = ""
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvMay, Me.Name.ToString)
    End Sub

    Private Sub grvMay_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvMay.FocusedRowChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Try
            If grdMay Is Nothing Or grvMay.RowCount = 0 Then
                txtMS_MAY.Text = ""
            Else
                txtMS_MAY.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            End If
        Catch ex As Exception
            txtMS_MAY.Text = ""
        End Try

        Try
            Tabthietbi_SelectedPageChanged(Nothing, Nothing)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
        End Try

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BtnNoilapdatCK(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ucDMTBi.txtMS_MAY.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT6", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'XtraMessageBox.Show("Bạn vui lòng nhập mã số máy ", MsgBoxStyle.Information, "Thông báo")
            Exit Sub
        End If
        If MS_MAY_TMP = "" Then MS_MAY_TMP = ucDMTBi.txtMS_MAY.Text
        If MS_MAY_TMP = "-1" Then MS_MAY_TMP = ucDMTBi.txtMS_MAY.Text
        FrmNXHTBPCP.MS_MAY = MS_MAY_TMP
        FrmNXHTBPCP.ShowDialog()
        If FrmNXHTBPCP.MS_MAY = "" And blnThongtintb <> 0 Then MS_MAY_TMP = "-1"
        ucDMTBi.TxtMS_HE_THONG.Text = ""
        ucDMTBi.TxtMS_BP_CHIU_PHI.Text = ""
        ucDMTBi.TxtMS_NHA_XUONG.Text = ""
        InitMayHeThongBPCPNhaXuongTmp(MS_MAY_TMP)

    End Sub

    Private Sub chkHienthihinhTBCkecKed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '''''If LstMAY.Items.Count <= 0 Then
        If grvMay.RowCount <= 0 Then Exit Sub
        If ucDMTBi.chkHienthihinhTB.Checked Then
            ucDMTBi.PtcAnhTB.ImageLocation = grvMay.GetFocusedRowCellValue("Anh_TB").ToString()   'LstMAY.SelectedItem("ANH_TB").ToString
        Else
            ucDMTBi.PtcAnhTB.ImageLocation = ""
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btLichSuCauTrucTB.Click
        Dim str As String = ""
        If dtpTuNgay1.Text = "" Or dtpDenNgay1.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBoxChuaChonTuNgayHoacDenNgay", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If tlHistory.Nodes.Count = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtMayTT.Text = "" Then
            txtMayTT.Text = ucDMTBi.txtMS_MAY.Text
        End If

        If Commons.Modules.sPrivate = "ADC" Or Commons.Modules.sPrivate = "VINHHOAN" Then
            InLichSuCTTB()
            Exit Sub
        End If
        If Commons.Modules.sPrivate = "TRUNGNGUYEN" Then
            InLSCTTBTN()
            Exit Sub
        End If
        Try
            SqlText = "DROP TABLE EXPORT_TO_EXCEL"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay1.DateTime.Date.ToString()).Day.ToString()
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay1.DateTime.Date.ToString()).Month.ToString()
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay1.DateTime.Date.ToString()).Year.ToString()
        Dim _date_TN As String = thang_TN & "/" & ngay_TN & "/" & nam_TN
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay1.DateTime.Date.ToString()).Day.ToString()
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay1.DateTime.Date.ToString()).Month.ToString()
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay1.DateTime.Date.ToString()).Year.ToString()
        Dim _date_DN As String = thang_DN & "/" & ngay_DN & "/" & nam_DN

        SqlText = ""

        If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then
            SqlText = " SELECT  DISTINCT ROW_NUMBER() OVER (ORDER BY NGAY_HOAN_THANH DESC ,PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI DESC ) AS STT, dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, case " & Commons.Modules.TypeLanguage & " when 0 then T1.MO_TA_CV when 1 then isnull(T1.MO_TA_CV_ANH,T1.MO_TA_CV) when 2 then isnull(T1.MO_TA_CV_HOA,T1.MO_TA_CV) end as MO_TA_CV, " &
                    " case " & Commons.Modules.TypeLanguage & " when 0 then dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN when 1 then isnull(CAU_TRUC_THIET_BI.TEN_BO_PHAN_ANH, CAU_TRUC_THIET_BI.TEN_BO_PHAN) when 2 then ISNULL(CAU_TRUC_THIET_BI.TEN_BO_PHAN_HOA,CAU_TRUC_THIET_BI.TEN_BO_PHAN) end AS TEN_BP_TH, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,T11.TEN_LOAI_BT,  " &
                    " (SELECT	[dbo].[MGetCongNhanPBTCV](PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,PHIEU_BAO_TRI_CONG_VIEC.MS_CV,PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN,'-1')) NVBT," &
                    " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, " &
                    " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT, " &
                    " dbo.IC_PHU_TUNG.TEN_PT AS Expr1, " &
                    " CASE WHEN dbo.PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL THEN  " &
                    " CASE WHEN (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,0)  = 0) AND ISNULL( dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU,'') <> '' THEN    dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH ELSE      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT END " &
                    " ELSE  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT END AS SL_TT , " &
                    " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT, " &
                    " CASE WHEN  '" & Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi).ToString().ToUpper() & "' = 'TRUE' " &
                    " THEN DHG.XUAT_XU ELSE dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU END AS XUAT_XU,TT_SAU_BT, " &
                    " CASE WHEN  '" & Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi).ToString().ToUpper() & "' = 'TRUE' " &
                    " THEN  DHG.GHI_CHU " &
                    " ELSE case  when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU is null then  " &
                    " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU else dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU end END " &
                    " as GHI_CHU "

            SqlText = SqlText & " FROM         dbo.CONG_VIEC T1 INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI ON " &
                          " T1.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV INNER JOIN " &
                          " dbo.CAU_TRUC_THIET_BI ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT "
            If Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi) Then
                SqlText = SqlText & " AND dbo.IC_DON_HANG_NHAP_VAT_TU.ID = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.ID "
            End If
            SqlText = SqlText & " INNER JOIN " &
                          " dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT = dbo.IC_PHU_TUNG.MS_PT RIGHT OUTER JOIN " &
                          " dbo.IC_PHU_TUNG IC_PHU_TUNG_1 INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                          " IC_PHU_TUNG_1.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE = dbo.CONG_NHAN.MS_CONG_NHAN "

            If Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi) Then
                SqlText = SqlText & " LEFT OUTER JOIN " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU AS DHG ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = DHG.MS_PT AND " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT_GOC = DHG.MS_DH_NHAP_PT AND dbo.IC_DON_HANG_NHAP_VAT_TU.ID_GOC = DHG.ID  "
            Else
                SqlText = SqlText & " LEFT OUTER JOIN " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU AS DHG ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = DHG.MS_PT AND " &
                            " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = DHG.MS_DH_NHAP_PT "

            End If


            SqlText = SqlText & " INNER JOIN dbo.LOAI_BAO_TRI T11 ON T11.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT WHERE (PHIEU_BAO_TRI.TINH_TRANG_PBT >= 4) AND (PHIEU_BAO_TRI.MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "') AND  " &
                          " (dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ")) " &
                          "  " &
                          " ORDER BY NGAY_HOAN_THANH DESC ,PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI   DESC"
        Else
            'chu y IC_PHU_TUNG_1.TEN_PT ten la ten_pt nhung lay MS_PT_NCC 
            SqlText = " SELECT  DISTINCT   dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, dbo.CONG_VIEC.MO_TA_CV, " &
                          " dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT, " &
                          " IC_PHU_TUNG_1.TEN_PT AS Expr1, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT, " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT, dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, " &
                          " case  when dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU is null then  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU else dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU end as GHI_CHU , CONVERT(INT,0) AS ID " &
                          " FROM         dbo.CONG_VIEC INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI ON " &
                          " dbo.CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV INNER JOIN " &
                          " dbo.CAU_TRUC_THIET_BI ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT INNER JOIN " &
                          " dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT = dbo.IC_PHU_TUNG.MS_PT RIGHT OUTER JOIN " &
                          " dbo.IC_PHU_TUNG IC_PHU_TUNG_1 INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                          " IC_PHU_TUNG_1.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT INNER JOIN " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " &
                          " AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT ON  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  " &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN LEFT OUTER JOIN " &
                          " dbo.CONG_NHAN ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE = dbo.CONG_NHAN.MS_CONG_NHAN " &
                          " WHERE (PHIEU_BAO_TRI.TINH_TRANG_PBT >= 4) AND (PHIEU_BAO_TRI.MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "') AND  " &
                          " (dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  IN (select  MS_BO_PHAN FROM BO_PHAN" & Commons.Modules.UserName & ")) " &
                          " ORDER BY dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH DESC"
        End If

        Dim vtbTam As New DataTable()
        Try
            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
            Commons.Modules.ObjSystems.MLoadXtraGrid(ucDMTBi.grdChung, ucDMTBi.grvChung, vtbTam, False, True, True, True, True, Me.Name.ToString)
            InVB()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ThayDoiMay()


        tmp_i = -1
        tmp_k = -1
        '0TabThongtinTB
        '1tabCautrucTB
        '2tabLichBTDKy
        '3tabGSTTvaHCTB
        '4tabThongsoTB
        '5tabLichsuTB
        '6tabHechuyengia
        '7tabBaocao
        Me.Cursor = Cursors.WaitCursor
        Try
            If grdMay Is Nothing Or grvMay.RowCount = 0 Then
                txtMS_MAY.Text = ""
            Else
                txtMS_MAY.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
            End If
        Catch ex As Exception
            txtMS_MAY.Text = ""
        End Try
        ShowMAY()
        If isFirst = False Then
            Select Case Tabthietbi.SelectedTabPageIndex
                Case 1
                    LoadCmbPT_BP()
                    If ucDMTBi.txtMS_MAY.Text = "" Then ShowTreeRootXtra("-1") Else ShowTreeRootXtra(ucDMTBi.txtMS_MAY.Text)
                    If tvwCTTBi.AllNodesCount > 1 Then
                        Try
                            tvwCTTBi.SetFocusedNode(tvwCTTBi.Nodes(0))
                        Catch ex As Exception
                        End Try
                    End If
                Case 2
                    BindData3()
                Case 3
                    BindData5()
                Case 4
                    If txtM4.Text = ucDMTBi.txtMS_MAY.Text Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    BindData2()
                    BindData1()
                    txtM4.Text = ucDMTBi.txtMS_MAY.Text
                Case 5
                    If txtM5.Text = ucDMTBi.txtMS_MAY.Text Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    ClearHistory()
                    txtM5.Text = ucDMTBi.txtMS_MAY.Text
                Case 6
                    If txtM6.Text = ucDMTBi.txtMS_MAY.Text Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    ClearHeChuyenGia()
                    txtM6.Text = ucDMTBi.txtMS_MAY.Text
            End Select
        End If

    End Sub


    Private Sub TaoMay()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Try

            Refesh()
            Dim dtTmp = New DataTable
            LoadNLD()
            Commons.Modules.SQLString = ""
            LoadMay()
            If ucDMTBi.txtMS_MAY.Text = "" And dtTmp.Rows.Count > 0 Then ThayDoiMay()
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub




    Dim flag As Boolean = False

    Private Sub LoadNhomTB()
        Dim dtTmp1 = New DataTable
        dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_NHOM_MAYs", "-1"))
        Dim drRow As DataRow = dtTmp1.NewRow
        drRow("MS_NHOM_MAY") = "-1"
        drRow("TEN_NHOM_MAY") = " < ALL > "
        drRow("MS_LOAI_MAY") = "-1"
        dtTmp1.Rows.Add(drRow)
        dtTmp1.DefaultView.Sort = "TEN_NHOM_MAY"
        dtTmp1 = dtTmp1.DefaultView.ToTable()

        Commons.Modules.ObjSystems.MLoadLookUpEdit(CboNhomthietbi, dtTmp1, "MS_NHOM_MAY", "TEN_NHOM_MAY", "")
    End Sub
    Private Sub optHienTrang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optHienTrang.SelectedIndexChanged
        Try
            Dim dtTmp As New DataTable()
            dtTmp = CType(grdMay.DataSource, DataTable)
            If (optHienTrang.SelectedIndex = 0) Then
                dtTmp.DefaultView.RowFilter = "MS_HIEN_TRANG = 2 AND MS_HT IS NOT NULL"
                dtTmp = dtTmp.DefaultView.ToTable()
            ElseIf (optHienTrang.SelectedIndex = 1) Then
                dtTmp.DefaultView.RowFilter = "(MS_HIEN_TRANG = 3 OR MS_HIEN_TRANG = 4) AND MS_HT IS NOT NULL"
                dtTmp = dtTmp.DefaultView.ToTable()
            Else
                dtTmp.DefaultView.RowFilter = "MS_HT IS NULL"
                dtTmp = dtTmp.DefaultView.ToTable()
            End If
            txtTimMay_KeyDown(txtTimMay, New KeyEventArgs(Keys.Enter))
            intRow = grvMay.FocusedRowHandle
            txtM0.Text = ""
            ShowMAY()
            Cursor = Cursors.Default
        Catch
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ShowTab2Sub()
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        If blnThemSuaCauTrucSub Then Exit Sub
        If blnXoaCauTruc Then Exit Sub
        If blnThemSuaCauTruc Then Exit Sub
        txtPath.Text = GetFullPath(tvwCTTBi.FocusedNode, "\")
        Me.Cursor = Cursors.WaitCursor
        Try
            XtraOldNode = tvwCTTBi.FocusedNode
            XtraPrevOldNode = tvwCTTBi.FocusedNode.PrevNode
        Catch ex As Exception
            XtraOldNode = Nothing
            XtraPrevOldNode = Nothing
        End Try
        Try
            refesh1()
            flagPTCha = True
            Call BindTextValue()
            flagPTCha = False
            Select Case Tab2Sub.SelectedTabPageIndex
                Case 0
                    ShowTHONG_TIN_PT()
                Case 1
                    ShowCongviecBoPhan()
                Case 2
                    ShowTSGSTTBoPhan()
                Case 3
                    ShowThongSoGSTTDL()
                Case 4
                    Call ShowTHONG_SO_BP()
            End Select
        Catch ex As Exception

        End Try
        blnThemSuaCauTruc = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tvwCTTBi_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvwCTTBi.FocusedNodeChanged
        ShowTab2Sub()
    End Sub

    Public Function GetFullPath(ByVal node As DevExpress.XtraTreeList.Nodes.TreeListNode, ByVal pathSeparator As String) As String
        If node Is Nothing Then
            Return ""
        End If
        Dim result As String = ""
        Do While node IsNot Nothing
            result = pathSeparator & node.GetValue("MS_BO_PHAN").ToString & result
            node = node.ParentNode
        Loop
        Return ucDMTBi.txtMS_MAY.Text & result
    End Function


    Private Sub tvwCTTBi_DragDrop(sender As Object, e As DragEventArgs) Handles tvwCTTBi.DragDrop
        If txtMS_BO_PHAN.Text = "" Then
            e.Effect = DragDropEffects.None
            Exit Sub
        End If

        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenkt54", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Effect = DragDropEffects.None
        Else

            e.Effect = DragDropEffects.Move


            Dim node As TreeListNode = GetDragNode(e.Data)
            Dim targetNode As TreeListNode
            If node Is Nothing Then
                Return
            End If
            Dim list As TreeList = CType(sender, TreeList)
            targetNode = list.CalcHitInfo(list.PointToClient(New Point(e.X, e.Y))).Node

            If list Is node.TreeList Then
                SQL = "UPDATE CAU_TRUC_THIET_BI SET MS_BO_PHAN_CHA = N'" & targetNode("MS_BO_PHAN").ToString() & "' WHERE MS_BO_PHAN='" & node("MS_BO_PHAN").ToString() & "' AND MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
                ShowTreeRootXtra(ucDMTBi.txtMS_MAY.Text)
                'TimkiemCauTrucThietBi(node("MS_BO_PHAN").ToString(), tvwCautrucTB)
                'tvwCTTBi.RefreshDataSource()

                Try
                    tvwCTTBi.SetFocusedNode(tvwCTTBi.FindNodeByFieldValue("MS_BO_PHAN", node("MS_BO_PHAN").ToString()))
                Catch ex As Exception
                End Try
                Return
            Else

                Dim info As TreeListHitInfo = list.CalcHitInfo(list.PointToClient(New Point(e.X, e.Y)))
                targetNode = list.CalcHitInfo(list.PointToClient(New Point(e.X, e.Y))).Node

                If info.Node Is Nothing Then
                    InsertBrunch(list, node, -1)
                Else
                    InsertBrunch(list, node, info.Node.Id)
                End If

                SQL = "UPDATE CAU_TRUC_THIET_BI SET MS_BO_PHAN_CHA = N'" & targetNode("MS_BO_PHAN").ToString() & "' WHERE MS_BO_PHAN='" & node("MS_BO_PHAN").ToString() & "' AND MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

                ShowTreeRootXtra(ucDMTBi.txtMS_MAY.Text)
            End If
        End If
    End Sub

    Private Sub tvwCTTBi_DragEnter(sender As Object, e As DragEventArgs) Handles tvwCTTBi.DragEnter

        Dim list As TreeList = CType(sender, TreeList)
        Dim node As TreeListNode = GetDragNode(e.Data)
        If node IsNot Nothing AndAlso node.TreeList IsNot list Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Function GetDragNode(ByVal data As IDataObject) As TreeListNode
        Return CType(data.GetData(GetType(TreeListNode)), TreeListNode)
    End Function

    Private Sub InsertBrunch(ByVal list As TreeList, ByVal node As TreeListNode, ByVal parent As Integer)
        Dim data As New ArrayList()
        For Each column As TreeListColumn In node.TreeList.Columns
            data.Add(node(column))
        Next column
        parent = list.AppendNode(data.ToArray(), parent).Id
        If node.HasChildren Then
            For Each n As TreeListNode In node.Nodes
                InsertBrunch(list, n, parent)
            Next n
        End If
    End Sub

    Private Sub grvCTTB_PT_ColumnPositionChanged(sender As Object, e As EventArgs) Handles grvCTTB_PT.ColumnPositionChanged
        If Commons.Modules.SQLString <> "MenuColumnRemoveColumn" Then Exit Sub

        Try

            Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
            opts.Columns.StoreAllOptions = True
            'grvCTTB_PT.SaveLayoutToXml(Application.StartupPath + "\XML\GrdMayCTTBPT.xml", opts)
            grdCTTB_PT.MainView.SaveLayoutToRegistry(regCTTB)
            Commons.Modules.SQLString = ""
            grvCTTB_PT.Columns("SL_TON").Visible = If(ShowTonKho = False, False, True)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub grvCTTB_PT_HideCustomizationForm(sender As Object, e As EventArgs) Handles grvCTTB_PT.HideCustomizationForm
        Try
            Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
            opts.Columns.StoreAllOptions = True
            'grvCTTB_PT.SaveLayoutToXml(Application.StartupPath + "\XML\GrdMayCTTBPT.xml", opts)
            grdCTTB_PT.MainView.SaveLayoutToRegistry(regCTTB)
            grvCTTB_PT.Columns("SL_TON").Visible = If(ShowTonKho = False, False, True)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub grvCTTB_PT_GridMenuItemClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.GridMenuItemClickEventArgs) Handles grvCTTB_PT.GridMenuItemClick
        If e.DXMenuItem.Tag = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn Then
            Commons.Modules.SQLString = "MenuColumnRemoveColumn"
        End If
    End Sub

    Private Sub grvCTTB_PT_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvCTTB_PT.ValidateRow
        Dim _i As Integer = 0
        Try
            Dim i As Integer
            While i < grvCTTB_PT.RowCount
                If Not IsDBNull(Me.grvCTTB_PT.GetDataRow(i)("MS_VI_TRI_PT")) Then
                    If i <> Me.grvCTTB_PT.FocusedRowHandle Then
                        If grvCTTB_PT.GetFocusedDataRow()("MS_VI_TRI_PT").ToString().ToUpper() = Me.grvCTTB_PT.GetDataRow(i)("MS_VI_TRI_PT").ToString().ToUpper() And Me.grvCTTB_PT.GetDataRow(i)("MS_PT") = grvCTTB_PT.GetFocusedDataRow()("MS_PT") Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenkt56", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            e.Valid = False
                            Exit Sub
                        End If
                    End If
                    i = i + 1
                End If
            End While
            If Not IsNumeric(grvCTTB_PT.GetFocusedDataRow()("SO_LUONG")) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
            Try
                If Not IsNumeric(grvCTTB_PT.GetFocusedDataRow()("GIA_TRI_MIN")) And Not IsDBNull(grvCTTB_PT.GetFocusedDataRow()("CBOPHUTUNG")) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT13", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Valid = False
                    Exit Sub
                ElseIf grvCTTB_PT.GetFocusedDataRow()("GIA_TRI_MIN") <> "" Then
                    If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(grvCTTB_PT.GetFocusedDataRow()("GIA_TRI_MIN")) Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        e.Valid = False
                        Exit Sub
                    End If

                End If
            Catch ex As Exception
            End Try
            Dim str As String = ""
            If grvCTTB_PT.GetFocusedDataRow()("ACTIVE").ToString() = "False" Then
                str = "SELECT COUNT(*) FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY='" & ucDMTBi.txtMS_MAY.Text & "' AND MS_PT='" & grvCTTB_PT.GetFocusedDataRow()("MS_PT").ToString() & "'"
                _i = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                If _i > 0 Then
                    str = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TonTaiPTPBT", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
                    'If str = vbNo Then
                    grvCTTB_PT.SetFocusedRowCellValue("ACTIVE", 1)
                    e.Valid = False
                    Exit Sub
                    'End If
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NhapDuLieuSai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub grvCTTB_PT_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvCTTB_PT.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvCTTB_TS_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvCTTB_TS.ValidateRow
        If BtnGhiTSGSTT_BP.Visible = False Then
            Exit Sub
        End If
        Try
            If grvCTTB_TS.GetFocusedDataRow()("CHU_KY_DO") <> "0" Then
                If IsDBNull(Me.grvCTTB_TS.GetFocusedDataRow()("MS_DV_TG")) Then
                    Commons.MssBox.Show(Me.Name, "Msgktdl", Me.Text)
                    e.Valid = False
                End If
            End If
            If (Not IsDBNull(grvCTTB_TS.GetFocusedDataRow()("MS_DV_TG"))) Then
                If Me.grvCTTB_TS.GetFocusedDataRow()("CHU_KY_DO") = 0 Then
                    Commons.MssBox.Show(Me.Name, "MsgQuyenKT47", Me.Text)
                    e.Valid = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grvCTTB_TS_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvCTTB_TS.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub Tab2Sub_SelectedIndexChanged(sender As Object, e As TabPageChangedEventArgs) Handles Tab2Sub.SelectedPageChanged
        Try

            Select Case Tab2Sub.SelectedTabPageIndex
                Case 0
                    ShowTHONG_TIN_PT()
                Case 1
                    ShowCongviecBoPhan()
                Case 2
                    ShowTSGSTTBoPhan()
                Case 3
                    ShowThongSoGSTTDL()
                Case 4
                    ShowTHONG_SO_BP()
            End Select
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Tabthietbi_SelectedPageChanging(sender As Object, e As TabPageChangingEventArgs) Handles Tabthietbi.SelectedPageChanging
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If BtnGhi.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhi4.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhi3.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhi2.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If btnGhi1.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhiPT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhiCV_BP.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhiTSGSTT_BP.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhi15.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhiTSvaPT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub Tab2Sub_SelectedPageChanging(sender As Object, e As TabPageChangingEventArgs) Handles Tab2Sub.SelectedPageChanging
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If BtnGhiPT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhiCV_BP.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhiTSGSTT_BP.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhi15.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
        If BtnGhiTSvaPT.Visible = True Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub grvThongSoBP_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvThongSoBP.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvThongSoBP_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvThongSoBP.ValidateRow
        If Not BtnGhiTSvaPT.Visible Then
            Exit Sub
        End If
        If grvThongSoBP.GetFocusedDataRow()("TEN_THONG_SO").ToString().Length > 250 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenThongSoMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If
        If grvThongSoBP.GetFocusedDataRow()("GIA_TRI_THONG_SO").ToString().Length > 250 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If
    End Sub

    Private Sub grvThongsoGSTTDL_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvThongsoGSTTDL.FocusedRowChanged
        If Commons.Modules.SQLString = "0L0AD" Then Exit Sub
        ShowThongsoChitiet(grvThongsoGSTTDL.FocusedRowHandle)
        If (BtnGhi15.Visible = False) Then Exit Sub
        If (grvThongsoGSTTDL.RowCount = 0) Then Exit Sub

        grvThongsochitiet.OptionsBehavior.Editable = True
        grvThongsochitiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        grvThongsochitiet.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    End Sub
    Dim focusTS As Integer = -1
    Private Sub grvThongsochitiet_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvThongsochitiet.ValidateRow
        If Not BtnGhi15.Visible Then
            Exit Sub
        End If
        If grvThongsochitiet.RowCount > 1 Then
            If Not IsDBNull(grvThongsochitiet.GetFocusedDataRow()("TEN_GT")) Or Not String.IsNullOrEmpty(grvThongsochitiet.GetFocusedDataRow()("TEN_GT").ToString().Trim()) Then
                If dtTableThongso.Select().AsEnumerable().Any(Function(x) x("TEN_GT").ToString().Trim().Equals(grvThongsochitiet.GetFocusedDataRow()("TEN_GT").ToString()) And x("MS_TT") <> grvThongsochitiet.GetFocusedDataRow()("MS_TT").ToString() And x("MS_TS_GSTT").ToString().Trim().Equals(grvThongsochitiet.GetFocusedDataRow()("MS_TS_GSTT").ToString())) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTengiatritrung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Valid = False
                    Exit Sub
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenGT", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
        End If
        Try
            Dim giaTriTren As Double = Convert.ToDouble(grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_TREN"))
            Dim giaTriDuoi As Double = 0
            Try
                giaTriDuoi = Convert.ToDouble(grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_DUOI"))
            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriDuoi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End Try
            If giaTriTren <= giaTriDuoi Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriTrennhohonGiaTriDuoi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriTren", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End Try
        Try
            Dim giaTriDuoi As Double = Convert.ToDouble(grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_DUOI"))
            Dim giaTriTren As Double = 0
            Try
                giaTriTren = Convert.ToDouble(grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_TREN"))
            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriTren", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End Try
            If giaTriTren <= giaTriDuoi Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriDuoilonhonGiaTriTren", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriDuoi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End Try
        Dim dr As DataRow
        Try
            dr = dtTableThongso.Select().AsEnumerable().SingleOrDefault(Function(x) x("MS_MAY") = grvThongsochitiet.GetFocusedDataRow()("MS_MAY") And x("MS_TS_GSTT") = grvThongsochitiet.GetFocusedDataRow()("MS_TS_GSTT") And x("MS_BO_PHAN") = grvThongsochitiet.GetFocusedDataRow()("MS_BO_PHAN") And x("MS_TT") = grvThongsochitiet.GetFocusedDataRow()("MS_TT"))
            dr("TEN_GT") = grvThongsochitiet.GetFocusedDataRow()("TEN_GT")
            dr("GIA_TRI_TREN") = grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_TREN")
            dr("GIA_TRI_DUOI") = grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_DUOI")
            dr("ACTIVE") = grvThongsoGSTTDL.GetFocusedDataRow()("ACTIVE")
            dr("DAT") = grvThongsochitiet.GetFocusedDataRow()("DAT")
        Catch ex As Exception
            dr = dtTableThongso.NewRow
            Dim drNew As DataRow = dtTableThongso.NewRow
            dr("MS_MAY") = ucDMTBi.txtMS_MAY.Text
            dr("MS_BO_PHAN") = txtMS_BO_PHAN.Text
            dr("DAT") = grvThongsochitiet.GetFocusedDataRow()("DAT")
            dr("MS_TS_GSTT") = grvThongsoGSTTDL.GetFocusedDataRow()("MS_TS_GSTT")
            dr("MS_TT") = grvThongsochitiet.GetFocusedDataRow()("MS_TT")
            dr("TEN_GT") = grvThongsochitiet.GetFocusedDataRow()("TEN_GT")
            dr("GIA_TRI_TREN") = grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_TREN")
            dr("GIA_TRI_DUOI") = grvThongsochitiet.GetFocusedDataRow()("GIA_TRI_DUOI")
            dr("ACTIVE") = grvThongsoGSTTDL.GetFocusedDataRow()("ACTIVE")
            dr("TEN_TS_GSTT") = grvThongsoGSTTDL.GetFocusedDataRow()("TEN_TS_GSTT")
            dr("THOI_GIAN") = grvThongsoGSTTDL.GetFocusedDataRow()("THOI_GIAN")
            dr("CACH_THUC_HIEN") = grvThongsoGSTTDL.GetFocusedDataRow()("CACH_THUC_HIEN")
            dtTableThongso.Rows.Add(dr)
        End Try
    End Sub

    Private Sub grvThongsochitiet_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvThongsochitiet.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvThongsochitiet_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvThongsochitiet.InitNewRow
        grvThongsochitiet.SetFocusedRowCellValue("MS_TT", GetNum(dtTableThongso))
        grvThongsochitiet.SetFocusedRowCellValue("MS_MAY", grvThongsoGSTTDL.GetFocusedDataRow()("MS_MAY"))
        grvThongsochitiet.SetFocusedRowCellValue("MS_TS_GSTT", grvThongsoGSTTDL.GetFocusedDataRow()("MS_TS_GSTT"))
        grvThongsochitiet.SetFocusedRowCellValue("MS_BO_PHAN", grvThongsoGSTTDL.GetFocusedDataRow()("MS_BO_PHAN"))
        grvThongsochitiet.SetFocusedRowCellValue("DAT", 0)
        grvThongsochitiet.SetFocusedRowCellValue("THOI_GIAN", grvThongsoGSTTDL.GetFocusedDataRow()("THOI_GIAN"))
        grvThongsochitiet.SetFocusedRowCellValue("CACH_THUC_HIEN", grvThongsoGSTTDL.GetFocusedDataRow()("CACH_THUC_HIEN"))
    End Sub

    Private Sub grvLichSuMay_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvLichSuMay.FocusedRowChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        If grvLichSuMay.RowCount = 0 Then Exit Sub
        Dim str As String = ""

        If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then
            If Convert.ToBoolean(Commons.Modules.ObjSystems.KhoMoi) Then
                '            str = "SELECT distinct  A.MS_PT,A.MS_VI_TRI_PT,CONG_NHAN.HO + '' + CONG_NHAN.TEN AS NGUOI_THAY_THE,A.NGAY_THAY_THE, A.VICT_NHA_THAU, A.SL_TT, A.GHI_CHU, A.ID FROM (" &
                '             " SELECT " &
                '             "         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, " &
                '              "        dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.VICT_NHA_THAU, " &
                '               "       dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE NTT, CONVERT(NVARCHAR(10), " &
                '                "      dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, 103) AS NGAY_THAY_THE, " &
                '" CASE WHEN dbo.PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL THEN  " &
                '" CASE WHEN (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,0)  = 0) AND ISNULL( dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU,'') <> '' THEN    dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH ELSE      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT END " &
                '" ELSE  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT END AS SL_TT , " &
                '            " dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, "
                '            If grvLichSuMay.GetFocusedDataRow()("NHA_THAU") Then
                '                str = str & " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU "
                '            Else
                '                str = str & " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU "
                '            End If
                '            str = str & " , dbo.IC_DON_HANG_NHAP_VAT_TU.ID FROM         dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                '  "                    dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON  " &
                '   "                   dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " &
                '    "                  dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT  AND " &
                '     "                  dbo.IC_DON_HANG_NHAP_VAT_TU.ID = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.ID RIGHT OUTER JOIN " &
                '     "                 dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN " &
                '      "                dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                '       "               dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND " &
                '        "               dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  " &
                '         "             dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                '          "            dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN INNER JOIN " &
                '           "           dbo.PHIEU_BAO_TRI_CONG_VIEC ON " &
                '            "          dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI AND " &
                '             "         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV AND " &
                '              "        dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN ON " &
                '            " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " &
                '             "          AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND " &
                '            " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " &
                '              "         AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " &
                '            "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT " &
                '" WHERE     (PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = '" & grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString() & "') " &
                '" AND (PHIEU_BAO_TRI_CONG_VIEC.MS_CV = " & grvLichSuMay.GetFocusedDataRow()("MS_CV").ToString() & ") " &
                '" AND ( (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT,0)  > 0)  " &
                '" OR  ( ISNULL( dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU,'') <> '' ) ) " &
                '" AND (PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = '" & grvLichSuMay.GetFocusedDataRow()("MS_BO_PHAN").ToString() & "')" &
                '            ") AS A LEFT JOIN CONG_NHAN ON A.NTT = CONG_NHAN.MS_CONG_NHAN"


                str = "
                        SELECT T4.MS_PT, T4.MS_VI_TRI_PT, HO+ ' ' + TEN AS NGUOI_THAY_THE,CONVERT(NVARCHAR(10), T5.NGAY_HOAN_THANH, 103) AS NGAY_THAY_THE, T4.VICT_NHA_THAU, 
                        CASE WHEN T5.STT_SERVICE IS NULL THEN 
	                        CASE WHEN (ISNULL(T4.SL_TT, 0) = 0) AND ISNULL(T4.GHI_CHU, '') <> '' THEN 
		                        T4.SL_KH 
	                        ELSE T2.SL_TT END 
                        ELSE T4.SL_TT END AS SL_TT, 
						                         CASE WHEN " & IIf(grvLichSuMay.GetFocusedDataRow()("NHA_THAU"), 1, 0) & " = 1 THEN T3.GHI_CHU ELSE T4.GHI_CHU END AS GHI_CHU, 
                                                 T2.MS_DH_XUAT_PT, T2.MS_DH_NHAP_PT, T1.XUAT_XU, T1.BAO_HANH_DEN_NGAY, T1.ID
                        FROM            dbo.CONG_NHAN AS T6 RIGHT OUTER JOIN
                                                 dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG AS T3 INNER JOIN
                                                 dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET AS T4 ON T3.MS_PHIEU_BAO_TRI = T4.MS_PHIEU_BAO_TRI AND T3.MS_CV = T4.MS_CV AND T3.MS_PT = T4.MS_PT AND 
                                                 T3.MS_BO_PHAN = T4.MS_BO_PHAN INNER JOIN
                                                 dbo.PHIEU_BAO_TRI_CONG_VIEC AS T5 ON T3.MS_PHIEU_BAO_TRI = T5.MS_PHIEU_BAO_TRI AND T3.MS_CV = T5.MS_CV AND T3.MS_BO_PHAN = T5.MS_BO_PHAN ON 
                                                 T6.MS_CONG_NHAN = T4.NGUOI_THAY_THE LEFT OUTER JOIN
                                                 dbo.IC_DON_HANG_NHAP_VAT_TU AS T1 INNER JOIN
                                                 dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO AS T2 ON T1.MS_DH_NHAP_PT = T2.MS_DH_NHAP_PT AND T1.MS_PT = T2.MS_PTTT AND T1.ID = T2.ID ON 
                                                 T4.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T4.MS_CV = T2.MS_CV AND T4.MS_BO_PHAN = T2.MS_BO_PHAN AND T4.MS_PT = T2.MS_PT AND T4.STT = T2.STT
                        WHERE        (T5.MS_PHIEU_BAO_TRI = '" & grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString() & "') AND (T5.MS_CV = " & grvLichSuMay.GetFocusedDataRow()("MS_CV").ToString() & ") AND (ISNULL(T2.SL_TT, 0) > 0 OR
                                                 ISNULL(T4.GHI_CHU, N'') <> '') AND (T5.MS_BO_PHAN = '" & grvLichSuMay.GetFocusedDataRow()("MS_BO_PHAN").ToString() & "')
                        "

            Else
                str = "SELECT distinct  A.MS_PT,A.MS_VI_TRI_PT,CONG_NHAN.HO+''+CONG_NHAN.TEN AS NGUOI_THAY_THE,A.NGAY_THAY_THE, A.VICT_NHA_THAU, A.SL_TT, A.GHI_CHU, CONVERT(INT,0) AS ID FROM (" &
                 " Select " &
                 "         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT, dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, " &
                  "        dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.VICT_NHA_THAU, " &
                   "       dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGUOI_THAY_THE NTT, CONVERT(NVARCHAR(10), " &
                    "      dbo.PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, 103) AS NGAY_THAY_THE, " &
    " CASE WHEN dbo.PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL THEN  " &
    " CASE WHEN (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,0)  = 0) AND ISNULL( dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU,'') <> '' THEN    dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH ELSE      dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT END " &
    " ELSE  dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT END AS SL_TT , " &
                " dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, "
                If grvLichSuMay.GetFocusedDataRow()("NHA_THAU") Then
                    str = str & " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU "
                Else
                    str = str & " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU "
                End If
                str = str & " FROM         dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
      "                    dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO ON  " &
       "                   dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_DH_NHAP_PT AND " &
        "                  dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PTTT RIGHT OUTER JOIN " &
         "                 dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN " &
          "                dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
           "               dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND " &
            "               dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  " &
             "             dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
              "            dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN INNER JOIN " &
               "           dbo.PHIEU_BAO_TRI_CONG_VIEC ON " &
                "          dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI AND " &
                 "         dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV AND " &
                  "        dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN ON " &
                " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " &
                 "          AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND " &
                " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " &
                  "         AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " &
                "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT " &
    " WHERE     (PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = '" & grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString() & "') " &
    " AND (PHIEU_BAO_TRI_CONG_VIEC.MS_CV = " & grvLichSuMay.GetFocusedDataRow()("MS_CV").ToString() & ") " &
    " AND ( (ISNULL(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO.SL_TT,0)  > 0)  " &
    " OR  ( ISNULL( dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.GHI_CHU,'') <> '' ) ) " &
    " AND (PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = '" & grvLichSuMay.GetFocusedDataRow()("MS_BO_PHAN").ToString() & "')" &
                ") AS A LEFT JOIN CONG_NHAN ON A.NTT = CONG_NHAN.MS_CONG_NHAN"
            End If
        Else
            str = "SELECT DISTINCT C.MS_PT,C.MS_VI_TRI_PT, CONVERT(NVARCHAR(10), A.NGAY_HOAN_THANH,103) AS NGAY_THAY_THE, C.SL_TT, dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN  AS NGUOI_THAY_THE, C.VICT_NHA_THAU,  D.MS_PTTT AS MS_PT1  ,  dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU,C.GHI_CHU , CONVERT(INT,0) AS ID" &
            " FROM         dbo.CONG_NHAN RIGHT OUTER JOIN" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC A INNER JOIN" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI AND A.MS_CV = B.MS_CV AND " &
                          " A.MS_BO_PHAN = B.MS_BO_PHAN INNER JOIN" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET C ON B.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI AND B.MS_CV = C.MS_CV AND " &
                          " B.MS_PT = C.MS_PT AND B.MS_BO_PHAN = C.MS_BO_PHAN ON dbo.CONG_NHAN.MS_CONG_NHAN = C.NGUOI_THAY_THE LEFT OUTER JOIN" &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN" &
                          " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO D ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = D.MS_DH_NHAP_PT AND" &
                          " dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = D.MS_PTTT ON C.MS_PHIEU_BAO_TRI = D.MS_PHIEU_BAO_TRI AND C.MS_CV = D.MS_CV AND " &
                          " C.MS_BO_PHAN = D.MS_BO_PHAN And C.MS_PT = D.MS_PT " &
            " WHERE (C.SL_TT IS NOT NULL AND C.SL_TT >0 ) AND (A.MS_PHIEU_BAO_TRI='" & grvLichSuMay.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString() & "')  " &
                    " AND (A.MS_CV=" & grvLichSuMay.GetFocusedDataRow()("MS_CV").ToString() & ") " &
                    " AND (A.MS_BO_PHAN='" & grvLichSuMay.GetFocusedDataRow()("MS_BO_PHAN").ToString() & "') "

        End If
        Try

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLichSuPTTThe, grvLichSuPTTThe, SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0), False, False, False, True, True, Me.Name)
            RefreshHistoryPTThayThe()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub grvThongsoGSTTDL_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvThongsoGSTTDL.ValidateRow
        If BtnGhi15.Visible Then
            Try

                If Not IsNumeric(grvThongsoGSTTDL.GetFocusedDataRow()("CHU_KY_DO")) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuKyDo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    grvThongsoGSTTDL.FocusedColumn = grvThongsoGSTTDL.Columns("CHU_KY_DO")
                    e.Valid = False
                    Exit Sub
                Else
                    If Convert.ToInt32(grvThongsoGSTTDL.GetFocusedDataRow()("CHU_KY_DO")) <= 0 Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuKyDo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        grvThongsoGSTTDL.FocusedColumn = grvThongsoGSTTDL.Columns("CHU_KY_DO")
                        e.Valid = False
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grvTaiLieuTS_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvTaiLieuTS.InitNewRow
        grvTaiLieuTS.SetFocusedRowCellValue("MS_MAY", ucDMTBi.txtMS_MAY.Text)
        grvTaiLieuTS.SetFocusedRowCellValue("TEN_TAI_LIEU", " ")

    End Sub

    Private Sub grvTaiLieuTS_DoubleClick(sender As Object, e As EventArgs) Handles grvTaiLieuTS.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowDoubleClick(view, pt)
    End Sub

    Private Sub DoRowDoubleClick(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal pt As Point)
        Try
            If btnGhi1.Visible Then
                Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
                If info.InRow OrElse info.InRowCell Then
                    If info.Column.FieldName = "NOI_LUU_TRU" Then
                        OFDTaiLieuMay.Multiselect = True
                        OFDTaiLieuMay.ShowDialog()
                    End If
                End If
            Else
                BtnXemTL_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grvThongSoMay_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvThongSoMay.ValidateRow

        If btnGhi1.Visible Then
            If Not IsDBNull(grvThongSoMay.GetFocusedDataRow()(1)) And IsDBNull(grvThongSoMay.GetFocusedDataRow()("GIA_TRI")) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT36", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If

            If grvThongSoMay.GetFocusedDataRow()("GIA_TRI").ToString() <> "" Then
                Dim tb As New DataTable()
                tb = grdThongSoMay.DataSource
                If tb.Columns("GIA_TRI").MaxLength < grvThongSoMay.GetFocusedDataRow()("GIA_TRI").ToString().Length Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiaTriMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    grvThongSoMay.FocusedColumn = grvThongSoMay.Columns("GIA_TRI")
                    e.Valid = False
                    Exit Sub
                End If
            End If
            If grvThongSoMay.GetFocusedDataRow()("GIA_TRI_MIN").ToString() <> "" Then
                If Not IsNumeric(grvThongSoMay.GetFocusedDataRow()("GIA_TRI_MIN")) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PhaiNhapSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    grvThongSoMay.FocusedColumn = grvThongSoMay.Columns("GIA_TRI_MIN")
                    e.Valid = True
                    Exit Sub
                End If
            End If


            If grvThongSoMay.GetFocusedDataRow()("GIA_TRI_MAX").ToString() <> "" Then
                If Not IsNumeric(grvThongSoMay.GetFocusedDataRow()("GIA_TRI_MAX")) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PhaiNhapSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    grvThongSoMay.FocusedColumn = grvThongSoMay.Columns("GIA_TRI_MAX")
                    e.Valid = True
                    Exit Sub
                End If
            End If


            If Convert.ToDouble(grvThongSoMay.GetFocusedDataRow()("GIA_TRI_MIN").ToString()) > Convert.ToDouble(grvThongSoMay.GetFocusedDataRow()("GIA_TRI_MAX").ToString()) Then

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgGiaTriMinLonHonGiaTriMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvThongSoMay.FocusedColumn = grvThongSoMay.Columns("GIA_TRI_MIN")
                e.Valid = True
                Exit Sub
            End If



            Dim dtTam As DataTable
            dtTam = CType(grdThongSoMay.DataSource, DataTable).Copy
            Dim result() As DataRow = dtTam.Select("MS_THONG_SO_MAY = '" & grvThongSoMay.GetFocusedDataRow()("MS_THONG_SO_MAY").ToString() & "' ")
            If result.Length > 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgTrungDuLieu", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvThongSoMay.FocusedColumn = grvThongSoMay.Columns("MS_THONG_SO_MAY")
                e.Valid = True
                Exit Sub
            End If


        End If
    End Sub

    Private Sub grvThongSoMay_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvThongSoMay.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvThongSoMay_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvThongSoMay.InitNewRow
        grvThongSoMay.SetFocusedRowCellValue("MS_MAY", ucDMTBi.txtMS_MAY.Text)
        grvThongSoMay.SetFocusedRowCellValue("GIA_TRI_MIN", 0)
        grvThongSoMay.SetFocusedRowCellValue("GIA_TRI_MAX", 0)
    End Sub

    Private Sub grvThongSoMay_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvThongSoMay.CellValueChanged
        Dim dtTableTam As DataTable
        Dim j As Integer = 0
        If e.Column.FieldName = "MS_THONG_SO_MAY" Then
            dtTableTam = New DataTable
            Dim Str As String = "SELECT DISTINCT TEN_DV_DO FROM THONG_SO_MAY INNER JOIN DON_VI_DO ON THONG_SO_MAY.MS_DV_DO =DON_VI_DO.MS_DV_DO  WHERE MS_THONG_SO_MAY='" & grvThongSoMay.GetFocusedDataRow()("MS_THONG_SO_MAY") & "'"
            dtTableTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))

            While j <= dtTableTam.Rows.Count - 1
                grvThongSoMay.SetFocusedRowCellValue("TEN_DV_DO", dtTableTam.Rows(j).Item(0).ToString)
                j = j + 1
            End While
        End If
    End Sub

    Private Sub grvHuHong_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvHuHong.FocusedRowChanged
        Try
            _SourceCause.Filter = "PROBLEM_ID='" + grvHuHong.GetFocusedDataRow()("PROBLEM_ID") + "' "

            grdNguyenNhan.DataSource = CType(_SourceCause.DataSource, DataTable)
            grvNguyenNhan_FocusedRowChanged(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub grvNguyenNhan_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvNguyenNhan.FocusedRowChanged
        Try
            If grvNguyenNhan.RowCount > 0 Then
                _SourceRemedy.Filter = " CAUSE_ID='" + grvNguyenNhan.GetFocusedDataRow()("CAUSE_ID") + "'"
            Else
                _SourceRemedy.Filter = " CAUSE_ID IS NULL"
            End If
            grdPP.DataSource = CType(_SourceRemedy.DataSource, DataTable)
        Catch ex As Exception
            grdPP.DataSource = DBNull.Value
        End Try
    End Sub

    Private Sub txtSearchLS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchLS.KeyDown
        Try
            If (e.KeyCode <> 13) Then Exit Sub
            Commons.Modules.ObjSystems.HTimXtraTreeList(txtSearchLS.Text, tlClass, "MS_BO_PHAN", "TEN_BO_PHAN", arrTim)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grvChuKiHC_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvChuKiHC.ValidateRow
        If Commons.Modules.SQLString = "" Then
            Commons.Modules.SQLString = "0Kiem"
            If CheckData(e.RowHandle) = True Then
                e.Valid = False
                Exit Sub
            End If
        End If
        Commons.Modules.SQLString = ""
        If btnGhi2.Visible = False Then Exit Sub

        If IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) And
            IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI")) And
            IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI")) And
            IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI")) And
            IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_DV_TG")) And
            IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KT")) And
            IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD")) Then Exit Sub


        If IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_DUNG_CU_DO_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If
        If String.IsNullOrEmpty(grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI").ToString().Trim()) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_DUNG_CU_DO_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If

        If IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI")) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_DUNG_CU_DO_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If

        If String.IsNullOrEmpty(grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI").ToString().Trim()) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_DUNG_CU_DO_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If

        If Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) And IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI")) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT8", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        ElseIf IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) And Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI")) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT9", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If

        If IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI")) And IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI")) And IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD")) And IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KT")) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT53", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If

        If (Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI")) Or Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI")) Or Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD")) Or Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD"))) And IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_DV_TG")) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT11", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If

        Dim tb As New DataTable


        If IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI")) Then

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDataNull", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            grvChuKiHC.FocusedColumn = grvChuKiHC.Columns("MS_VI_TRI")
            e.Valid = False
            Exit Sub
        Else

            tb = CType(grdChuKiHC.DataSource, DataTable)
            If tb.Columns("MS_VI_TRI").MaxLength < grvChuKiHC.GetFocusedDataRow()("MS_VI_TRI").ToString.Length Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMSViTriMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grvChuKiHC.FocusedColumn = grvChuKiHC.Columns("MS_VI_TRI")
                e.Valid = False
                Exit Sub
            End If
        End If


        If Not IsNumeric(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI")) And Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) And grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI").ToString() <> "" Then

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT13", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        ElseIf grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI").ToString() <> "" Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI").ToString()) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
            Try
                If Convert.ToInt32(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NOI").ToString()) <= 0 Then
                    grvChuKiHC.SetFocusedRowCellValue("CHU_KY_HC_NOI", Nothing)
                End If
            Catch ex As Exception

            End Try


        End If



        If Not IsNumeric(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI").ToString()) And Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) And grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI").ToString() <> "" Then

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT14", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        ElseIf grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI").ToString() <> "" Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI").ToString()) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
            Try
                If Convert.ToInt32(grvChuKiHC.GetFocusedDataRow()("CHU_KY_HC_NGOAI").ToString()) <= 0 Then
                    grvChuKiHC.SetFocusedRowCellValue("CHU_KY_HC_NGOAI", Nothing)
                End If
            Catch
            End Try
        End If

        If Not IsNumeric(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD")) And Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) And grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD").ToString() <> "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgABC", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        ElseIf grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD").ToString() <> "" Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD").ToString()) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
            Try
                If Convert.ToInt32(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KD").ToString()) <= 0 Then
                    grvChuKiHC.SetFocusedRowCellValue("CHU_KY_KD", Nothing)
                End If
            Catch ex As Exception

            End Try


        End If

        If Not IsNumeric(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KT")) And Not IsDBNull(grvChuKiHC.GetFocusedDataRow()("MS_PT")) And grvChuKiHC.GetFocusedDataRow()("CHU_KY_KT").ToString() <> "" Then

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDEF", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        ElseIf grvChuKiHC.GetFocusedDataRow()("CHU_KY_KT").ToString() <> "" Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KT").ToString()) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
            Try
                If Convert.ToInt32(grvChuKiHC.GetFocusedDataRow()("CHU_KY_KT").ToString()) <= 0 Then
                    grvChuKiHC.SetFocusedRowCellValue("CHU_KY_KT", Nothing)
                End If
            Catch ex As Exception
            End Try
        End If


        tb = New DataTable()
        tb = CType(grdChuKiHC.DataSource, DataTable)
        If tb.Columns("GHI_CHU").MaxLength < grvChuKiHC.GetFocusedDataRow()("GHI_CHU").ToString.Length Then

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhiChuMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If


    End Sub

    Private Sub grvChuKiHC_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvChuKiHC.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvChuKiHC_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvChuKiHC.InitNewRow
        grvChuKiHC.SetFocusedRowCellValue("GHI_CHU", "ADD")
    End Sub

    Private Sub grvLoaiBTPN_CV_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvLoaiBTPN_CV.FocusedRowChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        If Tabthietbi.SelectedTabPage.Name <> "tabLichBTDKy" Then Exit Sub


        If grvLoaiBTPN_CV.RowCount = 0 Then Exit Sub
        Dim str As String = ""
        If Not btnThemsua3.Visible Then
            Try
                Dim dtReader1 As SqlDataReader
                Dim bCo As Boolean = False
                For i As Integer = 0 To grvLoaiBTPN_PT.RowCount - 1
                    str = "select  MS_MAY FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT='" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_LOAI_BT") & "' AND MS_CV='" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_CV") & "' AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetDataRow(i)("MS_PT") & "'"
                    dtReader1 = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While dtReader1.Read
                        bCo = True
                    End While
                    dtReader1.Close()
                    If bCo Then
                        str = "UPDATE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " SET SO_LUONG='" & grvLoaiBTPN_PT.GetDataRow(i)("SO_LUONG") &
                        "' WHERE MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' AND MS_LOAI_BT ='" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_LOAI_BT") & "' AND MS_CV ='" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_CV") & "' AND MS_BO_PHAN='" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_BO_PHAN") & "' AND MS_PT='" & grvLoaiBTPN_PT.GetDataRow(i)("MS_PT") & "'"
                    Else
                        str = "INSERT INTO  MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " (MS_MAY,MS_LOAI_BT,MS_CV,MS_BO_PHAN,TEN_LOAI_VT,MS_PT,TEN_PT,TEN_PT_VIET,SO_LUONG,QUY_CACH,DA_CHON) VALUES(N'" &
                                            ucDMTBi.txtMS_MAY.Text & "','" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_LOAI_BT") & "','" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_CV") & "','" & grvLoaiBTPN_CV.GetDataRow(e.PrevFocusedRowHandle)("MS_BO_PHAN") & "',N'" & grvLoaiBTPN_PT.GetDataRow(i)("TEN_LOAI_VT") & "','" & grvLoaiBTPN_PT.GetDataRow(i)("MS_PT") & "',N'" & grvLoaiBTPN_PT.GetDataRow(i)("MS_PT") & "',N'" & grvLoaiBTPN_PT.GetDataRow(i)("TEN_PT_VIET") & "','" & grvLoaiBTPN_PT.GetDataRow(i)("SO_LUONG") & "',N'" & grvLoaiBTPN_PT.GetDataRow(i)("QUY_CACH") & "','" & 1 & "')"
                    End If
                    bCo = False
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Next
            Catch ex As Exception
            End Try
        End If

        grdLoaiBTPN_PT.DataSource = System.DBNull.Value
        Dim tb As New DataTable()
        Try
            str = " SELECT B.TEN_LOAI_VT, B.MS_PT, B.TEN_PT, B.TEN_PT_VIET, SL_MAX, B.SO_LUONG, " &
                    " CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN C.TEN_1 ELSE C.TEN_1 END AS DVT, B.QUY_CACH,GHI_CHU_BTPN  " &
                    " FROM dbo.DON_VI_TINH AS C INNER JOIN dbo.IC_PHU_TUNG AS D ON C.DVT = D.DVT INNER JOIN " &
                    " MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG" & Commons.Modules.UserName & " AS B ON D.MS_PT = B.MS_PT LEFT JOIN " &
                    " (SELECT MS_MAY, MS_BO_PHAN, SUM(SO_LUONG) AS SL_MAX , MS_PT FROM dbo.CAU_TRUC_THIET_BI_PHU_TUNG " &
                    " GROUP BY MS_MAY, MS_BO_PHAN, MS_PT HAVING (MS_MAY = N'" & ucDMTBi.txtMS_MAY.Text & "') AND (MS_BO_PHAN = N'" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "')) AS A  " &
                    " ON B.MS_MAY = A.MS_MAY AND B.MS_BO_PHAN = A.MS_BO_PHAN  AND B.MS_PT = A.MS_PT " &
                    " WHERE     (B.MS_MAY = N'" & ucDMTBi.txtMS_MAY.Text & "') AND (B.MS_LOAI_BT = '" & Me.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT") & "') AND (B.MS_CV = '" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV") & "') AND (B.MS_BO_PHAN = '" & grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN") & "')"

            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        Catch ex As Exception
        End Try
        If tb.Rows.Count = 0 Then
            tb = New MAYController().GetMAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG(ucDMTBi.txtMS_MAY.Text, Me.grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT"), grvLoaiBTPN_CV.GetFocusedDataRow()("MS_CV"), Commons.Modules.TypeLanguage, grvLoaiBTPN_CV.GetFocusedDataRow()("MS_BO_PHAN"))
        End If


        TaoLuoiBTPNPT(tb)

    End Sub

    Private Sub TaoLuoiBTPNPT(dtTmp As DataTable)
        If btnThemsua3.Visible Then
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBTPN_PT, grvLoaiBTPN_PT, dtTmp, False, True, True, True, True, "frmThongtinthietbi")
        Else
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBTPN_PT, grvLoaiBTPN_PT, dtTmp, True, True, True, True, True, "frmThongtinthietbi")
        End If

        Try
            Me.grvLoaiBTPN_PT.Columns("TEN_PT").OptionsColumn.ReadOnly = True
            Me.grvLoaiBTPN_PT.Columns("SL_MAX").OptionsColumn.ReadOnly = True
            Me.grvLoaiBTPN_PT.Columns("TEN_PT_VIET").OptionsColumn.ReadOnly = True
            Me.grvLoaiBTPN_PT.Columns("MS_PT").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("DVT").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("QUY_CACH").OptionsColumn.ReadOnly = True
            grvLoaiBTPN_PT.Columns("TEN_LOAI_VT").OptionsColumn.ReadOnly = True
            Me.grvLoaiBTPN_PT.Columns("TEN_PT_VIET").Visible = False
            grvLoaiBTPN_PT.Columns("GHI_CHU_BTPN").Visible = False
        Catch

        End Try
        RefeshLanguage3()
    End Sub

    Private Sub grvLoaiBTPN_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvLoaiBTPN.ValidateRow
        Dim returnValue As Boolean
        Try
            returnValue = Convert.IsDBNull(grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT"))
        Catch ex As Exception
            returnValue = False
        End Try
        If returnValue Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT3", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If
        If Date.Parse(grvLoaiBTPN.GetFocusedDataRow()("NGAY_CUOI")) > Now() Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayLonHonHienTai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If
        If grvLoaiBTPN.GetFocusedDataRow()("SO_NGAY").ToString() <> "" Then
            If Not IsNumeric(grvLoaiBTPN.GetFocusedDataRow()("SO_NGAY")) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PhaiNhapSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            Else
                Dim iTmp As Integer = CType(grvLoaiBTPN.GetFocusedDataRow()("SO_NGAY"), Integer)
                If iTmp.ToString() <> grvLoaiBTPN.GetFocusedDataRow()("SO_NGAY") Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PhaiNhapSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Valid = False
                    Exit Sub
                End If
            End If
        End If


        Dim dt As New DataTable
        dt = CType(grdLoaiBTPN.DataSource, DataTable)
        If (grvLoaiBTPN.FocusedRowHandle < 0) Then
            If dt.Select().AsEnumerable().Any(Function(x) x("MS_LOAI_BT").ToString().Trim().Equals(grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT").ToString())) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
        Else
            Dim ckDuplicate = dt.Select().AsEnumerable().GroupBy(Function(x) New With {Key .MS_LOAI_BT = x("MS_LOAI_BT").ToString()}).Where(Function(x) x.Count() > 1).Select(Function(x) New With {Key .MS_LOAI_BT = x.First()("MS_LOAI_BT")})
            If (ckDuplicate.Count() > 0) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", Commons.Modules.TypeLanguage) & Environment.NewLine & ckDuplicate.First().MS_LOAI_BT, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Valid = False
                Exit Sub
            End If
        End If



    End Sub

    Private Sub grvLoaiBTPN_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvLoaiBTPN.InitNewRow
        grvLoaiBTPN.SetFocusedRowCellValue("NGAY_CUOI", ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date)
    End Sub

    Private Sub grvLoaiBTPN_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvLoaiBTPN.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvLoaiBTPN_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvLoaiBTPN.FocusedRowChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub

        If Tabthietbi.SelectedTabPage.Name = "tabLichBTDKy" Then

            If grvLoaiBTPN.RowCount = 0 Then Exit Sub
            If grvLoaiBTPN.FocusedRowHandle < 0 Then Exit Sub
            Dim MS_LOAI_BT As Integer = 0
            MS_LOAI_BT = IIf(IsDBNull(grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")), 0, grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT"))
            grdLoaiBTPN_CV.DataSource = System.DBNull.Value
            grdLoaiBTPN_PT.DataSource = System.DBNull.Value
            Dim tb As New DataTable
            Dim str As String = ""
            Try
                str = "SELECT MS_MAY,MS_LOAI_BT,MS_CV, MS_BO_PHAN, (MS_BO_PHAN + ' - ' + TEN_BO_PHAN ) AS TEN_BO_PHAN,MO_TA_CV,KY_HIEU_CV FROM MAY_LOAI_BTPN_CONG_VIEC" &
                        Commons.Modules.UserName & " WHERE MS_LOAI_BT='" & MS_LOAI_BT & "' ORDER BY ISNULL(STT, 999) "
                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            Catch ex As Exception
            End Try
            If tb.Rows.Count = 0 Then
                tb = New MAYController().GetMAY_LOAI_BTPN_CONG_VIEC(ucDMTBi.txtMS_MAY.Text, MS_LOAI_BT)
            End If

            Commons.Modules.SQLString = "0LOAD"
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBTPN_CV, grvLoaiBTPN_CV, tb, False, True, True, True, True, "frmThongtinthietbi")
            Commons.Modules.SQLString = ""
            grvLoaiBTPN_CV.Columns(0).Visible = False
            grvLoaiBTPN_CV.Columns(1).Visible = False
            grvLoaiBTPN_CV.Columns(2).Visible = False
            grvLoaiBTPN_CV.Columns("MS_BO_PHAN").Visible = False

            grvLoaiBTPN_CV.Columns("TEN_BO_PHAN").Width = 150
            grvLoaiBTPN_CV.Columns("MO_TA_CV").Width = 250
            grvLoaiBTPN_CV.Columns("KY_HIEU_CV").Width = 80

            grvLoaiBTPN_CV_FocusedRowChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub grvLoaiBTPN_PT_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvLoaiBTPN_PT.ValidateRow
        If IsDBNull(grvLoaiBTPN_PT.GetFocusedDataRow()("SO_LUONG")) Then Exit Sub
        If Not IsNumeric(grvLoaiBTPN_PT.GetFocusedDataRow()("SO_LUONG")) And Not IsDBNull(grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT")) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT19", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Valid = False
            Exit Sub
        End If

        Dim sql As String

        sql = "SELECT dbo.LOAI_VT.VAT_TU FROM dbo.IC_PHU_TUNG INNER JOIN " &
                        " dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT WHERE " &
                        " MS_PT = '" + grvLoaiBTPN_PT.GetFocusedDataRow()("MS_PT").ToString() + "'"
        Dim VTu As Boolean
        Try
            VTu = Boolean.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        Catch ex As Exception
            VTu = False
        End Try
        If VTu = False Then
            If (String.IsNullOrEmpty(grvLoaiBTPN_PT.GetFocusedDataRow()("SL_MAX").ToString())) Then
                If CType(grvLoaiBTPN_PT.GetFocusedDataRow()("SO_LUONG"), Integer) > 0 Then

                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GiaTriLonHonGTMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Valid = False
                    Exit Sub
                End If
            Else
                If CType(grvLoaiBTPN_PT.GetFocusedDataRow()("SO_LUONG"), Integer) > CType(grvLoaiBTPN_PT.GetFocusedDataRow()("SL_MAX"), Integer) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GiaTriLonHonGTMax", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Valid = False
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grvLoaiBTPN_PT_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvLoaiBTPN_PT.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvCTTB_CV_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvCTTB_CV.CellValueChanged
        Dim _i As Integer = 0
        If e.Column.FieldName = "ACTIVE" Then

            Dim str As String = ""
            If e.Value = False Then
                str = "SELECT COUNT(*) FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_MAY='" & ucDMTBi.txtMS_MAY.Text & "' AND MS_CV='" & grvCTTB_CV.GetFocusedDataRow()("MS_CV") & "'"
                _i = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                If _i > 0 Then
                    str = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TonTaiCVPBT", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If str = vbNo Then
                        grvCTTB_CV.SetRowCellValue(e.RowHandle, "ACTIVE", 1)

                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grvCTTB_CV_DoubleClick(sender As Object, e As EventArgs) Handles grvCTTB_CV.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowCVDoubleClick(view, pt)
    End Sub

    Private Sub DoRowCVDoubleClick(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal pt As Point)
        Try
            Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
            If info.InRow OrElse info.InRowCell Then
                If info.Column.FieldName = "PATH_HD" Then
                    If (BtnGhiCV_BP.Visible) Then
                        Dim opendialog As New OpenFileDialog
                        opendialog.Multiselect = False
                        If (opendialog.ShowDialog() <> DialogResult.OK) Then Exit Sub

                        Dim strPath_DH As String = ""
                        strPath_DH = ""
                        strDuongDan = opendialog.FileName

                        grvCTTB_CV.SetFocusedRowCellValue("PATH_HD", opendialog.FileName)
                    Else
                        Process.Start(grvCTTB_CV.GetFocusedDataRow()("PATH_HD").ToString)
                    End If

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Dim valueChanged As Boolean = False
    Private Sub grvMay_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) 'Handles grvMay.CellValueChanging
        If valueChanged = True Then Return
        If e.Column.FieldName <> "LUU_Y_SU_DUNG" Then Return
        valueChanged = True
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        View.SetRowCellValue(e.RowHandle, "LUU_Y_SU_DUNG", e.Value)

    End Sub


    Private Sub grvTaiLieuTS_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvTaiLieuTS.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub txtTimMay_EditValueChanging(sender As Object, e As Controls.ChangingEventArgs) Handles txtTimMay.EditValueChanging
        LocDuLieu()
    End Sub

    Private Sub tlHistory_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tlHistory.FocusedNodeChanged
        If (tlHistory.Nodes.Count < 0) Then
            Exit Sub
        End If
        Dim str As String = ""
        Dim strBoPhan As String = ""
        txtMayTT.Text = ""
        txtBoPhanTT.Text = ""

        Try
            grdLichSuMay.DataSource = Nothing
            grdLichSuPTTThe.DataSource = Nothing
        Catch ex1 As Exception
        End Try
        Try
            str = "drop table BO_PHAN" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.BO_PHAN" & Commons.Modules.UserName & " (MS_BO_PHAN NVARCHAR(50))"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        If tlHistory.FocusedNode("MS_BO_PHAN").ToString() <> ucDMTBi.txtMS_MAY.Text Then
            str = "insert into dbo.BO_PHAN" & Commons.Modules.UserName & " VALUES(N'" & tlHistory.FocusedNode("MS_BO_PHAN").ToString() & "')"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End If
        TaoTable(ucDMTBi.txtMS_MAY.Text, tlHistory.FocusedNode("MS_BO_PHAN").ToString())
        HienThiDuLieuLichSuThietBi()
        RefreshHistory()

    End Sub

    Private Sub grvThongsoGSTTDL_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvThongsoGSTTDL.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub



    Private Sub grvCTTB_CV_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles grvCTTB_CV.RowCellClick
        If grvCTTB_CV.FocusedColumn.Name.ToString.ToUpper <> "colCT_CVIEC".ToUpper Then Exit Sub
        Dim frmCTiet As New VietShape.frmChiTietCongViec
        Try

            If BtnGhiCV_BP.Visible Then frmCTiet.bView = False Else frmCTiet.bView = True
            frmCTiet.sTaiLieu = grvCTTB_CV.GetFocusedDataRow("PATH_HD").ToString
            frmCTiet.sTenCV = grvCTTB_CV.GetFocusedDataRow("MO_TA_CV").ToString
            frmCTiet.sThaoTac = grvCTTB_CV.GetFocusedDataRow("THAO_TAC").ToString
            frmCTiet.sTieuChuan = grvCTTB_CV.GetFocusedDataRow("TIEU_CHUAN_KT").ToString
            frmCTiet.sYeuCauDC = grvCTTB_CV.GetFocusedDataRow("YEU_CAU_DUNG_CU").ToString
            frmCTiet.sYeuCauNS = grvCTTB_CV.GetFocusedDataRow("YEU_CAU_NS").ToString
        Catch ex As Exception

        End Try
        If frmCTiet.ShowDialog = DialogResult.Cancel Then Exit Sub
    End Sub

    Private Sub grvThongsoGSTTDL_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles grvThongsoGSTTDL.RowCellClick
        If grvThongsoGSTTDL.FocusedColumn.Name.ToString.ToUpper <> "colCT_CVIEC".ToUpper Then Exit Sub
        Dim frmCTiet As New VietShape.frmChiTietCongViec
        Try
            If BtnGhi15.Visible Then frmCTiet.bView = False Else frmCTiet.bView = True

            frmCTiet.sTaiLieu = grvThongsoGSTTDL.GetFocusedDataRow("PATH_HD").ToString
            frmCTiet.sTenCV = grvThongsoGSTTDL.GetFocusedDataRow("TEN_TS_GSTT").ToString
            frmCTiet.sThaoTac = grvThongsoGSTTDL.GetFocusedDataRow("CACH_THUC_HIEN").ToString
            frmCTiet.sTieuChuan = grvThongsoGSTTDL.GetFocusedDataRow("TIEU_CHUAN_KT").ToString
            frmCTiet.sYeuCauDC = grvThongsoGSTTDL.GetFocusedDataRow("YEU_CAU_DUNG_CU").ToString
            frmCTiet.sYeuCauNS = grvThongsoGSTTDL.GetFocusedDataRow("YEU_CAU_NS").ToString
        Catch ex As Exception
        End Try
        If frmCTiet.ShowDialog = DialogResult.Cancel Then Exit Sub


    End Sub

    Private Sub grvCTTB_TS_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles grvCTTB_TS.RowCellClick
        If grvCTTB_TS.FocusedColumn.Name.ToString.ToUpper <> "colCT_CVIEC".ToUpper Then Exit Sub
        Dim frmCTiet As New VietShape.frmChiTietCongViec
        Try
            If BtnGhiTSGSTT_BP.Visible Then frmCTiet.bView = False Else frmCTiet.bView = True

            frmCTiet.sTaiLieu = grvCTTB_TS.GetFocusedDataRow("PATH_HD").ToString
            frmCTiet.sTenCV = grvCTTB_TS.GetFocusedDataRow("TEN_TS_GSTT").ToString
            frmCTiet.sThaoTac = grvCTTB_TS.GetFocusedDataRow("CACH_THUC_HIEN").ToString
            frmCTiet.sTieuChuan = grvCTTB_TS.GetFocusedDataRow("TIEU_CHUAN_KT").ToString
            frmCTiet.sYeuCauDC = grvCTTB_TS.GetFocusedDataRow("YEU_CAU_DUNG_CU").ToString
            frmCTiet.sYeuCauNS = grvCTTB_TS.GetFocusedDataRow("YEU_CAU_NS").ToString
        Catch ex As Exception
        End Try
        If frmCTiet.ShowDialog = DialogResult.Cancel Then Exit Sub
    End Sub

    Private Sub grvCTTB_TS_DoubleClick(sender As Object, e As EventArgs) Handles grvCTTB_TS.DoubleClick
        Try
            If BtnGhiTSGSTT_BP.Visible Then Exit Sub
            Process.Start(grvCTTB_TS.GetFocusedDataRow()("PATH_HD").ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grvThongsoGSTTDL_DoubleClick(sender As Object, e As EventArgs) Handles grvThongsoGSTTDL.DoubleClick
        Try
            If BtnGhi15.Visible Then Exit Sub
            Process.Start(grvThongsoGSTTDL.GetFocusedDataRow()("PATH_HD").ToString)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GrpTSGSTT_Enter(sender As Object, e As EventArgs) Handles GrpTSGSTT.Enter

    End Sub

    Private Sub tlClass_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tlClass.FocusedNodeChanged
        If (tlClass.Nodes.Count < 0) Then
            Exit Sub
        Else
            BindDataSource()
        End If
    End Sub



    Private Sub tvwCTTBi_CustomDrawNodeCell(sender As Object, e As CustomDrawNodeCellEventArgs) Handles tvwCTTBi.CustomDrawNodeCell, tlHistory.CustomDrawNodeCell, tlClass.CustomDrawNodeCell
        If e.Node.Level = 0 Then
            Dim foreBrush As Brush = New SolidBrush(e.Appearance.ForeColor)
            Dim backBrush As Brush = New SolidBrush(ColorTranslator.FromHtml("#3a9da4"))
            e.Graphics.FillRectangle(backBrush, e.Bounds)
            Dim vRect As New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            e.Graphics.DrawString(e.CellText, e.Appearance.Font, foreBrush, vRect, e.Appearance.GetStringFormat)
            e.Handled = True

        End If
    End Sub

    Private Sub Tabthietbi_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles Tabthietbi.SelectedPageChanged
        Try

            If txtM0.Text <> grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then ShowMAY()


            Select Case Tabthietbi.SelectedTabPageIndex
                Case 0
                    Dim tableTB As New DataTable
                    If grdMay Is Nothing Or grvMay.RowCount = 0 Then
                        ucDMTBi.Refesh()
                        txtM0.Text = ""
                    Else

                        If txtM0.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
                        'tableTB = CType(grdMay.DataSource, DataTable).Copy
                        'tableTB.DefaultView.RowFilter = " MS_MAY = '" + grvMay.GetFocusedRowCellValue("MS_MAY").ToString() + "' "
                        'tableTB = tableTB.DefaultView.ToTable()
                        'ucDMTBi.ShowMAY(tableTB)

                        txtM0.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                    End If

                Case 1
                    If txtM1.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    LoadCmbPT_BP()
                    If grvMay.GetFocusedRowCellValue("MS_MAY").ToString() = "" Then ShowTreeRootXtra("-1") Else ShowTreeRootXtra(grvMay.GetFocusedRowCellValue("MS_MAY").ToString())
                    If tvwCTTBi.AllNodesCount > 1 Then
                        Try
                            tvwCTTBi.SetFocusedNode(tvwCTTBi.Nodes(0))
                        Catch ex As Exception
                        End Try
                    End If
                    txtM1.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                Case 2
                    If txtM2.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    BindData3()
                    txtM2.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                Case 3
                    If txtM3.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    BindData5()
                    txtM3.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                Case 4
                    If txtM4.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    BindData2()
                    BindData1()
                    txtM4.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                    Dim dtRead As New DataTable
                    Dim SQL As String = "SELECT ISNULL(LUU_Y_SU_DUNG, '') LUU_Y_SU_DUNG FROM MAY WHERE MS_MAY=N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "'"
                    dtRead.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
                    txtLuuY.Text = IIf(dtRead.Rows.Count > 0, dtRead.Rows(0)("LUU_Y_SU_DUNG"), grvMay.GetFocusedDataRow()("LUU_Y_SU_DUNG"))
                Case 5
                    If txtM5.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    ClearHistory()
                    txtM5.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                Case 6
                    If txtM6.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString() Then Exit Sub
                    Cursor = Cursors.WaitCursor
                    ClearHeChuyenGia()
                    txtM6.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString()
                Case 7
                    If Not grdReport.DataSource Is Nothing Then Exit Sub
                    Dim dt As New DataTable
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT REPORT_NAME, CASE " & Commons.Modules.TypeLanguage &
                    " WHEN 0 THEN TEN_REPORT_VIET WHEN 1 THEN TEN_REPORT_ANH ELSE TEN_REPORT_HOA END AS TEN_REPORT " &
                    " FROM  DS_REPORT WHERE  LOAI_REPORT = 6 AND STT < 100"))
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdReport, grvReport, dt, False, True, True, True, True, Me.Name)
                    grvReport.Columns("REPORT_NAME").Visible = False
            End Select
            arrTim.Clear()
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub txtTimMay_EditValueChanged(sender As Object, e As EventArgs) Handles txtTimMay.EditValueChanged
        lblTongSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTongSo", Commons.Modules.TypeLanguage) & " : " & grvMay.RowCount

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub grvMay_Click(sender As Object, e As EventArgs) Handles grvMay.Click
        If grvMay.RowCount > 1 Then Exit Sub
        txtM0.Text = ""
        grvMay_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub ucDMTBi_Load(sender As Object, e As EventArgs) Handles ucDMTBi.Load

    End Sub



    Private Sub optHL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optHL.SelectedIndexChanged
        If Commons.Modules.SQLString = "0LOADHL" Then Exit Sub
        ShowTreeRootXtra(grvMay.GetFocusedRowCellValue("MS_MAY").ToString())
    End Sub

    Private Sub CboChange()
        If flag = True Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        LoadMay()

        If grvMay.RowCount <= 0 Then
            grdChuKiHC.DataSource = System.DBNull.Value
            grdLoaiBTPN_CV.DataSource = System.DBNull.Value
            grdTaiLieuTS.DataSource = System.DBNull.Value
            grdLoaiBTPN_PT.DataSource = System.DBNull.Value
            grdLoaiBTPN.DataSource = System.DBNull.Value
            grdThongSoBP.DataSource = System.DBNull.Value
            grdThongSoMay.DataSource = System.DBNull.Value
            grdCTTB_PT.DataSource = System.DBNull.Value
            tvwCTTBi.Nodes.Clear()
            tvwCTTBi.Refresh()
            tvwCTTBi.RefreshDataSource()
        End If
        flag_nhom = False
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CboNLD_EditValuedChanged(sender As Object, e As MVControl.ucComboboxTreeList.EventArgs) Handles CboNLD.EditValuedChanged
        CboChange()
    End Sub

    Private Sub CboNhomthietbi_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboNhomthietbi.EditValueChanged, CboLoaithietbi.EditValueChanged, cboLine.EditValueChanged
        CboChange()
    End Sub

    Public Sub txtTimMay_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimMay.KeyDown
        If e.KeyCode <> 13 Then Exit Sub
        LocDuLieu()
    End Sub




    Private Sub CboPT_BP_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles CboPT_BP.EditValueChanging
        If Not BtnGhi4.Visible Then Exit Sub
        If flagPTCha Then Exit Sub

        Dim Str As String = "SELECT * FROM PHIEU_BAO_TRI_CONG_vIEC_PHU_TUNG T1 INNER JOIN PHIEU_BAO_TRI T2 ON T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI WHERE T2.MS_MAY = '" & ucDMTBi.txtMS_MAY.Text & "'  AND T1.MS_BO_PHAN = '" & txtMS_BO_PHAN.Text & "' AND T1.MS_PT = '" & e.OldValue & "'"
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))
        If (dtTmp.Rows.Count > 0) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgMSPhuTungChaDaPhatSinhBenPBT", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            e.Cancel = True
        End If

        Dim sSql As String
        sSql = "Select * FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_PT = '" & e.NewValue & "' AND MS_BO_PHAN = '" & txtMS_BO_PHAN.Text & "' AND MS_MAY = '" & ucDMTBi.txtMS_MAY.Text & "' "

        dtTmp = New DataTable()

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        If dtTmp.Rows.Count > 0 Then
            e.Cancel = True
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgPhuTungDaDuocChonTrongChiTiet", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub BtnTimPTCmb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimPTCmb.Click
        Try
            Dim frm As New frmDanhSachPhieuBT
            Commons.Modules.SQLString = ""
            frm.iLoaiForm = 3

            Dim sSql As String

            sSql = " SELECT T1.MS_PT, T1.TEN_PT, T1.TEN_PT_VIET, T1.QUY_CACH, T1.MS_PT_NCC, T1.MS_PT_CTY, CASE 0 WHEN 0 THEN T8.TEN_1  WHEN 1 THEN T8.TEN_2 ELSE T8.TEN_3 END AS TEN_DVT , " &
                            " CASE 0 WHEN 0 THEN T3.TEN_LOAI_VT_TV WHEN 1 THEN T3.TEN_LOAI_VT_TA ELSE T3.TEN_LOAI_VT_TH END AS TEN_LOAI_VT " &
                            " FROM         dbo.IC_PHU_TUNG AS T1 INNER JOIN " &
                            "                       dbo.LOAI_VT AS T3 ON T1.MS_LOAI_VT = T3.MS_LOAI_VT INNER JOIN " &
                            "                       dbo.IC_PHU_TUNG_LOAI_MAY AS T4 ON T1.MS_PT = T4.MS_PT INNER JOIN " &
                            "                       dbo.LOAI_MAY AS T5 ON T4.MS_LOAI_MAY = T5.MS_LOAI_MAY INNER JOIN " &
                            "                       dbo.NHOM_MAY AS T6 ON T5.MS_LOAI_MAY = T6.MS_LOAI_MAY INNER JOIN " &
                            "                       dbo.MAY AS T7 ON T6.MS_NHOM_MAY = T7.MS_NHOM_MAY INNER JOIN " &
                            "                       dbo.DON_VI_TINH AS T8 ON T1.DVT = T8.DVT " &
                            " WHERE     (T1.ACTIVE_PT = 1) AND (T5.MS_LOAI_MAY = '" & ucDMTBi.cboMS_LOAI_MAY.EditValue & "') " &
                            " AND (T3.VAT_TU = 0) AND (T7.MS_MAY = N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "') " &
                            " UNION " &
                            " SELECT     T1.MS_PT, T1.TEN_PT, T1.TEN_PT_VIET, T1.QUY_CACH, T1.MS_PT_NCC, T1.MS_PT_CTY, T3.TEN_1, T4.TEN_LOAI_VT_TV " &
                            " FROM         dbo.CAU_TRUC_THIET_BI AS T2 INNER JOIN " &
                            "                       dbo.IC_PHU_TUNG AS T1 ON T2.MS_PT = T1.MS_PT INNER JOIN " &
                            "                       dbo.DON_VI_TINH AS T3 ON T1.DVT = T3.DVT INNER JOIN " &
                            "                       dbo.LOAI_VT AS T4 ON T1.MS_LOAI_VT = T4.MS_LOAI_VT " &
                            " WHERE     (T2.MS_MAY = N'" & grvMay.GetFocusedRowCellValue("MS_MAY").ToString() & "') " &
                            " AND (T2.MS_BO_PHAN = N'" + Commons.Modules.ObjSystems.SplitString(txtMS_BO_PHAN.Text) + "')  " &
                            " ORDER BY T1.MS_PT, T1.TEN_PT"

            frm.DSPhieu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            frm.ShowDialog()
            If Commons.Modules.SQLString <> "" Then
                CboPT_BP.EditValue = Commons.Modules.SQLString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private arrTim As New List(Of String)()

    Private Sub txtTimThietBi_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimThietBi.KeyDown
        Try
            If (e.KeyCode <> 13) Then Exit Sub
            Commons.Modules.ObjSystems.HTimXtraTreeList(txtTimThietBi.Text, tvwCTTBi, "MS_BO_PHAN", "TEN_BO_PHAN", arrTim)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtTimKiemHistory_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTimKiemHistory.KeyDown
        Try
            If (e.KeyCode <> 13) Then Exit Sub
            Commons.Modules.ObjSystems.HTimXtraTreeList(txtTimKiemHistory.Text, tlHistory, "MS_BO_PHAN", "TEN_BO_PHAN", arrTim)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnCopyLoaiBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyLoaiBT.Click
        Try
            If (grvLoaiBTPN.RowCount <> 0) Then

                Dim vtbTam = New DataTable
                vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spCheckMayLoaiBaoTriDuoi", grvMay.GetFocusedDataRow()("MS_MAY"), grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")))
                If (vtbTam.Rows.Count <> 0) Then
                    Dim frm As New frmChonCopyLoaiBaoTriCon
                    frm.MS_MAY = grvMay.GetFocusedDataRow()("MS_MAY")
                    frm.MS_LOAI_BT = grvLoaiBTPN.GetFocusedDataRow()("MS_LOAI_BT")
                    If (frm.ShowDialog() = DialogResult.OK) Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCopyLoaiBTThanhCong", Commons.Modules.TypeLanguage))
                        'Bind lại data
                        BindData3()
                    End If
                Else
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoLoaiBaoTriCapDuoi", Commons.Modules.TypeLanguage))
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuaChonLoaiBaoTriCuaMay", Commons.Modules.TypeLanguage))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub InVB()

        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx")
        If sPath = "" Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()

        Try
            Dim TCot As Integer = ucDMTBi.grvChung.Columns.Count
            Dim TDong As Integer = ucDMTBi.grvChung.RowCount
            Dim Dong As Integer = 1

            ucDMTBi.grdChung.ExportToXlsx(sPath)

            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "",
                 False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)

            Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)


            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong)

            Dim title As Excel.Range
            Dim SCot As Integer
            SCot = 7
            Dim stmp As String = ""
            Dong = 2
            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "sSTLLichSuThietBi", Commons.Modules.TypeLanguage)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, TCot - 1, "@", 10, False, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, TCot - 1, Dong + 3, TCot)
            title.Font.Italic = True
            Dong += 1
            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "sPhienBanLichSuThietBi", Commons.Modules.TypeLanguage)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, TCot - 1, "@", 10, False, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter)
            Dong += 1
            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "sNgayApDungLichSuThietBi", Commons.Modules.TypeLanguage)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, TCot - 1, "@", 10, False, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter)

            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, SCot)))


            Dong += 1

            stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, SCot - 4)

            Dong += 1

            stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong - 1, 4, "@", 10, True, True, Dong, 6)




            Dong += 1
            'Dong += 1

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot)
            title.Font.Bold = True
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, False,
             True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100)

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 15

            'set width for all columns'
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "##", True, Dong + 1, 1, Dong, 1)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 18, "dd/MM/yyyy", True, Dong + 1, 2, Dong, 2)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 40, "@", True, Dong + 1, 3, Dong, 3)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 23, "@", True, Dong + 1, 4, Dong, 6)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", True, Dong + 1, 7, Dong, 7)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 19, "@", True, Dong + 1, 8, Dong, 12)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", True, Dong + 1, 13, Dong, 16)

            excelWorkSheet.Rows.AutoFit()

            excelWorkbook.Save()
            excelApplication.Visible = True
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)

            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        Catch ex As Exception
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Me.Cursor = Cursors.[Default]

    End Sub
#Region "Hyperlink"

    Private Sub CreateMenuNewPBT(ByVal grd As DevExpress.XtraGrid.GridControl)
        Try
            For Each conTrol In grd.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try

        Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grd.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        AddHandler grv.ShowGridMenu, AddressOf grv_ShowGridMenu

        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd

        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        AddHandler popup.BeforePopup, AddressOf PopupMenu_BeforePopup
        popup.BeginUpdate()

        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkNewPhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim mnuNewPhieuBaoTri As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuNewPhieuBaoTri.Name = "mnuNewPhieuBaoTri"

        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuNewPhieuBaoTri})
        BarManager.EndUpdate()
    End Sub

    Private Sub CreateMenuCV(ByVal grd As DevExpress.XtraGrid.GridControl)
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
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        AddHandler popup.BeforePopup, AddressOf PopupMenu_BeforePopup
        popup.BeginUpdate()
        BarManager.SetPopupContextMenu(grd, popup)
        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkCongViec", Commons.Modules.TypeLanguage)
        Dim mnuCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCongViec.Name = "mnuCongViec"
        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec})
        BarManager.EndUpdate()
    End Sub

    Private Sub CreateMenuPBT(ByVal grd As DevExpress.XtraGrid.GridControl)
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
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        AddHandler popup.BeforePopup, AddressOf PopupMenu_BeforePopup
        popup.BeginUpdate()

        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim mnuPhieuBaoTri As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuPhieuBaoTri.Name = "mnuPhieuBaoTri"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkCongViec", Commons.Modules.TypeLanguage)
        Dim mnuCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCongViec.Name = "mnuCongViec"


        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec, mnuPhieuBaoTri})
        BarManager.EndUpdate()
    End Sub


    Private Sub CreateMenuPT(ByVal grd As DevExpress.XtraGrid.GridControl)
        Try
            For Each conTrol In grd.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grd.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        AddHandler grv.ShowGridMenu, AddressOf grv_ShowGridMenu

        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()
        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        AddHandler popup.BeforePopup, AddressOf PopupMenu_BeforePopup
        popup.BeginUpdate()

        BarManager.SetPopupContextMenu(grd, popup)
        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhuTung", Commons.Modules.TypeLanguage)
        Dim mnuPhuTung As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuPhuTung.Name = "mnuPhuTung"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuInLichSuPhuTung", Commons.Modules.TypeLanguage)
        Dim mnuInLichSuPhuTung As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuInLichSuPhuTung.Name = "mnuInLichSuPhuTung"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuInLichSuMuaHang", Commons.Modules.TypeLanguage)
        Dim mnuInLichSuMuaHang As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuInLichSuMuaHang.Name = "mnuInLichSuMuaHang"

        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuPhuTung, mnuInLichSuPhuTung, mnuInLichSuMuaHang})
        BarManager.EndUpdate()
    End Sub

    Private Sub CreateMenuGSTT(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grd1 As DevExpress.XtraGrid.GridControl)
        Try
            For Each conTrol In grd.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    GoTo 1
                End If
            Next
        Catch ex As Exception
        End Try
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()
        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        AddHandler popup.BeforePopup, AddressOf PopupMenu_BeforePopup
        popup.BeginUpdate()

        BarManager.SetPopupContextMenu(grd, popup)
        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTT", Commons.Modules.TypeLanguage)
        Dim mnuGSTT As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuGSTT.Name = "mnuGSTT"
        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuGSTT})
        BarManager.EndUpdate()
        'Grd Dinh Luong

1:
        Try
            For Each conTrol In grd1.Controls
                If TypeOf conTrol Is DevExpress.XtraBars.BarDockControl Then
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try

        Dim BarManagerDL As New DevExpress.XtraBars.BarManager
        BarManagerDL.Form = grd1
        AddHandler BarManagerDL.ItemClick, AddressOf barManager_ItemClick
        BarManagerDL.BeginUpdate()
        Dim popupDL As New DevExpress.XtraBars.PopupMenu(BarManagerDL)
        BarManagerDL.SetPopupContextMenu(grd1, popupDL)
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTTDL", Commons.Modules.TypeLanguage)
        Dim mnuGSTTDL As New DevExpress.XtraBars.BarButtonItem(BarManagerDL, sStr)
        mnuGSTTDL.Name = "mnuGSTTDL"
        popupDL.AddItems(New DevExpress.XtraBars.BarItem() {mnuGSTTDL})
        BarManagerDL.EndUpdate()
    End Sub

    Dim frmDanhmuccongviec As MVControl.frmDanhmuccongviec
    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
        Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
        If Not subMenu Is Nothing Then Return

        Dim grd As DevExpress.XtraGrid.GridControl = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DevExpress.XtraGrid.GridControl)
        Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grd.MainView, DevExpress.XtraGrid.Views.Grid.GridView)


        Dim dt As New DataTable()
        Try

            Select Case e.Item.Name.ToUpper
#Region "mnuInLichSuPhuTung"
                Case "mnuInLichSuPhuTung".ToUpper
                    InLichSuPT()
#End Region
#Region "mnuInLichSuMuaHang"
                Case "mnuInLichSuMuaHang".ToUpper
                    InLichSuMH()
#End Region

#Region "mnuCongViec"
                Case "mnuCongViec".ToUpper
                    Commons.Hyperlink.ToCongViec(Me, grv.GetFocusedDataRow()("MS_CV").ToString())
#End Region
#Region "mnuPhuTung"
                Case "mnuPhuTung".ToUpper
                    Commons.Hyperlink.ToPhuTung(Me, grv.GetFocusedDataRow()("MS_PT").ToString())
#End Region
#Region "mnuPhieuBaoTri"
                Case "mnuPhieuBaoTri".ToUpper
                    Commons.Hyperlink.ToPhieuBaoTri(Me, grv.GetFocusedDataRow()("MS_PHIEU_BAO_TRI").ToString())

#End Region

#Region "mnuGSTTDL"
                Case "mnuGSTT".ToUpper
                    Commons.Hyperlink.ToGSTT(Me, grv.GetFocusedDataRow()("MS_TS_GSTT").ToString())
#End Region
#Region "mnuGSTTDL"
                Case "mnuGSTTDL".ToUpper
                    Commons.Hyperlink.ToGSTTDL(Me, grv.GetFocusedDataRow()("MS_TS_GSTT").ToString())
#End Region
                Case "mnuNewPhieuBaoTri".ToUpper

                    Dim str As String = "select * from NHOM_MENU WHERE MENU_ID = N'MnuPhieuBaoTri' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "')"
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                    If (dt.Rows.Count = 0) Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Commons.Modules.PermisString = Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, FrmPhieuBaoTri_New.Name)
                    Dim frm As New Report1.frmLapphieubaotri_CS
                    frm.MS_MAY = grv.GetFocusedDataRow()("MS_MAY").ToString()
                    frm.bLockMSMay = True
                    frm.ShowDialog()
                    Commons.Modules.SQLString = ""
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PopupMenu_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try

            Dim popupMenu As DevExpress.XtraBars.PopupMenu = TryCast(sender, DevExpress.XtraBars.PopupMenu)


            Dim grd As DevExpress.XtraGrid.GridControl = TryCast(Me.Controls.Find(popupMenu.Manager.Form.Name, True).FirstOrDefault(), DevExpress.XtraGrid.GridControl)
            Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grd.MainView, DevExpress.XtraGrid.Views.Grid.GridView)



            Dim p As Point = grd.PointToClient(Control.MousePosition)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = grv.CalcHitInfo(p)
            If hitInfo.InColumnPanel Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub grv_ShowGridMenu(sender As Object, e As GridMenuEventArgs)
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then Exit Sub
        Try
            Dim headerMenu As DevExpress.XtraGrid.Menu.GridViewMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewMenu)
            Dim menuItem As New DevExpress.Utils.Menu.DXMenuItem("Reset Grid", New EventHandler(AddressOf MyMenuItem))
            menuItem.BeginGroup = True
            menuItem.Tag = e.Menu
            headerMenu.Items.Add(menuItem)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MyMenuItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Item As DevExpress.Utils.Menu.DXMenuItem = CType(sender, DevExpress.Utils.Menu.DXMenuItem)
            Dim menu As DevExpress.XtraGrid.Menu.GridViewMenu = CType(Item.Tag, DevExpress.XtraGrid.Menu.GridViewMenu)
            Dim grv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(menu.View, DevExpress.XtraGrid.Views.Grid.GridView)

            Select Case grv.Name.ToUpper
                Case "grvmay".ToUpper
                    For i As Integer = 0 To grv.Columns.Count - 1
                        Try
                            grv.Columns(i).Visible = False
                        Catch ex As Exception

                        End Try
                    Next
                    grv.Columns("MS_MAY").Visible = True
                    grv.Columns("TEN_MAY").Visible = True
                    grv.Columns("MS_MAY").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
                    grv.Columns("TEN_MAY").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_MAY", Commons.Modules.TypeLanguage)
                    Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
                    opts.Columns.StoreAllOptions = True
                    'grdMay.MainView.SaveLayoutToXml(Application.StartupPath + "\XML\GridTTTB.xml", opts)
                    grdMay.MainView.SaveLayoutToRegistry(regMay)

                Case "grvCTTB_PT".ToUpper
                    For i As Integer = 0 To grv.Columns.Count - 1
                        Try
                            grv.Columns(i).Visible = False
                        Catch ex As Exception

                        End Try
                    Next


                    grv.Columns("MS_PT").Visible = True
                    grv.Columns("MS_VI_TRI_PT").Visible = True
                    grv.Columns("SO_LUONG").Visible = True
                    grv.Columns("DVT").Visible = True
                    grv.Columns("TEN_PT").Visible = True
                    grv.Columns("SL_TON").Visible = True
                    grv.Columns("CHUC_NANG").Visible = True
                    grv.Columns("MS_PT_NCC").Visible = True
                    grv.Columns("QUY_CACH").Visible = True
                    grv.Columns("ACTIVE").Visible = True

                    grv.Columns("MS_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
                    grv.Columns("MS_VI_TRI_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
                    grv.Columns("SO_LUONG").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG", Commons.Modules.TypeLanguage)
                    grv.Columns("DVT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DVT", Commons.Modules.TypeLanguage)
                    grv.Columns("TEN_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
                    grv.Columns("SL_TON").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TON", Commons.Modules.TypeLanguage)
                    grv.Columns("CHUC_NANG").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUC_NANG", Commons.Modules.TypeLanguage)
                    grv.Columns("MS_PT_NCC").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
                    grv.Columns("QUY_CACH").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "QUY_CACH", Commons.Modules.TypeLanguage)
                    grv.Columns("ACTIVE").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ACTIVE", Commons.Modules.TypeLanguage)
                    grv.Columns("DGVND_MIN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DGVND_MIN", Commons.Modules.TypeLanguage)
                    grv.Columns("DGVND_MAX").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DGVND_MAX", Commons.Modules.TypeLanguage)

                    FormatGridPT()
                    Try
                        grvCTTB_PT.Columns("ACTIVE").OptionsColumn.ReadOnly = False
                        grvCTTB_PT.Columns("CHUC_NANG").OptionsColumn.ReadOnly = False
                        grvCTTB_PT.Columns("PTVT").Visible = False
                        grvCTTB_PT.Columns("TEN_PT_VIET").Visible = False
                        grvCTTB_PT.Columns("MS_PT_CTY").Visible = False


                        grvCTTB_PT.Columns("MS_PT").VisibleIndex = 1
                        grvCTTB_PT.Columns("MS_VI_TRI_PT").VisibleIndex = 2
                        grvCTTB_PT.Columns("SO_LUONG").VisibleIndex = 3
                        grvCTTB_PT.Columns("DVT").VisibleIndex = 4
                        grvCTTB_PT.Columns("TEN_PT").VisibleIndex = 5
                        grvCTTB_PT.Columns("SL_TON").VisibleIndex = 6
                        grvCTTB_PT.Columns("DGVND_MIN").VisibleIndex = 7
                        grvCTTB_PT.Columns("DGVND_MAX").VisibleIndex = 8
                        grvCTTB_PT.Columns("CHUC_NANG").VisibleIndex = 9
                        grvCTTB_PT.Columns("MS_PT_NCC").VisibleIndex = 10
                        grvCTTB_PT.Columns("QUY_CACH").VisibleIndex = 11
                        grvCTTB_PT.Columns("ACTIVE").VisibleIndex = 12

                    Catch ex As Exception
                    End Try
                    grvCTTB_PT.Columns("SL_TON").Visible = If(ShowTonKho = False, False, True)

                    Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
                    opts.Columns.StoreAllOptions = True
                    'grvCTTB_PT.SaveLayoutToXml(Application.StartupPath + "\XML\GrdMayCTTBPT.xml", opts)
                    grdCTTB_PT.MainView.SaveLayoutToRegistry(regCTTB)
            End Select


            If grv.Name.ToLower = "grvmay".ToLower Then

            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region
    Private Sub txtTEN_BO_PHAN_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtTEN_BO_PHAN.ButtonClick
        If BtnGhi4.Visible = False Then Exit Sub
        If txtMS_BO_PHAN.Text.Trim = "" Then Exit Sub
        Dim sLoi As String = ""

        If Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblfrmThongtinthietbi_bo_phan_Anh", Commons.Modules.TypeLanguage),
            "CAU_TRUC_THIET_BI", "TEN_BO_PHAN_ANH", " WHERE MS_BO_PHAN = N'" + txtMS_BO_PHAN.Text + "'" + "AND MS_MAY = N'" + ucDMTBi.txtMS_MAY.Text + "'", sLoi, "frmThongtinthietbi") = False Then
            XtraMessageBox.Show(sLoi)
        End If

    End Sub

    Private Sub txtTEN_MAY_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If ucDMTBi.txtMS_MAY.Text.Trim = "" Then Exit Sub
        Dim sLoi As String = ""
        If Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblfrmThongtinthietbi_may_Anh", Commons.Modules.TypeLanguage),
                                                     "MAY", "TEN_MAY_ANH", " WHERE MS_MAY = N'" + ucDMTBi.txtMS_MAY.Text + "'", sLoi, "frmThongtinthietbi") = False Then
            XtraMessageBox.Show(sLoi)
        End If
    End Sub

    Sub HienThiDuLieuLichSuThietBi()
        Dim str As String

        str = "SELECT DISTINCT LICH_SU_TB.* FROM (" &
                    "SELECT  CONVERT(DATE, PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, 103) AS NGAY_HOAN_THANH,PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI,  case " & Commons.Modules.TypeLanguage & " when 0 then PHIEU_BAO_TRI.TT_SAU_BT when 1 then isnull(PHIEU_BAO_TRI.TT_SAU_BT_ANH,PHIEU_BAO_TRI.TT_SAU_BT) when 2 then isnull(PHIEU_BAO_TRI.TT_SAU_BT_HOA,PHIEU_BAO_TRI.TT_SAU_BT) end as TT_SAU_BT, dbo.MAY.MS_MAY AS MAY_TH,PHIEU_BAO_TRI_CONG_VIEC.MS_CV,PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN + ' - ' + case " & Commons.Modules.TypeLanguage & " when 0 then dbo.CAU_TRUC_THIET_BI.TEN_BO_PHAN when 1 then isnull(CAU_TRUC_THIET_BI.TEN_BO_PHAN_ANH, CAU_TRUC_THIET_BI.TEN_BO_PHAN) when 2 then ISNULL(CAU_TRUC_THIET_BI.TEN_BO_PHAN_HOA,CAU_TRUC_THIET_BI.TEN_BO_PHAN) end AS TEN_BP_TH , " &
                    " case " & Commons.Modules.TypeLanguage & " when 0 then CONG_VIEC.MO_TA_CV when 1 then isnull(CONG_VIEC.MO_TA_CV_ANH,CONG_VIEC.MO_TA_CV) when 2 then isnull(CONG_VIEC.MO_TA_CV_HOA,CONG_VIEC.MO_TA_CV) end as MO_TA_CV, LOAI_BAO_TRI.TEN_LOAI_BT,CONVERT(BIT,CASE ISNULL(PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE,-1) WHEN -1 THEN 0 ELSE 1 END) AS NHA_THAU,PHIEU_BAO_TRI_CONG_VIEC.GHI_CHU " &
                    " FROM dbo.PHIEU_BAO_TRI_CONG_VIEC INNER JOIN  " &
                    " dbo.PHIEU_BAO_TRI ON dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
                    " INNER JOIN dbo.MAY ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY  " &
                    " INNER JOIN dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " &
                    " dbo.CONG_VIEC ON dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV = dbo.CONG_VIEC.MS_CV INNER JOIN " &
                    " dbo.CAU_TRUC_THIET_BI ON dbo.MAY.MS_MAY = dbo.CAU_TRUC_THIET_BI.MS_MAY AND  " &
                    " dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI.MS_BO_PHAN INNER JOIN " &
                    " dbo.BO_PHAN" & Commons.Modules.UserName & " BP on BP.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN " &
                    " WHERE (PHIEU_BAO_TRI.TINH_TRANG_PBT >= 3) AND PHIEU_BAO_TRI.MS_MAY=N'" & ucDMTBi.txtMS_MAY.Text & "' " &
                    " AND CONVERT(DATETIME,dbo.PHIEU_BAO_TRI.NGAY_LAP,103) BETWEEN CONVERT(DATETIME,'" & dtpTuNgay1.DateTime.Date.ToString & "',103)  " &
                    " AND CONVERT(DATETIME,'" & dtpDenNgay1.DateTime.Date.ToString & "',103)) LICH_SU_TB ORDER BY NGAY_HOAN_THANH DESC"
        Commons.Modules.SQLString = "0LOAD"
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdLichSuMay, grvLichSuMay, SqlHelper.ExecuteDataset(IConnections.ConnectionString, CommandType.Text, str).Tables(0), False, False, False, True, True, Me.Name)
        Commons.Modules.SQLString = ""
        grvLichSuMay.Columns("MS_CV").Visible = False
        grvLichSuMay.Columns("MS_BO_PHAN").Visible = False
        grvLichSuMay.Columns("MAY_TH").Visible = False
        grvLichSuMay.Columns("MS_BO_PHAN").Visible = False
        grvLichSuMay_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Sub InVB(rptname As String, GroupBy As Integer)

        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
        If sPath = "" Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()

        Try
            Dim TCot As Integer = ucDMTBi.grvChung.Columns.Count
            Dim TDong As Integer = ucDMTBi.grvChung.RowCount
            Dim Dong As Integer = 1
            Dim stmp As String = ""
            ucDMTBi.grdChung.ExportToXls(sPath)
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "",
             False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)

            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3 + GroupBy, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0 + GroupBy, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_BP_CP_THIET_BI", "NGAY_IN", Commons.Modules.TypeLanguage) + DateTime.Now.ToString("dd/MM/yyyy"), 1, TCot + 1, "@", 10, False, True, 1, TCot + 1)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong)
            If rptname = "rptLICH_BAO_TRI_DINH_KI" Then
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong)
            ElseIf rptname = "rptLICH_HIEU_CHUAN_THIET_BI" Then
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong)
            ElseIf rptname = "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB" Then
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 20, Dong)
            End If

            Dim SCot As Integer
            SCot = 7
            Dong += 1
            If rptname = "rptLICH_SU_THIET_BI" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, SCot - 4)

                Dong += 1

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong - 1, 4, "@", 10,
                 True, True, Dong, 6)
            ElseIf rptname = "rptDANH_SACH_BP_CP_THIET_BI" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_BP_CP_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, SCot - 4)

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10,
                 True, True, Dong, 6)

                Dong += 1

                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, SCot - 4)

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10,
                 True, True, Dong, 6)

            ElseIf rptname = "rptDANH_SACH_DC_THIET_BI_DUOC_LAP_DAT" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_DC_THIET_BI_DUOC_LAP_DAT", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)

                Dong += 1

                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)
            ElseIf rptname = "rptDANH_SACH_NOI_LAP_DAT_THIET_BI" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_NOI_LAP_DAT_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)

                Dong += 1

                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)
            ElseIf rptname = "rptDANH_SACH_TAI_LIEU_THIET_BI" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_TAI_LIEU_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)

                Dong += 1

                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)
            ElseIf rptname = "rptDanhsach_VTPT_TheoMay" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT_TheoMay", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)

                Dong += 1

                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)
            ElseIf rptname = "rptLICH_BAO_TRI_DINH_KI" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_BAO_TRI_DINH_KI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, True, True, Dong, 5)

                Dong += 1

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)

                Dong += 1
                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, True, True, Dong, 5)

            ElseIf rptname = "rptLICH_HIEU_CHUAN_THIET_BI" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_HIEU_CHUAN_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, 3)
                Dong += 1
                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, 3)

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10,
                 True, True, Dong, 6)
                Dong += 1
                stmp = ucDMTBi.LblChuKyHC.Text + " : " + ucDMTBi.txtChukyHC.Text + ucDMTBi.cmbDVTG.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, 3)
                Dong += 1
                stmp = ucDMTBi.lblCKHCTBNgoai.Text + " : " + ucDMTBi.txtCKHCTB_Ngoai.Text + ucDMTBi.cmbDVTG.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, 3)
                Dong += 1
                stmp = ucDMTBi.lblCKKDTB.Text + " : " + ucDMTBi.txtCKKDTB.Text + ucDMTBi.cmbDVTG.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, 3)


            ElseIf rptname = "rptLICH_SU_VAT_TU_SD_CHO_TB" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptLICH_SU_VAT_TU_SD_CHO_TB", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)

                Dong += 1

                stmp = ucDMTBi.LblLoaiTB.Text + " : " + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, SCot - 5)

                stmp = ucDMTBi.LblNhomTB.Text + " : " + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10,
                 True, True, Dong, 5)

            ElseIf rptname = "rptQUI_DINH_VE_GSTT_THIET_BI" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptQUI_DINH_VE_GSTT_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, SCot - 3)
                Dong += 1
            ElseIf rptname = "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB" Then
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                   True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))
                Dong += 1

                stmp = ucDMTBi.LblMathietbi.Text + " : " + ucDMTBi.txtMS_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, True, True, Dong, 5)
                Dong += 1

                stmp = ucDMTBi.lblTEN_MAY.Text + " : " + ucDMTBi.txtTEN_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 3, "@", 10, True, True, Dong, 5)

                Dong += 1

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TT_CO_BAN", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 12, True, True, Dong, 2)
                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "LOAI_MAY", Commons.Modules.TypeLanguage) + ucDMTBi.cboMS_LOAI_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NHOM_MAY", Commons.Modules.TypeLanguage) + ucDMTBi.cboMS_NHOM_MAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "KIEU", Commons.Modules.TypeLanguage) + ucDMTBi.txtMODEL.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NUOC_SX", Commons.Modules.TypeLanguage) + ucDMTBi.txtNUOC_SX.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "HANG_SAN_XUAT", Commons.Modules.TypeLanguage) + ucDMTBi.CboMS_HSX.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NHA_CUNG_CAP", Commons.Modules.TypeLanguage) + ucDMTBi.cboMS_NCC.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "MO_TA", Commons.Modules.TypeLanguage) + ucDMTBi.txtMO_TA.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NHIEM_VU", Commons.Modules.TypeLanguage) + ucDMTBi.txtNHIEM_VU_THIET_BI.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TT_SU_DUNG", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_DUA_VAO_SD", Commons.Modules.TypeLanguage) + ucDMTBi.txtNGAY_DUA_VAO_SD.DateTime.Date
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "HIEN_TRANG_SU_DUNG", Commons.Modules.TypeLanguage) + ucDMTBi.cboMS_HIEN_TRANG.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, True, True, Dong, 5)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_NAM_DA_SD", Commons.Modules.TypeLanguage) + ucDMTBi.txtSO_NAM_SD.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "MUC_UU_TIEN", Commons.Modules.TypeLanguage) + ucDMTBi.cboMUC_UU_TIEN.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, True, True, Dong, 5)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NOI_LAP_DAT", Commons.Modules.TypeLanguage) + ucDMTBi.TxtMS_NHA_XUONG.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "BO_PHAN_TRA_PHI", Commons.Modules.TypeLanguage) + ucDMTBi.TxtMS_BP_CHIU_PHI.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_BD_BAO_HANH", Commons.Modules.TypeLanguage) + ucDMTBi.txtNGAY_BD_BAO_HANH.DateTime.Date
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_HET_BAO_HANH", Commons.Modules.TypeLanguage) + ucDMTBi.txtNgayKTBH.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, True, True, Dong, 5)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_NGAY_LAM_TB", Commons.Modules.TypeLanguage) + ucDMTBi.txtSO_NGAY_LV_TRONG_TUAN.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_GIO_LAM_TB", Commons.Modules.TypeLanguage) + ucDMTBi.txtSO_GIO_LV_TRONG_NGAY.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, True, True, Dong, 5)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "TT_KE_TOAN", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, True, Dong, 3)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_THE", Commons.Modules.TypeLanguage) + ucDMTBi.txtSO_THE.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "PHAN_TRAM", Commons.Modules.TypeLanguage) + ucDMTBi.txtTY_LE_CON_LAI.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, True, True, Dong, 5)

                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_MUA", Commons.Modules.TypeLanguage) + ucDMTBi.txtNGAY_MUA.DateTime.Date
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "GIA_MUA", Commons.Modules.TypeLanguage) + ucDMTBi.txtGIA_MUA.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, True, True, Dong, 5)
                Dong += 1
                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "SO_NAM_KH", Commons.Modules.TypeLanguage) + ucDMTBi.txtSO_NAM_KHAU_HAO.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 3)

                stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB", "NGAY_HET_KH", Commons.Modules.TypeLanguage) + ucDMTBi.txtNgayHHKH.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, True, True, Dong, 5)

            End If



            Dim title As Excel.Range

            Dong += 1
            Dong += 1

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot)
            title.Font.Bold = True
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True,
             True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100)

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 15

            If rptname = "rptLICH_SU_THIET_BI" Then
                'set width for all columns'
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7.8, "dd/MM/yyyy", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 23, "@", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 18.7, "@", True, Dong + 1, 4,
                 TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "@", True, Dong + 1, 6,
                 TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15.5, "@", True, Dong + 1, 7,
                 TDong + Dong, 7)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 31, "@", True, Dong + 1, 8,
                 TDong + Dong, 8)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.1, "@", True, Dong + 1, 9,
                 TDong + Dong, 9)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 16.5, "@", True, Dong + 1, 10, TDong + Dong, 10)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14.71, "@", True, Dong + 1, 11,
                 TDong + Dong, 11)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", True, Dong + 1, 12,
                 TDong + Dong, 12)
            ElseIf rptname = "rptDANH_SACH_BP_CP_THIET_BI" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "dd/MM/yyyy", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 40, "@", True, Dong + 1, 4,
                 TDong + Dong, 4)
            ElseIf rptname = "rptDANH_SACH_DC_THIET_BI_DUOC_LAP_DAT" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "dd/MM/yyyy", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 45, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
            ElseIf rptname = "rptDANH_SACH_NOI_LAP_DAT_THIET_BI" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "dd/MM/yyyy", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", True, Dong + 1, 4,
                 TDong + Dong, 4)
            ElseIf rptname = "rptDANH_SACH_TAI_LIEU_THIET_BI" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "dd/MM/yyyy", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 50, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
            ElseIf rptname = "rptDanhsach_VTPT_TheoMay" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", True, Dong + 1, 4,
                 TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 6,
                 TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 7,
                 TDong + Dong, 7)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 8,
                 TDong + Dong, 8)

            ElseIf rptname = "rptLICH_BAO_TRI_DINH_KI" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 2.5, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 2.5, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 4,
                 TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 6,
                 TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 7,
                 TDong + Dong, 7)

                For i2 As Integer = 11 To 11 + TDong
                    Try
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i2, 2, i2, 2)
                        If title.Value.ToString.Contains("Tên bộ phận:") = True Then
                            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#a10404"))
                            title.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 0
                            title.Font.Bold = True
                        End If
                    Catch ex As Exception

                    End Try
                Next
                For i1 As Integer = 11 To 11 + TDong
                    Try
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 1, i1, 1)
                        If title.Value.ToString.Contains("Loại bảo trì:") = True Then
                            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#0d6012"))
                            title.Font.Bold = True
                        End If
                    Catch ex As Exception

                    End Try
                Next
                Dim i As Integer = 1
                Dim T1, T2 As Excel.Range
                For i1 As Integer = 11 To 11 + TDong
                    Try
                        T1 = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 3, i1, 3)
                        If Convert.ToInt32(T1.Value) Then
                            T2 = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 1, i1, 3)
                            T2.Merge()
                            T2.Value = i
                            i = i + 1
                        End If

                    Catch ex As Exception

                    End Try

                Next
            ElseIf rptname = "rptLICH_HIEU_CHUAN_THIET_BI" Then

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/mm/yyyy", True, Dong + 1, 4,
                 TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 6,
                 TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 7,
                 TDong + Dong, 7)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 8,
                TDong + Dong, 8)
            ElseIf rptname = "rptLICH_SU_VAT_TU_SD_CHO_TB" Then

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "dd/mm/yyyy", True, Dong + 1, 4,
                 TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 6,
                 TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 7,
                 TDong + Dong, 7)
            ElseIf rptname = "rptLICH_SU_VAT_TU_SD_CHO_TB" Then

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "dd/mm/yyyy", True, Dong + 1, 4,
                 TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 6,
                 TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 7,
                 TDong + Dong, 7)
            ElseIf rptname = "rptQUI_DINH_VE_GSTT_THIET_BI" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 2.5, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", True, Dong + 1, 2,
                 TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 2.5, "@", True, Dong + 1, 3,
                 TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 4,
                 TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 6,
                 TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 7,
                 TDong + Dong, 7)

                For i2 As Integer = 11 To 11 + TDong
                    Try
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i2, 2, i2, 2)
                        If title.Value.ToString.Contains("Tên giá trị:") = True Then
                            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#a10404"))
                            title.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 0
                            title.Font.Bold = True
                        End If
                    Catch ex As Exception

                    End Try
                Next
                For i1 As Integer = 11 To 11 + TDong
                    Try
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 1, i1, 1)
                        If title.Value.ToString.Contains("Tên thông số GSTT:") = True Then
                            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#0d6012"))
                            title.Font.Bold = True
                        End If
                    Catch ex As Exception

                    End Try
                Next
                Dim i As Integer = 1
                Dim T1, T2 As Excel.Range
                For i1 As Integer = 10 To 11 + TDong
                    Try
                        T1 = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 3, i1, 3)
                        If Convert.ToInt32(T1.Value) Then
                            T2 = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 1, i1, 3)
                            T2.Merge()
                            T2.Value = i
                            i = i + 1
                        End If

                    Catch ex As Exception

                    End Try

                Next
            ElseIf rptname = "rptTHONG_TIN_CHUNG_VA_THONG_SO_TB" Then
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 2, TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 3, TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 4, TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 6,
                TDong + Dong, 6)
                For i1 As Integer = 9 To 30
                    Try
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 1, i1, 1)
                        If title.Value.ToString.Contains("Thông tin cơ bản:") = True Or title.Value.ToString.Contains("Thông tin sử dụng:") = True Or title.Value.ToString.Contains("Thông tin kế toán:") = True Then
                            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#a10404"))
                            title.Font.Bold = True
                        End If
                    Catch ex As Exception

                    End Try
                Next
            End If
            excelWorkbook.CheckCompatibility = False
            excelWorkbook.Save()
            excelApplication.Visible = True
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        Catch ex As Exception
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Me.Cursor = Cursors.[Default]

    End Sub

End Class


