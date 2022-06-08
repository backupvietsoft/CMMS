﻿Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Data.SqlClient

Public Class MLoadBaoCao
#Region "ucMailBaoTriDinhKyThangCS - BTDKTCS"
    'ByVal grd As DevExpress.XtraGrid.GridControl, ByVal grv As DevExpress.XtraGrid.Views.Grid.GridView
    Dim rcount As Integer = 3

    Public Function BTDKTCSInMailBaoTriDinhKyThangCS(ByVal dtSch As DataTable) As String

        Try
            Dim sPath As String
            sPath = Application.StartupPath + "\" + dtSch.Rows(0)("ID_MAIL").ToString().Trim() + "-" + dtSch.Rows(0)("ID").ToString().Trim + ".xls"
            Dim NNgu, iSNgay As Integer
            Dim sUserName, sDKBCao, sDKien As String
            Dim SauNgayBD As Boolean
            NNgu = Integer.Parse(dtSch.Rows(0)("NGON_NGU").ToString())
            sUserName = dtSch.Rows(0)("USERNAME").ToString()
            sDKBCao = dtSch.Rows(0)("DK_BAOCAO").ToString()
            'string[] chuoi_tach = sStmp.Split(new Char[] { ',' });

            Dim chuoi_tach As String() = sDKBCao.Split(New [Char]() {","c})
            Dim iTTrang As Integer
            Dim sDDiem, BTam As String
            Dim dtTmp As New DataTable
            Dim TNgay, DNgay As Date

            BTam = "AAA_BTDKCS_TMP" + sUserName

            If chuoi_tach.GetValue(0).ToString().Trim() = 0 Then SauNgayBD = False Else SauNgayBD = True
            iSNgay = Integer.Parse(chuoi_tach.GetValue(1).ToString().Trim())
            iTTrang = Integer.Parse(chuoi_tach.GetValue(2).ToString().Trim())
            If iTTrang = -1 Then iTTrang = 2
            sDDiem = chuoi_tach.GetValue(3).ToString().Trim()
            sDKien = chuoi_tach.GetValue(4).ToString().Trim()

            TNgay = Convert.ToDateTime("01/" + Now.Date.Month.ToString() + "/" + Now.Date.Year.ToString())

            If SauNgayBD = False Then
                iSNgay = -iSNgay
            End If
            Try
                If iSNgay = 0 Then
                    TNgay = TNgay
                    DNgay = TNgay.AddMonths(1).AddDays(-1)
                Else
                    TNgay = TNgay.AddMonths(Convert.ToDouble(iSNgay))
                    DNgay = TNgay.AddMonths(Convert.ToDouble(1)).AddDays(-1)
                End If
            Catch ex As Exception
                TNgay = TNgay
                DNgay = TNgay.AddDays(-1)
            End Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_HE_THONG",
                            sUserName, NNgu))

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, BTam, dtTmp, "")

            BTam = "AAA_BTDKCS" + sUserName
            Commons.Modules.ObjSystems.XoaTable(BTam)

            If sDKien <> "ALL" Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                                "SELECT * INTO " + BTam + " FROM AAA_BTDKCS_TMP" + sUserName +
                                " WHERE MS_HE_THONG IN (" + sDKien.Replace("@", ",").Substring(0, sDKien.Length - 1) + ") ")
            Else
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                                "SELECT * INTO " + BTam + " FROM AAA_BTDKCS_TMP" + sUserName + " ")

            End If
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG ,TEN_HE_THONG  FROM " + BTam + " ORDER BY MS_HE_THONG"))


            Dim vTbData As System.Data.DataTable = New System.Data.DataTable()

            Dim cnn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            Dim cmd As New SqlClient.SqlCommand

            If (cnn.State = ConnectionState.Closed) Then
                cnn.Open()
            End If
            cmd.Connection = cnn
            cmd.CommandTimeout = 99999
            cmd.CommandType = CommandType.StoredProcedure


            Try
                'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spBCBaoTriThang", sUserName, sDDiem, BTam, TNgay, DNgay, NNgu)

                cmd.CommandText = "spBCBaoTriThang"
                cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserName", sUserName))
                cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@MsNX", sDDiem))
                cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HThong", BTam))
                cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TuNgay", TNgay))
                cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DenNgay", DNgay))
                cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NNgu", NNgu))
                Dim dt As New System.Data.DataTable
                cmd.ExecuteNonQuery()

                Dim tbT1 As New System.Data.DataTable
                tbT1.Load(SqlHelper.ExecuteReader(cnn, "GET_BTCVBP"))
                For Each r As DataRow In tbT1.Rows
                    Dim tb2 As New System.Data.DataTable
                    Dim lstPhutung As String = ""
                    tb2.Load(SqlHelper.ExecuteReader(cnn, "GET_BTCVBP_TMP", r("MS_MAY"), r("MS_LOAI_BT"), r("MS_CV"), r("MS_BO_PHAN")))
                    For Each r1 As DataRow In tb2.Rows
                        If lstPhutung = "" Then
                            lstPhutung = r1("TEN_PT") & " " & r1("SO_LUONG") & " " & r1("DVT")
                        Else
                            lstPhutung = lstPhutung & ", " & r1("TEN_PT") & " " & r1("SO_LUONG") & " " & r1("DVT")
                        End If
                    Next
                    SqlHelper.ExecuteNonQuery(cnn, "ADD_CONG_VIEC_PHU_TUNG_LIST_TMP", r("MS_MAY").ToString, r("MS_LOAI_BT").ToString, r("MS_CV").ToString, r("MS_BO_PHAN").ToString, lstPhutung)
                Next

                vTbData = New System.Data.DataTable()
                vTbData = BTDKTCSGet_DataTable(sDDiem, iTTrang, TNgay, DNgay, "-1", "-1", "-1")
                rcount = 3
                If vTbData.Rows.Count > 0 Then
                    Dim sql As String = "(0"
                    For Each row As DataRow In dtTmp.Rows
                        sql = sql & "," & row("MS_HE_THONG").ToString()
                    Next
                    sql = sql & ")"
                    Dim tbdt As New System.Data.DataTable
                    vTbData.DefaultView.RowFilter = "MS_HE_THONG IN " & sql
                    tbdt = BTDKTCSGetParentBophan(vTbData.DefaultView.ToTable())
                    If vTbData.Rows.Count > 0 Then
                        Dim sLoi As String
                        sLoi = BTDKTCSExportExcel(vTbData.DefaultView.ToTable(), dtTmp, TNgay.ToString("MM/yyyy"), sDDiem, sPath, NNgu)
                        If sLoi <> "" Then Return sLoi
                    Else
                        Return "KhongCoDuLieuIn"
                    End If
                Else
                    Return "KhongCoDuLieuIn"
                End If
                If (cnn.State = ConnectionState.Open) Then
                    cnn.Close()
                End If
            Catch ex As Exception
                If (cnn.State = ConnectionState.Open) Then
                    cnn.Close()
                End If
                Return ex.Message.ToString()
            End Try

            Return "True"
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Private Function BTDKTCSGetParentBophan(ByVal dt As System.Data.DataTable) As System.Data.DataTable
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
                    sTenbp = BTDKTCSGetParent(sMabp, sMamay, sTenbp)
                    dt.Rows(i)("TEN_BO_PHAN") = sTenbp
                Next
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function BTDKTCSGetParent(ByVal mabp As String, ByVal msmay As String, ByVal sTenbp As String) As String
        Dim sql, mspbcha As String
        sql = "SELECT TEN_BO_PHAN,MS_BO_PHAN_CHA FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN =N'" + mabp + "' AND MS_MAY = N'" + msmay + "'"
        Dim dt As System.Data.DataTable = New System.Data.DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        If dt.Rows.Count > 0 Then
            If sTenbp = "" Then
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString()
            Else
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString() + " >> " + sTenbp
            End If


            mspbcha = dt.Rows(0)("MS_BO_PHAN_CHA").ToString()
            If mspbcha <> msmay Then
                Return BTDKTCSGetParent(mspbcha, msmay, sTenbp)
            Else
                Return sTenbp
            End If
        End If

        Return ""
    End Function

    Function BTDKTCSGet_DataTable(ByVal MS_N_Xuong As String, ByVal antoan As Integer, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_tinh As String, ByVal ms_quan As String, ByVal ms_duong As String) As System.Data.DataTable
        Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getBaoTriDinhDinhKyThang_CS", antoan, tungay, denngay, MS_N_Xuong, ms_tinh, ms_quan, ms_duong))
        Return objDataTable

    End Function

    Function BTDKTCSGet_DataTable_ALL(ByVal MS_N_Xuong As String, ByVal denngay As Date, ByVal city As String, ByVal district As String,
            ByVal street As String, ByVal sUserName As String) As System.Data.DataTable
        Try

            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getBaoTriDinhDinhKyThang_All", denngay.ToString("yyy/MM/dd"), MS_N_Xuong, sUserName, city, district, street))
            Return objDataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function BTDKTCSExportExcel(ByVal tbData As System.Data.DataTable, ByVal dtHeThong As DataTable, ByVal sThang As String,
                            ByVal sDDiem As String, ByVal sPath As String, ByVal NNgu As Integer) As String
        Try

            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)


            With ExcelSheets
                .Range("A1", "AL1").Font.Bold = True
                .Range("A1", "AL1").Merge(True)
                .Range("A1", "AL1").MergeCells = True
                .Range("A1", "AL1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1", "AL1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("A1", "AL1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "titleBaotridinhkythang", NNgu)

                .Range("A2", "B2").Font.Bold = True
                .Range("A2", "B2").Merge(True)
                .Range("A2", "B2").MergeCells = True
                .Range("A2", "B2").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                .Range("A2", "B2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Nhaxuong", NNgu) + " " + sDDiem
            End With

            For Each row As DataRow In dtHeThong.Rows
                tbData.DefaultView.RowFilter = "MS_HE_THONG = " & row("MS_HE_THONG").ToString()
                'row("MS_HE_THONG").ToString()
                If tbData.DefaultView.ToTable().Rows.Count > 0 Then
                    With ExcelSheets
                        .Range("A" & rcount.ToString, "G" & rcount.ToString).Font.Bold = True
                        .Range("A" & rcount.ToString, "G" & rcount.ToString).Merge(True)
                        .Range("A" & rcount.ToString, "G" & rcount.ToString).MergeCells = True
                        .Range("A" & rcount.ToString, "G" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                        .Range("A" & rcount.ToString, "G" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Daychuyen", NNgu) + " " + row("TEN_HE_THONG").ToString()

                        .Range("H" & rcount.ToString, "AL" & rcount.ToString).Font.Bold = True
                        .Range("H" & rcount.ToString, "AL" & rcount.ToString).Merge(True)
                        .Range("H" & rcount.ToString, "AL" & rcount.ToString).MergeCells = True
                        .Range("H" & rcount.ToString, "AL" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("H" & rcount.ToString, "AL" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "Thang", NNgu) + " " + sThang
                    End With
                    rcount = rcount + 1
                    BTDKTCSAddHeader(ExcelSheets, sThang, NNgu)
                    rcount = rcount + 1
                    BTDKTCSAddDetail(tbData.DefaultView.ToTable(), ExcelSheets, sThang)
                    'rcount = rcount + 1
                End If
            Next


            'ExcelBooks.SaveAs(sPath)
            ExcelApp.DisplayAlerts = False
            ExcelBooks.Save()

            ExcelBooks.SaveAs(sPath, Excel.XlFileFormat.xlWorkbookNormal,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Excel.XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing)

            ExcelBooks.Close(Type.Missing, Type.Missing, Type.Missing)
            ExcelApp.DisplayAlerts = False
            ExcelApp.Quit()
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
        Return ""
    End Function

    'sThang truyen vao voi gia tri "MM/yyyy"
    Private Sub BTDKTCSAddHeader(ByVal ExcelSheets As Excel.Worksheet, ByVal sThang As String, ByVal NNgu As Integer)
        With ExcelSheets
            .Range("A" & rcount.ToString, "A" & rcount.ToString).Font.Bold = True
            .Range("A" & rcount.ToString, "A" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("A" & rcount.ToString, "A" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A" & rcount.ToString, "A" & rcount.ToString).ColumnWidth = 5
            .Range("A" & rcount.ToString, "A" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "STT", NNgu)

            .Range("B" & rcount.ToString, "B" & rcount.ToString).Font.Bold = True
            .Range("B" & rcount.ToString, "B" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("B" & rcount.ToString, "B" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("B" & rcount.ToString, "B" & rcount.ToString).ColumnWidth = 25
            .Range("B" & rcount.ToString, "B" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MACHINENAME", NNgu)

            .Range("C" & rcount.ToString, "C" & rcount.ToString).Font.Bold = True
            .Range("C" & rcount.ToString, "C" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("C" & rcount.ToString, "C" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("C" & rcount.ToString, "C" & rcount.ToString).ColumnWidth = 15
            .Range("C" & rcount.ToString, "C" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "ID", NNgu)

            .Range("D" & rcount.ToString, "D" & rcount.ToString).Font.Bold = True
            .Range("D" & rcount.ToString, "D" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Range("D" & rcount.ToString, "D" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("D" & rcount.ToString, "D" & rcount.ToString).ColumnWidth = 15
            .Range("D" & rcount.ToString, "D" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "MODEL", NNgu)

            .Range("E" & rcount.ToString, "E" & rcount.ToString).Font.Bold = True
            .Range("E" & rcount.ToString, "E" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("E" & rcount.ToString, "E" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & rcount.ToString, "E" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "LOAIBT", NNgu)

            .Range("F" & rcount.ToString, "F" & rcount.ToString).Font.Bold = True
            .Range("F" & rcount.ToString, "F" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("F" & rcount.ToString, "F" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("F" & rcount.ToString, "F" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "CHUKY", NNgu)

            .Range("G" & rcount.ToString, "G" & rcount.ToString).Font.Bold = True
            .Range("G" & rcount.ToString, "G" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("G" & rcount.ToString, "G" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & rcount.ToString, "G" & rcount.ToString).ColumnWidth = 15
            .Range("G" & rcount.ToString, "G" & rcount.ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBaoTriDinhKyThangCS", "NGAYCUOI", NNgu)

            For i As Integer = 1 To 19
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Font.Bold = True
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).ColumnWidth = 2
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Value = i.ToString
                If DateTime.Parse(i.ToString & "/" & sThang).DayOfWeek = DayOfWeek.Sunday Then
                    .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                End If
            Next
            For i As Integer = 0 To 11
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Font.Bold = True
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).ColumnWidth = 2
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Value = (20 + i).ToString
                Try
                    If DateTime.Parse((20 + i).ToString & "/" & sThang).DayOfWeek = DayOfWeek.Sunday Then
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                    End If
                Catch ex As Exception

                End Try

            Next
        End With
    End Sub
    'sThang truyen vao voi gia tri "MM/yyyy"
    Private Sub BTDKTCSAddDetail(ByVal dtData As System.Data.DataTable, ByVal ExcelSheets As Excel.Worksheet, ByVal sThang As String)
        Try
            Dim inx As Integer = 0
            For Each row As DataRow In dtData.Rows
                inx += 1
                With ExcelSheets
                    .Range("A" & rcount.ToString, "A" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("A" & rcount.ToString, "A" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Range("A" & rcount.ToString, "A" & rcount.ToString).Value = inx

                    .Range("B" & rcount.ToString, "B" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                    .Range("B" & rcount.ToString, "B" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Range("B" & rcount.ToString, "B" & rcount.ToString).Value = row("TEN_MAY").ToString()

                    .Range("C" & rcount.ToString, "C" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("C" & rcount.ToString, "C" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Range("C" & rcount.ToString, "C" & rcount.ToString).Value = row("MS_MAY").ToString()

                    .Range("D" & rcount.ToString, "D" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("D" & rcount.ToString, "D" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Range("D" & rcount.ToString, "D" & rcount.ToString).Value = row("MODEL").ToString()

                    .Range("E" & rcount.ToString, "E" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("E" & rcount.ToString, "E" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Range("E" & rcount.ToString, "E" & rcount.ToString).Value = row("TEN_LOAI_BT").ToString()

                    .Range("F" & rcount.ToString, "F" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("F" & rcount.ToString, "F" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Range("F" & rcount.ToString, "F" & rcount.ToString).Value = row("CHU_KY").ToString() & " " & row("TEN_DV_TG").ToString()

                    Dim nc As DateTime = DateTime.Parse(row("NGAY_CUOI").ToString)
                    .Range("G" & rcount.ToString, "G" & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("G" & rcount.ToString, "G" & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Range("G" & rcount.ToString, "G" & rcount.ToString).Value = String.Format("{0:dd/MM/yyyy}", nc)


                    For i As Integer = 1 To 19
                        .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Value = "" 'IIf(row("T" & i).ToString <> "0", row("T" & i).ToString, "")
                        If Int32.Parse(row("T" & i).ToString) > 0 Then
                            .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Interior.Color = RGB(200, 160, 35)
                        End If
                        If DateTime.Parse(i.ToString & "/" & sThang).DayOfWeek = DayOfWeek.Sunday Then
                            .Range(Convert.ToChar(71 + i).ToString & rcount.ToString, Convert.ToChar(71 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                        End If
                    Next
                    For i As Integer = 0 To 11
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Value = "" 'IIf(row("T" & (i + 20).ToString).ToString <> "0", row("T" & (i + 20).ToString).ToString, "")
                        If Int32.Parse(row("T" & (i + 20).ToString).ToString()) > 0 Then
                            .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Interior.Color = RGB(200, 160, 35)
                        End If
                        Try
                            If DateTime.Parse((20 + i).ToString & "/" & sThang).DayOfWeek = DayOfWeek.Sunday Then
                                .Range("A" & Convert.ToChar(65 + i).ToString & rcount.ToString, "A" & Convert.ToChar(65 + i).ToString & rcount.ToString).Interior.Color = RGB(255, 0, 0)
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                End With
                rcount += 1
            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
