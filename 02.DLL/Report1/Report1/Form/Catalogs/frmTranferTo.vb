

Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data
Public Class frmTranferTo

    Private bThem As Boolean = False
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            flag = True
            BindData(-1)
            flag = False
            LockData(True)
            VisibleButton(True)

            If Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "frmTranferTo").ToString().ToLower().Trim().Equals("read only") Then
                BtnThem.Enabled = False
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub


    Sub Refesh()
        txtSTT.Text = ""
        txtTranferTo.Text = ""
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtTranferTo.Properties.ReadOnly = blnLock
        txtTranferTo.Enabled = Not blnLock
        grdTranferTo.Enabled = blnLock
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        btnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongGhi.Visible = Not blnVisible
    End Sub

    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        LockData(False)
        txtTranferTo.Text = ""
        bThem = True
        txtSTT.Text = -1
        txtTranferTo.Focus()
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongGhi.Click
        VisibleButton(True)
        LockData(True)
        ShowData(grvTranferTo.FocusedRowHandle)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If txtTranferTo.Text.Trim() = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongDuocTrong", Commons.Modules.TypeLanguage))
            txtTranferTo.Focus()
            Exit Sub
        End If


        Dim iID As Integer = -1
        Try
            '            Select Case ISNULL(COUNT(*), 0) As ICOUNT FROM dbo.TRANSFER_TO WHERE ID <> 5 And TRANSFER_TO_NAME = N'FGGGG'

            iID = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT ISNULL(COUNT(*),0) AS ICOUNT FROM dbo.TRANSFER_TO WHERE ID <> " & txtSTT.Text & " AND TRANSFER_TO_NAME = N'" & txtTranferTo.Text.Trim() & "'"))
            If iID > 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenTRANSFER_TO", Commons.Modules.TypeLanguage))
                txtTranferTo.Focus()
                Exit Sub
            End If


            iID = -1
            iID = Integer.Parse(txtSTT.Text)
        Catch ex As Exception

        End Try


        Try
            If bThem Then
                iID = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO TRANSFER_TO(TRANSFER_TO_NAME) values( N'" + txtTranferTo.Text + "' ) SELECT SCOPE_IDENTITY()"))
            Else
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE TRANSFER_TO SET TRANSFER_TO_NAME = N'" + txtTranferTo.Text + "' WHERE ID = '" + txtSTT.Text + "'")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


        BindData(iID)

        bThem = False
        VisibleButton(True)
        LockData(True)
        ShowData(grvTranferTo.FocusedRowHandle)
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grvTranferTo.RowCount = 0 Then Exit Sub
        If IsDBNull(grdTranferTo.DataSource) Then Exit Sub
        Dim traloi As String = ""
        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaTRANSFER_TO", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
        If traloi = vbYes Then
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM TRANSFER_TO WHERE ID = '" + grvTranferTo.GetFocusedDataRow()("ID").ToString + "'")
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message)
            End Try
            BindData(-1)
        End If
    End Sub
    Sub ShowData(ByVal intRow As Integer)
        Try
            If grvTranferTo.RowCount = 0 Then Exit Sub
            If IsDBNull(grdTranferTo.DataSource) Then Exit Sub

            Refesh()
            txtSTT.Text = grvTranferTo.GetRowCellValue(intRow, "ID").ToString
            txtTranferTo.Text = grvTranferTo.GetRowCellValue(intRow, "TRANSFER_TO_NAME").ToString
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        Try
            If grvTranferTo.RowCount = 0 Then Exit Sub
            If IsDBNull(grdTranferTo.DataSource) Then Exit Sub
            bThem = False
            VisibleButton(False)
            LockData(False)
            txtTranferTo.Focus()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim flag As Boolean = False
    Sub BindData(iID As Integer)
        Try

            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                           "SELECT ID, TRANSFER_TO_NAME FROM TRANSFER_TO ORDER BY TRANSFER_TO_NAME"))

            dtTmp.PrimaryKey = New DataColumn() {dtTmp.Columns("ID")}

            If flag = vbTrue Then
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTranferTo, grvTranferTo, dtTmp, False, True, True, True)
            Else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTranferTo, grvTranferTo, dtTmp, False, False, True, True)
            End If



            If iID <> -1 Then
                Dim index As Integer = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(iID))
                grvTranferTo.FocusedRowHandle = grvTranferTo.GetRowHandle(index)
            End If

            If grvTranferTo.RowCount = 0 Then
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            Else
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            End If
            grvTranferTo.Columns("ID").Visible = False
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdCA_FocusedRowChanged(sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvTranferTo.FocusedRowChanged
        Try
            If grvTranferTo.RowCount = 0 Then Exit Sub
            If IsDBNull(grdTranferTo.DataSource) Then Exit Sub

            ShowData(e.FocusedRowHandle)
        Catch ex As Exception
        End Try
    End Sub

End Class