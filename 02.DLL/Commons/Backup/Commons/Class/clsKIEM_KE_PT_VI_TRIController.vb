Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.IEStock
    Public Class KIEM_KE_PT_VI_TRIController
        
        Public Sub New()
        End Sub

#Region "Public Method"
        Public Function GetKIEM_KE_PT_VI_TRIs(Optional ByVal MsKho As Integer = 0, Optional ByVal Ngay As Date = Nothing) As DataTable
            Dim objDataTable As DataTable = New DataTable
            If MsKho <> 0 And Ngay <> "#12:00:00 AM#" Then
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT_VI_TRIs", Ngay, MsKho))
            Else
                If MsKho <> 0 Then
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT_VI_TRI_KHOs", MsKho))
                ElseIf Ngay <> "#12:00:00 AM#" Then
                    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT_VI_TRI_NGAYs", Ngay))
                Else
                    Return Nothing
                End If
            End If
            Return objDataTable

            'Dim objDataTable As DataTable
            'objDataTable = New DataTable

            'If MsKho <> 0 And Ngay <> "#12:00:00 AM#" Then
            '    scmd = New SqlCommand("GetKIEM_KE_PT_VI_TRIs", New SqlConnection(Commons.IConnections.ConnectionString))
            '    scmd.Parameters.Add(New SqlParameter("@MS_KHO", MsKho))
            '    scmd.Parameters.Add(New SqlParameter("@NGAY", Ngay))
            'Else
            '    If MsKho <> 0 Then
            '        scmd = New SqlCommand("GetKIEM_KE_PT_VI_TRI_KHOs", New SqlConnection(Commons.IConnections.ConnectionString))
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

        'Public Function GetKIEM_KE_PT_VI_TRI(ByVal Ngay As Date, ByVal MsKho As Integer, ByVal MsPT As String) As KIEM_KE_PT_VI_TRIInfo
        '    Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT_VI_TRI", Ngay, MsKho, MsPT)

        '    Dim objKIEM_KE_PT_VI_TRIInfo As New KIEM_KE_PT_VI_TRIInfo
        '    While objDataReader.Read
        '        objKIEM_KE_PT_VI_TRIInfo.MS_KHO = objDataReader.Item("MS_KHO")
        '        objKIEM_KE_PT_VI_TRIInfo.MS_PT = objDataReader.Item("MS_PT")
        '        objKIEM_KE_PT_VI_TRIInfo.NGAY = objDataReader.Item("NGAY")
        '        objKIEM_KE_PT_VI_TRIInfo.SL_KK_VI_TRI = objDataReader.Item("SL_KK")
        '        objKIEM_KE_PT_VI_TRIInfo.SL_TON_VI_TRI = objDataReader.Item("SL_TON")
        '    End While
        '    Return objKIEM_KE_PT_VI_TRIInfo
        'End Function

        Public Function GetKIEM_KE_PT_VI_TRI(ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer, ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKIEM_KE_PT_VI_TRI", NGAY, THANG, NAM, MS_KHO))
            Dim PrimaryKeyColumns(2) As DataColumn
            PrimaryKeyColumns(0) = objDataTable.Columns("MS_KHO")
            PrimaryKeyColumns(1) = objDataTable.Columns("MS_PT")
            PrimaryKeyColumns(2) = objDataTable.Columns("MS_VI_TRI")
            objDataTable.PrimaryKey = PrimaryKeyColumns
            Return objDataTable
        End Function
        Public Function GetNGAY_KIEM_KE_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNGAY_KIEM_KE_PT", MS_KHO, MS_PT)
        End Function
        Public Function GetSL_TON_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer) As Double
            Dim SO_LUONG_TON As Double = 0
            Dim SL_TON_READER As SqlDataReader
            SL_TON_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSL_TON_PT", MS_KHO, MS_PT, MS_VI_TRI)
            If SL_TON_READER.Read Then
                SO_LUONG_TON = SL_TON_READER.Item("SL_TON")
            End If
            Return SO_LUONG_TON
        End Function
        Public Function GetSO_LUONG_NHAP_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer) As Double
            Dim SO_LUONG_TON_PT As Double = 0
            Dim SL_TON_PT_READER As SqlDataReader
            SL_TON_PT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSO_LUONG_NHAP_PT", MS_KHO, MS_PT, MS_VI_TRI)
            If SL_TON_PT_READER.Read Then
                SO_LUONG_TON_PT = SL_TON_PT_READER.Item("SO_LUONG")
            End If
            Return SO_LUONG_TON_PT
        End Function
        Public Function GetSO_LUONG_XUAT_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer) As Double
            Dim SO_LUONG_XUAT_PT As Double = 0
            Dim SL_XUAT_PT_READER As SqlDataReader
            SL_XUAT_PT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSO_LUONG_XUAT_PT", MS_KHO, MS_PT, MS_VI_TRI)
            If SL_XUAT_PT_READER.Read Then
                SO_LUONG_XUAT_PT = SL_XUAT_PT_READER.Item("SO_LUONG")
            End If
            Return SO_LUONG_XUAT_PT
        End Function
        Public Function GetSL_TON_VI_TRI(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer)
            Dim SO_LUONG_TON_PT_VT As Double = 0
            Dim SL_XUAT_PT_READER As SqlDataReader
            SL_XUAT_PT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSL_TON_VI_TRI", MS_KHO, MS_PT, MS_VI_TRI)
            If SL_XUAT_PT_READER.Read Then
                SO_LUONG_TON_PT_VT = SL_XUAT_PT_READER.Item(0)
            End If
            Return SO_LUONG_TON_PT_VT
        End Function
        Public Function GetNews(ByVal Ngay As Date, ByVal MsKho As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            Dim objDataNews As SqlDataReader
            Dim myRow As DataRow
            Dim i As Integer = 0
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_KhoTinhTonVT", MsKho, Ngay))

            For i = 0 To (objDataTable.Rows.Count - 1)
                If Ngay > objDataTable.Rows(1).Item("NGAY") Then
                    objDataTable.Rows(i).Item("SL_TON") = GetNhapXuatTrongKy(MsKho, objDataTable.Rows(i).Item("MS_PT"), objDataTable.Rows(i).Item("MS_VI_TRI"), objDataTable.Rows(i).Item("NGAY"), Ngay)
                End If
                i = i + 1
            Next

            'Load nhung phu tung moi vao
            objDataNews = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_KhoTinhTonVTNews", MsKho, Ngay)

            While objDataNews.Read
                myRow = objDataTable.NewRow
                myRow.Item("NGAY") = objDataNews.Item("NGAY")
                myRow.Item("MS_KHO") = objDataNews.Item("MS_KHO")
                myRow.Item("MS_VI_TRI") = objDataNews.Item("MS_VI_TRI")
                myRow.Item("MS_PT") = objDataNews.Item("MS_PT")
                myRow.Item("SL_TON_VI_TRI") = GetNhapXuatTrongKy(MsKho, objDataNews.Item("MS_VI_TRI"), objDataNews.Item("MS_PT"), objDataNews.Item("NGAY"), Ngay)
                myRow.Item("SL_KK_VI_TRI") = myRow.Item("SL_TON_VI_TRI")
                objDataTable.Rows.Add(myRow)
            End While
            Return objDataTable
        End Function

        Private Function GetNhapXuatTrongKy(ByVal MsKho As Integer, ByVal MsVtri As Integer, ByVal MsPt As String, ByVal dtTuNgay As Date, ByVal dtDenNgay As Date) As Double
            Dim SL As Double = 0
            Dim objDtb1 As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_SLN_PT_VTRI_TNGAY_DNGAY", MsKho, MsVtri, MsPt, dtTuNgay, dtDenNgay)
            While objDtb1.Read
                SL = IIf(IsDBNull(objDtb1.Item("SLN")), 0, objDtb1.Item("SLN"))
            End While
            objDtb1 = Nothing
            objDtb1 = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKK_SLX_PT_VTRI_TNGAY_DNGAY", MsKho, MsVtri, MsPt, dtTuNgay, dtDenNgay)
            While objDtb1.Read
                SL = SL - IIf(IsDBNull(objDtb1.Item("SLX")), 0, objDtb1.Item("SLX"))
            End While
            Return SL
        End Function
        Public Sub UpdateData(ByVal dt As DataTable)
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
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).RowState = DataRowState.Added Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKIEM_KE_PT_VI_TRI", dt.Rows(i).Item("NGAY").ToString, dt.Rows(i).Item("MS_KHO").ToString, dt.Rows(i).Item("MS_PT").ToString, dt.Rows(i).Item("MS_VI_TRI").ToString, dt.Rows(i).Item("SL_TON_VI_TRI").ToString, dt.Rows(i).Item("SL_KK_VI_TRI").ToString)
                    ElseIf dt.Rows(i).RowState = DataRowState.Modified Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateKIEM_KE_PT_VI_TRI", dt.Rows(i).Item("NGAY").ToString, dt.Rows(i).Item("MS_KHO").ToString, dt.Rows(i).Item("MS_PT").ToString, dt.Rows(i).Item("MS_VI_TRI").ToString, dt.Rows(i).Item("SL_TON_VI_TRI").ToString, dt.Rows(i).Item("SL_KK_VI_TRI").ToString)
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
        Public Sub AddKIEM_KE_PT_VI_TRI(ByVal objKIEM_KE_PT_VI_TRIInfo As KIEM_KE_PT_VI_TRIInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddKIEM_KE_PT_VI_TRI", objKIEM_KE_PT_VI_TRIInfo.NGAY, objKIEM_KE_PT_VI_TRIInfo.MS_KHO, objKIEM_KE_PT_VI_TRIInfo.MS_PT, objKIEM_KE_PT_VI_TRIInfo.MS_VI_TRI, objKIEM_KE_PT_VI_TRIInfo.SL_TON_VI_TRI, objKIEM_KE_PT_VI_TRIInfo.SL_KK_VI_TRI, objKIEM_KE_PT_VI_TRIInfo.GIO, objKIEM_KE_PT_VI_TRIInfo.LOCK)
        End Sub
        Public Sub DeleteKIEM_KE_PT_VI_TRIs(ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer, ByVal MS_KHO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKIEM_KE_PT_VI_TRIs", NGAY, THANG, NAM, MS_KHO)
        End Sub
        Public Sub DeleteKIEM_KE_PT_VI_TRI(ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer, ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKIEM_KE_PT_VI_TRI", NGAY, THANG, NAM, MS_KHO, MS_PT, MS_VI_TRI)
        End Sub
        Public Sub UpdateSL_TON_KIEM_KE_PT(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer, ByVal SL_TON As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateSL_TON_KIEM_KE_PT", MS_KHO, MS_PT, NGAY, THANG, NAM, SL_TON)
        End Sub
        Public Sub UpdateKIEM_KE_PT_VI_TRI(ByVal objKIEM_KE_PT_VI_TRIInfo As KIEM_KE_PT_VI_TRIInfo)
            SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "UpdateKIEM_KE_PT_VI_TRI", objKIEM_KE_PT_VI_TRIInfo.GIO, objKIEM_KE_PT_VI_TRIInfo.MS_KHO, objKIEM_KE_PT_VI_TRIInfo.MS_PT, objKIEM_KE_PT_VI_TRIInfo.MS_VI_TRI, objKIEM_KE_PT_VI_TRIInfo.SL_TON_VI_TRI, objKIEM_KE_PT_VI_TRIInfo.SL_KK_VI_TRI, objKIEM_KE_PT_VI_TRIInfo.GIO, objKIEM_KE_PT_VI_TRIInfo.LOCK)
        End Sub
        Public Function CheckLOCK_IC_DH_NHAP_PT(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckLOCK_IC_DH_NHAP_PT", MS_KHO))
            Return objDataTable
        End Function
        Public Function CheckLOCK_IC_DH_XUAT_PT(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckLOCK_IC_DH_XUAT_PT", MS_KHO))
            Return objDataTable
        End Function
        Public Function CheckLOCKED_KIEM_KE_PT_VI_TRI(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckLOCKED_KIEM_KE_PT_VI_TRI", MS_KHO))
            Return objDataTable
        End Function
        Public Function CheckExistedKIEM_KE_PT_VI_TRI(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer, ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer) As SqlDataReader
            Return SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistedKIEM_KE_PT_VI_TRI", MS_KHO, MS_PT, MS_VI_TRI, NGAY, THANG, NAM)
        End Function
        Public Function GetVI_TRI_KIEM_KE(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetVI_TRI_KIEM_KE", MS_KHO))
            Return objDataTable
        End Function
        Public Function GetPHU_TUNG_KIEM_KE(ByVal MS_KHO As Integer) As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG_KIEM_KE", MS_KHO))
            Return objDataTable
        End Function
        Public Function GetGIO_KIEM_KE(ByVal MS_KHO As Integer, ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer) As String
            Dim GIO_KIEM_KE As String = String.Empty
            Dim GIO_READER As SqlDataReader
            GIO_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGIO_KIEM_KE", MS_KHO, NGAY, THANG, NAM)
            If GIO_READER.Read Then
                GIO_KIEM_KE = GIO_READER.Item("GIO")
            End If
            Return GIO_KIEM_KE
        End Function
        'Lấy ra mã số vị trí theo tên vị trí
        Public Function GetMS_VI_TRI_KIEM_KE(ByVal TEN_VI_TRI As String) As Integer
            Dim MS_VI_TRI As Integer = 0
            Dim MS_VI_TRI_READER As SqlDataReader
            MS_VI_TRI_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_VI_TRI_KIEM_KE", TEN_VI_TRI)
            If MS_VI_TRI_READER.Read Then
                MS_VI_TRI = MS_VI_TRI_READER.Item("MS_VI_TRI")
            End If
            Return MS_VI_TRI
        End Function
        'Lấy ra một số thông tin liên quan đến phụ tùng
        Public Function GetPHU_TUNG_INFO(ByVal MS_PT As String) As DataTable
            Dim objDataTable As New DataTable
            ' Dim PHU_TUNG_INFO_READER As SqlDataReader
            ' Dim DATA_ROW As DataRow
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG_INFO", MS_PT))
            ' PHU_TUNG_INFO_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG_INFO", MS_PT)
            'While PHU_TUNG_INFO_READER.Read
            '    DATA_ROW = objDataTable.NewRow
            '    DATA_ROW.Item("MS_PT") = PHU_TUNG_INFO_READER.Item("MS_PT")
            '    DATA_ROW.Item("MS_PT_CTY") = PHU_TUNG_INFO_READER.Item("MS_PT_CTY")
            '    DATA_ROW.Item("MS_PT_NCC") = PHU_TUNG_INFO_READER.Item("MS_PT_NCC")
            '    DATA_ROW.Item("TEN_PT") = PHU_TUNG_INFO_READER.Item("TEN_PT")
            '    'objDataTable.Rows.Add(DATA_ROW)
            'End While
            Return objDataTable
        End Function
        'Lấy ra số lượng tồn
        Public Function GetSO_LUONG_TON(ByVal MS_KHO As Integer, ByVal MS_PT As String) As Double
            Dim SO_LUONG_TON As Double = 0
            Dim SO_LUONG_TON_READER As SqlDataReader
            SO_LUONG_TON_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetSO_LUONG_TON", MS_KHO, MS_PT)
            If SO_LUONG_TON_READER.Read Then
                SO_LUONG_TON = SO_LUONG_TON_READER.Item("SL_TON")
            End If
            Return SO_LUONG_TON
        End Function
        Public Function GetTONG_SL_TON_PT_VI_TRI(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal NGAY As Integer, ByVal THANG As Integer, ByVal NAM As Integer) As Double
            Dim SL_TON_PT As Double = 0
            Dim SL_TON_PT_READER As SqlDataReader
            SL_TON_PT_READER = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTONG_SL_TON_PT_VI_TRI", MS_KHO, MS_PT, NGAY, THANG, NAM)
            If SL_TON_PT_READER.Read Then
                If Not IsDBNull(SL_TON_PT_READER.Item("SL_TON_VI_TRI")) Then
                    SL_TON_PT = SL_TON_PT_READER.Item("SL_TON_VI_TRI")
                End If
            End If
            Return SL_TON_PT
        End Function
        'Cập nhật số lượng theo vị trí trong bảng KIEM_KE_PT_VI_TRI
        Public Sub UpdateSL_KIEM_KE_PT_VI_TRI(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal SL_TON_VI_TRI As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateSL_KIEM_KE_PT_VI_TRI", MS_KHO, MS_PT, SL_TON_VI_TRI)
        End Sub
        Public Sub UpdateSL_TON_KK_PT_VI_TRI(ByVal MS_KHO As Integer, ByVal MS_PT As String, ByVal MS_VI_TRI As Integer, ByVal SL_TON As Double)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateSL_TON_KK_PT_VI_TRI", MS_KHO, MS_PT, MS_VI_TRI, SL_TON)
        End Sub
#End Region
    End Class
End Namespace
