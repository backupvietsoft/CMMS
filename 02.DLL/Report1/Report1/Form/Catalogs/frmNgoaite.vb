
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin

Public Class frmNgoaite

#Region "Private Member"
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL As String
    Private NGOAI_TE_TMP As String
    Private indexes As Integer
    Private SHOW_MESSAGE As Integer = 1
    Private count As Integer
    Private NGOAI_TE_VALUE As String
    Private TEN_NGOAI_TE_tmp As String

#End Region

#Region "Control Event"
    Private Sub ChkMacdinh_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ChkMacdinh.MouseClick
        checkDefault()
        Dim objNGOAI_TEController As New NGOAI_TEController
        If count = 0 Then
            If Me.ChkMacdinh.Checked = False Then
                Dim MAC_DINH_No As Integer = objNGOAI_TEController.CheckMAC_DINH()
                If MAC_DINH_No >= 1 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDefault", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Me.ChkMacdinh.Checked = False
                End If
            End If
        ElseIf count >= 1 And Me.TxtMangoaite.Text = NGOAI_TE_VALUE Then
            If objNGOAI_TEController.Check_UsedIC_CHI_TIET_DH_NHAP_PT(Me.TxtMangoaite.Text.Trim) Or objNGOAI_TEController.Check_UsedEOR_SERVICE_CHUNG(Me.TxtMangoaite.Text.Trim) Or objNGOAI_TEController.Check_UsedEOR_SERVICE_MNR(Me.TxtMangoaite.Text.Trim) Or objNGOAI_TEController.Check_UsedKINH_PHI_NAM(Me.TxtMangoaite.Text.Trim) Or objNGOAI_TEController.Check_UsedLUONG_CO_BAN(Me.TxtMangoaite.Text.Trim) Or objNGOAI_TEController.Check_UsedMAY(Me.TxtMangoaite.Text.Trim) Or objNGOAI_TEController.Check_UsedTI_GIA_NT(Me.TxtMangoaite.Text.Trim) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgUSED_NT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Me.ChkMacdinh.Checked = True
            ElseIf objNGOAI_TEController.Check_UsedIC_CHI_TIET_DH_NHAP_PT(Me.TxtMangoaite.Text.Trim) = False Then
                Me.ChkMacdinh.Checked = False
            End If
        ElseIf count >= 1 And Me.TxtMangoaite.Text.Trim.Equals(NGOAI_TE_VALUE) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDefault", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.ChkMacdinh.Checked = False
        End If
    End Sub

    Private Sub frmNgoaite_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim j As Integer
        For i As Integer = 0 To Me.GrdDanhsachngoaite.Rows.Count - 1
            If Me.GrdDanhsachngoaite.Rows(i).Cells("MAC_DINH").Value = True Then
                j = j + 1
            End If
        Next
        If j < 1 And Me.GrdDanhsachngoaite.RowCount > 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSELECT_NT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If
    End Sub
    Private Sub frmNgoaite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, Me.Name)
        If Commons.Modules.PermisString = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNoAccess1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Me.Close()
        Else
            If Commons.Modules.PermisString.Equals("No access") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNoAccess", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Me.Close()
            Else

                If Commons.Modules.PermisString.Equals("Read only") Then
                    BindData()
                    RefeshLanguage()
                    VisibleButton(True)
                    LockData(True)

                    If Me.GrdDanhsachngoaite.RowCount > 0 Then
                        Me.GrdDanhsachngoaite.Rows(0).Selected = True
                    End If
                    EnableButton(False)
                Else
                    EnableButton(True)
                    BindData()
                    RefeshLanguage()
                    VisibleButton(True)
                    LockData(True)

                    If Me.GrdDanhsachngoaite.RowCount > 0 Then
                        Me.GrdDanhsachngoaite.Rows(0).Selected = True
                    End If
                End If
            End If
        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.LblMangoaite.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblMangoaite.Name, commons.Modules.TypeLanguage)
        Me.ChkMacdinh.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, ChkMacdinh.Name, commons.Modules.TypeLanguage)
        Me.LblTenngoaite.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTenngoaite.Name, commons.Modules.TypeLanguage)
        Me.LblTieudengoaite.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudengoaite.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.GrpNhapngoaite.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpNhapngoaite.Name, commons.Modules.TypeLanguage)
        Me.GrpDanhsachngoaite.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpDanhsachngoaite.Name, commons.Modules.TypeLanguage)

        Me.GrdDanhsachngoaite.Columns("NGOAI_TE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGOAI_TE", commons.Modules.TypeLanguage)
        Me.GrdDanhsachngoaite.Columns("TEN_NGOAI_TE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_NGOAI_TE", commons.Modules.TypeLanguage)
        Me.GrdDanhsachngoaite.Columns("MAC_DINH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MAC_DINH", commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Dim objLoaiMayController As New LOAI_MAYController()
        NGOAI_TE_TMP = TxtMangoaite.Text
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        SHOW_MESSAGE = 1
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        NGOAI_TE_TMP = TxtMangoaite.Text
        TEN_NGOAI_TE_tmp = TxtTenngoaite.Text
        VisibleButton(False)
        LockData(False)
        SHOW_MESSAGE = 2
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        Dim objNGOAITEController As New NGOAI_TEController()
        Dim traloi As String
        Dim dtReader As SqlDataReader
        If GrdDanhsachngoaite.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        SQL = "SELECT * FROM KINH_PHI_NAM WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM EOR_SERVICE_CHUNG WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Ngoại tệ này đang được sử dụng trong EOR, Bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM EOR_SERVICE_MNR WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Ngoại tệ này đang được sử dụng trong EOR, Bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM IC_DON_HANG_NHAP_VAT_TU WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Ngoại tệ này đang được sử dụng trong đơn hàng nhập vật tư, Bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa4", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM LUONG_CO_BAN WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Ngoại tệ này đang được sử dụng trong phần lương cơ bản của nhân viên, bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa5", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM MAY WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            ' Ngoại tệ này đang được sử dụng trong phần thông tin thiết bị, Bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa6", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL = "SELECT * FROM TI_GIA_NT WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa9", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End While
        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa10", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
        If traloi = vbNo Then Exit Sub
        objNGOAITEController.DeleteNGOAI_TE(TxtMangoaite.Text)
        Refesh()
        BindData()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If blnThem Then
            SQL = "SELECT * FROM NGOAI_TE WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"

            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgGhi1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                TxtMangoaite.Focus()
                Exit Sub
            End While
        Else
            If TxtMangoaite.Text <> NGOAI_TE_TMP Then
                SQL = "SELECT * FROM NGOAI_TE WHERE NGOAI_TE='" & TxtMangoaite.Text & "'"

                Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

                While dtReader.Read
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgGhi1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    TxtMangoaite.Focus()
                    Exit Sub
                End While
            End If
        End If
        If SHOW_MESSAGE = 1 Then
            Dim objNGOAITEController As New NGOAI_TEController
            If (objNGOAITEController.CheckTEN_NGOAI_TE(Me.TxtTenngoaite.Text.Trim)).Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTEN_NGOAI_TE", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtTenngoaite.Focus()
                Exit Sub
            End If
        End If

        If isValidated() Then
            Dim i As Integer
            Dim TEMP As String = Me.TxtMangoaite.Text.Trim
            AddNgoaiTe()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < Me.GrdDanhsachngoaite.RowCount
                If Me.GrdDanhsachngoaite.Rows(i).Cells(0).Value = TEMP Then
                    Me.GrdDanhsachngoaite.Rows(i).Cells("NGOAI_TE").Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        End If

        Commons.Modules.sTienTeMD = ""
        Dim dtTmp = New DataTable
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _
                " SELECT TOP 1 ISNULL(NGOAI_TE,'') AS NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1"))
        Catch ex As Exception
        End Try
        Try
            Commons.Modules.sTienTeMD = dtTmp.Rows(0)("NGOAI_TE")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If GrdDanhsachngoaite.RowCount > 0 Then
                ShowNgoaiTe(GrdDanhsachngoaite.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowNgoaiTe(0)
        End Try
        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdPartner_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhsachngoaite.RowHeaderMouseClick
        ShowNgoaiTe(e.RowIndex)
    End Sub

    Private Sub GrdDanhsachngoaite_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachngoaite.RowEnter
        ShowNgoaiTe(e.RowIndex)
    End Sub
#End Region

#Region "Private Methods"
    Sub InitForm()



        Commons.Modules.DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Commons.Modules.DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Commons.Modules.DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdDanhsachngoaite.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1

        Commons.Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Commons.Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Commons.Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdDanhsachngoaite.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

    End Sub
    Sub Refesh()
        TxtMangoaite.Text = ""
        TxtTenngoaite.Text = ""
        ChkMacdinh.Checked = False
    End Sub
    Sub ShowNgoaiTe(ByVal RowIndex As Integer)
        TxtMangoaite.Text = GrdDanhsachngoaite.Rows(RowIndex).Cells("NGOAI_TE").Value
        TxtTenngoaite.Text = GrdDanhsachngoaite.Rows(RowIndex).Cells("TEN_NGOAI_TE").Value
        ChkMacdinh.Checked = GrdDanhsachngoaite.Rows(RowIndex).Cells("MAC_DINH").Value
        count = 1
    End Sub
    Sub BindData()
        Try
            GrdDanhsachngoaite.DataSource = New NGOAI_TEController().GetNGOAI_TEs
            GrdDanhsachngoaite.Columns(0).Width = 80
            GrdDanhsachngoaite.Columns(2).Width = 70
            Me.GrdDanhsachngoaite.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhsachngoaite.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

        If Me.GrdDanhsachngoaite.RowCount > 0 Then
            Me.BtnSua.Enabled = True
            Me.BtnXoa.Enabled = True
        Else
            Me.BtnSua.Enabled = False
            Me.BtnXoa.Enabled = False
        End If
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If
    End Sub
    Function isValidated()
        If Not TxtMangoaite.IsValidated Then
            TxtMangoaite.Focus()
            Return False
        End If
        If Not TxtTenngoaite.IsValidated Then
            TxtTenngoaite.Focus()
            Return False
        End If
        Return True
    End Function
    Sub AddNgoaiTe()
        Dim objNGOAITEInfo As New NGOAI_TEInfo
        Dim objNGOAITEController As New NGOAI_TEController()
        objNGOAITEInfo.TEN_NGOAI_TE = TxtTenngoaite.Text.Trim
        objNGOAITEInfo.MAC_DINH = ChkMacdinh.Checked
        objNGOAITEInfo.NGOAI_TE = TxtMangoaite.Text.Trim
        objNGOAITEInfo.NGOAI_TE_TMP = NGOAI_TE_TMP

        If Not blnThem Then
            Try
                If TEN_NGOAI_TE_tmp <> TxtTenngoaite.Text.Trim And (objNGOAITEController.CheckTEN_NGOAI_TE(Me.TxtTenngoaite.Text.Trim)).Read Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTEN_NGOAI_TE", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Me.TxtTenngoaite.Focus()
                    Dim i As Integer = 0
                    Dim TEMP As String = Me.TxtTenngoaite.Text.Trim
                    While i < Me.GrdDanhsachngoaite.RowCount - 1
                        If Me.GrdDanhsachngoaite.Rows(i).Cells(1).Value = TEMP Then
                            Me.GrdDanhsachngoaite.Rows(i).Cells("TEN_NGOAI_TE").Selected = True
                            Exit While
                        Else
                            i = i + 1
                        End If
                    End While
                    Exit Sub
                Else
                    objNGOAITEController.UpdateNGOAI_TE(objNGOAITEInfo)
                    SHOW_MESSAGE = 1
                End If
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgGhi1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                TxtMangoaite.Focus()
                Exit Sub
            End Try
        Else
            Try
                objNGOAITEInfo.NGOAI_TE = New NGOAI_TEController().AddNGOAI_TE(objNGOAITEInfo)
                SHOW_MESSAGE = 1
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgGhi1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                TxtMangoaite.Focus()
                Exit Sub
            End Try
        End If
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
        TxtMangoaite.ReadOnly = blnLock
        TxtTenngoaite.ReadOnly = blnLock
        ChkMacdinh.Enabled = Not blnLock
        GrdDanhsachngoaite.Enabled = blnLock
    End Sub
    Sub checkDefault()
        For i As Integer = 0 To Me.GrdDanhsachngoaite.Rows.Count - 1
            If Me.GrdDanhsachngoaite.Rows(i).Cells("MAC_DINH").Value = True Then
                count = 1
                NGOAI_TE_VALUE = Me.GrdDanhsachngoaite.Rows(i).Cells("NGOAI_TE").Value
                Exit Sub
            Else
                count = 0
            End If
        Next
    End Sub
#End Region


End Class