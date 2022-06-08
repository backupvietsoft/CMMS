Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmDanhmucngaynghi
    Dim act As String = "None"
    Dim dtNgaynghi As DataTable
    Dim index As Integer = 0
    Dim BindingNgaynghi As New BindingSource

    Private Sub EnableButton()
        If act = "None" Then
            If gvDanhsach.Rows.Count <= 0 Then
                txtGhichu.ReadOnly = True
                dtpNgay.Enabled = False
                gvDanhsach.Enabled = False
                btnThem.Enabled = True
                btnSua.Enabled = False
                btnGhi.Enabled = False
                btnKhongghi.Enabled = False
                btnXoa.Enabled = False
            Else
                txtGhichu.ReadOnly = True
                dtpNgay.Enabled = False
                gvDanhsach.Enabled = True
                btnThem.Enabled = True
                btnSua.Enabled = True
                btnGhi.Enabled = False
                btnKhongghi.Enabled = False
                btnXoa.Enabled = True
            End If
        Else
            If act = "Add" Or act = "Edit" Then
                txtGhichu.ReadOnly = False
                dtpNgay.Enabled = True
                gvDanhsach.Enabled = False
                btnThem.Enabled = False
                btnSua.Enabled = False
                btnGhi.Enabled = True
                btnKhongghi.Enabled = True
                btnXoa.Enabled = False
            End If
            If act = "Edit" Then
                dtpNgay.Enabled = False
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
            BindingNgaynghi.AddNew()
            If BindingNgaynghi.Count = 0 Then
                dtpNgay.Value = DateTime.Now
                dtpNgay.Focus()
            End If
            'gvDanhsach.Rows(gvDanhsach.NewRowIndex).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        act = "Edit"
        If gvDanhsach.Rows.Count > 0 Then
            index = gvDanhsach.CurrentCell.RowIndex
        End If
        EnableButton()
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        act = "None"
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCheckDelete", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            If gvDanhsach.Rows.Count > 0 Then
                index = gvDanhsach.CurrentCell.RowIndex

                Try
                    Dim result As Integer

                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_NGAY_NGHI_LOG", dtpNgay.Value.ToShortDateString, Me.Name, Commons.Modules.UserName, 3)
                    result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DELETE_NGAY_NGHI", dtpNgay.Value.ToShortDateString())
                    If result = 1 Then
                        BindingNgaynghi.RemoveCurrent()
                        dtNgaynghi.AcceptChanges()
                        If dtNgaynghi.Rows.Count = 0 Then
                            gvDanhsach.DataSource = BindingNgaynghi
                        End If
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongthexoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                Catch
                End Try
                EnableButton()
            End If
        End If


    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        If txtGhichu.Text.Trim = String.Empty Or txtGhichu.Text.Trim.Length <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhichukhongduocdetrong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtGhichu.Focus()
            Exit Sub
        End If

        Try

            If act = "Add" Then
                Dim result As Integer
                result = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GET_NGAY_NGHI", dtpNgay.Value.ToShortDateString())
                If result = 1 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaynghidatontai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "INSERT_NGAY_NGHI", dtpNgay.Value.ToShortDateString, txtGhichu.Text.Trim())

                If result = 1 Then
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_NGAY_NGHI_LOG", dtpNgay.Value.ToShortDateString, Me.Name, Commons.Modules.UserName, 1)
                    act = "None"
                    EnableButton()
                    BindingNgaynghi.EndEdit()
                    dtNgaynghi.AcceptChanges()

                    'For i As Integer = 0 To gvDanhsach.Rows.Count
                    '    If DateTime.Parse(gvDanhsach.Rows(i).Cells("NGAY").ToString).ToShortDateString() = dtpNgay.Value.ToShortDateString Then
                    '        gvDanhsach.Rows(i).Cells(0).Selected = True
                    '        Exit Try
                    '    End If
                    'Next
                Else
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaynghidatontai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            Else
                If act = "Edit" Then
                    Dim result As Integer
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_NGAY_NGHI_LOG", dtpNgay.Value.ToShortDateString, Me.Name, Commons.Modules.UserName, 2)
                    result = SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_NGAY_NGHI", dtpNgay.Value.ToShortDateString, txtGhichu.Text.Trim())
                    If result = 1 Then
                        act = "None"
                        EnableButton()
                        BindingNgaynghi.EndEdit()
                        dtNgaynghi.AcceptChanges()
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongtheluu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                End If
            End If

            gvDanhsach.AllowUserToAddRows = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongghi.Click
        act = "None"
        BindingNgaynghi.CancelEdit()
        If gvDanhsach.Rows.Count > 0 And index >= 0 Then
            gvDanhsach.ClearSelection()
            gvDanhsach.Rows(index).Cells(0).Selected = True
        End If
        EnableButton()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Dispose()
    End Sub

    Private Sub frmDanhmucngaynghi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtNgaynghi = New DataTable()
        dtpNgay.Value = DateTime.Now
        LoadNgaynghi()
        BindData()
        EnableButton()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnSua.Enabled = False
            btnThem.Enabled = False
            btnXoa.Enabled = False
        End If
    End Sub

    Private Sub LoadNgaynghi()
        Me.gvDanhsach.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        Me.gvDanhsach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Dim cl1 As New DataGridViewTextBoxColumn()

        cl1.Name = "NGAY"
        cl1.DataPropertyName = "NGAY"
        cl1.ReadOnly = True
        cl1.DefaultCellStyle.Format = "dd/MM/yyyy"
        cl1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
        gvDanhsach.Columns.Insert(0, cl1)

        Dim cl2 As New DataGridViewTextBoxColumn()
        cl2.Name = "GHI_CHU"
        cl2.DataPropertyName = "GHI_CHU"
        cl2.ReadOnly = True
        cl2.Width = 300
        cl2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        gvDanhsach.Columns.Insert(1, cl2)

        gvDanhsach.AutoGenerateColumns = True

        dtNgaynghi.Rows.Clear()
        dtNgaynghi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_NGAY_NGHIs"))
        BindingNgaynghi.DataSource = dtNgaynghi
        gvDanhsach.DataSource = BindingNgaynghi
    End Sub

    Sub BindData()
        Try
            dtpNgay.DataBindings.Clear()
            dtpNgay.DataBindings.Add("Value", BindingNgaynghi, "NGAY", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "dd/MM/yyyy")
            txtGhichu.DataBindings.Clear()
            txtGhichu.DataBindings.Add("text", BindingNgaynghi, "GHI_CHU", True, DataSourceUpdateMode.OnPropertyChanged)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvDanhsach_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gvDanhsach.DataError
        e.Cancel = True
    End Sub
End Class