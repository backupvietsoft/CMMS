Imports Microsoft.ApplicationBlocks.Data
Public Class frmChonNX
    Public ms_n_xuong As String
    Private Sub frmChonNX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTitle.Name, Commons.Modules.TypeLanguage)
        btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnExcute", Commons.Modules.TypeLanguage)
        btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnCancel", Commons.Modules.TypeLanguage)
        Dim _table As New DataTable
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_NHA_XUONG_CHUA_CO_MAY", frmBranch.txtMS.Text))
        gdNX.DataSource = _table
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvNX.Columns
            col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
        Next

        If Commons.Modules.PermisString.Equals("Read only") Then
            btnExcute.Enabled = False
        End If
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        If gvNX.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONGCONHAXUONGNAO", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        ms_n_xuong = gvNX.GetFocusedDataRow()("MS_N_XUONG")
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class