Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.Common

Imports Commons.VS.Classes.Admin
Public Class frmLoaivattu
    Dim bThem As Boolean = False
    Dim intRow As Integer = 0

    Private Sub frmLoaivattu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VisibleButton(True)
        EnableControl(True)
        BindData()
        Commons.Modules.ObjSystems.DinhDang()

        Commons.Modules.ObjSystems.ThayDoiNN(Me)

    End Sub
    Sub BindData()
        Try
            GrdDanhsachloaivattu.Columns.Clear()
        Catch ex As Exception
        End Try
        GrdDanhsachloaivattu.DataSource = New clsLOAI_VAT_TUController().GetLOAI_VTs()
        Try
            GrdDanhsachloaivattu.Columns("MS_LOAI_VT").Visible = False
            GrdDanhsachloaivattu.Columns("VAT_TU").Width = 60
            'Me.GrdDanhsachloaivattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            'Me.GrdDanhsachloaivattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        RefeshLanguage()
    End Sub
    Sub VisibleButton(ByVal chon As Boolean)
        BtnThem.Visible = chon
        BtnSua.Visible = chon
        BtnXoa.Visible = chon
        BtnThoat.Visible = chon
        BtnGhi.Visible = Not chon
        BtnKhongghi.Visible = Not chon
    End Sub
    Sub EnableControl(ByVal chon As Boolean)
        txtDVT_VN.ReadOnly = chon
        txtDVT_EN.ReadOnly = chon
        txtDVT_CHINA.ReadOnly = chon
        chkVatTu.Enabled = Not chon
        GrdDanhsachloaivattu.Enabled = chon
    End Sub
    Sub ClearData()
        txtMaLoaiVT.Text = ""
        txtDVT_CHINA.Text = ""
        txtDVT_EN.Text = ""
        txtDVT_VN.Text = ""
    End Sub
    Sub ShowData()
        txtMaLoaiVT.Text = GrdDanhsachloaivattu.Rows(intRow).Cells("MS_LOAI_VT").Value
        txtDVT_VN.Text = GrdDanhsachloaivattu.Rows(intRow).Cells("TEN_LOAI_VT_TV").Value.ToString
        txtDVT_EN.Text = GrdDanhsachloaivattu.Rows(intRow).Cells("TEN_LOAI_VT_TA").Value.ToString
        txtDVT_CHINA.Text = GrdDanhsachloaivattu.Rows(intRow).Cells("TEN_LOAI_VT_TH").Value.ToString
        chkVatTu.Checked = GrdDanhsachloaivattu.Rows(intRow).Cells("VAT_TU").Value
    End Sub
    Private Sub RefeshLanguage()
        Me.GrdDanhsachloaivattu.Columns("TEN_LOAI_VT_TV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_VT_TV", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaivattu.Columns("TEN_LOAI_VT_TA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_VT_TA", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaivattu.Columns("TEN_LOAI_VT_TH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_VT_TH", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaivattu.Columns("VAT_TU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "VAT_TU", commons.Modules.TypeLanguage)
    End Sub
    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        EnableControl(False)
        ClearData()
        bThem = True
    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        EnableControl(False)
        bThem = False
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim tmp As String
        Dim objLoaiVTController As New clsLOAI_VAT_TUController()
        If objLoaiVTController.CheckTenLoaiVT_TV(txtMaLoaiVT.Text, txtDVT_VN.Text.Trim) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTrungTenLoaiVT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtDVT_VN.SelectAll()
            txtDVT_VN.Focus()
            Exit Sub
        End If
        Dim objLoaiVTInfo As New clsLOAI_VAT_TUInfo
        objLoaiVTInfo.TEN_LOAI_VT_TV = txtDVT_VN.Text.Trim
        objLoaiVTInfo.TEN_LOAI_VT_TA = txtDVT_EN.Text.Trim
        objLoaiVTInfo.TEN_LOAI_VT_TH = txtDVT_CHINA.Text.Trim
        objLoaiVTInfo.VAT_TU = chkVatTu.CheckState

        If bThem Then
            tmp = objLoaiVTController.AddLoaiVT(objLoaiVTInfo)
        Else
            tmp = txtMaLoaiVT.Text
            objLoaiVTInfo.MS_LOAI_VT = tmp
            objLoaiVTController.UpdateLoaiVT(objLoaiVTInfo)
        End If
        VisibleButton(True)
        EnableControl(True)
        BindData()
        For i As Integer = 0 To GrdDanhsachloaivattu.Rows.Count - 1
            If GrdDanhsachloaivattu.Rows(i).Cells("MS_LOAI_VT").Value = tmp Then
                GrdDanhsachloaivattu.CurrentCell() = GrdDanhsachloaivattu.Rows(i).Cells("TEN_LOAI_VT_TV")
                GrdDanhsachloaivattu.Focus()
                Exit For
            End If
        Next
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        VisibleButton(True)
        EnableControl(True)
        BindData()
        Try
            GrdDanhsachloaivattu.CurrentCell() = GrdDanhsachloaivattu.Rows(0).Cells("TEN_LOAI_VT_TV")
            GrdDanhsachloaivattu.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub GrdDanhsachloaivattu_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachloaivattu.RowEnter
        intRow = e.RowIndex
        ShowData()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If GrdDanhsachloaivattu.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            Dim str As String
            str = "SELECT MS_LOAI_VT FROM IC_PHU_TUNG WHERE MS_LOAI_VT='" & txtMaLoaiVT.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDuocSDTrongPhuTung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
            Dim objLoaiVTCtroller As New clsLOAI_VAT_TUController()
            objLoaiVTCtroller.DeleteLoaiVT(txtMaLoaiVT.Text)
            Dim tmp As Integer = intRow
            BindData()
            If GrdDanhsachloaivattu.Rows.Count > 0 Then
                If GrdDanhsachloaivattu.Rows.Count = tmp Then
                    GrdDanhsachloaivattu.CurrentCell() = GrdDanhsachloaivattu.Rows(tmp - 1).Cells("TEN_LOAI_VT_TV")
                    GrdDanhsachloaivattu.Focus()
                Else
                    GrdDanhsachloaivattu.CurrentCell() = GrdDanhsachloaivattu.Rows(tmp).Cells("TEN_LOAI_VT_TV")
                    GrdDanhsachloaivattu.Focus()
                End If
            End If
        End If
    End Sub
End Class