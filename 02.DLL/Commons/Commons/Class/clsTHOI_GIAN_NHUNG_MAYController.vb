Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsTHOI_GIAN_NHUNG_MAYController
        Public Sub New()
        End Sub

        Public Function GetTHOI_GIAN_NGUNG_MAYs(ByVal NGAY As String, ByVal DEN_NGAY As String, ByVal USERNAME As String, ByVal MS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAYs", NGAY, DEN_NGAY, USERNAME, MS_LOAI_MAY))
            Return objDataTable
        End Function
        Public Function GetTHOI_GIAN_NGUNG_MAYs_BAYER(ByVal NGAY As String, ByVal DEN_NGAY As String, ByVal USERNAME As String, ByVal MS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAYs_BAYER", NGAY, DEN_NGAY, USERNAME, MS_LOAI_MAY))
            Return objDataTable
        End Function


        Public Function GetTHOI_GIAN_NGUNG_MAYs_THEM(ByVal NGAY As String, ByVal USERNAME As String, ByVal MS_LOAI_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAYs_THEM", NGAY, USERNAME, MS_LOAI_MAY))
            Return objDataTable
        End Function
        Public Function GetTHOI_GIAN_NGUNG_MAY(ByVal USERNAME As String, ByVal MS_MAY As String, ByVal TU_NGAY As String, ByVal DEN_NGAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAY", USERNAME, MS_MAY, TU_NGAY, DEN_NGAY))
            Return objDataTable
        End Function
        Public Function AddTHOI_GIAN_NGUNG_MAY_BAYER(ByVal tb As DataTable, ByVal NGAY As String, ByVal DEN_NGAY As String, ByVal MS_LOAI_MAY As String)
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            Dim dt As New DataTable
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                SqlHelper.ExecuteNonQuery(objTrans, "DeleteTHOI_GIAN_NGUNG_MAY_ALL", NGAY, DEN_NGAY, Commons.Modules.UserName, MS_LOAI_MAY)
                For i As Integer = 0 To tb.Rows.Count - 1
                    If tb.Rows(i).Item("TU_GIO").ToString <> "" And tb.Rows(i).Item("TU_GIO").ToString <> "  :" Then
                        Dim objThoiGianNgungMayInfo As New clsTHOI_GIAN_NHUNG_MAYInfo
                        objThoiGianNgungMayInfo.MS_MAY = tb.Rows(i).Item("MS_MAY")
                        objThoiGianNgungMayInfo.NGAY = Format(tb.Rows(i).Item("NGAY"), "Short date")
                        objThoiGianNgungMayInfo.TU_GIO = Format(tb.Rows(i).Item("TU_GIO"), "Long time")
                        objThoiGianNgungMayInfo.DEN_GIO = Format(tb.Rows(i).Item("DEN_GIO").ToString, "Long time")
                        objThoiGianNgungMayInfo.DEN_NGAY = Format(tb.Rows(i).Item("DEN_NGAY"), "Short date")
                        objThoiGianNgungMayInfo.MS_NGUYEN_NHAN = tb.Rows(i).Item("MS_NGUYEN_NHAN")
                        objThoiGianNgungMayInfo.MS_PHIEU_BAO_TRI = tb.Rows(i).Item("MS_PHIEU_BAO_TRI").ToString
                        objThoiGianNgungMayInfo.GHI_CHU = tb.Rows(i).Item("GHI_CHU").ToString
                        objThoiGianNgungMayInfo.NGUOI_GIAI_QUYET = tb.Rows(i).Item("NGUOI_GIAI_QUYET").ToString
                        objThoiGianNgungMayInfo.DUNG = IIf(tb.Rows(i).Item("DUNG").ToString = "", 0, tb.Rows(i).Item("DUNG"))
                        objThoiGianNgungMayInfo.MS_N_XUONG = IIf(tb.Rows(i).Item("MS_N_XUONG").ToString = "", "NULL", tb.Rows(i).Item("MS_N_XUONG"))
                        objThoiGianNgungMayInfo.NGAY_SUA = tb.Rows(i).Item("NGAY_SUA").ToString
                        objThoiGianNgungMayInfo.GIO_SUA = tb.Rows(i).Item("GIO_SUA").ToString
                        objThoiGianNgungMayInfo.NGUOI_DUNG_MAY = tb.Rows(i).Item("NGUOI_GIAI_QUYET").ToString

                        ' objThoiGianNgungMayInfo.STT = System.DBNull.Value 'IIf(IsDBNull(tb.Rows(i).Item("STT")), System.DBNull.Value, tb.Rows(i).Item("STT"))

                        'HIEU SUA 13/06/08
                        'dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "procHE_THONG_MAY", tb.Rows(i).Item("MS_MAY")))
                        Try
                            Try
                                objThoiGianNgungMayInfo.THOI_GIAN_SUA_CHUA = Convert.ToDouble(tb.Rows(i).Item("THOI_GIAN_SUA_CHUA"))
                            Catch ex As Exception
                            End Try
                            Try
                                objThoiGianNgungMayInfo.MS_HE_THONG = Convert.ToDouble(tb.Rows(i).Item("MS_HE_THONG"))
                            Catch ex As Exception
                            End Try

                            SqlHelper.ExecuteNonQuery(objTrans, "AddTHOI_GIAN_NGUNG_MAY_BAYER", _
                            objThoiGianNgungMayInfo.MS_MAY, objThoiGianNgungMayInfo.NGAY, _
                            objThoiGianNgungMayInfo.TU_GIO, objThoiGianNgungMayInfo.NGAY_SUA, objThoiGianNgungMayInfo.GIO_SUA, _
                            objThoiGianNgungMayInfo.DEN_NGAY, objThoiGianNgungMayInfo.DEN_GIO, _
                            objThoiGianNgungMayInfo.MS_NGUYEN_NHAN, objThoiGianNgungMayInfo.MS_PHIEU_BAO_TRI, _
                            objThoiGianNgungMayInfo.GHI_CHU, objThoiGianNgungMayInfo.NGUOI_GIAI_QUYET, _
                            objThoiGianNgungMayInfo.DUNG, objThoiGianNgungMayInfo.MS_HE_THONG, _
                            objThoiGianNgungMayInfo.THOI_GIAN_SUA_CHUA, objThoiGianNgungMayInfo.MS_N_XUONG, _
                            IIf(IsDBNull(tb.Rows(i).Item("STT")), System.DBNull.Value, tb.Rows(i).Item("STT")), _
                            IIf(IsDBNull(tb.Rows(i).Item("MS_CONG_NHAN")), System.DBNull.Value, tb.Rows(i).Item("MS_CONG_NHAN")))
                        Catch ex As Exception
                            objTrans.Rollback()
                        End Try

                    End If
                Next
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return False
            Finally
                objConnection.Close()
            End Try
            Return True
        End Function
        Public Function AddTHOI_GIAN_NGUNG_MAY(ByVal tb As DataTable, ByVal NGAY As String, ByVal DEN_NGAY As String, ByVal MS_LOAI_MAY As String)
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            Dim dt As New DataTable
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                SqlHelper.ExecuteNonQuery(objTrans, "DeleteTHOI_GIAN_NGUNG_MAY_ALL", NGAY, DEN_NGAY, Commons.Modules.UserName, MS_LOAI_MAY)
                For i As Integer = 0 To tb.Rows.Count - 1
                    If tb.Rows(i).Item("TU_GIO").ToString <> "" And tb.Rows(i).Item("TU_GIO").ToString <> "  :" Then
                        Dim objThoiGianNgungMayInfo As New clsTHOI_GIAN_NHUNG_MAYInfo
                        objThoiGianNgungMayInfo.MS_MAY = tb.Rows(i).Item("MS_MAY")
                        objThoiGianNgungMayInfo.NGAY = Format(tb.Rows(i).Item("NGAY"), "Short date")
                        objThoiGianNgungMayInfo.TU_GIO = Format(tb.Rows(i).Item("TU_GIO"), "Long time")
                        objThoiGianNgungMayInfo.DEN_GIO = Format(tb.Rows(i).Item("DEN_GIO").ToString, "Long time")
                        objThoiGianNgungMayInfo.DEN_NGAY = Format(tb.Rows(i).Item("DEN_NGAY"), "Short date")
                        objThoiGianNgungMayInfo.MS_NGUYEN_NHAN = tb.Rows(i).Item("MS_NGUYEN_NHAN")
                        objThoiGianNgungMayInfo.MS_PHIEU_BAO_TRI = tb.Rows(i).Item("MS_PHIEU_BAO_TRI").ToString
                        objThoiGianNgungMayInfo.GHI_CHU = tb.Rows(i).Item("GHI_CHU").ToString
                        objThoiGianNgungMayInfo.NGUOI_GIAI_QUYET = tb.Rows(i).Item("NGUOI_GIAI_QUYET").ToString
                        objThoiGianNgungMayInfo.DUNG = IIf(tb.Rows(i).Item("DUNG").ToString = "", 0, tb.Rows(i).Item("DUNG"))
                        objThoiGianNgungMayInfo.MS_N_XUONG = IIf(tb.Rows(i).Item("MS_N_XUONG").ToString = "", "NULL", tb.Rows(i).Item("MS_N_XUONG"))

                        'HIEU SUA 13/06/08
                        'dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "procHE_THONG_MAY", tb.Rows(i).Item("MS_MAY")))
                        Try
                            Try
                                objThoiGianNgungMayInfo.THOI_GIAN_SUA_CHUA = Convert.ToDouble(tb.Rows(i).Item("THOI_GIAN_SUA_CHUA"))
                            Catch ex As Exception
                            End Try
                            Try
                                objThoiGianNgungMayInfo.MS_HE_THONG = Convert.ToDouble(tb.Rows(i).Item("MS_HE_THONG"))
                            Catch ex As Exception
                            End Try
                            SqlHelper.ExecuteNonQuery(objTrans, "AddTHOI_GIAN_NGUNG_MAY", objThoiGianNgungMayInfo.MS_MAY, objThoiGianNgungMayInfo.NGAY, objThoiGianNgungMayInfo.TU_GIO, _
                            objThoiGianNgungMayInfo.DEN_NGAY, objThoiGianNgungMayInfo.DEN_GIO, _
                            objThoiGianNgungMayInfo.MS_NGUYEN_NHAN, objThoiGianNgungMayInfo.MS_PHIEU_BAO_TRI, _
                            objThoiGianNgungMayInfo.GHI_CHU, objThoiGianNgungMayInfo.NGUOI_GIAI_QUYET, _
                            objThoiGianNgungMayInfo.DUNG, objThoiGianNgungMayInfo.MS_HE_THONG, objThoiGianNgungMayInfo.THOI_GIAN_SUA_CHUA, objThoiGianNgungMayInfo.MS_N_XUONG)
                        Catch ex As Exception
                        End Try

                    End If
                Next
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return False
            Finally
                objConnection.Close()
            End Try
            Return True
        End Function
        Public Sub DeleteTHOI_GIAN_NGUNG_MAY_ALL(ByVal NGAY As String, ByVal USERNAME As String, ByVal MS_LOAI_MAY As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHOI_GIAN_NGUNG_MAY_ALL", NGAY, USERNAME, MS_LOAI_MAY)
        End Sub

        Public Sub DeleteTHOI_GIAN_NGUNG_MAY(ByVal NGAY As String, ByVal TU_GIO As String, ByVal USERNAME As String, ByVal DEN_NGAY As String, ByVal DEN_GIO As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTHOI_GIAN_NGUNG_MAY", NGAY, TU_GIO, USERNAME, DEN_NGAY, DEN_GIO)
        End Sub
    End Class
End Namespace