Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Windows.Forms
Imports Commons.VS.Classes.Admin
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Catalogue
Public Class frmDeXuatMuaHang
    Dim SO_DE_XUAT_CU As String = ""
    Dim bThem As Boolean = False
    Dim intRow As Integer

    Private Sub BtnChonVatTu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChonVatTu.Click
        Dim frmChonPTDeXuat_CS As Report1.frmChonPTDeXuat_CS = New Report1.frmChonPTDeXuat_CS()
        frmChonPTDeXuat_CS.ShowDialog()
        Dim str As String = ""
        If Not bThem Then
            str = "SELECT  DE_XUAT_MUA_HANG_CHI_TIET.MS_PT, TEN_PT, CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT, SO_LUONG,DE_XUAT_MUA_HANG_CHI_TIET.GHI_CHU ,1 AS TON_TAI" &
            " FROM DE_XUAT_MUA_HANG_CHI_TIET INNER JOIN  IC_PHU_TUNG ON DE_XUAT_MUA_HANG_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN " &
            " DON_VI_TINH ON IC_PHU_TUNG.DVT = DON_VI_TINH.DVT  WHERE SO_DE_XUAT='" & SO_DE_XUAT_CU & "'" &
            " UNION SELECT  MS_PT,TEN_PT ,DVT,CONVERT(INT,NULL) AS SO_LUONG,CONVERT(NVARCHAR(255),NULL) AS GHI_CHU,0 AS TON_TAI FROM tmpChonPT" & Commons.Modules.UserName &
            " where MS_PT NOT IN (SELECT MS_PT FROM DE_XUAT_MUA_HANG_CHI_TIET WHERE SO_DE_XUAT='" & SO_DE_XUAT_CU & "' )"
        Else
            str = " SELECT  MS_PT,TEN_PT ,DVT,CONVERT(INT,NULL) AS SO_LUONG,CONVERT(NVARCHAR(255),NULL) AS GHI_CHU,0 AS TON_TAI FROM tmpChonPT" & Commons.Modules.UserName
        End If
        grdDanhsachvattu.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        grdDanhsachvattu.Columns("TON_TAI").Visible = False
        RefreshLanguage()
        Try
            grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = False
            grdDanhsachvattu.Columns("GHI_CHU").ReadOnly = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub
    Sub BindData()
        grdDanhsachvattu.DataSource = Nothing
        Clear()
        If cbosoDeXuat.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDE_XUAT_MUA_HANG", cbosoDeXuat.SelectedValue)
        While objReader.Read
            cboPhongYC.SelectedValue = objReader.Item("MS_DON_VI")
            dtNgay.Value = objReader.Item("NGAY")
            txtNgayGiao.Text = objReader.Item("NGAY_GIAO").ToString
            txtGiaoCho.Text = objReader.Item("NGUOI_NHAN").ToString
            txtNguoiDuyet.Text = objReader.Item("NGUOI_DUYET").ToString

        End While
        objReader.Close()
        grdDanhsachvattu.DataSource = New clsDE_XUAT_MUA_HANGControler().GetDE_XUAT_MUA_HANG_CHI_TIETs(cbosoDeXuat.SelectedValue)
        grdDanhsachvattu.Columns("TON_TAI").Visible = False
        RefreshLanguage()

        BtnXoa.Enabled = IIf(grdDanhsachvattu.Rows.Count > 0, True, False)
        BtnThem.Enabled = True
        If Not chkDuyet.Checked Then
            'BtnXoa.Enabled = True
            BtnSua.Enabled = True
            BtnDuyet.Enabled = True
        Else
            'BtnXoa.Enabled = False
            BtnSua.Enabled = False
            BtnDuyet.Enabled = False
        End If
    End Sub
    Sub RefreshLanguage()
        grdDanhsachvattu.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("MS_PT").Width = 100
        grdDanhsachvattu.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("TEN_PT").Width = 200
        grdDanhsachvattu.Columns("DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DVT", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("DVT").Width = 80
        grdDanhsachvattu.Columns("SO_LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_LUONG", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("SO_LUONG").Width = 80
        grdDanhsachvattu.Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GHI_CHU", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("GHI_CHU").Width = 250
        Try
            Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        For i As Integer = 0 To grdDanhsachvattu.Columns.Count - 1
            grdDanhsachvattu.Columns(i).ReadOnly = True
        Next
    End Sub
    Sub Clear()
        txtNgayGiao.Text = ""
        txtGiaoCho.Text = ""
        txtNguoiDuyet.Text = ""
        txtSoDeXuat.Text = ""
        grdDanhsachvattu.DataSource = Nothing
    End Sub
    Sub LoadcboPhongYC()

        Dim dt As New DataTable()
        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VIs", Commons.Modules.UserName))
        cboPhongYC.ValueMember = "MS_DON_VI"
        cboPhongYC.DisplayMember = "TEN_DON_VI"
        cboPhongYC.DataSource = dt

    End Sub
    Sub LoadcboSoDeXuat()
        cbosoDeXuat.DataSource = Nothing
        cbosoDeXuat.Display = "SO_DE_XUAT"
        cbosoDeXuat.Value = "SO_DE_XUAT"
        cbosoDeXuat.StoreName = "GetDE_XUAT_MUA_HANGs"
        cbosoDeXuat.Param = IIf(chkDuyet.Checked, 1, 0)
        cbosoDeXuat.BindDataSource()
    End Sub
    Sub VisibleButtton(ByVal chon As Boolean)
        BtnThem.Visible = chon
        BtnSua.Visible = chon
        BtnThoat.Visible = chon
        BtnXoa.Visible = chon
        BtnGhi.Visible = Not chon
        BtnKhongghi.Visible = Not chon
        txtSoDeXuat.Visible = Not chon
        BtnChonVatTu.Visible = Not chon
        cbosoDeXuat.Visible = chon
        BtnIn.Visible = chon
        BtnDuyet.Visible = chon
        chkDuyet.Enabled = chon
        cboPhongYC.Enabled = Not chon
        txtNgayGiao.Enabled = Not chon
        txtGiaoCho.Enabled = Not chon
        txtNguoiDuyet.Enabled = Not chon
    End Sub

    Private Sub frmDeXuatMuaHang_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim str As String = ""
        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmpChonPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[tmpChonPT" & Commons.Modules.UserName & "]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub

    Private Sub frmDeXuatMuaHang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        commons.Modules.ObjSystems.DinhDang()
        VisibleButtton(True)
        LoadcboSoDeXuat()
        LoadcboPhongYC()
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(True)
        Else
            EnableButton(False)
        End If
        AddHandler chkDuyet.CheckedChanged, AddressOf Me.chkDuyet_CheckedChanged
        BindData()
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = Not chon
        'BtnXoa.Enabled = Not chon
        BtnSua.Enabled = Not chon
        BtnDuyet.Enabled = Not chon
    End Sub
    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Clear()
        bThem = True
        VisibleButtton(False)
        Try
            grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = False
        Catch ex As Exception

        End Try
        Try
            grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = False
            grdDanhsachvattu.Columns("GHI_CHU").ReadOnly = False
        Catch ex As Exception
        End Try
        txtSoDeXuat.Focus()
    End Sub

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        If grdDanhsachvattu.Rows.Count = 0 Then
            Exit Sub
        End If
        txtSoDeXuat.Text = cbosoDeXuat.Text
        SO_DE_XUAT_CU = cbosoDeXuat.Text
        bThem = False
        VisibleButtton(False)
        Try
            grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = False
            grdDanhsachvattu.Columns("GHI_CHU").ReadOnly = False
        Catch ex As Exception
        End Try
        txtSoDeXuat.Focus()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If KiemTra() Then
            Dim bSoLuong As Integer = -1, j As Integer
            For j = 0 To grdDanhsachvattu.Rows.Count - 1
                If grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value.ToString <> "" Then
                    If grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value = 0 Then
                        bSoLuong = bSoLuong + 1
                    End If
                Else
                    bSoLuong = bSoLuong + 1
                End If
            Next
            Dim Traloi As String
            If grdDanhsachvattu.Rows.Count = 0 Then
                Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChuachonVatTu", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    Exit Sub
                Else
                    GoTo KetThuc
                End If
            ElseIf bSoLuong = grdDanhsachvattu.Rows.Count - 1 Then
                Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChuaNhapSoLuong", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    Exit Sub
                Else
                    GoTo KetThuc
                End If
            ElseIf bSoLuong < grdDanhsachvattu.Rows.Count - 1 And bSoLuong <> -1 Then
                Traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongChuaNhap", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
                If Traloi = vbYes Then
                    grdDanhsachvattu.Focus()
                    Exit Sub
                End If
            End If

            Dim tb As New DataTable()
            tb = grdDanhsachvattu.DataSource
            Dim objDeXuat As New clsDE_XUAT_MUA_HANGInfo()
            objDeXuat.MS_DON_VI = cboPhongYC.SelectedValue
            objDeXuat.NGAY = Format(dtNgay.Value, "Short date")
            objDeXuat.NGUOI_NHAN = txtGiaoCho.Text
            objDeXuat.NGUOI_DUYET = txtNguoiDuyet.Text
            objDeXuat.NGAY_GIAO = IIf(txtNgayGiao.Text = "" Or txtNgayGiao.Text = "  /  /", "", txtNgayGiao.Text)
            objDeXuat.SO_DE_XUAT = txtSoDeXuat.Text.Trim
            If Not bThem Then
                objDeXuat.SO_DE_XUAT_CU = SO_DE_XUAT_CU
            End If
            Dim tmp As String = New clsDE_XUAT_MUA_HANGControler().AddDE_XUAT_MUA_HANG(objDeXuat, tb)

            If tmp = "" Then
                'XtraMessageBox.Show("thực hiện lưu không thành công")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgLuuKhongThanhCong", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            chkDuyet.Checked = False
            LoadcboSoDeXuat()
            cbosoDeXuat.SelectedValue = tmp
KetThuc:
            bThem = False
            VisibleButtton(True)
            BindData()
        End If
    End Sub
    Function KiemTra() As Boolean
        If Not txtSoDeXuat.IsValidated Then
            txtSoDeXuat.Focus()
            Return False
        End If
        If Not cboPhongYC.IsValidated Or cboPhongYC.SelectedValue Is Nothing Then
            cboPhongYC.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        ErrorProvider1.Clear()
        bThem = False
        VisibleButtton(True)
        BindData()
    End Sub

    Private Sub txtNgayGiao_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNgayGiao.Validating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If txtNgayGiao.Text <> "" And txtNgayGiao.Text <> "  /  /" Then
            If Not IsDate(txtNgayGiao.Text) Then
                'XtraMessageBox.Show("ngày giao nhập không hợp lệ")
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNgayGiaoErr", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtNgayGiao.Focus()
                e.Cancel = True
            Else
                If Date.Parse(Format(dtNgay.Value, "Short date")) > Date.Parse(txtNgayGiao.Text) Then
                    'XtraMessageBox.Show("NGÀY giao phải lớn hơn ngày lập")
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNgayGiaoNhoHonNgayLap", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                End If
            End If
        End If
    End Sub


    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If grdDanhsachvattu.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoa", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim RowCount As Integer = grdDanhsachvattu.Rows.Count
            Dim tmp As Integer = intRow
            Dim objDeXuat As New clsDE_XUAT_MUA_HANGControler()
            objDeXuat.DeleteDE_XUAT_MUA_HANG_CHI_TIET(cbosoDeXuat.SelectedValue, grdDanhsachvattu.Rows(intRow).Cells("MS_PT").Value)
            If RowCount = 1 Then
                objDeXuat.DeleteDE_XUAT_MUA_HANG(cbosoDeXuat.SelectedValue)
                LoadcboSoDeXuat()
            End If
            BindData()
            If RowCount > 1 Then
                If tmp = grdDanhsachvattu.Rows.Count Then
                    grdDanhsachvattu.CurrentCell() = grdDanhsachvattu.Rows(tmp - 1).Cells("MS_PT")
                    grdDanhsachvattu.Focus()
                    Exit Sub
                ElseIf tmp < grdDanhsachvattu.Rows.Count Then
                    grdDanhsachvattu.CurrentCell() = grdDanhsachvattu.Rows(tmp).Cells("MS_PT")
                    grdDanhsachvattu.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Dim txtSoLuong As TextBox
    Sub HandleKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub grdDanhsachvattu_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDanhsachvattu.EditingControlShowing
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
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
    End Sub

    Private Sub grdDanhsachvattu_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachvattu.RowEnter
        If e.RowIndex >= 0 Then
            intRow = e.RowIndex
        End If
    End Sub
    Sub ShowrptDonDatHang()
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptDE_XUAT_MUA_HANG", cbosoDeXuat.SelectedValue)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "Select count(*)as TONG from rptDE_XUAT_MUA_HANG")
        While objReader.Read
            If objReader.Item("TONG") = 0 Then
                objReader.Close()
                GoTo KetThuc
            End If
        End While
        objReader.Close()
        Commons.mdShowReport.ReportPreview("reports/rptDeXuatMuaHang.rpt")
KetThuc:
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rptDE_XUAT_MUA_HANG]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[rptDE_XUAT_MUA_HANG] ")
    End Sub
    Private Sub BtnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIn.Click
        If grdDanhsachvattu.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        ShowrptDonDatHang()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnDuyet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDuyet.Click
        If cbosoDeXuat.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME='" & Commons.Modules.UserName & "' AND STT=2")
        While objReader.Read
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE DE_XUAT_MUA_HANG SET DUYET=1 WHERE SO_DE_XUAT='" & cbosoDeXuat.SelectedValue & "'")
            objReader.Close()
            LoadcboSoDeXuat()
            BindData()
            Exit Sub
        End While
        objReader.Close()
        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgKhongCoQuyenDuyet", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
    End Sub

    Private Sub chkDuyet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles chkDuyet.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        LoadcboSoDeXuat()
        'If chkDuyet.Checked Then
        '    EnableButton(True)
        'Else
        '    EnableButton(False)
        'End If
        BindData()
        Me.Cursor = Cursors.Default
    End Sub

  
    Private Sub cbosoDeXuat_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbosoDeXuat.SelectionChangeCommitted
        BindData()
    End Sub

    Private Sub cbosoDeXuat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbosoDeXuat.Validating
        If Not BtnGhi.Visible Then
            BindData()
        End If
    End Sub

    Private Sub txtSoDeXuat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoDeXuat.Validated
        txtSoDeXuat.Text = Commons.clsXuLy.LocBoDau(txtSoDeXuat.Text)
    End Sub
End Class