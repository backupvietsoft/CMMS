Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue

    Public Class clsLANGUAGEControllers

        Public Sub New()
        End Sub
        Public Function GetLANGUAGEs(ByVal iType As Integer, ByVal bform As Byte) As DataTable
            Dim objTabel As New DataTable
            objTabel.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLANGUAGEs", iType, bform))
            Return objTabel
        End Function

        Public Function GetLANGUAGE_FORMs(ByVal FORM As String) As DataTable
            Dim objTabel As New DataTable
            objTabel.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLANGUAGE_FORMs", FORM))
            Return objTabel
        End Function
        Public Sub UpdateLANGUAGES(ByVal objLANGUAGEInfo As LANGUAGESInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateLANGUAGES", _
            objLANGUAGEInfo.STT, objLANGUAGEInfo.MS_MODULE, objLANGUAGEInfo.FORM, objLANGUAGEInfo.KEYWORD, _
            objLANGUAGEInfo.VIETNAM, objLANGUAGEInfo.ENGLISH, objLANGUAGEInfo.CHINESE)
        End Sub
        Public Sub UpdateData(ByVal dt As DataTable, ByVal FORM As String)
            Dim objDataTable As DataTable
            Dim sda As SqlDataAdapter
            Dim scmd As SqlCommand
            objDataTable = dt.GetChanges()
            If Not objDataTable Is Nothing Then
                Try
                    scmd = New SqlCommand("GetLANGUAGE_FORMs", New SqlConnection(Commons.IConnections.ConnectionString))
                    scmd.CommandType = CommandType.StoredProcedure
                    scmd.Parameters.Add(New SqlParameter("@FORM", FORM))
                    sda = New SqlDataAdapter(scmd)
                    Dim scb As New SqlCommandBuilder(sda)
                    sda.TableMappings.Add("TABLE", dt.TableName)
                    For Each vr As DataRow In objDataTable.Rows
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_LANGUAGES_LOG", vr("stt"), "frmLanguage", Commons.Modules.UserName, 2)
                    Next
                    sda.Update(objDataTable)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If

        End Sub

    End Class
End Namespace

