Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Threading

Public Class frmrptVAT_TU_XUAT_KHO
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            Dim i As Integer
            Dim dtTableOne = New DataTable
            Dim dtTIEU_DE As New DataTable
            Dim dangxuat, tendx As String
            tendx = ""
            dangxuat = ""
            While i < grvDangxuat.RowCount
                If grvDangxuat.GetDataRow(i)("CHON").ToString() = "True" Then
                    dangxuat = dangxuat & grvDangxuat.GetDataRow(i)("MS_DANG_XUAT").ToString & ","
                    tendx = tendx & grvDangxuat.GetDataRow(i)("DANG_XUAT").ToString & ", "
                End If
                i = i + 1
            End While
            If (String.IsNullOrEmpty(tendx)) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "ChonDangXuat", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Return
            End If
            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("fr-FR")


            Dim sPath As String = ""
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
            If sPath = "" Then
                Return
            End If
            Dim msKho As String = cboKho.EditValue.ToString()
            Dim path As String = ""

            If Not InBaoCao(sPath, msKho, dangxuat.Remove(dangxuat.Length - 1, 1), tendx, datTNgay.DateTime.Date, datDNgay.DateTime.Date) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.[Default]
    End Sub

    Public Function GoiMailTuDong(ByVal sPath As String, ByVal msKho As String, ByVal dangxuat As String, ByVal tendx As String, ByVal sTungay As DateTime, ByVal sDenngay As DateTime) As Boolean
        Return InBaoCao(sPath, msKho, dangxuat, tendx, sTungay, sDenngay, True)
    End Function

    Private Function InBaoCao(ByVal sPath As String, ByVal msKho As String, ByVal dangxuat As String, ByVal tendx As String, ByVal sTungay As DateTime, ByVal sDenngay As DateTime, Optional goiMailTuDong As Boolean = False) As Boolean

        Dim vtbData As New DataTable()

        Try
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetrptVTPT_XUATKHO", sTungay, sDenngay, msKho, dangxuat, Commons.Modules.TypeLanguage, Commons.Modules.UserName, IIf(String.IsNullOrEmpty(cboBPCP.EditValue.ToString), -1, cboBPCP.EditValue)))

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return False
        End Try

        Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, vtbData, False, True, True, True, True, "frmrptVAT_TU_XUAT_KHO")
        If vtbData.Rows.Count = 0 Then
            Return False
        End If
        Dim excelApplication As New Excel.Application()
        Try
            Dim TCot As Integer = grvChung.Columns.Count
            Dim TDong As Integer = grvChung.RowCount
            Dim Dong As Integer = 1
            prbIN.Visible = True
            prbIN.Position = 0
            prbIN.Properties.[Step] = 1
            prbIN.Properties.PercentView = True
            prbIN.Properties.Maximum = 11
            prbIN.Properties.Minimum = 0

            grdChung.ExportToXls(sPath)
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
            Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
            Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)

            prbIN.PerformStep()
            prbIN.Update()

            Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot)
            Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 100, 45, Application.StartupPath)
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong)

            Dim SCot As Integer

            SCot = 7

            '(TCot > 16 ? 14 : (TCot <= 6 ? TCot : TCot - 2));

            prbIN.PerformStep()
            prbIN.Update()
            Dong += 1
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "TEN_REPORT", Commons.Modules.TypeLanguage), Dong, 1, "@", 16,
True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)

            prbIN.PerformStep()
            prbIN.Update()

            Dong += 2
            Dim stmp As String = ""
            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "TU_NGAY", Commons.Modules.TypeLanguage) + " " + sTungay
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10,
True, True, Dong, SCot - 4)

            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "DEN_NGAY", Commons.Modules.TypeLanguage) + " " + sDenngay
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10,
True, True, Dong, 6)

            Dong += 1
            stmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "DANG_XUAT", Commons.Modules.TypeLanguage) + ": " + tendx
            Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, True, False, Dong, TCot)

            Dim title As Excel.Range
            Commons.Modules.MExcel.ThemDong(excelWorkSheet, Excel.XlInsertShiftDirection.xlShiftDown, 1, 10)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 10, 1, 10, TCot)
            title.RowHeight = 9

            Dong += 2

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot)
            title.Borders.LineStyle = 1
            title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color
            title.WrapText = True

            prbIN.PerformStep()
            prbIN.Update()

            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot)
            title.Font.Bold = True
            title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

            prbIN.PerformStep()
            prbIN.Update()


            Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True,
False, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100)
            title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1)
            title.RowHeight = 15


            prbIN.PerformStep()
            prbIN.Update()

            Try
                'set width for all columns'
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 4, "@", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14.43, "@", True, Dong + 1, 2, TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13.7, "@", True, Dong + 1, 3, TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9.14, "dd/MM/yyyy", True, Dong + 1, 4, TDong + Dong, 4)

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", True, Dong + 1, 6, TDong + Dong, 7)

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", True, Dong + 1, 8, TDong + Dong, 8)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 9, TDong + Dong, 9)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", True, Dong + 1, 10, TDong + Dong, 10)


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL), True, Dong + 1, 11, TDong + Dong, 11)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), True, Dong + 1, 15, TDong + Dong, 16)


                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 0, "@", True, Dong + 1, 12, TDong + Dong, 12)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", True, Dong + 1, 13, TDong + Dong, 13)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 14, TDong + Dong, 14)
                'Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT), True, Dong + 1, 16, TDong + Dong, 16)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 30, "@", True, Dong + 1, 17, TDong + Dong, 17)
            Catch ex As Exception

            End Try

            prbIN.PerformStep()
            prbIN.Update()
            Try

                If (goiMailTuDong = False) Then
                    excelApplication.Visible = True
                Else
                    excelApplication.Visible = False
                End If
                excelWorkbook.Save()
                prbIN.Position = 0
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            Catch ex As Exception

            End Try

        Catch ex As Exception
            excelApplication.Visible = True
            excelApplication.DisplayAlerts = False
            prbIN.Position = 0
            excelApplication.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(excelApplication)
            If (goiMailTuDong) Then Return False
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDSBaoTri", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return False
        End Try
        Return True
    End Function

    Private Function CreateTieuDe(ByVal dangxuat As String) As DataTable
        Dim dtTieuDe As New DataTable
        Dim dtR As DataRow

        dtTieuDe.Columns.Clear()
        dtTieuDe.Columns.Add("TEN_REPORT")
        dtTieuDe.Columns.Add("sTU_NGAY")
        dtTieuDe.Columns.Add("sDEN_NGAY")
        dtTieuDe.Columns.Add("TU_NGAY")
        dtTieuDe.Columns.Add("DEN_NGAY")
        dtTieuDe.Columns.Add("sDANG_XUAT")
        dtTieuDe.Columns.Add("DANG_XUAT")
        dtTieuDe.Columns.Add("sNGUOI_LAP")

        dtTieuDe.Columns.Add("sKHO")
        dtTieuDe.Columns.Add("sNGAY")
        dtTieuDe.Columns.Add("sSO_PHIEU_XUAT")
        dtTieuDe.Columns.Add("sSO_CHUNG_TU")
        dtTieuDe.Columns.Add("sLY_DO_XUAT")
        dtTieuDe.Columns.Add("sMUC_DICH")
        dtTieuDe.Columns.Add("sMASO_VTPT")
        dtTieuDe.Columns.Add("sTEN_VTPT")
        dtTieuDe.Columns.Add("sPHIEU_NHAP")
        dtTieuDe.Columns.Add("sSO_LUONG")
        dtTieuDe.Columns.Add("sDONG_GIA")
        dtTieuDe.Columns.Add("sTHANH_TIEN")
        dtTieuDe.Columns.Add("sTONG_KHO")
        dtTieuDe.Columns.Add("sTONG_TIEN")
        dtTieuDe.Columns.Add("sMSTHIETBI")

        dtR = dtTieuDe.NewRow
        dtR.Item("TEN_REPORT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "TEN_REPORT", Commons.Modules.TypeLanguage)
        dtR.Item("sTU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "TU_NGAY", Commons.Modules.TypeLanguage)
        dtR.Item("TU_NGAY") = datTNgay.DateTime.Date.ToString
        dtR.Item("DEN_NGAY") = datDNgay.DateTime.Date.ToString
        dtR.Item("sDEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "DEN_NGAY", Commons.Modules.TypeLanguage)
        dtR.Item("sDANG_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "DANG_XUAT", Commons.Modules.TypeLanguage)
        dtR.Item("DANG_XUAT") = dangxuat
        dtR.Item("sNGUOI_LAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "NGUOI_LAP", Commons.Modules.TypeLanguage)

        dtR.Item("sKHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sKHO", Commons.Modules.TypeLanguage)
        dtR.Item("sNGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sNGAY", Commons.Modules.TypeLanguage)
        dtR.Item("sSO_PHIEU_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sSO_PHIEU_XUAT", Commons.Modules.TypeLanguage)
        dtR.Item("sSO_CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sSO_CHUNG_TU", Commons.Modules.TypeLanguage)
        dtR.Item("sLY_DO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sLY_DO_XUAT", Commons.Modules.TypeLanguage)
        dtR.Item("sMUC_DICH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sMUC_DICH", Commons.Modules.TypeLanguage)
        dtR.Item("sMASO_VTPT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sMASO_VTPT", Commons.Modules.TypeLanguage)
        dtR.Item("sTEN_VTPT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTEN_VTPT", Commons.Modules.TypeLanguage)
        dtR.Item("sPHIEU_NHAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sPHIEU_NHAP", Commons.Modules.TypeLanguage)
        dtR.Item("sSO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sSO_LUONG", Commons.Modules.TypeLanguage)
        dtR.Item("sDONG_GIA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sDONG_GIA", Commons.Modules.TypeLanguage)
        dtR.Item("sTHANH_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTHANH_TIEN", Commons.Modules.TypeLanguage)
        dtR.Item("sTONG_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTONG_KHO", Commons.Modules.TypeLanguage)
        dtR.Item("sTONG_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTONG_TIEN", Commons.Modules.TypeLanguage)
        dtR.Item("sMSTHIETBI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sMSTHIET_BI", Commons.Modules.TypeLanguage)


        dtTieuDe.Rows.Add(dtR)

        Return dtTieuDe
    End Function


    'set ngon ngu tren form chon
    Private Sub refeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "rptVAT_TU_XUAT_KHO", Commons.Modules.TypeLanguage)
        Me.lbatuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", lbatuNgay.Name, Commons.Modules.TypeLanguage)
        Me.lbadenNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", lbadenNgay.Name, Commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", btnThucHien.Name, Commons.Modules.TypeLanguage)
        Me.lbaKho.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", lbaKho.Name, Commons.Modules.TypeLanguage)

    End Sub

    'Load cbo kho
    Private Sub LoadKho()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, Commons.Modules.ObjSystems.MLoadDataKho(1), "MS_KHO", "TEN_KHO", "")
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboBPCP, Commons.Modules.ObjSystems.MLoadDataBoPhanChiuPhi(1), "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "")
    End Sub

    Private Sub frmrptChonVTPTXuatkho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadKho()
        LoadDangxuat()
        datTNgay.DateTime = CDate("01/" & Month(Now) & "/" & Year(Now))
        datDNgay.DateTime = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1)
        If (Modules.sPrivate = "ADC") Then
            btnExport.Visible = True
        End If
    End Sub

    Private Sub LoadDangxuat()
        Dim dtTable As New DataTable()
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANG_XUATswithType", Commons.Modules.TypeLanguage))
        Dim newColumn As New System.Data.DataColumn("CHON", GetType(System.Boolean))
        newColumn.DefaultValue = "1"
        dtTable.Columns.Add(newColumn)
        newColumn.SetOrdinal(0)
        dtTable.Columns("CHON").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdDangxuat, grvDangxuat, dtTable, True, True, True, True, True, Me.Name.ToString)


        grvDangxuat.Columns("CHON").OptionsColumn.ReadOnly = False
        grvDangxuat.Columns("DANG_XUAT").OptionsColumn.ReadOnly = True
        grvDangxuat.Columns("MS_DANG_XUAT").Visible = False

        grvDangxuat.Columns("CHON").Width = 150

        'grvDangxuat.Columns("DANG_XUAT").Width = 300

        'Try
        '    Me.grvDangxuat.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        '    Me.grvDangxuat.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim vtbData As New DataTable()
            Dim sTungay, sDenngay As DateTime
            sTungay = DateTime.Parse(datTNgay.Text, New CultureInfo("vi-vn"))
            sDenngay = DateTime.Parse(datDNgay.Text, New CultureInfo("vi-vn"))
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBaoCaoVatTuKhoExportExcel", cboKho.EditValue, sTungay.ToString("yyyy/MM/dd"), sDenngay.ToString("yyyy/MM/dd")))
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl1, GridView1, vtbData, False, True, True, True, False, Me.Name.ToString)
            If (vtbData.Rows.Count > 0) Then
                Dim sPath As String = ""
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
                If sPath = "" Then
                    Return
                End If
                Me.Cursor = Cursors.WaitCursor
                GridControl1.ExportToXls(sPath)
                Dim excelApplication As New Excel.Application()

                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
                Dim excelWorkbooks As Excel.Workbooks = excelApplication.Workbooks
                Dim excelWorkbook As Excel.Workbook = excelWorkbooks.Open(sPath, 0, False, 5, "", "",
             False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
                Dim excelWorkSheet As Excel.Worksheet = DirectCast(excelWorkbook.Sheets(1), Excel.Worksheet)
                excelApplication.Visible = False


                Dim Dong As Integer = 1
                Dim Cot As Integer = 1
                Dim TDong As Integer = vtbData.Rows.Count
                Dim TCot As Integer = vtbData.Columns.Count




                Dim title As Excel.Range

                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True,
             False, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlPortrait, 30, 30, 30, 30, 50, 50, 100)





                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot)
                title.RowHeight = 33
                title.Font.Bold = True

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot)
                title.Borders.LineStyle = 1
                title.Font.Size = 10
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
                title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 1, 1, Dong + 1, 1).Interior.Color
                title.WrapText = True



                'set width for all columns'
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.71, "dd/MM/yyyy", True, Dong + 1, 1, TDong + Dong, 1)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15.71, "@", True, Dong + 1, 2, TDong + Dong, 2)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", True, Dong + 1, 3, TDong + Dong, 3)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.29, "@", True, Dong + 1, 4, TDong + Dong, 4)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11.29, "@", True, Dong + 1, 5, TDong + Dong, 5)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.57, "@", True, Dong + 1, 6, TDong + Dong, 6)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8.57, "@", True, Dong + 1, 7, TDong + Dong, 7)
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", True, Dong + 1, 8, TDong + Dong, 8)


                excelWorkbook.Save()
                excelApplication.Visible = True
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet)
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook)

                Commons.Modules.ObjSystems.MReleaseObject(excelApplication)

                Me.Cursor = Cursors.Default
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
