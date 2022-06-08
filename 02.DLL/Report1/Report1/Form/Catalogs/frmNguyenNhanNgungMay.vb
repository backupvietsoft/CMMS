Imports Microsoft.ApplicationBlocks.Data
Imports System.Convert
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports Commons
Imports System.Reflection

Public Class frmNguyenNhanNgungMay
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            BindData(-1)
            LockData(True)
            VisibleButton(True)
            LoadComBoLoaiNN()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub LoadComBoLoaiNN()
        Try
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID,CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN DownTimeTypeName WHEN 1 THEN DownTimeTypeNameA ELSE DownTimeTypeNameH END AS DownTimeTypeName FROM dbo.DownTimeType"))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiNN, dt, "ID", "DownTimeTypeName", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadText(ByVal nullText As Boolean)
        If grvDowtimeCause Is Nothing Then Return
        If grvDowtimeCause.RowCount = 0 Then nullText = True
        Try
            txtSTT.Text = (If(nullText, "-1", Convert.ToInt32(grvDowtimeCause.GetFocusedRowCellValue("MS_NGUYEN_NHAN")).ToString()))
            txtTenNN.Text = (If(nullText, "", grvDowtimeCause.GetFocusedRowCellValue("TEN_NGUYEN_NHAN")))
            txtTenNN_A.Text = (If(nullText, "", grvDowtimeCause.GetFocusedRowCellValue("TEN_NGUYEN_NHAN_ANH")))
            rdoLyDo.SelectedIndex = (If(nullText, 0, IIf(Convert.ToBoolean(grvDowtimeCause.GetFocusedRowCellValue("BTDK")), 1, 0)))
            chkMacDinh.Checked = (If(nullText, False, Convert.ToBoolean(grvDowtimeCause.GetFocusedRowCellValue("MAC_DINH"))))
            chkActive.Checked = (If(nullText, False, Convert.ToBoolean(grvDowtimeCause.GetFocusedRowCellValue("Planned"))))
        Catch ex As Exception
        End Try
    End Sub

    Sub LockData(ByVal blnLock As Boolean)
        txtTenNN.Enabled = Not blnLock
        txtTenNN_A.Enabled = Not blnLock
        cboLoaiNN.Enabled = Not blnLock
        chkActive.Enabled = Not blnLock
        chkMacDinh.Enabled = Not blnLock
        rdoLyDo.Enabled = Not blnLock
        grdDowtimeCause.Enabled = blnLock
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        btnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongGhi.Visible = Not blnVisible
    End Sub


    Private Sub DeleteData(ByVal iId As Int64)

        Dim traloi As DialogResult
        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Me.Name, "MsgXoaNguyenNhan"), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgThongBao"), MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        If traloi = DialogResult.Yes Then
            Dim comd = New SqlCommand()
            comd.CommandType = CommandType.StoredProcedure
            comd.CommandText = "spDownTimeCause"
            comd.Parameters.Add(New SqlParameter("@Loai", "Delete"))
            comd.Parameters.Add(New SqlParameter("@ID", Convert.ToInt64(txtSTT.Text)))
            Dim rs As Object
            Using connection As SqlConnection = New SqlConnection(Commons.IConnections.CNStr)
                comd.Connection = connection
                comd.CommandTimeout = 3600
                comd.Connection.Open()
                rs = comd.ExecuteScalar()
            End Using
            If Convert.ToString(rs) = "0" Then
                BindData(-1)
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Me.Name, "MsgDuLieuTonTai"), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        LockData(False)
        LoadText(True)
        txtSTT.Text = -1
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grvDowtimeCause.RowCount = 0 Then
            Exit Sub
        End If
        DeleteData(Convert.ToInt64(txtSTT.Text))
    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtTenNN.Focus()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If txtTenNN.Text.Trim() = "" Then
            txtTenNN.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenLoaiNNKhongTrong", Commons.Modules.TypeLanguage)
            txtTenNN.Focus()
            Exit Sub
        End If
        Dim iID As Integer
        iID = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT ISNULL(COUNT(*),0) AS ICOUNT FROM dbo.DownTimeType WHERE ID <> " & txtSTT.Text & " AND DownTimeTypeName = N'" & txtTenNN.Text.Trim() & "'"))
        If iID > 0 Then
            txtTenNN.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Me.Name, "MsgTrungTenLoaiNN")
            txtTenNN.Focus()
            Exit Sub
        End If

        Dim comd = New SqlCommand()
        comd.CommandType = CommandType.StoredProcedure
        comd.CommandText = "spDownTimeCause"
        comd.Parameters.Add(New SqlParameter("@Loai", "Save"))
        comd.Parameters.Add(New SqlParameter("@ID", txtSTT.Text))
        comd.Parameters.Add(New SqlParameter("@TEN_NGUYEN_NHAN", txtTenNN.Text))
        comd.Parameters.Add(New SqlParameter("@TEN_NGUYEN_NHANA", txtTenNN_A.Text))
        comd.Parameters.Add(New SqlParameter("@DownTimeTypeID", cboLoaiNN.EditValue))

        comd.Parameters.Add(New SqlParameter("@HU_HONG", IIf(rdoLyDo.SelectedIndex = 0, True, False)))
        comd.Parameters.Add(New SqlParameter("@BTDK", IIf(rdoLyDo.SelectedIndex = 1, True, False)))
        comd.Parameters.Add(New SqlParameter("@MAC_DINH", Convert.ToBoolean(chkMacDinh.Checked)))
        comd.Parameters.Add(New SqlParameter("@Active", Convert.ToBoolean(chkActive.Checked)))
        comd.Parameters.Add(New SqlParameter("@NNgu", Commons.Modules.TypeLanguage))

        Using connection As SqlConnection = New SqlConnection(Commons.IConnections.CNStr)
            comd.Connection = connection
            comd.CommandTimeout = 3600
            comd.Connection.Open()
            BindData(Convert.ToInt32(comd.ExecuteScalar()))
        End Using
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongGhi.Click
        VisibleButton(True)
        LockData(True)
        LoadText(False)
    End Sub

    Private Sub BtnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub BindData(ByVal id As Int32)
        Dim dt As DataTable = New DataTable()
        Try
            Dim comd = New SqlCommand()
            comd.CommandType = CommandType.StoredProcedure
            comd.CommandText = "spDownTimeCause"
            comd.Parameters.Add(New SqlParameter("@Loai", "Grd"))

            Using connection As SqlConnection = New SqlConnection(Commons.IConnections.CNStr)
                comd.Connection = connection
                comd.Connection.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(comd)
                da.Fill(dt)
                da.Dispose()
            End Using

            dt.PrimaryKey = New DataColumn() {dt.Columns("MS_NGUYEN_NHAN")}

            If grdDowtimeCause.DataSource Is Nothing Then
                Modules.ObjSystems.MLoadXtraGrid(grdDowtimeCause, grvDowtimeCause, dt, False, False, True, True, True, Me.Name)
            Else
                grdDowtimeCause.DataSource = dt
            End If
            If id <> -1 Then
                Dim index As Integer = dt.Rows.IndexOf(dt.Rows.Find(id))
                grvDowtimeCause.FocusedRowHandle = grvDowtimeCause.GetRowHandle(index)
            End If
            If grvDowtimeCause.RowCount = 0 Then
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            Else
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            End If
            grvDowtimeCause.Columns("MS_NGUYEN_NHAN").Visible = False
            grvDowtimeCause.Columns("DownTimeTypeID").Visible = False
            LoadText(False)
        Catch ex As Exception
            XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name & ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub grdCA_FocusedRowChanged(sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDowtimeCause.FocusedRowChanged
        Try
            If grvDowtimeCause.RowCount = 0 Then Exit Sub
            If IsDBNull(grdDowtimeCause.DataSource) Then Exit Sub
            LoadText(False)
        Catch ex As Exception
        End Try
    End Sub

End Class