
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmTinhTrangBoPhan
    Private blnThem As Boolean
    Private Ma_TMP As String = ""
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader

    Sub LockData(ByVal flg As Boolean)
        txt_Viet.ReadOnly = flg
        txt_EN.ReadOnly = flg
        txt_CH.ReadOnly = flg
    End Sub

    Sub VisibleButton(ByVal flg As Boolean)
        BtnThem.Visible = flg
        BtnSua.Visible = flg
        BtnThoat.Visible = flg
        BtnXoa.Visible = flg
        BtnGhi.Visible = Not flg
        BtnKhongghi.Visible = Not flg
    End Sub
    Private Sub frmTinhTrangBoPhan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        If Me.dgrDanhsach.RowCount > 0 Then
            Me.dgrDanhsach.Rows(0).Selected = True
        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

    Sub BindData()
        Me.dgrDanhsach.DataSource = New clsTINH_TRANG_BO_PHANController().GetTING_TRANGs
        Me.dgrDanhsach.Columns("MS_TINH_TRANG").Visible = False
        If Me.dgrDanhsach.RowCount > 0 Then
            Me.BtnSua.Enabled = True
            Me.BtnThem.Enabled = True
        Else
            Me.BtnSua.Enabled = False
            Me.BtnThem.Enabled = False
        End If
        refresh_language_grid()
        Try
            Me.dgrDanhsach.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.dgrDanhsach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RefeshLanguage()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        'Me.lblViet.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblViet.Name, commons.Modules.TypeLanguage)
        'Me.lblEN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblEN.Name, commons.Modules.TypeLanguage)
        'Me.lblCH.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblCH.Name, commons.Modules.TypeLanguage)
        'Me.lblMa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblMa.Name, commons.Modules.TypeLanguage)
        'Me.LblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieude.Name, commons.Modules.TypeLanguage)
        'Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        'Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        'Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        'Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        'Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        'Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        'Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        'Me.grpDanhSach.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpDanhSach.Name, commons.Modules.TypeLanguage)
        'Me.grpNhap.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpNhap.Name, commons.Modules.TypeLanguage)
    End Sub

    Sub refresh_language_grid()
        Me.dgrDanhsach.Columns("TEN_TIENG_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "lblViet", commons.Modules.TypeLanguage)
        Me.dgrDanhsach.Columns("TEN_TIENG_ANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "lblEN", commons.Modules.TypeLanguage)
        Me.dgrDanhsach.Columns("TEN_TIENG_HOA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "lblCH", commons.Modules.TypeLanguage)
    End Sub

    Sub Refesh()
        TxtMa.Text = ""
        txt_Viet.Text = ""
        txt_EN.Text = ""
        txt_CH.Text = ""
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
    End Sub
    Sub ShowTINH_TRANG(ByVal RowIndex As Integer)
        If (dgrDanhsach.Rows(RowIndex).Cells("MS_TINH_TRANG").Value).Equals(String.Empty) Then
            TxtMa.Text = ""
        Else
            TxtMa.Text = dgrDanhsach.Rows(RowIndex).Cells("MS_TINH_TRANG").Value
            Ma_TMP = dgrDanhsach.Rows(RowIndex).Cells("MS_TINH_TRANG").Value
        End If
        If Not IsDBNull(dgrDanhsach.Rows(RowIndex).Cells("TEN_TIENG_VIET").Value) Then
            txt_Viet.Text = dgrDanhsach.Rows(RowIndex).Cells("TEN_TIENG_VIET").Value
        Else
            txt_Viet.Text = ""
        End If
        If Not IsDBNull(dgrDanhsach.Rows(RowIndex).Cells("TEN_TIENG_ANH").Value) Then
            txt_EN.Text = dgrDanhsach.Rows(RowIndex).Cells("TEN_TIENG_ANH").Value
        Else
            txt_EN.Text = ""
        End If
        If Not IsDBNull(dgrDanhsach.Rows(RowIndex).Cells("TEN_TIENG_HOA").Value) Then
            txt_CH.Text = dgrDanhsach.Rows(RowIndex).Cells("TEN_TIENG_HOA").Value
        Else
            txt_CH.Text = ""
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If dgrDanhsach.RowCount <> 0 Then
                ShowTINH_TRANG(dgrDanhsach.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowTINH_TRANG(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim TMP As String = TxtMa.Text

        If isValidated() Then
            AddTinhTrang()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < dgrDanhsach.RowCount
                If dgrDanhsach.Rows(i).Cells(0).Value.ToString = TMP Then
                    dgrDanhsach.Rows(i).Cells(0).Selected = True
                    dgrDanhsach.Rows(i).Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        End If
    End Sub
    Function isValidated()
        If Not txt_Viet.IsValidated Then
            Return False
        End If
        Return True
    End Function
    Sub AddTinhTrang()
        Dim objTINH_TRANG As New clsTINH_TRANG_BO_PHANController()
        Dim objTINH_TRANGInfo As New clsTINH_TRANG_BO_PHANInfo
        objTINH_TRANGInfo.MA_TMP = Ma_TMP
        objTINH_TRANGInfo.MA = TxtMa.Text.Trim
        objTINH_TRANGInfo.TEN_1 = txt_Viet.Text.Trim
        objTINH_TRANGInfo.TEN_2 = txt_EN.Text.Trim
        objTINH_TRANGInfo.TEN_3 = txt_CH.Text.Trim
        If Not blnThem Then
            objTINH_TRANGInfo.MA = TxtMa.Text.Trim()
            objTINH_TRANG.UpdateTINH_TRANG(objTINH_TRANGInfo)
        Else
            objTINH_TRANG.AddTINH_TRANG(objTINH_TRANGInfo)
            blnThem = False
        End If
        Refesh()
    End Sub
    Dim intRow As Integer
    Private Sub dgrDanhsach_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhsach.RowEnter
        ShowTINH_TRANG(e.RowIndex)
        intRow = e.RowIndex
    End Sub

    Private Sub dgrDanhsach_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgrDanhsach.RowHeaderMouseClick
        ShowTINH_TRANG(e.RowIndex)
    End Sub
    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click

        VisibleButton(False)
        Ma_TMP = TxtMa.Text
        LockData(False)
    End Sub
    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If dgrDanhsach.RowCount = 0 Then Exit Sub
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")

        Dim sql_str As String = "select * from KE_HOACH_TONG_THE where LY_DO_SC = '" & Me.TxtMa.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql_str)
        While dtReader.Read
            ' Tình trạng này đang được sử dụng trong EOR tình trạng bộ phận, bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa01", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim objTINH_TRANGController As New clsTINH_TRANG_BO_PHANController()
            objTINH_TRANGController.DeleteTINH_TRANG(TxtMa.Text)
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If dgrDanhsach.Rows.Count > 0 Then
                If dgrDanhsach.Rows.Count = tmp Then
                    dgrDanhsach.CurrentCell() = dgrDanhsach.Rows(tmp - 1).Cells("TEN_TIENG_VIET")
                    dgrDanhsach.Focus()
                Else
                    dgrDanhsach.CurrentCell() = dgrDanhsach.Rows(tmp).Cells("TEN_TIENG_VIET")
                    dgrDanhsach.Focus()
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub
End Class