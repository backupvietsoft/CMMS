
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptBIEU_DO_CHI_PHI_MAINT_COST

    Private Sub frmrptBIEU_DO_CHI_PHI_MAINT_COST_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "MsgTungayphainhohondenngay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtpTungay.Focus()
            Exit Sub
        End If
        If dtpDenngay.Value > DateTime.Now Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "Msgdenngayphainhohonngayhientai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
                .Range("A1", GetCol(col) + "1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "titleBieudoMaintCost", Commons.Modules.TypeLanguage)

                .Range("A2", GetCol(col) + "2").Font.Bold = True
                .Range("A2", GetCol(col) + "2").Merge(True)
                .Range("A2", GetCol(col) + "2").MergeCells = True
                .Range("A2", GetCol(col) + "2").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A2", GetCol(col) + "2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "Tungay", Commons.Modules.TypeLanguage) + dtpTungay.Text + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "Denngay", Commons.Modules.TypeLanguage) + dtpDenngay.Text

                .Range("A3", GetCol(col) + "3").Font.Bold = True
                .Range("A3", GetCol(col) + "3").Merge(True)
                .Range("A3", GetCol(col) + "3").MergeCells = True
                .Range("A3", GetCol(col) + "3").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A3", GetCol(col) + "3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "BPCP", Commons.Modules.TypeLanguage) + cbBPCP.Text

                .Range("A6", "A6").Font.Bold = True
                .Range("A6", "A6").Merge(True)
                .Range("A6", "A6").MergeCells = True
                .Range("A6", "A6").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A6", "A6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "Month", Commons.Modules.TypeLanguage)
                .Range("A6", "A6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A7", "A7").Font.Bold = True
                .Range("A7", "A7").Merge(True)
                .Range("A7", "A7").MergeCells = True
                .Range("A7", "A7").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A7", "A7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "TongtienNCtrongxuong", Commons.Modules.TypeLanguage)
                .Range("A7", "A7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A8", "A8").Font.Bold = True
                .Range("A8", "A8").Merge(True)
                .Range("A8", "A8").MergeCells = True
                .Range("A8", "A8").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A8", "A8").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "vattuphutungthaythe", Commons.Modules.TypeLanguage)
                .Range("A8", "A8").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A9", "A9").Font.Bold = True
                .Range("A9", "A9").Merge(True)
                .Range("A9", "A9").MergeCells = True
                .Range("A9", "A9").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A9", "A9").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "hoatdongbaotritrongxuong", Commons.Modules.TypeLanguage)
                .Range("A9", "A9").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A10", "A10").Font.Bold = True
                .Range("A10", "A10").Merge(True)
                .Range("A10", "A10").MergeCells = True
                .Range("A10", "A10").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A10", "A10").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "lapdatvaxaydungxuong", Commons.Modules.TypeLanguage)
                .Range("A10", "A10").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range("A11", "A11").Font.Bold = True
                .Range("A11", "A11").Merge(True)
                .Range("A11", "A11").MergeCells = True
                .Range("A11", "A11").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A11", "A11").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "MainCost", Commons.Modules.TypeLanguage)
                .Range("A11", "A11").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            End With


            With ExcelSheets
                .Columns(1).ColumnWidth = 20
                .Columns(2).ColumnWidth = 15

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
            tt = New DateTime(dtpTungay.Value.Year, dtpTungay.Value.Month, 1)
            Dim dtMaincost As New System.Data.DataTable
            dtMaincost.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBIEU_DO_MAINT_COST", tt, dt, cbBPCP.SelectedValue.ToString()))
            If dtMaincost.Rows.Count > 0 Then
                col = 1
                Dim row As Integer = 7
                For i As Integer = 0 To dtMaincost.Rows.Count - 1
                    Dim colName As String = GetCol(col)
                    With ExcelSheets
                        .Range(colName + row.ToString(), colName + row.ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + row.ToString(), colName + row.ToString()).Value = dtMaincost.Rows(i).Item("TONGLUONG").ToString()
                        .Range(colName + row.ToString(), colName + row.ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range(colName + row.ToString(), colName + row.ToString()).NumberFormat = "#,##0.00"

                        .Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).Value = dtMaincost.Rows(i).Item("TONGVT").ToString()
                        .Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range(colName + (row + 1).ToString(), colName + (row + 1).ToString()).NumberFormat = "#,##0.00"

                        .Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).Value = dtMaincost.Rows(i).Item("HDBT").ToString()
                        .Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range(colName + (row + 2).ToString(), colName + (row + 2).ToString()).NumberFormat = "#,##0.00"

                        .Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).Value = dtMaincost.Rows(i).Item("CHIPHILAPDAT").ToString()
                        .Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range(colName + (row + 3).ToString(), colName + (row + 3).ToString()).NumberFormat = "#,##0.00"

                        .Range(colName + (row + 4).ToString(), colName + (row + 4).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range(colName + (row + 4).ToString(), colName + (row + 4).ToString()).Value = "=(" + colName + (row).ToString() + "+" + colName + (row + 1).ToString() + "+" + colName + (row + 2).ToString() + ")/(" + colName + (row + 3).ToString() + ")*100"
                        .Range(colName + (row + 4).ToString(), colName + (row + 4).ToString()).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range(colName + (row + 4).ToString(), colName + (row + 4).ToString()).NumberFormat = "#,##0.00"
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
            .Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "MaintCost", Commons.Modules.TypeLanguage)
            .XValues = ExcelSheets.Range("B6", GetCol(col) + "6")
            .Values = ExcelSheets.Range("B11", GetCol(col) + "11")
        End With

        xlChart.Refresh()

        xlChart.HasTitle = True
        xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBIEU_DO_CHI_PHI_MAINT_COST", "MaintCost", Commons.Modules.TypeLanguage)
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
