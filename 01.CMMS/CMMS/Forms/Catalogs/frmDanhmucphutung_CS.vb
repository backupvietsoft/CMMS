
Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient

Public Class frmDanhmucphutung_CS
    Public MSPT As String = "-1"
    Dim iLoaiData As Integer = 0 'dung de load cmb
    Private bDoiMS As Boolean = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 19)
    Private bFullTTTB As Boolean = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 20)
    Private bActivePT As Boolean = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 51)
    Private sMsPTSua As String = "-1"
    Private sHinhLuu As String = "-1"
    Private strDuongDan As String = ""
    Private Delegate Sub setDataGridInvoker(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal sMsPT As String)
    Private Delegate Sub loadDataToComboboxInvoker(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
    'VTPT Dinh nghia dung de INT voi cac fan mem = 0 la full wuyen,= 1 la khong cho sua ma voi ten, = 2 la khong cho sua ma voi ten + 0 cho xoa, = 3 nhu 2 + 0 cho sua cac gt MS_PT_CTY,MS_PT_NCC,TEN_PT_VIET,QUY_CACH,LOAI_VT,DVT
    Dim VTPT As Integer = 0
    Private Sub QuyenINT()
        If VTPT = 1 Then
            txtMS_PT.Enabled = False
            txtTEN_PT.Enabled = False
        End If
        If VTPT = 2 Then
            BtnXoa.Enabled = False
            txtMS_PT.Enabled = False
            txtTEN_PT.Enabled = False
        End If
        If VTPT = 3 Then
            BtnXoa.Enabled = False
            BtnThem.Enabled = False
            txtMS_PT.Enabled = False
            txtTEN_PT.Enabled = False
            txtMS_PT_CTY.Enabled = False
            txtMS_PT_NCC.Enabled = False
            txtTEN_PT_VIET.Enabled = False
            txtQUY_CACH.Enabled = False
            cmbLOAI_VT.Enabled = False
            cmbLOAI_VT.Properties.Buttons(1).Enabled = False
            cmbDVT.Enabled = False
            cmbDVT.Properties.Buttons(1).Enabled = False

        End If

    End Sub


#Region "Them Master Data"

    Private Sub LayDuongDan()
        strPath_DH = txtHinh.Text
        strDuongDan = ofdChonHinh.FileName
        If txtMS_PT.Text <> "" Then
            Dim strDuongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(True, txtMS_PT.Text)
            Dim sFile() As String
            Dim TenFile As String
            Dim i As Integer = 1

            TenFile = "PT_" & ofdChonHinh.SafeFileName.ToString()
            sFile = System.IO.Directory.GetFiles(strDuongDanTmp)

            If Commons.Modules.ObjSystems.KiemFileTonTai(strDuongDanTmp & "\" & "PT_" & ofdChonHinh.SafeFileName.ToString()) = False Then
                txtHinh.Text = strDuongDanTmp & "\" & "PT_" & ofdChonHinh.SafeFileName.ToString()
            Else
                TenFile = Commons.Modules.ObjSystems.STTFileCungThuMuc(strDuongDanTmp, TenFile)
                txtHinh.Text = strDuongDanTmp & "\" & TenFile
            End If


        End If
    End Sub

    Private Sub btnThemHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemHinh.Click
        Try
            If BtnGhi.Visible Then
                ofdChonHinh.ShowDialog()
                LayDuongDan()
            Else
                If txtHinh.Text = "" Then Exit Sub
                Commons.Modules.ObjSystems.OpenHinh(txtHinh.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Load Data"
    Private Sub ContextMenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        Dim str As String = e.ClickedItem.Text
        BtnGhi.Focus()
        Dim isUse As Boolean = False
        Select Case str
            Case "Check"

                If grvLTBi.GetFocusedRowCellValue("CHONLM").ToString() = "False" Then
                    grvLTBi.GetFocusedDataRow("CHONLM") = "True"
                End If

            Case "Check All"
                For i As Integer = 0 To Me.grvLTBi.RowCount - 1
                    grvLTBi.GetDataRow(i)("CHONLM") = "True"
                Next
            Case "UnCheck"
                If grvLTBi.GetFocusedRowCellValue("CHONLM").ToString() = "True" Then
                    Dim OBJ As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_IC_PHU_TUNG_CHECK_LOAI_MAY", sMsPTSua, grvLTBi.GetFocusedRowCellValue("MS_LOAI_MAY").ToString())
                    If CType(OBJ, Integer) > 0 Then
                        isUse = True
                    Else
                        grvLTBi.GetFocusedDataRow("CHONLM") = "False"
                    End If

                End If
                If isUse Then
                    Commons.MssBox.Show(Me.Name, "DA_CO_TRONG_CTTB_KO_SUA", Me.Text)
                End If
            Case "UnCheck All"
                For i As Integer = 0 To Me.grvLTBi.RowCount - 1
                    Dim OBJ As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_IC_PHU_TUNG_CHECK_LOAI_MAY", sMsPTSua, grvLTBi.GetDataRow(i)("MS_LOAI_MAY").ToString())
                    If CType(OBJ, Integer) > 0 Then
                        isUse = True
                    Else
                        grvLTBi.GetDataRow(i)("CHONLM") = "False"
                    End If
                Next
                If isUse Then
                    Commons.MssBox.Show(Me.Name, "DA_CO_TRONG_CTTB_KO_SUA", Me.Text)
                End If
        End Select

    End Sub



    Public Function LoadData(sMsPT As String) As Boolean
        setDataGrid(grdDanhSach, sMsPT)
    End Function

    Private Sub setDataGrid(ByVal grd As DevExpress.XtraGrid.GridControl, ByVal sMsPT As String)
        Try
            If grd.InvokeRequired Then
                grd.Invoke(New setDataGridInvoker(AddressOf setDataGrid), grd)
            Else
                Dim View As GridView = grd.MainView
                Try
                    Dim dtVTPT As New DataTable
                    dtVTPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_IC_PHU_TUNG_GET_DATA_TO_GRID"))
                    'dtVTPT.PrimaryKey = New DataColumn() {dtVTPT.Columns("MS_PT")}

                    dtVTPT.Columns("MS_PT").ReadOnly = True
                    dtVTPT.Columns("TEN_PT").ReadOnly = True
                    dtVTPT.Columns("TEN_PT_VIET").ReadOnly = True
                    dtVTPT.Columns("QUY_CACH").ReadOnly = True
                    dtVTPT.Columns("MS_PT_CTY").ReadOnly = True
                    dtVTPT.Columns("MS_PT_NCC").ReadOnly = True
                    dtVTPT.Columns("TEN_HSX").ReadOnly = True
                    Try
                        If grd.DataSource Is Nothing Then
                            Commons.Modules.ObjSystems.MLoadXtraGrid(grd, View, dtVTPT, False, True, False, False)
                        Else
                            grd.DataSource = Nothing
                            Commons.Modules.ObjSystems.MLoadXtraGrid(grd, View, dtVTPT, False, False, False, False)
                        End If
                    Catch ex As Exception
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grd, View, dtVTPT, False, True, False, False)
                    End Try

                    If View.Columns("ANH_PT").Visible Then
                        View.Columns("MS_PT").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                        View.Columns("MS_PT").Width = 100
                        View.Columns("TEN_PT").Width = 300
                        View.Columns("TEN_PT_VIET").Width = 250
                        View.Columns("QUY_CACH").Width = 250
                        View.Columns("MS_PT_CTY").Width = 100
                        View.Columns("MS_PT_NCC").Width = 100
                        View.Columns("TEN_HSX").Width = 250
                        View.Columns("ANH_PT").Visible = False
                        View.Columns("MS_LOAI_VT").Visible = False
                        View.Columns("MS_CACH_DAT_HANG").Visible = False
                        View.Columns("SO_NGAY_DAT_MUA_HANG").Visible = False
                        View.Columns("TON_TOI_THIEU").Visible = False
                        View.Columns("DVT").Visible = False
                        View.Columns("DUNG_CU_DO").Visible = False
                        View.Columns("MS_KH").Visible = False
                        View.Columns("MS_HSX").Visible = False
                        View.Columns("MS_VI_TRI").Visible = False
                        View.Columns("MS_CLASS").Visible = False
                        View.Columns("TON_KHO_MAX").Visible = False
                        View.Columns("MS_KHO").Visible = False
                        View.Columns("HANG_NGOAI").Visible = False
                        View.Columns("SERVICE_ID").Visible = False
                        View.Columns("THEO_KHO").Visible = False
                        View.Columns("ACTIVE_PT").Visible = False
                        View.Columns("USER_INSERT_PT").Visible = False
                        View.Columns("NGAY_INSERT_PT").Visible = False
                        View.Columns("USER_UPDATE_PT").Visible = False
                        View.Columns("NGAY_UPDATE_PT").Visible = False
                        View.Columns("KY_PB").Visible = False
                        View.Columns("VAT_TU_PT").Visible = False

                        lblTong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTong", Commons.Modules.TypeLanguage) + ": " + dtVTPT.Rows.Count.ToString()
                    End If
                    grd.ForceInitialize()
                    If sMsPT <> "-1" Then
                        Dim index As Integer
                        index = View.LocateByValue(0, View.Columns("MS_PT"), sMsPT)
                        If index <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then


                            If (index <> View.FocusedRowHandle) Then
                                View.FocusedRowHandle = index
                                View.SelectRow(index)
                            Else
                                grvDanhSach_FocusedRowChanged(Nothing, Nothing)
                            End If
                        End If

                    End If
                    If (Not MSPT.Equals("-1")) Then
                        'Dim index As Integer
                        'index = dtVTPT.Rows.IndexOf(dtVTPT.Rows.Find(sMsPT))
                        'View.FocusedRowHandle = View.GetRowHandle(index)

                        Dim index As Integer
                        index = View.LocateByValue(0, View.Columns("MS_PT"), MSPT)
                        If index <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                            If (index <> View.FocusedRowHandle) Then
                                View.FocusedRowHandle = index
                                View.SelectRow(index)
                            Else
                                grvDanhSach_FocusedRowChanged(Nothing, Nothing)
                            End If
                        End If

                        MSPT = "-1"



                    End If



                Catch ex As Exception
                    'Return False
                End Try
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadDataCombobox()
        BindDataCombo()
    End Sub

    Private Sub loadDataToCombobox(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim sMa As String = ""
            Dim sTen As String = ""

            If cbo.InvokeRequired Then
                cbo.Invoke(New loadDataToComboboxInvoker(AddressOf loadDataToCombobox), cbo)
            Else
                Dim dt As New DataTable()
                If (iLoaiData = 0) Then 'DVT
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_DVT_PT", Commons.Modules.TypeLanguage))
                    sMa = "DVT"
                    sTen = "TEN"
                ElseIf (iLoaiData = 1) Then
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHACH_HANGs"))
                    Dim rNull As DataRow = dt.NewRow()
                    rNull("MS_KH") = "-1"
                    rNull("TEN_CONG_TY") = ""
                    rNull("DC_TEL_FAX") = ""
                    dt.Rows.InsertAt(rNull, 0)
                    sMa = "MS_KH"
                    sTen = "TEN_CONG_TY"
                ElseIf (iLoaiData = 2) Then
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHANG_SAN_XUATs"))
                    Dim rNull As DataRow = dt.NewRow()
                    rNull("MS_HSX") = -1
                    rNull("TEN_HSX") = ""
                    dt.Rows.InsertAt(rNull, 0)
                    sMa = "MS_HSX"
                    sTen = "TEN_HSX"
                ElseIf (iLoaiData = 3) Then
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCACH_DAT_HANGs", Commons.Modules.TypeLanguage))
                    sMa = "MS_CACH_DAT_HANG"
                    sTen = "CACH_DAT_HANG"
                ElseIf (iLoaiData = 4) Then
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_VTs"))
                    sMa = "MS_LOAI_VT"
                    If Commons.Modules.TypeLanguage = 0 Then
                        sTen = "TEN_LOAI_VT_TV"
                    ElseIf Commons.Modules.TypeLanguage = 1 Then
                        sTen = "TEN_LOAI_VT_TA"
                    ElseIf Commons.Modules.TypeLanguage = 2 Then
                        sTen = "TEN_LOAI_VT_TH"
                    End If
                ElseIf (iLoaiData = 5) Then
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM CLASS_VT ORDER BY MS_CLASS"))
                    sMa = "MS_CLASS"
                    sTen = "TEN_CLASS"
                    Dim rNull As DataRow = dt.NewRow()
                    rNull("MS_CLASS") = -1
                    rNull("TEN_CLASS") = ""
                    dt.Rows.InsertAt(rNull, 0)
                ElseIf (iLoaiData = 6) Then
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT SERVICE_ID , " &
                                                " SERVICE_LEVEL FROM SERVICE_LEVEL ORDER BY SERVICE_LEVEL"))
                    Dim rNull As DataRow = dt.NewRow()
                    rNull("SERVICE_ID") = -1
                    rNull("SERVICE_LEVEL") = ""
                    dt.Rows.InsertAt(rNull, 0)
                    sMa = "SERVICE_ID"
                    sTen = "SERVICE_LEVEL"
                End If

                Try
                    cbo.Properties.DataSource = Nothing
                    cbo.Properties.DisplayMember = ""
                    cbo.Properties.ValueMember = ""
                    cbo.Properties.DataSource = dt
                    cbo.Properties.DisplayMember = sTen
                    cbo.Properties.ValueMember = sMa
                    cbo.Properties.Columns.Clear()
                    cbo.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(sTen))
                    cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                    cbo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
                    cbo.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
                    If dt.Rows.Count > 10 Then cbo.Properties.DropDownRows = 15 Else cbo.Properties.DropDownRows = 10
                    cbo.Properties.ShowHeader = False
                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub BindDataCombo()
        iLoaiData = 0
        loadDataToCombobox(cmbDVT)
        iLoaiData = 1
        loadDataToCombobox(cmbMS_KH)
        iLoaiData = 2
        loadDataToCombobox(cboNhaSanXuat)
        iLoaiData = 3
        loadDataToCombobox(cmbMS_CACH_DAT_HANG)
        iLoaiData = 4
        loadDataToCombobox(cmbLOAI_VT)
        iLoaiData = 5
        loadDataToCombobox(cboClass)
        iLoaiData = 6
        loadDataToCombobox(cboService)

    End Sub
#End Region


#Region "Event cmb click new"

    Private Sub cmbLOAI_VT_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles cmbLOAI_VT.ButtonClick
        If e.Button.Index <> 1 Then Exit Sub
        Dim frm As New Report1.frmLoaivattu()
        Dim sMS As String
        sMS = cmbLOAI_VT.EditValue
        frm.ShowDialog()
        Try
            iLoaiData = 4
            loadDataToCombobox(cmbLOAI_VT)
            cmbLOAI_VT.EditValue = sMS
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbDVT_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles cmbDVT.ButtonClick
        If e.Button.Index <> 1 Then Exit Sub
        Dim frm As New Report1.frmDonvitinh()
        Dim sMS As String
        sMS = cmbDVT.EditValue
        frm.ShowDialog()
        Try
            iLoaiData = 0
            loadDataToCombobox(cmbDVT)
            cmbDVT.EditValue = sMS
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboNhaSanXuat_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles cboNhaSanXuat.ButtonClick
        If e.Button.Index <> 1 Then Exit Sub
        Dim frm As New Report1.frmHangsanxuat()
        Dim iMS As Integer
        iMS = cboNhaSanXuat.EditValue
        frm.ShowDialog()
        Try
            iLoaiData = 2
            loadDataToCombobox(cboNhaSanXuat)
            cboNhaSanXuat.EditValue = iMS
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmbMS_KH_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles cmbMS_KH.ButtonClick
        If e.Button.Index <> 1 Then Exit Sub
        Dim frm As New Report1.frmNhacungcap()
        Dim sMS As String
        sMS = cmbMS_KH.EditValue

        frm.ShowDialog()
        Try
            iLoaiData = 1
            loadDataToCombobox(cmbMS_KH)
            cmbMS_KH.EditValue = sMS
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub frmDanhmucphutung_CS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TableLayoutPanel1.ColumnStyles(5).Width = 0
        ContextMenuStrip1.Items.Add("Check")
        ContextMenuStrip1.Items.Add("UnCheck")
        ContextMenuStrip1.Items.Add("Check All")
        ContextMenuStrip1.Items.Add("UnCheck All")

        Commons.Modules.SQLString = "0Load"
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLVatTu, Commons.Modules.ObjSystems.MLoadDataLoaiVatTu(1), "MS_LOAI_VT", "TEN_LOAI_VT", "")
        LoadDataCombobox()
        LoadData(MSPT)
        Commons.Modules.SQLString = ""
        LocData()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

        lblTong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTong", Commons.Modules.TypeLanguage) + ": " + grvDanhSach.RowCount.ToString()

        Try
            Dim Sql As String = "SELECT VAT_TU_PT FROM THONG_TIN_CHUNG"
            VTPT = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Sql)
        Catch ex As Exception
        End Try
        If Commons.Modules.PermisString.ToUpper().Equals("READ ONLY") Then
            BtnThem.Enabled = False
            BtnSua.Enabled = False
            btnThemsua.Enabled = False
            BtnXoa.Enabled = False
            btnXoa2.Enabled = False
            btnCapNhapMSPT.Enabled = False
            btnActive.Enabled = False
            cmbLOAI_VT.Properties.Buttons(1).Enabled = False
            cmbDVT.Properties.Buttons(1).Enabled = False
            cboNhaSanXuat.Properties.Buttons(1).Enabled = False
            cmbMS_KH.Properties.Buttons(1).Enabled = False
        Else
            BtnThem.Enabled = bFullTTTB
            'BtnSua.Enabled = bFullTTTB
            btnThemsua.Enabled = bFullTTTB
            btnCapNhapMSPT.Enabled = bDoiMS
            btnActive.Enabled = bActivePT
        End If
        If Commons.Modules.sPrivate.ToUpper = "TRUNGNGUYEN" Then
            btnImportPT.Visible = True
        End If


        QuyenINT()
    End Sub

    Public Sub txtSearch_EditValueChanging(sender As Object, e As Controls.ChangingEventArgs) Handles txtSearch.EditValueChanging
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        LocData()
    End Sub

    Private Sub btnCTTB_Click(sender As Object, e As EventArgs) Handles btnCTTB.Click
        If txtMS_PT.Text = "" Then
            Commons.MssBox.Show(Me.Name, "KhongCoMSPT", Me.Text)
            txtMS_PT.Focus()
            Exit Sub
        End If
        Dim frm As New Report1.frmPhuTungMay
        frm.iLoai = 1
        frm.MsPT = txtMS_PT.Text
        frm.btnCtruc = btnCTTB
        frm.ShowDialog()
    End Sub

    Private Sub grvDanhSach_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDanhSach.FocusedRowChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If grvDanhSach.RowCount > 0 Then
            LoadText()
            LoadChiTietPT(0)
        Else
            LoadTextNull()
            LoadChiTietPT(0)
        End If

    End Sub

    Private Sub LoadText()
        Try
            txtHinh.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("ANH_PT").ToString), "", grvDanhSach.GetFocusedRowCellValue("ANH_PT").ToString)
            txtMS_PT.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_PT").ToString), "", grvDanhSach.GetFocusedRowCellValue("MS_PT").ToString)
            txtMS_PT_CTY.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_PT_CTY").ToString), "", grvDanhSach.GetFocusedRowCellValue("MS_PT_CTY").ToString)
            txtMS_PT_NCC.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_PT_NCC").ToString), "", grvDanhSach.GetFocusedRowCellValue("MS_PT_NCC").ToString)
            txtQUY_CACH.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("QUY_CACH").ToString), "", grvDanhSach.GetFocusedRowCellValue("QUY_CACH").ToString)

            txtTEN_PT.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("TEN_PT").ToString), "", grvDanhSach.GetFocusedRowCellValue("TEN_PT").ToString)
            txtTEN_PT_VIET.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("TEN_PT_VIET").ToString), "", grvDanhSach.GetFocusedRowCellValue("TEN_PT_VIET").ToString)

            cboClass.EditValue = Convert.ToInt32(IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_CLASS").ToString), -1, grvDanhSach.GetFocusedRowCellValue("MS_CLASS").ToString))
            cboService.EditValue = Convert.ToInt32(IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("SERVICE_ID").ToString), -1, grvDanhSach.GetFocusedRowCellValue("SERVICE_ID").ToString))

            cboNhaSanXuat.EditValue = Convert.ToInt32(IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_HSX").ToString), -1, grvDanhSach.GetFocusedRowCellValue("MS_HSX").ToString))
            'cboKho.EditValue = Convert.ToInt32(IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_KHO").ToString), -1, grvDanhSach.GetFocusedRowCellValue("MS_KHO").ToString))
            'cboViTriKho.EditValue = Convert.ToInt32(IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_VI_TRI").ToString), -1, grvDanhSach.GetFocusedRowCellValue("MS_VI_TRI").ToString))
            cmbDVT.EditValue = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("DVT").ToString), "", grvDanhSach.GetFocusedRowCellValue("DVT").ToString)
            cmbLOAI_VT.EditValue = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_LOAI_VT").ToString), "", grvDanhSach.GetFocusedRowCellValue("MS_LOAI_VT").ToString)
            cmbMS_CACH_DAT_HANG.EditValue = Convert.ToInt32(IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_CACH_DAT_HANG").ToString), -1, grvDanhSach.GetFocusedRowCellValue("MS_CACH_DAT_HANG").ToString))

            chkDungcuDo.Checked = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("DUNG_CU_DO").ToString), "", grvDanhSach.GetFocusedRowCellValue("DUNG_CU_DO").ToString)
            chkVT.Checked = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("VAT_TU_PT").ToString), "", grvDanhSach.GetFocusedRowCellValue("VAT_TU_PT").ToString)
            ChkTaiSD.Checked = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("TAI_SD").ToString), "", grvDanhSach.GetFocusedRowCellValue("TAI_SD").ToString)
            chkHangNgoai.Checked = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("HANG_NGOAI").ToString), "", grvDanhSach.GetFocusedRowCellValue("HANG_NGOAI").ToString)
            cmbMS_KH.EditValue = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("MS_KH").ToString), "-1", grvDanhSach.GetFocusedRowCellValue("MS_KH").ToString)
            chkTheoKho.Checked = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("THEO_KHO").ToString), "", grvDanhSach.GetFocusedRowCellValue("THEO_KHO").ToString)



            txtUInsert.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("USER_INSERT_PT").ToString), "", grvDanhSach.GetFocusedRowCellValue("USER_INSERT_PT").ToString)
            If String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("NGAY_INSERT_PT").ToString) Then
                txtNInsert.Text = ""
            Else
                txtNInsert.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, grvDanhSach.GetFocusedRowCellValue("NGAY_INSERT_PT").ToString)
            End If

            txtUUpdate.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("USER_UPDATE_PT").ToString), "", grvDanhSach.GetFocusedRowCellValue("USER_UPDATE_PT").ToString)
            If String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("NGAY_UPDATE_PT").ToString) Then
                txtNUpdate.Text = ""
            Else
                txtNUpdate.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, grvDanhSach.GetFocusedRowCellValue("NGAY_UPDATE_PT").ToString)
            End If

            chkActive.Checked = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("ACTIVE_PT").ToString), "", grvDanhSach.GetFocusedRowCellValue("ACTIVE_PT").ToString)
            txtKyPB.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("KY_PB").ToString), "", grvDanhSach.GetFocusedRowCellValue("KY_PB").ToString)

            txtSO_NGAY_DAT_MUA_HANG.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("SO_NGAY_DAT_MUA_HANG").ToString), "", grvDanhSach.GetFocusedRowCellValue("SO_NGAY_DAT_MUA_HANG").ToString)

            If String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("TON_KHO_MAX").ToString) Then
                txtSLTD.Text = 0
            Else
                txtSLTD.Text = String.Format("{0:" + Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL) + "}", Convert.ToDouble(grvDanhSach.GetFocusedRowCellValue("TON_KHO_MAX").ToString))
            End If

            If String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("TON_TOI_THIEU").ToString) Then
                txtTON_TOI_THIEU.Text = 0
            Else
                txtTON_TOI_THIEU.Text = String.Format("{0:" + Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL) + "}", Convert.ToDouble(grvDanhSach.GetFocusedRowCellValue("TON_TOI_THIEU").ToString))
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadTextNull()
        Try
            txtHinh.Text = ""
            txtMS_PT.Text = ""
            txtMS_PT_CTY.Text = ""
            txtMS_PT_NCC.Text = ""
            txtQUY_CACH.Text = ""
            txtSLTD.Text = ""
            txtSO_NGAY_DAT_MUA_HANG.Text = ""
            txtTEN_PT.Text = ""
            txtTEN_PT_VIET.Text = ""
            txtTON_TOI_THIEU.Text = ""

            cboClass.EditValue = -1
            cboService.EditValue = -1
            cboNhaSanXuat.EditValue = -1
            'cboKho.EditValue = -1
            'cboViTriKho.EditValue = -1
            cmbDVT.EditValue = "-1"
            cmbLOAI_VT.EditValue = "-1"
            cmbMS_CACH_DAT_HANG.EditValue = -1
            chkDungcuDo.Checked = False
            chkHangNgoai.Checked = False
            chkVT.Checked = False
            ChkTaiSD.Checked = False
            cmbMS_KH.EditValue = "-1"
            chkTheoKho.Checked = False
            chkActive.Checked = True
            txtUInsert.Text = ""
            txtNInsert.Text = ""
            txtUUpdate.Text = ""
            txtNUpdate.Text = ""
            txtKyPB.Text = ""
            txtSLTon.Text = ""


        Catch ex As Exception
        End Try

    End Sub

    '0 binh thuong, 1 Them, 2 Sua
    Private Sub LoadChiTietPT(iThemSua As Integer)
        Dim dtTmp As New DataTable
        Dim sMsPTung As String
        Try
            sMsPTung = grvDanhSach.GetFocusedRowCellValue("MS_PT").ToString
        Catch ex As Exception
            sMsPTung = "-1"
        End Try
#Region "Loai May"
        Try
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetIcPhuTungLoaiMay", sMsPTung, Commons.Modules.UserName, iThemSua, Commons.Modules.TypeLanguage))
            If iThemSua = 0 Then
                Try
                    If grvLTBi.DataSource Is Nothing Then
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdLTBi, grvLTBi, dtTmp, False, True, True, False)
                    Else
                        grdLTBi.DataSource = Nothing
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdLTBi, grvLTBi, dtTmp, False, False, True, False)
                    End If
                Catch ex As Exception
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdLTBi, grvLTBi, dtTmp, False, True, True, False)
                End Try
                grvLTBi.Columns("CHONLM").OptionsColumn.ReadOnly = True
            Else
                dtTmp.Columns("CHONLM").ReadOnly = False
                Try
                    If grvLTBi.DataSource Is Nothing Then
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdLTBi, grvLTBi, dtTmp, True, True, True, False)
                    Else
                        grdLTBi.DataSource = Nothing
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdLTBi, grvLTBi, dtTmp, True, False, True, False)
                    End If
                Catch ex As Exception
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdLTBi, grvLTBi, dtTmp, True, True, True, False)
                End Try
                grvLTBi.Columns("CHONLM").OptionsColumn.ReadOnly = False
                grvLTBi.Columns("CHONLM").Caption = Commons.Modules.GetNNgu(Me.Name, "CHON_LOAI_MAY")
            End If

            grvLTBi.Columns("MS_LOAI_MAY").Visible = False
            grvLTBi.Columns("CHONLM").Width = 30

            grvLTBi.Columns("CHONLM").Visible = BtnGhi.Visible


        Catch ex As Exception
        End Try
#End Region
#Region "Noi Su Dung"
        Try
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetIcPhuTungLoaiPhuTung", sMsPTung, Commons.Modules.UserName, iThemSua, Commons.Modules.TypeLanguage))

            If iThemSua = 0 Then
                Try
                    If grvNSDung.DataSource Is Nothing Then
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdNSDung, grvNSDung, dtTmp, False, True, True, False)
                    Else
                        grdNSDung.DataSource = Nothing
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdNSDung, grvNSDung, dtTmp, False, False, True, False)
                    End If
                Catch ex As Exception
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNSDung, grvNSDung, dtTmp, False, True, True, False)
                End Try
            Else
                dtTmp.Columns("CHONPT").ReadOnly = False
                Try
                    If grvNSDung.DataSource Is Nothing Then
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdNSDung, grvNSDung, dtTmp, True, True, True, False)
                    Else
                        grdNSDung.DataSource = Nothing
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdNSDung, grvNSDung, dtTmp, True, False, True, False)
                    End If
                Catch ex As Exception
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNSDung, grvNSDung, dtTmp, True, True, True, False)
                End Try
                grvNSDung.Columns("CHONPT").OptionsColumn.ReadOnly = False
                grvNSDung.Columns("TEN_LOAI_PT").OptionsColumn.ReadOnly = True
                grvNSDung.Columns("CHONPT").Caption = Commons.Modules.GetNNgu(Me.Name, "CHON_LOAI_PT")
            End If

            grvNSDung.Columns("MS_LOAI_PT").Visible = False
            grvNSDung.Columns("CHONPT").Width = 30

            grvNSDung.Columns("CHONPT").Visible = BtnGhi.Visible

        Catch ex As Exception
        End Try
#End Region

#Region "Phu Tung Thay The"
        LoadPTTT()
#End Region

#Region "Theo Kho"
        LoadTheoKho(iThemSua)
#End Region
    End Sub


    Private Sub LoadTheoKho(iThemSua As Integer)
        Dim sMsPTung As String
        Try
            sMsPTung = txtMS_PT.Text ' grvDanhSach.GetFocusedRowCellValue("MS_PT").ToString
        Catch ex As Exception
            sMsPTung = "-1"
        End Try
        'Load vi tri Kho
        Try
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetIcPTKho", sMsPTung))

            Try
                If grdKhoPT.DataSource Is Nothing Then
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKhoPT, grvKhoPT, dtTmp, False, True, False, False)
                Else
                    grdKhoPT.DataSource = Nothing
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKhoPT, grvKhoPT, dtTmp, False, False, False, False)
                End If
            Catch ex As Exception
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdKhoPT, grvKhoPT, dtTmp, False, True, False, False)
            End Try
            If iThemSua <> 0 Then
                grvKhoPT.OptionsBehavior.Editable = True
                grvKhoPT.Columns("TEN_KHO").OptionsColumn.ReadOnly = True
                grvKhoPT.Columns("TEN_VI_TRI").OptionsColumn.ReadOnly = True

                dtTmp.Columns("TON_TOI_THIEU").ReadOnly = False
                dtTmp.Columns("TON_KHO_MAX").ReadOnly = False
                dtTmp.Columns("SO_NGAY_DAT_MUA_HANG").ReadOnly = False
                dtTmp.Columns("GHI_CHU").ReadOnly = False

                grvKhoPT.Columns("TON_TOI_THIEU").OptionsColumn.ReadOnly = False
                grvKhoPT.Columns("TON_KHO_MAX").OptionsColumn.ReadOnly = False
                grvKhoPT.Columns("SO_NGAY_DAT_MUA_HANG").OptionsColumn.ReadOnly = False
                grvKhoPT.Columns("GHI_CHU").OptionsColumn.ReadOnly = False

            End If

            If grvKhoPT.Columns("MS_PT").Visible = True Then
                grvKhoPT.Columns("MS_PT").Visible = False
                grvKhoPT.Columns("MS_KHO").Visible = False
                grvKhoPT.Columns("MS_VI_TRI").Visible = False
                grvKhoPT.Columns("TEN_KHO").Width = 150
                grvKhoPT.Columns("TEN_VI_TRI").Width = 150
                grvKhoPT.Columns("GHI_CHU").Width = 300

                grvKhoPT.Columns("TON_TOI_THIEU").Width = 95
                grvKhoPT.Columns("TON_KHO_MAX").Width = 95
                grvKhoPT.Columns("SO_NGAY_DAT_MUA_HANG").Width = 95
            End If

            'Try
            '    txtSLTon.Text = dtTmp.Select().AsEnumerable().Sum(Function(x) x("TON_HT"))
            'Catch ex As Exception
            '    txtSLTon.Text = 0
            'End Try


            'Try
            '{
            '    //exec spGetDataPIL '100000000283678','9WtaCelPwfKkx5rzgSSeAYjRvsGI'
            '    SLTon = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetDataPIL", sMSPT, sToken));
            '}
            'Catch
            '{
            '    SLTon = 0;
            '}
            'If (SLTon == 0) Then
            '                    {
            '    Try
            '    {
            '        CallBack();
            '        SLTon = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetDataPIL", sMSPT, sToken));
            '    }
            '    Catch
            '    {
            '        SLTon = 0;
            '    }
            '}

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub cboKho_EditValueChanged(sender As Object, e As EventArgs)
    '    If BtnGhi.Enabled Then
    '        Try
    '            Dim dtTmp As New DataTable
    '            If cboKho.EditValue Is Nothing Then
    '                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetVI_TRI_KHO", 0))
    '            Else
    '                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetVI_TRI_KHO", cboKho.EditValue))
    '            End If
    '            Dim rNull As DataRow = dtTmp.NewRow()
    '            rNull("MS_VI_TRI") = -1
    '            rNull("TEN_VI_TRI") = ""

    '            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboViTriKho, dtTmp, "MS_VI_TRI", "TEN_VI_TRI", "")
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub chkTheoKho_CheckedChanged(sender As Object, e As EventArgs) Handles chkVT.CheckedChanged, chkTheoKho.CheckedChanged
        'If BtnGhi.Visible = False Then Exit Sub
        If BtnGhi.Visible Then

            If chkTheoKho.Checked = True Then

                txtTON_TOI_THIEU.Properties.ReadOnly = True
                txtKyPB.Properties.ReadOnly = True
                txtSLTD.Properties.ReadOnly = True
                txtSO_NGAY_DAT_MUA_HANG.Properties.ReadOnly = True
            Else

                txtTON_TOI_THIEU.Properties.ReadOnly = False
                txtKyPB.Properties.ReadOnly = False
                txtSLTD.Properties.ReadOnly = False
                txtSO_NGAY_DAT_MUA_HANG.Properties.ReadOnly = False
                Try
                    If sMsPTSua <> "-1" Then
                        txtSO_NGAY_DAT_MUA_HANG.Text = IIf(String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("SO_NGAY_DAT_MUA_HANG").ToString), "", grvDanhSach.GetFocusedRowCellValue("SO_NGAY_DAT_MUA_HANG").ToString)
                        If String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("TON_KHO_MAX").ToString) Then
                            txtSLTD.Text = ""
                        Else
                            txtSLTD.Text = String.Format("{0:" + Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL) + "}", Convert.ToDouble(grvDanhSach.GetFocusedRowCellValue("TON_KHO_MAX").ToString))
                        End If
                        If String.IsNullOrEmpty(grvDanhSach.GetFocusedRowCellValue("TON_TOI_THIEU").ToString) Then
                            txtTON_TOI_THIEU.Text = ""
                        Else
                            txtTON_TOI_THIEU.Text = String.Format("{0:" + Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL) + "}", Convert.ToDouble(grvDanhSach.GetFocusedRowCellValue("TON_TOI_THIEU").ToString))
                        End If

                    End If


                Catch ex As Exception

                End Try


            End If
        Else
            If chkTheoKho.Checked = True Then
                'cboViTriKho.EditValue = -1
                txtSO_NGAY_DAT_MUA_HANG.Text = ""
                txtSLTD.Text = ""
                txtTON_TOI_THIEU.Text = ""
                LoadChiTietPT(0)
            Else
                LoadChiTietPT(0)
            End If
        End If
    End Sub

    Private Sub cboLVatTu_EditValueChanged(sender As Object, e As EventArgs) Handles optActive.EditValueChanged, cboLVatTu.EditValueChanged
        LocData()
    End Sub

    Private Sub LocData()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Try
            If grdDanhSach.DataSource Is Nothing Then Exit Sub

            Dim dtTmp As New DataTable
            Dim sDK As String = " (1 = 1) "

            dtTmp = CType(grdDanhSach.DataSource, DataTable)

            If cboLVatTu.EditValue <> "-1" Then
                sDK = sDK & " AND (MS_LOAI_VT = '" & cboLVatTu.EditValue & "') "
            End If

            If txtSearch.Text <> "" Then
                sDK = sDK & " AND (MS_PT like '%" + txtSearch.Text + "%' OR MS_PT_NCC like '%" + txtSearch.Text + "%' OR MS_PT_CTY like '%" + txtSearch.Text + "%' OR TEN_PT like '%" + txtSearch.Text + "%' OR QUY_CACH like '%" + txtSearch.Text + "%') "

            End If
            If optActive.SelectedIndex = 1 Then
                sDK = sDK + " AND ( ACTIVE_PT = 1 ) "
            End If
            If optActive.SelectedIndex = 2 Then
                sDK = sDK + " AND ( ACTIVE_PT = 0 ) "
            End If

            Try
                dtTmp.DefaultView.RowFilter = sDK
            Catch ex As Exception
                dtTmp.DefaultView.RowFilter = ""
            End Try


            lblTong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblTong", Commons.Modules.TypeLanguage) + ": " + grvDanhSach.RowCount.ToString()
            grvDanhSach_FocusedRowChanged(Nothing, Nothing)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnThoat_Click(sender As Object, e As EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub bLockNut(bTSua As Boolean)
        Try
            txtHinh.Properties.ReadOnly = bTSua
            txtMS_PT.Properties.ReadOnly = bTSua
            txtMS_PT_CTY.Properties.ReadOnly = bTSua
            txtMS_PT_NCC.Properties.ReadOnly = bTSua
            txtQUY_CACH.Properties.ReadOnly = bTSua
            txtSLTD.Properties.ReadOnly = bTSua
            txtSO_NGAY_DAT_MUA_HANG.Properties.ReadOnly = bTSua
            txtTEN_PT.Properties.ReadOnly = bTSua
            txtTEN_PT_VIET.Properties.ReadOnly = bTSua
            txtTON_TOI_THIEU.Properties.ReadOnly = bTSua
            txtKyPB.Properties.ReadOnly = bTSua

            cboClass.Properties.ReadOnly = bTSua
            cboService.Properties.ReadOnly = bTSua
            cboNhaSanXuat.Properties.ReadOnly = bTSua
            cmbDVT.Properties.ReadOnly = bTSua
            cmbLOAI_VT.Properties.ReadOnly = bTSua
            cmbMS_CACH_DAT_HANG.Properties.ReadOnly = bTSua
            cmbMS_KH.Properties.ReadOnly = bTSua

            chkDungcuDo.Properties.ReadOnly = bTSua
            chkVT.Properties.ReadOnly = bTSua
            ChkTaiSD.Properties.ReadOnly = bTSua
            chkHangNgoai.Properties.ReadOnly = bTSua
            chkTheoKho.Properties.ReadOnly = bTSua

            btnCTTB.Visible = bTSua
            btnCapNhapMSPT.Visible = bTSua
            btnActive.Visible = bTSua
            BtnThem.Visible = bTSua
            BtnSua.Visible = bTSua
            BtnXoa.Visible = bTSua
            BtnThoat.Visible = bTSua

            BtnGhi.Visible = Not bTSua
            BtnKhongghi.Visible = Not bTSua

            btnChonKho.Visible = Not bTSua

            grdLTBi.ContextMenuStrip = Nothing
            TableLayoutPanel8.Enabled = bTSua
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThem_Click(sender As Object, e As EventArgs) Handles BtnThem.Click
        LoadTextNull()
        bLockNut(False)
        grdLTBi.ContextMenuStrip = ContextMenuStrip1
        LoadChiTietPT(1)
        txtSO_NGAY_DAT_MUA_HANG.Text = 0
        txtTON_TOI_THIEU.Text = 0
        txtKyPB.Text = 0
        txtSLTD.Text = 0
        txtMS_PT.Focus()
        sMsPTSua = "-1"
        sHinhLuu = "-1"
        strDuongDan = ""
    End Sub

    Private Sub BtnSua_Click(sender As Object, e As EventArgs) Handles BtnSua.Click
        If grvDanhSach.RowCount = 0 Then Exit Sub
        If grdDanhSach.DataSource Is Nothing Then Exit Sub


        bLockNut(False)
        grdLTBi.ContextMenuStrip = ContextMenuStrip1
        LoadChiTietPT(2)
        chkTheoKho_CheckedChanged(Nothing, Nothing)
        Dim vtb As New DataTable
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckDoiMaPT", txtMS_PT.Text))
        txtMS_PT.Focus()
        If vtb.Rows.Count > 0 Then
            txtMS_PT.Properties.ReadOnly = True
            txtMS_PT_CTY.Focus()
        End If
        sMsPTSua = txtMS_PT.Text
        sHinhLuu = txtHinh.Text
        strDuongDan = ""

    End Sub

    Private Sub BtnGhi_Click(sender As Object, e As EventArgs) Handles BtnGhi.Click
        Dim iKyPB As Integer = 0
        Dim sPTLuu As String = txtMS_PT.Text

#Region "Kiem Ghi"
        If KiemGhi() = False Then Exit Sub
#End Region

#Region "Add vao IC_PHU_TUNGInfo"
        Dim objPhuTungInfo As New IC_PHU_TUNGInfo
        objPhuTungInfo = AddDuLieu()
        Try
            If txtKyPB.Text <> "" Then iKyPB = Integer.Parse(txtKyPB.Text)
        Catch ex As Exception
            iKyPB = 0
        End Try
#End Region
        'Xoa + Luu hinh 
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
#Region "Edit"
        Try
            If sMsPTSua <> "-1" Then
                SqlHelper.ExecuteNonQuery(objTrans, "H_UPDATE_IC_PHU_TUNG", objPhuTungInfo.MS_PT, objPhuTungInfo.MS_PT_NCC, objPhuTungInfo.MS_PT_CTY, objPhuTungInfo.MS_KH, objPhuTungInfo.TEN_PT, objPhuTungInfo.TEN_PT_VIET, objPhuTungInfo.TON_TOI_THIEU, objPhuTungInfo.DVT, objPhuTungInfo.SL_DA_DAT_CHUA_MUA, objPhuTungInfo.MS_CACH_DAT_HANG, objPhuTungInfo.SO_NGAY_DAT_MUA_HANG, objPhuTungInfo.DUNG_CU_DO, objPhuTungInfo.HANG_NGOAI, objPhuTungInfo.QUY_CACH, objPhuTungInfo.ANH_PT, objPhuTungInfo.MS_LOAI_VT, sMsPTSua, objPhuTungInfo.MS_HSX, objPhuTungInfo.MS_VI_TRI, objPhuTungInfo.MS_CLASS, objPhuTungInfo.TON_KHO_MAX, objPhuTungInfo.SERVICE_ID, objPhuTungInfo.THEO_KHO, Commons.Modules.UserName, iKyPB, IIf(chkVT.Checked, 1, 0),IIf(ChkTaiSD.Checked, 1, 0))

#Region "Cập nhật lại ms_pt vào các bảng liên quan đến ms_pt vừa được đổi"

                'BẢNG CAU_TRUC_THIET_BI
                Commons.Modules.SQLString = "UPDATE CAU_TRUC_THIET_BI_PHU_TUNG SET MS_PT='" & txtMS_PT.Text.Trim & "' WHERE MS_PT='" & sMsPTSua & "'"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)

                'BẢNG CAU_TRUC_THIET_BI_PHU_TUNG
                Commons.Modules.SQLString = "UPDATE CAU_TRUC_THIET_BI SET MS_PT='" & txtMS_PT.Text.Trim & "' WHERE MS_PT='" & sMsPTSua & "'"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)

                'BẢNG HIEU_CHUAN_DHD
                Commons.Modules.SQLString = "UPDATE HIEU_CHUAN_DHD SET MS_PT='" & txtMS_PT.Text.Trim & "' WHERE MS_PT='" & sMsPTSua & "'"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)

                'BẢNG KE_HOACH_TONG_CONG_VIEC_PHU_TUNG
                Commons.Modules.SQLString = "UPDATE KE_HOACH_TONG_CONG_VIEC_PHU_TUNG SET MS_PT='" & txtMS_PT.Text.Trim & "' WHERE MS_PT='" & sMsPTSua & "'"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)

                'BẢNG MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG
                Commons.Modules.SQLString = "UPDATE MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG SET MS_PT='" & txtMS_PT.Text.Trim & "' WHERE MS_PT='" & sMsPTSua & "'"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)

                'BẢNG PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG
                Commons.Modules.SQLString = "UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET MS_PT='" & txtMS_PT.Text.Trim & "' WHERE MS_PT='" & sMsPTSua & "'"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, Commons.Modules.SQLString)

#End Region
            Else
                SqlHelper.ExecuteNonQuery(objTrans, "H_IC_PHU_TUNG_INSERT_DATA", objPhuTungInfo.MS_PT, objPhuTungInfo.MS_PT_NCC, objPhuTungInfo.MS_PT_CTY, objPhuTungInfo.TEN_PT, objPhuTungInfo.TEN_PT_VIET, objPhuTungInfo.QUY_CACH, objPhuTungInfo.ANH_PT, objPhuTungInfo.MS_LOAI_VT, objPhuTungInfo.DVT, objPhuTungInfo.DUNG_CU_DO, objPhuTungInfo.HANG_NGOAI, objPhuTungInfo.MS_CACH_DAT_HANG, objPhuTungInfo.SO_NGAY_DAT_MUA_HANG, objPhuTungInfo.TON_TOI_THIEU, objPhuTungInfo.MS_KH, objPhuTungInfo.SL_DA_DAT_CHUA_MUA, objPhuTungInfo.MS_HSX, objPhuTungInfo.MS_VI_TRI, objPhuTungInfo.MS_CLASS, objPhuTungInfo.TON_KHO_MAX, objPhuTungInfo.SERVICE_ID, objPhuTungInfo.THEO_KHO, Commons.Modules.UserName, iKyPB, IIf(chkVT.Checked, 1, 0),IIf(ChkTaiSD.Checked, 1, 0))
            End If

#Region "Up loại thiết bị cho phụ tùng"
            SqlHelper.ExecuteNonQuery(objTrans, "DeletedIC_PHU_TUNG_LOAI_MAY", objPhuTungInfo.MS_PT)
            Dim dtTmp As New DataTable
            dtTmp = CType(grdLTBi.DataSource, DataTable).Copy
            dtTmp.DefaultView.RowFilter = "CHONLM = 'True' "
            dtTmp = dtTmp.DefaultView.ToTable

            For Each drRow As DataRow In dtTmp.Rows
                SqlHelper.ExecuteNonQuery(objTrans, "H_IC_PHU_TUNG_INSERT_LOAI_MAY", objPhuTungInfo.MS_PT, drRow("MS_LOAI_MAY").ToString())
            Next
#End Region

#Region "Up đối tượng sư dụng cho phụ tùng"
            SqlHelper.ExecuteNonQuery(objTrans, "DeletedIC_PHU_TUNG_LOAI_PHU_TUNG", objPhuTungInfo.MS_PT)
            dtTmp = New DataTable
            dtTmp = CType(grdNSDung.DataSource, DataTable).Copy
            dtTmp.DefaultView.RowFilter = "CHONPT = 'True' "
            dtTmp = dtTmp.DefaultView.ToTable
            For Each drRow As DataRow In dtTmp.Rows
                SqlHelper.ExecuteNonQuery(objTrans, "H_IC_PHU_TUNG_INSERT_LOAI_PT", objPhuTungInfo.MS_PT, drRow("MS_LOAI_PT").ToString())
            Next
#End Region

#Region "Nhieu Kho"
            'Up Nhieu Kho
            SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, "DELETE FROM IC_PHU_TUNG_KHO WHERE MS_PT = '" & objPhuTungInfo.MS_PT & "' ")

            For i As Integer = 0 To grvKhoPT.RowCount - 1
                SqlHelper.ExecuteNonQuery(objTrans, "MAddIC_PHU_TUNG_KHO", objPhuTungInfo.MS_PT,
                                Integer.Parse(grvKhoPT.GetDataRow(i)("MS_KHO").ToString()) _
                                , grvKhoPT.GetDataRow(i)("MS_VI_TRI").ToString(), Double.Parse(IIf(String.IsNullOrEmpty(grvKhoPT.GetDataRow(i)("TON_TOI_THIEU").ToString()), 0, grvKhoPT.GetDataRow(i)("TON_TOI_THIEU").ToString())),
                                Double.Parse(IIf(String.IsNullOrEmpty(grvKhoPT.GetDataRow(i)("TON_KHO_MAX").ToString()), 0, grvKhoPT.GetDataRow(i)("TON_KHO_MAX").ToString())),
                                grvKhoPT.GetDataRow(i)("GHI_CHU").ToString(),
                                Integer.Parse(IIf(String.IsNullOrEmpty(grvKhoPT.GetDataRow(i)("SO_NGAY_DAT_MUA_HANG").ToString()), 0, grvKhoPT.GetDataRow(i)("SO_NGAY_DAT_MUA_HANG").ToString())))
            Next

#End Region
            Dim sql As String
            If Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu <> "" Then
                sql = "update ic_phu_tung set ten_pt_anh = N'" + Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu + "' where MS_PT =N'" + txtMS_PT.Text + "'"
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql)
            End If

            objTrans.Commit()
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
            objTrans.Rollback()
            Exit Sub
        End Try



#End Region

        If sHinhLuu <> "" Then Commons.Modules.ObjSystems.Xoahinh(sHinhLuu)
        If strDuongDan <> "" Then Commons.Modules.ObjSystems.LuuDuongDan(strDuongDan, txtHinh.Text)

        sMsPTSua = ""
        sHinhLuu = ""
        bLockNut(True)
        LoadData(sPTLuu)
    End Sub

    Private Function KiemGhi() As Boolean
        Try
#Region "Kiem Du Lieu text"
            If txtMS_PT.Text.Trim.Equals("") Then
                Commons.MssBox.Show(Me.Name, "MS_PT_KO_DE_TRONG", Me.Text)
                txtMS_PT.Focus()
                Return False
            Else
                Dim r As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9_]+$+")
                Dim match As Boolean = False
                Dim S As String
                S = ""

                If txtMS_PT.Text.Length() > 0 Then S = txtMS_PT.Text.Replace("/", "")
                If S.Length() > 0 Then S = S.Replace("\", "")
                If S.Length() > 0 Then S = S.Replace("*", "")
                If S.Length() > 0 Then S = S.Replace("-", "")
                If S.Length() > 0 Then S = S.Replace(".", "")
                If S.Length() > 0 Then S = S.Replace("!", "")
                If S.Length() > 0 Then S = S.Replace("@", "")
                If S.Length() > 0 Then S = S.Replace("#", "")

                If S <> "" Then
                    Dim myMatches As System.Text.RegularExpressions.MatchCollection
                    myMatches = r.Matches(S)
                    If myMatches.Count > 0 Then
                        match = True
                    Else
                        match = False
                    End If

                    If Not match Then
                        Commons.MssBox.Show(Me.Name, "MS_PT_KO_CO_KY_TU_DB", Me.Text)
                        txtMS_PT.Focus()
                        Return False
                    End If
                End If
            End If
            If txtTEN_PT.Text.Trim.Equals("") Then
                Commons.MssBox.Show(Me.Name, "TEN_PT_KO_DE_TRONG", Me.Text)
                txtTEN_PT.Focus()
                Return False
            End If

            Dim obj As New Object
            obj = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(MS_PT) AS SO_LUONG FROM IC_PHU_TUNG WHERE MS_PT = '" + txtMS_PT.Text + "'")
            If CType(obj, Integer) > 0 And Not String.Equals(sMsPTSua, txtMS_PT.Text.Trim, StringComparison.OrdinalIgnoreCase) Then
                Commons.MssBox.Show(Me.Name, "MA_DA_DUOC_TAO", Me.Text)
                Return False
            End If

            Dim sSql As String
            If sMsPTSua = "-1" Then
                sSql = "SELECT COUNT(MS_PT) AS SO_LUONG FROM IC_PHU_TUNG WHERE TEN_PT = N'" + txtTEN_PT.Text.Trim + "' AND QUY_CACH = N'" + txtQUY_CACH.Text.Trim + "'"
            Else
                sSql = "SELECT COUNT(MS_PT) AS SO_LUONG FROM IC_PHU_TUNG WHERE TEN_PT = N'" + txtTEN_PT.Text.Trim + "' AND MS_PT <> '" + sMsPTSua + "' AND QUY_CACH = N'" + txtQUY_CACH.Text.Trim + "'"
            End If

            obj = New Object
            obj = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            If CType(obj, Integer) > 0 Then
                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_DA_TON_CO_MUON_TRUNG_KO", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    txtTEN_PT.Focus()
                    Return False
                End If

            End If

            If cmbLOAI_VT.EditValue = "-1" Or cmbLOAI_VT.Text = "" Then
                Commons.MssBox.Show(Me.Name, "LOAI_VT_KO_DE_TRONG", Me.Text)
                cmbLOAI_VT.Focus()
                Return False
            End If
            If cmbDVT.EditValue = "-1" Or cmbDVT.Text = "" Then
                Commons.MssBox.Show(Me.Name, "DVT_KO_DE_TRONG", Me.Text)
                cmbDVT.Focus()
                Return False
            End If
            If cmbMS_CACH_DAT_HANG.EditValue = -1 Or cmbMS_CACH_DAT_HANG.Text = "" Then
                Commons.MssBox.Show(Me.Name, "CACH_DAT_HANG_KO_DE_TRONG", Me.Text)
                cmbMS_CACH_DAT_HANG.Focus()
                Return False
            End If


            If (IIf(String.IsNullOrEmpty(txtSLTD.Text), 0, Double.Parse(txtSLTD.Text)) < IIf(String.IsNullOrEmpty(txtTON_TOI_THIEU.Text), 0, Double.Parse(txtTON_TOI_THIEU.Text))) Then
                Commons.MssBox.Show(Me.Name, "msgTonKhoMaxNhoHonTonKhoMin", Me.Text)
                txtSLTD.Focus()
                Return False
            End If
#End Region


#Region "Kiem Luoi Loai Thiet Bi"
            Dim dtTmp = New DataTable
            dtTmp = CType(grdLTBi.DataSource, DataTable).Copy
            Dim drRows As DataRow() = dtTmp.Select("[CHONLM]='True'")
            If drRows.Length <= 0 Then
                Commons.MssBox.Show(Me.Name, "BAN_CHUA_CHON_LOAI_TB", Me.Text)
                Return False
            End If

#End Region

#Region "Kiem noi Su Dung"
            dtTmp = New DataTable
            dtTmp = CType(grdNSDung.DataSource, DataTable).Copy
            Dim drRows1 As DataRow() = dtTmp.Select("[CHONPT]='True'")
            If drRows1.Length <= 0 Then
                Commons.MssBox.Show(Me.Name, "BAN_CHUA_CHON_NOI_SD", Me.Text)
                Return False
            End If
#End Region

#Region "Kiem neu co check Theo Kho"

            dtTmp = New DataTable()
            dtTmp = CType(grdKhoPT.DataSource, DataTable)
            If dtTmp.Rows.Count <= 0 Then
                Commons.MssBox.Show(Me.Name, "BanChuaChonPTKho", Me.Text)
                Return False
            End If

            Dim SLMin, SLMax As Double
            For Each drRow As DataRow In dtTmp.Rows
                drRow.ClearErrors()
                Try
                    SLMax = drRow("TON_KHO_MAX")
                Catch ex As Exception
                    SLMax = 0
                End Try
                Try
                    SLMin = drRow("TON_TOI_THIEU")
                Catch ex As Exception
                    SLMin = 0
                End Try
                If SLMax < SLMin Then
                    Dim sTmp As String
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SLMaxNhoHonSlMin", Commons.Modules.TypeLanguage)
                    drRow.SetColumnError(4, sTmp)
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SLMinLonHonMax", Commons.Modules.TypeLanguage)
                    drRow.SetColumnError(3, sTmp)
                    Return False
                End If
            Next

#End Region

            Return True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Private Function AddDuLieu() As IC_PHU_TUNGInfo
        Dim objPhuTungInfo As New IC_PHU_TUNGInfo
        Dim objPhuTungController As New IC_PHU_TUNGController()
        objPhuTungInfo.MS_PT_tmp = sMsPTSua
        objPhuTungInfo.MS_PT = Me.txtMS_PT.Text.Trim
        objPhuTungInfo.MS_PT_CTY = Me.txtMS_PT_CTY.Text.Trim
        objPhuTungInfo.MS_PT_NCC = Me.txtMS_PT_NCC.Text.Trim
        objPhuTungInfo.TEN_PT = txtTEN_PT.Text.Trim
        objPhuTungInfo.TEN_PT_VIET = txtTEN_PT_VIET.Text.Trim
        objPhuTungInfo.QUY_CACH = Me.txtQUY_CACH.Text.Trim
        objPhuTungInfo.ANH_PT = txtHinh.Text.Trim
        objPhuTungInfo.TON_KHO_MAX = IIf(txtSLTD.Text.Trim = "", 0, txtSLTD.Text.Trim)
        objPhuTungInfo.TON_TOI_THIEU = IIf(txtTON_TOI_THIEU.Text.Trim = "", 0, txtTON_TOI_THIEU.Text.Trim)
        objPhuTungInfo.SO_NGAY_DAT_MUA_HANG = IIf(txtSO_NGAY_DAT_MUA_HANG.Text.Trim = "", 0, txtSO_NGAY_DAT_MUA_HANG.Text.Trim)
        objPhuTungInfo.DUNG_CU_DO = chkDungcuDo.Checked
        objPhuTungInfo.HANG_NGOAI = chkHangNgoai.Checked
        objPhuTungInfo.THEO_KHO = chkTheoKho.Checked
        objPhuTungInfo.TAI_SD = ChkTaiSD.Checked
        objPhuTungInfo.MS_CLASS = cboClass.EditValue
        objPhuTungInfo.MS_LOAI_VT = cmbLOAI_VT.EditValue
        objPhuTungInfo.DVT = cmbDVT.EditValue
        objPhuTungInfo.MS_CACH_DAT_HANG = cmbMS_CACH_DAT_HANG.EditValue
        objPhuTungInfo.SERVICE_ID = cboService.EditValue
        objPhuTungInfo.MS_HSX = cboNhaSanXuat.EditValue
        objPhuTungInfo.MS_KH = cmbMS_KH.EditValue
        Return objPhuTungInfo
    End Function

    Private Sub BtnKhongghi_Click(sender As Object, e As EventArgs) Handles BtnKhongghi.Click
        sMsPTSua = ""
        sHinhLuu = ""
        strDuongDan = ""
        bLockNut(True)
        grvDanhSach_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub tabthongtinphutung_SelectedPageChanging(sender As Object, e As DevExpress.XtraTab.TabPageChangingEventArgs) Handles tabthongtinphutung.SelectedPageChanging
        If BtnGhi.Visible Or btnGhi2.Visible Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub grvLTBi_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvLTBi.CellValueChanging
        Try
            If (txtMS_PT.Properties.ReadOnly) Then
                Dim OBJ As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_IC_PHU_TUNG_CHECK_LOAI_MAY", sMsPTSua, grvLTBi.GetFocusedRowCellValue("MS_LOAI_MAY").ToString)
                If CType(OBJ, Integer) > 0 Then
                    Commons.MssBox.Show(Name, "DA_CO_TRONG_CTTB_KO_SUA", Me.Text)
                    grvLTBi.GetFocusedDataRow("CHONLM") = "True"
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnChonKho_Click(sender As Object, e As EventArgs) Handles btnChonKho.Click
        Try
            If txtMS_PT.Text = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaChonPhuTung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim frm As frmChonKho = New frmChonKho()
            Dim dtTmp As DataTable
            dtTmp = CType(grdKhoPT.DataSource, DataTable).Copy()
            Try
                frm.MsPT = txtMS_PT.Text

            Catch ex As Exception
                frm.MsPT = ""

            End Try
            frm.dtKho = New DataTable
            frm.dtKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetKhoDSPT", txtMS_PT.Text))
            frm.dtKho.Columns("CHON").ReadOnly = False
            frm.dtKho.Columns("TON_KHO_MAX").ReadOnly = False
            frm.dtKho.Columns("MS_VI_TRI").ReadOnly = False
            frm.dtKho.Columns("TON_TOI_THIEU").ReadOnly = False
            frm.dtKho.Columns("SO_NGAY_DAT_MUA_HANG").ReadOnly = False
            frm.dtKho.Columns("GHI_CHU").ReadOnly = False

            For Each drRow As DataRow In dtTmp.Rows
                For Each drKho As DataRow In frm.dtKho.Rows
                    If drRow("MS_KHO").ToString() = drKho("MS_KHO").ToString() Then
                        drKho("CHON") = 1
                        Try
                            drKho("TON_TOI_THIEU") = drRow("TON_TOI_THIEU")
                        Catch ex As Exception
                        End Try
                        Try
                            drKho("GHI_CHU") = drRow("GHI_CHU")
                        Catch ex As Exception
                        End Try
                        Try
                            drKho("TON_KHO_MAX") = drRow("TON_KHO_MAX")
                        Catch ex As Exception
                        End Try
                        Try
                            drKho("SO_NGAY_DAT_MUA_HANG") = drRow("SO_NGAY_DAT_MUA_HANG")
                        Catch ex As Exception
                        End Try
                        Exit For
                    End If
                Next
            Next


            If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

            Dim dtKhoPT As New DataTable
            dtKhoPT = CType(grdKhoPT.DataSource, DataTable)
            dtKhoPT.Clear()
            Dim drKhoPT As DataRow

            frm.dtKho.DefaultView.RowFilter = "CHON = 1"
            If frm.dtKho.DefaultView.ToTable().Rows.Count <= 0 Then
                Exit Sub
            End If


            For Each drRowKho As DataRow In frm.dtKho.Rows
                If Convert.ToBoolean(drRowKho("CHON").ToString()) = True Then
                    drKhoPT = dtKhoPT.NewRow()
                    drKhoPT("TEN_KHO") = drRowKho("TEN_KHO").ToString()
                    drKhoPT("TEN_VI_TRI") = ""
                    drKhoPT("MS_VI_TRI") = drRowKho("MS_VI_TRI").ToString()
                    Try
                        drKhoPT("TON_TOI_THIEU") = Double.Parse(drRowKho("TON_TOI_THIEU").ToString())
                    Catch ex As Exception
                        drKhoPT("TON_TOI_THIEU") = 0
                    End Try
                    Try
                        drKhoPT("GHI_CHU") = drRowKho("GHI_CHU").ToString()
                    Catch ex As Exception
                        drKhoPT("GHI_CHU") = ""
                    End Try
                    Try
                        drKhoPT("TON_KHO_MAX") = Convert.ToDouble(drRowKho("TON_KHO_MAX").ToString())
                    Catch ex As Exception
                        drKhoPT("TON_KHO_MAX") = 0
                    End Try
                    Try
                        drKhoPT("SO_NGAY_DAT_MUA_HANG") = Convert.ToDouble(drRowKho("SO_NGAY_DAT_MUA_HANG").ToString())
                    Catch ex As Exception
                        drKhoPT("SO_NGAY_DAT_MUA_HANG") = 0
                    End Try
                    drKhoPT("MS_KHO") = drRowKho("MS_KHO").ToString()
                    drKhoPT("MS_PT") = txtMS_PT.Text
                    Dim str As String = "SELECT SUM(SL_VT) FROM VI_TRI_KHO_VAT_TU WHERE ISNULL(SL_VT,0) > 0 AND MS_PT = '" & txtMS_PT.Text & "' AND  MS_KHO = '" & drRowKho("MS_KHO").ToString() & "'  GROUP BY MS_PT,MS_KHO,MS_VI_TRI"
                    Try
                        drKhoPT("TON_HT") = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str).ToString()
                    Catch ex As Exception
                        drKhoPT("TON_HT") = 0
                    End Try
                    dtKhoPT.Rows.Add(drKhoPT)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTEN_PT_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles txtTEN_PT.ButtonClick
        If txtMS_PT.Text.Trim = "" Then Exit Sub
        Dim sLoi As String = ""
        If Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblfrmDanhmucphutung_CS_Anh", Commons.Modules.TypeLanguage), "IC_PHU_TUNG", "TEN_PT_ANH", " WHERE MS_PT = N'" + txtMS_PT.Text + "'", sLoi, "frmDanhmucphutung_CS") = False Then
            XtraMessageBox.Show(sLoi)
        End If
    End Sub

#Region "PTTT"

    Private Sub btnThemsua_Click(sender As Object, e As EventArgs) Handles btnThemsua.Click
        Panel2.Enabled = Not Panel2.Enabled
        btnThemsua.Visible = Not btnThemsua.Visible
        btnXoa2.Visible = Not btnXoa2.Visible
        btnGhi2.Visible = Not btnGhi2.Visible
        btnKhongghi2.Visible = Not btnKhongghi2.Visible
        btnchonphutung.Visible = Not btnchonphutung.Visible
        TableLayoutPanel8.Enabled = Not TableLayoutPanel8.Enabled
    End Sub

    Private Sub btnXoa2_Click(sender As Object, e As EventArgs) Handles btnXoa2.Click
        If grvPTTT.RowCount > 0 Then
            Dim obj_ic_phutung As New IC_PHU_TUNGController
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa_pttt", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            obj_ic_phutung.Delete_IC_PHU_TUNG_THAY_THE(txtMS_PT.Text, grvPTTT.GetFocusedRowCellValue("MS_PT").ToString)
            LoadPTTT()
        End If
    End Sub

    Private Sub btnGhi2_Click(sender As Object, e As EventArgs) Handles btnGhi2.Click

        Dim i As Integer
        Dim obj_ic_phutung As New IC_PHU_TUNGController

        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try

            'obj_ic_phutung.Delete_All_IC_PHU_TUNG_THAY_THE(txtMS_PT.Text)
            SqlHelper.ExecuteNonQuery(objTrans, "Delete_All_IC_PHU_TUNG_THAY_THE", txtMS_PT.Text)
            For i = 0 To Me.grvPTTT.RowCount - 1
                'obj_ic_phutung.Add_IC_PHU_TUNG_THAY_THE(txtMS_PT.Text, grvPTTT.GetDataRow(i)("MS_PT").ToString)
                SqlHelper.ExecuteNonQuery(objTrans, "Add_IC_PHU_TUNG_THAY_THE", txtMS_PT.Text, grvPTTT.GetDataRow(i)("MS_PT").ToString)
            Next
            objTrans.Commit()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            objTrans.Rollback()
            Exit Sub
        End Try

        Panel2.Enabled = Not Panel2.Enabled
        btnThemsua.Visible = Not btnThemsua.Visible
        btnXoa2.Visible = Not btnXoa2.Visible
        btnGhi2.Visible = Not btnGhi2.Visible
        btnKhongghi2.Visible = Not btnKhongghi2.Visible
        btnchonphutung.Visible = Not btnchonphutung.Visible
        TableLayoutPanel8.Enabled = Not TableLayoutPanel8.Enabled
        LoadPTTT()
    End Sub

    Private Sub btnKhongghi2_Click(sender As Object, e As EventArgs) Handles btnKhongghi2.Click
        Panel2.Enabled = Not Panel2.Enabled
        btnThemsua.Visible = Not btnThemsua.Visible
        btnXoa2.Visible = Not btnXoa2.Visible
        btnGhi2.Visible = Not btnGhi2.Visible
        btnKhongghi2.Visible = Not btnKhongghi2.Visible
        btnchonphutung.Visible = Not btnchonphutung.Visible
        TableLayoutPanel8.Enabled = Not TableLayoutPanel8.Enabled
        LoadPTTT()
    End Sub


    Private Sub LoadPTTT()
        Try
            Dim sMsPTung As String
            Try
                sMsPTung = grvDanhSach.GetFocusedRowCellValue("MS_PT").ToString
            Catch ex As Exception
                sMsPTung = "-1"
            End Try
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_IC_PHU_TUNG_GET_PTTT", sMsPTung))

            Try
                If grdPTTT.DataSource Is Nothing Then
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTT, grvPTTT, dtTmp, False, True, True, False)
                Else
                    grdPTTT.DataSource = Nothing
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTT, grvPTTT, dtTmp, False, False, True, False)
                End If
            Catch ex As Exception
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTT, grvPTTT, dtTmp, False, True, True, False)
            End Try
            grvPTTT.Columns("MS_PT").OptionsColumn.FixedWidth = True
        Catch ex As Exception
        End Try
    End Sub

    Sub INIT_TABLE(ByVal TABLE As DataTable)
        TABLE.Columns.Add("MS_PT")
        TABLE.Columns("MS_PT").DataType = Type.GetType("System.String")
        TABLE.Columns.Add("TEN_PT")
        TABLE.Columns("TEN_PT").DataType = Type.GetType("System.String")
    End Sub

    Private Sub btnchonphutung_Click(sender As Object, e As EventArgs) Handles btnchonphutung.Click
        Dim dtNew As New DataTable
        Dim drNew As DataRow
        Dim i As Integer = 0
        Dim j As Integer = 0

        INIT_TABLE(dtNew)
        Try

            For i = 0 To grvPTTT.RowCount - 1
                drNew = dtNew.NewRow
                drNew.Item(0) = grvPTTT.GetDataRow(i)("MS_PT").ToString
                drNew.Item(1) = grvPTTT.GetDataRow(i)("TEN_PT").ToString
                dtNew.Rows.Add(drNew)
            Next

            Dim fPT As New frmChonphutung_thaythe()

            Dim thietbi As String = "('" + Me.grvLTBi.GetDataRow(0)("MS_LOAI_MAY").ToString() + "'"
            Dim noisd As String = "('" + Me.grvNSDung.GetDataRow(0)("MS_LOAI_PT").ToString() + "'"
            Dim phutung As String = "('" + txtMS_PT.Text + "'"

            For i = 1 To Me.grvLTBi.RowCount - 1
                thietbi = thietbi + ",'" + Me.grvLTBi.GetDataRow(i)("MS_LOAI_MAY").ToString() + "'"
            Next
            thietbi = thietbi + ")"

            For i = 1 To Me.grvNSDung.RowCount - 1
                noisd = noisd + ",'" + Me.grvNSDung.GetDataRow(0)("MS_LOAI_PT").ToString() + "'"
            Next
            noisd = noisd + ")"

            For i = 0 To grvPTTT.RowCount - 1
                phutung = phutung + ",'" + grvPTTT.GetDataRow(i)("MS_PT").ToString + "'"
            Next
            phutung = phutung + ")"

            fPT.Query = "SELECT DISTINCT  CONVERT(BIT, 0) AS CHON, T1.MS_PT, T1.MS_PT_NCC, T1.MS_PT_CTY, T1.TEN_PT, T1.TEN_PT_VIET, T1.QUY_CACH
                            FROM            dbo.IC_PHU_TUNG AS T1 INNER JOIN
                                                     dbo.IC_PHU_TUNG_LOAI_PHU_TUNG AS T2 ON T1.MS_PT = T2.MS_PT INNER JOIN
                                                     dbo.LOAI_PHU_TUNG AS T3 ON T3.MS_LOAI_PT = T2.MS_LOAI_PT INNER JOIN
                                                     dbo.IC_PHU_TUNG_LOAI_MAY AS T4 ON T4.MS_PT = T1.MS_PT INNER JOIN
                                                     dbo.LOAI_MAY AS T5 ON T5.MS_LOAI_MAY = T4.MS_LOAI_MAY INNER JOIN
                                                     dbo.NHOM_LOAI_MAY AS T6 ON T6.MS_LOAI_MAY = T5.MS_LOAI_MAY INNER JOIN
                                                     dbo.NHOM AS T7 ON T7.GROUP_ID = T6.GROUP_ID INNER JOIN
                                                     dbo.USERS AS T8 ON T8.GROUP_ID = T7.GROUP_ID
                            WHERE        (T1.ACTIVE_PT = 1) AND (T8.USERNAME = '" & Commons.Modules.UserName & "') 
                                AND (T5.MS_LOAI_MAY IN " & thietbi & " ) AND (T3.MS_LOAI_PT IN " & noisd & ") AND (T1.MS_PT NOT IN " & phutung & ") 
                                ORDER BY T1.MS_PT
                            "


            If fPT.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    Dim dtTmp = New DataTable()
                    dtTmp = CType(fPT.grdPTung.DataSource, DataTable).Copy
                    dtTmp.DefaultView.RowFilter = "CHON = True"
                    dtTmp = dtTmp.DefaultView.ToTable

                    For i = 0 To dtTmp.Rows.Count - 1
                        If Convert.ToBoolean(dtTmp.Rows(i)("CHON").ToString()) = True Then
                            drNew = dtNew.NewRow
                            drNew.Item(0) = dtTmp.Rows(i)("MS_PT").ToString()
                            drNew.Item(1) = dtTmp.Rows(i)("TEN_PT").ToString()

                            dtNew.Rows.Add(drNew)
                        End If
                    Next
                    Try
                        If grdPTTT.DataSource Is Nothing Then
                            Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTT, grvPTTT, dtNew, False, True, True, False)
                        Else
                            grdPTTT.DataSource = Nothing
                            Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTT, grvPTTT, dtNew, False, False, True, False)
                        End If
                    Catch ex As Exception
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTT, grvPTTT, dtNew, False, True, True, False)
                    End Try
                    grvPTTT.Columns("MS_PT").OptionsColumn.FixedWidth = True
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

    End Sub
#End Region


    Private Sub BtnXoa_Click(sender As Object, e As EventArgs) Handles BtnXoa.Click

        Dim objPhuTungController As New IC_PHU_TUNGController()
        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
#Region "Kiem Du Lieu"
        If objPhuTungController.CheckUsedCAU_TRUC_THIET_BI(Me.txtMS_PT.Text.Trim) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa2", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.CheckUsedCHU_KY_HIEU_CHUAN(Me.txtMS_PT.Text.Trim.Trim) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa3", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.CheckUsedNHAP_KHO_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa6", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.CheckUsedXUAT_KHO_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa7", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.CheckUsedMAY_LOAI_BTPN_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa4", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.CheckUsedKIEM_KE_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa5", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.CheckUsedCAU_TRUC_THIET_BI_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            Commons.MssBox.Show(Me.Name, "MsgXoa8", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.Check_UsedEOR_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            ' Phụ tùng này đang được sử dụng trong EOR ! Bạn không thể xóa !
            Commons.MssBox.Show(Me.Name, "MsgXoa9", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.Check_UsedEOR_TINH_TRANG_MNR(Me.txtMS_PT.Text.Trim) Then
            ' Phụ tùng này đang được sử dụng trong EOR_TINH_TRANG_MNR ! Bạn không thể xóa !
            Commons.MssBox.Show(Me.Name, "MsgXoa10", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.Check_UsedKE_HOACH_TONG_CONG_VIEC_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            ' Phụ tùng này đang được sử dụng trong kế hoạch tổng thể công việc ! Bạn không thể xóa !
            Commons.MssBox.Show(Me.Name, "MsgXoa11", Me.Text)
            Exit Sub
        End If

        If objPhuTungController.Check_UsedPHIEU_BAO_TRI_CV_PT_IC_PHU_TUNG(Me.txtMS_PT.Text.Trim) Then
            ' Phụ tùng này đang được sử dụng trong phiếu bảo trì-công việc-phụ tùng ! Bạn không thể xóa !
            Commons.MssBox.Show(Me.Name, "MsgXoa12", Me.Text)
            Exit Sub
        End If


        Dim str As String
        Dim dtReader As SqlDataReader
        str = "SELECT MS_PT FROM PICK_LIST_CHI_TIET WHERE MS_PT='" & txtMS_PT.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgPickList", Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        str = "SELECT MS_PT FROM VI_TRI_KHO_VAT_TU WHERE MS_PT='" & txtMS_PT.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgViTriVatTu", Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        str = "SELECT MS_PT FROM DI_CHUYEN_VI_TRI_TRONG_KHO WHERE MS_PT='" & txtMS_PT.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgDiChuyenViVatTu", Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        str = "SELECT MS_PT FROM DON_DAT_HANG_CHI_TIET WHERE MS_PT='" & txtMS_PT.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgDonDatHang", Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        str = "SELECT MS_PT FROM DE_XUAT_MUA_HANG_CHI_TIET WHERE MS_PT='" & txtMS_PT.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While dtReader.Read
            Commons.MssBox.Show(Me.Name, "MsgDeXuatMuaHang", Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
#End Region

        Dim vcon As New SqlConnection(Commons.IConnections.ConnectionString)
        vcon.Open()
        Dim vtran As SqlTransaction = vcon.BeginTransaction

        Try
            SqlHelper.ExecuteNonQuery(vtran, "MDeleteIC_PHU_TUNG_KHO", grvDanhSach.GetFocusedDataRow()("MS_PT").ToString())
            SqlHelper.ExecuteNonQuery(vtran, "H_IC_PHU_TUNG_DELETE_IC_LOAI_VT", grvDanhSach.GetFocusedDataRow()("MS_PT").ToString())
            SqlHelper.ExecuteNonQuery(vtran, "H_IC_PHU_TUNG_DELETE_LOAI_PT", grvDanhSach.GetFocusedDataRow()("MS_PT").ToString())
            SqlHelper.ExecuteNonQuery(vtran, "H_IC_PHU_TUNG_DELETE_PTTT", grvDanhSach.GetFocusedDataRow()("MS_PT").ToString())
            SqlHelper.ExecuteNonQuery(vtran, "H_IC_PHU_TUNG_DELETE", grvDanhSach.GetFocusedDataRow()("MS_PT").ToString())
            vtran.Commit()
        Catch ex As Exception
            vtran.Rollback()
            XtraMessageBox.Show(ex.Message)
        End Try
        vcon.Close()
        LoadData("-1")
        grvDanhSach_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub btnActive_Click(sender As Object, e As EventArgs) Handles btnActive.Click
        Dim sSql As String = ""
        If bActivePT = False Then
            Commons.MssBox.Show(Me.Name, "MsgNoAccess", Me.Text)
            Exit Sub
        End If

        If chkActive.Checked Then
            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoChacBoActive", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub
            sSql = " UPDATE IC_PHU_TUNG SET ACTIVE_PT = 0 WHERE MS_PT = '" + txtMS_PT.Text + "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        End If

        If chkActive.Checked = False Then
            If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoChacActive", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No) Then Exit Sub
            sSql = " UPDATE IC_PHU_TUNG SET ACTIVE_PT = 1 WHERE MS_PT = '" + txtMS_PT.Text + "' "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
        End If
        Dim sMsPT = txtMS_PT.Text
        Commons.Modules.SQLString = "0Load"
        If optActive.SelectedIndex <> 0 Then optActive.SelectedIndex = 0
        LoadData(sMsPT)
        Commons.Modules.SQLString = ""
        LocData()
    End Sub

    Private Sub btnCapNhapMSPT_Click(sender As Object, e As EventArgs) Handles btnCapNhapMSPT.Click
        Dim sText As String = ""
        Try
            Dim dtTMP = New DataTable()
            dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CheckDoiMaPT", txtMS_PT.Text))
            If dtTMP.Rows.Count > 0 Then
                Commons.MssBox.Show(Me.Name, "DaCoPhatSinhKhongThayDoi", Me.Text)
                Exit Sub
            End If
            sText = Commons.XtraInputBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NhapMa", Commons.Modules.TypeLanguage) & ".", Me.Text)
            If sText = "" Or sText = txtMS_PT.Text Then Exit Sub
            dtTMP = New DataTable()
            dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "CapNhapPT", txtMS_PT.Text, sText))
            If dtTMP.Rows(0)(0) Then
                Commons.MssBox.Show(Me.Name, "CapNhapThanhCong", Me.Text)
            Else
                Commons.MssBox.Show(Me.Name, "CapNhapKhongThanhCong", Me.Text)
            End If
        Catch ex As Exception
            Commons.MssBox.Show(Me.Name, "CapNhapKhongThanhCong", Me.Text)
            Exit Sub
        End Try
        LoadData(sText)
    End Sub

    Private Sub frmDanhmucphutung_CS_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            If BtnGhi.Visible Then Exit Sub
            If MSPT = "-1" Then Exit Sub
            Dim index As Integer
            index = grvDanhSach.LocateByValue(0, grvDanhSach.Columns("MS_PT"), MSPT)
            If index <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                grvDanhSach.FocusedRowHandle = index
                grvDanhSach.SelectRow(index)
            End If
            MSPT = "-1"
        Catch ex As Exception
        End Try
    End Sub
    'Import phụ tùng vào CMMS
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImportPT.Click
        Dim importPT As New ReportMain.frmChonInPhieuBaoTri
        importPT.iLoaiIP = 1
        If importPT.ShowDialog = DialogResult.OK Then
            LoadData("-1")
        End If
    End Sub
End Class
