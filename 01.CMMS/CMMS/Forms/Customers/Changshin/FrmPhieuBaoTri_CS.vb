
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Common.Data
Imports Commons.QL.Events
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports Commons
Imports DevExpress.XtraEditors

Public Class FrmPhieuBaoTri_CS
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

    Private bChangce As Boolean = True
    Private PBTOut As String = ""
    Dim TBNhanVien As New DataTable()
    Dim txtBaoTri As TextBox
#End Region

    Private Sub FrmPhieuBaoTri_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Str As String = ""
        Try
            e.Cancel = Not bThoat
            If bThoat = False Then btnThoat_Click(sender, e)
            Commons.Modules.ObjSystems.XoaTable("BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName)
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.XoaTable("PTB_DANH_GIA_SERVICE" & Commons.Modules.UserName)

        Commons.Modules.ObjSystems.XoaTable("rptTieuDe_PT_BT")
        Commons.Modules.ObjSystems.XoaTable("rptTieuDe_VT_BT")
        Try
            Str = "drop PROC [dbo].InsertTAM18" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmPhieuBaoTri_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = ""
        Dim objreader As SqlDataReader

        Me.Cursor = Cursors.WaitCursor
        txtDuongDan_2.Enabled = False
        If Commons.Modules.PermisString.Equals("Read only") Then
            Commons.Modules.ObjSystems.DinhDang()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            EnableControl(False)
            VisibleButtonXoa(False)
            HideButton1(True)
            HideButton_4(True)
            HideDelete_4(False)
            HideSave4(False)
            VisibleButtonGhi(False)
            dtTuNgay_1.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 20)
            dtpTuNgay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 30)
            LoadcboDiadiem()
            LoadcboLoaithietbi()
            LoadcboNhommay()
            LoadcboMS_MAY()
            LoadCombo()
            'LoadcboCa()
            'LoadcboBoPhan()
            'LoadcboThietBi()
            'tab 5 (Sửa)
            RefreshData5()

            BtnLockPBT.Enabled = False
            BtnXacnhanNT.Enabled = False
            str = "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME ='" & Commons.Modules.UserName & "' AND STT in(7,8,9)"
            objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objreader.Read
                If objreader.Item("STT") = 7 Then
                    BtnDuyetPBT.Enabled = True
                ElseIf objreader.Item("STT") = 9 Then
                    BtnKhoaPBT.Enabled = True
                    BtnLockPBT.Enabled = True
                ElseIf objreader.Item("STT") = 8 Then
                    BtnXacnhanNT.Enabled = True
                Else

                End If
            End While
            objreader.Close()
            If cboTinhTrangPBT.SelectedValue = 4 Then
                EnableButton5(False)
            End If

            LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
            LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            'end tab 5
            BindData()
            VisibleButtonXoa1(False)
            VisibleButtonThem1(True)
            VisibleButtonGhi1(False)
            'job card
            loadCboTo()
            loadCboNhanVien()
            AddHandler radPhieuBaoTriChuaNghiemThu_1.CheckedChanged, AddressOf Me.radPhieuBaoTriChuaNghiemThu_1_CheckedChanged
            AddHandler radPhieuBaoTriDaNghiemThu_1.CheckedChanged, AddressOf Me.radPhieuBaoTriDaNghiemThu_1_CheckedChanged
            EnableButton(False)
            TinhtrangPBT_Lock(False)
            btnIn_1.Enabled = True ' False
        Else
            EnableButton(True)
            Commons.Modules.ObjSystems.DinhDang()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            EnableControl(False)
            VisibleButtonXoa(False)
            HideButton1(True)
            HideButton_4(True)
            HideDelete_4(False)
            HideSave4(False)
            VisibleButtonGhi(False)
            dtTuNgay_1.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 20)
            dtpTuNgay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 30)
            LoadcboDiadiem()
            LoadcboLoaithietbi()
            LoadcboNhommay()
            LoadcboMS_MAY()
            LoadCombo()
            'LoadcboCa()
            'LoadcboBoPhan()
            'LoadcboThietBi()
            'tab 5 (Sửa)
            RefreshData5()

            BtnLockPBT.Enabled = False
            BtnXacnhanNT.Enabled = False
            str = "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME ='" & Commons.Modules.UserName & "' AND STT in(7,8,9)"
            objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objreader.Read
                If objreader.Item("STT") = 7 Then
                    BtnDuyetPBT.Enabled = True
                ElseIf objreader.Item("STT") = 9 Then
                    BtnKhoaPBT.Enabled = True
                    BtnLockPBT.Enabled = True
                ElseIf objreader.Item("STT") = 8 Then
                    BtnXacnhanNT.Enabled = True
                Else

                End If
            End While
            objreader.Close()
            If cboTinhTrangPBT.SelectedValue = 4 Then
                EnableButton5(False)
            End If

            LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
            LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
            'end tab 5
            BindData()
            VisibleButtonXoa1(False)
            VisibleButtonThem1(True)
            VisibleButtonGhi1(False)
            'job card
            loadCboTo()
            loadCboNhanVien()
            'job card
            AddHandler radPhieuBaoTriChuaNghiemThu_1.CheckedChanged, AddressOf Me.radPhieuBaoTriChuaNghiemThu_1_CheckedChanged
            AddHandler radPhieuBaoTriDaNghiemThu_1.CheckedChanged, AddressOf Me.radPhieuBaoTriDaNghiemThu_1_CheckedChanged
            AddHandler radCongviecchinh.CheckedChanged, AddressOf Me.radCongviecchinh_CheckedChanged
        End If

        Try
            cboLoai_BT.Value = "MS_LOAI_BT"
            cboLoai_BT.Display = "TEN_LOAI_BT"
            cboLoai_BT.Param = cboMS_ThietBi.SelectedValue.ToString
            cboLoai_BT.StoreName = "GetLOAI_BAO_TRI_PBT_THEO_BTPN"
            cboLoai_BT.DropDownWidth = 200
            cboLoai_BT.BindDataSource()
        Catch ex As Exception
        End Try

        objreader.Close()
        objreader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH=1")
        While objreader.Read
            lblTienMD.Text = lblTienMD.Text & " " & objreader.Item("NGOAI_TE")
        End While
        objreader.Close()

        tabControl.TabPages.RemoveByKey("tabBaocao")
        Me.Cursor = Cursors.Default
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnKhoaPBT.Enabled = chon
        BtnDuyetPBT.Enabled = chon
        btnThem_1.Enabled = chon
        btnSua_1.Enabled = chon
        btnXoa_1.Enabled = chon
        btnThem_2.Enabled = chon
        btnXoa_2.Enabled = chon
        btnThemsua.Enabled = chon
        btnXoa.Enabled = chon
        BtnLockPBT.Enabled = chon
        btnSua5.Enabled = chon
        btnXoa5.Enabled = chon
        btnDanhGia.Enabled = chon
        btnThemSuaDV_4.Enabled = chon
        btnThemSuaCV_4.Enabled = chon
        btnSua_1.Enabled = chon
        btnXoa_4.Enabled = chon
    End Sub
#Region "ptivate tab1"
    Sub BindDataHinh()
        TBHinh = New clsPHIEU_BAO_TRIController().GetPHIEU_BAO_TRI_HINHs(txtMaSoPBT.Text.Trim)
        grdHinh.DataSource = TBHinh
        grdHinh.Columns("MS_PHIEU_BAO_TRI").Visible = False
        grdHinh.Columns("STT").Visible = False
        grdHinh.Columns("HINH").Visible = False
        grdHinh.Columns("STT_YC_NSD").Visible = False
        grdHinh.Columns("STT_GSTT").Visible = False
        grdHinh.Columns("TEN_TAI_LIEU").ReadOnly = True
        grdHinh.Columns("DUONG_DAN").ReadOnly = True
        grdHinh.Columns("TEN_TAI_LIEU").ReadOnly = True
        With grdHinh
            .Columns("TEN_TAI_LIEU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TAI_LIEU", Commons.Modules.TypeLanguage)
            .Columns("DUONG_DAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DUONG_DAN", Commons.Modules.TypeLanguage)
        End With
        Try
            Me.grdHinh.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdHinh.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadCombo()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTINH_TRANG_PBT", Commons.Modules.TypeLanguage))
        cboTinhTrangPBT.DataSource = dtTable
        cboTinhTrangPBT.ValueMember = "STT"
        cboTinhTrangPBT.DisplayMember = "TEN_TINH_TRANG"

        cboMS_ThietBi.Value = "MS_MAY"
        cboMS_ThietBi.Display = "MS_MAY"
        cboMS_ThietBi.StoreName = "GetMAY_PQ"
        cboMS_ThietBi.Param = Commons.Modules.UserName
        cboMS_ThietBi.DropDownWidth = 180
        cboMS_ThietBi.BindDataSource()

        cboMucUuTien.Value = "MS_UU_TIEN"
        cboMucUuTien.Display = "TEN_UU_TIEN"
        cboMucUuTien.StoreName = "GetMUC_UU_TIENs"
        cboMucUuTien.BindDataSource()

        cboNguoiLap.Value = "MS_CONG_NHAN"
        cboNguoiLap.Display = "HO_TEN_CONG_NHAN"
        cboNguoiLap.StoreName = "GetCONG_NHANs2"
        cboNguoiLap.DropDownWidth = 200
        cboNguoiLap.BindDataSource()

        cboGS_Vien.Value = "MS_CONG_NHAN"
        cboGS_Vien.Display = "HO_TEN_CONG_NHAN"
        cboGS_Vien.StoreName = "GetCONG_NHANs2"
        cboGS_Vien.DropDownWidth = 200
        cboGS_Vien.BindDataSource()

        'tab 5
        cboNguoiNghiemThu.Value = "MS_CONG_NHAN"
        cboNguoiNghiemThu.Display = "HO_TEN_CONG_NHAN"
        cboNguoiNghiemThu.StoreName = "GetCONG_NHANs2"
        cboNguoiNghiemThu.BindDataSource()
        'tab 5
    End Sub
    Sub DropTable()
        Dim str As String = ""
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CV_PHU_TRO_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

    End Sub
    Sub DropTable4()
        Dim str As String = ""
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CV_PHU_TRO_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub
    Sub RefreshData()
        txtMaSoPBT.Text = ""
        txtLydo.Text = ""
        txtusernameNL.Text = ""
        cboGS_Vien.SelectedValue = -1
        txtGiohong.Text = ""
        txtNgayhong.Text = ""
    End Sub
    Sub LoadcboNhommay()
        cboNhomThietBi_1.DataSource = Nothing
        cboMS_TB_1.DataSource = Nothing
        Dim str As String = ""
        'str = "SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY FROM NHOM_MAY INNER JOIN " & _
        '    " MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN PHIEU_BAO_TRI ON MAY.MS_MAY = PHIEU_BAO_TRI.MS_MAY "
        'If cboLoaiThietBi_1.SelectedValue <> "-1" Then
        '    str = str + " WHERE NHOM_MAY.MS_LOAI_MAY ='" & cboLoaiThietBi_1.SelectedValue & "'"
        'End If
        str = "SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY " &
              "FROM dbo.USERS INNER JOIN dbo.NHOM_MAY INNER JOIN dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN " &
                   "dbo.PHIEU_BAO_TRI ON dbo.MAY.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY INNER JOIN " &
                   "dbo.NHOM_LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY ON " &
                   "dbo.USERS.GROUP_ID = dbo.NHOM_LOAI_MAY.GROUP_ID WHERE 1=1 AND USERS.USERNAME='" & Commons.Modules.UserName & "'"
        If cboLoaiThietBi_1.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_LOAI_MAY ='" & cboLoaiThietBi_1.SelectedValue & "'"
        End If
        cboNhomThietBi_1.Value = "MS_NHOM_MAY"
        cboNhomThietBi_1.Display = "TEN_NHOM_MAY"
        cboNhomThietBi_1.StoreName = "QL_SEARCH"
        cboNhomThietBi_1.Param = str
        cboNhomThietBi_1.DropDownWidth = 150
        cboNhomThietBi_1.BindDataSource()
    End Sub
    Sub LoadcboDiadiem()
        cboDiaDiem_1.Display = "TeN_N_XUONG"
        cboDiaDiem_1.Value = "MS_N_XUONG"
        cboDiaDiem_1.StoreName = "GetNHA_XUONG_PBT"
        cboDiaDiem_1.Param = Commons.Modules.UserName

        cboDiaDiem_1.BindDataSource()
    End Sub

    Sub LoadcboMS_MAY()
        cboMS_TB_1.DataSource = Nothing
        Dim str As String = ""
        'str = "SELECT DISTINCT PHIEU_BAO_TRI.MS_MAY, PHIEU_BAO_TRI.MS_MAY AS TEN_MAY FROM PHIEU_BAO_TRI INNER JOIN " & _
        '    " MAY ON PHIEU_BAO_TRI.MS_MAY = MAY.MS_MAY INNER JOIN MAY_NHA_XUONG ON PHIEU_BAO_TRI.MS_MAY = MAY_NHA_XUONG.MS_MAY INNER JOIN  " & _
        '    " NHOM_NHA_XUONG ON MAY_NHA_XUONG.MS_N_XUONG = NHOM_NHA_XUONG.MS_N_XUONG and MAY_NHA_XUONG.NGAY_NHAP =(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY =PHIEU_BAO_TRI.MS_MAY) INNER JOIN " & _
        '     " NHOM ON NHOM_NHA_XUONG.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN " & _
        '    " LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON NHOM.GROUP_ID = NHOM_LOAI_MAY.GROUP_ID AND  " & _
        '    " LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID " & _
        '    " WHERE USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        'If cboDiaDiem_1.SelectedValue <> "-1" Then
        '    str = str + " and NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem_1.SelectedValue & "'"
        'End If
        'If cboLoaiThietBi_1.SelectedValue <> "-1" Then
        '    str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi_1.SelectedValue & "'"
        'End If
        'If cboNhomThietBi_1.SelectedValue <> "-1" Then
        '    str = str + " and NHOM_MAY.MS_NHOM_MAY='" & cboNhomThietBi_1.SelectedValue & "'"
        'End If


        str = "SELECT DISTINCT PHIEU_BAO_TRI.MS_MAY, PHIEU_BAO_TRI.MS_MAY AS TEN_MAY " &
        " FROM PHIEU_BAO_TRI INNER JOIN  MAY ON PHIEU_BAO_TRI.MS_MAY = MAY.MS_MAY INNER JOIN NHOM_MAY ON " &
        " MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY=NHOM_MAY.MS_LOAI_MAY " &
        " INNER JOIN NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY " &
        " INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON " &
        " NHOM.GROUP_ID=NHOM_NHA_XUONG.GROUP_ID INNER JOIN USERS ON NHOM.GROUP_ID = USERS.GROUP_ID " &
        " WHERE USERS.USERNAME ='" & Commons.Modules.UserName & "'"


        'str = "SELECT DISTINCT PHIEU_BAO_TRI.MS_MAY, PHIEU_BAO_TRI.MS_MAY AS TEN_MAY " & _
        '      "FROM PHIEU_BAO_TRI INNER JOIN MAY ON PHIEU_BAO_TRI.MS_MAY = MAY.MS_MAY INNER JOIN " & _
        '           "NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN " & _
        '           "NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN bo.NHOM_LOAI_MAY NHOM_LOAI_MAY_1 ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY_1.MS_LOAI_MAY INNER JOIN " & _
        '           "USERS ON NHOM_LOAI_MAY_1.GROUP_ID = USERS.GROUP_ID AND NHOM_LOAI_MAY.GROUP_ID = USERS.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON USERS.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        '      "WHERE USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        If cboDiaDiem_1.SelectedValue <> "-1" Then
            str = str + " and NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem_1.SelectedValue & "'"
        End If
        If cboLoaiThietBi_1.SelectedValue <> "-1" Then
            str = str + " and LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi_1.SelectedValue & "'"
        End If
        If cboNhomThietBi_1.SelectedValue <> "-1" Then
            str = str + " and NHOM_MAY.MS_NHOM_MAY='" & cboNhomThietBi_1.SelectedValue & "'"
        End If
        cboMS_TB_1.Display = "TEN_MAY"
        cboMS_TB_1.Value = "MS_MAY"
        cboMS_TB_1.StoreName = "QL_SEARCH"
        cboMS_TB_1.Param = str
        cboMS_TB_1.DropDownWidth = 150
        cboMS_TB_1.BindDataSource()
    End Sub
    Sub LoadcboLoaithietbi()
        cboNhomThietBi_1.DataSource = Nothing
        cboMS_TB_1.DataSource = Nothing
        cboLoaiThietBi_1.DataSource = Nothing
        Dim str As String = ""
        'str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        '" FROM PHIEU_BAO_TRI INNER JOIN MAY ON PHIEU_BAO_TRI.MS_MAY=MAY.MS_MAY  " & _
        '" INNER JOIN NHOM_MAY ON MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY " & _
        '" INNER JOIN MAY_NHA_XUONG ON MAY_NHA_XUONG.MS_MAY=MAY.MS_MAY " & _
        '" AND MAY_NHA_XUONG.NGAY_NHAP =(SELECT MAX(NGAY_NHAP) FROM MAY_NHA_XUONG A WHERE A.MS_MAY =PHIEU_BAO_TRI.MS_MAY) " & _
        '" INNER JOIN LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY =NHOM_MAY.MS_LOAI_MAY INNER JOIN " & _
        '" NHOM_LOAI_MAY ON NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY INNER JOIN  " & _
        '" NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN  NHOM_NHA_XUONG  " & _
        '" ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN  USERS ON NHOM.GROUP_ID = USERS.GROUP_ID " & _
        '" WHERE  USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        'If cboDiaDiem_1.SelectedValue <> "-1" Then
        '    str = str + " and NHOM_NHA_XUONG.MS_N_XUONG ='" & cboDiaDiem_1.SelectedValue & "' and MAY_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem_1.SelectedValue & "'"
        'End If
        str = " SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY FROM  LOAI_MAY INNER JOIN " &
            " NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " &
            " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN  NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID INNER JOIN " &
            " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID INNER JOIN NHOM_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_MAY.MS_LOAI_MAY INNER JOIN " &
            " MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY INNER JOIN PHIEU_BAO_TRI ON MAY.MS_MAY = PHIEU_BAO_TRI.MS_MAY " &
            " WHERE  USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        If cboDiaDiem_1.SelectedValue <> "-1" Then
            str = str + " and NHOM_NHA_XUONG.MS_N_XUONG ='" & cboDiaDiem_1.SelectedValue & "'"
        End If

        str = str + " UNION SELECT '' AS MS_LOAI_MAY, '' AS TEN_LOAI_MAY"
        cboLoaiThietBi_1.Value = "MS_LOAI_MAY"
        cboLoaiThietBi_1.Display = "TEN_LOAI_MAY"
        cboLoaiThietBi_1.StoreName = "QL_SEARCH"
        cboLoaiThietBi_1.Param = str
        cboLoaiThietBi_1.BindDataSource()
    End Sub
    Function isValidated() As Boolean
        If Not cboMS_ThietBi.IsValidated Then
            cboMS_ThietBi.Focus()
            Return False
        End If
        If Not cboLoai_BT.IsValidated Then
            cboLoai_BT.Focus()
            Return False
        End If
        If Not txtLydo.IsValidated Then
            txtLydo.Focus()
            Return False
        End If
        If Not cboMucUuTien.IsValidated Then
            cboMucUuTien.Focus()
            Return False
        End If
        If Not cboNguoiLap.IsValidated Then
            cboNguoiLap.Focus()
            Return False
        End If
        Return True
    End Function
    Sub EnableControl(ByVal chon As Boolean)
        cboMS_ThietBi.Enabled = chon
        cboLoai_BT.Enabled = chon
        dtNgayLap.Enabled = chon
        txtLydo.Enabled = chon
        txtLydo.ReadOnly = Not chon
        cboMucUuTien.Enabled = chon
        dtNgayBDKH.Enabled = chon
        dtNgayKTKH.Enabled = chon
        cboNguoiLap.Enabled = chon
        txtusernameNL.Enabled = chon
        cboGS_Vien.Enabled = chon
        txtGiohong.Enabled = chon
        txtNgayhong.Enabled = chon
        dtKTTT.Enabled = chon
        dtGioLap.Enabled = chon
    End Sub
    Sub ShowData()
        cboLoai_BT.Value = "MS_LOAI_BT"
        cboLoai_BT.Display = "TEN_LOAI_BT"
        cboLoai_BT.Param = dgrDanhSach_1.Rows(intRowPBT).Cells("MS_MAY").Value
        cboLoai_BT.StoreName = "GetLOAI_BAO_TRI_PBT_THEO_BTPN"
        cboLoai_BT.DropDownWidth = 200
        cboLoai_BT.BindDataSource()
        txtMaSoPBT.Text = dgrDanhSach_1.Rows(intRowPBT).Cells("MS_PHIEU_BAO_TRI").Value
        cboMS_ThietBi.SelectedValue = dgrDanhSach_1.Rows(intRowPBT).Cells("MS_MAY").Value
        cboLoai_BT.SelectedValue = dgrDanhSach_1.Rows(intRowPBT).Cells("MS_LOAI_BT").Value
        cboTinhTrangPBT.SelectedValue = dgrDanhSach_1.Rows(intRowPBT).Cells("TINH_TRANG_PBT").Value
        txtLydo.Text = dgrDanhSach_1.Rows(intRowPBT).Cells("LY_DO_BT").Value
        cboMucUuTien.SelectedValue = dgrDanhSach_1.Rows(intRowPBT).Cells("MS_UU_TIEN").Value
        cboNguoiLap.SelectedValue = dgrDanhSach_1.Rows(intRowPBT).Cells("NGUOI_LAP").Value
        txtusernameNL.Text = dgrDanhSach_1.Rows(intRowPBT).Cells("USERNAME_NGUOI_LAP").Value
        If IsDBNull(dgrDanhSach_1.Rows(intRowPBT).Cells("NGUOI_GIAM_SAT").Value) Then
            cboGS_Vien.SelectedValue = -1
        Else
            cboGS_Vien.SelectedValue = dgrDanhSach_1.Rows(intRowPBT).Cells("NGUOI_GIAM_SAT").Value
        End If

        dtNgayLap.Value = dgrDanhSach_1.Rows(intRowPBT).Cells("NGAY_LAP").Value
        dtGioLap.Text = Format(dgrDanhSach_1.Rows(intRowPBT).Cells("GIO_LAP").Value.ToString, "Long time")
        dtNgayBDKH.Value = dgrDanhSach_1.Rows(intRowPBT).Cells("NGAY_BD_KH").Value
        dtNgayKTKH.Value = dgrDanhSach_1.Rows(intRowPBT).Cells("NGAY_KT_KH").Value
        txtGiohong.Text = Format(dgrDanhSach_1.Rows(intRowPBT).Cells("GIO_HONG").Value.ToString, "Long time")
        txtNgayhong.Text = Format(dgrDanhSach_1.Rows(intRowPBT).Cells("NGAY_HONG").Value.ToString, "Short date")

        If cboTinhTrangPBT.SelectedValue = 4 Then
            BtnKhoaPBT.Enabled = False
            TinhtrangPBT_Lock(False)
        Else
            BtnKhoaPBT.Enabled = True
            If Not Commons.Modules.PermisString.Equals("Read only") Then TinhtrangPBT_Lock(True)
            If cboTinhTrangPBT.SelectedValue = 2 Then
                BtnDuyetPBT.Enabled = False
            ElseIf cboTinhTrangPBT.SelectedValue = 3 Then
                BtnDuyetPBT.Enabled = False
            End If
        End If
    End Sub
    Function QueryPhieuBaoTri()
        Dim str As String = ""
        str = "SELECT DISTINCT PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI.MS_MAY, PHIEU_BAO_TRI.TINH_TRANG_PBT, TINH_TRANG_PBT.TEN_TINH_TRANG, " &
            " PHIEU_BAO_TRI.MS_LOAI_BT, LOAI_BAO_TRI.TEN_LOAI_BT,LY_DO_BT, PHIEU_BAO_TRI.NGAY_LAP, PHIEU_BAO_TRI.GIO_LAP, PHIEU_BAO_TRI.MS_UU_TIEN, " &
            " MUC_UU_TIEN.TEN_UU_TIEN, PHIEU_BAO_TRI.NGUOI_LAP, PHIEU_BAO_TRI.USERNAME_NGUOI_LAP, " &
            " CONG_NHAN.HO + '' + CONG_NHAN.TEN AS HO_TEN, PHIEU_BAO_TRI.NGUOI_GIAM_SAT, PHIEU_BAO_TRI.NGAY_BD_KH,  " &
            " PHIEU_BAO_TRI.NGAY_KT_KH, PHIEU_BAO_TRI.GIO_HONG, PHIEU_BAO_TRI.NGAY_HONG " &
            " FROM PHIEU_BAO_TRI INNER JOIN  TINH_TRANG_PBT ON PHIEU_BAO_TRI.TINH_TRANG_PBT = TINH_TRANG_PBT.STT LEFT JOIN    " &
            " MUC_UU_TIEN ON PHIEU_BAO_TRI.MS_UU_TIEN = MUC_UU_TIEN.MS_UU_TIEN INNER JOIN  LOAI_BAO_TRI ON    " &
            " PHIEU_BAO_TRI.MS_LOAI_BT = LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN  CONG_NHAN ON PHIEU_BAO_TRI.NGUOI_LAP =  " &
            " CONG_NHAN.MS_CONG_NHAN   INNER JOIN MAY ON PHIEU_BAO_TRI.MS_MAY=MAY.MS_MAY INNER JOIN NHOM_MAY ON  " &
            " MAY.MS_NHOM_MAY=NHOM_MAY.MS_NHOM_MAY  INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY  " &
            " INNER JOIN NHOM_LOAI_MAY ON  NHOM_LOAI_MAY.MS_LOAI_MAY=LOAI_MAY.MS_LOAI_MAY INNER JOIN NHOM ON  " &
            " NHOM.GROUP_ID=NHOM_LOAI_MAY.GROUP_ID  INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID=NHOM_NHA_XUONG.GROUP_ID  " &
            " INNER JOIN USERS ON USERS.GROUP_ID=NHOM.GROUP_ID  " &
             " WHERE USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        If cboDiaDiem_1.SelectedValue <> "-1" Then
            str = str + " and NHOM_NHA_XUONG.MS_N_XUONG='" & cboDiaDiem_1.SelectedValue & "'"
        End If
        If cboLoaiThietBi_1.SelectedValue <> "-1" Then
            str = str + " AND   LOAI_MAY.MS_LOAI_MAY='" & cboLoaiThietBi_1.SelectedValue & "'"
        End If
        If cboNhomThietBi_1.SelectedValue <> "-1" Then
            str = str + " AND NHOM_MAY.MS_NHOM_MAY='" & cboNhomThietBi_1.SelectedValue & "'"
        End If
        If cboMS_TB_1.SelectedValue <> "-1" Then
            str = str + " AND MAY.MS_MAY=N'" & cboMS_TB_1.SelectedValue & "'"
        End If
        str = str + " AND NGAY_LAP BETWEEN CONVERT(DATETIME,'" & dtTuNgay_1.Value & "' ,103) AND  CONVERT(DATETIME,'" & dtDenNgay_1.Value & "',103)"
        If radPhieuBaoTriChuaNghiemThu_1.Checked Then
            str = str + " AND TINH_TRANG_PBT < 3"
        Else
            str = str + " AND TINH_TRANG_PBT >2"
        End If
        str = str + " order by PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI DESC"
        Return str
    End Function
    Sub BindData()
        RefreshData()
        grdHinh.Columns.Clear()
        dgrDanhSachCongViecChinh_2.DataSource = System.DBNull.Value
        dgrDanhSachCongViecPhuTro_2.DataSource = System.DBNull.Value
        dgrDanhSachVatTuPhuTung.DataSource = System.DBNull.Value
        dgrViTriPhuTung_2.DataSource = System.DBNull.Value
        Dim tb As New DataTable
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QueryPhieuBaoTri()))
        dgrDanhSach_1.DataSource = tb
        dgrDanhSach_1.Columns("TINH_TRANG_PBT").Visible = False
        dgrDanhSach_1.Columns("MS_LOAI_BT").Visible = False
        dgrDanhSach_1.Columns("GIO_LAP").Visible = False
        dgrDanhSach_1.Columns("LY_DO_BT").Visible = False
        dgrDanhSach_1.Columns("MS_UU_TIEN").Visible = False
        dgrDanhSach_1.Columns("NGAY_KT_KH").Visible = False
        dgrDanhSach_1.Columns("USERNAME_NGUOI_LAP").Visible = False
        dgrDanhSach_1.Columns("NGUOI_GIAM_SAT").Visible = False
        dgrDanhSach_1.Columns("GIO_HONG").Visible = False
        dgrDanhSach_1.Columns("NGAY_HONG").Visible = False
        dgrDanhSach_1.Columns("NGUOI_LAP").Visible = False
        dgrDanhSach_1.Columns("HO_TEN").Visible = False
        With dgrDanhSach_1
            .Columns("MS_PHIEU_BAO_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
            .Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
            .Columns("TEN_TINH_TRANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TINH_TRANG", Commons.Modules.TypeLanguage)
            .Columns("TEN_LOAI_BT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_LOAI_BT", Commons.Modules.TypeLanguage)
            .Columns("NGAY_LAP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_LAP", Commons.Modules.TypeLanguage)
            .Columns("TEN_UU_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_UU_TIEN", Commons.Modules.TypeLanguage)
            .Columns("NGAY_BD_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_BD_KH", Commons.Modules.TypeLanguage)

        End With
        If dgrDanhSach_1.Rows.Count = 0 Then
            TinhtrangPBT_Lock(False)
            BtnDuyetPBT.Enabled = False
            BtnKhoaPBT.Enabled = False

        Else
            If cboTinhTrangPBT.SelectedValue = 4 Then
                TinhtrangPBT_Lock(False)
            Else
                TinhtrangPBT_Lock(True)
                If cboTinhTrangPBT.SelectedValue = 3 Or cboTinhTrangPBT.SelectedValue = 2 Then
                    BtnDuyetPBT.Enabled = False
                End If
            End If
        End If
        Try
            Me.dgrDanhSach_1.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrDanhSach_1.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub TinhtrangPBT_Lock(ByVal chon As Boolean)
        btnSua_1.Enabled = chon
        btnThem_2.Enabled = chon
        btnXoa_2.Enabled = chon
        'btnThem_3.Enabled = chon
        'btnXoa_3.Enabled = chon
        ' ''btnThemSuaCV_4.Enabled = chon
        ' ''btnThemSuaDV_4.Enabled = chon
        ' ''btnXoa_4.Enabled = chon
        btnXoa_1.Enabled = chon
        BtnXemtailieu.Enabled = chon
        BtnXemtailieu_2.Enabled = chon
        'BtnKhoaPBT.Enabled = chon
        BtnDuyetPBT.Enabled = chon
        BtnKhoaPBT.Enabled = chon
    End Sub
    Sub HideButton1(ByVal flg As Boolean)
        btnXoa_1.Visible = flg
        btnIn_1.Visible = flg
        btnThem_1.Visible = flg
        btnSua_1.Visible = flg
        btnThoat_1.Visible = flg
        BtnKhoaPBT.Visible = flg
        BtnDuyetPBT.Visible = flg
        BtnXemtailieu.Visible = flg
        radPhieuBaoTriChuaNghiemThu_1.Enabled = flg
        radPhieuBaoTriDaNghiemThu_1.Enabled = flg
        cboDiaDiem_1.Enabled = flg
        cboMS_TB_1.Enabled = flg
        cboLoaiThietBi_1.Enabled = flg
        cboNhomThietBi_1.Enabled = flg
        dtTuNgay_1.Enabled = flg
        dtDenNgay_1.Enabled = flg
    End Sub
    Sub VisibleButtonGhi(ByVal chon As Boolean)
        btnGhi_1.Visible = chon
        btnKhongGhi_1.Visible = chon
        BtnChonTaiLieu.Visible = chon
        grdHinh.AllowUserToAddRows = chon
        dgrDanhSach_1.Enabled = Not chon
    End Sub
#End Region

#Region "event tab1"

    Private Sub btnSua_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua_1.Click
        If dgrDanhSach_1.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim str As String = ""
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=null WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If

        bThem = 1
        bPBT = False
        EnableControl(True)
        HideButton1(False)
        VisibleButtonXoa(False)
        VisibleButtonGhi(True)
        str = "SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "'" &
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
            cboMS_ThietBi.Enabled = False
        Else
            cboMS_ThietBi.Enabled = True
        End If

        Try
            str = "DROP TABLE TAM12" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "create TABLE [dbo].TAM12" & Commons.Modules.UserName & " (STT INT,DUONG_DAN NVARCHAR(255),TEN_TAI_LIEU NVARCHAR(255),STT_YC_NSD INT,STT_GSTT INT,HINH NVARCHAR(150))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "SELECT DUONG_DAN FROM PHIEU_BAO_TRI_HINH WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        intSTT = Commons.Modules.ObjSystems.LaySTTChoTaiLieu(str)
        Try
            grdHinh.Columns("TEN_TAI_LIEU").ReadOnly = False
        Catch ex As Exception

        End Try
        grdHinh.AllowUserToAddRows = True
        cboNguoiLap.Value = "MS_CONG_NHAN"
        cboNguoiLap.Display = "HO_TEN_CONG_NHAN"
        cboNguoiLap.StoreName = "GetCONG_NHANs1"
        cboNguoiLap.DropDownWidth = 200
        cboNguoiLap.BindDataSource()
        ShowData()
        cboMS_ThietBi.Focus()
        AddHandler dtNgayKTKH.Validating, AddressOf Me.dtNgayKTKH_Validating
        AddHandler txtGiohong.Validating, AddressOf Me.txtGiohong_Validating
        AddHandler txtNgayhong.Validating, AddressOf Me.txtNgayhong_Validating
        AddHandler dtNgayLap.Validating, AddressOf Me.dtNgayLap_Validating
        AddHandler dtGioLap.Validating, AddressOf Me.dtGioLap_Validating
    End Sub
    Private Sub BtnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVe.Click
        HideButton1(True)
        VisibleButtonXoa(False)
        VisibleButtonGhi(False)
        intTabChanged = -1
    End Sub
    Private Sub btnThem_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem_1.Click
        bThem = 1
        bPBT = True
        cboNguoiLap.Value = "MS_CONG_NHAN"
        cboNguoiLap.Display = "HO_TEN_CONG_NHAN"
        cboNguoiLap.StoreName = "GetCONG_NHANs1"
        cboNguoiLap.DropDownWidth = 200
        cboNguoiLap.BindDataSource()
        cboTinhTrangPBT.SelectedValue = 1
        dtGioLap.Text = Format(Now(), "Long time")
        dtNgayLap.Value = Now()
        dtNgayBDKH.Value = Now()
        dtNgayKTKH.Value = Now()
        HideButton1(False)
        VisibleButtonXoa(False)
        VisibleButtonGhi(True)
        RefreshData()
        EnableControl(True)
        bThem = 1
        cboMS_ThietBi.SelectedValue = -1
        cboLoai_BT.SelectedValue = -1
        cboMucUuTien.SelectedValue = -1
        cboNguoiLap.SelectedValue = -1

        Dim str As String = ""
        Try
            str = "DROP TABLE TAM12" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "create TABLE [dbo].TAM12" & Commons.Modules.UserName & " (STT INT,DUONG_DAN NVARCHAR(255),TEN_TAI_LIEU NVARCHAR(255),STT_YC_NSD INT,STT_GSTT INT,HINH NVARCHAR(150))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "SELECT DUONG_DAN FROM PHIEU_BAO_TRI_HINH WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        intSTT = Commons.Modules.ObjSystems.LaySTTChoTaiLieu(str)
        Try
            grdHinh.Columns("TEN_TAI_LIEU").ReadOnly = False
        Catch ex As Exception

        End Try
        grdHinh.AllowUserToAddRows = True
        txtMaSoPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI()
        txtusernameNL.Text = Commons.Modules.UserName
        BindDataHinh()
        cboMS_ThietBi.Focus()
        AddHandler dtNgayKTKH.Validating, AddressOf Me.dtNgayKTKH_Validating
        AddHandler txtGiohong.Validating, AddressOf Me.txtGiohong_Validating
        AddHandler txtNgayhong.Validating, AddressOf Me.txtNgayhong_Validating
        AddHandler dtNgayLap.Validating, AddressOf Me.dtNgayLap_Validating
        AddHandler dtGioLap.Validating, AddressOf Me.dtGioLap_Validating

    End Sub

    Private Sub btnGhi_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi_1.Click
        If isValidated() Then
            If txtGiohong.Text <> "  :" And Not IsDate(txtGiohong.Text) Then
                'XtraMessageBox.Show("giờ hòng không hợp lệ")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtGiohong.Text = "  :"
                txtGiohong.Focus()
                Exit Sub
            End If
            If txtNgayhong.Text <> "  /  /" And Not IsDate(txtNgayhong.Text) Then
                'XtraMessageBox.Show("ngày hòng không hợp lệ")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtNgayhong.Text = "  /  /"
                txtNgayhong.Focus()
                Exit Sub
            End If
            If dtNgayBDKH.Value > dtNgayKTKH.Value Then
                'XtraMessageBox.Show("ngày kết thúc kế hoạch không được nhỏ hơn ngày bắt đầu kế hoạch")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKTKH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                dtNgayKTKH.Focus()
                Exit Sub
            End If
            Dim objPHIEU_BAO_TRIInfo As New clsPHIEU_BAO_TRIInfo()
            objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
            objPHIEU_BAO_TRIInfo.TINH_TRANG_PBT = cboTinhTrangPBT.SelectedValue
            objPHIEU_BAO_TRIInfo.MS_MAY = cboMS_ThietBi.SelectedValue
            objPHIEU_BAO_TRIInfo.MS_LOAI_BT = cboLoai_BT.SelectedValue
            objPHIEU_BAO_TRIInfo.NGAY_LAP = Format(dtNgayLap.Value, "Short date")
            objPHIEU_BAO_TRIInfo.GIO_LAP = Format(dtGioLap.Text, "Long time")
            objPHIEU_BAO_TRIInfo.LY_DO_BT = txtLydo.Text
            objPHIEU_BAO_TRIInfo.MS_UU_TIEN = cboMucUuTien.SelectedValue
            objPHIEU_BAO_TRIInfo.NGAY_BD_KH = Format(dtNgayBDKH.Value, "Short date")
            objPHIEU_BAO_TRIInfo.NGAY_KT_KH = Format(dtNgayKTKH.Value, "Short date")
            objPHIEU_BAO_TRIInfo.NGUOI_LAP = cboNguoiLap.SelectedValue
            objPHIEU_BAO_TRIInfo.USERNAME_NGUOI_LAP = txtusernameNL.Text
            objPHIEU_BAO_TRIInfo.NGUOI_GIAM_SAT = cboGS_Vien.SelectedValue
            objPHIEU_BAO_TRIInfo.GIO_HONG = txtGiohong.Text
            objPHIEU_BAO_TRIInfo.NGAY_HONG = txtNgayhong.Text
            Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
            Dim MS_PBT As String = ""
            If bPBT Then
                txtMaSoPBT.Text = objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI(objPHIEU_BAO_TRIInfo)
            Else
                objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI(objPHIEU_BAO_TRIInfo)
            End If
            Dim str As String = ""
            str = "DELETE FROM PHIEU_BAO_TRI_HINH WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'DBCC CHECKIDENT(EOR_REFFERENCE,RESEED,0)DBCC CHECKIDENT(EOR_REFFERENCE,RESEED)"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            For i As Integer = 0 To grdHinh.Rows.Count - 2
                If grdHinh.Rows(i).Cells("STT_YC_NSD").Value.ToString = "" And grdHinh.Rows(i).Cells("STT_GSTT").Value.ToString = "" Then
                    objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI_HINH(txtMaSoPBT.Text.Trim, grdHinh.Rows(i).Cells("TEN_TAI_LIEU").Value, grdHinh.Rows(i).Cells("DUONG_DAN").Value, 0, 0)
                Else
                    If grdHinh.Rows(i).Cells("STT_YC_NSD").Value.ToString = "" Then
                        objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI_HINH(txtMaSoPBT.Text.Trim, grdHinh.Rows(i).Cells("TEN_TAI_LIEU").Value.ToString, grdHinh.Rows(i).Cells("DUONG_DAN").Value, 0, grdHinh.Rows(i).Cells("STT_GSTT").Value)
                    Else
                        If grdHinh.Rows(i).Cells("STT_GSTT").Value.ToString = "" Then
                            objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI_HINH(txtMaSoPBT.Text.Trim, grdHinh.Rows(i).Cells("TEN_TAI_LIEU").Value.ToString(), grdHinh.Rows(i).Cells("DUONG_DAN").Value, grdHinh.Rows(i).Cells("STT_YC_NSD").Value, 0)
                        Else
                            objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI_HINH(txtMaSoPBT.Text.Trim, grdHinh.Rows(i).Cells("TEN_TAI_LIEU").Value, grdHinh.Rows(i).Cells("DUONG_DAN").Value, grdHinh.Rows(i).Cells("STT_YC_NSD").Value, grdHinh.Rows(i).Cells("STT_GSTT").Value)
                        End If
                    End If
                End If
            Next

            Dim tb As New DataTable()
            str = "SELECT DUONG_DAN,HINH FROM TAM12" & Commons.Modules.UserName & " WHERE STT_YC_NSD =0 AND STT_GSTT=0"
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            For i As Integer = 0 To tb.Rows.Count - 1
                Commons.Modules.ObjSystems.LuuDuongDan(tb.Rows(i).Item("HINH"), tb.Rows(i).Item("DUONG_DAN"))
            Next
            str = "DELETE FROM TAM12" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Try
                str = "DROP TABLE TAM12" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            HideButton1(True)
            VisibleButtonXoa(False)
            VisibleButtonGhi(False)
            EnableControl(False)
            LoadcboDiadiem()
            LoadcboLoaithietbi()
            LoadcboNhommay()
            LoadcboMS_MAY()
            str = txtMaSoPBT.Text
            BindData()
            For i As Integer = 0 To dgrDanhSach_1.Rows.Count - 1
                If dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value = str Then
                    dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Selected = True
                    dgrDanhSach_1.CurrentCell = dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI")
                    dgrDanhSach_1.Focus()
                    Exit For
                Else
                    dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Selected = False
                End If
            Next
            bThem = -1
            bPBT = False
            RemoveHandler dtNgayKTKH.Validating, AddressOf Me.dtNgayKTKH_Validating
            RemoveHandler txtGiohong.Validating, AddressOf Me.txtGiohong_Validating
            RemoveHandler txtNgayhong.Validating, AddressOf Me.txtNgayhong_Validating
            RemoveHandler dtNgayLap.Validating, AddressOf Me.dtNgayLap_Validating
            RemoveHandler dtGioLap.Validating, AddressOf Me.dtGioLap_Validating
        End If

    End Sub

    Private Sub btnKhongGhi_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi_1.Click
        RemoveHandler dtNgayKTKH.Validating, AddressOf Me.dtNgayKTKH_Validating
        RemoveHandler txtGiohong.Validating, AddressOf Me.txtGiohong_Validating
        RemoveHandler txtNgayhong.Validating, AddressOf Me.txtNgayhong_Validating
        RemoveHandler dtNgayLap.Validating, AddressOf Me.dtNgayLap_Validating
        RemoveHandler dtGioLap.Validating, AddressOf Me.dtGioLap_Validating
        Dim str As String = ""
        Try
            str = "DROP TABLE TAM12" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        cboNguoiLap.Value = "MS_CONG_NHAN"
        cboNguoiLap.Display = "HO_TEN_CONG_NHAN"
        cboNguoiLap.StoreName = "GetCONG_NHANs1"
        cboNguoiLap.DropDownWidth = 200
        cboNguoiLap.BindDataSource()
        HideButton1(True)
        VisibleButtonXoa(False)
        VisibleButtonGhi(False)
        RefreshData()
        If Not isValidated() Then
            ErrorProvider1.Clear()
        End If
        LoadcboDiadiem()
        LoadcboLoaithietbi()
        LoadcboNhommay()
        LoadcboMS_MAY()
        BindData()
        EnableControl(False)
        bThem = -1
        bPBT = False
    End Sub

    Private Sub btnThoat_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat_1.Click
        Try
            bThoat = True
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnXoaHinh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaHinh.Click
        If grdHinh.Rows.Count > 0 Then
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaHinh", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_HINH(txtMaSoPBT.Text.Trim, grdHinh.Rows(intRowHinh).Cells("STT").Value)
                BindDataHinh()
            End If
        End If
    End Sub
    Private Sub BtnXoaPBT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaPBT.Click
        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
        If Not objPHIEU_BAO_TRIController.CheckPHIEU_BAO_TRI(txtMaSoPBT.Text.Trim) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtraPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Try
                Commons.Modules.SQLString = "UPDATE EOR_SERVICE_CHUNG SET MS_PHIEU_BAO_TRI=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                Commons.Modules.SQLString = "UPDATE EOR_SERVICE_MNR SET MS_PHIEU_BAO_TRI=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                Commons.Modules.SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT=NULL WHERE MS_PBT='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_PBT=NULL WHERE MS_PBT='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT=NULL WHERE MS_PBT='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                Commons.Modules.SQLString = "UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Catch ex As Exception

            End Try
            objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI(txtMaSoPBT.Text)
            LoadcboDiadiem()
            LoadcboLoaithietbi()
            LoadcboNhommay()
            LoadcboMS_MAY()
            RefreshData()
            BindData()

            If dgrDanhSach_1.RowCount = 0 Then
                cboMS_ThietBi.SelectedValue = -1
                cboLoai_BT.SelectedValue = -1
                cboMucUuTien.SelectedValue = -1
                cboNguoiLap.SelectedValue = -1
            End If
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTaiLieu.Click
        Dim str As String = ""
        For i As Integer = 0 To grdHinh.Rows.Count - 2
            Dim stt_yc As Integer = Nothing
            Dim stt_gs As Integer = Nothing
            Dim stt As Integer = Nothing
            If grdHinh.Rows(i).Cells("STT").Value.ToString <> "" Then
                stt = grdHinh.Rows(i).Cells("STT").Value
            End If
            If grdHinh.Rows(i).Cells("STT_YC_NSD").Value.ToString <> "" Then
                stt_yc = grdHinh.Rows(i).Cells("STT_YC_NSD").Value
            End If
            If grdHinh.Rows(i).Cells("STT_GSTT").Value.ToString <> "" Then
                stt_gs = grdHinh.Rows(i).Cells("STT_GSTT").Value
            End If
            str = "INSERT INTO TAM12" & Commons.Modules.UserName & "(STT,DUONG_DAN,TEN_TAI_LIEU,STT_YC_NSD,STT_GSTT,HINH) VALUES(" & stt & ",N'" &
            grdHinh.Rows(i).Cells("DUONG_DAN").Value & "',N'" & grdHinh.Rows(i).Cells("TEN_TAI_LIEU").Value & "'," & stt_yc & "," & stt_gs &
            ",N'" & grdHinh.Rows(i).Cells("HINH").Value.ToString & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
        Dim frm As New FrmChonTaiLieu()
        frm.MS_MAY = cboMS_ThietBi.SelectedValue
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim tb As New DataTable()
            str = "SELECT DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,  STT,DUONG_DAN,TEN_TAI_LIEU,CASE STT_YC_NSD WHEN   0 THEN NULL ELSE STT_YC_NSD END AS STT_YC_NSD,CASE STT_GSTT WHEN 0 THEN NULL ELSE STT_GSTT END AS STT_GSTT,HINH FROM TAM12" & Commons.Modules.UserName & " ORDER BY STT DESC "
            TBHinh = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            grdHinh.DataSource = TBHinh
            grdHinh.Columns("MS_PHIEU_BAO_TRI").Visible = False
            grdHinh.Columns("STT").Visible = False
            grdHinh.Columns("STT_YC_NSD").Visible = False
            grdHinh.Columns("STT_GSTT").Visible = False
            grdHinh.Columns("HINH").Visible = False
            str = "DELETE FROM TAM12" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End If
    End Sub

    Private Sub grdHinh_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdHinh.CellBeginEdit
        If btnGhi_1.Visible And Not btnKhongGhi_1.Focused() Then
            If IsDBNull(grdHinh.Rows(e.RowIndex).Cells("DUONG_DAN").Value) Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub grdHinh_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdHinh.CellDoubleClick
        If btnGhi_1.Visible And Not btnKhongGhi_1.Focused() Then
            If grdHinh.Columns(e.ColumnIndex).Name = "DUONG_DAN" Then
                ofdDuongdan.Multiselect = True
                ofdDuongdan.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ofdDuongdan_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdDuongdan.FileOk
        LayDuongDan()
    End Sub
    Sub LayDuongDan()
        Dim str As String = ""

        Dim SERVER_PATH As String = Commons.Modules.ObjSystems.CapnhatTL(True, txtMaSoPBT.Text)

        Dim FILE_PATHs As String()
        FILE_PATHs = ofdDuongdan.FileNames()
        Dim tb As New DataTable()
        tb = TBHinh.Copy()
        For i As Integer = 0 To FILE_PATHs.Length - 1
            Dim dr As DataRow
            dr = tb.NewRow
            dr.Item(0) = txtMaSoPBT.Text
            dr.Item(1) = 0
            dr.Item(3) = SERVER_PATH & "\" & txtMaSoPBT.Text & "_" & IIf(Day(Now()).ToString.Length < 2, 0 & Day(Now()), Day(Now())) & IIf(Month(Now()).ToString.Length < 2, 0 & Month(Now()), Month(Now())) & Year(Now()) & "_" & intSTT & Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs(i))
            dr.Item(2) = ""
            dr.Item(4) = ""
            dr.Item(5) = 0
            dr.Item(6) = 0
            tb.Rows.Add(dr)
            str = "INSERT INTO TAM12" & Commons.Modules.UserName & " (DUONG_DAN,HINH,STT_YC_NSD,STT_GSTT ) VALUES(N'" & SERVER_PATH & "\" & txtMaSoPBT.Text & "_" & IIf(Day(Now()).ToString.Length < 2, 0 & Day(Now()), Day(Now())) & IIf(Month(Now()).ToString.Length < 2, 0 & Month(Now()), Month(Now())) & Year(Now()) & "_" & intSTT & Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs(i)) & "','" & FILE_PATHs(i) & "'," & 0 & "," & 0 & ")"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            intSTT = intSTT + 1
        Next
        TBHinh = tb.Copy()
        grdHinh.DataSource = TBHinh
    End Sub
    Private Sub dtKTTT_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtKTTT.CloseUp
        txtNgayhong.Text = Format(dtKTTT.Value, "Short date")
        txtNgayhong.Focus()
    End Sub

    Private Sub dgrDanhSach_1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhSach_1.RowEnter
        intRowPBT = e.RowIndex
        If btnGhi_1.Visible = False Then
            cboNguoiLap.Value = "MS_CONG_NHAN"
            cboNguoiLap.Display = "HO_TEN_CONG_NHAN"
            cboNguoiLap.StoreName = "GetCONG_NHANs2"
            cboNguoiLap.DropDownWidth = 200
            cboNguoiLap.BindDataSource()
        Else
            cboNguoiLap.Value = "MS_CONG_NHAN"
            cboNguoiLap.Display = "HO_TEN_CONG_NHAN"
            cboNguoiLap.StoreName = "GetCONG_NHANs1"
            cboNguoiLap.DropDownWidth = 200
            cboNguoiLap.BindDataSource()
        End If
        ShowData()
        'BindData1()
        'BindData11()
        BindDataHinh()
        'LoadCVChinh3()
        'LoadDanhsachDVThueNgoai()
        'BindData12()
        ''tab 5
        'BindData5()
        'If cboTinhTrangPBT.SelectedValue = 4 Then
        '    EnableButton5(False)
        'Else
        '    EnableButton5(True)
        'End If
        ''QuyenUser()
        'LoadNgayBatDauBaoTri(Me.txtMaSoPBT.Text)
        'LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        'LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        ''end tab 5
        If Commons.Modules.PermisString.Equals("Read only") Then TinhtrangPBT_Lock(False)
    End Sub

    Private Sub btnXoa_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa_1.Click
        Dim str As String = ""
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        intTabChanged = 0
        HideButton1(False)
        VisibleButtonXoa(True)
        VisibleButtonGhi(False)
        BtnTroVe.Left = BtnXoaHinh.Left + BtnXoaHinh.Width + 1
        BtnTroVe.Top = BtnXoaPBT.Top - 1
    End Sub

    Private Sub BtnDuyetPBT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDuyetPBT.Click
        Dim str As String = ""
        str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
        " WHERE USERNAME='" & Commons.Modules.UserName & "' AND CHUC_NANG.STT=7 "
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While objReader.Read
            If objReader.Item("STT").ToString <> "" Then
                Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 2)
                BindData()
            End If
            objReader.Close()
            Exit Sub
        End While
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPheDuyet", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        objReader.Close()
    End Sub

    Private Sub BtnKhoaPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhoaPBT.Click
        'If cboTinhTrangPBT.SelectedValue <> 3 Then
        '    'XtraMessageBox.Show(" phiếu bảo trì chưa nghiệm thu nên không được khóa")
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgPBTChuaNT", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        '    Exit Sub
        'End If
        'If cboTinhTrangPBT.SelectedValue = 3 Then
        '    Dim str As String = ""
        '    str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " & _
        '    " WHERE USERNAME='" & Commons.Modules.UserName & "' AND CHUC_NANG.STT=9 "
        '    Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        '    While objReader.Read
        '        If objReader.Item("STT").ToString <> "" Then
        '            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhoaPBT", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        '            If Traloi = vbYes Then
        '                Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
        '                objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 4)
        '                BindData()
        '            End If
        '        End If
        '        objReader.Close()
        '        Exit Sub
        '    End While
        '    objReader.Close()
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgLockPBT", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        If cboTinhTrangPBT.SelectedValue <> 3 Then
            'XtraMessageBox.Show(" phiếu bảo trì chưa nghiệm thu nên không được khóa")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPBTChuaNT", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        If cboTinhTrangPBT.SelectedValue = 3 Then
            Dim str As String = ""
            str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
            " WHERE USERNAME='" & Commons.Modules.UserName & "' AND CHUC_NANG.STT=9 "
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                If objReader.Item("STT").ToString <> "" Then
                    Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhoaPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                    If Traloi = vbYes Then
                        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                        objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 4)
                        Dim objReader1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHinhThucBT", cboLoai_BT.SelectedValue)
                        Try
                            While objReader1.Read
                                If objReader1.Item("MS_HT_BT") = 1 Then
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN", cboMS_ThietBi.SelectedValue, cboLoai_BT.SelectedValue, Format(dtNgayLap.Value, "Short date"))
                                End If
                            End While
                            objReader1.Close()
                        Catch ex As Exception
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN", cboMS_ThietBi.SelectedValue, cboLoai_BT.SelectedValue, Format(dtNgayLap.Value, "Short date"))
                        End Try
                        str = txtMaSoPBT.Text
                        BindData()
                        For i As Integer = 0 To dgrDanhSach_1.Rows.Count - 1
                            If dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value = str Then
                                dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Selected = True
                                dgrDanhSach_1.CurrentCell = dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI")
                                dgrDanhSach_1.Focus()
                                Exit For
                            Else
                                dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Selected = False
                            End If
                        Next
                    End If
                End If
                objReader.Close()
                If Commons.Modules.PermisString.Equals("Read only") Then
                    EnableButton(False)
                Else
                    If cboTinhTrangPBT.SelectedValue < 4 Then
                        EnableButton(True)
                        If radPhieuBaoTriChuaNghiemThu_1.Checked Then
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
                    End If
                End If

                Exit Sub
            End While
            objReader.Close()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLockPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        End If
    End Sub

    Private Sub cboDiaDiem_1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiaDiem_1.SelectionChangeCommitted
        LoadcboLoaithietbi()
        LoadcboNhommay()
        LoadcboMS_MAY()
        BindData()

    End Sub

    Private Sub cboLoaiThietBi_1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiThietBi_1.SelectionChangeCommitted
        LoadcboNhommay()
        LoadcboMS_MAY()
        BindData()
    End Sub

    Private Sub cboNhomThietBi_1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNhomThietBi_1.SelectionChangeCommitted
        LoadcboMS_MAY()
        BindData()
    End Sub

    Private Sub cboMS_TB_1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMS_TB_1.SelectionChangeCommitted
        BindData()
    End Sub
    Private Sub dtTuNgay_1_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtTuNgay_1.CloseUp
        BindData()
    End Sub

    Private Sub dtDenNgay_1_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDenNgay_1.CloseUp
        'If dtDenNgay_1.Value < dtTuNgay_1.Value Then
        '    'XtraMessageBox.Show("Đến ngày không được nhỏ hơn từ ngày")
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTungayDenNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If
        BindData()
    End Sub

    Private Sub radPhieuBaoTriChuaNghiemThu_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles radPhieuBaoTriChuaNghiemThu_1.CheckedChanged
        If radPhieuBaoTriChuaNghiemThu_1.Checked Then
            BindData()
            Dim str As String = ""
            str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
            " WHERE USERNAME='" & Commons.Modules.UserName & "' AND CHUC_NANG.STT=8 "
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
            btnIn_1.Enabled = True ' False
            btnThem_1.Enabled = True
        End If
    End Sub

    Private Sub radPhieuBaoTriDaNghiemThu_1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles radPhieuBaoTriDaNghiemThu_1.CheckedChanged
        If radPhieuBaoTriDaNghiemThu_1.Checked Then
            BindData()
            Dim str As String = ""
            str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
            " WHERE USERNAME='" & Commons.Modules.UserName & "' AND CHUC_NANG.STT=8 "
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
            btnIn_1.Enabled = True
            btnThem_1.Enabled = False
        End If
    End Sub
    Private Sub dtNgayKTKH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles dtNgayKTKH.Validating
        If btnKhongGhi_1.Focused() Then
            Exit Sub
        End If
        If Date.Parse(dtNgayKTKH.Value) < Date.Parse(dtNgayBDKH.Value) Then
            'XtraMessageBox.Show("ngày kết thúc kế hoạch không được nhỏ hơn ngày bắt đầu kế hoạch")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKTKH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtNgayKTKH.Focus()
            e.Cancel = True
        End If
    End Sub
    Private Sub txtGiohong_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) ' Handles txtGiohong.Validating
        If btnKhongGhi_1.Focused() Then
            Exit Sub
        End If
        If txtGiohong.Text <> "  :" Then
            If Not IsDate(txtGiohong.Text) Then
                ' Gi? không h?p l? ! Gi? ph?i có ki?u HH:MM (24h) !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtGiohong.Text = "  :"
                txtGiohong.Focus()
                e.Cancel = True

            End If
        End If

    End Sub

    Private Sub txtNgayhong_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtNgayhong.Validating
        If btnKhongGhi_1.Focused() Then
            Exit Sub
        End If
        If txtNgayhong.Text <> "  /  /" Then
            If Not IsDate(txtNgayhong.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtNgayhong.Text = "  /  /"
                txtNgayhong.Focus()
                e.Cancel = True
                Exit Sub
            ElseIf Date.Parse(txtNgayhong.Text) < Date.Parse("01/01/1900") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtNgayhong.Text = "  /  /"
                txtNgayhong.Focus()
                e.Cancel = True
                Exit Sub
            Else
                If Date.Parse(txtNgayhong.Text) > Date.Parse(dtNgayLap.Value) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHongLonHonHienTai1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtNgayhong.Text = "  /  /"
                    txtNgayhong.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub dtNgayLap_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles dtNgayLap.Validating
        If btnKhongGhi_1.Focused() Then
            Exit Sub
        End If
        If Date.Parse(dtNgayLap.Value) > Now() Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtNgayLap.Focus()
            e.Cancel = True

        End If
    End Sub
    Private Sub dtGioLap_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles dtGioLap.Validating
        If dtGioLap.Text <> "  :" Then
            If Not IsDate(dtGioLap.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtGioLap.Text = "  :"
                dtGioLap.Focus()
                e.Cancel = True

            End If
        End If
    End Sub
#End Region

#Region "private tab2"


    Sub LoadTableTmp()
        Dim str As String = ""
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName &
        " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT, MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(30),STT INT ,MS_VI_TRI_PT NVARCHAR(50),SL_KH FLOAT, SL_TT FLOAT,SL_CUM FLOAT,THAY_SUA BIT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI NVARCHAR(30),MS_CV INT, MA_CV NVARCHAR(255),MS_BO_PHAN NVARCHAR(50),TEN_BO_PHAN NVARCHAR(255),SO_GIO_KH FLOAT," &
                " HANG_MUC_ID INT ,TEN_HANG_MUC NVARCHAR(255),EOR_ID NVARCHAR(30),TEN_CHUYEN_MON NVARCHAR(200),NGAY_HOAN_THANH DATETIME , TEN_BAC_THO NVARCHAR(200),GHI_CHU NVARCHAR(255),TON_TAI BIT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CV_PHU_TRO_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE  TABLE DBO.PHIEU_BAO_TRI_CV_PHU_TRO_TMP" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI NVARCHAR(30),STT INT, TEN_CONG_VIEC NVARCHAR(255), SO_GIO_KH FLOAT,NGAY_HOAN_THANH DATETIME)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI NVARCHAR(30),MS_CV int,MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255),MS_PT_NCC NVARCHAR(255),MS_PT_CTY NVARCHAR(255),SL_KH FLOAT,SL_TT FLOAT,NGAY_HOAN_THANH DATETIME,GHI_CHU NVARCHAR(255),MS_PT_CHA NVARCHAR(50),TON_TAI BIT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "drop PROC [dbo].InsertTAM18" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE PROC [dbo].[InsertTAM18" & Commons.Modules.UserName & "] " &
        " @MS_PHIEU_BAO_TRI NVARCHAR(20),@MS_CV INT, @MA_CV NVARCHAR(255),@MS_BO_PHAN NVARCHAR(50),@TEN_BO_PHAN NVARCHAR(255),@SO_GIO_KH FLOAT, " &
        " @HANG_MUC_ID INT ,@TEN_HANG_MUC NVARCHAR(255),@EOR_ID NVARCHAR(30),@TEN_CHUYEN_MON NVARCHAR(200),@TEN_BAC_THO NVARCHAR(200),@GHI_CHU NVARCHAR(255),@TON_TAI BIT " &
        " as insert into PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI,MS_CV,MA_CV,MS_BO_PHAN,TEN_BO_PHAN,SO_GIO_KH,HANG_MUC_ID,TEN_HANG_MUC,EOR_ID,TEN_CHUYEN_MON ,TEN_BAC_THO ,GHI_CHU ,TON_TAI ) " &
        " values(@MS_PHIEU_BAO_TRI ,@MS_CV , @MA_CV ,@MS_BO_PHAN ,@TEN_BO_PHAN ,@SO_GIO_KH ,@HANG_MUC_ID ,@TEN_HANG_MUC ,@EOR_ID,@TEN_CHUYEN_MON ,@TEN_BAC_THO ,@GHI_CHU ,@TON_TAI)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        For i As Integer = 0 To dgrDanhSachCongViecChinh_2.Rows.Count - 1
            Dim tmp As String = ""
            If IsDBNull(dgrDanhSachCongViecChinh_2.Rows(i).Cells("SO_GIO_KH").Value) Then
                tmp = Nothing
            Else
                tmp = dgrDanhSachCongViecChinh_2.Rows(i).Cells("SO_GIO_KH").Value
            End If
            'str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " VALUES(N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value & " ',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_CV").Value & _
            '"',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MA_CV").Value & " ',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_BO_PHAN").Value & _
            '"',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_BO_PHAN").Value & " '," & tmp & _
            '",'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("HANG_MUC_ID").Value & " ',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_HANG_MUC").Value & _
            '"',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("EOR_ID").Value & " ',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_CHUYEN_MON").Value & _
            '"',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_BAC_THO").Value & " ',N'" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("GHI_CHU").Value & "','1')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertTAM18" & Commons.Modules.UserName, dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value, dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_CV").Value,
            dgrDanhSachCongViecChinh_2.Rows(i).Cells("MA_CV").Value, dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_BO_PHAN").Value,
            dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_BO_PHAN").Value, tmp,
            dgrDanhSachCongViecChinh_2.Rows(i).Cells("HANG_MUC_ID").Value, dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_HANG_MUC").Value,
             dgrDanhSachCongViecChinh_2.Rows(i).Cells("EOR_ID").Value, dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_CHUYEN_MON").Value,
            dgrDanhSachCongViecChinh_2.Rows(i).Cells("TEN_BAC_THO").Value, dgrDanhSachCongViecChinh_2.Rows(i).Cells("GHI_CHU").Value, 1)
        Next
        'lay toan bo phieu bao tri cong viec phu tung luu vao bang tam 
        str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV, " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, TEN_PT,MS_PT_NCC,MS_PT_CTY , " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_KH,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_TT,NULL,'', (CASE WHEN CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT IS NULL THEN 'N' ELSE 'Y' END) AS MS_PT_CHA ,(CASE WHEN SL_KH IS NULL THEN '0' ELSE '1' END)  AS TON_TAI" &
            " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN " &
            " IC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = IC_PHU_TUNG.MS_PT LEFT OUTER JOIN " &
            " CAU_TRUC_THIET_BI_PHU_TUNG ON  " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN AND " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT AND " &
            " CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' " &
            " INNER JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
            " PHIEU_BAO_TRI_CONG_VIEC.MS_CV= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL " &
            " WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim tb As New DataTable()
        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PT_CHA='Y'"
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        For i As Integer = 0 To tb.Rows.Count - 1
            'str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " Select DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV, " & _
            '                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " & _
            '                    " CASE WHEN ISNULL(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH,0)<=0 THEN CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ELSE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH END , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG,   " & _
            '                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA " & _
            '                    " FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " & _
            '                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  " & _
            '                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " & _
            '                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "'" & _
            '                    " LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND " & _
            '                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND " & _
            '                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND " & _
            '                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT  AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN='" & tb.Rows(i).Item("MS_BO_PHAN") & "'" & _
            '                    " AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN " & _
            '                    " AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT " & _
            '                    " LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " & _
            '                    "  PHIEU_BAO_TRI_CONG_VIEC.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND " & _
            '                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  AND " & _
            '                    " PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS  NULL " & _
            '                    " WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "'"

            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " SELECT DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV,  CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT,  CASE WHEN ISNULL(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH,0)<=0 THEN CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ELSE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH END , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA  FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON   CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND   CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "' LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT  AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN='" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN  AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT  LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND   PHIEU_BAO_TRI_CONG_VIEC.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  AND  PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS  NULL  WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT='" & tb.Rows(i).Item("MS_PT") & "' " &
                  "UNION " &
                  "SELECT DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV,  CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT,  0 AS SL_KH , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG,    PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA  FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND   CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "' LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT  AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN='" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN  AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT  LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND   PHIEU_BAO_TRI_CONG_VIEC.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  AND  PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS  NULL  WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT='" & tb.Rows(i).Item("MS_PT") & "' AND " &
                        "CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT NOT IN ( " &
                                    "SELECT DISTINCT CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON   CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND   CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "' LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT  AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN='" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN  AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT =PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT  LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND   PHIEU_BAO_TRI_CONG_VIEC.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN =PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN  AND  PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS  NULL  WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT='" & tb.Rows(i).Item("MS_PT") & "') ORDER BY MS_CV,CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT"

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
        str = "INSERT INTO PHIEU_BAO_TRI_CV_PHU_TRO_TMP" & Commons.Modules.UserName & " SELECT * FROM PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub VisibleButtonThem1(ByVal chon As Boolean)
        btnThem_2.Visible = chon
        btnXoa_2.Visible = chon
        btnThoat_2.Visible = chon
        BtnXemtailieu_2.Visible = chon
    End Sub
    Sub VisibleButtonXoa(ByVal chon As Boolean)
        BtnXoaPBT.Visible = chon
        BtnXoaHinh.Visible = chon
        BtnTroVe.Visible = chon
    End Sub
    Sub VisibleButtonGhi1(ByVal chon As Boolean)
        btnChonCongViec_2.Visible = chon
        btnChonVTPT_2.Visible = chon
        btnGhi_2.Visible = chon
        btnKhongGhi_2.Visible = chon
        dgrDanhSachCongViecPhuTro_2.ReadOnly = Not chon
        dgrDanhSachCongViecPhuTro_2.AllowUserToAddRows = chon
    End Sub
    Sub VisibleButtonXoa1(ByVal chon As Boolean)
        btnXoaCongViecChinh_2.Visible = chon
        btnXoaCongViecPhuTro_2.Visible = chon
        btnXoaVatTuPT_2.Visible = chon
        btnXoaViTriPT_2.Visible = chon
        BtnTrove_2.Visible = chon
    End Sub


    Sub GhiPhieuBaoTriCongViec()
        Dim str As String = ""
        str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC set SO_GIO_KH =TMP.SO_GIO_KH ,GHI_CHU=TMP.GHI_CHU " &
            " FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " TMP,PHIEU_BAO_TRI_CONG_VIEC TMP1 " &
            " WHERE(TMP.TON_TAI = 1 And TMP.MS_PHIEU_BAO_TRI = TMP1.MS_PHIEU_BAO_TRI And TMP.MS_CV = TMP1.MS_CV And TMP.MS_BO_PHAN = TMP1.MS_BO_PHAN)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try
            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH,HANG_MUC_ID,EOR_ID,GHI_CHU)" &
                          " SELECT distinct MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH,HANG_MUC_ID,EOR_ID,GHI_CHU " &
                          "  FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " WHERE TON_TAI IS NULL "
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, str)
            objTrans.Commit()
        Catch ex As Exception
            MsgBox(ex.ToString)
            objTrans.Rollback()
            Return
        Finally
            objConnection.Close()
        End Try
        For i As Integer = 0 To dgrDanhSachCongViecChinh_2.Rows.Count - 1
            If dgrDanhSachCongViecChinh_2.Rows(i).Cells("HANG_MUC_ID").Value.ToString <> "" Then
                str = "UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' WHERE KE_HOACH_TONG_CONG_VIEC.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND KE_HOACH_TONG_CONG_VIEC.HANG_MUC_ID=" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("HANG_MUC_ID").Value & " AND KE_HOACH_TONG_CONG_VIEC.MS_CV =" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_BO_PHAN").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Else
                If dgrDanhSachCongViecChinh_2.Rows(i).Cells("EOR_ID").Value.ToString <> "" Then
                    str = "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'  WHERE EOR_ID='" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("EOR_ID").Value & "' AND MS_CV =" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_BO_PHAN").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
            End If

        Next
        'str = "UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI=(SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " WHERE MS_MAY=KE_HOACH_TONG_CONG_VIEC.MS_MAY AND HANG_MUC_ID=KE_HOACH_TONG_CONG_VIEC.HANG_MUC_ID AND MS_CV =KE_HOACH_TONG_CONG_VIEC.MS_CV AND MS_BO_PHAN=KE_HOACH_TONG_CONG_VIEC.MS_BO_PHAN  )"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'str = "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI=(SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " WHERE EOR_ID=EOR_CONG_VIEC.EOR_ID AND MS_CV =EOR_CONG_VIEC.MS_CV AND MS_BO_PHAN=EOR_CONG_VIEC.MS_BO_PHAN  )"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub GhiPhieuBaoTriCongViecPhuTung()
        Dim str As String = ""
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try
            '            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU) " & _
            '                   "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,IC_PHU_TUNG.MS_PT,SL_KH,SL_TT,GHI_CHU  " & _
            '                  "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_CV,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN,IC_PHU_TUNG.MS_PT,SL_KH,SL_TT,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".GHI_CHU " & _
            '               "  FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " INNER JOIN IC_PHU_TUNG ON  " & _
            '               " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT = IC_PHU_TUNG.MS_PT " & _
            '              "INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " ON PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV " & _
            '             " WHERE(SL_KH Is Not Null And MS_LOAI_VT = 1 Or MS_LOAI_VT <> 1)"
            'str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU) " & _
            '      "  SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU " & _
            '       " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE  SL_KH IS NOT NULL "

            ''str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU) " & _
            ''      "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_CV,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN,IC_PHU_TUNG.MS_PT,SL_KH,SL_TT,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".GHI_CHU " & _
            ''      "FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " INNER JOIN IC_PHU_TUNG ON   PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT = IC_PHU_TUNG.MS_PT " & _
            ''      "INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " ON PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV " & _
            ''      "WHERE(SL_KH Is Not Null And MS_LOAI_VT = 1 Or MS_LOAI_VT <> 1)"

            'str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU) " & _
            '         "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,IC_PHU_TUNG.MS_PT,SL_KH,SL_TT,GHI_CHU  " & _
            '       "  FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " INNER JOIN IC_PHU_TUNG ON  " & _
            '        " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT = IC_PHU_TUNG.MS_PT " & _
            '        " WHERE(SL_KH Is Not Null And MS_LOAI_VT = 1 Or MS_LOAI_VT <> 1)"


            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU) " &
                  "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI, " &
                        "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN, IC_PHU_TUNG.MS_PT, " &
                        "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".SL_KH, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".SL_TT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".GHI_CHU " &
                  "FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " INNER JOIN IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " &
                        "PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI " &
                        "AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV = PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_CV AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN " &
                  "WHERE (PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".SL_KH IS NOT NULL) "
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, str)

            'For i As Integer = 0 To dgrDanhSachVatTuPhuTung.RowCount - 1
            '    str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU) " & _
            '          "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI, " & _
            '                "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN, IC_PHU_TUNG.MS_PT, " & _
            '                Val(dgrDanhSachVatTuPhuTung.Rows(i).Cells("SL_KH").Value) & " AS SL_KH, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".SL_TT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".GHI_CHU " & _
            '          "FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " INNER JOIN IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
            '                "PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI " & _
            '                "AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV = PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_CV AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN " & _
            '          "WHERE (PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".SL_KH IS NOT NULL) AND IC_PHU_TUNG.MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(i).Cells("MS_PT").Value.ToString & "'"
            '    SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, str)
            'Next
            objTrans.Commit()
        Catch ex As Exception
            MsgBox(ex.ToString)
            objTrans.Rollback()
            Return
        Finally
            objConnection.Close()
        End Try
    End Sub
    Sub GhiPhieuBaoTriCongViecPhuTungChiTiet()
        Dim str As String = ""
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try
            'str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,THAY_SUA) SELECT DISTINCT A.MS_PHIEU_BAO_TRI,A.MS_CV,A.MS_BO_PHAN,A.MS_PT,A.MS_VI_TRI_PT,A.SL_KH,A.SL_TT,A.THAY_SUA FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " A INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B ON A.MS_PHIEU_BAO_TRI=B.MS_PHIEU_BAO_TRI AND A.MS_CV = B.MS_CV And A.MS_BO_PHAN = B.MS_BO_PHAN And A.MS_PT = B.MS_PT WHERE A.SL_KH IS NOT NULL "
            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,THAY_SUA) " &
                  " SELECT DISTINCT A.MS_PHIEU_BAO_TRI,A.MS_CV,A.MS_BO_PHAN,A.MS_PT,A.MS_VI_TRI_PT,A.SL_KH,A.SL_TT,A.THAY_SUA  " &
                  " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " A , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " B  " &
                  " WHERE(B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI And A.MS_CV = B.MS_CV And A.MS_BO_PHAN = B.MS_BO_PHAN And A.MS_PT = B.MS_PT And A.SL_KH Is Not Null AND A.SL_KH>0) "
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, str)

            'CAP NHAT LAI SL CHO BANG PHU TUNG
            Dim dtReader As SqlDataReader

            str = "SELECT DISTINCT A.MS_PHIEU_BAO_TRI, A.MS_CV, A.MS_BO_PHAN, A.MS_PT, SUM(A.SL_KH) AS TONG_SL " &
                  "FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " A INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI AND A.MS_CV = B.MS_CV AND A.MS_BO_PHAN = B.MS_BO_PHAN And A.MS_PT = B.MS_PT " &
                  "WHERE (A.MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "') AND (A.SL_KH IS NOT NULL) AND (A.SL_KH > 0) " &
                  "GROUP BY A.MS_PHIEU_BAO_TRI, A.MS_CV, A.MS_BO_PHAN, A.MS_PT"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str) '"SELECT DISTINCT A.MS_PHIEU_BAO_TRI,A.MS_CV,A.MS_BO_PHAN,A.MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " A , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " B WHERE( A.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI And A.MS_CV = B.MS_CV And A.MS_BO_PHAN = B.MS_BO_PHAN And A.MS_PT = B.MS_PT And A.SL_KH Is Not Null AND A.SL_KH>0)")
            While dtReader.Read
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH=" & dtReader.Item("TONG_SL") & " WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & dtReader.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "'")
            End While
            dtReader.Close()
            objTrans.Commit()
        Catch ex As Exception
            MsgBox(ex.ToString)
            objTrans.Rollback()
            Return
        Finally
            objConnection.Close()
        End Try

        'Dim str As String = ""
        'Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        'objConnection.Open()
        'Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        'Try
        '    str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,THAY_SUA) " & _
        '          " SELECT DISTINCT A.MS_PHIEU_BAO_TRI,A.MS_CV,A.MS_BO_PHAN,A.MS_PT,A.MS_VI_TRI_PT,A.SL_KH,A.SL_TT,A.THAY_SUA  " & _
        '          " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " A , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " B  " & _
        '          " WHERE(B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI And A.MS_CV = B.MS_CV And A.MS_BO_PHAN = B.MS_BO_PHAN And A.MS_PT = B.MS_PT And A.SL_KH Is Not Null) " & _
        '                    "AND A.SL_KH>0"

        '    SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, str)

        '    str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT) " & _
        '          " SELECT DISTINCT A.MS_PHIEU_BAO_TRI,A.MS_CV,A.MS_BO_PHAN,A.MS_PT,A.SL_KH,A.SL_TT " & _
        '          " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " A " & _
        '          " WHERE SL_KH Is Not Null AND (MS_PT_CHA = 'N' OR MS_PT_CHA = 'YN') AND SL_KH>0"

        '    SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, str)
        '    objTrans.Commit()
        'Catch ex As Exception
        '    'MsgBox(ex.ToString)
        '    objTrans.Rollback()
        '    Return
        'Finally
        '    objConnection.Close()
        'End Try
    End Sub
    Sub GhiPhieuBaoTriCongViecPhuTro()
        Dim str As String = ""
        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
        For i As Integer = 0 To dgrDanhSachCongViecPhuTro_2.Rows.Count - 2
            If IsDBNull(dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("STT").Value) Then
                objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI_CV_PHU_TRO(txtMaSoPBT.Text.Trim, dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("TEN_CONG_VIEC").Value, IIf(IsDBNull(dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("SO_GIO_KH").Value), 0, dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("SO_GIO_KH").Value))
            Else
                objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_CV_PHU_TRO(txtMaSoPBT.Text.Trim, dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("STT").Value, dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("TEN_CONG_VIEC").Value, IIf(IsDBNull(dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("SO_GIO_KH").Value), 0, dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("SO_GIO_KH").Value))
            End If
        Next
    End Sub

    Sub BindData1(ByVal bGhi As Boolean)
        txtHuongDan_2.Text = ""
        txtTieuChuan_2.Text = ""
        txtDuongDan_2.Text = ""
        If bGhi Then
            If dgrDanhSachCongViecChinh_2.RowCount > 0 And Not bChangce Then
                Exit Sub
            End If
        End If
        dgrDanhSachVatTuPhuTung.DataSource = System.DBNull.Value
        dgrViTriPhuTung_2.DataSource = System.DBNull.Value
        'dgrDanhSachCongViecPhuTro_2.DataSource = System.DBNull.Value
        Dim str As String = ""
        Dim dtTable As New DataTable, dtTable_tmp As New DataTable

        str = "SELECT PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC.MS_CV, CONG_VIEC.MO_TA_CV AS MA_CV, " &
                     "PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN, CAU_TRUC_THIET_BI.TEN_BO_PHAN, " &
                     "PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH AS NGAY_TRUOC, PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH, CONG_VIEC.THOI_GIAN_DU_KIEN AS SO_GIO_KH, " &
                     "PHIEU_BAO_TRI_CONG_VIEC.HANG_MUC_ID, KE_HOACH_TONG_THE.TEN_HANG_MUC, PHIEU_BAO_TRI_CONG_VIEC.EOR_ID, " &
                     "CHUYEN_MON.TEN_CHUYEN_MON, BAC_THO.TEN_BAC_THO, PHIEU_BAO_TRI_CONG_VIEC.GHI_CHU " &
              "FROM PHIEU_BAO_TRI_CONG_VIEC INNER JOIN CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_CV = CONG_VIEC.MS_CV LEFT JOIN " &
                     "CHUYEN_MON ON CONG_VIEC.MS_CHUYEN_MON = CHUYEN_MON.MS_CHUYEN_MON LEFT JOIN " &
                     "BAC_THO ON CONG_VIEC.MS_BAC_THO = BAC_THO.MS_BAC_THO INNER JOIN " &
                     "CAU_TRUC_THIET_BI ON PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN AND CAU_TRUC_THIET_BI.MS_MAY=(SELECT MS_MAY FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI='WO-200812002') LEFT OUTER JOIN " &
                     "KE_HOACH_TONG_THE ON PHIEU_BAO_TRI_CONG_VIEC.HANG_MUC_ID = KE_HOACH_TONG_THE.HANG_MUC_ID " &
              "WHERE (PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI ='-1') ORDER BY PHIEU_BAO_TRI_CONG_VIEC.MS_CV, CONG_VIEC.MO_TA_CV, " &
                     "PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN, CAU_TRUC_THIET_BI.TEN_BO_PHAN"
        dtTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)

        If btnGhi_2.Visible And Not btnKhongGhi_2.Focused Then
            str = "select DISTINCT * from PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName
            dtTable_tmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        Else
            dtTable_tmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIECs", txtMaSoPBT.Text).Tables(0)
        End If

        For i As Integer = 0 To dtTable_tmp.Rows.Count - 1
            Dim dr As DataRow
            dr = dtTable.NewRow
            dr.Item("MS_PHIEU_BAO_TRI") = dtTable_tmp.Rows(i).Item("MS_PHIEU_BAO_TRI")
            dr.Item("MS_CV") = dtTable_tmp.Rows(i).Item("MS_CV")
            dr.Item("MA_CV") = dtTable_tmp.Rows(i).Item("MA_CV")
            dr.Item("MS_BO_PHAN") = dtTable_tmp.Rows(i).Item("MS_BO_PHAN")
            dr.Item("TEN_BO_PHAN") = dtTable_tmp.Rows(i).Item("TEN_BO_PHAN")
            dr.Item("NGAY_HOAN_THANH") = dtTable_tmp.Rows(i).Item("NGAY_HOAN_THANH")
            dr.Item("SO_GIO_KH") = dtTable_tmp.Rows(i).Item("SO_GIO_KH")
            dr.Item("HANG_MUC_ID") = dtTable_tmp.Rows(i).Item("HANG_MUC_ID")
            dr.Item("TEN_HANG_MUC") = dtTable_tmp.Rows(i).Item("TEN_HANG_MUC")
            dr.Item("EOR_ID") = dtTable_tmp.Rows(i).Item("EOR_ID")
            dr.Item("TEN_CHUYEN_MON") = dtTable_tmp.Rows(i).Item("TEN_CHUYEN_MON")
            dr.Item("TEN_BAC_THO") = dtTable_tmp.Rows(i).Item("TEN_BAC_THO")
            dr.Item("GHI_CHU") = dtTable_tmp.Rows(i).Item("GHI_CHU")

            Dim dt As New DataTable
            If IsDBNull(dr.Item("NGAY_HOAN_THANH")) Then
                dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH) AS NGAY_HOAN_THANH FROM PHIEU_BAO_TRI INNER JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_MAY=N'" & cboMS_ThietBi.Text & "' AND MS_CV=" & dr.Item("MS_CV") & " AND MS_BO_PHAN='" & dr.Item("MS_BO_PHAN") & "'").Tables(0)
            Else
                dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH) AS NGAY_HOAN_THANH FROM PHIEU_BAO_TRI INNER JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_MAY=N'" & cboMS_ThietBi.Text & "' AND MS_CV=" & dr.Item("MS_CV") & " AND MS_BO_PHAN='" & dr.Item("MS_BO_PHAN") & "' HAVING MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH)>'" & Format(dr.Item("NGAY_HOAN_THANH"), "dd/MMM/yyyy") & "'").Tables(0)
            End If

            Try
                dr.Item("NGAY_TRUOC") = dt.Rows(0).Item("NGAY_HOAN_THANH")
            Catch ex As Exception
                dr.Item("NGAY_TRUOC") = DBNull.Value
            End Try

            dtTable.Rows.Add(dr)
        Next

        'dtTable_tmp.Columns

        dgrDanhSachCongViecChinh_2.DataSource = dtTable

        dgrDanhSachCongViecChinh_2.Columns("MA_CV").DisplayIndex = 4
        dgrDanhSachCongViecChinh_2.Columns("TEN_BO_PHAN").DisplayIndex = 5
        dgrDanhSachCongViecChinh_2.Columns("NGAY_TRUOC").DisplayIndex = 6
        dgrDanhSachCongViecChinh_2.Columns("NGAY_TRUOC").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("MS_PHIEU_BAO_TRI").Visible = False
        dgrDanhSachCongViecChinh_2.Columns("NGAY_HOAN_THANH").Visible = False
        dgrDanhSachCongViecChinh_2.Columns("MS_CV").Visible = False
        dgrDanhSachCongViecChinh_2.Columns("MS_BO_PHAN").Visible = False
        dgrDanhSachCongViecChinh_2.Columns("HANG_MUC_ID").Visible = False
        dgrDanhSachCongViecChinh_2.Columns("EOR_ID").Visible = False
        dgrDanhSachCongViecChinh_2.Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgrDanhSachCongViecChinh_2.Columns("MA_CV").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("TEN_BO_PHAN").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("SO_GIO_KH").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("TEN_HANG_MUC").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("EOR_ID").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("TEN_CHUYEN_MON").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("TEN_BAC_THO").ReadOnly = True
        dgrDanhSachCongViecChinh_2.Columns("GHI_CHU").ReadOnly = True
        Try
            dgrDanhSachCongViecChinh_2.Columns("TON_TAI").Visible = False
        Catch ex As Exception
        End Try
        With dgrDanhSachCongViecChinh_2
            .Columns("MA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MA_CV", Commons.Modules.TypeLanguage)
            .Columns("MA_CV").Width = 200
            .Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
            .Columns("TEN_BO_PHAN").Width = 200
            .Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
            .Columns("TEN_HANG_MUC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_HANG_MUC", Commons.Modules.TypeLanguage)
            .Columns("EOR_ID").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "EOR_ID", Commons.Modules.TypeLanguage)
            .Columns("TEN_CHUYEN_MON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CHUYEN_MON", Commons.Modules.TypeLanguage)
            .Columns("TEN_CHUYEN_MON").Width = 200
            .Columns("TEN_BAC_THO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BAC_THO", Commons.Modules.TypeLanguage)
            .Columns("TEN_BAC_THO").Width = 200
            .Columns("NGAY_TRUOC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_TRUOC", Commons.Modules.TypeLanguage)
            .Columns("TEN_BAC_THO").Width = 150
            .Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
            .Columns("GHI_CHU").Width = 200
        End With
        Try
            Me.dgrDanhSachCongViecChinh_2.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrDanhSachCongViecChinh_2.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Dim rowCountCVPT As Integer
    Dim TBPhuTro As New DataTable()
    Sub BindData11(ByVal bGhi As Boolean)
        If bGhi Then
            If dgrDanhSachCongViecPhuTro_2.RowCount > 0 And Not bChangce Then
                Exit Sub
            End If
        End If
        dgrDanhSachCongViecPhuTro_2.Columns.Clear()
        Dim str As String = ""
        If btnGhi_2.Visible And Not btnKhongGhi_2.Focused() Then
            str = "select TEN_CONG_VIEC,SO_GIO_KH,MS_PHIEU_BAO_TRI,STT,NGAY_HOAN_THANH from PHIEU_BAO_TRI_CV_PHU_TRO_TMP" & Commons.Modules.UserName
            TBPhuTro = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        Else
            TBPhuTro = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CV_PHU_TROs", txtMaSoPBT.Text).Tables(0)
        End If
        dgrDanhSachCongViecPhuTro_2.DataSource = TBPhuTro
        TBPhuTro.Columns("TEN_CONG_VIEC").MaxLength = 150
        dgrDanhSachCongViecPhuTro_2.Columns("MS_PHIEU_BAO_TRI").Visible = False
        dgrDanhSachCongViecPhuTro_2.Columns("STT").Visible = False
        dgrDanhSachCongViecPhuTro_2.Columns("TEN_CONG_VIEC").Width = 330
        dgrDanhSachCongViecPhuTro_2.Columns("SO_GIO_KH").Width = 109
        dgrDanhSachCongViecPhuTro_2.Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgrDanhSachCongViecPhuTro_2.Columns("NGAY_HOAN_THANH").Visible = False
        With dgrDanhSachCongViecPhuTro_2
            .Columns("TEN_CONG_VIEC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CONG_VIEC", Commons.Modules.TypeLanguage)
            .Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
            '.Columns("NGAY_HOAN_THANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_HOAN_THANH", commons.Modules.TypeLanguage)
        End With
        rowCountCVPT = dgrDanhSachCongViecPhuTro_2.Rows.Count - 1
        Try
            Me.dgrDanhSachCongViecPhuTro_2.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrDanhSachCongViecPhuTro_2.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub BindDataCV_PT_CT(ByVal intRow As Integer)
        Dim str As String = ""
        Dim tb As New DataTable
        Dim dtTable As New DataTable, dtTable_tmp As New DataTable

        'CÂU SELECT LẤY VỀ 1 GIÁ TRỊ RỖNG
        str = "SELECT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV, " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT, " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT, " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA,PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH AS NGAY_TRUOC, PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH " &
              "FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN INNER JOIN " &
                      "PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI AND " &
                      "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN " &
              "WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI ='-1'"
        dtTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)

        If btnGhi_2.Visible Then
            str = "SELECT DISTINCT *, NULL AS NGAY_HOAN_THANH FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_CV").Value &
                               "' AND MS_BO_PHAN='" & dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_PT").Value & "'"

            'str = "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".*, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".NGAY_HOAN_THANH " & _
            '      "FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " ON " & _
            '            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI " & _
            '            "AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_CV AND " & _
            '            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN AND " & _
            '            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & ".MS_PT " & _
            '      "WHERE (PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".MS_CV = '" & dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_CV").Value & "') AND (PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".MS_BO_PHAN = '" & dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_BO_PHAN").Value & "') AND " & _
            '            "(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & ".MS_PT = '" & dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_PT").Value & "')"
            dtTable_tmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        Else
            dtTable_tmp = New clsPHIEU_BAO_TRIController().GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIETs(txtMaSoPBT.Text, dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_CV").Value, dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_BO_PHAN").Value, dgrDanhSachVatTuPhuTung.Rows(intRow).Cells("MS_PT").Value)
        End If

        For i As Integer = 0 To dtTable_tmp.Rows.Count - 1
            Dim dr As DataRow
            dr = dtTable.NewRow
            dr.Item("MS_PHIEU_BAO_TRI") = dtTable_tmp.Rows(i).Item("MS_PHIEU_BAO_TRI")
            dr.Item("MS_CV") = dtTable_tmp.Rows(i).Item("MS_CV")
            dr.Item("MS_BO_PHAN") = dtTable_tmp.Rows(i).Item("MS_BO_PHAN")
            dr.Item("MS_PT") = dtTable_tmp.Rows(i).Item("MS_PT")
            dr.Item("STT") = dtTable_tmp.Rows(i).Item("STT")
            dr.Item("MS_VI_TRI_PT") = dtTable_tmp.Rows(i).Item("MS_VI_TRI_PT")
            dr.Item("SL_KH") = dtTable_tmp.Rows(i).Item("SL_KH")
            dr.Item("SL_TT") = dtTable_tmp.Rows(i).Item("SL_TT")
            dr.Item("THAY_SUA") = dtTable_tmp.Rows(i).Item("THAY_SUA")
            dr.Item("NGAY_HOAN_THANH") = dtTable_tmp.Rows(i).Item("NGAY_HOAN_THANH")

            Dim dt As New DataTable
            If IsDBNull(dr.Item("NGAY_HOAN_THANH")) Then
                str = "SELECT MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH) AS NGAY_HOAN_THANH " &
                      "FROM PHIEU_BAO_TRI_CONG_VIEC INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON " &
                            "PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN INNER JOIN " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN INNER JOIN " &
                            "PHIEU_BAO_TRI ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
                      "WHERE PHIEU_BAO_TRI.MS_MAY=N'" & cboMS_ThietBi.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN='" & dr.Item("MS_BO_PHAN") & "' AND PHIEU_BAO_TRI_CONG_VIEC.MS_CV=" & dr.Item("MS_CV") &
                            " AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT='" & dr.Item("MS_PT") & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT='" & dr.Item("MS_VI_TRI_PT") & "'"

                dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            Else
                str = "SELECT MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH) AS NGAY_HOAN_THANH " &
                      "FROM PHIEU_BAO_TRI_CONG_VIEC INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON " &
                            "PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN INNER JOIN " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                            "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN INNER JOIN " &
                            "PHIEU_BAO_TRI ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
                      "WHERE PHIEU_BAO_TRI.MS_MAY=N'" & cboMS_ThietBi.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN='" & dr.Item("MS_BO_PHAN") & "' AND PHIEU_BAO_TRI_CONG_VIEC.MS_CV=" & dr.Item("MS_CV") &
                            " AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT='" & dr.Item("MS_PT") & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT='" & dr.Item("MS_VI_TRI_PT") & "'" &
                      "HAVING MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH)  > '" & Format(dr.Item("NGAY_HOAN_THANH"), "dd/MMM/yyyy") & "'"

                dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            End If

            Try
                dr.Item("NGAY_TRUOC") = dt.Rows(0).Item("NGAY_HOAN_THANH")
            Catch ex As Exception
                dr.Item("NGAY_TRUOC") = DBNull.Value
            End Try

            dtTable.Rows.Add(dr)
        Next

        dgrDanhSachCongViecChinh_2.Columns("MA_CV").DisplayIndex = 4
        dgrDanhSachCongViecChinh_2.Columns("TEN_BO_PHAN").DisplayIndex = 5
        dgrDanhSachCongViecChinh_2.Columns("NGAY_TRUOC").DisplayIndex = 6
        dgrViTriPhuTung_2.DataSource = dtTable
        dgrViTriPhuTung_2.Columns("MS_PHIEU_BAO_TRI").Visible = False
        dgrViTriPhuTung_2.Columns("MS_CV").Visible = False
        dgrViTriPhuTung_2.Columns("MS_BO_PHAN").Visible = False
        dgrViTriPhuTung_2.Columns("MS_PT").Visible = False
        dgrViTriPhuTung_2.Columns("THAY_SUA").Visible = False
        dgrViTriPhuTung_2.Columns("NGAY_HOAN_THANH").Visible = False
        dgrViTriPhuTung_2.Columns("STT").Visible = False
        dgrViTriPhuTung_2.Columns("MS_VI_TRI_PT").ReadOnly = True
        dgrViTriPhuTung_2.Columns("NGAY_TRUOC").ReadOnly = True
        dgrViTriPhuTung_2.Columns("SL_TT").ReadOnly = True
        dgrViTriPhuTung_2.Columns("SL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgrViTriPhuTung_2.Columns("SL_TT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Try
            dgrViTriPhuTung_2.Columns("SL_CUM").Visible = False
            dgrViTriPhuTung_2.Columns("SL_CUM").ReadOnly = True
            dgrViTriPhuTung_2.Columns("SL_CUM").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_CUM", Commons.Modules.TypeLanguage)
        Catch ex As Exception

        End Try
        With dgrViTriPhuTung_2
            .Columns("MS_VI_TRI_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
            .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
            .Columns("SL_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TT", Commons.Modules.TypeLanguage)
            .Columns("NGAY_TRUOC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_TRUOC", Commons.Modules.TypeLanguage)
        End With
        Try
            Me.dgrViTriPhuTung_2.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrViTriPhuTung_2.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub BindDataCV_PT(ByVal intRow As Integer)
        Dim str As String = ""
        Dim tb As New DataTable
        If btnGhi_2.Visible And Not btnKhongGhi_2.Focused Then
            Try
                str = "select DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,TEN_PT,SL_KH,SL_TT,GHI_CHU,MS_PT_NCC,MS_PT_CTY,MS_PT_CHA from PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_CV='" & dgrDanhSachCongViecChinh_2.Rows(intRow).Cells("MS_CV").Value & "' and MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.Rows(intRow).Cells("MS_BO_PHAN").Value & "'"
                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            Catch ex As Exception
            End Try
        Else
            tb = New clsPHIEU_BAO_TRIController().GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNGs(txtMaSoPBT.Text, dgrDanhSachCongViecChinh_2.Rows(intRow).Cells("MS_CV").Value, dgrDanhSachCongViecChinh_2.Rows(intRow).Cells("MS_BO_PHAN").Value)
        End If
        dgrViTriPhuTung_2.DataSource = System.DBNull.Value
        dgrDanhSachVatTuPhuTung.DataSource = tb
        dgrDanhSachCongViecChinh_2.Columns("MA_CV").DisplayIndex = 4
        dgrDanhSachCongViecChinh_2.Columns("TEN_BO_PHAN").DisplayIndex = 5
        dgrDanhSachCongViecChinh_2.Columns("NGAY_TRUOC").DisplayIndex = 6
        dgrDanhSachVatTuPhuTung.Columns("MS_PHIEU_BAO_TRI").Visible = False
        dgrDanhSachVatTuPhuTung.Columns("MS_CV").Visible = False
        dgrDanhSachVatTuPhuTung.Columns("MS_BO_PHAN").Visible = False
        dgrDanhSachVatTuPhuTung.Columns("MS_PT").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("TEN_PT").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("MS_PT_NCC").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("MS_PT_CTY").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("SL_KH").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("SL_TT").ReadOnly = True
        dgrDanhSachVatTuPhuTung.Columns("SL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgrDanhSachVatTuPhuTung.Columns("SL_TT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgrDanhSachVatTuPhuTung.Columns("GHI_CHU").ReadOnly = True
        Try
            'dgrDanhSachVatTuPhuTung.Columns("TON_TAI").Visible = False
            dgrDanhSachVatTuPhuTung.Columns("MS_PT_CHA").Visible = False
        Catch ex As Exception

        End Try
        dgrDanhSachVatTuPhuTung.Columns("TEN_PT").Width = 150
        With dgrDanhSachVatTuPhuTung
            .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
            .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
            .Columns("SL_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TT", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_CTY", Commons.Modules.TypeLanguage)
            .Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        End With
        Try
            Me.dgrDanhSachVatTuPhuTung.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrDanhSachVatTuPhuTung.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

        If dgrDanhSachVatTuPhuTung.Rows.Count > 0 Then dgrDanhSachVatTuPhuTung.Rows(0).Selected = True
    End Sub
#End Region
#Region "event tab2"
    Private bHuyNT As Byte = 0
    Private Sub btnThem_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem_2.Click
        txtDuongDan_2.Enabled = True
        LoadCV_VT_PT()
    End Sub

    Private Sub LoadCV_VT_PT()
        If dgrDanhSach_1.Rows.Count = 0 Then
            Exit Sub
        End If
        If cboTinhTrangPBT.SelectedValue = 3 Then
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                Dim str As String = ""
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                cboTinhTrangPBT.SelectedValue = 2
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        bThem = 2
        VisibleButtonXoa1(False)
        VisibleButtonThem1(False)
        VisibleButtonGhi1(True)
        LoadTableTmp()
        BindData1(True)
        If dgrDanhSachVatTuPhuTung.Rows.Count > 0 And intRowPT >= 0 Then
            dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_PT").Selected = True
        ElseIf dgrDanhSachVatTuPhuTung.Rows.Count > 0 Then
            dgrDanhSachVatTuPhuTung.Rows(0).Cells("MS_PT").Selected = True
        End If
        Try
            dgrDanhSachCongViecPhuTro_2.Columns("NGAY_HOAN_THANH").ReadOnly = True
        Catch ex As Exception
        End Try
        dgrDanhSachCongViecChinh_2.Columns("GHI_CHU").ReadOnly = False
        AddHandler dgrDanhSachVatTuPhuTung.CellValidating, AddressOf Me.dgrDanhSachVatTuPhuTung_CellValidating
        AddHandler dgrViTriPhuTung_2.CellValidating, AddressOf Me.dgrViTriPhuTung_2_CellValidating
        AddHandler dgrDanhSachCongViecPhuTro_2.CellValidating, AddressOf Me.dgrDanhSachCongViecPhuTro_2_CellValidating
        AddHandler dgrDanhSachCongViecChinh_2.CellValidating, AddressOf Me.dgrDanhSachCongViecChinh_2_CellValidating
    End Sub

    Private Sub btnGhi_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi_2.Click
        Luu_CV_VT_PT()
        txtDuongDan_2.Enabled = False
    End Sub

    'Private Sub Luu_CV_VT_PT()
    '    'kiem tra sl_kh o danh sach vi tri phu tung  co bang phu tung cha kong
    '    Dim str As String = ""
    '    Dim objRead As SqlDataReader
    '    'str = "SELECT DISTINCT TMP2.MA_CV,TMP2.TEN_BO_PHAN,TMP.TEN_PT, ISNULL(SL_KH,0) - ISNULL((SELECT SUM(ISNULL(TMP1.SL_KH, 0))" & _
    '    '    " FROM  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " TMP1 WHERE TMP.MS_PHIEU_BAO_TRI = TMP1.MS_PHIEU_BAO_TRI AND TMP.MS_CV = TMP1.MS_CV AND " & _
    '    '    " TMP.MS_BO_PHAN = TMP1.MS_BO_PHAN AND TMP.MS_PT = TMP1.MS_PT), 0) AS SL_KH FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " TMP,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " TMP2 " & _
    '    '    " WHERE(TMP.MS_PHIEU_BAO_TRI = TMP2.MS_PHIEU_BAO_TRI And TMP.MS_CV = TMP2.MS_CV And TMP.MS_BO_PHAN = TMP2.MS_BO_PHAN) " & _
    '    '    " and TMP.MS_PT_CHA='Y'"
    '    'objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '    'While objRead.Read
    '    '    If objRead.Item("SL_KH") > 0 Or objRead.Item("SL_KH") < 0 Then
    '    '        'XtraMessageBox.Show("Tổng số lượng kế hoạch chi tiết không trùng với số lượng kế hoạch phụ tùng ờ công việc :" + objRead.Item("MA_CV") + "Bộ phận: " + objRead.Item("TEN_BO_PHAN") + " Phụ tùng : " + objRead.Item("TEN_PT"))
    '    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSL_KHKhongTrung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '        objRead.Close()
    '    '        Exit Sub
    '    '    End If
    '    'End While
    '    'objRead.Close()
    '    'str = "SELECT DISTINCT TMP2.MA_CV,TMP2.TEN_BO_PHAN,TMP.TEN_PT, ISNULL(SL_TT,0) - ISNULL((SELECT SUM(ISNULL(TMP1.SL_TT, 0))" & _
    '    '    " FROM  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " TMP1 WHERE TMP.MS_PHIEU_BAO_TRI = TMP1.MS_PHIEU_BAO_TRI AND TMP.MS_CV = TMP1.MS_CV AND " & _
    '    '    " TMP.MS_BO_PHAN = TMP1.MS_BO_PHAN AND TMP.MS_PT = TMP1.MS_PT), 0) AS SL_TT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " TMP,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " TMP2 " & _
    '    '    " WHERE(TMP.MS_PHIEU_BAO_TRI = TMP2.MS_PHIEU_BAO_TRI And TMP.MS_CV = TMP2.MS_CV And TMP.MS_BO_PHAN = TMP2.MS_BO_PHAN) " & _
    '    '    " and TMP.MS_PT_CHA='Y'"
    '    'objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '    'While objRead.Read
    '    '    If objRead.Item("SL_TT") > 0 Or objRead.Item("SL_TT") < 0 Then
    '    '        'XtraMessageBox.Show("Tổng số lượng kế hoạch chi tiết không trùng với số lượng kế hoạch phụ tùng ờ công việc :" + objRead.Item("MA_CV") + "Bộ phận: " + objRead.Item("TEN_BO_PHAN") + " Phụ tùng : " + objRead.Item("TEN_PT"))
    '    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSL_TTKhongTrung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '        objRead.Close()
    '    '        Exit Sub
    '    '    End If
    '    'End While
    '    'objRead.Close()
    '    For i As Integer = 0 To dgrDanhSachCongViecPhuTro_2.Rows.Count - 2
    '        If IsDBNull(dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("TEN_CONG_VIEC").Value) Then ' Or IsDBNull(dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("SO_GIO_KH").Value) Then
    '            'công việc hay số giờ kế hoạch nhâp không đầy đủ
    '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSL_KHNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '            dgrDanhSachCongViecPhuTro_2.Focus()
    '            Exit Sub
    '        End If
    '    Next
    '    Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
    '    For i As Integer = 0 To dgrDanhSachCongViecChinh_2.Rows.Count - 1
    '        objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI(txtMaSoPBT.Text, dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_CV").Value, dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_BO_PHAN").Value)
    '    Next
    '    GhiPhieuBaoTriCongViec()
    '    GhiPhieuBaoTriCongViecPhuTung()
    '    GhiPhieuBaoTriCongViecPhuTungChiTiet()
    '    GhiPhieuBaoTriCongViecPhuTro()
    '    DropTable()
    '    VisibleButtonXoa1(False)
    '    VisibleButtonThem1(True)
    '    VisibleButtonGhi1(False)
    '    BindData1(False)
    '    BindData11(False)
    '    'dgrKeHoachNhanVien_3.Columns.Clear()
    '    'If radCongViecChinh_3.Checked Then
    '    '    'LoadDsCN_CVChinh(intRowIndexCV)
    '    '    LoadCVChinh3()
    '    'Else
    '    '    LoadCVPhuTro3()
    '    '    ' LoadDsCN_CVPhu(intRowIndexCVP)
    '    'End If
    '    bThem = -1
    '    RemoveHandler dgrDanhSachVatTuPhuTung.CellValidating, AddressOf Me.dgrDanhSachVatTuPhuTung_CellValidating
    '    RemoveHandler dgrViTriPhuTung_2.CellValidating, AddressOf Me.dgrViTriPhuTung_2_CellValidating
    '    RemoveHandler dgrDanhSachCongViecPhuTro_2.CellValidating, AddressOf Me.dgrDanhSachCongViecPhuTro_2_CellValidating
    '    RemoveHandler dgrDanhSachCongViecChinh_2.CellValidating, AddressOf Me.dgrDanhSachCongViecChinh_2_CellValidating
    'End Sub

    Private Sub Luu_CV_VT_PT()
        'kiem tra sl_kh o danh sach vi tri phu tung  co bang phu tung cha kong
        Dim str As String = ""
        Dim objRead As SqlDataReader
        'str = "SELECT DISTINCT TMP2.MA_CV,TMP2.TEN_BO_PHAN,TMP.TEN_PT, ISNULL(SL_KH,0) - ISNULL((SELECT SUM(ISNULL(TMP1.SL_KH, 0))" & _
        '    " FROM  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " TMP1 WHERE TMP.MS_PHIEU_BAO_TRI = TMP1.MS_PHIEU_BAO_TRI AND TMP.MS_CV = TMP1.MS_CV AND " & _
        '    " TMP.MS_BO_PHAN = TMP1.MS_BO_PHAN AND TMP.MS_PT = TMP1.MS_PT), 0) AS SL_KH FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " TMP,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " TMP2 " & _
        '    " WHERE(TMP.MS_PHIEU_BAO_TRI = TMP2.MS_PHIEU_BAO_TRI And TMP.MS_CV = TMP2.MS_CV And TMP.MS_BO_PHAN = TMP2.MS_BO_PHAN) " & _
        '    " and TMP.MS_PT_CHA='Y'"
        'objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'While objRead.Read
        '    If objRead.Item("SL_KH") > 0 Or objRead.Item("SL_KH") < 0 Then
        '        'XtraMessageBox.Show("Tổng số lượng kế hoạch chi tiết không trùng với số lượng kế hoạch phụ tùng ờ công việc :" + objRead.Item("MA_CV") + "Bộ phận: " + objRead.Item("TEN_BO_PHAN") + " Phụ tùng : " + objRead.Item("TEN_PT"))
        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSL_KHKhongTrung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        '        objRead.Close()
        '        Exit Sub
        '    End If
        'End While
        'objRead.Close()
        'Dim dtReader As SqlDataReader

        'For i As Integer = 0 To dgrDanhSachVatTuPhuTung.RowCount - 1
        '    str = "SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SUM(SL_KH) AS SL_KH,SUM(SL_TT) AS SL_TT,SUM(SL_CUM) AS SL_CUM " & _
        '          "FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " " & _
        '          "WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(i).Cells("MS_PT").Value & "' GROUP BY MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT"
        '    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)

        '    While dtReader.Read
        '        If dgrDanhSachVatTuPhuTung.Rows(i).Cells("SL_KH").Value <> dtReader.Item("SL_KH") Then
        '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSL_TTKhongTrung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        '            dtReader.Close()
        '            Exit Sub
        '        End If
        '    End While
        '    dtReader.Close()
        'Next
        Dim iTong As Integer = 0

        Dim _MS_PT_CHA As String = "", bVatTu As Boolean = False
        Dim dtReaderVT As SqlDataReader

        Try
            Commons.Modules.SQLString = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND MS_BO_PHAN ='" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value & "'"
            objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            objRead.Read()
            _MS_PT_CHA = objRead.Item("MS_PT")
        Catch
        End Try

        For i As Integer = 0 To dgrDanhSachVatTuPhuTung.RowCount - 1
            If UCase(dgrDanhSachVatTuPhuTung.Rows(i).Cells("MS_PT").Value.ToString).ToString <> UCase(_MS_PT_CHA).ToString Then
                iTong = 0
                For j As Integer = 0 To dgrViTriPhuTung_2.RowCount - 1
                    If Not IsDBNull(dgrViTriPhuTung_2.Rows(j).Cells("SL_KH").Value) Then
                        If Val(dgrViTriPhuTung_2.Rows(j).Cells("SL_KH").Value) > 0 Then iTong += dgrViTriPhuTung_2.Rows(j).Cells("SL_KH").Value
                    End If
                Next

                dtReaderVT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM IC_PHU_TUNG INNER JOIN LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT WHERE (IC_PHU_TUNG.MS_PT = '" & dgrDanhSachVatTuPhuTung.Rows(i).Cells("MS_PT").Value & "') AND (dbo.LOAI_VT.VAT_TU = 0)")
                bVatTu = False
                While dtReaderVT.Read
                    If dtReaderVT.Item(0) = 0 Then
                        bVatTu = False
                    End If
                End While
                dtReaderVT.Close()

                If bVatTu = True And dgrDanhSachVatTuPhuTung.Rows(i).Cells("SL_KH").Value <> iTong Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSL_TTKhongTrung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            End If
        Next
        'str = "SELECT DISTINCT TMP2.MA_CV,TMP2.TEN_BO_PHAN,TMP.TEN_PT, ISNULL(SL_TT,0) - ISNULL((SELECT SUM(ISNULL(TMP1.SL_TT, 0))" & _
        '    " FROM  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " TMP1 WHERE TMP.MS_PHIEU_BAO_TRI = TMP1.MS_PHIEU_BAO_TRI AND TMP.MS_CV = TMP1.MS_CV AND " & _
        '    " TMP.MS_BO_PHAN = TMP1.MS_BO_PHAN AND TMP.MS_PT = TMP1.MS_PT), 0) AS SL_TT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " TMP,PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " TMP2 " & _
        '    " WHERE(TMP.MS_PHIEU_BAO_TRI = TMP2.MS_PHIEU_BAO_TRI And TMP.MS_CV = TMP2.MS_CV And TMP.MS_BO_PHAN = TMP2.MS_BO_PHAN) " & _
        '    " and TMP.MS_PT_CHA='Y'"
        'objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'While objRead.Read
        '    If objRead.Item("SL_TT") > 0 Or objRead.Item("SL_TT") < 0 Then
        '        'XtraMessageBox.Show("Tổng số lượng kế hoạch chi tiết không trùng với số lượng kế hoạch phụ tùng ờ công việc :" + objRead.Item("MA_CV") + "Bộ phận: " + objRead.Item("TEN_BO_PHAN") + " Phụ tùng : " + objRead.Item("TEN_PT"))
        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSL_TTKhongTrung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        '        objRead.Close()
        '        Exit Sub
        '    End If
        'End While
        'objRead.Close()
        For i As Integer = 0 To dgrDanhSachCongViecPhuTro_2.Rows.Count - 2
            If IsDBNull(dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("TEN_CONG_VIEC").Value) Then ' Or IsDBNull(dgrDanhSachCongViecPhuTro_2.Rows(i).Cells("SO_GIO_KH").Value) Then
                'công việc hay số giờ kế hoạch nhâp không đầy đủ
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSL_KHNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                dgrDanhSachCongViecPhuTro_2.Focus()
                Exit Sub
            End If
        Next
        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
        For i As Integer = 0 To dgrDanhSachCongViecChinh_2.Rows.Count - 1
            objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI(txtMaSoPBT.Text, dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_CV").Value, dgrDanhSachCongViecChinh_2.Rows(i).Cells("MS_BO_PHAN").Value)
        Next
        GhiPhieuBaoTriCongViec()
        GhiPhieuBaoTriCongViecPhuTung()
        GhiPhieuBaoTriCongViecPhuTungChiTiet()
        GhiPhieuBaoTriCongViecPhuTro()
        DropTable()
        VisibleButtonXoa1(False)
        VisibleButtonThem1(True)
        VisibleButtonGhi1(False)
        BindData1(False)
        BindData11(False)

        'dgrKeHoachNhanVien_3.Columns.Clear()
        'If radCongViecChinh_3.Checked Then
        '    'LoadDsCN_CVChinh(intRowIndexCV)
        '    LoadCVChinh3()
        'Else
        '    LoadCVPhuTro3()
        '    ' LoadDsCN_CVPhu(intRowIndexCVP)
        'End If
        bThem = -1
        RemoveHandler dgrDanhSachVatTuPhuTung.CellValidating, AddressOf Me.dgrDanhSachVatTuPhuTung_CellValidating
        RemoveHandler dgrViTriPhuTung_2.CellValidating, AddressOf Me.dgrViTriPhuTung_2_CellValidating
        RemoveHandler dgrDanhSachCongViecPhuTro_2.CellValidating, AddressOf Me.dgrDanhSachCongViecPhuTro_2_CellValidating
        RemoveHandler dgrDanhSachCongViecChinh_2.CellValidating, AddressOf Me.dgrDanhSachCongViecChinh_2_CellValidating
    End Sub

    Private Sub btnChonCongViec_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChonCongViec_2.Click

        Dim str As String = ""
        Dim frm As New frmChonCongViecChoPBT
        frm.MS_MAY = cboMS_ThietBi.SelectedValue
        frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
        frm.ShowDialog()
        Dim tb As New DataTable
        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PT_CHA='Y'" ',MS_PT,SL_KH
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        For i As Integer = 0 To tb.Rows.Count - 1
            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " Select DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV, " &
                                " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                                " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG,   " &
                                " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA " &
                                " FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                                " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  " &
                                " CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                                " CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "'" &
                                " WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
        BindData1(False)
        BindData11(False)
    End Sub

    Private Sub btnChonVTPT_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChonVTPT_2.Click
        If dgrDanhSachCongViecChinh_2.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim frm As New frmChonPhuTungcho_PBT()
        frm.MS_MAY = cboMS_ThietBi.SelectedValue
        frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
        frm.ShowDialog()
        Dim str As String = ""
        Dim tb As New DataTable
        '        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PT_CHA='Y'"
        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_PT_CHA FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PT_CHA LIKE '%Y%'"
        tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

        'str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName ' & " WHERE TON_TAI IS NULL"
        'SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim dtReader As SqlDataReader, bPT_CHA As Boolean = False
        Dim dtTam As SqlDataReader, strTam As String = ""

        For i As Integer = 0 To tb.Rows.Count - 1
            strTam = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " WHERE MS_PT IN (SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND MS_BO_PHAN ='" & tb.Rows(i).Item("MS_BO_PHAN") & "')"
            dtTam = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strTam)
            If dtTam.Read = True Then
                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,SL_CUM) " &
                    "VALUES(N'" & txtMaSoPBT.Text & "'," & dtTam.Item("MS_CV") & ",'" & dtTam.Item("MS_BO_PHAN") & "','" & tb.Rows(i).Item("MS_PT") & "'," &
                    "NULL," & dtTam.Item("SL_KH") & "," & IIf(IsDBNull(dtTam.Item("SL_TT")), "NULL", dtTam.Item("SL_TT")) & "," & IIf(IsDBNull(dtTam.Item("SL_KH")), "NULL", dtTam.Item("SL_KH")) & ")"
            Else
                'If tb.Rows(i).Item("MS_PT_CHA").ToString = "Y" Then
                '    str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,SL_CUM) " & _
                '        "VALUES(N'" & txtMaSoPBT.Text & "'," & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_CV").Value & ",'" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value & "','" & tb.Rows(i).Item("MS_PT") & "'," & _
                '        "NULL," & dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("SL_KH").Value & "," & IIf(IsDBNull(dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("SL_TT").Value), "NULL", dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("SL_TT").Value) & "," & IIf(IsDBNull(dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("SL_TT").Value), "NULL", dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("SL_TT").Value) & ")"
                'Else
                str = "SELECT COUNT(*) FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & tb.Rows(i).Item("MS_CV") & " AND MS_BO_PHAN='" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_PT='" & tb.Rows(i).Item("MS_PT") & "'"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)

                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " Select DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV, " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                                    " CASE WHEN ISNULL(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH,0)<=0 THEN CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ELSE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH END AS SL_KH, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ,  " &
                                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA " &
                                    " FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "'"

                While dtReader.Read
                    If dtReader.Item(0) > 0 Then
                        str += " WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT='" & tb.Rows(i).Item("MS_PT") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND STT IS NOT NULL"
                    Else
                        str += " WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT='" & tb.Rows(i).Item("MS_PT") & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND STT IS NULL"
                    End If
                End While
                dtReader.Close()
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next

        BindData1(False)
    End Sub
    Private Sub btnKhongGhi_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi_2.Click
        RemoveHandler dgrDanhSachVatTuPhuTung.CellValidating, AddressOf Me.dgrDanhSachVatTuPhuTung_CellValidating
        RemoveHandler dgrViTriPhuTung_2.CellValidating, AddressOf Me.dgrViTriPhuTung_2_CellValidating
        RemoveHandler dgrDanhSachCongViecPhuTro_2.CellValidating, AddressOf Me.dgrDanhSachCongViecPhuTro_2_CellValidating
        RemoveHandler dgrDanhSachCongViecChinh_2.CellValidating, AddressOf Me.dgrDanhSachCongViecChinh_2_CellValidating
        DropTable()
        VisibleButtonXoa1(False)
        VisibleButtonThem1(True)
        VisibleButtonGhi1(False)
        BindData1(False)
        BindData11(False)
        bThem = -1
        txtDuongDan_2.Enabled = False
    End Sub

    Private Sub btnXoa_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa_2.Click
        Dim str As String = ""
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If

        intTabChanged = 1
        VisibleButtonXoa1(True)
        VisibleButtonThem1(False)
        VisibleButtonGhi1(False)
    End Sub

    Private Sub btnXoaCongViecChinh_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaCongViecChinh_2.Click
        If dgrDanhSachCongViecChinh_2.Rows.Count = 0 Then
            'XtraMessageBox.Show("KHÔNG CÓ DỮ LIỆU ĐỂ XÓA")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
            If Not objPHIEU_BAO_TRIController.CheckPHIEU_BAO_TRI_CONG_VIEC(txtMaSoPBT.Text, dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_CV").Value, dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value) Then
                'XtraMessageBox.Show("CÔNG VIỆC NÀY ĐÃ ĐƯỢC SỬ DỤNG Ở TABLE KHÁC")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCongViecDaSD", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            Else
                Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaCongViec", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC(txtMaSoPBT.Text, dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_CV").Value, dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value)
                    If dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("HANG_MUC_ID").Value.ToString <> "" Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKE_HOACH_TONG_CONG_VIEC", cboMS_ThietBi.SelectedValue, dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("HANG_MUC_ID").Value, dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_CV").Value, dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value, txtMaSoPBT.Text)
                    Else
                        If dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("EOR_ID").Value.ToString <> "" Then
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI =NULL WHERE EOR_ID='" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("EOR_ID").Value & "' AND MS_CV=" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value & "' AND MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'")
                        End If
                    End If
                    BindData1(False)
                    'LoadCVChinh3()
                End If
            End If
        End If
    End Sub

    Private Sub btnXoaCongViecPhuTro_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaCongViecPhuTro_2.Click
        If dgrDanhSachCongViecPhuTro_2.Rows.Count = 0 Then
            'XtraMessageBox.Show("Không tồn tại dữ liệu để xóa")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Dim str As String = ""
            str = "select DISTINCT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' and STT='" & dgrDanhSachCongViecPhuTro_2.Rows(intRowCVP).Cells("STT").Value & "'"
            Dim objRead As SqlDataReader
            objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objRead.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTonTaiCVP", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                objRead.Close()
                Exit Sub
                objRead.Close()
            End While
            objRead.Close()
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaCongViecPhuTro", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CV_PHU_TRO(txtMaSoPBT.Text, dgrDanhSachCongViecPhuTro_2.Rows(intRowCVP).Cells("STT").Value)
                BindData11(False)
            End If
        End If
    End Sub

    Private Sub btnXoaVatTuPT_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaVatTuPT_2.Click
        If dgrDanhSachVatTuPhuTung.Rows.Count = 0 Then
            'XtraMessageBox.Show(" không tồn tại dữ liệu để xóa")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Dim Traloi As String
            If dgrDanhSachVatTuPhuTung.RowCount > 1 Then
                Traloi = MsgBox("Chọn YES nếu bạn muốn xóa tất cả phụ tùng của công việc này, chọn NO nếu bạn muốn xóa phụ tùng đang chọn, chọn CANCEL nếu bạn muốn quay lại màn hình chính !", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Thông báo")
                If Traloi = vbYes Then
                    Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_BO_PHAN").Value & "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_BO_PHAN").Value & "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                ElseIf Traloi = vbNo Then
                    Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(txtMaSoPBT.Text, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_CV").Value, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_BO_PHAN").Value, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_PT").Value)
                Else
                    Exit Sub
                End If
            Else
                Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaVatTuPhuTung", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(txtMaSoPBT.Text, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_CV").Value, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_BO_PHAN").Value, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_PT").Value)
                End If
            End If
            BindDataCV_PT(intRowCV)
            'Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoaVatTuPhuTung", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)

            'If Traloi = vbYes Then
            '    Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
            '    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(txtMaSoPBT.Text, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_CV").Value, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_BO_PHAN").Value, dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("MS_PT").Value)
            '    BindDataCV_PT(intRowCV)
            'End If
        End If
    End Sub

    Private Sub btnXoaViTriPT_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaViTriPT_2.Click
        If dgrViTriPhuTung_2.Rows.Count = 0 Then
            'XtraMessageBox.Show(" không tồn tại dữ liệu để xóa")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaViTriPT", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                Dim iCurrent As Integer = -1
                iCurrent = dgrDanhSachVatTuPhuTung.Rows(intRowPT).Index
                objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(txtMaSoPBT.Text, dgrViTriPhuTung_2.Rows(intRowPT_VT).Cells("MS_CV").Value, dgrViTriPhuTung_2.Rows(intRowPT_VT).Cells("MS_BO_PHAN").Value, dgrViTriPhuTung_2.Rows(intRowPT_VT).Cells("MS_PT").Value, dgrViTriPhuTung_2.Rows(intRowPT_VT).Cells("STT").Value)
                'BindDataCV_PT_CT(intRowPT)
                BindDataCV_PT(intRowCV)
                If dgrDanhSachVatTuPhuTung.RowCount > 0 And dgrDanhSachVatTuPhuTung.RowCount - 1 < iCurrent Then
                    dgrDanhSachVatTuPhuTung.Rows(dgrDanhSachVatTuPhuTung.RowCount - 1).Selected = True
                Else
                    If dgrDanhSachVatTuPhuTung.RowCount > 0 And iCurrent >= 0 Then dgrDanhSachVatTuPhuTung.Rows(iCurrent).Cells("MS_PT").Selected = True '  dgrDanhSachVatTuPhuTung.Rows(iCurrent).Selected = True ' .Rows(iCurrent).Selected = True
                End If
                dgrDanhSachVatTuPhuTung.Focus()
            End If
        End If
    End Sub

    Private Sub btnThoat_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat_2.Click
        Try
            bThoat = True
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnChonCongViec_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonCongViec_5.Click
        If dgrNoiDungTrongHopDong_4.Rows.Count = 0 Then Exit Sub

        Dim frm As New frmChonCongViecChoPBT_ThueNgoai
        frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
        frm.MS_MAY = cboMS_ThietBi.SelectedValue
        frm.STT_EOR = dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value
        frm.CONG_VIEC_DV_THUE_NGOAI = True
        frm.ShowDialog()

        BindData12(False)
    End Sub

    Private Sub btnThoat_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub dgrDanhSachCongViecChinh_2_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles dgrDanhSachCongViecChinh_2.CellValidating
        If btnGhi_2.Visible Then
            If dgrDanhSachCongViecChinh_2.Columns(e.ColumnIndex).Name = "GHI_CHU" Then
                Dim str As String = ""
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_TMP" & Commons.Modules.UserName & " SET GHI_CHU='" & e.FormattedValue & "' WHERE MS_CV=" & dgrDanhSachCongViecChinh_2.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" &
                dgrDanhSachCongViecChinh_2.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub dgrDanhSachCongViecChinh_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrDanhSachCongViecChinh_2.Click
        If btnGhi_2.Visible Then
            dgrDanhSachCongViecChinh_2.Columns("GHI_CHU").ReadOnly = False
        End If
    End Sub
    Private Sub dgrDanhSachCongViecChinh_2_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhSachCongViecChinh_2.RowEnter
        intRowCV = e.RowIndex
        BindDataCV_PT(e.RowIndex)
        Dim tb As New DataTable
        tb = New clsPHIEU_BAO_TRIController().GetCONG_VIEC_PHIEU_BAO_TRIs(dgrDanhSachCongViecChinh_2.Rows(e.RowIndex).Cells("MS_CV").Value)
        'txtHuongDan_2.Text = tb.Rows(0).Item("THAO_TAC")
        'txtTieuChuan_2.Text = tb.Rows(0).Item("TIEU_CHUAN_KT")
        'txtDuongDan_2.Text = tb.Rows(0).Item("PATH_HD")

        txtHuongDan_2.Text = IIf(IsDBNull(tb.Rows(0).Item("THAO_TAC")), Nothing, tb.Rows(0).Item("THAO_TAC"))
        txtTieuChuan_2.Text = IIf(IsDBNull(tb.Rows(0).Item("TIEU_CHUAN_KT")), Nothing, tb.Rows(0).Item("TIEU_CHUAN_KT"))
        txtDuongDan_2.Text = IIf(IsDBNull(tb.Rows(0).Item("PATH_HD")), Nothing, tb.Rows(0).Item("PATH_HD"))
    End Sub
    Private Sub dgrDanhSachVatTuPhuTung_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles dgrDanhSachVatTuPhuTung.CellValidating
        If btnKhongGhi_2.Focused Then
            Exit Sub
        End If
        If btnGhi_2.Visible Then
            Try
                Dim str As String = ""
                Dim tam As String = ""
                If dgrDanhSachVatTuPhuTung.Columns(e.ColumnIndex).Name = "SL_KH" Then
                    If e.FormattedValue <> "" Then
                        If Not IsNumeric(e.FormattedValue) Then
                            'XtraMessageBox.Show("KHONG PHAI SO")
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                            dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).ErrorText = "Error"
                            e.Cancel = True
                            Exit Sub
                        ElseIf e.FormattedValue <= 0 Or e.FormattedValue = "0-" Or e.FormattedValue = "-0" Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                            dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).ErrorText = "Error"
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                    If e.FormattedValue = "" Then
                        tam = "null"
                    Else
                        tam = e.FormattedValue
                        If dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT_CHA").Value = "Y" Then
                            str = "SELECT ISNULL(" & e.FormattedValue & ",0)-(SELECT SUM(ISNULL(TMP1.SL_CUM,0))FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " TMP1 " &
                                " WHERE TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI And TMP1.MS_CV = TMP.MS_CV And TMP1.MS_BO_PHAN = TMP.MS_BO_PHAN " &
                                " AND TMP1.MS_PT=TMP.MS_PT ) AS SL_KH,(SELECT SUM(ISNULL(TMP1.SL_CUM,0))FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " TMP1  " &
                                " WHERE TMP1.MS_PHIEU_BAO_TRI = tmp.MS_PHIEU_BAO_TRI And TMP1.MS_CV = tmp.MS_CV And TMP1.MS_BO_PHAN = tmp.MS_BO_PHAN " &
                                " AND TMP1.MS_PT=TMP.MS_PT )as SL_CUM " &
                                " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " TMP " &
                                " WHERE TMP.MS_PT_CHA='Y' and TMP.MS_CV='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_CV").Value & "' and MS_BO_PHAN='" &
                                dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                        ElseIf dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT_CHA").Value = "N" Then
                            str = "SELECT " & e.FormattedValue & " - SO_LUONG AS SL_KH FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value &
                            "'AND MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "'"
                        End If
                        If str <> "" Then
                            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            While objReader.Read
                                If objReader.Item("SL_KH") > 0 Then
                                    'XtraMessageBox.Show("Số lượng kế hoạch không được lớn tổng số lượng cụm : ")
                                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoLuongKhongTrung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                                    dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).ErrorText = "Error"
                                    objReader.Close()
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End While
                            objReader.Close()
                        End If
                    End If
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " SET SL_KH=" & tam & " WHERE MS_CV='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_CV").Value &
                            "' AND MS_BO_PHAN='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                ElseIf dgrDanhSachVatTuPhuTung.Columns(e.ColumnIndex).Name = "SL_TT" Then
                    If e.FormattedValue <> "" Then
                        If Not IsNumeric(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                            dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).ErrorText = "Error"
                            e.Cancel = True
                            Exit Sub
                        Else
                            If e.FormattedValue <= 0 Or e.FormattedValue = "0-" Or e.FormattedValue = "-0" Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                                dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).ErrorText = "Error"
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                    End If
                    If e.FormattedValue = "" Then
                        tam = "null"
                    Else
                        tam = e.FormattedValue
                    End If
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " SET SL_TT=" & tam & " WHERE MS_CV='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_CV").Value &
                    "' AND MS_BO_PHAN='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                ElseIf dgrDanhSachVatTuPhuTung.Columns(e.ColumnIndex).Name = "GHI_CHU" Then
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " SET GHI_CHU='" & e.FormattedValue & "' WHERE MS_CV='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_CV").Value &
                                    "' AND MS_BO_PHAN='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If

            Catch ex As Exception

            End Try
        End If
        dgrDanhSachVatTuPhuTung.Rows(e.RowIndex).ErrorText = ""
    End Sub
    Private Sub dgrDanhSachVatTuPhuTung_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrDanhSachVatTuPhuTung.Click
        If btnGhi_2.Visible Then
            Try
                dgrDanhSachVatTuPhuTung.Columns("SL_KH").ReadOnly = False
                dgrDanhSachVatTuPhuTung.Columns("SL_TT").ReadOnly = True
                dgrDanhSachVatTuPhuTung.Columns("GHI_CHU").ReadOnly = False
            Catch
            End Try
        End If
    End Sub
    Private Sub dgrDanhSachVatTuPhuTung_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhSachVatTuPhuTung.RowEnter
        intRowPT = e.RowIndex
        BindDataCV_PT_CT(e.RowIndex)
    End Sub

    Private Sub dgrViTriPhuTung_2_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles dgrViTriPhuTung_2.CellValidating
        If btnKhongGhi_2.Focused Then
            Exit Sub
        End If
        If btnGhi_2.Visible Then
            Dim str As String = ""
            Dim tam As String = ""
            If dgrViTriPhuTung_2.Columns(e.ColumnIndex).Name = "SL_KH" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        'XtraMessageBox.Show("KHONG PHAI SO")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_2.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue < 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_2.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                If e.FormattedValue = "" Then
                    tam = "null"
                Else
                    tam = e.FormattedValue
                    'If e.FormattedValue > dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("SL_CUM").Value Then
                    '    'XtraMessageBox.Show("Số lượng kế học không được lớn hơn số lượng cụm")
                    '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongKhongTrung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    '    dgrViTriPhuTung_2.Rows(e.RowIndex).ErrorText = "Error"
                    '    e.Cancel = True
                    '    Exit Sub
                    'End If
                End If
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " SET SL_KH=" & tam & " WHERE MS_CV='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_CV").Value &
                    "' AND MS_BO_PHAN='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            ElseIf dgrViTriPhuTung_2.Columns(e.ColumnIndex).Name = "SL_TT" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        'XtraMessageBox.Show("KHONG PHAI SO")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_2.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue <= 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_2.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                If e.FormattedValue = "" Then
                    tam = "null"
                Else
                    tam = e.FormattedValue
                End If
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " SET SL_TT=" & tam & " WHERE MS_CV='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_CV").Value &
                "' AND MS_BO_PHAN='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                'ElseIf dgrViTriPhuTung_2.Columns(e.ColumnIndex).Name = "GHI_CHU" Then
                '    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " SET GHI_CHU=" & e.FormattedValue & " WHERE MS_CV='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_CV").Value & _
                '                    "' AND MS_BO_PHAN='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_2.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'"
                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
        dgrViTriPhuTung_2.Rows(e.RowIndex).ErrorText = ""
    End Sub
    Private Sub BtnTrove_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTrove_2.Click
        VisibleButtonThem1(True)
        VisibleButtonGhi1(False)
        VisibleButtonXoa1(False)
        intTabChanged = -1
    End Sub
    Private Sub BtnXemtailieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemtailieu.Click
        If grdHinh.Rows.Count = 0 Then
            Exit Sub
        Else
            Try
                System.Diagnostics.Process.Start(grdHinh.Rows(intRowHinh).Cells("DUONG_DAN").Value)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra8", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
            End Try
        End If
    End Sub

    Private Sub dgrDanhSachCongViecPhuTro_2_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles dgrDanhSachCongViecPhuTro_2.CellValidating
        If btnKhongGhi_2.Focused Then
            Exit Sub
        End If
        If e.RowIndex < dgrDanhSachCongViecPhuTro_2.Rows.Count - 1 Then
            If dgrDanhSachCongViecPhuTro_2.Columns(e.ColumnIndex).Name = "TEN_CONG_VIEC" Then
                If e.FormattedValue = "" Then
                    'XtraMessageBox.Show("TÊN CÔNG VIỆC KHÔNG ĐƯỢC ĐỂ TRỐNG")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenCongViecNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    dgrDanhSachCongViecPhuTro_2.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If e.FormattedValue.ToString.Length > TBPhuTro.Columns("TEN_CONG_VIEC").MaxLength Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenCongViec", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrDanhSachCongViecPhuTro_2.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            ElseIf dgrDanhSachCongViecPhuTro_2.Columns(e.ColumnIndex).Name = "SO_GIO_KH" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        'XtraMessageBox.Show("số giờ nhập không hợp lệ")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrDanhSachCongViecPhuTro_2.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue <= 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrDanhSachCongViecPhuTro_2.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                    'Else
                    '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSLKHNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    '    dgrDanhSachCongViecPhuTro_2.Rows(e.RowIndex).ErrorText = "Error"
                    '    e.Cancel = True
                    '    Exit Sub
                End If
            End If
        End If
        dgrDanhSachCongViecPhuTro_2.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub dgrViTriPhuTung_2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrViTriPhuTung_2.CellEndEdit
        If dgrViTriPhuTung_2.Columns(e.ColumnIndex).Name = "SL_KH" Then
            Dim iTong As Integer = 0
            For i As Integer = 0 To dgrViTriPhuTung_2.Rows.Count - 1
                If Not IsDBNull(dgrViTriPhuTung_2.Rows(i).Cells("SL_KH").Value) Then
                    If dgrViTriPhuTung_2.Rows(i).Cells("SL_KH").Value > 0 Then iTong += dgrViTriPhuTung_2.Rows(i).Cells("SL_KH").Value
                End If
            Next
            dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("SL_KH").Value = iTong
        End If
    End Sub

    Private Sub dgrViTriPhuTung_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrViTriPhuTung_2.Click
        Try
            dgrViTriPhuTung_2.Columns("SL_KH").ReadOnly = Not btnGhi_2.Visible
            dgrViTriPhuTung_2.Columns("SL_TT").ReadOnly = True ' Not btnGhi_2.Visible
            dgrViTriPhuTung_2.Columns("GHI_CHU").ReadOnly = Not btnGhi_2.Visible
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgrViTriPhuTung_2_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrViTriPhuTung_2.RowEnter
        intRowPT_VT = e.RowIndex
    End Sub


    Private Sub BtnXemtailieu_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemtailieu_2.Click
        If txtDuongDan_2.Text = "" Then
            Exit Sub
        Else
            Try
                System.Diagnostics.Process.Start(txtDuongDan_2.Text)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra8", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
            End Try
        End If
    End Sub
#End Region
#Region "Sub and Function 4"
    Sub initTab4()
        intRowIndexCV = 0
        HideButton_4(True)
        If cboTinhTrangPBT.SelectedValue = 4 Then
            EnableButton_4(False)
        Else
            EnableButton_4(True)
        End If
        LoadDanhsachDVThueNgoai(True)
        LoadDanhSachDV(True)
    End Sub
    Sub HideButton_4(ByVal flg As Boolean)
        btnThemSuaCV_4.Visible = flg
        btnThemSuaDV_4.Visible = flg
        btnThoat_4.Visible = flg
        btnXoa_4.Visible = flg
        btnChonTuROA_5.Visible = False ' Not flg
        btnChonCongViec_5.Visible = Not flg
        BtnPTThayThe.Visible = Not flg
    End Sub
    Sub HideDelete_4(ByVal flg As Boolean)
        btnXoaDichVu_4.Visible = flg
        btnXoaCongViec_4.Visible = flg
        btnXoaPhuTung_4.Visible = flg
        btnKhongXoa4.Visible = flg
    End Sub
    Sub HideSave4(ByVal chon As Boolean)
        btnGhi_4.Visible = chon
        btnKhongGhi_4.Visible = chon

        If bThem = 4 And blnDv Then
            btnChonTuROA_5.Visible = False ' chon
            btnChonCongViec_5.Visible = Not chon
            BtnPTThayThe.Visible = Not chon
        ElseIf bThem = 4 And Not blnDv Then
            btnChonTuROA_5.Visible = False ' Not chon
            btnChonCongViec_5.Visible = chon
            BtnPTThayThe.Visible = chon
        Else
            btnChonTuROA_5.Visible = False
            btnChonCongViec_5.Visible = False
            BtnPTThayThe.Visible = False
        End If
    End Sub
    Sub EnableButton_4(ByVal bln As Boolean)
        btnXoa_4.Enabled = bln
        btnThemSuaCV_4.Enabled = bln
        btnThemSuaDV_4.Enabled = bln
    End Sub

    Private intRowDanhGiaDV As Integer = 0
    Private Sub LoadDanhSachDV(ByVal bGhi As Boolean)
        If (bGhi = True And Not bChangce) Or (dgrNoiDungTrongHopDong_4.Rows.Count = 0) Then Exit Sub
        Dim dt As New DataTable
        Dim str As String = ""

        If bGhi = True Then
            str = "SELECT TMP.* FROM (SELECT PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT,PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR,DANH_GIA_SERVICE.ID,DANH_GIA_SERVICE.NOI_DUNG,PHIEU_BAO_TRI_DANH_GIA_SERVICE.DIEM FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA WHERE PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & " " &
                                    "UNION " &
                                    "SELECT '" & txtMaSoPBT.Text & "' AS MS_PBT," & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & " AS STT_EOR,DANH_GIA_SERVICE.ID,DANH_GIA_SERVICE.NOI_DUNG,0 AS DIEM FROM DANH_GIA_SERVICE " &
                                    "WHERE ID NOT IN (SELECT DANH_GIA_SERVICE.ID FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA WHERE PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & ")) TMP WHERE TMP.ID>0 " & IIf(btnDanhGia_Ghi.Enabled = True, "", "AND TMP.DIEM>0") & " ORDER BY ID"
        Else
            If dgrNoiDungTrongHopDong_4.CurrentRow Is Nothing Then dgrNoiDungTrongHopDong_4.Rows(0).Cells("NOI_DUNG_SERVICE").Selected = True
            '            str = "SELECT PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT,PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR,DANH_GIA_SERVICE.ID,DANH_GIA_SERVICE.NOI_DUNG,PHIEU_BAO_TRI_DANH_GIA_SERVICE.DIEM FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA WHERE PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=0"
            'Else
            str = "SELECT PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT,PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR,DANH_GIA_SERVICE.ID,DANH_GIA_SERVICE.NOI_DUNG,PHIEU_BAO_TRI_DANH_GIA_SERVICE.DIEM FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA WHERE DIEM>0 AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value
            'End If
        End If
        Try
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        Catch ex As Exception
        End Try

        grdDanhGiaDV.DataSource = dt
        intRowDanhGiaDV = dt.Rows.Count - 1
        FormatGridDanhSachDichVu()
        Try
            Me.grdDanhGiaDV.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhGiaDV.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        If grdDanhGiaDV.Rows.Count = 0 Then
            grdDanhGiaDV.DataSource = DBNull.Value
        Else
            grdDanhGiaDV.CurrentCell = grdDanhGiaDV.Rows(0).Cells("DIEM")
            grdDanhGiaDV.Focus()
        End If
        If btnGhi_4.Visible = True Then
            btnDanhGia.Enabled = False
        ElseIf bGhi = False Then
            btnDanhGia.Enabled = True
        End If
    End Sub

    Sub FormatGridDanhSachDichVu()
        Try
            With grdDanhGiaDV
                .Columns("MS_PBT").Visible = False
                .Columns("STT_EOR").Visible = False
                .Columns("ID").Visible = False
                .Columns("NOI_DUNG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_DUNG", Commons.Modules.TypeLanguage)
                .Columns("DIEM").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DIEM", Commons.Modules.TypeLanguage)
                '.Columns("NOI_DUNG").Width = 450
                .Columns("NOI_DUNG").ReadOnly = True
                .Columns("NOI_DUNG").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("DIEM").Width = 50
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private intRowDVTN As Integer = 0
    Sub LoadDanhsachDVThueNgoai(ByVal bGhi As Boolean)
        If bGhi Then
            If Not bChangce Then
                Exit Sub
            End If
        End If
        TBDichVu = New clsPHIEU_BAO_TRI_SERVICEController().GetDanhsachDVThueNgoai(txtMaSoPBT.Text)
        With dgrNoiDungTrongHopDong_4
            .Columns.Clear()
            .DataSource = TBDichVu
        End With
        intRowDVTN = TBDichVu.Rows.Count - 1
        LoadcboTenKHRutGon()
        LoadcboNGOAI_TE()
        FormatGridDichVu()
        Try
            Me.dgrNoiDungTrongHopDong_4.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrNoiDungTrongHopDong_4.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        If dgrNoiDungTrongHopDong_4.Rows.Count = 0 Then
            dgrCongViecDaThucHien_4.DataSource = DBNull.Value
            dgrViTriPhuTung_4.DataSource = DBNull.Value
            dgrViTriPhuTung_41.DataSource = DBNull.Value
            grdDanhGiaDV.DataSource = DBNull.Value
        Else
            dgrNoiDungTrongHopDong_4.Focus()
        End If
    End Sub
    Sub FormatGridDichVu()
        Try
            With dgrNoiDungTrongHopDong_4
                '.Columns("MS_PHIEU_BAO_TRI").Visible = False
                .Columns("STT").Visible = False
                .Columns("MS_KH").Visible = False
                .Columns("NGUOI_GIAO_DICH").Visible = False
                .Columns("NGOAI_TE").Visible = False
                .Columns("EOR_ID").Visible = False
                .Columns("STT_EOR").Visible = False
                .Columns("MnR").Visible = False
                .Columns("TEN_RUT_GON").Visible = False

                .Columns("NOI_DUNG_SERVICE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_DUNG_SERVICE", Commons.Modules.TypeLanguage)
                '.Columns("TEN_RUT_GON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_RUT_GON", commons.Modules.TypeLanguage)
                .Columns("cboTEN_RUT_GON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_RUT_GON", Commons.Modules.TypeLanguage)
                .Columns("SO_LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG", Commons.Modules.TypeLanguage)
                .Columns("DON_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA", Commons.Modules.TypeLanguage)
                .Columns("cboNGOAI_TE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGOAI_TE", Commons.Modules.TypeLanguage)
                .Columns("TY_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA", Commons.Modules.TypeLanguage)
                .Columns("TY_GIA_USD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA_USD", Commons.Modules.TypeLanguage)
                .Columns("NGUOI_GIAO_DICH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAO_DICH", Commons.Modules.TypeLanguage)

                .Columns("SO_LUONG").DefaultCellStyle.Format = "#,###"
                .Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("SO_LUONG").DefaultCellStyle.NullValue = 0
                .Columns("DON_GIA").DefaultCellStyle.Format = "#,###"
                .Columns("DON_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("DON_GIA").DefaultCellStyle.NullValue = 0
                '.Columns("TY_GIA").DefaultCellStyle.Format = "#,###"
                '.Columns("TY_GIA").DefaultCellStyle.NullValue = 0
                '.Columns("TY_GIA_USD").DefaultCellStyle.Format = "#,###.00"
                '.Columns("TY_GIA_USD").DefaultCellStyle.NullValue = "0.00"

                .Columns("NOI_DUNG_SERVICE").Width = 360
                '.Columns("NOI_DUNG_SERVICE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("cboTEN_RUT_GON").Width = 150
                .Columns("SO_LUONG").Width = 90
                .Columns("DON_GIA").Width = 100
                .Columns("NGOAI_TE").Width = 90
                .Columns("THANH_TIEN").Width = 100
                .Columns("TY_GIA").Width = 100
                .Columns("TY_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TY_GIA_USD").Width = 100
                .Columns("TY_GIA_USD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Columns("MnR").Width = 50

                .Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_TIEN", Commons.Modules.TypeLanguage)
                .Columns("THANH_TIEN").DefaultCellStyle.Format = "#,###"
                .Columns("THANH_TIEN").DefaultCellStyle.NullValue = 0
                .Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("THANH_TIEN_USD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_TIEN_USD", Commons.Modules.TypeLanguage)
                .Columns("THANH_TIEN_USD").DefaultCellStyle.Format = "#,###.00"
                .Columns("THANH_TIEN_USD").DefaultCellStyle.NullValue = "0.00"
                .Columns("THANH_TIEN").DefaultCellStyle.BackColor = Color.Silver
                .Columns("THANH_TIEN_USD").DefaultCellStyle.BackColor = Color.Silver
                .Columns("THANH_TIEN_USD").ReadOnly = True
                .Columns("THANH_TIEN_USD").ReadOnly = True
                .Columns("THANH_TIEN_USD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadcboTenKHRutGon()
        Dim cbo As New DataGridViewComboBoxColumn
        Dim dtTable = New DataTable

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_KH,TEN_RUT_GON FROM KHACH_HANG ORDER BY TEN_RUT_GON"))

        cbo.Name = "cboTEN_RUT_GON"
        cbo.DataPropertyName = "MS_KH"
        cbo.DataSource = dtTable
        cbo.ValueMember = "MS_KH"
        cbo.DisplayMember = "TEN_RUT_GON"
        cbo.DropDownWidth = 200
        dgrNoiDungTrongHopDong_4.Columns.Insert(3, cbo)
    End Sub

    Private Sub LoadcboNGOAI_TE()
        Dim cbo As New DataGridViewComboBoxColumn
        Dim dtTable = New DataTable

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE,TEN_NGOAI_TE FROM NGOAI_TE ORDER BY TEN_NGOAI_TE"))

        cbo.Name = "cboNGOAI_TE"
        cbo.DataPropertyName = "NGOAI_TE"
        cbo.DataSource = dtTable
        cbo.ValueMember = "NGOAI_TE"
        cbo.DisplayMember = "TEN_NGOAI_TE"
        cbo.DropDownWidth = 150
        dgrNoiDungTrongHopDong_4.Columns.Insert(4, cbo)
    End Sub

    Sub BindData12(ByVal bGhi As Boolean)
        If bGhi Then
            If dgrCongViecDaThucHien_4.RowCount > 0 And Not bChangce Then
                Exit Sub
            End If
        End If

        dgrCongViecDaThucHien_4.DataSource = System.DBNull.Value
        dgrViTriPhuTung_4.DataSource = System.DBNull.Value
        dgrViTriPhuTung_41.DataSource = System.DBNull.Value

        If dgrNoiDungTrongHopDong_4.RowCount = 0 Then Exit Sub
        Dim str As String = ""

        Try
            If btnGhi_4.Visible And Not btnKhongGhi_4.Focused Then
                str = "SELECT DISTINCT * from PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName
                'str = "SELECT dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".* " & _
                '      "FROM   dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " INNER JOIN " & _
                '             "dbo.PHIEU_BAO_TRI_SERVICE ON " & _
                '             "dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI AND " & _
                '             "dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".STT_EOR = dbo.PHIEU_BAO_TRI_SERVICE.STT_EOR " & _
                '      "WHERE (PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI ='" & txtMaSoPBT.Text & "') AND  PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT_EOR").Value

                'str = "SELECT DISTINCT dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".* " & _
                '      "FROM dbo.PHIEU_BAO_TRI_SERVICE INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " ON " & _
                '           "dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI AND " & _
                '           "dbo.PHIEU_BAO_TRI_SERVICE.STT = dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".STT_EOR " & _
                '      "WHERE dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".STT_EOR = " & IIf(dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value Is Nothing, -1, dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value)
                dgrCongViecDaThucHien_4.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
                'dgrCongViecDaThucHien_4.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIECs_THUENGOAI1", txtMaSoPBT.Text, dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value).Tables(0) ' intRowIndex + 1).Tables(0)

                'dgrCongViecDaThucHien_4.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIECs_THUENGOAI2", txtMaSoPBT.Text, dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT_EOR").Value).Tables(0) ' intRowIndex + 1).Tables(0)
            Else
                dgrCongViecDaThucHien_4.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIECs_THUENGOAI1", txtMaSoPBT.Text, dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value).Tables(0) ' intRowIndex + 1).Tables(0)
            End If

            dgrCongViecDaThucHien_4.Columns("MS_PHIEU_BAO_TRI").Visible = False
            dgrCongViecDaThucHien_4.Columns("GHI_CHU").Visible = False
            dgrCongViecDaThucHien_4.Columns("MS_CV").Visible = False
            dgrCongViecDaThucHien_4.Columns("MS_BO_PHAN").Visible = False
            dgrCongViecDaThucHien_4.Columns("HANG_MUC_ID").Visible = False
            dgrCongViecDaThucHien_4.Columns("TEN_CHUYEN_MON").Visible = False
            dgrCongViecDaThucHien_4.Columns("EOR_ID").Visible = False
            dgrCongViecDaThucHien_4.Columns("SO_GIO_KH").Visible = False
            dgrCongViecDaThucHien_4.Columns("TEN_BAC_THO").Visible = False
            dgrCongViecDaThucHien_4.Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            With dgrCongViecDaThucHien_4
                .Columns("MA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MA_CV", Commons.Modules.TypeLanguage)
                .Columns("MA_CV").Width = 300
                .Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
                .Columns("TEN_BO_PHAN").Width = 200
                .Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
                '.Columns("TEN_HANG_MUC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_HANG_MUC", commons.Modules.TypeLanguage)                
                .Columns("EOR_ID").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "EOR_ID", Commons.Modules.TypeLanguage)
                .Columns("TEN_CHUYEN_MON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CHUYEN_MON", Commons.Modules.TypeLanguage)
                .Columns("TEN_CHUYEN_MON").Width = 200
                .Columns("TEN_BAC_THO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BAC_THO", Commons.Modules.TypeLanguage)
                .Columns("TEN_BAC_THO").Width = 200
            End With

            dgrNoiDungTrongHopDong_4.Columns("TY_GIA_USD").DefaultCellStyle.Format = "N6"
            dgrCongViecDaThucHien_4.Columns("TEN_HANG_MUC").Visible = False
            dgrCongViecDaThucHien_4.Columns("STT_EOR").Visible = False
            dgrCongViecDaThucHien_4.Columns("TON_TAI").Visible = False
        Catch ex As Exception

        End Try
        Try
            Me.dgrCongViecDaThucHien_4.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrCongViecDaThucHien_4.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            dgrCongViecDaThucHien_4.Columns("TEN_BO_PHAN").DisplayIndex = 3
            dgrCongViecDaThucHien_4.Columns("MA_CV").DisplayIndex = 4
        Catch ex As Exception
        End Try

        If dgrCongViecDaThucHien_4.RowCount = 0 Then
            btnThemSuaCV_4.Enabled = False
            btnDanhGia.Enabled = False
            btnXoa_4.Enabled = False
            grdDanhGiaDV.DataSource = Nothing
        Else
            btnThemSuaCV_4.Enabled = True
            btnDanhGia.Enabled = True
            btnXoa_4.Enabled = True
        End If
    End Sub
    Sub CapNhatDLChon()
        Dim blnXNGhi As Boolean
        blnXNGhi = New clsPHIEU_BAO_TRI_SERVICEController().CapNhatDuLieuDVChon(TBDichVu, txtMaSoPBT.Text, intRowDVTN)
    End Sub
    Sub LoadTableTmp4()
        Dim str As String = ""

        '////////////////////
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName &
        " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT, MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(30),STT INT ,MS_VI_TRI_PT NVARCHAR(50),SL_KH FLOAT, SL_TT FLOAT,SL_CUM FLOAT,THAY_SUA BIT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        '////////////////////////

        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName &
        " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT, MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(30),STT INT ,MS_VI_TRI_PT NVARCHAR(50),SL_KH FLOAT, SL_TT FLOAT,SL_CUM FLOAT,THAY_SUA BIT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI NVARCHAR(30),MS_CV INT, MA_CV NVARCHAR(255),MS_BO_PHAN NVARCHAR(50),TEN_BO_PHAN NVARCHAR(255),SO_GIO_KH FLOAT," &
                " HANG_MUC_ID INT ,TEN_HANG_MUC NVARCHAR(255),EOR_ID NVARCHAR(30),STT_EOR INT,TEN_CHUYEN_MON NVARCHAR(200),TEN_BAC_THO NVARCHAR(200),GHI_CHU NVARCHAR(255),TON_TAI BIT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV int,MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(100),MS_VI_TRI_PT NVARCHAR(50),MS_PT_NCC NVARCHAR(255),MS_PT_CTY NVARCHAR(255),SL_KH FLOAT,SL_TT FLOAT,GHI_CHU NVARCHAR(255),MS_PT_CHA NVARCHAR(50),TON_TAI BIT,SL_CUM FLOAT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "DROP TABLE PTB_DANH_GIA_SERVICE" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.PTB_DANH_GIA_SERVICE" & Commons.Modules.UserName & " ([MS_PBT] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[STT_EOR] [int] NOT NULL,[NOI_DUNG] [nvarchar] (50),[MS_DANH_GIA] [int] NOT NULL,[DIEM] [float] NULL) ON [PRIMARY]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "DROP TABLE PHIEU_BAO_TRI_SERVICE_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE [dbo].[PHIEU_BAO_TRI_SERVICE_TMP" & Commons.Modules.UserName & "] ([MS_PHIEU_BAO_TRI] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,[STT] [int] NOT NULL, " &
                         "[NOI_DUNG_SERVICE] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[MS_KH] [nvarchar] (7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[NGUOI_GIAO_DICH] [int] NULL , " &
                         "[SO_LUONG] [int] NULL ,[DON_GIA] [float] NULL ,[NGOAI_TE] [nvarchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[TY_GIA] [float] NULL ,[TY_GIA_USD] [float] NULL ,[EOR_ID] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , " &
                         "[STT_EOR] [int] NULL ,[MnR] [bit] NULL ,[BAO_HANH_DEN] [datetime] NULL ,[DIEM] [int] NULL ,[NOI_DUNG_DANH_GIA] [nvarchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[SO_HOP_DONG] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , " &
                            "[NGAY_HOAN_THANH] [datetime] NULL ,[GHI_CHU] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[TON_TAI] [BIT])"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "DROP PROC [dbo].InsertTAM181" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE PROC [dbo].[InsertTAM181" & Commons.Modules.UserName & "] " &
        " @MS_PHIEU_BAO_TRI NVARCHAR(50),@MS_CV INT, @MA_CV NVARCHAR(255),@MS_BO_PHAN NVARCHAR(50),@TEN_BO_PHAN NVARCHAR(255),@SO_GIO_KH FLOAT, " &
        " @HANG_MUC_ID INT ,@TEN_HANG_MUC NVARCHAR(255),@EOR_ID NVARCHAR(50),@STT_EOR INT,@TEN_CHUYEN_MON NVARCHAR(200),@TEN_BAC_THO NVARCHAR(200),@GHI_CHU NVARCHAR(255),@TON_TAI BIT " &
        " as insert into PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI,MS_CV,MA_CV,MS_BO_PHAN,TEN_BO_PHAN,SO_GIO_KH,HANG_MUC_ID,TEN_HANG_MUC,EOR_ID,STT_EOR,TEN_CHUYEN_MON ,TEN_BAC_THO ,GHI_CHU ,TON_TAI ) " &
        " values(@MS_PHIEU_BAO_TRI ,@MS_CV , @MA_CV ,@MS_BO_PHAN ,@TEN_BO_PHAN ,@SO_GIO_KH ,@HANG_MUC_ID ,@TEN_HANG_MUC ,@EOR_ID,@STT_EOR,@TEN_CHUYEN_MON ,@TEN_BAC_THO ,@GHI_CHU ,@TON_TAI)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        For i As Integer = 0 To dgrCongViecDaThucHien_4.Rows.Count - 1
            Dim tmp As String = ""
            If IsDBNull(dgrCongViecDaThucHien_4.Rows(i).Cells("SO_GIO_KH").Value) Then
                tmp = Nothing
            Else
                tmp = dgrCongViecDaThucHien_4.Rows(i).Cells("SO_GIO_KH").Value
            End If
            Try
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value.ToString())
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("MS_CV").Value.ToString())
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("MS_BO_PHAN").Value.ToString())
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_BO_PHAN").Value.ToString())
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("HANG_MUC_ID").Value.ToString())
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_HANG_MUC").Value.ToString())
                Dim vstt As Integer = -1
                Try
                    vstt = Convert.ToInt32(dgrNoiDungTrongHopDong_4.CurrentRow.Cells("STT").Value)
                Catch ex As Exception

                End Try

                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_CHUYEN_MON").Value.ToString())
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_BAC_THO").Value.ToString())
                'XtraMessageBox.Show(dgrCongViecDaThucHien_4.Rows(i).Cells("GHI_CHU").Value.ToString())

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertTAM181" & Commons.Modules.UserName, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_CV").Value,
                                        dgrCongViecDaThucHien_4.Rows(i).Cells("MA_CV").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_BO_PHAN").Value,
                                        dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_BO_PHAN").Value, tmp, dgrCongViecDaThucHien_4.Rows(i).Cells("HANG_MUC_ID").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_HANG_MUC").Value,
                                        dgrCongViecDaThucHien_4.Rows(i).Cells("EOR_ID").Value, vstt, dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_CHUYEN_MON").Value,
                                        dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_BAC_THO").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("GHI_CHU").Value, 1)
            Catch ex As Exception
            End Try
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertTAM181" & Commons.Modules.UserName, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_CV").Value, _
            'dgrCongViecDaThucHien_4.Rows(i).Cells("MA_CV").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_BO_PHAN").Value, _
            'Nothing, tmp, dgrCongViecDaThucHien_4.Rows(i).Cells("HANG_MUC_ID").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_HANG_MUC").Value, _
            'dgrCongViecDaThucHien_4.Rows(i).Cells("EOR_ID").Value, IIf(intRowIndex < 0, Nothing, intRowIndex + 1), dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_CHUYEN_MON").Value, _
            'dgrCongViecDaThucHien_4.Rows(i).Cells("TEN_BAC_THO").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("GHI_CHU").Value, 1)
        Next
        'lay toan bo phieu bao tri cong viec phu tung thuê ngoài luu vao bang tam 
        str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV, " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, TEN_PT,TMP.MS_VI_TRI_PT,MS_PT_NCC,MS_PT_CTY , " &
            "(SELECT PBTCT.SL_KH FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET PBTCT WHERE " &
            " PBTCT.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND PBTCT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND " &
            " PBTCT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND PBTCT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT AND PBTCT.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV)AS SL_KH " &
            " ,(SELECT PBTCT.SL_TT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET PBTCT WHERE  " &
            " PBTCT.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND PBTCT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND " &
            " PBTCT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND PBTCT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT AND PBTCT.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV)AS SL_TT," &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU, (CASE WHEN CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT IS NULL THEN 'N' ELSE 'Y' END) AS MS_PT_CHA ,CONVERT(BIT,1)" &
            " ,CASE WHEN (SELECT CTTBPT.MS_VI_TRI_PT FROM CAU_TRUC_THIET_BI_PHU_TUNG CTTBPT WHERE CTTBPT.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND CTTBPT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN " &
            " AND CTTBPT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND CTTBPT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT)IS NULL THEN " &
            " (SELECT CTTB.SO_LUONG FROM CAU_TRUC_THIET_BI CTTB WHERE CTTB.MS_MAY= N'" & cboMS_ThietBi.SelectedValue & "' AND CTTB.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND CTTB.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT) ELSE " &
            " (SELECT CTTBPT.SO_LUONG FROM CAU_TRUC_THIET_BI_PHU_TUNG CTTBPT WHERE CTTBPT.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND CTTBPT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN " &
            " AND CTTBPT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND CTTBPT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT ) END AS SL_CUM " &
            " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN " &
            " IC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = IC_PHU_TUNG.MS_PT LEFT OUTER JOIN " &
            " CAU_TRUC_THIET_BI_PHU_TUNG ON  " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN AND " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT AND " &
            " CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' " &
            " INNER JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " &
            " PHIEU_BAO_TRI_CONG_VIEC.MS_CV= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS  NOT NULL " &
            " LEFT OUTER JOIN CAU_TRUC_THIET_BI ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN AND " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI.MS_PT AND CAU_TRUC_THIET_BI.MS_MAY =N'" & cboMS_ThietBi.SelectedValue & "' " &
            " LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET TMP ON TMP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI " &
            " AND TMP.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND TMP.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN " &
            " AND TMP.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT " &
            " LEFT join PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND  " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " &
            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " &
            " WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)


        'LẤY TOÀN BỘ CÁC ĐÁNH GIÁ CỦA TỪNG SERVICE ĐƯA VÀO BẢNG TẠM
        str = "INSERT INTO PTB_DANH_GIA_SERVICE" & Commons.Modules.UserName & " SELECT PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT,PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR,DANH_GIA_SERVICE.NOI_DUNG,DANH_GIA_SERVICE.ID,PHIEU_BAO_TRI_DANH_GIA_SERVICE.DIEM " &
              "FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA " &
              "WHERE PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" & txtMaSoPBT.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub BindData13()
        Dim str As String = ""
        If dgrCongViecDaThucHien_4.Rows.Count = 0 Then Exit Sub
        'dgrViTriPhuTung_41.DataSource = System.DBNull.Value
        If btnGhi_4.Visible Then
            str = "SELECT distinct TMP.MS_PHIEU_BAO_TRI, TMP.MS_CV,TMP.MS_BO_PHAN, TMP.MS_PT, TMP.TEN_PT,TMP.MS_VI_TRI_PT,SL_KH,SL_TT, TON_TAI,MS_PT_CHA, SL_CUM,GHI_CHU,MS_PT_NCC,MS_PT_CTY " &
                " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " TMP  " &
                " WHERE TMP.MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value & "' AND TMP.MS_CV='" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value & "'-- AND TON_TAI <> 0"
            dgrViTriPhuTung_4.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        Else
            dgrViTriPhuTung_4.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAIs", cboMS_ThietBi.SelectedValue, txtMaSoPBT.Text, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value).Tables(0)
        End If

        If dgrViTriPhuTung_4.RowCount = 0 Then dgrViTriPhuTung_41.DataSource = DBNull.Value

        dgrViTriPhuTung_4.Columns("MS_PHIEU_BAO_TRI").Visible = False
        dgrViTriPhuTung_4.Columns("MS_CV").Visible = False
        dgrViTriPhuTung_4.Columns("MS_BO_PHAN").Visible = False
        'dgrViTriPhuTung_4.Columns("MS_PT").Visible = False
        dgrViTriPhuTung_4.Columns("TON_TAI").Visible = False
        dgrViTriPhuTung_4.Columns("MS_PT_CHA").Visible = False
        dgrViTriPhuTung_4.Columns("MS_VI_TRI_PT").Visible = True
        dgrViTriPhuTung_4.Columns("SL_KH").Visible = False
        dgrViTriPhuTung_4.Columns("SL_CUM").Visible = False

        Try
            dgrViTriPhuTung_4.Columns("STT").Visible = False
        Catch ex As Exception

        End Try

        With dgrViTriPhuTung_4
            .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
            .Columns("TEN_PT").Width = 165
            .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
            .Columns("SL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SL_KH").Width = 70
            .Columns("SL_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TT", Commons.Modules.TypeLanguage)
            .Columns("SL_TT").Width = 70
            .Columns("SL_TT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", Commons.Modules.TypeLanguage)
            .Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT_CTY", Commons.Modules.TypeLanguage)
            .Columns("SL_CUM").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_CUM", Commons.Modules.TypeLanguage)
            .Columns("SL_CUM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MS_VI_TRI_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
            .Columns("MS_VI_TRI_PT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("MS_VI_TRI_PT").Width = 100
            .Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        End With
        Try
            Me.dgrViTriPhuTung_4.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrViTriPhuTung_4.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "tab 4"
    Private Sub btnChonTuROA_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonTuROA_5.Click
        Dim frm As New FrmChonDichVuThueNgoaiChoPBT()
        frm.TBDichVu = Me.TBDichVu
        If frm.ShowDialog() Then
            TBDichVu = frm.TBDichVu
            With dgrNoiDungTrongHopDong_4
                .Columns.Clear()
                .DataSource = TBDichVu
            End With
            FormatGridDichVu()
        End If

    End Sub

    Private Sub btnThemSuaDV_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemSuaDV_4.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                Dim str As String = ""
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        blnDv = True
        bThem = 4
        HideButton_4(False)
        HideDelete_4(False)
        HideSave4(True)
        LoadTableTmp4()
        BindData12(True)
        AddHandler dgrDanhSachVatTuPhuTung.CellValidating, AddressOf Me.dgrDanhSachVatTuPhuTung_CellValidating
        AddHandler dgrViTriPhuTung_2.CellValidating, AddressOf Me.dgrViTriPhuTung_2_CellValidating
        AddHandler dgrDanhSachCongViecPhuTro_2.CellValidating, AddressOf Me.dgrDanhSachCongViecPhuTro_2_CellValidating
        AddHandler dgrDanhSachCongViecChinh_2.CellValidating, AddressOf Me.dgrDanhSachCongViecChinh_2_CellValidating
        If dgrNoiDungTrongHopDong_4.Rows.Count > 0 Then LoadDanhSachDV(True)
        dgrNoiDungTrongHopDong_4.AllowUserToAddRows = True
        dgrNoiDungTrongHopDong_4.ReadOnly = False
        dgrNoiDungTrongHopDong_4.Focus()
    End Sub


    Private Sub btnXoa_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa_4.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        Dim str As String = ""
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        HideDelete_4(True)
        HideButton_4(False)
        HideSave4(False)
    End Sub

    Private Sub btnXoaDichVu_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaDichVu_4.Click
        If dgrNoiDungTrongHopDong_4.RowCount < 1 Then
            'MsgBox("Không có dữ liệu để xóa !", MsgBoxStyle.Critical, Me.Text)
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        'If MsgBox("Bạn có chắc muốn xóa danh sách nhân sự này không?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKT10", Commons.Modules.TypeLanguage), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub


        If dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("MnR").Value Then
            Commons.Modules.SQLString = "UPDATE EOR_SERVICE_MNR SET MS_PHIEU_BAO_TRI=NULL " &
                    " WHERE EOR_ID='" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("EOR_ID").Value & "' AND STT=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value

        Else
            Commons.Modules.SQLString = "UPDATE EOR_SERVICE_CHUNG SET MS_PHIEU_BAO_TRI=NULL " &
                                " WHERE EOR_ID='" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("EOR_ID").Value & "' AND STT=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value

        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        '        blnXNXoa = New clsPHIEU_BAO_TRI_SERVICEController().XoaDuLieuDV( _
        'dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("MS_PHIEU_BAO_TRI").Value, _
        'dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value)

        Try
            Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        Try
            Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        Try
            Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value & "' AND STT_SERVICE=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        Try
            Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" & txtMaSoPBT.Text & "' AND STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        Try
            Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND STT=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        'blnXNXoa = New clsPHIEU_BAO_TRI_SERVICEController().XoaDuLieuDV(txtMaSoPBT.Text, dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value.ToString, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value.ToString)

        LoadDanhsachDVThueNgoai(False)
        LoadDanhSachDV(False)
        If dgrNoiDungTrongHopDong_4.Rows.Count > 0 Then dgrNoiDungTrongHopDong_4.Rows(0).Selected = True
        dgrNoiDungTrongHopDong_4.Focus()
    End Sub

    Private Sub btnGhi_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi_4.Click
        Dim objReader As SqlDataReader, objReaderCheck As SqlDataReader
        Dim _NGOAI_TE As String = "VND"
        If dgrNoiDungTrongHopDong_4.Rows.Count > 0 Then
            If blnDv Then
                For i As Integer = 0 To dgrNoiDungTrongHopDong_4.Rows.Count - 2
                    'kiem tra xem co dl chua neu co thi cap nhat nguoc lai thi insert
                    objReaderCheck = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND STT=" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("STT").Value)
                    objReaderCheck.Read()

                    _NGOAI_TE = dgrNoiDungTrongHopDong_4.Rows(i).Cells("NGOAI_TE").Value
                    If objReaderCheck.HasRows Then  'co dl roi -> update
                        Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_SERVICE SET MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "',NOI_DUNG_SERVICE=" &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("NOI_DUNG_SERVICE").Value.ToString = "", "NULL", "N'" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("NOI_DUNG_SERVICE").Value & "'") & ",MS_KH=" &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("MS_KH").Value.ToString = "", "NULL", "'" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("MS_KH").Value & "'") & ",SO_LUONG=" &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("SO_LUONG").Value.ToString = "", 0, dgrNoiDungTrongHopDong_4.Rows(i).Cells("SO_LUONG").Value) & ",DON_GIA=" &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("DON_GIA").Value.ToString = "", 0, dgrNoiDungTrongHopDong_4.Rows(i).Cells("DON_GIA").Value) & ",NGOAI_TE='" & _NGOAI_TE &
                        "',TY_GIA=" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("TY_GIA").Value & ",TY_GIA_USD=" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("TY_GIA_USD").Value & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND STT=" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("STT").Value
                    Else    'chua co dl -> insert
                        Commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_SERVICE(MS_PHIEU_BAO_TRI,NOI_DUNG_SERVICE,MS_KH,SO_LUONG,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD) VALUES(N'" & txtMaSoPBT.Text & "'," &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("NOI_DUNG_SERVICE").Value.ToString = "", "NULL", "N'" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("NOI_DUNG_SERVICE").Value & "'") & "," &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("MS_KH").Value.ToString = "", "NULL", "'" & dgrNoiDungTrongHopDong_4.Rows(i).Cells("MS_KH").Value & "'") & "," &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("SO_LUONG").Value.ToString = "", 0, dgrNoiDungTrongHopDong_4.Rows(i).Cells("SO_LUONG").Value) & "," &
                        IIf(dgrNoiDungTrongHopDong_4.Rows(i).Cells("DON_GIA").Value.ToString = "", 0, dgrNoiDungTrongHopDong_4.Rows(i).Cells("DON_GIA").Value) & ",'" & _NGOAI_TE & "'," & dgrNoiDungTrongHopDong_4.Rows(i).Cells("TY_GIA").Value & "," & dgrNoiDungTrongHopDong_4.Rows(i).Cells("TY_GIA_USD").Value & ")"
                    End If
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                Next

                'Catch ex As Exception
                'End Try
                blnDv = False
            Else
                Dim str As String = ""
                Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
                objConnection.Open()
                Dim objTrans As SqlTransaction = objConnection.BeginTransaction
                Try
                    str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " WHERE STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objReader.Read
                        str = "SELECT COUNT(*) AS TONG FROM (" &
                              "SELECT DISTINCT dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI, dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV, dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN, " &
                                     "dbo.PHIEU_BAO_TRI_CONG_VIEC.SO_GIO_KH, dbo.PHIEU_BAO_TRI_CONG_VIEC.HANG_MUC_ID, dbo.PHIEU_BAO_TRI_CONG_VIEC.GHI_CHU " &
                              "FROM dbo.PHIEU_BAO_TRI_CONG_VIEC INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & " ON " &
                                     "dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI AND " &
                                     "dbo.PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE = dbo.PHIEU_BAO_TRI_CONG_VIEC_TMP1" & Commons.Modules.UserName & ".STT_EOR " &
                              "WHERE PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE=" & objReader.Item("STT_EOR") & " AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND PHIEU_BAO_TRI_CONG_VIEC.MS_CV=" & objReader.Item("MS_CV") & " AND PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "') TMP"
                        objReaderCheck = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        objReaderCheck.Read()

                        If objReaderCheck.Item("TONG") = 0 Then 'chưa có trong bảng công việc
                            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH,HANG_MUC_ID,EOR_ID,STT_SERVICE) VALUES(N'" &
                                            objReader.Item("MS_PHIEU_BAO_TRI") & "'," & objReader.Item("MS_CV") & ",'" & objReader.Item("MS_BO_PHAN") & "'," & IIf(IsDBNull(objReader.Item("SO_GIO_KH")), "NULL", objReader.Item("SO_GIO_KH")) &
                                            "," & IIf(IsDBNull(objReader.Item("HANG_MUC_ID")), "NULL", objReader.Item("HANG_MUC_ID")) & "," & IIf(IsDBNull(objReader.Item("EOR_ID")), "NULL", objReader.Item("EOR_ID")) & "," & IIf(IsDBNull(objReader.Item("STT_EOR")), "NULL", objReader.Item("STT_EOR")) & ")"
                        Else 'có rồi thì update
                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET SO_GIO_KH=" & IIf(IsDBNull(objReader.Item("SO_GIO_KH")), "NULL", objReader.Item("SO_GIO_KH")) &
                                            ",HANG_MUC_ID=" & IIf(IsDBNull(objReader.Item("HANG_MUC_ID")), "NULL", objReader.Item("HANG_MUC_ID")) & ",EOR_ID=" & IIf(IsDBNull(objReader.Item("EOR_ID")), "NULL", objReader.Item("EOR_ID")) & ",STT_SERVICE=" & IIf(IsDBNull(objReader.Item("STT_EOR")), "NULL", objReader.Item("STT_EOR")) &
                                  " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "'"
                        End If
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        objReaderCheck.Close()
                    End While
                    objReader.Close()
                    objTrans.Commit()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    objTrans.Rollback()
                    Return
                Finally
                    objConnection.Close()
                End Try
                'For i As Integer = 0 To dgrCongViecDaThucHien_4.Rows.Count - 1
                '    If dgrCongViecDaThucHien_4.Rows(i).Cells("HANG_MUC_ID").Value.ToString <> "" Then
                '        str = "UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' WHERE KE_HOACH_TONG_CONG_VIEC.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND KE_HOACH_TONG_CONG_VIEC.HANG_MUC_ID=" & dgrCongViecDaThucHien_4.Rows(i).Cells("HANG_MUC_ID").Value & " AND KE_HOACH_TONG_CONG_VIEC.MS_CV =" & dgrCongViecDaThucHien_4.Rows(i).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(i).Cells("MS_BO_PHAN").Value & "'"
                '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                '    Else
                '        If dgrCongViecDaThucHien_4.Rows(i).Cells("EOR_ID").Value.ToString <> "" Then
                '            str = "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'  WHERE EOR_ID='" & dgrCongViecDaThucHien_4.Rows(i).Cells("EOR_ID").Value & "' AND MS_CV =" & dgrCongViecDaThucHien_4.Rows(i).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(i).Cells("MS_BO_PHAN").Value & "'"
                '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                '        End If
                '    End If

                'Next
                'Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                'For i As Integer = 0 To dgrCongViecDaThucHien_4.Rows.Count - 1
                '    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI(txtMaSoPBT.Text, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_CV").Value, dgrCongViecDaThucHien_4.Rows(i).Cells("MS_BO_PHAN").Value)
                'Next
                Dim tb As New DataTable()
                objConnection.Open()
                objTrans = objConnection.BeginTransaction
                Try
                    str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objReader.Read
                        str = "SELECT COUNT(*) AS TONG FROM (" &
                                    "SELECT DISTINCT dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.* " &
                                    "FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " ON " &
                                         "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI " &
                                    "WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=" & objReader.Item("MS_CV") & " AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT='" & objReader.Item("MS_PT") & "') TMP"
                        objReaderCheck = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        objReaderCheck.Read()

                        If objReaderCheck.Item("TONG") = 0 Then 'chưa có trong bảng công việc
                            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU) VALUES(N'" &
                                            objReader.Item("MS_PHIEU_BAO_TRI") & "'," & objReader.Item("MS_CV") & ",'" & objReader.Item("MS_BO_PHAN") & "','" & objReader.Item("MS_PT") &
                                            "'," & IIf(IsDBNull(objReader.Item("SL_KH")), "NULL", objReader.Item("SL_KH")) & "," & IIf(IsDBNull(objReader.Item("SL_TT")), "NULL", objReader.Item("SL_TT")) & "," & IIf(IsDBNull(objReader.Item("GHI_CHU")), "NULL", "'" & objReader.Item("GHI_CHU") & "'") & ")"
                        Else    'có rồi thì update
                            'str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "',MS_CV=" & _
                            '        objReader.Item("MS_CV") & ",MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "',MS_PT='" & objReader.Item("MS_PT") & _
                            '        "',SL_KH=" & IIf(IsDBNull(objReader.Item("SL_KH")), "NULL", objReader.Item("SL_KH")) & ",SL_TT" & IIf(IsDBNull(objReader.Item("SL_TT")), "NULL", objReader.Item("SL_TT")) & ",GHI_CHU=" & IIf(IsDBNull(objReader.Item("GHI_CHU")), "NULL", "N'" & objReader.Item("GHI_CHU") & "'") & ")"
                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH=" & IIf(IsDBNull(objReader("SL_KH")), "NULL", objReader("SL_KH")) & ",SL_TT=" & IIf(IsDBNull(objReader("SL_TT")), "NULL", objReader("SL_TT")) & ",GHI_CHU=" & IIf(IsDBNull(objReader.Item("GHI_CHU")), "NULL", "N'" & objReader.Item("GHI_CHU") & "'") &
                                  " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") & "'"

                        End If
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        objReaderCheck.Close()
                    End While
                    objReader.Close()
                    objTrans.Commit()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    objTrans.Rollback()
                    Return
                Finally
                    objConnection.Close()
                End Try
                objConnection.Open()
                objTrans = objConnection.BeginTransaction
                Try
                    str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName '& " WHERE TON_TAI IS NULL"

                    'str = "SELECT dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_CV,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_BO_PHAN," & _
                    '             "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_PT,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_VI_TRI_PT,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".SL_KH," & _
                    '             "dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".SL_TT " & _
                    '             "FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " INNER JOIN dbo.PHIEU_BAO_TRI_SERVICE ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI INNER JOIN " & _
                    '             "dbo.PHIEU_BAO_TRI_CONG_VIEC ON dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI AND dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_CV = dbo.PHIEU_BAO_TRI_CONG_VIEC.MS_CV "
                    'objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    'While objReader.Read
                    '    str = "SELECT COUNT(*) AS TONG FROM (" & _
                    '                "SELECT DISTINCT dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_CV,dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_BO_PHAN " & _
                    '                "FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & ".MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " & _
                    '                "WHERE(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV = " & objReader.Item("MS_CV") & " AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT ='" & objReader.Item("MS_PT") & "')) TMP"
                    '    objReaderCheck = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    '    objReaderCheck.Read()

                    '    If objReaderCheck.Item("TONG") = 0 Then 'chưa có trong bảng công việc
                    '        str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT) VALUES(N'" & _
                    '                        objReader.Item("MS_PHIEU_BAO_TRI") & "'," & objReader.Item("MS_CV") & ",'" & objReader.Item("MS_BO_PHAN") & "','" & objReader.Item("MS_PT") & _
                    '                        "'," & IIf(IsDBNull(objReader.Item("MS_VI_TRI_PT")), "NULL", "'" & objReader.Item("MS_VI_TRI_PT") & "'") & "," & IIf(IsDBNull(objReader.Item("SL_KH")), "NULL", objReader.Item("SL_KH")) & "," & IIf(IsDBNull(objReader.Item("SL_TT")), "NULL", objReader.Item("SL_TT")) & ")"
                    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    '    Else 'có rồi thì update
                    '        str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET SET SL_TT=" & IIf(IsDBNull(objReader.Item("SL_TT")), "NULL", objReader.Item("SL_TT")) & " WHERE MS_PHIEU_BAO_TRI ='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND " & _
                    '                "MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") & _
                    '                        "' AND MS_VI_TRI_PT=" & IIf(IsDBNull(objReader.Item("MS_VI_TRI_PT")), "NULL", "'" & objReader.Item("MS_VI_TRI_PT") & "'")
                    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    '    End If
                    '    objReaderCheck.Close()

                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objReader.Read
                        If IsDBNull(objReader.Item("TON_TAI")) Then 'chưa có trong bảng PHU TUNG CHI TIET
                            str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT) VALUES(N'" &
                                            objReader.Item("MS_PHIEU_BAO_TRI") & "'," & objReader.Item("MS_CV") & ",'" & objReader.Item("MS_BO_PHAN") & "','" & objReader.Item("MS_PT") &
                                            "'," & IIf(IsDBNull(objReader.Item("MS_VI_TRI_PT")), "NULL", "'" & objReader.Item("MS_VI_TRI_PT") & "'") & "," & IIf(IsDBNull(objReader.Item("SL_KH")), "NULL", objReader.Item("SL_KH")) & "," & IIf(IsDBNull(objReader.Item("SL_TT")), "NULL", objReader.Item("SL_TT")) & ")"
                        ElseIf CBool(objReader.Item("TON_TAI")) = True Then  'có rồi thì update
                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET SET SL_TT=" & IIf(IsDBNull(objReader.Item("SL_TT")), "NULL", objReader.Item("SL_TT")) & " WHERE MS_PHIEU_BAO_TRI ='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND " &
                                    "MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") &
                                            "' AND MS_VI_TRI_PT=" & IIf(IsDBNull(objReader.Item("MS_VI_TRI_PT")), "NULL", "'" & objReader.Item("MS_VI_TRI_PT") & "'")
                        ElseIf CBool(objReader.Item("TON_TAI")) = False Then 'đã chọn xóa vị trí cũ
                            str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI ='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND " &
                                    "MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") &
                                            "' AND MS_VI_TRI_PT=" & IIf(IsDBNull(objReader.Item("MS_VI_TRI_PT")), "NULL", "'" & objReader.Item("MS_VI_TRI_PT") & "'")

                            str = str & vbCrLf & " DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI ='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND " &
                                    "MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") &
                                            "' AND MS_VI_TRI_PT=" & IIf(IsDBNull(objReader.Item("MS_VI_TRI_PT")), "NULL", "'" & objReader.Item("MS_VI_TRI_PT") & "'")
                        End If
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    End While
                    objReader.Close()

                    Dim dtReader As SqlDataReader

                    'XOA CAC PHU TUNG DA BO CHON TRONG BANG PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET
                    For i As Integer = 0 To dgrCongViecDaThucHien_4.RowCount - 1
                        'LAY CAC PT TUNG UNG VOI CONG VIEC DUOC CHON
                        str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrCongViecDaThucHien_4.Rows(i).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(i).Cells("MS_BO_PHAN").Value & "'"
                        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        While objReader.Read
                            str = "SELECT ISNULL(COUNT(*),0) AS TON_TAI FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") & "'"
                            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            dtReader.Read()
                            If dtReader.Item("TON_TAI") = 0 Then      'CO TRONG PHIEU BAO TRI CONG VIEC PHU TUNG NHUNG DA CHON XOA DL
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET  WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") & "'")
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG  WHERE MS_PHIEU_BAO_TRI='" & objReader.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & objReader.Item("MS_CV") & " AND MS_BO_PHAN='" & objReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & objReader.Item("MS_PT") & "'")
                            End If
                            dtReader.Close()
                        End While
                    Next


                    objTrans.Commit()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    objTrans.Rollback()
                    Return
                Finally
                    objConnection.Close()
                End Try
                DropTable4()
            End If
        End If
        bThem = -1
        HideButton_4(True)
        HideDelete_4(False)
        HideSave4(False)
        LoadDanhsachDVThueNgoai(blnDv)
        LoadDanhSachDV(blnDv)
        RemoveHandler dgrViTriPhuTung_4.CellValidating, AddressOf Me.dgrViTriPhuTung_4_CellValidating
        RemoveHandler dgrViTriPhuTung_41.CellValidating, AddressOf Me.dgrViTriPhuTung_41_CellValidating
        'dgrKeHoachNhanVien_3.Columns.Clear()
        'If radCongViecChinh_3.Checked Then
        '    LoadCVChinh3()
        'Else
        '    LoadCVPhuTro3()
        '     End If
        BindData12(False)
        dgrViTriPhuTung_4.ReadOnly = True
        If dgrNoiDungTrongHopDong_4.Rows.Count > 0 Then dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Selected = True
        dgrNoiDungTrongHopDong_4.AllowUserToAddRows = False
        dgrNoiDungTrongHopDong_4.ReadOnly = True
        dgrNoiDungTrongHopDong_4.Enabled = True

        If TabPhieuBaoTri.SelectedTab.Name = "tabDichVuThueNgoai" Then
            If dgrNoiDungTrongHopDong_4.RowCount = 0 Then
                btnThemSuaCV_4.Enabled = False
                btnDanhGia.Enabled = False
                btnXoa_4.Enabled = False
                grdDanhGiaDV.DataSource = Nothing
            Else
                btnThemSuaCV_4.Enabled = True
                btnDanhGia.Enabled = True
                btnXoa_4.Enabled = True
            End If
        End If
    End Sub
    Private Sub btnKhongGhi_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi_4.Click
        RemoveHandler dgrViTriPhuTung_41.CellValidating, AddressOf Me.dgrViTriPhuTung_41_CellValidating
        RemoveHandler dgrViTriPhuTung_4.CellValidating, AddressOf Me.dgrViTriPhuTung_4_CellValidating
        bThem = -1
        dgrNoiDungTrongHopDong_4.AllowUserToAddRows = False
        dgrNoiDungTrongHopDong_4.ReadOnly = False
        HideButton_4(True)
        HideDelete_4(False)
        HideSave4(False)
        LoadDanhsachDVThueNgoai(False)
        DropTable4()
        BindData12(False)
        dgrViTriPhuTung_4.ReadOnly = True
        dgrNoiDungTrongHopDong_4.AllowUserToAddRows = False
        dgrNoiDungTrongHopDong_4.ReadOnly = True
        dgrNoiDungTrongHopDong_4.Enabled = True
        If dgrNoiDungTrongHopDong_4.Rows.Count > 0 Then dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Selected = True
        LoadDanhSachDV(False)
        If TabPhieuBaoTri.SelectedTab.Name = "tabDichVuThueNgoai" Then
            If dgrNoiDungTrongHopDong_4.RowCount = 0 Then
                btnThemSuaCV_4.Enabled = False
                btnDanhGia.Enabled = False
                btnXoa_4.Enabled = False
                grdDanhGiaDV.DataSource = Nothing
            Else
                btnThemSuaCV_4.Enabled = True
                btnDanhGia.Enabled = True
                btnXoa_4.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnThoat_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnKhongXoa4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongXoa4.Click
        HideButton_4(True)
        HideDelete_4(False)
        HideSave4(False)
    End Sub

    Private Sub BtnPTThayThe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPTThayThe.Click
        'If dgrCongViecDaThucHien_4.Rows.Count > 0 Then
        '    Dim frm As New frmChonPhuTungThaySua
        '    frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
        '    frm.MS_MAY = cboMS_ThietBi.SelectedValue
        '    frm.ShowDialog()
        '    Dim tb As New DataTable
        '    Dim str As String = ""
        '    BindData12(False)
        '    Try
        '        dgrViTriPhuTung_4.Columns("SL_KH").ReadOnly = False
        '        dgrViTriPhuTung_4.Columns("SL_TT").ReadOnly = False
        '        dgrViTriPhuTung_4.Columns("TEN_PT").ReadOnly = True
        '        dgrViTriPhuTung_4.Columns("MS_PT").ReadOnly = True
        '        dgrViTriPhuTung_4.Columns("MS_VI_TRI_PT").ReadOnly = True
        '        dgrViTriPhuTung_4.Columns("SL_CUM").ReadOnly = True
        '        dgrViTriPhuTung_4.Columns("MS_PT_CTY").ReadOnly = True
        '        dgrViTriPhuTung_4.Columns("MS_PT_NCC").ReadOnly = True
        '    Catch ex As Exception

        '    End Try
        'End If

        If dgrCongViecDaThucHien_4.Rows.Count > 0 Then
            Dim frm As New frmChonPhuTungThaySua
            frm.MS_PHIEU_BAO_TRI = txtMaSoPBT.Text
            frm.MS_MAY = cboMS_ThietBi.SelectedValue
            frm.STT_EOR = dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value
            frm.ShowDialog()


            Dim str As String = ""
            Dim tb As New DataTable
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN , MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " WHERE MS_PT_CHA='Y'"
            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            For i As Integer = 0 To tb.Rows.Count - 1
                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName & " Select DISTINCT '" & txtMaSoPBT.Text & "' AS MS_PHIEU_BAO_TRI,'" & tb.Rows(i).Item("MS_CV") & "' AS MS_CV, " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG ,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH , " &
                                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA " &
                                    " FROM CAU_TRUC_THIET_BI_PHU_TUNG LEFT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND  " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                                    " CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV ='" & tb.Rows(i).Item("MS_CV") & "'" &
                                    " WHERE CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" & tb.Rows(i).Item("MS_BO_PHAN") & "' AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = '" & tb.Rows(i).Item("MS_PT") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Next

            Dim vSttservict As Integer = -1
            Try
                vSttservict = Convert.ToInt32(dgrNoiDungTrongHopDong_4.CurrentRow.Cells("STT").Value)
            Catch ex As Exception

            End Try
            BindData12(False)
            Try
                dgrViTriPhuTung_4.Columns("SL_KH").ReadOnly = False
                dgrViTriPhuTung_4.Columns("SL_TT").ReadOnly = False
                dgrViTriPhuTung_4.Columns("TEN_PT").ReadOnly = True
                dgrViTriPhuTung_4.Columns("MS_PT").ReadOnly = True
                dgrViTriPhuTung_4.Columns("MS_VI_TRI_PT").ReadOnly = True
                dgrViTriPhuTung_4.Columns("SL_CUM").ReadOnly = True
                dgrViTriPhuTung_4.Columns("MS_PT_CTY").ReadOnly = True
                dgrViTriPhuTung_4.Columns("MS_PT_NCC").ReadOnly = True
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub btnThemSuaCV_4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThemSuaCV_4.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        intCongViecDaThucHien_4 = dgrCongViecDaThucHien_4.RowCount
        dgrCongViecDaThucHien_4.AllowUserToDeleteRows = True
        intViTriPhuTung_4 = dgrViTriPhuTung_4.RowCount
        dgrViTriPhuTung_4.AllowUserToDeleteRows = True

        If dgrDanhSach_1.Rows.Count = 0 Then
            Exit Sub
        End If
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                Dim str As String = ""
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        blnDv = False
        bThem = 4
        LoadTableTmp4()
        HideButton_4(False)
        HideDelete_4(False)
        HideSave4(True)
        dgrViTriPhuTung_4.ReadOnly = False
        Try
            'dgrViTriPhuTung_4.Columns("SL_KH").ReadOnly = False
            'dgrViTriPhuTung_4.Columns("SL_TT").ReadOnly = False
            dgrViTriPhuTung_4.Columns("TEN_PT").ReadOnly = True
            dgrViTriPhuTung_4.Columns("MS_VI_TRI_PT").ReadOnly = True
            dgrViTriPhuTung_4.Columns("SL_CUM").ReadOnly = True
            dgrViTriPhuTung_4.Columns("MS_PT_CTY").ReadOnly = True
            dgrViTriPhuTung_4.Columns("MS_PT_NCC").ReadOnly = True
        Catch ex As Exception

        End Try
        dgrViTriPhuTung_41.ReadOnly = False
        Try
            dgrViTriPhuTung_41.Columns("MS_VI_TRI_PT").ReadOnly = True
        Catch ex As Exception
        End Try
        AddHandler dgrViTriPhuTung_4.CellValidating, AddressOf Me.dgrViTriPhuTung_4_CellValidating
        AddHandler dgrViTriPhuTung_41.CellValidating, AddressOf Me.dgrViTriPhuTung_41_CellValidating

        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                Dim str As String = ""
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        blnDv = False
        bThem = 4
        LoadTableTmp4()
        HideButton_4(False)
        HideDelete_4(False)
        HideSave4(True)
        dgrViTriPhuTung_4.ReadOnly = False
        dgrNoiDungTrongHopDong_4.Enabled = False
        Try
            'dgrViTriPhuTung_4.Columns("SL_KH").ReadOnly = False
            'dgrViTriPhuTung_4.Columns("SL_TT").ReadOnly = False
            dgrViTriPhuTung_4.Columns("TEN_PT").ReadOnly = True
            dgrViTriPhuTung_4.Columns("MS_VI_TRI_PT").ReadOnly = True
            dgrViTriPhuTung_4.Columns("SL_CUM").ReadOnly = True
            dgrViTriPhuTung_4.Columns("MS_PT_CTY").ReadOnly = True
            dgrViTriPhuTung_4.Columns("MS_PT_NCC").ReadOnly = True
        Catch ex As Exception

        End Try
        AddHandler dgrViTriPhuTung_4.CellValidating, AddressOf Me.dgrViTriPhuTung_4_CellValidating
        If dgrNoiDungTrongHopDong_4.Rows.Count > 0 Then LoadDanhSachDV(True)
    End Sub
    Private Sub dgrCongViecDaThucHien_4_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrCongViecDaThucHien_4.RowEnter
        intRowCV_TN = e.RowIndex
        BindData13()
    End Sub

    Private Sub dgrViTriPhuTung_4_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgrViTriPhuTung_4.CellValidating
        If btnKhongGhi_4.Focused() Or btnGhi_4.Visible = False Then
            Exit Sub
        End If
        Dim tmp As String = ""

        If dgrViTriPhuTung_4.Columns(e.ColumnIndex).Name = "SL_KH" Then
            If e.FormattedValue = "" Then
                tmp = "null"
            Else
                If Not IsNumeric(e.FormattedValue) Then
                    'XtraMessageBox.Show("giá trị nhập không phải số")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    dgrViTriPhuTung_4.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If e.FormattedValue <= 0 Or e.FormattedValue = "0-" Or e.FormattedValue = "-0" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_4.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                    If Not IsDBNull(dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("SL_CUM").Value) Then
                        Dim str1 As String = ""
                        Dim MS_LOAI_VT As Integer = 0
                        str1 = "SELECT MS_LOAI_VT FROM IC_PHU_TUNG WHERE MS_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str1)
                        While objReader.Read
                            MS_LOAI_VT = objReader.Item("MS_LOAI_VT")
                        End While
                        objReader.Close()
                        If MS_LOAI_VT = 1 Then
                            If e.FormattedValue > dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("SL_CUM").Value Then
                                'XtraMessageBox.Show("số lượng kế hoạch không được lớn hơn số lượng cụm")
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoLuongKhongTrung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                                dgrViTriPhuTung_4.Rows(e.RowIndex).ErrorText = "Error"
                                e.Cancel = True
                                Exit Sub
                            Else
                                tmp = e.FormattedValue
                            End If
                        Else
                            tmp = e.FormattedValue
                        End If
                    Else
                        tmp = e.FormattedValue
                    End If
                End If
            End If
            Dim str As String = ""
            If dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT_CHA").Value = "Y" Then
                'str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " SET SL_KH =" & tmp & " WHERE MS_PHIEU_BAO_TRI='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "'" & _
                '    " AND MS_CV='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_CV").Value & "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'" & _
                '    " AND MS_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT=" & IIf(IsDBNull(dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value), "NULL", "'" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'")
            Else
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " SET SL_KH =" & tmp & " WHERE MS_PHIEU_BAO_TRI='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "'" &
                      " AND MS_CV='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_CV").Value & "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'" &
                      " AND MS_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        ElseIf dgrViTriPhuTung_4.Columns(e.ColumnIndex).Name = "SL_TT" Then
            If e.FormattedValue = "" Then
                tmp = "null"
            Else
                If Not IsNumeric(e.FormattedValue) Then
                    'XtraMessageBox.Show("giá trị nhập không phải số")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    dgrViTriPhuTung_4.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    If e.FormattedValue <= 0 Or e.FormattedValue = "0-" Or e.FormattedValue = "-0" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_4.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                    tmp = e.FormattedValue
                End If
            End If
            Dim str As String = ""
            If dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT_CHA").Value = "Y" Then
                'str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " SET SL_TT =" & tmp & " WHERE MS_PHIEU_BAO_TRI='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "'" & _
                '    " AND MS_CV='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_CV").Value & "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'" & _
                '    " AND MS_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'"
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " SET SL_TT =" & tmp & " WHERE MS_PHIEU_BAO_TRI='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "'" &
                    " AND MS_CV='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_CV").Value & "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'" &
                    " AND MS_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_PT_CHA='Y'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Else
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " SET SL_TT =" & tmp & " WHERE MS_PHIEU_BAO_TRI='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "'" &
                      " AND MS_CV='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_CV").Value & "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'" &
                      " AND MS_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        ElseIf dgrViTriPhuTung_4.Columns(e.ColumnIndex).Name = "GHI_CHU" Then
            Dim str As String = ""
            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" & Commons.Modules.UserName & " SET SL_TT=" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("SL_TT").Value & ", GHI_CHU ='" & e.FormattedValue & "' WHERE MS_PHIEU_BAO_TRI='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PHIEU_BAO_TRI").Value & "'" &
                                  " AND MS_CV='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_CV").Value & "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'" &
                                  " AND MS_PT='" & dgrViTriPhuTung_4.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End If
        dgrViTriPhuTung_4.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub btnXoaPhuTung_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaPhuTung_4.Click
        If dgrViTriPhuTung_4.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaPT", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                If IsDBNull(dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_VI_TRI_PT").Value) Then
                    'NEU LA PT CHA
                    Dim dtReader As SqlDataReader

                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_MAY,MS_BO_PHAN,MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & cboMS_ThietBi.SelectedValue.ToString & "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_BO_PHAN").Value & "'")
                    While dtReader.Read
                        'XOA PT CHA
                        Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_CV").Value & " AND MS_BO_PHAN ='" & dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dtReader.Item("MS_PT") & "' " & vbCrLf &
                                 "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_CV").Value & " AND MS_BO_PHAN ='" & dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dtReader.Item("MS_PT") & "' "
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    End While
                    dtReader.Close()

                    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI_1(txtMaSoPBT.Text, dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_CV").Value, dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_BO_PHAN").Value, dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_PT").Value)
                Else
                    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_THUE_NGOAI(txtMaSoPBT.Text, dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_CV").Value, dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_BO_PHAN").Value, dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("MS_PT").Value, dgrViTriPhuTung_4.Rows(intRowPT_TN).Cells("STT").Value)
                End If
            End If
            BindData12(False)
        End If
    End Sub

    Private Sub btnXoaCongViec_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaCongViec_4.Click
        If dgrCongViecDaThucHien_4.Rows.Count = 0 Then
            'XtraMessageBox.Show("KHÔNG CÓ DỮ LIỆU ĐỂ XÓA")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
            If Not objPHIEU_BAO_TRIController.CheckPHIEU_BAO_TRI_CONG_VIEC(txtMaSoPBT.Text, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value) Then
                'XtraMessageBox.Show("CÔNG VIỆC NÀY ĐÃ ĐƯỢC SỬ DỤNG Ở TABLE KHÁC")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCongViecDaSD", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            Else
                Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaCongViec", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC(txtMaSoPBT.Text, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_CV").Value, dgrCongViecDaThucHien_4.Rows(intRowCV_TN).Cells("MS_BO_PHAN").Value)
                    If dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("HANG_MUC_ID").Value.ToString <> "" Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKE_HOACH_TONG_CONG_VIEC", cboMS_ThietBi.SelectedValue, dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("HANG_MUC_ID").Value, dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("MS_CV").Value, dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("MS_BO_PHAN").Value, txtMaSoPBT.Text)
                    Else
                        If dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("EOR_ID").Value.ToString <> "" Then
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI =NULL WHERE EOR_ID='" & dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("EOR_ID").Value & "' AND MS_CV=" & dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrCongViecDaThucHien_4.Rows(intRowCV).Cells("MS_BO_PHAN").Value & "' AND MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'")
                        End If
                    End If
                    BindData12(False)
                    'LoadCVChinh3()
                End If
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPhieuBaoTri.SelectedIndexChanged
        If bThem <> -1 Then
            TabPhieuBaoTri.SelectedIndex = bThem - 1
            If TabPhieuBaoTri.SelectedIndex = 2 Then binddata_Kehoachnhanvien()
            Exit Sub
        Else
            If TabPhieuBaoTri.SelectedIndex = 0 Then
                If bHuyNT > 0 Then
                    Dim tmpPBT As String = Me.txtMaSoPBT.Text
                    If bHuyNT = 1 Then
                        radPhieuBaoTriChuaNghiemThu_1.Checked = True
                    Else
                        radPhieuBaoTriDaNghiemThu_1.Checked = True
                    End If
                    BindData()
                    For j As Integer = 0 To dgrDanhSach_1.Rows.Count - 1
                        If dgrDanhSach_1.Rows(j).Cells("MS_PHIEU_BAO_TRI").Value = tmpPBT Then
                            dgrDanhSach_1.Rows(j).Cells("MS_PHIEU_BAO_TRI").Selected = True
                            dgrDanhSach_1.Focus()
                            Exit For
                        End If
                    Next
                    bHuyNT = 0
                End If
            ElseIf TabPhieuBaoTri.SelectedIndex = 1 Then
                BindData1(True)
                BindData11(True)
            Else
                If TabPhieuBaoTri.SelectedIndex = 2 Then
                    binddata_Congviecchinh()
                    binddata_CongviecPhu()
                    binddata_Kehoachnhanvien()
                    Try
                        If cboTinhTrangPBT.SelectedValue = 4 Or cboTinhTrangPBT.SelectedValue = 3 Then
                            grdCongviecchinh.ReadOnly = True
                            grdCongviecphu.ReadOnly = True
                        Else
                            grdCongviecchinh.ReadOnly = False
                            grdCongviecphu.ReadOnly = False
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    If TabPhieuBaoTri.SelectedIndex = 3 Then
                        DropTable4()
                        dgrNoiDungTrongHopDong_4.AllowUserToAddRows = False
                        dgrNoiDungTrongHopDong_4.ReadOnly = True
                        LoadDanhsachDVThueNgoai(False)
                        LoadDanhSachDV(False)
                    Else
                        If TabPhieuBaoTri.SelectedIndex = 4 Then
                            'BindData12(True)
                            'Else
                            'If TabPhieuBaoTri.SelectedIndex = 4 Then
                            cboBPCP.Enabled = False
                            cboNhaXuong.Enabled = False
                            cboHeThong.Enabled = False

                            BindData5()
                            'QuyenUser()
                            LoadNgayBatDauBaoTri(Me.txtMaSoPBT.Text)
                            LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
                            LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
                            'end tab 5
                            'End If
                            If cboTinhTrangPBT.SelectedValue = 4 Or (radPhieuBaoTriDaNghiemThu_1.Checked And bCoQuyen = False) Then
                                EnableButton5(False)
                            Else
                                EnableButton5(True)
                                If cboTinhTrangPBT.SelectedValue = 3 Then
                                    BtnXacnhanNT.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            Else
                'If TabPhieuBaoTri.SelectedIndex = 2 Then
                '    If grdCongviecchinh.RowCount > 0 And radCongviecchinh.Checked = True Then
                '        grdCongviecchinh.Rows(0).Selected = True
                '        If IsDBNull(grdCongviecchinh.Rows(0).Cells("NGAY_HOAN_THANH").Value) Then
                '            btnThemsua.Enabled = True
                '            btnXoa.Enabled = True
                '        Else
                '            btnThemsua.Enabled = False
                '            btnXoa.Enabled = False
                '        End If
                '    End If
                If cboTinhTrangPBT.SelectedValue < 4 Then
                    EnableButton(True)
                    If radPhieuBaoTriChuaNghiemThu_1.Checked Then
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
                End If
                'End If
            End If
        End If
        If TabPhieuBaoTri.SelectedTab.Name = "tabDichVuThueNgoai" Then
            If dgrNoiDungTrongHopDong_4.RowCount = 0 Then
                btnThemSuaCV_4.Enabled = False
                btnDanhGia.Enabled = False
                btnXoa_4.Enabled = False
                grdDanhGiaDV.DataSource = Nothing
            Else
                btnThemSuaCV_4.Enabled = True
                btnDanhGia.Enabled = True
                btnXoa_4.Enabled = True
            End If
        End If
    End Sub

    Private Sub BindDataDV_ThueNgoai(ByVal iRow As Integer)
        Dim str As String = ""
        Dim tb As New DataTable
        If bGhi Then
            If dgrCongViecDaThucHien_4.RowCount > 0 And Not bChangce Then
                Exit Sub
            End If
        End If
        BindData12(False)
        BindData13()
    End Sub

    Private Sub dgrNoiDungTrongHopDong_4_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrNoiDungTrongHopDong_4.CellValidated
    End Sub

    Private Sub dgrNoiDungTrongHopDong_4_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgrNoiDungTrongHopDong_4.CellValidating
        Dim dtReader As SqlDataReader

        If dgrNoiDungTrongHopDong_4.Columns(e.ColumnIndex).Name.ToString = "cboNGOAI_TE" Then
            Try
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM TI_GIA_NT WHERE NGOAI_TE='" & dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("cboNGOAI_TE").Value.ToString & "' AND NGAY >=ALL (SELECT MAX(NGAY) FROM TI_GIA_NT)")
                While dtReader.Read
                    dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA").Value = dtReader.Item("TI_GIA")
                    dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA_USD").Value = dtReader.Item("TI_GIA_USD")
                End While
                dtReader.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    'Private Sub dgrNoiDungTrongHopDong_4_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgrNoiDungTrongHopDong_4.CellValidating
    '    If IsDBNull(dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("SO_LUONG").Value) Or IsDBNull(dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("DON_GIA").Value) Then Exit Sub
    'End Sub

    Private Sub dgrNoiDungTrongHopDong_4_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgrNoiDungTrongHopDong_4.DataError
        If e.Context = 768 Then
            If IsDBNull(dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("SO_LUONG").Value) Or IsDBNull(dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("DON_GIA").Value) Then Exit Sub
            If dgrNoiDungTrongHopDong_4.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmEOR", "MsgNotNum", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                e.Cancel = True
            ElseIf dgrNoiDungTrongHopDong_4.Columns(e.ColumnIndex).Name = "DON_GIA" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmEOR", "MsgNotNum1", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dgrNoiDungTrongHopDong_4_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgrNoiDungTrongHopDong_4.DefaultValuesNeeded
        Try
            Dim dtReader As SqlDataReader
            With e.Row
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH=1")
                While dtReader.Read
                    .Cells("cboNGOAI_TE").Value = dtReader.Item("NGOAI_TE")
                End While
                dtReader.Close()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgrNoiDungTrongHopDong_4_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrNoiDungTrongHopDong_4.RowEnter
        intRowIndex = e.RowIndex
        dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("THANH_TIEN").ReadOnly = True
        'dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA").ReadOnly = Not btnGhi_4.Visible
        'dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA_USD").ReadOnly = Not btnGhi_4.Visible
        BindDataDV_ThueNgoai(e.RowIndex)
        grdDanhGiaDV.Enabled = False
        LoadDanhSachDV(False)
    End Sub
    'Private Sub dgrKeHoachNhanVien_3_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '      intRowKHNV = e.RowIndex
    ' End Sub


    Private Sub grdHinh_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdHinh.RowEnter
        intRowHinh = e.RowIndex
    End Sub

    Private Sub dgrDanhSachCongViecPhuTro_2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrDanhSachCongViecPhuTro_2.KeyDown
        If e.KeyCode = Keys.Escape Then
            If dgrDanhSachCongViecPhuTro_2.RowCount > 1 Then
                If dgrDanhSachCongViecPhuTro_2.RowCount - 1 > rowCountCVPT And Not dgrDanhSachCongViecPhuTro_2.CurrentRow.IsNewRow Then
                    dgrDanhSachCongViecPhuTro_2.Rows.RemoveAt(Me.dgrDanhSachCongViecPhuTro_2.CurrentRow.Index)
                End If
            Else
                BindData11(False)
            End If
            Exit Sub
        End If
    End Sub

    Private Sub dgrDanhSachCongViecPhuTro_2_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhSachCongViecPhuTro_2.RowEnter
        intRowCVP = e.RowIndex
    End Sub
#End Region

#Region "Tab5"
    Sub HideButton5(ByVal An As Boolean)
        btnSua5.Visible = Not An
        btnXoa5.Visible = Not An
        btnThoat5.Visible = Not An
        btnGhi5.Visible = An
        btnKhongGhi5.Visible = An
        'cmdChonBoPhan.Visible = An
        BtnLockPBT.Visible = Not An
        BtnXacnhanNT.Visible = Not An
    End Sub

    Sub EnableButton5(ByVal Khoa As Boolean)
        btnSua5.Enabled = Khoa
        btnXoa5.Enabled = Khoa
        BtnLockPBT.Enabled = Khoa
        BtnXacnhanNT.Enabled = Khoa

    End Sub

    Sub LockData5(ByVal btnKhoa As Boolean)
        With grdDichVuThueNgoai
            .ReadOnly = btnKhoa
            .AllowUserToAddRows = Not btnKhoa
            If .RowCount > 1 Then
                If Not btnKhoa Then
                    .Columns("NOI_DUNG_SERVICE").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("NGAY_HOAN_THANH").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("BAO_HANH_DEN").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("DIEM").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("NOI_DUNG_DANH_GIA").SortMode = DataGridViewColumnSortMode.NotSortable
                Else
                    .Columns("NOI_DUNG_SERVICE").SortMode = DataGridViewColumnSortMode.Automatic
                    .Columns("NGAY_HOAN_THANH").SortMode = DataGridViewColumnSortMode.Automatic
                    .Columns("BAO_HANH_DEN").SortMode = DataGridViewColumnSortMode.Automatic
                    .Columns("DIEM").SortMode = DataGridViewColumnSortMode.Automatic
                    .Columns("NOI_DUNG_DANH_GIA").SortMode = DataGridViewColumnSortMode.Automatic
                End If
            End If
        End With
        With grdPhuTungThayThe
            .ReadOnly = btnKhoa
            .Columns("MS_PT").ReadOnly = True
            .Columns("MS_BO_PHAN").ReadOnly = True
            .Columns("MS_VI_TRI_PT").ReadOnly = True
            .Columns("MS_PT1").ReadOnly = True
        End With
        With grdDiChuyenBoPhan
            .ReadOnly = btnKhoa
            .Columns("MS_MAY_THAY_THE").ReadOnly = True
            .Columns("TEN_BO_PHAN_THAY_THE").ReadOnly = True
            .Columns("MS_BO_PHAN_THAY_THE").ReadOnly = True
            .Columns("TEN_BO_PHAN").ReadOnly = True
            .Columns("NGAY_TRA_TT").ReadOnly = True
            .AllowUserToAddRows = Not btnKhoa
            If .RowCount > 1 Then
                If Not btnKhoa Then
                    .Columns("cboNgayThay").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("MS_MAY_THAY_THE").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("MS_BO_PHAN_THAY_THE").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("MS_BO_PHAN").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("TEN_BO_PHAN_THAY_THE").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("TEN_BO_PHAN").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("cboNguoiChoPhep").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("DAI_HAN").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("txtDenNgay").SortMode = DataGridViewColumnSortMode.NotSortable
                Else
                    .Columns("cboNgayThay").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("MS_MAY_THAY_THE").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("MS_BO_PHAN_THAY_THE").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("MS_BO_PHAN").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("TEN_BO_PHAN_THAY_THE").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("TEN_BO_PHAN").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("cboNguoiChoPhep").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("DAI_HAN").SortMode = DataGridViewColumnSortMode.NotSortable
                    .Columns("txtDenNgay").SortMode = DataGridViewColumnSortMode.NotSortable
                End If
            End If
        End With

        cboNguoiNghiemThu.Enabled = Not btnKhoa
        txtNgayNghiemThu.ReadOnly = btnKhoa
        cboNgayNghiemThu.Enabled = Not btnKhoa
        txtChiSoDongHo.ReadOnly = btnKhoa
        txtChiPhiKhacMacDinh.ReadOnly = btnKhoa
        'txtChiPhiKhacUSD.ReadOnly = btnKhoa
        txtMovement.ReadOnly = btnKhoa
        txtTinhTrangSauBaoTri.ReadOnly = btnKhoa
        cboBPCP.Enabled = Not btnKhoa
        cboNhaXuong.Enabled = Not btnKhoa
        cboHeThong.Enabled = Not btnKhoa

    End Sub

    Private Sub btnSua5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua5.Click
        Dim str As String = ""
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                cboTinhTrangPBT.SelectedValue = 2
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        bThem = 5
        BindData5()
        Dim intHang As Integer
        If txtMaSoPBT.Text = "" Then Exit Sub
        HideButton5(True)
        LockData5(False)
        intTabChanged = 4

        For intHang = 0 To grdDiChuyenBoPhan.Rows.Count - 2
            strArrMSBoPhan(intHang) = grdDiChuyenBoPhan.Rows(intHang).Cells("MS_BO_PHAN").Value
            strArrMSBoPhanThayThe(intHang) = grdDiChuyenBoPhan.Rows(intHang).Cells("MS_BO_PHAN_THAY_THE").Value
            strArrMSMay(intHang) = grdDiChuyenBoPhan.Rows(intHang).Cells("MS_MAY_THAY_THE").Value
        Next
        intRowCountDVTN = grdDichVuThueNgoai.RowCount
        intRowCountDCBP = grdDiChuyenBoPhan.RowCount
        AddHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged
        AddHandler grdDiChuyenBoPhan.CellDoubleClick, AddressOf Me.grdDiChuyenBoPhan_CellDoubleClick
        BindDataPTThayThe()
        Try
            str = "DROP TABLE BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE,MS_MAY,MS_BO_PHAN,CONVERT(int,1) AS TON_TAI " &
        " INTO DBO.BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName & " FROM PHIEU_BAO_TRI_DI_CHUYEN_BP PBTDC INNER JOIN PHIEU_BAO_TRI PBT ON PBTDC.MS_PHIEU_BAO_TRI=PBT.MS_PHIEU_BAO_TRI WHERE NGAY_TRA_TT IS NULL and PBT.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            grdPhuTungThayThe.Columns("BAO_HANH_DEN_NGAY").ReadOnly = True
            grdPhuTungThayThe.Columns("XUAT_XU").ReadOnly = True
            grdPhuTungThayThe.Columns("SL_KH").ReadOnly = True
            grdPhuTungThayThe.Columns("MS_PT1").ReadOnly = True
        Catch ex As Exception

        End Try
        AddHandler grdPhuTungThayThe.CellValueChanged, AddressOf Me.grdPhuTungThayThe_CellValueChanged
        AddHandler grdPhuTungThayThe.DataSourceChanged, AddressOf Me.grdPhuTungThayThe_DataSourceChanged
    End Sub

    Private Sub btnGhi5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi5.Click
        RemoveHandler grdPhuTungThayThe.CellValueChanged, AddressOf Me.grdPhuTungThayThe_CellValueChanged
        RemoveHandler grdPhuTungThayThe.DataSourceChanged, AddressOf Me.grdPhuTungThayThe_DataSourceChanged
        Dim intRowCount As Integer = grdDiChuyenBoPhan.RowCount - 1
        Dim i As Integer = 0
        blnLoiGhiDuLieu = False
        ThucHienGhiDichVuThueNgoai()
        If blnLoiGhiDuLieu Then Exit Sub
        ThucHienGhiPTThayThe()
        If blnLoiGhiDuLieu Then Exit Sub
        ThucHienGhiDiChuyenBoPhan()
        If blnLoiGhiDuLieu Then Exit Sub


        For i = 0 To grdPhuTungThayThe.RowCount - 1
            If (Not IsDBNull(grdPhuTungThayThe.Rows(i).Cells("MS_PT1").Value) And IsDBNull(Me.grdPhuTungThayThe.Rows(i).Cells("NGUOI_THAY_THE").Value)) Or IsDBNull(Me.grdPhuTungThayThe.Rows(i).Cells("NGUOI_THAY_THE").Value) Then
                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNguoiThayThe", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    Me.grdPhuTungThayThe.CurrentCell() = Me.grdPhuTungThayThe.Rows(i).Cells("cboNguoiThayThe")
                    Me.grdPhuTungThayThe.Focus()
                    blnLoiGhiDuLieu = True
                    Exit Sub
                Else
                    Exit For
                End If
            End If
        Next

        For k As Integer = 0 To grdPhuTungThayThe.RowCount - 1
            If IsDBNull(grdPhuTungThayThe.Rows(k).Cells("cboNgoaiTe").Value) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_NGOAI_TE", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                grdPhuTungThayThe.CurrentCell = grdPhuTungThayThe.Rows(k).Cells("cboNgoaiTe")
                Exit Sub
            End If
        Next

        ''hỏi có then gì khác không
        'If CType(Val(txtChiPhiKhacMacDinh.Text), Double) = 0 And CType(Val(txtChiPhiKhacUSD.Text), Double) = 0 Then
        '    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT19", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
        '        txtChiPhiKhacMacDinh.ReadOnly = False
        '        'txtChiPhiKhacUSD.ReadOnly = False
        '        txtChiPhiKhacMacDinh.Focus()
        '        Exit Sub
        '    End If
        'End If

        If Not txtChiPhiKhacMacDinh.IsValidated Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT20", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            txtChiPhiKhacMacDinh.Focus()
            Exit Sub
        End If
        'If Not txtChiPhiKhacUSD.IsValidated Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT20", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        '    txtChiPhiKhacUSD.Focus()
        '    Exit Sub
        'End If

        If grdPhuTungThayThe.RowCount > 0 Then
            If IsDBNull(grdPhuTungThayThe.CurrentRow.Cells("SL_TT").Value) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_SLTT_FAIL", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                grdPhuTungThayThe.CurrentRow.Cells("SL_TT").Selected = True
                Exit Sub
            ElseIf grdPhuTungThayThe.CurrentRow.Cells("SL_TT").Value = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msg_SLTT_FAIL", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                grdPhuTungThayThe.CurrentRow.Cells("SL_TT").Selected = True
                Exit Sub
            End If
        End If
        'ThucHienGhiThongTinNghiemThu()
        'If blnLoiGhiDuLieu Then Exit Sub

        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BPCP_DiaDiem_DayChuyen", Commons.Modules.TypeLanguage), MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Cancel Then
            Exit Sub
        End If


        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_UpdatePhieuBaoTriNghiemThu_CS", Me.txtMaSoPBT.Text, IIf(IsDBNull(Me.txtTinhTrangSauBaoTri.Text), Nothing, Me.txtTinhTrangSauBaoTri.Text), IIf(IsDBNull(Me.cboNguoiNghiemThu.SelectedValue), Nothing, Me.cboNguoiNghiemThu.SelectedValue), IIf(IsDBNull(Me.txtNgayNghiemThu.Text) Or txtNgayNghiemThu.Text = "  /  /", Nothing, txtNgayNghiemThu.Text), Commons.Modules.UserName, IIf(IsDBNull(Me.cboBPCP.SelectedValue), Nothing, Me.cboBPCP.SelectedValue), IIf(IsDBNull(Me.cboNhaXuong.SelectedValue), Nothing, Me.cboNhaXuong.SelectedValue), IIf(IsDBNull(Me.cboHeThong.SelectedValue), Nothing, Me.cboHeThong.SelectedValue))
        Catch
        End Try

        'Ghi Di Chuyen Bo Phan

        While i < intRowCount
            If i < intRowCountDCBP - 1 Then
                If grdDiChuyenBoPhan.Rows(i).Cells("DAI_HAN").Value Then
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePhieuBaoTriDiChuyenBP", Me.txtMaSoPBT.Text, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_MAY_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNguoiChoPhep").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNgayThay").Value, grdDiChuyenBoPhan.Rows(i).Cells("DAI_HAN").Value, "", Me.strArrMSBoPhan(i), Me.strArrMSMay(i), Me.strArrMSBoPhanThayThe(i))
                Else
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePhieuBaoTriDiChuyenBP", Me.txtMaSoPBT.Text, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_MAY_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNguoiChoPhep").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNgayThay").Value, grdDiChuyenBoPhan.Rows(i).Cells("DAI_HAN").Value, Format(grdDiChuyenBoPhan.Rows(i).Cells("txtDenNgay").Value, "Short date"), Me.strArrMSBoPhan(i), Me.strArrMSMay(i), Me.strArrMSBoPhanThayThe(i))
                End If
            Else
                If grdDiChuyenBoPhan.Rows(i).Cells("DAI_HAN").Value Then
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPhieuBaoTriDiChuyenBP", Me.txtMaSoPBT.Text, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_MAY_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNguoiChoPhep").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNgayThay").Value, grdDiChuyenBoPhan.Rows(i).Cells("DAI_HAN").Value, DBNull.Value)
                Else
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPhieuBaoTriDiChuyenBP", Me.txtMaSoPBT.Text, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_MAY_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("TEN_BO_PHAN_THAY_THE").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNguoiChoPhep").Value, grdDiChuyenBoPhan.Rows(i).Cells("cboNgayThay").Value, grdDiChuyenBoPhan.Rows(i).Cells("DAI_HAN").Value, Format(grdDiChuyenBoPhan.Rows(i).Cells("txtDenNgay").Value, "MM/dd/yyyy"))
                End If

            End If
            i += 1
        End While

        'Het Ghi

        'Ghi PT Thay the
        i = 0
        intRowCount = grdPhuTungThayThe.RowCount
        While i < intRowCount
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePBT_PhuTungThayThe", Me.grdPhuTungThayThe.Rows(i).Cells("STT").Value, grdPhuTungThayThe.Rows(i).Cells("SL_TT").Value, grdPhuTungThayThe.Rows(i).Cells("NGUOI_THAY_THE").Value, grdPhuTungThayThe.Rows(i).Cells("MS_DH_NHAP_PT").Value, grdPhuTungThayThe.Rows(i).Cells("MS_PT1").Value, grdPhuTungThayThe.Rows(i).Cells("DON_GIA").Value, grdPhuTungThayThe.Rows(i).Cells("cboNgoaiTe").Value, grdPhuTungThayThe.Rows(i).Cells("TY_GIA").Value, grdPhuTungThayThe.Rows(i).Cells("TY_GIA_USD").Value)
            i = i + 1
        End While

        Dim TB As New DataTable()
        TB = grdPhuTungThayThe.DataSource
        Dim str As String = ""
        '        str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_TT=( SELECT SUM(SL_TT) FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET PBTCT " & _
        '        " WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_bAO_TRI = PBTCT.MS_PHIEU_BAO_TRI " & _
        '       " AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV=PBTCT.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PBTCT.MS_BO_PHAN " & _
        '      " AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT=PBTCT.MS_PT ) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        For i = 0 To grdPhuTungThayThe.RowCount - 1
            Dim SL_TT As Double = 0
            For j As Integer = 0 To grdPhuTungThayThe.RowCount - 1
                If grdPhuTungThayThe.Rows(j).Cells("MS_PT").Value.Equals(grdPhuTungThayThe.Rows(i).Cells("MS_PT").Value) And grdPhuTungThayThe.Rows(j).Cells("MS_BO_PHAN").Value.Equals(grdPhuTungThayThe.Rows(i).Cells("MS_BO_PHAN").Value) And grdPhuTungThayThe.Rows(j).Cells("MS_CV").Value.Equals(grdPhuTungThayThe.Rows(i).Cells("MS_CV").Value) Then
                    Try
                        SL_TT = SL_TT + Convert.ToDouble(grdPhuTungThayThe.Rows(j).Cells("SL_TT").Value)
                    Catch ex As Exception
                    End Try
                End If
            Next
            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_TT=" & SL_TT &
               " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_PT='" & grdPhuTungThayThe.Rows(i).Cells("MS_PT").Value & "' AND MS_BO_PHAN = '" & grdPhuTungThayThe.Rows(i).Cells("MS_BO_PHAN").Value & "' AND MS_CV = " & grdPhuTungThayThe.Rows(i).Cells("MS_CV").Value & ""
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next

        'Het Ghi
        i = 0
        intRowCount = grdDichVuThueNgoai.RowCount - 1
        'Ghi Dich Vu Thue Ngoai
        While i < intRowCount

            If i < intRowCountDVTN - 1 Then
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDichVuThueNgoai", Me.txtMaSoPBT.Text, Me.grdDichVuThueNgoai.Rows(i).Cells("STT").Value, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_SERVICE").Value, grdDichVuThueNgoai.Rows(i).Cells("NGAY_HOAN_THANH").Value.ToString(), grdDichVuThueNgoai.Rows(i).Cells("BAO_HANH_DEN").Value.ToString(), grdDichVuThueNgoai.Rows(i).Cells("DIEM").Value, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_DANH_GIA").Value, grdDichVuThueNgoai.Rows(i).Cells("GHI_CHU").Value)
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateDichVuThueNgoai", Me.txtMaSoPBT.Text, Me.grdDichVuThueNgoai.Rows(i).Cells("STT").Value, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_SERVICE").Value, Format(grdDichVuThueNgoai.Rows(i).Cells("NGAY_HOAN_THANH").Value, "MM/dd/yyyy"), grdDichVuThueNgoai.Rows(i).Cells("BAO_HANH_DEN").Value, grdDichVuThueNgoai.Rows(i).Cells("DIEM").Value, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_DANH_GIA").Value)
            Else
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDichVuThueNgoai", Me.txtMaSoPBT.Text, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_SERVICE").Value, Format(grdDichVuThueNgoai.Rows(i).Cells("NGAY_HOAN_THANH").Value, "MM/dd/yyyy"), grdDichVuThueNgoai.Rows(i).Cells("BAO_HANH_DEN").Value, grdDichVuThueNgoai.Rows(i).Cells("DIEM").Value, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_DANH_GIA").Value)
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddDichVuThueNgoai", Me.txtMaSoPBT.Text, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_SERVICE").Value, grdDichVuThueNgoai.Rows(i).Cells("NGAY_HOAN_THANH").Value.ToString(), grdDichVuThueNgoai.Rows(i).Cells("BAO_HANH_DEN").Value.ToString(), grdDichVuThueNgoai.Rows(i).Cells("DIEM").Value, grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_DANH_GIA").Value, grdDichVuThueNgoai.Rows(i).Cells("GHI_CHU").Value)
            End If
            i = i + 1
        End While
        'Het Ghi
        Try
            Commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CHI_PHI(MS_PHIEU_BAO_TRI,CHI_PHI_KHAC,CHI_PHI_KHAC_USD) VALUES(N'" & txtMaSoPBT.Text & "','" & Val(IIf(IsDBNull(txtChiPhiKhacMacDinh.Text.ToString), 0, txtChiPhiKhacMacDinh.Text.ToString.Replace(",", ""))) & "','" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
            Try
                Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacMacDinh.Text), 0, txtChiPhiKhacMacDinh.Text.Replace(",", ""))) & "', CHI_PHI_KHAC_USD ='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & "' WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Catch ex1 As Exception
                Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacMacDinh.Text), 0, txtChiPhiKhacMacDinh.Text.Replace(",", ""))) & "', CHI_PHI_KHAC_USD ='" & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & "' WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            End Try
        End Try

        BindData5()
        HideButton5(False)
        LockData5(True)
        intTabChanged = -1
        bThem = -1
        BtnXacnhanNT.Enabled = True
        grdDiChuyenBoPhan.AllowUserToAddRows = False
        grdDichVuThueNgoai.AllowUserToAddRows = False
        Try
            str = "DROP TABLE BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        RemoveHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged
        RemoveHandler grdDiChuyenBoPhan.CellDoubleClick, AddressOf Me.grdDiChuyenBoPhan_CellDoubleClick
        RemoveHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged
    End Sub

    Sub ThucHienGhiPTThayThe()
        Dim intRowCount As Integer = grdPhuTungThayThe.RowCount
        Dim i As Integer = 0

        While i < intRowCount
            If Not IsDBNull(grdPhuTungThayThe.Rows(i).Cells("MS_PT1").Value) And IsDBNull(Me.grdPhuTungThayThe.Rows(i).Cells("SL_TT").Value) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT13", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                Me.grdPhuTungThayThe.CurrentCell() = Me.grdPhuTungThayThe.Rows(i).Cells("SL_TT")
                Me.grdPhuTungThayThe.Focus()
                blnLoiGhiDuLieu = True
                Exit Sub
            End If
            'If Not IsDBNull(grdPhuTungThayThe.Rows(i).Cells("MS_PT1").Value) Then
            '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNgayThayTheNull", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            '    Me.grdPhuTungThayThe.CurrentCell() = Me.grdPhuTungThayThe.Rows(i).Cells("cboNgayTT")
            '    Me.grdPhuTungThayThe.Focus()
            '    blnLoiGhiDuLieu = True
            '    Exit Sub
            'ElseIf IsDBNull(grdPhuTungThayThe.Rows(i).Cells("MS_PT1").Value) And Not IsDBNull(Me.grdPhuTungThayThe.Rows(i).Cells("cboNgayTT").Value) Then
            '    Me.grdPhuTungThayThe.Rows(i).Cells("cboNgayTT").Value = Nothing
            'End If
            i = i + 1
        End While
    End Sub

    Sub ThucHienGhiDiChuyenBoPhan()
        Dim intRowCount As Integer = grdDiChuyenBoPhan.RowCount - 1
        Dim i As Integer = 0

        While i < intRowCount
            If (IsDBNull(grdDiChuyenBoPhan.Rows(i).Cells("MS_MAY_THAY_THE").Value) And Not IsDBNull(grdDiChuyenBoPhan.Rows(i).Cells("cboNguoiChoPhep").Value)) Or (Not IsDBNull(grdDiChuyenBoPhan.Rows(i).Cells("MS_MAY_THAY_THE").Value) And IsDBNull(grdDiChuyenBoPhan.Rows(i).Cells("cboNguoiChoPhep").Value)) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT5", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                blnLoiGhiDuLieu = True
                Exit Sub
                'GoTo loi
            End If

            If grdDiChuyenBoPhan.Rows(i).Cells("DAI_HAN").Value = False And IsDBNull(Me.grdDiChuyenBoPhan.Rows(i).Cells("DEN_NGAY").Value) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT6", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                blnLoiGhiDuLieu = True
                Exit Sub
            End If

            i = i + 1
        End While
    End Sub

    Sub ThucHienGhiDichVuThueNgoai()
        Dim intRowCount As Integer = grdDichVuThueNgoai.RowCount - 1
        Dim i As Integer
        blnLoiGhiDuLieu = False
        While i < intRowCount
            If IsDBNull(grdDichVuThueNgoai.Rows(i).Cells("NOI_DUNG_SERVICE").Value) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT4", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                blnLoiGhiDuLieu = True
                Exit Sub
            End If

            i = i + 1
        End While
    End Sub

    Sub ThucHienGhiThongTinNghiemThu()
        'If cboNguoiNghiemThu.SelectedValue Is Nothing And txtNgayNghiemThu.Text = "  /  /" And txtTinhTrangSauBaoTri.Text = "" Then Exit Sub
        blnLoiGhiDuLieu = False
        If cboNguoiNghiemThu.SelectedValue Is Nothing Then
            'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNguoiNghiemThuNull", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            'cboNguoiNghiemThu.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If
        If txtNgayNghiemThu.Text = "" Or txtNgayNghiemThu.Text = "  /  /" Then
            'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNgayNghiemThuNull", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            'txtNgayNghiemThu.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If
        If txtTinhTrangSauBaoTri.Text = "" Then
            'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgtinhTrangSauBTNull", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            'txtTinhTrangSauBaoTri.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If
        'If cboNguoiNghiemThu.SelectedValue = "" Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT2", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        '    blnLoiGhiDuLieu = True
        '    Exit Sub
        'End If

        'If txtNgayNghiemThu.MaskCompleted = False Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT2", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        '    txtNgayNghiemThu.Focus()
        '    blnLoiGhiDuLieu = True
        '    Exit Sub
        'End If
        If Not IsNumeric(Me.txtChiSoDongHo.Text) And Me.txtChiSoDongHo.Text <> "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChiSoDongHo", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            txtChiSoDongHo.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If

        If Not IsNumeric(Me.txtMovement.Text) And Me.txtMovement.Text <> "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMovement", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            txtMovement.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If

        'If txtTinhTrangSauBaoTri.Text = "" Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT2", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        '    txtTinhTrangSauBaoTri.Focus()
        '    blnLoiGhiDuLieu = True
        '    Exit Sub
        'End If

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePhieuBaoTriNghiemThu", Me.txtMaSoPBT.Text, IIf(IsDBNull(Me.txtTinhTrangSauBaoTri.Text), Nothing, Me.txtTinhTrangSauBaoTri.Text), IIf(IsDBNull(Me.cboNguoiNghiemThu.SelectedValue), Nothing, Me.cboNguoiNghiemThu.SelectedValue), IIf(IsDBNull(Me.txtNgayNghiemThu.Text), Nothing, Me.txtNgayNghiemThu.Text), Commons.Modules.UserName)

        'Try
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTHOI_GIAN_CHAY_MAY", Me.cboMS_ThietBi.SelectedValue, Format(Me.txtNgayNghiemThu.Text, "short date"), txtChiSoDongHo.Text, txtMaSoPBT.Text, txtMovement.Text)
        'Catch ex As Exception
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHOI_GIAN_CHAY_MAY", Me.cboMS_ThietBi.SelectedValue, Format(Me.txtNgayNghiemThu.Text, "short date"), txtChiSoDongHo.Text, txtMaSoPBT.Text, txtMovement.Text)
        'End Try

    End Sub

    Private Sub btnKhongGhi5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi5.Click
        RemoveHandler grdPhuTungThayThe.CellValueChanged, AddressOf Me.grdPhuTungThayThe_CellValueChanged
        RemoveHandler grdPhuTungThayThe.DataSourceChanged, AddressOf Me.grdPhuTungThayThe_DataSourceChanged
        HideButton5(False)
        LockData5(True)
        BtnXacnhanNT.Enabled = True
        intTabChanged = -1
        bThem = -1
        BindData5()

        grdDiChuyenBoPhan.AllowUserToAddRows = False
        grdDichVuThueNgoai.AllowUserToAddRows = False
        RemoveHandler cboNguoiNghiemThu.SelectedIndexChanged, AddressOf Me.cboNguoiNghiemThu_SelectedIndexChanged
        RemoveHandler grdDiChuyenBoPhan.CellDoubleClick, AddressOf Me.grdDiChuyenBoPhan_CellDoubleClick
        Try
            RemoveHandler cb.SelectionChangeCommitted, AddressOf Me.editingComboBox_SelectedIndexChanged
        Catch ex As Exception

        End Try
        Try
            RemoveHandler cbNgoaiTe.SelectionChangeCommitted, AddressOf Me.editingComboBox_SelectedIndexChanged
        Catch ex As Exception

        End Try
        Dim str As String = ""
        Try
            str = "DROP TABLE BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TabPhieuBaoTri_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPhieuBaoTri.SelectedIndexChanged
        If TabPhieuBaoTri.SelectedTab.Name = "tabDichVuThueNgoai" Then
            If dgrNoiDungTrongHopDong_4.RowCount = 0 Then
                btnThemSuaCV_4.Enabled = False
                btnDanhGia.Enabled = False
                btnXoa_4.Enabled = False
                grdDanhGiaDV.DataSource = Nothing
            Else
                btnThemSuaCV_4.Enabled = True
                btnDanhGia.Enabled = True
                btnXoa_4.Enabled = True
            End If
        End If

        If intTabChanged = -1 Then Exit Sub
        TabPhieuBaoTri.SelectTab(intTabChanged)
    End Sub

    Private Sub LoadNgayBatDauBaoTri(ByVal MS_PBT As String)
        Dim dtReader As SqlDataReader
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNgayBatDauPBT", MS_PBT)
        While dtReader.Read
            txtNgayBatDau.Text = dtReader.Item(0)
        End While
        dtReader.Close()
    End Sub

    Private Sub LoadNgayKetThucBaoTri(ByVal MS_PBT As String, ByVal TINH_TRANG_PBT As Integer)
        Dim dtReader As SqlDataReader
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNgayKetThucPBT", MS_PBT, TINH_TRANG_PBT)
        While dtReader.Read
            txtNgayKetThuc.Text = dtReader.Item(0)
        End While
        dtReader.Close()
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
        If Commons.Modules.TypeLanguage = 1 Then ' Tiếng Việt 
            txtTongGioCong.Text = intSoGio & " Giờ " & intSoPhut & " Phút"
        ElseIf Commons.Modules.TypeLanguage = 2 Then ' Tiếng Anh
            txtTongGioCong.Text = intSoGio & " Hour " & intSoPhut & " Minute"
        Else ' Tiếng Hoa
            txtTongGioCong.Text = intSoGio & " Giờ " & intSoPhut & " Phút"
        End If
        dtReader.Close()
    End Sub

    Private Sub cboNgayNghiemThu_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNgayNghiemThu.CloseUp
        If btnGhi5.Visible Then
            txtNgayNghiemThu.Text = Format(cboNgayNghiemThu.Value, "Short date")
            txtNgayNghiemThu.Focus()
        End If
    End Sub

    Private Sub RefreshData5()
        txtNgayBatDau.Text = ""
        txtNgayKetThuc.Text = ""
        txtTongGioCong.Text = ""
        txtUserName.Text = ""
        txtNgayNghiemThu.Text = ""
        cboNgayNghiemThu.Text = ""
        cboNguoiNghiemThu.SelectedIndex = -1
        txtChiSoDongHo.Text = ""
        txtMovement.Text = ""
        txtTinhTrangSauBaoTri.Text = ""
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
        BindBoPhanChiuPhi(Me.txtMaSoPBT.Text)
        LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
        LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)

        BindDataThongTinNghiemThu(Me.txtMaSoPBT.Text)
        BindDataThongTinChiPhi(Me.txtMaSoPBT.Text)
        BindDataDichVuThueNgoai()
        BindDataDiChuyenBP()
        BindDataPTThayThe()

    End Sub
    Sub BindBoPhanChiuPhi(ByVal vMS_PBT As String)

        cboBPCP.Display = "TEN_BP_CHIU_PHI"
        cboBPCP.Value = "MS_BP_CHIU_PHI"
        cboBPCP.StoreName = "GetBO_PHAN_CHIU_PHIs"
        cboBPCP.Param = Commons.Modules.UserName
        cboBPCP.BindDataSource()

        cboHeThong.Display = "TEN_HE_THONG"
        cboHeThong.Value = "MS_HE_THONG"
        cboHeThong.StoreName = "H_getHeThong"
        cboHeThong.Param = Commons.Modules.UserName
        cboHeThong.BindDataSource()

        cboNhaXuong.Display = "TEN_N_XUONG"
        cboNhaXuong.Value = "MS_N_XUONG"
        cboNhaXuong.StoreName = "GetNHA_XUONGs"
        cboNhaXuong.Param = Commons.Modules.UserName
        cboNhaXuong.BindDataSource()

    End Sub

    Dim rowCount As Integer = 0
    Sub BindDataDiChuyenBP()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhieuBaoTriDiChuyenBP", Me.txtMaSoPBT.Text))
        Try
            grdDiChuyenBoPhan.Columns.Clear()
        Catch ex As Exception

        End Try

        Dim priCol(2) As DataColumn
        priCol(0) = dtTable.Columns("MS_BO_PHAN")
        priCol(1) = dtTable.Columns("MS_MAY_THAY_THE")
        priCol(2) = dtTable.Columns("MS_BO_PHAN_THAY_THE")
        dtTable.PrimaryKey = priCol
        grdDiChuyenBoPhan.DataSource = dtTable
        rowCount = dtTable.Rows.Count - 1
        grdDiChuyenBoPhan.Columns("MS_BO_PHAN").Visible = False
        grdDiChuyenBoPhan.Columns("MS_BO_PHAN_THAY_THE").Visible = False
        grdDiChuyenBoPhan.Columns("NGUOI_CHO_PHEP").Visible = False
        grdDiChuyenBoPhan.Columns("NGAY_THAY").Visible = False
        grdDiChuyenBoPhan.Columns("DEN_NGAY").Visible = False
        'grdDiChuyenBoPhan.Columns("NGAY_TRA_TT").Visible = False

        Dim cboNgayThay As New CalendarColumn
        cboNgayThay.Name = "cboNgayThay"
        cboNgayThay.DataPropertyName = "NGAY_THAY"
        grdDiChuyenBoPhan.Columns.Insert(0, cboNgayThay)

        'dtTable.Clear()
        dtTable = New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs"))
        Dim cboNguoiChoPhep As New DataGridViewComboBoxColumn
        cboNguoiChoPhep.Name = "cboNguoiChoPhep"
        cboNguoiChoPhep.DataPropertyName = "NGUOI_CHO_PHEP"
        cboNguoiChoPhep.DataSource = dtTable
        cboNguoiChoPhep.ValueMember = "MS_CONG_NHAN"
        cboNguoiChoPhep.DisplayMember = "HO_TEN_CONG_NHAN"
        grdDiChuyenBoPhan.Columns.Insert(1, cboNguoiChoPhep)

        Dim txtDenNgay As New Commons.QLGridMaskedTextBoxColumn
        txtDenNgay.Name = "txtDenNgay"
        txtDenNgay.Mask = "00/00/0000"
        txtDenNgay.DataPropertyName = "DEN_NGAY"
        grdDiChuyenBoPhan.Columns.Insert(9, txtDenNgay)

        'Dim txtNgayTraTT As New Commons.QLGridMaskedTextBoxColumn
        'txtNgayTraTT.Name = "txtNgayTraTT"
        'txtNgayTraTT.Mask = "00/00/0000"
        'txtNgayTraTT.DataPropertyName = "NGAY_TRA_TT"
        'grdDiChuyenBoPhan.Columns.Insert(10, txtNgayTraTT)

        Try
            grdDiChuyenBoPhan.Rows(0).Cells("cboNgayThay").Selected = True
        Catch ex As Exception

        End Try

        Try
            With grdDiChuyenBoPhan
                .Columns("cboNgayThay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboNgayThay", Commons.Modules.TypeLanguage)
                .Columns("cboNguoiChoPhep").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboNguoiChoPhep", Commons.Modules.TypeLanguage)
                .Columns("MS_MAY_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("MS_BO_PHAN_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("TEN_BO_PHAN_THAY_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
                .Columns("DAI_HAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAI_HAN", Commons.Modules.TypeLanguage)
                .Columns("txtDenNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "txtDenNgay", Commons.Modules.TypeLanguage)
                .Columns("NGAY_TRA_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_TRA_TT", Commons.Modules.TypeLanguage)
            End With
        Catch ex As Exception

        End Try
        Try
            Me.grdDiChuyenBoPhan.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDiChuyenBoPhan.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
    End Sub

    Sub BindDataDichVuThueNgoai()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDichVuThueNgoai", Me.txtMaSoPBT.Text))
        grdDichVuThueNgoai.Columns.Clear()
        grdDichVuThueNgoai.DataSource = dtTable
        grdDichVuThueNgoai.Columns("STT").Visible = False
        grdDichVuThueNgoai.Columns("NGAY_HOAN_THANH").Visible = False
        grdDichVuThueNgoai.Columns("BAO_HANH_DEN").Visible = False
        grdDichVuThueNgoai.Columns("NOI_DUNG_SERVICE").Width = 150

        Dim cboNgayHoanThanh As New Commons.QLGridMaskedTextBoxColumn 'CalendarColumn
        cboNgayHoanThanh.Name = "cbongayhoanthanh"
        cboNgayHoanThanh.DataPropertyName = "NGAY_HOAN_THANH"
        cboNgayHoanThanh.Mask = "00/00/0000"
        grdDichVuThueNgoai.Columns.Insert(2, cboNgayHoanThanh)

        Dim cboBaoHanhDen As New Commons.QLGridMaskedTextBoxColumn ' CalendarColumn
        cboBaoHanhDen.Name = "cboBaoHanhDen"
        cboBaoHanhDen.Mask = "00/00/0000"
        cboBaoHanhDen.DataPropertyName = "BAO_HANH_DEN"
        grdDichVuThueNgoai.Columns.Insert(3, cboBaoHanhDen)

        Try
            grdDichVuThueNgoai.Rows(0).Cells("NOI_DUNG_SERVICE").Selected = True
        Catch ex As Exception

        End Try

        Try
            With grdDichVuThueNgoai
                .Columns("NOI_DUNG_SERVICE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_DUNG_SERVICE", Commons.Modules.TypeLanguage)
                .Columns("NOI_DUNG_SERVICE").Width = 150
                .Columns("cboNgayHoanThanh").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboNgayHoanThanh", Commons.Modules.TypeLanguage)
                .Columns("cboBaoHanhDen").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboBaoHanhDen", Commons.Modules.TypeLanguage)
                .Columns("DIEM").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DIEM", Commons.Modules.TypeLanguage)
                .Columns("DIEM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("NOI_DUNG_DANH_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_DUNG_DANH_GIA", Commons.Modules.TypeLanguage)
                .Columns("NOI_DUNG_DANH_GIA").Width = 150
                .Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
                .Columns("GHI_CHU").Width = 250
            End With
        Catch ex As Exception

        End Try

        Try
            Me.grdDichVuThueNgoai.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDichVuThueNgoai.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
    End Sub

    Sub BindDataPTThayThe()
        Dim dtTable As New DataTable
        'LẤY MS LOẠI VẬT TƯ RA ĐỂ TÍNH CHI PHÍ LOẠI VẬT TƯ  HAY LÀ PHỤ TÙNG TUỲ THEO CÁC ITEM
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPTThayThe", Me.txtMaSoPBT.Text))
        grdPhuTungThayThe.Columns.Clear()
        grdPhuTungThayThe.DataSource = dtTable
        grdPhuTungThayThe.Columns("MS_BO_PHAN").Visible = False



        grdPhuTungThayThe.Columns("MS_PT").ReadOnly = True
        grdPhuTungThayThe.Columns("MS_CV").Visible = False
        grdPhuTungThayThe.Columns("MS_VI_TRI_PT").ReadOnly = True
        grdPhuTungThayThe.Columns("MS_BO_PHAN").ReadOnly = True
        grdPhuTungThayThe.Columns("NGUOI_THAY_THE").Visible = False
        grdPhuTungThayThe.Columns("SL_KH").ReadOnly = True
        grdPhuTungThayThe.Columns("MS_DH_NHAP_PT").Visible = False
        'grdPhuTungThayThe.Columns("STT").Visible = False
        grdPhuTungThayThe.Columns("NGOAI_TE").Visible = False
        grdPhuTungThayThe.Columns("DON_GIA").DefaultCellStyle.Format = "#,##0"
        grdPhuTungThayThe.Columns("VICT_NHA_THAU").Visible = False
        grdPhuTungThayThe.Columns("NGAY_THAY_THE").Visible = False
        grdPhuTungThayThe.Columns("TEN_PT").ReadOnly = True

        Dim cboNguoiThayThe As New DataGridViewComboBoxColumn
        dtTable = New DataTable
        Dim str As String = ""
        dtTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCongNhanThayThePT", txtMaSoPBT.Text).Tables(0)
        cboNguoiThayThe.Name = "cboNguoiThayThe"
        cboNguoiThayThe.DataPropertyName = "NGUOI_THAY_THE"
        cboNguoiThayThe.DisplayMember = "HO_TEN_CONG_NHAN"
        cboNguoiThayThe.ValueMember = "MS_CONG_NHAN"
        cboNguoiThayThe.DataSource = dtTable
        grdPhuTungThayThe.Columns.Insert(8, cboNguoiThayThe)

        Dim cboMSDHNhap As New DataGridViewComboBoxColumn
        dtTable = New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhieuNhap", Me.txtMaSoPBT.Text))
        cboMSDHNhap.Name = "cboMSDHNhap"
        cboMSDHNhap.DataPropertyName = "MS_DH_NHAP_PT"
        cboMSDHNhap.DisplayMember = "DH_NHAP_PT"
        cboMSDHNhap.ValueMember = "MS_DH_NHAP_PT"
        cboMSDHNhap.DataSource = dtTable
        cboMSDHNhap.Width = 110
        cboMSDHNhap.DropDownWidth = 200
        grdPhuTungThayThe.Columns.Insert(9, cboMSDHNhap)

        Dim cboNgoaiTe As New DataGridViewComboBoxColumn
        dtTable = New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "QL_LOAD_LIST_NGOAI_TE"))
        cboNgoaiTe.Name = "cboNgoaiTe"
        cboNgoaiTe.DataPropertyName = "NGOAI_TE"
        cboNgoaiTe.DisplayMember = "TEN_NGOAI_TE"
        cboNgoaiTe.ValueMember = "NGOAI_TE"
        cboNgoaiTe.DataSource = dtTable
        cboNgoaiTe.DropDownWidth = 150
        grdPhuTungThayThe.Columns.Insert(14, cboNgoaiTe)

        Dim Dtt As New DataTable()
        Dtt = CType(grdPhuTungThayThe.DataSource, DataTable).Copy()
        Try
            With grdPhuTungThayThe
                .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
                .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
                .Columns("TEN_PT").Width = 200
                .Columns("MS_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN", Commons.Modules.TypeLanguage)
                .Columns("MS_VI_TRI_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
                .Columns("SL_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TT", Commons.Modules.TypeLanguage)
                .Columns("SL_TT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("cboMSDHNhap").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboMSDHNhap", Commons.Modules.TypeLanguage)
                .Columns("cboMSDHNhap").Width = 150
                .Columns("MS_PT1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT1", Commons.Modules.TypeLanguage)
                .Columns("DON_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA", Commons.Modules.TypeLanguage)
                .Columns("DON_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("cboNgoaiTe").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGOAI_TE", Commons.Modules.TypeLanguage)
                .Columns("TY_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA", Commons.Modules.TypeLanguage)
                .Columns("TY_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TY_GIA_USD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA_USD", Commons.Modules.TypeLanguage)
                .Columns("TY_GIA_USD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TY_GIA_USD").DefaultCellStyle.Format = "N6"
                .Columns("BAO_HANH_DEN_NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BAO_HANH_DEN_NGAY", Commons.Modules.TypeLanguage)
                .Columns("BAO_HANH_DEN_NGAY").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("XUAT_XU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XUAT_XU", Commons.Modules.TypeLanguage)
                .Columns("XUAT_XU").Width = 150
                .Columns("cboNguoiThayThe").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_THAY_THE", Commons.Modules.TypeLanguage)
                .Columns("cboNguoiThayThe").Width = 150
                .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
                .Columns("STT").Visible = False
            End With
        Catch ex As Exception

        End Try

        Try
            Me.grdPhuTungThayThe.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdPhuTungThayThe.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try

        Try
            grdPhuTungThayThe.Rows(0).Cells("MS_PT").Selected = True
        Catch ex As Exception

        End Try
        Dim Dt As New DataTable()
        Dt = CType(grdPhuTungThayThe.DataSource, DataTable).Copy()


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
            'If IsDBNull(dtReader.Item("CHI_PHI_KHAC")) Then txtChiPhiKhacMacDinh.Text = 0 Else txtChiPhiKhacMacDinh.Text = Format(dtReader.Item("CHI_PHI_KHAC"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_KHAC_USD")) Then txtChiPhiKhacUSD.Text = 0 Else txtChiPhiKhacUSD.Text = Format(dtReader.Item("CHI_PHI_KHAC_USD"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_NHAN_CONG")) Then txtChiPhiNhanCongMacDinh.Text = 0 Else txtChiPhiNhanCongMacDinh.Text = Format(dtReader.Item("CHI_PHI_NHAN_CONG"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_NHAN_CONG_USD")) Then txtChiPhiNhanCongUSD.Text = 0 Else txtChiPhiNhanCongUSD.Text = Format(dtReader.Item("CHI_PHI_NHAN_CONG_USD"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_PHU_TUNG")) Then txtChiPhiPhuTungMacDinh.Text = 0 Else txtChiPhiKhacMacDinh.Text = Format(dtReader.Item("CHI_PHI_PHU_TUNG"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_DV")) Then txtChiPhiThueNgoaiMacDinh.Text = 0 Else txtChiPhiThueNgoaiMacDinh.Text = Format(dtReader.Item("CHI_PHI_DV"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_DV_USD")) Then txtChiPhiThueNgoaiUSD.Text = 0 Else txtChiPhiThueNgoaiUSD.Text = Format(dtReader.Item("CHI_PHI_DV_USD"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_VAT_TU")) Then txtChiPhiVatTuMacDinh.Text = 0 Else txtChiPhiVatTuMacDinh.Text = Format(dtReader.Item("CHI_PHI_VAT_TU"), "0")
            'If IsDBNull(dtReader.Item("CHI_PHI_VAT_TU_USD")) Then txtChiPhiVatTuUSD.Text = 0 Else txtChiPhiVatTuUSD.Text = Format(dtReader.Item("CHI_PHI_VAT_TU_USD"), "0")

            If IsDBNull(dtReader.Item("CHI_PHI_PHU_TUNG")) Then txtChiPhiPhuTungMacDinh.Text = 0 Else txtChiPhiPhuTungMacDinh.Text = Format(dtReader.Item("CHI_PHI_PHU_TUNG"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_PHU_TUNG_USD")) Then txtChiPhiPhuTungUSD.Text = 0 Else txtChiPhiPhuTungUSD.Text = Format(dtReader.Item("CHI_PHI_PHU_TUNG_USD"), "N2")

            If IsDBNull(dtReader.Item("CHI_PHI_VAT_TU")) Then txtChiPhiVatTuMacDinh.Text = 0 Else txtChiPhiVatTuMacDinh.Text = Format(dtReader.Item("CHI_PHI_VAT_TU"), "N0")
            If IsDBNull(dtReader.Item("CHI_PHI_VAT_TU_USD")) Then txtChiPhiVatTuUSD.Text = 0 Else txtChiPhiVatTuUSD.Text = Format(dtReader.Item("CHI_PHI_VAT_TU_USD"), "N2")

            If IsDBNull(dtReader.Item("CHI_PHI_NHAN_CONG")) Then txtChiPhiNhanCongMacDinh.Text = 0 Else txtChiPhiNhanCongMacDinh.Text = Format(dtReader.Item("CHI_PHI_NHAN_CONG"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_NHAN_CONG_USD")) Then txtChiPhiNhanCongUSD.Text = 0 Else txtChiPhiNhanCongUSD.Text = Format(dtReader.Item("CHI_PHI_NHAN_CONG_USD"), "N2")

            If IsDBNull(dtReader.Item("CHI_PHI_DV")) Then txtChiPhiThueNgoaiMacDinh.Text = 0 Else txtChiPhiThueNgoaiMacDinh.Text = Format(dtReader.Item("CHI_PHI_DV"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_DV_USD")) Then txtChiPhiThueNgoaiUSD.Text = 0 Else txtChiPhiThueNgoaiUSD.Text = Format(dtReader.Item("CHI_PHI_DV_USD"), "N2")

            If IsDBNull(dtReader.Item("CHI_PHI_KHAC")) Then txtChiPhiKhacMacDinh.Text = 0 Else txtChiPhiKhacMacDinh.Text = Format(dtReader.Item("CHI_PHI_KHAC"), "0")
            If IsDBNull(dtReader.Item("CHI_PHI_KHAC_USD")) Then txtChiPhiKhacUSD.Text = 0 Else txtChiPhiKhacUSD.Text = Format(dtReader.Item("CHI_PHI_KHAC_USD"), "N2")
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
                    Return Format(Val(Replace$(str, ",", "")), "N0").ToString
                Else
                    Return Format(Val(Replace$(str, ",", "")), "N2").ToString
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
            txtChiSoDongHo.Text = IIf(IsDBNull(dtReader.Item("CHI_SO_DONG_HO")), Nothing, dtReader.Item("CHI_SO_DONG_HO"))
            txtMovement.Text = IIf(IsDBNull(dtReader.Item("SO_MOVEMENT")), Nothing, dtReader.Item("SO_MOVEMENT"))

            If IsDBNull(dtReader.Item("MS_BP_CHIU_PHI")) Then
                cboBPCP.SelectedIndex = -1
            Else
                cboBPCP.SelectedValue = dtReader.Item("MS_BP_CHIU_PHI")
            End If

            If IsDBNull(dtReader.Item("MS_HE_THONG")) Then
                cboHeThong.SelectedIndex = -1
                cboHeThong.SelectedText = ""
            Else
                cboHeThong.SelectedValue = dtReader.Item("MS_HE_THONG")
            End If

            If IsDBNull(dtReader.Item("MS_N_XUONG")) Then
                cboNhaXuong.SelectedIndex = -1
                cboNhaXuong.SelectedText = ""
            Else
                cboNhaXuong.SelectedValue = dtReader.Item("MS_N_XUONG")
            End If

        End While
        dtReader.Close()
    End Sub

    Private Sub cboNguoiNghiemThu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtUserName.Text = Commons.Modules.UserName
    End Sub

    Private Sub grdDichVuThueNgoai_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDichVuThueNgoai.CellValidating
        If btnKhongGhi5.Focused() Then
            Exit Sub
        End If
        If btnGhi5.Visible Then
            If grdDichVuThueNgoai.Columns(e.ColumnIndex).Name = "cbongayhoanthanh" Then
                If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                    If Not IsDate(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHoanThanh", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        grdDichVuThueNgoai.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        grdDichVuThueNgoai.Focus()
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            ElseIf grdDichVuThueNgoai.Columns(e.ColumnIndex).Name = "cboBaoHanhDen" Then
                If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                    If Not IsDate(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgBaoHanhDen", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        grdDichVuThueNgoai.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        grdDichVuThueNgoai.Focus()
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdDichVuThueNgoai_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDichVuThueNgoai.DataError
        Select Case e.Context
            Case 768, 2816 'Lỗi kiểu dữ liệu 
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT3", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                'Case 512 ' Lỗi dữ liệu rỗng 
                'e.Empty.ToString()
        End Select
    End Sub

    'Private Sub grdDichVuThueNgoai_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdDichVuThueNgoai.DefaultValuesNeeded
    'With e.Row
    '    .Cells("cboNgayHoanThanh").Value = DateTime.Now
    '    .Cells("cboBaoHanhDen").Value = DateTime.Now
    'End With
    'End Sub

    Private Sub cmdChonBoPhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChonBoPhan.Click
        If IsDBNull(grdDiChuyenBoPhan.Rows(IIf(intCurrentRowDCBP = -1, 0, intCurrentRowDCBP)).Cells("cboNguoiChoPhep").Value) Or grdDiChuyenBoPhan.Rows(IIf(intCurrentRowDCBP = -1, 0, intCurrentRowDCBP)).Cells("cboNguoiChoPhep").Value Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT7", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        If intCurrentRowDCBP = -1 Then
            FrmChonBoPhanThayThe.intRowInd = 0
        Else
            FrmChonBoPhanThayThe.intRowInd = intCurrentRowDCBP
        End If

        FrmChonBoPhanThayThe.MS_MAY = cboMS_ThietBi.SelectedValue
        FrmChonBoPhanThayThe.ShowDialog()
    End Sub

    Private Sub grdDiChuyenBoPhan_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            If e.ColumnIndex = 1 Or e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then
                If grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("NGAY_TRA_TT").Value.ToString = "" Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim str As String = ""
                    str = "Delete FROM  BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName & " where TON_TAI<>1"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    For i As Integer = 0 To grdDiChuyenBoPhan.Rows.Count - 2
                        If grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN").Value.ToString <> "" And i <> e.RowIndex Then
                            If grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("NGAY_TRA_TT").Value.ToString = "" Then
                                str = "Insert into BO_PHAN_DI_CHUYEN_TMP" & Commons.Modules.UserName & " values(N'" & grdDiChuyenBoPhan.Rows(i).Cells("MS_MAY_THAY_THE").Value & "',N'" & grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN_THAY_THE").Value & "',N'" & cboMS_ThietBi.SelectedValue & "',N'" & grdDiChuyenBoPhan.Rows(i).Cells("MS_BO_PHAN").Value & "',2)"
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            End If
                        End If
                    Next
                    FrmChonBoPhanThayThe.intRowInd = e.RowIndex
                    FrmChonBoPhanThayThe.MS_MAY = cboMS_ThietBi.SelectedValue
                    If grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_MAY_THAY_THE").Value.ToString <> "" Then
                        FrmChonBoPhanThayThe.MS_MAY_THAY_THE = grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_MAY_THAY_THE").Value
                        FrmChonBoPhanThayThe.MS_BO_PHAN = grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value
                        FrmChonBoPhanThayThe.MS_BO_PHAN_THAY_THE = grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_BO_PHAN_THAY_THE").Value
                    End If
                    FrmChonBoPhanThayThe.ShowDialog()
                    Me.Cursor = Cursors.Default
                Else
                    'XtraMessageBox.Show("bộ phận này đã có ngày trả thực tế nên không thể thay đổi")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayTraTT", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDiChuyenBoPhan_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDiChuyenBoPhan.DataError
        'MsgBox(e.Exception.ToString)
        If btnKhongGhi5.Focused() Then
            Exit Sub
        End If
        If grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_MAY_THAY_THE").Value.ToString = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT5", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            e.Cancel = True
            Exit Sub
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungKhoaChinh", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        'If e.Context = 512 Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT5", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub grdDiChuyenBoPhan_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdDiChuyenBoPhan.DefaultValuesNeeded
        With e.Row
            .Cells("cboNgayThay").Value = DateTime.Now
            .Cells("DAI_HAN").Value = False
        End With
    End Sub

    Private Sub btnXoa5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa5.Click
        Dim str As String = ""
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If cboTinhTrangPBT.SelectedValue = 3 Then
            'hỏi có muốn xóa thông tin nghiệm thu không, nếu có thì cập nhật null cho người nghiệm thu
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                cboTinhTrangPBT.SelectedValue = 2
                str = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        bThem = 5
        BindData5()
        HideXoa5(True)
        BtnXoaDVTN.Visible = False
        btnXoaDCBP.Visible = False
    End Sub

    Sub HideXoa5(ByVal An As Boolean)
        btnSua5.Visible = Not An
        btnXoa5.Visible = Not An
        btnThoat5.Visible = Not An
        btnGhi5.Visible = Not An
        btnKhongGhi5.Visible = Not An
        cmdChonBoPhan.Visible = False
        BtnLockPBT.Visible = Not An
        BtnXacnhanNT.Visible = Not An
        btnXoaDCBP.Visible = An
        BtnXoaDVTN.Visible = An
        btnXoaPTTT.Visible = An
        btnXoaTTNT.Visible = An
        btnTroVe5.Visible = An
    End Sub

    Private Sub btnTroVe5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTroVe5.Click
        HideXoa5(False)
        bThem = -1
        BtnXacnhanNT.Enabled = True
    End Sub

    Private Sub btnXoaTTNT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaTTNT.Click
        'If blnUserCN = False Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKT8", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        '    Exit Sub
        'End If
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT9", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Thông báo") = vbNo Then Exit Sub

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_TTNT", Me.txtMaSoPBT.Text)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CHI_PHI WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'")
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePBT_THOI_GIAN_CHAY_MAY", Me.cboMS_ThietBi.SelectedValue, Format(Me.txtNgayNghiemThu.Text, "short date"))
        Catch ex As Exception

        End Try
        BindData5()
        'QuyenUser()
        LoadNgayBatDauBaoTri(Me.txtMaSoPBT.Text)
        LoadNgayKetThucBaoTri(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        LoadTongGioCong(Me.txtMaSoPBT.Text, Me.cboTinhTrangPBT.SelectedValue)
        'end tab 5
        'End If
        If cboTinhTrangPBT.SelectedValue = 4 Or (radPhieuBaoTriDaNghiemThu_1.Checked And bCoQuyen = False) Then
            EnableButton5(False)
        Else
            EnableButton5(True)
            If cboTinhTrangPBT.SelectedValue = 3 Then
                BtnXacnhanNT.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnXoaDVTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaDVTN.Click
        If grdDichVuThueNgoai.RowCount <= 0 Then Exit Sub
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT10", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Thông báo") = vbNo Then Exit Sub

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePBT_DichVuThueNgoai", Me.grdDichVuThueNgoai.CurrentRow.Cells("stt").Value)

        BindDataDichVuThueNgoai()

    End Sub

    Private Sub btnXoaDCBP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaDCBP.Click
        If grdDiChuyenBoPhan.RowCount <= 0 Then Exit Sub
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT11", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Thông báo") = vbNo Then Exit Sub

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePBT_PhieuBaoTriDiChuyenBP", Me.txtMaSoPBT.Text, grdDiChuyenBoPhan.CurrentRow.Cells("MS_BO_PHAN").Value, grdDiChuyenBoPhan.CurrentRow.Cells("MS_MAY_THAY_THE").Value, grdDiChuyenBoPhan.CurrentRow.Cells("MS_BO_PHAN_THAY_THE").Value)

        grdDiChuyenBoPhan.Rows.RemoveAt(Me.grdDiChuyenBoPhan.CurrentRow.Index)
    End Sub

    Private Sub btnThoat5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat5.Click
        Me.Close()
    End Sub

    Private Sub grdPhuTungThayThe_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdPhuTungThayThe.CellBeginEdit
        If grdPhuTungThayThe.Columns(e.ColumnIndex).Name = "cboMSDHNhap" Then
            Dim tb As New DataTable()
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPhieuNhapTheoPT", Me.txtMaSoPBT.Text, grdPhuTungThayThe.Rows(e.RowIndex).Cells("MS_PT").Value).Tables(0)
            Dim dr As DataRow
            dr = tb.NewRow
            dr.Item("MS_DH_NHAP_PT") = System.DBNull.Value
            tb.Rows.InsertAt(dr, 0)
            If tb.Rows.Count > 0 Then
                grdPhuTungThayThe.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = tb.Rows(0).Item(0)
                Dim cell1 As New DataGridViewComboBoxCell()
                cell1.DataSource = tb
                cell1.DisplayMember = "DH_NHAP_PT"
                cell1.ValueMember = "MS_DH_NHAP_PT"
                cell1.DropDownWidth = 200
                grdPhuTungThayThe.Rows(e.RowIndex).Cells("cboMSDHNhap").DataGridView("cboMSDHNhap", e.RowIndex) = cell1
            End If
        End If
    End Sub

    Private Sub grdPhuTungThayThe_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdPhuTungThayThe.CellValidating
        If btnKhongGhi5.Focused() Then
            Exit Sub
        End If
        If btnGhi5.Visible Then
            If grdPhuTungThayThe.Columns(e.ColumnIndex).Name = "SL_TT" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then 'And e.FormattedValue <> ""
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT12", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
                        e.Cancel = True
                        Exit Sub
                    Else
                        'If e.FormattedValue > grdPhuTungThayThe.Rows(e.RowIndex).Cells("SL_KH").Value Then
                        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSLTTLonHonSLKH", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
                        '    e.Cancel = True
                        '    Exit Sub
                        'End If
                    End If
                End If
            ElseIf e.ColumnIndex = 0 Then
                grdPhuTungThayThe.CurrentRow.Cells(0).Value = e.FormattedValue
            ElseIf grdPhuTungThayThe.Columns(e.ColumnIndex).Name = "cboNguoiThayThe" Then
                'If grdPhuTungThayThe.Rows(e.RowIndex).Cells("MS_PT1").Value.ToString <> "" Then
                '    If e.FormattedValue = "" Then
                '        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNguoiThayThe", commons.Modules.TypeLanguage), MsgBoxStyle.Critical + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                '            e.Cancel = True
                '            Exit Sub
                '        End If
                '    End If
                'End If
            ElseIf grdPhuTungThayThe.Columns(e.ColumnIndex).Name = "cboNgayTT" Then
                If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                    If e.FormattedValue.ToString().Length < 10 Or Not IsDate(e.FormattedValue) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayThayThe", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
                        grdPhuTungThayThe.CurrentCell().Selected = True
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            ElseIf grdPhuTungThayThe.Columns(e.ColumnIndex).Name = "DON_GIA" Or grdPhuTungThayThe.Columns(e.ColumnIndex).Name = "TY_GIA" Or grdPhuTungThayThe.Columns(e.ColumnIndex).Name = "TY_GIA_USD" Then
                If Not IsNumeric(e.FormattedValue) And e.FormattedValue <> "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT12", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "Thông báo ")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Dim cbNgoaiTe As System.Windows.Forms.ComboBox
    Dim autoCompleteSource As New AutoCompleteStringCollection()

    Private Sub grdPhuTungThayThe_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles grdPhuTungThayThe.CellValueChanged
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            If dgv.Columns(e.ColumnIndex).Name = "cboMSDHNhap" Then
                Dim val As String = dgv(e.ColumnIndex, e.RowIndex).Value
                If Not String.IsNullOrEmpty(val) AndAlso
                     Not Me.autoCompleteSource.Contains(val) Then
                    autoCompleteSource.Add(val)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdPhuTungThayThe_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles grdPhuTungThayThe.DataSourceChanged
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            Me.autoCompleteSource.Clear()
            Dim r As DataGridViewRow
            If dgv.CurrentCell.OwningColumn.Name = "cboMSDHNhap" Then
                For Each r In dgv.Rows
                    Dim val As String = r.Cells("cboMSDHNhap").Value
                    If Not String.IsNullOrEmpty(val) AndAlso
                        Not Me.autoCompleteSource.Contains(val) Then
                        autoCompleteSource.Add(val)
                    End If
                Next r

            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim txt As TextBox()

    Private Sub grdPhuTungThayThe_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdPhuTungThayThe.DataError

    End Sub
    Private Sub grdPhuTungThayThe_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdPhuTungThayThe.EditingControlShowing
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            If TypeOf e.Control Is System.Windows.Forms.ComboBox Then
                Dim tb As System.Windows.Forms.ComboBox = CType(e.Control, System.Windows.Forms.ComboBox)
                If dgv.CurrentCell.OwningColumn.Name = "cboMSDHNhap" Then
                    cb = e.Control

                    Try
                        RemoveHandler cbNgoaiTe.SelectionChangeCommitted, AddressOf Me.cbNgoaiTe_SelectedIndexChanged
                    Catch ex As Exception

                    End Try
                    RemoveHandler cb.SelectionChangeCommitted, AddressOf Me.editingComboBox_SelectedIndexChanged
                    AddHandler cb.SelectionChangeCommitted, AddressOf Me.editingComboBox_SelectedIndexChanged
                    'tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    'tb.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
                    'tb.AutoCompleteCustomSource = Me.autoCompleteSource
                ElseIf dgv.CurrentCell.OwningColumn.Name = "cboNgoaiTe" Then
                    'If Not IsDBNull(Me.grdPhuTungThayThe.CurrentRow.Cells("cboMSDHNhap").Value) Then Exit Sub
                    cbNgoaiTe = e.Control
                    Try
                        RemoveHandler cb.SelectionChangeCommitted, AddressOf Me.editingComboBox_SelectedIndexChanged
                    Catch ex As Exception
                    End Try
                    RemoveHandler cbNgoaiTe.SelectionChangeCommitted, AddressOf Me.cbNgoaiTe_SelectedIndexChanged
                    AddHandler cbNgoaiTe.SelectionChangeCommitted, AddressOf Me.cbNgoaiTe_SelectedIndexChanged
                Else
                    RemoveHandler cbNgoaiTe.SelectionChangeCommitted, AddressOf Me.cbNgoaiTe_SelectedIndexChanged
                    RemoveHandler cb.SelectionChangeCommitted, AddressOf Me.editingComboBox_SelectedIndexChanged
                End If
            ElseIf TypeOf e.Control Is TextBox Then
                If dgv.CurrentCell.OwningColumn.Name = "DON_GIA" Or dgv.CurrentCell.OwningColumn.Name = "TY_GIA" Or dgv.CurrentCell.OwningColumn.Name = "DON_GIA_USD" Then
                    txtBaoTri = e.Control

                    RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                    AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                Else
                    RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbNgoaiTe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(cbNgoaiTe.Text) Then Exit Sub
        If cbNgoaiTe.Text = "" Then Exit Sub
        Try
            Me.grdPhuTungThayThe.CurrentRow.Cells("cboNgoaiTe").Value = cbNgoaiTe.SelectedValue
            Dim objDonHangNhapPTController As New IC_DON_HANG_NHAP_Controller
            Me.grdPhuTungThayThe.CurrentRow.Cells("TY_GIA").Value = objDonHangNhapPTController.Load_Ty_Gia_Theo_Ngoai_Te(cbNgoaiTe.SelectedValue)

            Me.grdPhuTungThayThe.CurrentRow.Cells("TY_GIA_USD").Value = objDonHangNhapPTController.Load_Ty_Gia_USD_Theo_Ngoai_Te(cbNgoaiTe.SelectedValue)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub editingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strTam, strPT() As String
        Dim dtReader As SqlDataReader
        If IsDBNull(cb.Text) Then Exit Sub
        If cb.Text = "" Then Exit Sub
        strTam = cb.Text
        strPT = strTam.Split("-")
        Try

            Me.grdPhuTungThayThe.CurrentRow.Cells("cboMSDHNhap").Value = cb.SelectedValue
            Me.grdPhuTungThayThe.CurrentRow.Cells("MS_PT1").Value = Trim(strPT(2))
            'commons.Modules.SQLString = "SELECT SL_THUC_NHAP,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD,BAO_HANH_DEN_NGAY,XUAT_XU FROM IC_DON_HANG_NHAP_VAT_TU WHERE MS_PT='" & Trim(strPT(2)) & "' AND MS_DH_NHAP_PT='" & cb.SelectedValue & "'"

            Commons.Modules.SQLString = "SELECT dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA, dbo.IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE, dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA, dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA_USD, dbo.IC_DON_HANG_NHAP_VAT_TU.BAO_HANH_DEN_NGAY, " &
                            "dbo.IC_DON_HANG_NHAP_VAT_TU.XUAT_XU, dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT " &
                     "FROM dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND " &
                          "dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT " &
                     "WHERE (dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = '" & Trim(strPT(2)) & "') AND (dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = '" & cb.SelectedValue & "')"

            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                Me.grdPhuTungThayThe.CurrentRow.Cells("SL_TT").Value = dtReader.Item("SL_VT")
                Me.grdPhuTungThayThe.CurrentRow.Cells("DON_GIA").Value = dtReader.Item("DON_GIA")
                Me.grdPhuTungThayThe.CurrentRow.Cells("cboNgoaiTe").Value = dtReader.Item("NGOAI_TE")
                Me.grdPhuTungThayThe.CurrentRow.Cells("TY_GIA").Value = dtReader.Item("TY_GIA")
                Me.grdPhuTungThayThe.CurrentRow.Cells("TY_GIA_USD").Value = dtReader.Item("TY_GIA_USD")
                Me.grdPhuTungThayThe.CurrentRow.Cells("BAO_HANH_DEN_NGAY").Value = dtReader.Item("BAO_HANH_DEN_NGAY")
                Me.grdPhuTungThayThe.CurrentRow.Cells("XUAT_XU").Value = dtReader.Item("XUAT_XU")
            End While
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub grdPhuTungThayThe_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdPhuTungThayThe.CellBeginEdit
    '    If e.ColumnIndex = 7 Then
    '        Dim dtTable = New DataTable
    '        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVI_TRI_KHOs", Me.grdPhuTungThayThe.CurrentRow.Cells(6).Value))

    '        Dim cell As DataGridViewComboBoxCell = grdPhuTungThayThe.CurrentCell
    '        cell.DataSource = dtTable
    '    End If
    'End Sub

    'Private Sub grdPhuTungThayThe_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPhuTungThayThe.CellEndEdit
    '    If e.ColumnIndex = 7 Then
    '        Dim dtTable = New DataTable
    '        dtTable = New DataTable
    '        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM VI_TRI_KHO"))

    '        Dim cell As DataGridViewComboBoxCell = grdPhuTungThayThe.CurrentCell
    '        cell.DataSource = dtTable
    '    End If
    'End Sub

    Private Sub BtnXacnhanNT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXacnhanNT.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If cboTinhTrangPBT.SelectedValue = 1 Then
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPhieuBTChuaDuyet", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                BtnDuyetPBT_Click(sender, e)
            Else
                Exit Sub
            End If
        End If
        ThucHienGhiThongTinNghiemThu()
        If blnLoiGhiDuLieu Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHINH_SUA_DL", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        Dim str As String = ""
        str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
        " WHERE USERNAME='" & Commons.Modules.UserName & "' AND CHUC_NANG.STT=8 "
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim tmp As Boolean = False
        While objReader.Read
            If objReader.Item("STT").ToString <> "" Then
                tmp = True
            End If
        End While
        objReader.Close()
        If Not tmp Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNghiemThu", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim i As Integer


        For k As Integer = 0 To grdPhuTungThayThe.RowCount - 1
            If IsDBNull(grdPhuTungThayThe.Rows(k).Cells("cboNgoaiTe").Value) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_NGOAI_TE", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                grdPhuTungThayThe.CurrentCell = grdPhuTungThayThe.Rows(k).Cells("cboNgoaiTe")
                Exit Sub
            End If
        Next

        'hỏi có then gì khác không
        If Val(txtChiPhiKhacMacDinh.Text.Trim) = 0 And Val(txtChiPhiKhacUSD.Text.Trim) = 0 Then
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT19", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                txtChiPhiKhacMacDinh.ReadOnly = False
                'txtChiPhiKhacUSD.ReadOnly = False
                txtChiPhiKhacMacDinh.Focus()
                Exit Sub
            End If
        End If

        'GHI THONG TIN CHI PHI KHAC
        Try
            Commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CHI_PHI(MS_PHIEU_BAO_TRI,CHI_PHI_KHAC,CHI_PHI_KHAC_USD) VALUES(N'" & txtMaSoPBT.Text & "'," & IIf(IsDBNull(txtChiPhiKhacMacDinh.Text), 0, txtChiPhiKhacMacDinh.Text.Replace(",", "")) & ", " & Convert.ToDouble(IIf(IsDBNull(txtChiPhiKhacUSD.Text), 0, txtChiPhiKhacUSD.Text.Replace(",", ""))) & ")"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
            Try
                Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC=" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacMacDinh.Text, ",", ""))) & ", CHI_PHI_KHAC_USD =" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacUSD.Text, ",", ""))) & " WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Catch ex1 As Exception
                Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CHI_PHI SET CHI_PHI_KHAC=" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacMacDinh.Text, ",", ""))) & ", CHI_PHI_KHAC_USD =" & Convert.ToDouble(Val(Replace$(txtChiPhiKhacUSD.Text, ",", ""))) & " WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            End Try
        End Try

        'hỏ có chắc nghiệm thu phiếu bảo trì này không
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKT16", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then Exit Sub

        Dim strPN As String = "", strPX As String = ""
        Dim dtReader As SqlDataReader
        Dim blnNT As Boolean = False
        KTThongTinNT()
        If blnLoiGhiDuLieu Then Exit Sub

        While i < grdPhuTungThayThe.RowCount
            If Not IsDBNull(Me.grdPhuTungThayThe.Rows(i).Cells("MS_PT1").Value) And Not IsDBNull(Me.grdPhuTungThayThe.Rows(i).Cells("cboMSDHNhap").Value) Then
                strPN = Microsoft.VisualBasic.Left(Me.grdPhuTungThayThe.Rows(i).Cells("cboMSDHNhap").Value, 13)
                Commons.Modules.SQLString = "SELECT * FROM IC_DON_HANG_XUAT WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "' AND LOCK= 0 AND MS_DH_XUAT_PT IN (SELECT MS_DH_XUAT_PT FROM IC_DON_HANG_XUAT_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT='" & strPN & "')"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    Try
                        If InStr(strPX, dtReader.Item("MS_DH_XUAT_PT") & "; ") = 0 Then strPX = dtReader.Item("MS_DH_XUAT_PT") & "; " & strPX
                    Catch ex As Exception
                    End Try
                    blnNT = True
                End While
                dtReader.Close()
            End If
            i += 1
        End While
        If blnNT Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT14", Commons.Modules.TypeLanguage) & strPX, MsgBoxStyle.Critical, "Thông báo ")
            Exit Sub
        End If

        Commons.Modules.SQLString = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "' AND NGAY_HOAN_THANH IS NULL"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            blnNT = True
            Exit While
        End While
        dtReader.Close()
        If blnNT Then
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT15", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Thông báo ") = MsgBoxResult.No Then Exit Sub
            Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & txtNgayNghiemThu.Text & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND NGAY_HOAN_THANH IS NULL"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        End If
        Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & txtNgayNghiemThu.Text & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND NGAY_HOAN_THANH IS NULL"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Dim CHI_PHI_PHU_TUNG As Double = 0, CHI_PHI_PHU_TUNG_USD As Double = 0, CHI_PHI_VAT_TU As Double = 0, CHI_PHI_VAT_TU_USD As Double = 0, CHI_PHI_NHAN_CONG As Double = 0, CHI_PHI_NHAN_CONG_USD As Double = 0, CHI_PHI_DV As Double = 0, CHI_PHI_DV_USD As Double = 0, CHI_PHI_KHAC As Double = 0, CHI_PHI_KHAC_USD As Double = 0, dblTiGia As Double = 0, dblTiGiaUSD As Double

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_TONG_CHI_PHI_VT", Me.txtMaSoPBT.Text)

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
        str = "SELECT distinct MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND " &
        " (SELECT COUNT(*) FROM (SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE " &
        " FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
        " UNION SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE FROM PHIEU_BAO_TRI_DI_CHUYEN_BP  " &
        " INNER JOIN PHIEU_BAO_TRI ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
        " WHERE PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' AND DAI_HAN=1 AND (NGAY_TRA_TT IS NULL OR NGAY_TRA_TT>=NGAY_NGHIEM_THU)AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' ) AS P1 " &
        " WHERE PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=P1.MS_BO_PHAN)>1"

        Dim objReader1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)

        While objReader1.Read
            If objReader1.Item("MS_BO_PHAN").ToString <> "" Then
                bCoTmp = True
            End If
        End While
        objReader1.Close()
        If bCoTmp Then
            Try
                str = "DROP TABLE TMP_CONG_VIEC" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            Try
                str = "DROP TABLE TMP_MAY_BO_PHAN" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN,CONG_VIEC.MS_CV ,MO_TA_CV into DBO.TMP_CONG_VIEC" & Commons.Modules.UserName & " FROM PHIEU_BAO_TRI_CONG_VIEC INNER JOIN PHIEU_BAO_TRI " &
            " ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI INNER JOIN " &
            " CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV WHERE PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND " &
            "((SELECT COUNT(*) FROM PHIEU_BAO_TRI_DI_CHUYEN_BP PBTDC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
            " AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=PBTDC.MS_BO_PHAN)+(select COUNT(*) FROM PHIEU_BAO_TRI_DI_CHUYEN_BP PBTDC1 " &
            " INNER JOIN PHIEU_BAO_TRI PBT ON PBTDC1.MS_PHIEU_BAO_TRI=PBT.MS_PHIEU_BAO_TRI " &
            " WHERE PBT.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' AND (NGAY_TRA_TT IS NULL " &
            " OR NGAY_TRA_TT>=NGAY_NGHIEM_THU) AND PBT.MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND PBTDC1.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN))>1"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            str = "SELECT DISTINCT N'" & cboMS_ThietBi.SelectedValue & "'as MS_MAY,  MS_BO_PHAN,TEN_BO_PHAN,MS_MAY_THAY_THE AS MS_MAY_TT,MS_BO_PHAN_THAY_THE AS MS_BO_PHAN_TT,TEN_BO_PHAN_THAY_THE/*,NGAY_TRA_TT*/,CHON,MS_CV INTO DBO.TMP_MAY_BO_PHAN" & Commons.Modules.UserName & " FROM " &
            " (SELECT MS_BO_PHAN,TEN_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE,TEN_BO_PHAN_THAY_THE,NGAY_TRA_TT,CONVERT(BIT,0)AS CHON,CONVERT(INT,NULL)AS MS_CV FROM " &
            " (SELECT * FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'   " &
            " UNION SELECT PHIEU_BAO_TRI_DI_CHUYEN_BP.* FROM PHIEU_BAO_TRI_DI_CHUYEN_BP INNER JOIN PHIEU_BAO_TRI ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' AND (NGAY_TRA_TT IS NULL " &
            " OR NGAY_TRA_TT>=NGAY_NGHIEM_THU )AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "'/* AND MS_BO_PHAN NOT IN (SELECT DISTINCT MS_BO_PHAN FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' )*/) AS P2 " &
            " WHERE P2.MS_BO_PHAN IN (SELECT distinct MS_BO_PHAN FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND " &
            " (SELECT COUNT(*) FROM (SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE   " &
            " FROM PHIEU_BAO_TRI_DI_CHUYEN_BP WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
            " UNION SELECT DISTINCT MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE FROM PHIEU_BAO_TRI_DI_CHUYEN_BP INNER JOIN " &
            " PHIEU_bAO_TRI ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_bAO_TRI.MS_PHIEU_BAO_TRI " &
            " WHERE PHIEU_bAO_TRI.MS_PHIEU_BAO_TRI<>'" & txtMaSoPBT.Text & "' AND (NGAY_TRA_TT IS NULL OR NGAY_TRA_TT>=NGAY_NGHIEM_THU) AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "') AS P1 " &
            " WHERE PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN=P1.MS_BO_PHAN)>1))AS P3 "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            frmChonCongViecChoBoPhan.MS_MAY = cboMS_ThietBi.SelectedValue
            frmChonCongViecChoBoPhan.ShowDialog()
        End If
        Dim bCoTmp1 As Boolean = False, bCoTmp2 As Boolean = False, bCoTmp3 As Boolean = False
        Dim objRead As SqlDataReader
        Dim strTmp As String = ""
        tbTmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_BO_PHAN,MS_CV FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'").Tables(0)
        For i = 0 To tbTmp.Rows.Count - 1
            'str = "SELECT  MS_DH_NHAP_PT,PBTCVPTCT.MS_PT ,MS_PT1,MS_VI_TRI_PT,SUM(PBTCVPTCT.SL_TT) as SL_TT FROM PHIEU_BAO_TRI_CONG_VIEC PBTCV INNER JOIN" & _
            '            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG PBTCVPT ON PBTCV.MS_PHIEU_BAO_TRI = PBTCVPT.MS_PHIEU_BAO_TRI AND " & _
            '            " PBTCV.MS_CV = PBTCVPT.MS_CV AND PBTCV.MS_BO_PHAN = PBTCVPT.MS_BO_PHAN INNER JOIN " & _
            '            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET PBTCVPTCT ON PBTCVPT.MS_PHIEU_BAO_TRI = PBTCVPTCT.MS_PHIEU_BAO_TRI AND " & _
            '            " PBTCVPT.MS_CV = PBTCVPTCT.MS_CV AND PBTCVPT.MS_PT = PBTCVPTCT.MS_PT AND PBTCVPT.MS_BO_PHAN = PBTCVPTCT.MS_BO_PHAN " & _
            '            " WHERE (PBTCV.MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "') AND (PBTCV.MS_CV = " & tbTmp.Rows(i).Item("MS_CV") & ") AND " & _
            '            " (PBTCV.MS_BO_PHAN = '" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "') AND (PBTCVPTCT.SL_TT IS NOT NULL) GROUP BY MS_DH_NHAP_PT,MS_PT1,PBTCVPTCT.MS_PT,MS_VI_TRI_PT "
            'objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            'strTmp = ""
            'While objRead.Read
            '    If strTmp = "" Then
            '        strTmp = strTmp + "(" + objRead.Item("MS_PT") + "," + objRead.Item("MS_VI_TRI_PT") + "," + objRead.Item("MS_PT1") + "," + objRead.Item("SL_TT").ToString + ")"
            '    Else
            '        strTmp = strTmp + "," + "(" + objRead.Item("MS_PT") + "," + objRead.Item("MS_VI_TRI_PT") + "," + objRead.Item("MS_PT1") + "," + objRead.Item("SL_TT").ToString + ")"
            '    End If
            'End While
            'objRead.Close()
            If bCoTmp Then
                str = "SELECT MS_MAY_TT,MS_BO_PHAN_TT FROM TMP_MAY_BO_PHAN" & Commons.Modules.UserName & " WHERE MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV=" & tbTmp.Rows(i).Item("MS_CV")
                objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    bCoTmp2 = True
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=N'" & objRead.Item("MS_MAY_TT") & "', MS_BO_PHAN_TT='" & objRead.Item("MS_BO_PHAN_TT") & "', PHU_TUNG_TT='" & strTmp & "' WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                End While
                objRead.Close()
            End If
            If Not bCoTmp2 Then
                str = "SELECT MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE FROM PHIEU_BAO_TRI_DI_CHUYEN_BP INNER JOIN PHIEU_BAO_TRI " &
                " ON PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
                " WHERE (NGAY_TRA_TT IS NULL or NGAY_TRA_TT>=NGAY_NGHIEM_THU)AND DAI_HAN=1 AND MS_MAY=N'" & cboMS_ThietBi.SelectedValue & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "'"
                objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=N'" & objRead.Item("MS_MAY_THAY_THE") & "', MS_BO_PHAN_TT='" & objRead.Item("MS_BO_PHAN_THAY_THE") & "', PHU_TUNG_TT='" & strTmp & "' WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                    bCoTmp1 = True
                End While
                objRead.Close()
                If Not bCoTmp1 Then
                    'trường hợp các bộ phận mượn đều đã trả
                    str = " select TOP 1 MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE from PHIEU_BAO_TRI_DI_CHUYEN_BP " &
                    "WHERE DAI_HAN=1 AND MS_PHIEU_bAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' ORDER BY NGAY_TRA_TT DESC"
                    objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objRead.Read
                        If objRead.Item("MS_MAY_THAY_THE").ToString <> "" Then
                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=N'" & objRead.Item("MS_MAY_THAY_THE") & "', MS_BO_PHAN_TT='" & objRead.Item("MS_BO_PHAN_THAY_THE") & "', PHU_TUNG_TT='" & strTmp & "' WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                            bCoTmp3 = True
                        End If
                    End While
                    objRead.Close()
                    If Not bCoTmp3 Then
                        str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=N'" & cboMS_ThietBi.SelectedValue & "', MS_BO_PHAN_TT='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "', PHU_TUNG_TT='" & strTmp & "' WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_BO_PHAN='" & tbTmp.Rows(i).Item("MS_BO_PHAN") & "' AND MS_CV =" & tbTmp.Rows(i).Item("MS_CV")
                    End If
                End If
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            bCoTmp3 = False
            bCoTmp2 = False
            bCoTmp1 = False
        Next
        'history

        'CHI PHI NHAN CONG

        'commons.Modules.SQLString = "SELECT TI_GIA,TI_GIA_USD FROM TI_GIA_NT A INNER JOIN NGOAI_TE B ON A.NGOAI_TE=B.NGOAI_TE WHERE MAC_DINH=1 AND NGAY IN (SELECT MAX(NGAY) FROM TI_GIA_NT WHERE YEAR(NGAY)<=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY)<=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET)) "
        Commons.Modules.SQLString = "SELECT TI_GIA, TI_GIA_USD " &
                 "FROM TI_GIA_NT INNER JOIN NGOAI_TE ON TI_GIA_NT.NGOAI_TE=NGOAI_TE.NGOAI_TE " &
                 "WHERE NGOAI_TE.MAC_DINH=1 AND NGAY_NHAP >= (SELECT ISNULL(MAX(NGAY_NHAP),0) " &
                                                             "FROM TI_GIA_NT INNER JOIN NGOAI_TE ON TI_GIA_NT.NGOAI_TE = NGOAI_TE.NGOAI_TE " &
                                                             "WHERE DATEDIFF(DAY,NGAY_NHAP,'" & Format(CDate(txtNgayNghiemThu.Text), "dd/MMM/yyyy") & "')>=0)"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            dblTiGia = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
            dblTiGiaUSD = IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
        End While
        dtReader.Close()

        Dim strChiPhiCV_Chinh As String, strChiPhiCV_Phu As String

        'commons.Modules.SQLString = "SELECT SUM(LUONG) AS LUONG FROM (SELECT A.MS_CONG_NHAN,(SO_PHUT*LUONG_CO_BAN)/(26*8*60) AS LUONG FROM (SELECT MS_CONG_NHAN,SUM(DATEDIFF(mi,TU_GIO,DEN_GIO)) AS SO_PHUT FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "' GROUP BY MS_CONG_NHAN) A INNER JOIN (SELECT MS_CONG_NHAN,LUONG_CO_BAN FROM LUONG_CO_BAN WHERE MS_CONG_NHAN IN(SELECT MS_CONG_NHAN FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET)) AND NGAY_HIEU_LUC IN(SELECT MAX(NGAY_HIEU_LUC) AS NGAY_HIEU_LUC FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) GROUP BY MS_CONG_NHAN)) B ON A.MS_CONG_NHAN=B.MS_CONG_NHAN) AS TblTam"

        strChiPhiCV_Chinh = "SELECT A.MS_CONG_NHAN,(SO_PHUT*LUONG_CO_BAN)/(26*8*60) AS LUONG FROM (SELECT MS_CONG_NHAN,SUM(DATEDIFF(MINUTE,NGAY+' '+TU_GIO,DEN_NGAY+' '+DEN_GIO)) AS SO_PHUT FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "' GROUP BY MS_CONG_NHAN) A INNER JOIN (SELECT MS_CONG_NHAN,LUONG_CO_BAN FROM LUONG_CO_BAN WHERE MS_CONG_NHAN IN(SELECT MS_CONG_NHAN FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET)) AND NGAY_HIEU_LUC IN(SELECT MAX(NGAY_HIEU_LUC) AS NGAY_HIEU_LUC FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) GROUP BY MS_CONG_NHAN)) B ON A.MS_CONG_NHAN=B.MS_CONG_NHAN"
        strChiPhiCV_Phu = "SELECT A.MS_CONG_NHAN,(SO_PHUT*LUONG_CO_BAN)/(26*8*60) AS LUONG FROM (SELECT MS_CONG_NHAN,SUM(DATEDIFF(MINUTE,NGAY+' '+TU_GIO,DEN_NGAY+' '+DEN_GIO)) AS SO_PHUT FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "' GROUP BY MS_CONG_NHAN) A INNER JOIN (SELECT MS_CONG_NHAN,LUONG_CO_BAN FROM LUONG_CO_BAN WHERE MS_CONG_NHAN IN(SELECT MS_CONG_NHAN FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO)) AND NGAY_HIEU_LUC IN(SELECT MAX(NGAY_HIEU_LUC) AS NGAY_HIEU_LUC FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO) GROUP BY MS_CONG_NHAN)) B ON A.MS_CONG_NHAN=B.MS_CONG_NHAN"

        Commons.Modules.SQLString = "SELECT SUM(LUONG) AS LUONG,(SELECT TI_GIA_NT.TI_GIA FROM TI_GIA_NT WHERE TI_GIA_NT.NGAY >= (SELECT MAX(TI_GIA_NT.NGAY) FROM TI_GIA_NT) AND TI_GIA_NT.NGOAI_TE IN (SELECT NGOAI_TE.NGOAI_TE FROM NGOAI_TE WHERE NGOAI_TE.MAC_DINH=1)) AS TI_GIA FROM (" & strChiPhiCV_Chinh & " UNION " & strChiPhiCV_Phu & ") AS TblTam"
        Commons.Modules.SQLString = "SELECT ISNULL(LUONG*TI_GIA,0) FROM (" & Commons.Modules.SQLString & ") TMP"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            CHI_PHI_NHAN_CONG = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0)) * dblTiGia
            CHI_PHI_NHAN_CONG_USD = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0)) * dblTiGiaUSD
        End While
        dtReader.Close()

        'HET"

        'CHI PHI DICH VU
        'commons.Modules.SQLString = "SELECT SUM(SO_LUONG*DON_GIA*TY_GIA) AS CHI_PHI, SUM(SO_LUONG*DON_GIA*TY_GIA_USD) AS CHI_PHI_USD FROM PHIEU_BAO_TRI_SERVICE GROUP BY MS_PHIEU_BAO_TRI HAVING MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        Commons.Modules.SQLString = "SELECT dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI, SUM(dbo.PHIEU_BAO_TRI_SERVICE.SO_LUONG * dbo.PHIEU_BAO_TRI_SERVICE.DON_GIA * dbo.TI_GIA_NT.TI_GIA) AS CHI_PHI_DV, " &
                      "SUM(dbo.PHIEU_BAO_TRI_SERVICE.SO_LUONG * dbo.PHIEU_BAO_TRI_SERVICE.DON_GIA * dbo.TI_GIA_NT.TI_GIA_USD) AS CHI_PHI_DV_USD " &
                 "FROM dbo.PHIEU_BAO_TRI_SERVICE INNER JOIN dbo.TI_GIA_NT ON dbo.PHIEU_BAO_TRI_SERVICE.NGOAI_TE = dbo.TI_GIA_NT.NGOAI_TE " &
                 "WHERE (dbo.TI_GIA_NT.NGAY_NHAP >= ALL (SELECT MAX(NGAY_NHAP) FROM TI_GIA_NT)) " &
                 "GROUP BY dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI HAVING (dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI = N'" & txtMaSoPBT.Text & "')"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            CHI_PHI_DV = IIf(IsDBNull(dtReader.Item("CHI_PHI_DV")), 0, dtReader.Item("CHI_PHI_DV"))
            CHI_PHI_DV_USD = IIf(IsDBNull(dtReader.Item("CHI_PHI_DV_USD")), 0, dtReader.Item("CHI_PHI_DV_USD"))
        End While
        dtReader.Close()

        'HET

        'CHI PHI PHU TUNG
        '        commons.Modules.SQLString = "SELECT SUM(SL_TT*DON_GIA*TY_GIA) AS CHI_PHI, SUM(SL_TT*DON_GIA*TY_GIA_USD) AS CHI_PHI_USD FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET GROUP BY MS_PHIEU_BAO_TRI HAVING MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        'commons.Modules.SQLString = "SELECT SUM(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT * dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.DON_GIA * dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA) " & _
        ' "AS CHI_PHI, SUM(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT * dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.DON_GIA * dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA_USD) " & _
        ' "AS CHI_PHI_USD " & _
        ' "FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET INNER JOIN " & _
        ' "dbo.IC_PHU_TUNG ON dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " & _
        ' "dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT " & _
        ' "WHERE(dbo.LOAI_VT.VAT_TU = 0) " & _
        ' "GROUP BY dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI " & _
        ' "HAVING (dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = '" & Me.txtMaSoPBT.Text & "')"
        'dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

        ''''''''dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_CHI_PHI_VT_PT", Me.txtMaSoPBT.Text, 0)


        Commons.Modules.SQLString = "SELECT SUM(SL_TT*DON_GIA*TY_GIA) AS TONG_CP_PT, SUM(SL_TT*DON_GIA*TY_GIA_USD) AS TONG_CP_PT_USD FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & Me.txtMaSoPBT.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            CHI_PHI_PHU_TUNG = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
            CHI_PHI_PHU_TUNG_USD = IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
        End While
        dtReader.Close()

        'HET
        'Chi phí vật tư

        'end
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI_CHI_PHI", Me.txtMaSoPBT.Text, CHI_PHI_PHU_TUNG, CHI_PHI_PHU_TUNG_USD, CHI_PHI_VAT_TU, CHI_PHI_VAT_TU_USD, CHI_PHI_NHAN_CONG, CHI_PHI_NHAN_CONG_USD, CHI_PHI_DV, CHI_PHI_DV_USD)
        Catch ex As Exception
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI_CHI_PHI", Me.txtMaSoPBT.Text, CHI_PHI_PHU_TUNG, CHI_PHI_PHU_TUNG_USD, CHI_PHI_VAT_TU, CHI_PHI_VAT_TU_USD, CHI_PHI_NHAN_CONG, CHI_PHI_NHAN_CONG_USD, CHI_PHI_DV, CHI_PHI_DV_USD)
        End Try
        Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI SET TINH_TRANG_PBT=3 WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        bHuyNT = 2
        BindDataThongTinChiPhi(Me.txtMaSoPBT.Text)
        cboTinhTrangPBT.SelectedValue = 3
        LoadTongGioCong(txtMaSoPBT.Text, cboTinhTrangPBT.SelectedValue)
        LoadNgayBatDauBaoTri(txtMaSoPBT.Text)
        LoadNgayKetThucBaoTri(txtMaSoPBT.Text, cboTinhTrangPBT.SelectedValue)
        BtnXacnhanNT.Enabled = False
    End Sub

    Private Sub KTThongTinNT()
        If cboNguoiNghiemThu.SelectedValue Is Nothing And txtNgayNghiemThu.Text = "  /  /" And txtTinhTrangSauBaoTri.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT2", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            blnLoiGhiDuLieu = True
            Exit Sub
        End If

        If cboNguoiNghiemThu.SelectedValue = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT2", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            blnLoiGhiDuLieu = True
            Exit Sub
        End If

        If txtNgayNghiemThu.MaskCompleted = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT2", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            txtNgayNghiemThu.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If

        If txtTinhTrangSauBaoTri.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT2", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            txtTinhTrangSauBaoTri.Focus()
            blnLoiGhiDuLieu = True
            Exit Sub
        End If
    End Sub

    Private Sub BtnLockPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLockPBT.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If cboTinhTrangPBT.SelectedValue <> 3 Then
            'XtraMessageBox.Show(" phiếu bảo trì chưa nghiệm thu nên không được khóa")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPBTChuaNT", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        If cboTinhTrangPBT.SelectedValue = 3 Then
            Dim str As String = ""
            str = "SELECT CHUC_NANG.STT FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " &
            " WHERE USERNAME='" & Commons.Modules.UserName & "' AND CHUC_NANG.STT=9 "
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                If objReader.Item("STT").ToString <> "" Then
                    Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhoaPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                    If Traloi = vbYes Then
                        Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
                        objPHIEU_BAO_TRIController.UpdatePHIEU_BAO_TRI_TINH_TRANG(txtMaSoPBT.Text, 4)
                        Dim objReader1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHinhThucBT", cboLoai_BT.SelectedValue)
                        Dim dtReaderBTPT As SqlDataReader

                        'CAP NHAT CHO LOAI BT DOC LAP (THU_TU = 0)
                        Try
                            While objReader1.Read
                                If objReader1.Item("MS_HT_BT") = 1 Then
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_LOAI_BTPN", cboMS_ThietBi.SelectedValue, cboLoai_BT.SelectedValue, Format(dtNgayLap.Value, "Short date"))
                                End If
                            End While
                            objReader1.Close()
                        Catch ex As Exception
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN", cboMS_ThietBi.SelectedValue, cboLoai_BT.SelectedValue, Format(dtNgayLap.Value, "Short date"))
                        End Try

                        Try
                            'CAP NHAT CHO LOAI BT PHU THUOC (THU_TU <> 0 VA CAC LOAI BT TRONG QUAN HE)
                            dtReaderBTPT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT=" & cboLoai_BT.SelectedValue)
                            While dtReaderBTPT.Read
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_LOAI_BTPN", cboMS_ThietBi.SelectedValue, dtReaderBTPT.Item("MS_LOAI_BT_CD"), Format(dtNgayLap.Value, "Short date"))
                            End While
                            dtReaderBTPT.Close()
                        Catch
                        End Try

                        str = txtMaSoPBT.Text
                        BindData()
                        For i As Integer = 0 To dgrDanhSach_1.Rows.Count - 1
                            If dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Value = str Then
                                dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Selected = True
                                dgrDanhSach_1.CurrentCell = dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI")
                                dgrDanhSach_1.Focus()
                                Exit For
                            Else
                                dgrDanhSach_1.Rows(i).Cells("MS_PHIEU_BAO_TRI").Selected = False
                            End If
                        Next
                    End If
                End If
                objReader.Close()

                If Commons.Modules.PermisString.Equals("Read only") Then
                    EnableButton(False)
                Else
                    If cboTinhTrangPBT.SelectedValue < 4 Then
                        EnableButton(True)
                        If radPhieuBaoTriChuaNghiemThu_1.Checked Then
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
                    End If
                End If

                Exit Sub
            End While
            objReader.Close()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLockPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        End If

    End Sub
    Private Sub txtNgayNghiemThu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNgayNghiemThu.Validating
        If cboNgayNghiemThu.Focused() Or cboNgayNghiemThu.Enabled = False Then
            Exit Sub
        End If
        If btnGhi5.Visible Then
            If Not IsDate(txtNgayNghiemThu.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayNghiemThu", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayNghiemThu.Focus()
                Exit Sub
            Else
                If Date.Parse(txtNgayNghiemThu.Text) < Date.Parse(dtNgayLap.Value) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayNghiemThuLonHonHT", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtNgayNghiemThu.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grdDiChuyenBoPhan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDiChuyenBoPhan.KeyDown
        If e.KeyCode = Keys.Escape Then
            If grdDiChuyenBoPhan.RowCount > 1 Then
                If grdDiChuyenBoPhan.RowCount - 1 > rowCount And Not grdDiChuyenBoPhan.CurrentRow.IsNewRow Then
                    grdDiChuyenBoPhan.Rows.RemoveAt(Me.grdDiChuyenBoPhan.CurrentRow.Index)
                End If
            Else
                BindDataDiChuyenBP()
            End If
        End If
    End Sub
    Private Sub grdDiChuyenBoPhan_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdDiChuyenBoPhan.RowValidating
        If btnKhongGhi5.Focused() Then
            Exit Sub
        End If
        If btnGhi5.Visible Then
            Try
                Dim str As String = ""
                str = "SELECT top 1 NGAY_THAY, NGAY_TRA_TT FROM PHIEU_BAO_TRI_DI_CHUYEN_BP " &
                " WHERE  MS_MAY_THAY_THE = N'" & grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_MAY_THAY_THE").Value & "' AND MS_BO_PHAN_THAY_THE = '" & grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_BO_PHAN_THAY_THE").Value & "' AND NGAY_TRA_TT IS NOT NULL AND  " &
                " NGAY_TRA_TT > CONVERT(DATETIME, '" & Format(grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("cboNgayThay").Value, "Short date") & "', 103) AND NGAY_THAY <= CONVERT(DATETIME, '" & Format(grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("cboNgayThay").Value, "Short date") & "', 103)" &
                " GROUP BY MS_PHIEU_BAO_TRI,MS_BO_PHAN,MS_MAY_THAY_THE,MS_BO_PHAN_THAY_THE, NGAY_THAY, NGAY_TRA_TT " &
                " HAVING (SELECT COUNT(*) FROM PHIEU_BAO_TRI_DI_CHUYEN_BP PBTDC WHERE PBTDC.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_PHIEU_BAO_TRI " &
                " AND PBTDC.MS_BO_PHAN=PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_BO_PHAN AND PBTDC.MS_MAY_THAY_THE=PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_MAY_THAY_THE AND " &
                " PBTDC.MS_BO_PHAN=PHIEU_BAO_TRI_DI_CHUYEN_BP.MS_BO_PHAN_THAY_THE AND PBTDC.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' " &
                " AND PBTDC.MS_BO_PHAN='" & grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "')=0 "
                Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                While objRead.Read
                    If objRead.Item("NGAY_THAY").ToString <> "" Then
                        If Date.Parse(Format(grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("cboNgayThay").Value, "Short date")) = Date.Parse(Format(objRead.Item("NGAY_THAY"), "Short date")) Then
                            XtraMessageBox.Show("Ngày thay của Bộ phận thay thế ngày đã tồn tại ")
                            grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("cboNgayThay").Selected = True
                            grdDiChuyenBoPhan.Focus()
                            e.Cancel = True
                            objRead.Close()
                            Exit Sub
                        Else
                            XtraMessageBox.Show("Ngày thay của Bộ phận thay thế ngày nằm trong khoảng thời gian mà nó thay thế cho thiết bị khác(hiển thị thời gian nó thay thế ngày thay và ngay trả) ")
                            grdDiChuyenBoPhan.Rows(e.RowIndex).Cells("cboNgayThay").Selected = True
                            grdDiChuyenBoPhan.Focus()
                            e.Cancel = True
                            objRead.Close()
                            Exit Sub
                        End If
                    End If
                End While
                objRead.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub
#End Region

#Region "Báo cáo"

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

        Try
            str = "Drop table rptTieuDePhieuBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "Create table dbo.rptTieuDePhieuBaoTri(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255),ThietBi nvarchar(50)," &
        " PhieuBaoTri nvarchar(60),NgayLap nvarchar(50),NguoiLap nvarchar(60),HinhThucBT nvarchar(100), LoaiBT nvarchar(80),DiaDiem nvarchar(50), " &
        " NgayBD nvarchar(80),NgayKT nvarchar(80),BoPhanCP nvarchar(50),NgayNT nvarchar(60),NguoiNT nvarchar(80),KetQuaBT nvarchar(80),ChiPhiPhuTung nvarchar(100), " &
        " ChiPhiVatTu nvarchar(100),ChiPhuNhanCong nvarchar(100),ChiPhiDichVu nvarchar(100),ChiPhiKhac nvarchar(100),STT nvarchar(5),NoiDung nvarchar(50), " &
        " ChiPhi nvarchar(50),TongChiPhi nvarchar(70),KetQuaBaoTri nvarchar(80),Tong nvarchar(20),MoTa nvarchar(50),KeHoachThuchien nvarchar(80), " &
        " DanhSachCongViec nvarchar(255),DanhSachNhanVien nvarchar(255),DanhSachDichVu nvarchar(80),DanhSachPhuTung nvarchar(80),DiChuyenBoPhan nvarchar(80),TinhTrangPBT nvarchar(50),TenThietBi nvarchar(50),PheDuyet1 nvarchar(50),PheDuyet2 nvarchar(50),PheDuyet3 nvarchar(50)) " &
        " Insert into rptTieuDePhieuBaoTri values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & ThietBi & "',N'" & PhieuBaoTri &
        "',N'" & NgayLap & "',N'" & NguoiLap & "',N'" & HinhThucBT & "',N'" & LoaiBT & "',N'" & DiaDiem & "',N'" & NgayBD & "',N'" & NgayKT & "',N'" & BoPhanCP &
        "',N'" & NgayNT & "',N'" & NguoiNT & "',N'" & KetQuaBT & "',N'" & ChiPhiPhuTung & "',N'" & ChiPhiVatTu & "',N'" & chiPhiNhanCong & "',N'" & ChiPhiDichVu &
        "',N'" & ChiPhiKhac & "',N'" & STT & "',N'" & NoiDung & "',N'" & ChiPhi & "',N'" & TongChiPhi & "',N'" & KetQuaBaoTri & "',N'" & Tong & "',N'" & MoTa & "',N'" &
        KeHoachThucHien & "',N'" & DanhSachCongViec & "',N'" & DanhSachNhanVien & "',N'" & DanhSachDichVu & "',N'" & DanhSachPhuTung & "',N'" & DiChuyenBoPhan & "',N'" & TinhTrangPBT &
        "',N'" & TenThietBi & "',N'" & PheDuyet1 & "',N'" & PheDuyet2 & "',N'" & PheDuyet3 & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDeCongViecBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "CongViec", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BoPhan", Commons.Modules.TypeLanguage)
        Dim SoGioKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SoGioKH", Commons.Modules.TypeLanguage)
        Dim NgayHoanThanh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NgayHoanThanh", Commons.Modules.TypeLanguage)
        Dim NoiNgoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "NoiNgoai", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeCongViecBaoTri(TieuDe nvarchar(100),CongViec nvarchar(50),BoPhan nvarchar(50),SoGioKH nvarchar(50),NgayHoanThanh nvarchar(80),NoiNgoai nvarchar(50))" &
        " Insert into rptTieuDeCongViecBaoTri values(N'" & DanhSachCongViec & "',N'" & CongViec & "',N'" & BoPhan & "',N'" & SoGioKH & "',N'" & NgayHoanThanh & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDeNhanCongBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim HoTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "HoTen", Commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TuNgay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DenNgay", Commons.Modules.TypeLanguage)
        Dim ChinhPhu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "ChinhPhu", Commons.Modules.TypeLanguage)
        Dim BanTo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "BanTo", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDeNhanCongBaoTri(TieuDe nvarchar(100),HoTen Nvarchar(50),BanTo nvarchar(50),TuNgay nvarchar(50),Dengay Nvarchar(50),ChinhPhu nvarchar(50))" &
        " Insert into rptTieuDeNhanCongBaoTri values(N'" & DanhSachNhanVien & "',N'" & HoTen & "',N'" & BanTo & "',N'" & TuNgay & "',N'" & DenNgay & "',N'" & ChinhPhu & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDedichvuThueNgoaiBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
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
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Try
            str = "Drop table rptTieuDePhuTungBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim MaVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "MaVatTu", Commons.Modules.TypeLanguage)
        Dim TenVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "TenVatTu", Commons.Modules.TypeLanguage)
        Dim SLKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLKH", Commons.Modules.TypeLanguage)
        Dim SLTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "SLTT", Commons.Modules.TypeLanguage)
        Dim DonVi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI", "DonVi", Commons.Modules.TypeLanguage)
        str = "Create table dbo.rptTieuDePhuTungBaoTri(TieuDe nvarchar(100),MaVatTu nvarchar(50), TenVatTu nvarchar(50),SLKH nvarchar(60),SLTT nvarchar(60),DonVi nvarchar(10),NoiNgoai nvarchar(30))" &
        " Insert into rptTieuDePhuTungBaoTri values(N'" & DanhSachPhuTung & "',N'" & MaVatTu & "',N'" & TenVatTu & "',N'" & SLKH & "',N'" & SLTT & "',N'" & DonVi & "',N'" & NoiNgoai & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        ' tao tieu de Report cho Phu Tung
        Try
            str = "Drop table rptTieuDe_PT_BT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
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
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        ' tao tieu de Report cho Vat Tu

        Try
            str = "Drop table rptTieuDe_VT_BT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
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
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)



        Try
            str = "Drop table rptTieuDeDiChuyenBoPhanBaoTri"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
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
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowReport()
        Me.Cursor = Cursors.WaitCursor
        CreaterptTieuDePhieuBaoTri()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptCONG_VIEC_BAO_TRI", txtMaSoPBT.Text)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptNHAN_CONG", txtMaSoPBT.Text)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptDICH_VU_THUE_NGOAI", txtMaSoPBT.Text)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptPHU_TUNG_BAO_TRI", txtMaSoPBT.Text, Commons.Modules.TypeLanguage)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptPHIEU_BAO_TRI1", txtMaSoPBT.Text, Commons.Modules.TypeLanguage)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptDI_CHUYEN_BO_PHAN_BAO_TRI", txtMaSoPBT.Text)

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "getPhieuBaoTriVatTu", txtMaSoPBT.Text)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "getPhieuBaoTriPhuTung", txtMaSoPBT.Text)

        Commons.mdShowReport.ReportPreview("reports/rptPHIEU_BAO_TRI.rpt")
        Dim str As String = ""

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btnIn_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIn_1.Click
        'If radPhieuBaoTriDaNghiemThu_1.Checked = True Then
        '    If txtMaSoPBT.Text <> "" Then
        '        ShowReport()
        '    End If

        'End If
        If txtMaSoPBT.Text <> "" Then
            Commons.clsXuLy.CreateTitleReport()
            ShowReport()
        End If

    End Sub

    Private Sub btnXoaPTTT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoaPTTT.Click
        If grdPhuTungThayThe.RowCount <= 0 Then Exit Sub
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT100", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Thông báo") = vbNo Then Exit Sub

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePBT_PhuTungThayTheNull", Me.grdPhuTungThayThe.CurrentRow.Cells("stt").Value)

        BindDataPTThayThe()

    End Sub

    Private Sub tabDanhSachPhieuBaoTri_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabDanhSachPhieuBaoTri.Leave
        If txtMaSoPBT.Text <> PBTOut Then
            bChangce = True
            PBTOut = txtMaSoPBT.Text
        Else
            bChangce = False
        End If
    End Sub
#End Region
#Region "Job card"
    Private intRowCN As Integer = 0
    'Private rowindex As Integer = -1
    Private row_cv_index As Integer = -1
    Private row_cvp_index As Integer = -1
    Private gio As String
    Private phut As String
    Private rowcout As Integer = -1
    Private arr_tmp(50, 2) As String
    Private TU_GIO_TMP As String
    Private bThem1 As Boolean = False
    Private SqlText As String
    Private bCapnhat As Boolean = True
    Private Sub RefeshLanguageReport()
        Dim str As String = ""
        Try
            str = "drop table rptTieuDeJobCard"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "TrangIn", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "STT", Commons.Modules.TypeLanguage)
        Dim PhieuBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", " CongViec", Commons.Modules.TypeLanguage)
        Dim ThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim NgayPV As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Ngay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "DenNgay", Commons.Modules.TypeLanguage)
        Dim ThoiGianLv As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "ThoiGianLV", Commons.Modules.TypeLanguage)
        Dim Vict_TG As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Vict_TG", Commons.Modules.TypeLanguage)
        Dim Vendor_TG As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Vendor_TG", Commons.Modules.TypeLanguage)
        Dim CongNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "NhanCong", Commons.Modules.TypeLanguage)
        Dim Remark As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Remark", Commons.Modules.TypeLanguage)
        Dim Tong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "Tong", Commons.Modules.TypeLanguage)
        Dim TenTo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "TenTo", Commons.Modules.TypeLanguage)
        Dim CongViecChinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "CongViecChinh", Commons.Modules.TypeLanguage)
        Dim CongViecPhu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDAILY_SUMMARY_DMS", "CongViecPhu", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        DieuKienLoc = lblTungay.Text + " " + Format(dtpTuNgay.Value, "Short date") + " " + lblDenngay.Text + " " + Format(dtpDenNgay.Value, "Short date")
        str = "Create table dbo.rptTieuDeJobCard(TypeLanguage int,NgayIn nvarchar(50),TrangIn nvarchar(50),TieuDe nvarchar(255),DieuKienLoc nvarchar(255)," &
        " TenTo nvarchar(50),PhieuBaoTri nvarchar(30),STT nvarchar(5),CongViec nvarchar(50),ThoiGian nvarchar(30),NgayPC nvarchar(30), " &
        " DenNgay nvarchar(30),ThoiGianLV nvarchar(50), Vict_TG nvarchar(30),Vendor_TG nvarchar(30),CongNhan nvarchar(50),Remark nvarchar(20),Tong nvarchar(20),CongViecChinh nvarchar(100),CongViecPhu nvarchar(100)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "INSERT INTO dbo.rptTieuDeJobCard values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & DieuKienLoc & "',N'" & TenTo &
        "',N'" & PhieuBaoTri & "',N'" & STT & "',N'" & CongViec & "',N'" & ThoiGian & "',N'" & NgayPV & "',N'" & DenNgay & "',N'" &
        ThoiGianLv & "',N'" & Vict_TG & "',N'" & Vendor_TG & "',N'" & CongNhan & "',N'" & Remark & "',N'" & Tong & "',N'" & CongViecChinh & "',N'" & CongViecPhu & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

    End Sub
    Sub CreateData()
        If cboNhanVien.Text = "" Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        RefeshLanguageReport()
        Dim str As String = ""
        Try
            str = "drop table rptJOB_CARD"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "SELECT DISTINCT CONG_NHAN.MS_TO,[TO].TEN_TO, PBT.MS_PHIEU_BAO_TRI,MO_TA_CV,PBT3.NGAY+' ' +PBT3.TU_GIO AS NGAY,PBT3.DEN_NGAY+' ' +PBT3.DEN_GIO AS DEN_NGAY,PBT3.MS_CONG_NHAN+'_'+HO+' '+TEN AS HO_TEN " &
        " ,case  DON_VI.THUE_NGOAI when 0 then CONVERT(FLOAT,DATEDIFF(MINUTE, NGAY+' '+ TU_GIO,DEN_NGAY+' '+DEN_GIO))/60 else null end AS VICT  " &
        " ,case  DON_VI.THUE_NGOAI when 1 then CONVERT(FLOAT,DATEDIFF(MINUTE, NGAY+' '+ TU_GIO,DEN_NGAY+' '+DEN_GIO))/60 else null end AS VENDOR,0 AS CV  " &
        " INTO DBO.rptJOB_CARD  " &
        " FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET PBT3 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU PBT2 ON  " &
        " PBT3.MS_PHIEU_BAO_TRI = PBT2.MS_PHIEU_BAO_TRI AND PBT3.MS_CV = PBT2.MS_CV AND  " &
        " PBT3.MS_BO_PHAN = PBT2.MS_BO_PHAN AND PBT3.MS_CONG_NHAN = PBT2.MS_CONG_NHAN INNER JOIN " &
        " PHIEU_BAO_TRI_CONG_VIEC PBT1 ON PBT2.MS_PHIEU_BAO_TRI = PBT1.MS_PHIEU_BAO_TRI AND  " &
        " PBT2.MS_CV = PBT1.MS_CV AND PBT2.MS_BO_PHAN = PBT1.MS_BO_PHAN INNER JOIN " &
        " PHIEU_BAO_TRI PBT ON PBT1.MS_PHIEU_BAO_TRI = PBT.MS_PHIEU_BAO_TRI INNER JOIN CONG_NHAN ON PBT3.MS_CONG_NHAN = CONG_NHAN.MS_CONG_NHAN INNER JOIN " &
        " [TO] ON CONG_NHAN.MS_TO = [TO].MS_TO1 INNER JOIN TO_PHONG_BAN ON [TO].MS_TO = TO_PHONG_BAN.MS_TO INNER JOIN " &
        " DON_VI ON TO_PHONG_BAN.MS_DON_VI = DON_VI.MS_DON_VI INNER JOIN CONG_VIEC ON PBT1.MS_CV=CONG_VIEC.MS_CV INNER JOIN LOAI_CONG_VIEC  " &
        " ON CONG_VIEC.MS_LOAI_CV =LOAI_CONG_VIEC.MS_LOAI_CV INNER JOIN NHOM_LOAI_CONG_VIEC " &
        " ON LOAI_CONG_VIEC.MS_LOAI_CV=NHOM_LOAI_CONG_VIEC.MS_LOAI_CV INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_CONG_VIEC.GROUP_ID " &
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE USERNAME='" & Commons.Modules.UserName & "'" &
        " AND PBT3.NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) and convert(datetime,'" & Format(dtpDenNgay.Value, "Short date") & "',103) " &
        " AND [TO].MS_TO1=" & cboTo.SelectedValue
        If cboNhanVien.SelectedValue <> "-1" Then
            str = str + " AND PBT3.MS_CONG_NHAN='" & cboNhanVien.SelectedValue & "'"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "insert into DBO.rptJOB_CARD SELECT DISTINCT CONG_NHAN.MS_TO,[TO].TEN_TO, PBT.MS_PHIEU_BAO_TRI,PBT2.TEN_CONG_VIEC," &
        " convert(datetime,convert(nvarchar(10),NGAY,103)+' ' +CONVERT(NVARCHAR(5),TU_GIO,114),103) AS NGAY ,convert(datetime,convert(nvarchar(10),DEN_NGAY,103)+' ' +CONVERT(NVARCHAR(5),DEN_GIO,114),103)  AS DEN_NGAY, " &
        " PBT3.MS_CONG_NHAN+'_'+HO+' '+TEN AS HO_TEN  ,case  DON_VI.THUE_NGOAI when 0 then  " &
        " CONVERT(FLOAT,DATEDIFF(MINUTE, NGAY+' '+ TU_GIO,DEN_NGAY+' '+DEN_GIO))/60 else null end AS VICT   , " &
        " case  DON_VI.THUE_NGOAI when 1 then CONVERT(FLOAT,DATEDIFF(MINUTE, NGAY+' '+ TU_GIO,DEN_NGAY+' '+DEN_GIO))/60 else null end AS VENDOR,1 AS CV    " &
        " FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO PBT3 INNER JOIN  " &
        " PHIEU_BAO_TRI_CV_PHU_TRO PBT2 ON   PBT3.MS_PHIEU_BAO_TRI = PBT2.MS_PHIEU_BAO_TRI AND PBT3.STT = PBT2.STT INNER JOIN   " &
        " PHIEU_BAO_TRI PBT ON PBT2.MS_PHIEU_BAO_TRI = PBT.MS_PHIEU_BAO_TRI  " &
        " INNER JOIN CONG_NHAN ON PBT3.MS_CONG_NHAN = CONG_NHAN.MS_CONG_NHAN INNER JOIN  [TO] ON CONG_NHAN.MS_TO = [TO].MS_TO1 " &
        " INNER JOIN TO_PHONG_BAN ON [TO].MS_TO = TO_PHONG_BAN.MS_TO INNER JOIN  DON_VI ON TO_PHONG_BAN.MS_DON_VI = DON_VI.MS_DON_VI   " &
        " WHERE  PBT3.NGAY BETWEEN CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "Short date") & "',103) and convert(datetime,'" & Format(dtpDenNgay.Value, "Short date") & "',103) " &
        " AND [TO].MS_TO1=" & cboTo.SelectedValue
        If cboNhanVien.SelectedValue <> "-1" Then
            str = str + " AND PBT3.MS_CONG_NHAN='" & cboNhanVien.SelectedValue & "'"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptJOB_CARD ")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Cursor = Cursors.Default
                objReader.Close()
                Exit Sub
            End If
        End While
        objReader.Close()
        Commons.mdShowReport.ReportPreview("reports/rptDAILY_SUMMARY_DMS.rpt")
        Me.Cursor = Cursors.Default
        Try
            str = "drop table rptJOB_CARD"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = "drop table rptTieuDeJobCard"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadCboNhanVien()
        If cboTo.Text = "" Then
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT DISTINCT MS_CONG_NHAN,HO+''+ TEN AS HOTEN FROM CONG_NHAN where MS_TO=" & cboTo.SelectedValue
        cboNhanVien.Display = "HOTEN"
        cboNhanVien.Value = "MS_CONG_NHAN"
        cboNhanVien.Param = str
        cboNhanVien.StoreName = "QL_SEARCH"
        cboNhanVien.BindDataSource()
        If cboNhanVien.Items.Count = 0 Then
            cboNhanVien.Text = ""
        End If
    End Sub

    Private Sub loadCboTo()
        Dim dt, dtLast As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM [TO]"))
        cboTo.DataSource = dt
        cboTo.DisplayMember = "TEN_TO"
        cboTo.ValueMember = "MS_TO1"
    End Sub
    Private intRowCuaBT As Integer = 0
    Sub Enable_Button(ByVal bln As Boolean)
        'Me.btnCapnhatgioNV.Enabled = bln
        Me.btnThemsua.Enabled = bln
        Me.btnXoa.Enabled = bln
        Me.btnTinhcuasobaotri.Enabled = bln
        Me.btnCapnhatthoigiancongviec.Enabled = bln
        'Me.btnPhieubaotri.Enabled = bln
    End Sub

    Sub visible_Button(ByVal bln As Boolean)
        btnThemsua.Visible = bln
        btnXoa.Visible = bln
        btnIn.Visible = bln
        btnThoat.Visible = bln
        BtnChonNV.Visible = Not bln
        btnGhi.Visible = Not bln
        btnKhongghi.Visible = Not bln
        btnCapnhatthoigiancongviec.Visible = Not bln
    End Sub

    Sub lock_button()
        Me.btnThemsua.Enabled = True
        'Me.btnIn.Enabled = False
        If Me.tabControl.SelectedIndex = 0 Then
            If Me.radCongviecchinh.Checked Then
                If Me.grdCongviecchinh.RowCount > 0 Then
                    If grdCongviecchinh.Rows(row_cv_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" Then
                        Me.btnThemsua.Enabled = False
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                    If Me.grdKehoachnhanvien.RowCount > 0 Then
                        Me.btnXoa.Enabled = True
                        Exit Sub
                    Else
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                Else
                    Me.btnThemsua.Enabled = False
                    Me.btnXoa.Enabled = False
                    Exit Sub
                End If
            Else
                If Me.grdCongviecphu.RowCount > 0 Then
                    If grdCongviecphu.Rows(row_cvp_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" Then
                        Me.btnThemsua.Enabled = False
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                    If Me.grdKehoachnhanvien.RowCount > 0 Then
                        Me.btnXoa.Enabled = True
                        Exit Sub
                    Else
                        Me.btnXoa.Enabled = False
                        Exit Sub
                    End If
                Else
                    Me.btnThemsua.Enabled = False
                    Me.btnXoa.Enabled = False
                    Exit Sub
                End If
            End If
        Else
            Me.btnXoa.Enabled = False
            Me.btnThemsua.Enabled = False
            'Me.btnIn.Enabled = True
        End If
    End Sub

    Sub lock_Control(ByVal lock As Boolean)
        'Me.cboLoaithietbi.Enabled = lock
        'Me.cboNhomthietbi.Enabled = lock

        Me.radCongviecchinh.Enabled = lock
        Me.radCongviecphutro.Enabled = lock

        Me.grdCongviecchinh.Enabled = lock
        Me.grdCongviecphu.Enabled = lock
        'Me.grdDanhsachphieubaotri.Enabled = lock
        Me.grdKehoachnhanvien.ReadOnly = lock
        Try
            grdKehoachnhanvien.Columns("MS_CONG_NHAN").Visible = False
            Me.grdKehoachnhanvien.Columns("MS_CONG_NHAN").ReadOnly = True
            Me.grdKehoachnhanvien.Columns("TEN_CONG_NHAN").ReadOnly = True
            Me.grdKehoachnhanvien.Columns("THUE_NGOAI").ReadOnly = True
        Catch ex As Exception
        End Try

        'If Me.tabControl.SelectedIndex = 0 Then
        '    Me.grdKehoachnhanvien.AllowUserToAddRows = Not lock
        'End If
    End Sub

    Sub visible_Control()
        If Me.radCongviecchinh.Checked Then
            Me.grpCongviecchinh.Visible = True
            Me.grdCongviecchinh.Visible = True
            Me.grpCongviecphu.Visible = False
            Me.grdCongviecphu.Visible = False
        Else
            Me.grpCongviecchinh.Visible = False
            Me.grpCongviecphu.Visible = True
            Me.grdCongviecchinh.Visible = False
            Me.grdCongviecphu.Visible = True
        End If

        'binddata_Kehoachcongviec()
        binddata_Kehoachnhanvien()
    End Sub
    Sub binddata_Cuasobaotri()
        Dim objController As New JOBCARD_Controller
        Me.grdCuasobaotri.DataSource = objController.get_Cuasobaotri(cboMS_ThietBi.SelectedValue, Format(dtNgayBDKH.Value, "short date"), Format(dtNgayKTKH.Value, "short date"))

        formatGrid_Cuasobaotri()
    End Sub

    Sub binddata_Congviecchinh()
        Try
            grdCongviecchinh.Columns.Clear()
        Catch ex As Exception

        End Try
        Dim objController As New JOBCARD_Controller
        Me.grdCongviecchinh.DataSource = objController.get_Congviecchinh(txtMaSoPBT.Text, Commons.Modules.UserName)
        formatGrid_Congviecchinh()

        If Me.grdCongviecchinh.RowCount > 0 Then
            Me.row_cv_index = 0
            If Me.radCongviecchinh.Checked Then
                'binddata_Kehoachcongviec()
                binddata_Kehoachnhanvien()
                grdCongviecchinh.Rows(0).Cells("TEN_BO_PHAN").Selected = True
            End If
        Else
            Me.row_cv_index = -1
            Me.grdKehoachnhanvien.DataSource = System.DBNull.Value
            Me.btnThemsua.Enabled = False
            Me.btnXoa.Enabled = False
        End If
    End Sub

    Sub binddata_CongviecPhu()
        Try
            grdCongviecphu.Columns.Clear()
        Catch ex As Exception

        End Try
        Dim objController As New JOBCARD_Controller
        Me.grdCongviecphu.DataSource = objController.get_Congviecphu(txtMaSoPBT.Text)
        formatGrid_Congviecphu()

        If Me.grdCongviecphu.RowCount > 0 Then
            Me.row_cvp_index = 0
            If Me.radCongviecphutro.Checked Then
                'binddata_Kehoachcongviec()
                binddata_Kehoachnhanvien()
            End If
        Else
            Me.row_cvp_index = -1
            Me.grdKehoachnhanvien.DataSource = System.DBNull.Value
            Me.btnThemsua.Enabled = False
            Me.btnXoa.Enabled = False
        End If
    End Sub

    Sub binddata_Kehoachnhanvien()
        Dim objcontroller As New JOBCARD_Controller
        Try
            Me.grdKehoachnhanvien.Columns.Clear()
        Catch ex As Exception
        End Try

        If Me.radCongviecchinh.Checked Then
            If row_cv_index > -1 Then
                If bThem1 Then
                    TBNhanVien = objcontroller.get_Kehoachnhanvien(txtMaSoPBT.Text, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value.ToString, 1)
                Else
                    TBNhanVien = objcontroller.get_Kehoachnhanvien(txtMaSoPBT.Text, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value, Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value.ToString, 0)
                End If
                TBNhanVien.Columns("TEN_CONG_NHAN").ReadOnly = False
                TBNhanVien.Columns("TU_GIO").ReadOnly = False
                TBNhanVien.Columns("THUE_NGOAI").ReadOnly = False
                TBNhanVien.Columns("DEN_GIO").ReadOnly = False
                TBNhanVien.Columns("TU_GIO_TMP").AllowDBNull = True
                TBNhanVien.Columns("DEN_GIO_TMP").AllowDBNull = True
                TBNhanVien.Columns("DEN_GIO_TMP").AllowDBNull = True
                'Dim priCol(4) As DataColumn
                'priCol(0) = TBNhanVien.Columns("MS_CONG_NHAN")
                'priCol(1) = TBNhanVien.Columns("NGAY")
                'priCol(2) = TBNhanVien.Columns("TU_GIO")
                'priCol(3) = TBNhanVien.Columns("DEN_NGAY")
                'priCol(4) = TBNhanVien.Columns("DEN_GIO")
                'TBNhanVien.PrimaryKey = priCol
                Me.grdKehoachnhanvien.DataSource = TBNhanVien
                formatGrid_Kehoachnhanvien()
                grdKehoachnhanvien.Columns("MS_CONG_NHAN").Visible = False
            End If
        Else
            If row_cvp_index > -1 Then
                If bThem Then
                    TBNhanVien = objcontroller.get_Kehoachnhanvienphu(txtMaSoPBT.Text, Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value, 1)
                Else
                    TBNhanVien = objcontroller.get_Kehoachnhanvienphu(txtMaSoPBT.Text, Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value, 0)
                End If
                TBNhanVien.Columns("TEN_CONG_NHAN").ReadOnly = False
                TBNhanVien.Columns("TU_GIO").ReadOnly = False
                TBNhanVien.Columns("THUE_NGOAI").ReadOnly = False
                TBNhanVien.Columns("DEN_GIO").ReadOnly = False
                TBNhanVien.Columns("TU_GIO_TMP").AllowDBNull = True
                TBNhanVien.Columns("DEN_GIO_TMP").AllowDBNull = True
                'taọ khoá cho  lưới
                'Dim priCol(4) As DataColumn
                'priCol(0) = TBNhanVien.Columns("MS_CONG_NHAN")
                'priCol(1) = TBNhanVien.Columns("NGAY")
                'priCol(2) = TBNhanVien.Columns("TU_GIO")
                'priCol(3) = TBNhanVien.Columns("DEN_NGAY")
                'priCol(4) = TBNhanVien.Columns("DEN_GIO")
                'TBNhanVien.PrimaryKey = priCol
                'taọ khoá cho  lưới
                Me.grdKehoachnhanvien.DataSource = TBNhanVien
                grdKehoachnhanvien.Columns("MS_CONG_NHAN").Visible = False
                formatGrid_Kehoachnhanvien()
            End If
            If Me.grdKehoachnhanvien.RowCount > 0 Then
                Me.grdKehoachnhanvien.Rows(0).Cells("TEN_CONG_NHAN").Selected = True
            End If
            lock_button()
        End If
        If radCongviecchinh.Checked Then
            Try
                If grdCongviecchinh.Rows(row_cv_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" And grdCongviecchinh.Rows(row_cv_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "  /  /" Then
                    If cboTinhTrangPBT.SelectedValue < 3 Then
                        btnThemsua.Enabled = True
                        btnXoa.Enabled = True
                    Else
                        btnThemsua.Enabled = False
                        btnXoa.Enabled = False
                    End If
                ElseIf cboTinhTrangPBT.SelectedValue < 3 Then
                    btnThemsua.Enabled = True
                    btnXoa.Enabled = True
                Else
                    btnThemsua.Enabled = False
                    btnXoa.Enabled = False
                End If
            Catch ex As Exception
            End Try
        Else
            Try
                If grdCongviecphu.Rows(row_cvp_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "" And grdCongviecphu.Rows(row_cvp_index).Cells("NGAY_HOAN_THANH").Value.ToString <> "  /  /" Then
                    If cboTinhTrangPBT.SelectedValue < 3 Then
                        btnThemsua.Enabled = True
                        btnXoa.Enabled = True
                    Else
                        btnThemsua.Enabled = False
                        btnXoa.Enabled = False
                    End If
                ElseIf cboTinhTrangPBT.SelectedValue < 3 Then
                    btnThemsua.Enabled = True
                    btnXoa.Enabled = True
                Else
                    btnThemsua.Enabled = False
                    btnXoa.Enabled = False
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub
    Sub formatGrid_Cuasobaotri()
        With Me.grdCuasobaotri
            .Columns("THU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FROM_HOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TO_HOUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        End With
        refresh_Language_CSBT()
    End Sub

    Sub refresh_Language_CSBT()
        With Me.grdCuasobaotri
            .Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            .Columns("THU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THU", Commons.Modules.TypeLanguage)
            .Columns("FROM_HOUR").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
            .Columns("TO_HOUR").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub formatGrid_Congviecchinh()
        Dim col As New Commons.QLGridMaskedTextBoxColumn()
        col.Name = "cboNgay"
        col.DataPropertyName = "NGAY_HOAN_THANH"
        col.Mask = "00/00/0000"
        Me.grdCongviecchinh.Columns.Insert(6, col)
        With Me.grdCongviecchinh
            .Columns("MS_CV").Visible = False
            .Columns("MS_MAY").Visible = False
            .Columns("MS_BO_PHAN").Visible = False
            .Columns("NGAY_HOAN_THANH").Visible = False
            .Columns("TEN_LOAI_CV").Visible = False

            '.Columns("MO_TA_CV").Width = 200
            .Columns("SO_GIO_KH").Width = 80
            .Columns("TEN_BO_PHAN").Width = 200
            .Columns("TEN_LOAI_CV").Width = 150
            .Columns("MO_TA_CV").Width = 250
            '.Columns("MO_TA_CV").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        End With
        refresh_Language_CVC()
    End Sub

    Sub refresh_Language_CVC()
        With Me.grdCongviecchinh
            .Columns("MO_TA_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_CV", Commons.Modules.TypeLanguage)
            .Columns("MO_TA_CV").ReadOnly = True
            .Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
            .Columns("TEN_BO_PHAN").ReadOnly = True
            .Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
            .Columns("SO_GIO_KH").ReadOnly = True
            .Columns("TEN_LOAI_CV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_LOAI_CV", Commons.Modules.TypeLanguage)
            .Columns("TEN_LOAI_CV").ReadOnly = True
            .Columns("cboNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_HOAN_THANH", Commons.Modules.TypeLanguage)
            .Columns("cboNgay").ReadOnly = False
        End With
    End Sub

    Sub formatGrid_Congviecphu()
        Dim col As New Commons.QLGridMaskedTextBoxColumn()
        col.Name = "cboNgay"
        col.DataPropertyName = "NGAY_HOAN_THANH"
        col.Mask = "00/00/0000"
        Me.grdCongviecphu.Columns.Insert(3, col)
        With Me.grdCongviecphu
            .Columns("STT").Visible = False
            .Columns("NGAY_HOAN_THANH").Visible = False
            '.Columns("TEN_CONG_VIEC").Width = 200
            .Columns("TEN_CONG_VIEC").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("SO_GIO_KH").Width = 80
            .Columns("cboNgay").Width = 80
            .Columns("SO_GIO_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        End With
        refresh_Language_CVP()
    End Sub

    Sub refresh_Language_CVP()
        With Me.grdCongviecphu
            .Columns("TEN_CONG_VIEC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CONG_VIEC", Commons.Modules.TypeLanguage)
            .Columns("TEN_CONG_VIEC").ReadOnly = True
            .Columns("SO_GIO_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_GIO_KH", Commons.Modules.TypeLanguage)
            .Columns("SO_GIO_KH").ReadOnly = True
            .Columns("cboNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_HOAN_THANH", Commons.Modules.TypeLanguage)
            .Columns("cboNgay").ReadOnly = False
        End With
    End Sub

    Sub formatGrid_Kehoachnhanvien()
        loadcbo_CN()
        With Me.grdKehoachnhanvien
            .Columns("DEN_NGAY").Visible = False
            .Columns("NGAY").Visible = False
            .Columns("TU_GIO").Visible = False
            .Columns("DEN_GIO").Visible = False
            .Columns("TU_GIO_TMP").Visible = False
            .Columns("DEN_GIO_TMP").Visible = False
            .Columns("NGAY_TMP").Visible = False
            .Columns("MS_CN").Visible = False
            .Columns("THUE_NGOAI").Visible = False
            .Columns("HOAN_THANH").Visible = False
            .Columns("TEN_CONG_NHAN").Width = 140
            .Columns("cboNgay").Width = 80
            .Columns("cboTu_gio").Width = 60
            .Columns("cboDen_gio").Width = 60
            .Columns("THUE_NGOAI").Width = 80
            .Columns("TU_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("DEN_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            .Columns("TEN_CONG_NHAN").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        refresh_Language_KHNV()
    End Sub

    Sub loadcbo_CN()
        Dim col As New Commons.QLGridMaskedTextBoxColumn()

        col.Name = "cboNgay"
        col.DataPropertyName = "NGAY"
        col.Mask = "00/00/0000"
        Me.grdKehoachnhanvien.Columns.Insert(4, col)

        Dim col1 As New Commons.QLGridMaskedTextBoxColumn
        col1.Name = "cboTu_gio"
        col1.DataPropertyName = "TU_GIO"
        col1.Mask = "00:00"
        col1.DefaultCellStyle.Format = "HH:mm"
        col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grdKehoachnhanvien.Columns.Insert(5, col1)

        Dim col3 As New Commons.QLGridMaskedTextBoxColumn()

        col3.Name = "cboDenNgay"
        col3.DataPropertyName = "DEN_NGAY"
        col3.Mask = "00/00/0000"
        Me.grdKehoachnhanvien.Columns.Insert(7, col3)

        Dim col2 As New Commons.QLGridMaskedTextBoxColumn
        col2.Name = "cboDen_gio"
        col2.DataPropertyName = "DEN_GIO"
        col2.Mask = "00:00"
        col2.DefaultCellStyle.Format = "HH:mm"
        col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grdKehoachnhanvien.Columns.Insert(8, col2)
    End Sub

    Sub refresh_Language_KHNV()
        With Me.grdKehoachnhanvien
            .Columns("cboDenNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
            .Columns("THUE_NGOAI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THUE_NGOAI", Commons.Modules.TypeLanguage)
            .Columns("TEN_CONG_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CONG_NHAN", Commons.Modules.TypeLanguage)
            .Columns("MS_CONG_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_CONG_NHAN", Commons.Modules.TypeLanguage)
            .Columns("cboNgay").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            .Columns("cboTu_gio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
            .Columns("cboDen_gio").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
            .Columns("HOAN_THANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HOAN_THANH", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub refresh_Language_Form()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.lblMS_ThietBi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblMS_ThietBi", Commons.Modules.TypeLanguage)
        Me.radCongviecchinh.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "radCongviecchinh", Commons.Modules.TypeLanguage)
        Me.radCongviecphutro.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "radCongviecphutro", Commons.Modules.TypeLanguage)
        Me.btnThemsua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnThemsua", Commons.Modules.TypeLanguage)
        Me.btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnGhi", Commons.Modules.TypeLanguage)
        Me.btnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnKhongghi", Commons.Modules.TypeLanguage)
        Me.btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnXoa", Commons.Modules.TypeLanguage)
        Me.btnIn.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnIn", Commons.Modules.TypeLanguage)
        'Me.btnPhieubaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "btnPhieubaotri", commons.Modules.TypeLanguage)
        Me.btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnThoat", Commons.Modules.TypeLanguage)
        Me.btnTinhcuasobaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnTinhcuasobaotri", Commons.Modules.TypeLanguage)
        'Me.btnCapnhatgioNV.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "btnCapnhatgioNV", commons.Modules.TypeLanguage)
        Me.btnCapnhatthoigiancongviec.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnCapnhatthoigiancongviec", Commons.Modules.TypeLanguage)

        Me.grpCongviecchinh.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpCongviecchinh", Commons.Modules.TypeLanguage)
        Me.grpCongviecphu.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpCongviecphu", Commons.Modules.TypeLanguage)
        Me.grpCuasobaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grpCuasobaotri", Commons.Modules.TypeLanguage)
        'Me.grpDanhsachphieubaotri.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "grpDanhsachphieubaotri", commons.Modules.TypeLanguage)
        Me.tabBaocao.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "tabBaocao", Commons.Modules.TypeLanguage)
        'Me.tabCongviec.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "tabCongviec", commons.Modules.TypeLanguage)
        Me.tabNhanvien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "tabNhanvien", Commons.Modules.TypeLanguage)

        Me.lblDanhsachbaocao.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblDanhsachbaocao", Commons.Modules.TypeLanguage)

        Me.lblTungay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTungay", Commons.Modules.TypeLanguage)
        Me.lblDenngay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblDenngay", Commons.Modules.TypeLanguage)
        Me.lblTo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTo", Commons.Modules.TypeLanguage)
        Me.lblNhanvien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNhanvien", Commons.Modules.TypeLanguage)
        'Me.lblTonggio.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "lblTonggio", commons.Modules.TypeLanguage)
    End Sub
    Private Sub cboCN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(cboCN.Text) Then Exit Sub
        If cboCN.Text = "" Then Exit Sub
        Try
            Me.grdKehoachnhanvien.CurrentRow.Cells("cbo_CN").Value = cboCN.SelectedValue
            Dim str As String = ""
            str = "SELECT HO+' '+TEN AS HO_TEN FROM CONG_NHAN WHERE MS_CONG_NHAN='" & cboCN.SelectedValue & "'"
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While objReader.Read
                Me.grdKehoachnhanvien.CurrentRow.Cells("TEN_CONG_NHAN").Value = objReader.Item("HO_TEN").ToString
            End While
            objReader.Close()

        Catch ex As Exception

        End Try

    End Sub
#End Region



    Private Sub btnTinhcuasobaotri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTinhcuasobaotri.Click
        If txtMaSoPBT.Text = "" Then Exit Sub

        binddata_Cuasobaotri()
        If btnGhi.Visible Then
            If grdCuasobaotri.Rows.Count > 0 Then
                btnCapnhatthoigiancongviec.Visible = True
            Else
                btnCapnhatthoigiancongviec.Visible = False
            End If
        End If
    End Sub

    Private Sub btnCapnhatthoigiancongviec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapnhatthoigiancongviec.Click
        If btnGhi.Visible Then
            If cboTinhTrangPBT.SelectedValue < 4 Then
                For i As Integer = 0 To grdKehoachnhanvien.Rows.Count - 1
                    If i <> intRowCN Then
                        If grdKehoachnhanvien.Rows(intRowCN).Cells("MS_CONG_NHAN").Value = grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value Then
                            If Format(grdCuasobaotri.Rows(intRowCuaBT).Cells("NGAY").Value, "Short date") = Format(grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value, "Short date") And grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value = grdCuasobaotri.Rows(intRowCuaBT).Cells("FROM_HOUR").Value Then
                                'XtraMessageBox.Show("Không thể cập nhật thời gian này vì đã tồn tại. Vui lòng chọn thời gian khác")
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGian1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                Exit Sub
                            End If
                        End If
                    End If
                Next
                If grdKehoachnhanvien.Rows.Count > 0 Then
                    grdKehoachnhanvien.Rows(intRowCN).Cells("cboDen_gio").Value = grdCuasobaotri.Rows(intRowCuaBT).Cells("TO_HOUR").Value
                    grdKehoachnhanvien.Rows(intRowCN).Cells("cboTu_gio").Value = grdCuasobaotri.Rows(intRowCuaBT).Cells("FROM_HOUR").Value
                    grdKehoachnhanvien.Rows(intRowCN).Cells("cboNgay").Value = Format(grdCuasobaotri.Rows(intRowCuaBT).Cells("NGAY").Value, "Short date")
                    grdKehoachnhanvien.Rows(intRowCN).Cells("cboDenNgay").Value = Format(grdCuasobaotri.Rows(intRowCuaBT).Cells("NGAY").Value, "Short date")
                End If
            End If
        End If
    End Sub

    Private Sub btnThemsua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemsua.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        If cboTinhTrangPBT.SelectedValue = 3 Then
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPhieuBaoTri As New clsPHIEU_BAO_TRIController()
                objPhieuBaoTri.UpdatePHIEU_BAO_TRI_TINH_TRANGs(txtMaSoPBT.Text, 2)
                Dim strs As String = ""
                strs = "DELETE FROM  PHIEU_BAO_TRI_CHI_PHI  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, strs)
                strs = "UPDATE PHIEU_BAO_TRI SET TT_SAU_BT=NULL,NGAY_NGHIEM_THU=NULL,NGUOI_NGHIEM_THU=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, strs)
                strs = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET MS_MAY_TT=NULL ,MS_BO_PHAN_TT=NULL,PHU_TUNG_TT=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, strs)
                cboTinhTrangPBT.SelectedValue = 2
                bHuyNT = 1
            Else
                Exit Sub
            End If
        End If
        If radCongviecchinh.Checked Then
            If grdCongviecchinh.Rows.Count = 0 Then
                Exit Sub
            End If
        Else
            If grdCongviecphu.Rows.Count = 0 Then
                Exit Sub
            End If
        End If

        Dim str As String = ""
        Try
            str = "DROP TABLE tmpPhanBoNhanVien" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.tmpPhanBoNhanVien" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT,MS_BO_PHAN NVARCHAR(50), MS_CONG_NHAN NVARCHAR(9),TU_GIO NVARCHAR(5),TU_NGAY NVARCHAR(10),DEN_GIO NVARCHAR(5),DEN_NGAY NVARCHAR(10),DONG INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        If radCongviecchinh.Checked Then
            str = "INSERT INTO tmpPhanBoNhanVien" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_CONG_NHAN,TU_GIO,TU_NGAY,DEN_GIO,DEN_NGAY)  SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_CONG_NHAN,CONVERT(NVARCHAR(5),TU_GIO,114),CONVERT(NVARCHAR(10),NGAY,103),CONVERT(NVARCHAR(5),DEN_GIO,114),CONVERT(NVARCHAR(10),DEN_NGAY ,103) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        Else
            str = "INSERT INTO tmpPhanBoNhanVien" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_CONG_NHAN,TU_GIO,TU_NGAY,DEN_GIO,DEN_NGAY)  SELECT MS_PHIEU_BAO_TRI,STT as MS_CV,NULL,MS_CONG_NHAN,CONVERT(NVARCHAR(5),TU_GIO,114),CONVERT(NVARCHAR(10),NGAY,103),CONVERT(NVARCHAR(5),DEN_GIO,114),CONVERT(NVARCHAR(10),DEN_NGAY ,103) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        bThem1 = True
        bThem = 3
        If grdCuasobaotri.Rows.Count > 0 Then
            btnCapnhatthoigiancongviec.Visible = True
        Else
            btnCapnhatthoigiancongviec.Visible = False
        End If
        binddata_Kehoachnhanvien()
        visible_Button(False)
        lock_Control(False)
        AddHandler grdKehoachnhanvien.RowValidating, AddressOf Me.grdKehoachnhanvien_RowValidating
        AddHandler grdKehoachnhanvien.CellValidating, AddressOf Me.grdKehoachnhanvien_CellValidating
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub

        Dim jobcardinfo As New clsJobCardInfo()
        Dim jobcardcontroller As New JOBCARD_Controller

        If Me.tabControl.SelectedIndex = 0 Then
            ' Xóa kế hoạch công nhân công việc
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa_CNCV", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                If grdKehoachnhanvien.RowCount > 0 Then
                    jobcardinfo.PHIEU_BT = txtMaSoPBT.Text
                    jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(intRowCN).Cells("MS_CONG_NHAN").Value
                    jobcardinfo.NGAY = Me.grdKehoachnhanvien.Rows(intRowCN).Cells("NGAY").Value
                    If Me.radCongviecchinh.Checked Then
                        jobcardinfo.TU_GIO = Me.grdKehoachnhanvien.Rows(intRowCN).Cells("TU_GIO_TMP").Value
                        ' Xóa kế hoạch công nhân công việc chính
                        jobcardinfo.CONG_VIEC = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value
                        jobcardinfo.BO_PHAN = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value

                        jobcardcontroller.delete_congnhancongviecchinh(jobcardinfo)
                    Else
                        jobcardinfo.TU_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(intRowCN).Cells("TU_GIO_TMP").Value)
                        ' Xóa kế hoạch công nhân công việc phụ
                        jobcardinfo.STT = Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value

                        jobcardcontroller.delete_congnhancongviecphu(jobcardinfo)
                    End If
                End If
            End If
        End If

        'binddata_Kehoachcongviec()
        binddata_Kehoachnhanvien()
    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        If txtMaSoPBT.Text.Trim = "" Then Exit Sub
        Commons.clsXuLy.CreateTitleReport()
        CreateData()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Try
            bThoat = True
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    Function KiemTraPhanBoNhanVien() As Boolean
        For k As Integer = 0 To grdKehoachnhanvien.Rows.Count - 1
            If (grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString = "" Or grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString = "  /  /") Then
                If (grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString <> "  /  /") Then
                    'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgPCTrungThoiGian", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGianChuaNhapDayDu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        grdKehoachnhanvien.CurrentCell() = grdKehoachnhanvien.Rows(k).Cells("cboNgay")
                        grdKehoachnhanvien.Focus()
                        Return False
                    Else
                        Exit For
                    End If
                End If
            ElseIf (grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString = "" Or grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString = "  :") Then
                If (grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString <> "  /  /") Then
                    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGianChuaNhapDayDu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        grdKehoachnhanvien.CurrentCell() = grdKehoachnhanvien.Rows(k).Cells("cboTu_gio")
                        grdKehoachnhanvien.Focus()
                        Return False
                    Else
                        Exit For
                    End If
                End If
            ElseIf (grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString = "" Or grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString = "  /  /") Then
                If (grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString <> "  /  /") Then
                    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGianChuaNhapDayDu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        grdKehoachnhanvien.CurrentCell() = grdKehoachnhanvien.Rows(k).Cells("cboDenNgay")
                        grdKehoachnhanvien.Focus()
                        Return False
                    Else
                        Exit For
                    End If
                End If
            ElseIf (grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString = "" Or grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString = "  :") Then
                If (grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString <> "  /  /") Or (grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString <> "  /  /") Then
                    If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThoiGianChuaNhapDayDu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        grdKehoachnhanvien.CurrentCell() = grdKehoachnhanvien.Rows(k).Cells("cboDen_gio")
                        grdKehoachnhanvien.Focus()
                        Return False
                    End If
                Else
                    Exit For
                End If
            End If
        Next
        Dim str As String = ""
        'Try
        '    str = "drop table tmpPhanBoNhanVien" & Commons.Modules.UserName
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'Catch ex As Exception
        'End Try
        'str = "Create table dbo.tmpPhanBoNhanVien" & Commons.Modules.UserName & "( MS_CONG_NHAN NVARCHAR(9),NGAY NVARCHAR(10),TU_GIO NVARCHAR(5),DEN_NGAY NVARCHAR(10), DEN_GIO NVARCHAR(5),DONG INT)"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "Delete from tmpPhanBoNhanVien" & Commons.Modules.UserName & " where MS_PHIEU_BAO_TRI IS NULL OR ( MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "'"
        If radCongviecchinh.Checked Then
            str = str + " and MS_CV=" & grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value & "')"
        Else
            str = str + " and MS_CV=" & grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value & ")"
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim i As Integer
        For i = 0 To grdKehoachnhanvien.Rows.Count - 1
            'If IsDate(grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value) = False Or IsDate(grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value) = False Then
            '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DL_NGAY", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            '    Return False
            'End If
            If grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "  /  /" And (grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "  :") And (grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "  /  /") And (grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "  :") Then
                str = "Insert into tmpPhanBoNhanVien" & Commons.Modules.UserName & "(MS_CONG_NHAN,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO,DONG) VALUES(N'" & grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value & "','" & grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value & "','" & grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value & "','" & grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value & "','" & grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value & "'," & i & ")"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        Next
        str = "SELECT MIN(CONVERT(DATETIME,TU_NGAY,103)) AS NGAY ,MAX(CONVERT(DATETIME,DEN_NGAY,103))AS DEN_NGAY FROM tmpPhanBoNhanVien" & Commons.Modules.UserName
        Dim objRead As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim tu_ngay As String = "", den_ngay As String = ""
        While objRead.Read
            tu_ngay = objRead.Item("NGAY").ToString
            den_ngay = objRead.Item("DEN_NGAY").ToString
        End While
        objRead.Close()
        If tu_ngay <> "" Then
            If radCongviecchinh.Checked Then
                str = " INSERT INTO tmpPhanBoNhanVien" & Commons.Modules.UserName & "(MS_CONG_NHAN,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO) SELECT    MS_CONG_NHAN,CONVERT(NVARCHAR(10),NGAY,103) AS NGAY,CONVERT(NVARCHAR(5),TU_GIO,114) AS TU_GIO,CONVERT(NVARCHAR(10),DEN_NGAY,103) AS DEN_NGAY,CONVERT(NVARCHAR(5),DEN_GIO,114) AS DEN_GIO  FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET " &
                " WHERE (NGAY BETWEEN CONVERT(DATETIME,'" & tu_ngay & "',103) AND CONVERT(DATETIME,'" & den_ngay & "',103)" &
                " OR DEN_NGAY BETWEEN CONVERT(DATETIME,'" & tu_ngay & "',103) AND  CONVERT(DATETIME,'" & den_ngay & "',103)) AND MS_PHIEU_BAO_TRI <>'" & txtMaSoPBT.Text & "'"
            Else
                str = " INSERT INTO tmpPhanBoNhanVien" & Commons.Modules.UserName & "(MS_CONG_NHAN,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO) SELECT    MS_CONG_NHAN,CONVERT(NVARCHAR(10),NGAY,103) AS NGAY,CONVERT(NVARCHAR(5),TU_GIO,114) AS TU_GIO,CONVERT(NVARCHAR(10),DEN_NGAY,103) AS DEN_NGAY,CONVERT(NVARCHAR(5),DEN_GIO,114) AS DEN_GIO FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO " &
                            " WHERE (NGAY BETWEEN CONVERT(DATETIME,'" & tu_ngay & "',103) AND CONVERT(DATETIME,'" & den_ngay & "',103)" &
                            " OR DEN_NGAY BETWEEN CONVERT(DATETIME,'" & tu_ngay & "',103) AND  CONVERT(DATETIME,'" & den_ngay & "',103)) AND MS_PHIEU_BAO_TRI <>'" & txtMaSoPBT.Text & "'"
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Dim tb As New DataTable()
            str = "select MS_CONG_NHAN,CONVERT(DATETIME,TU_NGAY,103) AS NGAY,CONVERT(DATETIME,TU_GIO,114) AS TU_GIO,CONVERT(DATETIME,DEN_NGAY,103)AS DEN_NGAY,CONVERT(DATETIME,DEN_GIO,114) AS DEN_GIO,DONG from tmpPhanBoNhanVien" & Commons.Modules.UserName & " order by MS_CONG_NHAN,NGAY,TU_GIO"
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            For i = 0 To tb.Rows.Count - 1
                For j As Integer = i + 1 To tb.Rows.Count - 1
                    If tb.Rows(i).Item("MS_CONG_NHAN").ToString = tb.Rows(j).Item("MS_CONG_NHAN").ToString Then
                        If Date.Parse(Format(tb.Rows(j).Item("NGAY"), "Short date") + " " + Format(tb.Rows(j).Item("TU_GIO"), "Long time")) >= Date.Parse(Format(tb.Rows(i).Item("NGAY"), "Short date") + " " + Format(tb.Rows(i).Item("TU_GIO"), "Long time")) And Date.Parse(Format(tb.Rows(j).Item("NGAY"), "Short date") + " " + Format(tb.Rows(j).Item("TU_GIO"), "Long time")) < Date.Parse(Format(tb.Rows(i).Item("DEN_NGAY"), "Short date") + " " + Format(tb.Rows(i).Item("DEN_GIO"), "Long time")) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPCTrungThoiGian", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            grdKehoachnhanvien.CurrentCell() = grdKehoachnhanvien.Rows(IIf(tb.Rows(j).Item("DONG").ToString = "", IIf(tb.Rows(i).Item("DONG").ToString = "", 0, tb.Rows(i).Item("DONG")), tb.Rows(j).Item("DONG"))).Cells("cboDen_gio")
                            grdKehoachnhanvien.Focus()
                            Return False
                        End If
                    End If
                Next
            Next
        End If
        Return True
    End Function
    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        If Not KiemTraPhanBoNhanVien() Then
            Exit Sub
        End If
        For k As Integer = 0 To Me.grdKehoachnhanvien.RowCount - 1
            Try
                If Convert.ToDateTime(grdKehoachnhanvien.Rows(k).Cells("cboNgay").Value.ToString().Trim() & " " & grdKehoachnhanvien.Rows(k).Cells("cboTu_gio").Value.ToString().Trim()) > Convert.ToDateTime(grdKehoachnhanvien.Rows(k).Cells("cboDenNgay").Value.ToString().Trim() & " " & grdKehoachnhanvien.Rows(k).Cells("cboDen_gio").Value.ToString().Trim()) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDateTimeError", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDateTimeError", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End Try
        Next
        Dim jobcardinfo As New clsJobCardInfo()
        Dim jobcardcontroller As New JOBCARD_Controller

        If Me.tabControl.SelectedIndex = 0 Then
            ' Lưu kế hoạch nhân viên
            If Me.radCongviecchinh.Checked Then
                ' Kế hoạch nhân viên cho công việc chính
                Dim dtReader As SqlDataReader
                jobcardinfo.PHIEU_BT = txtMaSoPBT.Text
                jobcardinfo.CONG_VIEC = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_CV").Value
                jobcardinfo.BO_PHAN = Me.grdCongviecchinh.Rows(row_cv_index).Cells("MS_BO_PHAN").Value
                For i As Integer = 0 To Me.grdKehoachnhanvien.RowCount - 1
                    If Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value.ToString <> "" Or Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO_TMP").Value.ToString <> "" Then
                        If grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "  /  /" And (grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "  :") And (grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "  /  /") And (grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "  :") Then
                            jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                            jobcardinfo.NGAY = Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date")
                            jobcardinfo.DEN_NGAY = Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_NGAY").Value, "short date")
                            jobcardinfo.TU_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value, "Long time")
                            jobcardinfo.DEN_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value, "Long time")
                            jobcardinfo.CONG_NHAN_tmp = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CN").Value
                            jobcardinfo.NGAY_tmp = Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY_TMP").Value, "short date")
                            jobcardinfo.TU_GIO_tmp = Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value
                            jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                            jobcardcontroller.update_congnhancongviec_PBT(jobcardinfo)
                            jobcardcontroller.update_congnhancongviecchinh(jobcardinfo)
                        End If
                    Else
                        'If (Me.grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString = "  :") And (Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value.ToString = "  :") Then
                        '    Continue For
                        'End If
                        If grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "  /  /" And (grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "  :") And (grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "  /  /") And (grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "  :") Then
                            jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                            jobcardinfo.NGAY = Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date")
                            jobcardinfo.DEN_NGAY = Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_NGAY").Value, "short date")
                            jobcardinfo.TU_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value, "Long time")
                            jobcardinfo.DEN_GIO = Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value, "Long time")
                            jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_PBT_CV_NS", jobcardinfo.PHIEU_BT, jobcardinfo.CONG_VIEC, jobcardinfo.BO_PHAN, jobcardinfo.CONG_NHAN)
                            If Not dtReader.HasRows Then
                                jobcardcontroller.add_congnhancongviec_PBT(jobcardinfo)
                            End If
                            jobcardcontroller.add_congnhancongviecchinh(jobcardinfo)
                        End If
                    End If

                Next
            Else
                ' Kế hoạch nhân viên cho công việc phụ
                jobcardinfo.PHIEU_BT = txtMaSoPBT.Text
                jobcardinfo.STT = Me.grdCongviecphu.Rows(row_cvp_index).Cells("STT").Value
                For i As Integer = 0 To Me.grdKehoachnhanvien.RowCount - 1
                    If Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value.ToString <> "" Or Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO_TMP").Value.ToString <> "" Then
                        jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                        jobcardinfo.NGAY = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date"))
                        jobcardinfo.DEN_NGAY = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_NGAY").Value, "short date"))
                        jobcardinfo.TU_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value)
                        jobcardinfo.DEN_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value)
                        jobcardinfo.CONG_NHAN_tmp = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CN").Value
                        jobcardinfo.NGAY_tmp = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY_TMP").Value, "short date"))
                        jobcardinfo.TU_GIO_tmp = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO_TMP").Value)
                        jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                        jobcardcontroller.update_congnhancongviecphu(jobcardinfo)
                    Else
                        If grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value.ToString <> "  /  /" And (grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboTu_gio").Value.ToString <> "  :") And (grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value.ToString <> "  /  /") And (grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "" And grdKehoachnhanvien.Rows(i).Cells("cboDen_gio").Value.ToString <> "  :") Then
                            jobcardinfo.CONG_NHAN = Me.grdKehoachnhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                            jobcardinfo.NGAY = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("NGAY").Value, "short date"))
                            jobcardinfo.DEN_NGAY = Date.Parse(Format(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_NGAY").Value, "short date"))
                            jobcardinfo.TU_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("TU_GIO").Value)
                            jobcardinfo.DEN_GIO = Date.Parse(Me.grdKehoachnhanvien.Rows(i).Cells("DEN_GIO").Value)
                            jobcardinfo.HOAN_THANH = IIf(IsDBNull(Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value), False, Me.grdKehoachnhanvien.Rows(i).Cells("HOAN_THANH").Value)
                            jobcardcontroller.add_congnhancongviecphu(jobcardinfo)
                        End If
                    End If
                Next
            End If
        End If
        bThem1 = False
        bThem = -1
        visible_Button(True)
        lock_Control(True)
        RemoveHandler grdKehoachnhanvien.RowValidating, AddressOf Me.grdKehoachnhanvien_RowValidating
        RemoveHandler grdKehoachnhanvien.CellValidating, AddressOf Me.grdKehoachnhanvien_CellValidating
        binddata_Kehoachnhanvien()
        btnCapnhatthoigiancongviec.Visible = False
        Dim str As String = ""
        Try
            str = "DROP TABLE tmpNhanVien" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE tmpPhanBoNhanVien" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongghi.Click
        RemoveHandler grdKehoachnhanvien.RowValidating, AddressOf Me.grdKehoachnhanvien_RowValidating
        RemoveHandler grdKehoachnhanvien.CellValidating, AddressOf Me.grdKehoachnhanvien_CellValidating
        bThem1 = False
        bThem = -1
        visible_Button(True)
        lock_Control(True)
        binddata_Kehoachnhanvien()
        btnCapnhatthoigiancongviec.Visible = False
        Dim str As String = ""
        Try
            str = "DROP TABLE tmpNhanVien" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        Try
            str = "DROP TABLE tmpPhanBoNhanVien" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub radCongviecchinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles radCongviecchinh.CheckedChanged
        visible_Control()
    End Sub

    Private Sub grdCongviecchinh_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdCongviecchinh.CellBeginEdit
        'grdCongviecchinh.Rows(e.RowIndex).Cells("cboNgay").ReadOnly = btnThemsua.Visible
    End Sub

    Private Sub grdCongviecchinh_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecchinh.CellValidated
        If grdCongviecchinh.Columns(e.ColumnIndex).Name = "cboNgay" Then
            If Not bCapnhat Then
                grdCongviecchinh.Rows(e.RowIndex).Cells("cboNgay").Value = DBNull.Value
                bCapnhat = True
            End If
        End If
    End Sub

    Private Sub grdCongviecchinh_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCongviecchinh.CellValidating
        Try
            If grdCongviecchinh.Columns(e.ColumnIndex).Name = "cboNgay" Then
                If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                    If Not IsDate(e.FormattedValue) Then
                        'XtraMessageBox.Show("Ngày hoàn thành nhập không hợp lệ")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHoanThanh", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdCongviecchinh.Rows(e.RowIndex).ErrorText = "Error"
                        grdCongviecchinh.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                        grdCongviecchinh.Focus()
                        e.Cancel = True
                        Exit Sub
                    Else
                        Dim str As String = ""
                        Dim objReader As SqlDataReader
                        str = "SELECT NGAY_HOAN_THANH FROM  PHIEU_BAO_TRI_CONG_VIEC  WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                                                                      "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        While objReader.Read
                            If objReader.Item("NGAY_HOAN_THANH").ToString <> "" Then
                                If Format(objReader.Item("NGAY_HOAN_THANH"), "Short date") <> Format(e.FormattedValue, "Short date") Then
                                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                                                                                  "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                    grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                                End If
                                objReader.Close()
                                Exit Sub
                            End If
                        End While
                        str = "SELECT MS_CONG_NHAN from PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE HOAN_THANH=1 AND MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                        "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                        objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        Dim tmp As Boolean = False
                        While objReader.Read
                            If objReader.Item("MS_CONG_NHAN").ToString <> "" Then
                                tmp = True
                                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                                                  "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                                btnThemsua.Enabled = False
                                btnXoa.Enabled = False
                                objReader.Close()
                                Exit Sub
                            End If
                        End While
                        objReader.Close()
                        If Not tmp Then
                            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgghi", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                            If Traloi = vbNo Then
                                grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                                bCapnhat = False
                                Exit Sub
                            Else
                                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                       "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                                btnThemsua.Enabled = False
                                btnXoa.Enabled = False
                            End If
                        End If
                    End If
                Else
                    Dim str As String = ""
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                        "' AND MS_CV=" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & grdCongviecchinh.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    grdCongviecchinh.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                    btnThemsua.Enabled = True
                    btnXoa.Enabled = True
                End If
            End If
            grdCongviecchinh.Rows(e.RowIndex).ErrorText = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdCongviecchinh_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecchinh.RowEnter
        row_cv_index = e.RowIndex
        If Me.radCongviecchinh.Checked Then
            binddata_Kehoachnhanvien()
        End If
    End Sub
    Private bCapnhat1 As Boolean = True
    Private Sub grdCongviecphu_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecphu.CellValidated
        If grdCongviecphu.Columns(e.ColumnIndex).Name = "cboNgay" Then
            If Not bCapnhat1 Then
                grdCongviecphu.Rows(e.RowIndex).Cells("cboNgay").Value = DBNull.Value
                bCapnhat1 = True
            End If
        End If
    End Sub

    Private Sub grdCongviecphu_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCongviecphu.CellValidating
        If grdCongviecphu.Columns(e.ColumnIndex).Name = "cboNgay" Then
            If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                If Not IsDate(e.FormattedValue) Then
                    'XtraMessageBox.Show("Ngày hoàn thành nhập không hợp lệ")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayhoanThanh", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    grdCongviecphu.Rows(e.RowIndex).ErrorText = "Error"
                    grdCongviecphu.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                    grdCongviecphu.Focus()
                    e.Cancel = True
                    Exit Sub
                Else
                    Dim str As String = ""
                    Dim objReader As SqlDataReader
                    str = "SELECT NGAY_HOAN_THANH FROM PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    While objReader.Read
                        If objReader.Item("NGAY_HOAN_THANH").ToString <> "" Then
                            If Format(objReader.Item("NGAY_HOAN_THANH"), "Short date") <> Format(e.FormattedValue, "Short date") Then
                                str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                                                "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            End If
                            objReader.Close()
                            Exit Sub
                        End If
                    End While
                    objReader.Close()
                    str = "SELECT MS_CONG_NHAN from PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO wHERE HOAN_THANH=1 AND MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    Dim tmp As Boolean = False
                    While objReader.Read
                        If objReader.Item("MS_CONG_NHAN").ToString <> "" Then
                            tmp = True
                            str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            btnThemsua.Enabled = False
                            btnXoa.Enabled = False
                            objReader.Close()
                            Exit Sub
                        End If
                    End While
                    objReader.Close()
                    If Not tmp Then
                        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgghi", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                        If Traloi = vbNo Then
                            grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                            bCapnhat1 = False
                            Exit Sub
                        Else
                            str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" & e.FormattedValue & "',103) WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                                                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = Date.Parse(e.FormattedValue)
                            btnThemsua.Enabled = False
                            btnXoa.Enabled = False
                        End If
                    End If
                End If
            Else
                Dim str As String = ""
                str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=NULL WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text &
                    "' AND STT=" & grdCongviecphu.Rows(e.RowIndex).Cells("STT").Value
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value = DBNull.Value
                btnThemsua.Enabled = True
                btnXoa.Enabled = True
            End If
        End If
        grdCongviecphu.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub grdCongviecphu_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCongviecphu.RowEnter
        row_cvp_index = e.RowIndex
        If Me.radCongviecphutro.Checked Then
            binddata_Kehoachnhanvien()
            Try
                If grdCongviecphu.Rows(e.RowIndex).Cells("NGAY_HOAN_THANH").Value.ToString <> "" Then
                    btnThemsua.Enabled = False
                    btnXoa.Enabled = False
                Else
                    btnThemsua.Enabled = True
                    btnXoa.Enabled = True
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub grdKehoachnhanvien_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles grdKehoachnhanvien.CellValidating
        If Me.btnKhongghi.Focused Then
            Exit Sub
        End If

        If Me.grdKehoachnhanvien.Rows(e.RowIndex).IsNewRow Then Exit Sub

        If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("TU_GIO_tmp").Value.ToString <> "" Then
            Select Case Me.grdKehoachnhanvien.Columns(e.ColumnIndex).Name
                Case "cboTu_gio"
                    If e.FormattedValue = "" Or e.FormattedValue = "  :" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Invalid", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                    TU_GIO_TMP = e.FormattedValue
                Case "cboDen_gio"
                    If e.FormattedValue = "" Or e.FormattedValue = "  :" Then
                        If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "  :" Then Exit Sub
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDen_gio_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDen_gio_Invalid", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            e.Cancel = True
                            Exit Sub

                        End If
                    End If
                Case "cboNgay"
                    If e.FormattedValue = "" Or e.FormattedValue = "  /  /" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgay_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                        grdKehoachnhanvien.Focus()
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                            grdKehoachnhanvien.Focus()
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                Case "cboDenNgay"
                    If e.FormattedValue = "" Or e.FormattedValue = "  /  /" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgay_Null", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay").Selected = True
                        grdKehoachnhanvien.Focus()
                        e.Cancel = True
                        Exit Sub
                    Else
                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay").Selected = True
                            grdKehoachnhanvien.Focus()
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
            End Select
        Else
            Select Case Me.grdKehoachnhanvien.Columns(e.ColumnIndex).Name
                Case "cboTu_gio"
                    If e.FormattedValue <> "" And e.FormattedValue <> "  :" Then

                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Invalid", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                    TU_GIO_TMP = e.FormattedValue
                Case "cboDen_gio"
                    If e.FormattedValue <> "" And e.FormattedValue <> "  :" Then

                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDen_gio_Invalid", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                Case "cboNgay"
                    If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Selected = True
                            grdKehoachnhanvien.Focus()
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                Case "cboDenNgay"
                    If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                        If Not IsDate(e.FormattedValue) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                            grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay").Selected = True
                            grdKehoachnhanvien.Focus()
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
            End Select
        End If
        'End If
    End Sub

    Private Sub grdKehoachnhanvien_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdKehoachnhanvien.DataError
        If btnKhongghi.Focused() Then
            Exit Sub
        End If
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungKhoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        e.Cancel = True
        Exit Sub
        'End If
    End Sub

    Private Sub tabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControl.SelectedIndexChanged
        If btnThemsua.Visible = False Then
            tabControl.SelectedIndex = 0
            Exit Sub
        End If
        lock_button()
    End Sub
    Dim cboCN As System.Windows.Forms.ComboBox
    Private Sub grdKehoachnhanvien_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdKehoachnhanvien.EditingControlShowing

    End Sub

    Private Sub grdKehoachnhanvien_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdKehoachnhanvien.KeyDown
        If grdKehoachnhanvien.Rows.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgXOA_NC", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    grdKehoachnhanvien.Rows.RemoveAt(grdKehoachnhanvien.CurrentRow.Cells(0).RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub grdKehoachnhanvien_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdKehoachnhanvien.RowEnter
        intRowCN = e.RowIndex
    End Sub

    Private Sub grdKehoachnhanvien_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) 'Handles grdKehoachnhanvien.RowValidating
        'If btnKhongghi.Focused() Then
        '    Exit Sub
        'End If
        'If btnCapnhatthoigiancongviec.Focused() Then
        '    Exit Sub
        'End If
        'If btnGhi.Visible Then
        '    If e.RowIndex < grdKehoachnhanvien.Rows.Count Then
        '        If (Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Value.ToString = "  /  /") And (Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "  :") And (Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value.ToString = "  :") And Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("TU_GIO_tmp").Value.ToString = "" Then
        '            Exit Sub
        '        End If
        '        If Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Value.ToString = "  /  /" Then
        '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNgay_Null", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '            Me.grdKehoachnhanvien.Rows(e.RowIndex).ErrorText = "Error"
        '            Me.grdKehoachnhanvien.CurrentCell() = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay")
        '            Me.grdKehoachnhanvien.Focus()
        '            e.Cancel = True
        '            Exit Sub
        '        ElseIf Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay").Value.ToString = "  /  /" Then
        '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDenNgay_Null", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '            Me.grdKehoachnhanvien.Rows(e.RowIndex).ErrorText = "Error"
        '            'Me.grdKehoachnhanvien.CurrentCell() = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay")
        '            ''Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay").Selected = True
        '            'Me.grdKehoachnhanvien.Focus()
        '            'e.Cancel = True
        '            Exit Sub
        '        ElseIf Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value.ToString = "  :" Then
        '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTu_gio_Null", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '            Me.grdKehoachnhanvien.CurrentCell() = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio")
        '            Me.grdKehoachnhanvien.Focus()
        '            e.Cancel = True
        '            Exit Sub
        '        ElseIf Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value.ToString = "" Or Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value.ToString = "  :" Then
        '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDen_gio_Null", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '            Me.grdKehoachnhanvien.CurrentCell() = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio")
        '            Me.grdKehoachnhanvien.Focus()
        '            e.Cancel = True
        '            Exit Sub
        '        Else
        '            If Date.Parse(Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboNgay").Value + " " + Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboTu_gio").Value) >= Date.Parse(Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDenNgay").Value + " " + Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio").Value) Then
        '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDenGioNhoHonTuGio", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '                Me.grdKehoachnhanvien.CurrentCell() = Me.grdKehoachnhanvien.Rows(e.RowIndex).Cells("cboDen_gio")
        '                Me.grdKehoachnhanvien.Focus()
        '                e.Cancel = True
        '                Exit Sub
        '            End If
        '        End If
        '        Me.grdKehoachnhanvien.Rows(e.RowIndex).ErrorText = ""
        '    End If
        'End If
    End Sub


    Private Sub grdCuasobaotri_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCuasobaotri.RowEnter
        intRowCuaBT = e.RowIndex
    End Sub

    Private Sub BtnChonNV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonNV.Click
        'If frmChonNhanVienChoPBT.ShowDialog() = Windows.Forms.DialogResult.OK Then

        '    Dim str As String = ""
        '    str = "SELECT MS_CONG_NHAN,MS_CONG_NHAN + ' - ' + HO_TEN AS HO_TEN, THUE_NGOAI FROM tmpNhanVien" & Commons.Modules.UserName
        '    Dim tb As New DataTable()
        '    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        '    For i As Integer = 0 To tb.Rows.Count - 1
        '        Dim dr As DataRow
        '        dr = TBNhanVien.NewRow
        '        dr.Item("MS_CONG_NHAN") = tb.Rows(i).Item("MS_CONG_NHAN")
        '        dr.Item("MS_CN") = tb.Rows(i).Item("MS_CONG_NHAN")
        '        dr.Item("TEN_CONG_NHAN") = tb.Rows(i).Item("HO_TEN").ToString.Replace("   ", "'")
        '        dr.Item("HOAN_THANH") = 0
        '        dr.Item("THUE_NGOAI") = tb.Rows(i).Item("THUE_NGOAI")
        '        TBNhanVien.Rows.Add(dr)
        '    Next
        '    grdKehoachnhanvien.DataSource = TBNhanVien
        'End If
    End Sub

    Private Sub cboTo_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTo.SelectionChangeCommitted
        loadCboNhanVien()
    End Sub

    Sub HandleKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgrDanhSachVatTuPhuTung_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrDanhSachVatTuPhuTung.EditingControlShowing
        Try
            If Me.dgrDanhSachVatTuPhuTung.CurrentCellAddress.X = 5 Or Me.dgrDanhSachVatTuPhuTung.CurrentCellAddress.X = 6 Then
                txtBaoTri = e.Control

                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgrViTriPhuTung_2_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrViTriPhuTung_2.EditingControlShowing
        Try
            If Me.dgrViTriPhuTung_2.CurrentCellAddress.X = 6 Or Me.dgrViTriPhuTung_2.CurrentCellAddress.X = 7 Then
                txtBaoTri = e.Control

                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub dgrViTriPhuTung_4_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
    '    Try
    '        If Me.dgrViTriPhuTung_4.CurrentCellAddress.X = 6 Or Me.dgrViTriPhuTung_4.CurrentCellAddress.X = 7 Then
    '            txtBaoTri = e.Control

    '            RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
    '            AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
    '        Else
    '            RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub grdDichVuThueNgoai_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDichVuThueNgoai.EditingControlShowing
        Try
            If Me.grdDichVuThueNgoai.CurrentCellAddress.X = 6 Then
                txtBaoTri = e.Control

                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPress
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPress
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPress
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtChiSoDongHo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChiSoDongHo.KeyDown
        If (e.KeyValue >= 47 And e.KeyValue <= 56) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtMovement_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMovement.KeyDown
        If (e.KeyValue >= 47 And e.KeyValue <= 56) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
        'Or e.KeyValue = 190,110"."
    End Sub

    Private Sub btnSaoChep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaoChep.Click
        Dim i As Integer
        If grdKehoachnhanvien.RowCount <= 0 Then
            MsgBox("Bạn vui lòng chọn nhân viên !", MsgBoxStyle.Information, "Thông báo ")
            Exit Sub
        End If

        If grdKehoachnhanvien.RowCount > 1 Then
            For i = 0 To grdKehoachnhanvien.RowCount - 1
                If i <> grdKehoachnhanvien.CurrentRow.Index Then
                    grdKehoachnhanvien.Rows(i).Cells("cboNgay").Value = grdKehoachnhanvien.CurrentRow.Cells("cboNgay").Value
                    grdKehoachnhanvien.Rows(i).Cells("cboDenNgay").Value = grdKehoachnhanvien.CurrentRow.Cells("cboDenNgay").Value
                    grdKehoachnhanvien.Rows(i).Cells("cboTu_Gio").Value = grdKehoachnhanvien.CurrentRow.Cells("cboTu_Gio").Value
                    grdKehoachnhanvien.Rows(i).Cells("cboDen_Gio").Value = grdKehoachnhanvien.CurrentRow.Cells("cboDen_Gio").Value
                End If
            Next
        End If
    End Sub
    Private intCongViecDaThucHien_4 As Integer
    Private Sub dgrCongViecDaThucHien_4_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgrCongViecDaThucHien_4.UserDeletingRow
        If e.Row.Index < intCongViecDaThucHien_4 Then
            MsgBox("Đây là dữ liệu cũ, bạn không thể xóa !", MsgBoxStyle.Information, "Thông báo ")
            e.Cancel = True
        End If
    End Sub

    Private intViTriPhuTung_4 As Integer
    Private Sub dgrViTriPhuTung_4_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgrViTriPhuTung_4.UserDeletingRow

        If e.Row.Index < intViTriPhuTung_4 Then
            MsgBox("Đây là dữ liệu cũ, bạn không thể xóa !", MsgBoxStyle.Information, "Thông báo ")
            e.Cancel = True
        End If

    End Sub

    Private Sub btnThoat_4_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat_4.Click
        Me.Close()
    End Sub

    Private Sub txtChiPhiKhacMacDinh_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChiPhiKhacMacDinh.Validated
        Dim dtReader As SqlDataReader

        If txtChiPhiKhacMacDinh.Text <> "" And IsNumeric(txtChiPhiKhacMacDinh.Text.Trim) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOI_CHI_PHI_KHAC_MAC_DINH", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
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

    Private Sub btnDanhGia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDanhGia.Click, btnDanhGia_Ghi.Click, btnDanhGia_khong.Click
        LoadDanhGia(sender.name)
    End Sub

    Private Sub LoadDanhGia(ByVal str As String)
        Dim dtReader As SqlDataReader


        Select Case str
            Case "btnDanhGia"
                btnDanhGia.Enabled = False
                btnDanhGia_Ghi.Enabled = True
                btnDanhGia_khong.Enabled = True
                dgrNoiDungTrongHopDong_4.Enabled = False
                Dim btam As Boolean = bChangce
                bChangce = True
                LoadDanhSachDV(True)
                bChangce = btam
                btnThemSuaCV_4.Enabled = False
                btnThemSuaDV_4.Enabled = False
                btnXoa_4.Enabled = False
                grdDanhGiaDV.Enabled = True
                grdDanhGiaDV.Focus()
            Case "btnDanhGia_Ghi"
                btnDanhGia.Enabled = True
                btnDanhGia_Ghi.Enabled = False
                btnDanhGia_khong.Enabled = False
                btnThemSuaCV_4.Enabled = True
                btnThemSuaDV_4.Enabled = True
                btnXoa_4.Enabled = True
                dgrNoiDungTrongHopDong_4.Enabled = True
                For i As Integer = 0 To grdDanhGiaDV.Rows.Count - 1
                    If grdDanhGiaDV.Rows(i).Cells("DIEM").Value > 0 Then
                        'kiem tra neu co roi thi update, nguoc lai thi insert
                        Commons.Modules.SQLString = "SELECT * FROM dbo.PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & " AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA=" & grdDanhGiaDV.Rows(i).Cells("ID").Value
                        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        dtReader.Read()
                        If dtReader.HasRows = True Then 'co roi thi update
                            str = "UPDATE PHIEU_BAO_TRI_DANH_GIA_SERVICE SET DIEM=" & grdDanhGiaDV.Rows(i).Cells("DIEM").Value &
                                  " WHERE MS_PBT='" & txtMaSoPBT.Text & "' AND STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & " AND MS_DANH_GIA=" & grdDanhGiaDV.Rows(i).Cells("ID").Value
                        Else    'chua co thi insert
                            str = "INSERT INTO PHIEU_BAO_TRI_DANH_GIA_SERVICE(MS_PBT,STT_EOR,MS_DANH_GIA,DIEM)VALUES(N'" & txtMaSoPBT.Text & "'," & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & "," & grdDanhGiaDV.Rows(i).Cells("ID").Value & "," & grdDanhGiaDV.Rows(i).Cells("DIEM").Value & ")"
                        End If
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                        dtReader.Close()
                    Else    'nhập = 0 thì xóa khỏi database
                        str = "DELETE FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" & txtMaSoPBT.Text & "' AND STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & " AND MS_DANH_GIA=" & grdDanhGiaDV.Rows(i).Cells("ID").Value
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    End If
                Next
                Commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" & txtMaSoPBT.Text & "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" & dgrNoiDungTrongHopDong_4.Rows(intRowIndex).Cells("STT").Value & " AND DIEM<=0"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

                LoadDanhSachDV(False)
                grdDanhGiaDV.Enabled = False
            Case "btnDanhGia_khong"
                btnDanhGia.Enabled = True
                btnDanhGia_Ghi.Enabled = False
                btnDanhGia_khong.Enabled = False
                btnThemSuaCV_4.Enabled = True
                btnThemSuaDV_4.Enabled = True
                btnXoa_4.Enabled = True
                dgrNoiDungTrongHopDong_4.Enabled = True
                LoadDanhSachDV(False)
                grdDanhGiaDV.Enabled = False
        End Select
    End Sub

    Private Sub grdDanhGiaDV_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDanhGiaDV.DataError
        If e.Context = 768 Then MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DIEM_KHONG_HOP_LE", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
    End Sub

    Private Sub grdDanhGiaDV_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdDanhGiaDV.RowValidating
        If IsDBNull(grdDanhGiaDV.Rows(e.RowIndex).Cells("DIEM").Value) Then grdDanhGiaDV.Rows(e.RowIndex).Cells("DIEM").Value = 0
        If grdDanhGiaDV.Rows(e.RowIndex).Cells("DIEM").Value < 0 Or grdDanhGiaDV.Rows(e.RowIndex).Cells("DIEM").Value > 10 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG_DIEM_KHONG_HOP_LE", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub dgrNoiDungTrongHopDong_4_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrNoiDungTrongHopDong_4.RowValidated
        If IsDBNull(dgrNoiDungTrongHopDong_4.CurrentRow.Cells("TY_GIA").Value) Or IsDBNull(dgrNoiDungTrongHopDong_4.CurrentRow.Cells("TY_GIA_USD").Value) Then
            Dim dtReader As SqlDataReader

            Try
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM TI_GIA_NT WHERE NGOAI_TE='" & dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("cboNGOAI_TE").Value.ToString & "' AND NGAY >=ALL (SELECT MAX(NGAY) FROM TI_GIA_NT)")
                While dtReader.Read
                    dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA").Value = dtReader.Item("TI_GIA")
                    dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA_USD").Value = dtReader.Item("TI_GIA_USD")
                End While
                dtReader.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub dgrNoiDungTrongHopDong_4_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgrNoiDungTrongHopDong_4.RowValidating
        If (dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).IsNewRow = True Or btnGhi_4.Visible = False) Then Exit Sub
        If Not btnKhongGhi_4.Focused Then
            If dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("NOI_DUNG_SERVICE").Value Is Nothing Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_DUNG_SERVICE_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                dgrNoiDungTrongHopDong_4.CurrentCell = dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("NOI_DUNG_SERVICE")
                e.Cancel = True
                Exit Sub
            Else
                If dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("NOI_DUNG_SERVICE").Value.ToString = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_DUNG_SERVICE_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    dgrNoiDungTrongHopDong_4.CurrentCell = dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("NOI_DUNG_SERVICE")
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            If dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("MS_KH").Value.ToString Is Nothing Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_KH_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                dgrNoiDungTrongHopDong_4.CurrentCell = dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("cboTEN_RUT_GON")
                e.Cancel = True
                Exit Sub
            Else
                If dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("MS_KH").Value.ToString = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_KH_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    dgrNoiDungTrongHopDong_4.CurrentCell = dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("cboTEN_RUT_GON")
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            Try
                If Val(dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("SO_LUONG").Value.ToString) <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmEOR", "MsgNotNum", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                    dgrNoiDungTrongHopDong_4.CurrentCell = dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("SO_LUONG")
                    e.Cancel = True
                ElseIf Val(dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("DON_GIA").Value.ToString) <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmEOR", "MsgNotNum1", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                    dgrNoiDungTrongHopDong_4.CurrentCell = dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("DON_GIA")
                    e.Cancel = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    '///////////////
    Sub BindDataPTVT(ByVal intRow As Integer)
        Dim str As String = ""
        Dim tb As New DataTable

        If btnGhi_4.Visible And blnDv = False Then
            str = "SELECT distinct * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName & " WHERE MS_CV='" & dgrViTriPhuTung_4.Rows(intRow).Cells("MS_CV").Value &
                                "' AND MS_BO_PHAN='" & dgrViTriPhuTung_4.Rows(intRow).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_4.Rows(intRow).Cells("MS_PT").Value & "'"
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        Else
            tb = New clsPHIEU_BAO_TRIController().GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIETs(txtMaSoPBT.Text, dgrViTriPhuTung_4.Rows(intRow).Cells("MS_CV").Value, dgrViTriPhuTung_4.Rows(intRow).Cells("MS_BO_PHAN").Value, dgrViTriPhuTung_4.Rows(intRow).Cells("MS_PT").Value)
        End If
        dgrViTriPhuTung_41.DataSource = tb
        dgrViTriPhuTung_41.Columns("MS_PHIEU_BAO_TRI").Visible = False
        dgrViTriPhuTung_41.Columns("MS_CV").Visible = False
        dgrViTriPhuTung_41.Columns("MS_BO_PHAN").Visible = False
        dgrViTriPhuTung_41.Columns("MS_PT").Visible = False
        dgrViTriPhuTung_41.Columns("SL_KH").Visible = False
        dgrViTriPhuTung_41.Columns("THAY_SUA").Visible = False
        dgrViTriPhuTung_41.Columns("STT").Visible = False
        If btnGhi_4.Visible Then
            dgrViTriPhuTung_41.ReadOnly = False
            dgrViTriPhuTung_41.Columns("MS_VI_TRI_PT").ReadOnly = True
            dgrViTriPhuTung_41.Columns("SL_KH").ReadOnly = False
            dgrViTriPhuTung_41.Columns("SL_TT").ReadOnly = False
        Else
            dgrViTriPhuTung_41.ReadOnly = True
        End If
        'dgrViTriPhuTung_41.Columns("MS_VI_TRI_PT").ReadOnly = True
        'dgrViTriPhuTung_41.Columns("SL_KH").ReadOnly = True
        'dgrViTriPhuTung_41.Columns("SL_TT").ReadOnly = True
        dgrViTriPhuTung_41.Columns("SL_KH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgrViTriPhuTung_41.Columns("SL_TT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Try
            dgrViTriPhuTung_41.Columns("SL_CUM").Visible = False
            dgrViTriPhuTung_41.Columns("SL_CUM").ReadOnly = True
            dgrViTriPhuTung_41.Columns("SL_CUM").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_CUM", Commons.Modules.TypeLanguage)
        Catch ex As Exception

        End Try

        Try
            dgrViTriPhuTung_41.Columns("NGAY_HOAN_THANH").Visible = False
        Catch
        End Try

        With dgrViTriPhuTung_41
            .Columns("MS_VI_TRI_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
            .Columns("MS_VI_TRI_PT").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("SL_KH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_KH", Commons.Modules.TypeLanguage)
            .Columns("SL_TT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_TT", Commons.Modules.TypeLanguage)
        End With
        Try
            Me.dgrViTriPhuTung_41.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrViTriPhuTung_41.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgrViTriPhuTung_41_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'HandlesdgrViTriPhuTung_41.CellValidating
        If btnKhongGhi_4.Focused Then
            Exit Sub
        End If
        If btnGhi_4.Visible Then
            Dim str As String = ""
            Dim tam As String = ""
            If dgrViTriPhuTung_41.Columns(e.ColumnIndex).Name = "SL_KH" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        'XtraMessageBox.Show("KHONG PHAI SO")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_41.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue <= 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_41.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                If e.FormattedValue = "" Then
                    tam = "null"
                Else
                    tam = e.FormattedValue
                    'If Not IsDBNull(dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("SL_CUM").Value) Then
                    '    If e.FormattedValue > dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("SL_CUM").Value Then
                    '        'XtraMessageBox.Show("Số lượng kế học không được lớn hơn số lượng cụm")
                    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongKhongTrung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    '        dgrViTriPhuTung_41.Rows(e.RowIndex).ErrorText = "Error"
                    '        e.Cancel = True
                    '        Exit Sub
                    '    End If
                    'End If
                End If
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName & " SET SL_KH=" & tam & " WHERE MS_CV='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_CV").Value &
                        "' AND MS_BO_PHAN='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            ElseIf dgrViTriPhuTung_41.Columns(e.ColumnIndex).Name = "SL_TT" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        'XtraMessageBox.Show("KHONG PHAI SO")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_41.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue <= 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        dgrViTriPhuTung_41.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                If e.FormattedValue = "" Then
                    tam = "null"
                Else
                    tam = e.FormattedValue
                End If
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" & Commons.Modules.UserName & " SET SL_TT=" & tam & " WHERE MS_CV='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_CV").Value &
                "' AND MS_BO_PHAN='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                'ElseIf dgrViTriPhuTung_41.Columns(e.ColumnIndex).Name = "GHI_CHU" Then
                '    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " SET GHI_CHU=" & e.FormattedValue & " WHERE MS_CV='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_CV").Value & _
                '                    "' AND MS_BO_PHAN='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_41.Rows(e.RowIndex).Cells("MS_VI_TRI_PT").Value & "'"
                '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
        dgrViTriPhuTung_41.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub dgrViTriPhuTung_4_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrViTriPhuTung_4.RowEnter
        intRowPT_TN = e.RowIndex
        Try
            BindDataPTVT(e.RowIndex)
        Catch ex As Exception

        End Try
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
    '///////////////

    Private Sub dgrNoiDungTrongHopDong_4_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrNoiDungTrongHopDong_4.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            txtBaoTri = e.Control
            If dgrNoiDungTrongHopDong_4.CurrentCell.OwningColumn.Name = "SO_LUONG" Or dgrNoiDungTrongHopDong_4.CurrentCell.OwningColumn.Name = "DON_GIA" Or dgrNoiDungTrongHopDong_4.CurrentCell.OwningColumn.Name = "TY_GIA" Or dgrNoiDungTrongHopDong_4.CurrentCell.OwningColumn.Name = "TY_GIA_USD" Then
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        End If
    End Sub

    Private Sub dgrViTriPhuTung_4_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrViTriPhuTung_4.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            txtBaoTri = e.Control
            If dgrViTriPhuTung_4.CurrentCell.OwningColumn.Name = "SO_LUONG" Or dgrViTriPhuTung_4.CurrentCell.OwningColumn.Name = "SL_TT" Then
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        End If
    End Sub

    Private Sub dgrViTriPhuTung_41_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrViTriPhuTung_41.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            txtBaoTri = e.Control
            If dgrViTriPhuTung_41.CurrentCell.OwningColumn.Name = "SO_LUONG" Or dgrViTriPhuTung_4.CurrentCell.OwningColumn.Name = "SL_TT" Then
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        End If
    End Sub

    Private Sub dgrViTriPhuTung_2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrViTriPhuTung_2.KeyDown
        If e.KeyValue = Keys.Delete And (btnXoaVatTuPT_2.Visible = True Or btnGhi_2.Visible = True) Then
            If dgrViTriPhuTung_2.Rows.Count > 1 Then
                If dgrViTriPhuTung_2.SelectedRows.Count = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_VI_TRI", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XOA_VI_TRI_PT", Commons.Modules.TypeLanguage), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    If btnXoaVatTuPT_2.Visible = True Then
                        Try
                            If dgrViTriPhuTung_2.SelectedRows.Count = dgrViTriPhuTung_2.RowCount Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_DUOC_CHON_HET", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                                Exit Sub
                            End If
                            For i As Integer = dgrViTriPhuTung_2.SelectedRows.Count - 1 To 0 Step -1
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrViTriPhuTung_2.SelectedRows(i).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.Rows(intRowCV).Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_2.SelectedRows(i).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_2.SelectedRows(i).Cells("MS_VI_TRI_PT").Value & "'")
                                dgrViTriPhuTung_2.Rows.RemoveAt(dgrViTriPhuTung_2.SelectedRows(i).Index)
                            Next

                            'CAP NHAT LAI SL CHO BANG PHU TUNG
                            Dim dtReader As SqlDataReader, str As String = ""

                            str = "SELECT DISTINCT A.MS_PHIEU_BAO_TRI, A.MS_CV, A.MS_BO_PHAN, A.MS_PT, SUM(A.SL_KH) AS TONG_SL " &
                                  "FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET A INNER JOIN dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI AND A.MS_CV = B.MS_CV AND A.MS_BO_PHAN = B.MS_BO_PHAN And A.MS_PT = B.MS_PT " &
                                  "WHERE (A.MS_PHIEU_BAO_TRI = '" & txtMaSoPBT.Text & "') AND (A.SL_KH IS NOT NULL) AND (A.SL_KH > 0) " &
                                  "GROUP BY A.MS_PHIEU_BAO_TRI, A.MS_CV, A.MS_BO_PHAN, A.MS_PT"
                            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str) '"SELECT DISTINCT A.MS_PHIEU_BAO_TRI,A.MS_CV,A.MS_BO_PHAN,A.MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " A , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName & " B WHERE( A.MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI And A.MS_CV = B.MS_CV And A.MS_BO_PHAN = B.MS_BO_PHAN And A.MS_PT = B.MS_PT And A.SL_KH Is Not Null AND A.SL_KH>0)")
                            While dtReader.Read
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH=" & dtReader.Item("TONG_SL") & " WHERE MS_PHIEU_BAO_TRI='" & dtReader.Item("MS_PHIEU_BAO_TRI") & "' AND MS_CV=" & dtReader.Item("MS_CV") & " AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "'")
                            End While
                            dtReader.Close()

                            'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrDanhSachCongViecChinh_2.CurrentRow.Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.CurrentRow.Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_2.CurrentRow.Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_2.CurrentRow.Cells("MS_VI_TRI_PT").Value & "'")
                            'dgrViTriPhuTung_2.Rows.Remove(dgrViTriPhuTung_2.CurrentRow)
                        Catch ex As Exception
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_PHU_TUNG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        End Try
                    ElseIf btnGhi_2.Visible = True Then
                        Try
                            If dgrViTriPhuTung_2.SelectedRows.Count = dgrViTriPhuTung_2.RowCount Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_DUOC_CHON_HET", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                                Exit Sub
                            End If
                            For i As Integer = dgrViTriPhuTung_2.SelectedRows.Count - 1 To 0 Step -1
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" & Commons.Modules.UserName & " WHERE MS_PHIEU_BAO_TRI='" & txtMaSoPBT.Text & "' AND MS_CV=" & dgrViTriPhuTung_2.SelectedRows(i).Cells("MS_CV").Value & " AND MS_BO_PHAN='" & dgrDanhSachCongViecChinh_2.CurrentRow.Cells("MS_BO_PHAN").Value & "' AND MS_PT='" & dgrViTriPhuTung_2.SelectedRows(i).Cells("MS_PT").Value & "' AND MS_VI_TRI_PT='" & dgrViTriPhuTung_2.SelectedRows(i).Cells("MS_VI_TRI_PT").Value & "'")
                                dgrViTriPhuTung_2.Rows.RemoveAt(dgrViTriPhuTung_2.SelectedRows(i).Index)
                            Next
                        Catch ex As Exception
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_PHU_TUNG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        End Try
                    End If
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_XOA_DUOC_VI_TRI", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            End If

            Dim iTong As Integer = 0
            For i As Integer = 0 To dgrViTriPhuTung_2.RowCount - 1
                iTong += Val(dgrViTriPhuTung_2.Rows(i).Cells("SL_KH").Value)
            Next
            If intRowPT >= 0 Then dgrDanhSachVatTuPhuTung.Rows(intRowPT).Cells("SL_KH").Value = iTong
        End If
    End Sub

    Private Sub dgrNoiDungTrongHopDong_4_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrNoiDungTrongHopDong_4.CellValueChanged
        Dim dtReader As SqlDataReader

        If dgrNoiDungTrongHopDong_4.Columns(e.ColumnIndex).Name.ToString = "cboNGOAI_TE" And btnGhi_4.Visible = True Then
            Try
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM TI_GIA_NT WHERE NGOAI_TE='" & dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("cboNGOAI_TE").Value.ToString & "' AND NGAY >=ALL (SELECT MAX(NGAY) FROM TI_GIA_NT)")
                While dtReader.Read
                    dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA").Value = dtReader.Item("TI_GIA")
                    dgrNoiDungTrongHopDong_4.Rows(e.RowIndex).Cells("TY_GIA_USD").Value = dtReader.Item("TI_GIA_USD")
                End While
                dtReader.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cboMS_ThietBi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMS_ThietBi.SelectionChangeCommitted
        cboLoai_BT.Value = "MS_LOAI_BT"
        cboLoai_BT.Display = "TEN_LOAI_BT"
        cboLoai_BT.Param = cboMS_ThietBi.SelectedValue.ToString
        cboLoai_BT.StoreName = "GetLOAI_BAO_TRI_PBT_THEO_BTPN"
        cboLoai_BT.DropDownWidth = 200
        cboLoai_BT.BindDataSource()
    End Sub

    Private Sub grdKehoachnhanvien_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdKehoachnhanvien.CellMouseDoubleClick
        Try
            FrmCongViecNhanVien.MS_PBT = txtMaSoPBT.Text.Trim()
            FrmCongViecNhanVien.StartPosition = FormStartPosition.CenterParent
            FrmCongViecNhanVien.MS_CONG_NHAN = grdKehoachnhanvien.Rows(e.RowIndex).Cells("MS_CONG_NHAN").Value.ToString().Trim()
            FrmCongViecNhanVien.ShowDialog(Me)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtNgayBDKH_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtNgayBDKH.Validated
        If dtNgayBDKH.Value < dtNgayLap.Value Then
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_BDKH_NHO_HON_NGAY_LAP", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                dtNgayBDKH.Focus()
            End If
        End If
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class