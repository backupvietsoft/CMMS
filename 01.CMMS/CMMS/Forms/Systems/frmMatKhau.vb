
Imports Commons.VS.Classes.IEStock
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Public Class frmMatKhau
#Region "Private Member"
    Private SHOW_LANGUAGE As Integer
    Private OLD_PASSWORD As String
#End Region

#Region "Event"
    Private Sub frmMatKhau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VisibleButton(True)
        EnableControl(False)
        RefreshLanguage()
    End Sub

    Private Sub btnDOI_MAT_KHAU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDOI_MAT_KHAU.Click
        VisibleButton(False)
        EnableControl(True)
        SHOW_LANGUAGE = 1
        RefreshLanguage()
        Me.txtPASSWORD.Text = String.Empty
    End Sub

    Private Sub btnTRO_VE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTRO_VE.Click
        VisibleButton(True)
        EnableControl(False)
        RefreshLanguage()
        RefreshData()
    End Sub

    Private Sub btnXAC_NHAN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXAC_NHAN.Click
        Dim objMAT_KHAUController As New MAT_KHAUController
        Dim ENCRYPTED_PASSWORD As String
        If Me.txtPASSWORD.Text.Trim.Equals(String.Empty) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINPUT_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtPASSWORD.Focus()
            Exit Sub
        End If
        ENCRYPTED_PASSWORD = ENCRYPT_PASSWORD(Me.txtPASSWORD.Text.Trim)
        If ENCRYPTED_PASSWORD.Trim.Equals(objMAT_KHAUController.GetMAT_KHAU("KIEM_KE").Trim) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINVALID_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
            Me.txtPASSWORD.Focus()
        Else

        End If
    End Sub
    Private Sub txtPASSWORD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPASSWORD.Validating
        Dim objMAT_KHAUController As New MAT_KHAUController
        Dim ENCRYPTED_PASSWORD As String
        ENCRYPTED_PASSWORD = ENCRYPT_PASSWORD(Me.txtPASSWORD.Text.Trim)
        If Me.txtPASSWORD.Text.Trim.Equals(String.Empty) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINPUT_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtPASSWORD.Focus()
            Exit Sub
        End If
        If ENCRYPTED_PASSWORD.Trim.Equals(objMAT_KHAUController.GetMAT_KHAU("KIEM_KE").Trim) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINVALID_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtPASSWORD.Focus()
        End If
    End Sub
    Private Sub txtNEW_PASSWORD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNEW_PASSWORD.Validating
        If Me.txtNEW_PASSWORD.Text.Trim.Equals(String.Empty) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINPUT_NEW_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtNEW_PASSWORD.Focus()
            Exit Sub
        End If
        If Me.txtNEW_PASSWORD.Text.Trim.Length < 6 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgPASSWORD_LENGTH", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtNEW_PASSWORD.Focus()
        End If
    End Sub
    Private Sub txtCONFIRM_PASSWORD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCONFIRM_PASSWORD.Validating
        If Me.txtCONFIRM_PASSWORD.Text.Trim.Equals(String.Empty) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINPUT_CONFIRM_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtCONFIRM_PASSWORD.Focus()
            Exit Sub
        End If
        If Me.txtNEW_PASSWORD.Text.Trim.Equals(Me.txtCONFIRM_PASSWORD.Text.Trim) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINVALID_CONFIRM_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtCONFIRM_PASSWORD.Focus()
        End If
    End Sub
    Private Sub btnDONG_Y_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDONG_Y.Click
        If Me.txtPASSWORD.Text.Trim.Equals(String.Empty) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINPUT_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtPASSWORD.Focus()
            Exit Sub
        End If
        If Me.txtNEW_PASSWORD.Text.Trim.Equals(String.Empty) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINPUT_NEW_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtNEW_PASSWORD.Focus()
            Exit Sub
        End If
        If Me.txtCONFIRM_PASSWORD.Text.Trim.Equals(String.Empty) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINPUT_CONFIRM_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtCONFIRM_PASSWORD.Focus()
            Exit Sub
        End If
        If Me.txtNEW_PASSWORD.Text.Trim.Equals(Me.txtCONFIRM_PASSWORD.Text.Trim) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgINVALID_CONFIRM_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.txtCONFIRM_PASSWORD.Focus()
            Exit Sub
        End If
        'Lấy ra mật khẩu cũ
        OLD_PASSWORD = New MAT_KHAUController().GetMAT_KHAU("KIEM_KE")
        Dim objMAT_KHAUInfo As New MAT_KHAUInfo
        Dim objMAT_KHAUController As New MAT_KHAUController
        objMAT_KHAUInfo.CHUC_NANG = "KIEM_KE"
        objMAT_KHAUInfo.MAT_KHAU = ENCRYPT_PASSWORD(Me.txtCONFIRM_PASSWORD.Text.Trim)
        objMAT_KHAUController.UpdateMAT_KHAU(objMAT_KHAUInfo)
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSUCCESSFUL_CHANGE_PASSWORD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    End Sub
    Private Sub btnTHOAT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTHOAT.Click
        Me.Close()
    End Sub
#End Region

#Region "Method"
    Sub VisibleButton(ByVal blnVisible As Boolean)
        Me.btnXAC_NHAN.Visible = blnVisible
        Me.btnDOI_MAT_KHAU.Visible = blnVisible
        Me.btnDONG_Y.Visible = Not blnVisible
        Me.btnTRO_VE.Visible = Not blnVisible
    End Sub

    Sub EnableControl(ByVal blnEnable As Boolean)
        Me.txtNEW_PASSWORD.Enabled = blnEnable
        Me.txtCONFIRM_PASSWORD.Enabled = blnEnable
    End Sub

    Sub RefreshLanguage()
        Me.lblNEW_PASSWORD.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblNEW_PASSWORD.Name, commons.Modules.TypeLanguage)
        Me.lblCONFIRM_PASSWORD.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblCONFIRM_PASSWORD.Name, commons.Modules.TypeLanguage)
        Me.btnXAC_NHAN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnXAC_NHAN.Name, commons.Modules.TypeLanguage)
        Me.btnDOI_MAT_KHAU.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnDOI_MAT_KHAU.Name, commons.Modules.TypeLanguage)
        Me.btnDONG_Y.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnDONG_Y.Name, commons.Modules.TypeLanguage)
        Me.btnTRO_VE.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnTRO_VE.Name, commons.Modules.TypeLanguage)
        Me.btnTHOAT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnTHOAT.Name, commons.Modules.TypeLanguage)
        If SHOW_LANGUAGE = 0 Then
            Me.lblOLD_PASSWORD.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblOLD_PASSWORD.Name, commons.Modules.TypeLanguage)
            Me.lblTIEU_DE.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTIEU_DE.Name, commons.Modules.TypeLanguage)
            Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Else
            Me.lblOLD_PASSWORD.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblOLD_PASSWORD.Name & "1", commons.Modules.TypeLanguage)
            Me.lblTIEU_DE.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTIEU_DE.Name & "1", commons.Modules.TypeLanguage)
            Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name & "1", commons.Modules.TypeLanguage)
        End If
        SHOW_LANGUAGE = 0
    End Sub

    Function ENCRYPT_PASSWORD(ByVal PASSWORD_VALUE As String) As String
        Return PASSWORD_VALUE.GetHashCode().ToString
    End Function

    Sub RefreshData()
        Me.txtPASSWORD.Text = String.Empty
        Me.txtNEW_PASSWORD.Text = String.Empty
        Me.txtCONFIRM_PASSWORD.Text = String.Empty
    End Sub
#End Region
End Class