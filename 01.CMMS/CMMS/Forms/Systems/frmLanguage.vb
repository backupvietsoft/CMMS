
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors

Public Class frmLanguage
    Dim objDataTable As DataTable

    Private Sub frmLanguage_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub
    Private Sub frmLanguage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            BindData()
            Visiblebutton(True)

            EnableButton(False)
        Else
            EnableButton(True)

            BindData()
            Visiblebutton(True)
        End If
        AddHandler Me.VisibleChanged, AddressOf Me.frmLanguage_VisibleChanged
        ClsMain.SetLanguageForm(Me)
    End Sub

    Private Sub frmLanguage_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles Me.VisibleChanged
        If Me.Visible Then
            Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, Me.Name)
        End If
    End Sub

    Sub EnableButton(ByVal chon As Boolean)
        BtnSua.Enabled = chon
    End Sub
#Region "private"


    Sub BindData()
        Try

            Dim bform As Integer
            If optChon.SelectedIndex = 0 Then
                bform = -1
            End If
            If optChon.SelectedIndex = 1 Then
                bform = 0
            End If
            If optChon.SelectedIndex = 2 Then
                bform = 1
            End If

            Dim dt As New DataTable
            'dt = New clsLANGUAGEControllers().GetLANGUAGEs(Commons.Modules.TypeLanguage, bform)

            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetNNgu", Commons.Modules.TypeLanguage, bform))
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdForm, grvForm, dt, False, True, True, True, True, Me.Name)

            grvForm.Columns("FORM").Group()
            grvForm.OptionsView.ShowGroupPanel = True
            grvForm.Columns("FORM").Visible = False
            grvForm.OptionsView.ShowGroupPanel = False
            grvForm.OptionsCustomization.AllowGroup = False

            grvForm.ExpandAllGroups()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub Showdata(ByVal FORM As String)
        objDataTable = New clsLANGUAGEControllers().GetLANGUAGE_FORMs(FORM)
        objDataTable.Columns("KEYWORD").ReadOnly = True
        Commons.Modules.ObjSystems.MLoadXtraGrid(grdChiTiet, grvChiTiet, objDataTable, False, True, True, True, True, Me.Name)
        If FORM = "-1" Then grvChiTiet.Columns("FORM").Visible = True Else grvChiTiet.Columns("FORM").Visible = False

        grvChiTiet.Columns("STT").Visible = False
        grvChiTiet.Columns("MS_MODULE").Visible = False
        'grvChiTiet.Columns("KEYWORD").Visible = False
        'grvChiTiet.Columns("KEYWORD").ReadOnly = True
        grvChiTiet.Columns("CHINESE").Visible = False
        grvChiTiet.OptionsView.ColumnAutoWidth = True
    End Sub

    Sub Visiblebutton(ByVal chon As Boolean)
        BtnSua.Visible = chon
        BtnThoat.Visible = chon
        BtnGhi.Visible = Not chon
        BtnKhongghi.Visible = Not chon
        grvChiTiet.OptionsBehavior.Editable = Not chon
        'grdThongtinchitiet.ReadOnly = chon

        grdForm.Enabled = chon

        optCapNhap.Properties.ReadOnly = Not chon
        btnNNGoc.Visible = chon
        btnReplay.Visible = chon
        txtChuoi.Properties.ReadOnly = Not chon
        txtReplay.Properties.ReadOnly =Not chon

    End Sub
#End Region



    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        Dim sForm As String
        Try
            sForm = grvForm.GetFocusedRowCellValue("FORM").ToString
        Catch ex As Exception
            sForm = ""
        End Try
        Try
            If sForm = "" Then sForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("FORM"))
        Catch ex As Exception
            sForm = ""
        End Try
        Try
            If sForm = "-1" Then
                sForm = grvChiTiet.GetFocusedRowCellValue("FORM").ToString
            End If
        Catch ex As Exception
            sForm = ""
        End Try

        If sForm = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaChonFormCanChinhSua", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        Visiblebutton(False)

        optChon.Properties.ReadOnly = True
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Visiblebutton(True)
        Dim sForm As String
        Try
            sForm = grvForm.GetFocusedRowCellValue("FORM").ToString
        Catch ex As Exception
            sForm = ""
        End Try
        Try
            If sForm = "" Then sForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("FORM"))
        Catch ex As Exception
            sForm = ""
        End Try

        Showdata(sForm)
        optChon.Properties.ReadOnly = False
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Try
            Dim sForm As String
            Try
                sForm = grvForm.GetFocusedRowCellValue("FORM").ToString
            Catch ex As Exception
                sForm = ""
            End Try
            Try
                If sForm = "" Then sForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("FORM"))
            Catch ex As Exception
                sForm = ""
            End Try


            If sForm = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaChonFormCanChinhSua", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Dim objLanguageController As New clsLANGUAGEControllers()
            objLanguageController.UpdateData(objDataTable, sForm)
            Showdata(sForm)
            Visiblebutton(True)
            optChon.Properties.ReadOnly = False
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdThongtinchitiet_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

    End Sub

    Private Sub rdForm_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindData()
    End Sub

    Private Sub txtTK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTK.TextChanged
        Dim dtTmp As New DataTable
        dtTmp = CType(grdForm.DataSource, DataTable)
        Try
            If txtTK.Text <> "" Then
                dtTmp.DefaultView.RowFilter = "MENU like '%" & txtTK.Text & "%' or VIETNAM like '%" & txtTK.Text & "%' or FORM like '%" & txtTK.Text & "%'"
            Else
                dtTmp.DefaultView.RowFilter = ""
            End If
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try

    End Sub


    Private Sub grvForm_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvForm.FocusedRowChanged
        Try
            If grvForm.RowCount <= 0 Then
                Exit Sub
            End If
            Dim sForm As String
            Try
                sForm = grvForm.GetFocusedRowCellValue("FORM").ToString
            Catch ex As Exception
                sForm = ""
            End Try
            Try
                If sForm = "" Then sForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("FORM"))
            Catch ex As Exception
                sForm = ""
            End Try

            Showdata(sForm)
        Catch ex As Exception
            Showdata("")
        End Try
    End Sub

    Private Sub txtTim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTim.TextChanged
        Dim dtTmp As New DataTable
        dtTmp = CType(grdChiTiet.DataSource, DataTable)
        Try
            If txtTim.Text <> "" Then
                dtTmp.DefaultView.RowFilter = "VIETNAM like '%" & txtTim.Text & "%' OR KEYWORD like '%" & txtTim.Text & "%'   OR ENGLISH like '%" & txtTim.Text & "%'"
            Else
                dtTmp.DefaultView.RowFilter = ""
            End If
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
    End Sub

    Private Sub optChon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optChon.SelectedIndexChanged
        BindData()
    End Sub

    Private Sub btnNNGoc_Click(sender As Object, e As EventArgs) Handles btnNNGoc.Click
        Dim sForm As String
        Try
            sForm = grvForm.GetFocusedRowCellValue("FORM").ToString
        Catch ex As Exception
            sForm = ""
        End Try
        Try
            If sForm = "" Then sForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("FORM"))
        Catch ex As Exception
            sForm = ""
        End Try

        Dim sTenForm As String = ""
        Try
            sTenForm = grvForm.GetFocusedRowCellValue("VIETNAM").ToString
        Catch ex As Exception
            sTenForm = ""
        End Try
        Try
            If sTenForm = "" Then sForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("VIETNAM"))
        Catch ex As Exception
            sTenForm = ""
        End Try

        If sForm = "-1" Then
            sTenForm = " ALL Form"
        Else
            sTenForm = " Form " + sTenForm
        End If

        If sForm = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaChonFormCanChinhSua", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        If optCapNhap.SelectedIndex = 0 Then
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoMuonCapNhapLaiNgonNguAnhVietGocCho", Commons.Modules.TypeLanguage) + sTenForm, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        If optCapNhap.SelectedIndex = 1 Then
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoMuonCapNhapLaiNgonNguTiengVietGocCho", Commons.Modules.TypeLanguage) + sTenForm, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        If optCapNhap.SelectedIndex = 2 Then
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoMuonCapNhapLaiNgonNguTiengAnhGocCho", Commons.Modules.TypeLanguage) + sTenForm, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        Dim sSql As String = ""
        Try
            If optCapNhap.SelectedIndex = 0 Then
                sSql = "UPDATE LANGUAGES SET VIETNAM = VIETNAM_OR, ENGLISH = ENGLISH_OR	WHERE FORM = N'" + sForm + "' OR  N'" + sForm + "' = '-1' "
            End If
            If optCapNhap.SelectedIndex = 1 Then
                sSql = "UPDATE LANGUAGES SET VIETNAM = VIETNAM_OR WHERE FORM = N'" + sForm + "' OR  N'" + sForm + "' = '-1' "
            End If

            If optCapNhap.SelectedIndex = 2 Then
                sSql = "UPDATE LANGUAGES SET ENGLISH = ENGLISH_OR WHERE FORM = N'" + sForm + "' OR  N'" + sForm + "' = '-1' "
            End If

            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCapNhapThanhCong", Commons.Modules.TypeLanguage))

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCapNhapKhongThanhCong", Commons.Modules.TypeLanguage))
        End Try

    End Sub

    Private Sub btnReplay_Click(sender As Object, e As EventArgs) Handles btnReplay.Click
        Dim sForm As String
        If optCapNhap.SelectedIndex = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgVuiLongChonTiengAnhHayViet", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        If txtChuoi.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgVuiLongChonChuoiDieuKien", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        If optCapNhap.SelectedIndex = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgVuiLongChonChuoiThayThe", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Try
            sForm = grvForm.GetFocusedRowCellValue("FORM").ToString
        Catch ex As Exception
            sForm = ""
        End Try
        Try
            If sForm = "" Then sForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("FORM"))
        Catch ex As Exception
            sForm = ""
        End Try


        Dim sTenForm As String = ""
        Try
            sTenForm = grvForm.GetFocusedRowCellValue("VIETNAM").ToString
        Catch ex As Exception
            sTenForm = ""
        End Try
        Try
            If sTenForm = "" Then sTenForm = grvForm.GetGroupRowValue(grvForm.FocusedRowHandle(), grvForm.Columns("VIETNAM"))
        Catch ex As Exception
            sTenForm = ""
        End Try

        If sForm = "-1" Then
            sTenForm = " ALL Form"
        Else
            sTenForm = " Form " + sTenForm
        End If


        If sForm = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaChonFormCanChinhSua", Commons.Modules.TypeLanguage))
            Exit Sub
        End If


        If optCapNhap.SelectedIndex = 1 Then
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoMuonThayTheLaiNgonNguTiengVietCho", Commons.Modules.TypeLanguage) + sTenForm, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        If optCapNhap.SelectedIndex = 2 Then
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoMuonThayTheLaiNgonNguTiengAnhCho", Commons.Modules.TypeLanguage) + sTenForm, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        Dim sSql As String = ""
        Try
            If optCapNhap.SelectedIndex = 1 Then
                sSql = "UPDATE LANGUAGES SET VIETNAM = N'" + txtChuoi.Text + "'WHERE (FORM = N'" + sForm + "' OR  N'" + sForm + "' = '-1') AND (VIETNAM = N'" + txtReplay.Text + "') "
            End If

            If optCapNhap.SelectedIndex = 2 Then
                sSql = "UPDATE LANGUAGES SET ENGLISH = N'" + txtChuoi.Text + "'	WHERE (FORM = N'" + sForm + "' OR  N'" + sForm + "' = '-1') AND (VIETNAM = N'" + txtReplay.Text + "') "
            End If

            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql)
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCapNhapThanhCong", Commons.Modules.TypeLanguage))

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCapNhapKhongThanhCong", Commons.Modules.TypeLanguage))
        End Try
        Showdata(sForm)
    End Sub



End Class