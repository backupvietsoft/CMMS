Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Namespace VS.Classes.IEStock
    Public Class KIEM_KE_PTController

        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetKIEM_KE_PTs(Optional ByVal MsKho As Integer = 0, Optional ByVal Ngay As Date = Nothing) As DataTable
            Dim objDataTable As DataTable = New DataTable
            If MsKho <> 0 And Ngay <> "#12:00:00 AM#" Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PTs", Ngay, MsKho))
            Else
                If MsKho <> 0 Then
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT_KHOs", MsKho))
                ElseIf Ngay <> "#12:00:00 AM#" Then
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT_NGAYs", Ngay))
                Else
                    Return Nothing
                End If
            End If
            Return objDataTable
            'Dim objDataTable As DataTable
            'objDataTable = New DataTable
            'If MsKho <> 0 And Ngay <> "#12:00:00 AM#" Then
            '    scmd = New SqlCommand("GetKIEM_KE_PTs", New SqlConnection(Commons.IConnections.ConnectionString))
            '    scmd.Parameters.Add(New SqlParameter("@MS_KHO", MsKho))
            '    scmd.Parameters.Add(New SqlParameter("@NGAY", Ngay))
            'Else
            '    If MsKho <> 0 Then
            '        scmd = New SqlCommand("GetKIEM_KE_PT_KHOs", New SqlConnection(Commons.IConnections.ConnectionString))
            '        scmd.Parameters.Add(New SqlParameter("@MS_KHO", MsKho))
            '    ElseIf Ngay <> "#12:00:00 AM#" Then
            '        scmd = New SqlCommand("GetKIEM_KE_PT_NGAYs", New SqlConnection(Commons.IConnections.ConnectionString))
            '        scmd.Parameters.Add(New SqlParameter("@NGAY", Ngay))
            '    Else
            '        Return Nothing
            '    End If
            'End If
            'scmd.CommandType = CommandType.StoredProcedure
            'sda = New SqlDataAdapter(scmd)
            'Dim scb As New SqlCommandBuilder(sda)
            ''scb.GetUpdateCommand()
            'sda.Fill(objDataTable)
            'Return objDataTable
        End Function

        Public Function GetKIEM_KE_PT(ByVal Ngay As Date, ByVal MsKho As Integer, ByVal MsPT As String) As KIEM_KE_PTInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT", Ngay, MsKho, MsPT)
            Dim objKIEM_KE_PTInfo As New KIEM_KE_PTInfo
            While objDataReader.Read
                objKIEM_KE_PTInfo.MS_KHO = objDataReader.Item("MS_KHO")
                objKIEM_KE_PTInfo.MS_PT = objDataReader.Item("MS_PT")
                objKIEM_KE_PTInfo.NGAY = objDataReader.Item("NGAY")
                objKIEM_KE_PTInfo.SL_KK = objDataReader.Item("SL_KK")
                objKIEM_KE_PTInfo.SL_TON = objDataReader.Item("SL_TON")
            End While
            Return objKIEM_KE_PTInfo
        End Function

        Public Function GetNews(ByVal Ngay As Date, ByVal MsKho As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Dim objDataNews As SqlDataReader
            Dim myRow As DataRow
            Dim i As Integer = 0

            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_KhoTinhTon", MsKho, Ngay))

            For i = 0 To (objDataTable.Rows.Count - 1)
                If Ngay > objDataTable.Rows(1).Item("NGAY") Then
                    objDataTable.Rows(i).Item("SL_TON") = GetNhapXuatTrongKy(MsKho, objDataTable.Rows(i).Item("MS_PT"), objDataTable.Rows(i).Item("NGAY"), Ngay)
                End If
                i = i + 1
            Next

            'Load nhung phu tung moi vao
            objDataNews = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_KhoTinhTonNews", MsKho, Ngay)

            While objDataNews.Read
                myRow = objDataTable.NewRow
                myRow.Item("NGAY") = objDataNews.Item("NGAY")
                myRow.Item("MS_KHO") = objDataNews.Item("MS_KHO")
                myRow.Item("MS_PT") = objDataNews.Item("MS_PT")
                myRow.Item("TEN_PT") = objDataNews.Item("TEN_PT")
                myRow.Item("SL_TON") = GetNhapXuatTrongKy(MsKho, objDataNews.Item("MS_PT"), objDataNews.Item("NGAY"), Ngay)
                myRow.Item("SL_KK") = myRow.Item("SL_TON")
                objDataTable.Rows.Add(myRow)
            End While

            Return objDataTable
        End Function

        Private Function GetNhapXuatTrongKy(ByVal MsKho As Integer, ByVal MsPt As String, ByVal dtTuNgay As Date, ByVal dtDenNgay As Date) As Double
            Dim SL As Double = 0
            Dim objDtb1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_SLN_PT_TNGAY_DNGAY", MsKho, MsPt, dtTuNgay, dtDenNgay)
            While objDtb1.Read
                SL = IIf(IsDBNull(objDtb1.Item("SLN")), 0, objDtb1.Item("SLN"))
            End While
            objDtb1 = Nothing
            objDtb1 = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_SLX_PT_TNGAY_DNGAY", MsKho, MsPt, dtTuNgay, dtDenNgay)
            While objDtb1.Read
                SL = SL - IIf(IsDBNull(objDtb1.Item("SLX")), 0, objDtb1.Item("SLX"))
            End While
            Return SL
        End Function

        Public Sub UpdateData(ByVal dt As DataTable, ByVal MsKho As Integer, ByVal Ngay As Date)
            Dim i As Integer = 0

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
                For i = 0 To dt.Rows.Count
                    If dt.Rows(i).RowState = DataRowState.Added Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKIEM_KE_PT", dt.Rows(i).Item("NGAY").ToString, dt.Rows(i).Item("MS_KHO").ToString, dt.Rows(i).Item("MS_PT").ToString, dt.Rows(i).Item("SL_TON").ToString, dt.Rows(i).Item("SL_KK").ToString)
                    ElseIf dt.Rows(i).RowState = DataRowState.Modified Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKIEM_KE_PT", dt.Rows(i).Item("NGAY").ToString, dt.Rows(i).Item("MS_KHO").ToString, dt.Rows(i).Item("MS_PT").ToString, dt.Rows(i).Item("SL_TON").ToString, dt.Rows(i).Item("SL_KK").ToString)
                    End If
                Next
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
        Public Sub DeleteKIEM_KE_PT(ByVal MsKho As Integer, ByVal MsPT As String, ByVal Ngay As DateTime)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKIEM_KE_PT", Ngay, MsKho, MsPT)
        End Sub
        Public Sub UpdateKIEM_KE_PHU_TUNG(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal SL_TON As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKIEM_KE_PHU_TUNG", MS_KHO, MS_PT, SL_TON)
        End Sub
        Public Function GetSO_LUONG_TON_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String) As Double
            Dim SL_TON As Double = 0
            Dim SL_TON_READER As SqlDataReader
            SL_TON_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSO_LUONG_TON_PT", MS_KHO, MS_PT)
            If SL_TON_READER.Read Then
                SL_TON = SL_TON_READER.Item(0)
            End If
            Return SL_TON
        End Function
        Public Function CheckExistedKIEM_KE_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistedKIEM_KE_PT", MS_KHO, MS_PT)
        End Function
        Public Sub AddKIEM_KE_PT(ByVal objKIEM_KE_PTInfo As KIEM_KE_PTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKIEM_KE_PT", objKIEM_KE_PTInfo.NGAY, objKIEM_KE_PTInfo.MS_KHO, objKIEM_KE_PTInfo.MS_PT, objKIEM_KE_PTInfo.SL_TON, objKIEM_KE_PTInfo.SL_KK)
        End Sub
        Public Sub UpdateKIEM_KE_PT(ByVal objKIEM_KE_PTInfo As KIEM_KE_PTInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKIEM_KE_PT", objKIEM_KE_PTInfo.NGAY, objKIEM_KE_PTInfo.MS_KHO, objKIEM_KE_PTInfo.MS_PT, objKIEM_KE_PTInfo.SL_TON, objKIEM_KE_PTInfo.SL_KK)
        End Sub
        Public Sub UpdateSO_LUONG_KK_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal SL_TON As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateSO_LUONG_KK_PT", MS_PT, SL_TON)
        End Sub
#End Region
    End Class
End Namespace