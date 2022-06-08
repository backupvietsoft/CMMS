Imports System.Data.SqlClient
Imports Commons.VS.Classes.Catalogue
Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data
Imports Vietsoft

Public Class ucDMTBi
    'Public dtTBi As New DataTable
    Public dtTuNgay, dtDenNgay As DateTime
    Public MsLoaiMay, MsNhomMay As String

    Public Sub LoadLoaiMay2()
        Dim dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "PermisionLOAI_MAY", Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_LOAI_MAY, dtTmp.Copy(), "MS_LOAI_MAY", "TEN_LOAI_MAY", "")
    End Sub

    'load nhóm máy theo loai may
    Public Sub LoadNhomMay()
        Try
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_NHOM_MAY, "GetMAY_NHOM_MAYs", "MS_NHOM_MAY", "TEN_NHOM_MAY", "", True, cboMS_LOAI_MAY.EditValue)
        Catch ex As Exception
        End Try
    End Sub

    'Load Nhà cung cấp
    Public Sub LoadNCC()
        Dim dtTmp = New DataTable
        Dim dtRow As DataRow

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHACH_HANGs"))
        dtRow = dtTmp.NewRow
        dtRow(0) = "-99"
        dtRow(1) = ""
        For i As Integer = 1 To dtTmp.Columns.Count - 2
            dtRow(i + 1) = ""
        Next
        dtTmp.Rows.Add(dtRow)

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_NCC, dtTmp, "MS_KH", "TEN_CONG_TY", "")
    End Sub

    'load nhà sản xuất
    Public Sub LoadNSX()
        Dim dtTmp = New DataTable
        Dim dtRow As DataRow

        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHANG_SAN_XUATs"))
        dtRow = dtTmp.NewRow
        dtRow(0) = -99
        dtRow(1) = ""
        For i As Integer = 1 To dtTmp.Columns.Count - 2
            dtRow(i + 1) = ""
        Next
        dtTmp.Rows.Add(dtRow)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(CboMS_HSX, dtTmp, "MS_HSX", "TEN_HSX", "")
    End Sub

    'load hiện trạng mấy
    Public Sub LoadHIEN_TRANG_SD_MAY()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_HIEN_TRANG, "GetHIEN_TRANG_SU_DUNG_MAYs", "MS_HIEN_TRANG", "TEN_HIEN_TRANG", "", True, Commons.Modules.TypeLanguage)
    End Sub

    'load mức ưu tiên
    Public Sub LoadMUC_UU_TIEN()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMUC_UU_TIEN, "GetMUC_UU_TIENs", "MS_UU_TIEN", "TEN_UU_TIEN", "", True)
        Try
        Catch ex As Exception
        End Try
    End Sub

    'load dơn vị tính
    Public Sub LoadDON_VI_TINH_RUN_TIME()
        Dim dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_TINH_RUN_TIMEs"))
        Dim row As DataRow = dtTmp.NewRow()
        row("MS_DVT_RT") = "-99"
        row("TEN_DVT_RT") = ""
        dtTmp.Rows.InsertAt(row, 0)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_DVT_RT, dtTmp, "MS_DVT_RT", "TEN_DVT_RT", "")
    End Sub

    'load ngoại tệ
    Public Sub LoadNGOAI_TE()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNGOAI_TE, "GetNGOAI_TEs", "NGOAI_TE", "NGOAI_TE", "", True)
    End Sub

    'load đơn vị tính sản lượng
    Public Sub LoadDVTSL()

        Dim _table As New DataTable
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_DVT_PT", Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbDVTSL, _table, "DVT", "TEN", "")
    End Sub

    'load đơn vị tính thời gian
    Public Sub LoadDVTG()
        Dim _table As New DataTable
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DON_VI_TG", Commons.Modules.TypeLanguage))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbDVTG, _table, "MS_DV_TG", "TEN", "")

    End Sub

    'edit loại thiết bị
    Private Sub BtnLoaiTB_Click(sender As Object, e As EventArgs) Handles BtnLoaiTB.Click
        Dim frm As New Report1.frmThietBi()
        If frm.ShowDialog() Then
            LoadLoaiMay2()
        End If
    End Sub

    'edit nhóm thiết bị
    Private Sub btnNhomTB_Click(sender As Object, e As EventArgs) Handles btnNhomTB.Click
        Dim frmThietBi As New Report1.frmThietBi()
        If (frmThietBi.ShowDialog) Then
            LoadNhomMay()
        End If
    End Sub

    'edit nhà cung cấp
    Private Sub btnNhaCungCap_Click(sender As Object, e As EventArgs) Handles btnNhaCungCap.Click
        Dim frmNhacungcap As Report1.frmNhacungcap = New Report1.frmNhacungcap()
        If frmNhacungcap.ShowDialog() Then
            LoadNCC()
        End If
    End Sub

    'edit hãng xản xuất
    Private Sub BtnHangSX_Click(sender As Object, e As EventArgs) Handles BtnHangSX.Click
        Dim frm As Report1.frmHangsanxuat = New Report1.frmHangsanxuat()
        If frm.ShowDialog() Then
            LoadNSX()
        End If
    End Sub

    'edit mức ưu tiên
    Private Sub btnMUT_Click(sender As Object, e As EventArgs) Handles btnMUT.Click
        Try
            Dim frm As Report1.frmMucUT = New Report1.frmMucUT()
            frm.ShowDialog()
            LoadMUC_UU_TIEN()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadTextTrang()
        txtMS_MAY.Text = ""
        txtSERIAL_NUMBER.Text = ""
        txtTEN_MAY.Text = ""
        txtMO_TA.Text = ""
        txtMODEL.Text = ""
        txtNGAY_SX.Text = ""
        txtNUOC_SX.Text = ""
        txtNHIEM_VU_THIET_BI.Text = ""
        txtNGAY_DUA_VAO_SD.Text = ""
        txtSO_NAM_SD.Text = ""
        TxtMS_BP_CHIU_PHI.Text = ""
        TxtMS_HE_THONG.Text = ""
        TxtMS_NHA_XUONG.Text = ""
        txtNGAY_BD_BAO_HANH.Text = ""
        txtSO_THANG_BH.Text = ""
        txtNgayKTBH.Text = ""
        txtSO_NGAY_LV_TRONG_TUAN.Text = ""
        txtSO_GIO_LV_TRONG_NGAY.Text = ""
        txtSO_THE.Text = ""
        txtSoCT.Text = ""
        txtNGAY_MUA.Text = ""
        txtGIA_MUA.Text = ""
        txtTiGiaVND.Text = ""
        txtTiGiaUSD.Text = ""
        txtSO_NAM_KHAU_HAO.Text = ""
        txtNgayHHKH.Text = ""
        txtTY_LE_CON_LAI.Text = ""
        txtNgayHCtieptheo.Text = ""
        txtCKHCTB_Ngoai_Ngay_TT.Text = ""
        txtCKKDTB_NGAY_TT.Text = ""
        cboMS_HIEN_TRANG.EditValue = "-1"
        cboMS_NCC.EditValue = "-1"
        CboMS_HSX.EditValue = -1
        cboMUC_UU_TIEN.EditValue = "-1"

        txtChukyHC.Text = ""

        txtUInsert.Text = ""
        txtUUpdate.Text = ""
        txtNInsert.Text = ""
        txtNUpdate.Text = ""

        txtSO_NAM_KHAU_HAO.Text = 0
        txtSO_NGAY_LV_TRONG_TUAN.Text = 0
        txtSO_GIO_LV_TRONG_NGAY.Text = 0
        txtSO_THANG_BH.Text = 0
        txtGIA_MUA.Text = 0
        txtTiGiaVND.Text = 0
        txtTiGiaUSD.Text = 0
        txtChukyHC.Text = 0
        txtCKHCTB_Ngoai.Text = 0
        txtCKKDTB.Text = 0
        txtSO_NAM_KHAU_HAO.Text = 0
        txtTY_LE_CON_LAI.Text = 100
        cboMS_NCC.Text = String.Empty
    End Sub

    Sub Refesh()
        txtMS_MAY.Text = ""
        txtSERIAL_NUMBER.Text = ""
        txtTEN_MAY.Text = ""
        txtMO_TA.Text = ""
        txtMODEL.Text = ""
        txtNGAY_SX.Text = ""
        txtNUOC_SX.Text = ""
        txtNHIEM_VU_THIET_BI.Text = ""
        txtNGAY_DUA_VAO_SD.Text = ""
        txtSO_NAM_SD.Text = ""
        TxtMS_BP_CHIU_PHI.Text = ""
        TxtMS_HE_THONG.Text = ""
        TxtMS_NHA_XUONG.Text = ""
        txtNGAY_BD_BAO_HANH.Text = ""
        txtSO_THANG_BH.Text = ""
        txtNgayKTBH.Text = ""
        txtSO_NGAY_LV_TRONG_TUAN.Text = ""
        txtSO_GIO_LV_TRONG_NGAY.Text = ""
        txtSO_THE.Text = ""
        txtSoCT.Text = ""
        txtNGAY_MUA.Text = ""
        txtGIA_MUA.Text = ""
        txtTiGiaVND.Text = ""
        txtTiGiaUSD.Text = ""
        txtSO_NAM_KHAU_HAO.Text = ""
        txtNgayHHKH.Text = ""
        txtTY_LE_CON_LAI.Text = ""
        txtNgayHCtieptheo.Text = ""
        txtCKHCTB_Ngoai_Ngay_TT.Text = ""
        txtCKKDTB_NGAY_TT.Text = ""
        cboMS_HIEN_TRANG.EditValue = "-1"
        cboMS_NCC.EditValue = "-1"
        CboMS_HSX.EditValue = -1
        cboMUC_UU_TIEN.EditValue = "-1"
        'txtMS_BO_PHAN.Text = ""
        'txtTEN_BO_PHAN.Text = ""
        'txtSO_LUONG.Text = 0
        'txtGHI_CHU.Text = ""
        'TxtHINH.Text = ""
        txtChukyHC.Text = ""
        'grdThongSoBP.DataSource = System.DBNull.Value
        'grdCTTB_PT.DataSource = System.DBNull.Value
        'CboPT_BP.EditValue = "-1"
        'cboClass.EditValue = -1
        txtUInsert.Text = ""
        txtUUpdate.Text = ""
        txtNInsert.Text = ""
        txtNUpdate.Text = ""

    End Sub


    Sub LockData(ByVal blnLock As Boolean)
        Dim TB_CHECK As DataTable = New DataTable()
        TB_CHECK.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT * FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" & txtMS_MAY.Text.Trim() & "'"))
        If (TB_CHECK.Rows.Count > 0) Then
            txtMS_MAY.Properties.ReadOnly = True
        Else
            txtMS_MAY.Properties.ReadOnly = blnLock
        End If
        'cboMS_NHOM_MAY.Properties.ReadOnly = blnLock
        'cboMS_LOAI_MAY.Properties.ReadOnly = blnLock

        cboMS_NHOM_MAY.Enabled = Not blnLock
        cboMS_LOAI_MAY.Enabled = Not blnLock

        cboNGOAI_TE.Enabled = Not blnLock
        cboMUC_UU_TIEN.Enabled = Not blnLock
        cmbDVTSL.Enabled = Not blnLock
        cmbDVTG.Enabled = Not blnLock
        CboMS_HSX.Enabled = Not blnLock
        cboMS_HIEN_TRANG.Enabled = Not blnLock
        cboMS_NCC.Enabled = Not blnLock
        cboMS_DVT_RT.Enabled = Not blnLock

        txtTEN_MAY.Properties.ReadOnly = blnLock
        txtSO_NAM_KHAU_HAO.Properties.ReadOnly = blnLock
        txtTEN_MAY.Properties.ReadOnly = blnLock
        txtMO_TA.Properties.ReadOnly = blnLock
        txtNHIEM_VU_THIET_BI.Properties.ReadOnly = blnLock
        txtMODEL.Properties.ReadOnly = blnLock
        txtSERIAL_NUMBER.Properties.ReadOnly = blnLock

        btnChenhinh.Enabled = Not blnLock
        btnXoahinh.Enabled = Not blnLock

        txtNGAY_SX.Properties.ReadOnly = blnLock
        txtNGAY_SX.Properties.Buttons(0).Enabled = Not blnLock

        txtNUOC_SX.Properties.ReadOnly = blnLock
        txtNGAY_MUA.Properties.ReadOnly = blnLock
        txtNGAY_MUA.Properties.Buttons(0).Enabled = Not blnLock


        txtNGAY_BD_BAO_HANH.Properties.ReadOnly = blnLock
        txtNGAY_BD_BAO_HANH.Properties.Buttons(0).Enabled = Not blnLock

        txtNGAY_DUA_VAO_SD.Properties.ReadOnly = blnLock
        txtNGAY_DUA_VAO_SD.Properties.Buttons(0).Enabled = Not blnLock

        txtSO_THE.Properties.ReadOnly = blnLock
        txtSoCT.Properties.ReadOnly = blnLock
        txtSO_NGAY_LV_TRONG_TUAN.Properties.ReadOnly = blnLock
        txtSO_GIO_LV_TRONG_NGAY.Properties.ReadOnly = blnLock

        txtDinhMucSL.Properties.ReadOnly = blnLock
        txtTY_LE_CON_LAI.Properties.ReadOnly = blnLock

        txtSO_THANG_BH.Properties.ReadOnly = blnLock
        txtGIA_MUA.Properties.ReadOnly = blnLock
        txtTiGiaVND.Properties.ReadOnly = blnLock
        txtTiGiaUSD.Properties.ReadOnly = blnLock

        txtChukyHC.Properties.ReadOnly = blnLock
        txtCKHCTB_Ngoai.Properties.ReadOnly = blnLock
        txtCKKDTB.Properties.ReadOnly = blnLock

    End Sub
    Private Sub btnChenhinh_Click(sender As Object, e As EventArgs) Handles btnChenhinh.Click
        If txtMS_MAY.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi9", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ofdHinhTB.ShowDialog()
    End Sub
    Private Sub btnXoahinh_Click(sender As Object, e As EventArgs) Handles btnXoahinh.Click
        If PtcAnhTB.ImageLocation = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa6", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Dim Sql As String = "UPDATE MAY SET ANH_TB = '' WHERE MS_MAY=N'" & txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql)
        Commons.Modules.ObjSystems.Xoahinh(PtcAnhTB.ImageLocation)
        PtcAnhTB.ImageLocation = ""
        ' '' ''LstMAY.SelectedItem("ANH_TB") = ""
    End Sub
    Private Sub ofdHinhTB_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdHinhTB.FileOk
        Dim strDuongDan As String = ""
        Dim FILE_PATHs As String()
        FILE_PATHs = ofdHinhTB.FileNames()
        For i As Integer = 0 To FILE_PATHs.Length - 1
            Dim info As New System.IO.FileInfo(FILE_PATHs(i))
            If Commons.Modules.sPrivate <> "BARIA" Then
                If info.Length > 5242880 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgFileLonHon5Mb", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        Next
        strDuongDan = Commons.Modules.ObjSystems.CapnhatTL(False, txtMS_MAY.Text) '\Hinh_May\BDL-01-01\1_4_2019
        Dim str As String = "", str1 As String = ""
        str = "SELECT ANH_TB FROM MAY WHERE ANH_TB<>'' AND MS_MAY=N'" & txtMS_MAY.Text & "'"
        str = strDuongDan & "\" & "TB_" & txtMS_MAY.Text.Replace("/", "_") & "_" & IIf(DateTime.Now.Day.ToString.Length < 2, 0 & DateTime.Now.Day, DateTime.Now.Day) & IIf(Month(Now()).ToString.Length < 2, 0 & Month(Now()), Month(Now())) & Year(Now()) & Commons.Modules.ObjSystems.LayDuoiFile(ofdHinhTB.FileName)
        str1 = "UPDATE MAY SET ANH_TB='" & str & "' WHERE MS_MAY=N'" & txtMS_MAY.Text & "'"
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str1)
        '\Hinh_May\BOM-02-04\2_4_2019\TB_BOM-02-04_02042019.png
        '\Hinh_May\BOM-02-03\2_4_2019\TB_BOM-02-03_02/04/2019042019.jpg
        Commons.Modules.ObjSystems.LuuDuongDan(ofdHinhTB.FileName, str)
        PtcAnhTB.ImageLocation = str
    End Sub



    Private Sub txtSO_GIO_LV_TRONG_NGAY_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSO_GIO_LV_TRONG_NGAY.Validating
        'If Not BtnGhi.Visible Then Exit Sub
        If Not IsNumeric(txtSO_GIO_LV_TRONG_NGAY.Text) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSO_GIO_LV_TRONG_NGAY.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtSO_NGAY_LV_TRONG_TUAN_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSO_NGAY_LV_TRONG_TUAN.Validating
        'If Not BtnGhi.Visible Then Exit Sub

        If Not IsNumeric(txtSO_NGAY_LV_TRONG_TUAN.Text) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSO_NGAY_LV_TRONG_TUAN.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtGIA_MUA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtGIA_MUA.Validating
        'If Not BtnGhi.Visible Then Exit Sub

        If Not IsNumeric(txtGIA_MUA.Text) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGIA_MUA.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtSO_THANG_BH_Validated(sender As Object, e As EventArgs) Handles txtSO_THANG_BH.Validated
        txtNgayKTBH.Text = DateAdd(DateInterval.Month, Double.Parse(txtSO_THANG_BH.Text), txtNGAY_BD_BAO_HANH.DateTime.Date)
    End Sub

    Private Sub txtSO_THANG_BH_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSO_THANG_BH.Validating
        'If Not BtnGhi.Visible Then Exit Sub
        If IsNumeric(txtSO_THANG_BH.Text) Then
            If Not Commons.Modules.ObjSystems.KiemTraSoNguyen(txtSO_THANG_BH.Text) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtSO_THANG_BH.Focus()
                e.Cancel = True
            End If
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSO_THANG_BH.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtSO_NAM_KHAU_HAO_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSO_NAM_KHAU_HAO.Validating
        If Not IsNumeric(txtSO_NAM_KHAU_HAO.Text) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemTraSoNguyen", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSO_NAM_KHAU_HAO.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub cboMS_LOAI_MAY_EditValueChanged(sender As Object, e As EventArgs) Handles cboMS_LOAI_MAY.EditValueChanged
        LoadNhomMay()
    End Sub



    Public Sub ShowMAY(ByVal dtTBi As DataTable)
        If dtTBi.Rows.Count <= 0 Then Exit Sub
        Try
            txtMS_MAY.Text = dtTBi.Rows(0)("MS_MAY").ToString()
            txtTEN_MAY.Text = dtTBi.Rows(0)("TEN_MAY").ToString()
            cboMS_LOAI_MAY.Text = dtTBi.Rows(0)("TEN_LOAI_MAY").ToString()
            cboMS_NHOM_MAY.Text = dtTBi.Rows(0)("TEN_NHOM_MAY").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("TEN_HSX").ToString()) Then CboMS_HSX.EditValue = -99 Else CboMS_HSX.Text = dtTBi.Rows(0)("TEN_HSX").ToString()

            cboMS_HIEN_TRANG.EditValue = dtTBi.Rows(0)("MS_HIEN_TRANG")

            If String.IsNullOrEmpty(dtTBi.Rows(0)("TEN_CONG_TY").ToString()) Then cboMS_NCC.EditValue = "-99" Else cboMS_NCC.Text = dtTBi.Rows(0)("TEN_CONG_TY").ToString()

            txtSO_NAM_KHAU_HAO.Text = dtTBi.Rows(0)("SO_NAM_KHAU_HAO").ToString()
            txtMO_TA.Text = dtTBi.Rows(0)("MO_TA").ToString()
            txtNHIEM_VU_THIET_BI.Text = dtTBi.Rows(0)("NHIEM_VU_THIET_BI").ToString()
            txtMODEL.Text = dtTBi.Rows(0)("MODEL").ToString()
            txtSERIAL_NUMBER.Text = dtTBi.Rows(0)("SERIAL_NUMBER").ToString()

            If dtTBi.Rows(0)("NGAY_SX").ToString() <> "" Then txtNGAY_SX.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_SX").ToString()) Else txtNGAY_SX.Text = ""


            txtNUOC_SX.Text = dtTBi.Rows(0)("NUOC_SX").ToString()

            If dtTBi.Rows(0)("NGAY_BD_BAO_HANH").ToString() <> "" Then txtNGAY_BD_BAO_HANH.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_BD_BAO_HANH").ToString()) Else txtNGAY_BD_BAO_HANH.Text = ""

            If dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString() <> "" Then txtNGAY_DUA_VAO_SD.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString()) Else txtNGAY_DUA_VAO_SD.Text = ""


            txtSO_THE.Text = dtTBi.Rows(0)("SO_THE").ToString()
            txtSoCT.Text = dtTBi.Rows(0)("SO_CT").ToString()
            txtSO_NGAY_LV_TRONG_TUAN.Text = dtTBi.Rows(0)("SO_NGAY_LV_TRONG_TUAN").ToString()
            txtSO_GIO_LV_TRONG_NGAY.Text = dtTBi.Rows(0)("SO_GIO_LV_TRONG_NGAY").ToString()
            'Row("MS_DVT_RT") = "-99"
            'Row("TEN_DVT_RT") = ""
            If dtTBi.Rows(0)("TEN_DVT_RT").ToString() = "" Then
                cboMS_DVT_RT.EditValue = -99
            Else
                cboMS_DVT_RT.Text = dtTBi.Rows(0)("TEN_DVT_RT").ToString()

            End If

            Try
                txtDinhMucSL.Text = dtTBi.Rows(0)("DINH_MUC_SL").ToString()
                cmbDVTSL.Text = dtTBi.Rows(0)("DVT_SL").ToString()
                cmbDVTG.EditValue = Convert.ToInt32(dtTBi.Rows(0)("DON_VI_THOI_GIAN").ToString())

            Catch
                cmbDVTG.EditValue = 0

            End Try

            txtTY_LE_CON_LAI.Text = dtTBi.Rows(0)("TY_LE_CON_LAI").ToString()
            cboMUC_UU_TIEN.Text = dtTBi.Rows(0)("TEN_UU_TIEN").ToString()
            txtSO_THANG_BH.Text = dtTBi.Rows(0)("SO_THANG_BH").ToString()
            txtGIA_MUA.Text = dtTBi.Rows(0)("GIA_MUA").ToString()
            txtTiGiaVND.Text = dtTBi.Rows(0)("TI_GIA_VND").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("TI_GIA_USD").ToString()) = False Then
                txtTiGiaUSD.Text = CType(dtTBi.Rows(0)("TI_GIA_USD").ToString(), Double).ToString("###,##0.######")
            Else
                txtTiGiaUSD.Text = String.Empty
            End If
            cboNGOAI_TE.Text = IIf(IsDBNull(dtTBi.Rows(0)("NGOAI_TE").ToString()), "", dtTBi.Rows(0)("NGOAI_TE").ToString())
            txtChukyHC.Text = dtTBi.Rows(0)("CHU_KY_HC_TB").ToString()


            txtCKHCTB_Ngoai.Text = dtTBi.Rows(0)("CHU_KY_HIEU_CHUAN_TB_NGOAI").ToString()
            txtCKKDTB.Text = dtTBi.Rows(0)("CHU_KY_KD_TB").ToString()
            If chkHienthihinhTB.Checked Then
                PtcAnhTB.ImageLocation = dtTBi.Rows(0)("Anh_TB").ToString()
            Else
                PtcAnhTB.ImageLocation = ""
            End If
            InitMayHeThongBPCPNhaXuongTmp(txtMS_MAY.Text)
            Try
                If dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString() <> "" Then
                    dtTuNgay = DateTime.Parse(dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString())
                    dtDenNgay = DateTime.Parse(dtTBi.Rows(0)("NGAY_DUA_VAO_SD").ToString())
                End If
            Catch ex As Exception

            End Try
            Try
                MsLoaiMay = cboMS_LOAI_MAY.EditValue.ToString
            Catch ex As Exception

            End Try
            Try
                MsNhomMay = cboMS_NHOM_MAY.EditValue.ToString
            Catch ex As Exception

            End Try
            If String.IsNullOrEmpty(dtTBi.Rows(0)("USER_INSERT").ToString()) Then _
                    txtUInsert.Text = "" Else txtUInsert.Text = dtTBi.Rows(0)("USER_INSERT").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("NGAY_INSERT").ToString()) Then _
                    txtNInsert.Text = "" Else txtNInsert.Text = dtTBi.Rows(0)("NGAY_INSERT").ToString()


            If String.IsNullOrEmpty(dtTBi.Rows(0)("USER_UPDATE").ToString()) Then _
                    txtUUpdate.Text = "" Else txtUUpdate.Text = dtTBi.Rows(0)("USER_UPDATE").ToString()
            If String.IsNullOrEmpty(dtTBi.Rows(0)("NGAY_UPDATE").ToString()) Then _
                    txtNUpdate.Text = "" Else txtNUpdate.Text = dtTBi.Rows(0)("NGAY_UPDATE").ToString()
            If dtTBi.Rows(0)("NGAY_MUA").ToString() <> "" Then txtNGAY_MUA.DateTime = Convert.ToDateTime(dtTBi.Rows(0)("NGAY_MUA").ToString()) Else txtNGAY_MUA.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Sub InitMayHeThongBPCPNhaXuongTmp(ByVal MS_MAY As String)
        Dim dtReader As SqlDataReader
        Dim sSql As String = ""
        TxtMS_HE_THONG.Text = ""
        sSql = "SELECT TEN_HE_THONG FROM HE_THONG INNER JOIN MAY_HE_THONG ON " &
                "HE_THONG.MS_HE_THONG = MAY_HE_THONG.MS_HE_THONG WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_HE_THONG WHERE MS_MAY=N'" & MS_MAY & "')"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            TxtMS_HE_THONG.Text = dtReader.Item("TEN_HE_THONG")
        End While

        dtReader.Close()
        sSql = "SELECT TEN_N_XUONG + CASE WHEN GHI_CHU IS NULL OR GHI_CHU = '' THEN '' ELSE '(' + GHI_CHU + ')' END AS TEN_N_XUONG,NHA_XUONG.MS_N_XUONG FROM NHA_XUONG INNER JOIN MAY_NHA_XUONG ON " &
                "NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG.MS_N_XUONG WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_NHA_XUONG WHERE MS_MAY=N'" & MS_MAY & "')"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        TxtMS_NHA_XUONG.Text = ""
        While dtReader.Read
            TxtMS_NHA_XUONG.Text = dtReader.Item("TEN_N_XUONG")
        End While
        dtReader.Close()
        sSql = "SELECT TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI INNER JOIN MAY_BO_PHAN_CHIU_PHI ON " &
                        "BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI = MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI WHERE MS_MAY=N'" & MS_MAY & "' AND " &
                        "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY=N'" & MS_MAY & "')"

        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        While dtReader.Read
            TxtMS_BP_CHIU_PHI.Text = dtReader.Item("TEN_BP_CHIU_PHI")
        End While
        dtReader.Close()
    End Sub
End Class
