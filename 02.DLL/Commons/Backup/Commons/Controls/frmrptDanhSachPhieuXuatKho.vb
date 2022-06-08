Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Imports Commons.VS.Classes.Catalogue
Imports System.Globalization
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data
Imports Commons.VS.Classes.Admin
Imports System.Windows.Forms

Public Class frmrptDanhSachPhieuXuatKho
    Private SqlText As String = String.Empty
    Dim sqlColection As String
    Dim tuNgay As DateTime
    Dim denNgay As DateTime
    Dim dsTable As New DataSet
    Public Sub GetTuNgay_DenNgay(ByVal date1 As DateTime, ByVal date2 As DateTime)
        tuNgay = date1
        denNgay = date2
    End Sub
    Private Sub frmrptDanhSachPhieuXuatKho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetTuNgay_DenNgay(daTimeTuNgay.Value.Date, daTimeDenNgay.Value.Date)
        LoadList_IC_Kho()
        LoadGrid_PhieuXuat(cmbKho.Text, tuNgay, denNgay)
        AddHandler cmbKho.SelectedIndexChanged, AddressOf Me.cmbKho_SelectedIndexChanged

    End Sub
    ' Load du lieu len combo kho
    Public Sub LoadList_IC_Kho()

        Commons.Modules.SQLString = "Select MS_KHO , Ten_Kho From IC_KHO "
        Dim TB As New DataTable()
        TB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        cmbKho.DisplayMember = "Ten_Kho"
        cmbKho.ValueMember = "MS_KHO"
        cmbKho.DataSource = TB
    End Sub
    ' Load  du lieu len gridview
    Public Sub LoadGrid_PhieuXuat(ByVal tenKho As String, ByVal date1 As DateTime, ByVal date2 As DateTime)

        Dim ngay1, ngay2 As String
        date2 = denNgay
        date2 = date2.AddDays(1)
        ngay1 = tuNgay.Year.ToString + "/" + tuNgay.Month.ToString + "/" + tuNgay.Day.ToString
        ngay2 = date2.Year.ToString + "/" + date2.Month.ToString + "/" + date2.Day.ToString
        Commons.Modules.SQLString = "SELECT     dbo.DANG_XUAT.MS_DANG_XUAT, dbo.DANG_XUAT.DANG_XUAT_VIET, dbo.DANG_XUAT.DANG_XUAT_ANH, dbo.LOAI_BAO_TRI.HU_HONG " & _
                     " FROM dbo.LOAI_BAO_TRI INNER JOIN   dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT RIGHT OUTER JOIN " & _
                      " dbo.IC_KHO INNER JOIN  dbo.IC_DON_HANG_XUAT ON dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_XUAT.MS_KHO INNER JOIN " & _
                      " dbo.DANG_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT ON " & _
                    " dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI " & _
                    " WHERE     (dbo.IC_KHO.MS_KHO = " + cmbKho.SelectedValue.ToString + " ) AND (dbo.IC_DON_HANG_XUAT.NGAY BETWEEN '" + ngay1 + "' AND '" + ngay2 + "') " & _
                    " GROUP BY dbo.DANG_XUAT.MS_DANG_XUAT, dbo.DANG_XUAT.DANG_XUAT_VIET, dbo.DANG_XUAT.DANG_XUAT_ANH, dbo.LOAI_BAO_TRI.HU_HONG "

        Try
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
            Dim vtbTmp As New DataTable()
            vtbTmp = dt.Copy()
            vtbTmp.Rows.Clear()
            For Each vrow As DataRow In dt.Rows
                If vrow("MS_DANG_XUAT") = 1 Then
                    If vrow("HU_HONG") = True Then
                        vtbTmp.Rows.Add(1, "Xuất cho bảo trì không có kế hoạch", "Issued for corrective maintenance", 1)
                    Else
                        vtbTmp.Rows.Add(1, "Xuất cho bảo trì có kế hoạch", "Issued for preventive maintenance", 0)
                    End If
                Else
                    vtbTmp.Rows.Add(vrow("MS_DANG_XUAT"), vrow("DANG_XUAT_VIET"), vrow("DANG_XUAT_ANH"), 0)
                End If
            Next
            gvPhieuXuatKho.AutoGenerateColumns = False

            gvPhieuXuatKho.DataSource = vtbTmp
            gvPhieuXuatKho.Columns("MS_DANG_XUAT").DataPropertyName = "MS_DANG_XUAT"
            gvPhieuXuatKho.Columns("HU_HONG").DataPropertyName = "HU_HONG"
            If Commons.Modules.TypeLanguage = 0 Then
                gvPhieuXuatKho.Columns("DANG_XUAT").DataPropertyName = "DANG_XUAT_VIET"
            Else
                gvPhieuXuatKho.Columns("DANG_XUAT").DataPropertyName = "DANG_XUAT_ANH"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub daTimeDenNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles daTimeDenNgay.ValueChanged
        GetTuNgay_DenNgay(daTimeTuNgay.Value.Date, daTimeDenNgay.Value.Date)
        LoadGrid_PhieuXuat(cmbKho.Text, tuNgay, denNgay)
    End Sub

    Private Sub daTimeTuNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles daTimeTuNgay.ValueChanged
        If (daTimeTuNgay.Value.Date > DateTime.Now()) Then
            MessageBox.Show("Từ ngày không được lớn hơn ngày hiện tại")
            daTimeTuNgay.Value = DateTime.Now
            daTimeTuNgay.Focus()
            Exit Sub
        Else
            GetTuNgay_DenNgay(daTimeTuNgay.Value.Date, daTimeDenNgay.Value.Date)
            LoadGrid_PhieuXuat(cmbKho.Text, tuNgay, denNgay)
        End If

    End Sub
    Public Function ConvertDateYMD(ByVal ngay As DateTime) As String
        Return (ngay.Year.ToString + "/" + ngay.Month.ToString + "/" + ngay.Day.ToString)
    End Function


    ' Duyet gridview tra ra sql colection
    Public Function DuyetGridView() As Collection
        Dim arrSql As New Collection
        'Dim reportPX As New frmReportPhieuXuat
        Dim msNhap, ten, Sql As String
        Sql = ""
        Dim ngay1, ngay2 As String
        Dim date2 As DateTime
        date2 = denNgay
        date2 = date2.AddDays(1)
        ngay1 = ConvertDateYMD(tuNgay)
        ngay2 = ConvertDateYMD(date2)
        Dim i As Integer
        Dim maKho As String
        maKho = Get_MaKho(cmbKho.Text)

        Dim vtbs As New DataTable()
        vtbs = CType(gvPhieuXuatKho.DataSource, DataTable).Copy()

        For i = 0 To gvPhieuXuatKho.Rows.Count - 1
            If gvPhieuXuatKho.Rows(i).Cells("CHON").Value = True Then
                If gvPhieuXuatKho.Rows(i).Cells("MS_DANG_XUAT").Value = 1 Then
                    If gvPhieuXuatKho.Rows(i).Cells("HU_HONG").Value = True Then
                        msNhap = gvPhieuXuatKho.Rows(i).Cells("MS_DANG_XUAT").Value.ToString
                        Dim tenDX As String '= "Xuất cho bảo trì không có kế hoạch"
                        If Commons.Modules.TypeLanguage = 0 Then
                            tenDX = "Xuất cho bảo trì không có kế hoạch"
                        Else
                            tenDX = "Issued for corrective maintenance"
                        End If

                        Sql += " SELECT     dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN, dbo.IC_DON_HANG_XUAT.NGAY, dbo.IC_DON_HANG_XUAT.MS_KHO, dbo.IC_KHO.TEN_KHO, N'" + tenDX + "'AS DANG_XUAT_VIET, dbo.IC_DON_HANG_XUAT.LY_DO_XUAT, dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU, View_GT_DH_XUAT.GIA_TRI "
                        Sql += " FROM dbo.PHIEU_BAO_TRI INNER JOIN dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT RIGHT OUTER JOIN " & _
                               " dbo.IC_DON_HANG_XUAT INNER JOIN  dbo.View_GT_DH_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = dbo.View_GT_DH_XUAT.MS_DH_XUAT_PT INNER JOIN " & _
                               " dbo.IC_KHO ON dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO AND  dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " & _
                                " dbo.DANG_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT ON  dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI "
                        Sql += " Where dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = View_GT_DH_XUAT.MS_DH_XUAT_PT and dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO  and dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT  "
                        Sql += " And dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_XUAT.MS_KHO  And dbo.IC_DON_HANG_XUAT.MS_KHO = '" + maKho + "'  "
                        Sql += " And dbo.DANG_XUAT.MS_DANG_XUAT = '" + msNhap + "'"
                        Sql += " And dbo.IC_DON_HANG_XUAT.Ngay Between '" + ngay1 + "' and '" + ngay2 + "'"
                        Sql += " and dbo.LOAI_BAO_TRI.HU_HONG = 1"
                        Sql += " union "
                        arrSql.Add(Sql)
                    Else
                        Dim tenDX As String '= "Xuất cho bảo trì không có kế hoạch"
                        If Commons.Modules.TypeLanguage = 0 Then
                            tenDX = "Xuất cho bảo trì có kế hoạch"
                        Else
                            tenDX = "Issued for preventive maintenance"
                        End If
                        msNhap = gvPhieuXuatKho.Rows(i).Cells("MS_DANG_XUAT").Value.ToString
                        ten = gvPhieuXuatKho.Rows(i).Cells(1).Value.ToString
                        Sql += " SELECT     dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN, dbo.IC_DON_HANG_XUAT.NGAY, dbo.IC_DON_HANG_XUAT.MS_KHO, dbo.IC_KHO.TEN_KHO, N'" + tenDX + "'AS DANG_XUAT_VIET, dbo.IC_DON_HANG_XUAT.LY_DO_XUAT, dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU, View_GT_DH_XUAT.GIA_TRI "
                        Sql += " FROM dbo.PHIEU_BAO_TRI INNER JOIN dbo.LOAI_BAO_TRI ON dbo.PHIEU_BAO_TRI.MS_LOAI_BT = dbo.LOAI_BAO_TRI.MS_LOAI_BT RIGHT OUTER JOIN " & _
                               " dbo.IC_DON_HANG_XUAT INNER JOIN  dbo.View_GT_DH_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = dbo.View_GT_DH_XUAT.MS_DH_XUAT_PT INNER JOIN " & _
                               " dbo.IC_KHO ON dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO AND  dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " & _
                                " dbo.DANG_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT ON  dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI "
                        Sql += " Where dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = View_GT_DH_XUAT.MS_DH_XUAT_PT and dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO  and dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT  "
                        Sql += " And dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_XUAT.MS_KHO  And dbo.IC_DON_HANG_XUAT.MS_KHO = '" + maKho + "'  "
                        Sql += " And dbo.DANG_XUAT.MS_DANG_XUAT = '" + msNhap + "'"
                        Sql += " And dbo.IC_DON_HANG_XUAT.Ngay Between '" + ngay1 + "' and '" + ngay2 + "'"
                        Sql += " and dbo.LOAI_BAO_TRI.HU_HONG = 0"
                        Sql += " union "
                        arrSql.Add(Sql)
                    End If
                Else
                    msNhap = gvPhieuXuatKho.Rows(i).Cells("MS_DANG_XUAT").Value.ToString
                    ten = gvPhieuXuatKho.Rows(i).Cells(1).Value.ToString
                    Sql += " SELECT     dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN, dbo.IC_DON_HANG_XUAT.NGAY, dbo.IC_DON_HANG_XUAT.MS_KHO, dbo.IC_KHO.TEN_KHO, dbo.DANG_XUAT.DANG_XUAT_VIET, dbo.IC_DON_HANG_XUAT.LY_DO_XUAT, dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU, View_GT_DH_XUAT.GIA_TRI "
                    Sql += " FROM IC_DON_HANG_XUAT , View_GT_DH_XUAT , IC_KHO , DANG_XUAT  "
                    Sql += " Where dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = View_GT_DH_XUAT.MS_DH_XUAT_PT and dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO  and dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT  "
                    Sql += " And dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_XUAT.MS_KHO  And dbo.IC_DON_HANG_XUAT.MS_KHO = '" + maKho + "'  "
                    Sql += " And dbo.DANG_XUAT.MS_DANG_XUAT = '" + msNhap + "'"
                    Sql += " And dbo.IC_DON_HANG_XUAT.Ngay Between '" + ngay1 + "' and '" + ngay2 + "'"
                    Sql += " union "
                    arrSql.Add(Sql)
                End If

            End If

            'Dim dt As New DataGridViewCheckBoxCell
            'dt = gvPhieuXuatKho.Rows(i).Cells("CHON")
            'Sql = ""
            'If (dt.Value = -1) Then
            '    msNhap = gvPhieuXuatKho.Rows(i).Cells("MS_DANG_XUAT").Value.ToString
            '    ten = gvPhieuXuatKho.Rows(i).Cells(1).Value.ToString
            '    ' frmReportPhieuXuat.cacDangXuat = frmReportPhieuXuat.cacDangXuat + ten + " , "
            '    Sql += " SELECT     dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN, dbo.IC_DON_HANG_XUAT.NGAY, dbo.IC_DON_HANG_XUAT.MS_KHO, dbo.IC_KHO.TEN_KHO, dbo.DANG_XUAT.DANG_XUAT_VIET, dbo.IC_DON_HANG_XUAT.LY_DO_XUAT, dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU, View_GT_DH_XUAT.GIA_TRI "
            '    Sql += " FROM IC_DON_HANG_XUAT , View_GT_DH_XUAT , IC_KHO , DANG_XUAT  "
            '    Sql += " Where dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = View_GT_DH_XUAT.MS_DH_XUAT_PT and dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO  and dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT  "
            '    Sql += " And dbo.IC_KHO.MS_KHO = dbo.IC_DON_HANG_XUAT.MS_KHO  And dbo.IC_DON_HANG_XUAT.MS_KHO = '" + maKho + "'  "
            '    Sql += " And dbo.DANG_XUAT.MS_DANG_XUAT = '" + msNhap + "'"
            '    Sql += " And dbo.IC_DON_HANG_XUAT.Ngay Between '" + ngay1 + "' and '" + ngay2 + "'"
            '    Sql += " union "
            '    arrSql.Add(Sql)
            'End If
        Next
        '        sqlColection = arrSql
        Return arrSql
    End Function
    ' Xuat bao cao
    Public Function XuatBaoCao(ByVal arrSql As Collection) As DataSet
        Dim i As Integer
        Dim ds As New DataSet
        Dim sql As String = ""
        For i = 1 To arrSql.Count
            sql += arrSql(i).ToString
        Next
        If (sql.Length > 1) Then
            sql = sql.Substring(0, sql.Length - "union ".Length)
            sql += " Order by Ngay"
            sqlColection = sql
            ds = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            btnThucHien.Enabled = True
        Else
            'btThucHien.Enabled = False
            MessageBox.Show("Chưa chọn dữ liệu để in", "Thông báo", MessageBoxButtons.OK)
        End If
        Return ds
    End Function

    Public Function Get_MaKho(ByVal tenKho As String) As String
        Dim maKho As String
        Commons.Modules.SQLString = "Select MS_KHO From IC_KHO Where TEN_KHO like N'%" + tenKho + "%'"
        maKho = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString).ToString
        Return maKho
    End Function

    Private Sub cmbKho_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles cmbKho.SelectedIndexChanged
        GetTuNgay_DenNgay(daTimeTuNgay.Value.Date, daTimeDenNgay.Value.Date)
        LoadGrid_PhieuXuat(cmbKho.Text, tuNgay, denNgay)
    End Sub
    ' Tao tieu de cho report
    Public Sub CreateTitleObjectReport()
        Dim TIEU_DE, NGAY_IN, XUAT_TU_KHO, TU_NGAY, DEN_NGAY, CHO_CAC_DANG_XUAT As String
        Dim SO_PHIEU_XUAT, NGAY, TEN_KHO, SO_CHUNG_TU, LY_DO_XUAT, MUC_DICH_XUAT, GIA_TRI As String
        Dim DIEN_THOAI, FAX, NGAY_THANG_NAM, TRANG_IN, TONG_SO, TONG_CONG As String
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "TIEU_DE", Commons.Modules.TypeLanguage)
        NGAY_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "NGAY_IN", Commons.Modules.TypeLanguage)
        XUAT_TU_KHO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "XUAT_TU_KHO", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "DEN_NGAY", Commons.Modules.TypeLanguage)
        CHO_CAC_DANG_XUAT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "CHO_CAC_DANG_XUAT", Commons.Modules.TypeLanguage)
        SO_PHIEU_XUAT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "SO_PHIEU_XUAT", Commons.Modules.TypeLanguage)
        NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "NGAY", Commons.Modules.TypeLanguage)
        TEN_KHO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "TEN_KHO", Commons.Modules.TypeLanguage)
        SO_CHUNG_TU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "SO_CHUNG_TU", Commons.Modules.TypeLanguage)
        LY_DO_XUAT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "LY_DO_XUAT", Commons.Modules.TypeLanguage)
        MUC_DICH_XUAT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "MUC_DICH_XUAT", Commons.Modules.TypeLanguage)

        GIA_TRI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "GIA_TRI", Commons.Modules.TypeLanguage)
        DIEN_THOAI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "DIEN_THOAI", Commons.Modules.TypeLanguage)
        FAX = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "FAX", Commons.Modules.TypeLanguage)
        NGAY_THANG_NAM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "NGAY_THANG_NAM", Commons.Modules.TypeLanguage)
        TRANG_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "TRANG_IN", Commons.Modules.TypeLanguage)
        TONG_SO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "TONG_SO", Commons.Modules.TypeLanguage)
        TONG_CONG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachPhieuXuat", "TONG_CONG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDanhSachPhieuXuat_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDanhSachPhieuXuat_TMP "
        SqlText += " (TypeLanguage int ,TIEU_DE nvarchar(250), NGAY_IN nvarchar(50), XUAT_TU_KHO nvarchar(250), TU_NGAY nvarchar(50), DEN_NGAY nvarchar(50), "
        SqlText += " CHO_CAC_DANG_XUAT nvarchar(400), SO_PHIEU_XUAT nvarchar(50), NGAY nvarchar(50),TEN_KHO nvarchar(250),SO_CHUNG_TU nvarchar(50),LY_DO_XUAT nvarchar(250), MUC_DICH_XUAT nvarchar(250), GIA_TRI nvarchar(50) , "
        SqlText += " DIEN_THOAI nvarchar(15), FAX nvarchar(20), NGAY_THANG_NAM nvarchar(250), TRANG_IN nvarchar(250), TONG_SO nvarchar(30), TONG_CONG nvarchar(30) )"
        SqlText += " INSERT INTO [DBO].rptDanhSachPhieuXuat_TMP(commons.Modules.TypeLanguage,TIEU_DE, NGAY_IN ,XUAT_TU_KHO,TU_NGAY, "
        SqlText += " DEN_NGAY,CHO_CAC_DANG_XUAT,SO_PHIEU_XUAT,NGAY ,TEN_KHO,SO_CHUNG_TU,LY_DO_XUAT, MUC_DICH_XUAT,GIA_TRI, "
        SqlText += " DIEN_THOAI,FAX, NGAY_THANG_NAM ,TRANG_IN, TONG_SO, TONG_CONG )"
        SqlText += " VALUES(" & Commons.Modules.TypeLanguage & ",N'" & TIEU_DE & "',N'" & NGAY_IN & "',N'" & XUAT_TU_KHO & "',"
        SqlText += " N'" & TU_NGAY & "',N'" & DEN_NGAY & "',N'" & CHO_CAC_DANG_XUAT & "',N'" & SO_PHIEU_XUAT & "',N'" & NGAY & "',N'" & TEN_KHO & "',"
        SqlText += " N'" & SO_CHUNG_TU & "',N'" & LY_DO_XUAT & "',N'" & MUC_DICH_XUAT & "',N'" & GIA_TRI & "', "
        SqlText += " N'" & DIEN_THOAI & "',N'" & FAX & "',N'" & NGAY_THANG_NAM & "',N'" & TRANG_IN & "',N'" & TONG_SO & "',N'" & TONG_CONG & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub

    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        Try
            SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngayanh & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "' INTO [dbo].rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
    End Sub
    ' Ghi du lieu chung ra file xml
    Public Sub WriteXml()
        Dim frmShow As frmXMLReport = New frmXMLReport()

        RefeshHeaderReport()
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        ' Lay tieu de
        Dim sql As String
        Try
            Dim dt As New DataTable
            sql = "Select * From rptTHONG_TIN_CHUNG_TMP "
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            dt.TableName = "rptTHONG_TIN_CHUNG_TMP"
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)

        Catch ex As Exception
        End Try
        'Dim dt As New DataTable
        Try
            CreateTitleObjectReport()
            Dim dt As New DataTable
            sql = "Select * From rptDanhSachPhieuXuat_TMP "
            dt.TableName = "rptDanhSachPhieuXuat_TMP"
            da = New SqlDataAdapter(sql, Commons.IConnections.ConnectionString)
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception
        End Try
        Try
            Dim dt As New DataTable
            dt.TableName = "Values"
            da = New SqlDataAdapter(sqlColection, Commons.IConnections.ConnectionString)
            da.Fill(dt)
            'ds.Tables.Add(dt)
            frmShow.AddDataTableSource(dt)
        Catch ex As Exception
        End Try

        Try
            Dim clTenKho As DataColumn = New DataColumn("TenKho", Type.GetType("System.String"))
            Dim clTuNgay As DataColumn = New DataColumn("TuNgay", Type.GetType("System.String"))
            Dim clDenNgay As DataColumn = New DataColumn("DenNgay", Type.GetType("System.String"))
            Dim cldsDangNhap As DataColumn = New DataColumn("DSDangNhap", Type.GetType("System.String"))
            Dim Tb As DataTable = New DataTable("TIEU_DE")
            Tb.Columns.Add(clTenKho)
            Tb.Columns.Add(clTuNgay)
            Tb.Columns.Add(clDenNgay)
            Tb.Columns.Add(cldsDangNhap)

            Dim rows As DataRow = Tb.NewRow()
            rows("TenKho") = cmbKho.Text
            rows("TuNgay") = daTimeTuNgay.Text
            rows("DenNgay") = daTimeDenNgay.Text
            Dim dsDangNhap As String = ""

            Try
                For Each gvrow As DataGridViewRow In Me.gvPhieuXuatKho.Rows
                    If gvrow.Cells("CHON").Value = True Then
                        dsDangNhap = dsDangNhap & " - " & gvrow.Cells("DANG_XUAT").Value
                    End If
                Next
            Catch ex As Exception
            End Try
            rows("DSDangNhap") = dsDangNhap

            Tb.Rows.Add(rows)
            'ds.Tables.Add(Tb)
            frmShow.AddDataTableSource(Tb)
        Catch ex As Exception
        End Try

        Try

        Catch ex As Exception
        End Try

        frmShow.rptName = "rptDanhSachPhieuXuatKho"
        frmShow.ShowDialog()

    End Sub

    Private Sub cmbKho_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbKho.KeyDown
        cmbKho.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim arrSql As Collection
        arrSql = DuyetGridView()
        Dim ds As DataSet

        ds = XuatBaoCao(arrSql)
        If (ds.Tables.Count > 0) Then
            WriteXml()
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Try
            SqlText = "DROP TABLE dbo.rptDanhSachPhieuXuat_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Me.ParentForm.Close()
    End Sub
End Class
