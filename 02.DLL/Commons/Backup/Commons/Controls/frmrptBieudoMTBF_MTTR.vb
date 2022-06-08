
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptBieudoMTBF_MTTR

    Private Sub frmrptBieudoMTBF_MTTR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.Default
        dtpTungay.Value = Date.Now().AddMonths(-4)
        dtpDenngay.Value = Date.Now()
        LoadCombo()
    End Sub
    Sub LoadCombo()
        Dim dtNhaxuong As New System.Data.DataTable
        dtNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHA_XUONGs1", Commons.Modules.UserName))
        cboNhaxuong.DataSource = dtNhaxuong
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DisplayMember = "Ten_N_XUONG"
    End Sub


    Private Sub cboNhaxuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNhaxuong.SelectedIndexChanged
        Try
            If cboNhaxuong.SelectedIndex > 0 Then
                Dim dtNhaxuong As New System.Data.DataTable
                dtNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAYsbyMS_N_XUONG", cboNhaxuong.SelectedValue))
                gvLoaimay.AutoGenerateColumns = False
                gvLoaimay.Columns("CHON").ReadOnly = False
                gvLoaimay.DataSource = dtNhaxuong

                gvLoaimay.Columns("CHON").DataPropertyName = "CHON"
                gvLoaimay.Columns("MS_LOAI_MAY").DataPropertyName = "MS_LOAI_MAY"
                gvLoaimay.Columns("MS_LOAI_MAY").Visible = True
                gvLoaimay.Columns("TEN_LOAI_MAY").DataPropertyName = "TEN_LOAI_MAY"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim tuthang As DateTime = New DateTime(dtpTungay.Value.Year, dtpTungay.Value.Month, 1)
        Dim denthang As DateTime = New DateTime(dtpDenngay.Value.Year, dtpDenngay.Value.Month, DateTime.DaysInMonth(dtpDenngay.Value.Year, dtpDenngay.Value.Month))
        If tuthang > denthang Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "tuthangphainhodondenthang", Commons.Modules.TypeLanguage))
            dtpDenngay.Focus()
            Exit Sub
        End If

        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        Me.Cursor = Cursors.WaitCursor
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
        Dim tt As DateTime = tuthang
        Dim dt As DateTime = denthang

        Dim col As Integer = 0
        While dt.Year > tt.Year
            col = col + 1
            tt = tt.AddMonths(1)
        End While
        While dt.Year = tt.Year And tt.Month < dt.Month
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
            .Range("A1", GetCol(col) + "1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "titleBieudoMTBF_MTTR", Commons.Modules.TypeLanguage)

            .Range("A2", GetCol(col) + "2").Font.Bold = True
            .Range("A2", GetCol(col) + "2").Merge(True)
            .Range("A2", GetCol(col) + "2").MergeCells = True
            .Range("A2", GetCol(col) + "2").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A2", GetCol(col) + "2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "Tuthang", Commons.Modules.TypeLanguage) + dtpTungay.Text + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "Denthang", Commons.Modules.TypeLanguage) + dtpDenngay.Text

            .Range("A3", GetCol(col) + "3").Font.Bold = True
            .Range("A3", GetCol(col) + "3").Merge(True)
            .Range("A3", GetCol(col) + "3").MergeCells = True
            .Range("A3", GetCol(col) + "3").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A3", GetCol(col) + "3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "Nhaxuong", Commons.Modules.TypeLanguage) + cboNhaxuong.Text

            .Range("A6", "A6").Font.Bold = True
            .Range("A6", "A6").Merge(True)
            .Range("A6", "A6").MergeCells = True
            .Range("A6", "A6").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A6", "A6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "MECHINETYPE", Commons.Modules.TypeLanguage)
            .Range("A6", "A6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)


            .Range("B6", "B6").Font.Bold = True
            .Range("B6", "B6").Merge(True)
            .Range("B6", "B6").MergeCells = True
            .Range("B6", "B6").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("B6", "B6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "Detail", Commons.Modules.TypeLanguage)
            .Range("B6", "B6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        End With

        With ExcelSheets
            .Columns(1).ColumnWidth = 20
            .Columns(2).ColumnWidth = 15

        End With
        tt = tuthang
        dt = denthang
        col = 1
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
        'Dim dtMTBF As New System.Data.DataTable
        Dim vls As String
        Dim nhaxuong As String = cboNhaxuong.SelectedValue.ToString
        Dim row As String = 6
        Dim ind As Integer = 0
        For i As Integer = 0 To gvLoaimay.Rows.Count - 1
            If gvLoaimay.Rows(i).Cells("CHON").Value = True Then
                ind += 1
                Dim dtMTBF As New System.Data.DataTable
                vls = gvLoaimay.Rows(i).Cells("MS_LOAI_MAY").Value.ToString
                row += 1
                With ExcelSheets
                    .Range("A" + row, "A" + (row + 4).ToString).Font.Bold = True
                    .Range("A" + row, "A" + (row + 4).ToString).Merge(True)
                    .Range("A" + row, "A" + (row + 4).ToString).MergeCells = True
                    .Range("A" + row, "A" + (row + 4).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("A" + row, "A" + (row + 4).ToString).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("A" + row, "A" + (row + 4).ToString).Value = gvLoaimay.Rows(i).Cells("TEN_LOAI_MAY").Value.ToString
                    .Range("A" + row, "A" + (row + 4).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)


                    .Range("B" + (row).ToString, "B" + (row).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("B" + (row).ToString, "B" + (row).ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "RUNTIME", Commons.Modules.TypeLanguage)
                    .Range("B" + (row).ToString, "B" + (row).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                    .Range("B" + (row + 1).ToString, "B" + (row + 1).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("B" + (row + 1).ToString, "B" + (row + 1).ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "DOWNTIME", Commons.Modules.TypeLanguage)
                    .Range("B" + (row + 1).ToString, "B" + (row + 1).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                    .Range("B" + (row + 2).ToString, "B" + (row + 2).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("B" + (row + 2).ToString, "B" + (row + 2).ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "TOTALWOF", Commons.Modules.TypeLanguage)
                    .Range("B" + (row + 2).ToString, "B" + (row + 2).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                    .Range("B" + (row + 3).ToString, "B" + (row + 3).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("B" + (row + 3).ToString, "B" + (row + 3).ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "MTTR", Commons.Modules.TypeLanguage)
                    .Range("B" + (row + 3).ToString, "B" + (row + 3).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                    .Range("B" + (row + 4).ToString, "B" + (row + 4).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("B" + (row + 4).ToString, "B" + (row + 4).ToString).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoMTBF_MTTR", "MTBF", Commons.Modules.TypeLanguage)
                    .Range("B" + (row + 4).ToString, "B" + (row + 4).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                End With
                dtMTBF.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_MTBF_MTTR", tuthang, denthang, vls, cboNhaxuong.SelectedValue.ToString))
                tt = tuthang
                dt = denthang
                For index As Integer = 0 To col - 2
                    Dim runtime As Double
                    Dim downtime As Double
                    Dim total As Double
                    Dim mtbf As Double
                    Dim mttr As Double
                    dtMTBF.DefaultView.RowFilter = "THANG ='" + tt.Month.ToString + "' and NAM='" + tt.Year.ToString + "'"
                    If dtMTBF.DefaultView.Count > 0 Then

                        If dtMTBF.DefaultView(0)("RUNTIME").ToString <> "" Then
                            runtime = dtMTBF.DefaultView(0)("RUNTIME")
                        Else
                            runtime = 0
                        End If
                        If dtMTBF.DefaultView(0)("DOWNTIME").ToString <> "" Then
                            downtime = dtMTBF.DefaultView(0)("DOWNTIME")
                        Else
                            downtime = 0
                        End If
                        If dtMTBF.DefaultView(0)("TOTALWOF").ToString <> "" Then
                            total = dtMTBF.DefaultView(0)("TOTALWOF")
                        Else
                            total = 0
                        End If

                        Try
                            If total <> 0 Then
                                mtbf = runtime / total
                            Else
                                mtbf = runtime
                            End If
                        Catch ex As Exception
                            mtbf = runtime
                        End Try
                        Try
                            If total <> 0 Then
                                mttr = downtime / total
                            Else
                                mttr = downtime
                            End If
                        Catch ex As Exception
                            mttr = downtime
                        End Try
                        Dim sname As String = GetCol(index + 2)
                        With ExcelSheets
                            .Range(sname + (row).ToString, sname + (row).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row).ToString, sname + (row).ToString).Value = runtime
                            .Range(sname + (row).ToString, sname + (row).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 1).ToString, sname + (row + 1).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 1).ToString, sname + (row + 1).ToString).Value = downtime
                            .Range(sname + (row + 1).ToString, sname + (row + 1).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 2).ToString, sname + (row + 2).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 2).ToString, sname + (row + 2).ToString).Value = total
                            .Range(sname + (row + 2).ToString, sname + (row + 2).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 3).ToString, sname + (row + 3).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 3).ToString, sname + (row + 3).ToString).Value = mttr
                            .Range(sname + (row + 3).ToString, sname + (row + 3).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 4).ToString, sname + (row + 4).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 4).ToString, sname + (row + 4).ToString).Value = mtbf
                            .Range(sname + (row + 4).ToString, sname + (row + 4).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End With
                    Else
                        Dim sname As String = GetCol(index + 2)
                        With ExcelSheets
                            .Range(sname + (row).ToString, sname + (row).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row).ToString, sname + (row).ToString).Value = 0
                            .Range(sname + (row).ToString, sname + (row).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 1).ToString, sname + (row + 1).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 1).ToString, sname + (row + 1).ToString).Value = 0
                            .Range(sname + (row + 1).ToString, sname + (row + 1).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 2).ToString, sname + (row + 2).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 2).ToString, sname + (row + 2).ToString).Value = 0
                            .Range(sname + (row + 2).ToString, sname + (row + 2).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 3).ToString, sname + (row + 3).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 3).ToString, sname + (row + 3).ToString).Value = 0
                            .Range(sname + (row + 3).ToString, sname + (row + 3).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                            .Range(sname + (row + 4).ToString, sname + (row + 4).ToString).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            .Range(sname + (row + 4).ToString, sname + (row + 4).ToString).Value = 0
                            .Range(sname + (row + 4).ToString, sname + (row + 4).ToString).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        End With
                    End If
                    tt = tt.AddMonths(1)
                Next

                CreateChart(ExcelSheets, row - 1, col, gvLoaimay.Rows(i).Cells("TEN_LOAI_MAY").Value.ToString, ind)
                row += 4
            End If
        Next
        Me.Cursor = Cursors.Default
        ExcelApp.Visible = True
    End Sub

    Private Sub CreateChart(ByVal ExcelSheets As Excel.Worksheet, ByVal vDong As Integer, ByVal vColum As Integer, ByVal vTitle As String, ByVal index As Integer)
        '''''bieu do '''''
        Try


            Dim vLeft As Integer = 490
            Dim si As Integer = (index - 1)
            si = Math.Floor(si / 3)
            Dim sl As Integer = (index - 1) Mod 3
            Dim vTop As Integer = 50
            Dim vW As Integer = 200
            Dim vH As Integer = 200
            vLeft = vLeft + sl * vW
            vTop = vTop + vH * si

            Dim chartObjs As ChartObjects = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
            Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, vW, vH)
            Dim xlChart As Chart = chartObj.Chart
            Dim xlSeriesCollection As SeriesCollection = xlChart.SeriesCollection
            xlChart.ChartType = XlChartType.xlLineMarkers
            Dim xlSeries As Series = xlSeriesCollection.NewSeries

            With xlSeries
                .AxisGroup = XlAxisGroup.xlPrimary
                .Name = "MTTR"
                .XValues = ExcelSheets.Range("C6", GetCol(vColum).ToString + "6")
                .Values = ExcelSheets.Range("C" + (vDong + 4).ToString, GetCol(vColum).ToString + (vDong + 4).ToString)
            End With

            Dim xlSeries1 As Series = xlSeriesCollection.NewSeries
            With xlSeries1
                .AxisGroup = XlAxisGroup.xlSecondary
                .Name = "MTBF"
                .XValues = ExcelSheets.Range("C6", GetCol(vColum).ToString + "6")
                .Values = ExcelSheets.Range("C" + (vDong + 5).ToString, GetCol(vColum).ToString + (vDong + 5).ToString)
            End With
            xlChart.Refresh()

            'xlChart.Axes(XlCategoryType.xlAutomaticScale, XlAxisGroup.xlPrimary)


            xlChart.HasTitle = True
            xlChart.ChartTitle.Text = vTitle
            xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom
            xlChart.ChartArea.Border.Color = RGB(10, 10, 255)
            xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Border.Color = RGB(0, 255, 255)
            xlChart.Legend.Border.Color = RGB(255, 255, 255)
        Catch ex As Exception

        End Try
    End Sub

    Function GetCol(ByVal num As Integer) As String
        Return Convert.ToChar(65 + num).ToString
    End Function

    Private Sub btnChonhet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonhet.Click
        For i As Integer = 0 To gvLoaimay.Rows.Count - 1
            gvLoaimay.Rows(i).Cells("CHON").Value = True
        Next
    End Sub

    Private Sub btnBochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochon.Click
        For i As Integer = 0 To gvLoaimay.Rows.Count - 1
            gvLoaimay.Rows(i).Cells("CHON").Value = False
        Next
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
