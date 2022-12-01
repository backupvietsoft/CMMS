Imports System.IO
Imports System.Threading
Imports System.Timers
Imports DevExpress.XtraEditors
Imports Microsoft.ApplicationBlocks.Data
Imports Microsoft.Win32
Imports VS.Object
Imports System.Security.Permissions

Public Class frmMain
    Dim iLic As Integer
    Public aTimer As Timers.Timer
    Public Shared sDataLog As String
    Public Shared sCty As String
    Dim mf As New MessageFilter
    Public _wentIdle As DateTime = DateTime.Now
    Dim iTimeEnd As Integer = 0
    Public iKiemLic As Boolean = True

    Public Class MessageFilter
        Implements IMessageFilter

        <SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
        Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements IMessageFilter.PreFilterMessage
            Try
                If isUserInput(m) Then
                    frmMain._wentIdle = DateTime.Now
                End If
            Catch ex As Exception
            End Try

            Return False
        End Function
        Private Function isUserInput(ByVal m As Message) As Boolean
            If m.Msg = &H200 Then Return True   'WM_MOUSEMOVE
            If m.Msg = &H20A Then Return True   'WM_MOUSEWHEEL
            If m.Msg = &H100 Then Return True   'WM_KEYDOWN
            If m.Msg = &H101 Then Return True   'WM_KEYUP


            Return False
        End Function
    End Class


    Private Sub OnTimedEvent(source As Object, e As System.Timers.ElapsedEventArgs)
        Try
#Region "Kiem 30 phut thoat phan mem "
            Try
                Dim diff As TimeSpan = DateTime.Now - _wentIdle
                If diff.TotalMinutes >= iTimeEnd Then
                    aTimer.Stop()
                    aTimer.Enabled = False
                    iKiemLic = False
                    Application.RemoveMessageFilter(mf)
                    Application.ExitThread()

                    For Each frmChild As Form In Me.MdiChildren
                        frmChild.Close()
                    Next
                    Try
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
                    Catch
                    End Try

                    Dim iLogin As DialogResult
                    Me.Invoke(New Action(Sub()
                                             Dim frm = New frmLogin
                                             iLogin = frm.ShowDialog(Me)
                                         End Sub
                        ))


                    If iLogin = Windows.Forms.DialogResult.Cancel Or iLogin = Windows.Forms.DialogResult.No Then
                        Application.RemoveMessageFilter(mf)
                        Application.ExitThread()
                        Application.Exit()
                    End If
                    If Commons.Modules.UserName.Trim.Equals(String.Empty) Then
                        Application.RemoveMessageFilter(mf)
                        Application.ExitThread()
                        Application.Exit()
                    End If
                    Commons.Modules.SQLString = ""
                    If iLogin = Windows.Forms.DialogResult.OK Then
                        Dim t As New Thread(New ThreadStart(AddressOf CallTimerLogin))
                        t.Start()
                        Application.AddMessageFilter(mf)
                        iKiemLic = True
                    End If
                End If
            Catch ex As Exception

                Try
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_UPDATE_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
                Catch
                End Try
            End Try

#End Region
            If iKiemLic = False Then Exit Sub

            If Commons.Modules.UserName.Trim.Equals(String.Empty) Then
                aTimer.Enabled = False
                Me.Invoke(New Action(Sub() MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgUserKhongTonTaiHayBiXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)))
                End
            End If
            '--1) Vượt quá: khi số lượng truy cập lớn hơn quy định
            '--2) Khong ton tai: Khi truy vấn user đó k có trong login (đề phòng xóa)
            '--3) Không hợp lệ: Khi truy vấn user đó có trong login nhung lon hon 1
            '--4)Không kết nối dc với server: Khi k kết nối được hoặc time out
            Dim sSql As String = ""

            sSql = "	IF (( SELECT SUM(SL) FROM (" & sDataLog.Replace("CBOLICCOM", Commons.Modules.LicensePro.ToString()) & ") T1 ) > " & Commons.Modules.ObjSystems.Licences(Commons.Modules.UserName) & " ) " &
                        "		SELECT 1 " &
                        "	ELSE " &
                        "		BEGIN " &
                        "			IF NOT EXISTS(SELECT * FROM [LOGIN] WHERE USER_LOGIN = '" & Commons.Modules.UserName & "' AND ID = " & Commons.Modules.LicensePro & " )  " &
                        "				SELECT 2	 " &
                        "			ELSE " &
                        "				IF (SELECT COUNT (*) FROM [LOGIN]  WHERE USER_LOGIN = '" & Commons.Modules.UserName & "' AND ID = " & Commons.Modules.LicensePro & " ) > 1  SELECT 3 ELSE SELECT 0 " &
                        "		END "

            sSql = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            If Integer.Parse(sSql) = 0 Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_UPDATE_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
            Else
                aTimer.Enabled = False
                Application.RemoveMessageFilter(mf)
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
                If Integer.Parse(sSql) = 1 Then
                    Me.Invoke(New Action(Sub() MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgOutOfLicences", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)))
                Else
                    If Integer.Parse(sSql) = 2 Then
                        Me.Invoke(New Action(Sub() MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgUserKhongTonTaiHayBiXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)))

                    Else
                        Me.Invoke(New Action(Sub() MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgUserKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)))
                    End If
                End If
                End
            End If

        Catch ex As Exception
            aTimer.Enabled = False
            Application.RemoveMessageFilter(mf)

            Me.Invoke(New Action(Sub() MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "msgMatKetNoiVoiServer", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)))
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
            Catch
            End Try
            End
        End Try
        ThongTinDangNhap()


    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Try
                iTimeEnd = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ISNULL(TIME_END,0) FROM dbo.THONG_TIN_CHUNG"))
            Catch ex As Exception
                iTimeEnd = 0
            End Try
            If iTimeEnd = 0 Then iTimeEnd = 30
            Dim strDate As String = Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
            Dim strTime As String = Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sTimeFormat", "HH:mm:ss")
            If UCase(strDate) <> "DD/MM/YYYY" Then Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
            If UCase(strTime) <> "HH:MM:SS" Then Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sTimeFormat", "HH:mm:ss")
            strDate = Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
            strTime = Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sTimeFormat", "HH:mm:ss")
            If Not String.Equals(strDate, "dd/MM/yyyy", StringComparison.OrdinalIgnoreCase) Or Not String.Equals(strTime, "HH:mm:ss", StringComparison.OrdinalIgnoreCase) Then
                MsgBox("User đăng nhập không có quyền thay đổi hệ thống!" & vbCrLf & "Bạn vui lòng liện hệ với người quản trị để được hướng dẫn.", MsgBoxStyle.Exclamation)
                End
            End If
        Catch ex As Exception
            MsgBox("User đăng nhập không có quyền thay đổi hệ thống!" & vbCrLf & "Bạn vui lòng liện hệ với người quản trị để được hướng dẫn.", MsgBoxStyle.Exclamation)
            End
        End Try
        If Commons.Modules.LicDemo = True Then
            Dim fInfo As New FileInfo(System.Windows.Forms.Application.StartupPath & "\CMMS.exe")
            Dim dateMod As Date = fInfo.LastWriteTime.Date
            If DateDiff(DateInterval.Day, Now.Date, CDate(Commons.Modules.DemoDate)) < 0 Then
                MsgBox("Thời hạn chạy phiên bản dùng thử đã hết " & Application.ProductName & vbCrLf & vbCrLf & "Bạn vui lòng liên hệ với nhà cung cấp để được hướng dẫn.", MsgBoxStyle.Exclamation)
                End
            ElseIf DateDiff(DateInterval.Day, CDate(dateMod), Now.Date) < 0 Then
                MsgBox("Thời hạn chạy phiên bản dùng thử đã hết " & Application.ProductName & vbCrLf & vbCrLf & "Bạn vui lòng liên hệ với nhà cung cấp để được hướng dẫn.", MsgBoxStyle.Exclamation)
                End
            End If
        End If
        iLic = Commons.Modules.ObjSystems.MGetLicUser(Commons.Modules.UserName)
        PictureEdit1.EditValue = My.Resources.Eco_VICT
        PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        'Application.AddMessageFilter(mf)

    End Sub
    Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
        aTimer.Stop()
        Application.RemoveMessageFilter(mf)
        MyBase.OnFormClosed(e)

    End Sub

    ' Set quyền trên menu
    Public Shared Sub UserPermission(ByVal sUserName As String)
        Dim _Menu As MenuCtrl = New MenuCtrl()
        _Menu.LoadMenu()
    End Sub
    'Đóng form
    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            If Commons.Modules.UserName.Trim = "" Then End
            For Each frmChild As Form In Me.MdiChildren
                If (frmThongtinthietbi.Name.Trim().Equals(frmChild.Name.Trim())) Then
                    If frmThongtinthietbi.BtnGhi.Visible = True Then
                        e.Cancel = True
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If
            Next

            If Commons.Modules.SQLString = "iLoad" Then
                GoTo 1
            End If

            If (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name,
                        "MsgExitApp", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
1:
                Try
                    'Đóng OEE
                    Dim processlist As Process() = Process.GetProcessesByName("OEE")
                    For Each theprocess As Process In processlist
                        Try
                            theprocess.CloseMainWindow()
                        Catch ex As Exception
                        End Try
                    Next
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro)
                    aTimer.Enabled = False
                    Application.RemoveMessageFilter(mf)
                    Application.ExitThread()
                    End
                Catch ex As Exception
                End Try
            Else
                e.Cancel = True
                Exit Sub
            End If
            If (Commons.Modules.UserName <> "") Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spDelete_Table_Tmp", "", Commons.Modules.UserName, Commons.Modules.LicensePro)
            End If
        Catch ex As Exception
            aTimer.Enabled = False
            Application.RemoveMessageFilter(mf)
            Application.ExitThread()
        End Try
    End Sub

    Private Sub MnTop_ItemAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemEventArgs)
        If (e.Item.Text.Trim().Equals(String.Empty)) Then
            e.Item.Visible = False
        End If
    End Sub

    'Đăng nhập
    Public Shared Function LogIn() As Boolean
        Try
            Dim sUser = Commons.Modules.UserName
            'frmMain.aTimer.Enabled = False

            Dim iLogin As DialogResult
            iLogin = frmLogin.ShowDialog()
            If iLogin = Windows.Forms.DialogResult.Cancel Then
                Commons.Modules.UserName = sUser
                'frmMain.aTimer.Enabled = True
                Return False
                Exit Function
            End If
            If iLogin = Windows.Forms.DialogResult.No Then End
            If sUser <> Commons.Modules.UserName Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SP_DELETE_LOGIN", sUser, Commons.Modules.LicensePro)
            End If
            'frmMain.aTimer.Enabled = True

            If Commons.Modules.UserName.Trim.Equals(String.Empty) Then End
            TaoThongTinBar()

            VietShape.Modules.TypeLanguage = Commons.Modules.TypeLanguage
            VietShape.Modules.UserName = Commons.Modules.UserName
            VietShape.Modules.ConnectionString = Commons.IConnections.ConnectionString
            UserPermission(Commons.Modules.UserName)
            Vietsoft.Information.ModuleName = Commons.Modules.ModuleName
            Vietsoft.Information.Language = Commons.Modules.TypeLanguage
            Vietsoft.Information.ConnectionString = Commons.IConnections.ConnectionString()
            Vietsoft.Information.Username = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT FULL_NAME FROM dbo.USERS WHERE USERNAME = N'" + Commons.Modules.UserName + "'"), String)

            For Each frmChild As Form In frmMain.MdiChildren
                frmChild.Close()
            Next
            ShowForm(frmMLog)
            ShowShape()
            frmMLog.Close()

            Vietsoft.Information.UserID = Commons.Modules.UserName
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowNgayNhaXuong() As Boolean
        Try
            Dim frm As MVControl.frmNgayNghiTheoNhaXuong = New MVControl.frmNgayNghiTheoNhaXuong()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show KHTT new
    Public Shared Function ShowKHBT() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmKehoachtongtheNew.Name) Then
                ShowForm(frmKehoachtongtheNew)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    'Show phân bổ cho bộ phận chịu phí Synchronize
    Public Shared Function ShowPhanBoChoBPCPSyn() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmAllocateVTPTForBPCP.Name) Then
                ShowForm(frmAllocateVTPTForBPCP)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Show bộ phận chịu phí
    Public Shared Function ShowChiuPhi() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmBophanchiuphi.Name) Then
                ShowForm(frmBophanchiuphi)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function ShowVatTuPhuTung() As Boolean
        Try
            Dim frmVatTuPhuTung As ReportMain.frmVatTuPhuTung = New ReportMain.frmVatTuPhuTung()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmVatTuPhuTung.Name) Then
                ShowForm(frmVatTuPhuTung)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Shared Function ShowPhanCongBaoTri() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmPhanCongBaoTri.Name) Then
                ShowForm(frmPhanCongBaoTri)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shared Function ShowThamDinhTB() As Boolean
        Try

            Report1.cls_DataProvider.ketNoi = Commons.IConnections.ConnectionString()
            Dim frmThamDinh As Report1.Frm_Tham_Dinh_TB = New Report1.Frm_Tham_Dinh_TB
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmThamDinh.Name) Then
                ShowForm(frmThamDinh)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Show tỉ giá
    Public Shared Function ShowTiGia() As Boolean
        Try
            'Dim frmTigia As frmBangtygia = New frmBangtygia()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmBangtygia.Name) Then
                ShowForm(frmBangtygia)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show loại nhóm thiết bị
    Public Shared Function ShowLoaiNhomTB() As Boolean
        Try
            Dim frmThietBi As Report1.frmThietBi = New Report1.frmThietBi()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmThietBi.Name) Then
                ShowForm(frmThietBi)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Danh mục công việc
    Public Shared Function LoadDanhMucCongViec() As Boolean
        Try
            Dim frmDanhmuccongviec As MVControl.frmDanhmuccongviec = New MVControl.frmDanhmuccongviec()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDanhmuccongviec.Name) Then
                ShowForm(frmDanhmuccongviec)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show loại bảo trì
    Public Shared Function ShowBaoTri() As Boolean
        Try
            Dim frmBaoTri = New MVControl.frmBaoTri()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmBaoTri.Name) Then
                ShowForm(frmBaoTri)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show đơn vị đo
    Public Shared Function ShowDonViDo() As Boolean
        Try
            Dim frmDVD As Report1.frmDonvido = New Report1.frmDonvido()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDVD.Name) Then
                ShowForm(frmDVD)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowKeHoachSX() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmKeHoachSX.Name) Then
                ShowForm(frmKeHoachSX)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowKeHoachSanXuat() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmKeHoachSanXuat.Name) Then
                ShowForm(frmKeHoachSanXuat)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Phiếu bảo trì ChangShin
    Public Shared Function ShowPhieuBaoTri_DHG() As Boolean
        Try
            ' FrmPhieuBaoTri_DHG.Name = "FrmPhieuBaoTri_DHG"
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuBaoTri_DHG.Name) Then
                ShowForm(FrmPhieuBaoTri_DHG)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Danh mục phụ tùng
    Public Shared Function LoadDanhMucPhuTung_CS() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDanhmucphutung_CS.Name) Then
                ShowForm(frmDanhmucphutung_CS)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Đề xuất mua hàng ChangShin
    Public Shared Function ShowDeXuatMuaHang_CS() As Boolean
        Try
            Dim frmDeXuatMuaHang_CS As Report1.frmDeXuatMuaHang_CS = New Report1.frmDeXuatMuaHang_CS()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDeXuatMuaHang_CS.Name) Then
                ShowForm(frmDeXuatMuaHang_CS)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowDeXuatMuaHang_New() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDeXuatMuaHang.Name) Then
                Dim frmDeXuatMuaHang As WareHouse.frmDeXuatMuaHang_New = New WareHouse.frmDeXuatMuaHang_New()
                ShowForm(frmDeXuatMuaHang)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowAbout() As Boolean
        Try
            System.Diagnostics.Process.Start("http://www.vietsoft.com.vn")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function CheckUpdate() As Boolean
        'If KiemUpDate() = True Then
        '    CMMS_Main.CapNhapPM()
        'Else
        '    If (XtraMessageBox.Show("Bạn có muốn cập nhật lại?", "", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
        '        CMMS_Main.CapNhapPM()
        '    End If
        'End If
        CMMS_Main.CheckUpdate(1)
        Return True
    End Function

    'Bộ phận Chịu phí ChangShin
    Public Shared Function ShowChiuPhi_CS() As Boolean
        Try

            'If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmBophanchiuphi_cs.Name) Then
            'ShowForm(frmBophanchiuphi_cs)
            'End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Phiếu xuất kho vật tư ChangShin
    Public Shared Function ShowPhieuXuatKho_CS() As Boolean
        Try
            Dim frm As New MReportVB.FrmPhieuXuatKhoVatTu_CS
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Phiếu bảo trì ChangShin
    Public Shared Function ShowPhieuBaoTri_CS() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuBaoTri_CS.Name) Then
                ShowForm(FrmPhieuBaoTri_CS)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Di chuyển thiết bị
    Public Shared Function ShowDiChuyenThietBi() As Boolean
        Try
            Dim FrmDiChuyenThietBi As Report1.FrmDiChuyenThietBi = New Report1.FrmDiChuyenThietBi()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmDiChuyenThietBi.Name) Then
                ShowForm(FrmDiChuyenThietBi)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'nhập xác
    Public Shared Function ShowPhieuNhapXac() As Boolean
        Try
            ' If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, Iventory.frmGoodreceive.Name) Then
            Dim frmNhapXac As WareHouse.frmGoodreceive = New WareHouse.frmGoodreceive()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmNhapXac.Name) Then
                ShowForm(frmNhapXac)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'xuat xác
    Public Shared Function ShowPhieuXuatXac() As Boolean
        Try
            ' If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, Iventory.frmGoodreceive.Name) Then
            Dim frmXuatXac As WareHouse.frmGoodreturn = New WareHouse.frmGoodreturn()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmXuatXac.Name) Then
                ShowForm(frmXuatXac)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ' export excel
    Public Shared Function ShowExportExcel() As Boolean
        Try
            ' If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, Iventory.frmGoodreceive.Name) Then
            Dim frmExport As ExportExcels.frmExportExcel = New ExportExcels.frmExportExcel()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmExport.Name) Then
                ShowForm(frmExport)
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ' import excel
    Public Shared Function ShowImportExcel() As Boolean
        Try
            ' If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, Iventory.frmGoodreceive.Name) Then
            Dim frmImport As ImportExcels.frmImportExcel = New ImportExcels.frmImportExcel()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmImport.Name) Then
                ShowForm(frmImport)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Don dat hang Chang shin
    Public Shared Function ShowDonDatHang_CS() As Boolean
        Try

            Dim frmDonDatHang_CS As Report1.frmDonDatHang_CS = New Report1.frmDonDatHang_CS()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDonDatHang_CS.Name) Then
                ShowForm(frmDonDatHang_CS)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowDonDatHang_New() As Boolean
        Try
            Dim frmDonDatHang As WareHouse.frmDonDatHang_New = New WareHouse.frmDonDatHang_New()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDonDatHang") Then
                ShowForm(frmDonDatHang)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowQuyTrinhDuyetTL() As Boolean
        Try
            Vietsoft.Information.ConnectionString = Commons.IConnections.ConnectionString()
            Vietsoft.Information.Username = Commons.Modules.UserName
            Vietsoft.Information.Language = Commons.Modules.TypeLanguage
            Vietsoft.Information.ModuleName = Commons.Modules.ModuleName
            Dim frmTaiLieu As WareHouse.frmTaiLieu = New WareHouse.frmTaiLieu()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmTaiLieu.Name) Then
                ShowForm(frmTaiLieu)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Phiếu bảo trì KiDo
    Public Shared Function ShowPhieuBaoTri_KIDO() As Boolean
        Try
            FrmPhieuBaoTri_KIDO.Name = "FrmPhieuBaoTri_KIDO"
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuBaoTri_KIDO.Name) Then
                ShowForm(FrmPhieuBaoTri_KIDO)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowPhieuNhapKho_BDL() As Boolean
        Try
            'Dim frmPhieuNhap As FrmPhieuNhapKhoVatTu_BDL = New FrmPhieuNhapKhoVatTu_BDL()
            FrmPhieuNhapKhoVatTu_BDL.Name = "FrmPhieuNhapKhoVatTu_BDL"
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuNhapKhoVatTu_BDL.Name) Then
                ShowForm(FrmPhieuNhapKhoVatTu_BDL)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'SHOW Form Thoi gian ngung may 
    Public Shared Function ShowThoiGianNgungMay() As Boolean
        Try
            Dim frm As New MVControl.frmThoigianngungmayNEW
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'SHOW Form Thoi gian ngung may new
    Public Shared Function ShowThoiGianNgungMayNew() As Boolean
        Try



            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDowntime") Then
                Dim frm As New MVControl.frmThoigianngungmayNEW
                ShowForm(frm)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show đơn vị tính
    Public Shared Function ShowDVT() As Boolean
        Try
            Dim frmDVT As Report1.frmDonvitinh = New Report1.frmDonvitinh()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDVT.Name) Then
                ShowForm(frmDVT)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show nha cung cấp
    Public Shared Function ShowNhaCungCap() As Boolean
        Try
            Dim frmNhacungcap As Report1.frmNhacungcap = New Report1.frmNhacungcap()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmNhacungcap.Name) Then
                ShowForm(frmNhacungcap)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    'Show thông tin thiết bị
    Public Shared Function ShowThongTinThietBi() As Boolean
        If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmThongtinthietbi") Then
            ShowForm(frmThongtinthietbi)
        End If
    End Function

    Public Shared Function OpenThongKeVatTu()
        Try
            Dim frmThongKe As ImportExcels.frmThongKeVatTu = New ImportExcels.frmThongKeVatTu()
            For Each frmChild As Form In frmMain.MdiChildren
                If (frmThongKe.Name.Trim().Equals(frmChild.Name.Trim())) Then
                    frmChild.Close()
                    Exit For
                End If
            Next
            frmThongKe.MsNX = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
            frmThongKe.TenNX = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Text
            ShowForm(frmThongKe)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function OpenMaintenance()
        Try
            Dim frm As ReportHuda.General.frmMaintenance = New ReportHuda.General.frmMaintenance()
            For Each frmChild As Form In frmMain.MdiChildren
                If (frm.Name.Trim().Equals(frmChild.Name.Trim())) Then
                    frmChild.Close()
                    Exit For
                End If
            Next
            frm.ms_thiet_bi = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
            ShowForm(frm)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function OpenMaterialStatistical()
        Try
            Dim frm As ReportHuda.General.frmMaterialStatistical = New ReportHuda.General.frmMaterialStatistical()
            For Each frmChild As Form In frmMain.MdiChildren
                If (frm.Name.Trim().Equals(frmChild.Name.Trim())) Then
                    frmChild.Close()
                    Exit For
                End If
            Next
            frm.ms_thiet_bi = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
            ShowForm(frm)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function OpenFactoryStatistical()
        Try
            Dim frm As ReportHuda.General.frmFactoryStatistical = New ReportHuda.General.frmFactoryStatistical()
            For Each frmChild As Form In frmMain.MdiChildren
                If (frm.Name.Trim().Equals(frmChild.Name.Trim())) Then
                    frmChild.Close()
                    Exit For
                End If
            Next
            frm.ms_n_xuong = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
            ShowForm(frm)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function OpenThongTinThietBi()
        Try
            'If (VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(0, 3) = "MY-") Then
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmThongtinthietbi") Then
                For Each frmChild As Form In frmMain.MdiChildren
                    If frmChild.Name = frmThongtinthietbi.Name Then
                        frmChild.Close()
                        Return True
                        Exit For
                    End If
                Next
                frmThongtinthietbi.MS_MAY_CHOICE = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
                frmThongtinthietbi.TAB_INDEX_CHOICE = 0
                ShowForm(frmThongtinthietbi)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shared Function OpenTaiLieuTB()
        Try
            'If (VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(0, 3) = "MY-") Then
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmThongtinthietbi") Then
                For Each frmChild As Form In frmMain.MdiChildren
                    If frmChild.Name = frmThongtinthietbi.Name Then
                        frmChild.Close()
                        Return True
                        Exit For
                    End If
                Next
                frmThongtinthietbi.MS_MAY_CHOICE = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
                frmThongtinthietbi.TAB_INDEX_CHOICE = 4
                ShowForm(frmThongtinthietbi)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function OpenThoiGianNgungMay()
        Try
            'If (VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(0, 3) = "MY-") Then
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDowntime") Then
                For Each frmChild As Form In frmMain.MdiChildren
                    If frmChild.Name = frmThoiGianNgungMayNew.Name Then
                        frmChild.Close()
                        Exit For
                    End If
                Next
                frmThoiGianNgungMayNew.MS_MAY = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
                'frmThoiGianNgungMayNew.MS_MAY = VietShape.Modules.IXtraShape.menuMay.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.menuMay.SourceControl.Name.Length - 3)
                ShowForm(frmThoiGianNgungMayNew)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function OpenPhieuBaoTri()
        Try
            'If (VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(0, 3) = "MY-") Then
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "FrmPhieuBaoTri_New") Then
                For Each frmChild As Form In frmMain.MdiChildren
                    If frmChild.Name = FrmPhieuBaoTri_New.Name Then
                        frmChild.Close()
                        Exit For
                    End If
                Next
                FrmPhieuBaoTri_New.MS_MAY = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
                ShowForm(FrmPhieuBaoTri_New)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function OpenLichSuTB()
        Try
            'If (VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(0, 3) = "MY-") Then
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "FrmLichSuThietBi") Then
                For Each frmChild As Form In frmMain.MdiChildren
                    If frmChild.Name = FrmLichSuThietBi.Name Then
                        frmChild.Close()
                        Exit For
                    End If
                Next
                FrmLichSuThietBi.MS_MAY = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
                ShowForm(FrmLichSuThietBi)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show nhân viên
    Public Shared Function ShowNhanVien() As Boolean
        Try
            Dim frmNhanvien As MVControl.frmQuanlynhanvien = New MVControl.frmQuanlynhanvien()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmQuanlynhanvien") Then
                ShowForm(frmNhanvien)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show đơn vị sử dụng
    Public Shared Function ShowDonViSuDung() As Boolean
        Try
            Dim frmDonvi As Report1.frmDanhmucdonvi = New Report1.frmDanhmucdonvi()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDonvi.Name) Then
                ShowForm(frmDonvi)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Sub ShowmnuOEE(frm As String, title As String)
        Dim processlist As Process() = Process.GetProcessesByName("OEE")
        If processlist.Length = 0 Then
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\OEE\\OEE.exe", frm)
            Exit Sub
        End If
        Dim flag As Boolean = True
        For Each theprocess As Process In processlist
            Try
                If theprocess.MainWindowTitle.ToString() = title Then
                    flag = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
        If flag = True Then
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\OEE\\OEE.exe", frm)
        End If
    End Sub
    Public Shared Function LoadDonViTinhOEE() As Boolean
        ShowmnuOEE("mnuUOM", Commons.Modules.GetNNgu("ucUOM", "ucUOM"))
    End Function

    Public Shared Function LoadNhomMatHangOEE() As Boolean
        ShowmnuOEE("mnuItemGroup", Commons.Modules.GetNNgu("ucItemGroup", "ucItemGroup"))
    End Function

    Public Shared Function LoadNhomQuyDoiOEE() As Boolean
        ShowmnuOEE("mnuUOMConversionGroup", Commons.Modules.GetNNgu("ucUOMGroup", "ucUOMGroup"))
    End Function
    Public Shared Function LoadDinhMucNgungMay() As Boolean
        ShowmnuOEE("mnuDevicesCause", Commons.Modules.GetNNgu("ucDeviceCause", "ucDeviceCause"))
    End Function

    Public Shared Function LoadNhaDieuHanhOEE() As Boolean
        ShowmnuOEE("mnuOpreator", Commons.Modules.GetNNgu("ucOpreator", "ucOpreator"))
    End Function

    Public Shared Function ShowItemMay() As Boolean
        ShowmnuOEE("mnuItemDevices", Commons.Modules.GetNNgu("ucItemMay", "ucItemMay"))
    End Function

    Public Shared Function ShowLenhSanXuatTheoMay() As Boolean
        ShowmnuOEE("mnuProductionOrder", Commons.Modules.GetNNgu("ucProductOrder", "ucProductOrder"))
    End Function

    Public Shared Function ShowLenhSanXuatThucTe() As Boolean
        ShowmnuOEE("mnuProductionRun", Commons.Modules.GetNNgu("ucProductRun", "ucProductRun"))
    End Function

    Public Shared Function ShowLoaiNgungMay() As Boolean
        ShowmnuOEE("mnuDowntimeType ", Commons.Modules.GetNNgu("ucDownTimeType", "ucDownTimeType"))
    End Function

    Public Shared Function ShowNguyenNhanNgungMay() As Boolean
        ShowmnuOEE("mnuDowntimeCause", Commons.Modules.GetNNgu("ucDownTimeCause", "ucDownTimeCause"))
    End Function

    Public Shared Function ShowHieuXuatTheoNam() As Boolean
        ShowmnuOEE("mnuTarget", Commons.Modules.GetNNgu("mnuTarget", "mnuTarget"))
    End Function

    Public Shared Function ShowBaoCaoOEE() As Boolean
        ShowmnuOEE("mnuBaoCaoOEE", Commons.Modules.GetNNgu("mnuBaoCaoOEE", "mnuBaoCaoOEE"))
    End Function

    'Ngôn ngữ tiếng việt
    Public Shared Function LanguageVietNam() As Boolean
        Try
            If Commons.Modules.TypeLanguage = 0 Then Exit Function
            Commons.Modules.TypeLanguage = 0
            VietShape.Modules.TypeLanguage = Commons.Modules.TypeLanguage
            Vietsoft.Information.Language = Commons.Modules.TypeLanguage
            UserPermission(Commons.Modules.UserName)
            For Each vFrm As Form In frmMain.MdiChildren
                Commons.Modules.ObjSystems.ThayDoiNN(vFrm)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Ngôn ngữ tiếng anh 
    Public Shared Function LanguageEnglish() As Boolean
        Try
            If Commons.Modules.TypeLanguage = 1 Then Exit Function
            Commons.Modules.TypeLanguage = 1
            VietShape.Modules.TypeLanguage = Commons.Modules.TypeLanguage
            Vietsoft.Information.Language = Commons.Modules.TypeLanguage
            UserPermission(Commons.Modules.UserName)
            For Each vFrm As Form In frmMain.MdiChildren
                Commons.Modules.ObjSystems.ThayDoiNN(vFrm)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function LanguageChinese() As Boolean
        Try
            Commons.Modules.TypeLanguage = 2
            VietShape.Modules.TypeLanguage = Commons.Modules.TypeLanguage
            Vietsoft.Information.Language = Commons.Modules.TypeLanguage
            UserPermission(Commons.Modules.UserName)
            For Each vFrm As Form In frmMain.MdiChildren
                'ClsMain.SetLanguageForm(vFrm)
                Commons.Modules.ObjSystems.ThayDoiNN(vFrm)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Thoát chương trình
    Public Shared Function ExitSystem() As Boolean
        Try
            frmMain.Close()
        Catch ex As Exception
            Return False
            frmMain.Close()
        End Try

    End Function
    'Show kế hoạch công việc
    Public Shared Function ShowKeHoachCongViec() As Boolean
        Try
            Dim frmKHCV As MVControl.frmKeHoachCongViec = New MVControl.frmKeHoachCongViec()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmKHCV.Name) Then
                ShowForm(frmKHCV)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show giám sát tình trạng
    Public Shared Function ShowGiamSatTT() As Boolean
        Try
            Dim frmGSTT As MVControl.frmGiamsattinhtrang = New MVControl.frmGiamsattinhtrang()
            'frmGSTT.Bar
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmGSTT.Name) Then
                ShowForm(frmGSTT)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show hiệu chuẩn và kiểm định
    Public Shared Function ShowHieuChuanKiemDinh() As Boolean
        Try
            'Dim frmHC As frmHieuchuan = New frmHieuchuan()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmHieuchuan.Name) Then
                ShowForm(frmHieuchuan)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Show hiệu chuẩn và kiểm định
    Public Shared Function ShowGiayPhep() As Boolean
        Try
            Dim frmKVGH As ReportMain.frmKhuVucGioiHan = New ReportMain.frmKhuVucGioiHan()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmKVGH.Name) Then
                ShowForm(frmKVGH)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Show hiệu chuẩn và kiểm định
    Public Shared Function ShowTamXuatTaiNhap() As Boolean
        Try
            Dim frmTXTN As ReportMain.frmPhieuTamXuatTaiNhap = New ReportMain.frmPhieuTamXuatTaiNhap()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmTXTN.Name) Then
                ShowForm(frmTXTN)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Show kế hoạch tổng thể
    Public Shared Function ShowKeHoachTT() As Boolean
        Try
            'Dim frmKHTT As frmkehoachtongthe = New frmkehoachtongthe()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmKehoachtongthe") Then
                ShowForm(frmKehoachtongthe_odd)
            End If
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    'Show yêu cầu người sử dụng
    Public Shared Function ShowYeuCauNSD() As Boolean
        Try
            Dim frmYeucaucuaNSD As ReportMain.Forms.frmYeuCauCuaNSD = New ReportMain.Forms.frmYeuCauCuaNSD()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmYeucaucuaNSD.Name) Then
                ShowForm(frmYeucaucuaNSD)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowYeuCauNSD_DSX() As Boolean
        Try
            Dim frmDuyetSanXuat As MReportVB.frmDuyetSanXuat = New MReportVB.frmDuyetSanXuat()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDuyetSanXuat.Name) Then
                ShowForm(frmDuyetSanXuat)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show Duyệt yêu cầu bảo trì
    Public Shared Function ShowYeuCauNSD_DBT() As Boolean
        Try
            'Dim frmYCNSD As frmYeucaucuaNSD = New frmYeucaucuaNSD()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmYeuCauBT.Name) Then
                ShowForm(frmYeuCauBT)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowYeuCauNSD_DUYET() As Boolean
        Try
            'Dim frmYCNSD As frmYeucaucuaNSD = New frmYeucaucuaNSD()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmYeucaucuaNSD_Duyet.Name) Then
                ShowForm(frmYeucaucuaNSD_Duyet)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show thời gian chạy máy
    Public Shared Function ShowTGChayMay() As Boolean
        Try
            Dim frmTGCM As MVControl.frmThoigianchaymay = New MVControl.frmThoigianchaymay()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmTGCM.Name) Then
                ShowForm(frmTGCM)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show nơi sử dụng vật tư phụ tùng
    Public Shared Function ShowNoiSuDung() As Boolean
        Try
            Dim frmLoaiphutung As Report1.frmLoaiphutung = New Report1.frmLoaiphutung()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmLoaiphutung.Name) Then
                ShowForm(frmLoaiphutung)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show loại công việc 
    Public Shared Function ShowLoaiCV() As Boolean
        Try
            Dim frmLoaicv As Report1.frmLoaicongviec = New Report1.frmLoaicongviec()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmLoaicv.Name) Then
                ShowForm(frmLoaicv)
            End If
            Return True
        Catch ex As Exception
            Return True
        End Try

    End Function
    'Show đơn vị tính
    Public Shared Function ShowDonViTinhRunTime() As Boolean
        Try
            Dim frmDVTRunTime As Report1.frmDonvitinhRuntime = New Report1.frmDonvitinhRuntime()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDVTRunTime.Name) Then
                ShowForm(frmDVTRunTime)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Chạy form thông số giám sát tình trạng
    Public Shared Function ShowThongsoGSTT() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmThongsoGSTT.Name) Then
                ShowForm(frmThongsoGSTT)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show nhập kho vật tư phụ tùng
    Public Shared Function ShowPhieuNhapKho() As Boolean
        Try
            'Dim frmPhieuNhap As FrmPhieuNhapKhoVatTu = New FrmPhieuNhapKhoVatTu()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuNhapKhoVatTu.Name) Then
                ShowForm(FrmPhieuNhapKhoVatTu)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowPhieuNhapKho_New() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuNhapKhoVatTu.Name) Then
                Dim frmPhieuNhapKho As WareHouse.frmPhieuNhapKho_New = New WareHouse.frmPhieuNhapKho_New()
                ShowForm(frmPhieuNhapKho)
                'Commons.Modules.PermisString =""
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show kiểm kê 
    Public Shared Function ShowKiemKe() As Boolean
        Try
            Dim frmKiemKe As MVControl.frmKiemKeKho = New MVControl.frmKiemKeKho()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmKiemKe.Name) Then
                If Commons.Modules.PermisString.Equals("Read only") Then
                    frmKiemKe.EnableButton(False)
                End If
                ShowForm(frmKiemKe)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show danh mục kho
    Public Shared Function ShowDanhMucKho() As Boolean
        Try
            Dim frmKho As Report1.frmKho = New Report1.frmKho()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmKho.Name) Then
                ShowForm(frmKho)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show phiếu bảo trì
    Public Shared Function ShowPhieuBaoTri() As Boolean
        Try
            'Dim frmPhieuBT As FrmPhieuBaoTri = New FrmPhieuBaoTri()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmPhieuBaoTri.Name) Then
                ShowForm(FrmPhieuBaoTri)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show phiếu bảo trì
    Public Shared Function ShowPhieuBaoTri_New() As Boolean
        Try
            Dim frmPhieuBT As FrmPhieuBaoTri_New = New FrmPhieuBaoTri_New()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmPhieuBT.Name) Then
                ShowForm(frmPhieuBT)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Load form thông tin đơn vị sử dụng
    Public Shared Function LoadThongTinChung() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmCompany.Name) Then
                ShowForm(frmCompany)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Show form báo cáo new ReportManager.LoaiBaoCao._LoaiBC = 1
    Public Shared Function ShowReport() As Boolean
        Try
            ReportManager.LoaiBaoCao._LoaiBC = 1
            Dim frmBaocao As ReportManager.frmReports = New ReportManager.frmReports()
            'frmBaocao.LoaiBaoCao._LoaiBC = 1
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmBaocao.Name) Then
                ShowForm(frmBaocao)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show form bao cao cho mail ReportManager.LoaiBaoCao._LoaiBC = 2
    Public Shared Function ShowReportMail() As Boolean
        Try
            ReportManager.LoaiBaoCao._LoaiBC = 2

            Dim frmMail As ReportManager.frmReports = New ReportManager.frmReports()
            frmMail.Name = "frmReportmailsetting"
            'frmMail.LoaiBaoCao._LoaiBC = 2

            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmReportmailsetting") Then
                ShowForm(frmMail)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show form cho settingform ReportManager.LoaiBaoCao._LoaiBC = 3
    Public Shared Function ShowReportFormsetting() As Boolean
        Try
            ReportManager.LoaiBaoCao._LoaiBC = 3
            Dim frmFormsetting As ReportManager.frmReports = New ReportManager.frmReports()
            frmFormsetting.Name = "frmFormsetting"
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmFormsetting") Then
                ShowForm(frmFormsetting)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Phục hồi dữ liệu
    Public Shared Function PhucHoiDL() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmRefreshData.Name) Then
                ShowForm(FrmRefreshData, True)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show di chuyển vật tư trong kho
    Public Shared Function ShowDiChuyenVTKho() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmDiChuyenVatTu.Name) Then
                ShowForm(FrmDiChuyenVatTu)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show tìm vật tư trong kho
    Public Shared Function ShowTimVatTu() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmTimThongTinPT.Name) Then
                ShowForm(FrmTimThongTinPT)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show chon vật tư trong kho
    Public Shared Function ShowChonVT() As Boolean
        Try
            'Dim frmChonVT As frmChonVatTuTrongKho = New frmChonVatTuTrongKho()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmChonVatTuTrongKho.Name) Then
                ShowForm(frmChonVatTuTrongKho)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'ShowfrmThongKeNhapTheoKH
    Public Shared Function ShowfrmThongKeNhapTheoKH() As Boolean
        Try
            ' If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, Iventory.frmGoodreceive.Name) Then
            Dim frmThongKeNhapTheoKH As ReportHuda.frmThongKeNhapTheoKH = New ReportHuda.frmThongKeNhapTheoKH()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmThongKeNhapTheoKH.Name) Then
                ShowForm(frmThongKeNhapTheoKH)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show công việc hàng ngày
    Public Shared Function ShowCongViecHangNgay() As Boolean
        Try
            'Dim frmCongviecHN As frmCongViecHangNgay = New frmCongViecHangNgay()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmCongViecHangNgay.Name) Then
                ShowForm(frmCongViecHangNgay)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show thời gian ngừng máy
    Public Shared Function ShowTGNgungMay_Bayer() As Boolean
        Try
            frmDowntime_BAYER.Name = "frmDowntime"
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDowntime_BAYER.Name) Then
                ShowForm(frmDowntime_BAYER)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowTGNgungMay() As Boolean
        Try
            'Dim frmTGNM As frmDowntime = New frmDowntime()
            frmDowntime_DUYTAN.Name = "frmDowntime"
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDowntime_DUYTAN.Name) Then
                ShowForm(frmDowntime_DUYTAN)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Show nhắc việc NEW
    Public Shared Function ShowNhacViec_New() As Boolean
        Vietsoft.Admin.Adminvs.ConnectionString = Commons.IConnections.ConnectionString()
        Vietsoft.Admin.Adminvs.Language = Commons.Modules.TypeLanguage
        Vietsoft.Admin.Adminvs.UserName = Commons.Modules.UserName
        Try
            Dim frmReminder As Vietsoft.Reminder.frmReminder_new = New Vietsoft.Reminder.frmReminder_new()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmNhacviec") Then
                ShowForm(frmReminder)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show dây chuyền
    Public Shared Function ShowDayChuyen() As Boolean
        Try
            Dim frmDaychuyen As MVControl.frmDanhMucHeThong = New MVControl.frmDanhMucHeThong()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDaychuyen.Name) Then
                ShowForm(frmDaychuyen)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show đề xuất mua hàng
    Public Shared Function ShowDeXuatMuaHang() As Boolean
        Try
            'Dim frmDexuatMH As frmDeXuatMuaHang = New frmDeXuatMuaHang()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDeXuatMuaHang.Name) Then
                ShowForm(frmDeXuatMuaHang)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show đề xuất mua hàng
    Public Shared Function ShowDeXuatMuaHangDT() As Boolean
        Try
            'Dim frmDexuatMH As frmDeXuatMuaHang_DUYTAN = New frmDeXuatMuaHang_DUYTAN()
            'frmDexuatMH.Name = frmDeXuatMuaHang.Name
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDeXuatMuaHang_DUYTAN.Name) Then
                ShowForm(frmDeXuatMuaHang_DUYTAN)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowDeXuatMuaHangVMPACKs() As Boolean
        Try
            'Dim frmDexuatMH As frmDeXuatMuaHang = New frmDeXuatMuaHang()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDeXuatMuaHang_VMPACK.Name) Then
                ShowForm(frmDeXuatMuaHang_VMPACK)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show duyệt mua hàng
    Public Shared Function ShowDuyetMuaHang() As Boolean
        Try
            'Dim frmDuyetMua As frmDonDatHang = New frmDonDatHang()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDonDatHang.Name) Then
                ShowForm(frmDonDatHang)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Chỉn sửa ngôn ngữ
    Public Shared Function LoadEditLanguage() As Boolean
        Try
            ' Dim frmForm As frmLanguage = New frmLanguage()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmLanguage.Name) Then
                ShowForm(frmLanguage)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Phân quyền sử dụng
    Public Shared Function LoadPhanQuyen() As Boolean
        Try

            If Commons.Modules.UserName.ToUpper = "ADMIN" Then
                ShowForm(frmNhomquyen)
            Else
                'Dim frmPhanQuyen As frmNhomquyen = New frmNhomquyen()
                If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmNhomquyen.Name) Then
                    ShowForm(frmNhomquyen)
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Đổi mật khẩu
    Public Shared Function LoadDoiPassword() As Boolean
        Try
            frmPassword.ShowDialog()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub CallTimerLogin()
        BeginInvoke(DirectCast(Sub()
                                   aTimer = New System.Timers.Timer()
                                   aTimer.Interval = 60000
                                   AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
                                   aTimer.AutoReset = True
                                   aTimer.Enabled = True
                               End Sub, Action))

    End Sub


    'Mainform show
    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim iLogin As DialogResult
        Commons.Modules.SQLString = "iLoad"
        iLogin = frmLogin.ShowDialog()
        Commons.Modules.SQLString = ""
        If iLogin = Windows.Forms.DialogResult.Cancel Or iLogin = Windows.Forms.DialogResult.No Then
            Application.RemoveMessageFilter(mf)
            Application.ExitThread()
            Exit Sub
        End If
        If Commons.Modules.UserName.Trim.Equals(String.Empty) Then
            Application.RemoveMessageFilter(mf)
            Application.ExitThread()
            Exit Sub
        End If
        Dim t As New Thread(New ThreadStart(AddressOf CallTimerLogin))
        t.Start()
        Application.AddMessageFilter(mf)

        UserPermission(Commons.Modules.UserName)
        Try
            TaoThongTinBar()
        Catch ex As Exception

        End Try

        Vietsoft.Information.ModuleName = Commons.Modules.ModuleName
        Vietsoft.Information.Language = Commons.Modules.TypeLanguage
        Vietsoft.Information.ConnectionString = Commons.IConnections.ConnectionString()
        Vietsoft.Information.Username = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT FULL_NAME FROM dbo.USERS WHERE USERNAME = N'" + Commons.Modules.UserName + "'"), String)
        Vietsoft.Information.UserID = Commons.Modules.UserName
        VietShape.Modules.TypeLanguage = Commons.Modules.TypeLanguage
        VietShape.Modules.UserName = Commons.Modules.UserName
        VietShape.Modules.ConnectionString = Commons.IConnections.ConnectionString

        ShowForm(frmMLog)
        ShowShape()
        frmMLog.Close()

        Commons.Modules.DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Commons.Modules.DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Commons.Modules.DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]

        Commons.Modules.DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Commons.Modules.DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        Commons.Modules.DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Commons.Modules.DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        Commons.Modules.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Commons.Modules.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Commons.Modules.DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]

        ''''Dashboard.MdiParent = Me
        ''''Dashboard.WindowState = FormWindowState.Maximized
        ''''Dashboard.Show()
    End Sub
    Public Shared Function ShowShape()
        VietShape.Modules.IXtraShape = New VietShape.XtraShape()
        For Each frmChild As Form In frmMain.MdiChildren
            If (VietShape.Modules.IXtraShape.Name.Trim().Equals(frmChild.Name.Trim())) Then
                frmChild.Activate()
                Return True
                Exit Function
            End If
        Next
        Dim SQL As String = "SELECT COUNT(*) " &
                   " FROM dbo.USERS INNER JOIN " &
                   " dbo.NHOM_FORM ON dbo.USERS.GROUP_ID = dbo.NHOM_FORM.GROUP_ID " &
                   " WHERE dbo.NHOM_FORM.FORM_NAME = N'" & VietShape.Modules.IXtraShape.Name & "' AND QUYEN <> N'No access' AND dbo.USERS.USERNAME = N'" & Commons.Modules.UserName & "'"
        Dim Obj As Object = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        If (CType(Obj, Integer) > 0) Then
            VietShape.Modules.IXtraShape.MdiParent = frmMain
            VietShape.Modules.IXtraShape.Show()
        End If
        Return True '
    End Function
    'Show help 
    Public Shared Function ShowHelp() As Boolean

        'Dim sTenCty As String = "VietSoft"
        'Dim sMail As String = "sales@vietsoft.com.vn"
        'Dim sDThoai As String = "(028) 38 110 770"
        'Dim iCus As String = "1"
        'sTenCty = "VietSoft; sales@vietsoft.com.vn; (028) 38 110 770; (028) 38 110 770; 1"
        'Try
        '    Dim dt As DataTable = New DataTable()
        '    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT  ISNULL(EMAIL,'') AS EMAIL,ISNULL(Phone,'') AS DIEN_THOAI, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_CTY_TIENG_VIET ELSE ISNULL(NULLIF(TEN_CTY_TIENG_ANH,''), TEN_CTY_TIENG_VIET) END AS TEN_CTY,ISNULL(CustomerID,'-1') AS CustomerID FROM THONG_TIN_CHUNG "))
        '    sTenCty = dt.Rows(0)("TEN_CTY").ToString()
        '    sMail = dt.Rows(0)("EMAIL").ToString()
        '    sDThoai = dt.Rows(0)("DIEN_THOAI").ToString()
        '    iCus = dt.Rows(0)("CustomerID").ToString()
        'Catch
        'End Try


        'Try

        '    'Public frmSupport(String cnstr, int NgonNgu, String UserName, String FullName, String ModuleName, String sTEN_CT, String sEMAIL, String sPhone, String sZalo, int iCustomerID)

        '    Dim frm As New VS.Support.frmSupport(Commons.IConnections.CNStr, Commons.Modules.TypeLanguage, Commons.Modules.UserName, Commons.Modules.sTenNhanVienMD, Commons.Modules.ModuleName, sTenCty, sMail, sDThoai, sDThoai, iCus)
        '    'frm.ShowDialog()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)

        'End Try


    End Function
    'Hàm show form 
    Public Shared Sub ShowForm(ByVal frmForm As Form, Optional ByVal bDialog As Boolean = False)

        Try
            Try
                For Each frmChild As Form In frmMain.MdiChildren
                    If (frmForm.Name.Trim().Equals(frmChild.Name.Trim())) Then
                        frmChild.Activate()
                        Exit Sub
                    End If
                Next
            Catch ex As Exception
            End Try

            'If frmForm.IsHandleCreated Then
            '    frmForm.Activate()
            '    Exit Sub
            'End If

            frmMain.Cursor = Cursors.WaitCursor
            If bDialog = True Then

                frmForm.ShowDialog()
            Else
                frmForm.MdiParent = frmMain
                frmForm.WindowState = FormWindowState.Maximized
                frmForm.Show()
            End If
        Catch ex As Exception
            frmMain.Cursor = Cursors.Default
            XtraMessageBox.Show("Load form error" + vbCrLf + ex.Message)
        End Try
        frmMain.Cursor = Cursors.Default
    End Sub
    Public Shared Function ShowImport() As Boolean
        Try
            Dim frmImport As ImportExcelVietsoft.ImportExcel = New ImportExcelVietsoft.ImportExcel()
            frmImport.sqlConnectionstring = Commons.IConnections.ConnectionString()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmImport.Name) Then
                ShowForm(frmImport, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shared Function ShowImport_2() As Boolean
        Try
            DllCMMS.ConnectionString = Commons.IConnections.ConnectionString
            Dim frmImport As UI.ImportDataFromExcel = New UI.ImportDataFromExcel()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmImport.Name) Then
                ShowForm(frmImport, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowDeXuatMuaHangVMPACK() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDeXuatMuaHang_VMPACK.Name) Then
                ShowForm(frmDeXuatMuaHang_VMPACK)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowCanDoiKho() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, FrmCanDoiKho.Name) Then
                ShowForm(FrmCanDoiKho)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show Don dat hang 
    Public Shared Function ShowDonDatHangVMPACK() As Boolean
        Try
            Dim frmDexuatMH As Report1.frmDDH = New Report1.frmDDH()
            frmDexuatMH.Name = "frmDonDatHang"
            Commons.clsConnect.Connectstring = Commons.IConnections.ConnectionString
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDexuatMH.Name) Then
                ShowForm(frmDexuatMH)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show Ngày nghỉ lễ
    Public Shared Function ShowNgayNghiLe() As Boolean

        Try

            Dim frmDVD As Report1.frmDonvido = New Report1.frmDonvido()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDVD.Name) Then
                ShowForm(frmDVD)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show Chi phí theo tháng
    Public Shared Function ShowChiPhiTheoThang() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmChiPhiTheoThang.Name) Then
                ShowForm(frmChiPhiTheoThang)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show Công nhân - BPCP
    Public Shared Function ShowCongnhan_BPCP() As Boolean
        Try
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmCONGNHAN_BPCP.Name) Then
                ShowForm(frmCONGNHAN_BPCP)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Show Danh muc he chuyen gia
    Public Shared Function ShowDanhmuchechuyengia() As Boolean
        Try
            Dim frmCauseRemedy As Report1.frmCauseRemedy = New Report1.frmCauseRemedy()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDanhmucHechuyengia") Then
                ShowForm(frmCauseRemedy)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowCause() As Boolean
        Try
            Commons.Modules.PermisString = ""
            Dim frmCauseRemedy As Report1.frmCauseRemedy = New Report1.frmCauseRemedy()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmCauseRemedy.Name) Then
                ShowForm(frmCauseRemedy)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowProblem() As Boolean
        Try
            Commons.Modules.PermisString = ""
            Dim frmProblemCause As Report1.frmProblemCause = New Report1.frmProblemCause()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmProblemCause.Name) Then
                ShowForm(frmProblemCause)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowClass() As Boolean
        Try
            Commons.Modules.PermisString = ""
            Dim frmClassProblem As Report1.frmClassProblem = New Report1.frmClassProblem()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmClassProblem.Name) Then
                ShowForm(frmClassProblem)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowMinMax() As Boolean
        Try
            Dim _frmStock As frmStock = New frmStock()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, _frmStock.Name) Then
                ShowForm(_frmStock, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowDuong() As Boolean
        Try
            Dim _frmStreet As frmStreet = New frmStreet()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, _frmStreet.Name) Then
                ShowForm(_frmStreet, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowQuocGia() As Boolean
        Try
            Commons.Modules.PermisString = ""

            Dim _frmContry As frmContry = New frmContry()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, _frmContry.Name) Then
                ShowForm(_frmContry, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function DSDiaDiem() As Boolean
        Try
            Dim _frmBranch As frmBranch = New frmBranch()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, _frmBranch.Name) Then
                For Each frmChild As Form In frmMain.MdiChildren
                    If (_frmBranch.Name.Trim().Equals(frmChild.Name.Trim())) Then
                        frmChild.Close()
                        Exit For
                    End If
                Next
                _frmBranch.MsNX = VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Substring(3, VietShape.Modules.IXtraShape.ContextMenuStrip_TwoPopup.SourceControl.Name.Length - 3)
                ShowForm(_frmBranch, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowChiNhanh() As Boolean
        Try
            Dim _frmBranch As frmBranch = New frmBranch()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, _frmBranch.Name) Then
                ShowForm(_frmBranch, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowExportDataChangShin() As Boolean
        Try
            Dim _frmExport As Report1.frmExportData = New Report1.frmExportData()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, _frmExport.Name) Then
                ShowForm(_frmExport, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowBoPhanChiuPhiRule() As Boolean
        Try
            Dim frmBoPhanChiuPhiRule As ImportExcels.frmBoPhanChiuPhiRule = New ImportExcels.frmBoPhanChiuPhiRule()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmBoPhanChiuPhiRule.Name) Then
                ShowForm(frmBoPhanChiuPhiRule)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowDistribution() As Boolean
        Try
            Dim frmDistribution As ImportExcels.frmDistribution = New ImportExcels.frmDistribution()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmDistribution.Name) Then
                ShowForm(frmDistribution)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowSanPham() As Boolean
        Try
            Dim frmTTSP As ExportExcels.frmTTSP = New ExportExcels.frmTTSP()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmTTSP.Name) Then
                ShowForm(frmTTSP)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowLichTau() As Boolean
        Try
            ' If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, Iventory.frmGoodreceive.Name) Then
            Dim frmLichtau As ReportHuda.General.frmLichTau = New ReportHuda.General.frmLichTau()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmLichtau.Name) Then
                ShowForm(frmLichtau)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowTimvattudexuat() As Boolean
        Try
            ' If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, Iventory.frmGoodreceive.Name) Then
            Dim frmTimVT As ReportHuda.General.frmTimVT = New ReportHuda.General.frmTimVT()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmTimVT.Name) Then
                ShowForm(frmTimVT)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowTinhhinhtonkho() As Boolean
        Try
            Dim frmTinhHinhTonKho As ReportHuda.frmTinhHinhTonKho = New ReportHuda.frmTinhHinhTonKho()
            frmTinhHinhTonKho.bThanhLy = False
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmTinhHinhTonKho.Name) Then
                ShowForm(frmTinhHinhTonKho)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowTHTKhoThanhLy() As Boolean
        Try
            Dim frmTinhHinhTonKhoThanhLy As ReportHuda.frmTinhHinhTonKho = New ReportHuda.frmTinhHinhTonKho()
            frmTinhHinhTonKhoThanhLy.bThanhLy = True
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmTinhHinhTonKhoThanhLy") Then
                frmTinhHinhTonKhoThanhLy.Name = "frmTinhHinhTonKhoThanhLy"
                ShowForm(frmTinhHinhTonKhoThanhLy)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ShowTinhhinhtonkhoCS() As Boolean
        Try
            Dim frmTinhHinhTonKho As ReportHuda.frmTinhHinhTonKho = New ReportHuda.frmTinhHinhTonKho()
            frmTinhHinhTonKho.bThanhLy = True
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frmTinhHinhTonKho.Name) Then
                ShowForm(frmTinhHinhTonKho)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub XtraTabbedMdiManager_PageAdded(ByVal sender As System.Object, ByVal e As DevExpress.XtraTabbedMdi.MdiTabPageEventArgs) Handles XtraTabbedMdiManager.PageAdded
        PictureEdit1.SendToBack()
    End Sub

    Private Sub XtraTabbedMdiManager_PageRemoved(ByVal sender As System.Object, ByVal e As DevExpress.XtraTabbedMdi.MdiTabPageEventArgs) Handles XtraTabbedMdiManager.PageRemoved
        If XtraTabbedMdiManager.Pages.Count = 0 Then
            PictureEdit1.BringToFront()
        End If
    End Sub

    '1) Loại Vật tư							frmLoaivattu			ShowLoaivattu
    '2) Hãng sản xuất						frmHangsanxuat			ShowHangsanxuat				
    '3) Nguyên nhân dừng máy				frmNguyenNhanDungMay		ShowNguyenNhanDungMay
    '4) Thông số thiết bị (form thông tin thiết bị, tab thông số và tài liệu) 		frmThongsothietbi			ShowThongsothietbi	
    '5) lý do sữa chữa (kế hoạch tổng thể)					FrmLyDo				ShowLyDo	
    '6) Chức vụ (form công nhân)						frmDanhmucchucvu		ShowDanhmucchucvu
    '7) Tổ phòng ban							frmDanhmucto			ShowDanhmucto				
    '8) Chuyên môn							frmChuyenmon			ShowChuyenmon
    '9) Bậc thợ							frmBactho			ShowBactho



    Public Shared Function ShowLoaivattu() As Boolean
        Try
            Dim frm As Report1.frmLoaivattu = New Report1.frmLoaivattu()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowHangsanxuat() As Boolean
        Try
            Dim frm As Report1.frmHangsanxuat = New Report1.frmHangsanxuat()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowNguyenNhanDungMay() As Boolean
        Try
            Dim frm As Report1.frmNguyenNhanDungMay = New Report1.frmNguyenNhanDungMay()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowThongsothietbi() As Boolean
        Try
            Dim frm As frmThongsothietbi = New frmThongsothietbi()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowLyDo() As Boolean
        Try
            Dim frm As Report1.FrmLyDo = New Report1.FrmLyDo()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowDanhmucchucvu() As Boolean
        Try
            Dim frm As Report1.frmDanhmucchucvu = New Report1.frmDanhmucchucvu()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                frm.MS_CN = "-1"
                frm.MS_CN_TMP = "-1"
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowDanhmucto() As Boolean
        Try
            Dim frm As Report1.frmDanhmucto = New Report1.frmDanhmucto()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowChuyenmon() As Boolean
        Try
            Dim frm As Report1.frmChuyenmon = New Report1.frmChuyenmon()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowBactho() As Boolean
        Try
            Dim frm As Report1.frmBactho = New Report1.frmBactho()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowInBarCode() As Boolean
        Try
            Dim frm As ReportMain.frmChonMay = New ReportMain.frmChonMay()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Function ShowNhapTraBHS() As Boolean
        Try
            Dim frm As ReportHuda.frmAllocateNhapTra = New ReportHuda.frmAllocateNhapTra()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowPhanTichNNNMTheoNN() As Boolean
        Try
            Dim frm As ReportHuda.frmPhanTichNNNMTheoNN = New ReportHuda.frmPhanTichNNNMTheoNN()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowPhatSinhDichVu() As Boolean
        Try
            Dim frm As ReportHuda.frmPhatSinhDichVu = New ReportHuda.frmPhatSinhDichVu()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, frm.Name) Then
                ShowForm(frm, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowNhapTraBaria() As Boolean
        Try
            Dim frmBR As New ReportHuda.frmChonVTINTPBT
            frmBR.sPBT = "-1"
            frmBR.sMay = "-1"
            frmBR.iLoaiForm = 1
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmNhapTraBARIA") Then
                ShowForm(frmBR, False)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowTinhGiaLai() As Boolean
        Try
            Dim frmTinhGiaLai As New MReportVB.frmTinhGiaLai

            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmTinhGiaLai") Then
                ShowForm(frmTinhGiaLai, True)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ShowVTPTExcel() As Boolean
        Try
            Dim frmExcelVC As New ImportExcels.frmImportPhuTungVC
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmImportPhuTungVC") Then
                ShowForm(frmExcelVC)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
#Region "DieuDo"
    '    
    '
    'ShowDDNhomMay
    'ShowDDo
    Public Shared Function ShowDDNhom() As Boolean
        Try
            Dim frmDDNhom As New VietShape.frmDDNhom()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDDNhom") Then
                ShowForm(frmDDNhom)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function ShowDDNhomCNhan() As Boolean
        Try
            Dim frmDDNhomCNhan As New VietShape.frmDDNhomCNhan()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDDNhomCNhan") Then
                ShowForm(frmDDNhomCNhan)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function ShowDDNhomMay() As Boolean
        Try
            Dim frmDDNhomMay As New VietShape.frmDDNhomMay()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDDNhomMay") Then
                ShowForm(frmDDNhomMay)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function ShowDDo() As Boolean
        Try
            Dim frmDieuDo As New VietShape.frmDieuDo()
            If Commons.Modules.ObjSystems.check_permission(Commons.Modules.UserName, "frmDieuDo") Then
                ShowForm(frmDieuDo)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
#End Region
    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.Modifiers = Keys.Alt And e.KeyCode = Keys.Z Then

            For Each frmChild As Form In Me.MdiChildren
                'If (frmChild.IS) Then

                '    Exit Sub
                'End If
            Next
        ElseIf e.Modifiers = Keys.Control And e.KeyCode = Keys.L Then


        End If
    End Sub

    Private Sub BarUserName_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarUserName.ItemClick

        Try
            Dim currentForm As Form = Form.ActiveForm
            Clipboard.SetText(currentForm.ActiveMdiChild.ToString())
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub TaoThongTinBar()
        Try

            Dim _NGUOI_DANG_NHAP As String = "Login : "
            Dim _TEN_CONG_TY As String = CType(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT (CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN TEN_CTY_TIENG_VIET WHEN 1 THEN TEN_CTY_TIENG_ANH END) AS TEN_CTY FROM THONG_TIN_CHUNG "), String)
            Dim _PHIEN_BAN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "PHIEN_BAN", Commons.Modules.TypeLanguage)
            _NGUOI_DANG_NHAP += IIf(Commons.Modules.UserName <> "", Commons.Modules.UserName, " - - - - -")
            _NGUOI_DANG_NHAP += " - Database : " + Commons.IConnections.Database

            _PHIEN_BAN += " " + Application.ProductVersion.ToString.Substring(0, 3)

            CType(frmMain.ActiveForm, frmMain).BarUserName.Caption = _NGUOI_DANG_NHAP
            CType(frmMain.ActiveForm, frmMain).BarCompanyInfo.Caption = Replace(_TEN_CONG_TY.ToUpper(), "''", "'")
            If Commons.Modules.LicDemo = True Then
                CType(frmMain.ActiveForm, frmMain).BarVersion.Caption = "Phiên Bản Demo Ngày Hết Hạn : " + Commons.Modules.DemoDate.ToShortDateString
            Else
                CType(frmMain.ActiveForm, frmMain).BarVersion.Caption = _PHIEN_BAN
            End If



            'Commons.Modules.sInfoSer
            Dim SQL As String
            SQL = "SELECT TOP 1 VER FROM THONG_TIN_CHUNG"
            Dim sVer As String = ""
            sVer = Convert.ToDouble(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SQL))

            'CType(frmMain.ActiveForm, frmMain).BarDateUpdate.Caption = "Version Current : " & Commons.Modules.sInfoClient & If(Commons.Modules.sInfoSer = "1", "", " - Server " & Commons.Modules.sInfoSer)

            '201907030004

            Try

                sVer = sVer.Substring(6, 2) + "/" + sVer.Substring(4, 2) + "/" + sVer.Substring(0, 4) + "." + sVer.ToString.Substring(8, sVer.ToString.Length - 8)
            Catch ex As Exception
                sVer = sVer.ToString
            End Try
            CType(frmMain.ActiveForm, frmMain).BarDateUpdate.Caption = "Version Current : " & sVer & If(Commons.Modules.sInfoSer = "1", "", " - Server " & Commons.Modules.sInfoSer)

            Commons.Modules.sInfoSer = sVer
            Dim myHost As String = System.Net.Dns.GetHostName.ToUpper()

            'If Commons.Modules.sInfoClient <> sVer And Commons.Modules.UserName.ToLower <> "admin" And myHost <> "M4L0V3" Then
            '    XtraMessageBox.Show("Bạn đang chạy sai phiên bản vui lòng cập nhập")
            '    End
            'End If
            ThongTinDangNhap()
            Commons.Modules.SQLString = ""
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ThongTinDangNhap()
        Try
            Dim sSql As String
            sSql = " SELECT SUM(SL) FROM (" & sDataLog.Replace("CBOLICCOM", Commons.Modules.LicensePro.ToString()) & ") T1 "
            sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            sSql = "Total " & sSql & "/" & Commons.Modules.ObjSystems.Licences(Commons.Modules.UserName) & " user login"
            CType(frmMain.ActiveForm, frmMain).barLog.Caption = sSql & sCty



        Catch ex As Exception
        End Try
    End Sub


    Public Shared Sub SkinName1()
        Try
            Application.EnableVisualStyles()
            'DevExpress.UserSkins.BonusSkins.Register()
            DevExpress.Skins.SkinManager.EnableFormSkins()
            DevExpress.Skins.SkinManager.EnableMdiFormSkins()
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Black"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMain_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDoubleClick
        If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Left Then
            Dim Ctl As Label
            Dim sText As String = ""
            Ctl = CType(sender, Label)
            Try
                Dim sName As String = Commons.Modules.ObjSystems.GetParentForm(Ctl).Name.ToString 'DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                'sText = XtraInputBox.Show(Ctl.Text, True)
                'If sText = "" Then
                '    Exit Sub
                'Else
                '    If sText = "Windows.Forms.DialogResult.Retry" Then
                '        sText = ""
                '        CapNhapNN(sName, Ctl.Name, sText, True)
                '    Else
                '        CapNhapNN(sName, Ctl.Name, sText, False)
                '    End If
                'End If
                'sText = " SELECT TOP 1 " & IIf(Commons.Modules.TypeLanguage = 0, "VIETNAM", "ENGLISH") & " FROM LANGUAGES WHERE FORM = '" & sName & "' AND KEYWORD = '" & Ctl.Name & "' AND MS_MODULE = 'ECOMAIN'"
                'sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sText))

                Ctl.Text = sText
            Catch ex As Exception
                sText = ""
            End Try
        End If
    End Sub
    Dim clickTick As Integer
    Private Sub XtraTabbedMdiManager_MouseDown(sender As Object, e As MouseEventArgs) Handles XtraTabbedMdiManager.MouseDown
        Dim hi As DevExpress.XtraTab.ViewInfo.BaseTabHitInfo = XtraTabbedMdiManager.CalcHitInfo(New Point(e.X, e.Y))
        If hi.HitTest = DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader Then
            If clickTick = -1 Then
                clickTick = System.Environment.TickCount
            Else
                If System.Environment.TickCount - clickTick < SystemInformation.DoubleClickTime Then
                    If Form.ModifierKeys = Keys.Control And e.Button = MouseButtons.Right Then
                        'MessageBox.Show(("DoubleClick: " + hi.Page.Text))
                        Try
                            Dim frm = New VietShape.frmNNgu()
                            frm.sForm = DirectCast(hi.Page, DevExpress.XtraTabbedMdi.XtraMdiTabPage).MdiChild.Name.ToString()
                            frm.ShowDialog()
                            Commons.Modules.ObjSystems.ThayDoiNN(DirectCast(hi.Page, DevExpress.XtraTabbedMdi.XtraMdiTabPage).MdiChild)
                        Catch ex As Exception
                            XtraMessageBox.Show(ex.ToString())
                        End Try


                    End If
                End If
                clickTick = -1
            End If
        End If

    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed


        Application.RemoveMessageFilter(mf)
        aTimer.Stop()
        MyBase.OnFormClosed(e)

    End Sub

    Private Sub frmMain_BindingContextChanged(sender As Object, e As EventArgs) Handles Me.BindingContextChanged

    End Sub


    Public Shared Function ShowYeuCauHoTro() As Boolean
        Try
            Dim sTenCty As String = "VietSoft"
            Dim sMail As String = "sales@vietsoft.com.vn"
            Dim sDThoai As String = "(028) 38 110 770"
            Dim iCus As Int64 = -1
            Dim iConID As Int64 = -1
            sTenCty = "VietSoft; sales@vietsoft.com.vn; (028) 38 110 770; (028) 38 110 770; 1"
            Try
                Dim dt As DataTable = New DataTable()
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT  ISNULL(EMAIL,'') AS EMAIL,ISNULL(Phone,'') AS DIEN_THOAI, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_CTY_TIENG_VIET ELSE ISNULL(NULLIF(TEN_CTY_TIENG_ANH,''), TEN_CTY_TIENG_VIET) END AS TEN_CTY,ISNULL(CusID,-1) AS CustomerID ,ISNULL(iConID,-1) AS iContractID FROM THONG_TIN_CHUNG "))
                sTenCty = dt.Rows(0)("TEN_CTY").ToString()
                sMail = dt.Rows(0)("EMAIL").ToString()
                sDThoai = dt.Rows(0)("DIEN_THOAI").ToString()
                iCus = dt.Rows(0)("CustomerID").ToString()
                iConID = dt.Rows(0)("iContractID").ToString()
            Catch
            End Try
            'Commons.Modules.TypeLanguage, Commons.Modules.UserName, Commons.Modules.sTenNhanVienMD, sTenCty, sMail, sDThoai, sDThoai, iCus, iConID, String Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, Commons.Modules.sMailFromSmtp, Commons.Modules.sMailFromPort
            'Int NgonNgu, String UserName, String FullName, String sTEN_CT, String sEMAIL, String sPhone, String sZalo, Int64 iCustomerID, Int64 iContractID, String MailForm, String MailPass, String MailSMTP, Int MailPort

            Dim iMailPort As Int64 = 0
            Try
                iMailPort = Convert.ToInt16(Commons.Modules.sMailFromPort)
            Catch ex As Exception
            End Try

            'Dim frm As New VS.Support.frmSupport(Convert.ToInt16(Commons.Modules.TypeLanguage), Commons.Modules.UserName, Commons.Modules.sTenNhanVienMD, sTenCty, sMail, sDThoai, sDThoai, iCus, iConID, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, Commons.Modules.sMailFromSmtp, iMailPort)
            'frm.ShowDialog()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function
    Public Shared Function ShowXemYeuCauHoTro() As Boolean
        Try
            Dim sTenCty As String = "VietSoft"
            Dim sMail As String = "sales@vietsoft.com.vn"
            Dim sDThoai As String = "(028) 38 110 770"
            Dim iCus As Int64 = -1
            Dim iConID As Int64 = -1
            sTenCty = "VietSoft; sales@vietsoft.com.vn; (028) 38 110 770; (028) 38 110 770; 1"
            Try
                Dim dt As DataTable = New DataTable()
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT  ISNULL(EMAIL,'') AS EMAIL,ISNULL(Phone,'') AS DIEN_THOAI, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_CTY_TIENG_VIET ELSE ISNULL(NULLIF(TEN_CTY_TIENG_ANH,''), TEN_CTY_TIENG_VIET) END AS TEN_CTY,ISNULL(CusID,-1) AS CustomerID ,ISNULL(iConID,-1) AS iContractID FROM THONG_TIN_CHUNG "))
                sTenCty = dt.Rows(0)("TEN_CTY").ToString()
                sMail = dt.Rows(0)("EMAIL").ToString()
                sDThoai = dt.Rows(0)("DIEN_THOAI").ToString()
                iCus = dt.Rows(0)("CustomerID").ToString()
                iConID = dt.Rows(0)("iContractID").ToString()
            Catch
            End Try

            Dim iMailPort As Int64 = 0
            Try
                iMailPort = Convert.ToInt16(Commons.Modules.sMailFromPort)
            Catch ex As Exception
            End Try


            'Dim frm As New VS.Support.frmVSReply(Convert.ToInt16(Commons.Modules.TypeLanguage), Commons.Modules.UserName, Commons.Modules.sTenNhanVienMD, sTenCty, sMail, sDThoai, sDThoai, iCus, Commons.Modules.sMailFrom, Commons.Modules.sMailFromPass, Commons.Modules.sMailFromSmtp, iMailPort)
            'frm.ShowDialog()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try


    End Function

    Public Shared Function ShowELearning() As Boolean
        Try
            Dim iCus As Int64 = -1
            sTenCty = "VietSoft; sales@vietsoft.com.vn; (028) 38 110 770; (028) 38 110 770; 1"
            Try
                Dim dt As DataTable = New DataTable()
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT  ISNULL(EMAIL,'') AS EMAIL,ISNULL(Phone,'') AS DIEN_THOAI, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_CTY_TIENG_VIET ELSE ISNULL(NULLIF(TEN_CTY_TIENG_ANH,''), TEN_CTY_TIENG_VIET) END AS TEN_CTY,ISNULL(CusID,-1) AS CustomerID ,ISNULL(iConID,-1) AS iContractID FROM THONG_TIN_CHUNG "))

                iCus = dt.Rows(0)("CustomerID").ToString()
            Catch
            End Try
            'Dim frm As New VS.Support.frmELearning(iCus)
            'frm.ShowDialog()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


End Class