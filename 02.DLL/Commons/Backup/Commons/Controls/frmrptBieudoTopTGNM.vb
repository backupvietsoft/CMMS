
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptBieudoTopTGNM

    Private Sub frmrptBieudoTopTGNM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.Default
        dtpTungay.Value = Date.Now().AddMonths(-4)
        dtpDenngay.Value = Date.Now()
        mtxtTop.Text = 5
        LoadCombo()
    End Sub

    Sub LoadCombo()
        Dim dtNhaxuong As New System.Data.DataTable
        dtNhaxuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHA_XUONGs1", Commons.Modules.UserName))
        cboNhaxuong.DataSource = dtNhaxuong
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DisplayMember = "Ten_N_XUONG"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        Dim tungay As DateTime = dtpTungay.Value
        Dim denngay As DateTime = dtpDenngay.Value
        If tungay > denngay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "tuthangphainhodondenthang", Commons.Modules.TypeLanguage))
            dtpDenngay.Focus()
            Exit Sub
        End If
        Try
            If mtxtTop.Text.Trim.Length > 0 Then
                Dim top As Int32 = Int32.Parse(mtxtTop.Text)
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "msgKiemtralaigiatrinhap", Commons.Modules.TypeLanguage))
                mtxtTop.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "msgKiemtralaigiatrinhap", Commons.Modules.TypeLanguage))
            mtxtTop.Focus()
            Exit Sub
        End Try

        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        Me.Cursor = Cursors.WaitCursor
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
        Dim tt As DateTime = tungay
        Dim dt As DateTime = denngay
        Dim col As Integer = Int32.Parse(mtxtTop.Text)
        Dim dtDowntime As New System.Data.DataTable
        dtDowntime.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Top_TGNM", tungay, denngay, cboNhaxuong.SelectedValue.ToString, Int32.Parse(mtxtTop.Text)))
        If dtDowntime.Rows.Count <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "Khongcodulieu", Commons.Modules.TypeLanguage))
            cboNhaxuong.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        With ExcelSheets
            .Range("A1", GetCol(col) + "1").Font.Bold = True
            .Range("A1", GetCol(col) + "1").Merge(True)
            .Range("A1", GetCol(col) + "1").MergeCells = True
            .Range("A1", GetCol(col) + "1").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A1", GetCol(col) + "1").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A1", GetCol(col) + "1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "titleBieudoTopThoigianngungmay", Commons.Modules.TypeLanguage)


            .Range("A2", GetCol(col) + "2").Font.Bold = True
            .Range("A2", GetCol(col) + "2").Merge(True)
            .Range("A2", GetCol(col) + "2").MergeCells = True
            .Range("A2", GetCol(col) + "2").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A2", GetCol(col) + "2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "Tungay", Commons.Modules.TypeLanguage) + dtpTungay.Text + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "Denngay", Commons.Modules.TypeLanguage) + dtpDenngay.Text

            .Range("A3", GetCol(col) + "3").Font.Bold = True
            .Range("A3", GetCol(col) + "3").Merge(True)
            .Range("A3", GetCol(col) + "3").MergeCells = True
            .Range("A3", GetCol(col) + "3").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A3", GetCol(col) + "3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "Nhaxuong", Commons.Modules.TypeLanguage) + cboNhaxuong.Text

            .Range("A6", "A6").Font.Bold = True
            .Range("A6", "A6").Merge(True)
            .Range("A6", "A6").MergeCells = True
            .Range("A6", "A6").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A6", "A6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "Loaimay", Commons.Modules.TypeLanguage)
            .Range("A6", "A6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)


            .Range("A7", "A7").Font.Bold = True
            .Range("A7", "A7").Merge(True)
            .Range("A7", "A7").MergeCells = True
            .Range("A7", "A7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A7", "A7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "TGNM", Commons.Modules.TypeLanguage)
            .Range("A7", "A7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)


        End With

        With ExcelSheets
            .Columns(1).ColumnWidth = 20
        End With
        Dim index As Integer = 0
        For Each row As DataRow In dtDowntime.Rows
            With ExcelSheets
                .Range(GetCol(index + 1) & 6, GetCol(index + 1) & 6).Font.Bold = True
                .Range(GetCol(index + 1) & 6, GetCol(index + 1) & 6).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range(GetCol(index + 1) & 6, GetCol(index + 1) & 6).Value = row("TEN_LOAI_MAY").ToString
                .Range(GetCol(index + 1) & 6, GetCol(index + 1) & 6).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                .Range(GetCol(index + 1) & 7, GetCol(index + 1) & 7).Font.Bold = True
                .Range(GetCol(index + 1) & 7, GetCol(index + 1) & 7).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range(GetCol(index + 1) & 7, GetCol(index + 1) & 7).Value = row("TGNM").ToString
                .Range(GetCol(index + 1) & 7, GetCol(index + 1) & 7).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            End With
            index += 1
        Next
        CreateChart(ExcelSheets, index, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieudoTopTGNM", "hightdowntime", Commons.Modules.TypeLanguage))
        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CreateChart(ByVal ExcelSheets As Excel.Worksheet, ByVal index As Integer, ByVal vTitle As String)
        '''''bieu do '''''
        Dim vLeft As Integer = 20
        Dim vTop As Integer = 100
        Dim vW As Integer = 500
        Dim vH As Integer = 450

        Dim chartObjs As ChartObjects = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
        Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, vW, vH)
        Dim xlChart As Chart = chartObj.Chart
        ' Dim xlSeriesCollection As SeriesCollection = xlChart.SeriesCollection
        xlChart.ChartType = XlChartType.xl3DColumn

        Dim rgEqui As Excel.Range
        rgEqui = ExcelSheets.Range("A" & 6, GetCol(index) & 7)

        xlChart.SetSourceData(rgEqui, Excel.XlRowCol.xlRows)

        xlChart.HasDataTable = True
        xlChart.HasLegend = False
        xlChart.DataTable.Font.Size = 7.25
        With xlChart.Axes(XlAxisType.xlCategory)
            .HasMajorGridlines = True
            .MajorGridlines.Border.Color = RGB(216, 216, 216)

        End With

        With xlChart.Axes(XlAxisType.xlValue)
            .HasMajorGridlines = True
            .MajorGridlines.Border.Color = RGB(216, 216, 216)

        End With

        With chartObj
            .RoundedCorners = True
        End With

        xlChart.Refresh()

        'xlChart.Axes(XlCategoryType.xlAutomaticScale, XlAxisGroup.xlPrimary)


        xlChart.HasTitle = True
        xlChart.ChartTitle.Text = vTitle
        ' xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom
        xlChart.ChartArea.Border.Color = RGB(10, 10, 255)
        xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        xlChart.PlotArea.Border.Color = RGB(0, 255, 255)
    End Sub

    Function GetCol(ByVal num As Integer) As String
        Return Convert.ToChar(65 + num).ToString
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
