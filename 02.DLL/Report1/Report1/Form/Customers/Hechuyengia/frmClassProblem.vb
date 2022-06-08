
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Public Class frmClassProblem
    Private _SourceClass As BindingSource = New BindingSource()
    Private _SourceProblem As BindingSource = New BindingSource()
    Private _SourceCause As BindingSource = New BindingSource()
    Private _SourceRemedy As BindingSource = New BindingSource()
    Private Sub frmClassProblem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindingData()
        FormControl(True)
        ControlReadOnly(True)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        grvRemedyList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        grvCauseList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        grvProblemList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
        grvClassList.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)

        If Commons.Modules.PermisString.Equals("Read only") Then
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub
    Private Sub BindingData()
        Try
            Dim _sqlString As String = "Select CLASS_ID,CLASS_CODE,CLASS_NAME,CLASS_NOTE from dbo.CLASS_LIST order by CLASS_NAME"
            Dim _tbClass As DataTable = New DataTable()
            _tbClass.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            For Each _dtColumn As DataColumn In _tbClass.Columns
                _dtColumn.AllowDBNull = True
            Next
            AddHandler _tbClass.TableNewRow, AddressOf _tbClass_TableAddNewRow
            _SourceClass.DataSource = _tbClass
            _sqlString = "Select tmp1.CLASS_ID,tmp1.PROBLEM_ID,tmp2.PROBLEM_CODE,tmp2.PROBLEM_NAME,tmp1.NOTES from dbo.CLASS_PROBLEM tmp1 inner join dbo.PROBLEM_LIST tmp2 on tmp1.PROBLEM_ID = tmp2.PROBLEM_ID order by tmp2.PROBLEM_NAME"
            Dim _tbProblem As DataTable = New DataTable()
            _tbProblem.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            For Each _dtColumn As DataColumn In _tbProblem.Columns
                _dtColumn.AllowDBNull = True
            Next
            _SourceProblem.DataSource = _tbProblem
            _sqlString = "Select tmp1.PROBLEM_ID,tmp1.CAUSE_ID,tmp2.CAUSE_CODE,tmp2.CAUSE_NAME,tmp1.NOTES,tmp1.UU_TIEN from dbo.PROBLEM_CAUSE tmp1 inner join dbo.CAUSE_LIST tmp2 on tmp1.CAUSE_ID = tmp2.CAUSE_ID order by tmp1.UU_TIEN"
            Dim _tbCause As DataTable = New DataTable()
            _tbCause.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            _SourceCause.DataSource = _tbCause

            _sqlString = "Select REMEDY_ID,CAUSE_ID,REMEDY_CODE,REMEDY_NAME,NOTE,UU_TIEN from dbo.REMEDY_CAUSE order by UU_TIEN"
            Dim _tbRemedy As DataTable = New DataTable()
            _tbRemedy.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
            _SourceRemedy.DataSource = _tbRemedy

            grvClassList.DataSource = _SourceClass
            grvClassList.Columns("CLASS_ID").Visible = False
            grvClassList.Columns("CLASS_NOTE").Visible = False
            grvClassList.Columns("CLASS_CODE").MinimumWidth = 120
            grvClassList.Columns("CLASS_NAME").MinimumWidth = 150
            grvClassList.Columns("CLASS_NAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            txtClassCode.DataBindings.Add("Text", _SourceClass, "CLASS_CODE")
            txtClassName.DataBindings.Add("Text", _SourceClass, "CLASS_NAME")
            txtClassNote.DataBindings.Add("Text", _SourceClass, "CLASS_NOTE")
            If grvClassList.CurrentRow Is Nothing Then
                _SourceProblem.Filter = "CLASS_ID IS NULL"
            Else
                _SourceProblem.Filter = "CLASS_ID ='" + grvClassList.CurrentRow.Cells("CLASS_ID").Value.ToString() + "'"
            End If
            grvProblemList.DataSource = _SourceProblem
            grvProblemList.Columns("CLASS_ID").Visible = False
            grvProblemList.Columns("PROBLEM_ID").Visible = False
            grvProblemList.Columns("PROBLEM_CODE").MinimumWidth = 180
            grvProblemList.Columns("PROBLEM_NAME").MinimumWidth = 250
            grvProblemList.Columns("NOTES").MinimumWidth = 180
            grvProblemList.Columns("NOTES").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            If grvProblemList.CurrentRow Is Nothing Then
                _SourceCause.Filter = "PROBLEM_ID IS NULL"
            Else
                _SourceCause.Filter = "PROBLEM_ID ='" + grvProblemList.CurrentRow.Cells("PROBLEM_ID").Value.ToString() + "'"
            End If
            grvCauseList.DataSource = _SourceCause
            grvCauseList.Columns("PROBLEM_ID").Visible = False
            grvCauseList.Columns("CAUSE_ID").Visible = False
            grvCauseList.Columns("CAUSE_CODE").MinimumWidth = 180
            grvCauseList.Columns("CAUSE_NAME").MinimumWidth = 250
            grvCauseList.Columns("NOTES").MinimumWidth = 180
            grvCauseList.Columns("NOTES").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            grvCauseList.Columns("UU_TIEN").MinimumWidth = 50
            If grvCauseList.CurrentRow Is Nothing Then
                _SourceRemedy.Filter = "CAUSE_ID IS NULL"
            Else
                _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString() + "'"
            End If
            grvRemedyList.DataSource = _SourceRemedy
            grvRemedyList.Columns("REMEDY_ID").Visible = False
            grvRemedyList.Columns("CAUSE_ID").Visible = False
            grvRemedyList.Columns("REMEDY_CODE").MinimumWidth = 180
            grvRemedyList.Columns("REMEDY_NAME").MinimumWidth = 250
            grvRemedyList.Columns("NOTE").MinimumWidth = 180
            grvRemedyList.Columns("NOTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            grvRemedyList.Columns("UU_TIEN").MinimumWidth = 50
        Catch ex As Exception
            _SourceClass = Nothing
            _SourceProblem = Nothing
            _SourceCause = Nothing
            _SourceRemedy = Nothing
        End Try
    End Sub
    Private Sub _tbClass_TableAddNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs)
        e.Row("CLASS_ID") = Vietsoft.Information.GetID("CL")
    End Sub
    Private Sub FormControl(ByVal _flag As Boolean)
        If (_SourceClass Is Nothing) Then
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False
            btnSave.Visible = False
            btnCancel.Visible = False
            btnChoice.Visible = False
            btnExit.Visible = True
        Else
            If (_SourceClass.Count > 0) Then
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
        txtClassCode.ReadOnly = _flag
        txtClassName.ReadOnly = _flag
        txtClassNote.ReadOnly = _flag
        grvClassList.Enabled = _flag
        grvProblemList.ReadOnly = _flag
        grvProblemList.Columns("PROBLEM_CODE").ReadOnly = Not _flag
        grvProblemList.Columns("PROBLEM_NAME").ReadOnly = Not _flag
        grvProblemList.AllowUserToDeleteRows = _flag
    End Sub
    Private Sub grvClassList_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvClassList.RowEnter
        If e.RowIndex < 0 Then
            _SourceProblem.Filter = "CLASS_ID IS NULL"
        Else
            _SourceProblem.Filter = "CLASS_ID ='" + grvClassList.Rows(e.RowIndex).Cells("CLASS_ID").Value.ToString() + "'"
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
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub grvProblemList_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grvProblemList.UserDeletingRow
        If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgAskDeleteProblem", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Vietsoft Ecomaint") = MsgBoxResult.Yes) Then
            Try
                Dim sqlString As String = "Select count (*) from dbo.PHIEU_BAO_TRI_CLASS where CLASS_ID = N'" + e.Row.Cells("CLASS_ID").Value.ToString() + "' and PROBLEM_ID = N'" + e.Row.Cells("PROBLEM_ID").Value.ToString() + "'"
                Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
                If (Not _count Is Nothing) Then
                    If (CType(_count, Integer) > 0) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgProblemExistInPBTC", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                        _SourceProblem.CancelEdit()
                        e.Cancel = True
                        Return
                    End If
                End If
                sqlString = "Delete dbo.CLASS_PROBLEM where CLASS_ID = N'" + e.Row.Cells("CLASS_ID").Value.ToString() + "' and PROBLEM_ID = N'" + e.Row.Cells("PROBLEM_ID").Value.ToString() + "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sqlString)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorDeleteProblem", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                _SourceProblem.CancelEdit()
                e.Cancel = True
            End Try
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub grvProblemList_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grvProblemList.UserDeletedRow
        _SourceProblem.EndEdit()
        CType(_SourceProblem.DataSource, DataTable).AcceptChanges()
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
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        _SourceClass.AddNew()
        FormControl(False)
        ControlReadOnly(False)
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        FormControl(False)
        ControlReadOnly(False)
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgAskBeforeDeleteClass", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, "Vietsoft Ecomaint") = MsgBoxResult.Yes) Then
            Dim _cnn As SqlConnection = New SqlConnection()
            _cnn.ConnectionString = Commons.IConnections.ConnectionString
            If (_cnn.State = ConnectionState.Closed) Then
                _cnn.Open()
            End If
            Dim _sqlTran As SqlTransaction = _cnn.BeginTransaction()
            Dim _sqlString As String = String.Empty
            Try
                _SourceProblem.MoveFirst()
                Dim i As Integer = 0
                While (i < _SourceProblem.Count)
                    _sqlString = "Select count (*) from dbo.PHIEU_BAO_TRI_CLASS where CLASS_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("CLASS_ID").ToString() + "' and PROBLEM_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'"
                    Dim _countremedy As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
                    If (Not _countremedy Is Nothing) Then
                        If (CType(_countremedy, Integer) > 0) Then
                            _sqlTran.Rollback()
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgProblemExistInPBTC", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                            _SourceProblem.CancelEdit()
                            CType(_SourceProblem.DataSource, DataTable).RejectChanges()
                            _SourceClass.CancelEdit()
                            Return
                        End If
                    End If
                    _sqlString = "Delete dbo.CLASS_PROBLEM where CLASS_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("CLASS_ID").ToString() + "' and PROBLEM_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    _SourceProblem.RemoveCurrent()
                End While
                _sqlString = "Delete dbo.CLASS_LIST where CLASS_ID = N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_ID").ToString() + "'"
                SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                _SourceClass.RemoveCurrent()
                _sqlTran.Commit()
                _SourceProblem.EndEdit()
                CType(_SourceProblem.DataSource, DataTable).AcceptChanges()
                _SourceClass.EndEdit()
                If grvClassList.CurrentRow Is Nothing Then
                    _SourceProblem.Filter = "CLASS_ID IS NULL"
                Else
                    _SourceProblem.Filter = "CLASS_ID ='" + grvClassList.CurrentRow.Cells("CLASS_ID").Value.ToString() + "'"
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
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorDeleteClass", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                _SourceProblem.CancelEdit()
                CType(_SourceProblem.DataSource, DataTable).RejectChanges()
                _SourceClass.CancelEdit()
            End Try
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Validate()
        If (txtClassCode.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgInputClassCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
            txtClassCode.Focus()
            Return
        End If
        If (txtClassName.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgInputClassName", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
            txtClassName.Focus()
            Return
        End If
        Dim _sqlString As String = "Select count (*) from dbo.CLASS_LIST where CLASS_ID <> N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_ID").ToString() + "' and CLASS_CODE = '" + CType(_SourceClass.Current, DataRowView).Row("CLASS_CODE").ToString() + "'"
        Dim _count As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString)
        If (Not _count Is Nothing) Then
            If (CType(_count, Integer) > 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgClassCodeIsExist", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
                txtClassCode.Focus()
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
            _sqlString = "Select count (*) from dbo.CLASS_LIST where CLASS_ID = N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_ID").ToString() + "'"
            Dim _countcause As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
            If (Not _countcause Is Nothing) Then
                If (CType(_countcause, Integer) > 0) Then
                    _sqlString = "Update dbo.CLASS_LIST set CLASS_CODE = N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_CODE").ToString() + "',CLASS_NAME = N'" & _
                    CType(_SourceClass.Current, DataRowView).Row("CLASS_NAME").ToString() + "',CLASS_NOTE = N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_NOTE").ToString() + "' where CLASS_ID = N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_ID").ToString() + "'"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                Else
                    _sqlString = "Insert into dbo.CLASS_LIST (CLASS_ID,CLASS_CODE,CLASS_NAME,CLASS_NOTE) VALUES (" & _
                    "N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_ID").ToString() + "',N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_CODE").ToString() + "'," & _
                    "N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_NAME").ToString() + "',N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_NOTE").ToString() + "')"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                End If
            Else
                _sqlString = "Insert into dbo.CLASS_LIST (CLASS_ID,CLASS_CODE,CLASS_NAME,CLASS_NOTE) VALUES (" & _
                    "N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_ID").ToString() + "',N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_CODE").ToString() + "'," & _
                    "N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_NAME").ToString() + "',N'" + CType(_SourceClass.Current, DataRowView).Row("CLASS_NOTE").ToString() + "')"
                SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
            End If
            _SourceProblem.MoveFirst()
            Dim i As Integer = 0
            While (i < _SourceProblem.Count)
                _sqlString = "Select count (*) from dbo.CLASS_PROBLEM where CLASS_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("CLASS_ID").ToString() + "' and PROBLEM_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'"
                Dim _countremedy As Object = SqlHelper.ExecuteScalar(_sqlTran, CommandType.Text, _sqlString)
                If (Not _countremedy Is Nothing) Then
                    If (CType(_countremedy, Integer) > 0) Then
                        _sqlString = "Update dbo.CLASS_PROBLEM set NOTES= N'" + CType(_SourceProblem.Current, DataRowView).Row("NOTES").ToString() + "'" & _
                        " where CLASS_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("CLASS_ID").ToString() + "' and PROBLEM_ID = N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'"
                        SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    Else
                        _sqlString = "Insert into dbo.CLASS_PROBLEM (CLASS_ID,PROBLEM_ID,NOTES) VALUES (" & _
                        "N'" + CType(_SourceProblem.Current, DataRowView).Row("CLASS_ID").ToString() + "',N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'" & _
                        ",N'" + CType(_SourceProblem.Current, DataRowView).Row("NOTES").ToString() + "')"
                        SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                    End If
                Else
                    _sqlString = "Insert into dbo.CLASS_PROBLEM (CLASS_ID,PROBLEM_ID,NOTES) VALUES (" & _
                        "N'" + CType(_SourceProblem.Current, DataRowView).Row("CLASS_ID").ToString() + "',N'" + CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID").ToString() + "'" & _
                        ",N'" + CType(_SourceProblem.Current, DataRowView).Row("NOTES").ToString() + "')"
                    SqlHelper.ExecuteNonQuery(_sqlTran, CommandType.Text, _sqlString)
                End If
                _SourceProblem.MoveNext()
                i = i + 1
            End While
            _sqlTran.Commit()
            _SourceProblem.EndEdit()
            CType(_SourceProblem.DataSource, DataTable).AcceptChanges()
            _SourceClass.EndEdit()
            FormControl(True)
            ControlReadOnly(True)
        Catch ex As Exception
            _sqlTran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorUpdateClass", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, "Vietsoft Ecomaint")
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _SourceProblem.CancelEdit()
        CType(_SourceProblem.DataSource, DataTable).RejectChanges()
        _SourceClass.CancelEdit()
        If grvClassList.CurrentRow Is Nothing Then
            _SourceProblem.Filter = "CLASS_ID IS NULL"
        Else
            _SourceProblem.Filter = "CLASS_ID ='" + grvClassList.CurrentRow.Cells("CLASS_ID").Value.ToString() + "'"
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
    Private Sub btnChoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoice.Click
        Dim _sqlString As String = "Select Convert(bit,0) as CHOICE,PROBLEM_ID,PROBLEM_CODE,PROBLEM_NAME,PROBLEM_NOTE from PROBLEM_LIST order by PROBLEM_NAME"
        Dim _tbSource As DataTable = New DataTable()
        _tbSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _sqlString))
        Dim i As Integer = 0
        While (i < _tbSource.Rows.Count)
            For j As Integer = 0 To _SourceProblem.Count - 1
                If (_tbSource.Rows(i)("PROBLEM_ID").Equals(CType(_SourceProblem.List(j), DataRowView).Row("PROBLEM_ID"))) Then
                    _tbSource.Rows.RemoveAt(i)
                    i = i - 1
                    j = _SourceProblem.Count
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
        _frmchoice.Name = "frmChoiceProblem"
        _frmchoice.grvSource.DataSource = _tbSource
        _frmchoice.grvSource.Columns("CHOICE").Width = 80
        _frmchoice.grvSource.Columns("PROBLEM_ID").Visible = False
        _frmchoice.grvSource.Columns("PROBLEM_CODE").MinimumWidth = 120
        _frmchoice.grvSource.Columns("PROBLEM_NAME").MinimumWidth = 120
        _frmchoice.grvSource.Columns("PROBLEM_NOTE").MinimumWidth = 180
        _frmchoice.grvSource.Columns("PROBLEM_NOTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If (_frmchoice.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            _frmchoice.Validate()
            _tbSource.DefaultView.RowFilter = "CHOICE = 1"
            Dim _tbselect As DataTable = New DataTable
            _tbselect = _tbSource.DefaultView.ToTable()
            For Each _dtrow As DataRow In _tbselect.Rows
                _SourceProblem.AddNew()
                CType(_SourceProblem.Current, DataRowView).Row("CLASS_ID") = CType(_SourceClass.Current, DataRowView).Row("CLASS_ID")
                CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_ID") = _dtrow("PROBLEM_ID")
                CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_CODE") = _dtrow("PROBLEM_CODE")
                CType(_SourceProblem.Current, DataRowView).Row("PROBLEM_NAME") = _dtrow("PROBLEM_NAME")
            Next
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
    End Sub
    Private Sub grvCauseList_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvCauseList.RowEnter
        If e.RowIndex < 0 Then
            _SourceRemedy.Filter = "CAUSE_ID IS NULL"
        Else
            _SourceRemedy.Filter = "CAUSE_ID ='" + grvCauseList.Rows(e.RowIndex).Cells("CAUSE_ID").Value.ToString() + "'"
        End If
    End Sub
End Class