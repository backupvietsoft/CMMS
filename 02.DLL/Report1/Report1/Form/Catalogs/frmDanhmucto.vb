
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors

Public Class frmDanhmucto

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private Ten_To_tmp As String
    Private rowcount As Integer = 0

#Region "Control Event"

    Private Sub frmDanhmucto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadcboDON_VI()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        visibleButtonGhi(False)
        visibleButtonXoa(False)
        LockData(True)
        Try
            Me.grdTo.Columns("TEN_TO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TO", Commons.Modules.TypeLanguage)
            Me.grdTo.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdTo.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            If (Commons.Modules.sPrivate = "SHISEIDO") Then
                Me.grdTo.Columns("MS_CHUOI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MA_TO", Commons.Modules.TypeLanguage)
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguage()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Try

            Me.grdDanhsachto.Columns("TEN_TO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BAN", Commons.Modules.TypeLanguage)
            Me.grdDanhsachto.Columns("TEN_DON_VI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DON_VI", Commons.Modules.TypeLanguage)
            Me.grdDanhsachto.Columns("TO_TRUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TRUONG_BAN", Commons.Modules.TypeLanguage)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        visibleButtonGhi(True)
        LockData(False)
        blnThem = True
        txtTEN_TO.Focus()
        grdDanhsachto.Enabled = False

        grdTo.AllowUserToAddRows = True
        Me.grdTo.Columns("TEN_TO").ReadOnly = False

        If (Commons.Modules.sPrivate = "SHISEIDO") Then
            Me.grdTo.Columns("MS_CHUOI").ReadOnly = False

        End If

        AddHandler txtTEN_TO.Validated, AddressOf Me.txtTEN_TO_Validated
        AddHandler cboDON_VI.SelectedValueChanged, AddressOf Me.cboDON_VI_SelectedValueChanged
        AddHandler txtSTT_TO.Validated, AddressOf Me.txtSTT_TO_Validated
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        rowcount = Me.grdTo.RowCount
        Ten_To_tmp = txtTEN_TO.Text
        VisibleButton(False)
        visibleButtonGhi(True)
        LockData(False)
        txtTEN_TO.Focus()
        grdDanhsachto.CurrentCell() = grdDanhsachto.Rows(intRowPB).Cells("TEN_TO")
        grdDanhsachto.Focus()
        grdDanhsachto.Enabled = False
        grdTo.AllowUserToAddRows = True
        Me.grdTo.Columns("TEN_TO").ReadOnly = False
        If (Commons.Modules.sPrivate = "SHISEIDO") Then
            Me.grdTo.Columns("MS_CHUOI").ReadOnly = False

        End If
        AddHandler txtTEN_TO.Validated, AddressOf Me.txtTEN_TO_Validated
        AddHandler cboDON_VI.SelectedValueChanged, AddressOf Me.cboDON_VI_SelectedValueChanged
        AddHandler txtSTT_TO.Validated, AddressOf Me.txtSTT_TO_Validated


    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        VisibleButton(False)
        visibleButtonXoa(True)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim tmp As String = Trim(txtTEN_TO.Text)
        If txtTEN_TO.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage),
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtTEN_TO.Focus()
            Exit Sub
        End If
        If cboDON_VI.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage),
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            cboDON_VI.Focus()
            Exit Sub
        End If

        AddTo()

        ' Xử lý load lại dữ liệu cho combobox đơn vị đo trong Form Thông số thiết bị.

        BindData()
        blnThem = False
        VisibleButton(True)
        visibleButtonGhi(False)
        LockData(True)
        grdDanhsachto.Enabled = True
        grdTo.AllowUserToAddRows = False
        Me.grdTo.Columns("TEN_TO").ReadOnly = True
        If (Commons.Modules.sPrivate = "SHISEIDO") Then
            Me.grdTo.Columns("MS_CHUOI").ReadOnly = True

        End If
        While i < grdDanhsachto.RowCount
            If grdDanhsachto.Rows(i).Cells("TEN_TO").Value.ToString = tmp Then
                grdDanhsachto.Rows(i).Cells("TEN_TO").Selected = True
                Exit While
            Else
                i = i + 1
            End If
        End While

        RemoveHandler txtTEN_TO.Validated, AddressOf Me.txtTEN_TO_Validated
        RemoveHandler cboDON_VI.SelectedValueChanged, AddressOf Me.cboDON_VI_SelectedValueChanged
        RemoveHandler txtSTT_TO.Validated, AddressOf Me.txtSTT_TO_Validated
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grdDanhsachto.RowCount <> 0 Then
                ShowTO(grdDanhsachto.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowTO(0)
        End Try
        blnThem = False
        VisibleButton(True)
        visibleButtonGhi(False)
        LockData(True)
        grdDanhsachto.Enabled = True
        grdTo.AllowUserToAddRows = False
        Me.grdTo.Columns("TEN_TO").ReadOnly = True
        If (Commons.Modules.sPrivate = "SHISEIDO") Then
            Me.grdTo.Columns("MS_CHUOI").ReadOnly = True

        End If
        BindData()

        RemoveHandler txtTEN_TO.Validated, AddressOf Me.txtTEN_TO_Validated
        RemoveHandler cboDON_VI.SelectedValueChanged, AddressOf Me.cboDON_VI_SelectedValueChanged
        RemoveHandler txtSTT_TO.Validated, AddressOf Me.txtSTT_TO_Validated
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachto.RowHeaderMouseClick
        ShowTO(e.RowIndex)
        If Me.grdDanhsachto.Rows.Count > 0 Then
            BindData_To(e.RowIndex)
        Else
            Me.grdTo.Columns.Clear()
        End If

    End Sub
    Dim intRowTo As Integer, intRowPB As Integer
    Private Sub grddanhsachdonvido_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachto.RowEnter
        ShowTO(e.RowIndex)
        If Me.grdDanhsachto.Rows.Count > 0 Then
            BindData_To(e.RowIndex)
        Else
            Me.grdTo.Columns.Clear()
        End If
        intRowPB = e.RowIndex
    End Sub

    Private Sub txtTEN_TO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtTEN_TO.Validated
        txtTEN_TO.Text = Trim(txtTEN_TO.Text)

        If txtTEN_TO.Text = "" And Not BtnKhongghi.Focused Then
            ' Tên tổ không được rỗng ! Vui lòng nhập tên tổ !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage),
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtTEN_TO.Focus()
            'Exit Sub
        Else
            Dim SQL_TMP As String = "SELECT * FROM TO_PHONG_BAN WHERE MS_DON_VI = '" & cboDON_VI.SelectedValue.ToString.Replace("'", "''") & "' and TEN_TO = '" & txtTEN_TO.Text.Replace("'", "''") & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                If blnThem Then
                    If Not BtnKhongghi.Focused And Not cboDON_VI.Focused Then
                        ' Tên tổ này đã tồn tại trong đơn vị, Vui lòng nhập tên khác !
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        txtTEN_TO.Focus()
                        dtReader.Close()
                        Exit While
                    Else
                        Exit While
                    End If
                Else
                    If txtTEN_TO.Text.ToUpper <> Ten_To_tmp.ToUpper And Not BtnKhongghi.Focused And Not cboDON_VI.Focused Then
                        ' Tên tổ này đã tồn tại trong đơn vị, Vui lòng nhập tên khác !
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        txtTEN_TO.Focus()
                        dtReader.Close()
                        Exit While
                    Else
                        Exit While
                    End If
                End If
            End While
        End If
    End Sub

    Private Sub cboDON_VI_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboDON_VI.SelectedValueChanged
        'Refesh()
        Dim SQL_TMP As String = "SELECT * FROM TO_PHONG_BAN WHERE MS_DON_VI = '" & cboDON_VI.SelectedValue.ToString & "' and TEN_TO = '" & txtTEN_TO.Text & "'"
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            If blnThem Then
                If Not BtnKhongghi.Focused Then
                    ' Tên tổ này đã tồn tại trong đơn vị, Vui lòng nhập tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTEN_TO.Focus()
                    dtReader.Close()
                    Exit While
                Else
                    Exit While
                End If
            Else
                If txtTEN_TO.Text <> Ten_To_tmp And Not BtnKhongghi.Focused Then
                    ' Tên tổ này đã tồn tại trong đơn vị, Vui lòng nhập tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTEN_TO.Focus()
                    dtReader.Close()
                    Exit While
                Else
                    Exit While
                End If
            End If
        End While
    End Sub

    Private Sub txtSTT_TO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtSTT_TO.Validated
        txtSTT_TO.Text = Trim(txtSTT_TO.Text)
        If txtSTT_TO.Text <> "" And Not IsNumeric(txtSTT_TO.Text) And Not BtnKhongghi.Focused Then
            ' Số thứ tự phải là kiểu số ! Vui lòng nhập lại !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKT1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtSTT_TO.Text = ""
            txtSTT_TO.Focus()
        End If
    End Sub

#End Region

#Region "Private Methods"
    Sub Refesh()
        txtSTT_TO.Text = 0
        txtTEN_TO.Text = ""
        txtTO_TRUONG.Text = ""

        Dim i As Integer = Me.grdTo.Rows.Count - 1
        While i >= 0
            If Not Me.grdTo.Rows(i).IsNewRow Then
                Me.grdTo.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub ShowTO(ByVal RowIndex As Integer)
        cboDON_VI.Text = grdDanhsachto.Rows(RowIndex).Cells("TEN_DON_VI").Value.ToString
        txtTEN_TO.Text = grdDanhsachto.Rows(RowIndex).Cells("TEN_TO").Value.ToString
        txtTO_TRUONG.Text = grdDanhsachto.Rows(RowIndex).Cells("TO_TRUONG").Value.ToString
        txtSTT_TO.Text = grdDanhsachto.Rows(RowIndex).Cells("STT_TO").Value.ToString
        txtMS_TO.Text = grdDanhsachto.Rows(RowIndex).Cells("MS_TO").Value.ToString
    End Sub

    Sub LoadcboDON_VI() 'GetDON_VI_USER

        Dim dtReader As New DataTable()
        dtReader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_USER", Commons.Modules.UserName))


        cboDON_VI.ValueMember = "MS_DON_VI"
        cboDON_VI.DisplayMember = "TEN_DON_VI"
        cboDON_VI.DataSource = dtReader

    End Sub

    'Sub BindData()
    '    Refesh()
    '    Me.grdDanhsachto.DataSource = New clsTO_PHONG_BANController().GetTO_PHONG_BANs(cboDON_VI.SelectedValue.ToString)
    '    grdDanhsachto.Columns("MS_TO").Visible = False
    '    grdDanhsachto.Columns("TEN_TO").Width = 200
    '    grdDanhsachto.Columns("TEN_DON_VI").Visible = False
    '    grdDanhsachto.Columns("STT_TO").Visible = False
    '    grdDanhsachto.Columns("TO_TRUONG").Width = 150
    '    Me.grdDanhsachto.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
    '    Me.grdDanhsachto.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
    '    If grdDanhsachto.RowCount = 0 Then
    '        BtnSua.Enabled = False
    '        BtnXoa.Enabled = False
    '        btnXoaphongban.Enabled = False
    '    Else
    '        BtnSua.Enabled = True
    '        BtnXoa.Enabled = True
    '        btnXoaphongban.Enabled = True
    '    End If
    'End Sub

    Sub BindData()
        Refesh()
        Try
            Dim s As String = cboDON_VI.SelectedValue.ToString
            Dim tb As DataTable = New DataTable()
            tb = New clsTO_PHONG_BANController().GetTO_PHONG_BANs(cboDON_VI.SelectedValue.ToString)

            Me.grdDanhsachto.DataSource = New clsTO_PHONG_BANController().GetTO_PHONG_BANs(cboDON_VI.SelectedValue.ToString)
            grdDanhsachto.Columns("MS_TO").Visible = False
            grdDanhsachto.Columns("TEN_TO").Width = 200
            grdDanhsachto.Columns("TEN_DON_VI").Visible = False
            grdDanhsachto.Columns("STT_TO").Visible = False
            grdDanhsachto.Columns("TO_TRUONG").Width = 150
            Me.grdDanhsachto.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachto.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            If grdDanhsachto.RowCount = 0 Then
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
                btnXoaphongban.Enabled = False
            Else
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
                btnXoaphongban.Enabled = True
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub BindData_To(ByVal rowindex As Integer)
        Me.grdTo.Columns.Clear()
        If grdDanhsachto.Rows.Count > 0 Then
            Dim dt As DataTable = New DataTable()
            dt = New clsTO_PHONG_BANController().Get_To(grdDanhsachto.Rows(rowindex).Cells("MS_TO").Value)
            Me.grdTo.DataSource = dt
            If (Commons.Modules.sPrivate = "SHISEIDO") Then

                Me.grdTo.Columns("MS_CHUOI").Visible = True
                Me.grdTo.Columns("MS_CHUOI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MA_TO", Commons.Modules.TypeLanguage)
            End If
            dt.Columns("MS_TO").AllowDBNull = True
            Me.grdTo.Columns("MS_TO").Visible = False

            Me.grdTo.Columns("MS_TO1").Visible = False
            Me.grdTo.Columns("TEN_TO").ReadOnly = True
            If (Commons.Modules.sPrivate = "SHISEIDO") Then
                Me.grdTo.Columns("MS_CHUOI").ReadOnly = True

            End If
            Me.grdTo.Columns("TEN_TO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_TO", Commons.Modules.TypeLanguage)
            Me.grdTo.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdTo.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Else
            grdTo.DataSource = System.DBNull.Value
        End If
        If Me.grdTo.Rows.Count = 0 Then
            btnXoato.Enabled = False
        Else
            btnXoato.Enabled = True
            Me.grdTo.Focus()
            Me.grdTo.Rows(0).Cells("TEN_TO").Selected = True
        End If
    End Sub

    Function isValidated()
        If Not cboDON_VI.IsValidated Then
            Return False
        End If
        If Not txtTEN_TO.IsValidated Then
            Return False
        End If
        If Not txtSTT_TO.IsValidated Then
            Return False
        End If
        If Not txtTO_TRUONG.IsValidated Then
            Return False
        End If
        Return True
    End Function

    Sub AddTo() ' Thêm phòng ban.
        Dim objTOInfo As New Commons.TO_PHONG_BANInfo
        Dim objTOController As New clsTO_PHONG_BANController()
        objTOInfo.MS_DON_VI = cboDON_VI.SelectedValue.ToString
        If txtSTT_TO.Text = "" Then
            objTOInfo.STT_TO = Nothing
        Else
            objTOInfo.STT_TO = CInt(txtSTT_TO.Text)
        End If
        objTOInfo.TEN_TO = txtTEN_TO.Text
        objTOInfo.TO_TRUONG = txtTO_TRUONG.Text
        Dim tmp As Integer
        If Not blnThem Then
            objTOInfo.MS_TO = txtMS_TO.Text
            tmp = objTOInfo.MS_TO
            objTOController.UpdateTO_PHONG_BAN(objTOInfo)
        Else
            tmp = objTOController.AddTO_PHONG_BAN(objTOInfo)
            Dim str As String = "SELECT GROUP_ID FROM USERS WHERE USERNAME = '" & Commons.Modules.UserName & "'"
            Dim groupID As Integer = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddNHOM_TO_PHONG_BAN", groupID, tmp)
        End If
        Add_To(tmp)
    End Sub

    Sub Add_To(ByVal MS_PHONG_BAN As Integer) ' dùng để thêm mới tổ.
        Dim i As Integer
        Dim objTophongban As New clsTO_PHONG_BANController
        If blnThem Then
            For i = 0 To grdTo.Rows.Count - 2

                If Commons.Modules.sPrivate = "SHISEIDO" Then
                    Dim SQL As String = "INSERT INTO [TO](MS_TO, TEN_TO, MS_CHUOI) VALUES ( '" & MS_PHONG_BAN & "', N'" & Me.grdTo.Rows(i).Cells("TEN_TO").Value.ToString().Trim() & "', N'" & Me.grdTo.Rows(i).Cells("MS_CHUOI").Value.ToString().Trim() & "')"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

                Else
                    objTophongban.Add_TO(MS_PHONG_BAN, Me.grdTo.Rows(i).Cells("TEN_TO").Value.ToString().Trim())
                End If
            Next
        Else
            For i = 0 To grdTo.Rows.Count - 2
                While i < rowcount
                    If Commons.Modules.sPrivate = "SHISEIDO" Then
                        Dim SQL As String = "UPDATE [TO] SET TEN_TO = N'" & Me.grdTo.Rows(i).Cells("TEN_TO").Value.ToString().Trim() & "', MS_CHUOI = N'" & Me.grdTo.Rows(i).Cells("MS_CHUOI").Value.ToString().Trim() & "'  WHERE MS_TO1 = '" & Me.grdTo.Rows(i).Cells("MS_TO1").Value & "' AND MS_TO = '" & MS_PHONG_BAN & "'"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

                    Else
                        objTophongban.Update_TO(Me.grdTo.Rows(i).Cells("MS_TO1").Value, MS_PHONG_BAN, Me.grdTo.Rows(i).Cells("TEN_TO").Value)
                    End If
                    i += 1
                    Continue While
                End While
                If i > Me.grdTo.RowCount - 2 Then Exit For
                If Commons.Modules.sPrivate = "SHISEIDO" Then
                    Dim SQL As String = "INSERT INTO [TO](MS_TO, TEN_TO, MS_CHUOI) VALUES ( '" & MS_PHONG_BAN & "', N'" & Me.grdTo.Rows(i).Cells("TEN_TO").Value.ToString().Trim() & "', N'" & Me.grdTo.Rows(i).Cells("MS_CHUOI").Value.ToString().Trim() & "')"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

                Else
                    objTophongban.Add_TO(MS_PHONG_BAN, Me.grdTo.Rows(i).Cells("TEN_TO").Value.ToString().Trim())
                End If

            Next
        End If
    End Sub

    Sub Delete_All_to(ByVal MS_PHONG_BAN As Integer)
        Dim objTophongban As New clsTO_PHONG_BANController
        objTophongban.Delete_All_TO(MS_PHONG_BAN)
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnThoat.Visible = blnVisible
    End Sub

    Sub visibleButtonXoa(ByVal blnXoa As Boolean)
        BtnXoa.Visible = Not blnXoa
        btnXoaphongban.Visible = blnXoa
        btnXoato.Visible = blnXoa
        btnTrove.Visible = blnXoa
    End Sub

    Sub visibleButtonGhi(ByVal blnGhi As Boolean)
        BtnGhi.Visible = blnGhi
        BtnKhongghi.Visible = blnGhi
    End Sub

    Sub LockData(ByVal blnLock As Boolean)
        cboDON_VI.Enabled = blnLock
        txtSTT_TO.ReadOnly = blnLock
        txtTEN_TO.ReadOnly = blnLock
        txtTO_TRUONG.ReadOnly = blnLock
    End Sub

    '' Hàm này dùng để tìm kiếm tự động khi người sử dụng nhập vào.
    'Public Sub AutoCompleteCbo(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim strFindStr As String

    '    If e.KeyChar = Chr(8) Then  'Backspace
    '        If cb.SelectionStart <= 1 Then
    '            cb.Text = ""
    '            Exit Sub
    '        End If
    '        If cb.SelectionLength = 0 Then
    '            strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
    '        Else
    '            strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
    '        End If
    '    Else
    '        If cb.SelectionLength = 0 Then
    '            strFindStr = cb.Text & e.KeyChar
    '        Else
    '            strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
    '        End If
    '    End If

    '    Dim intIdx As Integer = -1

    '    ' Search the string in the Combo Box List.
    '    intIdx = cb.FindString(strFindStr)

    '    If intIdx <> -1 Then ' String found in the List.
    '        cb.SelectedText = ""
    '        cb.SelectedIndex = intIdx
    '        cb.SelectionStart = strFindStr.Length
    '        cb.SelectionLength = cb.Text.Length
    '        e.Handled = True
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub
#End Region

    Private Sub cboDON_VI_SelectedValueChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDON_VI.SelectedValueChanged
        BindData()
    End Sub

    Private Sub btnTrove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrove.Click
        VisibleButton(True)
        visibleButtonXoa(False)
    End Sub

    Private Sub btnXoaphongban_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaphongban.Click
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa chức vụ này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa7", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            '  Kiểm tra TỔ này có đang được sử dụng trong bảng CONG_NHAN không.

            SQL_TMP = "Select * FROM [TO] WHERE MS_TO = '" & txtMS_TO.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While

            SQL_TMP = "SELECT * FROM USERS WHERE MS_TO = '" & txtMS_TO.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While

            ' Xóa TỔ

            Dim objTOController As New clsTO_PHONG_BANController()
            objTOController.DeleteTO_PHONG_BAN(txtMS_TO.Text)
            Refesh()
            Dim tmp As Integer = intRowPB
            BindData()
            If grdDanhsachto.Rows.Count > 0 Then
                If grdDanhsachto.Rows.Count = tmp Then
                    grdDanhsachto.CurrentCell() = grdDanhsachto.Rows(tmp - 1).Cells("TEN_TO")
                    grdDanhsachto.Focus()
                Else
                    grdDanhsachto.CurrentCell() = grdDanhsachto.Rows(tmp).Cells("TEN_TO")
                    grdDanhsachto.Focus()
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnXoato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoato.Click
        Try
            If grdTo.SelectedRows.Count <= 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChonToCanXoa", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Exit Sub
            End If


            If IsDBNull(Me.grdTo.CurrentRow.Cells("MS_TO1").Value) Then
                MessageBox.Show("Vui long chọn tổ cần xóa")
                Exit Sub
            End If
            SQL_TMP = "SELECT * FROM CONG_NHAN WHERE MS_TO = '" & Me.grdTo.CurrentRow.Cells("MS_TO1").Value & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                ' Tổ này đang được sử dụng trong Nhân viên ! Bạn không thể xóa !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa5", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()

            SQL_TMP = "SELECT * FROM EOR WHERE BAN_TO_LAP = '" & Me.grdTo.CurrentRow.Cells("MS_TO1").Value & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                ' Tổ này đang được sử dụng trong EOR ! Bạn không thể xóa !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa6", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbNo Then Exit Sub
            ' Xóa TỔ

            Dim objTOController As New clsTO_PHONG_BANController()
            objTOController.Delete_TO(Me.grdTo.CurrentRow.Cells("MS_TO1").Value)

            'Refesh()
            Dim tmp As Integer = intRowTo
            BindData_To(Me.grdDanhsachto.CurrentRow.Cells("MS_TO").RowIndex)
            If grdTo.Rows.Count > 0 Then
                If grdTo.Rows.Count = tmp Then
                    grdTo.CurrentCell() = grdTo.Rows(tmp - 1).Cells("TEN_TO")
                    grdTo.Focus()
                Else
                    grdTo.CurrentCell() = grdTo.Rows(tmp).Cells("TEN_TO")
                    grdTo.Focus()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub grdTo_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTo.RowEnter
        intRowTo = e.RowIndex
    End Sub
End Class