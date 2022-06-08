
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin


Public Class frmDonvitinhRuntime

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private Ten_tmp As String


#Region "Control Event"

    Private Sub frmDonvitinhRuntime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            BindData()
            RefeshLanguage()
            VisibleButton(True)
            LockData(True)
            Try
                GrdDanhsachdonviRT.Rows(0).Cells(1).Selected = True
            Catch ex As Exception
            End Try
            EnableButton(False)
        Else
            EnableButton(True)
            BindData()
            RefeshLanguage()
            VisibleButton(True)
            LockData(True)
            Try
                GrdDanhsachdonviRT.Rows(0).Cells(1).Selected = True
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

    Private Sub RefeshLanguage()
        Me.lblTenDVRT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTenDVRT.Name, Commons.Modules.TypeLanguage)
        Me.lblTieudedonviRT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTieudedonviRT.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnGhi.Name, Commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, Commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnSua.Name, Commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThem.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnXoa.Name, Commons.Modules.TypeLanguage)
        Me.GrpDanhsachdonviRT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GrpDanhsachdonviRT.Name, Commons.Modules.TypeLanguage)
        Me.GrpNhapdonviRT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GrpNhapdonviRT.Name, Commons.Modules.TypeLanguage)
        Me.GrdDanhsachdonviRT.Columns("TEN_DVT_RT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DVT_RT", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        txtTendonviRT.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        Ten_tmp = txtTendonviRT.Text
        txtTendonviRT.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If GrdDanhsachdonviRT.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa!", MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị đo này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY không.

            SQL_TMP = "SELECT * FROM MAY WHERE MS_DVT_RT = '" & txtMadonviRT.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

                Exit Sub
            End While

            '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY_LOAI_BTPN_CHU_KY không.

            SQL_TMP = "SELECT * FROM MAY_LOAI_BTPN_CHU_KY WHERE MS_DVT_RT = '" & txtMadonviRT.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

                Exit Sub
            End While

            '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng CAU_TRUC_THIET_BI không.

            SQL_TMP = "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_DVT_RT = '" & txtMadonviRT.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa5", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

                Exit Sub
            End While

            ' Xóa đơn vị đo

            Dim objDonViTinhRTController As New DON_VI_TINH_RUN_TIMEController()
            objDonViTinhRTController.InsertDON_VI_TINH_RUN_TIME_LOG(CInt(txtMadonviRT.Text), Me.Name, Commons.Modules.UserName, 3)
            objDonViTinhRTController.DeleteDON_VI_TINH_RUN_TIME(txtMadonviRT.Text)
            ' Xử lý load lại dữ liệu cho combobox đơn vị đo trong Form Thông số thiết bị.
            'frmThongsothietbi.Load_cboDonvido()
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If GrdDanhsachdonviRT.Rows.Count > 0 Then
                If GrdDanhsachdonviRT.Rows.Count = tmp Then
                    GrdDanhsachdonviRT.CurrentCell() = GrdDanhsachdonviRT.Rows(tmp - 1).Cells("TEN_DVT_RT")
                    GrdDanhsachdonviRT.Focus()
                Else
                    GrdDanhsachdonviRT.CurrentCell() = GrdDanhsachdonviRT.Rows(tmp).Cells("TEN_DVT_RT")
                    GrdDanhsachdonviRT.Focus()
                End If
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If blnThem Then
            If New DON_VI_TINH_RUN_TIMEController().CheckExistTEN_DVT_RT(txtTendonviRT.Text.Trim) And Not BtnKhongghi.Focused Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtTendonviRT.Focus()
                txtTendonviRT.SelectAll()
                Exit Sub
            End If
        Else
            If txtTendonviRT.Text.Trim <> Ten_tmp And New DON_VI_TINH_RUN_TIMEController().CheckExistTEN_DVT_RT(txtTendonviRT.Text.Trim) And Not BtnKhongghi.Focused Then
                ' Đơn vị thời gian này đã tồn tại, vui lòng nhập tên khác !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtTendonviRT.Focus()
                txtTendonviRT.SelectAll()
                Exit Sub
            End If
        End If
        If isValidated() Then
            Dim i As Integer = 0
            Dim TEMP As String = txtTendonviRT.Text.Trim
            AddDonViTinhRT()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < Me.GrdDanhsachdonviRT.RowCount
                If Me.GrdDanhsachdonviRT.Rows(i).Cells("TEN_DVT_RT").Value = TEMP Then
                    Me.GrdDanhsachdonviRT.Rows(i).Cells("TEN_DVT_RT").Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        Refesh()
        Try
            If GrdDanhsachdonviRT.RowCount <> 0 Then
                ShowDonViTinhRT(GrdDanhsachdonviRT.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowDonViTinhRT(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub
    Dim intRow As Integer
    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhsachdonviRT.RowHeaderMouseClick
        ShowDonViTinhRT(e.RowIndex)
        intRow = e.RowIndex
    End Sub

    Private Sub grddanhsachdonvido_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachdonviRT.RowEnter
        ShowDonViTinhRT(e.RowIndex)
        intRow = e.RowIndex
    End Sub
#End Region

#Region "Private Methods"

    Sub Refesh()
        txtTendonviRT.Text = ""
    End Sub
    Sub ShowDonViTinhRT(ByVal RowIndex As Integer)
        txtMadonviRT.Text = GrdDanhsachdonviRT.Rows(RowIndex).Cells("MS_DVT_RT").Value
        txtTendonviRT.Text = GrdDanhsachdonviRT.Rows(RowIndex).Cells("TEN_DVT_RT").Value
    End Sub
    Sub BindData()
        Try
            Me.GrdDanhsachdonviRT.DataSource = New DON_VI_TINH_RUN_TIMEController().GetDON_VI_TINH_RUN_TIMEs
            GrdDanhsachdonviRT.Columns(0).Visible = False
            GrdDanhsachdonviRT.Columns(1).Width = 380
            Try
                Me.GrdDanhsachdonviRT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.GrdDanhsachdonviRT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try
            If GrdDanhsachdonviRT.RowCount > 0 Then
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
    Function isValidated()
        If Not txtTendonviRT.IsValidated Then
            txtTendonviRT.Focus()
            Return False
        End If
        Return True
    End Function

    Sub AddDonViTinhRT()
        Dim objDonviTinhRTInfo As New DON_VI_TINH_RUN_TIMEInfo
        Dim objDonViTinhRTController As New DON_VI_TINH_RUN_TIMEController()
        objDonviTinhRTInfo.TEN_DVT_RT = txtTendonviRT.Text.Trim
        If Not blnThem Then
            objDonviTinhRTInfo.MS_DVT_RT = txtMadonviRT.Text
            objDonViTinhRTController.InsertDON_VI_TINH_RUN_TIME_LOG(CInt(txtMadonviRT.Text), Me.Name, Commons.Modules.UserName, 2)
            objDonViTinhRTController.UpdateDON_VI_TINH_RUN_TIME(objDonviTinhRTInfo)
        Else
            objDonviTinhRTInfo.MS_DVT_RT = New DON_VI_TINH_RUN_TIMEController().AddDON_VI_TINH_RUN_TIME(objDonviTinhRTInfo)
            objDonViTinhRTController.InsertDON_VI_TINH_RUN_TIME_LOG(CInt(objDonviTinhRTInfo.MS_DVT_RT), Me.Name, Commons.Modules.UserName, 1)
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
        txtTendonviRT.ReadOnly = blnLock
        Me.GrdDanhsachdonviRT.Enabled = blnLock
    End Sub
#End Region

End Class