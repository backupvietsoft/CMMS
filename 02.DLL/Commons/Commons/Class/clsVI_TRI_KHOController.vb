Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class VI_TRI_KHOController
        Dim sda As SqlDataAdapter
        Dim scb As SqlCommandBuilder
        Dim scmd As SqlCommand

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetVI_TRI_KHOs(ByVal MsKho As Integer) As DataTable
            Dim objDataTable As DataTable
            objDataTable = New DataTable
            scmd = New SqlCommand("GetVI_TRI_KHOs", New SqlConnection(Commons.IConnections.ConnectionString))
            scmd.CommandType = CommandType.StoredProcedure
            scmd.Parameters.Add(New SqlParameter("@MS_KHO", MsKho))
            sda = New SqlDataAdapter(scmd)
            Dim scb As New SqlCommandBuilder(sda)
            scb.GetUpdateCommand()
            sda.Fill(objDataTable)
            Return objDataTable
        End Function

        Public Function GetVI_TRI_KHO(ByVal MS_VT As Integer) As VI_TRI_KHOInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVI_TRI_KHO", MS_VT)
            Dim objVI_TRI_KHOInfo As New VI_TRI_KHOInfo
            While objDataReader.Read
                objVI_TRI_KHOInfo.MS_KHO = objDataReader.Item("MS_KHO")
                objVI_TRI_KHOInfo.MS_VI_TRI = objDataReader.Item("MS_VI_TRI")
                objVI_TRI_KHOInfo.TEN_VI_TRI = objDataReader.Item("TEN_VI_TRI")
            End While
            Return objVI_TRI_KHOInfo
        End Function

        Public Sub UpdateData(ByVal dt As DataTable, ByVal MsKho As Integer)

            Try
                If (dt.HasErrors) Then
                    If (Reconcile(dt)) Then
                        ' Fixed all errors.
                        dt.AcceptChanges()
                    Else
                        ' Couldn'table fix all errors.
                        dt.RejectChanges()
                    End If
                Else
                    ' If no errors, AcceptChanges.
                    'dt.AcceptChanges()
                End If
                If sda Is Nothing Then
                    GetVI_TRI_KHOs(MsKho)
                End If

                sda.Update(dt)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub

        Private Function Reconcile(ByVal thisTable As DataTable) As Boolean
            Dim row As DataRow
            For Each row In thisTable.Rows
                'Insert code to try to reconcile error.

                ' If there are still errors return immediately
                ' since the caller rejects all changes upon error.
                If row.HasErrors Then
                    Reconcile = False
                    Exit Function
                End If
            Next row
            Reconcile = True
        End Function

        Public Sub DeleteVI_TRI_KHO(ByVal MS_VT As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteVI_TRI_KHO", MS_VT)
        End Sub
#End Region

#Region "Relatives"
        Public Function CheckUsedVITRI_KHO_KK_PT(ByVal MS_VTri As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_KK_PT", MS_VTri))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedVITRI_KHO_KK_VT(ByVal MS_VTri As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_KK_VT", MS_VTri))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedVITRI_KHO_NHAP_PT(ByVal MS_VTri As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_NHAP_PT", MS_VTri))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedVITRI_KHO_NHAP_VT(ByVal MS_VTri As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_NHAP_VT", MS_VTri))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedVITRI_KHO_XUAT_PT(ByVal MS_VTri As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_XUAT_PT", MS_VTri))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedVITRI_KHO_XUAT_VT(ByVal MS_VTri As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_XUAT_VT", MS_VTri))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedVITRI_KHO_CHU_KY_HIEU_CHUAN(ByVal MS_VTri As Integer) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedVITRI_KHO_CHU_KY_HIEU_CHUAN", MS_VTri))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

#End Region
    End Class
End Namespace

