
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmrptMAINTENANCT_REPORT_MONTHLY

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim sotuan As Integer = SoTuanTrongThang(cbxThang.Text)
        Dim vThang As DateTime


        Dim vtmp As String
        If cbxThang.Text.Length = 6 Then
            vtmp = "0" + cbxThang.Text
        Else
            vtmp = cbxThang.Text
        End If

        vThang = DateTime.ParseExact("01/" + vtmp, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        Dim vObjBD As Object
        Dim vTuanBD As Integer = 0
        vObjBD = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_GET_TUAN", vThang)
        vTuanBD = CType(vObjBD, Integer)

        Dim vtbData As New System.Data.DataTable
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_MAINTENANCE_REPORT_MONTHLY_CSWIND", vThang, cbxNhaXuong.SelectedValue))

        Dim vTbTTC As New Data.DataTable
        vTbTTC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * from THONG_TIN_CHUNG "))

        Me.Cursor = Cursors.WaitCursor
        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

        Try
            With ExcelSheets
                If Not IsDBNull(vTbTTC.Rows(0)("LOGO")) Then
                    Dim arrPicture As Byte() = vTbTTC.Rows(0)("LOGO")
                    Dim ms As New IO.MemoryStream(arrPicture)
                    Dim image As Image = System.Drawing.Image.FromStream(ms)
                    Dim newImage As New Bitmap(170, 30)
                    Dim gr_dest As Graphics = Graphics.FromImage(newImage)
                    gr_dest.DrawImage(image, 0, 0, _
                        newImage.Width + 1, _
                        newImage.Height + 1)
                    image = newImage
                    Clipboard.SetDataObject(image, True)
                    .Range("A1", "A1").Select()
                    ExcelSheets.Paste()
                End If
            End With
        Catch ex As Exception
        End Try

        With ExcelSheets
            .Columns(1).ColumnWidth = 5
            .Columns(2).ColumnWidth = 10
            .Columns(3).ColumnWidth = 15
            .Columns(4).ColumnWidth = 10
            .Columns(5).ColumnWidth = 5
            .Columns(6).ColumnWidth = 5
            .Columns(7).ColumnWidth = 5
            .Columns(8).ColumnWidth = 5
            .Columns(9).ColumnWidth = 5
            .Columns(10).ColumnWidth = 5
            .Columns(11).ColumnWidth = 5
            .Columns(12).ColumnWidth = 5
            .Columns(13).ColumnWidth = 5
            .Columns(14).ColumnWidth = 5
            .Columns(15).ColumnWidth = 5

            .Columns(16).ColumnWidth = 5
            .Columns(17).ColumnWidth = 5
            .Columns(18).ColumnWidth = 5
            .Columns(19).ColumnWidth = 5

        End With

        With ExcelSheets
            .Range("D1", "U4").Font.Bold = True
            .Range("D1", "U4").Merge(True)
            .Range("D1", "U4").MergeCells = True
            .Range("D1", "U4").Font.Size = 16
            .Range("D1", "U4").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("D1", "U4").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("D1", "U4").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("D1", "U4").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TD1", Commons.Modules.TypeLanguage) & vbLf & vThang.ToString("MMM-yyyy", System.Globalization.CultureInfo.CurrentCulture)

            .Range("V1", "V1").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("V1", "V1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "DocNo", Commons.Modules.TypeLanguage)
            .Range("V2", "V2").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("V2", "V2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "RevNo", Commons.Modules.TypeLanguage)
            .Range("V3", "V3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("V3", "V3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "RevDate", Commons.Modules.TypeLanguage)
            .Range("V4", "V4").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("V4", "V4").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "pageNo", Commons.Modules.TypeLanguage)


            .Range("A3", "C3").Merge(True)
            .Range("A3", "C3").MergeCells = True
            .Range("A3", "C3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A3", "C3").Value = cbxNhaXuong.Text

            .Range("A4", "C4").Merge(True)
            .Range("A4", "C4").MergeCells = True
            .Range("A4", "C4").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A4", "C4").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "Engineering", Commons.Modules.TypeLanguage)

        End With

        Dim chChar As Char = "A"
        If sotuan = 4 Then
            With ExcelSheets
                .Range("A6", "W7").Font.Bold = True
                .Range("A6", "W7").Interior.Color = RGB(250, 240, 60)
                .Range("A6", "W7").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A6", "W7").VerticalAlignment = XlVAlign.xlVAlignCenter

                .Range("A6", "A7").Merge(True)
                .Range("A6", "A7").MergeCells = True
                .Range("A6", "A7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A6", "A7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "NO", Commons.Modules.TypeLanguage)

                .Range("B6", "B7").Merge(True)
                .Range("B6", "B7").MergeCells = True
                .Range("B6", "B7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("B6", "B7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "IDCODE", Commons.Modules.TypeLanguage)

                .Range("C6", "C7").Merge(True)
                .Range("C6", "C7").MergeCells = True
                .Range("C6", "C7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("C6", "C7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "MACHINE_NAME", Commons.Modules.TypeLanguage)

                .Range("D6", "E7").Merge(True)
                .Range("D6", "E7").MergeCells = True
                .Range("D6", "E7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("D6", "E7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "MODEL", Commons.Modules.TypeLanguage)

                .Range("F6", "F7").Merge(True)
                .Range("F6", "F7").MergeCells = True
                .Range("F6", "F7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("F6", "F7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "QTY", Commons.Modules.TypeLanguage)

                .Range("G6", "K6").Merge(True)
                .Range("G6", "K6").MergeCells = True
                .Range("G6", "K6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G6", "K6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "LOSS_FOR_REPAIR", Commons.Modules.TypeLanguage)

                .Range("G7", "G7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G7", "G7").Value = "W" & vTuanBD

                .Range("H7", "H7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("H7", "H7").Value = "W" & vTuanBD + 1

                .Range("I7", "I7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("I7", "I7").Value = "W" & vTuanBD + 2

                .Range("J7", "J7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("J7", "J7").Value = "W" & vTuanBD + 3

                .Range("K7", "K7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("K7", "K7").Value = "TT"

                .Range("L6", "P6").Merge(True)
                .Range("L6", "P6").MergeCells = True
                .Range("L6", "P6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("L6", "P6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TIMES_FOR_DAMAGE", Commons.Modules.TypeLanguage)

                .Range("L7", "L7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("L7", "L7").Value = "W" & vTuanBD

                .Range("M7", "M7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("M7", "M7").Value = "W" & vTuanBD + 1

                .Range("N7", "N7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("N7", "N7").Value = "W" & vTuanBD + 2

                .Range("O7", "O7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("O7", "O7").Value = "W" & vTuanBD + 3

                .Range("P7", "P7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("P7", "P7").Value = "TT"

                .Range("Q6", "V6").Merge(True)
                .Range("Q6", "V6").MergeCells = True
                .Range("Q6", "V6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Q6", "V6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "LOSS_TIME_FOR_MAINT", Commons.Modules.TypeLanguage)

                .Range("Q7", "Q7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Q7", "Q7").Value = "W" & vTuanBD

                .Range("R7", "R7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("R7", "R7").Value = "W" & vTuanBD + 1

                .Range("S7", "S7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("S7", "S7").Value = "W" & vTuanBD + 2

                .Range("T7", "T7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("T7", "T7").Value = "W" & vTuanBD + 3

                .Range("U7", "U7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("U7", "U7").Value = "TT"

                .Range("V7", "V7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("V7", "V7").Value = "TIME"

                .Range("W6", "W7").Merge(True)
                .Range("W6", "W7").MergeCells = True
                .Range("W6", "W7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("W6", "W7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "Remark", Commons.Modules.TypeLanguage)
            End With

            Dim vDong As Integer = 7
            Dim STT As Integer = 0
            For Each vrow As DataRow In vtbData.Rows
                vDong = vDong + 1
                STT = STT + 1
                With ExcelSheets

                    .Range("A" & vDong, "A" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("A" & vDong, "A" & vDong).Value = STT.ToString()

                    .Range("B" & vDong, "B" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("B" & vDong, "B" & vDong).Value = vrow("MS_MAY").ToString

                    .Range("C" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("C" & vDong, "C" & vDong).Value = vrow("TEN_MAY").ToString

                    .Range("D" & vDong, "E" & vDong).Merge(True)
                    .Range("D" & vDong, "E" & vDong).MergeCells = True
                    .Range("D" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    .Range("D" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("D" & vDong, "E" & vDong).Value = vrow("MODEL").ToString

                    .Range("F" & vDong, "F" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("F" & vDong, "F" & vDong).Value = vrow("QTY").ToString

                    .Range("G" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("G" & vDong, "G" & vDong).NumberFormat = "0.0"
                    .Range("G" & vDong, "G" & vDong).Value = vrow("T1") / 60

                    .Range("H" & vDong, "H" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("H" & vDong, "H" & vDong).NumberFormat = "0.0"
                    .Range("H" & vDong, "H" & vDong).Value = vrow("T2") / 60

                    .Range("I" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("I" & vDong, "I" & vDong).NumberFormat = "0.0"
                    .Range("I" & vDong, "I" & vDong).Value = vrow("T3") / 60

                    .Range("J" & vDong, "J" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("J" & vDong, "J" & vDong).NumberFormat = "0.0"
                    .Range("J" & vDong, "J" & vDong).Value = vrow("T4") / 60

                    .Range("K" & vDong, "K" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("K" & vDong, "K" & vDong).NumberFormat = "0.0"
                    .Range("K" & vDong, "K" & vDong).Value = "= SUM(G" & vDong & ":J" & vDong & ")"

                    .Range("L" & vDong, "L" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("L" & vDong, "L" & vDong).Value = vrow("TT1")

                    .Range("M" & vDong, "M" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("M" & vDong, "M" & vDong).Value = vrow("TT2")

                    .Range("N" & vDong, "N" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("N" & vDong, "N" & vDong).Value = vrow("TT3")

                    .Range("O" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("O" & vDong, "O" & vDong).Value = vrow("TT4")

                    .Range("P" & vDong, "P" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("P" & vDong, "P" & vDong).Value = "= SUM(L" & vDong & ":O" & vDong & ")"

                    .Range("Q" & vDong, "Q" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("Q" & vDong, "Q" & vDong).NumberFormat = "0.0"
                    .Range("Q" & vDong, "Q" & vDong).Value = vrow("DKT1") / 60

                    .Range("R" & vDong, "R" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("R" & vDong, "R" & vDong).NumberFormat = "0.0"
                    .Range("R" & vDong, "R" & vDong).Value = vrow("DKT2") / 60

                    .Range("S" & vDong, "S" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("S" & vDong, "S" & vDong).NumberFormat = "0.0"
                    .Range("S" & vDong, "S" & vDong).Value = vrow("DKT3") / 60

                    .Range("T" & vDong, "T" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("T" & vDong, "T" & vDong).NumberFormat = "0.0"
                    .Range("T" & vDong, "T" & vDong).Value = vrow("DKT4") / 60

                    .Range("U" & vDong, "U" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("U" & vDong, "U" & vDong).Value = "= SUM(Q" & vDong & ":T" & vDong & ")"

                    .Range("V" & vDong, "V" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("V" & vDong, "V" & vDong).Value = vrow("BTTIMES")

                    .Range("W" & vDong, "W" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("W" & vDong, "W" & vDong).Value = ""
                End With
            Next
            ' Xuat bieu do =Sheet1!$C$6:$C$9,Sheet1!$F$6:$F$9,Sheet1!$J$6:$J$9

            Dim vLeft As Integer = 10
            Dim vTop As Integer = 10
            Dim vH As Integer = 250

            vTop = (vDong) * ExcelSheets.Range("A7", "X7").Height + 20

            Dim chartObjs As ChartObjects
            chartObjs = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
            Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, ExcelSheets.Range("A7", "Z7").Width, 300)
            Dim xlChart As Chart = chartObj.Chart

            Dim rgEqui As Excel.Range

            rgEqui = ExcelSheets.Range("$B$8:$B$" & vDong & ",$P$8:$P$" & vDong & ",$K$8:$K$" & vDong)

            xlChart.SetSourceData(rgEqui, Excel.XlRowCol.xlColumns)
            xlChart.ChartType = XlChartType.xlColumnStacked
            xlChart.HasTitle = True
            xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TIEU_DE_BD", Commons.Modules.TypeLanguage)

            'xlChart.Legend.Delete()
            xlChart.ChartArea.Border.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Border.Color = RGB(255, 255, 255)


            With xlChart
                .SeriesCollection(1).Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "SERIES_1", Commons.Modules.TypeLanguage)
                .SeriesCollection(2).Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "SERIES_2", Commons.Modules.TypeLanguage)

            End With

            With xlChart
                Dim xlAxisCategory As Excel.Axes
                Dim xlAxisValue As Excel.Axes

                xlAxisCategory = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).HasTitle = True
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "THIET_BI", Commons.Modules.TypeLanguage)

                xlAxisValue = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisValue.Item(Excel.XlAxisType.xlValue).HasTitle = True
                xlAxisValue.Item(Excel.XlAxisType.xlValue).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TITLE_2", Commons.Modules.TypeLanguage)

            End With

        End If

        If sotuan = 5 Then
            With ExcelSheets
                .Range("A6", "Z7").Font.Bold = True
                .Range("A6", "Z7").Interior.Color = RGB(250, 240, 60)
                .Range("A6", "Z7").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A6", "Z7").VerticalAlignment = XlVAlign.xlVAlignCenter

                .Range("A6", "A7").Merge(True)
                .Range("A6", "A7").MergeCells = True
                .Range("A6", "A7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A6", "A7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "NO", Commons.Modules.TypeLanguage)

                .Range("B6", "B7").Merge(True)
                .Range("B6", "B7").MergeCells = True
                .Range("B6", "B7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("B6", "B7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "IDCODE", Commons.Modules.TypeLanguage)

                .Range("C6", "C7").Merge(True)
                .Range("C6", "C7").MergeCells = True
                .Range("C6", "C7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("C6", "C7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "MACHINE_NAME", Commons.Modules.TypeLanguage)

                .Range("D6", "E7").Merge(True)
                .Range("D6", "E7").MergeCells = True
                .Range("D6", "E7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("D6", "E7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "MODEL", Commons.Modules.TypeLanguage)

                .Range("F6", "F7").Merge(True)
                .Range("F6", "F7").MergeCells = True
                .Range("F6", "F7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("F6", "F7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "QTY", Commons.Modules.TypeLanguage)

                .Range("G6", "L6").Merge(True)
                .Range("G6", "L6").MergeCells = True
                .Range("G6", "L6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G6", "L6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "LOSS_FOR_REPAIR", Commons.Modules.TypeLanguage)

                .Range("G7", "G7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G7", "G7").Value = "W" & vTuanBD

                .Range("H7", "H7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("H7", "H7").Value = "W" & vTuanBD + 1

                .Range("I7", "I7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("I7", "I7").Value = "W" & vTuanBD + 2

                .Range("J7", "J7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("J7", "J7").Value = "W" & vTuanBD + 3

                .Range("K7", "K7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("K7", "K7").Value = "W" & vTuanBD + 4

                .Range("L7", "L7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("L7", "L7").Value = "TT"

                .Range("M6", "R6").Merge(True)
                .Range("M6", "R6").MergeCells = True
                .Range("M6", "R6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("M6", "R6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TIMES_FOR_DAMAGE", Commons.Modules.TypeLanguage)

                .Range("M7", "M7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("M7", "M7").Value = "W" & vTuanBD

                .Range("N7", "N7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("N7", "N7").Value = "W" & vTuanBD + 1

                .Range("O7", "O7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("O7", "O7").Value = "W" & vTuanBD + 2

                .Range("P7", "P7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("P7", "P7").Value = "W" & vTuanBD + 3

                .Range("Q7", "Q7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Q7", "Q7").Value = "W" & vTuanBD + 4

                .Range("R7", "R7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("R7", "R7").Value = "TT"

                .Range("S6", "Y6").Merge(True)
                .Range("S6", "Y6").MergeCells = True
                .Range("S6", "Y6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("S6", "Y6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "LOSS_TIME_FOR_MAINT", Commons.Modules.TypeLanguage)

                .Range("S7", "S7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("S7", "S7").Value = "W" & vTuanBD

                .Range("T7", "T7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("T7", "T7").Value = "W" & vTuanBD + 1

                .Range("U7", "U7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("U7", "U7").Value = "W" & vTuanBD + 2

                .Range("V7", "V7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("V7", "V7").Value = "W" & vTuanBD + 3

                .Range("W7", "W7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("W7", "W7").Value = "W" & vTuanBD + 4

                .Range("X7", "X7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("X7", "X7").Value = "TT"

                .Range("Y7", "Y7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Y7", "Y7").Value = "TIME"

                .Range("Z6", "Z7").Merge(True)
                .Range("Z6", "Z7").MergeCells = True
                .Range("Z6", "Z7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Z6", "Z7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "Remark", Commons.Modules.TypeLanguage)

            End With

            Dim vDong As Integer = 7
            Dim STT As Integer = 0
            For Each vrow As DataRow In vtbData.Rows
                vDong = vDong + 1
                STT = STT + 1
                With ExcelSheets

                    .Range("A" & vDong, "A" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("A" & vDong, "A" & vDong).Value = STT.ToString()

                    .Range("B" & vDong, "B" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("B" & vDong, "B" & vDong).Value = vrow("MS_MAY").ToString

                    .Range("C" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("C" & vDong, "C" & vDong).Value = vrow("TEN_MAY").ToString

                    .Range("D" & vDong, "E" & vDong).Merge(True)
                    .Range("D" & vDong, "E" & vDong).MergeCells = True
                    .Range("D" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    .Range("D" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("D" & vDong, "E" & vDong).Value = vrow("MODEL").ToString

                    .Range("F" & vDong, "F" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("F" & vDong, "F" & vDong).Value = vrow("QTY").ToString

                    .Range("G" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("G" & vDong, "G" & vDong).NumberFormat = "0.0"
                    .Range("G" & vDong, "G" & vDong).Value = vrow("T1") / 60

                    .Range("H" & vDong, "H" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("H" & vDong, "H" & vDong).NumberFormat = "0.0"
                    .Range("H" & vDong, "H" & vDong).Value = vrow("T2") / 60

                    .Range("I" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("I" & vDong, "I" & vDong).NumberFormat = "0.0"
                    .Range("I" & vDong, "I" & vDong).Value = vrow("T3") / 60

                    .Range("J" & vDong, "J" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("J" & vDong, "J" & vDong).NumberFormat = "0.0"
                    .Range("J" & vDong, "J" & vDong).Value = vrow("T4") / 60

                    .Range("K" & vDong, "K" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("K" & vDong, "K" & vDong).NumberFormat = "0.0"
                    .Range("K" & vDong, "K" & vDong).Value = vrow("T5") / 60

                    .Range("L" & vDong, "L" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("L" & vDong, "L" & vDong).Value = "= SUM(G" & vDong & ":K" & vDong & ")"

                    .Range("M" & vDong, "M" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("M" & vDong, "M" & vDong).Value = vrow("TT1")

                    .Range("N" & vDong, "N" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("N" & vDong, "N" & vDong).Value = vrow("TT2")

                    .Range("O" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("O" & vDong, "O" & vDong).Value = vrow("TT3")

                    .Range("P" & vDong, "P" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("P" & vDong, "P" & vDong).Value = vrow("TT4")

                    .Range("Q" & vDong, "Q" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("Q" & vDong, "Q" & vDong).Value = vrow("TT5")

                    .Range("R" & vDong, "R" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("R" & vDong, "R" & vDong).Value = "= SUM(M" & vDong & ":Q" & vDong & ")"

                    .Range("S" & vDong, "S" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("S" & vDong, "S" & vDong).NumberFormat = "0.0"
                    .Range("S" & vDong, "S" & vDong).Value = vrow("DKT1") / 60

                    .Range("T" & vDong, "T" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("T" & vDong, "T" & vDong).NumberFormat = "0.0"
                    .Range("T" & vDong, "T" & vDong).Value = vrow("DKT2") / 60

                    .Range("U" & vDong, "U" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("U" & vDong, "U" & vDong).NumberFormat = "0.0"
                    .Range("U" & vDong, "U" & vDong).Value = vrow("DKT3") / 60

                    .Range("V" & vDong, "V" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("V" & vDong, "V" & vDong).NumberFormat = "0.0"
                    .Range("V" & vDong, "V" & vDong).Value = vrow("DKT4") / 60

                    .Range("W" & vDong, "W" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("W" & vDong, "W" & vDong).NumberFormat = "0.0"
                    .Range("W" & vDong, "W" & vDong).Value = vrow("DKT5") / 60

                    .Range("X" & vDong, "X" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("X" & vDong, "X" & vDong).Value = "= SUM(S" & vDong & ":W" & vDong & ")"

                    .Range("Y" & vDong, "Y" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("Y" & vDong, "Y" & vDong).Value = vrow("BTTIMES")

                    .Range("Z" & vDong, "Z" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("Z" & vDong, "Z" & vDong).Value = ""

                End With
            Next

            ' Xuat bieu do =Sheet1!$C$6:$C$9,Sheet1!$F$6:$F$9,Sheet1!$J$6:$J$9

            Dim vLeft As Integer = 10
            Dim vTop As Integer = 10
            Dim vH As Integer = 250

            vTop = (vDong) * ExcelSheets.Range("A7", "X7").Height + 20

            Dim chartObjs As ChartObjects
            chartObjs = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
            Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, ExcelSheets.Range("A7", "X7").Width, 300)
            Dim xlChart As Chart = chartObj.Chart

            Dim rgEqui As Excel.Range

            rgEqui = ExcelSheets.Range("$B$8:$B$" & vDong & ",$R$8:$R$" & vDong & ",$L$8:$L$" & vDong)

            xlChart.SetSourceData(rgEqui, Excel.XlRowCol.xlColumns)
            xlChart.ChartType = XlChartType.xlColumnStacked
            xlChart.HasTitle = True
            xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TIEU_DE_BD", Commons.Modules.TypeLanguage)

            'xlChart.Legend.Delete()
            xlChart.ChartArea.Border.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Border.Color = RGB(255, 255, 255)


            With xlChart
                .SeriesCollection(1).Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "SERIES_1", Commons.Modules.TypeLanguage)
                .SeriesCollection(2).Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "SERIES_2", Commons.Modules.TypeLanguage)

            End With

            With xlChart
                Dim xlAxisCategory As Excel.Axes
                Dim xlAxisValue As Excel.Axes

                xlAxisCategory = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).HasTitle = True
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "THIET_BI", Commons.Modules.TypeLanguage)

                xlAxisValue = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisValue.Item(Excel.XlAxisType.xlValue).HasTitle = True
                xlAxisValue.Item(Excel.XlAxisType.xlValue).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TITLE_2", Commons.Modules.TypeLanguage)

            End With

        End If

        If sotuan = 6 Then
            With ExcelSheets
                .Range("A6", "AC7").Font.Bold = True
                .Range("A6", "AC7").Interior.Color = RGB(250, 240, 60)
                .Range("A6", "AC7").HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A6", "AC7").VerticalAlignment = XlVAlign.xlVAlignCenter

                .Range("A6", "A7").Merge(True)
                .Range("A6", "A7").MergeCells = True
                .Range("A6", "A7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A6", "A7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "NO", Commons.Modules.TypeLanguage)

                .Range("B6", "B7").Merge(True)
                .Range("B6", "B7").MergeCells = True
                .Range("B6", "B7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("B6", "B7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "IDCODE", Commons.Modules.TypeLanguage)

                .Range("C6", "C7").Merge(True)
                .Range("C6", "C7").MergeCells = True
                .Range("C6", "C7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("C6", "C7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "MACHINE_NAME", Commons.Modules.TypeLanguage)

                .Range("D6", "E7").Merge(True)
                .Range("D6", "E7").MergeCells = True
                .Range("D6", "E7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("D6", "E7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "MODEL", Commons.Modules.TypeLanguage)

                .Range("F6", "F7").Merge(True)
                .Range("F6", "F7").MergeCells = True
                .Range("F6", "F7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("F6", "F7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "QTY", Commons.Modules.TypeLanguage)

                .Range("G6", "M6").Merge(True)
                .Range("G6", "M6").MergeCells = True
                .Range("G6", "M6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G6", "M6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "LOSS_FOR_REPAIR", Commons.Modules.TypeLanguage)

                .Range("G7", "G7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G7", "G7").Value = "W" & vTuanBD

                .Range("H7", "H7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("H7", "H7").Value = "W" & vTuanBD + 1

                .Range("I7", "I7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("I7", "I7").Value = "W" & vTuanBD + 2

                .Range("J7", "J7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("J7", "J7").Value = "W" & vTuanBD + 3

                .Range("K7", "K7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("K7", "K7").Value = "W" & vTuanBD + 4

                .Range("L7", "L7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("L7", "L7").Value = "W" & vTuanBD + 5

                .Range("M7", "M7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("M7", "M7").Value = "TT"

                .Range("N6", "T6").Merge(True)
                .Range("N6", "T6").MergeCells = True
                .Range("N6", "T6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("N6", "T6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TIMES_FOR_DAMAGE", Commons.Modules.TypeLanguage)

                .Range("N7", "N7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("N7", "N7").Value = "W" & vTuanBD

                .Range("O7", "O7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("O7", "O7").Value = "W" & vTuanBD + 1

                .Range("P7", "P7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("P7", "P7").Value = "W" & vTuanBD + 2

                .Range("Q7", "Q7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Q7", "Q7").Value = "W" & vTuanBD + 3

                .Range("R7", "R7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("R7", "R7").Value = "W" & vTuanBD + 4

                .Range("S7", "Y7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("S7", "Y7").Value = "W" & vTuanBD + 5

                .Range("T7", "T7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("T7", "T7").Value = "TT"

                .Range("U6", "AB6").Merge(True)
                .Range("U6", "AB6").MergeCells = True
                .Range("U6", "AB6").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("U6", "AB6").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "LOSS_TIME_FOR_MAINT", Commons.Modules.TypeLanguage)

                .Range("U7", "U7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("U7", "U7").Value = "W" & vTuanBD

                .Range("V7", "V7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("V7", "V7").Value = "W" & vTuanBD + 1


                .Range("W7", "W7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("W7", "W7").Value = "W" & vTuanBD + 2


                .Range("X7", "X7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("X7", "X7").Value = "W" & vTuanBD + 3

                .Range("Y7", "Y7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Y7", "Y7").Value = "W" & vTuanBD + 4

                .Range("Z7", "Z7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("Z7", "Z7").Value = "W" & vTuanBD + 5

                .Range("AA7", "AA7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("AA7", "AA7").Value = "TT"

                .Range("AB7", "AB7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("AB7", "AB7").Value = "TIME"

                .Range("AC6", "AC7").Merge(True)
                .Range("AC6", "AC7").MergeCells = True
                .Range("AC6", "AC7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("AC6", "AC7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "Remark", Commons.Modules.TypeLanguage)

            End With

            Dim vDong As Integer = 7
            Dim STT As Integer = 0
            For Each vrow As DataRow In vtbData.Rows
                vDong = vDong + 1
                STT = STT + 1
                With ExcelSheets

                    .Range("A" & vDong, "A" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("A" & vDong, "A" & vDong).Value = STT.ToString()

                    .Range("B" & vDong, "B" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("B" & vDong, "B" & vDong).Value = vrow("MS_MAY").ToString

                    .Range("C" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("C" & vDong, "C" & vDong).Value = vrow("TEN_MAY").ToString

                    .Range("D" & vDong, "E" & vDong).Merge(True)
                    .Range("D" & vDong, "E" & vDong).MergeCells = True
                    .Range("D" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    .Range("D" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("D" & vDong, "E" & vDong).Value = vrow("MODEL").ToString

                    .Range("F" & vDong, "F" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("F" & vDong, "F" & vDong).Value = vrow("QTY").ToString

                    .Range("G" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("G" & vDong, "G" & vDong).NumberFormat = "0.0"
                    .Range("G" & vDong, "G" & vDong).Value = vrow("T1") / 60

                    .Range("H" & vDong, "H" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("H" & vDong, "H" & vDong).NumberFormat = "0.0"
                    .Range("H" & vDong, "H" & vDong).Value = vrow("T2") / 60

                    .Range("I" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("I" & vDong, "I" & vDong).NumberFormat = "0.0"
                    .Range("I" & vDong, "I" & vDong).Value = vrow("T3") / 60

                    .Range("J" & vDong, "J" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("J" & vDong, "J" & vDong).NumberFormat = "0.0"
                    .Range("J" & vDong, "J" & vDong).Value = vrow("T4") / 60

                    .Range("K" & vDong, "K" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("K" & vDong, "K" & vDong).NumberFormat = "0.0"
                    .Range("K" & vDong, "K" & vDong).Value = vrow("T5") / 60

                    .Range("L" & vDong, "L" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("L" & vDong, "L" & vDong).NumberFormat = "0.0"
                    .Range("L" & vDong, "L" & vDong).Value = vrow("T6") / 60

                    .Range("M" & vDong, "M" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("M" & vDong, "M" & vDong).Value = "= SUM(G" & vDong & ":L" & vDong & ")"

                    .Range("N" & vDong, "N" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("N" & vDong, "N" & vDong).Value = vrow("TT1")

                    .Range("O" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("O" & vDong, "O" & vDong).Value = vrow("TT2")

                    .Range("P" & vDong, "P" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("P" & vDong, "P" & vDong).Value = vrow("TT3")

                    .Range("Q" & vDong, "Q" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("Q" & vDong, "Q" & vDong).Value = vrow("TT4")

                    .Range("R" & vDong, "R" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("R" & vDong, "R" & vDong).Value = vrow("TT5")

                    .Range("S" & vDong, "S" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("S" & vDong, "S" & vDong).Value = vrow("TT6")

                    .Range("T" & vDong, "T" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("T" & vDong, "T" & vDong).Value = "= SUM(N" & vDong & ":S" & vDong & ")"

                    .Range("U" & vDong, "U" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("U" & vDong, "U" & vDong).NumberFormat = "0.0"
                    .Range("U" & vDong, "U" & vDong).Value = vrow("DKT1") / 60

                    .Range("V" & vDong, "V" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("V" & vDong, "V" & vDong).NumberFormat = "0.0"
                    .Range("V" & vDong, "V" & vDong).Value = vrow("DKT2") / 60

                    .Range("W" & vDong, "W" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("W" & vDong, "W" & vDong).NumberFormat = "0.0"
                    .Range("W" & vDong, "W" & vDong).Value = vrow("DKT3") / 60

                    .Range("X" & vDong, "X" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("X" & vDong, "X" & vDong).NumberFormat = "0.0"
                    .Range("X" & vDong, "X" & vDong).Value = vrow("DKT4") / 60

                    .Range("Y" & vDong, "Y" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("Y" & vDong, "Y" & vDong).NumberFormat = "0.0"
                    .Range("Y" & vDong, "Y" & vDong).Value = vrow("DKT5") / 60

                    .Range("Z" & vDong, "Z" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("Z" & vDong, "Z" & vDong).NumberFormat = "0.0"
                    .Range("Z" & vDong, "Z" & vDong).Value = vrow("DKT6") / 60

                    .Range("AA" & vDong, "AA" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("AA" & vDong, "AA" & vDong).Value = "= SUM(U" & vDong & ":Z" & vDong & ")"

                    .Range("AB" & vDong, "AB" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("AB" & vDong, "AB" & vDong).Value = vrow("BTTIMES")

                    .Range("AC" & vDong, "AC" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("AC" & vDong, "AC" & vDong).Value = ""
                End With
            Next

            ' Xuat bieu do =Sheet1!$C$6:$C$9,Sheet1!$F$6:$F$9,Sheet1!$J$6:$J$9

            Dim vLeft As Integer = 10
            Dim vTop As Integer = 10
            Dim vH As Integer = 250

            vTop = (vDong) * ExcelSheets.Range("A7", "X7").Height + 20

            Dim chartObjs As ChartObjects
            chartObjs = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
            Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, ExcelSheets.Range("A7", "X7").Width, 300)
            Dim xlChart As Chart = chartObj.Chart

            Dim rgEqui As Excel.Range

            rgEqui = ExcelSheets.Range("$B$8:$B$" & vDong & ",$T$8:$T$" & vDong & ",$M$8:$M$" & vDong)

            xlChart.SetSourceData(rgEqui, Excel.XlRowCol.xlColumns)
            xlChart.ChartType = XlChartType.xlColumnStacked
            xlChart.HasTitle = True
            xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TIEU_DE_BD", Commons.Modules.TypeLanguage)

            'xlChart.Legend.Delete()
            xlChart.ChartArea.Border.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Border.Color = RGB(255, 255, 255)


            With xlChart
                .SeriesCollection(1).Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "SERIES_1", Commons.Modules.TypeLanguage)
                .SeriesCollection(2).Name = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "SERIES_2", Commons.Modules.TypeLanguage)

            End With

            With xlChart
                Dim xlAxisCategory As Excel.Axes
                Dim xlAxisValue As Excel.Axes

                xlAxisCategory = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).HasTitle = True
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "THIET_BI", Commons.Modules.TypeLanguage)

                xlAxisValue = CType(xlChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisValue.Item(Excel.XlAxisType.xlValue).HasTitle = True
                xlAxisValue.Item(Excel.XlAxisType.xlValue).AxisTitle.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptMAINTENANCT_REPORT_MONTHLY", "TITLE_2", Commons.Modules.TypeLanguage)

            End With
        End If
        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmrptMAINTENANCT_REPORT_MONTHLY_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadThangNgungMay()
        LoadDiaDiem()
    End Sub

    Sub loadThangNgungMay()
        Dim vtb As System.Data.DataTable = New System.Data.DataTable
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_THANG_NGUNG_MAY_CSWIND"))
        cbxThang.DisplayMember = "THANG_NAM"
        cbxThang.ValueMember = "THANG_NAM_ORDER"
        cbxThang.DataSource = vtb
    End Sub

    Sub LoadDiaDiem()
        cbxNhaXuong.Value = "MS_N_XUONG"
        cbxNhaXuong.Display = "Ten_N_XUONG"
        cbxNhaXuong.StoreName = "H_GET_NHA_XUONG_FILTER"
        cbxNhaXuong.BindDataSource()
    End Sub

    Function SoTuanTrongThang(ByVal vThang As String) As Integer
        Dim vSoTuan As Integer = 0
        Dim vObjBD As Object
        Dim vObjKT As Object

        If vThang.Length = 6 Then
            vThang = "0" + vThang
        End If

        Dim vDauThang As New DateTime
        Dim vCuoiThang As DateTime

        vDauThang = DateTime.ParseExact("01/" + vThang, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vCuoiThang = vDauThang.AddDays(DateTime.DaysInMonth(vDauThang.Year, vDauThang.Month) - 1)

        vObjBD = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_GET_TUAN", vDauThang)
        vObjKT = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_GET_TUAN", vCuoiThang)

        Dim vTuanBD As Integer = 0
        Dim vTuanKT As Integer = 0

        vTuanBD = CType(vObjBD, Integer)
        vTuanKT = CType(vObjKT, Integer)

        vSoTuan = (vTuanKT - vTuanBD) + 1

        'If vThang.Length = 6 Then
        '    vThang = "0" + vThang
        'End If

        'vDauThang = DateTime.ParseExact("01/" + vThang, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        'Dim vCuoiThang As DateTime
        'vCuoiThang = vDauThang.AddDays(DateTime.DaysInMonth(vDauThang.Year, vDauThang.Month) - 1)
        'While vDauThang < vCuoiThang Or vDauThang.AddDays(-6) <= vCuoiThang
        '    vSoTuan = vSoTuan + 1
        '    vDauThang = vDauThang.AddDays(7)
        'End While
        Return vSoTuan
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
