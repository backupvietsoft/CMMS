Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsYEU_CAU_NSD_CHI_TIETController

        Public Sub New()

        End Sub
        Public Function getYEU_CAU_NSD_CHI_TIET(ByVal intSTT As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getYEU_CAU_NSD_CHI_TIET", intSTT))
            Return objDataTable
        End Function

        Public Function AddYEU_CAU_NSD_CHI_TIET(ByVal objYEU_CAU_NSD_CTInfo As YEU_CAU_NSD_CHI_TIETInfo) As String
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddYEU_CAU_NSD_CHI_TIET", _
               objYEU_CAU_NSD_CTInfo.STT, objYEU_CAU_NSD_CTInfo.MS_MAY, objYEU_CAU_NSD_CTInfo.MO_TA_TINH_TRANG, objYEU_CAU_NSD_CTInfo.YEU_CAU, _
                objYEU_CAU_NSD_CTInfo.NGUOI_XAC_NHAN, objYEU_CAU_NSD_CTInfo.NOI_DUNG_XAC_NHAN, objYEU_CAU_NSD_CTInfo.UU_TIEN)
            Return True
        End Function

        Public Sub UpdateYEU_CAU_NSD_CHI_TIET(ByVal objYEU_CAU_NSD_CTInfo As YEU_CAU_NSD_CHI_TIETInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateYEU_CAU_NSD_CHI_TIET", _
                           objYEU_CAU_NSD_CTInfo.STT, objYEU_CAU_NSD_CTInfo.MS_MAY, objYEU_CAU_NSD_CTInfo.MS_MAY_TMP, objYEU_CAU_NSD_CTInfo.STT_VAN_DE, objYEU_CAU_NSD_CTInfo.MO_TA_TINH_TRANG, objYEU_CAU_NSD_CTInfo.YEU_CAU, _
                            objYEU_CAU_NSD_CTInfo.NGUOI_XAC_NHAN, objYEU_CAU_NSD_CTInfo.NOI_DUNG_XAC_NHAN, objYEU_CAU_NSD_CTInfo.UU_TIEN)
        End Sub
        Public Sub DeleteYEU_CAU_NSD_CHI_TIET(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intSTT_VAN_DE As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteYEU_CAU_NSD_CHI_TIET", intSTT, strMS_MAY, intSTT_VAN_DE)
        End Sub
        Public Function getSTT_VAN_DE_YC_NSD() As Integer
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getSTT_VAN_DE_YC_NSD")
            Dim intSTT As Integer = -1
            While objDataReader.Read
                intSTT = objDataReader.Item("STT_VAN_DE")
            End While
            Return intSTT
        End Function
        Public Sub UpdateChitietyeucau(ByVal dt As DataTable, ByVal intSTT As String)
            Dim objDataTable As DataTable
            Dim sda As SqlDataAdapter
            Dim scmd As SqlCommand
            objDataTable = dt.GetChanges()
            If Not objDataTable Is Nothing Then
                Try
                    scmd = New SqlCommand("getYEU_CAU_NSD_CHI_TIET", New SqlConnection(Commons.IConnections.ConnectionString))
                    scmd.CommandType = CommandType.StoredProcedure
                    scmd.Parameters.Add(New SqlParameter("@STT", intSTT))
                    sda = New SqlDataAdapter(scmd)
                    Dim scb As New SqlCommandBuilder(sda)
                    sda.TableMappings.Add("TABLE", dt.TableName)
                    sda.Update(objDataTable)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End Sub
    End Class
End Namespace
