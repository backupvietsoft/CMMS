Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace VS.Classes.Catalogue
    Public Class clsPHIEU_BAO_TRI_SERVICEController
        Public Sub New()
        End Sub

#Region "Methods"
        Function TaoDLChonServiceChung_Mnr(ByVal strMsPhieuBT As String, ByVal dtTungay As Date, ByVal dtDenNgay As Date) As DataTable
            Dim dtTable As New DataTable
            Try
                commons.Modules.SQLString = "DROP TABLE CHON_DICH_VU" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            Catch ex As Exception

            End Try
            commons.Modules.SQLString = "SELECT EOR.EOR_ID, STT, MS_MAY, SO_ROA, NGAY_ROA, NOI_DUNG_SERVICE, 'Dich vu chung' AS LOAI_DV, " & _
                " CONVERT(BIT,0) as MNR, EOR_SERVICE_CHUNG.MS_KH,TEN_RUT_GON, NGUOI_GIAO_DICH, SO_LUONG, DON_GIA, NGOAI_TE,  TY_GIA,  " & _
                " TY_GIA_USD, CONVERT(BIT,0) as CHON INTO CHON_DICH_VU" & Commons.Modules.UserName & _
                " FROM EOR INNER JOIN EOR_SERVICE_CHUNG ON EOR.EOR_ID = EOR_SERVICE_CHUNG.EOR_ID LEFT JOIN KHACH_HANG ON  " & _
                " EOR_SERVICE_CHUNG.MS_KH = KHACH_HANG.MS_KH WHERE DUYET=1 AND  ( MS_PHIEU_BAO_TRI IS NULL OR MS_PHIEU_BAO_TRI ='') AND  SO_ROA IS NOT NULL   " & _
                " AND NGAY_ROA BETWEEN '" & Format(dtTungay, "MM/dd/yyyy") & "' AND '" & Format(dtDenNgay, "MM/dd/yyyy") & "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

            commons.Modules.SQLString = "INSERT INTO CHON_DICH_VU" & Commons.Modules.UserName & " (EOR_ID, STT,MS_MAY, SO_ROA, NGAY_ROA, NOI_DUNG_SERVICE, " & _
                " LOAI_DV, MNR, MS_KH,TEN_RUT_GON, NGUOI_GIAO_DICH, SO_LUONG, DON_GIA, NGOAI_TE,  TY_GIA, TY_GIA_USD, CHON ) " & _
                " SELECT EOR_SERVICE_MNR.EOR_ID, STT, MS_MAY, SO_ROA, NGAY_ROA, NOI_DUNG_SERVICE, 'Dich vu Mnr' AS LOAI_DV, " & _
                " CONVERT(BIT,1) as MNR, EOR_SERVICE_MNR.MS_KH,TEN_RUT_GON, NGUOI_GIAO_DICH, SO_LUONG, DON_GIA, NGOAI_TE, TY_GIA,  " & _
                " TY_GIA_USD, CONVERT(BIT,0) as CHON " & _
                " FROM EOR INNER JOIN EOR_SERVICE_MNR ON EOR.EOR_ID = EOR_SERVICE_MNR.EOR_ID LEFT JOIN KHACH_HANG ON " & _
                " EOR_SERVICE_MNR.MS_KH = KHACH_HANG.MS_KH WHERE DUYET=1 AND  (MS_PHIEU_BAO_TRI IS NULL OR MS_PHIEU_BAO_TRI ='') AND  SO_ROA IS NOT NULL AND " & _
                " NGAY_ROA BETWEEN '" & Format(dtTungay, "MM/dd/yyyy") & "' AND '" & Format(dtDenNgay, "MM/dd/yyyy") & "' " & _
                " AND MS_MAY IN (SELECT MS_MAY FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI='" & strMsPhieuBT & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

            commons.Modules.SQLString = "SELECT * FROM CHON_DICH_VU" & Commons.Modules.UserName
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString))
            commons.Modules.SQLString = "Drop table CHON_DICH_VU" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
            Return dtTable

        End Function

        Function CapNhatDuLieuDVChon(ByVal dt As DataTable, ByVal strMsPBT As String, ByVal intRowDVTN As Integer) As Boolean
            Dim i As Integer, intSTT As Integer
            intSTT = GetMaxSTT(strMsPBT)
            If intSTT = -1 Then Return False

            For i = 0 To dt.Rows.Count - 1
                If i > intRowDVTN Then
                    With dt.Rows(i)
                        intSTT = intSTT + 1 'IIf(IsDBNull(.Item("STT_EOR")), intSTT + 1, .Item("STT_EOR"))
                        'If .Item("CHON") = True Then
                        'insert vao table PHIEU_BAO_TRI_SERVICE 
                        Dim bLoai As Byte
                        'If .Item("MNR") Then
                        '    bLoai = 1
                        'Else
                        '    bLoai = 0
                        'End If
                        Dim tmp As String, tmp1 As String
                        'If IsDBNull(.Item("MS_KH")) Then
                        '    tmp = "null"
                        'Else
                        '    tmp = .Item("MS_KH")
                        'End If
                        If IsDBNull(.Item("MS_KH")) Then
                            tmp = "null"
                        Else
                            tmp = .Item("MS_KH")
                        End If
                        If IsDBNull(.Item("NGUOI_GIAO_DICH")) Then
                            tmp1 = "null"
                        Else
                            tmp1 = .Item("NGUOI_GIAO_DICH")
                        End If
                        If tmp = "null" Then
                            'commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_SERVICE(MS_PHIEU_BAO_TRI,  " & _
                            '" NOI_DUNG_SERVICE, MS_KH, NGUOI_GIAO_DICH, SO_LUONG, DON_GIA,  NGOAI_TE, TY_GIA, " & _
                            '" TY_GIA_USD, EOR_ID,STT_EOR, MNR) VALUES(N'" & strMsPBT & _
                            '"',N'" & .Item("NOI_DUNG_SERVICE") & "'," & tmp & " ," & _
                            'tmp1 & " ," & .Item("SO_LUONG") & "," & .Item("DON_GIA") & "," & _
                            '" '" & .Item("NGOAI_TE") & "'," & .Item("TY_GIA") & "," & .Item("TY_GIA_USD") & "," & _
                            '" '" & .Item("EOR_ID") & "','" & .Item("STT_EOR") & "','" & bLoai & "' ) "

                            'commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_SERVICE(MS_PHIEU_BAO_TRI,NOI_DUNG_SERVICE,MS_KH,NGUOI_GIAO_DICH,SO_LUONG,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD,EOR_ID,STT_EOR,MNR) " & _
                            '         "VALUES(N'" & strMsPBT & "',N'" & .Item("NOI_DUNG_SERVICE") & "'," & tmp & " ," & tmp1 & " ," & .Item("SO_LUONG") & "," & .Item("DON_GIA") & ",'" & _
                            '                 .Item("NGOAI_TE") & "'," & .Item("TY_GIA") & "," & .Item("TY_GIA_USD") & ",'" & .Item("EOR_ID") & "','" & intSTT & "','" & bLoai & "') "
                            commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_SERVICE(MS_PHIEU_BAO_TRI,NOI_DUNG_SERVICE,MS_KH,NGUOI_GIAO_DICH,SO_LUONG,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD,EOR_ID,STT_EOR,MNR) " & _
                                     "VALUES(N'" & strMsPBT & "',N'" & .Item("NOI_DUNG_SERVICE") & "'," & tmp & " ," & tmp1 & " ," & .Item("SO_LUONG") & "," & .Item("DON_GIA") & ",'" & _
                                              "VND'," & .Item("TY_GIA") & "," & .Item("TY_GIA_USD") & ",'" & .Item("EOR_ID") & "','" & intSTT & "','" & bLoai & "') "
                        Else
                            ' commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_SERVICE(MS_PHIEU_BAO_TRI,  " & _
                            '" NOI_DUNG_SERVICE, MS_KH, NGUOI_GIAO_DICH, SO_LUONG, DON_GIA,  NGOAI_TE, TY_GIA, " & _
                            '" TY_GIA_USD, EOR_ID,STT_EOR, MNR) VALUES(N'" & strMsPBT & _
                            '"',N'" & .Item("NOI_DUNG_SERVICE") & "','" & tmp & "' ," & _
                            'tmp1 & " ," & .Item("SO_LUONG") & "," & .Item("DON_GIA") & "," & _
                            '" '" & .Item("NGOAI_TE") & "'," & .Item("TY_GIA") & "," & .Item("TY_GIA_USD") & "," & _
                            '" '" & .Item("EOR_ID") & "','" & .Item("STT_EOR") & "','" & bLoai & "' ) "


                            If IsDBNull(.Item("STT_EOR")) Then
                                'commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_SERVICE(MS_PHIEU_BAO_TRI,NOI_DUNG_SERVICE,MS_KH,NGUOI_GIAO_DICH,SO_LUONG,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD,EOR_ID,STT_EOR,MNR) " & _
                                '         "VALUES(N'" & strMsPBT & "',N'" & .Item("NOI_DUNG_SERVICE") & "','" & tmp & "' ," & tmp1 & " ," & .Item("SO_LUONG") & "," & .Item("DON_GIA") & ",'" & _
                                '                    .Item("NGOAI_TE") & "'," & IIf(IsDBNull(.Item("TY_GIA")), "NULL", .Item("TY_GIA")) & "," & IIf(IsDBNull(.Item("TY_GIA_USD")), "NULL", .Item("TY_GIA_USD")) & ",'" & .Item("EOR_ID") & "'," & intSTT & ",'" & bLoai & "' ) "

                                'THÊM VÀO PHIEU_BAO_TRI_SERVICE TRUOC
                                commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_SERVICE(MS_PHIEU_BAO_TRI,NOI_DUNG_SERVICE,MS_KH,NGUOI_GIAO_DICH,SO_LUONG,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD,EOR_ID,STT_EOR,MNR) " & _
                                         "VALUES(N'" & strMsPBT & "',N'" & .Item("NOI_DUNG_SERVICE") & "','" & tmp & "' ," & tmp1 & " ," & .Item("SO_LUONG") & "," & .Item("DON_GIA") & ",'" & _
                                                    "VND'," & IIf(IsDBNull(.Item("TY_GIA")), "NULL", .Item("TY_GIA")) & "," & IIf(IsDBNull(.Item("TY_GIA_USD")), "NULL", .Item("TY_GIA_USD")) & ",'" & .Item("EOR_ID") & "'," & intSTT & ",'" & bLoai & "' ) "
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                                'KIEM TRA NEU CO CHON DIEM THI GHI VAO BANG PHIEU_BAO_TRI_DANH_GIA_SERVICE
                                'Dim dtReader As SqlDataReader
                                'Dim STT_EOR As Long = -1
                                'dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MAX(STT) AS STT_EOR FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "'")
                                'While dtReader.Read
                                '    STT_EOR = dtReader.Item("STT_EOR")  'lấy số stt_eor vừa được ghi vào
                                'End While
                                'dtReader.Close()

                                ''thêm vào bảng PHIEU_BAO_TRI_DANH_GIA_SERVICE
                                'For i As Integer = 0 To FrmPhieuBaoTri.grdDanhGiaDV.Rows.Count - 1
                                '    If FrmPhieuBaoTri.grdDanhGiaDV.Rows(i).Cells("DIEM").Value > 0 Then
                                '        SQLHELPER.ExecuteScalar(Commons.IConnections.ConnectionString,CommandType.Text,"INSERT INTO PHIEU_BAO_TRI_DANH_GIA_SERVICE
                                '    End If
                                'Next





                            Else
                                commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_SERVICE SET MS_PHIEU_BAO_TRI='" & strMsPBT & "',NOI_DUNG_SERVICE=N'" & .Item("NOI_DUNG_SERVICE") & "',MS_KH='" & tmp & "',NGUOI_GIAO_DICH=" & tmp1 & _
                                                                        ",SO_LUONG=" & .Item("SO_LUONG") & ",DON_GIA=" & .Item("DON_GIA") & ",NGOAI_TE='" & .Item("NGOAI_TE") & "',TY_GIA=" & IIf(IsDBNull(.Item("TY_GIA")), "NULL", .Item("TY_GIA")) & _
                                                                        ",TY_GIA_USD=" & IIf(IsDBNull(.Item("TY_GIA_USD")), "NULL", .Item("TY_GIA_USD")) & ",EOR_ID='" & .Item("EOR_ID") & "',STT_EOR=" & .Item("STT_EOR") & ",MNR='" & bLoai & "'"
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                            End If
                        End If
                        'Cap nhat ma so phieu bao tri vao
                        If bLoai = 0 Then
                            commons.Modules.SQLString = "UPDATE EOR_SERVICE_CHUNG SET MS_PHIEU_BAO_TRI='" & strMsPBT & "' " & _
                                " WHERE EOR_ID='" & .Item("EOR_ID") & "' AND STT=" & IIf(IsDBNull(.Item("STT_EOR")), intSTT, .Item("STT_EOR"))
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        Else
                            commons.Modules.SQLString = "UPDATE EOR_SERVICE_MNR SET MS_PHIEU_BAO_TRI='" & strMsPBT & "' " & _
                                " WHERE EOR_ID='" & .Item("EOR_ID") & "' AND STT=" & IIf(IsDBNull(.Item("STT_EOR")), intSTT, .Item("STT_EOR")) ' & .Item("STT_EOR")
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                        End If
                    End With
                End If
            Next
            Return True
        End Function

        Function XoaDuLieuDV(ByVal strMsPBT As String, ByVal intSTT As Integer, ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String) As Boolean
            Try
                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND STT_SERVICE=" & intSTT
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" & strMsPBT & "' AND STT_EOR=" & intSTT
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND STT=" & intSTT
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        Function XoaDuLieuDV(ByVal strMsPBT As String, ByVal intSTT As Integer) As Boolean ', ByVal MS_CV As Integer, ByVal MS_BO_PHAN As String) As Boolean
            Try
                'commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "'"
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                'commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "'"
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                'commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND MS_CV=" & MS_CV & " AND MS_BO_PHAN='" & MS_BO_PHAN & "' AND STT_SERVICE=" & intSTT
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                'commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" & strMsPBT & "' AND STT_EOR=" & intSTT
                'SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)

                commons.Modules.SQLString = "DELETE FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "' AND STT=" & intSTT
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        Function GetMaxSTT(ByVal strMsPBT As String) As Integer
            Try
                Dim intSTT As Integer
                Dim reader As SqlDataReader

                intSTT = 0
                '                commons.Modules.SQLString = "SELECT isnull(MAX(STT),0) AS STT_MAX FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "'"
                commons.Modules.SQLString = "SELECT isnull(MAX(STT_EOR),0) AS STT_MAX FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" & strMsPBT & "'"
                reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, commons.Modules.SQLString)
                If reader.Read Then
                    intSTT = reader.Item("STT_MAX")
                End If
                reader.Close()
                Return intSTT
            Catch ex As Exception
                Return -1
            End Try

        End Function

        Function GetDanhsachDVThueNgoai(ByVal strMsPBT As String) As DataTable
            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
                            "GetDanhsachDVThueNgoai", strMsPBT))
            Return dtTable
        End Function


#End Region

    End Class
End Namespace

