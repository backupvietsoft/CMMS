
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmNguyenNhanHuHong
    Private blnThem As Boolean
    Dim ten As String
    Private Ma_TMP As String = ""
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader
    Sub LockData(ByVal flg As Boolean)
        txtNN_Viet.ReadOnly = flg
        txtNN_EN.ReadOnly = flg
        txtNN_CH.ReadOnly = flg
    End Sub
    Sub VisibleButton(ByVal flg As Boolean)
        BtnThem.Visible = flg
        BtnSua.Visible = flg
        BtnThoat.Visible = flg
        BtnXoa.Visible = flg
        BtnGhi.Visible = Not flg
        BtnKhongghi.Visible = Not flg
    End Sub

    Private Sub frmNguyenNhanHuHong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitForm()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        If Me.dgrDanhsachNguyenNhan.RowCount > 0 Then
            Me.dgrDanhsachNguyenNhan.Rows(0).Selected = True
        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Sub BindData()
        Me.dgrDanhsachNguyenNhan.DataSource = New clsNGUYEN_NHAN_HU_HONGController().GetNGUYEN_NHAN_HU_HONGs
    End Sub
    Sub InitForm()



        Commons.Modules.DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Commons.Modules.DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Commons.Modules.DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrDanhsachNguyenNhan.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle1


        Commons.Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Commons.Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Commons.Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgrDanhsachNguyenNhan.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
    End Sub
    Private Sub RefeshLanguage()

        Me.lblNN_Viet.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblNN_Viet.Name, commons.Modules.TypeLanguage)
        Me.lblNN_EN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblNN_EN.Name, commons.Modules.TypeLanguage)
        Me.lblNN_CH.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblNN_CH.Name, commons.Modules.TypeLanguage)
        Me.lblMaNguyenNhan.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblMaNguyenNhan.Name, commons.Modules.TypeLanguage)
        Me.LblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieude.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.grpDanhSachNN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpDanhSachNN.Name, commons.Modules.TypeLanguage)
        Me.grpNhapNguyenNhan.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpNhapNguyenNhan.Name, commons.Modules.TypeLanguage)
        Me.dgrDanhsachNguyenNhan.Columns("TEN_NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN", commons.Modules.TypeLanguage)
        Me.dgrDanhsachNguyenNhan.Columns("TEN_NGUYEN_NHAN_ANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN_ANH", commons.Modules.TypeLanguage)
        Me.dgrDanhsachNguyenNhan.Columns("TEN_NGUYEN_NHAN_HOA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN_HOA", commons.Modules.TypeLanguage)
        Me.dgrDanhsachNguyenNhan.Columns("STT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "STT", commons.Modules.TypeLanguage)
    End Sub

    Sub Refesh()
        TxtMa.Text = ""
        txtNN_Viet.Text = ""
        txtNN_EN.Text = ""
        txtNN_CH.Text = ""
    End Sub
    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click

        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
    End Sub
    Sub ShowNGUYEN_NHAN(ByVal RowIndex As Integer)
        If (dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("STT").Value).Equals(String.Empty) Then
            TxtMa.Text = ""
        Else
            TxtMa.Text = dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("STT").Value
            Ma_TMP = dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("STT").Value
        End If
        If Not IsDBNull(dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("TEN_NGUYEN_NHAN").Value) Then
            txtNN_Viet.Text = dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("TEN_NGUYEN_NHAN").Value
        Else
            txtNN_Viet.Text = ""
        End If
        If Not IsDBNull(dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("TEN_NGUYEN_NHAN_ANH").Value) Then
            txtNN_EN.Text = dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("TEN_NGUYEN_NHAN_ANH").Value
        Else
            txtNN_EN.Text = ""
        End If
        If Not IsDBNull(dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("TEN_NGUYEN_NHAN_HOA").Value) Then
            txtNN_CH.Text = dgrDanhsachNguyenNhan.Rows(RowIndex).Cells("TEN_NGUYEN_NHAN_HOA").Value
        Else
            txtNN_CH.Text = ""
        End If
    End Sub
    Private Sub BtnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If dgrDanhsachNguyenNhan.RowCount <> 0 Then
                ShowNGUYEN_NHAN(dgrDanhsachNguyenNhan.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowNGUYEN_NHAN(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim TMP As String = TxtMa.Text
        If txtNN_Viet.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            txtNN_Viet.Focus()
            Exit Sub
        End If
        If isValidated() Then
            AddNGUYEN_NHAN()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < dgrDanhsachNguyenNhan.RowCount
                If dgrDanhsachNguyenNhan.Rows(i).Cells(0).Value.ToString = TMP Then
                    dgrDanhsachNguyenNhan.Rows(i).Cells(0).Selected = True
                    dgrDanhsachNguyenNhan.Rows(i).Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        End If
    End Sub
    Sub AddNGUYEN_NHAN()
        Dim objNGUYEN_NHANController As New clsNGUYEN_NHAN_HU_HONGController()
        Dim objNGUYEN_NHANInfo As New clsNGUYEN_NHAN_HU_HONGInfo
        objNGUYEN_NHANInfo.MA_TMP = Ma_TMP
        objNGUYEN_NHANInfo.MA = TxtMa.Text.Trim
        objNGUYEN_NHANInfo.TEN_1 = txtNN_Viet.Text.Trim
        objNGUYEN_NHANInfo.TEN_2 = txtNN_EN.Text.Trim
        objNGUYEN_NHANInfo.TEN_3 = txtNN_CH.Text.Trim
        If Not blnThem Then
            objNGUYEN_NHANInfo.MA = TxtMa.Text.Trim()
            objNGUYEN_NHANController.UpdateNGUYEN_NHAN_HU_HONG(objNGUYEN_NHANInfo)
        Else
            objNGUYEN_NHANController.AddNGUYEN_NHAN_HU_HONG(objNGUYEN_NHANInfo)
            blnThem = False
        End If
        Refesh()
    End Sub
    Function isValidated()
        If Not txtNN_Viet.IsValidated Then
            Return False
        End If
        Return True
    End Function

    Private Sub dgrDanhsachNguyenNhan_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhsachNguyenNhan.RowEnter
        ShowNGUYEN_NHAN(e.RowIndex)
    End Sub

    Private Sub dgrDanhsachNguyenNhan_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgrDanhsachNguyenNhan.RowHeaderMouseClick
        ShowNGUYEN_NHAN(e.RowIndex)
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        Ma_TMP = TxtMa.Text
        ten = txtNN_Viet.Text

        LockData(False)
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If dgrDanhsachNguyenNhan.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim objNGUYEN_NHANController As New clsNGUYEN_NHAN_HU_HONGController()
            objNGUYEN_NHANController.DeleteNGUYEN_NHAN_HU_HONG(TxtMa.Text)
            Refesh()
            BindData()
            Try
                dgrDanhsachNguyenNhan.Rows(0).Selected = True
            Catch ex As Exception

            End Try

        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub
End Class