Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class frmReportViews_Budget
    Public vBUDGET As String
    Public vUSED As String
    Public vBALANCE As String
    Public tieuDe As String
    Public vtbData As New System.Data.DataTable()
    Public vMonth As String
    Public loaiChiuPhi As String
    Public vUnit As String
    Public Dept As String
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Dim fileDialog As SaveFileDialog = New SaveFileDialog()
    '    fileDialog.Filter = "Excel file (*.xls)|*.xls"
    '    If fileDialog.ShowDialog() = DialogResult.OK Then
    '        grvView.ExportToXls(fileDialog.FileName)
    '        Dim excelApplication As Excel.Application = New Excel.Application()
    '        Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
    '        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
    '        Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
    '        Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(fileDialog.FileName, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
    '        Dim excelWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)            
    '        'Dim excelRange As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A1", "A5")
    '        'excelRange.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown)
    '        'Dim excelRange1 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, 10))
    '        'excelRange1.Merge()
    '        'excelWorkSheet.Cells(1, 1) = "SPARE PART SEWING & MATERIALS"
    '        'excelWorkSheet.Cells(2, 1) = "Dept: MAINT"
    '        excelWorkSheet.Columns.AutoFit()
    '        excelApplication.ActiveWindow.DisplayGridlines = True
    '        excelApplication.Visible = True
    '        System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo
    '    End If
    'End Sub

    Private Sub frmReportViews_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "TIEU_DE", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim fileDialog As SaveFileDialog = New SaveFileDialog()
        fileDialog.Filter = "Excel file (*.xls)|*.xls"
        If fileDialog.ShowDialog() = DialogResult.OK Then
            grvView.ExportToXls(fileDialog.FileName)
            Dim count As Integer = vtbData.Rows.Count
            Dim countColumn As Integer = vtbData.Columns.Count
            Dim excelApplication As Excel.Application = New Excel.Application()
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(fileDialog.FileName, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)
            Dim excelRange As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A1", "A5")
            excelRange.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown)
            Dim excelRange1 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, countColumn))
            excelRange1.Merge()
            excelRange1.Font.Name = "Tahoma"
            excelRange1.Font.Size = 14
            excelRange1.Font.Bold = True
            excelRange1.VerticalAlignment = XlVAlign.xlVAlignCenter
            excelRange1.HorizontalAlignment = XlHAlign.xlHAlignCenter
            excelWorkSheet.Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "TIEU_DE", Commons.Modules.TypeLanguage)

            Dim excelRange2 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(2, 1), excelWorkSheet.Cells(2, countColumn))
            excelRange2.Merge()
            excelRange2.Font.Name = "Tahoma"
            excelRange2.Font.Size = 11
            excelRange2.Font.Bold = True
            excelRange2.VerticalAlignment = XlVAlign.xlVAlignCenter
            excelRange2.HorizontalAlignment = XlHAlign.xlHAlignCenter
            excelWorkSheet.Cells(2, 1) = loaiChiuPhi
            Dim excelRange3 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(3, 1), excelWorkSheet.Cells(3, countColumn))
            excelRange3.Merge()
            excelRange3.Font.Name = "Tahoma"
            excelRange3.Font.Size = 11
            excelRange3.Font.Bold = True
            excelWorkSheet.Cells(3, 1) = Dept
            Dim excelRange4 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(4, 1), excelWorkSheet.Cells(4, countColumn))
            excelRange4.Merge()
            excelRange4.Font.Name = "Tahoma"
            excelRange4.Font.Size = 11
            excelRange4.Font.Bold = True
            excelWorkSheet.Cells(4, 1) = vMonth
            Dim excelRange5 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(5, 1), excelWorkSheet.Cells(5, countColumn))
            excelRange5.Merge()
            excelRange5.Font.Name = "Tahoma"
            excelRange5.Font.Size = 11
            excelRange5.Font.Bold = True
            excelWorkSheet.Cells(5, 1) = vUnit
            'Dim excelRange6 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(6, 1), excelWorkSheet.Cells(vtbData.Rows.Count + 6, TbSource.Columns.Count))
            'excelRange6.Font.Name = "Tahoma"
            'excelRange6.Font.Size = 9
            'excelRange6.Borders.Value = 1
            Dim excelRange7 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A7", "A7")
            excelWorkSheet.Cells(7, 1) = vBUDGET
            Dim excelRange8 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A8", "A8")
            excelWorkSheet.Cells(8, 1) = vUSED
            Dim excelRange9 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A9", "A9")
            excelWorkSheet.Cells(9, 1) = vBALANCE

            Dim excelContent As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(7, 2), excelWorkSheet.Cells(count + 20, countColumn))
            excelContent.NumberFormat = "###,##0.00"
            excelWorkSheet.Columns.AutoFit()
            excelApplication.ActiveWindow.DisplayGridlines = True
            excelApplication.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo
        End If
    End Sub
End Class