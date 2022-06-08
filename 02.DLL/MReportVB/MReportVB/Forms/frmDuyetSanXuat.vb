Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.Utils.Menu
Imports MVControl

Public Class frmDuyetSanXuat
    Private bHienthi As Integer
    Private sql As String = ""
    Private CoAnHienDuyet As Boolean = False
    Private DSDuyet As New DataTable
    Private MucUuTien As New DataTable
    Private repositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private bDuyet As Boolean = False

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Close()
    End Sub

    Private Sub GoiMail(ByVal bDuyet As Boolean)
        Try
            If Commons.Modules.iLoaiGoiMail = 1 Or Commons.Modules.iLoaiGoiMail = 3 Then
                If (Commons.Modules.sMailFrom = "" Or Commons.Modules.sMailFromPass = "" Or Commons.Modules.sMailFromSmtp = "" Or Commons.Modules.sMailFromPort = "") Then
                    'MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "KhongCoThongTinMailGoi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Dim dtSTT As New DataTable
            Dim STT As Integer
            STT = Convert.ToInt32(GridViewDuyet.GetFocusedRowCellValue("STT").ToString())
            Dim sSql, sNXuong, sMail, sMailNX, sMailUser As String
            Dim sBT As String = "DSX" & Commons.Modules.UserName
            sSql = "SELECT DISTINCT STT FROM " & sBT & " WHERE CHON = 1"
            dtSTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtSTT.Rows.Count = 0 Then
                'MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "KhongCoDuLieuGoi", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
            sNXuong = ""
            sMail = ""
            sMailUser = ""
            sSql = ""
            sMailNX = ""


            For Each vr As DataRow In dtSTT.Rows
                STT = vr("STT")
                If bDuyet Then
                    sNXuong = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, " SELECT TOP 1 MS_N_XUONG FROM YEU_CAU_NSD WHERE STT = " & STT.ToString)
                    sMailNX = Commons.Modules.ObjSystems.MLoadMailNX(sNXuong, IIf(sMailNX = "", "", sMailNX & ";"), 2)
                End If
                sMail = IIf(sMail = "", "", sMail & ";") + SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                                    " SELECT ISNULL(USER_MAIL ,'') AS USER_MAIL FROM YEU_CAU_NSD A INNER JOIN USERS B ON A.USER_LAP = B.USERNAME WHERE STT = " & STT.ToString)

            Next

            If txtMailTo.Text.Trim <> "" Then
                sMail = sMail + ";" + txtMailTo.Text
            End If

            If sMailNX = "" And sMail = "" Then
                'MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "KhongCoMailGoi", Commons.Modules.TypeLanguage))
                Exit Sub
            End If

            Dim frm As ReportMain.frmPBTBanHanh = New ReportMain.frmPBTBanHanh()
            frm.iLoai = 3



            If bDuyet = False Then
                frm.sNXuong = sMail
            Else
                frm.sNXuong = IIf(sMail = "", sMailNX, sMail & ";" + sMailNX)
            End If
            Try
                sSql = "SELECT ISNULL(USER_MAIL,'') FROM dbo.USERS WHERE USERNAME = '" + Commons.Modules.UserName + "' "
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
                frm.sNXuong = IIf(sSql = "", frm.sNXuong, frm.sNXuong & ";" + sSql)
            Catch ex As Exception

            End Try



            frm.sNXuong = Commons.Modules.ObjSystems.MBoMailTrung(frm.sNXuong)
            frm.dtTmp = New DataTable()
            Commons.Modules.ObjSystems.XoaTable("DSX")
            sSql = "SELECT DISTINCT STT,STT_VAN_DE,MS_MAY  INTO DSX FROM " & sBT & " WHERE CHON = 1"
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql)
            frm.dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMailDuyetYCBT", Commons.Modules.TypeLanguage, IIf(bDuyet, 1, 0)))
            Commons.Modules.ObjSystems.XoaTable("DSX")
            If frm.dtTmp.Rows.Count = 0 Then
                'MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
            If bDuyet = False Then Commons.Modules.SQLString = "0DUYET" Else Commons.Modules.SQLString = ""


            frm.ShowDialog()
            Commons.Modules.SQLString = ""
        Catch ex As Exception

        End Try

    End Sub


    Private Sub VisibleControl(ByVal Value As Boolean)
        Try
            cmdDuyet.Visible = Value
            btnKgDuyet.Visible = Value
            cmdThoat.Visible = Value
            cmdGhi.Visible = Not Value
            cmdKhong.Visible = Not Value
            btnXemTL.Visible = Value
            If GroupChon.SelectedIndex = 0 Then
                btnALL.Visible = Not Value
                btnNotAll.Visible = Not Value
            Else
                txtMSMay.Enabled = Value
            End If
            If DSDuyet.Rows.Count = 0 Then
                cmdDuyet.Enabled = False
                btnKgDuyet.Enabled = False
                btnXemTL.Enabled = False
            Else
                cmdDuyet.Enabled = True
                btnKgDuyet.Enabled = True
                btnXemTL.Enabled = True
                If CoAnHienDuyet = True Then
                    cmdDuyet.Visible = Value
                    btnKgDuyet.Visible = Value
                Else
                    cmdDuyet.Visible = False
                    btnKgDuyet.Visible = False
                End If

            End If
            GroupChon.Enabled = Value
            optDuyet.Enabled = Value
            EnableControl(Not Value)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDChuyen()
        Try
            KiemApp.MLoadCboTreeList(cboNXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG")
        Catch
        End Try
    End Sub

    Private Sub LoadLoaiMay()
        Try
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "")
        Catch
        End Try
    End Sub
    Private Sub frmDuyetSanXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupChon.SelectedIndex = 0
        GridViewDuyet.BestFitColumns()
        flagLoad = True
        datTNgay.EditValue = DateSerial(DateTime.Now.Year, DateTime.Now.Month, 1)
        datDNgay.EditValue = DateTime.Now
        LoadLoaiMay()
        LoadDChuyen()
        Try
            Try
                bHienthi = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 ISNULL(HIEN_THI_YCBT,0) FROM THONG_TIN_CHUNG"))
            Catch ex As Exception
                bHienthi = 0
            End Try

            sql = "SELECT '0' MS_UU_TIEN, '' TEN_UU_TIEN UNION ALL select MS_UU_TIEN, TEN_UU_TIEN from MUC_UU_TIEN ORDER BY MS_UU_TIEN"
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbMucUuTien, sql, "MS_UU_TIEN", "TEN_UU_TIEN", lblMucUuTien.Text)
            cmbMucUuTien.Properties.ShowHeader = False
            cmbMucUuTien.Properties.ShowFooter = False
            cmbMucUuTien.Properties.DropDownRows = 20
            AnHienNutDuyet()
            VisibleControl(True)
            LoadGrid()
            txtUser.Text = ""
            txtThoiGian.Text = ""
            chkThucHien.Checked = False
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            tabDuyetYC.TabPages(0).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "tabDuyetSanXuat", Commons.Modules.TypeLanguage)
            tabDuyetYC.TabPages(1).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "tabBoPhanTheoYeuCau", Commons.Modules.TypeLanguage)
            flagLoad = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        optDuyet.SelectedIndex = 0

        If DSDuyet.Rows.Count = 0 Then
            cmdDuyet.Enabled = False
            btnKgDuyet.Enabled = False
            btnXemTL.Enabled = False
        Else
            cmdDuyet.Enabled = True
            btnKgDuyet.Enabled = True
            btnXemTL.Enabled = True
            If cmdGhi.Visible = False Then
                Try
                    cmdDuyet.Enabled = GridViewDuyet.GetFocusedRow("QUYEN_DUYET").ToString()
                    btnKgDuyet.Enabled = GridViewDuyet.GetFocusedRow("QUYEN_DUYET").ToString()
                Catch ex As Exception
                    cmdDuyet.Enabled = True
                    btnKgDuyet.Enabled = True
                End Try
            End If
        End If
        ControlButton()
        flagLoad = False
        If CoAnHienDuyet = False Then
            cmdDuyet.Visible = False
            btnKgDuyet.Visible = False
        End If

    End Sub

    Private Sub cmdDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDuyet.Click
        bDuyet = True
        CapNhapDuyet(1)
    End Sub

    Private Sub btnKgDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKgDuyet.Click
        bDuyet = False
        CapNhapDuyet(0)
    End Sub

    Private Sub CapNhapDuyet(ByVal Duyet As Integer)
        Try
            If GridViewDuyet.RowCount = 0 Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "msgKhongCoDuLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If


            If GroupChon.SelectedIndex = 1 Then
                If txtUser.Text.Trim.ToUpper <> Commons.Modules.UserName.ToUpper Then
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "KhongcungUser", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
            End If

            VisibleControl(False)
            MoKhoaLuoi(True)
            If GroupChon.SelectedIndex = 0 Then
                chkThucHien.Enabled = True
                txtUser.Text = Commons.Modules.UserName
                txtMailTo.Text = ""
                txtYKien.Text = ""
            Else
                If GroupChon.SelectedIndex = 1 Then
                    chkThucHien.Enabled = True
                    GridControlDuyet.Enabled = False
                Else
                    chkThucHien.Enabled = False
                    GridControlDuyet.Enabled = False
                End If
            End If
            If Duyet = 1 Then chkThucHien.Checked = False Else chkThucHien.Checked = True
            txtThoiGian.Text = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
            datNgay.DateTime = Date.Now

            GridViewDuyet.SetFocusedRowCellValue("CHON", True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim dtTmp As New DataTable
        dtTmp = (CType(GridControlDuyet.DataSource, DataTable)).Copy

        dtTmp.DefaultView.RowFilter = "CHON = 1"
        dtTmp = dtTmp.DefaultView.ToTable

        If dtTmp.Rows.Count > 1 Then
            cmbMucUuTien.Enabled = False
        Else
            cmbMucUuTien.Enabled = True
        End If
        Try
            cmbMucUuTien.EditValue = CType(GridViewDuyet.GetFocusedRowCellValue("MS_UU_TIEN"), Integer)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        Dim NgayGio As String = ""
        Dim TableTam As String = "DSX" & Commons.Modules.UserName

        Try
            Try
                Dim iLen As Integer
                iLen = Len(txtThoiGian.Text)
                If iLen < 19 Then
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "NgayGioSai", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If

                NgayGio = Format(CDate(txtThoiGian.Text), "MM/dd/yyyy HH:mm:ss")
            Catch ex As Exception
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "NgayGioSai", Commons.Modules.TypeLanguage))
                Exit Sub
            End Try

            If cmbMucUuTien.Text.Trim = "" Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "msgVuiLongNhapMucUuTien", Commons.Modules.TypeLanguage))
                cmbMucUuTien.Focus()
                Exit Sub
            End If

            If txtYKien.Text.Trim = "" And bDuyet = False Then
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "msgVuiLongNhapYKien", Commons.Modules.TypeLanguage))
                txtYKien.Focus()
                Exit Sub
            End If

            If txtMailTo.Text.Trim <> "" Then
                If Commons.Modules.ObjSystems.MCheckEmail(txtMailTo.Text) = False Then
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "MailSai", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
            End If

            If GroupChon.SelectedIndex = 0 Then
                DSDuyet.AcceptChanges()
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, TableTam, DSDuyet, "")
                If cmbMucUuTien.Enabled = True Then
                    sql = "UPDATE " & TableTam & " SET USERNAME_DSX ='" & txtUser.Text & "',THOI_GIAN_DSX='" & NgayGio & "',MS_UU_TIEN='" & cmbMucUuTien.EditValue.ToString & "'," &
                          "EMAIL_DSX = N'" & txtMailTo.Text.Trim & "',Y_KIEN_DSX = N'" & txtYKien.Text.Trim & "',THUC_HIEN_DSX ='" & IIf(chkThucHien.Checked = True, 0, 1) & "'" &
                          " WHERE ISNULL(CHON,0) <>0"
                Else
                    sql = "UPDATE " & TableTam & " SET USERNAME_DSX ='" & txtUser.Text & "',THOI_GIAN_DSX='" & NgayGio & "', " &
                          "EMAIL_DSX='" & txtMailTo.Text.Trim & "',Y_KIEN_DSX = N'" & txtYKien.Text.Trim & "',THUC_HIEN_DSX='" & IIf(chkThucHien.Checked = True, 0, 1) & "'" &
                          " WHERE ISNULL(CHON,0) <>0"

                End If

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                sql = "UPDATE YEU_CAU_NSD_CHI_TIET SET MS_UU_TIEN =A.MS_UU_TIEN,USERNAME_DSX=A.USERNAME_DSX,THOI_GIAN_DSX=A.THOI_GIAN_DSX ," &
                        " Y_KIEN_DSX=A.Y_KIEN_DSX ,THUC_HIEN_DSX=A.THUC_HIEN_DSX , EMAIL_DSX=A.EMAIL_DSX FROM  YEU_CAU_NSD_CHI_TIET B INNER JOIN " &
                        " ( SELECT STT, MS_MAY,STT_VAN_DE,MS_UU_TIEN ,USERNAME_DSX,THOI_GIAN_DSX,Y_KIEN_DSX,THUC_HIEN_DSX,EMAIL_DSX FROM " & TableTam & ") A ON " &
                        " A.STT = B.STT And A.MS_MAY = B.MS_MAY And A.STT_VAN_DE = B.STT_VAN_DE "
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                GoiMail(IIf(chkThucHien.Checked = True, False, True))
                LoadGrid()
                LocDuLieu()
                VisibleControl(True)
                MoKhoaLuoi(False)
            End If
            If GroupChon.SelectedIndex = 1 Or GroupChon.SelectedIndex = 2 Then
                sql = "UPDATE YEU_CAU_NSD_CHI_TIET SET USERNAME_DSX ='" & txtUser.Text & "',THOI_GIAN_DSX='" & NgayGio & "',MS_UU_TIEN='" & cmbMucUuTien.EditValue.ToString & "'," &
                 "EMAIL_DSX='" & txtMailTo.Text.Trim & "',Y_KIEN_DSX='" & txtYKien.Text.Trim & "',THUC_HIEN_DSX='" & IIf(chkThucHien.Checked = True, 0, 1) & "'" &
                      " WHERE STT='" & txtSTT.Text & "' and  MS_MAY='" & txtMSM.Text & "' and  STT_VAN_DE='" & txtSTVD.Text & "'"

                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                Dim luuSTT As String = txtSTT.Text
                Dim luuMSM As String = txtMSM.Text
                Dim luuSTVD As String = txtSTVD.Text
                sql = "SELECT CONVERT(BIT,1) AS CHON , * INTO " & TableTam & " FROM YEU_CAU_NSD_CHI_TIET WHERE STT='" & txtSTT.Text & "' and  MS_MAY='" & txtMSM.Text & "' and  STT_VAN_DE='" & txtSTVD.Text & "'"
                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                GoiMail(IIf(chkThucHien.Checked = True, False, True))
                LoadGrid()
                LocDuLieu()
                Dim dv As DataView
                Dim i As Integer
                Dim j As Integer
                Dim LuuVT As Integer = -1
                dv = DSDuyet.DefaultView
                For i = 0 To dv.Count - 1
                    j = DSDuyet.Rows.IndexOf(dv(i).Row)
                    If j >= 0 Then
                        If DSDuyet.Rows(j).Item("STT").ToString = luuSTT And DSDuyet.Rows(j).Item("MS_MAY").ToString = luuMSM And DSDuyet.Rows(j).Item("STT_VAN_DE").ToString = luuSTVD Then
                            LuuVT = i
                            Exit For
                        End If
                    End If
                Next

                GridControlDuyet.Enabled = True
                If LuuVT > 0 Then
                    GridViewDuyet.FocusedRowHandle = LuuVT
                End If


                VisibleControl(True)
                MoKhoaLuoi(False)
            End If

            LodDDuyet()

        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "CapNhapKhongThanhCong", Commons.Modules.TypeLanguage))
        End Try
        cmbMucUuTien.Enabled = False
        Commons.Modules.ObjSystems.XoaTable(TableTam)
        ControlButton()
    End Sub
    Private flagLoad As Boolean = True
    Private Sub cmdKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKhong.Click
        Try
            VisibleControl(True)
            MoKhoaLuoi(False)
            GridControlDuyet.Enabled = True
            LoadGrid()

        Catch ex As Exception

        End Try
        cmbMucUuTien.Enabled = False
        ControlButton()
        txtThoiGian.Text = ""
        txtUser.Text = ""
        txtMailTo.Text = ""
        cmbMucUuTien.EditValue = 0
        chkThucHien.Checked = False
    End Sub

    Private Sub EnableControl(ByVal Value As Boolean)
        Try
            txtThoiGian.Enabled = Value
            datNgay.Enabled = Value
            txtYKien.Enabled = Value
            txtMailTo.Enabled = Value
            chkThucHien.Enabled = Value
            cmbMucUuTien.Enabled = Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnHienNutDuyet()
        Dim vtb As New DataTable
        Try
            sql = "select distinct USERNAME  from USER_CHUC_NANG  where USERNAME=N'" & Commons.Modules.UserName & "' AND STT=13"
            vtb.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            If vtb.Rows.Count > 0 Then
                CoAnHienDuyet = True
            Else
                CoAnHienDuyet = False
            End If
        Catch ex As Exception

        End Try
    End Sub



    Public Sub LoadGrid()
        Dim LoaiOption As Integer
        Try
            GridViewDuyet.BestFitColumns()
            LoaiOption = GroupChon.SelectedIndex
            Dim img As Byte() = Commons.Modules.ObjSystems.MImageToByteArray(Global.Commons.My.Resources.Resources.attachment)
            DSDuyet = New DataTable
            DSDuyet.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_DuyetSanXuat", Commons.Modules.UserName, LoaiOption, Commons.Modules.TypeLanguage, img, datTNgay.DateTime.Date, datDNgay.DateTime.Date, cboNXuong.EditValue, cboLMay.EditValue))
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControlDuyet, GridViewDuyet, DSDuyet, True, False, False, True, True, Me.Name)
            LodDDuyet()
            txtSTT.DataBindings.Clear()
            txtSTT.DataBindings.Add("Text", DSDuyet, "STT")
            txtSTVD.DataBindings.Clear()
            txtSTVD.DataBindings.Add("Text", DSDuyet, "STT_VAN_DE")
            txtMSM.DataBindings.Clear()
            txtMSM.DataBindings.Add("Text", DSDuyet, "MS_MAY")
            GridViewDuyet.Columns("MS_CACH_TH").Visible = False
            GridViewDuyet.Columns("STT_VAN_DE").Visible = False
            GridViewDuyet.Columns("QUYEN_DUYET").Visible = False

            GridViewDuyet.Columns("STT").Visible = False
            GridViewDuyet.Columns("MS_UU_TIEN").Visible = False
            GridViewDuyet.Columns("CHON").Width = 100
            If LoaiOption = 0 Then
                GridViewDuyet.Columns("CHON").Visible = True
            Else
                GridViewDuyet.Columns("CHON").Visible = False
            End If


            Dim imgTaiLieu As RepositoryItemPictureEdit = New RepositoryItemPictureEdit()
            imgTaiLieu.NullText = " "
            GridViewDuyet.Columns("TAI_LIEU").ColumnEdit = imgTaiLieu
            GridViewDuyet.Columns("TAI_LIEU").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("TAI_LIEU").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("TAI_LIEU").OptionsColumn.AllowSize = False
            GridViewDuyet.Columns("TAI_LIEU").Width = 55

            GridViewDuyet.Columns("MS_MAY").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("MS_MAY").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("MS_MAY").Width = 120
            GridViewDuyet.Columns("TEN_MAY").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("TEN_MAY").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("TEN_MAY").Width = 150
            GridViewDuyet.Columns("TEN_LOAI_YEU_CAU_BT").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("TEN_LOAI_YEU_CAU_BT").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("TEN_LOAI_YEU_CAU_BT").Width = 150
            GridViewDuyet.Columns("MO_TA_TINH_TRANG").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("MO_TA_TINH_TRANG").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("MO_TA_TINH_TRANG").Width = 250
            GridViewDuyet.Columns("NGAY").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("NGAY").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("NGAY").Width = 100
            GridViewDuyet.Columns("MS_YEU_CAU").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("MS_YEU_CAU").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("MS_YEU_CAU").Visible = True
            GridViewDuyet.Columns("SO_YEU_CAU").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("SO_YEU_CAU").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("SO_YEU_CAU").Visible = False
            GridViewDuyet.Columns("NGUOI_YEU_CAU").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("NGUOI_YEU_CAU").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("NGUOI_YEU_CAU").Width = 150
            GridViewDuyet.Columns("YEU_CAU").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("YEU_CAU").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("YEU_CAU").Width = 200
            GridViewDuyet.Columns("USERNAME_DSX").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("USERNAME_DSX").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("USERNAME_DSX").Width = 120
            GridViewDuyet.Columns("USERNAME_DSX").Visible = False

            GridViewDuyet.Columns("THOI_GIAN_DSX").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("THOI_GIAN_DSX").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("THOI_GIAN_DSX").Width = 150
            GridViewDuyet.Columns("MS_UU_TIEN").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("MS_UU_TIEN").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("MS_UU_TIEN").Width = 100

            GridViewDuyet.Columns("Y_KIEN_DSX").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("Y_KIEN_DSX").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("Y_KIEN_DSX").Width = 220
            GridViewDuyet.Columns("Y_KIEN_DSX").Visible = False
            GridViewDuyet.Columns("THUC_HIEN_DSX").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("THUC_HIEN_DSX").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("THUC_HIEN_DSX").Width = 100
            GridViewDuyet.Columns("THUC_HIEN_DSX").Visible = False
            GridViewDuyet.Columns("EMAIL_DSX").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("EMAIL_DSX").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("EMAIL_DSX").Width = 200
            GridViewDuyet.Columns("EMAIL_DSX").Visible = False

            GridViewDuyet.Columns("Ten_N_XUONG").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("Ten_N_XUONG").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("Ten_N_XUONG").Visible = False
            GridViewDuyet.Columns("TEN_UU_TIEN").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("TEN_UU_TIEN").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("THOI_GIAN_DSX").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridViewDuyet.Columns("THOI_GIAN_DSX").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            GridViewDuyet.Columns("THOI_GIAN_DSX").Visible = False
            GridViewDuyet.Columns("NGAY_XAY_RA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridViewDuyet.Columns("NGAY_XAY_RA").DisplayFormat.FormatString = "dd/MM/yyyy"
            GridViewDuyet.Columns("GIO_XAY_RA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridViewDuyet.Columns("GIO_XAY_RA").DisplayFormat.FormatString = "HH:mm:ss"
            MoKhoaLuoi(False)
            DSDuyet.Columns("CHON").ReadOnly = False
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
        Try
            If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = True Then
                btnXemTL.Visible = False
            Else
                btnXemTL.Visible = True
            End If
        Catch ex As Exception

        End Try

        LoadNutDuyet()

    End Sub

    Private Sub ShowText()
        If cmdGhi.Visible = True Then Exit Sub
        Dim ss As String = ""
        Try
            Dim sql As String = "STT ='" + txtSTT.Text + "' and MS_MAY='" & txtMSM.Text & "' and STT_VAN_DE='" & txtSTVD.Text & "'"
            Dim _dtvTmp As New DataView(DSDuyet, "STT ='" + txtSTT.Text + "' and MS_MAY='" & txtMSM.Text & "' and STT_VAN_DE='" & txtSTVD.Text & "'", "", DataViewRowState.CurrentRows)
            Dim vtb As New DataTable
            vtb = _dtvTmp.ToTable
            For Each vr As DataRow In _dtvTmp.ToTable.Rows
                txtYKien.Text = vr("Y_KIEN_DSX").ToString()
                txtMailTo.Text = vr("EMAIL_DSX").ToString
                cmbMucUuTien.EditValue = Convert.ToInt32(vr("MS_UU_TIEN"))
                txtUser.Text = vr("USERNAME_DSX").ToString
                txtThoiGian.Text = vr("THOI_GIAN_DSX").ToString
                datNgay.DateTime = CType(vr("THOI_GIAN_DSX").ToString, Date)

                'If CBool(vr("THUC_HIEN_DSX")) = True Then
                '    chkThucHien.Checked = True
                'Else
                '    chkThucHien.Checked = False
                'End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MoKhoaLuoi(ByVal value As Boolean)
        Try
            GridViewDuyet.Columns("CHON").OptionsColumn.AllowEdit = value
            GridViewDuyet.Columns("CHON").OptionsColumn.AllowFocus = value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupChon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupChon.SelectedIndexChanged
        LoadGrid()
        btnKgDuyet.Enabled = True
        cmdDuyet.Enabled = True
        If GroupChon.SelectedIndex = 0 Then
            GridViewDuyet.Columns("MO_TA_TINH_TRANG").Width = 260
            chkThucHien.Checked = False
        End If

        If GroupChon.SelectedIndex = 1 Then
            GridViewDuyet.Columns("MO_TA_TINH_TRANG").Width = 360
            cmdDuyet.Enabled = False
            chkThucHien.Checked = False
        End If

        If GroupChon.SelectedIndex = 2 Then
            GridViewDuyet.Columns("MO_TA_TINH_TRANG").Width = 360
            btnKgDuyet.Enabled = False
            chkThucHien.Checked = True
        End If

        LodDDuyet()
        ControlButton()
        Try
            If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = True Then
                btnXemTL.Visible = False
            Else
                btnXemTL.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LocDuLieu()
        Try
            Dim sDk As String
            sDk = " AND ( MS_YEU_CAU LIKE '%" & txtMSMay.Text.Trim & "%' or  SO_YEU_CAU LIKE '%" & txtMSMay.Text.Trim & "%' or  MS_MAY LIKE '%" & txtMSMay.Text.Trim & "%' or TEN_MAY like '%" & txtMSMay.Text.Trim & "%' or MO_TA_TINH_TRANG like '%" & txtMSMay.Text.Trim & "%')"
            If GroupChon.SelectedIndex = 0 Then
                If GridViewDuyet.ActiveFilterString <> "" Then
                    If txtMSMay.Text.Trim <> "" Then
                        DSDuyet.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and THUC_HIEN_DSX IS NULL " & sDk
                    Else
                        DSDuyet.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and THUC_HIEN_DSX IS NULL "
                    End If
                Else
                    If txtMSMay.Text.Trim <> "" Then
                        DSDuyet.DefaultView.RowFilter = " THUC_HIEN_DSX IS NULL " & sDk
                    Else
                        DSDuyet.DefaultView.RowFilter = " THUC_HIEN_DSX IS NULL"
                    End If
                End If
            End If

            If GroupChon.SelectedIndex = 1 Then
                If GridViewDuyet.ActiveFilterString <> "" Then
                    If txtMSMay.Text.Trim <> "" Then
                        DSDuyet.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and THUC_HIEN_DSX =1 AND MS_CACH_TH is null " & sDk
                    Else
                        DSDuyet.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and THUC_HIEN_DSX =1 AND MS_CACH_TH is null"
                    End If
                Else
                    If txtMSMay.Text.Trim <> "" Then
                        DSDuyet.DefaultView.RowFilter = " THUC_HIEN_DSX =1 AND MS_CACH_TH is null   " & sDk
                    Else
                        DSDuyet.DefaultView.RowFilter = " THUC_HIEN_DSX =1 AND MS_CACH_TH is null"
                    End If
                End If
            End If
            If GroupChon.SelectedIndex = 2 Then
                If GridViewDuyet.ActiveFilterString <> "" Then
                    If txtMSMay.Text.Trim <> "" Then
                        DSDuyet.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and THUC_HIEN_DSX =0  " & sDk
                    Else
                        DSDuyet.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and THUC_HIEN_DSX =0"
                    End If
                Else
                    If txtMSMay.Text.Trim <> "" Then
                        DSDuyet.DefaultView.RowFilter = " THUC_HIEN_DSX =0  " & sDk
                    Else
                        DSDuyet.DefaultView.RowFilter = " THUC_HIEN_DSX =0"
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMSMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMSMay.EditValueChanged
        LocDuLieu()
    End Sub

    Private Sub GridViewDuyet_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridViewDuyet.MouseUp
        Try
            If cmdGhi.Visible = False Then
                If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = True Then
                    btnXemTL.Visible = False
                Else
                    btnXemTL.Visible = True
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewDuyet_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridViewDuyet.RowCellStyle
        If bHienthi <> 1 Then Exit Sub
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
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

    Private Sub txtSTT_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSTT.EditValueChanged
        ShowText()
    End Sub

    Private Sub txtMSM_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMSM.EditValueChanged
        ShowText()
    End Sub

    Private Sub txtSTVD_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSTVD.EditValueChanged
        ShowText()
    End Sub

    Private Sub GridViewDuyet_CustomDrawCell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridViewDuyet.CustomDrawCell
        If bHienthi <> 0 Then Exit Sub
        If e.Column.FieldName.ToUpper.ToString() <> "TEN_UU_TIEN" Then Exit Sub

        Dim MS_UU_TIEN As String = ""
        MS_UU_TIEN = Convert.ToString(GridViewDuyet.GetRowCellValue(e.RowHandle, "MS_UU_TIEN"))

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

    Private Sub btnALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnALL.Click
        Dim i As Integer
        For i = 0 To GridViewDuyet.RowCount - 1
            GridViewDuyet.SetRowCellValue(i, "CHON", 1)
        Next

    End Sub

    Private Sub btnNotAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotAll.Click
        Dim i As Integer
        For i = 0 To GridViewDuyet.RowCount - 1
            GridViewDuyet.SetRowCellValue(i, "CHON", 0)
        Next
    End Sub

    Private Sub GridViewDuyet_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDuyet.FocusedRowChanged
        'If GroupChon.SelectedIndex = 0 Then chkThucHien.Checked = True
        Try
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_BO_PHAN", GridViewDuyet.GetFocusedRow("STT").ToString(),
                                             GridViewDuyet.GetFocusedRow("MS_MAY").ToString(),
                                            GridViewDuyet.GetFocusedRow("STT_VAN_DE").ToString()))
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBoPhan, grvBoPhan, dt, False, False, True, False)

            grvBoPhan.Columns("STT").Visible = False
            grvBoPhan.Columns("MS_MAY").Visible = False
            grvBoPhan.Columns("STT_VAN_DE").Visible = False
            grvBoPhan.Columns("STT_BO_PHAN").Visible = False
            grvBoPhan.Columns("DEL").Visible = False
            grvBoPhan.Columns("MS_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_BO_PHAN", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("TEN_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("MS_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_PT", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("TEN_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_PT", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("MS_BO_PHAN").Width = 150
            grvBoPhan.Columns("TEN_BO_PHAN").Width = 350
            grvBoPhan.Columns("MS_PT").Width = 200
        Catch
            grvBoPhan.Columns("MS_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_BO_PHAN", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("TEN_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("MS_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_PT", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("TEN_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_PT", Commons.Modules.TypeLanguage)
        End Try



        LoadNutDuyet()

        Dim dtTmp As New DataTable
        dtTmp = (CType(GridControlDuyet.DataSource, DataTable)).Copy
        dtTmp.DefaultView.RowFilter = "CHON = 1"
        dtTmp = dtTmp.DefaultView.ToTable

        If cmdGhi.Visible = False Then Exit Sub
        If dtTmp.Rows.Count > 1 Then
            cmbMucUuTien.Enabled = False
        Else
            cmbMucUuTien.Enabled = True
        End If
        ControlButton()
        'ShowText()
    End Sub
    Private Sub LoadNutDuyet()
        If DSDuyet.Rows.Count = 0 Then
            cmdDuyet.Enabled = False
            btnKgDuyet.Enabled = False
            btnXemTL.Enabled = False
        Else
            cmdDuyet.Enabled = True
            btnKgDuyet.Enabled = True
            btnXemTL.Enabled = True
            If cmdGhi.Visible = False Then
                Try
                    cmdDuyet.Enabled = True
                    btnKgDuyet.Enabled = True
                    cmdDuyet.Enabled = GridViewDuyet.GetFocusedRow("QUYEN_DUYET").ToString()
                    btnKgDuyet.Enabled = GridViewDuyet.GetFocusedRow("QUYEN_DUYET").ToString()
                    If optDuyet.SelectedIndex = 0 Then
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                    End If
                Catch ex As Exception
                    cmdDuyet.Enabled = False
                    btnKgDuyet.Enabled = False
                End Try
                ControlButton()
                'ShowText()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub GridControlDuyet_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControlDuyet.Validated
        If cmdGhi.Visible = False Then Exit Sub

        Dim dtTmp As New DataTable
        dtTmp = (CType(GridControlDuyet.DataSource, DataTable)).Copy

        dtTmp.DefaultView.RowFilter = "CHON = 1"
        dtTmp = dtTmp.DefaultView.ToTable

        If dtTmp.Rows.Count > 1 Then
            cmbMucUuTien.Enabled = False
        Else
            cmbMucUuTien.Enabled = True
        End If
    End Sub

    Private Sub datNgay_CloseUp(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles datNgay.CloseUp
        If cmdGhi.Visible = False Then Exit Sub
        txtThoiGian.Text = datNgay.DateTime.ToString("dd/MM/yyyy") + Date.Now.ToString(" HH:mm:ss")



    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDuyet.SelectedIndexChanged
        LodDDuyet()
        ControlButton()
        Try
            If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = True Then
                btnXemTL.Visible = False
            Else
                btnXemTL.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LodDDuyet()
        Dim sDKien As String
        sDKien = ""
        If optDuyet.SelectedIndex = 0 Then
            sDKien = " QUYEN_DUYET = 1"
        End If

        If optDuyet.SelectedIndex = 1 Then
            sDKien = " QUYEN_DUYET = 0"
        End If

        DSDuyet.DefaultView.RowFilter = sDKien
        If DSDuyet.Rows.Count = 0 Then
            cmdDuyet.Enabled = False
            btnKgDuyet.Enabled = False
            btnXemTL.Enabled = False
        Else
            cmdDuyet.Enabled = True
            btnKgDuyet.Enabled = True
            btnXemTL.Enabled = True
            If cmdGhi.Visible = False Then
                Try
                    cmdDuyet.Enabled = GridViewDuyet.GetFocusedRow("QUYEN_DUYET").ToString()
                    btnKgDuyet.Enabled = GridViewDuyet.GetFocusedRow("QUYEN_DUYET").ToString()
                    If optDuyet.SelectedIndex = 0 Then
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                    End If
                Catch ex As Exception
                    cmdDuyet.Enabled = True
                    btnKgDuyet.Enabled = True
                End Try
                Exit Sub
            End If
        End If

    End Sub

    Private Sub btnXemHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemTL.Click
        XemTL()
    End Sub

    Private Sub GridViewDuyet_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViewDuyet.DoubleClick
        XemTL()
    End Sub

    Private Sub XemTL()
        If cmdDuyet.Visible = False Then Exit Sub
        Dim sSql As String
        Try

            sSql = "SELECT * FROM YEU_CAU_NSD_CHI_TIET_HINH WHERE STT = " & GridViewDuyet.GetFocusedRowCellValue("STT").ToString() & " AND STT_VAN_DE = " & GridViewDuyet.GetFocusedRowCellValue("STT_VAN_DE").ToString()
            Dim dtTmp As New DataTable
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql))
            If dtTmp.Rows.Count = 0 Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, Me.Name, "msgKhongCoTaiLieu", Commons.Modules.TypeLanguage))
                Exit Sub
            End If


            If dtTmp.Rows.Count > 1 Then
                Dim frm As New frmYCNSDXemTL
                frm.dtChung = dtTmp
                frm.ShowDialog()
            Else
                Dim sDDan As String
                sDDan = dtTmp.Rows(0)("DUONG_DAN").ToString
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start(sDDan)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ToolTipController1_GetActiveObjectInfo(ByVal sender As System.Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        Dim validColumn As Boolean
        validColumn = False

        If e.SelectedControl IsNot GridControlDuyet Then
            Return
        End If

        Dim hitInfo As GridHitInfo
        hitInfo = GridViewDuyet.CalcHitInfo(e.ControlMousePosition)


        If hitInfo.InRow = False Then
            Return
        End If

        If hitInfo.Column Is Nothing Then
            Return
        End If

        If hitInfo.Column.FieldName = "MS_MAY" Then
            validColumn = True
        End If

        If validColumn <> True Then
            Return
        End If
        Dim toolTip As String
        toolTip = String.Empty
        Dim toolTipArgs As SuperToolTipSetupArgs
        toolTipArgs = New SuperToolTipSetupArgs()
        toolTipArgs.Title.Text = String.Empty

        Dim row As Int32

        row = hitInfo.RowHandle


        toolTipArgs.Contents.Text = GridViewDuyet.GetRowCellDisplayText(row, "TEN_MAY").ToString()
        e.Info = New ToolTipControlInfo()
        e.Info.Object = hitInfo.HitTest.ToString() + hitInfo.RowHandle.ToString()
        e.Info.ToolTipType = ToolTipType.SuperTip
        e.Info.SuperTip = New SuperToolTip()
        e.Info.SuperTip.Setup(toolTipArgs)
    End Sub
    Private Sub ControlButton()

        Select Case GroupChon.SelectedIndex 'Option tren'
            Case 0 'Chua duyet'
                Select Case optDuyet.SelectedIndex 'Option duoi'
                    Case 0 'Có quyền duyệt'
                        If DirectCast(GridControlDuyet.DataSource, DataTable).Rows.Count > 0 Then
                            cmdDuyet.Enabled = True
                            btnKgDuyet.Enabled = True
                        Else
                            cmdDuyet.Enabled = False
                            btnKgDuyet.Enabled = False
                        End If
                        If KiemQuyenDuyetYeuCau(Commons.Modules.UserName) = False Then
                            cmdDuyet.Enabled = False
                            btnKgDuyet.Enabled = False
                        End If
                        If GridViewDuyet.DataRowCount = 0 Then
                            cmdDuyet.Enabled = False
                            btnKgDuyet.Enabled = False
                        End If
                    Case 1 'Không có quyền duyệt '
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                    Case 2 'Tất cả'
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                End Select
            Case 1 'Chấp nhận, đợi bảo trì tiếp nhận'
                Select Case optDuyet.SelectedIndex 'Option duoi'
                    Case 0 'Có quyền duyệt'
                        If DirectCast(GridControlDuyet.DataSource, DataTable).Rows.Count > 0 Then
                            btnKgDuyet.Enabled = True
                        Else
                            btnKgDuyet.Enabled = False
                        End If
                        cmdDuyet.Enabled = False

                    Case 1 'Không có quyền duyệt '
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                    Case 2 'Tất cả'
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                End Select
            Case 2 'Đã duyệt, không chấp nhận'
                Select Case optDuyet.SelectedIndex 'Option duoi'
                    Case 0 'Có quyền duyệt'
                        If DirectCast(GridControlDuyet.DataSource, DataTable).Rows.Count > 0 Then
                            cmdDuyet.Enabled = True
                        Else
                            cmdDuyet.Enabled = False
                        End If

                        btnKgDuyet.Enabled = False
                    Case 1 'Không có quyền duyệt '
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                    Case 2 'Tất cả'
                        cmdDuyet.Enabled = False
                        btnKgDuyet.Enabled = False
                End Select
        End Select

    End Sub
    Private Function KiemQuyenDuyetYeuCau(ByVal user As String) As [Boolean]
        Dim sSql As String = ""
        sSql = Convert.ToString((Convert.ToString("SELECT COUNT(*) FROM dbo.USER_CHUC_NANG WHERE USERNAME='" + user + "' and STT=13")))
        Try
            If Integer.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql).ToString()) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Private Sub GridViewDuyet_MouseDown(sender As Object, e As MouseEventArgs) Handles GridViewDuyet.MouseDown
        If (e.Button = MouseButtons.Right) Then

            Dim gridView As GridView = DirectCast(sender, GridView)
            Dim hitInfo As GridHitInfo = gridView.CalcHitInfo(New Point(e.X, e.Y))
            If (((e.Button & MouseButtons.Right) <> 0) And (hitInfo.InRow) And (Not gridView.IsGroupRow(hitInfo.RowHandle))) Then

                Dim Menu As ViewMenu = New ViewMenu(gridView)
                Dim MenuItem As DXMenuItem = New DXMenuItem(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "menuViewTiepNhanThongTin",
                    Commons.Modules.TypeLanguage), New EventHandler(AddressOf MenuViewTiepNhanThongTin_Click))
                MenuItem.Tag = gridView

                Dim MenuLinkTaiLieu As DXMenuItem = New DXMenuItem(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MenuLinkTaiLieu",
                    Commons.Modules.TypeLanguage), New EventHandler(AddressOf MenuLinkTaiLieu_Click))
                MenuLinkTaiLieu.Tag = gridView


                Menu.Items.Add(MenuItem)
                Menu.Items.Add(MenuLinkTaiLieu)


                Menu.Show(hitInfo.HitPoint)
                grvTmp = gridView
                ptTmp = New Point(e.X, e.Y)
            End If
        End If

    End Sub

    Private Sub MenuLinkTaiLieu_Click(sender As Object, e As EventArgs)
        Commons.Modules.SQLString = "MenuLinkTaiLieu_Click"
        DoRowDoubleClick(grvTmp, ptTmp)
    End Sub
    Private Sub MenuViewTiepNhanThongTin_Click(sender As Object, e As EventArgs)
        Commons.Modules.SQLString = "MenuViewTiepNhanThongTin_Click"
        DoRowDoubleClick(grvTmp, ptTmp)
    End Sub
    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            Dim info1 As GridViewInfo = TryCast(GridViewDuyet.GetViewInfo(), GridViewInfo)
            Dim cell As GridCellInfo = info1.GetGridCellInfo(info.RowHandle, 0)
            Dim p As New Point(24, Control.MousePosition.Y + 13)
            Select Case Commons.Modules.SQLString
                Case "MenuViewTiepNhanThongTin_Click"
                    ShowPanel()
                Case "MenuLinkTaiLieu_Click"
                    XemTL()
                Case Else
                    XemTL()
            End Select
            Commons.Modules.SQLString = ""
        End If
    End Sub

    Private Sub ShowPanel()

        If Commons.Modules.SQLString = "0Load" Then
            Return
        End If

        Dim tbVgrid As New DataTable
        Dim TenTT As String = ""
        Dim LoaiOption As Integer
        LoaiOption = GroupChon.SelectedIndex
        If GroupChon.Properties.Items(0).Value = "optChuaxemxet" Then
            TenTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GroupChon.Properties.Items(LoaiOption).Value, Commons.Modules.TypeLanguage)
        Else
            TenTT = GroupChon.Properties.Items(LoaiOption).Description
        End If

        Dim frm As New MVControl.frmShowThongTinYCNSD()
        frm.MS_MAY = GridViewDuyet.GetFocusedRowCellValue("MS_MAY")
        frm.STT = GridViewDuyet.GetFocusedRowCellValue("STT")
        frm.MS_PBT = "-1"
        frm.STT_VAN_DE = GridViewDuyet.GetFocusedRowCellValue("STT_VAN_DE")
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog()
    End Sub

    Dim grvTmp As GridView
    Dim ptTmp As Point

    Private Sub datTNgay_EditValueChanged(sender As Object, e As EventArgs) Handles datTNgay.EditValueChanged
        If (flagLoad = True) Then Exit Sub
        LoadGrid()

    End Sub

    Private Sub datDNgay_EditValueChanged(sender As Object, e As EventArgs) Handles datDNgay.EditValueChanged
        If (flagLoad = True) Then Exit Sub
        LoadGrid()

    End Sub


    Private Sub cboNXuong_EditValuedChanged(sender As Object, e As ucComboboxTreeList.EventArgs) Handles cboNXuong.EditValuedChanged
        If (flagLoad = True) Then Exit Sub
        LoadGrid()
    End Sub

    Private Sub cboLMay_EditValueChanged(sender As Object, e As EventArgs) Handles cboLMay.EditValueChanged
        If (flagLoad = True) Then Exit Sub
        LoadGrid()
    End Sub
End Class