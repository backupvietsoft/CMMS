Imports Microsoft.ApplicationBlocks.Data
Public Class ucDuToanTheoDonVi
    Private sql As String = ""
    Private vtbDonVi As New DataTable

    Private Sub ucDuToanTheoDonVi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            cmbThang.DateTime = Today
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 0, Commons.Modules.UserName))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbDonVi, dtTmp, "MS_DON_VI", "TEN_DON_VI", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click
        Dim Thang As Integer
        Dim Nam As Integer
        Dim DonVi As String = ""
        Dim vtbTam As New DataTable
        Dim vtbToPhongBan As New DataTable
        Dim ds As New DataSet
        Dim sPath As String = ""
        Try
            Thang = CInt(cmbThang.Text.Substring(0, 2))
            Nam = CInt(cmbThang.Text.Substring(3, 4))
            DonVi = cmbDonVi.EditValue.ToString
            sql = "exec sProcDuToanTheoDonVi " & Thang & "," & Nam & ",'" & DonVi & "', " & Commons.Modules.UserName
            ds = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            vtbToPhongBan = ds.Tables(0)
            vtbTam = New DataTable
            vtbTam = ds.Tables(1)

            'vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            If vtbTam.Rows.Count <= 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
            ' sPath = "f:\Book1.xlsx"
            'sPath = "d:\a7aa.xls"
            If sPath = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "PhaiChonFile", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridExport, GridView1, vtbTam, True, True, True, True, True, "ucDuToanTheoDonVi")
            GridExport.DataSource = vtbTam
            GridExport.ExportToXlsx(sPath)

        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "InKhongThanhCong", _
                Commons.Modules.TypeLanguage) + vbCrLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim excelApplication As New Excel.Application()
        Dim excelWorkbooks As Excel.Workbooks
        Dim excelWorkbook As Excel.Workbook
        Dim excelWorkSheet As Excel.Worksheet

        Try

            Cursor = Cursors.WaitCursor

            Dim i As Integer

            Dim Dong As Integer = 0
            excelWorkbooks = excelApplication.Workbooks
            excelWorkbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            excelWorkSheet = excelWorkbook.Sheets(1)
            Dim sTmp As String
            sTmp = ""
            Dim TCot As Integer
            TCot = vtbTam.Columns.Count
            excelApplication.Cells.Font.Name = "Times New Roman"
            excelApplication.Cells.Font.Size = 10
            With excelWorkSheet
                'excelApplication.Visible = True
                Dim DangThem As Microsoft.Office.Interop.Excel.XlInsertShiftDirection
                Dim MRange As Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, 1))
                MRange.EntireColumn.Insert(DangThem)
                Dong = 1
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 9, Dong)
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 7, 80, 37, Application.StartupPath)
                Dong = 5
                TCot = TCot + 1
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "TieuDe", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 16, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "Thang", Commons.Modules.TypeLanguage) & "  " & cmbThang.Text.Substring(0, 2) & "  " & _
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "Nam", Commons.Modules.TypeLanguage) & "  " & cmbThang.Text.Substring(3, 4)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong + 1, 1, "@", 12, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong + 1, TCot)

                Dong = Dong + 2
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "DonVi", Commons.Modules.TypeLanguage) & " : " & cmbDonVi.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 2, "@", 12, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, True, Dong, 2)

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, "@", True, 11, 3, 11 + vtbTam.Rows.Count + 1, 4)

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, "_(* " + Commons.Modules.sSoLeTT + "_);_(* (" + Commons.Modules.sSoLeTT + ");_(* ""-""_);_(@_)", True, 11, 5, 11 + vtbTam.Rows.Count + 1, 5 + 3 * vtbToPhongBan.Rows.Count + 2)

                Dong = Dong + 3
                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 1)).ColumnWidth = 0.25
                .Range(.Cells(Dong + 4, 2), .Cells(Dong + 5, 2)).ColumnWidth = 4.86
                .Range(.Cells(Dong + 4, 3), .Cells(Dong + 5, 3)).ColumnWidth = 31
                .Range(.Cells(Dong + 4, 4), .Cells(Dong + 5, 4)).ColumnWidth = 8


                For i = 3 To vtbTam.Columns.Count - 1
                    .Range(.Cells(Dong + 4, 2 + i), .Cells(Dong + 5, 2 + i)).ColumnWidth = 12.5
                Next
                i = 0
                'excelApplication.Visible = True
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "DuToan", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong - 1, 5, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong - 1, 5 + vtbToPhongBan.Rows.Count)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "ThucTe", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong - 1, 5 + vtbToPhongBan.Rows.Count + 1, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong - 1, 5 + 2 * vtbToPhongBan.Rows.Count + 1)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "ChenhLech", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong - 1, 5 + 2 * (vtbToPhongBan.Rows.Count + 1), "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong - 1, 5 + 3 * vtbToPhongBan.Rows.Count + 2)

                .Range(.Cells(9, 5), .Cells(9, 5 + 3 * vtbToPhongBan.Rows.Count + 2)).Borders.LineStyle = 1
                .Range(.Cells(10, 2), .Cells(10 + vtbTam.Rows.Count, 5 + 3 * vtbToPhongBan.Rows.Count + 2)).Borders.Color = RGB(0, 0, 0)

                .Range(.Cells(10, 4), .Cells(10 + vtbTam.Rows.Count, 4)).HorizontalAlignment = 3
                .Range(.Cells(10, 4), .Cells(10 + vtbTam.Rows.Count, 4)).VerticalAlignment = 2

                .Range(.Cells(10, 2), .Cells(10, 5 + 3 * vtbToPhongBan.Rows.Count + 2)).Interior.Color = RGB(255, 255, 255)
                .Range(.Cells(9, 5 + vtbToPhongBan.Rows.Count + 1), .Cells(10 + vtbTam.Rows.Count, 5 + 2 * vtbToPhongBan.Rows.Count + 1)).Interior.Color = RGB(120, 255, 255)


                For Each vr As DataRow In vtbToPhongBan.Rows
                    .Cells(Dong, 5 + i) = vr("TEN_TO").ToString
                    .Cells(Dong, 5 + vtbToPhongBan.Rows.Count + 1 + i) = vr("TEN_TO").ToString
                    .Cells(Dong, 5 + 2 * (vtbToPhongBan.Rows.Count + 1) + i) = vr("TEN_TO").ToString
                    i = i + 1
                Next
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "TongDuToan", Commons.Modules.TypeLanguage)
                .Cells(Dong, 5 + vtbToPhongBan.Rows.Count) = sTmp
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "TongThucTe", Commons.Modules.TypeLanguage)
                .Cells(Dong, 5 + 2 * vtbToPhongBan.Rows.Count + 1) = sTmp
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "TongChenhLech", Commons.Modules.TypeLanguage)
                .Cells(Dong, 5 + 3 * vtbToPhongBan.Rows.Count + 2) = sTmp

                Commons.Modules.MExcel.TaoShape(1, excelWorkSheet, 100, 0, 400, 50, "-1", "Times New Roman", 10, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "TruongNhaMay", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 10 + vtbTam.Rows.Count + 3, 3, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, 10 + vtbTam.Rows.Count + 2, 3)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDuToanTheoDonVi", "Khoisanxuat", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 10 + vtbTam.Rows.Count + 3, 10, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, 10 + vtbTam.Rows.Count + 2, 12)

                Try
                    .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                    .PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
                    .PageSetup.LeftMargin = 18
                    .PageSetup.RightMargin = 18
                    .PageSetup.TopMargin = 18
                    .PageSetup.BottomMargin = 18
                    .PageSetup.HeaderMargin = 18
                    .PageSetup.FooterMargin = 18
                    .PageSetup.Zoom = 75
                Catch ex As Exception

                End Try

            End With

            excelApplication.ActiveWindow.DisplayGridlines = False
            excelApplication.Visible = True
            excelWorkbook.Save()
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)

        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "InKhongThanhCong", _
                Commons.Modules.TypeLanguage) + vbCrLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Try
            ParentForm.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
