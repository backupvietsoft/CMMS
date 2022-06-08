Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class frmReportViews

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

    End Sub
End Class