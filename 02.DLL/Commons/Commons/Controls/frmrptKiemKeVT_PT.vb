
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports System.Windows.Forms

Public Class frmrptKiemKeVT_PT
    Private vNgay As DateTime
    Private objKiemKeController As New Commons.VS.Classes.Catalogue.KIEM_KE_Controller

    Private Sub frmrptKiemKeVT_PT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vNgay = DateTime.Now.Date
        mtxtNgay.Text = vNgay.ToString("dd/MM/yyyy")
        LoadKho()
    End Sub

    Sub LoadKho()
        Dim vtb As New DataTable

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 0, Commons.Modules.UserName))
        cbxKho.DataSource = vtb
        cbxKho.DisplayMember = "TEN_KHO"
        cbxKho.ValueMember = "MS_KHO"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If cbxKho.SelectedValue Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "CHON_KHO_CAN_TINH", Commons.Modules.TypeLanguage))
            Return
        End If
        Dim MS_KHO As Integer = Integer.Parse(cbxKho.SelectedValue.ToString)
        If Me.objKiemKeController.CHECK_PHIEU_KIEM_KE_UNLOCK_EXISTS(MS_KHO) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "PHIEU_KIEM_KE_UNLOCK_EXISTS", Commons.Modules.TypeLanguage))
            Return
        End If
        If Me.objKiemKeController.CHECK_PHIEU_XUAT_UNLOCK_EXISTS(MS_KHO) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "PHIEU_XUAT_UNLOCK_EXISTS", Commons.Modules.TypeLanguage))
            Return
        End If
        If Me.objKiemKeController.CHECK_PHIEU_NHAP_UNLOCK_EXISTS(MS_KHO) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "PHIEU_NHAP_UNLOCK_EXISTS", Commons.Modules.TypeLanguage))
            Return
        End If

        Dim dtKIEM_KE_VAT_TU As New DataTable
        Dim dtTIEU_DE_KIEM_KE_VAT_TU As New DataTable

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        If chkPN.Checked Then
            dtKIEM_KE_VAT_TU.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VAT_TU_KIEM_KE", cbxKho.SelectedValue, 1))
        Else
            dtKIEM_KE_VAT_TU.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VAT_TU_KIEM_KE", cbxKho.SelectedValue, 2))
        End If

        dtKIEM_KE_VAT_TU.TableName = "rptKIEM_KE_VAT_TU"

        If dtKIEM_KE_VAT_TU.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "KHONG_CO_DU_LIEU_IN", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "rptKiemKeVT_PT")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        dtTIEU_DE_KIEM_KE_VAT_TU = CreateTieuDeKiemKeVatTu()
        dtTIEU_DE_KIEM_KE_VAT_TU.TableName = "rptTIEU_DE_KIEM_KE_VAT_TU"
        Dim frm As New frmXMLReport
        If chkPN.Checked Then
            frm.rptName = "rptKiemKeVT_PT"
        Else
            frm.rptName = "rptKiemKeVT_PTKgPN"
        End If
        frm.AddDataTableSource(dtKIEM_KE_VAT_TU)
        frm.AddDataTableSource(dtTIEU_DE_KIEM_KE_VAT_TU)
        frm.Show()
        Me.Cursor = Cursors.Default

        'If GIA_TRI Then
        '    Me.grdDANH_SACH.DataSource = Me.objKiemKeController.LOAD_TON_KHO_VAT_TU_THEO_KHO(MS_KHO, 1, cboClass.SelectedValue)
        'Else
        '    Me.grdDANH_SACH.DataSource = Me.objKiemKeController.LOAD_TON_KHO_VAT_TU_THEO_KHO(MS_KHO, 0, cboClass.SelectedValue)
        'End If
    End Sub

    Private Function CreateTieuDeKiemKeVatTu() As DataTable
        Dim dtTieuDe As New DataTable
        Dim dtR As DataRow

        dtTieuDe.Columns.Clear()
        dtTieuDe.Columns.Add("_MS_PT_")
        dtTieuDe.Columns.Add("_TEN_PT_")
        dtTieuDe.Columns.Add("_MS_DH_NHAP_")
        dtTieuDe.Columns.Add("_MS_VI_TRI_")
        dtTieuDe.Columns.Add("_PART_NO_")
        dtTieuDe.Columns.Add("_ITEM_CODE_")
        dtTieuDe.Columns.Add("_DVT_")
        dtTieuDe.Columns.Add("_SL_TON_CT_")
        dtTieuDe.Columns.Add("_SL_TON_TT_")
        dtTieuDe.Columns.Add("_KHO_")
        dtTieuDe.Columns.Add("_TRANG_IN_")
        dtTieuDe.Columns.Add("_TIEU_DE_")
        dtTieuDe.Columns.Add("GHI_CHU")

        dtR = dtTieuDe.NewRow
        dtR.Item("_MS_PT_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "MS_PT", Commons.Modules.TypeLanguage)
        dtR.Item("_TEN_PT_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "TEN_PT", Commons.Modules.TypeLanguage)
        dtR.Item("_MS_DH_NHAP_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "MS_DH_NHAP", Commons.Modules.TypeLanguage)
        dtR.Item("_MS_VI_TRI_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "MS_VI_TRI", Commons.Modules.TypeLanguage)
        dtR.Item("_PART_NO_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "PART_NO", Commons.Modules.TypeLanguage)
        dtR.Item("_ITEM_CODE_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "ITEM_CODE", Commons.Modules.TypeLanguage)
        dtR.Item("_DVT_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "DVT", Commons.Modules.TypeLanguage)
        dtR.Item("_SL_TON_CT_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "SL_TON_CT", Commons.Modules.TypeLanguage)
        dtR.Item("_SL_TON_TT_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "SL_TON_TT", Commons.Modules.TypeLanguage)
        dtR.Item("_KHO_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "KHO", Commons.Modules.TypeLanguage) & " : " & cbxKho.Text.Trim()
        dtR.Item("_TRANG_IN_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "TRANG_IN", Commons.Modules.TypeLanguage)
        If chkPN.Checked Then
            dtR.Item("_TIEU_DE_") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "TIEU_DE", Commons.Modules.TypeLanguage)
        Else
            Dim sStmp As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "TieuDeKhongTheoPhieuNhap", Commons.Modules.TypeLanguage)
            If sStmp.Substring(0, 1) = "@" Then
                sStmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "TIEU_DE", Commons.Modules.TypeLanguage)
            End If
            dtR.Item("_TIEU_DE_") = sStmp
        End If
        dtR.Item("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "GHI_CHU", Commons.Modules.TypeLanguage)

        dtTieuDe.Rows.Add(dtR)

        Return dtTieuDe
    End Function

    Private Sub mtxtNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtNgay.Validating

        If mtxtNgay.Text.Trim <> "/  /" Then
            Try
                vNgay = DateTime.ParseExact(mtxtNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKiemKeVT_PT", "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, "rptKiemKeVT_PT")
            End Try
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub

    Private Sub mtxtNgay_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mtxtNgay.MaskInputRejected

    End Sub
End Class
