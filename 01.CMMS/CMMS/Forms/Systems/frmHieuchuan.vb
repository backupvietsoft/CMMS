
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports System.IO
Imports DevExpress.XtraGrid.Columns

Public Class frmHieuchuan
    Private bTab As Integer = 0
    Private bThem As Byte = 0
    Private strMS_MAY_MAY As String
    Private strNGAY_HC_MAY As String
    Private strMS_MAY As String
    Private strNGAY_HC As String
    Private strMS_PT As String
    Private intMS_VI_TRI As String
    Private strNGAY_KH_MAY As String
    Private strNGAY_KH As String
    Private strMS_LOAI_HIEU_CHUAN As String
    Dim regHCM As String = "DevExpress\XtraGrid\Layouts\GridHCM"
    Sub New()
        Commons.Modules.SQLString = "0Load"
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmHieuchuan_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("rptTIEU_DE_HIEU_CHUAN_MAY")
        Commons.Modules.ObjSystems.XoaTable("rptHIEU_CHUAN_MAY")
    End Sub
    Private Sub frmHieuchuan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()

        Commons.Modules.SQLString = "0Load"

        If Commons.Modules.PermisString.Equals("Read only") Then

            LoadcboThietbimay()
            'BindData()
            LockHieuchuanmay(True)
            VisiblebuttonMay(True)
            VisiblebuttonDHD(True)
            EnableDieukienloc(True)
            LockDieukienloctheomay_NgayHC(False)

            dtTungay1.DateTime = DateTime.Now
            dtDenngay1.DateTime = dtTungay1.DateTime.AddMonths(1)

            LockDieukienloctheomay_Thietbi(False)
            Try
                grvDSHieuChuanMay.FocusedRowHandle = 0
            Catch ex As Exception
            End Try
            LoadThietbiDHD()
            LoadMS_LOAI_HIEU_CHUAN()
            LoadDHD()
            Loadvitri()
            LockhieuchuanDHD(True)
            LoadcboNam()
            LoadcboThietbihieuchuantheoDHD()
            LoadDHD_filter()
            'LoadhieuchuanDHD()
            EnableButton(False)
        Else
            EnableButton(True)
            LoadcboThietbimay()
            LockHieuchuanmay(True)
            VisiblebuttonMay(True)
            VisiblebuttonDHD(True)
            EnableDieukienloc(True)
            LockDieukienloctheomay_NgayHC(False)
            dtTungay1.DateTime = DateTime.Now
            dtDenngay1.DateTime = dtTungay1.DateTime.AddMonths(1)
            LockDieukienloctheomay_Thietbi(False)
            Try
                grvDSHieuChuanMay.FocusedRowHandle = 0
            Catch ex As Exception
            End Try
            LoadThietbiDHD()
            LoadMS_LOAI_HIEU_CHUAN()
            LoadDHD()
            Loadvitri()
            LockhieuchuanDHD(True)
            LoadcboNam()
            LoadcboThietbihieuchuantheoDHD()
            LoadDHD_filter()

            'LoadhieuchuanDHD()
        End If
        Commons.Modules.SQLString = ""

        cboNamDHD1_EditValueChanged(Nothing, Nothing)
        optNTHT_SelectedIndexChanged(Nothing, Nothing)

        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        txtTMay.Enabled = True
        txtTMayDCD.Enabled = True
        txtNgayKHMAY.Enabled = False

    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThemMAY.Enabled = chon
        BtnXoaMAY.Enabled = chon
        BtnSuaMAY.Enabled = chon
        BtnThemDHD.Enabled = chon
        BtnXoaDHD.Enabled = chon
        BtnSuaDHD.Enabled = chon
    End Sub
#Region "private hieu chuan may"
    Sub ChangeTab(ByVal bTab As Integer)
        TabHieuchuan.SelectedTabPageIndex = bTab
    End Sub
    Sub BindData()

        Try
            grdDSHieuChuanMay.DataSource = Nothing
            grvDSHieuChuanMay.Columns.Clear()
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_MAYController().GetHIEU_CHUAN_MAYs, False, True, True, True, True, "")
        Try
        Catch ex As Exception
        End Try
        If grvDSHieuChuanMay.RowCount > 0 Then
            BtnSuaMAY.Enabled = True
            BtnXoaMAY.Enabled = True
            BtnInMAY.Enabled = True
        Else
            BtnSuaMAY.Enabled = False
            BtnXoaMAY.Enabled = False
            BtnInMAY.Enabled = False
        End If
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If
        Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
        Try
            opts.Columns.StoreAllOptions = True
            grdDSHieuChuanMay.MainView.RestoreLayoutFromRegistry(regHCM)
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadcboThietbimay()
        cboThietbi.StoreName = "GetMAYHCTB"
        cboThietbi.Display = "MS_MAY"
        cboThietbi.Value = "MS_MAY"
        cboThietbi.Param = Commons.Modules.UserName
        cboThietbi.BindDataSource()
        If cboThietbi.Items.Count > 0 Then
            BtnThemMAY.Enabled = True
        Else
            BtnThemMAY.Enabled = False
        End If


    End Sub
    Sub LoadcboThietbihieuchuantheomay()
        Try
            cboThietbiLoctheomay1.Properties.DataSource = Nothing
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_MAY_HIEU_CHUAN_MAY", Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThietbiLoctheomay1, dt, "MS_MAY", "MS_MAY", "MS_MAY")

    End Sub
    Sub Showhieuchuanmay(ByVal intRow As Integer)
        Try
            cboThietbi.SelectedValue = grvDSHieuChuanMay.GetDataRow(intRow)("MS_MAY")
            strMS_MAY_MAY = grvDSHieuChuanMay.GetDataRow(intRow)("MS_MAY")
            txtThietBi.Text = strMS_MAY_MAY

            txtNgayHCMAY.Text = grvDSHieuChuanMay.GetDataRow(intRow)("NGAY_HC")

            strNGAY_HC_MAY = grvDSHieuChuanMay.GetDataRow(intRow)("NGAY_HC")


            Try
                txtNgayKHMAY.Text = grvDSHieuChuanMay.GetDataRow(intRow)("NGAY_KH")
            Catch ex As Exception
            End Try
            Try
                dtNgay.DateTime = Convert.ToDateTime(txtNgayHCMAY.Text)
            Catch ex As Exception

            End Try
            Try
                strNGAY_KH_MAY = grvDSHieuChuanMay.GetDataRow(intRow)("NGAY_KH")
            Catch ex As Exception

            End Try


            txtGiayCN.Text = grvDSHieuChuanMay.GetDataRow(intRow)("GIAY_CHUNG_NHAN").ToString()
            txtCoquanHC.Text = grvDSHieuChuanMay.GetDataRow(intRow)("CO_QUAN_HIEU_CHUAN").ToString()
            txtDanhgia.Text = grvDSHieuChuanMay.GetDataRow(intRow)("DANH_GIA").ToString()
            txttai_lieu.Text = grvDSHieuChuanMay.GetDataRow(intRow)("TAI_LIEU").ToString()
            cboLoaiHieuChuan.EditValue = grvDSHieuChuanMay.GetDataRow(intRow)("MS_LOAI_HIEU_CHUAN")
            txtGhi_chu.Text = grvDSHieuChuanMay.GetDataRow(intRow)("GHI_CHU").ToString()
        Catch

            cboThietbi.SelectedValue = "-1"
            strMS_MAY_MAY = ""
            txtThietBi.Text = strMS_MAY_MAY

            txtNgayHCMAY.Text = "__/__/____"
            strNGAY_HC_MAY = "__/__/____"
            Try
                txtNgayKHMAY.Text = "__/__/____"
            Catch ex As Exception
            End Try
            Try
                strNGAY_KH_MAY = "__/__/____"
            Catch ex As Exception

            End Try

            txtGiayCN.Text = ""
            txtCoquanHC.Text = ""
            txtDanhgia.Text = ""
            txttai_lieu.Text = ""
            cboLoaiHieuChuan.EditValue = "-1"
            txtGhi_chu.Text = ""
        End Try



    End Sub
    Sub VisiblebuttonMay(ByVal chon As Boolean)
        BtnThemMAY.Visible = chon
        BtnSuaMAY.Visible = chon
        BtnXoaMAY.Visible = chon
        BtnInMAY.Visible = chon
        BtnThoatMAY.Visible = chon
        BTnGhiMAY.Visible = Not chon
        BtnKhongghiMAY.Visible = Not chon
        grdDSHieuChuanMay.Enabled = chon
        optNTHT.Enabled = Not chon
    End Sub

    Sub LockDieukienloctheomay_Thietbi(ByVal chon As Boolean)
        cboThietbiLoctheomay1.Visible = chon

        TxtNhomMay.Visible = chon
        LblMS_MAY.Visible = chon
        LblNhomMay.Visible = chon
    End Sub
    Sub LockDieukienloctheomay_NgayHC(ByVal chon As Boolean)
        lblTungay.Visible = chon
        'txtTungayHCMAY.Visible = chon
        dtTungay1.Visible = chon
        lblDenngay.Visible = chon
        'txtDenngayHCMAY.Visible = chon
        dtDenngay1.Visible = chon
    End Sub
    Sub Refeshhieuchuanmay()
        cboThietbi.SelectedIndex = -1
        txtThietBi.Text = ""
        txtNgayHCMAY.Text = "__/__/____"
        txtNgayKHMAY.Text = "__/__/____"
        txtGiayCN.Text = ""
        txtCoquanHC.Text = ""
        txtDanhgia.Text = ""
    End Sub

    Sub LockHieuchuanmay(ByVal chon As Boolean)
        cboThietbi.Enabled = Not chon
        btnTMay.Enabled = Not chon
        txtNgayHCMAY.ReadOnly = chon
        'txtNgayKHMAY.ReadOnly = chon
        txtGiayCN.ReadOnly = chon
        txtCoquanHC.ReadOnly = chon
        txtDanhgia.ReadOnly = chon
        cboLoaiHieuChuan.Enabled = Not chon
        dtNgay.Enabled = Not chon
        ' dtNgayKHMay.Enabled = Not chon
        txttai_lieu.Properties.ReadOnly = chon
        txtGhi_chu.ReadOnly = chon
    End Sub
    Sub EnableDieukienloc(ByVal chon As Boolean)
        optNTHT.Enabled = chon

        cboThietbiLoctheomay1.Enabled = chon
        dtTungay1.Enabled = chon
        dtDenngay1.Enabled = chon
    End Sub
    Sub AddHieuchuanmay()
        Dim objHIEU_CHUAN_MAYInfo As New HIEU_CHUAN_MAYInfo()
        objHIEU_CHUAN_MAYInfo.MS_MAY = cboThietbi.SelectedValue
        objHIEU_CHUAN_MAYInfo.NGAY_HC = txtNgayHCMAY.Text
        objHIEU_CHUAN_MAYInfo.NGAY_KH = txtNgayKHMAY.Text
        objHIEU_CHUAN_MAYInfo.GIAY_CHUNG_NHAN = txtGiayCN.Text.Trim()
        objHIEU_CHUAN_MAYInfo.CO_QUAN_HIEU_CHUAN = txtCoquanHC.Text.Trim()
        objHIEU_CHUAN_MAYInfo.DANH_GIA = txtDanhgia.Text.Trim()
        objHIEU_CHUAN_MAYInfo.TAI_LIEU = txttai_lieu.Text.Trim()
        objHIEU_CHUAN_MAYInfo.GHI_CHU = txtGhi_chu.Text.Trim()
        objHIEU_CHUAN_MAYInfo.LOAI_HIEU_CHUAN = cboLoaiHieuChuan.EditValue

        Dim objHIEU_CHUAN_MAYController As New clsHIEU_CHUAN_MAYController()
        If bThem = 1 Then
            objHIEU_CHUAN_MAYController.AddHIEU_CHUAN_MAY(objHIEU_CHUAN_MAYInfo)
            AddHIEU_CHUAN_MAY(objHIEU_CHUAN_MAYInfo)
        Else
            If bThem = 2 Then
                objHIEU_CHUAN_MAYInfo.MS_MAY_TMP = strMS_MAY_MAY
                objHIEU_CHUAN_MAYInfo.NGAY_HC_TMP = strNGAY_HC_MAY
                UpdateHIEU_CHUAN_MAY(objHIEU_CHUAN_MAYInfo)
                objHIEU_CHUAN_MAYController.UpdateHIEU_CHUAN_MAY(objHIEU_CHUAN_MAYInfo)
            End If
        End If
    End Sub
    Private Sub UpdateHIEU_CHUAN_MAY(ByVal objHIEU_CHUAN_MAYInfo As HIEU_CHUAN_MAYInfo)
        Dim sql As String
        Try
            sql = "exec UPDATE_HIEU_CHUAN_MAY_LOG '" & objHIEU_CHUAN_MAYInfo.MS_MAY & "','" & Format(CDate(objHIEU_CHUAN_MAYInfo.NGAY_HC), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',2"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddHIEU_CHUAN_MAY(ByVal objHIEU_CHUAN_MAYInfo As HIEU_CHUAN_MAYInfo)
        Dim sql As String
        Try
            sql = "exec UPDATE_HIEU_CHUAN_MAY_LOG '" & objHIEU_CHUAN_MAYInfo.MS_MAY & "','" & Format(CDate(objHIEU_CHUAN_MAYInfo.NGAY_HC), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteHIEU_CHUAN_MAY(ByVal strMS_MAY As String, ByVal strNGAY_HC As String)
        Dim sql As String
        Try
            sql = "exec UPDATE_HIEU_CHUAN_MAY_LOG '" & strMS_MAY & "','" & Format(CDate(strNGAY_HC), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "hiệu chuẩn máy"
    Dim intRow As Integer, intRow1 As Integer

    Private Sub BtnThoatMAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoatMAY.Click
        Me.Close()
    End Sub


    Private Sub BtnThemMAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThemMAY.Click
        bThem = 1
        bTab = 0
        VisiblebuttonMay(False)
        Refeshhieuchuanmay()
        txtNgayHCMAY.Text = Now.Date
        txtNgayKHMAY.Text = Now.Date
        txtNgayKHMAY.Enabled = False
        LockHieuchuanmay(False)
        EnableDieukienloc(False)
        cboThietbi.Focus()
        dtNgay.DateTime = Now.Date
    End Sub

    Private Sub BtnSuaMAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuaMAY.Click
        bThem = 2
        bTab = 0
        VisiblebuttonMay(False)
        LockHieuchuanmay(False)
        EnableDieukienloc(False)
        btnTMay.Enabled = False
        txtNgayKHMAY.Enabled = False
        cboThietbi.Focus()
    End Sub
    Private Sub BtnKhongghiMAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghiMAY.Click
        Try
            bThem = 0
            VisiblebuttonMay(True)
            LockHieuchuanmay(True)
            EnableDieukienloc(True)
            Refeshhieuchuanmay()
            optNTHT_SelectedIndexChanged(Nothing, Nothing)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnXoaMAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoaMAY.Click
        If grvDSHieuChuanMay.RowCount <= 0 Then
            'thông báo không có dữ liệu để xóa
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        Else
            'hỏi có muốn xóa thông tin người yêu cầu và chi tiết yêu cầu không? nếu muốn xóa chi tiêt yêu cầu hãy chọn tab chi tiết trước khi nhấn nút xóa
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objHIEU_CHUAN_MAYController As New clsHIEU_CHUAN_MAYController()
                DeleteHIEU_CHUAN_MAY(strMS_MAY_MAY, strNGAY_HC_MAY)
                objHIEU_CHUAN_MAYController.DeleteHIEU_CHUAN_MAY(strMS_MAY_MAY, strNGAY_HC_MAY)
                Refeshhieuchuanmay()
                Dim tmp As Integer = intRow

                optNTHT_SelectedIndexChanged(Nothing, Nothing)

            End If
        End If

    End Sub

    Private Sub BTnGhiMAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTnGhiMAY.Click

        If cboThietbi.SelectedIndex = -1 Or String.IsNullOrEmpty(txtThietBi.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThietBi", Commons.Modules.TypeLanguage),
                                                                                          MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        If txtNgayHCMAY.Text = "" Or txtNgayHCMAY.Text = "__/__/____" Then
            txtNgayHCMAY.Text = dtNgay.EditValue
        End If
        'If txtNgayKHMAY.Text = "" Or txtNgayKHMAY.Text = "__/__/____" Then
        '    txtNgayKHMAY.Text = dtNgayKHMay.Value.Date
        'End If
        If txtGiayCN.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiayChungNhan", Commons.Modules.TypeLanguage),
                                                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtGiayCN.Focus()
            Exit Sub
        End If
        If txtCoquanHC.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCoQuanHieuChuan", Commons.Modules.TypeLanguage),
                                                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtCoquanHC.Focus()
            Exit Sub
        End If
        If txtDanhgia.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDanhGia", Commons.Modules.TypeLanguage),
                                                                                                        MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtDanhgia.Focus()
            Exit Sub
        End If
        If IsDBNull(cboLoaiHieuChuan.EditValue) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoaiHieuChuan", Commons.Modules.TypeLanguage),
                                                                                                        MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            cboLoaiHieuChuan.Focus()
        End If
        For i As Integer = 0 To grvDSHieuChuanMay.RowCount - 1
            If grvDSHieuChuanMay.GetDataRow(i)("MS_MAY") = cboThietbi.SelectedValue And grvDSHieuChuanMay.GetDataRow(i)("NGAY_HC") = txtNgayHCMAY.Text Then
                If (bThem = 2 And grvDSHieuChuanMay.GetDataRow(i)("MS_MAY") <> strMS_MAY_MAY And
                    Date.Parse(grvDSHieuChuanMay.GetDataRow(i)("NGAY_HC").ToString).Date <> strNGAY_HC_MAY) Or bThem = 1 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrung", Commons.Modules.TypeLanguage),
                                                                                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    cboThietbi.Focus()
                    Exit Sub

                End If
            End If
        Next
        Try
            AddHieuchuanmay()
        Catch ex As Exception

        End Try

        Dim strMA_MAY_TMP, strNGAY_HC_TMP As String
        strMA_MAY_TMP = cboThietbi.SelectedValue
        strNGAY_HC_TMP = txtNgayHCMAY.Text
        Refeshhieuchuanmay()
        Try
            bThem = 0
            VisiblebuttonMay(True)
            LockHieuchuanmay(True)
            EnableDieukienloc(True)
            optNTHT_SelectedIndexChanged(Nothing, Nothing)
            For i As Integer = 0 To grvDSHieuChuanMay.RowCount - 1
                If grvDSHieuChuanMay.GetDataRow(i)("MS_MAY") = strMA_MAY_TMP And grvDSHieuChuanMay.GetDataRow(i)("NGAY_HC") = Date.Parse(strNGAY_HC_TMP) Then
                    grvDSHieuChuanMay.FocusedRowHandle = i
                    Showhieuchuanmay(i)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try


    End Sub


    Private Sub txtNgayHCMAY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNgayHCMAY.Validating
        If BtnThemMAY.Visible = True Then
            Exit Sub
        End If
        If txtNgayHCMAY.Text <> "" And txtNgayHCMAY.Text <> "__/__/____" Then
            If IsDate(txtNgayHCMAY.Text) Then
                If Date.Parse(txtNgayHCMAY.Text) < Date.Parse("01/01/1900") Then
                    'ngay nhập không hợp lệ
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgay", Commons.Modules.TypeLanguage),
                                                                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtNgayHCMAY.Text = ""
                    e.Cancel = True
                    Exit Sub
                ElseIf Date.Parse(txtNgayHCMAY.Text).Date > Date.Parse(Now.Date) Then

                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayLon", Commons.Modules.TypeLanguage),
                                                                                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtNgayHCMAY.Text = Now.Date
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf Not IsDate(txtNgayHCMAY.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgay", Commons.Modules.TypeLanguage),
                                                                                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayHCMAY.Text = Now.Date
                e.Cancel = True
                Exit Sub

            End If
        Else
            txtNgayHCMAY.Text = Now.Date
            e.Cancel = True
            Exit Sub
        End If
    End Sub



    Sub LocTheoMay()
        Dim dtReader As SqlDataReader

        Try
            grdDSHieuChuanMay.DataSource = Nothing
            grvDSHieuChuanMay.Columns.Clear()
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_MAYController().GetHIEU_CHUAN_MAY_Theo_MS_MAY(cboThietbiLoctheomay1.EditValue), False, True, True, True, True, "")
        Try
        Catch ex As Exception
        End Try


        If cboThietbiLoctheomay1.EditValue = "" Then
            TxtNhomMay.Text = ""
            Exit Sub
        End If
        Commons.Modules.SQLString = "SELECT TEN_NHOM_MAY FROM NHOM_MAY INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY=MAY.MS_NHOM_MAY WHERE MS_MAY=N'" & cboThietbiLoctheomay1.EditValue & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            TxtNhomMay.Text = dtReader.Item(0)
        End While
        dtReader.Close()
        Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
        Try
            opts.Columns.StoreAllOptions = True
            grdDSHieuChuanMay.MainView.RestoreLayoutFromRegistry(regHCM)
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "private dong ho do"
    Sub LoadThietbiDHD()
        cboThietbi_DHD.Display = "MS_MAY"
        cboThietbi_DHD.Value = "MS_MAY"
        cboThietbi_DHD.StoreName = "GetCHU_KY_HIEU_CHUAN_MS_MAYs"
        cboThietbi_DHD.Param = Commons.Modules.UserName
        cboThietbi_DHD.BindDataSource()
        If cboThietbi_DHD.Items.Count > 0 Then
            BtnThemDHD.Enabled = True
        Else
            BtnThemDHD.Enabled = False
        End If
        LoadDHD()
    End Sub
    Sub LoadDHD()
        If cboThietbi_DHD.SelectedIndex = -1 Then
            cboDHDo.Properties.DataSource = Nothing
            cboViTriDHD.Properties.DataSource = Nothing
            Exit Sub
        End If
        Try
            cboDHDo.Properties.DataSource = Nothing
        Catch ex As Exception
        End Try
        Dim dt As New DataTable
        If BtnGhiDHD.Visible = True Then
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHU_KY_HIEU_CHUAN_MS_PTs_Active", cboThietbi_DHD.SelectedValue))
        Else
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHU_KY_HIEU_CHUAN_MS_PTs", cboThietbi_DHD.SelectedValue))
        End If
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDHDo, dt, "MS_PT", "TENPT", "TENPT")
        Loadvitri()
    End Sub
    Sub LoadHC()

        Try
            cboLoaiHCHDH.Properties.DataSource = Nothing
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetLOAI_HIEU_CHUAN"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiHCHDH, dt, "MS_LOAI_HIEU_CHUAN", "TEN_LOAI_HIEU_CHUAN", "TEN_LOAI_HIEU_CHUAN")


    End Sub
    Public Sub LoadMS_LOAI_HIEU_CHUAN()

        Try
            cboLoaiHieuChuan.Properties.DataSource = Nothing
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiHieuChuanMay"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiHieuChuan, dt, "MS_LOAI_HIEU_CHUAN", "TEN_LOAI_HIEU_CHUAN", "TEN_LOAI_HIEU_CHUAN")


        LoadHC()
    End Sub

    Sub LoadcboNam()

        Try
            cboNamDHD1.Properties.DataSource = Nothing
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEU_CHUAN_DHD_Theo_NAM"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNamDHD1, dt, "NAM", "NAM", "NAM")

    End Sub
    Sub LoadcboThietbihieuchuantheoDHD()

        Try
            cboThietbitheoDHD1.Properties.DataSource = Nothing
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_MAY_HIEU_CHUAN_DHD", Commons.Modules.UserName))
        Dim dr As DataRow = dt.NewRow
        dr("MS_MAY") = "-1"
        dr("TEN_MAY") = "< ALL >"
        dt.Rows.InsertAt(dr, 0)

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThietbitheoDHD1, dt, "MS_MAY", "TEN_MAY", "TEN_MAY")



    End Sub
    Sub LoadDHD_filter()
        If cboThietbitheoDHD1.EditValue = Nothing Then
            Exit Sub
        End If
        Try
            cboDongHo1.Properties.DataSource = Nothing
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHU_KY_HIEU_CHUAN_MS_PTs", cboThietbitheoDHD1.EditValue))
        Dim dr As DataRow = dt.NewRow
        dr("MS_PT") = "-1"
        dr("TENPT") = "< ALL >"
        dt.Rows.InsertAt(dr, 0)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDongHo1, dt, "MS_PT", "TENPT", "TENPT")

    End Sub
    Sub Loadvitri()
        If cboDHDo.EditValue = Nothing Then
            Exit Sub
        End If

        Try
            cboViTriDHD.Properties.DataSource = Nothing
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        dt = New clsHIEU_CHUAN_DHDController().GetCHU_KY_HIEU_CHUAN_MS_VI_TRIs(cboThietbi_DHD.SelectedValue, cboDHDo.EditValue)

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboViTriDHD, dt, "MS_VI_TRI", "TEN_VI_TRI", "TEN_VI_TRI")
    End Sub
    Sub EnableHieuchuanDHD(ByVal chon As Boolean)
        cboThietbi_DHD.Enabled = chon
        cboDHDo.Enabled = chon
        cboViTriDHD.Enabled = chon
        btnTMaya.Enabled = chon
    End Sub
    Sub LoadhieuchuanDHD()
        Try
            grdDSHieuChuanDHD.DataSource = Nothing
            grvDSHieuChuanDHD.Columns.Clear()
        Catch ex As Exception
        End Try
        Commons.Modules.SQLString = "0Load"
        If cboNamDHD1.EditValue <> Nothing Then
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_DHDController().GetHIEU_CHUAN_DHD_LOC(cboNamDHD1.EditValue, cboThietbitheoDHD1.EditValue, IIf(cboDongHo1.EditValue Is Nothing, "-1", cboDongHo1.EditValue), Commons.Modules.UserName), False, True, True, True, True, "")

        Else
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanDHD, grvDSHieuChuanDHD, New clsHIEU_CHUAN_DHDController().GetHIEU_CHUAN_DHDs(), False, True, True, True, True, "")
        End If
        Commons.Modules.SQLString = ""
        Try
            grvDSHieuChuanDHD.Columns("MS_MAY").Width = 95
            Me.grvDSHieuChuanDHD.Columns("MS_PT").Width = 100
            grvDSHieuChuanDHD.Columns("MS_VI_TRI").Width = 100
            grvDSHieuChuanDHD.Columns("TEN_PT").Width = 150
            grvDSHieuChuanDHD.Columns("DANH_GIA").Width = 120
            grvDSHieuChuanDHD.Columns("GIAY_CHUNG_NHAN").Width = 150
            grvDSHieuChuanDHD.Columns("CO_QUAN_HIEU_CHUAN").Width = 154
            grvDSHieuChuanDHD.Columns("NGAYHCKE").Width = 95
            grvDSHieuChuanDHD.Columns("NGAY_KH").Width = 95
            grvDSHieuChuanDHD.Columns("TEN_LOAI_HIEU_CHUAN").Width = 150
            grvDSHieuChuanDHD.Columns("DD_GOC").Visible = False
            grvDSHieuChuanDHD.Columns("MS_LOAI_HIEU_CHUAN").Visible = False
            grvDSHieuChuanDHD.Columns("NGAY").Width = 95
            grvDSHieuChuanDHD.Columns("GHI_CHU").Visible = False
            grvDSHieuChuanDHD.Columns("DUONG_DAN").Visible = False
            grvDSHieuChuanDHD.Columns("NOI").Visible = False


        Catch ex As Exception
        End Try
        If grvDSHieuChuanDHD.RowCount > 0 Then
            BtnSuaDHD.Enabled = True
            BtnXoaDHD.Enabled = True
            BtnInDHD.Enabled = True
        Else
            BtnSuaDHD.Enabled = False
            BtnXoaDHD.Enabled = False
            BtnInDHD.Enabled = False
        End If
        Try
            Me.grvDSHieuChuanDHD.Columns("MS_PT").SortMode = DataGridViewColumnSortMode.Automatic

        Catch ex As Exception
        End Try

    End Sub
    Sub LockhieuchuanDHD(ByVal chon As Boolean)
        cboThietbi_DHD.Enabled = Not chon
        btnTMaya.Enabled = Not chon
        cboDHDo.Enabled = Not chon
        cboViTriDHD.Enabled = Not chon
        txtNgayHCDHD.ReadOnly = chon
        txtGiayCNDHD.ReadOnly = chon
        txtCoquanDHD.ReadOnly = chon
        txtNoidungDHD.ReadOnly = chon
        chkNoi.Enabled = Not chon
        dtNgayDHD.Enabled = Not chon

        txtNgayKH.ReadOnly = chon
        'dtNgayKH.Enabled = Not chon
        txtDDan.Properties.ReadOnly = True
        txtDDGoc.ReadOnly = chon
        txtGhiChu.ReadOnly = chon
        cboLoaiHCHDH.Enabled = Not chon
        txtDDan.Properties.Buttons(0).Enabled = chon
    End Sub
    Sub VisiblebuttonDHD(ByVal chon As Boolean)
        BtnThemDHD.Visible = chon
        BtnSuaDHD.Visible = chon
        BtnXoaDHD.Visible = chon
        BtnInDHD.Visible = chon
        BtnThoatDHD.Visible = chon
        BtnGhiDHD.Visible = Not chon
        BtnKhongghiDHD.Visible = Not chon
        grdDSHieuChuanDHD.Enabled = chon
    End Sub
    Sub RefeshhieuchuanDHD()
        cboThietbi_DHD.SelectedIndex = -1
        txtThietbi_DHD.Text = ""
        txtNgayHCDHD.Text = ""
        txtGiayCNDHD.Text = ""
        txtCoquanDHD.Text = ""
        txtNgayHCDHD.Text = ""
        txtNoidungDHD.Text = ""

        txtNgayKH.Text = ""
        txtDDan.Text = ""
        txtGhiChu.Text = ""
        txtDDGoc.Text = ""
        cboDHDo.EditValue = "-1"
        cboViTriDHD.EditValue = "-1"
    End Sub
    Sub EnableLoctheoDHD(ByVal chon As Boolean)
        cboNamDHD1.Enabled = chon
        cboThietbitheoDHD1.Enabled = chon
        cboDongHo1.Enabled = chon
    End Sub
    Sub ShowhieuchuanDHD(ByVal intRow As Integer)
        Try
            Commons.Modules.SQLString = "0Load"
            cboThietbi_DHD.SelectedValue = grvDSHieuChuanDHD.GetDataRow(intRow)("MS_MAY")
            strMS_MAY = grvDSHieuChuanDHD.GetDataRow(intRow)("MS_MAY")
            txtThietbi_DHD.Text = strMS_MAY

            LoadDHD()
            cboDHDo.EditValue = grvDSHieuChuanDHD.GetDataRow(intRow)("MS_PT")
            strMS_PT = grvDSHieuChuanDHD.GetDataRow(intRow)("MS_PT")

            Loadvitri()
            cboViTriDHD.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("MS_VI_TRI")
            intMS_VI_TRI = grvDSHieuChuanDHD.GetDataRow(intRow)("MS_VI_TRI")

            LoadHC()
            cboLoaiHCHDH.EditValue = grvDSHieuChuanDHD.GetDataRow(intRow)("MS_LOAI_HIEU_CHUAN")

            Try
                dtNgayDHD.DateTime = Convert.ToDateTime(txtNgayHCDHD.Text)
            Catch ex As Exception

            End Try


            txtNgayHCDHD.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("NGAY")
            strNGAY_HC = grvDSHieuChuanDHD.GetDataRow(intRow)("NGAY")


            txtGiayCNDHD.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("GIAY_CHUNG_NHAN").ToString()
            txtCoquanDHD.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("CO_QUAN_HIEU_CHUAN").ToString()
            txtNoidungDHD.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("DANH_GIA").ToString()
            chkNoi.Checked = grvDSHieuChuanDHD.GetDataRow(intRow)("NOI")

            txtDDan.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("DUONG_DAN").ToString()
            txtGhiChu.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("GHI_CHU").ToString()
            txtDDGoc.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("DD_GOC").ToString()

            If IsDBNull(grvDSHieuChuanDHD.GetDataRow(intRow)("NGAY_KH")) Then
                txtNgayKH.Text = "__/__/____"
                strNGAY_KH = txtNgayKH.Text
            Else
                txtNgayKH.Text = grvDSHieuChuanDHD.GetDataRow(intRow)("NGAY_KH")
                strNGAY_KH = grvDSHieuChuanDHD.GetDataRow(intRow)("NGAY_KH")
            End If
            Commons.Modules.SQLString = ""
        Catch ex As Exception
            RefeshhieuchuanDHD()
            Commons.Modules.SQLString = ""
        End Try

    End Sub
    Function AddhieuchuanDHD() As Boolean
        Dim objHIEU_CHUAN_DHDInfo As New HIEU_CHUAN_DHDInfo()
        objHIEU_CHUAN_DHDInfo.MS_MAY = cboThietbi_DHD.SelectedValue
        objHIEU_CHUAN_DHDInfo.MS_PT = cboDHDo.EditValue
        objHIEU_CHUAN_DHDInfo.MS_VI_TRI = cboViTriDHD.EditValue
        objHIEU_CHUAN_DHDInfo.NGAY = txtNgayHCDHD.Text
        objHIEU_CHUAN_DHDInfo.GIAY_CHUNG_NHAN = txtGiayCNDHD.Text
        objHIEU_CHUAN_DHDInfo.CO_QUAN_HIEU_CHUAN = txtCoquanDHD.Text
        objHIEU_CHUAN_DHDInfo.DANH_GIA = txtNoidungDHD.Text
        objHIEU_CHUAN_DHDInfo.NOI = chkNoi.Checked

        objHIEU_CHUAN_DHDInfo.NGAY_KH = txtNgayKH.Text
        objHIEU_CHUAN_DHDInfo.MS_LOAI_HIEU_CHUAN = cboLoaiHCHDH.EditValue
        objHIEU_CHUAN_DHDInfo.DUONG_DAN = txtDDan.Text
        objHIEU_CHUAN_DHDInfo.GHI_CHU = txtGhiChu.Text
        objHIEU_CHUAN_DHDInfo.DD_GOC = txtDDGoc.Text

        Dim objHIEU_CHUAN_DHDController As New clsHIEU_CHUAN_DHDController()
        If bThem = 1 Then
            Try
                objHIEU_CHUAN_DHDController.AddHIEU_CHUAN_DHD(objHIEU_CHUAN_DHDInfo)
                AddHIEU_CHUAN_DHD(objHIEU_CHUAN_DHDInfo)
            Catch ex As Exception
                Return False
            End Try
        Else
            If bThem = 2 Then
                objHIEU_CHUAN_DHDInfo.MS_MAY_TMP = strMS_MAY
                objHIEU_CHUAN_DHDInfo.MS_PT_TMP = strMS_PT
                objHIEU_CHUAN_DHDInfo.MS_VI_TRI_TMP = intMS_VI_TRI
                objHIEU_CHUAN_DHDInfo.NGAY_TMP = strNGAY_HC
                Try
                    UpdateHIEU_CHUAN_DHD(objHIEU_CHUAN_DHDInfo)
                    objHIEU_CHUAN_DHDController.UpdateHIEU_CHUAN_DHD(objHIEU_CHUAN_DHDInfo)
                Catch ex As Exception
                    Return False
                End Try
            End If
        End If
        Return True
    End Function

#End Region
#Region "hiệu chuẩn dồng hồ đo"
    Private Sub BtnThoatDHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoatDHD.Click
        Me.Close()
    End Sub
    Private Sub UpdateHIEU_CHUAN_DHD(ByVal objHIEU_CHUAN_DHDInfo As HIEU_CHUAN_DHDInfo)
        Dim sql As String
        Try
            sql = "exec UPDATE_HIEU_CHUAN_DHD_LOG '" & objHIEU_CHUAN_DHDInfo.MS_MAY & "','" & objHIEU_CHUAN_DHDInfo.MS_PT & "','" & objHIEU_CHUAN_DHDInfo.MS_VI_TRI & "','" & Format(CDate(objHIEU_CHUAN_DHDInfo.NGAY), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',2"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddHIEU_CHUAN_DHD(ByVal objHIEU_CHUAN_DHDInfo As HIEU_CHUAN_DHDInfo)
        Dim sql As String
        Try
            sql = "exec UPDATE_HIEU_CHUAN_DHD_LOG '" & objHIEU_CHUAN_DHDInfo.MS_MAY & "','" & objHIEU_CHUAN_DHDInfo.MS_PT & "','" & objHIEU_CHUAN_DHDInfo.MS_VI_TRI & "','" & Format(CDate(objHIEU_CHUAN_DHDInfo.NGAY), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnThemDHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThemDHD.Click
        bThem = 1
        bTab = 1
        VisiblebuttonDHD(False)
        RefeshhieuchuanDHD()
        txtNgayHCDHD.Text = Now.Date
        txtNgayKH.Text = Now.Date
        LockhieuchuanDHD(False)
        EnableLoctheoDHD(False)
        cboThietbi_DHD.Focus()
        LoadDHD()
        txtNgayKH.Enabled = False
        dtNgayDHD.DateTime = Now.Date
    End Sub

    Private Sub BtnSuaDHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuaDHD.Click
        bThem = 2
        bTab = 1
        VisiblebuttonDHD(False)
        LockhieuchuanDHD(False)
        EnableLoctheoDHD(False)
        EnableHieuchuanDHD(False)
        txtNgayKH.Enabled = False
    End Sub

    Private Sub BtnKhongghiDHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghiDHD.Click

        bThem = 0
        VisiblebuttonDHD(True)
        LockhieuchuanDHD(True)
        EnableLoctheoDHD(True)
        RefeshhieuchuanDHD()
        cboNamDHD1_EditValueChanged(Nothing, Nothing)
    End Sub
    Private Sub BtnXoaDHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoaDHD.Click
        If grvDSHieuChuanDHD.RowCount <= 0 Then
            'thông báo không có dữ liệu để xóa
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        Else
            'hỏi có muốn xóa thông tin người yêu cầu và chi tiết yêu cầu không? nếu muốn xóa chi tiêt yêu cầu hãy chọn tab chi tiết trước khi nhấn nút xóa
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim tmp As Integer = intRow1
                Dim objHIEU_CHUAN_DHDController As New clsHIEU_CHUAN_DHDController()
                DeleteHIEU_CHUAN_DHD(strMS_MAY, strMS_PT, intMS_VI_TRI, strNGAY_HC)
                objHIEU_CHUAN_DHDController.DeleteHIEU_CHUAN_DHD(strMS_MAY, strMS_PT, intMS_VI_TRI, strNGAY_HC)
                RefeshhieuchuanDHD()

                LoadcboNam()
                LoadcboThietbihieuchuantheoDHD()
                cboNamDHD1_EditValueChanged(Nothing, Nothing)
            End If
        End If
    End Sub
    Public Sub DeleteHIEU_CHUAN_DHD(ByVal strMS_MAY As String, ByVal strMS_PT As String, ByVal intMS_VI_TRI As String, ByVal strNGAY_HC As String)
        Dim sql As String
        Try
            sql = "exec UPDATE_HIEU_CHUAN_DHD_LOG '" & strMS_MAY & "','" & strMS_PT & "',N'" & intMS_VI_TRI & "','" & Format(CDate(strNGAY_HC), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnGhiDHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhiDHD.Click


        'kiểm tra ngày chưa nhập
        If txtNgayHCDHD.Text = "" Or txtNgayHCDHD.Text = "__/__/____" Then
            txtNgayHCDHD.Text = dtNgayDHD.DateTime.Date
        End If

        If txtNgayKH.Text = "" Or txtNgayKH.Text = "__/__/____" Then
            txtNgayKH.Text = Now.Date
        End If

        If txtNgayHCDHD.Text <> "" And txtNgayHCDHD.Text <> "__/__/____" Then
            If Not IsDate(txtNgayHCDHD.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgay", Commons.Modules.TypeLanguage),
                                                           MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayHCDHD.Focus()
                Exit Sub
            ElseIf Date.Parse(txtNgayHCDHD.Text).Date < Date.Parse("01/01/1900") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgay", Commons.Modules.TypeLanguage),
                                                                           MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayHCDHD.Focus()
                Exit Sub
            ElseIf Date.Parse(txtNgayHCDHD.Text).Date > Date.Parse(Now.Date).Date Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayLon", Commons.Modules.TypeLanguage),
                                                                           MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayHCDHD.Focus()
                Exit Sub
            End If
        Else
            txtNgayHCDHD.Focus()
            Exit Sub
        End If


        'kiểm tra đồng hồ đo
        If cboDHDo.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrong", Commons.Modules.TypeLanguage),
                                                   MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            cboThietbi.Focus()
            Exit Sub
        ElseIf cboViTriDHD.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrong", Commons.Modules.TypeLanguage),
                                                    MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            cboThietbi.Focus()
            Exit Sub
        End If
        If cboLoaiHCHDH.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrongLoaiHieuChuan", Commons.Modules.TypeLanguage),
                                                    MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            cboLoaiHCHDH.Focus()
            Exit Sub
        End If
        If txtGiayCNDHD.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGiayChungNhan", Commons.Modules.TypeLanguage),
                                                    MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtGiayCNDHD.Focus()
            Exit Sub
        End If
        If txtCoquanDHD.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCoQuanHieuChuan", Commons.Modules.TypeLanguage),
                                                    MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtCoquanDHD.Focus()
            Exit Sub
        End If
        If txtNoidungDHD.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDanhGia", Commons.Modules.TypeLanguage),
                                                                                                        MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtNoidungDHD.Focus()
            Exit Sub
        End If
        For i As Integer = 0 To grvDSHieuChuanDHD.RowCount - 1
            If grvDSHieuChuanDHD.GetDataRow(i)("MS_MAY") = cboThietbi_DHD.SelectedValue And grvDSHieuChuanDHD.GetDataRow(i)("MS_PT") = cboDHDo.EditValue And
                grvDSHieuChuanDHD.GetDataRow(i)("MS_VI_TRI") = cboViTriDHD.EditValue And
                 grvDSHieuChuanDHD.GetDataRow(i)("NGAY").Date = txtNgayHCDHD.Text Then
                If (bThem = 2 And cboThietbi_DHD.SelectedValue <> strMS_MAY And cboDHDo.EditValue <> strMS_PT And cboViTriDHD.EditValue <> intMS_VI_TRI _
                        And Date.Parse(txtNgayHCDHD.Text).Date <> strNGAY_HC) Or bThem = 1 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrung", Commons.Modules.TypeLanguage),
                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    cboThietbi.Focus()
                    Exit Sub
                End If
            End If
        Next
        Try
            Cursor = Cursors.WaitCursor

            If AddhieuchuanDHD() = False Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRUNG_DL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            Else

            End If
            Try
                Commons.Modules.ObjSystems.LuuDuongDan(txtDDGoc.Text, txtDDan.Text)
            Catch ex As Exception

            End Try



            Dim strmsmay, strmspt, strngay As String
            Dim intmsvitri As String
            Dim MsLHC As Integer

            strmsmay = cboThietbi_DHD.SelectedValue
            MsLHC = cboLoaiHCHDH.EditValue
            strmspt = cboDHDo.EditValue
            strngay = txtNgayHCDHD.Text

            intmsvitri = cboViTriDHD.EditValue
            bThem = 0


            Commons.Modules.SQLString = "0Load"
            LoadcboNam()
            LoadcboThietbihieuchuantheoDHD()
            Commons.Modules.SQLString = ""
            cboNamDHD1_EditValueChanged(Nothing, Nothing)
            VisiblebuttonDHD(True)
            EnableLoctheoDHD(True)
            LockhieuchuanDHD(True)
            Cursor = Cursors.Default
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cboThietbi_DHD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboThietbi_DHD.GotFocus
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub

        cboDHDo.Text = ""
        LoadDHD()
    End Sub
    Private Sub cboThietbi_DHD_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboThietbi_DHD.SelectionChangeCommitted
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub

        cboDHDo.Text = ""
        LoadDHD()
    End Sub

    Private Sub cboDHDo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub

        cboViTriDHD.Text = ""
        Loadvitri()
    End Sub



#End Region

    Sub CreaterptTieuDeHieuChuanDHD()
        Dim sTieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TieuDe1", Commons.Modules.TypeLanguage)
        Dim sTuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TuNgay", Commons.Modules.TypeLanguage)
        Dim sDenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "DenNgay", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "STT", Commons.Modules.TypeLanguage)
        Dim sVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "VatTu", Commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "Ngay", Commons.Modules.TypeLanguage)
        Dim sNgayKH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "Ngay_KH", Commons.Modules.TypeLanguage)
        Dim sLoaiHieuChuan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TEN_LOAI_HIEU_CHUAN", Commons.Modules.TypeLanguage)
        Dim sGiayCN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "GiayCN", Commons.Modules.TypeLanguage)
        Dim sCoQuanHC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "CoQuanHC", Commons.Modules.TypeLanguage)
        Dim sDanhGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "DanhGia", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sNoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "Noi", Commons.Modules.TypeLanguage)
        Dim sMaVatTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "MaVatTu", Commons.Modules.TypeLanguage)
        Dim sViTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "ViTri", Commons.Modules.TypeLanguage)
        Dim str As String = ""
        Try
            str = "drop table rptTIEU_DE_HIEU_CHUAN_DHD"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try

        str = "CREATE TABLE DBO.rptTIEU_DE_HIEU_CHUAN_DHD(TypeLanguage int,sTieuDe nvarchar(255),sNgayIn nvarchar(20),sTrangIn nvarchar(20), sSTT nvarchar(5),sVatTu nvarchar(50),sNgay nvarchar(20),sNgayKH nvarchar(20),sLoaiHieuChuan nvarchar(250),sGiayCN nvarchar(50),sCoQuanHC nvarchar(50),sDanhGia nvarchar(50),sNoi nvarchar(20),sMaVatTu nvarchar(30),sViTri nvarchar(30))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        str = "INSERT INTO rptTIEU_DE_HIEU_CHUAN_DHD VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTieuDe & "',N'" & sNgayIn & "',N'" & sTrangIn & "',N'" & sSTT & "',N'" & sVatTu & "',N'" & sNgay & "',N'" & sNgayKH & "',N'" & sLoaiHieuChuan & "',N'" & sGiayCN & "',N'" & sCoQuanHC & "',N'" & sDanhGia & "',N'" & sNoi & "',N'" & sMaVatTu & "',N'" & sViTri & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Private Sub BtnInDHD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInDHD.Click
        If cboNamDHD1.EditValue <> Nothing Then
            Me.Cursor = Cursors.WaitCursor
            InMayDHD()
            Me.Cursor = Cursors.Default
        End If
        Exit Sub
    End Sub
    Dim loai As Integer = 0


    Sub CreaterptTieuDeHieuChuanMay()


        Dim sTieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TieuDe", Commons.Modules.TypeLanguage)
        Dim sTuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TuNgay", Commons.Modules.TypeLanguage)
        Dim sDenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "DenNgay", Commons.Modules.TypeLanguage)
        Dim sThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "STT", Commons.Modules.TypeLanguage)
        Dim sMS_MAY As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim sNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "Ngay", Commons.Modules.TypeLanguage)
        Dim sNgay_KH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "Ngay_KH", Commons.Modules.TypeLanguage)
        Dim sNgay_KT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "Ngay_KT", Commons.Modules.TypeLanguage)
        Dim sGiayCN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "GiayCN", Commons.Modules.TypeLanguage)
        Dim sCoQuanHC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "CoQuanHC", Commons.Modules.TypeLanguage)
        Dim sDanhGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "DanhGia", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim str As String = ""
        Try
            str = "drop table rptTIEU_DE_HIEU_CHUAN_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try

        str = "CREATE TABLE dbo.rptTIEU_DE_HIEU_CHUAN_MAY(TypeLanguage int,Loai int,sTieuDe nvarchar(255),sTuNgay nvarchar(50), sDenNgay nvarchar(50),sThietBi nvarchar(30),sSTT nvarchar(5), sMS_MAY nvarchar(30),sNgay nvarchar(50),sNgay_KH nvarchar(50),sNgay_KT nvarchar(50),sGiayCN nvarchar(50),sCoQuanHC nvarchar(50),sDanhGia nvarchar(50),sNgayIn nvarchar(20),sTrangIn nvarchar(20))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        If optNTHT.SelectedIndex = 0 Then
            loai = 0
        Else
            If optNTHT.SelectedIndex = 2 Then
                loai = 1
            Else
                loai = 2
            End If
        End If
        str = "INSERT INTO rptTIEU_DE_HIEU_CHUAN_MAY VALUES(" & Commons.Modules.TypeLanguage & "," & loai & ",N'" & sTieuDe &
                "',N'" & sTuNgay & " : " & dtTungay1.DateTime.Date.ToString("dd/MM/yyyy") & "',N'" & sDenNgay & " : " &
                Format(dtDenngay1.DateTime, "dd/MM/yyyy") & "',N'" & sThietBi & "',N'" & sSTT & "',N'" & sMS_MAY & "',N'" & sNgay &
                "',N'" & sNgay_KH & "',N'" & sNgay_KT & "',N'" & sGiayCN & "',N'" & sCoQuanHC & "',N'" & sDanhGia & "',N'" & sNgayIn & "',N'" & sTrangIn & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub


    Function LanguageReportMay() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "rptTIEU_DE_HIEU_CHUAN_MAY"
        For i As Integer = 0 To 20
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "TypeLanguage"
        vtbTitle.Columns(1).ColumnName = "Loai"
        vtbTitle.Columns(2).ColumnName = "sTieuDe"
        vtbTitle.Columns(3).ColumnName = "sTuNgay"
        vtbTitle.Columns(4).ColumnName = "sDenNgay"
        vtbTitle.Columns(5).ColumnName = "sThietBi"
        vtbTitle.Columns(6).ColumnName = "sSTT"
        vtbTitle.Columns(7).ColumnName = "sMS_MAY"
        vtbTitle.Columns(8).ColumnName = "sNgay"
        vtbTitle.Columns(9).ColumnName = "sNgay_KH"
        vtbTitle.Columns(10).ColumnName = "sNgay_KT"
        vtbTitle.Columns(11).ColumnName = "sGiayCN"
        vtbTitle.Columns(12).ColumnName = "sCoQuanHC"
        vtbTitle.Columns(13).ColumnName = "sDanhGia"
        vtbTitle.Columns(14).ColumnName = "sNgayIn"
        vtbTitle.Columns(15).ColumnName = "sTrangIn"
        vtbTitle.Columns(16).ColumnName = "TMP1"
        vtbTitle.Columns(17).ColumnName = "TMP2"
        vtbTitle.Columns(18).ColumnName = "TMP3"
        vtbTitle.Columns(19).ColumnName = "TMP4"
        vtbTitle.Columns(20).ColumnName = "TMP5"

        Dim loai As Integer
        If optNTHT.SelectedIndex = 0 Then
            loai = 0
        Else
            If optNTHT.SelectedIndex = 2 Then
                loai = 1
            Else
                loai = 2
            End If
        End If

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TypeLanguage") = Commons.Modules.TypeLanguage.ToString()
        vRowTitle("Loai") = loai.ToString()
        vRowTitle("sTieuDe") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TieuDe", Commons.Modules.TypeLanguage)
        vRowTitle("sTuNgay") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TuNgay", Commons.Modules.TypeLanguage) & " : " & dtTungay1.DateTime.Date.ToString("dd/MM/yyyy")
        vRowTitle("sDenNgay") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "DenNgay", Commons.Modules.TypeLanguage) & " " &
                Format(dtDenngay1.DateTime, "dd/MM/yyyy")
        vRowTitle("sThietBi") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        vRowTitle("sSTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("sMS_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "MS_MAY", Commons.Modules.TypeLanguage)
        vRowTitle("sNgay") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "Ngay", Commons.Modules.TypeLanguage)

        vRowTitle("sNgay_KH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "Ngay_KH", Commons.Modules.TypeLanguage)
        vRowTitle("sNgay_KT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "Ngay_KT", Commons.Modules.TypeLanguage)


        vRowTitle("sGiayCN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "GiayCN", Commons.Modules.TypeLanguage)
        vRowTitle("sCoQuanHC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "CoQuanHC", Commons.Modules.TypeLanguage)
        vRowTitle("sDanhGia") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "DanhGia", Commons.Modules.TypeLanguage)
        vRowTitle("sNgayIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        vRowTitle("sTrangIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TrangIn", Commons.Modules.TypeLanguage)

        vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TEN_MAY", Commons.Modules.TypeLanguage)
        vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TMP2", Commons.Modules.TypeLanguage)
        vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TMP3", Commons.Modules.TypeLanguage)
        vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TMP4", Commons.Modules.TypeLanguage)
        vRowTitle("TMP5") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TMP5", Commons.Modules.TypeLanguage)




        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Function LanguageReportDHD() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "rptTIEU_DE_HIEU_CHUAN_DHD"
        For i As Integer = 0 To 20
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "sTieuDe1"
        vtbTitle.Columns(1).ColumnName = "sTuNgay"
        vtbTitle.Columns(2).ColumnName = "sDenNgay"
        vtbTitle.Columns(3).ColumnName = "sSTT"
        vtbTitle.Columns(4).ColumnName = "sVatTu"

        vtbTitle.Columns(5).ColumnName = "sNgay"
        vtbTitle.Columns(6).ColumnName = "sNgay_KH"
        vtbTitle.Columns(7).ColumnName = "sTEN_LOAI_HIEU_CHUAN"
        vtbTitle.Columns(8).ColumnName = "sGiayCN"
        vtbTitle.Columns(9).ColumnName = "sCoQuanHC"

        vtbTitle.Columns(10).ColumnName = "sDanhGia"
        vtbTitle.Columns(11).ColumnName = "sNgayIn"
        vtbTitle.Columns(12).ColumnName = "sTrangIn"
        vtbTitle.Columns(13).ColumnName = "sNoi"
        vtbTitle.Columns(14).ColumnName = "sMaVatTu"

        vtbTitle.Columns(15).ColumnName = "sViTri"

        vtbTitle.Columns(16).ColumnName = "TMP1"
        vtbTitle.Columns(17).ColumnName = "TMP2"
        vtbTitle.Columns(18).ColumnName = "TMP3"
        vtbTitle.Columns(19).ColumnName = "TMP4"
        vtbTitle.Columns(20).ColumnName = "TMP5"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("sTieuDe1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TieuDe1", Commons.Modules.TypeLanguage)
        vRowTitle("sTuNgay") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TuNgay", Commons.Modules.TypeLanguage)
        vRowTitle("sDenNgay") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "DenNgay", Commons.Modules.TypeLanguage)
        vRowTitle("sSTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("sVatTu") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "VatTu", Commons.Modules.TypeLanguage)

        vRowTitle("sNgay") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "Ngay", Commons.Modules.TypeLanguage)
        vRowTitle("sNgay_KH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "Ngay_KH", Commons.Modules.TypeLanguage)
        vRowTitle("sTEN_LOAI_HIEU_CHUAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TEN_LOAI_HIEU_CHUAN", Commons.Modules.TypeLanguage)
        vRowTitle("sGiayCN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "GiayCN", Commons.Modules.TypeLanguage)
        vRowTitle("sCoQuanHC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "CoQuanHC", Commons.Modules.TypeLanguage)


        vRowTitle("sDanhGia") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "DanhGia", Commons.Modules.TypeLanguage)
        vRowTitle("sNgayIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "NgayIn", Commons.Modules.TypeLanguage)
        vRowTitle("sTrangIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TrangIn", Commons.Modules.TypeLanguage)
        vRowTitle("sNoi") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "Noi", Commons.Modules.TypeLanguage)
        vRowTitle("sMaVatTu") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "MaVatTu", Commons.Modules.TypeLanguage)

        vRowTitle("sViTri") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "ViTri", Commons.Modules.TypeLanguage)

        vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TMP1", Commons.Modules.TypeLanguage)

        vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TMP2", Commons.Modules.TypeLanguage)
        vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TMP3", Commons.Modules.TypeLanguage)
        vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TMP4", Commons.Modules.TypeLanguage)
        vRowTitle("TMP5") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_DHD", "TMP5", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Private Sub BtnInMAY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInMAY.Click
        Me.Cursor = Cursors.WaitCursor
        InMay()
        Me.Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub InMay()
        'Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
        'Dim dt As DataTable = grdDSHieuChuanMay.DataSource
        'If dt.Rows.Count = 0 Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_CO_DL_IN", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        'Else
        '    dt.TableName = "rptHIEU_CHUAN_MAY"
        '    frmRpt.AddDataTableSource(dt)
        '    frmRpt.AddDataTableSource(LanguageReportMay)
        '    frmRpt.rptName = "rptHIEU_CHUAN_MAY"
        '    Commons.Modules.SQLString = "0Design"
        '    frmRpt.ShowDialog()
        '    Commons.Modules.SQLString = ""
        'End If
        Try
            Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
            composLink.Margins.Left = 50
            composLink.Margins.Right = 50
            composLink.Margins.Top = 130
            composLink.Margins.Bottom = 50
            composLink.PaperKind = System.Drawing.Printing.PaperKind.A4
            composLink.Landscape = True
            composLink.Margins.Clone()

            Dim leftColumn As String = "" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRANG", Commons.Modules.TypeLanguage) + ": [Page # of Pages #]"
            'Dim middleColumn As String = "User: " & Commons.Modules.UserName
            'Dim rightColumn As String = "Ngày in: [Date Printed]"
            Dim phf As PageHeaderFooter = TryCast(composLink.PageHeaderFooter, PageHeaderFooter)
            phf.Footer.Content.Clear()
            phf.Footer.Content.AddRange(New String() {"", leftColumn, ""})
            phf.Footer.LineAlignment = BrickAlignment.Far
            Dim header As PageHeaderArea = New PageHeaderArea()
            AddHandler composLink.CreateMarginalHeaderArea, AddressOf CreateMarginalHeaderArea
            Dim linkGrid1Report As Link = New Link()
            grvDSHieuChuanMay.OptionsPrint.AutoWidth = True
            PrintableComponentLink1.Component = grdDSHieuChuanMay
            composLink.Links.Add(linkGrid1Report)
            composLink.Links.Add(PrintableComponentLink1)
            composLink.ShowPreviewDialog()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)

        Dim dtTmp As DataTable = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, "SELECT LOGO,CASE WHEN " & Commons.Modules.TypeLanguage & "=0  THEN TEN_CTY_TIENG_VIET ELSE TEN_CTY_TIENG_ANH END + CASE WHEN " & Commons.Modules.TypeLanguage & "=0 THEN DIA_CHI_VIET  ELSE DIA_CHI_ANH END +'Phone : ' + Phone + '. Fax : ' + Fax + EMAIL AS 'TTC' FROM THONG_TIN_CHUNG  "))

        Dim data As Byte() = New Byte(-1) {}
        data = CType((dtTmp.Rows(0)(0)), Byte())
        Dim rec1 As RectangleF = New RectangleF(0, 0, 150, 50)
        Dim mem As MemoryStream = New MemoryStream(data)
        e.Graph.DrawImage(Image.FromStream(mem), rec1, BorderSide.None, Color.White)

        Dim rec2 As RectangleF = New RectangleF(155, 0, 400, 50)
        e.Graph.Font = New Font("Tahoma", 8, FontStyle.Regular)
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        e.Graph.DrawString(dtTmp.Rows(0)(1).ToString(), Color.Black, rec2, BorderSide.None)

        Dim rec3 As RectangleF = New RectangleF(e.Graph.ClientPageSize.Width - 120, 0, 120, 50)
        e.Graph.Font = New Font("Tahoma", 8, FontStyle.Regular)
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Far)
        e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ngayin", Commons.Modules.TypeLanguage) + " " + DateTime.Now.Date, Color.Black, rec3, BorderSide.None)
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 16, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 55, e.Graph.ClientPageSize.Width, 35)
        e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptHIEU_CHUAN_MAY", "TieuDe", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None)

        Dim rec4 As RectangleF = New RectangleF(0, 85, e.Graph.ClientPageSize.Width, 25)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)

        If optNTHT.SelectedIndex = 1 Then
            e.Graph.DrawString(LblMS_MAY.Text + ": " + cboThietbi.Text, Color.Black, rec4, BorderSide.None)
        End If

        If optNTHT.SelectedIndex = 2 Then
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY", Commons.Modules.TypeLanguage) + " " + dtTungay1.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage) + " " + dtDenngay1.Text, Color.Black, rec4, BorderSide.None)
        End If

    End Sub

    Private Sub InMayDHD()
        Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
        Dim dt As DataTable = New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "rptHieuChuanDHD", cboThietbi_DHD.SelectedValue, cboNamDHD1.EditValue, Commons.Modules.TypeLanguage))
        If dt.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_CO_DL_IN", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        Else
            dt.TableName = "rptHIEU_CHUAN_DHD"
            frmRpt.AddDataTableSource(dt)
            frmRpt.AddDataTableSource(LanguageReportDHD)
            frmRpt.rptName = "rptHIEU_CHUAN_DHD"
            Commons.Modules.SQLString = "0Design"
            frmRpt.ShowDialog()
            Commons.Modules.SQLString = ""
        End If
    End Sub

    Private Sub LoadDataThietBiTheoDHD()
        Try
            grdDSHieuChuanDHD.DataSource = Nothing
            grvDSHieuChuanDHD.Columns.Clear()
        Catch ex As Exception
        End Try
        Commons.Modules.SQLString = "0Load"
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanDHD, grvDSHieuChuanDHD, New clsHIEU_CHUAN_DHDController().GetHIEU_CHUAN_DHD_LOC(cboNamDHD1.EditValue, cboThietbitheoDHD1.EditValue, IIf(cboDongHo1.EditValue Is Nothing, "-1", cboDongHo1.EditValue), Commons.Modules.UserName), False, True, True, True, True, "")
        Commons.Modules.SQLString = ""
        Try
            grvDSHieuChuanDHD.Columns("MS_MAY").Width = 95
            grvDSHieuChuanDHD.Columns("MS_PT").Width = 100
            grvDSHieuChuanDHD.Columns("MS_VI_TRI").Width = 100
            grvDSHieuChuanDHD.Columns("TEN_PT").Width = 150
            grvDSHieuChuanDHD.Columns("DANH_GIA").Width = 120
            grvDSHieuChuanDHD.Columns("NGAY").Width = 95
            grvDSHieuChuanDHD.Columns("GIAY_CHUNG_NHAN").Width = 150
            grvDSHieuChuanDHD.Columns("CO_QUAN_HIEU_CHUAN").Width = 154
            grvDSHieuChuanDHD.Columns("NGAY_KH").Width = 95
            grvDSHieuChuanDHD.Columns("NGAYHCKE").Width = 95

            grvDSHieuChuanDHD.Columns("TEN_LOAI_HIEU_CHUAN").Width = 150
            grvDSHieuChuanDHD.Columns("DD_GOC").Visible = False
            grvDSHieuChuanDHD.Columns("MS_LOAI_HIEU_CHUAN").Visible = False
            grvDSHieuChuanDHD.Columns("GHI_CHU").Visible = False
            grvDSHieuChuanDHD.Columns("DUONG_DAN").Visible = False
            grvDSHieuChuanDHD.Columns("NOI").Visible = False

        Catch ex As Exception
        End Try
        If grvDSHieuChuanDHD.RowCount > 0 Then
            BtnSuaDHD.Enabled = True
            BtnXoaDHD.Enabled = True
            BtnInDHD.Enabled = True
        Else
            BtnSuaDHD.Enabled = False
            BtnXoaDHD.Enabled = False
            BtnInDHD.Enabled = False
        End If
    End Sub

    Private Sub txtNgayKH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNgayKH.Validating
        If BtnGhiDHD.Visible = False Then
            Exit Sub
        End If
        If txtNgayKH.Text <> "" And txtNgayKH.Text <> "__/__/____" Then
            If Not IsDate(txtNgayKH.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKH", Commons.Modules.TypeLanguage),
                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayKH.Text = ""
                e.Cancel = True
                Exit Sub
            ElseIf Date.Parse(txtNgayKH.Text) < Date.Parse("01/01/1900") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKH", Commons.Modules.TypeLanguage),
                                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayKH.Text = ""
                e.Cancel = True
                Exit Sub
            ElseIf Date.Parse(txtNgayKH.Text).Date > Date.Parse(Now.Date).Date Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKHLon", Commons.Modules.TypeLanguage),
                                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayKH.Text = ""
                e.Cancel = True
                Exit Sub
            End If
        Else
            txtNgayKH.Text = Now.Date
            e.Cancel = True
            Exit Sub
        End If
    End Sub



    Sub LayDuongDan()

        Dim TenFile = ofdDD.SafeFileName
        Dim strDuongDan = ofdDD.FileName
        txtDDGoc.Text = ofdDD.FileName

        Dim strDuongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(True, "Hieu_Chuan\" & cboThietbi_DHD.SelectedValue)
        txtDDan.Text = strDuongDanTmp & "\" & Convert.ToString(Format(Now, "yyyymmddHHmmss")) & "_" & TenFile

    End Sub
    Sub LayDuongDanTB()

        Dim TenFile = ofdDD.SafeFileName
        Dim strDuongDan = ofdDD.FileName
        txtDDGoc_TB.Text = ofdDD.FileName

        Dim strDuongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(True, "Hieu_Chuan\" & cboThietbi.SelectedValue)
        txttai_lieu.Text = strDuongDanTmp & "\" & Convert.ToString(Format(Now, "yyyymmddHHmmss")) & "_" & TenFile

    End Sub
    Private Sub txtDDan_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDDan.DoubleClick
        If BtnGhiDHD.Visible = False Then Exit Sub
        Dim res As New System.Windows.Forms.DialogResult
        res = ofdDD.ShowDialog()

        If res = Windows.Forms.DialogResult.OK Then
            LayDuongDan()
        End If

    End Sub

    Private Sub txtDDan_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDDan.ButtonClick
        If txtDDan.Text.Length = 0 Then Exit Sub
        Try
            Commons.Modules.ObjSystems.OpenHinh(txtDDan.Text)
        Catch ex As Exception

        End Try

    End Sub



    Private Sub txttai_lieu_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txttai_lieu.ButtonClick
        If txttai_lieu.Text.Length = 0 Then Exit Sub
        Try
            Commons.Modules.ObjSystems.OpenHinh(txttai_lieu.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttai_lieu_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttai_lieu.DoubleClick
        If BTnGhiMAY.Visible = False Then Exit Sub
        Dim res As New System.Windows.Forms.DialogResult
        res = ofdDD.ShowDialog()

        If res = Windows.Forms.DialogResult.OK Then
            LayDuongDanTB()
        End If
    End Sub


    Private Sub btnTMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMay.Click
        Dim frm As New ReportMain.Forms.frmYCSDChonMay()
        frm.iLoai = 3
        If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        cboThietbi.SelectedValue = Commons.Modules.SQLString
        txtThietBi.Text = Commons.Modules.SQLString
        Try
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_HC_MAX", txtThietBi.Text, Nothing, Nothing, cboLoaiHieuChuan.EditValue, False))
            If (dt.Rows.Count > 0) Then
                Try
                    Dim ngayHCCuoi As Date = Convert.ToDateTime(dt.Rows(0)("NGAY_HC_CUOI").ToString, New CultureInfo("vi-vn"))
                    Dim donVi As String = If(String.IsNullOrEmpty(dt.Rows(0)("DON_VI").ToString), 3, dt.Rows(0)("DON_VI").ToString)
                    Dim chuKy As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(dt.Rows(0)("CHU_KY").ToString), 0, dt.Rows(0)("CHU_KY").ToString))

                    ngayHCCuoi = If(donVi = "1", ngayHCCuoi.AddDays(chuKy), If(donVi = "2", ngayHCCuoi.AddDays(chuKy * 7), If(donVi = "3", ngayHCCuoi.AddMonths(chuKy), ngayHCCuoi.AddYears(chuKy))))
                    txtNgayKHMAY.Text = ngayHCCuoi
                Catch
                    txtNgayKHMAY.Text = Date.Now
                End Try
                Exit Sub
            End If
            txtNgayKHMAY.Text = Date.Now
        Catch
        End Try
    End Sub

    Private Sub btnTMaya_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMaya.Click
        Dim frm As New ReportMain.Forms.frmYCSDChonMay()
        frm.iLoai = 4
        If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        cboThietbi_DHD.SelectedValue = Commons.Modules.SQLString
        txtThietbi_DHD.Text = Commons.Modules.SQLString
        LoadDHD()

        Try
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_HC_MAX", txtThietbi_DHD.Text, cboDHDo.EditValue, cboViTriDHD.EditValue, cboLoaiHCHDH.EditValue, True))
            If (dt.Rows.Count > 0) Then
                Try
                    Dim ngayHCCuoi As Date = Convert.ToDateTime(dt.Rows(0)("NGAY_HC_CUOI").ToString, New CultureInfo("vi-vn"))
                    Dim donVi As String = If(String.IsNullOrEmpty(dt.Rows(0)("DON_VI").ToString), 3, dt.Rows(0)("DON_VI").ToString)
                    Dim chuKy As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(dt.Rows(0)("CHU_KY").ToString), 0, dt.Rows(0)("CHU_KY").ToString))

                    ngayHCCuoi = If(donVi = "1", ngayHCCuoi.AddDays(chuKy), If(donVi = "2", ngayHCCuoi.AddDays(chuKy * 7), If(donVi = "3", ngayHCCuoi.AddMonths(chuKy), ngayHCCuoi.AddYears(chuKy))))
                    txtNgayKH.Text = ngayHCCuoi
                Catch
                    txtNgayKH.Text = Date.Now
                End Try
                Exit Sub
            End If
            txtNgayKH.Text = Date.Now
        Catch
        End Try



    End Sub

    'Private Sub dtNgayKHMay_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txtNgayKHMAY.Text = dtNgayKHMay.Value.Date
    '    txtNgayKHMAY.Focus()
    'End Sub

    Private Sub txtTMayDCD_TextChanged(sender As Object, e As EventArgs) Handles txtTMayDCD.TextChanged
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grvDSHieuChuanDHD.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "MS_MAY like '%" + txtTMayDCD.Text + "%'  OR TEN_LOAI_HIEU_CHUAN like '%" + txtTMayDCD.Text + "%' 
                    OR MS_PT like '%" + txtTMayDCD.Text + "%'  OR TEN_PT like '%" + txtTMayDCD.Text + "%'  OR MS_VI_TRI like '%" + txtTMayDCD.Text + "%' "
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub

    Private Sub txtTMay_TextChanged(sender As Object, e As EventArgs) Handles txtTMay.TextChanged
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grvDSHieuChuanMay.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "MS_MAY like '%" + txtTMay.Text + "%'  OR TEN_LOAI_HIEU_CHUAN like '%" + txtTMay.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub


    Public Sub LocDuLieu(ByVal grd As System.Windows.Forms.DataGridView, ByVal sDKien As String, ByVal sTenCot As String)
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grd.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "MS_MAY like '%" + sDKien + "%' OR TEN_MAY like '%" + sDKien + "%' OR " + sTenCot + " like '%" + sDKien + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub

    Private Sub cboVitri_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If (BtnGhiDHD.Visible = False) Then Exit Sub

            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_HC_MAX", txtThietbi_DHD.Text, cboDHDo.EditValue, cboViTriDHD.EditValue, cboLoaiHCHDH.EditValue, True))
            If (dt.Rows.Count > 0) Then
                Try
                    Dim ngayHCCuoi As Date = Convert.ToDateTime(dt.Rows(0)("NGAY_HC_CUOI").ToString, New CultureInfo("vi-vn"))
                    Dim donVi As String = If(String.IsNullOrEmpty(dt.Rows(0)("DON_VI").ToString), 3, dt.Rows(0)("DON_VI").ToString)
                    Dim chuKy As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(dt.Rows(0)("CHU_KY").ToString), 0, dt.Rows(0)("CHU_KY").ToString))

                    ngayHCCuoi = If(donVi = "1", ngayHCCuoi.AddDays(chuKy), If(donVi = "2", ngayHCCuoi.AddDays(chuKy * 7), If(donVi = "3", ngayHCCuoi.AddMonths(chuKy), ngayHCCuoi.AddYears(chuKy))))
                    txtNgayKH.Text = ngayHCCuoi
                Catch
                    txtNgayKH.Text = Date.Now
                End Try
                Exit Sub
            End If
            txtNgayKH.Text = Date.Now
        Catch
        End Try

    End Sub

    Private Sub TabHieuchuan_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabHieuchuan.SelectedPageChanged
        If (bThem = 1 Or bThem = 2) Then
            ChangeTab(bTab)
        End If
    End Sub

    Private Sub cboThietbiLoctheomay1_EditValueChanged(sender As Object, e As EventArgs) Handles cboThietbiLoctheomay1.EditValueChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub

        Try
            grdDSHieuChuanMay.DataSource = Nothing
            grvDSHieuChuanMay.Columns.Clear()
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_MAYController().GetHIEU_CHUAN_MAY_Theo_MS_MAY(cboThietbiLoctheomay1.EditValue), False, True, True, True, True, "")
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub optNTHT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optNTHT.SelectedIndexChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        Commons.Modules.SQLString = "0Load"
        Cursor = Cursors.WaitCursor
        Try
            Try
                grdDSHieuChuanMay.DataSource = Nothing
                grvDSHieuChuanMay.Columns.Clear()
            Catch ex As Exception
            End Try

            If (optNTHT.SelectedIndex = 0) Then
                LockDieukienloctheomay_NgayHC(False)
                LockDieukienloctheomay_Thietbi(False)


                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_MAYController().GetHIEU_CHUAN_MAYs, False, True, True, True, True, "")

            ElseIf (optNTHT.SelectedIndex = 1) Then
                LockDieukienloctheomay_Thietbi(True)
                LockDieukienloctheomay_NgayHC(False)
                LoadcboThietbihieuchuantheomay()
                LocTheoMay()
            Else

                LockDieukienloctheomay_NgayHC(True)
                LockDieukienloctheomay_Thietbi(False)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_MAYController().GetHIEU_CHUAN_MAY_Theo_NGAY_HC(dtTungay1.DateTime.ToShortDateString(), dtDenngay1.DateTime.ToShortDateString()), False, True, True, True, True, "")
            End If
            FormartLuoi()
            Commons.Modules.SQLString = ""
            Showhieuchuanmay(grvDSHieuChuanMay.FocusedRowHandle)
            intRow = grvDSHieuChuanMay.FocusedRowHandle
            If (grvDSHieuChuanMay.RowCount = 0) Then
                BtnSuaMAY.Enabled = False
                BtnXoaMAY.Enabled = False
                BtnInMAY.Enabled = False
            Else
                BtnSuaMAY.Enabled = True
                BtnXoaMAY.Enabled = True
                BtnInMAY.Enabled = True
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub FormartLuoi()
        Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
        opts.Columns.StoreAllOptions = True
        Dim rkSubKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regHCM, False)
        If rkSubKey Is Nothing Then
            Try
                grvDSHieuChuanMay.Columns("MS_LOAI_HIEU_CHUAN").Visible = False
                grvDSHieuChuanMay.Columns("STT").Width = 50
                grvDSHieuChuanMay.Columns("MS_MAY").Width = 95
                grvDSHieuChuanMay.Columns("TEN_MAY").Width = 100
                grvDSHieuChuanMay.Columns("CHU_KY").Width = 80
                grvDSHieuChuanMay.Columns("NGAY_HC").Width = 100
                grvDSHieuChuanMay.Columns("NGAY_KH").Width = 100
                grvDSHieuChuanMay.Columns("NGAY_KT").Width = 100
                grvDSHieuChuanMay.Columns("GIAY_CHUNG_NHAN").Width = 120
                grvDSHieuChuanMay.Columns("CO_QUAN_HIEU_CHUAN").Width = 120
                grvDSHieuChuanMay.Columns("DANH_GIA").Width = 100
                grvDSHieuChuanMay.Columns("TEN_LOAI_HIEU_CHUAN").Width = 120
                grvDSHieuChuanMay.Columns("GHI_CHU").Width = 100
                grvDSHieuChuanMay.Columns("TAI_LIEU").Visible = False
                grvDSHieuChuanMay.Columns("STT").VisibleIndex = 0
                grvDSHieuChuanMay.Columns("MS_MAY").VisibleIndex = 1
                grvDSHieuChuanMay.Columns("TEN_MAY").VisibleIndex = 2
                grvDSHieuChuanMay.Columns("TEN_LOAI_HIEU_CHUAN").VisibleIndex = 3
                grvDSHieuChuanMay.Columns("NGAY_KH").VisibleIndex = 4
                grvDSHieuChuanMay.Columns("NGAY_HC").VisibleIndex = 5
                grvDSHieuChuanMay.Columns("NGAY_KT").VisibleIndex = 6
                grvDSHieuChuanMay.Columns("CHU_KY").VisibleIndex = 7
                grvDSHieuChuanMay.Columns("GIAY_CHUNG_NHAN").VisibleIndex = 8
                grvDSHieuChuanMay.Columns("CO_QUAN_HIEU_CHUAN").VisibleIndex = 9
                grvDSHieuChuanMay.Columns("DANH_GIA").VisibleIndex = 10
                grvDSHieuChuanMay.Columns("GHI_CHU").VisibleIndex = 11
                grdDSHieuChuanMay.MainView.SaveLayoutToRegistry(regHCM)
            Catch ex As Exception
            End Try
        Else
            grdDSHieuChuanMay.MainView.RestoreLayoutFromRegistry(regHCM)
        End If

    End Sub

    Private Sub grvDSHieuChuanMay_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDSHieuChuanMay.FocusedRowChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        Showhieuchuanmay(e.FocusedRowHandle)
        intRow = e.FocusedRowHandle
    End Sub

    Private Sub grvDSHieuChuanMay_ColumnFilterChanged(sender As Object, e As EventArgs) Handles grvDSHieuChuanMay.ColumnFilterChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub

        Showhieuchuanmay(grvDSHieuChuanMay.FocusedRowHandle)
        intRow = grvDSHieuChuanMay.FocusedRowHandle
    End Sub

    Private Sub dtTungay1_EditValueChanged(sender As Object, e As EventArgs) Handles dtTungay1.EditValueChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub

        Try
            grdDSHieuChuanMay.DataSource = Nothing
            grvDSHieuChuanMay.Columns.Clear()
        Catch ex As Exception
        End Try
        Commons.Modules.SQLString = "0Load"
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_MAYController().GetHIEU_CHUAN_MAY_Theo_NGAY_HC(dtTungay1.DateTime.ToShortDateString(), dtDenngay1.DateTime.ToShortDateString()), False, True, True, True, True, "")
        Try
            Commons.Modules.SQLString = ""
            Showhieuchuanmay(grvDSHieuChuanMay.FocusedRowHandle)
            intRow = grvDSHieuChuanMay.FocusedRowHandle

            If (grvDSHieuChuanMay.RowCount = 0) Then
                BtnSuaMAY.Enabled = False
                BtnXoaMAY.Enabled = False
                BtnInMAY.Enabled = False
            Else
                BtnSuaMAY.Enabled = True
                BtnXoaMAY.Enabled = True
                BtnInMAY.Enabled = True

            End If
        Catch ex As Exception
        End Try
        FormartLuoi()
    End Sub

    Private Sub dtDenngay1_EditValueChanged(sender As Object, e As EventArgs) Handles dtDenngay1.EditValueChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        Try
            grdDSHieuChuanMay.DataSource = Nothing
            grvDSHieuChuanMay.Columns.Clear()
        Catch ex As Exception
        End Try
        Commons.Modules.SQLString = "0Load"
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanMay, grvDSHieuChuanMay, New clsHIEU_CHUAN_MAYController().GetHIEU_CHUAN_MAY_Theo_NGAY_HC(dtTungay1.DateTime.ToShortDateString(), dtDenngay1.DateTime.ToShortDateString()), False, True, True, True, True, "")
        Try

            Commons.Modules.SQLString = ""
            Showhieuchuanmay(grvDSHieuChuanMay.FocusedRowHandle)
            intRow = grvDSHieuChuanMay.FocusedRowHandle

            If (grvDSHieuChuanMay.RowCount = 0) Then
                BtnSuaMAY.Enabled = False
                BtnXoaMAY.Enabled = False
                BtnInMAY.Enabled = False
            Else
                BtnSuaMAY.Enabled = True
                BtnXoaMAY.Enabled = True
                BtnInMAY.Enabled = True

            End If

        Catch ex As Exception
        End Try
        BtnThemMAY.Focus()
        FormartLuoi()
    End Sub

    Private Sub dtNgay_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles dtNgay.CloseUp
        Try
            If (dtNgay.EditValue = e.Value) Then
                Exit Sub
            End If
            txtNgayHCMAY.Text = e.Value
            txtNgayHCMAY.Focus()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboNamDHD1_EditValueChanged(sender As Object, e As EventArgs) Handles cboNamDHD1.EditValueChanged
        Try
            If (Commons.Modules.SQLString = "0Load") Then Exit Sub

            Try
                grdDSHieuChuanDHD.DataSource = Nothing
                grvDSHieuChuanDHD.Columns.Clear()
            Catch ex As Exception
            End Try
            Commons.Modules.SQLString = "0Load"
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSHieuChuanDHD, grvDSHieuChuanDHD, New clsHIEU_CHUAN_DHDController().GetHIEU_CHUAN_DHD_LOC(cboNamDHD1.EditValue, cboThietbitheoDHD1.EditValue, IIf(cboDongHo1.EditValue Is Nothing, "-1", cboDongHo1.EditValue), Commons.Modules.UserName), False, True, True, True, True, "")
            Commons.Modules.SQLString = ""
            Try
                grvDSHieuChuanDHD.Columns("MS_MAY").Width = 95
                grvDSHieuChuanDHD.Columns("TEN_MAY").Width = 100
                grvDSHieuChuanDHD.Columns("MS_PT").Width = 100
                grvDSHieuChuanDHD.Columns("MS_VI_TRI").Width = 100
                grvDSHieuChuanDHD.Columns("TEN_PT").Width = 150
                grvDSHieuChuanDHD.Columns("DANH_GIA").Width = 120
                grvDSHieuChuanDHD.Columns("GIAY_CHUNG_NHAN").Width = 150
                grvDSHieuChuanDHD.Columns("CO_QUAN_HIEU_CHUAN").Width = 154
                grvDSHieuChuanDHD.Columns("NGAY_KH").Width = 95
                grvDSHieuChuanDHD.Columns("NGAY").Width = 95
                grvDSHieuChuanDHD.Columns("NGAYHCKE").Width = 95
                grvDSHieuChuanDHD.Columns("GHI_CHU").Visible = False
                grvDSHieuChuanDHD.Columns("DUONG_DAN").Visible = False
                grvDSHieuChuanDHD.Columns("NOI").Visible = False

                grvDSHieuChuanDHD.Columns("TEN_LOAI_HIEU_CHUAN").Width = 150
                grvDSHieuChuanDHD.Columns("DD_GOC").Visible = False
                grvDSHieuChuanDHD.Columns("MS_LOAI_HIEU_CHUAN").Visible = False

            Catch ex As Exception
            End Try

            ShowhieuchuanDHD(0)

            If grvDSHieuChuanDHD.RowCount > 0 Then
                BtnSuaDHD.Enabled = True
                BtnXoaDHD.Enabled = True
                BtnInDHD.Enabled = True
            Else
                BtnSuaDHD.Enabled = False
                BtnXoaDHD.Enabled = False
                BtnInDHD.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboThietbitheoDHD1_EditValueChanged(sender As Object, e As EventArgs) Handles cboThietbitheoDHD1.EditValueChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        LoadDHD_filter()
        LoadDataThietBiTheoDHD()
    End Sub

    Private Sub cboDongHo1_EditValueChanged(sender As Object, e As EventArgs) Handles cboDongHo1.EditValueChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        LoadDataThietBiTheoDHD()
        ShowhieuchuanDHD(grvDSHieuChuanDHD.FocusedRowHandle)
    End Sub

    Private Sub grvDSHieuChuanDHD_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDSHieuChuanDHD.FocusedRowChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        ShowhieuchuanDHD(e.FocusedRowHandle)
        intRow1 = e.FocusedRowHandle
    End Sub

    Private Sub grvDSHieuChuanDHD_ColumnFilterChanged(sender As Object, e As EventArgs) Handles grvDSHieuChuanDHD.ColumnFilterChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub

        ShowhieuchuanDHD(grvDSHieuChuanDHD.FocusedRowHandle)
        intRow1 = grvDSHieuChuanDHD.FocusedRowHandle
    End Sub

    Private Sub cboLoaiHieuChuan_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaiHieuChuan.EditValueChanged
        Try
            If (BTnGhiMAY.Visible = False) Then Exit Sub
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_HC_MAX", txtThietBi.Text, Nothing, Nothing, cboLoaiHieuChuan.EditValue, False))
            If (dt.Rows.Count > 0) Then
                Try
                    Dim ngayHCCuoi As Date = Convert.ToDateTime(dt.Rows(0)("NGAY_HC_CUOI").ToString, New CultureInfo("vi-vn"))
                    Dim donVi As String = If(String.IsNullOrEmpty(dt.Rows(0)("DON_VI").ToString), 3, dt.Rows(0)("DON_VI").ToString)
                    Dim chuKy As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(dt.Rows(0)("CHU_KY").ToString), 0, dt.Rows(0)("CHU_KY").ToString))

                    ngayHCCuoi = If(donVi = "1", ngayHCCuoi.AddDays(chuKy), If(donVi = "2", ngayHCCuoi.AddDays(chuKy * 7), If(donVi = "3", ngayHCCuoi.AddMonths(chuKy), ngayHCCuoi.AddYears(chuKy))))
                    txtNgayKHMAY.Text = ngayHCCuoi
                Catch
                    txtNgayKHMAY.Text = Date.Now
                End Try
                Exit Sub
            End If

            txtNgayKHMAY.Text = Date.Now
        Catch ex As Exception
            txtNgayKHMAY.Text = Date.Now
        End Try
    End Sub

    Private Sub cboLoaiHCHDH_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaiHCHDH.EditValueChanged
        Try
            If (BtnGhiDHD.Visible = False) Then Exit Sub
            If (bThem = 2) Then Exit Sub

            Dim dtReader As SqlDataReader
            Commons.Modules.SQLString = "SELECT TOP 1 MAC_DINH FROM LOAI_HIEU_CHUAN WHERE MS_LOAI_HIEU_CHUAN = " & cboLoaiHCHDH.EditValue
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                chkNoi.Checked = dtReader.Item(0)
            End While
            dtReader.Close()

            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_HC_MAX", txtThietbi_DHD.Text, cboDHDo.EditValue, cboViTriDHD.EditValue, cboLoaiHCHDH.EditValue, True))
            If (dt.Rows.Count > 0) Then
                Try
                    Dim ngayHCCuoi As Date = Convert.ToDateTime(dt.Rows(0)("NGAY_HC_CUOI").ToString, New CultureInfo("vi-vn"))
                    Dim donVi As String = If(String.IsNullOrEmpty(dt.Rows(0)("DON_VI").ToString), 3, dt.Rows(0)("DON_VI").ToString)
                    Dim chuKy As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(dt.Rows(0)("CHU_KY").ToString), 0, dt.Rows(0)("CHU_KY").ToString))

                    ngayHCCuoi = If(donVi = "1", ngayHCCuoi.AddDays(chuKy), If(donVi = "2", ngayHCCuoi.AddDays(chuKy * 7), If(donVi = "3", ngayHCCuoi.AddMonths(chuKy), ngayHCCuoi.AddYears(chuKy))))
                    txtNgayKH.Text = ngayHCCuoi
                Catch
                    txtNgayKH.Text = Date.Now
                End Try
                Exit Sub
            End If
            txtNgayKH.Text = Date.Now
        Catch
            txtNgayKH.Text = Date.Now
        End Try
    End Sub

    Private Sub cboDHDoo_EditValueChanged(sender As Object, e As EventArgs) Handles cboDHDo.EditValueChanged

        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        cboViTriDHD.Text = ""
        Loadvitri()
    End Sub

    Private Sub cboViTriDHD_EditValueChanged(sender As Object, e As EventArgs) Handles cboViTriDHD.EditValueChanged
        Try
            If (BtnGhiDHD.Visible = False) Then Exit Sub

            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_HC_MAX", txtThietbi_DHD.Text, cboDHDo.EditValue, cboViTriDHD.EditValue, cboLoaiHCHDH.EditValue, True))
            If (dt.Rows.Count > 0) Then
                Try
                    Dim ngayHCCuoi As Date = Convert.ToDateTime(dt.Rows(0)("NGAY_HC_CUOI").ToString, New CultureInfo("vi-vn"))
                    Dim donVi As String = If(String.IsNullOrEmpty(dt.Rows(0)("DON_VI").ToString), 3, dt.Rows(0)("DON_VI").ToString)
                    Dim chuKy As Integer = Convert.ToInt32(If(String.IsNullOrEmpty(dt.Rows(0)("CHU_KY").ToString), 0, dt.Rows(0)("CHU_KY").ToString))

                    ngayHCCuoi = If(donVi = "1", ngayHCCuoi.AddDays(chuKy), If(donVi = "2", ngayHCCuoi.AddDays(chuKy * 7), If(donVi = "3", ngayHCCuoi.AddMonths(chuKy), ngayHCCuoi.AddYears(chuKy))))
                    txtNgayKH.Text = ngayHCCuoi
                Catch
                    txtNgayKH.Text = Date.Now
                End Try
                Exit Sub
            End If
            txtNgayKH.Text = Date.Now
        Catch
        End Try

    End Sub

    Private Sub dtNgayDHD_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles dtNgayDHD.CloseUp
        Try
            If (dtNgayDHD.EditValue = e.Value) Then
                Exit Sub
            End If
            txtNgayHCDHD.Text = e.Value
            txtNgayHCDHD.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grvDSHieuChuanMay_ShowGridMenu(sender As Object, e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs) Handles grvDSHieuChuanMay.ShowGridMenu
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then Exit Sub
        Try
            Dim headerMenu As DevExpress.XtraGrid.Menu.GridViewMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewMenu)
            'menu resetgrid
            Dim menuItem As New DevExpress.Utils.Menu.DXMenuItem("Reset Grid", New EventHandler(AddressOf MyMenuItem))
            menuItem.BeginGroup = True
            menuItem.Tag = e.Menu
            headerMenu.Items.Add(menuItem)
            'menu resetgrid
            Dim menuSave As New DevExpress.Utils.Menu.DXMenuItem("Save Grid", New EventHandler(AddressOf MyMenuItemSave))
            menuSave.BeginGroup = True
            menuSave.Tag = e.Menu
            headerMenu.Items.Add(menuSave)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MyMenuItemSave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grdDSHieuChuanMay.MainView.SaveLayoutToRegistry(regHCM)
    End Sub
    Private Sub MyMenuItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To grvDSHieuChuanMay.Columns.Count - 1
            Try
                grvDSHieuChuanMay.Columns(i).Visible = True
            Catch ex As Exception
            End Try
        Next
        Try
            grvDSHieuChuanMay.Columns("MS_LOAI_HIEU_CHUAN").Visible = False
            grvDSHieuChuanMay.Columns("STT").Width = 50
            grvDSHieuChuanMay.Columns("MS_MAY").Width = 95
            grvDSHieuChuanMay.Columns("TEN_MAY").Width = 100
            grvDSHieuChuanMay.Columns("CHU_KY").Width = 80
            grvDSHieuChuanMay.Columns("NGAY_HC").Width = 100
            grvDSHieuChuanMay.Columns("NGAY_KH").Width = 100
            grvDSHieuChuanMay.Columns("NGAY_KT").Width = 100
            grvDSHieuChuanMay.Columns("GIAY_CHUNG_NHAN").Width = 120
            grvDSHieuChuanMay.Columns("CO_QUAN_HIEU_CHUAN").Width = 120
            grvDSHieuChuanMay.Columns("DANH_GIA").Width = 100
            grvDSHieuChuanMay.Columns("TEN_LOAI_HIEU_CHUAN").Width = 120
            grvDSHieuChuanMay.Columns("GHI_CHU").Width = 100
            grvDSHieuChuanMay.Columns("TAI_LIEU").Visible = False
            grvDSHieuChuanMay.Columns("STT").VisibleIndex = 0
            grvDSHieuChuanMay.Columns("MS_MAY").VisibleIndex = 1
            grvDSHieuChuanMay.Columns("TEN_MAY").VisibleIndex = 2
            grvDSHieuChuanMay.Columns("TEN_LOAI_HIEU_CHUAN").VisibleIndex = 3
            grvDSHieuChuanMay.Columns("NGAY_KH").VisibleIndex = 4
            grvDSHieuChuanMay.Columns("NGAY_HC").VisibleIndex = 5
            grvDSHieuChuanMay.Columns("NGAY_KT").VisibleIndex = 6
            grvDSHieuChuanMay.Columns("CHU_KY").VisibleIndex = 7
            grvDSHieuChuanMay.Columns("GIAY_CHUNG_NHAN").VisibleIndex = 8
            grvDSHieuChuanMay.Columns("CO_QUAN_HIEU_CHUAN").VisibleIndex = 9
            grvDSHieuChuanMay.Columns("DANH_GIA").VisibleIndex = 10
            grvDSHieuChuanMay.Columns("GHI_CHU").VisibleIndex = 11
        Catch ex As Exception
            Try
                Dim rkSubKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("DevExpress\XtraGrid\Layouts", True)
                rkSubKey.DeleteSubKeyTree("GridHCM")
                optNTHT_SelectedIndexChanged(Nothing, Nothing)
                Exit Sub
            Catch exx As Exception
            End Try
        End Try
        Dim opts As New DevExpress.Utils.OptionsLayoutGrid()
        opts.Columns.StoreAllOptions = True
        grdDSHieuChuanMay.MainView.SaveLayoutToRegistry(regHCM)
    End Sub

    Private Sub txtNgayKHMAY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNgayKHMAY.Validating
        If BtnKhongghiMAY.Visible = False Then Exit Sub


        If BtnKhongghiMAY.Focused() Then
            Exit Sub
        End If
        If txtNgayKHMAY.Text <> "" And txtNgayKHMAY.Text <> "__/__/____" Then
            If Not IsDate(txtNgayKHMAY.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKH", Commons.Modules.TypeLanguage),
                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayKHMAY.Text = ""
                e.Cancel = True
                Exit Sub
            ElseIf Date.Parse(txtNgayKHMAY.Text) < Date.Parse("01/01/1900") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKH", Commons.Modules.TypeLanguage),
                                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayKHMAY.Text = ""
                e.Cancel = True
                Exit Sub
            ElseIf Date.Parse(txtNgayKHMAY.Text).Date > Date.Parse(Now.Date).Date Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKHLon", Commons.Modules.TypeLanguage),
                                                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayKHMAY.Text = ""
                e.Cancel = True
                Exit Sub
            End If
        Else
            txtNgayKHMAY.Text = Now.Date
            e.Cancel = True
            Exit Sub
        End If
    End Sub
End Class