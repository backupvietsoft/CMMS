Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsTRINH_DO_VAN_HOAController
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetTRINH_DO_VAN_HOAs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTRINH_DO_VAN_HOAs"))
            Return objDataTable
        End Function

        Public Function GetTRINH_DO_VAN_HOA(ByVal ID As Integer) As TRINH_DO_VAN_HOAInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTRINH_DO_VAN_HOA", ID)
            Dim objTRINH_DO_VAN_HOAInfo As New TRINH_DO_VAN_HOAInfo
            While objDataReader.Read
                objTRINH_DO_VAN_HOAInfo.MS_TRINH_DO = objDataReader.Item("MS_TRINH_DO")
                objTRINH_DO_VAN_HOAInfo.TEN_GOI = objDataReader.Item("TEN_GOI")
            End While
            objDataReader.Close()
            Return objTRINH_DO_VAN_HOAInfo
        End Function

        Public Function AddTRINH_DO_VAN_HOA(ByVal objTRINH_DO_VAN_HOAInfo As TRINH_DO_VAN_HOAInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTRINH_DO_VAN_HOA", objTRINH_DO_VAN_HOAInfo.TEN_GOI), Integer)
        End Function

        Public Sub UpdateTRINH_DO_VAN_HOA(ByVal objTRINH_DO_VAN_HOAInfo As TRINH_DO_VAN_HOAInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTRINH_DO_VAN_HOA", objTRINH_DO_VAN_HOAInfo.MS_TRINH_DO, objTRINH_DO_VAN_HOAInfo.TEN_GOI)
        End Sub

        Public Sub DeleteTRINH_DO_VAN_HOA(ByVal MS_TRINH_DO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTRINH_DO_VAN_HOA", MS_TRINH_DO)
        End Sub
#End Region

    End Class

End Namespace

