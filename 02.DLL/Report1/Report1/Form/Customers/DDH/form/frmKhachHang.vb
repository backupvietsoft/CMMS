
Imports System.Data.SqlClient

Public Class frmKhachHang
    Public Shared vMaKH As String = ""
    Public Shared vTenKH As String = ""

    Private vMaTem As String = ""
    Private vTenTem As String = ""
    Private vTbKH As DataTable = New DataTable()


    Private Sub frmKhachHang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
        vMaTem = String.Copy(vMaKH)
        vTenTem = String.Copy(vTenKH)       
    End Sub

    Private Sub Load_Data()
        Try
            Dim vCon As SqlConnection = New SqlConnection()
            Dim sql As String = "Select * FROM Khach_hang "
            Dim tbTem As DataTable = New DataTable()
            If (Commons.clsConnect.OpenConnect(vCon)) Then
                Dim vCmd As SqlDataAdapter = New SqlDataAdapter()
                vCmd.SelectCommand = New SqlCommand(sql, vCon)
                vCmd.Fill(tbTem)
                vTbKH = tbTem
                gv_KhachHang.AutoGenerateColumns = False
                gv_KhachHang.DataSource = tbTem
                gv_KhachHang.Columns("MS_KH").DataPropertyName = "MS_KH"
                gv_KhachHang.Columns("TEN_CONG_TY").DataPropertyName = "TEN_CONG_TY"
                gv_KhachHang.Columns("TEN_RUT_GON").DataPropertyName = "TEN_RUT_GON"
                gv_KhachHang.Columns("DIA_CHI").DataPropertyName = "DIA_CHI"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_Chon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_Chon.Click

        'For Each vRow As DataGridViewRow In gv_KhachHang.Rows
        '    If (gv_KhachHang.Rows(vRow.Index).Cells("CHON").Value = True) Then
        '        Me.Close()
        '    End If
        'Next
        'vMaKH = vMaTem
        'vTenKH = vTenTem
        Me.Close()

    End Sub

    Private Sub gv_KhachHang_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_KhachHang.CellValueChanged
        Try
            For Each vRow As DataGridViewRow In gv_KhachHang.Rows
                gv_KhachHang.Rows(vRow.Index).Cells("CHON").Value = 0

            Next
            vMaKH = gv_KhachHang.Rows(gv_KhachHang.CurrentRow.Index).Cells("MS_KH").Value
            vTenKH = gv_KhachHang.Rows(gv_KhachHang.CurrentRow.Index).Cells("TEN_CONG_TY").Value

            lba_KHchon.Text = vMaKH & vTenKH
        Catch ex As Exception
        End Try
       
    End Sub

    Private Sub bt_BoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_BoChon.Click
        vMaKH = vMaTem
        vTenKH = vTenTem
        Me.Close()
    End Sub

    Private Sub txt_seach_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seach.Validated
        Try
            For Each dtr As DataGridViewRow In gv_KhachHang.Rows
                If txt_seach.Text = dtr.Cells("MS_KH").Value Then
                    gv_KhachHang.CurrentCell = gv_KhachHang.Rows(dtr.Index).Cells("MS_KH")
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt_seach_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_seach.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                For Each dtr As DataGridViewRow In gv_KhachHang.Rows
                    If txt_seach.Text = dtr.Cells("MS_KH").Value Then
                        gv_KhachHang.CurrentCell = gv_KhachHang.Rows(dtr.Index).Cells("MS_KH")
                        Exit Sub
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class