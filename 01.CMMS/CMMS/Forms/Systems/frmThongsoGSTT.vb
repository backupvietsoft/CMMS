
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Linq
Imports DevExpress.XtraEditors

Public Class frmThongsoGSTT

    'Member Class

    ' Khai báo biến 
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private MS_KH_TMP As String = ""
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader
    Private flag As Boolean = True
    Private flag1 As Boolean = True
    Private flagGhi As Boolean = False
    Private row As Integer
    Private MS_TS_GSTT_TM_s As String
    Private MS_BP As Integer
    Dim TBGiaTri As New DataTable()
    Private strDuongDan As String = ""
    Private strPath_DH As String = ""

#Region "Control Event"

    Private Sub frmThongsoGSTT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TableLayoutPanel1.ColumnStyles(0).Width = 0
        TableLayoutPanel1.ColumnStyles(TableLayoutPanel1.ColumnCount - 1).Width = 0

        Commons.Modules.SQLString = "0Load"
        If Commons.Modules.PermisString.Equals("Read only") Then
            Load_cboDonvido()
            LoadMS_BP_GSTT()
            LoadLocMS_BP_GSTT()
            Refesh()
            BindData()
            BindData1()
            ' RefeshLanguage()
            VisibleButton(True)
            VisibleButton2(False)
            VisibleButton1(False)
            LockData(True)
            EnableButton(False)
        Else
            EnableButton(True)
            Load_cboDonvido()
            LoadMS_BP_GSTT()
            LoadLocMS_BP_GSTT()
            Refesh()
            BindData()
            BindData1()
            'RefeshLanguage()
            VisibleButton(True)
            VisibleButton2(False)
            VisibleButton1(False)
            LockData(True)
        End If
        If (LOAI_TS = True) Then
            optThongSo.SelectedIndex = 1
        End If
        Commons.Modules.SQLString = ""
        grvThongSo_FocusedRowChanged(Nothing, Nothing)
        findThongSo()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Public MS_GS_TT As String = "-1"
    Public LOAI_TS As Boolean = False
    Public Sub findThongSo()
        Try
            If Not MS_GS_TT.Equals("-1") Then
                optThongSo.SelectedIndex = 0
                For i As Integer = 0 To grvThongSo.RowCount - 1
                    If (grvThongSo.GetDataRow(i)("MS_TS_GSTT").ToString = MS_GS_TT) Then
                        grvThongSo.FocusedRowHandle = i
                        ShowThongSo()
                        BindData1()
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        btnCV.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub



    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        If optThongSo.SelectedIndex = 0 Then
            optThongSo.SelectedIndex = 1
        End If
        VisibleButton(False)
        VisibleButton2(True)
        LockData(False)
        blnThem = True
        flagGhi = True
        If optThongSo.SelectedIndex = 0 Then
            ShowGiatri(TxtMaso.Text)
            If chkDinhtinh.Checked = True Then
                chkDinhtinh_CheckedChanged(Nothing, Nothing)
            Else
                chkDinhtinh.Checked = True

            End If
        Else
            If chkDinhtinh.Checked = False Then
                chkDinhtinh_CheckedChanged(Nothing, Nothing)
            Else
                chkDinhtinh.Checked = False

            End If
        End If
        Refesh()
        Dim obj As New Commons.OSystems
        TxtMaso.Text = obj.GetIDInteger("GS")
        TxtTenthongso.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        If optThongSo.SelectedIndex = 0 Then
            Dim msts As String = grvThongSo.GetFocusedRowCellValue("MS_TS_GSTT").ToString()
            If Convert.ToBoolean(grvThongSo.GetFocusedRowCellValue("LOAI_TS")) = True Then
                optThongSo.SelectedIndex = 1
            Else
                optThongSo.SelectedIndex = 2
            End If
            For i As Integer = 0 To grvThongSo.RowCount - 1
                If grvThongSo.GetDataRow(i)("MS_TS_GSTT") = msts Then
                    grvThongSo.FocusedRowHandle = i
                    Exit For
                End If
            Next
        End If
        VisibleButton(False)
        VisibleButton2(True)
        LockData(False)
        TxtMaso.Properties.ReadOnly = True
        flagGhi = True
        strPath_DH = txtDuongDan.Text

        chkDinhtinh.Enabled = False
        chkDinhtinh_CheckedChanged(Nothing, Nothing)
        TxtTenthongso.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If optThongSo.SelectedIndex = 0 Then
            XtraMessageBox.Show("Vui lòng chọn định tính hay định lượng")
            Exit Sub
        End If


        'XÓA GIÁ TRỊ TS_GSTT
        'kiểm tra trong table GIA_TRI_GSTT

        SQL_TMP = "SELECT * FROM GIAM_SAT_TINH_TRANG_TS_DT WHERE MS_TS_GSTT = '" & TxtMaso.Text & "' AND STT_GT IN  (SELECT STT FROM GIA_TRI_TS_GSTT WHERE MS_TS_GSTT='" & TxtMaso.Text & "' ) "
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoagiatri21", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        'If grvGiaTriTS.RowCount <= 1 Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoagiatri1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        '    Exit Sub
        'End If
        If grvGiaTriTS.RowCount > 1 Then
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoagiatri2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim clsGia_tri_TS_GSTTController As New GIA_TRI_TS_GSTTController()
                clsGia_tri_TS_GSTTController.InsertGIA_TRI_TS_GSTT_LOG(CInt(grvGiaTriTS.GetFocusedDataRow()("STT")), TxtMaso.Text, Me.Name, Commons.Modules.UserName, 3)
                clsGia_tri_TS_GSTTController.DeleteGIA_TRI_TS_GSTT(TxtMaso.Text, grvGiaTriTS.GetFocusedDataRow()("STT"))

                Dim tmp As Integer = row
                BindData1()
                'If grvGiaTriTS.RowCount > 0 Then
                '    If grvGiaTriTS.RowCount = tmp Then
                '        grvGiaTriTS.CurrentCell() = grvGiaTriTS.Rows(tmp - 1).Cells("TEN_GIA_TRI")
                '        grvGiaTriTS.Focus()
                '    Else
                '        grvGiaTriTS.CurrentCell() = grvGiaTriTS.Rows(tmp).Cells("TEN_GIA_TRI")
                '        grvGiaTriTS.Focus()
                '    End If
                'End If

            End If
            Exit Sub
        End If
        'XÓA THÔNG SỐ
        If grvThongSo.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        If grvGiaTriTS.RowCount <= 1 Then
            Dim Traloi1 As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi1 = vbYes Then
                ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng CAU_TRUC_THIET_BI_TS_GSTT không.

                SQL_TMP = "SELECT * FROM CAU_TRUC_THIET_BI_TS_GSTT WHERE CONVERT(NUMERIC,MS_TS_GSTT) = '" & TxtMaso.Text.Replace("'", "''") & "'"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
                While dtReader.Read
                    ' Thông số này đang được sử dụng trong thông số giám sát của cấu trúc thiết bị, bạn không thể xóa!
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    dtReader.Close()
                    Exit Sub
                End While
                dtReader.Close()
                ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng MAY_THONG_SO_GSTT không.

                SQL_TMP = "SELECT * FROM CAU_TRUC_THIET_BI_TS_GSTT WHERE CONVERT(NUMERIC,MS_TS_GSTT) = '" & TxtMaso.Text.Replace("'", "''") & "'"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
                While dtReader.Read
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    dtReader.Close()
                    Exit Sub
                End While
                dtReader.Close()
                Dim clsGia_tri_TS_GSTTController As New GIA_TRI_TS_GSTTController()

                If grvGiaTriTS.RowCount > 0 Then
                    clsGia_tri_TS_GSTTController.DeleteGIA_TRI_TS_GSTT(TxtMaso.Text, grvGiaTriTS.GetFocusedDataRow()("STT"))

                End If
                Dim tmp As Integer = row
                BindData1()
                'If grvGiaTriTS.RowCount > 0 Then
                '    If grvGiaTriTS.RowCount = tmp Then
                '        grvGiaTriTS.CurrentCell() = grvGiaTriTS.Rows(tmp - 1).Cells("TEN_GIA_TRI")
                '        grvGiaTriTS.Focus()
                '    Else
                '        grvGiaTriTS.CurrentCell() = grvGiaTriTS.Rows(tmp).Cells("TEN_GIA_TRI")
                '        grvGiaTriTS.Focus()
                '    End If
                'End If


                ' Xóa khách hàng

                Dim objThongSoTBController As New THONG_SO_GSTTController()

                If chkDinhtinh.Checked Then

                    clsGia_tri_TS_GSTTController.DeleteGIA_TRI_TS_GSTT1(TxtMaso.Text)
                End If
                objThongSoTBController.InsertTHONG_SO_GSTT_LOG(CInt(TxtMaso.Text), Me.Name, Commons.Modules.UserName, 3)
                objThongSoTBController.DeleteTHONG_SO_GSTT(TxtMaso.Text)
                ' refresh dữ liệu cho cbo_thongso của Form Giá trĩ TS_GSTT
                'frmGiatrithongsoGSTT.Load_cboThongSo()

                Refesh()
                tmp = intRow
                BindData()
                'If grdDanhmucthongso.Rows.Count > 0 Then
                '    If grdDanhmucthongso.Rows.Count = tmp Then
                '        grdDanhmucthongso.CurrentCell() = grdDanhmucthongso.Rows(tmp - 1).Cells("TEN_TS_GSTT")
                '        grdDanhmucthongso.Focus()
                '        BindData1()
                '    Else
                '        grdDanhmucthongso.CurrentCell() = grdDanhmucthongso.Rows(tmp).Cells("TEN_TS_GSTT")
                '        grdDanhmucthongso.Focus()
                '    End If
                'End If
                VisibleButton1(False)
                VisibleButton(True)
            Else
                Exit Sub
            End If

        End If


        If grvGiaTriTS.RowCount >= 0 Then
            BtnXoagiatri.Enabled = True
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Try
            SQL_TMP = "SELECT * FROM THONG_SO_GSTT WHERE CONVERT(NUMERIC,MS_TS_GSTT) = CONVERT(NUMERIC,'" & TxtMaso.Text.Replace("'", "''") & "')"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            'Dim MS_TS_GSTT_TM_s As String = TxtMaso.Text
            Try
                MS_TS_GSTT_TM_s = Integer.Parse(TxtMaso.Text.Trim).ToString
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMSisNumber", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End Try
            If TxtTenthongso.Text.Trim.Length <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenthongso", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                TxtTenthongso.Focus()
                Exit Sub
            End If
            If cboBoPhanGSTT.EditValue < 0 And chkDinhtinh.Checked = True Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonbophan", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            If Not chkDinhtinh.Checked And cboBoPhanGSTT.EditValue < 0 Then
                ' Đơn vị đo không được rỗng ! Vui lòng chọn đơn vị đo !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonbophan", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            If cboDVD.EditValue < 0 And chkDinhtinh.Checked = False Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi2", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            If blnThem Then
                While dtReader.Read
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    TxtMaso.Focus()
                    TxtMaso.Text = ""
                    Exit Sub
                End While
            Else
                If TxtMaso.Text = MS_KH_TMP Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    TxtMaso.Focus()
                    TxtMaso.Text = ""
                    Exit Sub
                End If
            End If

            If Not chkDinhtinh.Checked And cboDVD.EditValue = -1 Then
                ' Đơn vị đo không được rỗng ! Vui lòng chọn đơn vị đo !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi2", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            If AddThongSoGSTT() Then
                ' refresh dữ liệu cho cbo_thongso của Form Giá trĩ TS_GSTT
                'frmGiatrithongsoGSTT.Load_cboThongSo()
                If cboLoaiCV.Text = "" Then
                    SQL_TMP = "UPDATE THONG_SO_GSTT SET MS_LOAI_CV = NULL WHERE MS_TS_GSTT = '" & TxtMaso.Text & "' "
                Else
                    SQL_TMP = "UPDATE THONG_SO_GSTT SET MS_LOAI_CV = " & cboLoaiCV.EditValue & " WHERE MS_TS_GSTT = '" & TxtMaso.Text & "' "
                End If
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE THONG_SO_GSTT SET MS_LOAI_CV = NULL WHERE MS_LOAI_CV = ''")

                grvGiaTriTS.OptionsBehavior.Editable = False
                grvGiaTriTS.OptionsBehavior.AllowAddRows = False
                grvGiaTriTS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                If chkDinhtinh.Checked Then
                    LoadLocMS_BP_GSTT()
                End If

                blnThem = False
                VisibleButton(True)
                VisibleButton2(False)
                LockData(True)
                flagGhi = False
                Commons.Modules.SQLString = "0Load"
                optThongSo.SelectedIndex = If(chkDinhtinh.Checked = True, 1, 2)
                Commons.Modules.SQLString = ""
                optThongSo_SelectedIndexChanged(Nothing, Nothing)
                For i As Integer = 0 To grvThongSo.RowCount - 1
                    If grvThongSo.GetDataRow(i)("MS_TS_GSTT") = MS_TS_GSTT_TM_s Then
                        grvThongSo.FocusedRowHandle = i
                        ShowGiatri(MS_TS_GSTT_TM_s)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Try
            MS_TS_GSTT_TM_s = TxtMaso.Text
            Refesh()

            Try
                If grvThongSo.RowCount <> 0 Then
                    ShowThongSo()
                End If
            Catch ex As Exception
                ShowThongSo()
            End Try

            blnThem = False
            flagGhi = False

            grvGiaTriTS.OptionsBehavior.Editable = False
            grvGiaTriTS.OptionsBehavior.AllowAddRows = False
            grvGiaTriTS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            VisibleButton(True)
            VisibleButton2(False)
            LockData(True)

            If Trim$(MS_TS_GSTT_TM_s) <> "" Then
                For i As Integer = 0 To grvThongSo.RowCount - 1
                    If grvThongSo.GetDataRow(i)("MS_TS_GSTT") = MS_TS_GSTT_TM_s Then
                        grvThongSo.FocusedRowHandle = i
                        ShowGiatri(MS_TS_GSTT_TM_s)
                        Exit For
                    End If
                Next
            End If
            BindData1()
            lblDonvido.Enabled = False
            cboDVD.Enabled = False
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub grdDanhmucthongso_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        'ShowThongSo(e.RowIndex)
        'BindData1()
        ''rowcount = grvGiaTriTS.RowCount
        'intRow = e.RowIndex
    End Sub
    Dim intRow As Integer
    Private Sub grdNhaXuong_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'ShowThongSo(e.RowIndex)
        'BindData1()
        'rowcount = grvGiaTriTS.RowCount
        'intRow = e.RowIndex
        'RefeshLanguage()
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        TxtMaso.Text = ""
        TxtTenthongso.Text = ""
        txtGhiChu.Text = ""
        cboBoPhanGSTT.EditValue = -1
        cboLoaiCV.EditValue = -1
        txtCachThucHien.Text = ""
        txtTCKT.Text = ""
        txtYCNS.Text = ""
        txtYCDC.Text = ""
        txtThoiGian.Text = 0
        txtDuongDan.Text = ""
        TBGiaTri.Rows.Clear()
    End Sub
    Sub ShowThongSo()
        Try


            txtCachThucHien.Text = grvThongSo.GetFocusedDataRow()("CACH_THUC_HIEN").ToString

            txtTCKT.Text = grvThongSo.GetFocusedDataRow()("TIEU_CHUAN_KT").ToString
            txtYCNS.Text = grvThongSo.GetFocusedDataRow()("YEU_CAU_NS").ToString
            txtYCDC.Text = grvThongSo.GetFocusedDataRow()("YEU_CAU_DUNG_CU").ToString

            txtThoiGian.Text = grvThongSo.GetFocusedDataRow()("THOI_GIAN").ToString
            TxtMaso.Text = grvThongSo.GetFocusedDataRow()("MS_TS_GSTT").ToString
            TxtTenthongso.Text = grvThongSo.GetFocusedDataRow()("TEN_TS_GSTT").ToString
            txtGhiChu.Text = grvThongSo.GetFocusedDataRow()("GHI_CHU").ToString
            txtDuongDan.Text = grvThongSo.GetFocusedDataRow()("DUONG_DAN").ToString
            chkDinhtinh.Checked = grvThongSo.GetFocusedDataRow()("LOAI_TS")
            cboBoPhanGSTT.EditValue = grvThongSo.GetFocusedDataRow()("MS_BP_GSTT")
            cboLoaiCV.EditValue = grvThongSo.GetFocusedDataRow()("MS_LOAI_CV")

            If chkDinhtinh.Checked Then
                cboDVD.EditValue = Nothing
            Else
                cboDVD.EditValue = grvThongSo.GetFocusedDataRow()("MS_DV_DO")
            End If
            grdGiaTriTS.DataSource = Nothing
        Catch ex As Exception
            Refesh()
        End Try

    End Sub
    Sub ShowGiatri(ByVal MS_ST_GSTT As String)
        TBGiaTri = New GIA_TRI_TS_GSTTController().GetGIA_TRI_TS_GSTT1(MS_ST_GSTT)
        TBGiaTri.Columns("DAT").ReadOnly = False
        Me.grdGiaTriTS.DataSource = TBGiaTri
        grvGiaTriTS.Columns("MS_TS_GSTT").Visible = False
        grvGiaTriTS.Columns("MS_TS_GSTT").Visible = False
        grvGiaTriTS.Columns("STT").Visible = False
        grvGiaTriTS.Columns("TEN_GIA_TRI").Width = 200
        grvGiaTriTS.Columns("DAT").Width = 80
    End Sub
    Sub Load_cboDonvido()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_DOs"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDVD, dt, "MS_DV_DO", "TEN_DV_DO", Name)
    End Sub

    Sub LoadMS_BP_GSTT()

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_GSTT_NGON_NGUs", Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBoPhanGSTT, dt, "MS_BP_GSTT", "TEN_BP_GSTT", Name)

        dt = New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC_PQ", Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCV, dt, "MS_LOAI_CV", "TEN_LOAI_CV", Name)
    End Sub
    Sub LoadLocMS_BP_GSTT()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_SO_GSTT_MS_BP_GSTT_NGON_NGUs", Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBoPhan, dt, "MS_BP_GSTT", "TEN_BP_GSTT", Name)
    End Sub

    Dim dtTmp As New DataTable
    Sub BindData()
        Try
            Dim iLoai As Int16 = -1
            If optThongSo.SelectedIndex = 0 Then iLoai = -1
            If optThongSo.SelectedIndex = 1 Then iLoai = 1
            If optThongSo.SelectedIndex = 2 Then iLoai = 0

            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetThongSoGiamSatTinhTrang", Commons.Modules.UserName,
                                               Commons.Modules.TypeLanguage, cboBoPhan.EditValue, iLoai))
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongSo, grvThongSo, dtTmp, False, False, False, True)
            Me.grvThongSo.Columns("MS_TS_GSTT").Visible = False
            Me.grvThongSo.Columns("TEN_TS_GSTT").Width = 350
            Me.grvThongSo.Columns("DUONG_DAN").Width = 275
            Me.grvThongSo.Columns("MS_DV_DO").Visible = False
            Me.grvThongSo.Columns("MS_LOAI_CV").Visible = False
            Me.grvThongSo.Columns("GHI_CHU").Visible = False
            Me.grvThongSo.Columns("MS_BP_GSTT").Visible = False
            Me.grvThongSo.Columns("TEN_BP_GSTT").Visible = False
            Me.grvThongSo.Columns("TEN_DV_DO").Visible = False
            'Me.grvThongSo.Columns("LOAI_TS").Visible = False
            Me.grvThongSo.Columns("CACH_THUC_HIEN").Visible = False
            Me.grvThongSo.Columns("THOI_GIAN").Visible = False

            Me.grvThongSo.Columns("TIEU_CHUAN_KT").Visible = False
            Me.grvThongSo.Columns("YEU_CAU_NS").Visible = False
            Me.grvThongSo.Columns("YEU_CAU_DUNG_CU").Visible = False


            If Me.grvThongSo.RowCount > 0 Then
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
                BtnXoathongso.Enabled = True
            Else
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
                BtnXoathongso.Enabled = False
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
        Catch ex As Exception

        End Try
        grvThongSo_FocusedRowChanged(Nothing, Nothing)
    End Sub
    Sub BindData1()

        TBGiaTri = New GIA_TRI_TS_GSTTController().GetGIA_TRI_TS_GSTT1(TxtMaso.Text.Trim())
        TBGiaTri.Columns("DAT").ReadOnly = False
        Me.grdGiaTriTS.DataSource = TBGiaTri
        grvGiaTriTS.OptionsBehavior.Editable = False
        Try
            grvGiaTriTS.Columns("MS_TS_GSTT").Visible = False
            grvGiaTriTS.Columns("STT").Visible = False
            grvGiaTriTS.Columns("TEN_GIA_TRI").Width = 200
            grvGiaTriTS.Columns("DAT").Width = 80
        Catch ex As Exception
        End Try

        If Me.grvGiaTriTS.RowCount > 0 Then
            Me.BtnXoagiatri.Enabled = True
        Else
            Me.BtnXoagiatri.Enabled = False
        End If
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If

    End Sub

    Function AddThongSoGSTT() As Boolean
        Try
            Dim dt As New DataTable

            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM THONG_SO_GSTT WHERE TEN_TS_GSTT = N'" & TxtTenthongso.Text.Trim() & "' AND MS_BP_GSTT = N'" & cboBoPhanGSTT.EditValue & "' AND MS_TS_GSTT <> " & TxtMaso.Text))
            If dt.Rows.Count > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLikeName", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Return False
            End If

            Dim objThongSoController As New THONG_SO_GSTTController()
            Dim objThongSoInfo As New THONG_SO_GSTTInfo
            objThongSoInfo.MS_TS_GSTT = Integer.Parse(TxtMaso.Text).ToString
            objThongSoInfo.DUONG_DAN = txtDuongDan.Text
            objThongSoInfo.TEN_TS_GSTT = TxtTenthongso.Text
            If Not chkDinhtinh.Checked Then
                objThongSoInfo.MS_DV_DO = cboDVD.EditValue.ToString
                objThongSoInfo.MS_BP_GSTT = cboBoPhanGSTT.EditValue.ToString
                objThongSoInfo.LOAI_TS = 0
            Else
                objThongSoInfo.MS_DV_DO = Nothing
                objThongSoInfo.MS_BP_GSTT = cboBoPhanGSTT.EditValue.ToString
                objThongSoInfo.LOAI_TS = 1
            End If
            objThongSoInfo.GHI_CHU = txtGhiChu.Text

            If Not blnThem Then
                If chkDinhtinh.Checked = True And objThongSoInfo.LOAI_TS = False Then
                    Dim clsGia_tri_TS_GSTTController As New GIA_TRI_TS_GSTTController()
                    clsGia_tri_TS_GSTTController.DeleteGIA_TRI_TS_GSTT1(TxtMaso.Text)
                End If
                Commons.Modules.ObjSystems.Xoahinh(strPath_DH)
                objThongSoController.InsertTHONG_SO_GSTT_LOG(CInt(TxtMaso.Text), Me.Name, Commons.Modules.UserName, 2)
                objThongSoController.UpdateTHONG_SO_GSTT(objThongSoInfo)
                Commons.Modules.ObjSystems.LuuDuongDan(strDuongDan, txtDuongDan.Text)
            Else
                objThongSoController.AddTHONG_SO_GSTT(objThongSoInfo)
                objThongSoController.InsertTHONG_SO_GSTT_LOG(CInt(objThongSoInfo.MS_TS_GSTT), Me.Name, Commons.Modules.UserName, 1)
                Commons.Modules.ObjSystems.LuuDuongDan(strDuongDan, txtDuongDan.Text)
            End If
            Dim tam As Integer = 0
            For i = 0 To grvGiaTriTS.RowCount - 2
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddUpdateGIA_TRI_TS_GSTT", Convert.ToInt32(TxtMaso.Text), grvGiaTriTS.GetDataRow(i)("TEN_GIA_TRI"), grvGiaTriTS.GetDataRow(i)("DAT"), grvGiaTriTS.GetDataRow(i)("GHI_CHU"), grvGiaTriTS.GetDataRow(i)("STT"))
                Catch ex As Exception
                End Try
            Next
            Dim sql As String
            Try
                sql = "UPDATE THONG_SO_GSTT SET CACH_THUC_HIEN = N'" & txtCachThucHien.Text & "', THOI_GIAN = " & txtThoiGian.Text & ",TIEU_CHUAN_KT = N'" & txtTCKT.Text & "', YEU_CAU_NS = N'" & txtYCNS.Text & "', YEU_CAU_DUNG_CU = N'" & txtYCDC.Text & "'  WHERE MS_TS_GSTT =N'" + TxtMaso.Text + "' "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                If Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu <> "" Then
                    sql = "UPDATE THONG_SO_GSTT SET TEN_TS_GSTT_ANH = N'" + Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu + "'WHERE MS_TS_GSTT =N'" + TxtMaso.Text + "'"
                End If
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            Catch ex As Exception

            End Try

            Return True
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        btnCV.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
    End Sub
    Sub VisibleButton2(ByVal blnVisible As Boolean)
        BtnGhi.Visible = blnVisible
        BtnKhongghi.Visible = blnVisible
    End Sub
    Sub VisibleButton1(ByVal blnVisible As Boolean)
        BtnTrove.Visible = blnVisible
        BtnXoathongso.Visible = blnVisible
        BtnXoagiatri.Visible = blnVisible
        BtnXoathongso.Enabled = False
        BtnXoagiatri.Enabled = True
    End Sub

    Sub LockData(ByVal blnLock As Boolean)
        TxtMaso.Properties.ReadOnly = blnLock
        TxtTenthongso.Properties.ReadOnly = blnLock

        'cboDVD.Enabled = Not blnLock
        chkDinhtinh.Enabled = Not blnLock
        'cboBoPhanGSTT.Enabled = Not blnLock
        cboBoPhanGSTT.Properties.ReadOnly = blnLock
        cboDVD.Properties.ReadOnly = blnLock

        txtCachThucHien.Properties.ReadOnly = blnLock
        txtTCKT.Properties.ReadOnly = blnLock
        txtYCNS.Properties.ReadOnly = blnLock
        txtYCDC.Properties.ReadOnly = blnLock
        txtGhiChu.Properties.ReadOnly = blnLock
        txtDuongDan.Properties.ReadOnly = blnLock
        txtThoiGian.Properties.ReadOnly = blnLock
        cboLoaiCV.Enabled = Not blnLock
        BtnTenBP.Enabled = Not blnLock
        cboBoPhan.Enabled = blnLock
        txtTimKiem.Properties.ReadOnly = Not blnLock
        optThongSo.Enabled = blnLock
        grdThongSo.Enabled = blnLock

    End Sub

    Private Sub btnDonvido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmDonvido As Report1.frmDonvido = New Report1.frmDonvido()
        frmDonvido.Show()
    End Sub
#End Region

    Private Sub BtnTrove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTrove.Click
        VisibleButton1(False)
        VisibleButton(True)
    End Sub

    Sub LayDuongDan()
        strPath_DH = txtDuongDan.Text
        strDuongDan = ofdHinh.FileName
        If strDuongDan = "" Then Exit Sub
        If TxtMaso.Text <> "" Then
            Dim strDuongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(True, "GSTT")
            txtDuongDan.Text = strDuongDanTmp & "\" & "GSTT_" & TxtMaso.Text & Commons.Modules.ObjSystems.LayDuoiFile(strDuongDan)
        End If
    End Sub

    Private Sub BtnTenBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTenBP.Click
        Dim msBP As String = cboBoPhanGSTT.EditValue
        frmBoPhanGSTT.ShowDialog()
        If (frmBoPhanGSTT.ckThayDoi = True) Then
            LoadMS_BP_GSTT()
        End If
        Try
            cboBoPhanGSTT.EditValue = Convert.ToInt32(msBP)
        Catch ex As Exception
            cboBoPhanGSTT.EditValue = msBP
        End Try
    End Sub

    Private Sub txtTimKiem_TextChanged(sender As Object, e As EventArgs) Handles txtTimKiem.TextChanged
        Dim sDK As String = ""
        Dim dtGSTT As New DataTable
        Try
            dtGSTT = CType(grdThongSo.DataSource, DataTable)
            sDK = "TEN_TS_GSTT Like '%" & txtTimKiem.Text & "%' "
            dtGSTT.DefaultView.RowFilter = sDK
        Catch ex As Exception
            dtGSTT.DefaultView.RowFilter = ""
        End Try
        grvThongSo_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub TxtTenthongso_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtTenthongso.ButtonClick
        Dim sLoi As String = ""
        If Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblfrmThongsoGSTT_Anh", Commons.Modules.TypeLanguage), "THONG_SO_GSTT", "TEN_TS_GSTT_ANH", " WHERE TEN_TS_GSTT = N'" + TxtTenthongso.Text + "'", sLoi, "frmThongsoGSTT") = False Then
            XtraMessageBox.Show(sLoi)
        End If
    End Sub

    Private Sub grvThongSo_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvThongSo.FocusedRowChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        ShowThongSo()
        BindData1()
        intRow = grvThongSo.FocusedRowHandle
    End Sub

    Private Sub optThongSo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optThongSo.SelectedIndexChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If optThongSo.SelectedIndex = 1 And BtnGhi.Visible = True Then
            cboDVD.Enabled = False
        ElseIf optThongSo.SelectedIndex = 2 And BtnGhi.Visible = True Then
            cboDVD.Enabled = True
        End If

        If optThongSo.SelectedIndex = 2 Then grdGiaTriTS.Enabled = False Else grdGiaTriTS.Enabled = True
        'grdGiaTriTS.Enabled = If(optThongSo.SelectedIndex = 1, True, False)


        BindData()
    End Sub

    Private Sub cboBoPhan_EditValueChanged(sender As Object, e As EventArgs) Handles cboBoPhan.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        BindData()
    End Sub

    Private Sub chkDinhtinh_CheckedChanged(sender As Object, e As EventArgs) Handles chkDinhtinh.CheckedChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If BtnGhi.Visible = False Then Exit Sub
        If chkDinhtinh.Checked Then
            grdGiaTriTS.Enabled = True
            grvGiaTriTS.OptionsBehavior.Editable = True
            grvGiaTriTS.OptionsBehavior.AllowAddRows = True
            grvGiaTriTS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            lblDonvido.Enabled = False
            cboDVD.Enabled = False
        Else
            grvGiaTriTS.OptionsBehavior.Editable = False
            grvGiaTriTS.OptionsBehavior.AllowAddRows = False
            grvGiaTriTS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            lblDonvido.Enabled = True
            cboDVD.Enabled = True
            grdGiaTriTS.Enabled = False
        End If

    End Sub

    Private Sub grvGiaTriTS_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvGiaTriTS.InitNewRow
        grvGiaTriTS.SetFocusedRowCellValue("MS_TS_GSTT", TxtMaso.Text.Trim())
        grvGiaTriTS.SetFocusedRowCellValue("DAT", False)

    End Sub

    Private Sub grvGiaTriTS_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles grvGiaTriTS.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub grvGiaTriTS_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grvGiaTriTS.ValidateRow
        If BtnGhi.Visible = False Then Exit Sub
        Try
            If grvGiaTriTS.GetFocusedDataRow()("TEN_GIA_TRI") Is Nothing Or String.IsNullOrEmpty(grvGiaTriTS.GetFocusedDataRow()("TEN_GIA_TRI").ToString) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgTEN_GIA_TRI", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                e.Valid = False
                Exit Sub
            Else
                Dim dt As DataTable = CType(grdGiaTriTS.DataSource, DataTable).Copy()
                If dt.Select().AsEnumerable().Any(Function(x) x("TEN_GIA_TRI") = grvGiaTriTS.GetFocusedDataRow()("TEN_GIA_TRI") And x("STT") <> grvGiaTriTS.GetFocusedDataRow()("STT")) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTengiatri", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    e.Valid = False
                    Exit Sub
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub cboDVD_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboDVD.ButtonClick
        If chkDinhtinh.Checked Then Exit Sub
        Dim frmDonvido As Report1.frmDonvido = New Report1.frmDonvido()
        frmDonvido.ShowDialog()
    End Sub

    Private Sub txtDuongDan_ButtonClick(sender As Object, e As EventArgs) Handles txtDuongDan.DoubleClick, txtDuongDan.ButtonClick
        Try
            If BtnGhi.Visible Then
                ofdHinh.FileName = ""
                ofdHinh.ShowDialog()
                LayDuongDan()
            Else
                If txtDuongDan.Text <> "" Then
                    Try
                        System.Diagnostics.Process.Start(txtDuongDan.Text)
                    Catch ex As Exception
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra9", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
                    End Try
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCV_Click(sender As Object, e As EventArgs) Handles btnCV.Click

        Dim frm As New MVControl.FrmGSTT_CV()
        frm.ShowDialog()
    End Sub
End Class
