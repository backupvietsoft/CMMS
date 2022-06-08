
Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptCHI_PHI_BAO_TRI_THEO_BPCP
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Private Sub frmrptCHI_PHI_BAO_TRI_THEO_BPCP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "PhaiNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End If
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "PhaiNhapDenNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If
            Dim vtbData As New DataTable()
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_CHI_PHI_THEO_BO_PHAN_CHIU_PHI", vTuNgay, vDenNgay, Commons.Modules.UserName))
            vtbData.TableName = "DATA_INFO"

            If vtbData.Rows.Count > 0 Then
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptCHI_PHI_BAO_TRI_THEO_BPCP"
                frmRepot.AddDataTableSource(RefeshLanguage())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
        vtbTitle.Columns(3).ColumnName = "DON_VI"
        vtbTitle.Columns(4).ColumnName = "BO_PHAN_CP"
        vtbTitle.Columns(5).ColumnName = "MS_TB"
        vtbTitle.Columns(6).ColumnName = "TEN_TB"
        vtbTitle.Columns(7).ColumnName = "CP_PHU_TUNG"
        vtbTitle.Columns(8).ColumnName = "CP_VAT_TU"
        vtbTitle.Columns(9).ColumnName = "CP_NHAN_CONG"
        vtbTitle.Columns(10).ColumnName = "CP_THUE"
        vtbTitle.Columns(11).ColumnName = "CP_KHAC"
        vtbTitle.Columns(12).ColumnName = "CP_H_NGAY"
        vtbTitle.Columns(13).ColumnName = "STT"
        vtbTitle.Columns(14).ColumnName = "TONG"
        vtbTitle.Columns(15).ColumnName = "TONG1"
        vtbTitle.Columns(16).ColumnName = "TONG2"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TIEU_DE", commons.Modules.TypeLanguage)
        vRowTitle("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TU_NGAY", commons.Modules.TypeLanguage) & mtxtTuNgay.Text
        vRowTitle("DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "DEN_NGAY", commons.Modules.TypeLanguage) & mtxtDenNgay.Text
        vRowTitle("DON_VI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "DON_VI", commons.Modules.TypeLanguage)
        vRowTitle("BO_PHAN_CP") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "BO_PHAN_CP", commons.Modules.TypeLanguage)
        vRowTitle("MS_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "MS_TB", commons.Modules.TypeLanguage)
        vRowTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TEN_TB", commons.Modules.TypeLanguage)
        vRowTitle("CP_PHU_TUNG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "CP_PHU_TUNG", commons.Modules.TypeLanguage)
        vRowTitle("CP_VAT_TU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "CP_VAT_TU", commons.Modules.TypeLanguage)
        vRowTitle("CP_NHAN_CONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "CP_NHAN_CONG", commons.Modules.TypeLanguage)
        vRowTitle("CP_THUE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "CP_THUE", commons.Modules.TypeLanguage)
        vRowTitle("CP_KHAC") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "CP_KHAC", commons.Modules.TypeLanguage)
        vRowTitle("CP_H_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "CP_H_NGAY", commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "STT", commons.Modules.TypeLanguage)
        vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TONG", commons.Modules.TypeLanguage)
        vRowTitle("TONG1") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TONG1", commons.Modules.TypeLanguage)
        vRowTitle("TONG2") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TONG2", commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function


    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TNPhaiNhoHonDN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating

        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_BAO_TRI_THEO_BPCP", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
