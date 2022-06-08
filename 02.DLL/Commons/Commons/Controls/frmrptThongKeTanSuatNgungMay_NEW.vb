
Imports Commons.VS.Classes.Catalogue
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient

Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptThongKeTanSuatNgungMay_NEW
    Dim v_all As DataTable = New DataTable()
    Dim vtbNx As DataTable = New DataTable()

    Private Sub btThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click, btnThucHien.Click
        If dtTu.Value > dtDen.Value Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeTanSuatNgungMay_NEW", "TNPhaiNhoHonDN", Commons.Modules.TypeLanguage))
            dtTu.Focus()
            Exit Sub
        End If
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vRow As Integer = 2
            Dim vRowSum As Integer = 2
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            Dim cander As System.Globalization.GregorianCalendar = New System.Globalization.GregorianCalendar()
            ExcelApp.Visible = False
            ExcelApp.Visible = True

            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            Dim vFlag As Boolean = False
            Dim vTheo As String = ""
            If (rdoNgay.Checked) Then
                vTheo = "THEO NGÀY"
            Else
                If (rdoTuan.Checked) Then
                    vTheo = "THEO TUẦN"
                Else
                    If rdoThang.Checked Then
                        vTheo = "THEO THÁNG"
                    Else
                        If rdoQuy.Checked Then
                            vTheo = "THEO QUÝ"
                        Else
                            vTheo = "THEO NĂM"
                        End If
                    End If
                End If
            End If
            With ExcelSheets
                .Columns(1).ColumnWidth = 15
                .Columns(2).ColumnWidth = 15
                .Columns(2).ColumnWidth = 20

                .Range("A2:H2").Merge()
                .Range("A2:H2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A2:H2").Font.Bold = True
                .Cells(vRow, 1).Font.Color = RGB(255, 0, 128)
                .Cells(vRow, 1).Font.Size = 13
                .Cells(vRow, 1) = "TẦN SUẤT DỪNG MÁY " & vTheo + " (LẦN)"
                vRow = vRow + 1

                .Range("B2:C2").Merge()
                .Range("B2:C2").Font.Italic = True
                .Range("B2:C2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 2) = "Từ ngày :" & dtTu.Value.ToShortDateString().Trim()
                .Range("D2:E2").Merge()
                .Range("D2:E2").Font.Italic = True
                .Range("D2:E2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(vRow, 3) = "Đến ngày :" & dtDen.Value.ToShortDateString().Trim()

                vRow = vRow + 2

            End With
            Dim vTablemay As DataTable = New DataTable()
            Dim count As Integer = vtbNx.Rows.Count

            If count > 0 Then
                For j As Integer = 0 To count - 1
                    Dim vList As ArrayList = New ArrayList()
                    ' If Convert.ToBoolean(gvNhaxuong.Rows(j).Cells("clChonnhaxuong").Value) Then
                    With ExcelSheets
                        .Cells(vRow, 1).Font.Bold = True
                        .Cells(vRow, 1).Font.Color = RGB(255, 0, 0)
                        .Cells(vRow, 1).Font.Size = 12
                        .Cells(vRow, 1) = vtbNx.Rows(j)("Ten_n_Xuong")
                        vRow = vRow + 1
                        vRowSum = vRow
                    End With
                    For i As Integer = 0 To gvNguyennhan.Rows.Count - 1
                        If Convert.ToBoolean(gvNguyennhan.Rows(i).Cells("clChonnguyennhan").Value) Then
                            With ExcelSheets
                                .Cells(vRow, 2).Font.Bold = True
                                .Cells(vRow, 2).Font.Color = RGB(168, 12, 128)
                                .Cells(vRow, 2).Font.Size = 11
                                .Cells(vRow, 2) = gvNguyennhan.Rows(i).Cells("clNguyennhan").Value.ToString().Trim()
                                vRow = vRow + 1
                            End With
                            vTablemay = New DataTable()
                            Dim strmay As String = " SELECT  DISTINCT   dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.MAY.TEN_MAY " & _
                                   " FROM         dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " & _
                                   " dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY  AND dbo.THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " "
                            ' vTablemay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strmay))

                            Dim vsMayselect As String = ""

                            For Each vrowmay As DataRow In vtbDsMayChon.Rows
                                If vsMayselect = "" Then
                                    vsMayselect = "'" + vrowmay("MS_MAY") + "'"
                                Else
                                    vsMayselect = vsMayselect + ", '" + vrowmay("MS_MAY") + "'"
                                End If
                            Next

                            Dim vStr As String = "SELECT * FROM (" + strmay + ")TMP WHERE TMP.MS_MAY IN (" + vsMayselect + ")"

                            If chxChonTheoMay.Checked = True Then
                                vTablemay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStr))
                            Else
                                vTablemay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strmay))
                            End If



                            Dim vColum As Integer = 2
                            If (rdoNgay.Checked) Then

                                With ExcelSheets
                                    .Cells(vRow, vColum).Font.Bold = True
                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                    .Cells(vRow, vColum) = "Máy"
                                    vColum = vColum + 1
                                    Dim vNgay As Date = dtTu.Value
                                    While vNgay < dtDen.Value
                                        If (Not vFlag) Then
                                            .Columns(vColum).ColumnWidth = 12
                                        End If
                                        .Cells(vRow, vColum).Font.Bold = True
                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                        .Cells(vRow, vColum) = "'" + vNgay.ToShortDateString().Trim()
                                        vColum = vColum + 1
                                        vNgay = vNgay.AddDays(1)
                                    End While

                                    vFlag = True

                                    For k As Integer = 0 To vTablemay.Rows.Count - 1
                                        vColum = 2
                                        .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                        .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("TEN_MAY").ToString().Trim()
                                        vNgay = dtTu.Value
                                        vColum = vColum + 1
                                        While vNgay < dtDen.Value
                                            Dim tbTb As DataTable = New DataTable()
                                            Dim strss As String = "SELECT     COUNT(*) AS TG_DUNG FROM         dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.THOI_GIAN_NGUNG_MAY_SO_LAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY = '" & vNgay.ToString("MM/dd/yyyy") & "' GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                            tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                            Try
                                                .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow + k + 1, vColum) = tbTb.Rows(0)("TG_DUNG").ToString().Trim()
                                            Catch ex As Exception
                                            End Try
                                            vColum = vColum + 1
                                            vNgay = vNgay.AddDays(1)
                                        End While
                                    Next
                                    If vTablemay.Rows.Count > 0 Then
                                        vNgay = dtTu.Value
                                        vColum = 3
                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2) = "Tổng theo nguyên nhân"
                                        While vNgay < dtDen.Value
                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                            If (vColum > 2) Then
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                            End If
                                            vColum = vColum + 1
                                            vNgay = vNgay.AddDays(1)
                                        End While
                                        vList.Add(vRow + vTablemay.Rows.Count + 1)
                                    End If
                                End With
                            Else
                                If (rdoThang.Checked) Then
                                    With ExcelSheets
                                        .Cells(vRow, vColum).Font.Bold = True
                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                        .Cells(vRow, vColum) = "Máy"
                                        vColum = vColum + 1
                                        Dim vNgay As Date = dtTu.Value
                                        While vNgay.Year <= dtDen.Value.Year
                                            If vNgay.Year = dtDen.Value.Year Then
                                                If (vNgay.Month <= dtDen.Value.Month) Then
                                                    If (Not vFlag) Then
                                                        .Columns(vColum).ColumnWidth = 12
                                                    End If
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow, vColum) = vNgay.Month.ToString() & "/" & vNgay.Year.ToString()
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddMonths(1)
                                                Else
                                                    Exit While
                                                End If
                                            Else
                                                If (Not vFlag) Then
                                                    .Columns(vColum).ColumnWidth = 12
                                                End If
                                                .Cells(vRow, vColum).Font.Bold = True
                                                .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow, vColum) = vNgay.Month.ToString() & "/" & vNgay.Year.ToString()
                                                vColum = vColum + 1
                                                vNgay = vNgay.AddMonths(1)
                                            End If

                                        End While

                                        vFlag = True

                                        For k As Integer = 0 To vTablemay.Rows.Count - 1
                                            vColum = 2
                                            .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("TEN_MAY").ToString().Trim()
                                            vNgay = dtTu.Value
                                            vColum = vColum + 1
                                            While vNgay.Year <= dtDen.Value.Year
                                                Dim tbTb As DataTable = New DataTable()
                                                If vNgay.Year = dtDen.Value.Year Then
                                                    If (vNgay.Month <= dtDen.Value.Month) Then
                                                        Dim strss As String = "SELECT     COUNT(*) AS TG_DUNG FROM  dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.THOI_GIAN_NGUNG_MAY_SO_LAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Month & " AND YEAR (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Year & ") GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                        tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                        Try
                                                            .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + k + 1, vColum) = tbTb.Rows(0)("TG_DUNG").ToString().Trim()
                                                        Catch ex As Exception
                                                        End Try
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddMonths(1)
                                                    Else
                                                        Exit While
                                                    End If
                                                Else
                                                    Dim strss As String = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.THOI_GIAN_NGUNG_MAY_SO_LAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Month & " AND YEAR (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Year & ") GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                    tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                    Try
                                                        .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + k + 1, vColum) = tbTb.Rows(0)("TG_DUNG").ToString().Trim()
                                                    Catch ex As Exception
                                                    End Try
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddMonths(1)
                                                End If

                                            End While
                                        Next
                                        If vTablemay.Rows.Count > 0 Then
                                            vNgay = dtTu.Value
                                            vColum = 3
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                            .Cells(vRow + vTablemay.Rows.Count + 1, 2) = "Tổng theo nguyên nhân"
                                            While vNgay.Year <= dtDen.Value.Year
                                                If (vNgay.Year = dtDen.Value.Year And vNgay.Month > dtDen.Value.Month) Then
                                                    Exit While
                                                End If
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                If (vColum > 2) Then
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                End If
                                                vColum = vColum + 1
                                                vNgay = vNgay.AddMonths(1)
                                            End While
                                            vList.Add(vRow + vTablemay.Rows.Count + 1)
                                        End If
                                    End With
                                Else
                                    If rdoQuy.Checked Then
                                        With ExcelSheets
                                            .Cells(vRow, vColum).Font.Bold = True
                                            .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                            .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                            .Cells(vRow, vColum) = "Máy"
                                            vColum = vColum + 1

                                            Dim vNgay As Date = dtTu.Value
                                            Dim vMaxMonth As Integer = -1
                                            If (dtDen.Value.Month > 9) Then
                                                vMaxMonth = 12
                                            Else
                                                If (dtDen.Value.Month > 6) Then
                                                    vMaxMonth = 9
                                                Else
                                                    If (dtDen.Value.Month > 3) Then
                                                        vMaxMonth = 6
                                                    Else
                                                        vMaxMonth = 3
                                                    End If
                                                End If
                                            End If

                                            While vNgay.Year <= dtDen.Value.Year
                                                If (vNgay.Year = dtDen.Value.Year And vNgay.Month > vMaxMonth) Then
                                                    Exit While
                                                End If
                                                If (Not vFlag) Then
                                                    .Columns(vColum).ColumnWidth = 12
                                                End If
                                                .Cells(vRow, vColum).Font.Bold = True
                                                .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                If (vNgay.Month > 9) Then
                                                    .Cells(vRow, vColum) = "IV/" & vNgay.Year.ToString()
                                                Else
                                                    If (vNgay.Month > 6) Then
                                                        .Cells(vRow, vColum) = "III/" & vNgay.Year.ToString()
                                                    Else
                                                        If (vNgay.Month > 3) Then
                                                            .Cells(vRow, vColum) = "II/" & vNgay.Year.ToString()
                                                        Else
                                                            .Cells(vRow, vColum) = "I/" & vNgay.Year.ToString()
                                                        End If
                                                    End If
                                                End If
                                                vColum = vColum + 1
                                                vNgay = vNgay.AddMonths(3)
                                            End While
                                            vFlag = True
                                            For k As Integer = 0 To vTablemay.Rows.Count - 1
                                                vColum = 2
                                                .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("TEN_MAY").ToString().Trim()
                                                vNgay = dtTu.Value
                                                vColum = vColum + 1
                                                While vNgay.Year <= dtDen.Value.Year
                                                    Dim tbTb As DataTable = New DataTable()
                                                    Dim strss As String = ""
                                                    'If (vNgay.Year = dtDen.Value.Year And vNgay.Month >= dtDen.Value.AddMonths(2).Month) Then
                                                    '    Exit While
                                                    'End If
                                                    If (vNgay.Year = dtDen.Value.Year And vNgay.Month > vMaxMonth) Then
                                                        Exit While
                                                    End If
                                                    If (vNgay.Month > 9) Then
                                                        strss = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY_SO_LAN INNER JOIN dbo.THOI_GIAN_NGUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) >= 10 AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) <= 12 AND YEAR (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Year & ") GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                    Else
                                                        If (vNgay.Month > 6) Then
                                                            strss = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY_SO_LAN INNER JOIN dbo.THOI_GIAN_NGUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) >= 7 AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) <= 9 AND YEAR (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Year & ") GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                        Else
                                                            If (vNgay.Month > 3) Then
                                                                strss = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY_SO_LAN INNER JOIN dbo.THOI_GIAN_NGUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) >= 3 AND  MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) <= 6 AND YEAR (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Year & ") GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                            Else
                                                                strss = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY_SO_LAN INNER JOIN dbo.THOI_GIAN_NGUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND ( THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND MONTH (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) <= 2 AND YEAR (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Year & ") GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                            End If
                                                        End If
                                                    End If

                                                    tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                    Try
                                                        .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + k + 1, vColum) = tbTb.Rows(0)("TG_DUNG").ToString().Trim()
                                                    Catch ex As Exception
                                                    End Try
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddMonths(3)

                                                End While
                                            Next
                                            If vTablemay.Rows.Count > 0 Then
                                                vNgay = dtTu.Value
                                                vColum = 3
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                                .Cells(vRow + vTablemay.Rows.Count + 1, 2) = "Tổng theo nguyên nhân"
                                                While vNgay.Year <= dtDen.Value.Year
                                                    'If (vNgay.Year = dtDen.Value.Year And vNgay.Month >= dtDen.Value.AddMonths(2).Month) Then
                                                    '    Exit While
                                                    'End If
                                                    If (vNgay.Year = dtDen.Value.Year And vNgay.Month > vMaxMonth) Then
                                                        Exit While
                                                    End If
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                    If (vColum > 2) Then
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                    End If
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddMonths(3)
                                                End While
                                                vList.Add(vRow + vTablemay.Rows.Count + 1)
                                            End If
                                        End With
                                    Else
                                        If rdoNam.Checked Then
                                            With ExcelSheets
                                                .Cells(vRow, vColum).Font.Bold = True
                                                .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                .Cells(vRow, vColum) = "Máy"
                                                vColum = vColum + 1
                                                Dim vNgay As Date = dtTu.Value
                                                While vNgay.Year <= dtDen.Value.Year
                                                    If (Not vFlag) Then
                                                        .Columns(vColum).ColumnWidth = 12
                                                    End If
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow, vColum) = vNgay.Year.ToString()
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddYears(1)
                                                End While

                                                vFlag = True

                                                For k As Integer = 0 To vTablemay.Rows.Count - 1
                                                    vColum = 2
                                                    .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("TEN_MAY").ToString().Trim()
                                                    vNgay = dtTu.Value
                                                    vColum = vColum + 1
                                                    While vNgay.Year <= dtDen.Value.Year
                                                        Dim tbTb As DataTable = New DataTable()
                                                        Dim strss As String = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.THOI_GIAN_NGUNG_MAY_SO_LAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "' AND (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & dtTu.Value.ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY < '" & dtDen.Value.ToString("MM/dd/yyyy") & "' AND YEAR (THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY) = " & vNgay.Year & ") GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                        tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                        Try
                                                            .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + k + 1, vColum) = tbTb.Rows(0)("TG_DUNG").ToString().Trim()
                                                        Catch ex As Exception
                                                        End Try
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddYears(1)
                                                    End While
                                                Next
                                                If vTablemay.Rows.Count > 0 Then
                                                    vNgay = dtTu.Value
                                                    vColum = 3
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                                    .Cells(vRow + vTablemay.Rows.Count + 1, 2) = "Tổng theo nguyên nhân"
                                                    While vNgay.Year <= dtDen.Value.Year
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                        If (vColum > 2) Then
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                        End If
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddYears(1)
                                                    End While
                                                    vList.Add(vRow + vTablemay.Rows.Count + 1)
                                                End If
                                            End With

                                        Else
                                            If rdoTuan.Checked Then
                                                With ExcelSheets
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                    .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                    .Cells(vRow, vColum) = "Máy"
                                                    vColum = vColum + 1
                                                    Dim vNgay As Date = dtTu.Value
                                                    While vNgay <= dtDen.Value
                                                        If (Not vFlag) Then
                                                            .Columns(vColum).ColumnWidth = 12
                                                        End If
                                                        .Cells(vRow, vColum).Font.Bold = True
                                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                                        .Cells(vRow, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow, vColum) = cander.GetWeekOfYear(vNgay, CalendarWeekRule.FirstDay, DayOfWeek.Friday).ToString() & "(" & vNgay.Year.ToString() & ")"
                                                        vColum = vColum + 1
                                                        vNgay = vNgay.AddDays(7)
                                                    End While

                                                    vFlag = True

                                                    For k As Integer = 0 To vTablemay.Rows.Count - 1
                                                        vColum = 2
                                                        .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + k + 1, vColum) = "(" & vTablemay.Rows(k)("MS_MAY").ToString().Trim() & ")" & vTablemay.Rows(k)("TEN_MAY").ToString().Trim()
                                                        vNgay = dtTu.Value
                                                        vColum = vColum + 1
                                                        While vNgay <= dtDen.Value
                                                            Dim tbTb As DataTable = New DataTable()
                                                            'Dim strss As String = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.THOI_GIAN_NGUNG_MAY_SO_LAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "'  AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & vNgay.AddDays(-Weekday(vNgay)).ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY <= '" & vNgay.AddDays(-Weekday(vNgay)).AddDays(7).ToString("MM/dd/yyyy") & "' GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                            Dim strss As String = "SELECT     COUNT(*) AS TG_DUNG FROM dbo.THOI_GIAN_NGUNG_MAY INNER JOIN dbo.THOI_GIAN_NGUNG_MAY_SO_LAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN WHERE THOI_GIAN_NGUNG_MAY.MS_N_XUONG = '" & vtbNx.Rows(j)("MS_N_XUONG") & "' AND  dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = " & gvNguyennhan.Rows(i).Cells("clMsnguyennhan").Value & " AND THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY = '" & vTablemay.Rows(k)("MS_MAY") & "'  AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY >= '" & vNgay.AddDays(-Weekday(vNgay)).ToString("MM/dd/yyyy") & "' AND THOI_GIAN_NGUNG_MAY_SO_LAN.NGAY <= '" & vNgay.AddDays(-Weekday(vNgay)).AddDays(7).ToString("MM/dd/yyyy") & "' GROUP BY THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY "
                                                            tbTb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strss))
                                                            Try
                                                                .Cells(vRow + k + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                                .Cells(vRow + k + 1, vColum) = tbTb.Rows(0)("TG_DUNG").ToString().Trim()
                                                            Catch ex As Exception
                                                            End Try
                                                            vColum = vColum + 1
                                                            vNgay = vNgay.AddDays(7)
                                                        End While
                                                    Next
                                                    If vTablemay.Rows.Count > 0 Then
                                                        vNgay = dtTu.Value
                                                        vColum = 3
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Bold = True
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2).Font.Color = RGB(168, 12, 128)
                                                        .Cells(vRow + vTablemay.Rows.Count + 1, 2) = "Tổng theo nguyên nhân"
                                                        While vNgay <= dtDen.Value
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Bold = True
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                                                            .Cells(vRow + vTablemay.Rows.Count + 1, vColum).Font.Color = RGB(168, 12, 128)
                                                            If (vColum > 2) Then
                                                                .Cells(vRow + vTablemay.Rows.Count + 1, vColum) = "=SUM(" & .Cells(vRow + 1, vColum).Address.ToString() & ":" & .Cells(vRow + vTablemay.Rows.Count, vColum).Address.ToString() & ")"
                                                            End If
                                                            vColum = vColum + 1
                                                            vNgay = vNgay.AddDays(7)
                                                        End While
                                                        vList.Add(vRow + vTablemay.Rows.Count + 1)
                                                    End If
                                                End With
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            vRow = vRow + vTablemay.Rows.Count + 2
                        End If
                    Next i
                    With ExcelSheets
                        Dim vNgay As Date = dtTu.Value
                        Dim vColum As Integer = 3
                        If vList.Count > 0 Then
                            If (rdoNgay.Checked) Then
                                .Cells(vRow, 2).Font.Bold = True
                                .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                .Cells(vRow, 2) = "Tổng theo nhà xưởng"
                                While vNgay < dtDen.Value
                                    .Cells(vRow, vColum).Font.Bold = True
                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                    If (vColum > 2) Then
                                        Dim vSum As String = ""
                                        For n As Integer = 0 To vList.Count - 1
                                            vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                        Next
                                        If vList.Count > 0 Then
                                            .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                        End If
                                    End If
                                    vColum = vColum + 1
                                    vNgay = vNgay.AddDays(1)
                                End While
                            Else
                                If rdoThang.Checked Then
                                    .Cells(vRow, 2).Font.Bold = True
                                    .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                    .Cells(vRow, 2) = "Tổng theo nhà xưởng"
                                    While vNgay.Year <= dtDen.Value.Year
                                        If (vNgay.Year = dtDen.Value.Year And vNgay.Month > dtDen.Value.Month) Then
                                            Exit While
                                        End If
                                        .Cells(vRow, vColum).Font.Bold = True
                                        .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                        .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                        If (vColum > 2) Then
                                            Dim vSum As String = ""
                                            Dim vRowTMP As Integer = vRowSum
                                            For n As Integer = 0 To vList.Count - 1
                                                vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                            Next
                                            If vList.Count > 0 Then
                                                .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                            End If
                                        End If
                                        vColum = vColum + 1
                                        vNgay = vNgay.AddMonths(1)
                                    End While
                                Else
                                    If rdoQuy.Checked Then
                                        Dim vMaxMonth As Integer = -1
                                        If (dtDen.Value.Month > 9) Then
                                            vMaxMonth = 12
                                        Else
                                            If (dtDen.Value.Month > 6) Then
                                                vMaxMonth = 9
                                            Else
                                                If (dtDen.Value.Month > 3) Then
                                                    vMaxMonth = 6
                                                Else
                                                    vMaxMonth = 3
                                                End If
                                            End If
                                        End If
                                        .Cells(vRow, 2).Font.Bold = True
                                        .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                        .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                        .Cells(vRow, 2) = "Tổng theo nhà xưởng"
                                        While vNgay.Year <= dtDen.Value.Year
                                            'If (vNgay.Year = dtDen.Value.Year And vNgay.Month >= dtDen.Value.AddMonths(2).Month) Then
                                            '    Exit While
                                            'End If
                                            If (vNgay.Year = dtDen.Value.Year And vNgay.Month >= vMaxMonth) Then
                                                Exit While
                                            End If
                                            .Cells(vRow, vColum).Font.Bold = True
                                            .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                            .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                            If (vColum > 2) Then
                                                Dim vSum As String = ""
                                                Dim vRowTMP As Integer = vRowSum
                                                For n As Integer = 0 To vList.Count - 1
                                                    vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                                Next
                                                If vList.Count > 0 Then
                                                    .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                                End If
                                            End If
                                            vColum = vColum + 1
                                            vNgay = vNgay.AddMonths(3)
                                        End While
                                    Else
                                        If rdoNam.Checked Then
                                            .Cells(vRow, 2).Font.Bold = True
                                            .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                            .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                            .Cells(vRow, 2) = "Tổng theo nhà xưởng"
                                            While vNgay.Year <= dtDen.Value.Year
                                                .Cells(vRow, vColum).Font.Bold = True
                                                .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                                If (vColum > 2) Then
                                                    Dim vSum As String = ""
                                                    Dim vRowTMP As Integer = vRowSum
                                                    For n As Integer = 0 To vList.Count - 1
                                                        vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                                    Next
                                                    If vList.Count > 0 Then
                                                        .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                                    End If
                                                End If
                                                vColum = vColum + 1
                                                vNgay = vNgay.AddYears(1)

                                            End While
                                        Else
                                            If rdoTuan.Checked Then
                                                .Cells(vRow, 2).Font.Bold = True
                                                .Cells(vRow, 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                .Cells(vRow, 2).Font.Color = RGB(255, 0, 0)
                                                .Cells(vRow, 2) = "Tổng theo nhà xưởng"
                                                While vNgay <= dtDen.Value
                                                    .Cells(vRow, vColum).Font.Bold = True
                                                    .Cells(vRow, vColum).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                                    .Cells(vRow, vColum).Font.Color = RGB(255, 0, 0)
                                                    If (vColum > 2) Then
                                                        Dim vSum As String = ""
                                                        Dim vRowTMP As Integer = vRowSum
                                                        For n As Integer = 0 To vList.Count - 1
                                                            vSum = vSum & .Cells(Convert.ToInt32(vList(n)), vColum).Address.ToString() & "+"
                                                        Next
                                                        If vList.Count > 0 Then
                                                            .Cells(vRow, vColum) = "=" & vSum.Substring(0, vSum.Length - 1)
                                                        End If
                                                    End If
                                                    vColum = vColum + 1
                                                    vNgay = vNgay.AddDays(7)

                                                End While

                                            End If
                                        End If
                                    End If
                                End If
                                vRow = vRow + 1
                            End If
                        End If
                    End With

                Next j
            End If
            ExcelApp.Visible = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmrptThongKeTanSuatNgungMay_NEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtTu.Value = Date.Now.Date.AddMonths(-6)
        dtDen.Value = Date.Now.Date
        dtTu.Format = DateTimePickerFormat.Short
        dtDen.Format = DateTimePickerFormat.Short
        BinDataNguyenNhan()

        BinDataNhaxuong()
        LoadDSMay("-1")
        chxChonTheoMay.Checked = False
        GroupBox1.Visible = False
        vtbDsMayChon = CType(gv_Maychon.DataSource, DataTable).Copy()
        vtbDsMayChon.Rows.Clear()
        AddHandler cbxNhaxuong.SelectedIndexChanged, AddressOf Me.cbxNhaxuong_SelectedIndexChanged

    End Sub
    'Bin data 
    Private Sub BinDataNguyenNhan()
        Try
            Dim tbNguyennhan As DataTable = New DataTable()
            tbNguyennhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT  CONVERT ( BIT , 0 ) AS CHON, MS_NGUYEN_NHAN , TEN_NGUYEN_NHAN,HU_HONG,BTDK  FROM NGUYEN_NHAN_DUNG_MAY  "))
            tbNguyennhan.Columns("CHON").ReadOnly = False
            gvNguyennhan.AutoGenerateColumns = False
            gvNguyennhan.DataSource = tbNguyennhan
            gvNguyennhan.Columns("clMsnguyennhan").DataPropertyName = "MS_NGUYEN_NHAN"
            gvNguyennhan.Columns("clNguyennhan").DataPropertyName = "TEN_NGUYEN_NHAN"
            gvNguyennhan.Columns("HU_HONG").DataPropertyName = "HU_HONG"
            gvNguyennhan.Columns("BTDK").DataPropertyName = "BTDK"
            gvNguyennhan.Columns("clChonnguyennhan").DataPropertyName = "CHON"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BinDataNhaxuong()
        Try
            'Dim tbNhaxuong As DataTable = New DataTable()
            'tbNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT MS_N_XUONG , TEN_N_XUONG , CONVERT (BIT ,0 ) AS CHON FROM NHA_XUONG "))
            'tbNhaxuong.Columns("CHON").ReadOnly = False
            'gvNhaxuong.AutoGenerateColumns = False
            'gvNhaxuong.DataSource = tbNhaxuong
            'gvNhaxuong.Columns("clMsnhaxuong").DataPropertyName = "MS_N_XUONG"
            'gvNhaxuong.Columns("clNhaxuong").DataPropertyName = "TEN_N_XUONG"
            'gvNhaxuong.Columns("clChonnhaxuong").DataPropertyName = "CHON"
            Dim tbNhaxuong As DataTable = New DataTable()
            tbNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Y_Get_Nha_XUONG_TKTSNM_NEW", "-1", "-1", "-1"))
            'tbNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT MS_N_XUONG , TEN_N_XUONG , CONVERT (BIT ,0 ) AS CHON FROM NHA_XUONG "))
            tbNhaxuong.Columns("CHON").ReadOnly = False
            gvNhaxuong.AutoGenerateColumns = False
            gvNhaxuong.DataSource = tbNhaxuong
            gvNhaxuong.Columns("clMsnhaxuong").DataPropertyName = "MS_N_XUONG"
            gvNhaxuong.Columns("clNhaxuong").DataPropertyName = "TEN_N_XUONG"
            gvNhaxuong.Columns("clChonnhaxuong").DataPropertyName = "CHON"
        Catch ex As Exception

        End Try
    End Sub


    Private Sub chxChonTheoMay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxChonTheoMay.CheckedChanged
        If chxChonTheoMay.Checked = True Then
            GroupBox1.Visible = True
            gNhaxuong.Visible = False
            gNguyennhan.Visible = False
            LoadNhaxuongChon()
        Else
            GroupBox1.Visible = False
            gNhaxuong.Visible = True
            gNguyennhan.Visible = True
        End If
    End Sub

    Private Sub cbxNhaxuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxNhaxuong.SelectedIndexChanged
        LoadDSMay(cbxNhaxuong.SelectedValue)
    End Sub

    Sub LoadNhaxuongChon()
        Dim vstrNx As String = "-1"
        For j As Integer = 0 To gvNhaxuong.Rows.Count - 1
            If Convert.ToBoolean(gvNhaxuong.Rows(j).Cells("clChonnhaxuong").Value) Then

                Dim _table As DataTable = New DataTable()
                _table = Get_DataTable(gvNhaxuong.Rows(j).Cells("clMsnhaxuong").Value.ToString().Trim(), "-1", "-1", "-1")
                For Each row As DataRow In _table.Rows
                    If vstrNx = "-1" Then
                        vstrNx = "'" + row("MS_N_XUONG") + "'"
                    Else
                        vstrNx = vstrNx + ",'" + row("MS_N_XUONG") + "'"
                    End If
                Next
            End If

        Next
        Dim vStr As String = ""
        If vstrNx = "-1" Then
            vStr = "SELECT TOP 0 MS_N_XUONG, TEN_N_XUONG  FROM NHA_XUONG "
        Else
            vStr = " SELECT MS_N_XUONG, TEN_N_XUONG  FROM NHA_XUONG " & _
                    " WHERE MS_N_XUONG IN (" + vstrNx + ")"
        End If

        cbxNhaxuong.Text = ""
        gv_Maychon.DataSource = Nothing
        vtbNx = New DataTable()
        vtbNx.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStr))

        cbxNhaxuong.ValueMember = "MS_N_XUONG"
        cbxNhaxuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaxuong.DataSource = vtbNx

    End Sub

    'Load Danh sach may theo nhà xuong 
    Sub LoadDSMay(ByVal ms_n_xuong As String)
        Dim vtbDsMay As New DataTable()
        vtbDsMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_MAY_NHA_XUONGs", ms_n_xuong))
        gv_Maychon.AutoGenerateColumns = False
        gv_Maychon.DataSource = vtbDsMay
        gv_Maychon.Columns("MS_MAY").DataPropertyName = "MS_MAY"
        gv_Maychon.Columns("TEN_MAY").DataPropertyName = "TEN_MAY"
        gv_Maychon.Columns("CHON_MAY").DataPropertyName = "CHON"
        CheckDSMay()
    End Sub
    Private vtbDsMayChon As New DataTable()

    Sub CheckDSMay()
        Try
            For Each grow As DataGridViewRow In gv_Maychon.Rows
                For Each vrow As DataRow In vtbDsMayChon.Rows
                    If vrow("MS_MAY") = grow.Cells("MS_MAY").Value Then
                        gv_Maychon.Rows(grow.Index).Cells("CHON_MAY").Value = True
                    End If
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gv_Maychon_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_Maychon.CellValidating
        If gv_Maychon.Columns(e.ColumnIndex).Name = "CHON_MAY" Then
            Dim vrow() As DataRow = vtbDsMayChon.Select("MS_MAY = '" + gv_Maychon.Rows(e.RowIndex).Cells("MS_MAY").Value + "'")
            gv_Maychon.EndEdit()

            Dim s As Boolean = gv_Maychon.Rows(e.RowIndex).Cells("CHON_MAY").Value
            If gv_Maychon.Rows(e.RowIndex).Cells("CHON_MAY").Value = True And vrow.Length <= 0 Then
                vtbDsMayChon.Rows.Add(gv_Maychon.Rows(e.RowIndex).Cells("MS_MAY").Value, gv_Maychon.Rows(e.RowIndex).Cells("TEN_MAY").Value, "")
            End If
            If gv_Maychon.Rows(e.RowIndex).Cells("CHON_MAY").Value = False And vrow.Length > 0 Then
                For Each rowTm As DataRow In vtbDsMayChon.Select("MS_MAY = '" + gv_Maychon.Rows(e.RowIndex).Cells("MS_MAY").Value + "'")
                    vtbDsMayChon.Rows.Remove(rowTm)
                Next
            End If
        End If
    End Sub

    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click
        Dim i As Integer
        While i < gv_Maychon.RowCount
            gv_Maychon.Rows(i).Cells("CHON_MAY").Value = True
            Dim vrow() As DataRow = vtbDsMayChon.Select("MS_MAY = '" + gv_Maychon.Rows(i).Cells("MS_MAY").Value + "'")
            If vrow.Length = 0 Then
                vtbDsMayChon.Rows.Add(gv_Maychon.Rows(i).Cells("MS_MAY").Value, gv_Maychon.Rows(i).Cells("TEN_MAY").Value, "")
            End If
            i = i + 1
        End While
    End Sub

    Private Sub btnBochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochon.Click
        Dim i As Integer
        While i < gv_Maychon.RowCount
            gv_Maychon.Rows(i).Cells("CHON_MAY").Value = False
            For Each rowTm As DataRow In vtbDsMayChon.Select("MS_MAY = '" + gv_Maychon.Rows(i).Cells("MS_MAY").Value + "'")
                vtbDsMayChon.Rows.Remove(rowTm)
            Next
            i = i + 1
        End While
    End Sub
#Region "Nhu Y"


    Function Get_DataTable(ByVal MS_N_Xuong As String) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable()
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[Y_Get_Nha_XUONG_TKTSNM_NEW]", "-1", "-1", "-1"))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong"))
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_TGSCTB_NEW]", "-1", "-1", "-1"))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable()
        _table = Get_DataTable(MS_N_Xuong)
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

    Private Sub gvNhaxuong_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvNhaxuong.Validated
        LoadNhaxuongChon()
    End Sub
End Class
