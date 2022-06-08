Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class LOAI_CHI_PHIController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetLOAI_CHI_PHIs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CHI_PHIs"))
            Return objDataTable
        End Function

        Public Function GetLOAI_CHI_PHI(ByVal ID As Integer) As LOAI_CHI_PHIInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CHI_PHI", ID)
            Dim objLOAI_CHI_PHIInfo As New LOAI_CHI_PHIInfo
            While objDataReader.Read
                objLOAI_CHI_PHIInfo.LOAI_CHI_PHI = objDataReader.Item("LOAI_CHI_PHI")
                objLOAI_CHI_PHIInfo.TEN_LOAI_CHI_PHI = objDataReader.Item("TEN_LOAI_CHI_PHI")
                objLOAI_CHI_PHIInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
            End While
            objDataReader.Close()
            Return objLOAI_CHI_PHIInfo
        End Function

        Public Function AddLOAI_CHI_PHI(ByVal objLOAI_CHI_PHIInfo As LOAI_CHI_PHIInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLOAI_CHI_PHI", objLOAI_CHI_PHIInfo.TEN_LOAI_CHI_PHI, objLOAI_CHI_PHIInfo.GHI_CHU), Integer)
        End Function

        Public Sub UpdateLOAI_CHI_PHI(ByVal objLOAI_CHI_PHIInfo As LOAI_CHI_PHIInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_CHI_PHI", objLOAI_CHI_PHIInfo.LOAI_CHI_PHI, objLOAI_CHI_PHIInfo.TEN_LOAI_CHI_PHI, objLOAI_CHI_PHIInfo.GHI_CHU)
        End Sub

        Public Sub DeleteLOAI_CHI_PHI(ByVal LOAI_CHI_PHI As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLOAI_CHI_PHI", LOAI_CHI_PHI)
        End Sub
        Public Function CheckTEN_LOAI_CHI_PHI(ByVal TEN_LOAI_CHI_PHI As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_LOAI_CHI_PHI", TEN_LOAI_CHI_PHI)
        End Function

        Public Function CheckExistLOAI_CHI_PHI(ByVal LOAI_CHI_PHI As Integer, ByVal TEN_LOAI_CHI_PHI As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistLOAI_CHI_PHI", LOAI_CHI_PHI, TEN_LOAI_CHI_PHI)
        End Function
#End Region


    End Class

End Namespace

