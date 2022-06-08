
Imports System.Data
Imports System.Data.SqlClient
Imports Commons.QL.Common.Data
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsLOAI_VAT_TUController

        Public Sub New()

        End Sub
        Public Function GetLOAI_VTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_VTs"))
            Return objDataTable
        End Function
        Public Function AddLoaiVT(ByVal objLoaiVTInfo As clsLOAI_VAT_TUInfo) As String
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Dim ms_loai_vt_tmp As String = ""
            Try
                Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_LOAI_VT_MAX")

                While objReader.Read
                    ms_loai_vt_tmp = (Integer.Parse(objReader.Item("MS_LOAI_VT")) + 1).ToString
                End While
                objReader.Close()
                If ms_loai_vt_tmp = "" Then
                    ms_loai_vt_tmp = "1"
                End If
                SqlHelper.ExecuteNonQuery(objTrans, "AddLOAI_VT", ms_loai_vt_tmp, objLoaiVTInfo.TEN_LOAI_VT_TV, objLoaiVTInfo.TEN_LOAI_VT_TA, objLoaiVTInfo.TEN_LOAI_VT_TH)
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                ms_loai_vt_tmp = ""
            Finally
                objConnection.Close()
            End Try

            Return ms_loai_vt_tmp
        End Function
        Public Sub UpdateLoaiVT(ByVal objLoaiVTInfo As clsLOAI_VAT_TUInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_VT", objLoaiVTInfo.MS_LOAI_VT, objLoaiVTInfo.TEN_LOAI_VT_TV, objLoaiVTInfo.TEN_LOAI_VT_TA, objLoaiVTInfo.TEN_LOAI_VT_TH, objLoaiVTInfo.VAT_TU)
        End Sub
        Public Sub DeleteLoaiVT(ByVal MS_LOAI_VT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLOAI_VT", MS_LOAI_VT)
        End Sub
        Public Function CheckTenLoaiVT_TV(ByVal MS_LOAI_VT As String, ByVal TEN_LOAI_VT_TV As String) As Boolean
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTenLoaiVTTV", MS_LOAI_VT, TEN_LOAI_VT_TV)
            While objReader.Read
                objReader.Close()
                Return True
            End While
            objReader.Close()
            Return False
        End Function
    End Class
End Namespace
