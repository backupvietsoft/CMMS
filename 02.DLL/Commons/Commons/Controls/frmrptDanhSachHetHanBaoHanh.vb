
Imports Microsoft.ApplicationBlocks.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmrptDanhSachHetHanBaoHanh
    Private SqlText As String = String.Empty
    Dim v_all As DataTable = New DataTable
    Dim vtbValue As DataTable = New DataTable()
    Dim vtbThongtinchung As DataTable = New DataTable("rptTHONG_TIN_CHUNG_TMP")
    Dim vtbHeader As DataTable = New DataTable("rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP")
    Private Sub frmrptDanhSachHetHanBaoHanh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadNhaxuong()
        LoadLoaiTB()
        txtDenngay.Value = DateTime.Now()
        txtTungay.Value = DateTime.Now.AddMonths(-1)
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
        Commons.Modules.ObjSystems.MLoadCboTreeList(cboNhaxuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        ' clsXuLy.CreateTitleReport()
        If txtDenngay.Value < txtTungay.Value Then
            If Commons.Modules.TypeLanguage = 0 Then
                MsgBox("Chọn ngày không hợp lệ")
            ElseIf Commons.Modules.TypeLanguage = 1 Then
                MsgBox("Date is valid")
            End If
        Else
            Call CreateData2()
            Call Printpreview2()
            Dim frmRP As frmXMLReport = New frmXMLReport()
            If Commons.Modules.sPrivate = "HUDA" Then
                frmRP.rptName = "rptDanhSachHetHanBaoHanh_Huda"
            Else
                frmRP.rptName = "rptDanhSachHetHanBaoHanh"
            End If
            If vtbValue.Rows.Count > 0 Then
                frmRP.AddDataTableSource(vtbThongtinchung)
                frmRP.AddDataTableSource(vtbHeader)
                frmRP.AddDataTableSource(vtbValue)
                frmRP.Show()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "KhongCoDuLieuDeIn", Commons.Modules.TypeLanguage))
                Exit Sub
            End If


        End If
    End Sub

    Function TDateFormat(ByVal sDate As String) As String
        Dim sDateValue As String = String.Empty
        Dim dDate As Date = CDate(sDate)
        Dim ci As CultureInfo = New CultureInfo("en-US")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        sDateValue = dDate.ToString("d", ci)
        Return sDateValue
    End Function
    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        vtbThongtinchung = New DataTable("rptTHONG_TIN_CHUNG_TMP")
        If Commons.Modules.TypeLanguage = 1 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))

        End If
        If Commons.Modules.TypeLanguage = 0 Then
            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS THONG_TIN_CTY, THONG_TIN_CHUNG.LOGO,  THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI_CTY, THONG_TIN_CHUNG.phone as DIEN_THOAI ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT,THONG_TIN_CHUNG.LE_TREN_LOGO,ngay_in='" & TDateFormat(Now) & "'   FROM THONG_TIN_CHUNG"
            vtbThongtinchung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        End If
    End Sub
    Sub WriteXML()
        Dim source As DataSet = New DataSet()
        source.Tables.Add(vtbValue)
        source.Tables.Add(vtbThongtinchung)
        source.Tables.Add(vtbHeader)
        source.WriteXml(Application.StartupPath + "\rptDanhSachHetHanBaoHanh.xml", XmlWriteMode.WriteSchema)
    End Sub
    Sub CreateData2()
        Cursor = Cursors.WaitCursor
        RefeshHeaderReport()
        RefeshLanguageReport2()
        Try
            SqlText = "DROP TABLE MAY_NHA_XUONG_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try


        vtbValue = New DataTable("HET_HAN_BH_TEMP")
        v_all = New DataTable()
        vtbValue = Get_DataTable(cboNhaxuong.EditValue.ToString(), TDateFormat(txtTungay.Text) _
                             , TDateFormat(txtDenngay.Text), cboLoaiThietBi.SelectedValue.ToString() _
                             , "-1", "-1", "-1")

        vtbValue.TableName = "HET_HAN_BH_TEMP"
        WriteXML()



        Cursor = Cursors.Default
    End Sub

    Sub Printpreview2()
        Cursor = Cursors.Default
KetThuc:
    End Sub

    Private Sub RefeshLanguageReport2()
        Dim danhsachthietbihethanbaohanh, tungay, denngay, tennhaxuong, tenloaimay, stt, maso As String
        Dim sothe, tennhommay, sothangbh, ngayhethanbh, trang As String, DKLoc As String, NHA_CC As String

        danhsachthietbihethanbaohanh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "danhsachthietbihethanbaohanh", Commons.Modules.TypeLanguage)
        tungay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tungay", Commons.Modules.TypeLanguage)
        denngay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "denngay", Commons.Modules.TypeLanguage)
        tennhaxuong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tennhaxuong", Commons.Modules.TypeLanguage)
        tenloaimay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "tenloaimay", Commons.Modules.TypeLanguage)
        stt = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "stt", Commons.Modules.TypeLanguage)
        maso = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " maso", Commons.Modules.TypeLanguage)
        sothe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "sothe", Commons.Modules.TypeLanguage)
        tennhommay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " tennhommay", Commons.Modules.TypeLanguage)
        sothangbh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "sothangbh", Commons.Modules.TypeLanguage)
        ngayhethanbh = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", " ngayhethanbh", Commons.Modules.TypeLanguage)
        trang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "trang", Commons.Modules.TypeLanguage)

        NHA_CC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachHetHanBaoHanh", "NHA_CC", Commons.Modules.TypeLanguage)
        DKLoc = tungay & " " & Format(txtTungay.Value, "dd/MM/yyyy") & "    " & denngay & " " & Format(txtDenngay.Value, "dd/MM/yyyy")
        vtbHeader = New DataTable("rptDANH_SACH_THIET_BI_HET_HAN_BAO_HANH_TMP")
        vtbHeader.Columns.Add("DANH_SACH_HET_HAN_BH_")
        vtbHeader.Columns.Add("TU_NGAY_")
        vtbHeader.Columns.Add("DEN_NGAY_")
        vtbHeader.Columns.Add("TEN_NHA_XUONG_")
        vtbHeader.Columns.Add("TEN_LOAI_MAY_")
        vtbHeader.Columns.Add("STT_")
        vtbHeader.Columns.Add("MA_SO_")
        vtbHeader.Columns.Add("SO_THE_")
        vtbHeader.Columns.Add("TEN_NHOM_MAY_")
        vtbHeader.Columns.Add("SO_THANG_BH_")
        vtbHeader.Columns.Add("NGAY_HET_HAN_BH_")
        vtbHeader.Columns.Add("TRANG_")
        vtbHeader.Columns.Add("DK_LOC_")
        vtbHeader.Columns.Add("NHA_CC")
        vtbHeader.Rows.Add(danhsachthietbihethanbaohanh, tungay, denngay, tennhaxuong, tenloaimay, stt, maso, sothe, tennhommay, sothangbh, ngayhethanbh, trang, DKLoc, NHA_CC)
    End Sub
#Region "Nhu Y"
    
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_loai_may As String) As DataTable
        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[S_DANHSACH_TBHHBH]", tungay, denngay, ms_loai_may))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("TEN_NHOM_MAY").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then

                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), tungay, denngay, ms_loai_may)
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[S_DANHSACH_TBHHBH]", tungay, denngay, ms_loai_may))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_loai_may As String, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As DataTable = New DataTable
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay, ms_loai_may)
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
