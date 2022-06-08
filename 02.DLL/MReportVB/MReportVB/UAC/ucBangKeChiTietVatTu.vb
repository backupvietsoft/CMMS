Imports Microsoft.ApplicationBlocks.Data

Public Class ucBangKeChiTietVatTu
    Private sql As String = ""
    Private vtbKho As New DataTable
    Private vtbLoaiVT As New DataTable

    Private Sub ucBangKeChiTietVatTu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
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

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click
        Dim TableTam As String = "BKCTVT" & Commons.Modules.UserName
        Dim TableTamDL As String = "BKCTVTDL" & Commons.Modules.UserName
        Dim TableExcel As String = "TableExcel" & Commons.Modules.UserName
        Dim Kho As String
        Dim Thang As String
        Dim vtbTam As New DataTable
        Dim SoLan As Integer
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
            sql = "SELECT ROW_NUMBER() OVER( PARTITION BY IC_DON_HANG_NHAP_VAT_TU.MS_PT " & _
                  " ORDER BY NGAY) AS STT ,IC_DON_HANG_NHAP_VAT_TU.MS_PT, IC_DON_HANG_NHAP.MS_DH_NHAP_PT, IC_DON_HANG_NHAP.NGAY,  " & _
                  "  sum(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP) as SoLuong,  " & _
                  "  sum(isnull(IC_DON_HANG_NHAP_VAT_TU.DON_GIA,0) * isnull(IC_DON_HANG_NHAP_VAT_TU.TY_GIA,0)* ISNULL(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP,0)) " & _
                  "  / sum(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP) AS DonGia, " & _
                  "  sum(isnull(IC_DON_HANG_NHAP_VAT_TU.DON_GIA,0) * isnull(IC_DON_HANG_NHAP_VAT_TU.TY_GIA,0)* ISNULL(IC_DON_HANG_NHAP_VAT_TU.SL_THUC_NHAP,0)) as ThanhTien " & _
                  " , dbo.LOAI_VT.MS_LOAI_VT, dbo.LOAI_VT.TEN_LOAI_VT_TV,dbo.LOAI_VT.TEN_LOAI_VT_TA, dbo.LOAI_VT.TEN_LOAI_VT_TH,dbo.IC_PHU_TUNG.TEN_PT " & _
                  ",dbo.DON_VI_TINH.TEN_1, dbo.DON_VI_TINH.TEN_2,dbo.DON_VI_TINH.TEN_3" & _
                  " into " & TableTamDL & _
                  " FROM         dbo.IC_DON_HANG_NHAP INNER JOIN " & _
                  "  dbo.IC_DON_HANG_NHAP_VAT_TU ON dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT INNER JOIN " & _
                  "  dbo.IC_PHU_TUNG ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " & _
                  "  dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT INNER JOIN " & _
                  "    dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT " & _
                  " where dbo.IC_PHU_TUNG.MS_LOAI_VT in ( select MS_LOAI_VT from " & TableTam & " where isnull(chon,0) <>0)" & _
                  " and dbo.IC_DON_HANG_NHAP.MS_KHO ='" & Kho & "' AND MONTH(IC_DON_HANG_NHAP.NGAY)=" & cmbThang.DateTime.Month.ToString & " AND  YEAR(IC_DON_HANG_NHAP.NGAY) =" & cmbThang.DateTime.Year.ToString & _
                  "  GROUP BY IC_DON_HANG_NHAP_VAT_TU.MS_PT, IC_DON_HANG_NHAP.MS_DH_NHAP_PT, IC_DON_HANG_NHAP.NGAY ,dbo.LOAI_VT.MS_LOAI_VT, dbo.LOAI_VT.TEN_LOAI_VT_TV ,dbo.LOAI_VT.TEN_LOAI_VT_TA, dbo.LOAI_VT.TEN_LOAI_VT_TH,dbo.IC_PHU_TUNG.TEN_PT " & _
                  ",dbo.DON_VI_TINH.TEN_1, dbo.DON_VI_TINH.TEN_2,dbo.DON_VI_TINH.TEN_3"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

            sql = "select MS_PT, TEN_PT,MS_LOAI_VT,TEN_LOAI_VT_TV,TEN_LOAI_VT_TA,TEN_LOAI_VT_TH,TEN_1, TEN_2,TEN_3, CONVERT(INT, 0) AS SOLAN  into " & TableExcel & " from " & TableTamDL
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

            sql = "UPDATE " & TableExcel & " SET SOLAN=A.SOLAN FROM " & TableExcel & " B INNER JOIN " & _
                  "( SELECT MS_PT, MAX(STT) AS SOLAN FROM " & TableTamDL & " GROUP BY MS_PT ) A ON A.MS_PT =B.MS_PT"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

            sql = "alter table " & TableExcel & " add TongSoLuong numeric(19,6)"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

            sql = "alter table " & TableExcel & " add TongDonGia numeric(19,6)"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

            sql = "alter table " & TableExcel & " add TongThanhTien numeric(19,6)"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)


            ChuoiLoc = "select DISTINCT MS_PT, TEN_PT,case when " & Commons.Modules.TypeLanguage & "=0  THEN TEN_1 ELSE case when " & Commons.Modules.TypeLanguage & "=1 THEN TEN_2 ELSE TEN_3 END END  AS DVT, SOLAN," & _
                       " case when " & Commons.Modules.TypeLanguage & "=0  THEN TEN_LOAI_VT_TV ELSE case when " & Commons.Modules.TypeLanguage & "=1 THEN TEN_LOAI_VT_TA ELSE TEN_LOAI_VT_TH END END  AS TEN_LOAI_VT "

            sql = "select isnull(max(STT),0) as Nhom  from " & TableTamDL
            vtbTam = New DataTable
            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            If vtbTam.Rows.Count > 0 Then
                SoLan = Convert.ToInt32(vtbTam.Rows(0).Item("Nhom").ToString)
                For i = 1 To SoLan

                    sql = "alter table " & TableExcel & " add SoLuong" & i & " numeric(19,6)"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    sql = "alter table " & TableExcel & " add DonGia" & i & " numeric(19,6)"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    sql = "alter table " & TableExcel & " add ThanhTien" & i & " numeric(19,6)"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    sql = "alter table " & TableExcel & " add Ngay_nhap" & i & " Datetime"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    sql = "update " & TableExcel & " set soluong" & i & "=a.soluong,DonGia" & i & "=a.DonGia,ThanhTien" & i & "=a.thanhTien,Ngay_nhap" & i & "=a.Ngay, TongSoLuong =isnull(tongsoluong,0) + isnull(a.soluong,0) ," & _
                          " tongthanhtien =isnull(tongthanhtien,0) + isnull(a.thanhtien,0) " & _
                          " from " & TableExcel & " b inner join ( SELECT MS_PT,NGAY, SOLUONG, DONGIA,THANHTIEN  from " & TableTamDL & " WHERE STT=" & i & ") A ON A.MS_PT=B.MS_PT "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    ChuoiLoc = ChuoiLoc & ",Soluong" & i & ",DonGia" & i & ",ThanhTien" & i & ",Ngay_nhap" & i


                Next
            End If
            sql = "update " & TableExcel & " set tongdongia =isnull(tongthanhtien,0) / tongsoluong where isnull(tongsoluong,0) <>0"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

            ChuoiLoc = ChuoiLoc & ",Tongsoluong, tongdongia, tongthanhtien FROM " & TableExcel & " ORDER BY TEN_LOAI_VT ,MS_PT"

            vtbTam = New DataTable
            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, ChuoiLoc))
            If vtbTam.Rows.Count <= 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
            If sPath = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "PhaiChonFile", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Commons.Modules.ObjSystems.MLoadXtraGrid(GridExport, GridView1, vtbTam, True, True, True, True, True, "ucBangKeChiTietVatTu")
            GridExport.DataSource = vtbTam

            GridView1.Columns("TEN_LOAI_VT").Group()
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
            excelApplication.ActiveWindow.DisplayGridlines = False
            With excelWorkSheet

                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, 5)
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 7, 80, 37, Application.StartupPath)
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "TieuDe", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 16, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "Thang", Commons.Modules.TypeLanguage) & "  " & cmbThang.DateTime.Month.ToString & "  " & _
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "Nam", Commons.Modules.TypeLanguage) & "  " & cmbThang.DateTime.Year.ToString

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong + 1, 1, "@", 12, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong + 1, TCot)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "TONGCONG", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 2, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 3)

                .Range(.Cells(Dong + 5, 2), .Cells(Dong + 5, 2)).UnMerge()
                .Range(.Cells(Dong + 4, 2), .Cells(Dong + 5, 2)).Merge()
                .Cells(Dong + 4, 2) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "MS_PT", Commons.Modules.TypeLanguage)
                .Range(.Cells(Dong + 4, 3), .Cells(Dong + 5, 3)).Merge()
                .Range(.Cells(Dong + 4, 4), .Cells(Dong + 5, 4)).Merge()
                .Range(.Cells(Dong + 4, 5), .Cells(Dong + 5, 5)).Merge()

                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 1)).ColumnWidth = 0.05
                .Range(.Cells(Dong + 4, 2), .Cells(Dong + 5, 2)).ColumnWidth = 20
                .Range(.Cells(Dong + 4, 3), .Cells(Dong + 5, 3)).ColumnWidth = 36
                .Range(.Cells(Dong + 4, 4), .Cells(Dong + 5, 4)).ColumnWidth = 3.86
                .Range(.Cells(Dong + 4, 5), .Cells(Dong + 5, 5)).ColumnWidth = 4.71
                Dim oldCultureInfo As System.Globalization.CultureInfo
                oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture

                For i = 1 To SoLan
                    Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 6 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 6 + 4 * (i - 1), Dong + 6, 6 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 5, 6 + 4 * (i - 1), 10, True, 10, Commons.Modules.sSoLeSL)
                    Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 8 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 8 + 4 * (i - 1), Dong + 6, 8 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 5, 8 + 4 * (i - 1), 10, True, 10, Commons.Modules.sSoLeTT)

                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 6, Commons.Modules.sSoLeSL, True, Dong + 7, 6 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 7, 6 + 4 * (i - 1))
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9.29, Commons.Modules.sSoLeDG, True, Dong + 7, 7 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 7, 7 + 4 * (i - 1))
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, Commons.Modules.sSoLeTT, True, Dong + 7, 8 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 7, 8 + 4 * (i - 1))
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.29, oldCultureInfo.DateTimeFormat.ShortDatePattern, True, Dong + 7, 9 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 7, 9 + 4 * (i - 1))

                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "LANNHAP", Commons.Modules.TypeLanguage) & " " & i
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong + 4, 6 + 4 * (i - 1), "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong + 4, 6 + 4 * (i - 1) + 3)
                Next i
                i = SoLan + 1

                Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 6 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 6 + 4 * (i - 1), Dong + 6, 6 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 5, 6 + 4 * (i - 1), 10, True, 10, Commons.Modules.sSoLeSL)
                Commons.Modules.MExcel.MFuntion(excelWorkSheet, "SUM", GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 8 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 8 + 4 * (i - 1), Dong + 6, 8 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 5, 8 + 4 * (i - 1), 10, True, 10, Commons.Modules.sSoLeTT)

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, Commons.Modules.sSoLeSL, True, Dong + 7, 6 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 6 + 4 * (i - 1))
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9.29, Commons.Modules.sSoLeDG, True, Dong + 7, 7 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 7 + 4 * (i - 1))
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.14, Commons.Modules.sSoLeTT, True, Dong + 7, 8 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 8 + 4 * (i - 1))
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.29, oldCultureInfo.DateTimeFormat.ShortDatePattern, True, Dong + 7, 9 + 4 * (i - 1), GridView1.RowCount + vtbTam.Rows.Count + Dong + 6, 9 + 4 * (i - 1))

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "TONGCONG", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong + 4, 6 + 4 * (i - 1), "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong + 4, 6 + 4 * (i - 1) + 2)

                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "NguoiLamBaoCao", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 9, 3, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 9, 3)
                If 6 + 4 * (i - 1) > 15 Then
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "Ngay ... Thang ... Nam ...", Commons.Modules.TypeLanguage)
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 15, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 18)
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "PhongQuanLySanXuat", Commons.Modules.TypeLanguage)
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 9, 15, "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 9, 18)

                Else
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "Ngay ... Thang ... Nam ...", Commons.Modules.TypeLanguage)
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 6 + 4 * (i - 1), "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 8, 6 + 4 * (i - 1) + 3)
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBangKeChiTietVatTu", "PhongQuanLySanXuat", Commons.Modules.TypeLanguage)
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, GridView1.RowCount + vtbTam.Rows.Count + Dong + 9, 6 + 4 * (i - 1), "@", 10, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, GridView1.RowCount + vtbTam.Rows.Count + Dong + 9, 6 + 4 * (i - 1) + 3)

                End If

                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 5 + (SoLan + 1) * 4 - 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 5 + (SoLan + 1) * 4 - 1)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 5 + (SoLan + 1) * 4 - 1)).WrapText = True

                .Range(.Cells(Dong + 4, 1), .Cells(Dong + 5, 5 + (SoLan + 1) * 4 - 1)).Interior.Color = RGB(255, 255, 255)
                .Range(.Cells(Dong + 4, 2), .Cells(Dong + 6 + GridView1.RowCount + vtbTam.Rows.Count, 5 + (SoLan + 1) * 4 - 1)).Borders.LineStyle = 1
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

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        ParentForm.Close()
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
End Class
