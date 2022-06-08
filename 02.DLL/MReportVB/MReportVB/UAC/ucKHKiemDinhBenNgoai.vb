Public Class ucKHKiemDinhBenNgoai
    Private sql As String = ""
    Private DSThietBi As New DataTable

    Private Sub ucKHKiemDinhBenNgoai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cmbNam.DateTime = Today
            sql = "SELECT    DISTINCT dbo.LOAI_MAY.MS_LOAI_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY " & _
                    " FROM         dbo.CHU_KY_HIEU_CHUAN INNER JOIN " & _
                    " dbo.MAY ON dbo.CHU_KY_HIEU_CHUAN.MS_MAY = dbo.MAY.MS_MAY INNER JOIN" & _
                    " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN" & _
                    " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY" & _
                    " union select '-1','<ALL>'" & _
                    " ORDER BY TEN_LOAI_MAY  "
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbLoaiMay, sql, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLoaiMay.Text)
            sql = "SELECT DISTINCT    dbo.LOAI_VT.MS_LOAI_VT,case when " & Commons.Modules.TypeLanguage & "=0 then dbo.LOAI_VT.TEN_LOAI_VT_TV else case when " & Commons.Modules.TypeLanguage & " =1 then TEN_LOAI_VT_TA else TEN_LOAI_VT_TH end end as TEN_LOAI_VT " & _
                    " FROM         dbo.IC_PHU_TUNG INNER JOIN" & _
                    " dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT" & _
                    " WHERE(dbo.IC_PHU_TUNG.DUNG_CU_DO = 1) " & _
                    " UNION SELECT '-1','<ALL>'" & _
                    " ORDER BY TEN_LOAI_VT_TV"
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbLoaiVT, sql, "MS_LOAI_VT", "TEN_LOAI_VT", lblLoaiVT.Text)

            sql = "SELECT DISTINCT convert(bit, 1) as CHON,dbo.MAY.MS_MAY, dbo.MAY.TEN_MAY " & _
                    " FROM dbo.CHU_KY_HIEU_CHUAN INNER JOIN dbo.MAY ON dbo.CHU_KY_HIEU_CHUAN.MS_MAY = dbo.MAY.MS_MAY INNER JOIN" & _
                    " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN" & _
                    " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY "
            DSThietBi = New DataTable
            DSThietBi.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            DSThietBi.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(gridThietBi, GridViewTB, DSThietBi, True, True, True, True)
            GridViewTB.Columns("MS_MAY").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("MS_MAY").OptionsColumn.AllowFocus = False
            GridViewTB.Columns("TEN_MAY").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("TEN_MAY").OptionsColumn.AllowFocus = False

            Commons.Modules.ObjSystems.ThayDoiNN(Me.ParentForm)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click
        Dim Nam As Integer
        Dim TableTam As String = "KHKDBN" & Commons.Modules.UserName
        Dim LoaiVT As String
        Dim DSMay As New DataTable
        Dim sPath As String = ""
        Try
            Nam = cmbNam.Text
            LoaiVT = cmbLoaiVT.EditValue.ToString

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, TableTam, DSThietBi, "")
            sql = "exec sp_KeHoachKiemDinhHieuChuanBenNgoai " & Nam & ",'" & LoaiVT & "','" & TableTam & "'"
            DSMay.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            Commons.Modules.ObjSystems.XoaTable(TableTam)
            If DSMay.Rows.Count <= 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKiemDinhBenNgoai", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls")
            If sPath = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKiemDinhBenNgoai", "PhaiChonFile", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Commons.Modules.ObjSystems.MLoadXtraGrid(GridExport, GridView1, DSMay, True, True, True, True, True, "ucKHKiemDinhBenNgoai")

            GridExport.DataSource = DSMay
            GridView1.Columns("TEN_MAY").Group()
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
            TCot = DSMay.Columns.Count
            excelApplication.Cells.Font.Name = "Times New Roman"
            excelApplication.Cells.Font.Size = 12
            With excelWorkSheet
                .Range(.Cells(1, 2), .Cells(1, 2)).ColumnWidth = 12.43
                .Range(.Cells(1, 3), .Cells(1, 3)).ColumnWidth = 15.14
                .Range(.Cells(1, 4), .Cells(1, 4)).ColumnWidth = 48
                .Range(.Cells(1, 5), .Cells(1, 5)).ColumnWidth = 20
                .Range(.Cells(1, 6), .Cells(1, 6)).ColumnWidth = 22.71
                .Range(.Cells(1, 7), .Cells(1, 7)).ColumnWidth = 16.71
                .Range(.Cells(1, 8), .Cells(1, 8)).ColumnWidth = 26.43
                .Range(.Cells(1, 9), .Cells(1, 9)).ColumnWidth = 15.29
                .Range(.Cells(1, 10), .Cells(1, 10)).ColumnWidth = 27.14
                .Range(.Cells(1, 11), .Cells(1, 11)).ColumnWidth = 12.86
                .Range(.Cells(1, 12), .Cells(1, 12)).ColumnWidth = 12.86
                .Range(.Cells(1, 13), .Cells(1, 13)).ColumnWidth = 11.57
                .Range(.Cells(1, 14), .Cells(1, 14)).ColumnWidth = 10.14
                .Range(.Cells(1, 15), .Cells(1, 15)).ColumnWidth = 20
                .Range(.Cells(9, 1), .Cells(9 + DSMay.Rows.Count, TCot)).WrapText = True

                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 4, 1, 5)
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath)
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong)
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucKHKiemDinhBenNgoai", "TieuDe", Commons.Modules.TypeLanguage)
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, sTmp, Dong, 1, "@", 16, True, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, True, Dong, TCot)
                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, False, True, True, True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)
            End With
            Cursor = Cursors.Default
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
        
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        ParentForm.Close()
    End Sub

    Private Sub cmdTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTatCa.Click
        Try
            Dim dv As DataView
            Dim i As Integer
            Dim j As Integer

            dv = DSThietBi.DefaultView
            For i = 0 To dv.Count - 1
                j = DSThietBi.Rows.IndexOf(dv(i).Row)
                If j >= 0 Then
                    DSThietBi.Rows(j).Item("CHON") = 1
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbLoaiMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoaiMay.EditValueChanged
        Try
            sql = "SELECT  DISTINCT convert(bit, 1) as CHON,dbo.MAY.MS_MAY, dbo.MAY.TEN_MAY " & _
               " FROM dbo.CHU_KY_HIEU_CHUAN INNER JOIN dbo.MAY ON dbo.CHU_KY_HIEU_CHUAN.MS_MAY = dbo.MAY.MS_MAY INNER JOIN" & _
               " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN" & _
               " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY " & _
               " where 1=1 "
            If cmbLoaiMay.EditValue.ToString <> "-1" Then
                sql = sql & " AND NHOM_MAY.MS_LOAI_MAY='" & cmbLoaiMay.EditValue.ToString & "'"
            End If
            DSThietBi = New DataTable
            DSThietBi.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            DSThietBi.Columns("CHON").ReadOnly = False
            Commons.Modules.ObjSystems.MLoadXtraGrid(gridThietBi, GridViewTB, DSThietBi, True, True, True, True, True, "ucKHKiemDinhBenNgoai")
            GridViewTB.Columns("MS_MAY").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("MS_MAY").OptionsColumn.AllowFocus = False
            GridViewTB.Columns("TEN_MAY").OptionsColumn.AllowEdit = False
            GridViewTB.Columns("TEN_MAY").OptionsColumn.AllowFocus = False

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBoChon.Click
        Try
            Dim dv As DataView
            Dim i As Integer
            Dim j As Integer

            dv = DSThietBi.DefaultView
            For i = 0 To dv.Count - 1
                j = DSThietBi.Rows.IndexOf(dv(i).Row)
                If j >= 0 Then
                    DSThietBi.Rows(j).Item("CHON") = 0
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMSMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMSMay.EditValueChanged
        Try
            If GridViewTB.ActiveFilterString <> "" Then
                DSThietBi.DefaultView.RowFilter = GridViewTB.ActiveFilterString & " and MS_MAY LIKE '" & txtMSMay.Text & "%'"
            Else
                DSThietBi.DefaultView.RowFilter = " MS_MAY LIKE '" & txtMSMay.Text & "%'"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridExport.Click

    End Sub
End Class
