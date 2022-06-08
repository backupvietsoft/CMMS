Imports Commons.VS.Classes.Catalogue
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons


Public Class frmDanhmucHechuyengia
    Dim bindingClassList, bindingCauseList, bindingProblemList, bindingRemedyList As New BindingSource
    Dim dtClassList As DataTable
    Dim dtProblemList As DataTable
    Dim dtCauseList As DataTable
    Dim dtRemedyList As DataTable
    Dim dtClassProblem, dtProblemCause, dtCauseRemedy As DataTable
    Dim iClassList, iCauseList, iProblemList, iRemedy As DataGridViewRow
    Dim tt, tt1, tt2, tt3, tt4 As String

    Private Sub frmDanhmucHechuyengia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tt = "None"
        tt1 = "None"
        tt2 = "None"
        tt3 = "None"
        tt4 = "None"
        InitDatabase()
        BindingControl()
        EnableButton1(True)
        EnableControl1(True)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        'EnableButton(False)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click, btnThoat2.Click, btnThoat3.Click, btnThoat4.Click, btnThoat.Click
        Me.Close()
    End Sub

    Private Sub InitDatabase()
        Try

            dtClassList = (New CLASS_LIST_Controller()).GetCLASS_LISTs()
            dtCauseList = (New CAUSE_LIST_Controller()).GetCAUSE_LISTs()
            dtProblemList = (New PROBLEM_LIST_Controller()).GetPROBLEM_LISTs()
            dtRemedyList = New DataTable()

            bindingClassList.DataSource = dtClassList
            bindingCauseList.DataSource = dtCauseList
            bindingProblemList.DataSource = dtProblemList
            gvCauseList.AutoGenerateColumns = False
            gvCauseList.DataSource = bindingCauseList
            gvClassList.AutoGenerateColumns = False
            gvClassList.DataSource = bindingClassList
            gvProblemList.AutoGenerateColumns = False
            gvProblemList.DataSource = bindingProblemList
            Me.gvCauseList.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.gvCauseList.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Me.gvClassList.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.gvClassList.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Me.gvProblemList.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.gvProblemList.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Me.gvRemedyCause.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.gvRemedyCause.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            gvRemedy1.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            gvRemedy1.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Me.clsCauseList.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.clsCauseList.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Me.clsProblemList.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.clsProblemList.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Me.clsClass.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.clsClass.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

            AddHandler dtClassList.TableNewRow, AddressOf dtClassList_TableNewRow
            AddHandler dtCauseList.TableNewRow, AddressOf dtCauseList_TableNewRow
            AddHandler dtProblemList.TableNewRow, AddressOf dtProblemList_TableNewRow



            cboRemedy_Cause.DataSource = bindingCauseList
            cboRemedy_Cause.DisplayMember = "CAUSE_NAME"
            cboRemedy_Cause.ValueMember = "CAUSE_ID"
            If cboRemedy_Cause.Items.Count > 0 Then
                tabRemedy.Show()
                cboRemedy_Cause.SelectedIndex = 0

                dtRemedyList = (New REMEDY_CAUSE_Controller()).GetREMEDY_CAUSEs(cboRemedy_Cause.SelectedValue)
                bindingRemedyList.DataSource = dtRemedyList
                gvRemedyCause.AutoGenerateColumns = False
                gvRemedyCause.DataSource = bindingRemedyList
            Else
                tabRemedy.Hide()
                dtRemedyList = (New REMEDY_CAUSE_Controller()).GetREMEDY_CAUSEs("")
                bindingRemedyList.DataSource = dtRemedyList
                gvRemedyCause.AutoGenerateColumns = False
                gvRemedyCause.DataSource = bindingRemedyList
            End If
            LoadHCG()

            AddHandler dtRemedyList.TableNewRow, AddressOf dtRemedyList_TableNewRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindingControl()
        txtCause_Code.DataBindings.Clear()
        txtCause_Code.DataBindings.Add("Text", bindingCauseList, "CAUSE_CODE")
        txtCause_Name.DataBindings.Clear()
        txtCause_Name.DataBindings.Add("Text", bindingCauseList, "CAUSE_NAME")
        txtCause_Note.DataBindings.Clear()
        txtCause_Note.DataBindings.Add("Text", bindingCauseList, "CAUSE_NOTE")

        txtClass_Code.DataBindings.Clear()
        txtClass_Code.DataBindings.Add("Text", bindingClassList, "CLASS_CODE")
        txtClass_Name.DataBindings.Clear()
        txtClass_Name.DataBindings.Add("Text", bindingClassList, "CLASS_NAME")
        txtClass_Note.DataBindings.Clear()
        txtClass_Note.DataBindings.Add("Text", bindingClassList, "CLASS_NOTE")

        txtProblem_Code.DataBindings.Clear()
        txtProblem_Code.DataBindings.Add("Text", bindingProblemList, "PROBLEM_CODE")
        txtProblem_Name.DataBindings.Clear()
        txtProblem_Name.DataBindings.Add("Text", bindingProblemList, "PROBLEM_NAME")
        txtProblemNote.DataBindings.Clear()
        txtProblemNote.DataBindings.Add("Text", bindingProblemList, "PROBLEM_NOTE")

        txtRemedy_Code.DataBindings.Clear()
        txtRemedy_Code.DataBindings.Add("Text", bindingRemedyList, "REMEDY_CODE")
        txtRemedy_Name.DataBindings.Clear()
        txtRemedy_Name.DataBindings.Add("Text", bindingRemedyList, "REMEDY_NAME")
        txtRemedy_Link.DataBindings.Clear()
        txtRemedy_Link.DataBindings.Add("Text", bindingRemedyList, "LINK")
        txtRemedy_Note.DataBindings.Clear()
        txtRemedy_Note.DataBindings.Add("Text", bindingRemedyList, "NOTE")
    End Sub

    Private Function CheckExist(ByVal dt As DataTable, ByVal colid As String, ByVal valuaid As String, ByVal col As String, ByVal value As String) As Boolean
        Dim str As String
        If colid = "" Then
            str = col & "='" & value & "'"
        Else
            str = col & "='" & value & "' AND " & colid & "<>'" & valuaid & "'"
        End If

        Dim row() As DataRow = dt.Select(str)
        If row.Length > 0 Then
            Return True
        End If
        Return False
    End Function


    Private Sub tabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControl.SelectedIndexChanged
        If tt = "None" And tt1 = "None" And tt2 = "None" And tt3 = "None" And tt4 = "None" Then
            Select Case tabControl.SelectedIndex
                Case 0
                    LoadHCG()
                    'EnableButton(False)
                Case 1
                    EnableButton1(True)
                    EnableControl1(True)
                Case 2
                    EnableButton2(True)
                    EnableControl2(True)
                Case 3
                    EnableButton3(True)
                    EnableControl3(True)
                Case 4
                    EnableButton4(True)
                    EnableControl4(True)
            End Select
        Else
            If tt <> "None" And Not tabControl.SelectedTab.Equals(tabHechuyengia) Then
                tabControl.SelectedTab = tabHechuyengia
            Else
                If tt1 <> "None" And Not tabControl.SelectedTab.Equals(tabClassList) Then
                    tabControl.SelectedTab = tabClassList
                Else
                    If tt2 <> "None" And Not tabControl.SelectedTab.Equals(tabProblemList) Then
                        tabControl.SelectedTab = tabProblemList
                    Else
                        If tt3 <> "None" And Not tabControl.SelectedTab.Equals(tabCauseList) Then
                            tabControl.SelectedTab = tabCauseList
                        Else
                            If tt4 <> "None" And Not tabControl.SelectedTab.Equals(tabRemedy) Then
                                tabControl.SelectedTab = tabRemedy
                            End If
                        End If
                    End If
                End If
            End If
        End If
        If cboRemedy_Cause.Items.Count > 0 Then
            cboRemedy_Cause.SelectedIndex = 0
        Else
            btnThem4.Enabled = False
            btnSua4.Enabled = False
            cboRemedy_Cause.Enabled = False
        End If
    End Sub

#Region "Tab He Chuyen Gia"
    Private Sub LoadHCG()
        Try
            clsClass.AutoGenerateColumns = False
            clsClass.DataSource = dtClassList
            dtClassProblem = New DataTable()
            dtProblemCause = New DataTable()
            dtClassProblem.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCLASS_PROBLEMs"))
            dtProblemCause.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPROBLEM_CAUSEs"))

            clsProblemList.AutoGenerateColumns = False
            clsProblemList.DataSource = dtClassProblem.DefaultView
            clsCauseList.AutoGenerateColumns = False
            clsCauseList.DataSource = dtProblemCause.DefaultView

            If dtClassList.Rows.Count > 0 Then
                clsClass.CurrentCell = clsClass.Rows(0).Cells("CLASS_NAME1")
                clsClass.Rows(0).Selected = True
                Dim str As String = clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString()
                dtClassProblem.DefaultView.RowFilter = "CLASS_ID='" & clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString() & "'"
                If clsProblemList.RowCount > 0 Then
                    dtProblemCause.DefaultView.RowFilter = "PROBLEM_ID='" & clsProblemList.CurrentRow.Cells("PROBLEM_ID1").Value.ToString() & "'"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnableButton(ByVal flag As Boolean)
        clsClass.Enabled = Not flag
        btnChonProblem.Enabled = flag
        btnChonCause.Enabled = flag
        'btnSua.Enabled = Not flag
        'btnGhi.Enabled = flag
        'btnKhongghi.Enabled = flag
    End Sub
    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tt = "Add"
        EnableButton(True)
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim cClass As String = clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString()
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try
            For Each rP As DataGridViewRow In clsProblemList.Rows
                dtProblemCause.DefaultView.RowFilter = "PROBLEM_ID='" & rP.Cells("PROBLEM_ID1").Value.ToString & "'"

                For Each rC As DataRow In dtProblemCause.DefaultView.ToTable().Rows
                    SqlHelper.ExecuteScalar(objTrans, "AddPROBLEM_CAUSE", rP.Cells("PROBLEM_ID").Value.ToString, rC("CAUSE_ID").ToString)
                Next
                SqlHelper.ExecuteScalar(objTrans, "AddCLASS_PROBLEM", cClass, rP.Cells("PROBLEM_ID").Value.ToString)
            Next
            objTrans.Commit()
            tt = "None"
            EnableButton(False)
        Catch ex As Exception
            objTrans.Rollback()
        Finally
            objConnection.Close()
        End Try

    End Sub

    Private Sub btnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tt = "None"
        EnableButton(False)
    End Sub

    Private Sub clsClass_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clsClass.SelectionChanged
        Try
            Dim str As String = clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString()
            dtClassProblem.DefaultView.RowFilter = "CLASS_ID='" & clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString() & "'"
            If clsProblemList.Rows.Count > 0 Then
                clsProblemList.CurrentCell = clsProblemList.Rows(0).Cells(0)
                clsProblemList.Rows(0).Cells(0).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub clsProblemList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clsProblemList.SelectionChanged
        Try
            If clsProblemList.RowCount > 0 Then
                'Dim str As String = clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString()
                dtProblemCause.DefaultView.RowFilter = "PROBLEM_ID='" & clsProblemList.CurrentRow.Cells("PROBLEM_ID1").Value.ToString() & "'"
                If clsCauseList.Rows.Count > 0 Then
                    ' clsCauseList.Rows(0).Selected = True
                    'clsCauseList.CurrentCell = clsCauseList.Rows(0).Cells(0)
                End If
            Else
                dtProblemCause.DefaultView.RowFilter = "0=1"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub clsCauseList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clsCauseList.SelectionChanged
        Try
            If clsCauseList.Rows.Count > 0 Then
                dtCauseRemedy = (New REMEDY_CAUSE_Controller()).GetREMEDY_CAUSEs(clsCauseList.CurrentRow.Cells("CAUSE_ID1").Value.ToString())
                gvRemedy1.AutoGenerateColumns = False
                gvRemedy1.DataSource = dtCauseRemedy
            Else
                gvRemedy1.DataSource = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChonCause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonCause.Click
        Dim frm As New frmChonHechuyengia()
        frm.Name = "frmChonCause"
        frm.dt = dtCauseList.Copy()
        frm.dt.Columns.Add("CHON", GetType(Boolean))
        frm.Label1.Name = "CAUSELIST"
        frm.gvListChon.Columns("cCHON").DataPropertyName = "CHON"
        frm.gvListChon.Columns("cID").DataPropertyName = "CAUSE_ID"
        frm.gvListChon.Columns("cCODE").DataPropertyName = "CAUSE_CODE"
        frm.gvListChon.Columns("cNAME").DataPropertyName = "CAUSE_NAME"
        frm.gvListChon.Columns("cNOTE").DataPropertyName = "CAUSE_NOTE"
        frm.gvListChon.AutoGenerateColumns = False
        frm.gvListChon.DataSource = frm.dt
        frm.gvListChon.ReadOnly = False
        frm.gvListChon.Columns("cCHON").ReadOnly = False
        frm.gvListChon.Columns("cCODE").ReadOnly = True
        frm.gvListChon.Columns("cNAME").ReadOnly = True
        frm.gvListChon.Columns("cNOTE").ReadOnly = True

        For Each row As DataGridViewRow In clsCauseList.Rows
            For Each r As DataRow In frm.dt.Rows
                If r("CAUSE_ID").ToString().Equals(row.Cells("CAUSE_ID1").Value.ToString()) Then
                    'Dim t As Boolean = r.Cells("cCHON").Value
                    r("CHON") = True
                End If
            Next
        Next
        If DialogResult.OK = frm.ShowDialog() Then
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                For Each r As DataGridViewRow In frm.gvListChon.Rows
                    If r.Cells("cCHON").Value.Equals(DBNull.Value) Or r.Cells("cCHON").Value.Equals(False) Then
                        Dim r1() As DataRow = dtProblemCause.Select("PROBLEM_ID='" & clsProblemList.CurrentRow.Cells("PROBLEM_ID1").Value.ToString & "' and CAUSE_ID='" & r.Cells("cID").Value.ToString() & "'")
                        If r1.Length > 0 Then
                            Dim result As Integer
                            result = SqlHelper.ExecuteNonQuery(objTrans, "DELETE_PROBLEM_CAUSE", clsProblemList.CurrentRow.Cells("PROBLEM_ID1").Value.ToString, r.Cells("cID").Value.ToString())
                            If result <= 0 Then
                                objTrans.Rollback()
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgdulieudaphatsinhkhongthexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                                Exit Sub
                            End If
                            dtProblemCause.Rows.Remove(r1(0))
                        End If
                    Else
                        Dim r1() As DataRow = dtProblemCause.Select("PROBLEM_ID='" & clsProblemList.CurrentRow.Cells("PROBLEM_ID1").Value.ToString & "' and CAUSE_ID='" & r.Cells("cID").Value.ToString() & "'")
                        If r1.Length <= 0 Then
                            Dim row As DataRow = dtProblemCause.NewRow()
                            row("PROBLEM_ID") = clsProblemList.CurrentRow.Cells("PROBLEM_ID1").Value.ToString
                            row("CAUSE_ID") = r.Cells("cID").Value.ToString()
                            row("CAUSE_CODE") = r.Cells("cCODE").Value.ToString()
                            row("CAUSE_NAME") = r.Cells("cNAME").Value.ToString()
                            dtProblemCause.Rows.Add(row)
                            SqlHelper.ExecuteScalar(objTrans, "AddPROBLEM_CAUSE", row("PROBLEM_ID"), row("CAUSE_ID"))
                        End If

                    End If
                Next
                objTrans.Commit()
            Catch ex As Exception
                objTrans.Rollback()
            Finally
                objConnection.Close()
            End Try

        End If
    End Sub

    Private Sub btnChonProblem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonProblem.Click
        Dim frm As New frmChonHechuyengia()
        frm.Name = "frmChonProblem"
        frm.dt = dtProblemList.Copy()
        frm.dt.Columns.Add("CHON", GetType(Boolean))
        frm.Label1.Name = "PROBLEMLIST"

        frm.gvListChon.Columns("cCHON").DataPropertyName = "CHON"
        frm.gvListChon.Columns("cID").DataPropertyName = "PROBLEM_ID"
        frm.gvListChon.Columns("cCODE").DataPropertyName = "PROBLEM_CODE"
        frm.gvListChon.Columns("cNAME").DataPropertyName = "PROBLEM_NAME"
        frm.gvListChon.Columns("cNOTE").DataPropertyName = "PROBLEM_NOTE"
        frm.gvListChon.AutoGenerateColumns = False
        frm.gvListChon.DataSource = frm.dt
        frm.gvListChon.ReadOnly = False
        frm.gvListChon.Columns("cCHON").ReadOnly = False
        frm.gvListChon.Columns("cCODE").ReadOnly = True
        frm.gvListChon.Columns("cNAME").ReadOnly = True
        frm.gvListChon.Columns("cNOTE").ReadOnly = True

        For Each row As DataGridViewRow In clsProblemList.Rows
            For Each r As DataRow In frm.dt.Rows
                If r("PROBLEM_ID").ToString().Equals(row.Cells("PROBLEM_ID1").Value.ToString()) Then
                    'Dim t As Boolean = r.Cells("cCHON").Value
                    r("CHON") = True
                End If
            Next
        Next
        If DialogResult.OK = frm.ShowDialog() Then
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                For Each r As DataGridViewRow In frm.gvListChon.Rows
                    If r.Cells("cCHON").Value.Equals(DBNull.Value) Or r.Cells("cCHON").Value.Equals(False) Then
                        Dim r1() As DataRow = dtClassProblem.Select("CLASS_ID='" & clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString & "' and PROBLEM_ID='" & r.Cells("cID").Value.ToString() & "'")
                        If r1.Length > 0 Then
                            Dim result As Integer
                            result = SqlHelper.ExecuteNonQuery(objTrans, "DELETECLASS_PROBLEM", clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString, r.Cells("cID").Value.ToString())
                            If result <= 0 Then
                                objTrans.Rollback()
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgdulieudaphatsinhkhongthexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                                Exit Sub
                            End If
                            dtClassProblem.Rows.Remove(r1(0))
                        End If
                    Else
                        Dim r1() As DataRow = dtClassProblem.Select("CLASS_ID='" & clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString & "' and PROBLEM_ID='" & r.Cells("cID").Value.ToString() & "'")
                        If r1.Length <= 0 Then
                            Dim row As DataRow = dtClassProblem.NewRow()
                            row("CLASS_ID") = clsClass.CurrentRow.Cells("CLASS_ID1").Value.ToString
                            row("PROBLEM_ID") = r.Cells("cID").Value.ToString()
                            row("PROBLEM_CODE") = r.Cells("cCODE").Value.ToString()
                            row("PROBLEM_NAME") = r.Cells("cNAME").Value.ToString()
                            dtClassProblem.Rows.Add(row)
                            SqlHelper.ExecuteScalar(objTrans, "AddCLASS_PROBLEM", row("CLASS_ID"), row("PROBLEM_ID"))
                        End If

                    End If
                Next
                objTrans.Commit()
            Catch ex As Exception
                objTrans.Rollback()
            Finally
                objConnection.Close()
            End Try
        End If
    End Sub
#End Region

#Region "Tab ClassList"
    Private Sub dtClassList_TableNewRow(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        e.Row("CLASS_ID") = Commons.clsTaoMa.RandomId("creatClassID", "CLASS_LIST", "CLASS_ID", "CLASS")
    End Sub

    Private Sub btnThem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem1.Click
        iClassList = gvClassList.CurrentRow
        txtClass_Name.Focus()
        tt1 = "Add"
        EnableButton1(False)
        EnableControl1(False)
        bindingClassList.AddNew()
        gvClassList.Enabled = False
    End Sub

    Private Sub btnSua1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua1.Click
        tt1 = "Edit"
        txtClass_Name.Focus()
        iClassList = gvClassList.CurrentRow
        EnableButton1(False)
        EnableControl1(False)
        gvClassList.Enabled = False
    End Sub

    Private Sub btnXoa1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa1.Click
        If gvClassList.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCodulieudexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim objCLASS_LIST_Controller As New CLASS_LIST_Controller()
            Dim result = objCLASS_LIST_Controller.DeleteCLASS_LIST(gvClassList.CurrentRow.Cells("CLASS_ID").Value.ToString())
            If result > 0 Then
                bindingClassList.Remove(bindingClassList.Current)
                bindingClassList.EndEdit()
                dtClassList.AcceptChanges()
                EnableButton1(True)
                EnableControl1(True)
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdulieuKhongxoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub btnGhi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi1.Click
        Try
            If txtClass_Name.Text.Trim.Length <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdNhapClassName", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtClass_Name.Focus()
                Exit Sub
            End If
            If txtClass_Code.Text.Trim.Length <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdNhapClassCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtClass_Code.Focus()
                Exit Sub
            End If
            Dim objCLASS_LIST_Controller As New CLASS_LIST_Controller()
            Dim objClassList As New CLASS_LIST_Info()
            objClassList.CLASS_ID = gvClassList.CurrentRow.Cells("CLASS_ID").Value
            objClassList.CLASS_CODE = txtClass_Code.Text
            objClassList.CLASS_NAME = txtClass_Name.Text
            objClassList.CLASS_NOTE = txtClass_Note.Text
            If tt1 = "Add" Then
                If CheckExist(dtClassList, "", "", "CLASS_CODE", txtClass_Code.Text) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungClassCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtClass_Code.Focus()
                    Exit Sub
                End If
                objClassList.CLASS_ID = Commons.clsTaoMa.RandomId("creatClassID", "CLASS_LIST", "CLASS_ID", "CLASS")
                gvClassList.CurrentRow.Cells("CLASS_ID").Value = objClassList.CLASS_ID
                objCLASS_LIST_Controller.AddCLASS_LIST(objClassList)
            Else
                If CheckExist(dtClassList, "CLASS_ID", objClassList.CLASS_ID, "CLASS_CODE", txtClass_Code.Text) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungClassCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtClass_Code.Focus()
                    Exit Sub
                End If
                If tt1 = "Edit" Then
                    objCLASS_LIST_Controller.UpdateCLASS_LIST(objClassList)
                End If
            End If
            bindingClassList.EndEdit()
            dtClassList.AcceptChanges()
            EnableButton1(True)
            EnableControl1(True)
            gvClassList.Enabled = True
            tt1 = "None"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnKhongghi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongghi1.Click
        Try

            tt1 = "None"
            bindingClassList.CancelEdit()
            dtClassList.RejectChanges()
            EnableButton1(True)
            EnableControl1(True)
            gvClassList.Enabled = True

            If Not iClassList.Equals(DBNull.Value) Then
                gvClassList.CurrentCell = iClassList.Cells("CLASS_CODE")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnableButton1(ByVal flag As Boolean)
        If gvClassList.RowCount > 0 Or tt1 = "Add" Then
            btnThem1.Enabled = flag
            btnSua1.Enabled = flag
            btnXoa1.Enabled = flag
            Button6.Enabled = flag
            btnGhi1.Enabled = Not flag
            btnKhongghi1.Enabled = Not flag
            'tabControl. = flag
        Else
            btnThem1.Enabled = True
            btnSua1.Enabled = False
            btnXoa1.Enabled = False
            btnGhi1.Enabled = False
            btnKhongghi1.Enabled = False
        End If

    End Sub

    Private Sub EnableControl1(ByVal flag As Boolean)
        txtClass_Code.ReadOnly = flag
        txtClass_Name.ReadOnly = flag
        txtClass_Note.ReadOnly = flag
    End Sub


#End Region

#Region "Tab Problem List"
    Private Sub dtProblemList_TableNewRow(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        e.Row("PROBLEM_ID") = Commons.clsTaoMa.RandomId("creatProblemID", "PROBLEM_LIST", "PROBLEM_ID", "PROBLEM")
    End Sub

    Private Sub btnThem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem2.Click
        iProblemList = gvProblemList.CurrentRow
        txtProblem_Name.Focus()
        tt2 = "Add"
        EnableButton2(False)
        EnableControl2(False)
        bindingProblemList.AddNew()
        gvProblemList.Enabled = False
    End Sub

    Private Sub btnSua2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua2.Click
        tt2 = "Edit"
        txtProblem_Name.Focus()
        iProblemList = gvProblemList.CurrentRow
        EnableButton2(False)
        EnableControl2(False)
        gvProblemList.Enabled = False
    End Sub

    Private Sub btnXoa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa2.Click
        Try
            If gvProblemList.RowCount <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCodulieudexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objPROBLEM_LIST_Controller As New PROBLEM_LIST_Controller()
                Dim result = objPROBLEM_LIST_Controller.DeletePROBLEM_LIST(gvProblemList.CurrentRow.Cells("PROBLEM_ID").Value.ToString())
                If result > 0 Then
                    bindingProblemList.Remove(bindingProblemList.Current)
                    bindingProblemList.EndEdit()
                    dtProblemList.AcceptChanges()
                    EnableButton2(True)
                    EnableControl2(True)
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdulieuKhongxoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    Exit Sub
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGhi2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi2.Click
        Try
            If txtProblem_Name.Text.Trim.Length <= 0 Then
                txtProblem_Name.Focus()
                Return
            End If
            If txtProblem_Code.Text.Trim.Length <= 0 Then
                txtProblem_Code.Focus()
                Return
            End If
            Dim objPROBLEM_LIST_Controller As New PROBLEM_LIST_Controller()
            Dim objProblemList As New PROBLEM_LIST_Info()
            objProblemList.PROBLEM_ID = gvProblemList.CurrentRow.Cells("PROBLEM_ID").Value
            objProblemList.PROBLEM_CODE = txtProblem_Code.Text
            objProblemList.PROBLEM_NAME = txtProblem_Name.Text
            objProblemList.PROBLEM_NOTE = txtProblemNote.Text
            If tt2 = "Add" Then
                If CheckExist(dtProblemList, "", "", "PROBLEM_CODE", txtProblem_Code.Text) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungProblemCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtProblem_Code.Focus()
                    Exit Sub
                End If
                objProblemList.PROBLEM_ID = Commons.clsTaoMa.RandomId("creatProblemID", "PROBLEM_LIST", "PROBLEM_ID", "PROBLEM")
                gvProblemList.CurrentRow.Cells("PROBLEM_ID").Value = objProblemList.PROBLEM_ID
                objPROBLEM_LIST_Controller.AddPROBLEM_LIST(objProblemList)
            Else
                If tt2 = "Edit" Then
                    If CheckExist(dtProblemList, "PROBLEM_ID", objProblemList.PROBLEM_ID, "PROBLEM_CODE", txtProblem_Code.Text) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungProblemCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        txtProblem_Code.Focus()
                        Exit Sub
                    End If
                    objPROBLEM_LIST_Controller.UpdatePROBLEM_LIST(objProblemList)
                End If
            End If
            bindingProblemList.EndEdit()
            dtProblemList.AcceptChanges()
            EnableButton2(True)
            EnableControl2(True)
            gvProblemList.Enabled = True
            tt2 = "None"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnKhongghi2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongghi2.Click
        Try

            tt2 = "None"
            bindingProblemList.CancelEdit()
            dtProblemList.RejectChanges()
            EnableButton2(True)
            EnableControl2(True)
            gvProblemList.Enabled = True

            If Not iProblemList.Equals(DBNull.Value) Then
                gvProblemList.CurrentCell = iProblemList.Cells("PROBLEM_CODE")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnableButton2(ByVal flag As Boolean)
        If gvProblemList.RowCount > 0 Or tt2 = "Add" Then
            btnThem2.Enabled = flag
            btnSua2.Enabled = flag
            btnXoa2.Enabled = flag
            btnThoat2.Enabled = flag
            btnGhi2.Enabled = Not flag
            btnKhongghi2.Enabled = Not flag
            'tabControl. = flag
        Else
            btnThem2.Enabled = True
            btnSua2.Enabled = False
            btnXoa2.Enabled = False
            btnGhi2.Enabled = False
            btnKhongghi2.Enabled = False
        End If
    End Sub
    Private Sub EnableControl2(ByVal flag As Boolean)
        txtProblem_Code.ReadOnly = flag
        txtProblem_Name.ReadOnly = flag
        txtProblemNote.ReadOnly = flag
    End Sub
#End Region

#Region "Tab Cause List"
    Private Sub dtCauseList_TableNewRow(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        e.Row("CAUSE_ID") = Commons.clsTaoMa.RandomId("creatCauseID", "CAUSE_LIST", "CAUSE_ID", "CAUSE")
    End Sub
    Private Sub btnThem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem3.Click
        iCauseList = gvCauseList.CurrentRow
        txtCause_Name.Focus()
        tt3 = "Add"
        EnableButton3(False)
        EnableControl3(False)
        bindingCauseList.AddNew()
        gvCauseList.Enabled = False
    End Sub

    Private Sub btnSua3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua3.Click
        tt3 = "Edit"
        txtCause_Name.Focus()
        iCauseList = gvCauseList.CurrentRow
        EnableButton3(False)
        EnableControl3(False)
        gvCauseList.Enabled = False
    End Sub

    Private Sub btnXoa3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa3.Click
        Try
            If gvCauseList.RowCount <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCodulieudexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objCAUSE_LIST_Controller As New CAUSE_LIST_Controller()
                Dim result = objCAUSE_LIST_Controller.DeleteCAUSE_LIST(gvCauseList.CurrentRow.Cells("CAUSE_ID").Value.ToString())
                If result > 0 Then
                    bindingCauseList.Remove(bindingCauseList.Current)
                    bindingCauseList.EndEdit()
                    dtCauseList.AcceptChanges()
                    EnableButton3(True)
                    EnableControl3(True)
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdulieuKhongxoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    Exit Sub
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGhi3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi3.Click
        Try
            If txtCause_Name.Text.Trim.Length <= 0 Then
                txtCause_Name.Focus()
                Return
            End If
            If txtCause_Code.Text.Trim.Length <= 0 Then
                txtCause_Code.Focus()
                Return
            End If
            Dim objCAUSE_LIST_Controller As New CAUSE_LIST_Controller()
            Dim objCauseList As New CAUSE_LIST_Info()
            objCauseList.CAUSE_ID = gvCauseList.CurrentRow.Cells("CAUSE_ID").Value
            objCauseList.CAUSE_CODE = txtCause_Code.Text
            objCauseList.CAUSE_NAME = txtCause_Name.Text
            objCauseList.CAUSE_NOTE = txtProblemNote.Text
            If tt3 = "Add" Then
                If CheckExist(dtCauseList, "", "", "CAUSE_CODE", txtCause_Code.Text) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungCAUSECode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtCause_Code.Focus()
                    Exit Sub
                End If
                objCauseList.CAUSE_ID = Commons.clsTaoMa.RandomId("creatCauseID", "CAUSE_LIST", "CAUSE_ID", "CAUSE")
                gvCauseList.CurrentRow.Cells("CAUSE_ID").Value = objCauseList.CAUSE_ID
                objCAUSE_LIST_Controller.AddCAUSE_LIST(objCauseList)
            Else
                If tt2 = "Edit" Then
                    If CheckExist(dtCauseList, "CAUSE_ID", objCauseList.CAUSE_ID, "CAUSE_CODE", txtCause_Code.Text) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungCAUSECode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        txtCause_Code.Focus()
                        Exit Sub
                    End If
                    objCAUSE_LIST_Controller.UpdateCAUSE_LIST(objCauseList)
                End If
            End If
            bindingCauseList.EndEdit()
            dtCauseList.AcceptChanges()
            EnableButton3(True)
            EnableControl3(True)
            gvCauseList.Enabled = True
            tt3 = "None"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnKhongghi3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongghi3.Click
        Try
            tt3 = "None"
            bindingCauseList.CancelEdit()
            dtCauseList.RejectChanges()
            EnableButton3(True)
            EnableControl3(True)
            gvCauseList.Enabled = True

            If Not iCauseList.Equals(DBNull.Value) Then
                gvCauseList.CurrentCell = iCauseList.Cells("CAUSE_CODE")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnableButton3(ByVal flag As Boolean)
        If gvCauseList.RowCount > 0 Or tt3 = "Add" Then
            btnThem3.Enabled = flag
            btnSua3.Enabled = flag
            btnXoa3.Enabled = flag
            btnThoat3.Enabled = flag
            btnGhi3.Enabled = Not flag
            btnKhongghi3.Enabled = Not flag
            'tabControl. = flag
        Else
            btnThem3.Enabled = True
            btnSua3.Enabled = False
            btnXoa3.Enabled = False
            btnGhi3.Enabled = False
            btnKhongghi3.Enabled = False
        End If
    End Sub
    Private Sub EnableControl3(ByVal flag As Boolean)
        txtCause_Code.ReadOnly = flag
        txtCause_Name.ReadOnly = flag
        txtCause_Note.ReadOnly = flag
    End Sub
#End Region

#Region "Tab Remedy List"
    Private Sub dtRemedyList_TableNewRow(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        Try
            e.Row("REMEDY_ID") = Commons.clsTaoMa.RandomId("creatRemedyID", "REMEDY_CAUSE", "REMEDY_ID", "REMEDY")
            e.Row("CAUSE_ID") = cboRemedy_Cause.SelectedValue
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnThem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem4.Click
        iRemedy = gvRemedyCause.CurrentRow
        txtRemedy_Name.Focus()
        tt4 = "Add"
        EnableButton4(False)
        EnableControl4(False)
        bindingRemedyList.AddNew()
        gvRemedyCause.Enabled = False
    End Sub

    Private Sub btnSua4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua4.Click
        tt4 = "Edit"
        txtRemedy_Name.Focus()
        iRemedy = gvRemedyCause.CurrentRow
        EnableButton4(False)
        EnableControl4(False)
        gvRemedyCause.Enabled = False
    End Sub

    Private Sub btnXoa4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXoa4.Click
        Try
            If gvRemedyCause.RowCount <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCodulieudexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Dim objREMEDY_Controller As New REMEDY_CAUSE_Controller()
                Dim result = objREMEDY_Controller.DeleteREMEDY_CAUSE(cboRemedy_Cause.SelectedValue.ToString(), gvRemedyCause.CurrentRow.Cells("REMEDY_ID").Value.ToString())
                If result > 0 Then
                    bindingRemedyList.Remove(bindingRemedyList.Current)
                    bindingRemedyList.EndEdit()
                    dtRemedyList.AcceptChanges()
                    EnableButton4(True)
                    EnableControl4(True)
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgdulieudaphatsinh", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                End If
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdulieuKhongxoa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub btnGhi4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi4.Click
        Try
            If cboRemedy_Cause.SelectedIndex >= 0 Then
                If txtRemedy_Name.Text.Trim.Length <= 0 Then
                    txtRemedy_Name.Focus()
                    Return
                End If
                If txtRemedy_Code.Text.Trim.Length <= 0 Then
                    txtRemedy_Code.Focus()
                    Return
                End If
                If txtRemedy_Link.Text.Trim.Length <= 0 Then
                    txtRemedy_Link.Focus()
                    Return
                End If
                Dim objREMEDY_Controller As New REMEDY_CAUSE_Controller()
                Dim objRemedyList As New REMEDY_CAUSE_Info()
                objRemedyList.CAUSE_ID = cboRemedy_Cause.SelectedValue.ToString
                objRemedyList.REMEDY_ID = gvRemedyCause.CurrentRow.Cells("REMEDY_ID").Value
                objRemedyList.REMEDY_CODE = txtRemedy_Code.Text
                objRemedyList.REMEDY_NAME = txtRemedy_Name.Text
                objRemedyList.LINK = txtRemedy_Link.Text
                objRemedyList.NOTE = txtRemedy_Note.Text
                If tt4 = "Add" Then
                    If CheckExist(dtRemedyList, "", "", "REMEDY_CODE", txtRemedy_Code.Text) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungREMEDYCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        txtRemedy_Code.Focus()
                        Exit Sub
                    End If
                    objRemedyList.REMEDY_ID = Commons.clsTaoMa.RandomId("creatRemedyID", "REMEDY_CAUSE", "REMEDY_ID", "REMEDY")
                    gvRemedyCause.CurrentRow.Cells("REMEDY_ID").Value = objRemedyList.REMEDY_ID

                    objREMEDY_Controller.AddREMEDY_CAUSE(objRemedyList)
                Else
                    If tt4 = "Edit" Then
                        If CheckExist(dtRemedyList, "REMEDY_ID", objRemedyList.REMEDY_ID, "REMEDY_CODE", txtRemedy_Code.Text) Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgdTrungREMEDYCode", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                            txtRemedy_Code.Focus()
                            Exit Sub
                        End If
                        objREMEDY_Controller.UpdateREMEDY_CAUSE(objRemedyList)
                    End If
                End If
                bindingRemedyList.EndEdit()
                dtRemedyList.AcceptChanges()
                EnableButton4(True)
                EnableControl4(True)
                gvRemedyCause.Enabled = True
                tt4 = "None"

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnKhongGhi4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi4.Click
        Try
            tt4 = "None"
            bindingRemedyList.CancelEdit()
            dtRemedyList.RejectChanges()
            EnableButton4(True)
            EnableControl4(True)
            gvRemedyCause.Enabled = True

            If Not iRemedy.Equals(DBNull.Value) Then
                gvRemedyCause.CurrentCell = iRemedy.Cells("REMEDY_CODE")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboRemedy_Cause_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRemedy_Cause.SelectedIndexChanged
        Try
            dtRemedyList = (New REMEDY_CAUSE_Controller()).GetREMEDY_CAUSEs(cboRemedy_Cause.SelectedValue)
            bindingRemedyList.DataSource = dtRemedyList
            AddHandler dtRemedyList.TableNewRow, AddressOf dtRemedyList_TableNewRow
            txtRemedy_Code.DataBindings.Clear()
            txtRemedy_Code.DataBindings.Add("Text", bindingRemedyList, "REMEDY_CODE")
            txtRemedy_Name.DataBindings.Clear()
            txtRemedy_Name.DataBindings.Add("Text", bindingRemedyList, "REMEDY_NAME")
            txtRemedy_Link.DataBindings.Clear()
            txtRemedy_Link.DataBindings.Add("Text", bindingRemedyList, "LINK")
            txtRemedy_Note.DataBindings.Clear()
            txtRemedy_Note.DataBindings.Add("Text", bindingRemedyList, "NOTE")
            EnableButton4(True)
            EnableControl4(True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EnableButton4(ByVal flag As Boolean)
        If gvRemedyCause.RowCount > 0 Or tt4 = "Add" Then
            btnThem4.Enabled = flag
            btnSua4.Enabled = flag
            btnXoa4.Enabled = flag
            btnThoat4.Enabled = flag
            btnGhi4.Enabled = Not flag
            btnKhongGhi4.Enabled = Not flag
            'tabControl. = flag
        Else
            btnThem4.Enabled = True
            btnSua4.Enabled = False
            btnXoa4.Enabled = False
            btnGhi4.Enabled = False
            btnKhongGhi4.Enabled = False
            btnLinkRemedy.Enabled = False
        End If
    End Sub

    Private Sub EnableControl4(ByVal flag As Boolean)
        txtRemedy_Code.ReadOnly = flag
        txtRemedy_Name.ReadOnly = flag
        txtRemedy_Note.ReadOnly = flag
        txtRemedy_Link.ReadOnly = flag
        cboRemedy_Cause.Enabled = flag
    End Sub

    Private Sub btnLinkRemedy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkRemedy.Click, txtRemedy_Link.DoubleClick
        If Not btnThem4.Enabled Then
            ofdLink.ShowDialog()
        End If
    End Sub

    Private Sub ofdLink_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdLink.FileOk
        Try
            Dim strDuongDan As String = ""
            strDuongDan = Commons.Modules.ObjSystems.CapnhatTL(True, "REMEDY")
            strDuongDan = strDuongDan & "\REMEDY_" & DateTime.Now.Day & DateTime.Now.Month & DateTime.Now.Month & DateTime.Now.Hour & DateTime.Now.Minute & Commons.Modules.ObjSystems.LayDuoiFile(ofdLink.FileName)
            Commons.Modules.ObjSystems.LuuDuongDan(ofdLink.FileName, strDuongDan)
            txtRemedy_Link.Text = strDuongDan
        Catch ex As Exception

        End Try

    End Sub
#End Region


End Class