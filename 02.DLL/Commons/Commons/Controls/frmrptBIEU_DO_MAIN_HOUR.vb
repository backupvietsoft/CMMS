
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptBIEU_DO_MAIN_HOUR

    Private Sub frmrptBIEU_DO_MAIN_HOUR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpTungay.Value = DateTime.Now.AddMonths(-5)
        dtpDenngay.Value = DateTime.Now()
        LoadBPCP()
    End Sub

    Private Sub LoadBPCP()
        Dim dtBPCP As New System.Data.DataTable
        dtBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_CHIU_PHIs"))
        cbBPCP.DataSource = dtBPCP
        cbBPCP.DisplayMember = "TEN_BP_CHIU_PHI"
        cbBPCP.ValueMember = "MS_BP_CHIU_PHI"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If dtpTungay.Value > dtpDenngay.Value Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "MsgTungayphainhohondenngay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtpTungay.Focus()

            Exit Sub
        End If
        If dtpDenngay.Value > DateTime.Now Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "Msgdenngayphainhohonngayhientai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtpDenngay.Focus()
            Exit Sub
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
            Dim tt As DateTime = New DateTime(dtpTungay.Value.Year, dtpTungay.Value.Month, 1)
            Dim dt As DateTime = New DateTime(dtpDenngay.Value.Year, dtpDenngay.Value.Month, DateTime.DaysInMonth(dtpDenngay.Value.Year, dtpDenngay.Value.Month))


            Dim col As Integer = 0
            While dt.Year > tt.Year
                col = col + 1
                tt = tt.AddMonths(1)
            End While
            While dt.Year = tt.Year And tt.Month <= dt.Month
                col = col + 1
                tt = tt.AddMonths(1)
            End While
            If col = 0 Then
                dtpDenngay.Focus()
                Exit Sub
            End If

            With ExcelSheets
                .Range("A1", GetCol(col) + "1").Font.Bold = True
                .Range("A1", GetCol(col) + "1").Merge(True)
                .Range("A1", GetCol(col) + "1").MergeCells = True
                .Range("A1", GetCol(col) + "1").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A1", GetCol(col) + "1").VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("A1", GetCol(col) + "1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "titleBieudoMainHour", Commons.Modules.TypeLanguage)

                .Range("A2", GetCol(col) + "2").Font.Bold = True
                .Range("A2", GetCol(col) + "2").Merge(True)
                .Range("A2", GetCol(col) + "2").MergeCells = True
                .Range("A2", GetCol(col) + "2").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A2", GetCol(col) + "2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "Tungay", Commons.Modules.TypeLanguage) + " " + dtpTungay.Text + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "Denngay", Commons.Modules.TypeLanguage) + " " + dtpDenngay.Text

                .Range("A3", GetCol(col) + "3").Font.Bold = True
                .Range("A3", GetCol(col) + "3").Merge(True)
                .Range("A3", GetCol(col) + "3").MergeCells = True
                .Range("A3", GetCol(col) + "3").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A3", GetCol(col) + "3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "BPCP", Commons.Modules.TypeLanguage) + " " + cbBPCP.Text

                .Range("A6", "A6").Font.Bold = True
                .Range("A6", "A6").Merge(True)
                .Range("A6", "A6").MergeCells = True
                .Range("A6", "A6").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A6", "A6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "Month", Commons.Modules.TypeLanguage)
                .Range("A6", "A6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A7", "A7").Font.Bold = True
                .Range("A7", "A7").Merge(True)
                .Range("A7", "A7").MergeCells = True
                .Range("A7", "A7").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A7", "A7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "ThoigianlamvieccuaCN", Commons.Modules.TypeLanguage)
                .Range("A7", "A7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A8", "A8").Font.Bold = True
                .Range("A8", "A8").Merge(True)
                .Range("A8", "A8").MergeCells = True
                .Range("A8", "A8").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A8", "A8").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "soCNcuabophanchiuphi", Commons.Modules.TypeLanguage)
                .Range("A8", "A8").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A9", "A9").Font.Bold = True
                .Range("A9", "A9").Merge(True)
                .Range("A9", "A9").MergeCells = True
                .Range("A9", "A9").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A9", "A9").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "Songaylamviectrongthang", Commons.Modules.TypeLanguage)
                .Range("A9", "A9").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A10", "A10").Font.Bold = True
                .Range("A10", "A10").Merge(True)
                .Range("A10", "A10").MergeCells = True
                .Range("A10", "A10").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A10", "A10").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "MainHour", Commons.Modules.TypeLanguage)
                .Range("A10", "A10").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            End With


            With ExcelSheets
                .Columns(1).ColumnWidth = 40
            End With
            tt = New DateTime(dtpTungay.Value.Year, dtpTungay.Value.Month, 1)
            dt = New DateTime(dtpDenngay.Value.Year, dtpDenngay.Value.Month, DateTime.DaysInMonth(dtpDenngay.Value.Year, dtpDenngay.Value.Month))

            col = 0
            While dt.Year > tt.Year
                col = col + 1
                Dim colName As String = GetCol(col) + "6"
                With ExcelSheets
                    .Range(colName, colName).Font.Bold = True
                    .Range(colName, colName).Merge(True)
                    .Range(colName, colName).MergeCells = True
                    .Range(colName, colName).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range(colName, colName).Value = tt.ToString("MM/yyyy")
                    .Range(colName, colName).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                End With
                tt = tt.AddMonths(1)
            End While
            While dt.Year = tt.Year And tt.Month <= dt.Month
                col = col + 1
                Dim colName As String = GetCol(col) + "6"
                With ExcelSheets
                    .Range(colName, colName).Font.Bold = True
                    .Range(colName, colName).Merge(True)
                    .Range(colName, colName).MergeCells = True
                    .Range(colName, colName).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range(colName, colName).Value = String.Format("{0:MM/yyyy}", tt)
                    .Range(colName, colName).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                End With
                tt = tt.AddMonths(1)
            End While
            Try
                ExcelSheets.Range(ExcelSheets.Cells(6, 2), ExcelSheets.Cells(9, 2)).EntireRow.Group()
                ExcelSheets.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove
            Catch ex As Exception

            End Try

            tt = New DateTime(dtpTungay.Value.Year, dtpTungay.Value.Month, 1)
            Dim dtMainhour As New System.Data.DataTable
            Dim ncn As Integer
            dtMainhour.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBIEU_DO_MAIN_HOUR", tt, dt, cbBPCP.SelectedValue.ToString()))
            If dtMainhour.Rows.Count > 0 Then
                col = 1
                Dim row As Integer = 7
                For i As Integer = 0 To dtMainhour.Rows.Count - 1
                    Dim colName As String = GetCol(col)
                    Dim tong As Double
                    tong = IIf(dtMainhour.Rows(i).Item("TGPBT") Is DBNull.Value, 0, dtMainhour.Rows(i).Item("TGPBT")) / 60 + IIf(dtMainhour.Rows(i).Item("TGCVHN") Is DBNull.Value, 0, dtMainhour.Rows(i).Item("TGCVHN")) + IIf(dtMainhour.Rows(i).Item("TGKHCV") Is DBNull.Value, 0, dtMainhour.Rows(i).Item("TGKHCV"))
                    ncn = GetOfWeek(Int32.Parse(dtMainhour.Rows(i).Item("THANG").ToString()), Int32.Parse(dtMainhour.Rows(i).Item("NAM").ToString()))
                    With ExcelSheets
                        .Range(colName + row.ToString(), colName + row.ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + row.ToString(), colName + row.ToString()).Value = tong
                        '.Range(colName + row.ToString(), colName + row.ToString()).NumberFormat = "N2"
                        .Range(colName + row.ToString(), colName + row.ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)


                        .Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).Value = dtMainhour.Rows(i).Item("CNCT").ToString()
                        '.Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).NumberFormat = "N2"
                        .Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                        .Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).Value = dtMainhour.Rows(i).Item("SNLV") - ncn
                        '.Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).NumberFormat = "N2"
                        .Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                        .Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).Value = "=" + colName + (row).ToString() + "/(" + colName + (row + 1).ToString() + "*" + colName + (row + 2).ToString() + "*8)*100"
                        '.Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).NumberFormat = "N2"
                        .Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                    End With
                    col += 1
                Next
            End If
            CreateChart(ExcelSheets, col - 1)
            ExcelApp.Visible = True
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Function GetOfWeek(ByVal thang As Integer, ByVal nam As Integer) As Integer
        Dim soNgayCN As Integer = 0
        For i As Integer = 1 To 31
            Try
                Dim dtt As New DateTime(nam, thang, i)
                If dtt.DayOfWeek = DayOfWeek.Sunday Then
                    soNgayCN += 1
                End If
            Catch ex As Exception

            End Try
        Next
        Return soNgayCN

    End Function

    Private Sub CreateChart(ByVal ExcelSheets As Excel.Worksheet, ByVal col As Integer)
        '''''bieu do '''''
        Dim vLeft As Integer = 20
        Dim vTop As Integer = 170
        Dim vW As Integer = 450
        Dim vH As Integer = 450

        Dim chartObjs As ChartObjects = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
        Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, vW, vH)
        Dim xlChart As Chart = chartObj.Chart
        Dim xlSeriesCollection As SeriesCollection = xlChart.SeriesCollection
        xlChart.ChartType = XlChartType.xlLineMarkers
        Dim xlSeries As Series = xlSeriesCollection.NewSeries

        With xlSeries
            .AxisGroup = XlAxisGroup.xlPrimary
            .Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "MaintHour", Commons.Modules.TypeLanguage)
            .XValues = ExcelSheets.Range("B6", GetCol(col) + "6")
            .Values = ExcelSheets.Range("B10", GetCol(col) + "10")
        End With

        'Dim xlSeries1 As Series = xlSeriesCollection.NewSeries
        'With xlSeries1
        '    .AxisGroup = XlAxisGroup.xlSecondary
        '    .Name = "MTBF"
        '    .XValues = ExcelSheets.Range("C6", "G6")
        '    .Values = ExcelSheets.Range("C" + (vDong + 5).ToString, "G" + (vDong + 5).ToString)
        'End With
        xlChart.Refresh()

        'xlChart.Axes(XlCategoryType.xlAutomaticScale, XlAxisGroup.xlPrimary)


        xlChart.HasTitle = True
        xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_MAIN_HOUR", "MaintHour", Commons.Modules.TypeLanguage)
        xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom
        xlChart.ChartArea.Border.Color = RGB(10, 10, 255)
        xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Border.Color = RGB(0, 255, 255)
        xlChart.Legend.Border.Color = RGB(255, 255, 255)
    End Sub

    Function GetCol(ByVal num As Integer) As String
        Return Convert.ToChar(65 + num).ToString
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
