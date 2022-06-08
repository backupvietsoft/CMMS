Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class clsCongNhanMay
    Private _MS_MAY As String
    Private _MS_CONG_NHAN As String
    Private _GHI_CHU As String

    Public Property MS_MAY() As String
        Get
            Return _MS_MAY
        End Get
        Set(ByVal value As String)
            _MS_MAY = value
        End Set
    End Property
    Public Property MS_CONG_NHAN() As String
        Get
            Return _MS_CONG_NHAN
        End Get
        Set(ByVal value As String)
            _MS_CONG_NHAN = value
        End Set
    End Property
    Public Property GHI_CHU() As String
        Get
            Return _GHI_CHU
        End Get
        Set(ByVal value As String)
            _GHI_CHU = value
        End Set
    End Property

    Sub New()

    End Sub
    Public Function LoadDataThietBi() As DataTable
        Dim dtTmp As DataTable = New DataTable
        Commons.Modules.SQLString = "SELECT M.MS_MAY, M.TEN_MAY, LM.TEN_LOAI_MAY, NM.TEN_NHOM_MAY, MNX.TEN_N_XUONG, M.MO_TA " & _
            " FROM MAY M  INNER JOIN NHOM_MAY NM ON M.MS_NHOM_MAY=NM.MS_NHOM_MAY " & _
            " INNER JOIN LOAI_MAY LM ON NM.MS_LOAI_MAY=LM.MS_LOAI_MAY " & _
            " INNER JOIN vwDS_NHA_XUONG_NGAY_MAX MNX ON M.MS_MAY=MNX.MS_MAY " & _
            " ORDER BY M.MS_MAY, M.TEN_MAY"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        Return dtTmp
    End Function
    Public Function LoadDataCongNhan() As DataTable
        Dim dtTmp As DataTable = New DataTable
        Commons.Modules.SQLString = "SELECT MCN.MS_CONG_NHAN, CN.HO + ' ' + CN.TEN AS HO_TEN, MCN.GHI_CHU, MCN.MS_MAY, CONVERT(NVARCHAR(1),'N') AS THAO_TAC " & _
                " FROM MAY_CONG_NHAN MCN INNER JOIN CONG_NHAN CN ON MCN.MS_CONG_NHAN=CN.MS_CONG_NHAN"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        dtTmp.Columns("THAO_TAC").ReadOnly = False
        dtTmp.Columns("GHI_CHU").ReadOnly = False
        Return dtTmp
    End Function
    Public Sub Add(ByVal FORM_NAME As String)
        If _MS_MAY.Length = 0 Or _MS_CONG_NHAN.Length = 0 Then Exit Sub
        Commons.Modules.SQLString = "INSERT INTO MAY_CONG_NHAN (MS_MAY, MS_CONG_NHAN, GHI_CHU)" & _
            " VALUES(N'" & _MS_MAY & "','" & _MS_CONG_NHAN & "','" & _GHI_CHU & "') "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        'UpdateMAY_CONG_NHAN_LOG
        Commons.Modules.SQLString = "exec UpdateMAY_CONG_NHAN_LOG '" & _MS_MAY & "','" & _MS_CONG_NHAN & "','" & FORM_NAME & "','" & Commons.Modules.UserName & "',1"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub
    Public Function Exist() As Boolean
        Dim i As String
        Commons.Modules.SQLString = "SELECT MS_MAY FROM MAY_CONG_NHAN WHERE MS_MAY=N'" & _MS_MAY & _
            "' AND MS_CONG_NHAN='" & _MS_CONG_NHAN & "' "
        i = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        If i Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub Update(ByVal FORM_NAME As String)
        If _MS_MAY.Length = 0 Or _MS_CONG_NHAN.Length = 0 Then Exit Sub
        Commons.Modules.SQLString = "exec UpdateMAY_CONG_NHAN_LOG '" & _MS_MAY & "','" & _MS_CONG_NHAN & "','" & FORM_NAME & "','" & Commons.Modules.UserName & "',2"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "UPDATE  MAY_CONG_NHAN  SET GHI_CHU='" & _GHI_CHU & "' WHERE MS_MAY=N'" & _MS_MAY & _
            "' AND MS_CONG_NHAN='" & _MS_CONG_NHAN & "' "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub
    Public Sub DeleteOneRow(ByVal FORM_NAME As String)
        If _MS_MAY.Length = 0 Or _MS_CONG_NHAN.Length = 0 Then Exit Sub
        Commons.Modules.SQLString = "exec UpdateMAY_CONG_NHAN_LOG '" & _MS_MAY & "','" & _MS_CONG_NHAN & "','" & FORM_NAME & "','" & Commons.Modules.UserName & "',3"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "DELETE FROM MAY_CONG_NHAN  WHERE MS_MAY=N'" & _MS_MAY & _
            "' AND MS_CONG_NHAN='" & _MS_CONG_NHAN & "' "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub
    Public Sub DeleteOneMS_MAY()
        If _MS_MAY.Length = 0 Then Exit Sub
        Commons.Modules.SQLString = "DELETE FROM MAY_CONG_NHAN  WHERE MS_MAY=N'" & _MS_MAY & _
            "' "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub
    Public Sub Delete()
        If _MS_MAY.Length = 0 Or _MS_CONG_NHAN.Length = 0 Then Exit Sub
        Commons.Modules.SQLString = "DELETE MAY_CONG_NHAN WHERE MS_MAY=N'" & _MS_MAY & _
                "' AND MS_CONG_NHAN='" & _MS_CONG_NHAN & "' "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub

    Public Function GetThongTinChung() As DataTable

        Dim vTbTTC As New Data.DataTable
        Dim vStrTTC As String = "SELECT * from THONG_TIN_CHUNG "
        vTbTTC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, vStrTTC))
        Return vTbTTC
    End Function

    Public Function GetDataPrint() As DataTable

        Dim vTbTTC As New Data.DataTable
        vTbTTC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getPhanCongBaoTriMay", DateTime.Now.Date))
        Return vTbTTC

    End Function

End Class
