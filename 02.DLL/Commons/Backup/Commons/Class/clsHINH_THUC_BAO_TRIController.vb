Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data



Namespace VS.Classes.Catalogue
    Public Class HINH_THUC_BAO_TRIController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetHINH_THUC_BAO_TRIs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHINH_THUC_BAO_TRIs"))
            Return objDataTable
        End Function

        Public Function GetHINH_THUC_BAO_TRI(ByVal MS_HT_BT As Integer) As HINH_THUC_BAO_TRIInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHINH_THUC_BAO_TRI", MS_HT_BT)
            Dim objHINH_THUC_BAO_TRIInfo As New HINH_THUC_BAO_TRIInfo
            While objDataReader.Read
                objHINH_THUC_BAO_TRIInfo.MS_HT_BT = objDataReader.Item("MS_HT_BT")
                objHINH_THUC_BAO_TRIInfo.TEN_HT_BT = objDataReader.Item("TEN_HT_BT")
                objHINH_THUC_BAO_TRIInfo.PHONG_NGUA = objDataReader.Item("PHONG_NGUA")
            End While
            objDataReader.Close()
            Return objHINH_THUC_BAO_TRIInfo
        End Function

        Public Function AddHINH_THUC_BAO_TRI(ByVal objHINH_THUC_BAO_TRIInfo As HINH_THUC_BAO_TRIInfo) As Integer
            Return CInt(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddHINH_THUC_BAO_TRI", objHINH_THUC_BAO_TRIInfo.TEN_HT_BT, objHINH_THUC_BAO_TRIInfo.PHONG_NGUA))

        End Function

        Public Sub UpdateHINH_THUC_BAO_TRI(ByVal objHINH_THUC_BAO_TRIInfo As HINH_THUC_BAO_TRIInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHINH_THUC_BAO_TRI", _
                objHINH_THUC_BAO_TRIInfo.MS_HT_BT, objHINH_THUC_BAO_TRIInfo.TEN_HT_BT, objHINH_THUC_BAO_TRIInfo.PHONG_NGUA)
        End Sub

        Public Sub DeleteHINH_THUC_BAO_TRI(ByVal _MS_HT_BT As Integer)
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHINH_THUC_BAO_TRI", _MS_HT_BT)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Sub
        Public Sub InsertHINH_THUC_BAO_TRI_LOG(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_HINH_THUC_BAO_TRI_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub

        Public Function CheckExistTEN_HT_BT(ByVal TEN_HT_BT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistTEN_HT_BT", TEN_HT_BT)
        End Function

        Public Function CheckHINH_THUC_BAO_TRI(ByVal MS_HT_BT As Integer, ByVal TEN_HT_BT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckHINH_THUC_BAO_TRI", MS_HT_BT, TEN_HT_BT)
        End Function
        Public Sub DeleteHINH_THUC_BAO_TRI_LOAI_BAO_TRI(ByVal _MS_HT_BT As Integer)
            Try
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteHINH_THUC_BAO_TRI_LOAI_BAO_TRI", _MS_HT_BT)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Sub
#End Region

#Region "Relatives"
        Public Function CheckUsedHINH_THUC_BAO_TRI_LOAI_BAO_TRI(ByVal MS_HT_BT As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedHINH_THUC_BAO_TRI_LOAI_BAO_TRI", MS_HT_BT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        'CheckExitsDINH_KY
        Public Function CheckExitsDINH_KY() As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExitsDINH_KY"))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region
    End Class
End Namespace


