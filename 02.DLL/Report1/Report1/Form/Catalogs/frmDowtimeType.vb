
Imports Microsoft.ApplicationBlocks.Data
Imports System.Convert
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports Commons
Imports System.Reflection

Public Class frmDowtimeType
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            BindData(-1)
            LockData(True)
            VisibleButton(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub LoadText(ByVal nullText As Boolean)
        If grvDowtimeType Is Nothing Then Return
        If grvDowtimeType.RowCount = 0 Then nullText = True
        Try
            txtSTT.Text = (If(nullText, "-1", Convert.ToInt64(grvDowtimeType.GetFocusedRowCellValue("ID")).ToString()))
            txtTenLoaiNN.Text = (If(nullText, "", grvDowtimeType.GetFocusedRowCellValue("DownTimeTypeName")))
            txtTenLoaiNN_A.Text = (If(nullText, "", grvDowtimeType.GetFocusedRowCellValue("DownTimeTypeNameA")))
            txtTenLoaiNN_H.Text = (If(nullText, "", grvDowtimeType.GetFocusedRowCellValue("DownTimeTypeNameH")))
            txtGhiChu.Text = (If(nullText, "", grvDowtimeType.GetFocusedRowCellValue("Note").ToString()).ToString())
            chkKeHoach.Checked = (If(nullText, False, Convert.ToBoolean(grvDowtimeType.GetFocusedRowCellValue("Planned"))))
            chkHieuLuc.Checked = (If(nullText, True, Convert.ToBoolean(grvDowtimeType.GetFocusedRowCellValue("Active"))))
        Catch ex As Exception
        End Try
    End Sub

    Sub LockData(ByVal blnLock As Boolean)
        txtTenLoaiNN.Enabled = Not blnLock
        txtTenLoaiNN_A.Enabled = Not blnLock
        txtTenLoaiNN_H.Enabled = Not blnLock
        txtGhiChu.Enabled = Not blnLock

        chkHieuLuc.Enabled = Not blnLock
        chkKeHoach.Enabled = Not blnLock

        grdDowtimeType.Enabled = blnLock

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
        traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Me.Name, "MsgXoaLoaiNguyenNhan"), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgThongBao"), MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        If traloi = DialogResult.Yes Then
            Dim comd = New SqlCommand()
            comd.CommandType = CommandType.StoredProcedure
            comd.CommandText = "spDownTimeType"
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
        If grvDowtimeType.RowCount = 0 Then
            Exit Sub
        End If
        DeleteData(Convert.ToInt64(txtSTT.Text))
    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtTenLoaiNN.Focus()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If txtTenLoaiNN.Text.Trim() = "" Then
            txtTenLoaiNN.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenLoaiNNKhongTrong", Commons.Modules.TypeLanguage)
            txtTenLoaiNN.Focus()
            Exit Sub
        End If
        Dim iID As Integer
        iID = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        "SELECT ISNULL(COUNT(*),0) AS ICOUNT FROM dbo.DownTimeType WHERE ID <> " & txtSTT.Text & " AND DownTimeTypeName = N'" & txtTenLoaiNN.Text.Trim() & "'"))
        If iID > 0 Then
            txtTenLoaiNN.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Me.Name, "MsgTrungTenLoaiNN")
            txtTenLoaiNN.Focus()
            Exit Sub
        End If

        Dim comd = New SqlCommand()
        comd.CommandType = CommandType.StoredProcedure
        comd.CommandText = "spDownTimeType"
        comd.Parameters.Add(New SqlParameter("@Loai", "Save"))
        comd.Parameters.Add(New SqlParameter("@ID", txtSTT.Text))
        comd.Parameters.Add(New SqlParameter("@DownTimeTypeName", txtTenLoaiNN.Text))
        comd.Parameters.Add(New SqlParameter("@DownTimeTypeNameA", txtTenLoaiNN_A.Text))
        comd.Parameters.Add(New SqlParameter("@DownTimeTypeNameH", txtTenLoaiNN_H.Text))
        comd.Parameters.Add(New SqlParameter("@Note", txtGhiChu.Text))
        comd.Parameters.Add(New SqlParameter("@Planned", Convert.ToBoolean(chkKeHoach.Checked)))
        comd.Parameters.Add(New SqlParameter("@Active", Convert.ToBoolean(chkHieuLuc.Checked)))

        Using connection As SqlConnection = New SqlConnection(Commons.IConnections.CNStr)
            comd.Connection = connection
            comd.CommandTimeout = 3600
            comd.Connection.Open()
            BindData(Convert.ToInt64(comd.ExecuteScalar()))
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

    Private Sub BindData(ByVal id As Int64)
        Dim dt As DataTable = New DataTable()
        Try
            Dim comd = New SqlCommand()
            comd.CommandType = CommandType.StoredProcedure
            comd.CommandText = "spDownTimeType"
            comd.Parameters.Add(New SqlParameter("@Loai", "Grd"))

            Using connection As SqlConnection = New SqlConnection(Commons.IConnections.CNStr)
                comd.Connection = connection
                comd.Connection.Open()
                Dim da As SqlDataAdapter = New SqlDataAdapter(comd)
                da.Fill(dt)
                da.Dispose()
            End Using

            dt.PrimaryKey = New DataColumn() {dt.Columns("ID")}

            If grdDowtimeType.DataSource Is Nothing Then
                Modules.ObjSystems.MLoadXtraGrid(grdDowtimeType, grvDowtimeType, dt, False, False, True, True, True, Me.Name)
            Else
                grdDowtimeType.DataSource = dt
            End If
            If id <> -1 Then
                Dim index As Integer = dt.Rows.IndexOf(dt.Rows.Find(id))
                grvDowtimeType.FocusedRowHandle = grvDowtimeType.GetRowHandle(index)
            End If
            If grvDowtimeType.RowCount = 0 Then
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            Else
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            End If
            grvDowtimeType.Columns("ID").Visible = False
            LoadText(False)
        Catch ex As Exception
            XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name & ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub grdCA_FocusedRowChanged(sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDowtimeType.FocusedRowChanged
        Try
            If grvDowtimeType.RowCount = 0 Then Exit Sub
            If IsDBNull(grdDowtimeType.DataSource) Then Exit Sub
            LoadText(False)
        Catch ex As Exception
        End Try
    End Sub

End Class