Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmCachdathang

#Region "Private Member"
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private LOAD_GRID As Integer = 1

#End Region

#Region "Control Event"

    Private Sub frmCachdathang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)

        If Me.grdDanhsachcachDH.RowCount > 0 Then
            Me.grdDanhsachcachDH.Rows(0).Selected = True
            ShowCachDH(0)
        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.lblcachDH.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblcachDH.Name, Commons.Modules.TypeLanguage)
        Me.lblTieudecachdathang.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTieudecachdathang.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnGhi.Name, Commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, Commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnSua.Name, Commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThem.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnXoa.Name, Commons.Modules.TypeLanguage)
        Me.grpDanhsachcachDH.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpDanhsachcachDH.Name, Commons.Modules.TypeLanguage)
        Me.grpNhapcachDH.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpNhapcachDH.Name, Commons.Modules.TypeLanguage)
        Me.grdDanhsachcachDH.Columns("CACH_DAT_HANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CACH_DAT_HANG", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        txtTencachDH.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
        txtTencachDH.Focus()
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grdDanhsachcachDH.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            '  Kiểm tra đơn vị TG có đang được sử dụng trong bảng IC_PHU_TUNG không.

            SQL_TMP = "SELECT * FROM IC_PHU_TUNG WHERE MS_CACH_DAT_HANG = '" & txtMasocachDH.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

                Exit Sub
            End While

            ' Xóa đơn vị đo

            Dim objCachDHController As New CACH_DAT_HANGController()
            objCachDHController.DeleteCACH_DAT_HANG(txtMasocachDH.Text)
            Refesh()
            BindData()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            Dim i As Integer
            Dim TEMP As String = Me.txtTencachDH.Text.Trim
            AddCachDH()
            blnThem = False
            If LOAD_GRID = 1 Then
                While i < Me.grdDanhsachcachDH.RowCount
                    If Me.grdDanhsachcachDH.Rows(i).Cells(1).Value.ToString = TEMP Then
                        Me.grdDanhsachcachDH.Rows(i).Cells("CACH_DAT_HANG").Selected = True
                        Me.grdDanhsachcachDH.Rows(i).Selected = True
                        ShowCachDH(i)
                        Exit While
                    Else
                        i = i + 1
                    End If
                End While
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grdDanhsachcachDH.RowCount <> 0 Then
                ShowCachDH(grdDanhsachcachDH.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowCachDH(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdDanhsachcachDH_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachcachDH.RowHeaderMouseClick
        ShowCachDH(e.RowIndex)
    End Sub
#End Region

#Region "Private Methods"

    Sub Refesh()
        txtTencachDH.Text = ""
    End Sub
    Sub ShowCachDH(ByVal RowIndex As Integer)
        txtMasocachDH.Text = grdDanhsachcachDH.Rows(RowIndex).Cells("MS_CACH_DAT_HANG").Value
        txtTencachDH.Text = grdDanhsachcachDH.Rows(RowIndex).Cells("CACH_DAT_HANG").Value
    End Sub
    Sub BindData()
        Try
            Me.grdDanhsachcachDH.DataSource = New CACH_DAT_HANGController().GetCACH_DAT_HANGs
            grdDanhsachcachDH.Columns(0).Visible = False
            grdDanhsachcachDH.Columns(1).Width = 380
            Me.grdDanhsachcachDH.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachcachDH.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            If grdDanhsachcachDH.RowCount > 0 Then
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
        If Not txtTencachDH.IsValidated Then
            txtTencachDH.Focus()
            Return False
        End If
        Return True
    End Function
    Sub AddCachDH()
        Dim objCachDHInfo As New CACH_DAT_HANGInfo
        Dim objCachDHController As New CACH_DAT_HANGController()
        objCachDHInfo.CACH_DAT_HANG = txtTencachDH.Text
        If Not blnThem Then
            objCachDHInfo.MS_CACH_DAT_HANG = txtMasocachDH.Text
            If (objCachDHController.CheckExistCACH_DAT_HANG(Integer.Parse(Me.txtMasocachDH.Text.Trim), Me.txtTencachDH.Text.Trim)).Read Then
                objCachDHController.UpdateCACH_DAT_HANG(objCachDHInfo)
                VisibleButton(True)
                LockData(True)
                BindData()
            Else
                If (objCachDHController.CheckCACH_DAT_HANG(Me.txtTencachDH.Text.Trim)).Read Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCACH_DAT_HANG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtTencachDH.Focus()
                    VisibleButton(False)
                    LockData(False)
                    LOAD_GRID = 2
                    Exit Sub
                Else
                    objCachDHController.UpdateCACH_DAT_HANG(objCachDHInfo)
                    VisibleButton(True)
                    LockData(True)
                    BindData()
                End If
            End If
        Else
            If (objCachDHController.CheckCACH_DAT_HANG(Me.txtTencachDH.Text.Trim)).Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCACH_DAT_HANG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Me.txtTencachDH.Focus()
                VisibleButton(False)
                LockData(False)
                LOAD_GRID = 2
                blnThem = False
                Exit Sub
            Else
                objCachDHInfo.MS_CACH_DAT_HANG = New CACH_DAT_HANGController().AddCACH_DAT_HANG(objCachDHInfo)
                VisibleButton(True)
                LockData(True)
                BindData()
            End If
        End If
        LOAD_GRID = 1
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
        txtTencachDH.ReadOnly = blnLock
        Me.grdDanhsachcachDH.Enabled = blnLock
    End Sub
#End Region

End Class