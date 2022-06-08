Public Class frmChonHechuyengia
    Public dt As New DataTable
    Private Sub ftmChonHechuyengia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Me.gvListChon.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        Me.gvListChon.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
    End Sub

    Private Sub btnChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChon.Click
        For Each row As DataGridViewRow In gvListChon.Rows
            row.Cells("cCHON").Value = True
        Next
    End Sub

    Private Sub btnBochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBochon.Click
        For Each row As DataGridViewRow In gvListChon.Rows
            row.Cells("cCHON").Value = False
        Next
    End Sub

    Private Sub btnThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThuchien.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
End Class