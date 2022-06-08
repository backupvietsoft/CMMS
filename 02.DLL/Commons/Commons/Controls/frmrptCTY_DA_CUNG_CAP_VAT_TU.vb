
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptCTY_DA_CUNG_CAP_VAT_TU
    Private SqlText As String = String.Empty

    Private Sub frmrptCTY_DA_CUNG_CAP_VAT_TU_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNCC_Kho"))
        cboNCC.DataSource = dt
        cboNCC.DisplayMember = "TEN_CONG_TY"
        cboNCC.ValueMember = "NGUOI_NHAP"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptCTY_DA_CUNG_CAP_VAT_TU()
        Me.Cursor = Cursors.Default
    End Sub



    Sub ShowrptCTY_DA_CUNG_CAP_VAT_TU()
        If cboNCC.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""

        Dim dtTable As New DataTable


        '    "CREATE TABLE [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY(MS_PT  NVARCHAR(25),TEN_PT NVARCHAR(250),QUY_CACH NVARCHAR(255),TEN_CONG_TY NVARCHAR(255)," &
        '" TEN_NDD NVARCHAR(250),DIA_CHI NVARCHAR(255),sFAX NVARCHAR(30),NGAY DATETIME,DON_GIA FLOAT, SO_LUONG FLOAT, sTEL nvarchar(15), NGOAI_TE NVARCHAR (6)) " &
        '" INSERT INTO [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY " &
        str = " SELECT * FROM(SELECT DISTINCT   IC_DON_HANG_NHAP_VAT_TU.MS_PT,TEN_PT,QUY_CACH, " &
        " ( select TOP 1 MAX(NGAY)AS NGAY  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " &
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)" &
        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT  )AS NGAY, " &
        "(select TOP 1 DON_GIA FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " &
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " &
       "  AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND NGAY=(select TOP 1 MAX(NGAY)AS NGAY " &
        " FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " &
       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " &
        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ))AS DON_GIA, " &
       " ( SELECT SUM(SL_THUC_NHAP) FROM  IC_DON_HANG_NHAP D , IC_DON_HANG_NHAP_VAT_TU DVT WHERE " &
       "  D.MS_DH_NHAP_PT=DVT.MS_DH_NHAP_PT AND D.NGUOI_NHAP= dbo.IC_DON_HANG_NHAP.NGUOI_NHAP AND " &
       " DVT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT )AS SO_LUONG ,IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE" &
       " FROM         IC_DON_HANG_NHAP INNER JOIN " &
                     " IC_DON_HANG_NHAP_VAT_TU ON IC_DON_HANG_NHAP.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT INNER JOIN " &
                     " KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH  INNER JOIN IC_PHU_TUNG " &
       " ON IC_DON_HANG_NHAP_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT AND KHACH_HANG.MS_KH='" & cboNCC.SelectedValue & "') TMP WHERE SO_LUONG>0"

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If dtTable.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTable, False, True, True, True, True, Me.Name.ToString)
        grvChung.Columns("DON_GIA").VisibleIndex = 6
        grvChung.Columns("SO_LUONG").VisibleIndex = 5
        Dim dtTable2 As New DataTable
        Dim newstr As String
        newstr = "SELECT DISTINCT TEN_CONG_TY,DIA_CHI,TEL,Email,TEN_NDD FROM khach_hang WHERE TEN_CONG_TY = N'" & cboNCC.Text & "'"

        dtTable2.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, newstr))
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTable2, False, True, True, True, True, Me.Name.ToString)


        InDuLieu()

        'Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY")
        'While objReader.Read
        '    If objReader.Item("TONG") = 0 Then
        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '        objReader.Close()
        '        GoTo KetThuc
        '    End If
        'End While
        'objReader.Close()
        'CreaterptTIEU_DE_CONG_TY_VAT_TU()
        'ReportPreview("reports/rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY.rpt")

    End Sub


    Sub InDuLieu()

        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls") '"C:\Users\Administrator\Desktop\frmrptCTY_DA_CUNG_CAP_VAT_TU.xls" '
        If sPath = "" Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim excelApplication As New Excel.Application()

        Try
            Dim TCot As Integer = grvChung.Columns.Count
            Dim TDong As Integer = grvChung.RowCount
            Dim Dong As Integer = 1

            grdChung.ExportToXls(sPath)
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "",
                 False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)

            Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)


            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 7, Dong)


            Dong += 1

            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, (If(TCot > 16, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignCenter)), Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)


            Dong += 1

            Dim stmp As String = ""
            Dim sDiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "sDiaChi", Commons.Modules.TypeLanguage)
            Dim stTel As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "stTel", Commons.Modules.TypeLanguage)
            Dim sNDD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "sNDD", Commons.Modules.TypeLanguage)
            Dim sEmail As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "sEmail", Commons.Modules.TypeLanguage)

            stmp = lblNhacungcap.Text + " : " + cboNCC.Text
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 6)
            Dong += 1
            stmp = sNDD + " : " + grvChung.GetFocusedRowCellValue("TEN_NDD").ToString()
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 6)

            Dong += 1
            stmp = sDiaChi + " : " + grvChung.GetFocusedRowCellValue("DIA_CHI").ToString()
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 6)
            Dong += 1
            stmp = stTel + " : " + grvChung.GetFocusedRowCellValue("TEL").ToString()
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 6)
            Dim title As Excel.Range

            Dong += 1
            stmp = sEmail + " : " + grvChung.GetFocusedRowCellValue("Email").ToString()
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 6)

            Dong += 1


            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot)
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

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 15
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 11, 1, 11, 1)
            title.RowHeight = 12.75
            'set width for all columns'
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "@", True, Dong + 1, 1, TDong + Dong, 1)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 2,
             TDong + Dong, 2)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", True, Dong + 1, 3,
             TDong + Dong, 3)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "dd/mm/yyyy", True, Dong + 1, 4,
             TDong + Dong, 4)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "#,##0", True, Dong + 1, 5, TDong + Dong, 5)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "#,##0", True, Dong + 1, 6,
             TDong + Dong, 6)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 7,
             TDong + Dong, 7)



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
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Me.Cursor = Cursors.[Default]

    End Sub

    '    Sub ShowrptCTY_DA_CUNG_CAP_VAT_TU()
    '        If cboNCC.SelectedValue Is Nothing Then
    '            Exit Sub
    '        End If
    '        Dim str As String = ""
    '        Try
    '            str = "DROP TABLE rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
    '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '        Catch ex As Exception
    '        End Try
    '        str = "CREATE TABLE [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY(MS_PT  NVARCHAR(25),TEN_PT NVARCHAR(250),QUY_CACH NVARCHAR(255),TEN_CONG_TY NVARCHAR(255)," & _
    '        " TEN_NDD NVARCHAR(250),DIA_CHI NVARCHAR(255),sFAX NVARCHAR(30),NGAY DATETIME,DON_GIA FLOAT, SO_LUONG FLOAT, sTEL nvarchar(15), NGOAI_TE NVARCHAR (6)) " & _
    '        " INSERT INTO [DBO].rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY " & _
    '        " SELECT * FROM(SELECT DISTINCT   IC_DON_HANG_NHAP_VAT_TU.MS_PT,TEN_PT,QUY_CACH,KHACH_HANG.TEN_CONG_TY,TEN_NDD,KHACH_HANG.DIA_CHI ,KHACH_HANG.FAX " & _
    '        " ,( select TOP 1 MAX(NGAY)AS NGAY  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
    '       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)" & _
    '        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT  )AS NGAY, " & _
    '        "(select TOP 1 DON_GIA FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
    '       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
    '       "  AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND NGAY=(select TOP 1 MAX(NGAY)AS NGAY " & _
    '        " FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
    '       " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
    '        " AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ))AS DON_GIA, " & _
    '       " ( SELECT SUM(SL_THUC_NHAP) FROM  IC_DON_HANG_NHAP D , IC_DON_HANG_NHAP_VAT_TU DVT WHERE " & _
    '       "  D.MS_DH_NHAP_PT=DVT.MS_DH_NHAP_PT AND D.NGUOI_NHAP= dbo.IC_DON_HANG_NHAP.NGUOI_NHAP AND " & _
    '       " DVT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT )AS SO_LUONG ,KHACH_HANG.TEL,IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE" & _
    '       " FROM         IC_DON_HANG_NHAP INNER JOIN " & _
    '                     " IC_DON_HANG_NHAP_VAT_TU ON IC_DON_HANG_NHAP.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT INNER JOIN " & _
    '                     " KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG.MS_KH  INNER JOIN IC_PHU_TUNG " & _
    '       " ON IC_DON_HANG_NHAP_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT AND KHACH_HANG.MS_KH='" & cboNCC.SelectedValue & "') TMP WHERE SO_LUONG>0"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

    '        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY")
    '        While objReader.Read
    '            If objReader.Item("TONG") = 0 Then
    '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    '                objReader.Close()
    '                GoTo KetThuc
    '            End If
    '        End While
    '        objReader.Close()
    '        CreaterptTIEU_DE_CONG_TY_VAT_TU()
    '        ReportPreview("reports/rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY.rpt")
    'KetThuc:
    '        Try
    '            str = "DROP TABLE rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY"
    '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '            str = "DROP TABLE rptTIEU_DE_CONG_TY_VAT_TU"
    '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    Sub CreaterptTIEU_DE_CONG_TY_VAT_TU()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptTIEU_DE_CONG_TY_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE dbo.rptTIEU_DE_CONG_TY_VAT_TU(TypeLanguage int, Ngayin nvarchar(20), TrangIn nvarchar(20), TieuDe nvarchar(255)," & _
            "NhaCungCap nvarchar(50), DiaChi nvarchar(20),NguoiDaiDien nvarchar(50),DienThoai nvarchar(30), stFax nvarchar(5), " & _
            "STT nvarchar(5),MaPhuTung nvarchar(30),TenPT nvarchar(50), QuyCach nvarchar(30), SoLuong nvarchar(30), DonGia nvarchar(20), " & _
            "NgayCuoi nvarchar(30),Tong nvarchar(20), ThoiGian nvarchar(70)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim sTieudeReport As String = ""
        sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TieuDe2", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sNhaCungCap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NhaCungCap", Commons.Modules.TypeLanguage)
        Dim sDiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "DiaChi", Commons.Modules.TypeLanguage)
        Dim sNguoiDaiDien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TenNDD", Commons.Modules.TypeLanguage)
        Dim sDienThoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "stTel", Commons.Modules.TypeLanguage)
        Dim stFax As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "stFax", Commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MaPT", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sSoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "SoLuong", Commons.Modules.TypeLanguage)
        Dim sDonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "DonGia", Commons.Modules.TypeLanguage)
        Dim sNgayCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "NgayCuoi", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "Tong", Commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TenPT", Commons.Modules.TypeLanguage)

        SqlText = "INSERT INTO [DBO].rptTIEU_DE_CONG_TY_VAT_TU(commons.Modules.TypeLanguage,Ngayin,TrangIn,TieuDe, " & _
                "NhaCungCap,DiaChi,NguoiDaiDien,DienThoai,stFax,MaPhuTung,TenPT,QuyCach,SoLuong,DonGia,NgayCuoi,Tong,ThoiGian,STT )" & _
                "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
                "N'" & sTieudeReport & "',N'" & sNhaCungCap & "',N'" & sDiaChi & "',N'" & sNguoiDaiDien & "',N'" & sDienThoai & "',N'" & stFax & "',N'" & sMaPhuTung & "',N'" & TenPT & "',N'" & sQuyCach & "',N'" & sSoLuong & "',N'" & sDonGia & "'," & _
                        "N'" & sNgayCuoi & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sSTT & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
