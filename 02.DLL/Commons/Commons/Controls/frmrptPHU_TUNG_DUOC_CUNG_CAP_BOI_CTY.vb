
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY
    Private SqlText As String = String.Empty
    Private Sub frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_PT_KHO", Commons.Modules.UserName))
        cboVattu.DataSource = dt
        cboVattu.DisplayMember = "TEN_PT"
        cboVattu.ValueMember = "MS_PT"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY()
        Me.Cursor = Cursors.Default
    End Sub



    Sub ShowrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY()
        If cboVattu.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""

        '"CREATE TABLE [DBO].rptCTY_DA_CUNG_CAP_VAT_TU(TEN_CONG_TY NVARCHAR(255),DIA_CHI NVARCHAR(255),TEN_NDD NVARCHAR(50),FAX NVARCHAR(30),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(250),QUY_CACH NVARCHAR(255), " &
        '   " NGAY DATETIME, DON_GIA FLOAT, SO_LUONG FLOAT,sTEL nvarchar(15),NGOAI_TE NVARCHAR (6)) " &
        '   " INSERT INTO [DBO].rptCTY_DA_CUNG_CAP_VAT_TU " &
        str = " SELECT * FROM(SELECT DISTINCT TEN_CONG_TY,case when KHACH_HANG.DIA_CHI = 'NULL' then '' else isnull(khach_hang.DIA_CHI,'') end as DIA_CHI,case when KHACH_HANG.TEN_NDD = 'NULL' then '' else isnull(khach_hang.TEN_NDD,'') end as TEN_NDD, case when KHACH_HANG.TEL like '%e+%' or KHACH_HANG.TEL = '0' or KHACH_HANG.TEL = 'NULL' then '' else isnull(khach_hang.tel,'') end as TEL, case when KHACH_HANG.Email like '%e+%' or KHACH_HANG.Email = '0' or KHACH_HANG.Email = 'NULL' then '' else isnull(khach_hang.Email,'') end as Email, " &
           " (select TOP 1 MAX(NGAY)AS NGAY  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " &
           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " &
         "    AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT )AS NGAY, " &
            "( select TOP 1 DON_GIA FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " &
           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " &
           "  AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND NGAY=(select TOP 1 MAX(NGAY)AS NGAY " &
           "  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH  " &
           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " &
         "    AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ))AS DON_GIA, " &
           " ( SELECT SUM(SL_THUC_NHAP) FROM  IC_DON_HANG_NHAP D , IC_DON_HANG_NHAP_VAT_TU DVT WHERE " &
         "    D.MS_DH_NHAP_PT=DVT.MS_DH_NHAP_PT AND D.NGUOI_NHAP= dbo.IC_DON_HANG_NHAP.NGUOI_NHAP AND " &
          " DVT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT  )AS SO_LUONG ,(SELECT TOP 1 NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1) AS NGOAI_TE " &
           " FROM         dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
            "  dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT " &
           "    INNER JOIN KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP=KHACH_HANG.MS_KH INNER JOIN IC_PHU_TUNG " &
      " ON IC_DON_HANG_NHAP_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT " &
            " WHERE  IC_PHU_TUNG.MS_PT='" & cboVattu.SelectedValue & "') TMP WHERE SO_LUONG>0"
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If dtTable.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTable, False, True, True, True, True, Me.Name.ToString)
        grvChung.Columns("DON_GIA").VisibleIndex = 7
        grvChung.Columns("SO_LUONG").VisibleIndex = 8


        InDuLieu()

        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        'Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCTY_DA_CUNG_CAP_VAT_TU")
        'While objReader.Read
        '    If objReader.Item("TONG") = 0 Then
        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '        objReader.Close()
        '        GoTo KetThuc
        '    End If
        'End While
        'objReader.Close()

        'CreaterptTIEU_DE_CONG_TY_VAT_TU()
        ''ReportPreview("reports/rptCTY_DA_CUNG_CAP_VAT_TU.rpt")

        ''frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY
        'Dim frmRepot As frmXMLReport = New frmXMLReport()
        'frmRepot.rptName = "rptCTY_DA_CUNG_CAP_VAT_TU"

        'Dim vtbTitle As New DataTable()
        'vtbTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTIEU_DE_CONG_TY_VAT_TU"))
        'vtbTitle.TableName = "rptTIEU_DE_CONG_TY_VAT_TU"
        'frmRepot.AddDataTableSource(vtbTitle)


        'Dim vtbData As New DataTable()
        'vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptCTY_DA_CUNG_CAP_VAT_TU"))
        'vtbData.TableName = "rptCTY_DA_CUNG_CAP_VAT_TU"
        'frmRepot.AddDataTableSource(vtbData)
        'frmRepot.ShowDialog()








    End Sub





    Sub InDuLieu()

        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls") ' "C:\Users\Administrator\Desktop\frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY.xls"
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


            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong)


            Dong += 1

            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
                    True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)


            Dong += 1
            Dim stmp As String = ""

            stmp = lblDSVT.Text + " : " + cboVattu.Text
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, True, Dong, 6)




            Dim title As Excel.Range

            Dong += 3


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
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 9, 1, 9, 1)
            title.RowHeight = 12.75
            'set width for all columns'
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", True, Dong + 1, 1, TDong + Dong, 1)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", True, Dong + 1, 2,
             TDong + Dong, 2)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", True, Dong + 1, 3,
             TDong + Dong, 3)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", True, Dong + 1, 4,
             TDong + Dong, 4)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 5, TDong + Dong, 5)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "dd/mm/yyyy", True, Dong + 1, 6,
             TDong + Dong, 6)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "#,##0", True, Dong + 1, 7,
             TDong + Dong, 7)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "#,##0", True, Dong + 1, 8,
             TDong + Dong, 8)
            Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "@", True, Dong + 1, 9,
             TDong + Dong, 9)

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
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        Me.Cursor = Cursors.[Default]

    End Sub



    '    Sub ShowrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY()
    '        If cboVattu.SelectedValue Is Nothing Then
    '            Exit Sub
    '        End If
    '        Dim str As String = ""
    '        Try
    '            str = "DROP TABLE rptCTY_DA_CUNG_CAP_VAT_TU"
    '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    '        Catch ex As Exception

    '        End Try
    '        str = "CREATE TABLE [DBO].rptCTY_DA_CUNG_CAP_VAT_TU(TEN_CONG_TY NVARCHAR(255),DIA_CHI NVARCHAR(255),TEN_NDD NVARCHAR(50),FAX NVARCHAR(30),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(250),QUY_CACH NVARCHAR(255), " & _
    '           " NGAY DATETIME, DON_GIA FLOAT, SO_LUONG FLOAT,sTEL nvarchar(15),NGOAI_TE NVARCHAR (6)) " & _
    '           " INSERT INTO [DBO].rptCTY_DA_CUNG_CAP_VAT_TU " & _
    '           " SELECT * FROM(SELECT DISTINCT TEN_CONG_TY,DIA_CHI,TEN_NDD,FAX,dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT,TEN_PT,QUY_CACH," & _
    '           " (select TOP 1 MAX(NGAY)AS NGAY  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
    '           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
    '         "    AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT )AS NGAY, " & _
    '            "( select TOP 1 DON_GIA FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH " & _
    '           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
    '           "  AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND NGAY=(select TOP 1 MAX(NGAY)AS NGAY " & _
    '           "  FROM IC_DON_HANG_NHAP_VAT_TU VT, IC_DON_HANG_NHAP DH  " & _
    '           " WHERE(VT.MS_DH_NHAP_PT = DH.MS_DH_NHAP_PT And DH.NGUOI_NHAP = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) " & _
    '         "    AND VT.MS_PT=dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT ))AS DON_GIA, " & _
    '           " ( SELECT SUM(SL_THUC_NHAP) FROM  IC_DON_HANG_NHAP D , IC_DON_HANG_NHAP_VAT_TU DVT WHERE " & _
    '         "    D.MS_DH_NHAP_PT=DVT.MS_DH_NHAP_PT AND D.NGUOI_NHAP= dbo.IC_DON_HANG_NHAP.NGUOI_NHAP AND " & _
    '          " DVT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT  )AS SO_LUONG ,KHACH_HANG.TEL,IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE " & _
    '           " FROM         dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " & _
    '            "  dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT " & _
    '           "    INNER JOIN KHACH_HANG ON IC_DON_HANG_NHAP.NGUOI_NHAP=KHACH_HANG.MS_KH INNER JOIN IC_PHU_TUNG " & _
    '      " ON IC_DON_HANG_NHAP_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT " & _
    '            " WHERE  IC_PHU_TUNG.MS_PT='" & cboVattu.SelectedValue & "') TMP WHERE SO_LUONG>0"
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

    '        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptCTY_DA_CUNG_CAP_VAT_TU")
    '        While objReader.Read
    '            If objReader.Item("TONG") = 0 Then
    '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    '                objReader.Close()
    '                GoTo KetThuc
    '            End If
    '        End While
    '        objReader.Close()

    '        CreaterptTIEU_DE_CONG_TY_VAT_TU()
    '        'ReportPreview("reports/rptCTY_DA_CUNG_CAP_VAT_TU.rpt")

    '        'frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY
    '        Dim frmRepot As frmXMLReport = New frmXMLReport()
    '        frmRepot.rptName = "rptCTY_DA_CUNG_CAP_VAT_TU"

    '        Dim vtbTitle As New DataTable()
    '        vtbTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTIEU_DE_CONG_TY_VAT_TU"))
    '        vtbTitle.TableName = "rptTIEU_DE_CONG_TY_VAT_TU"
    '        frmRepot.AddDataTableSource(vtbTitle)


    '        Dim vtbData As New DataTable()
    '        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptCTY_DA_CUNG_CAP_VAT_TU"))
    '        vtbData.TableName = "rptCTY_DA_CUNG_CAP_VAT_TU"
    '        frmRepot.AddDataTableSource(vtbData)
    '        frmRepot.ShowDialog()







    'KetThuc:
    '        Try
    '            str = "DROP TABLE rptCTY_DA_CUNG_CAP_VAT_TU"
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
        sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCTY_DA_CUNG_CAP_VAT_TU", "TieuDe3", Commons.Modules.TypeLanguage)

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
