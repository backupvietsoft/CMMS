Imports System.Data.SqlClient
Imports System.Data
Imports Commons


Public Class clsMain1
    'Danh sach tạo proceduce trong database
    ' get_DonDatHang cho bang  Don Dat Hang
    ' insert_DON_DAT_HANG
    ' get_DeXuatDatHang cho bang DE_XUAT_DAT_HANG    

    ''Lấy thông tin chung Đơn Đặt hàng

    Public Shared Function GetDataDayToDay(ByVal vNgay_BD As String, ByVal vNgay_KT As String) As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT DON_DAT_HANG.MS_DDH, DON_DAT_HANG.NGAY_LAP, DON_DAT_HANG.SO_DE_XUAT, DON_DAT_HANG.MS_KH, DON_DAT_HANG.THANH_TIEN, " & _
            " DON_DAT_HANG.NGUOI_XAC_NHAN, DON_DAT_HANG.NGUOI_DUYET, DON_DAT_HANG.NGUOI_DAT_HANG, DON_DAT_HANG.FAX, " & _
            " DON_DAT_HANG.DIEN_THOAI, DON_DAT_HANG.DIA_CHI_GIAO_HANG, DON_DAT_HANG.THOI_HAN_THANH_TOAN, DON_DAT_HANG.NGUOI_LIEN_HE, " & _
            " DON_DAT_HANG.DUYET, DON_DAT_HANG.VAT,DON_DAT_HANG.HINH_THUC_TT,DON_DAT_HANG.BAO_HANH,DON_DAT_HANG.GHI_CHU,DON_DAT_HANG.NGAY_GIAO,DON_DAT_HANG.SO_DDH, KHACH_HANG.TEN_CONG_TY,KHACH_HANG.TEL,KHACH_HANG.FAX,KHACH_HANG.DIA_CHI,KHACH_HANG.TEN_NDD,DON_DAT_HANG.NOI_DUNG_DDH,  DON_DAT_HANG.YKIEN_DUYET2, DON_DAT_HANG.YKIEN_DUYET3, DON_DAT_HANG.YKIEN_DUYET4, DON_DAT_HANG.DUYET1, " & _
            " DON_DAT_HANG.DUYET2, DON_DAT_HANG.DUYET3, DON_DAT_HANG.DUYET4, DON_DAT_HANG.TRANGTHAI, DON_DAT_HANG.YKIEN_DUYET,DON_DAT_HANG.CAN_CU " & _
            " FROM DON_DAT_HANG INNER JOIN KHACH_HANG ON DON_DAT_HANG.MS_KH = KHACH_HANG.MS_KH" & _
            " WHERE  DON_DAT_HANG.NGAY_LAP BETWEEN '" & vNgay_BD & "' AND '" & vNgay_KT & "'"
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
        Catch ex As Exception

        End Try
        Return vtbTem
    End Function

    'Get by trang thai
    Public Shared Function GetDDhbyMDDH(ByVal vma As String) As DataTable
        Try
            Dim vtbTem As DataTable = New DataTable()
            Dim vCon As SqlConnection = New SqlConnection()
            Try
                Dim sqlStr As String = "SELECT  MS_DDH, TRANGTHAI, SO_DDH, NGAY_LAP" & _
                                    " FROM DON_DAT_HANG WHERE  MS_DDH = '" & vma & "'"
                If (clsConnect.OpenConnect(vCon)) Then
                    Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                    vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                    vAdpt.Fill(vtbTem)
                    Return vtbTem
                End If
            Catch ex As Exception
            End Try
            Return vtbTem
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    'Lấy thông tin Chung 
    Public Shared Function GetInfo(ByVal proName As String) As DataTable
        Dim vTbTem As DataTable = New DataTable()
        Dim vConect As SqlConnection = New SqlConnection()
        Dim vCmd As SqlCommand = New SqlCommand()
        Try
            If (clsConnect.OpenConnect(vConect)) Then
                vCmd.Connection = vConect
                vCmd.CommandType = CommandType.StoredProcedure
                vCmd.CommandText = proName
                Dim vAdapter As SqlDataAdapter = New SqlDataAdapter(vCmd)
                vAdapter.Fill(vTbTem)
                Return vTbTem
            End If
        Catch ex As Exception
        End Try
        Return vTbTem
    End Function
    'Cập nhật Thông tin chung Đơn Đặt hàng
    Public Shared Function InsertDDH(ByVal vMs_ddh As String, ByVal vNgay_lap As Date, _
        ByVal vSo_De_Xuat As String, ByVal vMs_KH As String, ByVal vThanh_Tien As Double, _
        ByVal vNguoi_xac_nhan As String, ByVal vNguoi_duyet As String, ByVal vNguoi_Dathang As String, _
        ByVal vFax As String, ByVal vDienThoai As String, ByVal vDia_chi_Giao As String, _
        ByVal vThoiHan_TT As String, ByVal vNguoi_LH As String, ByVal vDuyet As Integer, ByVal vVAT As Double, ByVal vHT_TT As String, ByVal vBao_Hanh As String, ByVal vGhichu As String, ByVal vNgay_Giao As DateTime, ByVal vSoDDH As String, ByVal vNoiDung As String, ByVal vDiachi As String, ByVal vCanCu As String, ByVal vProStName As String) As Boolean
        Try
            Dim sqlCon As SqlConnection = New SqlConnection()
            Dim Cmd As SqlCommand = New SqlCommand()
            Cmd.CommandText = vProStName
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = sqlCon
            Cmd.Parameters.Add(New SqlParameter("@MS_DDH", SqlDbType.NVarChar, 30)).Value = vMs_ddh
            Cmd.Parameters.Add(New SqlParameter("@NGAY_LAP", SqlDbType.DateTime, 8)).Value = vNgay_lap
            Cmd.Parameters.Add(New SqlParameter("@SO_DE_XUAT", SqlDbType.NVarChar, 50)).Value = vSo_De_Xuat
            Cmd.Parameters.Add(New SqlParameter("@MS_KH", SqlDbType.NVarChar, 7)).Value = vMs_KH
            Cmd.Parameters.Add(New SqlParameter("@THANH_TIEN", SqlDbType.Float, 8)).Value = vThanh_Tien
            Cmd.Parameters.Add(New SqlParameter("@NGUOI_XAC_NHAN", SqlDbType.NVarChar, 50)).Value = vNguoi_xac_nhan
            Cmd.Parameters.Add(New SqlParameter("@NGUOI_DUYET", SqlDbType.NVarChar, 50)).Value = vNguoi_duyet
            Cmd.Parameters.Add(New SqlParameter("@NGUOI_DAT_HANG", SqlDbType.NVarChar, 50)).Value = vNguoi_Dathang
            Cmd.Parameters.Add(New SqlParameter("@FAX", SqlDbType.NVarChar, 255)).Value = vFax
            Cmd.Parameters.Add(New SqlParameter("@DIEN_THOAI", SqlDbType.NVarChar, 255)).Value = vDienThoai
            Cmd.Parameters.Add(New SqlParameter("@DIA_CHI_GIAO_HANG", SqlDbType.NVarChar, 255)).Value = vDia_chi_Giao
            Cmd.Parameters.Add(New SqlParameter("@THOI_HAN_THANH_TOAN", SqlDbType.NVarChar, 255)).Value = vThoiHan_TT
            Cmd.Parameters.Add(New SqlParameter("@NGUOI_LIEN_HE", SqlDbType.NVarChar, 255)).Value = vNguoi_LH
            Cmd.Parameters.Add(New SqlParameter("@DUYET", SqlDbType.Bit, 1)).Value = vDuyet
            Cmd.Parameters.Add(New SqlParameter("@VAT", SqlDbType.Float, 8)).Value = vVAT
            Cmd.Parameters.Add(New SqlParameter("@HINH_THUC_TT", SqlDbType.NVarChar, 255)).Value = vHT_TT
            Cmd.Parameters.Add(New SqlParameter("@BAO_HANH", SqlDbType.NVarChar, 255)).Value = vBao_Hanh
            Cmd.Parameters.Add(New SqlParameter("@GHI_CHU", SqlDbType.NVarChar, 255)).Value = vGhichu

            Cmd.Parameters.Add(New SqlParameter("@NOI_DUNG_DDH", SqlDbType.NVarChar, 255)).Value = vNoiDung
            Cmd.Parameters.Add(New SqlParameter("@DIA_CHI", SqlDbType.NVarChar, 255)).Value = vDiachi
            Cmd.Parameters.Add(New SqlParameter("@CAN_CU", SqlDbType.NVarChar, 255)).Value = vCanCu

            If (vNgay_Giao = Nothing) Then
                Cmd.Parameters.Add(New SqlParameter("@NGAY_GIAO", SqlDbType.DateTime, 8)).Value = DBNull.Value
            Else
                Cmd.Parameters.Add(New SqlParameter("@NGAY_GIAO", SqlDbType.DateTime, 8)).Value = vNgay_Giao
            End If

            Cmd.Parameters.Add(New SqlParameter("@SO_DDH", SqlDbType.NVarChar, 30)).Value = vSoDDH

            Try
                If (clsConnect.OpenConnect(sqlCon) = True) Then
                    Cmd.ExecuteNonQuery()
                    clsConnect.CloseConect(sqlCon)
                End If
            Finally

            End Try
            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function
    ' Xóa 1 DDH' thong tin chung 
    Public Shared Function DeleteDDH(ByVal vMS_DDH As String) As Boolean
        Try
            Dim vsqlStr As String = "Delete From DON_DAT_HANG WHERE MS_DDH = '" & vMS_DDH & "'"
            Dim vSqlcon As SqlConnection = New SqlConnection()
            If (clsConnect.OpenConnect(vSqlcon)) Then
                Dim vCmd As SqlCommand = New SqlCommand(vsqlStr, vSqlcon)
                vCmd.ExecuteNonQuery()
                Return True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


#Region "Chi tiết Phụ Tùng Vật Tư"

    Public Shared Function GetCT_DDH_VT(ByVal vMa_DDH) As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT DON_DAT_HANG_CHI_TIET.MS_PT,DON_DAT_HANG_CHI_TIET.MS_MAY,DON_DAT_HANG_CHI_TIET.NGOAI_TE,DON_DAT_HANG_CHI_TIET.TI_GIA," & _
                     " DON_DAT_HANG_CHI_TIET.SO_LUONG, DON_DAT_HANG_CHI_TIET.DON_GIA, IC_PHU_TUNG.TEN_PT,   " & _
                     " DON_VI_TINH.TEN_1 AS DVT,   0.00 AS THANH_TIEN, 0.00 AS THANH_TIEN_NT " & _
                     " FROM DON_DAT_HANG_CHI_TIET INNER JOIN IC_PHU_TUNG ON DON_DAT_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
                     " DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT WHERE MS_DDH = '" & vMa_DDH & "'"
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
        Catch ex As Exception
        End Try
        Return vtbTem
    End Function

    Public Shared Function GetVatTuPhuTung() As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, IC_PHU_TUNG.DVT, IC_PHU_TUNG.MS_LOAI_VT, " & _
                                    " DON_VI_TINH.TEN_1 FROM IC_PHU_TUNG INNER JOIN  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT "
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
            'Return vtbTem
        Catch ex As Exception
        End Try
        Return vtbTem
    End Function
    Public Shared Function GetVatTuPhuTung(ByVal vLoaiVT As String) As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, IC_PHU_TUNG.DVT, IC_PHU_TUNG.MS_LOAI_VT, " & _
                                    " DON_VI_TINH.TEN_1 FROM IC_PHU_TUNG INNER JOIN  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                                    "WHERE  IC_PHU_TUNG.MS_LOAI_VT = '" & vLoaiVT & "'"
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
            'Return vtbTem
        Catch ex As Exception
        End Try
        Return vtbTem
    End Function

    Public Shared Function GetVatTuPhuTungAll() As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, IC_PHU_TUNG.DVT, IC_PHU_TUNG.MS_LOAI_VT, " & _
                                    " DON_VI_TINH.TEN_1 FROM IC_PHU_TUNG INNER JOIN  DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT "

            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
            'Return vtbTem
        Catch ex As Exception
        End Try
        Return vtbTem
    End Function

    Public Shared Function GetLoaiVatTu() As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT MS_LOAI_VT, TEN_LOAI_VT_TV FROM LOAI_VT "
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
            'Return vtbTem
        Catch ex As Exception
        End Try
        Return vtbTem
    End Function


    '' Xoa 1 chi tiết trong đơn đặt hàng
    Public Shared Function DeleteItemCT_DDH(ByVal vMS_DDH As String, ByVal vMS_PT As String) As Boolean
        Try
            Dim vsqlStr As String = "Delete From DON_DAT_HANG_CHI_TIET WHERE MS_DDH = '" & vMS_DDH & "' AND MS_PT = '" & vMS_PT & "'"
            Dim vSqlcon As SqlConnection = New SqlConnection()
            If (clsConnect.OpenConnect(vSqlcon)) Then
                Dim vCmd As SqlCommand = New SqlCommand(vsqlStr, vSqlcon)
                vCmd.ExecuteNonQuery()
                Return True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Chi tiết đơn đặt hàng dịch vụ "
    Public Shared Function GetData_DichVu(ByVal vMa_DDH) As DataTable
        Try
            Dim vtbTem As DataTable = New DataTable()
            Dim vCon As SqlConnection = New SqlConnection()
            Try
                Dim sqlStr As String = "SELECT * ,0.00 AS THANH_TIEN, 0.00 AS THANH_TIEN_QD FROM DON_DAT_HANG_CHI_TIET_DICHVU  WHERE MS_DDH = '" & vMa_DDH & "'"
                If (clsConnect.OpenConnect(vCon)) Then
                    Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                    vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                    vAdpt.Fill(vtbTem)
                    Return vtbTem
                End If
            Catch ex As Exception
            End Try
            Return vtbTem
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function DeleteItem_DichVu(ByVal vMs_DDh As String, ByVal vMS_DDH_DV As String) As Boolean
        Try
            Dim vsqlStr As String = "Delete From DON_DAT_HANG_CHI_TIET_DICHVU WHERE MS_DDH = '" & vMs_DDh & "' AND MS_DDH_DV = '" & vMS_DDH_DV & "'"
            Dim vSqlcon As SqlConnection = New SqlConnection()
            If (clsConnect.OpenConnect(vSqlcon)) Then
                Dim vCmd As SqlCommand = New SqlCommand(vsqlStr, vSqlcon)
                vCmd.ExecuteNonQuery()
                Return True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Ti gia Ngoai Te"
    Public Shared Function GetNgoaite() As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT NGOAI_TE, TI_GIA, TI_GIA_USD FROM TI_GIA_NT "
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
            'Return vtbTem
        Catch ex As Exception
        End Try
        Return vtbTem
    End Function
#End Region

#Region "Đơn vị tính"
    Public Shared Function GetDVT() As DataTable
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Try
            Dim sqlStr As String = "SELECT DVT, TEN_1 as TEN FROM DON_VI_TINH "
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)
                Return vtbTem
            End If
            'Return vtbTem
        Catch ex As Exception
        End Try
        Return vtbTem
    End Function
#End Region

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
