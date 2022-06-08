
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptBieuDoKhaNangSanSangLine
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try

            If vTuNgay > vDenNgay Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoKhaNangSanSangLine", "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            '' LAY DU LIEU 

            Dim vtbData As New System.Data.DataTable
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_BD_HIEU_SUAT_AND_KNSS_SD_LINE", vTuNgay, vDenNgay))

            Dim ExcelApp As New Excel.Application
            Dim ExcelBooks As Excel.Workbook
            Dim ExcelSheets As Excel.Worksheet
            ExcelApp.Visible = False
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

            With ExcelSheets
                .Range("A1", "J1").Font.Bold = True
                .Range("A1", "J1").Merge(True)
                .Range("A1", "J1").MergeCells = True
                .Range("A1", "J1").Font.Size = 16
                .Range("A1", "J1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoKhaNangSanSangLine", "TD1", Commons.Modules.TypeLanguage)

                .Range("A2", "J2").Font.Bold = True
                .Range("A2", "J2").Merge(True)
                .Range("A2", "J2").MergeCells = True
                .Range("A2", "J2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoKhaNangSanSangLine", "TD2", Commons.Modules.TypeLanguage)

                .Range("A3", "J4").Font.Bold = True
                .Range("A3", "J4").Merge(True)
                .Range("A3", "J4").MergeCells = True
                .Range("A3", "J4").HorizontalAlignment = XlHAlign.xlHAlignLeft
                .Range("A3", "J4").VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("A3", "J4").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoKhaNangSanSangLine", "TD3", Commons.Modules.TypeLanguage)
            End With

            Dim vDong As Integer = 7
            Dim vColum As Char = "B"

            Dim vtbLine As New System.Data.DataTable
            vtbLine = vtbData.DefaultView.ToTable(True, "MS_HE_THONG", "TEN_HE_THONG")

            For Each rLine As DataRow In vtbLine.Rows
                With ExcelSheets

                    .Range("A" & vDong, "A" & vDong).Merge(True)
                    .Range("A" & vDong, "A" & vDong).MergeCells = True
                    .Range("A" & vDong, "A" & vDong).Value = rLine("TEN_HE_THONG")
                End With
                vDong = vDong + 1
            Next

            With ExcelSheets
                .Range("A" & vDong, "A" & vDong).Merge(True)
                .Range("A" & vDong, "A" & vDong).MergeCells = True
                .Range("A" & vDong, "A" & vDong).Value = "Averange"
            End With


            Dim vThang As New System.Data.DataTable
            vThang = vtbData.DefaultView.ToTable(True, "THANG")

            For Each rThang As DataRow In vThang.Rows
                Dim vdrInMonth As New DataView(vtbData, "THANG = '" & rThang("THANG").ToString & "'", "MS_HE_THONG", DataViewRowState.CurrentRows)
                vDong = 7
                With ExcelSheets
                    .Range(vColum & vDong - 1, vColum & vDong - 1).Merge(True)
                    .Range(vColum & vDong - 1, vColum & vDong - 1).MergeCells = True
                    Dim vtg As DateTime
                    vtg = rThang("THANG")
                    Dim ss As String = vtg.ToString("MMM-yy", System.Globalization.CultureInfo.CurrentCulture)
                    .Range(vColum & vDong - 1, vColum & vDong - 1).Value = rThang("THANG")
                    .Range(vColum & vDong - 1, vColum & vDong - 1).NumberFormat = "MMM-yy"
                End With


                Dim i As Integer = 0
                For Each rDThang As DataRow In vdrInMonth.ToTable.Rows
                    With ExcelSheets
                        .Range(vColum & vDong + i, vColum & vDong + i).Merge(True)
                        .Range(vColum & vDong + i, vColum & vDong + i).MergeCells = True
                        .Range(vColum & vDong + i, vColum & vDong + i).Value = (IIf((rDThang("SO_GIO_KH") - rDThang("SO_GIO_NN")) < 0, 0, (rDThang("SO_GIO_KH") - rDThang("SO_GIO_NN"))) / IIf(rDThang("SO_GIO_KH") = 0, 1, rDThang("SO_GIO_KH"))) * 100
                        .Range(vColum & vDong + i, vColum & vDong + i).NumberFormat = "0.0"
                        i = i + 1
                    End With
                Next

                With ExcelSheets
                    .Range(vColum & vDong + i, vColum & vDong + i).Merge(True)
                    .Range(vColum & vDong + i, vColum & vDong + i).MergeCells = True
                    .Range(vColum & vDong + i, vColum & vDong + i).Value = "=SUM(" & vColum & 7 & ":" & vColum & vDong + i - 1 & ")/" & vtbLine.Rows.Count
                    .Range(vColum & vDong + i, vColum & vDong + i).NumberFormat = "0.0"
                End With

                vColum = Chr(Asc(vColum) + 1)
            Next



            '''''bieu do '''''
            vColum = Chr(Asc(vColum) - 1)
            vDong = vDong - 1
            Dim vLeft As Integer = 20
            Dim vTop As Integer = 100
            Dim vH As Integer = 600


            vTop = vtbLine.Rows.Count * ExcelSheets.Range("A7", "X7").Height + 100

            'vH = (vWith + 4) * ExcelSheets.Range("A7", "X7").Height

            Dim chartObjs As ChartObjects = DirectCast(ExcelSheets.ChartObjects(Type.Missing), ChartObjects)
            Dim chartObj As ChartObject = chartObjs.Add(vLeft, vTop, 700, vH)
            Dim xlChart As Chart = chartObj.Chart


            Dim rgEqui As Excel.Range
            rgEqui = ExcelSheets.Range("A" & vDong, vColum & (vDong + vtbLine.Rows.Count) + 1)

            xlChart.SetSourceData(rgEqui, Excel.XlRowCol.xlRows)

            xlChart.ChartType = XlChartType.xlLineMarkers
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

            'xlChart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary).ticklabels.Orientation = XlTickLabelOrientation.xlTickLabelOrientationAutomatic
            xlChart.HasTitle = True
            xlChart.ChartTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoKhaNangSanSangLine", "CHART_TITLE", Commons.Modules.TypeLanguage)
            xlChart.ChartTitle.Font.Size = 14
            'xlChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom
            xlChart.ChartArea.Border.Color = RGB(10, 10, 255)
            xlChart.PlotArea.Interior.Color = RGB(255, 255, 255)
            xlChart.PlotArea.Border.Color = RGB(0, 255, 255)
            'xlChart.Legend.Border.Color = RGB(255, 255, 255)
            ExcelApp.Visible = True

        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmrptBieuDoKhaNangSanSangLine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vDenNgay = DateTime.Now.Date

        mtxtDenNgay.Text = vDenNgay.Date.ToString("MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        Dim sn As Integer = Date.DaysInMonth(vDenNgay.Year, vDenNgay.Month)
        vDenNgay = DateTime.ParseExact("01/" + mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vTuNgay = vDenNgay.AddYears(-1)
        vDenNgay = vDenNgay.AddDays(Date.DaysInMonth(vDenNgay.Year, vDenNgay.Month) - 1)
        mtxtTuNgay.Text = vTuNgay.Date.ToString("MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            vTuNgay = DateTime.ParseExact("01/" + mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoKhaNangSanSangLine", "KO_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try

    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Try
            vDenNgay = DateTime.ParseExact("01/" + mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            vDenNgay = vDenNgay.AddDays(Date.DaysInMonth(vDenNgay.Year, vDenNgay.Month) - 1)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBieuDoKhaNangSanSangLine", "KO_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub

End Class
