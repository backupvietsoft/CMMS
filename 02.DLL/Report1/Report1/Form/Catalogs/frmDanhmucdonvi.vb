
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin

Public Class frmDanhmucdonvi

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private MS_DV_tmp As String
    Private Ten_DV_tmp As String
    Private FLAG As Boolean = True

    Private regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("[^\w\.\,!""$%^&*\(\)-_+=::@']")
    Private regexReplace As String = " "


#Region "Control Event"

    Private Sub frmDanhmucdonvi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, Me.Name)
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
        If Commons.Modules.iMaPBT = 1 Then Me.lblTRutGon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        'Me.lblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTieude.Name, Commons.Modules.TypeLanguage)
        Me.lblMaso.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblMaso.Name, Commons.Modules.TypeLanguage)
        Me.lblTendonvi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTendonvi.Name, Commons.Modules.TypeLanguage)
        Me.lblDiachi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblDiachi.Name, Commons.Modules.TypeLanguage)
        Me.lblDienthoai.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblDienthoai.Name, Commons.Modules.TypeLanguage)
        Me.lblFax.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblFax.Name, Commons.Modules.TypeLanguage)
        Me.lblTenngan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTenngan.Name, Commons.Modules.TypeLanguage)
        Me.lblTRutGon.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTRutGon.Name, Commons.Modules.TypeLanguage)
        Me.chkMacdinh.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, chkMacdinh.Name, Commons.Modules.TypeLanguage)
        Me.chkThuengoai.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, chkThuengoai.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnGhi.Name, Commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, Commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnSua.Name, Commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThem.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnXoa.Name, Commons.Modules.TypeLanguage)
        Me.grpDanhsachdonvi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpDanhsachdonvi.Name, Commons.Modules.TypeLanguage)
        Me.grpNhapdanhmucDV.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpNhapdanhmucDV.Name, Commons.Modules.TypeLanguage)
        Me.grdDanhsachdonvi.Columns("MS_DON_VI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DON_VI", Commons.Modules.TypeLanguage)
        Me.grdDanhsachdonvi.Columns("TEN_DON_VI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DON_VI", Commons.Modules.TypeLanguage)
        Me.grdDanhsachdonvi.Columns("DIA_CHI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DIA_CHI", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        LockData(False)
        blnThem = True
        txtMS_DON_VI.Focus()
        grdDanhsachdonvi.Enabled = False
        chkMacdinh.Checked = False
        chkThuengoai.Checked = False
        AddHandler txtMS_DON_VI.Validated, AddressOf Me.txtMS_DON_VI_Validated
        AddHandler txtTEN_DON_VI.Validated, AddressOf Me.txtTEN_DON_VI_Validated
        AddHandler txtTEN_NGAN.Validated, AddressOf Me.txtTEN_NGAN_Validated
        AddHandler txtTRutGon.Validated, AddressOf Me.txtTRutGon_Validated

        Refesh()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        MS_DV_tmp = txtMS_DON_VI.Text
        Ten_DV_tmp = txtTEN_DON_VI.Text
        VisibleButton(False)
        LockData(False)
        grdDanhsachdonvi.Enabled = False
        txtTEN_DON_VI.Focus()
        txtMS_DON_VI.ReadOnly = True
        AddHandler txtMS_DON_VI.Validated, AddressOf Me.txtMS_DON_VI_Validated
        AddHandler txtTEN_DON_VI.Validated, AddressOf Me.txtTEN_DON_VI_Validated
        AddHandler txtTEN_NGAN.Validated, AddressOf Me.txtTEN_NGAN_Validated
        AddHandler txtTRutGon.Validated, AddressOf Me.txtTRutGon_Validated

    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If grdDanhsachdonvi.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa!", MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa chức vụ này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")

        '  Kiểm tra DON_VI này có đang được sử dụng trong bảng CONG_NHAN không.

        SQL_TMP = "SELECT * FROM TO_PHONG_BAN WHERE MS_DON_VI = '" & txtMS_DON_VI.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            'MsgBox("DON_VI này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL_TMP = "SELECT * FROM BO_PHAN_CHIU_PHI WHERE MSDV = '" & txtMS_DON_VI.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            ' Đơn vị này đang được sử dụng trong bộ phận chịu phí ! Bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        ' Xóa DON_VI
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            Dim tmp As Integer = introw
            Dim objDON_VIController As New clsDON_VIController()
            objDON_VIController.DeleteDON_VI(txtMS_DON_VI.Text)
            Refesh()
            BindData()
            If grdDanhsachdonvi.Rows.Count > 0 Then
                If grdDanhsachdonvi.Rows.Count = tmp Then
                    grdDanhsachdonvi.CurrentCell() = grdDanhsachdonvi.Rows(tmp - 1).Cells("TEN_DON_VI")
                    grdDanhsachdonvi.Focus()
                Else
                    grdDanhsachdonvi.CurrentCell() = grdDanhsachdonvi.Rows(tmp).Cells("TEN_DON_VI")
                    grdDanhsachdonvi.Focus()
                End If
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        txtMS_DON_VI.Text = Commons.Modules.ObjSystems.SplitString(txtMS_DON_VI.Text)
        txtTEN_DON_VI.Text = txtTEN_DON_VI.Text

        If Commons.Modules.iMaPBT = 1 Then txtTRutGon.Text = txtTRutGon.Text

        Dim tmp As String = Trim(txtMS_DON_VI.Text)

        If Trim(txtTEN_DON_VI.Text) = "" Then
            ' Tên đơn vị không được rỗng ! Vui lòng nhập tên đơn vị !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), _
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtTEN_DON_VI.Focus()
            'txtTEN_DON_VI.SelectAll()
            Exit Sub
        End If

        If Trim(txtTEN_NGAN.Text) = "" Then
            ' Tên viết tắt của đơn vị không được rỗng ! Vui lòng nhập tên viết tắt !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi21", Commons.Modules.TypeLanguage), _
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtTEN_NGAN.Focus()
            Exit Sub
        End If
        If Trim(txtTRutGon.Text) = "" And Commons.Modules.iMaPBT = 1 Then
            ' Tên viết tắt của đơn vị không được rỗng ! Vui lòng nhập tên viết tắt !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgTenRutGonKhongDuocDeTrong", _
                Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtTRutGon.Focus()
            Exit Sub
        End If

        AddChucvu()

        ' Xử lý load lại dữ liệu cho combobox đơn vị đo trong Form Thông số thiết bị.
        BindData()
        blnThem = False
        VisibleButton(True)
        LockData(True)
        While i < grdDanhsachdonvi.RowCount
            If grdDanhsachdonvi.Rows(i).Cells("MS_DON_VI").Value.ToString = tmp Then
                grdDanhsachdonvi.Rows(i).Cells("TEN_DON_VI").Selected = True
                Exit While
            Else
                i = i + 1
            End If
        End While
        grdDanhsachdonvi.Enabled = True
        RemoveHandler txtMS_DON_VI.Validated, AddressOf Me.txtMS_DON_VI_Validated
        RemoveHandler txtTEN_DON_VI.Validated, AddressOf Me.txtTEN_DON_VI_Validated
        RemoveHandler txtTEN_NGAN.Validated, AddressOf Me.txtTEN_NGAN_Validated
        RemoveHandler txtTRutGon.Validated, AddressOf Me.txtTRutGon_Validated





    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grdDanhsachdonvi.RowCount <> 0 Then
                ShowDON_VI(grdDanhsachdonvi.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowDON_VI(0)
        End Try
        blnThem = False
        VisibleButton(True)
        LockData(True)
        grdDanhsachdonvi.Enabled = True
        RemoveHandler txtMS_DON_VI.Validated, AddressOf Me.txtMS_DON_VI_Validated
        RemoveHandler txtTEN_DON_VI.Validated, AddressOf Me.txtTEN_DON_VI_Validated
        RemoveHandler txtTEN_NGAN.Validated, AddressOf Me.txtTEN_NGAN_Validated
        RemoveHandler txtTRutGon.Validated, AddressOf Me.txtTRutGon_Validated
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachdonvi.RowHeaderMouseClick
        ShowDON_VI(e.RowIndex)
    End Sub
    Dim introw As Integer
    Private Sub grddanhsachdonvido_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachdonvi.RowEnter
        ShowDON_VI(e.RowIndex)
        introw = e.RowIndex
    End Sub

    Private Sub txtMS_DON_VI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtMS_DON_VI.Validated
        If BtnKhongghi.Focused Then Exit Sub
        If Trim(txtMS_DON_VI.Text) = "" Then
            ' Mã số đơn vị không được rỗng ! Vui lòng nhập vào mã số !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), _
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtMS_DON_VI.Text = ""
            txtMS_DON_VI.Focus()
        Else
            Dim SQL_TMP As String = "SELECT * FROM DON_VI WHERE MS_DON_VI = '" & txtMS_DON_VI.Text.Replace("'", "''") & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                If blnThem Then
                    ' Mã số đơn vị này đã tồn tại, Vui lòng nhập mã số khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtMS_DON_VI.Focus()
                    txtMS_DON_VI.SelectAll()
                    dtReader.Close()
                    Exit While
                ElseIf Trim(txtMS_DON_VI.Text) <> MS_DV_tmp Then
                    ' Mã số đơn vị này đã tồn tại, Vui lòng nhập mã số khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtMS_DON_VI.Focus()
                    txtMS_DON_VI.SelectAll()
                    dtReader.Close()
                    Exit While
                Else
                    Exit While
                End If
            End While
            dtReader.Close()
        End If
    End Sub

    Private Sub txtTEN_DON_VI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtTEN_DON_VI.Validated
        If BtnKhongghi.Focused Then Exit Sub
        If Trim(txtTEN_DON_VI.Text) = "" Then
            ' Tên đơn vị không được rỗng ! Vui lòng nhập tên đơn vị !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), _
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            'txtTEN_DON_VI.Text = ""
            txtTEN_DON_VI.Focus()
            Exit Sub
        Else
            Dim tmp As String = txtTEN_DON_VI.Text
            txtTEN_DON_VI.Text = tmp
            Dim SQL_TMP As String = "SELECT * FROM DON_VI WHERE TEN_DON_VI = '" & tmp.Replace("'", "''") & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)

            While dtReader.Read
                If blnThem Then
                    ' Tên đơn vị này đã tồn tại, Vui lòng nhập Tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi345", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTEN_DON_VI.Focus()
                    txtTEN_DON_VI.SelectAll()
                    dtReader.Close()
                    Exit While
                ElseIf Trim(txtTEN_DON_VI.Text).ToUpper <> Ten_DV_tmp.ToUpper Then
                    ' Tên đơn vị này đã tồn tại, Vui lòng nhập Tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi345", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTEN_DON_VI.Focus()
                    txtTEN_DON_VI.SelectAll()
                    dtReader.Close()
                    Exit While
                Else
                    Exit While
                End If
            End While
            dtReader.Close()
        End If
    End Sub

    Private Sub txtTEN_NGAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtTEN_NGAN.Validated
        If BtnKhongghi.Focused Then
            Exit Sub
        End If
        If Trim(txtTEN_NGAN.Text) = "" Then
            ' Tên viết tắt của đơn vị không được rỗng ! Vui lòng nhập tên viết tắt !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi21", Commons.Modules.TypeLanguage), _
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtTEN_NGAN.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtTRutGon_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtTEN_NGAN.Validated
        If BtnKhongghi.Focused Then
            Exit Sub
        End If
        Dim sTmp As String = txtTRutGon.Text


        Dim r As New System.Text.RegularExpressions.Regex("(?:[^a-z0-9 ]|(?<=['""])s)", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.CultureInvariant Or System.Text.RegularExpressions.RegexOptions.Compiled)
        sTmp = r.Replace(sTmp, [String].Empty)
        Dim MyStringBuilder As New System.Text.StringBuilder(sTmp)
        MyStringBuilder.Replace(" ", "")
        sTmp = MyStringBuilder.ToString


        If sTmp <> txtTRutGon.Text Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgTenRutGonKhongDuocCoKhoangHayKyTuDacBiet", _
                Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtTRutGon.Text = sTmp
            txtTRutGon.Focus()
            Exit Sub
        End If
    End Sub

#End Region

#Region "Private Methods"
    Sub Refesh()
        txtDIA_CHI.Text = ""
        txtDIEN_THOAI.Text = ""
        txtFAX.Text = ""
        txtMS_DON_VI.Text = ""
        txtTEN_DON_VI.Text = ""
        txtTEN_NGAN.Text = ""
        txtTRutGon.Text = ""
    End Sub
    Sub ShowDON_VI(ByVal RowIndex As Integer)
        txtMS_DON_VI.Text = grdDanhsachdonvi.Rows(RowIndex).Cells("MS_DON_VI").Value.ToString
        txtTRutGon.Text = grdDanhsachdonvi.Rows(RowIndex).Cells("TEN_RUT_GON").Value.ToString
        txtTEN_DON_VI.Text = grdDanhsachdonvi.Rows(RowIndex).Cells("TEN_DON_VI").Value.ToString
        txtTEN_NGAN.Text = grdDanhsachdonvi.Rows(RowIndex).Cells("TEN_NGAN").Value.ToString
        txtDIA_CHI.Text = grdDanhsachdonvi.Rows(RowIndex).Cells("DIA_CHI").Value.ToString
        txtDIEN_THOAI.Text = grdDanhsachdonvi.Rows(RowIndex).Cells("DIEN_THOAI").Value.ToString
        txtFAX.Text = grdDanhsachdonvi.Rows(RowIndex).Cells("FAX").Value.ToString
        chkMacdinh.Checked = grdDanhsachdonvi.Rows(RowIndex).Cells("MAC_DINH").Value
        chkThuengoai.Checked = grdDanhsachdonvi.Rows(RowIndex).Cells("THUE_NGOAI").Value
    End Sub

    Sub BindData()

        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_USER", Commons.Modules.UserName))

        Me.grdDanhsachdonvi.DataSource = dt
        Try
            Me.grdDanhsachdonvi.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachdonvi.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
        grdDanhsachdonvi.Columns("MS_DON_VI").Visible = False
        grdDanhsachdonvi.Columns("DIA_CHI").Visible = False
        grdDanhsachdonvi.Columns("TEN_NGAN").Visible = False
        grdDanhsachdonvi.Columns("THUE_NGOAI").Visible = False
        grdDanhsachdonvi.Columns("MAC_DINH").Visible = False
        grdDanhsachdonvi.Columns("DIEN_THOAI").Visible = False
        grdDanhsachdonvi.Columns("TEN_RUT_GON").Visible = False
        grdDanhsachdonvi.Columns("FAX").Visible = False
        grdDanhsachdonvi.Columns("TEN_DON_VI_ANH").Visible = False
        grdDanhsachdonvi.Columns("TEN_DON_VI_HOA").Visible = False
        grdDanhsachdonvi.Columns("TEN_DON_VI").Width = 250
        If grdDanhsachdonvi.RowCount = 0 Then
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        Else
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        End If
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If
    End Sub
    Function isValidated()
        If Not txtDIA_CHI.IsValidated Then
            Return False
        End If
        If Not txtDIEN_THOAI.IsValidated Then
            Return False
        End If
        If Not txtFAX.IsValidated Then
            Return False
        End If
        If Not txtMS_DON_VI.IsValidated Then
            Return False
        End If
        If Not txtTEN_DON_VI.IsValidated Then
            Return False
        End If
        If Not txtTEN_NGAN.IsValidated Then
            Return False
        End If

        If Not txtTRutGon.IsValidated Then
            Return False
        End If
        Return True
    End Function

    Sub AddChucvu()
        Dim objDON_VIInfo As New Commons.DON_VIInfo
        Dim objDON_VIController As New clsDON_VIController()
        objDON_VIInfo.MS_DON_VI = Trim(txtMS_DON_VI.Text)
        objDON_VIInfo.TEN_DON_VI = Trim(txtTEN_DON_VI.Text)
        objDON_VIInfo.TEN_NGAN = Trim(txtTEN_NGAN.Text)
        objDON_VIInfo.DIA_CHI = Trim(txtDIA_CHI.Text)
        objDON_VIInfo.THUE_NGOAI = chkThuengoai.Checked
        objDON_VIInfo.MAC_DINH = chkMacdinh.Checked
        objDON_VIInfo.DIEN_THOAI = Trim(txtDIEN_THOAI.Text)
        objDON_VIInfo.FAX = Trim(txtFAX.Text)
        objDON_VIInfo.TEN_RUT_GON = Trim(txtTRutGon.Text)
        If Not blnThem Then
            objDON_VIInfo.MS_DON_VI_tmp = MS_DV_tmp
            objDON_VIController.UpdateDON_VI(objDON_VIInfo)
        Else
            objDON_VIController.AddDON_VI(objDON_VIInfo)
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
        chkMacdinh.Enabled = Not blnLock
        chkThuengoai.Enabled = Not blnLock
        txtDIA_CHI.ReadOnly = blnLock
        txtFAX.ReadOnly = blnLock
        txtDIEN_THOAI.ReadOnly = blnLock
        txtMS_DON_VI.ReadOnly = blnLock
        txtTRutGon.ReadOnly = blnLock
        txtTEN_DON_VI.ReadOnly = blnLock
        txtTEN_NGAN.ReadOnly = blnLock
    End Sub
#End Region

    Private Sub txtDIEN_THOAI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDIEN_THOAI.KeyDown
        If (e.KeyValue >= 47 And e.KeyValue <= 56) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Or e.KeyValue = 109 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TableLayoutPanel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub
End Class