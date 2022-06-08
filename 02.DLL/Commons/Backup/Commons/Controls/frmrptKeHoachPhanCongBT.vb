Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmrptKeHoachPhanCongBT
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptKeHoachPhanCongBT_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("MAY_CONG_NHAN_LIST_TMP")
    End Sub
    Private Sub frmrptKeHoachPhanCongBT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'BindData()
        LoadCity()
        Try
            mtxtTuNgay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            mtxtDenNgay.Text = DateTime.Now.Date.AddMonths(1).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
        End Try
    End Sub


    ' Load Data combo Nhà xưởng
    Private Sub BindData()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cbxChonXuong.DisplayMember = "TEN_N_XUONG"
        cbxChonXuong.ValueMember = "MS_N_XUONG"
        cbxChonXuong.DataSource = _table
    End Sub

    ' Kiểm tra ngày
    Private Sub mtxtChonNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        If mtxtTuNgay.Text.ToString.Trim.Equals("/  /") Then
            Exit Sub
        End If


        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TuNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        Try
            If vTuNgay < DateTime.Now.Date Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TuNgayPhaiLonHonNgayHienTai", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                e.Cancel = True
            Else
                mtxtDenNgay.Text = vTuNgay.AddMonths(1).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            End If
        Catch ex As Exception
        End Try
        Try
            Dim vDenNgay As DateTime = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            If vTuNgay > vDenNgay Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TuNgayPhaiNhoHonDenNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub mtxtChonNgay_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtTuNgay.Validated
        Try

        Catch ex As Exception
        End Try
    End Sub

    'Thực hiện In 
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            'kiểm tra nhà xưởng
            Try
                If cbxChonXuong.Text.ToString.Trim.Equals("") Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "ChuaChonN_XUONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    cbxChonXuong.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
            'kiểm tra Từ ngày 
            Try
                If mtxtTuNgay.Text.ToString.Trim.Equals("/  /") Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TuNgayChuaChonNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    mtxtTuNgay.Focus()
                    Exit Sub
                Else
                    vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                End If
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TuNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End Try
            'kiểm tra đến ngày 
            Try
                If mtxtDenNgay.Text.ToString.Trim.Equals("/  /") Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TuNgayChuaChonNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    mtxtDenNgay.Focus()
                    Exit Sub
                Else
                    vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                End If
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "DenNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End Try

            Dim vTbData As System.Data.DataTable = New System.Data.DataTable()
            vTbData = Get_DataTable(cbxChonXuong.SelectedValue.ToString(), vTuNgay, vDenNgay, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
            Dim frm As frmXMLReport = New frmXMLReport()
            frm.AddDataTableSource(vTbData)
            frm.AddDataTableSource(RefeshLanguageReport())
            frm.rptName = "rptKeHoachPhanCongBT"
            frm.Show()
            ' cbxChonXuong.DataSource = vTbData

        Catch ex As Exception
        End Try
    End Sub

    Private Function RefeshLanguageReport() As DataTable
        'Ngon Ngu bao bao 
        Dim TIEU_DE, TU_NGAY, DEN_NGAY, TDE_XUONG, TENXUONG, TUNGAY, DENNGAY, STT, TEN_MAY, MS_MAY, LOAI_BT, TG_BT, NV_TH, KETQUA, KY1, KY2, NGAY, MAU_SO, SO, TT_CTY, TT_PHONG_BAN, TRANG As String

        Dim vTBNgonNgu As DataTable = New DataTable()
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TIEU_DE", commons.Modules.TypeLanguage)
        Dim clTIEU_DE As DataColumn = New DataColumn("TIEU_DE", Type.GetType("System.String"))
        vTBNgonNgu.Columns.Add(New DataColumn("TIEU_DE", Type.GetType("System.String")))

        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TU_NGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TU_NGAY", Type.GetType("System.String"))

        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "DEN_NGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("DEN_NGAY", Type.GetType("System.String"))

        TDE_XUONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TDE_XUONG", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TDE_XUONG", Type.GetType("System.String"))

        TENXUONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TENXUONG", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TENXUONG", Type.GetType("System.String"))

        TUNGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TUNGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TUNGAY", Type.GetType("System.String"))

        DENNGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "DENNGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("DENNGAY", Type.GetType("System.String"))

        STT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "STT", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("STT", Type.GetType("System.String"))

        TEN_MAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TEN_MAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TEN_MAY", Type.GetType("System.String"))

        MS_MAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "MS_MAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("MS_MAY", Type.GetType("System.String"))

        LOAI_BT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "LOAI_BT", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("LOAI_BT", Type.GetType("System.String"))

        TG_BT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TG_BT", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TG_BT", Type.GetType("System.String"))

        NV_TH = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "NV_TH", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("NV_TH", Type.GetType("System.String"))

        KETQUA = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "KETQUA", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("KETQUA", Type.GetType("System.String"))

        KY1 = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "KY1", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("KY1", Type.GetType("System.String"))

        KY2 = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "KY2", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("KY2", Type.GetType("System.String"))

        NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "NGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("NGAY", Type.GetType("System.String"))

        MAU_SO = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "MAU_SO", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("MAU_SO", Type.GetType("System.String"))

        SO = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "SO", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("SO", Type.GetType("System.String"))

        vTBNgonNgu.Columns.Add("ND_SO", Type.GetType("System.String"))

        TT_CTY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TT_CTY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TT_CTY", Type.GetType("System.String"))

        TT_PHONG_BAN = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TT_PHONG_BAN", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TT_PHONG_BAN", Type.GetType("System.String"))

        TRANG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TRANG", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TRANG", Type.GetType("System.String"))

        Dim rowNew As DataRow = vTBNgonNgu.NewRow()
        rowNew("TIEU_DE") = TIEU_DE
        rowNew("TU_NGAY") = TU_NGAY
        rowNew("DEN_NGAY") = DEN_NGAY
        rowNew("TDE_XUONG") = TDE_XUONG
        rowNew("TENXUONG") = cbxChonXuong.Text
        rowNew("TUNGAY") = mtxtTuNgay.Text
        rowNew("DENNGAY") = mtxtDenNgay.Text
        rowNew("STT") = STT
        rowNew("TEN_MAY") = TEN_MAY
        rowNew("MS_MAY") = MS_MAY
        rowNew("LOAI_BT") = LOAI_BT
        rowNew("TG_BT") = TG_BT
        rowNew("NV_TH") = NV_TH
        rowNew("KETQUA") = KETQUA
        rowNew("KY1") = KY1
        rowNew("KY2") = KY2
        rowNew("NGAY") = NGAY
        rowNew("MAU_SO") = MAU_SO
        rowNew("SO") = SO
        rowNew("ND_SO") = cbxChonXuong.SelectedValue.ToString & "/" & vTuNgay.AddDays(15).Month.ToString
        rowNew("TT_CTY") = TT_CTY
        rowNew("TT_PHONG_BAN") = TT_PHONG_BAN
        rowNew("TRANG") = TRANG

        vTBNgonNgu.Rows.Add(rowNew)
        Return vTBNgonNgu

    End Function


    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        If mtxtTuNgay.Text.ToString.Trim.Equals("/  /") Then
            Exit Sub
        End If
        Try
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "DenNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            Dim vTuNgay As DateTime = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            If vTuNgay > vDenNgay Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "DenNgayPhaiLonHonTuNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try
    End Sub
#Region "Nhu Y"
    Private Sub LoadCity()

        Try
            cmbCity.ValueMember = "ma_qg"
            cmbCity.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"))
            cmbCity.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDistrict()

        Try
            cmbDistrict.ValueMember = "ma_qg"
            cmbDistrict.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District", cmbCity.SelectedValue.ToString()))
            cmbDistrict.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadStreet()

        Try

            'cmbStreet.StoreName = "S_Duong"
            'cmbStreet.Param = cmbCity.SelectedValue.ToString()
            'If cmbDistrict.SelectedValue = Nothing Then
            'Else
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            'End If
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString()))
            cmbStreet.DataSource = _table
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"
        Catch ex As Exception

        End Try

    End Sub
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[KeHoachPhanCongBaoTri_NEW]", tungay, denngay))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), tungay, denngay)
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all.Rows.Count <= 0) Then
                                v_all = vDataParent.ToTable().Copy()
                                v_all.Clear()
                            End If
                            v_all.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If
                Next

                'v_all.Merge(temp.ToTable())

                Return v_all
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[KeHoachPhanCongBaoTri_NEW]", tungay, denngay))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay)
        Dim _city As String = ""
        Dim _district As String = ""
        Dim _street As String = ""
        If _table.Rows.Count > 0 Then


            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function
#End Region
    Private Sub cmbCity_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCity.SelectedValueChanged
        LoadDistrict()
    End Sub

    Private Sub cmbDistrict_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectedValueChanged
        LoadStreet()
    End Sub

    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStreet.SelectedValueChanged
        BindData()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Commons.Modules.ObjSystems.XoaTable("MAY_CONG_NHAN_LIST_TMP")
        Me.ParentForm.Close()
    End Sub
End Class
