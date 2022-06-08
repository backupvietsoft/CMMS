
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin

Public Class frmBactho

    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private Ten_bt_tmp As String


#Region "Control Event"

    Private Sub FrmBacTho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        Try
            GrdDanhmucbactho.Rows(0).Cells(1).Selected = True
        Catch ex As Exception

        End Try
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
        Me.LblTenbactho.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblTenbactho.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnGhi.Name, Commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, Commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnSua.Name, Commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThem.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnXoa.Name, Commons.Modules.TypeLanguage)
        Me.GrpDanhmucbactho.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GrpDanhmucbactho.Name, Commons.Modules.TypeLanguage)
        Me.GrpNhapbactho.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GrpNhapbactho.Name, Commons.Modules.TypeLanguage)
        Me.GrdDanhmucbactho.Columns("TEN_BAC_THO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BAC_THO", Commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        TxtTenbactho.Focus()
        GrdDanhmucbactho.Enabled = False
    End Sub
    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        Ten_bt_tmp = TxtTenbactho.Text
        VisibleButton(False)
        LockData(False)
        TxtTenbactho.Focus()
        GrdDanhmucbactho.Enabled = False
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If GrdDanhmucbactho.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa !", MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        'Dim Traloi As String = MsgBox("Bạn có muốn xóa bậc thợ này không ? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            ' Kiểm tra xem bậc thợ này có đang tồn tại trong bảng CONG_VIEC không.

            Dim SQL_TMP As String = "SELECT * FROM CONG_NHAN_CHUYEN_MON_BAC_THO WHERE MS_BAC_THO = '" & TxtMabactho.Text & "'"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While

            SQL_TMP = "SELECT * FROM CONG_VIEC WHERE MS_BAC_THO = '" & TxtMabactho.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                ' Dữ liệu đang được sử dụng trong bảng công việc ! Bạn không thể xoá !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While
            ' Xóa bậc thợ
            Dim tmp As Integer = intRow
            Dim objBacThoController As New BAC_THOController()
            objBacThoController.DeleteBAC_THO(TxtMabactho.Text)
            Refesh()
            BindData()
            If GrdDanhmucbactho.Rows.Count > 0 Then
                If GrdDanhmucbactho.Rows.Count = tmp Then
                    GrdDanhmucbactho.CurrentCell() = GrdDanhmucbactho.Rows(tmp - 1).Cells("TEN_BAC_THO")
                    GrdDanhmucbactho.Focus()
                Else
                    GrdDanhmucbactho.CurrentCell() = GrdDanhmucbactho.Rows(tmp).Cells("TEN_BAC_THO")
                    GrdDanhmucbactho.Focus()
                End If
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim tmp As String = Trim(TxtTenbactho.Text)

        SQL_TMP = "SELECT * FROM BAC_THO WHERE TEN_BAC_THO = '" & TxtTenbactho.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            If blnThem Then
                If Not BtnKhongghi.Focused Then
                    ' Bậc thợ này đã tồn tại ! Vui lòng nhập lại tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    TxtTenbactho.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            Else
                If Not BtnKhongghi.Focused And TxtTenbactho.Text <> Ten_bt_tmp Then
                    ' Bậc thợ này đã tồn tại ! Vui lòng nhập lại tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    TxtTenbactho.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            End If
        End While

        If isValidated() And Trim(TxtTenbactho.Text) <> "" Then
            AddBacTho()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < GrdDanhmucbactho.RowCount
                If GrdDanhmucbactho.Rows(i).Cells("TEN_BAC_THO").Value.ToString = tmp Then
                    GrdDanhmucbactho.Rows(i).Cells("TEN_BAC_THO").Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        Else
            'MessageBox.Show("Tên bậc thợ không được rỗng ! Vui lòng nhập vào tên bậc thợ.")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Thông báo")
            TxtTenbactho.Focus()
            Exit Sub
        End If
        GrdDanhmucbactho.Enabled = True
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refresh()
        Try
            If GrdDanhmucbactho.RowCount <> 0 Then
                ShowBacTho(GrdDanhmucbactho.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowBacTho(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
        GrdDanhmucbactho.Enabled = True
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhmucbactho.RowHeaderMouseClick
        ShowBacTho(e.RowIndex)
    End Sub

    Dim intRow As Integer
    Private Sub GrdDanhmucbactho_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhmucbactho.RowEnter
        ShowBacTho(e.RowIndex)
        intRow = e.RowIndex
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        'TxtMadonvido.Text = ""
        TxtTenbactho.Text = ""
    End Sub
    Sub ShowBacTho(ByVal RowIndex As Integer)
        TxtMabactho.Text = GrdDanhmucbactho.Rows(RowIndex).Cells("MS_BAC_THO").Value
        TxtTenbactho.Text = GrdDanhmucbactho.Rows(RowIndex).Cells("TEN_BAC_THO").Value
    End Sub
    Sub BindData()

        Me.GrdDanhmucbactho.DataSource = New BAC_THOController().GetBAC_THOs
        GrdDanhmucbactho.Columns("MS_BAC_THO").Visible = False
        If GrdDanhmucbactho.RowCount > 0 Then
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
        Else
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        End If
        Try
            Me.GrdDanhmucbactho.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhmucbactho.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
        'If Commons.Modules.PermisString.Equals("Read only") Then
        '    EnableButton(False)
        'End If
    End Sub
    Function isValidated()
        'If Not TxtMadonvido.IsValidated Then
        '    Return False
        'End If
        If Not TxtTenbactho.IsValidated Then
            Return False
        End If
        Return True
    End Function

    Sub AddBacTho()
        Dim objBacThoInfo As New BAC_THOInfo
        Dim objBacThoController As New BAC_THOController()

        objBacThoInfo.TEN_BT = Trim(TxtTenbactho.Text)
        If Not blnThem Then
            objBacThoInfo.MS_BT = TxtMabactho.Text
            objBacThoController.UpdateBAC_THO(objBacThoInfo)
        Else
            objBacThoController.AddBAC_THO(objBacThoInfo)
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
        TxtTenbactho.ReadOnly = blnLock
    End Sub

#End Region


End Class