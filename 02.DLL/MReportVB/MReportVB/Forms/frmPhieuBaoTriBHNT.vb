Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Threading

Public Class frmPhieuBaoTriBHNT
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private TNgay As Date


    Public Property dTNgay() As Date
        Get
            Return TNgay
        End Get
        Set(ByVal value As Date)
            TNgay = value
        End Set
    End Property
    Private DNgay As Date
    Public Property dDNgay() As Date
        Get
            Return DNgay
        End Get
        Set(ByVal value As Date)
            DNgay = value
        End Set
    End Property

    Private Sub LoadNX()
        Try
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", Commons.Modules.UserName, "-1", "-1", "-1"))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDDiem, dtTmp, "MS_N_XUONG", "TEN_N_XUONG", lblDDiem.Text)
        Catch
        End Try
    End Sub
    Private Sub LoadDChuyen()
        Try
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyen(1), "MS_HE_THONG", "TEN_HE_THONG", lblDChuyen.Text)
        Catch
        End Try
    End Sub
    Private Sub LoadLoaiMay()
        Try
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text)
        Catch
        End Try
    End Sub

    Private Sub LoadMay()
        Try



            If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
            If Commons.Modules.SQLString = "" Then
                Commons.Modules.SQLString = "LOADMAY"
            End If
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayAll", tabPBT.SelectedTabPageIndex + 1, Commons.Modules.UserName,
                dtTNgay.DateTime, dtDNgay.DateTime, cboLMay.EditValue.ToString(), cboDDiem.EditValue.ToString(), Integer.Parse(cboDChuyen.EditValue.ToString())))
            Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboMay, dtTmp, "MS_MAY", "TEN_MAY", "frmPhieuBaoTriBHNT")
            If Commons.Modules.SQLString = "LOADMAY" Then
                Commons.Modules.SQLString = ""
                LoadPBT()
            End If
        Catch
            Commons.Modules.SQLString = ""
        End Try
    End Sub

    Private Sub LoadPBT()
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        If Commons.Modules.SQLString = "LOADMAY" Then Exit Sub

        Dim dtTmp As New DataTable()
        Dim sMay As String = "-1"
        Dim sDK As String = ""

        Try
            If cboMay.EditValue <> " < ALL > " Then sMay = cboMay.EditValue

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhieuBaoTriBHNT", tabPBT.SelectedTabPageIndex + 1, Commons.Modules.UserName,
                dtTNgay.DateTime, dtDNgay.DateTime, cboDDiem.EditValue.ToString(), Integer.Parse(cboDChuyen.EditValue.ToString()),
                cboLMay.EditValue.ToString(), sMay))
            For i As Integer = 0 To dtTmp.Columns.Count - 1
                dtTmp.Columns(i).ReadOnly = True
            Next

            dtTmp.Columns("CHON").ReadOnly = False

            Select Case tabPBT.SelectedTabPageIndex
                Case 0
                    grdPBT.DataSource = Nothing
                    txtTKiem.Text = ""
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPBT, grvPBT, dtTmp, True, False, True, False)
                    grvPBT.Columns("PHONG_NGUA").Visible = False
                Case 1
                    grdHThanh.DataSource = Nothing
                    txtTKiem.Text = ""
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdHThanh, grvHThanh, dtTmp, True, False, True, False)
                    grvHThanh.Columns("PHONG_NGUA").Visible = False
                Case 2
                    grdNThu.DataSource = Nothing
                    txtTKiem.Text = ""
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdNThu, grvNThu, dtTmp, True, False, True, False)
                    grvNThu.Columns("PHONG_NGUA").Visible = False
                Case 3
                    grdLock.DataSource = Nothing
                    txtTKiem.Text = ""
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdLock, grvLock, dtTmp, True, False, True, False)
                    grvLock.Columns("PHONG_NGUA").Visible = False
            End Select

            If grvPBT.Columns("MS_LOAI_BT").Visible = True Then
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdHThanh, grvHThanh, dtTmp, True, False, True, False)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNThu, grvNThu, dtTmp, True, False, True, False)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdLock, grvLock, dtTmp, True, False, True, False)
            End If
        Catch ex As Exception
            XtraMessageBox.Show (ex.Message.ToString())
        End Try


    End Sub
    Private Sub LoadNNThu()
        Try
            Dim dtTmp As New DataTable()
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCongNhanPBTTN", 1, "-1"))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNNThu, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", lblDDiem.Text)

            Dim Str As String = "SELECT ISNULL(MS_CONG_NHAN,'') FROM USERS WHERE USERNAME  = N'" & Commons.Modules.UserName & "' "
            Str = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, Str))
            If Str <> "" Then cboNNThu.EditValue = Str
        Catch
        End Try

    End Sub

    Private Sub frmPhieuBaoTriBHNT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            LoadNNThu()
            Commons.Modules.SQLString = "0LOAD"
            dtTNgay.DateTime = TNgay
            dtDNgay.DateTime = DNgay
            dtNHThanh.DateTime = Now.Date
            datNGNT.DateTime = Now
            LoadNX()
            LoadDChuyen()
            LoadLoaiMay()
            Commons.Modules.SQLString = ""
            LoadMay()
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvPBT, Me.Name)
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvHThanh, Me.Name)
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvNThu, Me.Name)
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvLock, Me.Name)


            'CONVERT (BIT,0) AS , T4.Ten_N_XUONG, T1., T1., T1.MS_MAY, T2.TEN_LOAI_BT, 
            'T1., T3.TEN_UU_TIEN, T1.
            grvPBT.Columns("CHON").Width = 40
            grvPBT.Columns("Ten_N_XUONG").Width = 85
            grvPBT.Columns("MS_PHIEU_BAO_TRI").Width = 75
            grvPBT.Columns("LY_DO_BT").Width = 70
            grvPBT.Columns("NGAY_LAP").Width = 50
            grvPBT.Columns("NGAY_BD_KH").Width = 50
            grvPBT.Columns("MS_LOAI_BT").Visible = False
            grvPBT.Columns("MS_HT_BT").Visible = False


            grvHThanh.Columns("CHON").Width = 40
            grvHThanh.Columns("Ten_N_XUONG").Width = 85
            grvHThanh.Columns("MS_PHIEU_BAO_TRI").Width = 75
            grvHThanh.Columns("LY_DO_BT").Width = 70
            grvHThanh.Columns("NGAY_LAP").Width = 50
            grvHThanh.Columns("NGAY_BD_KH").Width = 50
            grvHThanh.Columns("MS_LOAI_BT").Visible = False
            grvHThanh.Columns("MS_HT_BT").Visible = False

            grvNThu.Columns("CHON").Width = 40
            grvNThu.Columns("Ten_N_XUONG").Width = 85
            grvNThu.Columns("MS_PHIEU_BAO_TRI").Width = 75
            grvNThu.Columns("LY_DO_BT").Width = 70
            grvNThu.Columns("NGAY_LAP").Width = 50
            grvNThu.Columns("NGAY_BD_KH").Width = 50
            grvNThu.Columns("MS_LOAI_BT").Visible = False
            grvNThu.Columns("MS_HT_BT").Visible = False

            grvLock.Columns("CHON").Width = 40
            grvLock.Columns("Ten_N_XUONG").Width = 85
            grvLock.Columns("MS_PHIEU_BAO_TRI").Width = 75
            grvLock.Columns("LY_DO_BT").Width = 70
            grvLock.Columns("NGAY_LAP").Width = 50
            grvLock.Columns("NGAY_BD_KH").Width = 50
            grvLock.Columns("MS_LOAI_BT").Visible = False
            grvLock.Columns("MS_HT_BT").Visible = False


            tabPBT.TabPages(0).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTriBHNT", "tabDuyet", Commons.Modules.TypeLanguage)
            tabPBT.TabPages(1).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTriBHNT", "tabHoanThanh", Commons.Modules.TypeLanguage)
            tabPBT.TabPages(2).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTriBHNT", "tabNghiemThu", Commons.Modules.TypeLanguage)
            tabPBT.TabPages(3).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTriBHNT", "tabLock", Commons.Modules.TypeLanguage)
            txtCPhi.Text = 0
        Catch ex As Exception
            'XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboLMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLMay.EditValueChanged
        Try
            LoadMay()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtTNgay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTNgay.EditValueChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        Try
            LoadMay()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtDNgay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDNgay.EditValueChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        Try
            LoadMay()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboDDiem_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDDiem.EditValueChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        Try
            LoadMay()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboDChuyen_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDChuyen.EditValueChanged
        If Commons.Modules.SQLString = "0LOAD" Then Exit Sub
        Try
            LoadMay()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Close()
    End Sub

    Private Sub cboMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMay.EditValueChanged
        LoadPBT()
    End Sub

    Private Sub txtTKiem_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtTKiem.EditValueChanging

        Dim dtTmp As New DataTable
        Dim sDK As String = ""
        Try
            Select Case tabPBT.SelectedTabPageIndex
                Case 0
                    dtTmp = CType(grdPBT.DataSource, DataTable)
                Case 1
                    dtTmp = CType(grdHThanh.DataSource, DataTable)
                Case 2
                    dtTmp = CType(grdNThu.DataSource, DataTable)
                Case 3
                    dtTmp = CType(grdLock.DataSource, DataTable)
            End Select
            If txtTKiem.Text <> "" Then sDK = " OR MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + sDK
            If txtTKiem.Text <> "" Then sDK = " OR SO_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + sDK
            If txtTKiem.Text <> "" Then sDK = " OR MS_MAY LIKE '%" + txtTKiem.Text + "%' " + sDK
            If txtTKiem.Text <> "" Then sDK = " OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' " + sDK
            If sDK.Length > 0 Then sDK = sDK.Substring(4, sDK.Length - 4)
            dtTmp.DefaultView.RowFilter = sDK
        Catch ex As Exception
            Try
                dtTmp.DefaultView.RowFilter = ""
            Catch ex1 As Exception
            End Try

        End Try

    End Sub

    Private Sub btnALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnALL.Click
        Select Case tabPBT.SelectedTabPageIndex
            Case 0
                Commons.Modules.ObjSystems.MChooseGrid(True, "CHON", grvPBT)
            Case 1
                Commons.Modules.ObjSystems.MChooseGrid(True, "CHON", grvHThanh)
            Case 2
                Commons.Modules.ObjSystems.MChooseGrid(True, "CHON", grvNThu)
            Case 3
                Commons.Modules.ObjSystems.MChooseGrid(True, "CHON", grvLock)
        End Select
    End Sub

    Private Sub btnNotAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotAll.Click
        Select Case tabPBT.SelectedTabPageIndex
            Case 0
                Commons.Modules.ObjSystems.MChooseGrid(False, "CHON", grvPBT)
            Case 1
                Commons.Modules.ObjSystems.MChooseGrid(False, "CHON", grvHThanh)
            Case 2
                Commons.Modules.ObjSystems.MChooseGrid(False, "CHON", grvNThu)
            Case 3
                Commons.Modules.ObjSystems.MChooseGrid(False, "CHON", grvLock)
        End Select
    End Sub

    Function KiemPQuyen(ByVal iQuyen As Integer)
        Try
            Dim sSql As String = ""
            Dim iPQ As Integer = 0
            sSql = "SELECT COUNT(*) FROM CHUC_NANG INNER JOIN USER_CHUC_NANG ON CHUC_NANG.STT = USER_CHUC_NANG.STT " & _
                        " WHERE USERNAME = '" & Commons.Modules.UserName & "' AND CHUC_NANG.STT = " & iQuyen.ToString
            iPQ = Integer.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If iPQ > 0 Then Return True Else Return False
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Dim dtTmp As New DataTable
        Select Case tabPBT.SelectedTabPageIndex
            Case 0
                dtTmp = CType(grdPBT.DataSource, DataTable).Copy()
            Case 1
                dtTmp = CType(grdHThanh.DataSource, DataTable).Copy()
            Case 2
                dtTmp = CType(grdNThu.DataSource, DataTable).Copy()
            Case 3
                dtTmp = CType(grdLock.DataSource, DataTable).Copy()
        End Select
        dtTmp.DefaultView.RowFilter = "CHON = 1"
        dtTmp = dtTmp.DefaultView.ToTable
        If dtTmp.Rows.Count = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage( _
                Commons.Modules.ModuleName, "frmPhieuBaoTriBHNT", "ChuaChonDuLieu", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        If tabPBT.SelectedTabPageIndex = 0 Then
            If DuyetBPT(dtTmp) = False Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "msgDuyetKhongThanhCong", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
        End If

        If tabPBT.SelectedTabPageIndex = 1 Then
            If HoanThanhBPT(dtTmp) = False Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "msgHoanThanhKhongThanhCong", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
        End If
#Region "Ngiem Thu"
        If tabPBT.SelectedTabPageIndex = 2 Then
            If KiemPQuyen(8) = False Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "KhongCoQuyenNgiemThu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If


            If cboNNThu.Text = "" Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "ChuaNhapNguoiNghiemThu", Commons.Modules.TypeLanguage))
                cboNNThu.Focus()
                Exit Sub
            End If
            If datNGNT.Text = "" Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "ChuaNhapNgayNghiemThu", Commons.Modules.TypeLanguage))
                datNGNT.Focus()
                Exit Sub
            End If
            If txtCPhi.Text = "" Then
                txtCPhi.Text = 0
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "ChuaNhapChiPhi", Commons.Modules.TypeLanguage))
                txtCPhi.Focus()
                Exit Sub
            End If

            If txtTTrang.Text.Trim = "" Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "ChuaNhapTinhTrang", Commons.Modules.TypeLanguage))
                txtTTrang.Focus()
                Exit Sub
            End If

            If NgiemThuBPT(dtTmp) = False Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "msgNghiemThuKhongThanhCong", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

        End If
#End Region
        If tabPBT.SelectedTabPageIndex = 3 Then
            If LockPBT(dtTmp) = False Then
                Me.Cursor = Cursors.Default
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmPhieuBaoTriBHNT", "msgLockKhongThanhCong", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
        End If
        LoadPBT()
        Me.Cursor = Cursors.Default
    End Sub

    Function DuyetBPT(ByVal dtTmp As DataTable) As Boolean
        If KiemPQuyen(7) = False Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmPhieuBaoTriBHNT", "KhongCoQuyenDuyet", Commons.Modules.TypeLanguage))
            Return False
        End If

        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CoChacBanHanh",
            Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChung", "sThongBao",
                Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Return False

        Dim con As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        con.Open()
        Dim tran As SqlTransaction = con.BeginTransaction
        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "PBT_TT", dtTmp, "")

        Try
            SqlHelper.ExecuteNonQuery(tran, "UpdateDuyetALLPBT")
            tran.Commit()
            con.Close()
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmPhieuBaoTriBHNT", "msgThucHienThanhCong", Commons.Modules.TypeLanguage))

            Return True
        Catch ex As Exception
            tran.Rollback()
            con.Close()
            Commons.Modules.ObjSystems.XoaTable("PBT_TT")
            Return False
        End Try
    End Function

    Function HoanThanhBPT(ByVal dtTmp As DataTable) As Boolean

        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CoChacHoanThanh",
                Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChung", "sThongBao",
                Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Return False

        Dim con As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        con.Open()

        Dim tran As SqlTransaction = con.BeginTransaction
        Try
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "PBT_TT_HT", dtTmp, "")
            SqlHelper.ExecuteNonQuery(tran, "UpdateHoanThanhALLPBT", dtNHThanh.DateTime.Date, If(lblNgayCNBDKH.Checked, 1, 0))
            tran.Commit()
            con.Close()
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                    "frmPhieuBaoTriBHNT", "msgThucHienThanhCong", Commons.Modules.TypeLanguage))

            Return True
        Catch ex As Exception
            tran.Rollback()
            con.Close()
            Commons.Modules.ObjSystems.XoaTable("PBT_TT_HT")
            Return False
        End Try

    End Function

    Function NgiemThuBPT(ByVal dtTmp As DataTable) As Boolean
        Dim sBTKhongCan As String
        sBTKhongCan = ""

        Dim sBTKC As String
        sBTKC = ""

        If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CoChacNghiemThu",
            Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChung", "sThongBao",
                Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Return False



        Dim con As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
        con.Open()
        Dim tran As SqlTransaction = con.BeginTransaction
        Try
            Dim dblTiGia As Double = 0, dblTiGiaUSD As Double = 0
            'CHI PHI NHAN CONG
            'commons.Modules.SQLString = "SELECT TI_GIA,TI_GIA_USD FROM TI_GIA_NT A INNER JOIN NGOAI_TE B ON A.NGOAI_TE=B.NGOAI_TE WHERE MAC_DINH=1 AND NGAY IN (SELECT MAX(NGAY) FROM TI_GIA_NT WHERE YEAR(NGAY)<=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY)<=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET)) "
            Commons.Modules.SQLString = "SELECT ISNULL(TI_GIA,0) AS TI_GIA, ISNULL(TI_GIA_USD,0) AS TI_GIA_USD " &
                     "FROM TI_GIA_NT INNER JOIN NGOAI_TE ON TI_GIA_NT.NGOAI_TE=NGOAI_TE.NGOAI_TE " &
                     "WHERE NGOAI_TE.MAC_DINH=1 AND NGAY_NHAP >= (SELECT ISNULL(MAX(NGAY_NHAP),0) " &
                                                                 "FROM TI_GIA_NT INNER JOIN NGOAI_TE ON TI_GIA_NT.NGOAI_TE = NGOAI_TE.NGOAI_TE " &
                                                                 "WHERE DATEDIFF(DAY,NGAY_NHAP,'" & Format(CDate(datNGNT.Text), "dd/MMM/yyyy") & "')>=0)"
            Dim dtReader As SqlDataReader
            dtReader = SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString)
            While dtReader.Read
                dblTiGia = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
                dblTiGiaUSD = IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
            End While
            dtReader.Close()
            Dim sBoNT As String
            sBoNT = " UPDATE PBT_TT_NT SET CHON = 0 WHERE MS_PHIEU_BAO_TRI IN  ( "


            Dim inc As Boolean = SqlHelper.ExecuteScalar(tran, "GetPBT_CPNC")
            Dim sPBT As String
            For Each dr As DataRow In dtTmp.Rows

                Dim CHI_PHI_PHU_TUNG As Double = 0, CHI_PHI_PHU_TUNG_USD As Double = 0, CHI_PHI_VAT_TU As Double = 0, CHI_PHI_VAT_TU_USD As Double = 0, CHI_PHI_NHAN_CONG As Double = 0, CHI_PHI_NHAN_CONG_USD As Double = 0, CHI_PHI_DV As Double = 0, CHI_PHI_DV_USD As Double = 0, CHI_PHI_KHAC As Double = 0, CHI_PHI_KHAC_USD As Double = 0
                sPBT = dr("MS_PHIEU_BAO_TRI").ToString

                If Not KiemPhieuBaoTriCongViecNhanSu(sPBT) Then
                    sBTKhongCan = sBTKhongCan & "; " & sPBT
                    sBoNT = sBoNT & "'" & sPBT & "',"
                    GoTo khongcan
                End If

                Commons.Modules.SQLString = " SELECT TOP 1  MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE (ISNULL(SL_TT, 0) = 0) AND (ISNULL(GHI_CHU, N'') = N'') AND MS_PHIEU_BAO_TRI='" & sPBT & "' UNION  SELECT TOP 1 MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CV_PHU_TRO_PHU_TUNG WHERE (ISNULL(SL_TT, 0) = 0) AND (ISNULL(GHI_CHU, N'') = N'') AND MS_PHIEU_BAO_TRI='" & sPBT & "'"


                Dim dtTable_tmp = New DataTable()
                dtTable_tmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString))
                If dtTable_tmp.Rows.Count > 0 Then
                    sBTKhongCan = sBTKhongCan & "; " & sPBT
                    sBoNT = sBoNT & "'" & sPBT & "',"
                    GoTo khongcan
                End If




                If inc Then
                    'New
                    Dim tCHIPHI As New DataTable
                    tCHIPHI.Load(SqlHelper.ExecuteReader(tran, "GetPHIEU_BAO_TRI_CPNC_NEW", sPBT, datNGNT.DateTime))
                    If tCHIPHI.Rows.Count > 0 And tCHIPHI.Rows(0)("TI_GIA").ToString <> "" Then
                        CHI_PHI_NHAN_CONG = Double.Parse(tCHIPHI.Rows(0)("TI_GIA").ToString())
                        CHI_PHI_NHAN_CONG_USD = Double.Parse(tCHIPHI.Rows(0)("TI_GIA_USD").ToString())
                    Else
                        CHI_PHI_NHAN_CONG = 0
                        CHI_PHI_NHAN_CONG_USD = 0
                    End If
                Else
                    Dim strChiPhiCV_Chinh As String, strChiPhiCV_Phu As String, strChiPhiCV As String
                    strChiPhiCV_Chinh = "SELECT A.MS_CONG_NHAN,(SO_PHUT*LUONG_CO_BAN)/(26*8*60) AS LUONG FROM (SELECT MS_CONG_NHAN,SUM(DATEDIFF(MINUTE,NGAY+' '+TU_GIO,DEN_NGAY+' '+DEN_GIO)) AS SO_PHUT FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" & sPBT & "' GROUP BY MS_CONG_NHAN) A INNER JOIN (SELECT MS_CONG_NHAN,LUONG_CO_BAN FROM LUONG_CO_BAN WHERE MS_CONG_NHAN IN(SELECT MS_CONG_NHAN FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET)) AND NGAY_HIEU_LUC IN(SELECT MAX(NGAY_HIEU_LUC) AS NGAY_HIEU_LUC FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET) GROUP BY MS_CONG_NHAN)) B ON A.MS_CONG_NHAN=B.MS_CONG_NHAN"
                    strChiPhiCV_Phu = "SELECT A.MS_CONG_NHAN,(SO_PHUT*LUONG_CO_BAN)/(26*8*60) AS LUONG FROM (SELECT MS_CONG_NHAN,SUM(DATEDIFF(MINUTE,NGAY+' '+TU_GIO,DEN_NGAY+' '+DEN_GIO)) AS SO_PHUT FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" & sPBT & "' GROUP BY MS_CONG_NHAN) A INNER JOIN (SELECT MS_CONG_NHAN,LUONG_CO_BAN FROM LUONG_CO_BAN WHERE MS_CONG_NHAN IN(SELECT MS_CONG_NHAN FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO)) AND NGAY_HIEU_LUC IN(SELECT MAX(NGAY_HIEU_LUC) AS NGAY_HIEU_LUC FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO) GROUP BY MS_CONG_NHAN)) B ON A.MS_CONG_NHAN=B.MS_CONG_NHAN"
                    strChiPhiCV = "SELECT A.MS_CONG_NHAN,(SO_PHUT*LUONG_CO_BAN)/(26*8*60) AS LUONG FROM (SELECT MS_CONG_NHAN,SUM(DATEDIFF(MINUTE,NGAY+' '+TU_GIO,DEN_NGAY+' '+DEN_GIO)) AS SO_PHUT FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI='" & sPBT & "' GROUP BY MS_CONG_NHAN) A INNER JOIN (SELECT MS_CONG_NHAN,LUONG_CO_BAN FROM LUONG_CO_BAN WHERE MS_CONG_NHAN IN(SELECT MS_CONG_NHAN FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_NHAN_SU) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_NHAN_SU)) AND NGAY_HIEU_LUC IN(SELECT MAX(NGAY_HIEU_LUC) AS NGAY_HIEU_LUC FROM LUONG_CO_BAN WHERE YEAR(NGAY_HIEU_LUC) <=ANY(SELECT YEAR(NGAY) FROM PHIEU_BAO_TRI_NHAN_SU) AND MONTH(NGAY_HIEU_LUC) <=ANY(SELECT MONTH(NGAY) FROM PHIEU_BAO_TRI_NHAN_SU) GROUP BY MS_CONG_NHAN)) B ON A.MS_CONG_NHAN=B.MS_CONG_NHAN"

                    Commons.Modules.SQLString = "SELECT SUM(LUONG) AS LUONG,(SELECT TI_GIA_NT.TI_GIA FROM TI_GIA_NT WHERE TI_GIA_NT.NGAY >= (SELECT MAX(TI_GIA_NT.NGAY) FROM TI_GIA_NT) AND TI_GIA_NT.NGOAI_TE IN (SELECT NGOAI_TE.NGOAI_TE FROM NGOAI_TE WHERE NGOAI_TE.MAC_DINH=1)) AS TI_GIA FROM (" & strChiPhiCV_Chinh & " UNION " & strChiPhiCV_Phu & " UNION " & strChiPhiCV & " ) AS TblTam"


                    Commons.Modules.SQLString = "SELECT ISNULL(LUONG*TI_GIA,0) FROM (" & Commons.Modules.SQLString & ") TMP"
                    'dtReader = SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString)
                    'While dtReader.Read
                    '    CHI_PHI_NHAN_CONG = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0)) * dblTiGia
                    '    CHI_PHI_NHAN_CONG_USD = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0)) * dblTiGiaUSD
                    'End While
                    'dtReader.Close()

                    Dim tCHIPHI As New DataTable
                    tCHIPHI.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spChiPhiNhanCong", sPBT, datNGNT.DateTime.Date))

                    If tCHIPHI.Rows.Count > 0 Then
                        CHI_PHI_NHAN_CONG = IIf(IsDBNull(Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())), 0, Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())) * dblTiGia
                        CHI_PHI_NHAN_CONG_USD = IIf(IsDBNull(Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())), 0, Double.Parse(tCHIPHI.Rows(0)("LUONG").ToString())) * dblTiGiaUSD
                    Else
                        CHI_PHI_NHAN_CONG = 0
                        CHI_PHI_NHAN_CONG_USD = 0
                    End If
                End If

                'CHI_PHI_VAT_TU
                If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then
                    dtReader = SqlHelper.ExecuteReader(tran, "GET_TONG_CHI_PHI_VT", sPBT)
                Else
                    dtReader = SqlHelper.ExecuteReader(tran, "SP_NHU_Y_GET_CHI_PHI_VT_PT_KHONG_SD_KHO", sPBT, 1)
                End If

                While dtReader.Read
                    CHI_PHI_VAT_TU = CHI_PHI_VAT_TU + IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
                    CHI_PHI_VAT_TU_USD = CHI_PHI_VAT_TU_USD + IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
                End While
                dtReader.Close()
                CHI_PHI_KHAC = CLng(Val(txtCPhi.Text))
                CHI_PHI_KHAC_USD = CLng(Val(txtCPhi.Text) * dblTiGiaUSD)

                'HET"

                'CHI PHI DICH VU
                Commons.Modules.SQLString = "SELECT dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI, SUM(dbo.PHIEU_BAO_TRI_SERVICE.SO_LUONG * dbo.PHIEU_BAO_TRI_SERVICE.DON_GIA * dbo.TI_GIA_NT.TI_GIA) AS CHI_PHI_DV, " &
                              "SUM(dbo.PHIEU_BAO_TRI_SERVICE.SO_LUONG * dbo.PHIEU_BAO_TRI_SERVICE.DON_GIA * dbo.TI_GIA_NT.TI_GIA_USD) AS CHI_PHI_DV_USD " &
                         "FROM dbo.PHIEU_BAO_TRI_SERVICE INNER JOIN dbo.TI_GIA_NT ON dbo.PHIEU_BAO_TRI_SERVICE.NGOAI_TE = dbo.TI_GIA_NT.NGOAI_TE " &
                         "WHERE (dbo.TI_GIA_NT.NGAY_NHAP >= ALL (SELECT MAX(NGAY_NHAP) FROM TI_GIA_NT)) " &
                         "GROUP BY dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI HAVING (dbo.PHIEU_BAO_TRI_SERVICE.MS_PHIEU_BAO_TRI = N'" & sPBT & "')"
                dtReader = SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    CHI_PHI_DV = IIf(IsDBNull(dtReader.Item("CHI_PHI_DV")), 0, dtReader.Item("CHI_PHI_DV"))
                    CHI_PHI_DV_USD = IIf(IsDBNull(dtReader.Item("CHI_PHI_DV_USD")), 0, dtReader.Item("CHI_PHI_DV_USD"))
                End While
                dtReader.Close()

                'CHI PHI PHU TUNG
                Dim strCount As String = "SELECT     COUNT(*) " &
                   " FROM         dbo.IC_PHU_TUNG INNER JOIN " &
                   " dbo.LOAI_VT ON dbo.IC_PHU_TUNG.MS_LOAI_VT = dbo.LOAI_VT.MS_LOAI_VT INNER JOIN " &
                   " (SELECT     dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, " &
                   " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                   " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG, SUM(dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT)" &
                   " AS SL_TT " &
                   " FROM          dbo.CAU_TRUC_THIET_BI_PHU_TUNG INNER JOIN " &
                   " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON  " &
                   " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND " &
                   " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND " &
                   " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT = dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT INNER JOIN " &
                   " dbo.PHIEU_BAO_TRI ON dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = dbo.PHIEU_BAO_TRI.MS_MAY AND " &
                   " dbo.PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI = dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI " &
                   " WHERE dbo.PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI = '" & sPBT & "'" &
                   " GROUP BY dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY, dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, " &
                   " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, dbo.CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, " &
                   " dbo.CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG) AS T1 ON dbo.IC_PHU_TUNG.MS_PT = T1.MS_PT " &
                   " WHERE     (T1.SL_TT > T1.SO_LUONG AND (LOAI_VT.VAT_TU IS NULL OR LOAI_VT.VAT_TU = 0 ))"

                If Convert.ToBoolean(Commons.Modules.ObjSystems.PBTKho) Then

                    'KIỂM TRA CÂN
                    Dim TB_PT_XUAT As DataTable = New DataTable()
                    TB_PT_XUAT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), "SP_GET_PT_XUAT_PTSD", sPBT))
                    For Each rSL As DataRow In TB_PT_XUAT.Rows
                        If (Not rSL("SL_TT").Equals(rSL("SL_VT"))) Then
                            'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSL_PT_KHONG_CAN", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                            sBTKhongCan = sBTKhongCan & "; " & sPBT
                            sBoNT = sBoNT & "'" & sPBT & "',"
                            GoTo khongcan
                        End If
                    Next
                    Dim PXK_KHO As Integer = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 COUNT (*) FROM IC_DON_HANG_XUAT WHERE MS_PHIEU_BAO_TRI = '" & sPBT & "' AND ( LOCK IS NULL OR LOCK = 0 ) ")
                    If PXK_KHO > 0 Then
                        'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSL_PXK_CHUA_LOCK", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                        sBTKhongCan = sBTKhongCan & "; " & sPBT
                        sBoNT = sBoNT & "'" & sPBT & "',"
                        GoTo khongcan
                    End If

                    Commons.Modules.SQLString = "SELECT SUM(SL_TT*DON_GIA*TI_GIA) AS TONG_CP_PT, SUM(SL_TT*DON_GIA*TI_GIA_USD) AS TONG_CP_PT_USD FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_PHIEU_BAO_TRI='" & sPBT & "' AND SL_TT IS NOT NULL AND SL_TT > 0 "
                Else

                    Commons.Modules.SQLString = "EXEC SP_NHU_Y_GET_CHI_PHI_VT_PT_KHONG_SD_KHO '" & sPBT & "',0"
                End If

                dtReader = SqlHelper.ExecuteReader(tran, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    CHI_PHI_PHU_TUNG = IIf(IsDBNull(dtReader.Item(0)), 0, dtReader.Item(0))
                    CHI_PHI_PHU_TUNG_USD = IIf(IsDBNull(dtReader.Item(1)), 0, dtReader.Item(1))
                End While
                dtReader.Close()

                Try
                    SqlHelper.ExecuteNonQuery(tran, "AddPHIEU_BAO_TRI_CHI_PHI", sPBT, CHI_PHI_PHU_TUNG, CHI_PHI_PHU_TUNG_USD, CHI_PHI_VAT_TU, CHI_PHI_VAT_TU_USD, CHI_PHI_NHAN_CONG, CHI_PHI_NHAN_CONG_USD, CHI_PHI_DV, CHI_PHI_DV_USD)
                Catch ex As Exception
                    SqlHelper.ExecuteScalar(tran, "UpdatePHIEU_BAO_TRI_CHI_PHI", sPBT, CHI_PHI_PHU_TUNG, CHI_PHI_PHU_TUNG_USD, CHI_PHI_VAT_TU, CHI_PHI_VAT_TU_USD, CHI_PHI_NHAN_CONG, CHI_PHI_NHAN_CONG_USD, CHI_PHI_DV, CHI_PHI_DV_USD)
                End Try

                ''Nghiem thu tinh trang = 4
                'SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdatePHIEU_BAO_TRI_TINH_TRANG", sPBT, 4)

khongcan:
            Next

            sBoNT = sBoNT.Substring(1, sBoNT.Length - 2) & ") "
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "PBT_TT_NT", dtTmp, "")
            Try
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sBoNT)
            Catch ex As Exception
            End Try

            SqlHelper.ExecuteNonQuery(tran, "UpdateNghiemThuALLPBT", txtTTrang.Text,
                    cboNNThu.EditValue, datNGNT.DateTime, Commons.Modules.UserName, txtCPhi.Text)
            tran.Commit()
            con.Close()
            Try
                If sBTKhongCan <> "" Then
                    If sBTKhongCan.Length > 0 Then sBTKhongCan = sBTKhongCan.Substring(2)
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPhieuBaoTriBHNT", "msgCon1VaiPBTKhongNgiemThuDuoc", Commons.Modules.TypeLanguage) + vbCrLf + sBTKhongCan)
                Else
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmPhieuBaoTriBHNT", "msgThucHienThanhCong", Commons.Modules.TypeLanguage))
                End If
            Catch ex As Exception
            End Try
            Return True
        Catch ex As Exception
            tran.Rollback()
            con.Close()
            Commons.Modules.ObjSystems.XoaTable("PBT_TT_NT")
            Return False
        End Try
    End Function


    Function KiemPhieuBaoTriCongViecNhanSu(ByVal sPBT As String) As Boolean
        KiemPhieuBaoTriCongViecNhanSu = False
        Dim str As String = ""
        Dim iKT As Integer
        Try
            iKT = Integer.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spKiemNgiemThu", sPBT))
            If iKT <= 0 Then
                Exit Function
            End If

            If Commons.Modules.sPrivate  = "GREENFEED" Then
                str = "SELECT ISNULL(COUNT(*),0) AS STT FROM (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = '" & sPBT & "'  UNION " &
                            " SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI = '" & sPBT & "'  UNION SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '" & sPBT & "') A "

                iKT = Int64.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str))
                If iKT > 0 Then
                    str = " SELECT ISNULL(COUNT(*),0) AS STT FROM (SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI = '" & sPBT & "'  UNION " &
                                " SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = '" & sPBT & "' UNION SELECT MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '" & sPBT & "' ) A "

                    iKT = Int64.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str))
                    If iKT = 0 Then
                        Exit Function
                    End If
                End If
            End If
            KiemPhieuBaoTriCongViecNhanSu = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Function LockPBT(ByVal dtTmp As DataTable) As Boolean
        Try
            If KiemPQuyen(9) = False Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, _
                    "frmPhieuBaoTriBHNT", "KhongCoQuyenLock", Commons.Modules.TypeLanguage))
                Return False
            End If
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CoChacKhoaPBT",
                Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChung", "sThongBao",
                Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then Return False
            Dim con As SqlConnection = New SqlConnection(Commons.IConnections.ConnectionString)
            con.Open()
            Dim tran As SqlTransaction = con.BeginTransaction
            Try
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "PBT_TT_LOCK", dtTmp, "")
                SqlHelper.ExecuteNonQuery(tran, "UpdateLockALLPBT")
                tran.Commit()
                con.Close()
                Return True
            Catch ex As Exception
                tran.Rollback()
                con.Close()
                Commons.Modules.ObjSystems.XoaTable("PBT_TT_LOCK")
                Return False
            End Try

            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLockPBT", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub tabPBT_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tabPBT.SelectedPageChanged
        LoadPBT()
        If tabPBT.SelectedTabPageIndex = 3 Then
            btnXoa.Enabled = False
        Else
            btnXoa.Enabled = True
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim dtTmp As New DataTable
        Select Case tabPBT.SelectedTabPageIndex
            Case 0
                dtTmp = CType(grdPBT.DataSource, DataTable).Copy()
            Case 1
                dtTmp = CType(grdHThanh.DataSource, DataTable).Copy()
            Case 2
                dtTmp = CType(grdNThu.DataSource, DataTable).Copy()
        End Select
        dtTmp.DefaultView.RowFilter = "CHON = TRUE"
        dtTmp = dtTmp.DefaultView.ToTable()
        If dtTmp.Rows.Count = 1 Then
            If dtTmp.Rows(0)("PHONG_NGUA") = True Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "PBTDinhKyKhongDuocXoa",
                Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChung", "sThongBao",
                Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Question)
                Return
            End If
        End If
        If (CType(grdPBT.DataSource, DataTable).Copy().Rows.Count > 0) Then
            If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CoChacXoaPBT", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChung", "sThongBao",
                Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

                For Each row As DataRow In dtTmp.Rows
                    Dim str As String = row("MS_PHIEU_BAO_TRI")
                    If (row("PHONG_NGUA") = True) Then Continue For
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spXoaPBT", str)
                    Dim dt As New DataTable
                    Select Case tabPBT.SelectedTabPageIndex
                        Case 0
                            dt = CType(grdPBT.DataSource, DataTable)
                        Case 1
                            dt = CType(grdHThanh.DataSource, DataTable)
                        Case 2
                            dt = CType(grdNThu.DataSource, DataTable)
                    End Select
                    Dim dr As DataRow = dt.Select().AsEnumerable().SingleOrDefault(Function(x) x("MS_PHIEU_BAO_TRI") = str)
                    dt.Rows.Remove(dr)
                Next
            End If
        End If
    End Sub
End Class