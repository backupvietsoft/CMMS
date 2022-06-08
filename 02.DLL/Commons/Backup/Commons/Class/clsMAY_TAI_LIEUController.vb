Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class MAY_TAI_LIEUController
        Public Sub New()

        End Sub

#Region "public method "
        Public Function GetMAY_TAI_LIEUs(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_TAI_LIEUs", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddMAY_TAI_LIEU(ByVal objMAY_TAI_LIEUInfo As MAY_TAI_LIEUInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddMAY_TAI_LIEU", _
                objMAY_TAI_LIEUInfo.MS_MAY, objMAY_TAI_LIEUInfo.TEN_TAI_LIEU, objMAY_TAI_LIEUInfo.NOI_LUU_TRU, _
                    objMAY_TAI_LIEUInfo.SO_TAI_LIEU, objMAY_TAI_LIEUInfo.GHI_CHU)
            Return True
        End Function
        Public Function AddMAY_TAI_LIEUSC(ByVal Sqltran As SqlTransaction, ByVal objMAY_TAI_LIEUInfo As MAY_TAI_LIEUInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddMAY_TAI_LIEU", _
                objMAY_TAI_LIEUInfo.MS_MAY, objMAY_TAI_LIEUInfo.TEN_TAI_LIEU, objMAY_TAI_LIEUInfo.NOI_LUU_TRU, objMAY_TAI_LIEUInfo.SO_TAI_LIEU, objMAY_TAI_LIEUInfo.GHI_CHU)
            Return True
        End Function
        Public Function UpdateMAY_TAI_LIEU(ByVal objMAY_TAI_LIEUInfo As MAY_TAI_LIEUInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_TAI_LIEU", _
                objMAY_TAI_LIEUInfo.MS_MAY, objMAY_TAI_LIEUInfo.MA_TAI_LIEU, objMAY_TAI_LIEUInfo.TEN_TAI_LIEU, objMAY_TAI_LIEUInfo.NOI_LUU_TRU, objMAY_TAI_LIEUInfo.SO_TAI_LIEU, objMAY_TAI_LIEUInfo.GHI_CHU)
            Return True
        End Function
#End Region
    End Class
End Namespace

