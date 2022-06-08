Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsHIEU_CHUAN_MAYController

        Public Sub New()
        End Sub
        Public Function GetMS_MAY_HIEU_CHUAN_MAY() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_MAY_HIEU_CHUAN_MAY"))
            Return objDataTable
        End Function
        Public Function GetHIEU_CHUAN_MAY_Theo_NGAY_HC(ByVal strTU_NGAY As Date, ByVal strDEN_NGAY As Date) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEU_CHUAN_MAY_Theo_NGAY_HC", strTU_NGAY, strDEN_NGAY))
            Return objDataTable
        End Function
        Public Function GetHIEU_CHUAN_MAY_Theo_MS_MAY(ByVal strMS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEU_CHUAN_MAY_Theo_MS_MAY", strMS_MAY))
            Return objDataTable
        End Function

        Public Function GetHIEU_CHUAN_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEU_CHUAN_MAYs_Moi"))
            Return objDataTable
        End Function
        Public Sub AddHIEU_CHUAN_MAY(ByVal objHIEU_CHUAN_MAYInfo As HIEU_CHUAN_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddHIEU_CHUAN_MAY", _
            objHIEU_CHUAN_MAYInfo.MS_MAY, objHIEU_CHUAN_MAYInfo.NGAY_HC, objHIEU_CHUAN_MAYInfo.GIAY_CHUNG_NHAN, _
            objHIEU_CHUAN_MAYInfo.CO_QUAN_HIEU_CHUAN, objHIEU_CHUAN_MAYInfo.DANH_GIA, objHIEU_CHUAN_MAYInfo.LOAI_HIEU_CHUAN, objHIEU_CHUAN_MAYInfo.TAI_LIEU, objHIEU_CHUAN_MAYInfo.GHI_CHU, objHIEU_CHUAN_MAYInfo.NGAY_KH)
        End Sub
        Public Sub UpdateHIEU_CHUAN_MAY(ByVal objHIEU_CHUAN_MAYInfo As HIEU_CHUAN_MAYInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHIEU_CHUAN_MAY", _
            objHIEU_CHUAN_MAYInfo.MS_MAY, objHIEU_CHUAN_MAYInfo.MS_MAY_TMP, objHIEU_CHUAN_MAYInfo.NGAY_HC, objHIEU_CHUAN_MAYInfo.NGAY_HC_TMP, _
             objHIEU_CHUAN_MAYInfo.GIAY_CHUNG_NHAN, objHIEU_CHUAN_MAYInfo.CO_QUAN_HIEU_CHUAN, objHIEU_CHUAN_MAYInfo.DANH_GIA, objHIEU_CHUAN_MAYInfo.LOAI_HIEU_CHUAN, objHIEU_CHUAN_MAYInfo.TAI_LIEU, objHIEU_CHUAN_MAYInfo.GHI_CHU, objHIEU_CHUAN_MAYInfo.NGAY_KH)
        End Sub
        Public Sub DeleteHIEU_CHUAN_MAY(ByVal strMS_MAY As String, ByVal strNGAY_HC As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHIEU_CHUAN_MAY", strMS_MAY, strNGAY_HC)
        End Sub
        Public Function CheckNgayHC_MAY(ByVal strMS_MAY As String, ByVal intNAM As String) As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckNgayHC_MAY", strMS_MAY, intNAM)
            Dim tmp As Integer = 0
            While objDataReader.Read
                tmp = tmp + 1
            End While
            objDataReader.Close()
            Return tmp
        End Function
    End Class
End Namespace

