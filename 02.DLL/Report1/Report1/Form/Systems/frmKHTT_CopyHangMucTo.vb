Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class frmKHTT_CopyHangMucTo
    Public HANG_MUC_ID As String = "-1"
    Public MS_MAY_COPY_FROM As String = ""
    Public KH_NAM As String = "-1"
    Public KH_THANG As String = "-1"
    Public KH_TYPE As String = "-1"

    Private Sub LoadDataHangMucInfo()
        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
        Try
            Dim commandGetBTDK As SqlCommand = scon.CreateCommand()
            commandGetBTDK.Connection = scon
            commandGetBTDK.CommandTimeout = 9999
            commandGetBTDK.Transaction = sqlTrans
            commandGetBTDK.CommandType = CommandType.StoredProcedure

            commandGetBTDK.CommandText = "SP_GET_LIST_MAY_COPY_HANG_MUC"
            commandGetBTDK.Parameters.Add("@HANG_MUC_ID", SqlDbType.Int)
            commandGetBTDK.Parameters("@HANG_MUC_ID").Value = HANG_MUC_ID

            commandGetBTDK.Parameters.Add("@KH_NAM", SqlDbType.Int)
            commandGetBTDK.Parameters("@KH_NAM").Value = KH_NAM

            commandGetBTDK.Parameters.Add("@KH_THANG", SqlDbType.Int)
            commandGetBTDK.Parameters("@KH_THANG").Value = KH_THANG

            commandGetBTDK.Parameters.Add("@KH_TYPE", SqlDbType.Int)
            commandGetBTDK.Parameters("@KH_TYPE").Value = KH_TYPE

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

    Private Sub frmKHTT_ChuyenThangQuaThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadKHType()
        LoadNamData()
        LoadThangData()
        LoadDataHangMucInfo()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub
    Private Sub LoadKHType()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("1", "Kế hoạch năm")
        _vtb.Rows.Add("2", "Kế hoạch tháng")
        cbKHType.DataSource = _vtb
        cbKHType.DisplayMember = "Name"
        cbKHType.ValueMember = "Code"

        cbKHType.SelectedValue = KH_TYPE
        If KH_TYPE = 1 Then
            cbThang.Visible = False
            Label3.Visible = False
        Else
            cbThang.Visible = True
            Label3.Visible = True
        End If

        AddHandler cbKHType.SelectedValueChanged, AddressOf Me.cbKHType_SelectedValueChanged
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
        cbNam.SelectedValue = KH_NAM
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

        cbThang.DataSource = _vtb
        cbThang.DisplayMember = "Name"
        cbThang.ValueMember = "Code"
        If KH_TYPE = 1 Then
            cbThang.SelectedValue = Date.Now.ToString("MM")
        Else
            cbThang.SelectedValue = KH_THANG
        End If



    End Sub

    Private Sub cbKHType_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbKHType.SelectedValue = "1" Then
            cbThang.Visible = False
            Label3.Visible = False
        Else
            cbThang.Visible = True
            Label3.Visible = True
        End If
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click

    End Sub


    Private _loaikhTao As Integer = -1
    Private _khNamTao As String = -1
    Private _khThangTao As String = -1

    Private Function CheckDataBeforeCreateKH() As Boolean
        Dim _vtb As DataView
        _vtb = CType(gvBTDK.DataSource, DataView)
        Dim _vtbChoose As New DataView(_vtb.ToTable(), "CHOOSE = true", "MS_MAY", DataViewRowState.CurrentRows)
        'KTRA CHON
        If _vtbChoose.ToTable().Rows.Count <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_THIET_BI", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
            Return False
        End If
        'KTRA NGAY
        Dim _GioiHanTuNgay As String = ""
        Dim _ngayHienTai As String = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)

        If _loaikhTao = 1 Then
            _GioiHanTuNgay = _khNamTao + "0101"
        Else
            _GioiHanTuNgay = _khNamTao + _khThangTao + "01"
        End If

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

            If _loaikhTao = 1 Then
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
    Private Function CreateAutomaticKHBT() As Boolean
        Dim _dvDataChoose As New DataTable
        _dvDataChoose = New DataView(CType(gvBTDK.DataSource, DataView).ToTable(), "CHOOSE = 'true'", "MS_MAY", DataViewRowState.CurrentRows).ToTable()

        'lay hang muc ID
        For i As Integer = 0 To _dvDataChoose.Rows.Count - 1
            Dim mshm As Integer = -1
            mshm = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GET_ID_HANG_MUC", Commons.Modules.UserName))
            _dvDataChoose.Rows(i)("MA_HANG_MUC") = mshm
        Next

        'Them vao ke hoach tong the

        Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
        scon.Open()
        Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
        Try

            Dim command1 As SqlCommand = scon.CreateCommand()
            command1.Connection = scon
            command1.CommandTimeout = 9999
            command1.Transaction = sqlTrans
            command1.CommandType = CommandType.Text
            command1.CommandText = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON"
            command1.ExecuteNonQuery()

            For i As Integer = 0 To _dvDataChoose.Rows.Count - 1

                Dim commandGetBTDK As SqlCommand = scon.CreateCommand()
                commandGetBTDK.Connection = scon
                commandGetBTDK.CommandTimeout = 9999
                commandGetBTDK.Transaction = sqlTrans
                commandGetBTDK.CommandType = CommandType.StoredProcedure

                commandGetBTDK.CommandText = "SP_KHBT_COPY_HANG_MUC"

                commandGetBTDK.Parameters.Add("@MS_MAY_COPY_TO", SqlDbType.NVarChar)
                commandGetBTDK.Parameters("@MS_MAY_COPY_TO").Value = _dvDataChoose.Rows(i)("MS_MAY")

                commandGetBTDK.Parameters.Add("@MS_MAY_COPY_FROM", SqlDbType.NVarChar)
                commandGetBTDK.Parameters("@MS_MAY_COPY_FROM").Value = MS_MAY_COPY_FROM

                commandGetBTDK.Parameters.Add("@HANG_MUC_COPY_FROM", SqlDbType.Int)
                commandGetBTDK.Parameters("@HANG_MUC_COPY_FROM").Value = HANG_MUC_ID

                commandGetBTDK.Parameters.Add("@KH_NAM", SqlDbType.Int)
                commandGetBTDK.Parameters("@KH_NAM").Value = cbNam.SelectedValue

                commandGetBTDK.Parameters.Add("@KH_THANG", SqlDbType.Int)
                commandGetBTDK.Parameters("@KH_THANG").Value = cbThang.SelectedValue

                commandGetBTDK.Parameters.Add("@KH_TUAN", SqlDbType.Int)
                commandGetBTDK.Parameters("@KH_TUAN").Value = DBNull.Value

                commandGetBTDK.Parameters.Add("@KH_TYPE", SqlDbType.Int)
                commandGetBTDK.Parameters("@KH_TYPE").Value = cbKHType.SelectedValue

                commandGetBTDK.Parameters.Add("@HANG_MUC_ID", SqlDbType.Int)
                commandGetBTDK.Parameters("@HANG_MUC_ID").Value = _dvDataChoose.Rows(i)("MA_HANG_MUC")

                commandGetBTDK.Parameters.Add("@TEN_HANG_MUC", SqlDbType.NVarChar)
                commandGetBTDK.Parameters("@TEN_HANG_MUC").Value = _dvDataChoose.Rows(i)("TEN_HANG_MUC")

                commandGetBTDK.Parameters.Add("@TU_NGAY", SqlDbType.DateTime)
                commandGetBTDK.Parameters("@TU_NGAY").Value = _dvDataChoose.Rows(i)("TU_NGAY")

                commandGetBTDK.Parameters.Add("@DEN_NGAY", SqlDbType.DateTime)
                commandGetBTDK.Parameters("@DEN_NGAY").Value = _dvDataChoose.Rows(i)("DEN_NGAY")

                commandGetBTDK.Parameters.Add("@MS_UU_TIEN", SqlDbType.Int)
                commandGetBTDK.Parameters("@MS_UU_TIEN").Value = _dvDataChoose.Rows(i)("MS_UU_TIEN")

                commandGetBTDK.Parameters.Add("@CP_VT_NN_NGOAI_DM", SqlDbType.Float)
                commandGetBTDK.Parameters("@CP_VT_NN_NGOAI_DM").Value = _dvDataChoose.Rows(i)("CP_VT_NN_NGOAI_DM")

                commandGetBTDK.Parameters.Add("@CP_VT_NGOAI_DM", SqlDbType.Float)
                commandGetBTDK.Parameters("@CP_VT_NGOAI_DM").Value = _dvDataChoose.Rows(i)("CP_VT_NGOAI_DM")

                commandGetBTDK.Parameters.Add("@CP_THUE_NGOAI", SqlDbType.Float)
                commandGetBTDK.Parameters("@CP_THUE_NGOAI").Value = _dvDataChoose.Rows(i)("CP_THUE_NGOAI")

                commandGetBTDK.Parameters.Add("@USERNAME", SqlDbType.NVarChar)
                commandGetBTDK.Parameters("@USERNAME").Value = Commons.Modules.UserName

                commandGetBTDK.ExecuteNonQuery()

            Next

            'Dim command2 As SqlCommand = scon.CreateCommand()
            'command2.Connection = scon
            'command2.CommandTimeout = 9999
            'command2.Transaction = sqlTrans
            'command2.CommandType = CommandType.Text
            'command2.CommandText = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON"
            'command2.ExecuteNonQuery()

            sqlTrans.Commit()
            scon.Close()

        Catch ex As Exception
            sqlTrans.Rollback()
            scon.Close()
        End Try


     



        Return True
    End Function


    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        _loaikhTao = cbKHType.SelectedValue
        _khNamTao = cbNam.SelectedValue
        _khThangTao = cbThang.SelectedValue

        If CheckDataBeforeCreateKH() = False Then
            Exit Sub
        Else
            If CreateAutomaticKHBT() = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub

    Private Sub btnChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonAll.Click
        For i As Integer = 0 To gvBTDK.RowCount - 1
            gvBTDK.SetRowCellValue(i, CHOOSE, True)
        Next
    End Sub

    Private Sub btnBoChonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoChonAll.Click
        For i As Integer = 0 To gvBTDK.RowCount - 1
            gvBTDK.SetRowCellValue(i, CHOOSE, False)
        Next
    End Sub
End Class