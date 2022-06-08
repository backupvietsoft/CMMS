
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin

Public Class frmBophanchiuphi_cs
    Dim txtBaoTri As TextBox

#Region "Private Member"
    Private objKPNController As New KINH_PHI_NAMController
    Private blnThem As Boolean
    Private intPos As Integer
    Private DELETE_CON As Integer = 1
    Private MS_KPN As Integer
    Private THANG_KPN As Date
    Private MS_LOAI_CP As String
    Private RETURN_ROW As Integer
    Private LOAD_GRID As Integer = 1
    Private CURRENCY_VALUE As String

#End Region

#Region "Events form"
    Sub Them()
        If Me.grdDanhSach.Rows.Count > 0 Then
            intPos = grdDanhSach.CurrentRow.Index
        End If
        Refesh()
        RefreshBoPhanChiuPhi()
        VisibleButton(False)
        VisibleXOA(False)
        LockData(False)
        blnThem = True
        Try
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
            grdNganSach.Columns("THANH_TIEN_USD").ReadOnly = True
        Catch ex As Exception

        End Try
        AddHandler grdNganSach.CellValidating, AddressOf Me.grdNganSach_CellValidating
    End Sub
    Sub Sua()
        If Me.grdDanhSach.Rows.Count > 0 Then
            intPos = Me.grdDanhSach.CurrentRow.Index
        End If
        VisibleButton(False)
        VisibleXOA(False)
        LockData(False)
        Me.grdNganSach.Focus()
        Me.grdNganSach.Rows(Me.grdNganSach.RowCount - 1).Cells("THANG").Selected = True

        Try
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
            grdNganSach.Columns("THANH_TIEN_USD").ReadOnly = True
        Catch ex As Exception
        End Try
        AddHandler grdNganSach.CellValidating, AddressOf Me.grdNganSach_CellValidating
    End Sub
    Sub Xoa()
        VisibleButton(False)
        VisibleXOA(True)
        Me.BtnGhi.Visible = False
        Me.BtnKhongghi.Visible = False
        Me.grdDanhSach.Enabled = False
        If grdNganSach.RowCount > 0 Then
            grdNganSach.Focus()
            grdNganSach.Rows(0).Cells("THANG").Selected = True
        End If
    End Sub
    Sub KhongGhi()
        RemoveHandler grdNganSach.CellValidating, AddressOf Me.grdNganSach_CellValidating
        blnThem = False
        VisibleButton(True)
        VisibleXOA(False)
        LockData(True)
        ' Tăng sửa 15/01/2006
        Refesh()
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        If Me.grdDanhSach.Rows.Count > 0 Then
            Me.grdDanhSach.Rows(intPos).Cells("TEN_BP_CHIU_PHI").Selected = True
            ShowBoPhanChiuPhi(Me.grdDanhSach.CurrentRow.Index)
        End If
    End Sub
    Sub Ghi()
        If isValidated() Then
            Dim i As Integer
            Dim TEMP As String = Me.txtTEN_BP_CHIU_PHI.Text.Trim()
            AddBoPhanChiuPhi()
            If LOAD_GRID = 1 Then
                BindData()
                blnThem = False
                VisibleButton(True)
                LockData(True)
                If Me.grdDanhSach.Rows.Count > 0 Then
                    Me.grdDanhSach.Rows(intPos).Cells("TEN_BP_CHIU_PHI").Selected = True
                End If
                While i < Me.grdDanhSach.RowCount
                    If Me.grdDanhSach.Rows(i).Cells("TEN_BP_CHIU_PHI").Value = TEMP Then
                        Me.grdDanhSach.Rows(i).Cells(1).Selected = True
                        Me.grdDanhSach.Rows(i).Selected = True
                        ShowBoPhanChiuPhi(i)
                        Exit While
                    Else
                        i = i + 1
                    End If
                End While
            End If
        Else
            Exit Sub
        End If

        RemoveHandler grdNganSach.CellValidating, AddressOf Me.grdNganSach_CellValidating
    End Sub
    Private Sub frmBophanchiuphi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.A Then
                Them()
            ElseIf e.KeyCode = Keys.E Then
                Sua()
            ElseIf e.KeyCode = Keys.D Then
                Xoa()
            ElseIf e.KeyCode = Keys.N Then
                KhongGhi()
            ElseIf e.KeyCode = Keys.S Then
                Ghi()
            ElseIf e.KeyCode = Keys.X Then
                Me.Close()
            End If
        End If
    End Sub


    Private Sub frmBophanchiuphi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commons.Modules.ObjSystems.DinhDang()
        ''Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, Me.Name)DDDGDFGDFGSDGSSSS
        If Commons.Modules.PermisString.Equals("Read only") Then
            BindDataCombo()
            Refesh()
            BindData()
            RefeshLanguage()
            GetCurrencyValue()
            VisibleButton(True)
            VisibleXOA(False)
            LockData(True)
            EnableButton(False)
        Else
            EnableButton(True)
            BindDataCombo()
            Refesh()
            BindData()
            RefeshLanguage()
            GetCurrencyValue()
            VisibleButton(True)
            VisibleXOA(False)
            LockData(True)

        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        'BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        If Me.grdDanhSach.Rows.Count > 0 Then
            intPos = grdDanhSach.CurrentRow.Index
        End If
        Refesh()
        RefreshBoPhanChiuPhi()
        VisibleButton(False)
        VisibleXOA(False)
        LockData(False)
        blnThem = True
        Try
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
            grdNganSach.Columns("THANH_TIEN_USD").ReadOnly = True
        Catch ex As Exception

        End Try
        txtTEN_BP_CHIU_PHI.Focus()
    End Sub
    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        If Me.grdDanhSach.Rows.Count > 0 Then
            intPos = Me.grdDanhSach.CurrentRow.Index
        End If
        VisibleButton(False)
        VisibleXOA(False)
        LockData(False)
        Me.grdNganSach.Focus()
        Me.grdNganSach.Rows(Me.grdNganSach.RowCount - 1).Cells("THANG").Selected = True

        Try
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
            grdNganSach.Columns("THANH_TIEN_USD").ReadOnly = True
        Catch ex As Exception
        End Try

    End Sub
    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        VisibleButton(False)
        VisibleXOA(True)
        Me.BtnGhi.Visible = False
        Me.BtnKhongghi.Visible = False
        Me.grdDanhSach.Enabled = False
        If grdNganSach.RowCount > 0 Then
            grdNganSach.Focus()
            grdNganSach.Rows(0).Cells("THANG").Selected = True
        End If
    End Sub
    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            Dim i As Integer
            Dim TEMP As String = Me.txtTEN_BP_CHIU_PHI.Text.Trim()
            AddBoPhanChiuPhi()
            If LOAD_GRID = 1 Then
                BindData()
                blnThem = False
                VisibleButton(True)
                LockData(True)
                If Me.grdDanhSach.Rows.Count > 0 Then
                    Me.grdDanhSach.Rows(intPos).Cells("TEN_BP_CHIU_PHI").Selected = True
                End If
                While i < Me.grdDanhSach.RowCount
                    If Me.grdDanhSach.Rows(i).Cells("TEN_BP_CHIU_PHI").Value = TEMP Then
                        Me.grdDanhSach.Rows(i).Cells(1).Selected = True
                        Me.grdDanhSach.Rows(i).Selected = True
                        ShowBoPhanChiuPhi(i)
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

        blnThem = False
        VisibleButton(True)
        VisibleXOA(False)
        LockData(True)
        ' Tăng sửa 15/01/2006
        Refesh()
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        If Me.grdDanhSach.Rows.Count > 0 Then
            Me.grdDanhSach.Rows(intPos).Cells("TEN_BP_CHIU_PHI").Selected = True
            ShowBoPhanChiuPhi(Me.grdDanhSach.CurrentRow.Index)
        End If
    End Sub
    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.Dispose()
    End Sub
    Private Sub grdDanhSach_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhSach.RowEnter
        ShowBoPhanChiuPhi(e.RowIndex)
        RETURN_ROW = e.RowIndex
    End Sub
    Private Sub grdDanhSach_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhSach.RowHeaderMouseClick
        ShowBoPhanChiuPhi(e.RowIndex)
        RETURN_ROW = e.RowIndex
    End Sub

    Private Sub grdNganSach_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdNganSach.CellValidating
        If Me.BtnKhongghi.Focused Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If e.RowIndex < grdNganSach.Rows.Count - 1 Then
                Me.grdNganSach.Columns("SO_TIEN").DefaultCellStyle.Format = "#,##0.00"
                Me.grdNganSach.Columns("THANG").DefaultCellStyle.Format = "MM/yyyy"
                Me.grdNganSach.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,##0.00"
                Me.grdNganSach.Columns("THANH_TIEN_USD").DefaultCellStyle.Format = "#,##0.00"
                'Me.grdNganSach.Columns("TONG_CP_BT").DefaultCellStyle.Format = "#,##0.00"
                Me.grdNganSach.Columns("TY_GIA").DefaultCellStyle.Format = "#,##0.0000"
                Me.grdNganSach.Columns("TY_GIA_USD").DefaultCellStyle.Format = "#,##0.0000"
                If grdNganSach.Columns(e.ColumnIndex).Name = "THANG" Then
                    If e.FormattedValue <> "" Then
                        If Not IsDate(e.FormattedValue) Then
                            ' Năm phải là kiểu số !
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheck001", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                            grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                            e.Cancel = True
                        End If
                    ElseIf e.RowIndex < grdNganSach.RowCount - 1 Then
                        ' Năm không được rỗng ! 
                        e.Cancel = True
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheck02", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                    End If
                ElseIf grdNganSach.Columns(e.ColumnIndex).Name = "SO_TIEN" Then
                    If e.FormattedValue <> "" Then
                        If e.FormattedValue = 0 Then
                            e.Cancel = True
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoTien", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Else
                            Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value
                            Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN_USD").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA_USD").Value
                        End If
                    Else
                        ' Số tiền không được rỗng ! 
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheck04", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                        e.Cancel = True
                    End If
                ElseIf grdNganSach.Columns(e.ColumnIndex).Name = "NGOAI_TE" Then
                    Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value = New BO_PHAN_CHIU_PHIController().GetTI_GIA(e.FormattedValue)

                    Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = _
                            grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value * grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value

                    Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA_USD").Value = New BO_PHAN_CHIU_PHIController().GetTI_GIA_USD(e.FormattedValue)
                    Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN_USD").Value = _
                            grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value * grdNganSach.Rows(e.RowIndex).Cells("TY_GIA_USD").Value

                ElseIf grdNganSach.Columns(e.ColumnIndex).Name = "TY_GIA" Then
                    If e.FormattedValue.Equals("") = False Then
                        If e.FormattedValue = 0 Then
                            e.Cancel = True
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTyGia", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Else
                            Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value
                        End If

                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheckTyGiaNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        e.Cancel = True
                        'Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = 0
                    End If
                ElseIf grdNganSach.Columns(e.ColumnIndex).Name = "TY_GIA_USD" Then
                    If e.FormattedValue.Equals("") = False Then
                        If e.FormattedValue = 0 Then
                            e.Cancel = True
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTyGiaUSD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Else
                            Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN_USD").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value
                        End If

                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheckTyGiaUSDNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        e.Cancel = True
                        'Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = 0
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub grdNganSach_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) ' Handles grdNganSach.CellValidating
    '    If Me.BtnKhongghi.Focused Then
    '        Exit Sub
    '    End If

    '    Me.grdNganSach.Columns("SO_TIEN").DefaultCellStyle.Format = "#,##0.00"
    '    Me.grdNganSach.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,##0.00"
    '    Me.grdNganSach.Columns("TONG_CP_BT").DefaultCellStyle.Format = "#,##0.00"
    '    Me.grdNganSach.Columns("TY_GIA").DefaultCellStyle.Format = "#,##0.0000"
    '    If grdNganSach.Columns(e.ColumnIndex).Name = "NAM" Then
    '        If e.FormattedValue <> "" Then
    '            If Not IsNumeric(e.FormattedValue) Then
    '                ' Năm phải là kiểu số !
    '                e.Cancel = True
    '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheck01", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '                grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
    '            Else
    '                If e.FormattedValue <= 0 Then
    '                    ' Năm phai là một số lớn hơn 0 !
    '                    e.Cancel = True
    '                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChecknam", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '                    grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
    '                Else
    '                    If e.FormattedValue.ToString.Length <> 4 Then
    '                        e.Cancel = True
    '                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChecknamLenHon4", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '                        'Exit Sub
    '                    End If
    '                End If
    '            End If
    '        ElseIf e.RowIndex < grdNganSach.RowCount - 1 Then
    '            ' Năm không được rỗng ! 
    '            e.Cancel = True
    '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheck02", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '            grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True

    '        End If
    '    End If
    '    ''
    '    'If e.ColumnIndex = 2 Then
    '    '    If e.FormattedValue <> "" Then
    '    '        If Not IsNumeric(e.FormattedValue) Then
    '    '            ' Số tiền phải là kiểu số !
    '    '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheck03", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '            e.Cancel = True
    '    '        Else
    '    '            If e.FormattedValue < 0 Then
    '    '                ' Số tiền phải lớn hơn hoặc bằng 0 !
    '    '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChecksotien", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '                e.Cancel = True
    '    '            Else
    '    '                Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value
    '    '            End If
    '    '        End If
    '    '    Else
    '    '        ' Số tiền không được rỗng ! 
    '    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheck04", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
    '    '        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
    '    '        e.Cancel = True
    '    '    End If
    '    'End If

    '    ' ''
    '    'If e.ColumnIndex = 3 Then
    '    '    Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value = New BO_PHAN_CHIU_PHIController().GetTI_GIA(e.FormattedValue)
    '    '    Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = _
    '    '            grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value * grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value
    '    'End If
    '    'If e.ColumnIndex = 5 Then
    '    '    If e.FormattedValue.Equals("") = False Then
    '    '        If Not IsNumeric(e.FormattedValue) Then
    '    '            'MessageBox.Show ("tỷ giá phải là kiểu số")
    '    '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheckTyGia", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '            grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
    '    '            e.Cancel = True
    '    '        Else
    '    '            If e.FormattedValue < 0 Then
    '    '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheckTyGia", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '                grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
    '    '                e.Cancel = True
    '    '            Else
    '    '                ' Nhớ kiểm tra sai kiểu dữ liệu và số âm.
    '    '                Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value
    '    '            End If

    '    '        End If
    '    '    Else
    '    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheckTyGiaNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
    '    '        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
    '    '        e.Cancel = True
    '    '        'Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = 0
    '    '    End If
    '    'End If
    'End Sub
    Private Sub grdNganSach_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdNganSach.DefaultValuesNeeded
        With e.Row
            .Cells("MS_BP_CHIU_PHI").Value = Me.txtMS_BP_CHIU_PHI.Text
            .Cells("THANG").Value = Date.Now
            .Cells("SO_TIEN").Value = 0
            .Cells("THANH_TIEN").Value = 0
            .Cells("THANH_TIEN_USD").Value = 0
            .Cells("NGOAI_TE").Value = System.DBNull.Value
            .Cells("TY_GIA").Value = 0
            .Cells("TY_GIA_USD").Value = 0
        End With
    End Sub
    Private Sub grdNganSach_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdNganSach.UserDeletingRow
        'If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoaKinhPhi", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, Me.Text) = MsgBoxResult.No Then
        '    e.Cancel = True
        '    Exit Sub
        'End If
        Dim objKINH_PHI_NAMController As New KINH_PHI_NAMController
        'Xác nhận xóa
        If MS_KPN = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNO_NGAN_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXOA_NGAN_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If
        objKINH_PHI_NAMController.DeleteKINH_PHI_NAM_CS(MS_KPN, THANG_KPN, MS_LOAI_CP, Me.Name)
        If Me.grdDanhSach.RowCount > 0 Then
            ShowBoPhanChiuPhi(Me.grdDanhSach.CurrentRow.Index)
        End If
        e.Cancel = True
    End Sub
    Private Sub btnChiTiet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isValidated() Then
            'Save BoPhanChiuPhi and allow add/Edit grdNganSach
            AddBoPhanChiuPhi()
            BindData()
            LockData(False)
            'When user click detail, we lock add, unlock edit for Bo Phan Chiu Phi 
            blnThem = False
            grdDanhSach.Rows(grdDanhSach.RowCount - 1).Cells("TEN_BP_CHIU_PHI").Selected = True
        End If
    End Sub
    Private Sub grdNganSach_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdNganSach.DataError
        If BtnKhongghi.Focused Then
            e.Cancel = False
            Me.grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
            Exit Sub
        End If
        If e.Context = DataGridViewDataErrorContexts.Commit And e.RowIndex < grdNganSach.RowCount - 1 And Not BtnKhongghi.Focused Then
            If grdNganSach.Rows(e.RowIndex).Cells("THANG").Value.ToString = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSAME_DATA1", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
                Me.grdNganSach.CurrentRow.Cells("THANG").Selected = True
                e.Cancel = True
            Else
                Try
                    Dim vTHANG As Date = Convert.ToDateTime(Me.grdNganSach.CurrentRow.Cells("THANG").Value)
                Catch ex As Exception
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSAME_DATA", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
                    Me.grdNganSach.CurrentRow.Cells("THANG").Selected = True
                    e.Cancel = True
                End Try

            End If

        End If

    End Sub
    Private Sub grdNganSach_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdNganSach.RowHeaderMouseClick
        Try


            If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells("MS_BP_CHIU_PHI").Value) Then
                MS_KPN = Me.grdNganSach.Rows(e.RowIndex).Cells(0).Value
            Else
                MS_KPN = 0
            End If
            Try
                If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells("THANG").Value) Then
                    THANG_KPN = Convert.ToDateTime(Me.grdNganSach.Rows(e.RowIndex).Cells(1).Value)
                Else
                    THANG_KPN = Date.Now
                End If
            Catch ex As Exception
                THANG_KPN = Date.Now
            End Try
            If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells("MS_LOAI_CP").Value) Then
                MS_LOAI_CP = Me.grdNganSach.Rows(e.RowIndex).Cells(0).Value
            Else
                MS_LOAI_CP = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnTRO_VE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTRO_VE.Click
        VisibleButton(True)
        VisibleXOA(False)
        Me.grdDanhSach.Enabled = True
    End Sub
    Private Sub btnXOA_DANH_SACH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXOA_DANH_SACH.Click
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController
        If Integer.Parse(Me.txtMS_BP_CHIU_PHI.Text.Trim) = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNO_DANH_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If txtMS_BP_CHIU_PHI.Text = 3 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDuLieuMacDinh", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If Me.grdNganSach.Rows.Count > 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDATA_NGAN_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        'Kiểm tra dữ liệu có được dùng trong các bảng khác hay không
        If objBPCPController.CheckUsedBPCP_KINH_PHI_NAM(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If objBPCPController.CheckUsedBPCP_MAY(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        'Xác nhận xóa
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then Exit Sub
        objBPCPController.DeleteBO_PHAN_CHIU_PHI(Me.txtMS_BP_CHIU_PHI.Text.Trim, Me.Name)
        Refesh()
        Dim tmp As Integer = RETURN_ROW
        BindData()
        If grdDanhSach.Rows.Count > 0 Then
            If grdDanhSach.Rows.Count = tmp Then
                grdDanhSach.CurrentCell() = grdDanhSach.Rows(tmp - 1).Cells("TEN_BP_CHIU_PHI")
                grdDanhSach.Focus()
            Else
                grdDanhSach.CurrentCell() = grdDanhSach.Rows(tmp).Cells("TEN_BP_CHIU_PHI")
                grdDanhSach.Focus()
            End If
        End If

    End Sub
    Private Sub btnXOA_NGAN_SACH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXOA_NGAN_SACH.Click
        Dim objKINH_PHI_NAMController As New KINH_PHI_NAMController
        'Xác nhận xóa
        If MS_KPN = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNO_NGAN_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXOA_NGAN_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then Exit Sub
        objKINH_PHI_NAMController.DeleteKINH_PHI_NAM_CS(MS_KPN, THANG_KPN, MS_LOAI_CP, Me.Name)
        If Me.grdDanhSach.RowCount > 0 Then
            ShowBoPhanChiuPhi(Me.grdDanhSach.CurrentRow.Index)
        End If
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        txtTEN_BP_CHIU_PHI.Text = ""
        txtMS_BP_CHIU_PHI.Text = 0
        txtGHI_CHU.Text = ""
        cmbMSDV.SelectedIndex = -1
    End Sub

    Sub ShowBoPhanChiuPhi(ByVal RowIndex As Integer)
        Me.txtMS_BP_CHIU_PHI.Text = Me.grdDanhSach.Rows(RowIndex).Cells("MS_BP_CHIU_PHI").Value
        Me.txtTEN_BP_CHIU_PHI.Text = Me.grdDanhSach.Rows(RowIndex).Cells("TEN_BP_CHIU_PHI").Value
        Me.lblOLD_TEN_BP_CP.Text = Me.grdDanhSach.Rows(RowIndex).Cells("TEN_BP_CHIU_PHI").Value
        Me.txtGHI_CHU.Text = Me.grdDanhSach.Rows(RowIndex).Cells("GHI_CHU").Value.ToString
        Me.cmbMSDV.SelectedValue = Me.grdDanhSach.Rows(RowIndex).Cells("MSDV").Value
        If Me.grdDanhSach.Columns.Count > 0 Then
            Me.grdNganSach.Columns.Clear()
        End If
        Dim row As Integer = intRowNS
        Me.grdNganSach.DataSource = New KINH_PHI_NAMController().GetKINH_PHI_NAM_CS(Me.txtMS_BP_CHIU_PHI.Text.Trim)
        If Me.grdNganSach.Rows.Count > 0 Then
            Me.btnXOA_NGAN_SACH.Enabled = True
            If grdNganSach.Rows.Count = row Then
                grdNganSach.CurrentCell() = Me.grdNganSach.Rows(row - 1).Cells("THANG")
            Else
                grdNganSach.CurrentCell() = Me.grdNganSach.Rows(row).Cells("THANG")
            End If
        Else
            Me.btnXOA_NGAN_SACH.Enabled = False
        End If

        Me.grdNganSach.Columns("MS_BP_CHIU_PHI").Visible = False
        Me.grdNganSach.Columns("NGOAI_TE").Visible = False
        Me.grdNganSach.Columns("MS_LOAI_CP").Visible = False
        Me.grdNganSach.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        Me.grdNganSach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Me.grdNganSach.Columns("SO_TIEN").DefaultCellStyle.Format = "#,##0.00"
        Me.grdNganSach.Columns("THANG").DefaultCellStyle.Format = "MM/yyyy"
        Me.grdNganSach.Columns("TY_GIA").DefaultCellStyle.Format = "#,##0.00000"
        Me.grdNganSach.Columns("TY_GIA_USD").DefaultCellStyle.Format = "#,##0.00000"
        Me.grdNganSach.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,##0.00"
        Me.grdNganSach.Columns("THANH_TIEN_USD").DefaultCellStyle.Format = "#,##0.00"

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.Name = "NGOAI_TE"
        comboBoxColumn.ValueMember = "NGOAI_TE"
        comboBoxColumn.DisplayMember = "NGOAI_TE"
        comboBoxColumn.DataPropertyName = "NGOAI_TE"
        comboBoxColumn.DataSource = New NGOAI_TEController().GetNGOAI_TEs
        Me.grdNganSach.Columns.Insert(3, comboBoxColumn)

        Dim comboBoxColumn_LOAI_CP As New DataGridViewComboBoxColumn()
        comboBoxColumn_LOAI_CP.Name = "MS_LOAI_CP"
        comboBoxColumn_LOAI_CP.ValueMember = "MS_LOAI_CP"
        comboBoxColumn_LOAI_CP.DisplayMember = "TEN_CP"
        comboBoxColumn_LOAI_CP.DataPropertyName = "MS_LOAI_CP"
        Dim tbLoaiCP As DataTable = New DataTable()
        tbLoaiCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.StoredProcedure, "GET_LOAI_CP"))
        comboBoxColumn_LOAI_CP.DataSource = tbLoaiCP
        Me.grdNganSach.Columns.Insert(0, comboBoxColumn_LOAI_CP)

        Me.grdNganSach.Columns("MS_LOAI_CP").Width = 180
        Me.grdNganSach.Columns("THANG").Width = 85
        Me.grdNganSach.Columns("NGOAI_TE").Width = 78
        Me.grdNganSach.Columns("TY_GIA").Width = 80
        Me.grdNganSach.Columns("TY_GIA_USD").Width = 80
        Me.grdNganSach.Columns("THANH_TIEN").Width = 120
        Me.grdNganSach.Columns("THANH_TIEN_USD").Width = 120
        Language_KPN()
    End Sub
    Sub RefreshBoPhanChiuPhi()
        If Me.grdDanhSach.Columns.Count > 0 Then
            Me.grdNganSach.Columns.Clear()
        End If
        Me.grdNganSach.DataSource = New KINH_PHI_NAMController().GetKINH_PHI_NAM_CS(Me.txtMS_BP_CHIU_PHI.Text.Trim)
        grdNganSach.Columns("MS_BP_CHIU_PHI").Visible = False
        grdNganSach.Columns("MS_LOAI_CP").Visible = False
        grdNganSach.Columns("THANG").DefaultCellStyle.Format = "MM/yyyy"
        grdNganSach.Columns("NGOAI_TE").Visible = False

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.Name = "NGOAI_TE"
        comboBoxColumn.ValueMember = "NGOAI_TE"
        comboBoxColumn.DisplayMember = "NGOAI_TE"
        comboBoxColumn.DataPropertyName = "NGOAI_TE"
        comboBoxColumn.DataSource = New NGOAI_TEController().GetNGOAI_TEs
        grdNganSach.Columns.Insert(3, comboBoxColumn)

        Dim comboBoxColumn_LOAI_CP As New DataGridViewComboBoxColumn()
        comboBoxColumn_LOAI_CP.Name = "MS_LOAI_CP"
        comboBoxColumn_LOAI_CP.ValueMember = "MS_LOAI_CP"
        comboBoxColumn_LOAI_CP.DisplayMember = "TEN_CP"
        comboBoxColumn_LOAI_CP.DataPropertyName = "MS_LOAI_CP"
        Dim tbLoaiCP As DataTable = New DataTable()
        tbLoaiCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.StoredProcedure, "GET_LOAI_CP"))
        comboBoxColumn_LOAI_CP.DataSource = tbLoaiCP
        Me.grdNganSach.Columns.Insert(0, comboBoxColumn_LOAI_CP)

        Me.grdNganSach.Columns("THANG").Width = 85
        Me.grdNganSach.Columns("NGOAI_TE").Width = 78
        Me.grdNganSach.Columns("TY_GIA").Width = 80
        Me.grdNganSach.Columns("TY_GIA_USD").Width = 80
        Me.grdNganSach.Columns("THANH_TIEN").Width = 120
        Me.grdNganSach.Columns("THANH_TIEN_USD").Width = 120
        'Me.grdNganSach.Columns("TONG_CP_BT").Width = 130
        Language_KPN()
    End Sub

    Sub Language_KPN()
        Me.grdNganSach.Columns("MS_LOAI_CP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOAI_CP", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("THANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NAM", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("THANG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdNganSach.Columns("SO_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_TIEN", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("SO_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdNganSach.Columns("NGOAI_TE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGOAI_TE", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("TY_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TY_GIA", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("TY_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdNganSach.Columns("TY_GIA_USD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TY_GIA_USD", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("TY_GIA_USD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdNganSach.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANH_TIEN", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdNganSach.Columns("THANH_TIEN_USD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANH_TIEN_USD", commons.Modules.TypeLanguage)
        Me.grdNganSach.Columns("THANH_TIEN_USD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Sub BindData()
        Try
            Me.grdDanhSach.DataSource = New BO_PHAN_CHIU_PHIController().GetBO_PHAN_CHIU_PHIs()
            Me.grdDanhSach.Columns("MS_BP_CHIU_PHI").Visible = False
            Me.grdDanhSach.Columns("GHI_CHU").Visible = False
            Me.grdDanhSach.Columns("LOAI_CHI_PHI").Visible = False
            Me.grdDanhSach.Columns("MSDV").Visible = False
            Try
                Me.grdDanhSach.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdDanhSach.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception

            End Try

            grdDanhSach.Select()
            If grdDanhSach.RowCount > 0 Then
                BtnSua.Enabled = True
                'BtnXoa.Enabled = True
                btnXOA_DANH_SACH.Enabled = True
            Else
                BtnSua.Enabled = False
                'BtnXoa.Enabled = False
                btnXOA_DANH_SACH.Enabled = True
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindDataCombo()
        cmbMSDV.StoreName = "GetDON_VIs"
        cmbMSDV.Value = "MS_DON_VI"
        cmbMSDV.Display = "TEN_DON_VI"
        cmbMSDV.ClassName = "frmDanhmucdonvi"
        cmbMSDV.BindDataSource()
    End Sub
    Function isValidated()
        If Not txtTEN_BP_CHIU_PHI.IsValidated Then
            txtTEN_BP_CHIU_PHI.Focus()
            Return False
        End If
        If Not cmbMSDV.IsValidated Then
            cmbMSDV.Focus()
            Return False
        End If

        Return True
    End Function
    Sub AddBoPhanChiuPhi()
        Dim objBPCPInfo As New BO_PHAN_CHIU_PHIInfo
        Dim objKPNInfo As New KINH_PHI_NAMInfo
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController()
        Dim MS_BO_PHAN_CHIU_PHI As Integer
        Dim Sql As String
        objBPCPInfo.MS_BP_CHIU_PHI = Commons.Modules.ObjSystems.SplitString(Me.txtMS_BP_CHIU_PHI.Text.Trim)
        objBPCPInfo.TEN_BP_CHIU_PHI = Me.txtTEN_BP_CHIU_PHI.Text.Trim
        objBPCPInfo.MSDV = Me.cmbMSDV.SelectedValue
        objBPCPInfo.GHI_CHU = Me.txtGHI_CHU.Text.Trim

        grdNganSach.EndEdit()
        If Not blnThem Then
            If (objBPCPController.CheckBO_PHAN_CHIU_PHI(Commons.Modules.ObjSystems.SplitString(Me.txtMS_BP_CHIU_PHI.Text.Trim), Me.lblOLD_TEN_BP_CP.Text.Trim)).Read Then
                objBPCPController.InsertBO_PHAN_CHIU_PHI_LOG(objBPCPInfo.MS_BP_CHIU_PHI, Me.Name, Commons.Modules.UserName, 2)
                objBPCPController.UpdateBO_PHAN_CHIU_PHI(objBPCPInfo, Me.lblOLD_TEN_BP_CP.Text.Trim)
                'Cập nhật kinh phí năm theo bộ phận chịu phí 
                Dim vtb As New DataTable
                Sql = "select MS_LOAI_CP,THANG,MS_BP_CHIU_PHI from BUDGET where MS_BP_CHIU_PHI='" & txtMS_BP_CHIU_PHI.Text.Trim & "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
                For Each vr As DataRow In vtb.Rows
                    Sql = "exec UPDATE_BUDGET_LOG '" & vr("MS_LOAI_CP") & "','" & Format(CDate(vr("THANG")), "MM/dd/yyyy") & "','" & vr("MS_BP_CHIU_PHI") & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql)
                Next
                objKPNController.DeleteKINH_PHI_NAM_CSS(Me.txtMS_BP_CHIU_PHI.Text.Trim)
                For i As Integer = 0 To Me.grdNganSach.Rows.Count - 2
                    If Me.grdNganSach.Rows(i).Cells("MS_LOAI_CP").Value.ToString <> "" Then

                        objKPNInfo.MS_BP_CHIU_PHI = Me.txtMS_BP_CHIU_PHI.Text.Trim
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("MS_LOAI_CP").Value) Then
                            objKPNInfo.MS_LOAI_CP = Me.grdNganSach.Rows(i).Cells("MS_LOAI_CP").Value
                        Else
                            objKPNInfo.MS_LOAI_CP = Nothing
                        End If
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANG").Value) Then
                            objKPNInfo.THANG = Convert.ToDateTime(Me.grdNganSach.Rows(i).Cells("THANG").Value)
                        Else
                            objKPNInfo.THANG = Nothing
                        End If
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("SO_TIEN").Value) Then
                            objKPNInfo.SO_TIEN = Me.grdNganSach.Rows(i).Cells("SO_TIEN").Value
                        Else
                            objKPNInfo.SO_TIEN = Nothing
                        End If
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("NGOAI_TE").Value) Then
                            objKPNInfo.NGOAI_TE = Me.grdNganSach.Rows(i).Cells("NGOAI_TE").Value
                        Else
                            objKPNInfo.NGOAI_TE = Nothing
                        End If
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("TY_GIA").Value) Then
                            objKPNInfo.TY_GIA = Me.grdNganSach.Rows(i).Cells("TY_GIA").Value
                        Else
                            objKPNInfo.TY_GIA = Nothing
                        End If
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("TY_GIA_USD").Value) Then
                            objKPNInfo.TY_GIA_USD = Me.grdNganSach.Rows(i).Cells("TY_GIA_USD").Value
                        Else
                            objKPNInfo.TY_GIA_USD = Nothing
                        End If
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value) Then
                            objKPNInfo.THANH_TIEN = Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value
                        Else
                            objKPNInfo.THANH_TIEN = Nothing
                        End If
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANH_TIEN_USD").Value) Then
                            objKPNInfo.THANH_TIEN_USD = Me.grdNganSach.Rows(i).Cells("THANH_TIEN_USD").Value
                        Else
                            objKPNInfo.THANH_TIEN_USD = Nothing
                        End If
                        objKPNController.AddKINH_PHI_NAM_CS(objKPNInfo)
                        Sql = "exec UPDATE_BUDGET_LOG '" & objKPNInfo.MS_LOAI_CP & "','" & Format(CDate(objKPNInfo.THANG), "MM/dd/yyy") & "','" & objKPNInfo.MS_BP_CHIU_PHI & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql)
                    End If
                Next
            Else
                If (objBPCPController.CheckTEN_BP_CHIU_PHI(txtTEN_BP_CHIU_PHI.Text.Trim)).Read Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSameName", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                    LOAD_GRID = 2
                    Me.txtTEN_BP_CHIU_PHI.Focus()
                    Me.txtTEN_BP_CHIU_PHI.SelectAll()
                    Exit Sub
                End If
            End If
        Else
            If (objBPCPController.CheckTEN_BP_CHIU_PHI(txtTEN_BP_CHIU_PHI.Text.Trim)).Read Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSameName", commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                LOAD_GRID = 2
                Me.txtTEN_BP_CHIU_PHI.Focus()
                Me.txtTEN_BP_CHIU_PHI.SelectAll()
                Exit Sub
            End If
            'Thêm bộ phận chịu phí và kinh phí năm cùng một lúc
            objBPCPInfo.MS_BP_CHIU_PHI = objBPCPController.AddBO_PHAN_CHIU_PHI(objBPCPInfo)
            objBPCPController.InsertBO_PHAN_CHIU_PHI_LOG(objBPCPInfo.MS_BP_CHIU_PHI, Me.Name, Commons.Modules.UserName, 1)
            MS_BO_PHAN_CHIU_PHI = New KINH_PHI_NAMController().GetADDED_MS_BP_CHIU_PHI()
            'Cập nhật kinh phí năm cho bộ phận chịu phí
            objBPCPInfo.MS_BP_CHIU_PHI = MS_BO_PHAN_CHIU_PHI
            For i As Integer = 0 To Me.grdNganSach.Rows.Count - 1
                If Not (Me.grdNganSach.Rows(i).Cells("MS_LOAI_CP").Value) Is Nothing Then
                    objKPNInfo.MS_BP_CHIU_PHI = MS_BO_PHAN_CHIU_PHI
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("MS_LOAI_CP").Value) Then
                        objKPNInfo.MS_LOAI_CP = Me.grdNganSach.Rows(i).Cells("MS_LOAI_CP").Value
                    Else
                        objKPNInfo.MS_LOAI_CP = Nothing
                    End If
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANG").Value) Then
                        objKPNInfo.THANG = Me.grdNganSach.Rows(i).Cells("THANG").Value
                    Else
                        objKPNInfo.THANG = Nothing
                    End If
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("SO_TIEN").Value) Then
                        objKPNInfo.SO_TIEN = Me.grdNganSach.Rows(i).Cells("SO_TIEN").Value
                    Else
                        objKPNInfo.SO_TIEN = Nothing
                    End If
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("NGOAI_TE").Value) Then
                        objKPNInfo.NGOAI_TE = Me.grdNganSach.Rows(i).Cells("NGOAI_TE").Value
                    Else
                        objKPNInfo.NGOAI_TE = Nothing
                    End If
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("TY_GIA").Value) Then
                        objKPNInfo.TY_GIA = Me.grdNganSach.Rows(i).Cells("TY_GIA").Value
                    Else
                        objKPNInfo.TY_GIA = Nothing
                    End If
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("TY_GIA_USD").Value) Then
                        objKPNInfo.TY_GIA_USD = Me.grdNganSach.Rows(i).Cells("TY_GIA_USD").Value
                    Else
                        objKPNInfo.TY_GIA_USD = Nothing
                    End If
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANH_TIEN_USD").Value) Then
                        objKPNInfo.THANH_TIEN_USD = Me.grdNganSach.Rows(i).Cells("THANH_TIEN_USD").Value
                    Else
                        objKPNInfo.THANH_TIEN_USD = Nothing
                    End If
                    If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value) Then
                        objKPNInfo.THANH_TIEN = Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value
                    Else
                        objKPNInfo.THANH_TIEN = Nothing
                    End If
                    objKPNController.AddKINH_PHI_NAM_CS(objKPNInfo)
                    Sql = "exec UPDATE_BUDGET_LOG '" & objKPNInfo.MS_LOAI_CP & "','" & objKPNInfo.THANG & "','" & objKPNInfo.MS_BP_CHIU_PHI & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql)
                End If
            Next
            If Me.grdDanhSach.Rows.Count > 0 Then
                Me.grdDanhSach.Rows(intPos).Cells("TEN_BP_CHIU_PHI").Selected = True
            End If
        End If
        LOAD_GRID = 1
        Refesh()
    End Sub
    Sub Delete()
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController()
        'Check data is used
        If objBPCPController.CheckUsedBPCP_KINH_PHI_NAM(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        'Check data is used
        If objBPCPController.CheckUsedBPCP_MAY(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        If DELETE_CON = 2 Then
            Dim objKINH_PHI_NAMController As New KINH_PHI_NAMController
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCHI_TIET", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.Yes Then
                If MS_KPN <> 0 And MS_LOAI_CP <> "" Then
                    objKINH_PHI_NAMController.DeleteKINH_PHI_NAM_CS(MS_KPN, THANG_KPN, MS_LOAI_CP, Me.Name)
                    For i As Integer = 0 To Me.grdDanhSach.Rows.Count - 1
                        Me.grdDanhSach.Rows(i).Selected = False
                    Next
                    Me.grdDanhSach.Rows(RETURN_ROW).Selected = True
                    ShowBoPhanChiuPhi(RETURN_ROW)
                    DELETE_CON = 1
                    Exit Sub
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If
        'Exist data in details
        If grdNganSach.RowCount > 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa3", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            For i As Integer = 0 To Me.grdDanhSach.Rows.Count - 1
                Me.grdDanhSach.Rows(i).Selected = False
            Next
            Me.grdNganSach.Rows(0).Selected = True
            For j As Integer = 0 To Me.grdNganSach.Rows.Count - 1
                If Me.grdNganSach.Rows(j).Selected = True Then
                    MS_KPN = Me.grdNganSach.Rows(j).Cells("MS_BP_CHIU_PHI").Value
                    THANG_KPN = Convert.ToDateTime(Me.grdNganSach.Rows(j).Cells("THANG").Value)
                End If
            Next
            DELETE_CON = 2
            Exit Sub
        End If

        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then Exit Sub
        objBPCPController.DeleteBO_PHAN_CHIU_PHI(txtMS_BP_CHIU_PHI.Text, Me.Name)
        BindData()
        DELETE_CON = 1
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        'BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub VisibleXOA(ByVal blnVisible As Boolean)
        Me.btnXOA_DANH_SACH.Visible = blnVisible
        Me.btnXOA_NGAN_SACH.Visible = blnVisible
        Me.btnTRO_VE.Visible = blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtGHI_CHU.ReadOnly = blnLock
        txtGHI_CHU.BackColor = Color.White
        txtTEN_BP_CHIU_PHI.ReadOnly = blnLock
        txtTEN_BP_CHIU_PHI.BackColor = Color.White
        cmbMSDV.Enabled = Not blnLock
        grdNganSach.AllowUserToDeleteRows = blnLock
        grdDanhSach.Enabled = blnLock

        If Me.txtMS_BP_CHIU_PHI.Text = "" Then Exit Sub
        grdNganSach.AllowUserToAddRows = Not blnLock
        grdNganSach.ReadOnly = blnLock
        If grdNganSach.ReadOnly = False Then
            AddHandler Me.grdNganSach.CellValidating, AddressOf Me.grdNganSach_CellValidating
        Else
            RemoveHandler grdNganSach.CellValidating, AddressOf Me.grdNganSach_CellValidating
        End If

        If blnLock Then
            If Me.grdDanhSach.RowCount > 0 Then
                grdNganSach.Columns("THANG").SortMode = DataGridViewColumnSortMode.Automatic
                grdNganSach.Columns("TY_GIA").SortMode = DataGridViewColumnSortMode.Automatic
                grdNganSach.Columns("TY_GIA_USD").SortMode = DataGridViewColumnSortMode.Automatic
                grdNganSach.Columns("THANH_TIEN").SortMode = DataGridViewColumnSortMode.Automatic
                grdNganSach.Columns("THANH_TIEN_USD").SortMode = DataGridViewColumnSortMode.Automatic
                grdNganSach.Columns("SO_TIEN").SortMode = DataGridViewColumnSortMode.Automatic
            End If
        Else
            If Me.grdDanhSach.RowCount > 0 Then
                grdNganSach.Columns("THANG").SortMode = DataGridViewColumnSortMode.NotSortable
                grdNganSach.Columns("TY_GIA").SortMode = DataGridViewColumnSortMode.NotSortable
                grdNganSach.Columns("TY_GIA_USD").SortMode = DataGridViewColumnSortMode.NotSortable
                grdNganSach.Columns("THANH_TIEN").SortMode = DataGridViewColumnSortMode.NotSortable
                grdNganSach.Columns("THANH_TIEN_USD").SortMode = DataGridViewColumnSortMode.NotSortable
                grdNganSach.Columns("SO_TIEN").SortMode = DataGridViewColumnSortMode.NotSortable
            End If
        End If
    End Sub
    Private Sub RefeshLanguage()
        Me.lblTieuDe.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTieuDe.Name, commons.Modules.TypeLanguage)
        Me.lblGHI_CHU.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblGHI_CHU.Name, commons.Modules.TypeLanguage)
        Me.lblMSDV.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblMSDV.Name, commons.Modules.TypeLanguage)
        Me.lblTEN_BP_CHIU_PHI.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTEN_BP_CHIU_PHI.Name, commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, Me.Name, commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnGhi.Name, commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnSua.Name, commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThem.Name, commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnThoat.Name, commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, BtnXoa.Name, commons.Modules.TypeLanguage)
        Me.btnXOA_DANH_SACH.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnXOA_DANH_SACH.Name, commons.Modules.TypeLanguage)
        Me.btnXOA_NGAN_SACH.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnXOA_NGAN_SACH.Name, commons.Modules.TypeLanguage)
        Me.btnTRO_VE.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, btnTRO_VE.Name, commons.Modules.TypeLanguage)
        Me.lblQuyDoi.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblQuyDoi.Name, commons.Modules.TypeLanguage) & " " & GetCurrencyValue()
        Me.lblCurrencyValue.Text = Me.lblQuyDoi.Text
        Me.grpDanhSach.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpDanhSach.Name, commons.Modules.TypeLanguage)
        Me.grpThongTin.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpThongTin.Name, commons.Modules.TypeLanguage)
        Me.grpNganSach.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, grpNganSach.Name, commons.Modules.TypeLanguage)
        Me.grdDanhSach.Columns("TEN_BP_CHIU_PHI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_BP_CHIU_PHI", commons.Modules.TypeLanguage)
    End Sub
    Function GetCurrencyValue()
        CURRENCY_VALUE = New BO_PHAN_CHIU_PHIController().GetGIA_TRI_NGOAI_TE()
        Return CURRENCY_VALUE
    End Function
#End Region
    Dim intRowNS As Integer
    Private Sub grdNganSach_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNganSach.RowEnter
        If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells("MS_BP_CHIU_PHI").Value) Then
            MS_KPN = Me.grdNganSach.Rows(e.RowIndex).Cells("MS_BP_CHIU_PHI").Value
        Else
            MS_KPN = 0
        End If
        Try
            If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells("THANG").Value) Then
                THANG_KPN = Convert.ToDateTime(Me.grdNganSach.Rows(e.RowIndex).Cells("THANG").Value)
            Else
                THANG_KPN = Date.Now
            End If
        Catch ex As Exception
            THANG_KPN = Date.Now
        End Try
        If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells("MS_LOAI_CP").Value) Then
            MS_LOAI_CP = Me.grdNganSach.Rows(e.RowIndex).Cells("MS_LOAI_CP").Value
        Else
            MS_LOAI_CP = ""
        End If
        intRowNS = e.RowIndex
    End Sub

    Sub HandleKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
            End If
        End If
    End Sub
    Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub
    Private Sub grdNganSach_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdNganSach.EditingControlShowing
        Try
            If Me.grdNganSach.CurrentCellAddress.X = 7 Or Me.grdNganSach.CurrentCellAddress.X = 8 Or Me.grdNganSach.CurrentCellAddress.X = 5 Then
                txtBaoTri = e.Control
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPress
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grdNganSach_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdNganSach.RowValidating
        If Me.BtnKhongghi.Focused Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If e.RowIndex < grdNganSach.Rows.Count - 1 Then
                If grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value = "0.00" Then
                    e.Cancel = True
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoTien", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdNganSach.CurrentCell() = grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN")
                    grdNganSach.Focus()
                ElseIf grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value = "0.00" Then
                    e.Cancel = True
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTyGia", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdNganSach.CurrentCell() = grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN")
                    grdNganSach.Focus()
                End If
            End If
        End If
    End Sub


    Private Sub grdDanhSach_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdDanhSach.UserDeletingRow
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController
        If Integer.Parse(Me.txtMS_BP_CHIU_PHI.Text.Trim) = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNO_DANH_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        If txtMS_BP_CHIU_PHI.Text = 3 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDuLieuMacDinh", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        If Me.grdNganSach.Rows.Count > 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDATA_NGAN_SACH", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        'Kiểm tra dữ liệu có được dùng trong các bảng khác hay không
        If objBPCPController.CheckUsedBPCP_KINH_PHI_NAM(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        If objBPCPController.CheckUsedBPCP_MAY(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa2", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        'Xác nhận xóa
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If


        objBPCPController.DeleteBO_PHAN_CHIU_PHI(Me.txtMS_BP_CHIU_PHI.Text.Trim, Me.Name)
        Refesh()
        Dim tmp As Integer = RETURN_ROW
        BindData()
        If grdDanhSach.Rows.Count > 0 Then
            If grdDanhSach.Rows.Count = tmp Then
                grdDanhSach.CurrentCell() = grdDanhSach.Rows(tmp - 1).Cells("TEN_BP_CHIU_PHI")
                grdDanhSach.Focus()
            Else
                grdDanhSach.CurrentCell() = grdDanhSach.Rows(tmp).Cells("TEN_BP_CHIU_PHI")
                grdDanhSach.Focus()
            End If
        End If
        e.Cancel = True
    End Sub
End Class