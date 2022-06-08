Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptGiaphutungtheodonhang
    Private SqlText As String = String.Empty

    Private Sub frmrptDanhsach_CV_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Bind_cboPhutung()
        dtpDenngay.Value = DateTime.Now
        dtpTungay.Value = DateTime.Now.AddMonths(-1)
    End Sub

    Private Sub Bind_cboPhutung()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG1", Commons.Modules.UserName))
        For Each row As DataRow In dt.Rows
            row("TEN_PT") = row("MS_PT") + " - " + row("TEN_PT")
        Next
        'Dim dtRow As DataRow
        'dtRow = dt.NewRow
        'dtRow("MS_PT") = -1
        'dtRow("TEN_PT") = " < ALL > "
        'dt.Rows.InsertAt(dtRow, 0)
        cboPhuTung.DataSource = dt
        cboPhuTung.ValueMember = "MS_PT"
        cboPhuTung.DisplayMember = "TEN_PT"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If dtpTungay.Value > dtpDenngay.Value Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "Tungayphainhohondenngay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtpTungay.Focus()
            Exit Sub
        End If
        PrintCongViec()
    End Sub

    Sub PrintCongViec()
        Try
            Dim vtbData As New DataTable()
            vtbData = GetDataCongViec()
            vtbData.TableName = "rptDANH_SACH_GIA_PT"

            If vtbData.Rows.Count > 0 Then
                Cursor = Cursors.WaitCursor
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptGiaphutungtheodonhang"
                frmRepot.AddDataTableSource(RefeshLanguageReport())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default

    End Sub

    Function RefeshLanguageReport() As DataTable
        Dim dtTieuDe As New DataTable
        Dim dtR As DataRow

        dtTieuDe.Columns.Clear()
        dtTieuDe.Columns.Add("TEN_REPORT")
        dtTieuDe.Columns.Add("TU_NGAY")
        dtTieuDe.Columns.Add("DEN_NGAY")
        dtTieuDe.Columns.Add("MS_PHU_TUNG")
        dtTieuDe.Columns.Add("TEN_PHU_TUNG")

        dtTieuDe.Columns.Add("MS_DON_DAT_HANG")
        dtTieuDe.Columns.Add("SO_DDH")
        dtTieuDe.Columns.Add("KHACHHANG")
        dtTieuDe.Columns.Add("NGAY_LAP")
        dtTieuDe.Columns.Add("SL_DAT_HANG")
        dtTieuDe.Columns.Add("DON_GIA")
        dtTieuDe.Columns.Add("THANH_TIEN")
        dtTieuDe.Columns.Add("DGTB")


        dtR = dtTieuDe.NewRow
        dtR.Item("TEN_REPORT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "TEN_REPORT", Commons.Modules.TypeLanguage)
        dtR.Item("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "TUNGAY", Commons.Modules.TypeLanguage) & " " & dtpTungay.Text
        dtR.Item("DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "DENNGAY", Commons.Modules.TypeLanguage) & " " & dtpDenngay.Text
        dtR.Item("MS_PHU_TUNG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "MS_PHU_TUNG", Commons.Modules.TypeLanguage)
        dtR.Item("TEN_PHU_TUNG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "TEN_PHU_TUNG", Commons.Modules.TypeLanguage)

        dtR.Item("MS_DON_DAT_HANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "MS_DON_DAT_HANG", Commons.Modules.TypeLanguage)
        dtR.Item("SO_DDH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "SO_DDH", Commons.Modules.TypeLanguage)
        dtR.Item("KHACHHANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "KHACHHANG", Commons.Modules.TypeLanguage)
        dtR.Item("NGAY_LAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "NGAY_LAP", Commons.Modules.TypeLanguage)
        dtR.Item("SL_DAT_HANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "SL_DAT_HANG", Commons.Modules.TypeLanguage)
        dtR.Item("DON_GIA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "DON_GIA", Commons.Modules.TypeLanguage)
        dtR.Item("THANH_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "THANH_TIEN", Commons.Modules.TypeLanguage)
        dtR.Item("DGTB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGiaphutungtheodonhang", "DGTB", Commons.Modules.TypeLanguage)

        dtTieuDe.Rows.Add(dtR)

        Return dtTieuDe

    End Function

    Function GetDataCongViec() As DataTable
        Dim vtb As New DataTable()
        If cboPhuTung.SelectedIndex >= 0 Then
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_rptGiaphutungtheodonhang", dtpTungay.Value, dtpDenngay.Value, cboPhuTung.SelectedValue.ToString()))
        End If
        Return vtb
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
