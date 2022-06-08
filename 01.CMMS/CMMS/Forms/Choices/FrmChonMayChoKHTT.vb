Imports Microsoft.ApplicationBlocks.Data
Public Class FrmChonMayChoKHTT
    Public loai_may As String
    Public nhom_may As String
    Public dtMay As New DataTable

    Private Sub FrmChonMayChoKHTT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtMay = New DataTable
        dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_MAY_KHTT", _
                Commons.Modules.UserName, Commons.Modules.TypeLanguage, loai_may, nhom_may))
        dtMay.Columns("CHON").ReadOnly = False
        For i As Integer = 1 To GridView1.Columns.Count - 1
            dtMay.Columns(i).ReadOnly = True
        Next

        Commons.Modules.ObjSystems.MLoadXtraGrid(GridControl1, GridView1, dtMay, True, True, 1, 1)
        GridView1.Columns("CHON").Width = 55
        GridView1.Columns("MS_MAY").Width = 100
        GridView1.Columns("TEN_MAY").Width = 150
        GridView1.Columns("MODEL").Width = 100
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        dtMay.DefaultView.RowFilter = "CHON=TRUE"
        dtMay = dtMay.DefaultView.ToTable()
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtTKiem_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtTKiem.EditValueChanging
        Dim dk As String = ""
        Try
            If txtTKiem.Text <> "" Then dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk
            If txtTKiem.Text <> "" Then dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk
            If dk.Length > 0 Then dk = dk.Substring(5, dk.Length - 5)
            dtMay.DefaultView.RowFilter = dk
        Catch ex As Exception
            dtMay.DefaultView.RowFilter = ""
        End Try
    End Sub
End Class