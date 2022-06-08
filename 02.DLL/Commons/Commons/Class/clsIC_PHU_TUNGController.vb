Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class IC_PHU_TUNGController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetIC_PHU_TUNGs(ByVal userlog As String, ByVal MS_LOAI_MAY As String, ByVal MS_LOAI_PT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNGs", userlog, MS_LOAI_MAY, MS_LOAI_PT))
            Return objDataTable
        End Function

        Public Function GetIC_PHU_TUNG_FILTER(ByVal userlog As String, ByVal MS_LOAI_MAY As String, ByVal MS_LOAI_PT As String, ByVal MS_LOAI_VT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG_FILTER", userlog, MS_LOAI_MAY, MS_LOAI_PT, MS_LOAI_VT))
            Return objDataTable
        End Function

        Function get_IC_PHU_TUNG_SEARCH(ByVal userlog As String, ByVal tim_theo As Integer, ByVal giatri As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG_Search", userlog, tim_theo, giatri))
            Return objDataTable
        End Function


        Function get_IC_PHU_TUNG_SEARCH_CS(ByVal userlog As String, ByVal tim_theo As Integer, ByVal giatri As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetIC_PHU_TUNG_Search", userlog, tim_theo, giatri))
            Return objDataTable
        End Function

        Public Function GetIC_PHU_TUNG(ByVal MS_PT As String) As IC_PHU_TUNGInfo
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG", MS_PT)
            Dim objIC_PHU_TUNGInfo As New IC_PHU_TUNGInfo
            While objDataReader.Read
                objIC_PHU_TUNGInfo.MS_PT = objDataReader.Item("MS_HT_BT")
                objIC_PHU_TUNGInfo.TEN_PT = objDataReader.Item("TEN_HT_BT")
                objIC_PHU_TUNGInfo.TON_TOI_THIEU = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.ANH_PT = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.DUNG_CU_DO = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.DVT = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.MS_KH = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.MS_LOAI_MAY = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.MS_LOAI_PT = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.MS_PT_CTY = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.MS_PT_NCC = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.QUY_CACH = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG = objDataReader.Item("PHONG_NGUA")
                objIC_PHU_TUNGInfo.MS_HSX = objDataReader.Item("MS_HSX")
            End While
            objDataReader.Close()
            Return objIC_PHU_TUNGInfo
        End Function
        Public Sub AddIC_PHU_TUNG(ByVal objIC_PHU_TUNGInfo As IC_PHU_TUNGInfo)
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_PHU_TUNG", objIC_PHU_TUNGInfo.MS_PT, IIf(objIC_PHU_TUNGInfo.MS_PT_NCC = "", Nothing, objIC_PHU_TUNGInfo.MS_PT_NCC), IIf(objIC_PHU_TUNGInfo.MS_PT_CTY = "", Nothing, objIC_PHU_TUNGInfo.MS_PT_CTY), _
            'objIC_PHU_TUNGInfo.MS_KH, objIC_PHU_TUNGInfo.TEN_PT, objIC_PHU_TUNGInfo.TON_TOI_THIEU, _
            'objIC_PHU_TUNGInfo.DVT, objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA, objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG, _
            'objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG, objIC_PHU_TUNGInfo.DUNG_CU_DO, _
            'IIf(objIC_PHU_TUNGInfo.QUY_CACH = "", Nothing, objIC_PHU_TUNGInfo.QUY_CACH), IIf(objIC_PHU_TUNGInfo.ANH_PT = "", Nothing, objIC_PHU_TUNGInfo.ANH_PT), objIC_PHU_TUNGInfo.MS_LOAI_VT, IIf(objIC_PHU_TUNGInfo.MS_HSX = 0, Nothing, objIC_PHU_TUNGInfo.MS_HSX), objIC_PHU_TUNGInfo.MS_VI_TRI)


            If objIC_PHU_TUNGInfo.MS_VI_TRI > 0 Then
                Commons.Modules.SQLString = "INSERT INTO IC_PHU_TUNG ([MS_PT], [MS_PT_NCC], [MS_PT_CTY], [MS_KH], [TEN_PT], [TON_TOI_THIEU], [DVT], [SL_DA_DAT_CHUA_MUA],  [MS_CACH_DAT_HANG], [SO_NGAY_DAT_MUA_HANG], [DUNG_CU_DO], [QUY_CACH], [ANH_PT], [MS_LOAI_VT],[MS_HSX], [MS_VI_TRI] , [MS_CLASS]) VALUES ('" & _
                objIC_PHU_TUNGInfo.MS_PT & "'," & IIf(objIC_PHU_TUNGInfo.MS_PT_NCC = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_NCC & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_PT_CTY = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_CTY & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_KH = "" Or objIC_PHU_TUNGInfo.MS_KH Is Nothing, "NULL", objIC_PHU_TUNGInfo.MS_KH) & ",N'" & objIC_PHU_TUNGInfo.TEN_PT & "'," & objIC_PHU_TUNGInfo.TON_TOI_THIEU & ",'" & objIC_PHU_TUNGInfo.DVT & _
                "'," & objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA & "," & objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG & "," & objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG & "," & IIf(objIC_PHU_TUNGInfo.DUNG_CU_DO = False, 0, 1) & "," & IIf(objIC_PHU_TUNGInfo.QUY_CACH = "", "NULL", "N'" & objIC_PHU_TUNGInfo.QUY_CACH & "'") & "," & IIf(objIC_PHU_TUNGInfo.ANH_PT = "", "NULL", "'" & objIC_PHU_TUNGInfo.ANH_PT & "'") & ",'" & objIC_PHU_TUNGInfo.MS_LOAI_VT & "'," & IIf(objIC_PHU_TUNGInfo.MS_HSX = 0, "NULL", "'" & objIC_PHU_TUNGInfo.MS_HSX & "'") & "," & objIC_PHU_TUNGInfo.MS_VI_TRI & "," & IIf(objIC_PHU_TUNGInfo.MS_CLASS = -1, "NULL", objIC_PHU_TUNGInfo.MS_CLASS) & " )"
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            Else
                Commons.Modules.SQLString = "INSERT INTO IC_PHU_TUNG ([MS_PT], [MS_PT_NCC], [MS_PT_CTY], [MS_KH], [TEN_PT], [TON_TOI_THIEU], [DVT], [SL_DA_DAT_CHUA_MUA],  [MS_CACH_DAT_HANG], [SO_NGAY_DAT_MUA_HANG], [DUNG_CU_DO], [QUY_CACH], [ANH_PT], [MS_LOAI_VT],[MS_HSX] , MS_CLASS ) VALUES ('" & _
                objIC_PHU_TUNGInfo.MS_PT & "'," & IIf(objIC_PHU_TUNGInfo.MS_PT_NCC = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_NCC & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_PT_CTY = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_CTY & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_KH = "" Or objIC_PHU_TUNGInfo.MS_KH Is Nothing, "NULL", objIC_PHU_TUNGInfo.MS_KH) & ",N'" & objIC_PHU_TUNGInfo.TEN_PT & "'," & objIC_PHU_TUNGInfo.TON_TOI_THIEU & ",'" & objIC_PHU_TUNGInfo.DVT & _
                "'," & objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA & "," & objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG & "," & objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG & "," & IIf(objIC_PHU_TUNGInfo.DUNG_CU_DO = False, 0, 1) & "," & IIf(objIC_PHU_TUNGInfo.QUY_CACH = "", "NULL", "N'" & objIC_PHU_TUNGInfo.QUY_CACH & "'") & "," & IIf(objIC_PHU_TUNGInfo.ANH_PT = "", "NULL", "'" & objIC_PHU_TUNGInfo.ANH_PT & "'") & ",'" & objIC_PHU_TUNGInfo.MS_LOAI_VT & "'," & IIf(objIC_PHU_TUNGInfo.MS_HSX = 0, "NULL", objIC_PHU_TUNGInfo.MS_HSX) & ", " & IIf(objIC_PHU_TUNGInfo.MS_CLASS = -1, "NULL", objIC_PHU_TUNGInfo.MS_CLASS) & ")"
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        End Sub

        Public Sub AddIC_PHU_TUNG_CS(ByVal objIC_PHU_TUNGInfo As IC_PHU_TUNGInfo)
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_PHU_TUNG", objIC_PHU_TUNGInfo.MS_PT, IIf(objIC_PHU_TUNGInfo.MS_PT_NCC = "", Nothing, objIC_PHU_TUNGInfo.MS_PT_NCC), IIf(objIC_PHU_TUNGInfo.MS_PT_CTY = "", Nothing, objIC_PHU_TUNGInfo.MS_PT_CTY), _
            'objIC_PHU_TUNGInfo.MS_KH, objIC_PHU_TUNGInfo.TEN_PT, objIC_PHU_TUNGInfo.TON_TOI_THIEU, _
            'objIC_PHU_TUNGInfo.DVT, objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA, objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG, _
            'objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG, objIC_PHU_TUNGInfo.DUNG_CU_DO, _
            'IIf(objIC_PHU_TUNGInfo.QUY_CACH = "", Nothing, objIC_PHU_TUNGInfo.QUY_CACH), IIf(objIC_PHU_TUNGInfo.ANH_PT = "", Nothing, objIC_PHU_TUNGInfo.ANH_PT), objIC_PHU_TUNGInfo.MS_LOAI_VT, IIf(objIC_PHU_TUNGInfo.MS_HSX = 0, Nothing, objIC_PHU_TUNGInfo.MS_HSX), objIC_PHU_TUNGInfo.MS_VI_TRI)


            If objIC_PHU_TUNGInfo.MS_VI_TRI > 0 Then
                Commons.Modules.SQLString = "INSERT INTO IC_PHU_TUNG ([MS_PT], [MS_PT_NCC], [MS_PT_CTY], [MS_KH], [TEN_PT], [TON_TOI_THIEU], [DVT], [SL_DA_DAT_CHUA_MUA],  [MS_CACH_DAT_HANG], [SO_NGAY_DAT_MUA_HANG], [DUNG_CU_DO], [QUY_CACH], [ANH_PT], [MS_LOAI_VT],[MS_HSX], [MS_VI_TRI] , [MS_CLASS],[TON_KHO_MAX]) VALUES ('" & _
                objIC_PHU_TUNGInfo.MS_PT & "'," & IIf(objIC_PHU_TUNGInfo.MS_PT_NCC = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_NCC & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_PT_CTY = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_CTY & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_KH = "" Or objIC_PHU_TUNGInfo.MS_KH Is Nothing, "NULL", objIC_PHU_TUNGInfo.MS_KH) & ",N'" & objIC_PHU_TUNGInfo.TEN_PT & "'," & objIC_PHU_TUNGInfo.TON_TOI_THIEU & ",'" & objIC_PHU_TUNGInfo.DVT & _
                "'," & objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA & "," & objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG & "," & objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG & "," & IIf(objIC_PHU_TUNGInfo.DUNG_CU_DO = False, 0, 1) & "," & IIf(objIC_PHU_TUNGInfo.QUY_CACH = "", "NULL", "N'" & objIC_PHU_TUNGInfo.QUY_CACH & "'") & "," & IIf(objIC_PHU_TUNGInfo.ANH_PT = "", "NULL", "'" & objIC_PHU_TUNGInfo.ANH_PT & "'") & ",'" & objIC_PHU_TUNGInfo.MS_LOAI_VT & "'," & IIf(objIC_PHU_TUNGInfo.MS_HSX = 0, "NULL", "'" & objIC_PHU_TUNGInfo.MS_HSX & "'") & "," & objIC_PHU_TUNGInfo.MS_VI_TRI & "," & IIf(objIC_PHU_TUNGInfo.MS_CLASS = -1, "NULL", objIC_PHU_TUNGInfo.MS_CLASS) & "," & objIC_PHU_TUNGInfo.TON_KHO_MAX & " )"
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            Else
                Commons.Modules.SQLString = "INSERT INTO IC_PHU_TUNG ([MS_PT], [MS_PT_NCC], [MS_PT_CTY], [MS_KH], [TEN_PT], [TON_TOI_THIEU], [DVT], [SL_DA_DAT_CHUA_MUA],  [MS_CACH_DAT_HANG], [SO_NGAY_DAT_MUA_HANG], [DUNG_CU_DO], [QUY_CACH], [ANH_PT], [MS_LOAI_VT],[MS_HSX] , MS_CLASS ,[TON_KHO_MAX]) VALUES ('" & _
                objIC_PHU_TUNGInfo.MS_PT & "'," & IIf(objIC_PHU_TUNGInfo.MS_PT_NCC = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_NCC & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_PT_CTY = "", "NULL", "'" & objIC_PHU_TUNGInfo.MS_PT_CTY & "'") & "," & IIf(objIC_PHU_TUNGInfo.MS_KH = "" Or objIC_PHU_TUNGInfo.MS_KH Is Nothing, "NULL", objIC_PHU_TUNGInfo.MS_KH) & ",N'" & objIC_PHU_TUNGInfo.TEN_PT & "'," & objIC_PHU_TUNGInfo.TON_TOI_THIEU & ",'" & objIC_PHU_TUNGInfo.DVT & _
                "'," & objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA & "," & objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG & "," & objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG & "," & IIf(objIC_PHU_TUNGInfo.DUNG_CU_DO = False, 0, 1) & "," & IIf(objIC_PHU_TUNGInfo.QUY_CACH = "", "NULL", "N'" & objIC_PHU_TUNGInfo.QUY_CACH & "'") & "," & IIf(objIC_PHU_TUNGInfo.ANH_PT = "", "NULL", "'" & objIC_PHU_TUNGInfo.ANH_PT & "'") & ",'" & objIC_PHU_TUNGInfo.MS_LOAI_VT & "'," & IIf(objIC_PHU_TUNGInfo.MS_HSX = 0, "NULL", objIC_PHU_TUNGInfo.MS_HSX) & ", " & IIf(objIC_PHU_TUNGInfo.MS_CLASS = -1, "NULL", objIC_PHU_TUNGInfo.MS_CLASS) & "," & objIC_PHU_TUNGInfo.TON_KHO_MAX & ")"
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        End Sub



        Public Sub UpdateIC_PHU_TUNG(ByVal objIC_PHU_TUNGInfo As IC_PHU_TUNGInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateIC_PHU_TUNG", _
            objIC_PHU_TUNGInfo.MS_PT, objIC_PHU_TUNGInfo.MS_PT_NCC, objIC_PHU_TUNGInfo.MS_PT_CTY, _
            objIC_PHU_TUNGInfo.MS_KH, objIC_PHU_TUNGInfo.TEN_PT, objIC_PHU_TUNGInfo.TON_TOI_THIEU, _
            objIC_PHU_TUNGInfo.DVT, objIC_PHU_TUNGInfo.SL_DA_DAT_CHUA_MUA, objIC_PHU_TUNGInfo.MS_CACH_DAT_HANG, _
            objIC_PHU_TUNGInfo.SO_NGAY_DAT_MUA_HANG, objIC_PHU_TUNGInfo.DUNG_CU_DO, objIC_PHU_TUNGInfo.QUY_CACH, _
            objIC_PHU_TUNGInfo.ANH_PT, objIC_PHU_TUNGInfo.MS_LOAI_VT, objIC_PHU_TUNGInfo.MS_PT_tmp, IIf(objIC_PHU_TUNGInfo.MS_HSX = 0, Nothing, objIC_PHU_TUNGInfo.MS_HSX), IIf(objIC_PHU_TUNGInfo.MS_VI_TRI = 0, Nothing, objIC_PHU_TUNGInfo.MS_VI_TRI), IIf(objIC_PHU_TUNGInfo.MS_CLASS = -1, Nothing, objIC_PHU_TUNGInfo.MS_CLASS))
        End Sub

        Public Sub DeleteIC_PHU_TUNG(ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteIC_PHU_TUNG", MS_PT)
        End Sub

        Public Sub AddIC_PHU_TUNG_LOAI_PHU_TUNG(ByVal MS_PT As String, ByVal MS_LOAI_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_PHU_TUNG_LOAI_PHU_TUNG", MS_PT, MS_LOAI_PT)
        End Sub

        Public Function GetIC_PHU_TUNG_LOAI_PHU_TUNG(ByVal MS_PT As String, ByVal USER As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG_LOAI_PHU_TUNG", MS_PT, USER))
            Return objDataTable
        End Function

        Public Sub DeletedIC_PHU_TUNG_LOAI_PHU_TUNG(ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletedIC_PHU_TUNG_LOAI_PHU_TUNG", MS_PT)
        End Sub

        Public Sub AddIC_PHU_TUNG_LOAI_MAY(ByVal MS_PT As String, ByVal MS_LOAI_MAY As String)
            'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddIC_PHU_TUNG_LOAI_MAY", MS_PT, MS_LOAI_MAY)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "INSERT INTO IC_PHU_TUNG_LOAI_MAY(MS_PT,MS_LOAI_MAY) VALUES(N'" & MS_PT & "','" & MS_LOAI_MAY & "')")
        End Sub

        Public Function GetIC_PHU_TUNG_LOAI_MAY(ByVal MS_PT As String, ByVal USER As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG_LOAI_MAY", MS_PT, USER))
            Return objDataTable
        End Function

        Public Sub DeletedIC_PHU_TUNG_LOAI_MAY(ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeletedIC_PHU_TUNG_LOAI_MAY", MS_PT)
        End Sub

        'Public Function GetIC_PHU_TUNGs() As DataTable
        '    Dim objDataTable As DataTable = New DataTable
        '    objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNGs"))
        '    Return objDataTable
        'End Function

        'Public Function GetIC_PHU_TUNG(ByVal MS_PT As String) As String
        '    Dim TEN_PHU_TUNG As String
        '    Dim reader As SqlDataReader
        '    reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_PHU_TUNG", MS_PT)
        '    If reader.Read Then
        '        TEN_PHU_TUNG = reader.Item("TEN_PT")
        '    End If
        '    Return TEN_PHU_TUNG
        'End Function

        Public Function GetTEN_LOAI_VTs() As DataTable
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTEN_LOAI_VTs"))
            Return objDataTable
        End Function
#End Region

#Region "Relatives"
        ' Kiểm tra trùng tên phụ tùng.
        Public Function CheckExistTEN_PT(ByVal TEN_PT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistTEN_PT", TEN_PT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        ' Kiểm tra trùng mã số phụ tùng.
        Public Function CheckExistMS_PT(ByVal MS_PT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckExistMS_PT", MS_PT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedMAY_LOAI_BTPN_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedMAY_LOAI_BTPN_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedNHAP_KHO_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedNHAP_KHO_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedXUAT_KHO_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedXUAT_KHO_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedKIEM_KE_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedKIEM_KE_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function CheckUsedCHU_KY_HIEU_CHUAN(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedCHU_KY_HIEU_CHUAN", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedCAU_TRUC_THIET_BI(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedCAU_TRUC_THIET_BI", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function CheckUsedCAU_TRUC_THIET_BI_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUsedCAU_TRUC_THIET_BI_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Get_UpdateIC_PHU_TUNG_LOAI_MAY(ByVal MS_PT As String, ByVal USER As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_UpdateIC_PHU_TUNG_LOAI_MAY", MS_PT, USER))
            Return objDataTable
        End Function

        Public Function Get_UpdateIC_PHU_TUNG_LOAI_PHU_TUNG(ByVal MS_PT As String, ByVal USER As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_UpdateIC_PHU_TUNG_LOAI_PHU_TUNG", MS_PT, USER))
            Return objDataTable
        End Function

        Public Function Check_UsedEOR_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedEOR_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedEOR_TINH_TRANG_MNR(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedEOR_TINH_TRANG_MNR", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedKE_HOACH_TONG_CONG_VIEC_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedKE_HOACH_TONG_CONG_VIEC_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function Check_UsedPHIEU_BAO_TRI_CV_PT_IC_PHU_TUNG(ByVal MSPT As String) As Boolean
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Check_UsedPHIEU_BAO_TRI_CV_PT_IC_PHU_TUNG", MSPT))
            If objDataTable.Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
#End Region

#Region "Phụ tùng thay thế"
        Public Function Get_IC_PHU_TUNG_THAY_THE(ByVal MS_PT As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_IC_PHU_TUNG_THAY_THE", MS_PT))
            Return objDataTable
        End Function

        Public Sub Delete_IC_PHU_TUNG_THAY_THE(ByVal MS_PT As String, ByVal MS_PT1 As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_IC_PHU_TUNG_THAY_THE", MS_PT, MS_PT1)
        End Sub

        Public Sub Delete_All_IC_PHU_TUNG_THAY_THE(ByVal MS_PT As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Delete_All_IC_PHU_TUNG_THAY_THE", MS_PT)
        End Sub

        Public Sub Add_IC_PHU_TUNG_THAY_THE(ByVal MS_PT As String, ByVal MS_PT1 As String)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "Add_IC_PHU_TUNG_THAY_THE", MS_PT, MS_PT1)
        End Sub

        Public Function GetLOAI_MAYs(ByVal USER As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_LOAI_MAY_PT", USER))
            Return objDataTable
        End Function

        Public Function GetLOAI_PHU_TUNGs(ByVal USER As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_LOAI_PHU_TUNG_PT", USER))
            Return objDataTable
        End Function
#End Region

    End Class
End Namespace
