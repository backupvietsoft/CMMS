Imports Microsoft.ApplicationBlocks.Data
Imports System.Threading

Public Class ucBangKeCTNhapKho
    Private sql As String = ""
    Private vtbKho As New DataTable
    Private vtbLoaiVT As New DataTable

    Private Sub ucBangKeCTNhapKho_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False

            cmbThang.DateTime = Today
            sql = "SELECT distinct  MS_KHO, TEN_KHO FROM dbo.IC_KHO order by TEN_KHO"
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbKho, sql, "MS_KHO", "TEN_KHO", lblKho.Text)

            sql = "SELECT    convert(bit,0) as CHON, MS_LOAI_VT, TEN_LOAI_VT_TV, TEN_LOAI_VT_TA " & _
                  "FROM         dbo.LOAI_VT order by TEN_LOAI_VT_TV "

            vtbLoaiVT = New DataTable
            vtbLoaiVT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            vtbLoaiVT.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(gridThietBi, GridViewTB, vtbLoaiVT, True, True, True, True)
            GridViewTB.Columns("MS_LOAI_VT").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("TEN_LOAI_VT_TV").OptionsColumn.AllowFocus = False
            GridViewTB.Columns("TEN_LOAI_VT_TA").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("MS_LOAI_VT").Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMSMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMSMay.EditValueChanged
        Try
            If GridViewTB.ActiveFilterString <> "" Then
                vtbLoaiVT.DefaultView.RowFilter = GridViewTB.ActiveFilterString & " and TEN_LOAI_VT_TV LIKE '" & txtMSMay.Text & "%'"
            Else
                vtbLoaiVT.DefaultView.RowFilter = " TEN_LOAI_VT_TV LIKE '" & txtMSMay.Text & "%'"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTatCa.Click
        Try
            Dim dv As DataView
            Dim i As Integer
            Dim j As Integer

            dv = vtbLoaiVT.DefaultView
            For i = 0 To dv.Count - 1
                j = vtbLoaiVT.Rows.IndexOf(dv(i).Row)
                If j >= 0 Then
                    vtbLoaiVT.Rows(j).Item("CHON") = 1
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

            dv = vtbLoaiVT.DefaultView
            For i = 0 To dv.Count - 1
                j = vtbLoaiVT.Rows.IndexOf(dv(i).Row)
                If j >= 0 Then
                    vtbLoaiVT.Rows(j).Item("CHON") = 0
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        ParentForm.Close()
    End Sub

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click
        'Dim oThread As New Thread(AddressOf ThreadMethod)
        'oThread.SetApartmentState(ApartmentState.STA)
        'oThread.Start()

        Dim TableTam As String = "BKCTNK" & Commons.Modules.UserName
        Dim TableTamDL As String = "BKCTNKDL" & Commons.Modules.UserName
        Dim TableExcel As String = "TableNK" & Commons.Modules.UserName
        Dim Kho As String
        Dim Thang As String
        Dim vtbTam As New DataTable
        Dim ChuoiLoc As String = ""
        Dim i As Integer
        Dim sPath As String = ""
        Try

            Thang = cmbThang.DateTime.ToShortDateString()
            Kho = cmbKho.EditValue.ToString

            Commons.Modules.ObjSystems.XoaTable(TableTam)
            Commons.Modules.ObjSystems.XoaTable(TableTamDL)
            Commons.Modules.ObjSystems.XoaTable(TableExcel)
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, TableTam, vtbLoaiVT, "")

            sql = "SELECT   ROW_NUMBER() OVER(ORDER BY NGAY) AS STT " & _
                    " ,  IC_DON_HANG_NHAP.NGAY, IC_DON_HANG_NHAP.MS_DH_NHAP_PT, IC_DON_HANG_NHAP_VAT_TU.MS_PT, IC_PHU_TUNG.TEN_PT, " & _
                    "    DON_VI_TINH.TEN_1, LOAI_VT.TEN_LOAI_VT_TV, SUM(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP) AS SoLuong, " & _
                    "    SUM(ISNULL(IC_DON_HANG_NHAP_VAT_TU.DON_GIA, 0) * ISNULL(IC_DON_HANG_NHAP_VAT_TU.TY_GIA, 0) " & _
                    "    * ISNULL(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP, 0)) / SUM(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP) AS DonGia, " & _
                    "    SUM(ISNULL(IC_DON_HANG_NHAP_VAT_TU.DON_GIA, 0) * ISNULL(IC_DON_HANG_NHAP_VAT_TU.TY_GIA, 0) " & _
                    "    * ISNULL(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP, 0)) AS ThanhTien, ISNULL(IC_DON_HANG_NHAP_VAT_TU.TT_TAX,0) AS TAX, " & _
                    "    SUM(ISNULL(IC_DON_HANG_NHAP_VAT_TU.DON_GIA, 0) * ISNULL(IC_DON_HANG_NHAP_VAT_TU.TY_GIA, 0) " & _
                    "    * ISNULL(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP, 0)) + (ISNULL(IC_DON_HANG_NHAP_VAT_TU.TT_TAX,0)) AS Total, " & _
                    "    IC_DON_HANG_NHAP.NGAY AS NGAY_NHAP, IC_DON_HANG_NHAP.NGUOI_LAP, IC_DON_HANG_NHAP.NGUOI_GIAO, V3.TEN_CONG_TY, " & _
                    "    IC_DON_HANG_NHAP.SO_CHUNG_TU, IC_DON_HANG_NHAP.NGAY_CHUNG_TU, IC_DON_HANG_NHAP.GHI_CHU " & _
                    "  FROM         IC_DON_HANG_NHAP INNER JOIN " & _
                    " IC_DON_HANG_NHAP_VAT_TU ON IC_DON_HANG_NHAP.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT INNER JOIN " & _
                    " IC_PHU_TUNG ON IC_DON_HANG_NHAP_VAT_TU.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
                    " LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT INNER JOIN " & _
                    " DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT LEFT OUTER JOIN " & _
                    " ( " & _
                    " select MS_KH , TEN_CONG_TY  from KHACH_HANG  " & _
                    " UNION " & _
                    " select MS_CONG_NHAN , ISNULL(HO,'') + ' ' + ISNULL(TEN,'')  from CONG_NHAN  " & _
                    " ) " & _
                    " V3 ON IC_DON_HANG_NHAP.NGUOI_NHAP = V3.MS_KH " & _
                    " where dbo.IC_PHU_TUNG.MS_LOAI_VT in ( select MS_LOAI_VT from " & TableTam & " where isnull(chon,0) <>0)" & _
                    " and dbo.IC_DON_HANG_NHAP.MS_KHO ='" & Kho & "' AND MONTH(IC_DON_HANG_NHAP.NGAY)=" & Month(cmbThang.DateTime.ToShortDateString()) & " AND  YEAR(IC_DON_HANG_NHAP.NGAY) =" & Year(cmbThang.DateTime.ToShortDateString()) & _
                    " GROUP BY IC_DON_HANG_NHAP_VAT_TU.MS_PT, IC_DON_HANG_NHAP.MS_DH_NHAP_PT, IC_DON_HANG_NHAP.NGAY, LOAI_VT.TEN_LOAI_VT_TV,  " & _
                    " IC_PHU_TUNG.TEN_PT, DON_VI_TINH.TEN_1, IC_DON_HANG_NHAP_VAT_TU.TT_TAX, IC_DON_HANG_NHAP.NGUOI_GIAO,   " & _
                    "  IC_DON_HANG_NHAP.SO_CHUNG_TU, IC_DON_HANG_NHAP.NGUOI_LAP, IC_DON_HANG_NHAP.NGAY_CHUNG_TU, " & _
                    "  IC_DON_HANG_NHAP.GHI_CHU, V3.TEN_CONG_TY ORDER BY ROW_NUMBER() OVER(ORDER BY NGAY)"

            vtbTam = New DataTable
            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            If vtbTam.Rows.Count <= 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If


            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
            If sPath = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "PhaiChonFile", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Commons.Modules.ObjSystems.MLoadXtraGrid(GridExport, GridView1, vtbTam, True, True, True, True, True, "ucBangKeCTNhapKho")
            GridExport.DataSource = vtbTam
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
        Dim Dong As Integer = 0
        Try
            excelWorkbooks = excelApplication.Workbooks
            excelWorkbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            excelWorkSheet = excelWorkbook.Sheets(1)
            Dim sTmp As String
            sTmp = ""
            Dim TCot As Integer
            TCot = vtbTam.Columns.Count
            excelApplication.Cells.Font.Name = "Times New Roman"
            excelApplication.Cells.Font.Size = 10
            excelApplication.ActiveWindow.DisplayGridlines = False

            With excelWorkSheet
                Dim DangThem As Microsoft.Office.Interop.Excel.XlInsertShiftDirection
                Dim MRange As Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, 1))
                MRange.EntireColumn.Insert(DangThem)
                Dong = 1
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 9, Dong)
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 7, 80, 37, Application.StartupPath)
                Dong = 5
                TCot = TCot + 1
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "TieuDe", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 16, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "Thang", Commons.Modules.TypeLanguage) & "  " & cmbThang.DateTime.Month.ToString & "  " & _
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "Nam", Commons.Modules.TypeLanguage) & "  " & cmbThang.DateTime.Year.ToString
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong + 1, 1, "@", 12, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong + 1, TCot)
                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True, True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)
                Dong = Dong + 2
                Dong = Dong + 3

                Dim oldCultureInfo As System.Globalization.CultureInfo
                oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture

                .Range(.Cells(11, 9), .Cells(11 + vtbTam.Rows.Count, 9)).NumberFormat = "_(* " + Commons.Modules.sSoLeSL + "_);_(* (" + Commons.Modules.sSoLeSL + ");_(* ""-""_);_(@_)"
                .Range(.Cells(11, 10), .Cells(11 + vtbTam.Rows.Count, 10)).NumberFormat = "_(* " + Commons.Modules.sSoLeDG + "_);_(* (" + Commons.Modules.sSoLeDG + ");_(* ""-""_);_(@_)"
                .Range(.Cells(11, 11), .Cells(11 + vtbTam.Rows.Count, 13)).NumberFormat = "_(* " + Commons.Modules.sSoLeTT + "_);_(* (" + Commons.Modules.sSoLeTT + ");_(* ""-""_);_(@_)"
                .Range(.Cells(11, 14), .Cells(11 + vtbTam.Rows.Count, 14)).NumberFormat = oldCultureInfo.DateTimeFormat.ShortDatePattern

                .Range(.Cells(10, 2), .Cells(10, 18)).Interior.Color = RGB(255, 255, 255)
                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 1)).ColumnWidth = 0.25
                .Range(.Cells(Dong + 4, 2), .Cells(Dong + 5, 2)).ColumnWidth = 5.29
                .Range(.Cells(Dong + 4, 3), .Cells(Dong + 5, 3)).ColumnWidth = 8.71
                .Range(.Cells(Dong + 4, 4), .Cells(Dong + 5, 4)).ColumnWidth = 11.43
                .Range(.Cells(Dong + 4, 5), .Cells(Dong + 5, 5)).ColumnWidth = 11.43
                .Range(.Cells(Dong + 4, 6), .Cells(Dong + 5, 6)).ColumnWidth = 32.71
                .Range(.Cells(Dong + 4, 7), .Cells(Dong + 5, 7)).ColumnWidth = 8
                .Range(.Cells(Dong + 4, 8), .Cells(Dong + 5, 8)).ColumnWidth = 20
                .Range(.Cells(Dong + 4, 9), .Cells(Dong + 5, 9)).ColumnWidth = 10.71
                .Range(.Cells(Dong + 4, 10), .Cells(Dong + 5, 10)).ColumnWidth = 12.14
                .Range(.Cells(Dong + 4, 11), .Cells(Dong + 5, 11)).ColumnWidth = 12.14
                .Range(.Cells(Dong + 4, 12), .Cells(Dong + 5, 12)).ColumnWidth = 12.14
                .Range(.Cells(Dong + 4, 13), .Cells(Dong + 5, 13)).ColumnWidth = 12.14
                .Range(.Cells(Dong + 4, 14), .Cells(Dong + 5, 14)).ColumnWidth = 10
                .Range(.Cells(Dong + 4, 15), .Cells(Dong + 5, 15)).ColumnWidth = 18
                .Range(.Cells(Dong + 4, 16), .Cells(Dong + 5, 16)).ColumnWidth = 20
                .Range(.Cells(Dong + 4, 17), .Cells(Dong + 5, 17)).ColumnWidth = 20
                .Range(.Cells(Dong + 4, 18), .Cells(Dong + 5, 18)).ColumnWidth = 16.86
                .Range(.Cells(Dong + 4, 19), .Cells(Dong + 5, 19)).ColumnWidth = 10.29
                .Range(.Cells(Dong + 4, 20), .Cells(Dong + 5, 20)).ColumnWidth = 20

                i = 10 + vtbTam.Rows.Count + 1
                .Range(.Cells(10 + vtbTam.Rows.Count + 1, 11), .Cells(10 + vtbTam.Rows.Count + 1, 11)).Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(11, 11) + ":" + Commons.Modules.MExcel.TimDiemExcel(10 + vtbTam.Rows.Count, 11) + ")"
                .Range(.Cells(10 + vtbTam.Rows.Count + 1, 11), .Cells(10 + vtbTam.Rows.Count + 1, 11)).Font.Bold = True
                .Range(.Cells(10 + vtbTam.Rows.Count + 1, 12), .Cells(10 + vtbTam.Rows.Count + 1, 12)).Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(11, 12) + ":" + Commons.Modules.MExcel.TimDiemExcel(10 + vtbTam.Rows.Count, 12) + ")"
                .Range(.Cells(10 + vtbTam.Rows.Count + 1, 12), .Cells(10 + vtbTam.Rows.Count + 1, 12)).Font.Bold = True
                .Range(.Cells(10 + vtbTam.Rows.Count + 1, 13), .Cells(10 + vtbTam.Rows.Count + 1, 13)).Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(11, 13) + ":" + Commons.Modules.MExcel.TimDiemExcel(10 + vtbTam.Rows.Count, 13) + ")"
                .Range(.Cells(10 + vtbTam.Rows.Count + 1, 13), .Cells(10 + vtbTam.Rows.Count + 1, 13)).Font.Bold = True

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongKeVatTu", "TongCong", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 10 + vtbTam.Rows.Count + 1, 2, "@", 10, True, Excel.XlHAlign.xlHAlignRight, Excel.XlVAlign.xlVAlignCenter, True, 10 + vtbTam.Rows.Count + 1, 10)


                .Range(.Cells(10, 2), .Cells(11 + vtbTam.Rows.Count, 19)).Borders.LineStyle = 1
                .Range(.Cells(10, 2), .Cells(10, 20)).HorizontalAlignment = 3
                .Range(.Cells(10, 2), .Cells(10, 20)).VerticalAlignment = 2
                .Range(.Cells(10, 2), .Cells(10, 20)).WrapText = True
                .Range(.Cells(10, 2), .Cells(10, 20)).Interior.Color = RGB(255, 255, 255)
                .Range(.Cells(10, 2), .Cells(10, 20)).Font.Bold = True
                .Range(.Cells(10, 2), .Cells(11 + vtbTam.Rows.Count, 20)).BorderAround(1, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic)




                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "NguoiLamBaoCao", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 11 + vtbTam.Rows.Count + 3, 3, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, 11 + vtbTam.Rows.Count + 2, 3)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "NgayThangNam", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 11 + vtbTam.Rows.Count + 2, 12, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, 11 + vtbTam.Rows.Count + 2, 14)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "PhongQuanlySX", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 11 + vtbTam.Rows.Count + 3, 12, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, 11 + vtbTam.Rows.Count + 3, 14)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeCTNhapKho", "Kho", Commons.Modules.TypeLanguage) & " : " & cmbKho.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 8, 5, "@", 10, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, True, 8, 5)


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
            If Commons.Modules.bDoiFontReport Then excelApplication.Cells.Font.Name = Commons.Modules.sFontReport
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
        Commons.Modules.ObjSystems.XoaTable(TableTam)
        Commons.Modules.ObjSystems.XoaTable(TableTamDL)
        Commons.Modules.ObjSystems.XoaTable(TableExcel)
    End Sub



    Private Sub ThreadMethod()
        'OpenFileDialog dlg = new OpenFileDialog()
        Dim dlg As New OpenFileDialog
        dlg.ShowDialog()

    End Sub
End Class
