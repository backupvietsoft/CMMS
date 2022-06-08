Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Imports Commons.VS.Classes.Admin
Imports System.Data
Imports System.Windows.Forms

Public Class frmrptKE_HOACH_BT_TUAN
    Dim v_all As DataTable = New DataTable()
    Private Sub frmrptKE_HOACH_BT_TUAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FromDate.Value = System.DateTime.Now.Date
            ToDate.Value = System.DateTime.Now.Date.AddMonths(1)
            LoadNhaXuong()
            LoadLoaiCV()
            LoadGroupBy()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadLoaiCV()
        Dim tbLoaiCV As DataTable = New DataTable()
        Dim MS_LOAI_CV As DataColumn = New DataColumn()
        MS_LOAI_CV.ColumnName = "MS_LOAI_CV"
        tbLoaiCV.Columns.Add(MS_LOAI_CV)
        Dim TEN_LOAI_CV As DataColumn = New DataColumn()
        TEN_LOAI_CV.ColumnName = "TEN_LOAI_CV"
        tbLoaiCV.Columns.Add(TEN_LOAI_CV)
        Dim rAll As DataRow = tbLoaiCV.NewRow()
        rAll("MS_LOAI_CV") = "1"
        rAll("TEN_LOAI_CV") = " < ALL > "
        tbLoaiCV.Rows.Add(rAll)

        Dim rAnToan As DataRow = tbLoaiCV.NewRow()
        rAnToan("MS_LOAI_CV") = "2"
        If (Commons.Modules.TypeLanguage = 0) Then
            rAnToan("TEN_LOAI_CV") = "An toàn"
        Else
            rAnToan("TEN_LOAI_CV") = "Safety"
        End If
        tbLoaiCV.Rows.Add(rAnToan)

        Dim rKhongAnToan As DataRow = tbLoaiCV.NewRow()
        rKhongAnToan("MS_LOAI_CV") = "3"
        If (Commons.Modules.TypeLanguage = 0) Then
            rKhongAnToan("TEN_LOAI_CV") = "Thông thường"
        Else
            rKhongAnToan("TEN_LOAI_CV") = "Nomal"
        End If
        tbLoaiCV.Rows.Add(rKhongAnToan)

        cboTypeJob.DataSource = tbLoaiCV
        cboTypeJob.ValueMember = "MS_LOAI_CV"
        cboTypeJob.DisplayMember = "TEN_LOAI_CV"
    End Sub
    Private Sub LoadGroupBy()
        Dim tbGroup As DataTable = New DataTable()
        Dim MS_GROUP As DataColumn = New DataColumn()
        MS_GROUP.ColumnName = "MS_GROUP"
        tbGroup.Columns.Add(MS_GROUP)
        Dim TEN_GROUP As DataColumn = New DataColumn()
        TEN_GROUP.ColumnName = "TEN_GROUP"
        tbGroup.Columns.Add(TEN_GROUP)

        Dim rLoaiTB As DataRow = tbGroup.NewRow()
        rLoaiTB("MS_GROUP") = "1"
        If (Commons.Modules.TypeLanguage = 0) Then
            rLoaiTB("TEN_GROUP") = "Theo loại thiết bị"
        Else
            rLoaiTB("TEN_GROUP") = "by equipment type"
        End If
        tbGroup.Rows.Add(rLoaiTB)

        Dim rDayChuyen As DataRow = tbGroup.NewRow()
        rDayChuyen("MS_GROUP") = "2"
        If (Commons.Modules.TypeLanguage = 0) Then
            rDayChuyen("TEN_GROUP") = "Theo dây chuyền"
        Else
            rDayChuyen("TEN_GROUP") = "By line"
        End If
        tbGroup.Rows.Add(rDayChuyen)

        cboGroup.DataSource = tbGroup
        cboGroup.ValueMember = "MS_GROUP"
        cboGroup.DisplayMember = "TEN_GROUP"
    End Sub
    Private Sub LoadNhaXuong()
        Try
            'Dim tbNhaXuong As DataTable = New DataTable()
            'tbNhaXuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_N_XUONG, TEN_N_XUONG FROM NHA_XUONG"))
            'cboPlace.DataSource = tbNhaXuong
            'cboPlace.ValueMember = "MS_N_XUONG"
            'cboPlace.DisplayMember = "TEN_N_XUONG"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
            cboPlace.DisplayMember = "TEN_N_XUONG"
            cboPlace.ValueMember = "MS_N_XUONG"
            cboPlace.DataSource = _table
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If (FromDate.Value < Date.Now.Date) Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "MsgFromDateNhoHonNow", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If (FromDate.Value > ToDate.Value) Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "MsgFromDateNhoHonToDate", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim vTuan As System.Globalization.GregorianCalendar = New System.Globalization.GregorianCalendar()
            Dim vMin As Integer = vTuan.GetWeekOfYear(FromDate.Value, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
            Dim vMax As Integer = vTuan.GetWeekOfYear(ToDate.Value, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
            If (vMax > vMin) Then
                If (vMax - vMin > 5) Then
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "MsgSoTuanNhoHon5", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                Dim vTYear = vTuan.GetWeekOfYear(Convert.ToDateTime("31/12/" & FromDate.Value.Year), Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                If (((vTYear - vMin) + vMax) > 5) Then
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "MsgSoTuanNhoHon5", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            Dim frmShow As frmXMLReport = New frmXMLReport()
            If (cboGroup.SelectedValue = "1") Then
                frmShow.rptName = "rptKE_HOACH_BAO_TRI_TUAN"
            Else
                frmShow.rptName = "rptKE_HOACH_BAO_TRI_TUAN_He_Thong"
            End If
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim dtKHBT As New DataTable
            v_all = New DataTable()
            dtKHBT = GetKHBTTheoMay(FromDate.Value, ToDate.Value, cboPlace.SelectedValue, cboTypeJob.SelectedIndex)
            If dtKHBT Is Nothing Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "msgKhongcogiatridein", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            frmShow.AddDataTableSource(dtKHBT)
            frmShow.AddDataTableSource(CreaterptTieuDe())
            Me.Cursor = Cursors.Default
            frmShow.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub

    Private Function GetKHBTTheoMay(ByVal vNgayBDBTDK As System.DateTime, ByVal vNgayKTBTDK As System.DateTime, ByVal vNhaXuong As Object, ByVal vAnToan As String) As DataTable
        Try
            Dim vTableBTDK As DataTable = New DataTable()
            vTableBTDK = Get_DataTable(vNhaXuong, vAnToan, "-1", "-1", "-1")
            If vTableBTDK.Rows.Count <= 0 Then
                Return vTableBTDK
            End If
            Dim vTableKQ As DataTable = New DataTable()
            vTableKQ = vTableBTDK.Copy()
            vTableKQ.Rows.Clear()
            Try
                For Each vRow As DataRow In vTableBTDK.Rows
                    Dim vNgayKe As System.DateTime = Convert.ToDateTime(vRow("NGAY_CUOI"))
                    While (vNgayKe <= vNgayKTBTDK)
                        If IsDBNull(vRow("MS_DV_TG")) Then
                            Exit While
                        End If
                        Select Case (Convert.ToInt32(vRow("MS_DV_TG")))
                            Case 1
                                vNgayKe = vNgayKe.AddDays(Convert.ToInt32(vRow("CHU_KY")))
                            Case 2
                                vNgayKe = vNgayKe.AddDays(Convert.ToInt32(vRow("CHU_KY")) * 7)
                            Case 3
                                vNgayKe = vNgayKe.AddMonths(Convert.ToInt32(vRow("CHU_KY")))
                            Case 4
                                vNgayKe = vNgayKe.AddYears(Convert.ToInt32(vRow("CHU_KY")))
                        End Select
                        If (vNgayKe <= vNgayKTBTDK And vNgayKe >= vNgayBDBTDK) Then
                            Dim vRownew As DataRow = vTableKQ.NewRow()
                            For Each vColumn As DataColumn In vTableKQ.Columns
                                vRownew(vColumn.ColumnName) = vRow(vColumn.ColumnName)
                            Next
                            vRownew("NGAY_KE") = vNgayKe
                            vTableKQ.Rows.Add(vRownew)
                        End If
                    End While
                Next
            Catch ex As Exception

            End Try


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
            Dim vTuan As System.Globalization.GregorianCalendar = New System.Globalization.GregorianCalendar()
            Dim vMin As Integer = vTuan.GetWeekOfYear(vNgayBDBTDK, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
            Dim vMax As Integer = vTuan.GetWeekOfYear(vNgayKTBTDK, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)

            vTableKQ.Columns("TUAN1").ReadOnly = False
            vTableKQ.Columns("TUAN2").ReadOnly = False
            vTableKQ.Columns("TUAN3").ReadOnly = False
            vTableKQ.Columns("TUAN4").ReadOnly = False
            vTableKQ.Columns("TUAN5").ReadOnly = False
            vTableKQ.Columns("TUAN1").MaxLength = 50
            vTableKQ.Columns("TUAN2").MaxLength = 50
            vTableKQ.Columns("TUAN3").MaxLength = 50
            vTableKQ.Columns("TUAN4").MaxLength = 50
            vTableKQ.Columns("TUAN5").MaxLength = 50
            For i As Integer = 0 To vTableKQ.Rows.Count - 1
                Try
                    Dim vRow As DataRow = vTableKQ.Rows(i)
                    For j As Integer = i + 1 To vTableKQ.Rows.Count - 1
                        Try
                            Dim vRowRemove As DataRow = vTableKQ.Rows(j)
                            If (i <> j) Then
                                If (vRow("MS_MAY").Equals(vRowRemove("MS_MAY")) And vRow("MS_LOAI_BT").Equals(vRowRemove("MS_LOAI_BT")) And vRow("MS_CV").Equals(vRowRemove("MS_CV")) And vRow("MS_BO_PHAN").Equals(vRowRemove("MS_BO_PHAN"))) Then
                                    If (vMin < vMax Or vTuan.GetWeekOfYear(Convert.ToDateTime(vRowRemove("NGAY_KE")), Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday) < vMin) Then
                                        Select Case (5 - (vMax - vTuan.GetWeekOfYear(Convert.ToDateTime(vRowRemove("NGAY_KE")), Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)))
                                            Case 1
                                                vRow("TUAN1") = vRow("TUAN1").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 2
                                                vRow("TUAN2") = vRow("TUAN2").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 3
                                                vRow("TUAN3") = vRow("TUAN3").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 4
                                                vRow("TUAN4") = vRow("TUAN4").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 5
                                                vRow("TUAN5") = vRow("TUAN5").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                        End Select
                                    Else
                                        Select Case (vTuan.GetWeekOfYear(Convert.ToDateTime(vRowRemove("NGAY_KE")), Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday) - vMin + 1)
                                            Case 1
                                                vRow("TUAN1") = vRow("TUAN1").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 2
                                                vRow("TUAN2") = vRow("TUAN2").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 3
                                                vRow("TUAN3") = vRow("TUAN3").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 4
                                                vRow("TUAN4") = vRow("TUAN4").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                            Case 5
                                                vRow("TUAN5") = vRow("TUAN5").ToString().Trim() & "X"
                                                vTableKQ.Rows.Remove(vRowRemove)
                                                j = j - 1
                                        End Select
                                    End If
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                    Select Case (5 - (vMax - vTuan.GetWeekOfYear(Convert.ToDateTime(vRow("NGAY_KE")), Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)))
                        Case 1
                            vRow("TUAN1") = vRow("TUAN1").ToString().Trim() & "X"
                        Case 2
                            vRow("TUAN2") = vRow("TUAN2").ToString().Trim() & "X"
                        Case 3
                            vRow("TUAN3") = vRow("TUAN3").ToString().Trim() & "X"
                        Case 4
                            vRow("TUAN4") = vRow("TUAN4").ToString().Trim() & "X"
                        Case 5
                            vRow("TUAN5") = vRow("TUAN5").ToString().Trim() & "X"
                    End Select
                Catch ex As Exception

                End Try
            Next
            vTableKQ = GetParentBophan(vTableKQ)
            Return vTableKQ
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetParentBophan(ByVal dt As DataTable) As DataTable
        Try
            Dim sMamay As String
            Dim sTenbp As String
            If dt.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    Dim sMabp As String
                    sTenbp = ""
                    sMabp = dt.Rows(i)("MS_BO_PHAN").ToString()
                    sMamay = dt.Rows(i)("MS_MAY").ToString()
                    sTenbp = GetParent(sMabp, sMamay, sTenbp)
                    dt.Rows(i)("TEN_BO_PHAN") = sTenbp
                Next
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetParent(ByVal mabp As String, ByVal msmay As String, ByVal sTenbp As String) As String
        Dim sql, mspbcha As String
        sql = "SELECT TEN_BO_PHAN,MS_BO_PHAN_CHA FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN =N'" + mabp + "' AND MS_MAY = N'" + msmay + "'"
        Dim dt As DataTable = New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        If dt.Rows.Count > 0 Then
            If sTenbp = "" Then
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString()
            Else
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString() + " \ " + sTenbp
            End If


            mspbcha = dt.Rows(0)("MS_BO_PHAN_CHA").ToString()
            If mspbcha <> msmay Then
                Return GetParent(mspbcha, msmay, sTenbp)
            Else
                Return sTenbp
            End If
        Else
            Return Nothing
        End If


    End Function

    Private Function CreaterptTieuDe() As DataTable

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "TieuDe", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "ThietBi", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "CongViec", Commons.Modules.TypeLanguage)
        Dim DinhKy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "DinhKy", Commons.Modules.TypeLanguage)
        Dim Tuan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "Tuan", Commons.Modules.TypeLanguage)
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "HeThong", Commons.Modules.TypeLanguage)
        Dim LoaiTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "LoaiTB", Commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTuan", "BoPhan", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = ""
        If Commons.Modules.TypeLanguage = 0 Then
            DieuKienLoc = "Từ ngày: " & FromDate.Value.ToString("dd/MM/yyyy") & " Đến ngày: " & ToDate.Value.ToString("dd/MM/yyyy")
        Else
            DieuKienLoc = "From: " & FromDate.Value.ToString("dd/MM/yyyy") & " To: " & ToDate.Value.ToString("dd/MM/yyyy")
        End If

        Dim tbTitle As DataTable = New DataTable()

        Dim clTieuDe As DataColumn = New DataColumn()
        clTieuDe.ColumnName = "TieuDe"
        tbTitle.Columns.Add(clTieuDe)

        Dim clSTT As DataColumn = New DataColumn()
        clSTT.ColumnName = "STT"
        tbTitle.Columns.Add(clSTT)

        Dim clThietBi As DataColumn = New DataColumn()
        clThietBi.ColumnName = "ThietBi"
        tbTitle.Columns.Add(clThietBi)

        Dim clCongViec As DataColumn = New DataColumn()
        clCongViec.ColumnName = "CongViec"
        tbTitle.Columns.Add(clCongViec)

        Dim clDinhKy As DataColumn = New DataColumn()
        clDinhKy.ColumnName = "DinhKy"
        tbTitle.Columns.Add(clDinhKy)

        Dim clTuan As DataColumn = New DataColumn()
        clTuan.ColumnName = "Tuan"
        tbTitle.Columns.Add(clTuan)

        Dim clHeThong As DataColumn = New DataColumn()
        clHeThong.ColumnName = "HeThong"
        tbTitle.Columns.Add(clHeThong)

        Dim clBoPhan As DataColumn = New DataColumn()
        clBoPhan.ColumnName = "BoPhan"
        tbTitle.Columns.Add(clBoPhan)

        Dim clLoaiTB As DataColumn = New DataColumn()
        clLoaiTB.ColumnName = "LoaiTB"
        tbTitle.Columns.Add(clLoaiTB)

        Dim clDieuKienLoc As DataColumn = New DataColumn()
        clDieuKienLoc.ColumnName = "DieuKienLoc"
        tbTitle.Columns.Add(clDieuKienLoc)

        Dim clTuan1 As DataColumn = New DataColumn()
        clTuan1.ColumnName = "Tuan1"
        tbTitle.Columns.Add(clTuan1)

        Dim clTuan2 As DataColumn = New DataColumn()
        clTuan2.ColumnName = "Tuan2"
        tbTitle.Columns.Add(clTuan2)

        Dim clTuan3 As DataColumn = New DataColumn()
        clTuan3.ColumnName = "Tuan3"
        tbTitle.Columns.Add(clTuan3)

        Dim clTuan4 As DataColumn = New DataColumn()
        clTuan4.ColumnName = "Tuan4"
        tbTitle.Columns.Add(clTuan4)

        Dim clTuan5 As DataColumn = New DataColumn()
        clTuan5.ColumnName = "Tuan5"
        tbTitle.Columns.Add(clTuan5)

        Dim rTitle As DataRow = tbTitle.NewRow()
        rTitle("TieuDe") = TieuDe
        rTitle("STT") = STT
        rTitle("ThietBi") = ThietBi
        rTitle("CongViec") = CongViec
        rTitle("DinhKy") = DinhKy
        rTitle("Tuan") = Tuan
        rTitle("HeThong") = HeThong
        rTitle("BoPhan") = BoPhan
        rTitle("LoaiTB") = LoaiTB
        rTitle("DieuKienLoc") = DieuKienLoc
        Dim vNgay As System.DateTime = FromDate.Value
        Dim vTuan As System.Globalization.GregorianCalendar = New System.Globalization.GregorianCalendar()
        rTitle("Tuan1") = vTuan.GetWeekOfYear(vNgay, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString().Trim() & "/" & vNgay.Year.ToString().Trim()
        vNgay = vNgay.AddDays(7)
        rTitle("Tuan2") = vTuan.GetWeekOfYear(vNgay, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString().Trim() & "/" & vNgay.Year.ToString().Trim()
        vNgay = vNgay.AddDays(7)
        rTitle("Tuan3") = vTuan.GetWeekOfYear(vNgay, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString().Trim() & "/" & vNgay.Year.ToString().Trim()
        vNgay = vNgay.AddDays(7)
        rTitle("Tuan4") = vTuan.GetWeekOfYear(vNgay, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString().Trim() & "/" & vNgay.Year.ToString().Trim()
        vNgay = vNgay.AddDays(7)
        rTitle("Tuan5") = vTuan.GetWeekOfYear(vNgay, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString().Trim() & "/" & vNgay.Year.ToString().Trim()

        tbTitle.Rows.Add(rTitle)
        tbTitle.TableName = "tbTieuDe"
        Return tbTitle
    End Function
#Region "Nhu Y"
   

    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal antoan As Integer) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_KHBTT_New]", antoan))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), antoan)
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_KHBTT_New]", antoan))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal antoan As Integer, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, antoan)
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
  

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
