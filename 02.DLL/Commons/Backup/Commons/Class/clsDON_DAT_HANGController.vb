Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsDON_DAT_HANGController

        Public Sub New()
        End Sub
        Public Function GetDON_DAT_HANG(ByVal MS_DDH As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_DAT_HANG", MS_DDH))
            Return objDataTable
        End Function
        Function CheckDonDH(ByVal MS_DDH As String, ByVal MS_DDH_CU As String) As Boolean
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckDonDH", MS_DDH, MS_DDH_CU)
            While objReader.Read
                objReader.Close()
                Return True
            End While
            objReader.Close()
            Return False
        End Function
        Public Function GetDON_DAT_HANG_CHI_TIETs(ByVal MS_DDH As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_DAT_HANG_CHI_TIETs", MS_DDH, commons.Modules.TypeLanguage))
            Return objDataTable
        End Function
        Public Function AddDON_DAT_HANG(ByVal objDonDH As clsDON_DAT_HANGInfo, ByVal tb As DataTable) As String
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                If CheckDonDH(objDonDH.MS_DDH, objDonDH.MS_DDH_CU) Then
                    Return ""
                End If
                If objDonDH.MS_DDH_CU Is Nothing Then
                    SqlHelper.ExecuteNonQuery(objTrans, "AddDON_DAT_HANG", objDonDH.MS_DDH, objDonDH.NGAY_LAP, objDonDH.SO_DE_XUAT, objDonDH.MS_KH, objDonDH.THANH_TIEN, objDonDH.NGUOI_XAC_NHAN, objDonDH.NGUOI_DUYET, objDonDH.NGUOI_DAT_HANG, objDonDH.FAX, objDonDH.DIEN_THOAI, objDonDH.DIA_CHI_GIAO_HANG, objDonDH.THOI_HAN_THANH_TOAN, objDonDH.NGUOI_LIEN_HE, objDonDH.VAT)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        If tb.Rows(i).Item("THANH_TIEN").ToString <> "" And tb.Rows(i).Item("THANH_TIEN").ToString <> "0" Then
                            SqlHelper.ExecuteNonQuery(objTrans, "AddDON_DAT_HANG_CHI_TIET", objDonDH.MS_DDH, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("DON_GIA"), IIf(tb.Rows(i).Item("NGAY_GIAO").ToString = "  /  /", Nothing, tb.Rows(i).Item("NGAY_GIAO")))
                        End If
                    Next
                Else
                    SqlHelper.ExecuteNonQuery(objTrans, "DeleteDON_DAT_HANG_CHI_TIET", objDonDH.MS_DDH_CU)
                    SqlHelper.ExecuteNonQuery(objTrans, "UpdateDON_DAT_HANG", objDonDH.MS_DDH, objDonDH.MS_DDH_CU, objDonDH.NGAY_LAP, objDonDH.SO_DE_XUAT, objDonDH.MS_KH, objDonDH.THANH_TIEN, objDonDH.NGUOI_XAC_NHAN, objDonDH.NGUOI_DUYET, objDonDH.NGUOI_DAT_HANG, objDonDH.FAX, objDonDH.DIEN_THOAI, objDonDH.DIA_CHI_GIAO_HANG, objDonDH.THOI_HAN_THANH_TOAN, objDonDH.NGUOI_LIEN_HE, objDonDH.VAT)
                    For i As Integer = 0 To tb.Rows.Count - 1
                        'If tb.Rows(i).Item("TON_TAI") = 1 Then
                        '    If tb.Rows(i).Item("THANH_TIEN").ToString = "" Or tb.Rows(i).Item("THANH_TIEN").ToString = "0" Then
                        '        SqlHelper.ExecuteNonQuery(objTrans, "DelateDON_DAT_HANG_CHI_TIET", objDonDH.MS_DDH, tb.Rows(i).Item("MS_PT"))
                        '    Else
                        '        SqlHelper.ExecuteNonQuery(objTrans, "UpdateDON_DAT_HANG_CHI_TIET", objDonDH.MS_DDH, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("DON_GIA"), IIf(tb.Rows(i).Item("NGAY_GIAO").ToString = "  /  /", Nothing, tb.Rows(i).Item("NGAY_GIAO")))
                        '    End If
                        'Else
                        If tb.Rows(i).Item("THANH_TIEN").ToString <> "" And tb.Rows(i).Item("THANH_TIEN").ToString <> "0" Then
                            SqlHelper.ExecuteNonQuery(objTrans, "AddDON_DAT_HANG_CHI_TIET", objDonDH.MS_DDH, tb.Rows(i).Item("MS_PT"), tb.Rows(i).Item("SO_LUONG"), tb.Rows(i).Item("DON_GIA"), IIf(tb.Rows(i).Item("NGAY_GIAO").ToString = "  /  /", Nothing, tb.Rows(i).Item("NGAY_GIAO")))
                        End If
                        'End If
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
            Return objDonDH.MS_DDH
        End Function
        Public Sub DelateDON_DAT_HANG_CHI_TIET(ByVal MS_DDH As String, ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DelateDON_DAT_HANG_CHI_TIET", MS_DDH, MS_PT)
        End Sub
        Public Sub DeleteDON_DAT_HANG(ByVal MS_DDH As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteDON_DAT_HANG", MS_DDH)
        End Sub
    End Class

End Namespace
