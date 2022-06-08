

Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors

Public Class frmDanhmuchethong

#Region "Private Member"
    Private blnThem As Boolean
    Private ID As Integer = 0
#End Region

#Region "Control Event"

    Private Sub frmDanhmuchethong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TableLayoutPanel1.ColumnStyles(0).Width = 0
        TableLayoutPanel1.ColumnStyles(TableLayoutPanel1.ColumnCount - 1).Width = 0

        BindData()
        VisibleButton(True)
        LockData(True)

        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        Else
            EnableButton(True)
        End If


        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        txtMSHThong.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtMSHThong.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If grvHThong.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa!", MsgBoxStyle.OkOnly, "Thông báo")
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        '  Kiểm tra đơn vị đo có đang được sử dụng trong bảng khác không.

        Dim SQL_TMP As String = "SELECT * FROM MAY_HE_THONG WHERE MS_HE_THONG = '" & TxtMaHT.Text.Trim & "'"
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        'kiểm tra trong thời gian ngừng máy
        SQL_TMP = "SELECT * FROM THOI_GIAN_NGUNG_MAY WHERE MS_HE_THONG = '" & TxtMaHT.Text.Trim & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTHOI_GIAN_NGUNG_MAY", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtReader.Close()
            Exit Sub
        End While
        ' Xóa đơn vị đo
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị đo này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")

        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub


        Dim tmp As Integer = grvHThong.FocusedRowHandle

        Dim objHeThongController As New HE_THONGController()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_HE_THONG_LOG", TxtMaHT.Text, Me.Name, Commons.Modules.UserName, 3)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHE_THONG1", TxtMaHT.Text, Commons.Modules.UserName)
        objHeThongController.InsertHE_THONG_LOG(TxtMaHT.Text, Me.Name, Commons.Modules.UserName, 3)
        objHeThongController.DeleteHE_THONG(TxtMaHT.Text)

        Refesh()
        BindData()
        If tmp > 1 Then
            grvHThong.FocusedRowHandle() = tmp - 1
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Try
            '
            If isValidated() And txtMSHThong.Text <> "" And TxtTenHT.Text <> "" Then
                Dim i As Integer
                i = AddHethong()
                If i = -1 Then
                    Exit Sub
                End If
                BindData()
                blnThem = False
                VisibleButton(True)
                LockData(True)
                Dim j As Integer = 0
                Dim dtTmp As New DataTable
                dtTmp = CType(grdHThong.DataSource, DataTable)


                While j < dtTmp.Rows.Count
                    If dtTmp.Rows(j)(0).ToString = i Then
                        grvHThong.FocusedRowHandle = j
                        grvHThong_FocusedRowChanged(Nothing, Nothing)
                        Exit While
                    Else
                        j = j + 1
                    End If
                End While
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grvHThong.RowCount <> 0 Then
                grvHThong_FocusedRowChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            ShowHethong(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub


#End Region

#Region "Private Methods"

    Sub Refesh()
        TxtTenHT.Text = ""
        TxtTenHTAnh.Text = ""
        TxtTenHTHoa.Text = ""
        txtMSHThong.Text = ""
        txtGhiChu.Text = ""
    End Sub
    Sub ShowHethong(ByVal RowIndex As Integer)
        Try

            TxtMaHT.Text = grvHThong.GetRowCellValue(RowIndex, "MS_HE_THONG").ToString
            txtMSHThong.Text = grvHThong.GetRowCellValue(RowIndex, "MA_HE_THONG").ToString
            TxtTenHT.Text = grvHThong.GetRowCellValue(RowIndex, "TEN_HE_THONG").ToString
            Try
                TxtTenHTAnh.Text = IIf(String.IsNullOrEmpty(grvHThong.GetRowCellValue(RowIndex, "TEN_HE_THONG_ANH").ToString), "", grvHThong.GetRowCellValue(RowIndex, "TEN_HE_THONG_ANH").ToString)
                TxtTenHTHoa.Text = IIf(String.IsNullOrEmpty(grvHThong.GetRowCellValue(RowIndex, "TEN_HE_THONG_HOA").ToString), "", grvHThong.GetRowCellValue(RowIndex, "TEN_HE_THONG_HOA").ToString)
            Catch ex As Exception

            End Try



            If IsDBNull(grvHThong.GetRowCellValue(RowIndex, "GHI_CHU").ToString) = True Then txtGhiChu.Text = "" Else txtGhiChu.Text = grvHThong.GetRowCellValue(RowIndex, "GHI_CHU").ToString
            If IsDBNull(grvHThong.GetRowCellValue(RowIndex, "NO_LINE").ToString) = True Then
                chkNoLine.Checked = False
            Else
                If Convert.ToBoolean(grvHThong.GetRowCellValue(RowIndex, "NO_LINE").ToString) = True Then chkNoLine.Checked = True Else chkNoLine.Checked = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub BindData()
        Try
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHE_THONGs"))
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdHThong, grvHThong, dtTmp, False, True, True, True, True, "")
            grvHThong.Columns("MS_HE_THONG").Visible = False
            grvHThong.Columns("NO_LINE").Width = 100

            grvHThong.Columns("TEN_HE_THONG").Width = 200
            grvHThong.Columns("TEN_HE_THONG_ANH").Width = 200
            grvHThong.Columns("TEN_HE_THONG_HOA").Width = 200

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Function isValidated()
        If TxtTenHT.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgDaychuyenNull", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If txtMSHThong.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgMsHeThongNull", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        End If

        Return True
    End Function
    Function AddHethong()
        Dim objHeThongInfo As New HE_THONGInfo
        Dim objHeThongController As New HE_THONGController()

        objHeThongInfo.MA_HE_THONG = txtMSHThong.Text
        objHeThongInfo.TEN_HE_THONG = TxtTenHT.Text
        objHeThongInfo.GHI_CHU = txtGhiChu.Text
        If chkNoLine.Checked = True Then objHeThongInfo.NO_LINE = True Else objHeThongInfo.NO_LINE = False


        If Not blnThem Then
            If (objHeThongController.CheckHE_THONG_MA(Integer.Parse(Me.TxtMaHT.Text.Trim), Me.txtMSHThong.Text.Trim)).Read = False Then
                If (objHeThongController.CheckMA_HE_THONG(Me.txtMSHThong.Text)).Read Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgMaSoHeThongDaTonTai", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtMSHThong.Focus()
                    Return -1
                Else
                    GoTo 1
                End If
            Else
1:
                If (objHeThongController.CheckHE_THONG(Integer.Parse(Me.TxtMaHT.Text.Trim), Me.TxtTenHT.Text.Trim)).Read = False Then
                    If (objHeThongController.CheckTEN_HE_THONG(Me.TxtTenHT.Text)).Read Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTEN_HE_THONG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtTenHT.Focus()
                        Return -1
                    Else
                        objHeThongInfo.MS_HE_THONG = Me.TxtMaHT.Text.Trim
                        objHeThongController.InsertHE_THONG_LOG(objHeThongInfo.MS_HE_THONG, Me.Name, Commons.Modules.UserName, 2)
                        objHeThongController.UpdateHE_THONG(objHeThongInfo)
                    End If
                Else
                    objHeThongInfo.MS_HE_THONG = Me.TxtMaHT.Text.Trim
                    objHeThongController.InsertHE_THONG_LOG(objHeThongInfo.MS_HE_THONG, Me.Name, Commons.Modules.UserName, 2)
                    objHeThongController.UpdateHE_THONG(objHeThongInfo)
                End If
            End If
        Else

            If (objHeThongController.CheckMA_HE_THONG(Me.txtMSHThong.Text.Trim)).Read Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgMaSoHeThongDaTonTai", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMSHThong.Focus()
                Return -1
            Else

                If (objHeThongController.CheckTEN_HE_THONG(Me.TxtTenHT.Text.Trim)).Read Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTEN_HE_THONG", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtTenHT.Focus()
                    Return -1
                Else
                    objHeThongInfo.MS_HE_THONG = New HE_THONGController().AddHE_THONG(objHeThongInfo)
                    objHeThongController.InsertHE_THONG_LOG(objHeThongInfo.MS_HE_THONG, Me.Name, Commons.Modules.UserName, 1)
                    Dim str As String = "INSERT INTO NHOM_HE_THONG SELECT GROUP_ID,'" & objHeThongInfo.MS_HE_THONG & "' AS MS_LOAI_MAY FROM USERS WHERE USERNAME='" & Commons.Modules.UserName & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    Try
                        str = "INSERT INTO NHOM_HE_THONG SELECT GROUP_ID,'" & objHeThongInfo.MS_HE_THONG & "' AS MS_LOAI_MAY FROM USERS WHERE USERNAME='Administrator'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    Catch ex As Exception

                    End Try
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_NHOM_HE_THONG_LOG", objHeThongInfo.MS_HE_THONG, Me.Name, Commons.Modules.UserName, 1)
                End If
            End If
        End If

        Dim sSql As String
        Try
            sSql = "UPDATE HE_THONG SET TEN_HE_THONG_ANH = " & IIf(String.IsNullOrEmpty(TxtTenHTAnh.Text), "NULL", " N'" & TxtTenHTAnh.Text & "' ") & " ,TEN_HE_THONG_HOA = " & IIf(String.IsNullOrEmpty(TxtTenHTAnh.Text), "NULL", " N'" & TxtTenHTHoa.Text & "' ") & " WHERE MS_HE_THONG =  " & objHeThongInfo.MS_HE_THONG & " "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception
        End Try

        Refesh()
        Return objHeThongInfo.MS_HE_THONG
    End Function
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)

        TxtTenHT.Properties.ReadOnly = blnLock
        TxtTenHTAnh.Properties.ReadOnly = blnLock
        TxtTenHTHoa.Properties.ReadOnly = blnLock
        txtMSHThong.Properties.ReadOnly = blnLock
        txtGhiChu.Properties.ReadOnly = blnLock
        chkNoLine.Enabled = Not blnLock
        txtTKiem.Properties.ReadOnly = Not blnLock
        grdHThong.Enabled = blnLock
    End Sub

    Private Sub grvHThong_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvHThong.FocusedRowChanged
        Try
            If grvHThong.RowCount <> 0 Then
                ShowHethong(grvHThong.FocusedRowHandle)
            End If
        Catch ex As Exception
            ShowHethong(0)
        End Try
    End Sub

    Private Sub txtTKiem_EditValueChanging(sender As Object, e As Controls.ChangingEventArgs) Handles txtTKiem.EditValueChanging
        Dim dtTmp As New DataTable
        Try
            'MS_HE_THONG like '%" + txtTKiem.Text + "%' OR MA_HE_THONG like '%" + txtTKiem.Text + "%' OR
            dtTmp = CType(grdHThong.DataSource, DataTable)
            Dim sDK As String
            sDK = " MA_HE_THONG like '%" + txtTKiem.Text + "%' OR TEN_HE_THONG like '%" + txtTKiem.Text + "%' OR TEN_HE_THONG_ANH like '%" + txtTKiem.Text + "%' OR GHI_CHU like '%" + txtTKiem.Text + "%' "

            dtTmp.DefaultView.RowFilter = sDK
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub
#End Region

End Class