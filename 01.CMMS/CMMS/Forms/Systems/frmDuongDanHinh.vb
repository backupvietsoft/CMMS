Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmDuongDanHinh
    Public _STT As Integer
    Public _FLAG As Boolean = False
    'AND (MS_MAY = N'AIC-0011') AND (MS_TS_GSTT = N'48') AND (MS_BO_PHAN = N'01.02.02') AND (MS_TT = 1) "

    Public sMS_MAY As String = ""
    Public sMS_TS_GSTT As String = ""
    Public sMS_BO_PHAN As String = ""
    Public iMS_TT As Integer

    Public Property STT() As Integer
        Get
            Return _STT
        End Get
        Set(ByVal value As Integer)
            _STT = value
        End Set
    End Property

    Public Property FLAG() As Boolean
        Get
            Return _FLAG
        End Get
        Set(ByVal value As Boolean)
            _FLAG = value
        End Set
    End Property

    Sub BIND_DATA()
        Dim dttable As New DataTable
        If FLAG Then
            'dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_HINH_GSTT", STT))
            Dim sSql As String
            sSql = " SELECT        TOP (100) PERCENT DUONG_DAN, GHI_CHU
                        FROM            dbo.GIAM_SAT_TINH_TRANG_HINH
                        WHERE        (STT = " & STT & ") AND (MS_MAY = N'" & sMS_MAY & "') AND (MS_TS_GSTT = N'" & sMS_TS_GSTT & "') AND (MS_BO_PHAN = N'" & sMS_BO_PHAN & "') AND (MS_TT = " & iMS_TT & ") "
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        Else
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_HINH_YCNSDCTH", STT))
        End If
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdHinh, grvHinh, dttable, 0, 1, 0, 0)

        grvHinh.Columns("DUONG_DAN").Width = 400
        grvHinh.Columns("GHI_CHU").Width = 300
    End Sub


    Private Sub frmDuongDanHinh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BIND_DATA()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If Me.grvHinh.RowCount = 0 Then Exit Sub
        Try
            System.Diagnostics.Process.Start(grvHinh.GetFocusedRow("DUONG_DAN").ToString())
        Catch ex As Exception
            Commons.MssBox.Show("frmThongtinthietbi", "MsgQuyenKT45")
        End Try
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub grvHinh_DoubleClick(sender As Object, e As EventArgs) Handles grvHinh.DoubleClick
        If Me.grvHinh.RowCount = 0 Then Exit Sub
        Try
            System.Diagnostics.Process.Start(grvHinh.GetFocusedRow("DUONG_DAN").ToString())
        Catch ex As Exception
            Commons.MssBox.Show("frmThongtinthietbi", "MsgQuyenKT45")
        End Try

    End Sub
End Class