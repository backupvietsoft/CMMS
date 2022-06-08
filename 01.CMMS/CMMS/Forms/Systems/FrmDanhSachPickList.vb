Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Catalogue

Imports Commons.VS.Classes.Admin

Public Class FrmDanhSachPickList
    Dim _SQLPickList, _MS_KHO As String
    Dim frmLoad As Boolean = False

    Public Property SQLPickList() As String
        Get
            Return _SQLPickList
        End Get
        Set(ByVal value As String)
            _SQLPickList = value
        End Set
    End Property

    Public Property MS_KHO() As String
        Get
            Return _MS_KHO
        End Get
        Set(ByVal value As String)
            _MS_KHO = value
        End Set
    End Property

    Private Sub FrmDanhSachPickList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtpTuNgay.Value = DateSerial(Format(Year(Now()), "short date"), Format(Month(Now()), "short date") - 1, Format(Day(Now()), "short date"))
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        commons.Modules.ObjSystems.DinhDang()
        RemoveHandler CboUserName.SelectedIndexChanged, AddressOf Me.CboUserName_SelectedIndexChanged
        frmLoad = True
        Try
            grdPickList.DataSource = System.DBNull.Value
        Catch ex As Exception

        End Try

        Dim dtTable As New DataTable
        commons.Modules.SQLString = "SELECT DISTINCT USER_NAME FROM PICK_LIST"
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
        CboUserName.DisplayMember = "USER_NAME"
        CboUserName.ValueMember = "USER_NAME"
        CboUserName.DataSource = dtTable
        CboUserName.SelectedIndex = -1
        AddHandler CboUserName.SelectedIndexChanged, AddressOf Me.CboUserName_SelectedIndexChanged
        AddHandler DtpTuNgay.ValueChanged, AddressOf Me.DtpTuNgay_ValueChanged
        AddHandler DtpDenNgay.ValueChanged, AddressOf Me.DtpDenNgay_ValueChanged
        frmLoad = False
    End Sub

    Sub LayDuLieu()
        Dim dtTable As New DataTable
        Try
            grdPickList.Columns.Clear()
        Catch ex As Exception

        End Try
        If CboUserName.SelectedIndex = -1 Or CboUserName.SelectedValue = "" Or IsDBNull(CboUserName.SelectedValue) Or frmLoad = True Then
            grdPickList.DataSource = DBNull.Value
            Exit Sub
        End If

        commons.Modules.SQLString = "SELECT DISTINCT PICK_LIST.PICK_NO, THOI_GIAN FROM PICK_LIST INNER JOIN PICK_LIST_CHI_TIET ON PICK_LIST.PICK_NO = PICK_LIST_CHI_TIET.PICK_NO WHERE THOI_GIAN >=Convert(datetime,'" & Format(DtpTuNgay.Value, "Short date") & "',103) AND THOI_GIAN <=convert(datetime,'" & Format(DtpDenNgay.Value, "Short date") & "',103) AND USER_NAME='" & CboUserName.SelectedValue & "' AND MS_KHO='" & MS_KHO.ToString & "' ORDER BY PICK_LIST.PICK_NO DESC"

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))

        grdPickList.DataSource = dtTable
        Try
            grdPickList.Columns("PICK_NO").Width = 110
            grdPickList.Columns("THOI_GIAN").Width = 150
            grdPickList.Columns("PICK_NO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "PICK_NO", commons.Modules.TypeLanguage)
            grdPickList.Columns("THOI_GIAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THOI_GIAN", commons.Modules.TypeLanguage)
        Catch ex As Exception
        End Try
        Try
            Me.grdPickList.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdPickList.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnTHOAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTHOAT.Click

        Me.Close()
    End Sub

    Private Sub CboUserName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LayDuLieu()
    End Sub

    Private Sub DtpTuNgay_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LayDuLieu()
    End Sub

    Private Sub DtpDenNgay_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LayDuLieu()
    End Sub

    Private Sub grdPickList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPickList.RowEnter
        Try
            grdPickList.Rows(e.RowIndex).Selected = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnThuc_Hien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThuc_Hien.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class