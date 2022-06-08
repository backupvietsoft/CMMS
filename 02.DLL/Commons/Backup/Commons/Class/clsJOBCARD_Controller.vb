Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class JOBCARD_Controller
        Public Sub New()
        End Sub

        Function Get_Danhsachphieubaotri(ByVal Loai_TB As String, ByVal Nhom_TB As String) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Danhsachphieubaotri", Loai_TB, Nhom_TB))
            Return dttable
        End Function

        Function get_Cuasobaotri(ByVal Thietbi As String, ByVal Ngay_BT As String, ByVal DenNgay As String) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_cuasobaotri", Thietbi, Ngay_BT, DenNgay))
            Return dttable
        End Function
        Function get_CongViec_DKNhanSu(ByVal PhieuBT As String, ByVal user As String) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_CongViec_DKNhanSu", PhieuBT, user))
            Return dttable
        End Function
        Function get_Congviecchinh(ByVal PhieuBT As String, ByVal user As String) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_Congviecchinh", PhieuBT, user))
            Return dttable
        End Function

        Function get_Congviecphu(ByVal PhieuBT As String) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_Congviecphu", PhieuBT))
            Return dttable
        End Function

        Function get_Kehoachcongviec(ByVal ms_pbt As String, ByVal Congviec As Integer, ByVal ms_bp As String, ByVal gio As String, ByVal phut As String) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_Kehoachcongviec", ms_pbt, Congviec, ms_bp, gio, phut))
            Return dttable
        End Function

        Function get_kehoachcongviecphu(ByVal Phieu_bt As String, ByVal congviecphu As String, ByVal gio As String, ByVal phut As String) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_Kehoachcongviecphu", Phieu_bt, congviecphu, gio, phut))
            Return dttable
        End Function

        Function get_Kehoachnhanvien(ByVal phieu_bt As String, ByVal congviec As Integer, ByVal bophan As String, ByVal THEM As Byte) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_Kehoachnhanvienchinh", phieu_bt, congviec, bophan, THEM))
            Return dttable
        End Function

        Function get_Kehoachnhanvienphu(ByVal phieu_bt As String, ByVal congviecphu As Integer, ByVal THEM As Byte) As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_Kehoachnhanvienphu", phieu_bt, congviecphu, THEM))
            Return dttable
        End Function

        Sub add_Congviecchinh(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Add_PHIEU_BAO_TRI_CONG_VIEC_KE_HOACH", _
                                    jobcardinfo.PHIEU_BT, jobcardinfo.CONG_VIEC, jobcardinfo.BO_PHAN, _
                                    jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_GIO)
        End Sub

        Sub add_Congviecphutro(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Add_PHIEU_BAO_TRI_CV_KH_PHU_TRO", _
                                    jobcardinfo.PHIEU_BT, jobcardinfo.STT, _
                                    jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_GIO)
        End Sub

        Sub update_congviecchinh(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CONG_VIEC_KE_HOACH", _
                                    jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_GIO, _
                                    jobcardinfo.NGAY_tmp, jobcardinfo.TU_GIO_tmp)
        End Sub

        Sub update_congviecphutro(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CV_KH_PHU_TRO", _
                                    jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_GIO, _
                                    jobcardinfo.NGAY_tmp, jobcardinfo.TU_GIO_tmp)
        End Sub

        Sub add_congnhancongviecchinh(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Add_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET", _
                                    jobcardinfo.PHIEU_BT, jobcardinfo.CONG_VIEC, jobcardinfo.BO_PHAN, _
                                    jobcardinfo.CONG_NHAN, jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_NGAY, jobcardinfo.DEN_GIO, jobcardinfo.HOAN_THANH)
        End Sub

        Sub add_congnhancongviec_PBT(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Add_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU", _
                                    jobcardinfo.PHIEU_BT, jobcardinfo.CONG_VIEC, jobcardinfo.BO_PHAN, jobcardinfo.CONG_NHAN)
        End Sub

        Sub add_congnhancongviecphu(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Add_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO", _
                                    jobcardinfo.PHIEU_BT, jobcardinfo.STT, jobcardinfo.CONG_NHAN, _
                                    jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_NGAY, jobcardinfo.DEN_GIO, jobcardinfo.HOAN_THANH)
        End Sub

        Sub update_congnhancongviecchinh(ByVal jobcardinfo As clsJobCardInfo)
            If jobcardinfo.HOAN_THANH Then
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET", _
                                                            jobcardinfo.PHIEU_BT, jobcardinfo.BO_PHAN, jobcardinfo.CONG_VIEC, jobcardinfo.CONG_NHAN, jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_NGAY, jobcardinfo.DEN_GIO, _
                                                                    jobcardinfo.CONG_NHAN_tmp, jobcardinfo.NGAY_tmp, jobcardinfo.TU_GIO_tmp, 1)
            Else
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET", _
                                            jobcardinfo.PHIEU_BT, jobcardinfo.BO_PHAN, jobcardinfo.CONG_VIEC, jobcardinfo.CONG_NHAN, jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_NGAY, jobcardinfo.DEN_GIO, _
                                                    jobcardinfo.CONG_NHAN_tmp, jobcardinfo.NGAY_tmp, jobcardinfo.TU_GIO_tmp, 0)

                'Dim str As String

                'str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET SET " & _
                '             "MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "', " & _
                '             "NGAY=convert(datetime,'" & Format(CDate(jobcardinfo.NGAY), "dd/MMM/yyyy") & "',103), " & _
                '             "TU_GIO=convert(datetime,'" & jobcardinfo.TU_GIO & "',114), " & _
                '             "DEN_GIO=convert(datetime,'" & jobcardinfo.DEN_GIO & "',114), " & _
                '             "HOAN_THANH=0, " & _
                '             "DEN_NGAY=CONVERT(DATETIME,'" & Format(CDate(jobcardinfo.DEN_NGAY), "dd/MMM/yyyy") & "',103) " & _
                '      "WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' AND MS_BO_PHAN='" & jobcardinfo.BO_PHAN & "' AND MS_CV=" & jobcardinfo.CONG_VIEC & " " & _
                '         "AND MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN_tmp & "' AND convert(datetime,NGAY,103)=convert(datetime,'" & Format(CDate(jobcardinfo.NGAY_tmp), "dd/MMM/yyyy") & "',103) " & _
                '         "AND convert(datetime,TU_GIO,114)='" & jobcardinfo.TU_GIO_tmp & "'"



                ''                str = "select * from PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET"
                ''                where()
                ''	MS_PHIEU_BAO_TRI='WO-200901001' AND MS_BO_PHAN='07' AND MS_CV=379 
                ''	AND MS_CONG_NHAN='A0498' AND convert(datetime,NGAY,103)=convert(datetime,'10/jan/2009',103)
                ''--	 AND convert(datetime,TU_GIO,114)=convert(datetime,@TU_GIO_tmp,114)
                ''	 AND convert(datetime,TU_GIO,114)='01/01/1900 08:00:00'


            End If

        End Sub

        Sub update_congnhancongviec_PBT(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU", _
                                    jobcardinfo.CONG_NHAN, jobcardinfo.CONG_NHAN_tmp)
        End Sub

        Sub update_congnhancongviecphu(ByVal jobcardinfo As clsJobCardInfo)
            If jobcardinfo.HOAN_THANH Then
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO", _
                                                                  jobcardinfo.PHIEU_BT, jobcardinfo.STT, jobcardinfo.CONG_NHAN, jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_NGAY, jobcardinfo.DEN_GIO, _
                                                                    jobcardinfo.CONG_NHAN_tmp, jobcardinfo.NGAY_tmp, jobcardinfo.TU_GIO_tmp, 1)
            Else
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Update_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO", _
                                                  jobcardinfo.PHIEU_BT, jobcardinfo.STT, jobcardinfo.CONG_NHAN, jobcardinfo.NGAY, jobcardinfo.TU_GIO, jobcardinfo.DEN_NGAY, jobcardinfo.DEN_GIO, _
                                                    jobcardinfo.CONG_NHAN_tmp, jobcardinfo.NGAY_tmp, jobcardinfo.TU_GIO_tmp, 0)
            End If

        End Sub

        Sub delete_congviecchinh(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_PHIEU_BAO_TRI_CONG_VIEC_KE_HOACH", _
                                    jobcardinfo.PHIEU_BT, jobcardinfo.CONG_VIEC, jobcardinfo.BO_PHAN, _
                                    jobcardinfo.NGAY, jobcardinfo.TU_GIO)
        End Sub

        Sub delete_congviecphu(ByVal jobcardinfo As clsJobCardInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_PHIEU_BAO_TRI_CV_KH_PHU_TRO", _
                                    jobcardinfo.PHIEU_BT, jobcardinfo.STT, jobcardinfo.NGAY, jobcardinfo.TU_GIO)
        End Sub

        Sub delete_congnhancongviecchinh(ByVal jobcardinfo As clsJobCardInfo)
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET", _
            '                        jobcardinfo.PHIEU_BT, jobcardinfo.CONG_VIEC, jobcardinfo.BO_PHAN, _
            '                        jobcardinfo.CONG_NHAN, jobcardinfo.NGAY, jobcardinfo.TU_GIO)

            Dim str As String, dtReader As SqlDataReader
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim sqlTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' and MS_CV=" & jobcardinfo.CONG_VIEC & " and MS_BO_PHAN='" & jobcardinfo.BO_PHAN & "' " & _
                             "and MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "' and NGAY='" & Format(CDate(jobcardinfo.NGAY), "dd/MMM/yyyy") & "' and TU_GIO=convert(datetime,'" & jobcardinfo.TU_GIO & "',114)"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

                str = "SELECT ISNULL(COUNT(*),0) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' and MS_CV=" & jobcardinfo.CONG_VIEC & " and MS_BO_PHAN='" & jobcardinfo.BO_PHAN & "'"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
                dtReader.Read()

                If dtReader.Item(0) = 0 Then
                    str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU  WHERE  MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' and MS_CV=" & jobcardinfo.CONG_VIEC & " and MS_BO_PHAN='" & jobcardinfo.BO_PHAN & "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
                sqlTrans.Commit()
            Catch ex As Exception
                sqlTrans.Rollback()
            Finally
                objConnection.Close()
            End Try
        End Sub

        Sub delete_congnhancongviecphu(ByVal jobcardinfo As clsJobCardInfo)
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO", _
            '                        jobcardinfo.PHIEU_BT, jobcardinfo.STT, _
            '                        jobcardinfo.CONG_NHAN, jobcardinfo.NGAY, jobcardinfo.TU_GIO)

            Dim str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO " & _
                      "WHERE MS_PHIEU_BAO_TRI='" & jobcardinfo.PHIEU_BT & "' AND STT=" & jobcardinfo.STT & " and MS_CONG_NHAN='" & jobcardinfo.CONG_NHAN & "' and NGAY='" & Format(CDate(jobcardinfo.NGAY), "dd/MMM/yyyy") & "' and TU_GIO=convert(datetime,'" & Format(CDate(jobcardinfo.TU_GIO), "dd/MMM/yyyy HH:mm:ss") & "')"

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End Sub

        Public Function Get_CONG_NHAN() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetcboCONG_NHANs"))
            Return objDataTable
        End Function
    End Class
End Namespace