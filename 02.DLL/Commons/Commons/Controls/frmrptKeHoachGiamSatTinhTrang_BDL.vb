Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptKeHoachGiamSatTinhTrang_BDL
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As DataTable = New DataTable()
    'Load Form
    Private Sub frmrptKeHoachGiamSatTinhTrang_BDL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCity()
        mtxtTuNgay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy")
        mtxtDenNgay.Text = DateTime.Now.AddDays(7).Date.ToString("dd/MM/yyyy")
        'LoadNhaXuong()
    End Sub

    Private Sub refeshLanguage()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "rptKeHoachGiamSatTinhTrang_BDL", commons.Modules.TypeLanguage)
        Me.lbaTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", lbaTuNgay.Name, commons.Modules.TypeLanguage)
        Me.lbaNhaXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", lbaNhaXuong.Name, commons.Modules.TypeLanguage)
        Me.lbaDenNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", lbaDenNgay.Name, commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", btnThucHien.Name, commons.Modules.TypeLanguage)
    End Sub
    'Load combo Nha xuong
    Private Sub LoadNhaXuong()
        'cbxNhaXuong.Value = "MS_N_XUONG"
        'cbxNhaXuong.Display = "TEN_N_XUONG"
        'cbxNhaXuong.StoreName = "GetNHA_XUONGs"
        'cbxNhaXuong.Param = Commons.Modules.UserName
        'cbxNhaXuong.BindDataSource()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cbxNhaXuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaXuong.ValueMember = "MS_N_XUONG"
        cbxNhaXuong.DataSource = _table
    End Sub
    'Thuc Hien
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            Dim frmRP As frmXMLReport = New frmXMLReport()
            frmRP.rptName = "rptKeHoachGiamSatTinhTrang_BDL"
            Dim vTbData As DataTable = New DataTable()
            Dim vtbLgangua As DataTable = languageReport()
            frmRP.AddDataTableSource(vtbLgangua)
            v_all = New DataTable()
            vTbData = Get_DataTable(cbxNhaXuong.SelectedValue.ToString(), vTuNgay, vDenNgay, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
            frmRP.AddDataTableSource(vTbData)
            If vTbData.Rows.Count > 0 Then
                frmRP.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "KoCoduLieuDeIn", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function languageReport() As DataTable
        Dim vTbTitle As DataTable = New DataTable("Title")

        Dim DienThoai As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "DienThoai", commons.Modules.TypeLanguage)
        Dim Fax As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "Fax", commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "TieuDe", commons.Modules.TypeLanguage)
        Dim TuNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "TuNgay", commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "DenNgay", commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NguoiLap", commons.Modules.TypeLanguage)
        Dim NguoiPhuTrach As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NguoiPhuTrach", commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "STT", commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "ThietBi", commons.Modules.TypeLanguage)
        Dim HeThong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "HeThong", commons.Modules.TypeLanguage)
        Dim PhanXuong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "PhanXuong", commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "BoPhan", commons.Modules.TypeLanguage)
        Dim NoiDungGS As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NoiDungGS", commons.Modules.TypeLanguage)
        Dim KetQua As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "KetQua", commons.Modules.TypeLanguage)
        Dim ChuKy As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "ChuKy", commons.Modules.TypeLanguage)
        Dim NgayKT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NgayKT", commons.Modules.TypeLanguage)
        Dim KetQuaKe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "KetQuaKe", commons.Modules.TypeLanguage)
        Dim NhanVien As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NhanVien", commons.Modules.TypeLanguage)

        Dim Nthuhien As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NguoiTH", commons.Modules.TypeLanguage)
        Dim NgiamSat As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NguoiGiamSat", commons.Modules.TypeLanguage)
        Dim NDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "NguoiDuyet", commons.Modules.TypeLanguage)
        Dim TuanSo As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "TuanSo", commons.Modules.TypeLanguage)

        vTbTitle.Columns.Add("DIENTHOAI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("FAX", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TUNGAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DENNGAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOILAP", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIPT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("THIETBI", Type.GetType("System.String"))
        vTbTitle.Columns.Add("HETHONG", Type.GetType("System.String"))
        vTbTitle.Columns.Add("PHANXUONG", Type.GetType("System.String"))
        vTbTitle.Columns.Add("BOPHAN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NOIDUNGGS", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KETQUA", Type.GetType("System.String"))
        vTbTitle.Columns.Add("CHUKY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYKT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("KETQUAKE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NHANVIEN", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TUNGAY_ND", Type.GetType("System.String"))
        vTbTitle.Columns.Add("DENNGAY_ND", Type.GetType("System.String"))

        vTbTitle.Columns.Add("NGUOITH", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIGS", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGUOIDUYET", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TuanSo", Type.GetType("System.String"))


        Dim rowNew As DataRow = vTbTitle.NewRow()
        rowNew("DIENTHOAI") = DienThoai
        rowNew("FAX") = DienThoai
        rowNew("TIEUDE") = TieuDe
        rowNew("TUNGAY") = TuNgay
        rowNew("DENNGAY") = DenNgay
        rowNew("NGUOILAP") = NguoiLap
        rowNew("NGUOIPT") = NguoiPhuTrach
        rowNew("STT") = STT
        rowNew("THIETBI") = ThietBi
        rowNew("HETHONG") = HeThong
        rowNew("PHANXUONG") = PhanXuong
        rowNew("BOPHAN") = BoPhan
        rowNew("NOIDUNGGS") = NoiDungGS
        rowNew("KETQUA") = KetQua
        rowNew("CHUKY") = ChuKy
        rowNew("NGAYKT") = NgayKT
        rowNew("KETQUAKE") = KetQuaKe
        rowNew("NHANVIEN") = NhanVien
        rowNew("TUNGAY_ND") = mtxtTuNgay.Text
        rowNew("DENNGAY_ND") = mtxtDenNgay.Text
        rowNew("NGUOITH") = Nthuhien
        rowNew("NGUOIGS") = NgiamSat
        rowNew("NGUOIDUYET") = NDuyet
        rowNew("TuanSo") = TuanSo

        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle
    End Function


    'Kiem tra tu Ngay
    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
    'Kiem tra Den Ngay
    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating

        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachGiamSatTinhTrang_BDL", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub
#Region "Nhu Y"
    Private Sub LoadCity()

        Try
            cmbCity.ValueMember = "ma_qg"
            cmbCity.DisplayMember = "ten_qg"
            Dim _table As DataTable = New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"))
            cmbCity.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDistrict()

        Try
            cmbDistrict.ValueMember = "ma_qg"
            cmbDistrict.DisplayMember = "ten_qg"
            Dim _table As DataTable = New DataTable()
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
            Dim _table As DataTable = New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString()))
            cmbStreet.DataSource = _table
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"
        Catch ex As Exception

        End Try

    End Sub
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date) As DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GetKeHoachGiamSatTinhTrang_BDL_NEW]", tungay, denngay))
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
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GetKeHoachGiamSatTinhTrang_BDL_NEW]", tungay, denngay))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable
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
        LoadNhaXuong()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
