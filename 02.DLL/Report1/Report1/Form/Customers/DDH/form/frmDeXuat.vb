Imports System.Data.SqlClient

Public Class frmDeXuat
    Public Shared vSoDX As String = ""
    Private vTemSDX As String = ""

    Private Sub frmDeXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_data()

        Try
            For Each vgRow As DataGridViewRow In gvDeXuat.Rows
                gvDeXuat.Rows(vgRow.Index).Cells("CHON").Value = 0
            Next

            For Each vgRow As DataGridViewRow In gvDeXuat.Rows
                '  MessageBox.Show(vSoDX)
                If (vSoDX.Trim().Equals(gvDeXuat.Rows(vgRow.Index).Cells("SO_DE_XUAT").Value)) Then
                    gvDeXuat.Rows(vgRow.Index).Cells("CHON").Value = 1
                End If
            Next
            vTemSDX = String.Copy(vSoDX)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Load_data()
        Try
            Dim vCon As SqlConnection = New SqlConnection()
            Dim vSql As String = "Select *,0 as CHON from DE_XUAT_MUA_HANG WHERE  DE_XUAT_MUA_HANG.DUYET = 1"
            Dim vAdp As SqlDataAdapter = New SqlDataAdapter()
            Dim vTbTem As DataTable = New DataTable()

            If (Commons.clsConnect.OpenConnect(vCon)) Then
                vAdp.SelectCommand = New SqlCommand(vSql, vCon)
                vAdp.Fill(vTbTem)

                gvDeXuat.AutoGenerateColumns = False
                gvDeXuat.DataSource = vTbTem
                gvDeXuat.Columns("SO_DE_XUAT").DataPropertyName = "SO_DE_XUAT"
                gvDeXuat.Columns("NGAY").DataPropertyName = "NGAY"
                gvDeXuat.Columns("CHON").DataPropertyName = "CHON"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bt_chon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_chon.Click
        Me.Close()
    End Sub

    Private Sub bt_boChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_boChon.Click
        vSoDX = vTemSDX
        Me.Close()
    End Sub

    Private Sub gvDeXuat_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvDeXuat.CellValueChanged
        Try
            For Each vgRow As DataGridViewRow In gvDeXuat.Rows
                gvDeXuat.Rows(vgRow.Index).Cells("CHON").Value = 0
            Next

            'gvDeXuat.Rows(gvDeXuat.CurrentRow.Index).Cells("CHON").Value = True

            vSoDX = gvDeXuat.CurrentRow.Cells("SO_DE_XUAT").Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_seach_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seach.Validated
        Try
            For Each dtr As DataGridViewRow In gvDeXuat.Rows
                If txt_seach.Text = dtr.Cells("SO_DE_XUAT").Value Then
                    gvDeXuat.CurrentCell = gvDeXuat.Rows(dtr.Index).Cells("SO_DE_XUAT")
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt_seach_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_seach.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            For Each dtr As DataGridViewRow In gvDeXuat.Rows
                If txt_seach.Text = dtr.Cells("SO_DE_XUAT").Value Then
                    gvDeXuat.CurrentCell = gvDeXuat.Rows(dtr.Index).Cells("SO_DE_XUAT")
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private I As Integer = 0

    Private Sub gvDeXuat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gvDeXuat.KeyPress
        If e.KeyChar = Chr("13") Then
            MessageBox.Show(I)
            If I = gvDeXuat.Rows.Count - 1 Then
                MessageBox.Show(I + 1)
            End If
        End If
    End Sub

    Private Sub gvDeXuat_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gvDeXuat.CellValidating
        ''MessageBox.Show(e.RowIndex)
        'I = e.RowIndex

        'If I = gvDeXuat.Rows.Count - 1 Then
        '    I = gvDeXuat.Rows.Count - 1
        'End If
    End Sub

    'Private Sub gvDeXuat_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gvDeXuat.EditingControlShowing
    '    If (gvDeXuat.CurrentCell.Selected = gvDeXuat.CurrentRow.Cells("SO_LUONG_DV").Selected) Then
    '        AddHandler e.Control.KeyPress, AddressOf Me.gvKey_KeyPress
    '    End If
    'End Sub

    Private Sub gvDeXuat_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvDeXuat.CellValidated
       
    End Sub
End Class