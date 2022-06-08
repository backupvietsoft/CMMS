Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class clsHIEU_CHUAN_DHDController
        Public Sub New()

        End Sub
        Public Function GetHIEU_CHUAN_DHDs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEU_CHUAN_DHDs"))
            Return objDataTable
        End Function
        Public Function GetCHU_KY_HIEU_CHUAN_MS_VI_TRIs(ByVal strMS_MAY As String, ByVal strMS_PT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHU_KY_HIEU_CHUAN_MS_VI_TRIs", strMS_MAY, strMS_PT))
            Return objDataTable
        End Function
        Public Function GetHIEU_CHUAN_DHD_LOC(ByVal intNam As Integer, ByVal strMS_MAY As String, ByVal dongho As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHIEU_CHUAN_DHD_LOC", intNam, strMS_MAY, dongho))
            Return objDataTable
        End Function
        Public Sub AddHIEU_CHUAN_DHD(ByVal objHIEU_CHUAN_DHDInfo As HIEU_CHUAN_DHDInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddHIEU_CHUAN_DHD", _
            objHIEU_CHUAN_DHDInfo.MS_MAY, objHIEU_CHUAN_DHDInfo.MS_PT, objHIEU_CHUAN_DHDInfo.MS_VI_TRI, _
            objHIEU_CHUAN_DHDInfo.NGAY, objHIEU_CHUAN_DHDInfo.GIAY_CHUNG_NHAN, _
            objHIEU_CHUAN_DHDInfo.CO_QUAN_HIEU_CHUAN, objHIEU_CHUAN_DHDInfo.DANH_GIA, objHIEU_CHUAN_DHDInfo.NOI, _
            objHIEU_CHUAN_DHDInfo.MS_LOAI_HIEU_CHUAN, objHIEU_CHUAN_DHDInfo.NGAY_KH, _
            objHIEU_CHUAN_DHDInfo.DUONG_DAN, objHIEU_CHUAN_DHDInfo.GHI_CHU, objHIEU_CHUAN_DHDInfo.DD_GOC)
        End Sub
        Public Sub UpdateHIEU_CHUAN_DHD(ByVal objHIEU_CHUAN_DHDInfo As HIEU_CHUAN_DHDInfo)


            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHIEU_CHUAN_DHD", _
            objHIEU_CHUAN_DHDInfo.MS_MAY, objHIEU_CHUAN_DHDInfo.MS_MAY_TMP, objHIEU_CHUAN_DHDInfo.MS_PT, objHIEU_CHUAN_DHDInfo.MS_PT_TMP, _
            objHIEU_CHUAN_DHDInfo.MS_VI_TRI, objHIEU_CHUAN_DHDInfo.MS_VI_TRI_TMP, _
            objHIEU_CHUAN_DHDInfo.NGAY, objHIEU_CHUAN_DHDInfo.NGAY_TMP, objHIEU_CHUAN_DHDInfo.GIAY_CHUNG_NHAN, _
            objHIEU_CHUAN_DHDInfo.CO_QUAN_HIEU_CHUAN, objHIEU_CHUAN_DHDInfo.DANH_GIA, objHIEU_CHUAN_DHDInfo.NOI, _
            objHIEU_CHUAN_DHDInfo.MS_LOAI_HIEU_CHUAN, objHIEU_CHUAN_DHDInfo.NGAY_KH, _
            objHIEU_CHUAN_DHDInfo.DUONG_DAN, objHIEU_CHUAN_DHDInfo.GHI_CHU, objHIEU_CHUAN_DHDInfo.DD_GOC)
        End Sub
        Public Sub DeleteHIEU_CHUAN_DHD(ByVal strMS_MAY As String, ByVal strMS_PT As String, ByVal intMS_VI_TRI As String, ByVal strNGAY_HC As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHIEU_CHUAN_DHD", strMS_MAY, strMS_PT, intMS_VI_TRI, strNGAY_HC)
        End Sub
        Public Function CheckNgayHC_DHD(ByVal strMS_MAY As String, ByVal strMS_PT As String, ByVal intMS_VI_TRI As String, ByVal intNAM As String) As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckNgayHC_DHD", strMS_MAY, strMS_PT, intMS_VI_TRI, intNAM)
            Dim tmp As Integer = 0
            While objDataReader.Read
                tmp = tmp + 1
            End While
            objDataReader.Close()
            Return tmp
        End Function
    End Class
End Namespace

