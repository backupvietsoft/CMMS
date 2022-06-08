Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmCONGNHAN_BPCP
    Dim act As String = "None"
    Dim dtCN_BPCP As DataTable
    Dim index As Integer = 0
    Dim BindingCN_BPCP As New BindingSource
    Dim mscn1 As String
    Dim msbpcp1 As String
    Dim thang1 As String

    Private Sub EnableButton()
        If act = "None" Then
            If gvDanhsach.Rows.Count <= 0 Then
                cbBophan.Visible = False
                cbCongnhan.Visible = False
                dtpNgay.Visible = False
                gvDanhsach.Enabled = False
                btnThem.Visible = True
                btnSua.Visible = False
                btnGhi.Visible = False
                btnKhongghi.Visible = False
                btnXoa.Visible = False
                btnThoat.Visible = False
            Else
                cbBophan.Visible = False
                cbCongnhan.Visible = False
                dtpNgay.Visible = False
                gvDanhsach.Enabled = True
                btnThem.Visible = True
                btnSua.Visible = True
                btnGhi.Visible = False
                btnKhongghi.Visible = False
                btnXoa.Visible = True
                btnThoat.Visible = True
            End If
        Else
            If act = "Add" Or act = "Edit" Then
                cbBophan.Visible = True
                cbCongnhan.Visible = True
                dtpNgay.Visible = True
                gvDanhsach.Enabled = False
                btnThem.Visible = False
                btnSua.Visible = False
                btnGhi.Visible = True
                btnKhongghi.Visible = True
                btnXoa.Visible = False
                btnThoat.Visible = False
            End If
        End If
    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click
        Try
            act = "Add"
            EnableButton()
            If gvDanhsach.Rows.Count > 0 Then
                index = gvDanhsach.CurrentRow.Index
            End If
            gvDanhsach.ClearSelection()
            BindingCN_BPCP.AddNew()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        act = "Edit"
        mscn1 = cbCongnhan.SelectedValue.ToString
        msbpcp1 = cbBophan.SelectedValue.ToString
        thang1 = dtpNgay.Value.ToShortDateString
        If gvDanhsach.Rows.Count > 0 Then
            index = gvDanhsach.CurrentCell.RowIndex
        End If
        EnableButton()
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        act = "None"
        If Vietsoft.Information.MsgBox(Me, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            EnableButton()
            If gvDanhsach.Rows.Count > 0 Then
                index = gvDanhsach.CurrentCell.RowIndex

                Try
                    Dim result As Integer
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_BO_PHAN_CHIU_PHI_LOG", cbCongnhan.SelectedValue.ToString(), cbBophan.SelectedValue.ToString(), dtpNgay.Value, Me.Name, Commons.Modules.UserName, 3)
                    result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DELETE_CONGNHAN_BPCP", cbCongnhan.SelectedValue.ToString(), cbBophan.SelectedValue.ToString(), dtpNgay.Value)
                    If result = 1 Then
                        BindingCN_BPCP.RemoveCurrent()
                        ' gvDanhsach.Rows(index - 1).Cells(0).Selected = True
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongthexoa", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                Catch
                End Try

            End If
        End If
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        If cbCongnhan.SelectedIndex < 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChonCongnhan", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            cbCongnhan.Focus()
            Exit Sub
        End If
        If cbBophan.SelectedIndex < 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChonBPCP", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            cbBophan.Focus()
            Exit Sub
        End If

        Try
            Dim mscn As String = cbCongnhan.SelectedValue.ToString
            Dim msbpcp As String = cbBophan.SelectedValue.ToString
            Dim thang As String = dtpNgay.Value.ToShortDateString
            If act = "Add" Then
                Dim result As Integer
                result = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GET_CONGNHAN_PBCP", cbCongnhan.SelectedValue.ToString(), cbBophan.SelectedValue.ToString(), dtpNgay.Value)
                If result = 1 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNgaynghidatontai", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "INSERT_CONGNHAN_BPCP", cbCongnhan.SelectedValue.ToString(), cbBophan.SelectedValue.ToString(), dtpNgay.Value)

                If result = 1 Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_BO_PHAN_CHIU_PHI_LOG", cbCongnhan.SelectedValue.ToString(), cbBophan.SelectedValue.ToString(), dtpNgay.Value, Me.Name, Commons.Modules.UserName, 2)
                    act = "None"
                    dtCN_BPCP.Clear()
                    dtCN_BPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_CONGNHAN_BPCPs"))
                    BindingCN_BPCP.DataSource = dtCN_BPCP
                    gvDanhsach.DataSource = BindingCN_BPCP
                    gvDanhsach.ClearSelection()
                    For i As Integer = 0 To gvDanhsach.RowCount - 1
                        If gvDanhsach.Rows(i).Cells("MS_CONG_NHAN").Value.ToString = mscn And DateTime.Parse(gvDanhsach.Rows(i).Cells("NGAY_NHAP").Value.ToString).ToShortDateString = thang And gvDanhsach.Rows(i).Cells("MS_BO_PHAN_CHIU_PHI").Value.ToString = msbpcp Then
                            gvDanhsach.Rows(i).Cells(0).Selected = True
                            Exit For
                        End If
                    Next
                    EnableButton()
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaynghidatontai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            Else
                If act = "Edit" Then
                    Dim result As Integer
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_BO_PHAN_CHIU_PHI_LOG", mscn1, msbpcp1, dtpNgay.Value, Me.Name, Commons.Modules.UserName, 3)
                    result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DELETE_CONGNHAN_BPCP", mscn1, msbpcp1, dtpNgay.Value)
                    If result = 1 Then
                        result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "INSERT_CONGNHAN_BPCP", mscn, msbpcp, dtpNgay.Value)

                        If result = 1 Then
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_BO_PHAN_CHIU_PHI_LOG", mscn1, msbpcp1, dtpNgay.Value, Me.Name, Commons.Modules.UserName, 1)
                            act = "None"
                            dtCN_BPCP.Clear()
                            dtCN_BPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_CONGNHAN_BPCPs"))
                            BindingCN_BPCP.DataSource = dtCN_BPCP
                            gvDanhsach.DataSource = BindingCN_BPCP
                            For i As Integer = 0 To gvDanhsach.RowCount - 1
                                If gvDanhsach.Rows(i).Cells("MS_CONG_NHAN").Value.ToString = mscn And DateTime.Parse(gvDanhsach.Rows(i).Cells("NGAY_NHAP").Value.ToString).ToShortDateString = thang And gvDanhsach.Rows(i).Cells("MS_BO_PHAN_CHIU_PHI").Value.ToString = msbpcp Then
                                    gvDanhsach.ClearSelection()
                                    gvDanhsach.Rows(i).Cells(0).Selected = True
                                    Exit For
                                End If
                            Next
                            EnableButton()
                        End If
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongtheluu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                End If
            End If
            BindingCN_BPCP.EndEdit()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongghi.Click
        act = "None"
        BindingCN_BPCP.CancelEdit()
        If gvDanhsach.Rows.Count > 0 And index >= 0 Then
            gvDanhsach.ClearSelection()
            gvDanhsach.Rows(index).Cells(0).Selected = True
        End If
        EnableButton()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Dispose()
    End Sub

    Private Sub frmCONGNHAN_BPCP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtCN_BPCP = New DataTable()
        dtpNgay.Value = DateTime.Now
        LoadDanhsach()
        LoadCongnhan()
        LoadBPCP()
        BindData()
        EnableButton()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThem.Enabled = False
            btnSua.Enabled = False
            btnXoa.Enabled = False
        End If


    End Sub

    Private Sub LoadCongnhan()
        Dim dtCongnhan As New DataTable
        dtCongnhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GetCONG_NHANs"))
        cbCongnhan.DataSource = dtCongnhan
        cbCongnhan.DisplayMember = "HO_TEN_CONG_NHAN"
        cbCongnhan.ValueMember = "MS_CONG_NHAN"
    End Sub

    Private Sub LoadBPCP()
        Dim dtBPCP As New DataTable
        dtBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GetBO_PHAN_CHIU_PHIs"))
        cbBophan.DataSource = dtBPCP
        cbBophan.DisplayMember = "TEN_BP_CHIU_PHI"
        cbBophan.ValueMember = "MS_BP_CHIU_PHI"
    End Sub

    Private Sub LoadDanhsach()
        Me.gvDanhsach.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        Me.gvDanhsach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        dtCN_BPCP.Clear()
        BindingCN_BPCP = New BindingSource()
        gvDanhsach.DataSource = DBNull.Value

        Dim cl4 As New DataGridViewTextBoxColumn()
        cl4.Name = "MS_CONG_NHAN"
        cl4.DataPropertyName = "MS_CONG_NHAN"
        cl4.ReadOnly = True
        cl4.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_CONG_NHAN", commons.Modules.TypeLanguage)
        gvDanhsach.Columns.Insert(0, cl4)

        Dim cl1 As New DataGridViewTextBoxColumn()
        cl1.Name = "TEN_CN"
        cl1.DataPropertyName = "TEN_CN"
        cl1.ReadOnly = True
        cl1.Width = 300
        cl1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_CN", commons.Modules.TypeLanguage)
        gvDanhsach.Columns.Insert(1, cl1)

        Dim cl2 As New DataGridViewTextBoxColumn()
        cl2.Name = "TEN_BP_CHIU_PHI"
        cl2.DataPropertyName = "TEN_BP_CHIU_PHI"
        cl2.ReadOnly = True
        cl1.Width = 300
        cl2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BP_CHIU_PHI", commons.Modules.TypeLanguage)
        gvDanhsach.Columns.Insert(2, cl2)

        Dim cl3 As New DataGridViewTextBoxColumn()
        cl3.Name = "NGAY_NHAP"
        cl3.DataPropertyName = "NGAY_NHAP"
        cl3.ReadOnly = True
        cl3.DefaultCellStyle.Format = "dd/MM/yyyy"
        cl3.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_NHAP", commons.Modules.TypeLanguage)
        gvDanhsach.Columns.Insert(3, cl3)

        Dim cl5 As New DataGridViewTextBoxColumn()
        cl5.Name = "MS_BO_PHAN_CHIU_PHI"
        cl5.DataPropertyName = "MS_BO_PHAN_CHIU_PHI"
        cl5.Visible = False
        cl5.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN_CHIU_PHI", commons.Modules.TypeLanguage)
        gvDanhsach.Columns.Insert(4, cl5)

        gvDanhsach.AutoGenerateColumns = True

        dtCN_BPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_CONGNHAN_BPCPs"))
        BindingCN_BPCP.DataSource = dtCN_BPCP
        gvDanhsach.DataSource = BindingCN_BPCP
    End Sub

    Sub BindData()
        Try
            cbCongnhan.DataBindings.Clear()
            cbCongnhan.DataBindings.Add("SelectedValue", BindingCN_BPCP, "MS_CONG_NHAN", True, DataSourceUpdateMode.OnPropertyChanged)

            cbBophan.DataBindings.Clear()
            cbBophan.DataBindings.Add("SelectedValue", BindingCN_BPCP, "MS_BO_PHAN_CHIU_PHI", True, DataSourceUpdateMode.OnPropertyChanged)

            dtpNgay.DataBindings.Clear()
            dtpNgay.DataBindings.Add("value", BindingCN_BPCP, "NGAY_NHAP", True, DataSourceUpdateMode.OnPropertyChanged)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbCongnhan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCongnhan.SelectedIndexChanged

    End Sub

    Private Sub txtLoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If act = "None" Then
                dtCN_BPCP.DefaultView.RowFilter = "MS_CONG_NHAN LIKE '%" & txtLoc.Text.Trim & "%' OR TEN_CN LIKE '%" & txtLoc.Text.Trim & "%'"
                BindingCN_BPCP.DataSource = dtCN_BPCP.DefaultView
            End If
        End If
    End Sub

    Private Sub gvDanhsach_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvDanhsach.CellContentClick

    End Sub
End Class