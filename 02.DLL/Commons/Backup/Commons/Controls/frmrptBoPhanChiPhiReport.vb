
Imports Excel
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Public Class frmrptBoPhanChiPhiReport

    Dim vBUDGET As String
    Dim vUSED As String
    Dim vBALANCE As String
    Dim tieuDe As String
    Dim vtbData As New System.Data.DataTable()
    Dim vMonth As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "MONTH", Commons.Modules.TypeLanguage)
    Dim loaiChiuPhi As String
    Dim vUnit As String
    Dim Dept As String
    Private Sub frmrptBoPhanChiPhiReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLoaiChiuPhi()
        LoadNgoaiTe()
        dtpThang.Value = DateTime.Now.Date
    End Sub
    Private Sub LoadLoaiChiuPhi()
        Dim vtbData As New System.Data.DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM LOAI_CP"))
        cbxLoaiChiuPhi.DataSource = vtbData
        cbxLoaiChiuPhi.DisplayMember = "TEN_CP"
        cbxLoaiChiuPhi.ValueMember = "MS_LOAI_CP"
    End Sub

    Private Sub LoadNgoaiTe()
        'Dim vtbData As New System.Data.DataTable()
        'vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM NGOAI_TE"))
        'cbxNgoaiTe.DataSource = vtbData
        'cbxNgoaiTe.DisplayMember = "NGOAI_TE"
        'cbxNgoaiTe.ValueMember = "NGOAI_TE"
        'cbxNgoaiTe.Text = "USD"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        Dim soNgay As Integer = DateTime.DaysInMonth(dtpThang.Value.Year, dtpThang.Value.Month)
        Dim vDauThang As DateTime = New DateTime(dtpThang.Value.Year, dtpThang.Value.Month, 1)
        Dim vCuoiThang As DateTime = New DateTime(dtpThang.Value.Year, dtpThang.Value.Month, soNgay)
        loaiChiuPhi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "TIEU_DE_LOAI_CHIU_PHI", Commons.Modules.TypeLanguage) + cbxLoaiChiuPhi.Text.Trim()
        vUnit = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "UNIT", Commons.Modules.TypeLanguage) & " : " & cbxNgoaiTe.Text
        Dim cur As Integer = Convert.ToInt32(cbxNgoaiTe.SelectedIndex)
        vtbData = New System.Data.DataTable()
        If cbxLoaiChiuPhi.SelectedValue = "CP1" Then
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_MONTHLY_BUDGET", vDauThang, vCuoiThang, 0, cur))
        Else
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_MONTHLY_BUDGET", vDauThang, vCuoiThang, 1, cur))
        End If
        If vtbData.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBoPhanChiPhiReport", "KgCoDuLieuDeIn", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Dim vtbBudGet As New System.Data.DataTable()
        Dim _vtb_don_vi As New System.Data.DataTable()
        Dim _sql As String = "select MS_DON_VI from don_vi inner join (select distinct ten_don_Vi from MONTHLY_BUDGET_TMP)temp on don_vi.ten_don_vi=temp.ten_Don_vi order by don_vi.TEN_DON_VI"
        _vtb_don_vi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sql))
        vBALANCE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "BALANCE", Commons.Modules.TypeLanguage)
        vBUDGET = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "BUDGET", Commons.Modules.TypeLanguage)
        vUSED = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "USED", Commons.Modules.TypeLanguage)
        Dim row As DataRow = vtbData.NewRow()
        Dim row1 As DataRow = vtbData.NewRow()
        Dim row2 As DataRow = vtbData.NewRow()
        row(0) = DBNull.Value
        Dim i As Integer = 1
        For Each _datarow As DataRow In _vtb_don_vi.Rows

            vtbBudGet.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_BUDGET", _datarow("MS_DON_VI"), cbxLoaiChiuPhi.SelectedValue, dtpThang.Value))
            If (vtbBudGet.Rows.Count > 0) Then
                row(i) = vtbBudGet.Rows(0)("Tong")
            Else
                row(i) = 0
            End If
            Dim use As Double = 0
            Dim j As Integer = i
            For Each _rowUse As DataRow In vtbData.Rows
                Try
                    use += _rowUse(i)
                Catch ex As Exception
                End Try
            Next
            Try
                row1(j) = use

                row2(j) = (row(i) - row1(j))
                row1(j) = Convert.ToDouble(row1(j)).ToString("###,##0.##")
                row2(j) = Convert.ToDouble(row2(j)).ToString("###,##0.##")
                j = j + 1
            Catch ex As Exception
            End Try
            i = i + 1
        Next

        vtbData.Rows.InsertAt(row, 0)
        row1(0) = DBNull.Value
        vtbData.Rows.InsertAt(row1, 1)
        row2(0) = DBNull.Value
        vtbData.Rows.InsertAt(row2, 2)
        Dim obj As frmReportViews_Budget = New frmReportViews_Budget()

        For Each col As DataColumn In vtbData.Columns
            If col.ColumnName = "NGAY" Then
                col.ColumnName = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "NGAY", Commons.Modules.TypeLanguage)
            End If
        Next

        obj.grdView.DataSource = vtbData
        For col As Integer = 0 To obj.grvView.Columns.Count - 1
            obj.grvView.Columns(col).Width = 120
            obj.grvView.Columns(col).OptionsColumn.FixedWidth = True
        Next


        'obj.grvView.Columns(1).Group()
        'obj.grvView.ExpandAllGroups()
        obj.vBALANCE = vBALANCE
        obj.loaiChiuPhi = loaiChiuPhi
        obj.vUSED = vUSED
        obj.tieuDe = tieuDe
        obj.vBUDGET = vBUDGET
        obj.vMonth = vMonth & " " & dtpThang.Text
        Dept = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "DEPT", Commons.Modules.TypeLanguage)
        obj.vtbData = vtbData
        obj.vUnit = vUnit
        obj.Dept = Dept
        obj.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fileDialog As SaveFileDialog = New SaveFileDialog()
        fileDialog.Filter = "Excel file (*.xls)|*.xls"
        Dim frm As New frmReportViews_Budget
        If fileDialog.ShowDialog() = DialogResult.OK Then
            frm.grvView.ExportToXls(fileDialog.FileName)
            Dim excelApplication As Excel.Application = New Excel.Application()
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(fileDialog.FileName, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = CType(excelWorkbook.Sheets(1), Excel.Worksheet)
            Dim excelRange As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range("A1", "A5")
            excelRange.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown)
            Dim excelRange1 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, vtbData.Columns.Count))
            excelRange1.Merge()
            excelRange1.Font.Name = "Tahoma"
            excelRange1.Font.Size = 14
            excelRange1.Font.Bold = True

            excelWorkSheet.Cells(1, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmBoPhanChiPhiReport", "TIEU_DE", Commons.Modules.TypeLanguage)
            Dim excelRange2 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(2, 1), excelWorkSheet.Cells(2, vtbData.Columns.Count))
            excelRange2.Merge()
            excelRange2.Font.Name = "Tahoma"
            excelRange2.Font.Size = 11
            excelRange2.Font.Bold = True
            excelWorkSheet.Cells(2, 1) = loaiChiuPhi
            Dim excelRange3 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(3, 1), excelWorkSheet.Cells(3, vtbData.Columns.Count))
            excelRange3.Merge()
            excelRange3.Font.Name = "Tahoma"
            excelRange3.Font.Size = 11
            excelRange3.Font.Bold = True
            excelWorkSheet.Cells(3, 1) = "DEPT"
            Dim excelRange4 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(4, 1), excelWorkSheet.Cells(4, vtbData.Columns.Count))
            excelRange4.Merge()
            excelRange4.Font.Name = "Tahoma"
            excelRange4.Font.Size = 11
            excelRange4.Font.Bold = True
            excelWorkSheet.Cells(4, 1) = vMonth & " " & dtpThang.Text
            Dim excelRange5 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(5, 1), excelWorkSheet.Cells(5, vtbData.Columns.Count))
            excelRange5.Merge()
            excelRange5.Font.Name = "Tahoma"
            excelRange5.Font.Size = 11
            excelRange5.Font.Bold = True
            'excelWorkSheet.Cells(5, 1) = "TO DATE: " + dtpDenNgay.Value.ToString("dd/MM/yyyy")
            'Dim excelRange6 As Microsoft.Office.Interop.Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(6, 1), excelWorkSheet.Cells(vtbData.Rows.Count + 6, TbSource.Columns.Count))
            'excelRange6.Font.Name = "Tahoma"
            'excelRange6.Font.Size = 9
            'excelRange6.Borders.Value = 1
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
