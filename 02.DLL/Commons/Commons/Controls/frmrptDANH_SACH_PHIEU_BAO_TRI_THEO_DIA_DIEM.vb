
Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("DS_PHIEU_BAO_TRI_THEO_KHU_VUC_TMP")
    End Sub
    Private Sub frmrptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        loadNhaXuong()
    End Sub
    Sub loadNhaXuong()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cbxNhaxuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaxuong.ValueMember = "MS_N_XUONG"
        cbxNhaxuong.DataSource = _table
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "PhaiNhapTuNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End If
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "PhaiNhapDenNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If
            v_all = New DataTable()
            Dim vtbData As New DataTable()
            vtbData = Get_DataTable(cbxNhaxuong.SelectedValue.ToString(), vTuNgay, vDenNgay, "-1", "-1", "-1")
            vtbData.TableName = "DATA_INFO"

            If vtbData.Rows.Count > 0 Then
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM"
                frmRepot.AddDataTableSource(RefeshLanguage())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "KoCoDuLieuDeIn", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 14
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TU_NGAY"
        vtbTitle.Columns(2).ColumnName = "DEN_NGAY"
        vtbTitle.Columns(3).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(4).ColumnName = "MS_PHIEU_BT"
        vtbTitle.Columns(5).ColumnName = "MS_TB"
        vtbTitle.Columns(6).ColumnName = "TEN_TB"
        vtbTitle.Columns(7).ColumnName = "LOAI_TB"
        vtbTitle.Columns(8).ColumnName = "LOAI_BAO_TRI"
        vtbTitle.Columns(9).ColumnName = "LY_DO"
        vtbTitle.Columns(10).ColumnName = "NGAY_BDKH"
        vtbTitle.Columns(11).ColumnName = "NGAY_KTKH"
        vtbTitle.Columns(13).ColumnName = "NGAY_N_THU"
        vtbTitle.Columns(14).ColumnName = "STT"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "TIEU_DE", commons.Modules.TypeLanguage)
        vRowTitle("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "TU_NGAY", commons.Modules.TypeLanguage) & mtxtTuNgay.Text
        vRowTitle("DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "DEN_NGAY", commons.Modules.TypeLanguage) & mtxtDenNgay.Text
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "DIA_DIEM", commons.Modules.TypeLanguage)
        vRowTitle("MS_PHIEU_BT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "MS_PHIEU_BT", commons.Modules.TypeLanguage)
        vRowTitle("MS_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "MS_TB", commons.Modules.TypeLanguage)
        vRowTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "TEN_TB", commons.Modules.TypeLanguage)
        vRowTitle("LOAI_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "LOAI_TB", commons.Modules.TypeLanguage)
        vRowTitle("LOAI_BAO_TRI") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "LOAI_BAO_TRI", commons.Modules.TypeLanguage)
        vRowTitle("LY_DO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "LY_DO", commons.Modules.TypeLanguage)
        vRowTitle("NGAY_BDKH") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "NGAY_BDKH", commons.Modules.TypeLanguage)
        vRowTitle("NGAY_KTKH") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "NGAY_KTKH", commons.Modules.TypeLanguage)
        vRowTitle("NGAY_N_THU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "NGAY_N_THU", commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "STT", commons.Modules.TypeLanguage)

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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "TNPhaiNhoHonDN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDANH_SACH_PHIEU_BAO_TRI_THEO_DIA_DIEM", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
#Region "Nhu Y"

    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_tinh As String, ByVal ms_quan As String, ByVal ms_duong As String) As System.Data.DataTable



        Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_DS_PHIEU_BAO_TRI_THEO_KHU_VUC]", tungay, denngay, Commons.Modules.UserName, MS_N_Xuong, ms_tinh, ms_quan, ms_duong))

        Return objDataTable

    End Function

#End Region


    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
