
Imports Microsoft.ApplicationBlocks.Data
Imports Commons
Imports DevExpress.XtraEditors

Public Class frmLapphieubaotri_CS
    Public MS_MAY As String = ""
    Public bCoCV As Boolean = False
    Public MS_NGUYEN_NHAN As String = ""
    Public sNhanVienThucHien As String = ""
    Public sMsVatTu As String = ""
    Public dNgayBDKH As Date = Now.Date
    Public dNgayKTKH As Date = Now.Date
    Public dNgayHong As New Nullable(Of DateTime)
    Public dGioHong As New Nullable(Of DateTime)
    Public MucUuTien As Integer = 2
    Public sLyDo As String = ""
    Public bLockMSMay As Boolean
    Public iMsLoaiBT As Integer = -1
    Dim sbtAll As String = "TEMPTALL" + Commons.Modules.UserName


    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            If txtSophieu.Text.Trim = "" Or txtSophieu.Text = String.Empty Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSophieuNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtSophieu.Focus()
                Exit Sub
            End If

            If cboMSThietbi.Text.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMSThietbiNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cboMSThietbi.Focus()
                Exit Sub
            End If

            If mtxtGiolap.Text <> "  :" Then
                If Not IsDate(mtxtGiolap.Text) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmPhieuBaoTri_New", "MsgGioLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    mtxtGiolap.Text = "  :"
                    mtxtGiolap.Focus()
                    Exit Sub
                End If
            End If


            If cboLoaibt.ItemIndex < 0 Or cboLoaibt.Text.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLoaiBTNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cboLoaibt.Focus()
                Exit Sub
            End If

            If cboMucuutien.ItemIndex < 0 Or cboMucuutien.Text.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMucuutienNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cboMucuutien.Focus()
                Exit Sub
            End If

            If cboNguoilap.ItemIndex < 0 Or cboNguoilap.Text.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNguoilapNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cboNguoilap.Focus()
                Exit Sub
            End If
            'If mtxtGiohong.Text <> "  :" And Not IsDate(mtxtGiohong.Text) Then
            '    'MessageBox.Show("giờ hòng không hợp lệ")
            '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            '    mtxtGiohong.Text = "  :"
            '    mtxtGiohong.Focus()
            '    Exit Sub
            'End If
            'If dtpNgayhong.Text <> "  /  /" And Not IsDate(dtpNgayhong.Text) Then
            '    'MessageBox.Show("ngày hòng không hợp lệ")
            '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            '    dtpNgayhong.Text = "  /  /"
            '    dtpNgayhong.Focus()
            '    Exit Sub
            'End If
            'If txtDenGiohong.Text <> "  :" And Not IsDate(txtDenGiohong.Text) Then
            '    'MessageBox.Show("giờ hòng không hợp lệ")
            '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenGioHongKhongPhaiGio", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            '    txtDenGiohong.Text = "  :"
            '    txtDenGiohong.Focus()
            '    Exit Sub
            'End If
            'If dtpDenNgayhong.Text <> "  /  /" And Not IsDate(dtpDenNgayhong.Text) Then
            '    'MessageBox.Show("ngày hòng không hợp lệ")
            '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgayHongKhongPhaiNgay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            '    dtpDenNgayhong.Text = "  /  /"
            '    dtpDenNgayhong.Focus()
            '    Exit Sub
            'End If
            If dtpNgayBDKH.DateTime > dtpNgayKTKH.DateTime Then
                'MessageBox.Show("ngày kết thúc kế hoạch không được nhỏ hơn ngày bắt đầu kế hoạch")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKTKH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                dtpNgayKTKH.Focus()
                Exit Sub
            End If

            If dNgayBDKH.Month <> dtpNgayBDKH.DateTime.Month Then
                Dim sMs As String
                sMs = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(dtpNgayBDKH.DateTime.Year, dtpNgayBDKH.DateTime.Month)
                If txtMSPBT.Text <> txtSophieu.Text Then
                    txtMSPBT.Text = sMs
                Else
                    txtMSPBT.Text = sMs
                    txtSophieu.Text = sMs
                End If
            End If

            If txtLydo.Text.Trim = "" Or txtLydo.Text = String.Empty Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLydoNull", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                txtLydo.Focus()
                Exit Sub
            End If
            Dim objPHIEU_BAO_TRIInfo As New Commons.VS.Classes.Catalogue.clsPHIEU_BAO_TRIInfo()
            objPHIEU_BAO_TRIInfo.MS_PHIEU_BAO_TRI = txtMSPBT.Text
            objPHIEU_BAO_TRIInfo.SO_PHIEU_BAO_TRI = txtSophieu.Text
            objPHIEU_BAO_TRIInfo.TINH_TRANG_PBT = 2
            objPHIEU_BAO_TRIInfo.MS_MAY = cboMSThietbi.EditValue
            objPHIEU_BAO_TRIInfo.MS_LOAI_BT = cboLoaibt.EditValue
            objPHIEU_BAO_TRIInfo.NGAY_LAP = Format(dtpNgaylap.DateTime, "Short date")
            objPHIEU_BAO_TRIInfo.GIO_LAP = Format(mtxtGiolap.Text, "Long time")
            objPHIEU_BAO_TRIInfo.LY_DO_BT = txtLydo.Text
            objPHIEU_BAO_TRIInfo.MS_UU_TIEN = cboMucuutien.EditValue
            objPHIEU_BAO_TRIInfo.NGAY_BD_KH = Format(dtpNgayBDKH.DateTime, "Short date")
            objPHIEU_BAO_TRIInfo.NGAY_KT_KH = Format(dtpNgayKTKH.DateTime, "Short date")
            objPHIEU_BAO_TRIInfo.NGUOI_LAP = cboNguoilap.EditValue
            objPHIEU_BAO_TRIInfo.USERNAME_NGUOI_LAP = txtUsername.Text
            objPHIEU_BAO_TRIInfo.NGUOI_GIAM_SAT = cboGSVien.EditValue
            objPHIEU_BAO_TRIInfo.GIO_HONG = mtxtGiohong.Text
            objPHIEU_BAO_TRIInfo.NGAY_HONG = dtpNgayhong.Text
            objPHIEU_BAO_TRIInfo.DEN_GIO_HONG = txtDenGiohong.Text
            objPHIEU_BAO_TRIInfo.DEN_NGAY_HONG = dtpDenNgayhong.Text
            objPHIEU_BAO_TRIInfo.NGUYEN_NHAN = cmbNguyenNhan.EditValue
            Dim objPHIEU_BAO_TRIController As New clsPHIEU_BAO_TRIController()
            Dim MS_PBT As String = ""
            Dim str As String = ""
            str = objPHIEU_BAO_TRIController.AddPHIEU_BAO_TRI(objPHIEU_BAO_TRIInfo)
            If str <> "" Then
                Dim str1 As String = "UPDATE PHIEU_BAO_TRI SET UPDATE_NGAY_CUOI = '" & dtpNgayBDKH.DateTime.ToString("yyy/MM/dd") & "' WHERE MS_PHIEU_BAO_TRI='" & txtMSPBT.Text & "'"
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str1)
                Commons.Modules.SQLString = txtMSPBT.Text
                sNhanVienThucHien = cboGSVien.EditValue
                'insert vao PHIEU_BAO_TRI_CONG_VIEC
                If chkThemCV.Checked = True Then
                    Dim row As Int32
                    Try
                        row = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM " + sbtAll + ""))
                    Catch ex As Exception
                        row = 0
                    End Try
                    Try
                        If row > 0 Then
                            Try
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "Add_PhieuBaoTri_CongViec", txtMSPBT.EditValue, sbtAll, 1)
                            Catch ex As Exception
                            End Try
                        Else
                            'kiểm tra nếu không có talbe tampt thì ko làm gì cả
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "Add_PhieuBaoTri_CongViec", txtMSPBT.EditValue, "TEMPT" + Commons.Modules.UserName, 0)
                        End If
                    Catch ex As Exception
                    End Try
                End If
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Successfull!", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "khongtheinsert", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Private Sub AddsbtCongViec()
    '    Dim sbt As String = "TEMPT_CV" + Commons.Modules.UserName
    '    Try
    '        Commons.Modules.ObjSystems.XoaTable(sbt)
    '    Catch ex As Exception
    '    End Try
    '    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sbt, tabCongViec, "")
    'End Sub
    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Commons.Modules.SQLString = ""
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub VisibleCV()
        If bCoCV = True Then
            chkThemCV.Visible = True
            BtnChonCongViec.Visible = True
            chkThemCV.Checked = True
        Else
            chkThemCV.Visible = False
            BtnChonCongViec.Visible = False
            chkThemCV.Checked = False
        End If
    End Sub

    Private Sub frmLapphieubaotri_CS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLockMSMay Or Commons.Modules.SQLString = "frmYeuCauBT" Or Commons.Modules.SQLString = "frmReminder_new" Or Commons.Modules.SQLString = "frmReminder_newDCD" Then
            cboMSThietbi.Enabled = False
            VisibleCV()
        End If
        LoadCombo()
        mtxtGiolap.EditValue = Format(Now, "HH:mm")
        'mtxtGiohong.EditValue = Format(Now, "HH:mm")
        'txtDenGiohong.EditValue = Format(Now, "HH:mm")


        dtpNgaylap.DateTime = Now()
        dtpNgayBDKH.DateTime = dNgayBDKH
        'dtpNgayhong.DateTime = dNgayBDKH
        'dtpDenNgayhong.DateTime = dNgayKTKH
        dtpNgayKTKH.DateTime = dNgayKTKH
        If Not dNgayHong Is Nothing Then
            dtpNgayhong.DateTime = dNgayHong
        End If
        If Not dNgayHong Is Nothing Then
            mtxtGiohong.EditValue = Format(dGioHong, "HH:mm")
        End If

        If Commons.Modules.SQLString = "frmReminder_new" Then
            txtLydo.Text = "Hiệu chuẩn thiết bị"
        End If
        If Commons.Modules.SQLString = "frmReminder_newDCD" Then
            txtLydo.Text = "Hiệu chuẩn dụng cụ đo : " & sMsVatTu
        End If
        txtMSPBT.Text = New clsPHIEU_BAO_TRIController().Create_MS_PHIEU_BAO_TRI(dNgayBDKH.Year, dNgayBDKH.Month)
        If MS_MAY <> "" Then
            cboMSThietbi.EditValue = MS_MAY
        Else
            cboMSThietbi.EditValue = -1
        End If
        If MS_NGUYEN_NHAN <> "" Then
            cmbNguyenNhan.EditValue = MS_NGUYEN_NHAN
        Else
            cmbNguyenNhan.EditValue = -1
        End If
        cboLoaibt.EditValue = iMsLoaiBT
        cboMucuutien.EditValue = MucUuTien
        cboNguoilap.EditValue = -1
        cboGSVien.ItemIndex = -1
        txtUsername.Text = Commons.Modules.UserName

        cboNguoilap.EditValue = Commons.Modules.sMaNhanVienMD

        txtSophieu.Text = String.Empty

        If Commons.Modules.iDefault = 1 Then txtSophieu.Text = txtMSPBT.Text
        If Commons.Modules.iDefault = 2 Then
            txtSophieu.Text = txtMSPBT.Text
            txtSophieu.Properties.ReadOnly = True
        End If

        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        txtSophieu.Focus()

        Try
            Dim str As String = "SELECT ISNULL(MUC_UU_TIEN, 0) AS MUC_UU_TIEN FROM THONG_TIN_CHUNG"
            btnMucUuTienFlag = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str))

        Catch ex As Exception

        End Try

        If (btnMucUuTienFlag = False) Then
            btnMucUuTien.Visible = False
        Else
            btnMucUuTien.Visible = True
        End If
        Dim ToolTip1 As System.Windows.Forms.ToolTip = New System.Windows.Forms.ToolTip()
        ToolTip1.SetToolTip(btnMucUuTien, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "MucUuTienHint", Commons.Modules.TypeLanguage))

        If sLyDo <> "" Then txtLydo.Text = sLyDo
    End Sub
    Dim btnMucUuTienFlag = False

    Sub LoadCombo()
        Dim dtTmp As New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 2, Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboNguoilap, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "frmLapphieubaotri_CS")
        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_PQ", Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMSThietbi, dtTmp, "MS_MAY", "MS_MAY", "")


        Try
            dtTmp = New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_BAO_TRI_PBT_THEO_BTPN", cboMSThietbi.EditValue.ToString))

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaibt, dtTmp, "MS_LOAI_BT", "TEN_LOAI_BT", "")

        Catch ex As Exception
        End Try

        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMUC_UU_TIENs"))
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMucuutien, dtTmp, "MS_UU_TIEN", "TEN_UU_TIEN", "")

        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, Commons.Modules.UserName))
        Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboGSVien, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "frmLapphieubaotri_CS")


        Dim sql As String = "select MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN from nguyen_nhan_Dung_may ORDER BY TEN_NGUYEN_NHAN"
        dtTmp = New DataTable
        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
        Dim dr As DataRow = dtTmp.NewRow()
        dr("MS_NGUYEN_NHAN") = "-1"
        dr("TEN_NGUYEN_NHAN") = ""
        dtTmp.Rows.InsertAt(dr, 0)
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbNguyenNhan, dtTmp, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN", "")

    End Sub

    Private Sub dtpNgayKTKH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If btnThoat.Focused() Then
            Exit Sub
        End If
        If Date.Parse(dtpNgayKTKH.DateTime) < Date.Parse(dtpNgayBDKH.DateTime) Then
            'MessageBox.Show("ngày kết thúc kế hoạch không được nhỏ hơn ngày bắt đầu kế hoạch")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayKTKH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            dtpNgayKTKH.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub dtpNgayhong_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpNgayhong.Validating
        If btnThoat.Focused() Then
            Exit Sub
        End If
        If dtpNgayhong.Text <> "  /  /" Then
            If Not IsDate(dtpNgayhong.DateTime) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpNgayhong.DateTime = Now().AddHours(-1)
                dtpNgayhong.Focus()
                e.Cancel = True
                Exit Sub
            ElseIf Date.Parse(dtpNgayhong.DateTime) < Date.Parse("01/01/1900") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpNgayhong.DateTime = Now().AddHours(-1)
                dtpNgayhong.Focus()
                e.Cancel = True
                Exit Sub
            Else
                If Date.Parse(dtpNgayhong.DateTime) > Date.Parse(dtpNgaylap.DateTime) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayHongLonHonHienTai1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    dtpNgayhong.DateTime = Now().AddHours(-1)
                    dtpNgayhong.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub


    Private Sub dtpDenNgayhong_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDenNgayhong.Validating, dtpDenNgayhong.Validating
        If btnThoat.Focused() Then
            Exit Sub
        End If
        If dtpDenNgayhong.Text <> "  /  /" Then
            If Not IsDate(dtpDenNgayhong.DateTime) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpDenNgayhong.DateTime = Now().AddHours(-1)
                dtpDenNgayhong.Focus()
                e.Cancel = True
                Exit Sub
            ElseIf Date.Parse(dtpDenNgayhong.DateTime) < Date.Parse("01/01/1900") Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgayHong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                dtpDenNgayhong.DateTime = Now().AddHours(-1)
                dtpDenNgayhong.Focus()
                e.Cancel = True
                Exit Sub
            Else
                If Date.Parse(dtpDenNgayhong.DateTime) > Date.Parse(dtpNgaylap.DateTime) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDenNgayHongLonHonHienTai1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    dtpDenNgayhong.DateTime = Now().AddHours(-1)
                    dtpDenNgayhong.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub mtxtGiolap_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtGiolap.Validating
        If mtxtGiolap.Text <> "  :" Then
            If Not IsDate(mtxtGiolap.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                mtxtGiolap.Text = "  :"
                mtxtGiolap.Focus()
                e.Cancel = True

            End If
        End If
    End Sub

    Private Sub dtpNgaylap_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpNgaylap.Validating
        If btnThoat.Focused() Then
            Exit Sub
        End If
        If Date.Parse(dtpNgaylap.DateTime) > Now() Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            dtpNgaylap.Focus()
            e.Cancel = True

        End If
    End Sub

    Private Sub txtSophieu_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSophieu.Validated
        If txtSophieu.Text.Trim() <> "" Then
            Dim sophieu As DataTable = New DataTable()
            sophieu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select * from PHIEU_BAO_TRI where SO_PHIEU_BAO_TRI = '" & txtSophieu.Text.Trim() & "'"))
            If (sophieu.Rows.Count > 0) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Sophieubaotridatontai", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                txtSophieu.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cboMSThietbi_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboMSThietbi.Validating
        Try
            cboLoaibt.Properties.DataSource = Nothing
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_BAO_TRI_PBT_THEO_BTPN", cboMSThietbi.EditValue.ToString))
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaibt, dtTmp, "MS_LOAI_BT", "TEN_LOAI_BT", "")
        Catch ex As Exception
        End Try


    End Sub


    Private Sub btnMucUuTien_Click(sender As Object, e As EventArgs) Handles btnMucUuTien.Click
        Try
            Dim Str As String = "SELECT ISNULL(SO_NGAY_PHAI_BD, 0) AS SO_NGAY_PHAI_BD ,  ISNULL(SO_NGAY_PHAI_KT, 0) AS SO_NGAY_PHAI_KT FROM MUC_UU_TIEN WHERE MS_UU_TIEN = " & cboMucuutien.EditValue
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Str))

            dtpNgayBDKH.DateTime = dtpNgaylap.DateTime.AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_BD")))
            dtpNgayKTKH.DateTime = dtpNgaylap.DateTime.AddDays(Convert.ToInt32(dt.Rows(0)("SO_NGAY_PHAI_KT")))
        Catch
            dtpNgayBDKH.DateTime = dtpNgaylap.DateTime
            dtpNgayKTKH.DateTime = dtpNgaylap.DateTime
        End Try
    End Sub

    Private Sub cboMSThietbi_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboMSThietbi.ButtonClick
        If e.Button.Index = 1 Then
            Dim frm As New ReportMain.Forms.frmYCSDChonMay()
            frm.iLoai = 2
            If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
            cboMSThietbi.EditValue = Commons.Modules.SQLString
        End If
    End Sub

    Private Sub btnViewCV_Click(sender As Object, e As EventArgs) Handles BtnChonCongViec.Click
        Dim frm As New frmDanhSach_CV()
        frm.ShowDialog()
    End Sub
    Private Sub chkThemCV_CheckedChanged(sender As Object, e As EventArgs) Handles chkThemCV.CheckedChanged
        If chkThemCV.Checked = True Then
            BtnChonCongViec.Visible = True
        Else
            BtnChonCongViec.Visible = False
        End If

    End Sub
End Class