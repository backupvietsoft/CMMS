

Imports System.Data.SqlClient
Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data

Public Class frmLoaicongviec

#Region "Private Member"
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private LOAD_GRID As Integer = 1

#End Region

#Region "Control Event"
    Private Sub frmLoaicongviec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TableLayoutPanel1.ColumnStyles(0).Width = 0
        TableLayoutPanel1.ColumnStyles(TableLayoutPanel1.ColumnCount - 1).Width = 0
        If Commons.Modules.PermisString.Equals("Read only") Then
            BindData()
            VisibleButton(True)
            LockData(True)
            EnableButton(False)
        Else
            EnableButton(True)
            BindData()
            VisibleButton(True)
            LockData(True)
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
        TxtTenloaicv.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        TxtTenloaicv.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grvLCV.RowCount <= 0 Then
            Commons.MssBox.Show(Me.Name, "MsgXoa1", Me.Text)
            Exit Sub
        End If

        Dim SQL_TMP As String
        Dim dtReader As SqlDataReader
        SQL_TMP = "SELECT * FROM CONG_VIEC WHERE MS_LOAI_CV = '" & TxtMaloaicv.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgXoa3", Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        If (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa2", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub

        Dim objLoaiCongViecController As New LOAI_CONG_VIECController()
        objLoaiCongViecController.DeleteNHOM_LOAI_CONG_VIEC_1(TxtMaloaicv.Text, Commons.Modules.UserName)
        objLoaiCongViecController.InsertLOAI_CONG_VIEC_LOG(CInt(TxtMaloaicv.Text), Me.Name, Commons.Modules.UserName, 3)
        objLoaiCongViecController.DeleteLOAI_CONG_VIEC(TxtMaloaicv.Text)
        Refesh()
        BindData()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            Dim TEMP As String = Me.TxtTenloaicv.Text.Trim
            AddCongviec()
            If LOAD_GRID = 1 Then
                blnThem = False
                If TEMP <> "" Then
                    Dim index As Integer
                    index = grvLCV.LocateByValue(0, grvLCV.Columns("TEN_LOAI_CV"), TEMP)
                    grvLCV.FocusedRowHandle = index
                    Try
                        If TxtTenloaicv.Text = "" Then grvLCV_FocusedRowChanged(Nothing, Nothing)
                        If TxtMaloaicv.Text <> grvLCV.GetFocusedRowCellValue("MS_LOAI_CV").ToString Then grvLCV_FocusedRowChanged(Nothing, Nothing)
                    Catch ex As Exception
                        grvLCV_FocusedRowChanged(Nothing, Nothing)
                    End Try
                End If

            End If
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        Refesh()
        Try
            If grvLCV.RowCount <> 0 Then
                ShowLoaiCongViec()
            End If
        Catch ex As Exception
            ShowLoaiCongViec()
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

#End Region

#Region "Private Methods"
    Sub Refesh()
        TxtTenloaicv.Text = ""
        txtTenAnh.Text = ""
    End Sub
    Sub ShowLoaiCongViec()
        Try
            If grdLCV.DataSource Is Nothing Then Exit Sub
            If grvLCV.RowCount = 0 Then
                Refesh()
                Exit Sub
            End If
            TxtMaloaicv.Text = grvLCV.GetFocusedRowCellValue("MS_LOAI_CV").ToString
            TxtTenloaicv.Text = grvLCV.GetFocusedRowCellValue("TEN_LOAI_CV").ToString
            Try
                txtTenAnh.Text = grvLCV.GetFocusedRowCellValue("TEN_LOAI_CV_ANH").ToString
            Catch ex As Exception
                txtTenAnh.Text = ""
            End Try

        Catch ex As Exception
            Refesh()
        End Try

    End Sub
    Sub BindData()
        Try
            Dim dtTmp As New DataTable
            Dim sSql As String
            sSql = "
                        SELECT        T1.MS_LOAI_CV, T1.TEN_LOAI_CV, T1.TEN_LOAI_CV_ANH
                        FROM            dbo.LOAI_CONG_VIEC AS T1 INNER JOIN
                                                 dbo.NHOM_LOAI_CONG_VIEC AS T2 ON T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN
                                                 dbo.USERS AS T3 ON T2.GROUP_ID = T3.GROUP_ID
                        WHERE        (T3.USERNAME = N'" & Commons.Modules.UserName & "')                    "
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLCV, grvLCV, dtTmp, False, True, True, True, True, Me.Name)

            grvLCV.Columns(0).Visible = False
            If grvLCV.RowCount > 0 Then
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            Else
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
            Try
                If TxtTenloaicv.Text = "" Then grvLCV_FocusedRowChanged(Nothing, Nothing)
                If TxtMaloaicv.Text <> grvLCV.GetFocusedRowCellValue("MS_LOAI_CV").ToString Then grvLCV_FocusedRowChanged(Nothing, Nothing)
            Catch ex As Exception
                grvLCV_FocusedRowChanged(Nothing, Nothing)
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Function isValidated()
        If Not TxtTenloaicv.IsValidated Then
            TxtTenloaicv.Focus()
            Return False
        End If
        Return True
    End Function

    Sub AddCongviec()
        Dim objLoaiCongViecInfo As New LOAI_CONG_VIECInfo
        Dim objLoaiCongViecController As New LOAI_CONG_VIECController()

        Dim sSql As String
        objLoaiCongViecInfo.TEN_LOAI_CV = TxtTenloaicv.Text.Trim
        If Not blnThem Then
            objLoaiCongViecInfo.MS_LOAI_CV = TxtMaloaicv.Text
            If (objLoaiCongViecController.CheckLOAI_CONG_VIEC(Integer.Parse(Me.TxtMaloaicv.Text.Trim), Me.TxtTenloaicv.Text.Trim)).Read Then
                objLoaiCongViecController.InsertLOAI_CONG_VIEC_LOG(CInt(TxtMaloaicv.Text), Me.Name, Commons.Modules.UserName, 2)
                objLoaiCongViecController.UpdateLOAI_CONG_VIEC(objLoaiCongViecInfo)
            Else
                If (objLoaiCongViecController.CheckTEN_LOAI_CV(Me.TxtTenloaicv.Text.Trim)).Read Then
                    Commons.MssBox.Show(Me.Name, "MsgTEN_LOAI_CV", Me.Text)
                    Me.TxtTenloaicv.Focus()
                    Me.TxtTenloaicv.SelectAll()
                    VisibleButton(False)
                    LockData(False)
                    LOAD_GRID = 2
                    Exit Sub
                Else
                    objLoaiCongViecController.InsertLOAI_CONG_VIEC_LOG(CInt(TxtMaloaicv.Text), Me.Name, Commons.Modules.UserName, 2)
                    objLoaiCongViecController.UpdateLOAI_CONG_VIEC(objLoaiCongViecInfo)
                End If
            End If

            sSql = "UPDATE LOAI_CONG_VIEC SET TEN_LOAI_CV_ANH = N'" & txtTenAnh.Text & "' WHERE MS_LOAI_CV = " & TxtMaloaicv.Text
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            Catch ex As Exception
            End Try
            VisibleButton(True)
            LockData(True)
            BindData()
        Else
            If (objLoaiCongViecController.CheckTEN_LOAI_CV(Me.TxtTenloaicv.Text.Trim)).Read Then
                Commons.MssBox.Show(Me.Name, "MsgTEN_LOAI_CV", Me.Text)
                Me.TxtTenloaicv.Focus()
                Me.TxtTenloaicv.SelectAll()
                VisibleButton(False)
                LockData(False)
                LOAD_GRID = 2
                blnThem = True
                Exit Sub
            Else

                objLoaiCongViecInfo.MS_LOAI_CV = New LOAI_CONG_VIECController().AddLOAI_CONG_VIEC(objLoaiCongViecInfo)
                sSql = "UPDATE LOAI_CONG_VIEC SET TEN_LOAI_CV_ANH = N'" & txtTenAnh.Text & "' WHERE MS_LOAI_CV = " & objLoaiCongViecInfo.MS_LOAI_CV.ToString
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                Catch ex As Exception
                End Try

                objLoaiCongViecController.InsertLOAI_CONG_VIEC_LOG(CInt(objLoaiCongViecInfo.MS_LOAI_CV), Me.Name, Commons.Modules.UserName, 1)
                sSql = "INSERT INTO NHOM_LOAI_CONG_VIEC SELECT GROUP_ID,'" & objLoaiCongViecInfo.MS_LOAI_CV & "' AS MS_LOAI_MAY FROM USERS WHERE USERNAME='" & Commons.Modules.UserName & "'"
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                Catch ex As Exception
                End Try
                VisibleButton(True)
                LockData(True)
                BindData()
            End If
        End If
        LOAD_GRID = 1

        Refesh()
    End Sub
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        TxtTenloaicv.Properties.ReadOnly = blnLock
        txtTenAnh.Properties.ReadOnly = blnLock
        Me.grdLCV.Enabled = blnLock
    End Sub

    Private Sub grvLCV_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvLCV.FocusedRowChanged
        ShowLoaiCongViec()
    End Sub
#End Region

End Class