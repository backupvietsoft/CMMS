
Imports Excel
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptThongKeXuatVatTu
    Private frmReportView As frmReportViews = New frmReportViews()
    Private TbSource As System.Data.DataTable = New System.Data.DataTable()
    Private Sub frmrptThongKeXuatVatTu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpTuNgay.Value = DateTime.Now.AddMonths(-1).Date
        dtpDenNgay.Value = DateTime.Now.Date
        Dim TbKho As System.Data.DataTable = New System.Data.DataTable()
        TbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 1, Commons.Modules.UserName))
       
        cboKho.DataSource = TbKho
        cboKho.ValueMember = "MS_KHO"
        cboKho.DisplayMember = "TEN_KHO"
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try

            frmReportView = New frmReportViews()
            TbSource = New System.Data.DataTable
            TbSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_THONG_KE_XUAT_VAT_TU", dtpTuNgay.Value, dtpDenNgay.Value, cboKho.SelectedValue, Commons.Modules.UserName))
            frmReportView.grdView.DataSource = TbSource
            frmReportView.grvView.PopulateColumns()
            frmReportView.grvView.PopulateColumns()
            For i As Integer = 0 To frmReportView.grvView.Columns.Count - 1
                Select Case (i)
                    Case 0
                        frmReportView.grvView.Columns(i).Width = 85
                    Case 1
                        frmReportView.grvView.Columns(i).Width = 120
                    Case 2
                        frmReportView.grvView.Columns(i).Width = 250
                    Case Else
                        frmReportView.grvView.Columns(i).Width = 95
                End Select
                frmReportView.grvView.Columns(i).OptionsColumn.FixedWidth = True
            Next
            frmReportView.ShowDialog()
            AddHandler frmReportView.btnExcel.Click, AddressOf btnExcel_Click
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fileDialog As SaveFileDialog = New SaveFileDialog()
        fileDialog.Filter = "Excel file (*.xls)|*.xls"
        If fileDialog.ShowDialog() = DialogResult.OK Then
            frmReportView.grvView.ExportToXls(fileDialog.FileName)
            Dim excelApplication As Excel.Application = New Excel.Application()
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(fileDialog.FileName, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)
            Dim excelRange As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A1", "A5")
            excelRange.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown)
            Dim excelRange1 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, TbSource.Columns.Count))
            excelRange1.Merge()
            excelRange1.Font.Name = "Tahoma"
            excelRange1.Font.Size = 14
            excelRange1.Font.Bold = True

            excelWorkSheet.Cells(1, 1) = "SPARE PART SEWING & MATERIALS"
            Dim excelRange2 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(2, 1), excelWorkSheet.Cells(2, TbSource.Columns.Count))
            excelRange2.Merge()
            excelRange2.Font.Name = "Tahoma"
            excelRange2.Font.Size = 11
            excelRange2.Font.Bold = True
            excelWorkSheet.Cells(2, 1) = "DEPT: MAINT"
            Dim excelRange3 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(3, 1), excelWorkSheet.Cells(3, TbSource.Columns.Count))
            excelRange3.Merge()
            excelRange3.Font.Name = "Tahoma"
            excelRange3.Font.Size = 11
            excelRange3.Font.Bold = True
            excelWorkSheet.Cells(3, 1) = "WAREHOUSE: " + cboKho.Text.ToUpper()
            Dim excelRange4 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(4, 1), excelWorkSheet.Cells(4, TbSource.Columns.Count))
            excelRange4.Merge()
            excelRange4.Font.Name = "Tahoma"
            excelRange4.Font.Size = 11
            excelRange4.Font.Bold = True
            excelWorkSheet.Cells(4, 1) = "FROM DATE: " + dtpTuNgay.Value.ToString("dd/MM/yyyy")
            Dim excelRange5 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(5, 1), excelWorkSheet.Cells(5, TbSource.Columns.Count))
            excelRange5.Merge()
            excelRange5.Font.Name = "Tahoma"
            excelRange5.Font.Size = 11
            excelRange5.Font.Bold = True
            excelWorkSheet.Cells(5, 1) = "TO DATE: " + dtpDenNgay.Value.ToString("dd/MM/yyyy")
            Dim excelRange6 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(6, 1), excelWorkSheet.Cells(TbSource.Rows.Count + 6, TbSource.Columns.Count))
            excelRange6.Font.Name = "Tahoma"
            excelRange6.Font.Size = 9
            excelRange6.Borders.Value = 1
            excelWorkSheet.Columns.AutoFit()
            excelApplication.ActiveWindow.DisplayGridlines = True
            excelApplication.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
