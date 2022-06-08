Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class GIA_TRI_TS_GSTTController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetGIA_TRI_TS_GSTTs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIA_TRI_TS_GSTTs"))
            Return objDataTable
        End Function
        Public Function GetGIA_TRI_TS_GSTT1(ByVal MS_TS_GSTT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIA_TRI_TS_GSTT1", MS_TS_GSTT))
            Return objDataTable
        End Function

        Public Function GetGIA_TRI_TS_GSTT(ByVal ID As Integer) As GIA_TRI_TS_GSTTInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIA_TRI_TS_GSTT", ID)
            Dim objGIA_TRI_TS_GSTTInfo As New GIA_TRI_TS_GSTTInfo
            While objDataReader.Read
                objGIA_TRI_TS_GSTTInfo.MS_TS_GSTT = objDataReader.Item("MS_TS_GSTT")
                objGIA_TRI_TS_GSTTInfo.STT = objDataReader.Item("STT")
                objGIA_TRI_TS_GSTTInfo.TEN_GIA_TRI = objDataReader.Item("TEN_GIA_TRI")
                objGIA_TRI_TS_GSTTInfo.DAT = objDataReader.Item("DAT")
                objGIA_TRI_TS_GSTTInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
            End While
            objDataReader.Close()
            Return objGIA_TRI_TS_GSTTInfo
        End Function

        Public Function AddGIA_TRI_TS_GSTT(ByVal objGIA_TRI_TS_GSTTInfo As GIA_TRI_TS_GSTTInfo)
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddGIA_TRI_TS_GSTT", _
           objGIA_TRI_TS_GSTTInfo.MS_TS_GSTT, objGIA_TRI_TS_GSTTInfo.TEN_GIA_TRI, _
           objGIA_TRI_TS_GSTTInfo.DAT, objGIA_TRI_TS_GSTTInfo.GHI_CHU), Integer)
            'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO GIA_TRI_TS_GSTT (MS_TS_GSTT,TEN_GIA_TRI,DAT,GHI_CHU) VALUES ('" & objGIA_TRI_TS_GSTTInfo.MS_TS_GSTT & "','" & objGIA_TRI_TS_GSTTInfo.TEN_GIA_TRI & "'," & CInt(objGIA_TRI_TS_GSTTInfo.DAT) & ",'" & objGIA_TRI_TS_GSTTInfo.GHI_CHU & "')")
        End Function

        Public Sub UpdateGIA_TRI_TS_GSTT(ByVal objGIA_TRI_TS_GSTTInfo As GIA_TRI_TS_GSTTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateGIA_TRI_TS_GSTT", _
            objGIA_TRI_TS_GSTTInfo.MS_TS_GSTT, objGIA_TRI_TS_GSTTInfo.STT, objGIA_TRI_TS_GSTTInfo.TEN_GIA_TRI, _
            objGIA_TRI_TS_GSTTInfo.DAT, objGIA_TRI_TS_GSTTInfo.GHI_CHU)
        End Sub
        Public Sub InsertGIA_TRI_TS_GSTT_LOG(ByVal ID As Integer, ByVal ID1 As String, ByVal FORM_NAME As String, ByVal USER_SIGN As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateGIA_TRI_TS_GSTT_LOG", ID, ID1, FORM_NAME, USER_SIGN, THAO_TAC)

        End Sub
        Public Sub DeleteGIA_TRI_TS_GSTT(ByVal MS_TS_GSTT As String, ByVal STT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIA_TRI_TS_GSTT", MS_TS_GSTT, STT)
        End Sub
        Public Sub DeleteGIA_TRI_TS_GSTT1(ByVal MS_TS_GSTT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteGIA_TRI_TS_GSTT1", MS_TS_GSTT)
        End Sub
        
#End Region

    End Class
End Namespace
