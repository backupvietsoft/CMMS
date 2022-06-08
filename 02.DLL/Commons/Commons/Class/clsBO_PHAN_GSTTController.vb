Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class BO_PHAN_GSTTController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetBO_PHAN_GSTTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_GSTTs"))
            Return objDataTable
        End Function

        Public Function GetBO_PHAN_GSTT(ByVal ID As Integer) As BO_PHAN_GSTTInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_GSTT", ID)
            Dim objBO_PHAN_GSTTInfo As New BO_PHAN_GSTTInfo
            While objDataReader.Read
                objBO_PHAN_GSTTInfo.MS_BP_GSTT = objDataReader.Item("MS_BP_GSTT")
                objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TV = objDataReader.Item("TEN_BP_GSTT_TV")
                objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TA = objDataReader.Item("TEN_BP_GSTT_TA")
                objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TH = objDataReader.Item("TEN_BP_GSTT_TH")
            End While
            objDataReader.Close()
            Return objBO_PHAN_GSTTInfo
        End Function

        Public Function AddBO_PHAN_GSTT(ByVal objBO_PHAN_GSTTInfo As BO_PHAN_GSTTInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddBO_PHAN_GSTT", objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TV, objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TA, objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TH), Integer)
        End Function
        Public Sub UpdateBO_PHAN_GSTT(ByVal objBO_PHAN_GSTTInfo As BO_PHAN_GSTTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateBO_PHAN_GSTT", objBO_PHAN_GSTTInfo.MS_BP_GSTT, objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TV, objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TA, objBO_PHAN_GSTTInfo.TEN_BP_GSTT_TH)
        End Sub
        Public Sub DeleteBO_PHAN_GSTT(ByVal ID As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteBO_PHAN_GSTT", ID)
        End Sub
        
#End Region
    End Class
End Namespace


