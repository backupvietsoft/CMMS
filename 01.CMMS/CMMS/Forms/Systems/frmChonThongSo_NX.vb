
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class frmChonThongSo_NX

    'Member Class

    ' Khai báo biến 
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private MS_KH_TMP As String = ""
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader
    Public dtSource As New DataTable

#Region "Control Event"

   
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

    
    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        cboDonvido.SelectedValue = -1
        TxtMaso.Focus()
        blnThem = True
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        VisibleButton(False)
        LockData(False)
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grdDanhmucthongsoTB.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONGCODULIEUDEXOA", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BANCOCHACXOAKHONG", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng GIA_TRI_TS_GSTT không.
            SQL_TMP = "SELECT * FROM NHA_XUONG_THONG_SO WHERE MS_TS = '" & TxtMaso.Text & "'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONGDUOCXOA", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End While
            dtReader.Close()
            ' Xóa khách hàng
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_DELETE_THONG_SO", TxtMaso.Text)
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If grdDanhmucthongsoTB.Rows.Count > 0 Then
                If grdDanhmucthongsoTB.Rows.Count = tmp Then
                    grdDanhmucthongsoTB.CurrentCell() = grdDanhmucthongsoTB.Rows(tmp - 1).Cells("TEN_TS")
                    grdDanhmucthongsoTB.Focus()
                Else
                    grdDanhmucthongsoTB.CurrentCell() = grdDanhmucthongsoTB.Rows(tmp).Cells("TEN_TS")
                    grdDanhmucthongsoTB.Focus()
                End If
            End If
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
            For i As Integer = 0 To grdDanhmucthongsoTB.Rows.Count - 1
                If grdDanhmucthongsoTB.Rows(i).Cells("MS_TS").Value = intMS_TO Then
                    grdDanhmucthongsoTB.Focus()
                    grdDanhmucthongsoTB.Rows(i).Cells("TEN_TS").Selected = True
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
            If grdDanhmucthongsoTB.RowCount <> 0 Then
                ShowThongSo(grdDanhmucthongsoTB.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowThongSo(0)
        End Try

        blnThem = False
        VisibleButton(True)
        LockData(True)
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Dispose()
    End Sub

    Private Sub grdDanhmucthongsoTB_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhmucthongsoTB.RowHeaderMouseClick
        ShowThongSo(e.RowIndex)
    End Sub
    Dim intRow As Integer
    Private Sub grdDanhmucthongsoTB_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhmucthongsoTB.RowEnter
        ShowThongSo(e.RowIndex)
        intRow = e.RowIndex
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        TxtTenthongsoTB.Text = ""
        'txtGhichu.Text = ""
        cboDonvido.Text = ""
    End Sub
    Sub ShowThongSo(ByVal RowIndex As Integer)
        TxtMaso.Text = grdDanhmucthongsoTB.Rows(RowIndex).Cells("MS_TS").Value
        TxtTenthongsoTB.Text = grdDanhmucthongsoTB.Rows(RowIndex).Cells("TEN_TS").Value
        If grdDanhmucthongsoTB.Rows(RowIndex).Cells("DINH_LUONG").Value.Equals(True) Then
            chkDinhTinh.Checked = False
        Else
            chkDinhTinh.Checked = True
        End If
        cboDonvido.Text = grdDanhmucthongsoTB.Rows(RowIndex).Cells("TEN_DV_DO").Value
    End Sub
    Sub Load_cboDonvido()
        cboDonvido.Value = "MS_DV_DO"
        cboDonvido.Display = "TEN_DV_DO"
        cboDonvido.StoreName = "GetDON_VI_DOs"
        cboDonvido.ClassName = "frmDonvido"
        cboDonvido.BindDataSource()
    End Sub
    Dim _dt As New DataTable
    Sub BindData()
        Try

       
            _dt = New DataTable
            _dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DSTS_NX"))
            For Each col As DataColumn In _dt.Columns
                col.ReadOnly = False
            Next
            Me.grdDanhmucthongsoTB.DataSource = _dt
            grdDanhmucthongsoTB.ReadOnly = False
            grdDanhmucthongsoTB.Columns("MS_TS").Visible = False
            grdDanhmucthongsoTB.Columns("TEN_TS").Width = 300
            grdDanhmucthongsoTB.Columns("TEN_DV_DO").Width = 50
            grdDanhmucthongsoTB.Columns("CHON").Width = 50
            grdDanhmucthongsoTB.Columns("CHON").ReadOnly = False
            grdDanhmucthongsoTB.Columns("TEN_TS").ReadOnly = True
            grdDanhmucthongsoTB.Columns("TEN_DV_DO").ReadOnly = True
            grdDanhmucthongsoTB.Columns("DINH_LUONG").Visible = False
            With Me.grdDanhmucthongsoTB
                .ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                .DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            End With
            If grdDanhmucthongsoTB.RowCount = 0 Then cboDonvido.SelectedValue = -1
        Catch ex As Exception

        End Try
    End Sub
    Function isValidated()
        Dim dtReader As SqlDataReader
        If Not TxtMaso.IsValidated Then
            Return False
        End If
        If Not TxtTenthongsoTB.IsValidated Then
            Return False
        End If
        Commons.Modules.SQLString = "SELECT TEN_TS FROM THONG_SO WHERE TEN_TS=N'" & TxtTenthongsoTB.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TONTAITENTHONGSO", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Return False
        End While
        dtReader.Close()
        If Not cboDonvido.IsValidated Then
            Return False
        End If
        Return True
    End Function
    Sub AddThongSoTB()
        Dim ms_ts As String = TxtMaso.Text
        Dim ten_ts As String = TxtTenthongsoTB.Text
        Dim ms_dv As String = cboDonvido.SelectedValue
        Dim dinh_luong As Boolean = False
        If chkDinhTinh.Checked Then
            dinh_luong = False
        Else
            dinh_luong = True
        End If
        If Not blnThem Then
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_NHU_Y_UPDATE_THONG_SO", ms_ts, ten_ts, ms_dv, dinh_luong)
        Else
            TxtMaso.Text = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_NHU_Y_INSERT_THONG_SO", ten_ts, ms_dv, dinh_luong)
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
        TxtTenthongsoTB.ReadOnly = blnLock
        chkDinhTinh.Enabled = Not blnLock
        cboDonvido.Enabled = Not blnLock

    End Sub

    Private Sub btnDonvido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmDonvido As Report1.frmDonvido = New Report1.frmDonvido()
        frmDonvido.Show()
    End Sub
#End Region

    Private Sub frmChonThongSo_NX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Commons.Modules.ObjSystems.DinhDang()
        Load_cboDonvido()
        BindData()

        VisibleButton(True)
        LockData(True)
        Try
            grdDanhmucthongsoTB.Rows(0).Cells(1).Selected = True
        Catch ex As Exception
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        _dt.DefaultView.RowFilter = "CHON=TRUE"
        dtSource = _dt.DefaultView.ToTable()
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class