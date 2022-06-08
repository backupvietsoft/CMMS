﻿Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmKHTT_ChuyenCVNamQuaThang

    Public KHNam As String = 2014
    Public KHThang As String = "03"
    Private KHType As String = "2"

    Private Sub btnLayDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayDL.Click

        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
        Try
            Dim commandGetBTDK As SqlCommand = scon.CreateCommand()
            commandGetBTDK.Connection = scon
            commandGetBTDK.CommandTimeout = 9999
            commandGetBTDK.Transaction = sqlTrans
            commandGetBTDK.CommandType = CommandType.StoredProcedure
            commandGetBTDK.CommandText = "SP_GET_DATA_KHBT_CVNAM_TO_CVTHANG"
            commandGetBTDK.Parameters.Add("@KH_NAM", SqlDbType.Int)
            commandGetBTDK.Parameters("@KH_NAM").Value = cbNam.SelectedValue

            commandGetBTDK.Parameters.Add("@KH_THANG", SqlDbType.Int)
            commandGetBTDK.Parameters("@KH_THANG").Value = cbThang.SelectedValue


            commandGetBTDK.Parameters.Add("@KH_NAM_TO", SqlDbType.Int)
            commandGetBTDK.Parameters("@KH_NAM_TO").Value = KHNam

            commandGetBTDK.Parameters.Add("@KH_THANG_TO", SqlDbType.Int)
            commandGetBTDK.Parameters("@KH_THANG_TO").Value = KHThang

            commandGetBTDK.Parameters.Add("@USERNAME", SqlDbType.NVarChar)
            commandGetBTDK.Parameters("@USERNAME").Value = Commons.Modules.UserName

            Dim daGetBTDK As New SqlDataAdapter(commandGetBTDK)
            Dim dsBTDK As New DataSet()
            daGetBTDK.Fill(dsBTDK)

            gdBTDK.DataSource = dsBTDK.Tables(0)

            sqlTrans.Commit()
            scon.Close()

        Catch ex As Exception
            sqlTrans.Rollback()
            scon.Close()
        End Try
    End Sub
    Private Function CheckDataBeforeCreateKH() As Boolean
        Dim _vtb As DataView
        _vtb = CType(gvBTDK.DataSource, DataView)
        Dim _vtbChoose As New DataView(_vtb.ToTable(), "chkChon = true", "MS_MAY", DataViewRowState.CurrentRows)
        'KTRA CHON
        If _vtbChoose.ToTable().Rows.Count <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_THIET_BI", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
            Return False
        End If
        'KTRA NGAY
        Dim _GioiHanTuNgay As String = ""
        Dim _ngayHienTai As String = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)


        _GioiHanTuNgay = KHNam + KHThang + "01"


        For i As Integer = 0 To _vtbChoose.ToTable().Rows.Count - 1

            If _vtbChoose.ToTable().Rows(i)("TEN_HANG_MUC").ToString.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_TEN_HANG_MUC", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            If _vtbChoose.ToTable().Rows(i)("TU_NGAY").ToString().Trim() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_TU_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            If _vtbChoose.ToTable().Rows(i)("DEN_NGAY").ToString().Trim() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_DEN_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            Dim _tu_ngaytmp As String = CType(_vtbChoose.ToTable().Rows(i)("TU_NGAY"), DateTime).ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)
            Dim _den_ngaytmp As String = CType(_vtbChoose.ToTable().Rows(i)("DEN_NGAY"), DateTime).ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)

            If _tu_ngaytmp > _den_ngaytmp Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NHO_HON_DEN_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                Return False
            End If

            If KHType = "1" Then
                If _GioiHanTuNgay > _tu_ngaytmp Or _GioiHanTuNgay.Substring(0, 4) <> _tu_ngaytmp.Substring(0, 4) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NAM_TRONG_GIOI_HAN_NAM", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                    Return False
                End If
            Else
                If _GioiHanTuNgay > _tu_ngaytmp Or _GioiHanTuNgay.Substring(0, 6) <> _tu_ngaytmp.Substring(0, 6) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NAM_TRONG_GIOI_HAN_THANG", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim dataSelectTMP As New DataView(CType(gdBTDK.DataSource, DataTable), "chkChon = true", "MA_HANG_MUC", DataViewRowState.CurrentRows)

        If CheckDataBeforeCreateKH() = False Then
            Exit Sub
        End If

        'Add du lieu CHUYEN
        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
        Try
            For i As Integer = 0 To dataSelectTMP.ToTable().Rows.Count - 1
                'KTRA ĐÃ TỒN TAI HANG MUC HISTORY CHUA ?

                Dim commandGetHangMuc As SqlCommand = scon.CreateCommand()
                commandGetHangMuc.Connection = scon
                commandGetHangMuc.CommandTimeout = 9999
                commandGetHangMuc.Transaction = sqlTrans
                commandGetHangMuc.CommandType = CommandType.Text
                commandGetHangMuc.CommandText = "SELECT ID , MA_HANG_MUC FROM KE_HOACH_TONG_THE_CHI_TIET WHERE KH_NAM = '" & KHNam & "' AND KH_THANG = '" & KHThang & "' AND MA_HANG_MUC = '" & dataSelectTMP.ToTable().Rows(i)("MA_HANG_MUC") & "'"

                Dim daGetHangMuc As New SqlDataAdapter(commandGetHangMuc)
                Dim dsHangMuc As New DataSet()
                daGetHangMuc.Fill(dsHangMuc)


                If dsHangMuc.Tables(0).Rows.Count = 0 Then 'chua da ton tai

                    'Lay hang muc cu

                    'Dim commandGetID As SqlCommand = scon.CreateCommand()
                    'commandGetID.Connection = scon
                    'commandGetID.CommandTimeout = 9999
                    'commandGetID.Transaction = sqlTrans
                    'commandGetID.CommandType = CommandType.Text
                    'commandGetID.CommandText = "SELECT ID FROM KE_HOACH_TONG_THE_CHI_TIET WHERE KH_NAM = '" & cbNam.SelectedValue & "' AND KH_THANG = '" & cbThang.SelectedValue & "' AND MA_HANG_MUC = '" & dataSelectTMP.ToTable().Rows(i)("MA_HANG_MUC") & "' "

                    'Dim daGetID As New SqlDataAdapter(commandGetID)
                    'Dim dsID As New DataSet()
                    'daGetID.Fill(dsID)


                    Dim command As SqlCommand = scon.CreateCommand()
                    command.Connection = scon
                    command.CommandTimeout = 9999
                    command.Transaction = sqlTrans
                    command.CommandType = CommandType.Text
                    command.CommandText = "INSERT INTO dbo.KE_HOACH_TONG_THE_CHI_TIET ( MA_HANG_MUC, KH_NAM, KH_THANG, ID_TRUOC, KH_TYPE, TU_NGAY , DEN_NGAY , MS_UU_TIEN, CP_VT_NN_NGOAI_DM, CP_VT_NGOAI_DM, CP_THUE_NGOAI) " & _
                    "VALUES ('" & dataSelectTMP.ToTable().Rows(i)("MA_HANG_MUC").ToString() & "','" & KHNam & "','" & KHThang & "','" & dataSelectTMP.ToTable().Rows(i)("ID") & "','2' ,'" & Format(dataSelectTMP.ToTable().Rows(i)("TU_NGAY"), "MM/dd/yyyy") & "','" & Format(dataSelectTMP.ToTable().Rows(i)("DEN_NGAY"), "MM/dd/yyyy") & "'" & _
                    " ,'" & dataSelectTMP.ToTable().Rows(i)("MS_UU_TIEN") & "' , '" & dataSelectTMP.ToTable().Rows(i)("CP_VT_NN_NGOAI_DM") & "' , '" & dataSelectTMP.ToTable().Rows(i)("CP_VT_NGOAI_DM") & "', '" & dataSelectTMP.ToTable().Rows(i)("CP_THUE_NGOAI") & "')"
                    command.ExecuteNonQuery()

                End If

                Dim commandCV As SqlCommand = scon.CreateCommand()
                commandCV.Connection = scon
                commandCV.CommandTimeout = 9999
                commandCV.Transaction = sqlTrans
                commandCV.CommandType = CommandType.Text
                commandCV.CommandText = "INSERT INTO dbo.KE_HOACH_TONG_CONG_VIEC_CHI_TIET (MS_MAY, MA_HANG_MUC, MA_CV, MA_BO_PHAN, KH_NAM, " & _
                    " KH_THANG,ID_TRUOC, KH_TYPE, TU_NGAY , DEN_NGAY , MS_UU_TIEN, CP_VT_NN_NGOAI_DM, CP_VT_NGOAI_DM, CP_THUE_NGOAI, TG_KH)" & _
                    " SELECT MS_MAY, MA_HANG_MUC, MA_CV, MA_BO_PHAN, '" & KHNam & "' AS KH_NAM, '" & KHThang & "' AS KH_THANG, ID AS ID_TRUOC,  '2' AS KH_TYPE , '" & Format(dataSelectTMP.ToTable().Rows(i)("TU_NGAY"), "MM/dd/yyyy") & "','" & Format(dataSelectTMP.ToTable().Rows(i)("DEN_NGAY"), "MM/dd/yyyy") & "'" & _
                    " ,'" & dataSelectTMP.ToTable().Rows(i)("MS_UU_TIEN") & "' , '" & dataSelectTMP.ToTable().Rows(i)("CP_VT_NN_NGOAI_DM") & "' , '" & dataSelectTMP.ToTable().Rows(i)("CP_VT_NGOAI_DM") & "', '" & dataSelectTMP.ToTable().Rows(i)("CP_THUE_NGOAI") & "' , '" & dataSelectTMP.ToTable().Rows(i)("TG_KH") & "'" & _
                " FROM dbo.KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE MA_HANG_MUC = '" & dataSelectTMP.ToTable().Rows(i)("MA_HANG_MUC").ToString() & "' AND  KH_NAM = '" & cbNam.SelectedValue & "' AND KH_TYPE = '1' " & _
                " AND MA_CV = '" & dataSelectTMP.ToTable().Rows(i)("MA_CV").ToString() & "' AND MA_BO_PHAN = '" & dataSelectTMP.ToTable().Rows(i)("MA_BO_PHAN").ToString() & "' AND MS_MAY = '" & dataSelectTMP.ToTable().Rows(i)("MS_MAY").ToString() & "' "
                commandCV.ExecuteNonQuery()


                Dim commandVTPT As SqlCommand = scon.CreateCommand()
                commandVTPT.Connection = scon
                commandVTPT.CommandTimeout = 9999
                commandVTPT.Transaction = sqlTrans
                commandVTPT.CommandType = CommandType.Text
                commandVTPT.CommandText = "INSERT INTO dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET(KH_TYPE, KH_NAM, KH_THANG, KH_TUAN, MS_MAY, HANG_MUC_ID, MS_CV, MS_BO_PHAN, MS_PT, SO_LUONG, GHI_CHU, DON_GIA_KH, TIEN_TE_KH, TY_GIA_KH, TY_GIA_USD_KH, " & _
                " DON_GIA_CUOI, NGAY_LAY_DG_KH )" & _
                " SELECT '2' AS KH_TYPE,'" & KHNam & "' AS KH_NAM,'" & KHThang & "' KH_THANG, KH_TUAN, MS_MAY, HANG_MUC_ID, MS_CV, MS_BO_PHAN, MS_PT, SO_LUONG, GHI_CHU, DON_GIA_KH, TIEN_TE_KH, TY_GIA_KH, TY_GIA_USD_KH, " & _
                " DON_GIA_CUOI, NGAY_LAY_DG_KH " & _
                " FROM dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE HANG_MUC_ID = '" & dataSelectTMP.ToTable().Rows(i)("MA_HANG_MUC").ToString() & "' AND  KH_NAM = '" & cbNam.SelectedValue & "' AND KH_TYPE = '1' " & _
                " AND MS_CV = '" & dataSelectTMP.ToTable().Rows(i)("MA_CV").ToString() & "' AND MS_BO_PHAN = '" & dataSelectTMP.ToTable().Rows(i)("MA_BO_PHAN").ToString() & "' AND MS_MAY = '" & dataSelectTMP.ToTable().Rows(i)("MS_MAY").ToString() & "' "
                commandVTPT.ExecuteNonQuery()

            Next
            sqlTrans.Commit()
            scon.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            sqlTrans.Rollback()
            scon.Close()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUYEN_SANG_THANG_KO_THANH_CONG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub LoadNamData()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("2013", "2013")
        _vtb.Rows.Add("2014", "2014")
        _vtb.Rows.Add("2015", "2015")
        _vtb.Rows.Add("2016", "2016")
        _vtb.Rows.Add("2017", "2017")
        _vtb.Rows.Add("2018", "2018")
        _vtb.Rows.Add("2019", "2019")
        _vtb.Rows.Add("2020", "2020")
        cbNam.DataSource = _vtb.Copy()
        cbNam.DisplayMember = "Name"
        cbNam.ValueMember = "Code"
        cbNam.SelectedValue = DateTime.Now.ToString("yyyy", Globalization.CultureInfo.CurrentCulture)

    End Sub
    Private Sub LoadThangData()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("01", "01")
        _vtb.Rows.Add("02", "02")
        _vtb.Rows.Add("03", "03")
        _vtb.Rows.Add("04", "04")
        _vtb.Rows.Add("05", "05")
        _vtb.Rows.Add("06", "06")
        _vtb.Rows.Add("07", "07")
        _vtb.Rows.Add("08", "08")
        _vtb.Rows.Add("09", "09")
        _vtb.Rows.Add("10", "10")
        _vtb.Rows.Add("11", "11")
        _vtb.Rows.Add("12", "12")

        'For i As Integer = 0 To _vtb.Rows.Count - 1
        '    If _vtb.Rows(i)("Code").ToString = KHThang Then
        '        _vtb.Rows.RemoveAt(i)
        '        Exit For
        '    End If
        'Next

        cbThang.DataSource = _vtb
        cbThang.DisplayMember = "Name"
        cbThang.ValueMember = "Code"
        cbThang.SelectedValue = DateTime.Now.ToString("MM", Globalization.CultureInfo.CurrentCulture)
    End Sub
    Private Sub frmKHTT_ChuyenThangQuaThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadNamData()
        LoadThangData()
        Dim _tblUUTien = New DataTable()
        _tblUUTien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))
        Dim repositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit3.NullText = ""
        repositoryItemLookUpEdit3.ValueMember = "MS_UU_TIEN"
        repositoryItemLookUpEdit3.DisplayMember = "TEN_UU_TIEN"
        repositoryItemLookUpEdit3.DataSource = _tblUUTien
        repositoryItemLookUpEdit3.Columns.Clear()
        repositoryItemLookUpEdit3.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_UU_TIEN"))
        MS_UU_TIEN.ColumnEdit = repositoryItemLookUpEdit3
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click
        For i As Integer = 0 To gvBTDK.RowCount - 1
            gvBTDK.SetRowCellValue(i, chkChon, True)
        Next
    End Sub

    Private Sub btnBoChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChonAll.Click
        For i As Integer = 0 To gvBTDK.RowCount - 1
            gvBTDK.SetRowCellValue(i, chkChon, False)

        Next
    End Sub
End Class