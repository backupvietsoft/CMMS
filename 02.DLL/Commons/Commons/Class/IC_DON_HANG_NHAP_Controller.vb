
Imports System.Data
Imports System.Data.SqlClient
Imports Commons.QL.Common.Data
Imports Microsoft.ApplicationBlocks.Data
Namespace VS.Classes.Catalogue

    Public Class IC_DON_HANG_NHAP_Controller
        Private connectionString As String = ""
        Public Sub New()
            connectionString = Commons.IConnections.ConnectionString()
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

        Public Function Load_Ngoai_Te() As String
            Dim Ngoai_Te As String = ""
            Dim dtReaderNT As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_NGOAI_TE")
            While dtReaderNT.Read
                Ngoai_Te = dtReaderNT.Item("NGOAI_TE")
            End While
            dtReaderNT.Close()
            Return Ngoai_Te
        End Function

        Public Function Load_Ty_Gia() As String
            Dim Ty_Gia As String = ""
            Dim dtReaderNT As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_NGOAI_TE")
            While dtReaderNT.Read
                Ty_Gia = dtReaderNT.Item("TI_GIA")
            End While
            dtReaderNT.Close()
            Return Ty_Gia
        End Function
        Public Function Load_Ty_Gia_USD() As String
            Dim Ty_Gia As String = ""
            Dim dtReaderNT As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_NGOAI_TE")
            While dtReaderNT.Read
                Ty_Gia = dtReaderNT.Item("TI_GIA_USD")
            End While
            dtReaderNT.Close()
            Return Ty_Gia
        End Function
        Public Function Load_Ty_Gia_Theo_Ngoai_Te(ByVal NGOAI_TE As String) As String
            Dim Ty_Gia As String = ""
            Dim dtReaderNT As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_TY_GI_THEO_NGOAI_TE", NGOAI_TE)
            While dtReaderNT.Read
                Ty_Gia = dtReaderNT.Item("TI_GIA")
            End While
            dtReaderNT.Close()
            Return Ty_Gia
        End Function
        Public Function Load_Ty_Gia_USD_Theo_Ngoai_Te(ByVal NGOAI_TE As String) As String
            Dim Ty_Gia As String = ""
            Dim dtReaderNT As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_TY_GI_THEO_NGOAI_TE", NGOAI_TE)
            While dtReaderNT.Read
                Ty_Gia = dtReaderNT.Item("TI_GIA_USD")
            End While
            dtReaderNT.Close()
            Return Ty_Gia
        End Function
        Public Function Load_List_Ngoai_Te() As DataTable
            Dim dtTable As New DataTable
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_LIST_NGOAI_TE")
            dtTable.Load(dtReader)
            dtReader.Close()
            Return dtTable
        End Function

        Public Function Load_List_NCC() As DataTable
            Dim dtTable As New DataTable
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "GetMS_VT_NCC")
            dtTable.Load(dtReader)
            dtReader.Close()
            Return dtTable
        End Function

        Public Function Load_Phieu_Nhap(ByVal MS_DH_NHAP_PT As String) As IC_DON_HANG_NHAP_Info
            Dim objDonHangNhapPT As IC_DON_HANG_NHAP_Info = QLBusinessDataController.FillObject(Of IC_DON_HANG_NHAP_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_DON_HANG_NHAP", MS_DH_NHAP_PT))
            Return objDonHangNhapPT
        End Function

        Public Function Load_Phu_Tung(ByVal MS_PT As String) As IC_PHU_TUNG_Info
            Dim objPhuTung As IC_PHU_TUNG_Info = QLBusinessDataController.FillObject(Of IC_PHU_TUNG_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_PHU_TUNG", MS_PT))
            Return objPhuTung
        End Function

        Public Function Load_DON_VI_TINH(ByVal DVT As String) As String
            Dim temp As String = ""
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_DON_VI_TINH", DVT)
            While dtReader.Read
                temp = dtReader.Item(1)
            End While
            Return temp
        End Function

        Public Function Load_Danh_Sach_DH_Nhap(ByVal Query As String) As DataTable
            Dim dtTable As DataTable = New DataTable
            Dim dtReader As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_SEARCH", Query)
            dtTable.Load(dtReader)
            dtReader.Close()
            Return dtTable
        End Function

        Public Function Load_Danh_Sach_DH_Nhap_Vat_Tu(ByVal MS_DH_NHAP_PT As String) As List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
            Dim lstDonHangNhapVT As New List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
            lstDonHangNhapVT = QLBusinessDataController.FillCollection(Of IC_DON_HANG_NHAP_VAT_TU_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_DON_HANG_NHAP_VT", MS_DH_NHAP_PT))
            Return lstDonHangNhapVT
        End Function

        Public Function Load_Danh_Sach_DH_Nhap_Vat_Tu_CT(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String) As List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
            Dim lstDonHangNhapVTCT As New List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
            lstDonHangNhapVTCT = QLBusinessDataController.FillCollection(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_DON_HANG_NHAP_VT_CT_1", MS_DH_NHAP_PT, MS_PT))
            Return lstDonHangNhapVTCT
        End Function

        Public Function Load_Vi_Tri_Kho(ByVal MS_KHO As Integer) As List(Of VI_TRI_KHO_Info)
            Dim lstVi_Tri_Kho As New List(Of VI_TRI_KHO_Info)
            lstVi_Tri_Kho = QLBusinessDataController.FillCollection(Of VI_TRI_KHO_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LIST_VI_TRI_KHO", MS_KHO))
            Return lstVi_Tri_Kho
        End Function

        Public Function Lock_Don_Hang_Nhap(ByVal MS_DH_NHAP_PT As String)
            Try
                SqlHelper.ExecuteNonQuery(connectionString, "QL_LOCK_DON_HANG_NHAP", MS_DH_NHAP_PT)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Function Add_Don_Hang_Nhap(ByVal objDonHangNhapInfo As IC_DON_HANG_NHAP_Info, ByVal lstDonHangNhapVatTu As List(Of IC_DON_HANG_NHAP_VAT_TU_Info), ByVal hasListVTSL As Hashtable) As Boolean

            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                While CHECK_MS_DH_NHAP_EXISTS(objDonHangNhapInfo.MS_DH_NHAP_PT)
                    objDonHangNhapInfo.MS_DH_NHAP_PT = Create_MS_DH_NHAP_PT()
                End While
                'Add Don Hang Nhap VAO IC_DON_HANG_NHAP
                SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP", objDonHangNhapInfo.MS_DH_NHAP_PT, objDonHangNhapInfo.SO_PHIEU_XN, objDonHangNhapInfo.GIO, objDonHangNhapInfo.NGAY, objDonHangNhapInfo.MS_KHO, objDonHangNhapInfo.MS_DANG_NHAP, objDonHangNhapInfo.NGUOI_NHAP, objDonHangNhapInfo.NGAY_CHUNG_TU, objDonHangNhapInfo.SO_CHUNG_TU, objDonHangNhapInfo.DIEM, objDonHangNhapInfo.DANH_GIA, objDonHangNhapInfo.GHI_CHU, objDonHangNhapInfo.LOCK, objDonHangNhapInfo.THU_KHO, objDonHangNhapInfo.MS_DDH, objDonHangNhapInfo.DIEM1, objDonHangNhapInfo.DIEM2)

                'Add Don Hang Nhap Vat Tu Vao IC_DON_HANG_NHAP_VAT_TU
                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1

                    Dim objDonHangNhapVauTu As IC_DON_HANG_NHAP_VAT_TU_Info = lstDonHangNhapVatTu.Item(i)
                    objDonHangNhapVauTu.MS_DH_NHAP_PT = objDonHangNhapInfo.MS_DH_NHAP_PT
                    '----------
                    If objDonHangNhapVauTu.SL_THUC_NHAP <> 0 Then
                        '---------------
                        'ADD DON HANG NHAP VAT TU

                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, Double.Parse(objDonHangNhapVauTu.SO_LUONG_CTU), Double.Parse(objDonHangNhapVauTu.SL_THUC_NHAP), objDonHangNhapVauTu.DON_GIA, objDonHangNhapVauTu.NGOAI_TE, objDonHangNhapVauTu.TY_GIA, objDonHangNhapVauTu.TY_GIA_USD, objDonHangNhapVauTu.MS_VT_NCC, objDonHangNhapVauTu.XUAT_XU, IIf(Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date") = "01/01/0001", DBNull.Value, Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date")), objDonHangNhapVauTu.THANH_TIEN, objDonHangNhapVauTu.GHI_CHU)

                        'CHECK VA ADD DON HANG VAT TU CHI TIET
                        If hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT) IsNot Nothing Then
                            Dim tb As New DataTable()
                            tb = CType(hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT), DataTable)
                            For j As Integer = 0 To tb.Rows.Count - 1
                                If tb.Rows(j).Item("SL_VT").ToString <> "0" Then
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU_CHI_TIET", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), objDonHangNhapVauTu.MS_DH_NHAP_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    'SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_TON_KHO_NHAP", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))
                                End If
                            Next

                        End If
                        '---------
                    End If
                    '--------
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

        Public Function Add_Don_Hang_Nhap_BDL(ByVal objDonHangNhapInfo As IC_DON_HANG_NHAP_Info, ByVal lstDonHangNhapVatTu As List(Of IC_DON_HANG_NHAP_VAT_TU_Info), ByVal hasListVTSL As Hashtable) As Boolean

            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                While CHECK_MS_DH_NHAP_EXISTS(objDonHangNhapInfo.MS_DH_NHAP_PT)
                    objDonHangNhapInfo.MS_DH_NHAP_PT = Create_MS_DH_NHAP_PT()
                End While
                'Add Don Hang Nhap VAO IC_DON_HANG_NHAP
                SqlHelper.ExecuteNonQuery(objTrans, "H_ADD_DON_HANG_NHAP_BDL", objDonHangNhapInfo.MS_DH_NHAP_PT, objDonHangNhapInfo.SO_PHIEU_XN, objDonHangNhapInfo.GIO, objDonHangNhapInfo.NGAY, objDonHangNhapInfo.MS_KHO, objDonHangNhapInfo.MS_DANG_NHAP, objDonHangNhapInfo.NGUOI_NHAP, objDonHangNhapInfo.NGAY_CHUNG_TU, objDonHangNhapInfo.SO_CHUNG_TU, objDonHangNhapInfo.DIEM, objDonHangNhapInfo.DANH_GIA, objDonHangNhapInfo.GHI_CHU, objDonHangNhapInfo.LOCK, objDonHangNhapInfo.THU_KHO, objDonHangNhapInfo.MS_DDH, objDonHangNhapInfo.NGUOI_GIAO, objDonHangNhapInfo.BSXE)

                'Add Don Hang Nhap Vat Tu Vao IC_DON_HANG_NHAP_VAT_TU
                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1

                    Dim objDonHangNhapVauTu As IC_DON_HANG_NHAP_VAT_TU_Info = lstDonHangNhapVatTu.Item(i)
                    objDonHangNhapVauTu.MS_DH_NHAP_PT = objDonHangNhapInfo.MS_DH_NHAP_PT
                    '----------
                    If objDonHangNhapVauTu.SL_THUC_NHAP <> 0 Then
                        '---------------
                        'ADD DON HANG NHAP VAT TU

                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, Double.Parse(objDonHangNhapVauTu.SO_LUONG_CTU), Double.Parse(objDonHangNhapVauTu.SL_THUC_NHAP), objDonHangNhapVauTu.DON_GIA, objDonHangNhapVauTu.NGOAI_TE, objDonHangNhapVauTu.TY_GIA, objDonHangNhapVauTu.TY_GIA_USD, objDonHangNhapVauTu.MS_VT_NCC, objDonHangNhapVauTu.XUAT_XU, IIf(Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date") = "01/01/0001", DBNull.Value, Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date")), objDonHangNhapVauTu.THANH_TIEN, objDonHangNhapVauTu.GHI_CHU)

                        'CHECK VA ADD DON HANG VAT TU CHI TIET
                        If hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT) IsNot Nothing Then
                            Dim tb As New DataTable()
                            tb = CType(hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT), DataTable)
                            For j As Integer = 0 To tb.Rows.Count - 1
                                If tb.Rows(j).Item("SL_VT").ToString <> "0" Then
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU_CHI_TIET", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), objDonHangNhapVauTu.MS_DH_NHAP_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    'SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_TON_KHO_NHAP", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))
                                End If
                            Next

                        End If
                        '---------
                    End If
                    '--------
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

        Public Function Update_Don_Hang_Nhap(ByVal objDonHangNhapInfo As IC_DON_HANG_NHAP_Info, ByVal lstDonHangNhapVatTu As List(Of IC_DON_HANG_NHAP_VAT_TU_Info), ByVal hasListVTSL As Hashtable) As Boolean

            Dim TbKho As DataTable = New DataTable()

            Try
                Dim vstr As String = "Select * from IC_DON_HANG_NHAP_VAT_TU WHERE MS_DH_NHAP_PT = '" & objDonHangNhapInfo.MS_DH_NHAP_PT & "' "
                TbKho.Load(SqlHelper.ExecuteReader(connectionString, CommandType.Text, vstr))
                ' SqlHelper.ExecuteReader(

            Catch ex As Exception

            End Try


            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_DON_HANG_NHAP", objDonHangNhapInfo.MS_DH_NHAP_PT, objDonHangNhapInfo.SO_PHIEU_XN, objDonHangNhapInfo.GIO, objDonHangNhapInfo.NGAY, objDonHangNhapInfo.MS_KHO, objDonHangNhapInfo.MS_DANG_NHAP, objDonHangNhapInfo.NGUOI_NHAP, objDonHangNhapInfo.NGAY_CHUNG_TU, objDonHangNhapInfo.SO_CHUNG_TU, objDonHangNhapInfo.DIEM, objDonHangNhapInfo.DANH_GIA, objDonHangNhapInfo.GHI_CHU, objDonHangNhapInfo.LOCK, objDonHangNhapInfo.THU_KHO, objDonHangNhapInfo.MS_DDH, objDonHangNhapInfo.DIEM1, objDonHangNhapInfo.DIEM2)

                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
                    'ADD DON HANG NHAP VAT TU
                    Dim objDonHangNhapVauTu As IC_DON_HANG_NHAP_VAT_TU_Info = lstDonHangNhapVatTu.Item(i)
                    If objDonHangNhapVauTu.DON_GIA = "" Then
                        objDonHangNhapVauTu.DON_GIA = 0
                    End If

                    Dim slCL As Double = 0

                    'Dim dtTem As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "H_LOAD_DON_HANG_NHAP", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT)
                    'While dtTem.Read
                    '    'Ty_Gia = dtReaderNT.Item("TI_GIA_USD")
                    'End While

                    If objDonHangNhapVauTu.SL_THUC_NHAP <> 0 Then
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, Double.Parse(objDonHangNhapVauTu.SO_LUONG_CTU), Double.Parse(objDonHangNhapVauTu.SL_THUC_NHAP), objDonHangNhapVauTu.DON_GIA, objDonHangNhapVauTu.NGOAI_TE, objDonHangNhapVauTu.TY_GIA, objDonHangNhapVauTu.TY_GIA_USD, objDonHangNhapVauTu.MS_VT_NCC, objDonHangNhapVauTu.XUAT_XU, IIf(Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date") = "01/01/0001", DBNull.Value, Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date")), objDonHangNhapVauTu.THANH_TIEN, objDonHangNhapVauTu.GHI_CHU)

                        If hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT) IsNot Nothing Then
                            Dim tb As New DataTable()
                            tb = CType(hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT), DataTable)
                            For j As Integer = 0 To tb.Rows.Count - 1
                                If tb.Rows(j).Item("SL_VT").ToString <> "" And tb.Rows(j).Item("SL_VT").ToString <> "0" Then
                                    For z As Integer = 0 To tb.Rows.Count - 1
                                        If z <> j Then
                                            If tb.Rows(j).Item("MS_VI_TRI") = tb.Rows(z).Item("MS_VI_TRI") Then
                                                If tb.Rows(z).Item("SL_VT").ToString <> "" Then
                                                    tb.Rows(j).Item("SL_VT") = tb.Rows(j).Item("SL_VT") + tb.Rows(z).Item("SL_VT")
                                                    tb.Rows(z).Item("SL_VT") = 0
                                                End If
                                            End If
                                        End If
                                    Next
                                    If Double.Parse(tb.Rows(j).Item("SL_VT")) > 0 Then
                                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU_CHI_TIET", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    End If
                                    If Double.Parse(tb.Rows(j).Item("SL_VT")) > 0 Then
                                        Dim dsds As Double = Double.Parse(tb.Rows(j).Item("SL_VT"))
                                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), objDonHangNhapVauTu.MS_DH_NHAP_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))

                                    End If

                                    'Try
                                    '    For Each rw As DataRow In TbKho.Rows
                                    '        If rw("MS_PT") = objDonHangNhapVauTu.MS_PT Then
                                    '            If Double.Parse(rw("SL_THUC_NHAP").ToString) > Double.Parse(tb.Rows(j).Item("SL_VT")) Then
                                    '                SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_TON_KHO_XUAT", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, Double.Parse(rw("SL_THUC_NHAP").ToString) - Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    '            Else
                                    '                SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_TON_KHO_NHAP", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, Double.Parse(tb.Rows(j).Item("SL_VT")) - Double.Parse(rw("SL_THUC_NHAP").ToString))
                                    '            End If
                                    '        End If
                                    '    Next
                                    'Catch ex As Exception
                                    'End Try
                                End If
                            Next
                        End If
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

        Public Function Update_Don_Hang_Nhap_BDL(ByVal objDonHangNhapInfo As IC_DON_HANG_NHAP_Info, ByVal lstDonHangNhapVatTu As List(Of IC_DON_HANG_NHAP_VAT_TU_Info), ByVal hasListVTSL As Hashtable) As Boolean

            Dim TbKho As DataTable = New DataTable()

            Try
                Dim vstr As String = "Select * from IC_DON_HANG_NHAP_VAT_TU WHERE MS_DH_NHAP_PT = '" & objDonHangNhapInfo.MS_DH_NHAP_PT & "' "
                TbKho.Load(SqlHelper.ExecuteReader(connectionString, CommandType.Text, vstr))
                ' SqlHelper.ExecuteReader(

            Catch ex As Exception

            End Try


            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_DON_HANG_NHAP_BDL", objDonHangNhapInfo.MS_DH_NHAP_PT, objDonHangNhapInfo.SO_PHIEU_XN, objDonHangNhapInfo.GIO, objDonHangNhapInfo.NGAY, objDonHangNhapInfo.MS_KHO, objDonHangNhapInfo.MS_DANG_NHAP, objDonHangNhapInfo.NGUOI_NHAP, objDonHangNhapInfo.NGAY_CHUNG_TU, objDonHangNhapInfo.SO_CHUNG_TU, objDonHangNhapInfo.DIEM, objDonHangNhapInfo.DANH_GIA, objDonHangNhapInfo.GHI_CHU, objDonHangNhapInfo.LOCK, objDonHangNhapInfo.THU_KHO, objDonHangNhapInfo.MS_DDH, objDonHangNhapInfo.NGUOI_GIAO, objDonHangNhapInfo.BSXE)

                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
                    'ADD DON HANG NHAP VAT TU
                    Dim objDonHangNhapVauTu As IC_DON_HANG_NHAP_VAT_TU_Info = lstDonHangNhapVatTu.Item(i)
                    If objDonHangNhapVauTu.DON_GIA = "" Then
                        objDonHangNhapVauTu.DON_GIA = 0
                    End If

                    Dim slCL As Double = 0

                    'Dim dtTem As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "H_LOAD_DON_HANG_NHAP", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT)
                    'While dtTem.Read
                    '    'Ty_Gia = dtReaderNT.Item("TI_GIA_USD")
                    'End While



                    If objDonHangNhapVauTu.SL_THUC_NHAP <> 0 Then
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, Double.Parse(objDonHangNhapVauTu.SO_LUONG_CTU), Double.Parse(objDonHangNhapVauTu.SL_THUC_NHAP), objDonHangNhapVauTu.DON_GIA, objDonHangNhapVauTu.NGOAI_TE, objDonHangNhapVauTu.TY_GIA, objDonHangNhapVauTu.TY_GIA_USD, objDonHangNhapVauTu.MS_VT_NCC, objDonHangNhapVauTu.XUAT_XU, IIf(Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date") = "01/01/0001", DBNull.Value, Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date")), objDonHangNhapVauTu.THANH_TIEN, objDonHangNhapVauTu.GHI_CHU)

                        If hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT) IsNot Nothing Then
                            Dim tb As New DataTable()
                            tb = CType(hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT), DataTable)
                            For j As Integer = 0 To tb.Rows.Count - 1
                                If tb.Rows(j).Item("SL_VT").ToString <> "" And tb.Rows(j).Item("SL_VT").ToString <> "0" Then
                                    For z As Integer = 0 To tb.Rows.Count - 1
                                        If z <> j Then
                                            If tb.Rows(j).Item("MS_VI_TRI") = tb.Rows(z).Item("MS_VI_TRI") Then
                                                If tb.Rows(z).Item("SL_VT").ToString <> "" Then
                                                    tb.Rows(j).Item("SL_VT") = tb.Rows(j).Item("SL_VT") + tb.Rows(z).Item("SL_VT")
                                                    tb.Rows(z).Item("SL_VT") = 0
                                                End If
                                            End If
                                        End If
                                    Next
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU_CHI_TIET", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), objDonHangNhapVauTu.MS_DH_NHAP_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    'Try
                                    '    For Each rw As DataRow In TbKho.Rows
                                    '        If rw("MS_PT") = objDonHangNhapVauTu.MS_PT Then
                                    '            If Double.Parse(rw("SL_THUC_NHAP").ToString) > Double.Parse(tb.Rows(j).Item("SL_VT")) Then
                                    '                SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_TON_KHO_XUAT", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, Double.Parse(rw("SL_THUC_NHAP").ToString) - Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    '            Else
                                    '                SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_TON_KHO_NHAP", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, Double.Parse(tb.Rows(j).Item("SL_VT")) - Double.Parse(rw("SL_THUC_NHAP").ToString))
                                    '            End If
                                    '        End If
                                    '    Next
                                    'Catch ex As Exception
                                    'End Try
                                End If
                            Next
                        End If
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

        Public Function Add_Don_Hang_Nhap_DXMH(ByVal objDonHangNhapInfo As IC_DON_HANG_NHAP_Info, ByVal lstDonHangNhapVatTu As List(Of IC_DON_HANG_NHAP_VAT_TU_Info), ByVal hasListVTSL As Hashtable) As Boolean

            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                While CHECK_MS_DH_NHAP_EXISTS(objDonHangNhapInfo.MS_DH_NHAP_PT)
                    objDonHangNhapInfo.MS_DH_NHAP_PT = Create_MS_DH_NHAP_PT()
                End While
                'Add Don Hang Nhap VAO IC_DON_HANG_NHAP
                SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_DXMH", objDonHangNhapInfo.MS_DH_NHAP_PT, objDonHangNhapInfo.SO_PHIEU_XN, objDonHangNhapInfo.GIO, objDonHangNhapInfo.NGAY, objDonHangNhapInfo.MS_KHO, objDonHangNhapInfo.MS_DANG_NHAP, objDonHangNhapInfo.NGUOI_NHAP, objDonHangNhapInfo.NGAY_CHUNG_TU, IIf(IsDBNull(objDonHangNhapInfo.SO_CHUNG_TU) Or objDonHangNhapInfo.SO_CHUNG_TU Is Nothing, "", objDonHangNhapInfo.SO_CHUNG_TU), objDonHangNhapInfo.DIEM, objDonHangNhapInfo.DANH_GIA, objDonHangNhapInfo.GHI_CHU, objDonHangNhapInfo.LOCK, objDonHangNhapInfo.THU_KHO, objDonHangNhapInfo.MS_DDH)

                'Add Don Hang Nhap Vat Tu Vao IC_DON_HANG_NHAP_VAT_TU
                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1

                    Dim objDonHangNhapVauTu As IC_DON_HANG_NHAP_VAT_TU_Info = lstDonHangNhapVatTu.Item(i)
                    objDonHangNhapVauTu.MS_DH_NHAP_PT = objDonHangNhapInfo.MS_DH_NHAP_PT
                    '----------
                    If objDonHangNhapVauTu.SL_THUC_NHAP <> 0 Then
                        '---------------
                        'ADD DON HANG NHAP VAT TU

                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, Double.Parse(objDonHangNhapVauTu.SO_LUONG_CTU), Double.Parse(objDonHangNhapVauTu.SL_THUC_NHAP), objDonHangNhapVauTu.DON_GIA, objDonHangNhapVauTu.NGOAI_TE, objDonHangNhapVauTu.TY_GIA, objDonHangNhapVauTu.TY_GIA_USD, objDonHangNhapVauTu.MS_VT_NCC, objDonHangNhapVauTu.XUAT_XU, IIf(Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date") = "01/01/0001", DBNull.Value, Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date")), objDonHangNhapVauTu.THANH_TIEN, objDonHangNhapVauTu.GHI_CHU)

                        'CHECK VA ADD DON HANG VAT TU CHI TIET
                        If hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT) IsNot Nothing Then
                            Dim tb As New DataTable()
                            tb = CType(hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT), DataTable)
                            For j As Integer = 0 To tb.Rows.Count - 1
                                If tb.Rows(j).Item("SL_VT").ToString <> "0" Then
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU_CHI_TIET", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    ' SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), objDonHangNhapVauTu.MS_DH_NHAP_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))
                                End If
                            Next

                        End If
                        '---------
                    End If
                    '--------
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

        Public Function Update_Don_Hang_Nhap_DXMH(ByVal objDonHangNhapInfo As IC_DON_HANG_NHAP_Info, ByVal lstDonHangNhapVatTu As List(Of IC_DON_HANG_NHAP_VAT_TU_Info), ByVal hasListVTSL As Hashtable) As Boolean

            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_DON_HANG_NHAP", objDonHangNhapInfo.MS_DH_NHAP_PT, objDonHangNhapInfo.SO_PHIEU_XN, objDonHangNhapInfo.GIO, objDonHangNhapInfo.NGAY, objDonHangNhapInfo.MS_KHO, objDonHangNhapInfo.MS_DANG_NHAP, objDonHangNhapInfo.NGUOI_NHAP, objDonHangNhapInfo.NGAY_CHUNG_TU, objDonHangNhapInfo.SO_CHUNG_TU, objDonHangNhapInfo.DIEM, objDonHangNhapInfo.DANH_GIA, objDonHangNhapInfo.GHI_CHU, objDonHangNhapInfo.LOCK, objDonHangNhapInfo.THU_KHO, objDonHangNhapInfo.MS_DDH)

                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
                    'ADD DON HANG NHAP VAT TU
                    Dim objDonHangNhapVauTu As IC_DON_HANG_NHAP_VAT_TU_Info = lstDonHangNhapVatTu.Item(i)
                    If objDonHangNhapVauTu.DON_GIA = "" Then
                        objDonHangNhapVauTu.DON_GIA = 0
                    End If
                    If objDonHangNhapVauTu.SL_THUC_NHAP <> 0 Then
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, Double.Parse(objDonHangNhapVauTu.SO_LUONG_CTU), Double.Parse(objDonHangNhapVauTu.SL_THUC_NHAP), objDonHangNhapVauTu.DON_GIA, objDonHangNhapVauTu.NGOAI_TE, objDonHangNhapVauTu.TY_GIA, objDonHangNhapVauTu.TY_GIA_USD, objDonHangNhapVauTu.MS_VT_NCC, objDonHangNhapVauTu.XUAT_XU, IIf(Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date") = "01/01/0001", DBNull.Value, Format(objDonHangNhapVauTu.BAO_HANH_DEN_NGAY, "short date")), objDonHangNhapVauTu.THANH_TIEN, objDonHangNhapVauTu.GHI_CHU)

                        If hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT) IsNot Nothing Then
                            Dim tb As New DataTable()
                            tb = CType(hasListVTSL.Item(lstDonHangNhapVatTu.Item(i).MS_PT), DataTable)
                            For j As Integer = 0 To tb.Rows.Count - 1
                                If tb.Rows(j).Item("SL_VT").ToString <> "" And tb.Rows(j).Item("SL_VT").ToString <> "0" Then
                                    For z As Integer = 0 To tb.Rows.Count - 1
                                        If z <> j Then
                                            If tb.Rows(j).Item("MS_VI_TRI") = tb.Rows(z).Item("MS_VI_TRI") Then
                                                If tb.Rows(z).Item("SL_VT").ToString <> "" Then
                                                    tb.Rows(j).Item("SL_VT") = tb.Rows(j).Item("SL_VT") + tb.Rows(z).Item("SL_VT")
                                                    tb.Rows(z).Item("SL_VT") = 0
                                                End If
                                            End If
                                        End If
                                    Next
                                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_NHAP_VAT_TU_CHI_TIET", objDonHangNhapVauTu.MS_DH_NHAP_PT, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), Double.Parse(tb.Rows(j).Item("SL_VT")))
                                    'SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objDonHangNhapInfo.MS_KHO, objDonHangNhapVauTu.MS_PT, tb.Rows(j).Item("MS_VI_TRI"), objDonHangNhapVauTu.MS_DH_NHAP_PT, Double.Parse(tb.Rows(j).Item("SL_VT")))
                                End If
                            Next
                        End If
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

        Public Function Delete_Don_Hang_Nhap(ByVal MS_DH_NHAP_PT As String) As Boolean
            Try
                SqlHelper.ExecuteNonQuery(connectionString, "QL_DELETE_DON_HANG_NHAP", MS_DH_NHAP_PT)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Function CHECK_MS_DH_NHAP_EXISTS(ByVal MS_DH_NHAP_PT As String) As Boolean
            Dim dtReaderCheck As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_MS_DH_NHAP_PT_EXISTS", MS_DH_NHAP_PT)
            Dim FLAG As Boolean = False
            While dtReaderCheck.Read
                FLAG = True
            End While
            dtReaderCheck.Close()
            Return FLAG
        End Function

        Public Function CHECK_MS_DH_NHAP_VAT_TU(ByVal MS_DH_NHAP_PT As String, ByVal MS_PT As String) As Boolean
            Dim dtReaderCheck As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_DON_HANG_NHAP_VAT_TU", MS_DH_NHAP_PT, MS_PT)
            Dim FLAG As Boolean = False
            While dtReaderCheck.Read
                FLAG = True
            End While
            dtReaderCheck.Close()
            Return FLAG
        End Function

        Public Function Create_MS_DH_NHAP_PT() As String
            Dim MS_DH_NHAP_PT As String = ""
            Dim temp As String = ""
            Dim param As String = "/"
            If Now.Month < 10 Then
                param += "0" + Now.Month.ToString + "/"
            Else
                param += Now.Month.ToString + "/"
            End If
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_MAX_MSDH_NHAP_PT", param)
            While (dtReader.Read)
                temp = dtReader(0).ToString
            End While
            dtReader.Close()
            If temp.ToString.Length > 5 Then
                Dim temp1 As String = temp.Substring(6, 2)
                Dim month = Integer.Parse(temp1)
                If month <> Now.Month Then
                    MS_DH_NHAP_PT = New_MS_DH_NHAP_PT()
                Else
                    temp1 = temp.Substring(2, 3)
                    Dim SrNo As Integer = Integer.Parse(temp1) + 1
                    If SrNo < 10 Then
                        MS_DH_NHAP_PT += "N-00" + SrNo.ToString
                    ElseIf SrNo < 100 Then
                        MS_DH_NHAP_PT += "N-0" + SrNo.ToString
                    Else
                        MS_DH_NHAP_PT += "N-" + SrNo.ToString
                    End If
                    MS_DH_NHAP_PT += temp.Substring(5, 8)

                End If
            Else
                MS_DH_NHAP_PT = New_MS_DH_NHAP_PT()
            End If
            Return MS_DH_NHAP_PT

        End Function

        Private Function New_MS_DH_NHAP_PT() As String
            Dim MS_DH_NHAP_PT As String = "N-001/"
            If Now.Month > 9 Then
                MS_DH_NHAP_PT += Now.Month.ToString
            Else
                MS_DH_NHAP_PT += "0" + Now.Month.ToString
            End If
            MS_DH_NHAP_PT += "/" + Now.Year.ToString
            Return MS_DH_NHAP_PT
        End Function

        Public Function CHECK_SO_PHIEU_NHAP_EXISTS(ByVal SO_PHIEU_XN As String, ByVal MS_DH_NHAP_PT As String, ByVal ACTION As Boolean) As Boolean
            Dim Flag As Boolean = False
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_SO_PHIEU_NHAP_EXISTS", SO_PHIEU_XN)
            While dtReader.Read
                If ACTION Then
                    Flag = True
                    Exit While
                Else
                    If Not dtReader.Item("MS_DH_NHAP_PT").ToString.Equals(MS_DH_NHAP_PT) Then
                        Flag = True
                        Exit While
                    End If
                End If
            End While
            dtReader.Close()
            Return Flag
        End Function

        Public Function CHECK_SO_CHUNG_TU_EXISTS(ByVal SO_CHUNG_TU As String, ByVal MS_DH_NHAP_PT As String, ByVal ACTION As Boolean) As Boolean
            Dim Flag As Boolean = False
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_SO_CHUNG_TU_EXISTS", SO_CHUNG_TU)
            While dtReader.Read
                If ACTION Then
                    Flag = True
                    Exit While
                Else
                    If Not dtReader.Item("MS_DH_NHAP_PT").ToString.Equals(MS_DH_NHAP_PT) Then
                        Flag = True
                        Exit While
                    End If
                End If
            End While
            dtReader.Close()
            Return Flag
        End Function

    End Class
End Namespace