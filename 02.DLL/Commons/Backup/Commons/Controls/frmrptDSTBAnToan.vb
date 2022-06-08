
Imports Microsoft.ApplicationBlocks.Data
Namespace ReportManager

    Public Class frmrptDSTBAnToan
        Dim v_all As DataTable = New DataTable
        Private Sub rptDSTBAnToan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            refeshLanguage()
            LoadNhaXuong()
            LoadHienTrang()
            rdbDayChuyen.Checked = True
        End Sub

        Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
            Try
                If cbxLoaiTB.Text.ToString.Trim = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBAnToan", "ChuaChonLoaiTB", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
                If cbxNhaXuong.Text.ToString.Trim = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDSTBAnToan", "ChuaChonXuong", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                    Exit Sub
                End If
                Dim frmRP As frmXMLReport = New frmXMLReport()
                If rdbDayChuyen.Checked = True Then
                    frmRP.rptName = "rptDSTBAnToan"
                Else
                    frmRP.rptName = "rptDSTBAnToan1"
                End If
                v_all = New DataTable()
                Dim vtbValue As DataTable = New DataTable("DS_TB")
                Dim _city As String = "-1"

                Dim _district As String = "-1"
                Dim _hientrang As Integer = 0
                Dim _street As String = "-1"
                Dim _nx As String = "-1"
                Try
                    _hientrang = Integer.Parse(cbxHienTrang.SelectedValue.ToString())
                    _city = "-1"
                    _district = "-1"
                    _street = "-1"
                    _nx = cbxNhaXuong.SelectedValue.ToString()
                Catch ex As Exception

                End Try

                If cbxLoaiTB.SelectedIndex = 0 Then
                    'In Thiết bị có trạng thái ko an toàn
                    Dim vtblg As DataTable = New DataTable()
                    vtblg = languageReport()
                    frmRP.AddDataTableSource(vtblg)
                    vtbValue = Get_DataTable(_nx, 0, _hientrang, _city, _district, _street)
                    vtbValue.TableName = "DS_TB"
                    If vtbValue.Rows.Count > 0 Then
                        frmRP.AddDataTableSource(vtbValue)
                        frmRP.Show()
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                    End If
                Else
                    If cbxLoaiTB.SelectedIndex = 1 Then
                        'In thiết bị trạng thái An Toan
                        Dim vtblg As DataTable = New DataTable()
                        vtblg = RefeshLanguaAnToan()
                        frmRP.AddDataTableSource(vtblg)
                        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_getThietBiAnToan", 1, cbxNhaXuong.SelectedValue.ToString, Integer.Parse(cbxHienTrang.SelectedValue.ToString)))
                        vtbValue = Get_DataTable(_nx, 1, _hientrang, _city, _district, _street)
                        vtbValue.TableName = "DS_TB"
                        If vtbValue.Rows.Count > 0 Then
                            frmRP.AddDataTableSource(vtbValue)
                            frmRP.ShowDialog()
                        Else
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                        End If
                    Else
                        'In tất cả 
                        frmRP.AddDataTableSource(languageReport())
                        'vtbValue.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_getThietBiAnToan", 2, cbxNhaXuong.SelectedValue.ToString, Integer.Parse(cbxHienTrang.SelectedValue.ToString)))
                        vtbValue = Get_DataTable(_nx, 2, _hientrang, _city, _district, _street)
                        vtbValue.TableName = "DS_TB"
                        If vtbValue.Rows.Count > 0 Then
                            frmRP.AddDataTableSource(vtbValue)
                            frmRP.Show()
                        Else
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "KhongCoDLDeIn", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                        End If

                    End If
                End If

            Catch ex As Exception
            End Try
        End Sub


        Private Function RefeshLanguaAnToan() As DataTable
            Dim vTbTitle As DataTable = New DataTable("Title")
            Dim TieuDeAnh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TieuDeAnh1", Commons.Modules.TypeLanguage)
            Dim TieuDeViet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TieuDeViet1", Commons.Modules.TypeLanguage)
            Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "Thang", Commons.Modules.TypeLanguage)
            Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "Maso", Commons.Modules.TypeLanguage)
            Dim TotalPage As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TotalPage", Commons.Modules.TypeLanguage)
            Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NguoiLap", Commons.Modules.TypeLanguage)
            Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NguoiDuyet", Commons.Modules.TypeLanguage)
            Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "STT", Commons.Modules.TypeLanguage)
            Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TenMay", Commons.Modules.TypeLanguage)
            Dim Kieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "Kieu", Commons.Modules.TypeLanguage)
            Dim HangSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "HangSX", Commons.Modules.TypeLanguage)
            Dim NuocSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NuocSX", Commons.Modules.TypeLanguage)
            Dim MaSoTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "MaSoTB", Commons.Modules.TypeLanguage)
            Dim NgaySD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NgaySD", Commons.Modules.TypeLanguage)
            Dim NhiemVu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NhiemVu", Commons.Modules.TypeLanguage)
            Dim TLThamKhao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TLThamKhao", Commons.Modules.TypeLanguage)
            Dim HienTrang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "HienTrang", Commons.Modules.TypeLanguage)
            Dim NoiDS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NoiDS", Commons.Modules.TypeLanguage)
            Dim LoaiTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "LoaiTB", Commons.Modules.TypeLanguage)
            vTbTitle.Columns.Add("TIEUDEANH", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TIEUDEVIET", Type.GetType("System.String"))
            vTbTitle.Columns.Add("THANG", Type.GetType("System.String"))
            vTbTitle.Columns.Add("MASO", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TOTALPAGE", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NGUOILAP", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NGUOIDUYET", Type.GetType("System.String"))
            vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TENMAY", Type.GetType("System.String"))
            vTbTitle.Columns.Add("KIEUMAY", Type.GetType("System.String"))
            vTbTitle.Columns.Add("HANGSX", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NUOCSX", Type.GetType("System.String"))
            vTbTitle.Columns.Add("MASOTB", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NGAYSD", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NHIEMVU", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TAILIEUTK", Type.GetType("System.String"))
            vTbTitle.Columns.Add("HIENTRANG", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NOIDS", Type.GetType("System.String"))
            vTbTitle.Columns.Add("LoaiTB", Type.GetType("System.String"))
            Dim rowNew As DataRow = vTbTitle.NewRow()

            rowNew("TIEUDEANH") = TieuDeAnh
            rowNew("TIEUDEVIET") = TieuDeViet
            rowNew("THANG") = Thang
            rowNew("MASO") = Maso
            rowNew("TOTALPAGE") = TotalPage
            rowNew("NGUOILAP") = NguoiLap
            rowNew("NGUOIDUYET") = NguoiDuyet
            rowNew("STT") = STT
            rowNew("TENMAY") = TenMay
            rowNew("KIEUMAY") = Kieu
            rowNew("HANGSX") = HangSX
            rowNew("NUOCSX") = NuocSX
            rowNew("MASOTB") = MaSoTB
            rowNew("NGAYSD") = NgaySD
            rowNew("NHIEMVU") = NhiemVu
            rowNew("TAILIEUTK") = TLThamKhao
            rowNew("HIENTRANG") = HienTrang
            rowNew("NOIDS") = NoiDS
            rowNew("LoaiTB") = LoaiTB
            vTbTitle.Rows.Add(rowNew)

            Return vTbTitle
        End Function


        Private Function languageReport() As DataTable
            Dim vTbTitle As DataTable = New DataTable("Title")
            Dim TieuDeAnh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TieuDeAnh", Commons.Modules.TypeLanguage)
            Dim TieuDeViet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TieuDeViet", Commons.Modules.TypeLanguage)
            Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "Thang", Commons.Modules.TypeLanguage)
            Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "Maso", Commons.Modules.TypeLanguage)
            Dim TotalPage As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TotalPage", Commons.Modules.TypeLanguage)
            Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NguoiLap", Commons.Modules.TypeLanguage)
            Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NguoiDuyet", Commons.Modules.TypeLanguage)
            Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "STT", Commons.Modules.TypeLanguage)
            Dim TenMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TenMay", Commons.Modules.TypeLanguage)
            Dim Kieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "Kieu", Commons.Modules.TypeLanguage)
            Dim HangSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "HangSX", Commons.Modules.TypeLanguage)
            Dim NuocSX As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NuocSX", Commons.Modules.TypeLanguage)
            Dim MaSoTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "MaSoTB", Commons.Modules.TypeLanguage)
            Dim NgaySD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NgaySD", Commons.Modules.TypeLanguage)
            Dim NhiemVu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NhiemVu", Commons.Modules.TypeLanguage)
            Dim TLThamKhao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "TLThamKhao", Commons.Modules.TypeLanguage)
            Dim HienTrang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "HienTrang", Commons.Modules.TypeLanguage)
            Dim NoiDS As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "NoiDS", Commons.Modules.TypeLanguage)
            Dim LoaiTB As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "LoaiTB", Commons.Modules.TypeLanguage)
            vTbTitle.Columns.Add("TIEUDEANH", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TIEUDEVIET", Type.GetType("System.String"))
            vTbTitle.Columns.Add("THANG", Type.GetType("System.String"))
            vTbTitle.Columns.Add("MASO", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TOTALPAGE", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NGUOILAP", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NGUOIDUYET", Type.GetType("System.String"))
            vTbTitle.Columns.Add("STT", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TENMAY", Type.GetType("System.String"))
            vTbTitle.Columns.Add("KIEUMAY", Type.GetType("System.String"))
            vTbTitle.Columns.Add("HANGSX", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NUOCSX", Type.GetType("System.String"))
            vTbTitle.Columns.Add("MASOTB", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NGAYSD", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NHIEMVU", Type.GetType("System.String"))
            vTbTitle.Columns.Add("TAILIEUTK", Type.GetType("System.String"))
            vTbTitle.Columns.Add("HIENTRANG", Type.GetType("System.String"))
            vTbTitle.Columns.Add("NOIDS", Type.GetType("System.String"))
            vTbTitle.Columns.Add("LoaiTB", Type.GetType("System.String"))
            Dim rowNew As DataRow = vTbTitle.NewRow()

            rowNew("TIEUDEANH") = TieuDeAnh
            rowNew("TIEUDEVIET") = TieuDeViet
            rowNew("THANG") = Thang
            rowNew("MASO") = Maso
            rowNew("TOTALPAGE") = TotalPage
            rowNew("NGUOILAP") = NguoiLap
            rowNew("NGUOIDUYET") = NguoiDuyet
            rowNew("STT") = STT
            rowNew("TENMAY") = TenMay
            rowNew("KIEUMAY") = Kieu
            rowNew("HANGSX") = HangSX
            rowNew("NUOCSX") = NuocSX
            rowNew("MASOTB") = MaSoTB
            rowNew("NGAYSD") = NgaySD
            rowNew("NHIEMVU") = NhiemVu
            rowNew("TAILIEUTK") = TLThamKhao
            rowNew("HIENTRANG") = HienTrang
            rowNew("NOIDS") = NoiDS
            rowNew("LoaiTB") = LoaiTB
            vTbTitle.Rows.Add(rowNew)
            Return vTbTitle
        End Function

        'set ngon ngu tren form chon
        Private Sub refeshLanguage()
            Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", "rptDSTBAnToan", Commons.Modules.TypeLanguage)
            Me.lbaLoaiTB.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", lbaLoaiTB.Name, Commons.Modules.TypeLanguage)
            Me.lbaNhaXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", lbaNhaXuong.Name, Commons.Modules.TypeLanguage)
            Me.lbaHienTrang.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", lbaHienTrang.Name, Commons.Modules.TypeLanguage)
            Me.rdbDayChuyen.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", rdbDayChuyen.Name, Commons.Modules.TypeLanguage)
            Me.rdoLoaiMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", rdoLoaiMay.Name, Commons.Modules.TypeLanguage)
            Me.btnThucHien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", btnThucHien.Name, Commons.Modules.TypeLanguage)
            Me.lbaNhaXuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDSTBAnToan", lbaNhaXuong.Name, Commons.Modules.TypeLanguage)

        End Sub
        'Load cbo nha xuong 
        Private Sub LoadNhaXuong()
            'cbxNhaXuong.Value = "MS_N_XUONG"
            'cbxNhaXuong.Display = "TEN_N_XUONG"
            'cbxNhaXuong.StoreName = "GetNHA_XUONGs"
            'cbxNhaXuong.Param = Commons.Modules.UserName
            'cbxNhaXuong.BindDataSource()
            Dim _table As DataTable = New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, "-1", "-1", "-1"))
            cbxNhaXuong.DisplayMember = "TEN_N_XUONG"
            cbxNhaXuong.ValueMember = "MS_N_XUONG"
            cbxNhaXuong.DataSource = _table
        End Sub

        Sub LoadHienTrang()

            cbxHienTrang.Value = "MS_HIEN_TRANG"
            cbxHienTrang.Display = "TEN_HIEN_TRANG"
            cbxHienTrang.StoreName = "H_GetHienTrangSuDungMay"
            cbxHienTrang.Param = Commons.Modules.UserName
            cbxHienTrang.BindDataSource()
        End Sub
#Region "Nhu Y"
       
        Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal antoan As Integer, ByVal ms_hien_trang As Integer) As DataTable


            If MS_N_Xuong <> "-1" Then
                Dim objDataTable As DataTable = New DataTable
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_getThietBiAnToan_new]", antoan, ms_hien_trang))
                Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
                Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
                Dim nhom_may As String = vDataDetail(0)("MS_NHOM_MAY").ToString()
                Dim temp As DataView = vDataParent
                If String.IsNullOrEmpty(nhom_may) Then
                    For Each vr As DataRow In vDataParent.ToTable().Rows
                        If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                            Try
                                temp.Table.TableName = "test"
                                temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), antoan, ms_hien_trang)
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
                objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_getThietBiAnToan_new]", antoan, ms_hien_trang))
                Return objDataTable
            End If
        End Function
        Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal antoan As Integer, ByVal ms_he_thong As Integer, ByRef city As String, _
                               ByVal district As String, ByVal street As String)
            Dim _table As DataTable = New DataTable
            _table = Get_DataTable(MS_N_Xuong, antoan, ms_he_thong)
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

End Namespace