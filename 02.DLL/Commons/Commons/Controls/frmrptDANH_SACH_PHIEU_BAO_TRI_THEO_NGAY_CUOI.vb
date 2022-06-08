
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors

Public Class frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI
    Dim v_all As DataTable = New DataTable()
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        Me.Cursor = Cursors.WaitCursor
        Try
            If datTNgay.DateTime > datDNgay.DateTime Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.ToString, "msgTuNgayLonHonDenNgay",
                    Commons.Modules.TypeLanguage), Me.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                datDNgay.Focus()
            End If
            Dim vtbData As New DataTable()
            Dim frmRP As frmXMLReport = New frmXMLReport()
            frmRP.rptName = "rptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI"
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCDanhSachPBTTheoNgayCuoi", datTNgay.DateTime, datDNgay.DateTime,
                Commons.Modules.UserName, cboDDiem.EditValue, cboDChuyen.EditValue, cboLMay.EditValue, cboLBTri.EditValue, Commons.Modules.TypeLanguage))

            If vtbData.Rows.Count > 0 Then
                vtbData.TableName = "DATA_INFO"
                'Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, vtbData, True, True, True, True, True, Me.Name.ToString)
                ''grvChung.Columns("TEN_N_XUONG").Group()
                ''grvChung.Columns("TEN_LOAI_MAY").Group()
                ''grvChung.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold)
                ''grvChung.Appearance.GroupRow.Options.UseFont = True
                ''grvChung.ExpandAllGroups()
                'InBC()

                frmRP.AddDataTableSource(vtbData)
                frmRP.AddDataTableSource(RefeshLanguage)

                frmRP.ShowDialog()



            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 9
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(2).ColumnName = "LOAI_TB"
        vtbTitle.Columns(3).ColumnName = "NHOM_TB"
        vtbTitle.Columns(4).ColumnName = "STT"
        vtbTitle.Columns(5).ColumnName = "THIET_BI"
        vtbTitle.Columns(6).ColumnName = "NGAY_CUOI"
        vtbTitle.Columns(7).ColumnName = "MS_PHIEU_BT"
        vtbTitle.Columns(8).ColumnName = "LOAI_BT"
        vtbTitle.Columns(9).ColumnName = "LY_DO"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "TIEU_DE", Commons.Modules.TypeLanguage)
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "DIA_DIEM", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "LOAI_TB", Commons.Modules.TypeLanguage)
        vRowTitle("NHOM_TB") = lblTNgay.Text & " " & datTNgay.Text & " " & lblDNgay.Text & " - " & datDNgay.Text
        'Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "NHOM_TB", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("THIET_BI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "THIET_BI", Commons.Modules.TypeLanguage)
        vRowTitle("NGAY_CUOI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "NGAY_CUOI", Commons.Modules.TypeLanguage)
        vRowTitle("MS_PHIEU_BT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "MS_PHIEU_BT", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_BT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "LOAI_BT", Commons.Modules.TypeLanguage)
        vRowTitle("LY_DO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "LY_DO", Commons.Modules.TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        vtbTitle.TableName = "Table1"
        Return vtbTitle
    End Function



    Private Sub LoadNX()
        Commons.Modules.ObjSystems.MLoadCboTreeList(cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
    End Sub

    Private Sub LoadDChuyen()
        Commons.Modules.ObjSystems.MLoadCboTreeList(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG")
    End Sub

    Private Sub LoadLoaiMay()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text)
    End Sub

    Private Sub LoadLoaiBT()
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLoaiBaoTri"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, dtTmp, "MS_LOAI_BT", "TEN_LOAI_BT", lblLBaoTri.Text)
    End Sub


    Private Sub frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Ngay As DateTime
        Ngay = Convert.ToDateTime("01/" + Now.Month.ToString() + "/" + Now.Year.ToString())
        datTNgay.DateTime = Ngay.AddMonths(-2)
        datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1)

        LoadNX()
        LoadDChuyen()
        LoadLoaiMay()
        LoadLoaiBT()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
    Sub InBC()

        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
        If sPath = "" Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()

        Try
            Dim TCot As Integer = grvChung.Columns.Count
            Dim TDong As Integer = grvChung.RowCount
            Dim Dong As Integer = 1

            prbIN.Visible = True
            prbIN.Position = 0
            prbIN.Properties.Step = 1
            prbIN.Properties.PercentView = True
            prbIN.Properties.Maximum = 5
            prbIN.Properties.Minimum = 0

            grdChung.ExportToXls(sPath)


            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "",
                 False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)

            Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)


            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 5, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 40, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong)


            Dong += 1

            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)


            prbIN.PerformStep()
            prbIN.Update()


            Dim title As Excel.Range

            Dong += 1
            Dong += 1

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot)
            title.Font.Bold = True
            title.Font.Name = "Arial"
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True,
             True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100)

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 15

            prbIN.PerformStep()
            prbIN.Update()

            'set width for all columns'
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 4, "@", True, Dong + 1, 1, TDong + Dong, 1)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", True, Dong + 1, 2,
             TDong + Dong, 2)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", True, Dong + 1, 3,
             TDong + Dong, 3)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", True, Dong + 1, 4,
             TDong + Dong, 4)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", True, Dong + 1, 5, TDong + Dong, 5)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "dd/mm/yyyy", True, Dong + 1, 6,
             TDong + Dong, 6)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 7,
             TDong + Dong, 7)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", True, Dong + 1, 8,
             TDong + Dong, 8)

            prbIN.PerformStep()
            prbIN.Update()

            'For i2 As Integer = 7 To 7 + TDong
            '    Try
            '        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i2, 1, i2, 1)
            '        If title.Value.ToString.Contains("Địa điểm:") = True Then
            '            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#a10404"))
            '            title.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = 0
            '            title.Font.Bold = True
            '        End If
            '    Catch ex As Exception

            '    End Try
            'Next
            'prbIN.PerformStep()
            'prbIN.Update()

            'For i1 As Integer = 8 To 8 + TDong
            '    Try
            '        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 2, i1, 2)
            '        If title.Value.ToString.Contains("Loại thiết bị:") = True Then
            '            title.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#0d6012"))
            '            title.Font.Bold = True
            '        End If
            '    Catch ex As Exception

            '    End Try
            'Next

            prbIN.PerformStep()
            prbIN.Update()

            'Dim i As Integer = 1
            'Dim T1, T2 As Excel.Range
            'For i1 As Integer = 11 To 11 + TDong
            '    Try
            '        T1 = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 3, i1, 3)
            '        If Convert.ToInt32(T1.Value) Then
            '            T2 = Commons.Modules.MExcel.GetRange(excelWorkSheet, i1, 1, i1, 3)
            '            T2.Merge()
            '            T2.Value = i
            '            i = i + 1
            '        End If

            '    Catch ex As Exception

            '    End Try

            'Next

            prbIN.PerformStep()
            prbIN.Update()

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 1, 20 + TDong, TCot)
            title.Font.Name = "Arial"

            prbIN.PerformStep()
            prbIN.Update()

            excelWorkbook.Save()
            excelApplication.Visible = True
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        Catch ex As Exception
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_NGAY_CUOI", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Me.Cursor = Cursors.[Default]
        prbIN.Position = prbIN.Properties.Maximum
    End Sub

End Class
