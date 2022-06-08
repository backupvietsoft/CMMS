
Imports Commons.VS.Classes.Admin
Imports Microsoft.ApplicationBlocks.Data
Public Class frmStreet
    Private IsNew As Boolean = False
    Private TSource As DataTable = Nothing

    Private Sub frmStreet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindingSource()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnDelete.Enabled = False
            btnEdit.Enabled = False
            btnNew.Enabled = False
            btnPrint.Enabled = False
        End If
    End Sub

    Private Sub BindingSource()
        TSource = New DataTable()
        TSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select * from dbo.IC_DUONG"))
        For Each Column As DataColumn In TSource.Columns
            Column.AllowDBNull = True
            Column.ReadOnly = False
        Next
        grvList.AutoGenerateColumns = False
        grvList.DataSource = TSource
        colId.DataPropertyName = "MS"
        colNameViet.DataPropertyName = "TEN_V"
        colNameEnglish.DataPropertyName = "TEN_A"
        colNameChina.DataPropertyName = "TEN_H"
        colNote.DataPropertyName = "GHI_CHU"
        BindingControl()
        ReadOnlyControl(True)
        EnabledButton(True)
    End Sub

    Private Sub BindingControl()
        txtCode.DataBindings.Clear()
        txtNameViet.DataBindings.Clear()
        txtNameEnglish.DataBindings.Clear()
        txtNameChina.DataBindings.Clear()
        txtNote.DataBindings.Clear()
        txtCode.DataBindings.Add("Text", TSource, "MS")
        txtNameViet.DataBindings.Add("Text", TSource, "TEN_V")
        txtNameEnglish.DataBindings.Add("Text", TSource, "TEN_A")
        txtNameChina.DataBindings.Add("Text", TSource, "TEN_H")
        txtNote.DataBindings.Add("Text", TSource, "GHI_CHU")
    End Sub

    Private Sub ReadOnlyControl(ByVal Flag As Boolean)
        If Not Flag Then
            If IsNew Then
                txtCode.ReadOnly = Flag
            Else
                txtCode.ReadOnly = Not Flag
            End If
        Else
            txtCode.ReadOnly = Flag
        End If
        txtNameViet.ReadOnly = Flag
        txtNameEnglish.ReadOnly = Flag
        txtNameChina.ReadOnly = Flag
        txtNote.ReadOnly = Flag
        grvList.ReadOnly = True
        grvList.Enabled = Flag
    End Sub

    Private Sub EnabledButton(ByVal Flag As Boolean)
        btnNew.Enabled = Flag
        btnSave.Enabled = Not Flag
        btnCancel.Enabled = Not Flag
        If Flag Then
            If TSource.Rows.Count > 0 Then
                btnEdit.Enabled = Flag
                btnDelete.Enabled = Flag
                btnPrint.Enabled = Flag
            Else
                btnEdit.Enabled = Not Flag
                btnDelete.Enabled = Not Flag
                btnPrint.Enabled = Not Flag
            End If
        Else
            btnEdit.Enabled = Flag
            btnDelete.Enabled = Flag
            btnPrint.Enabled = Flag
        End If
        btnExit.Enabled = Flag
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        IsNew = True
        ReadOnlyControl(False)
        EnabledButton(False)
        Dim rNew As DataRow = TSource.NewRow()
        TSource.Rows.Add(rNew)
        For Each rSelect As DataGridViewRow In grvList.Rows
            If rSelect.Cells("colId").Value Is Nothing Then
                grvList.CurrentCell = rSelect.Cells("colId")
                Return
            Else
                If rSelect.Cells("colId").Value.Equals(DBNull.Value) Then
                    grvList.CurrentCell = rSelect.Cells("colId")
                    Return
                Else
                    If rSelect.Cells("colId").Value.ToString().Trim() = "" Then
                        grvList.CurrentCell = rSelect.Cells("colId")
                        Return
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Validate()
        If txtCode.Text.Trim() = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_MA_DUONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtCode.Focus()
            Return
        End If
        If IsNew Then
            If CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "select count(*) from dbo.IC_DUONG where MS = N'" + txtCode.Text.Trim() + "'"), Integer) > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MA_SO_DA_CO", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtCode.Focus()
                Return
            End If
        End If
        If txtNameViet.Text.Trim() = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_TEN_DUONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtNameViet.Focus()
            Return
        End If
        Try
            If IsNew Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "insert into dbo.IC_DUONG values(N'" + txtCode.Text.Trim() + "',N'" + txtNameViet.Text.Trim() + "'," & _
                IIf(txtNameEnglish.Text.Trim() = "", "NULL,", "N'" + txtNameEnglish.Text.Trim() + "',") & _
                IIf(txtNameChina.Text.Trim() = "", "NULL,", "N'" + txtNameChina.Text.Trim() + "',") & _
                IIf(txtNote.Text.Trim() = "", "NULL)", "N'" + txtNote.Text.Trim() + "')"))

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_IC_DUONG_LOG", txtCode.Text.Trim, Me.Name, Commons.Modules.UserName, 1)
            Else
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_IC_DUONG_LOG", txtCode.Text.Trim, Me.Name, Commons.Modules.UserName, 2)

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "update dbo.IC_DUONG set TEN_V = N'" + txtNameViet.Text.Trim() + "'," & _
                        "TEN_A = " + IIf(txtNameEnglish.Text.Trim() = "", "NULL,", "N'" + txtNameEnglish.Text.Trim() + "',") & _
                        "TEN_H = " + IIf(txtNameChina.Text.Trim() = "", "NULL,", "N'" + txtNameChina.Text.Trim() + "',") & _
                        "GHI_CHU = " + IIf(txtNote.Text.Trim() = "", "NULL", "N'" + txtNote.Text.Trim() + "'") & _
                        " where MS = N'" + txtCode.Text.Trim() + "'")
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOI_CAP_NHAT_DUONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Return
        End Try
        TSource.AcceptChanges()
        IsNew = False
        BindingControl()
        ReadOnlyControl(True)
        EnabledButton(True)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        IsNew = False
        TSource.RejectChanges()
        BindingControl()
        ReadOnlyControl(True)
        EnabledButton(True)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ReadOnlyControl(False)
        EnabledButton(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "HOI_KHI_XOA_DUONG", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            Try

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_IC_DUONG_LOG", txtCode.Text.Trim, Me.Name, Commons.Modules.UserName, 3)

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "delete dbo.IC_DUONG where MS = N'" + txtCode.Text.Trim() + "'")
                TSource.Rows.Remove(CType(grvList.CurrentRow.DataBoundItem, DataRowView).Row)
                TSource.AcceptChanges()
                EnabledButton(True)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOI_XOA_DUONG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            End Try
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class