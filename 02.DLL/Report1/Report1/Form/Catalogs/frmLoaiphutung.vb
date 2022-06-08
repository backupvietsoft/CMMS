
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin

Public Class frmLoaiphutung

#Region "Private Member"
    Private blnAdd As Boolean
    Private LOAD_GRID As Integer = 1

#End Region

#Region "Event Form"
    Private Sub frmLoaiphutung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TableLayoutPanel2.ColumnStyles(0).Width = 0
        TableLayoutPanel2.ColumnStyles(TableLayoutPanel2.ColumnCount - 1).Width = 0
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
        blnAdd = True
        txtTEN_LOAI_PT.Focus
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtTEN_LOAI_PT.Focus
        Me.txtTEN_LOAI_PT.SelectAll()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        DeleteGroup()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            AddGroup()
            Dim TEMP As String = Me.txtTEN_LOAI_PT.Text.Trim
            Refesh()
            If LOAD_GRID = 1 Then
                BindData()
                blnAdd = False
                VisibleButton(True)
                LockData(True)
                If TEMP <> "" Then
                    Dim index As Integer
                    index = grvLPT.LocateByValue(0, grvLPT.Columns("TEN_LOAI_PT"), TEMP)
                    grvLPT.FocusedRowHandle = index
                    Try
                        If txtTEN_LOAI_PT.Text = "" Then ShowGroup()
                        If txtMS_LOAI_PT.Text <> grvLPT.GetFocusedRowCellValue("MS_LOAI_PT").ToString Then ShowGroup()
                    Catch ex As Exception
                        ShowGroup()
                    End Try
                End If
            End If

        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        If Not isValidated() Then
            errProvider.Clear()
        End If
        blnAdd = False
        VisibleButton(True)
        LockData(True)

        ShowGroup()
    End Sub

#End Region

#Region "Methods"

    Sub Refesh()
        txtTEN_LOAI_PT.Text = ""
        txtGHI_CHU.Text = ""
    End Sub
    Sub ShowGroup()
        Try
            If grdLPT.DataSource Is Nothing Then Exit Sub
            If grvLPT.RowCount = 0 Then
                Refesh()
                Exit Sub
            End If
            txtMS_LOAI_PT.Text = grvLPT.GetFocusedRowCellValue("MS_LOAI_PT").ToString
            txtTEN_LOAI_PT.Text = grvLPT.GetFocusedRowCellValue("TEN_LOAI_PT").ToString

        Catch ex As Exception

        End Try

    End Sub
    Sub BindData()
        Try
            Dim dtTmp As New DataTable
            dtTmp = New LOAI_PHU_TUNGController().GetLOAI_PHU_TUNGs
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLPT, grvLPT, dtTmp, False, True, True, True, True, Me.Name)


            Me.grvLPT.Columns("MS_LOAI_PT").Visible = False

            If grvLPT.RowCount > 0 Then
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            Else
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
            Try
                If txtTEN_LOAI_PT.Text = "" Then grvLPT_FocusedRowChanged(Nothing, Nothing)
                If txtTEN_LOAI_PT.Text <> grvLPT.GetFocusedRowCellValue("TEN_LOAI_PT").ToString Then grvLPT_FocusedRowChanged(Nothing, Nothing)
            Catch ex As Exception
                grvLPT_FocusedRowChanged(Nothing, Nothing)
            End Try
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub AddGroup()
        Dim objLOAI_PHU_TUNGInfo As New LOAI_PHU_TUNGInfo
        Dim objLOAI_PHU_TUNGController As New LOAI_PHU_TUNGController()


        objLOAI_PHU_TUNGInfo.TEN_LOAI_PT = txtTEN_LOAI_PT.Text
        objLOAI_PHU_TUNGInfo.GHI_CHU = txtGHI_CHU.Text

        If Not blnAdd Then
            objLOAI_PHU_TUNGInfo.MS_LOAI_PT = CInt(txtMS_LOAI_PT.Text)
            If (objLOAI_PHU_TUNGController.CheckLOAI_PHU_TUNG(txtMS_LOAI_PT.Text.Trim, txtTEN_LOAI_PT.Text.Trim)).Read Then
                objLOAI_PHU_TUNGController.InsertLOAI_PHU_TUNG_LOG(CInt(txtMS_LOAI_PT.Text), Me.Name, Commons.Modules.UserName, 2)
                objLOAI_PHU_TUNGController.UpdateLOAI_PHU_TUNG(objLOAI_PHU_TUNGInfo)
                Exit Sub
            Else
                If (objLOAI_PHU_TUNGController.CheckExistLOAI_PHU_TUNG(txtTEN_LOAI_PT.Text.Trim)).Read Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSameName", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Name)
                    Me.txtTEN_LOAI_PT.Focus()
                    LOAD_GRID = 2
                    Exit Sub
                Else
                    objLOAI_PHU_TUNGController.InsertLOAI_PHU_TUNG_LOG(CInt(txtMS_LOAI_PT.Text), Me.Name, Commons.Modules.UserName, 2)
                    objLOAI_PHU_TUNGController.UpdateLOAI_PHU_TUNG(objLOAI_PHU_TUNGInfo)
                End If
            End If
        Else
            If (objLOAI_PHU_TUNGController.CheckTEN_LOAI_PT(txtTEN_LOAI_PT.Text.Trim)).Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSameName", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Name)
                Me.txtTEN_LOAI_PT.Focus()
                LOAD_GRID = 2
                Exit Sub
            End If
            objLOAI_PHU_TUNGInfo.MS_LOAI_PT = New LOAI_PHU_TUNGController().AddLOAI_PHU_TUNG(objLOAI_PHU_TUNGInfo)
            objLOAI_PHU_TUNGController.InsertLOAI_PHU_TUNG_LOG(CInt(objLOAI_PHU_TUNGInfo.MS_LOAI_PT), Me.Name, Commons.Modules.UserName, 1)
            Dim str As String = ""
            str = "INSERT INTO NHOM_LOAI_PHU_TUNG SELECT GROUP_ID,'" & objLOAI_PHU_TUNGInfo.MS_LOAI_PT & "' AS MS_LOAI_MAY FROM USERS WHERE USERNAME='" & Commons.Modules.UserName & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End If
        LOAD_GRID = 1
    End Sub
    Sub DeleteGroup()
        Dim objLOAI_PHU_TUNGController As New LOAI_PHU_TUNGController()
        If objLOAI_PHU_TUNGController.CheckUsedLOAI_PHU_TUNG_IC_PHU_TUNG(txtMS_LOAI_PT.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXacNhanXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, Me.Text) = MsgBoxResult.Yes Then

            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                SqlHelper.ExecuteScalar(objTrans, "DeleteNHOM_LOAI_PHU_TUNG_1", txtMS_LOAI_PT.Text, Commons.Modules.UserName)
                objLOAI_PHU_TUNGController.InsertLOAI_PHU_TUNG_LOG(CInt(txtMS_LOAI_PT.Text), Me.Name, Commons.Modules.UserName, 3)
                SqlHelper.ExecuteScalar(objTrans, "DeleteLOAI_PHU_TUNG", txtMS_LOAI_PT.Text)

                objTrans.Commit()
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DA_PS_KO_THE_XOA", commons.Modules.TypeLanguage))
                objTrans.Rollback()
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
        Dim str As String
        str = "SELECT * FROM NHOM_LOAI_PHU_TUNG INNER JOIN NHOM ON NHOM.GROUP_ID=NHOM_LOAI_PHU_TUNG.GROUP_ID INNER JOIN USERS ON USERS.GROUP_ID=NHOM.GROUP_ID WHERE MS_LOAI_PT='" & txtMS_LOAI_PT.Text.Trim.Replace("'", "''") & "' AND USERNAME<>'" & Commons.Modules.UserName & "'"
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgUser", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        Refesh()
        BindData
    End Sub
    Function isValidated()
        If Not txtTEN_LOAI_PT.IsValidated Then
            txtTEN_LOAI_PT.Focus()
            Return False
        End If
        Return True
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
        txtTEN_LOAI_PT.ReadOnly = blnLock
        txtGHI_CHU.ReadOnly = blnLock
        grdLPT.Enabled = blnLock
    End Sub

    Private Sub grvLPT_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvLPT.FocusedRowChanged
        ShowGroup()
    End Sub

#End Region
End Class