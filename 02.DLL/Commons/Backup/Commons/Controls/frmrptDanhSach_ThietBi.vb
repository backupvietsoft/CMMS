Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms

Public Class frmrptDanhSach_ThietBi
    Private SqlText As String = String.Empty
    Dim v_all As DataTable = New DataTable()
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Commons.clsXuLy.CreateTitleReport()
        Call Printpreview1()
    End Sub

    Private Sub frmrptDanhSach_ThietBi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadNhaxuong()
        LoadNhaxuong()
        LoadLoaiTB()
    End Sub

    Sub LoadLoaiTB()
        Dim dt As New DataTable
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Loai_TB", Commons.Modules.UserName))
        Dim dtRow As DataRow
        dtRow = dt.NewRow
        dtRow("MS_LOAI_MAY") = -1
        dtRow("TEN_LOAI_MAY") = " < ALL > "
        dt.Rows.InsertAt(dtRow, 0)

        cboLoaiThietBi.DataSource = dt
        cboLoaiThietBi.ValueMember = "MS_LOAI_MAY"
        cboLoaiThietBi.DisplayMember = "TEN_LOAI_MAY"

    End Sub

    Sub LoadNhaxuong()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
        cboNhaxuong.DisplayMember = "TEN_N_XUONG"
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DataSource = _table
    End Sub

    Sub Printpreview1()
        Dim dtDANH_SACH_THIET_BI_TMP As New DataTable
        Dim dtTIEU_DE_DANH_SACH_THIET_BI_TMP As New DataTable

        Cursor = Cursors.WaitCursor
        dtDANH_SACH_THIET_BI_TMP.Clear()
        dtTIEU_DE_DANH_SACH_THIET_BI_TMP.Clear()

        dtDANH_SACH_THIET_BI_TMP = CreateData1()
        dtTIEU_DE_DANH_SACH_THIET_BI_TMP = RefeshLanguageReport1()

        If dtDANH_SACH_THIET_BI_TMP.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim frm As New frmXMLReport
        frm.rptName = "rptDanhSachThietBi"
        frm.RemoveDataTableSource()
        frm.AddDataTableSource(dtDANH_SACH_THIET_BI_TMP)
        frm.AddDataTableSource(dtTIEU_DE_DANH_SACH_THIET_BI_TMP)
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Function CreateData1() As DataTable
        Dim dtDuLieu As New DataTable

        Cursor = Cursors.WaitCursor
        Dim _city As String = "-1"

        Dim _district As String = "-1"
        Dim _loai_may As String = "-1"
        Dim _street As String = "-1"
        Dim _nx As String = "-1"
        Try
            _city = "-1"
            _district = "-1"
            _street = "-1"
            _nx = cboNhaxuong.SelectedValue.ToString()
            _loai_may = cboLoaiThietBi.SelectedValue.ToString()
        Catch ex As Exception
            _city = "-1"
            _district = "-1"
            _street = "-1"
            _nx = "-1"
            _loai_may = "-1"
        End Try
        v_all = New DataTable()
        dtDuLieu = Get_DataTable(_nx, _loai_may, _city, _district, _street)
        dtDuLieu.TableName = "rptDANH_SACH_THIET_BI_TMP"
        Cursor = Cursors.Default
        Return dtDuLieu
    End Function


    Private Function RefeshLanguageReport1() As DataTable
        Dim dtTieuDe As New DataTable
        Dim danhsachthietbi, tennhaxuong, tenloaimay, stt, maso, sothe, nhomthietbi, chucnang, hangsx, nuocsx, trang As String

        danhsachthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "rptDanhSach_ThietBi  ", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "sothe", Commons.Modules.TypeLanguage)
        nhomthietbi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nhomthietbi", Commons.Modules.TypeLanguage)
        chucnang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "chucnang", Commons.Modules.TypeLanguage)
        hangsx = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "hangsx", Commons.Modules.TypeLanguage)
        nuocsx = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "nuocsx", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSach_ThietBi", "trang", Commons.Modules.TypeLanguage)

        Dim dtRow As DataRow, dtColumn As New DataColumn

        dtTieuDe.Columns.Clear()

        dtTieuDe.Columns.Add("_TIEU_DE_", GetType(String))
        dtTieuDe.Columns.Add("_TEN_NHA_XUONG_", GetType(String))
        dtTieuDe.Columns.Add("_TEN_LOAI_MAY_", GetType(String))
        dtTieuDe.Columns.Add("_STT_", GetType(String))
        dtTieuDe.Columns.Add("_MA_SO_", GetType(String))
        dtTieuDe.Columns.Add("_SO_THE_", GetType(String))
        dtTieuDe.Columns.Add("_NHOM_THIET_BI_", GetType(String))
        dtTieuDe.Columns.Add("_CHUC_NANG_", GetType(String))
        dtTieuDe.Columns.Add("_HANG_SX_", GetType(String))
        dtTieuDe.Columns.Add("_NUOC_SX_", GetType(String))
        dtTieuDe.Columns.Add("_TRANG_", GetType(String))

        dtRow = dtTieuDe.NewRow
        dtRow.Item("_TIEU_DE_") = danhsachthietbi
        dtRow.Item("_TEN_NHA_XUONG_") = tennhaxuong
        dtRow.Item("_TEN_LOAI_MAY_") = tenloaimay
        dtRow.Item("_STT_") = stt
        dtRow.Item("_MA_SO_") = maso
        dtRow.Item("_SO_THE_") = sothe
        dtRow.Item("_NHOM_THIET_BI_") = nhomthietbi
        dtRow.Item("_CHUC_NANG_") = chucnang
        dtRow.Item("_HANG_SX_") = hangsx
        dtRow.Item("_NUOC_SX_") = nuocsx
        dtRow.Item("_TRANG_") = trang
        dtTieuDe.Rows.Add(dtRow)

        dtTieuDe.TableName = "rptTIEU_DE_DANH_SACH_THIET_BI_TMP"
        Return dtTieuDe
    End Function
#Region "Nhu Y"
   
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal ms_loai_may As String) As DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_DSLM]", ms_loai_may))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_NHOM_MAY").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), ms_loai_may)
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_DSLM]", ms_loai_may))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal ms_loai_may As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable
        _table = Get_DataTable(MS_N_Xuong, ms_loai_may)
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

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
