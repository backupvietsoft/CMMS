Imports Commons.VS.Classes.Admin
Imports Commons.VS.Classes.Catalogue
Imports Microsoft.ApplicationBlocks.Data

Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.DateAndTime
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports Commons
Imports DevExpress.XtraEditors

Public Class frmKehoachtongtheNew
    Private bHienthi As Integer

    Private objLichBTPN As New clsLichBTPN
    Private dtReader As SqlDataReader
    Private intTabInd As Integer = -1, rowCount As Integer, ind As Integer = -1, rowCount1 As Integer, rowCount2 As Integer
    Private tmp_cv As Integer = -1, tmp_pt As Integer = -1
    Private blnThemSua As Boolean = False
    Private SqlText As String
    Private noDataToPrint As Boolean = True
    Private indOldPos As Integer = -1, indNewPos As Integer = -1
    Private arrStr As String = ""
    Private str() As String
    Private intRowYeuCauNSD As Integer = -1
    Private count As Integer = 0
    Private isFirst As Boolean = False
    'Private repositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private repositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Private repositoryItemLookUpEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private repositoryItemLookUpEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private lookeditMucUTHM As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit


    Private dtTable_CV As New DataTable
    Private dtTable_CV_TEMP As New DataTable
    Private dtTable_PT As New DataTable

    Private _temp As New DataTable
    Private dtTable_KHTT_TEMP As New DataTable
    Private dtTable_KHTT As New DataTable
    Dim j As Integer = 0
    Dim success As Boolean = True

    'Dim _DataHangMucNew As New DataTable

    'Private Sub InitDataHangMucNew()
    '    _DataHangMucNew = New DataTable
    '    _DataHangMucNew.Columns.Add("HANG_MUC_ID", Type.GetType("System.Int32"))
    '    _DataHangMucNew.Columns.Add("HANG_MUC_ID_ADD_NEW", Type.GetType("System.Int32"))

    'End Sub

#Region "DuLieu"
    Private DuyetNam As Boolean = False
    Private DuyetThang As Boolean = False
    Private KHType As String = "1"
#End Region

#Region "khoi tao"
    Private Sub LoadKHType()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("1", "Kế hoạch năm")
        _vtb.Rows.Add("2", "Kế hoạch tháng")
        cbKHType.DataSource = _vtb
        cbKHType.DisplayMember = "Name"
        cbKHType.ValueMember = "Code"

        KHType = "1"
        tbPanelKHNam.Visible = True
        tbPanelKHThang.Visible = False

        AddHandler cbKHType.SelectedValueChanged, AddressOf Me.cbKHType_SelectedValueChanged
    End Sub
    Private Sub loadKHbyType()
        If cbKHType.SelectedValue.ToString() = "1" Then 'ke hoach nam
            tbPanelKHNam.Visible = True
            tbPanelKHThang.Visible = False
            KHType = "1"
            cbKHNNam.Enabled = True

            'btnKHNLayBTDK.Enabled = True
            'btnKHNChuyen.Enabled = True
            'btnKHTLayKHNam.Enabled = False
            'btnKHTLayBTDK.Enabled = False
            'btnKHTChuyen.Enabled = False
            'btnKHTChuyenCV.Enabled = False

            btnLPBT.Visible = False
            mbtnKHT_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_Thang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_CV.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_CV_TU_NAM.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnChuyenCVDangDo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            mbtnKHN_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHN_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            mbtnCopyNam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnuCopyThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        ElseIf cbKHType.SelectedValue.ToString = "2" Then 'ke hoach thang
            tbPanelKHNam.Visible = False
            tbPanelKHThang.Visible = True
            KHType = "2"
            cbKHTNam.Enabled = True
            cbKHTThang.Enabled = True
            btnLPBT.Visible = True

            mbtnKHT_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_Thang.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_CV.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_CV_TU_NAM.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnChuyenCVDangDo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            mbtnKHN_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHN_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never


            mbtnCopyNam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mnuCopyThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        End If
    End Sub
    Private Sub LoadNamData()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("2013", "2013")
        _vtb.Rows.Add("2014", "2014")
        _vtb.Rows.Add("2015", "2015")
        _vtb.Rows.Add("2016", "2016")
        _vtb.Rows.Add("2017", "2017")
        _vtb.Rows.Add("2018", "2018")
        _vtb.Rows.Add("2019", "2019")
        _vtb.Rows.Add("2020", "2020")
        cbKHTNam.DataSource = _vtb.Copy()
        cbKHTNam.DisplayMember = "Name"
        cbKHTNam.ValueMember = "Code"

        cbKHTNam.SelectedValue = DateTime.Now.ToString("yyyy", Globalization.CultureInfo.CurrentCulture)

        cbKHNNam.DataSource = _vtb.Copy()
        cbKHNNam.DisplayMember = "Name"
        cbKHNNam.ValueMember = "Code"

        cbKHNNam.SelectedValue = DateTime.Now.ToString("yyyy", Globalization.CultureInfo.CurrentCulture)

    End Sub
    Private Sub LoadThangData()
        Dim _vtb As New DataTable()
        _vtb.Columns.Add("Code", Type.GetType("System.String"))
        _vtb.Columns.Add("Name", Type.GetType("System.String"))
        _vtb.Rows.Add("01", "01")
        _vtb.Rows.Add("02", "02")
        _vtb.Rows.Add("03", "03")
        _vtb.Rows.Add("04", "04")
        _vtb.Rows.Add("05", "05")
        _vtb.Rows.Add("06", "06")
        _vtb.Rows.Add("07", "07")
        _vtb.Rows.Add("08", "08")
        _vtb.Rows.Add("09", "09")
        _vtb.Rows.Add("10", "10")
        _vtb.Rows.Add("11", "11")
        _vtb.Rows.Add("12", "12")
        cbKHTThang.DataSource = _vtb
        cbKHTThang.DisplayMember = "Name"
        cbKHTThang.ValueMember = "Code"
        cbKHTThang.SelectedValue = DateTime.Now.ToString("MM", Globalization.CultureInfo.CurrentCulture)
    End Sub

#End Region

#Region "Điều khiển form"
    Public Sub DKLoadForm()

        cbKHType.Enabled = True
        DropDownButton1.Enabled = True
        btnDuyet.Enabled = True
        If KHType = "1" Then

            tbPanelKHNam.Visible = True
            cbKHNNam.Enabled = True
            btnLPBT.Visible = False
            tbPanelKHThang.Visible = False

            mbtnKHT_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_Thang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_CV.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHT_GET_CV_TU_NAM.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            mbtnKHN_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHN_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            mbtnCopyNam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnuCopyThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        ElseIf KHType = "2" Then

            tbPanelKHNam.Visible = False

            tbPanelKHThang.Visible = True
            cbKHTNam.Enabled = True
            cbKHTThang.Enabled = True
            btnLPBT.Visible = True
            mbtnKHT_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_Thang.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_CV.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mbtnKHT_GET_CV_TU_NAM.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            mbtnKHN_GET_BTDK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mbtnKHN_GET_Nam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            mbtnCopyNam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mnuCopyThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

    End Sub
    Private Sub DKLoadFormThem()

        cbKHType.Enabled = False
        DropDownButton1.Enabled = False
        btnDuyet.Enabled = False
        If KHType = "1" Then
            'btnKHNLayBTDK.Enabled = False
            'btnKHNChuyen.Enabled = False
            'btnKHTChuyenCV.Enabled = Fals
            'btnKHTLayKHNam.Enabled = False
            'btnKHTLayBTDK.Enabled = False
            'btnKHTChuyen.Enabled = False
            cbKHNNam.Enabled = False


        ElseIf KHType = "2" Then
            cbKHTNam.Enabled = False
            cbKHTThang.Enabled = False

            'btnKHNLayBTDK.Enabled = False
            'btnKHNChuyen.Enabled = False
            'btnKHTLayKHNam.Enabled = False
            'btnKHTLayBTDK.Enabled = False
            'btnKHTChuyen.Enabled = False
            'btnKHTChuyenCV.Enabled = False
        End If





        'cbKHType.Enabled = False
        'If KHType = "1" Then
        '    btnKHNLayBTDK.Enabled = True
        '    btnKHNChuyen.Enabled = True
        '    cbKHNNam.Enabled = False
        'ElseIf KHType = "2" Then
        '    btnKHTLayKHNam.Enabled = True
        '    btnKHTLayBTDK.Enabled = True
        '    btnKHTChuyen.Enabled = True
        '    cbKHTNam.Enabled = False
        '    cbKHTThang.Enabled = False
        'End If

    End Sub
#End Region

    Private Sub cbKHType_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        loadKHbyType()
    End Sub



    Private Sub PrepareData()
        'LoadMayGrid()
        Dim _tblMay As New DataTable
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLY_DO_SUA_CHUA", Commons.Modules.TypeLanguage))
        repositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit2.NullText = ""
        repositoryItemLookUpEdit2.ValueMember = "MS_LY_DO"
        repositoryItemLookUpEdit2.DisplayMember = "TEN_LY_DO"
        repositoryItemLookUpEdit2.DataSource = _tblMay
        repositoryItemLookUpEdit2.Columns.Clear()
        repositoryItemLookUpEdit2.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LY_DO"))

        repositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        repositoryItemDateEdit1.EditMask = "dd/MM/yyyy"
        repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy"
        repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy"
        repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy"
        repositoryItemDateEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

        _tblMay = New DataTable()
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))
        repositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit3.NullText = ""
        repositoryItemLookUpEdit3.ValueMember = "MS_UU_TIEN"
        repositoryItemLookUpEdit3.DisplayMember = "TEN_UU_TIEN"
        repositoryItemLookUpEdit3.DataSource = _tblMay
        repositoryItemLookUpEdit3.Columns.Clear()
        repositoryItemLookUpEdit3.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_UU_TIEN"))


        _tblMay = New DataTable()
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))
        lookeditMucUTHM = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        lookeditMucUTHM.NullText = ""
        lookeditMucUTHM.ValueMember = "MS_UU_TIEN"
        lookeditMucUTHM.DisplayMember = "TEN_UU_TIEN"
        lookeditMucUTHM.DataSource = _tblMay.Copy
        lookeditMucUTHM.Columns.Clear()
        lookeditMucUTHM.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_UU_TIEN"))

        '

        _tblMay = New DataTable()
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCACH_THUC_HIEN", Commons.Modules.TypeLanguage))
        repositoryItemLookUpEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit4.NullText = ""
        repositoryItemLookUpEdit4.ValueMember = "MS_CACH_TH"
        repositoryItemLookUpEdit4.DisplayMember = "TEN_CACH_TH"
        repositoryItemLookUpEdit4.DataSource = _tblMay
        repositoryItemLookUpEdit4.Columns.Clear()
        repositoryItemLookUpEdit4.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_CACH_TH"))

        _tblMay = New DataTable()
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPBT_CHUA_HT"))
        repositoryItemLookUpEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit5.NullText = ""
        repositoryItemLookUpEdit5.ValueMember = "MS_PHIEU_BAO_TRI"
        repositoryItemLookUpEdit5.DisplayMember = "MS_PHIEU_BAO_TRI"
        repositoryItemLookUpEdit5.DataSource = _tblMay
        repositoryItemLookUpEdit5.Columns.Clear()
        repositoryItemLookUpEdit5.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_PHIEU_BAO_TRI"))

        _tblMay = New DataTable()
        _tblMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs"))
        repositoryItemLookUpEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        repositoryItemLookUpEdit6.NullText = ""
        repositoryItemLookUpEdit6.ValueMember = "MS_CONG_NHAN"
        repositoryItemLookUpEdit6.DisplayMember = "HO_TEN_CONG_NHAN"
        repositoryItemLookUpEdit6.DataSource = _tblMay
        repositoryItemLookUpEdit6.Columns.Clear()
        repositoryItemLookUpEdit6.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HO_TEN_CONG_NHAN"))

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

    Private Sub frmKehoachtongthe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bHienthi = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 ISNULL(HIEN_THI_YCBT,0) FROM THONG_TIN_CHUNG"))
        Catch ex As Exception
            bHienthi = 0
        End Try

        LoadKHType()
        LoadNamData()
        LoadThangData()

        LoadCity()
        LoadcboDiadiem()
        LoadLoaiMay()
        LoadNhomMay()
        LoadMay()
        PrepareData()
        HideButton(False)
        LoadNguoiLap()
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

        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Try

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvCVTT.Columns
                Select Case col.FieldName
                    Case "MS_UU_TIEN"
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboMucUuTien", Commons.Modules.TypeLanguage)
                    Case Else
                        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
                End Select
            Next
        Catch ex As Exception




        End Try
        Try
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvVTTT.Columns
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
            Next
        Catch ex As Exception

        End Try

        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
        End If
        'set ngon ngu

        mnuOpt1.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mnuOpt1", Commons.Modules.TypeLanguage)
        mnuOpt2.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mnuOpt2", Commons.Modules.TypeLanguage)
        mnuOpt3.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mnuOpt3", Commons.Modules.TypeLanguage)

        mbtnKHN_GET_Nam.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mbtnKHN_GET_Nam", Commons.Modules.TypeLanguage)
        mbtnKHN_GET_BTDK.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mbtnKHN_GET_BTDK", Commons.Modules.TypeLanguage)

        mbtnKHT_GET_Nam.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mbtnKHT_GET_Nam", Commons.Modules.TypeLanguage)
        mbtnKHT_GET_BTDK.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mbtnKHT_GET_BTDK", Commons.Modules.TypeLanguage)
        mbtnKHT_GET_CV.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mbtnKHT_GET_CV", Commons.Modules.TypeLanguage)
        mbtnKHT_GET_Thang.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mbtnKHT_GET_Thang", Commons.Modules.TypeLanguage)

        mbtnCopyNam.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mbtnCopyNam", Commons.Modules.TypeLanguage)
        mnuCopyThang.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "mnuCopyThang", Commons.Modules.TypeLanguage)

        DKLoadForm()
        AddHandler cbKHType.SelectedValueChanged, AddressOf Me.cbKHType_SelectedValueChanged_1
        AddHandler cbKHNNam.SelectedValueChanged, AddressOf Me.cbKHNNam_SelectedValueChanged_1
        AddHandler cbKHTNam.SelectedValueChanged, AddressOf Me.cbKHTNam_SelectedValueChanged_1
        AddHandler cbKHTThang.SelectedValueChanged, AddressOf Me.cbKHTThang_SelectedValueChanged_1
        EnalbeGrid(False)


    End Sub
    Sub EnableButton(ByVal chon As Boolean)

    End Sub

    Sub LoadNguoiLap()


    End Sub

    Sub LoadMay()
        Try
            CboMaSoThietBiBTDK.DataSource = Nothing
            Dim ms_loai_may As String = "-1"
            Dim ms_nhom_may As String = "-1"
            If cboLoaiThietBiBTDK.SelectedValue Is Nothing Then
            Else
                ms_loai_may = cboLoaiThietBiBTDK.SelectedValue.ToString()
            End If
            If CboNhomThietBiBTDK.SelectedValue Is Nothing Then
            Else
                ms_nhom_may = CboNhomThietBiBTDK.SelectedValue.ToString()
            End If

            Dim str As String = ""
            str = "SELECT DISTINCT dbo.MAY.MS_MAY, dbo.MAY.MS_MAY AS TEN_MAY " & _
                        " FROM dbo.NHOM_MAY INNER JOIN dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN " & _
                        " dbo.NHOM INNER JOIN dbo.NHOM_LOAI_MAY ON dbo.NHOM.GROUP_ID = dbo.NHOM_LOAI_MAY.GROUP_ID INNER JOIN " & _
                        " dbo.USERS ON dbo.NHOM.GROUP_ID = dbo.USERS.GROUP_ID ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY " & _
                        " WHERE     (dbo.USERS.USERNAME = N'" & Commons.Modules.UserName & "') "
            If ms_loai_may <> "-1" Then
                str = str & " AND (dbo.NHOM_MAY.MS_LOAI_MAY = N'" & ms_loai_may & "') "
            End If
            If ms_nhom_may <> "-1" Then
                str = str & " AND (dbo.MAY.MS_NHOM_MAY = N'" & ms_nhom_may & "')"
            End If
            CboMaSoThietBiBTDK.Value = "MS_MAY"
            CboMaSoThietBiBTDK.Display = "TEN_MAY"
            CboMaSoThietBiBTDK.StoreName = "QL_SEARCH"
            CboMaSoThietBiBTDK.Param = str
            CboMaSoThietBiBTDK.DropDownWidth = 150
            CboMaSoThietBiBTDK.BindDataSource()
        Catch ex As Exception

        End Try
    End Sub

    Sub LoadLoaiMay()
        CboNhomThietBiBTDK.DataSource = Nothing
        CboMaSoThietBiBTDK.DataSource = Nothing
        cboLoaiThietBiBTDK.DataSource = Nothing
        Dim str As String = ""
        str = " SELECT DISTINCT LOAI_MAY.MS_LOAI_MAY, LOAI_MAY.TEN_LOAI_MAY FROM  LOAI_MAY INNER JOIN " & _
            " NHOM_LOAI_MAY ON LOAI_MAY.MS_LOAI_MAY = NHOM_LOAI_MAY.MS_LOAI_MAY INNER JOIN " & _
            " NHOM ON NHOM_LOAI_MAY.GROUP_ID = NHOM.GROUP_ID  INNER JOIN " & _
            " USERS ON NHOM.GROUP_ID = USERS.GROUP_ID" & _
            " WHERE  USERS.USERNAME ='" & Commons.Modules.UserName & "'"
        cboLoaiThietBiBTDK.Value = "MS_LOAI_MAY"
        cboLoaiThietBiBTDK.Display = "TEN_LOAI_MAY"
        cboLoaiThietBiBTDK.StoreName = "QL_SEARCH"
        cboLoaiThietBiBTDK.Param = str
        cboLoaiThietBiBTDK.BindDataSource()
    End Sub

    Sub LoadNhomMay()
        Try
            CboNhomThietBiBTDK.DataSource = Nothing
            CboMaSoThietBiBTDK.DataSource = Nothing
            Dim str As String = ""
            str = "SELECT DISTINCT NHOM_MAY.MS_NHOM_MAY, NHOM_MAY.TEN_NHOM_MAY " & _
                  "FROM dbo.USERS INNER JOIN dbo.NHOM_MAY " & _
                       " INNER JOIN " & _
                       "dbo.NHOM_LOAI_MAY ON dbo.NHOM_MAY.MS_LOAI_MAY = dbo.NHOM_LOAI_MAY.MS_LOAI_MAY ON " & _
                       "dbo.USERS.GROUP_ID = dbo.NHOM_LOAI_MAY.GROUP_ID WHERE 1=1 AND USERS.USERNAME='" & Commons.Modules.UserName & "'"
            If cboLoaiThietBiBTDK.SelectedValue <> "-1" Then
                str = str + " AND NHOM_MAY.MS_LOAI_MAY ='" & cboLoaiThietBiBTDK.SelectedValue & "'"
            End If
            str = str + " ORDER BY TEN_NHOM_MAY"
            CboNhomThietBiBTDK.Value = "MS_NHOM_MAY"
            CboNhomThietBiBTDK.Display = "TEN_NHOM_MAY"
            CboNhomThietBiBTDK.StoreName = "QL_SEARCH"
            CboNhomThietBiBTDK.Param = str
            CboNhomThietBiBTDK.DropDownWidth = 150
            CboNhomThietBiBTDK.BindDataSource()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat1.Click
        Me.Close()
    End Sub

    Sub LayDuLieu()
        If (CboMaSoThietBiBTDK.Text = "" Or IsDBNull(CboMaSoThietBiBTDK)) And (cboLoaiThietBiBTDK.Text = "" Or IsDBNull(cboLoaiThietBiBTDK)) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            'Không có dữ liệu 
            Exit Sub
        End If
    End Sub

    Private Sub tabKeHoachTongThe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindData_Tab()
    End Sub

    Private Sub btnThoat3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


#Region "KEHOACHTONGTHE"
    Private Sub radChuaGiaiQuyet1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radChuaGiaiQuyet1.CheckedChanged
        If radChuaGiaiQuyet1.Checked = False Then Exit Sub
        tmp_cv = -1
        tmp_pt = -1
        LoadData()

        BtnThem1.Enabled = True
        'dtpTuNgay1.Enabled = False
        'dtpDenNgay1.Enabled = False
        DropDownButton1.Enabled = True
        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
            DropDownButton1.Enabled = False
        End If
        If KHType = "2" Then
            If radChuaGiaiQuyet1.Checked = True Then
                btnLPBT.Visible = True
            Else
                btnLPBT.Visible = False
            End If
        Else
            btnLPBT.Visible = False
        End If



    End Sub

    Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If

        dtTable_KHTT = New DataTable()
        If radAll.Checked Then
            Try
                dtTable_KHTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_KHBT_ALL", _
                        cboLoaiThietBiBTDK.SelectedValue, CboNhomThietBiBTDK.SelectedValue, _
                        CboMaSoThietBiBTDK.SelectedValue, Commons.Modules.UserName, _
                        cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), _
                        cboDiaDiem_1.SelectedValue.ToString(), cboHThong.SelectedValue, KHType, _NAM, _THANG))
            Catch ex As Exception
            End Try

        ElseIf radChuaGiaiQuyet1.Checked Then
            Try
                dtTable_KHTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_KHBT_CHUA_GIAI_QUYET", _
                        cboLoaiThietBiBTDK.SelectedValue, CboNhomThietBiBTDK.SelectedValue, _
                        CboMaSoThietBiBTDK.SelectedValue, Commons.Modules.UserName, _
                        cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), _
                        cboDiaDiem_1.SelectedValue.ToString(), cboHThong.SelectedValue, KHType, _NAM, _THANG))

            Catch ex As Exception

            End Try

        ElseIf RadBoQua1.Checked Then
            dtTable_KHTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_KHBT_BO_QUA", _
                        cboLoaiThietBiBTDK.SelectedValue, CboNhomThietBiBTDK.SelectedValue, _
                        CboMaSoThietBiBTDK.SelectedValue, Commons.Modules.UserName, _
                        cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), _
                        cboDiaDiem_1.SelectedValue.ToString(), cboHThong.SelectedValue, KHType, _NAM, _THANG))
        Else
            dtTable_KHTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_KHBT_DA_GIAI_QUYET", _
                        cboLoaiThietBiBTDK.SelectedValue, CboNhomThietBiBTDK.SelectedValue, _
                        CboMaSoThietBiBTDK.SelectedValue, Commons.Modules.UserName, _
                        cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), _
                        cboDiaDiem_1.SelectedValue.ToString(), cboHThong.SelectedValue, KHType, _NAM, _THANG))
        End If

        For Each col As DataColumn In dtTable_KHTT.Columns
            col.ReadOnly = False
        Next
        gdKHTT.DataSource = dtTable_KHTT
        If dtTable_KHTT.Rows.Count <= 0 Then
            gdCVTT.DataSource = DBNull.Value
            gdVTTT.DataSource = DBNull.Value
        End If
        BindDataCV()
        BindDataVTPT()
        CBOLYDOSUACHUA.ColumnEdit = repositoryItemLookUpEdit2
        cboNgayLap.ColumnEdit = repositoryItemDateEdit1
        cboNgayDKHT.ColumnEdit = repositoryItemDateEdit1
        HM_MS_UU_TIEN.ColumnEdit = lookeditMucUTHM

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvKHTT.Columns
            Select Case col.FieldName
                Case "NGAY"
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboNgayLap", Commons.Modules.TypeLanguage)
                Case "LY_DO_SC"
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboLYDOSUACHUA", Commons.Modules.TypeLanguage)
                Case Else
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
            End Select
        Next
        Cursor = Cursors.Default
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
        'dtpTuNgay1.Enabled = True
        'dtpDenNgay1.Enabled = True
        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
        End If
        btnLPBT.Visible = False
    End Sub



    Sub HideButton(ByVal An As Boolean)
        BtnThem1.Visible = Not An
        btnLPBT.Visible = Not An
        BtnThoat1.Visible = Not An
        btnIn1.Visible = Not An
        BtnGhi1.Visible = An
        BtnKhongghi1.Visible = An
        BtnXemtonkhoPT.Visible = Not An
        btnChonCV.Visible = An
        btnChonPT.Visible = An
        btnChonMay.Visible = An
        btnDuyet.Visible = Not An
    End Sub

    Sub LockData1(ByVal Khoa As Boolean)
        radChuaGiaiQuyet1.Enabled = Not Khoa
        RadBoQua1.Enabled = Not Khoa
        radDaGiaiQuyet1.Enabled = Not Khoa
        'dtpTuNgay1.Enabled = Not Khoa
        'dtpDenNgay1.Enabled = Not Khoa
        cboLoaiThietBiBTDK.Enabled = Not Khoa
        CboNhomThietBiBTDK.Enabled = Not Khoa
        CboMaSoThietBiBTDK.Enabled = Not Khoa
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
        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If

        Try
            Commons.Modules.SQLString = "DROP TABLE KHTCV_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        Commons.Modules.SQLString = "CREATE TABLE KHTCV_TMP" & Commons.Modules.UserName & " ( ID BIGINT , MS_MAY nvarchar (30) NOT NULL, HANG_MUC_ID int NOT NULL, MS_CV int NOT NULL, MS_BO_PHAN [nvarchar] (50)NOT NULL, " & _
        " GHI_CHU nvarchar (255) NULL , MS_PHIEU_BAO_TRI nvarchar (20) NULL , EOR_ID nvarchar (20) NULL , KHONG_GQ bit NOT NULL DEFAULT 0,THUE_NGOAI bit NOT NULL DEFAULT 0, " & _
        " [KH_TYPE] [int] NULL, [KH_NAM] [int] NULL,[KH_THANG] [int] NULL,[KH_TUAN] [int] NULL,[TU_NGAY] [datetime] NULL,[DEN_NGAY] [datetime] NULL," & _
        " [MS_UU_TIEN] [int] NULL,[CP_VT_NN_NGOAI_DM] [float] NULL,[CP_VT_NGOAI_DM] [float] NULL,[CP_THUE_NGOAI] [float] NULL, TG_KH [float] NULL , " & _
        " CONSTRAINT PK_KHTCV_TMP" & Commons.Modules.UserName & " PRIMARY KEY CLUSTERED (ID,MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN) ON [PRIMARY]) ON [PRIMARY]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        If KHType = "1" Then
            Commons.Modules.SQLString = "INSERT INTO KHTCV_TMP" & Commons.Modules.UserName & " SELECT T1.ID, T1.MS_MAY, T2.HANG_MUC_ID, T2.MS_CV, T2.MS_BO_PHAN, T2.GHI_CHU, T2.MS_PHIEU_BAO_TRI, T2.EOR_ID, T2.KHONG_GQ, T2.THUE_NGOAI, T1.KH_TYPE, T1.KH_NAM, T1.KH_THANG, " & _
     " T1.KH_TUAN, T1.TU_NGAY, T1.DEN_NGAY, T1.MS_UU_TIEN, T1.CP_VT_NN_NGOAI_DM, T1.CP_VT_NGOAI_DM, T1.CP_THUE_NGOAI, T1.TG_KH" & _
     " FROM         (SELECT     ID, MS_MAY, MA_HANG_MUC, MA_CV, MA_BO_PHAN, KH_NAM, KH_THANG, KH_TUAN, TU_NGAY, DEN_NGAY, DUYET, NGUOI_DUYET, NGAY_DUYET, ID_TRUOC, KH_TYPE, " & _
     " MS_UU_TIEN, CP_VT_NN_NGOAI_DM, CP_VT_NGOAI_DM, CP_THUE_NGOAI, TG_KH " & _
     " FROM dbo.KE_HOACH_TONG_CONG_VIEC_CHI_TIET " & _
     "                WHERE KH_TYPE = '" & KHType & "' AND KH_NAM = '" & _NAM & "' ) AS T1 INNER JOIN " & _
     "               dbo.KE_HOACH_TONG_CONG_VIEC AS T2 ON T1.MS_MAY = T2.MS_MAY AND T1.MA_HANG_MUC = T2.HANG_MUC_ID AND T1.MA_CV = T2.MS_CV AND T1.MA_BO_PHAN = T2.MS_BO_PHAN"


        ElseIf KHType = "2" Then
            Commons.Modules.SQLString = "INSERT INTO KHTCV_TMP" & Commons.Modules.UserName & " SELECT T1.ID, T1.MS_MAY, T2.HANG_MUC_ID, T2.MS_CV, T2.MS_BO_PHAN, T2.GHI_CHU, T2.MS_PHIEU_BAO_TRI, T2.EOR_ID, T2.KHONG_GQ, T2.THUE_NGOAI, T1.KH_TYPE, T1.KH_NAM, T1.KH_THANG, " & _
     " T1.KH_TUAN, T1.TU_NGAY, T1.DEN_NGAY, T1.MS_UU_TIEN, T1.CP_VT_NN_NGOAI_DM, T1.CP_VT_NGOAI_DM, T1.CP_THUE_NGOAI, T1.TG_KH" & _
     " FROM         (SELECT     ID, MS_MAY, MA_HANG_MUC, MA_CV, MA_BO_PHAN, KH_NAM, KH_THANG, KH_TUAN, TU_NGAY, DEN_NGAY, DUYET, NGUOI_DUYET, NGAY_DUYET, ID_TRUOC, KH_TYPE, " & _
     " MS_UU_TIEN, CP_VT_NN_NGOAI_DM, CP_VT_NGOAI_DM, CP_THUE_NGOAI , TG_KH " & _
     " FROM dbo.KE_HOACH_TONG_CONG_VIEC_CHI_TIET " & _
     "                WHERE   KH_TYPE = '" & KHType & "' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "' ) AS T1 INNER JOIN " & _
     "               dbo.KE_HOACH_TONG_CONG_VIEC AS T2 ON T1.MS_MAY = T2.MS_MAY AND T1.MA_HANG_MUC = T2.HANG_MUC_ID AND T1.MA_CV = T2.MS_CV AND T1.MA_BO_PHAN = T2.MS_BO_PHAN"

        End If
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        Try
            Commons.Modules.SQLString = "DROP TABLE KHTCVPT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception

        End Try
        Commons.Modules.SQLString = "CREATE TABLE KHTCVPT_TMP" & Commons.Modules.UserName & " ( KH_TYPE int NOT NULL, " & _
                " KH_NAM int NOT NULL,KH_THANG int NULL,KH_TUAN int NULL, MS_MAY nvarchar (30) NOT NULL, " & _
                " HANG_MUC_ID int NOT NULL, MS_CV int NOT NULL,MS_BO_PHAN nvarchar (50) NOT NULL, MS_PT nvarchar (25) NOT NULL, SO_LUONG float NULL, " & _
                " GHI_CHU nvarchar (255) NULL , DON_GIA_KH numeric(18, 2) NULL, TIEN_TE_KH numeric(18, 2) NULL, TY_GIA_KH numeric(18, 2) NULL, " & _
                " TY_GIA_USD_KH numeric(18, 2) NULL, DON_GIA_CUOI numeric(18, 2) NULL, NGAY_LAY_DG_KH datetime NULL ,    " & _
                " CONSTRAINT PK_KHTCVPT_TMP" & Commons.Modules.UserName & _
                " PRIMARY KEY CLUSTERED (MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT) ON [PRIMARY]) ON [PRIMARY]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)

        If KHType = "1" Then
            Commons.Modules.SQLString = "INSERT INTO KHTCVPT_TMP" & Commons.Modules.UserName & " SELECT KH_TYPE, KH_NAM, KH_THANG, KH_TUAN, MS_MAY, HANG_MUC_ID, MS_CV, MS_BO_PHAN, MS_PT, SO_LUONG, GHI_CHU, DON_GIA_KH, TIEN_TE_KH, TY_GIA_KH, TY_GIA_USD_KH,  DON_GIA_CUOI, NGAY_LAY_DG_KH FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE KH_TYPE = '" & KHType & "' AND KH_NAM = '" & _NAM & "'"
        Else
            Commons.Modules.SQLString = "INSERT INTO KHTCVPT_TMP" & Commons.Modules.UserName & " SELECT KH_TYPE, KH_NAM, KH_THANG, KH_TUAN, MS_MAY, HANG_MUC_ID, MS_CV, MS_BO_PHAN, MS_PT, SO_LUONG, GHI_CHU, DON_GIA_KH, TIEN_TE_KH, TY_GIA_KH, TY_GIA_USD_KH,  DON_GIA_CUOI, NGAY_LAY_DG_KH FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE KH_TYPE = '" & KHType & "' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "'"
        End If

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    End Sub
    Private Sub BtnThem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem1.Click
        'Dim ind As Integer
        HideButton(True)
        LockData1(True)
        DKLoadFormThem()
        Try
            If radChuaGiaiQuyet1.Checked Then
                EnalbeGrid(True)
                blnThemSua = True
                EditData()

                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE ID_KE_HOACH_BAO_TRI WHERE USER_CREATE = '" & Commons.Modules.UserName & "'")
                Catch ex As Exception
                End Try
                j = -1
            ElseIf RadBoQua1.Checked Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT13", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                gvCVTT.Columns("KHONG_GQ").OptionsColumn.AllowEdit = True
                gvCVTT.Columns("THUE_NGOAI").OptionsColumn.AllowEdit = True
                btnChonCV.Enabled = False
                btnChonPT.Enabled = False
                btnChonMay.Enabled = False
            End If

            count = gvKHTT.RowCount
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnalbeGrid(ByVal bool As Boolean)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvKHTT.Columns
            col.OptionsColumn.AllowEdit = bool
        Next

        gvKHTT.Columns("MS_MAY").OptionsColumn.AllowEdit = False
        gvKHTT.Columns("TEN_MAY").OptionsColumn.AllowEdit = False
        gvKHTT.Columns("USERNAME").OptionsColumn.AllowEdit = False


        gvKHTT.Columns.ColumnByName("HM_DUYET").OptionsColumn.AllowEdit = False
        gvKHTT.Columns.ColumnByName("HTHANH").OptionsColumn.AllowEdit = False
        gvCVTT.Columns("THUE_NGOAI").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("KHONG_GQ").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("GHI_CHU").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("MS_UU_TIEN").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("CP_VT_NN_NGOAI_DM").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("CP_VT_NGOAI_DM").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("CP_THUE_NGOAI").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("TU_NGAY").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("DEN_NGAY").OptionsColumn.AllowEdit = bool
        gvCVTT.Columns("TG_KH").OptionsColumn.AllowEdit = bool

        gvVTTT.Columns("SO_LUONG").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("GHI_CHU").OptionsColumn.AllowEdit = bool


        gvVTTT.Columns("DON_GIA_KH").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("TIEN_TE_KH").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("TY_GIA_KH").OptionsColumn.AllowEdit = bool
        gvVTTT.Columns("TY_GIA_USD_KH").OptionsColumn.AllowEdit = bool


    End Sub
    Private Sub UpdateDataKHTT_CV(ByVal tran As SqlTransaction)

        Dim _khong_GQ As Boolean = False
        Dim _thue_ngoai As Boolean = False
        Dim _ms_bp As String = ""
        Dim _ghi_chu_temp As String = ""
        Dim _ms_may As String = ""
        Dim _ms_uu_tien As Integer
        Dim _hang_muc As Integer
        Dim _cv As Integer

        Dim hm_muc_ut As Integer = 2
        Dim hm_CP_VT_NN_NGOAI_DM As Double = 0
        Dim hm_CP_VT_NGOAI_DM As Double = 0
        Dim hm_CP_THUE_NGOAI As Double = 0
        Dim hm_tu_ngay As DateTime
        Dim hm_den_ngay As DateTime
        Dim hm_ID As Integer
        Dim hm_TG_KH As Double = 0


        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If


        For Each _dr As DataRow In dtTable_CV_TEMP.Rows


            Try
                Double.TryParse(_dr("CP_VT_NN_NGOAI_DM"), hm_CP_VT_NN_NGOAI_DM)
            Catch ex As Exception

            End Try
            Try
                Double.TryParse(_dr("CP_VT_NGOAI_DM"), hm_CP_VT_NGOAI_DM)
            Catch ex As Exception

            End Try
            Try
                Double.TryParse(_dr("CP_THUE_NGOAI"), hm_CP_THUE_NGOAI)
            Catch ex As Exception

            End Try
            Try
                Integer.TryParse(_dr("MS_UU_TIEN"), hm_muc_ut)
            Catch ex As Exception

            End Try

            If IsDBNull(_dr("TU_NGAY")) = False Then
                DateTime.TryParse(_dr("TU_NGAY"), hm_tu_ngay)
            End If

            If IsDBNull(_dr("DEN_NGAY")) = False Then
                DateTime.TryParse(_dr("DEN_NGAY"), hm_den_ngay)
            End If

            Try
                If IsDBNull(_dr("ID")) = False Then
                    Integer.TryParse(_dr("ID"), hm_ID)
                End If
            Catch ex As Exception

            End Try


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

            Try
                Double.TryParse(_dr("TG_KH"), hm_TG_KH)
            Catch ex As Exception

            End Try

            _hang_muc = _dr("HANG_MUC_ID")
            _cv = _dr("MS_CV")
            _ms_bp = _dr("MS_BO_PHAN")
            _ghi_chu_temp = _dr("GHI_CHU")
            _ms_uu_tien = _dr("MS_UU_TIEN")
            _ms_may = _dr("MS_MAY")
            Dim sql As String = "SELECT COUNT(*) FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY ='" & _ms_may & "' AND MS_CV=" & _cv & " AND MS_BO_PHAN ='" & _ms_bp & "' AND HANG_MUC_ID=" & _hang_muc
            If Convert.ToInt16(SqlHelper.ExecuteScalar(tran, CommandType.Text, sql)) > 0 Then
                SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", _ms_may, _hang_muc, _cv, _ms_bp, Me.Name, Commons.Modules.UserName, 2)
                SqlHelper.ExecuteNonQuery(tran, "SP_UPDATE_KHBT_CV_CHUA_GQ", _khong_GQ, _thue_ngoai, _hang_muc, _ms_bp, _cv, _ghi_chu_temp, _ms_uu_tien, KHType, _NAM, _THANG, hm_CP_VT_NN_NGOAI_DM, hm_CP_VT_NGOAI_DM, hm_CP_THUE_NGOAI, IIf(hm_tu_ngay < New DateTime(1900, 1, 1), DBNull.Value, hm_tu_ngay), IIf(hm_den_ngay < New DateTime(1900, 1, 1), DBNull.Value, hm_den_ngay), hm_ID, hm_TG_KH)
            Else
                SqlHelper.ExecuteNonQuery(tran, "SP_INSERT_KHBTCV_CHUA_GQ", _khong_GQ, _thue_ngoai, _hang_muc, _ms_bp, _cv, _ghi_chu_temp, _ms_uu_tien, _ms_may, KHType, _NAM, _THANG, hm_CP_VT_NN_NGOAI_DM, hm_CP_VT_NGOAI_DM, hm_CP_THUE_NGOAI, IIf(hm_tu_ngay < New DateTime(1900, 1, 1), DBNull.Value, hm_tu_ngay), IIf(hm_den_ngay < New DateTime(1900, 1, 1), DBNull.Value, hm_den_ngay), hm_ID, hm_TG_KH)
                SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", _ms_may, _hang_muc, _cv, _ms_bp, Me.Name, Commons.Modules.UserName, 1)
            End If
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

        Dim hm_muc_ut As Integer = 2
        Dim hm_CP_VT_NN_NGOAI_DM As Double = 0
        Dim hm_CP_VT_NGOAI_DM As Double = 0
        Dim hm_CP_THUE_NGOAI As Double = 0
        Dim PTHThanh As Double = 0

        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If


        If gvKHTT.RowCount > 0 Then
            For i As Integer = 0 To gvKHTT.RowCount - 1
                If gvKHTT.GetDataRow(i)("TEN_HANG_MUC").Equals(DBNull.Value) Or gvKHTT.GetDataRow(i)("LY_DO_SC") = -1 Then
                    gvKHTT.FocusedRowHandle = i
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TENHANGMUCVALYDOSCKHONGDUOCNULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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

            Try
                Double.TryParse(row("CP_VT_NN_NGOAI_DM"), hm_CP_VT_NN_NGOAI_DM)
            Catch ex As Exception

            End Try
            Try
                Double.TryParse(row("CP_VT_NGOAI_DM"), hm_CP_VT_NGOAI_DM)
            Catch ex As Exception

            End Try
            Try
                Double.TryParse(row("CP_THUE_NGOAI"), hm_CP_THUE_NGOAI)
            Catch ex As Exception

            End Try
            Try
                Integer.TryParse(row("MS_UU_TIEN"), hm_muc_ut)
            Catch ex As Exception

            End Try
            Try
                Double.TryParse(row("PT_HTHANH"), PTHThanh)
            Catch ex As Exception

            End Try


            Dim _sql As String = "SET IDENTITY_INSERT KE_HOACH_TONG_THE ON"
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, _sql)
            Dim sql As String = "SELECT COUNT(*) FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID =" & _hang_muc_id
            If Convert.ToInt16(SqlHelper.ExecuteScalar(tran, CommandType.Text, sql)) > 0 Then
                SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_THE_LOG", _hang_muc_id, Me.Name, Commons.Modules.UserName, 2)
                SqlHelper.ExecuteNonQuery(tran, "SP_UPDATE_KE_HOACH_BAO_TRI_HANG_MUC", ms_may, ngay, ngay_bd_kh, ten_hang_muc, _
                    ghi_chu, ly_do_sc, Commons.Modules.UserName, _hang_muc_id, KHType, _NAM, _THANG, hm_muc_ut, _
                    hm_CP_VT_NN_NGOAI_DM, hm_CP_VT_NGOAI_DM, hm_CP_THUE_NGOAI, PTHThanh)
            Else
                SqlHelper.ExecuteNonQuery(tran, "SP_INSERT_KE_HOACH_BAO_TRI_HANG_MUC", ms_may, _hang_muc_id, ngay, ngay_bd_kh, ten_hang_muc, ghi_chu, ly_do_sc, Commons.Modules.UserName, KHType, _NAM, _THANG, hm_muc_ut, hm_CP_VT_NN_NGOAI_DM, hm_CP_VT_NGOAI_DM, hm_CP_THUE_NGOAI)
                Try
                    SqlHelper.ExecuteNonQuery(tran, "UPDATE_KE_HOACH_TONG_THE_LOG", _hang_muc_id, Me.Name, Commons.Modules.UserName, 1)
                Catch ex As Exception

                End Try
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
        Dim sql As String
        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If

        If KHType = "1" Then
            sql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE HANG_MUC_ID IN (SELECT DISTINCT HANG_MUC_ID FROM KHTCVPT_TMP" & Commons.Modules.UserName & ")" & _
              " AND KH_TYPE = '" & KHType & "' AND KH_NAM = '" & _NAM & "'"
        Else
            sql = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE HANG_MUC_ID IN (SELECT DISTINCT HANG_MUC_ID FROM KHTCVPT_TMP" & Commons.Modules.UserName & ")" & _
              " AND KH_TYPE = '" & KHType & "' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "'"
        End If
        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql)

        sql = "INSERT INTO KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET(KH_TYPE, KH_NAM,KH_THANG,KH_TUAN, MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,GHI_CHU, " & _
                " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH ) " & _
                " SELECT KH_TYPE, KH_NAM,KH_THANG,KH_TUAN, MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG,GHI_CHU, " & _
                " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH FROM KHTCVPT_TMP" & Commons.Modules.UserName
        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql)

        Try
            sql = "DROP TABLE KHTCVPT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql)
        Catch ex As Exception
        End Try
    End Sub
    Sub UpdateDataKTTT_CV_PT(ByVal tran As SqlTransaction)
        For Each row As DataRow In dtTable_KHTT_TEMP.Rows
            SqlHelper.ExecuteNonQuery(tran, "SP_NHU_Y_UPDATE_KHTT_CV_PT", row("HANG_MUC_ID"), row("MS_MAY"))
        Next
    End Sub

    Private Function CheckDataBeforeCreateKH() As Boolean

        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If

        'KTRA NGAY
        Dim _GioiHanTuNgay As String = ""
        Dim _ngayHienTai As String = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)


        If KHType = "1" Then
            _GioiHanTuNgay = cbKHNNam.SelectedValue.ToString + "0101"
        Else
            _GioiHanTuNgay = cbKHTNam.SelectedValue.ToString + cbKHTThang.SelectedValue.ToString + "01"
        End If


        For i As Integer = 0 To gvKHTT.RowCount - 1


            If gvKHTT.GetRowCellValue(i, "TEN_HANG_MUC").ToString.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_TEN_HANG_MUC", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                gvKHTT.FocusedRowHandle = i
                Return False
            End If

            If gvKHTT.GetRowCellValue(i, "NGAY").ToString().Trim() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_TU_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                gvKHTT.FocusedRowHandle = i
                Return False
            End If

            If gvKHTT.GetRowCellValue(i, "NGAY_DK_HT").ToString().Trim() = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHAI_NHAP_DEN_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                gvKHTT.FocusedRowHandle = i
                Return False
            End If
            Dim dKT As Double = 0
            Try
                dKT = Convert.ToDouble(gvKHTT.GetRowCellValue(i, "PT_HTHANH").ToString())
            Catch ex As Exception

            End Try


            If dKT < 0 Or dKT > 100 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgPTHoanThanhPhaiLonhon0NhoHon100", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                gvKHTT.FocusedRowHandle = i
                Return False
            End If

            Dim _tu_ngaytmp As String = CType(gvKHTT.GetRowCellValue(i, "NGAY"), DateTime).ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)
            Dim _den_ngaytmp As String = CType(gvKHTT.GetRowCellValue(i, "NGAY_DK_HT"), DateTime).ToString("yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)

            If _tu_ngaytmp > _den_ngaytmp Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NHO_HON_DEN_NGAY", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                gvKHTT.FocusedRowHandle = i
                Return False
            End If

            If KHType = "1" Then
                If _GioiHanTuNgay > _tu_ngaytmp Or _GioiHanTuNgay.Substring(0, 4) <> _tu_ngaytmp.Substring(0, 4) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NAM_TRONG_GIOI_HAN_NAM", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                    gvKHTT.FocusedRowHandle = i
                    Return False
                End If
            Else
                If _GioiHanTuNgay > _tu_ngaytmp Or _GioiHanTuNgay.Substring(0, 6) <> _tu_ngaytmp.Substring(0, 6) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY_PHAI_NAM_TRONG_GIOI_HAN_THANG", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
                    gvKHTT.FocusedRowHandle = i
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub BtnGhi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi1.Click
        Dim tran As SqlTransaction
        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        tran = con.BeginTransaction()
        Dim _khong_GQ As Boolean = False
        Dim _thue_ngoai As Boolean = False
        Dim _ms_bp As String = ""
        Dim _ghi_chu_temp As String = ""
        Dim _ms_may As String = ""
        Dim _hang_muc As Integer
        Dim _cv As Integer
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

                If CheckDataBeforeCreateKH() = False Then
                    'dtTable_CV_TEMP.Clear()
                    'dtTable_KHTT_TEMP.Clear()
                    tran.Rollback()
                    con.Close()
                    Exit Sub
                End If

                UpdateDataKHTT(tran)
                If success = False Then
                    dtTable_CV_TEMP.Clear()
                    dtTable_KHTT_TEMP.Clear()
                    tran.Rollback()
                    con.Close()
                    Return
                End If
                UpdateDataKHTT_CV(tran)
                UpdateDataKHTT_PT(tran)

                If success = False Then
                    dtTable_CV_TEMP.Clear()
                    dtTable_KHTT_TEMP.Clear()
                    tran.Rollback()
                    con.Close()
                    Return
                End If
                Try
                    Dim sSql As String
                    'Cap nhap vao IC_PHU_TUNG_LOAI_MAY cho cac Phu Tung moi 
                    sSql = " INSERT INTO [IC_PHU_TUNG_LOAI_MAY] ([MS_PT],[MS_LOAI_MAY]) " & _
                                " SELECT  DISTINCT MS_PT,  dbo.NHOM_MAY.MS_LOAI_MAY " & _
                                " FROM dbo.NHOM_MAY INNER JOIN dbo.MAY ON dbo.NHOM_MAY.MS_NHOM_MAY = dbo.MAY.MS_NHOM_MAY INNER JOIN " & _
                                " dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET ON dbo.MAY.MS_MAY = dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_MAY " & _
                                " WHERE NOT EXISTS (SELECT * FROM IC_PHU_TUNG_LOAI_MAY D WHERE KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = D.MS_PT AND  " & _
                                " dbo.NHOM_MAY.MS_LOAI_MAY = D.MS_LOAI_MAY ) "
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)

                    sSql = " INSERT INTO [CAU_TRUC_THIET_BI_PHU_TUNG]([MS_MAY],[MS_BO_PHAN],[MS_PT],[MS_VI_TRI_PT],[SO_LUONG],[ACTIVE])	 " & _
                                " SELECT DISTINCT A.MS_MAY, A.MS_BO_PHAN, A.MS_PT, 'A' AS MS_VI_TRI_PT, A.SO_LUONG, 1 AS ACTIVE " & _
                                " FROM         dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET AS A INNER JOIN " & _
                                " dbo.IC_PHU_TUNG AS B ON A.MS_PT = B.MS_PT INNER JOIN " & _
                                " dbo.LOAI_VT AS C ON B.MS_LOAI_VT = C.MS_LOAI_VT " & _
                                " WHERE     (C.VAT_TU = 0) AND NOT EXISTS ( SELECT * FROM [CAU_TRUC_THIET_BI_PHU_TUNG] X WHERE  X.MS_MAY = A.MS_MAY AND  X.MS_BO_PHAN = A.MS_BO_PHAN " & _
                                " AND  X.MS_PT = A.MS_PT AND  X.MS_VI_TRI_PT = 'A')"
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
                Catch ex As Exception

                End Try

                'Xoa ID KHBT

                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE ID_KE_HOACH_BAO_TRI WHERE USER_CREATE = '" & Commons.Modules.UserName & "'")

                tran.Commit()
                con.Close()
                ResetData()
            Catch ex As Exception
                XtraMessageBox.Show(e.ToString)
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
        LoadData()
        EnalbeGrid(False)
        dtTable_CV_TEMP.Clear()
        dtTable_KHTT_TEMP.Clear()
        blnThemSua = False
        HideButton(False)
        LockData1(False)
        intTabInd = -1
        'dtpTuNgay1.Enabled = False
        'dtpDenNgay1.Enabled = False
        gvKHTT.FocusedRowHandle = index


        DKLoadForm()

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

        Try
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE ID_KE_HOACH_BAO_TRI WHERE USER_CREATE = '" & Commons.Modules.UserName & "'")

        Catch ex As Exception

        End Try

        DKLoadForm()

    End Sub
    Private Sub RadBoQua1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBoQua1.CheckedChanged
        If RadBoQua1.Checked = False Then Exit Sub
        tmp_cv = -1
        tmp_pt = -1
        LoadData()
        BtnThem1.Enabled = True
        'dtpTuNgay1.Enabled = False
        'dtpDenNgay1.Enabled = False
        If Commons.Modules.PermisString.Equals("Read only") Then
            BtnThem1.Enabled = False
        End If
        btnLPBT.Visible = False

    End Sub
    Sub HideButtonXoa(ByVal An As Boolean)
        BtnThem1.Visible = Not An

        BtnThoat1.Visible = Not An

        BtnTroVe.Visible = An
        btnIn1.Visible = Not An
    End Sub
    Private Sub BtnTroVe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTroVe.Click
        HideButtonXoa(False)
        LockData1(False)
        intTabInd = -1
    End Sub
    Private Sub btnChonCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonCV.Click
        If gvKHTT.RowCount <= 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT20", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        FrmChonCongViecChoKHTT.MS_MAY = gvKHTT.GetFocusedDataRow()("MS_MAY")
        FrmChonCongViecChoKHTT.HANG_MUC_ID = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
        FrmChonCongViecChoKHTT.RecNum = gvKHTT.RowCount
        FrmChonCongViecChoKHTT.Frm_KeHoachBaoTri = "frmKehoachtongtheNew"

        Dim sBT As String
        sBT = "CV_TMP" & Commons.Modules.UserName
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, gvCVTT.DataSource.ToTable(), "")
        Try
            If FrmChonCongViecChoKHTT.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sql As String = "SELECT TEN_BO_PHAN,KHTCV.MS_CV,HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & ",KHTCV.MS_MAY,MS_UU_TIEN=3," & _
                                     "KHTCV.MS_BO_PHAN,MO_TA_CV,MS_PHIEU_BAO_TRI='',EOR_ID='',THUE_NGOAI=0,KHONG_GQ=0,ISNULL(KHTCV.GHI_CHU,'') AS GHI_CHU,  " & _
                                    " MS_UU_TIEN = CONVERT(INT,3) , CP_VT_NN_NGOAI_DM = CONVERT(FLOAT,0) , CP_VT_NGOAI_DM = CONVERT(FLOAT,0) , " & _
                                    " CP_THUE_NGOAI = CONVERT(FLOAT,0), TU_NGAY = CONVERT(DATETIME,NULL) , DEN_NGAY = CONVERT(DATETIME,NULL) , " & _
                                    " ID = CONVERT(INT,-1), TG_KH FROM CONG_VIEC_KHTT_TMP" & Commons.Modules.UserName & " KHTCV WHERE CHON=1 "
                dtTable_CV_TEMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                CapNhapKeHoach("USERNAME")
                BindDataCV()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Dim autoCompleteSource As New AutoCompleteStringCollection()
    Private Sub BindDataVTPT()
        Try
            dtTable_PT = New DataTable()
            Dim str As String = Commons.Modules.TypeLanguage.ToString()
            Dim sql As String

            Dim _NAM As Integer
            Dim _THANG As Integer

            If cbKHType.SelectedValue.ToString() = "1" Then
                _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                _THANG = 0
                KHType = "1"
            ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                KHType = "2"
            End If

            If blnThemSua Then

                Dim sss As String = Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                Dim dfdfd As String = gvCVTT.GetFocusedDataRow()("MS_CV")
                sql = "SELECT MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,KHTCVPT.MS_PT,TEN_PT,SO_LUONG," & _
                            "CASE " & str & " WHEN 0 THEN TEN_1 WHEN 0 THEN TEN_2 WHEN 2 THEN TEN_3 END AS TEN_DVT,KHTCVPT.GHI_CHU, " & _
                            " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " & _
                            " FROM KHTCVPT_TMP" & Commons.Modules.UserName & _
                            " KHTCVPT INNER JOIN IC_PHU_TUNG PT ON KHTCVPT.MS_PT=PT.MS_PT" & _
                            " INNER JOIN DON_VI_TINH DV ON PT.DVT=DV.DVT WHERE HANG_MUC_ID=" & Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & _
                            " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & _
                            " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                dtTable_PT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            Else
                dtTable_PT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHBT_CONG_VIEC_PT", _
                    Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), Me.gvCVTT.GetFocusedDataRow("MS_CV"), _
                    Me.gvCVTT.GetFocusedDataRow()("MS_BO_PHAN"), Commons.Modules.TypeLanguage, KHType, _NAM, _THANG))
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

            Dim _NAM As Integer
            Dim _THANG As Integer

            If cbKHType.SelectedValue.ToString() = "1" Then
                _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                _THANG = 0
                KHType = "1"
            ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                KHType = "2"
            End If
            Dim sql As String = ""
            If radAll.Checked Then
                dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GetKHBT_CONG_VIEC", Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), -1, KHType, _NAM, _THANG))

            ElseIf radChuaGiaiQuyet1.Checked Then
                If blnThemSua = True Then
                    sql = "SELECT TEN_BO_PHAN,KHTCV.MS_CV,HANG_MUC_ID,KHTCV.MS_MAY,ISNULL(MS_UU_TIEN,3) AS MS_UU_TIEN,KHTCV.MS_BO_PHAN,MO_TA_CV, " & _
                        " MS_PHIEU_BAO_TRI,EOR_ID,THUE_NGOAI,KHONG_GQ,ISNULL(KHTCV.GHI_CHU,'') AS GHI_CHU ,KHTCV.KH_TYPE, KHTCV.KH_NAM, " & _
                        " KHTCV.KH_THANG, KHTCV.KH_TUAN, KHTCV.TU_NGAY, KHTCV.DEN_NGAY,KHTCV.CP_VT_NN_NGOAI_DM, KHTCV.CP_VT_NGOAI_DM, " & _
                        " KHTCV.CP_THUE_NGOAI, KHTCV.TG_KH FROM KHTCV_TMP" & Commons.Modules.UserName & " KHTCV INNER JOIN CONG_VIEC CV " & _
                        " ON KHTCV.MS_CV=CV.MS_CV INNER JOIN CAU_TRUC_THIET_BI CTTB ON KHTCV.MS_MAY=CTTB.MS_MAY AND KHTCV.MS_BO_PHAN=CTTB.MS_BO_PHAN " & _
                        " WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_PHIEU_BAO_TRI IS NULL AND EOR_ID IS NULL " & _
                        " AND (KHONG_GQ=0 OR KHONG_GQ IS NULL) AND (THUE_NGOAI=0 OR THUE_NGOAI IS NULL)"
                    dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
                Else
                    dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GetKHBT_CONG_VIEC", Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), 0, KHType, _NAM, _THANG))
                End If

            ElseIf RadBoQua1.Checked Then
                dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GetKHBT_CONG_VIEC", Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), 1, KHType, _NAM, _THANG))
            Else
                dtTable_CV.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GetKHBT_CONG_VIEC", Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), 2, KHType, _NAM, _THANG))
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
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT21", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim _NAM As Integer
            Dim _THANG As Integer

            If cbKHType.SelectedValue.ToString() = "1" Then
                _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                _THANG = 0
                KHType = "1"
            ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                KHType = "2"
            End If

            FrmChonPTChoKHTT.MS_MAY = gvCVTT.GetFocusedDataRow()("MS_MAY")
            FrmChonPTChoKHTT.HANG_MUC_ID = gvCVTT.GetFocusedDataRow()("HANG_MUC_ID")
            FrmChonPTChoKHTT.MS_CV = gvCVTT.GetFocusedDataRow()("MS_CV")
            FrmChonPTChoKHTT.MS_BO_PHAN = gvCVTT.GetFocusedDataRow()("MS_BO_PHAN")
            FrmChonPTChoKHTT.FormKHBTName = "frmKehoachtongtheNew"
            FrmChonPTChoKHTT.KH_TYPE = KHType
            FrmChonPTChoKHTT.KH_NAM = _NAM
            FrmChonPTChoKHTT.KH_THANG = _THANG

            If FrmChonPTChoKHTT.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim str As String = ""

                If Commons.Modules.sPrivate.ToUpper = "BHS" Then
                    str = " DECLARE @NGAYHT DATETIME " &
                    " SET @NGAYHT = GETDATE() " &
                    "UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET DON_GIA_KH = B.DON_GIA  , TY_GIA_KH = '1' , DON_GIA_CUOI = B.DON_GIA , NGAY_LAY_DG_KH = @NGAYHT  " &
                    " FROM KHTCVPT_TMP" & Commons.Modules.UserName & " AS A INNER JOIN  " &
                    " ( SELECT A.MS_PT , A.DON_GIA  FROM SYN_TB_NHAP_KHO_CMMS AS A INNER JOIN ( " &
                    "    SELECT MS_PT,  MAX(DATEADD(SS,DATEPART(SS,GIO), DATEADD(MI, DATEPART(MI,GIO), DATEADD(HOUR,DATEPART(HH,GIO),NGAY)))) AS MAX_NGAY FROM SYN_TB_NHAP_KHO_INTEGRATION  " &
                    "    WHERE  MS_PT  IN (SELECT MS_PT FROM KHTCVPT_TMP" & Commons.Modules.UserName & ") GROUP BY MS_PT " &
                    "    HAVING MAX(NGAY) <= @NGAYHT " &
                    " ) AS BT ON DATEADD(SS,DATEPART(SS,A.GIO), DATEADD(MI, DATEPART(MI,A.GIO), DATEADD(HOUR,DATEPART(HH,A.GIO),A.NGAY))) = BT.MAX_NGAY AND A.MS_PT = BT.MS_PT AND A.DON_GIA <> 0 " &
                    " ) AS B ON A.MS_PT = B.MS_PT"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    str = "SELECT MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,KHTCVPT.MS_PT,TEN_PT,TEN_1 AS TEN_DVT,SO_LUONG,KHTCVPT.GHI_CHU, " &
                            " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " &
                            " FROM KHTCVPT_TMP" & Commons.Modules.UserName & " KHTCVPT INNER JOIN IC_PHU_TUNG PT ON KHTCVPT.MS_PT=PT.MS_PT INNER JOIN DON_VI_TINH DV ON PT.DVT=DV.DVT WHERE HANG_MUC_ID=" & Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & Me.gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"

                Else


                    str = " DECLARE @NGAYHT DATETIME " &
                    " SET @NGAYHT = GETDATE() " &
                    " UPDATE KHTCVPT_TMP" & Commons.Modules.UserName & " SET DON_GIA_KH = B.DON_GIA , TY_GIA_KH = B.TY_GIA,TY_GIA_USD_KH = B.TY_GIA_USD, " &
                    " DON_GIA_CUOI = (B.SL_THUC_NHAP *  B.DON_GIA * B.TY_GIA), NGAY_LAY_DG_KH = @NGAYHT " &
                    " FROM KHTCVPT_TMP" & Commons.Modules.UserName & " AS A INNER JOIN  " &
                    " (SELECT B.* FROM dbo.IC_DON_HANG_NHAP AS A INNER JOIN " &
                    "                       dbo.IC_DON_HANG_NHAP_VAT_TU B ON A.MS_DH_NHAP_PT = B.MS_DH_NHAP_PT INNER JOIN " &
                    " (SELECT MAX(NGAY) AS NGAYMAX , A.MS_DH_NHAP_PT FROM dbo.IC_DON_HANG_NHAP AS A INNER JOIN " &
                    "                       dbo.IC_DON_HANG_NHAP_VAT_TU ON A.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT " &
                    " WHERE MS_PT IN (SELECT DISTINCT MS_PT FROM KHTCVPT_TMP" & Commons.Modules.UserName & " WHERE ISNULL(DON_GIA_KH,0) + ISNULL(TIEN_TE_KH,0) +  " &
                    " ISNULL(TY_GIA_KH,0) + ISNULL(TY_GIA_USD_KH,0) + ISNULL(DON_GIA_CUOI,0) = 0 )  AND NGAY < = @NGAYHT " &
                    " GROUP BY  A.MS_DH_NHAP_PT) C ON A.MS_DH_NHAP_PT = C.MS_DH_NHAP_PT AND A.NGAY = C.NGAYMAX ) B ON A.MS_PT = B.MS_PT "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    str = "SELECT MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,KHTCVPT.MS_PT,TEN_PT,TEN_1 AS TEN_DVT,SO_LUONG,KHTCVPT.GHI_CHU, " &
                            " DON_GIA_KH,TIEN_TE_KH,TY_GIA_KH,TY_GIA_USD_KH,DON_GIA_CUOI,NGAY_LAY_DG_KH " &
                            " FROM KHTCVPT_TMP" & Commons.Modules.UserName & " KHTCVPT INNER JOIN IC_PHU_TUNG PT ON KHTCVPT.MS_PT=PT.MS_PT INNER JOIN DON_VI_TINH DV ON PT.DVT=DV.DVT WHERE HANG_MUC_ID=" & Me.gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & Me.gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                End If
                Dim dtTable As New DataTable()
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                Try
                    gdVTTT.DataSource = dtTable
                Catch ex As Exception
                End Try
                CapNhapKeHoach("USERNAME")
            End If
        Catch ex As Exception

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

    Sub CreateData1()
        RefeshHeaderReport()
        RefeshLanguageReport1()
        Cursor = Cursors.WaitCursor

        Try
            Commons.Modules.SQLString = "DROP TABLE rptACTION_PLAN_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try
        Dim dtFirst, dtLast As New DataTable
        Dim rowFirst, rowLast As DataRow
        Commons.Modules.SQLString = "SELECT KE_HOACH_TONG_CONG_VIEC.MS_MAY, LOAI_MAY.TEN_LOAI_MAY, KE_HOACH_TONG_THE.TEN_HANG_MUC, CONG_VIEC.MO_TA_CV, KE_HOACH_TONG_CONG_VIEC.THUE_NGOAI, KE_HOACH_TONG_THE.NGAY, KE_HOACH_TONG_THE.GHI_CHU  FROM  KE_HOACH_TONG_CONG_VIEC INNER JOIN KE_HOACH_TONG_THE ON KE_HOACH_TONG_CONG_VIEC.MS_MAY = KE_HOACH_TONG_THE.MS_MAY AND KE_HOACH_TONG_CONG_VIEC.HANG_MUC_ID = KE_HOACH_TONG_THE.HANG_MUC_ID INNER JOIN  MAY ON KE_HOACH_TONG_THE.MS_MAY = MAY.MS_MAY INNER JOIN  NHOM_MAY ON MAY.MS_NHOM_MAY = NHOM_MAY.MS_NHOM_MAY INNER JOIN  LOAI_MAY ON NHOM_MAY.MS_LOAI_MAY = LOAI_MAY.MS_LOAI_MAY INNER JOIN  CONG_VIEC ON KE_HOACH_TONG_CONG_VIEC.MS_CV = CONG_VIEC.MS_CV AND LOAI_MAY.MS_LOAI_MAY = CONG_VIEC.MS_LOAI_MAY WHERE    (KE_HOACH_TONG_CONG_VIEC.KHONG_GQ = 0) AND (KE_HOACH_TONG_CONG_VIEC.EOR_ID IS NULL) AND (KE_HOACH_TONG_CONG_VIEC.MS_PHIEU_BAO_TRI IS NULL)"
        dtFirst.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
        dtLast.Columns.Add("MS_MAY")
        dtLast.Columns.Add("TEN_LOAI_MAY")
        dtLast.Columns.Add("TEN_HANG_MUC")
        dtLast.Columns.Add("MO_TA_CV")
        dtLast.Columns.Add("THUE_NGOAI")
        dtLast.Columns.Add("NGAY")
        dtLast.Columns.Add("GHI_CHU")

        For Each rowFirst In dtFirst.Rows
            rowLast = dtLast.NewRow()
            rowLast("MS_MAY") = rowFirst("MS_MAY").ToString()
            rowLast("TEN_LOAI_MAY") = rowFirst("TEN_LOAI_MAY").ToString()
            rowLast("TEN_HANG_MUC") = rowFirst("TEN_HANG_MUC").ToString()
            rowLast("MO_TA_CV") = rowFirst("MO_TA_CV").ToString()
            If rowFirst("THUE_NGOAI").ToString() = True Then
                rowLast("THUE_NGOAI") = "Vendor"
            Else
                rowLast("THUE_NGOAI") = "Nội bộ"
            End If
            rowLast("NGAY") = rowFirst("NGAY").ToString()
            rowLast("GHI_CHU") = rowFirst("GHI_CHU").ToString()
            dtLast.Rows.Add(rowLast)
        Next

        Commons.Modules.SQLString = "CREATE TABLE rptACTION_PLAN_TMP(MS_MAY nvarchar(50), TEN_LOAI_MAY nvarchar(50), TEN_HANG_MUC nvarchar(50), MO_TA_CV nvarchar(1000), THUE_NGOAI nvarchar(50), NGAY datetime, GHI_CHU nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        For Each row As DataRow In dtLast.Rows
            Dim ngay As String = Convert.ToDateTime(row("NGAY").ToString()).Day
            Dim thang As String = Convert.ToDateTime(row("NGAY").ToString()).Month
            Dim nam As String = Convert.ToDateTime(row("NGAY").ToString()).Year
            Dim _date As String = (thang & "/" & ngay & "/" & nam)
            Commons.Modules.SQLString = "INSERT INTO rptACTION_PLAN_TMP VALUES(N'" & row("MS_MAY").ToString() & "',N'" & row("TEN_LOAI_MAY").ToString() & "',N'" & row("TEN_HANG_MUC").ToString() & "',N'" & row("MO_TA_CV").ToString() & "',N'" & row("THUE_NGOAI").ToString() & "','" & _date & "',N'" & row("GHI_CHU").ToString() & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Next



    End Sub

    Sub Printpreview1()
        Cursor = Cursors.WaitCursor
        Dim frm As frmShowXMLReport = New frmShowXMLReport()
        Dim sql As String
        Dim dtTMP As New DataTable
        sql = "SELECT * FROM rptACTION_PLAN_TMP"
        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        dtTMP.TableName = "rptACTION_PLAN_TMP"
        frm.AddDataTableSource(dtTMP)


        dtTMP = New DataTable
        sql = "SELECT * FROM insert_rptACTION_PLAN_TMP"
        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        dtTMP.TableName = "insert_rptACTION_PLAN_TMP"
        frm.AddDataTableSource(dtTMP)

        frm.rptName = "rptACTION_PLAN"
        frm.ShowDialog()




        'Call ReportPreview("reports\rptACTION_PLAN.rpt")
        Cursor = Cursors.Default
        Try
            Commons.Modules.SQLString = "DROP TABLE rptACTION_PLAN_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try

        Try
            Commons.Modules.SQLString = "DROP TABLE insert_rptACTION_PLAN_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefeshLanguageReport1()
        Dim NGAY_IN, TIEU_DE, MS_MAY, TEN_LOAI_TB, STT, HANG_MUC, CONG_VIEC, WHO, THOI_GIAN, REMARK, TRANG As String

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
        Try
            Commons.Modules.SQLString = "DROP TABLE insert_rptACTION_PLAN_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        Catch ex As Exception
        End Try
        Commons.Modules.SQLString = "CREATE TABLE insert_rptACTION_PLAN_TMP(NGAY_IN_ nvarchar(50), TIEU_DE_ nvarchar(50), MS_MAY_ nvarchar(50), TEN_LOAI_TB_ nvarchar(50),STT_ nvarchar(50),HANG_MUC_ nvarchar(50),CONG_VIEC_ nvarchar(50),WHO_ nvarchar(50),THOI_GIAN_ nvarchar(50), REMARK_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "ins_rptACTION_PLAN", NGAY_IN, TIEU_DE, MS_MAY, TEN_LOAI_TB, STT, HANG_MUC, CONG_VIEC, WHO, THOI_GIAN, REMARK, TRANG)

    End Sub

    Private Sub BtnIn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'If radChuaGiaiQuyet1.Checked = True Then
        '    Call CreateData1()
        '    Call Printpreview1()
        'End If
        Dim frm As New ReportMain.frmInKHTT
        frm.ShowDialog()

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

    Private Sub BtnXemtonkhoPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemtonkhoPT.Click
        If gvVTTT.RowCount = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_DL_IN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim result As DialogResult
        result = XtraMessageBox.Show("Chọn Yes để in phụ tùng đang chọn, No để xem tất cả!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = Windows.Forms.DialogResult.Yes Then
            CreateData2_One()
            If noDataToPrint = False Then
                Printpreview2()
            End If
        Else
            CreateData2_All()
            If noDataToPrint = False Then
                Printpreview2()
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub Printpreview2()
        Cursor = Cursors.WaitCursor

        Call ReportPreview("reports\rptKE_HOACH_TONG_THE_PHU_TUNG.rpt")
        Cursor = Cursors.Default

    End Sub
    Private Sub RefeshLanguageReport2()
        Dim TIEU_DE, STT, MS_PT_CTY, MS_PT, TEN_PT, DVT, SL_TON, TRANG As String

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "TIEU_DE", Commons.Modules.TypeLanguage)
        STT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "STT", Commons.Modules.TypeLanguage)
        MS_PT_CTY = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "MS_PT_CTY", Commons.Modules.TypeLanguage)
        MS_PT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "MS_PT", Commons.Modules.TypeLanguage)
        TEN_PT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "TEN_PT", Commons.Modules.TypeLanguage)
        DVT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "DVT", Commons.Modules.TypeLanguage)
        SL_TON = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "SL_TON", Commons.Modules.TypeLanguage)
        TRANG = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptKE_HOACH_TONG_THE_PHU_TUNG", "TRANG", Commons.Modules.TypeLanguage)
        Try
            SqlText = "DROP TABLE insert_rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception
        End Try
        SqlText = "CREATE TABLE insert_rptKE_HOACH_TONG_THE_PHU_TUNG_TMP(TIEU_DE_ nvarchar(50), STT_ nvarchar(50), MS_PT_CTY_ nvarchar(50), MS_PT_ nvarchar(50), TEN_PT_ nvarchar(50), DVT_ nvarchar(50), SL_TON_ nvarchar(50), TRANG_ nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "insert_rptKE_HOACH_TONG_THE_PHU_TUNG", TIEU_DE, STT, MS_PT_CTY, MS_PT, TEN_PT, DVT, SL_TON, TRANG)

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

        SqlText = "SELECT     IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, DON_VI_TINH." & TEN_DVT & ",  " & _
                      "SUM(VI_TRI_KHO_VAT_TU.SL_VT) AS SUM_SL_TON " & _
                    "INTO   rptKE_HOACH_TONG_THE_PHU_TUNG_TMP   FROM         IC_PHU_TUNG INNER JOIN " & _
                      "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT INNER JOIN " & _
                      "VI_TRI_KHO_VAT_TU ON IC_PHU_TUNG.MS_PT = VI_TRI_KHO_VAT_TU.MS_PT " & _
                    "WHERE     (IC_PHU_TUNG.MS_PT = '" & gvVTTT.GetFocusedDataRow()("MS_PT") & "') " & _
                    "GROUP BY IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, DON_VI_TINH." & TEN_DVT
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        noDataToPrint = False

        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_DL_IN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
        SqlText = "SELECT  DISTINCT   IC_PHU_TUNG.MS_PT_CTY, IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT, DON_VI_TINH." & TEN_DVT & ",  " & _
                      "(SELECT SUM(SL_VT) FROM VI_TRI_KHO_VAT_TU  WHERE VI_TRI_KHO_VAT_TU.MS_PT=IC_PHU_TUNG.MS_PT) AS SUM_SL_TON " & _
                    "INTO   rptKE_HOACH_TONG_THE_PHU_TUNG_TMP   FROM    KE_HOACH_TONG_CONG_VIEC_PHU_TUNG inner join " & _
                    " IC_PHU_TUNG ON KE_HOACH_TONG_CONG_VIEC_PHU_TUNG.MS_PT =IC_PHU_TUNG.MS_PT INNER JOIN " & _
                      "DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT " & _
                     " WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID")
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        noDataToPrint = False

        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptKE_HOACH_TONG_THE_PHU_TUNG_TMP"))
        If dt.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHONG_DL_IN", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            noDataToPrint = True
        End If


    End Sub
    Private Sub btnLydosuachua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLydosuachua.Click
        If BtnGhi1.Visible Then Exit Sub
        Dim FrmLyDo As Report1.FrmLyDo = New Report1.FrmLyDo()
        If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmLyDo.Name) Then
            FrmLyDo.ShowDialog()
        End If
    End Sub

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


    Sub PrintpreviewBTDK()
        Call ReportPreview("reports\rptBaoTriDinhKy.rpt")
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
    'Sub BindBaoTriTheoThoiGian()
    '    Dim _table As New DataTable
    '    _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, _
    '        "SP_H_GET_BTDK_KHTT_TG", Commons.Modules.UserName, cboDiaDiem_1.SelectedValue, cboHThong.SelectedValue, _
    '        cboLoaiThietBiBTDK.SelectedValue, _
    '        IIf(CboNhomThietBiBTDK.SelectedValue = Nothing, "-1", CboNhomThietBiBTDK.SelectedValue), _
    '        IIf(CboMaSoThietBiBTDK.SelectedValue = Nothing, "-1", CboMaSoThietBiBTDK.SelectedValue), _
    '        Commons.Modules.UserName, _
    '        IIf(cmbCity.SelectedValue = Nothing, "-1", cmbCity.SelectedValue), _
    '        IIf(cmbDistrict.SelectedValue = Nothing, "-1", cmbDistrict.SelectedValue)))


    '    _table.Columns("CHON").ReadOnly = False
    '    gdBTDK_Gio.DataSource = _table
    '    For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvBTDK_Gio.Columns
    '        If col.FieldName = "CHON" Then
    '            col.OptionsColumn.AllowEdit = True
    '            col.OptionsColumn.ReadOnly = False
    '        Else
    '            col.OptionsColumn.ReadOnly = True
    '            col.OptionsColumn.AllowEdit = False
    '            col.Width = 150
    '        End If
    '        col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
    '        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '        col.AppearanceHeader.Options.UseTextOptions = True
    '        col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, col.FieldName, Commons.Modules.TypeLanguage)
    '    Next
    '    gvBTDK_Gio.Columns("MS_LOAI_BT").Visible = False
    '    gvBTDK_Gio.Columns("RUN_TIME").Visible = False
    '    gvBTDK_Gio.Columns("RUN_TIME_HT").Visible = False
    '    gvBTDK_Gio.Columns("MS_NHOM_MAY").Visible = False
    'End Sub


    'Private Sub BtnLapKHTT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strTenHangMuc As String
    '    Dim _dt As New DataTable
    '    Dim _temp As New DataTable()
    '    _dt = CType(gdBTDK_Gio.DataSource, DataTable)
    '    _temp = _dt.Copy()
    '    _temp.DefaultView.RowFilter = "CHON=True"
    '    _temp = _temp.DefaultView.ToTable()
    '    If _temp.Rows.Count = 0 Then
    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT22", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    '        Exit Sub
    '    End If
    '    Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
    '    If objConnection.State = ConnectionState.Closed Then
    '        objConnection.Open()
    '    End If
    '    Dim objTrans As SqlTransaction = objConnection.BeginTransaction
    '    Try
    '        For Each _row In _temp.Rows
    '            strTenHangMuc = "Chuyển từ BTPN " & _row("TEN_LOAI_BT")
    '            'Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_THE(MS_MAY ,	NGAY ,	MS_LOAI_BT ,TEN_HANG_MUC,	LY_DO_SC,NGAY_DK_HT,USERNAME) VALUES(N'" & _row("MS_MAY") & "','" & Format(DateValue(Now), "MM/dd/yyyy") & "'," & _row("MS_LOAI_BT") & ",N'" & strTenHangMuc & "',2,'" & Format(DateValue(Now), "MM/dd/yyyy") & "','" & Commons.Modules.UserName & "')"
    '            'SqlHelper.ExecuteScalar(objTrans, CommandType.Text, Commons.Modules.SQLString)
    '            Dim HANG_MUC_ID As Integer = CType(SqlHelper.ExecuteScalar(objTrans, "InsertKE_HOACH_TONG_THE", _row("MS_MAY"), Format(DateValue(Now), "MM/dd/yyyy"), _row("MS_LOAI_BT"), strTenHangMuc, "2", Format(DateValue(Now), "MM/dd/yyyy"), Commons.Modules.UserName), Integer)
    '            Try
    '                SqlHelper.ExecuteNonQuery(objTrans, "UPDATE_KE_HOACH_TONG_THE_LOG", HANG_MUC_ID, Me.Name, Commons.Modules.UserName, 1)
    '            Catch ex As Exception

    '            End Try


    '            Commons.Modules.SQLString = "SELECT HANG_MUC_ID FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID NOT IN (SELECT HANG_MUC_ID FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY ='" & _row("MS_MAY") & "') AND MS_MAY=N'" & _row("MS_MAY") & "'"

    '            Dim vtb As New DataTable
    '            Dim vtbTam As New DataTable

    '            vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))

    '            For Each vrow As DataRow In vtb.Rows
    '                Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN) SELECT '" & _row("MS_MAY") & "'," & vrow("HANG_MUC_ID").ToString & ", MS_CV,MS_BO_PHAN FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")
    '                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)

    '                Try
    '                    Commons.Modules.SQLString = "SELECT '" & _row("MS_MAY") & "' as MS_MAY ," & vrow("HANG_MUC_ID").ToString & " as HANG_MUC_ID , MS_CV,MS_BO_PHAN FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")
    '                    vtbTam = New DataTable
    '                    vtbTam.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))
    '                    For Each vr As DataRow In vtbTam.Rows
    '                        SqlHelper.ExecuteNonQuery(objTrans, "UPDATE_KE_HOACH_TONG_CONG_VIEC_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), Me.Name, Commons.Modules.UserName, 1)
    '                    Next
    '                Catch ex As Exception

    '                End Try

    '            Next

    '            Commons.Modules.SQLString = "SELECT DISTINCT HANG_MUC_ID,MS_CV,MS_BO_PHAN FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID NOT IN (SELECT HANG_MUC_ID FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE MS_MAY ='" & _row("MS_MAY") & "') AND MS_MAY=N'" & _row("MS_MAY") & "'"
    '            vtb = New DataTable
    '            vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))
    '            For Each vrow As DataRow In vtb.Rows
    '                Commons.Modules.SQLString = "INSERT KE_HOACH_TONG_CONG_VIEC_PHU_TUNG(MS_MAY,HANG_MUC_ID,MS_CV,MS_BO_PHAN,MS_PT,SO_LUONG) SELECT '" & _row("MS_MAY") & "'," & vrow("HANG_MUC_ID").ToString & "," & vrow("MS_CV").ToString & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & vrow("MS_CV").ToString
    '                SqlHelper.ExecuteScalar(objTrans, CommandType.Text, Commons.Modules.SQLString)

    '                Try
    '                    Commons.Modules.SQLString = "SELECT '" & _row("MS_MAY") & "' as MS_MAY ," & vrow("HANG_MUC_ID").ToString & " as HANG_MUC_ID ," & vrow("MS_CV").ToString & " as MS_CV ,MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & vrow("MS_CV").ToString
    '                    vtbTam = New DataTable
    '                    vtbTam.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, Commons.Modules.SQLString))
    '                    For Each vr As DataRow In vtbTam.Rows
    '                        SqlHelper.ExecuteNonQuery(objTrans, "UPDATE_KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_LOG", vr("MS_MAY"), vr("HANG_MUC_ID"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 1)
    '                    Next
    '                Catch ex As Exception

    '                End Try

    '            Next
    '        Next
    '        objTrans.Commit()
    '        objConnection.Close()
    '    Catch ex As Exception
    '        objTrans.Rollback()
    '        objConnection.Close()
    '    End Try
    '    BindBaoTriTheoThoiGian()
    '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT23", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    'End Sub

    'Private Sub BtnLapPBT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim i As Integer = 0
    '    Dim strGioTam, MS_PBT As String
    '    Dim vtbTam As New DataTable

    '    strGioTam = TimeValue(Now)
    '    Dim blnChon As Boolean = False
    '    If IsDBNull(cboNguoiLap1.SelectedValue) Then
    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT22", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    '        cboNguoiLap1.Focus()
    '        Exit Sub
    '    End If
    '    Dim _dt As New DataTable
    '    Dim _temp As New DataTable()
    '    _dt = CType(gdBTDK_Gio.DataSource, DataTable)
    '    _temp = _dt.Copy()
    '    _temp.DefaultView.RowFilter = "CHON=True"
    '    _temp = _temp.DefaultView.ToTable()
    '    If _temp.Rows.Count = 0 Then
    '        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT22", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    '        Exit Sub
    '    End If
    '    For Each _row As DataRow In _temp.Rows
    '        MS_PBT = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI()

    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddPHIEU_BAO_TRI", MS_PBT, _row("MS_MAY"), _row("MS_LOAI_BT"), DateValue(Now), strGioTam.ToString, _row("TEN_LOAI_BT"), 1, DateValue(Now), Me.cboNguoiLap1.SelectedValue, Commons.Modules.UserName, DateValue(Now), DateValue(Now))
    '        Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH) SELECT '" & MS_PBT & "',MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MS_BO_PHAN,THOI_GIAN_DU_KIEN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")
    '        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    '        Try
    '            Commons.Modules.SQLString = "SELECT '" & MS_PBT & "' as MS_PHIEU_BAO_TRI ,MAY_LOAI_BTPN_CONG_VIEC.MS_CV,MS_BO_PHAN,THOI_GIAN_DU_KIEN FROM MAY_LOAI_BTPN_CONG_VIEC INNER JOIN CONG_VIEC ON MAY_LOAI_BTPN_CONG_VIEC.MS_CV=CONG_VIEC.MS_CV WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT")
    '            vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
    '            For Each vr As DataRow In vtbTam.Rows
    '                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_PHIEU_BAO_TRI_CONG_VIEC_LOG", vr("MS_PHIEU_BAO_TRI"), vr("MS_CV"), vr("MS_BO_PHAN"), Me.Name, Commons.Modules.UserName, 1)
    '            Next
    '        Catch ex As Exception

    '        End Try

    '        Commons.Modules.SQLString = "SELECT     dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_CV " & _
    '                "FROM         dbo.CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN " & _
    '            "  dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG ON dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY AND " & _
    '             " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND " & _
    '             "  dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT WHERE dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY ='" & _row("MS_MAY") & "'" & _
    '             "  AND dbo.MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT ='" & _row("MS_LOAI_BT") & "'"
    '        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)


    '        While dtReader.Read
    '            Commons.Modules.SQLString = "INSERT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH) SELECT '" & MS_PBT & "'," & dtReader.Item("MS_CV") & ",MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & dtReader.Item(0)
    '            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
    '            Try
    '                vtbTam = New DataTable
    '                Commons.Modules.SQLString = "SELECT '" & MS_PBT & "' as MS_PHIEU_BAO_TRI ," & dtReader.Item("MS_CV") & " as MS_CV ,MS_BO_PHAN,MS_PT,SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG WHERE MS_MAY=N'" & _row("MS_MAY") & "' AND MS_LOAI_BT=" & _row("MS_LOAI_BT") & " AND MS_CV=" & dtReader.Item(0)
    '                vtbTam.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
    '                For Each vr As DataRow In vtbTam.Rows
    '                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_LOG", vr("MS_PHIEU_BAO_TRI"), vr("MS_CV"), vr("MS_BO_PHAN"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 1)
    '                Next
    '            Catch ex As Exception

    '            End Try

    '        End While
    '        dtReader.Close()
    '        Try
    '            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_TAO_PHIEU_BAO_TRI_THEO_GIO", MS_PBT, _row("MS_MAY"), _row("MS_LOAI_BT"))
    '        Catch ex As Exception
    '        End Try
    '    Next

    '    BindBaoTriTheoThoiGian()
    '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT23", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    'End Sub
    'Private Sub BtnThoat5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Close()
    'End Sub
#End Region

    Private Sub cboLoaiThietBiBTDK_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiThietBiBTDK.SelectionChangeCommitted
        LoadNhomMay()
        LoadMay()
        BindData_Tab()

    End Sub

    Private Sub CboNhomThietBiBTDK_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboNhomThietBiBTDK.SelectionChangeCommitted
        LoadMay()
        BindData_Tab()
    End Sub

    Private Sub CboMaSoThietBiBTDK_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMaSoThietBiBTDK.SelectionChangeCommitted
        BindData_Tab()
    End Sub



    Private Sub gvKHTT_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvKHTT.FocusedRowChanged
        BindDataCV()
        BindDataVTPT()
    End Sub
    Private Sub gvCVTT_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvCVTT.FocusedRowChanged
        BindDataVTPT()
    End Sub

    Private Sub gvCVTT_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvCVTT.CellValueChanged
        Dim name As String = e.Column.FieldName
        Dim dr As DataRow
        dr = dtTable_CV_TEMP.NewRow()
        If RadBoQua1.Checked Then
            Select Case name
                Case "KHONG_GQ", "THUE_NGOAI"
                    dr("MS_CV") = gvCVTT.GetFocusedDataRow()("MS_CV")
                    dr("MS_BO_PHAN") = gvCVTT.GetFocusedDataRow()("MS_BO_PHAN")
                    dr("HANG_MUC_ID") = gvCVTT.GetFocusedDataRow()("HANG_MUC_ID")
                    dr("MS_MAY") = gvCVTT.GetFocusedDataRow()("MS_MAY")
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
            Dim _ms_hang_muc As Integer
            Dim _ms_may As String
            Dim _kgv As Integer = 0
            Dim _tn As Integer = 0

            Dim hmcv_tu_ngay As DateTime
            Dim hmcv_den_ngay As DateTime
            Dim hmcv_CP_VT_NN_NGOAI_DM As Double = 0
            Dim hmcv_CP_VT_NGOAI_DM As Double = 0
            Dim hmcv_CP_THUE_NGOAI As Double = 0
            Dim hmcv_TG_KH As Double = 0

            Select Case name
                Case "KHONG_GQ", "THUE_NGOAI", "GHI_CHU", "MS_UU_TIEN", "TU_NGAY", "DEN_NGAY", "CP_VT_NN_NGOAI_DM", "CP_VT_NGOAI_DM", "CP_THUE_NGOAI", "TG_KH"
                    _khong_gq = gvCVTT.GetFocusedDataRow()("KHONG_GQ")
                    _thue_ngoai = gvCVTT.GetFocusedDataRow()("THUE_NGOAI")
                    _ghi_chu_temp = Convert.ToString(gvCVTT.GetFocusedDataRow()("GHI_CHU"))
                    If String.IsNullOrEmpty(Convert.ToString(gvCVTT.GetFocusedDataRow()("MS_UU_TIEN"))) = False Then
                        _utien = gvCVTT.GetFocusedDataRow()("MS_UU_TIEN")
                    End If

                    _ms_cv = gvCVTT.GetFocusedDataRow("MS_CV")
                    _ms_bp = gvCVTT.GetFocusedDataRow("MS_BO_PHAN")
                    _ms_hang_muc = gvCVTT.GetFocusedDataRow("HANG_MUC_ID")
                    _ms_may = gvCVTT.GetFocusedDataRow("MS_MAY")

                    If IsDBNull(gvCVTT.GetFocusedDataRow()("CP_VT_NN_NGOAI_DM")) = False Then
                        Double.TryParse(gvCVTT.GetFocusedDataRow("CP_VT_NN_NGOAI_DM"), hmcv_CP_VT_NN_NGOAI_DM)
                    End If
                    If IsDBNull(gvCVTT.GetFocusedDataRow()("CP_VT_NGOAI_DM")) = False Then
                        Double.TryParse(gvCVTT.GetFocusedDataRow("CP_VT_NGOAI_DM"), hmcv_CP_VT_NGOAI_DM)
                    End If
                    If IsDBNull(gvCVTT.GetFocusedDataRow()("CP_THUE_NGOAI")) = False Then
                        Double.TryParse(gvCVTT.GetFocusedDataRow("CP_THUE_NGOAI"), hmcv_CP_THUE_NGOAI)
                    End If
                    If IsDBNull(gvCVTT.GetFocusedDataRow()("TG_KH")) = False Then
                        Double.TryParse(gvCVTT.GetFocusedDataRow("TG_KH"), hmcv_TG_KH)
                    End If

                    If IsDBNull(gvCVTT.GetFocusedDataRow()("TU_NGAY")) = False Then
                        DateTime.TryParse(gvCVTT.GetFocusedDataRow("TU_NGAY"), hmcv_tu_ngay)
                    End If

                    If IsDBNull(gvCVTT.GetFocusedDataRow()("DEN_NGAY")) = False Then
                        DateTime.TryParse(gvCVTT.GetFocusedDataRow("DEN_NGAY"), hmcv_den_ngay)
                    End If

                    If _khong_gq = True Then
                        _kgv = 1
                    End If
                    If _thue_ngoai = True Then
                        _tn = 1
                    End If

                    sql = "UPDATE KHTCV_TMP" & Commons.Modules.UserName & " SET KHONG_GQ=" & _kgv & ", THUE_NGOAI=" & _tn & _
                    ", MS_UU_TIEN = " & _utien & ", GHI_CHU='" & _ghi_chu_temp & "', CP_VT_NN_NGOAI_DM='" & hmcv_CP_VT_NN_NGOAI_DM & "', " & _
                    " CP_VT_NGOAI_DM='" & hmcv_CP_VT_NGOAI_DM & "', CP_THUE_NGOAI='" & hmcv_CP_THUE_NGOAI & "' , TG_KH ='" & hmcv_TG_KH & "'" & _
                    " WHERE MS_MAY ='" & _ms_may & "' AND MS_CV=" & _ms_cv & " AND MS_BO_PHAN ='" & _ms_bp & "' AND HANG_MUC_ID=" & _ms_hang_muc
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                    dtTable_CV_TEMP.Columns("THUE_NGOAI").ReadOnly = False
                    dtTable_CV_TEMP.Columns("KHONG_GQ").ReadOnly = False
                    dtTable_CV_TEMP.Columns("MS_UU_TIEN").ReadOnly = False
                    dtTable_CV_TEMP.Columns("GHI_CHU").ReadOnly = False
                    dtTable_CV_TEMP.Columns("CP_VT_NN_NGOAI_DM").ReadOnly = False
                    dtTable_CV_TEMP.Columns("CP_VT_NGOAI_DM").ReadOnly = False
                    dtTable_CV_TEMP.Columns("CP_THUE_NGOAI").ReadOnly = False
                    dtTable_CV_TEMP.Columns("TG_KH").ReadOnly = False
                    dtTable_CV_TEMP.Columns("TU_NGAY").ReadOnly = False
                    dtTable_CV_TEMP.Columns("DEN_NGAY").ReadOnly = False
                    Dim _datarow() As DataRow = dtTable_CV_TEMP.Select("MS_CV='" & _ms_cv & "' AND MS_BO_PHAN='" & _ms_bp & "' AND HANG_MUC_ID='" & _ms_hang_muc & "'")
                    If _datarow.Length > 0 Then
                        _datarow(0)("THUE_NGOAI") = _thue_ngoai
                        _datarow(0)("KHONG_GQ") = _khong_gq
                        _datarow(0)("MS_UU_TIEN") = _utien
                        _datarow(0)("GHI_CHU") = _ghi_chu_temp
                        _datarow(0)("CP_VT_NN_NGOAI_DM") = hmcv_CP_VT_NN_NGOAI_DM
                        _datarow(0)("CP_VT_NGOAI_DM") = hmcv_CP_VT_NGOAI_DM
                        _datarow(0)("CP_THUE_NGOAI") = hmcv_CP_THUE_NGOAI
                        _datarow(0)("TU_NGAY") = hmcv_tu_ngay
                        _datarow(0)("DEN_NGAY") = hmcv_den_ngay
                        _datarow(0)("TG_KH") = hmcv_TG_KH
                    Else
                        dr("MS_CV") = _ms_cv
                        dr("MS_BO_PHAN") = _ms_bp
                        dr("HANG_MUC_ID") = _ms_hang_muc
                        dr("THUE_NGOAI") = _thue_ngoai
                        dr("KHONG_GQ") = _khong_gq
                        dr("MS_UU_TIEN") = _utien
                        dr("GHI_CHU") = _ghi_chu_temp
                        dr("MS_MAY") = _ms_may

                        dr("TG_KH") = hmcv_TG_KH
                        dr("CP_VT_NN_NGOAI_DM") = hmcv_CP_VT_NN_NGOAI_DM
                        dr("CP_VT_NGOAI_DM") = hmcv_CP_VT_NGOAI_DM
                        dr("CP_THUE_NGOAI") = hmcv_CP_THUE_NGOAI
                        dr("TU_NGAY") = hmcv_tu_ngay
                        dr("DEN_NGAY") = hmcv_den_ngay
                        dtTable_CV_TEMP.Rows.Add(dr)
                    End If
            End Select
        End If
        CapNhapKeHoach("USERNAME")

    End Sub
    Private Sub CapNhapKeHoach(ByVal sFieldName As String)
        If Commons.Modules.SQLString = "0load" Then Exit Sub
        Dim str As String = sFieldName
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

        dr("MS_UU_TIEN") = gvKHTT.GetFocusedDataRow()("MS_UU_TIEN")
        dr("CP_VT_NN_NGOAI_DM") = gvKHTT.GetFocusedDataRow()("CP_VT_NN_NGOAI_DM")
        dr("CP_VT_NGOAI_DM") = gvKHTT.GetFocusedDataRow()("CP_VT_NGOAI_DM")
        dr("CP_THUE_NGOAI") = gvKHTT.GetFocusedDataRow()("CP_THUE_NGOAI")
        dr("USERNAME") = Commons.Modules.UserName

        Dim dKT As Double = 0
        Try
            dKT = Convert.ToDouble(gvKHTT.GetFocusedDataRow()("PT_HTHANH").ToString)
        Catch ex As Exception

        End Try
        If dKT < 0 Or dKT > 100 Then
            Commons.Modules.SQLString = "0load"
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgPTHoanThanhPhaiLonhon0NhoHon100", Commons.Modules.TypeLanguage), MsgBoxStyle.Information)
            gvKHTT.SetFocusedRowCellValue("PT_HTHANH", 0)
            Commons.Modules.SQLString = ""
        End If
        dr("PT_HTHANH") = gvKHTT.GetFocusedDataRow()("PT_HTHANH")

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
                Case "CP_VT_NN_NGOAI_DM"
                    _datarow(0)("CP_VT_NN_NGOAI_DM") = gvKHTT.GetFocusedDataRow()("CP_VT_NN_NGOAI_DM")
                Case "CP_VT_NGOAI_DM"
                    _datarow(0)("CP_VT_NGOAI_DM") = gvKHTT.GetFocusedDataRow()("CP_VT_NGOAI_DM")
                Case "CP_THUE_NGOAI"
                    _datarow(0)("CP_THUE_NGOAI") = gvKHTT.GetFocusedDataRow()("CP_THUE_NGOAI")
                Case "PT_HTHANH"
                    _datarow(0)("PT_HTHANH") = gvKHTT.GetFocusedDataRow()("PT_HTHANH")
                Case "PT_HTHANH"
                    _datarow(0)("PT_HTHANH") = gvKHTT.GetFocusedDataRow()("PT_HTHANH")
                Case "USERNAME"
                    _datarow(0)("USERNAME") = Commons.Modules.UserName
            End Select
        Else
            dtTable_KHTT_TEMP.Rows.Add(dr)
        End If
    End Sub

    Private Sub gvKHTT_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvKHTT.CellValueChanged
        If blnThemSua = True Then
            CapNhapKeHoach(e.Column.FieldName)
        End If

    End Sub

    Private Sub btnChonMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonMay.Click
        FrmChonMayChoKHTT.loai_may = cboLoaiThietBiBTDK.SelectedValue
        FrmChonMayChoKHTT.nhom_may = CboNhomThietBiBTDK.SelectedValue
        Dim _table_chon_may As New DataTable
        Dim _table_KHTT As New DataTable
        If FrmChonMayChoKHTT.ShowDialog() = Windows.Forms.DialogResult.OK Then
            _table_chon_may = FrmChonMayChoKHTT.dtMay
            _table_KHTT = CType(gvKHTT.DataSource, DataView).ToTable()
            For Each col As DataColumn In _table_KHTT.Columns
                col.AllowDBNull = True
            Next

            ' ID_KE_HOACH_BAO_TRI()

            Dim dr As DataRow
            Dim dr1 As DataRow
            For Each _row In _table_chon_may.Rows
                dr = _table_KHTT.NewRow()
                dr1 = dtTable_KHTT_TEMP.NewRow()
                'j = j + 1
                j = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GET_ID_HANG_MUC", Commons.Modules.UserName))

                dr("MS_MAY") = _row("MS_MAY")
                dr("TEN_MAY") = _row("TEN_MAY")
                dr("HANG_MUC_ID") = j
                dr("NGAY") = Date.Now
                dr("NGAY_DK_HT") = Date.Now
                dr("LY_DO_SC") = -1
                _table_KHTT.Rows.InsertAt(dr, 0)

                dr1("MS_MAY") = _row("MS_MAY")
                dr1("TEN_MAY") = _row("TEN_MAY")
                dr1("HANG_MUC_ID") = j
                dr1("NGAY") = Date.Now
                dr1("NGAY_DK_HT") = Date.Now
                dr1("LY_DO_SC") = -1
                dtTable_KHTT_TEMP.Rows.Add(dr1)
                '_DataHangMucNew.Rows.Add(j, 0)
            Next
            gdKHTT.DataSource = _table_KHTT
            count = gvKHTT.RowCount
            BindDataCV()
            BindDataVTPT()

        End If
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
        CapNhapKeHoach("USERNAME")
    End Sub
    Private Sub BindData_Tab()
        LoadData()
    End Sub

    Private Sub gdKHTT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gdKHTT.KeyDown
        If blnThemSua = False Then
            If e.KeyCode = Keys.Delete Then

                Dim _NAM As Integer
                Dim _THANG As Integer

                If cbKHType.SelectedValue.ToString() = "1" Then
                    _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                    _THANG = 0
                    KHType = "1"
                ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                    _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                    _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                    KHType = "2"
                End If

                'Ktra duyet 
                'ktra copy 
                Dim _vtbTmp As New DataTable
                _vtbTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_CHECK_DATA_BEFORE_DELETE_HM", KHType, _NAM, _THANG, gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")))

                If CType(_vtbTmp.Rows(0)("DUYET"), Boolean) = True Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_KH_DA_DUYET_KO_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If CType(_vtbTmp.Rows(0)("ID_COPY"), Int32) <> 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_KH_DA_CHUYEN_KO_XOA_CHUOT_PHAI_XEM_CHI_TIET", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If


                Dim strTraloi As String
                If gvKHTT.RowCount <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT14", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Commons.Modules.SQLString = "SELECT * FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND (MS_PHIEU_BAO_TRI IS NOT NULL OR EOR_ID IS NOT NULL)"
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT36", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    dtReader.Close()
                    Exit Sub
                End While
                dtReader.Close()
                Dim tran As SqlTransaction
                Dim con As New SqlConnection(Commons.IConnections.ConnectionString)

                If gvCVTT.RowCount > 0 Then
                    strTraloi = MsgBox("Kế hoạch này đang tồn tại công việc, chọn YES nếu bạn muốn xóa nó và tất cả công việc, phụ tùng đi theo nó, chọn NO nếu bạn muốn quay về màn hình chính ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Thông báo ")
                    If strTraloi = vbNo Then Exit Sub
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try

                        Dim _vtbCheck1 As New DataTable
                        Commons.Modules.SQLString = " SELECT COUNT(MA_HANG_MUC) AS SL2 FROM KE_HOACH_TONG_THE_CHI_TIET WHERE MA_HANG_MUC = '" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & "' "
                        _vtbCheck1.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))

                        Dim isDeleteMaster As Boolean = False
                        If _vtbCheck1.Rows(0)("SL2").ToString() = "1" Then
                            isDeleteMaster = True
                        End If

                        If isDeleteMaster = True Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE  HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        End If

                        ' xoa chi tiet
                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE  HANG_MUC_ID= " & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND KH_TYPE = '1' AND KH_NAM = '" & _NAM & "'"
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE  HANG_MUC_ID= " & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND KH_TYPE = '2' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "'"
                        End If

                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                        If isDeleteMaster = True Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        End If
                        'Xoa khbt chi tiet
                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE  MA_HANG_MUC=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND KH_TYPE = '1' AND KH_NAM = '" & _NAM & "'"
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE  MA_HANG_MUC=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND KH_TYPE = '2' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "'"
                        End If
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE_CHI_TIET WHERE  MA_HANG_MUC=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND KH_TYPE = '1' AND KH_NAM = '" & _NAM & "'"
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE_CHI_TIET WHERE  MA_HANG_MUC=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND KH_TYPE = '2' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "'"
                        End If
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                        Try
                            If isDeleteMaster = True Then
                                Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED,0) DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED)"
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                            End If
                        Catch ex As Exception
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT19", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
                    strTraloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT17", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo)
                    If strTraloi = vbNo Then Exit Sub
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try

                        'Xoa khbt chi tiet

                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE  MA_HANG_MUC=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE_CHI_TIET WHERE  MA_HANG_MUC=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

                        Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_THE WHERE HANG_MUC_ID=" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & " DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED,0) DBCC CHECKIDENT (KE_HOACH_TONG_THE,RESEED)"
                        SqlHelper.ExecuteScalar(tran, CommandType.Text, Commons.Modules.SQLString)
                        tran.Commit()
                        con.Close()
                        LoadData()
                    Catch ex As Exception
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT19", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
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
                Dim strTraloi As String

                Dim _NAM As Integer
                Dim _THANG As Integer

                If cbKHType.SelectedValue.ToString() = "1" Then
                    _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                    _THANG = 0
                    KHType = "1"
                ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                    _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                    _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                    KHType = "2"
                End If

                'Ktra duyet 
                'ktra copy 
                'ktra pbt 
                Dim _vtbTmp As New DataTable
                _vtbTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_CHECK_DATA_BEFORE_DELETE_HM_CV", KHType, _NAM, _THANG, _
                        gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), gvCVTT.GetFocusedDataRow()("MS_CV"), gvCVTT.GetFocusedDataRow()("MS_BO_PHAN")))

                If CType(_vtbTmp.Rows(0)("DUYET"), Boolean) = True Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_CV_DA_DUYET_KO_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If CType(_vtbTmp.Rows(0)("ID_COPY"), Int32) <> 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_CV_DA_CHUYEN_KO_XOA_CHUOT_PHAI_XEM_CHI_TIET", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If CType(_vtbTmp.Rows(0)("MSPBT"), String) <> "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgDaCoPhieuBaoTriKhongTheXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If gvKHTT.RowCount <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT14", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Dim tran As SqlTransaction
                Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
                If gvVTTT.RowCount > 0 Then
                    strTraloi = MsgBox("Công việc này đang tồn tại phụ tùng, chọn YES nếu bạn muốn xóa công việc này và tất cả phụ tùng của nó, chọn NO nếu bạn muốn quay lại màn hình chính", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Thông báo")
                    If strTraloi = vbNo Then Exit Sub
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try

                        Dim _vtbCheck1 As New DataTable
                        Commons.Modules.SQLString = "SELECT COUNT(MA_CV) AS SL2 FROM  KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE MS_MAY = N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND MA_HANG_MUC = " & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MA_BO_PHAN = '" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MA_CV = '" & gvCVTT.GetFocusedDataRow()("MS_CV") & "'"
                        _vtbCheck1.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))

                        Dim isDeleteMaster As Boolean = False
                        If _vtbCheck1.Rows(0)("SL2").ToString() = "1" Then
                            isDeleteMaster = True
                        End If

                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND HANG_MUC_ID=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV= " & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND KH_TYPE = '1'  AND KH_NAM ='" & _NAM & "' "
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND HANG_MUC_ID=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV= " & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND KH_TYPE = '2'  AND KH_NAM ='" & _NAM & "'  AND KH_THANG = '" & _THANG & "'"
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        End If

                        If isDeleteMaster Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND HANG_MUC_ID=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        End If

                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND MA_HANG_MUC=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MA_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MA_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND KH_TYPE = '1' AND  KH_NAM = '" & _NAM & "'"
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND MA_HANG_MUC=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MA_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MA_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND KH_TYPE = '2' AND  KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "' "
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        End If

                        tran.Commit()
                        con.Close()
                        BindDataCV()
                        BindDataVTPT()
                    Catch ex As Exception
                        tran.Rollback()
                        con.Close()
                    End Try
                Else
                    strTraloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT17", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo)
                    If strTraloi = vbNo Then Exit Sub
                    If strTraloi = vbNo Then Exit Sub
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try
                        Dim _vtbCheck1 As New DataTable
                        Commons.Modules.SQLString = "SELECT COUNT(MA_CV) AS SL2 FROM  KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE MS_MAY = N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND MA_HANG_MUC = " & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MA_BO_PHAN = '" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND MA_CV = '" & gvCVTT.GetFocusedDataRow()("MS_CV") & "'"
                        _vtbCheck1.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))

                        Dim isDeleteMaster As Boolean = False
                        If _vtbCheck1.Rows(0)("SL2").ToString() = "1" Then
                            isDeleteMaster = True
                        End If

                        If isDeleteMaster Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND HANG_MUC_ID=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MS_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "'"
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        End If

                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND MA_HANG_MUC=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MA_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MA_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND KH_TYPE = '1' AND  KH_NAM = '" & _NAM & "'"
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_CHI_TIET WHERE MS_MAY=N'" & gvCVTT.GetFocusedDataRow()("MS_MAY") & "' AND MA_HANG_MUC=" & gvCVTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MA_CV=" & gvCVTT.GetFocusedDataRow()("MS_CV") & " AND MA_BO_PHAN='" & gvCVTT.GetFocusedDataRow()("MS_BO_PHAN") & "' AND KH_TYPE = '2' AND  KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "' "
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
                        End If

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

                Dim _NAM As Integer
                Dim _THANG As Integer

                If cbKHType.SelectedValue.ToString() = "1" Then
                    _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                    _THANG = 0
                    KHType = "1"
                ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                    _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                    _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                    KHType = "2"
                End If

                'Ktra duyet 
                'ktra copy 
                Dim _vtbTmp As New DataTable
                _vtbTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_CHECK_DATA_BEFORE_DELETE_HM_CV", KHType, _NAM, _THANG, gvKHTT.GetFocusedDataRow()("HANG_MUC_ID"), gvCVTT.GetFocusedDataRow()("MS_CV"), gvCVTT.GetFocusedDataRow()("MS_BO_PHAN")))

                If CType(_vtbTmp.Rows(0)("DUYET"), Boolean) = True Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_CV_DA_DUYET_KO_XOA", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                If CType(_vtbTmp.Rows(0)("ID_COPY"), Int32) <> 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_CV_DA_CHUYEN_KO_XOA_CHUOT_PHAI_XEM_CHI_TIET", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If


                If gvVTTT.RowCount <= 0 Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT14", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
                Dim tran As SqlTransaction
                strTraloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT15", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNoCancel)
                If strTraloi = vbCancel Then
                    Exit Sub
                ElseIf strTraloi = vbYes Then
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    tran = con.BeginTransaction()
                    Try

                        'Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvVTTT.GetFocusedDataRow()("MS_CV")

                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvVTTT.GetFocusedDataRow()("MS_CV") & " AND KH_TYPE = '1' AND KH_NAM = '" & _NAM & "'"
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvVTTT.GetFocusedDataRow()("MS_CV") & " AND KH_TYPE = '2' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "'"
                        End If

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
                        If KHType = "1" Then
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvVTTT.GetFocusedDataRow()("MS_CV") & " AND MS_PT='" & gvVTTT.GetFocusedDataRow()("MS_PT") & "' AND MS_BO_PHAN='" & gvVTTT.GetFocusedDataRow()("MS_BO_PHAN") & "'" & " AND KH_TYPE = '1' AND KH_NAM = '" & _NAM & "'"
                        Else
                            Commons.Modules.SQLString = "DELETE FROM KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE HANG_MUC_ID=" & gvVTTT.GetFocusedDataRow()("HANG_MUC_ID") & " AND MS_CV=" & gvVTTT.GetFocusedDataRow()("MS_CV") & " AND MS_PT='" & gvVTTT.GetFocusedDataRow()("MS_PT") & "' AND MS_BO_PHAN='" & gvVTTT.GetFocusedDataRow()("MS_BO_PHAN") & "'" & " AND KH_TYPE = '2' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "'"
                        End If

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

    Private Sub LoadCity()
        Try
            cmbCity.Value = "ma_qg"
            cmbCity.Display = "ten_qg"
            cmbCity.StoreName = "S_Tinh"
            cmbCity.BindDataSource()
            LoadDistrict()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadDistrict()
        Try
            cmbDistrict.Value = "ma_qg"
            cmbDistrict.Display = "ten_qg"
            cmbDistrict.StoreName = "S_District"
            cmbDistrict.Param = cmbCity.SelectedValue.ToString()
            cmbDistrict.BindDataSource()
        Catch ex As Exception

        End Try

    End Sub

    Sub LoadcboDiadiem()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), "-1"))
        cboDiaDiem_1.DisplayMember = "TEN_N_XUONG"
        cboDiaDiem_1.ValueMember = "MS_N_XUONG"
        cboDiaDiem_1.DataSource = _table
        LoadcboDayChuyen()
    End Sub

    Sub LoadcboDayChuyen()
        Dim _table As DataTable = New DataTable()
        table = Commons.Modules.ObjSystems.MLoadDataDayChuyen(1)
        cboHThong.DisplayMember = "TEN_HE_THONG"
        cboHThong.ValueMember = "MS_HE_THONG"
        cboHThong.DataSource = _table
    End Sub

    Private Sub cmbCity_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCity.SelectionChangeCommitted
        LoadDistrict()
        LoadcboDiadiem()

        BindData_Tab()
    End Sub

    Private Sub cmbDistrict_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectionChangeCommitted
        LoadcboDiadiem()
        BindData_Tab()
    End Sub

    Private Sub cboDiaDiem_1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDiaDiem_1.SelectionChangeCommitted, cboHThong.SelectionChangeCommitted
        BindData_Tab()
    End Sub

    Private Sub btnLPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLPBT.Click
        If gvKHTT.RowCount = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongCoDuLieuLapPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
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
            frm.dNBDKH = Now.Date
        End Try
        Try
            frm.dNKTKH = gvKHTT.GetFocusedRowCellValue("NGAY_DK_HT")
        Catch ex As Exception
            frm.dNKTKH = Now.Date
        End Try

        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If


        If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim sNLap, sNGSat As String
        Dim iLBT As Integer = Convert.ToInt32(Commons.Modules.SQLString)
        sNLap = frm.sNLap
        sNGSat = frm.sNGSat
        iLBT = frm.iLoaiBT
        If iLBT = -1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuaChonLBT", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If sNLap = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuaChonNLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If sNGSat = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuaChonNGSat", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName)
        Dim strGioTam As String = TimeValue(Now)
        Dim sBT, sSql As String
        Dim dtTmp As New DataTable

        sBT = "LPBTCV" & Commons.Modules.UserName
        dtTmp = CType(gdCVTT.DataSource, DataTable)
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "")

        Dim NGAY_BTPN, NGAY_BD_KH, NGAY_KT_KH As Date
        Try
            NGAY_BTPN = gvKHTT.GetFocusedRowCellValue("NGAY_BTPN")
        Catch ex As Exception
            NGAY_BTPN = "01/01/1900"
        End Try

        Try
            NGAY_BD_KH = frm.dNBDKH 'gvKHTT.GetFocusedRowCellValue("NGAY")
        Catch ex As Exception
            NGAY_BD_KH = "01/01/1900"
        End Try
        Try
            NGAY_KT_KH = frm.dNKTKH 'gvKHTT.GetFocusedRowCellValue("NGAY_DK_HT")
        Catch ex As Exception
            NGAY_KT_KH = "01/01/1900"
        End Try
        Dim MS_PBT As String = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(NGAY_BD_KH.Year, NGAY_BD_KH.Month)

        Dim tran As SqlTransaction
        Dim con As New SqlConnection(Commons.IConnections.ConnectionString)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        tran = con.BeginTransaction()
        Try
            'Add Phieu Bao Tri
            SqlHelper.ExecuteNonQuery(tran, "AddPHIEU_BAO_TRI", MS_PBT, gvKHTT.GetFocusedDataRow()("MS_MAY"), _
                iLBT, DateValue(Now), strGioTam.ToString, gvKHTT.GetFocusedDataRow()("TEN_HANG_MUC"), 1, _
                IIf(NGAY_BTPN = "01/01/1900", Nothing, NGAY_BTPN), sNLap, Commons.Modules.UserName, _
                IIf(NGAY_BD_KH = "01/01/1900", Nothing, NGAY_BD_KH), IIf(NGAY_KT_KH = "01/01/1900", Nothing, NGAY_KT_KH), _
                sNGSat, gvKHTT.GetFocusedDataRow()("MS_UU_TIEN"))
            'Add cong viec

            sSql = " INSERT PHIEU_BAO_TRI_CONG_VIEC (MS_PHIEU_BAO_TRI,HANG_MUC_ID, MS_CV, MS_BO_PHAN, SO_GIO_KH) " & _
                        " SELECT '" & MS_PBT & "','" & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & "' AS HANG_MUC_ID, A.MS_CV, A.MS_BO_PHAN, A.TG_KH FROM " & sBT & " AS A INNER JOIN " & _
                        " dbo.CONG_VIEC AS B ON A.MS_CV = B.MS_CV WHERE     (ISNULL(A.MS_PHIEU_BAO_TRI,'') = '') " & _
                        " AND (A.KHONG_GQ = 0) "
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)
            'Add cong viec phu tung
            sSql = "INSERT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH) " & _
                        "SELECT '" & MS_PBT & "', MS_CV, MS_BO_PHAN, MS_PT, SO_LUONG FROM dbo.KE_HOACH_TONG_CONG_VIEC_PHU_TUNG_CHI_TIET A " & _
                        " WHERE (MS_MAY = N'" & gvKHTT.GetFocusedDataRow()("MS_MAY") & "') " & _
                        " AND KH_TYPE = '2' AND KH_NAM = '" & _NAM & "' AND KH_THANG = '" & _THANG & "' " & _
                        " AND (HANG_MUC_ID = " & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & ")" & _
                        " AND EXISTS ( SELECT * FROM " & sBT & " B WHERE A.MS_CV = B.MS_CV  AND A.MS_BO_PHAN = B.MS_BO_PHAN ) "
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)

            ' Update vao KE_HOACH_TONG_CONG_VIEC 
            sSql = " UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI = N'" & MS_PBT & "' FROM KE_HOACH_TONG_CONG_VIEC A " & _
                        " WHERE (MS_MAY = N'" & gvKHTT.GetFocusedDataRow()("MS_MAY") & "') " & _
                        " AND (HANG_MUC_ID = " & gvKHTT.GetFocusedDataRow()("HANG_MUC_ID") & ")" & _
                        " AND EXISTS ( SELECT * FROM " & sBT & " B WHERE A.MS_CV = B.MS_CV  AND A.MS_BO_PHAN = B.MS_BO_PHAN ) "
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql)


            ' cap nhap vi tri
            Commons.Modules.SQLString = "SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV, " & _
                    "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, " & _
                    "0 AS SL_KH, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT " & _
                    "INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName & " " & _
                    "FROM         CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN " & _
                    "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON " & _
                    "CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN And " & _
                    "CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT INNER JOIN " & _
                    "MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG ON " & _
                    "CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_MAY And " & _
                    "CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_BO_PHAN And " & _
                    "CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_PT INNER JOIN " & _
                    "PHIEU_BAO_TRI ON MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG.MS_LOAI_BT = PHIEU_BAO_TRI.MS_LOAI_BT AND " & _
                    "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " & _
                    "WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI='" & MS_PBT & "'"
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)

            Dim dtTmp1 As New DataTable
            Dim dtReaderTam As SqlDataReader
            Dim iSL_BTPN As Integer = 0, iSL_CTTB As Integer = 0
            Dim iSL_KH As Integer = 0

            'dtReader = SqlHelper.ExecuteReader(tran, CommandType.Text, _
            '    "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName)

            dtTmp1.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT " & _
                                " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName))
            'While dtReader.Read
            For Each dr As DataRow In dtTmp1.Rows
                'lay so luong can thuc hien cho phu tung trong lich bao tri dinh ky
                'Commons.Modules.SQLString = "SELECT ISNULL(SO_LUONG,0) AS SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG " & _
                '        " WHERE MS_MAY=N'" & gvKHTT.GetFocusedDataRow()("MS_MAY") & "' AND MS_CV=" & dtReader.Item("MS_CV") & _
                '        " AND MS_BO_PHAN='" & dtReader.Item("MS_BO_PHAN") & "' AND MS_PT='" & dtReader.Item("MS_PT") & "'"
                Commons.Modules.SQLString = "SELECT ISNULL(SO_LUONG,0) AS SO_LUONG FROM MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG " & _
                        " WHERE MS_MAY=N'" & gvKHTT.GetFocusedDataRow()("MS_MAY") & "' AND MS_CV=" & dr("MS_CV") & _
                        " AND MS_BO_PHAN='" & dr("MS_BO_PHAN") & "' AND MS_PT='" & dr("MS_PT") & "'"
                dtReaderTam = SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString)
                While dtReaderTam.Read
                    iSL_BTPN = dtReaderTam.Item("SO_LUONG")
                End While
                dtReaderTam.Close()

                'lay so luong tren tung vi tri cua phu tung trong cau truc thiet bi
                Commons.Modules.SQLString = "SELECT MS_MAY,MS_BO_PHAN,MS_PT, SUM(SO_LUONG) AS SL_TAT_CA_VI_TRI FROM CAU_TRUC_THIET_BI_PHU_TUNG " & _
                        " WHERE MS_MAY=N'" & gvKHTT.GetFocusedDataRow()("MS_MAY") & "' AND MS_BO_PHAN='" & dr("MS_BO_PHAN") & "' " & _
                        " AND MS_PT='" & dr("MS_PT") & "' GROUP BY MS_MAY,MS_BO_PHAN,MS_PT"
                dtReaderTam = SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString)
                While dtReaderTam.Read
                    iSL_CTTB = dtReaderTam.Item("SL_TAT_CA_VI_TRI")
                End While
                dtReaderTam.Close()

                'tim so luong tren tung vi tri co bao nhieu do so luong ben btnpn sang cho hop le
                'dtReaderTam = SqlHelper.ExecuteReader(tran, CommandType.Text, _
                '" SELECT * FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE MS_MAY=N'" & gvKHTT.GetFocusedDataRow()("MS_MAY") & "' " & _
                '" AND MS_BO_PHAN='" & dr("MS_BO_PHAN") & "' AND MS_PT='" & dr("MS_PT") & "'")
                Dim dtTmp2 As New DataTable
                dtTmp2.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, " SELECT * FROM CAU_TRUC_THIET_BI_PHU_TUNG WHERE ACTIVE = 1 AND MS_MAY=N'" & gvKHTT.GetFocusedDataRow()("MS_MAY") & "' " &
                        " AND MS_BO_PHAN='" & dr("MS_BO_PHAN") & "' AND MS_PT='" & dr("MS_PT") & "'"))


                'While dtReaderTam.Read And iSL_BTPN > 0
                For Each dr1 As DataRow In dtTmp2.Rows
                    If iSL_BTPN > 0 Then
                        iSL_KH = iSL_BTPN - dr1("SO_LUONG")
                        If iSL_KH <= 0 Then
                            iSL_KH = dr1("SO_LUONG")
                        ElseIf iSL_KH > dr1("SO_LUONG") Then
                            iSL_KH = dr1("SO_LUONG")
                        End If
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, _
                            "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName & " SET SL_KH=" & iSL_KH & _
                            " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' AND MS_CV=" & dr("MS_CV") & " AND " & _
                            " MS_BO_PHAN='" & dr("MS_BO_PHAN") & "' AND MS_PT='" & dr("MS_PT") & "' " & _
                            " AND MS_VI_TRI_PT='" & dr1("MS_VI_TRI_PT") & "'")
                        iSL_BTPN -= dr1("SO_LUONG")
                        'End While
                    Else
                        Exit For
                    End If
                Next

                dtReaderTam.Close()
            Next

            Commons.Modules.SQLString = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET " & _
                    " (MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, SL_KH, MS_VI_TRI_PT)" & _
                    " SELECT DISTINCT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName & " WHERE SL_KH>0"
            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, Commons.Modules.SQLString)
            'CAP NHAT LAI SO LUONG CHO  BANG CHA
            Commons.Modules.SQLString = "SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SUM(SL_KH) AS SL_TONG FROM " & _
                    " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' " & _
                    " GROUP BY MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT"
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString))
            For Each dr2 As DataRow In dtTmp.Rows
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH=" & dr2("SL_TONG") & _
                    " WHERE MS_PHIEU_BAO_TRI='" & MS_PBT & "' AND MS_CV=" & dr2("MS_CV") & _
                    " AND MS_BO_PHAN='" & dr2("MS_BO_PHAN") & "' AND MS_PT='" & dr2("MS_PT") & "'")
            Next


            tran.Commit()
            con.Close()
            BindData_Tab()
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenKT23", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhongThanhCong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            tran.Rollback()
            con.Close()
        End Try
        Commons.Modules.ObjSystems.XoaTable(sBT)
        Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET123" & Commons.Modules.UserName)

    End Sub

    Private Sub cbKHType_SelectedValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub cbKHNNam_SelectedValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub cbKHTNam_SelectedValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub cbKHTThang_SelectedValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
    End Sub

    Private Sub btnDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuyet.Click
        Dim _diaDiem As String = ""
        _diaDiem = cboDiaDiem_1.SelectedValue
        Dim _msg1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_CO_CHAC_D_TREN_DD", Commons.Modules.TypeLanguage)
        Dim _msg2 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MSG_D_KH_SE_KO_SUA_DL", Commons.Modules.TypeLanguage)
        Dim _caption As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CAPTION_DUYET_KHBT", Commons.Modules.TypeLanguage)

        If XtraMessageBox.Show(_msg1 + " " + cboDiaDiem_1.Text.ToString & vbCrLf & _msg2, _caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim _NAM As Integer
            Dim _THANG As Integer

            If cbKHType.SelectedValue.ToString() = "1" Then
                _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                _THANG = 0
                KHType = "1"
            ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                KHType = "2"
            End If

            Dim scon As New SqlConnection(Commons.IConnections.ConnectionString())
            scon.Open()
            Dim sqlTrans As SqlTransaction = scon.BeginTransaction()
            Try
                Dim commandDuyetKHN As SqlCommand = scon.CreateCommand()
                commandDuyetKHN.Connection = scon
                commandDuyetKHN.CommandTimeout = 9999
                commandDuyetKHN.Transaction = sqlTrans
                commandDuyetKHN.CommandType = CommandType.StoredProcedure
                commandDuyetKHN.CommandText = "SP_KHBT_DUYET_KH"

                commandDuyetKHN.Parameters.Add("@KHTYPE", SqlDbType.Int)
                commandDuyetKHN.Parameters("@KHTYPE").Value = KHType

                commandDuyetKHN.Parameters.Add("@KHNAM", SqlDbType.Int)
                commandDuyetKHN.Parameters("@KHNAM").Value = _NAM

                commandDuyetKHN.Parameters.Add("@KHTHANG", SqlDbType.Int)
                commandDuyetKHN.Parameters("@KHTHANG").Value = _THANG

                commandDuyetKHN.Parameters.Add("@NGUOIDUYET", SqlDbType.NVarChar)
                commandDuyetKHN.Parameters("@NGUOIDUYET").Value = Commons.Modules.UserName

                commandDuyetKHN.Parameters.Add("@DIA_DIEM", SqlDbType.NVarChar)
                commandDuyetKHN.Parameters("@DIA_DIEM").Value = _diaDiem

                commandDuyetKHN.ExecuteNonQuery()
                sqlTrans.Commit()
                scon.Close()
                LoadData()

            Catch ex As Exception

                sqlTrans.Rollback()
                scon.Close()
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DuyetKhongThanhCong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            End Try
        End If


    End Sub

    Private Sub gvKHTT_ShowGridMenu(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs) Handles gvKHTT.ShowGridMenu
        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As ViewInfo.GridHitInfo

        HitInfo = View.CalcHitInfo(e.Point)

        If HitInfo.InRow Then

            View.FocusedRowHandle = HitInfo.RowHandle
            ContextMenuStrip1.Show(View.GridControl, e.Point)

        End If
    End Sub

    Private Sub mnuRelationship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelationship.Click

        'XtraMessageBox.Show(gvKHTT.GetFocusedDataRow()("HANG_MUC_ID").ToString)
        Dim frmChoose As New Report1.frmKHTT_HangMucHistory
        frmChoose.HANG_MUC_ID = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID")
        frmChoose.ShowDialog()
    End Sub

    Private Sub mnuCopyTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyTo.Click
        XtraMessageBox.Show(gvKHTT.GetFocusedDataRow()("HANG_MUC_ID").ToString)

        Dim _NAM As Integer
        Dim _THANG As Integer

        If cbKHType.SelectedValue.ToString() = "1" Then
            _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
            _THANG = 0
            KHType = "1"
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
            _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
            KHType = "2"
        End If

        Dim frmChoose As New Report1.frmKHTT_CopyHangMucTo
        frmChoose.KH_TYPE = KHType
        frmChoose.KH_NAM = _NAM
        frmChoose.KH_THANG = _THANG
        frmChoose.HANG_MUC_ID = gvKHTT.GetFocusedDataRow()("HANG_MUC_ID").ToString
        frmChoose.MS_MAY_COPY_FROM = gvKHTT.GetFocusedDataRow()("MS_MAY").ToString
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If


    End Sub

    Private Sub mnuDeleteHM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteHM.Click

    End Sub


    Private Sub mbtnKHT_GET_Nam_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnKHT_GET_Nam.ItemClick
        Dim frmChoose As New Report1.frmKHTT_LayTuKHBTNam
        frmChoose.KHNam = cbKHTNam.SelectedValue.ToString()
        frmChoose.KHThang = cbKHTThang.SelectedValue.ToString()
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub mbtnKHT_GET_BTDK_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnKHT_GET_BTDK.ItemClick
        Dim frmChoose As New Report1.frmKHTT_BTDKChoose
        frmChoose.KHNam = cbKHTNam.SelectedValue.ToString()
        frmChoose.KHThang = cbKHTThang.SelectedValue.ToString()
        frmChoose.KHType = 2
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub mbtnKHT_GET_Thang_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnKHT_GET_Thang.ItemClick
        Dim frmChoose As New Report1.frmKHTT_ChuyenThangQuaThang
        frmChoose.KHNam = cbKHTNam.SelectedValue.ToString()
        frmChoose.KHThang = cbKHTThang.SelectedValue.ToString()
        frmChoose.iLoai = 1
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub mbtnKHT_GET_CV_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnKHT_GET_CV.ItemClick
        Dim frmChoose As New Report1.frmKHTT_ChuyenCVThangQuaCVThang
        frmChoose.KHNam = cbKHTNam.SelectedValue.ToString()
        frmChoose.KHThang = cbKHTThang.SelectedValue.ToString()
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub mbtnKHN_GET_BTDK_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnKHN_GET_BTDK.ItemClick
        Dim frmChoose As New Report1.frmKHTT_BTDKChoose
        frmChoose.KHNam = cbKHNNam.SelectedValue.ToString()
        frmChoose.KHType = 1
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub mbtnKHN_GET_Nam_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnKHN_GET_Nam.ItemClick
        Dim frmChoose As New Report1.frmKHTT_ChuyenNamQuaNam
        frmChoose.KHNam = cbKHNNam.SelectedValue.ToString()
        frmChoose.iLoai = 1
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub


    Private Sub mnuOpt1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuOpt1.ItemClick
        Try
            Dim _NAM As Integer
            Dim _THANG As Integer
            Dim _datetmp As DateTime

            If cbKHType.SelectedValue.ToString() = "1" Then
                _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                _THANG = 0
                KHType = "1"
                _datetmp = New DateTime(_NAM, 1, 1)
            ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                KHType = "2"
                _datetmp = New DateTime(_NAM, _THANG, 1)
            End If
            Dim frm As New ReportMain.frmInKHTT
            frm.iLoai = 1
            frm.iKHType = KHType
            frm.NamThang = _datetmp
            frm.sTenBC = mnuOpt1.Caption
            frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mnuOpt2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuOpt2.ItemClick
        Try
            Dim _NAM As Integer
            Dim _THANG As Integer
            Dim _datetmp As DateTime

            If cbKHType.SelectedValue.ToString() = "1" Then
                _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                _THANG = 0
                KHType = "1"
                _datetmp = New DateTime(_NAM, 1, 1)
            ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                KHType = "2"
                _datetmp = New DateTime(_NAM, _THANG, 1)
            End If

            Dim frm As New ReportMain.frmInKHTT
            frm.iLoai = 2
            frm.iKHType = KHType
            frm.NamThang = _datetmp
            frm.sTenBC = mnuOpt2.Caption
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuOpt3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuOpt3.ItemClick
        Try
            Dim _NAM As Integer
            Dim _THANG As Integer
            Dim _datetmp As DateTime

            If cbKHType.SelectedValue.ToString() = "1" Then
                _NAM = CType(cbKHNNam.SelectedValue.ToString, Integer)
                _THANG = 0
                KHType = "1"
                _datetmp = New DateTime(_NAM, 1, 1)
            ElseIf cbKHType.SelectedValue.ToString() = "2" Then
                _NAM = CType(cbKHTNam.SelectedValue.ToString, Integer)
                _THANG = CType(cbKHTThang.SelectedValue.ToString, Integer)
                KHType = "2"
                _datetmp = New DateTime(_NAM, _THANG, 1)
            End If

            Dim frm As New ReportMain.frmInKHTT
            frm.iLoai = 3
            frm.iKHType = KHType
            frm.NamThang = _datetmp
            frm.sTenBC = mnuOpt3.Caption
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub radAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radAll.CheckedChanged
        If radAll.Checked = False Then Exit Sub
        tmp_cv = -1
        tmp_pt = -1
        LoadData()
        DropDownButton1.Enabled = True
        btnLPBT.Visible = False
        BtnThem1.Enabled = False
    End Sub

    Private Sub mbtnKHT_GET_CV_TU_NAM_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnKHT_GET_CV_TU_NAM.ItemClick
        Dim frmChoose As New Report1.frmKHTT_ChuyenCVNamQuaThang
        frmChoose.KHNam = cbKHTNam.SelectedValue.ToString()
        frmChoose.KHThang = cbKHTThang.SelectedValue.ToString()
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub mbtnChuyenCVDangDo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnChuyenCVDangDo.ItemClick
        If cbKHType.SelectedValue.ToString() = "1" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, _
                "msgVuiLongChonKeHoachThang", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Dim frm As New ReportMain.frmTimMay
        frm.iLoaiBC = 98
        frm.MsLoaiMay = cboLoaiThietBiBTDK.SelectedValue
        frm.MsNMay = CboNhomThietBiBTDK.SelectedValue
        If cbKHType.SelectedValue.ToString() = "1" Then
            frm.iKeHoachNam = CType(cbKHNNam.SelectedValue.ToString, Integer)
            frm.TuNgay = New DateTime(frm.iKeHoachNam, 1, 1)
            frm.DenNgay = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, frm.TuNgay))
        ElseIf cbKHType.SelectedValue.ToString() = "2" Then
            frm.iKeHoachNam = CType(cbKHTNam.SelectedValue.ToString, Integer)
            frm.iKeHoachThang = CType(cbKHTThang.SelectedValue.ToString, Integer)
            frm.TuNgay = New DateTime(frm.iKeHoachNam, frm.iKeHoachThang, 1)
            frm.DenNgay = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, frm.TuNgay))
        End If

        If frm.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Cursor = Cursors.WaitCursor

        If radAll.Checked Then radAll_CheckedChanged(sender, e)
        If radDaGiaiQuyet1.Checked Then radDaGiaiQuyet1_CheckedChanged(sender, e)
        Cursor = Cursors.Default

    End Sub

    Private Sub mbtnCopyNam_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mbtnCopyNam.ItemClick
        Dim frmChoose As New Report1.frmKHTT_ChuyenNamQuaNam
        frmChoose.KHNam = cbKHNNam.SelectedValue.ToString()
        frmChoose.iLoai = 2
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub mnuCopyThang_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuCopyThang.ItemClick
        Dim frmChoose As New Report1.frmKHTT_ChuyenThangQuaThang
        frmChoose.KHNam = cbKHTNam.SelectedValue.ToString()
        frmChoose.KHThang = cbKHTThang.SelectedValue.ToString()
        frmChoose.iLoai = 2
        If frmChoose.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

End Class