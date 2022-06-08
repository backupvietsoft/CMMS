Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Globalization

Public Class frmrptKeHoachBaoTriTrongTuan
    Dim v_all As DataTable = New DataTable()
    Dim v_all_bdl As DataTable = New DataTable()
    Private Sub frmrptKeHoachBaoTriTrongTuan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Bind_cboNhaxuong()
            Bind_cboLoaiCV()
            LoadTuan()
            Bind_cboLoaithietbi3()

            'If Commons.Modules.sPrivate <> "BDL" Then
            '    cboLoai_CV.Visible = False
            '    lblLoaiCV.Visible = False
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Bind_cboLoaiCV()
        Dim tbLoaiCV As DataTable = New DataTable()
        tbLoaiCV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "PermisionLOAI_CV", Commons.Modules.UserName))
        Dim dtRow As DataRow
        dtRow = tbLoaiCV.NewRow
        dtRow("MS_LOAI_CV") = -1
        dtRow("TEN_LOAI_CV") = " < ALL > "
        dtRow("Username") = Commons.Modules.UserName
        tbLoaiCV.Rows.InsertAt(dtRow, 0)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoai_CV, tbLoaiCV, "MS_LOAI_CV", "TEN_LOAI_CV", "")


    End Sub

    Sub LoadTuan()
        Dim tb As New DataTable()
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTUAN_TRONG_NAM", "01/01/" + Now.Year.ToString, "31/12/" + Now.Year.ToString, Commons.Modules.TypeLanguage).Tables(0)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTuanNam, tb, "TUAN", "TEN_TUAN", "")
        Try
            Dim ciCurr As CultureInfo = CultureInfo.CurrentCulture
            Dim weekNum As Integer = ciCurr.Calendar.GetWeekOfYear(Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
            cboTuanNam.EditValue = weekNum
        Catch ex As Exception

        End Try
    End Sub

    Sub Bind_cboLoaithietbi3()
        Dim str As String = ""
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " &
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " &
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " &
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE USERNAME='" & Commons.Modules.UserName & "'"
        Dim tbLoaiTB As DataTable = New DataTable()
        tbLoaiTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, str))
        Dim dtRow As DataRow
        dtRow = tbLoaiTB.NewRow
        dtRow("MS_LOAI_MAY") = -1
        dtRow("TEN_LOAI_MAY") = " < ALL > "
        tbLoaiTB.Rows.InsertAt(dtRow, 0)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaithietbi3, tbLoaiTB, "MS_LOAI_MAY", "TEN_LOAI_MAY", "")

    End Sub

    Sub Bind_cboNhaxuong()

        Commons.Modules.ObjSystems.MLoadCboTreeList(cboNhaXuongPBT, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")

    End Sub


    Private Function ShowrptKeHoachBaoTriTrongTuan() As DataTable
        Try

            If Commons.Modules.sPrivate = "BDL" Then
                Dim sTuNgay As String
                sTuNgay = Microsoft.VisualBasic.Right(cboTuanNam.Text, 21)
                Dim vtbData As New DataTable
                'vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetrptKeHoachBaoTriTrongTuan_BDL", Microsoft.VisualBasic.Left(sTuNgay, 10), Microsoft.VisualBasic.Right(sTuNgay, 10), cboLoaithietbi3.SelectedValue.ToString, cboNhaXuongPBT.SelectedValue.ToString, Commons.Modules.UserName, cboLoai_CV.SelectedValue.ToString))
                vtbData = Get_DataTable_BDL(cboNhaXuongPBT.EditValue, Microsoft.VisualBasic.Left(sTuNgay, 10), Microsoft.VisualBasic.Right(sTuNgay, 10), cboLoaithietbi3.EditValue, cboLoai_CV.EditValue, "-1", "-1", "-1")
                Return vtbData
            Else
                Dim sTuNgay As String
                sTuNgay = Microsoft.VisualBasic.Right(cboTuanNam.Text, 21)

                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptKeHoachBaoTriTrongTuan", Microsoft.VisualBasic.Left(sTuNgay, 10), Microsoft.VisualBasic.Right(sTuNgay, 10), cboLoaithietbi3.SelectedValue, cboNhaXuongPBT.SelectedValue, Commons.Modules.UserName)
                Dim objTB As New DataTable
                'objTB = Get_DataTable(cboNhaXuongPBT.EditValue, Microsoft.VisualBasic.Left(sTuNgay, 10), Microsoft.VisualBasic.Right(sTuNgay, 10), cboLoaithietbi3.EditValue, "-1", "-1", "-1")

                objTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sBCKeHoachBaoTriTuan", Commons.Modules.UserName,
                                    Commons.Modules.TypeLanguage, cboNhaXuongPBT.EditValue, cboLoaithietbi3.EditValue, cboLoai_CV.EditValue))


                If objTB.Rows.Count <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Cursor = Cursors.Default
                    Return Nothing
                    Exit Function
                Else
                    Dim vTableKQ As DataTable = New DataTable()
                    vTableKQ = objTB.Copy()
                    vTableKQ.Clear()
                    For Each col As DataColumn In objTB.Columns
                        col.ReadOnly = False
                    Next

                    For Each vRow As DataRow In objTB.Rows
                        Dim ngaycuoi As DateTime
                        Try
                            ngaycuoi = GetNgaycuoi(Convert.ToDateTime(vRow("NGAY_CUOI")), Convert.ToDateTime(Microsoft.VisualBasic.Left(sTuNgay, 10)), Convert.ToDateTime(Microsoft.VisualBasic.Right(sTuNgay, 10)), vRow("MS_DV_TG"), Convert.ToInt32(vRow("CHU_KY")))

                            If ngaycuoi >= Convert.ToDateTime(Microsoft.VisualBasic.Left(sTuNgay, 10)) And ngaycuoi <= Convert.ToDateTime(Microsoft.VisualBasic.Right(sTuNgay, 10)) Then
                                vRow("NGAY_CUOI") = ngaycuoi
                                Select Case (ngaycuoi.DayOfWeek)
                                    Case DayOfWeek.Monday
                                        vRow("N1") = "X"
                                    Case DayOfWeek.Tuesday
                                        vRow("N2") = "X"
                                    Case DayOfWeek.Wednesday
                                        vRow("N3") = "X"
                                    Case DayOfWeek.Thursday
                                        vRow("N4") = "X"
                                    Case DayOfWeek.Friday
                                        vRow("N5") = "X"
                                    Case DayOfWeek.Saturday
                                        vRow("N6") = "X"
                                    Case DayOfWeek.Sunday
                                        vRow("N7") = "X"
                                End Select
                                Dim vRownew As DataRow = vTableKQ.NewRow()
                                For Each vColumn As DataColumn In vTableKQ.Columns
                                    vRownew(vColumn.ColumnName) = vRow(vColumn.ColumnName)
                                Next
                                vRownew("NGAY_KE") = ngaycuoi
                                vTableKQ.Rows.Add(vRownew)
                            Else
                            End If
                        Catch ex As Exception

                        End Try

                    Next

                    If vTableKQ.Rows.Count > 0 Then
                        For Each vRow As DataRow In vTableKQ.Rows
                            For Each vRowRemove As DataRow In vTableKQ.Rows
                                If (vRow("MS_MAY").Equals(vRowRemove("MS_MAY"))) Then
                                    If (Not vRow.IsNull("THU_TU") And Not vRowRemove.IsNull("THU_TU")) Then
                                        If (Convert.ToInt32(vRowRemove("THU_TU")) > Convert.ToInt32(vRow("THU_TU")) And Convert.ToInt32(vRowRemove("THU_TU")) <> 0) Then
                                            If (Not vRow.IsNull("MS_LOAI_BT") And Not vRowRemove.IsNull("MS_LOAI_BT")) Then
                                                Dim vTableLBT As DataTable = New DataTable()
                                                vTableLBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 LOAI_BAO_TRI_QH.* FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT = " & Convert.ToInt32(vRow("MS_LOAI_BT")) & "  AND MS_LOAI_BT_CD = " & Convert.ToInt32(vRowRemove("MS_LOAI_BT")) & ""))
                                                If (vTableLBT.Rows.Count > 0) Then
                                                    If (vRowRemove.IsNull("MS_DV_TG")) Then
                                                        Dim vNgayDuoi As System.DateTime = New System.DateTime()
                                                        Dim vNgayTren As System.DateTime = New System.DateTime()
                                                        Select Case (Convert.ToInt32(vRowRemove("MS_DV_TG")))
                                                            Case 1
                                                                vNgayDuoi = Convert.ToDateTime(vRow("NGAY_KE")).AddDays(-(Convert.ToInt64(vRowRemove("CHU_KY")) / 4))
                                                                vNgayTren = Convert.ToDateTime(vRow("NGAY_KE")).AddDays(Convert.ToInt64(vRowRemove("CHU_KY")) / 4)
                                                            Case 2
                                                                vNgayDuoi = Convert.ToDateTime(vRow("NGAY_KE")).AddDays((-(Convert.ToInt64(vRowRemove("CHU_KY")) * 7) / 4))
                                                                vNgayTren = Convert.ToDateTime(vRow("NGAY_KE")).AddDays((Convert.ToInt64(vRowRemove("CHU_KY")) * 7) / 4)
                                                            Case 3
                                                                vNgayDuoi = Convert.ToDateTime(vRow("NGAY_KE")).AddDays(-((Convert.ToInt64(vRowRemove("CHU_KY")) * 30) / 4))
                                                                vNgayTren = Convert.ToDateTime(vRow("NGAY_KE")).AddDays((Convert.ToInt64(vRowRemove("CHU_KY")) * 30) / 4)
                                                            Case 4
                                                                vNgayDuoi = Convert.ToDateTime(vRow("NGAY_KE")).AddDays(-((Convert.ToInt64(vRowRemove("CHU_KY")) * 360) / 4))
                                                                vNgayTren = Convert.ToDateTime(vRow("NGAY_KE")).AddDays((Convert.ToInt64(vRowRemove("CHU_KY")) * 360) / 4)
                                                        End Select
                                                        If (Convert.ToDateTime(vRowRemove("NGAY_KE")) >= vNgayDuoi And Convert.ToDateTime(vRowRemove("NGAY_KE")) <= vNgayTren) Then
                                                            vRowRemove.Delete()
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                        Return vTableKQ
                    Else
                        Return Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Function GetNgaycuoi(ByVal vNgayKe As DateTime, ByVal vNgayBDBTDK As DateTime, ByVal vNgayKTBTDK As DateTime, ByVal time As Integer, ByVal chuky As Integer) As DateTime
        Dim curent As DateTime
        Try

            While (vNgayKe <= vNgayKTBTDK)
                curent = vNgayKe
                Select Case (time)
                    Case 1
                        vNgayKe = vNgayKe.AddDays(chuky)
                    Case 2
                        vNgayKe = vNgayKe.AddDays(chuky * 7)
                    Case 3
                        vNgayKe = vNgayKe.AddMonths(chuky)
                    Case 4
                        vNgayKe = vNgayKe.AddYears(chuky)
                End Select
            End While
        Catch ex As Exception

        End Try
        Return curent

    End Function

    Private Function CreateTieuDe() As DataTable
        Dim DieuKienLoc As String = ""
        Dim sTuNgay As String
        sTuNgay = Microsoft.VisualBasic.Right(cboTuanNam.Text, 21)
        If Commons.Modules.TypeLanguage = 0 Then
            DieuKienLoc = "Từ ngày: " & Microsoft.VisualBasic.Left(sTuNgay, 10) & " Đến ngày: " & Microsoft.VisualBasic.Right(sTuNgay, 10)
        Else
            DieuKienLoc = "From: " & Microsoft.VisualBasic.Left(sTuNgay, 10) & " To: " & Microsoft.VisualBasic.Right(sTuNgay, 10)
        End If
        Dim dtTieuDe As New DataTable
        Dim dtR As DataRow
        dtTieuDe.TableName = "rptTieuDeKeHoachBaoTriTrongTuan"
        dtTieuDe.Columns.Clear()
        dtTieuDe.Columns.Add("commons.Modules.TypeLanguage")
        dtTieuDe.Columns.Add("NgayIn")
        dtTieuDe.Columns.Add("TrangIn")
        dtTieuDe.Columns.Add("TieuDe")
        dtTieuDe.Columns.Add("STT")
        dtTieuDe.Columns.Add("ThietBi")
        dtTieuDe.Columns.Add("CongViec")
        dtTieuDe.Columns.Add("DinhKy")
        dtTieuDe.Columns.Add("NgayTrongTuan")
        dtTieuDe.Columns.Add("DKloc")
        dtTieuDe.Columns.Add("NguoiThucHien")
        dtTieuDe.Columns.Add("N1")
        dtTieuDe.Columns.Add("N2")
        dtTieuDe.Columns.Add("N3")
        dtTieuDe.Columns.Add("N4")
        dtTieuDe.Columns.Add("N5")
        dtTieuDe.Columns.Add("N6")
        dtTieuDe.Columns.Add("N7")
        dtTieuDe.Columns.Add("NhaXuong")
        dtTieuDe.Columns.Add("HeThong")
        dtTieuDe.Columns.Add("TenThietBi")
        dtTieuDe.Columns.Add("NguoiDuyet")
        dtTieuDe.Columns.Add("NguoiGS")
        dtTieuDe.Columns.Add("ketQua")
        dtTieuDe.Columns.Add("NguoiLap")
        dtTieuDe.Columns.Add("NguoiKT")

        dtR = dtTieuDe.NewRow
        dtR.Item("commons.Modules.TypeLanguage") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NgayIn", Commons.Modules.TypeLanguage)
        dtR.Item("NgayIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NgayIn", Commons.Modules.TypeLanguage)
        dtR.Item("TrangIn") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TrangIn", Commons.Modules.TypeLanguage)
        dtR.Item("TieuDe") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TieuDe", Commons.Modules.TypeLanguage)
        dtR.Item("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "STT", Commons.Modules.TypeLanguage)
        dtR.Item("ThietBi") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "ThietBi", Commons.Modules.TypeLanguage)
        dtR.Item("CongViec") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "CongViec", Commons.Modules.TypeLanguage)
        dtR.Item("DinhKy") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "DinhKy", Commons.Modules.TypeLanguage)
        dtR.Item("NgayTrongTuan") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NgayTrongTuan", Commons.Modules.TypeLanguage)
        dtR.Item("DKloc") = DieuKienLoc
        dtR.Item("NguoiThucHien") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiThucHien", Commons.Modules.TypeLanguage)
        dtR.Item("N1") = "N1"
        dtR.Item("N2") = "N2"
        dtR.Item("N3") = "N3"
        dtR.Item("N4") = "N4"
        dtR.Item("N5") = "N5"
        dtR.Item("N6") = "N6"
        dtR.Item("N7") = "N7"
        dtR.Item("NhaXuong") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NhaXuong", Commons.Modules.TypeLanguage) & " " & cboNhaXuongPBT.TextValue.Trim
        dtR.Item("HeThong") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "HeThong", Commons.Modules.TypeLanguage)
        dtR.Item("TenThietBi") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TenThietBi", Commons.Modules.TypeLanguage)
        dtR.Item("NguoiDuyet") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiDuyet", Commons.Modules.TypeLanguage)
        dtR.Item("NguoiGS") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiGS", Commons.Modules.TypeLanguage)
        dtR.Item("ketQua") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "ketQua", Commons.Modules.TypeLanguage)

        dtR.Item("NguoiLap") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiLap", Commons.Modules.TypeLanguage)
        dtR.Item("NguoiKT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiKT", Commons.Modules.TypeLanguage)


        dtTieuDe.Rows.Add(dtR)

        Return dtTieuDe
    End Function
#Region "Nhu Y"


    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_loai_may As String) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[GetrptKeHoachBaoTriTrongTuan_NEW]", tungay, denngay, ms_loai_may, Commons.Modules.UserName))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), tungay, denngay, ms_loai_may)
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all.Rows.Count <= 0) Then
                                v_all = vDataParent.ToTable().Copy()
                                v_all.Clear()
                            End If
                            v_all.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If
                Next

                'v_all.Merge(temp.ToTable())

                Return v_all
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[GetrptKeHoachBaoTriTrongTuan_NEW]", tungay, denngay, ms_loai_may, Commons.Modules.UserName))
            Return objDataTable
        End If
    End Function

    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_loai_may As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay, ms_loai_may)
        Dim _city As String = ""
        Dim _district As String = ""
        Dim _street As String = ""
        If _table.Rows.Count > 0 Then


            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function

    Function Get_DataTable_BDL(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_loai_may As String, ByVal loai_cv As String) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[GetrptKeHoachBaoTriTrongTuan_BDL_NEW]", tungay, denngay, ms_loai_may, Commons.Modules.UserName, loai_cv))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable_BDL(vr("MS_N_Xuong_Final"), tungay, denngay, ms_loai_may, loai_cv)
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all_bdl.Rows.Count <= 0) Then
                                v_all_bdl = vDataParent.ToTable().Copy()
                                v_all_bdl.Clear()
                            End If
                            v_all_bdl.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If
                Next

                'v_all.Merge(temp.ToTable())

                Return v_all_bdl
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[GetrptKeHoachBaoTriTrongTuan_BDL_NEW]", tungay, denngay, ms_loai_may, Commons.Modules.UserName, loai_cv))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable_BDL(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_loai_may As String, ByVal loai_cv As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable_BDL(MS_N_Xuong, tungay, denngay, ms_loai_may, loai_cv)
        Dim _city As String = ""
        Dim _district As String = ""
        Dim _street As String = ""
        If _table.Rows.Count > 0 Then


            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function
#End Region





    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim frmReport As frmXMLReport = New frmXMLReport()
        Dim vtb As New DataTable

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT  PRIVATE FROM dbo.THONG_TIN_CHUNG "))
        If Commons.Modules.sPrivate = "BDL" Then
            frmReport.rptName = "rptKeHoachBaoTriTrongTuan_BDL"
        Else
            frmReport.rptName = "rptKeHoachBaoTriTrongTuan"
        End If
        v_all = New DataTable()
        v_all_bdl = New DataTable()
        vtb = ShowrptKeHoachBaoTriTrongTuan()
        If vtb Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_BAO_TRI_TRONG_TUAN", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
        Else
            vtb.TableName = "rptKE_HOACH_BAO_TRI_TRONG_TUAN"
            frmReport.AddDataTableSource(vtb)
            Dim dtTieude As DataTable
            dtTieude = CreateTieuDe()
            dtTieude.TableName = "rptTieude"
            frmReport.AddDataTableSource(dtTieude)
            frmReport.ShowDialog()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnThoat_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
