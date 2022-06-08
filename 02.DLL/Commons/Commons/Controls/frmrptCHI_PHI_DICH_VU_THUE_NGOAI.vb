Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptCHI_PHI_DICH_VU_THUE_NGOAI
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As DataTable = New DataTable()

    Private Sub frmrptCHI_PHI_DICH_VU_THUE_NGOAI_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("CHI_PHI_DV_THUE_NGOAI_TMP")
    End Sub
    Private Sub frmrptCHI_PHI_DICH_VU_THUE_NGOAI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vDenNgay = DateTime.Now.Date
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        LoadCity()
    End Sub

    Sub loadNhaXuong()

        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cbxNhaxuong.DisplayMember = "TEN_N_XUONG"
        cbxNhaxuong.ValueMember = "MS_N_XUONG"
        cbxNhaxuong.DataSource = _table

    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            e.Cancel = True
        End Try
        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TNPhaiNhoHonDN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating

        Try
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "DenNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                Exit Sub
            End If
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TuNgayChuaDung", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End Try

        If vTuNgay > vDenNgay Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "DNPhaiLonHonTN", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            e.Cancel = True
        End If

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            If mtxtTuNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "PhaiNhapTuNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtTuNgay.Focus()
                Exit Sub
            End If
            If mtxtDenNgay.Text.Trim.ToString = "/  /" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "PhaiNhapDenNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtDenNgay.Focus()
                Exit Sub
            End If
            Dim vtbData As New DataTable()
            v_all = New DataTable()
            vtbData = Get_DataTable(cbxNhaxuong.SelectedValue.ToString(), vTuNgay, vDenNgay, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
            vtbData.TableName = "DATA_INFO"

            If vtbData.Rows.Count > 0 Then
                Dim frmRepot As frmXMLReport = New frmXMLReport()
                frmRepot.rptName = "rptCHI_PHI_DICH_VU_THUE_NGOAI"
                frmRepot.AddDataTableSource(RefeshLanguage())
                frmRepot.AddDataTableSource(vtbData)
                frmRepot.ShowDialog()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "KoCoDuLieuDeIn", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function RefeshLanguage() As DataTable
        Dim vtbTitle As New DataTable()
        For i As Integer = 0 To 14
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TIEU_DE"
        vtbTitle.Columns(1).ColumnName = "TU_NGAY"
        vtbTitle.Columns(2).ColumnName = "DEN_NGAY"
        vtbTitle.Columns(3).ColumnName = "DIA_DIEM"
        vtbTitle.Columns(4).ColumnName = "MS_PHIEU_BT"
        vtbTitle.Columns(5).ColumnName = "MS_TB"
        vtbTitle.Columns(6).ColumnName = "TEN_TB"
        vtbTitle.Columns(7).ColumnName = "NOI_DUNG"
        vtbTitle.Columns(8).ColumnName = "SO_LUONG"
        vtbTitle.Columns(9).ColumnName = "DON_GIA"
        vtbTitle.Columns(10).ColumnName = "TI_GIA"
        vtbTitle.Columns(11).ColumnName = "THANH_TIEN"
        vtbTitle.Columns(13).ColumnName = "TONG"
        vtbTitle.Columns(14).ColumnName = "STT"
        vtbTitle.Columns(12).ColumnName = "NHA_CC"
        Dim vRowTitle As DataRow = vtbTitle.NewRow()

        vRowTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TIEU_DE", commons.Modules.TypeLanguage)
        vRowTitle("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TU_NGAY", commons.Modules.TypeLanguage) & mtxtTuNgay.Text
        vRowTitle("DEN_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "DEN_NGAY", commons.Modules.TypeLanguage) & mtxtDenNgay.Text
        vRowTitle("DIA_DIEM") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "DIA_DIEM", commons.Modules.TypeLanguage)
        vRowTitle("MS_PHIEU_BT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "MS_PHIEU_BT", commons.Modules.TypeLanguage)
        vRowTitle("MS_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "MS_TB", commons.Modules.TypeLanguage)
        vRowTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TEN_TB", commons.Modules.TypeLanguage)
        vRowTitle("NOI_DUNG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "NOI_DUNG", commons.Modules.TypeLanguage)
        vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "SO_LUONG", commons.Modules.TypeLanguage)
        vRowTitle("DON_GIA") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "DON_GIA", commons.Modules.TypeLanguage)
        vRowTitle("TI_GIA") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TI_GIA", commons.Modules.TypeLanguage)
        vRowTitle("THANH_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "THANH_TIEN", commons.Modules.TypeLanguage)
        vRowTitle("TONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "TONG", commons.Modules.TypeLanguage)
        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "STT", commons.Modules.TypeLanguage)
        vRowTitle("NHA_CC") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptCHI_PHI_DICH_VU_THUE_NGOAI", "NHA_CC", commons.Modules.TypeLanguage)

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function
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
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"
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
        Catch ex As Exception

        End Try

    End Sub
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date) As DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_CHI_PHI_DICH_VU_THUE_NGOAI_NEW]", tungay, denngay))
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GET_CHI_PHI_DICH_VU_THUE_NGOAI_NEW]", tungay, denngay))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal ngay As Date, ByVal ms_loai_may As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable
        _table = Get_DataTable(MS_N_Xuong, ngay, ms_loai_may)
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
        loadNhaXuong()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Commons.Modules.ObjSystems.XoaTable("CHI_PHI_DV_THUE_NGOAI_TMP")
        Me.ParentForm.Close()
    End Sub
End Class
