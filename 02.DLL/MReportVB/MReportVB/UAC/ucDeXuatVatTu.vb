Imports Microsoft.ApplicationBlocks.Data

Public Class ucDeXuatVatTu
    Private sql As String = ""
    Private vtbDonVi As New DataTable
    Private vtbPhongBan As New DataTable

    Private Sub ucDeXuatVatTu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbThang.DateTime = Today
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 0, Commons.Modules.UserName))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbDonVi, dtTmp, "MS_DON_VI", "TEN_DON_VI", "")
        Catch ex As Exception

        End Try

        If cmbDonVi.Text = "" Then Exit Sub
        Try
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetToUserAll", 1, cmbDonVi.EditValue, Commons.Modules.UserName))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbPhongBan, dtTmp, "MS_TO", "TEN_TO", lblPhongban.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbDonVi_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDonVi.EditValueChanged
        If cmbDonVi.Text = "" Then Exit Sub
        Try
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetToUserAll", 1, cmbDonVi.EditValue, Commons.Modules.UserName))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbPhongBan, dtTmp, "MS_TO", "TEN_TO", lblPhongban.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Try
            ParentForm.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click
        Dim Thang As Integer
        Dim Nam As Integer
        Dim DonVi As String = ""
        Dim PhongBan As String = ""
        Dim vtbTam As New DataTable
        Dim sPath As String = ""
        Try
            Thang = CInt(cmbThang.Text.Substring(0, 2))
            Nam = CInt(cmbThang.Text.Substring(3, 4))
            DonVi = cmbDonVi.EditValue.ToString
            PhongBan = cmbPhongBan.EditValue.ToString
            Dim sBTDV As String
            sBTDV = "DV_TMP" & Commons.Modules.UserName
            Commons.Modules.ObjSystems.XoaTable(sBTDV)



            sql = " SELECT DISTINCT T2.MS_DON_VI, T2.MS_TO INTO " & sBTDV &
                            " FROM            dbo.NHOM_TO_PHONG_BAN AS T1 INNER JOIN " &
                            "                          dbo.TO_PHONG_BAN AS T2 ON T1.MS_TO = T2.MS_TO INNER JOIN " &
                            "                          dbo.USERS AS T3 ON T1.GROUP_ID = T3.GROUP_ID " &
                            " WHERE        (T3.USERNAME = N'" & Commons.Modules.UserName & "') "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)


            sql = "SELECT ROW_NUMBER() OVER(PARTITION BY dbo.LOAI_VT.TEN_LOAI_VT_TV ORDER BY dbo.LOAI_VT.TEN_LOAI_VT_TV,dbo.IC_PHU_TUNG.MS_PT DESC) as STT, dbo.IC_PHU_TUNG.MS_PT, dbo.IC_PHU_TUNG.TEN_PT, dbo.IC_PHU_TUNG.QUY_CACH,DE_XUAT_MUA_HANG.MS_DE_XUAT , dbo.DE_XUAT_MUA_HANG_CHI_TIET.NHAN_HIEU, " &
                        " dbo.DE_XUAT_MUA_HANG_CHI_TIET.NHA_CUNG_CAP, dbo.DON_VI_TINH.TEN_1, dbo.DE_XUAT_MUA_HANG_CHI_TIET.TON_KHO, " &
                        " dbo.DE_XUAT_MUA_HANG_CHI_TIET.SL_DA_DUYET, isnull(dbo.DE_XUAT_MUA_HANG_CHI_TIET.DON_GIA,0) * isnull( dbo.DE_XUAT_MUA_HANG_CHI_TIET.TY_GIA,0) as DON_GIA, " &
                        " dbo.DE_XUAT_MUA_HANG_CHI_TIET.THANH_TIEN_VND, dbo.DE_XUAT_MUA_HANG_CHI_TIET.GHI_CHU,  " &
                        " dbo.LOAI_VT.TEN_LOAI_VT_TV " &
                        " FROM dbo.TO_PHONG_BAN INNER JOIN dbo.DON_VI ON dbo.TO_PHONG_BAN.MS_DON_VI = dbo.DON_VI.MS_DON_VI INNER JOIN " &
                        " dbo.IC_PHU_TUNG INNER JOIN " &
                        " dbo.DE_XUAT_MUA_HANG_CHI_TIET ON dbo.IC_PHU_TUNG.MS_PT = dbo.DE_XUAT_MUA_HANG_CHI_TIET.MS_PT INNER JOIN " &
                        " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT INNER JOIN " &
                        " dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT INNER JOIN " &
                        " dbo.DE_XUAT_MUA_HANG ON dbo.DE_XUAT_MUA_HANG_CHI_TIET.MS_DE_XUAT = dbo.DE_XUAT_MUA_HANG.MS_DE_XUAT ON  " &
                        " dbo.TO_PHONG_BAN.TEN_TO = dbo.DE_XUAT_MUA_HANG.PHONG_BAN INNER JOIN " & sBTDV &
                        " AS T1 ON dbo.TO_PHONG_BAN.MS_DON_VI = T1.MS_DON_VI AND dbo.TO_PHONG_BAN.MS_TO = T1.MS_TO  " &
                        "  where 1 = 1 and month(DE_XUAT_MUA_HANG.NGAY_LAP)=" & Thang & " and year(DE_XUAT_MUA_HANG.NGAY_LAP)=" & Nam & " and TO_PHONG_BAN.MS_DON_VI=N'" & DonVi & "' "
            If PhongBan <> "-1" Then
                sql = sql & " and TO_PHONG_BAN.MS_TO=N'" & PhongBan & "'"
            End If
            vtbTam = New DataTable
            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            Commons.Modules.ObjSystems.XoaTable(sBTDV)

            If vtbTam.Rows.Count <= 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDeXuatVatTu", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
            'sPath = "d:\111L.xls"
            If sPath = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDeXuatVatTu", "PhaiChonFile", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Commons.Modules.ObjSystems.MLoadXtraGrid(GridExport, GridView1, vtbTam, True, True, True, True, True, "ucDeXuatVatTu")
            GridExport.DataSource = vtbTam
            GridView1.Columns("TEN_LOAI_VT_TV").Group()
            GridExport.ExportToXls(sPath)

            Commons.Modules.ObjSystems.XoaTable(sBTDV)

        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "InKhongThanhCong",
                Commons.Modules.TypeLanguage) + vbCrLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

        Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()
        Dim excelWorkbooks As Excel.Workbooks
        Dim excelWorkbook As Excel.Workbook
        Dim excelWorkSheet As Excel.Worksheet

        Try
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
            excelApplication.Visible = True
            With excelWorkSheet
                Dim DangThem As Microsoft.Office.Interop.Excel.XlInsertShiftDirection
                Dim MRange As Excel.Range = excelWorkSheet.Range(excelWorkSheet.Cells(1, 1), excelWorkSheet.Cells(1, 1))
                MRange.EntireColumn.Insert(DangThem)


                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, 1)
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 6, 1, TCot)
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 7, 80, 37, Application.StartupPath)

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, True, True, True,
                        True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 90)

                TCot = TCot + 1
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDeXuatVatTu", "TieuDe", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 16, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDeXuatVatTu", "Thang", Commons.Modules.TypeLanguage) & "  " & cmbThang.Text.Substring(0, 2) & "  " &
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDeXuatVatTu", "Nam", Commons.Modules.TypeLanguage) & "  " & cmbThang.Text.Substring(3, 4)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong + 1, 1, "@", 12, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong + 1, TCot)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "TONGCONG", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 3, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 5)

                Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", 10 + GridView1.RowCount + vtbTam.Rows.Count + 1, 13, 10 + GridView1.RowCount + vtbTam.Rows.Count + 1, 13, 11, 13, 10 + GridView1.RowCount + vtbTam.Rows.Count, 13, 10, True, 10, "#,##0")

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, Commons.Modules.sSoLeSL, True, 11, 10, 10 + GridView1.RowCount + vtbTam.Rows.Count + 2, 10)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, Commons.Modules.sSoLeSL, True, 11, 11, 10 + GridView1.RowCount + vtbTam.Rows.Count + 2, 11)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, Commons.Modules.sSoLeDG, True, 11, 12, 10 + GridView1.RowCount + vtbTam.Rows.Count + 2, 12)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, Commons.Modules.sSoLeTT, True, 11, 13, 10 + GridView1.RowCount + vtbTam.Rows.Count + 2, 13)


                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 1)).ColumnWidth = 0.25
                .Range(.Cells(Dong + 4, 2), .Cells(Dong + 5, 2)).ColumnWidth = 0
                .Range(.Cells(Dong + 4, 3), .Cells(Dong + 5, 3)).ColumnWidth = 3.57
                .Range(.Cells(Dong + 4, 4), .Cells(Dong + 5, 4)).ColumnWidth = 12
                .Range(.Cells(Dong + 4, 5), .Cells(Dong + 5, 5)).ColumnWidth = 20
                .Range(.Cells(Dong + 4, 6), .Cells(Dong + 5, 6)).ColumnWidth = 15.43
                .Range(.Cells(Dong + 4, 7), .Cells(Dong + 5, 7)).ColumnWidth = 14
                .Range(.Cells(Dong + 4, 8), .Cells(Dong + 5, 8)).ColumnWidth = 14
                .Range(.Cells(Dong + 4, 9), .Cells(Dong + 5, 9)).ColumnWidth = 16.86
                .Range(.Cells(Dong + 4, 10), .Cells(Dong + 5, 10)).ColumnWidth = 7.57
                .Range(.Cells(Dong + 4, 11), .Cells(Dong + 5, 11)).ColumnWidth = 9.86
                .Range(.Cells(Dong + 4, 12), .Cells(Dong + 5, 12)).ColumnWidth = 10.86
                .Range(.Cells(Dong + 4, 13), .Cells(Dong + 5, 13)).ColumnWidth = 14.29
                .Range(.Cells(Dong + 4, 14), .Cells(Dong + 5, 14)).ColumnWidth = 12
                .Range(.Cells(Dong + 4, 15), .Cells(Dong + 5, 15)).ColumnWidth = 23
                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, TCot)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, TCot)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, TCot)).WrapText = True
                '.Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, TCot)).Interior.Color = RGB(255, 255, 255)
                .Range(.Cells(10, 2), .Cells(10 + GridView1.RowCount + vtbTam.Rows.Count + 1, 15)).Borders.LineStyle = 1
                .Range(.Cells(10, 1), .Cells(10 + GridView1.RowCount + vtbTam.Rows.Count + 1, 1)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = 1

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "DEXUAT", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 3, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 4)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "TRUONGNHAMAY", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 7, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 10)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "KHOISANXUAT", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 13, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 15)


                sTmp = lblDonVi.Text + ": " + cmbDonVi.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 7, 5, "@", 10, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, True, 7, 7)

                sTmp = lblPhongban.Text + ": " + cmbPhongBan.Text
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, 7, 8, "@", 10, True, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, True, 7, 10)


                'Try
                '    .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                '    .PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
                '    .PageSetup.LeftMargin = 18
                '    .PageSetup.RightMargin = 18
                '    .PageSetup.TopMargin = 18
                '    .PageSetup.BottomMargin = 18
                '    .PageSetup.HeaderMargin = 18
                '    .PageSetup.FooterMargin = 18
                '    .PageSetup.Zoom = 75
                'Catch ex As Exception

                'End Try

            End With

            'excelApplication.ActiveWindow.DisplayGridlines = False
            excelApplication.Visible = True
            excelWorkbook.Save()
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
            Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "InKhongThanhCong",
                Commons.Modules.TypeLanguage) + vbCrLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
        End Try

        Cursor = Cursors.Default


    End Sub
End Class
