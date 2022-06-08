
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Public Class frmProblemCause
    Private _SourceProblem As BindingSource = New BindingSource()
    Private _SourceCause As BindingSource = New BindingSource()
    Private _SourceRemedy As BindingSource = New BindingSource()
    Private edit As Boolean = False
    Private Sub frmProblemCause_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindingData()
        FormControl(True)
        ControlReadOnly(True)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        grvRemedyList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        grvCauseList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        grvProblemList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
      

    End Sub
    Private Sub BindingData()
        Try
            Dim _sqlString As String = "Select PROBLEM_ID,PROBLEM_CODE,PROBLEM_NAME,PROBLEM_NOTE from dbo.PROBLEM_LIST order by PROBLEM_NAME"
            Dim _tbProblem As DataTable = New DataTable()
            _tbProblem.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            For Each _dtColumn As DataColumn In _tbProblem.Columns
                _dtColumn.AllowDBNull = True
                _dtColumn.ReadOnly = False
            Next
            AddHandler _tbProblem.TableNewRow, AddressOf _tbProblem_TableAddNewRow
            _SourceProblem.DataSource = _tbProblem
            _sqlString = "Select tmp1.PROBLEM_ID,tmp1.CAUSE_ID,tmp2.CAUSE_CODE,tmp2.CAUSE_NAME,tmp1.NOTES,tmp1.UU_TIEN from dbo.PROBLEM_CAUSE tmp1 inner join dbo.CAUSE_LIST tmp2 on tmp1.CAUSE_ID = tmp2.CAUSE_ID order by tmp1.UU_TIEN"
            Dim _tbCause As DataTable = New DataTable()
            _tbCause.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            For Each _dtColumn As DataColumn In _tbCause.Columns
                _dtColumn.AllowDBNull = True
            Next
            _SourceCause.DataSource = _tbCause
            _sqlString = "Select REMEDY_ID,CAUSE_ID,REMEDY_CODE,REMEDY_NAME,NOTE,UU_TIEN from dbo.REMEDY_CAUSE order by UU_TIEN"
            Dim _tbRemedy As DataTable = New DataTable()
            _tbRemedy.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            _SourceRemedy.DataSource = _tbRemedy

            grvProblemList.DataSource = _SourceProblem

            grvProblemList.Columns("PROBLEM_ID").Visible = False
            grvProblemList.Columns("PROBLEM_NOTE").Visible = False
            grvProblemList.Columns("PROBLEM_CODE").MinimumWidth = 120
            grvProblemList.Columns("PROBLEM_NAME").MinimumWidth = 150

            grvProblemList.Columns("PROBLEM_NAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            txtProblemCode.DataBindings.Add("Text", _SourceProblem, "PROBLEM_CODE")
            txtProblemName.DataBindings.Add("Text", _SourceProblem, "PROBLEM_NAME")
            txtNote.DataBindings.Add("Text", _SourceProblem, "PROBLEM_NOTE")
            If grvProblemList.CurrentRow Is Nothing Then
                _SourceCause.Filter = "PROBLEM_ID IS NULL"
            Else
                _SourceCause.Filter = "PROBLEM_ID ='" + grvProblemList.CurrentRow.Cells("PROBLEM_ID").Value.ToString() + "'"
            End If
            grvCauseList.DataSource = _SourceCause
            grvCauseList.Columns("PROBLEM_ID").Visible = False
            grvCauseList.Columns("CAUSE_ID").Visible = False
            grvCauseList.Columns("CAUSE_CODE").MinimumWidth = 150
            grvCauseList.Columns("CAUSE_NAME").MinimumWidth = 200
            grvCauseList.Columns("NOTES").MinimumWidth = 180
            grvCauseList.Columns("UU_TIEN").MinimumWidth = 50
            grvCauseList.Columns("NOTES").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            grvCauseList.Columns("CAUSE_CODE").ReadOnly = True
            grvCauseList.Columns("CAUSE_NAME").ReadOnly = True
            grvCauseList.Columns("NOTES").ReadOnly = True
            grvCauseList.Columns("UU_TIEN").ReadOnly = False
            grvCauseList.ReadOnly = False
            If grvCauseList.CurrentRow Is Nothing Then
                _SourceRemedy.Filter = "CAUSE_ID IS NULL"
            Else
                _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
            End If
            grvRemedyList.DataSource = _SourceRemedy
            grvRemedyList.Columns("REMEDY_ID").Visible = False
            grvRemedyList.Columns("CAUSE_ID").Visible = False
            grvRemedyList.Columns("REMEDY_CODE").MinimumWidth = 150
            grvRemedyList.Columns("REMEDY_NAME").MinimumWidth = 250
            grvRemedyList.Columns("NOTE").MinimumWidth = 180
            grvRemedyList.Columns("UU_TIEN").MinimumWidth = 50
            grvRemedyList.Columns("NOTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
            _SourceProblem = Nothing
            _SourceCause = Nothing
            _SourceRemedy = Nothing
        End Try
    End Sub
    Private Sub _tbProblem_TableAddNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs)
        e.Row("PROBLEM_ID") = Vietsoft.Information.GetID("PL")
    End Sub
    Private Sub FormControl(ByVal _flag As Boolean)
        If (_SourceProblem Is Nothing) Then
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False
            btnSave.Visible = False
            btnCancel.Visible = False
            btnChoice.Visible = False
            btnExit.Visible = True
        Else
            If (_SourceProblem.Count > 0) Then
                btnAdd.Visible = _flag
                btnEdit.Visible = _flag
                btnDelete.Visible = _flag
                btnSave.Visible = Not _flag
                btnCancel.Visible = Not _flag
                btnChoice.Visible = Not _flag
                btnExit.Visible = _flag
            Else
                btnAdd.Visible = _flag
                btnEdit.Visible = False
                btnDelete.Visible = False
                btnSave.Visible = Not _flag
                btnCancel.Visible = Not _flag
                btnChoice.Visible = Not _flag
                btnExit.Visible = _flag
            End If
        End If
    End Sub
    Private Sub ControlReadOnly(ByVal _flag As Boolean)
        txtProblemCode.ReadOnly = _flag
        txtProblemName.ReadOnly = _flag
        txtNote.ReadOnly = _flag
        grvProblemList.Enabled = _flag
        grvCauseList.ReadOnly = _flag
        grvCauseList.Columns("CAUSE_CODE").ReadOnly = Not _flag
        grvCauseList.Columns("CAUSE_NAME").ReadOnly = Not _flag
        grvCauseList.AllowUserToDeleteRows = _flag
    End Sub
    Private Sub grvProblemList_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvProblemList.RowEnter
        If e.RowIndex < 0 Then
            _SourceCause.Filter = "PROBLEM_ID IS NULL"
        Else
            _SourceCause.Filter = "PROBLEM_ID ='" + grvProblemList.Rows(e.RowIndex).Cells("PROBLEM_ID").Value.ToString() + "'"
        End If

        If grvCauseList.CurrentRow Is Nothing Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub grvCauseList_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grvCauseList.UserDeletingRow
        If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgAskDeleteCause", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Vietsoft Ecomaint") = MsgBoxResult.Yes) Then
            Try
                Dim sqlString As String = "Select count (*) from dbo.PHIEU_BAO_TRI_CLASS where PROBLEM_ID = N'" + e.Row.Cells("PROBLEM_ID").Value.ToString() + "' and CAUSE_ID = N'" + e.Row.Cells("CAUSE_ID").Value.ToString() + "'"
                Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
                If (Not _count Is Nothing) Then
                    If (CType(_count, Integer) > 0) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCauseExistInPBTC", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                        _SourceCause.CancelEdit()
                        e.Cancel = True
                        Return
                    End If
                End If
                sqlString = "Delete dbo.PROBLEM_CAUSE where PROBLEM_ID = N'" + e.Row.Cells("PROBLEM_ID").Value.ToString() + "' and CAUSE_ID = N'" + e.Row.Cells("CAUSE_ID").Value.ToString() + "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorDeleteCause", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                _SourceCause.CancelEdit()
                e.Cancel = True
            End Try
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub grvCauseList_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grvCauseList.UserDeletedRow
        _SourceCause.EndEdit()
        CType(_SourceCause.DataSource, DataTable).AcceptChanges()
        If grvCauseList.CurrentRow Is Nothing Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        _SourceProblem.AddNew()
        FormControl(False)
        ControlReadOnly(False)
        edit = True
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim tb As DataTable = CType(_SourceCause.DataSource, DataTable)
        FormControl(False)
        ControlReadOnly(False)
        edit = True
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgAskBeforeDeleteProblem", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Vietsoft Ecomaint") = MsgBoxResult.Yes) Then
            Dim _cnn As SqlConnection = New SqlConnection()
            _cnn.ConnectionString = Commons.IConnections.ConnectionString
            If (_cnn.State = ConnectionState.Closed) Then
                _cnn.Open()
            End If
            Dim _sqlTran As SqlTransaction = _cnn.BeginTransaction()
            Dim _sqlString As String = String.Empty
            Try
                _SourceCause.MoveFirst()
                Dim i As Integer = 0
                While (i < _SourceCause.Count)
                    _sqlString = "Select count (*) from dbo.PHIEU_BAO_TRI_CLASS where PROBLEM_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("PROBLEM_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                    Dim _countremedy As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
                    If (Not _countremedy Is Nothing) Then
                        If (CType(_countremedy, Integer) > 0) Then
                            _sqlTran.Rollback()
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCauseExistInPBTC", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                            _SourceCause.CancelEdit()
                            CType(_SourceCause.DataSource, DataTable).RejectChanges()
                            _SourceProblem.CancelEdit()
                            Return
                        End If
                    End If
                    _sqlString = "Delete dbo.PROBLEM_CAUSE where PROBLEM_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("PROBLEM_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    _SourceCause.RemoveCurrent()
                End While
                _sqlString = "Delete dbo.PROBLEM_LIST where PROBLEM_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'"
                SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                _SourceProblem.RemoveCurrent()
                _sqlTran.Commit()
                _SourceCause.EndEdit()
                CType(_SourceCause.DataSource, DataTable).AcceptChanges()
                _SourceProblem.EndEdit()
                If grvProblemList.CurrentRow Is Nothing Then
                    _SourceCause.Filter = "PROBLEM_ID IS NULL"
                Else
                    _SourceCause.Filter = "PROBLEM_ID ='" + grvProblemList.CurrentRow.Cells("PROBLEM_ID").Value.ToString() + "'"
                End If
                If grvCauseList.CurrentRow Is Nothing Then
                    _SourceRemedy.Filter = "CAUSE_ID IS NULL"
                Else
                    _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
                End If
                If grvProblemList.CurrentRow Is Nothing Then
                    _SourceCause.Filter = "PROBLEM_ID IS NULL"
                Else
                    _SourceCause.Filter = "PROBLEM_ID ='" + grvProblemList.CurrentRow.Cells("PROBLEM_ID").Value.ToString() + "'"
                End If
                If grvCauseList.CurrentRow Is Nothing Then
                    _SourceRemedy.Filter = "CAUSE_ID IS NULL"
                Else
                    _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
                End If
                FormControl(True)
                ControlReadOnly(True)
            Catch ex As Exception
                _sqlTran.Rollback()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorDeleteProblem", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                _SourceCause.CancelEdit()
                CType(_SourceCause.DataSource, DataTable).RejectChanges()
                _SourceProblem.CancelEdit()
            End Try
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Validate()
        If (txtProblemCode.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgInputProblemCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
            txtProblemCode.Focus()
            Return
        End If
        If (txtProblemName.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgInputProblemName", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
            txtProblemName.Focus()
            Return
        End If
        Dim _sqlString As String = "Select count (*) from dbo.PROBLEM_LIST where PROBLEM_ID <> N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "' and PROBLEM_CODE = '" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_CODE").ToString() + "'"
        Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString)
        If (Not _count Is Nothing) Then
            If (CType(_count, Integer) > 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgProblemCodeIsExist", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                txtProblemCode.Focus()
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
            _sqlString = "Select count (*) from dbo.PROBLEM_LIST where PROBLEM_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'"
            Dim _countcause As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
            If (Not _countcause Is Nothing) Then
                If (CType(_countcause, Integer) > 0) Then
                    _sqlString = "Update dbo.PROBLEM_LIST set PROBLEM_CODE = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_CODE").ToString() + "',PROBLEM_NAME = N'" & _
                    CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_NAME").ToString() + "',PROBLEM_NOTE = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_NOTE").ToString() + "' where PROBLEM_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                Else
                    _sqlString = "Insert into dbo.PROBLEM_LIST (PROBLEM_ID,PROBLEM_CODE,PROBLEM_NAME,PROBLEM_NOTE) VALUES (" & _
                    "N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "',N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_CODE").ToString() + "'," & _
                    "N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_NAME").ToString() + "',N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_NOTE").ToString() + "')"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                End If
            Else
                _sqlString = "Insert into dbo.PROBLEM_LIST (PROBLEM_ID,PROBLEM_CODE,PROBLEM_NAME,PROBLEM_NOTE) VALUES (" & _
                    "N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "',N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_CODE").ToString() + "'," & _
                    "N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_NAME").ToString() + "',N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_NOTE").ToString() + "')"
                SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
            End If
            _SourceCause.MoveFirst()
            Dim i As Integer = 0
            While (i < _SourceCause.Count)

                If (CType(_SourceCause.Current, DataRowView).Row.IsNull("UU_TIEN") Or CType(_SourceCause.Current, DataRowView).Row.IsNull("UU_TIEN").ToString().Trim().Equals(String.Empty)) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgInputUUTIEN", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                    _sqlTran.Rollback()
                    Return
                End If

                _sqlString = "Select count (*) from dbo.PROBLEM_CAUSE where PROBLEM_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("PROBLEM_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                Dim _countremedy As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)

                If (Not _countremedy Is Nothing) Then
                    If (CType(_countremedy, Integer) > 0) Then
                        _sqlString = "Update dbo.PROBLEM_CAUSE set NOTES= N'" + CType(_SourceCause.Current, DataRowView).Row("NOTES").ToString() + "'" & _
                        ",UU_TIEN='" + CType(_SourceCause.Current, DataRowView).Row("UU_TIEN").ToString() + "' where PROBLEM_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("PROBLEM_ID").ToString() + "' and CAUSE_ID = N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'"
                        SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    Else
                        _sqlString = "Insert into dbo.PROBLEM_CAUSE (PROBLEM_ID,CAUSE_ID,NOTES,UU_TIEN) VALUES (" & _
                        "N'" + CType(_SourceCause.Current, DataRowView).Row("PROBLEM_ID").ToString() + "',N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'" & _
                        ",N'" + CType(_SourceCause.Current, DataRowView).Row("NOTES").ToString() + "','" + CType(_SourceCause.Current, DataRowView).Row("UU_TIEN").ToString() + "')"
                        SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    End If
                Else
                    _sqlString = "Insert into dbo.PROBLEM_CAUSE (PROBLEM_ID,CAUSE_ID,NOTES) VALUES (" & _
                       "N'" + CType(_SourceCause.Current, DataRowView).Row("PROBLEM_ID").ToString() + "',N'" + CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID").ToString() + "'" & _
                       ",N'" + CType(_SourceCause.Current, DataRowView).Row("NOTES").ToString() + "','" + CType(_SourceCause.Current, DataRowView).Row("UU_TIEN").ToString() + "')"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                End If
                _SourceCause.MoveNext()
                i = i + 1
            End While
            _sqlTran.Commit()
            _SourceCause.EndEdit()
            CType(_SourceCause.DataSource, DataTable).AcceptChanges()
            _SourceProblem.EndEdit()
            FormControl(True)
            ControlReadOnly(True)
            edit = False
        Catch ex As Exception
            _sqlTran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorUpdateProblem", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _SourceCause.CancelEdit()
        CType(_SourceCause.DataSource, DataTable).RejectChanges()
        _SourceProblem.CancelEdit()
        If grvProblemList.CurrentRow Is Nothing Then
            _SourceCause.Filter = "PROBLEM_ID IS NULL"
        Else
            _SourceCause.Filter = "PROBLEM_ID ='" + grvProblemList.CurrentRow.Cells("PROBLEM_ID").Value.ToString() + "'"
        End If
        If grvCauseList.CurrentRow Is Nothing Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
        End If
        FormControl(True)
        ControlReadOnly(True)
        edit = False
    End Sub
    Private Sub grvCauseList_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvCauseList.RowEnter
        If e.RowIndex < 0 Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.Rows(e.RowIndex).Cells("CAUSE_ID").Value.ToString() + "'"
        End If
    End Sub
    Private Sub btnChoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoice.Click
        Dim _sqlString As String = "Select Convert(bit,0) as CHOICE,CAUSE_ID,CAUSE_CODE,CAUSE_NAME,CAUSE_NOTE from CAUSE_LIST"
        Dim _tbSource As DataTable = New DataTable()
        _tbSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
        Dim i As Integer = 0
        While (i < _tbSource.Rows.Count)
            For j As Integer = 0 To _SourceCause.Count - 1
                If (_tbSource.Rows(i)("CAUSE_ID").Equals(CType(_SourceCause.List(j), DataRowView).Row("CAUSE_ID"))) Then
                    _tbSource.Rows.RemoveAt(i)
                    i = i - 1
                    j = _SourceCause.Count
                End If
            Next
            i = i + 1
        End While

        For Each _dtcolumn As DataColumn In _tbSource.Columns
            If (_dtcolumn.ColumnName.Equals("CHOICE")) Then
                _dtcolumn.ReadOnly = False
            Else
                _dtcolumn.ReadOnly = True
            End If
        Next
        Dim _frmchoice As frmChoice = New frmChoice()
        _frmchoice.Name = "frmChoiceCause"
        _frmchoice.grvSource.DataSource = _tbSource
        _frmchoice.grvSource.Columns("CHOICE").Width = 80
        _frmchoice.grvSource.Columns("CAUSE_ID").Visible = False
        _frmchoice.grvSource.Columns("CAUSE_CODE").MinimumWidth = 120
        _frmchoice.grvSource.Columns("CAUSE_NAME").MinimumWidth = 120
        _frmchoice.grvSource.Columns("CAUSE_NOTE").MinimumWidth = 180
        _frmchoice.grvSource.Columns("CAUSE_NOTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If (_frmchoice.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            _frmchoice.Validate()
            _tbSource.DefaultView.RowFilter = "CHOICE = 1"
            Dim _tbselect As DataTable = New DataTable
            _tbselect = _tbSource.DefaultView.ToTable()
            For Each _dtrow As DataRow In _tbselect.Rows
                _SourceCause.AddNew()
                CType(_SourceCause.Current, DataRowView).Row("PROBLEM_ID") = CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID")
                CType(_SourceCause.Current, DataRowView).Row("CAUSE_ID") = _dtrow("CAUSE_ID")
                CType(_SourceCause.Current, DataRowView).Row("CAUSE_CODE") = _dtrow("CAUSE_CODE")
                CType(_SourceCause.Current, DataRowView).Row("CAUSE_NAME") = _dtrow("CAUSE_NAME")
            Next
        End If
        If grvCauseList.CurrentRow Is Nothing Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
        End If
    End Sub

  
    Private Sub grvCauseList_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grvCauseList.CellValidating
        If edit = True Then
            Exit Sub
        End If
        Try
            If e.ColumnIndex = 5 Then
                Convert.ToInt32(e.FormattedValue)
            End If

        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub
End Class