Imports Microsoft.ApplicationBlocks.Data

Public Class frmKho
    Private Sub frmKho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadKho()
    End Sub
    Private Sub LoadKho()
        Dim dtTMP As New DataTable
        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_KHOs"))
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdKho, grvKho, dtTMP, True, True, False, False)
    End Sub
End Class