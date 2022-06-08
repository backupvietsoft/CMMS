Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsPHIEU_BAO_TRI_CONG_VIECController
        Public Sub New()
        End Sub

#Region "Methods"
        Function getPHIEU_BAO_TRI_CONG_VIEC_NHAN_SUs(ByVal PhieuBT As String, ByVal IntMSCV As Integer, ByVal strMsBP As String) As DataTable
            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                "getPHIEU_BAO_TRI_CONG_VIEC_NHAN_SUs", PhieuBT, IntMSCV, strMsBP))
            Return dtTable
        End Function

        Function getPHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SUs(ByVal PhieuBT As String, ByVal IntSTT As Integer) As DataTable
            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                "getPHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SUs", PhieuBT, IntSTT))
            Return dtTable
        End Function

        Function TaoDLThemCvPhu(ByVal PhieuBT As String, ByVal IntSTT As Integer, ByVal intMsTo As Integer)
            Dim dtTable As New DataTable
            Try
                commons.Modules.SQLString = "DROP TABLE PBT_CV_PHU_NS" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            Catch ex As Exception

            End Try
            'lay nhung du lieu nhung cong nhan da co
            commons.Modules.SQLString = "SELECT MS_PHIEU_BAO_TRI, STT, CONVERT (BIT,1) AS CHON ,PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU.MS_CONG_NHAN ," & _
                " HO + ' ' + TEN AS HOTEN INTO dbo.PBT_CV_PHU_NS" & Commons.Modules.UserName & _
                " FROM PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU INNER JOIN CONG_NHAN ON " & _
                " PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU.MS_CONG_NHAN =  CONG_NHAN.MS_CONG_NHAN " & _
                " WHERE MS_PHIEU_BAO_TRI='" & PhieuBT & "' AND STT=" & IntSTT
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

            'Them moi cong nhan
            commons.Modules.SQLString = "INSERT INTO dbo.PBT_CV_PHU_NS" & Commons.Modules.UserName & "(MS_PHIEU_BAO_TRI, STT, CHON, MS_CONG_NHAN, HOTEN )" & _
                " SELECT '" & PhieuBT & "'," & IntSTT & " , CONVERT (BIT,0) , CONG_NHAN.MS_CONG_NHAN, " & _
                " HO + ' ' + TEN FROM CONG_NHAN WHERE MS_TO=" & intMsTo & " AND MS_CONG_NHAN NOT IN " & _
                    " (SELECT DISTINCT MS_CONG_NHAN FROM dbo.PBT_CV_PHU_NS" & Commons.Modules.UserName & _
                    " WHERE MS_PHIEU_BAO_TRI='" & PhieuBT & "' AND STT=" & IntSTT & ")"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

            commons.Modules.SQLString = "SELECT * FROM PBT_CV_PHU_NS" & Commons.Modules.UserName
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
            'Try
            '    commons.Modules.SQLString = "DROP TABLE PBT_CV_PHU_NS" & Commons.Modules.UserName
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            'Catch ex As Exception

            'End Try
            Return dtTable
        End Function

        Function TaoDLThemCvChinh(ByVal PhieuBT As String, ByVal IntMSCV As Integer, ByVal strMsBoPhan As String, ByVal intMsTo As Integer, Optional ByVal intChuyenMon As Integer = 0) As DataTable
            Dim dtTable As New DataTable
            Try
                commons.Modules.SQLString = "DROP TABLE PBT_CV_CHINH_NS" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            Catch ex As Exception

            End Try
            'lay nhung du lieu nhung cong nhan da co
            commons.Modules.SQLString = " SELECT MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, CONVERT(BIT,1) as CHON, " & _
                " PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU.MS_CONG_NHAN, HO + ' ' + TEN AS HOTEN " & _
                " INTO dbo.PBT_CV_CHINH_NS" & Commons.Modules.UserName & " FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU INNER JOIN CONG_NHAN ON  " & _
                " PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU.MS_CONG_NHAN = CONG_NHAN.MS_CONG_NHAN " & _
                " WHERE MS_PHIEU_BAO_TRI='" & PhieuBT & "' AND MS_CV=" & IntMSCV
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

            'Them moi cong nhan
            If intChuyenMon = 0 Then
                commons.Modules.SQLString = "INSERT INTO dbo.PBT_CV_CHINH_NS" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, CHON, MS_CONG_NHAN, HOTEN)" & _
                    " SELECT '" & PhieuBT & "'," & IntMSCV & ",'" & strMsBoPhan & "',0, MS_CONG_NHAN, HO + ' ' + TEN FROM CONG_NHAN " & _
                    " WHERE MS_TO=" & intMsTo & _
                    " AND MS_CONG_NHAN NOT IN (SELECT DISTINCT MS_CONG_NHAN FROM PBT_CV_CHINH_NS" & Commons.Modules.UserName & ") "
            Else
                commons.Modules.SQLString = "INSERT INTO dbo.PBT_CV_CHINH_NS" & Commons.Modules.UserName & " (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, CHON, MS_CONG_NHAN, HOTEN)" & _
                    " SELECT '" & PhieuBT & "'," & IntMSCV & ",'" & strMsBoPhan & "',0, MS_CONG_NHAN, HO + ' ' + TEN FROM CONG_NHAN " & _
                    " WHERE MS_TO=" & intMsTo & _
                    " AND MS_CONG_NHAN NOT IN (SELECT DISTINCT MS_CONG_NHAN FROM PBT_CV_CHINH_NS" & Commons.Modules.UserName & ") AND " & _
                    " MS_CONG_NHAN IN (SELECT DISTINCT MS_CONG_NHAN FROM CONG_NHAN_CHUYEN_MON WHERE MS_CHUYEN_MON=" & intChuyenMon & ")"
            End If
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

            commons.Modules.SQLString = "SELECT * FROM PBT_CV_CHINH_NS" & Commons.Modules.UserName
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
            'Try
            '    commons.Modules.SQLString = "DROP TABLE PBT_CV_CHINH_NS" & Commons.Modules.UserName
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            'Catch ex As Exception

            'End Try
            Return dtTable
        End Function

        Function CapNhatDLCvChinh(ByVal dt As DataTable, ByVal PhieuBT As String, ByVal IntMSCV As Integer) As Boolean
            Try
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    With dt.Rows(i)
                        commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU " & _
                            " WHERE MS_PHIEU_BAO_TRI = '" & .Item("MS_PHIEU_BAO_TRI").ToString & "' AND " & _
                            " MS_CV = " & .Item("MS_CV").ToString & " AND MS_BO_PHAN='" & .Item("MS_BO_PHAN").ToString & "' " & _
                            " AND MS_CONG_NHAN ='" & .Item("MS_CONG_NHAN").ToString & "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        If .Item("CHON") Then
                            commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_CONG_NHAN)" & _
                                " VALUES(N'" & .Item("MS_PHIEU_BAO_TRI").ToString & "'," & .Item("MS_CV").ToString & _
                                ",'" & .Item("MS_BO_PHAN").ToString & "','" & .Item("MS_CONG_NHAN").ToString & "') "
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        End If

                    End With

                Next
                CapNhatDLCvChinh = True
            Catch ex As Exception
                ex.Message.ToString()
                CapNhatDLCvChinh = False

            End Try
        End Function

        Function CapNhatDLCvPhu(ByVal dt As DataTable, ByVal PhieuBT As String, ByVal IntSTT As Integer) As Boolean
            Try
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    With dt.Rows(i)
                        commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU " & _
                            " WHERE MS_PHIEU_BAO_TRI = '" & .Item("MS_PHIEU_BAO_TRI").ToString & "' AND " & _
                            " STT = " & .Item("STT").ToString & " AND MS_CONG_NHAN ='" & .Item("MS_CONG_NHAN").ToString & "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        If .Item("CHON") Then
                            commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU (MS_PHIEU_BAO_TRI, STT, MS_CONG_NHAN) " & _
                                " VALUES(N'" & .Item("MS_PHIEU_BAO_TRI").ToString & "'," & .Item("STT").ToString & _
                                ",'" & .Item("MS_CONG_NHAN").ToString & "') "
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        End If
                    End With
                Next
                Return True
            Catch ex As Exception
                ex.Message.ToString()
                Return False

            End Try
        End Function

        Function DeleteCongViecChinhNhanSu(ByVal PhieuBT As String, ByVal IntMSCV As Integer, ByVal MS_BO_PHAN As String, ByVal MS_CONG_NHAN As String) As Boolean
            Try
                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & PhieuBT & "' AND MS_CV='" & IntMSCV & "' AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND MS_CONG_NHAN='" & MS_CONG_NHAN & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                Return True
            Catch ex As Exception
                ex.Message.ToString()
                Return False
            End Try
        End Function

        Function DeleteCongViecPhuNhanSu(ByVal PhieuBT As String, ByVal IntSTT As Integer, ByVal MS_CONG_NHAN As String) As Boolean
            Try
                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & PhieuBT & "' AND STT='" & IntSTT & "' AND MS_CONG_NHAN='" & MS_CONG_NHAN & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                Return True
            Catch ex As Exception
                ex.Message.ToString()
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

