Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Imports System.Windows.Forms
Public Class FrmCopyDecive
    Public MS_MAY As String = ""
    'Load form
    Private Sub FrmCopyDecive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            LoadData()
        Catch ex As Exception
        End Try
        If Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 53) = False Then optOption.Enabled = False

    End Sub
    'Load data

    Private Sub LoadData()
        Try
            grdMay.DataSource = Nothing

            Dim dt = New DataTable()
            If optOption.SelectedIndex = 0 Then
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_THIET_BI_COPY", MS_MAY, 0, Commons.Modules.UserName))
            Else
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "GET_THIET_BI_COPY", MS_MAY, 1, Commons.Modules.UserName))
            End If

            For Each cl As DataColumn In dt.Columns
                If cl.ColumnName.Trim().ToUpper().Equals("CHON") Then
                    cl.ReadOnly = False
                Else
                    cl.ReadOnly = True
                End If
            Next
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dt, True, False, True, True, True, Name)


            FormatGrid()
        Catch ex As Exception
        End Try
    End Sub
    'Thoat
    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    'Thực hiện copy
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Try
            Dim sqlCnn As SqlConnection = New SqlConnection()
            sqlCnn.ConnectionString = Commons.IConnections.ConnectionString()
            If (sqlCnn.State = ConnectionState.Closed) Then
                sqlCnn.Open()
            End If
            Dim sqlCmd As SqlCommand = New SqlCommand()
            sqlCmd.Connection = sqlCnn
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandText = "COPY_CAU_TRUC_TB"

            Dim sqlP0 As SqlParameter = sqlCmd.CreateParameter()
            sqlP0.ParameterName = "@MS_MAY_ODD"
            sqlP0.SqlDbType = SqlDbType.NVarChar

            If optOption.SelectedIndex = 0 Then
                sqlP0.Value = MS_MAY
            End If


            sqlCmd.Parameters.Add(sqlP0)

            Dim sqlP As SqlParameter = sqlCmd.CreateParameter()
            sqlP.ParameterName = "@MS_MAY_NEW"
            sqlP.SqlDbType = SqlDbType.NVarChar
            If optOption.SelectedIndex = 1 Then
                sqlP.Value = MS_MAY
            End If
            sqlCmd.Parameters.Add(sqlP)
            Dim sqlTr As SqlTransaction = sqlCnn.BeginTransaction()
            sqlCmd.Transaction = sqlTr
            Try
                Dim vFlag As Boolean = False
                For i As Integer = 0 To grvMay.RowCount - 1
                    If (Not grvMay.GetDataRow(i)("CHON").Equals(Nothing)) Then
                        If (Convert.ToBoolean(grvMay.GetDataRow(i)("CHON"))) Then
                            vFlag = True
                            If optOption.SelectedIndex = 0 Then
                                sqlP.Value = grvMay.GetDataRow(i)("MS_MAY").ToString().Trim()
                            Else
                                sqlP0.Value = grvMay.GetDataRow(i)("MS_MAY").ToString().Trim()
                            End If
                            sqlCmd.ExecuteNonQuery()
                        End If
                    End If
                Next
                sqlTr.Commit()
                If (vFlag) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCopyTBSuc", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSelectTB", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Catch ex As Exception
                sqlTr.Rollback()
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorCopyTB", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString, "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgErrorCopyTB", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString, "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Format grid
    Private Sub FormatGrid()
        Try
            With grvMay
                If Not .DataSource Is Nothing Then
                    .Columns("MS_MAY").MinWidth = 100
                    .Columns("TEN_MAY").MinWidth = 150
                    .Columns("TEN_NHOM_MAY").MinWidth = 150
                    .Columns("TEN_LOAI_MAY").MinWidth = 150
                    .Columns("MO_TA").MinWidth = 100
                    .Columns("TEN_QG").MinWidth = 100
                    .Columns("TEN_TINH").MinWidth = 100
                    .Columns("TEN_QUAN").MinWidth = 100
                    .Columns("CHON").MinWidth = 60
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNhomTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNhomTB.TextChanged
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grdMay.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = "Ten_Nhom_May Like '%" + txtNhomTB.Text + "%' or TEN_MAY like '%" + txtNhomTB.Text + "%' or MS_MAY like '%" + txtNhomTB.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try

    End Sub

    Private Sub optHienTrang_EditValueChanged(sender As Object, e As EventArgs) Handles optOption.EditValueChanged
        LoadData()
    End Sub
End Class