
Imports System.Windows.Forms
Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            datTNgay.DateTime = DateSerial(Year(Today), Month(Today), 1)
            datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1)
            loadNhaXuong()
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 15
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TU_NGAY"
        vtbTitle.Columns(2).ColumnName = "DEN_NGAY"
        vtbTitle.Columns(3).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(4).ColumnName = "TMP"
        vtbTitle.Columns(5).ColumnName = "MS_TB"
        vtbTitle.Columns(6).ColumnName = "TEN_TB"
        vtbTitle.Columns(7).ColumnName = "LOAI_TB"
        vtbTitle.Columns(8).ColumnName = "MS_VT"
        vtbTitle.Columns(9).ColumnName = "TEN_VT"
        vtbTitle.Columns(10).ColumnName = "SO_LUONG"
        vtbTitle.Columns(11).ColumnName = "THANH_TIEN"
        vtbTitle.Columns(12).ColumnName = "TONG"
        vtbTitle.Columns(13).ColumnName = "STT"
        vtbTitle.Columns(14).ColumnName = "LOAI_VT"
        vtbTitle.Columns(15).ColumnName = "TONG_THEO_XUONG"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TIEU_DE", Commons.Modules.TypeLanguage)
        vRowTitle("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TU_NGAY", Commons.Modules.TypeLanguage) & datTNgay.Text
        vRowTitle("DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "DEN_NGAY", Commons.Modules.TypeLanguage) & datDNgay.Text
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "DIA_DIEM", Commons.Modules.TypeLanguage)
        vRowTitle("TMP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TMP", Commons.Modules.TypeLanguage)
        vRowTitle("MS_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "MS_TB", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TEN_TB", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "LOAI_TB", Commons.Modules.TypeLanguage)
        vRowTitle("MS_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "MS_VT", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TEN_VT", Commons.Modules.TypeLanguage)
        vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "SO_LUONG", Commons.Modules.TypeLanguage)
        vRowTitle("THANH_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "THANH_TIEN", Commons.Modules.TypeLanguage)
        vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TONG", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "LOAI_VT", Commons.Modules.TypeLanguage)
        vRowTitle("TONG_THEO_XUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TONG_THEO_XUONG", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Sub loadNhaXuong()
        Commons.Modules.ObjSystems.MLoadCboTreeList(cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            If datTNgay.Text.Trim.ToString = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "PhaiNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                datTNgay.Focus()
                Exit Sub
            End If
            If datDNgay.Text = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "PhaiNhapDenNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                datDNgay.Focus()
                Exit Sub
            End If

            Dim vtbData As New DataTable()
            v_all = New DataTable()

            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCDanhSachVatTuSuDungBaoTri",
                    datTNgay.DateTime.Date, datDNgay.DateTime.Date, Modules.UserName, cboDDiem.EditValue, Modules.TypeLanguage))
            vtbData.TableName = "DATA_INFO"

            If vtbData.Rows.Count > 0 Then
                'Dim frmRepot As frmXMLReport = New frmXMLReport()
                'frmRepot.rptName = "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB"
                'frmRepot.AddDataTableSource(RefeshLanguage())
                'frmRepot.AddDataTableSource(vtbData)
                'frmRepot.ShowDialog()
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, vtbData, False, True, True, True, True, Me.Name.ToString)
                grvChung.Columns("MS_NHOM_MAY").Visible = False
                grvChung.Columns("NGAY_XUAT").Visible = False
                grvChung.Columns("MS_PHIEU_BAO_TRI").Visible = False
                grvChung.Columns("NGAY_BD_KH").Visible = False
                grvChung.Columns("MS_DH_XUAT_PT").Visible = False
                grvChung.Columns("DON_GIA").Visible = False
                grvChung.Columns("NGOAI_TE").Visible = False
                grvChung.Columns("TY_GIA").Visible = False
                grvChung.Columns("MS_LOAI_VT").Visible = False
                grvChung.Columns("MS_N_XUONG").Visible = False

                grvChung.Columns("TEN_N_XUONG").Group()
                grvChung.Columns("TEN_LOAI_VT_TV").Group()


                grvChung.Columns("STT").VisibleIndex = 1
                grvChung.Columns("TEN_LOAI_MAY").VisibleIndex = 2
                grvChung.Columns("MS_MAY").VisibleIndex = 3
                grvChung.Columns("MS_PT").VisibleIndex = 4
                grvChung.Columns("TEN_PT").VisibleIndex = 5
                grvChung.Columns("SO_LUONG_THUC_XUAT").VisibleIndex = 6
                grvChung.Columns("THANH_TIEN").VisibleIndex = 7


                InDuLieu()

            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub InDuLieu()

        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls") ' "C:\Users\Administrator\Desktop\frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY.xls"
        If sPath = "" Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()
        grvChung.ExpandAllGroups()
        Try
            Dim TCot As Integer = grvChung.Columns.Count - 10
            Dim TDong As Integer = grvChung.RowCount 'grvChung.DataRowCount + grvChung.GetChildRowCount(1) + 1 + grvChung.GroupCount
            Dim Dong As Integer = 1

            grdChung.ExportToXls(sPath)
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "",
                 False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)

            Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)


            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 6, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong)


            Dong += 1

            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)


            Dong += 1
            Dim stmp As String = ""

            stmp = lbaTuNgay.Text + " : " + datTNgay.Text
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong + 1, 3, "@", 10, True, True, Dong + 1, 5)

            stmp = lbaDenNgay.Text + " : " + datDNgay.Text
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong + 1, 6, "@", 10, True, True, Dong + 1, 8)

            Dim title As Excel.Range

            Dong += 3

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong , TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot)
            title.Font.Bold = True
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True,
             True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 1)
            title.RowHeight = 19.5
            'set width for all columns'
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 1.5, "@", True, Dong + 1, 1, TDong + Dong, 1)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", True, Dong + 1, 2,
             TDong + Dong, 2)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 3.5, "@", True, Dong + 1, 3,
             TDong + Dong, 3)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", True, Dong + 1, 4,
             TDong + Dong, 4)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 5, TDong + Dong, 5)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 6,
             TDong + Dong, 6)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 7,
             TDong + Dong, 7)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "@", True, Dong + 1, 8,
             TDong + Dong, 8)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "@", True, Dong + 1, 9,
             TDong + Dong, 9)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), True, Dong + 1, 10, TDong + Dong, 10)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", True, Dong + 1, 11,
             TDong + Dong, 11)
            Dim str As String = ""
            Dim strtt As String = ""
            Dim DongBD_DD As Integer = 0
            Dim DongBD_LVT As Integer = 0


            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 7, 1, 7, 1)
            title.RowHeight = 9

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 9, 1, 9, 1)
            title.RowHeight = 9
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
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Me.Cursor = Cursors.[Default]

    End Sub
    Private Sub btnThoat_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
