Imports Microsoft.ApplicationBlocks.Data
Public Class frmrptKeHoachSuaChuaThietBi_KKTL
    Dim v_all As DataTable = New DataTable()
    Private Sub frmrptKeHoachSuaChuaThietBi_KKTL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpTN.Value = (SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT GETDATE()")).ToString()
        dtpDN.Value = Convert.ToDateTime(dtpTN.Value).AddMonths(1) ' dtpTN.Value.Day.ToString() + "/" + dtpTN.Value.AddMonths(1).Month.ToString() + "/" + dtpTN.Value.Year.ToString()

        Dim dtDD As New DataTable
        dtDD.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VIs"))
        cboDiadiem.ValueMember = "MS_DON_VI"
        cboDiadiem.DisplayMember = "TEN_DON_VI"
        cboDiadiem.DataSource = dtDD
        If dtDD.Rows.Count > 0 Then
            cboDiadiem.SelectedIndex = 0
        End If

        'GetNhaXuong()
    End Sub

    Private Sub GetNhaXuong()
        Dim dtNX As New DataTable
        dtNX.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_NHA_XUONG_DONVI", cboDiadiem.SelectedValue, Commons.Modules.UserName))
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DisplayMember = "TEN_N_XUONG"
        cboNhaxuong.DataSource = dtNX

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If cboNhaxuong.Text <> "" Then

            If dtpDN.Value.Year <> dtpTN.Value.Year Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "Denngayphaicungnam", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpDN.Focus()
                Exit Sub
            End If
            If dtpTN.Value < DateTime.Parse(DateTime.Now.ToShortDateString) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "Tungayphailonhonngayhientai", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpTN.Focus()
                Exit Sub
            End If
            If dtpTN.Value > dtpDN.Value Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "Tungayphainhohondenngay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpTN.Focus()
                Exit Sub
            End If
            v_all = New DataTable()
            'Dim sqlconn As New SqlClient.SqlConnection
            'sqlconn.ConnectionString = Vietsoft.Information.ConnectionString
            'sqlconn.Open()
            Dim nhaxuong As String = cboNhaxuong.SelectedValue.ToString()
            Dim TbSource As New DataTable()
            TbSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getKeHoachsuachuathietbi", dtpTN.Value, dtpDN.Value, nhaxuong, Modules.UserName, Modules.UserName)) 'Modules.UserName
            'If sqlconn.State = ConnectionState.Open Then
            '    sqlconn.Close()
            'End If
            'TbSource = Get_DataTable(cboNhaxuong.SelectedValue.ToString(), Convert.ToDateTime(dtpTN.Value), Convert.ToDateTime(dtpDN.Value), cboDiadiem.SelectedValue.ToString())
            If TbSource.Rows.Count <= 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "msgKhongcodulieudein", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            TbSource.TableName = "rptKeHoachSuaChuaThietBi"

            Dim frmRptView As New frmXMLReport()
            frmRptView.rptName = "rptKeHoachSuaChuaThietBi"
            frmRptView.AddDataTableSource(TbSource)

            Dim TbTieuDe As New DataTable()
            TbTieuDe.Columns.Add("TIEU_DE")
            TbTieuDe.Columns.Add("TIEU_DE1")
            TbTieuDe.Columns.Add("TIEU_DE2")
            TbTieuDe.Columns.Add("MASO")
            TbTieuDe.Columns.Add("LAN_BAN_HANH")
            TbTieuDe.Columns.Add("NGAY_HIEU_LUC")
            TbTieuDe.Columns.Add("SO_QD")
            TbTieuDe.Columns.Add("TU_NGAY")
            TbTieuDe.Columns.Add("PHAN_XUONG")
            TbTieuDe.Columns.Add("NHA_MAY")
            TbTieuDe.Columns.Add("DUYET")
            TbTieuDe.Columns.Add("TEN")
            TbTieuDe.Columns.Add("CHUC_VU")
            TbTieuDe.Columns.Add("CHU_KY")
            TbTieuDe.Columns.Add("STT")
            TbTieuDe.Columns.Add("CAU_TRUC_MAY")
            TbTieuDe.Columns.Add("NOI_DUNG_CV")
            TbTieuDe.Columns.Add("NGAY_BT")
            TbTieuDe.Columns.Add("LOAI_BT")
            TbTieuDe.Columns.Add("THOI_GIAN_THUC_HIEN")
            TbTieuDe.Columns.Add("GHICHU")
            TbTieuDe.Columns.Add("LOAI_CV")
            TbTieuDe.Columns.Add("MA_TB")
            TbTieuDe.Columns.Add("TEN_TB")
            TbTieuDe.Columns.Add("SOKIEMKE")
            TbTieuDe.Columns.Add("TONG_THOI_GIAN1")
            TbTieuDe.Columns.Add("TONG_THOI_GIAN2")
            TbTieuDe.Columns.Add("TONG_THOI_GIAN3")
            TbTieuDe.Columns.Add("TMP1")
            TbTieuDe.Columns.Add("TMP2")
            TbTieuDe.Columns.Add("NHA_XUONG")
            Dim rTitle As DataRow
            rTitle = TbTieuDe.NewRow()
            rTitle("TIEU_DE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TIEU_DE", commons.Modules.TypeLanguage)
            rTitle("TIEU_DE1") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TIEU_DE1", commons.Modules.TypeLanguage)
            rTitle("TIEU_DE2") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TIEU_DE2", commons.Modules.TypeLanguage)
            rTitle("MASO") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "MASO", commons.Modules.TypeLanguage)
            rTitle("LAN_BAN_HANH") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "LAN_BAN_HANH", commons.Modules.TypeLanguage)
            rTitle("NGAY_HIEU_LUC") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "NGAY_HIEU_LUC", commons.Modules.TypeLanguage)
            rTitle("TU_NGAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "THOI_GIAN_TU", commons.Modules.TypeLanguage) + " " + dtpTN.Text.Trim + " " + Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "DEN", commons.Modules.TypeLanguage) + " " + dtpDN.Text.Trim
            rTitle("SO_QD") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "SO_QD", commons.Modules.TypeLanguage) + ".../" + dtpTN.Value.Month.ToString + " " + Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "QDKHSC", commons.Modules.TypeLanguage)
            rTitle("PHAN_XUONG") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "PHAN_XUONG", commons.Modules.TypeLanguage)
            rTitle("NHA_MAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "NHA_MAY", commons.Modules.TypeLanguage) + " " + cboDiadiem.Text
            rTitle("DUYET") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "DUYET", commons.Modules.TypeLanguage)
            rTitle("TEN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TEN", commons.Modules.TypeLanguage)
            rTitle("CHUC_VU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "CHUC_VU", commons.Modules.TypeLanguage)
            rTitle("CHU_KY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "CHU_KY", commons.Modules.TypeLanguage)
            rTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "STT", commons.Modules.TypeLanguage)
            rTitle("CAU_TRUC_MAY") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "CAU_TRUC_MAY", commons.Modules.TypeLanguage)
            rTitle("NOI_DUNG_CV") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "NOI_DUNG_CV", commons.Modules.TypeLanguage)
            rTitle("NGAY_BT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "NGAY_BT", commons.Modules.TypeLanguage)
            rTitle("LOAI_BT") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "LOAI_BT", commons.Modules.TypeLanguage)
            rTitle("THOI_GIAN_THUC_HIEN") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "THOI_GIAN_THUC_HIEN", commons.Modules.TypeLanguage)
            rTitle("GHICHU") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "GHICHU", commons.Modules.TypeLanguage)

            rTitle("LOAI_CV") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "LOAI_CV", commons.Modules.TypeLanguage)
            rTitle("MA_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "MA_TB", commons.Modules.TypeLanguage)
            rTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TEN_TB", commons.Modules.TypeLanguage)
            rTitle("SOKIEMKE") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "SOKIEMKE", commons.Modules.TypeLanguage)
            rTitle("TONG_THOI_GIAN1") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TONG_THOI_GIAN1", commons.Modules.TypeLanguage)
            rTitle("TONG_THOI_GIAN2") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TONG_THOI_GIAN2", commons.Modules.TypeLanguage)
            rTitle("TONG_THOI_GIAN3") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TONG_THOI_GIAN3", commons.Modules.TypeLanguage)
            rTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TMP1", commons.Modules.TypeLanguage)
            rTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachSuaChuaThietBi_KKTL", "TMP2", commons.Modules.TypeLanguage)
            rTitle("NHA_XUONG") = cboNhaxuong.Text
            TbTieuDe.TableName = "rptTieuDe_KehoachSuachuathietbi"
            TbTieuDe.Rows.Add(rTitle)
            frmRptView.AddDataTableSource(TbTieuDe)
            frmRptView.ShowDialog(Me)
        End If

    End Sub

    Private Sub cboDiadiem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiadiem.SelectedIndexChanged
        GetNhaXuong()
    End Sub
#Region "Nhu Y"

    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[getKeHoachsuachuathietbi_new]", tungay, denngay, Commons.Modules.UserName, Commons.Modules.UserName))
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[getKeHoachsuachuathietbi_new]", tungay, denngay, Commons.Modules.UserName, Commons.Modules.UserName))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_dv As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay)
        Dim _ms_dv As String = ""

        If _table.Rows.Count > 0 Then
            If _ms_dv <> "-1" Then
                _ms_dv = "MS_DON_VI = '" + ms_dv + "'"
                _table.DefaultView.RowFilter = _ms_dv
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
            'Dim _row As DataRow = _table.NewRow()
            '_row("Ten_N_Xuong") = cboNhaxuong.Text
            '_row("MS_MAY_FINAL") = ""
            '_row("MS_CHA") = ""
            '_row("MS_DON_VI") = ""
            '_row("MS_N_XUONG_FINAL") = cboNhaxuong.SelectedValue
            '_table.Rows.InsertAt(_row, 0)
        End If
        Return _table
    End Function
#End Region
  
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
