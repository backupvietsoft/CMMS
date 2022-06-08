
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin

Public Class frmBophanchiuphi

#Region "Private Member"
    Private objKPNController As New KINH_PHI_NAMController
    Private blnThem As Boolean
    Private intPos As Integer
    Private DELETE_CON As Integer = 1
    Private MS_KPN As Integer
    Private NAM_KPN As Integer
    Private RETURN_ROW As Integer
    Private LOAD_GRID As Integer = 1
    Private CURRENCY_VALUE As String

#End Region

#Region "Events form"
    Sub Them()
        If Me.grvDanhSach.RowCount > 0 Then
            intPos = grvDanhSach.FocusedRowHandle
        End If
        Refesh()
        RefreshBoPhanChiuPhi()
        VisibleButton(False)
        VisibleXOA(False)
        LockData(False)
        blnThem = True
        Try
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
        Catch ex As Exception

        End Try
        AddHandler grdNganSach.CellValidating, AddressOf Me.grdNganSach_CellValidating
    End Sub
    Sub Sua()
        If Me.grvDanhSach.RowCount > 0 Then
            intPos = Me.grvDanhSach.FocusedRowHandle
        End If
        VisibleButton(False)
        VisibleXOA(False)
        LockData(False)
        Me.grdNganSach.Focus()
        Me.grdNganSach.Rows(Me.grdNganSach.RowCount - 1).Cells("NAM").Selected = True

        Try
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
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
            grdNganSach.Rows(0).Cells("NAM").Selected = True
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
        If Me.grvDanhSach.RowCount > 0 Then
            Me.grvDanhSach.FocusedRowHandle = intPos
            ShowBoPhanChiuPhi()
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
                If Me.grvDanhSach.RowCount > 0 Then
                    Me.grvDanhSach.FocusedRowHandle = intPos
                End If
                While i < Me.grvDanhSach.RowCount
                    If Me.grvDanhSach.GetDataRow(i)("TEN_BP_CHIU_PHI") = TEMP Then
                        grvDanhSach.FocusedRowHandle = i
                        ShowBoPhanChiuPhi()
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
        'Commons.Modules.ObjSystems.MRemoveRow(TableLayoutPanel2)
        If Commons.Modules.iBBCPMail <> 1 Then Commons.Modules.ObjSystems.MRemoveRow(TableLayoutPanel2, 3)


        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Dim s As String
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
        ShowBoPhanChiuPhi()
        Language_KPN()

        s = Commons.Modules.PermisString
    End Sub

    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        If Me.grvDanhSach.RowCount > 0 Then
            intPos = grvDanhSach.FocusedRowHandle
        End If
        Refesh()
        RefreshBoPhanChiuPhi()
        VisibleButton(False)
        VisibleXOA(False)
        LockData(False)
        blnThem = True
        Try
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
        Catch ex As Exception

        End Try
        txtMA_BP_CHIU_PHI.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        Try
            If Me.grvDanhSach.RowCount > 0 Then
                intPos = Me.grvDanhSach.FocusedRowHandle
            End If
            VisibleButton(False)
            VisibleXOA(False)
            LockData(False)
            Me.grdNganSach.Focus()
            Me.grdNganSach.Rows(Me.grdNganSach.RowCount - 1).Cells("NAM").Selected = True
            grdNganSach.Columns("THANH_TIEN").ReadOnly = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        VisibleButton(False)
        VisibleXOA(True)
        Me.BtnXoa.Visible = False
        Me.BtnGhi.Visible = False
        Me.BtnKhongghi.Visible = False
        Me.grdDanhSach.Enabled = False
        If grdNganSach.RowCount > 0 Then
            grdNganSach.Focus()
            grdNganSach.Rows(0).Cells("NAM").Selected = True
        End If
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If isValidated() Then
            Dim i As Integer
            Dim TEMP As String = Me.txtTEN_BP_CHIU_PHI.Text.Trim().ToString() 'Commons.Modules.ObjSystems.SplitString(Me.txtTEN_BP_CHIU_PHI.Text.Trim())
            Dim sMail As String = ""
            Dim sBBCP As String = ""
            sBBCP = txtMS_BP_CHIU_PHI.Text
            If txtMail.Text.Trim <> "" Then
                If Not Commons.Modules.ObjSystems.MCheckEmail(txtMail.Text, sMail) Then
                    Commons.MssBox.Show(Me.Name, "msgKhongPhaiMail", Me.Text)
                    Exit Sub
                End If
                sMail = txtMail.Text
            End If

            AddBoPhanChiuPhi()
            If sMail <> "" Then
                Try
                    TEMP = "UPDATE  BO_PHAN_CHIU_PHI SET BPCP_MAIL = N'" & sMail & "' WHERE MS_BP_CHIU_PHI = " & sBBCP
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, TEMP)
                Catch ex As Exception

                End Try
            End If

            If LOAD_GRID = 1 Then
                BindData()
                blnThem = False
                VisibleButton(True)
                LockData(True)
                If Me.grvDanhSach.RowCount > 0 Then
                    Me.grvDanhSach.FocusedRowHandle = intPos
                End If
                While i < Me.grvDanhSach.RowCount
                    If Me.grvDanhSach.GetDataRow(i)("TEN_BP_CHIU_PHI") = TEMP Then
                        Me.grvDanhSach.FocusedRowHandle = i
                        ShowBoPhanChiuPhi()
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
        If Me.grvDanhSach.RowCount > 0 Then
            Me.grvDanhSach.FocusedRowHandle = intPos
            ShowBoPhanChiuPhi()
        End If
    End Sub
    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Commons.Modules.ObjSystems.Kiemtralaiphanquyen(Me.Name)
        Me.BtnXoa.Visible = True
        Me.Dispose()
    End Sub
    Private Sub grvDanhSach_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        ShowBoPhanChiuPhi()
        RETURN_ROW = e.RowIndex
    End Sub
    Private Sub grvDanhSach_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        ShowBoPhanChiuPhi()
        RETURN_ROW = e.RowIndex
    End Sub

    Private Sub grdNganSach_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdNganSach.CellValidating
        If Me.BtnKhongghi.Focused Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If e.RowIndex < grdNganSach.RowCount - 1 Then
                Me.grdNganSach.Columns("SO_TIEN").DefaultCellStyle.Format = "#,##0.00"
                Me.grdNganSach.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,##0.00"
                Me.grdNganSach.Columns("TONG_CP_BT").DefaultCellStyle.Format = "#,##0.00"
                Me.grdNganSach.Columns("TY_GIA").DefaultCellStyle.Format = "#,##0.0000"
                If grdNganSach.Columns(e.ColumnIndex).Name = "NAM" Then
                    Try
                        Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value = New BO_PHAN_CHIU_PHIController().GetTI_GIA(Me.grdNganSach.Rows(e.RowIndex).Cells("NGOAI_TE").Value)
                        Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value =
                                grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value * grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value
                    Catch ex As Exception

                    End Try
                    If e.FormattedValue <> "" Then
                        If Not IsNumeric(e.FormattedValue) Then
                            ' Năm phải là kiểu số !
                            Commons.MssBox.Show(Me.Name, "MsgCheck01", Me.Text)
                            grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                            e.Cancel = True
                        Else
                            If e.FormattedValue.ToString.Length <> 4 Then
                                e.Cancel = True
                                Commons.MssBox.Show(Me.Name, "MsgChecknamLenHon4", Me.Text)
                                Exit Sub
                            End If
                        End If
                    ElseIf e.RowIndex < grdNganSach.RowCount - 1 Then
                        ' Năm không được rỗng ! 
                        e.Cancel = True
                        Commons.MssBox.Show(Me.Name, "MsgCheck02", Me.Text)
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                    End If
                ElseIf grdNganSach.Columns(e.ColumnIndex).Name = "SO_TIEN" Then
                    If e.FormattedValue <> "" Then
                        If e.FormattedValue = 0 Then
                            e.Cancel = True
                            Commons.MssBox.Show(Me.Name, "MsgSoTien", Me.Text)
                        Else
                            Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value
                        End If
                    Else
                        'Số tiền không được rỗng ! 
                        Commons.MssBox.Show(Me.Name, "MsgCheck04", Me.Text)
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                        e.Cancel = True
                    End If
                ElseIf grdNganSach.Columns(e.ColumnIndex).Name = "NGOAI_TE" Then
                    Me.grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value = New BO_PHAN_CHIU_PHIController().GetTI_GIA(grdNganSach.Rows(e.RowIndex).Cells("NGOAI_TE").Value)
                    Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value =
                            grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value * grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value
                ElseIf grdNganSach.Columns(e.ColumnIndex).Name = "TY_GIA" Then
                    If e.FormattedValue.Equals("") = False Then
                        If e.FormattedValue = 0 Then
                            e.Cancel = True
                            Commons.MssBox.Show(Me.Name, "MsgTyGia", Me.Text)
                        Else
                            Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value
                        End If

                    Else
                        Commons.MssBox.Show(Me.Name, "MsgCheckTyGiaNull", Me.Text)
                        grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                        e.Cancel = True
                        'Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = 0
                    End If

                End If
            End If
        End If
    End Sub


    Private Sub grdNganSach_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdNganSach.DefaultValuesNeeded
        With e.Row
            .Cells("MS_BP_CHIU_PHI").Value = Me.txtMS_BP_CHIU_PHI.Text
            .Cells("SO_TIEN").Value = 0
            .Cells("THANH_TIEN").Value = 0
            .Cells("TONG_CP_BT").Value = ""
            .Cells("NGOAI_TE").Value = GetCurrencyValue()
            .Cells("TY_GIA").Value = 1
        End With
    End Sub
    Private Sub grdNganSach_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdNganSach.UserDeletingRow
        Dim objKINH_PHI_NAMController As New KINH_PHI_NAMController
        'Xác nhận xóa
        If MS_KPN = 0 Then
            Commons.MssBox.Show(Me.Name, "MsgNO_NGAN_SACH", Me.Text)
            Exit Sub
        End If

        If (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXOA_NGAN_SACH", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then
            e.Cancel = True
            Exit Sub
        End If
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_KINH_PHI_NAM_LOG", MS_KPN, NAM_KPN, Me.Name, Commons.Modules.UserName, 3)
        objKINH_PHI_NAMController.DeleteKINH_PHI_NAM(MS_KPN, NAM_KPN)
        If Me.grvDanhSach.RowCount > 0 Then
            ShowBoPhanChiuPhi()
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
            grvDanhSach.FocusedRowHandle = grvDanhSach.RowCount - 1
        End If
    End Sub
    Private Sub grdNganSach_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdNganSach.DataError
        If BtnKhongghi.Focused Then
            e.Cancel = False
            Me.grdNganSach.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
            Exit Sub
        End If
        If e.Context = DataGridViewDataErrorContexts.Commit And e.RowIndex < grdNganSach.RowCount - 1 And Not BtnKhongghi.Focused Then
            If grdNganSach.Rows(e.RowIndex).Cells("NAM").Value.ToString = "" Then
                Commons.MssBox.Show(Me.Name, "MsgSAME_DATA1", Me.Text)
                Me.grdNganSach.CurrentRow.Cells("NAM").Selected = True
                e.Cancel = True
            Else
                Commons.MssBox.Show(Me.Name, "MsgSAME_DATA", Me.Text)
                Me.grdNganSach.CurrentRow.Cells("NAM").Selected = True
                e.Cancel = True
            End If

        End If

    End Sub
    Private Sub grdNganSach_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdNganSach.RowHeaderMouseClick
        If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells(0).Value) Then
            MS_KPN = Me.grdNganSach.Rows(e.RowIndex).Cells(0).Value
        Else
            MS_KPN = 0
        End If
        If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells(1).Value) Then
            NAM_KPN = Me.grdNganSach.Rows(e.RowIndex).Cells(1).Value
        Else
            NAM_KPN = 0
        End If
    End Sub
    Private Sub btnTRO_VE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTRO_VE.Click
        VisibleButton(True)
        VisibleXOA(False)
        Me.grdDanhSach.Enabled = True
    End Sub
    Private Sub btnXOA_DANH_SACH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXOA_DANH_SACH.Click
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController
        If Integer.Parse(Me.txtMS_BP_CHIU_PHI.Text.Trim) = 0 Then
            Commons.MssBox.Show(Me.Name, "MsgNO_DANH_SACH", Me.Text)
            Exit Sub
        End If
        If txtMS_BP_CHIU_PHI.Text = 3 Then
            Commons.MssBox.Show(Me.Name, "MsgDuLieuMacDinh", Me.Text)
            Exit Sub
        End If
        If Me.grdNganSach.RowCount > 0 Then
            Commons.MssBox.Show(Me.Name, "MsgDATA_NGAN_SACH", Me.Text)
            Exit Sub
        End If
        'Kiểm tra dữ liệu có được dùng trong các bảng khác hay không
        If objBPCPController.CheckUsedBPCP_KINH_PHI_NAM(txtMS_BP_CHIU_PHI.Text) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa1", Me.Text)
            Exit Sub
        End If
        If objBPCPController.CheckUsedBPCP_MAY(txtMS_BP_CHIU_PHI.Text) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa2", Me.Text)
            Exit Sub
        End If
        'Xác nhận xóa
        If (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub


        Try
            objBPCPController.DeleteBO_PHAN_CHIU_PHI(Me.txtMS_BP_CHIU_PHI.Text.Trim, Me.Name)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try

        Refesh()
        Dim tmp As Integer = RETURN_ROW
        BindData()
        If grvDanhSach.RowCount > 0 Then
            If grvDanhSach.RowCount = tmp Then
                grvDanhSach.FocusedRowHandle = tmp - 1
            Else
                grvDanhSach.FocusedRowHandle = tmp
            End If
        End If
    End Sub

    Private Sub btnXOA_NGAN_SACH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXOA_NGAN_SACH.Click
        Dim objKINH_PHI_NAMController As New KINH_PHI_NAMController
        'Xác nhận xóa
        If MS_KPN = 0 Then
            Commons.MssBox.Show(Me.Name, "MsgNO_NGAN_SACH", Me.Text)
            Exit Sub
        End If
        If (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXOA_NGAN_SACH", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then Exit Sub
        objKINH_PHI_NAMController.DeleteKINH_PHI_NAM(MS_KPN, NAM_KPN)
        If Me.grvDanhSach.RowCount > 0 Then
            ShowBoPhanChiuPhi()
        End If
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        txtMA_BP_CHIU_PHI.Text = ""
        txtTEN_BP_CHIU_PHI.Text = ""
        txtMS_BP_CHIU_PHI.Text = 0
        txtGHI_CHU.Text = ""
        txtMail.Text = ""
        cmbLOAI_CHI_PHI.SelectedIndex = -1
        cmbMSDV.SelectedIndex = -1
        txtAccount.Text = ""
        txtSub.Text = ""
    End Sub

    Sub ShowBoPhanChiuPhi()
        Try
            Try
                Me.txtMS_BP_CHIU_PHI.Text = Me.grvDanhSach.GetFocusedDataRow()("MS_BP_CHIU_PHI")
            Catch ex As Exception
                txtMS_BP_CHIU_PHI.Text = ""
            End Try
            Try
                Me.txtMA_BP_CHIU_PHI.Text = Me.grvDanhSach.GetFocusedDataRow()("MA_BP_CHIU_PHI")
            Catch ex As Exception
                txtMA_BP_CHIU_PHI.Text = ""
            End Try
            Try
                Me.txtTEN_BP_CHIU_PHI.Text = Me.grvDanhSach.GetFocusedDataRow()("TEN_BP_CHIU_PHI")
            Catch ex As Exception
                txtTEN_BP_CHIU_PHI.Text = ""
            End Try
            Try
                Me.lblOLD_TEN_BP_CP.Text = Me.grvDanhSach.GetFocusedDataRow()("TEN_BP_CHIU_PHI")
            Catch ex As Exception
                lblOLD_TEN_BP_CP.Text = ""
            End Try
            Try
                Me.txtGHI_CHU.Text = Me.grvDanhSach.GetFocusedDataRow()("GHI_CHU").ToString
            Catch ex As Exception
                txtGHI_CHU.Text = ""
            End Try
            Try
                Me.txtMail.Text = Me.grvDanhSach.GetFocusedDataRow()("BPCP_MAIL").ToString
            Catch ex As Exception
                txtMail.Text = ""
            End Try
            Try
                Me.cmbLOAI_CHI_PHI.SelectedValue = Me.grvDanhSach.GetFocusedDataRow()("LOAI_CHI_PHI")
            Catch ex As Exception

            End Try
            Try
                Me.cmbMSDV.SelectedValue = Me.grvDanhSach.GetFocusedDataRow()("MSDV")
            Catch ex As Exception

            End Try
            Try
                txtAccount.Text = Me.grvDanhSach.GetFocusedDataRow()("ACCOUNT")
            Catch ex As Exception
                txtAccount.Text = ""
            End Try
            Try
                txtSub.Text = Me.grvDanhSach.GetFocusedDataRow()("SUB")
            Catch ex As Exception
                txtSub.Text = ""
            End Try

            If Me.grvDanhSach.Columns.Count > 0 Then
                Me.grdNganSach.Columns.Clear()
            End If
            Dim row As Integer = intRowNS
            Me.grdNganSach.DataSource = New KINH_PHI_NAMController().GetKINH_PHI_NAM(Me.txtMS_BP_CHIU_PHI.Text.Trim)
            If Me.grdNganSach.RowCount > 0 Then
                Me.btnXOA_NGAN_SACH.Enabled = True
                If grdNganSach.RowCount = row Then
                    grdNganSach.CurrentCell() = Me.grdNganSach.Rows(row - 1).Cells("NAM")
                Else
                    grdNganSach.CurrentCell() = Me.grdNganSach.Rows(row).Cells("NAM")
                End If
            Else
                Me.btnXOA_NGAN_SACH.Enabled = False
            End If

            Me.grdNganSach.Columns("MS_BP_CHIU_PHI").Visible = False
            Me.grdNganSach.Columns("NGOAI_TE").Visible = False

            Me.grdNganSach.Columns("SO_TIEN").DefaultCellStyle.Format = "#,##0.00"
            Me.grdNganSach.Columns("TY_GIA").DefaultCellStyle.Format = "#,##0.00000"
            Me.grdNganSach.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,##0.00"
            Me.grdNganSach.Columns("TONG_CP_BT").DefaultCellStyle.Format = "#,##0.00"

            Dim comboBoxColumn As New DataGridViewComboBoxColumn()
            comboBoxColumn.Name = "NGOAI_TE"
            comboBoxColumn.ValueMember = "NGOAI_TE"
            comboBoxColumn.DisplayMember = "NGOAI_TE"
            comboBoxColumn.DataPropertyName = "NGOAI_TE"
            comboBoxColumn.DataSource = New NGOAI_TEController().GetNGOAI_TEs
            Me.grdNganSach.Columns.Insert(3, comboBoxColumn)
            Me.grdNganSach.Columns("NAM").Width = 85
            Me.grdNganSach.Columns("NGOAI_TE").Width = 78
            Me.grdNganSach.Columns("TY_GIA").Width = 80
            Me.grdNganSach.Columns("THANH_TIEN").Width = 120
            Me.grdNganSach.Columns("TONG_CP_BT").Width = 130
            Language_KPN()
        Catch ex As Exception

        End Try

    End Sub
    Sub RefreshBoPhanChiuPhi()
        If Me.grvDanhSach.Columns.Count > 0 Then
            Me.grdNganSach.Columns.Clear()
        End If
        Me.grdNganSach.DataSource = New KINH_PHI_NAMController().GetKINH_PHI_NAM(Me.txtMS_BP_CHIU_PHI.Text.Trim)
        grdNganSach.Columns("MS_BP_CHIU_PHI").Visible = False
        grdNganSach.Columns("NGOAI_TE").Visible = False

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.Name = "NGOAI_TE"
        comboBoxColumn.ValueMember = "NGOAI_TE"
        comboBoxColumn.DisplayMember = "NGOAI_TE"
        comboBoxColumn.DataPropertyName = "NGOAI_TE"
        comboBoxColumn.DataSource = New NGOAI_TEController().GetNGOAI_TEs
        grdNganSach.Columns.Insert(3, comboBoxColumn)

        Me.grdNganSach.Columns("NAM").Width = 85
        Me.grdNganSach.Columns("NGOAI_TE").Width = 78
        Me.grdNganSach.Columns("TY_GIA").Width = 80
        Me.grdNganSach.Columns("THANH_TIEN").Width = 120
        Me.grdNganSach.Columns("TONG_CP_BT").Width = 130
        Language_KPN()
    End Sub

    Sub Language_KPN()
        Try
            Me.grdNganSach.Columns("NAM").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NAM", Commons.Modules.TypeLanguage)
            Me.grdNganSach.Columns("NAM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.grdNganSach.Columns("SO_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_TIEN", Commons.Modules.TypeLanguage)
            Me.grdNganSach.Columns("SO_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.grdNganSach.Columns("NGOAI_TE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGOAI_TE", Commons.Modules.TypeLanguage)
            Me.grdNganSach.Columns("TY_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA", Commons.Modules.TypeLanguage)
            Me.grdNganSach.Columns("TY_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.grdNganSach.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_TIEN", Commons.Modules.TypeLanguage)
            Me.grdNganSach.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.grdNganSach.Columns("TONG_CP_BT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TONG_CP_BT", Commons.Modules.TypeLanguage)
            Me.grdNganSach.Columns("TONG_CP_BT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception

        End Try

    End Sub
    Sub BindData()
        Try
            Dim dtTmp = New DataTable
            dtTmp = New BO_PHAN_CHIU_PHIController().GetBO_PHAN_CHIU_PHIs()

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDanhSach, grvDanhSach, New BO_PHAN_CHIU_PHIController().GetBO_PHAN_CHIU_PHIs(), False, False, True, True, True, "")

            Me.grvDanhSach.Columns("MS_BP_CHIU_PHI").Visible = False
            Me.grvDanhSach.Columns("MA_BP_CHIU_PHI").Visible = False

            Me.grvDanhSach.Columns("GHI_CHU").Visible = False
            Me.grvDanhSach.Columns("LOAI_CHI_PHI").Visible = False
            grvDanhSach.Columns("MSDV").Visible = False
            grvDanhSach.Columns("ACCOUNT").Visible = False
            grvDanhSach.Columns("SUB").Visible = False
            grvDanhSach.Columns("BPCP_MAIL").Visible = False

            ' Me.grvDanhSach.Columns("MA_BP_CHIU_PHI").Width = 100
            Try
                Me.grvDanhSach.Columns("ISIT").Visible = False
            Catch ex As Exception
            End Try


            If grvDanhSach.RowCount > 0 Then
                BtnSua.Enabled = True
                btnXOA_DANH_SACH.Enabled = True
            Else
                BtnSua.Enabled = False
                btnXOA_DANH_SACH.Enabled = True
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
        Catch ex As Exception
        End Try
        LocDuLieu()
    End Sub

    Sub BindDataCombo()
        cmbLOAI_CHI_PHI.StoreName = "GetLOAI_CHI_PHIs"
        cmbLOAI_CHI_PHI.Value = "LOAI_CHI_PHI"
        cmbLOAI_CHI_PHI.Display = "TEN_LOAI_CHI_PHI"
        cmbLOAI_CHI_PHI.ClassName = "frmLoaichiphi"
        cmbLOAI_CHI_PHI.BindDataSource()

        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VIs", Commons.Modules.UserName))
        cmbMSDV.ValueMember = "MS_DON_VI"
        cmbMSDV.DisplayMember = "TEN_DON_VI"
        cmbMSDV.DataSource = dt

        Dim dt1 As New DataTable()
        dt1 = dt.Copy()
        cboDVLoc.ValueMember = "MS_DON_VI"
        cboDVLoc.DisplayMember = "TEN_DON_VI"
        cboDVLoc.DataSource = dt1
    End Sub
    Function isValidated()
        If Not txtMA_BP_CHIU_PHI.IsValidated Then
            txtMA_BP_CHIU_PHI.Focus()
            Return False
        End If
        If Not txtTEN_BP_CHIU_PHI.IsValidated Then
            txtTEN_BP_CHIU_PHI.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cmbLOAI_CHI_PHI.Text.Trim()) Then
            cmbLOAI_CHI_PHI.DroppedDown = True
            Return False
        End If
        If String.IsNullOrEmpty(cmbMSDV.Text.Trim()) Then
            cmbMSDV.DroppedDown = True
            Return False
        End If

        Return True
    End Function
    Sub AddBoPhanChiuPhi()
        Dim objBPCPInfo As New BO_PHAN_CHIU_PHIInfo
        Dim objKPNInfo As New KINH_PHI_NAMInfo
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController()
        Dim MS_BO_PHAN_CHIU_PHI As Integer
        Dim sql As String
        objBPCPInfo.MS_BP_CHIU_PHI = Me.txtMS_BP_CHIU_PHI.Text.Trim.ToString
        objBPCPInfo.MA_BP_CHIU_PHI = Me.txtMA_BP_CHIU_PHI.Text.Trim.ToString
        objBPCPInfo.TEN_BP_CHIU_PHI = Me.txtTEN_BP_CHIU_PHI.Text.Trim().ToString() 'Commons.Modules.ObjSystems.SplitString(Me.txtTEN_BP_CHIU_PHI.Text.Trim)
        objBPCPInfo.LOAI_CHI_PHI = Me.cmbLOAI_CHI_PHI.SelectedValue
        objBPCPInfo.MSDV = Me.cmbMSDV.SelectedValue.ToString
        objBPCPInfo.GHI_CHU = Me.txtGHI_CHU.Text.Trim
        objBPCPInfo.ACCOUNT = Me.txtAccount.Text.Trim
        objBPCPInfo.SUBS = Me.txtSub.Text.Trim
        Try
            If Not blnThem Then

                If (objBPCPController.CheckBO_PHAN_CHIU_PHI_MA(Me.txtMS_BP_CHIU_PHI.Text.Trim, Me.txtMA_BP_CHIU_PHI.Text.Trim)).Read = False Then
                    If (objBPCPController.CheckMA_BP_CHIU_PHI(txtMA_BP_CHIU_PHI.Text.Trim)).Read Then
                        Commons.MssBox.Show(Me.Name, "msgMaSoBPCPDaTonTai", Me.Text)
                        LOAD_GRID = 2
                        Me.txtMA_BP_CHIU_PHI.Focus()
                        Me.txtMA_BP_CHIU_PHI.SelectAll()
                        Exit Sub
                    Else
                        GoTo 1
                    End If
                Else
1:
                    If (objBPCPController.CheckBO_PHAN_CHIU_PHI(Me.txtMS_BP_CHIU_PHI.Text.Trim, Me.txtTEN_BP_CHIU_PHI.Text.Trim)).Read Then
2:
                        objBPCPController.InsertBO_PHAN_CHIU_PHI_LOG(objBPCPInfo.MS_BP_CHIU_PHI, Me.Name, Commons.Modules.UserName, 2)
                        objBPCPController.UpdateBO_PHAN_CHIU_PHI(objBPCPInfo, Me.lblOLD_TEN_BP_CP.Text.Trim)

                        Try
                            sql = "UPDATE  BO_PHAN_CHIU_PHI SET BPCP_MAIL = N'" & txtMail.Text & "' WHERE MS_BP_CHIU_PHI = " & txtMS_BP_CHIU_PHI.Text
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                        Catch ex As Exception
                        End Try

                        'Cập nhật kinh phí năm theo bộ phận chịu phí 
                        Try
                            Dim tb As New DataTable

                            sql = "select MS_BP_CHIU_PHI,NAM,SO_TIEN,NGOAI_TE,TY_GIA,THANH_TIEN from KINH_PHI_NAM where MS_BP_CHIU_PHI ='" & Me.txtMS_BP_CHIU_PHI.Text.Trim & "'"
                            'tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, sql).Tables(0)
                            tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                            For Each vr As DataRow In tb.Rows
                                sql = "exec UPDATE_KINH_PHI_NAM_LOG " & vr("MS_BP_CHIU_PHI") & "," & vr("NAM") & ",'" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                            Next
                        Catch ex As Exception

                        End Try
                        objKPNController.DeleteKINH_PHI_NAMs(Me.txtMS_BP_CHIU_PHI.Text.Trim)
                        For i As Integer = 0 To Me.grdNganSach.RowCount - 2
                            If Me.grdNganSach.Rows(i).Cells(1).Value.ToString <> "" Then
                                objKPNInfo.MS_BP_CHIU_PHI = Me.txtMS_BP_CHIU_PHI.Text.Trim
                                If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("NAM").Value) Then
                                    objKPNInfo.NAM = Me.grdNganSach.Rows(i).Cells("NAM").Value
                                Else
                                    objKPNInfo.NAM = Nothing
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
                                If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value) Then
                                    objKPNInfo.THANH_TIEN = Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value
                                Else
                                    objKPNInfo.THANH_TIEN = Nothing
                                End If
                                objKPNController.AddKINH_PHI_NAM(objKPNInfo)
                                sql = "exec UPDATE_KINH_PHI_NAM_LOG " & objKPNInfo.MS_BP_CHIU_PHI & "," & objKPNInfo.NAM & ",'" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                            End If
                        Next
                    Else
                        If (objBPCPController.CheckTEN_BP_CHIU_PHI(txtTEN_BP_CHIU_PHI.Text.Trim)).Read Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSameName", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                            LOAD_GRID = 2
                            Me.txtTEN_BP_CHIU_PHI.Focus()
                            Me.txtTEN_BP_CHIU_PHI.SelectAll()
                            Exit Sub
                        Else
                            GoTo 2
                        End If
                    End If
                End If
            Else
                If (objBPCPController.CheckMA_BP_CHIU_PHI(txtMA_BP_CHIU_PHI.Text.Trim)).Read Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgMaSoBPCPDaTonTai", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                    LOAD_GRID = 2
                    Me.txtMA_BP_CHIU_PHI.Focus()
                    Me.txtMA_BP_CHIU_PHI.SelectAll()
                    Exit Sub
                End If


                If (objBPCPController.CheckTEN_BP_CHIU_PHI(txtTEN_BP_CHIU_PHI.Text.Trim)).Read Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSameName", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
                    LOAD_GRID = 2
                    Me.txtTEN_BP_CHIU_PHI.Focus()
                    Me.txtTEN_BP_CHIU_PHI.SelectAll()
                    Exit Sub
                End If
                'Thêm bộ phận chịu phí và kinh phí năm cùng một lúc


                objBPCPInfo.MS_BP_CHIU_PHI = objBPCPController.AddBO_PHAN_CHIU_PHI(objBPCPInfo)
                Try
                    sql = "UPDATE  BO_PHAN_CHIU_PHI SET BPCP_MAIL = N'" & txtMail.Text & "' WHERE MS_BP_CHIU_PHI = " & objBPCPInfo.MS_BP_CHIU_PHI
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                Catch ex As Exception

                End Try

                objBPCPController.InsertBO_PHAN_CHIU_PHI_LOG(objBPCPInfo.MS_BP_CHIU_PHI, Me.Name, Commons.Modules.UserName, 1)
                MS_BO_PHAN_CHIU_PHI = New KINH_PHI_NAMController().GetADDED_MS_BP_CHIU_PHI()
                'Cập nhật kinh phí năm cho bộ phận chịu phí
                objBPCPInfo.MS_BP_CHIU_PHI = MS_BO_PHAN_CHIU_PHI
                For i As Integer = 0 To Me.grdNganSach.RowCount - 1
                    If Not (Me.grdNganSach.Rows(i).Cells(1).Value) Is Nothing Then
                        objKPNInfo.MS_BP_CHIU_PHI = MS_BO_PHAN_CHIU_PHI
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("NAM").Value) Then
                            objKPNInfo.NAM = Me.grdNganSach.Rows(i).Cells("NAM").Value
                        Else
                            objKPNInfo.NAM = Nothing
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
                        If Not IsDBNull(Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value) Then
                            objKPNInfo.THANH_TIEN = Me.grdNganSach.Rows(i).Cells("THANH_TIEN").Value
                        Else
                            objKPNInfo.THANH_TIEN = Nothing
                        End If
                        objKPNController.AddKINH_PHI_NAM(objKPNInfo)
                        sql = "exec UPDATE_KINH_PHI_NAM_LOG " & objKPNInfo.MS_BP_CHIU_PHI & "," & objKPNInfo.NAM & ",'" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                    End If
                Next
                If Me.grvDanhSach.RowCount > 0 Then
                    Me.grvDanhSach.FocusedRowHandle = intPos
                End If
            End If
            LOAD_GRID = 1
        Catch ex As Exception
            LOAD_GRID = 2
        End Try
        Refesh()
    End Sub
    Sub Delete()
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController()
        'Check data is used
        If objBPCPController.CheckUsedBPCP_KINH_PHI_NAM(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        'Check data is used
        If objBPCPController.CheckUsedBPCP_MAY(txtMS_BP_CHIU_PHI.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        If DELETE_CON = 2 Then
            Dim objKINH_PHI_NAMController As New KINH_PHI_NAMController
            If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCHI_TIET", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.Yes Then
                If MS_KPN <> 0 And NAM_KPN <> 0 Then
                    objKINH_PHI_NAMController.DeleteKINH_PHI_NAM(MS_KPN, NAM_KPN)

                    Me.grvDanhSach.FocusedRowHandle = RETURN_ROW
                    ShowBoPhanChiuPhi()
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Me.grvDanhSach.ClearSelection()
            Me.grdNganSach.Rows(0).Selected = True
                For j As Integer = 0 To Me.grdNganSach.RowCount - 1
                If Me.grdNganSach.Rows(j).Selected = True Then
                    MS_KPN = Me.grdNganSach.Rows(j).Cells(0).Value
                    NAM_KPN = Me.grdNganSach.Rows(j).Cells(1).Value
                End If
            Next
            DELETE_CON = 2
            Exit Sub
        End If

        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text) = MsgBoxResult.No Then Exit Sub
        objBPCPController.DeleteBO_PHAN_CHIU_PHI(txtMS_BP_CHIU_PHI.Text, Me.Name)
        BindData()
        DELETE_CON = 1
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        Try
            BtnThem.Visible = blnVisible
            BtnSua.Visible = blnVisible
            BtnThoat.Visible = blnVisible
            BtnXoa.Visible = blnVisible
            BtnGhi.Visible = Not blnVisible
            BtnKhongghi.Visible = Not blnVisible
        Catch ex As Exception

        End Try
    End Sub
    Sub VisibleXOA(ByVal blnVisible As Boolean)
        Try
            Me.btnXOA_DANH_SACH.Visible = blnVisible
            Me.btnXOA_NGAN_SACH.Visible = blnVisible
            Me.btnTRO_VE.Visible = blnVisible
        Catch ex As Exception

        End Try
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        Try

            txtGHI_CHU.ReadOnly = blnLock
            txtGHI_CHU.BackColor = Color.White
            txtMail.ReadOnly = blnLock
            txtMail.BackColor = Color.White
            txtMA_BP_CHIU_PHI.ReadOnly = blnLock
            txtMA_BP_CHIU_PHI.BackColor = Color.White
            txtTEN_BP_CHIU_PHI.ReadOnly = blnLock
            txtTEN_BP_CHIU_PHI.BackColor = Color.White
            cmbLOAI_CHI_PHI.Enabled = Not blnLock
            cmbMSDV.Enabled = Not blnLock

            cboDVLoc.Enabled = blnLock
            txtTim.Enabled = blnLock

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
                If Me.grvDanhSach.RowCount > 0 Then
                    grdNganSach.Columns("NAM").SortMode = DataGridViewColumnSortMode.Automatic
                    grdNganSach.Columns("TY_GIA").SortMode = DataGridViewColumnSortMode.Automatic
                    grdNganSach.Columns("THANH_TIEN").SortMode = DataGridViewColumnSortMode.Automatic
                    grdNganSach.Columns("TONG_CP_BT").SortMode = DataGridViewColumnSortMode.Automatic
                    grdNganSach.Columns("SO_TIEN").SortMode = DataGridViewColumnSortMode.Automatic
                End If
            Else
                If Me.grvDanhSach.RowCount > 0 Then
                    grdNganSach.Columns("NAM").SortMode = DataGridViewColumnSortMode.NotSortable
                    grdNganSach.Columns("TY_GIA").SortMode = DataGridViewColumnSortMode.NotSortable
                    grdNganSach.Columns("THANH_TIEN").SortMode = DataGridViewColumnSortMode.NotSortable
                    grdNganSach.Columns("TONG_CP_BT").SortMode = DataGridViewColumnSortMode.NotSortable
                    grdNganSach.Columns("SO_TIEN").SortMode = DataGridViewColumnSortMode.NotSortable
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RefeshLanguage()
        'Me.lblTieuDe.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, lblTieuDe.Name, commons.Modules.TypeLanguage)
        Me.lblGHI_CHU.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblGHI_CHU.Name, Commons.Modules.TypeLanguage)
        Me.lblLOAI_CHI_PHI.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblLOAI_CHI_PHI.Name, Commons.Modules.TypeLanguage)
        Me.lblMSDV.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblMSDV.Name, Commons.Modules.TypeLanguage)
        Me.lblTEN_BP_CHIU_PHI.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTEN_BP_CHIU_PHI.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnGhi.Name, Commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, Commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnSua.Name, Commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThem.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnXoa.Name, Commons.Modules.TypeLanguage)
        Me.btnXOA_DANH_SACH.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnXOA_DANH_SACH.Name, Commons.Modules.TypeLanguage)
        Me.btnXOA_NGAN_SACH.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnXOA_NGAN_SACH.Name, Commons.Modules.TypeLanguage)
        Me.btnTRO_VE.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnTRO_VE.Name, Commons.Modules.TypeLanguage)
        Me.lblQuyDoi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblQuyDoi.Name, Commons.Modules.TypeLanguage) & " " & GetCurrencyValue()
        Me.lblCurrencyValue.Text = Me.lblQuyDoi.Text
        Me.grpDanhSach.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpDanhSach.Name, Commons.Modules.TypeLanguage)
        Me.grpThongTin.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpThongTin.Name, Commons.Modules.TypeLanguage)
        Me.grpNganSach.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpNganSach.Name, Commons.Modules.TypeLanguage)

        lblAccount.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ACCOUNT", Commons.Modules.TypeLanguage)
        lblSub.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SUB", Commons.Modules.TypeLanguage)

        lblMSCPhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblMSCPhi.Name, Commons.Modules.TypeLanguage)
        lblMail.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblMail.Name, Commons.Modules.TypeLanguage)


    End Sub
    Function GetCurrencyValue()
        Try
            CURRENCY_VALUE = New BO_PHAN_CHIU_PHIController().GetGIA_TRI_NGOAI_TE()
        Catch ex As Exception

        End Try
        Return CURRENCY_VALUE
    End Function
#End Region
    Dim intRowNS As Integer
    Private Sub grdNganSach_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNganSach.RowEnter
        If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells(0).Value) Then
            MS_KPN = Me.grdNganSach.Rows(e.RowIndex).Cells(0).Value
        Else
            MS_KPN = 0
        End If
        If Not IsDBNull(Me.grdNganSach.Rows(e.RowIndex).Cells(1).Value) Then
            NAM_KPN = Me.grdNganSach.Rows(e.RowIndex).Cells(1).Value
        Else
            NAM_KPN = 0
        End If
        intRowNS = e.RowIndex
    End Sub
    Dim txtBaoTri As TextBox
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
            If Me.grdNganSach.CurrentCellAddress.X = 1 Then
                txtBaoTri = e.Control
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPress
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPress
            ElseIf Me.grdNganSach.CurrentCellAddress.X = 2 Or Me.grdNganSach.CurrentCellAddress.X = 5 Then
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

    Private Sub cmbLOAI_CHI_PHI_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbLOAI_CHI_PHI.Validating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If cmbLOAI_CHI_PHI.SelectedValue Is Nothing Then
            If txtMA_BP_CHIU_PHI.Text <> "" And txtTEN_BP_CHIU_PHI.Text <> "" And Not cmbMSDV.SelectedValue Is Nothing Then
                e.Cancel = True
            End If
            cmbLOAI_CHI_PHI.Text = ""
        End If
    End Sub


    Private Sub grdNganSach_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdNganSach.RowValidating
        If Me.BtnKhongghi.Focused Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If e.RowIndex < grdNganSach.RowCount - 1 Then
                If grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN").Value = "0.00" Then
                    e.Cancel = True
                    Commons.MssBox.Show(Me.Name, "MsgSoTien", Me.Text)
                    grdNganSach.CurrentCell() = grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN")
                    grdNganSach.Focus()
                ElseIf grdNganSach.Rows(e.RowIndex).Cells("TY_GIA").Value = "0.00" Then
                    e.Cancel = True
                    Commons.MssBox.Show(Me.Name, "MsgTyGia", Me.Text)
                    grdNganSach.CurrentCell() = grdNganSach.Rows(e.RowIndex).Cells("SO_TIEN")
                    grdNganSach.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub grvDanhSach_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs)
        Dim objBPCPController As New BO_PHAN_CHIU_PHIController
        If Integer.Parse(Me.txtMS_BP_CHIU_PHI.Text.Trim) = 0 Then
            Commons.MssBox.Show(Me.Name, "MsgNO_DANH_SACH", Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        If txtMS_BP_CHIU_PHI.Text = 3 Then
            Commons.MssBox.Show(Me.Name, "MsgDuLieuMacDinh", Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        If Me.grdNganSach.RowCount > 0 Then
            Commons.MssBox.Show(Me.Name, "MsgDATA_NGAN_SACH", Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        'Kiểm tra dữ liệu có được dùng trong các bảng khác hay không
        If objBPCPController.CheckUsedBPCP_KINH_PHI_NAM(txtMS_BP_CHIU_PHI.Text) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa1", Me.Text)
            e.Cancel = True
            Exit Sub
        End If
        If objBPCPController.CheckUsedBPCP_MAY(txtMS_BP_CHIU_PHI.Text) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa2", Me.Text)
            e.Cancel = True
            Exit Sub
        End If

        'Xác nhận xóa
        If (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = vbNo Then
            e.Cancel = True
            Exit Sub
        End If


        objBPCPController.DeleteBO_PHAN_CHIU_PHI(Me.txtMS_BP_CHIU_PHI.Text.Trim, Me.Name)
        Refesh()
        Dim tmp As Integer = RETURN_ROW
        BindData()
        If grvDanhSach.RowCount > 0 Then
            If grvDanhSach.RowCount = tmp Then
                grvDanhSach.FocusedRowHandle = tmp - 1
            Else
                grvDanhSach.FocusedRowHandle = tmp
            End If
        End If
        e.Cancel = True
    End Sub


    Private Sub cboDVLoc_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDVLoc.SelectionChangeCommitted
        LocDuLieu()
    End Sub

    Private Sub txtTim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTim.TextChanged
        LocDuLieu()
    End Sub

    Private Sub LocDuLieu()
        Dim dtTmp = New DataTable
        Dim sStmp As String = ""
        Try
            dtTmp = CType(grdDanhSach.DataSource, DataTable)
            If cboDVLoc.SelectedValue <> "-1" Then sStmp = " AND (MSDV = '" & cboDVLoc.SelectedValue & "') "
            If txtTim.Text <> "" Then
                sStmp = sStmp & " AND ( (TEN_BP_CHIU_PHI LIKE '%" & txtTim.Text & "%') "
                sStmp = sStmp & " OR (ACCOUNT LIKE '%" & txtTim.Text & "%') "
                sStmp = sStmp & " OR (SUB LIKE '%" & txtTim.Text & "%') ) "
            End If
            If sStmp.Length > 1 Then
                dtTmp.DefaultView.RowFilter = sStmp.Substring(5)
            Else
                dtTmp.DefaultView.RowFilter = ""
            End If
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub

    Private Sub grvDanhSach_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDanhSach.FocusedRowChanged
        ShowBoPhanChiuPhi()
        RETURN_ROW = e.FocusedRowHandle

    End Sub
End Class