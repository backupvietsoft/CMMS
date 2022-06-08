Imports Microsoft.ApplicationBlocks.Data
Public Class ucLuanChuyenVatTu
    Private sql As String = ""
    Private DSKho As New DataTable

    Private Sub ucLuanChuyenVatTu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            cmbTuNgay.DateTime = DateSerial(Year(Today), Month(Today), 1)
            cmbDenNgay.DateTime = Today
            sql = "SELECT   DISTINCT CONVERT(BIT,0) AS CHON,  IC_KHO.MS_KHO, IC_KHO.TEN_KHO, IC_KHO.KHO_DD, DON_VI.TEN_DON_VI" & _
                  "  FROM         IC_KHO LEFT OUTER JOIN  DON_VI ON IC_KHO.MS_DON_VI = DON_VI.MS_DON_VI ORDER BY IC_KHO.MS_KHO"



            sql = " SELECT  DISTINCT CONVERT(BIT,0) AS CHON,  T1.MS_KHO, T1.TEN_KHO, T1.KHO_DD, T4.TEN_DON_VI " & _
                            " FROM            dbo.IC_KHO AS T1 INNER JOIN " & _
                            "                          dbo.NHOM_KHO AS T2 ON T1.MS_KHO = T2.MS_KHO INNER JOIN " & _
                            "                          dbo.USERS AS T3 ON T2.GROUP_ID = T3.GROUP_ID " & _
                            " LEFT OUTER JOIN  DON_VI T4 ON T1.MS_DON_VI = T4.MS_DON_VI " & _
                            " WHERE        (T3.USERNAME = N'" & Commons.Modules.UserName & "')"
            DSKho = New DataTable
            DSKho.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            DSKho.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(gridThietBi, GridViewTB, DSKho, True, True, True, True)
            GridViewTB.Columns("MS_KHO").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("MS_KHO").OptionsColumn.AllowFocus = False

            GridViewTB.Columns("TEN_KHO").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("TEN_KHO").OptionsColumn.AllowFocus = False

            GridViewTB.Columns("KHO_DD").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("KHO_DD").OptionsColumn.AllowFocus = False

            GridViewTB.Columns("TEN_DON_VI").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("TEN_DON_VI").OptionsColumn.AllowFocus = False

            'Commons.Modules.ObjSystems.ThayDoiNN(Me.ParentForm)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        ParentForm.Close()
    End Sub

    Private Sub cmdTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTatCa.Click
        Try
            Dim dv As DataView
            Dim i As Integer
            Dim j As Integer

            dv = DSKho.DefaultView
            For i = 0 To dv.Count - 1
                j = DSKho.Rows.IndexOf(dv(i).Row)
                If j >= 0 Then
                    DSKho.Rows(j).Item("CHON") = 1
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBoChon.Click
        Try
            Dim dv As DataView
            Dim i As Integer
            Dim j As Integer

            dv = DSKho.DefaultView
            For i = 0 To dv.Count - 1
                j = DSKho.Rows.IndexOf(dv(i).Row)
                If j >= 0 Then
                    DSKho.Rows(j).Item("CHON") = 0
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click

        Dim dv As DataView
        Dim i As Integer
        Dim j As Integer
        Dim strWhsCode As String
        Dim vtb As New DataTable
        Dim Co As Boolean = False
        Dim sPath As String = ""
        strWhsCode = "<ROOT>"

        Try
            dv = DSKho.DefaultView
            For i = 0 To dv.Count - 1
                j = DSKho.Rows.IndexOf(dv(i).Row)
                If j >= 0 Then
                    If CBool(DSKho.Rows(j).Item("CHON")) = True Then
                        strWhsCode = strWhsCode & "<MSKHO id=""" & DSKho.Rows(j).Item("MS_KHO") & """></MSKHO>"
                        Co = True
                    End If
                End If
            Next
            strWhsCode += "</ROOT>"
            If Co = False Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "Vuilongchonkho", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sProcLuanChuyenVatTu", cmbTuNgay.DateTime, cmbDenNgay.Text, strWhsCode))
            If vtb.Rows.Count <= 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
            'sPath = "D:\18511.XLS"
            If sPath = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "PhaiChonFile", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridExport, GridView1, vtb, True, True, True, True, True, "ucLuanChuyenVatTu")
            GridExport.DataSource = vtb
            GridExport.ExportToXls(sPath)


        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "InKhongThanhCong", _
                    Commons.Modules.TypeLanguage) + vbCrLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


        Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()
        Dim excelWorkbooks As Excel.Workbooks
        Dim excelWorkbook As Excel.Workbook
        Dim excelWorkSheet As Excel.Worksheet
        Dim Cot As Integer
        Dim Dong As Integer = 0
        Dim sTmp As String
        Dim TCot As Integer

        Try
            excelWorkbooks = excelApplication.Workbooks
            excelWorkbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            excelWorkSheet = excelWorkbook.Sheets(1)

            sTmp = ""
            TCot = vtb.Columns.Count
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

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "TieuDe", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 16, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "TuNgay", Commons.Modules.TypeLanguage) & "  " & cmbTuNgay.Text.Replace("/", ".") & "  " & _
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "DenNgay", Commons.Modules.TypeLanguage) & "  " & cmbDenNgay.Text.Replace("/", ".")
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong + 1, 1, "@", 12, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong + 1, TCot)
                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True, True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)
                Cot = 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 0.25
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 5.29
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 12
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 12
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 11
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 17.57
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 32.57
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 10
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 12
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 18
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 18
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 14
                Cot = Cot + 1

                .Range(.Cells(9, Cot), .Cells(9, Cot + 1)).Merge()
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "TinhTrang", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 9, Cot, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, 9, Cot + 1)

                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 7.29
                Cot = Cot + 1
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 7.29
                Cot = Cot + 1
                .Range(.Cells(9, Cot), .Cells(10, Cot)).Merge()
                .Range(.Cells(10, Cot), .Cells(10, Cot)).ColumnWidth = 24.86
                Cot = Cot + 1
                ' Commons.Modules.MExcel.TaoShape(1, excelWorkSheet, 100, 0, 400, 50, "-1", "Times New Roman", 10, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter)
                .Range(.Cells(10, 4), .Cells(10 + vtb.Rows.Count, 7)).NumberFormat = "@"
                .Range(.Cells(10, 4), .Cells(10 + vtb.Rows.Count, 7)).WrapText = True

                .Range(.Cells(11, 8), .Cells(11 + vtb.Rows.Count, 8)).NumberFormat = "_(* " + Commons.Modules.sSoLeSL + "_);_(* (" + Commons.Modules.sSoLeSL + ");_(* ""-""_);_(@_)"
                .Range(.Cells(11, 9), .Cells(11 + vtb.Rows.Count, 9)).NumberFormat = "_(* " + Commons.Modules.sSoLeDG + "_);_(* (" + Commons.Modules.sSoLeDG + ");_(* ""-""_);_(@_)"
                .Range(.Cells(11, 10), .Cells(11 + vtb.Rows.Count, 10)).NumberFormat = "_(* " + Commons.Modules.sSoLeTT + "_);_(* (" + Commons.Modules.sSoLeTT + ");_(* ""-""_);_(@_)"

                .Range(.Cells(10, 11), .Cells(10 + vtb.Rows.Count, 12)).WrapText = True
                .Range(.Cells(11, 13), .Cells(11 + vtb.Rows.Count, 14)).NumberFormat = "_(* " + Commons.Modules.sSoLeSL + "_);_(* (" + Commons.Modules.sSoLeSL + ");_(* ""-""_);_(@_)"
                .Range(.Cells(10, 15), .Cells(10 + vtb.Rows.Count, 15)).WrapText = True

                .Range(.Cells(9, 2), .Cells(10 + vtb.Rows.Count, 15)).Borders.LineStyle = 1
                .Range(.Cells(10, 2), .Cells(10, 15)).HorizontalAlignment = 3
                .Range(.Cells(10, 2), .Cells(10, 15)).VerticalAlignment = 2
                .Range(.Cells(10, 2), .Cells(10, 15)).WrapText = True
                .Range(.Cells(9, 2), .Cells(10, 15)).Interior.Color = RGB(255, 255, 255)
                .Range(.Cells(9, 2), .Cells(10, 15)).Font.Bold = True
                .Range(.Cells(9, 2), .Cells(10 + vtb.Rows.Count, 15)).BorderAround(1, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic)
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
End Class
