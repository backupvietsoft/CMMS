Imports Microsoft.ApplicationBlocks.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports System.IO
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.Utils.Menu
Imports MVControl

Public Class frmYeuCauBT
    Private sql As String
    Private bHienthi As Integer
    Private DSYeuCau As New DataTable
    Private CoAnHienDuyet As Boolean
    Private iLoad As Boolean = False
    Private isBoQuaOrCho As Integer = 0

    Public msmay As String = ""
    Public stt As String = ""
    Public sttVanDe As String = ""
    Public fromday As DateTime
    Public today As DateTime



    Private Sub frmYeuCauBT_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If cmdGhi.Visible = True Then
                Dim noidung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "Bancomuonthoatkhong", Commons.Modules.TypeLanguage)
                Dim tieude As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "thongbao", Commons.Modules.TypeLanguage)
                If XtraMessageBox.Show(noidung, tieude, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Dim flagLoad As Boolean = True
    Private Sub frmYeuCauBT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DockPanel1.Text = ""
            GroupChon.SelectedIndex = 0
            Try
                bHienthi = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, "SELECT TOP 1 ISNULL(HIEN_THI_YCBT,0) FROM THONG_TIN_CHUNG"))
            Catch ex As Exception
                bHienthi = 0
            End Try

            flagLoad = True
            datTNgay.EditValue = DateTime.Now.AddMonths(-1)
            datDNgay.EditValue = DateTime.Now
            If Not String.IsNullOrEmpty(msmay) Then
                datTNgay.DateTime = fromday
                datDNgay.DateTime = today
            End If
            LoadLoaiMay()
            LoadDChuyen()

            sql = "select MS_CACH_TH , (ISNULL(TEN_TIENG_VIET,'None') +'/ '+ ISNULL(TEN_TIENG_ANH,'None')) as TEN from CACH_THUC_HIEN   order by TEN_TIENG_VIET"
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbCachTH, sql, "MS_CACH_TH", "TEN", lblThucHien.Text)
            cmbCachTH.Properties.ShowHeader = False
            cmbCachTH.Properties.ShowFooter = False
            cmbCachTH.Properties.DropDownRows = 2

            'sql = "select cong_nhan.MS_CONG_NHAN , cong_nhan.HO + ' ' + cong_nhan.TEN  as ho_ten from CONG_NHAN   order by ho_ten"
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbNVPT, "GetCNVaiTro", "MS_CONG_NHAN", "HO_TEN", lblNVPT.Text, True, 2)
            cmbNVPT.Properties.ShowHeader = False
            cmbNVPT.Properties.ShowFooter = False
            cmbNVPT.Properties.DropDownRows = 7

            AnHienNutDuyet()
            VisibleControl(True)

            Loadgrid()
            flagLoad = False
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            tabTiepNhanYC.TabPages(0).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "tabDuyetSanXuat", Commons.Modules.TypeLanguage)
            tabTiepNhanYC.TabPages(1).Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "tabBoPhanTheoYeuCau", Commons.Modules.TypeLanguage)
            If Commons.Modules.PermisString.Equals("Read only") Then
                cmdDuyet.Enabled = False
            End If



        Catch ex As Exception

        End Try
        btnTimNV.Text = "..."
        btnNew1.Text = "+"
        btnNew2.Text = "+"
        btnKHTT.Text = "..."

        GroupChon_SelectedIndexChanged(GroupChon, Nothing)

    End Sub

    Private Sub VisibleControl(ByVal Value As Boolean)
        Try
            cmdDuyet.Visible = Value
            cmdThoat.Visible = Value
            cmdGhi.Visible = Not Value
            cmdKhong.Visible = Not Value
            btnBoQua.Visible = Value
            btnChoTH.Visible = Value
            btnALL.Visible = False
            btnNotAll.Visible = False
            btnXemTL.Visible = Value
            GroupChon.Enabled = Value
            EnableControl(Not Value)
            If CoAnHienDuyet = True Then
                cmdDuyet.Visible = Value
                btnBoQua.Visible = Value
                btnChoTH.Visible = Value
            Else
                cmdDuyet.Visible = False
                btnBoQua.Visible = False
                btnChoTH.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Loadgrid()
        If (flagLoad = True) Then Exit Sub
        Dim LoaiOption As Integer
        Dim sTenTT As String

        Try
            LoaiOption = GroupChon.SelectedIndex
            If GroupChon.Properties.Items(0).Value = "optChuaxemxet" Then
                sTenTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, GroupChon.Properties.Items(LoaiOption).Value, Commons.Modules.TypeLanguage)
            Else
                sTenTT = GroupChon.Properties.Items(LoaiOption).Description
            End If


            Dim filename As String = System.IO.Path.Combine(Directory.GetCurrentDirectory & "\reports\images", "attachment.jpg")
            Dim img As Byte() = System.IO.File.ReadAllBytes(filename)

            DSYeuCau = New DataTable

            DSYeuCau.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_TinhHinhYeuCauBT", LoaiOption, Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                    sTenTT, img, datTNgay.EditValue, datDNgay.EditValue, cboNXuong.EditValue, cboLMay.EditValue))
            DSYeuCau.PrimaryKey = {DSYeuCau.Columns(2), DSYeuCau.Columns(3), DSYeuCau.Columns(4)}
            Commons.Modules.ObjSystems.MLoadXtraGrid(GridControlDuyet, GridViewDuyet, DSYeuCau, True, False, False, True, True, Me.Name)
            Try
                'index = GridViewDuyet.LocateByValue(0, GridViewDuyet.Columns("MS_MAY"), msmay)
                If Not String.IsNullOrEmpty(msmay) Then
                    index = DSYeuCau.Rows.IndexOf(DSYeuCau.Rows.Find({stt, sttVanDe, msmay}))
                    GridViewDuyet.FocusedRowHandle = index
                End If

            Catch ex As Exception
            End Try
            If txtSTT.DataBindings.Count > 0 Then
                txtSTT.DataBindings.Clear()
            End If
            txtSTT.DataBindings.Add("Text", DSYeuCau, "STT")

            If txtSTVD.DataBindings.Count > 0 Then
                txtSTVD.DataBindings.Clear()
            End If
            txtSTVD.DataBindings.Add("Text", DSYeuCau, "STT_VAN_DE")

            If txtMSM.DataBindings.Count > 0 Then
                txtMSM.DataBindings.Clear()
            End If
            txtMSM.DataBindings.Add("Text", DSYeuCau, "MS_MAY")

            For i = 1 To DSYeuCau.Columns.Count - 1
                GridViewDuyet.Columns(i).OptionsColumn.AllowEdit = False
                GridViewDuyet.Columns(i).OptionsColumn.AllowFocus = False
            Next

            For i = 0 To DSYeuCau.Columns.Count - DSYeuCau.Columns.Count + 1
                GridViewDuyet.Columns(i).OptionsColumn.AllowEdit = False
                GridViewDuyet.Columns(i).OptionsColumn.AllowFocus = False

            Next

            GridViewDuyet.Columns("CHON").Width = 100

            Dim imgTaiLieu As RepositoryItemPictureEdit = New RepositoryItemPictureEdit()
            imgTaiLieu.NullText = " "
            GridViewDuyet.Columns("TAI_LIEU").ColumnEdit = imgTaiLieu
            GridViewDuyet.Columns("TAI_LIEU").OptionsColumn.AllowEdit = False
            GridViewDuyet.Columns("TAI_LIEU").OptionsColumn.AllowFocus = False
            GridViewDuyet.Columns("TAI_LIEU").OptionsColumn.AllowSize = False
            GridViewDuyet.Columns("NGAY_DBT").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            GridViewDuyet.Columns("MS_YEU_CAU").OptionsColumn.FixedWidth = True
            GridViewDuyet.Columns("SO_YEU_CAU").OptionsColumn.FixedWidth = True
            GridViewDuyet.Columns("NGAY_DBT").OptionsColumn.FixedWidth = True
            GridViewDuyet.Columns("NGAY_BD_KH").OptionsColumn.FixedWidth = True
            GridViewDuyet.Columns("NGAY_KT_KH").OptionsColumn.FixedWidth = True
            GridViewDuyet.Columns("NGAY_XAY_RA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridViewDuyet.Columns("NGAY_XAY_RA").DisplayFormat.FormatString = "dd/MM/yyyy"
            GridViewDuyet.Columns("GIO_XAY_RA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridViewDuyet.Columns("GIO_XAY_RA").DisplayFormat.FormatString = "HH:mm:ss"

            AnHienCot()
            txtMSM.Visible = False
            txtSTVD.Visible = False
            txtSTT.Visible = False

            'Dim MemoEdit As RepositoryItemMemoEdit = New RepositoryItemMemoEdit()
            'MemoEdit.ReadOnly = False
            'MemoEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            'MemoEdit.WordWrap = True
            '' MemoEdit.NullText = " "
            'GridControlDuyet.RepositoryItems.Add(MemoEdit)
            'GridViewDuyet.Columns("YEU_CAU").ColumnEdit = MemoEdit


            'MemoEdit = New RepositoryItemMemoEdit()
            'MemoEdit.ReadOnly = False
            'MemoEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            'MemoEdit.WordWrap = True
            '' MemoEdit.NullText = " "
            'GridControlDuyet.RepositoryItems.Add(MemoEdit)
            'GridViewDuyet.Columns("MO_TA_TINH_TRANG").ColumnEdit = MemoEdit



        Catch ex As Exception

        End Try
        If iLoad = True Then Exit Sub
        iLoad = True
        LoadPhieuBaoTri()
        Showtext()
        iLoad = False
        isBoQuaOrCho = 0

        GridViewDuyet.Columns("MS_YEU_CAU").OptionsColumn.FixedWidth = True
        GridViewDuyet.Columns("MS_MAY").OptionsColumn.FixedWidth = True
        GridViewDuyet.Columns("SO_YEU_CAU").OptionsColumn.FixedWidth = True
        GridViewDuyet.Columns("NGAY_DBT").OptionsColumn.FixedWidth = True
        GridViewDuyet.Columns("NGAY_BD_KH").OptionsColumn.FixedWidth = True
        GridViewDuyet.Columns("NGAY_KT_KH").OptionsColumn.FixedWidth = True

        GridViewDuyet.Columns("TAI_LIEU").Width = 55
        GridViewDuyet.Columns("MS_MAY").Width = 100
        GridViewDuyet.Columns("TEN_MAY").Width = 130
        GridViewDuyet.Columns("MO_TA_TINH_TRANG").Width = 320
        GridViewDuyet.Columns("YEU_CAU").Width = 320
        GridViewDuyet.Columns("TEN_LOAI_YEU_CAU_BT").Width = 120
        GridViewDuyet.Columns("TEN_NGUYEN_NHAN").Width = 120
        GridViewDuyet.Columns("TEN_UU_TIEN").Width = 98

        If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = False Then
            btnXemTL.Visible = True
        Else
            btnXemTL.Visible = False
        End If
    End Sub
    Private Sub ShowPanel()
        If Commons.Modules.SQLString = "0Load" Then
            Return
        End If
        Dim frm As New MVControl.frmShowThongTinYCNSD()
        frm.MS_MAY = GridViewDuyet.GetFocusedRowCellValue("MS_MAY")
        frm.STT = GridViewDuyet.GetFocusedRowCellValue("STT")
        frm.MS_PBT = "-1"
        frm.STT_VAN_DE = GridViewDuyet.GetFocusedRowCellValue("STT_VAN_DE")
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog()
    End Sub


    Private Sub LoadPhieuBaoTri()
        sql = " EXEC sp_getMS_PHIEU_BAO_TRI '" & txtSTT.Text & "','" & txtMSM.Text & "','" & txtSTVD.Text & "'"

        cmbMSPBT.Properties.DataSource = Nothing
        cmbMSPBT.Properties.ValueMember = ""
        cmbMSPBT.Properties.DisplayMember = ""

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbMSPBT, sql, "MS_PHIEU_BAO_TRI", "MS_PHIEU_BAO_TRI", lblMSPBT.Text)
        cmbMSPBT.Properties.ShowHeader = False
        cmbMSPBT.Properties.ShowFooter = False
        cmbMSPBT.Properties.DropDownRows = CType(cmbMSPBT.Properties.DataSource, DataTable).Rows.Count
        If Commons.Modules.SQLString <> "" Then
            cmbMSPBT.EditValue = Commons.Modules.SQLString
        End If

        sql = " EXEC sp_getKHTT '" & txtSTT.Text & "','" & txtMSM.Text & "','" & txtSTVD.Text & "'"
        cboKHTT.Properties.DataSource = Nothing
        cboKHTT.Properties.ValueMember = ""
        cboKHTT.Properties.DisplayMember = ""

        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKHTT, sql, "MA", "TEN", "")
        cboKHTT.Properties.ShowHeader = False
        cboKHTT.Properties.ShowFooter = False
        cboKHTT.Properties.DropDownRows = CType(cboKHTT.Properties.DataSource, DataTable).Rows.Count

    End Sub

    Private Sub txtMSM_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Commons.Modules.SQLString = ""

        If iLoad = True Then Exit Sub
        iLoad = True
        LoadPhieuBaoTri()
        Showtext()
        iLoad = False

    End Sub
    Private Sub AnHienCot()
        Try
            GridViewDuyet.Columns("CHON").Visible = False
            GridViewDuyet.Columns("STT").Visible = False
            GridViewDuyet.Columns("STT_VAN_DE").Visible = False
            GridViewDuyet.Columns("MS_UU_TIEN").Visible = False
            GridViewDuyet.Columns("MS_CACH_TH").Visible = False
            GridViewDuyet.Columns("MS_CONG_NHAN").Visible = False
            GridViewDuyet.Columns("TINH_TRANG_PBT").Visible = False
            GridViewDuyet.Columns("HANG_MUC_ID_KE_HOACH").Visible = False
            'GridViewDuyet.Columns("MS_YEU_CAU").Visible = False
            GridViewDuyet.Columns("SO_YEU_CAU").Visible = False
            GridViewDuyet.Columns("Ten_N_XUONG").Visible = False
            GridViewDuyet.Columns("MS_CACH_TH").Visible = False
            GridViewDuyet.Columns("TEN_TIENG_VIET").Visible = False
            GridViewDuyet.Columns("TEN_HANG_MUC").Visible = False
            GridViewDuyet.Columns("MS_PBT").Visible = False
            GridViewDuyet.Columns("EMAIL_DBT").Visible = False
            GridViewDuyet.Columns("MS_CONG_NHAN").Visible = False
            GridViewDuyet.Columns("NGUOI_PHU_TRACH").Visible = False
            GridViewDuyet.Columns("TEN_TINH_TRANG").Visible = False
            GridViewDuyet.Columns("USERNAME_DSX").Visible = False
            GridViewDuyet.Columns("THOI_GIAN_DSX").Visible = False
            GridViewDuyet.Columns("Y_KIEN_DSX").Visible = False
            GridViewDuyet.Columns("USERNAME_DBT").Visible = False
            GridViewDuyet.Columns("NGAY_DBT").Visible = False
            GridViewDuyet.Columns("Y_KIEN_DBT").Visible = False
            GridViewDuyet.Columns("NGAY_GIO_YEU_CAU").Visible = False
            GridViewDuyet.Columns("NGAY_BD_KH").Visible = False
            GridViewDuyet.Columns("NGAY_KT_KH").Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AnHienNutDuyet()
        Dim vtb As New DataTable
        Try
            sql = "select distinct USERNAME  from USER_CHUC_NANG  where USERNAME=N'" & Commons.Modules.UserName & "' AND STT=14"
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql))
            If vtb.Rows.Count > 0 Then
                CoAnHienDuyet = True


                If CoAnHienDuyet = True Then
                    cmdDuyet.Visible = True
                    btnBoQua.Visible = True
                    btnChoTH.Visible = True
                Else
                    cmdDuyet.Visible = False
                    btnBoQua.Visible = False
                    btnChoTH.Visible = False
                End If
            Else
                CoAnHienDuyet = False
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewDuyet_CustomDrawCell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridViewDuyet.CustomDrawCell
        If bHienthi <> 0 Then Exit Sub
        'XtraMessageBox.Show(e.Column.FieldName.ToUpper.ToString())

        If e.Column.FieldName.ToUpper.ToString() <> "TEN_UU_TIEN" Then Exit Sub

        Dim MS_UU_TIEN As String = ""
        'gridView.GetRowCellValue(e.RowHandle, colAge)
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

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Close()
    End Sub

    Private Sub cmdDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDuyet.Click
        Try
            If GroupChon.SelectedIndex <> 0 Then
                If txtUser.Text.Trim.ToUpper <> Commons.Modules.UserName.ToUpper Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "KhongcungUser", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
            End If

            VisibleControl(False)
            If GroupChon.SelectedIndex = 0 Then
                txtUser.Text = Commons.Modules.UserName
                txtYKien.Text = ""
                txtMailto.Text = ""
            End If
            GridControlDuyet.Enabled = False
            txtThoiGian.Text = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Catch ex As Exception

        End Try
        Dim dtTMP As New DataTable
        dtTMP = CType(cmbCachTH.Properties.DataSource, DataTable)
        dtTMP.DefaultView.RowFilter = " MS_CACH_TH = '01' OR MS_CACH_TH = '04' "


        If GroupChon.SelectedIndex = 3 Or GroupChon.SelectedIndex = 4 Then
            cmbCachTH.Enabled = False
            cboKHTT.Enabled = False
        End If
        '01	Lập kế hoạch bảo trì
        '03	Bỏ qua, không xử lý 
        '04	Thực hiện trên PBT
        '06	Chờ thực hiện

        cmdTim.Enabled = False
        btnTimNV.Enabled = True
        btnKHTT.Enabled = False
        LoadPhieuBaoTri()
    End Sub

    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        Dim sBT As String = "DUYET_YCSD_TMP" & Commons.Modules.UserName
        Try
            Dim USERNAME_DBT As String = txtUser.Text
            Dim NGAY_DBT As String = txtThoiGian.Text
            Dim Y_KIEN_DBT As String = txtYKien.Text.Trim
            Dim EMAIL_DBT As String = txtMailto.Text.Trim
            Dim MS_CONG_NHAN As String
            Try
                MS_CONG_NHAN = cmbNVPT.EditValue.ToString()
            Catch ex As Exception
                MS_CONG_NHAN = ""
            End Try

            Dim MS_CACH_TH As String
            If isBoQuaOrCho <> 0 Then
                MS_CACH_TH = "0" & isBoQuaOrCho
            Else
                MS_CACH_TH = cmbCachTH.EditValue.ToString
            End If


            Dim MS_PBT As String = ""
            Dim MS_HM As String = ""
            Dim vtb As New DataTable
            vtb = cmbMSPBT.Properties.DataSource


            If MS_CACH_TH = "" Then
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "Batbuocnhapcachthuchien", Commons.Modules.TypeLanguage))

                Exit Sub
            End If
            'bo qua
            If MS_CACH_TH <> "03" Then

                If vtb.Rows.Count = 0 Then
                    MS_PBT = ""
                Else
                    MS_PBT = cmbMSPBT.EditValue.ToString
                End If
                If CType(cboKHTT.Properties.DataSource, DataTable).Rows.Count = 0 Then
                    MS_HM = ""
                Else
                    MS_HM = cboKHTT.EditValue.ToString
                End If


            End If
            If MS_CACH_TH = "03" Then
                If txtYKien.Text.Trim = "" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "msgNhapYKienBoQua", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
            End If

            'chap nhap lam
            If MS_CACH_TH = "04" Then
                If MS_PBT = "" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "Batbuocchonphieubaotri", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
            End If
            If MS_CACH_TH = "01" Then
                If MS_HM = "" Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "msgBatbuocchonKHTT", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
            End If
            If txtMailto.Text.Trim <> "" Then
                If Commons.Modules.ObjSystems.MCheckEmail(txtMailto.Text) = False Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "MailSai", Commons.Modules.TypeLanguage))
                    Exit Sub
                End If
            End If

            Dim dt As New DataTable
            dt = CType(GridControlDuyet.DataSource, DataTable).Copy
            If isBoQuaOrCho <> 0 Then
                dt.DefaultView.RowFilter = "CHON = True"
            Else
                dt.DefaultView.RowFilter = "STT_VAN_DE = " & GridViewDuyet.GetFocusedRowCellValue("STT_VAN_DE").ToString()
            End If
            dt = dt.DefaultView.ToTable()
            Commons.Modules.ObjSystems.XoaTable(sBT)
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dt, "")

            ChonOrKhongChon(0)
            CType(cmbCachTH.Properties.DataSource, DataTable).DefaultView.RowFilter = ""







            Try
                If MS_CONG_NHAN = "" Then
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS SET TG_XU_LY  = GETDATE() " &
                        " FROM GIAM_SAT_TINH_TRANG_TS GS INNER JOIN " & sBT & " Temp ON GS.STT_VAN_DE=Temp.STT_VAN_DE " &
                        " WHERE ISNULL(GS.MS_PBT,'') = ''  "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET TG_XU_LY  = GETDATE()" &
                        " FROM GIAM_SAT_TINH_TRANG_TS_DT GS INNER JOIN " & sBT & " Temp ON GS.STT_VAN_DE=Temp.STT_VAN_DE " &
                        " WHERE ISNULL(GS.MS_PBT,'') = ''  "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)


                    sql = "UPDATE YEU_CAU_NSD_CHI_TIET SET USERNAME_DBT = N'" & USERNAME_DBT & "', HANG_MUC_ID_KE_HOACH = " & IIf(String.IsNullOrEmpty(MS_HM), "NULL", MS_HM) & ", " &
                        " NGAY_DBT = '" & Format(CDate(NGAY_DBT), "MM/dd/yyyy HH:mm:ss") & "', Y_KIEN_DBT = N'" & Y_KIEN_DBT & "'," &
                        " EMAIL_DBT = N'" & EMAIL_DBT & "' , MS_CACH_TH = '" & MS_CACH_TH & "', MS_PBT = N'" & MS_PBT & "'" &
                        " FROM YEU_CAU_NSD_CHI_TIET GS INNER JOIN " & sBT & " Temp ON GS.STT_VAN_DE=Temp.STT_VAN_DE AND GS.STT=Temp.STT AND GS.MS_MAY=Temp.MS_MAY"

                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                Else
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_CONG_NHAN = N'" & MS_CONG_NHAN & "' , TG_XU_LY  = GETDATE()" &
                    " FROM GIAM_SAT_TINH_TRANG_TS GS INNER JOIN " & sBT & " Temp ON GS.STT_VAN_DE=Temp.STT_VAN_DE " &
                    " WHERE ISNULL(GS.MS_PBT,'') = ''  "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)


                    sql = "UPDATE YEU_CAU_NSD_CHI_TIET SET USERNAME_DBT = N'" & USERNAME_DBT & "', HANG_MUC_ID_KE_HOACH = " & IIf(String.IsNullOrEmpty(MS_HM), "NULL", MS_HM) & ", " &
                        " NGAY_DBT='" & Format(CDate(NGAY_DBT), "MM/dd/yyyy HH:mm:ss") & "',Y_KIEN_DBT = N'" & Y_KIEN_DBT & "'," &
                        " EMAIL_DBT = N'" & EMAIL_DBT & "', MS_CONG_NHAN= '" & MS_CONG_NHAN & "' ,MS_CACH_TH='" & MS_CACH_TH & "', MS_PBT = N'" & MS_PBT & "'" &
                        " FROM YEU_CAU_NSD_CHI_TIET GS INNER JOIN " & sBT & " Temp ON GS.STT_VAN_DE=Temp.STT_VAN_DE AND GS.STT=Temp.STT AND GS.MS_MAY=Temp.MS_MAY"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                End If
                '01 THUC HIEN TREN KE HOACH  -- UPDATE MA HANG MUC
                If MS_CACH_TH = "01" And String.IsNullOrEmpty(MS_HM) = False Then
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_CACH_TH = '01' , HANG_MUC_ID_KE_HOACH = " & MS_HM &
                    " FROM GIAM_SAT_TINH_TRANG_TS GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                    " WHERE ISNULL(GS.MS_PBT,'') = ''  AND ISNULL(GS.MS_CACH_TH,'') <> '03'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_CACH_TH = '01' , HANG_MUC_ID_KE_HOACH = " & MS_HM &
                        " FROM GIAM_SAT_TINH_TRANG_TS_DT GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                        " WHERE ISNULL(GS.MS_PBT,'') = ''  AND ISNULL(GS.MS_CACH_TH,'') <> '03'"
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                End If

                '06 CHO THUC HIEN -- UPDATE CACH THUC HIEN THUI
                If MS_CACH_TH = "06" Then
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_CACH_TH = '06'" &
                        " FROM GIAM_SAT_TINH_TRANG_TS GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                        " WHERE ISNULL(GS.MS_PBT,'') = ''  AND ISNULL(GS.HANG_MUC_ID_KE_HOACH,0) = 0 "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_CACH_TH = '06'" &
                        " FROM GIAM_SAT_TINH_TRANG_TS_DT GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                        " WHERE ISNULL(GS.MS_PBT,'') = ''  AND ISNULL(GS.HANG_MUC_ID_KE_HOACH,0) = 0 "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)

                End If

                '03 BO WA -- UPDATE CACH THUC HIEN THUI
                If MS_CACH_TH = "03" Then
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_CACH_TH = '03' , HANG_MUC_ID_KE_HOACH = NULL" &
                    " FROM GIAM_SAT_TINH_TRANG_TS GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                    " WHERE ISNULL(GS.MS_PBT,'') = ''  AND ISNULL(GS.HANG_MUC_ID_KE_HOACH,0) = 0 "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_CACH_TH = '03' , HANG_MUC_ID_KE_HOACH = NULL" &
                    " FROM GIAM_SAT_TINH_TRANG_TS_DT GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                    " WHERE ISNULL(GS.MS_PBT,'') = ''  AND ISNULL(GS.HANG_MUC_ID_KE_HOACH,0) = 0 "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                End If
                '04 lam tren pbt

                If MS_CACH_TH = "04" Then
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_CACH_TH = '04' , MS_PBT = '" & MS_PBT & "'" &
                        " FROM GIAM_SAT_TINH_TRANG_TS GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                        " WHERE ISNULL(GS.MS_PBT,'') = ''  "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                    sql = " UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_CACH_TH = '04' , MS_PBT = '" & MS_PBT & "'" &
                        " FROM GIAM_SAT_TINH_TRANG_TS_DT GS INNER JOIN " & sBT & " Temp ON Temp.STT=GS.STT AND Temp.MS_MAY=GS.MS_MAY AND Temp.STT_VAN_DE=GS.STT_VAN_DE" &
                        " WHERE ISNULL(GS.MS_PBT,'') = ''  "
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql)
                End If
                VisibleControl(True)
                MoKhoaLuoi(False)
                GridControlDuyet.Enabled = True
                Dim luuSTT As String = txtSTT.Text
                Dim luuMSM As String = txtMSM.Text
                Dim luuSTVD As String = txtSTVD.Text
                GoiMail()
                Loadgrid()
                LocDuLieu()
                Dim dv As DataView
                Dim i As Integer
                Dim j As Integer
                Dim LuuVT As Integer = -1
                dv = DSYeuCau.DefaultView
                For i = 0 To dv.Count - 1
                    j = DSYeuCau.Rows.IndexOf(dv(i).Row)
                    If j >= 0 Then
                        If DSYeuCau.Rows(j).Item("STT").ToString = luuSTT And DSYeuCau.Rows(j).Item("MS_MAY").ToString = luuMSM And DSYeuCau.Rows(j).Item("STT_VAN_DE").ToString = luuSTVD Then
                            LuuVT = i
                            Exit For
                        End If
                    End If
                Next

                GridControlDuyet.Enabled = True
                If LuuVT > 0 Then
                    GridViewDuyet.FocusedRowHandle = LuuVT
                End If

                CType(cmbCachTH.Properties.DataSource, DataTable).DefaultView.RowFilter = ""
                cmdTim.Enabled = False
                btnTimNV.Enabled = False
                btnKHTT.Enabled = False
                LoadPhieuBaoTri()
            Catch ex As Exception
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauBT", "Loighidulieu", Commons.Modules.TypeLanguage))


                Exit Sub
            End Try

        Catch ex As Exception

        End Try

        Commons.Modules.ObjSystems.XoaTable(sBT)
        ControlButton()
    End Sub

    Private Sub GoiMail()
        If (Commons.Modules.sMailFrom = "" Or Commons.Modules.sMailFromPass = "" Or Commons.Modules.sMailFromSmtp = "" Or Commons.Modules.sMailFromPort = "") Then
            'XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "KhongCoThongTinMailGoi", Commons.Modules.TypeLanguage), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim STT As Integer
        Dim sMsMay As String

        STT = Convert.ToInt32(GridViewDuyet.GetFocusedRowCellValue("STT").ToString())
        sMsMay = GridViewDuyet.GetFocusedRowCellValue("MS_MAY").ToString()
        Dim sSql, sNXuong, sMail, sMailUser As String
        Try
            sNXuong = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, " SELECT TOP 1 MS_N_XUONG FROM YEU_CAU_NSD WHERE STT = " & STT.ToString)
        Catch ex As Exception
            sNXuong = ""
        End Try
        Try
            sMail = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                    " SELECT USER_MAIL FROM YEU_CAU_NSD A INNER JOIN USERS B ON A.USER_LAP = B.USERNAME WHERE STT = " & STT.ToString)

        Catch ex As Exception
            sMail = ""
        End Try

        sSql = " DECLARE @listStr1 VARCHAR(1000) " &
                    " SELECT @listStr1 = COALESCE(ISNULL( RTRIM(LTRIM(@listStr1)),'') ,'') +   " &
                    " + CASE LEN(ISNULL(RTRIM(LTRIM(@listStr1)),'')) WHEN 0 THEN '' ELSE ';' END +  " &
                    " ISNULL(USER_MAIL,'') FROM ( SELECT  DISTINCT  dbo.USERS.USER_MAIL FROM dbo.YEU_CAU_NSD_CHI_TIET AS B INNER JOIN " &
                    " dbo.USERS ON B.USERNAME_DSX = dbo.USERS.USERNAME " &
                    " WHERE STT = " & STT.ToString & " AND MS_MAY = '" + GridViewDuyet.GetFocusedRowCellValue("MS_MAY").ToString() + "' ) A   SELECT  ISNULL(@listStr1,'') AS EMAIL "
        sMailUser = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)


        If sMail <> "" Then
            If sMailUser <> "" Then
                sMail = sMail & ";" & sMailUser
            End If
        Else
            If sMailUser <> "" Then
                sMail = sMailUser
            End If
        End If

        Dim frm As ReportMain.frmPBTBanHanh = New ReportMain.frmPBTBanHanh()
        frm.iLoai = 4

        sSql = ""
        sSql = Commons.Modules.ObjSystems.MLoadMailNX(sNXuong, sMail, 2)
        If txtMailto.Text.Trim <> "" Then
            sSql = sSql + ";" + txtMailto.Text
        End If

        frm.sNXuong = sSql
        If sSql = "" Then
            Exit Sub
        End If
        frm.dtTmp = New DataTable()
        frm.dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MMailGetXuLyYeuCau", STT.ToString, sMsMay, Commons.Modules.TypeLanguage))
        If frm.dtTmp.Rows.Count = 0 Then
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "KhongCoDuLieu", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        frm.ShowDialog()
    End Sub

    Private Sub LocDuLieu()
        Try
            If GridViewDuyet.ActiveFilterString <> "" Then
                If txtMSMay.Text.Trim <> "" Then
                    DSYeuCau.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and (MS_MAY LIKE '%" & txtMSMay.Text.Trim & "%' or TEN_MAY like '%" & txtMSMay.Text.Trim & "%' or MS_YEU_CAU LIKE '%" & txtMSMay.Text.Trim & "%')"
                Else
                    DSYeuCau.DefaultView.RowFilter = GridViewDuyet.ActiveFilterString & " and 1=1 "
                End If
            Else
                If txtMSMay.Text.Trim <> "" Then
                    DSYeuCau.DefaultView.RowFilter = "  (TEN_MAY like '%" & txtMSMay.Text.Trim & "%' or  MS_MAY LIKE '%" & txtMSMay.Text.Trim & "%' or MS_YEU_CAU LIKE '%" & txtMSMay.Text.Trim & "%')"
                Else
                    DSYeuCau.DefaultView.RowFilter = " 1=1"
                End If
            End If
        Catch ex As Exception
            DSYeuCau.DefaultView.RowFilter = " 1=1"
        End Try
    End Sub
    Private Sub cmdKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKhong.Click
        VisibleControl(True)
        MoKhoaLuoi(False)
        GridControlDuyet.Enabled = True
        Showtext()
        CType(cmbCachTH.Properties.DataSource, DataTable).DefaultView.RowFilter = ""
        cmdTim.Enabled = False
        btnTimNV.Enabled = False
        btnKHTT.Enabled = False
        isBoQuaOrCho = 0
        ChonOrKhongChon(0)
        ControlButton()
    End Sub

    Private Sub GroupChon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupChon.SelectedIndexChanged
        Loadgrid()
        If GroupChon.SelectedIndex = 4 Then
            cmdDuyet.Enabled = False
            btnBoQua.Enabled = False
            btnChoTH.Enabled = False
        Else
            If GroupChon.SelectedIndex = 0 Then
                btnBoQua.Enabled = True
                btnChoTH.Enabled = True
            Else
                If GroupChon.SelectedIndex = 1 Then
                    btnBoQua.Enabled = False
                    btnChoTH.Enabled = True
                Else
                    If GroupChon.SelectedIndex = 2 Then
                        btnBoQua.Enabled = False
                        btnChoTH.Enabled = False
                    Else
                        If GroupChon.SelectedIndex = 3 Then
                            btnBoQua.Enabled = False
                            btnChoTH.Enabled = False
                        Else
                            If GroupChon.SelectedIndex = 5 Then
                                btnBoQua.Enabled = True
                                btnChoTH.Enabled = False
                            End If
                        End If
                    End If
                End If
            End If
            cmdDuyet.Enabled = True
        End If
        ControlButton()
        DockPanel1.Close()
    End Sub
    Private Sub Showtext()

        If Not (btnALL.Visible) Then
            Dim ss As String = ""
            Try
                Dim sql As String = "STT ='" + txtSTT.Text + "' and MS_MAY='" & txtMSM.Text & "' and STT_VAN_DE='" & txtSTVD.Text & "'"
                Dim _dtvTmp As New DataView(DSYeuCau, "STT ='" + txtSTT.Text + "' and MS_MAY='" & txtMSM.Text & "' and STT_VAN_DE='" & txtSTVD.Text & "'", "", DataViewRowState.CurrentRows)
                Dim vtb As New DataTable
                vtb = _dtvTmp.ToTable
                For Each vr As DataRow In vtb.Rows
                    txtYKien.Text = vr("Y_KIEN_DBT").ToString
                    txtMailto.Text = vr("EMAIL_DBT").ToString
                    Try
                        cmbCachTH.EditValue = vr("MS_CACH_TH").ToString
                    Catch ex As Exception

                    End Try

                    cmbNVPT.EditValue = vr("MS_CONG_NHAN").ToString
                    txtUser.Text = vr("USERNAME_DBT").ToString
                    txtThoiGian.Text = vr("NGAY_DBT").ToString
                    cmbMSPBT.EditValue = vr("MS_PBT").ToString
                    cboKHTT.EditValue = vr("HANG_MUC_ID_KE_HOACH").ToString
                    If cmbMSPBT.Text = "" Then
                        cmbMSPBT.EditValue = ""
                    End If
                    If cboKHTT.Text = "" Then
                        cboKHTT.EditValue = ""
                    End If
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub EnableControl(ByVal Value As Boolean)
        Try
            txtYKien.Enabled = Value
            txtMailto.Enabled = Value
            cmbCachTH.Enabled = Value
            cmbNVPT.Enabled = Value
            btnTimNV.Enabled = Value
            cmbMSPBT.Enabled = Value

            cboKHTT.Enabled = Value
            btnKHTT.Enabled = Value
            cmdTim.Enabled = Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMSMay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMSMay.EditValueChanged
        LocDuLieu()
    End Sub

    Private Sub cmbMSPBT_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMSPBT.EditValueChanged
        If cmbMSPBT.Text = "...New" And cmdGhi.Visible = True Then
            Commons.Modules.SQLString = "frmYeuCauBT"
            Dim frm As New Report1.frmLapphieubaotri_CS
            'kiểm tra nếu có tồn tại ngày giờ sự cố thì gán vào
            If Not String.IsNullOrEmpty(GridViewDuyet.GetFocusedRowCellValue("NGAY_XAY_RA").ToString()) Then
                frm.dNgayHong = Convert.ToDateTime(GridViewDuyet.GetFocusedRowCellValue("NGAY_XAY_RA").ToString())
            End If
            If Not String.IsNullOrEmpty(GridViewDuyet.GetFocusedRowCellValue("GIO_XAY_RA").ToString()) Then
                frm.dGioHong = Convert.ToDateTime(GridViewDuyet.GetFocusedRowCellValue("GIO_XAY_RA").ToString())
            End If
            frm.MS_MAY = txtMSM.Text
            frm.MS_NGUYEN_NHAN = GridViewDuyet.GetRowCellDisplayText(GridViewDuyet.FocusedRowHandle, "TEN_NGUYEN_NHAN")
            frm.ShowDialog()
            If Commons.Modules.SQLString <> "" Then
                LoadPhieuBaoTri()
                cmbNVPT.EditValue = frm.sNhanVienThucHien
            Else
                cmbMSPBT.EditValue = ""
            End If
            Commons.Modules.SQLString = ""

        End If
    End Sub


    Private Sub cmdTim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTim.Click
        Try
            Dim frm As New frmDanhSachPhieuBT
            Commons.Modules.SQLString = ""
            frm.STT = txtSTT.Text
            frm.STT_VAN_DE = txtSTVD.Text
            frm.MS_MAY = txtMSM.Text
            frm.iLoaiForm = 1
            frm.ShowDialog()
            If Commons.Modules.SQLString <> "" Then
                cmbMSPBT.EditValue = Commons.Modules.SQLString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewDuyet_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDuyet.FocusedRowChanged
        If iLoad = True Then Exit Sub
        iLoad = True
        LoadPhieuBaoTri()
        Showtext()
        iLoad = False
        Try
            Dim dt As New DataTable()
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_BO_PHAN", GridViewDuyet.GetFocusedRow("STT").ToString(),
                                             GridViewDuyet.GetFocusedRow("MS_MAY").ToString(),
                                            GridViewDuyet.GetFocusedRow("STT_VAN_DE").ToString()))

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBoPhan, grvBoPhan, dt, False, False, True, False)

            grvBoPhan.Columns("STT").Visible = False
            grvBoPhan.Columns("MS_MAY").Visible = False
            grvBoPhan.Columns("STT_VAN_DE").Visible = False
            grvBoPhan.Columns("DEL").Visible = False
            grvBoPhan.Columns("STT_BO_PHAN").Visible = False
            grvBoPhan.Columns("MS_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_BO_PHAN", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("TEN_BO_PHAN").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_BO_PHAN", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("MS_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_PT", Commons.Modules.TypeLanguage)
            grvBoPhan.Columns("TEN_PT").Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_PT", Commons.Modules.TypeLanguage)

            grvBoPhan.Columns("MS_BO_PHAN").Width = 150
            grvBoPhan.Columns("TEN_BO_PHAN").Width = 350
            grvBoPhan.Columns("MS_PT").Width = 200
        Catch
        End Try



        If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = False Then
            btnXemTL.Visible = True
        Else
            btnXemTL.Visible = False
        End If
    End Sub


    Private Sub cmbCachTH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCachTH.EditValueChanged

        cmbMSPBT.Properties.ReadOnly = True
        cmdTim.Enabled = False
        btnNew1.Enabled = False
        btnNew2.Enabled = False

        cboKHTT.Properties.ReadOnly = True
        btnKHTT.Enabled = False

        If (Not cmdGhi.Visible) Then Exit Sub
        cboKHTT.EditValue = ""
        cmbMSPBT.EditValue = ""
        If cmbCachTH.EditValue = 1 Then
            cboKHTT.Properties.ReadOnly = False
            btnKHTT.Enabled = True
            btnNew2.Enabled = True
        Else
            If cmbCachTH.EditValue = 6 Then
                cmbMSPBT.Properties.ReadOnly = True
                cmdTim.Enabled = False
                btnNew1.Enabled = False
            Else
                If cmbCachTH.EditValue = 3 Then
                    cmbMSPBT.Properties.ReadOnly = True
                    cmdTim.Enabled = False
                    btnNew1.Enabled = False
                Else
                    cmbMSPBT.Properties.ReadOnly = False
                    cmdTim.Enabled = True
                    btnNew1.Enabled = True
                End If

            End If
        End If
    End Sub

    Private Sub btnTimNV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimNV.Click
        Dim frm As New ReportMain.frmTimNhanVien()
        frm.VaiTro = 2
        If frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim sMSNV As String
        sMSNV = frm.MsNVien
        If sMSNV = "" Then Exit Sub
        cmbNVPT.EditValue = sMSNV
    End Sub


    Private Sub btnKHTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKHTT.Click
        Try
            Dim frm As New frmDanhSachPhieuBT
            Commons.Modules.SQLString = ""
            frm.STT = txtSTT.Text
            frm.STT_VAN_DE = txtSTVD.Text
            frm.MS_MAY = txtMSM.Text
            frm.iLoaiForm = 2
            frm.ShowDialog()
            If Commons.Modules.SQLString <> "" Then
                cboKHTT.EditValue = Commons.Modules.SQLString
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cboKHTT_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKHTT.EditValueChanged
        If cboKHTT.Text = "...New" And cmdGhi.Visible = True Then
            Dim frm As New ReportHuda.frmTaoKHTT
            frm.sMsMay = txtMSM.Text
            If cmbNVPT.Text = "" Then frm.sNVien = "-1" Else frm.sNVien = cmbNVPT.EditValue

            If frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                cboKHTT.ItemIndex = -1
                Exit Sub
            End If

            Dim iHMuc As Integer
            iHMuc = frm.iHangMuc
            cmbNVPT.EditValue = frm.sNhanVienThucHien
            Try
                If iHMuc = -1 Then Exit Sub
                sql = " EXEC sp_getKHTT '" & txtSTT.Text & "','" & txtMSM.Text & "','" & txtSTVD.Text & "'"
                cboKHTT.Properties.DataSource = Nothing
                cboKHTT.Properties.ValueMember = ""
                cboKHTT.Properties.DisplayMember = ""

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKHTT, sql, "MA", "TEN", lblMSPBT.Text)
                cboKHTT.Properties.ShowHeader = False
                cboKHTT.Properties.ShowFooter = False
                cboKHTT.Properties.DropDownRows = 7

                cboKHTT.EditValue = iHMuc.ToString()
            Catch ex As Exception

            End Try
        End If

    End Sub




    Private Sub btnXemTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemTL.Click
        XemTL()
    End Sub
    Private Sub XemTL()
        If cmdDuyet.Visible = False Then Exit Sub
        If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = True Then Exit Sub
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
                'Dim frm As New MReportVB.frmYCNSDXemTL
                'frm.dtChung = dtTmp
                'frm.ShowDialog()
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

    'Private Sub GridViewDuyet_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViewDuyet.DoubleClick
    '    Dim view As GridView = CType(sender, GridView)
    '    Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
    '    DoRowDoubleClick(view, pt)
    'End Sub
    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            Dim info1 As GridViewInfo = TryCast(GridViewDuyet.GetViewInfo(), GridViewInfo)
            Dim cell As GridCellInfo = info1.GetGridCellInfo(info.RowHandle, 0)
            Dim p As New Point(24, Control.MousePosition.Y + 13)

            DockPanel1.FloatLocation = p
            ShowPanel()
        End If



    End Sub

    Dim grvTmp As GridView
    Dim ptTmp As Point
    ''Private inplaceEditor As BaseEdit


    ''Private Sub GridViewDuyet_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViewDuyet.ShownEditor

    ''    inplaceEditor = (CType(sender, GridView)).ActiveEditor
    ''    AddHandler inplaceEditor.DoubleClick, AddressOf inplaceEditor_DoubleClick
    ''End Sub

    ''Private Sub inplaceEditor_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
    ''    Try

    ''        Dim editor As BaseEdit = CType(sender, BaseEdit)
    ''        Dim grid As GridControl = CType(editor.Parent, GridControl)
    ''        Dim pt As Point = grid.PointToClient(Control.MousePosition)
    ''        Dim view As GridView = CType(grid.FocusedView, GridView)
    ''        DoRowDoubleClick(view, pt)
    ''    Catch ex As Exception
    ''        XtraMessageBox.Show(ex.Message)
    ''    End Try

    ''End Sub

    ''Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
    ''    Dim info As GridHitInfo = view.CalcHitInfo(pt)
    ''    Try

    ''        If info.InRow OrElse info.InRowCell Then
    ''            Dim colCaption As String
    ''            If info.Column Is Nothing Then
    ''                colCaption = "N/A"
    ''            Else
    ''                colCaption = info.Column.GetCaption()
    ''            End If
    ''            Dim sDDan As String
    ''            sDDan = GridViewDuyet.GetFocusedRowCellValue("DUONG_DAN").ToString()
    ''            Me.Cursor = Cursors.WaitCursor
    ''            System.Diagnostics.Process.Start(sDDan)
    ''            Me.Cursor = Cursors.Default
    ''        End If
    ''    Catch ex As Exception
    ''        XtraMessageBox.Show(ex.Message)
    ''    End Try

    ''End Sub


    Private mouseDownTime As DateTime = DateTime.MinValue
    Private mouseDownCell As New GridCell(GridControl.InvalidRowHandle, Nothing)
    Private DoubleClickInterval As New TimeSpan(0, 0, 0, 0, 100)

    Private Sub GridViewDuyet_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GridViewDuyet.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Dim hi As GridHitInfo = GridViewDuyet.CalcHitInfo(e.Location)
            If hi.InRowCell Then
                If hi.RowHandle = mouseDownCell.RowHandle AndAlso mouseDownTime - DateTime.Now < DoubleClickInterval Then
                    XemTL()
                End If
            End If
            mouseDownCell = New GridCell(hi.RowHandle, hi.Column)
            mouseDownTime = DateTime.Now
        Else
            Dim gridView As GridView = DirectCast(sender, GridView)
            Dim hitInfo As GridHitInfo = gridView.CalcHitInfo(New Point(e.X, e.Y))
            If (((e.Button & MouseButtons.Right) <> 0) And (hitInfo.InRow) And (Not gridView.IsGroupRow(hitInfo.RowHandle))) Then
                Dim Menu As ViewMenu = New ViewMenu(gridView)
                Dim MenuItem As DXMenuItem = New DXMenuItem(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "menuViewTiepNhanThongTin",
                    Commons.Modules.TypeLanguage),
                  New EventHandler(AddressOf MenuViewTiepNhanThongTin_Click))
                MenuItem.Tag = gridView
                Menu.Items.Add(MenuItem)
                Menu.Show(hitInfo.HitPoint)
                grvTmp = gridView
                ptTmp = New Point(e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub MenuViewTiepNhanThongTin_Click(sender As Object, e As EventArgs)
        DoRowDoubleClick(grvTmp, ptTmp)

    End Sub









    Private Sub btnBoQua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoQua.Click
        VisibleControl(False)
        btnALL.Visible = True
        btnNotAll.Visible = True
        'cmbCachTH.EditValue = Nothing
        cmbCachTH.Enabled = False
        isBoQuaOrCho = 3
        CachThucHien_Action(3)
        MoKhoaLuoi(True)
    End Sub

    Private Sub CachThucHien_Action(ByVal Value As Integer)
        cmbMSPBT.Properties.ReadOnly = True
        cmdTim.Enabled = False

        cboKHTT.Properties.ReadOnly = True
        btnKHTT.Enabled = False

        txtUser.Text = Commons.Modules.UserName
        txtYKien.Text = ""
        txtMailto.Text = ""
        txtThoiGian.Text = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")

        If (Not cmdGhi.Visible) Then Exit Sub
        cboKHTT.EditValue = ""
        cmbMSPBT.EditValue = ""
        If Value = 1 Then
            cboKHTT.Properties.ReadOnly = False
            btnKHTT.Enabled = True
        Else
            If Value = 6 Then
                cmbMSPBT.Properties.ReadOnly = True
                cmdTim.Enabled = False
            Else
                If Value = 3 Then
                    cmbMSPBT.Properties.ReadOnly = True
                    cmdTim.Enabled = False
                Else
                    cmbMSPBT.Properties.ReadOnly = False
                    cmdTim.Enabled = True
                End If

            End If
        End If
    End Sub

    Private Sub btnChoTH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoTH.Click
        VisibleControl(False)
        btnALL.Visible = True
        btnNotAll.Visible = True
        ''cmbCachTH.EditValue = Nothing
        cmbCachTH.Enabled = False
        isBoQuaOrCho = 6
        CachThucHien_Action(6)
        MoKhoaLuoi(True)
    End Sub

    Private Sub MoKhoaLuoi(ByVal value As Boolean)
        Try
            GridViewDuyet.Columns("CHON").Visible = value
            GridViewDuyet.Columns("CHON").OptionsColumn.AllowEdit = value
            GridViewDuyet.Columns("CHON").OptionsColumn.AllowFocus = value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChonOrKhongChon(ByVal Chon As Integer)
        Dim i As Integer
        For i = 0 To GridViewDuyet.RowCount - 1
            GridViewDuyet.SetRowCellValue(i, "CHON", Chon)
        Next
    End Sub

    Private Sub btnALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnALL.Click
        ChonOrKhongChon(1)
    End Sub

    Private Sub btnNotAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotAll.Click
        ChonOrKhongChon(0)
    End Sub

    Private Sub btnNew2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew2.Click
        Dim frm As New ReportHuda.frmTaoKHTT
        frm.sMsMay = txtMSM.Text
        If cmbNVPT.Text = "" Then frm.sNVien = "-1" Else frm.sNVien = cmbNVPT.EditValue

        If frm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            cboKHTT.ItemIndex = -1
            Exit Sub
        End If

        Dim iHMuc As Integer
        iHMuc = frm.iHangMuc
        cmbNVPT.EditValue = frm.sNhanVienThucHien
        Try
            If iHMuc = -1 Then Exit Sub
            sql = " EXEC sp_getKHTT '" & txtSTT.Text & "','" & txtMSM.Text & "','" & txtSTVD.Text & "'"
            cboKHTT.Properties.DataSource = Nothing
            cboKHTT.Properties.ValueMember = ""
            cboKHTT.Properties.DisplayMember = ""

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKHTT, sql, "MA", "TEN", lblMSPBT.Text)
            cboKHTT.Properties.ShowHeader = False
            cboKHTT.Properties.ShowFooter = False
            cboKHTT.Properties.DropDownRows = 7

            cboKHTT.EditValue = iHMuc.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNew1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew1.Click
        Commons.Modules.SQLString = "frmYeuCauBT"
        Dim frm As New Report1.frmLapphieubaotri_CS
        'kiểm tra nếu có tồn tại ngày giờ sự cố thì gán vào
        If Not String.IsNullOrEmpty(GridViewDuyet.GetFocusedRowCellValue("NGAY_XAY_RA").ToString()) Then
            frm.dNgayHong = Convert.ToDateTime(GridViewDuyet.GetFocusedRowCellValue("NGAY_XAY_RA").ToString())
        End If
        If Not String.IsNullOrEmpty(GridViewDuyet.GetFocusedRowCellValue("GIO_XAY_RA").ToString()) Then
            frm.dGioHong = Convert.ToDateTime(GridViewDuyet.GetFocusedRowCellValue("GIO_XAY_RA").ToString())
        End If


        frm.MS_MAY = txtMSM.Text
        frm.MS_NGUYEN_NHAN = GridViewDuyet.GetRowCellDisplayText(GridViewDuyet.FocusedRowHandle, "TEN_NGUYEN_NHAN")
        frm.MucUuTien = GridViewDuyet.GetFocusedRowCellValue("MS_UU_TIEN")
        frm.ShowDialog()
        If Commons.Modules.SQLString <> "" Then
            LoadPhieuBaoTri()
            cmbNVPT.EditValue = frm.sNhanVienThucHien
        Else
            cmbMSPBT.EditValue = ""
        End If
        Commons.Modules.SQLString = ""
    End Sub

    Private Sub TimerLogin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLogin.Tick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i = 0 To GridViewDuyet.Columns.Count - 1
            If GridViewDuyet.Columns(i).Visible = True Then

                MsgBox(GridViewDuyet.Columns(i).FieldName & " : " & GridViewDuyet.Columns(i).Width.ToString())
            End If

        Next
    End Sub



    Private Sub ControlButton()
        btnBoQua.Visible = True
        btnChoTH.Visible = True


        If CoAnHienDuyet = True Then
            cmdDuyet.Visible = True
            btnBoQua.Visible = True
            btnChoTH.Visible = True
        Else
            cmdDuyet.Visible = False
            btnBoQua.Visible = False
            btnChoTH.Visible = False
        End If
        Select Case GroupChon.SelectedIndex
            Case 0 'Chưa kiểm tra'
                btnBoQua.Enabled = True
                btnChoTH.Enabled = True
                cmdDuyet.Enabled = True
            Case 1 'Đợi đưa vào kế hoạch'
                btnBoQua.Enabled = True
                btnChoTH.Enabled = False
                cmdDuyet.Enabled = True
            Case 2 'Đã đưa vào KHTT'
                btnBoQua.Enabled = False
                btnChoTH.Enabled = False
                cmdDuyet.Enabled = False
            Case 3 'Đang bảo trì'
                btnBoQua.Enabled = False
                btnChoTH.Enabled = False
                cmdDuyet.Enabled = False
            Case 4 'Đã hoàn thành bào trì'
                btnBoQua.Enabled = False
                btnChoTH.Enabled = False
                cmdDuyet.Enabled = False
            Case 5 'Không chấp nhận thực hiện'
                btnBoQua.Enabled = False
                btnChoTH.Enabled = True
                cmdDuyet.Enabled = True
        End Select
        If GridViewDuyet.RowCount = 0 Then
            btnBoQua.Enabled = False
            btnChoTH.Enabled = False
            cmdDuyet.Enabled = False
            btnXemTL.Visible = False
        Else
            If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = False Then
                btnXemTL.Visible = True
            Else
                btnXemTL.Visible = False
            End If
        End If



    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub GridViewDuyet_RowCellClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridViewDuyet.RowCellClick
        If IsDBNull(GridViewDuyet.GetFocusedRowCellValue("TAI_LIEU")) = False Then
            btnXemTL.Visible = True
        Else
            btnXemTL.Visible = False
        End If

        'DoRowMouseUp_XuLy()


        'Dim pingSender As New Ping()
        'Dim address As IPAddress = IPAddress.Loopback
        'Dim reply As PingReply = pingSender.Send("192.168.1.10")

        'If reply.Status = IPStatus.Success Then
        '    MsgBox("ok")
        'Else
        '    MsgBox("not found")
        'End If

    End Sub




    Private Sub DoRowMouseUp_XuLy()
        'Try
        '    Dim info As GridViewInfo = TryCast(GridViewDuyet.GetViewInfo(), GridViewInfo)
        '    Dim cell As GridCellInfo = info.GetGridCellInfo((GridViewDuyet.GetSelectedRows())(0), 0)
        '    Dim p As New Point(24, Control.MousePosition.Y + 13)

        '    DockPanel1.FloatLocation = p
        '    ShowPanel()
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub datTNgay_EditValueChanged(sender As Object, e As EventArgs) Handles datTNgay.EditValueChanged
        If (flagLoad = True) Then Exit Sub
        GroupChon_SelectedIndexChanged(GroupChon, Nothing)

    End Sub

    Private Sub datDNgay_EditValueChanged(sender As Object, e As EventArgs) Handles datDNgay.EditValueChanged
        If (flagLoad = True) Then Exit Sub
        GroupChon_SelectedIndexChanged(GroupChon, Nothing)


    End Sub



    Private Sub cboLMay_EditValueChanged(sender As Object, e As EventArgs) Handles cboLMay.EditValueChanged
        If (flagLoad = True) Then Exit Sub
        GroupChon_SelectedIndexChanged(GroupChon, Nothing)


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

    Private Sub cboNXuong_EditValuedChanged(sender As Object, e As MVControl.ucComboboxTreeList.EventArgs) Handles cboNXuong.EditValuedChanged
        If (flagLoad = True) Then Exit Sub
        GroupChon_SelectedIndexChanged(GroupChon, Nothing)
    End Sub
End Class