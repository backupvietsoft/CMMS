Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Common.Data
Imports Commons.QL.Events
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons
Imports DevExpress.XtraEditors
Imports ReportMain

Public Class FrmPhieuXuatKhoVatTu_CS
    Private callback As New QLCallBackEvent
    Private actionButton As Boolean = False
    Private status As Boolean = True
    Dim lstDHXVT As New List(Of IC_DON_HANG_XUAT_VAT_TU_Info)
    Dim lstCTVTPT As New List(Of CHI_TIET_VAT_TU_XUAT_Info)
    'Private hasDataCTXuatVT As New Hashtable
    Dim MS_PT As String = ""
    Dim ID_XUAT As Double = 0
    Dim isFirst As Boolean = False
    Dim dtPhieuXuat As New DataTable
    Dim objDonHangXuatController As New IC_DON_HANG_XUAT_Controller
    Dim bXuatBTMoi As Boolean = False

    Private Sub FrmPhieuXuatKhoVatTu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.SQLString = "0Load"
        LyDoXuatKeToan()
        LoadDonViNhan()
        LoadMay()
        LOAD_FORM()


        If Commons.Modules.sPrivate.ToUpper <> "ACECOOK" Then
            txtSLe.Visible = False
            lblSoLe.Visible = False
        End If
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        btnTimCX.Text = "..."
        If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Visible = True Else btnInDN.Visible = False
        Commons.Modules.SQLString = ""
        Try
            If grvDanhsachXuatkhoPT.RowCount > 0 And Me.grvXuatkhoPTCT.RowCount = 0 Then
                LoadVTPT()
            End If


        Catch ex As Exception

        End Try
        Try
            If Me.grvXuatkhoPTCT.RowCount > 0 And Me.grvSLtheoViTri.RowCount = 0 Then
                intRowPT = 0
                LoadViTriXuat()
            End If
        Catch ex As Exception

        End Try
        Commons.Modules.SQLString = ""
    End Sub

    Public Sub LyDoXuatKeToan()
        Try
            Dim _table As New DataTable
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetLyDoXuatKT"))
            Me.cboLDXKT.DataSource = _table
            cboLDXKT.ValueMember = "MS_LY_DO_XUAT_KT"
            cboLDXKT.DisplayMember = "TEN_LY_DO_XUAT_KT"
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LOAD_FORM()
        If Check_User_Form() Then
            LoadPBT()
            LoadCbChiPhi()
            Try
                Dim _table As New DataTable
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LISTKHO", Commons.Modules.UserName))
                Me.cboKHO.DataSource = _table
                cboKHO.ValueMember = "MS_KHO"
                cboKHO.DisplayMember = "TEN_KHO"
            Catch ex As Exception

            End Try

            Try
                Dim _tableKhoChinh As New DataTable
                _tableKhoChinh.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetViTriTreeListAll", Commons.Modules.UserName, Commons.Modules.TypeLanguage))
                Commons.Modules.ObjSystems.MLoadCboTreeList(cboKHO_CHINH, _tableKhoChinh, "MS_CHA", "MS_VI_TRI", "TEN_VI_TRI")
            Catch ex As Exception
            End Try
            Me.cboDANG_XUAT.Display = "DANG_XUAT_VIET"
            Me.cboDANG_XUAT.BindDataSource()
            Dim TbKho As DataTable = New DataTable()
            TbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_KHO", Commons.Modules.UserName))
            lokWareHouse.Properties.DataSource = TbKho
            lokWareHouse.Properties.ValueMember = "MS_KHO"
            lokWareHouse.Properties.DisplayMember = "TEN_KHO"
            Commons.Modules.ObjSystems.MLoadLookUpEdit(lokWareHouse, TbKho, "MS_KHO", "TEN_KHO", "TEN_KHO")
            Dim NgayHT As Date = Commons.Modules.ObjSystems.GetNgayHeThong()
            datFromDate.DateTime = Convert.ToDateTime("01/" & NgayHT.Month & "/" & NgayHT.Year)
            datToDate.DateTime = NgayHT
            Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
            lokWareHouse.EditValue = -1
            dtpNGAY_CHUNG_TU.DateTime = NgayHT
            AddHandler cboDANG_XUAT.SelectedIndexChanged, AddressOf Me.cboDANG_XUAT_SelectedIndexChanged
            AddHandler cboDANG_XUAT.SelectedValueChanged, AddressOf Me.cboDANG_XUAT_SelectedValueChanged
            Show()
            EnableControl(False)
            SetVisibleButton(True)
            isFirst = True
        End If
    End Sub

    Private Sub LoadPBT()
        Dim iTThai As Integer = 0
        If btnGHI.Visible = True Then iTThai = 1

        If btnLockPhieuXuat.Enabled = False Then
            cboPhieuBaoTri.Param = iTThai
            cboPhieuBaoTri.StoreName = "QL_LIST_PHIEU_BAO_TRI_ALL"
        Else
            cboPhieuBaoTri.StoreName = "QL_LIST_PHIEU_BAO_TRI"
        End If
        cboPhieuBaoTri.Display = "TEN"
        cboPhieuBaoTri.DropDownWidth = 250
        cboPhieuBaoTri.AssemblyName = Application.StartupPath & "\Report1.dll"
        cboPhieuBaoTri.ClassName = "frmLapphieubaotri_CS"
        Me.cboPhieuBaoTri.BindDataSource()
    End Sub

    Private Sub LoadMay()
        cboMay.StoreName = "GetMAY_PQ"
        cboMay.ValueMember = "MS_MAY"
        cboMay.DisplayMember = "MSMAY"
        cboMay.Param = Commons.Modules.UserName
        cboMay.DropDownWidth = 250
        Me.cboMay.BindDataSource()
    End Sub

    Function Check_User_Form() As Boolean
        Select Case Commons.Modules.PermisString.ToUpper()
            Case "Full access".ToUpper()
                actionButton = True
                If Me.grvDanhsachXuatkhoPT.RowCount > 0 Then
                    BtnIN.Enabled = True
                    If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = True Else btnInDN.Visible = False
                    Try
                    Catch ex As Exception
                    End Try
                    grdDanhsachXuatkhoPT.Focus()
                    'LoadVTPT()
                Else
                    btnLockPhieuXuat.Enabled = False
                    btnSUA.Enabled = False
                    btnXOA.Enabled = False
                    BtnIN.Enabled = False
                    If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = False Else btnInDN.Visible = False
                End If
                btnImport.Visible = Commons.Modules.sPrivate.ToUpper = "TRUNGNGUYEN"
                Exit Select
            Case "Read only".ToUpper()
                Me.btnLockPhieuXuat.Enabled = False
                Me.BtnTHEM.Enabled = False
                Me.btnSUA.Enabled = False
                Me.btnXOA.Enabled = False
                Me.btnKHONG_GHI.Enabled = False
                Me.btnGHI.Enabled = False
                Me.btnSUA.Enabled = False
                Me.btnGHI.Enabled = False
                Me.btnXOA.Enabled = False
                Me.btnXOA.Enabled = False


                If Me.grvDanhsachXuatkhoPT.RowCount > 0 Then
                    BtnIN.Enabled = True
                    BtnIN.Visible = True
                    If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = True Else btnInDN.Visible = False
                Else

                    BtnIN.Enabled = False
                    If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = False Else btnInDN.Visible = False
                End If
                btnImport.Visible = False
                Me.btnLockPhieuXuat.Visible = False
                Me.btnUnLock.Visible = False
                Exit Select
            Case "No access"
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoAccess", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Dispose()
                Return False
                Exit Select
            Case Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoAccess1", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Dispose()
                Return False
                Exit Select
        End Select

        If Commons.Modules.PermisString.ToUpper = "Full access".ToUpper Then
            If Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 56) Then
                If chkIsLock.Checked Then
                    btnUnLock.Visible = True
                    btnLockPhieuXuat.Visible = False
                Else
                    btnUnLock.Visible = False
                    btnLockPhieuXuat.Visible = True
                End If
            End If

        End If
        Return True
    End Function

    Sub CallBackData(ByVal lstDHX As List(Of IC_DON_HANG_XUAT_VAT_TU_Info))
        Me.grdXuatkhoPTCT.DataSource = Nothing
        Me.grdXuatkhoPTCT.DataSource = lstDHX
        If cboDANG_XUAT.SelectedValue = 9 Then
            grvXuatkhoPTCT.Columns("CHI_PHI").Visible = True
            grvXuatkhoPTCT.Columns("CHI_PHI").OptionsColumn.ReadOnly = False
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvXuatkhoPTCT, Me.Name)
            grvSLtheoViTri.OptionsBehavior.Editable = True
            grvSLtheoViTri.Columns("DON_GIA").OptionsColumn.ReadOnly = False
        Else
            grvXuatkhoPTCT.Columns("CHI_PHI").Visible = False
        End If
        Try
            If Me.grvXuatkhoPTCT.RowCount > 0 Then
                MS_PT = grvXuatkhoPTCT.GetFocusedRowCellValue("MS_PT")
                intRowPT = 0
                Try
                    LoadViTriXuat()
                Catch ex As Exception
                End Try
            Else
                Me.grdSLtheoViTri.DataSource = System.DBNull.Value
            End If
            If Me.grvXuatkhoPTCT.Columns("MS_DH_XUAT_PT") IsNot Nothing Then
                Me.grvXuatkhoPTCT.Columns("MS_DH_XUAT_PT").Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub


    Function Nhu_Y_CreateQuery() As String
        Try
            Dim dang_xuat As String = "DANG_XUAT_VIET"
            Dim tungay As String = datFromDate.Text
            Dim denngay As String = datToDate.DateTime.Date.AddDays(1)
            Dim _from As Date = Convert.ToDateTime(tungay)
            Dim _to As Date = Convert.ToDateTime(denngay)

            Dim sql As String = "SELECT   PX.MS_DH_XUAT_PT,ISNULL(PBT.MS_PHIEU_BAO_TRI, '') AS MS_PHIEU_BAO_TRI,  PX.SO_PHIEU_XN, PX.GIO,PX.MS_KHO,PX.MS_DANG_XUAT, " + dang_xuat + ", PX.NGUOI_NHAN, PX.NGAY_CHUNG_TU, PX.SO_CHUNG_TU,  PX.GHI_CHU,PX.LOCK, PX.STT, PX.THU_KHO, PX.MS_BP_CHIU_PHI,  PX.NGUOI_LAP, PX.CAN_CU, PX.THU_KHO_KY, PX.MS_KHO_DEN,PX.MS_VI_TRI_DEN, PX.MS_LY_DO_XUAT_KT, PX.MS_KH_NHAN,
KHCN.TEN_NGUOI_NHAP,DANG_XUAT_VIET AS DANG_XUAT, PX.NGAY AS NGAY_XUAT, LY_DO_XUAT ,PBT.TEN_TINH_TRANG, ISNULL(PBT.MS_MAY, '') AS PBT_MS_MAY, PBT.TEN_MAY 
"
            Dim from As String = " FROM IC_DON_HANG_XUAT PX INNER JOIN DANG_XUAT DX ON DX.MS_DANG_XUAT = PX.MS_DANG_XUAT LEFT JOIN KHACH_HANG_CONG_NHAN_XUAT KHCN ON PX.MS_DANG_XUAT = KHCN.MS_DANG_XUAT AND " &
                                     " PX.NGUOI_NHAN = KHCN.NGUOI_NHAP INNER JOIN NHOM_KHO ON PX.MS_KHO = NHOM_KHO.MS_KHO INNER JOIN USERS ON NHOM_KHO.GROUP_ID = USERS.GROUP_ID " &
                                     " LEFT JOIN (SELECT DISTINCT T1.MS_PHIEU_BAO_TRI, T2.TEN_TINH_TRANG, T1.MS_MAY, T3.TEN_MAY " &
                                     " FROM dbo.PHIEU_BAO_TRI AS T1 INNER JOIN  dbo.TINH_TRANG_PBT AS T2 ON T1.TINH_TRANG_PBT = T2.STT INNER JOIN  dbo.MAY AS T3 ON T1.MS_MAY = T3.MS_MAY) AS PBT " &
                                     " ON PX.MS_PHIEU_BAO_TRI = PBT.MS_PHIEU_BAO_TRI " &
                                     " WHERE USERS.USERNAME='" & Commons.Modules.UserName & "' "
            from = from + " AND PX.NGAY >= '" & _from.Month & "/" & _from.Day & "/" & _from.Year & "' AND PX.NGAY<'" & _to.Month & "/" & _to.Day & "/" & _to.Year & "'"
            If chkIsLock.Checked = True Then
                from = from + " AND  PX.LOCK = 1"
            Else
                from = from + " AND  PX.LOCK = 0"
            End If
            Dim condition = ""
            If Me.lokWareHouse.EditValue IsNot Nothing Then
                If Me.lokWareHouse.EditValue <> -1 Then
                    condition += " AND PX.MS_KHO=" + Me.lokWareHouse.EditValue.ToString
                End If
            End If
            sql = sql + from + condition + " ORDER BY PX.NGAY desc, PX.MS_DH_XUAT_PT DESC"
            Return sql
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Sub Load_Danh_Sach_PX(ByVal strQuery As String, ByVal msxuat As String)
        Me.Cursor = Cursors.WaitCursor
        Try
            Commons.Modules.SQLString = "0Load"
            Dim sTmp As String
            sTmp = txtMS_DH_XUAT.Text
            dtPhieuXuat = objDonHangXuatController.Load_Danh_Sach_DH_XUAT(strQuery)
            dtPhieuXuat.PrimaryKey = New DataColumn() {dtPhieuXuat.Columns("MS_DH_XUAT_PT")}
            If dtPhieuXuat.Rows.Count <= intRowCT Then
                intRowCT = dtPhieuXuat.Rows.Count - 1
            End If
            If grdDanhsachXuatkhoPT.DataSource Is Nothing Then
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDanhsachXuatkhoPT, grvDanhsachXuatkhoPT, dtPhieuXuat, False, True, False, False, True, Me.Name)
            Else
                grdDanhsachXuatkhoPT.DataSource = dtPhieuXuat
            End If

            If msxuat <> "-1" Then
                Try
                    Dim n As Integer = dtPhieuXuat.Rows.IndexOf(dtPhieuXuat.Rows.Find(msxuat))
                    grvDanhsachXuatkhoPT.FocusedRowHandle = grvDanhsachXuatkhoPT.GetRowHandle(n)
                Catch ex As Exception
                    'MessageBox.Show(ex.Message.ToString())
                End Try
            End If

            Commons.Modules.SQLString = ""
            If Me.grvDanhsachXuatkhoPT.Columns("SO_PHIEU_XN").Visible Then
                Me.grvDanhsachXuatkhoPT.Columns("SO_PHIEU_XN").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("TEN_MAY").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("NGAY_XUAT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_LY_DO_XUAT_KT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_KH_NHAN").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("DANG_XUAT_VIET").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("GIO").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_KHO").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_DANG_XUAT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("NGAY_CHUNG_TU").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("SO_CHUNG_TU").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("GHI_CHU").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("LOCK").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("STT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("LY_DO_XUAT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("THU_KHO").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_BP_CHIU_PHI").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("NGUOI_LAP").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("CAN_CU").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("THU_KHO_KY").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_KHO_DEN").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_VI_TRI_DEN").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("MS_LY_DO_XUAT_KT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("NGUOI_NHAN").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("SO_PHIEU_XN").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("DANG_XUAT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("NGAY_XUAT").Visible = False
                Me.grvDanhsachXuatkhoPT.Columns("TEN_TINH_TRANG").Width = 100
                Me.grvDanhsachXuatkhoPT.Columns("PBT_MS_MAY").Visible = False
            End If

            If Me.grvDanhsachXuatkhoPT.RowCount > 0 Then
                BtnIN.Enabled = True
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Then btnInDN.Enabled = True Else btnInDN.Enabled = False
                grdDanhsachXuatkhoPT.Focus()
                ShowPhieuXuat()
            Else
                btnLockPhieuXuat.Enabled = False
                btnSUA.Enabled = False
                btnXOA.Enabled = False
                BtnIN.Enabled = False
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = False Else btnInDN.Visible = False
                grdXuatkhoPTCT.DataSource = DBNull.Value
                grdSLtheoViTri.DataSource = DBNull.Value
                TextTrang()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Sub EnableControl(ByVal chon As Boolean)
        txtGHI_CHU.Properties.ReadOnly = Not chon
        dtpNGAY_CHUNG_TU.Enabled = chon
        txtNGAY_CHUNG_TU.Enabled = chon
        cboDANG_XUAT.Enabled = chon
        cboLDXKT.Enabled = chon
        txtSO_CHUNG_TU.Properties.ReadOnly = Not chon
        txtSO_PHIEU_XUAT.Properties.ReadOnly = Not chon

        cboNguoiNhan.Enabled = chon
        cboPhieuBaoTri.Enabled = chon
        NONNbtnTimPBT.Enabled = chon
        NONNbtnTimMay.Enabled = chon

        txtGIO_NHAP.Enabled = False
        dtpNGAY_NHAP.Enabled = False
        txtLydoxuat.Enabled = chon
        cbxCostCenter.Enabled = chon
        grvXuatkhoPTCT.OptionsBehavior.Editable = chon
        grvXuatkhoPTCT.Columns("GHI_CHU").OptionsColumn.ReadOnly = Not chon

        If cboDANG_XUAT.SelectedValue = 9 Then
            grvXuatkhoPTCT.Columns("CHI_PHI").OptionsColumn.ReadOnly = Not chon
        End If
        grvXuatkhoPTCT.Columns("TG_PB").OptionsColumn.ReadOnly = Not chon
        txtCCu.Enabled = chon
        txtTKho.Enabled = chon
        txtNLap.Enabled = chon
        cboKHO.Enabled = chon
        cboMay.Enabled = chon
        cboKHO_CHINH.Enabled = chon
        cboDVNhan.Enabled = chon
    End Sub
    Sub ShowPhieuXuat()
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Try
            If Me.grvDanhsachXuatkhoPT.RowCount > 0 Then
                If intRowCT < 0 Or grvDanhsachXuatkhoPT.RowCount = 1 Then intRowCT = 0
                Dim MS_DH_XUAT_PT As String = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_DH_XUAT_PT")
                Me.txtMS_DH_XUAT.Text = MS_DH_XUAT_PT
                Me.txtSO_PHIEU_XUAT.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("SO_PHIEU_XN")
                Dim time As String = ""
                Dim gio As DateTime
                Try
                    gio = Convert.ToDateTime(grvDanhsachXuatkhoPT.GetFocusedRowCellValue("GIO"))
                    If gio.Hour < 10 Then
                        time += "0" + gio.Hour.ToString + ":" '
                    Else
                        time += gio.Hour.ToString + ":"
                    End If
                    If gio.Minute < 10 Then
                        time += "0" + gio.Minute.ToString
                    Else
                        time += gio.Minute.ToString
                    End If
                    Me.txtGIO_NHAP.Text = time
                Catch ex As Exception
                    Me.txtGIO_NHAP.Text = " : "
                End Try
                Me.txtGIO_NHAP.Enabled = False
                Me.dtpNGAY_NHAP.Value = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("NGAY_XUAT") ' objDHX.NGAY
                Me.dtpNGAY_NHAP.Enabled = False
                txtNGAY_CHUNG_TU.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("NGAY_CHUNG_TU") ' objDHX.NGAY_CHUNG_TU
                Me.txtSO_CHUNG_TU.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("SO_CHUNG_TU") ' objDHX.SO_CHUNG_TU
                Me.txtNLap.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("NGUOI_LAP") ' objDHX.NGUOI_LAP
                Me.txtCCu.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("CAN_CU") ' objDHX.CAN_CU
                Me.txtTKho.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("THU_KHO_KY") 'objDHX.THU_KHO_KY
                Me.cboKHO.SelectedValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_KHO") ' objDHX.MS_KHO
                Me.cboKHO.Enabled = False
                Try
                    If grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_LY_DO_XUAT_KT") Is Nothing Or
                        grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_LY_DO_XUAT_KT") = "" Then
                        Me.cboLDXKT.SelectedIndex = -1
                    Else
                        Me.cboLDXKT.SelectedValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_LY_DO_XUAT_KT") ' objDHX.MS_LY_DO_XUAT_KT
                    End If
                    Me.cboLDXKT.Enabled = False
                Catch ex As Exception
                End Try
                Try
                    If grvDanhsachXuatkhoPT.GetFocusedRowCellValue("PBT_MS_MAY") Is Nothing Or
                        grvDanhsachXuatkhoPT.GetFocusedRowCellValue("PBT_MS_MAY") = "" Then
                        Me.cboMay.SelectedIndex = -1
                    Else
                        Me.cboMay.SelectedValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("PBT_MS_MAY") ' objDHX.MS_MAY
                    End If
                    Me.cboMay.Enabled = False
                Catch ex As Exception
                End Try
                Try
                    cboKHO_CHINH.SetValue(grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_VI_TRI_DEN").ToString())
                    Me.cboKHO_CHINH.Enabled = False
                Catch ex As Exception
                    cboKHO_CHINH.SelectedIndex = 0
                End Try

                Try
                    Me.cboDVNhan.EditValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_KH_NHAN") 'objDHX.MS_KH_NHAN
                    Me.cboDVNhan.Enabled = False

                Catch ex As Exception

                End Try
                Me.cboDANG_XUAT.SelectedValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_DANG_XUAT")

                Try
                    cboNguoiNhan.EditValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("NGUOI_NHAN").ToString()
                Catch ex As Exception
                End Try
                Try
                    If (grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI")() <> "") Then
                        cboMay.SelectedValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("PBT_MS_MAY")
                    End If
                Catch ex As Exception

                End Try


                Try
                    Me.cboPhieuBaoTri.SelectedValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI")
                Catch ex As Exception
                End Try
                Me.chkLOCK.Checked = Convert.ToBoolean(grvDanhsachXuatkhoPT.GetFocusedRowCellValue("LOCK"))
                Me.txtLydoxuat.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("LY_DO_XUAT")


                Try
                    Me.cbxCostCenter.SelectedValue = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_BP_CHIU_PHI") ' objDHX.MS_BP_CHIU_PHI
                Catch ex As Exception
                End Try

                If Me.chkLOCK.Checked Then
                    btnLockPhieuXuat.Enabled = False
                    btnSUA.Enabled = False
                    btnXOA.Enabled = False
                Else
                    btnLockPhieuXuat.Enabled = True
                    btnSUA.Enabled = True
                    btnXOA.Enabled = True
                End If
                Me.txtGHI_CHU.Text = grvDanhsachXuatkhoPT.GetFocusedRowCellValue("GHI_CHU") ' objDHX.GHI_CHU

                LoadVTPT()

                MS_PT = ""
                If chkLOCK.Checked = False Then
                    Me.btnLockPhieuXuat.Enabled = True And actionButton
                    Me.BtnTHEM.Enabled = True And actionButton
                    Me.btnSUA.Enabled = True And actionButton
                    Me.btnXOA.Enabled = True And actionButton
                Else
                    Me.btnLockPhieuXuat.Enabled = False
                    Me.btnSUA.Enabled = False
                    Me.btnXOA.Enabled = False
                End If
                BtnIN.Enabled = True
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = True Else btnInDN.Visible = False
                If chkLOCK.Checked = True And cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10 Then
                    btnXOA.Enabled = True
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, ToString())
        End Try

        Try
            If grvXuatkhoPTCT.RowCount = 0 Or grdXuatkhoPTCT.DataSource Is Nothing Then
                grvDanhsachXuatkhoPT_FocusedRowChanged(Nothing, Nothing)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            If grvSLtheoViTri.RowCount = 0 Or grdSLtheoViTri.DataSource Is Nothing Then
                grvXuatkhoPTCT_FocusedRowChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LoadVTPT()
        Me.lstDHXVT.Clear()
        Me.grdXuatkhoPTCT.DataSource = Nothing
        lstCTVTPT.Clear()
        grdSLtheoViTri.DataSource = Nothing

        Dim MS_DH_XUAT_PT As String = Me.grvDanhsachXuatkhoPT.GetFocusedRowCellValue("MS_DH_XUAT_PT")
        lstDHXVT = Me.objDonHangXuatController.Load_Don_Hang_Xuat_Vat_Tu(MS_DH_XUAT_PT)
        Me.grdXuatkhoPTCT.DataSource = lstDHXVT ' SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "QL_LOAD_LIST_DH_XUAT_VAT_TU", MS_DH_XUAT_PT).Tables(0)



        If cboDANG_XUAT.SelectedValue = 9 Then
            grvXuatkhoPTCT.Columns("CHI_PHI").Visible = True
        Else
            grvXuatkhoPTCT.Columns("CHI_PHI").Visible = False
        End If



        If Me.grvXuatkhoPTCT.RowCount > 0 Then
            intRowPT = 0
            LoadViTriXuat()
        Else
            Me.grdSLtheoViTri.DataSource = System.DBNull.Value
        End If
        MS_PT = ""

        Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvXuatkhoPTCT, Me.Name)


    End Sub

    Sub Load_Nguoi_Nhap()
        Try
            Dim lstNOINHAN As List(Of NOINHAN_Info) = New List(Of NOINHAN_Info)
            Dim dangNhap As String = Me.cboDANG_XUAT.SelectedValue.ToString
            Dim dtTmp As DataTable = New DataTable()

            Select Case dangNhap
                Case "1", "4" To "6", "8" To "9"
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LIST_CONG_NHAN", If(btnGHI.Visible = True, 5, -1)))
                    Exit Select
                Case "2"
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LIST_KHACH_HANG", If(btnGHI.Visible = True, 5, -1)))
                    Exit Select
                Case "3"
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LIST_KHACH_HANG", If(btnGHI.Visible = True, 5, -1)))
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LIST_CONG_NHAN", If(btnGHI.Visible = True, 5, -1)))
                    Exit Select
                Case Else
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LIST_CONG_NHAN", If(btnGHI.Visible = True, 5, -1)))
                    Exit Select
            End Select
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiNhan, dtTmp, "MA", "TEN", "")
        Catch ex As Exception

        End Try
    End Sub

    Sub LoadDonViNhan()
        Try
            Dim dtTmp = New DataTable
            'dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers"))
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_NGUOI_NHAP_KHO"))
            dtTmp.DefaultView.RowFilter = "VTRO = 4 "
            dtTmp = dtTmp.DefaultView.ToTable
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDVNhan, dtTmp, "MS_NGUOI_NHAP", "TEN_NGUOI_NHAP", "")

            'Me.cboDVNhan.DataSource = dtTmp
            'Me.cboDVNhan.ValueMember = "MS_NGUOI_NHAP"
            'Me.cboDVNhan.DisplayMember = "TEN_NGUOI_NHAP"
        Catch ex As Exception

        End Try
    End Sub

    Function Load_List(ByVal storeName As String) As List(Of NOINHAN_Info)
        Dim lstData As List(Of NOINHAN_Info)
        If btnGHI.Visible Then
            lstData = QLBusinessDataController.FillCollection(Of NOINHAN_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, storeName, 5))
        Else
            lstData = QLBusinessDataController.FillCollection(Of NOINHAN_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, storeName, -1))
        End If
        Return lstData
    End Function


    Sub SetVisibleButton(ByVal Flag As Boolean)
        Me.BtnTHEM.Visible = Flag And actionButton
        Me.btnSUA.Visible = Flag And actionButton
        Me.btnXOA.Visible = Flag And actionButton
        Me.BtnIN.Visible = Flag And actionButton

        If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then
            btnInDN.Visible = Flag And Not chkIsLock.Checked
        Else
            btnInDN.Visible = False
        End If
        Me.btnChon_Vat_Tu.Enabled = Not Flag And actionButton
        Me.btnTHOAT_CT.Visible = Flag
        Me.btnChon_Vat_Tu.Visible = Not Flag
        Me.btnLockPhieuXuat.Visible = Flag
        btnGHI.Visible = Not Flag
        btnKHONG_GHI.Visible = Not Flag
        Panel1.Visible = False
        'grdXuatkhoPTCT.Enabled = Flag
        txtFilter.Visible = Flag
        '     btnTimCX.Visible = Flag
        Check_User_Form()
    End Sub

    Function ValidatedForm() As Boolean
        Dim Flag As Boolean = True
        If Me.txtMS_DH_XUAT.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_XUAT_NOT_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMS_DH_XUAT.Focus()
            Return False
        End If

        If txtGIO_NHAP.Text = "  :" Then
            ' Giờ nhập không được rỗng ! Vui lòng nhập giờ nhập vào !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_NHAP_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGIO_NHAP.SelectAll()
            Return False
        ElseIf Not IsDate(Me.txtGIO_NHAP.Text) Then
            ' Giờ nhập không hợp lệ ! Giờ phải có kiểu HH:MM (00:00 -> 23:59) !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_NHAP_KHONG_HOP_LE", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGIO_NHAP.SelectAll()
            Return False
        End If

        If Not IsDate(dtpNGAY_NHAP.Text) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayNhapKhongDung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpNGAY_NHAP.Focus()
            Return False
        End If

        If Convert.ToDateTime(dtpNGAY_NHAP.Text) > Commons.Modules.ObjSystems.GetNgayHeThong().Date Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayNhapLonHonHienTai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpNGAY_NHAP.Focus()
            Return False
        End If

        If status Then
            Dim dt As New DataTable
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_CHECK_MS_DH_XUAT_PT_EXISTS", txtMS_DH_XUAT.Text))
            If dt.Rows.Count > 0 Then
                If (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgMsDHXTrungBanCoMuonTaoPhieuMoi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then Return False
                Dim cpSCT As Boolean = False
                If txtMS_DH_XUAT.Text = txtSO_PHIEU_XUAT.Text Then cpSCT = True
#Region "tao phieu xuat moi"
                TaoPX()
#End Region
                If cpSCT Then txtSO_PHIEU_XUAT.Text = txtMS_DH_XUAT.Text
            End If
        End If

        If Me.txtSO_PHIEU_XUAT.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_PHIEU_XUAT_NOT_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtSO_PHIEU_XUAT.Focus()
            Return False
        Else
            If status Then
                If Me.objDonHangXuatController.CHECK_SO_PHIEU_XUAT_EXISTS(Me.txtSO_PHIEU_XUAT.Text, Me.txtMS_DH_XUAT.Text, status) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgboxMsPhieuXuatTonTaiMuonTaoMaoi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSO_PHIEU_XUAT.Focus()
                    Return False
                End If
            End If
            If Me.objDonHangXuatController.CHECK_SO_PHIEU_XUAT_EXISTS(Me.txtSO_PHIEU_XUAT.Text, Me.txtMS_DH_XUAT.Text, status) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_PHIEU_XUAT_EXISTS", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSO_PHIEU_XUAT.Focus()
                Return False
            End If
        End If
        If Me.txtSO_CHUNG_TU.Text <> "" Then
            If Me.objDonHangXuatController.CHECK_SO_CHUNG_TU_EXISTS(Me.txtSO_CHUNG_TU.Text, Me.txtMS_DH_XUAT.Text, status) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_CHUNG_TU_EXISTS", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSO_CHUNG_TU.Focus()
                Return False
            End If
        End If
        If cboDANG_XUAT.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DANG_XUAT_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboDANG_XUAT.Focus()
            Return False
        End If
        If Me.cboNguoiNhan.EditValue Is Nothing Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaNhapNoiNhan", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboNguoiNhan.Focus()
            Return False
        End If
        If Me.cboDVNhan.Text = "" And (cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaNhapDonViNhan", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboDVNhan.Focus()
            Return False
        End If
        If Me.grvXuatkhoPTCT.RowCount < 1 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_XUAT_CHUA_NHAP_CHI_TIET", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If NgayMaxKK(cboKHO.SelectedValue, dtpNGAY_NHAP.Text, txtGIO_NHAP.Text) = False Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NgayKiemKeLonHonNgayXuat", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If NgayMaxKho(cboKHO.SelectedValue, dtpNGAY_NHAP.Text, txtGIO_NHAP.Text) = False Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NgayKhoLonHonNgayXuat", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Try

            For j As Integer = 0 To Me.lstDHXVT.Count - 1
                Dim sTmp As String
                Dim sChiPhi As String
                sTmp = lstDHXVT.Item(j).TG_PB
                sChiPhi = lstDHXVT.Item(j).CHI_PHI

                If sTmp = "" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTGPBPhaiLonHon0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'grdXuatkhoPTCT.Rows(j).Cells("TG_PB").Selected = True
                    Return False
                Else
                    If Not IsNumeric(sTmp) Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'grdXuatkhoPTCT.Rows(j).Cells("TG_PB").Selected = True
                        Return False
                    Else
                        If sTmp = "0-" Or sTmp = "-0" Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'grdXuatkhoPTCT.Rows(j).Cells("TG_PB").Selected = True
                            Return False
                        End If

                        If sTmp <= 0 And Commons.Modules.sPrivate = "GREENFEED" Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTGPBPhaiLonHon0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                    End If
                End If
                If sChiPhi = "" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCHI_PHIPhaiLonHon0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                Else
                    If Not IsNumeric(sChiPhi) Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    Else
                        If sChiPhi = "0-" Or sChiPhi = "-0" Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongPhaiSo", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                    End If
                End If

                If Integer.Parse(sTmp) < 0 Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTGPBPhaiLonHon0", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Next
        Catch ex As Exception
            Return False
        End Try


        Return Flag
    End Function

    Private Sub TextTrang()
        Dim NgayHT As Date = Commons.Modules.ObjSystems.GetNgayHeThong()
        Me.txtMS_DH_XUAT.Text = ""
        Dim time As String = ""
        If NgayHT.Hour < 10 Then
            time += "0" + NgayHT.Hour.ToString + ":"
        Else
            time += NgayHT.Hour.ToString + ":"
        End If
        If NgayHT.Minute < 10 Then
            time += "0" + NgayHT.Minute.ToString
        Else
            time += NgayHT.Minute.ToString
        End If

        Me.txtGIO_NHAP.Text = time
        Me.dtpNGAY_NHAP.Value = NgayHT
        txtNGAY_CHUNG_TU.Text = NgayHT
        cboMay.SelectedIndex = -1
        Me.txtSO_CHUNG_TU.Text = ""
        Me.txtCCu.Text = ""
        Me.txtTKho.Text = ""
        Me.txtNLap.Text = ""
        Me.txtSO_PHIEU_XUAT.Text = ""
        Me.txtGHI_CHU.Text = ""
        cboKHO.SelectedValue = -1
        cboKHO_CHINH.SelectedIndex = 0
        txtLydoxuat.Text = ""
        cboDANG_XUAT.SelectedValue = -1
        Me.lstDHXVT.Clear()
        Me.grdXuatkhoPTCT.DataSource = Nothing
        Me.grdSLtheoViTri.DataSource = Nothing
        cboPhieuBaoTri.SelectedValue = -1
        cboMay.SelectedIndex = -1
        txtSO_PHIEU_XUAT.Text = ""
        txtNLap.Text = ""
        cboNguoiNhan.EditValue = -1
        cboNguoiNhan.Text = ""
        cboDVNhan.EditValue = -1
        cboDVNhan.Text = ""
    End Sub
    Private Sub TaoPX()
        If Not status Then Exit Sub
        If Not btnGHI.Visible Then Exit Sub

        Me.txtMS_DH_XUAT.Text = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_get_id", "PX", dtpNGAY_NHAP.Value))
    End Sub


    Private Sub BtnTHEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTHEM.Click
        Try
            Dim NgayHT As Date = Commons.Modules.ObjSystems.GetNgayHeThong()
            SetVisibleButton(False)
#Region "tao phieu xuat moi"
            TaoPX()
#End Region

            Dim time As String = ""
            If NgayHT.Hour < 10 Then
                time += "0" + NgayHT.Hour.ToString + ":"
            Else
                time += NgayHT.Hour.ToString + ":"
            End If
            If NgayHT.Minute < 10 Then
                time += "0" + NgayHT.Minute.ToString
            Else
                time += NgayHT.Minute.ToString
            End If
            Load_Nguoi_Nhap()
            Me.txtGIO_NHAP.Text = time
            Me.txtGIO_NHAP.Enabled = True
            Me.dtpNGAY_NHAP.Value = NgayHT
            Me.dtpNGAY_NHAP.Enabled = True
            txtNGAY_CHUNG_TU.Text = NgayHT
            Me.cboKHO.Enabled = True
            Me.cboMay.Enabled = True
            cboMay.SelectedIndex = -1
            Me.txtSO_CHUNG_TU.Text = ""
            Me.txtCCu.Text = ""
            Me.txtTKho.Text = ""
            Me.txtNLap.Text = ""
            Me.txtSO_PHIEU_XUAT.Text = ""
            Me.txtGHI_CHU.Text = ""
            cboKHO.SelectedValue = -1
            cboKHO_CHINH.SelectedIndex = 0
            txtLydoxuat.Text = ""
            Me.chkLOCK.Checked = False
            Me.btnLockPhieuXuat.Enabled = False
            btnGHI.Visible = False
            'tabXuatkhoPT.SelectedTab = tabChiTietPT
            btnGHI.Visible = True
            status = True
            cboDANG_XUAT.SelectedValue = -1
            Me.lstDHXVT.Clear()
            Me.grdXuatkhoPTCT.DataSource = Nothing 'Me.lstDHXVT
            Me.grdSLtheoViTri.DataSource = Nothing
            'Me.hasDataCTXuatVT.Clear()
            MS_PT = ""
            EnableControl(True)
            txtSO_PHIEU_XUAT.Focus()
            txtGIO_NHAP.Enabled = True
            dtpNGAY_NHAP.Enabled = True
            tblCondition.Enabled = False
            AddHandler txtSO_PHIEU_XUAT.Validating, AddressOf Me.txtSO_PHIEU_XUAT_Validating
            If Not BtnTHEM.Visible Then
                If cboDANG_XUAT.SelectedValue = 1 Then
                    cboPhieuBaoTri.Enabled = True
                    NONNbtnTimPBT.Enabled = True
                    If cboPhieuBaoTri.Items.Count > 0 Then cboPhieuBaoTri.SelectedIndex = 0 Else cboPhieuBaoTri.SelectedIndex = -1
                Else
                    cboPhieuBaoTri.Enabled = False
                    NONNbtnTimPBT.Enabled = False
                    cboPhieuBaoTri.SelectedValue = -1
                End If
                If cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10 Then
                    cboKHO_CHINH.Enabled = True
                    cboDVNhan.Enabled = True
                Else
                    cboKHO_CHINH.Enabled = False
                    cboDVNhan.Enabled = False
                End If
                If cboDANG_XUAT.SelectedValue = 8 Then
                    cboMay.Enabled = True
                    NONNbtnTimMay.Enabled = True
                    cbxCostCenter.Enabled = False
                    If cboMay.Items.Count > 0 Then cboMay.SelectedIndex = 0 Else cboMay.SelectedIndex = -1
                Else
                    cboMay.Enabled = False
                    NONNbtnTimMay.Enabled = False
                    cboMay.SelectedIndex = -1
                End If
            Else
                cboPhieuBaoTri.Enabled = False
                NONNbtnTimPBT.Enabled = False
                cboMay.Enabled = False
                NONNbtnTimMay.Enabled = False

            End If
            If Commons.Modules.iDefault = 1 Then txtSO_PHIEU_XUAT.Text = txtMS_DH_XUAT.Text
            If Commons.Modules.iDefault = 2 Then
                txtSO_PHIEU_XUAT.Text = txtMS_DH_XUAT.Text
                txtSO_PHIEU_XUAT.Properties.ReadOnly = True
            End If

            If Commons.Modules.sTenNhanVienMD <> "" Then txtNLap.Text = Commons.Modules.sTenNhanVienMD
            'grdXuatkhoPTCT.Enabled = False
            LoadXuatKTDefault()
            LoadPBT()
            'cboNOI_NHAN.SelectedValue = -1
            'cboNOI_NHAN.Text = ""
            cboNguoiNhan.EditValue = Nothing
            cboNguoiNhan.Text = ""
            cboDVNhan.EditValue = -1
            cboDVNhan.Text = ""

            If Commons.Modules.iMaKhoMD <> -1 Then cboKHO.SelectedValue = Commons.Modules.iMaKhoMD
        Catch ex As Exception
        End Try
        grdDanhsachXuatkhoPT.Enabled = False
    End Sub
    Private Sub btnLockPhieuXuat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockPhieuXuat.Click
        If Not Commons.Modules.ObjSystems.MGetQuyenChucNang(Modules.UserName, 64) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoQuyenLockPX", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DO_YOU_WANT_TO_LOCK_THIS_PX", Commons.Modules.TypeLanguage), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        ' kiểu tra nếu là trung nguyên thì tự động tạo thêm phiếu hập
        If Commons.Modules.sPrivate = "TRUNGNGUYEN" And txtGHI_CHU.Text.Trim() <> "Xuất INT" Then
            Try
                Dim mspn As String = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_get_id", "PN", DateTime.Now))
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spUpdateAutoNhap", txtMS_DH_XUAT.Text.Trim(), mspn)
            Catch ex As Exception
            End Try
        End If
        If Me.objDonHangXuatController.LOCK_DON_HANG_XUAT(Me.txtMS_DH_XUAT.Text) Then
            Try
                If Commons.Modules.sPrivate.ToUpper = "SHISEIDO" Then
                    If cbxCostCenter.Text <> "" Then InSHISEIDO(1)
                End If
            Catch ex As Exception
            End Try

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOCK_PHIEU_XUAT_SUCCESS", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
            EnableControl(False)
            SetVisibleButton(True)
            If chkIsLock.Checked = True Then
                BtnTHEM.Enabled = False
            End If

        End If

    End Sub

    Private Sub btnChon_Vat_Tu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChon_Vat_Tu.Click
        If cboDANG_XUAT.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DANG_XUAT_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If txtSO_PHIEU_XUAT.Text = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_PHIEU_XUAT_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSO_PHIEU_XUAT.Focus()
            Return
        End If

        If Not IsDate(dtpNGAY_NHAP.Text) Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayNhapKhongDung", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpNGAY_NHAP.Focus()
            Return
        End If

        If Convert.ToDateTime(dtpNGAY_NHAP.Text) > Commons.Modules.ObjSystems.GetNgayHeThong().Date Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayNhapLonHonHienTai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpNGAY_NHAP.Focus()
            Return
        End If

        If txtGIO_NHAP.Text = "  :" Then
            ' Giờ nhập không được rỗng ! Vui lòng nhập giờ nhập vào !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_NHAP_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGIO_NHAP.SelectAll()
            Return
        ElseIf Not IsDate(Me.txtGIO_NHAP.Text) Then
            ' Giờ nhập không hợp lệ ! Giờ phải có kiểu HH:MM (00:00 -> 23:59) !
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_NHAP_KHONG_HOP_LE", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtGIO_NHAP.SelectAll()
            Return
        End If

        If cboKHO.SelectedValue = -1 Or cboKHO.SelectedValue Is Nothing Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHO_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboKHO.Focus()
            Return
        End If

        Try
            If cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10 Then
                Dim sSql As String
                Dim TNgay As Date
                TNgay = DateSerial(Year(dtpNGAY_NHAP.Value), Month(dtpNGAY_NHAP.Value), 1)
                Dim DNgay As Date
                DNgay = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, TNgay))
                If Commons.Modules.sPrivate = "ACECOOK" Then
                    sSql = " SELECT * FROM ( SELECT T1.*, ISNULL(TI_GIA,-1) AS TGIA FROM NGOAI_TE T1 LEFT JOIN " &
                                        " (SELECT A.* FROM TI_GIA_NT A INNER JOIN (SELECT NGOAI_TE, MAX(NGAY) AS NMAX FROM TI_GIA_NT  " &
                                        " WHERE NGAY_NHAP BETWEEN '" & TNgay.ToString("MM/dd/yyyy") & "' AND '" & DNgay.ToString("MM/dd/yyyy") & "' GROUP BY NGOAI_TE)B ON A.NGOAI_TE = B.NGOAI_TE AND A.NGAY = B.NMAX " &
                                        " )T2 ON T1.NGOAI_TE = T2.NGOAI_TE " &
                                        " ) A WHERE TGIA = -1"
                    Try

                        Dim dtTG As New DataTable
                        dtTG.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                        If dtTG.Rows.Count > 0 Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaNhapTiGia", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Catch ex As Exception
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgChuaNhapTiGiaHoacThoiGianXuatLapSai", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End Try
                End If

                If cboKHO_CHINH.treeList.FocusedNode("STT") Is Nothing Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ChuaChonKhoDD", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboKHO_CHINH.Focus()
                    Return
                End If
                '''''''''''''nếu mà mscha bằng null thì bắc chọn vị trí
                ''''''''''''''kiểm tra nếu chưa cọn vị trí thì báo lên
                'nếu dạng xuất khác 9 thì return
                'chỉ được chọn thèn con cuối cùng
                If cboKHO_CHINH.treeList.FocusedNode("MS_CHA").ToString() = "" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgBanConChonViTriTruocKhiChuyenKho", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                If cboKHO_CHINH.treeList.FocusedNode("STT") = cboKHO.SelectedValue Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhoXuatGiongKhoDD", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboKHO.Focus()
                    Exit Sub
                End If
                sSql = "SELECT MS_KHO, ISNULL(MS_KHO_CHINH ,0) AS  MS_KHO_CHINH FROM IC_KHO A  WHERE A.MS_KHO_CHINH = " & cboKHO.SelectedValue.ToString
                Dim dtTmp = New DataTable
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                If dtTmp.Rows.Count > 0 Then
                    For Each dr As DataRow In dtTmp.Rows
                        If cboKHO_CHINH.treeList.FocusedNode("STT") = dr("MS_KHO") Then
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhoXuatKhoDD", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cboKHO_CHINH.Focus()
                            Exit Sub
                        End If
                    Next
                End If

            End If
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KhoXuatKhoDD", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboKHO_CHINH.Focus()
            Exit Sub
        End Try

        Try
            If cboDANG_XUAT.SelectedValue = 1 And (cboPhieuBaoTri.SelectedValue.Equals(Nothing) Or cboPhieuBaoTri.SelectedValue.ToString.Equals("-1") Or cboPhieuBaoTri.SelectedValue.ToString.Equals(System.DBNull.Value)) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_BAO_TRI_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboPhieuBaoTri.Focus()
                Return
            End If

        Catch ex As Exception
        End Try
        'If cboKHO_CHINH.TextValue.ToString() <> "" Then
        '    If cboKHO.SelectedValue = cboKHO_CHINH.EditValue And (cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10) Then
        '        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TrungKhoDenDiDuong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        cboKHO_CHINH.Focus()
        '        Return
        '    End If
        'End If

        If Me.cboKHO.SelectedValue IsNot Nothing Then
            If Me.objDonHangXuatController.CHECK_PHIEU_KIEM_KE_UNLOCK_EXISTS(Integer.Parse(Me.cboKHO.SelectedValue.ToString)) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_KIEM_KE_CUA_KHO_CON_UNLOCK", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If NgayMaxKK(cboKHO.SelectedValue, dtpNGAY_NHAP.Text, txtGIO_NHAP.Text) = False Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NgayKiemKeLonHonNgayXuat", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If NgayMaxKho(cboKHO.SelectedValue, dtpNGAY_NHAP.Text, txtGIO_NHAP.Text) = False Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NgayKhoLonHonNgayXuat", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If


            Dim lstVITRI_KHO_VATTU_Filter As New List(Of VI_TRI_KHO_VAT_TU_Info)
            Dim pbtri As String = ""
            If cboPhieuBaoTri.Text.ToString.Equals("") Then
                pbtri = ""
            Else
                pbtri = cboPhieuBaoTri.SelectedValue.ToString
            End If
            'If status = False Then
            ''TRUONG HOP CAP NHAT DON HANG XUAT
            ''LOAD DACH SACH VAT TU TRONG DON HANG XUAT VAT TU
            Dim lstVTXuat As List(Of IC_DON_HANG_XUAT_VAT_TU_Info) = Me.objDonHangXuatController.Load_Don_Hang_Xuat_Vat_Tu(Me.txtMS_DH_XUAT.Text)
            'LOAD DANH SACH VAT TU TRONG DON HANG NHAP UNLOCK
            Dim lstDHN_VATTU_UNLOCK As List(Of IC_DON_HANG_NHAP_VAT_TU_Info) = Me.objDonHangXuatController.LOAD_LIST_DON_HANG_NHAP_VAT_TU_UNLOCK()
            For i As Integer = 0 To lstDHN_VATTU_UNLOCK.Count - 1
                Dim objVTKho_VatTu As New VI_TRI_KHO_VAT_TU_Info
                objVTKho_VatTu.MS_PT = lstDHN_VATTU_UNLOCK.Item(i).MS_PT
                lstVITRI_KHO_VATTU_Filter.Add(objVTKho_VatTu)
                For j As Integer = 0 To lstVTXuat.Count - 1
                    If lstDHN_VATTU_UNLOCK.Item(i).MS_PT = lstVTXuat.Item(j).MS_PT Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_NHAP_", Commons.Modules.TypeLanguage) + lstDHN_VATTU_UNLOCK.Item(i).MS_DH_NHAP_PT + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "_CHUA_LOCK", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                Next
            Next
            'LOAD DANH SACH VAT TU TRONG DON HANG XUAT KHAC DON HANG XUAT DANG CHON
            Dim lstDHX_VATTU_UNLOCK As List(Of IC_DON_HANG_XUAT_VAT_TU_Info) =
                    Me.objDonHangXuatController.LOAD_LIST_DON_HANG_XUAT_TU_UNLOCK_KHAC_PHIEU_XUAT_CHON(Me.txtMS_DH_XUAT.Text, cboKHO.SelectedValue)
            For i As Integer = 0 To lstDHX_VATTU_UNLOCK.Count - 1
                Dim objVTKho_VatTu As New VI_TRI_KHO_VAT_TU_Info
                objVTKho_VatTu.MS_PT = lstDHX_VATTU_UNLOCK.Item(i).MS_PT
                lstVITRI_KHO_VATTU_Filter.Add(objVTKho_VatTu)
                For j As Integer = 0 To lstVTXuat.Count - 1
                    If lstDHX_VATTU_UNLOCK.Item(i).MS_PT = lstVTXuat.Item(j).MS_PT Then
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_XUAT_", Commons.Modules.TypeLanguage) + lstDHX_VATTU_UNLOCK.Item(i).MS_DH_XUAT_PT + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "_CHUA_LOCK", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                Next
            Next

            Dim FlagReport As Boolean = True
            If lstDHN_VATTU_UNLOCK.Count > 0 Then
                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_NHAP_CHUA_LOCK", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    FlagReport = False
                End If
            End If

            If lstDHX_VATTU_UNLOCK.Count > 0 Then
                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_XUAT_CHUA_LOCK", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    FlagReport = False
                End If
            End If
            If FlagReport = False Then
                'In Report
                XtraMessageBox.Show("In report DANH SACH PHIEU NHAP XUAT CHUA LOCK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim frmCVT As New FrmChonVatTuXuatKho()
            frmCVT.MS_DH_XUAT_PT = Me.txtMS_DH_XUAT.Text
            frmCVT.NGAY_XUA = dtpNGAY_NHAP.Value
            frmCVT.MS_KHO = Integer.Parse(Me.cboKHO.SelectedValue.ToString)
            frmCVT.MS_PBT = pbtri
            frmCVT.lstDonHangXuatVT = lstDHXVT
            If lstCTVTPT.Count = 0 Then
                'duyệt để lấy hết chi tiết vật tư
                For Each item As IC_DON_HANG_XUAT_VAT_TU_Info In lstDHXVT
                    Dim lst As List(Of CHI_TIET_VAT_TU_XUAT_Info) = Me.objDonHangXuatController.Load_Don_Hang_Xuat_Vat_Tu_Chi_Tiet(Integer.Parse(Me.cboKHO.SelectedValue.ToString), Me.txtMS_DH_XUAT.Text, item.MS_PT)
                    frmCVT.lstCTVTXuat.AddRange(lst)
                Next
            Else
                frmCVT.lstCTVTXuat = lstCTVTPT
            End If
            If frmCVT.ShowDialog() = DialogResult.OK Then
                'thực hiện
                lstDHXVT = frmCVT.lstDonHangXuatVT
                lstCTVTPT = frmCVT.lstCTVTXuat
                CallBackData(lstDHXVT)
            End If

        Else
        End If
        cboKHO.Enabled = IIf(grvXuatkhoPTCT.RowCount > 0, False, True)
        cboKHO_CHINH.Enabled = IIf(grvXuatkhoPTCT.RowCount > 0, False, True)
        txtGIO_NHAP.Enabled = cboKHO.Enabled
        dtpNGAY_NHAP.Enabled = cboKHO.Enabled
        cboDANG_XUAT.Enabled = cboKHO.Enabled
        cboLDXKT.Enabled = cboKHO.Enabled
        cboPhieuBaoTri.Enabled = cboKHO.Enabled
        NONNbtnTimPBT.Enabled = cboKHO.Enabled

        cboMay.Enabled = cboKHO.Enabled
        NONNbtnTimMay.Enabled = cboKHO.Enabled
    End Sub

    Private Sub btnSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSUA.Click
        Try

            If Not Commons.Modules.ObjSystems.MGetQuyenChucNang(Modules.UserName, 5) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenSua", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            status = False
            Me.btnLockPhieuXuat.Enabled = False
            SetVisibleButton(False)
            EnableControl(True)


            If cboDANG_XUAT.SelectedValue <> 1 Then
                cboPhieuBaoTri.Enabled = False
                NONNbtnTimPBT.Enabled = False
                cboMay.Enabled = False
                NONNbtnTimMay.Enabled = False
            End If
            Me.txtSO_PHIEU_XUAT.Focus()
            tblCondition.Enabled = False
            AddHandler txtSO_PHIEU_XUAT.Validating, AddressOf Me.txtSO_PHIEU_XUAT_Validating


            If grvXuatkhoPTCT.RowCount <= 0 Then
                cboDANG_XUAT.Enabled = True
                cboLDXKT.Enabled = True
            Else
                cboDANG_XUAT.Enabled = False
                cboLDXKT.Enabled = False
            End If
            If Not BtnTHEM.Visible Then
                cboPhieuBaoTri.Enabled = False
                NONNbtnTimPBT.Enabled = False
                cboMay.Enabled = False
                NONNbtnTimMay.Enabled = False
                If cboDANG_XUAT.SelectedValue = 1 Then
                    cbxCostCenter.Enabled = False
                End If

                If cboDANG_XUAT.SelectedValue = 8 Then If cboMay.Text <> "" Then cbxCostCenter.Enabled = False
            Else
                cboPhieuBaoTri.Enabled = False
                NONNbtnTimPBT.Enabled = False
                cboMay.Enabled = False
                NONNbtnTimMay.Enabled = False
            End If

            cboKHO.Enabled = False
            cboMay.Enabled = False
            cboKHO_CHINH.Enabled = False
            If Commons.Modules.iDefault = 2 Then txtSO_PHIEU_XUAT.Properties.ReadOnly = True
            Dim sNHap As String = cboNguoiNhan.EditValue
            cboNguoiNhan.EditValue = sNHap
            Commons.Modules.SQLString = "0LOADTAB"
            Commons.Modules.SQLString = ""
        Catch ex As Exception

        End Try
        grdDanhsachXuatkhoPT.Enabled = False
    End Sub

    Private Sub btnXOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXOA.Click
        If (chkIsLock.Checked = True) Then
            Dim _dtTmp As New DataTable
            _dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_DATA_CHECK_BEFORE_DELETE", Me.txtMS_DH_XUAT.Text))
            If _dtTmp.Rows.Count > 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHAP_TAO_TU_DONG_DA_SU_DUNG_KOXOA", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If Me.txtMS_DH_XUAT.Text <> "" Then
            Dim bQuyen As Boolean = False
            bQuyen = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 11)
            If bQuyen Then
                Dim sSql As String
                Dim _dtTmp As New DataTable
                sSql = " SELECT DISTINCT A.MS_PHIEU_BAO_TRI FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO A WHERE  A.MS_DH_XUAT_PT = N'" + txtMS_DH_XUAT.Text + "' " &
                                    " ORDER BY A.MS_PHIEU_BAO_TRI "
                _dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

                If _dtTmp.Rows.Count > 0 Then
                    sSql = ""
                    For Each dr As DataRow In _dtTmp.Rows
                        sSql = sSql + " - " + dr(0)
                    Next
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "msgCoPBTDaNhapSLTTNenKhongTheXoa", Commons.Modules.TypeLanguage) + vbCrLf + sSql.Substring(3, sSql.Length - 3))
                    Exit Sub
                End If

                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgXoaDHXuat", Commons.Modules.TypeLanguage) + " " + Me.txtMS_DH_XUAT.Text, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If Me.cboKHO.SelectedValue IsNot Nothing Then


                        Me.objDonHangXuatController.DELETE_DON_HANG_XUAT(Me.txtMS_DH_XUAT.Text, Integer.Parse(Me.cboKHO.SelectedValue.ToString))
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_HANG_XUAT_DA_DUOC_XOA", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If cboPhieuBaoTri.SelectedValue IsNot Nothing Then
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapPhieuXuatPBTChiTiet", cboPhieuBaoTri.SelectedValue)
                        End If
                        Me.txtMS_DH_XUAT.Text = ""
                        Me.txtGHI_CHU.Text = ""
                        Me.txtSO_CHUNG_TU.Text = ""
                        Me.txtCCu.Text = ""
                        Me.txtTKho.Text = ""
                        Me.txtNLap.Text = ""
                        Me.txtSO_PHIEU_XUAT.Text = ""
                        Me.txtGIO_NHAP.Text = ""

                        Me.btnLockPhieuXuat.Enabled = True
                        ' Me.tabXuatkhoPT.TabPages.Insert(0, Me.tabDanhSachPT)

                        Commons.Modules.SQLString = "0Load"
                        Me.Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
                        Commons.Modules.SQLString = ""
                        Me.SetVisibleButton(True)
                        RemoveHandler txtSO_PHIEU_XUAT.Validating, AddressOf Me.txtSO_PHIEU_XUAT_Validating
                        EnableControl(False)
                        If chkIsLock.Checked = True Then
                            BtnTHEM.Enabled = False
                        End If
                    End If
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub btnGHI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGHI.Click
        Try
            If cboDANG_XUAT.SelectedValue = 1 Then
                If (cboPhieuBaoTri.SelectedValue Is Nothing Or cboPhieuBaoTri.SelectedValue.ToString.Equals("-1")) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_BAO_TRI_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboPhieuBaoTri.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PHIEU_BAO_TRI_NULL", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboPhieuBaoTri.Focus()
            Exit Sub
        End Try

        If Me.ValidatedForm Then
            Dim sNgayThang As String = dtpNGAY_NHAP.Value.Month.ToString + "/" + dtpNGAY_NHAP.Value.Year.ToString
            Dim intMs_To As Integer = Me.cboKHO.SelectedValue
            Dim objDonHangXuat As New IC_DON_HANG_XUAT_Info
            Try
                objDonHangXuat.MS_DH_XUAT_PT = Me.txtMS_DH_XUAT.Text
                objDonHangXuat.SO_PHIEU_XN = Me.txtSO_PHIEU_XUAT.Text
                objDonHangXuat.GIO = Date.Parse(Me.txtGIO_NHAP.Text)
                objDonHangXuat.NGAY = Me.dtpNGAY_NHAP.Value
                objDonHangXuat.MS_KHO = Me.cboKHO.SelectedValue.ToString
                objDonHangXuat.MS_DANG_XUAT = Me.cboDANG_XUAT.SelectedValue.ToString
                objDonHangXuat.NGUOI_NHAN = cboNguoiNhan.EditValue 'IIf(cboNguoiNhan.EditValue, Nothing, Me.cboNOI_NHAN.SelectedValue.ToString)
                objDonHangXuat.NGAY_CHUNG_TU = IIf(txtNGAY_CHUNG_TU.Text = "  /  /", Nothing, txtNGAY_CHUNG_TU.Text)
                objDonHangXuat.SO_CHUNG_TU = Me.txtSO_CHUNG_TU.Text ' + " "

                If objDonHangXuat.MS_DANG_XUAT = 9 Or objDonHangXuat.MS_DANG_XUAT = 10 Then
                    objDonHangXuat.MS_KHO_DEN = Me.cboKHO_CHINH.treeList.FocusedNode("STT")
                    objDonHangXuat.MS_VT_DEN = Me.cboKHO_CHINH.treeList.FocusedNode("MS_VI_TRI")
                    objDonHangXuat.MS_KH_NHAN = IIf(cboDVNhan.Text = "", Nothing, Me.cboDVNhan.EditValue.ToString)
                    cboKHO_CHINH.SelectedIndex = 0
                Else
                    objDonHangXuat.MS_KHO_DEN = -1
                    objDonHangXuat.MS_KH_NHAN = Nothing
                    cboDVNhan.EditValue = -1
                End If
                If objDonHangXuat.MS_DANG_XUAT = 8 Then
                    If cboMay.SelectedValue = "" Then
                        objDonHangXuat.MS_MAY = Nothing
                    Else
                        objDonHangXuat.MS_MAY = Me.cboMay.SelectedValue.ToString
                    End If
                Else
                    objDonHangXuat.MS_MAY = Nothing
                End If

                If cboLDXKT.SelectedValue = "" Then
                    objDonHangXuat.MS_LY_DO_XUAT_KT = Nothing
                Else
                    objDonHangXuat.MS_LY_DO_XUAT_KT = Me.cboLDXKT.SelectedValue.ToString
                End If

                objDonHangXuat.CAN_CU = Me.txtCCu.Text
                objDonHangXuat.NGUOI_LAP = Me.txtNLap.Text
                objDonHangXuat.THU_KHO_KY = Me.txtTKho.Text

                objDonHangXuat.LY_DO_XUAT = Me.txtLydoxuat.Text
                objDonHangXuat.THU_KHO = Commons.Modules.UserName
                If Me.cboPhieuBaoTri.SelectedValue IsNot Nothing Then
                    If Me.cboPhieuBaoTri.SelectedValue.ToString <> "-1" Then
                        objDonHangXuat.MS_PHIEU_BAO_TRI = Me.cboPhieuBaoTri.SelectedValue
                    End If
                End If
                objDonHangXuat.GHI_CHU = Me.txtGHI_CHU.Text

                If Me.cbxCostCenter.SelectedValue IsNot Nothing Then
                    objDonHangXuat.MS_BP_CHIU_PHI = Me.cbxCostCenter.SelectedValue
                End If
            Catch ex As Exception

            End Try



            If status Then
                If Me.objDonHangXuatController.ADD_DON_HANG_XUAT_CS(objDonHangXuat, lstDHXVT, lstCTVTPT) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ADD_DON_HANG_XUAT_SUCCESS", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ADD_DON_HANG_XUAT_NOT_SUCCESS", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                If lstCTVTPT.Count = 0 Then
                    'duyệt để lấy hết chi tiết vật tư
                    For Each item As IC_DON_HANG_XUAT_VAT_TU_Info In lstDHXVT
                        Dim lst As List(Of CHI_TIET_VAT_TU_XUAT_Info) = Me.objDonHangXuatController.Load_Don_Hang_Xuat_Vat_Tu_Chi_Tiet(Integer.Parse(Me.cboKHO.SelectedValue.ToString), Me.txtMS_DH_XUAT.Text, item.MS_PT)
                        lstCTVTPT.AddRange(lst)
                    Next
                End If
                If Me.objDonHangXuatController.UPDATE_DON_HANG_XUAT_CS(objDonHangXuat, lstDHXVT, lstCTVTPT) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "UPDATE_DON_HANG_XUAT_SUCCESS", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "UPDATE_DON_HANG_XUAT_NOT_SUCCESS", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                lstCTVTPT.Clear()
            End If
1:
            Me.btnLockPhieuXuat.Enabled = True
            If objDonHangXuat.MS_DANG_XUAT = 9 Or objDonHangXuat.MS_DANG_XUAT = 10 Then chkIsLock.Checked = True

            'Me.tabXuatkhoPT.TabPages.Insert(0, Me.tabDanhSachPT)
            Me.SetVisibleButton(True)
            'LoadPBT()
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapPhieuXuatPBTChiTiet", cboPhieuBaoTri.SelectedValue)
            Catch ex As Exception
            End Try
            Commons.Modules.SQLString = "0Load"
            Me.Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), txtMS_DH_XUAT.EditValue)
            Commons.Modules.SQLString = ""
            RemoveHandler txtSO_PHIEU_XUAT.Validating, AddressOf Me.txtSO_PHIEU_XUAT_Validating
            EnableControl(False)
            tblCondition.Enabled = True
            grdDanhsachXuatkhoPT.Enabled = True
            grdDanhsachXuatkhoPT.Enabled = True
            Try
                'grdXuatkhoPTCT.Enabled = True
                'grvXuatkhoPTCT.Columns("TG_PB").ReadOnly = True
                'grdXuatkhoPTCT.Columns("GHI_CHU").ReadOnly = True
            Catch ex As Exception
            End Try
        End If
        bXuatBTMoi = False
        Commons.Modules.SQLString = ""
        'grdDanhsachXuatkhoPT.Enabled = True
    End Sub
    Private Sub btnKHONG_GHI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKHONG_GHI.Click
        RemoveHandler txtSO_PHIEU_XUAT.Validating, AddressOf Me.txtSO_PHIEU_XUAT_Validating
        lstCTVTPT.Clear()
        Try
            Dim sMSPhieuLuu As String = txtMS_DH_XUAT.Text

            Me.txtMS_DH_XUAT.Text = ""
            Me.txtGHI_CHU.Text = ""
            Me.txtSO_CHUNG_TU.Text = ""
            Me.txtCCu.Text = ""
            Me.txtNLap.Text = ""
            Me.txtTKho.Text = ""
            Me.txtSO_PHIEU_XUAT.Text = ""
            Me.txtGIO_NHAP.Text = ""
            Me.btnLockPhieuXuat.Enabled = True
            Me.SetVisibleButton(True)
            If status Then LoadPBT()
            Me.Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), sMSPhieuLuu)

            EnableControl(False)
            tblCondition.Enabled = True
            If Me.grvDanhsachXuatkhoPT.RowCount > 0 Then
                If Me.chkLOCK.Checked Then
                    Me.btnSUA.Enabled = False
                    Me.btnXOA.Enabled = False
                Else
                    Me.btnSUA.Enabled = True
                    Me.btnXOA.Enabled = True
                End If
                Me.BtnIN.Enabled = True
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = True Else btnInDN.Visible = False
            Else
                Me.btnSUA.Enabled = False
                Me.btnXOA.Enabled = False
                Me.BtnIN.Enabled = False
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = False Else btnInDN.Visible = False
            End If
        Catch ex As Exception

        End Try
        Commons.Modules.SQLString = ""
        bXuatBTMoi = False
        grdDanhsachXuatkhoPT.Enabled = True
    End Sub

    Private Sub btnTHOAT_CT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTHOAT_CT.Click
        Dispose()
    End Sub
    Sub CreateTitleReport_BDL()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rptTIEU_DE_NHAP_KHO_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TieudeReport", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Trangin", Commons.Modules.TypeLanguage)
        Dim sSoPhieuXN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoPhieuXN", Commons.Modules.TypeLanguage)
        Dim sNo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "sNo", Commons.Modules.TypeLanguage)
        Dim sCo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "sCo", Commons.Modules.TypeLanguage)
        Dim sNoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NoiGiao", Commons.Modules.TypeLanguage)
        Dim sSoChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SochungTu", Commons.Modules.TypeLanguage)
        Dim sDangNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DangNhap", Commons.Modules.TypeLanguage)
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NgayNhap", Commons.Modules.TypeLanguage)
        Dim sGhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "GhiChu", Commons.Modules.TypeLanguage)
        Dim sKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Kho", Commons.Modules.TypeLanguage)
        Dim sSoLuongChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoLuongChungTu", Commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MaPhuTung", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sDonViTinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DonViTinh", Commons.Modules.TypeLanguage)
        Dim sViTriKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ViTriKho", Commons.Modules.TypeLanguage)
        Dim sSoLuongVattu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoLuongVatTu", Commons.Modules.TypeLanguage)
        Dim sDonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DonGia", Commons.Modules.TypeLanguage)
        Dim sNgoaiTe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NgoaiTe", Commons.Modules.TypeLanguage)
        Dim sThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThanhTien", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Tong", Commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim sPhuTrachBoPhanSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PhuTrachBoPhanSD", Commons.Modules.TypeLanguage)
        Dim sPhuTrachcungTieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PhuTrachcungTieu", Commons.Modules.TypeLanguage)
        Dim sNguoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NguoiGiao", Commons.Modules.TypeLanguage)
        Dim sThuKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThuKho", Commons.Modules.TypeLanguage)
        Dim sKyTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "KyTen", Commons.Modules.TypeLanguage)
        Dim ThanhTienUSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThanhTienUSD", Commons.Modules.TypeLanguage)
        Dim MaDHNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MaDHNhap", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TenPT", Commons.Modules.TypeLanguage)

        Dim mauSO As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MAU_SO", Commons.Modules.TypeLanguage)
        Dim Lien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "LIEN", Commons.Modules.TypeLanguage)
        Dim tuPhieuBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PHIEUBT", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "GHI_CHU_CT", Commons.Modules.TypeLanguage)
        Dim MaVTPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MS_PT", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SOLUONG", Commons.Modules.TypeLanguage)
        Dim TienText As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoTienBangChu", Commons.Modules.TypeLanguage)
        Dim DiaChiKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DiaChiKho", Commons.Modules.TypeLanguage)
        Dim BoPhanNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "BoPhanNhan", Commons.Modules.TypeLanguage)

        Dim vNgay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "vNgay", Commons.Modules.TypeLanguage)
        Dim vThang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "vThang", Commons.Modules.TypeLanguage)
        Dim vNam As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "vNam", Commons.Modules.TypeLanguage)
        Dim vNgayXuat As String = dtpNGAY_NHAP.Text

        Try
            Dim vtbTien As New DataTable()
            vtbTien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, " SELECT SUM(THANH_TIEN) AS TONG_TIEN FROM dbo.rptPHIEU_XUAT_KHO_VAT_TU "))
            TienText = TienText + "  " + clsXuLy.DocTien(vtbTien.Rows(0)("TONG_TIEN").ToString()) + " đồng"
        Catch ex As Exception
        End Try

        Try
            Dim vtbBophan As New DataTable()
            vtbBophan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT  dbo.DON_VI.TEN_DON_VI " &
            " FROM    dbo.CONG_NHAN INNER JOIN  dbo.[TO] ON dbo.CONG_NHAN.MS_TO = dbo.[TO].MS_TO1 INNER JOIN  dbo.TO_PHONG_BAN ON dbo.[TO].MS_TO = dbo.TO_PHONG_BAN.MS_TO INNER JOIN " &
            " dbo.DON_VI ON dbo.TO_PHONG_BAN.MS_DON_VI = dbo.DON_VI.MS_DON_VI WHERE dbo.CONG_NHAN.MS_CONG_NHAN = '" + cboNguoiNhan.EditValue + "'"))
            BoPhanNhan = BoPhanNhan + vtbBophan.Rows(0)("TEN_DON_VI").ToString()
        Catch ex As Exception
        End Try


        SqlText = "CREATE TABLE DBO.rptTIEU_DE_NHAP_KHO_VAT_TU (TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(120),TrangIn nvarchar(120),SoPhieuXuatNhap nvarchar(150),sNo nvarchar(110),sCo nvarchar(110),NoiGiao nvarchar(120),SoChungTu nvarchar(130), " &
       " DangNhap nvarchar(130),NgayNhap nvarchar(120),GhiChu nvarchar(120),Kho nvarchar(120),SoLuongChungTu nvarchar(150), " &
       " STT nvarchar(15),MaPhuTung nvarchar(130),TenPT nvarchar(150),QuyCach nvarchar(130),DonViTinh nvarchar(15),ViTrikho nvarchar(150),SoLuongVatTu nvarchar(150),DonGia nvarchar(130),NgoaiTe nvarchar(120),ThanhTien nvarchar(120),Tong nvarchar(130), " &
       " MAU_SO nvarchar(160), LIEN nvarchar(160),PHIEUBT nvarchar(160),GHI_CHU_CT nvarchar(160), MS_PT nvarchar(160),SOLUONG nvarchar(160) ,ThoiGian nvarchar(160),PhuTrachBoPhanSD nvarchar(170),PhuTrachCungTieu nvarchar(160),NguoiGiao nvarchar(130), ThuKho nvarchar(130),KyTen nvarchar(130),ThanhTienUSD nvarchar(130),MaDHNhap nvarchar(120),SoTienBangChu nvarchar(255),DiaChiKho nvarchar(255),BoPhanNhan nvarchar(255),vNgay nvarchar(120),vThang nvarchar(120),vNam nvarchar(120),vNgayXuat nvarchar(120) ) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO rptTIEU_DE_NHAP_KHO_VAT_TU(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,SoPhieuXuatNhap,sNo,sCo,NoiGiao,SoChungTu, " &
        "DangNhap,NgayNhap,GhiChu,Kho,SoLuongChungTu,STT,MaPhuTung,TenPT,QuyCach,DonviTinh,ViTriKho,SoLuongVatTu,DonGia,NgoaiTe,ThanhTien,Tong, " &
        "ThoiGian,PhuTrachBoPhanSD,PhuTrachCungTieu,NguoiGiao,ThuKho,KyTen,ThanhTienUSD,MaDHNhap,MAU_SO,LIEN,PHIEUBT,GHI_CHU_CT,MS_PT,SOLUONG,SoTienBangChu,DiaChiKho,BoPhanNhan,vNgay,vThang,vNam,vNgayXuat)" &
        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTieudeReport & "',N'" & sNgayIn & "',N'" & sTrangIn & "'," &
        "N'" & sSoPhieuXN & "',N'" & sNo & "',N'" & sCo & "',N'" & sNoiGiao & "',N'" & sSoChungTu & "',N'" & Replace(sDangNhap, "'", "''") & "',N'" & sNgayNhap & "',N'" & Replace(sGhiChu, "'", "''") & "',N'" & sKho & "'," &
        "N'" & sSoLuongChungTu & "',N'" & sSTT & "',N'" & sMaPhuTung & "',N'" & TenPT & "',N'" & sQuyCach & "',N'" & sDonViTinh & "',N'" & sViTriKho & "',N'" & sSoLuongVattu & "',N'" & sDonGia & "'," &
        "N'" & sNgoaiTe & "',N'" & sThanhTien & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sPhuTrachBoPhanSD & "',N'" & sPhuTrachcungTieu & "',N'" & sNguoiGiao & "',N'" & sThuKho & "',N'" & sKyTen & "',N'" & ThanhTienUSD & "',N'" & MaDHNhap & "',N'" & mauSO & "',N'" & Lien & "',N'" & tuPhieuBT & "',N'" & GhiChu & "',N'" & MaVTPT & "',N'" & SoLuong & "',N'" & TienText & "',N'" & DiaChiKho & "',N'" & BoPhanNhan & "',N'" & vNgay & "',N'" & vThang & "',N'" & vNam & "',N'" & vNgayXuat & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub CreateTitleReportGRE()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rptTIEU_DE_NHAP_KHO_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TieudeReport", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Trangin", Commons.Modules.TypeLanguage)
        Dim sSoPhieuXN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                    "SoPhieuXN", Commons.Modules.TypeLanguage) & " : " & txtMS_DH_XUAT.Text
        Dim sNo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                    "BoPhanChiuPhi", Commons.Modules.TypeLanguage) & " : " & cbxCostCenter.Text
        Dim sCo As String = cboNguoiNhan.Text
        Dim sNoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                    "NoiGiao", Commons.Modules.TypeLanguage) & " : " & cboNguoiNhan.Text
        Dim sSoChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                "SochungTu", Commons.Modules.TypeLanguage) & " : " & Commons.Modules.UserName


        Dim sDangNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                "DangNhap", Commons.Modules.TypeLanguage) & " : " & cboDANG_XUAT.Text
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                "NgayNhap", Commons.Modules.TypeLanguage) & " : " & dtpNGAY_NHAP.Text
        Dim sGhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                "GhiChu", Commons.Modules.TypeLanguage) & " : " & cboLDXKT.Text
        Dim sKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                "Kho", Commons.Modules.TypeLanguage) & " : " & cboKHO.Text
        Dim sSoLuongChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoLuongChungTu", Commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MaPhuTung", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sDonViTinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DonViTinh", Commons.Modules.TypeLanguage)
        Dim sViTriKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ViTriKho", Commons.Modules.TypeLanguage)
        Dim sSoLuongVattu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoLuongVatTu", Commons.Modules.TypeLanguage)
        Dim sThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TG_PB", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Tong", Commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim sNguoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NguoiGiao", Commons.Modules.TypeLanguage)
        Dim sThuKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThuKho", Commons.Modules.TypeLanguage)
        Dim sKyTen As String = "-1"

        Dim sPhieuBaoTri As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PhieuBaoTri", Commons.Modules.TypeLanguage)

        If cboKHO_CHINH.Text <> "" Then
            sKyTen = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                        "KhoNhan", Commons.Modules.TypeLanguage) + " : " + cboKHO_CHINH.Text.ToString()
        End If

        Dim ThanhTienUSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThanhTienUSD", Commons.Modules.TypeLanguage)
        Dim MaDHNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MaDHNhap", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TenPT", Commons.Modules.TypeLanguage)

        Dim mauSO As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MAU_SO", Commons.Modules.TypeLanguage)
        Dim Lien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "LIEN", Commons.Modules.TypeLanguage)
        Dim tuPhieuBT As String = "-1"
        Dim sTenThietBi As String = "-1"
        If cboPhieuBaoTri.Text <> "" Then
            tuPhieuBT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                        "PHIEUBT", Commons.Modules.TypeLanguage) & " : " & cboPhieuBaoTri.Text
            sTenThietBi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TenMay", Commons.Modules.TypeLanguage) _
                        & " : " & cboMay.Text

        End If


        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "GHI_CHU_CT", Commons.Modules.TypeLanguage)
        Dim MaVTPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MS_PT", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SOLUONG", Commons.Modules.TypeLanguage)


        Dim TenThuKho As String = ""
        Dim dtTmp = New DataTable
        Dim NgayIn As Date = Commons.Modules.ObjSystems.GetNgayHeThong()

        TenThuKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU",
                "NgayHT", Commons.Modules.TypeLanguage) & " : " & NgayIn.ToString("dd/MM/yyyy HH:mm")

        Dim sDonGia As String
        Dim sNgoaiTe As String
        Dim sPhuTrachBoPhanSD As String
        Dim sPhuTrachcungTieu As String


        sDonGia = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DonGia", Commons.Modules.TypeLanguage)
        sNgoaiTe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NgoaiTe", Commons.Modules.TypeLanguage)
        sPhuTrachBoPhanSD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PhuTrachBoPhanSD", Commons.Modules.TypeLanguage)
        sPhuTrachcungTieu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PhuTrachcungTieu", Commons.Modules.TypeLanguage)
        Dim sKyPhanBo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuXuatKhoVatTu_CS", "TG_PB", Commons.Modules.TypeLanguage)

        Commons.Modules.ObjSystems.XoaTable("rptTIEU_DE_NHAP_KHO_VAT_TU")

        SqlText = "CREATE TABLE DBO.rptTIEU_DE_NHAP_KHO_VAT_TU (TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(120),TrangIn nvarchar(120),SoPhieuXuatNhap nvarchar(150),sNo nvarchar(110),sCo nvarchar(110),NoiGiao nvarchar(120),SoChungTu nvarchar(130), " &
       " DangNhap nvarchar(130),NgayNhap nvarchar(255),GhiChu nvarchar(120),Kho nvarchar(120),SoLuongChungTu nvarchar(150), " &
       " STT nvarchar(15),MaPhuTung nvarchar(130),TenPT nvarchar(150),QuyCach nvarchar(30),DonViTinh nvarchar(15),ViTrikho nvarchar(150),SoLuongVatTu nvarchar(150),DonGia nvarchar(130),NgoaiTe nvarchar(120),ThanhTien nvarchar(120),Tong nvarchar(130), " &
       " MAU_SO nvarchar(160), LIEN nvarchar(160),PHIEUBT nvarchar(160),GHI_CHU_CT nvarchar(160), MS_PT nvarchar(160),SOLUONG nvarchar(160) ,ThoiGian nvarchar(160),PhuTrachBoPhanSD nvarchar(170),PhuTrachCungTieu nvarchar(160),NguoiGiao nvarchar(130), " &
       " ThuKho nvarchar(130),KyTen nvarchar(130),ThanhTienUSD nvarchar(130),MaDHNhap nvarchar(120),TenThuKho nvarchar(250), TenMay nvarchar(4000), KyPhanBo nvarchar(255)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO rptTIEU_DE_NHAP_KHO_VAT_TU(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,SoPhieuXuatNhap,sNo,sCo,NoiGiao,SoChungTu, " &
        "DangNhap,NgayNhap,GhiChu,Kho,SoLuongChungTu,STT,MaPhuTung,TenPT,QuyCach,DonviTinh,ViTriKho,SoLuongVatTu,DonGia,NgoaiTe,ThanhTien,Tong, " &
        "ThoiGian,PhuTrachBoPhanSD,PhuTrachCungTieu,NguoiGiao,ThuKho,KyTen,ThanhTienUSD,MaDHNhap,MAU_SO,LIEN,PHIEUBT,GHI_CHU_CT,MS_PT,SOLUONG,TenThuKho,  TenMay, KyPhanBo)" &
        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTieudeReport & "',N'" & sNgayIn & "',N'" & sTrangIn & "'," &
        "N'" & sSoPhieuXN & "',N'" & sNo & "',N'" & sCo & "',N'" & sNoiGiao & "',N'" & sSoChungTu & "',N'" & Replace(sDangNhap, "'", "''") & "',N'" & sNgayNhap & "',N'" & Replace(sGhiChu, "'", "''") & "',N'" & sKho & "'," &
        "N'" & sSoLuongChungTu & "',N'" & sSTT & "',N'" & sMaPhuTung & "',N'" & TenPT & "',N'" & sQuyCach & "',N'" & sDonViTinh & "',N'" & sViTriKho & "',N'" & sSoLuongVattu & "',N'" & sDonGia & "'," &
        "N'" & sNgoaiTe & "',N'" & sThanhTien & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sPhuTrachBoPhanSD & "',N'" &
        sPhuTrachcungTieu & "',N'" & sNguoiGiao & "',N'" & sThuKho & "',N'" & sKyTen & "',N'" & ThanhTienUSD & "',N'" & MaDHNhap & "',N'" &
        mauSO & "',N'" & Lien & "',N'" & tuPhieuBT & "',N'" & GhiChu & "',N'" & MaVTPT & "',N'" & SoLuong & "',N'" & TenThuKho & "',N'" & sTenThietBi & "', N'" & sKyPhanBo & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub CreateTitleReportGRE_DN()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rptTIEU_DE_NHAP_KHO_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "TieudeReport", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "Trangin", Commons.Modules.TypeLanguage)
        Dim sSoPhieuXN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                    "SoPhieuXN", Commons.Modules.TypeLanguage) & " : " & txtMS_DH_XUAT.Text
        SqlText = ""
        Try
            SqlText = "SELECT     T3.TEN_TO, T1.MS_CONG_NHAN FROM dbo.CONG_NHAN AS T1 INNER JOIN dbo.[TO] AS T2 ON T1.MS_TO = T2.MS_TO1 INNER JOIN dbo.TO_PHONG_BAN AS T3 ON T2.MS_TO = T3.MS_TO WHERE T1.MS_CONG_NHAN = '" + cboNguoiNhan.EditValue + "' "
            SqlText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText))
        Catch ex As Exception
            SqlText = ""
        End Try

        Dim sNo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                    "BoPhanDeNghi", Commons.Modules.TypeLanguage) & " : " & SqlText

        Dim sCo As String = cboNguoiNhan.Text
        Dim sNoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                    "NoiGiao", Commons.Modules.TypeLanguage) & " : " & cboNguoiNhan.Text
        Dim sSoChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                "SochungTu", Commons.Modules.TypeLanguage) & " : " & Commons.Modules.UserName

        Dim sDangNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                "DangNhap", Commons.Modules.TypeLanguage) & " : " & cboDANG_XUAT.Text
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                "NgayNhap", Commons.Modules.TypeLanguage) & " : " & dtpNGAY_NHAP.Text
        Dim sGhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                "GhiChu", Commons.Modules.TypeLanguage) & " : " & cboLDXKT.Text
        Dim sKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                "Kho", Commons.Modules.TypeLanguage) & " : " & cboKHO.Text
        Dim sSoLuongChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "SoLuongChungTu", Commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "MaPhuTung", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sDonViTinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "DonViTinh", Commons.Modules.TypeLanguage)
        Dim sViTriKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "ViTriKho", Commons.Modules.TypeLanguage)
        Dim sSoLuongVattu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "SoLuongVatTu", Commons.Modules.TypeLanguage)
        Dim sThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "ThanhTien", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "Tong", Commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim sNguoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "NguoiGiao", Commons.Modules.TypeLanguage)
        Dim sThuKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "ThuKho", Commons.Modules.TypeLanguage)
        Dim sKyTen As String = "-1"
        If cboKHO_CHINH.Text <> "" Then
            sKyTen = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                        "KhoNhan", Commons.Modules.TypeLanguage) + " : " + cboKHO_CHINH.Text.ToString()
        End If

        Dim ThanhTienUSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "ThanhTienUSD", Commons.Modules.TypeLanguage)
        Dim MaDHNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "MaDHNhap", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "TenPT", Commons.Modules.TypeLanguage)

        Dim mauSO As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "MAU_SO", Commons.Modules.TypeLanguage)
        Dim Lien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "LIEN", Commons.Modules.TypeLanguage)
        Dim tuPhieuBT As String = "-1"
        If cboPhieuBaoTri.Text <> "" Then
            tuPhieuBT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                        "PHIEUBT", Commons.Modules.TypeLanguage) & " : " & cboPhieuBaoTri.Text
        End If

        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "GHI_CHU_CT", Commons.Modules.TypeLanguage)
        Dim MaVTPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "MS_PT", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "SOLUONG", Commons.Modules.TypeLanguage)


        Dim TenThuKho As String = ""
        Dim dtTmp = New DataTable
        Dim NgayIn As Date = Commons.Modules.ObjSystems.GetNgayHeThong()

        TenThuKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU",
                "NgayHT", Commons.Modules.TypeLanguage) & " : " & NgayIn.ToString("dd/MM/yyyy HH:mm")

        Dim sDonGia As String
        Dim sNgoaiTe As String
        Dim sPhuTrachBoPhanSD As String
        Dim sPhuTrachcungTieu As String


        sDonGia = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "DonGia", Commons.Modules.TypeLanguage)
        sNgoaiTe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "NgoaiTe", Commons.Modules.TypeLanguage)
        sPhuTrachBoPhanSD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "PhuTrachBoPhanSD", Commons.Modules.TypeLanguage)
        sPhuTrachcungTieu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDN_XUAT_KHO_VAT_TU", "PhuTrachcungTieu", Commons.Modules.TypeLanguage)

        Commons.Modules.ObjSystems.XoaTable("rptTIEU_DE_NHAP_KHO_VAT_TU")

        SqlText = "CREATE TABLE DBO.rptTIEU_DE_NHAP_KHO_VAT_TU (TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(120),TrangIn nvarchar(120),SoPhieuXuatNhap nvarchar(150),sNo nvarchar(110),sCo nvarchar(110),NoiGiao nvarchar(120),SoChungTu nvarchar(130), " &
       " DangNhap nvarchar(130),NgayNhap nvarchar(255),GhiChu nvarchar(120),Kho nvarchar(120),SoLuongChungTu nvarchar(150), " &
       " STT nvarchar(15),MaPhuTung nvarchar(130),TenPT nvarchar(150),QuyCach nvarchar(30),DonViTinh nvarchar(15),ViTrikho nvarchar(150),SoLuongVatTu nvarchar(150),DonGia nvarchar(130),NgoaiTe nvarchar(120),ThanhTien nvarchar(120),Tong nvarchar(130), " &
       " MAU_SO nvarchar(160), LIEN nvarchar(160),PHIEUBT nvarchar(160),GHI_CHU_CT nvarchar(160), MS_PT nvarchar(160),SOLUONG nvarchar(160) ,ThoiGian nvarchar(160),PhuTrachBoPhanSD nvarchar(170),PhuTrachCungTieu nvarchar(160),NguoiGiao nvarchar(130), " &
       " ThuKho nvarchar(130),KyTen nvarchar(130),ThanhTienUSD nvarchar(130),MaDHNhap nvarchar(120),TenThuKho nvarchar(250)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO rptTIEU_DE_NHAP_KHO_VAT_TU(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,SoPhieuXuatNhap,sNo,sCo,NoiGiao,SoChungTu, " &
        "DangNhap,NgayNhap,GhiChu,Kho,SoLuongChungTu,STT,MaPhuTung,TenPT,QuyCach,DonviTinh,ViTriKho,SoLuongVatTu,DonGia,NgoaiTe,ThanhTien,Tong, " &
        "ThoiGian,PhuTrachBoPhanSD,PhuTrachCungTieu,NguoiGiao,ThuKho,KyTen,ThanhTienUSD,MaDHNhap,MAU_SO,LIEN,PHIEUBT,GHI_CHU_CT,MS_PT,SOLUONG,TenThuKho )" &
        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTieudeReport & "',N'" & sNgayIn & "',N'" & sTrangIn & "'," &
        "N'" & sSoPhieuXN & "',N'" & sNo & "',N'" & sCo & "',N'" & sNoiGiao & "',N'" & sSoChungTu & "',N'" & Replace(sDangNhap, "'", "''") & "',N'" & sNgayNhap & "',N'" & Replace(sGhiChu, "'", "''") & "',N'" & sKho & "'," &
        "N'" & sSoLuongChungTu & "',N'" & sSTT & "',N'" & sMaPhuTung & "',N'" & TenPT & "',N'" & sQuyCach & "',N'" & sDonViTinh & "',N'" & sViTriKho & "',N'" & sSoLuongVattu & "',N'" & sDonGia & "'," &
        "N'" & sNgoaiTe & "',N'" & sThanhTien & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sPhuTrachBoPhanSD & "',N'" &
        sPhuTrachcungTieu & "',N'" & sNguoiGiao & "',N'" & sThuKho & "',N'" & sKyTen & "',N'" & ThanhTienUSD & "',N'" & MaDHNhap & "',N'" &
        mauSO & "',N'" & Lien & "',N'" & tuPhieuBT & "',N'" & GhiChu & "',N'" & MaVTPT & "',N'" & SoLuong & "',N'" & TenThuKho & "')"

        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Sub CreateTitleReport()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rptTIEU_DE_NHAP_KHO_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TieudeReport", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Trangin", Commons.Modules.TypeLanguage)
        Dim sSoPhieuXN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoPhieuXN", Commons.Modules.TypeLanguage)
        Dim sNo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "sNo", Commons.Modules.TypeLanguage)
        Dim sCo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "sCo", Commons.Modules.TypeLanguage)
        Dim sNoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NoiGiao", Commons.Modules.TypeLanguage)
        Dim sSoChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SochungTu", Commons.Modules.TypeLanguage)

        If Commons.Modules.sPrivate.ToUpper = "ACECOOK" And (cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10) Then
            sNoiGiao = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "KhoNhan", Commons.Modules.TypeLanguage)
            sSoChungTu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "CanCu", Commons.Modules.TypeLanguage)
        End If



        Dim sDangNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DangNhap", Commons.Modules.TypeLanguage)
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NgayNhap", Commons.Modules.TypeLanguage)
        Dim sGhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "GhiChu", Commons.Modules.TypeLanguage)
        Dim sKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Kho", Commons.Modules.TypeLanguage)
        Dim sSoLuongChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoLuongChungTu", Commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MaPhuTung", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sDonViTinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DonViTinh", Commons.Modules.TypeLanguage)
        Dim sViTriKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ViTriKho", Commons.Modules.TypeLanguage)
        Dim sSoLuongVattu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SoLuongVatTu", Commons.Modules.TypeLanguage)
        Dim sThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThanhTien", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "Tong", Commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim sNguoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NguoiGiao", Commons.Modules.TypeLanguage)
        Dim sThuKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThuKho", Commons.Modules.TypeLanguage)
        Dim sKyTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "KyTen", Commons.Modules.TypeLanguage)
        Dim ThanhTienUSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "ThanhTienUSD", Commons.Modules.TypeLanguage)
        Dim MaDHNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MaDHNhap", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TenPT", Commons.Modules.TypeLanguage)

        Dim mauSO As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MAU_SO", Commons.Modules.TypeLanguage)
        Dim Lien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "LIEN", Commons.Modules.TypeLanguage)
        Dim tuPhieuBT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PHIEUBT", Commons.Modules.TypeLanguage)
        Dim GhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "GHI_CHU_CT", Commons.Modules.TypeLanguage)
        Dim MaVTPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MS_PT", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "SOLUONG", Commons.Modules.TypeLanguage)
        Dim PartNum As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MS_PT_NCC", Commons.Modules.TypeLanguage)

        Dim MsPtCty As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MS_PT_CTY", Commons.Modules.TypeLanguage)


        Dim TenThuKho As String = ""
        If Commons.Modules.SQLString = "NUTIFOOD" Then
            TenThuKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TenThuKho", Commons.Modules.TypeLanguage)
        End If

        Dim sDonGia As String
        Dim sNgoaiTe As String
        Dim sPhuTrachBoPhanSD As String
        Dim sPhuTrachcungTieu As String

        If Commons.Modules.SQLString = "DOFICO" Then
            sDonGia = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MsMay", Commons.Modules.TypeLanguage)
            sNgoaiTe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "MS_PT_CTY", Commons.Modules.TypeLanguage)
            sThanhTien = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "TenMay", Commons.Modules.TypeLanguage)
            sPhuTrachBoPhanSD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "QuanDoc", Commons.Modules.TypeLanguage)
            sPhuTrachcungTieu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "QuanLyPhanXuong", Commons.Modules.TypeLanguage)
        Else
            sDonGia = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "DonGia", Commons.Modules.TypeLanguage)
            sNgoaiTe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NgoaiTe", Commons.Modules.TypeLanguage)
            sPhuTrachBoPhanSD = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PhuTrachBoPhanSD", Commons.Modules.TypeLanguage)
            sPhuTrachcungTieu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "PhuTrachcungTieu", Commons.Modules.TypeLanguage)
        End If
        If Commons.Modules.sPrivate.ToUpper = "ACECOOK" Then
            sKyTen = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "NgayLap", Commons.Modules.TypeLanguage)
            TenThuKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU", "BoPhanChiuPhi", Commons.Modules.TypeLanguage)
            sThoiGian = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Ngay", Commons.Modules.TypeLanguage) + " ..... " &
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Thang", Commons.Modules.TypeLanguage) + " ..... " &
                Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Nam", Commons.Modules.TypeLanguage) + " ...... "

        End If

        SqlText = "CREATE TABLE DBO.rptTIEU_DE_NHAP_KHO_VAT_TU (TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(120),TrangIn nvarchar(120),SoPhieuXuatNhap nvarchar(150),sNo nvarchar(110),sCo nvarchar(110),NoiGiao nvarchar(120),SoChungTu nvarchar(130), " &
       " DangNhap nvarchar(130),NgayNhap nvarchar(20),GhiChu nvarchar(120),Kho nvarchar(120),SoLuongChungTu nvarchar(150), " &
       " STT nvarchar(15),MaPhuTung nvarchar(130),TenPT nvarchar(150),QuyCach nvarchar(30),DonViTinh nvarchar(15),ViTrikho nvarchar(150),SoLuongVatTu nvarchar(150),DonGia nvarchar(130),NgoaiTe nvarchar(120),ThanhTien nvarchar(120),Tong nvarchar(130), " &
       " MAU_SO nvarchar(160), LIEN nvarchar(160),PHIEUBT nvarchar(160),GHI_CHU_CT nvarchar(160), MS_PT nvarchar(160),SOLUONG nvarchar(160) ,ThoiGian nvarchar(160),PhuTrachBoPhanSD nvarchar(170),PhuTrachCungTieu nvarchar(160),NguoiGiao nvarchar(130), " &
       " ThuKho nvarchar(130),KyTen nvarchar(130),ThanhTienUSD nvarchar(130),MaDHNhap nvarchar(120),TenThuKho nvarchar(250), PartNum nvarchar(255),MS_PT_CTY nvarchar(25) ) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        SqlText = "INSERT INTO rptTIEU_DE_NHAP_KHO_VAT_TU(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,SoPhieuXuatNhap,sNo,sCo,NoiGiao,SoChungTu, " &
        "DangNhap,NgayNhap,GhiChu,Kho,SoLuongChungTu,STT,MaPhuTung,TenPT,QuyCach,DonviTinh,ViTriKho,SoLuongVatTu,DonGia,NgoaiTe,ThanhTien,Tong, " &
        "ThoiGian,PhuTrachBoPhanSD,PhuTrachCungTieu,NguoiGiao,ThuKho,KyTen,ThanhTienUSD,MaDHNhap,MAU_SO,LIEN,PHIEUBT,GHI_CHU_CT,MS_PT,SOLUONG,TenThuKho,PartNum,MS_PT_CTY  )" &
        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTieudeReport & "',N'" & sNgayIn & "',N'" & sTrangIn & "'," &
        "N'" & sSoPhieuXN & "',N'" & sNo & "',N'" & sCo & "',N'" & sNoiGiao & "',N'" & sSoChungTu & "',N'" & Replace(sDangNhap, "'", "''") & "',N'" & sNgayNhap & "',N'" & Replace(sGhiChu, "'", "''") & "',N'" & sKho & "'," &
        "N'" & sSoLuongChungTu & "',N'" & sSTT & "',N'" & sMaPhuTung & "',N'" & TenPT & "',N'" & sQuyCach & "',N'" & sDonViTinh & "',N'" & sViTriKho & "',N'" & sSoLuongVattu & "',N'" & sDonGia & "'," &
        "N'" & sNgoaiTe & "',N'" & sThanhTien & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sPhuTrachBoPhanSD & "',N'" &
        sPhuTrachcungTieu & "',N'" & sNguoiGiao & "',N'" & sThuKho & "',N'" & sKyTen & "',N'" & ThanhTienUSD & "',N'" & MaDHNhap & "',N'" &
        mauSO & "',N'" & Lien & "',N'" & tuPhieuBT & "',N'" & GhiChu & "',N'" & MaVTPT & "',N'" & SoLuong & "',N'" & TenThuKho & "',N'" & PartNum & "',N'" & MsPtCty & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
    End Sub



#Region " In Phieu Xuat Kho VINHHOAN"
    Private Sub InPhieuXuatKhoVINHHOAN()
        Try
            Dim dtTmp = New DataTable
            Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()


            frmRpt.rptName = "rptPHIEUXUATKHO_VH"
            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            command.CommandText = "SP_PHIEUXUATKHO"
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@MS_DH_XUAT_PT", txtMS_DH_XUAT.Text))
            command.Parameters.Add(New SqlParameter("@NNgu", Commons.Modules.TypeLanguage))


            Dim adapter As New SqlDataAdapter(command)
            Dim dsTmp As New DataSet()
            Try
                adapter.Fill(dsTmp)
            Catch ex As Exception

            End Try
            Dim sTmp As String = ""

            For i As Integer = 0 To dsTmp.Tables.Count - 1
                dtTmp = New DataTable
                dtTmp = dsTmp.Tables(i)
                Select Case i
                    Case 0
                        If Integer.Parse(dtTmp.Rows(0)("MS_DANG_XUAT").ToString) = 1 Then
                            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEUXUATKHO_VH", "MUC_DICH_XUAT", Commons.Modules.TypeLanguage) &
                                " : " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEUXUATKHO_VH", "PBT", Commons.Modules.TypeLanguage) &
                                " : " & dtTmp.Rows(0)("MS_PHIEU_BAO_TRI").ToString & " + " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEUXUATKHO_VH", "MS_MAY", Commons.Modules.TypeLanguage) &
                                " : " & dtTmp.Rows(0)("MS_MAY").ToString & " + " & Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEUXUATKHO_VH", "TEN_MAY", Commons.Modules.TypeLanguage) &
                                " : " & dtTmp.Rows(0)("TEN_MAY").ToString
                        Else
                            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEUXUATKHO_VH", "MUC_DICH_XUAT", Commons.Modules.TypeLanguage) &
                            " : " & dtTmp.Rows(0)("MUC_DICH_XUAT").ToString
                        End If
                        dtTmp.TableName = "PXK_INFO"
                    Case 1
                        dtTmp.TableName = "PXK_DETAIL"
                End Select
                frmRpt.AddDataTableSource(dsTmp.Tables(i))
            Next
            ''Mục đích xuất: Phiếu bảo trì số:...+ ;Mã số thiết bị:...+ ;Tên thiết bị:….


            frmRpt.AddDataTableSource(LanguageReportVINHHOAN(sTmp))
            Commons.Modules.SQLString = "0Design"
            frmRpt.ShowDialog()
            Commons.Modules.SQLString = ""
        Catch ex As Exception

        End Try

    End Sub

    Function LanguageReportVINHHOAN(ByVal sDX As String) As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_PXK"
        For i As Integer = 0 To 29
            vtbTitle.Columns.Add()
        Next
        Try
            vtbTitle.Columns(0).ColumnName = "PHIEU_XUAT_KHO"
            vtbTitle.Columns(1).ColumnName = "MA_SO"
            vtbTitle.Columns(2).ColumnName = "NGAY_HIEU_LUC"
            vtbTitle.Columns(3).ColumnName = "LAN_SOAT_XET"

            vtbTitle.Columns(4).ColumnName = "XUAT_TAI_KHO"
            vtbTitle.Columns(5).ColumnName = "NGAY_GIO_XUAT"
            vtbTitle.Columns(6).ColumnName = "DON_VI"

            vtbTitle.Columns(7).ColumnName = "LOAI_CHUNG_TU"
            vtbTitle.Columns(8).ColumnName = "MUC_DICH_XUAT"

            vtbTitle.Columns(9).ColumnName = "PHIEU_BAO_TRI_SO"
            vtbTitle.Columns(10).ColumnName = "MA_SO_THIET_BI"
            vtbTitle.Columns(11).ColumnName = "TEN_THIET_BI"
            vtbTitle.Columns(12).ColumnName = "STT"

            vtbTitle.Columns(13).ColumnName = "TEN_HANG_HOA"
            vtbTitle.Columns(14).ColumnName = "MA_HANG_HOA"

            vtbTitle.Columns(15).ColumnName = "DVT"
            vtbTitle.Columns(16).ColumnName = "SO_LUONG"

            vtbTitle.Columns(17).ColumnName = "THEO_CHUNG_TU"
            vtbTitle.Columns(18).ColumnName = "THUC_XUAT"

            vtbTitle.Columns(19).ColumnName = "GHI_CHU"
            vtbTitle.Columns(20).ColumnName = "NGUOI_NHAN_HANG"
            vtbTitle.Columns(21).ColumnName = "THU_KHO"
            vtbTitle.Columns(22).ColumnName = "KE_TOAN_TRUONG"
            vtbTitle.Columns(23).ColumnName = "KY_HO_TEN"
            vtbTitle.Columns(24).ColumnName = "SO_PX"

            vtbTitle.Columns(25).ColumnName = "TMP1"
            vtbTitle.Columns(26).ColumnName = "TMP2"
            vtbTitle.Columns(27).ColumnName = "TMP3"
            vtbTitle.Columns(28).ColumnName = "TMP4"
            vtbTitle.Columns(29).ColumnName = "TMP5"



            Dim vRowTitle As DataRow = vtbTitle.NewRow()
            Dim sBC As String = "rptPHIEUXUATKHO_VH"

            vRowTitle("PHIEU_XUAT_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHIEU_XUAT_KHO", Commons.Modules.TypeLanguage)
            vRowTitle("MA_SO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO", Commons.Modules.TypeLanguage)
            vRowTitle("NGAY_HIEU_LUC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_HIEU_LUC", Commons.Modules.TypeLanguage)
            vRowTitle("LAN_SOAT_XET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LAN_SOAT_XET", Commons.Modules.TypeLanguage)
            vRowTitle("XUAT_TAI_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "XUAT_TAI_KHO", Commons.Modules.TypeLanguage)
            vRowTitle("NGAY_GIO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_GIO_XUAT", Commons.Modules.TypeLanguage)
            vRowTitle("DON_VI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DON_VI", Commons.Modules.TypeLanguage)
            vRowTitle("LOAI_CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LOAI_CHUNG_TU", Commons.Modules.TypeLanguage)
            'Mục đích xuất: Phiếu bảo trì số:...+ ;Mã số thiết bị:...+ ;Tên thiết bị:….
            vRowTitle("MUC_DICH_XUAT") = sDX
            vRowTitle("PHIEU_BAO_TRI_SO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHIEU_BAO_TRI_SO", Commons.Modules.TypeLanguage)
            vRowTitle("MA_SO_THIET_BI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO_THIET_BI", Commons.Modules.TypeLanguage)
            vRowTitle("TEN_THIET_BI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_THIET_BI", Commons.Modules.TypeLanguage)
            vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "STT", Commons.Modules.TypeLanguage)
            vRowTitle("TEN_HANG_HOA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_HANG_HOA", Commons.Modules.TypeLanguage)
            vRowTitle("MA_HANG_HOA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_HANG_HOA", Commons.Modules.TypeLanguage)
            vRowTitle("DVT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DVT", Commons.Modules.TypeLanguage)
            vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_LUONG", Commons.Modules.TypeLanguage)
            vRowTitle("THEO_CHUNG_TU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THEO_CHUNG_TU", Commons.Modules.TypeLanguage)
            vRowTitle("THUC_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THUC_XUAT", Commons.Modules.TypeLanguage)

            vRowTitle("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "GHI_CHU", Commons.Modules.TypeLanguage)
            vRowTitle("NGUOI_NHAN_HANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_NHAN_HANG", Commons.Modules.TypeLanguage)
            vRowTitle("THU_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THU_KHO", Commons.Modules.TypeLanguage)
            vRowTitle("KE_TOAN_TRUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KE_TOAN_TRUONG", Commons.Modules.TypeLanguage)

            vRowTitle("KY_HO_TEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KY_HO_TEN", Commons.Modules.TypeLanguage)
            vRowTitle("SO_PX") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_PX", Commons.Modules.TypeLanguage)

            vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LY_DO_XUAT", Commons.Modules.TypeLanguage)
            vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP2", Commons.Modules.TypeLanguage)
            vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP3", Commons.Modules.TypeLanguage)
            vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP4", Commons.Modules.TypeLanguage)
            Dim sTmp As String
            Try
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblNOI_NHAN", Commons.Modules.TypeLanguage) & " : " & cboNguoiNhan.Text
            Catch ex As Exception
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "lblNOI_NHAN", Commons.Modules.TypeLanguage)
            End Try

            vRowTitle("TMP5") = sTmp

            vtbTitle.Rows.Add(vRowTitle)
        Catch ex As Exception

        End Try
        Return vtbTitle
    End Function
#End Region

#Region "In Phieu De Nghi Xuat Kho VINHHOAN"
    Private Sub InPhieuDeNghiXuatKhoVINHHOAN()
        Try
            Dim dtTmp = New DataTable
            Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()


            frmRpt.rptName = "rptPHIEUDENGHIXUATKHO_VH"
            Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
            connection.Open()

            Dim command As New System.Data.SqlClient.SqlCommand()
            command.Connection = connection
            command.CommandText = "SP_PHIEUDENGHIXUATKHO"
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@MS_DH_XUAT_PT", txtMS_DH_XUAT.Text))

            Dim adapter As New SqlDataAdapter(command)
            Dim dsTmp As New DataSet()
            Try
                adapter.Fill(dsTmp)
            Catch ex As Exception

            End Try
            Dim sTmp As String = ""

            For i As Integer = 0 To dsTmp.Tables.Count - 1
                dtTmp = New DataTable
                dtTmp = dsTmp.Tables(i)
                Select Case i
                    Case 0
                        dtTmp.TableName = "DNXK_INFO"
                    Case 1
                        dtTmp.TableName = "DNXK_DETAIL"
                End Select
                frmRpt.AddDataTableSource(dsTmp.Tables(i))
            Next

            frmRpt.AddDataTableSource(LanguageReportPhieuDeNghiXuatKhoVINHHOAN())
            Commons.Modules.SQLString = "0Design"
            frmRpt.ShowDialog()
            Commons.Modules.SQLString = ""
        Catch ex As Exception

        End Try

    End Sub

    Function LanguageReportPhieuDeNghiXuatKhoVINHHOAN() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TIEU_DE_DNXK"
        For i As Integer = 0 To 23
            vtbTitle.Columns.Add()
        Next
        Try
            vtbTitle.Columns(0).ColumnName = "PHIEU_DE_NGHI_XUAT_KHO"
            vtbTitle.Columns(1).ColumnName = "MA_SO"
            vtbTitle.Columns(2).ColumnName = "NGAY_HIEU_LUC"
            vtbTitle.Columns(3).ColumnName = "LAN_SOAT_XET"

            vtbTitle.Columns(4).ColumnName = "BO_PHAN_CONG_TAC"
            vtbTitle.Columns(5).ColumnName = "LY_DO_XUAT_KHO"

            vtbTitle.Columns(6).ColumnName = "STT"

            vtbTitle.Columns(7).ColumnName = "TEN_HANG_HOA"
            vtbTitle.Columns(8).ColumnName = "MA_HANG_HOA"

            vtbTitle.Columns(9).ColumnName = "DVT"
            vtbTitle.Columns(10).ColumnName = "SO_LUONG"

            vtbTitle.Columns(11).ColumnName = "XIN_LINH"
            vtbTitle.Columns(12).ColumnName = "THUC_LINH"
            vtbTitle.Columns(13).ColumnName = "GHI_CHU"


            vtbTitle.Columns(14).ColumnName = "BAN_GIAM_DOC_TRUONG_DON_VI"
            vtbTitle.Columns(15).ColumnName = "NGAY"
            vtbTitle.Columns(16).ColumnName = "NGUOI_DE_NGHI"
            vtbTitle.Columns(17).ColumnName = "NGAY_DE_NGHI"
            vtbTitle.Columns(18).ColumnName = "SO_DNX"

            vtbTitle.Columns(19).ColumnName = "TMP1"
            vtbTitle.Columns(20).ColumnName = "TMP2"
            vtbTitle.Columns(21).ColumnName = "TMP3"
            vtbTitle.Columns(22).ColumnName = "TMP4"
            vtbTitle.Columns(23).ColumnName = "TMP5"



            Dim vRowTitle As DataRow = vtbTitle.NewRow()
            Dim sBC As String = "rptPHIEUDENGHIXUATKHO_VH"

            vRowTitle("PHIEU_DE_NGHI_XUAT_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHIEU_DE_NGHI_XUAT_KHO", Commons.Modules.TypeLanguage)
            vRowTitle("MA_SO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO", Commons.Modules.TypeLanguage)
            vRowTitle("NGAY_HIEU_LUC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_HIEU_LUC", Commons.Modules.TypeLanguage)
            vRowTitle("LAN_SOAT_XET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LAN_SOAT_XET", Commons.Modules.TypeLanguage)
            vRowTitle("BO_PHAN_CONG_TAC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "BO_PHAN_CONG_TAC", Commons.Modules.TypeLanguage)
            vRowTitle("LY_DO_XUAT_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LY_DO_XUAT_KHO", Commons.Modules.TypeLanguage)

            vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "STT", Commons.Modules.TypeLanguage)
            vRowTitle("TEN_HANG_HOA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_HANG_HOA", Commons.Modules.TypeLanguage)
            vRowTitle("MA_HANG_HOA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_HANG_HOA", Commons.Modules.TypeLanguage)
            vRowTitle("DVT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DVT", Commons.Modules.TypeLanguage)
            vRowTitle("SO_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_LUONG", Commons.Modules.TypeLanguage)
            vRowTitle("XIN_LINH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "XIN_LINH", Commons.Modules.TypeLanguage)
            vRowTitle("THUC_LINH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THUC_LINH", Commons.Modules.TypeLanguage)

            vRowTitle("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "GHI_CHU", Commons.Modules.TypeLanguage)
            vRowTitle("BAN_GIAM_DOC_TRUONG_DON_VI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "BAN_GIAM_DOC_TRUONG_DON_VI", Commons.Modules.TypeLanguage)
            vRowTitle("NGAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY", Commons.Modules.TypeLanguage)
            vRowTitle("NGUOI_DE_NGHI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_DE_NGHI", Commons.Modules.TypeLanguage)

            vRowTitle("NGAY_DE_NGHI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_DE_NGHI", Commons.Modules.TypeLanguage)
            vRowTitle("SO_DNX") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_DNX", Commons.Modules.TypeLanguage)

            vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP1", Commons.Modules.TypeLanguage)
            vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP2", Commons.Modules.TypeLanguage)
            vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP3", Commons.Modules.TypeLanguage)
            vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP4", Commons.Modules.TypeLanguage)
            vRowTitle("TMP5") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP5", Commons.Modules.TypeLanguage)

            vtbTitle.Rows.Add(vRowTitle)
        Catch ex As Exception

        End Try
        Return vtbTitle
    End Function
#End Region

#Region "In Shisedo"
    Private Sub InSHISEIDO(ByVal iLoaiBC As Integer) ' 0 in binh thuong-- 1 xuat pdf

        Dim sMail As String = ""
        If iLoaiBC = 1 Then
            Try
                sMail = Convert.ToString(SqlHelper.ExecuteScalar(IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 ISNULL(BPCP_MAIL,'') FROM BO_PHAN_CHIU_PHI WHERE MS_BP_CHIU_PHI = " & cbxCostCenter.SelectedValue))
            Catch ex As Exception
                sMail = ""
            End Try
            If sMail = "" Then Exit Sub
        End If


        Dim Mexport As New Vietsoft.MLoadReport()
        Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
        Dim dtTmp As New DataTable
        Commons.Modules.SQLString = ""
        Try

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT     C.TEN_TO FROM dbo.CONG_NHAN AS A INNER JOIN dbo.[TO] AS B ON A.MS_TO = B.MS_TO1 INNER JOIN dbo.TO_PHONG_BAN AS C ON B.MS_TO = C.MS_TO WHERE (A.MS_CONG_NHAN = '" & cboNguoiNhan.EditValue & "')"))
            If dtTmp.Rows.Count > 0 Then
                Commons.Modules.SQLString = dtTmp.Rows(0)(0).ToString()
            End If
        Catch ex As Exception

        End Try

        dtTmp = New DataTable
        dtTmp.TableName = "PXK"
        For i As Integer = 0 To 7
            dtTmp.Columns.Add()
        Next
        dtTmp.Columns(0).ColumnName = "MS_PX"
        dtTmp.Columns(1).ColumnName = "NGAY_XUAT"
        dtTmp.Columns(2).ColumnName = "KHO_XUAT"
        dtTmp.Columns(3).ColumnName = "BP_CHIU_PHI"
        dtTmp.Columns(4).ColumnName = "CTY_NHAN"
        dtTmp.Columns(5).ColumnName = "PHONG_BAN"
        dtTmp.Columns(6).ColumnName = "TEN_MAY"
        dtTmp.Columns(7).ColumnName = "LY_DO_XUAT"
        Dim vRowTitle As DataRow = dtTmp.NewRow()
        vRowTitle("MS_PX") = txtMS_DH_XUAT.Text
        vRowTitle("NGAY_XUAT") = dtpNGAY_NHAP.Text
        vRowTitle("KHO_XUAT") = cboKHO.Text
        vRowTitle("BP_CHIU_PHI") = cbxCostCenter.Text
        vRowTitle("CTY_NHAN") = cboNguoiNhan.Text


        vRowTitle("PHONG_BAN") = Commons.Modules.SQLString
        If cboDANG_XUAT.SelectedValue = 1 Then
            vRowTitle("TEN_MAY") = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 dbo.MAY.TEN_MAY FROM dbo.PHIEU_BAO_TRI INNER JOIN dbo.MAY ON dbo.PHIEU_BAO_TRI.MS_MAY = dbo.MAY.MS_MAY WHERE (dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = '" & cboPhieuBaoTri.SelectedValue & "')")

        Else
            vRowTitle("TEN_MAY") = cboMay.Text
        End If
        vRowTitle("LY_DO_XUAT") = txtGHI_CHU.Text

        dtTmp.Rows.Add(vRowTitle)

        If iLoaiBC = 1 Then Mexport.AddDataTableSource(dtTmp) Else frmRpt.AddDataTableSource(dtTmp)

        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCPhieuXuatSSD", txtMS_DH_XUAT.Text, Commons.Modules.TypeLanguage))
        dtTmp.TableName = "PXK_CT"
        If iLoaiBC = 1 Then Mexport.AddDataTableSource(dtTmp) Else frmRpt.AddDataTableSource(dtTmp)

        If iLoaiBC = 1 Then Mexport.AddDataTableSource(NNNguReportSSD) Else frmRpt.AddDataTableSource(NNNguReportSSD)

        frmRpt.rptName = "rptXUAT_KHO_VAT_TU_SSD"

        If iLoaiBC = 1 Then

            Dim sFile As String = ""
            Try
                sFile = "PhieuXuatKho-" + txtMS_DH_XUAT.Text
                'Try
                '    sMail = Convert.ToString(SqlHelper.ExecuteScalar(IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 ISNULL(BPCP_MAIL,'') FROM BO_PHAN_CHIU_PHI WHERE MS_BP_CHIU_PHI = " & cbxCostCenter.SelectedValue))
                'Catch ex As Exception

                'End Try
                If sMail = "" Then Exit Sub
                Modules.ObjSystems.MCheckEmail(sMail)
                Modules.ObjSystems.MBoMailTrung(sMail)
                Modules.ObjSystems.MBoMailUser(sMail)
                If Not Mexport.AutoExporttoPDF(Application.StartupPath + "\reports\", frmRpt.rptName, sFile, Application.StartupPath, Commons.Modules.TypeLanguage) Then Exit Sub
                Dim sTieuDePX As String
                Dim sBodyPX As String
                sTieuDePX = Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TIEU_DE_GOI_MAIL_SSD", Commons.Modules.TypeLanguage)
                sBodyPX = Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "sBodyPX", Commons.Modules.TypeLanguage)
                Commons.Modules.MMail.MSendEmail(sMail, Modules.sMailFrom, Modules.sMailFromPass, sTieuDePX, sBodyPX, Application.StartupPath + "\" + sFile + ".pdf", Modules.sMailFromSmtp, Modules.sMailFromPort)
            Catch ex As Exception

            End Try

            Commons.Modules.ObjSystems.Xoahinh(Application.StartupPath + "\" + sFile + ".pdf")
        Else
            frmRpt.ShowDialog()
        End If



    End Sub

    Function NNNguReportSSD() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TD_PX_SSD"
        For i As Integer = 0 To 26
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "TD_PX_SSD"
        vtbTitle.Columns(1).ColumnName = "MS_DHX"
        vtbTitle.Columns(2).ColumnName = "NGAY_XUAT"
        vtbTitle.Columns(3).ColumnName = "KHO_XUAT"
        vtbTitle.Columns(4).ColumnName = "BP_CHIU_PHI"
        vtbTitle.Columns(5).ColumnName = "NCTY_NHAN"
        vtbTitle.Columns(6).ColumnName = "PB_NHAN"
        vtbTitle.Columns(7).ColumnName = "TEN_MAY"
        vtbTitle.Columns(8).ColumnName = "LY_DO_XUAT"

        vtbTitle.Columns(9).ColumnName = "STT"
        vtbTitle.Columns(10).ColumnName = "MS_PT"
        vtbTitle.Columns(11).ColumnName = "TEN_PT"

        vtbTitle.Columns(13).ColumnName = "PART_NO"
        vtbTitle.Columns(14).ColumnName = "TEN_DVT"
        vtbTitle.Columns(15).ColumnName = "SL_XUAT"
        vtbTitle.Columns(16).ColumnName = "GHI_CHU"
        vtbTitle.Columns(17).ColumnName = "PHU_TRACH_KHO"
        vtbTitle.Columns(18).ColumnName = "NGUOI_NHAN"
        vtbTitle.Columns(19).ColumnName = "NGUOI_DUYET"
        vtbTitle.Columns(20).ColumnName = "KY_HO_TEN"
        vtbTitle.Columns(21).ColumnName = "APPROVED_BY"
        vtbTitle.Columns(22).ColumnName = "TMP1"
        vtbTitle.Columns(23).ColumnName = "TMP2"
        vtbTitle.Columns(24).ColumnName = "TMP3"
        vtbTitle.Columns(25).ColumnName = "TMP4"
        vtbTitle.Columns(26).ColumnName = "TMP5"


        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("TD_PX_SSD") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "TD_PX_SSD", Commons.Modules.TypeLanguage)
        vRowTitle("MS_DHX") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "MS_DHX", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("NGAY_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "NGAY_XUAT", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("KHO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "KHO_XUAT", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("BP_CHIU_PHI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "BP_CHIU_PHI", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("NCTY_NHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "NCTY_NHAN", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("PB_NHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "PB_NHAN", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("TEN_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "TEN_MAY", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("LY_DO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "LY_DO_XUAT", Commons.Modules.TypeLanguage) & " : "

        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "MS_PT", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "TEN_PT", Commons.Modules.TypeLanguage)
        vRowTitle("PART_NO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "PART_NO", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_DVT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "TEN_DVT", Commons.Modules.TypeLanguage)
        vRowTitle("SL_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "SL_XUAT", Commons.Modules.TypeLanguage)
        vRowTitle("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "GHI_CHU", Commons.Modules.TypeLanguage)
        vRowTitle("PHU_TRACH_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "PHU_TRACH_KHO", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_NHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "NGUOI_NHAN", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_DUYET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "NGUOI_DUYET", Commons.Modules.TypeLanguage)
        vRowTitle("KY_HO_TEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "KY_HO_TEN", Commons.Modules.TypeLanguage)
        vRowTitle("APPROVED_BY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_SSD", "APPROVED_BY", Commons.Modules.TypeLanguage)
        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

#End Region

#Region "In ADC"
    Private Sub InADC()
        Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCPhieuXuatADC", txtMS_DH_XUAT.Text, Commons.Modules.TypeLanguage))
        dtTmp.TableName = "PXK_ADC"
        frmRpt.AddDataTableSource(dtTmp)

        frmRpt.AddDataTableSource(NNNguADC)
        frmRpt.rptName = "rptXUAT_KHO_VAT_TU_ADC"
        frmRpt.ShowDialog()
    End Sub

    Function NNNguADC() As DataTable
        Dim vtbTitle As New DataTable()
        vtbTitle.TableName = "TD_PX_ADC"
        For i As Integer = 0 To 30
            vtbTitle.Columns.Add()
        Next
        vtbTitle.Columns(0).ColumnName = "MAU_SO"
        vtbTitle.Columns(1).ColumnName = "LAN_BH"
        vtbTitle.Columns(2).ColumnName = "NGAY_BH"
        vtbTitle.Columns(3).ColumnName = "TIEU_DE_XK_ADC"

        vtbTitle.Columns(4).ColumnName = "SO_PHIEU"
        vtbTitle.Columns(5).ColumnName = "NGAY_XUAT"
        vtbTitle.Columns(6).ColumnName = "KHO_XUAT"
        vtbTitle.Columns(7).ColumnName = "LD_XUAT"


        vtbTitle.Columns(8).ColumnName = "G_CHU"


        vtbTitle.Columns(9).ColumnName = "STT"
        vtbTitle.Columns(10).ColumnName = "MS_PT"
        vtbTitle.Columns(11).ColumnName = "TEN_PT"
        vtbTitle.Columns(12).ColumnName = "TEN_MAY"
        vtbTitle.Columns(13).ColumnName = "SO_PBT"

        vtbTitle.Columns(14).ColumnName = "TEN_DVT"
        vtbTitle.Columns(15).ColumnName = "SL_XUAT"

        vtbTitle.Columns(16).ColumnName = "GHI_CHU"
        vtbTitle.Columns(17).ColumnName = "DON_GIA"
        vtbTitle.Columns(18).ColumnName = "THANH_TIEN"
        vtbTitle.Columns(19).ColumnName = "TRUONG_BP"
        vtbTitle.Columns(20).ColumnName = "THU_KHO"
        vtbTitle.Columns(21).ColumnName = "NGUOI_NHAN_HANG"
        vtbTitle.Columns(22).ColumnName = "NGUOI_LAP"
        vtbTitle.Columns(23).ColumnName = "TONG_CONG"
        vtbTitle.Columns(24).ColumnName = "NGUOI_DX"
        vtbTitle.Columns(25).ColumnName = "NGUOI_NHAN"

        vtbTitle.Columns(26).ColumnName = "TMP1"
        vtbTitle.Columns(27).ColumnName = "TMP2"
        vtbTitle.Columns(28).ColumnName = "TMP3"
        vtbTitle.Columns(29).ColumnName = "TMP4"
        vtbTitle.Columns(30).ColumnName = "TMP5"





        Dim vRowTitle As DataRow = vtbTitle.NewRow()
        vRowTitle("MAU_SO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "MAU_SO", Commons.Modules.TypeLanguage)
        vRowTitle("LAN_BH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "LAN_BH", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("NGAY_BH") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "NGAY_BH", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("TIEU_DE_XK_ADC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TIEU_DE_XK_ADC", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("SO_PHIEU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "SO_PHIEU", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("NGAY_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "NGAY_XUAT", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("KHO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "KHO_XUAT", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("LD_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "LD_XUAT", Commons.Modules.TypeLanguage) & " : "
        vRowTitle("G_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "G_CHU", Commons.Modules.TypeLanguage) & " : "

        vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "STT", Commons.Modules.TypeLanguage)
        vRowTitle("MS_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "MS_PT", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_PT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TEN_PT", Commons.Modules.TypeLanguage)
        vRowTitle("SO_PBT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "SO_PBT", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_DVT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TEN_DVT", Commons.Modules.TypeLanguage)
        vRowTitle("SL_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "SL_XUAT", Commons.Modules.TypeLanguage)
        vRowTitle("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "GHI_CHU", Commons.Modules.TypeLanguage)
        vRowTitle("DON_GIA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "DON_GIA", Commons.Modules.TypeLanguage)
        vRowTitle("THANH_TIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "THANH_TIEN", Commons.Modules.TypeLanguage)
        vRowTitle("TRUONG_BP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TRUONG_BP", Commons.Modules.TypeLanguage)
        vRowTitle("THU_KHO") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "THU_KHO", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_NHAN_HANG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "NGUOI_NHAN_HANG", Commons.Modules.TypeLanguage)

        vRowTitle("NGUOI_LAP") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "NGUOI_LAP", Commons.Modules.TypeLanguage)
        vRowTitle("TONG_CONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TONG_CONG", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_DX") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "NGUOI_DX", Commons.Modules.TypeLanguage)
        vRowTitle("NGUOI_NHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "NGUOI_NHAN", Commons.Modules.TypeLanguage)
        vRowTitle("TEN_MAY") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TEN_MAY", Commons.Modules.TypeLanguage)


        vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TMP1", Commons.Modules.TypeLanguage)
        vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TMP2", Commons.Modules.TypeLanguage)
        vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TMP3", Commons.Modules.TypeLanguage)
        vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TMP4", Commons.Modules.TypeLanguage)
        vRowTitle("TMP5") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptXUAT_KHO_VAT_TU_ADC", "TMP5", Commons.Modules.TypeLanguage)

        vtbTitle.Columns(26).ColumnName = "TMP1"
        vtbTitle.Columns(27).ColumnName = "TMP2"
        vtbTitle.Columns(28).ColumnName = "TMP3"
        vtbTitle.Columns(29).ColumnName = "TMP4"
        vtbTitle.Columns(30).ColumnName = "TMP5"

        vtbTitle.Rows.Add(vRowTitle)
        Return vtbTitle
    End Function

#End Region



    Private Sub BtnIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIN.Click
        If txtMS_DH_XUAT.Text = "" Then Exit Sub
#Region "In ADC"
        If Commons.Modules.sPrivate.ToUpper = "ADC" Then
            Me.Cursor = Cursors.WaitCursor
            InADC()
            Me.Cursor = Cursors.Default
            GoTo 1
        End If
#End Region
#Region "In SHISEIDO"
        If Commons.Modules.sPrivate.ToUpper = "SHISEIDO" Then
            Me.Cursor = Cursors.WaitCursor
            InSHISEIDO(0)
            Me.Cursor = Cursors.Default
            GoTo 1
        End If
#End Region
#Region "In VINHHOAN"
        If Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then
            Me.Cursor = Cursors.WaitCursor
            InPhieuXuatKhoVINHHOAN()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
#End Region

        Me.Cursor = Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        Dim str As String = ""
        Commons.Modules.ObjSystems.XoaTable("rptPHIEU_XUAT_KHO_VAT_TU")
        If Commons.Modules.sPrivate.ToUpper = "ACECOOK" Then
            If txtSLe.Text = "" Then txtSLe.Text = 2
            GoTo ACE
        Else
            ' tao bang tam rptPHIEU_XUAT_KHO_VAT_TU in report 
            If Commons.Modules.sPrivate.ToUpper = "DOFICO" Then
#Region "Dofico"
                str = " CREATE TABLE DBO.rptPHIEU_XUAT_KHO_VAT_TU (SO_PHIEU_XN NVARCHAR(50),TEN_CONG_TY NVARCHAR(250),SO_CHUNG_TU NVARCHAR(255), " &
                    " DANG_XUAT NVARCHAR(250),NGAY DATETIME,GHI_CHU NVARCHAR(255),TEN_KHO NVARCHAR(255),DIA_CHI NVARCHAR(255),SO_LUONG_CTU FLOAT, " &
                    " QUY_CACH NVARCHAR(250),DVT NVARCHAR(10),VI_TRI NVARCHAR(255),SL_VT FLOAT, " &
                    " DON_GIA FLOAT, NGOAI_TE NVARCHAR(10),THANH_TIEN FLOAT, THANH_TIEN_USD FLOAT, MS_DH_NHAP_PT NVARCHAR(30),LY_DO_XUAT NVARCHAR(255), " &
                    " THU_KHO NVARCHAR(50),MS_PHIEU_BAO_TRI NVARCHAR(50),GHI_CHU_CT NVARCHAR (50),TEN_PT NVARCHAR(255),MS_PT NVARCHAR (50), " &
                    " TEN_BP_CHIU_PHI nvarchar(100) , NGUOI_LAP nvarchar(255),CAN_CU nvarchar(255),THU_KHO_KY nvarchar(255),MS_PT_NCC nvarchar(25),MS_PT_CTY nvarchar(25) ) " &
                    " INSERT INTO DBO.rptPHIEU_XUAT_KHO_VAT_TU " &
                    " SELECT     SO_PHIEU_XN, TEN_CONG_TY, SO_CHUNG_TU, DANG_XUAT, NGAY, GHI_CHU, TEN_KHO, DIA_CHI, SO_LUONG_CTU, QUY_CACH, DVT, VI_TRI, SUM(SL_VT) AS SL_VT, 0 AS DON_GIA,  " &
                    " 0 AS NGOAI_TE, 0 AS THANH_TIEN, 0 AS THANH_TIEN_USD, '' AS MS_DH_NHAP_PT, LY_DO_XUAT, THU_KHO, MS_PHIEU_BAO_TRI, GHI_CHU_CT, TEN_PT, MS_PT, TEN_TO, NGUOI_LAP,  " &
                    " CAN_CU, THU_KHO_KY, MS_PT_NCC, MS_PT_CTY " &
                    " FROM         (SELECT DISTINCT dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN, " &
                    " (SELECT     TEN_CONG_TY " &
                    " FROM          dbo.KHACH_HANG " &
                    " WHERE      (MS_KH = dbo.IC_DON_HANG_XUAT.NGUOI_NHAN) " &
                    " UNION " &
                    " SELECT     HO + ' ' + TEN AS HO_TEN " &
                    " FROM         dbo.CONG_NHAN " &
                    " WHERE     (MS_CONG_NHAN = dbo.IC_DON_HANG_XUAT.NGUOI_NHAN)) AS TEN_CONG_TY, dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU,  " &
                    " (CASE 0 WHEN 0 THEN dbo.DANG_XUAT.DANG_XUAT_VIET WHEN 1 THEN dbo.DANG_XUAT.DANG_XUAT_ANH END) AS DANG_XUAT, dbo.IC_DON_HANG_XUAT.NGAY,  " &
                    " dbo.IC_DON_HANG_XUAT.GHI_CHU, dbo.IC_KHO.TEN_KHO, dbo.IC_KHO.DIA_CHI, dbo.IC_DON_HANG_XUAT_VAT_TU.SO_LUONG_CTU, dbo.IC_PHU_TUNG.QUY_CACH,  " &
                    " (CASE 0 WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 END) AS DVT, " &
                    " (SELECT     VTK.TEN_VI_TRI " &
                    " FROM          dbo.VI_TRI_KHO AS VTK INNER JOIN " &
                    "                        dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET AS DHXVTCT ON VTK.MS_VI_TRI = DHXVTCT.MS_VI_TRI " &
                    " WHERE      (DHXVTCT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "') AND (DHXVTCT.MS_DH_NHAP_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT) AND  " &
                    "                        (DHXVTCT.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT) AND (DHXVTCT.MS_VI_TRI = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI) AND  " &
                    "                        (DHXVTCT.ID_XUAT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT)) AS VI_TRI, dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT,  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA, dbo.IC_DON_HANG_NHAP_VAT_TU.NGOAI_TE,  " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT * ISNULL(dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA, 0) * dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA AS THANH_TIEN,  " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT * ISNULL(dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA, 0) * dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA_USD AS THANH_TIEN_USD,  " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT, dbo.IC_DON_HANG_XUAT.LY_DO_XUAT, " &
                    " (SELECT     FULL_NAME " &
                    " FROM          dbo.USERS " &
                    " WHERE      (USERNAME = dbo.IC_DON_HANG_XUAT.THU_KHO)) AS THU_KHO, ISNULL(dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI, '') AS MS_PHIEU_BAO_TRI,  " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU.GHI_CHU AS GHI_CHU_CT, CASE WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL  " &
                    " THEN ' ' WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NOT NULL  " &
                    " THEN dbo.IC_PHU_TUNG.QUY_CACH WHEN dbo.IC_PHU_TUNG.TEN_PT IS NOT NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL  " &
                    " THEN dbo.IC_PHU_TUNG.TEN_PT ELSE dbo.IC_PHU_TUNG.TEN_PT + ' ' + dbo.IC_PHU_TUNG.QUY_CACH END AS TEN_PT, dbo.IC_PHU_TUNG.MS_PT, dbo.TO_PHONG_BAN.TEN_TO,  " &
                    " dbo.IC_DON_HANG_XUAT.NGUOI_LAP, dbo.IC_DON_HANG_XUAT.CAN_CU, dbo.IC_DON_HANG_XUAT.THU_KHO_KY, dbo.IC_PHU_TUNG.MS_PT_NCC,  " &
                    " dbo.IC_PHU_TUNG.MS_PT_CTY " &
                    " FROM          dbo.TO_PHONG_BAN RIGHT OUTER JOIN " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET INNER JOIN " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                    " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT ON  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_NHAP_VAT_TU.ID INNER JOIN " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET INNER JOIN " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU ON dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT AND  " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT INNER JOIN " &
                    " dbo.IC_DON_HANG_XUAT ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT INNER JOIN " &
                    " dbo.IC_KHO ON dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " &
                    " dbo.IC_PHU_TUNG ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " &
                    " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT INNER JOIN " &
                    " dbo.DANG_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT ON  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT LEFT OUTER JOIN " &
                    " dbo.CONG_NHAN AS CONG_NHAN_1 ON dbo.IC_DON_HANG_XUAT.NGUOI_NHAN = CONG_NHAN_1.MS_CONG_NHAN LEFT OUTER JOIN " &
                    " dbo.[TO] ON dbo.[TO].MS_TO1 = CONG_NHAN_1.MS_TO ON dbo.TO_PHONG_BAN.MS_TO = dbo.[TO].MS_TO " &
                    " WHERE      (dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "')) AS A " &
                    " GROUP BY SO_PHIEU_XN, TEN_CONG_TY, SO_CHUNG_TU, DANG_XUAT, NGAY, GHI_CHU, TEN_KHO, DIA_CHI, SO_LUONG_CTU, QUY_CACH, DVT, VI_TRI, LY_DO_XUAT, THU_KHO, MS_PHIEU_BAO_TRI,  " &
                    " GHI_CHU_CT, TEN_PT, MS_PT, TEN_TO, NGUOI_LAP, CAN_CU, THU_KHO_KY, MS_PT_NCC, MS_PT_CTY "
#End Region
            Else
#Region "Khong Dofico"
                str = " CREATE TABLE DBO.rptPHIEU_XUAT_KHO_VAT_TU (SO_PHIEU_XN NVARCHAR(50),TEN_CONG_TY NVARCHAR(250),SO_CHUNG_TU NVARCHAR(255), " &
                    " DANG_XUAT NVARCHAR(250),NGAY DATETIME,GHI_CHU NVARCHAR(255),TEN_KHO NVARCHAR(255),DIA_CHI NVARCHAR(255),SO_LUONG_CTU FLOAT, " &
                    " QUY_CACH NVARCHAR(250),DVT NVARCHAR(10),VI_TRI NVARCHAR(255),SL_VT FLOAT, " &
                    " DON_GIA FLOAT, NGOAI_TE NVARCHAR(10),THANH_TIEN FLOAT, THANH_TIEN_USD FLOAT, MS_DH_NHAP_PT NVARCHAR(30),LY_DO_XUAT NVARCHAR(255), " &
                    " THU_KHO NVARCHAR(50),MS_PHIEU_BAO_TRI NVARCHAR(50),GHI_CHU_CT NVARCHAR (50),TEN_PT NVARCHAR(255),MS_PT NVARCHAR (50), " &
                    " TEN_BP_CHIU_PHI nvarchar(100) , NGUOI_LAP nvarchar(255),CAN_CU nvarchar(255),THU_KHO_KY nvarchar(255),MS_PT_NCC nvarchar(25),MS_PT_CTY nvarchar(25) ) " &
                    " INSERT INTO DBO.rptPHIEU_XUAT_KHO_VAT_TU " &
                    " SELECT DISTINCT dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN,(SELECT TEN_CONG_TY FROM KHACH_HANG WHERE MS_KH = NGUOI_NHAN  " &
                    " UNION SELECT     HO + ' ' + TEN AS HO_TEN FROM CONG_NHAN  " &
                    " WHERE  MS_CONG_NHAN = NGUOI_NHAN) AS TEN_CONG_TY, dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU, " &
                    " (CASE " & Commons.Modules.TypeLanguage & "  WHEN 0 THEN dbo.DANG_XUAT.DANG_XUAT_VIET WHEN 1 THEN dbo.DANG_XUAT.DANG_XUAT_ANH END) AS TEN_DANG_XUAT, " &
                    " dbo.IC_DON_HANG_XUAT.NGAY, dbo.IC_DON_HANG_XUAT.GHI_CHU, dbo.IC_KHO.TEN_KHO ,dbo.IC_KHO.DIA_CHI , dbo.IC_DON_HANG_XUAT_VAT_TU.SO_LUONG_CTU, " &
                    " QUY_CACH, (CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 END) AS TEN, " &
                    " (SELECT     TEN_VI_TRI FROM   VI_TRI_KHO VTK, IC_DON_HANG_XUAT_VAT_TU_CHI_TIET DHXVTCT " &
                    " WHERE  VTK.MS_VI_TRI = DHXVTCT.MS_VI_TRI AND DHXVTCT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "' AND  " &
                    " DHXVTCT.MS_DH_NHAP_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND " &
                    " DHXVTCT.MS_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND  DHXVTCT.MS_VI_TRI = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI " &
                    " AND DHXVTCT.ID_XUAT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT), IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT, DON_GIA, NGOAI_TE, " &
                    " CASE N'" & Commons.Modules.sPrivate & "' WHEN 'GREENFEED' THEN ISNULL(TG_PB,0) ELSE IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT *  ISNULL(DON_GIA, 0) * TY_GIA END AS THANH_TIEN " &
                    " ,IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT * ISNULL(DON_GIA, 0) * TY_GIA_USD AS THANH_TIEN_USD , IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT,IC_DON_HANG_XUAT.LY_DO_XUAT," &
                    " (SELECT FULL_NAME FROM USERS WHERE USERNAME= IC_DON_HANG_XUAT.THU_KHO) AS THU_KHO, ISNULL(dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI,'') AS MS_PHIEU_BAO_TRI, " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU.GHI_CHU AS GHI_CHU_CT,'TEN_PT' = CASE WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL
                                     AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL
                                THEN ' '
                                WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL
                                     AND dbo.IC_PHU_TUNG.QUY_CACH IS NOT NULL
                                THEN dbo.IC_PHU_TUNG.QUY_CACH
                                WHEN dbo.IC_PHU_TUNG.TEN_PT IS NOT NULL
                                     AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL
                                THEN CASE ISNULL(IC_DON_HANG_XUAT_VAT_TU.TEN_PT_CT,'') WHEN '' THEN  dbo.IC_PHU_TUNG.TEN_PT ELSE IC_DON_HANG_XUAT_VAT_TU.TEN_PT_CT END
                                ELSE CASE ISNULL(IC_DON_HANG_XUAT_VAT_TU.TEN_PT_CT,'') WHEN '' THEN  dbo.IC_PHU_TUNG.TEN_PT ELSE IC_DON_HANG_XUAT_VAT_TU.TEN_PT_CT END+ ' '
                                     + dbo.IC_PHU_TUNG.QUY_CACH
                           END, CASE ISNULL(IC_DON_HANG_XUAT_VAT_TU.MS_PT_CT,'') WHEN '' THEN  dbo.IC_PHU_TUNG.MS_PT ELSE IC_DON_HANG_XUAT_VAT_TU.MS_PT_CT END AS MS_PT,  TEN_BP_CHIU_PHI , " &
                    " IC_DON_HANG_XUAT.NGUOI_LAP ,IC_DON_HANG_XUAT.CAN_CU ,IC_DON_HANG_XUAT.THU_KHO_KY,dbo.IC_PHU_TUNG.MS_PT_NCC, dbo.IC_PHU_TUNG.MS_PT_CTY " &
                    " FROM         dbo.TO_PHONG_BAN RIGHT OUTER JOIN " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET INNER JOIN " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                    " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT ON  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_NHAP_VAT_TU.ID INNER JOIN " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET INNER JOIN " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU ON  " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT AND  " &
                    " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT INNER JOIN " &
                    " dbo.IC_DON_HANG_XUAT ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT INNER JOIN " &
                    " dbo.IC_KHO ON dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " &
                    " dbo.IC_PHU_TUNG ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " &
                    " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT INNER JOIN " &
                    " dbo.DANG_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT ON  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI AND  " &
                    " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT LEFT OUTER JOIN " &
                    " dbo.CONG_NHAN AS CONG_NHAN_1 ON dbo.IC_DON_HANG_XUAT.NGUOI_NHAN = CONG_NHAN_1.MS_CONG_NHAN LEFT OUTER JOIN " &
                    " dbo.[TO] ON dbo.[TO].MS_TO1 = CONG_NHAN_1.MS_TO ON dbo.TO_PHONG_BAN.MS_TO = dbo.[TO].MS_TO LEFT OUTER JOIN " &
                    " dbo.BO_PHAN_CHIU_PHI ON dbo.IC_DON_HANG_XUAT.MS_BP_CHIU_PHI = dbo.BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI " &
                    " WHERE  IC_DON_HANG_XUAT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "'"
#End Region
            End If

        End If
        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)

#Region "In Vard"
        If Commons.Modules.sPrivate = "VARD" Then

            Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
            frmRepot.rptName = "rptXUAT_KHO_VAT_TU_VARD"
            Dim vtbData As New DataTable
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptPHIEU_XUAT_KHO_VAT_TU"))
            vtbData.TableName = "rptPHIEU_XUAT_KHO_VAT_TU"
            Dim vtbTitle As New DataTable
            CreateTitleReport()
            vtbTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTIEU_DE_NHAP_KHO_VAT_TU"))
            vtbTitle.TableName = "rptTIEU_DE_NHAP_KHO_VAT_TU"

            frmRepot.AddDataTableSource(vtbData)
            frmRepot.AddDataTableSource(vtbTitle)
            Commons.Modules.SQLString = "0Design"
            frmRepot.ShowDialog()
            Commons.Modules.SQLString = ""
            GoTo 1
        End If
#End Region

ACE:
        Dim query As String = "SELECT * FROM THONG_TIN_CHUNG"
        Dim tb1 As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)
        'Phieu xuat kho Bia Daclac
        Try
            Commons.Modules.SQLString = ""
#Region "GREENFEED"
            If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Then
                CreateTitleReportGRE()

                str = "SELECT * FROM rptPHIEU_XUAT_KHO_VAT_TU ORDER BY MS_PT , TEN_PT"
                dtPhieuXuat = New DataTable
                dtPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))

                Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
                frmRepot.rptName = "rptXUAT_KHO_VAT_TU_GRE"

                dtPhieuXuat.TableName = "rptPHIEU_XUAT_KHO_VAT_TU"
                frmRepot.AddDataTableSource(dtPhieuXuat)

                str = "SELECT * FROM rptTIEU_DE_NHAP_KHO_VAT_TU"
                dtPhieuXuat = New DataTable
                dtPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                dtPhieuXuat.TableName = "rptTIEU_DE_NHAP_KHO_VAT_TU"
                frmRepot.AddDataTableSource(dtPhieuXuat)

                Commons.Modules.SQLString = "0Design"
                frmRepot.ShowDialog()
                Commons.Modules.SQLString = ""
                GoTo 1
            End If
#End Region
#Region "BDL"
            If Commons.Modules.sPrivate.ToUpper = "BDL" Then
                CreateTitleReport_BDL()
                Commons.mdShowReport.ReportPreview("reports\rptXUAT_KHO_VAT_TU_BDL.rpt")
                Me.Cursor = Cursors.Default
                GoTo 1
            End If
#End Region
            'COLGATE
#Region "COLGATE"
            If Commons.Modules.sPrivate.ToUpper = "COLGATE" Then
                CreateTitleReport()
                Commons.mdShowReport.ReportPreview("reports\rptXUAT_KHO_VAT_TU_COLGATE.rpt")
                Me.Cursor = Cursors.Default
                GoTo 1
            End If
#End Region

#Region "NUTIFOOD"
            If Commons.Modules.sPrivate.ToUpper = "NUTIFOOD" Then
                Commons.Modules.SQLString = "NUTIFOOD"
                Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
                frmRepot.rptName = "rptXUAT_KHO_VAT_TU_NU"

                str = "SELECT * FROM rptPHIEU_XUAT_KHO_VAT_TU ORDER BY MS_PT , TEN_PT"
                dtPhieuXuat = New DataTable
                dtPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                dtPhieuXuat.TableName = "rptPHIEU_XUAT_KHO_VAT_TU"
                frmRepot.AddDataTableSource(dtPhieuXuat)

                CreateTitleReport()
                str = "SELECT * FROM rptTIEU_DE_NHAP_KHO_VAT_TU"
                dtPhieuXuat = New DataTable
                dtPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
                dtPhieuXuat.TableName = "rptTIEU_DE_NHAP_KHO_VAT_TU"
                frmRepot.AddDataTableSource(dtPhieuXuat)

                Commons.Modules.SQLString = "0Design"
                frmRepot.ShowDialog()
                Commons.Modules.SQLString = ""
                GoTo 1
            End If
#End Region

#Region "DOFICO"
            If Commons.Modules.sPrivate.ToUpper = "DOFICO" Then
                Commons.Modules.SQLString = "DOFICO"
                CreateTitleReport()
                Commons.mdShowReport.ReportPreview("reports\rptXUAT_KHO_VAT_TU_DFC.rpt")
                Me.Cursor = Cursors.Default
                GoTo 1
            End If

        Catch ex As Exception
        End Try
#End Region

        ' Phieu xuat kho VMPACK
#Region "VMPACK"
        Try
            Dim s As String = tb1.Rows(0)("PHIEU_XUAT_VTPT").ToString
            If s.Trim() = "rptXUAT_KHO_VAT_TU_VMPACK.rpt" Then
                CreateTitleReport()
                Commons.mdShowReport.ReportPreview("reports\rptXUAT_KHO_VAT_TU_VMPACK.rpt")
                Me.Cursor = Cursors.Default
                GoTo 1
            End If
        Catch ex As Exception
        End Try
#End Region

        'Phieu xuat kho Ban Chung va ACECOOK

        If Commons.Modules.sPrivate.ToUpper = "ACECOOK" Then
#Region "ACECOOK"
            str = " SELECT DISTINCT dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN, CASE DANG_XUAT.MS_DANG_XUAT WHEN 9 THEN (  " &
                        "  CASE ISNULL(M.KHO_DD,0) WHEN 0 THEN 	(SELECT TOP 1 TEN_KHO FROM IC_KHO A  WHERE A.MS_KHO = dbo.IC_DON_HANG_XUAT.MS_KHO_DEN)ELSE 	(SELECT T2.TEN_KHO FROM dbo.IC_KHO AS T1 INNER JOIN dbo.IC_KHO AS T2 ON T1.MS_KHO_CHINH = T2.MS_KHO WHERE (T1.MS_KHO = dbo.IC_DON_HANG_XUAT.MS_KHO_DEN)) END )  ELSE (SELECT TEN_CONG_TY FROM KHACH_HANG WHERE MS_KH = NGUOI_NHAN " &
                        " UNION SELECT     HO + ' ' + TEN AS HO_TEN FROM CONG_NHAN    WHERE  MS_CONG_NHAN = NGUOI_NHAN) END AS TEN_CONG_TY , " &
                        " CASE DANG_XUAT.MS_DANG_XUAT WHEN 9 THEN  dbo.IC_DON_HANG_XUAT.CAN_CU ELSE  dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU  END AS SO_CHUNG_TU , " &
                        " (CASE " & Commons.Modules.TypeLanguage & "  WHEN 0 THEN dbo.DANG_XUAT.DANG_XUAT_VIET WHEN 1 THEN dbo.DANG_XUAT.DANG_XUAT_ANH END) AS TEN_DANG_XUAT, " &
                        " dbo.IC_DON_HANG_XUAT.NGAY, dbo.IC_DON_HANG_XUAT.GHI_CHU, dbo.IC_KHO.TEN_KHO ,dbo.IC_KHO.DIA_CHI , dbo.IC_DON_HANG_XUAT_VAT_TU.SO_LUONG_CTU, " &
                        " QUY_CACH, (CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 END) AS TEN, " &
                        " (SELECT     TEN_VI_TRI FROM   VI_TRI_KHO VTK, IC_DON_HANG_XUAT_VAT_TU_CHI_TIET DHXVTCT " &
                        " WHERE  VTK.MS_VI_TRI = DHXVTCT.MS_VI_TRI AND DHXVTCT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "' AND  " &
                        " DHXVTCT.MS_DH_NHAP_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND " &
                        " DHXVTCT.MS_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND  DHXVTCT.MS_VI_TRI = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI " &
                        " AND DHXVTCT.ID_XUAT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT), IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT, " &
                        " ISNULL(DON_GIA, 0)* TY_GIA AS DON_GIA, NGOAI_TE, IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT * ISNULL(DON_GIA, 0)* TY_GIA AS THANH_TIEN " &
                        " ,IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT * ISNULL(DON_GIA, 0)* TY_GIA_USD AS THANH_TIEN_USD , IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT,IC_DON_HANG_XUAT.LY_DO_XUAT," &
                        " (SELECT FULL_NAME FROM USERS WHERE USERNAME= IC_DON_HANG_XUAT.THU_KHO) AS THU_KHO,dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI, " &
                        " dbo.IC_DON_HANG_XUAT_VAT_TU.GHI_CHU AS GHI_CHU_CT,'TEN_PT' = CASE WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL THEN ' ' " &
                        " WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NOT NULL THEN dbo.IC_PHU_TUNG.QUY_CACH " &
                        " WHEN dbo.IC_PHU_TUNG.TEN_PT IS NOT NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL THEN dbo.IC_PHU_TUNG.TEN_PT " &
                        " ELSE dbo.IC_PHU_TUNG.TEN_PT END, dbo.IC_PHU_TUNG.MS_PT, " &
                        " (SELECT TOP 1 TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI WHERE MS_BP_CHIU_PHI =  (SELECT MS_BP_CHIU_PHI FROM IC_DON_HANG_XUAT WHERE MS_DH_XUAT_PT = '" + txtMS_DH_XUAT.Text + "')) AS TEN_BP_CHIU_PHI , " &
                        " IC_DON_HANG_XUAT.NGUOI_LAP ,IC_DON_HANG_XUAT.CAN_CU ,IC_DON_HANG_XUAT.THU_KHO_KY, " &
                        " dbo.IC_PHU_TUNG.MS_PT_NCC, dbo.IC_PHU_TUNG.MS_PT_CTY,IC_DON_HANG_XUAT.MS_DH_XUAT_PT, " & txtSLe.Text &
                        " FROM         dbo.TO_PHONG_BAN RIGHT OUTER JOIN " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
                        " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT ON  " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_NHAP_VAT_TU.ID INNER JOIN " &
                        " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET INNER JOIN " &
                        " dbo.IC_DON_HANG_XUAT_VAT_TU ON  " &
                        " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT AND  " &
                        " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT INNER JOIN " &
                        " dbo.IC_DON_HANG_XUAT ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT INNER JOIN " &
                        " dbo.IC_KHO ON dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " &
                        " dbo.IC_PHU_TUNG ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " &
                        " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT INNER JOIN " &
                        " dbo.DANG_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT ON  " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND  " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI AND  " &
                        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT LEFT OUTER JOIN " &
                        " dbo.CONG_NHAN AS CONG_NHAN_1 ON dbo.IC_DON_HANG_XUAT.NGUOI_NHAN = CONG_NHAN_1.MS_CONG_NHAN LEFT OUTER JOIN " &
                        " dbo.[TO] ON dbo.[TO].MS_TO1 = CONG_NHAN_1.MS_TO ON dbo.TO_PHONG_BAN.MS_TO = dbo.[TO].MS_TO " &
                        " LEFT JOIN IC_KHO M ON IC_DON_HANG_XUAT.MS_KHO_DEN = M.MS_KHO " &
                        " WHERE  IC_DON_HANG_XUAT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "'"

            Dim vtbData As New DataTable
            Dim vtbTitle As New DataTable
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            CreateTitleReport()
            vtbTitle.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTIEU_DE_NHAP_KHO_VAT_TU"))

            Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
            frmRepot.rptName = "rptXUAT_KHO_VAT_TU_ACE"
            vtbData.TableName = "rptPHIEU_XUAT_KHO_VAT_TU"
            vtbTitle.TableName = "rptTIEU_DE_NHAP_KHO_VAT_TU"

            frmRepot.AddDataTableSource(vtbData)
            frmRepot.AddDataTableSource(vtbTitle)
            Commons.Modules.SQLString = "0Design"
            frmRepot.ShowDialog()
            Commons.Modules.SQLString = ""
#End Region
        Else
#Region "Ban Chung"
            'in kieu cu ban chung
            'Commons.mdShowReport.ReportPreview("reports\rptXUAT_KHO_VAT_TU.rpt")
            ' in xml
            Dim frmRepot As frmShowXMLReport = New frmShowXMLReport()
            If Commons.Modules.sPrivate = "TRUNGNGUYEN" Then
                frmRepot.rptName = "rptXUAT_KHO_VAT_TU_TN"
            Else
                frmRepot.rptName = "rptXUAT_KHO_VAT_TU"
            End If

            str = "SELECT * FROM rptPHIEU_XUAT_KHO_VAT_TU ORDER BY MS_PT , TEN_PT"
            dtPhieuXuat = New DataTable
            dtPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            dtPhieuXuat.TableName = "rptPHIEU_XUAT_KHO_VAT_TU"
            frmRepot.AddDataTableSource(dtPhieuXuat)

            CreateTitleReport()
            str = "SELECT * FROM rptTIEU_DE_NHAP_KHO_VAT_TU"
            dtPhieuXuat = New DataTable
            dtPhieuXuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            dtPhieuXuat.TableName = "rptTIEU_DE_NHAP_KHO_VAT_TU"
            frmRepot.AddDataTableSource(dtPhieuXuat)

            Commons.Modules.SQLString = "0Design"
            frmRepot.ShowDialog()
            Commons.Modules.SQLString = ""
            GoTo 1
#End Region


        End If
1:
        Commons.Modules.ObjSystems.XoaTable("rptPHIEU_XUAT_KHO_VAT_TU")
        Commons.Modules.ObjSystems.XoaTable("rptTIEU_DE_NHAP_KHO_VAT_TU")
        Me.Cursor = Cursors.Default

    End Sub



    Private Sub btnInDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInDN.Click
        'Commons.Modules.sPrivate.ToUpper = "VINHHOAN"
        If txtMS_DH_XUAT.Text = "" Then Exit Sub

        If Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then
            Me.Cursor = Cursors.WaitCursor
            InPhieuDeNghiXuatKhoVINHHOAN()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        Me.Cursor = Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        Dim str As String = ""
        Commons.Modules.ObjSystems.XoaTable("rptPHIEU_XUAT_KHO_VAT_TU")

        str = " CREATE TABLE DBO.rptPHIEU_XUAT_KHO_VAT_TU (SO_PHIEU_XN NVARCHAR(50),TEN_CONG_TY NVARCHAR(250),SO_CHUNG_TU NVARCHAR(255), " &
        " DANG_XUAT NVARCHAR(250),NGAY DATETIME,GHI_CHU NVARCHAR(255),TEN_KHO NVARCHAR(255),DIA_CHI NVARCHAR(255),SO_LUONG_CTU FLOAT, " &
        " QUY_CACH NVARCHAR(250),DVT NVARCHAR(10),VI_TRI NVARCHAR(255),SL_VT FLOAT, " &
        " DON_GIA FLOAT, NGOAI_TE NVARCHAR(10),THANH_TIEN FLOAT, THANH_TIEN_USD FLOAT, MS_DH_NHAP_PT NVARCHAR(30),LY_DO_XUAT NVARCHAR(255), " &
        " THU_KHO NVARCHAR(50),MS_PHIEU_BAO_TRI NVARCHAR(50),GHI_CHU_CT NVARCHAR (50),TEN_PT NVARCHAR(255),MS_PT NVARCHAR (50), " &
        " TEN_BP_CHIU_PHI nvarchar(100) , NGUOI_LAP nvarchar(255),CAN_CU nvarchar(255),THU_KHO_KY nvarchar(255),MS_PT_NCC nvarchar(25),MS_PT_CTY nvarchar(25) ) " &
        " INSERT INTO DBO.rptPHIEU_XUAT_KHO_VAT_TU " &
        " SELECT DISTINCT dbo.IC_DON_HANG_XUAT.SO_PHIEU_XN,(SELECT TEN_CONG_TY FROM KHACH_HANG WHERE MS_KH = NGUOI_NHAN  " &
        " UNION SELECT     HO + ' ' + TEN AS HO_TEN FROM CONG_NHAN  " &
        " WHERE  MS_CONG_NHAN = NGUOI_NHAN) AS TEN_CONG_TY, dbo.IC_DON_HANG_XUAT.SO_CHUNG_TU, " &
        " (CASE " & Commons.Modules.TypeLanguage & "  WHEN 0 THEN dbo.DANG_XUAT.DANG_XUAT_VIET WHEN 1 THEN dbo.DANG_XUAT.DANG_XUAT_ANH END) AS TEN_DANG_XUAT, " &
        " dbo.IC_DON_HANG_XUAT.NGAY, dbo.IC_DON_HANG_XUAT.GHI_CHU, dbo.IC_KHO.TEN_KHO ,dbo.IC_KHO.DIA_CHI , dbo.IC_DON_HANG_XUAT_VAT_TU.SO_LUONG_CTU, " &
        " QUY_CACH, (CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 END) AS TEN, " &
        " (SELECT     TEN_VI_TRI FROM   VI_TRI_KHO VTK, IC_DON_HANG_XUAT_VAT_TU_CHI_TIET DHXVTCT " &
        " WHERE  VTK.MS_VI_TRI = DHXVTCT.MS_VI_TRI AND DHXVTCT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "' AND  " &
        " DHXVTCT.MS_DH_NHAP_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND " &
        " DHXVTCT.MS_PT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND  DHXVTCT.MS_VI_TRI = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI " &
        " AND DHXVTCT.ID_XUAT = IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT), IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT, DON_GIA, NGOAI_TE, IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT * ISNULL(DON_GIA, 0)* TY_GIA AS THANH_TIEN " &
        " ,IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.SL_VT * ISNULL(DON_GIA, 0)* TY_GIA_USD AS THANH_TIEN_USD , IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT,IC_DON_HANG_XUAT.LY_DO_XUAT," &
        " (SELECT FULL_NAME FROM USERS WHERE USERNAME= IC_DON_HANG_XUAT.THU_KHO) AS THU_KHO, ISNULL(dbo.IC_DON_HANG_XUAT.MS_PHIEU_BAO_TRI,'') AS MS_PHIEU_BAO_TRI, " &
        " dbo.IC_DON_HANG_XUAT_VAT_TU.GHI_CHU AS GHI_CHU_CT,'TEN_PT' = CASE WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL THEN ' ' " &
        " WHEN dbo.IC_PHU_TUNG.TEN_PT IS NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NOT NULL THEN dbo.IC_PHU_TUNG.QUY_CACH " &
        " WHEN dbo.IC_PHU_TUNG.TEN_PT IS NOT NULL AND dbo.IC_PHU_TUNG.QUY_CACH IS NULL THEN dbo.IC_PHU_TUNG.TEN_PT " &
        " ELSE dbo.IC_PHU_TUNG.TEN_PT + ' ' +  dbo.IC_PHU_TUNG.QUY_CACH END, dbo.IC_PHU_TUNG.MS_PT,dbo.TO_PHONG_BAN.TEN_TO AS TEN_BP_CHIU_PHI , " &
        " IC_DON_HANG_XUAT.NGUOI_LAP ,IC_DON_HANG_XUAT.CAN_CU ,IC_DON_HANG_XUAT.THU_KHO_KY,dbo.IC_PHU_TUNG.MS_PT_NCC, dbo.IC_PHU_TUNG.MS_PT_CTY " &
        " FROM         dbo.TO_PHONG_BAN RIGHT OUTER JOIN " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET INNER JOIN " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU INNER JOIN " &
        " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT ON  " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND  " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_NHAP_VAT_TU.ID INNER JOIN " &
        " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET INNER JOIN " &
        " dbo.IC_DON_HANG_XUAT_VAT_TU ON  " &
        " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT AND  " &
        " dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT INNER JOIN " &
        " dbo.IC_DON_HANG_XUAT ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT INNER JOIN " &
        " dbo.IC_KHO ON dbo.IC_DON_HANG_XUAT.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " &
        " dbo.IC_PHU_TUNG ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " &
        " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT INNER JOIN " &
        " dbo.DANG_XUAT ON dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT = dbo.DANG_XUAT.MS_DANG_XUAT ON  " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_DH_NHAP_PT AND  " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_PT AND  " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.MS_VI_TRI AND  " &
        " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.ID = dbo.IC_DON_HANG_XUAT_VAT_TU_CHI_TIET.ID_XUAT LEFT OUTER JOIN " &
        " dbo.CONG_NHAN AS CONG_NHAN_1 ON dbo.IC_DON_HANG_XUAT.NGUOI_NHAN = CONG_NHAN_1.MS_CONG_NHAN LEFT OUTER JOIN " &
        " dbo.[TO] ON dbo.[TO].MS_TO1 = CONG_NHAN_1.MS_TO ON dbo.TO_PHONG_BAN.MS_TO = dbo.[TO].MS_TO " &
        " WHERE  IC_DON_HANG_XUAT.MS_DH_XUAT_PT = '" & txtMS_DH_XUAT.Text & "'"

        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim query As String = "SELECT * FROM THONG_TIN_CHUNG"
        Dim tb1 As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)


        Try

            Commons.Modules.SQLString = ""
            If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Then
                CreateTitleReportGRE_DN()
                Commons.mdShowReport.ReportPreview("reports\rptDN_XUAT_KHO_VAT_TU_GRE.rpt")
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
        Try
            Commons.Modules.ObjSystems.XoaTable("rptPHIEU_XUAT_KHO_VAT_TU")
            Commons.Modules.ObjSystems.XoaTable("rptTIEU_DE_NHAP_KHO_VAT_TU")
        Catch ex As Exception
        End Try



    End Sub


    Private Sub cboDANG_XUAT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Load_Nguoi_Nhap()
        If Not BtnTHEM.Visible Then
            If cboDANG_XUAT.SelectedValue = 1 Then
                cboPhieuBaoTri.Enabled = True
                NONNbtnTimPBT.Enabled = True
                If cboPhieuBaoTri.Items.Count > 0 Then cboPhieuBaoTri.SelectedIndex = 0
            Else
                cboPhieuBaoTri.Enabled = False
                NONNbtnTimPBT.Enabled = False
                cboPhieuBaoTri.SelectedValue = -1
            End If
        Else
            cboPhieuBaoTri.Enabled = False
            NONNbtnTimPBT.Enabled = False
        End If
    End Sub
    Sub LoadViTriXuat()

        Dim Flag As Boolean = True
        Try
            MS_PT = Me.grvXuatkhoPTCT.GetFocusedRowCellValue("MS_PT")
            'ID_XUAT = Convert.ToDouble(Me.grdXuatkhoPTCT.Rows(intRowPT).Cells("ID_XUAT"))
        Catch ex As Exception
        End Try

        If lstCTVTPT.Count > 0 Then
            Dim lst As List(Of CHI_TIET_VAT_TU_XUAT_Info) = lstCTVTPT.Where(Function(x) x.MS_PT.Equals(MS_PT)).ToList()
            Me.grdSLtheoViTri.DataSource = lst
        Else
            Dim lstDHXVTCT As List(Of CHI_TIET_VAT_TU_XUAT_Info) =
              Me.objDonHangXuatController.Load_Don_Hang_Xuat_Vat_Tu_Chi_Tiet(
                  Integer.Parse(Me.cboKHO.SelectedValue.ToString), Me.txtMS_DH_XUAT.Text, MS_PT)
            Me.grdSLtheoViTri.DataSource = lstDHXVTCT
        End If

    End Sub
    Dim intRowCT As Integer = 0, intRowPT As Integer = 0
    Private Sub txtGIO_NHAP_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGIO_NHAP.Leave
        Try
            Dim temp As String = Me.txtGIO_NHAP.Text
            For i As Integer = 0 To temp.Length - 1
                If i <> 2 Then
                    If Microsoft.VisualBasic.Asc(temp.Chars(i)) < 48 Or Microsoft.VisualBasic.Asc(temp.Chars(i)) > 57 Then
                        Me.txtGIO_NHAP.Focus()
                        Return

                    End If
                End If
            Next
            If Integer.Parse(temp.Substring(0, 2)) > 23 Then
                Me.txtGIO_NHAP.Focus()
                Return
            End If
            If Integer.Parse(temp.Substring(3, 2)) > 59 Then
                Me.txtGIO_NHAP.Focus()
                Return
            End If
        Catch ex As Exception
            Me.txtGIO_NHAP.Focus()
        End Try
    End Sub

#Region "Sub Class"
    Class NOINHAN_Info
        Dim _ma As String = ""
        Dim _ten As String = ""
        Public Sub New()

        End Sub
        Public Property MA() As String
            Get
                Return _ma
            End Get
            Set(ByVal value As String)
                _ma = value
            End Set
        End Property
        Public Property TEN() As String
            Get
                Return _ten
            End Get
            Set(ByVal value As String)
                _ten = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return _ten
        End Function
    End Class
#End Region
    Private intRowPX As Integer = 0

    Private Sub chkLOCK_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLOCK.CheckedChanged
        If Me.chkLOCK.Checked Then
            btnLockPhieuXuat.Enabled = False
            btnSUA.Enabled = False
            btnXOA.Enabled = False
        Else
            btnLockPhieuXuat.Enabled = True
            btnSUA.Enabled = True
            btnXOA.Enabled = True
        End If
    End Sub

    Private Sub txtSO_PHIEU_XUAT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtSO_PHIEU_XUAT.Validating
        If Commons.Modules.SQLString = "0LOADTAB" Then Exit Sub
        If Me.btnKHONG_GHI.Focused Then Exit Sub

        Me.txtSO_PHIEU_XUAT.Text = Trim(Me.txtSO_PHIEU_XUAT.Text)

        If Me.txtSO_PHIEU_XUAT.Text <> "" Then
            For i As Integer = 0 To Me.txtSO_PHIEU_XUAT.Text.Length - 1
                If Me.txtSO_PHIEU_XUAT.Text.Chars(i).ToString = " " Then
                    ' Số phiếu xuất phải không có khoảng trắng ! Vui lòng nhập lại !
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_PHIEU_XUAT_SAI", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSO_PHIEU_XUAT.Focus()
                    Me.txtSO_PHIEU_XUAT.SelectAll()
                    e.Cancel = True
                End If
            Next
        End If
    End Sub

    Private Sub cboDVNhan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboNguoiNhan.Validating, cboDVNhan.Validating

        If btnKHONG_GHI.Focused Then
            Exit Sub
        Else
            If cboDANG_XUAT.SelectedValue <> 9 Then Exit Sub
            If cboDVNhan.EditValue Is Nothing Then
                'e.Cancel = True
            End If
        End If
    End Sub


    Private Sub cboPhieuBaoTri_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPhieuBaoTri.Enter
        cboPhieuBaoTri.StoreName = "QL_LIST_PHIEU_BAO_TRI"
    End Sub

    Private Sub cboDANG_XUAT_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDANG_XUAT.SelectedValueChanged
        Try
            If Commons.Modules.SQLString = "0Load" Then Exit Sub
            Load_Nguoi_Nhap()
            If cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10 Then
                Me.lblDVNhan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                Me.lblDVNhan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If

            If Not BtnTHEM.Visible Then

                If cboDANG_XUAT.SelectedValue = 4 Then
                    cbxCostCenter.Enabled = True
                    LoadCbChiPhi()
                Else
                    cbxCostCenter.Enabled = False
                    LoadCbChiPhi()
                End If

                If cboDANG_XUAT.SelectedValue = 1 Then
                    cboPhieuBaoTri.Enabled = True
                    NONNbtnTimPBT.Enabled = True
                    cbxCostCenter.Enabled = True
                    If cboPhieuBaoTri.Items.Count > 0 Then cboPhieuBaoTri.SelectedIndex = 0
                Else
                    cboPhieuBaoTri.Enabled = False
                    NONNbtnTimPBT.Enabled = False
                    cboPhieuBaoTri.SelectedValue = -1
                End If
                If cboDANG_XUAT.SelectedValue = 9 Or cboDANG_XUAT.SelectedValue = 10 Then
                    cboKHO_CHINH.Enabled = True
                    cboDVNhan.Enabled = True
                Else
                    cboKHO_CHINH.Enabled = False
                    cboDVNhan.Enabled = False
                End If
                If cboDANG_XUAT.SelectedValue = 8 Then
                    cboMay.Enabled = True
                    NONNbtnTimMay.Enabled = True
                    LoadCbChiPhi()
                    If cboMay.Items.Count > 0 Then cboMay.SelectedIndex = 0 Else cboMay.SelectedIndex = -1
                Else
                    cboMay.Enabled = False
                    NONNbtnTimMay.Enabled = False
                    cboMay.SelectedIndex = -1
                End If
                LoadXuatKTDefault()
            Else
                cboPhieuBaoTri.Enabled = False
                NONNbtnTimPBT.Enabled = False
                cboMay.Enabled = False
                NONNbtnTimMay.Enabled = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadXuatKTDefault()
        Dim sSql As String
        Try
            sSql = "SELECT TOP 1 MS_LY_DO_XUAT_KT FROM LY_DO_XUAT_KT WHERE MS_DANG_XUAT = " & cboDANG_XUAT.SelectedValue.ToString()
            Dim dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count > 0 Then
                cboLDXKT.SelectedValue = dtTmp.Rows(0)(0).ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnXoaPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaPhieu.Click
        If Me.txtMS_DH_XUAT.Text <> "" Then
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME='" & Commons.Modules.UserName & "' AND STT=10")
            Dim bQuyen As Boolean = False
            While objReader.Read
                bQuyen = True
            End While
            objReader.Close()
            If bQuyen Then
                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgXoaDHXuat", Commons.Modules.TypeLanguage) + " " + Me.txtMS_DH_XUAT.Text, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If Me.cboKHO.SelectedValue IsNot Nothing Then
                        Me.objDonHangXuatController.DELETE_DON_HANG_XUAT(Me.txtMS_DH_XUAT.Text, Integer.Parse(Me.cboKHO.SelectedValue.ToString))
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_HANG_XUAT_DA_DUOC_XOA", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtMS_DH_XUAT.Text = ""
                        Me.txtGHI_CHU.Text = ""
                        Me.txtSO_CHUNG_TU.Text = ""
                        Me.txtCCu.Text = ""
                        Me.txtNLap.Text = ""
                        Me.txtTKho.Text = ""

                        Me.txtSO_PHIEU_XUAT.Text = ""
                        Me.txtGIO_NHAP.Text = ""

                        Me.btnLockPhieuXuat.Enabled = True
                        '    Me.tabXuatkhoPT.TabPages.Insert(0, Me.tabDanhSachPT)

                        Me.Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
                        Me.SetVisibleButton(True)
                        RemoveHandler txtSO_PHIEU_XUAT.Validating, AddressOf Me.txtSO_PHIEU_XUAT_Validating
                        EnableControl(False)
                        If chkIsLock.Checked = True Then
                            BtnTHEM.Enabled = False
                        End If
                        Panel1.Visible = False
                        Panel2.Visible = True
                    End If
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnTroVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTroVe.Click
        Panel1.Visible = False
        Panel4.Visible = True
        ' Me.tabXuatkhoPT.TabPages.Insert(0, Me.tabDanhSachPT)
    End Sub

    Private Sub btnXoaVTPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaVTPT.Click
        If Me.txtMS_DH_XUAT.Text <> "" Then
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME='" & Commons.Modules.UserName & "' AND STT=10")
            Dim bQuyen As Boolean = False
            While objReader.Read
                bQuyen = True
            End While
            objReader.Close()
            If bQuyen Then
                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BanMuonXoaPTNayKo", Commons.Modules.TypeLanguage) + " " + Me.txtMS_DH_XUAT.Text, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim vMsPT As String = grvXuatkhoPTCT.GetFocusedRowCellValue("MS_PT")
                    Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
                    objConnection.Open()
                    Dim objTrans As SqlTransaction = objConnection.BeginTransaction
                    Try
                        'Lay thong tin trong IC_DON_HANG_XUAT_CHI_TIET 
                        Dim vDHXVT_CTIET As List(Of IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info) = QLBusinessDataController.FillCollection(Of IC_DON_HANG_XUAT_VAT_TU_CHI_TIET_Info)(SqlHelper.ExecuteReader(objTrans, "H_GET_VT_PT_CHI_TIET_BY_MS_PT_AND_DH_XUAT", Me.txtMS_DH_XUAT.Text, vMsPT))

                        For i As Integer = 0 To vDHXVT_CTIET.Count - 1
                            Dim objVTKHOVATTU As New VI_TRI_KHO_VAT_TU_Info
                            objVTKHOVATTU.MS_DH_NHAP_PT = vDHXVT_CTIET.Item(i).MS_DH_NHAP_PT
                            objVTKHOVATTU.MS_PT = vDHXVT_CTIET.Item(i).MS_PT
                            objVTKHOVATTU.MS_VI_TRI = vDHXVT_CTIET.Item(i).MS_VI_TRI
                            objVTKHOVATTU.ID = vDHXVT_CTIET.Item(i).ID_XUAT
                            objVTKHOVATTU.SL_VT = Double.Parse(vDHXVT_CTIET.Item(i).SL_VT)
                            objVTKHOVATTU.MS_KHO = Integer.Parse(Me.cboKHO.SelectedValue.ToString)

                            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(objTrans, "QL_LOAD_VI_TRI_KHO_VAT_TU",
                                    objVTKHOVATTU.MS_KHO, objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI,
                                    objVTKHOVATTU.MS_DH_NHAP_PT, objVTKHOVATTU.ID)
                            Dim tempFlag As Boolean = True
                            While dtReader.Read
                                tempFlag = False
                                objVTKHOVATTU.SL_VT = objVTKHOVATTU.SL_VT + Double.Parse(dtReader.Item("SL_VT").ToString)
                                Exit While
                            End While
                            dtReader.Close()
                            If tempFlag Then
                                SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_VI_TRI_KHO_VAT_TU",
                                    objVTKHOVATTU.MS_KHO, objVTKHOVATTU.MS_PT, objVTKHOVATTU.MS_VI_TRI,
                                    objVTKHOVATTU.MS_DH_NHAP_PT, objVTKHOVATTU.SL_VT, objVTKHOVATTU.ID)
                            Else
                                SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU",
                                    objVTKHOVATTU.MS_KHO, objVTKHOVATTU.MS_PT,
                                    objVTKHOVATTU.MS_VI_TRI, objVTKHOVATTU.MS_DH_NHAP_PT,
                                    objVTKHOVATTU.SL_VT, objVTKHOVATTU.ID)
                            End If
                        Next
                        SqlHelper.ExecuteNonQuery(objTrans, "H_DELETE_VT_PT_DON_HANG_XUAT", Me.txtMS_DH_XUAT.Text, vMsPT)
                        objTrans.Commit()
                    Catch ex As Exception
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        objTrans.Rollback()
                        Exit Sub
                    Finally
                        objConnection.Close()
                    End Try
                    LoadVTPT()
                    If grvXuatkhoPTCT.RowCount = 0 Then
                        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DaHetVTPT_coXoaDHXko", Commons.Modules.TypeLanguage) + " " + Me.txtMS_DH_XUAT.Text, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            If Me.cboKHO.SelectedValue IsNot Nothing Then
                                Me.objDonHangXuatController.DELETE_DON_HANG_XUAT(Me.txtMS_DH_XUAT.Text, Integer.Parse(Me.cboKHO.SelectedValue.ToString))
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_HANG_XUAT_DA_DUOC_XOA", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.txtMS_DH_XUAT.Text = ""
                                Me.txtGHI_CHU.Text = ""
                                Me.txtSO_CHUNG_TU.Text = ""
                                Me.txtCCu.Text = ""
                                Me.txtNLap.Text = ""
                                Me.txtTKho.Text = ""

                                Me.txtSO_PHIEU_XUAT.Text = ""
                                Me.txtGIO_NHAP.Text = ""

                                Me.btnLockPhieuXuat.Enabled = True
                                '            Me.tabXuatkhoPT.TabPages.Insert(0, Me.tabDanhSachPT)

                                'cboStockTabDS.SelectedValue = intMs_To
                                Me.Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
                                Me.SetVisibleButton(True)
                                RemoveHandler txtSO_PHIEU_XUAT.Validating, AddressOf Me.txtSO_PHIEU_XUAT_Validating
                                EnableControl(False)

                                If chkIsLock.Checked = True Then
                                    BtnTHEM.Enabled = False
                                End If

                                Panel1.Visible = False
                                Panel4.Visible = True

                                'Me.tabXuatkhoPT.SelectedTab.Name = tabDanhSachPT.Name
                            End If
                        End If
                    End If
                End If
            Else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub



    Sub EnableButton()
        If chkIsLock.Checked = True Then
            BtnTHEM.Enabled = False
            btnSUA.Enabled = False
            btnXOA.Enabled = False
            btnLockPhieuXuat.Enabled = False

            If grvDanhsachXuatkhoPT.RowCount > 0 Then
                BtnIN.Enabled = True
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = True Else btnInDN.Visible = False
            Else
                BtnIN.Enabled = False
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = False Else btnInDN.Visible = False
            End If
        Else
            If grvDanhsachXuatkhoPT.RowCount > 0 Then
                BtnTHEM.Enabled = True
                btnSUA.Enabled = True
                btnXOA.Enabled = True
                BtnIN.Enabled = True
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then
                    btnInDN.Enabled = True
                Else
                    btnInDN.Visible = False
                End If
                btnLockPhieuXuat.Enabled = True
            Else
                BtnTHEM.Enabled = True
                btnSUA.Enabled = False
                btnXOA.Enabled = False
                BtnIN.Enabled = False
                If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then
                    btnInDN.Enabled = False
                Else
                    btnInDN.Visible = False
                End If
                btnLockPhieuXuat.Enabled = False
            End If
        End If

    End Sub

    Private Sub rdbChuaLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles rdbChuaLock.CheckedChanged
        'LOAD_FORM()
    End Sub

    Private Sub cboPhieuBaoTri_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPhieuBaoTri.SelectedIndexChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        If cboPhieuBaoTri.SelectedValue = "0" Then
        Else
            If cboPhieuBaoTri.SelectedValue = "-1" Then
                If Commons.Modules.SQLString.Length > 3 Then
                    If Commons.Modules.SQLString.Substring(0, 3).ToUpper() = "WO-" Then
                        cboPhieuBaoTri.SelectedValue = Commons.Modules.SQLString
                        Commons.Modules.SQLString = ""
                    End If
                    bXuatBTMoi = True
                Else
                    bXuatBTMoi = False
                End If
            Else
                Try
                    Dim sql As String = "SELECT MS_MAY FROM PHIEU_BAO_TRI WHERE MS_PHIEU_BAO_TRI= '" + cboPhieuBaoTri.SelectedValue + "'"
                    cboMay.SelectedValue = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                Catch ex As Exception
                    cboMay.SelectedValue = ""
                End Try

            End If
        End If
        LoadCbChiPhi()
    End Sub

    Private Sub LoadCbChiPhi()

        Dim vtbData As DataTable = New DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                             "SELECT TOP 0 MS_BP_CHIU_PHI, TEN_BP_CHIU_PHI  FROM dbo.BO_PHAN_CHIU_PHI "))
        cbxCostCenter.DataSource = vtbData
        cbxCostCenter.DisplayMember = "TEN_BP_CHIU_PHI"
        cbxCostCenter.ValueMember = "MS_BP_CHIU_PHI"

        If cboDANG_XUAT.SelectedValue = 4 Or cboDANG_XUAT.SelectedValue = 8 Then
            vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT A.MS_BP_CHIU_PHI, A.TEN_BP_CHIU_PHI, C.USERNAME FROM dbo.BO_PHAN_CHIU_PHI AS A INNER JOIN " &
                    " dbo.NHOM_BO_PHAN_CHIU_PHI AS B ON A.MS_BP_CHIU_PHI = B.MS_BP_CHIU_PHI INNER JOIN dbo.USERS AS C ON B.GROUP_ID = C.GROUP_ID " &
                    " WHERE USERNAME = '" + Commons.Modules.UserName + "' ORDER BY TEN_BP_CHIU_PHI"))
            cbxCostCenter.DataSource = vtbData
            cbxCostCenter.DisplayMember = "TEN_BP_CHIU_PHI"
            cbxCostCenter.ValueMember = "MS_BP_CHIU_PHI"
        Else
            If cboPhieuBaoTri.Text.Trim.ToString <> "" Then
                vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_getBPCPhi_PBTri", cboPhieuBaoTri.SelectedValue.ToString))
                cbxCostCenter.DataSource = vtbData
                cbxCostCenter.DisplayMember = "TEN_BP_CHIU_PHI"
                cbxCostCenter.ValueMember = "MS_BP_CHIU_PHI"
            Else
                cbxCostCenter.Text = ""
            End If
        End If
    End Sub

    Private Sub chkIsLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsLock.CheckedChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        intRowCT = 0
        Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
        EnableControl(False)
        SetVisibleButton(True)
        EnableButton()

    End Sub

    Private Sub lokWareHouse_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lokWareHouse.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
        EnableControl(False)
        SetVisibleButton(True)
        EnableButton()
    End Sub

    Private Sub datFromDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datFromDate.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub

        Try
            If isFirst Then
                If (datFromDate.DateTime <= datToDate.DateTime) Then
                    Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub datToDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datToDate.EditValueChanged
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        Try
            If isFirst Then
                If (datFromDate.DateTime <= datToDate.DateTime) Then
                    Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub datToDate_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles datToDate.EditValueChanging
        Try
            If Commons.Modules.SQLString = "0Load" Then Exit Sub
            If isFirst Then

                If (e.NewValue < datFromDate.DateTime) Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub datFromDate_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles datFromDate.EditValueChanging
        If Commons.Modules.SQLString = "0Load" Then Exit Sub
        If isFirst Then
            If (e.NewValue > datToDate.DateTime) Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub cboKHO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKHO.SelectedIndexChanged
        If btnGHI.Visible = False Then Exit Sub
        If cboKHO.Text = "" Then Exit Sub

        txtTKho.Text = TimCN(cboKHO.SelectedValue)
        If KiemTraKhoDiDuong(cboKHO.SelectedValue) = True Then
            cboDANG_XUAT.Enabled = False
            cboLDXKT.Enabled = False
            cboDANG_XUAT.SelectedValue = "9"
        Else
            cboDANG_XUAT.Enabled = True
            cboLDXKT.Enabled = True
        End If
        If cboDANG_XUAT.SelectedValue = "3" Then
        End If
    End Sub

    Function TimCN(ByVal MS As Integer) As String
        Dim sql As String
        sql = " SELECT CONVERT(NVARCHAR(255),ISNULL(dbo.CONG_NHAN.HO, N'') + ' ' + ISNULL(dbo.CONG_NHAN.TEN, N'')) AS HTEN " &
                    " FROM CONG_NHAN WHERE MS_CONG_NHAN = ( SELECT MS_CONG_NHAN FROM IC_KHO WHERE MS_KHO = " & MS & ")"
        Dim dtCN As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql)
        sql = ""
        While dtCN.Read
            sql = dtCN.Item("HTEN").ToString.Trim()
        End While
        dtCN.Close()
        Return sql
    End Function
    Function KiemTraKhoDiDuong(ByVal MS_KHO As String) As Boolean
        Try
            Dim sql As String = ""
            sql = "select MS_KHO,MS_KHO_CHINH FROM IC_KHO WHERE MS_KHO=N'" & MS_KHO & "' AND ISNULL(KHO_DD,0) <>0"
            Dim dtCN As New DataTable
            dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            KiemTraKhoDiDuong = False
            If dtCN.Rows.Count > 0 Then
                cboKHO_CHINH.EditValue = dtCN.Rows(0)(1).ToString()
                KiemTraKhoDiDuong = True
            Else
                cboKHO_CHINH.SelectedIndex = 0
                cboKHO_CHINH.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Function
    Function NgayMaxKK(ByVal MsKho As Integer, ByVal Ngay As Date, ByVal Gio As Date) As Boolean
        Dim Sql As String
        Try
            Sql = "SELECT MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(2), DAY(NGAY))+'/'+CONVERT(NVARCHAR(2),MONTH(NGAY))+'/'+ " &
                        " CONVERT(NVARCHAR(4),YEAR(NGAY))+ ' ' + CONVERT(NVARCHAR(2),DATEPART(hour, GIO))+':'+ " &
                        " CONVERT(NVARCHAR(2),DATEPART(MINUTE, GIO)),103) ) FROM KIEM_KE WHERE MS_KHO = " + MsKho.ToString()
            Dim NgayKK, NgayNhap As Date
            NgayKK = Convert.ToDateTime(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
            Sql = Ngay.ToShortDateString() + " " + Gio.ToLongTimeString()
            NgayNhap = Convert.ToDateTime(Sql)
            If NgayKK >= NgayNhap Then Return False Else Return True
        Catch ex As Exception
            Return True
        End Try

    End Function
    Function NgayMaxKho(ByVal MsKho As Integer, ByVal Ngay As Date, ByVal Gio As Date) As Boolean
        Dim Sql As String
        Try
            Sql = "SELECT MAX(CONVERT(DATETIME,CONVERT(NVARCHAR(2), DAY(NGAY_LOCK))+'/'+CONVERT(NVARCHAR(2),MONTH(NGAY_LOCK))+'/'+ " &
                        " CONVERT(NVARCHAR(4),YEAR(NGAY_LOCK))+ ' ' + CONVERT(NVARCHAR(2),DATEPART(hour, GIO_LOCK))+':'+ " &
                        " CONVERT(NVARCHAR(2),DATEPART(MINUTE, GIO_LOCK)),103) ) FROM IC_KHO WHERE MS_KHO = " + MsKho.ToString()
            Dim NgayKK, NgayKho As Date
            NgayKK = Convert.ToDateTime(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Sql))
            Sql = Ngay.ToShortDateString() + " " + Gio.ToLongTimeString()
            NgayKho = Convert.ToDateTime(Sql)
            If NgayKK >= NgayKho Then Return False Else Return True
        Catch ex As Exception
            Return True
        End Try

    End Function

    Private Sub btnTimPBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONNbtnTimPBT.Click
        Dim frm As New ReportMain.Forms.frmYCSDChonMay()
        frm.iLoai = 5
        If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        cboPhieuBaoTri.SelectedValue = Commons.Modules.SQLString
    End Sub

    Private Sub tabXuatkhoPT_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
        If Commons.Modules.SQLString = "0LOADTAB" Then Exit Sub
        If btnGHI.Visible = True Then e.Cancel = True
    End Sub

    Private Sub cboMay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMay.SelectedIndexChanged
        Dim str As String
        If cboMay.Text <> "" Then
            str = " SELECT TOP 1 A.MS_BP_CHIU_PHI FROM MAY_BO_PHAN_CHIU_PHI  A INNER JOIN " &
                    " (SELECT MS_MAY, MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY = '" & cboMay.SelectedValue & "' GROUP BY MS_MAY ) B ON  " &
                    " A.MS_MAY = B.MS_MAY AND A.NGAY_NHAP = B.NGAY_MAX WHERE A.MS_MAY = '" & cboMay.SelectedValue & "' "
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            cbxCostCenter.SelectedValue = dtTmp.Rows(0)("MS_BP_CHIU_PHI")
        Else
            cbxCostCenter.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnTimMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONNbtnTimMay.Click

    End Sub

    Private Sub btnNNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub btnDVNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnUnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnLock.Click

        If btnGHI.Visible Then Exit Sub
        If txtMS_DH_XUAT.Text.Trim = "" Then Exit Sub
        If Not chkIsLock.Checked Then Exit Sub

        Dim sSql As String
        Dim dtTmp = New DataTable
        '
        sSql = " SELECT DISTINCT A.MS_PHIEU_BAO_TRI FROM dbo.PHIEU_BAO_TRI AS A INNER JOIN " &
                    " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO AS B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI " &
                    " WHERE  A.TINH_TRANG_PBT > 3 AND B.MS_DH_XUAT_PT = N'" + txtMS_DH_XUAT.Text + "' " &
                    " ORDER BY A.MS_PHIEU_BAO_TRI "
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

        If dtTmp.Rows.Count > 0 Then
            sSql = ""
            For Each dr As DataRow In dtTmp.Rows
                sSql = sSql + " - " + dr(0)
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                "msgCoPBTDaNghiemThuHayHoanThanhHayLockNenKhongTheUnLock", Commons.Modules.TypeLanguage) + vbCrLf + sSql.Substring(3, sSql.Length - 3))
            Exit Sub
        End If
        dtTmp = New DataTable
        sSql = "SELECT DISTINCT MS_DH_NHAP_PT FROM dbo.IC_DON_HANG_NHAP WHERE MS_DH_XUAT_PT = N'" + txtMS_DH_XUAT.Text + "'"
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
        If dtTmp.Rows.Count > 0 Then
            sSql = ""
            For Each dr As DataRow In dtTmp.Rows
                sSql = sSql + " - " + dr(0)
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                "msgCoPhieuNhapKhoKhongTheUnLock", Commons.Modules.TypeLanguage) + vbCrLf + sSql.Substring(3, sSql.Length - 3))
            Exit Sub
        End If
        dtTmp = New DataTable
        sSql = " SELECT DISTINCT A.MS_PHIEU_BAO_TRI FROM dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO A WHERE  A.MS_DH_XUAT_PT = N'" + txtMS_DH_XUAT.Text + "' " &
                    " ORDER BY A.MS_PHIEU_BAO_TRI "
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))

        If dtTmp.Rows.Count > 0 Then
            sSql = ""
            For Each dr As DataRow In dtTmp.Rows
                sSql = sSql + " - " + dr(0)
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                "msgCoPBTDaNhapSLTTNenKhongTheUnLock", Commons.Modules.TypeLanguage) + vbCrLf + sSql.Substring(3, sSql.Length - 3))
            Exit Sub
        End If

        If DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgBanCoMuonBoLockPhieuXuat", Commons.Modules.TypeLanguage), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Try
            sSql = " UPDATE IC_DON_HANG_XUAT SET LOCK = 0 WHERE MS_DH_XUAT_PT = N'" + txtMS_DH_XUAT.Text + "'  "
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)

            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgUnlockThanhCong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
            EnableControl(False)
            SetVisibleButton(True)
            If chkIsLock.Checked = True Then
                BtnTHEM.Enabled = False
            End If

        Catch ex As Exception
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgUnlockKhongThanhCong", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnTimCX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimCX.Click

        If txtFilter.Text.Trim = "" Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgVuiLongNhapGiaTriCanTim", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim dNgay As Date = "01/01/1900"
        Dim iLock As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            Commons.Modules.ObjSystems.mGetSoPhieu("IC_DON_HANG_XUAT", "MS_DH_XUAT_PT", "NGAY", "CONVERT(INT,LOCK)", txtFilter.Text, dNgay, iLock)
            If dNgay.Date <> "01/01/1900" Then
                isFirst = False
                Commons.Modules.SQLString = "0Load"
                If iLock = 1 Then chkIsLock.Checked = True Else chkIsLock.Checked = False
                lokWareHouse.EditValue = -1
                datFromDate.Text = dNgay.Date
                datToDate.Text = dNgay.Date
                Commons.Modules.SQLString = ""
                isFirst = True
                Load_Danh_Sach_PX(Nhu_Y_CreateQuery(), "-1")
                'txtFilter_TextChanged(sender, e)
            End If
        Catch ex As Exception
            'txtFilter_TextChanged(sender, e)
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub InBCXuatGiaCong()
        Dim frmRpt As frmShowXMLReport = New frmShowXMLReport()
        frmRpt.rptName = "rptPhieuXuatGiaCong"
        Dim connection As New System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString)
        connection.Open()
        Dim command As New System.Data.SqlClient.SqlCommand()
        command.Connection = connection
        command.CommandText = "GetBCPhieuXuatGC"
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add(New SqlParameter("@MsDHX", txtMS_DH_XUAT.Text))


        Dim adapter As New SqlDataAdapter(command)
        Dim dsTmp As New DataSet()
        Try
            adapter.Fill(dsTmp)
        Catch ex As Exception

        End Try
        Dim dtTMP = New DataTable
        For i As Integer = 0 To dsTmp.Tables.Count - 1
            dtTMP = New DataTable
            dtTMP = dsTmp.Tables(i)
            Select Case i
                Case 0
                    dtTMP.TableName = "PX_PT"
            End Select
            frmRpt.AddDataTableSource(dsTmp.Tables(i))
        Next
        frmRpt.AddDataTableSource(NNguPBTDV())
        frmRpt.ShowDialog()

    End Sub

    Function NNguPBTDV() As DataTable
        Try

            Dim dtNN As New DataTable()
            dtNN.TableName = "TIEU_DE_PBT_DV"
            For i As Integer = 0 To 30
                dtNN.Columns.Add()
            Next
            dtNN.Columns(0).ColumnName = "TIEU_DE_PX_GC"
            dtNN.Columns(1).ColumnName = "SO_PHIEU"
            dtNN.Columns(2).ColumnName = "NGUOI_DE_NGHI"
            dtNN.Columns(3).ColumnName = "BO_PHAN"
            dtNN.Columns(4).ColumnName = "KHO_XUAT"
            dtNN.Columns(5).ColumnName = "DV_SUA_CHUA"
            dtNN.Columns(6).ColumnName = "DANG_XUAT"
            dtNN.Columns(7).ColumnName = "LY_DO_XUAT"
            dtNN.Columns(8).ColumnName = "BB_CHIU_PHI"
            dtNN.Columns(9).ColumnName = "THOI_GIAN"
            dtNN.Columns(10).ColumnName = "TG_DU_KIEN"
            dtNN.Columns(11).ColumnName = "THONG_TIN_TB"
            dtNN.Columns(13).ColumnName = "STT"
            dtNN.Columns(14).ColumnName = "TEN_TB"
            dtNN.Columns(15).ColumnName = "S_LUONG"
            dtNN.Columns(16).ColumnName = "CONG_VIEC"
            dtNN.Columns(17).ColumnName = "GHI_CHU"
            dtNN.Columns(18).ColumnName = "N_DE_NGHI"
            dtNN.Columns(19).ColumnName = "BAO_VE"
            dtNN.Columns(20).ColumnName = "DUYET"
            dtNN.Columns(21).ColumnName = "TMP1"
            dtNN.Columns(22).ColumnName = "TMP2"
            dtNN.Columns(23).ColumnName = "TMP3"
            dtNN.Columns(24).ColumnName = "TMP4"
            dtNN.Columns(25).ColumnName = "TMP5"
            dtNN.Columns(26).ColumnName = "TMP6"
            dtNN.Columns(27).ColumnName = "TMP7"
            dtNN.Columns(28).ColumnName = "TMP8"
            dtNN.Columns(29).ColumnName = "TMP9"

            'A.MS_PHIEU_BAO_TRI, B.HO + ' ' + B.TEN AS HT_NLAP, D.TEN_TO, @NCCap AS CTY, A.LY_DO_BT, A.NGAY_BD_KH, TEN_BP_CHIU_PHI
            Dim vRowTitle As DataRow = dtNN.NewRow()
            vRowTitle("TIEU_DE_PX_GC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TIEU_DE_PX_GC", Commons.Modules.TypeLanguage)
            vRowTitle("SO_PHIEU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "SO_PHIEU", Commons.Modules.TypeLanguage) & " : " & txtSO_PHIEU_XUAT.Text
            vRowTitle("NGUOI_DE_NGHI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "NGUOI_DE_NGHI", Commons.Modules.TypeLanguage) & " : " & txtNLap.Text
            vRowTitle("BO_PHAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "BO_PHAN", Commons.Modules.TypeLanguage)
            vRowTitle("KHO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "KHO_XUAT", Commons.Modules.TypeLanguage) & " : " & cboKHO.Text
            vRowTitle("DV_SUA_CHUA") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "DV_SUA_CHUA", Commons.Modules.TypeLanguage) & " : " & cboNguoiNhan.Text
            vRowTitle("DANG_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "DANG_XUAT", Commons.Modules.TypeLanguage) & " : " & cboDANG_XUAT.Text
            vRowTitle("LY_DO_XUAT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "LY_DO_XUAT", Commons.Modules.TypeLanguage) & " : " & txtLydoxuat.Text
            vRowTitle("BB_CHIU_PHI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "BB_CHIU_PHI", Commons.Modules.TypeLanguage)
            vRowTitle("THOI_GIAN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "THOI_GIAN", Commons.Modules.TypeLanguage) & " : " & dtpNGAY_NHAP.Text
            vRowTitle("TG_DU_KIEN") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TG_DU_KIEN", Commons.Modules.TypeLanguage)
            vRowTitle("THONG_TIN_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "THONG_TIN_TB", Commons.Modules.TypeLanguage)
            vRowTitle("STT") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "STT", Commons.Modules.TypeLanguage)
            vRowTitle("TEN_TB") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TEN_TB", Commons.Modules.TypeLanguage)
            vRowTitle("S_LUONG") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "S_LUONG", Commons.Modules.TypeLanguage)
            vRowTitle("CONG_VIEC") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "CONG_VIEC", Commons.Modules.TypeLanguage)
            vRowTitle("GHI_CHU") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "GHI_CHU", Commons.Modules.TypeLanguage)
            vRowTitle("N_DE_NGHI") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "N_DE_NGHI", Commons.Modules.TypeLanguage)
            vRowTitle("BAO_VE") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "BAO_VE", Commons.Modules.TypeLanguage)
            vRowTitle("DUYET") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "DUYET", Commons.Modules.TypeLanguage)
            vRowTitle("TMP1") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP1", Commons.Modules.TypeLanguage)
            vRowTitle("TMP2") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP2", Commons.Modules.TypeLanguage)
            vRowTitle("TMP3") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP3", Commons.Modules.TypeLanguage)
            vRowTitle("TMP4") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP4", Commons.Modules.TypeLanguage)
            vRowTitle("TMP5") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP5", Commons.Modules.TypeLanguage)
            vRowTitle("TMP6") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP6", Commons.Modules.TypeLanguage)
            vRowTitle("TMP7") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP7", Commons.Modules.TypeLanguage)
            vRowTitle("TMP8") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP8", Commons.Modules.TypeLanguage)
            vRowTitle("TMP9") = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuXuatGiaCong", "TMP9", Commons.Modules.TypeLanguage)
            dtNN.Rows.Add(vRowTitle)
            Return dtNN
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub dtpNGAY_CHUNG_TU_EditValueChanged(sender As Object, e As EventArgs) Handles dtpNGAY_CHUNG_TU.EditValueChanged

        txtNGAY_CHUNG_TU.Text = dtpNGAY_CHUNG_TU.DateTime

    End Sub

    Private Sub cboDANG_XUAT_KeyDown(sender As Object, e As KeyEventArgs) Handles cboDANG_XUAT.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub grvXuatkhoPTCT_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvXuatkhoPTCT.FocusedRowChanged
        Try
            LoadViTriXuat()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grvDanhsachXuatkhoPT_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvDanhsachXuatkhoPT.FocusedRowChanged
        If (Commons.Modules.SQLString = "0Load") Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        ShowPhieuXuat()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim frm As New frmChonInPhieuBaoTri
        frm.iLoaiIP = 2
        If frm.ShowDialog = DialogResult.OK Then
            LoadPBT()
        End If
    End Sub

    Private Sub dtpNGAY_NHAP_ValueChanged(sender As Object, e As EventArgs) Handles dtpNGAY_NHAP.ValueChanged
        If dtpNGAY_NHAP.Value.Month = DateTime.Now.Month Then Exit Sub

        Dim cpSCT As Boolean = False
        If txtMS_DH_XUAT.Text = txtSO_PHIEU_XUAT.Text Then cpSCT = True
#Region "tao phieu xuat moi"
        TaoPX()
#End Region
        If cpSCT Then txtSO_PHIEU_XUAT.Text = txtMS_DH_XUAT.Text
    End Sub

    Private Sub cboDVNhan_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles cboDVNhan.ButtonClick
        If e.Button.Kind.ToString().ToUpper() = "Ellipsis".ToUpper() Then
            Dim frm As New WareHouse.frmTimNCTy()
            frm.Loai = 5
            frm.DangNhapXuat = 3
            If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
            cboDVNhan.EditValue = frm.MsNV
            'cboDVNhan.PerformClick(cboDVNhan.Properties.Buttons(2))
        End If

    End Sub

    Private Sub cboNguoiNhan_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles cboNguoiNhan.ButtonClick
        If e.Button.Kind.ToString().ToUpper() = "Ellipsis".ToUpper() Then
            Dim frm As New WareHouse.frmTimNCTy()
            frm.Loai = 5
            frm.DangNhapXuat = cboDANG_XUAT.SelectedValue
            If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
            cboNguoiNhan.EditValue = frm.MsNV
        End If
    End Sub

    Private Sub txtFilter_EditValueChanged(sender As Object, e As EventArgs) Handles txtFilter.EditValueChanged
        Dim dtTmp = New DataTable
        Try
            dtTmp = CType(grdDanhsachXuatkhoPT.DataSource, DataTable)
            dtTmp.DefaultView.RowFilter = " MS_DH_XUAT_PT like '%" + txtFilter.Text + "%' OR SO_PHIEU_XN like '%" + txtFilter.Text + "%'"
            dtTmp = dtTmp.DefaultView.ToTable()
        Catch ex As Exception
            dtTmp.DefaultView.RowFilter = ""
            dtTmp = dtTmp.DefaultView.ToTable()
        End Try
        If Me.grvDanhsachXuatkhoPT.RowCount > 0 Then
            BtnIN.Enabled = True
            If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = True Else btnInDN.Visible = False
            grvDanhsachXuatkhoPT_FocusedRowChanged(Nothing, Nothing)
        Else
            btnLockPhieuXuat.Enabled = False
            btnSUA.Enabled = False
            btnXOA.Enabled = False
            BtnIN.Enabled = False
            If Commons.Modules.sPrivate.ToUpper = "GREENFEED" Or Commons.Modules.sPrivate.ToUpper = "VINHHOAN" Then btnInDN.Enabled = False Else btnInDN.Visible = False
            grdXuatkhoPTCT.DataSource = DBNull.Value
            grdSLtheoViTri.DataSource = DBNull.Value
        End If
    End Sub
End Class