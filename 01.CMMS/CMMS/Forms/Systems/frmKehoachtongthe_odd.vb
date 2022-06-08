Imports Commons.VS.Classes.Admin
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
'Imports Microsoft.VisualBasic.DateAndTime
Imports DevExpress.XtraGrid.Views.Grid
Imports Commons
Imports DevExpress.XtraCharts
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTab
Imports MVControl

Public Class frmKehoachtongthe_odd
    Private bHienthi As Integer
    Private bISUSE_KHBT As Boolean
    Private bShowMonitoring As Boolean = False
    Private objLichBTPN As New clsLichBTPN
    Private dtReader As SqlDataReader
    Private intTabInd As Integer = -1, rowCount As Integer, ind As Integer = -1, rowCount1 As Integer, rowCount2 As Integer
    Private tmp_cv As Integer = -1, tmp_pt As Integer = -1
    Public blnThemSua As Boolean = False
    Private SqlText As String
    Private noDataToPrint As Boolean = True
    Private indOldPos As Integer = -1, indNewPos As Integer = -1
    Private arrStr As String = ""
    Private str() As String
    Private intRowYeuCauNSD As Integer = -1
    Private count As Integer = 0
    Private isFirst As Boolean = False
    Private repositoryItemLookUpEdit2 As Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit3 As Repository.RepositoryItemLookUpEdit
    Private repositoryItemDateEdit1 As Repository.RepositoryItemDateEdit
    Private repositoryItemLookUpEdit4 As Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit5 As Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit6 As Repository.RepositoryItemLookUpEdit
    Private repositoryItemChoose As Repository.RepositoryItemCheckEdit
    Private cboMsUTien As Repository.RepositoryItemLookUpEdit
    Private cboCNPTrach As Repository.RepositoryItemLookUpEdit

    Private dtTable_CV As New DataTable
    Private dtTable_CV_TEMP As New DataTable
    Private dtTable_PT As New DataTable

    Private _temp As New DataTable
    Private dtTable_KHTT_TEMP As New DataTable
    Private dtTable_KHTT As New DataTable
    Dim j As Integer = 0
    Dim success As Boolean = True
    Dim ucMonitor As MVControl.ucMonitoring
    Sub New()
        ''load tab monitoring
        'Commons.Modules.SQLString = "0Load"
        InitializeComponent()
        'ucMonitor = New ucMonitoring()
        'ucMonitor.Dock = DockStyle.Fill
        'ucMonitor.Name = "ucMonitor"
        'ucMonitor.Location = New Point(0, 0)
        'TabMonitoring.Controls.Add(ucMonitor)
        'Commons.Modules.SQLString = ""
    End Sub

    Private Sub PrepareData()

        Dim _tblMay As New DataTable
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLY_DO_SUA_CHUA", Commons.Modules.TypeLanguage))
        repositoryItemLookUpEdit2 = New Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit2.NullText = ""
        repositoryItemLookUpEdit2.ValueMember = "MS_LY_DO"
        repositoryItemLookUpEdit2.DisplayMember = "TEN_LY_DO"
        repositoryItemLookUpEdit2.DataSource = _tblMay
        repositoryItemLookUpEdit2.Columns.Clear()
        repositoryItemLookUpEdit2.Columns.Add(New Controls.LookUpColumnInfo("TEN_LY_DO"))

        repositoryItemDateEdit1 = New Repository.RepositoryItemDateEdit()
        repositoryItemDateEdit1.EditMask = "dd/MM/yyyy"
        repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy"
        repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy"
        repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy"
        repositoryItemDateEdit1.Mask.MaskType = Mask.MaskType.DateTimeAdvancingCaret
        _tblMay = New DataTable()
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))

        repositoryItemLookUpEdit3 = New Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit3.NullText = ""
        repositoryItemLookUpEdit3.ValueMember = "MS_UU_TIEN"
        repositoryItemLookUpEdit3.DisplayMember = "TEN_UU_TIEN"
        repositoryItemLookUpEdit3.DataSource = _tblMay
        repositoryItemLookUpEdit3.Columns.Clear()
        repositoryItemLookUpEdit3.Columns.Add(New Controls.LookUpColumnInfo("TEN_UU_TIEN"))
        'AddHandler repositoryItemLookUpEdit3.EditValueChanged, AddressOf repositoryItemLookUpEdit3_EditValueChanged


        cboMsUTien = New Repository.RepositoryItemLookUpEdit()
        cboMsUTien.NullText = ""
        cboMsUTien.ValueMember = "MS_UU_TIEN"
        cboMsUTien.DisplayMember = "TEN_UU_TIEN"
        cboMsUTien.DataSource = _tblMay
        cboMsUTien.Columns.Clear()
        cboMsUTien.Columns.Add(New Controls.LookUpColumnInfo("TEN_UU_TIEN"))

        _tblMay = New DataTable()
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs"))
        repositoryItemLookUpEdit6 = New Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit6.NullText = ""
        repositoryItemLookUpEdit6.ValueMember = "MS_CONG_NHAN"
        repositoryItemLookUpEdit6.DisplayMember = "HO_TEN_CONG_NHAN"
        repositoryItemLookUpEdit6.DataSource = _tblMay
        repositoryItemLookUpEdit6.Columns.Clear()
        repositoryItemLookUpEdit6.Columns.Add(New Controls.LookUpColumnInfo("HO_TEN_CONG_NHAN"))

        _tblMay = New DataTable
        _tblMay.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCongNhanPBTTN", 2, "-1"))
        cboCNPTrach = New Repository.RepositoryItemLookUpEdit()
        cboCNPTrach.NullText = ""
        cboCNPTrach.ValueMember = "MS_CONG_NHAN"
        cboCNPTrach.DisplayMember = "HO_TEN_CONG_NHAN"
        cboCNPTrach.DataSource = _tblMay
        cboCNPTrach.Columns.Clear()
        cboCNPTrach.Columns.Add(New Controls.LookUpColumnInfo("HO_TEN_CONG_NHAN"))
    End Sub



    Private Sub repositoryItemLookUpEdit4_EditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) ' Handles radCongviecchinh.CheckedChanged

        Try
            'LookUpEdit cbo = (LookUpEdit)sender
            Dim cbo As LookUpEdit
            cbo = CType(sender, LookUpEdit)
            If cbo.EditValue <> "04" Then
                gvTSGSTT.Columns("MS_PBT").OptionsColumn.AllowEdit = False
                gvTSGSTT.SetFocusedRowCellValue("MS_PBT", vbNull)
                Exit Sub
            End If
            Dim tb As New DataTable()
            Dim str As String
            Dim NgayKT As DateTime
            Try
                NgayKT = gvTSGSTT.GetFocusedDataRow()("NGAY_GIO_KT_MAX")
            Catch ex As Exception
                NgayKT = Now
            End Try
            str = "SELECT DISTINCT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & gvTSGSTT.GetFocusedDataRow()("MS_MAY") & "' " &
                                " AND TINH_TRANG_PBT IN (4,5) And NGAY_NGHIEM_THU >='" & NgayKT.ToString("MM/dd/yyyy") & "'"
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            If tb.Rows.Count = 0 Then
                Commons.MssBox.Show(Me.Name, "msgChuaCoPBTCoNgayNghiemThuLonHonNgayGiamSat")
                gvTSGSTT.SetFocusedRowCellValue("MS_CACH_TH", "00")
                cbo.EditValue = "00"
                gvTSGSTT.SetFocusedRowCellValue("MS_PBT", vbNull)
                gvTSGSTT.Columns("MS_PBT").OptionsColumn.AllowEdit = False
                Exit Sub
            End If
            Dim dr As DataRow
            dr = tb.NewRow
            dr.Item("MS_PHIEU_BAO_TRI") = tb.Rows(0).Item(0)
            tb.Rows.InsertAt(dr, 0)
            If tb.Rows.Count > 0 Then
                repositoryItemLookUpEdit5.DataSource = Nothing
                repositoryItemLookUpEdit5.NullText = ""
                repositoryItemLookUpEdit5.ValueMember = "MS_PHIEU_BAO_TRI"
                repositoryItemLookUpEdit5.DisplayMember = "MS_PHIEU_BAO_TRI"
                repositoryItemLookUpEdit5.DataSource = tb
                repositoryItemLookUpEdit5.Columns.Clear()
                repositoryItemLookUpEdit5.Columns.Add(New Controls.LookUpColumnInfo("MS_PHIEU_BAO_TRI"))
            End If
            gvTSGSTT.Columns("MS_PBT").OptionsColumn.AllowEdit = True

        Catch ex As Exception

        End Try


    End Sub



    Private Sub frmkehoachtongthe_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Commons.Modules.ObjSystems.XoaTable("CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName)

        Commons.Modules.SQLString = "DU_LIEU_BAO_CAO_KHBT_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "MAY_LOAI_BTPN_CHU_KY_MAX" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "DL_BTDK" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "PHU" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "NGAY_CUOI_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "BT_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "PHU" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "PHU1" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "GIAM_SAT_TINH_TRANG_TS_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "GIAM_SAT_TINH_TRANG_TS_DT_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "YEU_CAU_NSD_TMP1" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "YEU_CAU_NSD_TMP2" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "KE_HOACH_TONG_THE_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "KE_HOACH_TONG_CONG_VIEC_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "KHTT_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "KHTCV_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "KHTCVPT_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "ADDKHTTTMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "UPDATEKHTTTMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "ADDKHTCVTMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "UPDATEKHTCVTMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "ADDKHTCVPTTMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "UPDATEKHTCVPTTMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.Modules.SQLString = "insert_rptKE_HOACH_TONG_THE_PHU_TUNG_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(Commons.Modules.SQLString)

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName)

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU_TONG_SO_VTPT")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptKE_HOACH_TONG_THE_PHU_TUNG_TMP")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_BTDK")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_DU_TRU_VT_THEO_MAY")


    End Sub

    Private Sub dtpTNGSTT_EditValueChanged(sender As Object, e As EventArgs)
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        LoadDataTSGSTT()
    End Sub

    Private Sub frmKehoachtongthe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabMonitoring.Visible = False

        TableLayoutPanel1.ColumnStyles(0).Width = 0
        TableLayoutPanel1.ColumnStyles(TableLayoutPanel1.ColumnCount - 1).Width = 0

        Me.Cursor = Cursors.WaitCursor
        Commons.Modules.SQLString = "0Load"
        AddHandler dtpDNGSTT.EditValueChanged, AddressOf Me.dtpTNGSTT_EditValueChanged
        AddHandler dtpTNGSTT.EditValueChanged, AddressOf Me.dtpTNGSTT_EditValueChanged

        RemoveHandler dtpTNYCSD.EditValueChanged, AddressOf Me.dtpTNYCSD_EditValueChanged
        RemoveHandler dtpDNYCSD.EditValueChanged, AddressOf Me.dtpTNYCSD_EditValueChanged


        dtpTNKHTT.DateTime = DateSerial(Year(Now), Month(Now), 1)
        dtpDNKHTT.DateTime = DateSerial(Year(Now), Month(Now), 1).AddMonths(1).AddDays(-1)

        dtpTNGSTT.DateTime = dtpTNKHTT.DateTime
        dtpDNGSTT.DateTime = dtpDNKHTT.DateTime

        dtpTuNgay.Value = dtpTNKHTT.DateTime
        dtpDenNgay.Value = dtpDNKHTT.DateTime

        Try
            bHienthi = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 ISNULL(HIEN_THI_YCBT,0) FROM THONG_TIN_CHUNG"))
        Catch ex As Exception
            bHienthi = 0
        End Try
        If bHienthi = 0 Then tabKeHoachTongThe.TabPages.Remove(TabYeucaunguoisudung)
        LoadCACHTHUCHIEN1()
        LoadcboDiadiem()
        LoadcboDayChuyen()
        LoadLoaiMay()
        LoadNhomMay()
        LoadMay()
        PrepareData()
        HideButton(False)
        LoadNguoiLap()
        Commons.Modules.SQLString = ""
        radChuaGiaiQuyet1.Checked = True
        dtTable_CV_TEMP = dtTable_CV.Copy()
        dtTable_CV_TEMP.Clear()
        dtTable_KHTT_TEMP = dtTable_KHTT.Copy()
        dtTable_KHTT_TEMP.Clear()

        For Each col As DataColumn In dtTable_CV_TEMP.Columns
            col.AllowDBNull = True
        Next
        For Each col As DataColumn In dtTable_KHTT_TEMP.Columns
            col.AllowDBNull = True
        Next

        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
            btnThucHien1.Enabled = False
            btnThucHien2.Enabled = False
            BtnLapKHTT.Enabled = False
            BtnLapPBT.Enabled = False
            BtnChonTatCa.Enabled = False
            BtnBoChonTatCa.Enabled = False
            BtnLapKHTT1.Enabled = False
            BtnLapPBT1.Enabled = False

            'NONN.Visible = False
            'BtnChonTatCa1.Visible = False
            'BtnBoChonTatCa1.Visible = False
            btnLydosuachua.Visible = False
            btnXemNguyenNhan.Visible = False
            btnCapNhatMUT.Visible = False
            btnLPBT.Visible = False
            BtnThem1.Visible = False
            btnXoa.Visible = False
            BtnIn.Visible = False


            btnAllGSTT.Visible = False
            btnNotAllGSTT.Visible = False
            btnXemBangChung1.Visible = False
            btnHuy.Visible = False
            btnThucHien1.Visible = False

            btnXemBangChung2.Visible = False
            btnThucHien2.Visible = False

            BtnChonTatCa.Visible = False
            BtnBoChonTatCa.Visible = False
            BtnLapKHTT.Visible = False
            BtnLapPBT.Visible = False
            btnInBTDK.Visible = False

            btnAllBTDKTheoGio.Visible = False
            btnNotAllBTDKTheoGio.Visible = False
            BtnLapKHTT1.Visible = False
            BtnLapPBT1.Visible = False
            btnInGio.Visible = False



        End If

        Try
            bISUSE_KHBT = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 ISNULL(ISUSE_KHBT,0) FROM THONG_TIN_CHUNG"))
        Catch ex As Exception
            bISUSE_KHBT = False
        End Try

        If bISUSE_KHBT Then
            tabKeHoachTongThe.TabPages.Remove(tabKeHoachTT)
            BtnLapKHTT.Visible = False
            BtnLapKHTT1.Visible = False
        End If

        If Commons.Modules.LicID <> 0 Then LoadVersion()
        Me.Cursor = Cursors.Default
        Commons.Modules.SQLString = ""

        Try
            EnalbeGrid(False)
        Catch ex As Exception
        End Try

        cboNguoiLap.EditValue = Commons.Modules.sMaNhanVienMD
        cboNGSat.EditValue = Commons.Modules.sMaNhanVienMD
        cboNguoiLap1.EditValue = Commons.Modules.sMaNhanVienMD
        Try
            gvKHTT.Columns("Choose").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Catch ex As Exception
        End Try
        gvKHTT.Columns("MS_MAY").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        gvKHTT.Columns("TEN_MAY").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        CreateTableDataMonitoring()
        DockPanel1.Hide()
        TableLayoutPanel4.RowStyles.Item(TableLayoutPanel4.GetRow(prbLapPhieuBaoTri)).Height = 0
        prbLapPhieuBaoTri.Visible = False
        CreateMenuMay(gdKHTT)
        CreateMenuPT(gdVTTT)
        CreateMenuCV(gdCVTT)
        CreateMenuGSTT(gdTSGSTT)
        Try
            Dim str As String = "SELECT ISNULL(MUC_UU_TIEN, 0) AS MUC_UU_TIEN FROM THONG_TIN_CHUNG"
            btnMucUuTienFlag = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str))
        Catch ex As Exception
        End Try
        Dim ToolTip1 As System.Windows.Forms.ToolTip = New System.Windows.Forms.ToolTip()
        ToolTip1.SetToolTip(btnCapNhatMUT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MucUuTienHint", Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Tong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTong", Commons.Modules.TypeLanguage)
        Chon = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON", Commons.Modules.TypeLanguage)
        lblTong.Text = Tong & ": " & gvKHTT.RowCount.ToString()
        TabMonitoring.Visible = False

    End Sub
    Dim Tong As String = ""
    Dim Chon As String = ""
    Dim btnMucUuTienFlag = False
#Region "Hyperlink"
    Private Sub CreateMenuMay(ByVal grd As DevExpress.XtraGrid.GridControl)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkMay", Commons.Modules.TypeLanguage)
        Dim mnuMay As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuMay.Name = "mnuMay"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim mnuPhieuBaoTri As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuPhieuBaoTri.Name = "mnuPhieuBaoTri"


        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuMay, mnuPhieuBaoTri})

        BarManager.EndUpdate()
    End Sub
    Private Sub CreateMenuGridBaoTri(ByVal grd As DevExpress.XtraGrid.GridControl)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()
        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)
        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkMay", Commons.Modules.TypeLanguage)
        Dim mnuMay As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuMay.Name = "mnuMay"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuLapPhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim mnuPhieuBaoTri As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuPhieuBaoTri.Name = "mnuPhieuBaoTri"

        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuMay, mnuPhieuBaoTri})
        BarManager.EndUpdate()
    End Sub



    Private Sub CreateMenuCV(ByVal grd As DevExpress.XtraGrid.GridControl)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd
        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkCongViec", Commons.Modules.TypeLanguage)
        Dim mnuCongViec As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuCongViec.Name = "mnuCongViec"
        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuCongViec})
        BarManager.EndUpdate()
    End Sub

    Private Sub CreateMenuPT(ByVal grd As DevExpress.XtraGrid.GridControl)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = gdVTTT

        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        BarManager.SetPopupContextMenu(gdVTTT, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhuTung", Commons.Modules.TypeLanguage)

        Dim mnuPhuTung As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuPhuTung.Name = "mnuPhuTung"

        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuPhuTung})

        BarManager.EndUpdate()
    End Sub
    Private Sub CreateMenuGSTT(ByVal grd As DevExpress.XtraGrid.GridControl)
        Dim BarManager As New DevExpress.XtraBars.BarManager
        BarManager.Form = grd

        AddHandler BarManager.ItemClick, AddressOf barManager_ItemClick
        BarManager.BeginUpdate()

        Dim popup As New DevExpress.XtraBars.PopupMenu(BarManager)
        AddHandler popup.BeforePopup, AddressOf popupMenu1_BeforePopup

        BarManager.SetPopupContextMenu(grd, popup)

        Dim sStr As String
        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTT", Commons.Modules.TypeLanguage)

        Dim mnuGSTT As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuGSTT.Name = "mnuGSTT"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTTCNhap", Commons.Modules.TypeLanguage)
        Dim mnuGSTTCNhap As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuGSTTCNhap.Name = "mnuGSTTCNhap"

        sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhieuBaoTri", Commons.Modules.TypeLanguage)
        Dim mnuPhieuBaoTri As New DevExpress.XtraBars.BarButtonItem(BarManager, sStr)
        mnuPhieuBaoTri.Name = "mnuPhieuBaoTri"

        popup.AddItems(New DevExpress.XtraBars.BarItem() {mnuGSTT, mnuGSTTCNhap, mnuPhieuBaoTri})
        BarManager.EndUpdate()
    End Sub
    Dim frmDanhmuccongviec As MVControl.frmDanhmuccongviec
    Dim countFrm As Integer = 0

    Private Sub popupMenu1_BeforePopup(sender As Object, e As System.EventArgs)
        If Commons.Modules.PermisString.Equals("Read only") Then Exit Sub

        If RadBoQua2.Checked Then
            TryCast(sender, DevExpress.XtraBars.PopupMenu).ItemLinks(2).Item.Enabled = False
        Else
            TryCast(sender, DevExpress.XtraBars.PopupMenu).ItemLinks(2).Item.Enabled = True
        End If

        If radDaGiaiQuyet2.Checked Then
            TryCast(sender, DevExpress.XtraBars.PopupMenu).ItemLinks(2).Item.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhieuBaoTri", Commons.Modules.TypeLanguage)
        Else
            TryCast(sender, DevExpress.XtraBars.PopupMenu).ItemLinks(2).Item.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkLapPhieuBaoTri", Commons.Modules.TypeLanguage)
        End If

        If radChuaGiaiQuyet2.Checked Then
            TryCast(sender, DevExpress.XtraBars.PopupMenu).ItemLinks(1).Item.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTTCNhap", Commons.Modules.TypeLanguage)
        Else
            TryCast(sender, DevExpress.XtraBars.PopupMenu).ItemLinks(1).Item.Caption = radChuaGiaiQuyet2.Text
        End If
    End Sub

    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        Dim subMenu As DevExpress.XtraBars.BarSubItem = TryCast(e.Item, DevExpress.XtraBars.BarSubItem)
        Dim barMenu As DevExpress.XtraBars.BarManager = TryCast(sender, DevExpress.XtraBars.BarManager)
        If Not subMenu Is Nothing Then Return
        Dim grd As DevExpress.XtraGrid.GridControl = TryCast(Me.Controls.Find(barMenu.Form.Name, True).FirstOrDefault(), DevExpress.XtraGrid.GridControl)
        Dim grv As GridView = TryCast(grd.MainView, GridView)
        Dim dt As New DataTable()
        Try
            Select Case e.Item.Name.ToUpper
                Case "mnuMay".ToUpper
                    Commons.Hyperlink.ToMay(Me, grv.GetFocusedDataRow()("MS_MAY").ToString())
                Case "mnuCongViec".ToUpper
                    Commons.Hyperlink.ToCongViec(Me, grv.GetFocusedDataRow()("MS_CV").ToString())
                Case "mnuPhuTung".ToUpper
                    Commons.Hyperlink.ToPhuTung(Me, grv.GetFocusedDataRow()("MS_PT").ToString())
                Case "mnuGSTT".ToUpper
                    Commons.Hyperlink.ToGSTT(Me, grv.GetFocusedDataRow()("MS_TS_GSTT").ToString())
                Case "mnuPhieuBaoTri".ToUpper
                    If tabKeHoachTongThe.SelectedTabPageIndex = 0 Then
                        btnLPBT_Click(Nothing, Nothing)
                    ElseIf tabKeHoachTongThe.SelectedTabPageIndex = 2 Then
                        BtnLapPBT_Click(Nothing, Nothing)
                    Else
                        'Da giai quyet thi link toi PBT
                        If radDaGiaiQuyet2.Checked Then Commons.Hyperlink.ToPhieuBaoTri(Me, grv.GetFocusedDataRow()("MS_PBT").ToString())
                        'Chua giai quyet thi tao moi PBT
                        If radChuaGiaiQuyet2.Checked Then
                            gvTSGSTT.UpdateCurrentRow()
                            Dim dtTmp As New DataTable
                            dtTmp = CType(gdTSGSTT.DataSource, DataTable).Copy
                            dtTmp.DefaultView.RowFilter = "CHON = 1"
                            dtTmp = dtTmp.DefaultView.ToTable

                            If dtTmp.Rows.Count < 1 Then
                                If gvTSGSTT.GetFocusedRowCellValue("CHON") = 0 Then
                                    gvTSGSTT.SetFocusedRowCellValue("CHON", 1)
                                    gvTSGSTT.UpdateCurrentRow()
                                End If
                                dtTmp = New DataTable
                                dtTmp = CType(gdTSGSTT.DataSource, DataTable).Copy
                                dtTmp.DefaultView.RowFilter = "CHON = 1"
                                dtTmp = dtTmp.DefaultView.ToTable
                                If dtTmp.Rows.Count < 1 Then
                                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgChuaChonGiamSatCanThucHien", Commons.Modules.TypeLanguage))
                                    Exit Sub
                                End If
                            End If
                            Dim distinctDT As DataTable = dtTmp.DefaultView.ToTable(True, "MS_MAY", "NGAY_GIO_KT_MAX")
                            If distinctDT.Rows.Count > 1 Then
                                Commons.MssBox.Show(Me.Name, "msgCoTren2MayHayNgayKiemTra")
                                Exit Sub
                            End If
                            'Huongthem

                            AddsbtChonTS()

                            Dim frm As New Report1.frmLapphieubaotri_CS
                            frm.MS_MAY = grv.GetFocusedDataRow()("MS_MAY").ToString()
                            frm.bCoCV = True
                            frm.bLockMSMay = True
                            Dim sLyDo As String = ""
                            If Commons.Modules.sPrivate = "VIFON" Then
                                For Each dr As DataRow In dtTmp.Rows
                                    sLyDo = sLyDo & dr("TEN_BO_PHAN").ToString() & " : " & dr("TEN_TS_GSTT").ToString() & IIf(String.IsNullOrEmpty(dr("GT_DT").ToString()), "", " : " & dr("GT_DT").ToString()) & IIf(String.IsNullOrEmpty(dr("GT_DL").ToString()), "", dr("GT_DL").ToString()) & ", "
                                Next
                                sLyDo = sLyDo.Substring(1, sLyDo.Length - 3)
                            Else

                                If dtTmp.Rows.Count > 1 Then
                                    For Each dr As DataRow In dtTmp.Rows
                                        sLyDo = dr("TEN_TS_GSTT").ToString() & IIf(String.IsNullOrEmpty(dr("GT_DT").ToString()), "", " : " & dr("GT_DT").ToString()) & IIf(String.IsNullOrEmpty(dr("GT_DL").ToString()), "", dr("GT_DL").ToString()) & ", "
                                    Next
                                Else
                                    sLyDo = grv.Columns("TEN_TS_GSTT").Caption & "-" & grv.GetFocusedDataRow()("TEN_TS_GSTT").ToString() & IIf(String.IsNullOrEmpty(grv.GetFocusedDataRow()("GT_DT").ToString()), "", " : " & grv.Columns("GT_DT").Caption & " - " & grv.GetFocusedDataRow()("GT_DT").ToString()) & IIf(String.IsNullOrEmpty(grv.GetFocusedDataRow()("GT_DL").ToString()), "", " : " & grv.Columns("GT_DL").Caption & " - " & grv.GetFocusedDataRow()("GT_DL").ToString())
                                End If
                            End If
                            If sLyDo.Length > 5000 Then
                                If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgLyDoBaoTriQuaDai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub
                            End If
                            frm.sLyDo = sLyDo


                            If frm.ShowDialog() <> DialogResult.OK Then Exit Sub
                            Dim sNHTH As String = frm.sNhanVienThucHien
                            Dim sPBT As String = Commons.Modules.SQLString

                            For Each dr As DataRow In dtTmp.Rows
                                Try
                                    If String.IsNullOrEmpty(dr("GT_DT").ToString) Or String.IsNullOrEmpty(dr("STT_GT").ToString) Or
                                                String.IsNullOrEmpty(dr("STT_GT").ToString().Trim().ToString) Then
                                        sSql = "UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT='" & sPBT & "',MS_CACH_TH='04', " &
                                                    " USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & sNHTH & "',  " &
                                                    " TG_XU_LY= GETDATE() WHERE STT=" & dr("STT") & " AND MS_MAY=N'" & dr("MS_MAY") & "' " &
                                                    " AND MS_TS_GSTT='" & dr("MS_TS_GSTT") & "' AND MS_BO_PHAN = N'" & dr("MS_BO_PHAN") & "' "
                                    Else
                                        sSql = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_PBT='" & sPBT & "',MS_CACH_TH='04', " &
                                                " USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & sNHTH & "', " &
                                                " TG_XU_LY= GETDATE() WHERE STT=" & dr("STT") & " AND MS_MAY=N'" & dr("MS_MAY") & "'  " &
                                                " AND MS_TS_GSTT='" & dr("MS_TS_GSTT") & "' AND MS_BO_PHAN = N'" & dr("MS_BO_PHAN") & "' " &
                                                " AND STT_GT=" & dr("STT_GT")
                                    End If
                                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
                                Catch ex As Exception
                                    'DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
                                End Try
                            Next

                            Commons.Modules.SQLString = ""
                            RadBoQua2_Click(Nothing, Nothing)
                        End If
                    End If

                Case "mnuGSTTCNhap".ToUpper
                    Dim view As GridView = CType(gvTSGSTT, GridView)
                    Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
                    DoRowDoubleClick(view, pt)
            End Select
        Catch ex As Exception

        End Try

    End Sub
#End Region

    Private Sub LoadVersion()
        Dim sSql As String
        Dim dtTmp As New DataTable
        Try
            sSql = "SELECT TYPE" + Commons.Modules.LicID.ToString() + " FROM LIC_ID " &
                        " WHERE (ID_NAME <> N'" + Commons.Modules.ObjSystems.MaHoaDL("mnuKehoachtongthe").ToString() + "') " &
                        " AND (ID_NAME LIKE N'" + Commons.Modules.ObjSystems.MaHoaDL("mnuKehoachtongthe").ToString() + "%')"

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count = 0 Then
                TableLayoutPanel1.Visible = False
                Exit Sub
            Else
                For Each dr As DataRow In dtTmp.Rows
                    sSql = Commons.Modules.ObjSystems.GiaiMaDL(dr(0).ToString())
                    sSql = sSql.Replace("mnuKehoachtongthe", "")
                    If Microsoft.VisualBasic.Strings.Left(Microsoft.VisualBasic.Strings.Right(sSql, 2), 1) <> Commons.Modules.LicID Then
                        For Each tb As XtraTabPage In tabKeHoachTongThe.TabPages
                            If tb.Name.ToUpper() = sSql.Substring(0, sSql.Length - 2).ToUpper() Then
                                tabKeHoachTongThe.TabPages.Remove(tb)
                            End If
                        Next
                    Else
                        If Microsoft.VisualBasic.Strings.Right(sSql, 1) <> 1 Then
                            For Each tb As XtraTabPage In tabKeHoachTongThe.TabPages
                                If tb.Name.ToUpper() = sSql.Substring(0, sSql.Length - 2).ToUpper() Then
                                    tabKeHoachTongThe.TabPages.Remove(tb)
                                End If
                            Next
                        End If
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        btnLydosuachua.Enabled = chon
        BtnThem1.Enabled = chon
        btnThucHien1.Enabled = chon
        btnThucHien2.Enabled = chon
        BtnLapKHTT.Enabled = chon
        BtnLapPBT.Enabled = chon
        BtnLapKHTT1.Enabled = chon
        BtnLapPBT1.Enabled = chon
    End Sub

    Sub LoadNguoiLap()

        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 2, Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiLap, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "")


        dtTmp = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 2, Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiLap1, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "")

        dtTmp = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNGSat, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "")
    End Sub

    Sub LoadMay()
        Try
            CboMaSoThietBiBTDK.Properties.DataSource = Nothing
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayTheoLMNXHT", Commons.Modules.UserName,
                    cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue, cboDiaDiem_1.EditValue, cboHThong.EditValue, 0, 1))
            Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(CboMaSoThietBiBTDK, dtTmp, "MS_MAY", "TEN_MAY", "")
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadLoaiMay()
        CboNhomThietBiBTDK.Properties.DataSource = Nothing
        CboMaSoThietBiBTDK.Properties.DataSource = Nothing
        cboLoaiThietBiBTDK.Properties.DataSource = Nothing


        Dim dtTmp As New DataTable
        'dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

        dtTmp = Commons.Modules.ObjSystems.MLoadDataLoaiMay(1)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiThietBiBTDK, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "")

    End Sub

    Sub LoadNhomMay()
        Try
            CboNhomThietBiBTDK.Properties.DataSource = Nothing
            CboMaSoThietBiBTDK.Properties.DataSource = Nothing
            'Dim sSql As String = ""
            'sSql = "SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY " &
            '      "FROM dbo.USERS INNER JOIN dbo.NHOM_MAY " &
            '           " INNER JOIN " &
            '           "dbo.NHOM_LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY ON " &
            '           "dbo.USERS.GROUP_ID = dbo.NHOM_LOAI_MAY.GROUP_ID WHERE USERS.USERNAME='" & Commons.Modules.UserName & "'"
            'If cboLoaiThietBiBTDK.EditValue <> "-1" Then
            '    sSql = sSql + " AND NHOM_MAY.MS_LOAI_MAY ='" & cboLoaiThietBiBTDK.EditValue & "'"
            'End If
            'sSql = sSql + " ORDER BY TEN_NHOM_MAY"
            'CboNhomThietBiBTDK.Value = "MS_NHOM_MAY"
            'CboNhomThietBiBTDK.Display = "TEN_NHOM_MAY"
            'CboNhomThietBiBTDK.StoreName = "QL_SEARCH"
            'CboNhomThietBiBTDK.Param = sSql
            'CboNhomThietBiBTDK.DropDownWidth = 150
            'CboNhomThietBiBTDK.BindDataSource()

            Dim dtTmp As New DataTable
            'dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

            dtTmp = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cboLoaiThietBiBTDK.EditValue)

            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboNhomThietBiBTDK, dtTmp, "MS_NHOM_MAY", "TEN_NHOM_MAY", "")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat1.Click
        Me.Close()
    End Sub

    Private Sub BtnThoatBTDK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoatBTDK.Click
        Me.Close()
    End Sub

    Private Sub dtpDenNgayBTDK_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        LayDuLieu()
        Me.Cursor = Cursors.Default

    End Sub

    Sub LayDuLieu()
        If (CboMaSoThietBiBTDK.Text = "" Or IsDBNull(CboMaSoThietBiBTDK)) And (cboLoaiThietBiBTDK.Text = "" Or IsDBNull(cboLoaiThietBiBTDK)) Then
            Commons.MssBox.Show(Me.Name, "MsgQuyenKT1")
            Exit Sub
        End If

        dtpDenNgayBTDK1.Text = dtpDenNgay.Value
        TaoLuoiBTDK()
    End Sub

    Sub TaoLuoiBTDK()
        Try
            Dim dtTable As New DataTable

            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTT", dtpTuNgay.Value, dtpDenNgay.Value,
                cboDiaDiem_1.EditValue, cboHThong.EditValue,
                cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue, IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue),
                Commons.Modules.UserName, Commons.Modules.TypeLanguage, IIf(chkDuGio.Checked, 1, 0)))

            dtTable.Columns("chkChon").ReadOnly = False
            Dim bNull As Boolean
            If gdBTDK.DataSource Is Nothing Then bNull = True

            If bNull Then
                Commons.Modules.ObjSystems.MLoadXtraGrid(gdBTDK, gvBTDK, dtTable, True, True, True, True)
            Else
                gdBTDK.DataSource = dtTable
            End If

            If bNull Then
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvBTDK.Columns
                    If col.FieldName = "chkChon" Then
                        col.Width = 50
                        col.OptionsColumn.AllowEdit = True
                        col.OptionsColumn.ReadOnly = False
                        col.OptionsColumn.AllowEdit = True
                    Else
                        'col.Width = 200
                        col.OptionsColumn.AllowEdit = False
                        col.OptionsColumn.ReadOnly = True
                        col.OptionsColumn.AllowEdit = False
                    End If

                    col.AppearanceHeader.Options.UseTextOptions = True
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
                Next
                gvBTDK.Columns("Ten_N_XUONG").Visible = False
                gvBTDK.Columns("TEN_HE_THONG").Visible = False
                gvBTDK.Columns("MS_LOAI_BT").Visible = False
                gvBTDK.Columns("THU_TU").Visible = False
                gvBTDK.Columns("MUC_UU_TIEN").Visible = False

                Dim col1 As DevExpress.XtraGrid.Columns.GridColumn = gvBTDK.Columns("Ten_N_XUONG")
                Dim col2 As DevExpress.XtraGrid.Columns.GridColumn = gvBTDK.Columns("TEN_HE_THONG")
                gvBTDK.OptionsCustomization.AllowGroup = True
                gvBTDK.BeginSort()
                Try
                    gvBTDK.ClearGrouping()
                    col1.GroupIndex = 0
                    col2.GroupIndex = 1

                Catch ex As Exception
                Finally
                    gvBTDK.EndSort()
                End Try



            End If
            gvBTDK.ExpandAllGroups()

            lblChon.Text = Chon & ": 0"
        Catch ex As Exception
            gdBTDK.DataSource = Nothing
            lblChon.Text = Chon & ": 0"
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgThucHienKhongThanhCong", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnLapKHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLapKHTT.Click
        Try

            If gdBTDK.DataSource Is Nothing Then Exit Sub
            gdBTDK.Update()
            Dim i As Integer = 0
            Dim strTenHangMuc As String
            Dim blnChon As Boolean = False
            Dim HangMucID As Integer = -1
            Dim _dt As New DataTable
            Dim _temp As New DataTable()
            _dt = CType(gdBTDK.DataSource, DataTable)

            _temp = _dt.Copy()
            _temp.DefaultView.RowFilter = "chkChon=True"

            _temp = _temp.DefaultView.ToTable()
            If _temp.Rows.Count = 0 Then
                Commons.MssBox.Show(Me.Name, "MsgQuyenKT22")
                Exit Sub
            End If
            Dim sql As String = "select ISNULL(MAX(HANG_MUC_ID),0) FROM KE_HOACH_TONG_THE"
            j = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            j = j + 1

            Dim tran As SqlTransaction
            Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            tran = con.BeginTransaction()
            Dim _dt_temp As New DataTable()
            Try
                For Each _row As DataRow In _temp.Rows
                    Dim _sql As String = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, _sql)
                    strTenHangMuc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuyenTuBTPN", Commons.Modules.TypeLanguage) & " " & _row("TEN_LOAI_BT")
                    Dim sCnPT As String = ""
                    Dim sCnGS As String = ""
                    If cboNguoiLap.Text <> "" Then sCnPT = cboNguoiLap.EditValue Else sCnPT = ""
                    If cboNGSat.Text <> "" Then sCnGS = cboNGSat.EditValue Else sCnGS = ""

                    Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_THE(HANG_MUC_ID,MS_MAY,NGAY,MS_LOAI_BT ,NGAY_BTPN,TEN_HANG_MUC,LY_DO_SC,NGAY_DK_HT,USERNAME, MS_UU_TIEN, MS_CN_PT, MS_CN_GS) " &
                                " VALUES(" & j & ",N'" & _row("MS_MAY") & "','" & Format(_row("NGAY_BTKT"), "MM/dd/yyyy") & "'," & _row("MS_LOAI_BT") & ",'" &
                                Format(_row("NGAY_BTKT"), "MM/dd/yyyy") & "',N'" & strTenHangMuc & "',2,'" & Format(_row("NGAY_BTKT"), "MM/dd/yyyy") & "','" & Commons.Modules.UserName & "','" & _row("MUC_UU_TIEN") & "', '" & sCnPT & "', '" & sCnGS & "' )"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                    Commons.Modules.SQLString = "UPDATE KE_HOACH_TONG_THE SET NGAY_BTDK_GOC = '" & Format(_row("NGAY_BTKT"), "MM/dd/yyyy") & "' WHERE HANG_MUC_ID='" & j & "'"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                    Try
                        SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_THE_LOG", j, Me.Name, Commons.Modules.UserName, 1)
                    Catch ex As Exception
                    End Try

                    If Commons.Modules.iMacDinhCVPT = 0 Or Commons.Modules.iMacDinhCVPT = 1 Then
                        Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN, THOI_GIAN_DU_KIEN, SNGUOI, YCAU_NS, YCAU_DC) SELECT N'" & _row("MS_MAY") & "'," & j & ", " &
                                " MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN,CASE ISNULL(CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH , 0) WHEN 0 THEN CONG_VIEC.THOI_GIAN_DU_KIEN ELSE CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH END AS THOI_GIAN_DU_KIEN,SO_NGUOI, CAU_TRUC_THIET_BI_CONG_VIEC.YEU_CAU_NS, CAU_TRUC_THIET_BI_CONG_VIEC.YEU_CAU_DUNG_CU FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC ON " &
                                " MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN " &
                                " AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CONG_VIEC.MS_CV " &
                                " WHERE CAU_TRUC_THIET_BI_CONG_VIEC.ACTIVE = 1 AND MAY_LOAI_BTPN_CONG_VIEC.MS_MAY=N'" & _row("MS_MAY") & "' " &
                                " AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Try
                            Dim vtb As New DataTable
                            sql = "SELECT N'" & _row("MS_MAY") & "' as MS_MAY ," & j & " as HANG_MUC_ID , MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV WHERE MAY_LOAI_BTPN_CONG_VIEC.MS_MAY=N'" & _row("MS_MAY") & "' AND MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT=" & _row("MS_LOAI_BT")
                            vtb.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, sql))
                            For Each vr As DataRow In vtb.Rows
                                SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), Me.Name, Commons.Modules.UserName, 1)

                            Next
                        Catch ex As Exception

                        End Try
                    End If
                    If Commons.Modules.iMacDinhCVPT = 0 Then
                        Commons.Modules.SQLString = "SELECT DISTINCT HANG_MUC_ID,MS_CV FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID NOT IN (SELECT HANG_MUC_ID FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY ='" & _row("MS_MAY") & "') AND MS_MAY=N'" & _row("MS_MAY") & "' AND HANG_MUC_ID=" & j
                        _dt_temp = New DataTable()
                        _dt_temp.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))
                        For Each _dt_row In _dt_temp.Rows
                            Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC_PHU_TUNG(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG) SELECT '" & _row("MS_MAY") & "'," & _dt_row(0) & "," & _dt_row(1) & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & _dt_row(1)
                            SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                            Try
                                sql = "SELECT '" & _row("MS_MAY") & "' as MS_MAY ," & _dt_row(0) & " as HANG_MUC_ID ," & _dt_row(1) & " as MS_CV ,MS_BO_PHAN,MS_PT,SO_LUONG 
                                        FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & _dt_row(1)

                                Dim vtb As New DataTable
                                vtb.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, sql))
                                For Each vr As DataRow In vtb.Rows
                                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 1)
                                Next
                            Catch ex As Exception

                            End Try
                        Next

                    End If
                    j = j + 1
                Next
                tran.Commit()
                con.Close()
            Catch ex As Exception
                tran.Rollback()
                con.Close()
            End Try

            TaoLuoiBTDK()
            Commons.MssBox.Show(Me.Name, "MsgQuyenKT23")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnLapPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLapPBT.Click
        Try

            If String.IsNullOrEmpty(cboNguoiLap.Text) Then
                Commons.MssBox.Show(Me.Name, "msgChuaChonNguoiLap")
                cboNguoiLap.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(cboNGSat.Text) Then
                Commons.MssBox.Show(Me.Name, "msgChuaChonNguoiGiamSat")
                cboNGSat.Focus()
                Exit Sub
            End If
            Dim _dt As New DataTable
            Dim _temp As New DataTable()
            _dt = CType(gdBTDK.DataSource, DataTable)
            _temp = _dt.Copy()
            _temp.DefaultView.RowFilter = "chkChon=True"
            _temp = _temp.DefaultView.ToTable()
            If _temp.Rows.Count = 0 Then
                Commons.MssBox.Show(Me.Name, "MsgQuyenKT22")
                Exit Sub
            End If
            If Commons.Modules.ObjSystems.LapBPTDinhKy(_temp, cboNguoiLap.EditValue, cboNGSat.EditValue) Then
                TaoLuoiBTDK()
            End If

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgLapPhieuBaoTriKhongThanhCong", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub btnThoat2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat2.Click
        Me.Close()
    End Sub

    Sub HideButton2(ByVal An As Boolean)
        btnThoat2.Visible = Not An
        btnXemBangChung1.Visible = Not An
        btnThucHien1.Visible = An
    End Sub

    Private Sub AddsbtChonTS()
        Dim sbt As String = "TEMPT" + Commons.Modules.UserName
        Try
            Commons.Modules.ObjSystems.XoaTable(sbt)
        Catch ex As Exception
        End Try
        Dim tempt As New DataTable()
        tempt = CType(gdTSGSTT.DataSource, DataTable)
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sbt, tempt, "")
    End Sub

    Private Sub btnThucHien1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien1.Click
        Dim view As GridView = CType(gvTSGSTT, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        DoRowDoubleClick(view, pt)

        Exit Sub

        Dim strTraLoi As String = ""
        Dim i As Integer
        Dim lstPBT, lstKHTT, lstBoQua As New List(Of Integer)

        If gvTSGSTT.RowCount <= 0 Then Exit Sub
        For i = 0 To gvTSGSTT.RowCount - 1
            If (Not IsDBNull(gvTSGSTT.GetDataRow(i)("MS_CACH_TH"))) Then
                If IsDBNull(gvTSGSTT.GetDataRow(i)("MS_CACH_TH")) Then
                    If IsDBNull(gvTSGSTT.GetDataRow(i)("MS_PBT")) And Not IsDBNull(gvTSGSTT.GetDataRow(i)("MS_CONG_NHAN")) Then
                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "VAN_DE", Commons.Modules.TypeLanguage) & " : " & UCase(gvTSGSTT.GetDataRow(i)("TEN_TS_GSTT")) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT33", Commons.Modules.TypeLanguage) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKTConfirm", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                            Continue For
                        Else
                            gvTSGSTT.FocusedRowHandle = i
                            Exit Sub
                        End If
                    ElseIf Not IsDBNull(gvTSGSTT.GetDataRow(i)("MS_PBT")) Then
                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT26", Commons.Modules.TypeLanguage) & " " & UCase(gvTSGSTT.GetDataRow(i)("TEN_TS_GSTT")) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKTConfirm", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                            Continue For
                        Else
                            gvTSGSTT.FocusedRowHandle = i
                            Exit Sub
                        End If
                    ElseIf Not IsDBNull(gvTSGSTT.GetDataRow(i)("MS_PBT")) Then
                        If IsDBNull(gvTSGSTT.GetDataRow(i)("MS_CONG_NHAN")) Then
                            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "VAN_DE", Commons.Modules.TypeLanguage) & " : " & UCase(gvTSGSTT.GetDataRow(i)("TEN_TS_GSTT")) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT11", Commons.Modules.TypeLanguage) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKTConfirm", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                                Continue For
                            Else
                                gvTSGSTT.FocusedRowHandle = i
                                Exit Sub
                            End If
                        Else
                            lstPBT.Add(i)
                            Continue For
                        End If
                    Else
                        Continue For
                    End If
                    Continue For
                End If

                If gvTSGSTT.GetDataRow(i)("MS_CACH_TH") = "01" Then

                    If IsDBNull(gvTSGSTT.GetDataRow(i)("MS_CONG_NHAN")) Then
                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "VAN_DE", Commons.Modules.TypeLanguage) & " : " & UCase(gvTSGSTT.GetDataRow(i)("TEN_TS_GSTT")) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT11", Commons.Modules.TypeLanguage) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKTConfirm", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                            Continue For
                        Else
                            gvTSGSTT.FocusedRowHandle = i
                            Exit Sub
                        End If
                    End If

                    lstKHTT.Add(i)
                End If
                If gvTSGSTT.GetDataRow(i)("MS_CACH_TH") = "02" Or gvTSGSTT.GetDataRow(i)("MS_CACH_TH") = "04" Then


                    If IsDBNull(gvTSGSTT.GetDataRow(i)("MS_CONG_NHAN")) Then
                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "VAN_DE", Commons.Modules.TypeLanguage) & " : " & UCase(gvTSGSTT.GetDataRow(i)("TEN_TS_GSTT")) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT11", Commons.Modules.TypeLanguage) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKTConfirm", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                            Continue For
                        Else
                            gvTSGSTT.FocusedRowHandle = i
                            Exit Sub
                        End If
                    End If
                    lstPBT.Add(i)
                End If
                If gvTSGSTT.GetDataRow(i)("MS_CACH_TH") = "03" Then
                    lstBoQua.Add(i)
                End If

            End If
        Next
        If lstPBT.Count > 0 Then

            i = 0
            While i < lstPBT.Count
                '.Cells("MS_CACH_TH").Value.ToString = "02" Then
                If gvTSGSTT.GetDataRow(i)("MS_CACH_TH").ToString() = "02" Then
                    LapPBT2_tab2(lstPBT(i))
                ElseIf gvTSGSTT.GetDataRow(i)("MS_CACH_TH").ToString() = "04" Then
                    LapPBT1_tab2(lstPBT(i))
                End If
                i += 1
            End While
        End If
        Dim sql As String
        Dim vtb As New DataTable

        If lstBoQua.Count > 0 Then

            i = 0
            While i < lstBoQua.Count

                If IsDBNull(gvTSGSTT.GetDataRow(lstBoQua(i))("GT_DT")) Or IsDBNull(gvTSGSTT.GetDataRow(lstBoQua(i))("STT_GT")) Or gvTSGSTT.GetDataRow(lstBoQua(i))("STT_GT").ToString().Trim().Equals(String.Empty) Then
                    Try
                        sql = "SELECT STT,MS_MAY,MS_TS_GSTT,MS_BO_PHAN,MS_TT FROM GIAM_SAT_TINH_TRANG_TS WHERE STT=" & gvTSGSTT.GetDataRow(lstBoQua(i))("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_TS_GSTT") & "'"
                        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                        For Each vr As DataRow In vtb.Rows
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_GIAM_SAT_TINH_TRANG_TS_LOG", vr("STT"), vr("MS_MAY"), vr("MS_TS_GSTT"), vr("MS_BO_PHAN"), vr("MS_TT"), Me.Name, Commons.Modules.UserName, 2)
                        Next
                    Catch ex As Exception

                    End Try

                    Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS SET " &
                            " MS_CONG_NHAN='" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_CONG_NHAN") & "', " &
                            " MS_CACH_TH = '03',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "', " &
                            " USERNAME='" & Commons.Modules.UserName & "' " &
                            " WHERE STT=" & gvTSGSTT.GetDataRow(lstBoQua(i))("STT") &
                            " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_MAY") & "' " &
                            " AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_TS_GSTT") & "'"
                Else
                    Try
                        sql = " select STT,MS_MAY,MS_TS_GSTT,MS_BO_PHAN,MS_TT,STT_GT from GIAM_SAT_TINH_TRANG_TS_DT WHERE STT=" & gvTSGSTT.GetDataRow(lstBoQua(i))("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_TS_GSTT") & "' AND STT_GT=" & gvTSGSTT.GetDataRow(lstBoQua(i))("STT_GT")
                        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                        For Each vr As DataRow In vtb.Rows
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_GIAM_SAT_TINH_TRANG_TS_DT_LOG", vr("STT"), vr("MS_MAY"), vr("MS_TS_GSTT"), vr("MS_BO_PHAN"), vr("MS_TT"), vr("STT_GT"), Me.Name, Commons.Modules.UserName, 2)
                        Next
                    Catch ex As Exception

                    End Try
                    Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_CONG_NHAN='" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_CONG_NHAN") & "',MS_CACH_TH='03',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "',USERNAME='" & Commons.Modules.UserName & "' WHERE STT=" & gvTSGSTT.GetDataRow(lstBoQua(i))("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(lstBoQua(i))("MS_TS_GSTT") & "' AND STT_GT=" & gvTSGSTT.GetDataRow(lstBoQua(i))("STT_GT")
                End If
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                i += 1
            End While
        End If
        LoadDataTSGSTT()
    End Sub


    Private Sub tabKeHoachTongThe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabKeHoachTongThe.SelectedPageChanged
        BindData_Tab()
    End Sub

    Function Loc3(ByVal intCTH As Integer) As String
        Dim SQL As String
        Dim NgayHT As Date
        NgayHT = Now.Date

        SQL = " SELECT     A.NGAY_GIO_YC_MAX, A.STT, A.STT_VAN_DE, A.MS_MAY, A.MO_TA_TINH_TRANG, A.YEU_CAU, A.MS_CACH_TH, A.MS_PBT, dbo.KE_HOACH_TONG_THE.TEN_HANG_MUC, A.MS_CONG_NHAN, " &
                    " A.NGAY_XU_LY + ' ' + A.GIO_XU_LY AS TG_XU_LY, A.USERNAME, A.HO_TEN, A.NOI_DUNG_XAC_NHAN, A.NGAY_XU_LY, A.GIO_XU_LY, A.TEN_UU_TIEN, A.MS_UU_TIEN " &
                    " FROM         (SELECT     MS_N_XUONG " &
                    " FROM          dbo.MashjGetNXUser('" & Commons.Modules.UserName & "', '" & cboDiaDiem_1.EditValue & "') AS MashjGetNXUser_1) AS NNX INNER JOIN " &
                    " dbo.YEU_CAU_NSD_TMP1" & Commons.Modules.UserName & " AS A INNER JOIN " &
                    " dbo.MAY ON A.MS_MAY = dbo.MAY.MS_MAY INNER JOIN " &
                    " dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY INNER JOIN " &
                    " dbo.MAY_NHA_XUONG_NGAY_MAX AS MAY_NHA_XUONG ON A.MS_MAY = MAY_NHA_XUONG.MS_MAY LEFT OUTER JOIN " &
                    " dbo.KE_HOACH_TONG_THE ON A.HANG_MUC_ID_KE_HOACH = dbo.KE_HOACH_TONG_THE.HANG_MUC_ID INNER JOIN " &
                    " (SELECT     NHOM_LOAI_MAY_1.MS_LOAI_MAY, dbo.USERS.USERNAME " &
                    " FROM          dbo.NHOM_LOAI_MAY AS NHOM_LOAI_MAY_1 INNER JOIN " &
                    " dbo.NHOM ON NHOM_LOAI_MAY_1.GROUP_ID = dbo.NHOM.GROUP_ID INNER JOIN " &
                    " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID " &
                    " WHERE      (dbo.USERS.USERNAME = '" & Commons.Modules.UserName & "')) AS NHOM_LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " &
                    " dbo.NHA_XUONG ON MAY_NHA_XUONG.MS_N_XUONG = dbo.NHA_XUONG.MS_N_XUONG ON NNX.MS_N_XUONG = MAY_NHA_XUONG.MS_N_XUONG"


        If intCTH = 1 Then
            SQL = SQL & " WHERE A.NGAY_XU_LY IS NULL  "
        ElseIf intCTH = 2 Then
            SQL = SQL & " WHERE A.MS_CACH_TH='03' "
        ElseIf intCTH = 3 Then
            SQL = SQL & " WHERE A.MS_CACH_TH<>'03' AND A.NGAY_XU_LY >='" & Format(dtpTNYCSD.DateTime.Date, "MM/dd/yyyy") & "' AND A.NGAY_XU_LY<='" & Format(dtpDNYCSD.DateTime.Date, "MM/dd/yyyy") & "'  "
            NgayHT = dtpDNYCSD.DateTime.Date
        End If
        If cboLoaiThietBiBTDK.EditValue <> "-1" Then SQL = SQL & " AND NHOM_MAY.MS_LOAI_MAY='" & cboLoaiThietBiBTDK.EditValue & "'"
        If CboNhomThietBiBTDK.EditValue <> "-1" Then SQL = SQL & " AND NHOM_MAY.MS_NHOM_MAY='" & CboNhomThietBiBTDK.EditValue & "'"
        If CboMaSoThietBiBTDK.EditValue <> " < ALL > " Then SQL = SQL & " AND A.MS_MAY=N'" & CboMaSoThietBiBTDK.EditValue & "'"

        If cboHThong.EditValue <> -1 Then SQL = SQL & " AND dbo.MGetHTTheoNgay(A.MS_MAY , '" & Format(NgayHT, "MM/dd/yyyy") & "' ) =N'" & cboHThong.EditValue & "'"
        Commons.Modules.SQLString = SQL

        Return Commons.Modules.SQLString & " order by A.MS_UU_TIEN ASC"
    End Function
    Sub LoadDataYCNSD()
        Try

            Dim dtTable As New DataTable
            Commons.Modules.ObjSystems.XoaTable("YEU_CAU_NSD_TMP1" & Commons.Modules.UserName)
            Commons.Modules.ObjSystems.XoaTable("YEU_CAU_NSD_TMP2" & Commons.Modules.UserName)

            Commons.Modules.SQLString = "SELECT CONVERT(CHAR(10),NGAY,103)+ ' ' + CONVERT(CHAR(5),GIO_YEU_CAU,8) AS NGAY_GIO_YC,YEU_CAU_NSD_CHI_TIET.* " &
                    "INTO YEU_CAU_NSD_TMP1" & Commons.Modules.UserName & " FROM YEU_CAU_NSD INNER JOIN YEU_CAU_NSD_CHI_TIET ON " &
                    " YEU_CAU_NSD.STT=YEU_CAU_NSD_CHI_TIET.STT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.SQLString = "SELECT MS_MAY,STT_VAN_DE,MAX(NGAY_GIO_YC) AS NGAY_GIO_YC_MAX INTO YEU_CAU_NSD_TMP2" & Commons.Modules.UserName & " FROM YEU_CAU_NSD_TMP1" & Commons.Modules.UserName & " GROUP BY MS_MAY,STT_VAN_DE"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

            Commons.Modules.ObjSystems.XoaTable("YEU_CAU_NSD_TMP1" & Commons.Modules.UserName)

            Dim sql As String
            sql = "SELECT YEU_CAU_NSD_CHI_TIET.STT,YEU_CAU_NSD_TMP2" & Commons.Modules.UserName & ".*, " &
                        " MO_TA_TINH_TRANG,YEU_CAU,CONG_NHAN.HO + ' ' + CONG_NHAN.TEN AS HO_TEN ,NOI_DUNG_XAC_NHAN,YEU_CAU_NSD_CHI_TIET.MS_CONG_NHAN, " &
                        " YEU_CAU_NSD_CHI_TIET.USERNAME,NGAY_XU_LY,GIO_XU_LY,MS_CACH_TH,MS_PBT,HANG_MUC_ID_KE_HOACH,dbo.YEU_CAU_NSD_CHI_TIET.MS_UU_TIEN, " &
                        " dbo.MUC_UU_TIEN.TEN_UU_TIEN INTO YEU_CAU_NSD_TMP1" & Commons.Modules.UserName & " FROM " &
                        " YEU_CAU_NSD_TMP2" & Commons.Modules.UserName & " INNER JOIN YEU_CAU_NSD_CHI_TIET ON YEU_CAU_NSD_TMP2" &
                        Commons.Modules.UserName & ".MS_MAY=YEU_CAU_NSD_CHI_TIET.MS_MAY AND YEU_CAU_NSD_TMP2" &
                        Commons.Modules.UserName & ".STT_VAN_DE=YEU_CAU_NSD_CHI_TIET.STT_VAN_DE LEFT JOIN CONG_NHAN ON " &
                        " YEU_CAU_NSD_CHI_TIET.NGUOI_XAC_NHAN = CONG_NHAN.MS_CONG_NHAN INNER JOIN YEU_CAU_NSD ON YEU_CAU_NSD_CHI_TIET.STT=YEU_CAU_NSD.STT " &
                        " AND CONVERT(DATETIME,LEFT(NGAY_GIO_YC_MAX,10),103)=YEU_CAU_NSD.NGAY AND " &
                        " CONVERT(DATETIME,RIGHT(NGAY_GIO_YC_MAX,5),103)=YEU_CAU_NSD.GIO_YEU_CAU LEFT OUTER JOIN dbo.MUC_UU_TIEN ON " &
                        " dbo.YEU_CAU_NSD_CHI_TIET.MS_UU_TIEN = dbo.MUC_UU_TIEN.MS_UU_TIEN"
            Commons.Modules.SQLString = sql
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            ' da giai quyet
            If radChuaGiaiQuyet3.Checked Then
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Loc3(1)))
            ElseIf RadBoQua3.Checked Then
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Loc3(2)))
            ElseIf radDaGiaiQuyet3.Checked Then
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Loc3(3)))
            Else
                radChuaGiaiQuyet3.Checked = True
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Loc3(1)))
            End If

            gdYCNSD.DataSource = dtTable
            gvYCNSD.Columns("STT").Visible = False
            gvYCNSD.Columns("STT_VAN_DE").Visible = False
            gvYCNSD.Columns("TEN_HANG_MUC").Visible = False
            gvYCNSD.Columns("MS_UU_TIEN").Visible = False
            gvYCNSD.Columns("GIO_XU_LY").Visible = False
            gvYCNSD.Columns("MS_CACH_TH").ColumnEdit = repositoryItemLookUpEdit4
            gvYCNSD.Columns("MS_PBT").ColumnEdit = repositoryItemLookUpEdit5
            gvYCNSD.Columns("MS_CONG_NHAN").ColumnEdit = repositoryItemLookUpEdit6
            Dim str As String = ""
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvYCNSD.Columns
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
                str = col.FieldName
                Select Case str
                    Case "MS_CONG_NHAN", "MS_PBT", "MS_CACH_TH"
                        If radChuaGiaiQuyet3.Checked Then
                            col.OptionsColumn.AllowEdit = True
                        Else
                            col.OptionsColumn.AllowEdit = False
                        End If

                    Case Else
                        col.OptionsColumn.AllowEdit = False
                End Select

            Next
            gvYCNSD.BestFitColumns()
        Catch ex As Exception

        End Try

    End Sub

    Sub HideButton3(ByVal An As Boolean)
        btnThoat3.Visible = Not An
        btnXemBangChung2.Visible = Not An
        btnThucHien2.Visible = An
    End Sub



    Private Sub dtpTNYCSD_EditValueChanged(sender As Object, e As EventArgs)
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        LoadDataYCNSD()
        btnThucHien2.Enabled = False
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThucHien2.Enabled = False
        End If
    End Sub

    Private Sub radChuaGiaiQuyet3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radChuaGiaiQuyet3.Click
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        LoadDataYCNSD()
        btnThucHien2.Enabled = True
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThucHien2.Enabled = False
        End If

    End Sub

    Private Sub radDaGiaiQuyet3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDaGiaiQuyet3.Click
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        LoadDataYCNSD()
        btnThucHien2.Enabled = False
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThucHien2.Enabled = False
        End If
    End Sub

    Private Sub btnThoat3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThoat3.Click
        Me.Close()
    End Sub

    Private Sub btnThucHien2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThucHien2.Click
        Dim strTraLoi As String = ""
        Dim i As Integer
        Dim lstPBT, lstKHTT, lstBoQua As New List(Of Integer)

        If gvYCNSD.RowCount <= 0 Then Exit Sub
        For i = 0 To gvYCNSD.RowCount - 1
            If Not IsDBNull(gvYCNSD.GetDataRow(i)("MS_CACH_TH")) Then
                If gvYCNSD.GetDataRow(i)("MS_CACH_TH") = "01" Then
                    If IsDBNull(gvYCNSD.GetDataRow(i)("MS_CONG_NHAN")) Then
                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "VAN_DE", Commons.Modules.TypeLanguage) & " : " & UCase(gvYCNSD.GetDataRow(i)("MO_TA_TINH_TRANG")) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT11", Commons.Modules.TypeLanguage) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKTConfirm", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                            Continue For
                        Else
                            gvYCNSD.FocusedRowHandle = i
                            Exit Sub
                        End If
                    End If

                    lstKHTT.Add(i)
                End If
                If gvYCNSD.GetDataRow(i)("MS_CACH_TH") = "02" Or gvYCNSD.GetDataRow(i)("MS_CACH_TH") = "04" Then
                    If IsDBNull(gvYCNSD.GetDataRow(i)("MS_CONG_NHAN")) Then
                        If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "VAN_DE", Commons.Modules.TypeLanguage) & " : " & UCase(gvYCNSD.GetDataRow(i)("MO_TA_TINH_TRANG")) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT11", Commons.Modules.TypeLanguage) & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKTConfirm", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                            Continue For
                        Else
                            gvYCNSD.FocusedRowHandle = i
                            Exit Sub
                        End If
                    End If
                    lstPBT.Add(i)
                End If
                If gvYCNSD.GetDataRow(i)("MS_CACH_TH") = "03" Then
                    lstBoQua.Add(i)
                End If
            End If
        Next
        If lstPBT.Count > 0 Then
            i = 0
            While i < lstPBT.Count
                If gvYCNSD.GetDataRow(lstPBT.Item(i))("MS_CACH_TH").ToString = "02" Then
                    LapPBT2_tab3(lstPBT(i))
                ElseIf gvYCNSD.GetDataRow(lstPBT.Item(i))("MS_CACH_TH").ToString = "04" Then
                    LapPBT1_tab3(lstPBT(i))
                End If
                i += 1
            End While
        End If
        If lstBoQua.Count > 0 Then
            i = 0
            While i < lstBoQua.Count
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_YEU_CAU_NSD_CHI_TIET_LOG", gvYCNSD.GetDataRow(lstBoQua(i))("STT"), gvYCNSD.GetDataRow(lstBoQua(i))("STT_VAN_DE"), Me.Name, Commons.Modules.UserName, 2)
                Catch ex As Exception

                End Try
                Commons.Modules.SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_CACH_TH='03',NGAY_XU_LY='" & Format(Now, "MM/dd/yyyy") & "',GIO_XU_LY='" & Format(Now, "HH:mm") & "',USERNAME='" & Commons.Modules.UserName & "' WHERE STT=" & gvYCNSD.GetDataRow(lstBoQua(i))("STT") & " AND MS_MAY=N'" & gvYCNSD.GetDataRow(lstBoQua(i))("MS_MAY") & "' AND STT_VAN_DE=" & gvYCNSD.GetDataRow(lstBoQua(i))("STT_VAN_DE")
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                i += 1
            End While
        End If
        LoadDataYCNSD()
    End Sub
    Sub LapPBT2_tab2(ByVal ind As Integer)
        Dim MS_PBT, LY_DO_BT As String
        LY_DO_BT = ""
        Dim MS_LOAI_BT As Integer
        If IsDBNull(gvTSGSTT.GetDataRow(ind)("MS_PBT")) Or gvTSGSTT.GetDataRow(ind)("MS_PBT") = "" Then
            MS_PBT = Commons.Modules.ObjSystems.TangMS_PBT
            Commons.Modules.SQLString = "SELECT MS_LOAI_BT,LY_DO_BT FROM CACH_THUC_HIEN WHERE MS_CACH_TH='02'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                MS_LOAI_BT = dtReader.Item(0)
                LY_DO_BT = dtReader.Item(1)
            End While
            dtReader.Close()

            Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI(MS_PHIEU_BAO_TRI,TINH_TRANG_PBT,MS_MAY,MS_LOAI_BT,NGUOI_LAP,NGAY_LAP,GIO_LAP,LY_DO_BT,NGAY_BD_KH,USERNAME_NGUOI_LAP,NGAY_KT_KH) VALUES(N'" & MS_PBT & "',1,'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "'," & MS_LOAI_BT & ",'" & gvTSGSTT.GetDataRow(ind)("MS_CONG_NHAN") & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Format(TimeValue(Now), "HH:mm") & "','" & LY_DO_BT & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Commons.Modules.UserName & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Else
            MS_PBT = gvTSGSTT.GetDataRow(ind)("MS_PBT")
        End If


        If IsDBNull(gvTSGSTT.GetDataRow(ind)("GT_DT")) Or IsDBNull(gvTSGSTT.GetDataRow(ind)("STT_GT")) Or gvTSGSTT.GetDataRow(ind)("STT_GT").ToString().Trim().Equals(String.Empty) Then
            Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='" & gvTSGSTT.GetDataRow(ind)("MS_CACH_TH") & "',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & gvTSGSTT.GetDataRow(ind)("MS_CONG_NHAN") & "',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "' WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "'"
        Else
            Commons.Modules.SQLString = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='" & gvTSGSTT.GetDataRow(ind)("MS_CACH_TH") & "',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & gvTSGSTT.GetDataRow(ind)("MS_CONG_NHAN") & "',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "' WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "' AND STT_GT=" & gvTSGSTT.GetDataRow(ind)("STT_GT")
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub
    Sub LapPBT1_tab2(ByVal ind As Integer)
        Dim MS_PBT, LY_DO_BT As String
        Dim MS_LOAI_BT As Integer
        If IsDBNull(gvTSGSTT.GetDataRow(ind)("MS_PBT")) Or gvTSGSTT.GetDataRow(ind)("MS_PBT") = "" Then
            MS_PBT = Commons.Modules.ObjSystems.TangMS_PBT
            Commons.Modules.SQLString = "SELECT MS_LOAI_BT,LY_DO_BT FROM CACH_THUC_HIEN WHERE MS_CACH_TH='02'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                MS_LOAI_BT = dtReader.Item(0)
                LY_DO_BT = dtReader.Item(1)
            End While
            dtReader.Close()

        Else
            MS_PBT = gvTSGSTT.GetDataRow(ind)("MS_PBT")
        End If

        Dim sql As String = ""
        If IsDBNull(gvTSGSTT.GetDataRow(ind)("GT_DT")) Or IsDBNull(gvTSGSTT.GetDataRow(ind)("STT_GT")) Or gvTSGSTT.GetDataRow(ind)("STT_GT").ToString().Trim().Equals(String.Empty) Then
            sql = "UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='" & gvTSGSTT.GetDataRow(ind)("MS_CACH_TH") & "',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & gvTSGSTT.GetDataRow(ind)("MS_CONG_NHAN") & "',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "' WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "'"
        Else
            sql = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='" & gvTSGSTT.GetDataRow(ind)("MS_CACH_TH") & "',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & gvTSGSTT.GetDataRow(ind)("MS_CONG_NHAN") & "',TG_XU_LY='" & Format(Now, "MM/dd/yyyy HH:mm") & "' WHERE STT=" & gvTSGSTT.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvTSGSTT.GetDataRow(ind)("MS_MAY") & "' AND MS_TS_GSTT='" & gvTSGSTT.GetDataRow(ind)("MS_TS_GSTT") & "' AND STT_GT=" & gvTSGSTT.GetDataRow(ind)("STT_GT")
        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)
    End Sub

    Sub LapPBT2_tab3(ByVal ind As Integer)
        Dim MS_PBT, LY_DO_BT As String
        Dim MS_LOAI_BT As Integer
        If IsDBNull(gvYCNSD.GetDataRow(ind)("MS_PBT")) Or gvYCNSD.GetDataRow(ind)("MS_PBT") = "" Then
            MS_PBT = Commons.Modules.ObjSystems.TangMS_PBT
            Commons.Modules.SQLString = "SELECT MS_LOAI_BT,LY_DO_BT FROM CACH_THUC_HIEN WHERE MS_CACH_TH='02'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                MS_LOAI_BT = dtReader.Item(0)
                LY_DO_BT = dtReader.Item(1)
            End While
            dtReader.Close()
        Else
            MS_PBT = gvYCNSD.GetDataRow(ind)("MS_PBT")
        End If

        Commons.Modules.SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='04',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & gvYCNSD.GetDataRow(ind)("MS_CONG_NHAN") & "',NGAY_XU_LY='" & Format(Now, "MM/dd/yyyy") & "',GIO_XU_LY='" & Format(Now, "HH:mm") & "' WHERE STT=" & gvYCNSD.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvYCNSD.GetDataRow(ind)("MS_MAY") & "' AND STT_VAN_DE=" & gvYCNSD.GetDataRow(ind)("STT_VAN_DE")
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub

    Sub LapPBT1_tab3(ByVal ind As Integer)
        Dim MS_PBT, LY_DO_BT As String
        LY_DO_BT = ""
        Dim MS_LOAI_BT As Integer
        If IsDBNull(gvYCNSD.GetDataRow(ind)("MS_PBT")) Or gvYCNSD.GetDataRow(ind)("MS_PBT") = "" Then
            MS_PBT = Commons.Modules.ObjSystems.TangMS_PBT
            Commons.Modules.SQLString = "SELECT MS_LOAI_BT,LY_DO_BT FROM CACH_THUC_HIEN WHERE MS_CACH_TH='02'"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                MS_LOAI_BT = dtReader.Item(0)
                LY_DO_BT = dtReader.Item(1)
            End While
            dtReader.Close()

            Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI(MS_PHIEU_BAO_TRI,TINH_TRANG_PBT,MS_MAY,MS_LOAI_BT,NGUOI_LAP,NGAY_LAP,GIO_LAP,LY_DO_BT,NGAY_BD_KH,USERNAME_NGUOI_LAP,NGAY_KT_KH, UPDATE_NGAY_CUOI) VALUES(N'" & MS_PBT & "',1,'" & gvYCNSD.GetDataRow(ind)("MS_MAY") & "'," & MS_LOAI_BT & ",'" & gvYCNSD.GetDataRow(ind)("MS_CONG_NHAN") & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Format(TimeValue(Now), "HH:mm") & "','" & LY_DO_BT & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Commons.Modules.UserName & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            'Dim str1 As String = "UPDATE PHIEU_BAO_TRI SET UPDATE_NGAY_CUOI = '" & If(NGAY_BD_KH = "01/01/1900", Nothing, NGAY_BD_KH.ToString("yyy/MM/dd")) & "' WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
            'SqlHelper.ExecuteNonQuery(tran, CommandType.Text, str1)
        Else
            MS_PBT = gvYCNSD.GetDataRow(ind)("MS_PBT")
        End If


        Commons.Modules.SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT='" & MS_PBT & "',MS_CACH_TH='04',USERNAME='" & Commons.Modules.UserName & "',MS_CONG_NHAN='" & gvYCNSD.GetDataRow(ind)("MS_CONG_NHAN") & "',NGAY_XU_LY='" & Format(Now, "MM/dd/yyyy") & "',GIO_XU_LY='" & Format(Now, "HH:mm") & "' WHERE STT=" & gvYCNSD.GetDataRow(ind)("STT") & " AND MS_MAY=N'" & gvYCNSD.GetDataRow(ind)("MS_MAY") & "' AND STT_VAN_DE=" & gvYCNSD.GetDataRow(ind)("STT_VAN_DE")
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub

#Region "KEHOACHTONGTHE"
    Private Sub radChuaGiaiQuyet1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radChuaGiaiQuyet1.CheckedChanged
        If radChuaGiaiQuyet1.Checked = False Then Exit Sub
        tmp_cv = -1
        tmp_pt = -1
        LoadData()

        BtnThem1.Enabled = True
        btnLPBT.Enabled = True
        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
            btnLPBT.Enabled = False
        End If



        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
            dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
            CalularDataSelected(dataHangMucSelected)
        End If
    End Sub

    Sub LoadData()

        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Dim str As String = ""

        Me.Cursor = Cursors.WaitCursor
        dtTable_KHTT = New DataTable()


        Dim scon As New SqlConnection(Commons.IConnections.CNStr)
        Try
            scon.Open()
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New", "msgConnectKhongThanhCong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Dim command As New SqlCommand





        If radChuaGiaiQuyet1.Checked Then


            'dtTable_KHTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_KHTT",
            '            cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue,
            '            IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue), Commons.Modules.UserName,
            '            cboDiaDiem_1.EditValue.ToString(), cboHThong.EditValue, dtpTNKHTT.DateTime.Date, dtpDNKHTT.DateTime.Date))
            command = New SqlCommand("SP_NHU_Y_GET_KHTT", scon)


        ElseIf RadBoQua1.Checked Then
            'dtTable_KHTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_KHTT_BO_QUA",
            '            cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue,
            '            IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue), Commons.Modules.UserName,
            '            cboDiaDiem_1.EditValue.ToString(), cboHThong.EditValue, dtpTNKHTT.DateTime.Date, dtpDNKHTT.DateTime.Date))
            command = New SqlCommand("SP_NHU_Y_GET_KHTT_BO_QUA", scon)

        Else
            'dtTable_KHTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_KHTT_DA_GIAI_QUYET",
            '            cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue,
            '            IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue), Commons.Modules.UserName,
            '            dtpTNKHTT.DateTime.Date, dtpDNKHTT.DateTime.Date,
            '            cboDiaDiem_1.EditValue.ToString(), cboHThong.EditValue))

            command = New SqlCommand("SP_NHU_Y_GET_KHTT_DA_GIAI_QUYET", scon)


        End If
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@MS_LOAI_MAY", cboLoaiThietBiBTDK.EditValue)
        command.Parameters.AddWithValue("@MS_NHOM_MAY", CboNhomThietBiBTDK.EditValue)
        command.Parameters.AddWithValue("@MS_MAY", IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue))
        command.Parameters.AddWithValue("@USERNAME", Commons.Modules.UserName)
        command.Parameters.AddWithValue("@TU_NGAY", dtpTNKHTT.DateTime.Date)
        command.Parameters.AddWithValue("@DEN_NGAY", dtpDNKHTT.DateTime.Date)
        command.Parameters.AddWithValue("@MS_NHA_XUONG", cboDiaDiem_1.EditValue)
        command.Parameters.AddWithValue("@MS_HE_THONG", cboHThong.EditValue)
        command.CommandTimeout = 99999

        If (scon.State = ConnectionState.Closed) Then
            scon.Open()
        End If
        dtTable_KHTT.Load(command.ExecuteReader())
        scon.Close()

        For Each col As DataColumn In dtTable_KHTT.Columns
            col.ReadOnly = False
        Next
        Try
            Dim sBTCN As String = "CN_KHTT_TMP" & Commons.Modules.UserName
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTCN, dtTable_KHTT, "")

            Dim sCNLoc As String
            sCNLoc = cboNTHien.EditValue
            Commons.Modules.SQLString = "0LOAD"
            str = "SELECT DISTINCT A.MS_CONG_NHAN, B.HO + ' ' + B.TEN AS HO_TEN FROM " & sBTCN & " A INNER JOIN CONG_NHAN B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN " &
                    " UNION SELECT '-1' , ' < ALL > '  UNION SELECT '' , '' ORDER BY A.MS_CONG_NHAN "
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNTHien, dtTmp, "MS_CONG_NHAN", "HO_TEN", "")
            cboNTHien.EditValue = "-1"
            If Not sCNLoc.Equals(Nothing) Then cboNTHien.EditValue = sCNLoc

        Catch ex As Exception

        End Try

        Commons.Modules.SQLString = ""


        LocData()

        Commons.Modules.SQLString = "0Load"
        gdKHTT.DataSource = dtTable_KHTT

        Commons.Modules.ObjSystems.MLoadNNXtraGrid(gvKHTT, "frmKehoachtongthe_odd")
        gvKHTT.BestFitColumns()


        Commons.Modules.SQLString = ""
        If dtTable_KHTT.Rows.Count <= 0 Then
            gdCVTT.DataSource = DBNull.Value
            gdVTTT.DataSource = DBNull.Value
        End If
        BindDataCV()
        BindDataVTPT()
        CBOLYDOSUACHUA.ColumnEdit = repositoryItemLookUpEdit2
        cboNgayLap.ColumnEdit = repositoryItemDateEdit1
        cboNgayDKHT.ColumnEdit = repositoryItemDateEdit1

        cboMS_UU_TIEN.ColumnEdit = cboMsUTien
        cboMS_CN_PT.ColumnEdit = cboCNPTrach

        gvKHTT.Columns("NGAY").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboNgayLap", Commons.Modules.TypeLanguage)
        gvKHTT.Columns("LY_DO_SC").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboLYDOSUACHUA", Commons.Modules.TypeLanguage)



        gvKHTT.Columns("MS_MAY").BestFit()
        gvKHTT.Columns("NGAY").BestFit()
        gvKHTT.Columns("NGAY_DK_HT").BestFit()
        gvKHTT.Columns("TONG_THOI_GIAN").Width = gvKHTT.Columns("NGAY_DK_HT").Width

        gvKHTT.Columns("YC_MO_TA").Visible = False
        gvKHTT.Columns("YC_CHUNG").Visible = False
        gvKHTT.Columns("YC").Visible = False

        lblTong.Text = Tong & ": " & dtTable_KHTT.Rows.Count.ToString()



        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
            dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
            CalularDataSelected(dataHangMucSelected)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Sub LocData()
        Try
            If Commons.Modules.SQLString = "0LOAD" Then Exit Sub

            If cboNTHien.Text = "" Then
                dtTable_KHTT.DefaultView.RowFilter = " ISNULL(MS_CONG_NHAN,'') = '' "
            Else
                If cboNTHien.EditValue = "-1" Then
                    dtTable_KHTT.DefaultView.RowFilter = ""
                Else
                    dtTable_KHTT.DefaultView.RowFilter = " ISNULL(MS_CONG_NHAN,'') = '" & cboNTHien.EditValue & "' "
                End If
            End If

        Catch ex As Exception
            dtTable_KHTT.DefaultView.RowFilter = ""
        End Try
    End Sub

    Sub LoadNgayLap()
        Dim col As New Commons.CalendarColumn()
        col.Name = "cboNgayLap"
        col.DataPropertyName = "NGAY"
    End Sub

    Sub LoadNgayDKHT()
        Dim col As New Commons.CalendarColumn()
        col.Name = "cboNgayDKHT"
        col.DataPropertyName = "NGAY_DK_HT"
    End Sub

    Sub LoadMayKHTT()
        Dim dtTable As New DataTable
        Dim cboColumn As New DataGridViewComboBoxColumn
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionMAY_KHTT", Commons.Modules.UserName))
        cboColumn.Name = "cboMay"
        cboColumn.ValueMember = "MS_MAY"
        cboColumn.DisplayMember = "MSMAY"
        cboColumn.DataPropertyName = "MS_MAY"
        cboColumn.DataSource = dtTable
    End Sub

    Sub LoadCACHTHUCHIEN1()
        Dim cboColumn As New DataGridViewComboBoxColumn()
        Dim dtTable1 As New DataTable
        dtTable1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCACH_THUC_HIEN_KHTT", Commons.Modules.TypeLanguage))
        cboColumn.Name = "cboCACHTHUCHIEN"
        cboColumn.ValueMember = "MS_CACH_TH"
        cboColumn.DisplayMember = "TEN_CACH_TH"
        cboColumn.DataPropertyName = "MS_CACH_TH"
        cboColumn.DataSource = dtTable1
    End Sub

    Sub LoadPBT1()
        Dim cboColumn As New DataGridViewComboBoxColumn()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPBT_CHUA_HT"))
        cboColumn.Name = "cboPBT"
        cboColumn.ValueMember = "MS_PHIEU_BAO_TRI"
        cboColumn.DisplayMember = "TEN_PHIEU_BAO_TRI"
        cboColumn.DataPropertyName = "MS_PBT"
        cboColumn.DataSource = dtTable
    End Sub

    Sub LoadLYDOSUACHUA()
        Dim cboColumn As New DataGridViewComboBoxColumn()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLY_DO_SUA_CHUA", Commons.Modules.TypeLanguage))
        cboColumn.Name = "cboLYDOSUACHUA"
        cboColumn.ValueMember = "MS_LY_DO"
        cboColumn.DisplayMember = "TEN_LY_DO"
        cboColumn.DataPropertyName = "LY_DO_SC"
        cboColumn.DataSource = dtTable
    End Sub
#End Region

    Private Sub radDaGiaiQuyet1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDaGiaiQuyet1.CheckedChanged
        If radDaGiaiQuyet1.Checked = False Then Exit Sub
        tmp_cv = -1
        tmp_pt = -1
        LoadData()
        BtnThem1.Enabled = False
        btnLPBT.Enabled = False

        dtpTNKHTT.Enabled = True
        dtpDNKHTT.Enabled = True
        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
        End If
    End Sub


    Sub HideButton(ByVal An As Boolean)
        btnChonCV.Visible = An
        btnChonPT.Visible = An
        btnChonMay.Visible = An
        BtnGhi1.Visible = An
        BtnKhongghi1.Visible = An


        btnXoa.Visible = Not An
        BtnThem1.Visible = Not An
        btnLPBT.Visible = Not An
        BtnThoat1.Visible = Not An
        BtnIn.Visible = Not An
        btnLydosuachua.Visible = Not An


        If (btnMucUuTienFlag = True) Then
            btnCapNhatMUT.Visible = An
        Else
            btnCapNhatMUT.Visible = False

        End If

    End Sub

    Sub LockData1(ByVal Khoa As Boolean)
        radChuaGiaiQuyet1.Enabled = Not Khoa
        RadBoQua1.Enabled = Not Khoa
        radDaGiaiQuyet1.Enabled = Not Khoa
        dtpTNKHTT.Enabled = Not Khoa
        dtpDNKHTT.Enabled = Not Khoa
        cboLoaiThietBiBTDK.Enabled = Not Khoa
        CboNhomThietBiBTDK.Enabled = Not Khoa
        CboMaSoThietBiBTDK.Enabled = Not Khoa
        cboDiaDiem_1.Enabled = Not Khoa
        cboHThong.Enabled = Not Khoa
        BtnChonTatCa1.Enabled = Not Khoa
        BtnBoChonTatCa1.Enabled = Not Khoa
        NONN.Enabled = Not Khoa
    End Sub
    Sub ResetData()
        Try
            Commons.Modules.SQLString = "DROP TABLE KHTCV_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try
        Try
            Commons.Modules.SQLString = "DROP TABLE KHTCVPT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try
    End Sub
    Sub EditData()
        Commons.Modules.ObjSystems.XoaTable("KHTCV_TMP" & Commons.Modules.UserName)
        Commons.Modules.SQLString = "CREATE TABLE KHTCV_TMP" & Commons.Modules.UserName & " (MS_MAY nvarchar (30) NOT NULL, HANG_MUC_ID int NOT NULL, MS_CV int NOT NULL, " &
                " MS_BO_PHAN [nvarchar] (50)NOT NULL, MS_UU_TIEN int NULL , GHI_CHU nvarchar (255) NULL , MS_PHIEU_BAO_TRI nvarchar (20) NULL , EOR_ID nvarchar (20) NULL ,  " &
                " KHONG_GQ bit NOT NULL DEFAULT 0,THUE_NGOAI bit NOT NULL DEFAULT 0 ,[THOI_GIAN_DU_KIEN] [FLOAT] NULL ,[SNGUOI] [int] NULL,[YCAU_NS] [nvarchar](1000) NULL,[YCAU_DC] [nvarchar](1000) NULL, CONSTRAINT PK_KHTCV_TMP" & Commons.Modules.UserName &
                " PRIMARY KEY CLUSTERED (MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN) ON [PRIMARY]) ON [PRIMARY]"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Commons.Modules.SQLString = "INSERT INTO KHTCV_TMP" & Commons.Modules.UserName &
                    " ([MS_MAY],[HANG_MUC_ID],[MS_CV],[MS_BO_PHAN],[MS_UU_TIEN],[GHI_CHU],[MS_PHIEU_BAO_TRI],[EOR_ID],[KHONG_GQ],[THUE_NGOAI],[THOI_GIAN_DU_KIEN],[SNGUOI],[YCAU_NS],[YCAU_DC]) " &
                    " SELECT [MS_MAY],[HANG_MUC_ID],[MS_CV],[MS_BO_PHAN],[MS_UU_TIEN],[GHI_CHU]," &
                    " [MS_PHIEU_BAO_TRI],[EOR_ID],ISNULL(KHONG_GQ,0) AS KHONG_GQ , ISNULL(THUE_NGOAI,0) AS THUE_NGOAI,[THOI_GIAN_DU_KIEN],[SNGUOI],[YCAU_NS],[YCAU_DC]  FROM KE_HOACH_TONG_CONG_VIEC"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.ObjSystems.XoaTable("KHTCVPT_TMP" & Commons.Modules.UserName)
        Commons.Modules.SQLString = "CREATE TABLE KHTCVPT_TMP" & Commons.Modules.UserName & " ( MS_MAY nvarchar (30)NOT NULL, " &
                " HANG_MUC_ID int NOT NULL, MS_CV int NOT NULL,MS_BO_PHAN nvarchar (50) NOT NULL, MS_PT nvarchar (25) NOT NULL, SO_LUONG float NULL, " &
                " GHI_CHU nvarchar (255) NULL , DON_GIA_KH numeric(18, 2) NULL, TIEN_TE_KH numeric(18, 2) NULL, TY_GIA_KH numeric(18, 2) NULL, " &
                " TY_GIA_USD_KH numeric(18, 2) NULL, DON_GIA_CUOI numeric(18, 2) NULL, NGAY_LAY_DG_KH datetime NULL , " &
                " CONSTRAINT PK_KHTCVPT_TMP" & Commons.Modules.UserName &
                " PRIMARY KEY CLUSTERED (MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT) ON [PRIMARY]) ON [PRIMARY]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "INSERT INTO KHTCVPT_TMP" & Commons.Modules.UserName & " ([MS_MAY],[HANG_MUC_ID],[MS_CV],[MS_BO_PHAN],[MS_PT],[SO_LUONG],[GHI_CHU],[DON_GIA_KH],[TIEN_TE_KH],[TY_GIA_KH],[TY_GIA_USD_KH],[DON_GIA_CUOI],[NGAY_LAY_DG_KH]) SELECT [MS_MAY],[HANG_MUC_ID],[MS_CV],[MS_BO_PHAN],[MS_PT],[SO_LUONG],[GHI_CHU],[DON_GIA_KH],[TIEN_TE_KH],[TY_GIA_KH],[TY_GIA_USD_KH],[DON_GIA_CUOI],[NGAY_LAY_DG_KH] FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

    End Sub
    Private Sub BtnThem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem1.Click
        'Dim ind As Integer

        HideButton(True)
        LockData1(True)
        Try
            bShowMonitoring = False
            If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
                bShowMonitoring = True
            End If

            If DockPanel1.Visibility <> DevExpress.XtraBars.Docking.DockVisibility.Hidden Then
                DockPanel1.Hide()
            End If





            If radChuaGiaiQuyet1.Checked Then
                EnalbeGrid(True)
                blnThemSua = True
                EditData()
                Dim sql As String = "select ISNULL(MAX(HANG_MUC_ID),0) FROM KE_HOACH_TONG_THE"
                j = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            ElseIf RadBoQua1.Checked Then
                Commons.MssBox.Show(Me.Name, "MsgQuyenKT13")
                gvCVTT.Columns("KHONG_GQ").OptionsColumn.AllowEdit = True
                gvCVTT.Columns("THUE_NGOAI").OptionsColumn.AllowEdit = True
                btnChonCV.Enabled = False
                btnChonPT.Enabled = False
                btnChonMay.Enabled = False
            End If


            'Không cho nhập, vì nó lấy từ bảng khác qua dbo.GetThongSoYC(hangmucid, 1 or 2 or 3)
            gvKHTT.Columns("YC_CHUNG").OptionsColumn.AllowEdit = False
            gvKHTT.Columns("YC_MO_TA").OptionsColumn.AllowEdit = False
            gvKHTT.Columns("YC").OptionsColumn.AllowEdit = False

            dtTable_CV_TEMP.Clear()
            dtTable_CV_TEMP = dtTable_CV.Copy()
            count = gvKHTT.RowCount
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub RadBoQua3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadBoQua3.Click
        'RemoveHandler dtpTuNgay3.ValueChanged, AddressOf Me.dtpTuNgay3_ValueChanged
        'RemoveHandler dtpDenNgay3.ValueChanged, AddressOf Me.dtpDenNgay3_ValueChanged
        LoadDataYCNSD()
        dtpTNYCSD.Enabled = False
        dtpDNYCSD.Enabled = False
        btnThucHien2.Enabled = False
        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThucHien2.Enabled = False
        End If
    End Sub

    Private Sub RadBoQua2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadBoQua2.Click, radDaGiaiQuyet2.Click, radChuaGiaiQuyet2.Click
        LoadDataTSGSTT()

        If radDaGiaiQuyet2.Checked Then
            dtpTNGSTT.Enabled = True
            dtpDNGSTT.Enabled = True
        Else
            'dtpTNGSTT.Enabled = False
            'dtpDNGSTT.Enabled = False
            dtpTNGSTT.Enabled = True
            dtpDNGSTT.Enabled = True
        End If

        If Commons.Modules.PermisString.Equals("Read only") Then
            btnThucHien1.Enabled = False
            btnHuy.Enabled = False
        Else
            If radDaGiaiQuyet2.Checked Or RadBoQua2.Checked Then
                btnThucHien1.Enabled = False
                btnHuy.Enabled = True
            Else
                btnThucHien1.Enabled = True
                btnHuy.Enabled = False
            End If
        End If
    End Sub

    Sub LoadDataTSGSTT()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim dtTable As New DataTable

        ' chua giai quyet
        If radChuaGiaiQuyet2.Checked Then
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", cboDiaDiem_1.EditValue, cboHThong.EditValue, cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue, CboMaSoThietBiBTDK.EditValue, 1, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        ElseIf RadBoQua2.Checked Then
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", cboDiaDiem_1.EditValue, cboHThong.EditValue, cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue, CboMaSoThietBiBTDK.EditValue, 2, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        ElseIf radDaGiaiQuyet2.Checked Then
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", cboDiaDiem_1.EditValue, cboHThong.EditValue, cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue, CboMaSoThietBiBTDK.EditValue, 3, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Else
            radChuaGiaiQuyet2.Checked = True
            dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                        "spGetGiamSatKhongDat", cboDiaDiem_1.EditValue, cboHThong.EditValue, cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue, CboMaSoThietBiBTDK.EditValue, 1, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        End If
        Try
            For Each cl As DataColumn In dtTable.Columns
                cl.ReadOnly = False
            Next
        Catch ex As Exception
        End Try
        dtTable.Columns("CHON").ReadOnly = False
        Commons.Modules.ObjSystems.MLoadXtraGrid(gdTSGSTT, gvTSGSTT, dtTable, True, False, False, True, True, Me.Name)
        Me.Cursor = Cursors.Default
        If gvTSGSTT.Columns("MS_TT").Visible = False Then Exit Sub
        gvTSGSTT.Columns("MS_CACH_TH").Visible = False
        gvTSGSTT.Columns("MS_TS_GSTT").Visible = False
        gvTSGSTT.Columns("MS_BO_PHAN").Visible = False
        gvTSGSTT.Columns("STT").Visible = False
        gvTSGSTT.Columns("STT_GT").Visible = False
        gvTSGSTT.Columns("MS_CONG_NHAN").ColumnEdit = repositoryItemLookUpEdit6
        gvTSGSTT.Columns("NGAY_GIO_KT_MAX").DisplayFormat.FormatString = "MM/dd/yyyy"
        gvTSGSTT.Columns("NGAY_GIO_KT_MAX").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Dim str As String = ""
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvTSGSTT.Columns
            Select Case col.FieldName
                'Case "MS_CONG_NHAN", "MS_PBT", "MS_CACH_TH"
                Case "CHON"
                    col.OptionsColumn.AllowEdit = True
                Case Else
                    col.OptionsColumn.AllowEdit = False
            End Select
        Next
        Me.Cursor = Cursors.Default
        gvTSGSTT.Columns("MS_TT").Visible = False
    End Sub
    Private Sub EnalbeGrid(ByVal bool As Boolean)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvKHTT.Columns
            col.OptionsColumn.AllowEdit = bool
        Next
        gvKHTT.Columns("Choose").OptionsColumn.AllowEdit = True
        gvKHTT.Columns("MS_MAY").OptionsColumn.AllowEdit = False
        gvKHTT.Columns("TONG_THOI_GIAN").OptionsColumn.AllowEdit = False
        gvCVTT.Columns("THUE_NGOAI").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("KHONG_GQ").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("GHI_CHU").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("MS_UU_TIEN").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("SO_LUONG").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("GHI_CHU").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("THOI_GIAN_DU_KIEN").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("SNGUOI").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("YCAU_NS").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("YCAU_DC").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("THAO_TAC").OptionsColumn.AllowEdit = False
        gvCVTT.Columns("TIEU_CHUAN_KT").OptionsColumn.AllowEdit = False
        gvVTTT.Columns("DON_GIA_KH").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("TIEN_TE_KH").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("TY_GIA_KH").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("TY_GIA_USD_KH").OptionsColumn.AllowEdit = bool
    End Sub
    Private Sub UpdateDataKHTT_CV(ByVal tran As SqlTransaction)

        'lay nhung hang muc them moi và edit 
        Dim tbHangMucUpdate As New DataTable()
        tbHangMucUpdate = CType(gdKHTT.DataSource, DataTable).Copy()
        tbHangMucUpdate.DefaultView.RowFilter = "RecordAction <> 0"

        For Each _rowUD As DataRow In tbHangMucUpdate.DefaultView.ToTable().Rows
            'Update cong viec 
            Dim _sqlCVHangMucFromTableTMP As String = "Select * from KHTCV_TMP" & Commons.Modules.UserName & " where HANG_MUC_ID = '" & _rowUD("HANG_MUC_ID").ToString() & "'"
            Dim TbCongViecUpdate As New DataTable()
            TbCongViecUpdate.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, _sqlCVHangMucFromTableTMP))
            Dim _khong_GQ As Boolean = False
            Dim _thue_ngoai As Boolean = False
            Dim _ms_bp As String = ""
            Dim _ghi_chu_temp As String = ""
            Dim _ms_may As String = ""
            Dim _ms_uu_tien As Integer
            Dim _hang_muc As Integer
            Dim _cv As Integer
            Dim _SNguoi As Integer
            Dim _YCNsu As String
            Dim _YCDCu As String
            Dim _THOI_GIAN_DU_KIEN As Double
            Dim dtTmp As New DataTable
            dtTmp = TbCongViecUpdate 'CType(gdCVTT.DataSource, DataTable)

            For Each _dr As DataRow In dtTmp.Rows
                Try
                    If Convert.ToBoolean(_dr("KHONG_GQ")) Then _khong_GQ = True Else _khong_GQ = False
                Catch ex As Exception
                    _khong_GQ = False
                End Try
                Try
                    If Convert.ToBoolean(_dr("THUE_NGOAI")) Then _thue_ngoai = True Else _thue_ngoai = False
                Catch ex As Exception
                    _thue_ngoai = False
                End Try
                _hang_muc = _dr("HANG_MUC_ID")
                _cv = _dr("MS_CV")
                _ms_bp = _dr("MS_BO_PHAN")

                Try
                    _ghi_chu_temp = _dr("GHI_CHU")
                Catch ex As Exception
                    _ghi_chu_temp = ""
                End Try
                Try
                    _ms_uu_tien = _dr("MS_UU_TIEN")
                Catch ex As Exception
                    _ms_uu_tien = 2
                End Try

                _ms_may = _dr("MS_MAY")

                Try
                    _THOI_GIAN_DU_KIEN = _dr("THOI_GIAN_DU_KIEN")
                Catch ex As Exception
                    _THOI_GIAN_DU_KIEN = Nothing
                End Try


                Try
                    _SNguoi = _dr("SNGUOI")
                Catch ex As Exception
                    _SNguoi = Nothing
                End Try

                Try
                    _YCNsu = _dr("YCAU_NS")
                Catch ex As Exception
                    _YCNsu = Nothing
                End Try
                Try
                    _YCDCu = _dr("YCAU_DC")
                Catch ex As Exception
                    _YCDCu = Nothing
                End Try










                Dim sql As String = "Select COUNT(*) FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY ='" & _ms_may & "' AND MS_CV=" & _cv & " AND MS_BO_PHAN ='" & _ms_bp & "' AND HANG_MUC_ID=" & _hang_muc
                If Convert.ToInt16(SqlHelper.ExecuteScalar(tran, CommandType.Text, sql)) > 0 Then
                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", _ms_may, _hang_muc, _cv, _ms_bp, Me.Name, Commons.Modules.UserName, 2)
                    SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_UPDATE_KHTTCV_CHUA_GQ", _khong_GQ, _thue_ngoai, _hang_muc, _ms_bp, _cv, _ghi_chu_temp, _ms_uu_tien, _THOI_GIAN_DU_KIEN, _SNguoi, _YCNsu, _YCDCu)
                Else
                    SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_INSERT_KHTTCV_CHUA_GQ", _khong_GQ, _thue_ngoai, _hang_muc, _ms_bp, _cv, _ghi_chu_temp, _ms_uu_tien, _ms_may, _THOI_GIAN_DU_KIEN, _SNguoi, _YCNsu, _YCDCu)
                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", _ms_may, _hang_muc, _cv, _ms_bp, Me.Name, Commons.Modules.UserName, 1)

                    Dim dt1 As New DataTable

                    sql = "SELECT * FROM CAU_TRUC_THIET_BI_CONG_VIEC WHERE MS_MAY = '" & _ms_may & "' AND MS_CV = " & _cv & " AND MS_BO_PHAN = '" & _ms_bp & "'"
                    dt1.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, sql))
                    If (dt1.Rows.Count = 0) Then
                        sql = "INSERT INTO [dbo].[CAU_TRUC_THIET_BI_CONG_VIEC] ([MS_MAY],[MS_BO_PHAN],[MS_CV],[GHI_CHU],[ACTIVE], TG_KH)
                               VALUES('" & _ms_may & "', '" & _ms_bp & "', '" & _cv & "', '" & _ghi_chu_temp & "', 1, '" & _THOI_GIAN_DU_KIEN & "')"
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql)
                    End If
                End If
            Next
        Next

    End Sub
    Private Sub UpdateDataKHTT(ByVal tran As SqlTransaction)
        Dim _hang_muc_id As Integer
        Dim ngay As Date
        Dim ngay_bd_kh As Date
        Dim ms_may As String
        Dim ten_hang_muc As String
        Dim ghi_chu As String
        Dim ly_do_sc As Integer
        Dim MucUTien As Integer
        Dim CNhan As String
        Dim ActionRecord As Integer

        If gvKHTT.RowCount > 0 Then
            For i As Integer = 0 To gvKHTT.RowCount - 1
                Try
                    If Convert.ToDateTime(gvKHTT.GetDataRow(i)("NGAY")) > Convert.ToDateTime(gvKHTT.GetDataRow(i)("NGAY_DK_HT")) Then
                        gvKHTT.FocusedRowHandle = i
                        Commons.MssBox.Show(Me.Name, "msgTuNgayNhoHonDenNgay")
                        success = False
                        Return
                    End If

                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message)
                End Try

                If String.IsNullOrEmpty(gvKHTT.GetDataRow(i)("TEN_HANG_MUC").ToString) Then
                    gvKHTT.FocusedRowHandle = i
                    Commons.MssBox.Show(Me.Name, "msgPhaiNhapHangMucSuaChua")
                    success = False
                    Return
                End If
                If gvKHTT.GetDataRow(i)("LY_DO_SC") = -1 Then
                    gvKHTT.FocusedRowHandle = i
                    Commons.MssBox.Show(Me.Name, "msgPhaiNhapLyDoSuaChua")
                    success = False
                    Return
                End If
                If String.IsNullOrEmpty(gvKHTT.GetDataRow(i)("MS_UU_TIEN").ToString) Then
                    gvKHTT.FocusedRowHandle = i
                    Commons.MssBox.Show(Me.Name, "msgPhaiNhapMucUuTien")
                    success = False
                    Return
                End If
            Next
        End If
        success = True
        For Each row As DataRow In dtTable_KHTT_TEMP.Rows
            ngay = row("NGAY")
            ten_hang_muc = row("TEN_HANG_MUC")
            _hang_muc_id = row("HANG_MUC_ID")
            ngay_bd_kh = row("NGAY_DK_HT")
            ms_may = row("MS_MAY")
            ghi_chu = Convert.ToString(row("GHI_CHU"))
            ly_do_sc = row("LY_DO_SC")
            MucUTien = row("MS_UU_TIEN")
            CNhan = Convert.ToString(row("MS_CONG_NHAN"))
            ActionRecord = row("RecordAction")
            'Sua lai phan cap nhat KHTT
            If ActionRecord = 1 Then ' them moi
                Dim sql As String = "select ISNULL(MAX(HANG_MUC_ID),0) FROM KE_HOACH_TONG_THE"
                Dim max_hang_muc_id = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, CommandType.Text, sql)) + 1

                'Chuyen trang thai so tang tu dong 
                Dim _sql As String = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, _sql)

                ' them moi vao database
                SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_INSERT_KE_HOACH_TONG_THE", ms_may, max_hang_muc_id, ngay, ngay_bd_kh, ten_hang_muc, ghi_chu, ly_do_sc, Commons.Modules.UserName, MucUTien, CNhan)
                Try
                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_THE_LOG", max_hang_muc_id, Me.Name, Commons.Modules.UserName, 1)
                Catch ex As Exception
                End Try

                'Update Hang_muc_id trong table tam (cv và vtpt)

                sql = "update KHTCV_TMP" & Commons.Modules.UserName & " set HANG_MUC_ID = " & max_hang_muc_id.ToString() & " where HANG_MUC_ID = " & _hang_muc_id.ToString() &
                        " update KHTCVPT_TMP" & Commons.Modules.UserName & " set HANG_MUC_ID = " & max_hang_muc_id.ToString() & " where HANG_MUC_ID = " & _hang_muc_id.ToString()
                Try
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql)
                Catch ex As Exception
                End Try

                'Cap nhat Hang_muc_id len tableview hien tai.

                Dim cusRow() As Data.DataRow
                cusRow = CType(gdKHTT.DataSource, DataTable).Select("HANG_MUC_ID = " & _hang_muc_id.ToString())
                If cusRow.Length > 0 Then
                    cusRow(0)("HANG_MUC_ID") = max_hang_muc_id
                End If

            ElseIf ActionRecord = 2 Then ' sua
                Dim _sql As String = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, _sql)
                SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_THE_LOG", _hang_muc_id, Me.Name, Commons.Modules.UserName, 2)
                SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_UPDATE_KE_HOACH_TONG_THE", ms_may, ngay, ngay_bd_kh, ten_hang_muc, ghi_chu, ly_do_sc, Commons.Modules.UserName, _hang_muc_id, MucUTien, CNhan)
                _sql = "SET IDENTITY_INSERT KE_HOACH_TONG_THE OFF"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, _sql)
            End If
        Next
    End Sub
    Private Sub UPDATE_KE_HOACH_TONG_THE(ByVal HANG_MUC_ID As Integer)
        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_KE_HOACH_TONG_THE_LOG", HANG_MUC_ID, Me.Name, Commons.Modules.UserName, 2)
        Catch ex As Exception

        End Try
    End Sub
    Sub UpdateDataKHTT_PT(ByVal tran As SqlTransaction)

        Dim tbHangMucUpdate As New DataTable()
        tbHangMucUpdate = CType(gdKHTT.DataSource, DataTable).Copy()
        tbHangMucUpdate.DefaultView.RowFilter = "RecordAction <> 0"


        For Each _rowUD As DataRow In tbHangMucUpdate.DefaultView.ToTable().Rows



            Dim sql As String
            success = True
            Dim vtb As New DataTable
            sql = "SELECT MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,GHI_CHU," &
                    " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH FROM KHTCVPT_TMP" & Commons.Modules.UserName & " where HANG_MUC_ID =  " & _rowUD("HANG_MUC_ID")
            vtb.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, sql))


            For Each vr As DataRow In vtb.Rows
                SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 3)
                SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 1)
                If Not IsNumeric(vr("SO_LUONG")) Then
                    Commons.MssBox.Show(Me.Name, "MsgQuyenKT25")
                    success = False
                    Exit Sub
                End If
                If vr("SO_LUONG") <= 0 Then
                    Commons.MssBox.Show(Me.Name, "SoLuongNhoHonKhong")
                    success = False
                    Exit Sub
                End If
            Next

            sql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE HANG_MUC_ID IN (SELECT DISTINCT HANG_MUC_ID FROM KHTCVPT_TMP" & Commons.Modules.UserName & ")"
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql)
            sql = "INSERT INTO KE_HOACH_TONG_CONG_VIEC_PHU_TUNG(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,GHI_CHU, " &
                    " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH ) " &
                    " SELECT MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,GHI_CHU, " &
                    " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH FROM KHTCVPT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql)

            Commons.Modules.ObjSystems.XoaTable("DROP TABLE KHTCVPT_TMP" & Commons.Modules.UserName)
        Next
    End Sub
    Sub UpdateDataKTTT_CV_PT(ByVal tran As SqlTransaction)
        For Each row As DataRow In dtTable_KHTT_TEMP.Rows
            SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_UPDATE_KHTT_CV_PT", row("HANG_MUC_ID"), row("MS_MAY"))
        Next
    End Sub
    Private Sub BtnGhi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi1.Click
        Dim tran As SqlTransaction
        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Cursor = Cursors.WaitCursor
        tran = con.BeginTransaction()
        Dim _khong_GQ As Boolean = False
        Dim _thue_ngoai As Boolean = False
        Dim _ms_bp As String = ""
        Dim _ghi_chu_temp As String = ""
        Dim _ms_may As String = ""
        Dim _hang_muc As Integer
        Dim _cv As Integer

        Dim _Hang_muc_select As New DataTable

        _Hang_muc_select = CType(gdKHTT.DataSource, DataTable).Copy()





        If RadBoQua1.Checked Then
            Try
                For Each _dr As DataRow In dtTable_CV_TEMP.Rows
                    If Convert.ToBoolean(_dr("KHONG_GQ")) Then
                        _khong_GQ = True
                    Else
                        _khong_GQ = False

                    End If
                    If Convert.ToBoolean(_dr("THUE_NGOAI")) Then
                        _thue_ngoai = True
                    Else
                        _thue_ngoai = False
                    End If
                    _hang_muc = _dr("HANG_MUC_ID")
                    _cv = _dr("MS_CV")
                    _ms_bp = _dr("MS_BO_PHAN")
                    'SP_NHU_Y_UPDATE_KHTTCV_BO_QUA_LOG
                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", _dr("MS_MAY"), _hang_muc, _cv, _ms_bp, Me.Name, Commons.Modules.UserName, 2)
                    SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_UPDATE_KHTTCV_BO_QUA", _khong_GQ, _thue_ngoai, _hang_muc, _ms_bp, _cv)
                Next
                tran.Commit()
                con.Close()
            Catch ex As Exception
                dtTable_CV_TEMP.Clear()
                dtTable_KHTT_TEMP.Clear()
                tran.Rollback()
                con.Close()
            End Try
        ElseIf radChuaGiaiQuyet1.Checked Then
            Try
                UpdateDataKHTT(tran)
                If success = False Then
                    tran.Rollback()
                    con.Close()
                    Cursor = Cursors.Default
                    Return
                End If
                UpdateDataKHTT_CV(tran)
                UpdateDataKHTT_PT(tran)
                If success = False Then
                    tran.Rollback()
                    con.Close()
                    Cursor = Cursors.Default
                    Return
                End If

                tran.Commit()
                con.Close()
                ResetData()
            Catch ex As Exception
                dtTable_CV_TEMP.Clear()
                dtTable_KHTT_TEMP.Clear()
                tran.Rollback()
                con.Close()
            End Try
        End If
        Dim index As Integer = 0
        If gvKHTT.RowCount = count Then
            index = gvKHTT.FocusedRowHandle
        End If
        EnalbeGrid(False)
        dtTable_CV_TEMP.Clear()
        dtTable_KHTT_TEMP.Clear()
        blnThemSua = False
        HideButton(False)
        LockData1(False)
        intTabInd = -1
        LoadData()
        gvKHTT.FocusedRowHandle = index
        Cursor = Cursors.Default

        _Hang_muc_select.DefaultView.RowFilter = "Choose = true"

        Dim DataHangMuc As New DataTable()
        DataHangMuc = CType(gdKHTT.DataSource, DataTable)

        For _rc As Integer = 0 To DataHangMuc.Rows.Count - 1
            For _rc1 As Integer = 0 To _Hang_muc_select.DefaultView.ToTable().Rows.Count - 1
                If DataHangMuc.Rows(_rc)("HANG_MUC_ID") = _Hang_muc_select.DefaultView.ToTable().Rows(_rc1)("HANG_MUC_ID") Then
                    DataHangMuc.Rows(_rc)("Choose") = True
                    Exit For
                End If
            Next
        Next

        If bShowMonitoring Then
            DockPanel1.Show()
        End If

    End Sub

    Private Sub BtnKhongghi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi1.Click
        blnThemSua = False
        HideButton(False)
        LockData1(False)
        tmp_cv = -1
        tmp_pt = -1
        blnThemSua = False
        btnChonCV.Enabled = True
        btnChonPT.Enabled = True
        btnChonMay.Enabled = True
        Dim index As Integer = gvKHTT.FocusedRowHandle
        LoadData()
        If index <= gvKHTT.RowCount Then
            gvKHTT.FocusedRowHandle = index
        End If
        EnalbeGrid(False)
        dtTable_CV_TEMP.Clear()
        dtTable_KHTT_TEMP.Clear()
        ResetData()
        intTabInd = -1

        'If DockPanel1.Visibility <> DevExpress.XtraBars.Docking.DockVisibility.Hidden Then
        '    DockPanel1.Show()
        'End If

        If bShowMonitoring Then
            DockPanel1.Show()
        End If
    End Sub
    Private Sub RadBoQua1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBoQua1.CheckedChanged
        If RadBoQua1.Checked = False Then Exit Sub
        tmp_cv = -1
        tmp_pt = -1
        LoadData()
        BtnThem1.Enabled = True
        btnLPBT.Enabled = False

        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
            btnLPBT.Enabled = False
        End If
    End Sub

    Sub HideButtonXoa(ByVal An As Boolean)
        BtnThem1.Visible = Not An

        BtnThoat1.Visible = Not An

        BtnTroVe.Visible = An
        BtnIn.Visible = Not An
    End Sub

    Private Sub BtnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVe.Click
        HideButtonXoa(False)
        LockData1(False)
        intTabInd = -1
    End Sub

    Private Sub btnChonCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonCV.Click
        Try
            If gvKHTT.RowCount <= 0 Then
                Commons.MssBox.Show(Me.Name, "MsgQuyenKT20")
                Exit Sub
            End If
            Dim frmChonCV As New FrmChonCongViecChoKHTT()
            frmChonCV.MS_MAY = gvKHTT.GetFocusedDataRow()("MS_MAY")
            frmChonCV.HANG_MUC_ID = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
            frmChonCV.RecNum = gvKHTT.RowCount
            Dim sBT As String
            sBT = "CV_TMP" & Commons.Modules.UserName
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, gvCVTT.DataSource.ToTable(), "")


            If frmChonCV.ShowDialog() = DialogResult.OK Then
                'THUE_NGOAI=0,KHONG_GQ=0,
                Dim sql As String = "SELECT TEN_BO_PHAN,KHTCV.MS_CV,HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & ",KHTCV.MS_MAY,MS_UU_TIEN=3," &
                                     "KHTCV.MS_BO_PHAN,MO_TA_CV,MS_PHIEU_BAO_TRI='',EOR_ID='',ISNULL(KHTCV.GHI_CHU,'') AS GHI_CHU " &
                                     " FROM CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " KHTCV WHERE CHON=1"
                dtTable_CV_TEMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))

                sql = "UPDATE KHTCV_TMP" & Commons.Modules.UserName & " SET THOI_GIAN_DU_KIEN = ISNULL(T2.THOI_GIAN_DU_KIEN,0) " &
                          " FROM KHTCV_TMP" & Commons.Modules.UserName & " T1 INNER JOIN CONG_VIEC T2 ON T1.MS_CV = T2.MS_CV " &
                          " WHERE ISNULL(T1.THOI_GIAN_DU_KIEN,0) = 0 "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)


                sql = "UPDATE KHTCV_TMP" & Commons.Modules.UserName & " SET SNGUOI = ISNULL(SO_NGUOI,1) " &
                            " FROM KHTCV_TMP" & Commons.Modules.UserName & " T1 INNER JOIN CONG_VIEC T2 ON T1.MS_CV = T2.MS_CV " &
                            " WHERE ISNULL(SNGUOI,0) = 0 "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)


                sql = "UPDATE KHTCV_TMP" & Commons.Modules.UserName & " SET YCAU_NS = YEU_CAU_NS " &
                            " FROM KHTCV_TMP" & Commons.Modules.UserName & " T1 INNER JOIN CONG_VIEC T2 ON T1.MS_CV = T2.MS_CV" &
                            " WHERE ISNULL(YCAU_NS,'') = '' "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                sql = "UPDATE KHTCV_TMP" & Commons.Modules.UserName & " SET YCAU_DC = YEU_CAU_DUNG_CU " &
                            " FROM KHTCV_TMP" & Commons.Modules.UserName & " T1 INNER JOIN CONG_VIEC T2 ON T1.MS_CV = T2.MS_CV" &
                            " WHERE ISNULL(YCAU_DC,'') = '' "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                'BẬT CỜ RECORDEDIT LÊN

                If gvKHTT.GetFocusedDataRow("RecordAction").ToString().Equals("0") Then
                    gvKHTT.GetFocusedDataRow("RecordAction") = 2
                End If

                BindDataCV()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Dim autoCompleteSource As New AutoCompleteStringCollection()
    Private Sub BindDataVTPT()
        Try
            dtTable_PT = New DataTable()
            Dim str As String = Commons.Modules.TypeLanguage.ToString()
            Dim sql As String
            If blnThemSua Then
                sql = "SELECT MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,KHTCVPT.MS_PT,TEN_PT , PT.QUY_CACH,SO_LUONG," &
                            "CASE " & str & " WHEN 0 THEN TEN_1 WHEN 0 THEN TEN_2 WHEN 2 THEN TEN_3 END AS TEN_DVT,KHTCVPT.GHI_CHU, " &
                            " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " &
                            " FROM KHTCVPT_TMP" & Commons.Modules.UserName &
                            " KHTCVPT INNER JOIN IC_PHU_TUNG PT ON KHTCVPT.MS_PT=PT.MS_PT" &
                            " INNER JOIN DON_VI_TINH DV ON PT.DVT=DV.DVT WHERE HANG_MUC_ID=" & Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") &
                            " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") &
                            " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                dtTable_PT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            Else
                dtTable_PT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTT_CONG_VIEC_PT",
                    Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), Me.gvCVTT.GetFocusedDataRow("MS_CV"),
                    Me.gvCVTT.GetFocusedDataRow()("MS_BO_PHAN"), Commons.Modules.TypeLanguage))
            End If

            gdVTTT.DataSource = dtTable_PT
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvVTTT.Columns
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindDataCV()
        Try
            dtTable_CV = New DataTable()
            Dim sql As String = ""
            If radChuaGiaiQuyet1.Checked Then
                If blnThemSua = True Then
                    sql = "SELECT (CTTB.MS_BO_PHAN + ' - ' + TEN_BO_PHAN) AS TEN_BO_PHAN,KHTCV.MS_CV,HANG_MUC_ID,KHTCV.MS_MAY,ISNULL(MS_UU_TIEN,3) AS MS_UU_TIEN,KHTCV.MS_BO_PHAN,MO_TA_CV,MS_PHIEU_BAO_TRI,EOR_ID,THUE_NGOAI, " &
                                " KHONG_GQ,ISNULL(KHTCV.GHI_CHU,'') AS GHI_CHU ,KHTCV.THOI_GIAN_DU_KIEN,  KHTCV.SNGUOI, KHTCV.YCAU_NS, KHTCV.YCAU_DC, CV.THAO_TAC, CV.TIEU_CHUAN_KT " &
                                " FROM KHTCV_TMP" & Commons.Modules.UserName & " KHTCV INNER JOIN CONG_VIEC CV ON KHTCV.MS_CV=CV.MS_CV " &
                                " INNER JOIN CAU_TRUC_THIET_BI CTTB ON KHTCV.MS_MAY=CTTB.MS_MAY AND KHTCV.MS_BO_PHAN=CTTB.MS_BO_PHAN WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") &
                                " AND MS_PHIEU_BAO_TRI IS NULL AND EOR_ID IS NULL AND (KHONG_GQ=0 OR KHONG_GQ IS NULL) "
                    dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                Else
                    dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTT_CONG_VIEC", Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), 0))
                End If
            ElseIf RadBoQua1.Checked Then
                dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTT_CONG_VIEC", Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), 1))
            Else
                dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTT_CONG_VIEC", Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), 2))
            End If
            If RadBoQua1.Checked Then
                Dim dr() As DataRow = dtTable_CV_TEMP.Select("HANG_MUC_ID='" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & "'")
                If dr.Length <= 0 Then
                Else
                    Dim i As Integer
                    For i = 0 To dr.Length - 1
                        Dim _dr_temp() As DataRow = dtTable_CV.Select("HANG_MUC_ID='" & dr(i)("HANG_MUC_ID") & "'")
                        If _dr_temp.Length > 0 Then
                            _dr_temp(i)("THUE_NGOAI") = dr(i)("THUE_NGOAI")
                            _dr_temp(i)("KHONG_GQ") = dr(i)("KHONG_GQ")
                            _dr_temp(i)("MS_MAY") = dr(i)("MS_MAY")
                            _dr_temp(i)("MS_UU_TIEN") = dr(i)("MS_UU_TIEN")
                            _dr_temp(i)("GHI_CHU") = dr(i)("GHI_CHU")
                        End If
                    Next i
                End If
            End If

            gdCVTT.DataSource = dtTable_CV
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvCVTT.Columns
                Select Case col.FieldName
                    Case "MS_UU_TIEN"
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboMucUuTien", Commons.Modules.TypeLanguage)
                    Case Else
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
                End Select
            Next

            If dtTable_CV.Rows.Count <= 0 Then
                gdVTTT.DataSource = DBNull.Value
            End If
            MS_UU_TIEN.ColumnEdit = repositoryItemLookUpEdit3
            For Each col As DataColumn In dtTable_CV.Columns
                col.ReadOnly = False
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnChonPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonPT.Click
        Try

            If gvCVTT.RowCount <= 0 Then
                Commons.MssBox.Show(Me.Name, "MsgQuyenKT21")
                Exit Sub
            End If
            Dim FRM As New FrmChonPTChoKHTT

            FRM.MS_MAY = gvCVTT.GetFocusedDataRow()("MS_MAY")
            FRM.HANG_MUC_ID = gvCVTT.GetFocusedDataRow()("HANG_MUC_ID")
            FRM.MS_CV = gvCVTT.GetFocusedDataRow()("MS_CV")
            FRM.MS_BO_PHAN = gvCVTT.GetFocusedDataRow()("MS_BO_PHAN")
            If FRM.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim str As String = ""

                'BẬT CỜ RECORDEDIT LÊN

                If gvKHTT.GetFocusedDataRow("RecordAction").ToString().Equals("0") Then
                    gvKHTT.GetFocusedDataRow("RecordAction") = 2
                End If

                str = " DECLARE @NGAYHT DATETIME " &
                " SET @NGAYHT = GETDATE() " &
                " UPDATE KHTCVPT_TMP" + Commons.Modules.UserName + " SET DON_GIA_KH = B.DON_GIA , TY_GIA_KH = B.TY_GIA,TY_GIA_USD_KH = B.TY_GIA_USD, " &
                " DON_GIA_CUOI = (B.SL_THUC_NHAP *  B.DON_GIA * B.TY_GIA), NGAY_LAY_DG_KH = @NGAYHT " &
                " FROM KHTCVPT_TMP" + Commons.Modules.UserName + " A INNER JOIN  " &
                " (SELECT B.* FROM dbo.IC_DON_HANG_NHAP AS A INNER JOIN " &
                "                       dbo.IC_DON_HANG_NHAP_VAT_TU B ON A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT INNER JOIN " &
                " (SELECT MAX(NGAY) AS NGAYMAX , A.MS_DH_NHAP_PT FROM dbo.IC_DON_HANG_NHAP AS A INNER JOIN " &
                "                       dbo.IC_DON_HANG_NHAP_VAT_TU ON A.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT " &
                " WHERE MS_PT IN (SELECT DISTINCT MS_PT FROM KHTCVPT_TMP" + Commons.Modules.UserName + " WHERE ISNULL(DON_GIA_KH,0) + ISNULL(TIEN_TE_KH,0) +  " &
                " ISNULL(TY_GIA_KH,0) + ISNULL(TY_GIA_USD_KH,0) + ISNULL(DON_GIA_CUOI,0) = 0 )  AND NGAY < = @NGAYHT " &
                " GROUP BY  A.MS_DH_NHAP_PT) C ON A.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT AND A.NGAY = C.NGAYMAX ) B ON A.MS_PT = B.MS_PT "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)


                str = "SELECT MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,KHTCVPT.MS_PT,TEN_PT , PT.QUY_CACH ,TEN_1 AS TEN_DVT,SO_LUONG,KHTCVPT.GHI_CHU, " &
                        " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " &
                        " FROM KHTCVPT_TMP" & Commons.Modules.UserName & " KHTCVPT INNER JOIN IC_PHU_TUNG PT ON KHTCVPT.MS_PT=PT.MS_PT  " &
                        " INNER JOIN DON_VI_TINH DV ON PT.DVT=DV.DVT WHERE HANG_MUC_ID=" & Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") &
                        " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & Me.gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                Dim dtTable As New DataTable()
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                Try
                    gdVTTT.DataSource = dtTable
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub btnXemBangChung1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXemBangChung1.Click
        If gvTSGSTT.RowCount = 0 Then Exit Sub
        Dim frm As New frmDuongDanHinh
        Try
            frm.STT = Integer.Parse(Me.gvTSGSTT.GetFocusedDataRow()("STT").ToString)
            frm.sMS_MAY = gvTSGSTT.GetFocusedDataRow()("MS_MAY").ToString
            frm.sMS_TS_GSTT = gvTSGSTT.GetFocusedDataRow()("MS_TS_GSTT").ToString
            frm.sMS_BO_PHAN = gvTSGSTT.GetFocusedDataRow()("MS_BO_PHAN").ToString
            frm.iMS_TT = Integer.Parse(Me.gvTSGSTT.GetFocusedDataRow()("MS_TT").ToString)

            frm.FLAG = True
            frm.ShowDialog()
        Catch ex1 As Exception
        End Try
    End Sub

    Private Sub btnXemBangChung2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXemBangChung2.Click
        Dim frm As New frmDuongDanHinh
        Try
            frm.STT = Me.gvYCNSD.GetFocusedDataRow()("STT")
            frm.FLAG = False
            frm.ShowDialog()
        Catch ex1 As Exception
        End Try
    End Sub

    Sub RefeshHeaderReport()
        Dim ngay As String = "Ngày in:"
        Dim ngayanh As String = "Date Print:"
        Dim t As String = CStr(Now.Day) + "/" + CStr(Now.Month) + "/" + CStr(Now.Year)
        Dim SqlText As String = ""
        Try
            SqlText = "DROP TABLE rptTHONG_TIN_CHUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        Catch ex As Exception
        End Try
        If Commons.Modules.TypeLanguage = 1 Then

            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_ANH AS TEN_CTY, THONG_TIN_CHUNG.TEN_NGAN_TIENG_ANH AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_ANH AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & t & "',tenngayin='" & ngayanh & "' INTO rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
        If Commons.Modules.TypeLanguage = 0 Then

            SqlText = " SELECT THONG_TIN_CHUNG.TEN_CTY_TIENG_VIET AS TEN_CTY, THONG_TIN_CHUNG.DIA_CHI_VIET AS TEN_NGAN, THONG_TIN_CHUNG.LOGO, THONG_TIN_CHUNG.LOGO_PATH, THONG_TIN_CHUNG.DIA_CHI_VIET AS DIA_CHI, THONG_TIN_CHUNG.Phone ,THONG_TIN_CHUNG.Fax, THONG_TIN_CHUNG.WIDTH, THONG_TIN_CHUNG.HEIGHT, THONG_TIN_CHUNG.TI_LE_PHAN_TRAM, THONG_TIN_CHUNG.STRETCH, THONG_TIN_CHUNG.LE_PHAI_LOGO, THONG_TIN_CHUNG.LE_TREN_LOGO, THONG_TIN_CHUNG.LIM_NUMBER, THONG_TIN_CHUNG.USE_NUMBER , THONG_TIN_CHUNG.NGAY_TAO, THONG_TIN_CHUNG.VI_TRI_KHO, THONG_TIN_CHUNG.DUONG_DAN_TL,ngayin='" & t & "',tenngayin='" & ngay & "' INTO rptTHONG_TIN_CHUNG_TMP FROM THONG_TIN_CHUNG "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        End If
    End Sub

    Sub Printpreview1()
        Cursor = Cursors.WaitCursor
        Dim frm As frmShowXMLReport = New frmShowXMLReport()
        Dim sql As String
        Dim dtTMP As New DataTable


        Dim sMsMay As String
        If CboMaSoThietBiBTDK.EditValue = " < ALL > " Or CboMaSoThietBiBTDK.EditValue Is Nothing Then
            sMsMay = "-1"
        Else
            sMsMay = CboMaSoThietBiBTDK.EditValue
        End If
        Dim iLoai As Integer = 0
        If radChuaGiaiQuyet1.Checked Then iLoai = 0
        If RadBoQua1.Checked Then iLoai = 1
        If radDaGiaiQuyet1.Checked Then iLoai = 2

        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spInKeHoachTongThe", dtpTNKHTT.DateTime.Date, dtpDNKHTT.DateTime.Date, cboDiaDiem_1.EditValue, cboHThong.EditValue,
            cboLoaiThietBiBTDK.EditValue,
            IIf(CboNhomThietBiBTDK.EditValue Is Nothing, "-1", CboNhomThietBiBTDK.EditValue),
            sMsMay, Commons.Modules.UserName, iLoai, Commons.Modules.TypeLanguage))

        dtTMP.TableName = "rptACTION_PLAN_TMP"
        frm.AddDataTableSource(dtTMP)
        RefeshLanguageReport1()
        dtTMP = New DataTable
        sql = "SELECT * FROM insert_rptACTION_PLAN_TMP"
        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        dtTMP.TableName = "insert_rptACTION_PLAN_TMP"
        frm.AddDataTableSource(dtTMP)

        frm.rptName = "rptACTION_PLAN"
        frm.ShowDialog()

        Commons.Modules.ObjSystems.XoaTable("rptACTION_PLAN_TMP")
        Commons.Modules.ObjSystems.XoaTable("insert_rptACTION_PLAN_TMP")

    End Sub

    Private Sub RefeshLanguageReport1()
        Dim NGAY_IN, TIEU_DE, MS_MAY, TEN_LOAI_TB, STT, HANG_MUC, CONG_VIEC, WHO, THOI_GIAN, REMARK, TRANG, MS_BO_PHAN, TEN_BO_PHAN As String

        NGAY_IN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "NGAY_IN", Commons.Modules.TypeLanguage)
        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "TIEU_DE", Commons.Modules.TypeLanguage)
        MS_MAY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "MS_MAY", Commons.Modules.TypeLanguage)
        TEN_LOAI_TB = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "TEN_LOAI_TB", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "STT", Commons.Modules.TypeLanguage)
        HANG_MUC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "HANG_MUC", Commons.Modules.TypeLanguage)
        CONG_VIEC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "CONG_VIEC", Commons.Modules.TypeLanguage)
        WHO = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "WHO", Commons.Modules.TypeLanguage)
        THOI_GIAN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "THOI_GIAN", Commons.Modules.TypeLanguage)
        REMARK = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "REMARK", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "TRANG", Commons.Modules.TypeLanguage)
        TEN_BO_PHAN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
        MS_BO_PHAN = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptACTION_PLAN", "MS_BO_PHAN", Commons.Modules.TypeLanguage)

        Try
            Commons.Modules.SQLString = "DROP TABLE insert_rptACTION_PLAN_TMP"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        Commons.Modules.SQLString = "CREATE TABLE insert_rptACTION_PLAN_TMP(NGAY_IN_ nvarchar(50), TIEU_DE_ nvarchar(50), MS_MAY_ nvarchar(50), TEN_LOAI_TB_ nvarchar(50),STT_ nvarchar(50),HANG_MUC_ nvarchar(50),CONG_VIEC_ nvarchar(50),WHO_ nvarchar(50),THOI_GIAN_ nvarchar(50), REMARK_ nvarchar(50), TRANG_ nvarchar(50),MS_BO_PHAN_ nvarchar(50),TEN_BO_PHAN_ nvarchar(50) )"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "ins_rptACTION_PLAN", NGAY_IN, TIEU_DE, MS_MAY, TEN_LOAI_TB, STT, HANG_MUC, CONG_VIEC, WHO, THOI_GIAN, REMARK, TRANG, MS_BO_PHAN, TEN_BO_PHAN)

    End Sub

    Private Sub BtnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIn.Click
        If gvKHTT.RowCount = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongcoDuLieu", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        If radChuaGiaiQuyet1.Checked = True Then
            Try
                If Commons.Modules.sPrivate = "BARIA" Or Commons.Modules.sPrivate = "VIETSOFT" Then
                    Me.Cursor = Cursors.WaitCursor
                    EportKHTTtoExcelBaria()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message)
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try
        End If

        Cursor = Cursors.WaitCursor
        Try
            'Call CreateData1()
            Call Printpreview1()
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub RefeshLanguageReport3()
        Dim TIEU_DE, TEN_HANG_MUC, STT, LOAI, VAN_DE, NGUOI_KT, NGAY_KT, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "TIEU_DE", Commons.Modules.TypeLanguage)
        TEN_HANG_MUC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "TEN_HANG_MUC", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "STT", Commons.Modules.TypeLanguage)
        LOAI = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "LOAI", Commons.Modules.TypeLanguage)
        VAN_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "VAN_DE", Commons.Modules.TypeLanguage)
        NGUOI_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "NGUOI_KT", Commons.Modules.TypeLanguage)
        NGAY_KT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "NGAY_KT", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNOI_DUNG_GIAI_QUYET_HANG_MUC", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE insert_rptNOI_DUNG_GIAI_QUYET_HANG_MUC_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE insert_rptNOI_DUNG_GIAI_QUYET_HANG_MUC_TMP(TIEU_DE_ nvarchar(50), TEN_HANG_MUC_ nvarchar(50), STT_ nvarchar(50), LOAI_ nvarchar(50), VAN_DE_ nvarchar(50), NGUOI_KT_ nvarchar(50), NGAY_KT_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptNOI_DUNG_GIAI_QUYET_HANG_MUC", TIEU_DE, TEN_HANG_MUC, STT, LOAI, VAN_DE, NGUOI_KT, NGAY_KT, TRANG)

    End Sub

    Private Sub Printpreview3()
        Cursor = Cursors.WaitCursor
        Call ReportPreview("reports\rptNOI_DUNG_GIAI_QUYET_HANG_MUC.rpt")
        Cursor = Cursors.Default
    End Sub

    Private Sub btnXemNguyenNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemNguyenNhan.Click
        If noDataToPrint = False Then
            Printpreview3()
        End If
    End Sub



    Private Sub Printpreview2()
        Cursor = Cursors.WaitCursor

        Call ReportPreview("reports\rptKE_HOACH_TONG_THE_PHU_TUNG.rpt")
        Cursor = Cursors.Default

    End Sub
    Private Sub RefeshLanguageReport2()
        Dim TIEU_DE, STT, MS_PT_CTY, MS_PT, TEN_PT, QUY_CACH, DVT, SL_TON, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "TIEU_DE", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "STT", Commons.Modules.TypeLanguage)
        MS_PT_CTY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "MS_PT_CTY", Commons.Modules.TypeLanguage)
        MS_PT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "MS_PT", Commons.Modules.TypeLanguage)
        TEN_PT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "TEN_PT", Commons.Modules.TypeLanguage)
        QUY_CACH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "QUY_CACH", Commons.Modules.TypeLanguage)

        DVT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "DVT", Commons.Modules.TypeLanguage)
        SL_TON = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "SL_TON", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE insert_rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE insert_rptKE_HOACH_TONG_THE_PHU_TUNG_TMP(TIEU_DE_ nvarchar(50), STT_ nvarchar(50), MS_PT_CTY_ nvarchar(50), MS_PT_ nvarchar(50), TEN_PT_ nvarchar(50) , QUY_CACH_ nvarchar(255)  , DVT_ nvarchar(50), SL_TON_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptKE_HOACH_TONG_THE_PHU_TUNG", TIEU_DE, STT, MS_PT_CTY, MS_PT, TEN_PT, QUY_CACH, DVT, SL_TON, TRANG)

    End Sub
    Private Sub CreateData2_One()
        Dim TEN_DVT As String = ""
        If Commons.Modules.TypeLanguage = 0 Then
            TEN_DVT = "TEN_1"
        ElseIf Commons.Modules.TypeLanguage = 1 Then
            TEN_DVT = "TEN_2"
        ElseIf Commons.Modules.TypeLanguage = 2 Then
            TEN_DVT = "TEN_3"
        End If

        RefeshHeaderReport()
        RefeshLanguageReport2()
        Cursor = Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try

        SqlText = "SELECT     IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT , IC_PHU_TUNG.QUY_CACH, DON_VI_TINH." & TEN_DVT & ",  " &
                      "SUM(VI_TRI_KHO_VAT_TU.SL_VT) AS SUM_SL_TON " &
                    "INTO   rptKE_HOACH_TONG_THE_PHU_TUNG_TMP   FROM         IC_PHU_TUNG INNER JOIN " &
                      "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN " &
                      "VI_TRI_KHO_VAT_TU ON IC_PHU_TUNG.MS_PT = VI_TRI_KHO_VAT_TU.MS_PT " &
                    "WHERE     (IC_PHU_TUNG.MS_PT = '" & gvVTTT.GetFocusedDataRow()("MS_PT") & "') " &
                    "GROUP BY IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.QUY_CACH, DON_VI_TINH." & TEN_DVT
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        noDataToPrint = False

        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"))
        If dt.Rows.Count < 1 Then
            Commons.MssBox.Show(Me.Name, "KHONG_DL_IN")
            noDataToPrint = True
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub CreateData2_All()
        Dim TEN_DVT As String = ""
        If Commons.Modules.TypeLanguage = 0 Then
            TEN_DVT = "TEN_1"
        ElseIf Commons.Modules.TypeLanguage = 1 Then
            TEN_DVT = "TEN_2"
        ElseIf Commons.Modules.TypeLanguage = 2 Then
            TEN_DVT = "TEN_3"
        End If

        RefeshHeaderReport()
        RefeshLanguageReport2()
        Cursor = Cursors.WaitCursor

        Try
            SqlText = "DROP TABLE rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        SqlText = "SELECT  DISTINCT   IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT , IC_PHU_TUNG.QUY_CACH , DON_VI_TINH." & TEN_DVT & ",  " &
                      "(SELECT SUM(SL_VT) FROM VI_TRI_KHO_VAT_TU  WHERE VI_TRI_KHO_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT) AS SUM_SL_TON " &
                    "INTO   rptKE_HOACH_TONG_THE_PHU_TUNG_TMP   FROM    KE_HOACH_TONG_CONG_VIEC_PHU_TUNG inner join " &
                    " IC_PHU_TUNG ON KE_HOACH_TONG_CONG_VIEC_PHU_TUNG.MS_PT =IC_PHU_TUNG.MS_PT INNER JOIN " &
                      "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " &
                     " WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID")
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        noDataToPrint = False

        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"))
        If dt.Rows.Count < 1 Then
            Commons.MssBox.Show(Me.Name, "KHONG_DL_IN")
            noDataToPrint = True
        End If
        Cursor = Cursors.Default

    End Sub
    Private Sub btnLydosuachua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLydosuachua.Click
        Dim frm As Report1.FrmLyDo = New Report1.FrmLyDo()
        If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then frm.ShowDialog()
    End Sub
    Private Sub btnInBTDK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInBTDK.Click, btnInGio.Click
        Try
            If DateDiff(DateInterval.Day, dtpTuNgay.Value, dtpDenNgay.Value) < 0 Then
                Commons.MssBox.Show(Me.Name, "NGAY_KHONG_HOP_LE")
                Exit Sub
            End If

            Dim dvTmp = New DataView
            If tabKeHoachTongThe.SelectedTabPageIndex = 3 Then
                dvTmp = CType(gvBTDK_Gio.DataSource, DataView)
            Else
                dvTmp = CType(gvBTDK.DataSource, DataView)
            End If

            Dim dtTmp As DataTable

            If tabKeHoachTongThe.SelectedTabPageIndex = 3 Then
                dtTmp = dvTmp.ToTable("UniqueLastNames", True, "CHON")
                dtTmp.DefaultView.RowFilter = "CHON = 1"
            Else
                dtTmp = dvTmp.ToTable("UniqueLastNames", True, "chkChon")
                dtTmp.DefaultView.RowFilter = "chkChon = 1"
            End If


            dtTmp = dtTmp.DefaultView.ToTable()

            If dtTmp.Rows.Count = 0 Then
                Commons.MssBox.Show(Me.Name, "CHUA_CHON_DL_IN")
                Return
            End If

            Dim frmIn As New frmInTuKeHoachTongThe

            If tabKeHoachTongThe.SelectedTabPageIndex = 3 Then

                frmIn.optDuTruVT_TheoMay.Checked = True
            End If

            frmIn.ShowDialog()

            Dim iBaoCao As Integer = frmIn.iLoaiBC
            Me.Cursor = Cursors.WaitCursor
            Commons.clsXuLy.CreateTitleReport()
            Select Case iBaoCao
                Case 1      'in bảo trì định kỳ theo năm
                    If CreateDataBTDK1() = False Then
                        Me.Cursor = Cursors.Default
                        Commons.MssBox.Show(Me.Name, "CHUA_CHON_DL_IN")
                        Return
                    End If
                    Call PrintpreviewBTDK()
                    Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_BTDK")
                    Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "tblBTDK_TMP")
                    Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHONG_TIN_CHUNG")

                Case 2      'dự trù vật tư theo máy
                    If CreateDataDuTruVT() = False Then
                        Dim dt As SqlDataReader
                        dt = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDU_TRU_VAT_TU")
                        While dt.Read
                            If dt.Item("TONG") = 0 Then
                                Commons.MssBox.Show(Me.Name, "KHONG_DL_IN")
                                GoTo TT1
                            End If
                        End While

                        CreateTieuDeDuTruVTTheoMay()

                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU_TONG_SO_VTPT")
                        'tao table chua dl cua cac vtpt va so luong duoc su dung
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_PT, TEN_PT, QUY_CACH, ten_1, SUM(ISNULL(SO_LUONG,0)) AS TONG_SL INTO rptDU_TRU_VAT_TU_TONG_SO_VTPT FROM rptDU_TRU_VAT_TU GROUP BY MS_PT, TEN_PT , QUY_CACH, ten_1 ORDER BY MS_PT")

                        Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
                        frmRepot.rptName = "rptDU_TRU_VT_THEO_MAY"
                        Dim sSql As String
                        Dim dtTmp1 As New DataTable

                        sSql = "SELECT * FROM rptTIEU_DE_DU_TRU_VT_THEO_MAY"
                        dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        dtTmp1.TableName = "rptTIEU_DE_DU_TRU_VT_THEO_MAY"
                        frmRepot.AddDataTableSource(dtTmp1)

                        dtTmp1 = New DataTable
                        sSql = "SELECT * FROM rptDU_TRU_VAT_TU"
                        dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        dtTmp1.TableName = "rptDU_TRU_VAT_TU"
                        frmRepot.AddDataTableSource(dtTmp1)

                        dtTmp1 = New DataTable
                        sSql = "SELECT * FROM rptDU_TRU_VAT_TU_TONG_SO_VTPT"
                        dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        dtTmp1.TableName = "rptDU_TRU_VAT_TU_TONG_SO_VTPT"
                        frmRepot.AddDataTableSource(dtTmp1)

                        frmRepot.ShowDialog()
TT1:
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHONG_TIN_CHUNG")
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_DU_TRU_VT_THEO_MAY")
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU")
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU_TONG_SO_VTPT")

                    End If
                Case 3      'dự trù vật tư theo dây chuyền
                    If CreateDataDuTruVT() = False Then
                        Dim dt As SqlDataReader
                        dt = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptDU_TRU_VAT_TU")
                        While dt.Read
                            If dt.Item("TONG") = 0 Then
                                Commons.MssBox.Show(Me.Name, "KHONG_DL_IN")
                                GoTo TT2
                            End If
                        End While

                        CreateTieuDeDuTruVTTheoMay(True)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU_TONG_SO_VTPT")
                        'tao table chua dl cua cac vtpt va so luong duoc su dung
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_PT, TEN_PT, QUY_CACH, ten_1, SUM(ISNULL(SO_LUONG,0)) AS TONG_SL INTO rptDU_TRU_VAT_TU_TONG_SO_VTPT FROM rptDU_TRU_VAT_TU GROUP BY MS_PT, TEN_PT , QUY_CACH, ten_1 ORDER BY MS_PT")
                        Dim sSql As String
                        Dim dtTmp1 As New DataTable

                        Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
                        frmRepot.rptName = "rptDU_TRU_VT_THEO_DAY_CHUYEN"
                        sSql = "SELECT * FROM rptDU_TRU_VAT_TU_TONG_SO_VTPT"
                        dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        dtTmp1.TableName = "rptDU_TRU_VAT_TU_TONG_SO_VTPT"
                        frmRepot.AddDataTableSource(dtTmp1)


                        dtTmp1 = New DataTable
                        sSql = "SELECT * FROM rptTIEU_DE_DU_TRU_VT_THEO_MAY"
                        dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        dtTmp1.TableName = "rptTIEU_DE_DU_TRU_VT_THEO_MAY"
                        frmRepot.AddDataTableSource(dtTmp1)

                        dtTmp1 = New DataTable
                        sSql = "SELECT * FROM rptDU_TRU_VAT_TU"
                        dtTmp1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        dtTmp1.TableName = "rptDU_TRU_VAT_TU"
                        frmRepot.AddDataTableSource(dtTmp1)
                        frmRepot.ShowDialog()
TT2:
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTHONG_TIN_CHUNG")
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_DU_TRU_VT_THEO_MAY")
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU")
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName)
                        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU_TONG_SO_VTPT")
                    End If
                Case 4  'bảo trì định kỳ theo tuần
                    ShowrptKeHoachBaoTriTrongTuan()
                Case 5  'bảo trì định kỳ theo tuần
                    ShowKehoachbaotridinhky_KHTT()
            End Select
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ShowrptKeHoachBaoTriTrongTuan()
        Dim str As String = "", bChon As Boolean = False
        Dim ngay As New Date

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "KeHoachTuanTmp" & Commons.Modules.UserName)
        str = "Create table KeHoachTuanTmp" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(30),MS_LOAI_BT INT,TEN_LOAI_BT NVARCHAR(150)"
        ngay = dtpTuNgay.Value.Date
        While DateDiff(DateInterval.Day, ngay, dtpDenNgay.Value) >= 0       'ngay.Day <= dtpDenNgay.Value.Day
            str += ",N" & ngay.Day.ToString & " NVARCHAR(5)"
            ngay = DateAdd(DateInterval.Day, 1, ngay)
        End While
        str += ")"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim _dt As New DataTable
        Dim _temp As New DataTable()
        _dt = CType(gdBTDK.DataSource, DataTable)
        _temp = _dt.Copy()
        _temp.DefaultView.RowFilter = "chkChon=True"

        _temp = _temp.DefaultView.ToTable()
        For Each _row In _temp.Rows
            If Convert.ToDateTime(_row("NGAY_BTKT")).Year >= Convert.ToDateTime(Now()).Year Then
                str = "Insert into KeHoachTuanTmp" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,TEN_LOAI_BT,N" & Convert.ToDateTime(_row("NGAY_BTKT")).Day.ToString & ") VALUES(N'" &
                           _row("MS_MAY") & "'," & _row("MS_LOAI_BT") & ",'" & _row("TEN_LOAI_BT") &
                           "',N'X')"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                bChon = True
            End If
        Next
        If bChon Then
            Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptKE_HOACH_BAO_TRI_TRONG_TUAN")

            str = "SELECT DISTINCT MS_MAY,MO_TA_CV,TEN_LOAI_BT,CASE WHEN NGAY_KE=CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103)THEN 'X' ELSE NULL END AS N1," &
                        "CASE WHEN NGAY_KE=DATEADD(DAY,1,CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103))THEN 'X' ELSE NULL END AS N2," &
                        "CASE WHEN NGAY_KE=DATEADD(DAY,2,CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103))THEN 'X' ELSE NULL END AS N3," &
                        "CASE WHEN NGAY_KE=DATEADD(DAY,3,CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103))THEN 'X' ELSE NULL END AS N4," &
                        "CASE WHEN NGAY_KE=DATEADD(DAY,4,CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103))THEN 'X' ELSE NULL END AS N5," &
                        "CASE WHEN NGAY_KE=DATEADD(DAY,5,CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103))THEN 'X' ELSE NULL END AS N6," &
                        "CASE WHEN NGAY_KE=DATEADD(DAY,6,CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103))THEN 'X' ELSE NULL END AS N7 " &
                  "INTO rptKE_HOACH_BAO_TRI_TRONG_TUAN " &
                  "FROM(SELECT MAY_LOAI_BTPN_CHU_KY.MS_MAY, MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN, MAY_LOAI_BTPN_CONG_VIEC.MS_CV, CONG_VIEC.MO_TA_CV, LOAI_BAO_TRI.TEN_LOAI_BT, MAY_LOAI_BTPN_CHU_KY.MS_LOAI_BT, MAY_LOAI_BTPN.NGAY_CUOI, " &
                              "CASE MS_DV_TG WHEN 1 THEN DATEADD(DAY, CHU_KY, NGAY_CUOI) WHEN 2 THEN DATEADD(DAY, 7 * CHU_KY, NGAY_CUOI) WHEN 3 THEN DATEADD(MONTH, CHU_KY, NGAY_CUOI) ELSE DATEADD(YEAR, CHU_KY, NGAY_CUOI) END NGAY_KE " &
                       "FROM MAY INNER JOIN MAY_LOAI_BTPN ON MAY.MS_MAY = MAY_LOAI_BTPN.MS_MAY INNER JOIN MAY_LOAI_BTPN_CHU_KY ON MAY_LOAI_BTPN.MS_MAY = MAY_LOAI_BTPN_CHU_KY.MS_MAY AND " &
                            "MAY_LOAI_BTPN.MS_LOAI_BT = MAY_LOAI_BTPN_CHU_KY.MS_LOAI_BT INNER JOIN MAY_LOAI_BTPN_CONG_VIEC ON MAY_LOAI_BTPN.MS_MAY = MAY_LOAI_BTPN_CONG_VIEC.MS_MAY AND " &
                            "MAY_LOAI_BTPN.MS_LOAI_BT = MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV = CONG_VIEC.MS_CV INNER JOIN " &
                            "LOAI_BAO_TRI ON LOAI_BAO_TRI.MS_LOAI_BT = MAY_LOAI_BTPN.MS_LOAI_BT INNER JOIN KeHoachTuanTmp" & Commons.Modules.UserName & " ON MAY.MS_MAY = KeHoachTuanTmp" & Commons.Modules.UserName & ".MS_MAY AND " &
                            "MAY_LOAI_BTPN.MS_LOAI_BT = KeHoachTuanTmp" & Commons.Modules.UserName & ".MS_LOAI_BT) AS P1 " &
                  "WHERE NGAY_KE>=CONVERT(DATETIME,'" & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "',103) AND NGAY_KE<=CONVERT(DATETIME,'" & Format(dtpDenNgay.Value, "dd/MM/yyyy") & "',103)"

            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End If

        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM rptKE_HOACH_BAO_TRI_TRONG_TUAN")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                Commons.MssBox.Show(Me.Name, "KHONG_CO_DL_IN")
                Cursor = Cursors.Default
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreaterptTieuDeKeHoachThuchienTuan()
        Commons.mdShowReport.ReportPreview("reports/rptKeHoachBaoTriTrongTuan.rpt")
KetThuc:
        Try
        Catch ex As Exception

        End Try

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "KeHoachTuanTmp" & Commons.Modules.UserName)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptKE_HOACH_BAO_TRI_TRONG_TUAN")
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table   rptTieuDeKeHoachBaoTriTrongTuan")

    End Sub
    Private Sub CreaterptTieuDeKeHoachThuchienTuan()
        Dim str As String = String.Empty, str1, str2 As String
        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "Drop table rptTieuDeKeHoachBaoTriTrongTuan")
        Catch ex As Exception
        End Try
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TrangIn", Commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "TieuDe", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "STT", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "ThietBi", Commons.Modules.TypeLanguage)
        Dim CongViec As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "CongViec", Commons.Modules.TypeLanguage)
        Dim DinhKy As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "DinhKy", Commons.Modules.TypeLanguage)
        Dim NgayTrongTuan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NgayTrongTuan", Commons.Modules.TypeLanguage)
        Dim NguoiThuchien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKeHoachBaoTriTrongTuan", "NguoiThucHien", Commons.Modules.TypeLanguage)
        Dim DieuKienLoc As String = lblTuNgay.Text & " " & Format(dtpTuNgay.Value, "dd/MM/yyyy") & "   " & lblDenNgay.Text & " " & Format(dtpDenNgay.Value, "dd/MM/yyyy")
        str = "Create table rptTieuDeKeHoachBaoTriTrongTuan(TypeLanguage int,NgayIn nvarchar(30),TrangIn nvarchar(30),TieuDe nvarchar(255)," &
        " DieuKienLoc nvarchar(255),STT nvarchar(5),ThietBi nvarchar(30),CongViec nvarchar(50),DinhKy nvarchar(30),NgayTrongTuan nvarchar(60), " &
        " NguoiThucHien nvarchar(50),N1 INT,N2 INT,N3 INT,N4 INT,N5 INT,N6 INT,N7 INT)"

        str1 = " Insert into rptTieuDeKeHoachBaoTriTrongTuan(commons.Modules.TypeLanguage,NgayIn,TrangIn,TieuDe,DieuKienLoc,STT,ThietBi,CongViec,DinhKy,NgayTrongTuan,NguoiThucHien"
        str2 = " values(" & Commons.Modules.TypeLanguage & ",'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & DieuKienLoc & "',N'" &
        STT & "',N'" & ThietBi & "',N'" & CongViec & "',N'" & DinhKy & "',N'" & NgayTrongTuan & "',N'" & NguoiThuchien & "'"
        Dim tmp As Integer = 1

        Dim ngay As New Date
        ngay = dtpTuNgay.Value.Date
        While DateDiff(DateInterval.Day, ngay, dtpDenNgay.Value) >= 0   'ngay.Day <= dtpDenNgay.Value.Day
            str1 = str1 + ",N" + tmp.ToString
            str2 = str2 + "," + ngay.Day.ToString
            ngay = DateAdd(DateInterval.Day, 1, ngay)
            tmp = tmp + 1
        End While
        str1 = str1 + ")"
        str2 = str2 + ")"
        str = str + str1 + str2

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Private Function CreateDataDuTruVT() As Boolean
        Dim strWHERE As String = ""
        Dim dtReader As SqlDataReader

        'xoa dl cac bang tam
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptDU_TRU_VAT_TU")
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName)

        'lay du lieu tu luoi dua vao table
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "CREATE TABLE DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(30),MS_LOAI_BT INT,NGAY_CUOI DATETIME,NGAY_BTKT DATETIME)")
        Dim _dt As New DataTable
        Dim _temp As New DataTable()

        If tabKeHoachTongThe.SelectedTabPageIndex = 3 Then
            _dt = CType(gdBTDK_Gio.DataSource, DataTable)
        Else
            _dt = CType(gdBTDK.DataSource, DataTable)
        End If

        _temp = _dt.Copy()
        If tabKeHoachTongThe.SelectedTabPageIndex = 3 Then
            _temp.DefaultView.RowFilter = "CHON=True"
        Else
            _temp.DefaultView.RowFilter = "chkChon=True"
        End If



        _temp = _temp.DefaultView.ToTable()
        For Each _row In _temp.Rows
            If tabKeHoachTongThe.SelectedTabPageIndex = 3 Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                    "INSERT INTO DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName & " VALUES(N'" & _row("MS_MAY") & "'," &
                    _row("MS_LOAI_BT") & ",'" & Format(_row("NGAY_CUOI"), "MM/dd/yyyy") & "','" & Format(_row("NGAY_CUOI"), "MM/dd/yyyy") & "')")
            Else

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text,
                    "INSERT INTO DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName & " VALUES(N'" & _row("MS_MAY") & "'," &
                    _row("MS_LOAI_BT") & ",'" & Format(_row("NGAY_CUOI"), "MM/dd/yyyy") & "','" & Format(_row("NGAY_BTKT"), "MM/dd/yyyy") & "')")
            End If
        Next


        'lay tat ca cac phu tung tuong ung voi ms duoc chon ben khtt
        Commons.Modules.SQLString = "SELECT DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName & ".*, MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT,IC_PHU_TUNG.TEN_PT,IC_PHU_TUNG.QUY_CACH " &
                 "INTO DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName & " " &
                 "FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG INNER JOIN DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName & " ON " &
                      "MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY = DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName & ".MS_MAY AND " &
                      "MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT = DU_TRU_VAT_TU_TMP0" & Commons.Modules.UserName & ".MS_LOAI_BT " &
                      " INNER JOIN IC_PHU_TUNG ON MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT = IC_PHU_TUNG.MS_PT "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)



        Commons.Modules.SQLString = "SELECT * INTO DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & " FROM V_DON_GIA_VTPT_SAU_CUNG"

        Commons.Modules.SQLString = " SELECT T4.MS_PT, DON_GIA, NGOAI_TE, TY_GIA,TY_GIA_USD,T1.NGAY " &
                    " INTO DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName &
                    " FROM dbo.IC_DON_HANG_NHAP AS T1 INNER JOIN dbo.IC_DON_HANG_NHAP_VAT_TU AS T2  " &
                    " ON T1.MS_DH_NHAP_PT = T2.MS_DH_NHAP_PT INNER JOIN " &
                    " (SELECT    MS_PT, MAX(A.NGAY) AS NGAY " &
                    " FROM         dbo.IC_DON_HANG_NHAP AS A INNER JOIN " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU AS B ON A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT INNER JOIN " &
                    " dbo.NHOM_KHO ON A.MS_KHO = dbo.NHOM_KHO.MS_KHO INNER JOIN " &
                    " dbo.USERS ON dbo.NHOM_KHO.GROUP_ID = dbo.USERS.GROUP_ID  " &
                    " WHERE     (dbo.USERS.USERNAME = N'" & Commons.Modules.UserName & "') AND (A.NGAY <= GETDATE()) GROUP BY MS_PT " &
                    " ) T3 ON T1.NGAY = T3.NGAY AND T2.MS_PT = T3.MS_PT RIGHT OUTER JOIN dbo.IC_PHU_TUNG AS T4 ON T2.MS_PT = T4.MS_PT "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        'gop bang tmp 1 và 2 lại với bảng MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG
        Commons.Modules.SQLString = "SELECT MS_MAY, MS_LOAI_BT, TMP.MS_PT, TEN_PT , QUY_CACH, SUM(SO_LUONG) AS SO_LUONG, SUM(DON_GIA) AS DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD " &
                 "INTO DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & " " &
                 "FROM (SELECT MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY, MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT, MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT, TEN_PT , QUY_CACH, SUM(MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.SO_LUONG) AS SO_LUONG, " &
                              "DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".DON_GIA ,DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".NGOAI_TE,DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".TY_GIA,DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".TY_GIA_USD " &
                       "FROM DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName & " INNER JOIN MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG ON DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName & ".MS_MAY = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY AND " &
                            "DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName & ".MS_LOAI_BT = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT AND " &
                            "DU_TRU_VAT_TU_TMP1" & Commons.Modules.UserName & ".MS_PT = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT LEFT OUTER JOIN DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & " ON " &
                            "MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT = DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".MS_PT " &
                       "GROUP BY MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY, MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT, MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT, TEN_PT, QUY_CACH, MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.SO_LUONG, " &
                                "DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".DON_GIA, TEN_PT,QUY_CACH,DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".NGOAI_TE,DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".TY_GIA,DU_TRU_VAT_TU_TMP2" & Commons.Modules.UserName & ".TY_GIA_USD) TMP " &
                 "GROUP BY MS_MAY, MS_LOAI_BT, TMP.MS_PT,TEN_PT, QUY_CACH,NGOAI_TE,TY_GIA,TY_GIA_USD"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Commons.Modules.SQLString = "SELECT NHA_XUONG.MS_N_XUONG, NHA_XUONG.Ten_N_XUONG, LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY, DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_MAY, DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_LOAI_BT, " &
                        "LOAI_BAO_TRI.TEN_LOAI_BT, DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_PT, TEN_PT, QUY_CACH, DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".SO_LUONG, DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".DON_GIA, " &
                        "ISNULL(DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".SO_LUONG,0) * ISNULL(DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".DON_GIA,0)*TY_GIA AS THANH_TIEN, " &
                        "ISNULL(DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".SO_LUONG,0) * ISNULL(DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".DON_GIA,0)*TY_GIA_USD AS THANH_TIEN_USD, " &
                        "HE_THONG.MS_HE_THONG, HE_THONG.TEN_HE_THONG, 0 AS SL_TON " &
                 "INTO DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName & " " &
                 "FROM MAY_NHA_XUONG INNER JOIN NHA_XUONG ON MAY_NHA_XUONG.MS_N_XUONG = NHA_XUONG.MS_N_XUONG INNER JOIN DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & " INNER JOIN " &
                      "NHOM_MAY INNER JOIN LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN MAY ON NHOM_MAY.MS_NHOM_MAY = MAY.MS_NHOM_MAY ON " &
                      "DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_MAY = MAY.MS_MAY ON MAY_NHA_XUONG.MS_MAY = DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_MAY INNER JOIN LOAI_BAO_TRI ON DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_LOAI_BT = LOAI_BAO_TRI.MS_LOAI_BT INNER JOIN " &
                      "MAY_HE_THONG ON DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_MAY = MAY_HE_THONG.MS_MAY INNER JOIN HE_THONG ON MAY_HE_THONG.MS_HE_THONG = HE_THONG.MS_HE_THONG "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) AS TONG FROM DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName)
        While dtReader.Read
            If dtReader.Item("TONG") = 0 Then
                Commons.MssBox.Show(Me.Name, "KHONG_DL_IN")
                dtReader.Close()
                Return True     'khong co dl de in
            End If
        End While
        dtReader.Close()

        'tinh sl ton cua tung vat tu
        Dim NgayKiemKe As Date = "1/1/1900"

        'LẤY NGÀY KIỂM KÊ CỦA KHO ĐƯỢC CHỌN
        'dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ISNULL(MAX(NGAY),'1/1/1900') AS NGAY FROM KIEM_KE")
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT ISNULL(MAX(NGAY),'1/1/1900') AS NGAY FROM KIEM_KE A INNER JOIN NHOM_KHO B ON A.MS_KHO = B.MS_KHO " &
                " INNER JOIN USERS C ON B.GROUP_ID = C.GROUP_ID WHERE USERNAME = '" + Commons.Modules.UserName + "' ")
        While dtReader.Read
            NgayKiemKe = dtReader.Item(0)
        End While
        dtReader.Close()

        Commons.Modules.SQLString = "SELECT tmp.MS_N_XUONG,tmp.TEN_N_XUONG,tmp.MS_LOAI_MAY,tmp.TEN_LOAI_MAY,tmp.MS_MAY,tmp.MS_LOAI_BT,tmp.TEN_LOAI_BT,TMP.MS_PT,TMP.TEN_PT, don_vi_tinh.ten_1, tmp.QUY_CACH,SUM(SO_LUONG) AS SO_LUONG,SUM(DON_GIA) AS DON_GIA,SUM(THANH_TIEN) AS THANH_TIEN,SUM(THANH_TIEN_USD) AS THANH_TIEN_USD ,tmp.MS_HE_THONG,tmp.TEN_HE_THONG,SUM(SL_TON) AS SL_TON,SUM(SL_KIEM_KE) AS SL_KIEM_KE,SUM(NHAP) AS NHAP,SUM(XUAT) AS XUAT " &
                 "INTO rptDU_TRU_VAT_TU " &
                 "FROM(SELECT DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName & ".*,0 SL_KIEM_KE,0 AS NHAP,0 AS XUAT " &
                      "FROM  KIEM_KE_VAT_TU_CHI_TIET RIGHT JOIN " &
                            "DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName & " ON KIEM_KE_VAT_TU_CHI_TIET.MS_PT = DU_TRU_VAT_TU_TMP" & Commons.Modules.UserName & ".MS_PT " &
                      ") as TMP inner join ic_phu_tung on  tmp.ms_pt = ic_phu_tung.ms_pt inner join don_vi_tinh On ic_phu_tung.dvt = don_vi_tinh.dvt " &
                      "GROUP BY MS_N_XUONG,TEN_N_XUONG,MS_LOAI_MAY,TEN_LOAI_MAY,MS_MAY,don_vi_tinh.ten_1,MS_LOAI_BT,TEN_LOAI_BT,TMP.MS_PT,TMP.TEN_PT,TMP.QUY_CACH,MS_HE_THONG,TEN_HE_THONG"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        'LẤY SL KIỂM KÊ ĐƯA VÀO BẢNG TẠM
        Commons.Modules.SQLString = "Select KIEM_KE_VAT_TU_CHI_TIET.MS_PT, SUM(KIEM_KE_VAT_TU_CHI_TIET.SL_KK_CT) As SL_KK_CT " &
                 " FROM KIEM_KE_VAT_TU_CHI_TIET INNER JOIN DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName &
                 " On KIEM_KE_VAT_TU_CHI_TIET.MS_PT = DU_TRU_VAT_TU_TMP3" & Commons.Modules.UserName & ".MS_PT " &
                 " INNER JOIN NHOM_KHO A On KIEM_KE_VAT_TU_CHI_TIET.MS_KHO = A.MS_KHO " &
                 " INNER JOIN USERS C On A.GROUP_ID = C.GROUP_ID " &
                 " WHERE (KIEM_KE_VAT_TU_CHI_TIET.SL_KK_CT > 0) And ( USERNAME = '" + Commons.Modules.UserName + "' ) " &
                 " GROUP BY KIEM_KE_VAT_TU_CHI_TIET.MS_PT"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDU_TRU_VAT_TU SET SL_KIEM_KE=" & dtReader.Item("SL_KK_CT") & " WHERE MS_PT='" & dtReader.Item("MS_PT") & "'")
        End While
        dtReader.Close()

        'LẤY SL NHẬP TỪ NGÀY KIỂM KÊ -> NGAY HIEN TAI (NHAP)
        Commons.Modules.SQLString = "SELECT DISTINCT IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT, IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT, IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI, IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.SL_VT " &
                 "FROM IC_DON_HANG_NHAP INNER JOIN IC_DON_HANG_NHAP_VAT_TU ON IC_DON_HANG_NHAP.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT INNER JOIN IC_DON_HANG_NHAP_VAT_TU_CHI_TIET ON " &
                      "IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND IC_DON_HANG_NHAP_VAT_TU.MS_PT = IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT INNER JOIN " &
                      "rptDU_TRU_VAT_TU ON IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = rptDU_TRU_VAT_TU.MS_PT " &
                    " INNER JOIN NHOM_KHO A ON IC_DON_HANG_NHAP.MS_KHO = A.MS_KHO " &
                    " INNER JOIN USERS C ON A.GROUP_ID = C.GROUP_ID " &
                 " WHERE (IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.SL_VT > 0) AND ( USERNAME = '" + Commons.Modules.UserName + "' ) " &
                    " AND (IC_DON_HANG_NHAP.NGAY BETWEEN '" & Format(DateAdd(DateInterval.Day, 1, NgayKiemKe), "MM/dd/yyyy") & "' AND '" & Format(Now.Date, "MM/dd/yyyy") & "') AND SL_VT>0"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDU_TRU_VAT_TU SET NHAP=NHAP+" & dtReader.Item("SL_VT") & " WHERE MS_PT='" & dtReader.Item("MS_PT") & "'")
        End While
        dtReader.Close()

        'LẤY SL XUẤT TỪ NGÀY KIỂM KÊ -> NGAY HIEN TAI (XUAT)
        Commons.Modules.SQLString = "SELECT IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_XUAT_PT, IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT,IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI, IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT " &
              "FROM IC_DON_HANG_XUAT INNER JOIN IC_DON_HANG_XUAT_VAT_TU ON IC_DON_HANG_XUAT.MS_DH_XUAT_PT = IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT INNER JOIN IC_DON_HANG_XUAT_VAT_TU_CHI_TIET ON " &
                   "IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_XUAT_PT AND IC_DON_HANG_XUAT_VAT_TU.MS_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT INNER JOIN " &
                   "rptDU_TRU_VAT_TU ON IC_DON_HANG_XUAT_VAT_TU.MS_PT = rptDU_TRU_VAT_TU.MS_PT " &
                    " INNER JOIN NHOM_KHO A ON IC_DON_HANG_XUAT.MS_KHO = A.MS_KHO " &
                    " INNER JOIN USERS C ON A.GROUP_ID = C.GROUP_ID " &
              "WHERE   ( USERNAME = '" + Commons.Modules.UserName + "' )  AND (IC_DON_HANG_XUAT.NGAY BETWEEN '" & Format(DateAdd(DateInterval.Day, 1, NgayKiemKe), "MM/dd/yyyy") & "' AND '" & Format(Now.Date, "MM/dd/yyyy") & "') AND SL_VT>0"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        While dtReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDU_TRU_VAT_TU SET XUAT=XUAT+" & dtReader.Item("SL_VT") & " WHERE MS_PT='" & dtReader.Item("MS_PT") & "'")
        End While
        dtReader.Close()

        'LẤY SL_KIEM_KE + NHAP - XUAT -> TÍNH ĐƯỢC TỒN HIEN TAI
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_PT, SL_KIEM_KE + NHAP - XUAT AS TON_DK FROM rptDU_TRU_VAT_TU WHERE SL_KIEM_KE+NHAP-XUAT>0")
        While dtReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE rptDU_TRU_VAT_TU SET SL_TON=" & dtReader.Item("TON_DK") & " WHERE MS_PT='" & dtReader.Item("MS_PT") & "'")
        End While
        dtReader.Close()

    End Function
    Private Sub CreateTieuDeDuTruVTTheoMay(Optional ByVal bInTheoDayChuyen As Boolean = False)
        Dim str As String = ""
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_DU_TRU_VT_THEO_MAY")
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "TrangIn", Commons.Modules.TypeLanguage)
        Dim Tieude As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "Tieude", Commons.Modules.TypeLanguage)
        Dim MasoPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "Maso_PT", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "SoLuong", Commons.Modules.TypeLanguage)
        Dim LoaiBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "LoaiBT", Commons.Modules.TypeLanguage)
        Dim DonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "DonGia", Commons.Modules.TypeLanguage)
        Dim ThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "ThanhTien", Commons.Modules.TypeLanguage)
        Dim SLTon As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "SLTon", Commons.Modules.TypeLanguage)
        Dim KhuVuc As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "KhuVuc", Commons.Modules.TypeLanguage)
        Dim LoaiMay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "LoaiMay", Commons.Modules.TypeLanguage)
        Dim MSThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "MSThietBi", Commons.Modules.TypeLanguage)
        Dim TenThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "TenThietBi", Commons.Modules.TypeLanguage)
        Dim TenHeThong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "TenHeThong", Commons.Modules.TypeLanguage)
        Dim TongCong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "TongCong", Commons.Modules.TypeLanguage)
        Dim NguoiLap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "NguoiLap", Commons.Modules.TypeLanguage)
        Dim DonViTinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_MAY", "DonViTinh", Commons.Modules.TypeLanguage)
        Dim TenNguoiLap As String = cboNguoiLap.Text
        Dim DKLoc As String = lblTuNgay.Text & " " & dtpTuNgay.Value & "   " & lblDenNgay.Text & " " & dtpDenNgay.Value

        If bInTheoDayChuyen = True Then Tieude = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_DU_TRU_VT_THEO_DAY_CHUYEN", "Tieude", Commons.Modules.TypeLanguage)

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_DU_TRU_VT_THEO_MAY")
        str = "CREATE TABLE [DBO].rptTIEU_DE_DU_TRU_VT_THEO_MAY(TypeLanguage int,Trangin nvarchar(20),NgayIn nvarchar(20),TieuDe nvarchar(255),MasoPT nvarchar(30)," &
              "SoLuong nvarchar(30),LoaiBT nvarchar(30),DonGia nvarchar(30),ThanhTien nvarchar(30),SLTon nvarchar(30),KhuVuc nvarchar(20),LoaiMay nvarchar(30),MSThietBi nvarchar(30)," &
              "TenThietBi nvarchar(30),TenHeThong nvarchar(30),TongCong nvarchar(30),NguoiLap nvarchar(30),TenNguoiLap nvarchar(100),DonViTinh nvarchar(50),DKLoc nvarchar(255)) " &
              "INSERT INTO [DBO].rptTIEU_DE_DU_TRU_VT_THEO_MAY(commons.Modules.TypeLanguage,TrangIn,NgayIn,TieuDe,MasoPT,SoLuong,LoaiBT,DonGia,ThanhTien,SLTon,KhuVuc,LoaiMay,MSThietBi,TenThietBi,TenHeThong,TongCong,NguoiLap,TenNguoiLap,DonViTinh,DKLoc) " &
              "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & TrangIn & "',N'" & NgayIn & "',N'" & Tieude & "',N'" & MasoPT & "',N'" &
              SoLuong & "',N'" & LoaiBT & "',N'" & DonGia & "',N'" & ThanhTien & "',N'" & SLTon & "',N'" & KhuVuc & "',N'" & LoaiMay & "',N'" & MSThietBi & "',N'" & TenThietBi & "',N'" & TenHeThong & "',N'" & TongCong & "',N'" & NguoiLap & "',N'" & TenNguoiLap & "',N'" & DonViTinh & "',N'" & DKLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Private Function CreateDataBTDK1() As Boolean
        Dim bChon As Boolean = False
        Dim str As String = ""
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "KeHoachTmp" & Commons.Modules.UserName)
        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "tblBTDK_TMP")
        str = "Create table KeHoachTmp" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(30),MS_LOAI_BT INT,TEN_LOAI_BT NVARCHAR(150),T1 INT, T2 INT,T3 INT, T4 INT, T5 INT, T6 INT , T7 INT, T8 INT,T9 INT, T10 INT,T11 INT, T12 INT, NAM INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim _dt As New DataTable
        Dim _temp As New DataTable()
        _dt = CType(gdBTDK.DataSource, DataTable)
        _temp = _dt.Copy()
        _temp.DefaultView.RowFilter = "chkChon=True"

        _temp = _temp.DefaultView.ToTable()
        For Each _row In _temp.Rows
            str = "Insert into KeHoachTmp" & Commons.Modules.UserName & "(MS_MAY,MS_LOAI_BT,TEN_LOAI_BT,T" & Convert.ToDateTime(_row("NGAY_BTKT")).Month.ToString & ",NAM) VALUES(N'" &
               _row("MS_MAY") & "'," & _row("MS_LOAI_BT") & ",'" & _row("TEN_LOAI_BT") &
               "',1," & Convert.ToDateTime(_row("NGAY_BTKT")).Year & ")"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            bChon = True
        Next

        If bChon Then
            str = "SELECT A.MS_MAY,B.MS_BO_PHAN,TEN_BO_PHAN,B.MS_CV,MO_TA_CV,A.MS_LOAI_BT,TEN_LOAI_BT,case SUM(ISNULL(T1,0))WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10),SUM(ISNULL(T1,0))) END  AS THANG_1 ,CASE SUM(ISNULL(T2,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T2,0))) END AS THANG_2," &
            " CASE SUM(ISNULL(T3,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T3,0))) END AS THANG_3,CASE SUM(ISNULL(T4,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10),SUM(ISNULL(T4,0))) END AS THANG_4,CASE SUM(ISNULL(T5,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T5,0))) END AS THANG_5," &
            " CASE SUM(ISNULL(T6,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10),SUM(ISNULL(T6,0)))END AS THANG_6,CASE SUM(ISNULL(T7,0))WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T7,0))) END AS THANG_7, " &
            " CASE SUM(ISNULL(T8,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T8,0)))END AS THANG_8,CASE SUM(ISNULL(T9,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T9,0))) END AS THANG_9,CASE SUM(ISNULL(T10,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T10,0))) END AS THANG_10," &
            " CASE SUM(ISNULL(T11,0)) WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T11,0))) END AS THANG_11,CASE SUM(ISNULL(T12,0))WHEN 0 THEN NULL ELSE CONVERT(NVARCHAR(10), SUM(ISNULL(T12,0))) END AS THANG_12,NAM " &
            " INTO tblBTDK_TMP " &
            " FROM KeHoachTmp" & Commons.Modules.UserName & " A INNER JOIN MAY_LOAI_BTPN_CONG_VIEC B " &
            " ON A.MS_MAY=B.MS_MAY AND A.MS_LOAI_BT=B.MS_LOAI_BT " &
            " INNER JOIN CONG_VIEC ON CONG_VIEC.MS_CV=B.MS_CV " &
            " INNER JOIN CAU_TRUC_THIET_BI C ON C.MS_MAY=A.MS_MAY AND C.MS_BO_PHAN=B.MS_BO_PHAN " &
            " GROUP BY A.MS_MAY,B.MS_BO_PHAN,TEN_BO_PHAN,B.MS_CV,MO_TA_CV,A.MS_LOAI_BT,TEN_LOAI_BT,NAM "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            SqlText = "ALTER TABLE tblBTDK_TMP ALTER COLUMN TEN_BO_PHAN nvarchar (500) NULL"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM [DBO].tblBTDK_TMP"))
            dt = GetParentBophan(dt)


            For Each row As DataRow In dt.Rows
                SqlText = "UPDATE [tblBTDK_TMP]   SET [TEN_BO_PHAN] = N'" & row("TEN_BO_PHAN") & "' WHERE  [MS_CV] = " & row("MS_CV") & " AND MS_BO_PHAN = '" & row("MS_BO_PHAN") & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
            Next


            CreateTieuDeBTDK1()
        End If
        Return bChon
    End Function
    Private Function GetParentBophan(ByVal dt As DataTable) As DataTable
        Try
            Dim sMamay As String
            Dim sTenbp As String
            If dt.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    Dim sMabp As String
                    sTenbp = ""
                    sMabp = dt.Rows(i)("MS_BO_PHAN").ToString()
                    sMamay = dt.Rows(i)("MS_MAY").ToString()
                    sTenbp = GetParent(sMabp, sMamay, sTenbp)
                    dt.Rows(i)("TEN_BO_PHAN") = sTenbp
                Next
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetParent(ByVal mabp As String, ByVal msmay As String, ByVal sTenbp As String) As String
        Dim sql, mspbcha As String
        sql = "SELECT TEN_BO_PHAN,MS_BO_PHAN_CHA FROM CAU_TRUC_THIET_BI WHERE MS_BO_PHAN =N'" + mabp + "' AND MS_MAY = N'" + msmay + "'"
        Dim dt As DataTable = New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        If dt.Rows.Count > 0 Then
            If sTenbp = "" Then
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString()
            Else
                sTenbp = dt.Rows(0)("TEN_BO_PHAN").ToString() + " \ " + sTenbp
            End If


            mspbcha = dt.Rows(0)("MS_BO_PHAN_CHA").ToString()
            If mspbcha <> msmay Then
                Return GetParent(mspbcha, msmay, sTenbp)
            Else
                Return sTenbp
            End If
        Else
            Return Nothing
        End If


    End Function

    Private Sub CreateTieuDeBTDK1()
        Dim str As String = ""

        Commons.clsXuLy.DropTable(Commons.IConnections.ConnectionString, "rptTIEU_DE_BTDK")

        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "TrangIn", Commons.Modules.TypeLanguage)
        Dim Tieude As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "Tieude", Commons.Modules.TypeLanguage)
        Dim Nam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "Nam", Commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "ThietBi", Commons.Modules.TypeLanguage)
        Dim TenBoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "TenBoPhan", Commons.Modules.TypeLanguage)
        Dim NoiDung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "NoiDung", Commons.Modules.TypeLanguage)
        Dim LoaiBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "LoaiBT", Commons.Modules.TypeLanguage)
        Dim Thang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "Thang", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTIEU_DE_BTDK", "GhiChu", Commons.Modules.TypeLanguage)
        Dim DKLoc As String = lblTuNgay.Text & " " & dtpTuNgay.Value & "     " & lblDenNgay.Text & " " & dtpDenNgay.Value

        str = "CREATE TABLE rptTIEU_DE_BTDK(TypeLanguage int,Trangin nvarchar(20),NgayIn nvarchar(20),TieuDe nvarchar(255),Nam nvarchar(20)," &
              "ThietBi nvarchar(30),TenBoPhan nvarchar(30),NoiDung nvarchar(30),LoaiBT nvarchar(30),Thang nvarchar(20),GhiChu nvarchar(30), DKLoc nvarchar(255)) " &
              "INSERT INTO rptTIEU_DE_BTDK(commons.Modules.TypeLanguage,TrangIn,Ngayin,TieuDe,Nam, " &
              "ThietBi,TenBoPhan,NoiDung,LoaiBT,Thang,GhiChu,DKLoc)" &
              "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & TrangIn & "',N'" & NgayIn & "',N'" & Tieude & "',N'" & Nam & "',N'" &
              ThietBi & "',N'" & TenBoPhan & "',N'" & NoiDung & "',N'" & LoaiBT & "',N'" & Thang & "',N'" & GhiChu & "',N'" & DKLoc & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Sub PrintpreviewBTDK()
        'Call ReportPreview("reports\rptBaoTriDinhKy.rpt")
        Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
        frmRepot.rptName = "rptBaoTriDinhKy"
        Dim vtbData As New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM tblBTDK_TMP"))
        vtbData.TableName = "tblBTDK_TMP"
        Dim vtbTitle As New DataTable()
        vtbTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTIEU_DE_BTDK"))
        vtbTitle.TableName = "rptTIEU_DE_BTDK"
        frmRepot.AddDataTableSource(vtbData)
        frmRepot.AddDataTableSource(vtbTitle)
        frmRepot.ShowDialog()
        Try
            SqlText = "DROP TABLE KeHoachTmp" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        Try
            SqlText = "DROP TABLE tblBTDK_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
    End Sub

#Region "Bảo trì theo thời gian"
    Sub BindBaoTriTheoThoiGian()
        Dim _table As New DataTable

        Dim sMsMay As String
        If CboMaSoThietBiBTDK.EditValue = " < ALL > " Or CboMaSoThietBiBTDK.EditValue Is Nothing Then
            sMsMay = "-1"
        Else
            sMsMay = CboMaSoThietBiBTDK.EditValue
        End If
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
            "SP_H_GET_BTDK_KHTT_TG", Commons.Modules.UserName, cboDiaDiem_1.EditValue, cboHThong.EditValue,
            cboLoaiThietBiBTDK.EditValue,
            IIf(CboNhomThietBiBTDK.EditValue Is Nothing, "-1", CboNhomThietBiBTDK.EditValue),
            sMsMay, Commons.Modules.UserName))
        _table.Columns("CHON").ReadOnly = False
        'gdBTDK_Gio.DataSource = _table
        Commons.Modules.ObjSystems.MLoadXtraGrid(gdBTDK_Gio, gvBTDK_Gio, _table, True, False, True, True)

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvBTDK_Gio.Columns
            If col.FieldName = "CHON" Then
                col.Width = 100
                col.OptionsColumn.AllowEdit = True
                col.OptionsColumn.ReadOnly = False
            Else
                col.OptionsColumn.ReadOnly = True
                col.OptionsColumn.AllowEdit = False
                'col.Width = 150
            End If
            col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.AppearanceHeader.Options.UseTextOptions = True
            col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
        Next
        gvBTDK_Gio.Columns("MS_LOAI_BT").Visible = False
        gvBTDK_Gio.Columns("RUN_TIME").Visible = False
        gvBTDK_Gio.Columns("RUN_TIME_HT").Visible = False
        gvBTDK_Gio.Columns("MS_NHOM_MAY").Visible = False
    End Sub


    Private Sub BtnLapKHTT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLapKHTT1.Click
        Dim strTenHangMuc As String
        Dim _dt As New DataTable
        Dim _temp As New DataTable()
        _dt = CType(gdBTDK_Gio.DataSource, DataTable)
        _temp = _dt.Copy()
        _temp.DefaultView.RowFilter = "CHON=True"
        _temp = _temp.DefaultView.ToTable()
        If _temp.Rows.Count = 0 Then
            Commons.MssBox.Show(Me.Name, "MsgQuyenKT22")
            Exit Sub
        End If
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        If objConnection.State = ConnectionState.Closed Then
            objConnection.Open()
        End If
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try
            For Each _row In _temp.Rows
                strTenHangMuc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuyenTuBTPN", Commons.Modules.TypeLanguage) & " " & _row("TEN_LOAI_BT")
                Dim HANG_MUC_ID As Integer = CType(SqlHelper.ExecuteScalar(objTrans, "InsertKE_HOACH_TONG_THE", _row("MS_MAY"), Format(DateValue(Now), "MM/dd/yyyy"), _row("MS_LOAI_BT"), strTenHangMuc, "2", Format(DateValue(Now), "MM/dd/yyyy"), Commons.Modules.UserName), Integer)
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, "UPDATE KE_HOACH_TONG_THE SET MS_UU_TIEN = 2 WHERE HANG_MUC_ID = " & HANG_MUC_ID.ToString)
                Try
                    SqlHelper.ExecuteNonQuery(objTrans, "UPDATE_KE_HOACH_TONG_THE_LOG", HANG_MUC_ID, Me.Name, Commons.Modules.UserName, 1)
                Catch ex As Exception
                End Try

                If Commons.Modules.iMacDinhCVPT = 0 Or Commons.Modules.iMacDinhCVPT = 1 Then
                    Commons.Modules.SQLString = "SELECT HANG_MUC_ID FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID NOT IN (SELECT HANG_MUC_ID FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY ='" & _row("MS_MAY") & "') AND MS_MAY=N'" & _row("MS_MAY") & "'"

                    Dim vtb As New DataTable
                    Dim vtbTam As New DataTable

                    vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))

                    For Each vrow As DataRow In vtb.Rows
                        Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN, THOI_GIAN_DU_KIEN ,SNGUOI, YCAU_NS, YCAU_DC) " &
                                " SELECT '" & _row("MS_MAY") & "'," & vrow("HANG_MUC_ID").ToString & ", T1.MS_CV, T1.MS_BO_PHAN, " &
                                " THOI_GIAN_DU_KIEN , SO_NGUOI, YEU_CAU_NS, YEU_CAU_DUNG_CU" &
                                " FROM MAY_LOAI_BTPN_CONG_VIEC T1 INNER JOIN CONG_VIEC T2 ON T1.MS_CV = T2.MS_CV " &
                                " WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")
                        SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)
                        Try
                            Commons.Modules.SQLString = "SELECT '" & _row("MS_MAY") & "' as MS_MAY ," & vrow("HANG_MUC_ID").ToString & " as HANG_MUC_ID , MS_CV,MS_BO_PHAN FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")
                            vtbTam = New DataTable
                            vtbTam.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))
                            For Each vr As DataRow In vtbTam.Rows
                                SqlHelper.ExecuteNonQuery(objTrans, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), Me.Name, Commons.Modules.UserName, 1)
                            Next
                        Catch ex As Exception

                        End Try

                    Next
                End If

                If Commons.Modules.iMacDinhCVPT = 0 Then
                    Commons.Modules.SQLString = "SELECT DISTINCT HANG_MUC_ID,MS_CV,MS_BO_PHAN FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID NOT IN (SELECT HANG_MUC_ID FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY ='" & _row("MS_MAY") & "') AND MS_MAY=N'" & _row("MS_MAY") & "'"
                    Dim vtb As New DataTable
                    Dim vtbTam As New DataTable

                    vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))
                    For Each vrow As DataRow In vtb.Rows
                        Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC_PHU_TUNG(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG) SELECT '" & _row("MS_MAY") & "'," & vrow("HANG_MUC_ID").ToString & "," & vrow("MS_CV").ToString & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & vrow("MS_CV").ToString
                        SqlHelper.ExecuteScalar(objTrans, CommandType.Text, Commons.Modules.SQLString)

                        Try
                            Commons.Modules.SQLString = "SELECT '" & _row("MS_MAY") & "' as MS_MAY ," & vrow("HANG_MUC_ID").ToString & " as HANG_MUC_ID ," & vrow("MS_CV").ToString & " as MS_CV ,MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & vrow("MS_CV").ToString
                            vtbTam = New DataTable
                            vtbTam.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))
                            For Each vr As DataRow In vtbTam.Rows
                                SqlHelper.ExecuteNonQuery(objTrans, "UPDATE_KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 1)
                            Next
                        Catch ex As Exception

                        End Try

                    Next

                End If
            Next
            objTrans.Commit()
            objConnection.Close()


        Catch ex As Exception
            objTrans.Rollback()
            objConnection.Close()
            Commons.MssBox.Show(Me.Name, "msgKhongThanhCong")
            Exit Sub
        End Try
        BindBaoTriTheoThoiGian()
        Commons.MssBox.Show(Me.Name, "MsgQuyenKT23")
    End Sub

    Private Sub BtnLapPBT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLapPBT1.Click
        Dim i As Integer = 0
        Dim strGioTam, MS_PBT As String
        Dim vtbTam As New DataTable
        Try

            strGioTam = TimeValue(Now)
            Dim blnChon As Boolean = False
            If String.IsNullOrEmpty(cboNguoiLap1.EditValue) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                    "msgChuaChonNguoiLap", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboNguoiLap1.Focus()
                Exit Sub
            End If
            Dim _dt As New DataTable
            Dim _temp As New DataTable()
            _dt = CType(gdBTDK_Gio.DataSource, DataTable)
            _temp = _dt.Copy()
            _temp.DefaultView.RowFilter = "CHON=True"
            _temp = _temp.DefaultView.ToTable()
            If _temp.Rows.Count = 0 Then
                Commons.MssBox.Show(Me.Name, "MsgQuyenKT22")
                Exit Sub
            End If
            For Each _row As DataRow In _temp.Rows
                MS_PBT = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI()

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI", MS_PBT, _row("MS_MAY"), _row("MS_LOAI_BT"),
                        DateValue(Now), strGioTam.ToString, _row("TEN_LOAI_BT"), 1, DateValue(Now), Me.cboNguoiLap1.EditValue,
                        Commons.Modules.UserName, DateValue(Now), DateValue(Now), "-1", 3)

                If Commons.Modules.iDefault Then
                    Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI SET SO_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = '" & MS_PBT & "'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                End If
                If Commons.Modules.iMacDinhCVPT = 0 Or Commons.Modules.iMacDinhCVPT = 1 Then
                    'Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH,SO_NGUOI,YEU_CAU_NS,YEU_CAU_DUNG_CU) " &
                    '            " SELECT '" & MS_PBT & "',MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MS_BO_PHAN," &
                    '            " CASE ISNULL(CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH,0) WHEN 0 THEN  ISNULL(CONG_VIEC.THOI_GIAN_DU_KIEN,0) ELSE ISNULL(CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH,0) END AS THOI_GIAN_DU_KIEN, " &
                    '            " SO_NGUOI, YEU_CAU_NS, YEU_CAU_DUNG_CU " &
                    '            " FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV " &
                    '            " INNER JOIN CAU_TRUC_THIET_BI_CONG_VIEC On MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY AND MAY_LOAI_BTPN_CONG_VIEC.MS_CV=CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV " &
                    '            " WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")


                    Commons.Modules.SQLString = " INSERT PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH,SO_NGUOI,YEU_CAU_NS,YEU_CAU_DUNG_CU) " &
                                                " SELECT '" & MS_PBT & "', dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_CV, dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN, CASE ISNULL(CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH, 0)  WHEN 0 THEN ISNULL(CONG_VIEC.THOI_GIAN_DU_KIEN, 0) ELSE ISNULL(CAU_TRUC_THIET_BI_CONG_VIEC.TG_KH, 0) END AS THOI_GIAN_DU_KIEN, dbo.CONG_VIEC.SO_NGUOI, dbo.CONG_VIEC.YEU_CAU_NS, dbo.CONG_VIEC.YEU_CAU_DUNG_CU " &
                                                " FROM dbo.MAY_LOAI_BTPN_CONG_VIEC " &
                                                " INNER JOIN dbo.CONG_VIEC ON dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_CV = dbo.CONG_VIEC.MS_CV" &
                                                " INNER JOIN dbo.CAU_TRUC_THIET_BI_CONG_VIEC ON dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = dbo.CAU_TRUC_THIET_BI_CONG_VIEC.MS_MAY And " &
                                                "           dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_CV = dbo.CAU_TRUC_THIET_BI_CONG_VIEC.MS_CV And " &
                                                "           dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_BO_PHAN = dbo.CAU_TRUC_THIET_BI_CONG_VIEC.MS_BO_PHAN AND dbo.CAU_TRUC_THIET_BI_CONG_VIEC.ACTIVE = 1 " &
                                                " WHERE(dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_MAY = N'" & _row("MS_MAY") & "') AND (dbo.MAY_LOAI_BTPN_CONG_VIEC.MS_LOAI_BT = " & _row("MS_LOAI_BT") & ")"

                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                    Try
                        Commons.Modules.SQLString = "SELECT '" & MS_PBT & "' as MS_PHIEU_BAO_TRI ,MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MS_BO_PHAN,THOI_GIAN_DU_KIEN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")
                        vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
                        For Each vr As DataRow In vtbTam.Rows
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_PHIEU_BAO_TRI_CONG_VIEC_LOG", vr("MS_PHIEU_BAO_TRI"), vr("MS_CV"), vr("MS_BO_PHAN"), Me.Name, Commons.Modules.UserName, 1)
                        Next
                    Catch ex As Exception

                    End Try

                    Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_BDCV = " & DateValue(Now) & " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertCongNhanPBT", MS_PBT)
                    Catch ex As Exception
                    End Try
                    Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_KTCV = " & DateValue(Now) & " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertCongNhanPBT", MS_PBT)
                    Catch ex As Exception
                    End Try
                End If
                If Commons.Modules.iMacDinhCVPT = 0 Then

                    Commons.Modules.SQLString = "SELECT DISTINCT dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_CV " &
                            "FROM         dbo.CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN " &
                        "  dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG ON dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY AND " &
                         " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND " &
                         "  dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT WHERE dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY ='" & _row("MS_MAY") & "'" &
                         "  AND dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT ='" & _row("MS_LOAI_BT") & "'"
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)


                    While dtReader.Read
                        Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH) " &
                                    " SELECT '" & MS_PBT & "'," & dtReader.Item("MS_CV") & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' " &
                                    " AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & dtReader.Item(0)
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                        Try
                            vtbTam = New DataTable
                            Commons.Modules.SQLString = "SELECT '" & MS_PBT & "' as MS_PHIEU_BAO_TRI ," & dtReader.Item("MS_CV") & " as MS_CV ,MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & dtReader.Item(0)
                            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
                            For Each vr As DataRow In vtbTam.Rows
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_LOG", vr("MS_PHIEU_BAO_TRI"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 1)
                            Next
                        Catch ex As Exception

                        End Try

                    End While
                    dtReader.Close()

                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_TAO_PHIEU_BAO_TRI_THEO_GIO", MS_PBT, _row("MS_MAY"), _row("MS_LOAI_BT"))
                    Catch ex As Exception
                    End Try
                End If
                'tu dong insert cong nhan neu cot auto_cn = 1 trong thong tin chung
                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertCongNhanPBT", MS_PBT)
                Catch ex As Exception
                End Try

            Next

            BindBaoTriTheoThoiGian()
            Commons.MssBox.Show(Me.Name, "MsgQuyenKT23")
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                "msgLapPBTLoi", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub BtnThoat5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat5.Click
        Me.Close()
    End Sub
#End Region

    Private Sub chkDuGio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDuGio.CheckedChanged
        If dtpDenNgayBTDK1.Text = "  /  /" Then
            Commons.MssBox.Show(Me.Name, "GIO_NHAP_NULL")
            Me.dtpDenNgayBTDK1.Focus()
        ElseIf Not IsDate(dtpDenNgayBTDK1.Text) Then
            Commons.MssBox.Show(Me.Name, "GIO_NHAP_ERROR")
            Me.dtpDenNgayBTDK1.Focus()
        Else
            Me.Cursor = Cursors.WaitCursor
            LayDuLieu()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If DateDiff(DateInterval.Day, dtpTuNgay.Value, dtpDenNgay.Value) < 0 Then
            Commons.MssBox.Show(Me.Name, "NGAY_KHONG_HOP_LE")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        LayDuLieu()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa.Click
        Dim i As Integer
        While i < gvBTDK.RowCount
            gvBTDK.GetDataRow(i)("chkChon") = True
            i = i + 1
        End While
        lblChon.Text = Chon & ": " & gvBTDK.RowCount.ToString()
    End Sub

    Private Sub BtnBoChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa.Click
        Dim i As Integer
        While i < gvBTDK.RowCount
            gvBTDK.GetDataRow(i)("chkChon") = False
            i = i + 1
        End While
        lblChon.Text = Chon & ": 0"

    End Sub
    Private Sub gvKHTT_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvKHTT.FocusedRowChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If (BtnThem1.Visible = False) Then
            If (IsDBNull(gvKHTT.GetFocusedDataRow()("MS_LOAI_BT"))) And (btnMucUuTienFlag = True) Then
                btnCapNhatMUT.Visible = True
            Else
                btnCapNhatMUT.Visible = False
            End If
        End If
        BindDataCV()
        BindDataVTPT()
    End Sub
    Private Sub gvCVTT_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvCVTT.FocusedRowChanged
        BindDataVTPT()
    End Sub

    Private Sub gvCVTT_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvCVTT.CellValueChanged
        Try
            Dim name As String = e.Column.FieldName
            Dim dr As DataRow
            dr = dtTable_CV_TEMP.NewRow()
            If RadBoQua1.Checked Then
                Select Case name
                    Case "KHONG_GQ", "THUE_NGOAI"
                        dr("MS_CV") = gvCVTT.GetFocusedDataRow()("MS_CV")
                        dr("MS_BO_PHAN") = gvCVTT.GetFocusedDataRow()("MS_BO_PHAN")
                        dr("TEN_BO_PHAN") = gvCVTT.GetFocusedDataRow()("TEN_BO_PHAN")
                        dr("HANG_MUC_ID") = gvCVTT.GetFocusedDataRow()("HANG_MUC_ID")
                        dr("MS_MAY") = gvCVTT.GetFocusedDataRow()("MS_MAY")

                        'BẬT CỜ RECORDEDIT LÊN
                        If gvKHTT.GetFocusedDataRow("RecordAction").ToString().Equals("0") Then
                            gvKHTT.GetFocusedDataRow("RecordAction") = 2
                        End If

                        Dim _datarow() As DataRow = dtTable_CV_TEMP.Select("MS_CV='" & dr("MS_CV") & "' AND MS_BO_PHAN='" & dr("MS_BO_PHAN") & "' AND HANG_MUC_ID='" & dr("HANG_MUC_ID") & "'")
                        If _datarow.Length > 0 Then
                            _datarow(0)("THUE_NGOAI") = gvCVTT.GetFocusedDataRow()("THUE_NGOAI")
                            _datarow(0)("KHONG_GQ") = gvCVTT.GetFocusedDataRow()("KHONG_GQ")
                        Else
                            dr("THUE_NGOAI") = gvCVTT.GetFocusedDataRow()("THUE_NGOAI")
                            dr("KHONG_GQ") = gvCVTT.GetFocusedDataRow()("KHONG_GQ")
                            dtTable_CV_TEMP.Rows.Add(dr)
                        End If
                End Select
            ElseIf radChuaGiaiQuyet1.Checked Then
                Dim sql As String = ""
                Dim _khong_gq As Boolean = False
                Dim _thue_ngoai As Boolean = False
                Dim _ghi_chu_temp As String = ""
                Dim _utien As Integer = 3
                Dim _ms_cv As Integer
                Dim _ms_bp As String
                Dim _TEN_bp As String
                Dim _ms_hang_muc As Integer
                Dim _ms_may As String
                Dim _kgv As Integer = 0
                Dim _tn As Integer = 0
                Dim _THOI_GIAN_DU_KIEN As Double = 0
                Dim _SNguoi As Integer = 0
                Dim _YCNsu As String
                Dim _YCDCu As String

                Select Case name
                    Case "KHONG_GQ", "THUE_NGOAI", "GHI_CHU", "MS_UU_TIEN", "THOI_GIAN_DU_KIEN", "SNGUOI", "YCAU_NS", "YCAU_DC"
                        _khong_gq = gvCVTT.GetFocusedDataRow()("KHONG_GQ")
                        _thue_ngoai = gvCVTT.GetFocusedDataRow()("THUE_NGOAI")
                        _ghi_chu_temp = Convert.ToString(gvCVTT.GetFocusedDataRow()("GHI_CHU"))
                        If String.IsNullOrEmpty(Convert.ToString(gvCVTT.GetFocusedDataRow()("MS_UU_TIEN"))) = False Then
                            _utien = gvCVTT.GetFocusedDataRow()("MS_UU_TIEN")
                        End If

                        Try
                            'BẬT CỜ RECORDEDIT LÊN
                            If gvKHTT.GetFocusedDataRow("RecordAction").ToString().Equals("0") Then
                                gvKHTT.GetFocusedDataRow("RecordAction") = 2
                            End If

                        Catch ex As Exception

                        End Try

                        _ms_cv = gvCVTT.GetFocusedDataRow("MS_CV")
                        _ms_bp = gvCVTT.GetFocusedDataRow("MS_BO_PHAN")
                        _TEN_bp = gvCVTT.GetFocusedDataRow("TEN_BO_PHAN")

                        _ms_hang_muc = gvCVTT.GetFocusedDataRow("HANG_MUC_ID")
                        _ms_may = gvCVTT.GetFocusedDataRow("MS_MAY")
                        If _khong_gq = True Then
                            _kgv = 1
                        End If
                        If _thue_ngoai = True Then
                            _tn = 1
                        End If

                        Try
                            _THOI_GIAN_DU_KIEN = gvCVTT.GetFocusedDataRow("THOI_GIAN_DU_KIEN")
                        Catch ex As Exception
                        End Try

                        Try
                            _SNguoi = gvCVTT.GetFocusedDataRow("SNGUOI")
                        Catch ex As Exception
                        End Try

                        Try
                            _YCNsu = gvCVTT.GetFocusedDataRow("YCAU_NS")
                        Catch ex As Exception
                            _YCNsu = Nothing
                        End Try
                        Try
                            _YCDCu = gvCVTT.GetFocusedDataRow("YCAU_DC")
                        Catch ex As Exception
                            _YCDCu = Nothing
                        End Try


                        sql = "UPDATE KHTCV_TMP" & Commons.Modules.UserName & " SET KHONG_GQ = " & _kgv & ", THUE_NGOAI = " & _tn &
                                    ", MS_UU_TIEN = " & _utien & ", GHI_CHU = N'" & _ghi_chu_temp & "'" &
                                    ", THOI_GIAN_DU_KIEN = " + _THOI_GIAN_DU_KIEN.ToString() + ", SNGUOI = " & _SNguoi & ", YCAU_NS = N'" & _YCNsu & "', YCAU_DC = N'" & _YCDCu & "'   " &
                                    " WHERE MS_MAY ='" & _ms_may & "' AND MS_CV=" & _ms_cv & " AND MS_BO_PHAN ='" & _ms_bp & "' AND HANG_MUC_ID=" & _ms_hang_muc
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                        Dim _datarow() As DataRow = dtTable_CV_TEMP.Select("MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND HANG_MUC_ID='" & _ms_hang_muc & "'")
                        If _datarow.Length > 0 Then
                            _datarow(0)("THUE_NGOAI") = _thue_ngoai
                            _datarow(0)("KHONG_GQ") = _khong_gq
                            _datarow(0)("MS_UU_TIEN") = _utien
                            _datarow(0)("GHI_CHU") = _ghi_chu_temp

                            _datarow(0)("THOI_GIAN_DU_KIEN") = _THOI_GIAN_DU_KIEN
                            _datarow(0)("SNGUOI") = _SNguoi
                            _datarow(0)("YCAU_NS") = _YCNsu
                            _datarow(0)("YCAU_DC") = _YCDCu
                        Else
                            dr("MS_CV") = _ms_cv
                            dr("MS_BO_PHAN") = _ms_bp
                            dr("HANG_MUC_ID") = _ms_hang_muc
                            dr("THUE_NGOAI") = _thue_ngoai
                            dr("KHONG_GQ") = _khong_gq
                            dr("MS_UU_TIEN") = _utien
                            dr("GHI_CHU") = _ghi_chu_temp
                            dr("MS_MAY") = _ms_may
                            dr("TEN_BO_PHAN") = _TEN_bp

                            dr("THOI_GIAN_DU_KIEN") = _THOI_GIAN_DU_KIEN
                            dr("SNGUOI") = _SNguoi
                            dr("YCAU_NS") = _YCNsu
                            dr("YCAU_DC") = _YCDCu
                            dtTable_CV_TEMP.Rows.Add(dr)
                        End If
                End Select

            End If
        Catch ex As Exception

        End Try

    End Sub
    'Dim flag As Boolean = False
    Private Sub gvKHTT_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvKHTT.CellValueChanged

        Try
            If blnThemSua = True Then
                Dim str As String = e.Column.FieldName
                Dim _ms_hang_muc As Integer = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                Dim _datarow() As DataRow = dtTable_KHTT_TEMP.Select("HANG_MUC_ID='" & _ms_hang_muc & "'")
                Dim dr As DataRow
                dr = dtTable_KHTT_TEMP.NewRow()
                dr("MS_MAY") = gvKHTT.GetFocusedDataRow()("MS_MAY")
                dr("HANG_MUC_ID") = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                dr("TEN_HANG_MUC") = gvKHTT.GetFocusedDataRow()("TEN_HANG_MUC")
                dr("NGAY") = gvKHTT.GetFocusedDataRow()("NGAY")
                dr("NGAY_DK_HT") = gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")
                dr("GHI_CHU") = gvKHTT.GetFocusedDataRow()("GHI_CHU")
                dr("LY_DO_SC") = gvKHTT.GetFocusedDataRow()("LY_DO_SC")
                If gvKHTT.GetFocusedDataRow()("RecordAction").ToString().Equals("0") Then
                    gvKHTT.GetFocusedDataRow()("RecordAction") = 2
                End If


                dr("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
                dr("MS_CONG_NHAN") = gvKHTT.GetFocusedDataRow()("MS_CONG_NHAN")
                dr("RecordAction") = gvKHTT.GetFocusedDataRow()("RecordAction")

                If _datarow.Length > 0 Then
                    Select Case str
                        Case "MS_MAY"
                            _datarow(0)("MS_MAY") = gvKHTT.GetFocusedDataRow()("MS_MAY")
                        Case "TEN_HANG_MUC"
                            _datarow(0)("TEN_HANG_MUC") = gvKHTT.GetFocusedDataRow()("TEN_HANG_MUC")
                        Case "NGAY"

                            _datarow(0)("NGAY") = gvKHTT.GetFocusedDataRow()("NGAY")
                        Case "NGAY_DK_HT"
                            _datarow(0)("NGAY_DK_HT") = gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")
                        Case "GHI_CHU"
                            _datarow(0)("GHI_CHU") = gvKHTT.GetFocusedDataRow()("GHI_CHU")
                        Case "LY_DO_SC"
                            _datarow(0)("LY_DO_SC") = gvKHTT.GetFocusedDataRow()("LY_DO_SC")
                        Case "MS_UU_TIEN"
                            _datarow(0)("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
                        Case "MS_CONG_NHAN"
                            _datarow(0)("MS_CONG_NHAN") = gvKHTT.GetFocusedDataRow()("MS_CONG_NHAN")
                    End Select
                Else
                    dtTable_KHTT_TEMP.Rows.Add(dr)
                End If
            End If
            'If blnThemSua = True Then
            '    If (flag = False) Then
            '        Dim str As String = e.Column.FieldName
            '        Dim _ms_hang_muc As Integer = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
            '        Dim _datarow() As DataRow = dtTable_KHTT_TEMP.Select("HANG_MUC_ID='" & _ms_hang_muc & "'")
            '        Dim dtKHTT As DataTable = CType(gdKHTT.DataSource, DataTable)
            '        Dim drKHTT() As DataRow = dtKHTT.Select("HANG_MUC_ID='" & _ms_hang_muc & "'")
            '        Dim dr As DataRow
            '        dr = dtTable_KHTT_TEMP.NewRow()
            '        dr("MS_MAY") = gvKHTT.GetFocusedDataRow()("MS_MAY")
            '        dr("HANG_MUC_ID") = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
            '        dr("TEN_HANG_MUC") = gvKHTT.GetFocusedDataRow()("TEN_HANG_MUC")
            '        Dim str1 As String = "SELECT ISNULL(SO_NGAY_PHAI_BD, 0) AS SO_NGAY_PHAI_BD ,  ISNULL(SO_NGAY_PHAI_KT, 0) AS SO_NGAY_PHAI_KT FROM MUC_UU_TIEN WHERE MS_UU_TIEN = " & gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
            '        Dim dt As New DataTable()
            '        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str1))
            '        If (str = "MS_UU_TIEN") Then
            '            dr("MS_UU_TIEN") = e.Value
            '            dr("NGAY") = Convert.ToDateTime(drKHTT(0)("NGAY_OLD")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
            '            dr("NGAY_DK_HT") = Convert.ToDateTime(drKHTT(0)("NGAY_KT_OLD")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
            '            dr("NGAY_OLD") = drKHTT(0)("NGAY_OLD")
            '            dr("NGAY_KT_OLD") = drKHTT(0)("NGAY_KT_OLD")
            '            flag = True
            '            drKHTT(0)("NGAY") = dr("NGAY")
            '            drKHTT(0)("NGAY_DK_HT") = dr("NGAY_DK_HT")
            '            drKHTT(0)("MS_UU_TIEN") = dr("MS_UU_TIEN")
            '            flag = False
            '        Else
            '            dr("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
            '            dr("NGAY") = gvKHTT.GetFocusedDataRow()("NGAY")
            '            dr("NGAY_DK_HT") = gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")
            '            dr("NGAY_OLD") = gvKHTT.GetFocusedDataRow()("NGAY")
            '            dr("NGAY_KT_OLD") = gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")
            '            flag = True
            '            drKHTT(0)("NGAY_OLD") = dr("NGAY")
            '            drKHTT(0)("NGAY_KT_OLD") = dr("NGAY_DK_HT")
            '            flag = False
            '        End If
            '        dr("GHI_CHU") = gvKHTT.GetFocusedDataRow()("GHI_CHU")
            '        dr("LY_DO_SC") = gvKHTT.GetFocusedDataRow()("LY_DO_SC")
            '        If gvKHTT.GetFocusedDataRow()("RecordAction").ToString().Equals("0") Then
            '            gvKHTT.GetFocusedDataRow()("RecordAction") = 2
            '        End If
            '        dr("MS_CONG_NHAN") = gvKHTT.GetFocusedDataRow()("MS_CONG_NHAN")
            '        dr("RecordAction") = gvKHTT.GetFocusedDataRow()("RecordAction")
            '        If _datarow.Length > 0 Then
            '            Select Case str
            '                Case "MS_MAY"
            '                    _datarow(0)("MS_MAY") = gvKHTT.GetFocusedDataRow()("MS_MAY")
            '                Case "TEN_HANG_MUC"
            '                    _datarow(0)("TEN_HANG_MUC") = gvKHTT.GetFocusedDataRow()("TEN_HANG_MUC")
            '                Case "NGAY"
            '                    If (e.Column.FieldName = "MS_UU_TIEN") Then
            '                        _datarow(0)("NGAY") = Convert.ToDateTime(drKHTT(0)("NGAY_OLD")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
            '                    Else
            '                        _datarow(0)("NGAY_OLD") = gvKHTT.GetFocusedDataRow()("NGAY")
            '                        _datarow(0)("NGAY") = gvKHTT.GetFocusedDataRow()("NGAY")
            '                    End If
            '                Case "NGAY_DK_HT"
            '                    If (e.Column.FieldName = "MS_UU_TIEN") Then
            '                        _datarow(0)("NGAY_DK_HT") = Convert.ToDateTime(drKHTT(0)("NGAY_KT_OLD")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
            '                    Else
            '                        _datarow(0)("NGAY_KT_OLD") = gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")
            '                        _datarow(0)("NGAY_DK_HT") = gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")
            '                    End If
            '                Case "GHI_CHU"
            '                    _datarow(0)("GHI_CHU") = gvKHTT.GetFocusedDataRow()("GHI_CHU")
            '                Case "LY_DO_SC"
            '                    _datarow(0)("LY_DO_SC") = gvKHTT.GetFocusedDataRow()("LY_DO_SC")
            '                Case "MS_UU_TIEN"
            '                    _datarow(0)("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
            '                    _datarow(0)("NGAY") = gvKHTT.GetFocusedDataRow()("NGAY")
            '                    _datarow(0)("NGAY_DK_HT") = gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")
            '                Case "MS_CONG_NHAN"
            '                    _datarow(0)("MS_CONG_NHAN") = gvKHTT.GetFocusedDataRow()("MS_CONG_NHAN")
            '            End Select
            '        Else
            '            dtTable_KHTT_TEMP.Rows.Add(dr)
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            'flag = False
        End Try
    End Sub

    Private Sub btnChonMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonMay.Click
        Try

            FrmChonMayChoKHTT.loai_may = cboLoaiThietBiBTDK.EditValue
            FrmChonMayChoKHTT.nhom_may = CboNhomThietBiBTDK.EditValue
            Dim _table_chon_may As New DataTable
            Dim _table_KHTT As New DataTable
            If FrmChonMayChoKHTT.ShowDialog() = Windows.Forms.DialogResult.OK Then
                _table_chon_may = FrmChonMayChoKHTT.dtMay
                _table_KHTT = CType(gvKHTT.DataSource, DataView).ToTable()
                For Each col As DataColumn In _table_KHTT.Columns
                    col.AllowDBNull = True
                Next
                Dim dr As DataRow
                Dim dr1 As DataRow
                For Each _row In _table_chon_may.Rows
                    dr = _table_KHTT.NewRow()
                    dr1 = dtTable_KHTT_TEMP.NewRow()
                    j = j + 1
                    dr("MS_MAY") = _row("MS_MAY")
                    dr("TEN_MAY") = _row("TEN_MAY")
                    dr("MS_CONG_NHAN") = Commons.Modules.sMaNhanVienMD
                    dr("HANG_MUC_ID") = j

                    Dim str As String = "SELECT ISNULL(SO_NGAY_PHAI_BD, 0) AS SO_NGAY_PHAI_BD ,  ISNULL(SO_NGAY_PHAI_KT, 0) AS SO_NGAY_PHAI_KT FROM MUC_UU_TIEN WHERE MS_UU_TIEN = " & _row("MUC_UU_TIEN")
                    Dim dt As New DataTable()
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

                    dr("NGAY_OLD") = Date.Now
                    dr("NGAY_KT_OLD") = Date.Now

                    dr("NGAY") = Date.Now.AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
                    dr("NGAY_DK_HT") = Date.Now.AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
                    dr("LY_DO_SC") = -1
                    dr("RecordAction") = 1
                    dr("MS_UU_TIEN") = _row("MUC_UU_TIEN")
                    _table_KHTT.Rows.InsertAt(dr, 0)

                    dr1("MS_MAY") = _row("MS_MAY")
                    dr1("TEN_MAY") = _row("TEN_MAY")
                    dr1("HANG_MUC_ID") = j
                    dr1("NGAY") = dr("NGAY")
                    dr1("NGAY_DK_HT") = dr("NGAY_DK_HT")
                    dr1("LY_DO_SC") = -1
                    dr1("RecordAction") = 1
                    dr1("MS_UU_TIEN") = _row("MUC_UU_TIEN")
                    dtTable_KHTT_TEMP.Rows.Add(dr1)
                Next
                gdKHTT.DataSource = _table_KHTT
                count = gvKHTT.RowCount

                BindDataCV()
                BindDataVTPT()
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub gvVTTT_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvVTTT.CellValueChanged
        Dim name As String = e.Column.FieldName
        Dim _hang_muc_id As Integer = gvVTTT.GetFocusedDataRow()("HANG_MUC_ID")
        Dim _ms_cv As Integer = gvVTTT.GetFocusedDataRow()("MS_CV")
        Dim _ms_bp As String = gvVTTT.GetFocusedDataRow()("MS_BO_PHAN")
        Dim _ms_pt As String = gvVTTT.GetFocusedDataRow()("MS_PT")
        Dim sql As String

        Select Case name
            Case "SO_LUONG"
                sql = "UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=" & gvVTTT.GetFocusedDataRow()("SO_LUONG")
                sql += " WHERE HANG_MUC_ID='" & _hang_muc_id & "' AND MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND MS_PT='" & _ms_pt & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            Case "GHI_CHU"
                sql = "UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET GHI_CHU=" & gvVTTT.GetFocusedDataRow()("GHI_CHU")
                sql += " WHERE HANG_MUC_ID='" & _hang_muc_id & "' AND MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND MS_PT='" & _ms_pt & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            Case "DON_GIA_KH"
                sql = "UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET DON_GIA_KH = " & gvVTTT.GetFocusedDataRow()("DON_GIA_KH")
                sql += " WHERE HANG_MUC_ID='" & _hang_muc_id & "' AND MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND MS_PT='" & _ms_pt & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            Case "TIEN_TE_KH"
                sql = "UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET TIEN_TE_KH=" & gvVTTT.GetFocusedDataRow()("TIEN_TE_KH")
                sql += " WHERE HANG_MUC_ID='" & _hang_muc_id & "' AND MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND MS_PT='" & _ms_pt & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            Case "TY_GIA_KH"
                sql = "UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET TY_GIA_KH=" & gvVTTT.GetFocusedDataRow()("TY_GIA_KH")
                sql += " WHERE HANG_MUC_ID='" & _hang_muc_id & "' AND MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND MS_PT='" & _ms_pt & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
            Case "TY_GIA_USD_KH"
                sql = "UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET TY_GIA_USD_KH=" & gvVTTT.GetFocusedDataRow()("TY_GIA_USD_KH")
                sql += " WHERE HANG_MUC_ID='" & _hang_muc_id & "' AND MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND MS_PT='" & _ms_pt & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        End Select

        'BẬT CỜ RECORDEDIT LÊN

        If gvKHTT.GetFocusedDataRow("RecordAction").ToString().Equals("0") Then
            gvKHTT.GetFocusedDataRow("RecordAction") = 2
        End If

    End Sub
    Private Sub BindData_Tab()
        Me.Cursor = Cursors.WaitCursor
        Dim sName As String = tabKeHoachTongThe.SelectedTabPage.Name
        Select Case sName.ToUpper
            Case "tabKeHoachTT".ToUpper
                LoadData()
            Case "tabGSTT".ToUpper
                If radDaGiaiQuyet3.Checked = True Then
                    dtpTNYCSD.Enabled = True
                    dtpDNYCSD.Enabled = True
                Else
                    dtpTNYCSD.Enabled = False
                    dtpDNYCSD.Enabled = False
                End If
                LoadDataTSGSTT()
            Case "TabYeucaunguoisudung".ToUpper
                LoadDataYCNSD()
            Case "TabBaotridinhky".ToUpper
                btnThucHien_Click(Nothing, Nothing)
            Case "TabBaoTriTheoGio".ToUpper
                BindBaoTriTheoThoiGian()
            Case "TabMonitoring".ToUpper
                ucMonitor.SetValueForFilter(cboDiaDiem_1.EditValue, cboHThong.EditValue, cboLoaiThietBiBTDK.EditValue, CboMaSoThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue)
                ucMonitor.LoadMonitoringByPlan()
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub gdKHTT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gdKHTT.KeyDown
        If blnThemSua = False Then
            If e.KeyCode = Keys.Delete Then
                If gvKHTT.RowCount <= 0 Then
                    Commons.MssBox.Show(Me.Name, "MsgQuyenKT14")
                    Exit Sub
                End If

                Commons.Modules.SQLString = "SELECT TOP 1 MS_PHIEU_BAO_TRI FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND (MS_PHIEU_BAO_TRI IS NOT NULL OR EOR_ID IS NOT NULL)"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                    "MsgQuyenKT36", Commons.Modules.TypeLanguage) + " - " + dtReader.Item("MS_PHIEU_BAO_TRI"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dtReader.Close()
                    Exit Sub
                End While
                dtReader.Close()
                Dim tran As SqlTransaction
                Dim con As New SqlConnection(Commons.IConnections.ConnectionString)

                If gvCVTT.RowCount > 0 Then
                    If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKHDangTonTaiCongViec", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()


                    Try
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE  HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Try
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED,0) DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED)"
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Catch ex As Exception
                            Commons.MssBox.Show(Me.Name, "MsgQuyenKT19")
                            Exit Sub
                        End Try
                    Catch ex As Exception
                        tran.Rollback()
                        con.Close()
                    End Try
                    tran.Commit()
                    con.Close()
                    LoadData()
                Else
                    If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT17", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try
                        Commons.Modules.SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_CACH_TH=N'03',HANG_MUC_ID_KE_HOACH=NULL WHERE  HANG_MUC_ID_KE_HOACH=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND  ISNULL(MS_PBT,'') ='' "
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED,0) DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED)"
                        SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                        tran.Commit()
                        con.Close()
                        LoadData()
                    Catch ex As Exception
                        Commons.MssBox.Show(Me.Name, "MsgQuyenKT19")
                        tran.Rollback()
                        con.Close()
                        Exit Sub
                    End Try
                End If
            End If

        End If
    End Sub

    Private Sub gdCVTT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gdCVTT.KeyDown
        If blnThemSua = False Then
            If e.KeyCode = Keys.Delete Then
                If gvKHTT.RowCount <= 0 Then
                    Commons.MssBox.Show(Me.Name, "MsgQuyenKT14")
                    Exit Sub
                End If


                Dim tran As SqlTransaction
                Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
                If gvVTTT.RowCount > 0 Then
                    If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgCongViecDangTonTaiPhuTung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "'  " &
                            " AND HANG_MUC_ID=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "'  " &
                            " AND HANG_MUC_ID=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        tran.Commit()
                        con.Close()
                        BindDataCV()
                        BindDataVTPT()
                    Catch ex As Exception
                        tran.Rollback()
                        con.Close()
                    End Try
                Else
                    If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT17", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "'  " &
                            " AND HANG_MUC_ID=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        tran.Commit()
                        con.Close()
                        BindDataCV()
                        BindDataVTPT()
                    Catch ex As Exception
                        tran.Rollback()
                        con.Close()
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub gdVTTT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gdVTTT.KeyDown
        If blnThemSua = False Then
            If e.KeyCode = Keys.Delete Then
                Dim strTraloi As String

                If gvVTTT.RowCount <= 0 Then
                    Commons.MssBox.Show(Me.Name, "MsgQuyenKT14")
                    Exit Sub
                End If
                Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
                Dim tran As SqlTransaction
                strTraloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT15", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNoCancel)
                If strTraloi = vbCancel Then
                    Exit Sub
                ElseIf strTraloi = vbYes Then
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try

                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvVTTT.GetFocusedDataRow()("MS_CV")
                        SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                        tran.Commit()
                        con.Close()
                        BindDataVTPT()
                    Catch ex As Exception
                        tran.Rollback()
                        con.Close()
                    End Try
                Else
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvVTTT.GetFocusedDataRow()("MS_CV") & " AND MS_PT='" & gvVTTT.GetFocusedDataRow()("MS_PT") & "' AND MS_BO_PHAN='" & gvVTTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                        SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                        tran.Commit()
                        con.Close()
                        BindDataVTPT()
                    Catch ex As Exception
                        tran.Rollback()
                        con.Close()
                    End Try

                End If
            End If

        End If
    End Sub


    Private Sub gvYCNSD_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvYCNSD.CellValueChanged
        If radChuaGiaiQuyet3.Checked = False Then
            gvYCNSD.GetFocusedDataRow()("MS_PBT") = ""
            gvYCNSD.GetFocusedDataRow()("MS_CONG_NHAN") = ""
            Exit Sub
        End If

        If IsDBNull(gvYCNSD.GetFocusedDataRow()("MS_CACH_TH")) Then
            gvYCNSD.GetFocusedDataRow()("MS_PBT") = ""
            Exit Sub
        End If
        If e.Column.FieldName = "MS_CACH_TH" Then
            If gvYCNSD.GetFocusedDataRow()("MS_CACH_TH") = "04" Then
                gvYCNSD.Columns("MS_PBT").OptionsColumn.AllowEdit = True
                Dim tb As New DataTable()
                Dim str As String = "SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" & gvYCNSD.GetFocusedDataRow()("MS_MAY") & "' AND TINH_TRANG_PBT IN (5,4) AND NGAY_NGHIEM_THU >='" & Format(CDate(gvYCNSD.GetFocusedDataRow()("NGAY_GIO_YC_MAX")), "dd/MMM/yyyy") & "'"
                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
                If tb.Rows.Count = 0 Then
                    Commons.MssBox.Show(Me.Name, "msgChuaCoPBTCoNgayNghiemThuLonHonNgayGiamSat")
                    gvYCNSD.GetFocusedDataRow()("MS_PBT") = ""
                    gvYCNSD.GetFocusedDataRow()("MS_CACH_TH") = "00"
                    gvYCNSD.Columns("MS_PBT").OptionsColumn.AllowEdit = False
                    Exit Sub
                End If

                Dim dr As DataRow
                dr = tb.NewRow
                dr.Item("MS_PHIEU_BAO_TRI") = tb.Rows(0).Item(0)
                tb.Rows.InsertAt(dr, 0)
                If tb.Rows.Count > 0 Then
                    repositoryItemLookUpEdit5.NullText = ""
                    repositoryItemLookUpEdit5.ValueMember = "MS_PHIEU_BAO_TRI"
                    repositoryItemLookUpEdit5.DisplayMember = "MS_PHIEU_BAO_TRI"
                    repositoryItemLookUpEdit5.DataSource = tb
                    repositoryItemLookUpEdit5.Columns.Clear()
                    repositoryItemLookUpEdit5.Columns.Add(New Controls.LookUpColumnInfo("MS_PHIEU_BAO_TRI"))
                End If

            Else
                If gvYCNSD.GetFocusedDataRow()("MS_CACH_TH") <> "04" Then
                    gvYCNSD.GetFocusedDataRow()("MS_PBT") = ""
                    gvYCNSD.Columns("MS_PBT").OptionsColumn.AllowEdit = False

                End If
            End If
        End If
    End Sub

    Private Sub gvYCNSD_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gvYCNSD.RowCellStyle
        If bHienthi <> 1 Then Exit Sub
        Dim view As GridView = CType(sender, GridView)
        If e.RowHandle >= 0 Then
            Dim MS_UU_TIEN As String = ""
            MS_UU_TIEN = Convert.ToString(view.GetRowCellDisplayText(e.RowHandle, view.Columns("MS_UU_TIEN")))
            Select Case MS_UU_TIEN
                Case "1"
                    e.Appearance.BackColor = Color.Red

                Case "2"
                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 128, 64)
                Case "3"
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor = Color.Brown
                Case "4"
                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 3, 158, 252)
            End Select
            Select Case MS_UU_TIEN
                Case "3"
                    If view.FocusedRowHandle = e.RowHandle Then
                        e.Appearance.BackColor = Color.Brown 'ControlPaint.Dark(e.Appearance.BackColor)
                    End If
            End Select
        End If
    End Sub

    Sub LoadcboDiadiem()

        'Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDiaDiem_1, Commons.Modules.ObjSystems.MLoadDataNhaXuong(1), "MS_N_XUONG", "TEN_N_XUONG", "")
        If Not String.IsNullOrEmpty(cboDiaDiem_1.TextValue) Then Exit Sub

        Dim dtTmp As New DataTable
        dtTmp = New DataTable()
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", 1, Commons.Modules.UserName, Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadCboTreeList(cboDiaDiem_1, dtTmp, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
        cboDiaDiem_1.SelectedIndex = 1
    End Sub

    Sub LoadcboDayChuyen()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboHThong, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", "")

    End Sub

    Private Sub cmbCity_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadcboDiadiem()
        BindData_Tab()
    End Sub

    Private Sub cmbDistrict_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadcboDiadiem()
        BindData_Tab()
    End Sub



    Private Sub gvYCNSD_CustomDrawCell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gvYCNSD.CustomDrawCell
        If bHienthi <> 0 Then Exit Sub
        If e.Column.FieldName.ToUpper.ToString() <> "TEN_UU_TIEN" Then Exit Sub

        Dim MS_UU_TIEN As String = ""
        MS_UU_TIEN = Convert.ToString(gvYCNSD.GetRowCellValue(e.RowHandle, "MS_UU_TIEN"))

        Select Case MS_UU_TIEN
            Case "1"
                e.Appearance.BackColor = Color.Red
            Case "2"
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 128, 64)
            Case "3"
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor = Color.Brown
            Case "4"
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 3, 158, 252)
        End Select
    End Sub
    'btnLPBT_Click
    Private Sub btnLPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLPBT.Click
        If gvKHTT.RowCount = 0 Then
            Commons.MssBox.Show(Me.Name, "KhongCoDuLieuLapPBT")
            Exit Sub
        End If
1:
        Dim dtselect As New DataTable
        dtselect = CType(gdKHTT.DataSource, DataTable).Copy
        dtselect.DefaultView.RowFilter = " Choose = 1 "
        dtselect = dtselect.DefaultView.ToTable().Copy
        If (dtselect.Rows.Count = 0) Then
            gvKHTT.SetFocusedRowCellValue("Choose", 1)
            gvKHTT.UpdateCurrentRow()
            GoTo 1
            Exit Sub
        End If
        If (dtselect.Rows.Count = 1) Then
            If gvCVTT.RowCount = 0 Then
                Commons.MssBox.Show(Me.Name, "msgKhongCoCongViecNenKhongTheLapPBT")
                Exit Sub
            End If
        End If
        Dim frm As New frmChonLBT()
        frm.sMS_MAY = gvKHTT.GetFocusedDataRow()("MS_MAY")
        Try
            frm.iLoaiBT = gvKHTT.GetFocusedDataRow()("MS_LOAI_BT")
        Catch ex As Exception
            frm.iLoaiBT = -1
        End Try
        Try
            frm.dNBDKH = gvKHTT.GetFocusedRowCellValue("NGAY")
        Catch ex As Exception
        End Try
        Try
            frm.dNKTKH = gvKHTT.GetFocusedRowCellValue("NGAY_DK_HT")
        Catch ex As Exception
        End Try
        Try
            frm.sNLap = gvKHTT.GetFocusedRowCellValue("MS_CONG_NHAN")
        Catch ex As Exception
            frm.sNLap = Nothing
        End Try
        Try
            frm.sNGSat = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT ISNULL(MS_CN_GS,'') AS MS_CN_GS FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID = " & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID").ToString()))
        Catch ex As Exception
            frm.sNGSat = Nothing
        End Try
        If dtselect.Rows.Count > 1 Then
            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgThongBaoLapPBT", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub
            frm.bLapNhieu = True
        End If
        If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        LapPhieuBaoTris(frm)
    End Sub


    Sub ShowKehoachbaotridinhky_KHTT()
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(gdBTDK.DataSource, DataTable).Copy
            dtTmp.DefaultView.RowFilter = " chkCHON = 1"
            dtTmp = dtTmp.DefaultView.ToTable().Copy
            Dim sBT As String = "KHTT_IN_TMP" & Commons.Modules.UserName
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "")
            Me.Cursor = Cursors.WaitCursor
            sBT = " SELECT CONVERT(INT,NULL) AS STT, " &
                        " A.MS_MAY, B.TEN_MAY, A.TEN_LOAI_BT, A.NGAY_CUOI, A.NGAY_BTKT, A.TGCM, A.TGCM_HIEN_TAI, A.TEN_NHOM_MAY " &
                        " FROM " + sBT + " AS A INNER JOIN dbo.MAY AS B ON A.MS_MAY = B.MS_MAY " &
                        " ORDER BY A.MS_MAY"
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sBT))
            ReportMain.clsKHBTDinhKyKHTT.InKHBT(dtTmp, Me.Name.ToString)
            Commons.Modules.ObjSystems.XoaTable("KHTT_IN_TMP" & Commons.Modules.UserName)
            Commons.Modules.ObjSystems.XoaTable("rptTHONG_TIN_CHUNG")
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EportKHTTtoExcel()
        Dim DataToExportBaria As New DataTable()


        DataToExportBaria.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_DATA_KHTT_BARIA_TO_PRINT",
                        cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue,
                        IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue), Commons.Modules.UserName,
                        cboDiaDiem_1.EditValue.ToString(), cboHThong.EditValue, dtpTNKHTT.DateTime.Date, dtpDNKHTT.DateTime.Date))

        If DataToExportBaria.Rows.Count <= 0 Then
            Commons.MssBox.Show(Me.Name, "BARIA_NO_DATA_TO_PRINT")
            Exit Sub
        End If


        Dim _ExcelApp As New Excel.Application
        Dim _ExcelBooks As Excel.Workbook
        Dim _ExcelSheets As Excel.Worksheet


        _ExcelBooks = _ExcelApp.Workbooks.Add
        _ExcelSheets = CType(_ExcelBooks.Worksheets(1), Excel.Worksheet)

        Dim iRow As Integer = 0
        Dim iColumn As Integer = 3
        Dim iTop As Integer = 6
        iRow = 1


        With _ExcelSheets

            .PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            .PageSetup.LeftMargin = 18
            .PageSetup.RightMargin = 18
            .PageSetup.TopMargin = 18
            .PageSetup.BottomMargin = 18



            .PageSetup.HeaderMargin = 50
            .PageSetup.FooterMargin = 50

            '  Commons.Modules.MExcel.ExcelEnd(_ExcelApp, _ExcelBooks, _ExcelSheets, False, True, True, _
            ' True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)

            .Range(.Cells(1, 1), .Cells(20000, 50)).Font.Name = "Arial"
            .Range(.Cells(1, 1), .Cells(20000, 50)).Font.Size = 10

            .Cells(1, 1).ColumnWidth = 3
            .Cells(1, 2).ColumnWidth = 17
            .Cells(1, 3).ColumnWidth = 7
            .Cells(1, 4).ColumnWidth = 10
            .Cells(1, 5).ColumnWidth = 19
            .Cells(1, 6).ColumnWidth = 20
            .Cells(1, 7).ColumnWidth = 5
            .Cells(1, 8).ColumnWidth = 6
            .Cells(1, 9).ColumnWidth = 13
            .Cells(1, 10).ColumnWidth = 15
            .Cells(1, 11).ColumnWidth = 8
            .Cells(1, 12).ColumnWidth = 10


            Try

                .PageSetup.PrintTitleRows = "$9:$9"
                Commons.Modules.MExcel.TaoLogo(_ExcelSheets, 5, 0, 100, 45, Application.StartupPath)

            Catch ex As Exception
            End Try
            .Range(.Cells(iRow, 1), .Cells(iRow + 2, 2)).MergeCells = True
            .Range(.Cells(iRow, 1), .Cells(iRow + 2, 3)).BorderAround()

            .Range(.Cells(iRow, iColumn), .Cells(iRow + 2, iColumn + 6)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Value = "MASTER MAINTENANCE PLAN"
            '.Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Color = RGB(237, 28, 36)
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Bold = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Size = 24
            .Range(.Cells(iRow, iColumn), .Cells(iRow + 2, iColumn + 6)).BorderAround()

            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            'iRow += 1
            '.Cells(iRow, iColumn).Value = "" '"From Period " & _FromPeriod & " To Period " & _ToPeriod
            'iRow += 3
            iColumn = iColumn + 7
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "From"


            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "BM001/01"


            iRow += 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "Date"


            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "'" + DateTime.Now.Date.ToString("dd/MM/yyyy")

            iRow += 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "Revision"

            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "'01"

            .Range(.Cells(iRow + 1, 1), .Cells(iRow + 5, 12)).BorderAround()


            iRow += 2
            iColumn = 2



            .Cells(iRow, iColumn).Value = "From:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = "'" + dtpTNKHTT.DateTime.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            .Cells(iRow, iColumn + 4).Value = "To:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = "'" + dtpDNKHTT.DateTime.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)


            iRow += 1
            iColumn = 2

            .Cells(iRow, iColumn).Value = "Location:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = cboDiaDiem_1.Text.ToString()

            .Cells(iRow, iColumn + 4).Value = "Line:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = cboHThong.Text.ToString()

            iRow += 1
            iColumn = 2

            .Cells(iRow, iColumn).Value = "Equipment type:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = cboLoaiThietBiBTDK.Text.ToString()

            .Cells(iRow, iColumn + 4).Value = "Equipment group:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = CboNhomThietBiBTDK.Text.ToString()

            iRow += 2
            iColumn = 1

            .Cells(iRow, iColumn).Value = "No."
            .Cells(iRow, iColumn + 1).Value = "Plan Acticle"
            .Cells(iRow, iColumn + 2).Value = "Priority"
            .Cells(iRow, iColumn + 3).Value = "Planner"
            .Cells(iRow, iColumn + 4).Value = "Component"
            .Cells(iRow, iColumn + 5).Value = "Work description"
            .Cells(iRow, iColumn + 6).Value = "Time"
            .Cells(iRow, iColumn + 7).Value = "Labor"
            .Cells(iRow, iColumn + 8).Value = "Labor requirement"
            .Cells(iRow, iColumn + 9).Value = "Spare part and material"
            .Cells(iRow, iColumn + 10).Value = "Tool"
            .Cells(iRow, iColumn + 11).Value = "Date"
            '.Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).BorderAround()
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).Borders.LineStyle() = 7
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).WrapText = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).Font.Bold = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            Dim _DataMay As New DataTable
            _DataMay = DataToExportBaria.DefaultView.ToTable(True, "MS_MAY", "TEN_MAY")

            For Each vr As DataRow In _DataMay.Rows
                iRow += 1
                iColumn = 1
                .Cells(iRow, iColumn).Value = "Equipment code: " + vr("MS_MAY") + "                         Equipment: " + vr("MS_MAY")
                .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).MergeCells = True
                .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).BorderAround()
                .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).Font.Bold = True

                Dim _DtTMPLine As New DataView(DataToExportBaria, "MS_MAY = '" + vr("MS_MAY").ToString + "'", "NGAY_KH", DataViewRowState.CurrentRows)

                iRow += 1
                Dim MaTran2(0 To _DtTMPLine.ToTable().Rows.Count, 0 To 11) As Object

                For i As Integer = 0 To _DtTMPLine.ToTable().Rows.Count - 1
                    MaTran2(i, 0) = (i + 1).ToString()
                    MaTran2(i, 1) = _DtTMPLine.ToTable().Rows(i)("TEN_HANG_MUC").ToString()
                    MaTran2(i, 2) = _DtTMPLine.ToTable().Rows(i)("TEN_MUC_UT").ToString()
                    MaTran2(i, 3) = _DtTMPLine.ToTable().Rows(i)("TEN_NGUOI_LKH").ToString()
                    MaTran2(i, 4) = _DtTMPLine.ToTable().Rows(i)("TEN_BO_PHAN").ToString()
                    MaTran2(i, 5) = _DtTMPLine.ToTable().Rows(i)("TEN_CONG_VIEC").ToString()
                    MaTran2(i, 6) = _DtTMPLine.ToTable().Rows(i)("THOI_GIAN_DU_KIEN").ToString()
                    MaTran2(i, 7) = _DtTMPLine.ToTable().Rows(i)("SO_NS").ToString()
                    MaTran2(i, 8) = _DtTMPLine.ToTable().Rows(i)("SO_NS_YC").ToString()
                    MaTran2(i, 9) = _DtTMPLine.ToTable().Rows(i)("VT_PT").ToString()
                    MaTran2(i, 10) = _DtTMPLine.ToTable().Rows(i)("CC_DC").ToString()
                    MaTran2(i, 11) = DateTime.Parse(_DtTMPLine.ToTable().Rows(i)("NGAY_KH").ToString()).ToString("dd/MM/yyyy")
                Next

                .Range(.Cells(iRow, iColumn), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count, iColumn + 11)).Value = MaTran2
                .Range(.Cells(iRow, iColumn), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count - 1, iColumn + 11)).Borders.LineStyle() = 7
                .Range(.Cells(iRow, iColumn), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count, iColumn + 11)).WrapText = True
                '  .Range(.Cells(iRow, iColumn + 10), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count, iColumn + 11)).NumberFormat = "dd/MM/yyyy"
                iRow += _DtTMPLine.ToTable().Rows.Count - 1
                iColumn = 1

            Next

        End With

        _ExcelApp.Visible = True

    End Sub

    Private Sub EportKHTTtoExcelBaria()
        Dim DataToExportBaria As New DataTable()
        DataToExportBaria.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_DATA_KHTT_BARIA_TO_PRINT",
                        cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue,
                        IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue), Commons.Modules.UserName,
                        cboDiaDiem_1.EditValue.ToString(), cboHThong.EditValue, dtpTNKHTT.DateTime.Date, dtpDNKHTT.DateTime.Date))

        If DataToExportBaria.Rows.Count <= 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BARIA_NO_DATA_TO_PRINT", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        Try
            If cboNTHien.Text = "" Then
                DataToExportBaria.DefaultView.RowFilter = " ISNULL(MS_CONG_NHAN,'') = '' "
            Else
                If cboNTHien.EditValue = "-1" Then
                    DataToExportBaria.DefaultView.RowFilter = ""
                Else
                    DataToExportBaria.DefaultView.RowFilter = " ISNULL(MS_CONG_NHAN,'') = '" & cboNTHien.EditValue & "' "
                End If
            End If

        Catch ex As Exception
            DataToExportBaria.DefaultView.RowFilter = ""
        End Try
        Dim _ExcelApp As New Excel.Application
        Dim _ExcelBooks As Excel.Workbook
        Dim _ExcelSheets As Excel.Worksheet


        _ExcelBooks = _ExcelApp.Workbooks.Add
        _ExcelSheets = CType(_ExcelBooks.Worksheets(1), Excel.Worksheet)

        Dim iRow As Integer = 0
        Dim iColumn As Integer = 3
        Dim iTop As Integer = 6
        iRow = 1
        '_ExcelApp.Visible = True

        With _ExcelSheets

            '.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            .PageSetup.LeftMargin = 18
            .PageSetup.RightMargin = 18
            .PageSetup.TopMargin = 18
            .PageSetup.BottomMargin = 18



            .PageSetup.HeaderMargin = 50
            .PageSetup.FooterMargin = 50

            '  Commons.Modules.MExcel.ExcelEnd(_ExcelApp, _ExcelBooks, _ExcelSheets, False, True, True, _
            ' True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)

            .Range(.Cells(1, 1), .Cells(20000, 50)).Font.Name = "Arial"
            .Range(.Cells(1, 1), .Cells(20000, 50)).Font.Size = 10

            .Cells(1, 1).ColumnWidth = 3
            .Cells(1, 2).ColumnWidth = 17
            .Cells(1, 3).ColumnWidth = 18
            .Cells(1, 4).ColumnWidth = 17
            .Cells(1, 5).ColumnWidth = 7
            .Cells(1, 6).ColumnWidth = 10
            .Cells(1, 7).ColumnWidth = 19
            .Cells(1, 8).ColumnWidth = 20
            .Cells(1, 9).ColumnWidth = 5
            .Cells(1, 10).ColumnWidth = 6
            .Cells(1, 11).ColumnWidth = 13
            .Cells(1, 12).ColumnWidth = 15
            .Cells(1, 13).ColumnWidth = 17
            .Cells(1, 14).ColumnWidth = 10


            Try
                .PageSetup.PrintTitleRows = "$9:$9"
                Commons.Modules.MExcel.TaoLogo(_ExcelSheets, 5, 0, 100, 45, Application.StartupPath)
            Catch ex As Exception
            End Try

            .Range(.Cells(iRow, 1), .Cells(iRow + 2, 3)).MergeCells = True
            .Range(.Cells(iRow, 1), .Cells(iRow + 2, 3)).BorderAround()
            iColumn = iColumn + 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow + 2, iColumn + 7)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Value = "MASTER MAINTENANCE PLAN"
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Bold = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Size = 24
            .Range(.Cells(iRow, iColumn), .Cells(iRow + 2, iColumn + 7)).BorderAround()

            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            'iRow += 1
            '.Cells(iRow, iColumn).Value = "" '"From Period " & _FromPeriod & " To Period " & _ToPeriod
            'iRow += 3
            iColumn = iColumn + 8
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "From"


            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "BM001/01"


            iRow += 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "Date"


            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "'" + DateTime.Now.Date.ToString("dd/MM/yyyy")

            iRow += 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "Revision"

            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "'01"

            .Range(.Cells(iRow + 1, 1), .Cells(iRow + 5, 14)).BorderAround()


            iRow += 2
            iColumn = 4

            .Cells(iRow, iColumn).Value = "From:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = "'" + dtpTNKHTT.DateTime.Date.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            .Cells(iRow, iColumn + 4).Value = "To:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = "'" + dtpDNKHTT.DateTime.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)


            iRow += 1
            iColumn = 4

            .Cells(iRow, iColumn).Value = "Location:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = cboDiaDiem_1.Text.ToString()

            .Cells(iRow, iColumn + 4).Value = "Line:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = cboHThong.Text.ToString()

            iRow += 1
            iColumn = 4

            .Cells(iRow, iColumn).Value = "Equipment type:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = cboLoaiThietBiBTDK.Text.ToString()

            .Cells(iRow, iColumn + 4).Value = "Equipment group:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = CboNhomThietBiBTDK.Text.ToString()

            iRow += 2
            iColumn = 1

            .Cells(iRow, iColumn).Value = "No."
            .Cells(iRow, iColumn + 1).Value = "Equipment code"
            .Cells(iRow, iColumn + 2).Value = "Equipment"
            .Cells(iRow, iColumn + 3).Value = "Plan Acticle"
            .Cells(iRow, iColumn + 4).Value = "Priority"
            .Cells(iRow, iColumn + 5).Value = "Planner"
            .Cells(iRow, iColumn + 6).Value = "Component"
            .Cells(iRow, iColumn + 7).Value = "Work description"
            .Cells(iRow, iColumn + 8).Value = "Time"
            .Cells(iRow, iColumn + 9).Value = "Labor"
            .Cells(iRow, iColumn + 10).Value = "Labor requirement"
            .Cells(iRow, iColumn + 11).Value = "Spare part and material"
            .Cells(iRow, iColumn + 12).Value = "Tool"
            .Cells(iRow, iColumn + 13).Value = "Date"

            '.Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).BorderAround()
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 13)).Borders.LineStyle() = 7
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 13)).WrapText = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 13)).Font.Bold = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 13)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 13)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter


            Dim MaTran2(0 To DataToExportBaria.Rows.Count, 0 To 13) As Object

            For i As Integer = 0 To DataToExportBaria.Rows.Count - 1
                MaTran2(i, 0) = (i + 1).ToString()
                MaTran2(i, 1) = DataToExportBaria.Rows(i)("MS_MAY").ToString()
                MaTran2(i, 2) = DataToExportBaria.Rows(i)("TEN_MAY").ToString()
                MaTran2(i, 3) = DataToExportBaria.Rows(i)("TEN_HANG_MUC").ToString()
                MaTran2(i, 4) = DataToExportBaria.Rows(i)("TEN_MUC_UT").ToString()
                MaTran2(i, 5) = DataToExportBaria.Rows(i)("TEN_NGUOI_LKH").ToString()
                MaTran2(i, 6) = DataToExportBaria.Rows(i)("TEN_BO_PHAN").ToString()
                MaTran2(i, 7) = DataToExportBaria.Rows(i)("TEN_CONG_VIEC").ToString()
                MaTran2(i, 8) = DataToExportBaria.Rows(i)("THOI_GIAN_DU_KIEN").ToString()
                MaTran2(i, 9) = DataToExportBaria.Rows(i)("SO_NS").ToString()
                MaTran2(i, 10) = DataToExportBaria.Rows(i)("SO_NS_YC").ToString()
                MaTran2(i, 11) = DataToExportBaria.Rows(i)("VT_PT").ToString()
                MaTran2(i, 12) = DataToExportBaria.Rows(i)("CC_DC").ToString()
                MaTran2(i, 13) = DateTime.Parse(DataToExportBaria.Rows(i)("NGAY_KH").ToString()).ToString("dd/MM/yyyy")
            Next
            iRow += 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow + DataToExportBaria.Rows.Count, iColumn + 13)).Value = MaTran2
            .Range(.Cells(iRow, iColumn), .Cells(iRow + DataToExportBaria.Rows.Count - 1, iColumn + 13)).Borders.LineStyle() = 7
            .Range(.Cells(iRow, iColumn), .Cells(iRow + DataToExportBaria.Rows.Count, iColumn + 13)).WrapText = True


            .Range(.Cells(iRow, 14), .Cells(iRow + DataToExportBaria.Rows.Count, 14)).NumberFormat = "dd/MM/yyyy"
            .Range(.Cells(iRow, 14), .Cells(iRow + DataToExportBaria.Rows.Count, 14)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(iRow, 14), .Cells(iRow + DataToExportBaria.Rows.Count, 14)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter


        End With

        _ExcelApp.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim DataToExportBaria As New DataTable()


        DataToExportBaria.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_DATA_KHTT_BARIA_TO_PRINT",
                        cboLoaiThietBiBTDK.EditValue, CboNhomThietBiBTDK.EditValue,
                        IIf(CboMaSoThietBiBTDK.EditValue = " < ALL > ", "-1", CboMaSoThietBiBTDK.EditValue), Commons.Modules.UserName,
                        cboDiaDiem_1.EditValue.ToString(), cboHThong.EditValue, dtpTNKHTT.DateTime.Date, dtpDNKHTT.DateTime.Date))

        If DataToExportBaria.Rows.Count <= 0 Then
            Commons.MssBox.Show(Me.Name, "BARIA_NO_DATA_TO_PRINT")
            Exit Sub
        End If


        Dim _ExcelApp As New Excel.Application
        Dim _ExcelBooks As Excel.Workbook
        Dim _ExcelSheets As Excel.Worksheet

        _ExcelApp.Visible = True
        _ExcelBooks = _ExcelApp.Workbooks.Add
        _ExcelSheets = CType(_ExcelBooks.Worksheets(1), Excel.Worksheet)

        Dim iRow As Integer = 0
        Dim iColumn As Integer = 3
        Dim iTop As Integer = 6
        iRow = 1


        With _ExcelSheets

            .PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4
            .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            .PageSetup.LeftMargin = 18
            .PageSetup.RightMargin = 18
            .PageSetup.TopMargin = 18
            .PageSetup.BottomMargin = 18



            .PageSetup.HeaderMargin = 50
            .PageSetup.FooterMargin = 50

            '  Commons.Modules.MExcel.ExcelEnd(_ExcelApp, _ExcelBooks, _ExcelSheets, False, True, True, _
            ' True, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30, 30, 30, 30, 50, 50, 100)

            .Range(.Cells(1, 1), .Cells(20000, 50)).Font.Name = "Arial"
            .Range(.Cells(1, 1), .Cells(20000, 50)).Font.Size = 10

            .Cells(1, 1).ColumnWidth = 3
            .Cells(1, 2).ColumnWidth = 17
            .Cells(1, 3).ColumnWidth = 7
            .Cells(1, 4).ColumnWidth = 10
            .Cells(1, 5).ColumnWidth = 19
            .Cells(1, 6).ColumnWidth = 20
            .Cells(1, 7).ColumnWidth = 5
            .Cells(1, 8).ColumnWidth = 6
            .Cells(1, 9).ColumnWidth = 13
            .Cells(1, 10).ColumnWidth = 15
            .Cells(1, 11).ColumnWidth = 8
            .Cells(1, 12).ColumnWidth = 10


            Try


                Commons.Modules.MExcel.TaoLogo(_ExcelSheets, 0, 0, 100, 45, Application.StartupPath)

            Catch ex As Exception
            End Try
            .Range(.Cells(iRow, 1), .Cells(iRow + 2, 2)).MergeCells = True
            .Range(.Cells(iRow, 1), .Cells(iRow + 2, 3)).BorderAround()

            .Range(.Cells(iRow, iColumn), .Cells(iRow + 2, iColumn + 6)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Value = "MASTER MAINTENANCE PLAN"
            '.Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Color = RGB(237, 28, 36)
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Bold = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).Font.Size = 24
            .Range(.Cells(iRow, iColumn), .Cells(iRow + 2, iColumn + 6)).BorderAround()

            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            'iRow += 1
            '.Cells(iRow, iColumn).Value = "" '"From Period " & _FromPeriod & " To Period " & _ToPeriod
            'iRow += 3
            iColumn = iColumn + 7
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "From"


            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "BM001/01"


            iRow += 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "Date"


            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "'" + DateTime.Now.Date.ToString("dd/MM/yyyy")

            iRow += 1
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).MergeCells = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn)).BorderAround()
            .Cells(iRow, iColumn).Value = "Revision"

            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).MergeCells = True
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 2)).BorderAround()
            .Cells(iRow, iColumn + 1).Value = "'01"

            .Range(.Cells(iRow + 1, 1), .Cells(iRow + 5, 12)).BorderAround()


            iRow += 2
            iColumn = 2

            .Cells(iRow, iColumn).Value = "From:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = "'" + dtpTNKHTT.DateTime.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

            .Cells(iRow, iColumn + 4).Value = "To:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = "'" + dtpDNKHTT.DateTime.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)


            iRow += 1
            iColumn = 2

            .Cells(iRow, iColumn).Value = "Location:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = cboDiaDiem_1.Text.ToString()

            .Cells(iRow, iColumn + 4).Value = "Line:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = cboHThong.Text.ToString()

            iRow += 1
            iColumn = 2

            .Cells(iRow, iColumn).Value = "Equipment type:"
            .Range(.Cells(iRow, iColumn + 1), .Cells(iRow, iColumn + 3)).MergeCells = True
            .Cells(iRow, iColumn + 1).Value = cboLoaiThietBiBTDK.Text.ToString()

            .Cells(iRow, iColumn + 4).Value = "Equipment group:"
            .Range(.Cells(iRow, iColumn + 5), .Cells(iRow, iColumn + 10)).MergeCells = True
            .Cells(iRow, iColumn + 5).Value = CboNhomThietBiBTDK.Text.ToString()

            iRow += 2
            iColumn = 1

            .Cells(iRow, iColumn).Value = "No."
            .Cells(iRow, iColumn + 1).Value = "Plan Acticle"
            .Cells(iRow, iColumn + 2).Value = "Priority"
            .Cells(iRow, iColumn + 3).Value = "Planner"
            .Cells(iRow, iColumn + 4).Value = "Component"
            .Cells(iRow, iColumn + 5).Value = "Work description"
            .Cells(iRow, iColumn + 6).Value = "Time"
            .Cells(iRow, iColumn + 7).Value = "Labor"
            .Cells(iRow, iColumn + 8).Value = "Labor requirement"
            .Cells(iRow, iColumn + 9).Value = "Spare part and material"
            .Cells(iRow, iColumn + 10).Value = "Tool"
            .Cells(iRow, iColumn + 11).Value = "Date"
            '.Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).BorderAround()
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).Borders.LineStyle() = 7
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).WrapText = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).Font.Bold = True
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            Dim _DataMay As New DataTable
            _DataMay = DataToExportBaria.DefaultView.ToTable(True, "MS_MAY", "TEN_MAY")

            For Each vr As DataRow In _DataMay.Rows
                iRow += 1
                iColumn = 1
                .Cells(iRow, iColumn).Value = "Equipment code: " + vr("MS_MAY") + "                         Equipment: " + vr("MS_MAY")
                .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).MergeCells = True
                .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).BorderAround()
                .Range(.Cells(iRow, iColumn), .Cells(iRow, iColumn + 11)).Font.Bold = True

                Dim _DtTMPLine As New DataView(DataToExportBaria, "MS_MAY = '" + vr("MS_MAY").ToString + "'", "NGAY_KH", DataViewRowState.CurrentRows)

                iRow += 1
                Dim MaTran2(0 To _DtTMPLine.ToTable().Rows.Count, 0 To 11) As Object

                For i As Integer = 0 To _DtTMPLine.ToTable().Rows.Count - 1
                    MaTran2(i, 0) = (i + 1).ToString()
                    MaTran2(i, 1) = _DtTMPLine.ToTable().Rows(i)("TEN_HANG_MUC").ToString()
                    MaTran2(i, 2) = _DtTMPLine.ToTable().Rows(i)("TEN_MUC_UT").ToString()
                    MaTran2(i, 3) = _DtTMPLine.ToTable().Rows(i)("TEN_NGUOI_LKH").ToString()
                    MaTran2(i, 4) = _DtTMPLine.ToTable().Rows(i)("TEN_BO_PHAN").ToString()
                    MaTran2(i, 5) = _DtTMPLine.ToTable().Rows(i)("TEN_CONG_VIEC").ToString()
                    MaTran2(i, 6) = _DtTMPLine.ToTable().Rows(i)("THOI_GIAN_DU_KIEN").ToString()
                    MaTran2(i, 7) = _DtTMPLine.ToTable().Rows(i)("SO_NS").ToString()
                    MaTran2(i, 8) = _DtTMPLine.ToTable().Rows(i)("SO_NS_YC").ToString()
                    MaTran2(i, 9) = _DtTMPLine.ToTable().Rows(i)("VT_PT").ToString()
                    MaTran2(i, 10) = _DtTMPLine.ToTable().Rows(i)("CC_DC").ToString()
                    MaTran2(i, 11) = DateTime.Parse(_DtTMPLine.ToTable().Rows(i)("NGAY_KH").ToString()).ToString("dd/MM/yyyy")
                Next

                .Range(.Cells(iRow, iColumn), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count, iColumn + 11)).Value = MaTran2
                .Range(.Cells(iRow, iColumn), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count - 1, iColumn + 11)).Borders.LineStyle() = 7
                .Range(.Cells(iRow, iColumn), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count, iColumn + 11)).WrapText = True
                '  .Range(.Cells(iRow, iColumn + 10), .Cells(iRow + _DtTMPLine.ToTable().Rows.Count, iColumn + 11)).NumberFormat = "dd/MM/yyyy"
                iRow += _DtTMPLine.ToTable().Rows.Count - 1
                iColumn = 1

            Next

        End With
    End Sub

    Private Sub gdVTTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gdVTTT.Click

    End Sub

    Private Sub cboNTHien_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNTHien.EditValueChanged
        Try
            If Me.ActiveControl Is Nothing Then Exit Sub
            LocData()
            If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
                dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
                CalularDataSelected(dataHangMucSelected)
            End If
        Catch ex As Exception
        End Try

    End Sub

#Region "Monitoring"
    Private monitorCheckAll As Boolean = False
    Private dataHangMucSelected As New DataTable()
    Private dataCongViecHangMucSelected As New DataTable()
    Private DataMonitoring As New DataTable()

    Private Sub CreateTableDataMonitoring()

        DataMonitoring = New DataTable("Monitoring")
        DataMonitoring.Columns.Add("Argument", GetType(String))
        DataMonitoring.Columns.Add("Value", GetType(Double))

    End Sub

    Private Sub CalularDataSelected(ByRef dataHangMucSelected1 As DataTable)
        Try
            btnViewMonitoring.Series.Clear()
            ChartWeeksMonitoring.Series.Clear()
            ChartMonthsMonitoring.Series.Clear()
            Dim tbfilterChoose As New DataTable()
            tbfilterChoose = GetDataKHTTMonitoring(dataHangMucSelected1)
            If tbfilterChoose IsNot Nothing Then
                If tbfilterChoose.Rows.Count > 0 Then

                    Dim seriesDays As New Series("TG bảo trì dự kiến", ViewType.Bar)
                    btnViewMonitoring.Series.Add(seriesDays)
                    Dim _dataDays As New DataView(tbfilterChoose, "OBJOPTION=1", "", DataViewRowState.CurrentRows)
                    seriesDays.DataSource = _dataDays.ToTable()
                    seriesDays.ArgumentScaleType = ScaleType.Qualitative
                    seriesDays.ArgumentDataMember = "OBJDATA"
                    seriesDays.ValueScaleType = ScaleType.Numerical
                    seriesDays.ValueDataMembers.AddRange(New String() {"OBJVALUE"})
                    CType(btnViewMonitoring.Series(0).Label, BarSeriesLabel).ShowForZeroValues = True

                    Dim seriesWeeks As New Series("TG bảo trì dự kiến", ViewType.Bar)
                    ChartWeeksMonitoring.Series.Add(seriesWeeks)
                    Dim _dataWeeks As New DataView(tbfilterChoose, "OBJOPTION=2", "", DataViewRowState.CurrentRows)
                    seriesWeeks.DataSource = _dataWeeks.ToTable()
                    seriesWeeks.ArgumentScaleType = ScaleType.Qualitative
                    seriesWeeks.ArgumentDataMember = "OBJDATA"
                    seriesWeeks.ValueScaleType = ScaleType.Numerical
                    seriesWeeks.ValueDataMembers.AddRange(New String() {"OBJVALUE"})
                    CType(ChartWeeksMonitoring.Series(0).Label, BarSeriesLabel).ShowForZeroValues = True

                    Dim seriesMonths As New Series("TG bảo trì dự kiến", ViewType.Bar)
                    ChartMonthsMonitoring.Series.Add(seriesMonths)
                    Dim _dataMonths As New DataView(tbfilterChoose, "OBJOPTION=3", "", DataViewRowState.CurrentRows)
                    seriesMonths.DataSource = _dataMonths.ToTable()
                    seriesMonths.ArgumentScaleType = ScaleType.Qualitative
                    seriesMonths.ArgumentDataMember = "OBJDATA"
                    seriesMonths.ValueScaleType = ScaleType.Numerical
                    seriesMonths.ValueDataMembers.AddRange(New String() {"OBJVALUE"})
                    CType(ChartMonthsMonitoring.Series(0).Label, BarSeriesLabel).ShowForZeroValues = True
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        Try
            If monitorCheckAll = False Then
                Try
                    dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
                    dataHangMucSelected.Rows(gvKHTT.GetFocusedDataSourceRowIndex)("Choose") = CType(sender, CheckEdit).Checked
                Catch ex As Exception
                End Try
                If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
                    dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
                    CalularDataSelected(dataHangMucSelected)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetDataKHTTMonitoring(ByRef dataHangMucSelected1 As DataTable) As DataTable
        Dim _dtmonitoring As New DataTable()

        Dim _Status As Integer = 0

        If radChuaGiaiQuyet1.Checked = True Then
            _Status = 1
        End If

        If RadBoQua1.Checked = True Then
            _Status = 2
        End If

        If radDaGiaiQuyet1.Checked = True Then
            _Status = 3
        End If

        dataHangMucSelected1.DefaultView.RowFilter = "Choose = true"
        Dim aaa As DataTable = dataHangMucSelected1.DefaultView.ToTable("hangmuc", True, "HANG_MUC_ID")

        Dim sqlparams(5) As SqlParameter
        sqlparams(0) = New SqlClient.SqlParameter("@FROMDATE", SqlDbType.DateTime)
        sqlparams(0).Value = dtpTNKHTT.DateTime.Date

        sqlparams(1) = New SqlClient.SqlParameter("@TODATE", SqlDbType.DateTime)
        sqlparams(1).Value = dtpDNKHTT.DateTime.Date

        sqlparams(2) = New SqlClient.SqlParameter("@OPTION", SqlDbType.Int)
        sqlparams(2).Value = -1

        sqlparams(3) = New SqlClient.SqlParameter("@STATUS", SqlDbType.Int)
        sqlparams(3).Value = _Status


        Dim parameter As SqlParameter = New SqlParameter()
        parameter.ParameterName = "@hangmuc"
        parameter.SqlDbType = System.Data.SqlDbType.Structured
        parameter.TypeName = "VS_Hang_Muc_KHTT"
        parameter.Value = aaa

        sqlparams(4) = parameter

        _dtmonitoring.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.StoredProcedure, "VS_GET_DATA_KTTT_MONITORING", sqlparams))

        Return _dtmonitoring
    End Function

    Private Sub btnShowMonitoring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONN.Click
        dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
        CalularDataSelected(dataHangMucSelected)
        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden Then
            DockPanel1.Show()
        Else
            DockPanel1.Hide()
        End If
    End Sub

    Private Sub gvBTDK_RowClick(sender As Object, e As RowClickEventArgs) Handles gvBTDK.RowClick
        Try
            If e.Button = MouseButtons.Right Then
                CreateMenuGridBaoTri(gdBTDK)
            End If

        Catch
        End Try

    End Sub

    Private Sub btnSelectAllForMonitoring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllForMonitoring.Click
        Try
            For i As Integer = 0 To CType(gdKHTT.DataSource, DataTable).Rows.Count
                CType(gdKHTT.DataSource, DataTable).Rows(i)("Choose") = True
            Next

        Catch ex As Exception

        End Try
        dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
        CalularDataSelected(dataHangMucSelected)


    End Sub

    Private Sub btnDeselectAllForMonitoring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAllForMonitoring.Click
        Try
            For i As Integer = 0 To CType(gdKHTT.DataSource, DataTable).Rows.Count - 1
                CType(gdKHTT.DataSource, DataTable).Rows(i)("Choose") = False
            Next
            CType(gdKHTT.DataSource, DataTable).AcceptChanges()
        Catch ex As Exception
        End Try


        dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
        CalularDataSelected(dataHangMucSelected)

    End Sub

#End Region

    Private Sub gdCVTT_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gdCVTT.DataSourceChanged

    End Sub
    Private Sub LapPhieuBaoTris(ByVal frm As frmChonLBT)

        Dim sNLap, sNGSat As String
        Dim iLBT As Integer = Convert.ToInt32(Commons.Modules.SQLString)
        Dim strGioTam As String = TimeValue(Now)
        Dim sBT, sSql As String
        Dim dtTmp As New DataTable

        Dim NGAY_BTPN, NGAY_BD_KH, NGAY_KT_KH As Date
        Dim MS_PBT As String

        Dim sBTPTCT As String
        sBTPTCT = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.XoaTable(sBTPTCT)

        Dim tran As SqlTransaction
        'Dim tran As SqlConnection



        Dim dtselect As New DataTable
        dtselect = CType(gdKHTT.DataSource, DataTable).Copy
        dtselect.DefaultView.RowFilter = " Choose = 1"
        dtselect = dtselect.DefaultView.ToTable().Copy
        If (dtselect.Rows.Count > 1) Then
            dtselect.DefaultView.RowFilter = "(MS_LOAI_BT IS NOT NULL OR MS_LOAI_BT <> '')"
            dtselect = dtselect.DefaultView.ToTable().Copy

            If (dtselect.Rows.Count = 0) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                    "msgKhongKHTTNaoCoLoaiBaoTriNenKhongTaoPhieuDuoc", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        prbLapPhieuBaoTri.Visible = True
        TableLayoutPanel4.RowStyles.Item(TableLayoutPanel4.GetRow(prbLapPhieuBaoTri)).Height = 20
        prbLapPhieuBaoTri.Position = 0
        prbLapPhieuBaoTri.Properties.Step = 1
        prbLapPhieuBaoTri.Properties.PercentView = True
        prbLapPhieuBaoTri.Properties.Maximum = dtselect.Rows.Count
        prbLapPhieuBaoTri.Properties.Minimum = 0

        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        tran = con.BeginTransaction()
        Try
            sSql = " INSERT INTO [IC_PHU_TUNG_LOAI_MAY] ([MS_PT],[MS_LOAI_MAY]) " &
                                " SELECT  DISTINCT MS_PT,  dbo.NHOM_MAY.MS_LOAI_MAY " &
                                " FROM dbo.NHOM_MAY INNER JOIN dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN " &
                                " dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG ON dbo.MAY.MS_MAY = dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG.MS_MAY " &
                                " WHERE NOT EXISTS (SELECT * FROM IC_PHU_TUNG_LOAI_MAY D WHERE KE_HOACH_TONG_CONG_VIEC_PHU_TUNG.MS_PT = D.MS_PT AND  " &
                                " dbo.NHOM_MAY.MS_LOAI_MAY = D.MS_LOAI_MAY )"
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            tran.Rollback()
            con.Close()
            Exit Sub
        End Try

        Try
            For Each dr As DataRow In dtselect.Rows
                'Cap nhap vao IC_PHU_TUNG_LOAI_MAY cho cac Phu Tung moi 
                Dim dt_Tmp As New DataTable()
                sSql = "select * from KE_HOACH_TONG_CONG_VIEC where HANG_MUC_ID =" & dr("HANG_MUC_ID") & " and THUE_NGOAI=0 and MS_PHIEU_BAO_TRI IS NULL"
                dt_Tmp.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, sSql))
                For Each dr1 As DataRow In dt_Tmp.Rows
                    sSql = " INSERT INTO [CAU_TRUC_THIET_BI_PHU_TUNG]([MS_MAY],[MS_BO_PHAN],[MS_PT],[MS_VI_TRI_PT],[SO_LUONG],[ACTIVE])	 " &
                                " SELECT DISTINCT A.MS_MAY, A.MS_BO_PHAN, A.MS_PT, 'A' AS MS_VI_TRI_PT, A.SO_LUONG, 1 AS ACTIVE " &
                                " FROM         dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG AS A INNER JOIN " &
                                " dbo.IC_PHU_TUNG AS B ON A.MS_PT = B.MS_PT INNER JOIN " &
                                " dbo.LOAI_VT AS C ON B.MS_LOAI_VT = C.MS_LOAI_VT " &
                                " WHERE     (C.VAT_TU = 0) AND NOT EXISTS ( SELECT * FROM [CAU_TRUC_THIET_BI_PHU_TUNG] X WHERE  X.MS_MAY = A.MS_MAY AND  X.MS_BO_PHAN = A.MS_BO_PHAN " &
                                " AND  X.MS_PT = A.MS_PT) AND A.SO_LUONG > 0 AND A.MS_MAY = '" & dr("MS_MAY") & "' AND A.MS_BO_PHAN = '" & dr1("MS_BO_PHAN") & "'  AND A.MS_CV = " & dr1("MS_CV")
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
                Next


                Dim dtTmp2 As New DataTable()
                dtTmp2.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTT_CONG_VIEC", dr("HANG_MUC_ID"), 0))
                If dtTmp2.Rows.Count = 0 Then
                    tran.Commit()
                    tran = con.BeginTransaction()
                    Continue For
                End If

                sBT = "(select * from KE_HOACH_TONG_CONG_VIEC where HANG_MUC_ID =" & dr("HANG_MUC_ID") & " and THUE_NGOAI=0 AND MS_PHIEU_BAO_TRI IS NULL AND KHONG_GQ = 0)"
                Try
                    NGAY_BTPN = dr("NGAY_BTPN")
                Catch ex As Exception
                    NGAY_BTPN = "01/01/1900"
                End Try

                Try
                    If dtselect.Rows.Count = 1 Then
                        NGAY_BD_KH = frm.datNgayBDKH.DateTime
                    Else
                        NGAY_BD_KH = dr("NGAY")
                    End If

                Catch ex As Exception
                    NGAY_BD_KH = "01/01/1900"
                End Try

                Try
                    If dtselect.Rows.Count = 1 Then
                        NGAY_KT_KH = frm.datNgayKTKH.DateTime
                    Else
                        NGAY_KT_KH = dr("NGAY_DK_HT")
                    End If
                Catch ex As Exception
                    NGAY_KT_KH = "01/01/1900"
                End Try

                MS_PBT = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(NGAY_BD_KH.Year, NGAY_BD_KH.Month)
                sNLap = frm.sNLap
                sNGSat = frm.sNGSat
                Try
                    iLBT = dr("MS_LOAI_BT")
                Catch ex As Exception
                    iLBT = frm.iLoaiBT
                End Try

                If iLBT = -1 Then
                    Commons.MssBox.Show(Me.Name, "ChuaChonLBT")
                    Exit Sub
                End If
                If sNLap = "" Then
                    Commons.MssBox.Show(Me.Name, "ChuaChonNLap")
                    Exit Sub
                End If
                If sNGSat = "" Then
                    Commons.MssBox.Show(Me.Name, "ChuaChonNGSat")
                    Exit Sub
                End If

                Dim MUC_UU_TIEN As String = "-1"
                Try
                    MUC_UU_TIEN = If(String.IsNullOrEmpty(dr("MS_UU_TIEN").ToString()), -1, dr("MS_UU_TIEN"))
                Catch ex As Exception
                    MUC_UU_TIEN = "-1"
                End Try

                'Add Phieu Bao Tri
                SqlHelper.ExecuteNonQuery(tran, "AddPHIEU_BAO_TRI", MS_PBT, dr("MS_MAY"),
                iLBT, DateValue(Now), strGioTam.ToString, dr("TEN_HANG_MUC"), 1,
                IIf(NGAY_BTPN = "01/01/1900", Nothing, NGAY_BTPN), sNLap, Commons.Modules.UserName,
                IIf(NGAY_BD_KH = "01/01/1900", Nothing, NGAY_BD_KH),
                IIf(NGAY_KT_KH = "01/01/1900", Nothing, NGAY_KT_KH), sNGSat, Convert.ToInt32(MUC_UU_TIEN))


                If Commons.Modules.iDefault Then
                    sSql = "UPDATE PHIEU_BAO_TRI SET SO_PHIEU_BAO_TRI = MS_PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI = '" & MS_PBT & "'"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
                End If
                Try
                    Dim str1 As String = "UPDATE PHIEU_BAO_TRI SET UPDATE_NGAY_CUOI = '" & If(NGAY_BD_KH = "01/01/1900", Nothing, NGAY_BD_KH.ToString("yyy/MM/dd")) & "' WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, str1)

                    str1 = "UPDATE PHIEU_BAO_TRI SET NGAY_BTDK_GOC = '" & Format(NGAY_BD_KH, "MM/dd/yyyy") & "' WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, str1)
                Catch ex As Exception

                End Try
                'Add cong viec
                If Commons.Modules.iMacDinhCVPT = 0 Or Commons.Modules.iMacDinhCVPT = 1 Then
                    sSql = " INSERT PHIEU_BAO_TRI_CONG_VIEC (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, SO_GIO_KH, " &
                            " SO_NGUOI,YEU_CAU_NS,YEU_CAU_DUNG_CU,HANG_MUC_ID, GHI_CHU,THAO_TAC,TIEU_CHUAN_KT,PATH_HD) " &
                            " SELECT DISTINCT '" & MS_PBT & "', A.MS_CV, A.MS_BO_PHAN, A.THOI_GIAN_DU_KIEN, " &
                            " A.SNGUOI, A.YCAU_NS, A.YCAU_DC, A.HANG_MUC_ID, A.GHI_CHU, B.THAO_TAC, B.TIEU_CHUAN_KT,B.PATH_HD " &
                            " FROM " & sBT & " AS A INNER JOIN " &
                            " dbo.CONG_VIEC AS B ON A.MS_CV = B.MS_CV " &
                            " WHERE (ISNULL(A.MS_PHIEU_BAO_TRI, N'') = '') AND (A.KHONG_GQ = 0)  "

                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
                End If

                If Commons.Modules.iMacDinhCVPT = 0 Then
                    'Add cong viec phu tung
                    sSql = "INSERT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH) " &
                                "SELECT '" & MS_PBT & "', MS_CV, MS_BO_PHAN, MS_PT, SO_LUONG FROM dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG A " &
                                " WHERE (MS_MAY = N'" & dr("MS_MAY") & "') " &
                                " AND (HANG_MUC_ID = " & dr("HANG_MUC_ID") & ")" &
                                " AND EXISTS ( SELECT * FROM " & sBT & " B WHERE A.MS_CV = B.MS_CV  AND A.MS_BO_PHAN = B.MS_BO_PHAN AND B.KHONG_GQ = 0) AND SO_LUONG > 0 "
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)

                End If
                If Commons.Modules.iMacDinhCVPT = 0 Or Commons.Modules.iMacDinhCVPT = 1 Then
                    ' Update vao KE_HOACH_TONG_CONG_VIEC 
                    sSql = " UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI = N'" & MS_PBT & "' FROM KE_HOACH_TONG_CONG_VIEC A " &
                                " WHERE (MS_MAY = N'" & dr("MS_MAY") & "') " &
                                " AND (HANG_MUC_ID = " & dr("HANG_MUC_ID") & ")" &
                                " AND EXISTS ( SELECT * FROM " & sBT & " B WHERE A.MS_CV = B.MS_CV  AND A.MS_BO_PHAN = B.MS_BO_PHAN ) "
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
                End If

                If Commons.Modules.iMacDinhCVPT = 0 Then
                    Try
                        SqlHelper.ExecuteNonQuery(tran, "InsertPhuTungLoaiMayPCV", MS_PBT)
                    Catch ex As Exception
                    End Try

                    ' cap nhap vi tri
                    Commons.Modules.SQLString = "SELECT  T.MS_PHIEU_BAO_TRI, T.MS_CV,  T.MS_BO_PHAN, T.MS_PT,  T.SL_KH, T1.MS_VI_TRI_PT " &
                                                " INTO " & sBTPTCT & " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T " &
                                                " INNER JOIN CAU_TRUC_THIET_BI_PHU_TUNG T1 On T.MS_PT = T1.MS_PT And T.MS_BO_PHAN = T1.MS_BO_PHAN And T1.MS_MAY = '" & dr("MS_MAY") & "'" &
                                                " WHERE T.MS_PHIEU_BAO_TRI ='" & MS_PBT & "' And (EXISTS(SELECT * FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE  MS_MAY = '" & dr("MS_MAY") & "' AND MS_BO_PHAN = T.MS_BO_PHAN))"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                    '----------------------------------------
                    Dim dtReaderTam As New DataTable
                    Dim dtReader1 As New DataTable

                    Dim iSL_BTPN As Integer = 0, iSL_CTTB As Integer = 0
                    Dim iSL_KH As Integer = 0

                    dtReader1.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM " & sBTPTCT))
                    For Each row As DataRow In dtReader1.Rows
                        'lay so luong can thuc hien cho phu tung trong lich bao tri dinh ky
                        Commons.Modules.SQLString = "SELECT ISNULL(SO_LUONG,0) AS SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & dr("MS_MAY") & "' AND MS_CV=" & row("MS_CV") & " AND MS_BO_PHAN='" & row("MS_BO_PHAN") & "' AND MS_PT='" & row("MS_PT") & "'"
                        dtReaderTam = New DataTable()
                        dtReaderTam.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))
                        If (dtReaderTam.Rows.Count > 0) Then
                            iSL_BTPN = dtReaderTam.Rows(0)("SO_LUONG")
                        End If
                        If (iSL_BTPN > 0) Then
                            'lay so luong tren tung vi tri cua phu tung trong cau truc thiet bi
                            Commons.Modules.SQLString = "SELECT MS_MAY,MS_BO_PHAN,MS_PT, SUM(SO_LUONG) AS SL_TAT_CA_VI_TRI FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & dr("MS_MAY") & "' AND MS_BO_PHAN='" & row("MS_BO_PHAN") & "' AND MS_PT='" & row("MS_PT") & "' GROUP BY MS_MAY,MS_BO_PHAN,MS_PT"

                            dtReaderTam = New DataTable()
                            dtReaderTam.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))
                            If (dtReaderTam.Rows.Count > 0) Then
                                iSL_CTTB = dtReaderTam.Rows(0)("SL_TAT_CA_VI_TRI")
                            End If

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE " & sBTPTCT & " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' AND MS_PT='" & row("MS_PT") & "'")

                            'tim so luong tren tung vi tri co bao nhieu do so luong ben btnpn sang cho hop le

                            dtReaderTam = New DataTable()
                            dtReaderTam.Load(SqlHelper.ExecuteReader(tran, CommandType.Text,
                                    "SELECT * FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE ACTIVE = 1 AND MS_MAY=N'" & dr("MS_MAY") &
                                    "' AND MS_BO_PHAN='" & row("MS_BO_PHAN") & "' AND MS_PT='" & row("MS_PT") & "'"))

                            For Each row1 As DataRow In dtReaderTam.Rows
                                iSL_KH = iSL_BTPN - row1("SO_LUONG")
                                If iSL_KH <= 0 Then
                                    iSL_KH = iSL_BTPN 'row1("SO_LUONG")
                                ElseIf iSL_KH > row1("SO_LUONG") Then
                                    iSL_KH = row1("SO_LUONG")
                                Else
                                    iSL_KH = row1("SO_LUONG")
                                End If
                                Dim sSql1 As String = " INSERT INTO " & sBTPTCT & " (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, SL_KH, MS_VI_TRI_PT) VALUES('" & MS_PBT & "'," & row("MS_CV") & ",'" & row("MS_BO_PHAN") & "','" & row("MS_PT") & "'," & iSL_KH & ",'" & row1("MS_VI_TRI_PT") & "')"
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql1)
                                iSL_BTPN -= row1("SO_LUONG")
                            Next
                        End If
                    Next

                    '--------------------------------------------
                    Dim dtTmp1 As New DataTable
                    Commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET " &
                            " (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, SL_KH, MS_VI_TRI_PT)" &
                            " SELECT DISTINCT * FROM " & sBTPTCT & " WHERE SL_KH>0"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)


                    '--------------------------------------------
                    'CAP NHAT LAI SO LUONG CHO  BANG CHA
                    Commons.Modules.SQLString = "SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SUM(SL_KH) AS SL_TONG FROM " &
                            " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' " &
                            " GROUP BY MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT"
                    dtTmp = New DataTable
                    dtTmp.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))
                    For Each dr2 As DataRow In dtTmp.Rows
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH=" & dr2("SL_TONG") &
                            " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' AND MS_CV=" & dr2("MS_CV") &
                            " AND MS_BO_PHAN='" & dr2("MS_BO_PHAN") & "' AND MS_PT='" & dr2("MS_PT") & "'")
                    Next
                End If

                'update vao Yeu cau su dung chi tiet voi hang muc ID va MSPBT
                Commons.Modules.SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT = '" & MS_PBT & "' " &
                        " WHERE HANG_MUC_ID_KE_HOACH = " & dr("HANG_MUC_ID") & " AND MS_CACH_TH = '01' AND ISNULL(MS_PBT,'') = ''"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                'update vao Giam sat tinh trang voi hang muc ID va MSPBT
                Commons.Modules.SQLString = " UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_CACH_TH = '04' , MS_PBT = '" & MS_PBT & "' " &
                                    " WHERE STT_VAN_DE IN (SELECT STT_VAN_DE FROM YEU_CAU_NSD_CHI_TIET WHERE HANG_MUC_ID_KE_HOACH = " & dr("HANG_MUC_ID") & ")  " &
                                    " AND ISNULL(MS_PBT,'') = ''  AND ISNULL(MS_CACH_TH,'') <> '03'"
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                'tu dong cap nhap cong nhan voi dieu kien auto_cn = 1 trong thong tin chung
                Try
                    SqlHelper.ExecuteNonQuery(tran, "InsertCongNhanPBT", MS_PBT)
                Catch ex As Exception
                End Try
                tran.Commit()
                Commons.Modules.ObjSystems.XoaTable(sBTPTCT)
                Try
                    prbLapPhieuBaoTri.PerformStep()
                    prbLapPhieuBaoTri.Update()
                Catch

                End Try
                If (dtselect.Rows.Count > 1 And (dtselect.Rows.IndexOf(dr) < dtselect.Rows.Count - 1)) Then
                    tran = con.BeginTransaction()
                End If
            Next
            con.Close()
            Commons.MssBox.Show(Me.Name, "MsgQuyenKT23")
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongThanhCong", Commons.Modules.TypeLanguage) + vbCrLf + ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tran.Rollback()
            con.Close()
        End Try
        prbLapPhieuBaoTri.Visible = False
        TableLayoutPanel4.RowStyles.Item(TableLayoutPanel4.GetRow(prbLapPhieuBaoTri)).Height = 0
        prbLapPhieuBaoTri.Position = 0
        BindData_Tab()
        'Commons.Modules.ObjSystems.XoaTable(sBT)
        Commons.Modules.ObjSystems.XoaTable(sBTPTCT)
    End Sub



    Private Sub BtnBoChonTatCa1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoChonTatCa1.Click
        Dim i As Integer
        While i < gvKHTT.RowCount
            gvKHTT.GetDataRow(i)("Choose") = False
            i = i + 1
        End While
        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
            dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
            CalularDataSelected(dataHangMucSelected)
        End If
    End Sub



    Private Sub txtTKiemBTDK_EditValueChanging(sender As Object, e As Controls.ChangingEventArgs) Handles txtTKiemBTDK.EditValueChanging
        TimKiemMay(gdBTDK, txtTKiemBTDK.Text)
    End Sub

    Private Sub txtTKiemBTDKGio_EditValueChanging(sender As Object, e As Controls.ChangingEventArgs) Handles txtTKiemBTDKGio.EditValueChanging
        TimKiemMay(gdBTDK_Gio, txtTKiemBTDKGio.Text)
    End Sub

    Private Sub btnNotAllBTDKTheoGio_Click(sender As Object, e As EventArgs) Handles btnNotAllBTDKTheoGio.Click
        Dim i As Integer
        While i < gvBTDK_Gio.RowCount
            gvBTDK_Gio.GetDataRow(i)("CHON") = True
            i = i + 1
        End While
    End Sub
    Private Sub btnAllBTDKTheoGio_Click(sender As Object, e As EventArgs) Handles btnAllBTDKTheoGio.Click
        Dim i As Integer
        While i < gvBTDK_Gio.RowCount
            gvBTDK_Gio.GetDataRow(i)("CHON") = True
            i = i + 1
        End While
    End Sub
    Private Sub btnCapNhatMUT_Click(sender As Object, e As EventArgs) Handles btnCapNhatMUT.Click
        Try
            If gdKHTT.DataSource Is Nothing Then Exit Sub
            If gvKHTT.RowCount < 1 Then Exit Sub
            Dim _ms_hang_muc As Integer = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
            Dim _datarow() As DataRow = dtTable_KHTT_TEMP.Select("HANG_MUC_ID='" & _ms_hang_muc & "'")
            Dim dtKHTT As DataTable = CType(gdKHTT.DataSource, DataTable)
            Dim drKHTT() As DataRow = dtKHTT.Select("HANG_MUC_ID='" & _ms_hang_muc & "'")
            Dim dr As DataRow
            Dim str1 As String = "SELECT ISNULL(SO_NGAY_PHAI_BD, 0) AS SO_NGAY_PHAI_BD ,  ISNULL(SO_NGAY_PHAI_KT, 0) AS SO_NGAY_PHAI_KT FROM MUC_UU_TIEN WHERE MS_UU_TIEN = " & gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str1))
            If (dt.Rows.Count > 0) Then
                If (_datarow.Length > 0) Then
                    _datarow(0)("NGAY") = Convert.ToDateTime(drKHTT(0)("NGAY")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
                    _datarow(0)("NGAY_DK_HT") = Convert.ToDateTime(drKHTT(0)("NGAY_DK_HT")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
                    _datarow(0)("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
                    drKHTT(0)("NGAY") = Convert.ToDateTime(gvKHTT.GetFocusedDataRow()("NGAY")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
                    drKHTT(0)("NGAY_DK_HT") = Convert.ToDateTime(gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
                    drKHTT(0)("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
                Else
                    drKHTT(0)("NGAY") = Convert.ToDateTime(gvKHTT.GetFocusedDataRow()("NGAY")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
                    drKHTT(0)("NGAY_DK_HT") = Convert.ToDateTime(gvKHTT.GetFocusedDataRow()("NGAY_DK_HT")).AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
                    drKHTT(0)("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
                    dr = dtTable_KHTT_TEMP.NewRow()
                    dr("MS_MAY") = gvKHTT.GetFocusedDataRow()("MS_MAY")
                    dr("HANG_MUC_ID") = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                    dr("TEN_HANG_MUC") = gvKHTT.GetFocusedDataRow()("TEN_HANG_MUC")
                    dr("NGAY") = drKHTT(0)("NGAY")
                    dr("NGAY_DK_HT") = drKHTT(0)("NGAY_DK_HT")
                    dr("GHI_CHU") = gvKHTT.GetFocusedDataRow()("GHI_CHU")
                    dr("LY_DO_SC") = gvKHTT.GetFocusedDataRow()("LY_DO_SC")
                    If gvKHTT.GetFocusedDataRow()("RecordAction").ToString().Equals("0") Then
                        gvKHTT.GetFocusedDataRow()("RecordAction") = 2
                    End If
                    dr("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
                    dr("MS_CONG_NHAN") = gvKHTT.GetFocusedDataRow()("MS_CONG_NHAN")
                    dr("RecordAction") = gvKHTT.GetFocusedDataRow()("RecordAction")
                    dtTable_KHTT_TEMP.Rows.Add(dr)
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonMucUuTien", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub gvTSGSTT_DoubleClick(sender As Object, e As EventArgs) Handles gvTSGSTT.DoubleClick
        If Commons.Modules.PermisString.Equals("Read only") Then Exit Sub
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        If view.RowCount = 0 Then Exit Sub

        DoRowDoubleClick(view, pt)
    End Sub
    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)

        If Commons.Modules.PermisString.Equals("Read only") Then Exit Sub
        If Not radChuaGiaiQuyet2.Checked Then
            btnHuy_Click(Nothing, Nothing)
            Exit Sub
        End If


        Dim frm As New frmChonThucHienGSTT
        gvTSGSTT.UpdateCurrentRow()
        Dim dtTmp As New DataTable
        dtTmp = CType(gdTSGSTT.DataSource, DataTable).Copy
        dtTmp.DefaultView.RowFilter = "CHON = 1"
        dtTmp = dtTmp.DefaultView.ToTable
        If dtTmp.Rows.Count < 1 Then
            If gvTSGSTT.GetFocusedRowCellValue("CHON") = 0 Then
                gvTSGSTT.SetFocusedRowCellValue("CHON", 1)
                gvTSGSTT.UpdateCurrentRow()
            End If
            dtTmp = New DataTable
            dtTmp = CType(gdTSGSTT.DataSource, DataTable).Copy
            dtTmp.DefaultView.RowFilter = "CHON = 1"
            dtTmp = dtTmp.DefaultView.ToTable
            If dtTmp.Rows.Count < 1 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgChuaChonGiamSatCanThucHien", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
        End If
        Dim distinctDT As DataTable = dtTmp.DefaultView.ToTable(True, "MS_MAY", "NGAY_GIO_KT_MAX")
        If distinctDT.Rows.Count > 1 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgCoTren2MayHayNgayKiemTra", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        frm.dtTSGSTT = dtTmp

        frm.drGSTT = gvTSGSTT.GetDataRow(gvTSGSTT.FocusedRowHandle)
        If frm.ShowDialog() = DialogResult.Cancel Then Exit Sub
        LoadDataTSGSTT()

    End Sub

    Private Sub txtTimGSTT_EditValueChanging(sender As Object, e As Controls.ChangingEventArgs) Handles txtTimGSTT.EditValueChanging
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(gdTSGSTT.DataSource, DataTable)
            Dim str As String = ""
            If txtTimGSTT.Text <> "" Then str = " MS_MAY like '%" + txtTimGSTT.Text + "%' OR TEN_MAY like '%" + txtTimGSTT.Text + "%' "
            dtTmp.DefaultView.RowFilter = str
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
        dtTmp = dtTmp.DefaultView.ToTable()
    End Sub

    Private Sub btnAllGSTT_Click(sender As Object, e As EventArgs) Handles btnAllGSTT.Click
        Try
            Dim i As Integer
            While i < gvTSGSTT.RowCount
                gvTSGSTT.GetDataRow(i)("CHON") = True
                i = i + 1
            End While

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNotAllGSTT_Click(sender As Object, e As EventArgs) Handles btnNotAllGSTT.Click
        Try

            Dim i As Integer
            While i < gvTSGSTT.RowCount
                gvTSGSTT.GetDataRow(i)("CHON") = False
                i = i + 1
            End While
        Catch ex As Exception

        End Try

    End Sub


    Private Sub cboLoaiThietBiBTDK_EditValueChanged(sender As Object, e As EventArgs) Handles cboLoaiThietBiBTDK.EditValueChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        If gdKHTT.DataSource Is Nothing Then Exit Sub
        Commons.Modules.SQLString = "LOADLMAY"
        LoadNhomMay()
        LoadMay()
        Commons.Modules.SQLString = ""
        BindData_Tab()

        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
            dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
            CalularDataSelected(dataHangMucSelected)
        End If
    End Sub

    Private Sub CboNhomThietBiBTDK_EditValueChanged(sender As Object, e As EventArgs) Handles CboNhomThietBiBTDK.EditValueChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        If gdKHTT.DataSource Is Nothing Then Exit Sub
        If Commons.Modules.SQLString = "LOADLMAY" Then Exit Sub

        Commons.Modules.SQLString = "LOADNMAY"
        LoadMay()
        Commons.Modules.SQLString = ""
        BindData_Tab()

        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
            dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
            CalularDataSelected(dataHangMucSelected)
        End If

    End Sub

    Private Sub CboMaSoThietBiBTDK_EditValueChanged(sender As Object, e As EventArgs) Handles CboMaSoThietBiBTDK.EditValueChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        If gdKHTT.DataSource Is Nothing Then Exit Sub
        If Commons.Modules.SQLString = "LOADLMAY" Then Exit Sub
        If Commons.Modules.SQLString = "LOADNMAY" Then Exit Sub

        BindData_Tab()

        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
            dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
            CalularDataSelected(dataHangMucSelected)
        End If

    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        gvTSGSTT.UpdateCurrentRow()
        If gvTSGSTT.RowCount = 0 Then Exit Sub


        Dim dtTmp As New DataTable
        dtTmp = CType(gdTSGSTT.DataSource, DataTable).Copy()
        dtTmp.DefaultView.RowFilter = " CHON = 1 "
        dtTmp = dtTmp.DefaultView.ToTable()

        If dtTmp.Rows.Count = 0 Then
            'XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
            '            "msgChuaChonGiamSatCanThucHien", Commons.Modules.TypeLanguage))
            'Return
            gvTSGSTT.SetFocusedRowCellValue("CHON", 1)
            gvTSGSTT.UpdateCurrentRow()
            dtTmp = New DataTable
            dtTmp = CType(gdTSGSTT.DataSource, DataTable).Copy()
            dtTmp.DefaultView.RowFilter = " CHON = 1 "
            dtTmp = dtTmp.DefaultView.ToTable()
        End If

        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgHuyVeChuaGiaQuyet", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "TSGSTT" & Commons.Modules.UserName, dtTmp, "")

        Dim str As String = " UPDATE GIAM_SAT_TINH_TRANG_TS_DT
                              SET 
                                 MS_CACH_TH = NULL,
                                 USERNAME = NULL,
                                 TG_XU_LY = NULL,
                                 MS_PBT = NULL,
                                 HANG_MUC_ID_KE_HOACH = NULL,
                                 MS_CONG_NHAN = NULL
                              FROM GIAM_SAT_TINH_TRANG_TS_DT T INNER JOIN " & "TSGSTT" & Commons.Modules.UserName & " T1 ON T1.STT = T.STT AND T1.MS_MAY = T.MS_MAY AND T.MS_TS_GSTT = T1.MS_TS_GSTT AND T.MS_TT = T1.MS_TT AND T1.STT_GT = T.STT_GT AND T1.MS_BO_PHAN = T.MS_BO_PHAN
                  
                  UPDATE GIAM_SAT_TINH_TRANG_TS
                  SET 
                        MS_CACH_TH = NULL,
                        USERNAME = NULL,
                        TG_XU_LY = NULL,
                        MS_PBT = NULL,
                        HANG_MUC_ID_KE_HOACH = NULL,
                        MS_CONG_NHAN = NULL
                        FROM GIAM_SAT_TINH_TRANG_TS T INNER JOIN " & "TSGSTT" & Commons.Modules.UserName & " T1 ON 
                        T1.STT = T.STT AND T1.MS_MAY = T.MS_MAY AND T.MS_TS_GSTT = T1.MS_TS_GSTT AND 
                        T.MS_TT = T1.MS_TT AND T1.MS_BO_PHAN = T.MS_BO_PHAN "
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Commons.Modules.ObjSystems.XoaTable("TSGSTT" & Commons.Modules.UserName)
        LoadDataTSGSTT()
    End Sub

    Private Sub dtpTNKHTT_EditValueChanged(sender As Object, e As EventArgs) Handles dtpTNKHTT.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        If dtpTNKHTT.DateTime.Date > dtpDNKHTT.DateTime.Date Then
            Commons.MssBox.Show(Me.Name, "MsgQuyenKT37")
        Else
            LoadData()

            If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
                dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
                CalularDataSelected(dataHangMucSelected)
            End If
        End If
    End Sub

    Private Sub dtpDNKHTT_EditValueChanged(sender As Object, e As EventArgs) Handles dtpDNKHTT.EditValueChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If dtpDNKHTT.DateTime.Date < dtpTNKHTT.DateTime.Date Then
            Commons.MssBox.Show(Me.Name, "MsgQuyenKT38")
        Else
            LoadData()
            If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
                dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
                CalularDataSelected(dataHangMucSelected)
            End If
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If BtnGhi1.Visible = False Then

            If gvKHTT.RowCount <= 0 Then
                Commons.MssBox.Show(Me.Name, "MsgQuyenKT14")
                Exit Sub
            End If

            Commons.Modules.SQLString = "SELECT TOP 1 MS_PHIEU_BAO_TRI FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND (MS_PHIEU_BAO_TRI IS NOT NULL OR EOR_ID IS NOT NULL)"
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                    "MsgQuyenKT36", Commons.Modules.TypeLanguage) + " - " + dtReader.Item("MS_PHIEU_BAO_TRI"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtReader.Close()
                Exit Sub
            End While
            dtReader.Close()
            Dim tran As SqlTransaction
            Dim con As New SqlConnection(Commons.IConnections.ConnectionString)

            If gvCVTT.RowCount > 0 Then
                If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgKHDangTonTaiCongViec", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                tran = con.BeginTransaction()
                Try
                    Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE  HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                    Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                    Try
                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED,0) DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED)"
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                    Catch ex As Exception
                        Commons.MssBox.Show(Me.Name, "MsgQuyenKT19")
                        Exit Sub
                    End Try
                Catch ex As Exception
                    tran.Rollback()
                    con.Close()
                End Try
                tran.Commit()
                con.Close()
                LoadData()
            Else
                If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT17", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                tran = con.BeginTransaction()
                Try
                    Commons.Modules.SQLString = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_CACH_TH=N'03',HANG_MUC_ID_KE_HOACH=NULL WHERE  HANG_MUC_ID_KE_HOACH=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND  ISNULL(MS_PBT,'') ='' "
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                    Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED,0) DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED)"
                    SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                    tran.Commit()
                    con.Close()
                    LoadData()
                Catch ex As Exception
                    Commons.MssBox.Show(Me.Name, "MsgQuyenKT19")
                    tran.Rollback()
                    con.Close()
                    Exit Sub
                End Try
            End If
        End If


    End Sub

    Private Sub gvBTDK_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvBTDK.CellValueChanged
        If (e.Column.FieldName = "chkChon") Then
            gvBTDK.UpdateCurrentRow()
            Dim dt As New DataTable
            dt = CType(gdBTDK.DataSource, DataTable).Copy()
            dt.DefaultView.RowFilter = "chkChon = true"
            lblChon.Text = Chon & ": " & dt.DefaultView.ToTable().Rows.Count.ToString()
        End If
    End Sub

    Private Sub cboDiaDiem_1_EditValuedChanged(sender As Object, e As ucComboboxTreeList.EventArgs) Handles cboDiaDiem_1.EditValuedChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        If gdKHTT.DataSource Is Nothing Then Exit Sub
        BindData_Tab()
    End Sub

    Private Sub radChuaGiaiQuyet2_CheckedChanged(sender As Object, e As EventArgs) Handles radChuaGiaiQuyet2.CheckedChanged

    End Sub

    Private Sub TimKiemMay(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal sTK As String)
        Dim dtTmp As New DataTable
        Try
            dtTmp = CType(grd.DataSource, DataTable)
            Dim str As String = ""
            If sTK <> "" Then str = " MS_MAY like '%" + sTK + "%' OR TEN_MAY like '%" + sTK + "%' "
            dtTmp.DefaultView.RowFilter = str
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
        End Try
        dtTmp = dtTmp.DefaultView.ToTable()
    End Sub

    Private Delegate Sub setDataGridInvoker(ByVal grd As DevExpress.XtraGrid.GridControl)

    Private Sub setDataGrid(ByVal grd As DevExpress.XtraGrid.GridControl)
        Try
            If grd.InvokeRequired Then
                grd.Invoke(New setDataGridInvoker(AddressOf setDataGrid), grd)
            Else
                Dim View As GridView = grd.MainView
                Dim i As Integer
                While i < View.RowCount
                    View.GetDataRow(i)("Choose") = True
                    i = i + 1
                End While
                'If monitorCheckAll = False Then
                '    Try
                '        dataHangMucSelected.Clear()
                '        dataHangMucSelected = CType(grd.DataSource, DataTable).Copy()
                '    Catch ex As Exception
                '    End Try
                'End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
        If DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible Then
            dataHangMucSelected.Clear()
            dataHangMucSelected = CType(gdKHTT.DataSource, DataTable).Copy()
            CalularDataSelected(dataHangMucSelected)
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        loadPhuTungToGrid()
    End Sub
    Private Sub loadPhuTungToGrid()
        setDataGrid(gdKHTT)
        Threading.Thread.Sleep(500)
    End Sub
    Private Sub BtnChonTatCa1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonTatCa1.Click
        Try
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
        End Try

    End Sub

End Class