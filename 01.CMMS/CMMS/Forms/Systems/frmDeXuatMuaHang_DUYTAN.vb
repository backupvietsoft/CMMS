Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Catalogue



Public Class frmDeXuatMuaHang_DUYTAN
    Dim SO_DE_XUAT_CU As String = ""
    Dim bThem As Boolean = False
    Dim intRow As Integer

    Private Sub btnChonVTPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonVTPT.Click
        frmChonPTDeXuat.ShowDialog()
        Dim str As String = ""
        Dim dtDE_XUAT_MUA_HANG As New DataTable
        If Not bThem Then
            str = "SELECT  DE_XUAT_MUA_HANG_CHI_TIET.MS_PT, TEN_PT, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT,DE_XUAT_MUA_HANG_CHI_TIET.TON_KHO,DE_XUAT_MUA_HANG_CHI_TIET.NHAN_HIEU,DE_XUAT_MUA_HANG_CHI_TIET.MS_HSX ,DE_XUAT_MUA_HANG_CHI_TIET.SO_LUONG,DE_XUAT_MUA_HANG_CHI_TIET.DON_GIA, DE_XUAT_MUA_HANG_CHI_TIET.SO_LUONG * DE_XUAT_MUA_HANG_CHI_TIET.DON_GIA AS THANH_TIEN , DE_XUAT_MUA_HANG_CHI_TIET.HOA_DON ,DE_XUAT_MUA_HANG_CHI_TIET.MS_KH,NGAY_CAN_HANG ,DE_XUAT_MUA_HANG_CHI_TIET.THOI_HAN_SD ,DE_XUAT_MUA_HANG_CHI_TIET.CONG_DUNG ,DE_XUAT_MUA_HANG_CHI_TIET.LOAI , DE_XUAT_MUA_HANG_CHI_TIET.GHI_CHU ,1 AS TON_TAI" & _
            " FROM DE_XUAT_MUA_HANG_CHI_TIET INNER JOIN  IC_PHU_TUNG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
            " DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT  WHERE SO_DE_XUAT='" & SO_DE_XUAT_CU & "'" & _
            " UNION SELECT  MS_PT,TEN_PT ,DVT, CONVERT(INT,NULL) AS TON_KHO, CONVERT(NVARCHAR(100),NULL) AS NHAN_HIEU,CONVERT(NVARCHAR(100),NULL) AS MS_HSX ,CONVERT(INT,NULL) AS SO_LUONG,CONVERT(INT,NULL) AS DON_GIA,CONVERT(INT,NULL) AS THANH_TIEN,CONVERT(NVARCHAR(50),NULL) AS HOA_DON,CONVERT(NVARCHAR(7),NULL) AS MS_KH,CONVERT(DATETIME,NULL) AS NGAY_CAN_HANG,CONVERT(NVARCHAR(30),NULL) AS THOI_HAN_SD, CONVERT(NVARCHAR(255),NULL) AS CONG_DUNG,CONVERT(NVARCHAR(5),NULL) AS LOAI,CONVERT(NVARCHAR(255),NULL) AS GHI_CHU,0 AS TON_TAI FROM tmpChonPT" & Commons.Modules.UserName & _
            " where MS_PT NOT IN (SELECT MS_PT FROM DE_XUAT_MUA_HANG_CHI_TIET WHERE SO_DE_XUAT='" & SO_DE_XUAT_CU & "' )"
        Else
            'str = " SELECT  MS_PT,TEN_PT ,DVT,CONVERT(INT,NULL) AS SO_LUONG,CONVERT(NVARCHAR(255),NULL) AS GHI_CHU,0 AS TON_TAI FROM tmpChonPT" & Commons.Modules.UserName
            str = "SELECT  MS_PT,TEN_PT ,DVT, CONVERT(INT,NULL) AS TON_KHO, CONVERT(NVARCHAR(100),NULL) AS NHAN_HIEU,CONVERT(NVARCHAR(100),NULL) AS NUOC_SX,CONVERT(INT,NULL) AS SO_LUONG,CONVERT(INT,NULL) AS DON_GIA,CONVERT(INT,NULL) AS THANH_TIEN,CONVERT(NVARCHAR(50),NULL) AS HOA_DON,CONVERT(NVARCHAR(7),NULL) AS MS_KH,CONVERT(DATETIME,NULL) AS NGAY_CAN_HANG,CONVERT(NVARCHAR(30),NULL) AS THOI_HAN_SD, CONVERT(NVARCHAR(255),NULL) AS CONG_DUNG,CONVERT(NVARCHAR(5),NULL) AS LOAI,CONVERT(NVARCHAR(255),NULL) AS GHI_CHU,0 AS TON_TAI FROM tmpChonPT" & Commons.Modules.UserName
        End If

        dtDE_XUAT_MUA_HANG.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

        Dim dtReader As SqlDataReader, iTonKho As Long = 0, iSLNhap As Long = 0, iSLXuat As Long = 0

        For i As Integer = 0 To dtDE_XUAT_MUA_HANG.Rows.Count - 1
            'LAY SL TON KHO
            str = "SELECT MS_PT, ISNULL(SUM(SL_VT),0) AS TONG FROM VI_TRI_KHO_VAT_TU WHERE MS_PT='" & dtDE_XUAT_MUA_HANG.Rows(i)("MS_PT").ToString & "' GROUP BY MS_PT"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While dtReader.Read
                iTonKho = dtReader.Item("TONG")
            End While
            dtReader.Close()

            iTonKho = iTonKho

            'CAP NHAT DL VAO LAI DATATABLE
            Try
                dtDE_XUAT_MUA_HANG.Columns("TON_KHO").ReadOnly = False
                dtDE_XUAT_MUA_HANG.Rows(i)("TON_KHO") = iTonKho
                dtDE_XUAT_MUA_HANG.Columns("TON_KHO").ReadOnly = True
            Catch
            End Try
        Next

        grdDanhsachvattu.Columns.Clear()
        'grdDanhsachvattu.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For j As Integer = 0 To dtDE_XUAT_MUA_HANG.Columns.Count - 1
            dtDE_XUAT_MUA_HANG.Columns(j).ReadOnly = False
        Next

        grdDanhsachvattu.DataSource = dtDE_XUAT_MUA_HANG

        If grdDanhsachvattu.Rows.Count > 0 Then
            LoadcboNuocSX()
            LoadcboNhaCungCap()
            LoadcboLoai()

            Dim col As New Commons.QLGridMaskedTextBoxColumn
            col.Name = "dtpNgayCanHang"
            col.DataPropertyName = "NGAY_CAN_HANG"
            col.Mask = "00/00/0000"
            col.DefaultCellStyle.Format = Nothing
            grdDanhsachvattu.Columns.Insert(13, col)
        Else
            grdDanhsachvattu.Columns.Clear()
            Exit Sub
        End If

        grdDanhsachvattu.Columns("TON_TAI").Visible = False
        RefreshLanguage()
        Try
            grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = False
            grdDanhsachvattu.Columns("GHI_CHU").ReadOnly = False
            grdDanhsachvattu.Columns("cboNuocSX").ReadOnly = False
            grdDanhsachvattu.Columns("NHAN_HIEU").ReadOnly = False
            grdDanhsachvattu.Columns("DON_GIA").ReadOnly = False
            grdDanhsachvattu.Columns("HOA_DON").ReadOnly = False
            grdDanhsachvattu.Columns("cboNCC").ReadOnly = False
            grdDanhsachvattu.Columns("cboLOAI").ReadOnly = False
            grdDanhsachvattu.Columns("dtpNgayCanHang").ReadOnly = False
            grdDanhsachvattu.Columns("NGAY_CAN_HANG").ReadOnly = False
            grdDanhsachvattu.Columns("THOI_HAN_SD").ReadOnly = False
            grdDanhsachvattu.Columns("CONG_DUNG").ReadOnly = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
    Sub BindData()
        grdDanhsachvattu.DataSource = Nothing
        Clear()
        If cboSoDeXuat.SelectedValue Is Nothing Then
            Exit Sub
        End If

        grdDanhsachvattu.Columns.Clear()

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM DE_XUAT_MUA_HANG WHERE SO_DE_XUAT='" & cboSoDeXuat.SelectedValue & "' AND NOT TO_PHONG_BAN IS NULL")

        While objReader.Read
            cboBoPhanDeXuat.SelectedValue = objReader.Item("TO_PHONG_BAN")
            dtpNgay.Value = objReader.Item("NGAY")
            If Not IsDBNull(objReader.Item("NGAY_GIAO")) Then txtNgayGiao.Text = objReader.Item("NGAY_GIAO")
            txtGiaoCho.Text = objReader.Item("NGUOI_NHAN").ToString
            txtNguoiDuyet.Text = objReader.Item("NGUOI_DUYET").ToString
        End While
        objReader.Close()
        grdDanhsachvattu.DataSource = New clsDE_XUAT_MUA_HANGControler().GetDE_XUAT_MUA_HANG_CHI_TIETs_DUYTAN(cboSoDeXuat.SelectedValue)
        grdDanhsachvattu.Columns("TON_TAI").Visible = False

        If grdDanhsachvattu.Rows.Count > 0 Then
            LoadcboNuocSX()
            LoadcboNhaCungCap()
            LoadcboLoai()
            Dim col As New Commons.QLGridMaskedTextBoxColumn
            col.Name = "dtpNgayCanHang"
            col.DataPropertyName = "NGAY_CAN_HANG"
            col.Mask = "00/00/0000"
            col.DefaultCellStyle.Format = Nothing
            grdDanhsachvattu.Columns.Insert(13, col)

            RefreshLanguage()
        ElseIf grdDanhsachvattu.Rows.Count = 0 Then
            grdDanhsachvattu.Columns.Clear()
        End If

        btnXoa.Enabled = IIf(grdDanhsachvattu.Rows.Count > 0, True, False)
        btnThem.Enabled = True
        If Not chkDuyet.Checked Then
            btnSua.Enabled = True
            btnDuyet.Enabled = True
        Else
            btnSua.Enabled = False
            btnDuyet.Enabled = False
        End If
    End Sub
    Sub RefreshLanguage()
        grdDanhsachvattu.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("MS_PT").Width = 100
        grdDanhsachvattu.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("TEN_PT").Width = 200
        grdDanhsachvattu.Columns("DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DVT", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("DVT").Width = 80
        grdDanhsachvattu.Columns("SO_LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("SO_LUONG").Width = 80
        grdDanhsachvattu.Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("GHI_CHU").Width = 250

        grdDanhsachvattu.Columns("TON_KHO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TON_KHO", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("NHAN_HIEU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHAN_HIEU", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("cboNuocSX").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_HSX", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("DON_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("HOA_DON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HOA_DON", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_TIEN", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("cboNCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHA_CUNG_CAP", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("dtpNgayCanHang").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_CAN_HANG", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("THOI_HAN_SD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_HAN_SD", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("CONG_DUNG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CONG_DUNG", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("cboLoai").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAI", Commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("DVT").Width = 50
        grdDanhsachvattu.Columns("DVT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDanhsachvattu.Columns("TON_KHO").Width = 90
        grdDanhsachvattu.Columns("TON_KHO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns("SO_LUONG").Width = 80
        grdDanhsachvattu.Columns("DON_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns("SO_LUONG").DefaultCellStyle.Format = "#,###"
        grdDanhsachvattu.Columns("DON_GIA").DefaultCellStyle.Format = "#,###"
        grdDanhsachvattu.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,###"
        grdDanhsachvattu.Columns("cboNCC").Width = 150
        grdDanhsachvattu.Columns("dtpNgayCanHang").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDanhsachvattu.Columns("cboLoai").Width = 80
        Try
            Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        Try
            grdDanhsachvattu.Columns("MS_HSX").Visible = False
        Catch ex As Exception
        End Try

        Try
            grdDanhsachvattu.Columns("NUOC_SX").Visible = False
        Catch ex As Exception
        End Try

        Try
            grdDanhsachvattu.Columns("NGAY_CAN_HANG").Visible = False
            grdDanhsachvattu.Columns("MS_KH").Visible = False
            grdDanhsachvattu.Columns("LOAI").Visible = False
        Catch ex As Exception
        End Try
        For i As Integer = 0 To grdDanhsachvattu.Columns.Count - 1
            grdDanhsachvattu.Columns(i).ReadOnly = True
        Next
    End Sub
    Sub Clear()
        txtGiaoCho.Text = ""
        txtNguoiDuyet.Text = ""
        txtSoDeXuat.Text = ""
        txtNgayGiao.Text = ""
        grdDanhsachvattu.DataSource = Nothing
        cboBoPhanDeXuat.SelectedIndex = -1
        grdDanhsachvattu.Columns.Clear()
    End Sub
    Sub LoadcboPhongYC()
        cboBoPhanDeXuat.Param = "SELECT MS_TO AS MS_DON_VI, TEN_TO AS TEN_DON_VI FROM TO_PHONG_BAN"
        cboBoPhanDeXuat.StoreName = "QL_SEARCH"
        cboBoPhanDeXuat.Display = "TEN_DON_VI"
        cboBoPhanDeXuat.Value = "MS_DON_VI"
        cboBoPhanDeXuat.BindDataSource()
    End Sub

    Sub LoadcboNuocSX()
        Dim cboColumn As New DataGridViewComboBoxColumn()
        Dim dtTable1 As New DataTable
        dtTable1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM HANG_SAN_XUAT ORDER BY TEN_HSX"))
        cboColumn.Name = "cboNuocSX"
        cboColumn.ValueMember = "MS_HSX"
        cboColumn.DisplayMember = "TEN_HSX"
        cboColumn.DataPropertyName = "MS_HSX"
        cboColumn.DropDownWidth = 180
        cboColumn.DataSource = dtTable1
        grdDanhsachvattu.Columns.Insert(5, cboColumn)
        grdDanhsachvattu.Columns("cboNuocSX").ReadOnly = True
    End Sub

    Sub LoadcboLoai()
        Dim cboColumn As New DataGridViewComboBoxColumn()
        Dim dtTable1 As New DataTable
        Dim dtRow As DataRow, dtColumn As New DataColumn

        dtTable1.Columns.Clear()
        dtTable1.Columns.Add("MS_LOAI", GetType(String))
        dtTable1.Columns.Add("TEN_LOAI", GetType(String))
        If Commons.Modules.TypeLanguage = 0 Then
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "S"
            dtRow.Item("TEN_LOAI") = "Sửa chữa"
            dtTable1.Rows.Add(dtRow)
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "B"
            dtRow.Item("TEN_LOAI") = "Bảo trì"
            dtTable1.Rows.Add(dtRow)
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "M"
            dtRow.Item("TEN_LOAI") = "Lắp mới"
            dtTable1.Rows.Add(dtRow)
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "K"
            dtRow.Item("TEN_LOAI") = "Khác"
            dtTable1.Rows.Add(dtRow)
        Else
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "S"
            dtRow.Item("TEN_LOAI") = "Repair"
            dtTable1.Rows.Add(dtRow)
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "B"
            dtRow.Item("TEN_LOAI") = "Maintenace"
            dtTable1.Rows.Add(dtRow)
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "M"
            dtRow.Item("TEN_LOAI") = "Install"
            dtTable1.Rows.Add(dtRow)
            dtRow = dtTable1.NewRow
            dtRow.Item("MS_LOAI") = "K"
            dtRow.Item("TEN_LOAI") = "Other"
            dtTable1.Rows.Add(dtRow)
        End If
        cboColumn.DataSource = dtTable1
        cboColumn.ValueMember = "MS_LOAI"
        cboColumn.DisplayMember = "TEN_LOAI"
        cboColumn.Name = "cboLOAI"
        cboColumn.DataPropertyName = "LOAI"
        grdDanhsachvattu.Columns.Insert(16, cboColumn)
        grdDanhsachvattu.Columns("cboLOAI").ReadOnly = True
    End Sub

    Sub LoadcboNhaCungCap()
        Dim cboColumn As New DataGridViewComboBoxColumn()
        Dim dtTable1 As New DataTable
        dtTable1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM KHACH_HANG ORDER BY TEN_RUT_GON"))
        cboColumn.Name = "cboNCC"
        cboColumn.ValueMember = "MS_KH"
        cboColumn.DisplayMember = "TEN_RUT_GON"
        cboColumn.DataPropertyName = "MS_KH"
        cboColumn.DropDownWidth = 180
        cboColumn.DataSource = dtTable1
        grdDanhsachvattu.Columns.Insert(12, cboColumn)
        grdDanhsachvattu.Columns("cboNCC").ReadOnly = True
    End Sub
    Sub LoadcboSoDeXuat()
        cboSoDeXuat.DataSource = Nothing
        cboSoDeXuat.Display = "SO_DE_XUAT"
        cboSoDeXuat.Value = "SO_DE_XUAT"
        cboSoDeXuat.StoreName = "GetDE_XUAT_MUA_HANGs"
        cboSoDeXuat.Param = IIf(chkDuyet.Checked, 1, 0)
        cboSoDeXuat.BindDataSource()
    End Sub
    Sub VisibleButtton(ByVal chon As Boolean)
        btnThem.Visible = chon
        btnSua.Visible = chon
        btnThoat.Visible = chon
        btnXoa.Visible = chon
        btnGhi.Visible = Not chon
        btnKhongGhi.Visible = Not chon
        txtSoDeXuat.Visible = Not chon
        btnChonVTPT.Visible = chon
        cboSoDeXuat.Visible = chon
        btnIn.Visible = chon
        btnDuyet.Visible = chon
        chkDuyet.Enabled = chon
        cboBoPhanDeXuat.Enabled = Not chon
        dtpNgay.Enabled = Not chon
        txtNgayGiao.Enabled = Not chon
        txtGiaoCho.Enabled = Not chon
        txtNguoiDuyet.Enabled = Not chon
    End Sub

    Private Sub frmDeXuatMuaHang_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim str As String = ""
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmpChonPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[tmpChonPT" & Commons.Modules.UserName & "]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub frmDeXuatMuaHang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Commons.Modules.ObjSystems.DinhDang()
        VisibleButtton(True)
        LoadcboSoDeXuat()
        LoadcboPhongYC()
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(True)
        Else
            EnableButton(False)
        End If
        AddHandler chkDuyet.CheckedChanged, AddressOf Me.chkDuyet_CheckedChanged
        BindData()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        btnChonVTPT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnChonVTPT.Name, Commons.Modules.TypeLanguage)
        btnDuyet.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnDuyet.Name, Commons.Modules.TypeLanguage)
        btnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnThem.Name, Commons.Modules.TypeLanguage)
        btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnXoa.Name, Commons.Modules.TypeLanguage)
        btnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnSua.Name, Commons.Modules.TypeLanguage)
        btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnGhi.Name, Commons.Modules.TypeLanguage)
        btnKhongGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnKhongGhi.Name, Commons.Modules.TypeLanguage)
        btnIn.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, btnIn.Name, Commons.Modules.TypeLanguage)
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        btnThem.Enabled = Not chon
        'BtnXoa.Enabled = Not chon
        btnSua.Enabled = Not chon
        btnDuyet.Enabled = Not chon
    End Sub
    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThem.Click
        Clear()
        bThem = True
        VisibleButtton(False)
        btnChonVTPT.Visible = True
        Try
            grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = False
            grdDanhsachvattu.Columns("GHI_CHU").ReadOnly = False
            grdDanhsachvattu.Columns("cboNuocSX").ReadOnly = False
            grdDanhsachvattu.Columns("NHAN_HIEU").ReadOnly = False
            grdDanhsachvattu.Columns("DON_GIA").ReadOnly = False
            grdDanhsachvattu.Columns("HOA_DON").ReadOnly = False
            grdDanhsachvattu.Columns("cboNCC").ReadOnly = False
            grdDanhsachvattu.Columns("cboLOAI").ReadOnly = False
            grdDanhsachvattu.Columns("NGAY_CAN_HANG").ReadOnly = False
            grdDanhsachvattu.Columns("THOI_HAN_SD").ReadOnly = False
            grdDanhsachvattu.Columns("CONG_DUNG").ReadOnly = False
        Catch ex As Exception
        End Try
        txtSoDeXuat.Focus()
        AddHandler grdDanhsachvattu.DataError, AddressOf Me.grdDanhsachvattu_DataError
    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSua.Click
        If grdDanhsachvattu.Rows.Count = 0 Then
            Exit Sub
        End If
        txtSoDeXuat.Text = cboSoDeXuat.Text
        SO_DE_XUAT_CU = cboSoDeXuat.Text
        bThem = False
        VisibleButtton(False)
        btnChonVTPT.Visible = True
        Try
            grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = False
            grdDanhsachvattu.Columns("GHI_CHU").ReadOnly = False

            grdDanhsachvattu.Columns("cboNuocSX").ReadOnly = False
            grdDanhsachvattu.Columns("NHAN_HIEU").ReadOnly = False
            grdDanhsachvattu.Columns("DON_GIA").ReadOnly = False
            grdDanhsachvattu.Columns("HOA_DON").ReadOnly = False
            grdDanhsachvattu.Columns("cboNCC").ReadOnly = False
            grdDanhsachvattu.Columns("cboLOAI").ReadOnly = False
            grdDanhsachvattu.Columns("NGAY_CAN_HANG").ReadOnly = False
            grdDanhsachvattu.Columns("dtpNgayCanHang").ReadOnly = False
            grdDanhsachvattu.Columns("THOI_HAN_SD").ReadOnly = False
            grdDanhsachvattu.Columns("CONG_DUNG").ReadOnly = False
        Catch ex As Exception
        End Try
        AddHandler grdDanhsachvattu.DataError, AddressOf grdDanhsachvattu_DataError
        txtSoDeXuat.Focus()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        If KiemTra() Then
            Dim bSoLuong As Integer = -1, j As Integer
            For j = 0 To grdDanhsachvattu.Rows.Count - 1
                If j <> grdDanhsachvattu.NewRowIndex Then
                    If IsDBNull(grdDanhsachvattu.Rows(j).Cells("cboNuocSX").Value) Or grdDanhsachvattu.Rows(j).Cells("cboNuocSX").Value Is Nothing Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NUOC_SX_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(j).Cells("cboNuocSX")
                        Exit Sub
                    End If
                    If IsDBNull(grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(j).Cells("SO_LUONG")
                        Exit Sub
                    End If
                    If IsDBNull(grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(j).Cells("DON_GIA")
                        Exit Sub
                    End If
                    If IsDBNull(grdDanhsachvattu.Rows(j).Cells("cboNCC").Value) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHA_CUNG_CAP_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(j).Cells("cboNCC")
                        Exit Sub
                    End If
                    If IsDBNull(grdDanhsachvattu.Rows(j).Cells("dtpNgayCanHang").Value) Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_CAN_HANG_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(j).Cells("dtpNgayCanHang")
                        Exit Sub
                    ElseIf CDate(grdDanhsachvattu.Rows(j).Cells("dtpNgayCanHang").Value) < CDate("01/01/1900") Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_CAN_KHONG_HOP_LE", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(j).Cells("dtpNgayCanHang")
                        Exit Sub
                    End If
                    If IsDBNull(grdDanhsachvattu.Rows(j).Cells("cboLOAI").Value) Or grdDanhsachvattu.Rows(j).Cells("cboLOAI").Value Is Nothing Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAI_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdDanhsachvattu.CurrentCell = grdDanhsachvattu.Rows(j).Cells("cboLOAI")
                        Exit Sub
                    End If
                End If
            Next

            For j = 0 To grdDanhsachvattu.Rows.Count - 1
                If j <> grdDanhsachvattu.NewRowIndex Then
                    If grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value.ToString <> "" Then
                        If grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value = 0 Then
                            bSoLuong = bSoLuong + 1
                        End If
                    Else
                        bSoLuong = bSoLuong + 1
                    End If
                End If
            Next
            Dim Traloi As String
            If grdDanhsachvattu.Rows.Count = 0 Then
                Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuachonVatTu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    Exit Sub
                Else
                    GoTo KetThuc
                End If
            ElseIf bSoLuong = grdDanhsachvattu.Rows.Count - 1 Then
                Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuaNhapSoLuong", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    Exit Sub
                Else
                    GoTo KetThuc
                End If
            ElseIf bSoLuong < grdDanhsachvattu.Rows.Count - 1 And bSoLuong <> -1 Then
                Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoLuongChuaNhap", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    grdDanhsachvattu.Focus()
                    Exit Sub
                End If
            End If

            Dim tb As New DataTable()
            tb = grdDanhsachvattu.DataSource
            Dim objDeXuat As New clsDE_XUAT_MUA_HANGInfo()
            objDeXuat.MS_DON_VI = cboBoPhanDeXuat.SelectedValue
            objDeXuat.NGAY = Format(dtpNgay.Value, "Short date")
            objDeXuat.NGUOI_NHAN = txtGiaoCho.Text
            objDeXuat.NGUOI_DUYET = txtNguoiDuyet.Text
            objDeXuat.NGAY_GIAO = IIf(IsDate(txtNgayGiao.Text) = True, txtNgayGiao.Text, Nothing)
            objDeXuat.SO_DE_XUAT = txtSoDeXuat.Text.Trim
            If Not bThem Then
                objDeXuat.SO_DE_XUAT_CU = SO_DE_XUAT_CU
            End If
            Dim tmp As String = New clsDE_XUAT_MUA_HANGControler().AddDE_XUAT_MUA_HANG_DUYTAN(objDeXuat, tb)

            If tmp = "" Then
                'XtraMessageBox.Show("thực hiện lưu không thành công")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLuuKhongThanhCong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            chkDuyet.Checked = False
            LoadcboSoDeXuat()
            cboSoDeXuat.SelectedValue = tmp
KetThuc:
            bThem = False
            VisibleButtton(True)
            BindData()
            Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "tmpChonPT" & Commons.Modules.UserName)
        End If
    End Sub
    Function KiemTra() As Boolean
        If Not txtSoDeXuat.IsValidated Then
            txtSoDeXuat.Focus()
            Return False
        End If
        If Not txtGiaoCho.IsValidated Then
            txtGiaoCho.Focus()
            Return False
        End If
        If Not cboBoPhanDeXuat.IsValidated Or cboBoPhanDeXuat.SelectedValue Is Nothing Then
            cboBoPhanDeXuat.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        ErrorProvider1.Clear()
        bThem = False
        VisibleButtton(True)
        BindData()
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "tmpChonPT" & Commons.Modules.UserName)
    End Sub

    Private Sub txtNgayGiao_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If btnKhongGhi.Focused() Then
            Exit Sub
        End If
        If Date.Parse(Format(dtpNgay.Value, "Short date")) > Date.Parse(txtNgayGiao.Text) Then
            'XtraMessageBox.Show("NGÀY giao phải lớn hơn ngày lập")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayGiaoNhoHonNgayLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        End If
    End Sub


    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click
        If grdDanhsachvattu.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim RowCount As Integer = grdDanhsachvattu.Rows.Count
            Dim tmp As Integer = intRow
            Dim objDeXuat As New clsDE_XUAT_MUA_HANGControler()
            objDeXuat.DeleteDE_XUAT_MUA_HANG_CHI_TIET(cboSoDeXuat.SelectedValue, grdDanhsachvattu.Rows(intRow).Cells("MS_PT").Value)
            If RowCount = 1 Then
                objDeXuat.DeleteDE_XUAT_MUA_HANG(cboSoDeXuat.SelectedValue)
                LoadcboSoDeXuat()
            End If
            BindData()
            If RowCount > 1 Then
                If tmp = grdDanhsachvattu.Rows.Count Then
                    grdDanhsachvattu.CurrentCell() = grdDanhsachvattu.Rows(tmp - 1).Cells("MS_PT")
                    grdDanhsachvattu.Focus()
                    Exit Sub
                ElseIf tmp < grdDanhsachvattu.Rows.Count Then
                    grdDanhsachvattu.CurrentCell() = grdDanhsachvattu.Rows(tmp).Cells("MS_PT")
                    grdDanhsachvattu.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Dim txtSoLuong As TextBox
    Sub HandleKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdDanhsachvattu_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachvattu.CellValidated
        If grdDanhsachvattu.Columns(e.ColumnIndex).Name = "cboNuocSX" Then
            Try
                grdDanhsachvattu.Rows(e.RowIndex).Cells("NUOC_SX").Value = grdDanhsachvattu.Rows(e.RowIndex).Cells("cboNuocSX").Value
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdDanhsachvattu_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDanhsachvattu.DataError
        If IsDate(grdDanhsachvattu.Rows(e.RowIndex).Cells("dtpNgayCanHang").Value) = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_KHONG_HOP_LE", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
            e.Cancel = True
            Exit Sub
            'ElseIf grdDanhsachvattu.Rows(e.RowIndex).Cells("dtpNgayCanHang").Value < dtpNgay.Value Then
            '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_CAN_HANG_NHO_HON_NGAY_LAP", commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.txtNgayGiao)
            '    e.Cancel = True
            '    Exit Sub
        End If
        e.Cancel = False
    End Sub

    Private Sub grdDanhsachvattu_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDanhsachvattu.EditingControlShowing
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            If TypeOf e.Control Is TextBox Then
                If dgv.CurrentCell.OwningColumn.Name = "SO_LUONG" Then
                    txtSoLuong = e.Control

                    RemoveHandler txtSoLuong.KeyPress, AddressOf Me.HandleKeyPress
                    AddHandler txtSoLuong.KeyPress, AddressOf Me.HandleKeyPress
                Else
                    RemoveHandler txtSoLuong.KeyPress, AddressOf Me.HandleKeyPress
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDanhsachvattu_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachvattu.RowEnter
        If e.RowIndex >= 0 Then
            intRow = e.RowIndex
        End If
    End Sub
    Sub ShowrptDonDatHang()
        Cursor = Cursors.WaitCursor
        Dim dtDE_XUAT_MUA_HANG As New DataTable, dtTIEU_DE_DE_XUAT_MUA_HANG As New DataTable

        dtDE_XUAT_MUA_HANG.Clear()
        dtTIEU_DE_DE_XUAT_MUA_HANG.Clear()
        dtDE_XUAT_MUA_HANG.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetrptDE_XUAT_MUA_HANG_DUYTAN", cboSoDeXuat.SelectedValue, Commons.Modules.TypeLanguage))
        dtDE_XUAT_MUA_HANG.TableName = "rptDE_XUAT_MUA_HANG"

        If dtDE_XUAT_MUA_HANG.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Cursor = Cursors.Default
            Exit Sub
        End If

        dtTIEU_DE_DE_XUAT_MUA_HANG = CreateTieuDeDeXuatMuaHang()

        Dim dtReader As SqlDataReader, str As String = ""

        str = "SELECT SUM(ISNULL(DE_XUAT_MUA_HANG_CHI_TIET.SO_LUONG, 0) * ISNULL(DE_XUAT_MUA_HANG_CHI_TIET.DON_GIA, 0)) AS THANH_TIEN " & _
              "FROM DE_XUAT_MUA_HANG INNER JOIN DE_XUAT_MUA_HANG_CHI_TIET ON DE_XUAT_MUA_HANG.SO_DE_XUAT = DE_XUAT_MUA_HANG_CHI_TIET.SO_DE_XUAT INNER JOIN " & _
                   "IC_PHU_TUNG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN " & _
                   "TO_PHONG_BAN ON DE_XUAT_MUA_HANG.TO_PHONG_BAN = TO_PHONG_BAN.MS_TO LEFT OUTER JOIN KHACH_HANG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_KH = KHACH_HANG.MS_KH LEFT OUTER JOIN " & _
                   "HANG_SAN_XUAT ON DE_XUAT_MUA_HANG_CHI_TIET.MS_HSX = HANG_SAN_XUAT.MS_HSX " & _
              "WHERE DE_XUAT_MUA_HANG.SO_DE_XUAT='" & cboSoDeXuat.SelectedValue & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            If dtReader.Item("THANH_TIEN") > 0 Then
                str = Commons.clsXuLy.DocTien(dtReader.Item("THANH_TIEN").ToString)
            End If
        End While
        dtReader.Close()

        If str.Substring(str.Length - 1, 1).ToString = "." Then str = str.Substring(0, str.Length - 1)
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH=1")
        While dtReader.Read
            str &= " " & dtReader.Item("NGOAI_TE") & ""
        End While
        dtReader.Close()

        dtTIEU_DE_DE_XUAT_MUA_HANG.Columns("_TIEN_CHU_").ReadOnly = False
        dtTIEU_DE_DE_XUAT_MUA_HANG.Rows(0)("_TIEN_CHU_") = str
        dtTIEU_DE_DE_XUAT_MUA_HANG.Columns("_TIEN_CHU_").ReadOnly = True

        Commons.clsXuLy.CreateTitleReport()
        Dim dtTIEU_DE_REPORT As New DataTable

        dtTIEU_DE_REPORT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTHONG_TIN_CHUNG"))
        dtTIEU_DE_REPORT.TableName = "rptTIEU_DE_REPORT"
        frmShowXMLReport.rptName = "rptDeXuatMuaHang_DUYTAN"
        frmShowXMLReport.RemoveDataTableSource()
        frmShowXMLReport.AddDataTableSource(dtDE_XUAT_MUA_HANG)
        frmShowXMLReport.AddDataTableSource(dtTIEU_DE_DE_XUAT_MUA_HANG)
        frmShowXMLReport.AddDataTableSource(dtTIEU_DE_REPORT)
        frmShowXMLReport.Show()
        Cursor = Cursors.Default
    End Sub

    Private Function CreateTieuDeDeXuatMuaHang() As DataTable
        Dim dtTieuDe As New DataTable

        Dim phieudexuatmh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "phieudexuatmh", Commons.Modules.TypeLanguage)
        Dim bophandexuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "bophandexuat", Commons.Modules.TypeLanguage)
        Dim danhchophongmua As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "danhchophongmua", Commons.Modules.TypeLanguage)
        Dim phucluc1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "phucluc1", Commons.Modules.TypeLanguage)
        Dim so As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "so", Commons.Modules.TypeLanguage)
        Dim tt_mh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "tt_mh", Commons.Modules.TypeLanguage)
        Dim ngaygioden As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "ngaygioden", Commons.Modules.TypeLanguage)
        Dim ngaygiodi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "ngaygiodi", Commons.Modules.TypeLanguage)
        Dim stt As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "stt", Commons.Modules.TypeLanguage)
        Dim tenhangquycach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "tenhangquycach", Commons.Modules.TypeLanguage)
        Dim dvt As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "dvt", Commons.Modules.TypeLanguage)
        Dim tonkho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "tonkho", Commons.Modules.TypeLanguage)
        Dim nhanhieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "nhanhieu", Commons.Modules.TypeLanguage)
        Dim nuocsx As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "nuocsx", Commons.Modules.TypeLanguage)
        Dim soluong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "soluong", Commons.Modules.TypeLanguage)
        Dim dongia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "dongia", Commons.Modules.TypeLanguage)
        Dim thanhtien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "thanhtien", Commons.Modules.TypeLanguage)
        Dim hoadon As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "hoadon", Commons.Modules.TypeLanguage)
        Dim nhacungung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "nhacungung", Commons.Modules.TypeLanguage)
        Dim ngaycanhang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "ngaycanhang", Commons.Modules.TypeLanguage)
        Dim thoihansd As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "thoihansd", Commons.Modules.TypeLanguage)
        Dim congdung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "congdung", Commons.Modules.TypeLanguage)
        Dim loai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "loai", Commons.Modules.TypeLanguage)
        Dim ghichuloai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "ghichuloai", Commons.Modules.TypeLanguage)
        Dim pheduyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "pheduyet", Commons.Modules.TypeLanguage)
        Dim truongbophan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "truongbophan", Commons.Modules.TypeLanguage)
        Dim ngaythangnam As String = IIf(Commons.Modules.TypeLanguage = 0, "Ngày ", "Day ") & dtpNgay.Value.Day & IIf(Commons.Modules.TypeLanguage = 0, " Tháng ", " Month ") & dtpNgay.Value.Month & IIf(Commons.Modules.TypeLanguage = 0, " Năm ", " Year ") & dtpNgay.Value.Year ' Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "ngaythangnam", commons.Modules.TypeLanguage)
        Dim nguoidexuat As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "nguoidexuat", Commons.Modules.TypeLanguage)
        Dim tongcong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "tongcong", Commons.Modules.TypeLanguage)
        Dim tienchu As String = ""
        Dim trang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDeXuatMuaHang_DUYTAN", "trang", Commons.Modules.TypeLanguage)

        Dim dtRow As DataRow, dtColumn As New DataColumn

        dtTieuDe.Columns.Clear()

        dtTieuDe.Columns.Add("_TIEU_DE_", GetType(String))
        dtTieuDe.Columns.Add("_BO_PHAN_DE_XUAT_", GetType(String))
        dtTieuDe.Columns.Add("_DANH_CHO_PHONG_MUA_", GetType(String))
        dtTieuDe.Columns.Add("_PHUC_LUC1_", GetType(String))
        dtTieuDe.Columns.Add("_SO_", GetType(String))
        dtTieuDe.Columns.Add("_TT_MH_", GetType(String))
        dtTieuDe.Columns.Add("_NGAY_GIO_DEN_", GetType(String))
        dtTieuDe.Columns.Add("_NGAY_GIO_DI_", GetType(String))
        dtTieuDe.Columns.Add("_STT_", GetType(String))
        dtTieuDe.Columns.Add("_TEN_HANG_QUY_CACH", GetType(String))
        dtTieuDe.Columns.Add("_DVT_", GetType(String))
        dtTieuDe.Columns.Add("_TON_KHO_", GetType(String))
        dtTieuDe.Columns.Add("_NHAN_HIEU_", GetType(String))
        dtTieuDe.Columns.Add("_NUOC_SX_", GetType(String))
        dtTieuDe.Columns.Add("_SO_LUONG_", GetType(String))
        dtTieuDe.Columns.Add("_DON_GIA_", GetType(String))
        dtTieuDe.Columns.Add("_THANH_TIEN_", GetType(String))
        dtTieuDe.Columns.Add("_HOA_DON_", GetType(String))
        dtTieuDe.Columns.Add("_NHA_CUNG_UNG_", GetType(String))
        dtTieuDe.Columns.Add("_NGAY_CAN_HANG_", GetType(String))
        dtTieuDe.Columns.Add("_THOI_HAN_SD_", GetType(String))
        dtTieuDe.Columns.Add("_CONG_DUNG_", GetType(String))
        dtTieuDe.Columns.Add("_LOAI_", GetType(String))
        dtTieuDe.Columns.Add("_GHI_CHU_LOAI_", GetType(String))
        dtTieuDe.Columns.Add("_PHE_DUYET_", GetType(String))
        dtTieuDe.Columns.Add("_TRUONG_BO_PHAN_", GetType(String))
        dtTieuDe.Columns.Add("_NGAY_THANG_NAM_", GetType(String))
        dtTieuDe.Columns.Add("_NGUOI_DE_XUAT_", GetType(String))
        dtTieuDe.Columns.Add("_TIEN_CHU_", GetType(String))
        dtTieuDe.Columns.Add("_TONG_CONG_", GetType(String))
        dtTieuDe.Columns.Add("_TRANG_", GetType(String))

        dtRow = dtTieuDe.NewRow
        dtRow.Item("_TIEU_DE_") = phieudexuatmh
        dtRow.Item("_BO_PHAN_DE_XUAT_") = bophandexuat
        dtRow.Item("_DANH_CHO_PHONG_MUA_") = danhchophongmua
        dtRow.Item("_PHUC_LUC1_") = phucluc1
        dtRow.Item("_SO_") = so
        dtRow.Item("_TT_MH_") = tt_mh
        dtRow.Item("_NGAY_GIO_DEN_") = ngaygioden
        dtRow.Item("_NGAY_GIO_DI_") = ngaygiodi
        dtRow.Item("_STT_") = stt
        dtRow.Item("_TEN_HANG_QUY_CACH") = tenhangquycach
        dtRow.Item("_DVT_") = dvt
        dtRow.Item("_TON_KHO_") = tonkho
        dtRow.Item("_NHAN_HIEU_") = nhanhieu
        dtRow.Item("_NUOC_SX_") = nuocsx
        dtRow.Item("_SO_LUONG_") = soluong
        dtRow.Item("_DON_GIA_") = dongia
        dtRow.Item("_THANH_TIEN_") = thanhtien
        dtRow.Item("_HOA_DON_") = hoadon
        dtRow.Item("_NHA_CUNG_UNG_") = nhacungung
        dtRow.Item("_NGAY_CAN_HANG_") = ngaycanhang
        dtRow.Item("_THOI_HAN_SD_") = thoihansd
        dtRow.Item("_CONG_DUNG_") = congdung
        dtRow.Item("_LOAI_") = loai
        dtRow.Item("_GHI_CHU_LOAI_") = ghichuloai
        dtRow.Item("_PHE_DUYET_") = pheduyet
        dtRow.Item("_TRUONG_BO_PHAN_") = truongbophan
        dtRow.Item("_NGAY_THANG_NAM_") = ngaythangnam
        dtRow.Item("_NGUOI_DE_XUAT_") = nguoidexuat
        dtRow.Item("_TIEN_CHU_") = tienchu
        dtRow.Item("_TONG_CONG_") = tongcong
        dtRow.Item("_TRANG_") = trang
        dtTieuDe.Rows.Add(dtRow)

        dtTieuDe.TableName = "rptTIEU_DE_DE_XUAT_MUA_HANG"
        Return dtTieuDe
    End Function

    Private Sub BtnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        If grdDanhsachvattu.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        ShowrptDonDatHang()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnDuyet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDuyet.Click
        If cboSoDeXuat.SelectedValue Is Nothing Then Exit Sub
        If txtNguoiDuyet.Text.ToString.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_DUYET_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME='" & Commons.Modules.UserName & "' AND STT=2")
        While objReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE DE_XUAT_MUA_HANG SET DUYET=1 WHERE SO_DE_XUAT='" & cboSoDeXuat.SelectedValue & "'")
            objReader.Close()
            LoadcboSoDeXuat()
            BindData()
            Exit Sub
        End While
        objReader.Close()
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoQuyenDuyet", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    End Sub

    Private Sub chkDuyet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles chkDuyet.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        LoadcboSoDeXuat()
        'If chkDuyet.Checked Then
        '    EnableButton(True)
        'Else
        '    EnableButton(False)
        'End If
        BindData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cbosoDeXuat_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSoDeXuat.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub cbosoDeXuat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSoDeXuat.Validating
        If Not btnGhi.Visible Then
            BindData()
        End If
    End Sub

    Private Sub cboBoPhanDeXuat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoPhanDeXuat.SelectedIndexChanged
        'Tao so de xuat
        'txtSoDeXuat.Text = 
        'If cboBoPhanDeXuat.SelectedValue = "" Then


        'ElseIf cboSoDeXuat.SelectedValue = "" Then


        'End If


    End Sub



End Class