
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Convert
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Drawing.Graphics
Public Class frmChonNDD
    Private _MS_KH As String
    Public intRow As Integer = 0


    Public Property MS_KH() As String
        Get
            Return _MS_KH
        End Get
        Set(ByVal value As String)
            _MS_KH = value
        End Set
    End Property

    Private Sub frmChonNDD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        grdDSNDD.DataSource = New clsEORController().GetNGUOI_DAI_DIENs(MS_KH)
        grdDSNDD.Columns("STT").Visible = False
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    
    Private Sub bBtnChon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChon.Click
        If grdDSNDD.Rows.Count = 0 Then
            DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Close()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdDSNDD_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDSNDD.RowEnter
        intRow = e.RowIndex
    End Sub

    Private Sub grdDSNDD_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDSNDD.RowHeaderMouseClick
        intRow = e.RowIndex
    End Sub
End Class