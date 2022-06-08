Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class CAU_TRUC_THIET_BIController
        Public Sub New()

        End Sub

#Region "public method BTPN"
        Public Function GetCAU_TRUC_THIET_BI(ByVal MS_MAY As String, Optional ByVal MsBp As String = "") As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCAU_TRUC_THIET_BI", MS_MAY, MsBp))
            Return objDataTable
        End Function
        Public Function GetCAU_TRUC_THIET_BIs(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetCAU_TRUC_THIET_BIs", MS_MAY))
            Return objDataTable
        End Function
        Public Function AddCAU_TRUC_THIET_BI(ByVal Sqltran As SqlTransaction, ByVal objCAU_TRUC_THIET_BIInfo As CAU_TRUC_THIET_BIInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddCAU_TRUC_THIET_BI", _
                objCAU_TRUC_THIET_BIInfo.MS_MAY, objCAU_TRUC_THIET_BIInfo.MS_BO_PHAN, objCAU_TRUC_THIET_BIInfo.TEN_BO_PHAN, objCAU_TRUC_THIET_BIInfo.SO_LUONG, objCAU_TRUC_THIET_BIInfo.MS_BO_PHAN_CHA, objCAU_TRUC_THIET_BIInfo.GHI_CHU, objCAU_TRUC_THIET_BIInfo.RUN_TIME, objCAU_TRUC_THIET_BIInfo.MS_DVT_RT, objCAU_TRUC_THIET_BIInfo.CLASS_ID)
            Return True
        End Function

#End Region
    End Class
End Namespace

