Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

    Public Class OGroups
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetNHOMs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOMs"))
            Return objDataTable
        End Function

        Public Function GetNHOM(ByVal GROUP_ID As Integer, Optional ByVal GROUP_NAME As String = "") As IGroups
            'neu GROUP_NAME<> "" thi chung ta kiem tra coi co GROUP_NAME nao giong voi cua GROUP_ID hien tai khong
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM", GROUP_ID, GROUP_NAME)
            Dim objNHOMInfo As New IGroups
            While objDataReader.Read
                objNHOMInfo.DESCRIPTION = objDataReader.Item("DESCRIPTION")
                objNHOMInfo.GROUP_ID = objDataReader.Item("GROUP_ID")
                objNHOMInfo.GROUP_NAME = objDataReader.Item("GROUP_NAME")
            End While
            Return objNHOMInfo
        End Function

    Public Function AddNHOM(ByVal objNHOMInfo As IGroups) As Integer
        Return CType(SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM", _
            objNHOMInfo.GROUP_NAME, objNHOMInfo.DESCRIPTION, objNHOMInfo.TYPE_LIC), Integer)
    End Function

    Public Sub UpdateNHOM(ByVal objNHOMInfo As IGroups, ByVal FORM_NAME As String, ByVal THAO_TAC As Integer)
        Try
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "UPDATE_NHOM_LOG", _
                objNHOMInfo.GROUP_ID, FORM_NAME, Commons.Modules.UserName, THAO_TAC)
        Catch ex As Exception

        End Try
        SqlHelper.ExecuteScalar(IConnections.ConnectionString, "UpdateNHOM", _
            objNHOMInfo.GROUP_ID, objNHOMInfo.GROUP_NAME, objNHOMInfo.DESCRIPTION, objNHOMInfo.TYPE_LIC)
    End Sub

        Public Function CheckNHOM_IN_ACTIVITY(ByVal GROUP_ID As Integer) As SqlDataReader
            Return SqlHelper.ExecuteReader(IConnections.ConnectionString, "CheckNHOM_IN_ACTIVITY", GROUP_ID)
        End Function

        Public Sub DeleteNHOM(ByVal GROUP_ID As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM", GROUP_ID)
        End Sub

        Public Function CheckGROUP_NAME(ByVal GROUP_NAME As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(IConnections.ConnectionString, "CheckGROUP_NAME", GROUP_NAME)
        End Function

        Public Function CheckExistGROUP(ByVal GROUP_ID As Integer, ByVal GROUP_NAME As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(IConnections.ConnectionString, "CheckExistGROUP", GROUP_ID, GROUP_NAME)
        End Function

        Public Function CheckExistTEN_NHOM(ByVal GROUP_ID As Integer, ByVal GROUP_NAME As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(IConnections.ConnectionString, "CheckExistTEN_NHOM", GROUP_ID, GROUP_NAME)
        End Function
#End Region
#Region "quyền nhóm"
        '-----------14/03/2007----------------------------------------
        Public Function GetUSERofGROUPs(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetUSERofGROUPs", intGroupID))
            Return objDataTable
        End Function
        Public Sub DeleteNHOMs(ByVal GROUP_ID As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOMs", GROUP_ID)
        End Sub
        Public Function GetCHI_TIET_FORM_QUYEN(ByVal GROUP_ID As Integer, ByVal intTypeLanguage As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetCHI_TIET_FORM_QUYEN", GROUP_ID, intTypeLanguage))
            Return objDataTable
        End Function
        Public Sub AddNHOM_FORM(ByVal intGroupID As Integer, ByVal strFormName As String, ByVal strQuyen As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_FORM", _
                intGroupID, strFormName, strQuyen)

        End Sub

        Public Sub UpdateNHOM_FORM(ByVal intGroupID As Integer, ByVal strFormName As String, ByVal strQuyen As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "UpdateNHOM_FORM", _
                intGroupID, strFormName, strQuyen)
        End Sub
        Public Function GetNHA_XUONG_QUYEN(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHA_XUONG_QUYEN", intGroupID))
            Return objDataTable
        End Function

        Public Function GetNHOM_NHA_XUONG(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_NHA_XUONG", intGroupID))
            Return objDataTable
        End Function
        Public Sub DeleteNHOM_NHA_XUONG(ByVal GROUP_ID As Integer, ByVal strMS_N_XUONG As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM_NHA_XUONG", GROUP_ID, strMS_N_XUONG)
        End Sub
        Public Sub AddNHOM_NHA_XUONG(ByVal intGroupID As Integer, ByVal strMS_N_XUONG As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_NHA_XUONG", _
                intGroupID, strMS_N_XUONG)
        End Sub
        '-------------- PHAN QUYEN DAY TRUYEN -------------------------
        Public Sub AddNHOM_HE_THONG(ByVal intGroupID As Integer, ByVal strMS_HE_THONG As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_HE_THONG", _
                intGroupID, strMS_HE_THONG)
        End Sub
        Public Function GetNHOM_HE_THONG(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_HE_THONG", intGroupID))
            Return objDataTable
        End Function
        Public Function GetHE_THONG_QUYEN(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetHE_THONG_QUYEN", intGroupID))
            Return objDataTable
        End Function
        Public Sub DeleteNHOM_HE_THONG(ByVal GROUP_ID As Integer, ByVal strMS_HE_THONG As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM_HE_THONG", GROUP_ID, strMS_HE_THONG)
        End Sub
        '--------------------------------END------------------------------
        Public Sub AddNHOM_NHA_HE_THONG(ByVal intGroupID As Integer, ByVal strMS_HE_THONG As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_NHA_HE_THONG", _
                intGroupID, strMS_HE_THONG)
        End Sub
        Public Function GetNHOM_LOAI_MAY(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_LOAI_MAY", intGroupID))
            Return objDataTable
        End Function
        Public Function GetLOAI_MAY_QUYEN(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLOAI_MAY_QUYEN", intGroupID))
            Return objDataTable
        End Function
        Public Sub DeleteNHOM_LOAI_MAY(ByVal GROUP_ID As Integer, ByVal strMS_LOAI_MAY As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM_LOAI_MAY", GROUP_ID, strMS_LOAI_MAY)
        End Sub
        Public Sub AddNHOM_LOAI_MAY(ByVal intGroupID As Integer, ByVal strMS_LOAI_MAY As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_LOAI_MAY", _
                intGroupID, strMS_LOAI_MAY)
        End Sub
        Public Function GetNHOM_LOAI_CONG_VIEC(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_LOAI_CONG_VIEC", intGroupID))
            Return objDataTable
        End Function
        Public Function GetLOAI_CONG_VIEC_QUYEN(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLOAI_CONG_VIEC_QUYEN", intGroupID))
            Return objDataTable
        End Function
        Public Sub DeleteNHOM_LOAI_CV(ByVal GROUP_ID As Integer, ByVal strMS_LOAI_CV As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM_LOAI_CV", GROUP_ID, strMS_LOAI_CV)
        End Sub
        Public Sub AddNHOM_LOAI_CV(ByVal intGroupID As Integer, ByVal strMS_LOAI_CV As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_LOAI_CV", _
                intGroupID, strMS_LOAI_CV)
        End Sub
        Public Function GetNHOM_LOAI_PHU_TUNG(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_LOAI_PHU_TUNG", intGroupID))
            Return objDataTable
        End Function
        Public Function GetLOAI_PHU_TUNG_QUYEN(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLOAI_PHU_TUNG_QUYEN", intGroupID))
            Return objDataTable
        End Function
        Public Sub DeleteNHOM_LOAI_PHU_TUNG(ByVal GROUP_ID As Integer, ByVal strMS_LOAI_PT As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM_LOAI_PHU_TUNG", GROUP_ID, strMS_LOAI_PT)
        End Sub
        Public Sub AddNHOM_LOAI_PHU_TUNG(ByVal intGroupID As Integer, ByVal strMS_LOAI_PT As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_LOAI_PHU_TUNG", _
                intGroupID, strMS_LOAI_PT)
        End Sub
        Public Function GetNHOM_KHO(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_KHO", intGroupID))
            Return objDataTable
        End Function
        Public Function GetLOAI_IC_KHO_QUYEN(ByVal intGroupID As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetLOAI_IC_KHO_QUYEN", intGroupID))
            Return objDataTable
        End Function
        Public Sub DeleteNHOM_KHO(ByVal GROUP_ID As Integer, ByVal strMS_KHO As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM_KHO", GROUP_ID, strMS_KHO)
        End Sub
        Public Sub AddNHOM_KHO(ByVal intGroupID As Integer, ByVal strMS_KHO As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_KHO", _
                intGroupID, strMS_KHO)
        End Sub
        Public Function GetNHOM_MENU(ByVal intGroupID As Integer, ByVal Type As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_MENU", intGroupID, Type))
            Return objDataTable
        End Function
        Public Function GetMENU_QUYEN(ByVal intGroupID As Integer, ByVal Type As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetMENU_QUYEN", intGroupID, Type))
            Return objDataTable
        End Function
        Public Sub DeleteNHOM_MENU(ByVal GROUP_ID As Integer, ByVal strMENU_ID As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteNHOM_MENU", GROUP_ID, strMENU_ID)
        End Sub
        Public Sub AddNHOM_MENU(ByVal intGroupID As Integer, ByVal strMENU_ID As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddNHOM_MENU", _
                intGroupID, strMENU_ID)
        End Sub
        Function CheckExistGROUP_ID(ByVal GROUP_ID As Integer) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, "CheckExistGROUP_ID", GROUP_ID)

            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function
        Function CheckUSER_CHUCNANG(ByVal USERNAME As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, "CheckUSER_CHUCNANG", USERNAME)

            While objDataReader.Read
                objDataReader.Close()
                Return True
            End While
            objDataReader.Close()
            Return False
        End Function

        Public Function UpdateUSER(ByVal strUSERNAME As String, ByVal objUSERInfo As IUsers) As String
            If objUSERInfo.MsTo = 0 Then
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "UpdateUSER", _
            strUSERNAME, objUSERInfo.UserName, objUSERInfo.GroupID, objUSERInfo.FullName, _
            objUSERInfo.Password, objUSERInfo.Description, Nothing, objUSERInfo.UserMail)
            Else
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "UpdateUSER", _
                            strUSERNAME, objUSERInfo.UserName, objUSERInfo.GroupID, objUSERInfo.FullName, _
                            objUSERInfo.Password, objUSERInfo.Description, objUSERInfo.MsTo, objUSERInfo.UserMail)
            End If
            Return objUSERInfo.USERNAME
        End Function
        Public Function AddUSER(ByVal objUSERInfo As IUsers) As String
            If objUSERInfo.MsTo = 0 Then
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddUSER", _
            objUSERInfo.UserName, objUSERInfo.GroupID, objUSERInfo.FullName, _
            objUSERInfo.Password, objUSERInfo.Description, Nothing, objUSERInfo.UserMail)
            Else
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddUSER", _
                            objUSERInfo.UserName, objUSERInfo.GroupID, objUSERInfo.FullName, _
                            objUSERInfo.Password, objUSERInfo.Description, objUSERInfo.MsTo, objUSERInfo.UserMail)
            End If
            Return objUSERInfo.USERNAME
        End Function
        Public Sub DeleteUSER_NHOM(ByVal GROUP_ID As Integer, ByVal USERNAME As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteUSER_NHOM", GROUP_ID, USERNAME)
        End Sub
        Public Function CheckExistUserName(ByVal USERNAME As String) As Boolean
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, "CheckUSERNAME", USERNAME)
            While objDataReader.Read
                objDataReader.Close()
                Return False
            End While
            objDataReader.Close()
            Return True
        End Function
        Public Function GetUSER_CHUC_NANG(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetUSER_CHUC_NANG", USERNAME))
            Return objDataTable
        End Function
        Public Function GetCHUC_NANG_QUYEN(ByVal USERNAME As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetCHUC_NANG_QUYEN", USERNAME))
            Return objDataTable
        End Function
        Public Sub DeleteUSER_CHUC_NANG(ByVal USERNAME As String, ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "DeleteUSER_CHUC_NANG", USERNAME, intSTT)
        End Sub
        Public Sub AddUSER_CHUC_NANG(ByVal USERNAME As String, ByVal intSTT As Integer)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "AddUSER_CHUC_NANG", _
                USERNAME, intSTT)
        End Sub
        Public Function GetNHOM_FORM_QUYEN(ByVal USERNAME As String, ByVal FORM_NAME As String) As String
            Dim objDataReader As SqlDataReader = SqlHelper.ExecuteReader(IConnections.ConnectionString, "GetNHOM_FORM_QUYEN", USERNAME, FORM_NAME)
            While objDataReader.Read
                Return objDataReader.Item("QUYEN")
                objDataReader.Close()
            End While
            objDataReader.Close()
            Return ""
        End Function
        Public Function Get_Danhsachbaocao(ByVal user_loged As String, ByVal GROUP_ID As Integer, ByVal Loai_rp As Integer, ByVal ngon_ngu As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.ConnectionString, "Get_Danhsachbaocao", user_loged, GROUP_ID, Loai_rp, ngon_ngu))
            Return objDataTable
        End Function
        Public Sub Add_NHOM_REPORT(ByVal REPORT_NAME As String, ByVal GROUP_ID As Integer, ByVal QUYEN As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "Add_NHOM_REPORT", REPORT_NAME, GROUP_ID, QUYEN)
        End Sub
        Public Sub Update_NHOM_REPORT(ByVal REPORT_NAME As String, ByVal GROUP_ID As Integer, ByVal QUYEN As String)
            SqlHelper.ExecuteScalar(IConnections.ConnectionString, "Update_NHOM_REPORT", REPORT_NAME, GROUP_ID, QUYEN)
        End Sub
        '-----------------------------------------------------------------
#End Region
    End Class