Imports Microsoft.ApplicationBlocks.Data

Public Class frmChonphutung_thaythe
    Dim _sQuery As String

    Public Property Query() As String
        Get
            Return _sQuery
        End Get
        Set(ByVal value As String)
            _sQuery = value
        End Set
    End Property

    Sub ShowData()
        Dim dtPT As DataTable = New DataTable()
        dtPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Query))

        Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTung, grvPTung, dtPT, True, True, 0, 1, 0, "")
        For i As Int16 = 1 To dtPT.Columns.Count - 1
            dtPT.Columns(i).ReadOnly = True
            grvPTung.Columns(i).OptionsColumn.ReadOnly = True
        Next
        dtPT.Columns("CHON").ReadOnly = False

        grvPTung.Columns("CHON").OptionsColumn.ReadOnly = False
        grvPTung.Columns("CHON").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        grvPTung.Columns("MS_PT").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        grvPTung.Columns("MS_PT").OptionsColumn.FixedWidth = True
        grvPTung.Columns("TEN_PT").OptionsColumn.FixedWidth = True

    End Sub

    Private Sub frmChonPhuTung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ShowData()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnChapnhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Close()
    End Sub

    Private Sub txtSearch_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtSearch.EditValueChanging
        Try
            If grdPTung.DataSource Is Nothing Then Exit Sub

            Dim dtTmp As New DataTable
            Dim sDK As String = ""

            dtTmp = CType(grdPTung.DataSource, DataTable)

            sDK = " (MS_PT like '%" + txtSearch.Text + "%' OR MS_PT_NCC like '%" + txtSearch.Text + "%' OR MS_PT_CTY like '%" + txtSearch.Text + "%' OR TEN_PT like '%" + txtSearch.Text + "%' OR TEN_PT_VIET like '%" + txtSearch.Text + "%' OR QUY_CACH like '%" + txtSearch.Text + "%') "
            Try
                dtTmp.DefaultView.RowFilter = sDK
            Catch ex As Exception
                dtTmp.DefaultView.RowFilter = ""
            End Try
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnALL_Click(sender As Object, e As EventArgs) Handles btnALL.Click
        Commons.Modules.ObjSystems.MChooseGrid(True, "CHON", grvPTung)
    End Sub

    Private Sub btnNotALL_Click(sender As Object, e As EventArgs) Handles btnNotALL.Click
        Commons.Modules.ObjSystems.MChooseGrid(False, "CHON", grvPTung)
    End Sub
End Class