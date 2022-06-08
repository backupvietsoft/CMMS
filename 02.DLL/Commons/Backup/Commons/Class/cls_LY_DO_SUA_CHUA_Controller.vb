Imports Microsoft.ApplicationBlocks.Data

Namespace VS.Classes.Catalogue
    Public Class cls_LY_DO_SUA_CHUA_Controller

        Public Sub New()
        End Sub

        Function Get_LY_DO() As DataTable
            Dim dttable As New DataTable
            dttable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "get_LY_DO_SUA_CHUA"))
            Return dttable
        End Function

        Sub add_LY_DO(ByVal obj_LY_DO_Info As cls_LY_DO_SUA_CHUA_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "add_LY_DO_SUA_CHUA", _
            obj_LY_DO_Info.TEN_LY_DO_VIET, obj_LY_DO_Info.TEN_LY_DO_ANH, obj_LY_DO_Info.TEN_LY_DO_HOA)
        End Sub

        Sub update_LY_DO(ByVal obj_LY_DO_Info As cls_LY_DO_SUA_CHUA_Info)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "update_LY_DO_SUA_CHUA", _
            obj_LY_DO_Info.STT, obj_LY_DO_Info.TEN_LY_DO_VIET, _
            obj_LY_DO_Info.TEN_LY_DO_ANH, obj_LY_DO_Info.TEN_LY_DO_HOA)
        End Sub

        Sub delete_LY_DO(ByVal LY_DO As Integer)
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "delete_LY_DO_SUA_CHUA", LY_DO)
        End Sub
    End Class
End Namespace

