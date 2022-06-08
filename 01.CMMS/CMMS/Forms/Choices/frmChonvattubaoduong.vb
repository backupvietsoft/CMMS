
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmChonvattubaoduong

    Private _TBVattu As New DataTable
    Private txtKeyPress As TextBox

    Public Property TBVattu() As DataTable
        Get
            Return _TBVattu
        End Get
        Set(ByVal value As DataTable)
            _TBVattu = value
        End Set
    End Property


    Private _vstt_cv As Integer

    Public Property STT_CV() As Integer
        Get
            Return _vstt_cv
        End Get
        Set(ByVal value As Integer)
            _vstt_cv = value
        End Set
    End Property


    Private Sub frmChonvattubaoduong_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        Dim str As String = "SELECT DISTINCT LOAI_PHU_TUNG.MS_LOAI_PT,TEN_LOAI_PT " & _
                            "FROM LOAI_PHU_TUNG INNER JOIN NHOM_LOAI_PHU_TUNG ON LOAI_PHU_TUNG.MS_LOAI_PT=NHOM_LOAI_PHU_TUNG.MS_LOAI_PT " & _
                                "INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_PHU_TUNG.GROUP_ID " & _
                                "INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID " & _
                            "WHERE USERNAME='" & Commons.Modules.UserName & "'"

        cboLoaiPT.Display = "TEN_LOAI_PT"
        cboLoaiPT.Value = "MS_LOAI_PT"
        cboLoaiPT.DropDownWidth = 200
        cboLoaiPT.Param = str
        cboLoaiPT.StoreName = "QL_SEARCH"
        cboLoaiPT.BindDataSource()
        If cboLoaiPT.Items.Count = 0 Then
            cboLoaiPT.Text = ""
        End If

        BindData()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdDanhsachvattu_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhsachvattu.CellValidating

        If grdDanhsachvattu.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
            If e.FormattedValue <> "" Then
                If Not IsNumeric(e.FormattedValue) Then
                    grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    e.Cancel = True
                    Exit Sub
                ElseIf e.FormattedValue = "0-" Or e.FormattedValue = "-0" Or e.FormattedValue < 0 Then
                    grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    e.Cancel = True
                    Exit Sub
                End If
                grdDanhsachvattu.EndEdit()
                For i As Integer = 0 To _TBVattu.Rows.Count - 1
                    If grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value = _TBVattu.Rows(i).Item("MS_PT") Then
                        _TBVattu.Rows(i)("SO_LUONG") = grdDanhsachvattu.Rows(e.RowIndex).Cells("SO_LUONG").Value
                        _TBVattu.Rows(i)("DON_GIA") = grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value
                        Exit Sub
                    End If
                Next
                Dim dr As DataRow
                dr = _TBVattu.NewRow
                dr.Item("STT_CV") = System.DBNull.Value
                dr.Item("MS_PT") = grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value
                dr.Item("TEN_PT") = grdDanhsachvattu.Rows(e.RowIndex).Cells("TEN_PT").Value
                dr.Item("DVT") = grdDanhsachvattu.Rows(e.RowIndex).Cells("DVT").Value
                dr.Item("SO_LUONG") = Math.Round(Double.Parse(grdDanhsachvattu.Rows(e.RowIndex).Cells("SO_LUONG").Value), 1)
                If grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value Is Nothing Then
                    dr.Item("DON_GIA") = System.DBNull.Value
                    dr.Item("THANH_TIEN") = System.DBNull.Value
                Else
                    If Not grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value Is Nothing And Not grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value.ToString().Trim().Equals("") Then
                        dr.Item("DON_GIA") = Math.Round(Double.Parse(grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value), 1)
                        dr.Item("THANH_TIEN") = dr.Item("DON_GIA") * dr.Item("SO_LUONG")
                    End If
                End If
                _TBVattu.Rows.Add(dr)
            Else
                For i As Integer = 0 To _TBVattu.Rows.Count - 1
                    If grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value = _TBVattu.Rows(i).Item("MS_PT") Then
                        _TBVattu.Rows.Remove(TBVattu.Rows(i))
                    End If
                Next
            End If
        ElseIf grdDanhsachvattu.Columns(e.ColumnIndex).Name = "DON_GIA" Then
            If e.FormattedValue <> "" Then
                If Not IsNumeric(e.FormattedValue) Then
                    grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDonGiaLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    e.Cancel = True
                    Exit Sub
                ElseIf e.FormattedValue = "0-" Or e.FormattedValue = "-0" Or e.FormattedValue < 0 Then
                    grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDonGiaLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    e.Cancel = True
                    Exit Sub
                End If
                grdDanhsachvattu.EndEdit()
                For i As Integer = 0 To _TBVattu.Rows.Count - 1
                    If grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value = _TBVattu.Rows(i).Item("MS_PT") Then
                        If grdDanhsachvattu.Rows(e.RowIndex).Cells("SO_LUONG").Value Is Nothing Then
                            _TBVattu.Rows(i)("SO_LUONG") = System.DBNull.Value
                        Else
                            _TBVattu.Rows(i)("SO_LUONG") = grdDanhsachvattu.Rows(e.RowIndex).Cells("SO_LUONG").Value
                        End If
                        If grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value Is Nothing Then
                            _TBVattu.Rows(i)("DON_GIA") = System.DBNull.Value
                        Else
                            _TBVattu.Rows(i)("DON_GIA") = grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value
                        End If
                        Exit Sub
                    End If
                Next
            End If

        End If

        grdDanhsachvattu.Rows(e.RowIndex).ErrorText = ""
    End Sub

    Private Sub BtnThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThuchien.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Sub BindData()
        Dim col1 As New DataGridViewTextBoxColumn

        grdDanhsachvattu.Columns.Clear()
        grdDanhsachvattu.DataSource = Nothing
        col1.DataPropertyName = "MS_PT"
        col1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
        col1.Name = "MS_PT"
        col1.Width = 100
        col1.ReadOnly = True
        grdDanhsachvattu.Columns.Add(col1)
        Dim col2 As New DataGridViewTextBoxColumn
        col2.DataPropertyName = "TEN_PT"
        col2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
        col2.Name = "TEN_PT"
        'col2.Width = 200
        col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col2.ReadOnly = True
        grdDanhsachvattu.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        col3.DataPropertyName = "SO_LUONG"
        col3.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_LUONG", commons.Modules.TypeLanguage)
        col3.Name = "SO_LUONG"
        col3.DefaultCellStyle.Format = "###.0"
        col3.Width = 90
        col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns.Add(col3)

        Dim col5 As New DataGridViewTextBoxColumn
        col5.DataPropertyName = "DVT"
        col5.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DVT", commons.Modules.TypeLanguage)
        col5.Name = "DVT"
        col5.Width = 76
        col5.ReadOnly = True
        grdDanhsachvattu.Columns.Add(col5)

        Dim col4 As New DataGridViewTextBoxColumn
        col4.DataPropertyName = "DON_GIA"
        col4.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DON_GIA", commons.Modules.TypeLanguage)
        col4.Name = "DON_GIA"
        col4.Width = 77
        col4.DefaultCellStyle.Format = "###"
        col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns.Add(col4)
        Dim str As String = ""

        'str = "SELECT distinct IC_PHU_TUNG.MS_PT,TEN_PT,CASE " & commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT " & _
        '" FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT INNER JOIN " & _
        '" IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT INNER JOIN " & _
        '" LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN " & _
        '" LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '" NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        '" NHOM_LOAI_PHU_TUNG ON LOAI_PHU_TUNG.MS_LOAI_PT = NHOM_LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN " & _
        '" NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID AND NHOM_LOAI_PHU_TUNG.GROUP_ID = NHOM.GROUP_ID INNER JOIN " & _
        '" USERS ON NHOM.GROUP_ID = USERS.GROUP_ID LEFT OUTER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
        '" WHERE USERNAME='" & Commons.Modules.UserName & "' and MS_LOAI_VT<>1"



        str = "SELECT DISTINCT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT,CASE " & commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT " & _
              "FROM IC_PHU_TUNG INNER JOIN IC_PHU_TUNG_LOAI_MAY ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_MAY.MS_PT INNER JOIN " & _
                      "IC_PHU_TUNG_LOAI_PHU_TUNG ON IC_PHU_TUNG.MS_PT = IC_PHU_TUNG_LOAI_PHU_TUNG.MS_PT INNER JOIN " & _
                      "LOAI_PHU_TUNG ON IC_PHU_TUNG_LOAI_PHU_TUNG.MS_LOAI_PT = LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN " & _
                      "LOAI_MAY ON IC_PHU_TUNG_LOAI_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                      "NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
                      "NHOM_LOAI_PHU_TUNG ON LOAI_PHU_TUNG.MS_LOAI_PT = NHOM_LOAI_PHU_TUNG.MS_LOAI_PT INNER JOIN " & _
                      "NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID AND " & _
                      "NHOM_LOAI_PHU_TUNG.GROUP_ID = NHOM.GROUP_ID INNER JOIN " & _
                      "USERS ON NHOM.GROUP_ID = USERS.GROUP_ID INNER JOIN " & _
                      "LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT LEFT OUTER JOIN " & _
                      "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
              "WHERE (USERS.USERNAME = '" & Commons.Modules.UserName & "') AND (LOAI_VT.VAT_TU = 1) "

        If cboLoaiPT.SelectedValue <> -1 Then
            str += " AND LOAI_PHU_TUNG.MS_LOAI_PT=" & cboLoaiPT.SelectedValue
        End If

        Dim vTbData As New DataTable
        vTbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VT_CONG_VIEC_HANG_NGAY", _vstt_cv, cboLoaiPT.SelectedValue))

        grdDanhsachvattu.DataSource = vTbData         'SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To TBVattu.Rows.Count - 1
            For j As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
                If grdDanhsachvattu.Rows(j).Cells("MS_PT").Value = TBVattu.Rows(i).Item("MS_PT") Then
                    grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value = TBVattu.Rows(i).Item("SO_LUONG")
                    grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value = TBVattu.Rows(i).Item("DON_GIA")
                    Exit For
                End If
            Next
        Next
        Try
            Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboLoaiPT_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiPT.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub txtMSPT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMSPT.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim i As Integer = 0
            While i < grdDanhsachvattu.RowCount - 1 And grdDanhsachvattu.Rows(i).Cells("MS_PT").Value.ToString.ToUpper <> txtMSPT.Text.ToUpper
                i = i + 1
            End While

            If i < grdDanhsachvattu.RowCount - 1 Then
                grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(i).Cells("MS_PT")
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "KHONG_TIM_THAY", commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
            End If
        End If
    End Sub

    Private Sub grdDanhsachvattu_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDanhsachvattu.EditingControlShowing
        Try
            txtKeyPress = e.Control
            If grdDanhsachvattu.CurrentCell.OwningColumn.Name = "SO_LUONG" Or grdDanhsachvattu.CurrentCell.OwningColumn.Name = "DON_GIA" Then
                RemoveHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
                AddHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            Else
                RemoveHandler txtKeyPress.KeyPress, AddressOf Commons.clsXuLy.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class