
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmCongViecHangNgayTBCTVT

    Private _TBThietBi As New DataTable
    Private _TBVatTu As New DataTable
    Private _BXem As Boolean
    Private intRow As Integer = -1
    Public Property TBThietBi() As DataTable
        Get
            Return _TBThietBi
        End Get
        Set(ByVal value As DataTable)
            _TBThietBi = value
        End Set
    End Property
    Public Property TBVatTu() As DataTable
        Get
            Return _TBVatTu
        End Get
        Set(ByVal value As DataTable)
            _TBVatTu = value
        End Set
    End Property
    Public Property BXem() As Boolean
        Get
            Return _BXem
        End Get
        Set(ByVal value As Boolean)
            _BXem = value
        End Set
    End Property

    Private Sub frmCongViecHangNgayTBCTVT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        BindData()
        If BXem Then
            AddHandler grdDanhsachvattu.CellValidating, AddressOf Me.grdDanhsachvattu_CellValidating
            BtnThuchien.Visible = True
        Else
            BtnThuchien.Visible = False
        End If
    End Sub

    Sub BindData()
        grdDanhsachTB.DataSource = TBThietBi
        Try
            grdDanhsachTB.Columns("NOI_DUNG").Visible = False
            grdDanhsachTB.Columns("CHI_PHI_NC").Visible = False
            grdDanhsachTB.Columns("STT_CV").Visible = False
        Catch ex As Exception
        End Try
        Me.grdDanhsachTB.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY", commons.Modules.TypeLanguage)
        Me.grdDanhsachTB.Columns("MS_MAY").Width = 113
        Me.grdDanhsachTB.Columns("CHI_PHI_VT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHI_PHI_VT", commons.Modules.TypeLanguage)
        Me.grdDanhsachTB.Columns("CHI_PHI_VT").Width = 80
        Me.grdDanhsachTB.Columns("CHI_PHI_VT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Try
            Me.grdDanhsachTB.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachTB.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Sub BindDataChiTiet()
        Dim str As String = ""
        str = "SELECT * FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE MS_MAY=N'" & grdDanhsachTB.Rows(intRow).Cells("MS_MAY").Value & "' and DON_GIA IS NOT NULL"
        grdDanhsachvattu.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        grdDanhsachvattu.Columns("MS_MAY").Visible = False
        Me.grdDanhsachvattu.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
        Me.grdDanhsachvattu.Columns("MS_PT").Width = 86
        Me.grdDanhsachvattu.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
        Me.grdDanhsachvattu.Columns("TEN_PT").Width = 150
        Me.grdDanhsachvattu.Columns("SO_LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_LUONG", commons.Modules.TypeLanguage)
        Me.grdDanhsachvattu.Columns("SO_LUONG").Width = 70
        Me.grdDanhsachvattu.Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdDanhsachvattu.Columns("DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DVT", commons.Modules.TypeLanguage)
        Me.grdDanhsachvattu.Columns("DVT").Width = 50
        Me.grdDanhsachvattu.Columns("DON_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DON_GIA", commons.Modules.TypeLanguage)
        Me.grdDanhsachvattu.Columns("DON_GIA").Width = 75
        Me.grdDanhsachvattu.Columns("DON_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdDanhsachvattu.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANH_TIEN", commons.Modules.TypeLanguage)
        Me.grdDanhsachvattu.Columns("THANH_TIEN").Width = 75
        Me.grdDanhsachvattu.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Try
            Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        grdDanhsachvattu.Columns("MS_PT").ReadOnly = True
        grdDanhsachvattu.Columns("TEN_PT").ReadOnly = True
        grdDanhsachvattu.Columns("DVT").ReadOnly = True
        grdDanhsachvattu.Columns("THANH_TIEN").ReadOnly = True
        grdDanhsachvattu.Columns("DON_GIA").ReadOnly = True
    End Sub

    Private Sub grdDanhsachTB_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachTB.RowEnter
        intRow = e.RowIndex
        BindDataChiTiet()
    End Sub

    Private Sub grdDanhsachvattu_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles grdDanhsachvattu.CellValidating
        If grdDanhsachvattu.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
            If e.FormattedValue <> "" Then
                If Not IsNumeric(e.FormattedValue) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                ElseIf e.FormattedValue < 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    grdDanhsachvattu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value
                    Dim str As String = ""
                    str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=" & e.FormattedValue & ",THANH_TIEN=" & grdDanhsachvattu.Rows(e.RowIndex).Cells("THANH_TIEN").Value & " WHERE MS_MAY=N'" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_MAY").Value & "' AND MS_PT='" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
            Else
                Dim str As String = ""
                str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=NULL,THANH_TIEN=NULL WHERE MS_MAY=N'" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_MAY").Value & "' AND MS_PT='" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdDanhsachvattu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = System.DBNull.Value
            End If
            grdDanhsachvattu.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub

    Private Sub BtnThuchien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThuchien.Click
        Dim tb As New DataTable()
        Dim str As String = ""
        str = "SELECT MS_PT,SUM(ISNULL(THANH_TIEN,0))as THANH_TIEN FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE DON_GIA IS NOT NULL AND THANH_TIEN IS NOT NULL GROUP BY MS_PT"
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tb.Rows.Count - 1
            For j As Integer = 0 To TBVatTu.Rows.Count - 1
                If tb.Rows(i).Item("MS_PT") = TBVatTu.Rows(j).Item("MS_PT") Then
                    If tb.Rows(i).Item("THANH_TIEN") <> TBVatTu.Rows(j).Item("THANH_TIEN") Then
                        'XtraMessageBox.Show("phân bổ vật tư khong  đồng đều")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgPhanBoKhongDeuThietBiVTCT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If
            Next
        Next
        str = "SELECT MS_MAY,SUM(ISNULL(THANH_TIEN,0))as THANH_TIEN FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE DON_GIA IS NOT NULL AND THANH_TIEN IS NOT NULL GROUP BY MS_MAY"
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tb.Rows.Count - 1
            For j As Integer = 0 To TBThietBi.Rows.Count - 1
                If tb.Rows(i).Item("MS_MAY") = TBThietBi.Rows(j).Item("MS_MAY") Then
                    If tb.Rows(i).Item("THANH_TIEN") <> TBThietBi.Rows(j).Item("CHI_PHI_VT") Then
                        'XtraMessageBox.Show("phân bổ thiết bị khong  đồng đều")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgPhanBoKhongDeuThietBiCT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If
            Next
        Next
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Dim str As String = ""
        str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET THANH_TIEN=NULL "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Me.Close()
    End Sub
End Class