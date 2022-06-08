Imports System.Data.SqlClient

Public Class frmKHTT_HangMucHistory


    Public HANG_MUC_ID As String = "-1"

    Private Sub LoadDataHangMucInfo()
        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
        Try
            Dim commandGetBTDK As SqlCommand = scon.CreateCommand()
            commandGetBTDK.Connection = scon
            commandGetBTDK.CommandTimeout = 9999
            commandGetBTDK.Transaction = sqlTrans
            commandGetBTDK.CommandType = CommandType.StoredProcedure
            commandGetBTDK.CommandText = "SP_GET_HANG_MUC_HISTORY"
            commandGetBTDK.Parameters.Add("@HANG_MUC_ID", SqlDbType.Int)
            commandGetBTDK.Parameters("@HANG_MUC_ID").Value = HANG_MUC_ID

            'commandGetBTDK.Parameters.Add("@KH_THANG", SqlDbType.Int)
            'commandGetBTDK.Parameters("@KH_THANG").Value = cbThang.SelectedValue

            Dim daGetBTDK As New SqlDataAdapter(commandGetBTDK)
            Dim dsBTDK As New DataSet()
            daGetBTDK.Fill(dsBTDK)

            'Dim _tbBTDK As New DataTable()
            '_tbBTDK = dsBTDK.Tables(0)

            gdBTDK.DataSource = dsBTDK.Tables(0)

            sqlTrans.Commit()
            scon.Close()

        Catch ex As Exception
            sqlTrans.Rollback()
            scon.Close()
        End Try
    End Sub

    Private Sub frmKHTT_ChuyenThangQuaThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       LoadDataHangMucInfo()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click

    End Sub
End Class