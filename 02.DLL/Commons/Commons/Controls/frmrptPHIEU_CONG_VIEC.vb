Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptPHIEU_CONG_VIEC

    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Private Sub frmrptPHIEU_CONG_VIEC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        'loadNhaXuong()
        LoadDonVi()
        LoadToPhongBan()
        LoadNhanVien()
        btnTimNV.Text = "..."
    End Sub


    'kiem tra tu ngay
    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception

            e.Cancel = True
        End Try
        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TNPhaiNhoHonDN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
    'Kiem tra den ngay
    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating

        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "PhaiNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End If
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "PhaiNhapDenNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If

            If cbxNhanVien.Text.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "ChuaChonNhanVien", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                cbxNhanVien.Focus()
                Exit Sub
            End If

            Dim vtbData As New DataTable()
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_PHIEU_CONG_VIEC", vTuNgay, vDenNgay, cbxDonVi.SelectedValue.ToString, cbxPhongban.SelectedValue.ToString, cbxNhanVien.SelectedValue.ToString))
            vtbData.TableName = "DATA_INFO"

            If vtbData.Rows.Count > 0 Then
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptPHIEU_CONG_VIEC"
                frmRepot.AddDataTableSource(RefeshLanguage())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
        End Try


    End Sub


    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 16
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TU_NGAY"
        vtbTitle.Columns(2).ColumnName = "DEN_NGAY"
        vtbTitle.Columns(3).ColumnName = "MS_NV"
        vtbTitle.Columns(4).ColumnName = "TEN_NV"
        vtbTitle.Columns(5).ColumnName = "TO"
        vtbTitle.Columns(6).ColumnName = "PHONG_BAN"
        vtbTitle.Columns(7).ColumnName = "DON_VI"
        vtbTitle.Columns(8).ColumnName = "MS_PBT"
        vtbTitle.Columns(9).ColumnName = "THIET_BI"
        vtbTitle.Columns(10).ColumnName = "BO_PHAN"
        vtbTitle.Columns(11).ColumnName = "CONG_VIEC"
        vtbTitle.Columns(12).ColumnName = "TNG"
        vtbTitle.Columns(13).ColumnName = "DNG"
        vtbTitle.Columns(14).ColumnName = "TMP"
        vtbTitle.Columns(15).ColumnName = "STT"
        vtbTitle.Columns(16).ColumnName = "DANH_GIA"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TIEU_DE", commons.Modules.TypeLanguage)
        vRowTitle("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TU_NGAY", commons.Modules.TypeLanguage) & mtxtTuNgay.Text
        vRowTitle("DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "DEN_NGAY", commons.Modules.TypeLanguage) & mtxtDenNgay.Text
        vRowTitle("MS_NV") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "MS_NV", commons.Modules.TypeLanguage)
        vRowTitle("TEN_NV") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TEN_NV", commons.Modules.TypeLanguage)
        vRowTitle("TO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TO", commons.Modules.TypeLanguage)
        vRowTitle("PHONG_BAN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "PHONG_BAN", commons.Modules.TypeLanguage)
        vRowTitle("DON_VI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "DON_VI", commons.Modules.TypeLanguage)
        vRowTitle("MS_PBT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "MS_PBT", commons.Modules.TypeLanguage)
        vRowTitle("THIET_BI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "THIET_BI", commons.Modules.TypeLanguage)
        vRowTitle("BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "BO_PHAN", commons.Modules.TypeLanguage)
        vRowTitle("CONG_VIEC") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "CONG_VIEC", commons.Modules.TypeLanguage)
        vRowTitle("TNG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TNG", commons.Modules.TypeLanguage)
        vRowTitle("DNG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "DNG", commons.Modules.TypeLanguage)
        vRowTitle("TMP") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "TMP", commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "STT", commons.Modules.TypeLanguage)
        vRowTitle("DANH_GIA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_CONG_VIEC", "DANH_GIA", Commons.Modules.TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function


    'Load Don vi
    Sub LoadDonVi()
        cbxDonVi.Value = "MS_DON_VI"
        cbxDonVi.Display = "TEN_DON_VI"
        cbxDonVi.StoreName = "H_GET_DON_VIs"
        cbxDonVi.Param = Commons.Modules.UserName
        cbxDonVi.BindDataSource()
    End Sub
    'load To Phong ban 
    Sub LoadToPhongBan()
        cbxPhongban.Value = "MS_TO"
        cbxPhongban.Display = "TEN_TO"
        cbxPhongban.StoreName = "H_GET_TO_PHONG_BANs"
        cbxPhongban.Param = cbxDonVi.SelectedValue.ToString
        cbxPhongban.BindDataSource()
    End Sub
    'Load nhan vien
    Sub LoadNhanVien()
        cbxNhanVien.Value = "MS_CONG_NHAN"
        cbxNhanVien.Display = "TEN_CONG_NHAN"
        cbxNhanVien.StoreName = "H_GET_CONG_NHANs"
        Dim s As String = cbxPhongban.SelectedValue.ToString
        cbxNhanVien.Param = cbxPhongban.SelectedValue.ToString
        cbxNhanVien.BindDataSource()
    End Sub

    Private Sub cbxPhongban_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxPhongban.SelectedIndexChanged
        Try

            cbxNhanVien.Value = "MS_CONG_NHAN"
            cbxNhanVien.Display = "TEN_CONG_NHAN"
            cbxNhanVien.StoreName = "H_GET_CONG_NHANs"
            Dim s As String = cbxPhongban.SelectedValue.ToString
            cbxNhanVien.Param = cbxPhongban.SelectedValue.ToString
            cbxNhanVien.BindDataSource()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub

    Private Sub btnTimNV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimNV.Click
        Dim frm As New ReportMain.frmTimNhanVien()
        frm.MsDVi = cbxDonVi.SelectedValue
        frm.MsPBan = cbxPhongban.SelectedValue()


        If frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim sMSNV As String
        sMSNV = frm.MsNVien
        If sMSNV = "" Then Exit Sub
        cbxNhanVien.SelectedValue = sMSNV
    End Sub
End Class
