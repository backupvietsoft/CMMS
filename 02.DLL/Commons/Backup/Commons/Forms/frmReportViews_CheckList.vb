Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class frmReportViews_CheckList
    Public tieuDe As String
    Public vtbData As New System.Data.DataTable()
    Public loaivt As String
    Public kho As String
    Public ngay As String
    Public count As Integer
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
        lblTitle.Text = tieuDe
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

        Dim fileDialog As SaveFileDialog = New SaveFileDialog()
        fileDialog.Filter = "Excel file (*.xls)|*.xls"
        If fileDialog.ShowDialog() = DialogResult.OK Then
            grvView.ExportToXls(fileDialog.FileName)
            Dim excelApplication As Excel.Application = New Excel.Application()
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(fileDialog.FileName, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)
            Dim excelRange As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A1", "A5")
            excelRange.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown)
            Dim countColumn As Integer = vtbData.Columns.Count
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
            excelWorkSheet.Cells(2, 1) = ngay
            Dim excelRange3 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(3, 1), excelWorkSheet.Cells(3, countColumn))
            excelRange3.Merge()
            excelRange3.Font.Name = "Tahoma"
            excelRange3.Font.Size = 11
            excelRange3.Font.Bold = True
            excelWorkSheet.Cells(3, 1) = kho
            Dim excelRange4 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(4, 1), excelWorkSheet.Cells(4, countColumn))
            excelRange4.Merge()
            excelRange4.Font.Name = "Tahoma"
            excelRange4.Font.Size = 11
            excelRange4.Font.Bold = True
            excelWorkSheet.Cells(4, 1) = loaivt

            Dim excelContent As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(7, 2), excelWorkSheet.Cells(count + 7, countColumn))
            excelContent.NumberFormat = "###,##0.00"
            Dim c = count + 7
            Dim excelTotal As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A" & c, "A" & c)
            excelWorkSheet.Cells(c, 1) = "Total"
            excelTotal.Font.Bold = True

            Dim excelSum As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(c, 2), excelWorkSheet.Cells(c, countColumn))
            Dim i As Integer
            Dim j As Integer
            For i = 0 To countColumn - 2
                If (66 + i) > 90 Then
                    excelWorkSheet.Cells(c, i + 2) = "=SUM(" & Chr(65) & Chr(65 + j) & 7 & ":" & Chr(65) & Chr(65 + j) & c - 1 & ")"

                    j = j + 1
                Else
                    excelWorkSheet.Cells(c, i + 2) = "=SUM(" & Chr(66 + i) & 7 & ":" & Chr(66 + i) & c - 1 & ")"
                End If

            Next i
            excelSum.Font.Bold = True
            excelSum.NumberFormat = "###,##0.00"
            excelWorkSheet.Columns.AutoFit()
            excelApplication.ActiveWindow.DisplayGridlines = True
            excelApplication.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo
        End If
    End Sub
End Class