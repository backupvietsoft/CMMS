
Imports Microsoft.ApplicationBlocks.Data


Public Class frmBCLSTB_Antoan
    Public Sub frmBCLSTB_Antoan()
        InitializeComponent()
    End Sub

    Private Sub frmBCLSTB_Antoan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtTuNgay.EditValue = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString())
            dtDenNgay.EditValue = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()).AddMonths(1).AddDays(-1)
            LoadNXuong()
            LoadLoaiMay()
            LoadDChuyen()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadNXuong()
        Try
            Commons.Modules.ObjSystems.MLoadCboTreeList(cboNhaXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
        Catch
        End Try
    End Sub
    Private Sub LoadDChuyen()
        Try
            Commons.Modules.ObjSystems.MLoadCboTreeList(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG")
        Catch
        End Try
    End Sub
    Private Sub LoadLoaiMay()
        Try
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaimay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLoaiMay.Text)
        Catch
        End Try
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        ParentForm.Close()
    End Sub

    Private Sub btnExcute_Click(sender As Object, e As EventArgs) Handles btnExcute.Click
        Print()
    End Sub
    Private Sub Print()

        Dim vtbData As New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_BCLSTB_Antoan", dtTuNgay.EditValue, dtDenNgay.EditValue, cboNhaXuong.EditValue.ToString, cboDChuyen.EditValue.ToString, cboLoaimay.EditValue.ToString, Commons.Modules.UserName, Commons.Modules.TypeLanguage))

        If (vtbData.Rows.Count = 0) Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucLuanChuyenVatTu", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, vtbData, False, True, True, True, True, Me.Name.ToString)
        grvChung.Columns("THIET_BI").Group()
        grvChung.Columns("THIET_BI").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCLSTB_Antoan", "THIET_BI", Commons.Modules.TypeLanguage)
        grvChung.ExpandAllGroups()



        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
        If sPath = "" Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()

        prbIN.Visible = True
        prbIN.Position = 0
        prbIN.Properties.Step = 1
        prbIN.Properties.PercentView = True
        prbIN.Properties.Maximum = 15
        prbIN.Properties.Minimum = 0
        Try
            Dim TCot As Integer = grvChung.Columns.Count
            Dim TDong As Integer = grvChung.RowCount
            Dim Dong As Integer = 1
            prbIN.PerformStep()
            prbIN.Update()
            grdChung.ExportToXls(sPath)
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "",
                 False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)

            Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)
            prbIN.PerformStep()
            prbIN.Update()

            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong)
            prbIN.PerformStep()
            prbIN.Update()
            Dong += 1
            Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True,
             True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100)
            prbIN.PerformStep()
            prbIN.Update()
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCLSTB_Antoan", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 18,
                    True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))

            prbIN.PerformStep()
            prbIN.Update()
            Dong += 1
            Dim stmp As String = ""
            stmp = lblTuNgay.Text + ": " + dtTuNgay.EditValue + " - " + lblDenNgay.Text + ": " + dtDenNgay.EditValue
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 1, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, (If(TCot > 16, 16, TCot)))

            prbIN.PerformStep()
            prbIN.Update()
            Dong += 1

            stmp = lblNhaXuong.Text + " : " + cboNhaXuong.TextValue
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10,
             True, True, Dong, 4)
            prbIN.PerformStep()
            prbIN.Update()
            Dong += 1

            stmp = lblLoaiMay.Text + " : " + cboLoaimay.Text
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10,
             True, True, Dong, 4)
            prbIN.PerformStep()
            prbIN.Update()
            Dim title As Excel.Range

            Dong += 1
            Dong += 1
            Dong += 1
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot)
            title.Font.Bold = True
            prbIN.PerformStep()
            prbIN.Update()


            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 15
            prbIN.PerformStep()
            prbIN.Update()
            'set width for all columns'
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", True, Dong + 1, 1, TDong + Dong, 1)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 23, "dd/MM/yyyy", True, Dong + 1, 2,
             TDong + Dong, 2)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", True, Dong + 1, 3,
             TDong + Dong, 3)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 18.7, "@", True, Dong + 1, 4,
             TDong + Dong, 4)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", True, Dong + 1, 5, TDong + Dong, 5)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "@", True, Dong + 1, 6,
             TDong + Dong, 6)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15.5, "@", True, Dong + 1, 7,
             TDong + Dong, 7)
            prbIN.PerformStep()
            prbIN.Update()
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 1, Dong + TDong, TCot)

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, TCot, Dong + TDong, TCot)
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            prbIN.PerformStep()
            prbIN.Update()
            For i As Integer = 12 To TDong + 12
                Try
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i, 1, i, 1)
                    If title.Value.ToString().Contains("Thiết bị:") Then
                        title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                    End If
                Catch ex As Exception

                End Try
            Next

            excelWorkbook.Save()
            excelApplication.Visible = True
            prbIN.Position = prbIN.Properties.Maximum
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)

            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        Catch ex As Exception
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            prbIN.Position = prbIN.Properties.Maximum
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Me.Cursor = Cursors.[Default]

    End Sub
End Class