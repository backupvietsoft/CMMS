
Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptDANH_SACH_VAT_TU_DE_BAO_TRI_TB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            datTNgay.Text = DateSerial(Year(Today), Month(Today), 1)
            datDNgay.Text = datTNgay.DateTime.Date.AddMonths(1).AddDays(-1)
            loadNhaXuong()
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 15
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TU_NGAY"
        vtbTitle.Columns(2).ColumnName = "DEN_NGAY"
        vtbTitle.Columns(3).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(4).ColumnName = "TMP"
        vtbTitle.Columns(5).ColumnName = "MS_TB"
        vtbTitle.Columns(6).ColumnName = "TEN_TB"
        vtbTitle.Columns(7).ColumnName = "LOAI_TB"
        vtbTitle.Columns(8).ColumnName = "MS_VT"
        vtbTitle.Columns(9).ColumnName = "TEN_VT"
        vtbTitle.Columns(10).ColumnName = "SO_LUONG"
        vtbTitle.Columns(11).ColumnName = "THANH_TIEN"
        vtbTitle.Columns(12).ColumnName = "TONG"
        vtbTitle.Columns(13).ColumnName = "STT"
        vtbTitle.Columns(14).ColumnName = "LOAI_VT"
        vtbTitle.Columns(15).ColumnName = "TONG_THEO_XUONG"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TIEU_DE", Commons.Modules.TypeLanguage)
        vRowTitle("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TU_NGAY", Commons.Modules.TypeLanguage) & datTNgay.Text
        vRowTitle("DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "DEN_NGAY", Commons.Modules.TypeLanguage) & datDNgay.Text
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "DIA_DIEM", Commons.Modules.TypeLanguage)
        vRowTitle("TMP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TMP", Commons.Modules.TypeLanguage)
        vRowTitle("MS_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "MS_TB", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TEN_TB", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "LOAI_TB", Commons.Modules.TypeLanguage)
        vRowTitle("MS_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "MS_VT", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TEN_VT", Commons.Modules.TypeLanguage)
        vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "SO_LUONG", Commons.Modules.TypeLanguage)
        vRowTitle("THANH_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "THANH_TIEN", Commons.Modules.TypeLanguage)
        vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TONG", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "LOAI_VT", Commons.Modules.TypeLanguage)
        vRowTitle("TONG_THEO_XUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "TONG_THEO_XUONG", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Sub loadNhaXuong()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", Commons.Modules.UserName, "-1", "-1", "-1"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, _table, "MS_N_XUONG", "TEN_N_XUONG", "")
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            If datTNgay.Text.Trim.ToString = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "PhaiNhapTuNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                datTNgay.Focus()
                Exit Sub
            End If
            If datDNgay.Text = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "PhaiNhapDenNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                datDNgay.Focus()
                Exit Sub
            End If

            Dim vtbData As New DataTable()
            v_all = New DataTable()

            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spBCDanhSachVatTuSuDungBaoTri", _
                    datTNgay.DateTime.Date, datDNgay.DateTime.Date, Modules.UserName, cboDDiem.EditValue, Modules.TypeLanguage))
            vtbData.TableName = "DATA_INFO"

            If vtbData.Rows.Count > 0 Then
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB"
                frmRepot.AddDataTableSource(RefeshLanguage())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDANH_SACH_VAT_TU_DE_BAO_TRI_TB", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnThoat_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
