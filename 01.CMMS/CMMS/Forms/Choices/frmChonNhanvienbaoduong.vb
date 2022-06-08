
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmChonNhanvienbaoduong

    Private _TBCongNhan As New DataTable
    Private txtKeyPress As TextBox

    Public Property TBCongNhan() As DataTable
        Get
            Return _TBCongNhan
        End Get
        Set(ByVal value As DataTable)
            _TBCongNhan = value
        End Set
    End Property

    Private Sub frmChonNhanvienbaoduong_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        LoadDonVi()
        LoadBan()
        BindData()
    End Sub

    Private Sub LoadDonVi()
        Dim str As String = ""
        str = "SELECT MS_DON_VI,TEN_DON_VI FROM DON_VI"
        cboDonVi.Value = "MS_DON_VI"
        cboDonVi.Display = "TEN_DON_VI"
        cboDonVi.StoreName = "QL_SEARCH"
        cboDonVi.Param = str
        cboDonVi.BindDataSource()
    End Sub

    Private Sub LoadBan()
        Dim str As String = ""
        cboBan.DataSource = Nothing
        If cboDonVi.SelectedIndex <> -1 Then
            Try
                Str = "SELECT  TO_PHONG_BAN.MS_TO, TEN_TO  FROM TO_PHONG_BAN WHERE MS_DON_VI='" & cboDonVi.SelectedValue & "'"
                cboBan.StoreName = "QL_SEARCH"
                cboBan.Value = "MS_TO"
                cboBan.Display = "TEN_TO"
                cboBan.Param = str
                cboBan.BindDataSource()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Sub BindData()

        grdDanhsachnhanvien.Columns.Clear()
        Dim col1 As New DataGridViewTextBoxColumn
        col1.DataPropertyName = "MS_CONG_NHAN"
        col1.Name = "MS_CONG_NHAN"
        col1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_CONG_NHAN", commons.Modules.TypeLanguage)
        col1.Width = 146
        col1.ReadOnly = True
        grdDanhsachnhanvien.Columns.Add(col1)
        Dim col2 As New DataGridViewTextBoxColumn
        col2.DataPropertyName = "HO_TEN_CONG_NHAN"
        col2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "HO_TEN_CONG_NHAN", commons.Modules.TypeLanguage)
        col2.Name = "HO_TEN_CONG_NHAN"
        col2.Width = 220
        col2.ReadOnly = True
        grdDanhsachnhanvien.Columns.Add(col2)
        Dim col3 As New DataGridViewTextBoxColumn
        col3.DataPropertyName = "SO_GIO"
        col3.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_GIO", commons.Modules.TypeLanguage)
        col3.Width = 80
        col3.Name = "SO_GIO"
        If Commons.Modules.iPhutGioPBT = 1 Then
            col3.DefaultCellStyle.Format = "###,###,###"
        Else
            col3.DefaultCellStyle.Format = "###,###,##0.00"
        End If
        col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachnhanvien.Columns.Add(col3)
        grdDanhsachnhanvien.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetNHAN_VIEN_LUONG", cboBan.SelectedValue, cboDonVi.SelectedValue).Tables(0)
        grdDanhsachnhanvien.Columns("LUONG_CO_BAN").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachnhanvien.Columns("LUONG_CO_BAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LUONG", commons.Modules.TypeLanguage)
        grdDanhsachnhanvien.Columns("LUONG_CO_BAN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachnhanvien.Columns("LUONG_CO_BAN").ReadOnly = True
        For i As Integer = 0 To TBCongNhan.Rows.Count - 1
            For j As Integer = 0 To grdDanhsachnhanvien.Rows.Count - 1
                If TBCongNhan.Rows(i).Item("MS_CONG_NHAN") = grdDanhsachnhanvien.Rows(j).Cells("MS_CONG_NHAN").Value Then
                    grdDanhsachnhanvien.Rows(j).Cells("SO_GIO").Value = TBCongNhan.Rows(i).Item("SO_GIO")
                    Exit For
                End If
            Next
        Next
        Try
            Me.grdDanhsachnhanvien.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachnhanvien.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThuchien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThuchien.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub grdDanhsachnhanvien_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhsachnhanvien.CellValidating
        If grdDanhsachnhanvien.Columns(e.ColumnIndex).Name = "SO_GIO" Then
            If e.FormattedValue <> "" Then
                If Not IsNumeric(e.FormattedValue) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoGioLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdDanhsachnhanvien.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                ElseIf e.FormattedValue = "0-" Or e.FormattedValue < 0 Or e.FormattedValue = "-0" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoGioLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdDanhsachnhanvien.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                End If
                grdDanhsachnhanvien.EndEdit()
                For i As Integer = 0 To _TBCongNhan.Rows.Count - 1
                    If TBCongNhan.Rows(i).Item("MS_CONG_NHAN") = grdDanhsachnhanvien.Rows(e.RowIndex).Cells("MS_CONG_NHAN").Value Then
                        _TBCongNhan.Rows(i).Item("SO_GIO") = grdDanhsachnhanvien.Rows(e.RowIndex).Cells("SO_GIO").Value
                        Exit Sub
                    End If
                Next
                Dim rCongnhan As DataRow = _TBCongNhan.NewRow()
                rCongnhan("MS_CONG_NHAN") = grdDanhsachnhanvien.Rows(e.RowIndex).Cells("MS_CONG_NHAN").Value
                rCongnhan("SO_GIO") = Convert.ToDouble(grdDanhsachnhanvien.Rows(e.RowIndex).Cells("SO_GIO").Value)
                rCongnhan("HO_TEN") = grdDanhsachnhanvien.Rows(e.RowIndex).Cells("HO_TEN_CONG_NHAN").Value
                rCongnhan("LUONG") = grdDanhsachnhanvien.Rows(e.RowIndex).Cells("LUONG_CO_BAN").Value
                _TBCongNhan.Rows.Add(rCongnhan)
            Else
                For i As Integer = 0 To _TBCongNhan.Rows.Count - 1
                    If TBCongNhan.Rows(i).Item("MS_CONG_NHAN") = grdDanhsachnhanvien.Rows(e.RowIndex).Cells("MS_CONG_NHAN").Value Then
                        _TBCongNhan.Rows.Remove(_TBCongNhan.Rows(i))
                        Exit Sub
                    End If
                Next
            End If
            grdDanhsachnhanvien.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub

    Private Sub cboDonVi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDonVi.SelectionChangeCommitted
        If Not cboDonVi.SelectedValue Is Nothing Then
            LoadBan()
            BindData()
        End If
    End Sub

    Private Sub cboBan_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBan.SelectionChangeCommitted
        If Not cboDonVi.SelectedValue Is Nothing Then BindData()
    End Sub

    Private Sub grdDanhsachnhanvien_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDanhsachnhanvien.EditingControlShowing
        Try
            txtKeyPress = e.Control
            If grdDanhsachnhanvien.CurrentCell.OwningColumn.Name = "SO_GIO" Then
                RemoveHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
                AddHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            Else
                RemoveHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class