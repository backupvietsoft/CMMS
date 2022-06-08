
Imports Commons.VS.Classes.Catalogue
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Data.SqlClient.SqlConnection
Imports Microsoft.ApplicationBlocks.Data

Public Class clsPHIEU_BAO_TRIController

    Public Sub New()

    End Sub
#Region "Tab 1"
    Private Function New_MS_PHIEU_BAO_TRI() As String
        Dim sMS = Commons.Modules.ObjSystems.GetMaSoPBTTheoDonVi(Commons.Modules.UserName)
        Dim MS_PHIEU_BAO_TRI As String = sMS + "-"
        MS_PHIEU_BAO_TRI += Now.Year.ToString
        If Now.Month > 9 Then
            MS_PHIEU_BAO_TRI += Now.Month.ToString
        Else
            MS_PHIEU_BAO_TRI += "0" + Now.Month.ToString
        End If
        MS_PHIEU_BAO_TRI += "000001"
        Return MS_PHIEU_BAO_TRI
    End Function

    Private Function New_MS_PHIEU_BAO_TRI(ByVal _Year As Int32, ByVal _Month As Int32) As String
        Dim sMS = Commons.Modules.ObjSystems.GetMaSoPBTTheoDonVi(Commons.Modules.UserName)
        Dim MS_PHIEU_BAO_TRI As String = sMS + "-"
        MS_PHIEU_BAO_TRI += _Year.ToString
        If _Month > 9 Then
            MS_PHIEU_BAO_TRI += _Month.ToString
        Else
            MS_PHIEU_BAO_TRI += "0" + _Month.ToString
        End If
        MS_PHIEU_BAO_TRI += "000001"
        Return MS_PHIEU_BAO_TRI
    End Function

    Public Function Create_MS_PHIEU_BAO_TRI() As String
        Dim sMS = Commons.Modules.ObjSystems.GetMaSoPBTTheoDonVi(Commons.Modules.UserName)
        Dim MS_PHIEU_BAO_TRI As String = ""
        Dim temp As String = ""
        Dim param As String = Now.Year.ToString()
        If Now.Month < 10 Then
            param += "0" + Now.Month.ToString
        Else
            param += Now.Month.ToString
        End If
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getMAX_MS_PHIEU_BAO_TRI", param, sMS)
        While (dtReader.Read)
            temp = dtReader(0).ToString
        End While

        If temp.ToString.Length > 5 Then
            temp = sMS + "-" + temp.Replace(sMS + "-", "")

            Dim sTmp As String
            sTmp = temp.Replace(sMS + "-", "")
            Dim temp1 As String = sTmp.Substring(4, 2)
            Dim month = Integer.Parse(temp1)
            If month <> Now.Month Then
                MS_PHIEU_BAO_TRI = New_MS_PHIEU_BAO_TRI()
            Else
                If temp.Length = 10 + sMS.Length Then
                    temp1 = "000" + temp.Substring(7 + sMS.Length, 3)
                Else
                    If temp.Length = 11 + sMS.Length Then
                        temp1 = temp.Substring(7 + sMS.Length, 4)
                    Else
                        temp1 = temp.Substring(7 + sMS.Length, 6)
                    End If

                End If
                MS_PHIEU_BAO_TRI = temp.Substring(0, 7 + sMS.Length)
                Dim SrNo As Integer = Integer.Parse(temp1) + 1
                For i As Integer = SrNo.ToString.Length() To 5
                    MS_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI & "0"
                Next
                MS_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI + SrNo.ToString
            End If
        Else
            MS_PHIEU_BAO_TRI = New_MS_PHIEU_BAO_TRI()
        End If
        Return MS_PHIEU_BAO_TRI

    End Function
    Public Function Create_MS_PHIEU_BAO_TRI(ByVal _Year As Int32, ByVal _Month As Int32) As String
        Dim sMS = Commons.Modules.ObjSystems.GetMaSoPBTTheoDonVi(Commons.Modules.UserName)
        Dim MS_PHIEU_BAO_TRI As String = ""
        Dim temp As String = ""
        Dim param As String = _Year.ToString()
        If _Month < 10 Then
            param += "0" + _Month.ToString
        Else
            param += _Month.ToString
        End If
        Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getMAX_MS_PHIEU_BAO_TRI", param, sMS)
        While (dtReader.Read)
            temp = dtReader(0).ToString
        End While


        If temp.ToString.Length > 1 Then
            temp = sMS + "-" + temp
            Dim sTmp As String
            sTmp = temp.Replace(sMS + "-", "")
            Dim temp1 As String = sTmp.Substring(4, 2)
            Dim month = Integer.Parse(temp1)
            If month <> _Month Then
                MS_PHIEU_BAO_TRI = New_MS_PHIEU_BAO_TRI()
            Else
                If temp.Length = 10 + sMS.Length Then
                    temp1 = "000" + temp.Substring(7 + sMS.Length, 3)
                Else
                    If temp.Length = 11 + sMS.Length Then
                        temp1 = temp.Substring(7 + sMS.Length, 4)
                    Else
                        temp1 = temp.Substring(7 + sMS.Length, 6)
                    End If

                End If
                MS_PHIEU_BAO_TRI = temp.Substring(0, 7 + sMS.Length)
                Dim SrNo As Integer = Integer.Parse(temp1) + 1
                For i As Integer = SrNo.ToString.Length() To 5
                    MS_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI & "0"
                Next
                MS_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI + SrNo.ToString
            End If
        Else
            MS_PHIEU_BAO_TRI = New_MS_PHIEU_BAO_TRI(_Year, _Month)
        End If
        Return MS_PHIEU_BAO_TRI

    End Function

    Public Function AddPHIEU_BAO_TRI(ByVal objPHIEU_BAO_TRIInfo As clsPHIEU_BAO_TRIInfo) As String
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Commons.Modules.SQLString = ""
        Dim MS_PHIEU_BAO_TRI As String = ""
        Try
            If Not CheckPHIEU_BAO_TRI(objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI) Then
                MS_PHIEU_BAO_TRI = Create_MS_PHIEU_BAO_TRI()
                If objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI = objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI Then
                    objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI
                End If
            Else
                MS_PHIEU_BAO_TRI = objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI
            End If
            SqlHelper.ExecuteNonQuery(objTrans, "AddPHIEU_BAO_TRI1", _
           MS_PHIEU_BAO_TRI, objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI, objPHIEU_BAO_TRIInfo.TINH_TRANG_PBT, objPHIEU_BAO_TRIInfo.MS_MAY, objPHIEU_BAO_TRIInfo.MS_LOAI_BT, _
           objPHIEU_BAO_TRIInfo.NGAY_LAP, objPHIEU_BAO_TRIInfo.GIO_LAP, objPHIEU_BAO_TRIInfo.LY_DO_BT, objPHIEU_BAO_TRIInfo.MS_UU_TIEN, _
           objPHIEU_BAO_TRIInfo.NGAY_BD_KH, objPHIEU_BAO_TRIInfo.NGAY_KT_KH, objPHIEU_BAO_TRIInfo.NGUOI_LAP, objPHIEU_BAO_TRIInfo.USERNAME_NGUOI_LAP, _
           objPHIEU_BAO_TRIInfo.NGUOI_GIAM_SAT, objPHIEU_BAO_TRIInfo.GIO_HONG, objPHIEU_BAO_TRIInfo.NGAY_HONG, objPHIEU_BAO_TRIInfo.NGUYEN_NHAN, _
           objPHIEU_BAO_TRIInfo.DEN_GIO_HONG, objPHIEU_BAO_TRIInfo.DEN_NGAY_HONG)
            objTrans.Commit()
        Catch ex As Exception
            MsgBox(ex.ToString)
            objTrans.Rollback()

            Return ""
        Finally
            objConnection.Close()
        End Try

        Return MS_PHIEU_BAO_TRI
    End Function

    Public Function UpdatePHIEU_BAO_TRI(ByVal objPHIEU_BAO_TRIInfo As clsPHIEU_BAO_TRIInfo) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI", _
            objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI, objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI, objPHIEU_BAO_TRIInfo.TINH_TRANG_PBT, objPHIEU_BAO_TRIInfo.MS_MAY, objPHIEU_BAO_TRIInfo.MS_LOAI_BT, _
            objPHIEU_BAO_TRIInfo.NGAY_LAP, objPHIEU_BAO_TRIInfo.GIO_LAP, objPHIEU_BAO_TRIInfo.LY_DO_BT, objPHIEU_BAO_TRIInfo.MS_UU_TIEN, _
            objPHIEU_BAO_TRIInfo.NGAY_BD_KH, objPHIEU_BAO_TRIInfo.NGAY_KT_KH, objPHIEU_BAO_TRIInfo.NGUOI_LAP, objPHIEU_BAO_TRIInfo.USERNAME_NGUOI_LAP, _
            objPHIEU_BAO_TRIInfo.NGUOI_GIAM_SAT, objPHIEU_BAO_TRIInfo.GIO_HONG, objPHIEU_BAO_TRIInfo.NGAY_HONG, objPHIEU_BAO_TRIInfo.NGUYEN_NHAN, _
            objPHIEU_BAO_TRIInfo.DEN_GIO_HONG, objPHIEU_BAO_TRIInfo.DEN_NGAY_HONG)
        Return True
    End Function

    Public Function UpdatePHIEU_BAO_TRI_TINH_TRANG(ByVal MS_PHIEU_BAO_TRI As String, ByVal TINH_TRANG_PBT As Integer) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI_TINH_TRANG", MS_PHIEU_BAO_TRI, TINH_TRANG_PBT)
        Return True
    End Function

    Public Function DeletePHIEU_BAO_TRI(ByVal MS_PHIEU_BAO_TRI As String) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI", MS_PHIEU_BAO_TRI)
        Return True
    End Function

    Public Function GetPHIEU_BAO_TRI_HINHs(ByVal MS_PHIEU_BAO_TRI As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_HINHs", MS_PHIEU_BAO_TRI))
        Return objDataTable
    End Function

    Public Function AddPHIEU_BAO_TRI_HINH(ByVal MS_PHIEU_BAO_TRI As String, ByVal TEN_TAI_LIEU As String, ByVal DUONG_DAN As String, ByVal STT_YC_NSD As Integer, ByVal STT_GSTT As Integer) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI_HINH", MS_PHIEU_BAO_TRI, TEN_TAI_LIEU, DUONG_DAN, STT_YC_NSD, STT_GSTT)
        Return True
    End Function

    Public Function UpdatePHIEU_BAO_TRI_HINH(ByVal MS_PHIEU_BAO_TRI As String, ByVal STT As Integer, ByVal TEN_TAI_LIEU As String) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI_HINH", MS_PHIEU_BAO_TRI, STT, TEN_TAI_LIEU)
        Return True
    End Function

    Public Function DeletePHIEU_BAO_TRI_HINH(ByVal MS_PHIEU_BAO_TRI As String, ByVal STT As Integer) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_HINH", MS_PHIEU_BAO_TRI, STT)
        Return True
    End Function

    Public Function CheckPHIEU_BAO_TRI(ByVal MS_PHIEU_BAO_TRI As String) As Boolean
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckPHIEU_BAO_TRI", MS_PHIEU_BAO_TRI))
        If IsDBNull(objDataTable.Rows(0).Item("MS_PHIEU_BAO_TRI")) Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "Tab 2"

    Public Function UpdatePHIEU_BAO_TRI_TINH_TRANGs(ByVal MS_PHIEU_BAO_TRI As String, ByVal TINH_TRANG_PBT As Integer) As String
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI_TINH_TRANGs", MS_PHIEU_BAO_TRI, TINH_TRANG_PBT)
        Return True
    End Function
    Public Sub AddPHIEU_BAO_TRI_CV_PHU_TRO(ByVal MS_PHIEU_BAO_TRI As String, ByVal TEN_CONG_VIEC As String, ByVal SO_GIO_KH As Double)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI_CV_PHU_TRO", MS_PHIEU_BAO_TRI, TEN_CONG_VIEC, SO_GIO_KH)
    End Sub

    Public Sub UpdatePHIEU_BAO_TRI_CV_PHU_TRO(ByVal MS_PHIEU_BAO_TRI As String, ByVal STT As Integer, ByVal TEN_CONG_VIEC As String, ByVal SO_GIO_KH As Double)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI_CV_PHU_TRO", MS_PHIEU_BAO_TRI, STT, TEN_CONG_VIEC, SO_GIO_KH)
    End Sub

    Public Sub DeletePHIEU_BAO_TRI_CV_PHU_TRO(ByVal MS_PHIEU_BAO_TRI As String, ByVal STT As Integer)
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CV_PHU_TRO", MS_PHIEU_BAO_TRI, STT)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieubaotri", "CV_PHU_TRO_DANG_SU_DUNG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, "Vietsoft")
        End Try
    End Sub

    Public Function GetCONG_VIEC_PHIEU_BAO_TRIs(ByVal MS_CV As Integer) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_PHIEU_BAO_TRIs", MS_CV))
        Return objDataTable
    End Function
    Public Function GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIETs(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String, ByVal MS_PT As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIETs", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT))
        Return objDataTable
    End Function
    Public Function GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNGs(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String) As DataTable
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN))
        Return objDataTable
    End Function

    Public Function CheckPHIEU_BAO_TRI_CONG_VIEC(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String) As Boolean
        Dim objDataTable As DataTable = New DataTable
        objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckPHIEU_BAO_TRI_CONG_VIEC", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN))
        If IsDBNull(objDataTable.Rows(0).Item("MS_PHIEU_BAO_TRI")) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub DeletePHIEU_BAO_TRI_CONG_VIEC(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CONG_VIEC", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN)
    End Sub

    Public Sub DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String, ByVal MS_PT As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT)
    End Sub

    Public Sub DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String, ByVal MS_PT As String, ByVal STT As Integer)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, STT)
    End Sub
#End Region
#Region "tab 4"

    Public Sub DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN)
    End Sub
    Public Sub DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI_1(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String, ByVal MS_PT As String)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI_1", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT)
    End Sub
    Public Sub DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_THUE_NGOAI(ByVal MS_PHIEU_BAO_TRI As String, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String, ByVal MS_PT As String, ByVal STT As Integer)
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_THUE_NGOAI", MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, STT)
        Catch
        End Try
    End Sub
#End Region
End Class
