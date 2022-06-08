
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class frmrptTON_KHO_THEO_PHIEU_NHAP
    Private SqlText As String = String.Empty
    Dim vtbThongtinchung As DataTable = New DataTable()
    Private Sub frmrptTON_KHO_THEO_PHIEU_NHAP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_KHO_KHO", Commons.Modules.UserName))
        cboKho.DataSource = dt
        cboKho.DisplayMember = "TEN_KHO"
        cboKho.ValueMember = "MS_KHO"
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'clsXuLy.CreateTitleReport()
        'ShowrptTON_KHO_THEO_PHIEU_NHAP()
        WriteXml()
        Me.Cursor = Cursors.Default
    End Sub
    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        'Dim source As DataSet = New DataSet()
        'Try
        '    SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        'Catch ex As Exception
        'End Try
        vtbThongtinchung = New DataTable("rptTHONG_TIN_CHUNG_TMP")
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            'SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & TDateFormat(Now) & "',tenngayin='" & ngay & "' INTO rptTHONG_TIN_CHUNG FROM THONG_TIN_CHUNG "
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
    End Sub
    Sub WriteXml()
        Dim frmRP As frmXMLReport = New frmXMLReport()
        Dim vtbValue As DataTable = New DataTable()
        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetThietBiConHanBaoHanh", vDay, cbxNhaXuong.SelectedValue, cboLoaiTB.SelectedValue))

        'createData()
        Dim Str As String

        Str = " SELECT DISTINCT dbo.VI_TRI_KHO_VAT_TU.MS_KHO, dbo.VI_TRI_KHO_VAT_TU.MS_PT, dbo.IC_PHU_TUNG.TEN_PT, dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT, " & _
                " dbo.VI_TRI_KHO_VAT_TU.SL_VT, dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA, dbo.IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE,  " & _
                " dbo.VI_TRI_KHO_VAT_TU.SL_VT * dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA * dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA AS THANH_TIEN,  " & _
                " dbo.VI_TRI_KHO_VAT_TU.SL_VT * dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA * dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA_USD AS THANH_TIEN_USD,  " & _
                " dbo.IC_PHU_TUNG.QUY_CACH, (CASE 0 WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 END) AS DVT, dbo.IC_KHO.TEN_KHO, dbo.IC_DON_HANG_NHAP.NGUOI_NHAP,  " & _
                " ISNULL ((SELECT     TEN_CONG_TY FROM         dbo.KHACH_HANG WHERE     (MS_KH = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)), '') + ISNULL " & _
                " ((SELECT     HO + ' ' + TEN AS HO_TEN FROM         dbo.CONG_NHAN WHERE     (MS_CONG_NHAN = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)), '') AS TEN_NGUOI_NHAP,  " & _
                " dbo.IC_DON_HANG_NHAP.NGAY, dbo.IC_DON_HANG_NHAP_VAT_TU.BAO_HANH_DEN_NGAY, dbo.VI_TRI_KHO.TEN_VI_TRI, dbo.VI_TRI_KHO_VAT_TU.ID " & _
                " FROM         dbo.VI_TRI_KHO_VAT_TU INNER JOIN " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET ON dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.ID = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID INNER JOIN " & _
                " dbo.IC_PHU_TUNG ON dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU ON dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " & _
                " dbo.IC_PHU_TUNG.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND dbo.VI_TRI_KHO_VAT_TU.ID = dbo.IC_DON_HANG_NHAP_VAT_TU.ID INNER JOIN " & _
                " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT INNER JOIN " & _
                " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT LEFT OUTER JOIN " & _
                " dbo.KHACH_HANG AS KHACH_HANG_1 ON dbo.IC_PHU_TUNG.MS_KH = KHACH_HANG_1.MS_KH INNER JOIN " & _
                " dbo.IC_KHO ON dbo.VI_TRI_KHO_VAT_TU.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " & _
                " dbo.VI_TRI_KHO ON dbo.VI_TRI_KHO.MS_KHO = dbo.VI_TRI_KHO_VAT_TU.MS_KHO AND dbo.VI_TRI_KHO.MS_VI_TRI = dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI " & _
                " WHERE VI_TRI_KHO_VAT_TU.MS_KHO= '" & cboKho.SelectedValue & "' AND VI_TRI_KHO_VAT_TU.SL_VT>0"
        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM TON_KHO_THEO_PHIEU_NHAP"))

        vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, Str))
        vtbValue.TableName = "TON_KHO_THEO_PHIEU_NHAP"
        frmRP.rptName = "rptTON_KHO_THEO_PHIEU_NHAP"

        If vtbValue.Rows.Count > 0 Then
            Dim vtblg As DataTable = New DataTable()
            RefeshHeaderReport()
            vtblg = CreaterptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP()
            frmRP.AddDataTableSource(vtbThongtinchung)
            frmRP.AddDataTableSource(vtblg)
            frmRP.AddDataTableSource(vtbValue)
            frmRP.ShowDialog()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "KhongCoDuLieuDeIn", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
    End Sub
    Sub createData()
        If cboKho.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        Try
            str = "DROP TABLE TON_KHO_THEO_PHIEU_NHAP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = " SELECT DISTINCT dbo.VI_TRI_KHO_VAT_TU.MS_KHO, dbo.VI_TRI_KHO_VAT_TU.MS_PT, dbo.IC_PHU_TUNG.TEN_PT, dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT, " & _
                " dbo.VI_TRI_KHO_VAT_TU.SL_VT, dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA, dbo.IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE,  " & _
                " dbo.VI_TRI_KHO_VAT_TU.SL_VT * dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA * dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA AS THANH_TIEN,  " & _
                " dbo.VI_TRI_KHO_VAT_TU.SL_VT * dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA * dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA_USD AS THANH_TIEN_USD,  " & _
                " dbo.IC_PHU_TUNG.QUY_CACH, (CASE 0 WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 END) AS DVT, dbo.IC_KHO.TEN_KHO, dbo.IC_DON_HANG_NHAP.NGUOI_NHAP,  " & _
                " ISNULL ((SELECT     TEN_CONG_TY FROM         dbo.KHACH_HANG WHERE     (MS_KH = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)), '') + ISNULL " & _
                " ((SELECT     HO + ' ' + TEN AS HO_TEN FROM         dbo.CONG_NHAN WHERE     (MS_CONG_NHAN = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP)), '') AS TEN_NGUOI_NHAP,  " & _
                " dbo.IC_DON_HANG_NHAP.NGAY, dbo.IC_DON_HANG_NHAP_VAT_TU.BAO_HANH_DEN_NGAY, dbo.VI_TRI_KHO.TEN_VI_TRI, dbo.VI_TRI_KHO_VAT_TU.ID " & _
                " INTO TON_KHO_THEO_PHIEU_NHAP FROM         dbo.VI_TRI_KHO_VAT_TU INNER JOIN " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET ON dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.ID = dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID INNER JOIN " & _
                " dbo.IC_PHU_TUNG ON dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU ON dbo.VI_TRI_KHO_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " & _
                " dbo.VI_TRI_KHO_VAT_TU.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " & _
                " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " & _
                " dbo.IC_PHU_TUNG.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND dbo.VI_TRI_KHO_VAT_TU.ID = dbo.IC_DON_HANG_NHAP_VAT_TU.ID INNER JOIN " & _
                " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT INNER JOIN " & _
                " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT LEFT OUTER JOIN " & _
                " dbo.KHACH_HANG AS KHACH_HANG_1 ON dbo.IC_PHU_TUNG.MS_KH = KHACH_HANG_1.MS_KH INNER JOIN " & _
                " dbo.IC_KHO ON dbo.VI_TRI_KHO_VAT_TU.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " & _
                " dbo.VI_TRI_KHO ON dbo.VI_TRI_KHO.MS_KHO = dbo.VI_TRI_KHO_VAT_TU.MS_KHO AND dbo.VI_TRI_KHO.MS_VI_TRI = dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI " & _
                " WHERE VI_TRI_KHO_VAT_TU.MS_KHO= '" & cboKho.SelectedValue & "' AND VI_TRI_KHO_VAT_TU.SL_VT>0"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Function CreaterptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP() As DataTable
        'Dim str As String = ""
        'Try
        '    str = "DROP TABLE rptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP"
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        'Catch ex As Exception

        'End Try
        'str = "CREATE TABLE DBO.rptTIEU_DE_TON_KHO_THEO_PHIEU_NHAP(TypeLanguage int, TrangIn nvarchar(20)," & _
        '    "NgayIn nvarchar(20),TieuDe nvarchar(255),MaKho nvarchar(20),TenKho nvarchar(20),MaPT nvarchar(30), " & _
        '    "TenPT nvarchar(30),MaPhieuNhapKho nvarchar(20),SoLuong nvarchar(20),DonGia nvarchar(20), " & _
        '    "NgoaiTe nvarchar(20), ThanhTien nvarchar(20),ThanhTienUSD nvarchar(30),QuyCach nvarchar(30)," & _
        '    "sDVT nvarchar(10),NguoiNhap nvarchar(20),TenNguoiNhan nvarchar(50),NgayNhap nvarchar(20)," & _
        '    "NgayBH nvarchar(20),TonKho nvarchar(30),TongPT nvarchar(30))"
        'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TieuDe6", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgayIn", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TrangIn", Commons.Modules.TypeLanguage)
        Dim sMaKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "MaKho", Commons.Modules.TypeLanguage)
        Dim sTenKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TenKho", Commons.Modules.TypeLanguage)
        Dim sMaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "MaPT", Commons.Modules.TypeLanguage)
        Dim sTenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TenPT", Commons.Modules.TypeLanguage)
        Dim sMaPhieuNhapKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "MaPhieuNhapKho", Commons.Modules.TypeLanguage)
        Dim sSoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "SoLuong", Commons.Modules.TypeLanguage)
        Dim sDonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "DonGia", Commons.Modules.TypeLanguage)
        Dim sNgoaiTe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgoaiTe", Commons.Modules.TypeLanguage)
        Dim sThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "ThanhTien", Commons.Modules.TypeLanguage)
        Dim sThanhTienUSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "ThanhTienUSD", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sDVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "sDVT", Commons.Modules.TypeLanguage)
        Dim sNguoiNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NguoiNhap", Commons.Modules.TypeLanguage)
        Dim sTenNguoiNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TenNguoiNhan", Commons.Modules.TypeLanguage)
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgayNhap", Commons.Modules.TypeLanguage)
        Dim sNgayBH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "NgayBH", Commons.Modules.TypeLanguage)
        Dim sTonKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TonKho", Commons.Modules.TypeLanguage)
        Dim sTongPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTON_KHO_THEO_PHIEU_NHAP", "TongPT", Commons.Modules.TypeLanguage)

        Dim vTbTitle As DataTable = New DataTable()
        vTbTitle.Columns.Add("TypeLanguage", Type.GetType("System.String"))
        vTbTitle.Columns.Add("Trangin", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NgayIn", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TieuDe", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MaKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MaPT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenPT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("MaPhieuNhapKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("SoLuong", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DonGia", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NgoaiTe", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ThanhTien", Type.GetType("System.String"))
        vTbTitle.Columns.Add("ThanhTienUSD", Type.GetType("System.String"))

        vTbTitle.Columns.Add("QuyCach", Type.GetType("System.String"))
        vTbTitle.Columns.Add("sDVT", Type.GetType("System.String"))

        vTbTitle.Columns.Add("NguoiNhap", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TenNguoiNhan", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NgayNhap", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NgayBH", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TonKho", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TongPT", Type.GetType("System.String"))
        Dim rowNew As DataRow = vTbTitle.NewRow()
        rowNew("TypeLanguage") = Commons.Modules.TypeLanguage
        rowNew("Trangin") = sTrangIn
        rowNew("NgayIn") = sNgayIn
        rowNew("TieuDe") = sTieudeReport
        rowNew("MaKho") = sMaKho
        rowNew("TenKho") = sTenKho
        rowNew("MaPT") = sMaPT
        rowNew("TenPT") = sTenPT
        rowNew("MaPhieuNhapKho") = sMaPhieuNhapKho
        rowNew("SoLuong") = sSoLuong
        rowNew("DonGia") = sDonGia
        rowNew("NgoaiTe") = sNgoaiTe
        rowNew("ThanhTien") = sThanhTien
        rowNew("ThanhTienUSD") = sThanhTienUSD

        rowNew("sDVT") = sDVT
        rowNew("QuyCach") = sQuyCach
        rowNew("NguoiNhap") = sTenNguoiNhan
        rowNew("TenNguoiNhan") = sTenNguoiNhan
        rowNew("NgayNhap") = sNgayNhap
        rowNew("NgayBH") = sNgayBH
        rowNew("TonKho") = sTonKho
        rowNew("TongPT") = sTongPT
        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle

    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
