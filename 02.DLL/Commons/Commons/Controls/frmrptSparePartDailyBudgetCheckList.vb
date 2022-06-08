
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptSparePartDailyBudgetCheckList
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Public tieuDe As String

    Private loaivt As String
    Private kho As String
    Private ngay As String
    Private count As Integer

    Private Sub frmrptSparePartDailyBudgetCheckList_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table dbo.LIST_BPCP_TMP" + Commons.Modules.UserName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmrptSparePartDailyBudgetCheckList_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged

    End Sub
    Private Sub frmrptSparePartDailyBudgetCheckList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        loadLoaiVTPT()
        LoadDSBPCP()
        loadKho()
        CreatTableTMP()
    End Sub

    Sub loadLoaiVTPT()
        cboLoaiVTPT.Value = "MS_LOAI_VT"
        cboLoaiVTPT.Display = "TEN_LOAI_VT_TV"
        cboLoaiVTPT.StoreName = "H_MSDR_LOAI_VTPT"
        cboLoaiVTPT.BindDataSource()
    End Sub

    Sub CreatTableTMP()
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table dbo.LIST_BPCP_TMP" + Commons.Modules.UserName)
        Catch ex As Exception
        End Try

        Dim str As String = ""
        str = "CREATE TABLE dbo.LIST_BPCP_TMP" + Commons.Modules.UserName + "( MS_BP_CHIU_PHI INT, CHON BIT )"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

    End Sub


    Sub LoadDSBPCP()
        Dim vtb As New System.Data.DataTable
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_MSDR_BPCP"))
        vtb.Columns("CHON").ReadOnly = False
        grdListBPCP.AutoGenerateColumns = False
        grdListBPCP.DataSource = vtb
        grdListBPCP.Columns("MS_BP_CHIU_PHI").DataPropertyName = "MS_BP_CHIU_PHI"
        grdListBPCP.Columns("TEN_BP_CHIU_PHI").DataPropertyName = "TEN_BP_CHIU_PHI"
        grdListBPCP.Columns("CHON").DataPropertyName = "CHON"
    End Sub


    Sub loadKho()
        cboKho.Value = "MS_KHO"
        cboKho.Display = "TEN_KHO"
        cboKho.StoreName = "H_GET_DATA_MATERIAL_SEWING_KHO"
        cboKho.BindDataSource()
    End Sub


    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        If CheckSelectBPCP() = False Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "CHUA_CHON_BPCP", Commons.Modules.TypeLanguage))
            Exit Sub
        End If


        'Load data
        Dim vData As New System.Data.DataTable
        vData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DATA_SPARE_PART_DAILY_RP", vTuNgay, vDenNgay, Commons.Modules.UserName, cboKho.SelectedValue, cboLoaiVTPT.SelectedValue))
        count = vData.Rows.Count
        If count = 0 Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "KO_CO_DL_DE_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        tieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "TIEU_DE_REPORT", Commons.Modules.TypeLanguage)
        loaivt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "LOAI_VAT_TU", Commons.Modules.TypeLanguage) & " : " & cboLoaiVTPT.Text
        kho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "KHO", Commons.Modules.TypeLanguage) & " : " & cboKho.Text
        ngay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "tungay", Commons.Modules.TypeLanguage) & " : " & vTuNgay & " " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "dengay", Commons.Modules.TypeLanguage) & " : " & vDenNgay

        Dim obj As frmReportViews_CheckList = New frmReportViews_CheckList()
        obj.vtbData = vData
        obj.tieuDe = tieuDe
        obj.loaivt = loaivt
        obj.kho = kho
        obj.ngay = ngay
        obj.count = count

        obj.grdView.DataSource = vData

        obj.ShowDialog()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.Cursor = Cursors.Default
    End Sub

    Function CheckSelectBPCP() As Boolean
        For i As Integer = 0 To grdListBPCP.Rows.Count - 1
            If (grdListBPCP.Rows(i).Cells("CHON").Value = True) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating
        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Try
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptSparePartDailyBudgetCheckList", "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try

    End Sub

    Private Sub btnChonALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonALL.Click

        Dim STR As String = ""
        STR = "DELETE dbo.LIST_BPCP_TMP" + Commons.Modules.UserName
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)

        For i As Integer = 0 To grdListBPCP.Rows.Count - 1
            grdListBPCP.Rows(i).Cells("CHON").Value = True
            STR = "INSERT INTO dbo.LIST_BPCP_TMP" + Commons.Modules.UserName + "(MS_BP_CHIU_PHI,CHON) VALUES(N'" + grdListBPCP.Rows(i).Cells("MS_BP_CHIU_PHI").Value.ToString + "',1)"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
        Next

    End Sub

    Private Sub btnBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChon.Click

        Dim STR As String = ""
        STR = "DELETE dbo.LIST_BPCP_TMP" + Commons.Modules.UserName
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)

        For i As Integer = 0 To grdListBPCP.Rows.Count - 1
            grdListBPCP.Rows(i).Cells("CHON").Value = False
        Next

    End Sub

    Private Sub grdListBPCP_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdListBPCP.CellValidating
        If grdListBPCP.Columns(e.ColumnIndex).Name = "CHON" Then
            Dim cell As DataGridViewCell = grdListBPCP.Item(e.ColumnIndex, e.RowIndex)
            If cell.IsInEditMode Then
                If e.FormattedValue Then
                    Dim OBJ As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Select count(MS_BP_CHIU_PHI) from dbo.LIST_BPCP_TMP" + Commons.Modules.UserName & " WHERE MS_BP_CHIU_PHI = '" & grdListBPCP.Rows(e.RowIndex).Cells("MS_BP_CHIU_PHI").Value & "'")
                    If CType(OBJ, Integer) = 0 Then
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO dbo.LIST_BPCP_TMP" + Commons.Modules.UserName + "(MS_BP_CHIU_PHI,CHON) VALUES(N'" + grdListBPCP.Rows(e.RowIndex).Cells("MS_BP_CHIU_PHI").Value.ToString + "',1)")
                    End If
                Else
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM  dbo.LIST_BPCP_TMP" + Commons.Modules.UserName & " WHERE MS_BP_CHIU_PHI='" & grdListBPCP.Rows(e.RowIndex).Cells("MS_BP_CHIU_PHI").Value & "'")
                End If
            End If
        End If

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
