Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class frmrptDanhsach_VTPT
    Private SqlText As String = String.Empty
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        PrintDanhMucPhuTung()


    End Sub

    Sub PrintDanhMucPhuTung()
        Cursor = Cursors.WaitCursor
        Try
            Dim vtbData As New DataTable()
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCDanhMucVTPT", optBCao.SelectedIndex, Modules.UserName, Modules.TypeLanguage, cboLMay.EditValue, cboLVT.EditValue, cboNSD.EditValue))

            Cursor = Cursors.WaitCursor
            If vtbData.Rows.Count > 0 Then
                If optBCao.SelectedIndex = 2 Then
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, vtbData.Clone(), False, True, True, True, True, "rptDanhsach_VTPT")
                    InDuLieu(vtbData)
                Else
                    Dim frmRepot As frmXMLReport = New frmXMLReport()
                    vtbData.TableName = "rptrptDANH_SACH_VTPT"
                    frmRepot.rptName = If(optBCao.SelectedIndex = 0, "rptDanhsach_VTPT_ALL", "rptDanhsach_VTPT")
                    frmRepot.AddDataTableSource(RefeshLanguageDMVTPT())
                    frmRepot.AddDataTableSource(vtbData)
                    frmRepot.ShowDialog()
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), "", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Function RefeshLanguageDMVTPT() As DataTable
        Dim tieude, stt, Loaithietbi, noisudung, masovtpt, itemcode, partno, tenvattu, quycach, donvitinh, trang As String
        tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tieude", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "stt", Commons.Modules.TypeLanguage)
        Loaithietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "Loaithietbi", Commons.Modules.TypeLanguage)
        noisudung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "noisudung", Commons.Modules.TypeLanguage)
        masovtpt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "masovtpt", Commons.Modules.TypeLanguage)
        itemcode = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "itemcode", Commons.Modules.TypeLanguage)
        partno = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "partno", Commons.Modules.TypeLanguage)
        tenvattu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tenvattu", Commons.Modules.TypeLanguage)
        quycach = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "quycach", Commons.Modules.TypeLanguage)
        donvitinh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "donvitinh", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "trang", Commons.Modules.TypeLanguage)

        Dim vtb As New DataTable("rptDANH_SACH_VTPT_TMP")
        vtb.Columns.Add("TIEUDE_", Type.GetType("System.String"))
        vtb.Columns.Add("STT_", Type.GetType("System.String"))
        vtb.Columns.Add("LOAI_TB_", Type.GetType("System.String"))
        vtb.Columns.Add("NOI_SD_", Type.GetType("System.String"))
        vtb.Columns.Add("MS_PT_", Type.GetType("System.String"))
        vtb.Columns.Add("ITEM_CODE_", Type.GetType("System.String"))
        vtb.Columns.Add("PART_NO_", Type.GetType("System.String"))
        vtb.Columns.Add("TEN_PT_", Type.GetType("System.String"))
        vtb.Columns.Add("QUY_CACH_", Type.GetType("System.String"))
        vtb.Columns.Add("DON_VI_TINH_", Type.GetType("System.String"))
        vtb.Columns.Add("TRANG_", Type.GetType("System.String"))
        vtb.Columns.Add("NGON_NGU_", Type.GetType("System.String"))

        Dim vrow As DataRow = vtb.NewRow()
        vrow("TIEUDE_") = tieude
        vrow("STT_") = stt
        vrow("LOAI_TB_") = Loaithietbi
        vrow("NOI_SD_") = noisudung
        vrow("MS_PT_") = masovtpt
        vrow("ITEM_CODE_") = itemcode
        vrow("PART_NO_") = partno
        vrow("TEN_PT_") = tenvattu
        vrow("QUY_CACH_") = quycach
        vrow("DON_VI_TINH_") = donvitinh
        vrow("TRANG_") = trang
        vrow("NGON_NGU_") = Commons.Modules.TypeLanguage.ToString()

        vtb.Rows.Add(vrow)
        Return vtb
    End Function

    Private Sub frmrptDanhsach_VTPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Bind_cboLoaiTB()
        Bind_cboNoisudung()
    End Sub

    Sub Bind_cboLoaiTB()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "")
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVT, Commons.Modules.ObjSystems.MLoadDataLoaiVatTu(1), "MS_LOAI_VT", "TEN_LOAI_VT", "")

    End Sub
    Sub Bind_cboNoisudung()

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_PT", Commons.Modules.UserName))
        Dim row As DataRow
        row = dt.NewRow()
        row(0) = -1
        row(1) = " < ALL > "
        row(2) = Commons.Modules.UserName
        dt.Rows.InsertAt(row, 0)

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNSD, dt, "MS_LOAI_PT", "TEN_LOAI_PT", "")

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub




    Private Sub InDuLieu(dtTmp As DataTable)

        Dim sPath As String = ""
        sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx") ' 
        If sPath = "" Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim xlApp As New Excel.Application()
        Try
            Dim TCot As Integer = dtTmp.Columns.Count
            Dim TDong As Integer = dtTmp.Rows.Count
            Dim Dong As Integer = 1

            Dim oldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            prbIN.Visible = True
            prbIN.Position = 0
            prbIN.Properties.Step = 1
            prbIN.Properties.PercentView = True
            prbIN.Properties.Maximum = 18
            prbIN.Properties.Minimum = 0

            grvChung.ExportToXlsx(sPath)

            Dim xlWBooks As Excel.Workbooks = xlApp.Workbooks

#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            Dim xlWBook As Excel.Workbook = xlWBooks.Open(sPath, 0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", True, False, 0, True)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            Dim xlWSheet As Excel.Worksheet = DirectCast(xlWBook.Sheets(1), Excel.Worksheet)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            If Commons.Modules.bDoiFontReport Then xlApp.Cells.Font.Name = Commons.Modules.sFontReport
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region

            Dim title As Excel.Range
            TDong = TDong + 2
            title = Commons.Modules.MExcel.GetRange(xlWSheet, Dong, 1, TDong, TCot)
            title.Borders.LineStyle = 1
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0))
            title.Interior.Color = Commons.Modules.MExcel.GetRange(xlWSheet, Dong + 1, 1, Dong + 1, 1).Interior.Color
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region

            Commons.Modules.MExcel.ColumnWidth(xlWSheet, 6, "##", True, 1, 1, TDong, 1)

#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            title = Commons.Modules.MExcel.GetRange(xlWSheet, 2, 1, TDong, dtTmp.Columns.Count)
            Commons.Modules.MExcel.MExportExcel(dtTmp, xlWSheet, title)

            DirectCast(xlWSheet.Rows(2, Type.Missing), Excel.Range).Delete(Excel.XlDeleteShiftDirection.xlShiftUp)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            DirectCast(xlWSheet.Columns(12, Type.Missing), Excel.Range).Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            DirectCast(xlWSheet.Columns(13, Type.Missing), Excel.Range).Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region

            xlWSheet.Columns.AutoFit()
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            xlWSheet.Rows.AutoFit()
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            xlApp.ActiveWindow.DisplayGridlines = True
            Dong = 1
            Commons.Modules.MExcel.ThemDong(xlWSheet, Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            Commons.Modules.MExcel.TaoLogo(xlWSheet, 0, 0, 65, 38, System.Windows.Forms.Application.StartupPath)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region

            Commons.Modules.MExcel.DinhDang(xlWSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhsach_VTPT", "tieude", Commons.Modules.TypeLanguage), 2, 3, "@", 15, True)
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region

            title = Commons.Modules.MExcel.GetRange(xlWSheet, 5, 1, 5, TCot)
            title.Font.Bold = True
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            title = Commons.Modules.MExcel.GetRange(xlWSheet, 4, 1, 4, 1)
            title.RowHeight = 9
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            title = Commons.Modules.MExcel.GetRange(xlWSheet, 6, 2, TDong + 10, TCot + 4)
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

            title = Commons.Modules.MExcel.GetRange(xlWSheet, 6, 17, TDong + 10, 20)
            title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            xlWBook.Save()
#Region "prbIN"
            prbIN.PerformStep()
            prbIN.Update()
#End Region
            xlApp.Visible = True
            Commons.Modules.ObjSystems.MReleaseObject(xlWSheet)
            Commons.Modules.ObjSystems.MReleaseObject(xlWBook)
            Commons.Modules.ObjSystems.MReleaseObject(xlApp)
        Catch ex As Exception
            xlApp.Visible = True
            xlApp.DisplayAlerts = False
            xlApp.Quit()
            Commons.Modules.ObjSystems.MReleaseObject(xlApp)
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptPHU_TUNG_DUOC_CUNG_CAP_BOI_CTY", "InKhongThanhCong", Commons.Modules.TypeLanguage) + vbLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        prbIN.Position = prbIN.Properties.Maximum
        Me.Cursor = Cursors.Default

    End Sub


End Class
