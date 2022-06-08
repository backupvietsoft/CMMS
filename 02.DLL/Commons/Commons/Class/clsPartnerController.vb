Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Partner
    Public Class PartnerController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetPartners() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPartners"))
            Return objDataTable
        End Function

        Public Function GetPartner(ByVal ID As Integer) As PartnerInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPartner", ID)
            Dim objPartnerInfo As New PartnerInfo
            While objDataReader.Read
                objPartnerInfo.ID = objDataReader.Item("ID")
                objPartnerInfo.PartnerName = objDataReader.Item("PartnerName")
                objPartnerInfo.Address = objDataReader.Item("Address")
                objPartnerInfo.Phone = objDataReader.Item("Phone")
                objPartnerInfo.Fax = objDataReader.Item("Fax")
                objPartnerInfo.Email = objDataReader.Item("Email")
            End While
            Return objPartnerInfo
        End Function

        Public Function AddPartner(ByVal objPartnerInfo As PartnerInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPartner", objPartnerInfo.PartnerName, objPartnerInfo.Address, objPartnerInfo.Phone, objPartnerInfo.Fax, objPartnerInfo.Email), Integer)
        End Function

        Public Sub UpdatePartner(ByVal objPartnerInfo As PartnerInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePartner", objPartnerInfo.ID, objPartnerInfo.PartnerName, objPartnerInfo.Address, objPartnerInfo.Phone, objPartnerInfo.Fax, objPartnerInfo.Email)
        End Sub

        Public Sub DeletePartner(ByVal ID As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePartner", ID)
        End Sub
#End Region
    End Class
End Namespace
