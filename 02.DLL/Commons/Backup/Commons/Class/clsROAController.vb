Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsROAController

        Public Sub New()
        End Sub
        Public Function GetEOR_ROAs(ByVal TU_NGAY As String, ByVal DEN_NGAY As String, ByVal DUYET As Boolean) As DataTable
            Dim objDataTable As DataTable = New DataTable
            If DUYET Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_ROAs", TU_NGAY, DEN_NGAY, 1)) ', Commons.Modules.UserName
            Else
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetEOR_ROAs", TU_NGAY, DEN_NGAY, 0)) ', Commons.Modules.UserName
            End If

            Return objDataTable
        End Function

        Public Sub UpdatePHE_DUYET_ROA(ByVal objEORInfo As clsEORInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHE_DUYET_ROA", objEORInfo.EOR_ID, objEORInfo.HEAD_DUYET, objEORInfo.HEAD_COMMENT, objEORInfo.GHI_CHU_3, objEORInfo.HEAD_NAME, objEORInfo.MANAGER_DUYET, objEORInfo.GHI_CHU_4, objEORInfo.MANAGER_NAME)

        End Sub
        Public Sub UpdatePHE_DUYET_ROA1(ByVal objEORInfo As clsEORInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHE_DUYET_ROA1", objEORInfo.EOR_ID, _
           objEORInfo.MANAGER_DUYET, objEORInfo.GHI_CHU_4, objEORInfo.MANAGER_NAME)
        End Sub

        Public Function GetCHUC_NANG_ROA(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUC_NANG_ROA", USERNAME))
            Return objDataTable
        End Function
        Public Function Get_SO_ROA(ByVal NGAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_SO_ROA", NGAY))
            Return objDataTable
        End Function

        Public Sub UpdateEOR_ROA(ByVal EOR_ID As String, ByVal SO_ROA As String, ByVal NGAY As String, ByVal LOCK As Boolean)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEOR_ROA", EOR_ID, SO_ROA, NGAY, LOCK)
        End Sub
        Function CheckPheDuyetROA(ByVal EOR_ID As String) As Boolean
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckPheDuyetROA", EOR_ID)
            Dim bCo As Boolean = False
            While objReader.Read
                If objReader.Item("EOR_ID").ToString <> "" Then
                    bCo = True
                    Exit Function
                End If
            End While
            objReader.Close()
            Return bCo
        End Function
        Public Sub UpdateHANG_MUC_EOR(ByVal EOR_ID As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateHANG_MUC_EOR", EOR_ID)
        End Sub
        Public Sub UpdateData(ByVal TBDichVu As DataTable, ByVal TBPhuTung As DataTable, ByVal TBCongViec As DataTable, ByVal EOR_ID As String)
            Dim objDataTable As DataTable
            Dim sda As SqlDataAdapter
            Dim scmd As SqlCommand
            objDataTable = TBDichVu.GetChanges()
            If Not objDataTable Is Nothing Then
                Try
                    scmd = New SqlCommand("GetEorDichVu", New SqlConnection(Commons.IConnections.ConnectionString))
                    scmd.CommandType = CommandType.StoredProcedure
                    scmd.Parameters.Add(New SqlParameter("@EOR_ID", EOR_ID))
                    sda = New SqlDataAdapter(scmd)
                    Dim scb As New SqlCommandBuilder(sda)
                    sda.TableMappings.Add("TABLE", TBDichVu.TableName)
                    sda.Update(objDataTable)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
            objDataTable = TBPhuTung.GetChanges()
            If Not objDataTable Is Nothing Then
                For i As Integer = 0 To objDataTable.Rows.Count - 1
                    UpdateEorPhuTung(EOR_ID, objDataTable.Rows(i).Item("MS_PT"), objDataTable.Rows(i).Item("DUYET"))
                Next
            End If
            objDataTable = TBCongViec.GetChanges()
            If Not objDataTable Is Nothing Then
                For i As Integer = 0 To objDataTable.Rows.Count - 1
                    If objDataTable.Rows(i).Item("CHINH_PHU") Then
                        UpdateEorCongViec(EOR_ID, objDataTable.Rows(i).Item("MS_CV"), objDataTable.Rows(i).Item("MS_BO_PHAN"), objDataTable.Rows(i).Item("DUYET"))
                    Else
                        UpdateEorCongViecPhuTro(EOR_ID, objDataTable.Rows(i).Item("MS_CV"), objDataTable.Rows(i).Item("DUYET"))
                    End If
                Next
            End If
        End Sub
        Public Sub UpdateEorPhuTung(ByVal EOR_ID As String, ByVal MS_PT As String, ByVal CHON As Boolean)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEorPhuTung", EOR_ID, MS_PT, CHON)
        End Sub
        Public Sub UpdateEorCongViec(ByVal EOR_ID As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String, ByVal CHON As Boolean)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEorCongViec", EOR_ID, MS_CV, MS_BO_PHAN, CHON)
        End Sub
        Public Sub UpdateEorCongViecPhuTro(ByVal EOR_ID As String, ByVal STT As Integer, ByVal CHON As Boolean)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateEorCongViecPhuTro", EOR_ID, STT, CHON)
        End Sub

    End Class
End Namespace
