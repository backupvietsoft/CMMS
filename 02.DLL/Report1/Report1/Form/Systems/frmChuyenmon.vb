
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin

Public Class frmChuyenmon
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL As String
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private Ten_cm_tmp As String


#Region "Control Event"
    Private Sub frmChuyenmon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        BindData()
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        Try
            GrdDanhmucchuyenmon.Rows(0).Cells(1).Selected = True
        Catch ex As Exception
        End Try
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.LblTenchuyenmon.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, LblTenchuyenmon.Name, Commons.Modules.TypeLanguage)
        Me.LblTieudechuyenmon.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, LblTieudechuyenmon.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.GrpNhapchuyenmon.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpNhapchuyenmon.Name, commons.Modules.TypeLanguage)
        Me.GrpDanhmucchuyenmon.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, GrpDanhmucchuyenmon.Name, commons.Modules.TypeLanguage)
        Me.GrdDanhmucchuyenmon.Columns("TEN_CHUYEN_MON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_CHUYEN_MON", commons.Modules.TypeLanguage)
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        GrdDanhmucchuyenmon.Enabled = False
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        Ten_cm_tmp = TxtTEN_CM.Text
        VisibleButton(False)
        LockData(False)
        GrdDanhmucchuyenmon.Enabled = False
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        Dim traloi As String
        Dim dtReader As SqlDataReader
        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa5", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
        If traloi = vbNo Then Exit Sub

        Dim objCHUYEN_MONController As New CHUYEN_MONController()

        If GrdDanhmucchuyenmon.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        SQL = "SELECT * FROM CONG_VIEC WHERE MS_CHUYEN_MON = " & TxtMS_CM.Text
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtReader.Close()
            Exit Sub
        End While

        SQL = "SELECT * FROM CONG_NHAN_CHUYEN_MON WHERE MS_CHUYEN_MON=" & TxtMS_CM.Text
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtReader.Close()
            Exit Sub
        End While

        SQL = "SELECT * FROM CONG_NHAN_CHUYEN_MON_BAC_THO WHERE MS_CHUYEN_MON=" & TxtMS_CM.Text
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa4", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        Dim tmp As Integer = intRow
        objCHUYEN_MONController.DeleteCHUYEN_MON(CType(TxtMS_CM.Text, Integer))
        Refesh()
        BindData()
        If GrdDanhmucchuyenmon.Rows.Count > 0 Then
            If GrdDanhmucchuyenmon.Rows.Count = tmp Then
                GrdDanhmucchuyenmon.CurrentCell() = GrdDanhmucchuyenmon.Rows(tmp - 1).Cells("TEN_CHUYEN_MON")
                GrdDanhmucchuyenmon.Focus()
            Else
                GrdDanhmucchuyenmon.CurrentCell() = GrdDanhmucchuyenmon.Rows(tmp).Cells("TEN_CHUYEN_MON")
                GrdDanhmucchuyenmon.Focus()
            End If
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim tmp As String = Trim(TxtTEN_CM.Text)
        If Trim(TxtTEN_CM.Text) = "" And Not BtnKhongghi.Focused Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            TxtTEN_CM.Focus()
            Exit Sub
        Else
            TxtTEN_CM.Text = Trim(TxtTEN_CM.Text)
        End If
        SQL_TMP = "SELECT * FROM CHUYEN_MON WHERE TEN_CHUYEN_MON = '" & TxtTEN_CM.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            If blnThem Then
                If Not BtnKhongghi.Focused Then
                    ' Bậc thợ này đã tồn tại ! Vui lòng nhập lại tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    TxtTEN_CM.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            Else
                If Not BtnKhongghi.Focused And TxtTEN_CM.Text <> Ten_cm_tmp Then
                    ' Bậc thợ này đã tồn tại ! Vui lòng nhập lại tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    TxtTEN_CM.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            End If
        End While

        If isValidated() Then
            AddCHUYEN_MON()
            BindData()
            blnThem = False
            VisibleButton(True)
            LockData(True)
            While i < GrdDanhmucchuyenmon.RowCount
                If GrdDanhmucchuyenmon.Rows(i).Cells("TEN_CHUYEN_MON").Value.ToString = tmp Then
                    GrdDanhmucchuyenmon.Rows(i).Cells("TEN_CHUYEN_MON").Selected = True
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        End If
        GrdDanhmucchuyenmon.Enabled = True
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If GrdDanhmucchuyenmon.RowCount > 0 Then
                ShowCHUYEN_MON(GrdDanhmucchuyenmon.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowCHUYEN_MON(0)
        End Try
        blnThem = False
        VisibleButton(True)
        LockData(True)
        GrdDanhmucchuyenmon.Enabled = True
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Close()
    End Sub

    Private Sub GrdDanhmucchuyenmon_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdDanhmucchuyenmon.RowHeaderMouseClick
        ShowCHUYEN_MON(e.RowIndex)
    End Sub
    Dim intRow
    Private Sub GrdDanhmucchuyenmon_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDanhmucchuyenmon.RowEnter
        ShowCHUYEN_MON(e.RowIndex)
        intRow = e.RowIndex
    End Sub

#End Region

#Region "Private Methods"

    Sub Refesh()
        TxtTEN_CM.Text = ""
        TxtMS_CM.Text = ""
    End Sub

    Sub ShowCHUYEN_MON(ByVal RowIndex As Integer)
        TxtTEN_CM.Text = GrdDanhmucchuyenmon.Rows(RowIndex).Cells("TEN_CHUYEN_MON").Value
        TxtMS_CM.Text = GrdDanhmucchuyenmon.Rows(RowIndex).Cells("MS_CHUYEN_MON").Value
    End Sub

    Sub BindData()
        Try
            GrdDanhmucchuyenmon.DataSource = New CHUYEN_MONController().GetCHUYEN_MONs
            GrdDanhmucchuyenmon.Columns(0).Visible = False
            GrdDanhmucchuyenmon.Columns(1).Resizable = DataGridViewTriState.False
            If GrdDanhmucchuyenmon.RowCount > 0 Then
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            Else
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
            Me.GrdDanhmucchuyenmon.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.GrdDanhmucchuyenmon.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try


    End Sub

    Function isValidated()
        If Not TxtTEN_CM.IsValidated Then
            TxtTEN_CM.Focus()
            Return False
        End If

        Return True
    End Function

    Sub AddCHUYEN_MON()
        Dim objCHUYEN_MONInfo As New CHUYEN_MONInfo
        Dim objCHUYEN_MONController As New CHUYEN_MONController()

        objCHUYEN_MONInfo.TEN_CM = Trim(TxtTEN_CM.Text)
        If Not blnThem Then
            objCHUYEN_MONInfo.MS_CM = CInt(TxtMS_CM.Text)
            objCHUYEN_MONController.UpdateCHUYEN_MON(objCHUYEN_MONInfo)
        Else
            objCHUYEN_MONController.AddCHUYEN_MON(objCHUYEN_MONInfo)
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
        TxtTEN_CM.ReadOnly = blnLock
    End Sub
#End Region

End Class