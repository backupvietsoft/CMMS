Imports Microsoft.ApplicationBlocks.Data
Imports System.IO.Compression
Imports DevExpress.XtraEditors

Public Class frmChonCopyLoaiBaoTriCon
    Public MS_LOAI_BT As String
    Public MS_MAY As String
    Public TEN_LOAI_BT As String

    Private Sub frmChonCopyLoaiBaoTriCon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'lblLoaiBaoTriCT.Text = MS
            Dim sql As String = " SELECT CONVERT(BIT, 0) AS CHON,  T1.MS_LOAI_BT_CD , T2.TEN_LOAI_BT  FROM LOAI_BAO_TRI_QH T1 " &
                                " INNER JOIN LOAI_BAO_TRI T2 ON T1.MS_LOAI_BT_CD = T2.MS_LOAI_BT " &
                                " WHERE T1.MS_LOAI_BT_CT = " & MS_LOAI_BT & "AND T1.MS_LOAI_BT_CD IN (SELECT MS_LOAI_BT FROM MAY_LOAI_BTPN WHERE MS_MAY = N'" & MS_MAY & "' AND MS_LOAI_BT <> " & MS_LOAI_BT & " ) "
            Dim vtbTam = New DataTable
            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            vtbTam.Columns("CHON").ReadOnly = False
            vtbTam.Columns("TEN_LOAI_BT").ReadOnly = True
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiBaoTri, grvLoaiBaoTri, vtbTam, True, True, True, True)
            grvLoaiBaoTri.Columns("MS_LOAI_BT_CD").Visible = False

            'refreshLanguage()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)


            sql = " SELECT TEN_LOAI_BT FROM LOAI_BAO_TRI WHERE MS_LOAI_BT = " & MS_LOAI_BT
            lblLoaiBTCT.Text = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)

        Catch ex As Exception
        End Try
    End Sub

    'Private Sub RefreshLanguage()

    '    grvLoaiBaoTri.Columns("MS_LOAI_BT_CD").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_LOAI_BT_CD", Commons.Modules.TypeLanguage)
    '    grvLoaiBaoTri.Columns("CHON").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON", Commons.Modules.TypeLanguage)
    'End Sub
    Private Sub btnThucHien_Click(sender As Object, e As EventArgs) Handles btnThucHien.Click
        Try
            Dim dtTmp = New DataTable
            dtTmp = CType(grdLoaiBaoTri.DataSource, DataTable).Copy()
            dtTmp.DefaultView.RowFilter = " CHON = 1 "
            dtTmp = dtTmp.DefaultView.ToTable()



            If (dtTmp.Rows.Count = 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuaChonLoaiBT", Commons.Modules.TypeLanguage))
                Return
            End If

            If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgBanCoChac_ThucHien", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.No) Then
                Return
            End If

            Dim SqlInsert = New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
            SqlInsert.BeginTransaction()
            Try
                For Each row As DataRow In dtTmp.Rows
                    'spLoaiBT_CT_CopyCV_PT_LoaiBT_CD
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spLoaiBT_CT_CopyCV_PT_LoaiBT_CD", MS_MAY, MS_LOAI_BT, row("MS_LOAI_BT_CD"))
                Next
            Catch ex As Exception
                SqlInsert.RollbackTransaction()
                XtraMessageBox.Show(ex.Message)
            End Try
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class