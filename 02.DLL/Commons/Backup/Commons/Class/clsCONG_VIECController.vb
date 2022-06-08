Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class CONG_VIECController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetBAC_THOs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBAC_THOs"))
            Return objDataTable
        End Function

        Public Function GetCHUYEN_MONs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUYEN_MONs"))
            Return objDataTable
        End Function

        Public Function GetLOAI_CONG_VIECs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIECs"))
            Return objDataTable
        End Function

        Public Function GetLOAI_MAYs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAYs"))
            Return objDataTable
        End Function

        Public Function GetCONG_VIECs(ByVal userdn As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIECs", userdn))
            Return objDataTable
        End Function

        Public Function GetCONG_VIEC_LOC_LOAI_MAY() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOC_LOAI_MAY"))
            Return objDataTable
        End Function

        Public Function GetCONG_VIEC_LOAI_MAY(ByVal MS_LOAI_MAY As String, ByVal userdn As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOAI_MAY", MS_LOAI_MAY, userdn))
            Return objDataTable

            'Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOAI_MAY", MS_LOAI_MAY)
            'Dim objCONG_VIECInfo As New CONG_VIECInfo
            'While objDataReader.Read
            '    objCONG_VIECInfo.MS_CV = objDataReader.Item("MS_CV")
            '    objCONG_VIECInfo.MS_LOAI_CV = objDataReader.Item("MS_LOAI_CV")
            '    objCONG_VIECInfo.MO_TA_CV = objDataReader.Item("MO_TA_CV")
            '    objCONG_VIECInfo.PATH_HD = objDataReader.Item("PATH_HD")
            '    objCONG_VIECInfo.MS_LOAI_MAY = objDataReader.Item("MS_LOAI_MAY")
            '    objCONG_VIECInfo.THOI_GIAN_DU_KIEN = objDataReader.Item("THOI_GIAN_DU_KIEN")
            '    objCONG_VIECInfo.THAO_TAC = objDataReader.Item("THAO_TAC")
            '    objCONG_VIECInfo.TIEU_CHUAN_KT = objDataReader.Item("TIEU_CHUAN_KT")
            '    objCONG_VIECInfo.MS_CM = objDataReader.Item("MS_CM")
            '    objCONG_VIECInfo.MS_BT = objDataReader.Item("MS_BT")
            'End While
            'Return objCONG_VIECInfo
        End Function

        Public Function GetCONG_VIEC(ByVal ID As Integer) As CONG_VIECInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC", ID)
            Dim objCONG_VIECInfo As New CONG_VIECInfo
            While objDataReader.Read
                objCONG_VIECInfo.MS_CV = objDataReader.Item("MS_CV")
                objCONG_VIECInfo.MS_LOAI_CV = objDataReader.Item("MS_LOAI_CV")
                objCONG_VIECInfo.MO_TA_CV = objDataReader.Item("MO_TA_CV")
                objCONG_VIECInfo.PATH_HD = objDataReader.Item("PATH_HD")
                objCONG_VIECInfo.MS_LOAI_MAY = objDataReader.Item("MS_LOAI_MAY")
                objCONG_VIECInfo.THOI_GIAN_DU_KIEN = objDataReader.Item("THOI_GIAN_DU_KIEN")
                objCONG_VIECInfo.THAO_TAC = objDataReader.Item("THAO_TAC")
                objCONG_VIECInfo.TIEU_CHUAN_KT = objDataReader.Item("TIEU_CHUAN_KT")
                objCONG_VIECInfo.MS_CM = objDataReader.Item("MS_CM")
                objCONG_VIECInfo.MS_BT = objDataReader.Item("MS_BT")
                objCONG_VIECInfo.MA_CV = objDataReader.Item("MA_CV")
                objCONG_VIECInfo.KY_HIEU_CV = objDataReader.Item("KY_HIEU_CV")
                objCONG_VIECInfo.DINH_MUC = objDataReader.Item("DINH_MUC")
                objCONG_VIECInfo.NGOAI_TE = objDataReader.Item("NGOAI_TE")
            End While
            objDataReader.Close()
            Return objCONG_VIECInfo
        End Function

        Public Function AddCONG_VIEC(ByVal objCONG_VIECInfo As CONG_VIECInfo, ByVal Formname As String) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddCONG_VIEC", objCONG_VIECInfo.MA_CV, objCONG_VIECInfo.MS_LOAI_CV, _
                objCONG_VIECInfo.MO_TA_CV, objCONG_VIECInfo.PATH_HD, objCONG_VIECInfo.MS_LOAI_MAY, objCONG_VIECInfo.THOI_GIAN_DU_KIEN, _
                objCONG_VIECInfo.THAO_TAC, objCONG_VIECInfo.TIEU_CHUAN_KT, objCONG_VIECInfo.MS_CM, objCONG_VIECInfo.MS_BT, _
                objCONG_VIECInfo.MA_CV, objCONG_VIECInfo.KY_HIEU_CV, objCONG_VIECInfo.AN_TOAN, objCONG_VIECInfo.DINH_MUC, _
                objCONG_VIECInfo.NGOAI_TE, objCONG_VIECInfo.GhiChu, objCONG_VIECInfo.SO_NGUOI, objCONG_VIECInfo.YEU_CAU_NS, objCONG_VIECInfo.YEU_CAU_DUNG_CU)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_LOG", objCONG_VIECInfo.MS_CV, FormName, Commons.Modules.UserName, 1)

            Return True
        End Function

        Public Sub UpdateCONG_VIEC(ByVal objCONG_VIECInfo As CONG_VIECInfo, Optional ByVal FormName As String = "", Optional ByVal FormCaption As String = "")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_LOG", objCONG_VIECInfo.MS_CV, FormName, Commons.Modules.UserName, 2)
            'KY_HIEU_CV
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateCONG_VIEC", _
               objCONG_VIECInfo.MS_CV, objCONG_VIECInfo.MS_LOAI_CV, objCONG_VIECInfo.MO_TA_CV, objCONG_VIECInfo.PATH_HD, objCONG_VIECInfo.MS_LOAI_MAY, _
                objCONG_VIECInfo.THOI_GIAN_DU_KIEN, objCONG_VIECInfo.THAO_TAC, objCONG_VIECInfo.TIEU_CHUAN_KT, objCONG_VIECInfo.MS_CM, _
                objCONG_VIECInfo.MS_BT, objCONG_VIECInfo.MA_CV, objCONG_VIECInfo.KY_HIEU_CV, objCONG_VIECInfo.AN_TOAN, _
                objCONG_VIECInfo.DINH_MUC, objCONG_VIECInfo.NGOAI_TE, objCONG_VIECInfo.GhiChu, objCONG_VIECInfo.SO_NGUOI, objCONG_VIECInfo.YEU_CAU_NS, objCONG_VIECInfo.YEU_CAU_DUNG_CU)

        End Sub


        Public Sub DeleteCONG_VIEC(ByVal MS_CV As Integer, ByVal formname As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_LOG", MS_CV, formname, Commons.Modules.UserName, 1)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteCONG_VIEC", MS_CV)
        End Sub

        Public Function CheckMA_CV(ByVal MA_CV As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckMA_CV", MA_CV)
        End Function
        Public Function CheckCONG_VIEC(ByVal MS_CV As Integer, ByVal MA_CV As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckCONG_VIEC", MS_CV, MA_CV)
        End Function

        Public Function Check_MO_TA_CONG_VIEC(ByVal MS_LOAI_MAY As String, ByVal MO_TA_CV As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_MO_TA_CONG_VIEC", MS_LOAI_MAY, MO_TA_CV))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region
    End Class
End Namespace
