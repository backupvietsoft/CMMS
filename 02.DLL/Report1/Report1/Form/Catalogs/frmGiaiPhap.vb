
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmGiaiPhap
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
    Private Sub frmGiaiPhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitForm()
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
    Sub InitForm()



        Commons.Modules.DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Commons.Modules.DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Commons.Modules.DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrDanhsach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle1


        Commons.Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Commons.Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Commons.Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgrDanhsach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
    End Sub
    Sub BindData()
        Me.dgrDanhsach.DataSource = New clsGIAI_PHAPController().GetGIAI_PHAPs
        If Me.dgrDanhsach.RowCount > 0 Then
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        Else
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        End If
    End Sub
    Private Sub RefeshLanguage()

        Me.lblViet.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblViet.Name, commons.Modules.TypeLanguage)
        Me.lblEN.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblEN.Name, commons.Modules.TypeLanguage)
        Me.lblCH.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblCH.Name, commons.Modules.TypeLanguage)
        Me.lblMa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblMa.Name, commons.Modules.TypeLanguage)
        Me.LblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieude.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.grpDanhSach.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpDanhSach.Name, commons.Modules.TypeLanguage)
        Me.grpNhap.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpNhap.Name, commons.Modules.TypeLanguage)
        Me.dgrDanhsach.Columns("TEN_TIENG_VIET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_TIENG_VIET", commons.Modules.TypeLanguage)
        Me.dgrDanhsach.Columns("TEN_TIENG_ANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_TIENG_ANH", commons.Modules.TypeLanguage)
        Me.dgrDanhsach.Columns("TEN_TIENG_HOA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_TIENG_HOA", commons.Modules.TypeLanguage)
        Me.dgrDanhsach.Columns("MS_GIAI_PHAP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_GIAI_PHAP", commons.Modules.TypeLanguage)
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
    Sub ShowGIAI_PHAP(ByVal RowIndex As Integer)
        If (dgrDanhsach.Rows(RowIndex).Cells("MS_GIAI_PHAP").Value).Equals(String.Empty) Then
            TxtMa.Text = ""
        Else
            TxtMa.Text = dgrDanhsach.Rows(RowIndex).Cells("MS_GIAI_PHAP").Value
            Ma_TMP = dgrDanhsach.Rows(RowIndex).Cells("MS_GIAI_PHAP").Value
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
                ShowGIAI_PHAP(dgrDanhsach.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowGIAI_PHAP(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim TMP As String = TxtMa.Text

        If isValidated() Then
            AddGIAI_PHAP()
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
    Sub AddGIAI_PHAP()
        Dim objGIAI_PHAP As New clsGIAI_PHAPController()
        Dim objGIAI_PHAPInfo As New clsGIAI_PHAPInfo
        objGIAI_PHAPInfo.MA_TMP = Ma_TMP
        objGIAI_PHAPInfo.MA = TxtMa.Text.Trim
        objGIAI_PHAPInfo.TEN_1 = txt_Viet.Text.Trim
        objGIAI_PHAPInfo.TEN_2 = txt_EN.Text.Trim
        objGIAI_PHAPInfo.TEN_3 = txt_CH.Text.Trim
        If Not blnThem Then
            objGIAI_PHAPInfo.MA = TxtMa.Text.Trim()

            objGIAI_PHAP.UpdateGIAI_PHAP(objGIAI_PHAPInfo)
        Else
            objGIAI_PHAP.AddPRIORITY(objGIAI_PHAPInfo)
            blnThem = False
        End If
        Refesh()
    End Sub
    Dim intRow As Integer
    Private Sub dgrDanhsach_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDanhsach.RowEnter
        ShowGIAI_PHAP(e.RowIndex)
        intRow = e.RowIndex
    End Sub

    Private Sub dgrDanhsach_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgrDanhsach.RowHeaderMouseClick
        ShowGIAI_PHAP(e.RowIndex)
    End Sub
    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click

        VisibleButton(False)
        Ma_TMP = TxtMa.Text
        LockData(False)
    End Sub
    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If dgrDanhsach.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim objGIAI_PHAPController As New clsGIAI_PHAPController()
            objGIAI_PHAPController.DeleteGIAI_PHAP(TxtMa.Text)
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If dgrDanhsach.Rows.Count > 0 Then
                If dgrDanhsach.Rows.Count = tmp Then
                    dgrDanhsach.CurrentCell() = dgrDanhsach.Rows(tmp - 1).Cells(0)
                    dgrDanhsach.Focus()
                Else
                    dgrDanhsach.CurrentCell() = dgrDanhsach.Rows(tmp).Cells(0)
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