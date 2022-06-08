
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class clsMAY_THONG_SO_GSTTController

        Public Sub New()
        End Sub
        Public Function get_THONG_SO_GSTTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_THONG_SO_GSTTs"))
            Return objDataTable
        End Function
        Public Function get_THONG_SO_GSTTs_Theo_MS_BP_GSTT(ByVal intMS_BP_GSTT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_THONG_SO_GSTTs_Theo_MS_BP_GSTT", intMS_BP_GSTT))
            Return objDataTable
        End Function

        Public Function GetDON_VI_THOI_GIANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_THOI_GIANs"))
            Return objDataTable
        End Function
        Public Function getMAY_THONG_SO_GSTTs(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getMAY_THONG_SO_GSTTs", MS_MAY))
            'Dim priCol(0) As DataColumn
            'priCol(0) = objDataTable.Columns("MS_TS_GSTT")
            'objDataTable.PrimaryKey = priCol
            Return objDataTable
        End Function

        Public Function GetMAY_TS_GSTT_Theo_MS_BP_GSTTs(ByVal strMS_MAY As String, ByVal intMS_BP_GSTT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_TS_GSTT_Theo_MS_BP_GSTTs", strMS_MAY, intMS_BP_GSTT))
            'Dim priCol(0) As DataColumn
            'priCol(0) = objDataTable.Columns("MS_TS_GSTT")
            'objDataTable.PrimaryKey = priCol
            Return objDataTable
        End Function
        Public Function getGIATRITSGSTT(ByVal MS_TS_GSTT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGTTSGSTT", MS_TS_GSTT))
            Return objDataTable
        End Function
        Public Function AddMAY_THONG_SO_GSTT(ByVal objMAY_THONG_SO_GSTTInfo As MAY_THONG_SO_GSTTInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_THONG_SO_GSTT", _
                objMAY_THONG_SO_GSTTInfo.MS_MAY, objMAY_THONG_SO_GSTTInfo.MS_TS_GSTT, objMAY_THONG_SO_GSTTInfo.GIA_TRI_TREN, objMAY_THONG_SO_GSTTInfo.GIA_TRI_DUOI, objMAY_THONG_SO_GSTTInfo.CHU_KY_DO, objMAY_THONG_SO_GSTTInfo.MS_DV_TG, objMAY_THONG_SO_GSTTInfo.GHI_CHU)
            Return True
        End Function

        Public Sub DeleteMAY_THONG_SO_GSTT(ByVal MS_MAY As String, ByVal MS_TS_GSTT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteMAY_THONG_SO_GSTT", MS_MAY, MS_TS_GSTT)
        End Sub
    End Class
End Namespace



