Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.Common

Imports Commons.VS.Classes.Admin

Public Class frmDonvitinh

#Region "Private Member"
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private DVT_TMP As String = ""
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader

#End Region

#Region "Control Event"

    Private Sub FrmDonvitinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        VisibleButton(True)
        LockData(True)
        If Commons.Modules.PermisString.Equals("Read only") Then
            BindData()
            EnableButton(False)
        Else
            EnableButton(True)
            BindData()
        End If
        RefeshLanguage()

        If Me.GrdDanhsachloaivattu.RowCount > 0 Then
            Me.GrdDanhsachloaivattu.Rows(0).Selected = True
        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.lblDVT_VN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblDVT_VN.Name, commons.Modules.TypeLanguage)
        Me.lblDVT_EN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblDVT_EN.Name, commons.Modules.TypeLanguage)
        Me.lblDVT_CHINA.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblDVT_CHINA.Name, commons.Modules.TypeLanguage)
        Me.LblMadonvitinh.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblMadonvitinh.Name, commons.Modules.TypeLanguage)
        'Me.LblTieudedonvitinh.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudedonvitinh.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.GrpDanhsachdonvitinh.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpDanhsachdonvitinh.Name, commons.Modules.TypeLanguage)
        Me.GrpNhapdonvitinh.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpNhapdonvitinh.Name, commons.Modules.TypeLanguage)

        Me.GrdDanhsachloaivattu.Columns("TEN_1").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_1", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaivattu.Columns("TEN_2").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_2", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaivattu.Columns("TEN_3").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_3", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaivattu.Columns("DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DVT", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaivattu.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GHI_CHU_1", commons.Modules.TypeLanguage)

    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        LockData(False)
        blnThem = True
        TxtMadonvitinh.Focus()
        AddHandler TxtMadonvitinh.Validating, AddressOf Me.TxtMadonvitinh_Validating
        AddHandler txtDVT_VN.Validating, AddressOf Me.txtDVT_VN_Validating
        Refesh()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        DVT_TMP = TxtMadonvitinh.Text
        LockData(False)
        AddHandler TxtMadonvitinh.Validating, AddressOf Me.TxtMadonvitinh_Validating
        AddHandler txtDVT_VN.Validating, AddressOf Me.txtDVT_VN_Validating
        TxtMadonvitinh.ReadOnly = True
        txtDVT_VN.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If GrdDanhsachloaivattu.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            ' Kiểm tra đơn vị tính này có tồn tại trong bảng IC_PHU_TUNG không.
            SQL_TMP = "SELECT * FROM IC_PHU_TUNG WHERE DVT = '" & TxtMadonvitinh.Text.Replace("'", "''") & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While
            ' Xóa đơn vị tính
            Dim objDonViTinhController As New DON_VI_TINHController()
            objDonViTinhController.InsertDON_VI_TINH(TxtMadonvitinh.Text, Me.Name, Commons.Modules.UserName, 3)
            objDonViTinhController.DeleteDON_VI_TINH(TxtMadonvitinh.Text)
            
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If GrdDanhsachloaivattu.RowCount > 0 Then
                If GrdDanhsachloaivattu.Rows.Count = tmp Then
                    GrdDanhsachloaivattu.CurrentCell() = GrdDanhsachloaivattu.Rows(tmp - 1).Cells("TEN_1")
                    GrdDanhsachloaivattu.Focus()
                Else
                    GrdDanhsachloaivattu.CurrentCell() = GrdDanhsachloaivattu.Rows(tmp).Cells("TEN_1")
                    GrdDanhsachloaivattu.Focus()
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim TMP As String = commons.Modules.ObjSystems.SplitString(TxtMadonvitinh.Text)

        SQL_TMP = "SELECT * FROM DON_VI_TINH WHERE DON_VI_TINH.DVT = '" & TMP.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)

        If blnThem Then
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi4", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                TxtMadonvitinh.Focus()
                Exit Sub
            End While
        Else
            If Not DVT_TMP.Equals(TxtMadonvitinh.Text.Trim) Then
                While dtReader.Read
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi4", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    TxtMadonvitinh.Focus()
                    Exit Sub
                End While
            End If
        End If

        If Not IsNumeric(TxtMadonvitinh.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSaiMa", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            TxtMadonvitinh.Focus()
            Exit Sub
        End If

        If isValidated() Then
            If AddDonViTinh() Then
                BindData()
                blnThem = False
                VisibleButton(True)
                LockData(True)
                While i < GrdDanhsachloaivattu.RowCount
                    If GrdDanhsachloaivattu.Rows(i).Cells(0).Value.ToString = TMP Then
                        GrdDanhsachloaivattu.Rows(i).Cells(0).Selected = True
                        Exit While
                    Else
                        i = i + 1
                    End If
                End While
                RemoveHandler TxtMadonvitinh.Validating, AddressOf Me.TxtMadonvitinh_Validating
                RemoveHandler txtDVT_VN.Validating, AddressOf Me.txtDVT_VN_Validating
            End If
        End If

    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        Try
            If GrdDanhsachloaivattu.RowCount <> 0 Then
                ShowDonViTinh(GrdDanhsachloaivattu.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowDonViTinh(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
        RemoveHandler TxtMadonvitinh.Validating, AddressOf Me.TxtMadonvitinh_Validating
        RemoveHandler txtDVT_VN.Validating, AddressOf Me.txtDVT_VN_Validating
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub GrdDanhsachdonvitinh_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhsachloaivattu.RowHeaderMouseClick
        ShowDonViTinh(e.RowIndex)
    End Sub
    Dim intRow As Integer
    Private Sub GrdDanhsachdonvitinh_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachloaivattu.RowEnter
        ShowDonViTinh(e.RowIndex)
        intRow = e.RowIndex
    End Sub
#End Region

#Region "Private Methods"

    Sub Refesh()
        TxtMadonvitinh.Text = ""
        txtDVT_VN.Text = ""
        txtDVT_EN.Text = ""
        txtDVT_CHINA.Text = ""
    End Sub
    Sub ShowDonViTinh(ByVal RowIndex As Integer)
        If (GrdDanhsachloaivattu.Rows(RowIndex).Cells("DVT").Value).Equals(String.Empty) Then
            TxtMadonvitinh.Text = ""
        Else
            TxtMadonvitinh.Text = GrdDanhsachloaivattu.Rows(RowIndex).Cells("DVT").Value
            DVT_TMP = GrdDanhsachloaivattu.Rows(RowIndex).Cells("DVT").Value
        End If
        If Not IsDBNull(GrdDanhsachloaivattu.Rows(RowIndex).Cells("TEN_1").Value) Then
            txtDVT_VN.Text = GrdDanhsachloaivattu.Rows(RowIndex).Cells("TEN_1").Value
        Else
            txtDVT_VN.Text = ""
        End If
        If Not IsDBNull(GrdDanhsachloaivattu.Rows(RowIndex).Cells("TEN_2").Value) Then
            txtDVT_EN.Text = GrdDanhsachloaivattu.Rows(RowIndex).Cells("TEN_2").Value
        Else
            txtDVT_EN.Text = ""
        End If
        If Not IsDBNull(GrdDanhsachloaivattu.Rows(RowIndex).Cells("GHI_CHU").Value) Then
            txtDVT_CHINA.Text = GrdDanhsachloaivattu.Rows(RowIndex).Cells("GHI_CHU").Value
        Else
            txtDVT_CHINA.Text = ""
        End If

    End Sub
    Sub BindData()
        Me.GrdDanhsachloaivattu.DataSource = New DON_VI_TINHController().GetDON_VI_TINHs
        GrdDanhsachloaivattu.Columns("TEN_3").Visible = False
        Try
            Me.GrdDanhsachloaivattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhsachloaivattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
        If GrdDanhsachloaivattu.RowCount > 0 Then
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        Else
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        End If
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If

    End Sub
    Function isValidated()
        If Not TxtMadonvitinh.IsValidated Then
            TxtMadonvitinh.Focus()
            Return False
        End If
        If Not txtDVT_VN.IsValidated Then
            txtDVT_VN.Focus()
            Return False
        End If
        Return True
    End Function
    Function AddDonViTinh() As Boolean
        Dim objDonViTinhController As New DON_VI_TINHController()
        Dim objDonvitinhInfo As New DON_VI_TINHInfo


        objDonvitinhInfo.DVT_TMP = DVT_TMP
        objDonvitinhInfo.DVT = commons.Modules.ObjSystems.SplitString(TxtMadonvitinh.Text.Trim)
        objDonvitinhInfo.TEN_1 = txtDVT_VN.Text.Trim
        objDonvitinhInfo.TEN_2 = txtDVT_EN.Text.Trim
        objDonvitinhInfo.GHI_CHU = txtDVT_CHINA.Text.Trim

        Dim obj As SqlDataReader
        If Not blnThem Then
            obj = objDonViTinhController.CheckExistTEN_DON_VI_TINH(DVT_TMP, txtDVT_VN.Text.Trim)
            If obj.Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTrungTen", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtDVT_VN.Focus()
                txtDVT_VN.SelectAll()
                obj.Close()
                Return False
            End If
            obj.Close()
            objDonViTinhController.InsertDON_VI_TINH(objDonvitinhInfo.DVT, Me.Name, Commons.Modules.UserName, 2)
            objDonViTinhController.UpdateDON_VI_TINH(objDonvitinhInfo)
        Else
            obj = objDonViTinhController.CheckTEN_DON_VI_TINH(txtDVT_VN.Text.Trim)
            If obj.Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTrungTen", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtDVT_VN.Focus()
                txtDVT_VN.SelectAll()
                obj.Close()
                Return False
            End If
            obj.Close()
            objDonViTinhController.AddDON_VI_TINH(objDonvitinhInfo)
            objDonViTinhController.InsertDON_VI_TINH(objDonvitinhInfo.DVT, Me.Name, Commons.Modules.UserName, 1)
            
            blnThem = False
        End If
        Refesh()
        Return True
    End Function
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
        GrdDanhsachloaivattu.Enabled = blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        TxtMadonvitinh.ReadOnly = blnLock
        txtDVT_VN.ReadOnly = blnLock
        txtDVT_EN.ReadOnly = blnLock
        txtDVT_CHINA.ReadOnly = blnLock
    End Sub
    Sub SetFocus()
        'me.GrdDanhsachdonvitinh.Rows()
    End Sub
#End Region

    Private Sub TxtMadonvitinh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles TxtMadonvitinh.Validating
        If Not TxtMadonvitinh.IsValidated Then
            TxtMadonvitinh.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDVT_VN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtDVT_VN.Validating
        If Not txtDVT_VN.IsValidated Then
            txtDVT_VN.Focus()
            e.Cancel = True
        End If
    End Sub

   
End Class