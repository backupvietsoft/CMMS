Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class LOAI_CONG_VIECController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetLOAI_CONG_VIECs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIECs"))
            Return objDataTable
        End Function

        Public Function GetLOAI_CONG_VIEC(ByVal ID As Integer) As LOAI_CONG_VIECInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC", ID)
            Dim objLOAI_CONG_VIECInfo As New LOAI_CONG_VIECInfo
            While objDataReader.Read
                objLOAI_CONG_VIECInfo.MS_LOAI_CV = objDataReader.Item("MS_LOAI_CV")
                objLOAI_CONG_VIECInfo.TEN_LOAI_CV = objDataReader.Item("TEN_LOAI_CV")
            End While
            objDataReader.Close()
            Return objLOAI_CONG_VIECInfo
        End Function

        Public Function AddLOAI_CONG_VIEC(ByVal objLOAI_CONG_VIECInfo As LOAI_CONG_VIECInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLOAI_CONG_VIEC", objLOAI_CONG_VIECInfo.TEN_LOAI_CV), Integer)
        End Function

        Public Sub UpdateLOAI_CONG_VIEC(ByVal objLOAI_CONG_VIECInfo As LOAI_CONG_VIECInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_CONG_VIEC", objLOAI_CONG_VIECInfo.MS_LOAI_CV, objLOAI_CONG_VIECInfo.TEN_LOAI_CV)
        End Sub
        Public Sub InsertLOAI_CONG_VIEC_LOG(ByVal ID As Integer, ByVal FORMNAME As String, ByVal USERSIGN As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_CONG_VIEC_LOG", ID, FORMNAME, USERSIGN, THAO_TAC)
        End Sub
        Public Sub DeleteLOAI_CONG_VIEC(ByVal MS_LOAI_CV As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLOAI_CONG_VIEC", MS_LOAI_CV)
        End Sub
        Public Function CheckTEN_LOAI_CV(ByVal TEN_LOAI_CV As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_LOAI_CV", TEN_LOAI_CV)
        End Function
        Public Function CheckLOAI_CONG_VIEC(ByVal MS_LOAI_CV As Integer, ByVal TEN_LOAI_CV As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckLOAI_CONG_VIEC", MS_LOAI_CV, TEN_LOAI_CV)
        End Function

        Public Sub DeleteNHOM_LOAI_CONG_VIEC_1(ByVal MS_LOAI_CV As String, ByVal USERNAME As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteNHOM_LOAI_CONG_VIEC_1", MS_LOAI_CV, USERNAME)
        End Sub

#End Region
    End Class

End Namespace
