Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmChonTGCM
    Public MsMay As String


    Private Sub BtnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThucHien.Click
        Try

            If txtSGLuyKe.Text = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaNhapSGio", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If
            If Double.Parse(txtSGLuyKe.Text) = 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgSGioLonHon0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            Dim dNgay As Date
            Try
                dNgay = Date.Parse(dtNgaySGLK.Text)
            Catch ex As Exception
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgNgay0Dung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End Try
            'If Commons.Modules.sPrivate <> "BARIA" Then

            'Else
            If TinhSGLK(dNgay) Then Close()
            'End If
        Catch ex As Exception

        End Try

    End Sub


    Function TinhSGLK(ByVal NgaySGLK As Date) As Boolean
        Dim sSql As String

        Dim dNgay As Date
        Dim dSGLK As Double
        Dim sNgayWhere As String
        Dim bOk As Boolean = False


        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        sNgayWhere = " CONVERT(DATETIME,CONVERT(NVARCHAR(10), NGAY, 101) + ' ' + CONVERT(NVARCHAR(8), NGAY, 108)) "

        Dim dtTmp As New DataTable
        sSql = "SELECT * FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY = '" & MsMay & "' AND " & sNgayWhere & " = '" & NgaySGLK.ToString("MM/dd/yyyy HH:mm:ss") & "' "
        dtTmp.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sSql))
        If dtTmp.Rows.Count <= 0 Then
            sSql = "INSERT INTO [THOI_GIAN_CHAY_MAY]([MS_MAY],[NGAY],[CHI_SO_DONG_HO],[SO_GIO_LUY_KE], [USERNAME]) " &
                            " VALUES ( N'" & MsMay & "', N'" & NgaySGLK.ToString("MM/dd/yyyy HH:mm:ss") & "', 0 ," & txtSGLuyKe.Text & ", '" & Commons.Modules.UserName & "')"
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
        Else
            If (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgDuLieuCSDHDaTonTaiBanMuonCapNhap", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.No Then
                objTrans.Rollback()
                Return False
            Else
                sSql = " UPDATE THOI_GIAN_CHAY_MAY SET SO_GIO_LUY_KE = " & txtSGLuyKe.Text & ", USERNAME = '" & Commons.Modules.UserName & "' 
                        WHERE MS_MAY = '" & MsMay & "' " &
                            " AND CONVERT(DATETIME,CONVERT(NVARCHAR(10), NGAY, 101) + ' ' + CONVERT(NVARCHAR(8), NGAY, 108)) = '" & NgaySGLK.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
            End If
        End If

        Try

            dNgay = NgaySGLK
            dSGLK = Double.Parse(txtSGLuyKe.Text)

            Dim dSGLKTruoc As Double
            'lay du lieu truoc
            sSql = "SELECT * FROM THOI_GIAN_CHAY_MAY T1 INNER JOIN  " & _
                        " (SELECT MS_MAY, MAX(NGAY) NGAY_MAX FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY = '" & MsMay & "' AND NGAY < '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' GROUP BY MS_MAY) T2 ON " & _
                        " T1.MS_MAY = T2.MS_MAY And NGAY = NGAY_MAX "
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sSql))

            If dtTmp.Rows.Count > 0 Then
                dSGLKTruoc = Double.Parse(dtTmp.Rows(0)("SO_GIO_LUY_KE"))
                'CHI_SO_ONG_HO= chỉ số lũy kế n – chỉ số lũy kế (n-1)., 
                Dim dDSDH As Double
                dDSDH = dSGLK - dSGLKTruoc
                If dDSDH < 0 Then
                    If (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgDuLieuDongHoDoAmBanMuonTiepTuc", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.No Then
                        objTrans.Rollback()
                        Return False
                    Else
                        bOk = True
                    End If
                    dDSDH = dSGLK
                End If
                'CHI_SO_ONG_HO= chỉ số lũy kế n – chỉ số lũy kế (n-1)., 
                sSql = " UPDATE THOI_GIAN_CHAY_MAY SET CHI_SO_DONG_HO = " & dDSDH.ToString & " , USERNAME = '" & Commons.Modules.UserName & "'  WHERE MS_MAY = '" & MsMay & "' " &
                                " AND " & sNgayWhere & " = '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
1:              'lay du lieu Ke


                sSql = " SELECT * FROM THOI_GIAN_CHAY_MAY T1 INNER JOIN " & _
                                    " (SELECT MS_MAY, MIN(NGAY) NGAY_MIN FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY = '" & MsMay & "' AND " + sNgayWhere + " > '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' GROUP BY MS_MAY) T2 ON  " & _
                                    " T1.MS_MAY = T2.MS_MAY AND NGAY = NGAY_MIN "
                dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sSql))
                If dtTmp.Rows.Count > 0 Then
                    dDSDH = Double.Parse(dtTmp.Rows(0)("SO_GIO_LUY_KE")) - dSGLK
                    If dDSDH < 0 Then
                        If bOk = False Then
                            If (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgDuLieuDongHoDoAmBanMuonTiepTuc", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.No Then
                                objTrans.Rollback()
                                Return False
                            Else
                                bOk = True
                            End If
                            dDSDH = Double.Parse(dtTmp.Rows(0)("SO_GIO_LUY_KE"))
                        End If
                    End If

                    dNgay = dtTmp.Rows(0)("NGAY")
                    sSql = " UPDATE THOI_GIAN_CHAY_MAY SET CHI_SO_DONG_HO = " & dDSDH.ToString & " , USERNAME = '" & Commons.Modules.UserName & "'  WHERE MS_MAY = '" & MsMay & "' " &
                                    " AND CONVERT(DATETIME,CONVERT(NVARCHAR(10), NGAY, 101) + ' ' + CONVERT(NVARCHAR(8), NGAY, 108)) = '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                    SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
                End If
            Else
                sSql = " UPDATE THOI_GIAN_CHAY_MAY SET CHI_SO_DONG_HO = " & txtSGLuyKe.Text & " , USERNAME = '" & Commons.Modules.UserName & "' WHERE MS_MAY = '" & MsMay & "' " &
                                " AND CONVERT(DATETIME,CONVERT(NVARCHAR(10), NGAY, 101) + ' ' + CONVERT(NVARCHAR(8), NGAY, 108)) = '" & dNgay.ToString("MM/dd/yyyy HH:mm:ss") & "' "
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sSql)
                GoTo 1

            End If
            objTrans.Commit()
        Catch ex As Exception
            objTrans.Rollback()
            Return False
        End Try


        'Với CHI_SO_LUY_KE bằng số nhập, 
        'CHI_SO_ONG_HO= chỉ số lũy kế n – chỉ số lũy kế (n-1)., 
        'Update CHI_SO_DONG_HO n+1 = Chỉ số lũy kế n+1 trừ đi chỉ số lũy kế n. 
        'Nếu sau khi trừ mà chỉ số nhỏ hơn 0 thì mesagebox lên cho user chọn yes, no. 
        'Nếu yes thì lấy CHI_SO_DONG_HO bằng CHI_SO_LUY_KE, nếu no thì rrollback, k nhập. 





        Return True

    End Function

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub frmChonTGCM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtNgaySGLK.Text = Now.Date
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        Dim str As String = "SELECT TOP 1 NGAY, CHI_SO_DONG_HO FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY = '" & MsMay & "' ORDER BY NGAY DESC"
        Dim DT As New DataTable
        DT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
        If (DT.Rows.Count > 0) Then
            txtChiSoTruoc.Text = DT.Rows(0)("CHI_SO_DONG_HO").ToString() & " - " & Convert.ToDateTime(DT.Rows(0)("NGAY").ToString()).ToString("dd/MM/yyyy HH:mm:ss")
        End If

    End Sub
End Class