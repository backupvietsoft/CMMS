Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Public Class frmChiPhiTheoThang

    Dim action As String = "None"
    Dim dtChiphi As New DataTable
    Private BindingChiphi As New BindingSource
    Dim index As Integer
    Private Sub frmChiPhiTheoThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        GetBPCP()
        LoadNgoaite()
        LoadData()
        BindData()
        EnableButton()
        LockControl(True)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThem.Enabled = False
            btnSua.Enabled = False
            btnXoa.Enabled = False
        End If
    End Sub


    Private Sub GetBPCP()
        Dim dtBPCP As New DataTable
        dtBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GetBO_PHAN_CHIU_PHIs"))
        cbMSBPCP.DataSource = dtBPCP
        cbMSBPCP.DisplayMember = "TEN_BP_CHIU_PHI"
        cbMSBPCP.ValueMember = "MS_BP_CHIU_PHI"
    End Sub

    Sub BindData()
        Try

            cbMSBPCP.DataBindings.Clear()
            cbMSBPCP.DataBindings.Add("SelectedValue", BindingChiphi, "MS_BO_PHAN_CHIU_PHI", True, DataSourceUpdateMode.OnPropertyChanged)
            txtThang.DataBindings.Clear()
            txtThang.DataBindings.Add("text", BindingChiphi, "THANG", True, DataSourceUpdateMode.OnPropertyChanged)
            txtChiphiHDBT.DataBindings.Clear()
            txtChiphiHDBT.DataBindings.Add("text", BindingChiphi, "CHI_PHI_HDBT", True, DataSourceUpdateMode.OnPropertyChanged)
            txtChiphilapdat.DataBindings.Clear()
            txtChiphilapdat.DataBindings.Add("text", BindingChiphi, "CHI_PHI_LAP_DAT", True, DataSourceUpdateMode.OnPropertyChanged)
            cboNgoaite.DataBindings.Clear()
            cboNgoaite.DataBindings.Add("SelectedValue", BindingChiphi, "NGOAI_TE", True, DataSourceUpdateMode.OnPropertyChanged)
            txtTygia.DataBindings.Clear()
            txtTygia.DataBindings.Add("text", BindingChiphi, "TY_GIA", False, DataSourceUpdateMode.OnPropertyChanged)
            txtTygiaUSD.DataBindings.Clear()
            txtTygiaUSD.DataBindings.Add("text", BindingChiphi, "TY_GIA_USD", False, DataSourceUpdateMode.OnPropertyChanged)
            txtGhichu.DataBindings.Clear()
            txtGhichu.DataBindings.Add("text", BindingChiphi, "GHI_CHU", True, DataSourceUpdateMode.OnPropertyChanged)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadNgoaite()
        Dim dtNgoaite As New DataTable
        dtNgoaite.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_Y_GET_NGOAI_TE"))
        dtNgoaite.DefaultView.Sort = "MAC_DINH"
        cboNgoaite.DataSource = dtNgoaite.DefaultView
        cboNgoaite.DisplayMember = "TEN_NGOAI_TE"
        cboNgoaite.ValueMember = "NGOAI_TE"
    End Sub

    Private Sub LoadData()
        Me.gvChiphithang.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        Me.gvChiphithang.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Dim cl1 As New DataGridViewTextBoxColumn()

        cl1.Name = "TEN_BP_CHIU_PHI"
        cl1.DataPropertyName = "TEN_BP_CHIU_PHI"
        cl1.ReadOnly = True
        cl1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BP_CHIU_PHI", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(0, cl1)


        Dim cl2 As New DataGridViewTextBoxColumn()
        cl2.Name = "MS_BO_PHAN_CHIU_PHI"
        cl2.DataPropertyName = "MS_BO_PHAN_CHIU_PHI"
        cl2.ReadOnly = True
        cl2.Visible = False
        cl2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN_CHIU_PHI", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(1, cl2)

        Dim cl3 As New DataGridViewTextBoxColumn()
        cl3.Name = "THANG"
        cl3.DataPropertyName = "THANG"
        cl3.ReadOnly = True
        cl3.DefaultCellStyle.Format = "MM/yyyy"
        cl3.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANG", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(2, cl3)

        Dim cl4 As New DataGridViewTextBoxColumn()
        cl4.Name = "CHI_PHI_HDBT"
        cl4.DataPropertyName = "CHI_PHI_HDBT"
        cl4.ReadOnly = True
        cl4.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHI_PHI_HDBT", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(3, cl4)


        Dim cl5 As New DataGridViewTextBoxColumn()
        cl5.Name = "CHI_PHI_LAP_DAT"
        cl5.DataPropertyName = "CHI_PHI_LAP_DAT"
        cl5.ReadOnly = True
        cl5.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHI_PHI_LAP_DAT", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(4, cl5)

        Dim cl6 As New DataGridViewTextBoxColumn()
        cl6.Name = "NGOAI_TE"
        cl6.DataPropertyName = "NGOAI_TE"
        cl6.ReadOnly = True
        cl6.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGOAI_TE", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(5, cl6)

        Dim cl7 As New DataGridViewTextBoxColumn()
        cl7.Name = "TY_GIA"
        cl7.DataPropertyName = "TY_GIA"
        cl7.ReadOnly = True
        cl7.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(6, cl7)

        Dim cl8 As New DataGridViewTextBoxColumn()
        cl8.Name = "TY_GIA_USD"
        cl8.DataPropertyName = "TY_GIA_USD"
        cl8.ReadOnly = True
        cl8.DefaultCellStyle.Format = "N6"
        cl8.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA_USD", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(7, cl8)

        Dim cl9 As New DataGridViewTextBoxColumn()
        cl9.Name = "GHI_CHU"
        cl9.DataPropertyName = "GHI_CHU"
        cl9.ReadOnly = True
        cl9.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        gvChiphithang.Columns.Insert(8, cl9)

        gvChiphithang.AutoGenerateColumns = False

        dtChiphi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GetCHI_PHI_THEO_THANGs"))
        BindingChiphi.DataSource = dtChiphi
        gvChiphithang.DataSource = BindingChiphi

    End Sub

    Private Sub LockControl(ByVal lock As Boolean)
        cbMSBPCP.Enabled = Not lock
        txtChiphiHDBT.ReadOnly = lock
        txtChiphilapdat.ReadOnly = lock
        txtGhichu.ReadOnly = lock
        txtThang.Enabled = Not lock
        cboNgoaite.Enabled = Not lock
        txtTygia.ReadOnly = lock
        txtTygiaUSD.ReadOnly = lock
        gvChiphithang.Enabled = lock
    End Sub

    Sub EnableButton()
        btnThoat.Enabled = True
        LockControl(True)
        gvChiphithang.AllowUserToAddRows = False
        If action = "None" Then
            btnThem.Enabled = True
            btnSua.Enabled = True
            btnXoa.Enabled = True
            btnGhi.Enabled = False
            btnKhongghi.Enabled = False
            If gvChiphithang.Rows.Count <= 0 Or cbMSBPCP.SelectedIndex < 0 Then
                btnSua.Enabled = False
                btnXoa.Enabled = False
            End If
            LockControl(True)
        Else
            If action = "Add" Or action = "Edit" Then
                btnThem.Enabled = False
                btnSua.Enabled = False
                btnXoa.Enabled = False
                btnGhi.Enabled = True
                btnKhongghi.Enabled = True
                LockControl(False)
            End If
        End If
    End Sub

    Sub ClearControl()
        cbMSBPCP.SelectedIndex = 0
        cboNgoaite.SelectedValue = 0
        txtChiphiHDBT.Text = ""
        txtChiphilapdat.Text = ""
        txtGhichu.Text = ""
        txtThang.Text = DateTime.Now
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        action = "Add"
        If gvChiphithang.Rows.Count > 0 Then
            index = gvChiphithang.CurrentCell.RowIndex
        End If
        EnableButton()
        'gvChiphithang.AllowUserToAddRows = True
        'Dim row As DataRow = dtChiphi.NewRow()
        'row("TEN_BP_CHIU_PHI") = ""
        'row("MS_BO_PHAN_CHIU_PHI") = -1
        'row("THANG") = DateTime.Now
        'dtChiphi.Rows.Add(row)
        ClearControl()
        gvChiphithang.ClearSelection()
        'gvChiphithang.Rows(gvChiphithang.NewRowIndex).Cells(0).Selected = True
        BindingChiphi.AddNew()

    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If gvChiphithang.Rows.Count > 0 Then
            index = gvChiphithang.CurrentCell.RowIndex
        Else
            Exit Sub
        End If
        action = "Edit"
        EnableButton()
        cbMSBPCP.Enabled = False
        txtThang.Enabled = False
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try

            If cbMSBPCP.SelectedIndex < 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonBPCP", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cbMSBPCP.Focus()
                Exit Sub
            End If
            If txtChiphiHDBT.Text.Trim() = String.Empty Or txtChiphiHDBT.Text = "" Or Double.Parse(txtChiphiHDBT.Text.Trim) <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChiphiHDBTkodung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtChiphiHDBT.Focus()
                Exit Sub
            End If
            If txtChiphilapdat.Text.Trim() = String.Empty Or txtChiphilapdat.Text = "" Or Double.Parse(txtChiphilapdat.Text.Trim) <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChiphilapdatkodung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtChiphilapdat.Focus()
                Exit Sub
            End If
            If txtThang.Text.Trim() = "\" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgThangkodung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtThang.Focus()
                Exit Sub
            End If
            If cboNgoaite.SelectedIndex < 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuachonngoaite", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cboNgoaite.Focus()
                Exit Sub
            End If
            Try
                txtTygia.Text = Double.Parse(txtTygia.Text).ToString
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiakhongdung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtTygia.Focus()
            End Try
            Try
                txtTygiaUSD.Text = Double.Parse(txtTygiaUSD.Text).ToString
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiakhongdung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtTygiaUSD.Focus()
            End Try

            If txtTygia.Text.Trim() = String.Empty Or txtTygia.Text = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiakhongdung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtTygia.Focus()
                Exit Sub
            End If
            If txtTygiaUSD.Text.Trim() = String.Empty Or txtTygiaUSD.Text = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiaUSDkhongdung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtTygiaUSD.Focus()
                Exit Sub
            End If
            Dim msbpcp As Integer = cbMSBPCP.SelectedValue
            Dim thang As DateTime = New DateTime(txtThang.Value.Year, txtThang.Value.Month, 1)
            Dim nhdbt As Double = Double.Parse(txtChiphiHDBT.Text.Trim())
            Dim nlapdat As Double = Double.Parse(txtChiphilapdat.Text.Trim())
            Dim tygia As Double = Double.Parse(txtTygia.Text.Trim)
            Dim tygiaUsd As Double = Double.Parse(txtTygiaUSD.Text.Trim)
            Try

                If action = "Add" Then
                    Dim result As Integer
                    result = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GET_CHI_PHI_THEO_THANG", msbpcp, thang)
                    If result = 0 Then

                        result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "INSERT_CHI_PHI_THEO_THANG", msbpcp, thang, nhdbt, nlapdat, cboNgoaite.SelectedValue, tygia, tygiaUsd, txtGhichu.Text.Trim())
                        INSERT_CHI_PHI_THEO_THANG(msbpcp, thang, nhdbt, nlapdat, cboNgoaite.SelectedValue, tygia, tygiaUsd, txtGhichu.Text.Trim())
                        If result = 1 Then
                            action = "None"
                            EnableButton()
                            'dtChiphi.AcceptChanges()
                            dtChiphi.Clear()
                            dtChiphi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GetCHI_PHI_THEO_THANGs"))
                            BindingChiphi.DataSource = dtChiphi
                            gvChiphithang.DataSource = BindingChiphi

                            For i As Integer = 0 To gvChiphithang.RowCount - 1
                                If gvChiphithang.Rows(i).Cells("MS_BO_PHAN_CHIU_PHI").Value.ToString = msbpcp And gvChiphithang.Rows(i).Cells("THANG").Value.ToString = thang Then
                                    gvChiphithang.Rows(i).Cells(0).Selected = True
                                    Exit For
                                End If
                            Next

                        End If
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChiphidaduoctinhchobophannay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If

                Else
                    If action = "Edit" Then
                        Dim result As Integer
                        Update_CHI_PHI_THEO_THANG(msbpcp, thang, nhdbt, nlapdat, cboNgoaite.SelectedValue, txtTygia.Text.Trim(), txtTygiaUSD.Text.Trim(), txtGhichu.Text.Trim())
                        result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "Update_CHI_PHI_THEO_THANG", msbpcp, thang, nhdbt, nlapdat, cboNgoaite.SelectedValue, txtTygia.Text.Trim(), txtTygiaUSD.Text.Trim(), txtGhichu.Text.Trim())
                        If result = 1 Then
                            action = "None"
                            EnableButton()
                            dtChiphi.AcceptChanges()
                            'BindData()
                        End If
                    End If
                End If
                BindingChiphi.EndEdit()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            dtChiphi.RejectChanges()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongtheluu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub
    Private Sub Update_CHI_PHI_THEO_THANG(ByVal msbpcp As String, ByVal thang As String, ByVal nhdbt As Double, ByVal nlapdat As Double, ByVal ngoaite As String, ByVal tygia As Double, ByVal tygiaUsd As Double, ByVal GhiChu As String)
        Try
            Dim SQL = "EXEC UPDATE_CHI_PHI_THEO_THANG_LOG '" & msbpcp & "','" & Format(CDate(thang), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',2"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub INSERT_CHI_PHI_THEO_THANG(ByVal msbpcp As String, ByVal thang As String, ByVal nhdbt As Double, ByVal nlapdat As Double, ByVal ngoaite As String, ByVal tygia As Double, ByVal tygiaUsd As Double, ByVal GhiChu As String)
        Try
            Dim SQL = "EXEC UPDATE_CHI_PHI_THEO_THANG_LOG '" & msbpcp & "','" & Format(CDate(thang), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        Catch ex As Exception

        End Try
    End Sub

    Public Function IsPositiveNumber(ByVal strNumber As String) As Boolean
        Dim objNotPositivePattern As New System.Text.RegularExpressions.Regex("[^0-9.]")
        Dim objPositivePattern As New System.Text.RegularExpressions.Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$")
        Dim objTwoDotPattern As New System.Text.RegularExpressions.Regex("[0-9]*[.][0-9]*[.][0-9]*")
        Return Not objNotPositivePattern.IsMatch(strNumber) And objPositivePattern.IsMatch(strNumber) And Not objTwoDotPattern.IsMatch(strNumber)
    End Function



    Private Sub btnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongghi.Click
        Try
            dtChiphi.RejectChanges()
            BindingChiphi.CancelEdit()
            action = "None"
            BindData()
            If index >= 0 Then
                gvChiphithang.Rows(index).Cells(0).Selected = True
            End If
            EnableButton()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        Dim msbpcp As Integer = cbMSBPCP.SelectedValue
        Dim thang As DateTime = txtThang.Value
        If Vietsoft.Information.MsgBox(Me, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then

            Try
                Dim result As Integer
                Try
                    Dim SQL = "EXEC UPDATE_CHI_PHI_THEO_THANG_LOG '" & msbpcp & "','" & Format(CDate(thang), "MM/dd/yyyy") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
                Catch ex As Exception

                End Try
                result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DELETE_CHI_PHI_THEO_THANG", msbpcp, thang)
                
                If result = 1 Then
                    action = "None"
                    EnableButton()
                    dtChiphi.Clear()
                    dtChiphi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GetCHI_PHI_THEO_THANGs"))
                    gvChiphithang.DataSource = dtChiphi
                    'BindData()
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongthexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            Catch
            End Try
        End If
    End Sub
   
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub txtChiphiHDBT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChiphiHDBT.KeyDown
        If (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtChiphiHDBT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtChiphiHDBT.Validating
        If txtChiphiHDBT.Text.Trim <> String.Empty Then
            Try
                Convert.ToDouble(txtChiphiHDBT.Text.Trim())
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChiphiHDBTkodung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub txtChiphilapdat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChiphilapdat.KeyDown
        If (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtChiphilapdat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtChiphilapdat.Validating
        If txtChiphilapdat.Text.Trim <> String.Empty Then
            Try
                Convert.ToDouble(txtChiphilapdat.Text.Trim())
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChiphilapdatkodung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub cboNgoaite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNgoaite.SelectedIndexChanged
        Try
            If action = "Add" Or action = "Edit" Then
                If cboNgoaite.SelectedIndex >= 0 Then
                    Dim dtNgoaite As New DataTable
                    dtNgoaite.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_Y_GET_TY_GIA_NGOAI_TE", cboNgoaite.SelectedValue.ToString))
                    If dtNgoaite.Rows.Count > 0 Then
                        txtTygia.Text = Double.Parse(dtNgoaite.Rows(0)("TI_GIA").ToString()).ToString("N", System.Globalization.CultureInfo.InvariantCulture())
                        txtTygiaUSD.Text = Double.Parse(dtNgoaite.Rows(0)("TI_GIA_USD").ToString()).ToString("N6", System.Globalization.CultureInfo.InvariantCulture())
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    
End Class