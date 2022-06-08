
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmCauseRemedy    
    Private _SourceCause As BindingSource = New BindingSource()
    Private _SourceRemedy As BindingSource = New BindingSource()
    Private edit As Boolean = False
    Private Sub frmCauseRemedy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindingData()
        FormControl(True)
        ControlReadOnly(True)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        grvRemdyList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        grvCauseList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub
    Private Sub BindingData()
        Try
            Dim _sqlString As String = "Select CAUSE_ID,CAUSE_CODE,CAUSE_NAME,CAUSE_NOTE from dbo.CAUSE_LIST order by CAUSE_NAME"
            Dim _tbCause As DataTable = New DataTable()
            _tbCause.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            For Each _dtColumn As DataColumn In _tbCause.Columns
                _dtColumn.AllowDBNull = True
            Next
            AddHandler _tbCause.TableNewRow, AddressOf _tbCause_TableAddNewRow
            _SourceCause.DataSource = _tbCause
            _sqlString = "Select CAUSE_ID,REMEDY_ID,REMEDY_CODE,REMEDY_NAME,LINK,NOTE,UU_TIEN from dbo.REMEDY_CAUSE order by UU_TIEN"
            Dim _tbRemedy As DataTable = New DataTable()
         
            _tbRemedy.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            For Each _dtColumn As DataColumn In _tbRemedy.Columns
                _dtColumn.AllowDBNull = True
            Next
            AddHandler _tbRemedy.TableNewRow, AddressOf _tbRemedy_TableAddNewRow
            _SourceRemedy.DataSource = _tbRemedy
            grvCauseList.DataSource = _SourceCause




            grvCauseList.Columns("CAUSE_ID").Visible = False
            grvCauseList.Columns("CAUSE_NOTE").Visible = False
            grvCauseList.Columns("CAUSE_CODE").MinimumWidth = 120
            grvCauseList.Columns("CAUSE_NAME").MinimumWidth = 150
            grvCauseList.Columns("CAUSE_NAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            txtCauseCode.DataBindings.Add("Text", _SourceCause, "CAUSE_CODE")
            txtCauseName.DataBindings.Add("Text", _SourceCause, "CAUSE_NAME")
            txtNote.DataBindings.Add("Text", _SourceCause, "CAUSE_NOTE")


            If grvCauseList.CurrentRow Is Nothing Then
                _SourceRemedy.Filter = "CAUSE_ID IS NULL"
            Else
                _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
            End If

            grvRemdyList.DataSource = _SourceRemedy
            grvRemdyList.Columns("CAUSE_ID").Visible = False
            grvRemdyList.Columns("REMEDY_ID").Visible = False
            grvRemdyList.Columns("REMEDY_CODE").MinimumWidth = 180
            grvRemdyList.Columns("REMEDY_NAME").MinimumWidth = 250
            grvRemdyList.Columns("LINK").MinimumWidth = 200
            grvRemdyList.Columns("NOTE").MinimumWidth = 220
            grvRemdyList.Columns("UU_TIEN").MinimumWidth = 50

            grvRemdyList.Columns("NOTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
            _SourceCause = Nothing
            _SourceRemedy = Nothing
        End Try

    End Sub
    Private Sub _tbCause_TableAddNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs)
        e.Row("CAUSE_ID") = Vietsoft.Information.GetID("CA")
    End Sub
    Private Sub _tbRemedy_TableAddNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs)
        e.Row("REMEDY_ID") = Vietsoft.Information.GetID("RD")
        e.Row("CAUSE_ID") = grvCauseList.CurrentRow.Cells("CAUSE_ID").Value
    End Sub
    Private Sub FormControl(ByVal _flag As Boolean)
        If (_SourceCause Is Nothing) Then
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False
            btnSave.Visible = False
            btnCancel.Visible = False
            btnExit.Visible = True
        Else
            If (_SourceCause.Count > 0) Then
                btnAdd.Visible = _flag
                btnEdit.Visible = _flag
                btnDelete.Visible = _flag
                btnSave.Visible = Not _flag
                btnCancel.Visible = Not _flag
                btnExit.Visible = _flag
            Else
                btnAdd.Visible = _flag
                btnEdit.Visible = False
                btnDelete.Visible = False
                btnSave.Visible = Not _flag
                btnCancel.Visible = Not _flag
                btnExit.Visible = _flag
            End If
        End If
    End Sub
    Private Sub ControlReadOnly(ByVal _flag As Boolean)
        txtCauseCode.ReadOnly = _flag
        txtCauseName.ReadOnly = _flag
        txtNote.ReadOnly = _flag
        grvCauseList.Enabled = _flag
        grvRemdyList.ReadOnly = _flag
        If (Not _flag) Then
            grvRemdyList.Columns("LINK").ReadOnly = True
        End If
        grvRemdyList.AllowUserToAddRows = Not _flag
        grvRemdyList.AllowUserToDeleteRows = _flag
    End Sub
    Private Sub grvCauseList_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvCauseList.RowEnter
        If e.RowIndex < 0 Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.Rows(e.RowIndex).Cells("CAUSE_ID").Value.ToString() + "'"
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub grvRemdyList_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grvRemdyList.UserDeletingRow
        If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgAskDeleteRemedy", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Vietsoft Ecomaint") = MsgBoxResult.Yes) Then
            Try
                Dim sqlString As String = "Select count (*) from dbo.PHIEU_BAO_TRI_CLASS where REMEDY_ID = N'" + e.Row.Cells("REMEDY_ID").Value.ToString() + "' and CAUSE_ID = N'" + e.Row.Cells("CAUSE_ID").Value.ToString() + "'"
                Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
                If (Not _count Is Nothing) Then
                    If (CType(_count, Integer) > 0) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgRemedyExistInPBTC", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                        _SourceRemedy.CancelEdit()
                        CType(_SourceRemedy.DataSource, DataTable).RejectChanges()
                        e.Cancel = True
                        Return
                    End If
                End If
                sqlString = "Delete dbo.REMEDY_CAUSE where REMEDY_ID = N'" + e.Row.Cells("REMEDY_ID").Value.ToString() + "' and CAUSE_ID = N'" + e.Row.Cells("CAUSE_ID").Value.ToString() + "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgErrorDeleteRemedy", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                _SourceRemedy.CancelEdit()
                CType(_SourceRemedy.DataSource, DataTable).RejectChanges()
                e.Cancel = True
            End Try
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub grvRemdyList_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grvRemdyList.UserDeletedRow
        _SourceRemedy.EndEdit()
        CType(_SourceRemedy.DataSource, DataTable).AcceptChanges()
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        _SourceCause.AddNew()
        FormControl(False)
        ControlReadOnly(False)
        edit = True
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        FormControl(False)
        ControlReadOnly(False)
        edit = True
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgAskBeforeDeleteCause", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Vietsoft Ecomaint") = MsgBoxResult.Yes) Then
            Dim _cnn As SqlConnection = New SqlConnection()
            _cnn.ConnectionString = Commons.IConnections.ConnectionString
            If (_cnn.State = ConnectionState.Closed) Then
                _cnn.Open()
            End If
            Dim _sqlTran As SqlTransaction = _cnn.BeginTransaction()
            Dim _sqlString As String = String.Empty
            Try
                _SourceRemedy.MoveFirst()
                Dim i As Integer = 0
                While (i < _SourceRemedy.Count)
                    _sqlString = "Select count (*) from dbo.PHIEU_BAO_TRI_CLASS where REMEDY_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                    Dim _countremedy As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
                    If (Not _countremedy Is Nothing) Then
                        If (CType(_countremedy, Integer) > 0) Then
                            _sqlTran.Rollback()
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgRemedyExistInPBTC", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                            CType(_SourceRemedy.DataSource, DataTable).RejectChanges()
                            _SourceCause.CancelEdit()
                            Return
                        End If
                    End If
                    _sqlString = "Delete dbo.REMEDY_CAUSE where REMEDY_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    _SourceRemedy.RemoveCurrent()
                End While
                _sqlString = "Delete dbo.CAUSE_LIST where CAUSE_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                _SourceCause.RemoveCurrent()
                _sqlTran.Commit()
                CType(_SourceRemedy.DataSource, DataTable).AcceptChanges()
                _SourceCause.EndEdit()
                If grvCauseList.CurrentRow Is Nothing Then
                    _SourceRemedy.Filter = "CAUSE_ID IS NULL"
                Else
                    _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
                End If
                FormControl(True)
                ControlReadOnly(True)
            Catch ex As Exception
                _sqlTran.Rollback()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgErrorDeleteCause", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                CType(_SourceRemedy.DataSource, DataTable).RejectChanges()
                _SourceCause.CancelEdit()
            End Try
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Validate()
        If (txtCauseCode.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgInputCauseCode", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
            txtCauseCode.Focus()
            Return
        End If
        If (txtCauseName.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgInputCauseName", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
            txtCauseName.Focus()
            Return
        End If
        Dim _sqlString As String = "Select count (*) from dbo.CAUSE_LIST where CAUSE_ID <> N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "' and CAUSE_CODE = '" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_CODE").ToString() + "'"
        Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString)
        If (Not _count Is Nothing) Then
            If (CType(_count, Integer) > 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCauseCodeIsExist", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                txtCauseCode.Focus()
                Return
            End If
        End If
        Dim _cnn As SqlConnection = New SqlConnection()
        _cnn.ConnectionString = Commons.IConnections.ConnectionString
        If (_cnn.State = ConnectionState.Closed) Then
            _cnn.Open()
        End If
        Dim _sqlTran As SqlTransaction = _cnn.BeginTransaction()
        Try
            _sqlString = "Select count (*) from dbo.CAUSE_LIST where CAUSE_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
            Dim _countcause As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
            If (Not _countcause Is Nothing) Then
                If (CType(_countcause, Integer) > 0) Then
                    _sqlString = "Update dbo.CAUSE_LIST set CAUSE_CODE = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_CODE").ToString() + "',CAUSE_NAME = N'" & _
                    CType(_SourceCause.Current, DataRowView).Row("CAUSE_NAME").ToString() + "',CAUSE_NOTE = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_NOTE").ToString() + "' where CAUSE_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                Else
                    _sqlString = "Insert into dbo.CAUSE_LIST (CAUSE_ID,CAUSE_CODE,CAUSE_NAME,CAUSE_NOTE) VALUES (" & _
                    "N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "',N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_CODE").ToString() + "'," & _
                    "N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_NAME").ToString() + "',N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_NOTE").ToString() + "')"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                End If
            Else
                _sqlString = "Insert into dbo.CAUSE_LIST (CAUSE_ID,CAUSE_CODE,CAUSE_NAME,CAUSE_NOTE) VALUES (" & _
                    "N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "',N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_CODE").ToString() + "'," & _
                    "N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_NAME").ToString() + "',N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_NOTE").ToString() + "')"
                SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
            End If
            _SourceRemedy.MoveFirst()
            Dim i As Integer = 0
            While (i < _SourceRemedy.Count)
                If (CType(_SourceRemedy.Current, DataRowView).Row.IsNull("REMEDY_CODE") Or CType(_SourceRemedy.Current, DataRowView).Row.IsNull("REMEDY_CODE").ToString().Trim().Equals(String.Empty)) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgInputRemedyCode", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                    _sqlTran.Rollback()

                    Return
                End If
                If (CType(_SourceRemedy.Current, DataRowView).Row.IsNull("REMEDY_NAME") Or CType(_SourceRemedy.Current, DataRowView).Row.IsNull("REMEDY_NAME").ToString().Trim().Equals(String.Empty)) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgInputRemedyName", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                    _sqlTran.Rollback()
                    Return
                End If
                If (CType(_SourceRemedy.Current, DataRowView).Row.IsNull("UU_TIEN") Or CType(_SourceRemedy.Current, DataRowView).Row.IsNull("UU_TIEN").ToString().Trim().Equals(String.Empty)) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgInputUUTIEN", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                    _sqlTran.Rollback()
                    Return
                End If
                _sqlString = "Select count (*) from dbo.REMEDY_CAUSE where REMEDY_ID + CAUSE_ID <> N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_ID").ToString() + CType(_SourceRemedy.Current, DataRowView).Row("CAUSE_ID").ToString() + "' and REMEDY_CODE = N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_CODE").ToString() + "'"
                Dim _counts As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
                If (Not _counts Is Nothing) Then
                    If (CType(_counts, Integer) > 0) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgRemedyCodeIsExist", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                        _sqlTran.Rollback()
                        Return
                    End If
                End If
                _sqlString = "Select count (*) from dbo.REMEDY_CAUSE where REMEDY_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                Dim _countremedy As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
                If (Not _countremedy Is Nothing) Then
                    If (CType(_countremedy, Integer) > 0) Then
                        _sqlString = "Update dbo.REMEDY_CAUSE set REMEDY_CODE = N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_CODE").ToString() + "',REMEDY_NAME = N'" & _
                        CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_NAME").ToString() + "',LINK = N'" + CType(_SourceRemedy.Current, DataRowView).Row("LINK").ToString() + "',NOTE = N'" + CType(_SourceRemedy.Current, DataRowView).Row("NOTE").ToString() + "'" & _
                        ", UU_TIEN ='" + CType(_SourceRemedy.Current, DataRowView).Row("UU_TIEN").ToString() + "' where REMEDY_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceRemedy.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                        SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    Else
                        _sqlString = "Insert into dbo.REMEDY_CAUSE (REMEDY_ID,CAUSE_ID,REMEDY_CODE,REMEDY_NAME,LINK,NOTE,UU_TIEN) VALUES (" & _
                        "N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_ID").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("CAUSE_ID").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_CODE").ToString() + "'," & _
                        "N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_NAME").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("LINK").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("NOTE").ToString() + "', '" + CType(_SourceRemedy.Current, DataRowView).Row("UU_TIEN").ToString() + "')"
                        SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    End If
                Else
                    _sqlString = "Insert into dbo.REMEDY_CAUSE (REMEDY_ID,CAUSE_ID,REMEDY_CODE,REMEDY_NAME,LINK,NOTE,UU_TIEN) VALUES (" & _
                        "N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_ID").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("CAUSE_ID").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_CODE").ToString() + "'," & _
                        "N'" + CType(_SourceRemedy.Current, DataRowView).Row("REMEDY_NAME").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("LINK").ToString() + "',N'" + CType(_SourceRemedy.Current, DataRowView).Row("NOTE").ToString() + "','" + CType(_SourceRemedy.Current, DataRowView).Row("UU_TIEN").ToString() + "')"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                End If
                _SourceRemedy.MoveNext()
                i = i + 1
            End While
            _sqlTran.Commit()
            CType(_SourceRemedy.DataSource, DataTable).AcceptChanges()
            _SourceCause.EndEdit()
            FormControl(True)
            ControlReadOnly(True)
            edit = False
        Catch ex As Exception
            _sqlTran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgErrorUpdateCause", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CType(_SourceRemedy.DataSource, DataTable).RejectChanges()
        _SourceCause.CancelEdit()
        If grvCauseList.CurrentRow Is Nothing Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
        End If
        FormControl(True)
        ControlReadOnly(True)
        edit = False
    End Sub
    Private Sub grvRemdyList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvRemdyList.CellDoubleClick
        If (grvRemdyList.Columns(e.ColumnIndex).Name.Equals("LINK")) Then
            If (Not grvRemdyList.CurrentRow.Cells("REMEDY_ID").Value.ToString().Equals(String.Empty)) Then
                If btnSave.Enabled Then
                    Dim dialogfileopen As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
                    If (dialogfileopen.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                        Dim strDuongDan As String = dialogfileopen.FileName
                        Dim strDuongDanTmp As String = commons.Modules.ObjSystems.CapnhatTL(True, grvRemdyList.CurrentRow.Cells("REMEDY_ID").Value.ToString())
                        grvRemdyList.CurrentRow.Cells("LINK").Value = strDuongDanTmp & "\" + grvRemdyList.CurrentRow.Cells("REMEDY_ID").Value.ToString() + commons.Modules.ObjSystems.LayDuoiFile(strDuongDan)
                        commons.Modules.ObjSystems.LuuDuongDan(dialogfileopen.FileName, grvRemdyList.CurrentRow.Cells("LINK").Value.ToString())
                        Validate()
                    End If
                Else
                    commons.Modules.ObjSystems.OpenHinh(grvRemdyList.CurrentRow.Cells("LINK").Value.ToString())
                End If
            End If
        End If
    End Sub


    Private Sub grvRemdyList_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grvRemdyList.CellValidating
        If edit = True Then
            Exit Sub
        End If
        Try
            If e.ColumnIndex = 6 Then
                Convert.ToInt32(e.FormattedValue)
            End If

        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub
End Class