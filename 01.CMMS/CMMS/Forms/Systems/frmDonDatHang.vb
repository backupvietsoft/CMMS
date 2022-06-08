
Imports Commons.VS.Classes.Catalogue
Imports Commons.VS.Classes.Admin
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Microsoft.VisualBasic.DateAndTime


Public Class frmDonDatHang
    Dim MS_DDH As String = ""
    Dim SO_DE_XUAT As String = ""
    Dim bThem As Boolean = False
    Dim intRow As Integer


    Private Sub frmDonDatHang_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim str As String = ""
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmpChonPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[tmpChonPT" & Commons.Modules.UserName & "]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub frmDonDatHang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'grdDAnhsachPt.Columns.Clear()
            grdDAnhsachPt.DataSource = Nothing
            cboSoPR.DataSource = Nothing
        Catch ex As Exception

        End Try
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Commons.Modules.ObjSystems.DinhDang()
        chkDuyet.Checked = False
        VisibleButtton(True)
        LoadcboMS_DDH()
        LoadcboKHACH_HANG()
        BindData()
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        Else
            EnableButton(True)
        End If
        AddHandler chkDuyet.CheckedChanged, AddressOf Me.chkDuyet_CheckedChanged
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
        BtnDuyet.Enabled = chon
    End Sub
    Sub LoadcboMS_DDH()
        cboMS_DDH.DataSource = Nothing
        cboMS_DDH.Display = "MS_DDH"
        cboMS_DDH.Value = "MS_DDH"
        cboMS_DDH.StoreName = "GetDON_DAT_HANGs"
        cboMS_DDH.Param = IIf(chkDuyet.Checked, 1, 0)
        cboMS_DDH.BindDataSource()
    End Sub
    Sub LoadcboKHACH_HANG()
        cboKhachHang.Display = "TEN_CONG_TY"
        cboKhachHang.Value = "MS_KH"
        cboKhachHang.StoreName = "GetKHACH_HANGs"
        cboKhachHang.BindDataSource()
    End Sub
    Sub LoadcboSoDeXuat(ByVal ms_ddh As String)
        cboSoPR.Display = "SO_DE_XUAT"
        cboSoPR.Value = "SO_DE_XUAT"
        cboSoPR.StoreName = "GetDE_XUAT_MUA_HANGs1"
        cboSoPR.Param = ms_ddh
        cboSoPR.BindDataSource()
    End Sub
    Sub Clear()

        txtMS_DDH.Text = ""
        txtDiaChi.Text = ""
        txtFax.Text = ""
        txtXacNhan.Text = ""
        txtNguoiDuyet.Text = ""
        txtNguoiDatHang.Text = ""
        txtFax1.Text = ""
        txtDiaChi1.Text = ""
        txtThoiHan.Text = ""
        txtNguoiLienHe.Text = ""
        TXTVat.Text = 5
        txtTongST.Text = 0
        txtTongTT.Text = 0
        txtThueVAT.Text = 0
        txtSoPR.Text = ""
        Try
            grdDAnhsachPt.Columns.Clear()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindData()
        grdDAnhsachPt.Columns.Clear()
        Clear()
        If cboMS_DDH.SelectedValue Is Nothing Then
            Exit Sub
        End If
        LoadcboSoDeXuat(cboMS_DDH.SelectedValue)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_DAT_HANG", cboMS_DDH.SelectedValue)
        While objReader.Read
            cboKhachHang.SelectedValue = objReader.Item("MS_KH")
            'txtDiaChi.Text = objReader.Item("DIA_CHI1").ToString
            ' txtFax.Text = objReader.Item("FAX").ToString
            txtSoPR.Text = objReader.Item("SO_DE_XUAT").ToString
            dtNgay.Value = objReader.Item("NGAY_LAP")
            txtFax1.Text = objReader.Item("FAX").ToString
            txtDiaChi1.Text = objReader.Item("DIA_CHI_GIAO_HANG").ToString
            txtThoiHan.Text = objReader.Item("THOI_HAN_THANH_TOAN").ToString
            txtNguoiLienHe.Text = objReader.Item("NGUOI_LIEN_HE").ToString
            txtTongTT.Text = objReader.Item("THANH_TIEN")
            TXTVat.Text = objReader.Item("VAT")
            txtThueVAT.Text = objReader.Item("THANH_TIEN") * objReader.Item("VAT") / 100
            txtTongST.Text = objReader.Item("THANH_TIEN") + (objReader.Item("THANH_TIEN") * objReader.Item("VAT") / 100)
        End While
        objReader.Close()
        grdDAnhsachPt.DataSource = New clsDON_DAT_HANGController().GetDON_DAT_HANG_CHI_TIETs(cboMS_DDH.SelectedValue)
        grdDAnhsachPt.Columns("NGAY_GIAO").Visible = False
        grdDAnhsachPt.Columns("TON_TAI").Visible = False
        AddColumn()
        For i As Integer = 0 To grdDAnhsachPt.Columns.Count - 1
            grdDAnhsachPt.Columns(i).ReadOnly = True
        Next
        RefreshLanguage()
    End Sub

    Private Sub cboSoPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If BtnGhi.Visible Then
            LoadData()
        End If
    End Sub

    Sub RefreshLanguage()
        grdDAnhsachPt.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
        grdDAnhsachPt.Columns("MS_PT").Width = 100
        grdDAnhsachPt.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
        grdDAnhsachPt.Columns("TEN_PT").Width = 220
        grdDAnhsachPt.Columns("DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DVT", Commons.Modules.TypeLanguage)
        grdDAnhsachPt.Columns("DVT").Width = 80
        grdDAnhsachPt.Columns("SO_LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG", Commons.Modules.TypeLanguage)
        grdDAnhsachPt.Columns("SO_LUONG").Width = 80
        grdDAnhsachPt.Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDAnhsachPt.Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDAnhsachPt.Columns("DON_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA", Commons.Modules.TypeLanguage)
        grdDAnhsachPt.Columns("DON_GIA").Width = 100
        grdDAnhsachPt.Columns("DON_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDAnhsachPt.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_TIEN", Commons.Modules.TypeLanguage)
        grdDAnhsachPt.Columns("THANH_TIEN").Width = 120
        grdDAnhsachPt.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDAnhsachPt.Columns("cboThoiGianGiaoHang").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_GIAO", Commons.Modules.TypeLanguage)
        grdDAnhsachPt.Columns("cboThoiGianGiaoHang").Width = 80
        Try
            Me.grdDAnhsachPt.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDAnhsachPt.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

    End Sub
    Sub VisibleButtton(ByVal chon As Boolean)
        BtnThem.Visible = chon
        BtnSua.Visible = chon
        BtnThoat.Visible = chon
        BtnXoa.Visible = chon
        BtnIn.Visible = chon
        BtnGhi.Visible = Not chon
        BtnKhongghi.Visible = Not chon
        txtMS_DDH.Visible = Not chon
        BtnChonVatTu.Visible = False
        cboMS_DDH.Visible = chon
        cboKhachHang.Enabled = Not chon
        dtNgay.Enabled = Not chon
        cboSoPR.Enabled = Not chon
        txtNguoiDatHang.Enabled = Not chon
        txtNguoiDuyet.Enabled = Not chon
        txtXacNhan.Enabled = Not chon
        txtFax1.Enabled = Not chon
        txtDiaChi1.Enabled = Not chon
        txtDienThoai.Enabled = Not chon
        txtThoiHan.Enabled = Not chon
        txtNguoiLienHe.Enabled = Not chon
        txtSoPR.Enabled = Not chon
        txtSoPR.Visible = chon
        BtnDuyet.Visible = chon
        chkDuyet.Enabled = chon

    End Sub

    Private Sub cboMS_DDH_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMS_DDH.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Clear()

        bThem = True
        VisibleButtton(False)
        LoadcboSoDeXuat("-1")
        Try
            grdDAnhsachPt.Columns("SO_LUONG").ReadOnly = False
            grdDAnhsachPt.Columns("DON_GIA").ReadOnly = False
            grdDAnhsachPt.Columns("cboThoiGianGiaoHang").ReadOnly = False
        Catch ex As Exception
        End Try
        Dim str As String = ""
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmpChonPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[tmpChonPT" & Commons.Modules.UserName & "]" & _
        "Create table dbo.tmpChonPT" & Commons.Modules.UserName & "(MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255),DVT NVARCHAR(20))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        txtMS_DDH.Focus()
        cboSoPR.Text = ""
        AddHandler cboSoPR.SelectedIndexChanged, AddressOf Me.cboSoPR_SelectedIndexChanged
    End Sub
    Dim SO_PR As String = ""
    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        If grdDAnhsachPt.Rows.Count = 0 Then
            Exit Sub
        End If
        LoadcboSoDeXuat(cboMS_DDH.SelectedValue)
        bThem = False
        VisibleButtton(False)
        MS_DDH = cboMS_DDH.SelectedValue
        txtMS_DDH.Text = cboMS_DDH.SelectedValue
        SO_PR = txtSoPR.Text
        Try
            grdDAnhsachPt.Columns("SO_LUONG").ReadOnly = False
            grdDAnhsachPt.Columns("DON_GIA").ReadOnly = False
            grdDAnhsachPt.Columns("cboThoiGianGiaoHang").ReadOnly = False
        Catch ex As Exception
        End Try
        Dim str As String = ""
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmpChonPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[tmpChonPT" & Commons.Modules.UserName & "]" & _
        "Create table dbo.tmpChonPT" & Commons.Modules.UserName & "(MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255),DVT NVARCHAR(20))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        txtMS_DDH.Focus()
        AddHandler cboSoPR.SelectedIndexChanged, AddressOf Me.cboSoPR_SelectedIndexChanged
    End Sub
    Sub LoadData()
        grdDAnhsachPt.Columns.Clear()
        Dim str As String = ""
        If Not bThem And SO_PR = cboSoPR.SelectedValue Then
            str = "SELECT     DON_DAT_HANG_CHI_TIET.MS_PT, IC_PHU_TUNG.TEN_PT, CASE " & Commons.Modules.TypeLanguage & "  WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT,DON_DAT_HANG_CHI_TIET.SO_LUONG, " & _
            " DON_DAT_HANG_CHI_TIET.DON_GIA, DON_DAT_HANG_CHI_TIET.SO_LUONG * DON_DAT_HANG_CHI_TIET.DON_GIA AS THANH_TIEN,  " & _
            " CONVERT(NVARCHAR(10),DON_DAT_HANG_CHI_TIET.NGAY_GIAO,103) AS NGAY_GIAO,1 AS TON_TAI " & _
            " FROM  DON_DAT_HANG_CHI_TIET INNER JOIN IC_PHU_TUNG ON DON_DAT_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " & _
            " DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT WHERE MS_DDH='" & MS_DDH & "'" & _
            " UNION SELECT     A.MS_PT, TEN_PT, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 ELSE TEN_2 END AS DVT, SO_LUONG, CONVERT(float, NULL) AS DON_GIA, CONVERT(FLOAT, NULL) " & _
            " AS THANH_TIEN, CONVERT(NVARCHAR(10), NULL) AS NGAY_GIAO, 0 AS TON_TAI FROM DE_XUAT_MUA_HANG_CHI_TIET A INNER JOIN " & _
            " IC_PHU_TUNG PT ON PT.MS_PT = A.MS_PT INNER JOIN DON_VI_TINH ON DON_VI_TINH.DVT = PT.DVT " & _
            " WHERE  SO_DE_XUAT = '" & cboSoPR.SelectedValue & "' AND A.MS_PT NOT IN (SELECT  MS_PT FROM DON_DAT_HANG_CHI_TIET B INNER JOIN " & _
            " DON_DAT_HANG C ON C.MS_DDH = B.MS_DDH WHERE C.SO_DE_XUAT = A.SO_DE_XUAT )"
        Else
            str = "SELECT     A.MS_PT, TEN_PT, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 ELSE TEN_2 END AS DVT, SO_LUONG, CONVERT(float, NULL) AS DON_GIA, CONVERT(FLOAT, NULL) " & _
            " AS THANH_TIEN, CONVERT(NVARCHAR(10), NULL) AS NGAY_GIAO, 0 AS TON_TAI FROM DE_XUAT_MUA_HANG_CHI_TIET A INNER JOIN " & _
            " IC_PHU_TUNG PT ON PT.MS_PT = A.MS_PT INNER JOIN DON_VI_TINH ON DON_VI_TINH.DVT = PT.DVT " & _
            " WHERE  SO_DE_XUAT = '" & cboSoPR.SelectedValue & "' AND A.MS_PT NOT IN (SELECT  MS_PT FROM DON_DAT_HANG_CHI_TIET B INNER JOIN " & _
            " DON_DAT_HANG C ON C.MS_DDH = B.MS_DDH WHERE C.SO_DE_XUAT = A.SO_DE_XUAT )"
        End If
        grdDAnhsachPt.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        grdDAnhsachPt.Columns("TON_TAI").Visible = False
        grdDAnhsachPt.Columns("NGAY_GIAO").Visible = False
        AddColumn()
        Try
            grdDAnhsachPt.Columns("SO_LUONG").ReadOnly = False
            grdDAnhsachPt.Columns("DON_GIA").ReadOnly = False
            grdDAnhsachPt.Columns("cboThoiGianGiaoHang").ReadOnly = False
        Catch ex As Exception
        End Try
        RefreshLanguage()
    End Sub
    Sub AddColumn()
        Dim col As New Commons.QLGridMaskedTextBoxColumn  'MaskedTextBoxColumn("00/00/0000")
        col.Name = "cboThoiGianGiaoHang"
        col.DataPropertyName = "NGAY_GIAO"
        col.Mask = "00/00/0000"
        col.DefaultCellStyle.Format = Nothing
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDAnhsachPt.Columns.Insert(6, col)

    End Sub
    Private Sub BtnChonVatTu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChonVatTu.Click
        Dim frmChonPTDeXuat_CS As Report1.frmChonPTDeXuat_CS = New Report1.frmChonPTDeXuat_CS()
        frmChonPTDeXuat_CS.ShowDialog()
        LoadData()
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        RemoveHandler cboSoPR.SelectedIndexChanged, AddressOf Me.cboSoPR_SelectedIndexChanged
        ErrorProvider1.Clear()
        bThem = False
        VisibleButtton(True)
        BindData()
    End Sub
    Function isValidate()
        If Not txtMS_DDH.IsValidated Then
            txtMS_DDH.Focus()
            Return False
        End If
        If Not TXTVat.IsValidated Then
            TXTVat.Focus()
            Return False
        End If
        If Not cboKhachHang.IsValidated Then
            cboKhachHang.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        RemoveHandler cboSoPR.SelectedIndexChanged, AddressOf Me.cboSoPR_SelectedIndexChanged
        If Not isValidate() Then
            Exit Sub
        End If
        Dim bSoLuong As Integer = -1
        For i As Integer = 0 To grdDAnhsachPt.Rows.Count - 1
            If grdDAnhsachPt.Rows(i).Cells("THANH_TIEN").Value.ToString = "" Or grdDAnhsachPt.Rows(i).Cells("THANH_TIEN").Value.ToString = "0" Then
                bSoLuong = bSoLuong + 1 'SỐ DÒNG CHƯA NHẬP ĐƠN GIÁ
            End If
        Next
        Dim Traloi As String
        If grdDAnhsachPt.Rows.Count = 0 Then
            Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuaChonVatTu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Exit Sub
            Else
                GoTo KetThuc
            End If
        ElseIf bSoLuong = grdDAnhsachPt.Rows.Count - 1 Then
            Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuaNhapSoLuongChoVatTu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Exit Sub
            Else
                GoTo KetThuc
            End If
        ElseIf bSoLuong < grdDAnhsachPt.Rows.Count - 1 And bSoLuong <> -1 Then
            Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoLuongChuaNhap", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                grdDAnhsachPt.Focus()
                Exit Sub
            End If
        End If
        'For i As Integer = 0 To grdDAnhsachPt.Rows.Count - 1
        '    If grdDAnhsachPt.Rows(i).Cells("THANH_TIEN").Value.ToString = "" Or grdDAnhsachPt.Rows(i).Cells("THANH_TIEN").Value.ToString = "0" Then
        '        'XtraMessageBox.Show("Còn tồn tại vật tư chưa nhập số lượng. Nhấn Yes để nhập tiếp số lượng. Nhấn No để bỏ những vật tư chưa nhập số lượng")
        '        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongChuaNhap", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        '        If Traloi = vbYes Then
        '            grdDAnhsachPt.CurrentCell() = grdDAnhsachPt.Rows(i).Cells("SO_LUONG")
        '            grdDAnhsachPt.Focus()
        '            Exit Sub
        '        Else
        '            Exit For
        '        End If
        '    End If
        'Next
        Dim tmp As String = ""
        If txtTongTT.Text > 0 Then
            Dim tb As New DataTable()
            tb = grdDAnhsachPt.DataSource
            Dim objDonDH As New clsDON_DAT_HANGController()
            Dim objDonDHInfo As New clsDON_DAT_HANGInfo()
            objDonDHInfo.MS_DDH = txtMS_DDH.Text.Trim
            objDonDHInfo.NGAY_LAP = Format(dtNgay.Value, "Short date")
            objDonDHInfo.SO_DE_XUAT = cboSoPR.SelectedValue
            objDonDHInfo.MS_KH = cboKhachHang.SelectedValue
            objDonDHInfo.NGUOI_XAC_NHAN = txtXacNhan.Text
            objDonDHInfo.NGUOI_DUYET = txtNguoiDuyet.Text
            objDonDHInfo.NGUOI_DAT_HANG = txtNguoiDatHang.Text
            objDonDHInfo.FAX = txtFax1.Text
            objDonDHInfo.DIEN_THOAI = txtDienThoai.Text
            objDonDHInfo.DIA_CHI_GIAO_HANG = txtDiaChi1.Text
            objDonDHInfo.NGUOI_LIEN_HE = txtNguoiLienHe.Text
            objDonDHInfo.THOI_HAN_THANH_TOAN = txtThoiHan.Text
            objDonDHInfo.THANH_TIEN = IIf(txtTongTT.Text = "", 0, txtTongTT.Text)
            objDonDHInfo.VAT = TXTVat.Text
            If Not bThem Then
                objDonDHInfo.MS_DDH_CU = MS_DDH
            End If
            tmp = objDonDH.AddDON_DAT_HANG(objDonDHInfo, tb)
            If tmp = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLuuKhongThanhCong", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            chkDuyet.Checked = False
            LoadcboMS_DDH()
            cboMS_DDH.SelectedValue = tmp
        Else
            Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuaVatTu", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Exit Sub
            End If
        End If
KetThuc:
        bThem = False
        VisibleButtton(True)

        BindData()
    End Sub
    Dim txtSoLuong As TextBox
    Dim txtDonGia As TextBox
    Sub HandleKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
            End If
        End If
    End Sub
    Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub

    Private Sub grdDAnhsachPt_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDAnhsachPt.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If grdDAnhsachPt.Columns(e.ColumnIndex).Name = "cboThoiGianGiaoHang" Then
                If e.FormattedValue <> "" And e.FormattedValue <> "  /  /" Then
                    If Not IsDate(e.FormattedValue) Then
                        'XtraMessageBox.Show("Ngày giao hàng không hợp lệ")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayGiaoKhongHopLe", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        e.Cancel = True
                    Else
                        If Date.Parse(Format(dtNgay.Value, "Short date")) > Date.Parse(e.FormattedValue) Then
                            'XtraMessageBox.Show("Ngày giao hàng phải lớn hơn ngày đặt hàng")
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayGiaoNhoHonNgayLap", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        End If
                    End If
                End If
            ElseIf grdDAnhsachPt.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
                If grdDAnhsachPt.Rows(e.RowIndex).Cells("DON_GIA").Value.ToString <> "" Then
                    If e.FormattedValue = "" Then
                        grdDAnhsachPt.Rows(e.RowIndex).Cells("THANH_TIEN").Value = 0
                    Else
                        grdDAnhsachPt.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * grdDAnhsachPt.Rows(e.RowIndex).Cells("DON_GIA").Value
                    End If

                    TongCong()
                End If
                TongCong()
            ElseIf grdDAnhsachPt.Columns(e.ColumnIndex).Name = "DON_GIA" Then
                If grdDAnhsachPt.Rows(e.RowIndex).Cells("SO_LUONG").Value.ToString <> "" Then
                    If e.FormattedValue = "" Then
                        grdDAnhsachPt.Rows(e.RowIndex).Cells("THANH_TIEN").Value = 0
                    Else
                        grdDAnhsachPt.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * grdDAnhsachPt.Rows(e.RowIndex).Cells("SO_LUONG").Value
                    End If

                    TongCong()
                End If
                TongCong()
            End If
        End If
    End Sub
    Sub TongCong()
        Dim tmp As Double = 0
        For i As Integer = 0 To grdDAnhsachPt.Rows.Count - 1
            tmp = tmp + IIf(grdDAnhsachPt.Rows(i).Cells("THANH_TIEN").Value.ToString = "", 0, grdDAnhsachPt.Rows(i).Cells("THANH_TIEN").Value)
        Next
        txtTongTT.Text = tmp.ToString
        txtThueVAT.Text = (tmp * IIf(TXTVat.Text = "", 0, TXTVat.Text)) / 100.ToString
        txtTongST.Text = (tmp + tmp * IIf(TXTVat.Text = "", 0, TXTVat.Text) / 100).ToString
    End Sub
    Private Sub grdDAnhsachPt_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDAnhsachPt.EditingControlShowing
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Try
            If TypeOf e.Control Is TextBox Then
                If dgv.CurrentCell.OwningColumn.Name = "SO_LUONG" Then
                    txtSoLuong = e.Control

                    RemoveHandler txtSoLuong.KeyPress, AddressOf Me.HandleKeyPress
                    AddHandler txtSoLuong.KeyPress, AddressOf Me.HandleKeyPress
                Else
                    RemoveHandler txtSoLuong.KeyPress, AddressOf Me.HandleKeyPress
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If TypeOf e.Control Is TextBox Then
                If dgv.CurrentCell.OwningColumn.Name = "DON_GIA" Then
                    txtDonGia = e.Control

                    RemoveHandler txtDonGia.KeyPress, AddressOf Me.HandleKeyPressFloat
                    AddHandler txtDonGia.KeyPress, AddressOf Me.HandleKeyPressFloat
                Else
                    RemoveHandler txtDonGia.KeyPress, AddressOf Me.HandleKeyPressFloat
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grdDAnhsachPt.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "select distinct MS_DDH FROM IC_DON_HANG_NHAP WHERE MS_DDH='" & cboMS_DDH.SelectedValue.ToString.Replace("'", "''") & "'")
        While objReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDonDHDuocSD", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            objReader.Close()
            Exit Sub
        End While
        objReader.Close()
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim RowCount As Integer = grdDAnhsachPt.Rows.Count
            Dim tmp As Integer = intRow
            Dim objDeXuat As New clsDON_DAT_HANGController()
            objDeXuat.DelateDON_DAT_HANG_CHI_TIET(cboMS_DDH.SelectedValue, grdDAnhsachPt.Rows(intRow).Cells("MS_PT").Value)
            If RowCount = 1 Then
                objDeXuat.DeleteDON_DAT_HANG(cboMS_DDH.SelectedValue)
                LoadcboMS_DDH()
            End If
            BindData()
            If RowCount > 1 Then
                If tmp = grdDAnhsachPt.Rows.Count Then
                    grdDAnhsachPt.CurrentCell() = grdDAnhsachPt.Rows(tmp - 1).Cells("MS_PT")
                    grdDAnhsachPt.Focus()
                    Exit Sub
                ElseIf tmp < grdDAnhsachPt.Rows.Count Then
                    grdDAnhsachPt.CurrentCell() = grdDAnhsachPt.Rows(tmp).Cells("MS_PT")
                    grdDAnhsachPt.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grdDAnhsachPt_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDAnhsachPt.RowEnter
        If e.RowIndex >= 0 Then
            intRow = e.RowIndex
        End If
    End Sub

    Private Sub cboKhachHang_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKhachHang.Validating
        If cboKhachHang.SelectedValue Is Nothing Then
            txtFax.Text = ""
            txtDiaChi.Text = ""
            e.Cancel = True
        Else

            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHACH_HANG", cboKhachHang.SelectedValue)
            While objReader.Read
                txtFax.Text = objReader.Item("FAX").ToString
                txtDiaChi.Text = objReader.Item("DIA_CHI").ToString
            End While
            objReader.Close()
        End If
    End Sub
    Sub CreaterptTieuDenDonDatHang()
        Dim str As String = ""
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "TrangIn", Commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "NgayIn", Commons.Modules.TypeLanguage)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "TieuDe", Commons.Modules.TypeLanguage)
        Dim Ngay As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "NgayLap", Commons.Modules.TypeLanguage)
        Dim KhachHang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "KhachHang", Commons.Modules.TypeLanguage)
        Dim DiaChi As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "DiaChi", Commons.Modules.TypeLanguage)
        Dim Fax As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Fax", Commons.Modules.TypeLanguage)
        Dim SoDDH As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "SoDDH", Commons.Modules.TypeLanguage)
        Dim SoPR As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "SoPR", Commons.Modules.TypeLanguage)
        Dim Note As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note", Commons.Modules.TypeLanguage)
        Dim STT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "STT", Commons.Modules.TypeLanguage)
        Dim MaPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "MaPT", Commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "TenPT", Commons.Modules.TypeLanguage)
        Dim DVT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "DVT", Commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "SoLuong", Commons.Modules.TypeLanguage)
        Dim DonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "DonGia", Commons.Modules.TypeLanguage)
        Dim ThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "ThanhTien", Commons.Modules.TypeLanguage)
        Dim NgayGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "NgayGiao", Commons.Modules.TypeLanguage)
        Dim TongTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "TongTT", Commons.Modules.TypeLanguage)
        Dim ThueVAT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "ThueVAT", Commons.Modules.TypeLanguage)
        Dim TongST As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "TongST", Commons.Modules.TypeLanguage)
        Dim Note1 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note1", Commons.Modules.TypeLanguage)
        Dim Note3 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note3", Commons.Modules.TypeLanguage)
        Dim Note4 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note4", Commons.Modules.TypeLanguage)
        Dim Note5 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note5", Commons.Modules.TypeLanguage)
        Dim Note6 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note6", Commons.Modules.TypeLanguage)
        Dim Note7 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note7", Commons.Modules.TypeLanguage)
        Dim Note8 As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "Note8", Commons.Modules.TypeLanguage)
        Dim XacNhan As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "XacNhan", Commons.Modules.TypeLanguage)
        Dim NguoiDuyet As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "NguoiDuyet", Commons.Modules.TypeLanguage)
        Dim NguoiDatHang As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptDonDatHang", "NguoiDatHang", Commons.Modules.TypeLanguage)
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rptTieuDeDonDatHang]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " & _
        " drop table [dbo].[rptTieuDeDonDatHang] " & _
        " Create table dbo.rptTieuDeDonDatHang(TypeLanguage int,NgayIn nvarchar(20),TrangIn nvarchar(20),TieuDe nvarchar(255),Ngay nvarchar(30), " & _
        " SoDDH nvarchar(20),SoPR nvarchar(30),KhachHang nvarchar(20),DiaChi nvarchar(20),sFax nvarchar(3),Note nvarchar(150),STT nvarchar(5),MaPT nvarchar(20), " & _
        " TenPT nvarchar(20),DVT nvarchar(10),SoLuong nvarchar(15),DonGia nvarchar(50),ThanhTien nvarchar(30),NgayGiao nvarchar(30),TongTT nvarchar(30), " & _
        " ThueVAT nvarchar(30),TongST nvarchar(30),Note1 nvarchar(150),Note3 nvarchar(150),Note4 nvarchar(150),Note5 nvarchar(150),Note6 nvarchar(150), " & _
        " Note7 nvarchar(150),Note8 nvarchar(150),XacNhan nvarchar(20), NguoiDuyet nvarchar(20),NguoiDatHang nvarchar(30)) " & _
        " Insert into rptTieuDeDonDatHang values(" & Commons.Modules.TypeLanguage & ",N'" & NgayIn & "',N'" & TrangIn & "',N'" & TieuDe & "',N'" & Ngay & "',N'" & SoDDH & _
        "',N'" & SoPR & "',N'" & KhachHang & "',N'" & DiaChi & "',N'" & Fax & "',N'" & Note & "',N'" & STT & "',N'" & MaPT & "',N'" & TenPT & "',N'" & DVT & _
        "',N'" & SoLuong & "',N'" & DonGia & "',N'" & ThanhTien & "',N'" & NgayGiao & "',N'" & TongTT & "',N'" & ThueVAT & "',N'" & TongST & "',N'" & Note1 & _
        "',N'" & Note3 & "',N'" & Note4 & "',N'" & Note5 & "',N'" & Note6 & "',N'" & Note7 & "',N'" & Note8 & "',N'" & XacNhan & "',N'" & NguoiDuyet & "',N'" & NguoiDatHang & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowrptDonDatHang()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptDON_DAT_HANG", cboMS_DDH.SelectedValue, Commons.Modules.TypeLanguage)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select count(*)as TONG from rptDON_DAT_HANG")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        CreaterptTieuDenDonDatHang()
        Commons.mdShowReport.ReportPreview("reports/rptDonDatHang.rpt")
KetThuc:
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rptTieuDeDonDatHang]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)  drop table [dbo].[rptTieuDeDonDatHang] ")
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rptDON_DAT_HANG]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[rptDON_DAT_HANG] ")
    End Sub
    Private Sub BtnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIn.Click
        If grdDAnhsachPt.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Commons.clsXuLy.CreateTitleReport()
        ShowrptDonDatHang()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TXTVat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTVat.KeyDown
        If (e.KeyValue >= 47 And e.KeyValue <= 56) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Or e.KeyValue = 8 Or e.KeyValue = 46 Or e.KeyValue = 37 Or e.KeyValue = 39 Or e.KeyValue = 109 Or e.KeyValue = 189 Or e.KeyValue = 110 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub chkDuyet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles chkDuyet.CheckedChanged
        LoadcboMS_DDH()
        BindData()
        If chkDuyet.Checked Then
            EnableButton(False)
        Else
            EnableButton(True)
        End If
    End Sub

    Private Sub BtnDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDuyet.Click
        If cboMS_DDH.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME='" & Commons.Modules.UserName & "' AND STT=2")
        While objReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE DON_DAT_HANG SET DUYET=1 WHERE MS_DDH='" & cboMS_DDH.SelectedValue & "'")
            'CAP NHAT NHUNG VAT TU CHUA CO VI TRI THANH VI TRI MAC DINH TRONG BANG IC_PHU_TUNG
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE IC_PHU_TUNG SET MS_VI_TRI=1 WHERE MS_PT IN(SELECT DON_DAT_HANG_CHI_TIET.MS_PT FROM DON_DAT_HANG_CHI_TIET INNER JOIN IC_PHU_TUNG ON DON_DAT_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT WHERE MS_DDH='" & cboMS_DDH.SelectedValue & "' AND MS_VI_TRI IS NULL)")
            objReader.Close()
            LoadcboMS_DDH()
            BindData()
            Exit Sub
        End While
        objReader.Close()
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoQuyenDuyet", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    End Sub

    Private Sub cboSoPR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSoPR.Validating
        If BtnGhi.Visible Then
            LoadData()
        End If
    End Sub



End Class