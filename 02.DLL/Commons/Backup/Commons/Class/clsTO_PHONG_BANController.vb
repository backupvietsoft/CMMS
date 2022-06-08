Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsTO_PHONG_BANController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetTO_PHONG_BANs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTO_PHONG_BANs"))
            Return objDataTable
        End Function
        ' Lọc theo đơn vị, chưa hoạt động.
        Public Function GetTO_PHONG_BANs(ByVal MS_DON_VI As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTO_PHONG_BANs", MS_DON_VI))
            Return objDataTable
        End Function

        Public Function Get_To(ByVal MS_PHONG_BAN As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_TO", MS_PHONG_BAN))
            Return objDataTable
        End Function

        Public Function GetTO_PHONG_BAN(ByVal ID As Integer) As TO_PHONG_BANInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTO_PHONG_BAN", ID)
            Dim objTO_PHONG_BANInfo As New TO_PHONG_BANInfo
            While objDataReader.Read
                objTO_PHONG_BANInfo.MS_TO = objDataReader.Item("MS_TO")
                objTO_PHONG_BANInfo.MS_DON_VI = objDataReader.Item("MS_DON_VI")
                objTO_PHONG_BANInfo.TEN_TO = objDataReader.Item("TEN_TO")
                objTO_PHONG_BANInfo.STT_TO = objDataReader.Item("STT_TO")
                objTO_PHONG_BANInfo.TO_TRUONG = objDataReader.Item("TO_TRUONG")
            End While
            objDataReader.Close()
            Return objTO_PHONG_BANInfo
        End Function

        Public Function AddTO_PHONG_BAN(ByVal objTO_PHONG_BANInfo As TO_PHONG_BANInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddTO_PHONG_BAN", _
            objTO_PHONG_BANInfo.MS_DON_VI, objTO_PHONG_BANInfo.TEN_TO, objTO_PHONG_BANInfo.STT_TO, _
            objTO_PHONG_BANInfo.TO_TRUONG), Integer)
        End Function

        Public Sub UpdateTO_PHONG_BAN(ByVal objTO_PHONG_BANInfo As TO_PHONG_BANInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTO_PHONG_BAN", _
            objTO_PHONG_BANInfo.MS_TO, objTO_PHONG_BANInfo.MS_DON_VI, objTO_PHONG_BANInfo.TEN_TO, _
            objTO_PHONG_BANInfo.STT_TO, objTO_PHONG_BANInfo.TO_TRUONG)
        End Sub

        Public Sub Add_TO(ByVal MS_PHONG_BAN As Integer, ByVal TEN_TO As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Add_TO", MS_PHONG_BAN, TEN_TO)
        End Sub

        Public Sub Update_TO(ByVal MS_TO As Integer, ByVal MS_PHONG_BAN As Integer, ByVal TEN_TO As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTO", MS_TO, MS_PHONG_BAN, TEN_TO)
        End Sub

        Public Sub DeleteTO_PHONG_BAN(ByVal MS_TO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTO_PHONG_BAN", MS_TO)
        End Sub

        Public Sub Delete_TO(ByVal MS_TO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_TO", MS_TO)
        End Sub

        Public Sub Delete_All_TO(ByVal MS_PHONG_BAN As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_All_TO", MS_PHONG_BAN)
        End Sub

        Public Function Get_MS_PHONG_BAN(ByVal TEN_PHONG_BAN As String) As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_MS_PHONG_BAN", TEN_PHONG_BAN)
            Dim objTO_PHONG_BANInfo As New TO_PHONG_BANInfo
            objTO_PHONG_BANInfo.MS_TO = 0
            While objDataReader.Read
                objTO_PHONG_BANInfo.MS_TO = objDataReader.Item("MS_TO")
                Exit While
            End While
            objDataReader.Close()
            Return objTO_PHONG_BANInfo.MS_TO
        End Function
#End Region

    End Class
End Namespace