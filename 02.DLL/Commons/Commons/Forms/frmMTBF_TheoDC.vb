Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data

Imports System.Globalization
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.SqlClient
Imports System.Data
Imports Commons.VS.Classes.Admin
Imports System.Windows.Forms

Public Class frmMTBF_TheoDC
    Public adaychuyen(1000000) As String
    Public aTdaychuyen(1000000) As String
    Public loaibaocao As Integer
    Public dem As Integer

    Private Sub frmMTBF_TheoDC_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("Rpttinhthoigiantrungbinh_haimay")
        Commons.Modules.ObjSystems.XoaTable("chon_HETHONG")

    End Sub
    Private Sub frmMTBF_TheoDC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDGVShow(0)
        EnableCboChon()

    End Sub
    Private Sub loadTemp()

        Commons.Modules.ObjSystems.XoaTable("NHOC")
        Commons.Modules.SQLString = "SELECT  CAST('' AS INT) AS STT, dbo.THOI_GIAN_NGUNG_MAY.ms_he_thong as MS_MAY,  dbo.THOI_GIAN_NGUNG_MAY.NGAY, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO, " & _
                "CAST('' AS DATETIME) AS NGAY_KE_TIEP, " & _
                "CASE  " & _
                "WHEN MONTH(NGAY) >= 1 AND MONTH(NGAY) <= 3 THEN '1/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(NGAY) >= 4 AND MONTH(NGAY) <= 6 THEN '2/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(NGAY) >= 7 AND MONTH(NGAY) <= 9 THEN '3/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(NGAY) >= 10 AND MONTH(NGAY) <= 12 THEN '4/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                "END AS QUY, case  " & _
                "WHEN MONTH(NGAY) = 1  THEN '1/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(NGAY) = 2  THEN '2/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                "WHEN MONTH(NGAY) = 3  THEN '3/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 4  THEN '4/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 5  THEN '5/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 6  THEN '6/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 7  THEN '7/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 8  THEN '8/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 9  THEN '9/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 10  THEN '10/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 11  THEN '11/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                 "WHEN MONTH(NGAY) = 12  THEN '12/' + CAST(YEAR(NGAY) AS NVARCHAR(4))  " & _
                "END AS thang,  " & _
               "YEAR(NGAY) AS NAM " & _
                "INTO [DBO].NHOC " & _
                "FROM         HE_THONG INNER JOIN " & _
                        "THOI_GIAN_NGUNG_MAY " & _
                "ON HE_THONG.ms_he_thong = THOI_GIAN_NGUNG_MAY.ms_he_thong INNER JOIN NGUYEN_NHAN_DUNG_MAY  " & _
                "ON THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN " & _
                "WHERE(NGUYEN_NHAN_DUNG_MAY.HU_HONG = 1)  " & _
                "   and  HE_THONG.ms_he_thong in( select ms_he_thong  from   chon_hethong)   " & _
                "ORDER BY THOI_GIAN_NGUNG_MAY.MS_MAY, NGAY, THOI_GIAN_NGUNG_MAY.TU_GIO  "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Dim dtSTT As New DataTable
        Commons.Modules.SQLString = "SELECT * FROM DBO.NHOC ORDER BY MS_MAY , NGAY "
        dtSTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        For STT As Int16 = 0 To dtSTT.Rows.Count - 1
            Commons.Modules.SQLString = "UPDATE DBO.NHOC SET STT='" + STT.ToString + "'" & _
            " WHERE MS_MAY=N'" + dtSTT.Rows(STT)("MS_MAY").ToString + "' AND NGAY = '" & _
            Format(dtSTT.Rows(STT)("NGAY"), "MM/dd/yyyy") + "' AND TU_GIO = '" & _
            Format(dtSTT.Rows(STT)("TU_GIO"), "HH:mm:ss") + "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Next

        Dim dt, dtt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM DBO.NHOC   ORDER BY MS_MAY , NGAY  "))
        Dim rowCount As Integer = dt.Rows.Count
        'Dim ngay As Date

        For i As Integer = 1 To rowCount - 1
            If dt.Rows(i)("MS_MAY").ToString = dt.Rows(i - 1)("MS_MAY").ToString Then

                'ngay = DateAdd(DateInterval.Day, -1, dt.Rows(i)("ngay"))
                Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = '" + Format(dt.Rows(i)("NGAY"), "MM/dd/yyyy").ToString & _
                "' WHERE STT = '" + dt.Rows(i - 1)("STT").ToString + "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            End If
        Next

        dtt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM DBO.NHOC ORDER BY MS_MAY , NGAY "))
        For Each dr As DataRow In dtt.Rows
            If Convert.ToDateTime(dr("NGAY_KE_TIEP").ToString).Date = "#1/1/1900#" Then
                Commons.Modules.SQLString = "UPDATE DBO.NHOC SET NGAY_KE_TIEP = '" + Format(dr("NGAY"), "MM/dd/yyyy").ToString & _
                            "' WHERE STT = '" + dr("STT").ToString + "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            End If
        Next

        Dim obj As New Commons.clsprintnhanvien
        obj.Update_bangngayhuhong()
    End Sub
    Private Sub dgvShow_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvShow.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub


    Private Sub loadDGVShow(ByVal intChon As Int16)
        Dim dt As New DataTable
        Commons.Modules.SQLString = "SELECT  *, CAST('" + intChon.ToString + "' AS BIT) AS CHON  FROM   HE_THONG  ORDER BY TEN_HE_THONG "
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        dt.Columns("chon").ReadOnly = False
        dgvShow.DataSource = dt

        Column1.DataPropertyName = "CHON"
        Column2.DataPropertyName = "MS_HE_THONG"
        Column3.DataPropertyName = "TEN_HE_THONG"
        dgvShow.Columns("CHON").Visible = False
        dgvShow.Columns("MS_HE_THONG").Visible = False
        dgvShow.Columns("TEN_HE_THONG").Visible = False
    End Sub

    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click

        loadDGVShow(1)

    End Sub

    Private Sub btnBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChon.Click

        loadDGVShow(0)

    End Sub

    'Private Sub cboHeThong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        loadDGVShow(0)
    '    Catch ex As Exception
    '    End Try
    '    EnableCboChon()

    'End Sub

    Private Sub EnableCboChon()

        If dgvShow.RowCount > 0 Then
            btnChonAll.Enabled = True
            btnBoChon.Enabled = True
        Else
            btnChonAll.Enabled = False
            btnBoChon.Enabled = False
        End If

    End Sub

    Private Sub tblHeThongChonIn()
        Dim x As Integer
        Dim dt As New DataTable
        Commons.Modules.ObjSystems.XoaTable("chon_HETHONG")
        Commons.Modules.SQLString = "CREATE TABLE [dbo].chon_HETHONG(MS_HE_THONG INT)"
        'commons.Modules.SQLString = "CREATE TABLE [dbo].NHOC_MS_MAY(MS_MAY NVARCHAR(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        x = 0
        For x = 1 To dem
            adaychuyen(x) = ""
        Next
        dem = 0
        x = 0
        For Each dr As DataGridViewRow In dgvShow.Rows
            If dr.Cells("chon").Value.ToString = "True" Then
                x = x + 1
                adaychuyen(x) = dr.Cells("MS_HE_THONG").Value.ToString
                aTdaychuyen(x) = dr.Cells("ten_he_thong").Value.ToString
                dem = dem + 1
                Commons.Modules.SQLString = "INSERT INTO chon_HETHONG(MS_HE_THONG) VALUES(N'" + dr.Cells("MS_HE_THONG").Value.ToString + "')"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            End If
        Next

    End Sub

    Public Sub TinhHeThong(ByVal ngay As Date, ByVal heThong As Int16)
        Commons.Modules.SQLString = "drop table DBO.MAY_HETHONG"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "procMAY_HETHONG", Format(ngay, "MM/dd/yyyy").ToString, heThong.ToString)

        'Try
        '    commons.Modules.SQLString = "CREATE TABLE DBO.MAY_HETHONG (MS_MAY NVARCHAR(30), MS_HE_THONG INT, NGAY DATETIME)"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        'Catch ex As Exception
        'End Try


    End Sub
    Public Sub Xuatexcel_QUy()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'Globals.Sheet1.Range("A1", System.Type.Missing).Value = "05/12/04"
            With ExcelSheets
                .Range("A1:I1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")

                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                If loaibaocao = 1 Then
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB_GIUA_2_LAN_HU_HONG", Commons.Modules.TypeLanguage) ' "THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)"
                Else
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) ' "THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                End If
                .Range("D2:F2").Merge()
                .Cells(2, 4) = "Từ Quý  " & frmReports.tu & "  Đến quý " & frmReports.den
                .Range(.Cells(2, 4), .Cells(2, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 4).Font.Bold = True
                '.Cells(2, 4) = "Đến ngày"
                '.Cells(2, 3) = Me.TUNGAY1
                '.Cells(2, 5) = Me.DENNGAY1
                dt = obj.Getquy_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = "Hệ thống"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                ExcelSheets.Cells(3, 1).Font.Bold = True
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = "Quý" & " " & row("quy")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        'Dim TNgay, DNgay As Date
                        'TNgay = row("TU_NGAY")
                        'DNgay = row("DEN_NGAY")
                        'Try
                        '    dt1 = TinhThoiGianTungBinh(amay(j), TNgay, DNgay)




                        dt1 = obj.Tinhthoigian_baocao(adaychuyen(j), row("quy"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")

                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next

                Next


                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub
    Public Sub Xuatexcel_QUy_tinhthoigiantrungbinh()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'Globals.Sheet1.Range("A1", System.Type.Missing).Value = "05/12/04"
            With ExcelSheets
                .Range("A1:I1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")

                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                If loaibaocao = 1 Then
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB_GIUA_2_LAN_HU_HONG", Commons.Modules.TypeLanguage) ' "THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)"
                Else
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) ' "THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                End If
                .Range("D2:F2").Merge()
                .Cells(2, 4) = "Từ Quý  " & frmReports.tu & "  Đến quý " & frmReports.den
                .Range(.Cells(2, 4), .Cells(2, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 4).Font.Bold = True

                dt = obj.Getquy_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = "Hệ thống"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(3, 1).Font.Bold = True
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = "Quý" & " " & row("quy")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        Dim TNgay, DNgay As Date
                        TNgay = row("TU_NGAY")
                        DNgay = row("DEN_NGAY")
                        Try

                            dt1 = TinhThoiGianTungBinh(adaychuyen(j), TNgay, DNgay)
                        Catch ex As Exception
                            dt1 = obj.Baocao_Tinhthoigiantrungbinh_quy(adaychuyen(j), row("quy"))
                        End Try

                        'dt1 = obj.Baocao_Tinhthoigiantrungbinh_quy(adaychuyen(j), row("quy"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")

                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next

                Next


                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 0)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub
    Public Sub Xuatexcel_thang()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Integer
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            With ExcelSheets
                .Range("A1:I1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("K")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("L")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("M")
                colums.ColumnWidth = 15
                If loaibaocao = 1 Then
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB_GIUA_2_LAN_HU_HONG", Commons.Modules.TypeLanguage) ' "THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)"
                Else
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) ' "THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                End If
                .Range("D2:F2").Merge()
                .Cells(2, 4) = "Từ tháng  " & frmReports.tu & "  Đến tháng " & frmReports.den
                .Range(.Cells(2, 4), .Cells(2, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 4).Font.Bold = True
                '.Range("A2:B2").Merge()
                '.Cells(2, 2) = "Từ ngày"
                '.Cells(2, 4) = "Đến ngày"
                '.Cells(2, 3) = Me.TUNGAY1
                '.Cells(2, 5) = Me.DENNGAY1
                dt = obj.Getthang_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = "Hệ thống"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                ExcelSheets.Cells(3, 1).Font.Bold = True
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = "Tháng" & " " & row("thang")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        dt1 = obj.Tinhthoigianbythang(adaychuyen(j), row("thang"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")
                            '  tong = tong + thoigian
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next


                Next

                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub
    Public Sub Xuatexcel_thang_tinhthoigiantrungbinh()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim tong As Integer
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'ExcelApp.Cells.ColumnWidth = 15

            ExcelApp.Cells.ColumnWidth = 15



            With ExcelSheets
                .Range("A1:I1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A1:F1").Font.Bold = True
                If loaibaocao = 1 Then
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB_GIUA_2_LAN_HU_HONG", Commons.Modules.TypeLanguage) ' "THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)"
                Else
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) ' "THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                End If
                .Range("D2:F2").Merge()
                .Cells(2, 4) = "Từ tháng  " & frmReports.tu & "  Đến tháng " & frmReports.den
                .Range(.Cells(2, 4), .Cells(2, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 4).Font.Bold = True
                dt = obj.Getthang_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = "Hệ thống"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                ExcelSheets.Cells(3, 1).Font.Bold = True
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = "Tháng" & " " & row("thang")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        Try
                            Dim TNgay, DNgay, Thang As Date
                            Thang = Convert.ToDateTime(row("thang").ToString)
                            TNgay = Thang
                            DNgay = TNgay.AddMonths(1).AddDays(-1)
                            dt1 = TinhThoiGianTungBinh(adaychuyen(j), TNgay, DNgay)
                        Catch ex As Exception
                            dt1 = obj.Baocao_Tinhthoigiantrungbinh_thang(adaychuyen(j), row("thang"))
                        End Try

                        'dt1 = obj.Baocao_Tinhthoigiantrungbinh_thang(adaychuyen(j), row("thang"))

                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")
                            Commons.Modules.MExcel.ColumnWidth(ExcelSheets, 15, "@", True, k, 1, k, 1)
                            '  tong = tong + thoigian
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = ""
                            Commons.Modules.MExcel.ColumnWidth(ExcelSheets, 15, "@", True, k, 1, k, 1)
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next


                Next

                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 0)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub
    Public Sub xuat_excelnam()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'Globals.Sheet1.Range("A1", System.Type.Missing).Value = "05/12/04"
            With ExcelSheets
                .Range("A1:F1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")

                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                If loaibaocao = 1 Then
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB_GIUA_2_LAN_HU_HONG", Commons.Modules.TypeLanguage) ' "THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)"
                Else
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) ' "THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                End If
                .Range("A2:D2").Merge()
                .Cells(2, 2) = "Từ năm  " & frmReports.tu & "  Đến năm " & frmReports.den
                .Range(.Cells(2, 2), .Cells(2, 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 2).Font.Bold = True
                '.Cells(2, 4) = "Đến ngày"
                '.Cells(2, 3) = Me.TUNGAY1
                '.Cells(2, 5) = Me.DENNGAY1
                dt = obj.Getnam_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = "Hệ thống"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                ExcelSheets.Cells(3, 1).Font.Bold = True
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = "Năm" & " " & row("nam")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True

                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        dt1 = obj.Tinhthoigianbaocaobynam(adaychuyen(j), row("nam"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")

                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If

                    Next

                Next


                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1

                            End If
                        End If

                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 2)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub
    Public Sub xuat_excelnam_tinhthoigiantrungbinh()
        Try
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable
            Dim colums As Excel.Range
            Dim tong As Double
            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            'Globals.Sheet1.Range("A1", System.Type.Missing).Value = "05/12/04"
            With ExcelSheets
                .Range("A1:F1").Merge()

                .Range("A1:F1").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                .Range("A1:F1").Font.Bold = True
                colums = ExcelSheets.Columns("A")

                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("H")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("I")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("J")
                colums.ColumnWidth = 15
                If loaibaocao = 1 Then
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB_GIUA_2_LAN_HU_HONG", Commons.Modules.TypeLanguage) ' "THỜI GIAN TRUNG BÌNH GIỮA HAI LẦN HƯ HỎNG (ngày)"
                Else
                    .Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_SUA_CHUA_TB", "THOI_GIAN_SUA_CHUA_TB", Commons.Modules.TypeLanguage) ' "THỜI GIAN SỬA CHỮA TRUNG BÌNH"
                End If
                .Range("A2:D2").Merge()
                .Cells(2, 1) = "Từ năm  " & frmReports.tu & "  Đến năm " & frmReports.den
                .Range(.Cells(2, 1), .Cells(2, 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(2, 1).Font.Bold = True
                dt = obj.Getnam_baocao()
                Dim row As DataRow
                Dim i As Integer
                Dim j As Integer
                j = 1
                .Cells(3, 1) = "Hệ thống"
                .Range(.Cells(3, 1), .Cells(3, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range(.Cells(3, 1), .Cells(3, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ExcelSheets.Cells(3, 1).Font.Bold = True
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    row = dt.Rows(i)
                    .Cells(3, j) = "Năm" & " " & row("nam")
                    .Range(.Cells(3, j), .Cells(3, j)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(3, j), .Cells(3, j)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(3, j).Font.Bold = True
                    '.Range("D2:E2").Merge()
                Next
                Dim l As Integer
                Dim dt1 As New DataTable
                Dim row1 As DataRow
                Dim k As Integer
                l = 1
                k = 3
                For j = 1 To dem
                    k = k + 1
                    l = 1
                    For i = 0 To dt.Rows.Count - 1
                        l = l + 1

                        row = dt.Rows(i)
                        Dim Thang, TNgay, DNgay As Date
                        Thang = Convert.ToDateTime("01/01/" + row("nam").ToString)
                        TNgay = Thang
                        DNgay = TNgay.AddYears(1).AddDays(-1)
                        Try
                            dt1 = TinhThoiGianTungBinh(adaychuyen(j), TNgay, DNgay)

                        Catch ex As Exception
                            ' Neu loi chay code cu
                            dt1 = obj.Baocao_Tinhthoigiantrungbinh_nam(adaychuyen(j), row("nam"))
                        End Try
                        'dt1 = obj.Baocao_Tinhthoigiantrungbinh_nam(adaychuyen(j), row("nam"))
                        If dt1.Rows.Count > 0 Then
                            row1 = dt1.Rows(0)
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = row1("thoigian")
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Else
                            ExcelSheets.Cells(k, 1).value = aTdaychuyen(j)
                            ExcelSheets.Cells(k, l).value = ""
                            .Range(.Cells(k, l), .Cells(k, l)).ColumnWidth = 15
                            .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, l), .Cells(k, l)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(k, l), .Cells(k, l)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End If
                    Next
                Next


                k = k + 1
                Dim tongtruoc As Double
                Dim biendem As Integer
                For i = 2 To dt.Rows.Count + 1
                    tong = 0
                    biendem = 0
                    For l = 4 To dem + 5
                        If IsDBNull(ExcelSheets.Cells(l, i).value) = False Then
                            tongtruoc = tong
                            tong = tong + ExcelSheets.Cells(l, i).value
                            If tong > tongtruoc Then
                                biendem = biendem + 1
                            End If
                        End If
                    Next
                    If tong <> 0 Then
                        ExcelSheets.Cells(k, i).value = Math.Round(tong / biendem, 0)
                    End If
                    .Range(.Cells(k, i), .Cells(k, i)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, i), .Cells(k, i)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range(.Cells(k, 1), .Cells(k, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(k, 1), .Cells(k, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    ExcelSheets.Cells(k, i).Font.Bold = True
                Next

            End With
            ExcelApp.Visible = True
            'ExcelApp.ActiveCell.Worksheet.SaveAs("c:\tu12.xls")
        Catch
        End Try
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'TinhHeThong("01/03/2008", 3)
        '   Dim frmrpt As New frmReports
        If loaibaocao = 1 Then
            tblHeThongChonIn()
            loadTemp()

            ' Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Select Case frmReports.baocao
                Case 0

                    Xuatexcel_thang()
                    'ReportPreview("reports\rptMTBF_MAY.rpt")
                    'Me.Cursor = Cursors.Default
                Case 1
                    Xuatexcel_QUy()

                    'ReportPreview("reports\rptMTBF_MAY_NAM.rpt")
                    ' Me.Cursor = Cursors.Default
                Case 2
                    xuat_excelnam()
                    '  ReportPreview("reports\RPTMTBF_THANG.rpt")
                    ' Me.Cursor = Cursors.Default
            End Select
        Else
            Commons.Modules.ObjSystems.XoaTable("Rpttinhthoigiantrungbinh_haimay")
            tblHeThongChonIn()
            Dim obj As New Commons.clsprintnhanvien
            obj.Rpttinhthoigiantrungbinh_byDC()
            ' Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Select Case frmReports.baocao
                Case 0

                    Xuatexcel_thang_tinhthoigiantrungbinh()
                    'ReportPreview("reports\rptMTBF_MAY.rpt")
                    'Me.Cursor = Cursors.Default
                Case 1
                    Xuatexcel_QUy_tinhthoigiantrungbinh()

                    'ReportPreview("reports\rptMTBF_MAY_NAM.rpt")
                    ' Me.Cursor = Cursors.Default
                Case 2
                    xuat_excelnam_tinhthoigiantrungbinh()
                    '  ReportPreview("reports\RPTMTBF_THANG.rpt")
                    ' Me.Cursor = Cursors.Default
            End Select
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub createTblNGAY_HU_HONG_HT()
        Commons.Modules.SQLString = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NGAY_HU_HONG_HT" + Commons.Modules.UserName + "]') AND type in (N'U')) " & _
                "DROP TABLE [dbo].[NGAY_HU_HONG_HT" + Commons.Modules.UserName + "] " & _
                "CREATE TABLE [dbo].[NGAY_HU_HONG_HT" + Commons.Modules.UserName + "]( " & _
                 "[NGAY] [datetime] NOT NULL, " & _
                 "[MS_HE_THONG] [int] NOT NULL, " & _
                 "CONSTRAINT [PK_NGAY_HU_HONG_HT] PRIMARY KEY CLUSTERED  " & _
                "(	[NGAY] ASC, " & _
                        "[MS_HE_THONG] Asc " & _
                ")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY] " & _
                ") ON [PRIMARY]"
        SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub

    Private Function createTblNGAY() As String
        Commons.Modules.SQLString = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NGAY" + Commons.Modules.UserName + "]') AND type in (N'U')) " & _
            "DROP TABLE [dbo].[NGAY" + Commons.Modules.UserName + "] " & _
            "CREATE TABLE [dbo].[NGAY" + Commons.Modules.UserName + "]( " & _
             "[TU_NGAY] [datetime] NOT NULL, " & _
             "[DEN_NGAY] [datetime] NULL, " & _
             "[MS_HE_THONG] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, " & _
             "CONSTRAINT [PK_NGAY] PRIMARY KEY CLUSTERED  " & _
            "( " & _
             "[TU_NGAY] ASC, " & _
                    "[MS_HE_THONG] Asc " & _
            ")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY] " & _
            ") ON [PRIMARY]"
        SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Return "NGAY" + Commons.Modules.UserName

    End Function

    Private Function createTblNGAY_HE_THONG() As String

        Commons.Modules.SQLString = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NGAY_HETHONG" + Commons.Modules.UserName + "]') AND type in (N'U')) " & _
            "DROP TABLE [dbo].[NGAY_HETHONG" + Commons.Modules.UserName + "] " & _
            "CREATE TABLE [dbo].[NGAY_HETHONG" + Commons.Modules.UserName + "]( " & _
             "[TU_NGAY] [datetime] NOT NULL, " & _
             "[DEN_NGAY] [datetime] NULL, " & _
             "[MS_MAY] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, " & _
             "[MS_HE_THONG] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, " & _
             "CONSTRAINT [PK_NGAY_HE_THONG2] PRIMARY KEY CLUSTERED  " & _
            "(	[TU_NGAY] ASC, " & _
             "[MS_MAY] ASC, " & _
                    "[MS_HE_THONG] Asc " & _
            ")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY] " & _
            ") ON [PRIMARY]"
        SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Return "NGAY_HETHONG" + Commons.Modules.UserName

    End Function


    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Function TinhThoiGianTungBinh(ByVal iMsHThong As Integer, ByVal TNgay As Date, ByVal DNgay As Date) As System.Data.DataTable

        Dim dtTmp As System.Data.DataTable = New System.Data.DataTable
        Dim sTmp As String
        Try

            sTmp = " SELECT CONVERT(INT,ROUND(SUM(THOI_GIAN_SUA_CHUA) /  CASE COUNT(DISTINCT MS_LAN) " & _
                " WHEN 0 THEN 1 ELSE COUNT(DISTINCT MS_LAN) END,0)) AS thoigian FROM dbo.THOI_GIAN_NGUNG_MAY A " & _
                " WHERE     (NGAY BETWEEN  '" + TNgay.ToString("yyyyMMdd") + "' AND '" + DNgay.ToString("yyyyMMdd") + "' ) " & _
                " AND (MS_HE_THONG = " + iMsHThong.ToString + ")"
            dtTmp = New System.Data.DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp))
            Return dtTmp
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


End Class