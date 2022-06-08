Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.Common

Imports Commons.VS.Classes.Admin

Public Class frmBoPhanGSTT

#Region "Private Member"
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private intMS_BP_GSTT As String = ""
    Private Ten_BP_GSTT As String

    Private dtReader As SqlDataReader

#End Region

#Region "Control Event"

    Private Sub FrmBoPhanGSTT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, Me.Name)
        'If Commons.Modules.PermisString = "" Then
        '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, frmMain.Name, "MsgNoAccess1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '    Me.Close()
        'Else
        '    If Commons.Modules.PermisString.Equals("No access") Then
        '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, frmMain.Name, "MsgNoAccess", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        '        Me.Close()
        '    Else
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        If Me.GrdDanhmucBoPhanGSTT.RowCount > 0 Then
            Me.GrdDanhmucBoPhanGSTT.Rows(0).Selected = True
        End If
        'If Commons.Modules.PermisString.Equals("Read only") Then
        '    EnableButton(False)
        'End If
        '    End If
        'End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.lblTEN_BP_GSTT_TV.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTEN_BP_GSTT_TV.Name, commons.Modules.TypeLanguage)
        Me.lblTEN_BP_GSTT_TA.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTEN_BP_GSTT_TA.Name, commons.Modules.TypeLanguage)
        'Me.lblTEN_BP_GSTT_TH.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTEN_BP_GSTT_TH.Name, commons.Modules.TypeLanguage)
        Me.LblTieudeBoPhanGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudeBoPhanGSTT.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.GrpDanhsachBoPhanGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpDanhsachBoPhanGSTT.Name, commons.Modules.TypeLanguage)
        Me.GrpNhapBoPhanGSTT.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpNhapBoPhanGSTT.Name, commons.Modules.TypeLanguage)
        Me.GrdDanhmucBoPhanGSTT.Columns("TEN_BP_GSTT_TV").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BP_GSTT_TV", commons.Modules.TypeLanguage)
        Me.GrdDanhmucBoPhanGSTT.Columns("TEN_BP_GSTT_TA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BP_GSTT_TA", commons.Modules.TypeLanguage)
        Me.GrdDanhmucBoPhanGSTT.Columns("TEN_BP_GSTT_TH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BP_GSTT_TH", commons.Modules.TypeLanguage)

    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        txtTEN_BP_GSTT_TV.Focus()
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        intMS_BP_GSTT = TxtMS_BP_GSTT.Text
        Ten_BP_GSTT = txtTEN_BP_GSTT_TV.Text
        txtTEN_BP_GSTT_TV.Focus()
        LockData(False)
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If GrdDanhmucBoPhanGSTT.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa đơn vị này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            ' Kiểm tra đơn vị tính này có tồn tại trong bảng THONG_SO_GSTT không.
            commons.Modules.SQLString = "SELECT * FROM THONG_SO_GSTT WHERE MS_BP_GSTT = " & TxtMS_BP_GSTT.Text
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While
            dtReader.Close()
            ' Xóa đơn vị tính
            Dim objBO_PHAN_GSTTController As New BO_PHAN_GSTTController()
            objBO_PHAN_GSTTController.DeleteBO_PHAN_GSTT(TxtMS_BP_GSTT.Text)
            Refesh()
            BindData()
            If GrdDanhmucBoPhanGSTT.RowCount > 0 Then
                GrdDanhmucBoPhanGSTT.Rows(0).Selected = True
            End If
        Else
            Exit Sub
        End If
    End Sub
    Public ckThayDoi As Boolean = False
    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            Dim i As Integer = 0
            Dim TMP As String = txtTEN_BP_GSTT_TV.Text
            AddBO_PHAN_GSTT()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < GrdDanhmucBoPhanGSTT.RowCount
                If GrdDanhmucBoPhanGSTT.Rows(i).Cells(1).Value.ToString = TMP Then
                    GrdDanhmucBoPhanGSTT.Rows(i).Cells(1).Selected = True
                    'GrdDanhmucBoPhanGSTT.Rows(i).Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        End If
        ckThayDoi = True
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        Try
            If GrdDanhmucBoPhanGSTT.RowCount <> 0 Then
                ShowBO_PHAN_GSTT(GrdDanhmucBoPhanGSTT.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowBO_PHAN_GSTT(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub GrdBO_PHAN_GSTT_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhmucBoPhanGSTT.RowHeaderMouseClick
        ShowBO_PHAN_GSTT(e.RowIndex)
    End Sub

    Private Sub GrdBO_PHAN_GSTT_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhmucBoPhanGSTT.RowEnter
        ShowBO_PHAN_GSTT(e.RowIndex)
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        txtTEN_BP_GSTT_TV.Text = ""
        txtTEN_BP_GSTT_TA.Text = ""
        'txtTEN_BP_GSTT_TH.Text = ""
    End Sub
    Sub ShowBO_PHAN_GSTT(ByVal RowIndex As Integer)
        If Not IsDBNull(GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("MS_BP_GSTT").Value) Then
            TxtMS_BP_GSTT.Text = GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("MS_BP_GSTT").Value
        Else
            TxtMS_BP_GSTT.Text = ""
        End If
        If Not IsDBNull(GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("TEN_BP_GSTT_TV").Value) Then
            txtTEN_BP_GSTT_TV.Text = GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("TEN_BP_GSTT_TV").Value
        Else
            txtTEN_BP_GSTT_TV.Text = ""
        End If
        If Not IsDBNull(GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("TEN_BP_GSTT_TA").Value) Then
            txtTEN_BP_GSTT_TA.Text = GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("TEN_BP_GSTT_TA").Value
        Else
            txtTEN_BP_GSTT_TA.Text = ""
        End If
        If Not IsDBNull(GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("TEN_BP_GSTT_TH").Value) Then
            'txtTEN_BP_GSTT_TH.Text = GrdDanhmucBoPhanGSTT.Rows(RowIndex).Cells("TEN_BP_GSTT_TH").Value
        Else
            'txtTEN_BP_GSTT_TH.Text = ""
        End If
    End Sub
    Sub BindData()
        Me.GrdDanhmucBoPhanGSTT.DataSource = New BO_PHAN_GSTTController().GetBO_PHAN_GSTTs
        GrdDanhmucBoPhanGSTT.Columns("MS_BP_GSTT").Visible = False
        GrdDanhmucBoPhanGSTT.Columns("TEN_BP_GSTT_TH").Visible = False
        Try
            Me.GrdDanhmucBoPhanGSTT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhmucBoPhanGSTT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
        If GrdDanhmucBoPhanGSTT.RowCount > 0 Then
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
        If Not txtTEN_BP_GSTT_TV.IsValidated Then
            txtTEN_BP_GSTT_TV.Focus()
            Return False
        End If
        Return True
    End Function
    Sub AddBO_PHAN_GSTT()
        Dim objBO_PHAN_GSTTController As New BO_PHAN_GSTTController()
        Dim objBO_PHAN_GSTTInfo As New BO_PHAN_GSTTInfo

        objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TV = txtTEN_BP_GSTT_TV.Text.Trim
        objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TA = txtTEN_BP_GSTT_TA.Text.Trim
        objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TH = "" ' txtTEN_BP_GSTT_TH.Text.Trim
        If Not blnThem Then
            objBO_PHAN_GSTTInfo.MS_BP_GSTT = TxtMS_BP_GSTT.Text.Trim
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_BO_PHAN_GSTT_LOG", objBO_PHAN_GSTTInfo.MS_BP_GSTT, Me.Name, Commons.Modules.UserName, 2)
            objBO_PHAN_GSTTController.UpdateBO_PHAN_GSTT(objBO_PHAN_GSTTInfo)
        Else
            Dim ms_BP_GSTT As Integer = objBO_PHAN_GSTTController.AddBO_PHAN_GSTT(objBO_PHAN_GSTTInfo)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_BO_PHAN_GSTT_LOG", ms_BP_GSTT, Me.Name, Commons.Modules.UserName, 1)
            blnThem = False
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
        GrdDanhmucBoPhanGSTT.Enabled = blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtTEN_BP_GSTT_TV.ReadOnly = blnLock
        txtTEN_BP_GSTT_TA.ReadOnly = blnLock
        'txtTEN_BP_GSTT_TH.ReadOnly = blnLock
    End Sub
    Sub SetFocus()
        'me.GrdDanhsachdonvitinh.Rows()
    End Sub
#End Region

    Private Sub txtTEN_BP_GSTT_TV_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTEN_BP_GSTT_TV.Validated
        If Not txtTEN_BP_GSTT_TV.IsValidated Then
            txtTEN_BP_GSTT_TV.Focus()
            Exit Sub
            
        End If
    End Sub
End Class