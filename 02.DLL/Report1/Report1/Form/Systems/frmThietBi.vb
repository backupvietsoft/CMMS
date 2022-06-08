
Imports Commons.VS.Classes.Catalogue

Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraTab
Imports DevExpress.XtraEditors

Public Class frmThietBi

#Region "Private Members"
    Private blnThem As Boolean
    Private Group_blnThem As Boolean
    Private ID As String = ""
    Private SQL As String
    Private MS_LOAI_MAY_TMP As String
    Private TEN_LOAI_MAY_TMP As String
    Private STT_MAY_TMP As Integer
    Private dvLoaithietbi As DataView
    Private MS_NHOM_MAY_TMP As String
    Private TEN_NHOM_MAY As String
    Private LOAD_GRID As Integer = 1

#End Region

#Region "Equiment Type Event"
    Private Sub frmThietBi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        btnThemNhom.Enabled = chon
        btnXoaNhom.Enabled = chon
        btnSuaNhom.Enabled = chon
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Me.TxtMSLoaiMay.Focus()
        Dim objLoaiMayController As New LOAI_MAYController()
        Dim dtReader As SqlDataReader
        MS_LOAI_MAY_TMP = Me.TxtMSLoaiMay.Text.Trim
        Refesh()
        blnThem = True
        VisibleButton(False)
        LockData(False)
        SQL = "SELECT MS_LOAI_MAY ,TEN_LOAI_MAY,MAX(STT_MAY) FROM LOAI_MAY GROUP BY TEN_LOAI_MAY,MS_LOAI_MAY ORDER BY MAX(STT_MAY)"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        TxtTtsort.Text = 1
        While dtReader.Read
            TxtTtsort.Text = CType(dtReader.Item(2).ToString, Integer) + 1
        End While
        dtReader.Close()
        TxtMSLoaiMay.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        If TxtMSLoaiMay.Text = "" Then Exit Sub
        MS_LOAI_MAY_TMP = TxtMSLoaiMay.Text
        TEN_LOAI_MAY_TMP = TxtLoaithietbi1.Text
        STT_MAY_TMP = TxtTtsort.Text
        VisibleButton(False)
        LockData(False)
        TxtMSLoaiMay.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        Dim objLoaiMayController As New LOAI_MAYController()
        Dim dtReader As SqlDataReader
        If grvLoaiMay.RowCount <= 0 Then
            Commons.MssBox.Show(Me.Name, "MsgXoa1", Me.Text)
            Exit Sub
        End If
        SQL = "SELECT * FROM CONG_VIEC WHERE MS_LOAI_MAY='" & TxtMSLoaiMay.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgXoa2", Me.Text)
            Exit Sub
        End While
        SQL = "SELECT * FROM IC_PHU_TUNG_LOAI_MAY WHERE MS_LOAI_MAY='" & TxtMSLoaiMay.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgXoa3", Me.Text)
            Exit Sub
        End While
        SQL = "SELECT * FROM NHOM_MAY WHERE MS_LOAI_MAY='" & TxtMSLoaiMay.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgXoa4", Me.Text)
            Exit Sub
        End While
        SQL = "SELECT * FROM TRUC_CA WHERE MS_LOAI_MAY='" & TxtMSLoaiMay.Text.Trim.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgTrucCa", Me.Text)
            Exit Sub
        End While

        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa5", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub


        objLoaiMayController.InsertNHOM_LOAI_MAY_1(TxtMSLoaiMay.Text, Me.Name, Commons.Modules.UserName, 3)
        objLoaiMayController.DeleteNHOM_LOAI_MAY_1(TxtMSLoaiMay.Text, Commons.Modules.UserName)
        objLoaiMayController.InsertLOAI_MAY(TxtMSLoaiMay.Text, Me.Name, Commons.Modules.UserName, 3)
        objLoaiMayController.DeleteLOAI_MAY(TxtMSLoaiMay.Text)
        Refesh()
        BindData()

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim objLoaiMayController As LOAI_MAYController = New LOAI_MAYController
        Dim TEMP As String = TxtMSLoaiMay.Text
        Dim i As Integer = 0
        Me.TxtMSLoaiMay.Text = Commons.Modules.ObjSystems.SplitString(Me.TxtMSLoaiMay.Text.Trim)
        Me.TxtLoaithietbi1.Text = Me.TxtLoaithietbi1.Text.Trim


        If TxtMSLoaiMay.Text = "" Then
            TxtMSLoaiMay.Focus()
            Commons.MssBox.Show(Me.Name, "msgChuaNhapMsLoaiMay", Me.Text)
            Exit Sub
        End If

        If TxtLoaithietbi1.Text = "" Then
            TxtLoaithietbi1.Focus()
            Commons.MssBox.Show(Me.Name, "msgChuaNhapTenLoaiMay", Me.Text)
            Exit Sub
        End If



        If blnThem Then
            '' Tăng sửa 13/01/06
            ' Kiểm tra trung mã
            If objLoaiMayController.CheckTRUNG_LOAI_MAY(TxtMSLoaiMay.Text.Trim) And Not BtnKhongghi.Focused Then
                Commons.MssBox.Show(Me.Name, "MsgGhi1", Me.Text)
                TxtMSLoaiMay.Focus()
                TxtMSLoaiMay.Text = ""
                Exit Sub
            End If
            ' Kiểm tra trùng tên
            If objLoaiMayController.CheckTEN_LOAI_MAY(TxtLoaithietbi1.Text.Trim) And Not BtnKhongghi.Focused Then
                Commons.MssBox.Show(Me.Name, "MsgTEN_TB", Me.Text)
                TxtLoaithietbi1.Focus()
                TxtLoaithietbi1.Text = ""
                Exit Sub
            End If
        Else
            If TxtMSLoaiMay.Text.Trim.ToUpper() <> MS_LOAI_MAY_TMP.Trim.ToUpper() Then ' Kiểm tra trùng mã khi thực hiện sửa.
                If objLoaiMayController.CheckTRUNG_LOAI_MAY(TxtMSLoaiMay.Text.Trim) And Not BtnKhongghi.Focused Then
                    Commons.MssBox.Show(Me.Name, "MsgGhi1", Me.Text)
                    TxtMSLoaiMay.Focus()
                    TxtMSLoaiMay.Text = ""
                    Exit Sub
                End If
            End If
            If TxtLoaithietbi1.Text.Trim.ToUpper() <> TEN_LOAI_MAY_TMP.ToUpper() Then ' Kiểm tra trùng tên khi thực hiện sửa.
                If objLoaiMayController.CheckTEN_LOAI_MAY(TxtLoaithietbi1.Text.Trim) And Not BtnKhongghi.Focused Then
                    Commons.MssBox.Show(Me.Name, "MsgTEN_TB", Me.Text)
                    TxtLoaithietbi1.Focus()
                    TxtLoaithietbi1.Text = ""
                    Exit Sub
                End If
            End If
        End If

        Dim SQL As String
        If Not TxtTtsort.Text.Trim.Equals(String.Empty) Then
            If IsNumeric(TxtTtsort.Text.Trim) Then
                If TxtTtsort.Text > 0 Then
                    If CType(TxtTtsort.Text.Trim, Integer) <> STT_MAY_TMP Then
                        SQL = "SELECT * FROM LOAI_MAY WHERE STT_MAY=" & TxtTtsort.Text

                        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)

                        While dtReader.Read
                            Commons.MssBox.Show(Me.Name, "MsgGhi2", Me.Text)
                            TxtTtsort.Focus()
                            Exit Sub
                        End While
                    End If
                Else
                    Commons.MssBox.Show(Me.Name, "MsgSTT_MAY", Me.Text)
                    TxtTtsort.Focus()
                    Exit Sub
                End If
            Else
                Commons.MssBox.Show(Me.Name, "MsgSTT_MAY", Me.Text)
                TxtTtsort.Focus()
                Exit Sub
            End If
        End If

        AddLoaiMay()
        BindData()
        VisibleButton(True)
        LockData(True)
        blnThem = False

        If TEMP <> "" Then
            Dim index As Integer
            index = grvLoaiMay.LocateByValue(0, grvLoaiMay.Columns("MS_LOAI_MAY"), TEMP)
            grvLoaiMay.FocusedRowHandle = index
            If TxtMSLoaiMay.Text = "" Then grvLoaiMay_FocusedRowChanged(Nothing, Nothing)
        End If


    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        VisibleButton(True)
        LockData(True)
        blnThem = False
        Try
            If grvLoaiMay.RowCount > 0 Then
                ShowLoaiMay()
            End If
        Catch ex As Exception
            ShowLoaiMay()
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub


#End Region

#Region "Equipment Type Method"
    Sub Refesh()
        TxtLoaithietbi1.Text = ""
        txtTenLoaiAnh.Text = ""
        TxtTtsort.Text = ""
        TxtMSLoaiMay.Text = ""
        txtGhiChu.Text = ""
    End Sub

    Sub ShowLoaiMay()
        Try
            '
            TxtMSLoaiMay.Text = grvLoaiMay.GetFocusedRowCellValue("MS_LOAI_MAY").ToString
            TxtLoaithietbi1.Text = grvLoaiMay.GetFocusedRowCellValue("TEN_LOAI_MAY").ToString
            txtTenLoaiAnh.Text = grvLoaiMay.GetFocusedRowCellValue("TEN_LOAI_MAY_ANH").ToString
            Try
                txtGhiChu.Text = grvLoaiMay.GetFocusedRowCellValue("GHI_CHU").ToString
            Catch ex As Exception
                txtGhiChu.Text = ""
            End Try

            TxtTtsort.Text = grvLoaiMay.GetFocusedRowCellValue("STT_MAY").ToString
        Catch ex As Exception
            Refesh()
        End Try

    End Sub
    Sub BindData()
        Try
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAY1", Commons.Modules.TypeLanguage))
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiMay, grvLoaiMay, dtTmp, False, True, True, True, True, Me.Name)

            If grvLoaiMay.RowCount > 0 Then
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            Else
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub AddLoaiMay()
        Dim objLoaiMayInfo As New LOAI_MAYInfo
        Dim objLoaiMayController As New LOAI_MAYController()
        objLoaiMayInfo.TEN_LOAI_MAY = TxtLoaithietbi1.Text
        If TxtTtsort.Text.Trim.Equals(String.Empty) Then
            objLoaiMayInfo.STT_MAY = 0
        Else
            objLoaiMayInfo.STT_MAY = TxtTtsort.Text
        End If
        objLoaiMayInfo.MS_LOAI_MAY = TxtMSLoaiMay.Text
        objLoaiMayInfo.MS_LOAI_MAY_TMP = MS_LOAI_MAY_TMP

        If Not blnThem Then
            objLoaiMayController.InsertLOAI_MAY(objLoaiMayInfo.MS_LOAI_MAY, Me.Name, Commons.Modules.UserName, 2)
            objLoaiMayController.UpdateLOAI_MAY(objLoaiMayInfo)
        Else
            objLoaiMayInfo.MS_LOAI_MAY = New LOAI_MAYController().AddLOAI_MAY(objLoaiMayInfo)
            objLoaiMayController.InsertLOAI_MAY(objLoaiMayInfo.MS_LOAI_MAY, Me.Name, Commons.Modules.UserName, 1)
            Dim str As String = ""
            str = "INSERT INTO NHOM_LOAI_MAY SELECT GROUP_ID,'" & TxtMSLoaiMay.Text.Replace("'", "''") & "' AS MS_LOAI_MAY FROM USERS WHERE USERNAME='" & Commons.Modules.UserName & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            Try
                str = "INSERT INTO NHOM_LOAI_MAY SELECT GROUP_ID,'" & TxtMSLoaiMay.Text.Replace("'", "''") & "' AS MS_LOAI_MAY FROM USERS WHERE USERNAME='Administrator'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            Catch ex As Exception

            End Try
            objLoaiMayController.InsertNHOM_LOAI_MAY_1(TxtMSLoaiMay.Text.Replace("'", "''"), Me.Name, Commons.Modules.UserName, 1)
        End If

        Dim sSql As String
        Try
            sSql = "UPDATE LOAI_MAY SET GHI_CHU = " & IIf(txtGhiChu.Text = "", "NULL", "N'" & txtGhiChu.Text & "'") & " WHERE MS_LOAI_MAY = N'" & TxtMSLoaiMay.Text & "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception

        End Try

        Try
            SQL = "UPDATE LOAI_MAY SET TEN_LOAI_MAY_ANH = N'" + txtTenLoaiAnh.Text + "' where MS_LOAI_MAY = N'" + TxtMSLoaiMay.Text + "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        Catch ex As Exception
        End Try

        Refesh()
    End Sub
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtGhiChu.Properties.ReadOnly = blnLock
        TxtMSLoaiMay.Properties.ReadOnly = blnLock
        TxtLoaithietbi1.Properties.ReadOnly = blnLock
        txtTenLoaiAnh.Properties.ReadOnly = blnLock
        txtGhiChu.Properties.ReadOnly = blnLock
        TxtTtsort.Properties.ReadOnly = blnLock
        txtTKiem.Properties.ReadOnly = Not blnLock
        grdLoaiMay.Enabled = blnLock
    End Sub


    Private Sub TxtMSLoaiMay_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTKiem.Validated, TxtMSLoaiMay.Validated
        If BtnGhi.Visible = False Then Exit Sub
        Me.TxtMSLoaiMay.Text = Commons.Modules.ObjSystems.SplitString(Me.TxtMSLoaiMay.Text.Trim)
    End Sub

    Private Sub TxtLoaithietbi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLoaithietbi1.Validated, txtTenLoaiAnh.Validated  'Handles TxtLoaithietbi.Validated
        If BtnGhi.Visible = False Then Exit Sub
        Me.TxtLoaithietbi1.Text = Me.TxtLoaithietbi1.Text.Trim
    End Sub

#End Region

#Region "Equiment Group Event"


    Sub Group_Refesh()
        TxtTennhomthietbi.Text = ""
        txtTenNhomAnh.Text = ""
        TxtMSNhomthietbi.Text = ""
        txtGChu.Text = ""

    End Sub
    Sub ShowNhomMay()
        If grdNhomMay.DataSource Is Nothing Then Exit Sub
        Try

            TxtMSNhomthietbi.Text = grvNhomMay.GetFocusedRowCellValue("MS_NHOM_MAY").ToString
            TxtTennhomthietbi.Text = grvNhomMay.GetFocusedRowCellValue("TEN_NHOM_MAY").ToString
            txtTenNhomAnh.Text = grvNhomMay.GetFocusedRowCellValue("TEN_NHOM_MAY_ANH").ToString
            cboLoaiMay.EditValue = grvNhomMay.GetFocusedRowCellValue("MS_LOAI_MAY").ToString
            Try
                txtGChu.Text = grvNhomMay.GetFocusedRowCellValue("GHI_CHU").ToString
            Catch ex As Exception
                txtGChu.Text = ""
            End Try
        Catch ex As Exception

        End Try

    End Sub

    Sub BindCombo()
        Dim dtTmp = New NHOM_MAYController().GetLOAI_MAYs()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "")


    End Sub
    Sub Group_BindData()
        Try

            'BindCombo()
            If cboLoaiMay.ItemIndex = -1 Then Exit Sub
            grdNhomMay.DataSource = Nothing
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHOM_MAY", cboLoaiMay.EditValue, Commons.Modules.TypeLanguage))
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhomMay, grvNhomMay, dtTmp, False, True, True, True, True, Me.Name)

            Me.grvNhomMay.Columns("MS_LOAI_MAY").Visible = False
            Me.grvNhomMay.Columns("TEN_LOAI_MAY").Visible = False



            If grvNhomMay.RowCount > 0 Then
                btnSuaNhom.Enabled = True
                btnXoaNhom.Enabled = True
            Else
                btnSuaNhom.Enabled = False
                btnXoaNhom.Enabled = False
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
            If TxtTennhomthietbi.Text = "" Then grvNhomMay_FocusedRowChanged(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Function Group_isValidated()
        If TxtMSNhomthietbi.Text = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaNhapMaNhomThietBi", Me.Text)
            TxtMSNhomthietbi.Focus()
            Return False
        End If
        If TxtTennhomthietbi.Text.ToString.Trim = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaNhapTenNhomThietBi", Me.Text)
            TxtTennhomthietbi.Focus()
            Return False
        End If
        Return True
    End Function
    Sub AddNHOM_MAY()
        Dim objNHOM_MAYInfo As New NHOM_MAYInfo
        Dim objNHOM_MAYController As New NHOM_MAYController()

        objNHOM_MAYInfo.TEN_NHOM_MAY = TxtTennhomthietbi.Text
        objNHOM_MAYInfo.MS_NHOM_MAY = TxtMSNhomthietbi.Text.Trim
        objNHOM_MAYInfo.MS_LOAI_MAY = cboLoaiMay.EditValue

        If Not Group_blnThem Then ' Tăng sửa 12/01/06
            objNHOM_MAYInfo.MS_NHOM_MAY_TMP = MS_NHOM_MAY_TMP
            objNHOM_MAYInfo.MS_LOAI_MAY_TMP = MS_LOAI_MAY_TMP
            objNHOM_MAYController.InsertNHOM_MAY_LOG(objNHOM_MAYInfo.MS_NHOM_MAY, Me.Name, Commons.Modules.UserName, 2)
            objNHOM_MAYController.UpdateNHOM_MAY(objNHOM_MAYInfo)
        Else ' Tăng sửa 12/01/06
            objNHOM_MAYController.AddNHOM_MAY(objNHOM_MAYInfo)
            objNHOM_MAYController.InsertNHOM_MAY_LOG(objNHOM_MAYInfo.MS_NHOM_MAY, Me.Name, Commons.Modules.UserName, 1)
        End If

        Dim sSql As String
        Try
            sSql = "UPDATE NHOM_MAY SET GHI_CHU = " & IIf(txtGChu.Text = "", "NULL", "N'" & txtGChu.Text & "'") & " WHERE MS_NHOM_MAY = N'" & objNHOM_MAYInfo.MS_NHOM_MAY & "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception

        End Try
        Try
            SQL = "UPDATE NHOM_MAY SET TEN_NHOM_MAY_ANH = N'" + txtTenNhomAnh.Text + "'  WHERE MS_NHOM_MAY = N'" + TxtMSNhomthietbi.Text + "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        Catch ex As Exception
        End Try
        Group_RefeshForm(True)
        Group_blnThem = False
        LOAD_GRID = 1
        Group_Refesh()
        Group_BindData()
    End Sub
    Sub Group_VisibleButton(ByVal blnVisible As Boolean)
        btnThemNhom.Visible = blnVisible
        btnSuaNhom.Visible = blnVisible
        btnThoatNhom.Visible = blnVisible
        btnXoaNhom.Visible = blnVisible
        btnGhiNhom.Visible = Not blnVisible
        btnKhongGhiNhom.Visible = Not blnVisible
    End Sub
    Sub Group_RefeshForm(ByVal blnVisible As Boolean)
        Group_VisibleButton(blnVisible)
        Group_LockData(blnVisible)
        Group_BindData()
        Group_Refesh()
    End Sub
    Sub Group_LockData(ByVal blnLock As Boolean)
        TxtMSNhomthietbi.Properties.ReadOnly = blnLock
        TxtTennhomthietbi.Properties.ReadOnly = blnLock
        txtTenNhomAnh.Properties.ReadOnly = blnLock
        txtGChu.Properties.ReadOnly = blnLock
        grdNhomMay.Enabled = blnLock
    End Sub
#End Region

#Region "Equipment Group Event"
    Private Sub BtnThemNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemNhom.Click
        Me.TxtMSNhomthietbi.Focus()
        Dim objNHOM_MAYController As New NHOM_MAYController()
        Group_Refesh()
        Group_VisibleButton(False)
        Group_LockData(False)
        Group_blnThem = True
    End Sub
    Dim msNhomMayOld As String = ""
    Private Sub btnSua_Group(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuaNhom.Click
        Me.TxtMSNhomthietbi.Focus()
        MS_NHOM_MAY_TMP = TxtMSNhomthietbi.Text
        MS_LOAI_MAY_TMP = cboLoaiMay.EditValue
        TEN_NHOM_MAY = TxtTennhomthietbi.Text
        Group_VisibleButton(False)
        Group_LockData(False)
        Group_blnThem = False
        msNhomMayOld = TxtMSNhomthietbi.Text
        cboLoaiMay.Properties.ReadOnly = True
    End Sub

    Private Sub btnXoa_Group(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaNhom.Click
        Dim objNHOM_MAYController As New NHOM_MAYController()
        Dim dtReader As SqlDataReader
        If grvNhomMay.RowCount <= 0 Then
            Commons.MssBox.Show(Me.Name, "MsgXoa1", Me.Text)
            Exit Sub
        End If
        SQL = "SELECT * FROM MAY WHERE MS_NHOM_MAY='" & TxtMSNhomthietbi.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgXoa2", Me.Text)
            Exit Sub
        End While

        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCONFIRM", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub

        objNHOM_MAYController.InsertNHOM_MAY(TxtMSNhomthietbi.Text, cboLoaiMay.EditValue, Me.Name, Commons.Modules.UserName, 3)
        objNHOM_MAYController.DeleteNHOM_MAY(TxtMSNhomthietbi.Text, cboLoaiMay.EditValue)
        Group_Refesh()
        Group_BindData()
    End Sub

    Private Sub btnGhi_Group(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhiNhom.Click

        Dim objclsNHOMMAYController As NHOM_MAYController = New NHOM_MAYController
        If Group_blnThem Then
            ' Kiểm tra trùng mã
            If objclsNHOMMAYController.CheckTRUNG_NHOM_MAY(TxtMSNhomthietbi.Text.Trim) Then
                Commons.MssBox.Show(Me.Name, "MsgGhi1", Me.Text)
                TxtMSNhomthietbi.Focus()
                Exit Sub
            End If
            ' Kiểm tra trùng tên
            If (objclsNHOMMAYController.CheckTEN_NHOM_MAY(TxtTennhomthietbi.Text.Trim, cboLoaiMay.EditValue)).Read Then
                Commons.MssBox.Show(Me.Name, "MsgTEN_MAY", Me.Text)
                Me.TxtTennhomthietbi.Focus()
                Exit Sub
            End If
        Else
            ' Kiểm tra trùng mã
            If TxtMSNhomthietbi.Text.Trim <> MS_NHOM_MAY_TMP Then
                If objclsNHOMMAYController.CheckTRUNG_NHOM_MAY(TxtMSNhomthietbi.Text.Trim) Then
                    Commons.MssBox.Show(Me.Name, "MsgGhi1", Me.Text)
                    TxtMSNhomthietbi.Focus()
                    Exit Sub
                End If
            End If
            If TxtTennhomthietbi.Text.Trim <> TEN_NHOM_MAY Then ' Kiểm tra trùng tên
                Dim sql As String = "SELECT * FROM NHOM_MAY WHERE MS_LOAI_MAY='" + cboLoaiMay.EditValue + "' AND  TEN_NHOM_MAY=N'" + TxtTennhomthietbi.Text.Trim + "' and MS_NHOM_MAY <> '" + msNhomMayOld + "'"
                Dim SqlReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                If (SqlReader.Read) Then
                    Commons.MssBox.Show(Me.Name, "MsgTEN_MAY", Me.Text)
                    Me.TxtTennhomthietbi.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Group_isValidated() Then
            Dim i As Integer = 0
            Dim MS_THIET_BI_TEMP As String = TxtMSNhomthietbi.Text.Trim
            AddNHOM_MAY()
            If LOAD_GRID = 1 Then
                If MS_THIET_BI_TEMP <> "" Then
                    Dim index As Integer
                    index = grvNhomMay.LocateByValue(0, grvNhomMay.Columns("MS_NHOM_MAY"), MS_THIET_BI_TEMP)
                    grvNhomMay.FocusedRowHandle = index
                    If TxtTennhomthietbi.Text = "" Then grvNhomMay_FocusedRowChanged(Nothing, Nothing)
                End If
            End If
        End If



        LockData(True)
        cboLoaiMay.Properties.ReadOnly = False
    End Sub

    Private Sub btnKhongGhi_Group(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhiNhom.Click
        Me.TxtMSNhomthietbi.Enabled = True
        Group_Refesh()

        Try
            If grvNhomMay.RowCount > 0 Then
                ShowNhomMay()
            End If
        Catch ex As Exception
            Group_Refesh()
        End Try
        Group_blnThem = False
        Group_VisibleButton(True)
        Group_LockData(True)
        cboLoaiMay.Properties.ReadOnly = False
    End Sub

    Private Sub btnThoat_Group(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoatNhom.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub


    Private Sub cboLoaiMay_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiMay.EditValueChanged
        If btnGhiNhom.Visible Then Exit Sub
        Group_BindData()
        ShowNhomMay()
    End Sub

    Private Sub TxtMSNhomthietbi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMSNhomthietbi.Validated
        If btnKhongGhiNhom.Focused Then Exit Sub
        If Not btnGhiNhom.Visible Then Exit Sub

        Me.TxtMSNhomthietbi.Text = Commons.Modules.ObjSystems.SplitString(Me.TxtMSNhomthietbi.Text.Trim)

        'If TxtMSNhomthietbi.Text = "" Then
        '    TxtMSNhomthietbi.Focus()
        'End If

        Dim objclsNHOMMAYController As NHOM_MAYController = New NHOM_MAYController
        If Group_blnThem Then
            If objclsNHOMMAYController.CheckTRUNG_NHOM_MAY(TxtMSNhomthietbi.Text.Trim) Then
                Commons.MssBox.Show(Me.Name, "MsgGhi1", Me.Text)
                TxtMSNhomthietbi.Focus()
                TxtMSNhomthietbi.SelectAll()
                Exit Sub
            End If
        Else
            If TxtMSNhomthietbi.Text.Trim <> MS_NHOM_MAY_TMP Then
                If objclsNHOMMAYController.CheckTRUNG_NHOM_MAY(TxtMSNhomthietbi.Text.Trim) Then
                    Commons.MssBox.Show(Me.Name, "MsgGhi1", Me.Text)
                    TxtMSNhomthietbi.Focus()
                    TxtMSNhomthietbi.SelectAll()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub TxtTennhomthietbi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTennhomthietbi.Validated
        If btnKhongGhiNhom.Focused Then Exit Sub
        If Not btnGhiNhom.Visible Then Exit Sub

        Me.TxtTennhomthietbi.Text = Me.TxtTennhomthietbi.Text.Trim

        If TxtTennhomthietbi.ToString.Trim = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaNhapNhomMay", Me.Text)
            Me.TxtTennhomthietbi.Focus()
        End If

        Dim objclsNHOMMAYController As NHOM_MAYController = New NHOM_MAYController
        If Group_blnThem Then
            If (objclsNHOMMAYController.CheckTEN_NHOM_MAY(TxtTennhomthietbi.Text.Trim, cboLoaiMay.EditValue)).Read Then
                Commons.MssBox.Show(Me.Name, "MsgTEN_MAY", Me.Text)
                Me.TxtTennhomthietbi.Focus()
                Me.TxtTennhomthietbi.SelectAll()
                Exit Sub
            End If
        ElseIf TxtTennhomthietbi.Text.Trim <> TEN_NHOM_MAY Then
            Dim sql As String = "SELECT * FROM NHOM_MAY WHERE MS_LOAI_MAY='" + cboLoaiMay.EditValue + "' AND  TEN_NHOM_MAY=N'" + TxtTennhomthietbi.Text.Trim + "' and MS_NHOM_MAY <> '" + msNhomMayOld + "'"
            Dim SqlReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            If (SqlReader.Read) Then
                Commons.MssBox.Show(Me.Name, "MsgTEN_MAY", Me.Text)
                Me.TxtTennhomthietbi.Focus()
                Me.TxtTennhomthietbi.SelectAll()
                Exit Sub
            End If
        End If
    End Sub
#End Region
    Private Sub khongGhi()
        Refesh()
        Try
            If grvLoaiMay.RowCount > 0 Then
                ShowLoaiMay()
            End If
        Catch ex As Exception
            ShowLoaiMay()
        End Try

        VisibleButton(True)
        LockData(True)
        blnThem = False
    End Sub


    Private Sub grvLoaiMay_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvLoaiMay.FocusedRowChanged
        ShowLoaiMay()
    End Sub

    Private Sub grvLoaiMay_DoubleClick(sender As Object, e As EventArgs) Handles grvLoaiMay.DoubleClick
        tabThietBi.SelectedTabPageIndex = 1
    End Sub

    Private Sub tabThietBi_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles tabThietBi.SelectedPageChanged
        Try

            Select Case tabThietBi.SelectedTabPageIndex
                Case 0
                    If cboLoaiMay.Text = "" Then Exit Sub
                    If cboLoaiMay.EditValue = TxtMSLoaiMay.Text Then Exit Sub
                    Dim index As Integer
                    index = grvLoaiMay.LocateByValue(0, grvLoaiMay.Columns("MS_LOAI_MAY"), cboLoaiMay.EditValue)
                    grvLoaiMay.FocusedRowHandle = index
                    If TxtMSLoaiMay.Text = "" Then grvLoaiMay_FocusedRowChanged(Nothing, Nothing)
                Case 1
                    If cboLoaiMay.EditValue = TxtMSLoaiMay.Text Then Exit Sub
                    BindCombo()
                    Group_Refesh()
                    cboLoaiMay.EditValue = TxtMSLoaiMay.Text
                    Group_BindData()
                    Group_VisibleButton(True)
                    Group_LockData(True)
                    If Me.grvNhomMay.RowCount > 0 Then
                        grvNhomMay_FocusedRowChanged(Nothing, Nothing)
                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTKiem_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtTKiem.EditValueChanging
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grdLoaiMay.DataSource, DataTable)
            Dim str As String = ""
            str = " MS_LOAI_MAY like '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY like '%" + txtTKiem.Text + "%'  "
            dtTmp.DefaultView.RowFilter = str
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
        dtTmp = dtTmp.DefaultView.ToTable()
    End Sub

    Private Sub tabThietBi_SelectedPageChanging(sender As Object, e As TabPageChangingEventArgs) Handles tabThietBi.SelectedPageChanging
        If BtnGhi.Visible = True Or btnGhiNhom.Visible Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub grvNhomMay_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvNhomMay.FocusedRowChanged
        ShowNhomMay()
    End Sub

    Private Sub txtTKNhom_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtTKNhom.EditValueChanging
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grdNhomMay.DataSource, DataTable)
            Dim str As String = ""
            str = " MS_NHOM_MAY like '%" + txtTKNhom.Text + "%' OR TEN_NHOM_MAY like '%" + txtTKNhom.Text + "%'  "
            dtTmp.DefaultView.RowFilter = str
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
        dtTmp = dtTmp.DefaultView.ToTable()
    End Sub

    Private Sub txtTenNhomAnh_Validated(sender As Object, e As EventArgs) Handles txtTenNhomAnh.Validated
        If btnKhongGhiNhom.Focused Then Exit Sub
        If Not btnGhiNhom.Visible Then Exit Sub

        Me.txtTenNhomAnh.Text = Me.txtTenNhomAnh.Text.Trim

        If txtTenNhomAnh.ToString.Trim = "" Then
            Commons.MssBox.Show(Me.Name, "ChuaNhapNhomMay", Me.Text)
            Me.txtTenNhomAnh.Focus()
        End If
        Dim sSql As String

        Dim bCoData As Boolean


        Dim objclsNHOMMAYController As NHOM_MAYController = New NHOM_MAYController
        If Group_blnThem Then
            sSql = "SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END AS REC  FROM NHOM_MAY WHERE MS_LOAI_MAY= N'" & cboLoaiMay.EditValue.ToString() & "' AND  TEN_NHOM_MAY_ANH= N'" & txtTenNhomAnh.Text.Trim & "' "
            bCoData = False
            Try
                bCoData = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql))
            Catch ex As Exception
                bCoData = False
            End Try

            If bCoData Then
                Commons.MssBox.Show(Me.Name, "MsgTEN_MAY", Me.Text)
                Me.txtTenNhomAnh.Focus()
                Me.txtTenNhomAnh.SelectAll()
                Exit Sub
            End If
        ElseIf txtTenNhomAnh.Text.Trim <> TEN_NHOM_MAY Then
            sSql = "SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END AS REC FROM NHOM_MAY WHERE MS_LOAI_MAY= N'" + cboLoaiMay.EditValue + "' AND  TEN_NHOM_MAY_ANH = N'" + txtTenNhomAnh.Text.Trim + "' AND MS_NHOM_MAY <> '" + msNhomMayOld + "'"
            bCoData = False
            Try
                bCoData = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql))
            Catch ex As Exception
                bCoData = False
            End Try
            If bCoData Then
                Commons.MssBox.Show(Me.Name, "MsgTEN_MAY", Me.Text)
                Me.txtTenNhomAnh.Focus()
                Me.txtTenNhomAnh.SelectAll()
                Exit Sub
            End If

        End If
    End Sub
End Class

