Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptPhanTichGiaTriTonKho

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        ShowPhanTichGiaTriTonKho()

    End Sub

    Private Sub frmrtChonPhanTichHangTonKho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadKho()
    End Sub

    Private Sub loadKho()

        Dim TbKho As System.Data.DataTable = New System.Data.DataTable()
        TbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 1, Commons.Modules.UserName))

        cboKho.DataSource = TbKho
        cboKho.ValueMember = "MS_KHO"
        cboKho.DisplayMember = "TEN_KHO"
    End Sub

    Sub ShowPhanTichGiaTriTonKho()
        Dim vtbData As New DataTable
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_PHAN_TICH_GIA_TRI_HANG_TON_KHO", cboKho.SelectedValue, Commons.Modules.UserName))

        If vtbData.Rows.Count > 0 Then
            Dim frm As frmXMLReport = New frmXMLReport
            If (Modules.sPrivate = "ADC") Then
                frm.rptName = "rptPhanTichGiaTriTonKho_ADC"
                Modules.SQLString = "0Design"
            Else
                frm.rptName = "rptPhanTichGiaTriTonKho"
            End If

            frm.AddDataTableSource(RefeshLanguaPhanTichGiaiTriTK())
            frm.AddDataTableSource(vtbData)
            frm.ShowDialog()
        Else
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage))
        End If
    End Sub

    Function RefeshLanguaPhanTichGiaiTriTK() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 14
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TONG_GT"
        vtbTitle.Columns(2).ColumnName = "STT"
        vtbTitle.Columns(3).ColumnName = "MS_PT"
        vtbTitle.Columns(4).ColumnName = "TEN_PT"
        vtbTitle.Columns(5).ColumnName = "PART_NO"
        vtbTitle.Columns(6).ColumnName = "QUY_CACH"
        vtbTitle.Columns(7).ColumnName = "SO_LUONG"
        vtbTitle.Columns(8).ColumnName = "GIA_TRI"
        vtbTitle.Columns(9).ColumnName = "KHO"
        vtbTitle.Columns(10).ColumnName = "LOAI_VT"
        vtbTitle.Columns(11).ColumnName = "TMP1"
        vtbTitle.Columns(12).ColumnName = "TMP2"
        vtbTitle.Columns(13).ColumnName = "TMP3"
        vtbTitle.Columns(14).ColumnName = "TMP4"
        'vtbTitle.Columns(15).ColumnName = "TMP5"
        'vtbTitle.Columns(16).ColumnName = "TMP6"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TIEU_DE", Commons.Modules.TypeLanguage)
        vRowTitle("TONG_GT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TONG_GT", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "MS_PT", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TEN_PT", Commons.Modules.TypeLanguage)
        vRowTitle("PART_NO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "PART_NO", Commons.Modules.TypeLanguage)
        vRowTitle("QUY_CACH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "QUY_CACH", Commons.Modules.TypeLanguage)
        vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "SO_LUONG", Commons.Modules.TypeLanguage)
        vRowTitle("GIA_TRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "GIA_TRI", Commons.Modules.TypeLanguage)
        vRowTitle("KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "KHO", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "LOAI_VT", Commons.Modules.TypeLanguage)
        vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TMP1", Commons.Modules.TypeLanguage)
        vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TMP2", Commons.Modules.TypeLanguage)
        vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TMP3", Commons.Modules.TypeLanguage)
        vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichGiaTriTonKho", "TMP4", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle

    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
