
Imports System.Data
Imports System.Data.SqlClient
Imports Commons.QL.Common.Data
Imports Microsoft.ApplicationBlocks.Data
Namespace VS.Classes.Catalogue
    Public Class KIEM_KE_Controller

        Private connectionString As String = ""

        Public Sub New()
            connectionString = Commons.IConnections.ConnectionString
        End Sub

        Public Function Load_Authorized_User_Form(ByVal Form_Name As String) As String
            Dim dtReaderUserForm As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_USER_FORM", Commons.Modules.UserName, Form_Name)
            Dim authorized As String = ""
            While dtReaderUserForm.Read
                authorized = dtReaderUserForm.Item("QUYEN")
            End While
            dtReaderUserForm.Close()
            Return authorized
        End Function

        Public Function Load_Authorized_Lock() As Boolean
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_USER_LOCK", Commons.Modules.UserName)
            Dim Flag As Boolean = False
            While dtReader.Read
                Flag = True
            End While
            Return Flag
        End Function

        Public Function CHECK_PHIEU_XUAT_UNLOCK_EXISTS(ByVal MS_KHO As Integer) As Boolean
            Dim Flag As Boolean = False
            Try
                Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_PHIEU_XUAT_UNLOCK_THEO_KHO", MS_KHO)
                While dtReader.Read
                    Flag = True
                    Exit While
                End While
            Catch ex As Exception
                Flag = True
            End Try
            Return Flag
        End Function

        Public Function CHECK_PHIEU_NHAP_UNLOCK_EXISTS(ByVal MS_KHO As Integer) As Boolean
            Dim Flag As Boolean = False
            Try
                Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_PHIEU_NHAP_UNLOCK_THEO_KHO", MS_KHO)
                While dtReader.Read
                    Flag = True
                    Exit While
                End While
            Catch ex As Exception
                Flag = True
            End Try
            Return Flag
        End Function

        Public Function CHECK_PHIEU_KIEM_KE_UNLOCK_EXISTS(ByVal MS_KHO As String) As Boolean
            Dim Flag As Boolean = False
            Try
                Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_KIEM_KE_UNLOCK_THEO_KHO", MS_KHO)
                While dtReader.Read
                    Flag = True
                    Exit While
                End While
            Catch ex As Exception
                Flag = True
            End Try
            Return Flag
        End Function

        Public Function CHECK_PHIEU_KIEM_KE_EXISTS(ByVal MS_KHO As Integer, ByVal NGAY As DateTime) As Boolean
            Dim Flag As Boolean = False
            Try
                Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_PHIEU_KIEM_KE_EXISTS", MS_KHO, NGAY)
                While dtReader.Read
                    Flag = True
                    Exit While
                End While
            Catch ex As Exception
                Flag = True
            End Try
            Return Flag
        End Function

        Public Function CheckIC_KHO_LON_HON_NGAY_KIEM_KE(ByVal GIO As String, ByVal NGAY As String, ByVal MS_KHO As Integer) As Boolean
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "MashjCheckIC_KHO_LON_HON_NGAY_KIEM_KE", GIO, NGAY, MS_KHO)
            While dtReader.Read
                Return True
                dtReader.Close()
            End While
            dtReader.Close()
            Return False
        End Function
        Public Function CheckIC_DON_HANG_NHAP_LON_HON_NGAY_KIEM_KE(ByVal GIO As String, ByVal NGAY As String, ByVal MS_KHO As Integer) As Boolean
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "CheckIC_DON_HANG_NHAP_LON_HON_NGAY_KIEM_KE", GIO, NGAY, MS_KHO)
            While dtReader.Read
                Return True
                dtReader.Close()
            End While
            dtReader.Close()
            Return False
        End Function
        Public Function CheckIC_DON_HANG_XUAT_LON_HON_NGAY_KIEM_KE(ByVal GIO As String, ByVal NGAY As String, ByVal MS_KHO As Integer) As Boolean
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "CheckIC_DON_HANG_XUAT_LON_HON_NGAY_KIEM_KE", GIO, NGAY, MS_KHO)
            While dtReader.Read
                Return True
                dtReader.Close()
            End While
            dtReader.Close()
            Return False
        End Function
        Public Function CheckKIEM_KE_VAT_TU_CHI_TIET_LON_HON_NGAY_KIEM_KE(ByVal GIO As String, ByVal NGAY As String, ByVal MS_KHO As Integer) As Boolean
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "CheckKIEM_KE_VAT_TU_CHI_TIET_LON_HON_NGAY_KIEM_KE", GIO, NGAY, MS_KHO)
            While dtReader.Read
                Return True
                dtReader.Close()
            End While
            dtReader.Close()
            Return False
        End Function
        Public Function LOAD_TON_KHO_VAT_TU_THEO_KHO(ByVal MS_KHO As Integer, ByVal GIA_TRI As Integer, ByVal MS_CLASS As Integer) As DataTable
            Dim dtTable As New DataTable
            'Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_LIST_TON_KHO_VAT_TU", MS_KHO, GIA_TRI, MS_CLASS)
            ''Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "GetKIEM_KE_VAT_TUs", GIO, NGAY, MS_KHO, Type)
            'dtTable.Load(dtReader)
            'dtReader.Close()

            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_LIST_TON_KHO_VAT_TU", MS_KHO, GIA_TRI, MS_CLASS))
            Dim column As New DataColumn("SL_TON_TT")
            column.DataType = GetType(String)
            column.DefaultValue = ""
            dtTable.Columns.Add(column)
            Dim columnS As New DataColumn("GHI_CHU")
            columnS.DataType = GetType(String)
            columnS.DefaultValue = ""
            dtTable.Columns.Add(columnS)
            Return dtTable
        End Function

        Public Function LOAD_PHIEU_KIEM_KE(ByVal MS_KHO As Integer, ByVal NGAY As DateTime) As KIEM_KE_Info
            Dim objKIEMKE As New KIEM_KE_Info
            Try
                objKIEMKE = QLBusinessDataController.FillObject(Of KIEM_KE_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_PHIEU_KIEM_KE", MS_KHO, NGAY))
            Catch ex As Exception

            End Try

            Return objKIEMKE
        End Function

        Public Function LOAD_PHIEU_KIEM_KE_CHI_TIET(ByVal MS_KHO As Integer, ByVal NGAY As DateTime, ByVal MS_CLASS As Integer) As DataTable
            Dim dtTable As New DataTable
            Try
                Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_PHIEU_KIEM_KE_VAT_TU_CHI_TIET", MS_KHO, NGAY, MS_CLASS)
                dtTable.Load(dtReader)
                dtReader.Close()
            Catch ex As Exception

            End Try
            Return dtTable
        End Function


        Public Function ADD_KIEM_KE(ByVal MS_KHO As Integer, ByVal NGAY As String, ByVal GIO As String, ByVal dtTable As DataTable) As Boolean
            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Dim SQLString_VI_TRI_KHO As String = ""

            Try
                SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_KIEM_KE", NGAY, MS_KHO, GIO, 0)
                For i As Integer = 0 To dtTable.Rows.Count - 1
                    Dim row As DataRow = dtTable.Rows(i)
                    If Not IsDBNull(row("SL_TON_TT")) And row("SL_TON_TT").ToString <> "" Then
                        Commons.Modules.SQLString = "INSERT INTO KIEM_KE_VAT_TU_CHI_TIET(NGAY,MS_KHO,MS_PT,STT,MS_VI_TRI,MS_DH_NHAP_PT,SL_KK_CT,SL_CHUNG_TU,GHI_CHU, ID_KK) " & _
                               "VALUES(N'" & Format(CDate(NGAY), "dd/MMM/yyyy") & "'," & MS_KHO & ",'" & row("MS_PT").ToString & "'," & i + 1 & "," & _
                        Integer.Parse(row("MS_VI_TRI").ToString) & ",'" & row("MS_DH_NHAP_PT").ToString & "'," & row("SL_TON_TT") & "," & row("SL_TON_CTU").ToString & " ,'" & row("GHI_CHU").ToString & "'," & row("ID_KK").ToString & " )"

                        SQLString_VI_TRI_KHO = "UPDATE VI_TRI_KHO_VAT_TU SET SL_VT = " & row("SL_TON_TT").ToString & _
                                            " WHERE MS_KHO = " & MS_KHO & " AND MS_PT = '" & row("MS_PT").ToString & "' AND MS_VI_TRI = '" & Integer.Parse(row("MS_VI_TRI").ToString) & _
                                            "' AND ID = " + row("ID_KK").ToString + " AND MS_DH_NHAP_PT = '" & row("MS_DH_NHAP_PT").ToString & "'"

                        SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", Commons.Modules.SQLString)
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", SQLString_VI_TRI_KHO)
                    End If
                Next
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return False
            Finally
                objConnection.Close()
            End Try
            Return True
        End Function

        Public Function UPDATE_KIEM_KE(ByVal MS_KHO As Integer, ByVal NGAY As DateTime, ByVal dtTable As DataTable) As Boolean
            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                For i As Integer = 0 To dtTable.Rows.Count - 1
                    Dim row As DataRow = dtTable.Rows(i)
                    ' If Val(row("SL_TON_TT").ToString) > 0 Then
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_KIEM_KE_VAT_TU_CHI_TIET", NGAY, MS_KHO, _
                            row("MS_PT").ToString, Integer.Parse(row("MS_VI_TRI").ToString), _
                            row("MS_DH_NHAP_PT").ToString, Double.Parse(row("SL_TON_TT").ToString), _
                            row("GHI_CHU").ToString, Double.Parse(row("ID_KK").ToString))

                    'If Double.Parse(row("SL_TON_TT").ToString) = 0 Then
                    '    SqlHelper.ExecuteNonQuery(objTrans, "QL_DELETE_ITEM_VI_TRI_KHO_VAT_TU", MS_KHO, row("MS_PT").ToString, Integer.Parse(row("MS_VI_TRI").ToString), row("MS_DH_NHAP_PT").ToString)
                    'Else
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", MS_KHO, _
                            row("MS_PT").ToString, Integer.Parse(row("MS_VI_TRI").ToString), _
                            row("MS_DH_NHAP_PT").ToString, Double.Parse(row("SL_TON_TT").ToString), _
                            Double.Parse(row("ID_KK").ToString))
                    'End If
                    'End If
                Next
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Return False
            Finally
                objConnection.Close()
            End Try
            Return True
        End Function

        Public Function DELETE_KIEM_KE(ByVal MS_KHO As Integer, ByVal NGAY As DateTime) As Boolean
            Try
                SqlHelper.ExecuteNonQuery(connectionString, "QL_DELETE_KIEM_KE", MS_KHO, NGAY)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Function LOCK_PHIEU_KIEM_KE(ByVal MS_KHO As Integer, ByVal NGAY As DateTime) As Boolean
            Try
                SqlHelper.ExecuteNonQuery(connectionString, "QL_LOCK_PHIEU_KIEM_KE", MS_KHO, NGAY)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
    End Class
End Namespace
