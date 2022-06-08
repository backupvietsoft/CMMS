Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue

    Public Class LOAI_BAO_TRIController
        Public Sub New()
        End Sub


#Region "Public Method"
        Public Function GetHINH_THUC_BAO_TRIs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHINH_THUC_BAO_TRIs"))
            Return objDataTable
        End Function

        'Public Function GetLOAI_BAO_TRI(ByVal ID As Integer) As LOAI_BAO_TRIInfo
        '    Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC", ID)
        '    Dim objLOAI_BAO_TRIInfo As New LOAI_BAO_TRIInfo
        '    Try
        '        While objDataReader.Read
        '            objLOAI_BAO_TRIInfo.MS_LOAI_BT = objDataReader.Item("MS_LOAI_BT")
        '            objLOAI_BAO_TRIInfo.MS_HT_BT = objDataReader.Item("MS_HT_BT")
        '            objLOAI_BAO_TRIInfo.TEN_LOAI_BT = objDataReader.Item("TEN_LOAI_BT")
        '            objLOAI_BAO_TRIInfo.GHI_CHU = objDataReader.Item("GHI_CHU")
        '            objLOAI_BAO_TRIInfo.THU_TU = objDataReader.Item("THU_TU")
        '        End While
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '    End Try

        '    Return objLOAI_BAO_TRIInfo
        'End Function


        Public Function GetLOAI_BAO_TRI(ByVal ID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_BAO_TRI", ID))
            Return objDataTable
        End Function

        'Public Function AddLOAI_BAO_TRI(ByVal objLOAI_BAO_TRIInfo As LOAI_BAO_TRIInfo) As Integer
        '    Return CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLOAI_BAO_TRI", objLOAI_BAO_TRIInfo.MS_HT_BT, objLOAI_BAO_TRIInfo.TEN_LOAI_BT, objLOAI_BAO_TRIInfo.GHI_CHU, objLOAI_BAO_TRIInfo.THU_TU), Integer)
        'End Function

        Public Function AddLOAI_BAO_TRI(ByVal MS_HT_BT As Integer, ByVal TEN_LOAI_BT As String, ByVal GHI_CHU As String, ByVal THU_TU As Integer, ByVal huhong As Integer)
            Return (CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddLOAI_BAO_TRI", MS_HT_BT, TEN_LOAI_BT, GHI_CHU, THU_TU, huhong), Integer))
        End Function

        'Public Sub UpdateLOAI_BAO_TRI(ByVal objLOAI_BAO_TRIInfo As LOAI_BAO_TRIInfo)
        '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_BAO_TRI", objLOAI_BAO_TRIInfo.MS_LOAI_BT, objLOAI_BAO_TRIInfo.MS_HT_BT, objLOAI_BAO_TRIInfo.TEN_LOAI_BT, objLOAI_BAO_TRIInfo.GHI_CHU, objLOAI_BAO_TRIInfo.THU_TU)
        'End Sub

        Public Sub UpdateLOAI_BAO_TRI(ByVal MS_LOAI_BT As Integer, ByVal MS_HT_BT As Integer, ByVal TEN_LOAI_BT As String, ByVal GHI_CHU As String, ByVal THU_TU As Integer, ByVal huhong As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLOAI_BAO_TRI", MS_LOAI_BT, MS_HT_BT, TEN_LOAI_BT, GHI_CHU, THU_TU, huhong)
        End Sub

        Public Sub DeleteLOAI_BAO_TRI(ByVal MS_LOAI_BT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteLOAI_BAO_TRI", MS_LOAI_BT)
        End Sub
        Public Sub InsertLOAI_BAO_TRI(ByVal ID As String, ByVal FORM_NAME As String, ByVal USER_NAME As String, ByVal THAO_TAC As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_LOAI_BAO_TRI_LOG", ID, FORM_NAME, USER_NAME, THAO_TAC)
        End Sub

        Public Function CheckExistTHU_TU(ByVal THU_TU As String) As SqlDataReader
            Dim QUERY As String

            'If THU_TU.Equals(String.Empty) = False Then
            Try
                QUERY = "SELECT * FROM LOAI_BAO_TRI WHERE THU_TU ='" & THU_TU & "' AND THU_TU !=0"
                Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
            Catch ex As Exception

            End Try

            Return Nothing

        End Function
        'Public Function GetMAX_THU_TU() As Integer
        '    Dim MAX_THU_TU As Integer
        '    Dim QUERY As String = "SELECT COUNT(THU_TU) FROM LOAI_BAO_TRI"
        '    Dim THU_TU_READER As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
        '    If THU_TU_READER.Read Then
        '        MAX_THU_TU = THU_TU_READER.Item(0)
        '        MAX_THU_TU = MAX_THU_TU + MAX_THU_TU
        '    End If
        '    Return MAX_THU_TU
        'End Function
        Public Function CheckLOAI_BAO_TRI(ByVal TEN_LOAI_BT As String, ByVal THU_TU As Integer) As SqlDataReader
            Dim QUERY = "SELECT * FROM LOAI_BAO_TRI WHERE TEN_LOAI_BT='" & TEN_LOAI_BT & "'" & " AND THU_TU='" & THU_TU & "'"
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
        End Function
        Public Function CheckTEN_LOAI_BT(ByVal TEN_LOAI_BT As String) As SqlDataReader
            Dim QUERY As String = "SELECT * FROM LOAI_BAO_TRI WHERE TEN_LOAI_BT='" & TEN_LOAI_BT & "'"
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, QUERY)
        End Function
#End Region
    End Class
End Namespace
