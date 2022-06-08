Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue

Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports DevExpress.XtraEditors
Imports System.Globalization
Imports System.Linq
Imports Commons

Public Class frmThoiGianNgungMayNew
    Private TbTGNM As DataTable
    Private tbTG As DataTable
    Private tbMay As DataTable



    Private TrangThai As String = [String].Empty
    Private lannm As String = "-1"
    Private index As String = 0
    Public MS_MAY As String = ""
    Public NGAY_BD As DateTime = DateTime.Now
    Public GIO_BD As DateTime = DateTime.Now
    Public MS_NN As String = ""
    Public NGAY_KT As DateTime = DateTime.Now
    Public GIO_KT As DateTime = DateTime.Now

    Public NGAY_SX As DateTime = DateTime.Now

    Public MS_PHIEU_BAO_TRI As String
    Dim v_all As DataTable = New DataTable
    Private vtbPhieuBaoTri As DataTable
    Private bLock As Boolean
    Private bUnLock As Boolean
    Private _Loc As Collection
    Private cur_NgayBD As DateTime
    Private cur_NgayKT As DateTime
    Private Sub frmThoiGianNgungMayNew_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHOI_GIAN_NGUNG_MAY")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_THOI_GIAN_NGUNG_MAY")
    End Sub
    'Private BindingTGNM As New BindingSource()

    Private Sub frmThoiGianNgungMayNew_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            panel1.Visible = True
            Panel2.Visible = False
            _Loc = New Collection()
            Commons.Modules.SQLString = "0Load"
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            Dim str As String = ""

            If Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 49) Then bLock = True
            If Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 50) Then bUnLock = True

            If MS_MAY <> "" Then
                If NGAY_BD < Now.AddMonths(-3) Then
                    dtpTNgayLoc.Value = NGAY_BD.AddMonths(-3)
                    dtpDNgayLoc.Value = NGAY_BD.AddMonths(1)
                Else
                    dtpTNgayLoc.Value = Now.AddMonths(-3)
                    dtpDNgayLoc.Value = Now.AddMonths(1)

                End If

            Else
                dtpTNgayLoc.Value = Now.AddMonths(-3)
                dtpDNgayLoc.Value = Now.AddMonths(1)
            End If

            cur_NgayBD = dtpTNgayLoc.Value
            cur_NgayKT = dtpDNgayLoc.Value
            LoadLoaithietbi()
            LoadLoaidungmay()
            LoadDiaDiem()
            LoadMay()


            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, Commons.Modules.UserName))

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiGiaiQuyet, dtTable, "HO_TEN_CONG_NHAN", "HO_TEN_CONG_NHAN", "")



            dtTable = New DataTable()
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 6, Commons.Modules.UserName))

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTruongCa, dtTable, "HO_TEN_CONG_NHAN", "HO_TEN_CONG_NHAN", "")



            dtpNgaybatdau.Text = DateTime.Now.[Date].ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            dtpGioBD.Text = DateTime.Now.[Date].ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            dtpNgayKT.Text = DateTime.Now.[Date].ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            dtpGioKT.Text = DateTime.Now.[Date].AddHours(1).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            dtpNgaySX.Text = DateTime.Now.[Date].ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            Commons.Modules.SQLString = ""




            InitializeDatabase()
            InitializeForm()


            If MS_MAY <> "" Then
                btnAdd_Click(btnAdd, EventArgs.Empty)
                cboMSMAY.SelectedValue = MS_MAY
                dtpNgaybatdau.Value = NGAY_BD
                LoadPhieuBaoTri(MS_MAY)
                dtpGioBD.Value = GIO_BD
                dtpNgayKT.Value = NGAY_KT
                dtpGioKT.Value = GIO_KT

                dtpNgaySX.Value = NGAY_SX

                cboLoaidungmay.SelectedValue = MS_NN
                cmbPhieuBaoTri.SelectedValue = MS_PHIEU_BAO_TRI
                CapNhapNgay()
            End If
        Catch ex As Exception

        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        'RefeshLanguage()
        If bUnLock = False Then btnUnLockTGNM.Visible = False
        If bLock = False Then btnLockTGNM.Visible = False
        Try

            gvLanngungmay.AllowUserToDeleteRows = True
            gvThoigianngungmay.AllowUserToDeleteRows = True
        Catch ex As Exception

        End Try
    End Sub



    Private Sub InitializeDatabase()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If cboLoaiTB.SelectedValue = Nothing Then Exit Sub
        Dim iLock As Integer = 0
        If chkIsLock.Checked = True Then
            iLock = 1
        End If

        Dim dtTable As New DataTable


        Dim STR As String = "select STT, ( case '" + Commons.Modules.TypeLanguage.ToString() + "' when 0 then CA when 1 then isnull(ca_anh,CA) end ) + ' (' + CONVERT(NVARCHAR(5),CAST(TU_GIO AS TIME),108) + ' - ' +  CONVERT(NVARCHAR(5),CAST(DEN_GIO AS TIME),108) + ')' as TEN_CA from CA order by TU_GIO "

        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, STR))

        cboCa.DisplayMember = "TEN_CA"
        cboCa.ValueMember = "STT"
        cboCa.DataSource = dtTable
        cboCa.DropDownWidth = 150

        tbTG = New DataTable()
        gvLanngungmay.DataSource = System.DBNull.Value
        Dim SqlTbTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
        TbTGNM = New DataTable()

        Try
            TbTGNM.Load(SqlTbTGNM.ExecuteReader(CommandType.StoredProcedure, "GetTHOI_GIAN_NGUNG_MAY_SO_LAN", Commons.Modules.UserName,
                    "-1", cboLoaiTB.SelectedValue, -1, cboDiaDiem.SelectedValue, -1, dtpTNgayLoc.Value, dtpDNgayLoc.Value, iLock))
        Catch ex As Exception

        End Try

        Try
            Dim sDK As String
            If txtSearch.Text <> "" Then sDK = "MS_MAY like '%" + txtSearch.Text + "%' " Else sDK = ""
            TbTGNM.DefaultView.RowFilter = sDK
            TbTGNM = TbTGNM.DefaultView.ToTable()
        Catch ex As Exception
            TbTGNM.DefaultView.RowFilter = ""
        End Try


        txtHTuong.MaxLength = TbTGNM.Columns("HIEN_TUONG").MaxLength
        txtNguyennhan.MaxLength = TbTGNM.Columns("NN_CGQ").MaxLength
        txtNNCuThe.MaxLength = TbTGNM.Columns("NGUYEN_NHAN_CU_THE").MaxLength

        For Each Cl As DataColumn In TbTGNM.Columns
            Cl.AllowDBNull = True

        Next

        gvLanngungmay.DataSource = TbTGNM
        For Each GVCOL As DataGridViewColumn In gvLanngungmay.Columns
            GVCOL.Visible = False
        Next

        'gvLanngungmay.Columns("MS_PHIEU_BAO_TRI").Visible = False
        'gvLanngungmay.Columns("HIEN_TUONG").Visible = False
        ''gvLanngungmay.Columns("NGUYEN_NHAN_CU_THE").Visible = False

        gvLanngungmay.Columns("MS_MAY").Visible = True
        gvLanngungmay.Columns("NGAY").Visible = False
        gvLanngungmay.Columns("NGAY_KT").Visible = False
        gvLanngungmay.Columns("TU_GIO").Visible = False
        gvLanngungmay.Columns("GIO_KT").Visible = False

        gvLanngungmay.Columns("TNGAY_GIO").Visible = True
        gvLanngungmay.Columns("DNGAY_GIO").Visible = True
        gvLanngungmay.Columns("TNGAY_GIO").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        gvLanngungmay.Columns("DNGAY_GIO").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

        'gvLanngungmay.Columns("TU_GIO").DefaultCellStyle.Format = "HH:mm"
        'gvLanngungmay.Columns("GIO_KT").DefaultCellStyle.Format = "HH:mm"
        gvLanngungmay.Columns("MS_MAY").Width = 110
        gvLanngungmay.Columns("NGAY").Width = 85
        gvLanngungmay.Columns("NGAY_KT").Width = 85
        gvLanngungmay.Columns("TU_GIO").Width = 80
        gvLanngungmay.Columns("GIO_KT").Width = 80
        Try
            BindingControl()
            gvLanngungmay.AutoGenerateColumns = False
            'chitiet 
            Binddata()
        Catch ex As Exception

        End Try

        If gvLanngungmay.Rows.Count <> 0 Then
            lannm = gvLanngungmay.Rows(0).Cells("MS_LAN").Value.ToString
        Else
            lannm = "-1"
        End If
        getTGNM()
        Try
            getBoPhanTheoMay(gvLanngungmay.Rows(0).Index)
        Catch ex As Exception
            getBoPhanTheoMay("-1")

        End Try

        If gvThoigianngungmay.RowCount = 0 Then
            Try

                'LoadCT("-1", "01/01/1900", "00:00", "01/01/1900", "00:00")
            Catch ex As Exception

            End Try

        End If
        Me.gvLanngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
        Me.gvLanngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
    End Sub

    ' <summary> 
    ' Điều khiển form 
    ' </summary> 
    Private Sub InitializeForm()
        Try
            'cboNhaxuong.Enabled = False
            cboNguoiGiaiQuyet.Properties.ReadOnly = False
            cboTruongCa.Properties.ReadOnly = False

            txtTruongCa.ReadOnly = False
            txtNguoiGiaiQuyet.ReadOnly = False
            'btnNguoiGiaiQuyet.Enabled = True
            btnCa.Enabled = True
            cboCa.Enabled = True
            'btnTruongCa.Enabled = True
            txtNguyennhan.[ReadOnly] = False
            txtHTuong.ReadOnly = False
            txtNNCuThe.ReadOnly = False

            dtpGioBD.Enabled = False
            dtpNgaybatdau.Enabled = False
            dtpGioKT.Enabled = False
            dtpNgayKT.Enabled = False

            dtpNgaySX.Enabled = False

            cboLoaidungmay.Enabled = False
            cboMSMAY.Enabled = False
            cboLoaiTB.Enabled = True
            cboDiaDiem.Enabled = True
            cmbPhieuBaoTri.Enabled = False
            Select Case TrangThai
                Case "CT"
                    cboNguoiGiaiQuyet.Properties.ReadOnly = False
                    cboTruongCa.Properties.ReadOnly = False
                    txtTruongCa.ReadOnly = False
                    txtNguoiGiaiQuyet.ReadOnly = False
                    btnCa.Enabled = True
                    cboCa.Enabled = True
                    'btnNguoiGiaiQuyet.Enabled = True
                    'btnTruongCa.Enabled = True
                    txtNguyennhan.[ReadOnly] = False
                    txtHTuong.ReadOnly = False
                    txtNNCuThe.ReadOnly = False

                    txtSearch.ReadOnly = True
                    dtpGioBD.Enabled = True
                    dtpNgaybatdau.Enabled = True
                    dtpGioKT.Enabled = True
                    dtpNgayKT.Enabled = True

                    dtpNgaySX.Enabled = True

                    cboLoaidungmay.Enabled = True
                    cmbPhieuBaoTri.Enabled = True
                    cboMSMAY.Enabled = True
                    cboLoaiTB.Enabled = False
                    cboDiaDiem.Enabled = False
                    gvLanngungmay.[ReadOnly] = True
                    gvLanngungmay.Enabled = False

                    For Each ClLan As DataGridViewColumn In gvLanngungmay.Columns
                        ClLan.[ReadOnly] = True
                    Next
                    For Each ClTG As DataGridViewColumn In gvThoigianngungmay.Columns
                        ClTG.[ReadOnly] = True
                    Next

                    gvThoigianngungmay.Enabled = False
                    gvThoigianngungmay.[ReadOnly] = True
                    'gvThoigianngungmay.AllowUserToAddRows = False
                    'gvThoigianngungmay.AllowUserToDeleteRows = False


                    'grdCT.Enabled = True

                    'grvCT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
                    'grvCT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                    'grvCT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                    'grvCT.OptionsBehavior.Editable = True

                    btnAdd.Visible = False
                    btnThoat.Visible = False
                    btnAddPT.Visible = False
                    btnTroVe.Visible = False
                    btnXoaCTiet.Visible = False
                    btnXoaLanNgungMay.Visible = False
                    btnXoa.Visible = False
                    btnXoaBoPhan.Visible = False

                    btnKhongghi.Visible = True

                    btnEdit.Visible = False
                    'btnCT.Visible = False

                    'btnLoc.Visible = False
                    ''btnPrint.Visible = False
                    btnSave.Visible = True
                    btnTMay.Enabled = True
                    btnNNNM.Enabled = True
                    btnCapNhapTG.Visible = True
                    btnCopy.Visible = False
                    Exit Select

                Case "Add", "Edit"
                    'cboNhaxuong.Enabled = True
                    cboNguoiGiaiQuyet.Properties.ReadOnly = False
                    cboTruongCa.Properties.ReadOnly = False
                    txtTruongCa.ReadOnly = False
                    txtNguoiGiaiQuyet.ReadOnly = False
                    btnCa.Enabled = True
                    cboCa.Enabled = True
                    'btnNguoiGiaiQuyet.Enabled = True
                    'btnTruongCa.Enabled = True
                    txtNguyennhan.[ReadOnly] = False
                    txtHTuong.ReadOnly = False
                    txtNNCuThe.ReadOnly = False

                    txtSearch.ReadOnly = True
                    dtpGioBD.Enabled = True
                    dtpNgaybatdau.Enabled = True

                    dtpGioKT.Enabled = True
                    dtpNgayKT.Enabled = True

                    dtpNgaySX.Enabled = True

                    cboLoaidungmay.Enabled = True
                    cmbPhieuBaoTri.Enabled = True
                    cboMSMAY.Enabled = True
                    cboLoaiTB.Enabled = False
                    cboDiaDiem.Enabled = False
                    gvLanngungmay.[ReadOnly] = True
                    gvLanngungmay.Enabled = False

                    For Each ClLan As DataGridViewColumn In gvLanngungmay.Columns
                        ClLan.[ReadOnly] = True
                    Next
                    Try


                        gvLanngungmay.Columns("MS_MAY").[ReadOnly] = True
                        gvLanngungmay.Columns("MS_LAN").[ReadOnly] = True
                        gvLanngungmay.Columns("MS_LAN").Visible = False
                        gvLanngungmay.Columns("NGAY").[ReadOnly] = True
                        gvLanngungmay.Columns("TU_GIO").[ReadOnly] = True
                        gvLanngungmay.Columns("NGUOI_GIAI_QUYET").[ReadOnly] = True
                        gvLanngungmay.Columns("MS_NGUYEN_NHAN").[ReadOnly] = True
                        gvLanngungmay.Columns("TU_GIO").DefaultCellStyle.Format = "HH:mm"
                        gvLanngungmay.Columns("NGAY").DefaultCellStyle.Format = "dd/MM/yyyy"
                        gvLanngungmay.Columns("GIO_KT").DefaultCellStyle.Format = "HH:mm"
                        gvLanngungmay.Columns("NGAY_KT").DefaultCellStyle.Format = "dd/MM/yyyy"

                        gvLanngungmay.Columns("TNGAY_GIO").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                        gvLanngungmay.Columns("DNGAY_GIO").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"



                        gvThoigianngungmay.Enabled = True
                        gvThoigianngungmay.[ReadOnly] = False
                        'gvThoigianngungmay.AllowUserToAddRows = True
                        gvThoigianngungmay.AllowUserToDeleteRows = True
                        gvThoigianngungmay.Columns("NGAY").[ReadOnly] = False
                        gvThoigianngungmay.Columns("TU_GIO").[ReadOnly] = False
                        gvThoigianngungmay.Columns("DEN_NGAY").[ReadOnly] = False
                        gvThoigianngungmay.Columns("DEN_GIO").[ReadOnly] = False

                        'If Commons.Modules.sPrivate = "BARIA" Then
                        '    gvThoigianngungmay.Columns("THOI_GIAN_NGUNG_MAY").[ReadOnly] = False
                        'Else
                        gvThoigianngungmay.Columns("THOI_GIAN_NGUNG_MAY").[ReadOnly] = False
                        'End If
                        gvThoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").[ReadOnly] = False

                        gvThoigianngungmay.Columns("MS_N_XUONG").ReadOnly = True
                        gvThoigianngungmay.Columns("MS_HE_THONG").ReadOnly = False
                        gvThoigianngungmay.Columns("NGUOI_GIAI_QUYET").[ReadOnly] = False
                        gvThoigianngungmay.Columns("MS_NGUYEN_NHAN").ReadOnly = False
                        gvThoigianngungmay.Columns("GHI_CHU").[ReadOnly] = False
                        gvThoigianngungmay.Columns("NGUYEN_NHAN").[ReadOnly] = False
                        gvThoigianngungmay.Columns("NGUYEN_NHAN_CU_THE").[ReadOnly] = False
                        gvThoigianngungmay.Columns("HIEN_TUONG").[ReadOnly] = False

                    Catch ex As Exception

                    End Try

                    btnAdd.Visible = False
                    btnThoat.Visible = False
                    btnAddPT.Visible = False
                    btnNNNM.Enabled = True
                    btnKhongghi.Visible = True

                    btnTroVe.Visible = False
                    btnXoaCTiet.Visible = False
                    btnXoaLanNgungMay.Visible = False
                    btnXoa.Visible = False
                    btnXoaBoPhan.Visible = False

                    btnEdit.Visible = False
                    'btnCT.Visible = False

                    'btnLoc.Visible = False
                    ''btnPrint.Visible = False
                    btnSave.Visible = True
                    btnTMay.Enabled = True
                    btnCapNhapTG.Visible = True
                    btnCopy.Visible = False

                    Exit Select
                Case Else
                    cboNguoiGiaiQuyet.Properties.ReadOnly = True
                    cboTruongCa.Properties.ReadOnly = True
                    txtTruongCa.ReadOnly = True
                    txtNguoiGiaiQuyet.ReadOnly = True
                    'btnNguoiGiaiQuyet.Enabled = False
                    'btnTruongCa.Enabled = False
                    btnCa.Enabled = False
                    cboCa.Enabled = False
                    txtNguyennhan.[ReadOnly] = True
                    txtHTuong.ReadOnly = True
                    txtNNCuThe.ReadOnly = True
                    dtpGioBD.Enabled = False
                    dtpNgaybatdau.Enabled = False
                    dtpGioKT.Enabled = False
                    dtpNgayKT.Enabled = False

                    dtpNgaySX.Enabled = False

                    cboLoaidungmay.Enabled = False
                    cmbPhieuBaoTri.Enabled = False
                    cboMSMAY.Enabled = False
                    cboLoaiTB.Enabled = True
                    cboDiaDiem.Enabled = True

                    txtSearch.ReadOnly = False
                    'cboNhaxuong.Enabled = False
                    gvLanngungmay.[ReadOnly] = True
                    gvLanngungmay.Enabled = True

                    gvLanngungmay.AllowUserToAddRows = False
                    'gvLanngungmay.AllowUserToDeleteRows = False

                    For Each ClLan As DataGridViewColumn In gvLanngungmay.Columns
                        ClLan.[ReadOnly] = True
                    Next

                    Try
                        gvLanngungmay.Columns("MS_MAY").[ReadOnly] = True
                        gvLanngungmay.Columns("MS_LAN").[ReadOnly] = True
                        gvLanngungmay.Columns("MS_LAN").Visible = False
                        gvLanngungmay.Columns("NGAY").[ReadOnly] = True
                        gvLanngungmay.Columns("TU_GIO").[ReadOnly] = True
                        gvLanngungmay.Columns("NGUOI_GIAI_QUYET").[ReadOnly] = True
                        gvLanngungmay.Columns("MS_NGUYEN_NHAN").Visible = False
                        gvLanngungmay.Columns("MS_LOAI_MAY").Visible = False
                        gvLanngungmay.Columns("NGAY").DefaultCellStyle.Format = "dd/MM/yyyy"
                        gvLanngungmay.Columns("TU_GIO").DefaultCellStyle.Format = "HH:mm"

                        gvLanngungmay.Columns("TNGAY_GIO").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                        gvLanngungmay.Columns("DNGAY_GIO").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"


                    Catch ex As Exception

                    End Try
                    gvThoigianngungmay.Enabled = True
                    gvThoigianngungmay.[ReadOnly] = True
                    'gvThoigianngungmay.AllowUserToAddRows = False
                    'gvThoigianngungmay.AllowUserToDeleteRows = False
                    For Each ClThoigianngungmay As DataGridViewColumn In gvThoigianngungmay.Columns
                        ClThoigianngungmay.[ReadOnly] = True
                    Next

                    Try
                        'grdCT.Enabled = True
                        'grdCT.Enabled = True
                        'grvCT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                        'grvCT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                        'grvCT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                        'grvCT.OptionsBehavior.Editable = False
                        'For Each clCT As DataGridViewColumn In grvCT.Columns
                        '    clCT.ReadOnly = True
                        'Next
                    Catch ex As Exception

                    End Try

                    If Commons.Modules.PermisString.Equals("Read only") Then
                        btnAdd.Visible = False
                        btnNNNM.Enabled = False
                        btnCopy.Visible = False
                        btnThoat.Visible = True
                        btnKhongghi.Visible = False
                        btnAddPT.Visible = False

                        btnTroVe.Visible = False
                        btnXoaCTiet.Visible = False
                        btnXoaLanNgungMay.Visible = False
                        btnXoa.Visible = False
                        btnXoaBoPhan.Visible = False
                        btnEdit.Visible = False
                        'btnCT.Visible = False

                        'btnLoc.Visible = True
                        'btnPrint.Visible = True
                        btnSave.Visible = False
                        btnTMay.Enabled = False
                        btnCapNhapTG.Visible = False

                        If bLock Then btnLockTGNM.Visible = False
                        If bUnLock Then btnUnLockTGNM.Visible = False
                    Else
                        If chkIsLock.Checked = False Then
                            If (gvLanngungmay.Rows.Count <= 0) Then
                                btnAdd.Visible = True
                                btnAddPT.Visible = False
                                btnThoat.Visible = True
                                btnNNNM.Enabled = False
                                btnCopy.Visible = True
                                btnKhongghi.Visible = False

                                btnTroVe.Visible = False
                                btnXoaCTiet.Visible = False
                                btnXoaLanNgungMay.Visible = False
                                btnXoaBoPhan.Visible = False
                                btnXoa.Visible = True

                                btnEdit.Visible = False
                                'btnCT.Visible = False

                                'btnLoc.Visible = False
                                'btnPrint.Visible = False
                                btnSave.Visible = False
                                btnTMay.Enabled = False
                                btnCapNhapTG.Visible = False
                                btnCopy.Visible = False
                                If bLock Then btnLockTGNM.Visible = False
                                If bUnLock Then btnUnLockTGNM.Visible = False
                            Else
                                btnAdd.Visible = True
                                btnAddPT.Visible = True
                                btnThoat.Visible = True
                                btnNNNM.Enabled = False
                                btnCopy.Visible = True
                                btnKhongghi.Visible = False

                                btnTroVe.Visible = False
                                btnXoaCTiet.Visible = False
                                btnXoaLanNgungMay.Visible = False
                                btnXoaBoPhan.Visible = False
                                btnXoa.Visible = True


                                btnEdit.Visible = True
                                'btnCT.Visible = True

                                'btnLoc.Visible = True
                                'btnPrint.Visible = True
                                btnSave.Visible = False
                                btnTMay.Enabled = False
                                btnCapNhapTG.Visible = False
                                btnCopy.Visible = True
                                If bLock Then btnLockTGNM.Visible = True
                                If bUnLock Then btnUnLockTGNM.Visible = False

                            End If
                        Else
                            If (gvLanngungmay.Rows.Count <= 0) Then
                                btnAdd.Visible = False
                                btnAddPT.Visible = False
                                btnThoat.Visible = True
                                btnNNNM.Enabled = False
                                btnCopy.Visible = False
                                btnKhongghi.Visible = False
                                btnTroVe.Visible = False
                                btnXoaCTiet.Visible = False
                                btnXoaLanNgungMay.Visible = False
                                btnXoaBoPhan.Visible = False
                                btnXoa.Visible = False
                                btnEdit.Visible = False
                                'btnCT.Visible = False
                                'btnLoc.Visible = False
                                'btnPrint.Visible = False
                                btnSave.Visible = False
                                btnTMay.Enabled = False
                                btnCapNhapTG.Visible = False
                                btnCopy.Visible = False
                                If bLock Then btnLockTGNM.Visible = False
                                If bUnLock Then btnUnLockTGNM.Visible = False
                            Else
                                btnAdd.Visible = False
                                btnAddPT.Visible = False
                                btnThoat.Visible = True
                                btnNNNM.Enabled = False
                                btnCopy.Visible = False
                                btnKhongghi.Visible = False
                                btnTroVe.Visible = False
                                btnXoaCTiet.Visible = False
                                btnXoaLanNgungMay.Visible = False
                                btnXoaBoPhan.Visible = False
                                btnXoa.Visible = False
                                btnEdit.Visible = False
                                'btnCT.Visible = False
                                'btnLoc.Visible = False
                                'btnPrint.Visible = False
                                btnSave.Visible = False
                                btnTMay.Enabled = False
                                btnCapNhapTG.Visible = False
                                btnCopy.Visible = False
                                If bLock Then btnLockTGNM.Visible = False
                                If bUnLock Then btnUnLockTGNM.Visible = True
                            End If
                        End If
                    End If
                    Exit Select
            End Select
            If TrangThai = "Add" Then
                cboMSMAY.Enabled = True
            End If
            If TrangThai = "Edit" Then
                gvThoigianngungmay.Columns("MS_HE_THONG").ReadOnly = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub refresh1()
        txtSearch.Text = ""
        txtNguoiGiaiQuyet.Text = ""
        txtTruongCa.Text = ""
        txtNguyennhan.Text = ""
        txtHTuong.Text = ""
        txtNNCuThe.Text = ""
    End Sub

    ' <summary> 

    ' </summary> 
    Private Sub BindingControl()
        Try
            dtpNgaybatdau.DataBindings.Clear()
            dtpNgaybatdau.DataBindings.Add("Value", TbTGNM, "NGAY", True, DataSourceUpdateMode.OnPropertyChanged)

            dtpGioBD.DataBindings.Clear()
            dtpGioBD.DataBindings.Add("Value", TbTGNM, "TU_GIO", True, DataSourceUpdateMode.OnPropertyChanged)

            dtpNgayKT.DataBindings.Clear()
            dtpNgayKT.DataBindings.Add("Value", TbTGNM, "NGAY_KT", True, DataSourceUpdateMode.OnPropertyChanged)

            dtpGioKT.DataBindings.Clear()
            dtpGioKT.DataBindings.Add("Value", TbTGNM, "GIO_KT", True, DataSourceUpdateMode.OnPropertyChanged)

            dtpNgaySX.DataBindings.Clear()
            dtpNgaySX.DataBindings.Add("Value", TbTGNM, "NGAY_SX", True, DataSourceUpdateMode.OnPropertyChanged)

            cboLoaidungmay.DataBindings.Clear()
            cboLoaidungmay.DataBindings.Add("SelectedValue", TbTGNM, "MS_NGUYEN_NHAN", False, DataSourceUpdateMode.OnPropertyChanged)

            txtNguyennhan.DataBindings.Clear()
            txtNguyennhan.DataBindings.Add("Text", TbTGNM, "NN_CGQ", False, DataSourceUpdateMode.OnPropertyChanged)

            txtHTuong.DataBindings.Clear()
            txtHTuong.DataBindings.Add("Text", TbTGNM, "HIEN_TUONG", False, DataSourceUpdateMode.OnPropertyChanged)

            txtNNCuThe.DataBindings.Clear()
            txtNNCuThe.DataBindings.Add("Text", TbTGNM, "NGUYEN_NHAN_CU_THE", False, DataSourceUpdateMode.OnPropertyChanged)

            cboMSMAY.DataBindings.Clear()
            cboMSMAY.DataBindings.Add("SelectedValue", TbTGNM, "MS_MAY", False, DataSourceUpdateMode.OnPropertyChanged)

            cmbPhieuBaoTri.DataBindings.Clear()
            cmbPhieuBaoTri.DataBindings.Add("SelectedValue", TbTGNM, "MS_PHIEU_BAO_TRI", False, DataSourceUpdateMode.OnPropertyChanged)

            txtNguoiGiaiQuyet.DataBindings.Clear()
            txtNguoiGiaiQuyet.DataBindings.Add("Text", TbTGNM, "NGUOI_GIAI_QUYET", False, DataSourceUpdateMode.OnPropertyChanged)

            txtTruongCa.DataBindings.Clear()
            txtTruongCa.DataBindings.Add("Text", TbTGNM, "TRUONG_CA", False, DataSourceUpdateMode.OnPropertyChanged)




        Catch ex As Exception

        End Try

    End Sub

    Public Sub Binddata()
        Try
            gvThoigianngungmay.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            gvThoigianngungmay.DataSource = Nothing
        Catch ex As Exception
        End Try
        Try
            gvThoigianngungmay.Rows.Clear()
        Catch ex As Exception
        End Try

        gvThoigianngungmay.AutoGenerateColumns = False
        gvThoigianngungmay.DataSource = tbTG

        Dim col As New WareHouse.ColumnMaskedTextBoxLinksoft()
        col.Name = "NGAY"
        col.DataPropertyName = "NGAY"
        col.Mask = "00/00/0000"
        col.DefaultCellStyle.Format = Nothing
        gvThoigianngungmay.Columns.Insert(0, col)

        Dim col2 As New WareHouse.ColumnMaskedTextBoxLinksoft()
        col2.Name = "TU_GIO"
        col2.DataPropertyName = "TU_GIO"
        col2.Mask = "00:00"
        col2.DefaultCellStyle.Format = "HH:mm"
        col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col2.Width = 80
        gvThoigianngungmay.Columns.Insert(1, col2)

        Dim col11 As New WareHouse.ColumnMaskedTextBoxLinksoft()
        col11.Name = "DEN_NGAY"
        col11.DataPropertyName = "DEN_NGAY"
        col11.Mask = "00/00/0000"
        col11.DefaultCellStyle.Format = Nothing
        gvThoigianngungmay.Columns.Insert(2, col11)

        Dim col12 As New WareHouse.ColumnMaskedTextBoxLinksoft()
        col12.Name = "DEN_GIO"
        col12.DataPropertyName = "DEN_GIO"
        col12.Mask = "00:00"
        col12.DefaultCellStyle.Format = "HH:mm"
        col12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col12.Width = 80
        gvThoigianngungmay.Columns.Insert(3, col12)

        Dim col1 As New WareHouse.ColumnMaskedTextBoxLinksoft()
        col1.Name = "THOI_GIAN_NGUNG_MAY"
        col1.DataPropertyName = "THOI_GIAN_NGUNG_MAY"
        col1.DefaultCellStyle.Format = "N0"
        col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        col1.[ReadOnly] = True
        col1.Width = 80
        gvThoigianngungmay.Columns.Insert(4, col1)


        Dim col5 As New WareHouse.ColumnMaskedTextBoxLinksoft()
        col5.Name = "THOI_GIAN_SUA_CHUA"
        col5.DataPropertyName = "THOI_GIAN_SUA_CHUA"
        col5.DefaultCellStyle.Format = "N0"
        col5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        col5.Width = 80
        gvThoigianngungmay.Columns.Insert(5, col5)

        LoadNhaxuong()
        LoadDaychuyen()






        Try
            gvThoigianngungmay.Columns("MS_MAY").Visible = False
            gvThoigianngungmay.Columns("MS_LAN").Visible = False

        Catch ex As Exception

        End Try

        'gvThoigianngungmay.Columns("THOI_GIAN_NGUNG_MAY").ReadOnly = True






        For Each ClchiTiet As DataGridViewColumn In gvThoigianngungmay.Columns
            ClchiTiet.DataPropertyName = ClchiTiet.Name
            ClchiTiet.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        For Each Cl As DataColumn In tbTG.Columns
            Cl.AllowDBNull = True
        Next


        Dim colMsMay As New DataGridViewTextBoxColumn()
        colMsMay.Name = "MS_MAY"
        colMsMay.DataPropertyName = "MS_MAY"
        colMsMay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gvThoigianngungmay.Columns.Insert(8, colMsMay)
        colMsMay.Visible = False
        gvThoigianngungmay.Columns("MS_MAY").Visible = False


        Dim Sqlin As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "MS_NGUYEN_NHAN"
        comboBoxColumn.ValueMember = "MS_NGUYEN_NHAN"
        comboBoxColumn.DisplayMember = "TEN_NGUYEN_NHAN"
        comboBoxColumn.DataPropertyName = "MS_NGUYEN_NHAN"
        comboBoxColumn.DropDownWidth = 250
        Dim Tbndaychuyen As New System.Data.DataTable()
        Tbndaychuyen.Load(Sqlin.ExecuteReader(CommandType.Text, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"))
        comboBoxColumn.DataSource = Tbndaychuyen
        comboBoxColumn.MinimumWidth = 150
        comboBoxColumn.Width = 150
        gvThoigianngungmay.Columns.Insert(9, comboBoxColumn)

        Dim col23 As New DataGridViewTextBoxColumn()
        col23.Name = "NGUOI_GIAI_QUYET"
        col23.DataPropertyName = "NGUOI_GIAI_QUYET"
        col23.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col23.MinimumWidth = 150
        col23.Width = 150
        col23.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gvThoigianngungmay.Columns.Insert(10, col23)

        Dim col26 As New DataGridViewTextBoxColumn()
        col26.Name = "TRUONG_CA"
        col26.DataPropertyName = "TRUONG_CA"
        col26.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col26.MinimumWidth = 150
        col26.Width = 150
        col26.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gvThoigianngungmay.Columns.Insert(11, col26)


        comboBoxColumn = New DataGridViewComboBoxColumn()
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "CaID"
        comboBoxColumn.ValueMember = "STT"
        comboBoxColumn.DisplayMember = "CA"
        comboBoxColumn.DataPropertyName = "CaID"
        comboBoxColumn.DropDownWidth = 250
        TbCa = New System.Data.DataTable()
        TbCa.Load(Sqlin.ExecuteReader(CommandType.StoredProcedure, "Get_CA", Commons.Modules.TypeLanguage))
        comboBoxColumn.DataSource = TbCa
        comboBoxColumn.MinimumWidth = 150
        comboBoxColumn.Width = 150
        comboBoxColumn.ReadOnly = True
        gvThoigianngungmay.Columns.Insert(12, comboBoxColumn)




        col23 = New DataGridViewTextBoxColumn()
        col23.Name = "NGUYEN_NHAN_CU_THE"
        col23.DataPropertyName = "NGUYEN_NHAN_CU_THE"
        col23.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col23.MinimumWidth = 150
        col23.Width = 150
        'col22.ReadOnly = True 
        col23.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gvThoigianngungmay.Columns.Insert(13, col23)


        Dim col24 As New DataGridViewTextBoxColumn()
        col24.Name = "HIEN_TUONG"
        col24.DataPropertyName = "HIEN_TUONG"
        col24.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col24.MinimumWidth = 150
        col24.Width = 150
        'col22.ReadOnly = True 
        col24.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gvThoigianngungmay.Columns.Insert(14, col24)

        Dim col22 As New DataGridViewTextBoxColumn()
        col22.Name = "CACH_GIAI_QUYET"
        col22.DataPropertyName = "NN_CGQ"
        col22.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col22.MinimumWidth = 150
        col22.Width = 150
        'col22.ReadOnly = True 
        col22.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gvThoigianngungmay.Columns.Insert(15, col22)


        Dim col25 As New DataGridViewTextBoxColumn()
        col25.Name = "GHI_CHU"
        col25.DataPropertyName = "GHI_CHU"
        col25.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col25.MinimumWidth = 150
        col25.Width = 150
        'col25.ReadOnly = True 
        col25.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gvThoigianngungmay.Columns.Insert(16, col25)


        'RefeshLanguage()
        gvThoigianngungmay.Columns("MS_N_XUONG").Width = 140
        gvThoigianngungmay.Columns("MS_HE_THONG").Width = 160
        Try
            Me.gvThoigianngungmay.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("TU_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("DEN_NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("DEN_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("THOI_GIAN_NGUNG_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_NGUNG_MAY", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("CACH_GIAI_QUYET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CACH_GIAI_QUYET", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("NGUOI_GIAI_QUYET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("MS_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAY_CHUYEN", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("MS_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHA_XUONG", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("HIEN_TUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HIEN_TUONG", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("NGUYEN_NHAN_CU_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN_CU_THE", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("MS_NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("TRUONG_CA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTruongCa", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("CaID").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblCa", Commons.Modules.TypeLanguage)

            Me.gvThoigianngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.gvThoigianngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

        Catch ex As Exception

        End Try

    End Sub

    Private Function GetNN(ByVal dtNN As DataTable, ByVal sKeyWord As String) As String
        Dim sNN As String = ""
        Try
            sNN = CType(dtNN.Select("KEYWORD = '" & sKeyWord & "'"), DataRow())(0)(1).ToString()
        Catch ex As Exception
            sNN = ""
        End Try
        Return sNN

    End Function

    Private Sub RefeshLanguage1()
        Try

            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT KEYWORD , CASE " & Commons.Modules.TypeLanguage &
                    " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" & Me.Name & "' "))

            Me.gbLanngungmay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "gbLanNgungMay", Commons.Modules.TypeLanguage)
            Me.gbThoigiandungmay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "gbThoigianngungmay", Commons.Modules.TypeLanguage)
            Try
                Me.gvLanngungmay.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
                Me.gvLanngungmay.Columns("TU_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
                Me.gvLanngungmay.Columns("NGUOI_GIAI_QUYET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
                Me.gvLanngungmay.Columns("NN_CGQ").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NN_CGQ", Commons.Modules.TypeLanguage)
                Me.gvLanngungmay.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
                Me.gvLanngungmay.Columns("NGAY_KT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNKThuc", Commons.Modules.TypeLanguage)
                Me.gvLanngungmay.Columns("GIO_KT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_KT", Commons.Modules.TypeLanguage)

                gvLanngungmay.Columns("NGUYEN_NHAN_CU_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN_CU_THE", Commons.Modules.TypeLanguage)
                gvLanngungmay.Columns("TEN_NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage)

                Me.gvLanngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.gvLanngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception

            End Try

            Try
                Me.gvThoigianngungmay.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("TU_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("DEN_NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("DEN_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("THOI_GIAN_NGUNG_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_NGUNG_MAY", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("MS_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAY_CHUYEN", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("MS_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHA_XUONG", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("HIEN_TUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HIEN_TUONG", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("NGUYEN_NHAN_CU_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN_CU_THE", Commons.Modules.TypeLanguage)

                Me.gvThoigianngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.gvThoigianngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2


                Me.gvThoigianngungmay.Columns("NGAY").HeaderText = GetNN(dtTmp, "NGAY")


            Catch ex As Exception

            End Try


            'Try


            '    Me.grvCT.Columns("MS_NGUYEN_NHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN", Commons.Modules.TypeLanguage)
            '    Me.grvCT.Columns("MS_HE_THONG").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAY_CHUYEN", Commons.Modules.TypeLanguage)
            '    Me.grvCT.Columns("TU_NGAY_CT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            '    Me.grvCT.Columns("TU_GIO_CT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
            '    Me.grvCT.Columns("DEN_NGAY_CT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
            '    Me.grvCT.Columns("DEN_GIO_CT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
            '    Me.grvCT.Columns("THOI_GIAN_SUA_CHUA").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
            '    Me.grvCT.Columns("GHI_CHU").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)

            'Catch ex As Exception

            'End Try

            Me.lblLoaithietbi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAI_THIET_BI", Commons.Modules.TypeLanguage)
            Me.lblMSMAY.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_MAY", Commons.Modules.TypeLanguage)
            Me.lblNgaydau.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_DAU", Commons.Modules.TypeLanguage)
            Me.lblNguoigiaiquyet.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
            Me.lblNguyennhan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN", Commons.Modules.TypeLanguage)
            Me.lblPhieuBaoTri.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_BAO_TRI", Commons.Modules.TypeLanguage)
            Me.lblHienTuong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblHienTuong", Commons.Modules.TypeLanguage)
            Me.lblNNCuThe.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNNCuThe", Commons.Modules.TypeLanguage)
            Me.lblNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNgay", Commons.Modules.TypeLanguage)
            Me.lblNKThuc.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNKThuc", Commons.Modules.TypeLanguage)
            Me.lblTenMay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTenMay", Commons.Modules.TypeLanguage)
            Me.lblNgaySX.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblNgaySX", Commons.Modules.TypeLanguage)

            Me.lblNguyennhanvacachgiaiquyet.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CACH_GIAI_QUYET", Commons.Modules.TypeLanguage)
            Me.lblSearch.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SEARCH", Commons.Modules.TypeLanguage)
            'Me.lblTitle.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TUA_DE_FORM", Commons.Modules.TypeLanguage)
            Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TUA_DE_FORM", Commons.Modules.TypeLanguage)

            Me.btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thoat", Commons.Modules.TypeLanguage)
            Me.btnAdd.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Them", Commons.Modules.TypeLanguage)
            Me.btnEdit.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Sua", Commons.Modules.TypeLanguage)

            Me.btnSave.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Ghi", Commons.Modules.TypeLanguage)
            Me.btnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Khongghi", Commons.Modules.TypeLanguage)
            Me.btnNNNM.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NguyennhanNM", Commons.Modules.TypeLanguage)
            Me.btnPrint.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "In", Commons.Modules.TypeLanguage)
            'Me.btnLoc.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Loc", Commons.Modules.TypeLanguage)
            btnCopy.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Copy", Commons.Modules.TypeLanguage)

            Me.btnCapNhapTG.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnCapNhapTG", Commons.Modules.TypeLanguage)

            btnUnLockTGNM.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnUnLockTGNM", Commons.Modules.TypeLanguage)
            btnLockTGNM.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnLockTGNM", Commons.Modules.TypeLanguage)

            btnCT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "btnCT", Commons.Modules.TypeLanguage)
            chkIsLock.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "chkIsLock", Commons.Modules.TypeLanguage)
            'grdTGNMCT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "grdTGNMCT", Commons.Modules.TypeLanguage)
        Catch ex As Exception

        End Try
    End Sub

#Region "LoadCombobox"
    Private Sub LoadLoaidungmay()
        Try
            cboLoaidungmay.DataBindings.Clear()

            Dim SqlDeXuatMuaHang As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

            Dim Tb As New System.Data.DataTable()

            Tb.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text,
                "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"))
            cboLoaidungmay.DataSource = Tb
            cboLoaidungmay.ValueMember = "MS_NGUYEN_NHAN"

            cboLoaidungmay.DisplayMember = "TEN_NGUYEN_NHAN"

            cboLoaidungmay.DataBindings.Add("SelectedValue", TbTGNM, "MS_NGUYEN_NHAN", False, DataSourceUpdateMode.OnPropertyChanged)

        Catch

        End Try
    End Sub

    Private Sub LoadDaychuyen()

        Dim Sqlin As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "MS_HE_THONG"
        comboBoxColumn.ValueMember = "MS_HE_THONG"
        comboBoxColumn.DisplayMember = "TEN_HE_THONG"
        comboBoxColumn.DataPropertyName = "MS_HE_THONG"
        Dim Tbndaychuyen As New System.Data.DataTable()
        Tbndaychuyen.Load(Sqlin.ExecuteReader(CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG FROM DBO.HE_THONG ORDER BY TEN_HE_THONG"))
        Dim dtRow As DataRow
        If Tbndaychuyen.Rows.Count > 0 Then
            dtRow = Tbndaychuyen.NewRow()
            dtRow("MS_HE_THONG") = 0
            dtRow("TEN_HE_THONG") = "  "
            Tbndaychuyen.Rows.InsertAt(dtRow, 0)
        End If
        comboBoxColumn.DataSource = Tbndaychuyen
        gvThoigianngungmay.Columns.Insert(7, comboBoxColumn)
    End Sub

    Private Sub LoadNhaxuong()
        Dim Sqlin As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "MS_N_XUONG"
        comboBoxColumn.ValueMember = "MS_N_XUONG"
        comboBoxColumn.DisplayMember = "Ten_N_XUONG"
        comboBoxColumn.DataPropertyName = "MS_N_XUONG"
        Dim Tbndaychuyen As New System.Data.DataTable()
        Tbndaychuyen.Load(Sqlin.ExecuteReader(CommandType.Text, "SELECT MS_N_XUONG,TEN_N_XUONG FROM NHA_XUONG"))
        comboBoxColumn.DataSource = Tbndaychuyen
        gvThoigianngungmay.Columns.Insert(6, comboBoxColumn)
    End Sub

    Private Sub LoadLoaithietbi()
        Dim Sqlin As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

        Dim Tbloaimay As New System.Data.DataTable()
        Tbloaimay.Load(Sqlin.ExecuteReader(CommandType.StoredProcedure, "GetLOAI_MAY_SEC", Commons.Modules.UserName))
        Dim dtRow As DataRow
        Dim _itemAll As String = " < ALL > "
        If Tbloaimay.Rows.Count > 0 Then
            dtRow = Tbloaimay.NewRow()
            dtRow("MS_LOAI_MAY") = -1
            dtRow("TEN_LOAI_MAY") = _itemAll
            Tbloaimay.Rows.InsertAt(dtRow, 0)
        End If
        cboLoaiTB.ValueMember = "MS_LOAI_MAY"
        cboLoaiTB.DisplayMember = "TEN_LOAI_MAY"
        cboLoaiTB.DataSource = Tbloaimay
    End Sub

    Private Sub LoadDiaDiem()
        Dim Sqlin As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

        Dim Tbloaimay As New System.Data.DataTable()
        Tbloaimay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", Commons.Modules.UserName, "-1", "-1", "-1"))

        'Dim dtRow As DataRow
        'Dim _itemAll As String = " < ALL > "
        'If Tbloaimay.Rows.Count > 0 Then
        '    dtRow = Tbloaimay.NewRow()
        '    dtRow("MS_LOAI_MAY") = -1
        '    dtRow("TEN_LOAI_MAY") = _itemAll
        '    Tbloaimay.Rows.InsertAt(dtRow, 0)
        'End If
        cboDiaDiem.ValueMember = "MS_N_XUONG"
        cboDiaDiem.DisplayMember = "TEN_N_XUONG"
        cboDiaDiem.DataSource = Tbloaimay
    End Sub

    Private Sub LoadPhieuBaoTri(ByVal MS_MAY As String)
        Try

            cmbPhieuBaoTri.DataBindings.Clear()
            Dim tbPhieuBaoTri As New System.Data.DataTable()
            'tbPhieuBaoTri.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRIs_MOI", MS_MAY))
            Dim query As String = "SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  dbo.PHIEU_BAO_TRI  WHERE  MS_MAY = '" & MS_MAY & "' AND  NGAY_BD_KH >= '" & dtpNgaybatdau.Value.ToString("yyyyMMdd") & "' UNION SELECT '' AS MS_PHIEU_BAO_TRI  "
            tbPhieuBaoTri.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, query))


            cmbPhieuBaoTri.DataSource = tbPhieuBaoTri
            cmbPhieuBaoTri.DisplayMember = "MS_PHIEU_BAO_TRI"
            cmbPhieuBaoTri.ValueMember = "MS_PHIEU_BAO_TRI"
            cmbPhieuBaoTri.DataBindings.Add("SelectedValue", TbTGNM, "MS_PHIEU_BAO_TRI", False, DataSourceUpdateMode.OnPropertyChanged)
        Catch
        End Try
    End Sub

    Private Sub LoadMay()
        Try

            Dim Sql As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
            Dim tbMay As New System.Data.DataTable()
            tbMay.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "GetTHIET_BIs", Commons.Modules.UserName))

            Dim dtRow As DataRow
            dtRow = tbMay.NewRow()
            dtRow("MS_MAY") = ""
            dtRow("TEN_MAY") = ""
            tbMay.Rows.InsertAt(dtRow, 0)

            cboMSMAY.DataSource = tbMay
            cboMSMAY.DisplayMember = "TEN_MAY"
            cboMSMAY.ValueMember = "MS_MAY"

        Catch
        End Try
    End Sub

#End Region

#Region "Event"
    Private Sub btnThoat_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        chkIsLock.Enabled = False
        dtpTNgayLoc.Enabled = False
        dtpDNgayLoc.Enabled = False
        cboLoaiTB.Enabled = False
        cboDiaDiem.Enabled = False
        Try
            Dim dt As New DataTable()
            dt = CType(grdPhuTungtheoMay.DataSource, DataTable)
            dt.Rows.Clear()
            grdPhuTungtheoMay.DataSource = dt

        Catch ex As Exception

        End Try
        Add()
        cboMSMAY.Focus()
    End Sub

    Private Sub Add()
        Dim SqlDonDatHang As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
        Try
            If (gvLanngungmay.Rows.Count > 0) Then
                If gvLanngungmay.CurrentRow Is Nothing Then
                    index = -1
                Else
                    index = gvLanngungmay.CurrentRow.Index
                End If

            Else
                index = -1
            End If
            TrangThai = "Add"
            InitializeForm()
            refresh1()
            dtpNgaybatdau.Value = DateTime.Now
            dtpGioBD.Value = DateTime.Now

            dtpNgayKT.Value = DateTime.Now
            dtpGioKT.Value = DateTime.Now.AddHours(1)

            dtpNgaySX.Value = DateTime.Now
            Dim row As DataRow = TbTGNM.NewRow()
            lannm = Vietsoft.Information.GetID("LAN")
            row("MS_LAN") = lannm
            row("TNGAY_GIO") = Convert.ToDateTime(New DateTime(dtpNgaybatdau.Value.Year, dtpNgaybatdau.Value.Month, dtpNgaybatdau.Value.Day, dtpGioBD.Value.Hour, dtpGioBD.Value.Minute, 0)).ToString("dd/MM/yyyy HH:mm")
            row("DNGAY_GIO") = Convert.ToDateTime(New DateTime(dtpNgayKT.Value.Year, dtpNgayKT.Value.Month, dtpNgayKT.Value.Day, dtpGioKT.Value.Hour, dtpGioKT.Value.Minute, 0)).ToString("dd/MM/yyyy HH:mm")
            TbTGNM.Rows.Add(row)


            For r As Integer = 0 To gvLanngungmay.Rows.Count - 1
                If gvLanngungmay.Rows(r).Cells("MS_LAN").Value = lannm Then
                    gvLanngungmay.Rows(r).Cells(0).Selected = True
                    Exit For
                End If
            Next


            tbTG.Clear()
            gvThoigianngungmay.DataSource = tbTG

            cboMSMAY.SelectedIndex = 0
            cboLoaidungmay.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click
        Try
            chkIsLock.Enabled = False
            dtpTNgayLoc.Enabled = False
            dtpDNgayLoc.Enabled = False
            cboLoaiTB.Enabled = False
            cboDiaDiem.Enabled = False
            If gvLanngungmay.Rows.Count > 0 Then
                TrangThai = "Edit"
                If gvLanngungmay.CurrentRow Is Nothing Then
                    index = -1
                Else
                    index = gvLanngungmay.CurrentRow.Index
                End If
                InitializeForm()
            Else
                Vietsoft.Information.MsgBox(Me, "MsgKhongcodulieu", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        Catch ex As Exception
            Vietsoft.Information.MsgBox(Me, "MsgKhongcodulieu", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
        cboMSMAY.Enabled = False
        btnTMay.Enabled = False

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Validate()
        Dim SqlTbTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
        Dim Sql As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
        Dim sStr As String
        Dim sBTCT As String
        sBTCT = "TGNMCT" & Commons.Modules.UserName
        Dim sBTLan As String = "TGNMLAN" + Commons.Modules.UserName
        Dim sBTCTiet As String = "TGNMCT" + Commons.Modules.UserName
        Try
            If cboMSMAY.Text = "" OrElse cboMSMAY.Equals(DBNull.Value) OrElse cboMSMAY.SelectedIndex < 0 Then
                Vietsoft.Information.MsgBox(Me, "MsgMAYNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cboMSMAY.Focus()
                Exit Sub
            End If

            If cboLoaidungmay.Text = "" OrElse cboLoaidungmay.Equals(DBNull.Value) Then
                Vietsoft.Information.MsgBox(Me, "MsgNguyenNhanNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cboLoaidungmay.Focus()
                Exit Sub
            End If

            Try
                Dim value As String = ""
                Try
                    value = cmbPhieuBaoTri.SelectedValue
                Catch ex As Exception

                End Try
                If value = "" And cmbPhieuBaoTri.Text <> "" Then
                    Vietsoft.Information.MsgBox(Me, "MsgPhieuBaoTri", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    cmbPhieuBaoTri.Focus()
                    Exit Sub
                End If

            Catch ex As Exception

            End Try


            Dim ngay As DateTime = dtpNgaybatdau.Value
            Dim gio As DateTime = dtpGioBD.Value
            Dim NgayKT As DateTime = dtpNgayKT.Value
            Dim GioKT As DateTime = dtpGioKT.Value
            Dim NgaySX As DateTime = dtpNgaySX.Value

            ngay = New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)
            NgayKT = New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)

            Dim msMay As String = cboMSMAY.SelectedValue.ToString()

            Dim LoaiNM As String = cboLoaidungmay.SelectedValue.ToString()

            Dim PhieuBaoTri As String = ""
            Try
                PhieuBaoTri = cmbPhieuBaoTri.SelectedValue.ToString()
            Catch ex As Exception
            End Try

            Dim CA As String = "-1"
            Try
                CA = cboCa.SelectedValue
            Catch ex As Exception
            End Try


            Dim nguoiGQ As String = txtNguoiGiaiQuyet.Text.Trim()
            Dim nguyennhan As String = txtNguyennhan.Text.Trim()
            Dim hientuong As String = txtHTuong.Text.Trim()
            Dim NNCuThe As String = txtNNCuThe.Text.Trim()


            If gvThoigianngungmay.Rows.Count = 0 Then
                Vietsoft.Information.MsgBox(Me, "MsgThoigianngungmaynull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            Try
                tbTG = New DataTable
                tbTG = CType(gvThoigianngungmay.DataSource, DataTable)
                tbTG.DefaultView.Sort = "NGAY ASC, TU_GIO ASC"
                gvThoigianngungmay.DataSource = tbTG.DefaultView.ToTable
            Catch ex As Exception

            End Try


            'Kiểm hợp lệ chi tiết
            For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
                Dim vtungay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("NGAY").Value.ToString)
                Dim vdenngay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_NGAY").Value.ToString)
                Dim vtugio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("TU_GIO").Value.ToString)
                Dim vdengio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_GIO").Value.ToString)
                Dim vngaytruoc As DateTime = ngay, vgiotruoc As DateTime = gio

                If gvThoigianngungmay.Rows(i).Cells("MS_HE_THONG").Value.ToString = "" Or gvThoigianngungmay.Rows(i).Cells("MS_HE_THONG").Value.ToString = "0" Then
                    Vietsoft.Information.MsgBox(Me, "ChuaNhapHThong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    gvThoigianngungmay.Rows(i).Selected = True
                    Exit Sub
                End If

                If gvThoigianngungmay.Rows(i).Cells("MS_N_XUONG").Value.ToString = "" Then
                    Vietsoft.Information.MsgBox(Me, "ChuaNhapNhaXuong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    gvThoigianngungmay.Rows(i).Selected = True
                    Exit Sub
                End If

                If gvThoigianngungmay.Rows(i).Cells("MS_NGUYEN_NHAN").Value.ToString = "" Then
                    Vietsoft.Information.MsgBox(Me, "ChuaNhapMS_NNHAN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    gvThoigianngungmay.Rows(i).Selected = True
                    Exit Sub
                End If


                If i > 0 Then
                    vngaytruoc = DateTime.Parse(gvThoigianngungmay.Rows(i - 1).Cells("DEN_NGAY").Value.ToString)
                    vgiotruoc = DateTime.Parse(gvThoigianngungmay.Rows(i - 1).Cells("DEN_GIO").Value.ToString)

                    vngaytruoc = New DateTime(vngaytruoc.Year, vngaytruoc.Month, vngaytruoc.Day, vgiotruoc.Hour, vgiotruoc.Minute, 0)
                End If

                vtungay = New DateTime(vtungay.Year, vtungay.Month, vtungay.Day, vtugio.Hour, vtugio.Minute, 0)
                vdenngay = New DateTime(vdenngay.Year, vdenngay.Month, vdenngay.Day, vdengio.Hour, vdengio.Minute, 0)

                'If vngaytruoc > vtungay Then
                '    Vietsoft.Information.MsgBox(Me, "MsgNgaynhapkhongdung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    gvThoigianngungmay.Rows(i).Selected = True
                '    Exit Sub
                'Else
                If vtungay > vdenngay Then
                    Vietsoft.Information.MsgBox(Me, "MsgTungayphainhohondenngay", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If (vtungay.Date = vdenngay.Date) Then
                        gvThoigianngungmay.ClearSelection()
                        gvThoigianngungmay.Rows(i).Cells("TU_GIO").Selected = True
                        gvThoigianngungmay.Rows(i).Cells("DEN_GIO").Selected = True

                    Else
                        gvThoigianngungmay.Rows(i).Selected = True

                    End If
                    Exit Sub
                End If

                Dim stime As Integer = (vdenngay - vtungay).Days * 24 * 60 + (vdenngay - vtungay).Hours * 60 + (vdenngay - vtungay).Minutes
                If stime <= 0 Then
                    Vietsoft.Information.MsgBox(Me, "MsgTungayphainhohondenngay", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    'tbTG.RejectChanges(); 
                    If (vtungay.Date = vdenngay.Date) Then
                        gvThoigianngungmay.ClearSelection()
                        gvThoigianngungmay.Rows(i).Cells("TU_GIO").Selected = True
                        gvThoigianngungmay.Rows(i).Cells("DEN_GIO").Selected = True

                    Else
                        gvThoigianngungmay.Rows(i).Selected = True
                    End If
                    Exit Sub
                End If
                If stime > 1440 Then
                    Vietsoft.Information.MsgBox(Me, "MsgThoigianphainhohon24h", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    'gvThoigianngungmay.Focus(); 
                    gvThoigianngungmay.Rows(i).Selected = True
                    Exit Sub
                End If

                For Each row As DataGridViewRow In gvThoigianngungmay.Rows
                    Dim dtungay As DateTime = DateTime.Parse(row.Cells("NGAY").Value.ToString())
                    Dim ddenngay As DateTime = DateTime.Parse(row.Cells("DEN_NGAY").Value.ToString())
                    Dim dtugio As DateTime = DateTime.Parse(row.Cells("TU_GIO").Value.ToString())
                    Dim ddengio As DateTime = DateTime.Parse(row.Cells("DEN_GIO").Value.ToString())
                    dtungay = New DateTime(dtungay.Year, dtungay.Month, dtungay.Day, dtugio.Hour, dtugio.Minute, 0)
                    ddenngay = New DateTime(ddenngay.Year, ddenngay.Month, ddenngay.Day, ddengio.Hour, ddengio.Minute, 0)
                    If (i = gvThoigianngungmay.Rows.IndexOf(row)) Then
                        Exit For
                    Else
                        If vdenngay <= dtungay Or vtungay >= ddenngay Then
                        Else
                            Vietsoft.Information.MsgBox(Me, "msgMaydangdungtaithoidiemnay", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            gvThoigianngungmay.ClearSelection()
                            gvThoigianngungmay.Rows(If(i = 0, 0, i - 1)).Selected = True
                            gvThoigianngungmay.Rows(i).Selected = True
                            Exit Sub
                        End If
                    End If
                Next
                Dim kiemtralan As DataTable
                kiemtralan = New System.Data.DataTable()

                If TrangThai = "Edit" Then
                    lannm = gvLanngungmay.SelectedRows(0).Cells("MS_LAN").Value.ToString()
                    kiemtralan.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "KIEM_TRA_TGNM", msMay, lannm))
                Else
                    kiemtralan.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "KIEM_TRA_TGNM", msMay, "-1"))
                End If

                If kiemtralan.Rows.Count > 0 Then
                    For Each row As DataRow In kiemtralan.Rows
                        Dim dtungay As DateTime = DateTime.Parse(row("NGAY").ToString())
                        Dim ddenngay As DateTime = DateTime.Parse(row("DEN_NGAY").ToString())
                        Dim dtugio As DateTime = DateTime.Parse(row("TU_GIO").ToString())
                        Dim ddengio As DateTime = DateTime.Parse(row("DEN_GIO").ToString())
                        dtungay = New DateTime(dtungay.Year, dtungay.Month, dtungay.Day, dtugio.Hour, dtugio.Minute, 0)
                        ddenngay = New DateTime(ddenngay.Year, ddenngay.Month, ddenngay.Day, ddengio.Hour, ddengio.Minute, 0)
                        If vdenngay <= dtungay Or vtungay >= ddenngay Then

                        Else
                            Vietsoft.Information.MsgBox(Me, "msgMaydangdungtaithoidiemnay", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            gvThoigianngungmay.Rows(i).Selected = True
                            Exit Sub
                        End If
                    Next
                End If




            Next

            '---------------Kiểm min max time chi tiết so với time cha

            Dim tNgayChiTietMin As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(0).Cells("NGAY").Value.ToString)
            Dim tGioChiTietMin As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(0).Cells("TU_GIO").Value.ToString)

            Dim dNgayChiTietMax As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(gvThoigianngungmay.RowCount - 1).Cells("DEN_NGAY").Value.ToString)
            Dim dGioChiTietMax As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(gvThoigianngungmay.RowCount - 1).Cells("DEN_GIO").Value.ToString)

            tNgayChiTietMin = New DateTime(tNgayChiTietMin.Year, tNgayChiTietMin.Month, tNgayChiTietMin.Day, tGioChiTietMin.Hour, tGioChiTietMin.Minute, 0)
            dNgayChiTietMax = New DateTime(dNgayChiTietMax.Year, dNgayChiTietMax.Month, dNgayChiTietMax.Day, dGioChiTietMax.Hour, dGioChiTietMax.Minute, 0)


            Dim tNgayCha As New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)
            Dim dNgayCha As New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)
            'Kiểm ngày giờ min của chi tiết so với ngày giờ bắt đầu của bảng cha

            Dim count As Integer = 0

            If tNgayCha <> tNgayChiTietMin Then
                If Vietsoft.Information.MsgBox(Me, "msgNgayChaMinKhacNgayChiTiet", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    count = count + 1
                Else
                    Exit Sub
                End If
            End If


            If count = 0 Then
                If dNgayCha <> dNgayChiTietMax Then
                    If Vietsoft.Information.MsgBox(Me, "msgNgayChaMinKhacNgayChiTiet", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                        count = count + 1
                    Else
                        Exit Sub
                    End If
                End If
            End If


            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTLan, CType(gvThoigianngungmay.DataSource, DataTable), "")
            SqlTbTGNM.BeginTransaction()
            Dim tlan As String = ""
            Dim sqlLan As String = "SELECT MS_LAN FROM THOI_GIAN_NGUNG_MAY_SO_LAN WHERE MS_MAY=N'" + msMay + "' AND NGAY='" + ngay.ToString("MM/dd/yyyy") + "' AND TU_GIO='" + gio.ToString("hh:mm") & "'"
            tlan = SqlTbTGNM.ExecuteNonQuery(CommandType.Text, sqlLan)
            If tlan <> "-1" And tlan <> "" Then
                Vietsoft.Information.MsgBox(Me, "Msgthietbinaydangduocsua", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cboMSMAY.Focus()
                Exit Sub
            End If

            Select Case TrangThai
                Case "Add"
                    Dim result As Integer = 0
                    If lannm <> "" Then

                        result = SqlTbTGNM.ExecuteNonQuery(CommandType.StoredProcedure, "AddTHOI_GIAN_NGUNG_MAY_LAN",
                                lannm, msMay, tNgayChiTietMin.ToShortDateString(), tGioChiTietMin.ToShortTimeString(), nguoiGQ, nguyennhan, hientuong, NNCuThe _
                                , dNgayChiTietMax.ToShortDateString(), dGioChiTietMax.ToShortTimeString(), NgaySX.ToShortDateString(), txtTruongCa.Text.Trim, Convert.ToInt32(CA), LoaiNM, PhieuBaoTri)
                        If result > 0 Then
                            If lannm <> "" Then
                                For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
                                    Dim vtungay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("NGAY").Value.ToString)
                                    Dim vdenngay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_NGAY").Value.ToString)
                                    Dim vtugio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("TU_GIO").Value.ToString)
                                    Dim vdengio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_GIO").Value.ToString)
                                    Dim daychuyen As String = gvThoigianngungmay.Rows(i).Cells("MS_HE_THONG").Value.ToString
                                    Dim hethong As String = gvThoigianngungmay.Rows(i).Cells("MS_N_XUONG").Value.ToString
                                    Dim msNguyenNhan As String = gvThoigianngungmay.Rows(i).Cells("MS_NGUYEN_NHAN").Value.ToString

                                    Dim vghichu As String
                                    Try
                                        vghichu = gvThoigianngungmay.Rows(i).Cells("GHI_CHU").Value.ToString
                                    Catch ex As Exception
                                        vghichu = ""
                                    End Try
                                    Dim vthoigianngungmay As String = gvThoigianngungmay.Rows(i).Cells("THOI_GIAN_NGUNG_MAY").Value.ToString
                                    Dim vthoigiansua As String = gvThoigianngungmay.Rows(i).Cells("THOI_GIAN_SUA_CHUA").Value.ToString
                                    Dim CA1 As Integer = -1
                                    Try
                                        CA1 = If(String.IsNullOrEmpty(gvThoigianngungmay.Rows(i).Cells("CaID").Value.ToString), -1, gvThoigianngungmay.Rows(i).Cells("CaID").Value.ToString)
                                    Catch ex As Exception

                                    End Try

                                    result = SqlTbTGNM.ExecuteNonQuery(CommandType.StoredProcedure, "AddTHOI_GIAN_NGUNG_MAY_THEO_LAN", msMay, lannm, vtungay.ToShortDateString(), vtugio.ToShortTimeString(),
                                        vdenngay.ToShortDateString(), vdengio.ToShortTimeString(), msNguyenNhan, vghichu, daychuyen,
                                        vthoigianngungmay, hethong, vthoigiansua, gvThoigianngungmay.Rows(i).Cells("CACH_GIAI_QUYET").Value.ToString, gvThoigianngungmay.Rows(i).Cells("HIEN_TUONG").Value.ToString, gvThoigianngungmay.Rows(i).Cells("NGUYEN_NHAN_CU_THE").Value.ToString, gvThoigianngungmay.Rows(i).Cells("NGUOI_GIAI_QUYET").Value.ToString,
                                                                       gvThoigianngungmay.Rows(i).Cells("TRUONG_CA").Value.ToString, CA1)
                                Next
                            End If
                        End If
                    End If
                    Exit Select
                Case "Edit"
                    lannm = gvLanngungmay.SelectedRows(0).Cells("MS_LAN").Value.ToString()
                    Dim result As Integer = 0


                    result = SqlTbTGNM.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateTHOI_GIAN_NGUNG_MAY_LAN",
                            msMay, lannm, tNgayChiTietMin.ToShortDateString(), tGioChiTietMin.ToShortTimeString(), nguoiGQ, nguyennhan,
                            hientuong, NNCuThe, dNgayChiTietMax.ToShortDateString(), dGioChiTietMax.ToShortTimeString(), NgaySX.ToShortDateString(), txtTruongCa.Text, If(CA = Nothing, -1, CA), PhieuBaoTri, LoaiNM)
                    If result > 0 Then

                        If lannm <> "" Then
                            sStr = "DELETE THOI_GIAN_NGUNG_MAY WHERE MS_LAN = '" & lannm & "'"
                            SqlTbTGNM.ExecuteNonQuery(CommandType.Text, sStr)
                        End If

                        sStr = " INSERT INTO THOI_GIAN_NGUNG_MAY (MS_MAY,NGAY,TU_GIO,DEN_NGAY,DEN_GIO,MS_NGUYEN_NHAN, " &
                                        " GHI_CHU,MS_HE_THONG,  " &
                                        " THOI_GIAN_SUA_CHUA,MS_N_XUONG,MS_LAN, THOI_GIAN_SUA,HIEN_TUONG, NGUYEN_NHAN, NGUYEN_NHAN_CU_THE, NGUOI_GIAI_QUYET, TRUONG_CA, CaID) " &
                                        " SELECT '" + msMay + "' AS  MS_MAY,NGAY,TU_GIO,DEN_NGAY,DEN_GIO, MS_NGUYEN_NHAN, " &
                                        " GHI_CHU,MS_HE_THONG,  " &
                                        " THOI_GIAN_NGUNG_MAY,MS_N_XUONG, '" + lannm + "' AS MS_LAN, THOI_GIAN_SUA_CHUA,HIEN_TUONG, NN_CGQ, NGUYEN_NHAN_CU_THE, NGUOI_GIAI_QUYET, TRUONG_CA, CaID FROM " & sBTLan
                        Try
                            SqlTbTGNM.ExecuteNonQuery(CommandType.Text, sStr)

                        Catch ex As Exception

                        End Try
                    End If
                    Exit Select
            End Select
            SqlTbTGNM.CommitTransaction()
            TbTGNM.AcceptChanges()
            Commons.Modules.ObjSystems.XoaTable(sBTLan)



        Catch ex1 As Exception
            Try
                SqlTbTGNM.RollbackTransaction()
            Catch ex As Exception

            End Try

            Vietsoft.Information.MsgBox(Me, "MsgKhongtheluu" & " - " & ex1.Message, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            gvThoigianngungmay.Focus()
            Commons.Modules.ObjSystems.XoaTable(sBTCT)
            Commons.Modules.ObjSystems.XoaTable(sBTLan)

            Exit Sub
        End Try
        Dim ms_lan As String = lannm
        dtpTNgayLoc.Enabled = True
        dtpDNgayLoc.Enabled = True
        cboLoaiTB.Enabled = True
        cboDiaDiem.Enabled = True

        chkIsLock.Enabled = True

        InitializeDatabase()
        InitializeForm()
        btnAddPT.Visible = True
        btnAdd.Visible = True
        btnXoa.Visible = True
        btnThoat.Visible = True
        btnCopy.Visible = True
        btnEdit.Visible = True
        btnCapNhapTG.Visible = False
        btnSave.Visible = False
        btnKhongghi.Visible = False
        txtNguyennhan.[ReadOnly] = True
        cboNguoiGiaiQuyet.Properties.ReadOnly = True
        cboTruongCa.Properties.ReadOnly = True
        txtTruongCa.ReadOnly = True
        txtNguoiGiaiQuyet.ReadOnly = True
        txtHTuong.ReadOnly = True
        txtNNCuThe.ReadOnly = True
        dtpGioBD.Enabled = False
        dtpNgaybatdau.Enabled = False
        dtpGioKT.Enabled = False
        dtpNgayKT.Enabled = False

        dtpNgaySX.Enabled = False

        cboLoaidungmay.Enabled = False
        cmbPhieuBaoTri.Enabled = False
        cboMSMAY.Enabled = False
        cboLoaiTB.Enabled = True
        cboDiaDiem.Enabled = True

        txtSearch.ReadOnly = False
        gvLanngungmay.[ReadOnly] = True
        gvLanngungmay.Enabled = True

        gvLanngungmay.AllowUserToAddRows = False

        For Each ClLan As DataGridViewColumn In gvLanngungmay.Columns
            ClLan.[ReadOnly] = True
        Next

        Try
            gvLanngungmay.Columns("MS_MAY").[ReadOnly] = True
            gvLanngungmay.Columns("MS_LAN").[ReadOnly] = True
            gvLanngungmay.Columns("MS_LAN").Visible = False
            gvLanngungmay.Columns("NGAY").[ReadOnly] = True
            gvLanngungmay.Columns("TU_GIO").[ReadOnly] = True
            gvLanngungmay.Columns("NGUOI_GIAI_QUYET").[ReadOnly] = True
            gvLanngungmay.Columns("MS_NGUYEN_NHAN").Visible = False
            gvLanngungmay.Columns("MS_LOAI_MAY").Visible = False
            gvLanngungmay.Columns("NGAY").DefaultCellStyle.Format = "dd/MM/yyyy"
            gvLanngungmay.Columns("TU_GIO").DefaultCellStyle.Format = "HH:mm"
        Catch ex As Exception

        End Try
        gvThoigianngungmay.Enabled = True
        gvThoigianngungmay.[ReadOnly] = True
        For Each ClThoigianngungmay As DataGridViewColumn In gvThoigianngungmay.Columns
            ClThoigianngungmay.[ReadOnly] = True
        Next
        Commons.Modules.ObjSystems.XoaTable(sBTCT)
        Commons.Modules.ObjSystems.XoaTable(sBTLan)

        Try
            Me.gvThoigianngungmay.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("TU_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("DEN_NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("DEN_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("THOI_GIAN_NGUNG_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_NGUNG_MAY", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("CACH_GIAI_QUYET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CACH_GIAI_QUYET", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("MS_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAY_CHUYEN", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("MS_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHA_XUONG", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("HIEN_TUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HIEN_TUONG", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("NGUYEN_NHAN_CU_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN_CU_THE", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("MS_NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("NGUOI_GIAI_QUYET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("TRUONG_CA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTruongCa", Commons.Modules.TypeLanguage)
            Me.gvThoigianngungmay.Columns("CaID").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblCa", Commons.Modules.TypeLanguage)





            Me.gvThoigianngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.gvThoigianngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

        Catch ex As Exception

        End Try

        TrangThai = ""
        For i As Integer = 0 To gvLanngungmay.Rows.Count - 1
            If gvLanngungmay.Rows(i).Cells("MS_LAN").Value = ms_lan Then
                gvLanngungmay.Rows(i).Cells("MS_MAY").Selected = True
                gvLanngungmay.CurrentCell = gvLanngungmay.Rows(i).Cells("MS_MAY")
                gvLanngungmay.Focus()
                Exit For
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnKhongghi.Click
        Try
            chkIsLock.Enabled = True
            dtpTNgayLoc.Enabled = True
            dtpDNgayLoc.Enabled = True
            cboLoaiTB.Enabled = True
            cboDiaDiem.Enabled = True

            flag = True
            Cursor = Cursors.WaitCursor

            refresh1()
            TrangThai = [String].Empty
            InitializeDatabase()
            InitializeForm()

            gvLanngungmay.Rows(index).Cells(0).Selected = True
            lannm = gvLanngungmay.Rows(index).Cells("MS_LAN").Value.ToString

            flag = False
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub btnNNNM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNNNM.Click

        Dim frmNguyenNhanDungMay As Report1.frmNguyenNhanDungMay = New Report1.frmNguyenNhanDungMay()
        If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmNguyenNhanDungMay.Name) Then
            frmNguyenNhanDungMay.ShowDialog()
            LoadLoaidungmay()
        End If

    End Sub

    Sub CreaterptTieuDeThoiGianNgungMay()
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TieuDe", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "ThietBi", Commons.Modules.TypeLanguage)
        Dim Ngay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "Ngay", Commons.Modules.TypeLanguage)
        Dim DenNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "sDenNgay", Commons.Modules.TypeLanguage)
        Dim TuGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TuGio", Commons.Modules.TypeLanguage)
        Dim DenGio As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "DenGio", Commons.Modules.TypeLanguage)
        Dim NguyenNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NguyenNhan", Commons.Modules.TypeLanguage)
        Dim PhieuBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "PhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "GhiChu", Commons.Modules.TypeLanguage)
        Dim MaLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "MaLoai", Commons.Modules.TypeLanguage)
        Dim TenLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenLoai", Commons.Modules.TypeLanguage)
        Dim MaNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "MaNhom", Commons.Modules.TypeLanguage)
        Dim TenNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TenNhom", Commons.Modules.TypeLanguage)
        Dim ThoiGianNghi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "ThoiGianNghi", Commons.Modules.TypeLanguage)
        Dim TongMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongMay", Commons.Modules.TypeLanguage)
        Dim TongNhom As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongNhom", Commons.Modules.TypeLanguage)
        Dim TongLoai As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongLoai", Commons.Modules.TypeLanguage)
        Dim TongKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "TongKho", Commons.Modules.TypeLanguage)

        Dim NGUOI_GIAI_QUYET As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NGUOI_GIAI_QUYET", Commons.Modules.TypeLanguage)
        Dim LOAI As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "LOAI", Commons.Modules.TypeLanguage)

        Dim HTuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "HTuong", Commons.Modules.TypeLanguage)
        Dim CGQuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "CGQuyet", Commons.Modules.TypeLanguage)
        Dim NNCuThe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHOI_GIAN_NGUNG_MAY", "NNCuThe", Commons.Modules.TypeLanguage)

        Dim DieuKienLoc As String = ""
        'DieuKienLoc = lbldiadiem.Text + " " + cboNhaxuong.Text + "  "
        ' DieuKienLoc = DieuKienLoc + lblTungay.Text + " " + Format(dtTungay.Value, "Short date") + "  " + lblDenngay.Text + " " + Format(dtDengnay.Value, "Short date")
        Dim str As String = ""
        Try
            str = "drop table rptTIEU_DE_THOI_GIAN_NGUNG_MAY"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_THOI_GIAN_NGUNG_MAY(TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(30),TrangIn nvarchar(30),DieuKienLoc nvarchar(255)," &
        " ThietBi nvarchar(50),sNgay nvarchar(20),sDenNgay nvarchar(20),TuGio nvarchar(20),DenGio nvarchar(20),NguyenNhan nvarchar(50),PhieuBaoTri nvarchar(50),GhiChu nvarchar(20), " &
        " MaLoai nvarchar(50),TenLoai nvarchar(50),MaNhom nvarchar(50),TenNhom nvarchar(50),ThoiGianNghi nvarchar(50),TongMay nvarchar(50),TongNhom nvarchar(50), " &
        " TongLoai nvarchar(50),TongKho nvarchar(50),NGUOI_GIAI_QUYET nvarchar(100) ,LOAI nvarchar(100),HienTuong nvarchar(50),CGQuyet nvarchar(50),NNCuThe nvarchar(100) )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        str = "Insert into rptTIEU_DE_THOI_GIAN_NGUNG_MAY(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,DieuKienLoc,ThietBi,sNgay,sDenNgay,TuGio,DenGio,NguyenNhan,PhieuBaoTri, " &
        " GhiChu,MaLoai,TenLoai,MaNhom,TenNhom,ThoiGianNghi,TongMay,TongNhom,TongLoai,TongKho,NGUOI_GIAI_QUYET,LOAI,HienTuong,CGQuyet,NNCuThe) values(" &
        Commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & DieuKienLoc & "',N'" & ThietBi & "',N'" & Ngay & "',N'" & DenNgay & "',N'" & TuGio & "',N'" & DenGio & "',N'" & NguyenNhan & "',N'" & PhieuBaoTri & "',N'" & GhiChu &
        "',N'" & MaLoai & "',N'" & TenLoai & "',N'" & MaNhom & "',N'" & TenNhom & "',N'" & ThoiGianNghi & "',N'" & TongMay & "',N'" & TongNhom & "',N'" & TongLoai & "',N'" & TongKho & "',N'" & NGUOI_GIAI_QUYET & "',N'" & LOAI & "',N'" & HTuong & "',N'" & CGQuyet & "',N'" & NNCuThe & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Try

            'IN THEO nha xuong ,loai may
            If gvLanngungmay.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Commons.clsXuLy.CreateTitleReport()
                Dim str As String = ""
                CreaterptTieuDeThoiGianNgungMay()
                Try
                    str = "drop table rptTHOI_GIAN_NGUNG_MAY"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                Catch ex As Exception
                End Try

                str = ""

                For i As Integer = 0 To gvLanngungmay.Rows.Count - 1
                    str = str & " , '" + gvLanngungmay.Rows(i).Cells("ms_may").Value + "' "

                Next
                str = str.Substring(2, str.Length - 3)
                str = " SELECT DISTINCT dbo.NHOM_MAY.MS_NHOM_MAY, dbo.NHOM_MAY.TEN_NHOM_MAY, dbo.LOAI_MAY.MS_LOAI_MAY, dbo.LOAI_MAY.TEN_LOAI_MAY,  " &
                        " dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY, dbo.THOI_GIAN_NGUNG_MAY.DEN_NGAY, " &
                        " dbo.THOI_GIAN_NGUNG_MAY.TU_GIO, dbo.THOI_GIAN_NGUNG_MAY.DEN_GIO, dbo.THOI_GIAN_NGUNG_MAY.THOI_GIAN_SUA_CHUA AS THOI_GIAN,  " &
                        " dbo.NGUYEN_NHAN_DUNG_MAY.TEN_NGUYEN_NHAN, dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_PHIEU_BAO_TRI, dbo.THOI_GIAN_NGUNG_MAY.GHI_CHU,  " &
                        " dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.NGUOI_GIAI_QUYET, dbo.THOI_GIAN_NGUNG_MAY.HIEN_TUONG,  " &
                        " dbo.THOI_GIAN_NGUNG_MAY.NGUYEN_NHAN,THOI_GIAN_NGUNG_MAY.NGUYEN_NHAN_CU_THE into rptTHOI_GIAN_NGUNG_MAY FROM dbo.THOI_GIAN_NGUNG_MAY INNER JOIN " &
                        " dbo.MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " &
                        " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " &
                        " dbo.LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.LOAI_MAY.MS_LOAI_MAY INNER JOIN " &
                        " dbo.NGUYEN_NHAN_DUNG_MAY ON dbo.THOI_GIAN_NGUNG_MAY.MS_NGUYEN_NHAN = dbo.NGUYEN_NHAN_DUNG_MAY.MS_NGUYEN_NHAN INNER JOIN " &
                        " dbo.THOI_GIAN_NGUNG_MAY_SO_LAN ON dbo.THOI_GIAN_NGUNG_MAY.MS_LAN = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_LAN AND  " &
                        " dbo.THOI_GIAN_NGUNG_MAY.MS_MAY = dbo.THOI_GIAN_NGUNG_MAY_SO_LAN.MS_MAY " &
                        " WHERE     (dbo.THOI_GIAN_NGUNG_MAY.MS_MAY IN (" + str + ")) "

                str = str + " ORDER BY dbo.THOI_GIAN_NGUNG_MAY.MS_MAY, dbo.THOI_GIAN_NGUNG_MAY.NGAY DESC, dbo.THOI_GIAN_NGUNG_MAY.TU_GIO "


                'Commons.mdShowReport.ReportPreview("reports/rptTHOI_GIAN_NGUNG_MAY.rpt")

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

                Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()

                frmRepot.rptName = "rptTHOI_GIAN_NGUNG_MAY"


                Dim vtbData As New DataTable()
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTHOI_GIAN_NGUNG_MAY"))
                vtbData.TableName = "rptTHOI_GIAN_NGUNG_MAY"
                Dim vtbTitle As New DataTable()
                vtbTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTIEU_DE_THOI_GIAN_NGUNG_MAY"))
                vtbTitle.TableName = "rptTIEU_DE_THOI_GIAN_NGUNG_MAY"



                frmRepot.AddDataTableSource(vtbData)
                frmRepot.AddDataTableSource(vtbTitle)
                frmRepot.ShowDialog()




                Me.Cursor = Cursors.Default
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieu", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboLoaiTB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboLoaiTB.SelectedIndexChanged, dtpTNgayLoc.ValueChanged, dtpDNgayLoc.ValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Try
            _Loc.Clear()
            lannm = "-1"
            refresh1()
            InitializeDatabase()
            InitializeForm()
        Catch
        End Try
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            InitializeDatabase()




        End If
    End Sub

    Dim flag As Boolean = False
    Private Sub cboMSMAY_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboMSMAY.SelectedIndexChanged
        Dim value As String = ""
        Try
            value = ""
            Try
                value = cboMSMAY.SelectedValue
            Catch ex As Exception

            End Try
            If value <> "" Then
                If (flag = False) Then
                    LoadPhieuBaoTri(cboMSMAY.SelectedValue)
                End If
            End If

            If cboMSMAY.SelectedText = "" Then
                For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
                    gvThoigianngungmay.Rows(i).Cells("MS_N_XUONG").Value = GetNhaxuong(cboMSMAY.Text.ToString.Trim, gvThoigianngungmay.Rows(i).Cells("NGAY").Value.ToString)
                    gvThoigianngungmay.Rows(i).Cells("MS_HE_THONG").Value = GetDaychuyen(cboMSMAY.Text.ToString.Trim, gvThoigianngungmay.Rows(i).Cells("NGAY").Value.ToString)
                Next

            End If
        Catch
        End Try
        '


        Try
            Dim sTenMay As String
            sTenMay = ""
            sTenMay = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT TEN_MAY FROM MAY WHERE MS_MAY = '" & value & "' "))

            txtTenMay.Text = sTenMay

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvThoigianngungmay_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles gvThoigianngungmay.CellValidating
        If TrangThai = "Add" OrElse TrangThai = "Edit" Then
            If btnKhongghi.Focused Then
                Exit Sub
            Else
                Try
                    If e.RowIndex < gvThoigianngungmay.Rows.Count - 1 Then
                        'Dim column As String = gvThoigianngungmay.Columns(e.ColumnIndex).Name
                        If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "NGAY" OrElse gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_NGAY" OrElse gvThoigianngungmay.Columns(e.ColumnIndex).Name = "TU_GIO" OrElse gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_GIO" Then
                            If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "NGAY" Then
                                Try
                                    If e.FormattedValue = "" OrElse e.FormattedValue = " / /" OrElse Not IsDate(e.FormattedValue) Then
                                        Vietsoft.Information.MsgBox(Me, "MsgTuNgayNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"

                                        e.Cancel = True
                                        Exit Sub
                                    Else
                                        If cboMSMAY.Text.Trim <> "" Then
                                            Try
                                                gvThoigianngungmay.Rows(e.RowIndex).Cells("MS_N_XUONG").Value = GetNhaxuong(cboMSMAY.Text.Trim, e.FormattedValue)
                                                gvThoigianngungmay.Rows(e.RowIndex).Cells("MS_HE_THONG").Value = GetDaychuyen(cboMSMAY.Text.Trim, e.FormattedValue)
                                            Catch ex As Exception
                                            End Try
                                        End If
                                    End If
                                Catch
                                    Vietsoft.Information.MsgBox(Me, "MsgTuNgayKhongHopLe", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                                    gvThoigianngungmay.CurrentCell.Value = dtpNgaybatdau.Value
                                    e.Cancel = True
                                    Exit Sub
                                End Try
                            End If

                            If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "TU_GIO" Then
                                Try
                                    If e.FormattedValue = "" OrElse e.FormattedValue = " : " OrElse Not IsDate(e.FormattedValue) Then
                                        Vietsoft.Information.MsgBox(Me, "MsgTuGioNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                                        e.Cancel = True
                                        Exit Sub
                                    End If
                                Catch
                                    Vietsoft.Information.MsgBox(Me, "MsgTuGiokhongdung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                                    e.Cancel = True
                                    Exit Sub

                                End Try
                            End If
                            If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_GIO" OrElse gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_NGAY" Then
                                If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_NGAY" Then
                                    Try
                                        If e.FormattedValue = "" OrElse e.FormattedValue = " / /" OrElse Not IsDate(e.FormattedValue) Then
                                            Vietsoft.Information.MsgBox(Me, "MsgDenNgayNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                                            e.Cancel = True
                                        End If
                                    Catch
                                        gvThoigianngungmay.CurrentCell.Value = dtpNgaybatdau.Value.ToShortDateString()
                                        Vietsoft.Information.MsgBox(Me, "MsgDenNgayKhongHopLe", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                                        e.Cancel = True
                                        Exit Sub
                                    End Try
                                End If
                                If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_GIO" Then
                                    Try
                                        If e.FormattedValue = "" OrElse e.FormattedValue = " : " OrElse Not IsDate(e.FormattedValue) Then
                                            Vietsoft.Information.MsgBox(Me, "MsgDenGioNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                                            e.Cancel = True
                                            Exit Sub
                                        End If
                                    Catch
                                        Vietsoft.Information.MsgBox(Me, "MsgDenkhongdung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        gvThoigianngungmay.Rows(e.RowIndex).ErrorText = "Error"
                                        e.Cancel = True
                                        Exit Sub

                                    End Try

                                End If
                            End If
                        Else
                            If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "GHI_CHU" Or gvThoigianngungmay.Columns(e.ColumnIndex).Name = "NGUOI_GIAI_QUYET" Then
                                Try
                                    Dim TN As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("TU_GIO").Value.ToString()).ToString("HH:mm:ss"))
                                    Dim DN As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_GIO").Value.ToString()).ToString("HH:mm:ss"))
                                Catch ex As Exception
                                    Vietsoft.Information.MsgBox(Me, "MsgThoigianngungmaykodung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    'e.Cancel = True
                                    Exit Sub
                                End Try
                            End If
                            If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "THOI_GIAN_NGUNG_MAY" Or gvThoigianngungmay.Columns(e.ColumnIndex).Name = "THOI_GIAN_SUA_CHUA" Then

                                Dim TuNgay__1 As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("TU_GIO").Value.ToString()).ToString("HH:mm:ss"))
                                Dim DenNgay__2 As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_GIO").Value.ToString()).ToString("HH:mm:ss"))
                                Dim stime As Integer = (DenNgay__2 - TuNgay__1).Days * 24 * 60 + (DenNgay__2 - TuNgay__1).Hours * 60 + (DenNgay__2 - TuNgay__1).Minutes
                                Dim st As Integer
                                If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "THOI_GIAN_NGUNG_MAY" Then

                                    'If Not Integer.TryParse(e.FormattedValue.ToString().Replace(",", "").Replace(".", ""), st) Then
                                    If Not IsNumeric(e.FormattedValue) Then
                                        Vietsoft.Information.MsgBox(Me, "MsgThoigianngungmayphailaso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        e.Cancel = True
                                        Exit Sub
                                    End If

                                    st = e.FormattedValue
                                    If st = 0 Then
                                        Vietsoft.Information.MsgBox(Me, "MsgThoigianngungmaybang0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    End If
                                    If stime <= 0 Then
                                        Vietsoft.Information.MsgBox(Me, "MsgThoigianngungmaykodung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        gvThoigianngungmay.Rows(e.RowIndex).Selected = True
                                        Exit Sub
                                    End If
                                    If stime > 1440 Then
                                        Vietsoft.Information.MsgBox(Me, "MsgThoigianngungmayphainhohon24h", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        gvThoigianngungmay.Rows(e.RowIndex).Selected = True
                                        Exit Sub
                                    End If

                                    If st < 0 Then
                                        gvThoigianngungmay.Rows(e.RowIndex).Cells("THOI_GIAN_NGUNG_MAY").Value = stime
                                        st = stime
                                    End If
                                End If

                                If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "THOI_GIAN_SUA_CHUA" Then
                                    If e.FormattedValue.ToString() = "" OrElse e.FormattedValue.ToString().Trim().Equals("") Then
                                        Vietsoft.Information.MsgBox(Me, "MsgThoigiansuachuanull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        e.Cancel = True
                                        Exit Sub
                                    Else
                                        Try
                                            Dim tgsc As Single = Single.Parse(e.FormattedValue.ToString())
                                            If tgsc <= 0 Or tgsc > stime Then
                                                If (tgsc = 0) Then
                                                    Vietsoft.Information.MsgBox(Me, "MsgThoigiansuamaybang0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                Else
                                                    Vietsoft.Information.MsgBox(Me, "MsgThoigiansuachuasai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                    e.Cancel = True
                                                    Exit Sub
                                                End If
                                                '
                                            End If
                                        Catch
                                            Vietsoft.Information.MsgBox(Me, "MsgThoigiansuachuasai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            e.Cancel = True
                                            Exit Sub
                                        End Try
                                    End If
                                End If
                            End If

                        End If
                    End If
                Catch
                    'e.Cancel = True
                End Try
            End If

        End If
    End Sub

    Private Sub gvThoigianngungmay_CellValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles gvThoigianngungmay.CellValidated
        Try
            If TrangThai = "Add" OrElse TrangThai = "Edit" Then

                Try
                    Dim TuNgay As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("TU_GIO").Value.ToString()).ToString("HH:mm:ss"))
                    Dim DenNgay As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_GIO").Value.ToString()).ToString("HH:mm:ss"))
                    Dim stime As Integer = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes

                    'If Commons.Modules.sPrivate = "BARIA" Then
                    Dim TG As Double

                    Try
                        TG = gvThoigianngungmay.Rows(e.RowIndex).Cells("THOI_GIAN_NGUNG_MAY").Value
                    Catch ex As Exception
                        TG = 0
                    End Try
                    'If TG = 0 Then
                    '    Vietsoft.Information.MsgBox(Me, "MsgThoigianngungmaybang0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    'Else
                    If TG < 0 Then
                        gvThoigianngungmay.Rows(e.RowIndex).Cells("THOI_GIAN_NGUNG_MAY").Value = stime
                    End If
                    'End If
                    'Else
                    ' gvThoigianngungmay.Rows(e.RowIndex).Cells("THOI_GIAN_NGUNG_MAY").Value = stime
                    ' End If



                Catch
                End Try

            End If
        Catch
        End Try
    End Sub
    Private Sub gvThoigianngungmay_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles gvThoigianngungmay.CellValueChanged
        Try


            If TrangThai = "Add" OrElse TrangThai = "Edit" Then
                If gvThoigianngungmay.Columns(e.ColumnIndex).Name = "NGAY" OrElse gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_NGAY" OrElse gvThoigianngungmay.Columns(e.ColumnIndex).Name = "TU_GIO" OrElse gvThoigianngungmay.Columns(e.ColumnIndex).Name = "DEN_GIO" Then
                    Try
                        Dim TuNgay As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("TU_GIO").Value.ToString()).ToString("HH:mm:ss"))
                        Dim DenNgay As DateTime = DateTime.Parse((DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_NGAY").Value.ToString()).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_GIO").Value.ToString()).ToString("HH:mm:ss"))
                        Dim stime As Integer = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes

                        gvThoigianngungmay.Rows(e.RowIndex).Cells("THOI_GIAN_NGUNG_MAY").Value = stime
                        gvThoigianngungmay.Rows(e.RowIndex).Cells("THOI_GIAN_SUA_CHUA").Value = stime

                    Catch
                    End Try
                End If



            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub gvThoigianngungmay_DefaultValuesNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
        Try
            If gvThoigianngungmay.Rows.Count = 1 Then
                CapNhapNgay()


                ' gvThoigianngungmay.AllowUserToAddRows = False


            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Function GetNhaxuong(ByVal may As String, ByVal ngay As DateTime) As String
        Try
            Dim SqlTbTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
            Dim nhaxuong As String
            nhaxuong = SqlTbTGNM.ExecuteScalar(CommandType.StoredProcedure, "GetNHA_XUONG_BY_MAY", may, ngay).ToString
            Return nhaxuong
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetDaychuyen(ByVal may As String, ByVal ngay As DateTime) As Integer
        Try
            Dim SqlTbTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
            Dim daychuyen As String
            daychuyen = SqlTbTGNM.ExecuteScalar(CommandType.StoredProcedure, "GetDAY_CHUYEN_BY_MAY", may, ngay).ToString
            Return CType(daychuyen, Integer)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub getTGNM()
        Try
            If cboLoaiTB.SelectedValue = Nothing Then Exit Sub
            tbTG = New DataTable()
            gvThoigianngungmay.DataSource = Nothing
            Dim SqlTbTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
            If lannm <> "-1" Then
                tbTG.Load(SqlTbTGNM.ExecuteReader(CommandType.StoredProcedure, "GetTHOI_GIAN_NGUNG_MAY_THEO_MAY", lannm))
            Else
                tbTG.Load(SqlTbTGNM.ExecuteReader(CommandType.StoredProcedure, "GetTHOI_GIAN_NGUNG_MAY_THEO_MAY", "-1111"))
            End If

            If tbTG.Columns.Count > 0 Then
                tbTG.Columns("MS_HE_THONG").AllowDBNull = True
                tbTG.Columns("MS_N_XUONG").AllowDBNull = True
                tbTG.Columns("MS_MAY").AllowDBNull = True
                tbTG.Columns("NGAY").AllowDBNull = True
                tbTG.Columns("TU_GIO").AllowDBNull = True
                tbTG.Columns("DEN_NGAY").AllowDBNull = True
                tbTG.Columns("DEN_GIO").AllowDBNull = True
                tbTG.Columns("MS_NGUYEN_NHAN").AllowDBNull = True
                tbTG.Columns("TRUONG_CA").AllowDBNull = True
                tbTG.Columns("MS_MAY_OLD").AllowDBNull = True
                tbTG.Columns("NGAY_OLD").AllowDBNull = True
                tbTG.Columns("TU_GIO_OLD").AllowDBNull = True
                tbTG.Columns("DEN_NGAY_OLD").AllowDBNull = True
                tbTG.Columns("DEN_GIO_OLD").AllowDBNull = True
                tbTG.Columns("MS_LAN_OLD").AllowDBNull = True
            End If

            gvThoigianngungmay.DataSource = tbTG
            gvThoigianngungmay.Columns("MS_N_XUONG").Width = 140
            gvThoigianngungmay.Columns("MS_HE_THONG").Width = 160
            Try
                Me.gvThoigianngungmay.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("TU_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_GIO", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("DEN_NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("DEN_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_GIO", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("THOI_GIAN_NGUNG_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_NGUNG_MAY", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("THOI_GIAN_SUA_CHUA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THOI_GIAN_SUA_CHUA", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("CACH_GIAI_QUYET").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CACH_GIAI_QUYET", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("MS_HE_THONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DAY_CHUYEN", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("MS_N_XUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHA_XUONG", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("HIEN_TUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HIEN_TUONG", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("NGUYEN_NHAN_CU_THE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN_CU_THE", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("MS_NGUYEN_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.gvThoigianngungmay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

                Me.gvThoigianngungmay.Columns("TRUONG_CA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTruongCa", Commons.Modules.TypeLanguage)
                Me.gvThoigianngungmay.Columns("CaID").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblCa", Commons.Modules.TypeLanguage)

            Catch
            End Try
        Catch
        End Try
    End Sub

    Private Sub gvLanngungmay_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvLanngungmay.RowEnter
        Try

            If TrangThai <> "Add" And TrangThai <> "Edit" And TrangThai <> "Delete" Then
                If gvLanngungmay.Rows.Count > 0 And e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                    lannm = gvLanngungmay.Rows(e.RowIndex).Cells("MS_LAN").Value.ToString
                    cboCa.SelectedValue = gvLanngungmay.Rows(e.RowIndex).Cells("CaID").Value.ToString

                End If
                getTGNM()
                getBoPhanTheoMay(e.RowIndex)
            End If


            If (gvLanngungmay.RowCount = 0) Then
                grdPhuTungtheoMay.DataSource = Nothing
            End If
        Catch
        End Try
    End Sub
    Private Sub getBoPhanTheoMay(ByVal index As Integer)
        Try
            Dim dt = New DataTable()
            grdPhuTungtheoMay.DataSource = Nothing
            Try
                dt = New DataTable()
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhutungTheoMay", gvLanngungmay.Rows(index).Cells("MS_LAN").Value.ToString, gvLanngungmay.Rows(index).Cells("MS_MAY").Value.ToString))
            Catch
                dt = New DataTable()
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhutungTheoMay", "", ""))
            End Try



            dt.Columns("MS_BO_PHAN").ReadOnly = True
            dt.Columns("TEN_BO_PHAN").ReadOnly = True
            dt.Columns("MS_PT").ReadOnly = True
            dt.Columns("TEN_PT").ReadOnly = True
            dt.Columns("MS_VI_TRI_PT").ReadOnly = True
            grdPhuTungtheoMay.DataSource = dt
            grdPhuTungtheoMay.Columns("MS_LAN").Visible = False
            grdPhuTungtheoMay.Columns("MS_MAY").Visible = False
            grdPhuTungtheoMay.Columns("STT").Visible = False

            grdPhuTungtheoMay.Columns("MS_PT").DisplayIndex = 5
            grdPhuTungtheoMay.Columns("MS_VI_TRI_PT").DisplayIndex = 6
            grdPhuTungtheoMay.Columns("TEN_PT").DisplayIndex = 7

            grdPhuTungtheoMay.Columns("DEL").Visible = False
            grdPhuTungtheoMay.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPTTuBoPhan", "TEN_PT", Commons.Modules.TypeLanguage)
            grdPhuTungtheoMay.Columns("MS_VI_TRI_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPTTuBoPhan", "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
            grdPhuTungtheoMay.Columns("MS_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN", Commons.Modules.TypeLanguage)
            grdPhuTungtheoMay.Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
            grdPhuTungtheoMay.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
            grdPhuTungtheoMay.Columns("MS_BO_PHAN").Width = 150
            grdPhuTungtheoMay.Columns("TEN_BO_PHAN").Width = 250
            grdPhuTungtheoMay.Columns("MS_PT").Width = 155
            grdPhuTungtheoMay.Columns("TEN_PT").Width = 250
            grdPhuTungtheoMay.Columns("MS_VI_TRI_PT").Width = 130

            Me.grdPhuTungtheoMay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdPhuTungtheoMay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub gvThoigianngungmay_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gvThoigianngungmay.DataError
        Try
            'If TypeOf e.Exception Is OutOfMemoryException Then
            e.ThrowException = False
            'End If
        Catch
        End Try


    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Try
            If (gvLanngungmay.Rows.Count > 0) Then
                index = gvLanngungmay.CurrentRow.Index
            Else
                index = -1
            End If
            'If FrmChonMayChoKHTT.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If gvLanngungmay.Rows.Count > 0 And lannm <> "" And lannm <> String.Empty Then
                Dim frmMay As New WareHouse.frmChonMay_TGNM()
                Dim SqlPhuTung As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
                Dim sSql As String
                sSql = " SELECT DISTINCT CONVERT(BIT,0) AS CHON, A.MS_MAY, A.TEN_MAY, A.MODEL, B.TEN_NHOM_MAY, C.TEN_LOAI_MAY, K.TEN_HE_THONG, " &
                       " CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN I.Ten_N_XUONG WHEN 1 THEN I.TEN_N_XUONG_A ELSE I.TEN_N_XUONG_H END AS Ten_N_XUONG " &
                    " FROM         dbo.MAY AS A INNER JOIN " &
                    " 					  dbo.NHOM_MAY AS B ON A.MS_NHOM_MAY = B.MS_NHOM_MAY INNER JOIN " &
                    " 					  dbo.LOAI_MAY AS C ON B.MS_LOAI_MAY = C.MS_LOAI_MAY INNER JOIN " &
                    " 					  dbo.NHOM_LOAI_MAY AS D ON C.MS_LOAI_MAY = D.MS_LOAI_MAY INNER JOIN " &
                    " 					  dbo.NHOM AS E ON D.GROUP_ID = E.GROUP_ID INNER JOIN " &
                    " 					  dbo.USERS AS F ON E.GROUP_ID = F.GROUP_ID INNER JOIN " &
                    " 					  dbo.MAY_HE_THONG_NGAY_MAX AS G ON A.MS_MAY = G.MS_MAY INNER JOIN " &
                    " 					  dbo.MAY_NHA_XUONG_NGAY_MAX AS H ON A.MS_MAY = H.MS_MAY INNER JOIN " &
                    " 					  dbo.NHA_XUONG AS I ON H.MS_N_XUONG = I.MS_N_XUONG INNER JOIN " &
                    " 					  dbo.HE_THONG AS K ON G.MS_HE_THONG = K.MS_HE_THONG " &
                    " WHERE     (USERNAME = N'" & Commons.Modules.UserName & "') AND (A.MS_HIEN_TRANG = 2) " &
                    " AND ( A.MS_MAY <> '" & cboMSMAY.SelectedValue.ToString() & "'  ) " &
                    " 	ORDER BY A.MS_MAY, A.TEN_MAY, A.MODEL"
                frmMay.DataSource = New DataTable()
                frmMay.DataSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                frmMay.DataSource.PrimaryKey = New DataColumn() {frmMay.DataSource.Columns("MS_MAY")}
                frmMay.MsMay = "-1"

aaa:
                If frmMay.ShowDialog(Me) = DialogResult.OK Then
                    frmMay.DataSource.DefaultView.RowFilter = "CHON = true"
                    frmMay.DataSource = frmMay.DataSource.DefaultView.ToTable()
                    frmMay.DataSource.PrimaryKey = New DataColumn() {frmMay.DataSource.Columns("MS_MAY")}

                    If frmMay.DataSource.DefaultView.Count > 0 Then
                        'kiem tra
                        For r As Integer = 0 To frmMay.DataSource.DefaultView.Count - 1
                            Dim msMay As String = frmMay.DataSource.DefaultView.ToTable().Rows(r)("MS_MAY").ToString()
                            Dim cr As Integer = KiemtralanNM(msMay)
                            If cr = 0 Then
                                frmMay.MsMay = msMay
                                GoTo aaa
                            End If
                        Next
                        'them
                        For r As Integer = 0 To frmMay.DataSource.DefaultView.Count - 1
                            Dim msMay As String = frmMay.DataSource.DefaultView.ToTable().Rows(r)("MS_MAY").ToString()

                            Dim LoaiNM As String = cboLoaidungmay.SelectedValue.ToString()
                            Dim PhieuBaoTri As String = ""
                            Try
                                PhieuBaoTri = cmbPhieuBaoTri.SelectedValue.ToString()
                            Catch ex As Exception

                            End Try
                            Dim ngay As DateTime = dtpNgaybatdau.Value
                            Dim gio As DateTime = dtpGioBD.Value
                            ngay = New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)

                            Dim NgayKT As DateTime = dtpNgayKT.Value
                            Dim GioKT As DateTime = dtpGioKT.Value

                            NgayKT = New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)

                            Dim NgaySX As DateTime = dtpNgaySX.Value


                            Dim nguoiGQ As String = txtNguoiGiaiQuyet.Text.Trim()
                            Dim nguyennhan As String = txtNguyennhan.Text.Trim()
                            Dim hientuong As String = txtHTuong.Text.Trim()
                            Dim NNCuThe As String = txtNNCuThe.Text.Trim()
                            Dim CA As String = "-1"
                            Try
                                CA = cboCa.SelectedValue
                            Catch ex As Exception
                            End Try

                            Dim row As DataRow = TbTGNM.NewRow()
                            lannm = Vietsoft.Information.GetID("LAN")
                            row("MS_LAN") = lannm
                            row("MS_MAY") = msMay
                            row("NGAY") = gvLanngungmay.Rows(index).Cells("NGAY").Value
                            row("TU_GIO") = gvLanngungmay.Rows(index).Cells("TU_GIO").Value
                            row("NGUOI_GIAI_QUYET") = gvLanngungmay.Rows(index).Cells("NGUOI_GIAI_QUYET").Value
                            row("MS_NGUYEN_NHAN") = gvLanngungmay.Rows(index).Cells("MS_NGUYEN_NHAN").Value
                            row("MS_LOAI_MAY") = gvLanngungmay.Rows(index).Cells("MS_LOAI_MAY").Value
                            row("NN_CGQ") = gvLanngungmay.Rows(index).Cells("NN_CGQ").Value
                            row("NGAY_KT") = gvLanngungmay.Rows(index).Cells("NGAY_KT").Value
                            row("GIO_KT") = gvLanngungmay.Rows(index).Cells("GIO_KT").Value

                            'row("TNGAY_GIO") = gvLanngungmay.Rows(index).Cells("NGAY_KT").Value
                            'row("DNGAY_GIO") = gvLanngungmay.Rows(index).Cells("NGAY_KT").Value

                            Dim NgayGio As Date
                            NgayGio = gvLanngungmay.Rows(index).Cells("NGAY").Value

                            row("TNGAY_GIO") = Convert.ToDateTime(New DateTime(dtpNgaybatdau.Value.Year, dtpNgaybatdau.Value.Month, dtpNgaybatdau.Value.Day, dtpGioBD.Value.Hour, dtpGioBD.Value.Minute, 0)).ToString("dd/MM/yyyy HH:mm")
                            row("DNGAY_GIO") = Convert.ToDateTime(New DateTime(dtpNgayKT.Value.Year, dtpNgayKT.Value.Month, dtpNgayKT.Value.Day, dtpGioKT.Value.Hour, dtpGioKT.Value.Minute, 0)).ToString("dd/MM/yyyy HH:mm")

                            TbTGNM.Rows.Add(row)

                            Dim SqlTbTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
                            'Add thoi gian ngung may
                            Dim result As Integer = 0
                            If lannm <> "" Then


                                result = SqlTbTGNM.ExecuteNonQuery(CommandType.StoredProcedure, "AddTHOI_GIAN_NGUNG_MAY_LAN",
                                    lannm, msMay, ngay.ToShortDateString(), gio.ToShortTimeString(), nguoiGQ, nguyennhan, hientuong,
                                    NNCuThe, NgayKT.ToShortDateString(), GioKT.ToShortTimeString(), NgaySX.ToShortDateString(),
                                                                   txtTruongCa.Text.Trim, Convert.ToInt32(CA), LoaiNM, PhieuBaoTri)



                                If result > 0 Then
                                    'add chi thoigian ngung may chi tiet 
                                    If lannm <> "" Then
                                        For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
                                            Dim vtungay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("NGAY").Value.ToString)
                                            Dim vdenngay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_NGAY").Value.ToString)
                                            Dim vtugio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("TU_GIO").Value.ToString)
                                            Dim vdengio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_GIO").Value.ToString)
                                            Dim daychuyen As String = gvThoigianngungmay.Rows(i).Cells("MS_HE_THONG").Value.ToString
                                            Dim hethong As String = gvThoigianngungmay.Rows(i).Cells("MS_N_XUONG").Value.ToString
                                            Dim msNguyenNhan As String = gvThoigianngungmay.Rows(i).Cells("MS_NGUYEN_NHAN").Value.ToString

                                            Dim vghichu As String
                                            Try
                                                vghichu = gvThoigianngungmay.Rows(i).Cells("GHI_CHU").Value.ToString
                                            Catch ex As Exception
                                                vghichu = ""
                                            End Try
                                            Dim vnguoigiaiquyet As String
                                            Try
                                                vnguoigiaiquyet = gvThoigianngungmay.Rows(i).Cells("NGUOI_GIAI_QUYET").Value.ToString
                                            Catch ex As Exception
                                                vnguoigiaiquyet = ""
                                            End Try
                                            Dim vthoigianngungmay As String = gvThoigianngungmay.Rows(i).Cells("THOI_GIAN_NGUNG_MAY").Value.ToString
                                            Dim vthoigiansua As String = gvThoigianngungmay.Rows(i).Cells("THOI_GIAN_SUA_CHUA").Value.ToString
                                            Dim MsCode As String = ""
                                            Try
                                                MsCode = gvThoigianngungmay.Rows(i).Cells("MA_CODE").Value.ToString
                                            Catch ex As Exception

                                            End Try


                                            Dim CA1 As Integer = -1
                                            Try
                                                CA1 = If(String.IsNullOrEmpty(gvThoigianngungmay.Rows(i).Cells("CaID").Value.ToString), -1, gvThoigianngungmay.Rows(i).Cells("CaID").Value.ToString)
                                            Catch ex As Exception

                                            End Try

                                            result = SqlTbTGNM.ExecuteNonQuery(CommandType.StoredProcedure, "AddTHOI_GIAN_NGUNG_MAY_THEO_LAN", msMay, lannm,
                                                        vtungay.ToShortDateString(), vtugio.ToShortTimeString(), vdenngay.ToShortDateString(),
                                                        vdengio.ToShortTimeString(), msNguyenNhan, vghichu, daychuyen, vthoigianngungmay,
                                                        hethong, vthoigiansua, gvThoigianngungmay.Rows(i).Cells("CACH_GIAI_QUYET").Value.ToString,
                                                        gvThoigianngungmay.Rows(i).Cells("HIEN_TUONG").Value.ToString, gvThoigianngungmay.Rows(i).Cells("NGUYEN_NHAN_CU_THE").Value.ToString,
                                                        gvThoigianngungmay.Rows(i).Cells("NGUOI_GIAI_QUYET").Value.ToString, gvThoigianngungmay.Rows(i).Cells("TRUONG_CA").Value.ToString, CA1)


                                        Next
                                    End If
                                    'TbTGNM.EndEdit()
                                    If result > 0 Then
                                        TbTGNM.AcceptChanges()
                                        getTGNM()
                                    End If
                                End If
                            End If

                        Next
                    End If

                    gvLanngungmay.Rows(TbTGNM.Rows.Count - 1).Cells(0).Selected = True
                    getTGNM()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function KiemtralanNM(ByVal msmay As String) As Integer
        Dim Sql As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
        Dim kiemtra As DataTable
        kiemtra = New System.Data.DataTable()
        kiemtra.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "KIEM_TRA_TGNM", msmay, "-1"))

        If kiemtra.Rows.Count > 0 Then
            For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
                For Each row As DataRow In kiemtra.Rows
                    Dim vtungay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("NGAY").Value.ToString)
                    Dim vdenngay As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_NGAY").Value.ToString)
                    Dim vtugio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("TU_GIO").Value.ToString)
                    Dim vdengio As DateTime = DateTime.Parse(gvThoigianngungmay.Rows(i).Cells("DEN_GIO").Value.ToString)


                    vtungay = New DateTime(vtungay.Year, vtungay.Month, vtungay.Day, vtugio.Hour, vtugio.Minute, 0)
                    vdenngay = New DateTime(vdenngay.Year, vdenngay.Month, vdenngay.Day, vdengio.Hour, vdengio.Minute, 0)

                    Dim dtungay As DateTime = DateTime.Parse(row("NGAY").ToString())
                    Dim ddenngay As DateTime = DateTime.Parse(row("DEN_NGAY").ToString())
                    Dim dtugio As DateTime = DateTime.Parse(row("TU_GIO").ToString())
                    Dim ddengio As DateTime = DateTime.Parse(row("DEN_GIO").ToString())
                    dtungay = New DateTime(dtungay.Year, dtungay.Month, dtungay.Day, dtugio.Hour, dtugio.Minute, 0)
                    ddenngay = New DateTime(ddenngay.Year, ddenngay.Month, ddenngay.Day, ddengio.Hour, ddengio.Minute, 0)
                    If vdenngay <= dtungay Or vtungay >= ddenngay Then
                        Return 1
                    Else
                        XtraMessageBox.Show("May '" + msmay + "' dang dung tai thoi diem nay.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Return 0
                    End If
                Next
            Next
        Else
            Return 1
        End If
    End Function

    Private Sub cmbPhieuBaoTri_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbPhieuBaoTri.Validating
        If btnSave.Enabled = False Then Exit Sub
        Try
            Dim value As String = ""
            Try
                value = cmbPhieuBaoTri.SelectedValue
            Catch ex As Exception

            End Try
            If value = "" And cmbPhieuBaoTri.Text <> "" Then
                cmbPhieuBaoTri.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub



    Dim currentCa As DateTime

    Dim dtTmp As DataTable
    Public Sub CapNhapNgay()
        Try
            Dim ngay As DateTime = dtpNgaybatdau.Value
            Dim gio As DateTime = dtpGioBD.Value
            Dim NgayKT As DateTime = dtpNgayKT.Value
            Dim GioKT As DateTime = dtpGioKT.Value

            ngay = New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)
            gio = New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)
            NgayKT = New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)
            GioKT = New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)

            Dim tongNgay As Integer = NgayKT.DayOfYear - ngay.DayOfYear

            dtTmp = New DataTable()
            dtTmp = CType(gvThoigianngungmay.DataSource, DataTable)
            dtTmp.Rows.Clear()
            dtTmp.AcceptChanges()

            Dim sNX As String = GetNhaxuong(cboMSMAY.SelectedValue.ToString, Format(ngay, "Short date").ToString)
            Dim iDC As Integer = GetDaychuyen(cboMSMAY.SelectedValue.ToString, Format(ngay, "Short date").ToString)

            Dim dtCa As New DataTable()
            dtCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Ca", Commons.Modules.TypeLanguage))


            For i As Integer = 0 To tongNgay
                Dim dr As DataRow
                Dim TuNgay As DateTime
                Dim DenNgay As DateTime
                Dim stime As Integer = 0
                If (dtCa.Rows.Count = 0) Then 'Không cài đặt Ca
                    dr = dtTmp.NewRow


                    If (i = 0) Then
                        dr.Item("NGAY") = ngay.ToString("dd/MM/yyyy")
                        dr.Item("TU_GIO") = ngay.ToString("HH:mm:ss")
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(ngay.TimeOfDay.ToString.Substring(0, 5)).ToString("HH:mm:ss"))
                    Else
                        ngay = ngay.AddDays(1)
                        dr.Item("NGAY") = ngay.ToString("dd/MM/yyyy")
                        dr.Item("TU_GIO") = "00:00:00"
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " 00:00:00"))
                    End If
                    dr.Item("DEN_NGAY") = ngay.ToString("dd/MM/yyyy")
                    If (i = tongNgay) Then
                        dr.Item("DEN_GIO") = dtpGioKT.Value.ToString("HH:mm:ss")
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(NgayKT, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(dr.Item("DEN_GIO")).ToString("HH:mm:ss")))
                    Else
                        dr.Item("DEN_GIO") = "23:59:00"
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " 23:59:00"))
                    End If
                    stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                    dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                    dr.Item("THOI_GIAN_SUA_CHUA") = stime
                    dr.Item("MS_N_XUONG") = sNX
                    dr.Item("MS_HE_THONG") = iDC
                    dr.Item("MS_MAY") = cboMSMAY.SelectedValue
                    dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                    dr.Item("NN_CGQ") = txtNguyennhan.Text
                    dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                    dr.Item("HIEN_TUONG") = txtHTuong.Text
                    dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                    dr.Item("TRUONG_CA") = txtTruongCa.Text

                    dtTmp.Rows.Add(dr)
                Else 'Có cài đặt Ca
                    If (i > 0 And i < tongNgay) Then
                        ngay = ngay.AddDays(1)
                        For Each row As DataRow In dtCa.Rows
                            dr = dtTmp.NewRow
                            dr.Item("NGAY") = ngay.ToString("dd/MM/yyyy")
                            dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                            TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))
                            If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                dr.Item("DEN_NGAY") = ngay.AddDays(1).ToString("dd/MM/yyyy")
                            Else
                                dr.Item("DEN_NGAY") = ngay.ToString("dd/MM/yyyy")
                            End If
                            dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")
                            DenNgay = DateTime.Parse((DateTime.Parse(Format(NgayKT, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")))
                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                            dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                            dr.Item("THOI_GIAN_SUA_CHUA") = stime
                            dr.Item("MS_N_XUONG") = sNX
                            dr.Item("MS_HE_THONG") = iDC
                            dr.Item("MS_MAY") = cboMSMAY.SelectedValue
                            dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                            dr.Item("NN_CGQ") = txtNguyennhan.Text
                            dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                            dr.Item("HIEN_TUONG") = txtHTuong.Text
                            dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                            dr.Item("TRUONG_CA") = txtTruongCa.Text
                            dr.Item("CaID") = row("STT")
                            dtTmp.Rows.Add(dr)
                        Next
                    ElseIf (i = 0) Then
                        For Each row As DataRow In dtCa.Rows
                            If (tongNgay = 0) Then

                                If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    If (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")) And
                                        Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO")).AddDays(-1) Or
                                        Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")).AddDays(1) And
                                        Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO"))
                                        ) Then
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = cboMSMAY.SelectedValue
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If
                                Else
                                    If ((Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("TU_GIO")) And
                                            Convert.ToDateTime("1900/01/01 " & dtpGioKT.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO"))) Or
                                           (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO")) And Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")))
                                        ) Then
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = cboMSMAY.SelectedValue
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If
                                End If
                            Else
                                If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    If ((Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")) And
                                        Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO")).AddDays(-1)) Or
                                        (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")).AddDays(1) And
                                        Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO"))) Or
                                         (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("TU_GIO")) And
                                          Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")).AddDays(1)) Or
                                           (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("TU_GIO")).AddDays(-1) And
                                          Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")))
                                        ) Then
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = cboMSMAY.SelectedValue
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If

                                Else
                                    If (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) > Convert.ToDateTime(row("TU_GIO")) And
                                       Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    Else
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = cboMSMAY.SelectedValue
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If
                                End If
                            End If
                        Next
                        Dim dataView As New DataView(dtTmp)
                        dataView.Sort = "NGAY ASC, TU_GIO ASC"
                        dtTmp = dataView.ToTable()
                        If (dtTmp.Rows.Count = 0) Then Continue For
                        Dim row1 As DataRow = dtTmp.Rows(0)
                        row1("TU_GIO") = dtpGioBD.Value.ToString("HH:mm")
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(row1("NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("TU_GIO")).ToString("HH:mm")))
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgayKT.Value, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("DEN_GIO")).ToString("HH:mm")))
                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                        row1("THOI_GIAN_NGUNG_MAY") = stime
                        row1("THOI_GIAN_SUA_CHUA") = stime
                        dataView = New DataView(dtTmp)
                        dataView.Sort = "NGAY ASC, TU_GIO ASC"
                        dtTmp = dataView.ToTable()
                        If tongNgay = 0 Then
1:                          dataView = New DataView(dtTmp)
                            dataView.Sort = "NGAY DESC, TU_GIO DESC"
                            dtTmp = dataView.ToTable()
                            row1 = dtTmp.Rows(0) ' dtTmp.Select().OrderByDescending(Function(x) x("TU_GIO")).Take(1).Single()
                            row1("DEN_GIO") = dtpGioKT.Value.ToString("HH:mm")
                            row1("DEN_NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                            TuNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(row1("NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("TU_GIO")).ToString("HH:mm")))
                            DenNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgayKT.Value, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("DEN_GIO")).ToString("HH:mm")))
                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                            If (stime < 0) Then
                                dtTmp.Rows.Remove(row1)
                                GoTo 1
                            End If
                            row1("THOI_GIAN_NGUNG_MAY") = stime
                            row1("THOI_GIAN_SUA_CHUA") = stime
                            dataView = New DataView(dtTmp)
                            dataView.Sort = "NGAY ASC, TU_GIO ASC"
                            dtTmp = dataView.ToTable()
                        End If
                    ElseIf (i = tongNgay) Then
                        For Each row As DataRow In dtCa.Rows
                            If (Convert.ToDateTime("1900/01/01 " & dtpGioKT.Value.ToString("HH:mm")) > Convert.ToDateTime(row("TU_GIO"))) Then
                                dr = dtTmp.NewRow
                                dr.Item("NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                                dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))
                                If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    dr.Item("DEN_NGAY") = dtpNgayKT.Value.AddDays(1).ToString("dd/MM/yyyy")
                                Else
                                    dr.Item("DEN_NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                                End If
                                dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")
                                DenNgay = DateTime.Parse((DateTime.Parse(Format(NgayKT, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).AddMinutes(1).ToString("HH:mm")))
                                stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                dr.Item("MS_N_XUONG") = sNX
                                dr.Item("MS_HE_THONG") = iDC
                                dr.Item("MS_MAY") = cboMSMAY.SelectedValue
                                dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                dr.Item("NN_CGQ") = txtNguyennhan.Text
                                dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                dr.Item("HIEN_TUONG") = txtHTuong.Text
                                dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                dr.Item("TRUONG_CA") = txtTruongCa.Text
                                dr.Item("CaID") = row("STT")

                                dtTmp.Rows.Add(dr)
                            End If
                        Next
                        '
                        Dim dataView As New DataView(dtTmp)
                        dataView.Sort = "NGAY DESC, TU_GIO DESC"
                        dtTmp = dataView.ToTable()
                        Dim row1 As DataRow = dtTmp.Rows(0) ' dtTmp.Select().OrderByDescending(Function(x) x("TU_GIO")).Take(1).Single()
                        row1("DEN_GIO") = dtpGioKT.Value.ToString("HH:mm")
                        row1("DEN_NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(row1("NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("TU_GIO")).ToString("HH:mm")))
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgayKT.Value, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("DEN_GIO")).ToString("HH:mm")))
                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                        row1("THOI_GIAN_NGUNG_MAY") = stime
                        row1("THOI_GIAN_SUA_CHUA") = stime
                        dataView = New DataView(dtTmp)
                        dataView.Sort = "NGAY ASC, TU_GIO ASC"
                        dtTmp = dataView.ToTable()
                    End If
                End If
            Next

            tbTG = New DataTable()
            tbTG = dtTmp

            gvThoigianngungmay.DataSource = Nothing
            gvThoigianngungmay.DataSource = tbTG

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CapNhapNgay1(RowKT As DataRow)
        Try

            Dim ngay As DateTime = RowKT("NGAY")
            Dim gio As DateTime = RowKT("TU_GIO")
            Dim NgayKT As DateTime = RowKT("NGAY_KT")
            Dim GioKT As DateTime = RowKT("GIO_KT")


            dtpNgaySX.Value = RowKT("NGAY")
            dtpNgaybatdau.Value = RowKT("NGAY")
            dtpGioBD.Value = RowKT("TU_GIO")
            dtpNgayKT.Value = RowKT("NGAY_KT")
            dtpGioKT.Value = RowKT("GIO_KT")
            cboLoaidungmay.SelectedValue = RowKT("MS_NGUYEN_NHAN")



            txtNguyennhan.Text = RowKT("NN_CGQ")
            txtNNCuThe.Text = RowKT("NGUYEN_NHAN_CU_THE")
            txtHTuong.Text = RowKT("HIEN_TUONG")
            txtNguoiGiaiQuyet.Text = RowKT("NGUOI_GIAI_QUYET")
            txtTruongCa.Text = RowKT("TRUONG_CA")


            cboMSMAY.SelectedValue = RowKT("MS_MAY")

            Dim ms_may As String = RowKT("MS_MAY")


            ngay = New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)
            gio = New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)
            NgayKT = New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)
            GioKT = New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)

            Dim tongNgay As Integer = NgayKT.DayOfYear - ngay.DayOfYear

            dtTmp = New DataTable()
            dtTmp = CType(gvThoigianngungmay.DataSource, DataTable)
            dtTmp.Rows.Clear()
            dtTmp.AcceptChanges()

            Dim sNX As String = GetNhaxuong(ms_may, Format(ngay, "Short date").ToString)
            Dim iDC As Integer = GetDaychuyen(ms_may, Format(ngay, "Short date").ToString)

            Dim dtCa As New DataTable()
            dtCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Ca", Commons.Modules.TypeLanguage))


            For i As Integer = 0 To tongNgay
                Dim dr As DataRow
                Dim TuNgay As DateTime
                Dim DenNgay As DateTime
                Dim stime As Integer = 0
                If (dtCa.Rows.Count = 0) Then 'Không cài đặt Ca
                    dr = dtTmp.NewRow


                    If (i = 0) Then
                        dr.Item("NGAY") = ngay.ToString("dd/MM/yyyy")
                        dr.Item("TU_GIO") = ngay.ToString("HH:mm:ss")
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " ") + DateTime.Parse(ngay.TimeOfDay.ToString.Substring(0, 5)).ToString("HH:mm:ss"))
                    Else
                        ngay = ngay.AddDays(1)
                        dr.Item("NGAY") = ngay.ToString("dd/MM/yyyy")
                        dr.Item("TU_GIO") = "00:00:00"
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " 00:00:00"))
                    End If
                    dr.Item("DEN_NGAY") = ngay.ToString("dd/MM/yyyy")
                    If (i = tongNgay) Then
                        dr.Item("DEN_GIO") = dtpGioKT.Value.ToString("HH:mm:ss")
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(NgayKT, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(dr.Item("DEN_GIO")).ToString("HH:mm:ss")))
                    Else
                        dr.Item("DEN_GIO") = "23:59:00"
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " 23:59:00"))
                    End If
                    stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                    dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                    dr.Item("THOI_GIAN_SUA_CHUA") = stime
                    dr.Item("MS_N_XUONG") = sNX
                    dr.Item("MS_HE_THONG") = iDC
                    dr.Item("MS_MAY") = ms_may
                    dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                    dr.Item("NN_CGQ") = txtNguyennhan.Text
                    dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                    dr.Item("HIEN_TUONG") = txtHTuong.Text
                    dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                    dr.Item("TRUONG_CA") = txtTruongCa.Text

                    dtTmp.Rows.Add(dr)
                Else 'Có cài đặt Ca
                    If (i > 0 And i < tongNgay) Then
                        ngay = ngay.AddDays(1)
                        For Each row As DataRow In dtCa.Rows
                            dr = dtTmp.NewRow
                            dr.Item("NGAY") = ngay.ToString("dd/MM/yyyy")
                            dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                            TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))
                            If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                dr.Item("DEN_NGAY") = ngay.AddDays(1).ToString("dd/MM/yyyy")
                            Else
                                dr.Item("DEN_NGAY") = ngay.ToString("dd/MM/yyyy")
                            End If
                            dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")
                            DenNgay = DateTime.Parse((DateTime.Parse(Format(NgayKT, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")))
                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                            dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                            dr.Item("THOI_GIAN_SUA_CHUA") = stime
                            dr.Item("MS_N_XUONG") = sNX
                            dr.Item("MS_HE_THONG") = iDC
                            dr.Item("MS_MAY") = ms_may
                            dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                            dr.Item("NN_CGQ") = txtNguyennhan.Text
                            dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                            dr.Item("HIEN_TUONG") = txtHTuong.Text
                            dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                            dr.Item("TRUONG_CA") = txtTruongCa.Text
                            dr.Item("CaID") = row("STT")
                            dtTmp.Rows.Add(dr)
                        Next
                    ElseIf (i = 0) Then
                        For Each row As DataRow In dtCa.Rows
                            If (tongNgay = 0) Then

                                If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    If (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")) And
                                    Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO")).AddDays(-1) Or
                                    Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")).AddDays(1) And
                                    Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO"))
                                    ) Then
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = ms_may
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If


                                Else
                                    If ((Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("TU_GIO")) And
                                        Convert.ToDateTime("1900/01/01 " & dtpGioKT.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO"))) Or
                                        (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO")) And Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")))
                                    ) Then
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = ms_may
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If
                                End If
                            Else
                                If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    If ((Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")) And
                                    Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO")).AddDays(-1)) Or
                                    (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")).AddDays(1) And
                                    Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) >= Convert.ToDateTime(row("TU_GIO"))) Or
                                        (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("TU_GIO")) And
                                        Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")).AddDays(1)) Or
                                        (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("TU_GIO")).AddDays(-1) And
                                        Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) <= Convert.ToDateTime(row("DEN_GIO")))
                                    ) Then
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = ms_may
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If

                                Else
                                    If (Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) > Convert.ToDateTime(row("TU_GIO")) And
                                    Convert.ToDateTime("1900/01/01 " & dtpGioBD.Value.ToString("HH:mm")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    Else
                                        dr = dtTmp.NewRow
                                        dr.Item("NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")

                                        dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                        TuNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgaybatdau.Value.ToString("dd/MM/yyyy"), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))

                                        If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.AddDays(1).ToString("dd/MM/yyyy")
                                        Else
                                            dr.Item("DEN_NGAY") = dtpNgaybatdau.Value.ToString("dd/MM/yyyy")
                                        End If
                                        dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")
                                        DenNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(dr.Item("DEN_NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")))
                                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                        dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                        dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                        dr.Item("MS_N_XUONG") = sNX
                                        dr.Item("MS_HE_THONG") = iDC
                                        dr.Item("MS_MAY") = ms_may
                                        dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                        dr.Item("NN_CGQ") = txtNguyennhan.Text
                                        dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                        dr.Item("HIEN_TUONG") = txtHTuong.Text
                                        dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                        dr.Item("TRUONG_CA") = txtTruongCa.Text
                                        dr.Item("CaID") = row("STT")
                                        dtTmp.Rows.Add(dr)
                                    End If
                                End If
                            End If
                        Next
                        Dim dataView As New DataView(dtTmp)
                        dataView.Sort = "NGAY ASC, TU_GIO ASC"
                        dtTmp = dataView.ToTable()
                        If (dtTmp.Rows.Count = 0) Then Continue For
                        Dim row1 As DataRow = dtTmp.Rows(0)
                        row1("TU_GIO") = dtpGioBD.Value.ToString("HH:mm")
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(row1("NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("TU_GIO")).ToString("HH:mm")))
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgayKT.Value, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("DEN_GIO")).ToString("HH:mm")))
                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                        row1("THOI_GIAN_NGUNG_MAY") = stime
                        row1("THOI_GIAN_SUA_CHUA") = stime
                        dataView = New DataView(dtTmp)
                        dataView.Sort = "NGAY ASC, TU_GIO ASC"
                        dtTmp = dataView.ToTable()
                        If tongNgay = 0 Then
1:                          dataView = New DataView(dtTmp)
                            dataView.Sort = "NGAY DESC, TU_GIO DESC"
                            dtTmp = dataView.ToTable()
                            row1 = dtTmp.Rows(0) ' dtTmp.Select().OrderByDescending(Function(x) x("TU_GIO")).Take(1).Single()
                            row1("DEN_GIO") = dtpGioKT.Value.ToString("HH:mm")
                            row1("DEN_NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                            TuNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(row1("NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("TU_GIO")).ToString("HH:mm")))
                            DenNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgayKT.Value, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("DEN_GIO")).ToString("HH:mm")))
                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                            If (stime < 0) Then
                                dtTmp.Rows.Remove(row1)
                                GoTo 1
                            End If
                            row1("THOI_GIAN_NGUNG_MAY") = stime
                            row1("THOI_GIAN_SUA_CHUA") = stime
                            dataView = New DataView(dtTmp)
                            dataView.Sort = "NGAY ASC, TU_GIO ASC"
                            dtTmp = dataView.ToTable()
                        End If
                    ElseIf (i = tongNgay) Then
                        For Each row As DataRow In dtCa.Rows
                            If (Convert.ToDateTime("1900/01/01 " & dtpGioKT.Value.ToString("HH:mm")) > Convert.ToDateTime(row("TU_GIO"))) Then
                                dr = dtTmp.NewRow
                                dr.Item("NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                                dr.Item("TU_GIO") = Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")
                                TuNgay = DateTime.Parse((DateTime.Parse(Format(ngay, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("TU_GIO")).ToString("HH:mm")))
                                If (Convert.ToDateTime(row("TU_GIO")) > Convert.ToDateTime(row("DEN_GIO"))) Then
                                    dr.Item("DEN_NGAY") = dtpNgayKT.Value.AddDays(1).ToString("dd/MM/yyyy")
                                Else
                                    dr.Item("DEN_NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                                End If
                                dr.Item("DEN_GIO") = Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")
                                DenNgay = DateTime.Parse((DateTime.Parse(Format(NgayKT, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row("DEN_GIO")).ToString("HH:mm")))
                                stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                                dr.Item("THOI_GIAN_NGUNG_MAY") = stime
                                dr.Item("THOI_GIAN_SUA_CHUA") = stime
                                dr.Item("MS_N_XUONG") = sNX
                                dr.Item("MS_HE_THONG") = iDC
                                dr.Item("MS_MAY") = ms_may
                                dr.Item("MS_NGUYEN_NHAN") = cboLoaidungmay.SelectedValue
                                dr.Item("NN_CGQ") = txtNguyennhan.Text
                                dr.Item("NGUYEN_NHAN_CU_THE") = txtNNCuThe.Text
                                dr.Item("HIEN_TUONG") = txtHTuong.Text
                                dr.Item("NGUOI_GIAI_QUYET") = txtNguoiGiaiQuyet.Text
                                dr.Item("TRUONG_CA") = txtTruongCa.Text
                                dr.Item("CaID") = row("STT")

                                dtTmp.Rows.Add(dr)
                            End If
                        Next

                        Dim dataView As New DataView(dtTmp)
                        dataView.Sort = "NGAY DESC, TU_GIO DESC"
                        dtTmp = dataView.ToTable()
                        Dim row1 As DataRow = dtTmp.Rows(0) ' dtTmp.Select().OrderByDescending(Function(x) x("TU_GIO")).Take(1).Single()
                        row1("DEN_GIO") = dtpGioKT.Value.ToString("HH:mm")
                        row1("DEN_NGAY") = dtpNgayKT.Value.ToString("dd/MM/yyyy")
                        TuNgay = DateTime.Parse((DateTime.Parse(Format(Convert.ToDateTime(row1("NGAY")), "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("TU_GIO")).ToString("HH:mm")))
                        DenNgay = DateTime.Parse((DateTime.Parse(Format(dtpNgayKT.Value, "Short date")).ToString("dd/MM/yyyy") & " " & Convert.ToDateTime(row1("DEN_GIO")).ToString("HH:mm")))
                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes
                        row1("THOI_GIAN_NGUNG_MAY") = stime
                        row1("THOI_GIAN_SUA_CHUA") = stime
                        dataView = New DataView(dtTmp)
                        dataView.Sort = "NGAY ASC, TU_GIO ASC"
                        dtTmp = dataView.ToTable()
                    End If
                End If
            Next

            'tbTG = New DataTable()
            'tbTG = dtTmp


            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "AAAA3", dtTmp, "")

            Dim sSql As String
            sSql = " INSERT INTO AAAA2 SELECT *, " & RowKT("MS_LAN").ToString & " FROM AAAA3 "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)


            'gvThoigianngungmay.DataSource = Nothing
            'gvThoigianngungmay.DataSource = tbTG

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCapNhapTG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhapTG.Click
        If btnSave.Enabled = False Then Exit Sub
        If String.IsNullOrEmpty(cboMSMAY.SelectedValue) Then Exit Sub
        If gvThoigianngungmay.RowCount > 0 Then
            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DaCoThoiGianMuonLamLai",
                        Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub
        End If
        If (Convert.ToDateTime(dtpNgaybatdau.Value.ToString("dd/MM/yyyy") & " " & dtpGioBD.Value.ToString("HH:mm")) >=
            Convert.ToDateTime(dtpNgayKT.Value.ToString("dd/MM/yyyy") & " " & dtpGioKT.Value.ToString("HH:mm"))
            ) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgTuNgayNhoHonDenNgay",
                        Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK)
            Exit Sub
        End If

        If (cboLoaidungmay.SelectedValue = Nothing) Then
            cboLoaidungmay.SelectedIndex = 0
        End If

        CapNhapNgay()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnTMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMay.Click
        Dim frm As New ReportMain.Forms.frmYCSDChonMay()
        frm.iLoai = 2
        If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        cboMSMAY.SelectedValue = Commons.Modules.SQLString
    End Sub

    Private Sub cboLoaidungmay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboLoaidungmay.Validating, cboCa.Validating
        If btnSave.Enabled = False Then Exit Sub
        Try
            Dim value As String = ""
            Try
                value = cboLoaidungmay.SelectedValue
            Catch ex As Exception

            End Try
            If value = "" And cboLoaidungmay.Text <> "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DuLieuKhongDung", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cboLoaidungmay.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboMSMAY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboMSMAY.Validating
        If btnSave.Enabled = False Then Exit Sub
        Try
            Dim value As String = ""
            Try
                value = cboMSMAY.SelectedValue
            Catch ex As Exception

            End Try
            If value = "" And cboMSMAY.Text <> "" Then
                cboMSMAY.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gvThoigianngungmay_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvThoigianngungmay.RowEnter
        'If Commons.Modules.SQLString = "0Load" Then Exit Sub
        'Try
        '    LoadCT(gvThoigianngungmay.Rows(e.RowIndex).Cells("MS_MAY").Value, gvThoigianngungmay.Rows(e.RowIndex).Cells("NGAY").Value,
        '           gvThoigianngungmay.Rows(e.RowIndex).Cells("TU_GIO").Value, gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_NGAY").Value,
        '           gvThoigianngungmay.Rows(e.RowIndex).Cells("DEN_GIO").Value)
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub frmThoiGianNgungMayNew_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        gvLanngungmay.Columns.Clear()
        gvThoigianngungmay.Columns.Clear()
    End Sub

    Private Sub btnCT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCT.Click
        Try
            If gvLanngungmay.Rows.Count > 0 And gvThoigianngungmay.Rows.Count Then
                TrangThai = "CT"
                index = gvLanngungmay.CurrentRow.Index
                InitializeForm()
            Else
                Vietsoft.Information.MsgBox(Me, "MsgKhongcodulieuCT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            Vietsoft.Information.MsgBox(Me, "MsgKhongcodulieuCT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub btnLockTGNM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockTGNM.Click
        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgBanCoMuonLockTGNM", Commons.Modules.TypeLanguage), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSql As String
        Try
            sSql = "UPDATE THOI_GIAN_NGUNG_MAY_SO_LAN SET LOCK = 1 WHERE MS_LAN = '" + gvLanngungmay.SelectedRows(0).Cells("MS_LAN").Value.ToString() + "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCapNhapLockTGNMKhongThanhCong", Commons.Modules.TypeLanguage))
        End Try
        lannm = "-1"
        refresh1()
        InitializeDatabase()
        InitializeForm()
    End Sub

    Private Sub chkIsLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsLock.CheckedChanged
        Try
            lannm = "-1"
            refresh1()
            InitializeDatabase()
            InitializeForm()
        Catch
        End Try
    End Sub

    Private Sub btnUnLockTGNM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnLockTGNM.Click
        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgBanCoMuonUnLockTGNM", Commons.Modules.TypeLanguage), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Dim sSql As String
        Try
            sSql = "UPDATE THOI_GIAN_NGUNG_MAY_SO_LAN SET LOCK = 0 WHERE MS_LAN = '" + gvLanngungmay.Rows(gvLanngungmay.CurrentRow.Index).Cells("MS_LAN").Value.ToString() + "'"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCapNhapUnLockTGNMKhongThanhCong", Commons.Modules.TypeLanguage))
        End Try
        lannm = "-1"
        refresh1()
        InitializeDatabase()
        InitializeForm()

    End Sub

    Private Sub gvLanngungmay_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles gvLanngungmay.UserDeletingRow
        Try
            'TrangThai = "Delete"
            Dim solan As String = gvLanngungmay.SelectedRows(0).Cells("MS_LAN").Value.ToString()
            If (XoaFlag = False) Then

                If Vietsoft.Information.MsgBox(Me, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    TrangThai = ""
                    e.Cancel = True
                    Exit Sub

                End If
            End If


            Dim SqlTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

            SqlTGNM.BeginTransaction()
            Try
                sStr = " DELETE THOI_GIAN_NGUNG_MAY_PHU_TUNG WHERE MS_LAN = '" & solan & "'"
                SqlTGNM.ExecuteNonQuery(CommandType.Text, sStr)
                SqlTGNM.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteTHOI_GIAN_NGUNG_MAY_CHI_TIET", solan)
                tbTG.DefaultView.RowFilter = "1=0"
                SqlTGNM.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteTHOI_GIAN_NGUNG_MAY_LAN", solan)
                SqlTGNM.CommitTransaction()
                TbTGNM.AcceptChanges()
                refresh1()
                tbTG.Clear()
            Catch ex As Exception
                SqlTGNM.RollbackTransaction()
                ' TrangThai = ""
                Vietsoft.Information.MsgBox(Me, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.[Error], MessageBoxDefaultButton.Button1)
                e.Cancel = True
            End Try

            '  TrangThai = ""
            'If TbTGNM.Rows.Count > 0 And flag1 = False Then
            '    gvLanngungmay.Rows(0).Cells(0).Selected = True
            '    getTGNM()
            'End If
            getTGNM()
        Catch
        End Try
    End Sub
    Dim flag1 As Boolean = False
    Dim XoaFlag As Boolean = False
    Private Sub gvThoigianngungmay_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles gvThoigianngungmay.UserDeletingRow

        If gvThoigianngungmay.Rows.Count = 1 Then
            flag1 = False
            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCon1DongChiTietNenKhongTheXoa", Commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = DialogResult.OK) Then
                XoaFlag = True
                gvLanngungmay_UserDeletingRow(Nothing, Nothing)
                gvLanngungmay.Rows.RemoveAt(gvLanngungmay.SelectedRows(0).Index)
                e.Cancel = True
                Exit Sub
            Else
                XoaFlag = False
                e.Cancel = True
                Exit Sub
            End If

        End If
        'TrangThai = "Delete"
        Dim SqlTGNM As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)
        Dim sStr As String

        ' Dim solan As String = gvLanngungmay.Rows(gvThoigianngungmay.CurrentRow.Index).Cells("MS_LAN").Value.ToString()

        SqlTGNM.BeginTransaction()
        Try


            sStr = "DELETE FROM THOI_GIAN_NGUNG_MAY WHERE MS_MAY = '" & gvThoigianngungmay.CurrentRow.Cells("MS_MAY").Value.ToString & "' " &
                " AND CONVERT(NVARCHAR(10),NGAY,103) = CONVERT(NVARCHAR(10),'" & DateTime.Parse(gvThoigianngungmay.CurrentRow.Cells("NGAY").Value.ToString).ToString("dd/MM/yyyy") & "',103)  " &
                " AND CONVERT(NVARCHAR(10),TU_GIO,108) = CONVERT(NVARCHAR(10), CONVERT(DATETIME,'" & DateTime.Parse(gvThoigianngungmay.CurrentRow.Cells("TU_GIO").Value.ToString).ToString("HH:mm:ss") & "'),108)  " &
                " AND CONVERT(NVARCHAR(10),DEN_NGAY,103) = CONVERT(NVARCHAR(10),'" & DateTime.Parse(gvThoigianngungmay.CurrentRow.Cells("DEN_NGAY").Value.ToString).ToString("dd/MM/yyyy") & "',103)  " &
                " AND CONVERT(NVARCHAR(10),DEN_GIO,108) = CONVERT(NVARCHAR(10),CONVERT(DATETIME,'" & DateTime.Parse(gvThoigianngungmay.CurrentRow.Cells("DEN_GIO").Value.ToString).ToString("HH:mm:ss") & "'),108)" &
                " AND MS_LAN = '" + lannm + "'"
            SqlTGNM.ExecuteNonQuery(CommandType.Text, sStr)
            SqlTGNM.CommitTransaction()


        Catch ex1 As Exception
            SqlTGNM.RollbackTransaction()
            'TrangThai = ""

            Vietsoft.Information.MsgBox(Me, "MsgDeleteError" + vbCrLf + ex1.Message, MessageBoxButtons.OK, MessageBoxIcon.[Error], MessageBoxDefaultButton.Button1)
            e.Cancel = True
        End Try
        Try
            ' TrangThai = ""
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        InitializeDatabase()
    End Sub

    Private Sub btnTroVe_Click(sender As Object, e As EventArgs) Handles btnTroVe.Click
        btnAdd.Visible = True
        btnXoa.Visible = True
        btnThoat.Visible = True
        btnCopy.Visible = True
        btnEdit.Visible = True
        btnCapNhapTG.Visible = False
        btnSave.Visible = False
        btnTroVe.Visible = False
        btnAddPT.Visible = True
        btnXoaCTiet.Visible = False
        btnXoaBoPhan.Visible = False
        btnXoaLanNgungMay.Visible = False
    End Sub

    Private Sub btnXoaCTiet_Click(sender As Object, e As EventArgs) Handles btnXoaCTiet.Click
        Try
            flag1 = True
            Dim index As Integer = gvThoigianngungmay.CurrentCell.RowIndex
            gvThoigianngungmay.Rows(index).Selected = True
            gvThoigianngungmay_UserDeletingRow(Nothing, Nothing)
            If (gvThoigianngungmay.RowCount > 0 And flag1 = True) Then
                Dim index1 As Integer = gvThoigianngungmay.SelectedRows(0).Index
                gvThoigianngungmay.Rows.RemoveAt(index1)
            End If
            flag1 = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnXoaLanNgungMay_Click(sender As Object, e As EventArgs) Handles btnXoaLanNgungMay.Click
        Try
            flag1 = True
            gvLanngungmay_UserDeletingRow(Nothing, Nothing)
            If (gvLanngungmay.RowCount > 0) Then
                Dim index As Integer = gvLanngungmay.SelectedRows(0).Index
                gvLanngungmay.Rows.RemoveAt(index)
                getTGNM()
            End If
            flag1 = False
        Catch ex As Exception
        End Try


    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        btnAdd.Visible = False
        btnXoa.Visible = False
        btnThoat.Visible = False
        btnCopy.Visible = False
        btnEdit.Visible = False
        btnCapNhapTG.Visible = False
        btnSave.Visible = False
        ''btnPrint.Visible = False
        btnXoaBoPhan.Visible = True
        btnTroVe.Visible = True
        btnXoaCTiet.Visible = True
        btnXoaLanNgungMay.Visible = True
        btnAddPT.Visible = False
    End Sub

    Private Sub btnAddPT_Click(sender As Object, e As EventArgs) Handles btnAddPT.Click
        If (gvLanngungmay.SelectedRows.Count = 1) Then
            panel1.Visible = False
            Panel2.Visible = True
            tableLayoutPanel3.Enabled = False
            fChuaLuu = True
            gvThoigianngungmay.Enabled = False
            bThemBP = True
            btnChonPT_Click(btnChonPT, Nothing)
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaCoMay", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

    Private Sub btnKhongGhi1_Click(sender As Object, e As EventArgs) Handles btnKhongGhi1.Click
        panel1.Visible = True
        Panel2.Visible = False
        gvLanngungmay.Enabled = True
        gvThoigianngungmay.Enabled = True
        tableLayoutPanel3.Enabled = True
        getBoPhanTheoMay(gvLanngungmay.SelectedRows(0).Index)

        bThemBP = False
    End Sub
    Dim bThemBP As Boolean = False
    Private Sub btnGhi1_Click(sender As Object, e As EventArgs) Handles btnGhi1.Click

        Dim sql As New SqlConnection(Commons.IConnections.ConnectionString)
        If sql.State = ConnectionState.Closed Then
            sql.Open()
        End If


        Dim tran As SqlTransaction = Nothing
        If bThemBP = True And dtBP.Rows.Count > 0 Then
            Try
                For Each row As DataRow In dtBP.Rows
                    If (row.RowState <> DataRowState.Deleted) Then
                        tran = sql.BeginTransaction()
                        SqlHelper.ExecuteNonQuery(tran, "spInsertThoiGianNgungMayBoPhanTheoMay", gvLanngungmay.SelectedRows(0).Cells("MS_MAY").Value.ToString(), gvLanngungmay.SelectedRows(0).Cells("MS_LAN").Value.ToString(),
                                            row("STT"), row("MS_BO_PHAN"), row("MS_PT"), row("MS_VI_TRI_PT"), row("DEL"))
                        tran.Commit()
                    End If
                Next
            Catch ex As Exception
                tran.Rollback()
                fChuaLuu = False
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgThemBPLoi", Commons.Modules.TypeLanguage) + vbLf + ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End Try
        End If
        fChuaLuu = True
        panel1.Visible = True
        Panel2.Visible = False
        gvLanngungmay.Enabled = True
        gvThoigianngungmay.Enabled = True
        tableLayoutPanel3.Enabled = True
        bThemBP = False
        getBoPhanTheoMay(gvLanngungmay.SelectedRows(0).Index)
    End Sub
    Dim dtPT As New DataTable()
    Dim sBTT As String = "ChonPhuTungChoMay" + Commons.Modules.UserName
    Dim fChuaLuu As Boolean = True
    Private Sub btnChonPT_Click(sender As Object, e As EventArgs) Handles btnChonPT.Click

        Try
            Commons.Modules.ObjSystems.XoaTable(sBTT)
        Catch
        End Try

        Try
            If (fChuaLuu = False) Then
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, dtBP, "")

            Else
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, DirectCast(grdPhuTungtheoMay.DataSource, DataTable), "")
            End If

            Dim frm As New VietShape.frmChonPTTuBoPhan()
            frm.MS_MAY = gvLanngungmay.SelectedRows(0).Cells("MS_MAY").Value.ToString()
            frm.StartPosition = FormStartPosition.CenterParent

            If frm.ShowDialog() = DialogResult.OK Then
                If frm.dtTTPT1.Rows.Count < 0 Then
                    Return
                End If
                fChuaLuu = False


                dtBP = New DataTable()
                dtBP = frm.dtTTPT1
                fChuaLuu = False
                frm.dtTTPT1.DefaultView.RowFilter = "DEL = 0"
                frm.dtTTPT1 = frm.dtTTPT1.DefaultView.ToTable()

                Commons.Modules.ObjSystems.XoaTable(sBTT)
                grdPhuTungtheoMay.DataSource = Nothing
                grdPhuTungtheoMay.DataSource = frm.dtTTPT1

                grdPhuTungtheoMay.Columns("MS_LAN").Visible = False
                grdPhuTungtheoMay.Columns("MS_MAY").Visible = False
                grdPhuTungtheoMay.Columns("STT").Visible = False

                grdPhuTungtheoMay.Columns("MS_PT").DisplayIndex = 5
                grdPhuTungtheoMay.Columns("MS_VI_TRI_PT").DisplayIndex = 6
                grdPhuTungtheoMay.Columns("TEN_PT").DisplayIndex = 7

                grdPhuTungtheoMay.Columns("DEL").Visible = False
                grdPhuTungtheoMay.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPTTuBoPhan", "TEN_PT", Commons.Modules.TypeLanguage)
                grdPhuTungtheoMay.Columns("MS_VI_TRI_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonPTTuBoPhan", "MS_VI_TRI_PT", Commons.Modules.TypeLanguage)
                grdPhuTungtheoMay.Columns("MS_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_BO_PHAN", Commons.Modules.TypeLanguage)
                grdPhuTungtheoMay.Columns("TEN_BO_PHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
                grdPhuTungtheoMay.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
                grdPhuTungtheoMay.Columns("MS_BO_PHAN").Width = 150
                grdPhuTungtheoMay.Columns("TEN_BO_PHAN").Width = 250
                grdPhuTungtheoMay.Columns("MS_PT").Width = 155
                grdPhuTungtheoMay.Columns("TEN_PT").Width = 250
                grdPhuTungtheoMay.Columns("MS_VI_TRI_PT").Width = 130
                Me.grdPhuTungtheoMay.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdPhuTungtheoMay.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Else
                Try
                    Commons.Modules.ObjSystems.XoaTable(sBT)
                Catch
                End Try
            End If
        Catch ex As Exception
            Commons.Modules.ObjSystems.XoaTable(sBTT)
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim dtBP As New DataTable()
    Dim sBT As String = "ChonBoPhanChoMay" + Commons.Modules.UserName

    Private Sub btnXoaBoPhan_Click(sender As Object, e As EventArgs) Handles btnXoaBoPhan.Click

        If (grdPhuTungtheoMay.RowCount > 0) Then
            If (grdPhuTungtheoMay.SelectedRows.Count = 1) Then

                If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                 Commons.Modules.ModuleName, Me.Name, "msgChacChanXoa", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes) Then
                    flag1 = True
                    'Dim index As Integer = grdPhuTungtheoMay.CurrentCell.RowIndex
                    'grdPhuTungtheoMay.Rows(index).Selected = True
                    grdPhuTungtheoMay_UserDeletingRow(Nothing, Nothing)
                    If (grdPhuTungtheoMay.RowCount > 0 And flag1 = True) Then
                        Dim index1 As Integer = grdPhuTungtheoMay.SelectedRows(0).Index
                        grdPhuTungtheoMay.Rows.RemoveAt(index1)
                    End If
                    flag1 = False
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgVuiLongChonBPCanXoa", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If



    End Sub
    Private Sub grdPhuTungtheoMay_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles grdPhuTungtheoMay.UserDeletingRow
        Try
            If (grdPhuTungtheoMay.SelectedRows.Count = 1) Then
                Dim str As String = "DELETE THOI_GIAN_NGUNG_MAY_PHU_TUNG WHERE STT = " + grdPhuTungtheoMay.SelectedRows(0).Cells("STT").Value.ToString()
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        Catch ex1 As Exception
            flag1 = False
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKhongTheXoa", Commons.Modules.TypeLanguage) + "\n" + ex1.Message, "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Function GetLocation(ByVal edit As Windows.Forms.TextBox, ByVal mousePosition As Point, ByVal menu As ContextMenuStrip)
        If (edit Is Nothing) Then Return mousePosition
        Return edit.PointToScreen(New Point(mousePosition.X - menu.Size.Width + edit.Size.Width, mousePosition.Y + edit.Size.Height))
    End Function

    'Private Sub btnNguoiGiaiQuyet_MouseDown(sender As Object, e As MouseEventArgs) Handles 'btnNguoiGiaiQuyet.MouseDown
    '    If (e.Button = MouseButtons.Right) Then Exit Sub
    '    Dim menu As New ContextMenuStrip()
    '    Dim dtTable As New DataTable
    '    dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, Commons.Modules.UserName))
    '    If (dtTable.Rows.Count = 0) Then
    '        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKhongCoCongNhan", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '        Return
    '    End If
    '    Dim i As Integer = 0
    '    For Each dr As DataRow In dtTable.Rows
    '        menu.Items.Add(dr("HO_TEN_CONG_NHAN"))

    '        AddHandler menu.Items(i).Click, AddressOf Me.menu_Click
    '        i = i + 1
    '    Next
    '    menu.Size = New Size(200, If(menu.Size.Height > 600, 600, menu.Size.Height))

    '    menu.Show(GetLocation(txtNguoiGiaiQuyet, txtNguoiGiaiQuyet.Parent.Location, menu))
    'End Sub

    'Private Sub menu_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    txtNguoiGiaiQuyet.Text = CType(sender, ToolStripMenuItem).Text
    '    For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1

    '        Dim str As String = ""
    '        Try
    '            str = gvThoigianngungmay.Rows(i).Cells("NGUOI_GIAI_QUYET").Value.ToString()
    '        Catch ex As Exception

    '        End Try
    '        If (str.Trim() = "") Then
    '            gvThoigianngungmay.Rows(i).Cells("NGUOI_GIAI_QUYET").Value = txtNguoiGiaiQuyet.Text
    '        End If

    '    Next

    'End Sub

    'Private Sub menu_Click1(ByVal sender As Object, ByVal e As EventArgs)
    '    txtTruongCa.Text = CType(sender, ToolStripMenuItem).Text
    '    For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
    '        Dim str As String = ""
    '        Try
    '            str = gvThoigianngungmay.Rows(i).Cells("TRUONG_CA").Value.ToString()
    '        Catch ex As Exception

    '        End Try
    '        If (str.Trim() = "") Then
    '            gvThoigianngungmay.Rows(i).Cells("TRUONG_CA").Value = txtTruongCa.Text
    '        End If


    '    Next
    'End Sub
    'Private Sub btnTruongCa_MouseDown(sender As Object, e As MouseEventArgs) Handles 'btnTruongCa.MouseDown
    '    Dim menu As New ContextMenuStrip()
    '    Dim dtTable As New DataTable
    '    dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 6, Commons.Modules.UserName))

    '    If (dtTable.Rows.Count = 0) Then
    '        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKhongCoCongNhan", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '        Return
    '    End If
    '    Dim i As Integer = 0
    '    For Each dr As DataRow In dtTable.Rows
    '        menu.Items.Add(dr("HO_TEN_CONG_NHAN"))
    '        AddHandler menu.Items(i).Click, AddressOf Me.menu_Click1
    '        i = i + 1

    '    Next
    '    menu.Size = New Size(200, If(menu.Size.Height > 600, 600, menu.Size.Height))
    '    menu.Show(GetLocation(txtTruongCa, txtTruongCa.Parent.Location, menu))
    'End Sub

    Private Sub frmThoiGianNgungMayNew_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        'If Me.Width > 1024 Then
        '    SplitContainerControl1.SplitterPosition = 478
        'Else
        '    SplitContainerControl1.SplitterPosition = 290

        'End If

    End Sub

    Private Sub LoadCa()
        Try
            Dim dtTable As New DataTable
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCaTheoGio", dtpGioKT.Value, Commons.Modules.TypeLanguage))
            If (dtTable.Rows.Count > 0) Then
                cboCa.SelectedValue = dtTable.Rows(0)(0).ToString()
            Else
                cboCa.SelectedValue = "-1"
            End If
        Catch ex As Exception
            cboCa.SelectedValue = "-1"
        End Try
    End Sub


    Private Sub dtpGioBD_ValueChanged(sender As Object, e As EventArgs) Handles dtpGioBD.ValueChanged, dtpGioKT.ValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        If btnSave.Visible = True Then
            LoadCa()
        End If

    End Sub

    Private Sub CreateMenuPT(ByVal grd As DataGridView)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd

        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoiGianNgungMayNew", "mnuAddMoreRowDownTime", Commons.Modules.TypeLanguage)

        Dim mnuAddRow As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuAddRow.Name = "mnuAddRow"


        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuAddRow})

        BarManager.EndUpdate()
    End Sub

    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        'Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
        'Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
        'If Not subMenu Is Nothing Then Return

        'Dim grd As DataGridView = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DataGridView)
        Try
            Dim dt As New DataTable()
            Select Case e.Item.Name.ToUpper
                Case "mnuAddRow".ToUpper
                    AddThemThoiGianChiTiet()
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gvThoigianngungmay_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gvThoigianngungmay.CellMouseDown
        If btnSave.Visible = False Then Exit Sub
        If gvThoigianngungmay.RowCount = 0 Then Exit Sub
        If e.RowIndex = -1 Then Exit Sub
        If e.ColumnIndex = -1 Then Exit Sub
        If e.Button <> MouseButtons.Right Then Exit Sub
        gvThoigianngungmay.ClearSelection()
        gvThoigianngungmay.Rows(e.RowIndex).Selected = True
        indexGrivChiTiet = e.RowIndex
        CreateMenuPT(gvThoigianngungmay)

    End Sub
    Private indexGrivChiTiet As Integer = -1
    Private Sub AddThemThoiGianChiTiet()
        Try
            Dim ngay As DateTime = Convert.ToDateTime(gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("NGAY").Value, New CultureInfo("vi-vn"))
            Dim gio As DateTime = Convert.ToDateTime(gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("DEN_GIO").Value, New CultureInfo("vi-vn")).AddMinutes(1)
            Dim NgayKT As DateTime = Convert.ToDateTime(gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("DEN_NGAY").Value, New CultureInfo("vi-vn"))
            Dim GioKT As DateTime = Convert.ToDateTime(gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("DEN_GIO").Value, New CultureInfo("vi-vn")).AddMinutes(1)


            Dim MS_N_XUONG As Object = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("MS_N_XUONG").Value
            Dim MS_HE_THONG As Object = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("MS_HE_THONG").Value
            Dim MS_MAY As Object = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("MS_MAY").Value



            Dim dtTmp As DataTable
            dtTmp = CType(gvThoigianngungmay.DataSource, DataTable)

            vtungay = New DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0)
            vdenngay = New DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0)


            Dim stime As Integer = (vdenngay - vtungay).Days * 24 * 60 + (vdenngay - vtungay).Hours * 60 + (vdenngay - vtungay).Minutes


            Dim dr As DataRow
            dr = dtTmp.NewRow
            dr.Item("NGAY") = If(gio.ToString("HH:mm") = "00:00", ngay.AddDays(1).ToString("dd/MM/yyyy"), ngay.ToString("dd/MM/yyyy"))
            dr.Item("TU_GIO") = gio.ToString("HH:mm:ss")
            dr.Item("DEN_NGAY") = If(GioKT.ToString("HH:mm") = "00:00", NgayKT.AddDays(1).ToString("dd/MM/yyyy"), NgayKT.ToString("dd/MM/yyyy"))
            dr.Item("DEN_GIO") = GioKT.ToString("HH:mm:ss")
            dr.Item("THOI_GIAN_NGUNG_MAY") = stime
            dr.Item("THOI_GIAN_SUA_CHUA") = stime
            dr.Item("MS_N_XUONG") = MS_N_XUONG
            dr.Item("MS_HE_THONG") = MS_HE_THONG
            dr.Item("MS_MAY") = MS_MAY

            dr.Item("MS_NGUYEN_NHAN") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("MS_NGUYEN_NHAN").Value
            dr.Item("NN_CGQ") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("CACH_GIAI_QUYET").Value

            dr.Item("HIEN_TUONG") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("HIEN_TUONG").Value
            dr.Item("NGUYEN_NHAN_CU_THE") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("NGUYEN_NHAN_CU_THE").Value
            dr.Item("GHI_CHU") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("GHI_CHU").Value
            dr.Item("NGUOI_GIAI_QUYET") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("NGUOI_GIAI_QUYET").Value
            dr.Item("TRUONG_CA") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("TRUONG_CA").Value
            dr.Item("CaID") = gvThoigianngungmay.Rows(indexGrivChiTiet).Cells("CaID").Value


            dtTmp.Rows.InsertAt(dr, indexGrivChiTiet + 1)

            tbTG = New DataTable()
            tbTG = dtTmp

            gvThoigianngungmay.DataSource = Nothing
            gvThoigianngungmay.DataSource = tbTG

            gvThoigianngungmay.ClearSelection()

            gvThoigianngungmay.Rows(indexGrivChiTiet + 1).Selected = True


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCa_Click(sender As Object, e As EventArgs) Handles btnCa.Click
        Dim frmCa As Report1.frmCa = New Report1.frmCa()
        'If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmCa.Name) Then
        frmCa.StartPosition = FormStartPosition.CenterParent
        frmCa.ShowDialog()
        LoadCa()

        Dim comboBoxColumn As DataGridViewComboBoxColumn = DirectCast(gvThoigianngungmay.Columns("CaID"), DataGridViewComboBoxColumn)


        Dim TbCa As DataTable = New System.Data.DataTable()
        TbCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_CA", Commons.Modules.TypeLanguage))

        comboBoxColumn.DataSource = TbCa




        'End If
    End Sub

    Private Sub cboCa_KeyDown(sender As Object, e As KeyEventArgs) Handles cboCa.KeyDown
        e.SuppressKeyPress = True
    End Sub


    Private Sub cboDiaDiem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDiaDiem.SelectedIndexChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Try
            _Loc.Clear()
            lannm = "-1"
            refresh1()
            InitializeDatabase()
            InitializeForm()
        Catch
        End Try
    End Sub

    Private Sub txtNNCuThe_Validated(sender As Object, e As EventArgs) Handles txtNNCuThe.Validated
        For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1

            Dim str As String = ""
            Try
                str = gvThoigianngungmay.Rows(i).Cells("NGUYEN_NHAN_CU_THE").Value.ToString()
            Catch ex As Exception

            End Try
            If (str.Trim() = "") Then
                gvThoigianngungmay.Rows(i).Cells("NGUYEN_NHAN_CU_THE").Value = txtNNCuThe.Text
            End If

            'gvThoigianngungmay.Rows(i).Cells("NGUYEN_NHAN_CU_THE").Value = If(String.IsNullOrEmpty(gvThoigianngungmay.Rows(i).Cells("NGUYEN_NHAN_CU_THE").Value), txtNNCuThe.Text, gvThoigianngungmay.Rows(i).Cells("NGUYEN_NHAN_CU_THE").Value)
        Next
    End Sub

    Private Sub txtHTuong_Validated(sender As Object, e As EventArgs) Handles txtHTuong.Validated
        For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
            'gvThoigianngungmay.Rows(i).Cells("HIEN_TUONG").Value = If(String.IsNullOrEmpty(gvThoigianngungmay.Rows(i).Cells("HIEN_TUONG").Value), txtHTuong.Text, gvThoigianngungmay.Rows(i).Cells("HIEN_TUONG").Value)


            Dim str As String = ""
            Try
                str = gvThoigianngungmay.Rows(i).Cells("HIEN_TUONG").Value.ToString()
            Catch ex As Exception

            End Try
            If (str.Trim() = "") Then
                gvThoigianngungmay.Rows(i).Cells("HIEN_TUONG").Value = txtHTuong.Text
            End If
        Next
    End Sub

    Private Sub txtNguyennhan_Validated(sender As Object, e As EventArgs) Handles txtNguyennhan.Validated
        For i As Integer = 0 To gvThoigianngungmay.Rows.Count - 1
            Dim str As String = ""
            Try
                str = gvThoigianngungmay.Rows(i).Cells("CACH_GIAI_QUYET").Value.ToString()
            Catch ex As Exception
            End Try
            If (str.Trim() = "") Then
                gvThoigianngungmay.Rows(i).Cells("CACH_GIAI_QUYET").Value = txtNguyennhan.Text
            End If
        Next
    End Sub

    Private Sub cboNguoiGiaiQuyet_EditValueChanged(sender As Object, e As EventArgs) Handles cboNguoiGiaiQuyet.EditValueChanged
        If (btnSave.Visible = True) Then
            txtNguoiGiaiQuyet.Text = cboNguoiGiaiQuyet.EditValue.ToString()
        End If


    End Sub

    Private Sub cboTruongCa_EditValueChanged(sender As Object, e As EventArgs) Handles cboTruongCa.EditValueChanged
        If (btnSave.Visible = True) Then
            txtTruongCa.Text = cboTruongCa.EditValue.ToString()
        End If
    End Sub



    Private Sub cboNguoiGiaiQuyet_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles cboNguoiGiaiQuyet.Closed
        cboNguoiGiaiQuyet_EditValueChanged(cboNguoiGiaiQuyet, Nothing)
    End Sub

    Private Sub cboTruongCa_Closed(sender As Object, e As Controls.ClosedEventArgs) Handles cboTruongCa.Closed
        cboTruongCa_EditValueChanged(cboTruongCa, Nothing)
    End Sub
End Class

