
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class FrmLoaiBTQH
    Private sTatus As String = "R"
    Private Sub FrmLoaiBTQH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        LoadData()
        LocControl()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        If Commons.Modules.PermisString.Equals("Read only") Then
            btAdd.Enabled = False
        End If
    End Sub
    'Load dữ liệu
    Private Sub LoadData()
        Dim tbLoaiBT As DataTable = New DataTable()
        Commons.Modules.SQLString = "SELECT LOAI_BAO_TRI.MS_LOAI_BT, LOAI_BAO_TRI.TEN_LOAI_BT, HINH_THUC_BAO_TRI.PHONG_NGUA " &
            " FROM LOAI_BAO_TRI INNER JOIN HINH_THUC_BAO_TRI ON LOAI_BAO_TRI.MS_HT_BT = HINH_THUC_BAO_TRI.MS_HT_BT " &
            " WHERE  (LOAI_BAO_TRI.THU_TU NOT IN (SELECT MAX(THU_TU) AS MS_LOAI_BT FROM LOAI_BAO_TRI)) AND (HINH_THUC_BAO_TRI.PHONG_NGUA = 1) ORDER BY THU_TU"

        tbLoaiBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))

        If grdCapTren.DataSource = Nothing Then
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCapTren, grvCapTren, tbLoaiBT, False, True, True, True, True, "")
        Else
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCapTren, grvCapTren, tbLoaiBT, False, False, True, True, True, "")
        End If

    End Sub
    'Thoát form
    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
    'Lock control
    Private Sub LocControl()
        If (sTatus = "A") Then

            grvCapDuoi.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            grvCapDuoi.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
            grvCapDuoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            grvCapDuoi.OptionsBehavior.Editable = True

            btSave.Visible = True
            btCancel.Visible = True

            btAdd.Visible = False
            btExit.Visible = False
        Else
            grvCapDuoi.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            grvCapDuoi.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
            grvCapDuoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            grvCapDuoi.OptionsBehavior.Editable = False

            If (grvCapDuoi.RowCount > 0) Then
                btSave.Visible = False
                btCancel.Visible = False

                btAdd.Visible = True
                btExit.Visible = True
            Else
                btSave.Visible = False
                btCancel.Visible = False
                btAdd.Visible = True
                btExit.Visible = True
            End If
        End If
    End Sub
    'Load data child 
    Private Sub LoadDataChild(ByVal MS_LOAI_BT_CT As Integer)
        Try
            grdCapDuoi.DataSource = Nothing
            Dim tbChild As DataTable = New DataTable()
            tbChild.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT dbo.LOAI_BAO_TRI_QH.MS_LOAI_BT_CD FROM  dbo.LOAI_BAO_TRI_QH  WHERE MS_LOAI_BT_CT = " & MS_LOAI_BT_CT & " "))

            If grdCapDuoi.DataSource = Nothing Then
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCapDuoi, grvCapDuoi, tbChild, False, True, True, True, True, Me.Name)
            Else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCapDuoi, grvCapDuoi, tbChild, False, False, True, True, True, Me.Name)
            End If


            Dim vTable As DataTable = New DataTable()
            vTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT LOAI_BAO_TRI.MS_LOAI_BT AS MS_LOAI_BT_CD, LOAI_BAO_TRI.TEN_LOAI_BT FROM LOAI_BAO_TRI " &
                    " INNER JOIN HINH_THUC_BAO_TRI ON LOAI_BAO_TRI.MS_HT_BT = HINH_THUC_BAO_TRI.MS_HT_BT " &
                    " WHERE (HINH_THUC_BAO_TRI.PHONG_NGUA = 1) ORDER BY THU_TU"))

            Dim cboLBT = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            cboLBT.Name = "LOAI_BT"
            cboLBT.DataSource = vTable
            cboLBT.NullText = ""
            cboLBT.PopulateColumns()
            cboLBT.ValueMember = "MS_LOAI_BT_CD"
            cboLBT.DisplayMember = "TEN_LOAI_BT"
            cboLBT.Columns("MS_LOAI_BT_CD").Visible = False
            grvCapDuoi.Columns("MS_LOAI_BT_CD").ColumnEdit = cboLBT
        Catch ex As Exception

        End Try
    End Sub
    'Thêm sửa        
    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        sTatus = "A"
        LocControl()
    End Sub
    'Lưu dữ liệu
    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        Dim sqlCnn As SqlConnection = New SqlConnection()
        Dim sqlCmd As SqlCommand = New SqlCommand()
        sqlCnn.ConnectionString = Commons.IConnections.ConnectionString
        If (sqlCnn.State = ConnectionState.Closed) Then
            sqlCnn.Open()
        End If
        sqlCmd.Connection = sqlCnn
        Dim sqlTran As SqlTransaction = sqlCnn.BeginTransaction()
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.Transaction = sqlTran
        Try
            Dim vInt As Integer = -1
            Try
                Try
                    vInt = Convert.ToInt32(grvCapTren.GetFocusedRowCellValue("MS_LOAI_BT").ToString) ''gvLoaiBTCT.CurrentRow.Cells("clMsLoaiBT").Value)
                Catch ex As Exception

                End Try
            Catch ex As Exception
            End Try
            Dim vTable As New DataTable

            vTable.Load(SqlHelper.ExecuteReader(sqlTran, CommandType.Text, "SELECT MS_LOAI_BT_CT,MS_LOAI_BT_CD FROM LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT = " & vInt))
            For Each vr As DataRow In vTable.Rows
                sqlCmd.CommandText = " exec UPDATE_LOAI_BAO_TRI_QH_LOG '" & vr("MS_LOAI_BT_CT") & "','" & vr("MS_LOAI_BT_CD") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                sqlCmd.ExecuteNonQuery()
            Next

            sqlCmd.CommandText = "DELETE LOAI_BAO_TRI_QH WHERE MS_LOAI_BT_CT = " & vInt
            sqlCmd.ExecuteNonQuery()
            For i As Integer = 0 To grvCapDuoi.RowCount - 2
                Dim vIntcd As Integer = -1
                Try
                    Try
                        vIntcd = Convert.ToInt32(grvCapDuoi.GetRowCellValue(i, "MS_LOAI_BT_CD").ToString)
                    Catch ex As Exception

                    End Try
                Catch ex As Exception
                End Try
                If (vInt <> -1 And vIntcd <> -1) Then


                    sqlCmd.CommandText = "INSERT INTO LOAI_BAO_TRI_QH (MS_LOAI_BT_CT , MS_LOAI_BT_CD) VALUES ( " & vInt & " , " & vIntcd & ")"
                    sqlCmd.ExecuteNonQuery()

                    sqlCmd.CommandText = " exec UPDATE_LOAI_BAO_TRI_QH_LOG '" & vInt & "','" & vIntcd & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                    sqlCmd.ExecuteNonQuery()
                Else
                    sqlTran.Rollback()
                    MessageBox.Show("Cập nhật dữ liệu không thành công, bạn vui lòng kiểm tra lại dữ liệu!", "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'gvLoaiBTCD.CurrentCell = gvLoaiBTCD.Rows(i).Cells(0)
                    'gvLoaiBTCD.CurrentRow.Selected = True
                End If
            Next
            sqlTran.Commit()
        Catch ex As Exception
            sqlTran.Rollback()
            MessageBox.Show("Cập nhật dữ liệu không thành công, bạn vui lòng kiểm tra lại dữ liệu!", "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
        sTatus = "R"
        LocControl()
    End Sub
    'Không lưu
    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Try
            Dim MsLoaiBT As Integer = -1
            Try
                MsLoaiBT = Convert.ToInt32(grvCapTren.GetFocusedRowCellValue("MS_LOAI_BT").ToString)
            Catch ex As Exception

            End Try
            LoadDataChild(MsLoaiBT)
        Catch ex As Exception

        End Try
        sTatus = "R"
        LocControl()
    End Sub


    Private Sub grvCapTren_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvCapTren.FocusedRowChanged
        Try
            Dim MsLoaiBT As Integer = -1
            Try
                MsLoaiBT = Convert.ToInt32(grvCapTren.GetFocusedRowCellValue("MS_LOAI_BT").ToString)
            Catch ex As Exception

            End Try
            LoadDataChild(MsLoaiBT)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub grvCapTren_MouseDown(sender As Object, e As MouseEventArgs) Handles grvCapTren.MouseDown
        If btSave.Visible = False Then Exit Sub
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = grvCapTren.CalcHitInfo(e.Location)
        If grvCapTren.GetFocusedRowCellValue("MS_LOAI_BT").ToString = grvCapTren.GetDataRow(info.RowHandle)("MS_LOAI_BT") Then

            Exit Sub
        End If

        DirectCast(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
    End Sub

    Private Sub grvCapDuoi_KeyDown(sender As Object, e As KeyEventArgs) Handles grvCapDuoi.KeyDown
        If btSave.Visible = False Then Exit Sub
        If Not e.KeyData = Keys.Delete Then Exit Sub
        grvCapDuoi.DeleteSelectedRows()
        e.Handled = True
    End Sub
End Class