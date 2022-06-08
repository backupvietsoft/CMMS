Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class frmReportViews_SewingDaily

    Public tieuDe As String
    Public vtbData As New System.Data.DataTable()
    Public vMonth As String
    Public warehouse As String
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
            excelWorkSheet.Cells(1, 1) = tieuDe

            Dim excelRange2 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(2, 1), excelWorkSheet.Cells(2, countColumn))
            excelRange2.Merge()
            excelRange2.Font.Name = "Tahoma"
            excelRange2.Font.Size = 11
            excelRange2.Font.Bold = True
            excelRange2.VerticalAlignment = XlVAlign.xlVAlignCenter
            excelRange2.HorizontalAlignment = XlHAlign.xlHAlignCenter
            excelWorkSheet.Cells(2, 1) = vMonth
            Dim excelRange3 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(3, 1), excelWorkSheet.Cells(3, countColumn))
            excelRange3.Merge()
            excelRange3.Font.Name = "Tahoma"
            excelRange3.Font.Size = 11
            excelRange3.Font.Bold = True
            excelWorkSheet.Cells(3, 1) = warehouse


            Try
                Dim excelContent As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(9, 12), excelWorkSheet.Cells(vtbData.Rows.Count + 50, 13))
                excelContent.NumberFormat = "###,##0.00"
            Catch ex As Exception

            End Try
            excelWorkSheet.Columns.AutoFit()
            excelApplication.ActiveWindow.DisplayGridlines = True
            excelApplication.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo
        End If
    End Sub

    Private Sub frmReportViews_SewingDaily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTitle.Text = tieuDe
    End Sub
End Class