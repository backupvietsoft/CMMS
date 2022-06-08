Public Class frmInTuKeHoachTongThe
    Public iLoaiBC As Integer = -1

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If optDuTruVT_TheoMay.Checked Then
            iLoaiBC = 2
        ElseIf optDuTruVT_TheoDayChuyen.Checked Then
            iLoaiBC = 3
        End If

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        iLoaiBC = -1
        Me.Close()
    End Sub

    Private Sub frmInTuKeHoachTongThe_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
End Class