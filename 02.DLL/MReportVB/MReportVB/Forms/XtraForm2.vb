Public Class XtraForm2 

    Private Sub XtraForm2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dsduyet As New DataTable
        sql = " exec sp_DuyetSanXuat '" & Commons.Modules.UserName & "',1"
        dsduyet = New DataTable

    End Sub
End Class