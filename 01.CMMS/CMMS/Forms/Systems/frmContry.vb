
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Public Class frmContry
    Private IsNew As Boolean = False
    Private TSource As DataTable = Nothing
    Private TDetial As DataTable = Nothing
    Private Sub frmContry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindingSource()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnNew.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub
    Private Sub BindingSource()
        TSource = New DataTable()
        TSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select * from dbo.IC_QUOC_GIA"))
        For Each Column As DataColumn In TSource.Columns
            Column.AllowDBNull = True
            Column.ReadOnly = False
        Next
        CreateTreeView()
        TDetial = New DataTable()
        TDetial.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT T1.MS_QG,T1.MS_DUONG,T2.TEN_V,T2.TEN_A,T2.TEN_H,T2.GHI_CHU FROM dbo.DUONG_QG T1 " & _
        "INNER JOIN dbo.IC_DUONG T2 ON T1.MS_DUONG = T2.MS"))
        For Each Column As DataColumn In TDetial.Columns
            Column.AllowDBNull = True
            Column.ReadOnly = False
        Next

        TDetial.DefaultView.RowFilter = "MS_QG IS NULL"
        grvDetial.AutoGenerateColumns = False
        grvDetial.DataSource = TDetial
        colMS_QG.DataPropertyName = "MS_QG"
        colMS.DataPropertyName = "MS_DUONG"
        colTEN_V.DataPropertyName = "TEN_V"
        colTEN_A.DataPropertyName = "TEN_A"
        colTEN_H.DataPropertyName = "TEN_H"
        colGHI_CHU.DataPropertyName = "GHI_CHU"
        BindingControl()
        ReadOnlyControl(True)
        EnabledButton(True)

    End Sub
    Private Sub CreateTreeView()
        Dim nRoot As TreeNode = New TreeNode()
        nRoot.Name = "ROOT"
        nRoot.Text = "Quốc Gia"
        trvList.Nodes.Add(nRoot)
        TSource.DefaultView.RowFilter = "MS_CHA is null or MS_CHA = ''"
        Dim TParent As DataTable = TSource.DefaultView.ToTable()
        For Each Row In TParent.Rows
            Dim nNew As TreeNode = New TreeNode()
            nNew.Name = Row("MA_QG").ToString().Trim()
            If Row("GHI_CHU").ToString().Trim() = "" Then
                nNew.Text = Row("TEN_QG").ToString().Trim()
            Else
                nNew.Text = Row("TEN_QG").ToString().Trim() + "(" + Row("GHI_CHU").ToString().Trim() + ")"
            End If

            nNew.Tag = Row
            nRoot.Nodes.Add(nNew)
            CreateTreeNode(nNew)
        Next
        trvList.ExpandAll()
        trvList.Focus()
    End Sub
    Private Sub CreateTreeNode(ByVal nParent As TreeNode)
        TSource.DefaultView.RowFilter = "MS_CHA = '" + nParent.Name + "'"
        Dim TParent As DataTable = TSource.DefaultView.ToTable()
        For Each Row In TParent.Rows
            Dim nNew As TreeNode = New TreeNode()
            nNew.Name = Row("MA_QG").ToString().Trim()
            If Row("GHI_CHU").ToString().Trim() = "" Then
                nNew.Text = Row("TEN_QG").ToString().Trim()
            Else
                nNew.Text = Row("TEN_QG").ToString().Trim() + "(" + Row("GHI_CHU").ToString().Trim() + ")"
            End If
            nNew.Tag = Row
            nParent.Nodes.Add(nNew)
            CreateTreeNode(nNew)
        Next
    End Sub
    Private Sub BindingControl()
        If trvList.SelectedNode Is Nothing Then
            ClearConten()
        Else
            If trvList.SelectedNode.Name = "ROOT" Then
                ClearConten()
            Else
                txtMS.Text = CType(trvList.SelectedNode.Tag, DataRow)("MA_QG").ToString().Trim()
                txtTEN_V.Text = CType(trvList.SelectedNode.Tag, DataRow)("TEN_QG").ToString().Trim()
                txtTEN_A.Text = CType(trvList.SelectedNode.Tag, DataRow)("TEN_QG_A").ToString().Trim()
                txtTEN_H.Text = CType(trvList.SelectedNode.Tag, DataRow)("TEN_QG_H").ToString().Trim()
                txtGHI_CHU.Text = CType(trvList.SelectedNode.Tag, DataRow)("GHI_CHU").ToString().Trim()
                TDetial.DefaultView.RowFilter = "MS_QG = '" + txtMS.Text.Trim() + "'"
            End If
        End If
    End Sub
    Private Sub ClearConten()
        txtMS.Text = ""
        txtTEN_V.Text = ""
        txtTEN_A.Text = ""
        txtTEN_H.Text = ""
        txtGHI_CHU.Text = ""
        TDetial.DefaultView.RowFilter = "MS_QG IS NULL"
    End Sub
    Private Sub ReadOnlyControl(ByVal Flag As Boolean)
        If Not Flag Then
            If IsNew Then
                txtMS.ReadOnly = Flag
            Else
                txtMS.ReadOnly = Not Flag
            End If
        Else
            txtMS.ReadOnly = Flag
        End If
        txtTEN_V.ReadOnly = Flag
        txtTEN_A.ReadOnly = Flag
        txtTEN_H.ReadOnly = Flag
        txtGHI_CHU.ReadOnly = Flag
        trvList.Enabled = Flag
        grvDetial.AllowUserToDeleteRows = Flag
    End Sub
    Private Sub EnabledButton(ByVal Flag As Boolean)
        btnNew.Enabled = Flag
        btnSave.Enabled = Not Flag
        btnCancel.Enabled = Not Flag
        btnChoice.Enabled = Not Flag
        If Flag Then
            If Not trvList.SelectedNode Is Nothing Then
                If trvList.SelectedNode.Name <> "ROOT" Then
                    btnEdit.Enabled = Flag
                    btnDelete.Enabled = Flag
                    btnPrint.Enabled = Flag
                Else
                    btnEdit.Enabled = Not Flag
                    btnDelete.Enabled = Not Flag
                    btnPrint.Enabled = Not Flag
                End If

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
    Private Sub trvList_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvList.AfterSelect
        BindingControl()
        EnabledButton(True)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If trvList.SelectedNode Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON_CAP_TREN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            trvList.Focus()
            Return
        End If
        IsNew = True
        ReadOnlyControl(False)
        EnabledButton(False)
        ClearConten()
    End Sub

    Private Sub btnChoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoice.Click
        If txtMS.Text.Trim() = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_MS_QG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtMS.Focus()
            Return
        End If
        If IsNew Then
            If CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "select count(*) from dbo.IC_QUOC_GIA where MA_QG = N'" + txtMS.Text.Trim() + "'"), Integer) > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_QG_DA_CO", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtMS.Focus()
                Return
            End If
        End If
        Dim TStreet As DataTable = New DataTable()
        TStreet.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT CONVERT(BIT,0) AS CHOICE,T.MS,T.TEN_V,T.TEN_A,T.TEN_H,T.GHI_CHU FROM dbo.IC_DUONG T "))
        For Each Column As DataColumn In TStreet.Columns
            If Column.ColumnName = "CHOICE" Then
                Column.ReadOnly = False
            Else
                Column.ReadOnly = True
            End If
        Next

        For i As Integer = 0 To TStreet.Rows.Count - 1
            If (i < TStreet.Rows.Count) Then
                For j As Integer = 0 To TDetial.DefaultView.Count - 1
                    If TStreet.Rows(i)("MS").Equals(TDetial.DefaultView(j).Row("MS_DUONG")) Then
                        TStreet.Rows.RemoveAt(i)
                        If TStreet.Rows.Count > 0 Then
                            i = i - 1
                        End If
                        Exit For
                    End If
                Next
            End If
        Next
        Dim frmChoice As frmChoiStreet = New frmChoiStreet()
        frmChoice.grvList.DataSource = TStreet
        Commons.Modules.ObjSystems.ThayDoiNN(frmChoice)
        If frmChoice.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            TStreet.DefaultView.RowFilter = "CHOICE = 1"
            Dim Flag As Boolean = False
            For i As Integer = 0 To TStreet.DefaultView.Count - 1
                Dim dtRow As DataRow = TDetial.NewRow()
                dtRow("MS_QG") = txtMS.Text.Trim()
                dtRow("MS_DUONG") = TStreet.DefaultView(i).Row("MS")
                dtRow("TEN_V") = TStreet.DefaultView(i).Row("TEN_V")
                dtRow("TEN_A") = TStreet.DefaultView(i).Row("TEN_A")
                dtRow("TEN_H") = TStreet.DefaultView(i).Row("TEN_H")
                dtRow("GHI_CHU") = TStreet.DefaultView(i).Row("GHI_CHU")
                TDetial.Rows.Add(dtRow)
                Flag = True
            Next
            If Flag Then
                TDetial.DefaultView.RowFilter = "MS_QG = '" + txtMS.Text.Trim() + "'"
                txtMS.ReadOnly = True
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Validate()
        If txtMS.Text.Trim() = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_MS_QG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtMS.Focus()
            Return
        End If
        If txtTEN_V.Text.Trim() = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_TEN_QG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtTEN_V.Focus()
            Return
        End If
        If IsNew Then
            If CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "select count(*) from dbo.IC_QUOC_GIA where MA_QG = N'" + txtMS.Text.Trim() + "'"), Integer) > 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_QG_DA_CO", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtMS.Focus()
                Return
            End If
        End If

        Dim Cnn As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim sqlTran As SqlTransaction = Cnn.BeginTransaction()
        Try
            If IsNew Then

                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "insert into dbo.IC_QUOC_GIA values(N'" + txtMS.Text.Trim() + "'," + IIf(trvList.SelectedNode.Name = "ROOT", "NULL,", "N'" + trvList.SelectedNode.Name + "',") & _
                            IIf(txtTEN_V.Text.Trim() = "", "NULL,", "N'" + txtTEN_V.Text.Trim() + "',") & _
                            IIf(txtTEN_A.Text.Trim() = "", "NULL,", "N'" + txtTEN_A.Text.Trim() + "',") & _
                            IIf(txtTEN_H.Text.Trim() = "", "NULL,", "N'" + txtTEN_H.Text.Trim() + "',") & _
                            IIf(txtGHI_CHU.Text.Trim() = "", "NULL)", "N'" + txtGHI_CHU.Text.Trim() + "')"))
                SqlHelper.ExecuteNonQuery(sqlTran, "UPDATE_IC_QUOC_GIA_LOG", txtMS.Text.Trim, Me.Name, Commons.Modules.UserName, 1)

            Else
                SqlHelper.ExecuteNonQuery(sqlTran, "UPDATE_IC_QUOC_GIA_LOG", txtMS.Text.Trim, Me.Name, Commons.Modules.UserName, 2)
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "update dbo.IC_QUOC_GIA set TEN_QG = N'" + txtTEN_V.Text.Trim() + "'," & _
                            "TEN_QG_A = " + IIf(txtTEN_A.Text.Trim() = "", "NULL,", "N'" + txtTEN_A.Text.Trim() + "',") & _
                            "TEN_QG_H = " + IIf(txtTEN_H.Text.Trim() = "", "NULL,", "N'" + txtTEN_H.Text.Trim() + "',") & _
                            "GHI_CHU = " + IIf(txtGHI_CHU.Text.Trim() = "", "NULL", "N'" + txtGHI_CHU.Text.Trim() + "'") & _
                            " where MA_QG = N'" + txtMS.Text.Trim() + "'")
            End If

            For i As Integer = 0 To TDetial.DefaultView.Count - 1
                If CType(SqlHelper.ExecuteScalar(sqlTran, CommandType.Text, "select count(*) from dbo.DUONG_QG where MS_DUONG = N'" + TDetial.DefaultView(i).Row("MS_DUONG").ToString().Trim() + "' AND MS_QG = N'" + TDetial.DefaultView(i).Row("MS_QG").ToString().Trim() + "'"), Integer) = 0 Then
                    SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "insert into dbo.DUONG_QG values(N'" + TDetial.DefaultView(i).Row("MS_DUONG").ToString().Trim() + "',N'" + TDetial.DefaultView(i).Row("MS_QG").ToString().Trim() + "')")
                    SqlHelper.ExecuteNonQuery(sqlTran, "UPDATE_DUONG_QG_LOG", TDetial.DefaultView(i).Row("MS_DUONG").ToString().Trim, TDetial.DefaultView(i).Row("MS_QG").ToString().Trim(), Me.Name, Commons.Modules.UserName, 1)
                End If
            Next

            If IsNew Then
                Dim nNew As TreeNode = New TreeNode()
                nNew.Name = txtMS.Text.Trim()
                nNew.Text = txtTEN_V.Text.Trim()
                Dim dtRow As DataRow = TSource.NewRow()
                dtRow("MA_QG") = txtMS.Text.Trim()
                dtRow("TEN_QG") = txtTEN_V.Text.Trim()
                dtRow("TEN_QG_A") = txtTEN_A.Text.Trim()
                dtRow("TEN_QG_H") = txtTEN_H.Text.Trim()
                dtRow("GHI_CHU") = txtGHI_CHU.Text.Trim()
                TSource.Rows.Add(dtRow)
                nNew.Tag = dtRow
                trvList.SelectedNode.Nodes.Add(nNew)
                trvList.SelectedNode = nNew
            Else
                CType(trvList.SelectedNode.Tag, DataRow)("MA_QG") = txtMS.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("TEN_QG") = txtTEN_V.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("TEN_QG_A") = txtTEN_A.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("TEN_QG_H") = txtTEN_H.Text.Trim()
                CType(trvList.SelectedNode.Tag, DataRow)("GHI_CHU") = txtGHI_CHU.Text.Trim()
            End If

            sqlTran.Commit()
            TSource.AcceptChanges()
            TDetial.AcceptChanges()
            IsNew = False
            BindingControl()
            ReadOnlyControl(True)
            EnabledButton(True)
        Catch ex As Exception
            sqlTran.Rollback()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOI_CAP_NHAT_QG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Return
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        IsNew = False
        TSource.RejectChanges()
        TDetial.RejectChanges()
        BindingControl()
        ReadOnlyControl(True)
        EnabledButton(True)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ReadOnlyControl(False)
        EnabledButton(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "HOI_KHI_XOA_QG", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            Dim Cnn As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
            End If
            Dim sqlTran As SqlTransaction = Cnn.BeginTransaction()
            Try
                For i As Integer = 0 To TDetial.DefaultView.Count - 1
                    SqlHelper.ExecuteNonQuery(sqlTran, "UPDATE_DUONG_QG_LOG", TDetial.DefaultView(i).Row("MS_DUONG").ToString().Trim, TDetial.DefaultView(i).Row("MS_QG").ToString().Trim(), Me.Name, Commons.Modules.UserName, 3)
                    SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "DELETE dbo.DUONG_QG WHERE MS_DUONG = N'" + TDetial.DefaultView(i).Row("MS_DUONG").ToString().Trim() + "' AND MS_QG = N'" + TDetial.DefaultView(i).Row("MS_QG").ToString().Trim() + "'")
                    TDetial.Rows.Remove(TDetial.DefaultView(i).Row)
                    If TDetial.DefaultView.Count > 0 Then
                        i = i - 1
                    End If
                Next
                SqlHelper.ExecuteNonQuery(sqlTran, "UPDATE_IC_QUOC_GIA_LOG", txtMS.Text.Trim, Me.Name, Commons.Modules.UserName, 3)
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "DELETE dbo.IC_QUOC_GIA WHERE MA_QG = N'" + txtMS.Text.Trim() + "'")

                
                For Each dtRow As DataRow In TSource.Rows
                    If (dtRow("MA_QG").Equals(txtMS.Text.Trim())) Then
                        TSource.Rows.Remove(dtRow)
                        Exit For
                    End If
                Next
                trvList.Nodes.Remove(trvList.SelectedNode)
                sqlTran.Commit()
                TSource.AcceptChanges()
                TDetial.AcceptChanges()
                BindingControl()
                ReadOnlyControl(True)
                EnabledButton(True)
            Catch ex As Exception
                sqlTran.Rollback()
                TSource.RejectChanges()
                TDetial.RejectChanges()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOI_XOA_QG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Return
            End Try
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub grvDetial_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grvDetial.UserDeletedRow
        TDetial.AcceptChanges()
    End Sub

    Private Sub grvDetial_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grvDetial.UserDeletingRow
        Dim Cnn As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim sqlTran As SqlTransaction = Cnn.BeginTransaction()
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HOI_KHI_XOA_DUONG_QG", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            Try

                SqlHelper.ExecuteNonQuery(sqlTran, "UPDATE_DUONG_QG_LOG", e.Row.Cells("colMS").Value.ToString().Trim(), e.Row.Cells("colMS_QG").Value.ToString().Trim(), Me.Name, Commons.Modules.UserName, 3)
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, "DELETE dbo.DUONG_QG WHERE MS_DUONG = N'" + e.Row.Cells("colMS").Value.ToString().Trim() + "' AND MS_QG = N'" + e.Row.Cells("colMS_QG").Value.ToString().Trim() + "'")
                sqlTran.Commit()
            Catch ex As Exception
                sqlTran.Rollback()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOI_XOA_DUONG", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly, Me.Text)
                e.Cancel = True
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnPCBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPCBT.Click

        If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmPCBT") = False Then Exit Sub
        Dim frm As ImportExcels.frmPCBT = New ImportExcels.frmPCBT()
        frm.MSTQuan = txtMS.Text
        frm.TenQuan = txtTEN_A.Text
        frm.ShowDialog()
    End Sub

    Private Sub grvDetial_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvDetial.CellContentClick

    End Sub
End Class