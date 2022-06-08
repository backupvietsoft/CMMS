
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmThongsothietbi

    'Member Class

    ' Khai báo biến 
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private MS_KH_TMP As String = ""
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader


#Region "Control Event"

    Private Sub frmThongsothietbi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Load_cboDonvido()
        BindData()
        VisibleButton(True)
        LockData(True)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        cboDonvido.EditValue = -1
        TxtMaso.Focus()
        blnThem = True
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grvThongSo.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng GIA_TRI_TS_GSTT không.
            SQL_TMP = "SELECT * FROM THONG_SO_CHINH_MAY WHERE MS_THONG_SO_MAY = '" & TxtMaso.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While
            dtReader.Close()
            ' Xóa khách hàng
            Dim objThongSoMayController As New THONG_SO_MAYController()
            objThongSoMayController.DeleteTHONG_SO_MAY(TxtMaso.Text)
            Refesh()
            Dim tmp As Integer = grvThongSo.FocusedRowHandle
            grvThongSo.DeleteRow(tmp)
            'BindData()
            'If grvThongSo.Rows.Count > 0 Then
            '    If grvThongSo.Rows.Count = tmp Then
            '        grvThongSo.CurrentCell() = grvThongSo.Rows(tmp - 1).Cells("TEN_THONG_SO_MAY")
            '        grvThongSo.Focus()
            '    Else
            '        grvThongSo.CurrentCell() = grvThongSo.Rows(tmp).Cells("TEN_THONG_SO_MAY")
            '        grvThongSo.Focus()
            '    End If
            'End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            Dim intMS_TO As Integer = 0

            AddThongSoTB()
            intMS_TO = TxtMaso.Text
            BindData()
            For i As Integer = 0 To grvThongSo.RowCount - 1
                If grvThongSo.GetDataRow(i)("MS_THONG_SO_MAY") = intMS_TO Then
                    grvThongSo.FocusedRowHandle = i
                    Exit For
                End If
            Next
            blnThem = False
            VisibleButton(True)
            LockData(True)
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grvThongSo.RowCount <> 0 Then
                ShowThongSo()
            End If
        Catch ex As Exception
            ShowThongSo()
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Dispose()
    End Sub


#End Region

#Region "Private Methods"
    Sub Refesh()
        TxtTenthongsoTB.Text = ""
        txtGhichu.Text = ""
        cboDonvido.Text = ""
    End Sub
    Sub ShowThongSo()
        TxtMaso.Text = grvThongSo.GetFocusedDataRow()("MS_THONG_SO_MAY")
        TxtTenthongsoTB.Text = grvThongSo.GetFocusedDataRow()("TEN_THONG_SO_MAY")
        txtGhichu.Text = grvThongSo.GetFocusedDataRow()("GHI_CHU")
        cboDonvido.EditValue = grvThongSo.GetFocusedDataRow()("MS_DV_DO") ' grvThongSo.Rows(RowIndex).Cells("TEN_DV_DO").Value
    End Sub
    Sub Load_cboDonvido()

        Dim dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_DOs"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonvido, dtTmp, "MS_DV_DO", "TEN_DV_DO", Name)

        'frmDonvido
    End Sub
    Sub BindData()
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongSo, grvThongSo, New THONG_SO_MAYController().GetTHONG_SO_MAYs(), False, False, True, False, True, Name)
        grvThongSo.Columns("MS_THONG_SO_MAY").Visible = False
        grvThongSo.Columns("TEN_THONG_SO_MAY").Width = 300
        grvThongSo.Columns("GHI_CHU").Width = 80
        grvThongSo.Columns("MS_DV_DO").Visible = False
        If grvThongSo.RowCount = 0 Then cboDonvido.EditValue = -1
    End Sub
    Function isValidated()
        Dim dtReader As SqlDataReader
        If String.IsNullOrEmpty(TxtTenthongsoTB.Text.Trim()) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNhapTenTSTB", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        End If

        Commons.Modules.SQLString = "SELECT TEN_THONG_SO_MAY FROM THONG_SO_MAY WHERE TEN_THONG_SO_MAY=N'" & TxtTenthongsoTB.Text & "' AND MS_DV_DO='" & cboDonvido.EditValue.ToString & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTEN_TB", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Return False
        End While
        dtReader.Close()
        Return True
    End Function
    Sub AddThongSoTB()
        Dim objThongSoTBController As New THONG_SO_MAYController()
        Dim objThongSoTBInfo As New THONG_SO_MAYInfo
        objThongSoTBInfo.TEN_THONG_SO_MAY = TxtTenthongsoTB.Text.Trim().ToString() 'Commons.Modules.ObjSystems.SplitString(TxtTenthongsoTB.Text)
        objThongSoTBInfo.MS_DV_DO = cboDonvido.EditValue.ToString
        objThongSoTBInfo.GHI_CHU = txtGhichu.Text

        If Not blnThem Then
            objThongSoTBInfo.MS_THONG_SO_MAY = TxtMaso.Text
            objThongSoTBController.UpdateTHONG_SO_MAY(objThongSoTBInfo)
        Else
            TxtMaso.Text = objThongSoTBController.AddTHONG_SO_MAY(objThongSoTBInfo)
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
        TxtTenthongsoTB.Properties.ReadOnly = blnLock
        txtGhichu.Properties.ReadOnly = blnLock
        cboDonvido.Enabled = Not blnLock
        grdThongSo.Enabled = blnLock
    End Sub

    Private Sub grvThongSo_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvThongSo.FocusedRowChanged
        ShowThongSo()
    End Sub

    Private Sub cboDonvido_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboDonvido.ButtonClick
        If (e.Button.Index <> 1) Then Return
        Dim str As String = cboDonvido.EditValue
        Dim frm As New Report1.frmDonvido
        frm.StartPosition = FormStartPosition.CenterParent
        frm.Size = New Size(900, 600)
        frm.ShowDialog()
        Load_cboDonvido()
        cboDonvido.EditValue = Convert.ToInt16(str)
    End Sub
#End Region

End Class