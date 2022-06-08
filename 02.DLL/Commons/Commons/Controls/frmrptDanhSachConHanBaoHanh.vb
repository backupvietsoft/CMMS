Imports Microsoft.ApplicationBlocks.Data


Public Class frmrptDanhSachConHanBaoHanh
    Dim v_all As DataTable = New DataTable()
    Private Sub frmrptDanhSachConHanBaoHanh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_NhaXuong()

        Load_LoaiTB()
        mtxtDenNgay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy")
        'refeshLanguageform()
    End Sub

    'set ngon ngu tren form chon
    Private Sub refeshLanguageform()
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "rptDanhSachConHanBaoHanh", commons.Modules.TypeLanguage)
        Me.lbaLoaiTB.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", lbaLoaiTB.Name, commons.Modules.TypeLanguage)
        Me.lbaDenNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", lbaDenNgay.Name, commons.Modules.TypeLanguage)
        Me.lbaNhaXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", lbaNhaXuong.Name, commons.Modules.TypeLanguage)
        Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", btnThucHien.Name, commons.Modules.TypeLanguage)
    End Sub

    'Load Nha xuong 
    Sub load_NhaXuong()

        Commons.Modules.ObjSystems.MLoadCboTreeList(cbxNhaXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")

    End Sub
    'Load Loai Thiet bi
    Sub Load_LoaiTB()
        'H_GET_NHA_XUONG_LOAI_MAY
        cboLoaiTB.Value = "MS_LOAI_MAY"
        cboLoaiTB.Display = "TEN_LOAI_MAY"
        cboLoaiTB.StoreName = "H_getLoaiThietBi"
        cboLoaiTB.Param = Commons.Modules.UserName
        cboLoaiTB.BindDataSource()
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        If mtxtDenNgay.Text.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "ChuaChonNgay", Commons.Modules.TypeLanguage))
        End If
        Dim vDay As DateTime
        Try
            vDay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "NgayChuaDungDD", Commons.Modules.TypeLanguage))
        End Try

        Dim frmRP As frmXMLReport = New frmXMLReport()
        If Commons.Modules.sPrivate = "HUDA" Then
            frmRP.rptName = "rptDanhSachConHanBaoHanh_Huda"
        Else
            frmRP.rptName = "rptDanhSachConHanBaoHanh"
        End If

        Dim vtbValue As DataTable = New DataTable("DS_TB")
        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetThietBiConHanBaoHanh", vDay, cbxNhaXuong.SelectedValue, cboLoaiTB.SelectedValue))
        v_all = New DataTable()
        vtbValue = Get_DataTable(cbxNhaXuong.EditValue.ToString(), vDay, cboLoaiTB.SelectedValue.ToString(), "-1", "-1", "-1")
        vtbValue.TableName = "DS_TB"
        If vtbValue.Rows.Count > 0 Then
            Dim vtblg As DataTable = New DataTable()
            vtblg = RefeshLanguage()

            frmRP.AddDataTableSource(vtblg)
            frmRP.AddDataTableSource(vtbValue)
            frmRP.Show()
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "KhongCoDuLieuDeIn", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
    End Sub

    'set ngon ngu bao cao 
    Function RefeshLanguage() As DataTable
        Dim vTbTitle As DataTable = New DataTable("Title")
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "TieuDe", Commons.Modules.TypeLanguage)
        Dim TieuDe1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "TieuDe1", Commons.Modules.TypeLanguage)
        Dim TieuDe2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "TieuDe2", Commons.Modules.TypeLanguage)
        Dim TieuDe3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "TieuDe3", Commons.Modules.TypeLanguage)
        Dim Ngay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "Ngay", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "STT", Commons.Modules.TypeLanguage)
        Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "TenMay", Commons.Modules.TypeLanguage)
        Dim SoThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "SoThe", Commons.Modules.TypeLanguage)
        Dim TenNhomTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "TenNhomTB", Commons.Modules.TypeLanguage)
        Dim SoThangBH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "SoThangBH", Commons.Modules.TypeLanguage)
        Dim NgayHetHan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "NgayHetHan", Commons.Modules.TypeLanguage)
        Dim Xuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "Xuong", Commons.Modules.TypeLanguage)
        Dim LoaiTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "LoaiTB", Commons.Modules.TypeLanguage)
        Dim NHA_CC As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "NHA_CC", Commons.Modules.TypeLanguage)
        Dim CO_QUAN_TH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "CO_QUAN_TH", Commons.Modules.TypeLanguage)
        Dim GIAY_CHUNG_NHAN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "GIAY_CHUNG_NHAN", Commons.Modules.TypeLanguage)

        vTbTitle.Columns.Add("TIEUDE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDE1", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDE2", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TIEUDE3", Type.GetType("System.String"))
        vTbTitle.Columns.Add("CO_QUAN_TH", Type.GetType("System.String"))
        vTbTitle.Columns.Add("GIAY_CHUNG_NHAN", Type.GetType("System.String"))

        vTbTitle.Columns.Add("NGAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TENMAY", Type.GetType("System.String"))
        vTbTitle.Columns.Add("SOTHE", Type.GetType("System.String"))
        vTbTitle.Columns.Add("TENNHOMTB", Type.GetType("System.String"))
        vTbTitle.Columns.Add("SOTHANGBH", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYHH", Type.GetType("System.String"))
        vTbTitle.Columns.Add("XUONG", Type.GetType("System.String"))
        vTbTitle.Columns.Add("LOAITB", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NGAYDK", Type.GetType("System.String"))
        vTbTitle.Columns.Add("NHA_CC", Type.GetType("System.String"))
        Dim rowNew As DataRow = vTbTitle.NewRow()
        rowNew("TIEUDE") = TieuDe
        rowNew("TIEUDE1") = TieuDe1
        rowNew("TIEUDE2") = TieuDe2
        rowNew("TIEUDE3") = TieuDe3
        rowNew("CO_QUAN_TH") = CO_QUAN_TH
        rowNew("GIAY_CHUNG_NHAN") = GIAY_CHUNG_NHAN

        rowNew("NGAY") = Ngay
        rowNew("STT") = STT
        rowNew("TENMAY") = TenMay
        rowNew("SOTHE") = SoThe
        rowNew("TENNHOMTB") = TenNhomTB
        rowNew("SOTHANGBH") = SoThangBH
        rowNew("NGAYHH") = NgayHetHan
        rowNew("XUONG") = Xuong
        rowNew("LOAITB") = LoaiTB
        rowNew("NGAYDK") = mtxtDenNgay.Text
        rowNew("NHA_CC") = NHA_CC
        vTbTitle.Rows.Add(rowNew)
        Return vTbTitle
    End Function

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Dim vDay As DateTime
        Try
            vDay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDanhSachConHanBaoHanh", "NgayChuaDungDD", Commons.Modules.TypeLanguage))
        End Try
    End Sub

#Region "Nhu Y"

    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal ngay As Date, ByVal ms_loai_may As String) As DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As DataTable = New DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GetThietBiConHanBaoHanh_New]", ngay, ms_loai_may))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("TEN_NHOM_MAY").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), ngay, ms_loai_may)
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
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_GetThietBiConHanBaoHanh_New]", ngay, ms_loai_may))
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

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
