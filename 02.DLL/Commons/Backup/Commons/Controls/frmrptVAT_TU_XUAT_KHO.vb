
Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptVAT_TU_XUAT_KHO
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            Dim i As Integer
            Dim dtTableOne = New DataTable
            Dim dtTIEU_DE As New DataTable
            Dim dangxuat, tendx As String
            tendx = ""
            dangxuat = ""
            While i < grvDangxuat.Rows.Count
                If grvDangxuat.Rows(i).Cells("CHON").Value = True Then
                    dangxuat = dangxuat & grvDangxuat.Rows(i).Cells("MS_DANG_XUAT").Value.ToString & ","
                    tendx = tendx & grvDangxuat.Rows(i).Cells("DANG_XUAT").Value.ToString & ", "
                End If
                i = i + 1
            End While
            If (String.IsNullOrEmpty(tendx)) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "ChonDangXuat", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Return
            End If
            tendx = tendx.Remove(tendx.Length - 2, 2)

            Dim frmReport As frmXMLReport = New frmXMLReport()
            frmReport.rptName = "rptVAT_TU_XUAT_KHO"
            'frmReport.AddDataTableSource()

            Dim vtbData As New DataTable()
            Dim sTungay, sDenngay As DateTime
            sTungay = DateTime.Parse(mtxtuNgay.Text)
            sDenngay = DateTime.Parse(mtxtdenNgay.Text)
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetrptVTPT_XUATKHO", sTungay, sDenngay, cboKho.SelectedValue, dangxuat.Remove(dangxuat.Length - 1, 1), Commons.Modules.TypeLanguage, Commons.Modules.UserName))

            If vtbData.Rows.Count > 0 Then
                ' vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DS_PHIEU_BAO_TRI_THEO_NGAY_CUOI", cbxNhaXuong.SelectedValue.ToString))
                vtbData.TableName = "DATA_INFO"
                frmReport.AddDataTableSource(vtbData)

                dtTIEU_DE = CreateTieuDe(tendx)
                dtTIEU_DE.TableName = "TIEU_DE"
                frmReport.AddDataTableSource(dtTIEU_DE)


                frmReport.ShowDialog()

            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function CreateTieuDe(ByVal dangxuat As String) As DataTable
        Dim dtTieuDe As New DataTable
        Dim dtR As DataRow

        dtTieuDe.Columns.Clear()
        dtTieuDe.Columns.Add("TEN_REPORT")
        dtTieuDe.Columns.Add("sTU_NGAY")
        dtTieuDe.Columns.Add("sDEN_NGAY")
        dtTieuDe.Columns.Add("TU_NGAY")
        dtTieuDe.Columns.Add("DEN_NGAY")
        dtTieuDe.Columns.Add("sDANG_XUAT")
        dtTieuDe.Columns.Add("DANG_XUAT")
        dtTieuDe.Columns.Add("sNGUOI_LAP")

        dtTieuDe.Columns.Add("sKHO")
        dtTieuDe.Columns.Add("sNGAY")
        dtTieuDe.Columns.Add("sSO_PHIEU_XUAT")
        dtTieuDe.Columns.Add("sSO_CHUNG_TU")
        dtTieuDe.Columns.Add("sLY_DO_XUAT")
        dtTieuDe.Columns.Add("sMUC_DICH")
        dtTieuDe.Columns.Add("sMASO_VTPT")
        dtTieuDe.Columns.Add("sTEN_VTPT")
        dtTieuDe.Columns.Add("sPHIEU_NHAP")
        dtTieuDe.Columns.Add("sSO_LUONG")
        dtTieuDe.Columns.Add("sDONG_GIA")
        dtTieuDe.Columns.Add("sTHANH_TIEN")
        dtTieuDe.Columns.Add("sTONG_KHO")
        dtTieuDe.Columns.Add("sTONG_TIEN")
        dtTieuDe.Columns.Add("sMSTHIETBI")

        dtR = dtTieuDe.NewRow
        dtR.Item("TEN_REPORT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "TEN_REPORT", commons.Modules.TypeLanguage)
        dtR.Item("sTU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "TU_NGAY", commons.Modules.TypeLanguage)
        dtR.Item("TU_NGAY") = mtxtuNgay.Text
        dtR.Item("DEN_NGAY") = mtxtdenNgay.Text
        dtR.Item("sDEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "DEN_NGAY", commons.Modules.TypeLanguage)
        dtR.Item("sDANG_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "DANG_XUAT", commons.Modules.TypeLanguage)
        dtR.Item("DANG_XUAT") = dangxuat
        dtR.Item("sNGUOI_LAP") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "NGUOI_LAP", commons.Modules.TypeLanguage)

        dtR.Item("sKHO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sKHO", commons.Modules.TypeLanguage)
        dtR.Item("sNGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sNGAY", commons.Modules.TypeLanguage)
        dtR.Item("sSO_PHIEU_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sSO_PHIEU_XUAT", commons.Modules.TypeLanguage)
        dtR.Item("sSO_CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sSO_CHUNG_TU", commons.Modules.TypeLanguage)
        dtR.Item("sLY_DO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sLY_DO_XUAT", commons.Modules.TypeLanguage)
        dtR.Item("sMUC_DICH") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sMUC_DICH", commons.Modules.TypeLanguage)
        dtR.Item("sMASO_VTPT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sMASO_VTPT", commons.Modules.TypeLanguage)
        dtR.Item("sTEN_VTPT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTEN_VTPT", commons.Modules.TypeLanguage)
        dtR.Item("sPHIEU_NHAP") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sPHIEU_NHAP", commons.Modules.TypeLanguage)
        dtR.Item("sSO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sSO_LUONG", commons.Modules.TypeLanguage)
        dtR.Item("sDONG_GIA") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sDONG_GIA", commons.Modules.TypeLanguage)
        dtR.Item("sTHANH_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTHANH_TIEN", commons.Modules.TypeLanguage)
        dtR.Item("sTONG_KHO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTONG_KHO", commons.Modules.TypeLanguage)
        dtR.Item("sTONG_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sTONG_TIEN", commons.Modules.TypeLanguage)
        dtR.Item("sMSTHIETBI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "sMSTHIET_BI", commons.Modules.TypeLanguage)


        dtTieuDe.Rows.Add(dtR)

        Return dtTieuDe
    End Function


    'set ngon ngu tren form chon
    Private Sub refeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", "rptVAT_TU_XUAT_KHO", commons.Modules.TypeLanguage)
        Me.lbatuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", lbatuNgay.Name, commons.Modules.TypeLanguage)
        Me.lbadenNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", lbadenNgay.Name, commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", btnThucHien.Name, commons.Modules.TypeLanguage)
        Me.lbaKho.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptVAT_TU_XUAT_KHO", lbaKho.Name, commons.Modules.TypeLanguage)

    End Sub

    'Load cbo kho
    Private Sub LoadKho()
        Dim vtbData As New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 1, Commons.Modules.UserName))
        cboKho.DataSource = vtbData
        cboKho.ValueMember = "MS_KHO"
        cboKho.DisplayMember = "TEN_KHO"
    End Sub

    Private Sub frmrptChonVTPTXuatkho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadKho()
        LoadDangxuat()
        mtxtuNgay.Value = CDate("1/1/" & Year(Now))
        mtxtdenNgay.Value = CDate("31/12/" & Year(Now))
    End Sub

    Private Sub LoadDangxuat()
        Dim dtTable As New DataTable()
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDANG_XUATswithType", commons.Modules.TypeLanguage))
        With grvDangxuat
            .DataSource = dtTable
            .Columns("CHON").ReadOnly = False
            .Columns("DANG_XUAT").ReadOnly = True
            .Columns("MS_DANG_XUAT").Visible = False
        End With
        Try
            Me.grvDangxuat.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grvDangxuat.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
