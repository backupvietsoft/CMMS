
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptDSCPBTTLoaiMay_LoaiTB1
    Private SqlText As String
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmrptDSCPBTTLoaiMay_LoaiTB_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpTuNgay.Value = DateTime.Now.AddMonths(-1)
        dtpDenNgay.Value = DateTime.Now
        loadCboLoaiTB()
        loadCboDiaDiem1()
    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        If rdLoaiMay_DD.Checked Then
            Call CreateData15()
            Call Printpreview15()
        Else
            Call CreateData14()
            Call Printpreview14()
        End If
    End Sub
    Private Sub loadCboLoaiTB()
        Dim str As String = ""
        'If cboDiaDiem1.Text = "" Then
        '    Exit Sub
        'End If
        str = "SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY " & _
        " FROM LOAI_MAY INNER JOIN NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
        " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID INNER JOIN NHOM_NHA_XUONG ON NHOM.GROUP_ID = NHOM_NHA_XUONG.GROUP_ID " & _
        " INNER JOIN USERS ON NHOM.GROUP_ID=USERS.GROUP_ID WHERE USERNAME='" & Commons.Modules.UserName & "'"
        cboLoaiTB1.DisplayMember = "TEN_LOAI_MAY"
        cboLoaiTB1.ValueMember = "MS_LOAI_MAY"
        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow(0) = -1
        dtRow(1) = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)
        cboLoaiTB1.DataSource = dt
        If cboLoaiTB1.Items.Count = 0 Then
            cboLoaiTB1.Text = ""
        End If
    End Sub
    Private Sub loadCboDiaDiem1()
        cboDiaDiem1.ValueMember = "MS_N_XUONG"
        cboDiaDiem1.DisplayMember = "TEN_N_XUONG"
        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionNHA_XUONG", Commons.Modules.UserName))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow(0) = -1
        dtRow(1) = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)
        cboDiaDiem1.DataSource = dt
    End Sub
    Private Sub RefeshHeaderReport()
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
    Private Sub RefeshLanguageReport15()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "DEN_NGAY", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "DIA_DIEM", Commons.Modules.TypeLanguage)
        NHOM_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NHOM_TB", Commons.Modules.TypeLanguage)
        TEN_LOAI_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TEN_LOAI_TB", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "STT", Commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "YEU_CAU", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "MS_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "NGAY_KT", Commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TT_TRUOC_BT", Commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TT_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_DiaDiem", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP(TIEU_DE_ nvarchar(250), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), DIA_DIEM_ nvarchar(50),NHOM_TB_ nvarchar(50),TEN_LOAI_TB_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50),TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCPBTTLoaiMay_DiaDiem", TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub


    Sub CreateData15()

        RefeshHeaderReport()
        RefeshLanguageReport15()

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String = (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        date_DN = dtpDenNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        date_TN = dtpTuNgay.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        If rdLMDaNghiemThu.Checked Then
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT > 2)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE    (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "') AND  (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT > 2) order by NGAY_BD_KH desc"
            End If
        Else
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT < 3)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT distinct CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_DiaDiem_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE     (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "') AND (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND DateAdd(day,1,'" & date_DN & "')) AND  (dbo.PHIEU_BAO_TRI.TINH_TRANG_PBT < 3) order by NGAY_BD_KH desc"
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub
    Sub Printpreview15()
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCPBTTLoaiMay_DiaDiem_TMP")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB1", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()

        Cursor = Cursors.WaitCursor

        Call ReportPreview("reports\rptDSCPBTTLoaiMay_DiaDiem.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_DiaDiem_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RefeshLanguageReport14()
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TIEU_DE", Commons.Modules.TypeLanguage)
        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TU_NGAY", Commons.Modules.TypeLanguage)
        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "DEN_NGAY", Commons.Modules.TypeLanguage)
        DIA_DIEM = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "DIA_DIEM", Commons.Modules.TypeLanguage)
        NHOM_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "NHOM_TB", Commons.Modules.TypeLanguage)
        TEN_LOAI_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TEN_LOAI_TB", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "STT", Commons.Modules.TypeLanguage)
        YEU_CAU = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "YEU_CAU", Commons.Modules.TypeLanguage)
        MS_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "MS_TB", Commons.Modules.TypeLanguage)
        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "LOAI_BT", Commons.Modules.TypeLanguage)
        NGAY_BD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "NGAY_BD", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "NGAY_KT", Commons.Modules.TypeLanguage)
        TT_TRUOC_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TT_TRUOC_BT", Commons.Modules.TypeLanguage)
        TT_SAU_BT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TT_SAU_BT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_lbl_TMP(TIEU_DE_ nvarchar(250), TU_NGAY_ nvarchar(50), DEN_NGAY_ nvarchar(50), DIA_DIEM_ nvarchar(50),NHOM_TB_ nvarchar(50),TEN_LOAI_TB_ nvarchar(50),STT_ nvarchar(50),YEU_CAU_ nvarchar(50),MS_TB_ nvarchar(50), LOAI_BT_ nvarchar(50), NGAY_BD_ nvarchar(50), NGAY_KT_ nvarchar(50), TT_TRUOC_BT_ nvarchar(50), TT_SAU_BT_ nvarchar(50),TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptDSCPBTTLoaiMay_LoaiTB", TIEU_DE, TU_NGAY, DEN_NGAY, DIA_DIEM, NHOM_TB, TEN_LOAI_TB, STT, YEU_CAU, MS_TB, LOAI_BT, NGAY_BD, NGAY_KT, TT_TRUOC_BT, TT_SAU_BT, TRANG)

    End Sub


    Sub CreateData14()

        RefeshHeaderReport()
        RefeshLanguageReport14()
        Cursor = Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Dim ngay_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Day
        Dim thang_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Month
        Dim nam_TN As String = Convert.ToDateTime(dtpTuNgay.Value.ToString()).Year
        Dim date_TN As String = (thang_TN & "/" & ngay_TN & "/" & nam_TN)
        Dim ngay_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Day
        Dim thang_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Month
        Dim nam_DN As String = Convert.ToDateTime(dtpDenNgay.Value.ToString()).Year
        Dim date_DN As String = (thang_DN & "/" & ngay_DN & "/" & nam_DN)

        If rdLMDaNghiemThu.Checked Then
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS not  NULL)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE     (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "')AND (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS not NULL) order by NGAY_BD_KH desc"
            End If
        Else
            If rdLoaiMay_DD.Checked Then
                SqlText = "SELECT DISTINCT CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS  NULL)  order by NGAY_BD_KH desc"
            Else
                SqlText = "SELECT  DISTINCT CAST('" & date_TN & "' AS DATETIME) AS TU_NGAY, CAST('" & date_DN & "' AS DATETIME) AS DEN_NGAY, dbo.NHA_XUONG.Ten_N_XUONG, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY, dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI, dbo.MAY.MS_MAY, dbo.LOAI_BAO_TRI.TEN_LOAI_BT, dbo.PHIEU_BAO_TRI.NGAY_BD_KH, dbo.PHIEU_BAO_TRI.NGAY_KT_KH, dbo.PHIEU_BAO_TRI.LY_DO_BT AS TINH_TRANG_PBT, dbo.PHIEU_BAO_TRI.TT_SAU_BT        INTO [dbo].rptDSCPBTTLoaiMay_LoaiTB_TMP       FROM  dbo.LOAI_BAO_TRI INNER JOIN  dbo.PHIEU_BAO_TRI ON dbo.LOAI_BAO_TRI.MS_LOAI_BT = dbo.PHIEU_BAO_TRI.MS_LOAI_BT INNER JOIN dbo.MAY INNER JOIN  dbo.MAY_NHA_XUONG ON dbo.MAY.MS_MAY = dbo.MAY_NHA_XUONG.MS_MAY INNER JOIN  dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN  dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN  dbo.NHA_XUONG ON dbo.MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE      (dbo.LOAI_MAY.MS_LOAI_MAY = '" & cboLoaiTB1.SelectedValue.ToString() & "')AND (dbo.NHA_XUONG.MS_N_XUONG = '" & cboDiaDiem1.SelectedValue.ToString() & "') AND (dbo.PHIEU_BAO_TRI.NGAY_LAP BETWEEN '" & date_TN & "' AND '" & date_DN & "') AND (dbo.PHIEU_BAO_TRI.NGAY_NGHIEM_THU IS  NULL) order by NGAY_BD_KH desc"
            End If
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)


    End Sub
    Sub Printpreview14()
        Try
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*)AS TONG FROM rptDSCPBTTLoaiMay_LoaiTB_TMP")
            While objReader.Read
                If objReader.Item("TONG") = 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSCPBTTLoaiMay_LoaiTB1", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Me.Cursor = Cursors.Default
                    objReader.Close()
                    GoTo KetThuc
                End If
            End While
            objReader.Close()
        Catch ex As Exception
        End Try
        Call ReportPreview("reports\rptDSCPBTTLoaiMay_LoaiTB.rpt")
        Cursor = Cursors.Default
KetThuc:
        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try

        Try
            SqlText = "DROP TABLE dbo.rptDSCPBTTLoaiMay_LoaiTB_lbl_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE dbo.rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub rdLoaiMay_LoaiTB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLoaiMay_LoaiTB.CheckedChanged
        cboLoaiTB1.SelectedIndex = 0
        cboDiaDiem1.Enabled = False
        cboLoaiTB1.Enabled = True
    End Sub


    Private Sub rdLoaiMay_DD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdLoaiMay_DD.CheckedChanged
        cboDiaDiem1.SelectedIndex = 0
        cboDiaDiem1.Enabled = True
        cboLoaiTB1.Enabled = False
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
