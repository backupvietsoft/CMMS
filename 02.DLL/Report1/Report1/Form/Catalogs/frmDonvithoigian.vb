
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmDonvithoigian

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader

#Region "Control Event"

    Private Sub frmDonvithoigian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitForm()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        Try
            GrdDanhsachdonviTG.Rows(0).Cells(1).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.lblTenDVTG.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTenDVTG.Name, commons.Modules.TypeLanguage)
        Me.lblTieudedonviTG.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTieudedonviTG.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.GrpDanhsachdonviTG.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpDanhsachdonviTG.Name, commons.Modules.TypeLanguage)
        Me.GrpNhapdonviTG.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpNhapdonviTG.Name, commons.Modules.TypeLanguage)
        Me.GrdDanhsachdonviTG.Columns("TEN_DV_TG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_DV_TG", commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        txtTendonviTG.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtTendonviTG.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If GrdDanhsachdonviTG.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa!", MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị đo này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY_LOAI_BTPN_CHU_KY không.

            SQL_TMP = "SELECT * FROM MAY_LOAI_BTPN_CHU_KY WHERE MS_DV_TG = '" & txtMadonviTG.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

                Exit Sub
            End While

            '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng MAY_THONG_SO_GSTT không.

            SQL_TMP = "SELECT * FROM MAY_THONG_SO_GSTT WHERE MS_DV_TG = '" & txtMadonviTG.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

                Exit Sub
            End While
            SQL_TMP = "SELECT * FROM CAU_TRUC_THIET_BI_TS_GSTT WHERE MS_DV_TG = '" & txtMadonviTG.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                'MsgBox("Đơn vị đo này đang được sử dụng trong Thông số giám sát tình trạng! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While
            ' Xóa đơn vị đo

            Dim objDonViTGController As New DON_VI_THOI_GIANController()
            objDonViTGController.DeleteDON_VI_THOI_GIAN(txtMadonviTG.Text)

            ' Xử lý load lại dữ liệu cho combobox đơn vị đo trong Form Thông số thiết bị.
            'frmThongsothietbi.Load_cboDonvido()

            Refesh()
            BindData()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() And txtTendonviTG.Text <> "" Then
            AddDonViTG()

            ' Xử lý load lại dữ liệu cho combobox đơn vị đo trong Form Thông số thiết bị.
            'frmThongsoGSTT.Load_cboDonvido()

            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Thông báo")
            txtTendonviTG.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If GrdDanhsachdonviTG.RowCount <> 0 Then
                ShowDonViTG(GrdDanhsachdonviTG.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowDonViTG(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhsachdonviTG.RowHeaderMouseClick
        ShowDonViTG(e.RowIndex)
    End Sub

    Private Sub grddanhsachdonvido_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhsachdonviTG.RowEnter
        ShowDonViTG(e.RowIndex)
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
        Me.GrdDanhsachdonviTG.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1


        Commons.Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Commons.Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Commons.Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdDanhsachdonviTG.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

    End Sub
    Sub Refesh()
        txtTendonviTG.Text = ""
    End Sub
    Sub ShowDonViTG(ByVal RowIndex As Integer)
        txtMadonviTG.Text = GrdDanhsachdonviTG.Rows(RowIndex).Cells("MS_DV_TG").Value
        txtTendonviTG.Text = GrdDanhsachdonviTG.Rows(RowIndex).Cells("TEN_DV_TG").Value
    End Sub
    Sub BindData()
        Me.GrdDanhsachdonviTG.DataSource = New DON_VI_THOI_GIANController().GetDON_VI_THOI_GIANs
        GrdDanhsachdonviTG.Columns(0).Visible = False
        GrdDanhsachdonviTG.Columns(1).Width = 380
        If Me.GrdDanhsachdonviTG.RowCount > 0 Then
            Me.BtnSua.Enabled = True
            Me.BtnXoa.Enabled = True
        Else
            Me.BtnSua.Enabled = False
            Me.BtnXoa.Enabled = False
        End If

    End Sub
    Function isValidated()
        If Not txtTendonviTG.IsValidated Then
            Return False
        End If
        Return True
    End Function

    Sub AddDonViTG()
        Dim objDonviTGInfo As New DON_VI_THOI_GIANInfo
        objDonviTGInfo.TEN_DV_TG = txtTendonviTG.Text
        If Not blnThem Then
            Dim objDonViTGController As New DON_VI_THOI_GIANController()
            objDonviTGInfo.MS_DV_TG = txtMadonviTG.Text
            objDonViTGController.UpdateDON_VI_THOI_GIAN(objDonviTGInfo)
        Else
            objDonviTGInfo.MS_DV_TG = New DON_VI_THOI_GIANController().AddDON_VI_THOI_GIAN(objDonviTGInfo)

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
        txtTendonviTG.ReadOnly = blnLock
    End Sub
#End Region

End Class