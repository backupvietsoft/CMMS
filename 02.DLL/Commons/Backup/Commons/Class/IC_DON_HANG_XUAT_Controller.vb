Imports System.Data
Imports System.Data.SqlClient
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Common.Data
Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class IC_DON_HANG_XUAT_Controller

        Private connectionString As String
        Public Sub New()
            connectionString = Commons.IConnections.ConnectionString
        End Sub

        Public Function Load_Authorized_User_Form(ByVal Form_Name As String) As String
            Dim dtReaderUserForm As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_USER_FORM", Commons.Modules.UserName, Form_Name)
            Dim authorized As String = ""
            While dtReaderUserForm.Read
                authorized = dtReaderUserForm.Item("QUYEN").ToString
            End While
            dtReaderUserForm.Close()
            Return authorized
        End Function

        Public Function Load_Danh_Sach_DH_XUAT(ByVal Query As String) As DataTable
            Dim dtTable As DataTable = New DataTable
            Dim dtReader As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_SEARCH", Query)
            dtTable.Load(dtReader)
            dtReader.Close()
            Return dtTable
        End Function

        Public Function Load_Don_Hang_Xuat(ByVal MS_DH_XUAT_PT As String) As IC_DON_HANG_XUAT_Info
            Dim objDHXVT As New IC_DON_HANG_XUAT_Info
            objDHXVT = QLBusinessDataController.FillObject(Of IC_DON_HANG_XUAT_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_DON_HANG_XUAT", MS_DH_XUAT_PT))
            Return objDHXVT
        End Function

        Public Function Load_Don_Hang_Xuat_Vat_Tu(ByVal MS_DH_XUAT_PT As String) As List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
            Dim lstTemp As New List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
            lstTemp = QLBusinessDataController.FillCollection(Of IC_DON_HANG_XUAT_VAT_TU_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_LIST_DH_XUAT_VAT_TU", MS_DH_XUAT_PT))
            Return lstTemp
        End Function

        Public Function Load_Don_Hang_Xuat_Vat_Tu_Chi_Tiet(ByVal MS_KHO As Integer, ByVal MS_DH_XUAT_PT As String, ByVal MS_PT As String) As List(Of CHI_TIET_VAT_TU_XUAT_Info)
            Dim lstDHXVTCT As New List(Of CHI_TIET_VAT_TU_XUAT_Info)
            lstDHXVTCT = QLBusinessDataController.FillCollection(Of CHI_TIET_VAT_TU_XUAT_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_LIST_DH_XUAT_VAT_TU_CHI_TIET", MS_DH_XUAT_PT, MS_PT))
            If lstDHXVTCT IsNot Nothing Then
                Dim dtReader As SqlDataReader
                For i As Integer = 0 To lstDHXVTCT.Count - 1
                    dtReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_VI_TRI_KHO_VAT_TU", MS_KHO, _
                        lstDHXVTCT.Item(i).MS_PT, lstDHXVTCT.Item(i).MS_VI_TRI, _
                        lstDHXVTCT.Item(i).MS_DH_NHAP_PT, lstDHXVTCT.Item(i).ID_XUAT)
                    While dtReader.Read
                        lstDHXVTCT.Item(i).SL_VT = Double.Parse(dtReader.Item("SL_VT").ToString) + lstDHXVTCT.Item(i).SL_VT
                    End While
                Next
            Else
                Return New List(Of CHI_TIET_VAT_TU_XUAT_Info)
            End If
            Return lstDHXVTCT
        End Function

        Public Function LOAD_LIST_DON_HANG_NHAP_VAT_TU_UNLOCK() As List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
            Dim lstDHNVATTU As New List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
            Try
                lstDHNVATTU = QLBusinessDataController.FillCollection(Of IC_DON_HANG_NHAP_VAT_TU_Info)(SqlHelper.ExecuteReader(connectionString, "QL_LOAD_LIST_DON_HANG_NHAP_VAT_TU_UNLOCK"))
            Catch ex As Exception
                Return New List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
            End Try
            Return lstDHNVATTU
        End Function

        Public Function LOAD_LIST_DON_HANG_XUAT_TU_UNLOCK_KHAC_PHIEU_XUAT_CHON(ByVal MS_DH_XUAT_PT As String, ByVal MS_KHO As Integer) As List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
            ' tam thoi de loi (vi khong bik ly do) de return ve 1 list moi, 
            Dim lstDHXVATTU As New List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
            Try
                lstDHXVATTU = QLBusinessDataController.FillCollection(Of IC_DON_HANG_XUAT_VAT_TU_Info)(SqlHelper.ExecuteReader(connectionString, _
                    "QL_LOAD_LIST_DON_HANG_XUAT_VAT_TU_UNLOCK", MS_DH_XUAT_PT))
            Catch ex As Exception
                Return New List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
            End Try
            Return lstDHXVATTU
        End Function

        Public Function Create_MS_DH_XUAT_PT() As String
            Dim MS_DH_XUAT_PT As String = ""
            Dim temp As String = ""
            Dim param As String = "/"
            If Now.Month < 10 Then
                param += "0" + Now.Month.ToString + "/"
            Else
                param += Now.Month.ToString + "/"
            End If
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_LOAD_MAX_MSDH_XUAT_PT", param)
            While (dtReader.Read)
                temp = dtReader(0).ToString
            End While

            If temp.ToString.Length > 5 Then
                Dim temp1 As String = temp.Substring(6, 2)
                Dim month = Integer.Parse(temp1)
                If month <> Now.Month Then
                    MS_DH_XUAT_PT = New_MS_DH_XUAT_PT()
                Else
                    temp1 = temp.Substring(2, 3)
                    Dim SrNo As Integer = Integer.Parse(temp1) + 1
                    If SrNo < 10 Then
                        MS_DH_XUAT_PT += "X-00" + SrNo.ToString
                    ElseIf SrNo < 100 Then
                        MS_DH_XUAT_PT += "X-0" + SrNo.ToString
                    Else
                        MS_DH_XUAT_PT += "X-" + SrNo.ToString
                    End If
                    MS_DH_XUAT_PT += temp.Substring(5, 8)

                End If
            Else
                MS_DH_XUAT_PT = New_MS_DH_XUAT_PT()
            End If
            Return MS_DH_XUAT_PT

        End Function
        Private Function New_MS_DH_XUAT_PT() As String
            Dim MS_DH_NHAP_PT As String = "X-001/"
            If Now.Month > 9 Then
                MS_DH_NHAP_PT += Now.Month.ToString
            Else
                MS_DH_NHAP_PT += "0" + Now.Month.ToString
            End If
            MS_DH_NHAP_PT += "/" + Now.Year.ToString
            Return MS_DH_NHAP_PT
        End Function

        Public Function CHECK_SO_PHIEU_XUAT_EXISTS(ByVal SO_PHIEU_XUAT As String, ByVal MS_DH_XUAT_PT As String, ByVal ACTION As Boolean) As Boolean
            Dim Flag As Boolean = False
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_SO_PHIEU_XUAT_EXISTS", SO_PHIEU_XUAT)
            While dtReader.Read
                If ACTION Then
                    Flag = True
                    Exit While
                Else
                    If Not dtReader.Item("MS_DH_XUAT_PT").ToString.Equals(MS_DH_XUAT_PT) Then
                        Flag = True
                        Exit While
                    End If
                End If
            End While
            dtReader.Close()
            Return Flag
        End Function

        Public Function CHECK_SO_CHUNG_TU_EXISTS(ByVal SO_CHUNG_TU As String, ByVal MS_DH_XUAT_PT As String, ByVal ACTION As Boolean) As Boolean
            Dim Flag As Boolean = False
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_SO_CHUNG_TU_XUAT_EXISTS", SO_CHUNG_TU)
            While dtReader.Read
                If ACTION Then
                    Flag = True
                    Exit While
                Else
                    If Not dtReader.Item("MS_DH_XUAT_PT").ToString.Equals(MS_DH_XUAT_PT) Then
                        Flag = True
                        Exit While
                    End If
                End If
            End While
            dtReader.Close()
            Return Flag
        End Function

        Private Function CHECK_MS_DH_XUAT_EXISTS(ByVal MS_DH_XUAT_PT As String) As Boolean
            Dim Flag As Boolean = False
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "QL_CHECK_MS_DH_XUAT_PT_EXISTS", MS_DH_XUAT_PT)
            While dtReader.Read
                Flag = True
                Exit While
            End While
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

        Public Function LOCK_DON_HANG_XUAT(ByVal MS_DH_XUAT_PT As String) As Boolean
            Dim objConnection As New SqlConnection(connectionString)
            Dim sl_ton As Decimal? = 0
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                SqlHelper.ExecuteNonQuery(objTrans, "QL_LOCK_DON_HANG_XUAT", MS_DH_XUAT_PT)

                'thuc hien voi nhung cong ty co day du lieu ra 
                If Commons.Modules.iTRFData = 1 Then
                    If TRFNhapKho(objTrans, MS_DH_XUAT_PT, 1) = False Then
                        objTrans.Rollback()
                        Return False
                    End If
                End If

                objTrans.Commit()
            Catch ex As Exception
                objTrans.Rollback()
                Return False
            Finally
                objConnection.Close()
            End Try
            Return True
        End Function
        'Thêm thông tin đơn hàng xuất ChangShin
        Public Function ADD_DON_HANG_XUAT_CS(ByVal objDonHangXuat As IC_DON_HANG_XUAT_Info, ByVal lstDHXVT As List(Of IC_DON_HANG_XUAT_VAT_TU_Info), ByVal hasDataCTXuatVT As Hashtable) As Boolean
            Dim objConnection As New SqlConnection(connectionString)
            Dim sl_ton As Decimal? = 0
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                While CHECK_MS_DH_XUAT_EXISTS(objDonHangXuat.MS_DH_XUAT_PT)
                    objDonHangXuat.MS_DH_XUAT_PT = Me.Create_MS_DH_XUAT_PT
                End While

                If objDonHangXuat.MS_DANG_XUAT = 9 Then
                    objDonHangXuat.LOCK = True
                End If

                'ADD DON HANG XUAT
                SqlHelper.ExecuteNonQuery(objTrans, "H_QL_ADD_DON_HANG_XUAT_CS", objDonHangXuat.MS_DH_XUAT_PT, _
                    objDonHangXuat.SO_PHIEU_XN, objDonHangXuat.GIO, objDonHangXuat.NGAY, objDonHangXuat.MS_KHO, _
                    objDonHangXuat.MS_DANG_XUAT, objDonHangXuat.NGUOI_NHAN, objDonHangXuat.NGAY_CHUNG_TU, _
                    objDonHangXuat.SO_CHUNG_TU, objDonHangXuat.MS_PHIEU_BAO_TRI, objDonHangXuat.GHI_CHU, _
                    objDonHangXuat.LOCK, objDonHangXuat.LY_DO_XUAT, objDonHangXuat.THU_KHO, _
                    IIf(objDonHangXuat.MS_BP_CHIU_PHI <> 0, objDonHangXuat.MS_BP_CHIU_PHI, DBNull.Value), _
                    objDonHangXuat.NGUOI_LAP, objDonHangXuat.CAN_CU, objDonHangXuat.THU_KHO_KY, objDonHangXuat.MS_KHO_DEN, _
                    objDonHangXuat.MS_MAY, objDonHangXuat.MS_LY_DO_XUAT_KT, objDonHangXuat.MS_KH_NHAN)
                For i As Integer = 0 To lstDHXVT.Count - 1
                    'ADD DON HANG XUAT VAT TU
                    Dim objDHXVT As IC_DON_HANG_XUAT_VAT_TU_Info = lstDHXVT.Item(i)
                    objDHXVT.MS_DH_XUAT_PT = objDonHangXuat.MS_DH_XUAT_PT
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_XUAT_VAT_TU", objDHXVT.MS_DH_XUAT_PT, objDHXVT.MS_PT, _
                            objDHXVT.SO_LUONG_CTU, objDHXVT.SO_LUONG_THUC_XUAT, objDHXVT.GHI_CHU, objDHXVT.TG_PB)

                    If hasDataCTXuatVT.Item(objDHXVT.MS_PT) IsNot Nothing Then
                        Dim lstDHX_VTCT As List(Of CHI_TIET_VAT_TU_XUAT_Info) = CType(hasDataCTXuatVT.Item(objDHXVT.MS_PT), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                        For j As Integer = 0 To lstDHX_VTCT.Count - 1
                            Dim objDHX_VTCT As CHI_TIET_VAT_TU_XUAT_Info = lstDHX_VTCT.Item(j)
                            If objDHX_VTCT.SL_XUAT <> "" And objDHX_VTCT.SL_XUAT <> "0" Then
                                Dim objDHXVTCT As New IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info
                                objDHXVTCT.MS_DH_XUAT_PT = objDonHangXuat.MS_DH_XUAT_PT
                                objDHXVTCT.MS_DH_NHAP_PT = objDHX_VTCT.MS_DH_NHAP_PT
                                objDHXVTCT.MS_PT = objDHX_VTCT.MS_PT
                                objDHXVTCT.MS_VI_TRI = objDHX_VTCT.MS_VI_TRI
                                objDHXVTCT.ID_XUAT = objDHX_VTCT.ID_XUAT
                                objDHXVTCT.SL_VT = objDHX_VTCT.SL_XUAT
                                objDHXVTCT.STT = j + 1
                                'ADD DON HANG XUAT VAT TU CHI 
                                SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_XUAT_VAT_TU_CHI_TIET", objDHXVTCT.MS_DH_XUAT_PT, _
                                    objDHXVTCT.MS_PT, objDHXVTCT.STT, objDHXVTCT.MS_DH_NHAP_PT, objDHXVTCT.MS_VI_TRI, _
                                    Double.Parse(objDHXVTCT.SL_VT), Double.Parse(objDHXVTCT.ID_XUAT))

                                Dim objVTKHO_VTU As New VI_TRI_KHO_VAT_TU_Info
                                objVTKHO_VTU.MS_DH_NHAP_PT = objDHXVTCT.MS_DH_NHAP_PT
                                objVTKHO_VTU.MS_PT = objDHXVTCT.MS_PT
                                objVTKHO_VTU.MS_VI_TRI = objDHXVTCT.MS_VI_TRI
                                objVTKHO_VTU.ID = objDHXVTCT.ID_XUAT
                                objVTKHO_VTU.MS_KHO = objDonHangXuat.MS_KHO

                                sl_ton = SqlHelper.ExecuteScalar(objTrans, "SP_NHU_Y_GET_SO_LUONG_TON_OLD", _
                                    objDHXVTCT.MS_DH_NHAP_PT, objDHXVTCT.MS_VI_TRI, objDHXVTCT.MS_PT, _
                                    objDHXVTCT.ID_XUAT)
                                objVTKHO_VTU.SL_VT = sl_ton - objDHX_VTCT.SL_XUAT
                                If objVTKHO_VTU.SL_VT < 0 Then
                                    objTrans.Rollback()
                                    Return False
                                End If
                                SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", _
                                    objVTKHO_VTU.MS_KHO, objVTKHO_VTU.MS_PT, objVTKHO_VTU.MS_VI_TRI, _
                                    objVTKHO_VTU.MS_DH_NHAP_PT, objVTKHO_VTU.SL_VT, objVTKHO_VTU.ID)
                            End If
                        Next
                    End If
                Next

                ' THEM DON HANG NHAP KHI DANG XUAT LA CHUYEN KHO
                If objDonHangXuat.MS_DANG_XUAT = 9 Then
                    Dim _MS_DH_NHAP_PT_AUTO As String = ""
                    _MS_DH_NHAP_PT_AUTO = OSystems.VSGetID("PN", objDonHangXuat.NGAY)

                    SqlHelper.ExecuteNonQuery(objTrans, "AddDonhangNhapTuDonHangXuat", objDonHangXuat.MS_DH_XUAT_PT, _MS_DH_NHAP_PT_AUTO)
                    Dim dttmp = New DataTable
                    If Commons.Modules.iTRFData = 1 Then dttmp.Load(SqlHelper.ExecuteReader(objTrans, "spTRFNhapKho", _MS_DH_NHAP_PT_AUTO, -1))
                    If dttmp.Rows.Count > 0 Then
                        MsgBox(dttmp.Rows(0)(3).ToString() + vbCrLf + dttmp.Rows(0)(5).ToString())
                        objTrans.Rollback()
                        Return False
                    End If
                End If

                If objDonHangXuat.MS_DANG_XUAT = 8 And objDonHangXuat.MS_MAY <> "" Then
                    Try
                        Dim STT As Integer
                        Dim TongTien As Double = 0
                        STT = SqlHelper.ExecuteScalar(objTrans, "AddCONG_VIEC_HANG_NGAY", Format(objDonHangXuat.NGAY, "Short date"), "", Commons.Modules.UserName)
                        Dim Str As String = " SELECT    SUM(ISNULL(A.SL_VT,0) *  ISNULL(C.DON_GIA,0) *  ISNULL(C.TY_GIA,0)) AS TT " & _
                                    " FROM dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS A INNER JOIN dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS B ON  " & _
                                    " A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT AND A.ID_XUAT = B.ID AND A.MS_VI_TRI = B.MS_VI_TRI AND A.MS_PT = B.MS_PT INNER JOIN " & _
                                    " dbo.IC_DON_HANG_NHAP_VAT_TU AS C ON B.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT AND B.MS_PT = C.MS_PT AND B.ID = C.ID " & _
                                    " WHERE MS_DH_XUAT_PT = '" & objDonHangXuat.MS_DH_XUAT_PT & "' "
                        TongTien = Double.Parse(SqlHelper.ExecuteScalar(objTrans, CommandType.Text, Str))
                        SqlHelper.ExecuteNonQuery(objTrans, "AddCONG_VIEC_HANG_NGAY_THIET_BI", STT, objDonHangXuat.MS_MAY, "", -1, TongTien)


                        Str = " INSERT INTO CONG_VIEC_HANG_NGAY_VT(STT_CV,MS_PT, MS_DH_XUAT_PT, MS_DH_NHAP_PT,SO_LUONG,ID) " & _
                                    " SELECT  " & STT.ToString & "  ,  MS_PT, MS_DH_XUAT_PT, MS_DH_NHAP_PT, SUM(SL_VT) AS SL_VT, ID_XUAT " & _
                                    " FROM dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET " & _
                                    " WHERE MS_DH_XUAT_PT = '" & objDonHangXuat.MS_DH_XUAT_PT & "' " & _
                                    " GROUP BY MS_PT, MS_DH_XUAT_PT, MS_DH_NHAP_PT, ID_XUAT "
                        SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Str)

                        Str = " INSERT INTO CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT " & _
                                    " (STT_CV, MS_MAY, MS_PT, SO_LUONG, DON_GIA, THANH_TIEN, MS_DH_XUAT_PT, MS_DH_NHAP_PT, ID) " & _
                                    " SELECT  " & STT.ToString & " , '" & objDonHangXuat.MS_MAY & "' ,A.MS_PT,A.SL_VT,C.DON_GIA,  " & _
                                    " ISNULL(A.SL_VT, 0) * ISNULL(C.DON_GIA, 0) * ISNULL(C.TY_GIA, 0) AS TT, A.MS_DH_XUAT_PT, A.MS_DH_NHAP_PT, A.ID_XUAT " & _
                                    " FROM         dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS A INNER JOIN " & _
                                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET AS B ON A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT AND A.ID_XUAT = B.ID  " & _
                                    " AND A.MS_VI_TRI = B.MS_VI_TRI AND A.MS_PT = B.MS_PT INNER JOIN " & _
                                    " dbo.IC_DON_HANG_NHAP_VAT_TU AS C ON B.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT AND B.MS_PT = C.MS_PT AND B.ID = C.ID " & _
                                    " WHERE     (A.MS_DH_XUAT_PT = '" & objDonHangXuat.MS_DH_XUAT_PT & "') "
                        SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Str)

                    Catch ex As Exception

                    End Try
                End If

                'thuc hien voi nhung cong ty co day du lieu ra 
                If Commons.Modules.iTRFData = 1 Then
                    If TRFNhapKho(objTrans, objDonHangXuat.MS_DH_XUAT_PT, -1) = False Then
                        objTrans.Rollback()
                        Return False
                    End If
                End If
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

        Public Function TRFNhapKho(ByVal objTrans As SqlTransaction, ByVal DHX As String, ByVal TrangThai As Integer)
            Try
                Dim dttmp = New DataTable
                dttmp.Load(SqlHelper.ExecuteReader(objTrans, "spTRFXuatKho", DHX, TrangThai))
                If dttmp.Rows.Count > 0 Then
                    'Dim myHost As String = System.Net.Dns.GetHostName
                    If System.Net.Dns.GetHostName.ToUpper().ToString() = "mashilove".ToUpper.ToString() Then Return True
                    MsgBox(dttmp.Rows(0)(3).ToString() + vbCrLf + dttmp.Rows(0)(5).ToString())
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        'Update đơn hàng Xuất ChangShin
        Public Function UPDATE_DON_HANG_XUAT_CS(ByVal objDonHangXuat As IC_DON_HANG_XUAT_Info, ByVal lstDHXVT As List(Of IC_DON_HANG_XUAT_VAT_TU_Info), ByVal hasDataCTXuatVT As Hashtable) As Boolean

            Dim TbKho As DataTable = New DataTable()
            Dim sl_ton As Decimal? = 0
            Try
                Dim vstr As String = "Select * from IC_DON_HANG_XUAT_VAT_TU WHERE MS_DH_XUAT_PT = '" & objDonHangXuat.MS_DH_XUAT_PT & "' "
                TbKho.Load(SqlHelper.ExecuteReader(connectionString, CommandType.Text, vstr))
            Catch ex As Exception

            End Try

            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Dim Flag As Boolean = True
            Try
                'UPDATE DON HANG XUAT
                SqlHelper.ExecuteNonQuery(objTrans, "H_QL_UPDATE_DON_HANG_XUAT_CS", objDonHangXuat.MS_DH_XUAT_PT, _
                    objDonHangXuat.SO_PHIEU_XN, objDonHangXuat.GIO, objDonHangXuat.NGAY, objDonHangXuat.MS_KHO, _
                    objDonHangXuat.MS_DANG_XUAT, objDonHangXuat.NGUOI_NHAN, objDonHangXuat.NGAY_CHUNG_TU, _
                    objDonHangXuat.SO_CHUNG_TU, objDonHangXuat.MS_PHIEU_BAO_TRI, objDonHangXuat.GHI_CHU, _
                    objDonHangXuat.LOCK, objDonHangXuat.LY_DO_XUAT, objDonHangXuat.THU_KHO, _
                    IIf(objDonHangXuat.MS_BP_CHIU_PHI <> 0, objDonHangXuat.MS_BP_CHIU_PHI, DBNull.Value), _
                    objDonHangXuat.NGUOI_LAP, objDonHangXuat.CAN_CU, objDonHangXuat.THU_KHO_KY, objDonHangXuat.MS_KHO_DEN, _
                    objDonHangXuat.MS_MAY, objDonHangXuat.MS_LY_DO_XUAT_KT, objDonHangXuat.MS_KH_NHAN)

                'LOAD DANG SACH DON HANG XUAT VAT TU CHI TIET
                Dim lstDHXVTCTIET As List(Of IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info) = QLBusinessDataController.FillCollection(Of IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info)(SqlHelper.ExecuteReader(objTrans, "QL_LOAD_DON_HANG_XUAT_VAT_TU_CHI_TIET_THEO_DH_XUAT", objDonHangXuat.MS_DH_XUAT_PT))
                For i As Integer = 0 To lstDHXVTCTIET.Count - 1
                    Dim objVTKHOVATTU As New VI_TRI_KHO_VAT_TU_Info
                    objVTKHOVATTU.MS_DH_NHAP_PT = lstDHXVTCTIET.Item(i).MS_DH_NHAP_PT
                    objVTKHOVATTU.MS_PT = lstDHXVTCTIET.Item(i).MS_PT
                    objVTKHOVATTU.MS_VI_TRI = lstDHXVTCTIET.Item(i).MS_VI_TRI
                    objVTKHOVATTU.ID = lstDHXVTCTIET.Item(i).ID_XUAT
                    objVTKHOVATTU.SL_VT = Double.Parse(lstDHXVTCTIET.Item(i).SL_VT)
                    objVTKHOVATTU.MS_KHO = objDonHangXuat.MS_KHO

                    Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(objTrans, "QL_LOAD_VI_TRI_KHO_VAT_TU", _
                        objVTKHOVATTU.MS_KHO, objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI, _
                        objVTKHOVATTU.MS_DH_NHAP_PT, objVTKHOVATTU.ID)
                    Dim tempFlag As Boolean = True
                    While dtReader.Read
                        tempFlag = False
                        objVTKHOVATTU.SL_VT = objVTKHOVATTU.SL_VT + Double.Parse(dtReader.Item("SL_VT").ToString)
                        Exit While
                    End While
                    dtReader.Close()

                    If tempFlag Then
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objVTKHOVATTU.MS_KHO, _
                            objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI, objVTKHOVATTU.MS_DH_NHAP_PT, _
                            objVTKHOVATTU.SL_VT, objVTKHOVATTU.ID)
                    Else
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", objVTKHOVATTU.MS_KHO, _
                            objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI, objVTKHOVATTU.MS_DH_NHAP_PT, _
                            objVTKHOVATTU.SL_VT, objVTKHOVATTU.ID)
                    End If
                Next
                'DELETE DON HANG NHAP VAT TU 
                SqlHelper.ExecuteNonQuery(objTrans, "QL_DELETE_DON_HANG_XUAT_VAT_TU", objDonHangXuat.MS_DH_XUAT_PT)
                For i As Integer = 0 To lstDHXVT.Count - 1

                    Dim MS_KHO As String = ""
                    Dim objDHXVT As IC_DON_HANG_XUAT_VAT_TU_Info = lstDHXVT.Item(i)
                    objDHXVT.MS_DH_XUAT_PT = objDonHangXuat.MS_DH_XUAT_PT
                    'ADD DON HANG NHAP VAT TU
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_XUAT_VAT_TU", objDHXVT.MS_DH_XUAT_PT, _
                        objDHXVT.MS_PT, objDHXVT.SO_LUONG_CTU, objDHXVT.SO_LUONG_THUC_XUAT, objDHXVT.GHI_CHU, objDHXVT.TG_PB)

                    If hasDataCTXuatVT.Item(objDHXVT.MS_PT) IsNot Nothing Then
                        Dim lstDHX_VTCT As List(Of CHI_TIET_VAT_TU_XUAT_Info) = CType(hasDataCTXuatVT.Item(objDHXVT.MS_PT), List(Of CHI_TIET_VAT_TU_XUAT_Info))
                        For j As Integer = 0 To lstDHX_VTCT.Count - 1
                            Dim objDHX_VTCT As CHI_TIET_VAT_TU_XUAT_Info = lstDHX_VTCT.Item(j)
                            If objDHX_VTCT.SL_VT > 0 Then
                                Dim objDHXVTCT As New IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info
                                objDHXVTCT.MS_DH_XUAT_PT = objDonHangXuat.MS_DH_XUAT_PT
                                objDHXVTCT.MS_DH_NHAP_PT = objDHX_VTCT.MS_DH_NHAP_PT
                                objDHXVTCT.MS_PT = objDHX_VTCT.MS_PT
                                objDHXVTCT.MS_VI_TRI = objDHX_VTCT.MS_VI_TRI
                                objDHXVTCT.ID_XUAT = objDHX_VTCT.ID_XUAT
                                objDHXVTCT.SL_VT = objDHX_VTCT.SL_XUAT
                                objDHXVTCT.STT = j + 1
                                'ADD DON HANG NHAP VAT TU CHI TIET
                                SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_DON_HANG_XUAT_VAT_TU_CHI_TIET", _
                                    objDHXVTCT.MS_DH_XUAT_PT, objDHXVTCT.MS_PT, objDHXVTCT.STT, _
                                    objDHXVTCT.MS_DH_NHAP_PT, objDHXVTCT.MS_VI_TRI, _
                                    Double.Parse(objDHXVTCT.SL_VT), objDHXVTCT.ID_XUAT)

                                Dim objVTKHO_VTU As New VI_TRI_KHO_VAT_TU_Info
                                objVTKHO_VTU.MS_DH_NHAP_PT = objDHXVTCT.MS_DH_NHAP_PT
                                objVTKHO_VTU.MS_PT = objDHXVTCT.MS_PT
                                objVTKHO_VTU.MS_VI_TRI = objDHXVTCT.MS_VI_TRI
                                objVTKHO_VTU.ID = objDHXVTCT.ID_XUAT
                                objVTKHO_VTU.MS_KHO = objDonHangXuat.MS_KHO
                                sl_ton = SqlHelper.ExecuteScalar(objTrans, "SP_NHU_Y_GET_SO_LUONG_TON_OLD", _
                                    objDHXVTCT.MS_DH_NHAP_PT, objDHXVTCT.MS_VI_TRI, _
                                    objDHXVTCT.MS_PT, objDHXVTCT.ID_XUAT)
                                'objVTKHO_VTU.SL_VT = objDHX_VTCT.SL_VT - objDHX_VTCT.SL_XUAT
                                objVTKHO_VTU.SL_VT = sl_ton - objDHX_VTCT.SL_XUAT
                                If objVTKHO_VTU.SL_VT < 0 Then
                                    objTrans.Rollback()
                                    Return False
                                End If
                                'UPDATE VI TRI KHO VAT TU
                                SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", _
                                    objVTKHO_VTU.MS_KHO, objVTKHO_VTU.MS_PT, objVTKHO_VTU.MS_VI_TRI, _
                                    objVTKHO_VTU.MS_DH_NHAP_PT, objVTKHO_VTU.SL_VT, objVTKHO_VTU.ID)
                                MS_KHO = objVTKHO_VTU.MS_KHO
                            End If
                        Next
                    End If
                Next
                'thuc hien voi nhung cong ty co day du lieu ra 
                If Commons.Modules.iTRFData = 1 Then
                    If TRFNhapKho(objTrans, objDonHangXuat.MS_DH_XUAT_PT, -1) = False Then
                        objTrans.Rollback()
                        Flag = False
                        Exit Function
                    End If
                End If
                objTrans.Commit()
            Catch ex As Exception
                MsgBox(ex.ToString)
                objTrans.Rollback()
                Flag = False
            Finally
                objConnection.Close()
            End Try
            Return Flag
        End Function

        Public Function DELETE_DON_HANG_XUAT(ByVal MS_DH_XUAT_PT As String, ByVal MS_KHO As Integer) As Boolean
            Dim objConnection As New SqlConnection(connectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                Dim lstDHXVTCTIET As List(Of IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info) = QLBusinessDataController.FillCollection(Of IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info)(SqlHelper.ExecuteReader(objTrans, "QL_LOAD_DON_HANG_XUAT_VAT_TU_CHI_TIET_THEO_DH_XUAT", MS_DH_XUAT_PT))
                For i As Integer = 0 To lstDHXVTCTIET.Count - 1
                    Dim objVTKHOVATTU As New VI_TRI_KHO_VAT_TU_Info
                    objVTKHOVATTU.MS_DH_NHAP_PT = lstDHXVTCTIET.Item(i).MS_DH_NHAP_PT
                    objVTKHOVATTU.MS_PT = lstDHXVTCTIET.Item(i).MS_PT
                    objVTKHOVATTU.MS_VI_TRI = lstDHXVTCTIET.Item(i).MS_VI_TRI
                    objVTKHOVATTU.ID = lstDHXVTCTIET.Item(i).ID_XUAT
                    objVTKHOVATTU.SL_VT = Double.Parse(lstDHXVTCTIET.Item(i).SL_VT)

                    objVTKHOVATTU.MS_KHO = MS_KHO
                    Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(objTrans, "QL_LOAD_VI_TRI_KHO_VAT_TU", _
                        objVTKHOVATTU.MS_KHO, objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI, _
                        objVTKHOVATTU.MS_DH_NHAP_PT, objVTKHOVATTU.ID)
                    Dim tempFlag As Boolean = True
                    While dtReader.Read
                        tempFlag = False
                        objVTKHOVATTU.SL_VT = objVTKHOVATTU.SL_VT + Double.Parse(dtReader.Item("SL_VT").ToString)
                        Exit While
                    End While
                    dtReader.Close()
                    If tempFlag Then
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU", objVTKHOVATTU.MS_KHO, _
                            objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI, objVTKHOVATTU.MS_DH_NHAP_PT, _
                            objVTKHOVATTU.SL_VT, objVTKHOVATTU.ID)
                    Else
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", objVTKHOVATTU.MS_KHO, _
                            objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI, objVTKHOVATTU.MS_DH_NHAP_PT, _
                            objVTKHOVATTU.SL_VT, objVTKHOVATTU.ID)
                    End If
                Next

                SqlHelper.ExecuteNonQuery(objTrans, "DELETE_DATA_NHAP_KHO_AUTO", MS_DH_XUAT_PT)

                SqlHelper.ExecuteNonQuery(objTrans, "QL_DELETE_DON_HANG_XUAT", MS_DH_XUAT_PT)

                'thuc hien voi nhung cong ty co day du lieu ra 
                If Commons.Modules.iTRFData = 1 Then
                    Dim dttmp = New DataTable
                    dttmp.Load(SqlHelper.ExecuteReader(objTrans, "spTRFDelXuatKho", MS_DH_XUAT_PT, "-1"))
                    If dttmp.Rows.Count > 0 Then
                        MsgBox(dttmp.Rows(0)(3).ToString() + vbCrLf + dttmp.Rows(0)(5).ToString())
                        objTrans.Rollback()
                        Return False
                    End If
                End If
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

        Public Function CheckIC_KHO_LON_HON_NGAY_KIEM_KE(ByVal GIO As String, ByVal NGAY As String, ByVal MS_KHO As Integer) As Boolean
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(connectionString, "MashjCheckIC_KHO_LON_HON_NGAY_KIEM_KE", GIO, NGAY, MS_KHO)
            While dtReader.Read
                Return True
                dtReader.Close()
            End While
            dtReader.Close()
            Return False
        End Function

    End Class

    Public Class CHI_TIET_VAT_TU_XUAT_Info
        Private _MS_DH_NHAP_PT As String
        Private _NGAY As DateTime
        Private _TEN_VI_TRI As String
        Private _MS_PT As String
        Private _MS_PT_NCC As String
        Private _SL_VT As Double
        Private _GHI_CHU As Double
        Private _SL_XUAT As String

        Private _BAO_HANH_DEN_NGAY As DateTime
        Private _MS_VI_TRI As Integer
        Private _ID_XUAT As Double
        Private _DON_GIA As Double
        Private _TEN_NGOAI_TE As String
        Private _KY_PB As Integer

        Public Sub New()

        End Sub
        Public Property KY_PB() As Integer
            Get
                Return _KY_PB
            End Get
            Set(ByVal value As Integer)
                _KY_PB = value
            End Set
        End Property


        Public Property MS_DH_NHAP_PT() As String
            Get
                Return _MS_DH_NHAP_PT
            End Get
            Set(ByVal value As String)
                _MS_DH_NHAP_PT = value
            End Set
        End Property
        Public Property NGAY() As DateTime
            Get
                Return _NGAY
            End Get
            Set(ByVal value As DateTIME)
                _NGAY = value
            End Set
        End Property
        Public Property BAO_HANH_DEN_NGAY() As DateTime
            Get
                Return _BAO_HANH_DEN_NGAY
            End Get
            Set(ByVal value As DateTime)
                _BAO_HANH_DEN_NGAY = value
            End Set
        End Property
        Public Property TEN_VI_TRI() As String
            Get
                Return _TEN_VI_TRI
            End Get
            Set(ByVal value As String)
                _TEN_VI_TRI = value
            End Set
        End Property
        Public Property MS_PT() As String
            Get
                Return _MS_PT
            End Get
            Set(ByVal value As String)
                _MS_PT = value
            End Set
        End Property
        Public Property MS_PT_NCC() As String
            Get
                Return _MS_PT_NCC
            End Get
            Set(ByVal value As String)
                _MS_PT_NCC = value
            End Set
        End Property
        Public Property SL_VT() As Double
            Get
                Return _SL_VT
            End Get
            Set(ByVal value As Double)
                _SL_VT = value
            End Set
        End Property
        Public Property SL_XUAT() As String
            Get
                Return _SL_XUAT
            End Get
            Set(ByVal value As String)
                _SL_XUAT = value
            End Set
        End Property

        Public Property MS_VI_TRI() As Integer
            Get
                Return _MS_VI_TRI
            End Get
            Set(ByVal value As Integer)
                _MS_VI_TRI = value
            End Set
        End Property

        Public Property GHI_CHU() As Integer
            Get
                Return _GHI_CHU
            End Get
            Set(ByVal value As Integer)
                _GHI_CHU = value
            End Set
        End Property
        Public Property ID_XUAT() As Double
            Get
                Return _ID_XUAT
            End Get
            Set(ByVal value As Double)
                _ID_XUAT = value
            End Set
        End Property


        Public Property DON_GIA() As Double
            Get
                Return _DON_GIA
            End Get
            Set(ByVal value As Double)
                _DON_GIA = value
            End Set
        End Property

        Public Property TEN_NGOAI_TE() As String
            Get
                Return _TEN_NGOAI_TE
            End Get
            Set(ByVal value As String)
                _TEN_NGOAI_TE = value
            End Set
        End Property

    End Class

End Namespace