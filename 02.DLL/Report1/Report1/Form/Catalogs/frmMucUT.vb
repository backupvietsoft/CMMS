
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmMucUT


    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private MS_tmp As Integer
    Private TEN_tmp As String

#Region "Control Event"

    Private Sub FrmBacTho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BindData(-1)
            VisibleButton(True)
            LockData(True)
            grvMUT_FocusedRowChanged(Nothing, Nothing)
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Catch ex As Exception

        End Try
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
        txtMaso.Focus()

        grpDanhsachmucUT.Enabled = False
        AddHandler txtMaso.Validated, AddressOf Me.txtMaso_Validated
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        If txtMaso.Text = "" Then Exit Sub
        If txtMucUT.Text = "" Then Exit Sub
        MS_tmp = txtMaso.Text
        TEN_tmp = txtMucUT.Text
        VisibleButton(False)
        LockData(False)
        grpDanhsachmucUT.Enabled = False
        AddHandler txtMaso.Validated, AddressOf Me.txtMaso_Validated
        txtMaso.ReadOnly = True
        txtMucUT.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grvMUT.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            Dim SQL_TMP As String = "SELECT * FROM MAY WHERE MUC_UU_TIEN = '" & txtMaso.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_UU_TIEN='" & txtMaso.Text & "'")
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKHTTCV", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI WHERE MS_UU_TIEN='" & txtMaso.Text & "'")
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPhieuBaoTri", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM KE_HOACH_THUC_HIEN WHERE MS_UU_TIEN='" & txtMaso.Text & "'")
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKeHoachThucHien", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()

            Dim objMucUTController As New MUC_UU_TIENController()
            objMucUTController.DeleteMUC_UU_TIEN(txtMaso.Text)
            Refesh()
            BindData(-1)
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim iMaSo As Integer = Integer.Parse(txtMaso.Text)


        If Trim(txtMaso.Text) = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtMaso.Focus()
            txtMaso.Text = ""
            Exit Sub
        End If
        If Trim(txtMucUT.Text) = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtMucUT.Focus()
            Exit Sub
        End If
        If (Convert.ToInt32(txtSoNgayBD.Text) > Convert.ToInt32(txtSoNgayKT.Text)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayBDNhoorBangKT", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtSoNgayBD.Focus()
            Exit Sub
        End If

        SQL_TMP = "SELECT * FROM MUC_UU_TIEN WHERE MS_UU_TIEN = '" & txtMaso.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            If blnThem Then
                If Not BtnKhongghi.Focused Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtMaso.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            Else
                If Not BtnKhongghi.Focused And txtMaso.Text <> MS_tmp Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtMaso.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            End If
        End While

        SQL_TMP = "SELECT * FROM MUC_UU_TIEN WHERE TEN_UU_TIEN = '" & txtMucUT.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)

        While dtReader.Read
            If blnThem Then
                If Not BtnKhongghi.Focused Then
                    ' Mức ưu tiên này đã tồn tại ! vui lòng nhập tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi6", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtMucUT.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            Else
                If Not BtnKhongghi.Focused And txtMucUT.Text <> TEN_tmp Then
                    ' Mức ưu tiên này đã tồn tại ! vui lòng nhập tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi6", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtMucUT.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            End If
        End While

        If isValidated() Then
            AddMucUT()
            BindData(iMaSo)
            blnThem = False
            VisibleButton(True)
            LockData(True)
            grvMUT_FocusedRowChanged(Nothing, Nothing)
        End If
        grpDanhsachmucUT.Enabled = True
        RemoveHandler txtMaso.Validated, AddressOf Me.txtMaso_Validated
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refresh()
        Try
            If grvMUT.RowCount <> 0 Then
                grvMUT_FocusedRowChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            Refesh()
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
        grpDanhsachmucUT.Enabled = True
        RemoveHandler txtMaso.Validated, AddressOf Me.txtMaso_Validated
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub txtSoNgayKT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoNgayKT.Validated 'Handles txtMaso.Validated
        If (BtnGhi.Visible = False) Then Exit Sub
        txtSoNgayKT.Text = Trim(txtSoNgayKT.Text)
        If txtSoNgayKT.Text = "" And Not BtnKhongghi.Focused Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgVuiLongNhapSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtSoNgayKT.Focus()
            txtSoNgayKT.Text = ""
        Else
            If txtSoNgayKT.Text <> "" Then
                If Not IsNumeric(txtSoNgayKT.Text) And Not BtnKhongghi.Focused Then

                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi4", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtSoNgayKT.Focus()
                    Return
                Else
                    If Convert.ToInt32(txtSoNgayKT.Text) < 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoDuong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        txtSoNgayKT.Focus()
                        Return
                    End If


                End If
            End If
        End If
    End Sub

    Private Sub txtSoNgayBD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoNgayBD.Validated 'Handles txtMaso.Validated
        txtSoNgayBD.Text = Trim(txtSoNgayBD.Text)
        If txtSoNgayBD.Text = "" And Not BtnKhongghi.Focused Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgVuiLongNhapSo", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtSoNgayBD.Focus()
            txtSoNgayBD.Text = ""
        Else
            If txtSoNgayBD.Text <> "" Then
                If Not IsNumeric(txtSoNgayBD.Text) And Not BtnKhongghi.Focused Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi4", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtSoNgayBD.Focus()
                    Return
                ElseIf Convert.ToInt32(txtSoNgayBD.Text) < 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoDuong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtSoNgayBD.Focus()
                    Return

                End If

            End If
        End If
    End Sub

    Private Sub txtMaso_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtMaso.Validated
        txtMaso.Text = Trim(txtMaso.Text)
        If txtMaso.Text = "" And Not BtnKhongghi.Focused Then
            ' Mã số không được rỗng ! Vui lòng nhập vào mã số !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtMaso.Focus()
            txtMaso.Text = ""
        Else
            If txtMaso.Text <> "" Then
                If Not IsNumeric(txtMaso.Text) And Not BtnKhongghi.Focused Then
                    ' Mã số phải có kiểu số !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi4", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtMaso.Focus()
                    txtMaso.Text = ""
                Else
                    SQL_TMP = "SELECT * FROM MUC_UU_TIEN WHERE MS_UU_TIEN = '" & txtMaso.Text & "'"
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
                    While dtReader.Read
                        If blnThem Then
                            If Not BtnKhongghi.Focused Then
                                ' Mã số này đã tồn tại ! Vui lòng nhập lại !
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                txtMaso.Focus()
                                dtReader.Close()
                                Exit Sub
                            End If
                        Else
                            If Not BtnKhongghi.Focused And txtMaso.Text <> MS_tmp Then
                                ' Mã số này đã tồn tại ! Vui lòng nhập lại !
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                txtMaso.Focus()
                                dtReader.Close()
                                Exit Sub
                            End If
                        End If
                    End While
                End If
            End If
        End If
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        txtMaso.Text = ""
        txtMucUT.Text = ""
        txtSoNgayKT.Text = 0
        txtSoNgayBD.Text = 0
    End Sub
    Sub ShowBacTho()
        Try
            txtMaso.Text = grvMUT.GetFocusedRowCellValue("MS_UU_TIEN").ToString()
            txtMucUT.Text = grvMUT.GetFocusedRowCellValue("TEN_UU_TIEN").ToString()
            txtSoNgayBD.Text = grvMUT.GetFocusedRowCellValue("SO_NGAY_PHAI_BD").ToString()
            txtSoNgayKT.Text = grvMUT.GetFocusedRowCellValue("SO_NGAY_PHAI_KT").ToString()
        Catch ex As Exception
            Refesh()
        End Try

    End Sub
    Sub BindData(iMs As Integer)
        Dim dt = New DataTable
        dt = New MUC_UU_TIENController().GetMUC_UU_TIENs
        dt.PrimaryKey = New DataColumn() {dt.Columns("MS_UU_TIEN")}
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdMUT, grvMUT, dt, False, True, True, True, True, Me.Name.ToString())

        If iMs <> -1 Then
            Dim index As Integer
            index = dt.Rows.IndexOf(dt.Rows.Find(iMs))
            grvMUT.FocusedRowHandle = grvMUT.GetRowHandle(index)
        End If

    End Sub
    Function isValidated()
        If Not txtMaso.IsValidated Then
            Return False
        End If
        If String.IsNullOrEmpty(txtMucUT.Text.Trim()) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMucUuTienRong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Return False
        End If
        Return True
    End Function

    Sub AddMucUT()
        Dim objMucUTInfo As New MUC_UU_TIENInfo
        Dim objMucUTController As New MUC_UU_TIENController()
        objMucUTInfo.MS_UU_TIEN = Commons.Modules.ObjSystems.SplitString(txtMaso.Text)
        objMucUTInfo.TEN_UU_TIEN = txtMucUT.Text
        If Not blnThem Then

            objMucUTInfo.MS_UU_TIEN_tmp = Commons.Modules.ObjSystems.SplitString(MS_tmp)
            objMucUTController.UpdateMUC_UU_TIEN(objMucUTInfo)
        Else
            objMucUTController.AddMUC_UU_TIEN(objMucUTInfo)
        End If

        If (String.IsNullOrEmpty(Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu.Trim())) Then
            Dim str As String = "UPDATE MUC_UU_TIEN SET SO_NGAY_PHAI_BD = " & txtSoNgayBD.Text.Trim() & " , SO_NGAY_PHAI_KT = " & txtSoNgayKT.Text.Trim() & " WHERE MS_UU_TIEN = " & objMucUTInfo.MS_UU_TIEN
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Else
            Dim str As String = "UPDATE MUC_UU_TIEN SET SO_NGAY_PHAI_BD = " & txtSoNgayBD.Text.Trim() & " , SO_NGAY_PHAI_KT = " & txtSoNgayKT.Text.Trim() & ", TEN_TA = N'" & Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu & "' WHERE MS_UU_TIEN = " & objMucUTInfo.MS_UU_TIEN
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)



        End If



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
        txtMaso.ReadOnly = blnLock
        txtMucUT.Properties.ReadOnly = blnLock

        txtSoNgayBD.Properties.ReadOnly = blnLock
        txtSoNgayKT.Properties.ReadOnly = blnLock
    End Sub

    Private Sub txtMucUT_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtMucUT.ButtonClick
        If txtMucUT.Text.Trim = "" Then Exit Sub
        Dim sLoi As String = ""
        'If BtnGhi.Visible = False Then
        If Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblfrmMucUuTienAnh", Commons.Modules.TypeLanguage),
                                                     "MUC_UU_TIEN", "TEN_TA", " WHERE MS_UU_TIEN = " + txtMaso.Text.Trim(), sLoi) = False Then
            MessageBox.Show(sLoi)
        End If
    End Sub

    Private Sub grvMUT_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvMUT.FocusedRowChanged
        ShowBacTho()
    End Sub
#End Region

End Class