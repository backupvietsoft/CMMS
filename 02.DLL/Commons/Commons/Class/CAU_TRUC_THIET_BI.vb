Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class CAU_TRUC_THIET_BI

    Public Function getAllRecord() As DataTable
        Return SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "sp_CauTrucThietBi").Tables(0)
    End Function

    Public Function getAllRecord(ByVal sMS_MAY As String, ByVal sMS_BP As String) As CAU_TRUC_THIET_BI_ROW
        Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCAU_TRUC_THIET_BI", sMS_MAY, sMS_BP)
        Dim TB As New DataTable()
        TB = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCAU_TRUC_THIET_BI", sMS_MAY, sMS_BP).Tables(0)
        Dim oCTTB As New CAU_TRUC_THIET_BI_ROW
        Do While objDataReader.Read
            oCTTB.MA_MAY = IIf(IsDBNull(objDataReader.Item("MS_MAY")), String.Empty, objDataReader.Item("MS_MAY").ToString())
            oCTTB.MA_BO_PHAN = IIf(IsDBNull(objDataReader.Item("MS_BO_PHAN")), String.Empty, objDataReader.Item("MS_BO_PHAN").ToString())
            oCTTB.TEN_BO_PHAN = IIf(IsDBNull(objDataReader.Item("TEN_BO_PHAN")), String.Empty, objDataReader.Item("TEN_BO_PHAN").ToString())
            oCTTB.SO_LUONG = IIf(IsDBNull(objDataReader.Item("SO_LUONG")), 0, objDataReader.Item("SO_LUONG"))
            oCTTB.BO_PHAN_CHA = IIf(IsDBNull(objDataReader.Item("MS_BO_PHAN_CHA")), String.Empty, objDataReader.Item("MS_BO_PHAN_CHA").ToString())
            oCTTB.GHI_CHU = IIf(IsDBNull(objDataReader.Item("GHI_CHU")), String.Empty, objDataReader.Item("GHI_CHU").ToString())
            oCTTB.RUN_TIME = IIf(IsDBNull(objDataReader.Item("RUN_TIME")), 0, objDataReader.Item("RUN_TIME"))
            oCTTB.MS_DVT_RT = IIf(IsDBNull(objDataReader.Item("MS_DVT_RT")), 0, objDataReader.Item("MS_DVT_RT"))
            oCTTB.HINH = IIf(IsDBNull(objDataReader.Item("HINH")), String.Empty, objDataReader.Item("HINH").ToString())
            oCTTB.MS_PT = IIf(IsDBNull(objDataReader.Item("MA_PT")), String.Empty, objDataReader.Item("MA_PT").ToString())
            oCTTB.CLASS_ID = IIf(IsDBNull(objDataReader.Item("CLASS_ID")), "-1", objDataReader.Item("CLASS_ID").ToString())
            'Lấy ra tên đơn vị tính
            Dim SqlText As String = "SELECT * FROM DON_VI_TINH_RUN_TIME WHERE MS_DVT_RT=" & oCTTB.MS_DVT_RT & ""
            Dim objDVT As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            Do While objDVT.Read
                oCTTB.TEN_DVT_RT = IIf(IsDBNull(objDVT.Item("TEN_DVT_RT")), String.Empty, objDVT.Item("TEN_DVT_RT"))
            Loop
            objDVT.Close()
        Loop
        objDataReader.Close()
        Return oCTTB
    End Function

    Public Function getThongSoBP(ByVal sMS_MAY As String, ByVal sMS_BP As String)
        Dim SqlText As String = "SELECT TEN_THONG_SO,GIA_TRI_THONG_SO,STT FROM THONG_SO_BO_PHAN WHERE MS_MAY=N'" & sMS_MAY & "' AND MS_BO_PHAN='" & sMS_BP.Replace("'", "''") & "'"
        Return SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, SqlText).Tables(0)
    End Function

    Public Function getThongTinPT(ByVal sMS_MAY As String, ByVal sMS_BP As String, ByVal TEN_DVT As String) As DataTable
        Return SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "sp_ThongTinPT", sMS_MAY, sMS_BP, TEN_DVT).Tables(0)
    End Function

    Public Sub AddNew(ByVal oCTTB As CAU_TRUC_THIET_BI_ROW)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_Insert_Cautructhietbi", oCTTB.MA_MAY, oCTTB.MA_BO_PHAN, oCTTB.TEN_BO_PHAN, oCTTB.SO_LUONG, oCTTB.BO_PHAN_CHA, oCTTB.GHI_CHU, oCTTB.RUN_TIME, oCTTB.MS_DVT_RT)
    End Sub

    Public Sub Update(ByVal oCTTB As CAU_TRUC_THIET_BI_ROW)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_Update_Cautructhietbi", oCTTB.MA_MAY, oCTTB.MA_BO_PHAN, oCTTB.TEN_BO_PHAN, oCTTB.SO_LUONG, oCTTB.BO_PHAN_CHA, oCTTB.GHI_CHU, oCTTB.RUN_TIME, oCTTB.MS_DVT_RT)
    End Sub

    Public Sub Delete(ByVal sMS_MAY As String, ByVal sMS_BP As String)

    End Sub

End Class
