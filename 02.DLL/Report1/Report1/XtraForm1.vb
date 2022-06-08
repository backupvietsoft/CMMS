Public Class XtraForm1 
    Private sql As String
    Private data As New DataTable

    Private Sub XtraForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Commons.Modules.SQLString = "0LOAD"


        Dim myUc As New ctlDMTBDL
        myUc.Location = New Point(0, 0)
        myUc.Dock = DockStyle.Fill
        Me.Controls.Add(myUc)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

    End Sub

    Private Sub cmbThang_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub

    End Sub
End Class