Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class BO_PHAN_CHIU_PHIController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetBO_PHAN_CHIU_PHIs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_CHIU_PHIs"))

            Return objDataTable
        End Function

        Public Function GetBO_PHAN_CHIU_PHI(ByVal ID As Integer) As BO_PHAN_CHIU_PHIInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_CHIU_PHI", ID)
            Dim objBO_PHAN_CHIU_PHIInfo As New BO_PHAN_CHIU_PHIInfo
            While objDataReader.Read
                objBO_PHAN_CHIU_PHIInfo.MA_BP_CHIU_PHI = objDataReader.Item("MA_BP_CHIU_PHI")
                objBO_PHAN_CHIU_PHIInfo.MS_BP_CHIU_PHI = objDataReader.Item("MS_BP_CHIU_PHI")
                objBO_PHAN_CHIU_PHIInfo.TEN_BP_CHIU_PHI = objDataReader.Item("TEN_BP_CHIU_PHI")
                objBO_PHAN_CHIU_PHIInfo.LOAI_CHI_PHI = objDataReader.Item("LOAI_CHI_PHI")
                objBO_PHAN_CHIU_PHIInfo.MSDV = objDataReader.Item("MSDV")
                objBO_PHAN_CHIU_PHIInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
            End While
            objDataReader.Close()
            Return objBO_PHAN_CHIU_PHIInfo
        End Function

        Public Function AddBO_PHAN_CHIU_PHI(ByVal objBO_PHAN_CHIU_PHIInfo As BO_PHAN_CHIU_PHIInfo) As Integer
            Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddBO_PHAN_CHIU_PHI", _
            objBO_PHAN_CHIU_PHIInfo.TEN_BP_CHIU_PHI, objBO_PHAN_CHIU_PHIInfo.LOAI_CHI_PHI, _
            objBO_PHAN_CHIU_PHIInfo.MSDV, objBO_PHAN_CHIU_PHIInfo.GHI_CHU, objBO_PHAN_CHIU_PHIInfo.ACCOUNT, _
            objBO_PHAN_CHIU_PHIInfo.SUBS, objBO_PHAN_CHIU_PHIInfo.MA_BP_CHIU_PHI), Integer)
        End Function

        Public Sub UpdateBO_PHAN_CHIU_PHI(ByVal objBO_PHAN_CHIU_PHIInfo As BO_PHAN_CHIU_PHIInfo, ByVal OLD_TEN_BP_CHIU_PHI As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateBO_PHAN_CHIU_PHI",
            objBO_PHAN_CHIU_PHIInfo.MS_BP_CHIU_PHI, objBO_PHAN_CHIU_PHIInfo.TEN_BP_CHIU_PHI,
            objBO_PHAN_CHIU_PHIInfo.LOAI_CHI_PHI, objBO_PHAN_CHIU_PHIInfo.MSDV, objBO_PHAN_CHIU_PHIInfo.GHI_CHU, OLD_TEN_BP_CHIU_PHI,
            objBO_PHAN_CHIU_PHIInfo.ACCOUNT, objBO_PHAN_CHIU_PHIInfo.SUBS, objBO_PHAN_CHIU_PHIInfo.MA_BP_CHIU_PHI)
        End Sub
       
        Public Sub InsertBO_PHAN_CHIU_PHI_LOG(ByVal ID As Integer, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_BO_PHAN_CHIU_PHI_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub
        Public Sub DeleteBO_PHAN_CHIU_PHI(ByVal MS_BP_CHIU_PHI As Integer, ByVal FORMNAME As String)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_BO_PHAN_CHIU_PHI_LOG", MS_BP_CHIU_PHI, FORMNAME, Commons.Modules.UserName, 3)
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteBO_PHAN_CHIU_PHI", MS_BP_CHIU_PHI)
        End Sub

        Public Function CheckTEN_BP_CHIU_PHI(ByVal TEN_BP_CHIU_PHI As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_BP_CHIU_PHI", TEN_BP_CHIU_PHI)
        End Function

        Public Function CheckMA_BP_CHIU_PHI(ByVal MA_BP_CHIU_PHI As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckMA_BP_CHIU_PHI", MA_BP_CHIU_PHI)
        End Function

        Public Function GetTI_GIA(ByVal NGOAI_TE As String) As Double
            Dim TY_GIA As Double
            Dim reader As SqlDataReader
            reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA", NGOAI_TE)
            If reader.Read Then
                TY_GIA = reader.Item("TI_GIA")
            End If

            reader.Close()
            Return TY_GIA
        End Function
        Public Function GetTI_GIA_USD(ByVal NGOAI_TE As String) As Double
            Dim TY_GIA_USD As Double
            Dim reader As SqlDataReader
            reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA_USD", NGOAI_TE)
            If reader.Read Then
                TY_GIA_USD = reader.Item("TI_GIA_USD")
            End If

            reader.Close()
            Return TY_GIA_USD
        End Function
        Public Function CheckBO_PHAN_CHIU_PHI(ByVal MS_BP_CHIU_PHI As Integer, ByVal TEN_BP_CHIU_PHI As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckBO_PHAN_CHIU_PHI", MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI)
        End Function

        Public Function CheckBO_PHAN_CHIU_PHI_MA(ByVal MS_BP_CHIU_PHI As Integer, ByVal MA_BP_CHIU_PHI As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckBO_PHAN_CHIU_PHI_MA", MS_BP_CHIU_PHI, MA_BP_CHIU_PHI)
        End Function

        Public Function GetGIA_TRI_NGOAI_TE() As String
            Dim QUERY As String = "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1"
            Dim GIA_TRI_NGOAI_TE As String
            Dim VALUE_READER As SqlDataReader
            GIA_TRI_NGOAI_TE = ""
            VALUE_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            If VALUE_READER.Read Then
                GIA_TRI_NGOAI_TE = VALUE_READER.Item(0)
            End If
            VALUE_READER.Close()
            Return GIA_TRI_NGOAI_TE
        End Function
#End Region

#Region "Relatives"
        Public Function CheckUsedBPCP_KINH_PHI_NAM(ByVal MS_BPCP As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedBPCP_KINH_PHI_NAM", MS_BPCP))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedBPCP_MAY(ByVal MS_BPCP As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedBPCP_MAY", MS_BPCP))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region
    End Class

End Namespace
