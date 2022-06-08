Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Security

Namespace VS.Object
    Public Class UserCtrl
#Region "Public Method"
        Public Function GetAllUser() As DataTable
            Dim TbUser As DataTable = New DataTable
            TbUser.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSERs"))
            Return TbUser
        End Function
        Public Function GetUsetOfGroup(ByVal GroupID As Integer) As DataTable
            Dim TbUser As DataTable = New DataTable
            TbUser.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSERofGROUPs", GroupID))
            Return TbUser
        End Function
        Public Function GetUser(ByVal UserName As String) As Commons.IUsers
            Dim TbUser As DataTable = New DataTable()
            TbUser.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER", UserName))
            Dim vUserInfo As Commons.IUsers = New Commons.IUsers()
            vUserInfo.UserName = TbUser.Rows(0)("USERNAME")
            vUserInfo.GroupID = TbUser.Rows(0)("GROUP_ID")
            vUserInfo.Password = TbUser.Rows(0)("PASS")
            vUserInfo.FullName = TbUser.Rows(0)("FULL_NAME")
            vUserInfo.Description = TbUser.Rows(0)("DESCRIPTION")
            Return vUserInfo
        End Function
        Public Function AddUser(ByVal vUserInfo As Commons.IUsers) As Object
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddUSER", _
                vUserInfo.UserName, vUserInfo.GroupID, vUserInfo.FullName, _
                vUserInfo.Password, vUserInfo.Description)
            Return vUserInfo.UserName
        End Function
        Public Sub UpdateUser(ByVal vUserInfo As Commons.IUsers)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateUSERNAME", _
                vUserInfo.UserName, vUserInfo.GroupID, vUserInfo.FullName, _
                vUserInfo.Password, vUserInfo.Description)
        End Sub
        Public Sub DeleteUser(ByVal vUserName As Object)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteUSER", vUserName)
        End Sub
        Public Function CheckUser(ByVal vUserName As Object, ByVal vPassword As Object) As Boolean
            Dim TbUser As DataTable = New DataTable()
            TbUser.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSER", vUserName))

            If TbUser.Rows.Count <= 0 Then
                Return False
            End If
            If clsXuLy.MaHoaDL(vPassword).Equals(TbUser.Rows(0)("PASS")) Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function ExistUser(ByVal vUserName As String) As DataTable
            Dim TbUser As DataTable = New DataTable()
            TbUser.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckUSERNAME", vUserName))
            Return TbUser
        End Function
#End Region
    End Class
End Namespace