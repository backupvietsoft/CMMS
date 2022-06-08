Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsDE_XUAT_MUA_HANGControler

        Public Sub New()
        End Sub
        Public Function GetDE_XUAT_MUA_HANG_CHI_TIETs(ByVal SO_DE_XUAT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDE_XUAT_MUA_HANG_CHI_TIETs", SO_DE_XUAT, commons.Modules.TypeLanguage))
            Return objDataTable
        End Function
        Public Function GetDE_XUAT_MUA_HANG_CHI_TIETs_VMPACK(ByVal SO_DE_XUAT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDE_XUAT_MUA_HANG_CHI_TIETs_VMPACK", SO_DE_XUAT, commons.Modules.TypeLanguage))
            Return objDataTable
        End Function
        Public Function GetDE_XUAT_MUA_HANG_CHI_TIETs_DUYTAN(ByVal SO_DE_XUAT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDE_XUAT_MUA_HANG_CHI_TIETs_DUYTAN", SO_DE_XUAT, commons.Modules.TypeLanguage))
            Return objDataTable
        End Function
        Public Function AddDE_XUAT_MUA_HANG(ByVal objDeXuat As clsDE_XUAT_MUA_HANGInfo, ByVal tb As DataTable) As String
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                If CheckSO_DE_XUAT(objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU) Then
                    Return ""
                End If
                If objDeXuat.SO_DE_XUAT_CU Is Nothing Then
                    SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG", objDeXuat.SO_DE_XUAT, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                            SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG_CHI_TIET", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"))
                        End If
                    Next
                Else
                    SqlHelper.ExecuteNonQuery(objTrans, "UpdateDE_XUAT_MUA_HANG", objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("TON_TAI") = 1 Then
                            If tb.Rows(i).Item("SO_LUONG").ToString = "" Or tb.Rows(i).Item("SO_LUONG").ToString = "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "DeleteDE_XUAT_MUA_HANG_CHI_TIET", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"))
                            Else
                                SqlHelper.ExecuteNonQuery(objTrans, "UpdateDE_XUAT_MUA_HANG_CHI_TIET", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"))
                            End If

                        Else
                            If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG_CHI_TIET", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"))
                            End If
                        End If
                    Next
                End If
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return ""
            Finally
                objConnection.Close()
            End Try
            Return objDeXuat.SO_DE_XUAT
        End Function
        Public Function AddDE_XUAT_MUA_HANG_VMPACK(ByVal objDeXuat As clsDE_XUAT_MUA_HANGInfo, ByVal tb As DataTable) As String
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                If CheckSO_DE_XUAT(objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU) Then
                    Return ""
                End If
                If objDeXuat.SO_DE_XUAT_CU Is Nothing Then
                    SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG", objDeXuat.SO_DE_XUAT, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO, objDeXuat.THEOKH, objDeXuat.THEOYEUCAU)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                            SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG_CHI_TIET_VMPACK", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("NHAN_HIEU"))
                        End If
                    Next
                Else
                    SqlHelper.ExecuteNonQuery(objTrans, "UpdateDE_XUAT_MUA_HANG", objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO, objDeXuat.THEOKH, objDeXuat.THEOYEUCAU)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("TON_TAI") = 1 Then
                            If tb.Rows(i).Item("SO_LUONG").ToString = "" Or tb.Rows(i).Item("SO_LUONG").ToString = "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "DeleteDE_XUAT_MUA_HANG_CHI_TIET", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"))
                            Else
                                SqlHelper.ExecuteNonQuery(objTrans, "UpdateDE_XUAT_MUA_HANG_CHI_TIET_VMPACK", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("NHAN_HIEU"))
                            End If

                        Else
                            If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG_CHI_TIET_VMPACK", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("NHAN_HIEU"))
                            End If
                        End If
                    Next
                End If
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return ""
            Finally
                objConnection.Close()
            End Try
            Return objDeXuat.SO_DE_XUAT
        End Function
        Public Function AddDE_XUAT_MUA_HANG_DUYTAN(ByVal objDeXuat As clsDE_XUAT_MUA_HANGInfo, ByVal tb As DataTable) As String
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                If CheckSO_DE_XUAT(objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU) Then
                    Return ""
                End If
                If objDeXuat.SO_DE_XUAT_CU Is Nothing Then
                    SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG_DUYTAN", objDeXuat.SO_DE_XUAT, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                            SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG_CHI_TIET_DUYTAN", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("TON_KHO"), tb.Rows(i).Item("NHAN_HIEU"), tb.Rows(i).Item("NUOC_SX"), tb.Rows(i).Item("DON_GIA"), tb.Rows(i).Item("HOA_DON"), tb.Rows(i).Item("MS_KH"), tb.Rows(i).Item("NGAY_CAN_HANG"), tb.Rows(i).Item("THOI_HAN_SD"), tb.Rows(i).Item("CONG_DUNG"), tb.Rows(i).Item("LOAI"))
                        End If
                    Next
                Else
                    SqlHelper.ExecuteNonQuery(objTrans, "UpdateDE_XUAT_MUA_HANG_DUYTAN", objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("TON_TAI") = 1 Then
                            If tb.Rows(i).Item("SO_LUONG").ToString = "" Or tb.Rows(i).Item("SO_LUONG").ToString = "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "DeleteDE_XUAT_MUA_HANG_CHI_TIET", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"))
                            Else
                                SqlHelper.ExecuteNonQuery(objTrans, "UpdateDE_XUAT_MUA_HANG_CHI_TIET_DUYTAN", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("TON_KHO"), tb.Rows(i).Item("NHAN_HIEU"), tb.Rows(i).Item("MS_HSX"), tb.Rows(i).Item("DON_GIA"), tb.Rows(i).Item("HOA_DON"), tb.Rows(i).Item("MS_KH"), tb.Rows(i).Item("NGAY_CAN_HANG"), tb.Rows(i).Item("THOI_HAN_SD"), tb.Rows(i).Item("CONG_DUNG"), tb.Rows(i).Item("LOAI"))
                            End If
                        Else
                            If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "AddDE_XUAT_MUA_HANG_CHI_TIET_DUYTAN", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("TON_KHO"), tb.Rows(i).Item("NHAN_HIEU"), tb.Rows(i).Item("MS_HSX"), tb.Rows(i).Item("DON_GIA"), tb.Rows(i).Item("HOA_DON"), tb.Rows(i).Item("MS_KH"), tb.Rows(i).Item("NGAY_CAN_HANG"), tb.Rows(i).Item("THOI_HAN_SD"), tb.Rows(i).Item("CONG_DUNG"), tb.Rows(i).Item("LOAI"))
                            End If
                        End If
                    Next
                End If
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return ""
            Finally
                objConnection.Close()
            End Try
            Return objDeXuat.SO_DE_XUAT
        End Function
        Function CheckSO_DE_XUAT(ByVal SO_DE_XUAT As String, ByVal SO_DE_XUAT_CU As String) As Boolean
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckSO_DE_XUAT", SO_DE_XUAT, SO_DE_XUAT_CU)
            While objReader.Read
                objReader.Close()
                Return True
            End While
            objReader.Close()
            Return False
        End Function
        Public Sub DeleteDE_XUAT_MUA_HANG_CHI_TIET(ByVal SO_DE_XUAT As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDE_XUAT_MUA_HANG_CHI_TIET", SO_DE_XUAT, MS_PT)
        End Sub
        Public Sub DeleteDE_XUAT_MUA_HANG(ByVal SO_DE_XUAT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDE_XUAT_MUA_HANG", SO_DE_XUAT)
        End Sub

        Public Function GetDE_XUAT_MUA_HANG_CHI_TIETs_CS(ByVal SO_DE_XUAT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetDE_XUAT_MUA_HANG_CHI_TIETs_CS", SO_DE_XUAT, commons.Modules.TypeLanguage))
            Return objDataTable
        End Function
        Public Function AddDE_XUAT_MUA_HANG_CS(ByVal objDeXuat As clsDE_XUAT_MUA_HANGInfo, ByVal tb As DataTable) As String
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                If CheckSO_DE_XUAT(objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU) Then
                    Return ""
                End If
                If objDeXuat.SO_DE_XUAT_CU Is Nothing Then
                    SqlHelper.ExecuteNonQuery(objTrans, "H_AddDE_XUAT_MUA_HANG_CS", objDeXuat.SO_DE_XUAT, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO, objDeXuat.THEOKH, objDeXuat.THEOYEUCAU, objDeXuat.GHI_CHU)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        Dim tonMin As String = ""
                        Dim tonMax As String = ""
                        Dim gtTMin As Double = 0
                        Dim gtTMax As Double = 0
                        Try
                            tonMin = IIf(IsDBNull(tb.Rows(i).Item("TON_MIN")), "NULL", "NOTNULL")
                            tonMax = IIf(IsDBNull(tb.Rows(i).Item("TON_MAX")), "NULL", "NOTNULL")
                        Catch ex As Exception
                        End Try
                        Try
                            If tonMin = "NOTNULL" Then
                                gtTMin = Double.Parse(tb.Rows(i).Item("TON_MIN").ToString())
                            End If
                        Catch ex As Exception
                            gtTMin = 0
                        End Try
                        Try
                            If tonMax = "NOTNULL" Then
                                gtTMax = Double.Parse(tb.Rows(i).Item("TON_MAX").ToString())
                            End If
                        Catch ex As Exception
                            gtTMax = 0
                        End Try
                        Dim vDonGia As Double = tb.Rows(i).Item("DON_GIA")

                        Dim vNgoaiTe As String = tb.Rows(i).Item("NGOAI_TE")
                        Dim vTi_Gia As Double = tb.Rows(i).Item("TI_GIA")
                        Dim vTi_Gia_USD As Double = 0

                        If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                            SqlHelper.ExecuteNonQuery(objTrans, "H_AddDE_XUAT_MUA_HANG_CHI_TIET_CS", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), gtTMin, gtTMax, tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("NHAN_HIEU"), vDonGia, vNgoaiTe, vTi_Gia, vTi_Gia_USD)
                        End If
                    Next
                Else
                    SqlHelper.ExecuteNonQuery(objTrans, "H_UpdateDE_XUAT_MUA_HANG_CS", objDeXuat.SO_DE_XUAT, objDeXuat.SO_DE_XUAT_CU, objDeXuat.MS_DON_VI, objDeXuat.NGAY, objDeXuat.NGUOI_NHAN, objDeXuat.NGUOI_DUYET, objDeXuat.NGAY_GIAO, objDeXuat.THEOKH, objDeXuat.THEOYEUCAU, objDeXuat.GHI_CHU)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        Dim tonMin As String = ""
                        Dim tonMax As String = ""
                        Dim gtTMin As Double = 0
                        Dim gtTMax As Double = 0
                        Try
                            tonMin = IIf(IsDBNull(tb.Rows(i).Item("TON_MIN")), "NULL", "NOTNULL")
                            tonMax = IIf(IsDBNull(tb.Rows(i).Item("TON_MAX")), "NULL", "NOTNULL")
                        Catch ex As Exception
                        End Try
                        Try
                            If tonMin = "NOTNULL" Then
                                gtTMin = Double.Parse(tb.Rows(i).Item("TON_MIN").ToString())
                            End If
                        Catch ex As Exception
                            gtTMin = 0
                        End Try
                        Try
                            If tonMax = "NOTNULL" Then
                                gtTMax = Double.Parse(tb.Rows(i).Item("TON_MAX").ToString())
                            End If
                        Catch ex As Exception
                            gtTMax = 0
                        End Try

                        Dim vDonGia As Double = tb.Rows(i).Item("DON_GIA")

                        Dim vNgoaiTe As String = tb.Rows(i).Item("NGOAI_TE")
                        Dim vTi_Gia As Double = tb.Rows(i).Item("TI_GIA")
                        Dim vTi_Gia_USD As Double = 0

                        If tb.Rows(i).Item("TON_TAI") = 1 Then
                            If tb.Rows(i).Item("SO_LUONG").ToString = "" Or tb.Rows(i).Item("SO_LUONG").ToString = "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "DeleteDE_XUAT_MUA_HANG_CHI_TIET", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"))
                            Else
                                SqlHelper.ExecuteNonQuery(objTrans, "H_UpdateDE_XUAT_MUA_HANG_CHI_TIET_CS", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), gtTMin, gtTMax, tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("NHAN_HIEU"), vDonGia, vNgoaiTe, vTi_Gia, vTi_Gia_USD)
                            End If

                        Else
                            If tb.Rows(i).Item("SO_LUONG").ToString <> "" And tb.Rows(i).Item("SO_LUONG").ToString <> "0" Then
                                SqlHelper.ExecuteNonQuery(objTrans, "H_AddDE_XUAT_MUA_HANG_CHI_TIET_CS", objDeXuat.SO_DE_XUAT, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), gtTMin, gtTMax, tb.Rows(i).Item("GHI_CHU"), tb.Rows(i).Item("NHAN_HIEU"), vDonGia, vNgoaiTe, vTi_Gia, vTi_Gia_USD)
                            End If
                        End If
                    Next
                End If
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return ""
            Finally
                objConnection.Close()
            End Try
            Return objDeXuat.SO_DE_XUAT
        End Function
    End Class
End Namespace
