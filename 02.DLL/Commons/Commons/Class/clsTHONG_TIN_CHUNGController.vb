Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


'Namespace VS.Classes.Catalogue
Public Class clsTHONG_TIN_CHUNGController

    Public Sub New()
    End Sub

    Public Function GetTHONG_TIN_CHUNG() As clsTHONG_TIN_CHUNGInfo
        Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHONG_TIN_CHUNG")
        Dim objTHONG_TIN_CHUNGInfo As New clsTHONG_TIN_CHUNGInfo
        While objDataReader.Read
            If (Not objDataReader.Item("LOGO_PATH").Equals(DBNull.Value)) Then
                objTHONG_TIN_CHUNGInfo.LOGO_PATH = objDataReader.Item("LOGO_PATH")
            Else
                objTHONG_TIN_CHUNGInfo.LOGO_PATH = ""
            End If
            objTHONG_TIN_CHUNGInfo.LE_PHAI_LOGO = objDataReader.Item("LE_PHAI_LOGO")
            objTHONG_TIN_CHUNGInfo.LE_TREN_LOGO = objDataReader.Item("LE_TREN_LOGO")
            objTHONG_TIN_CHUNGInfo.HEIGHT = objDataReader.Item("HEIGHT")
            objTHONG_TIN_CHUNGInfo.WIDTH = objDataReader.Item("WIDTH")
            objTHONG_TIN_CHUNGInfo.TI_LE_PHAN_TRAM = objDataReader.Item("TI_LE_PHAN_TRAM")
            objTHONG_TIN_CHUNGInfo.STRETCH = objDataReader.Item("STRETCH")
            objTHONG_TIN_CHUNGInfo.LOGO_TEN_CTY = objDataReader.Item("LOGO_TEN_CTY")
            Try
                objTHONG_TIN_CHUNGInfo.LIM_NUMBER = objDataReader.Item("SO_LE")
            Catch ex As Exception
                objTHONG_TIN_CHUNGInfo.LIM_NUMBER = 2
            End Try


        End While
        objDataReader.Close()
        Return objTHONG_TIN_CHUNGInfo
    End Function
    Public Sub UpdateTHONG_TIN_CHUNG(ByVal objThongtin As clsTHONG_TIN_CHUNGInfo)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateTHONG_TIN_CHUNG", _
        objThongtin.WIDTH, objThongtin.HEIGHT, objThongtin.TI_LE_PHAN_TRAM, objThongtin.STRETCH, objThongtin.LE_PHAI_LOGO, objThongtin.LE_TREN_LOGO, _
        objThongtin.LOGO_TEN_CTY, objThongtin.LOGO, objThongtin.LOGO_PATH)
    End Sub
End Class
'End Namespace
