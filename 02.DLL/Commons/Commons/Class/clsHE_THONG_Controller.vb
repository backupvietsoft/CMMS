
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class HE_THONGController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetHE_THONGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHE_THONGs"))
            Return objDataTable
        End Function

        Public Function GetHE_THONG(ByVal ID As Integer) As HE_THONGInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHE_THONG", ID)
            Dim objHE_THONGInfo As New HE_THONGInfo
            While objDataReader.Read
                objHE_THONGInfo.MS_HE_THONG = objDataReader.Item("MS_HE_THONG")
                objHE_THONGInfo.MA_HE_THONG = objDataReader.Item("MA_HE_THONG")
                objHE_THONGInfo.TEN_HE_THONG = objDataReader.Item("TEN_HE_THONG")
                objHE_THONGInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
                objHE_THONGInfo.NO_LINE = objDataReader.Item("NO_LINE")

            End While
            objDataReader.Close()
            Return objHE_THONGInfo
        End Function

        Public Function AddHE_THONG(ByVal objHE_THONGInfo As HE_THONGInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddHE_THONG", objHE_THONGInfo.TEN_HE_THONG _
                                                 , objHE_THONGInfo.GHI_CHU, objHE_THONGInfo.NO_LINE, objHE_THONGInfo.MA_HE_THONG), Integer)
        End Function

        Public Sub UpdateHE_THONG(ByVal objHE_THONGInfo As HE_THONGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHE_THONG", objHE_THONGInfo.MS_HE_THONG, _
                                    objHE_THONGInfo.TEN_HE_THONG, objHE_THONGInfo.GHI_CHU, objHE_THONGInfo.NO_LINE, objHE_THONGInfo.MA_HE_THONG)
        End Sub

        Public Sub DeleteHE_THONG(ByVal MS_HT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHE_THONG", MS_HT)
        End Sub
        Public Sub InsertHE_THONG_LOG(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_HE_THONG_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Function CheckTEN_HE_THONG(ByVal TEN_HE_THONG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_HE_THONG", TEN_HE_THONG)
        End Function

        Public Function CheckHE_THONG(ByVal MS_HE_THONG As Integer, ByVal TEN_HE_THONG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckHE_THONG", MS_HE_THONG, TEN_HE_THONG)
        End Function

        Public Function CheckHE_THONG_MA(ByVal MS_HE_THONG As Integer, ByVal MA_HE_THONG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckHE_THONG_MA", MS_HE_THONG, MA_HE_THONG)
        End Function

        Public Function CheckMA_HE_THONG(ByVal MA_HE_THONG As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckMA_HE_THONG", MA_HE_THONG)
        End Function
#End Region
    End Class

End Namespace


