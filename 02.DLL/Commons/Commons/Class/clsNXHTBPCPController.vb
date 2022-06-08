Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class NXHTBPCPController
        Public Sub New()

        End Sub

#Region "Public Method"
        Public Function GetMAY_HE_THONGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_HE_THONGs", Commons.Modules.UserName))
            Return objDataTable
        End Function
        Public Function GetNHA_XUONGs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNHA_XUONGs1", Commons.Modules.UserName))
            Return objDataTable
        End Function
        Public Function GetBO_PHAN_CHIU_PHIs() As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBoPhanChiuPhiUser", Commons.Modules.UserName))
            Return objDataTable
        End Function

        Public Function GetHE_THONGs() As DataTable
            Return Commons.Modules.ObjSystems.MLoadDataDayChuyen(0)
        End Function

        Public Function GetMAY_HE_THONG(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_HE_THONG", MS_MAY, Commons.Modules.UserName))
            Return objDataTable
        End Function
        Public Function GetMAY_HE_THONGSC(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_HE_THONG", MS_MAY, Commons.Modules.UserName))
            Return objDataTable
        End Function

        Public Function GetMAY_NHA_XUONG(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_NHA_XUONG1", MS_MAY, Commons.Modules.UserName))
            Return objDataTable
        End Function
        Public Function GetMAY_NHA_XUONGSC(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_NHA_XUONG1", MS_MAY, Commons.Modules.UserName))
            Return objDataTable
        End Function

        Public Function GetMAY_BPCP(ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_BPCP", MS_MAY, Commons.Modules.UserName))
            Return objDataTable
        End Function

        Public Function GetMAY_BPCPSC(ByVal Sqltran As SqlTransaction, ByVal MS_MAY As String) As DataTable
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Sqltran, "GetMAY_BPCP", MS_MAY, Commons.Modules.UserName))
            Return objDataTable
        End Function

        Public Function AddMAY_HE_THONG(ByVal Sqltran As SqlTransaction, ByVal objMAY_HE_THONGInfo As MAY_HE_THONGInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddMAY_HE_THONG", _
                objMAY_HE_THONGInfo.MS_MAY, objMAY_HE_THONGInfo.NGAY_NHAP, objMAY_HE_THONGInfo.MS_HE_THONG)
            Return True
        End Function
        Public Function AddMAY_NHA_XUONG(ByVal Sqltran As SqlTransaction, ByVal objMAY_NHA_XUONGInfo As MAY_NHA_XUONGInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddMAY_NHA_XUONG", _
                objMAY_NHA_XUONGInfo.MS_MAY, objMAY_NHA_XUONGInfo.NGAY_NHAP, objMAY_NHA_XUONGInfo.MS_N_XUONG)
            Return True
        End Function
        Public Function AddMAY_BPCP(ByVal Sqltran As SqlTransaction, ByVal objMAY_BPCPInfo As MAY_BO_PHAN_CHIU_PHIInfo) As String
            SqlHelper.ExecuteScalar(Sqltran, "AddMAY_BPCP", _
                objMAY_BPCPInfo.MS_MAY, objMAY_BPCPInfo.NGAY_NHAP, objMAY_BPCPInfo.MS_BP_CHIU_PHI)
            Return True
        End Function

        Public Sub UpdateMAY_HE_THONG(ByVal objNXHTBPCPInfo As NXHTBPCPInfo)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UpdateMAY_HE_THONG", _
                objNXHTBPCPInfo.MS_MAY, objNXHTBPCPInfo.NGAY_NHAP, objNXHTBPCPInfo.MS_HE_THONG)
        End Sub

        Public Sub DeleteMAY_HE_THONG(ByVal MS_MAY As String, ByVal NGAY_NHAP As Date)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteMAY_HE_THONG", MS_MAY, NGAY_NHAP)
        End Sub
        Public Sub DeleteMAY_BPCP(ByVal MS_MAY As String, ByVal NGAY_NHAP As Date)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteMAY_BPCP", MS_MAY, NGAY_NHAP)
        End Sub
        Public Sub DeleteMAY_NHA_XUONG(ByVal MS_MAY As String, ByVal NGAY_NHAP As Date)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteMAY_NHA_XUONG", MS_MAY, NGAY_NHAP)
        End Sub

#End Region
    End Class
End Namespace
