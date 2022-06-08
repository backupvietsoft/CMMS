
Imports Microsoft.ApplicationBlocks.Data
Imports H.UserControl
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmrptPhanTichChiPhi_DUYTAN
    Private vData As New DataTable()
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Private vSort As String = "DESC"

    Private Sub frmrptPhanTichChiPhi_DUYTAN_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.PHAN_TICH_CHI_PHI_TMP" + Commons.Modules.UserName)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmrptPhanTichChiPhi_DUYTAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        'btnThucHien.Visible = False
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddMonths(-1).Date
        dtTNgay.DateTime = vTuNgay.ToString("dd/MM/yyyy")
        dtDNgay.DateTime = vDenNgay.ToString("dd/MM/yyyy")
        vData = loadData()
        CreateData(vData)
        ViewData()
        RefreshLanguages()
    End Sub

    Private Sub RefreshLanguages()
        clNhaxuong.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "NHA_XUONG", Commons.Modules.TypeLanguage)
        clPhuTung.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_TP_KH", Commons.Modules.TypeLanguage)
        clVatTu.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_VT_KH", Commons.Modules.TypeLanguage)
        clDichVu.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_DV_KH", Commons.Modules.TypeLanguage)
        clNhanCong.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_NC_KH", Commons.Modules.TypeLanguage)
        clHangNgay.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_KHAC_KH", Commons.Modules.TypeLanguage)
        clKhac.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_HN_KH", Commons.Modules.TypeLanguage)
        clTong.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_TONG", Commons.Modules.TypeLanguage)

        clPhuTunghh.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_TP_KKH", Commons.Modules.TypeLanguage)
        clVatTuhh.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_VT_KKH", Commons.Modules.TypeLanguage)
        clDichVuhh.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_DV_KKH", Commons.Modules.TypeLanguage)
        clNhanConghh.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_NC_KKH", Commons.Modules.TypeLanguage)
        clHangNgayhh.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_KHAC_KKH", Commons.Modules.TypeLanguage)
        clTongcokh.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_TONG_KH", Commons.Modules.TypeLanguage)
        clTongkkh.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CP_TONG_KKH ", Commons.Modules.TypeLanguage)

    End Sub

    Function loadData() As DataTable
        Dim vtb As New DataTable()
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DATA_PHAN_TICH_CHI_PHI", vTuNgay, vDenNgay, Commons.Modules.UserName))
        Return vtb
    End Function

    Private Sub CreateData(ByVal vtb As DataTable)
        'Dim vtb As New DataTable()
        'vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DATA_PHAN_TICH_CHI_PHI", vTuNgay, vDenNgay, Commons.Modules.UserName))
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DROP TABLE dbo.PHAN_TICH_CHI_PHI_TMP" + Commons.Modules.UserName)
        Catch ex As Exception
        End Try
        Try
            Dim vSQL As String = "CREATE TABLE dbo.PHAN_TICH_CHI_PHI_TMP" + Commons.Modules.UserName + _
            " (MS_PHIEU_BAO_TRI NVARCHAR(30), 	MS_MAY NVARCHAR(30),  MS_N_XUONG NVARCHAR(50), TEN_N_XUONG NVARCHAR(100)," & _
            " MS_HE_THONG INT, TEN_HE_THONG NVARCHAR(100),  MS_LOAI_MAY NVARCHAR(20), " & _
            " TEN_LOAI_MAY NVARCHAR(100), MS_NHOM_MAY NVARCHAR(20), TEN_NHOM_MAY NVARCHAR(100), MS_BP_CHIU_PHI INT, " & _
            " TEN_BP_CHIU_PHI NVARCHAR(100), CHI_PHI_PHU_TUNG FLOAT, CHI_PHI_VAT_TU FLOAT, CHI_PHI_NHAN_CONG FLOAT, " & _
            " CHI_PHI_DV FLOAT, CHI_PHI_KHAC FLOAT,	CHI_PHI_HANG_NGAY FLOAT	, TONG FLOAT ,HU_HONG INT)"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, vSQL)
        Catch ex As Exception
        End Try
        If (vtb.Rows.Count > 0) Then
            For Each vrow As DataRow In vtb.Rows
                Dim sqlInsert As String = " INSERT INTO dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & _
                     " ( MS_PHIEU_BAO_TRI,MS_MAY,MS_N_XUONG,TEN_N_XUONG,MS_HE_THONG,TEN_HE_THONG,MS_LOAI_MAY, " & _
                     " TEN_LOAI_MAY,MS_NHOM_MAY,TEN_NHOM_MAY,MS_BP_CHIU_PHI,TEN_BP_CHIU_PHI,CHI_PHI_PHU_TUNG, " & _
                     " CHI_PHI_VAT_TU,CHI_PHI_NHAN_CONG,CHI_PHI_DV,CHI_PHI_KHAC,CHI_PHI_HANG_NGAY,TONG,HU_HONG) " & _
                     " VALUES( N'" & vrow("MS_PHIEU_BAO_TRI") & "',N'" & vrow("MS_MAY") & "',N'" & vrow("MS_N_XUONG") & "',N'" & vrow("TEN_N_XUONG") & "','" & _
                     vrow("MS_HE_THONG") & "',N'" & vrow("TEN_HE_THONG") & "','" & vrow("MS_LOAI_MAY") & "',N'" & _
                     vrow("TEN_LOAI_MAY") & "','" & vrow("MS_NHOM_MAY") & "',N'" & vrow("TEN_NHOM_MAY") & "','" & _
                     vrow("MS_BP_CHIU_PHI") & "',N'" & vrow("TEN_BP_CHIU_PHI") & "','" & vrow("CHI_PHI_PHU_TUNG") & "','" & _
                     vrow("CHI_PHI_VAT_TU") & "','" & vrow("CHI_PHI_NHAN_CONG") & "','" & vrow("CHI_PHI_DV") & "','" & _
                     vrow("CHI_PHI_KHAC") & "','" & vrow("CHI_PHI_HANG_NGAY") & "','" & vrow("TONG") & "','" & vrow("HU_HONG") & "')"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sqlInsert)
            Next
        End If

    End Sub

    Function DataNhaMay() As DataTable
        Dim vtb As New DataTable()
        Dim VSQL As String = "SELECT" & _
            "(SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 0 )AS CHI_PHI_PHU_TUNG_KH ,  " & _
            "(SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 1)AS CHI_PHI_PHU_TUNG_KKH,	" & _
            "(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 0 )AS CHI_PHI_VAT_TU_KH,  " & _
            "(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 1 )AS CHI_PHI_VAT_TU_KKH, " & _
            "(SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 0 )AS CHI_PHI_NHAN_CONG_KH," & _
            "(SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 1 )AS CHI_PHI_NHAN_CONG_KKH,   " & _
            "(SELECT     SUM(CHI_PHI_DV) AS TONG_CP FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 0 )AS CHI_PHI_DV_KH, " & _
            "(SELECT     SUM(CHI_PHI_DV) AS TONG_CP FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 1 )AS CHI_PHI_DV_KKH,   " & _
            "(SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 0 )AS CHI_PHI_KHAC_KH, " & _
            "(SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 1)AS CHI_PHI_KHAC_KKH, " & _
            " SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY,  " & _
            "(SELECT     SUM(TONG) AS TONG_KH   FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 WHERE      HU_HONG = 0 ) AS TONG_KH, " & _
            "(SELECT     SUM(TONG) AS TONG_KKH  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1  WHERE      HU_HONG = 1 ) AS TONG_KKH, " & _
            " SUM(TONG) AS TONG " & _
            " FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP  ORDER BY TONG DESC"
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataNhaxuong() As DataTable
        Dim vtb As New DataTable()
        Dim VSQL As String = "SELECT MS_N_XUONG, TEN_N_XUONG," & _
  " (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
                 " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 0 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_PHU_TUNG_KH , " & _
   " (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
                  " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 1 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_PHU_TUNG_KKH," & _
 "	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
               " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 0 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_VAT_TU_KH, " & _
  " (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
                  " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 1 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_VAT_TU_KKH," & _
 " (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
                 " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 0 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_NHAN_CONG_KH," & _
  " (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
                 " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 1 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_NHAN_CONG_KKH,  " & _
  " (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
                 " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 0 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_DV_KH," & _
  " (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
                 " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 1 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_DV_KKH,  " & _
  " (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
             "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 0 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_KHAC_KH," & _
  " (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
                 " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                 " WHERE      HU_HONG = 1 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG)AS CHI_PHI_KHAC_KKH, " & _
                 " SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY, " & _
  " (SELECT     SUM(TONG) AS TONG_KH " & _
                 "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                   " WHERE      HU_HONG = 0 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG) AS TONG_KH," & _
  " (SELECT     SUM(TONG) AS TONG_KKH" & _
                  " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
                  "  WHERE      HU_HONG = 1 AND TMP1.MS_N_XUONG = TMP.MS_N_XUONG) AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
 " GROUP BY TMP.MS_N_XUONG, TMP.TEN_N_XUONG ORDER BY TONG DESC"
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataHeThong(ByVal _vNhaXuong As String) As DataTable
        Dim vtb As New DataTable()


        Dim VSQL As String = "SELECT TMP.MS_HE_THONG, TMP.TEN_HE_THONG," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 0 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
          " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 1 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 0 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " ) AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
          " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 1 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 0 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 1 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 0 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " ) AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 1 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
     "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 0 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND  " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 1 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND  " & _
         " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
         " )AS CHI_PHI_KHAC_KKH, " & _
         " SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
         "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
           " WHERE      HU_HONG = 0 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND  " & _
           " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
           " ) AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
          " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
          "  WHERE      HU_HONG = 1 AND TMP1.MS_HE_THONG = TMP.MS_HE_THONG AND  " & _
          " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
          " ) AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
" WHERE TMP.MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
" GROUP BY TMP.MS_HE_THONG, TMP.TEN_HE_THONG ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataLoaiMay(ByVal _vNhaXuong As String) As DataTable
        Dim vtb As New DataTable()
        Dim sNX As String
        sNX = " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) "

        Dim VSQL As String = "SELECT TMP.MS_LOAI_MAY, TMP.TEN_LOAI_MAY," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 0 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & ")AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 1 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & ")AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 0 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & ")AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & ")AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY  AND " & sNX & ")AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
         " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & ")AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & ")AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & ")AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
        "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & " )AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
         " WHERE      HU_HONG = 1 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY  AND " & sNX & " )AS CHI_PHI_KHAC_KKH, " & _
 " SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
        "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY AND " & sNX & " ) AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        "  WHERE      HU_HONG = 1 AND TMP1.MS_LOAI_MAY = TMP.MS_LOAI_MAY  AND " & sNX & ") AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
" WHERE MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
" GROUP BY TMP.MS_LOAI_MAY, TMP.TEN_LOAI_MAY ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataNhomMayByLoaiMay(ByVal _vNhaXuong As String, ByVal _vLoaiMay As String) As DataTable
        Dim vtb As New DataTable()
        Dim sNX As String
        sNX = " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) "


        Dim VSQL As String = "SELECT TMP.MS_NHOM_MAY, TMP.TEN_NHOM_MAY," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "')AS CHI_PHI_KHAC_KKH, " & _
" SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "') AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       "  WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' ) AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
" WHERE TMP.MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
" AND TMP.MS_LOAI_MAY = '" & _vLoaiMay & "'" & _
" GROUP BY TMP.MS_NHOM_MAY, TMP.TEN_NHOM_MAY ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataNhomMayByHeThong(ByVal _vNhaXuong As String, ByVal _vHeThong As String) As DataTable
        Dim vtb As New DataTable()
        Dim sNX As String
        sNX = " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) "

        Dim VSQL As String = "SELECT TMP.MS_NHOM_MAY, TMP.TEN_NHOM_MAY," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "')AS CHI_PHI_KHAC_KKH, " & _
" SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "') AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       "  WHERE      HU_HONG = 1 AND TMP1.MS_NHOM_MAY = TMP.MS_NHOM_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "') AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
 " WHERE TMP.MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
 " AND TMP.MS_HE_THONG = '" & _vHeThong & "'" & _
" GROUP BY TMP.MS_NHOM_MAY, TMP.TEN_NHOM_MAY ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataMayByLoaiMay(ByVal _vNhaXuong As String, ByVal _vLoaiMay As String, ByVal _vNhomMay As String) As DataTable
        Dim vtb As New DataTable()
        Dim sNX As String
        sNX = " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) "

        Dim VSQL As String = "SELECT TMP.MS_MAY," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_KHAC_KKH, " & _
" SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "') AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       "  WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "') AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
" WHERE MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
" AND TMP.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP.MS_NHOM_MAY = '" & _vNhomMay & "'" & _
" GROUP BY TMP.MS_MAY ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataMaybyHeThong(ByVal _vNhaXuong As String, ByVal _vHeThong As String, ByVal _vNhomMay As String) As DataTable
        Dim vtb As New DataTable()
        Dim sNX As String
        sNX = " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) "

        Dim VSQL As String = "SELECT TMP.MS_MAY," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "')AS CHI_PHI_KHAC_KKH, " & _
" SUM(CHI_PHI_HANG_NGAY) AS CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_MAY = TMP.MS_MAY  AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "') AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       "  WHERE      HU_HONG = 1 AND TMP1.MS_MAY = TMP.MS_MAY AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "') AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
 " WHERE TMP.MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
 " AND TMP.MS_HE_THONG = '" & _vHeThong & "' AND TMP.MS_NHOM_MAY = '" & _vNhomMay & "'" & _
" GROUP BY TMP.MS_MAY ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataPBTByLoaiMay(ByVal _vNhaXuong As String, ByVal _vLoaiMay As String, ByVal _vNhomMay As String, ByVal _vMay As String) As DataTable
        Dim vtb As New DataTable()
        Dim sNX As String
        sNX = " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) "

        Dim VSQL As String = "SELECT TMP.MS_PHIEU_BAO_TRI," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_KHAC_KKH, " & _
 " (SELECT SUM(CHI_PHI_HANG_NGAY) AS TONG_CP FROM  dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 " & _
"  WHERE " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "' ) AS  CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "') AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       "  WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "' ) AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
 " WHERE MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
 " AND TMP.MS_LOAI_MAY = '" & _vLoaiMay & "' AND TMP.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP.MS_MAY = N'" & _vMay & "'" & _
" GROUP BY TMP.MS_PHIEU_BAO_TRI ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function DataPBTByHeThong(ByVal _vNhaXuong As String, ByVal _vHeThong As String, ByVal _vNhomMay As String, ByVal _vMay As String) As DataTable
        Dim vtb As New DataTable()
        Dim sNX As String
        sNX = " TMP1.MS_N_XUONG IN (SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) "

        Dim VSQL As String = "SELECT TMP.MS_PHIEU_BAO_TRI," & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_PHU_TUNG_KH , " & _
" (SELECT     SUM(CHI_PHI_PHU_TUNG) AS TONG_CP " & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_PHU_TUNG_KKH," & _
"	(SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_VAT_TU_KH, " & _
" (SELECT     SUM(CHI_PHI_VAT_TU) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_VAT_TU_KKH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_NHAN_CONG_KH," & _
" (SELECT     SUM(CHI_PHI_NHAN_CONG) AS TONG_CP" & _
        " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_NHAN_CONG_KKH,  " & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_DV_KH," & _
" (SELECT     SUM(CHI_PHI_DV) AS TONG_CP " & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_DV_KKH,  " & _
" (SELECT    SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_KHAC_KH," & _
" (SELECT     SUM(CHI_PHI_KHAC) AS TONG_CP" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
        " WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "')AS CHI_PHI_KHAC_KKH, " & _
" (SELECT SUM(CHI_PHI_HANG_NGAY) AS TONG_CP FROM dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1 " & _
 " WHERE " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "' ) AS  CHI_PHI_HANG_NGAY, " & _
" (SELECT     SUM(TONG) AS TONG_KH " & _
       "  FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       " WHERE      HU_HONG = 0 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI  AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "' ) AS TONG_KH," & _
" (SELECT     SUM(TONG) AS TONG_KKH" & _
       " FROM          dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP1" & _
       "  WHERE      HU_HONG = 1 AND TMP1.MS_PHIEU_BAO_TRI = TMP.MS_PHIEU_BAO_TRI AND " & sNX & " AND TMP1.MS_HE_THONG = '" & _vHeThong & "' AND TMP1.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP1.MS_MAY = N'" & _vMay & "') AS TONG_KKH, SUM(TONG) AS TONG" & _
" FROM         dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName & " TMP " & _
 " WHERE TMP.MS_N_XUONG IN(SELECT MS_N_XUONG FROM [dbo].[MashjGetNXUser]('" & Commons.Modules.UserName & "','" & _vNhaXuong & "')) " & _
 " AND TMP.MS_HE_THONG = '" & _vHeThong & "' AND TMP.MS_NHOM_MAY = '" & _vNhomMay & "' AND TMP.MS_MAY = N'" & _vMay & "'" & _
" GROUP BY TMP.MS_PHIEU_BAO_TRI ORDER BY TONG DESC"

        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, VSQL))
        Return vtb
    End Function

    Function KiemTraData() As Boolean
        Dim vtb As New DataTable()
        Dim vsql As String = "SELECT * FROM dbo.PHAN_TICH_CHI_PHI_TMP" & Commons.Modules.UserName
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vsql))
        If vtb.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ViewData()
        If KiemTraData() Then



            clImage.DefaultCellStyle.NullValue = Nothing
            Me.imgList.ImageSize = New System.Drawing.Size(16, 16)
            Me.imgList.TransparentColor = System.Drawing.Color.Magenta
            Me.imgList.ImageSize = New Size(16, 16)

            Try
                Me.imgList.Images.AddStrip(My.Resources.newGroupPostIconStrip)
            Catch ex As Exception

            End Try
            gvData.ImageList = imgList
            Me.clImage.HeaderCell = New AttachmentColumnHeader(imgList.Images(2))
            Dim boldFont As Font = New Font(gvData.DefaultCellStyle.Font, FontStyle.Bold)
            Dim vtbNhaMay As New DataTable()
            vtbNhaMay = DataNhaMay()
            Dim noderoot As TreeGridNode = Nothing
            If vtbNhaMay.Rows.Count > 0 Then
                noderoot = gvData.Nodes.Add(Nothing, "Nhà máy", vtbNhaMay.Rows(0)("CHI_PHI_PHU_TUNG_KH"), vtbNhaMay.Rows(0)("CHI_PHI_PHU_TUNG_KKH"), _
                                            vtbNhaMay.Rows(0)("CHI_PHI_VAT_TU_KH"), vtbNhaMay.Rows(0)("CHI_PHI_VAT_TU_KKH"), _
                                            vtbNhaMay.Rows(0)("CHI_PHI_NHAN_CONG_KH"), vtbNhaMay.Rows(0)("CHI_PHI_NHAN_CONG_KKH"), _
                                            vtbNhaMay.Rows(0)("CHI_PHI_DV_KH"), vtbNhaMay.Rows(0)("CHI_PHI_DV_KKH"), _
                                            vtbNhaMay.Rows(0)("CHI_PHI_KHAC_KH"), vtbNhaMay.Rows(0)("CHI_PHI_KHAC_KKH"), vtbNhaMay.Rows(0)("CHI_PHI_HANG_NGAY"), _
                                            vtbNhaMay.Rows(0)("TONG_KH"), vtbNhaMay.Rows(0)("TONG_KKH"), vtbNhaMay.Rows(0)("TONG"))
                noderoot.ImageIndex = 0
            End If

            Dim vtbNx As New DataTable()
            vtbNx = DataNhaxuong()

            prbIN.Position = 0
            prbIN.Properties.Step = 1
            prbIN.Properties.PercentView = True
            prbIN.Properties.Maximum = (vtbNx.Rows.Count)
            prbIN.Properties.Minimum = 0
            'prbIN.Position = prbIN.Properties.Maximum

            For Each vRowNx As DataRow In vtbNx.Rows
                prbIN.PerformStep()
                prbIN.Update()

                Dim node As TreeGridNode = noderoot.Nodes.Add(Nothing, vRowNx("TEN_N_XUONG").ToString, vRowNx("CHI_PHI_PHU_TUNG_KH"), vRowNx("CHI_PHI_PHU_TUNG_KKH"), _
                        vRowNx("CHI_PHI_VAT_TU_KH"), vRowNx("CHI_PHI_VAT_TU_KKH"), _
                        vRowNx("CHI_PHI_NHAN_CONG_KH"), vRowNx("CHI_PHI_NHAN_CONG_KKH"), _
                        vRowNx("CHI_PHI_DV_KH"), vRowNx("CHI_PHI_DV_KKH"), _
                        vRowNx("CHI_PHI_KHAC_KH"), vRowNx("CHI_PHI_KHAC_KKH"), _
                        vRowNx("CHI_PHI_HANG_NGAY"), _
                        vRowNx("TONG_KH"), vRowNx("TONG_KKH"), vRowNx("TONG"))
                node.ImageIndex = 0

                'Loai may
                'node.DefaultCellStyle.Font = boldFont
                node.DefaultCellStyle.ForeColor = Color.Blue
                node = node.Nodes.Add(Nothing, "Loại máy", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                node.ImageIndex = 0
                Dim nodeCap2 As TreeGridNode
                nodeCap2 = node
                Dim vtbLoaiMay As New DataTable
                vtbLoaiMay = DataLoaiMay(vRowNx("MS_N_XUONG").ToString)
                Dim c3 As Integer = 0
                Dim nodeCap3 As TreeGridNode = Nothing

                For Each vRowLm As DataRow In vtbLoaiMay.Rows
                    If c3 = 0 Then
                        node = node.Nodes.Add(Nothing, vRowLm("TEN_LOAI_MAY").ToString, vRowLm("CHI_PHI_PHU_TUNG_KH"), vRowLm("CHI_PHI_PHU_TUNG_KKH"), _
                                              vRowLm("CHI_PHI_VAT_TU_KH"), vRowLm("CHI_PHI_VAT_TU_KKH"), _
                                              vRowLm("CHI_PHI_NHAN_CONG_KH"), vRowLm("CHI_PHI_NHAN_CONG_KKH"), _
                                              vRowLm("CHI_PHI_DV_KH"), vRowLm("CHI_PHI_DV_KKH"), _
                                              vRowLm("CHI_PHI_KHAC_KH"), vRowLm("CHI_PHI_KHAC_KKH"), _
                                              vRowLm("CHI_PHI_HANG_NGAY"), _
                                              vRowLm("TONG_KH"), vRowLm("TONG_KKH"), vRowLm("TONG"))
                        node.ImageIndex = 0
                        nodeCap3 = node
                        c3 = c3 + 1
                        'Nhóm Máy
                        Dim vtbNhomMay As New DataTable()
                        vtbNhomMay = DataNhomMayByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString)
                        Dim c4 As Integer = 0
                        Dim nodeCap4 As TreeGridNode = Nothing
                        For Each vRowNm As DataRow In vtbNhomMay.Rows
                            If c4 = 0 Then
                                'node.DefaultCellStyle.Font = boldFont
                                node.DefaultCellStyle.ForeColor = Color.Maroon
                                node = node.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), _
                                                      vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), _
                                                      vRowNm("CHI_PHI_HANG_NGAY"), _
                                                      vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 0
                                nodeCap4 = node
                                c4 = c4 + 1
                                'Máy
                                Dim vtbMay As New DataTable
                                vtbMay = DataMayByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), _
                                                      vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), _
                                                      vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), _
                                                      vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), _
                                                      vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), _
                                                      vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), _
                                                      vRowPBT("CHI_PHI_HANG_NGAY"), _
                                                      vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                            End If

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), _
                                                      vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), _
                                                      vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            Try
                                                If c6 = 0 Then
                                                    node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), _
                                                      vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), _
                                                      vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                    node.ImageIndex = 0
                                                    nodeCap6 = node
                                                    c6 = c6 + 1
                                                Else
                                                    node = nodeCap6
                                                    node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), _
                                                      vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), _
                                                      vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                    node.ImageIndex = 0
                                                End If
                                            Catch ex As Exception

                                            End Try
                                        Next
                                    End If
                                Next

                            Else
                                node = nodeCap4
                                'node.DefaultCellStyle.Font = boldFont
                                'node.DefaultCellStyle.ForeColor = Color.DarkViolet
                                node = node.Parent.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), _
                                                      vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), vRowNm("CHI_PHI_HANG_NGAY"), _
                                                      vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 0
                                Dim vtbMay As New DataTable
                                vtbMay = DataMayByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), _
                                                      vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), _
                                                      vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), _
                                                      vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), _
                                                      vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), _
                                                      vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), _
                                                      vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                            End If

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), _
                                                      vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), _
                                                      vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), _
                                                      vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), _
                                                      vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), _
                                                      vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), _
                                                      vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), _
                                                      vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next

                    Else
                        node = nodeCap3
                        node = node.Parent.Nodes.Add(Nothing, vRowLm("TEN_LOAI_MAY").ToString, vRowLm("CHI_PHI_PHU_TUNG_KH"), vRowLm("CHI_PHI_PHU_TUNG_KKH"), vRowLm("CHI_PHI_VAT_TU_KH"), vRowLm("CHI_PHI_VAT_TU_KKH"), vRowLm("CHI_PHI_NHAN_CONG_KH"), vRowLm("CHI_PHI_NHAN_CONG_KKH"), vRowLm("CHI_PHI_DV_KH"), vRowLm("CHI_PHI_DV_KKH"), vRowLm("CHI_PHI_KHAC_KH"), vRowLm("CHI_PHI_KHAC_KKH"), vRowLm("CHI_PHI_HANG_NGAY"), vRowLm("TONG_KH"), vRowLm("TONG_KKH"), vRowLm("TONG"))
                        node.ImageIndex = 0
                        Dim vtbNhomMay As New DataTable()
                        vtbNhomMay = DataNhomMayByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString)
                        Dim c4 As Integer = 0
                        Dim nodeCap4 As TreeGridNode = Nothing
                        For Each vRowNm As DataRow In vtbNhomMay.Rows
                            If c4 = 0 Then
                                'node.DefaultCellStyle.Font = boldFont
                                node.DefaultCellStyle.ForeColor = Color.Maroon
                                node = node.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), vRowNm("CHI_PHI_HANG_NGAY"), vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 0
                                nodeCap4 = node
                                c4 = c4 + 1
                                'Máy
                                Dim vtbMay As New DataTable
                                vtbMay = DataMayByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                            End If

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                            End If
                                        Next
                                    End If
                                Next

                            Else
                                node = nodeCap4
                                'node.DefaultCellStyle.Font = boldFont
                                'node.DefaultCellStyle.ForeColor = Color.DarkViolet
                                node = node.Parent.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), vRowNm("CHI_PHI_HANG_NGAY"), vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 0
                                Dim vtbMay As New DataTable
                                vtbMay = DataMayByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            Try
                                                If c6 = 0 Then
                                                    node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                    node.ImageIndex = 0
                                                    nodeCap6 = node
                                                    c6 = c6 + 1
                                                Else
                                                    node = nodeCap6
                                                    node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                    node.ImageIndex = 0
                                                End If
                                            Catch ex As Exception

                                            End Try

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 0
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByLoaiMay(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_LOAI_MAY").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 0
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If



                Next

                'He thong
                node = nodeCap2
                'node.DefaultCellStyle.Font = boldFont
                node = node.Parent.Nodes.Add(Nothing, "Dây chuyền ", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                node.ImageIndex = 2
                'node.DefaultCellStyle.Font = boldFont
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim nodeCap21 As TreeGridNode
                nodeCap21 = node
                Dim vtbHeThong As New DataTable
                vtbHeThong = DataHeThong(vRowNx("MS_N_XUONG").ToString)
                Dim c31 As Integer = 0
                nodeCap3 = Nothing


                For Each vRowLm As DataRow In vtbHeThong.Rows
                    If c31 = 0 Then
                        node = node.Nodes.Add(Nothing, vRowLm("TEN_HE_THONG").ToString, vRowLm("CHI_PHI_PHU_TUNG_KH"), vRowLm("CHI_PHI_PHU_TUNG_KKH"), vRowLm("CHI_PHI_VAT_TU_KH"), vRowLm("CHI_PHI_VAT_TU_KKH"), vRowLm("CHI_PHI_NHAN_CONG_KH"), vRowLm("CHI_PHI_NHAN_CONG_KKH"), vRowLm("CHI_PHI_DV_KH"), vRowLm("CHI_PHI_DV_KKH"), vRowLm("CHI_PHI_KHAC_KH"), vRowLm("CHI_PHI_KHAC_KKH"), vRowLm("CHI_PHI_HANG_NGAY"), vRowLm("TONG_KH"), vRowLm("TONG_KKH"), vRowLm("TONG"))
                        node.ImageIndex = 2
                        nodeCap3 = node
                        c31 = c31 + 1
                        'Nhóm Máy
                        Dim vtbNhomMay As New DataTable()
                        vtbNhomMay = DataNhomMayByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString)
                        Dim c4 As Integer = 0
                        Dim nodeCap4 As TreeGridNode = Nothing
                        For Each vRowNm As DataRow In vtbNhomMay.Rows
                            If c4 = 0 Then
                                'node.DefaultCellStyle.Font = boldFont
                                node.DefaultCellStyle.ForeColor = Color.DarkGreen
                                node = node.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), vRowNm("CHI_PHI_HANG_NGAY"), vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 2
                                nodeCap4 = node
                                c4 = c4 + 1
                                'Máy
                                Dim vtbMay As New DataTable
                                vtbMay = DataMaybyHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If
                                        Next
                                    End If
                                Next

                            Else
                                node = nodeCap4
                                'node.DefaultCellStyle.Font = boldFont
                                'node.DefaultCellStyle.ForeColor = Color.DarkViolet
                                node = node.Parent.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), vRowNm("CHI_PHI_HANG_NGAY"), vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 2
                                Dim vtbMay As New DataTable
                                vtbMay = DataMaybyHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next

                    Else
                        node = nodeCap3
                        node = node.Parent.Nodes.Add(Nothing, vRowLm("TEN_HE_THONG").ToString, vRowLm("CHI_PHI_PHU_TUNG_KH"), vRowLm("CHI_PHI_PHU_TUNG_KKH"), vRowLm("CHI_PHI_VAT_TU_KH"), vRowLm("CHI_PHI_VAT_TU_KKH"), vRowLm("CHI_PHI_NHAN_CONG_KH"), vRowLm("CHI_PHI_NHAN_CONG_KKH"), vRowLm("CHI_PHI_DV_KH"), vRowLm("CHI_PHI_DV_KKH"), vRowLm("CHI_PHI_KHAC_KH"), vRowLm("CHI_PHI_KHAC_KKH"), vRowLm("CHI_PHI_HANG_NGAY"), vRowLm("TONG_KH"), vRowLm("TONG_KKH"), vRowLm("TONG"))
                        node.ImageIndex = 2
                        Dim vtbNhomMay As New DataTable()
                        vtbNhomMay = DataNhomMayByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString)
                        Dim c4 As Integer = 0
                        Dim nodeCap4 As TreeGridNode = Nothing
                        For Each vRowNm As DataRow In vtbNhomMay.Rows
                            If c4 = 0 Then
                                ' node.DefaultCellStyle.Font = boldFont
                                node.DefaultCellStyle.ForeColor = Color.DarkGreen
                                node = node.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), vRowNm("CHI_PHI_HANG_NGAY"), vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 2
                                nodeCap4 = node
                                c4 = c4 + 1
                                'Máy
                                Dim vtbMay As New DataTable
                                vtbMay = DataMaybyHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If
                                        Next
                                    End If
                                Next

                            Else
                                node = nodeCap4
                                'node.DefaultCellStyle.Font = boldFont
                                'node.DefaultCellStyle.ForeColor = Color.DarkViolet
                                node = node.Parent.Nodes.Add(Nothing, vRowNm("TEN_NHOM_MAY").ToString, vRowNm("CHI_PHI_PHU_TUNG_KH"), vRowNm("CHI_PHI_PHU_TUNG_KKH"), vRowNm("CHI_PHI_VAT_TU_KH"), vRowNm("CHI_PHI_VAT_TU_KKH"), vRowNm("CHI_PHI_NHAN_CONG_KH"), vRowNm("CHI_PHI_NHAN_CONG_KKH"), vRowNm("CHI_PHI_DV_KH"), vRowNm("CHI_PHI_DV_KKH"), vRowNm("CHI_PHI_KHAC_KH"), vRowNm("CHI_PHI_KHAC_KKH"), vRowNm("CHI_PHI_HANG_NGAY"), vRowNm("TONG_KH"), vRowNm("TONG_KKH"), vRowNm("TONG"))
                                node.ImageIndex = 2
                                Dim vtbMay As New DataTable
                                vtbMay = DataMaybyHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString)
                                Dim c5 As Integer = 0
                                Dim nodeCap5 As TreeGridNode = Nothing
                                For Each vRowMay As DataRow In vtbMay.Rows
                                    If c5 = 0 Then
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        nodeCap5 = node
                                        c5 = c5 + 1
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If

                                        Next
                                    Else
                                        node = nodeCap5
                                        'node.DefaultCellStyle.Font = boldFont
                                        'node.DefaultCellStyle.ForeColor = Color.Green
                                        node = node.Parent.Nodes.Add(Nothing, vRowMay("MS_MAY").ToString, vRowMay("CHI_PHI_PHU_TUNG_KH"), vRowMay("CHI_PHI_PHU_TUNG_KKH"), vRowMay("CHI_PHI_VAT_TU_KH"), vRowMay("CHI_PHI_VAT_TU_KKH"), vRowMay("CHI_PHI_NHAN_CONG_KH"), vRowMay("CHI_PHI_NHAN_CONG_KKH"), vRowMay("CHI_PHI_DV_KH"), vRowMay("CHI_PHI_DV_KKH"), vRowMay("CHI_PHI_KHAC_KH"), vRowMay("CHI_PHI_KHAC_KKH"), vRowMay("CHI_PHI_HANG_NGAY"), vRowMay("TONG_KH"), vRowMay("TONG_KKH"), vRowMay("TONG"))
                                        node.ImageIndex = 2
                                        'Phieu Bao Tri    
                                        Dim vtbPhieuBaotri As New DataTable
                                        vtbPhieuBaotri = DataPBTByHeThong(vRowNx("MS_N_XUONG").ToString, vRowLm("MS_HE_THONG").ToString, vRowNm("MS_NHOM_MAY").ToString, vRowMay("MS_MAY").ToString)
                                        Dim c6 As Integer = 0
                                        Dim nodeCap6 As TreeGridNode = Nothing
                                        For Each vRowPBT As DataRow In vtbPhieuBaotri.Rows
                                            If c6 = 0 Then
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                                nodeCap6 = node
                                                c6 = c6 + 1
                                            Else
                                                node = nodeCap6
                                                node = node.Parent.Nodes.Add(Nothing, vRowPBT("MS_PHIEU_BAO_TRI").ToString, vRowPBT("CHI_PHI_PHU_TUNG_KH"), vRowPBT("CHI_PHI_PHU_TUNG_KKH"), vRowPBT("CHI_PHI_VAT_TU_KH"), vRowPBT("CHI_PHI_VAT_TU_KKH"), vRowPBT("CHI_PHI_NHAN_CONG_KH"), vRowPBT("CHI_PHI_NHAN_CONG_KKH"), vRowPBT("CHI_PHI_DV_KH"), vRowPBT("CHI_PHI_DV_KKH"), vRowPBT("CHI_PHI_KHAC_KH"), vRowPBT("CHI_PHI_KHAC_KKH"), vRowPBT("CHI_PHI_HANG_NGAY"), vRowPBT("TONG_KH"), vRowPBT("TONG_KKH"), vRowPBT("TONG"))
                                                node.ImageIndex = 2
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Next
        Else
            Exit Sub
        End If

        prbIN.PerformStep()
        prbIN.Update()

        prbIN.Position = prbIN.Properties.Maximum
    End Sub



    Private Sub ShowData()
        clImage.DefaultCellStyle.NullValue = Nothing
        Me.imgList.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgList.TransparentColor = System.Drawing.Color.Magenta
        Me.imgList.ImageSize = New Size(16, 16)

        Try
            Me.imgList.Images.AddStrip(My.Resources.newGroupPostIconStrip)
        Catch ex As Exception

        End Try
        gvData.ImageList = imgList
        Me.clImage.HeaderCell = New AttachmentColumnHeader(imgList.Images(2))

        Dim boldFont As Font = New Font(gvData.DefaultCellStyle.Font, FontStyle.Bold)

        Dim vtbNhaxuong As New DataTable
        vtbNhaxuong = SelectDistinct(vData, "MS_N_XUONG", "TEN_N_XUONG")
        For Each vrowNX As DataRow In vtbNhaxuong.Rows
            Dim vtbNXtmp() As DataRow = vData.Select("MS_N_XUONG = '" + vrowNX("MS_N_XUONG") + "'")
            Dim vCp_Pt As Double = 0
            Dim vCp_Vt As Double = 0
            Dim vCp_Nc As Double = 0
            Dim vCp_Dv As Double = 0
            Dim vCp_Hn As Double = 0
            Dim vCp_Kh As Double = 0
            Dim vCp_Tg As Double = 0
            For i As Integer = 0 To vtbNXtmp.Length - 1
                vCp_Pt = vCp_Pt + Double.Parse(vtbNXtmp(i).Item("CHI_PHI_PHU_TUNG").ToString)
                vCp_Vt = vCp_Vt + Double.Parse(vtbNXtmp(i).Item("CHI_PHI_VAT_TU").ToString)
                vCp_Nc = vCp_Nc + Double.Parse(vtbNXtmp(i).Item("CHI_PHI_NHAN_CONG").ToString)
                vCp_Dv = vCp_Dv + Double.Parse(vtbNXtmp(i).Item("CHI_PHI_DV").ToString)
                vCp_Kh = vCp_Kh + Double.Parse(vtbNXtmp(i).Item("CHI_PHI_KHAC").ToString)
                vCp_Hn = vCp_Hn + Double.Parse(vtbNXtmp(i).Item("CHI_PHI_HANG_NGAY").ToString)
                vCp_Tg = vCp_Tg + Double.Parse(vtbNXtmp(i).Item("TONG").ToString)
            Next
            Dim node As TreeGridNode = gvData.Nodes.Add(Nothing, vrowNX("TEN_N_XUONG").ToString, vCp_Pt, vCp_Vt, vCp_Nc, vCp_Dv, vCp_Hn, vCp_Kh, vCp_Tg)
            node.ImageIndex = 0
            node.DefaultCellStyle.Font = boldFont
            'Loai May
            Dim vDtr As DataView = New DataView(vData, "MS_N_XUONG = '" + vrowNX("MS_N_XUONG") + "'", "TONG", DataViewRowState.CurrentRows)
            Dim vtbLoaiMay As New DataTable()
            vtbLoaiMay = SelectDistinct(vDtr.ToTable, "MS_LOAI_MAY", "TEN_LOAI_MAY")
            Dim j As Integer = 0
            For Each vrowLM As DataRow In vtbLoaiMay.Rows
                Dim vtbLMtmp() As DataRow = vData.Select("MS_LOAI_MAY = '" + vrowLM("MS_LOAI_MAY") + "' AND MS_N_XUONG = '" + vrowNX("MS_N_XUONG") + "'")
                Dim vCp_Pt1 As Double = 0
                Dim vCp_Vt1 As Double = 0
                Dim vCp_Nc1 As Double = 0
                Dim vCp_Dv1 As Double = 0
                Dim vCp_Hn1 As Double = 0
                Dim vCp_Kh1 As Double = 0
                Dim vCp_Tg1 As Double = 0
                For i As Integer = 0 To vtbLMtmp.Length - 1
                    vCp_Pt1 = vCp_Pt1 + Double.Parse(vtbLMtmp(i).Item("CHI_PHI_PHU_TUNG").ToString)
                    vCp_Vt1 = vCp_Vt1 + Double.Parse(vtbLMtmp(i).Item("CHI_PHI_VAT_TU").ToString)
                    vCp_Nc1 = vCp_Nc1 + Double.Parse(vtbLMtmp(i).Item("CHI_PHI_NHAN_CONG").ToString)
                    vCp_Dv1 = vCp_Dv1 + Double.Parse(vtbLMtmp(i).Item("CHI_PHI_DV").ToString)
                    vCp_Kh1 = vCp_Kh1 + Double.Parse(vtbLMtmp(i).Item("CHI_PHI_KHAC").ToString)
                    vCp_Hn1 = vCp_Hn1 + Double.Parse(vtbLMtmp(i).Item("CHI_PHI_HANG_NGAY").ToString)
                    vCp_Tg1 = vCp_Tg1 + Double.Parse(vtbLMtmp(i).Item("TONG").ToString)
                Next

                If j = 0 Then
                    node = node.Nodes.Add(Nothing, vrowLM("TEN_LOAI_MAY").ToString, vCp_Pt1, vCp_Vt1, vCp_Nc1, vCp_Dv1, vCp_Hn1, vCp_Kh1, vCp_Tg1)
                    node.ImageIndex = 1
                    j = j + 1
                Else
                    node = node.Parent.Nodes.Add(Nothing, vrowLM("TEN_LOAI_MAY").ToString, vCp_Pt1, vCp_Vt1, vCp_Nc1, vCp_Dv1, vCp_Hn1, vCp_Kh1, vCp_Tg1)
                    node.ImageIndex = 1
                End If

            Next
        Next

        'Dim vtbLoaiMay As New DataView
        'Dim vtbNhomMay As New DataView

    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Friend Class AttachmentColumnHeader
        Inherits DataGridViewColumnHeaderCell
        Public _image As Image
        Public Sub New(ByVal img As Image)
            MyBase.New()
            Me._image = img
        End Sub
        Protected Overloads Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal dataGridViewElementState As DataGridViewElementStates, ByVal value As Object, _
         ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
            graphics.DrawImage(_image, cellBounds.X + 4, cellBounds.Y + 2)
        End Sub
        Protected Overloads Overrides Function GetValue(ByVal rowIndex As Integer) As Object
            Return (Nothing)
        End Function
    End Class

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Shared Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
        Dim lastValues() As Object
        Dim newTable As DataTable

        If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
            Throw New ArgumentNullException("FieldNames")
        End If

        lastValues = New Object(FieldNames.Length - 1) {}
        newTable = New DataTable

        For Each field As String In FieldNames
            newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
        Next

        For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
            If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
                newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

                setLastValues(lastValues, Row, FieldNames)
            End If
        Next

        Return newTable
    End Function

    Private Shared Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
        Dim areEqual As Boolean = True

        For i As Integer = 0 To fieldNames.Length - 1
            If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
                areEqual = False
                Exit For
            End If
        Next

        Return areEqual
    End Function

    Private Shared Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
        For Each field As String In fieldNames
            newRow(field) = sourceRow(field)
        Next

        Return newRow
    End Function

    Private Shared Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
        For i As Integer = 0 To fieldNames.Length - 1
            lastValues(i) = sourceRow(fieldNames(i))
        Next
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        'gvData.Nodes.Clear()
        'vData = loadData()
        'CreateData(vData)
        'ViewData()


        Try
            If dtTNgay.Text = "" Then Exit Sub
            If dtDNgay.Text = "" Then Exit Sub

            Try
                vTuNgay = dtTNgay.DateTime.Date
            Catch ex As Exception
                Exit Sub
            End Try
            Try
                vDenNgay = dtDNgay.DateTime.Date
            Catch ex As Exception
                Exit Sub
            End Try

            If vTuNgay > vDenNgay Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "DN_PHAI_LON_HON_TN", Commons.Modules.TypeLanguage))
                dtTNgay.Focus()
                Exit Sub
            End If

            gvData.Nodes.Clear()
            vData = loadData()
            CreateData(vData)
            ViewData()
            RefreshLanguages()

        Catch ex As Exception
            'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "CHUA_DUNG_DINH_DANG", commons.Modules.TypeLanguage))
        End Try

    End Sub

    Private Sub gvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvData.DoubleClick
        If KiemTraData() Then
            Dim mspbt As String
            Dim index As Integer
            Dim node As TreeGridNode = gvData.CurrentRow
            index = node.RowIndex
            If index >= 0 And node.Nodes.Count = 0 Then
                mspbt = node.Cells.Item(1).Value.ToString

                Try
                    'Tinh trang Va hinh thuc phieu bao tri 
                    Dim vtbTT As DataTable = New DataTable()
                    vtbTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_TINH_TRANG_AND_HINH_THUC_PHIEU_BAO_TRI", mspbt))
                    Try
                        Dim vSDKho As Integer
                        vSDKho = 0
                        Dim frmRpt As frmXMLReport = New frmXMLReport()
                        Select Case Commons.Modules.sPrivate
                            Case "VMPACK"
                                frmRpt.rptName = "rptPHIEU_BAO_TRI_NT_VMPACK"
                            Case Else
                                Select Case Commons.Modules.sPrivate
                                    Case "KKTL"
                                        frmRpt.rptName = "rptPHIEU_BAO_TRI_NT_KKTL"
                                    Case Else
                                        frmRpt.rptName = "rptPHIEU_BAO_TRI_NT"
                                End Select
                        End Select

                        Dim iTinhtrangphieu As Integer = vtbTT.Rows(0)("TINH_TRANG_PBT")
                        If iTinhtrangphieu >= 0 Then


                            Dim vtbPBT As New DataTable()
                            vtbPBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_PHIEU_BAO_TRI", mspbt, Commons.Modules.TypeLanguage))
                            vtbPBT.TableName = "PBT_INFO"
                            Dim vtbCongViec As New DataTable()
                            vtbCongViec.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_VIEC_BAO_TRI", mspbt))
                            vtbCongViec.TableName = "PBT_CONG_VIEC"
                            Dim vtbCongNhan As New DataTable()
                            vtbCongNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_CONG_NHAN_BAO_TRI", mspbt))
                            vtbCongNhan.TableName = "PBT_CONG_NHAN"
                            Dim vtbDichVu As New DataTable()
                            vtbDichVu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_RPT_DICH_VU_THUE_NGOAI", mspbt))
                            vtbDichVu.TableName = "PBT_DICH_VU"
                            Dim vtbVatTu As New DataTable()
                            vtbVatTu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_VAT_TU_PHIEU_BAO_TRI", mspbt, iTinhtrangphieu, Commons.Modules.TypeLanguage))
                            vtbVatTu.TableName = "PBT_VAT_TU"
                            Dim vtbPhuTung As New DataTable()
                            vtbPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_PHU_TUNG_PHIEU_BAO_TRI", mspbt, iTinhtrangphieu, Commons.Modules.TypeLanguage, vSDKho))
                            vtbPhuTung.TableName = "PBT_PHU_TUNG"

                            Dim vtbNumberRecord As New DataTable()
                            vtbNumberRecord.TableName = "BT_NUMBER_RECORD"
                            For i As Integer = 0 To 5
                                vtbNumberRecord.Columns.Add()
                            Next
                            vtbNumberRecord.Columns(0).ColumnName = "NR_CONG_VIEC"
                            vtbNumberRecord.Columns(1).ColumnName = "NR_CONG_NHAN"
                            vtbNumberRecord.Columns(2).ColumnName = "NR_DICH_VU"
                            vtbNumberRecord.Columns(3).ColumnName = "NR_PHU_TUNG"
                            vtbNumberRecord.Columns(4).ColumnName = "NR_VAT_TU"
                            vtbNumberRecord.Columns(5).ColumnName = "NR_TT"
                            Dim vRowTitle As DataRow = vtbNumberRecord.NewRow()

                            vRowTitle("NR_CONG_VIEC") = vtbCongViec.Rows.Count
                            vRowTitle("NR_CONG_NHAN") = vtbCongNhan.Rows.Count
                            vRowTitle("NR_DICH_VU") = vtbDichVu.Rows.Count
                            vRowTitle("NR_PHU_TUNG") = vtbPhuTung.Rows.Count
                            vRowTitle("NR_VAT_TU") = vtbVatTu.Rows.Count
                            vRowTitle("NR_TT") = vtbTT.Rows(0)("TINH_TRANG_PBT")
                            vtbNumberRecord.Rows.Add(vRowTitle)

                            frmRpt.AddDataTableSource(vtbPBT)
                            frmRpt.AddDataTableSource(vtbCongViec)
                            frmRpt.AddDataTableSource(vtbCongNhan)
                            frmRpt.AddDataTableSource(vtbDichVu)
                            frmRpt.AddDataTableSource(vtbVatTu)
                            frmRpt.AddDataTableSource(vtbPhuTung)
                            frmRpt.AddDataTableSource(vtbNumberRecord)

                            frmRpt.AddDataTableSource(LanguageReport())
                            frmRpt.AddDataTableSource(LanguageCongViecBT())
                            frmRpt.AddDataTableSource(LanguageNhanvienBT())
                            frmRpt.AddDataTableSource(LanguageDichVuBT())
                            frmRpt.AddDataTableSource(LanguagePhuTungBT())
                            frmRpt.AddDataTableSource(LanguageVatTuBT())
                            frmRpt.AddDataTableSource(LanguageChiPhiBT())
                            frmRpt.ShowDialog()
                        Else
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhanTichChiPhi_DUYTAN", "Phieubaotrichuacapnhattinhtrang", Commons.Modules.TypeLanguage))
                        End If
                    Catch ex As Exception
                    End Try
                Catch ex As Exception
                End Try

            End If

        End If
    End Sub

    Function LanguageReport() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PHIEU_BAO_TRI_BT"
        For i As Integer = 0 To 25
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "MAU_SO"
        vtbTitle.Columns(2).ColumnName = "PHIEU_BAO_TRI"
        vtbTitle.Columns(3).ColumnName = "NGUOI_LAP"
        vtbTitle.Columns(4).ColumnName = "NGAY_LAP"
        vtbTitle.Columns(5).ColumnName = "MS_MAY"
        vtbTitle.Columns(6).ColumnName = "TEN_MAY"
        vtbTitle.Columns(7).ColumnName = "TINH_TRANG"
        vtbTitle.Columns(8).ColumnName = "MO_TA"
        vtbTitle.Columns(9).ColumnName = "HINH_THUC_BT"
        vtbTitle.Columns(10).ColumnName = "LOAI_BT"
        vtbTitle.Columns(11).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(13).ColumnName = "KE_HOACH"
        vtbTitle.Columns(14).ColumnName = "NGAY_BD"
        vtbTitle.Columns(15).ColumnName = "NGAY_KT"
        vtbTitle.Columns(16).ColumnName = "BO_PHAN_CP"
        vtbTitle.Columns(17).ColumnName = "PHE_DUYET1"
        vtbTitle.Columns(18).ColumnName = "PHE_DUYET2"
        vtbTitle.Columns(19).ColumnName = "PHE_DUYET3"
        vtbTitle.Columns(20).ColumnName = "PHE_DUYET4"
        vtbTitle.Columns(21).ColumnName = "LY_DO_BT"
        vtbTitle.Columns(22).ColumnName = "TMP1"
        vtbTitle.Columns(23).ColumnName = "TMP2"
        vtbTitle.Columns(24).ColumnName = "TMP3"
        vtbTitle.Columns(25).ColumnName = "TMP4"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TIEU_DE", Commons.Modules.TypeLanguage)
        vRowTitle("MAU_SO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "MAU_SO", Commons.Modules.TypeLanguage)
        vRowTitle("PHIEU_BAO_TRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_LAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGUOI_LAP", Commons.Modules.TypeLanguage)
        vRowTitle("NGAY_LAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_LAP", Commons.Modules.TypeLanguage)
        vRowTitle("MS_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "MS_MAY", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TEN_MAY", Commons.Modules.TypeLanguage)
        vRowTitle("TINH_TRANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TINH_TRANG", Commons.Modules.TypeLanguage)
        vRowTitle("MO_TA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "MO_TA", Commons.Modules.TypeLanguage)
        vRowTitle("HINH_THUC_BT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "HINH_THUC_BT", Commons.Modules.TypeLanguage)
        vRowTitle("LOAI_BT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "LOAI_BT", Commons.Modules.TypeLanguage)
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DIA_DIEM", Commons.Modules.TypeLanguage)
        vRowTitle("KE_HOACH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "KE_HOACH", Commons.Modules.TypeLanguage)
        vRowTitle("NGAY_BD") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_BD", Commons.Modules.TypeLanguage)
        vRowTitle("NGAY_KT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGAY_KT", Commons.Modules.TypeLanguage)
        vRowTitle("BO_PHAN_CP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "BO_PHAN_CP", Commons.Modules.TypeLanguage)
        vRowTitle("PHE_DUYET1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET1", Commons.Modules.TypeLanguage)
        vRowTitle("PHE_DUYET2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET2", Commons.Modules.TypeLanguage)
        vRowTitle("PHE_DUYET3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET3", Commons.Modules.TypeLanguage)
        vRowTitle("PHE_DUYET4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PHE_DUYET4", Commons.Modules.TypeLanguage)
        vRowTitle("LY_DO_BT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "LY_DO_BT", Commons.Modules.TypeLanguage)
        vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TMP1", Commons.Modules.TypeLanguage)
        vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TMP2", Commons.Modules.TypeLanguage)
        vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TMP3", Commons.Modules.TypeLanguage)
        vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TMP4", Commons.Modules.TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageCongViecBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_CONG_VIEC_BT"
        For i As Integer = 0 To 7
            vtbTitle.Columns.Add()
        Next

        vtbTitle.Columns(0).ColumnName = "DANH_SACH_CV"
        vtbTitle.Columns(1).ColumnName = "CV_CONG_VIEC"
        vtbTitle.Columns(2).ColumnName = "CV_BO_PHAN"
        vtbTitle.Columns(3).ColumnName = "CV_SPHUT_KH"
        vtbTitle.Columns(4).ColumnName = "CV_NGAY_HT"
        vtbTitle.Columns(5).ColumnName = "CV_LOAI_CV"
        vtbTitle.Columns(6).ColumnName = "TONG_PHUT_KH_CV"
        vtbTitle.Columns(7).ColumnName = "STT"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("DANH_SACH_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DANH_SACH_CV", Commons.Modules.TypeLanguage)
        vRowTitle("CV_CONG_VIEC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_CONG_VIEC", Commons.Modules.TypeLanguage)
        vRowTitle("CV_BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_BO_PHAN", Commons.Modules.TypeLanguage)
        vRowTitle("CV_SPHUT_KH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_SPHUT_KH", Commons.Modules.TypeLanguage)
        vRowTitle("CV_NGAY_HT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_NGAY_HT", Commons.Modules.TypeLanguage)
        vRowTitle("CV_LOAI_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CV_LOAI_CV", Commons.Modules.TypeLanguage)
        vRowTitle("TONG_PHUT_KH_CV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TONG_PHUT_KH_CV", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "STT", Commons.Modules.TypeLanguage)


        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageNhanvienBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_NHAN_VIEN_BT"
        For i As Integer = 0 To 6
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "NV_DS_NV"
        vtbTitle.Columns(1).ColumnName = "NV_HO_TEN"
        vtbTitle.Columns(2).ColumnName = "NV_TO_PB"
        vtbTitle.Columns(3).ColumnName = "NV_TU_NGAY"
        vtbTitle.Columns(4).ColumnName = "NV_DEN_NGAY"
        vtbTitle.Columns(5).ColumnName = "NV_LOAI_VN"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("NV_DS_NV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_DS_NV", Commons.Modules.TypeLanguage)
        vRowTitle("NV_HO_TEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_HO_TEN", Commons.Modules.TypeLanguage)
        vRowTitle("NV_TO_PB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_TO_PB", Commons.Modules.TypeLanguage)
        vRowTitle("NV_TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_TU_NGAY", Commons.Modules.TypeLanguage)
        vRowTitle("NV_DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_DEN_NGAY", Commons.Modules.TypeLanguage)
        vRowTitle("NV_LOAI_VN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NV_LOAI_VN", Commons.Modules.TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)

        Return vtbTitle
    End Function
    Function LanguageDichVuBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_DICH_VU_BT"
        For i As Integer = 0 To 7
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "DV_DS_DV"
        vtbTitle.Columns(1).ColumnName = "DV_ND"
        vtbTitle.Columns(2).ColumnName = "DV_CTY"
        vtbTitle.Columns(3).ColumnName = "DV_SL"
        vtbTitle.Columns(4).ColumnName = "DV_DG"
        vtbTitle.Columns(5).ColumnName = "DV_TG"
        vtbTitle.Columns(6).ColumnName = "DV_TT"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("DV_DS_DV") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_DS_DV", Commons.Modules.TypeLanguage)
        vRowTitle("DV_ND") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_ND", Commons.Modules.TypeLanguage)
        vRowTitle("DV_CTY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_CTY", Commons.Modules.TypeLanguage)
        vRowTitle("DV_SL") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_SL", Commons.Modules.TypeLanguage)
        vRowTitle("DV_DG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_DG", Commons.Modules.TypeLanguage)
        vRowTitle("DV_TG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_TG", Commons.Modules.TypeLanguage)
        vRowTitle("DV_TT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "DV_TT", Commons.Modules.TypeLanguage)


        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguagePhuTungBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PHU_TUNG_BT"
        For i As Integer = 0 To 9
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "PT_DS_PT"
        vtbTitle.Columns(1).ColumnName = "PT_MS_PT"
        vtbTitle.Columns(2).ColumnName = "PT_MS_PTTT"
        vtbTitle.Columns(3).ColumnName = "PT_TEN_PT"
        vtbTitle.Columns(4).ColumnName = "PT_TEN_PTTT"
        vtbTitle.Columns(5).ColumnName = "PT_SL_KH"
        vtbTitle.Columns(6).ColumnName = "PT_SL_TT"
        vtbTitle.Columns(7).ColumnName = "PT_DVT"
        vtbTitle.Columns(8).ColumnName = "PT_GHI_CHU"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("PT_DS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_DS_PT", Commons.Modules.TypeLanguage)
        vRowTitle("PT_MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_MS_PT", Commons.Modules.TypeLanguage)
        vRowTitle("PT_MS_PTTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_MS_PTTT", Commons.Modules.TypeLanguage)
        vRowTitle("PT_TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_TEN_PT", Commons.Modules.TypeLanguage)
        vRowTitle("PT_TEN_PTTT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_TEN_PTTT", Commons.Modules.TypeLanguage)
        vRowTitle("PT_SL_KH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_SL_KH", Commons.Modules.TypeLanguage)
        vRowTitle("PT_SL_TT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_SL_TT", Commons.Modules.TypeLanguage)
        vRowTitle("PT_DVT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_DVT", Commons.Modules.TypeLanguage)
        vRowTitle("PT_GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "PT_GHI_CHU", Commons.Modules.TypeLanguage)


        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageVatTuBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_VAT_TU_BT"
        For i As Integer = 0 To 7
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "VT_DS_VT"
        vtbTitle.Columns(1).ColumnName = "VT_MS_VT"
        vtbTitle.Columns(2).ColumnName = "VT_TEN_VT"
        vtbTitle.Columns(3).ColumnName = "VT_SL_KH"
        vtbTitle.Columns(4).ColumnName = "VT_SL_TT"
        vtbTitle.Columns(5).ColumnName = "VT_DVT"
        vtbTitle.Columns(6).ColumnName = "VT_GHI_CHU"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("VT_DS_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_DS_VT", Commons.Modules.TypeLanguage)
        vRowTitle("VT_MS_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_MS_VT", Commons.Modules.TypeLanguage)
        vRowTitle("VT_TEN_VT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_TEN_VT", Commons.Modules.TypeLanguage)
        vRowTitle("VT_SL_KH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_SL_KH", Commons.Modules.TypeLanguage)
        vRowTitle("VT_SL_TT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_SL_TT", Commons.Modules.TypeLanguage)
        vRowTitle("VT_DVT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_DVT", Commons.Modules.TypeLanguage)
        vRowTitle("VT_GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "VT_GHI_CHU", Commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
    Function LanguageChiPhiBT() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_CHI_PHI_BT"
        For i As Integer = 0 To 13
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TONG_CHI_PHI"
        vtbTitle.Columns(1).ColumnName = "STT"
        vtbTitle.Columns(2).ColumnName = "CP_NOI_DUNG"
        vtbTitle.Columns(3).ColumnName = "CP_TIEN"
        vtbTitle.Columns(4).ColumnName = "CP_TONG"
        vtbTitle.Columns(5).ColumnName = "KQ_BAO_TRI"
        vtbTitle.Columns(6).ColumnName = "KQ_NGAY_NT"
        vtbTitle.Columns(7).ColumnName = "KQ_BT"
        vtbTitle.Columns(8).ColumnName = "NGUOI_NT"
        vtbTitle.Columns(9).ColumnName = "CP_PHU_TUNG"
        vtbTitle.Columns(10).ColumnName = "CP_VAT_TU"
        vtbTitle.Columns(11).ColumnName = "CP_NHAN_CONG"
        vtbTitle.Columns(12).ColumnName = "CP_DICH_VU"
        vtbTitle.Columns(13).ColumnName = "CP_KHAC"

        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TONG_CHI_PHI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "TONG_CHI_PHI", Commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("CP_NOI_DUNG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_NOI_DUNG", Commons.Modules.TypeLanguage)
        vRowTitle("CP_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_TIEN", Commons.Modules.TypeLanguage)
        vRowTitle("CP_TONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_TONG", Commons.Modules.TypeLanguage)
        vRowTitle("KQ_BAO_TRI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "KQ_BAO_TRI", Commons.Modules.TypeLanguage)
        vRowTitle("KQ_NGAY_NT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "KQ_NGAY_NT", Commons.Modules.TypeLanguage)
        vRowTitle("KQ_BT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "KQ_BT", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_NT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "NGUOI_NT", Commons.Modules.TypeLanguage)
        vRowTitle("CP_PHU_TUNG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_PHU_TUNG", Commons.Modules.TypeLanguage)
        vRowTitle("CP_VAT_TU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_VAT_TU", Commons.Modules.TypeLanguage)
        vRowTitle("CP_NHAN_CONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_NHAN_CONG", Commons.Modules.TypeLanguage)
        vRowTitle("CP_DICH_VU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_DICH_VU", Commons.Modules.TypeLanguage)
        vRowTitle("CP_KHAC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_NT", "CP_KHAC", Commons.Modules.TypeLanguage)



        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub


    Private Sub dtTNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtTNgay.Validating
        gvData.Nodes.Clear()
    End Sub

    Private Sub dtDNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtDNgay.Validating
        gvData.Nodes.Clear()
    End Sub
End Class
