
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin

Public Class frmStock
    Private _Tinh As Boolean = False
    Private Sub frmStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtTuNgay.Value = DateTime.Now.AddMonths(-6)
        BindingKho()
        BindingDangXuat()
    End Sub
    Private Sub BindingKho()        
        Dim _tbKho As DataTable = New DataTable()
        _tbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select MS_KHO,TEN_KHO from dbo.IC_KHO"))
        Dim _rowall As DataRow = _tbKho.NewRow()
        _rowall("MS_KHO") = -1
        _rowall("TEN_KHO") = " < ALL > "
        _tbKho.Rows.InsertAt(_rowall, 0)
        cboKho.ValueMember = "MS_KHO"
        cboKho.DisplayMember = "TEN_KHO"
        cboKho.DataSource = _tbKho
        BindingPhuTung()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Private Sub BindingDangXuat()
        Dim _tbDangXuat As DataTable = New DataTable()
        _tbDangXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select convert(bit,0)as CHON,MS_DANG_XUAT,DANG_XUAT_VIET AS TEN_DANG_XUAT from dbo.DANG_XUAT"))
        _tbDangXuat.Columns("CHON").ReadOnly = False
        grvDangXuat.AutoGenerateColumns = False
        grvDangXuat.Columns("colCHON").DataPropertyName = "CHON"
        grvDangXuat.Columns("colMaDangXuat").DataPropertyName = "MS_DANG_XUAT"
        grvDangXuat.Columns("colTenDangXuat").DataPropertyName = "TEN_DANG_XUAT"
        grvDangXuat.DataSource = _tbDangXuat
    End Sub

    Private Sub cboKho_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKho.SelectionChangeCommitted
        BindingPhuTung()
    End Sub
    Private Sub BindingPhuTung()
        Me.Validate()
        Dim _TbPhuTung As DataTable = New DataTable()
        _TbPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_MIN_MAX", cboKho.SelectedValue, dtTuNgay.Value, dtDenNgay.Value, GetDangXuat()))
        grvVTPT.AutoGenerateColumns = False
        grvVTPT.Columns("MS_PT").DataPropertyName = "MS_PT"
        grvVTPT.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        grvVTPT.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"
        grvVTPT.Columns("PART_NO").DataPropertyName = "PART_NO"
        grvVTPT.Columns("DVT").DataPropertyName = "DVT"
        grvVTPT.Columns("HANG_NGOAI").DataPropertyName = "HANG_NGOAI"
        grvVTPT.Columns("TOTAL_USAGE").DataPropertyName = "TOTAL_SL_XUAT"
        grvVTPT.Columns("MAX_WEEK").DataPropertyName = "MAX_WEEK"
        grvVTPT.Columns("EVERAGE_WEEK").DataPropertyName = "EVERAGE_WEEK"
        grvVTPT.Columns("ANNUAL").DataPropertyName = "ANNUAL"
        grvVTPT.Columns("GIA_CUOI").DataPropertyName = "DON_GIA_CUOI"
        grvVTPT.Columns("HE_SO").DataPropertyName = "HE_SO"
        grvVTPT.Columns("LEADTIME").DataPropertyName = "LEADTIME"
        grvVTPT.Columns("TON_MIN").DataPropertyName = "TON_TOI_THIEU"
        grvVTPT.Columns("TON_MAX").DataPropertyName = "TON_KHO_MAX"
        grvVTPT.DataSource = _TbPhuTung
    End Sub
    Private Function GetDangXuat() As String
        Dim _DangXuat As String = String.Empty
        For Each row As DataGridViewRow In grvDangXuat.Rows
            If (Not row.Cells("colCHON").Value Is Nothing) Then
                If (CType(row.Cells("colCHON").Value, Boolean)) Then
                    _DangXuat = _DangXuat + row.Cells("colMaDangXuat").Value.ToString() + ";"
                End If
            End If
        Next
        If (Not _DangXuat.Equals(String.Empty)) Then
            _DangXuat = _DangXuat.Substring(0, _DangXuat.Length - 1)
        End If
        Return _DangXuat
    End Function
    Private Sub dtTuNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTuNgay.ValueChanged
        BindingPhuTung()
    End Sub
    Private Sub dtDenNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDenNgay.ValueChanged
        BindingPhuTung()
    End Sub
    Private Sub dgvDangXuat_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvDangXuat.CellValueChanged
        If grvDangXuat.Columns(e.ColumnIndex).Name.Equals("colChon") Then
            BindingPhuTung()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtOrderNoi_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOrderNoi.Validating
        Try
            If (Not txtOrderNoi.Text.Trim().Equals(String.Empty)) Then
                Double.Parse(txtOrderNoi.Text)
            End If
        Catch ex As Exception
            e.Cancel = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

    Private Sub txtOrderNgoai_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOrderNgoai.Validating
        Try
            If (Not txtOrderNgoai.Text.Trim().Equals(String.Empty)) Then
                Double.Parse(txtOrderNgoai.Text)
            End If
        Catch ex As Exception
            e.Cancel = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub
    Private Sub txtCarryNoi_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCarryNoi.Validating
        Try
            If (Not txtCarryNoi.Text.Trim().Equals(String.Empty)) Then
                If (Double.Parse(txtCarryNoi.Text) = 0) Then
                    e.Cancel = True
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If
        Catch ex As Exception
            e.Cancel = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub
    Private Sub txtCarryNgoai_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCarryNgoai.Validating
        Try
            If (Not txtCarryNgoai.Text.Trim().Equals(String.Empty)) Then
                If (Double.Parse(txtCarryNgoai.Text) = 0) Then
                    e.Cancel = True
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If
        Catch ex As Exception
            e.Cancel = True
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

    Private Sub grvVTPT_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grvVTPT.CellValidating
        If (grvVTPT.Columns(e.ColumnIndex).Name.Equals("TON_MIN") Or grvVTPT.Columns(e.ColumnIndex).Name.Equals("TON_MAX")) Then
            If (Not grvVTPT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing) Then
                If (Not grvVTPT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.Equals(DBNull.Value)) Then
                    If (Not grvVTPT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString().Trim().Equals(String.Empty)) Then
                        Try
                            Double.Parse(grvVTPT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString())
                        Catch ex As Exception
                            e.Cancel = True
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        End Try
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grvVTPT_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grvVTPT.DataError
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SAI_DU_LIEU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        If (cboKho.SelectedValue Is Nothing) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON_KHO", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            cboKho.Focus()
            Return
        End If
        If (dtTuNgay.Value.AddDays(7) >= dtDenNgay.Value) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TU_NGAY7_LON_HON_DEN_NGAY", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtTuNgay.Focus()
            Return
        End If
        If (txtOrderNoi.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_ORDER_NOI", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtOrderNoi.Focus()
            Return
        End If
        If (txtOrderNgoai.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_ORDER_NGOAI", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtOrderNgoai.Focus()
            Return
        End If
        If (txtCarryNoi.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_CARRY_NOI", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtCarryNoi.Focus()
            Return
        End If
        If (txtCarryNgoai.Text.Trim().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_CARRY_NGOAI", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtCarryNgoai.Focus()
            Return
        End If
        If (GetDangXuat().Equals(String.Empty)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON_DANG_XUAT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            grvDangXuat.Focus()
            Return
        End If
        For Each _row As DataGridViewRow In grvVTPT.Rows
            Dim min As Double = CType(_row.Cells("LEADTIME").Value * _row.Cells("EVERAGE_WEEK").Value + ((_row.Cells("MAX_WEEK").Value - _row.Cells("EVERAGE_WEEK").Value) * _row.Cells("HE_SO").Value), Double)
            If (min / Int(min) <> 1) Then
                min = Int(min) + 1
            End If
            _row.Cells("TON_MIN").Value = min
            If (Not _row.Cells("HANG_NGOAI").Value Is Nothing) Then
                If (_row.Cells("HANG_NGOAI").Value.Equals(True)) Then
                    Dim max_ngoai As Double = CType(_row.Cells("TON_MIN").Value + System.Math.Sqrt((2 * _row.Cells("ANNUAL").Value * Double.Parse(txtOrderNgoai.Text)) / Double.Parse(txtCarryNgoai.Text)), Double)
                    If (max_ngoai / Int(max_ngoai) <> 1) Then
                        max_ngoai = Int(max_ngoai) + 1
                    End If
                    _row.Cells("TON_MAX").Value = max_ngoai
                Else
                    Dim max_noi As Double = CType(_row.Cells("TON_MIN").Value + System.Math.Sqrt((2 * _row.Cells("ANNUAL").Value * Double.Parse(txtOrderNoi.Text)) / Double.Parse(txtCarryNoi.Text)), Double)
                    If (max_noi / Int(max_noi) <> 1) Then
                        max_noi = Int(max_noi) + 1
                    End If
                    _row.Cells("TON_MAX").Value = max_noi
                End If
            Else
                _row.Cells("TON_MAX").Value = _row.Cells("TON_MIN").Value + System.Math.Sqrt((2 * _row.Cells("ANNUAL").Value * Double.Parse(txtOrderNoi.Text)) / Double.Parse(txtCarryNoi.Text))
            End If
        Next
        _Tinh = True
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TINH_THANH_CONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (Not _Tinh) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TINH_TRUOC_KHI_CAP_NHAT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Return
        End If
        If (MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TINH_THANH_CONG", commons.Modules.TypeLanguage), MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Ok) Then
            Dim _CNN As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
            If (_CNN.State = ConnectionState.Closed) Then
                _CNN.Open()
            End If
            Dim _Tran As SqlTransaction = _CNN.BeginTransaction()
            Try
                For Each _row As DataGridViewRow In grvVTPT.Rows
                    SqlHelper.ExecuteNonQuery(_Tran, CommandType.Text, "Update dbo.IC_PHU_TUNG SET TON_TOI_THIEU = " + _row.Cells("TON_MIN").Value.ToString() + ",TON_KHO_MAX = " + _row.Cells("TON_MAX").Value.ToString() + " WHERE MS_PT = N'" + _row.Cells("MS_PT").Value.ToString() + "'")
                Next
                _Tran.Commit()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CAP_NHAT_THANH_CONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                _Tinh = False
            Catch ex As Exception
                _Tran.Rollback()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CAP_NHAT_KHONG_THANH_CONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            End Try
        End If
    End Sub
End Class