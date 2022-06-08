
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin

Public Class frmLoaichiphi

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0

    Private intRow As Integer
#Region "Control Event"

    Private Sub frmLoaichiphi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        Try
            GrdDanhsachloaichiphi.Rows(0).Cells(1).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.LblTenloaichiphi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblTenloaichiphi.Name, commons.Modules.TypeLanguage)
        Me.LblGhichu.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblGhichu.Name, commons.Modules.TypeLanguage)
        Me.LblTieudeloaichiphi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudeloaichiphi.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.GrpDanhsachloaichiphi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpDanhsachloaichiphi.Name, commons.Modules.TypeLanguage)
        Me.GrpNhaploaichiphi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpNhaploaichiphi.Name, commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaichiphi.Columns("TEN_LOAI_CHI_PHI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_LOAI_CHI_PHI", commons.Modules.TypeLanguage)
        Me.GrdDanhsachloaichiphi.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GHI_CHU", commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        TxtTenloaichiphi.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        TxtTenloaichiphi.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If GrdDanhsachloaichiphi.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            '  Kiểm tra loại chịu phí có đang được sử dụng trong bảng BO_PHAN_CHIU_PHI không.

            Dim SQL_TMP As String = "SELECT * FROM BO_PHAN_CHIU_PHI WHERE LOAI_CHI_PHI = '" & TxtMaso.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While

            ' Xóa loại chịu phí

            Dim objLoaiChiPhiController As New LOAI_CHI_PHIController()
            objLoaiChiPhiController.DeleteLOAI_CHI_PHI(TxtMaso.Text)
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If GrdDanhsachloaichiphi.Rows.Count > 0 Then
                If GrdDanhsachloaichiphi.Rows.Count = tmp Then
                    GrdDanhsachloaichiphi.CurrentCell() = GrdDanhsachloaichiphi.Rows(tmp - 1).Cells("TEN_LOAI_CHI_PHI")
                    GrdDanhsachloaichiphi.Focus()
                Else
                    GrdDanhsachloaichiphi.CurrentCell() = GrdDanhsachloaichiphi.Rows(tmp - 1).Cells("TEN_LOAI_CHI_PHI")
                    GrdDanhsachloaichiphi.Focus()
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            If AddDonViDo() Then
                Dim ms As Integer = TxtMaso.Text
                BindData()
                For i As Integer = 0 To GrdDanhsachloaichiphi.Rows.Count - 1
                    If GrdDanhsachloaichiphi.Rows(i).Cells("LOAI_CHI_PHI").Value = ms Then
                        GrdDanhsachloaichiphi.CurrentCell() = GrdDanhsachloaichiphi.Rows(i).Cells("TEN_LOAI_CHI_PHI")
                        GrdDanhsachloaichiphi.Focus()
                        Exit For
                    End If
                Next
                blnThem = False
                VisibleButton(True)
                LockData(True)
            End If
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        Refesh()
        Try
            If GrdDanhsachloaichiphi.RowCount <> 0 Then
                ShowLoaiChiPhi(GrdDanhsachloaichiphi.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowLoaiChiPhi(0)
        End Try
        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub GrdDanhsachloaichiphi_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhsachloaichiphi.RowHeaderMouseClick
        ShowLoaiChiPhi(e.RowIndex)
        intRow = e.RowIndex
    End Sub

    Private Sub GrdDanhsachloaichiphi_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachloaichiphi.RowEnter
        ShowLoaiChiPhi(e.RowIndex)
        intRow = e.RowIndex
    End Sub
#End Region

#Region "Private Methods"

    Sub Refesh()
        TxtTenloaichiphi.Text = ""
        txtGhichu.Text = ""
    End Sub
    Sub ShowLoaiChiPhi(ByVal RowIndex As Integer)
        TxtMaso.Text = GrdDanhsachloaichiphi.Rows(RowIndex).Cells("LOAI_CHI_PHI").Value
        TxtTenloaichiphi.Text = GrdDanhsachloaichiphi.Rows(RowIndex).Cells("TEN_LOAI_CHI_PHI").Value
        txtGhichu.Text = GrdDanhsachloaichiphi.Rows(RowIndex).Cells("GHI_CHU").Value
    End Sub
    Sub BindData()
        Me.GrdDanhsachloaichiphi.DataSource = New LOAI_CHI_PHIController().GetLOAI_CHI_PHIs
        GrdDanhsachloaichiphi.Columns(0).Visible = False
        GrdDanhsachloaichiphi.Columns(1).Width = 120
        GrdDanhsachloaichiphi.Columns(2).Width = 260
        Try
            Me.GrdDanhsachloaichiphi.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhsachloaichiphi.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
        If GrdDanhsachloaichiphi.RowCount < 1 Then
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        Else
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        End If
    End Sub
    Function isValidated()
        If Not TxtTenloaichiphi.IsValidated Then
            TxtTenloaichiphi.Focus()
            Return False
        End If
        Return True
    End Function
    Function AddDonViDo() As Boolean
        Dim objLoaiChiPhiInfo As New LOAI_CHI_PHIInfo
        objLoaiChiPhiInfo.TEN_LOAI_CHI_PHI = Trim(TxtTenloaichiphi.Text)
        objLoaiChiPhiInfo.GHI_CHU = Trim(txtGhichu.Text)
        Dim objLoaiCongViecController As New LOAI_CHI_PHIController()
        If Not blnThem Then
            If objLoaiCongViecController.CheckExistLOAI_CHI_PHI(TxtMaso.Text, TxtTenloaichiphi.Text).Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSameName", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Name)
                Me.TxtTenloaichiphi.Focus()
                Return False
            End If

            objLoaiChiPhiInfo.LOAI_CHI_PHI = TxtMaso.Text
            objLoaiCongViecController.UpdateLOAI_CHI_PHI(objLoaiChiPhiInfo)
        Else

            If objLoaiCongViecController.CheckTEN_LOAI_CHI_PHI(TxtTenloaichiphi.Text).Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSameName", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Name)
                Me.TxtTenloaichiphi.Focus()
                Return False
            End If
            TxtMaso.Text = New LOAI_CHI_PHIController().AddLOAI_CHI_PHI(objLoaiChiPhiInfo)
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
        GrdDanhsachloaichiphi.Enabled = blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        TxtTenloaichiphi.ReadOnly = blnLock
        txtGhichu.ReadOnly = blnLock
    End Sub
#End Region
End Class