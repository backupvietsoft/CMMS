
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmTrinhdo

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private Trinh_do_tmp As String

#Region "Control Event"

    Private Sub FrmBacTho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        Try
            grdDanhmuctrinhdo.Rows(0).Cells(1).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.lblTrinhdo.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTrinhdo.Name, commons.Modules.TypeLanguage)
        Me.lblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTieude.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.grpDanhmuctrinhdo.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpDanhmuctrinhdo.Name, commons.Modules.TypeLanguage)
        Me.grpNhaptrinhdo.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpNhaptrinhdo.Name, commons.Modules.TypeLanguage)
        Me.grdDanhmuctrinhdo.Columns("TEN_GOI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_GOI", commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        VisibleButton(False)
        LockData(False)
        blnThem = True
        txtTrinhdo.Focus()
        txtTrinhdo.Text = ""
        grdDanhmuctrinhdo.Enabled = False
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtTrinhdo.Focus()
        grdDanhmuctrinhdo.Enabled = False
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grdDanhmuctrinhdo.RowCount <= 0 Then
            MsgBox("Không có dữ liệu để xóa !", MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        'Dim Traloi As String = MsgBox("Bạn có muốn xóa bậc thợ này không ? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            ' Kiểm tra xem TRINH_DO_VAN_HOA này có đang tồn tại trong bảng CONG_NHAN không.

            Dim SQL_TMP As String = "SELECT * FROM CONG_NHAN WHERE MS_TRINH_DO = '" & txtMaso.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                'MsgBox("TRINH_DO_VAN_HOA này đang được sử dụng trong CONG_NHAN! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While

            ' Xóa TRINH_DO_VAN_HOA

            Dim objTrinhdoController As New clsTRINH_DO_VAN_HOAController()
            objTrinhdoController.DeleteTRINH_DO_VAN_HOA(txtMaso.Text)
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If grdDanhmuctrinhdo.Rows.Count > 0 Then
                If grdDanhmuctrinhdo.Rows.Count = tmp Then
                    grdDanhmuctrinhdo.CurrentCell() = grdDanhmuctrinhdo.Rows(tmp - 1).Cells(1)
                    grdDanhmuctrinhdo.Focus()
                Else
                    grdDanhmuctrinhdo.CurrentCell() = grdDanhmuctrinhdo.Rows(tmp).Cells(1)
                    grdDanhmuctrinhdo.Focus()
                End If
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim tmp As String = Trim(txtTrinhdo.Text)

        Dim SQL_TMP As String = "SELECT * FROM TRINH_DO_VAN_HOA WHERE TEN_GOI = '" & txtTrinhdo.Text.Replace("'", "''") & "'"
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            If blnThem Then
                ' Tên trình độ này đã tồn tại ! Vui lòng nhập tên khác !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtTrinhdo.Focus()
                dtReader.Close()
                Exit Sub
            Else
                If txtTrinhdo.Text <> Trinh_do_tmp Then
                    ' Tên trình độ này đã tồn tại ! Vui lòng nhập tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTrinhdo.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            End If
        End While

        If isValidated() And Trim(txtTrinhdo.Text) <> "" Then
            AddTrinhdo()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < grdDanhmuctrinhdo.RowCount
                If grdDanhmuctrinhdo.Rows(i).Cells("TEN_GOI").Value.ToString = tmp Then
                    grdDanhmuctrinhdo.Rows(i).Cells("TEN_GOI").Selected = True
                    'grdDanhmuctrinhdo.Rows(i).Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        Else
            'XtraMessageBox.Show("Tên bậc thợ không được rỗng ! Vui lòng nhập vào tên bậc thợ.")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            txtTrinhdo.Focus()
            Exit Sub
        End If
        grdDanhmuctrinhdo.Enabled = True
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grdDanhmuctrinhdo.RowCount <> 0 Then
                ShowTrinhdo(grdDanhmuctrinhdo.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowTrinhdo(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
        grdDanhmuctrinhdo.Enabled = True
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        'If frmQuanlynhanvien.IsActivated Then
        '    frmQuanlynhanvien.LoadcboTRINH_DO()
        'End If
        commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhmuctrinhdo.RowHeaderMouseClick
        ShowTrinhdo(e.RowIndex)
    End Sub

    'Private Sub grddanhsachdonvido_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachdonvido.CellClick
    'ShowDonViDo(e.RowIndex)
    'End Sub
    Dim intRow As Integer
    Private Sub GrdDanhmucbactho_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhmuctrinhdo.RowEnter
        ShowTrinhdo(e.RowIndex)
        intRow = e.RowIndex
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        'TxtMadonvido.Text = ""
        txtTrinhdo.Text = ""
    End Sub
    Sub ShowTrinhdo(ByVal RowIndex As Integer)
        txtMaso.Text = grdDanhmuctrinhdo.Rows(RowIndex).Cells("MS_TRINH_DO").Value.ToString
        txtTrinhdo.Text = grdDanhmuctrinhdo.Rows(RowIndex).Cells("TEN_GOI").Value.ToString
    End Sub
    Sub BindData()
        Me.grdDanhmuctrinhdo.DataSource = New clsTRINH_DO_VAN_HOAController().GetTRINH_DO_VAN_HOAs
        grdDanhmuctrinhdo.Columns(0).Visible = False
        grdDanhmuctrinhdo.Columns(1).Width = 380
        If grdDanhmuctrinhdo.RowCount > 0 Then
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        Else
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        End If
        'If Commons.Modules.PermisString.Equals("Read only") Then
        '    EnableButton(False)
        'End If
    End Sub
    Function isValidated()
        If Not txtTrinhdo.IsValidated Then
            Return False
        End If
        Return True
    End Function

    Sub AddTrinhdo()
        Dim objTrinhdoInfo As New Commons.TRINH_DO_VAN_HOAInfo
        Dim objTrinhdoController As New clsTRINH_DO_VAN_HOAController()
        objTrinhdoInfo.TEN_GOI = Trim(txtTrinhdo.Text)
        If Not blnThem Then
            objTrinhdoInfo.MS_TRINH_DO = txtMaso.Text
            objTrinhdoController.UpdateTRINH_DO_VAN_HOA(objTrinhdoInfo)
        Else
            objTrinhdoInfo.MS_TRINH_DO = objTrinhdoController.AddTRINH_DO_VAN_HOA(objTrinhdoInfo)
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
        txtTrinhdo.ReadOnly = blnLock
    End Sub
#End Region

End Class