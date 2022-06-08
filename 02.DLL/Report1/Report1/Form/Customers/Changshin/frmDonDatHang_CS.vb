
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports H.COMBO
Imports Office

Public Class frmDonDatHang_CS

    Private vEvent As String = Nothing
    Private vListPO As New DataTable()
    Private vIndex As Integer = -1
    Private vMS_DDH As String = Nothing
    Private vThang As DateTime

    Private Sub frmDonDatHang_CS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        formatgrdListPO()
        formatgrdPODetail()
        loadThangPO()
        loadData()
        BindData()
        lockControl()
        lockControlDetail()
        lockInput(True)
        loadKhachHang()
        loadCongNhan()
        'AddHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
        AddHandler rdbDaDuyet.CheckedChanged, AddressOf rdbDaDuyet_CheckedChanged
        AddHandler cboPOThang.SelectedIndexChanged, AddressOf cboPOThang_SelectedIndexChanged
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

    End Sub

    Sub RefeshLangua()

    End Sub


    'Load Data 
    Sub loadData()
        Dim vtbData As New System.Data.DataTable()

        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetDonDatHang_CS", vThang, IIf(rdbChuaDuyet.Checked = True, 0, 1)))
        vtbData.Columns("DUYET1").DefaultValue = False
        vtbData.Columns("DUYET2").DefaultValue = False
        vtbData.Columns("DUYET3").DefaultValue = False
        vtbData.Columns("DUYET4").DefaultValue = False
        vtbData.Columns("DUYET").DefaultValue = False

        vtbData.Columns("YKIEN_DUYET").DefaultValue = ""
        vtbData.Columns("YKIEN_DUYET2").DefaultValue = ""
        vtbData.Columns("YKIEN_DUYET3").DefaultValue = ""
        vtbData.Columns("YKIEN_DUYET4").DefaultValue = ""

        grdListPO.DataSource = vtbData

        'grdListPO.Columns("TEN_CONG_NHAN").Visible = False
        'grdListPO.Columns("MS_KH").Visible = False
        'grdListPO.Columns("NGUOI_LIEN_HE").Visible = False
        'grdListPO.Columns("GHI_CHU").Visible = False
        'grdListPO.Columns("VAT").Visible = False
        'grdListPO.Columns("DIA_CHI").Visible = False
        'grdListPO.Columns("DIEN_THOAI").Visible = False
        'grdListPO.Columns("FAX").Visible = False
        'grdListPO.Columns("MS_CONG_NHAN").Visible = False
        vListPO = vtbData
    End Sub
    Sub BindData()

        txtMsDDH.DataBindings.Clear()
        txtMsDDH.DataBindings.Add("text", vListPO, "MS_DDH", True, DataSourceUpdateMode.OnPropertyChanged)

        mTxtNgayLap.DataBindings.Clear()
        mTxtNgayLap.DataBindings.Add("text", vListPO, "NGAY_LAP", True, DataSourceUpdateMode.OnPropertyChanged)

        cboKhachHang.DataBindings.Clear()
        cboKhachHang.DataBindings.Add("SelectedValue", vListPO, "MS_KH", True, DataSourceUpdateMode.OnPropertyChanged)

        'txtTenKH.DataBindings.Clear()
        'txtTenKH.DataBindings.Add("text", vListPO, "TEN_CONG_TY", True, DataSourceUpdateMode.OnPropertyChanged)


        mtxtNgayGiao.DataBindings.Clear()
        mtxtNgayGiao.DataBindings.Add("text", vListPO, "NGAY_GIAO", True, DataSourceUpdateMode.OnPropertyChanged)

        txtNguoiLH.DataBindings.Clear()
        txtNguoiLH.DataBindings.Add("text", vListPO, "NGUOI_LIEN_HE")

        cboNguoiLH.DataBindings.Clear()
        cboNguoiLH.DataBindings.Add("SelectedValue", vListPO, "MS_CONG_NHAN", True, DataSourceUpdateMode.OnValidation, String.Empty, "", System.Globalization.CultureInfo.CurrentCulture)

        txtGhiChu.DataBindings.Clear()
        txtGhiChu.DataBindings.Add("text", vListPO, "GHI_CHU")

        txtDiachi.DataBindings.Clear()
        txtDiachi.DataBindings.Add("text", vListPO, "DIA_CHI", True, DataSourceUpdateMode.OnPropertyChanged)

        txtDienThoai.DataBindings.Clear()
        txtDienThoai.DataBindings.Add("text", vListPO, "DIEN_THOAI", True, DataSourceUpdateMode.OnPropertyChanged)

        txtFax.DataBindings.Clear()
        txtFax.DataBindings.Add("text", vListPO, "FAX", True, DataSourceUpdateMode.OnPropertyChanged)

        txtVAT.DataBindings.Clear()
        txtVAT.DataBindings.Add("text", vListPO, "VAT")


        chxDuyet1.DataBindings.Clear()
        chxDuyet1.DataBindings.Add("Checked", vListPO, "DUYET1", True, DataSourceUpdateMode.OnValidation, False, "", System.Globalization.CultureInfo.CurrentCulture)

        chxDuyet2.DataBindings.Clear()
        chxDuyet2.DataBindings.Add("Checked", vListPO, "DUYET2", True, DataSourceUpdateMode.OnValidation, False)

        chxDuyet3.DataBindings.Clear()
        chxDuyet3.DataBindings.Add("Checked", vListPO, "DUYET3", True, DataSourceUpdateMode.OnValidation, False)

        chxDuyet4.DataBindings.Clear()
        chxDuyet4.DataBindings.Add("Checked", vListPO, "DUYET4", True, DataSourceUpdateMode.OnValidation, False)


        txtYKien1.DataBindings.Clear()
        txtYKien1.DataBindings.Add("text", vListPO, "YKIEN_DUYET")

        txtYKien2.DataBindings.Clear()
        txtYKien2.DataBindings.Add("text", vListPO, "YKIEN_DUYET2")

        txtYKien3.DataBindings.Clear()
        txtYKien3.DataBindings.Add("text", vListPO, "YKIEN_DUYET3")

        txtYKien4.DataBindings.Clear()
        txtYKien4.DataBindings.Add("text", vListPO, "YKIEN_DUYET4")

    End Sub

    Sub lockControlDetail()
        If vEvent = "A" Or vEvent = "E" Then
            Me.grdPODetail.Columns("SO_LUONG").ReadOnly = False
            Me.grdPODetail.Columns("DON_GIA").ReadOnly = False
            Me.grdPODetail.Columns("TI_GIA").ReadOnly = False
            Me.grdPODetail.Columns("GHI_CHU").ReadOnly = False
            Me.grdPODetail.Columns("NGOAI_TE").ReadOnly = False

        Else
            Me.grdPODetail.Columns("SO_LUONG").ReadOnly = True
            Me.grdPODetail.Columns("DON_GIA").ReadOnly = True
            Me.grdPODetail.Columns("TI_GIA").ReadOnly = True
            Me.grdPODetail.Columns("GHI_CHU").ReadOnly = True
            Me.grdPODetail.Columns("NGOAI_TE").ReadOnly = True
        End If

    End Sub
    'Dieu khien button 
    Sub lockControl()
        If rdbChuaDuyet.Checked = True Then
            If vEvent = "A" Or vEvent = "E" Then
                btnGhi.Enabled = True
                btnKhongGhi.Enabled = True
                btnThoat.Enabled = True
                btnChonVTPT.Enabled = True
                btnTaoMa.Enabled = True
                btnThem.Enabled = False
                btnSua.Enabled = False
                btnXoa.Enabled = False
                btnIn.Enabled = False
            Else
                If grdListPO.Rows.Count > 0 Then
                    btnThoat.Enabled = True
                    btnThem.Enabled = True
                    btnSua.Enabled = True
                    btnXoa.Enabled = True
                    btnIn.Enabled = True
                    btnGhi.Enabled = False
                    btnKhongGhi.Enabled = False
                    btnChonVTPT.Enabled = False
                    btnTaoMa.Enabled = False
                Else
                    btnThem.Enabled = True
                    btnThoat.Enabled = True
                    btnGhi.Enabled = False
                    btnKhongGhi.Enabled = False
                    btnSua.Enabled = False
                    btnXoa.Enabled = False
                    btnIn.Enabled = False
                    btnChonVTPT.Enabled = False
                    btnTaoMa.Enabled = False
                End If
            End If
        Else
            If grdListPO.Rows.Count > 0 Then
                btnThem.Enabled = False
                btnThoat.Enabled = True
                btnGhi.Enabled = False
                btnKhongGhi.Enabled = False
                btnSua.Enabled = False
                btnXoa.Enabled = False
                btnIn.Enabled = True
                btnChonVTPT.Enabled = False
                btnTaoMa.Enabled = False

            Else
                btnThem.Enabled = False
                btnThoat.Enabled = True
                btnGhi.Enabled = False
                btnKhongGhi.Enabled = False
                btnSua.Enabled = False
                btnXoa.Enabled = False
                btnIn.Enabled = False
                btnChonVTPT.Enabled = False
                btnTaoMa.Enabled = False

            End If
        End If
    End Sub
    'Điều khiển nhập liệu
    Sub lockInput(ByVal flag As Boolean)
        cboKhachHang.Enabled = Not flag
        cboNguoiLH.Enabled = Not flag
        cboPOThang.Enabled = flag

        txtGhiChu.ReadOnly = flag
        txtMsDDH.ReadOnly = flag
        txtNguoiLH.ReadOnly = flag
        mtxtNgayGiao.ReadOnly = flag
        mTxtNgayLap.ReadOnly = flag

        txtDiachi.ReadOnly = flag
        txtDienThoai.ReadOnly = flag
        txtFax.ReadOnly = flag
        txtVAT.ReadOnly = flag


    End Sub
    'Định dạng Gridview danh sách PO
    Sub formatgrdListPO()
        Dim cl1 As New DataGridViewTextBoxColumn()
        cl1.Name = "MS_DDH"
        cl1.DataPropertyName = "MS_DDH"
        cl1.Width = 150
        cl1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_DDH", commons.Modules.TypeLanguage)
        grdListPO.Columns.Insert(0, cl1)

        Dim cl2 As New DataGridViewTextBoxColumn()
        cl2.Name = "NGAY_LAP"
        cl2.DataPropertyName = "NGAY_LAP"
        cl2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_LAP", commons.Modules.TypeLanguage)
        cl2.Width = 120
        grdListPO.Columns.Insert(1, cl2)

        Dim cl3 As New DataGridViewTextBoxColumn()
        cl3.Name = "TEN_CONG_TY"
        cl3.DataPropertyName = "TEN_CONG_TY"
        cl3.MinimumWidth = 150
        cl3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        cl3.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_CONG_TY", commons.Modules.TypeLanguage)
        grdListPO.Columns.Insert(2, cl3)

        Dim cl4 As New DataGridViewTextBoxColumn()
        cl4.Name = "NGAY_GIAO"
        cl4.DataPropertyName = "NGAY_GIAO"
        cl4.Width = 120
        cl4.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_GIAO", commons.Modules.TypeLanguage)
        grdListPO.Columns.Insert(3, cl4)
        grdListPO.AllowUserToAddRows = False

        grdListPO.AutoGenerateColumns = False

    End Sub
    'Định dạng GridView chi tiet PO
    Sub formatgrdPODetail()
        Dim cl1 As New DataGridViewTextBoxColumn()
        cl1.Name = "MS_PT"
        cl1.DataPropertyName = "MS_PT"
        cl1.Width = 150
        cl1.ReadOnly = True
        cl1.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(0, cl1)

        Dim cl2 As New DataGridViewTextBoxColumn()
        cl2.Name = "TEN_PT"
        cl2.DataPropertyName = "TEN_PT"
        cl2.Width = 150
        cl2.ReadOnly = True
        cl2.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(1, cl2)

        Dim cl3 As New DataGridViewTextBoxColumn()
        cl3.Name = "SO_LUONG"
        cl3.DataPropertyName = "SO_LUONG"
        cl3.Width = 150
        cl3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cl3.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_LUONG", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(2, cl3)

        Dim cl4 As New DataGridViewTextBoxColumn()
        cl4.Name = "DVT"
        cl4.DataPropertyName = "DVT"
        cl4.Width = 150
        cl4.ReadOnly = True
        cl4.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DVT", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(3, cl4)

        Dim cl5 As New DataGridViewTextBoxColumn()
        cl5.Name = "DON_GIA"
        cl5.DataPropertyName = "DON_GIA"
        cl5.Width = 150
        cl5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cl5.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DON_GIA", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(4, cl5)

        Dim cl6 As New DataGridViewComboBoxColumn()
        cl6.Name = "NGOAI_TE"
        cl6.DisplayMember = "NGOAI_TE"
        cl6.ValueMember = "NGOAI_TE"
        Dim vtbData As New System.Data.DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM NGOAI_TE"))
        cl6.DataSource = vtbData
        cl6.DataPropertyName = "NGOAI_TE"
        cl6.Width = 150
        cl6.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGOAI_TE", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(5, cl6)

        Dim cl7 As New DataGridViewTextBoxColumn()
        cl7.Name = "TI_GIA"
        cl7.DataPropertyName = "TI_GIA"
        cl7.Width = 150
        cl7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cl7.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TI_GIA", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(6, cl7)

        Dim cl8 As New DataGridViewTextBoxColumn()
        cl8.Name = "THANH_TIEN_NT"
        cl8.DataPropertyName = "THANH_TIEN_NT"
        cl8.Width = 150
        cl8.ReadOnly = True
        cl8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cl8.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANH_TIEN_NT", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(7, cl8)

        Dim cl9 As New DataGridViewTextBoxColumn()
        cl9.Name = "THANH_TIEN"
        cl9.DataPropertyName = "THANH_TIEN"
        cl9.Width = 150
        cl9.ReadOnly = True
        cl9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cl9.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANH_TIEN", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(8, cl9)

        Dim cl10 As New DataGridViewTextBoxColumn()
        cl10.Name = "GHI_CHU"
        cl10.DataPropertyName = "GHI_CHU"
        cl10.Width = 150
        'cl10.Visible = False
        cl10.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GHI_CHU", commons.Modules.TypeLanguage)
        grdPODetail.Columns.Insert(9, cl10)

        grdPODetail.AllowUserToAddRows = False

    End Sub
    'Load các tháng có đơn đặt hàng
    Sub loadThangPO()
        Try
            Dim vtb As New DataTable()
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_THANG_DON_DAT_HANG_CS"))
            cboPOThang.DataSource = vtb
            cboPOThang.ValueMember = "NAM"
            cboPOThang.DisplayMember = "THANG"
            cboPOThang.SelectedIndex = 0
            If vtb.Rows.Count > 0 Then
                Dim vThangText As String = "0" + cboPOThang.Text.Trim()
                vThangText = vThangText.Substring(vThangText.Length - 7, 7)
                vThangText = "01/" + vThangText
                vThang = DateTime.ParseExact(vThangText, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            Else
                vThang = DateTime.Now.Date
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Load Danh Sach khách hàng
    Sub loadKhachHang()
        Dim vtb As DataTable = New DataTable()
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_getKhachHang_CS"))
        cboKhachHang.HValueMember = "MS_KH"
        cboKhachHang.HDisLayMember = "TEN_CONG_TY"
        cboKhachHang.HColumnNames = "MS_KH,TEN_CONG_TY"
        cboKhachHang.HBindData(vtb)

    End Sub
    Sub loadCongNhan()

        Dim vtb As DataTable = New DataTable()
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetCongNhan_CS"))

        cboNguoiLH.HValueMember = "MS_CONG_NHAN"
        cboNguoiLH.HDisLayMember = "TEN_CONG_NHAN"
        cboNguoiLH.HBindData(vtb)

    End Sub

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click

        RemoveHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
        ' vMS_DDH = ""
        txtMsDDH.Text = ""
        grdquyen.SelectedIndex = 1
        vEvent = "A"
        Try
            vIndex = grdListPO.CurrentRow.Index
        Catch ex As Exception
            vIndex = -1
        End Try

        vListPO.Columns("MS_DDH").AllowDBNull = True
        vListPO.Columns("TEN_CONG_TY").AllowDBNull = True
        Try
            vListPO.Rows.Add()
        Catch ex As Exception
        End Try
        'grdListPO.CurrentCell = grdListPO.Rows(grdListPO.Rows.Count - 1).Cells(0)
        For i As Integer = 0 To grdListPO.Rows.Count
            If (grdListPO.Rows(i).Cells("MS_DDH").Value.Equals(DBNull.Value)) Then
                grdListPO.CurrentCell = grdListPO.Rows(i).Cells(0)
                Exit For
            End If
        Next
        'vListPO.AcceptChanges()
        lockControl()
        lockControlDetail()
        lockInput(False)
        txtVAT.Text = 0
        loadChiTietPO(txtMsDDH.Text.Trim)
        mTxtNgayLap.Text = DateTime.Now.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        'grdPODetail.DataSource = Nothing
        'formatgrdPODetail()
        AddHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        'Me.Validate(True)

        'vEvent = "G"
        If txtMsDDH.Text.Trim.ToString = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_DDH_KO_TRONG", commons.Modules.TypeLanguage))
            txtMsDDH.Focus()
            Exit Sub
        End If
        If mTxtNgayLap.Text.Trim.ToString = "/  /" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_LAP_KO_TRONG", commons.Modules.TypeLanguage))
            mTxtNgayLap.Focus()
            Exit Sub
        End If

        If cboKhachHang.Text.Trim.ToString = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "KHACH_HANG_KO_TRONG", commons.Modules.TypeLanguage))
            cboKhachHang.Focus()
            Exit Sub
        End If

        If cboNguoiLH.Text.Trim.ToString = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGUOI_LAP_KO_TRONG", commons.Modules.TypeLanguage))
            cboNguoiLH.Focus()
            Exit Sub
        End If

        Dim vNgayLap As New System.DateTime()
        Try
            vNgayLap = System.DateTime.ParseExact(mTxtNgayLap.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_LAP_KO_DUNG_DD", commons.Modules.TypeLanguage))
            mTxtNgayLap.Focus()
            Exit Sub
        End Try
        Dim vNgaygiao As New DateTime

        Try
            If mtxtNgayGiao.Text.Trim <> "/  /" Then
                vNgaygiao = System.DateTime.ParseExact(mtxtNgayGiao.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_GIAO_KO_DUNG_DD", commons.Modules.TypeLanguage))
            mtxtNgayGiao.Focus()
            Exit Sub
        End Try

        If grdPODetail.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_CO_VT_PT", commons.Modules.TypeLanguage))
            Exit Sub
        End If

        If txtVAT.Text.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_VAT", commons.Modules.TypeLanguage))
            Exit Sub
        End If

        For i As Integer = 0 To grdPODetail.Rows.Count - 1
            If grdPODetail.Rows(i).Cells("SO_LUONG").Value = Nothing Or grdPODetail.Rows(i).Cells("SO_LUONG").Value = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_SO_LUONG", commons.Modules.TypeLanguage))
                grdPODetail.Rows(i).Cells("SO_LUONG").Selected() = True
                Exit Sub
            End If
        Next
        Try
            Dim vAT As Integer = 0
            vAT = Integer.Parse(txtVAT.Text.Trim())

            If vEvent = "A" Then
                Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
                objConnection.Open()
                Dim objTrans As SqlTransaction = objConnection.BeginTransaction
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_InsertDonDatHang_CS", txtMsDDH.Text, vNgayLap, cboNguoiLH.SelectedValue, cboKhachHang.SelectedValue, _
                    IIf(txtNguoiLH.Text.ToString.Trim = "", DBNull.Value, txtNguoiLH.Text.Trim), IIf(mtxtNgayGiao.Text.Trim = "/  /", DBNull.Value, vNgaygiao), _
                    IIf(txtGhiChu.Text.Trim = "", DBNull.Value, txtGhiChu.Text), vAT, IIf(txtDiachi.Text.Trim = "", DBNull.Value, txtDiachi.Text), IIf(txtDienThoai.Text.Trim = "", DBNull.Value, txtDienThoai.Text), IIf(txtFax.Text.Trim = "", DBNull.Value, txtFax.Text))

                    For i As Integer = 0 To grdPODetail.Rows.Count - 1
                        Dim VNT As String = grdPODetail.Rows(i).Cells("NGOAI_TE").Value.ToString
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_insert_DON_DAT_HANG_CHI_TIET_CS", _
                        txtMsDDH.Text, grdPODetail.Rows(i).Cells("MS_PT").Value, grdPODetail.Rows(i).Cells("SO_LUONG").Value, grdPODetail.Rows(i).Cells("DON_GIA").Value, _
                        grdPODetail.Rows(i).Cells("NGOAI_TE").Value, grdPODetail.Rows(i).Cells("TI_GIA").Value, grdPODetail.Rows(i).Cells("GHI_CHU").Value)
                    Next


                    vListPO.AcceptChanges()
                    CType(grdListPO.DataSource, DataTable).AcceptChanges()
                    objTrans.Commit()
                    'RemoveHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged

                    'loadData()
                    'BindData()
                Catch ex As Exception
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CHUA_UPDATE_THANH_CONG", commons.Modules.TypeLanguage))
                    objTrans.Rollback()
                    Exit Sub
                End Try

            ElseIf vEvent = "E" Then
                Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
                objConnection.Open()
                Dim objTrans As SqlTransaction = objConnection.BeginTransaction
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_UpdateDonDatHang_CS", txtMsDDH.Text, vNgayLap, cboNguoiLH.SelectedValue, cboKhachHang.SelectedValue, _
                       IIf(txtNguoiLH.Text.ToString.Trim = "", DBNull.Value, txtNguoiLH.Text.Trim), IIf(mtxtNgayGiao.Text.Trim = "/  /", DBNull.Value, vNgaygiao), _
                       IIf(txtGhiChu.Text.Trim = "", DBNull.Value, txtGhiChu.Text), vAT, IIf(txtDiachi.Text.Trim = "", DBNull.Value, txtDiachi.Text), IIf(txtDienThoai.Text.Trim = "", DBNull.Value, txtDienThoai.Text), IIf(txtFax.Text.Trim = "", DBNull.Value, txtFax.Text))

                    SqlHelper.ExecuteNonQuery(objTrans, "H_Delete_CHI_TIET_DON_DAT_HANGs_CS", txtMsDDH.Text.Trim)
                    objTrans.Commit()

                    For i As Integer = 0 To grdPODetail.Rows.Count - 1
                        Dim VNT As String = grdPODetail.Rows(i).Cells("NGOAI_TE").Value.ToString
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_insert_DON_DAT_HANG_CHI_TIET_CS", _
                        txtMsDDH.Text, grdPODetail.Rows(i).Cells("MS_PT").Value, grdPODetail.Rows(i).Cells("SO_LUONG").Value, grdPODetail.Rows(i).Cells("DON_GIA").Value, _
                        grdPODetail.Rows(i).Cells("NGOAI_TE").Value, grdPODetail.Rows(i).Cells("TI_GIA").Value, grdPODetail.Rows(i).Cells("GHI_CHU").Value)
                    Next

                    vListPO.AcceptChanges()
                    'objTrans.Commit()

                Catch ex As Exception
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CHUA_UPDATE_THANH_CONG", commons.Modules.TypeLanguage))
                    objTrans.Rollback()
                End Try

            End If
            'grdListPO.DataSource = Nothing
            'grdListPO.DataSource = vListPO
            vEvent = "N"
            vMS_DDH = ""

            grdquyen.SelectedIndex = 0
            'loadThangPO()
            'loadData()
            'BindData()
            'vListPO.AcceptChanges()
            lockControl()
            lockControlDetail()
            lockInput(True)
            RemoveHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged

        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CHUA_UPDATE_THANH_CONG", commons.Modules.TypeLanguage))
        End Try

    End Sub

    Private Sub btnKhongGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        RemoveHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
        Try
            vEvent = "N"
            vMS_DDH = ""
            vListPO.RejectChanges()
            BindData()
            lockControl()
            lockControlDetail()
            lockInput(True)
            grdquyen.SelectedIndex = 0
            If (vIndex < grdListPO.Rows.Count) Then
                grdListPO.CurrentCell = grdListPO.Rows(vIndex).Cells(0)
            End If
            grdListPO.CurrentRow.Selected = True


        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        Try

            grdquyen.SelectedIndex = 1
            vEvent = "E"

            vMS_DDH = grdListPO.CurrentRow.Cells("MS_DDH").Value.ToString().Trim()
            vIndex = grdListPO.CurrentRow.Index
            grdListPO.CurrentCell = grdListPO.Rows(vIndex).Cells(0)
            lockControl()
            lockControlDetail()
            lockInput(False)

            txtMsDDH.ReadOnly = True
            btnTaoMa.Enabled = False
            AddHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
            'If ChecDDHTinhTrang(vMS_DDH) Then
            '    MessageBox.Show("Đơn đặt hàng đã được phê duyệt ! bạn không thể sửa ", "Thông báo", MessageBoxButtons.OK)
            'Try
            '    vEvent = "N"
            '    vListPO.RejectChanges()
            '    lockControl()
            '    If (vIndex < gv_List_DDH.Rows.Count) Then
            '        gv_List_DDH.CurrentCell = gv_List_DDH.Rows(vIndex).Cells(0)
            '    End If
            '    gv_List_DDH.CurrentRow.Selected = True
            'Catch ex As Exception
            'End Try
            'End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CO_CHAC_MUON_XOA_KO", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            grdquyen.SelectedIndex = 0
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                SqlHelper.ExecuteNonQuery(objTrans, "H_Delete_CHI_TIET_DON_DAT_HANGs_CS", txtMsDDH.Text.Trim)
                SqlHelper.ExecuteNonQuery(objTrans, "H_Delete_DON_DAT_HANGs_CS", txtMsDDH.Text.Trim)

                For Each vRow As DataRow In vListPO.Rows
                    If (vRow("MS_DDH").ToString().Trim().Equals(grdListPO.CurrentRow.Cells("MS_DDH").Value.ToString().Trim())) Then
                        vListPO.Rows.Remove(vRow)
                        Exit For
                    End If
                Next
                vListPO.AcceptChanges()
                lockControl()
                objTrans.Commit()
            Catch ex As Exception
                objTrans.Rollback()
            End Try


        End If
    End Sub
    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click

        If grdListPO.Rows.Count = 0 Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
        With ExcelSheets
            .Columns(1).ColumnWidth = 3
            .Columns(2).ColumnWidth = 20
            .Columns(3).ColumnWidth = 15
            .Columns(4).ColumnWidth = 8
            .Columns(5).ColumnWidth = 8
            .Columns(6).ColumnWidth = 8
            .Columns(7).ColumnWidth = 8
            .Columns(8).ColumnWidth = 8
            .Columns(9).ColumnWidth = 8
            .Columns(10).ColumnWidth = 8
            .Columns(11).ColumnWidth = 8
        End With

        Dim TenCty As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "TenCty", commons.Modules.TypeLanguage)
        Dim rgTenCty As Excel.Range
        rgTenCty = ExcelSheets.Range("A1", "D1")
        rgTenCty.Merge(True)
        rgTenCty.MergeCells() = True
        rgTenCty.Font.Bold = True
        rgTenCty.Value = TenCty
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "BoPhan", commons.Modules.TypeLanguage)
        Dim rgBoPhan As Excel.Range
        rgBoPhan = ExcelSheets.Range("A2", "D2")
        rgBoPhan.Merge(True)
        rgBoPhan.MergeCells() = True
        rgBoPhan.Font.Bold = True
        rgBoPhan.Value = BoPhan

        Dim vtbTTC As New DataTable()
        vtbTTC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM THONG_TIN_CHUNG"))

        With ExcelSheets

            .Range("A4", "B4").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A4", "B4").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Range("A4", "B4").Merge(True)
            .Range("A4", "B4").MergeCells = True
            .Range("A4", "B4").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "TEL", commons.Modules.TypeLanguage) + ":" + vtbTTC.Rows(0)("Phone").ToString

            .Range("A5", "B5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A5", "B5").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Range("A5", "B5").Merge(True)
            .Range("A5", "B5").MergeCells = True
            .Range("A5", "B5").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "FAX", commons.Modules.TypeLanguage) + ":" + vtbTTC.Rows(0)("Fax").ToString

            .Range("A6", "B6").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A6", "B6").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Range("A6", "B6").Merge(True)
            .Range("A6", "B6").MergeCells = True
            .Range("A6", "B6").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "EMAIL", commons.Modules.TypeLanguage) + ":" + vtbTTC.Rows(0)("EMAIL").ToString


        End With


        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 400, 1, 60, 15)
            .Name = "k11"
            .TextFrame.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "DUYET5", commons.Modules.TypeLanguage)
            .TextFrame.Characters.Font.Size = 8
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 400, 15, 60, 50)
            .Name = "k21"
        End With

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 340, 1, 60, 15)
            .Name = "k12"
            .TextFrame.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "DUYET4", commons.Modules.TypeLanguage)
            .TextFrame.Characters.Font.Size = 8
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 340, 15, 60, 50)
            .Name = "k22"
        End With

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 280, 1, 60, 15)
            .Name = "K13"
            .TextFrame.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "DUYET3", commons.Modules.TypeLanguage)
            .TextFrame.Characters.Font.Size = 8
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 280, 15, 60, 50)
            .Name = "k23"
        End With

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 220, 1, 60, 15)
            .Name = "K31"
            .TextFrame.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "DUYET2", commons.Modules.TypeLanguage)
            .TextFrame.Characters.Font.Size = 8
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 220, 15, 60, 50)
            .Name = "k41"
        End With

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 160, 1, 60, 15)
            .Name = "K51"
            .TextFrame.Characters.Text = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "DUYET1", commons.Modules.TypeLanguage)
            .TextFrame.Characters.Font.Size = 8
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 160, 15, 60, 50)
            .Name = "k52"
        End With

        Dim ASGroup As Object() = New Object() {"k11", "k12", "k13", "k21", "k22", "k23", "k31", "k41", "k51", "k52"}
        ExcelSheets.Shapes.Range(ASGroup).Group()

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "TieuDe", commons.Modules.TypeLanguage)
        Dim rgTieuDe As Excel.Range
        rgTieuDe = ExcelSheets.Range("A8", "L9")
        rgTieuDe.Merge(True)
        rgTieuDe.MergeCells() = True
        rgTieuDe.Font.Bold = True
        rgTieuDe.Font.Size = 16
        rgTieuDe.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgTieuDe.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rgTieuDe.Value = TieuDe


        Dim vTo As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "TO", commons.Modules.TypeLanguage)
        Dim rgMaSo As Excel.Range
        rgMaSo = ExcelSheets.Range("A11", "E11")
        rgMaSo.Merge(True)
        rgMaSo.MergeCells() = True
        rgMaSo.Font.Bold = True
        rgMaSo.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgMaSo.Value = vTo + " : " + cboKhachHang.Text

        Dim ATTN As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "ATTN", commons.Modules.TypeLanguage)
        Dim rgATTN As Excel.Range
        rgATTN = ExcelSheets.Range("A12", "E12")
        rgATTN.Merge(True)
        rgATTN.MergeCells() = True
        rgATTN.Font.Bold = True
        rgATTN.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgATTN.Value = ATTN + " : " + txtNguoiLH.Text

        Dim FROM As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "FROM", commons.Modules.TypeLanguage)
        Dim rgFROM As Excel.Range
        rgFROM = ExcelSheets.Range("A13", "E13")
        rgFROM.Merge(True)
        rgFROM.MergeCells() = True
        rgFROM.Font.Bold = True
        rgFROM.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFROM.Value = FROM + " : " + cboNguoiLH.Text


        Dim Ms_DDH As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "NO", commons.Modules.TypeLanguage)
        Dim rgMs_DDH As Excel.Range
        rgMs_DDH = ExcelSheets.Range("F11", "L11")
        rgMs_DDH.Merge(True)
        rgMs_DDH.MergeCells() = True
        rgMs_DDH.Font.Bold = True
        rgMs_DDH.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgMs_DDH.Value = Ms_DDH + " : " + txtMsDDH.Text


        Dim Ms_DATE As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "DATE", commons.Modules.TypeLanguage)
        Dim rgMs_DATE As Excel.Range
        rgMs_DATE = ExcelSheets.Range("F12", "L12")
        rgMs_DATE.Merge(True)
        rgMs_DATE.MergeCells() = True
        rgMs_DATE.Font.Bold = True
        rgMs_DATE.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgMs_DATE.Value = Ms_DATE + " : " + mtxtNgayGiao.Text


        Dim RAT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "RAT", commons.Modules.TypeLanguage)
        Dim rgRAT As Excel.Range
        rgRAT = ExcelSheets.Range("F13", "L13")
        rgRAT.Merge(True)
        rgRAT.MergeCells() = True
        rgRAT.Font.Bold = True
        rgRAT.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgRAT.Value = RAT + " : " + txtMsDDH.Text

        'Dim GHI As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDonDatHang", "RAT", commons.Modules.TypeLanguage)
        Dim ghichu As Excel.Range
        ghichu = ExcelSheets.Range("A15", "L15")
        ghichu.Merge(True)
        ghichu.MergeCells() = True
        ghichu.Font.Bold = True
        ghichu.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        ghichu.Value = txtGhiChu.Text



        ' Tieu de columns
        Dim stt As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "NO", commons.Modules.TypeLanguage)
        Dim material As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "MATERIAL_NAME", commons.Modules.TypeLanguage)
        Dim spec As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "DECSCIPTION", commons.Modules.TypeLanguage)
        Dim unit As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "UNIT", commons.Modules.TypeLanguage)
        'Dim Min As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDonDatHang", "MIN", commons.Modules.TypeLanguage)
        'Dim Max As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDonDatHang", "MAX", commons.Modules.TypeLanguage)
        'Dim inventory As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDonDatHang", "INVENTORY", commons.Modules.TypeLanguage)
        Dim quantity As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "QUANTITY", commons.Modules.TypeLanguage)
        Dim unitprice As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "PRICE", commons.Modules.TypeLanguage)
        Dim amount As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "AMOUNT", commons.Modules.TypeLanguage)
        Dim remark As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "REMARK", commons.Modules.TypeLanguage)

        With ExcelSheets
            .Range("A18", "A18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A18", "A18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("A18", "A18").Font.Bold = True
            .Range("A18", "A18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A18", "A18").Value = stt

            .Range("B18", "B18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("B18", "B18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("B18", "B18").Font.Bold = True
            .Range("B18", "B18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("B18", "B18").Value = material

            .Range("C18", "C18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("C18", "C18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("C18", "C18").Font.Bold = True
            .Range("C18", "C18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("C18", "C18").Value = spec

            .Range("D18", "D18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("D18", "D18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("D18", "D18").Font.Bold = True
            .Range("D18", "D18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("D18", "D18").Value = unit

            .Range("E18", "E18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E18", "E18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("E18", "E18").Font.Bold = True
            .Range("E18", "E18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E18", "E18").Value = quantity

            .Range("F18", "F18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("F18", "F18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("F18", "F18").Font.Bold = True
            .Range("F18", "F18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F18", "F18").Value = unitprice

            .Range("G18", "G18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G18", "G18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("G18", "G18").Font.Bold = True
            .Range("G18", "G18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G18", "G18").Value = amount

            .Range("H18", "H18").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("H18", "H18").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("H18", "H18").Font.Bold = True
            .Range("H18", "H18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H18", "H18").Value = remark

        End With

        Dim vtbData As New System.Data.DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DON_DAT_HANG_CHI_TIET_RPT_CS", txtMsDDH.Text))

        Dim row As Integer = 19
        For i As Integer = 0 To vtbData.Rows.Count - 1
            With ExcelSheets
                .Range("A" & row + i, "A" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("A" & row + i, "A" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A" & row + i, "A" & row + i).Font.Bold = False
                .Range("A" & row + i, "A" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A" & row + i, "A" & row + i).Value = i + 1

                .Range("B" & row + i, "B" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("B" & row + i, "B" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("B" & row + i, "B" & row + i).Font.Bold = False
                .Range("B" & row + i, "B" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("B" & row + i, "B" & row + i).Value = vtbData.Rows(i)("TEN_PT")

                .Range("C" & row + i, "C" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("C" & row + i, "C" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("C" & row + i, "C" & row + i).Font.Bold = False
                .Range("C" & row + i, "C" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("C" & row + i, "C" & row + i).Value = vtbData.Rows(i)("QUY_CACH")

                .Range("D" & row + i, "D" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("D" & row + i, "D" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("D" & row + i, "D" & row + i).Font.Bold = False
                .Range("D" & row + i, "D" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("D" & row + i, "D" & row + i).Value = vtbData.Rows(i)("DVT")

                .Range("E" & row + i, "E" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("E" & row + i, "E" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range("E" & row + i, "E" & row + i).Font.Bold = False
                .Range("E" & row + i, "E" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("E" & row + i, "E" & row + i).Value = vtbData.Rows(i)("SO_LUONG")

                .Range("F" & row + i, "F" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("F" & row + i, "F" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("F" & row + i, "F" & row + i).Font.Bold = False
                .Range("F" & row + i, "F" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("F" & row + i, "F" & row + i).Value = vtbData.Rows(i)("DON_GIA")

                .Range("G" & row + i, "G" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("G" & row + i, "G" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range("G" & row + i, "G" & row + i).Font.Bold = False
                .Range("G" & row + i, "G" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G" & row + i, "G" & row + i).Value = vtbData.Rows(i)("THANH_TIEN_NT")

                .Range("H" & row + i, "H" & row + i).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Range("H" & row + i, "H" & row + i).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                .Range("H" & row + i, "H" & row + i).Font.Bold = False
                .Range("H" & row + i, "H" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("H" & row + i, "H" & row + i).Value = ""

            End With
        Next

        row = row + vtbData.Rows.Count

        With ExcelSheets

            .Range("A" & row, "E" & row).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A" & row, "E" & row).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("A" & row, "E" & row).Font.Bold = True
            .Range("A" & row, "E" & row).Merge(True)
            .Range("A" & row, "E" & row).MergeCells() = True
            .Range("A" & row, "E" & row).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A" & row, "E" & row).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "TOTAL", commons.Modules.TypeLanguage)


            .Range("F" & row, "F" & row).Font.Bold = False
            .Range("F" & row, "F" & row).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            .Range("G" & row, "G" & row).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & row, "G" & row).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("G" & row, "G" & row).Font.Bold = False
            .Range("G" & row, "G" & row).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & row, "G" & row).Value = "=Sum(G" & (row - vtbData.Rows.Count) & ":G" & (row - 1) & " )"

            .Range("H" & row, "H" & row).Font.Bold = False
            .Range("H" & row, "H" & row).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)



            .Range("A" & row + 1, "E" & row + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("A" & row + 1, "E" & row + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("A" & row + 1, "E" & row + 1).Font.Bold = True
            .Range("A" & row + 1, "E" & row + 1).Merge(True)
            .Range("A" & row + 1, "E" & row + 1).MergeCells() = True
            .Range("A" & row + 1, "E" & row + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A" & row + 1, "E" & row + 1).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "VAT", commons.Modules.TypeLanguage)


            .Range("F" & row + 1, "F" & row + 1).Font.Bold = False
            .Range("F" & row + 1, "F" & row + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            .Range("G" & row + 1, "G" & row + 1).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & row + 1, "G" & row + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("G" & row + 1, "G" & row + 1).Font.Bold = False
            .Range("G" & row + 1, "G" & row + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            .Range("G" & row + 1, "G" & row + 1).Value = "=G" & (row - 1) & "/100 * " & txtVAT.Text.Trim

            .Range("H" & row + 1, "H" & row + 1).Font.Bold = False
            .Range("H" & row + 1, "H" & row + 1).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            row = row + 2
            .Range("E" & row, "E" & row).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("E" & row, "E" & row).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("E" & row, "E" & row).Font.Bold = True
            '.Range("E" & row, "E" & row).Merge(True)
            '.Range("E" & row, "E" & row).MergeCells() = True
            .Range("E" & row, "E" & row).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E" & row, "E" & row).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "TOTAL", commons.Modules.TypeLanguage)


            .Range("F" & row, "F" & row).Font.Bold = False
            .Range("F" & row, "F" & row).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            .Range("G" & row, "G" & row).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range("G" & row, "G" & row).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .Range("G" & row, "G" & row).Font.Bold = False
            .Range("G" & row, "G" & row).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & row, "G" & row).Value = "=G" & (row - 1) & " + G" & (row - 2)

        End With

        row = row + 1

        Dim vFoot1 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot1", commons.Modules.TypeLanguage)
        Dim rgvFoot1 As Excel.Range
        rgvFoot1 = ExcelSheets.Range("A" & row, "H" & row + 1)
        rgvFoot1.Merge(True)
        rgvFoot1.MergeCells() = True
        rgvFoot1.Font.Bold = True
        rgvFoot1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgvFoot1.Value = vFoot1

        row = row + 2

        Dim vFoot21 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot21", commons.Modules.TypeLanguage)
        Dim rgFoot21 As Excel.Range
        rgFoot21 = ExcelSheets.Range("A" & row, "B" & row)
        rgFoot21.Merge(True)
        rgFoot21.MergeCells() = True
        rgFoot21.Font.Bold = True
        rgFoot21.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        rgFoot21.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot21.Value = vFoot21

        Dim vFoot22 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot22", commons.Modules.TypeLanguage)
        Dim rgFoot22 As Excel.Range
        rgFoot22 = ExcelSheets.Range("C" & row, "H" & row)
        rgFoot22.Merge(True)
        rgFoot22.MergeCells() = True
        rgFoot22.Font.Bold = True
        rgFoot22.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot22.Value = vFoot22

        row = row + 1

        Dim vFoot31 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot31", commons.Modules.TypeLanguage)
        Dim rgFoot31 As Excel.Range
        rgFoot31 = ExcelSheets.Range("A" & row, "B" & row)
        rgFoot31.Merge(True)
        rgFoot31.MergeCells() = True
        rgFoot31.Font.Bold = True
        rgFoot31.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot31.Value = vFoot31

        Dim vFoot32 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot32", commons.Modules.TypeLanguage)
        Dim rgFoot32 As Excel.Range
        rgFoot32 = ExcelSheets.Range("C" & row, "H" & row)
        rgFoot32.Merge(True)
        rgFoot32.MergeCells() = True
        rgFoot32.Font.Bold = True
        rgFoot32.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot32.Value = vFoot32

        row = row + 1

        Dim vFoot41 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot41", commons.Modules.TypeLanguage)
        Dim rgFoot41 As Excel.Range
        rgFoot41 = ExcelSheets.Range("A" & row, "B" & row)
        rgFoot41.Merge(True)
        rgFoot41.MergeCells() = True
        rgFoot41.Font.Bold = True
        rgFoot41.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot41.Value = vFoot41

        Dim vFoot42 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot42", commons.Modules.TypeLanguage)
        Dim rgFoot42 As Excel.Range
        rgFoot42 = ExcelSheets.Range("C" & row, "H" & row)
        rgFoot42.Merge(True)
        rgFoot42.MergeCells() = True
        rgFoot42.Font.Bold = True
        rgFoot42.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot42.Value = vFoot42


        row = row + 1

        Dim vFoot51 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot51", commons.Modules.TypeLanguage)
        Dim rgFoot51 As Excel.Range
        rgFoot51 = ExcelSheets.Range("A" & row, "B" & row)
        rgFoot51.Merge(True)
        rgFoot51.MergeCells() = True
        rgFoot51.Font.Bold = True
        rgFoot51.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot51.Value = vFoot51

        Dim vFoot52 As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "vFoot52", commons.Modules.TypeLanguage)
        Dim rgFoot52 As Excel.Range
        rgFoot52 = ExcelSheets.Range("C" & row, "H" & row)
        rgFoot52.Merge(True)
        rgFoot52.MergeCells() = True
        rgFoot52.Font.Bold = True
        rgFoot52.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        rgFoot52.Value = vFoot52

        row = row + 2
        Dim Thanks As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDonDatHang_CS", "Thanks", commons.Modules.TypeLanguage)
        Dim rgThanks As Excel.Range
        rgThanks = ExcelSheets.Range("C" & row, "H" & row)
        rgThanks.Merge(True)
        rgThanks.MergeCells() = True
        rgThanks.Font.Bold = True
        rgThanks.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        rgThanks.Value = Thanks

        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub
    'Thoat khoi form
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnChonVTPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonVTPT.Click

        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DON_DAT_HANG_VTPT_CHON_TMP", Commons.Modules.UserName)
        Catch ex As Exception
        End Try

        For Each vrg As DataGridViewRow In grdPODetail.Rows
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DON_DAT_HANG_INSERT_VTPT_CHON_TMP", vrg.Cells("MS_PT").Value, _
                vrg.Cells("TEN_PT").Value, IIf(IsDBNull(vrg.Cells("SO_LUONG").Value), 0, vrg.Cells("SO_LUONG").Value), vrg.Cells("DVT").Value, IIf(IsDBNull(vrg.Cells("DON_GIA").Value), 0, vrg.Cells("DON_GIA").Value), IIf(IsDBNull(vrg.Cells("NGOAI_TE").Value), 0, vrg.Cells("NGOAI_TE").Value), _
                IIf(IsDBNull(vrg.Cells("TI_GIA").Value), 0, vrg.Cells("TI_GIA").Value), IIf(IsDBNull(vrg.Cells("THANH_TIEN_NT").Value), 0, vrg.Cells("THANH_TIEN_NT").Value), IIf(IsDBNull(vrg.Cells("THANH_TIEN").Value), 0, vrg.Cells("THANH_TIEN").Value), vrg.Cells("GHI_CHU").Value, txtMsDDH.Text.Trim, Commons.Modules.UserName)
            Catch ex As Exception
            End Try
        Next

        Try

        Catch ex As Exception

        End Try


        Dim frmChon As frmChonVTPTCS = New frmChonVTPTCS()


        frmChon.VDonDH = txtMsDDH.Text.Trim

        frmChon.ShowDialog()

        If frmChon.vEventChon = "OK" Then
            grdPODetail.DataSource = Nothing
            Dim vtb As New DataTable
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM dbo.CHON_VTPT_DON_DAT_HANG_CS_TMP" & Commons.Modules.UserName))

            'formatgrdPODetail()
            grdPODetail.AutoGenerateColumns = False
            grdPODetail.DataSource = vtb

        End If
    End Sub
    'Tao ma tu dong
    Private Sub btnTaoMa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaoMa.Click
        'clsConnect.Connectstring = Commons.IConnections.ConnectionString
        'txtMsDDH.Text = Commons.clsTaoMa.RandomId("DonDatHangTMP", "DON_DAT_HANG", "MS_DDH", txtMsDDH.Text.Trim & DateTime.Now.ToString("yy") & DateTime.Now.ToString("MM") & "-")
        'txtMsDDH.SelectAll()
        'txtMsDDH.Focus()

        If txtMsDDH.Text.Trim.Length > 3 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_NHO_HON_3_KT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        If txtMsDDH.Text.Trim.Length = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CHUA_NHAP_KI_HIEU_MA", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Vietsoft.Admin.Adminvs.ConnectionString = Commons.IConnections.ConnectionString
        Me.txtMsDDH.Text = Vietsoft.Admin.IDvs.CREATE_ID(txtMsDDH.Text.Trim.ToUpper)

    End Sub

    'Chuyen qua lai giua hai tab
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdquyen.SelectedIndexChanged
        'H_GET_DON_DAT_HANG_CHI_TIET_CS 
        Select Case grdquyen.SelectedTab.Name
            Case "tabPODetail"
                loadChiTietPO(txtMsDDH.Text)
                lockControl()
            Case "tabListPO"
                lockControl()
            Case "tabDuyet"
                LockPheDuyet()
        End Select
    End Sub
#Region "Phe Duyet"
    Sub LockPheDuyet()
        If rdbChuaDuyet.Checked = False Then

            btnDuyet.Visible = False
            btnCapNhat.Visible = False
            btnHuy.Visible = False

        Else
            btnDuyet.Visible = True
            btnCapNhat.Visible = False
            btnHuy.Visible = False
        End If

        chxDuyet1.Enabled = False
        chxDuyet2.Enabled = False
        chxDuyet3.Enabled = False
        chxDuyet4.Enabled = False

        txtYKien1.ReadOnly = True
        txtYKien2.ReadOnly = True
        txtYKien3.ReadOnly = True
        txtYKien4.ReadOnly = True

        btnThem.Enabled = False
        btnThoat.Enabled = True
        btnGhi.Enabled = False
        btnKhongGhi.Enabled = False
        btnSua.Enabled = False
        btnXoa.Enabled = False
        btnIn.Enabled = False
        btnChonVTPT.Enabled = False
        btnTaoMa.Enabled = False

    End Sub
#End Region


    Sub loadChiTietPO(ByVal vms_DDH As String)
        Dim vtbDetail As New DataTable()
        'MessageBox.Show(grdPODetail.Columns("THANH_TIEN").ReadOnly)
        vtbDetail.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DON_DAT_HANG_CHI_TIET_CS", vms_DDH))
        vtbDetail.Columns("THANH_TIEN").ReadOnly = False
        vtbDetail.Columns("THANH_TIEN_NT").ReadOnly = False
        grdPODetail.AutoGenerateColumns = False
        grdPODetail.DataSource = vtbDetail
        'grdPODetail.Columns("MS_DDH").Visible = False
        ' MessageBox.Show(grdPODetail.Columns("THANH_TIEN").ReadOnly)

    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles grdquyen.Selecting
        If vEvent = "A" Or vEvent = "E" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub grdPODetail_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdPODetail.CellValidating
        Try
            If Me.btnKhongGhi.Focused Then
                Exit Sub
            End If
            If btnGhi.Visible Then
                If e.RowIndex < grdPODetail.Rows.Count Then
                    Me.grdPODetail.Columns("SO_LUONG").DefaultCellStyle.Format = "#,###"
                    Me.grdPODetail.Columns("DON_GIA").DefaultCellStyle.Format = "#,##0.00"
                    Me.grdPODetail.Columns("TI_GIA").DefaultCellStyle.Format = "#,##0.00"
                    Me.grdPODetail.Columns("THANH_TIEN_NT").DefaultCellStyle.Format = "#,##0.00"
                    Me.grdPODetail.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,##0.00"

                    If grdPODetail.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
                        If e.FormattedValue <> "" Then
                            If e.FormattedValue <= 0 Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SL_LON_HON_KO", commons.Modules.TypeLanguage))
                                e.Cancel = True
                                Exit Sub
                            Else
                                Me.grdPODetail.Rows(e.RowIndex).Cells("THANH_TIEN_NT").Value = e.FormattedValue * Me.grdPODetail.Rows(e.RowIndex).Cells("DON_GIA").Value * GetTI_GIA_USD(Me.grdPODetail.Rows(e.RowIndex).Cells("NGOAI_TE").Value)
                                Me.grdPODetail.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdPODetail.Rows(e.RowIndex).Cells("DON_GIA").Value * Me.grdPODetail.Rows(e.RowIndex).Cells("TI_GIA").Value

                            End If
                        End If
                    ElseIf grdPODetail.Columns(e.ColumnIndex).Name = "DON_GIA" Then
                        If e.FormattedValue <> "" Then
                            If e.FormattedValue <= 0 Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DG_LON_HON_KO", commons.Modules.TypeLanguage))
                                Exit Sub
                            Else
                                Me.grdPODetail.Rows(e.RowIndex).Cells("THANH_TIEN_NT").Value = e.FormattedValue * Me.grdPODetail.Rows(e.RowIndex).Cells("SO_LUONG").Value * GetTI_GIA_USD(Me.grdPODetail.Rows(e.RowIndex).Cells("NGOAI_TE").Value)
                                Me.grdPODetail.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdPODetail.Rows(e.RowIndex).Cells("SO_LUONG").Value * Me.grdPODetail.Rows(e.RowIndex).Cells("TI_GIA").Value
                            End If
                        End If
                    ElseIf grdPODetail.Columns(e.ColumnIndex).Name = "NGOAI_TE" Then
                        Me.grdPODetail.Rows(e.RowIndex).Cells("TI_GIA").Value = GetTI_GIA(e.FormattedValue)

                        Me.grdPODetail.Rows(e.RowIndex).Cells("THANH_TIEN_NT").Value = Me.grdPODetail.Rows(e.RowIndex).Cells("SO_LUONG").Value * Me.grdPODetail.Rows(e.RowIndex).Cells("DON_GIA").Value * GetTI_GIA_USD(e.FormattedValue)
                        Me.grdPODetail.Rows(e.RowIndex).Cells("THANH_TIEN").Value = Me.grdPODetail.Rows(e.RowIndex).Cells("SO_LUONG").Value * Me.grdPODetail.Rows(e.RowIndex).Cells("DON_GIA").Value * GetTI_GIA(e.FormattedValue)

                    ElseIf grdPODetail.Columns(e.ColumnIndex).Name = "TI_GIA" Then
                        If e.FormattedValue.Equals("") = False Then
                            If e.FormattedValue = 0 Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTyGia", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                                e.Cancel = True
                                Exit Sub
                            Else
                                Me.grdPODetail.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdPODetail.Rows(e.RowIndex).Cells("DON_GIA").Value * Me.grdPODetail.Rows(e.RowIndex).Cells("SO_LUONG").Value
                            End If
                        Else
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheckTyGiaNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                            grdPODetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                            e.Cancel = True
                            Exit Sub
                            'Me.grdNganSach.Rows(e.RowIndex).Cells("THANH_TIEN").Value = 0
                        End If

                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetTI_GIA_USD(ByVal NGOAI_TE As String) As Double
        Dim TY_GIA_USD As Double
        Dim reader As SqlDataReader
        reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA_USD", NGOAI_TE)
        If reader.Read Then
            TY_GIA_USD = reader.Item("TI_GIA_USD")
        End If
        reader.Close()
        Return TY_GIA_USD
    End Function

    Public Function GetTI_GIA(ByVal NGOAI_TE As String) As Double
        Dim TY_GIA As Double
        Dim reader As SqlDataReader
        reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA", NGOAI_TE)
        If reader.Read Then
            TY_GIA = reader.Item("TI_GIA")
        End If
        reader.Close()
        Return TY_GIA
    End Function

    Private Sub grdPODetail_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdPODetail.DataError
        If TypeOf e.Exception Is FormatException Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.ThrowException = False
        End If
    End Sub

    Public Shared Function RandomId(ByVal tmpStoreProcedure As String, ByVal table As String, ByVal table_id As String, ByVal id As String) As String
        Dim num As Integer = 0
        Dim strCode As String = ""
        Dim sql As String = ""

        Dim connection As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        Dim cmdstore As New System.Data.SqlClient.SqlCommand()
        cmdstore.Connection = connection
        Try
            'If clsConnect.OpenConnect(connection) Then
            connection.Open()
            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            sql = (" select count(" & table_id & ") total from ") + table
            command.CommandText = sql
            Dim dataAdapter As New SqlDataAdapter()
            dataAdapter.SelectCommand = command
            dataAdapter.TableMappings.Add("Table", table)
            Dim dataSet As New DataSet()
            dataAdapter.Fill(dataSet)
            Dim myDataRow As DataRow = dataSet.Tables(table).Rows(0)
            Dim dataColumn As DataColumn = dataSet.Tables(table).Columns(0)
            num = CInt(myDataRow(dataColumn))
            'Create Check Primary Store Proc
            sql = (("create proc " & tmpStoreProcedure & "(@id varchar(16)," & "@Result int=1 Output) as " & "If not Exists(SELECT * FROM ") + table & " where ") + table_id & "=@id) " & "begin" & " SELECT @Result=0 " & " end " & " else " & " begin " & " SELECT @Result=1 " & " end " & " return "
            cmdstore.CommandText = sql
            cmdstore.ExecuteNonQuery()
            For i As Integer = 1 To num + 1
                If i < 10 Then
                    strCode = (id & "0") & i.ToString()
                Else
                    strCode = id & i.ToString()
                End If

                Dim cmd As New SqlCommand(tmpStoreProcedure, connection)
                cmd.CommandType = CommandType.StoredProcedure
                Dim param As SqlParameter = cmd.Parameters.AddWithValue("@id", strCode)
                param = cmd.Parameters.AddWithValue("@Result", 0)
                param.Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                Dim retVal As String = Convert.ToString(cmd.Parameters("@Result").Value)
                If retVal = "0" Then
                    Return (strCode)
                End If
            Next

        Finally
            sql = "drop proc " & tmpStoreProcedure
            cmdstore.CommandText = sql
            cmdstore.ExecuteNonQuery()
            connection.Close()

        End Try
        Return ""
    End Function

    Private Sub txtVAT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVAT.Validating
        If btnGhi.Visible = False Then
            Exit Sub
        End If
        Try
            Dim vat As Integer
            vat = Integer.Parse(txtVAT.Text.Trim)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "VAT_PHAI_LA_SO", commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub cboKhachHang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cboKhachHang.SelectedIndexChanged
        Dim vdv As DataRowView = CType(cboKhachHang.SelectedItem, DataRowView)
        txtDiachi.Text = vdv("DIA_CHI").ToString()
        txtDienThoai.Text = vdv("TEL").ToString()
        txtFax.Text = vdv("FAX").ToString()
        txtNguoiLH.Text = vdv("TEN_NDD").ToString()
        grdListPO.CurrentRow.Cells("TEN_CONG_TY").Value = vdv("TEN_CONG_TY").ToString()
    End Sub

    Private Sub rdbDaDuyet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles rdbDaDuyet.CheckedChanged
        RemoveHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
        loadData()
        BindData()
        vListPO.AcceptChanges()
        lockControl()
        'AddHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged

    End Sub

    Private Sub cboPOThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cboPOThang.SelectedIndexChanged

        RemoveHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
        Try
            Dim vThangText As String = "0" + cboPOThang.Text.Trim()
            vThangText = vThangText.Substring(vThangText.Length - 7, 7)
            vThangText = "01/" + vThangText
            vThang = DateTime.ParseExact(vThangText, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            loadData()
            BindData()
            vListPO.AcceptChanges()
            lockControl()
        Catch ex As Exception
        End Try

        'AddHandler cboKhachHang.SelectedIndexChanged, AddressOf cboKhachHang_SelectedIndexChanged
    End Sub

    Private Sub grdListPO_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdListPO.DataError
        e.ThrowException = True
    End Sub


    Private Sub btnDuyet_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuyet.Click

        chxDuyet1.Enabled = True
        chxDuyet2.Enabled = True
        chxDuyet3.Enabled = True
        chxDuyet4.Enabled = True


        txtYKien1.ReadOnly = False
        txtYKien2.ReadOnly = False
        txtYKien3.ReadOnly = False
        txtYKien4.ReadOnly = False


        btnDuyet.Visible = False
        btnCapNhat.Visible = True
        btnHuy.Visible = True

    End Sub

    Private Sub btnCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Click
        'H_UPDATE_DUYET_DON_DAT_HANG_CS
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_UPDATE_DUYET_DON_DAT_HANG_CS", txtMsDDH.Text.Trim, _
            IIf(chxDuyet4.Checked = True, 1, 0), IIf(chxDuyet1.Checked = True, 1, 0), IIf(chxDuyet1.Checked = True, 1, 0), IIf(chxDuyet1.Checked = True, 1, 0), IIf(chxDuyet1.Checked = True, 1, 0), _
            txtYKien1.Text.Trim, txtYKien2.Text.Trim, txtYKien3.Text.Trim, txtYKien4.Text.Trim)
            vListPO.AcceptChanges()
            If chxDuyet4.Checked = True Then
                loadData()
                BindData()
                lockControl()
            End If

            chxDuyet1.Enabled = False
            chxDuyet2.Enabled = False
            chxDuyet3.Enabled = False
            chxDuyet4.Enabled = False

            txtYKien1.ReadOnly = True
            txtYKien2.ReadOnly = True
            txtYKien3.ReadOnly = True
            txtYKien4.ReadOnly = True

            btnDuyet.Visible = True
            btnCapNhat.Visible = False
            btnHuy.Visible = False
            grdquyen.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuy.Click
        chxDuyet1.Enabled = False
        chxDuyet2.Enabled = False
        chxDuyet3.Enabled = False
        chxDuyet4.Enabled = False

        txtYKien1.ReadOnly = True
        txtYKien2.ReadOnly = True
        txtYKien3.ReadOnly = True
        txtYKien4.ReadOnly = True

        btnDuyet.Visible = True
        btnCapNhat.Visible = False
        btnHuy.Visible = False

        Try
            vEvent = "N"
            vMS_DDH = ""
            vListPO.RejectChanges()
            BindData()
            lockControl()
            lockInput(True)
            grdquyen.SelectedIndex = 0
            If (vIndex < grdListPO.Rows.Count) Then
                grdListPO.CurrentCell = grdListPO.Rows(vIndex).Cells(0)
            End If
            grdListPO.CurrentRow.Selected = True
        Catch ex As Exception
        End Try

    End Sub

    'Private Sub chxDuyet1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxDuyet1.CheckedChanged
    '    If chxDuyet1.Checked = True Then
    '        txtYKien1.ReadOnly = False
    '    Else
    '        txtYKien1.ReadOnly = True
    '    End If
    'End Sub

    'Private Sub chxDuyet2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxDuyet2.CheckedChanged
    '    If chxDuyet2.Checked = True Then
    '        txtYKien2.ReadOnly = False
    '    Else
    '        txtYKien2.ReadOnly = True
    '    End If
    'End Sub

    'Private Sub chxDuyet3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxDuyet3.CheckedChanged
    '    If chxDuyet3.Checked = True Then
    '        txtYKien3.ReadOnly = False
    '    Else
    '        txtYKien3.ReadOnly = True
    '    End If
    'End Sub

    'Private Sub chxDuyet4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxDuyet4.CheckedChanged
    '    If chxDuyet4.Checked = True Then
    '        txtYKien4.ReadOnly = False
    '    Else
    '        txtYKien4.ReadOnly = True
    '    End If
    'End Sub
End Class