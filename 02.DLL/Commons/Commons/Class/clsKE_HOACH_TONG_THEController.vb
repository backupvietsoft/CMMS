Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class KE_HOACH_TONG_THEController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetKE_HOACH_TONG_THE() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKE_HOACH_TONG_THE"))
            Return objDataTable
        End Function

        'Public Function GetBO_PHAN_CHIU_PHI(ByVal ID As Integer) As BO_PHAN_CHIU_PHIInfo
        '    Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBO_PHAN_CHIU_PHI", ID)
        '    Dim objBO_PHAN_CHIU_PHIInfo As New BO_PHAN_CHIU_PHIInfo
        '    While objDataReader.Read
        '        objBO_PHAN_CHIU_PHIInfo.MS_BP_CHIU_PHI = objDataReader.Item("MS_BP_CHIU_PHI")
        '        objBO_PHAN_CHIU_PHIInfo.TEN_BP_CHIU_PHI = objDataReader.Item("TEN_BP_CHIU_PHI")
        '        objBO_PHAN_CHIU_PHIInfo.LOAI_CHI_PHI = objDataReader.Item("LOAI_CHI_PHI")
        '        objBO_PHAN_CHIU_PHIInfo.MSDV = objDataReader.Item("MSDV")
        '        objBO_PHAN_CHIU_PHIInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
        '    End While
        '    objDataReader.Close()
        '    Return objBO_PHAN_CHIU_PHIInfo
        'End Function

        Public Function AddKE_HOACH_TONG_THE(ByVal objKE_HOACH_TONG_THEInfo As KE_HOACH_TONG_THEInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKE_HOACH_TONG_THE", _
             objKE_HOACH_TONG_THEInfo.MS_MAY, objKE_HOACH_TONG_THEInfo.NGAY, _
             objKE_HOACH_TONG_THEInfo.MS_LOAI_BT, objKE_HOACH_TONG_THEInfo.NGAY_BTPN)
            Return True
        End Function

        'Public Sub UpdateBO_PHAN_CHIU_PHI(ByVal objBO_PHAN_CHIU_PHIInfo As BO_PHAN_CHIU_PHIInfo, ByVal OLD_TEN_BP_CHIU_PHI As String)
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateBO_PHAN_CHIU_PHI", _
        '    objBO_PHAN_CHIU_PHIInfo.MS_BP_CHIU_PHI, objBO_PHAN_CHIU_PHIInfo.TEN_BP_CHIU_PHI, _
        '    objBO_PHAN_CHIU_PHIInfo.LOAI_CHI_PHI, objBO_PHAN_CHIU_PHIInfo.MSDV, objBO_PHAN_CHIU_PHIInfo.GHI_CHU, OLD_TEN_BP_CHIU_PHI)
        'End Sub

        'Public Sub DeleteBO_PHAN_CHIU_PHI(ByVal MS_BP_CHIU_PHI As Integer)
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteBO_PHAN_CHIU_PHI", MS_BP_CHIU_PHI)
        'End Sub

        'Public Function CheckTEN_BP_CHIU_PHI(ByVal TEN_BP_CHIU_PHI As String) As SqlDataReader
        '    Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckTEN_BP_CHIU_PHI", TEN_BP_CHIU_PHI)
        'End Function
        'Public Function GetTI_GIA(ByVal NGOAI_TE As String) As Double
        '    Dim TY_GIA As Double
        '    Dim reader As SqlDataReader
        '    reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA", NGOAI_TE)
        '    If reader.Read Then
        '        TY_GIA = reader.Item("TI_GIA")
        '    End If
        '    reader.Close()
        '    Return TY_GIA
        'End Function
        'Public Function CheckBO_PHAN_CHIU_PHI(ByVal MS_BP_CHIU_PHI As Integer, ByVal TEN_BP_CHIU_PHI As String) As SqlDataReader
        '    Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckBO_PHAN_CHIU_PHI", MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI)
        'End Function
        'Public Function GetGIA_TRI_NGOAI_TE() As String
        '    Dim QUERY As String = "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1"
        '    Dim GIA_TRI_NGOAI_TE As String
        '    Dim VALUE_READER As SqlDataReader
        '    GIA_TRI_NGOAI_TE = ""
        '    VALUE_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
        '    If VALUE_READER.Read Then
        '        GIA_TRI_NGOAI_TE = VALUE_READER.Item(0)
        '    End If
        '    VALUE_READER.Close()
        '    Return GIA_TRI_NGOAI_TE
        'End Function
#End Region
    End Class

End Namespace
