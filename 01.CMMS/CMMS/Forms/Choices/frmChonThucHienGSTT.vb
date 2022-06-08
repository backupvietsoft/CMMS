Imports Microsoft.ApplicationBlocks.Data

Public Class frmChonThucHienGSTT
    Public drGSTT As DataRow
    Public dtTSGSTT As DataTable
    Dim bCoPBT As Boolean

    Private Sub frmChonThucHienGSTT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            bCoPBT = True
            txtMay.Text = drGSTT("MS_MAY") & " - " & drGSTT("TEN_MAY")
            TaoCachThucHien()
            TaoPBT()



            If Not String.IsNullOrEmpty(drGSTT("MS_CACH_TH").ToString()) Then
                cboCTH.EditValue = drGSTT("MS_CACH_TH")
            End If
            If Not String.IsNullOrEmpty(drGSTT("MS_CONG_NHAN").ToString()) Then
                cboCNTHien.EditValue = drGSTT("MS_CONG_NHAN")
            End If
            If Not String.IsNullOrEmpty(cboCTH.Text) Then
                If cboCTH.EditValue = "04" Then
                    cboPBT.EditValue = drGSTT("MS_PBT")
                End If
            End If
            Commons.Modules.ObjSystems.MLoadXtraGrid(gdTSGSTT, gvTSGSTT, dtTSGSTT, False, True, False, False)
            For i = 0 To gvTSGSTT.Columns.Count - 1
                gvTSGSTT.Columns(i).Visible = False
            Next
            gvTSGSTT.Columns("TEN_BO_PHAN").Visible = True
            gvTSGSTT.Columns("TEN_TS_GSTT").Visible = True
            gvTSGSTT.Columns("GT_DL").Visible = True
            gvTSGSTT.Columns("GT_DT").Visible = True

            gvTSGSTT.OptionsView.ColumnAutoWidth = True
            gvTSGSTT.BestFitColumns()

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub TaoCachThucHien()
        Dim dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCACH_THUC_HIEN", Commons.Modules.TypeLanguage))
        dtTmp.DefaultView.RowFilter = " MS_CACH_TH <> '01' "
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCTH, dtTmp, "MS_CACH_TH", "TEN_CACH_TH", "")
        cboCTH.EditValue = "00"
    End Sub


    Private Sub TaoPBT()
        Dim sSql As String
        Dim dtTmp = New DataTable
        Dim NgayKT As Date

        Try
            NgayKT = drGSTT("NGAY_GIO_KT_MAX")
        Catch ex As Exception
            NgayKT = Now
        End Try

        sSql = " SELECT DISTINCT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & drGSTT("MS_MAY").ToString & "' " &
                            " AND TINH_TRANG_PBT IN (4,5) And NGAY_NGHIEM_THU >='" & NgayKT.ToString("MM/dd/yyyy") & "' ORDER BY MS_PHIEU_BAO_TRI DESC"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))



        If dtTmp.Rows.Count = 0 Then
            bCoPBT = False
            cboPBT.Properties.DataSource = Nothing
        Else
            Dim drPBT As DataRow
            drPBT = dtTmp.NewRow
            drPBT.Item("MS_PHIEU_BAO_TRI") = ""
            dtTmp.Rows.InsertAt(drPBT, 0)
            bCoPBT = True
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPBT, dtTmp, "MS_PHIEU_BAO_TRI", "MS_PHIEU_BAO_TRI", "")
            cboPBT.EditValue = ""
        End If

        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs"))

        Dim dr As DataRow
        dr = dtTmp.NewRow
        dr.Item("MS_CONG_NHAN") = ""
        dr.Item("HO_TEN_CONG_NHAN") = ""
        dtTmp.Rows.InsertAt(dr, 0)
        Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboCNTHien, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "")

    End Sub

    Private Sub cboCTH_EditValueChanged(sender As Object, e As EventArgs) Handles cboCTH.EditValueChanged
        Try
            If cboCTH.EditValue = "04" Then
                If bCoPBT = False Then
                    cboPBT.Enabled = False
                    'MsgBox("Hiện chưa có phiếu bảo trì nào đã nghiệm thu có ngày nghiệm thu lớn hơn ngày giám sát cho thiết bị này." & vbCrLf & "Thao tác này không thực hiện được !", MsgBoxStyle.Exclamation)
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgHienChuaCoPBTNgiemThuLonHonNgayGiamSat", Commons.Modules.TypeLanguage))
                    cboCTH.EditValue = "00"
                    Exit Sub
                Else
                    cboPBT.Enabled = True
                End If
            Else
                cboPBT.EditValue = ""
                cboPBT.Enabled = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        If gvTSGSTT.RowCount <= 0 Then Exit Sub

        If cboCTH.EditValue.ToString() = "00" Then
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgChuaChonCachThucHien", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        If cboCTH.EditValue.ToString() = "04" Then
            If String.IsNullOrEmpty(cboPBT.EditValue.ToString()) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgChuaChonPBT", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
        End If

            If cboCTH.EditValue.ToString() = "02" Or cboCTH.EditValue.ToString() = "04" Or cboCTH.EditValue.ToString() = "01" Then
            If String.IsNullOrEmpty(cboCNTHien.EditValue) Then
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgChuaNhapNguoiThucHien", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
        End If

        'PBT
        If cboCTH.EditValue.ToString() = "02" Or cboCTH.EditValue.ToString() = "04" Then
            CapNhapPBT()
        End If
        'BoQua
        If cboCTH.EditValue.ToString() = "03" Or cboCTH.EditValue.ToString() = "06" Then
            CapNhapBoQua()
        End If
        'BoQua
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub CapNhapPBT()
        Try
            For i = 0 To gvTSGSTT.RowCount - 1
                If cboCTH.EditValue.ToString().ToString() = "02" Then
                    LapPBT2_tab2(i)
                ElseIf cboCTH.EditValue.ToString().ToString() = "04" Then
                    LapPBT1_tab2(i)
                End If
            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub CapNhapBoQua()
        Dim sSql As String
        Dim dtTmp As New DataTable
        Try

            For i = 0 To gvTSGSTT.RowCount - 1

                If IsDBNull(gvTSGSTT.GetDataRow(i)("GT_DT")) Or
                        IsDBNull(gvTSGSTT.GetDataRow(i)("STT_GT")) Or
                            gvTSGSTT.GetDataRow(i)("STT_GT").ToString().Trim().Equals(String.Empty) Then
                    Try
                        sSql = "SELECT STT,MS_MAY,MS_TS_GSTT,MS_BO_PHAN,MS_TT FROM GIAM_SAT_TINH_TRANG_TS WHERE STT=" & gvTSGSTT.GetDataRow(i)("STT") &
                                    " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(i)("MS_MAY") & "' " &
                                    " And MS_TS_GSTT='" & gvTSGSTT.GetDataRow(i)("MS_TS_GSTT") & "'"
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        For Each vr As DataRow In dtTmp.Rows
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_GIAM_SAT_TINH_TRANG_TS_LOG",
                                                    vr("STT"), vr("MS_MAY"), vr("MS_TS_GSTT"), vr("MS_BO_PHAN"), vr("MS_TT"), Me.Name, Commons.Modules.UserName, 2)
                        Next
                    Catch ex As Exception

                    End Try


                    Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS SET " &
                            " MS_CONG_NHAN='" & cboCNTHien.EditValue.ToString & "', " &
                            " MS_CACH_TH = '" & cboCTH.EditValue.ToString() & "',TG_XU_LY= " & IIf(cboCTH.EditValue = "06", "NULL", "GETDATE()") & " , " &
                            " USERNAME='" & Commons.Modules.UserName & "' " &
                            " WHERE STT=" & gvTSGSTT.GetDataRow(i)("STT") &
                            " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(i)("MS_MAY") & "' " &
                            " AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(i)("MS_TS_GSTT") & "'"
                Else
                    Try
                        sSql = " select STT,MS_MAY,MS_TS_GSTT,MS_BO_PHAN,MS_TT,STT_GT from GIAM_SAT_TINH_TRANG_TS_DT " &
                                    " WHERE STT=" & gvTSGSTT.GetDataRow(i)("STT") &
                                    " And MS_MAY=N'" & gvTSGSTT.GetDataRow(i)("MS_MAY") & "' " &
                                    " And MS_TS_GSTT='" & gvTSGSTT.GetDataRow(i)("MS_TS_GSTT") & "' " &
                                    " And STT_GT=" & gvTSGSTT.GetDataRow(i)("STT_GT")
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        For Each vr As DataRow In dtTmp.Rows
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_GIAM_SAT_TINH_TRANG_TS_DT_LOG", vr("STT"), vr("MS_MAY"), vr("MS_TS_GSTT"), vr("MS_BO_PHAN"), vr("MS_TT"), vr("STT_GT"), Me.Name, Commons.Modules.UserName, 2)
                        Next
                    Catch ex As Exception

                    End Try
                    Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET " &
                            " MS_CONG_NHAN='" & cboCNTHien.EditValue.ToString & "', " &
                            " MS_CACH_TH='" & cboCTH.EditValue.ToString() & "',TG_XU_LY= " & IIf(cboCTH.EditValue = "06", "NULL", "GETDATE()") & ",  " &
                            " USERNAME='" & Commons.Modules.UserName & "' " &
                            " WHERE STT=" & gvTSGSTT.GetDataRow(i)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(i)("MS_MAY") & "'  " &
                            " AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(i)("MS_TS_GSTT") & "' AND STT_GT=" & gvTSGSTT.GetDataRow(i)("STT_GT")
                End If
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            Next
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Sub LapPBT2_tab2(ByVal ind As Integer)
        Dim MS_PBT, LY_DO_BT As String
        LY_DO_BT = ""
        Dim MS_LOAI_BT As Integer
        If IsDBNull(cboPBT.EditValue.ToString()) Or cboPBT.EditValue.ToString() = "" Then
            MS_PBT = Commons.Modules.ObjSystems.TangMS_PBT
            Commons.Modules.SQLString = "SELECT MS_LOAI_BT,LY_DO_BT FROM CACH_THUC_HIEN WHERE MS_CACH_TH='02'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                MS_LOAI_BT = dtReader.Item(0)
                LY_DO_BT = dtReader.Item(1)
            End While
            dtReader.Close()

            Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI(MS_PHIEU_BAO_TRI,TINH_TRANG_PBT,MS_MAY,MS_LOAI_BT,NGUOI_LAP,NGAY_LAP,GIO_LAP,LY_DO_BT,NGAY_BD_KH,USERNAME_NGUOI_LAP,NGAY_KT_KH) VALUES(N'" & MS_PBT & "',1,'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "'," & MS_LOAI_BT & ",'" & cboCNTHien.EditValue.ToString() & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Format(TimeValue(Now), "HH:mm") & "','" & LY_DO_BT & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Commons.Modules.UserName & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "')"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Else
            MS_PBT = cboPBT.EditValue.ToString()
        End If


        If IsDBNull(gvTSGSTT.GetDataRow(ind)("GT_DT")) Or IsDBNull(gvTSGSTT.GetDataRow(ind)("STT_GT")) Or gvTSGSTT.GetDataRow(ind)("STT_GT").ToString().Trim().Equals(String.Empty) Then
            Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='" & cboCTH.EditValue.ToString() & "',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & cboCNTHien.EditValue.ToString() & "',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "' WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "'"
        Else
            Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='" & cboCTH.EditValue.ToString() & "',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & cboCNTHien.EditValue.ToString() & "',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "' WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "' AND STT_GT=" & gvTSGSTT.GetDataRow(ind)("STT_GT")
        End If
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub
    Sub LapPBT1_tab2(ByVal ind As Integer)
        Dim sSql As String = ""
        Try
            If String.IsNullOrEmpty(gvTSGSTT.GetDataRow(ind)("GT_DT").ToString) Or String.IsNullOrEmpty(gvTSGSTT.GetDataRow(ind)("STT_GT").ToString) Or
                        String.IsNullOrEmpty(gvTSGSTT.GetDataRow(ind)("STT_GT").ToString().Trim().ToString) Then
                sSql = "UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT='" & cboPBT.EditValue.ToString() & "',MS_CACH_TH='" & cboCTH.EditValue.ToString() & "', " &
                            " USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & cboCNTHien.EditValue.ToString() & "',  " &
                            " TG_XU_LY= GETDATE() WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "' " &
                            " AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "' AND MS_BO_PHAN = N'" & gvTSGSTT.GetDataRow(ind)("MS_BO_PHAN") & "' "
            Else
                sSql = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_PBT='" & cboPBT.EditValue.ToString() & "',MS_CACH_TH='" & cboCTH.EditValue.ToString() & "', " &
                        " USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & cboCNTHien.EditValue.ToString() & "', " &
                        " TG_XU_LY= GETDATE() WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "'  " &
                        " AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "' AND MS_BO_PHAN = N'" & gvTSGSTT.GetDataRow(ind)("MS_BO_PHAN") & "' " &
                        " AND STT_GT=" & gvTSGSTT.GetDataRow(ind)("STT_GT")
            End If
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

End Class