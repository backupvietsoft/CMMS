
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmCongViecHangNgay
    Dim TBNhanVien As New DataTable()
    Dim TBVatTu As New DataTable()
    Dim TBThietBi As New DataTable()
    Private MS_PHIEU_CV As Integer = -1
    Dim txtBaoTri As TextBox

    Private vEvent As String = ""

    Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub

    Private Sub frmCongViecHangNgay_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        
        Commons.Modules.ObjSystems.XoaTable("CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName)

        Try
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, _
                            "drop PROC InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub frmCongViecHangNgay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Ghi()
            End If
        End If
    End Sub
    Private Sub frmCongViecHangNgay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        If Commons.Modules.PermisString.Equals("Read only") Then
            VisibleButton(True)
            VisibleButtonGhi(False)
            EnableControl(True)
            Dim str As String = ""
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MAX(NGAY_TH) AS NGAY_TH FROM CONG_VIEC_HANG_NGAY")
            While objReader.Read
                If Not IsDBNull(objReader.Item("NGAY_TH")) Then
                    dtNgay.Value = objReader.Item("NGAY_TH")
                End If
            End While
            objReader.Close()
            LoadcboLan(Format(dtNgay.Value, "Short date"))
            If Not cboLan.SelectedValue Is Nothing Then
                BindData(cboLan.SelectedValue)
            End If
            BtnThem.Focus()
            EnableControlAll(False)
        Else
            VisibleButton(True)
            VisibleButtonGhi(False)
            EnableControl(True)
            EnableControlAll(True)
            Dim str As String = ""
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MAX(NGAY_TH) AS NGAY_TH FROM CONG_VIEC_HANG_NGAY")
            While objReader.Read
                If Not IsDBNull(objReader.Item("NGAY_TH")) Then
                    dtNgay.Value = objReader.Item("NGAY_TH")
                End If
            End While
            objReader.Close()
            LoadcboLan(Format(dtNgay.Value, "Short date"))
            If Not cboLan.SelectedValue Is Nothing Then
                BindData(cboLan.SelectedValue)
            End If
            BtnThem.Focus()
        End If

    End Sub
    Sub EnableControlAll(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnSua.Enabled = chon
        BtnXoa.Enabled = chon
    End Sub
    Sub VisibleButton(ByVal chon As Boolean)
        BtnThem.Visible = chon
        BtnXoa.Visible = chon
        BtnSua.Visible = chon
        BtnThoat.Visible = chon
        BtnXemPBVT.Visible = False
    End Sub
    Sub VisibleButtonGhi(ByVal chon As Boolean)
        BtnGhi.Visible = chon
        BtnKhongghi.Visible = chon
        BtnNVBD.Visible = chon
        BtnVTBD.Visible = chon
        BtnTBBD.Visible = chon
        BtnPBdenNC.Visible = chon
        BtnPBdeuCPVT.Visible = chon
        BtnPBVT.Visible = False
        lblSTT_CV.Visible = Not chon
        cboLan.Visible = Not chon
        rtxtNoidung.ReadOnly = Not chon
    End Sub
    Sub EnableControl(ByVal chon As Boolean)
        dtNgay.Enabled = chon
        grdDanhsachthietbi.ReadOnly = chon
        grdDanhsachvattu.ReadOnly = chon
        grdNhanvien.ReadOnly = chon
    End Sub
    Sub BindData(ByVal STT_CV As Integer)
        grdPhanBoVatTu.Columns.Clear()
        Dim str As String = ""
        str = "SELECT * from CONG_VIEC_HANG_NGAY WHERE NGAY_TH=CONVERT(DATETIME,'" & Format(dtNgay.Value, "Short date") & "',103) and STT_CV=" & STT_CV
        '" AND USERNAME='" & Commons.Modules.UserName &
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While objReader.Read
            rtxtNoidung.Text = objReader.Item("GHI_CHU").ToString
        End While
        objReader.Close()
        TBNhanVien = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCONG_VIEC_HANG_NGAY_NV", STT_CV).Tables(0)
        grdNhanvien.DataSource = TBNhanVien
        TBThietBi = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCONG_VIEC_HANG_NGAY_THIET_BI", STT_CV).Tables(0)
        grdDanhsachthietbi.DataSource = TBThietBi
        'H_CONG_VIEC_HANG_NGAY_LOAD_VT
        'TBVatTu = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCONG_VIEC_HANG_NGAY_VT", STT_CV, 0).Tables(0) 'commons.Modules.TypeLanguage
        'grdDanhsachvattu.DataSource = TBVatTu
        TBVatTu = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "H_CONG_VIEC_HANG_NGAY_LOAD_VT", STT_CV).Tables(0) 'commons.Modules.TypeLanguage
        grdDanhsachvattu.DataSource = TBVatTu

        grdNhanvien.Columns("STT_CV").Visible = False
        grdNhanvien.Columns("MS_CONG_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_CONG_NHAN", commons.Modules.TypeLanguage)
        grdNhanvien.Columns("MS_CONG_NHAN").Width = 80
        grdNhanvien.Columns("HO_TEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "HO_TEN", commons.Modules.TypeLanguage)
        grdNhanvien.Columns("HO_TEN").Width = 196
        grdNhanvien.Columns("SO_GIO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_GIO", commons.Modules.TypeLanguage)
        grdNhanvien.Columns("SO_GIO").Width = 70
        If Commons.Modules.iPhutGioPBT = 1 Then
            grdNhanvien.Columns("SO_GIO").DefaultCellStyle.Format = "###,###,###"
        Else
            grdNhanvien.Columns("SO_GIO").DefaultCellStyle.Format = "###,###,##0.00"
        End If
        grdNhanvien.Columns("SO_GIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdNhanvien.Columns("SO_GIO").DefaultCellStyle.BackColor = Color.LightGray
        grdNhanvien.Columns("LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LUONG", commons.Modules.TypeLanguage)
        grdNhanvien.Columns("LUONG").Width = 70
        grdNhanvien.Columns("LUONG").DefaultCellStyle.Format = "###,###,##0.00"
        grdNhanvien.Columns("LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdNhanvien.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANH_TIEN", commons.Modules.TypeLanguage)
        grdNhanvien.Columns("THANH_TIEN").Width = 80
        grdNhanvien.Columns("THANH_TIEN").MinimumWidth = 80
        grdNhanvien.Columns("THANH_TIEN").DefaultCellStyle.Format = "###,###,##0.00"
        grdNhanvien.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdNhanvien.Columns("THANH_TIEN").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Try
            Me.grdNhanvien.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdNhanvien.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

        grdDanhsachthietbi.Columns("STT_CV").Visible = False
        grdDanhsachthietbi.Columns("MS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_MAY", commons.Modules.TypeLanguage)
        grdDanhsachthietbi.Columns("MS_MAY").Width = 90
        grdDanhsachthietbi.Columns("NOI_DUNG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NOI_DUNG", commons.Modules.TypeLanguage)
        grdDanhsachthietbi.Columns("NOI_DUNG").Width = 150
        grdDanhsachthietbi.Columns("NOI_DUNG").DefaultCellStyle.NullValue = ""

        grdDanhsachthietbi.Columns("CHI_PHI_NC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHI_PHI_NC", commons.Modules.TypeLanguage)
        grdDanhsachthietbi.Columns("CHI_PHI_NC").Width = 70
        grdDanhsachthietbi.Columns("CHI_PHI_NC").DefaultCellStyle.BackColor = Color.LightGray
        grdDanhsachthietbi.Columns("CHI_PHI_NC").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachthietbi.Columns("CHI_PHI_NC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        grdDanhsachthietbi.Columns("CHI_PHI_VT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHI_PHI_VT", commons.Modules.TypeLanguage)
        grdDanhsachthietbi.Columns("CHI_PHI_VT").Width = 70
        grdDanhsachthietbi.Columns("CHI_PHI_VT").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachthietbi.Columns("CHI_PHI_VT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachthietbi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Try
            Me.grdDanhsachthietbi.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachthietbi.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

        grdDanhsachvattu.Columns("STT_CV").Visible = False

        grdDanhsachvattu.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("MS_PT").Width = 100
        grdDanhsachvattu.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("TEN_PT").Width = 176

        grdDanhsachvattu.Columns("MS_DH_XUAT_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_DH_XUAT_PT", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("MS_DH_XUAT_PT").Width = 70
        'grdDanhsachvattu.Columns("MS_DH_XUAT_PT").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachvattu.Columns("MS_DH_XUAT_PT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdDanhsachvattu.Columns("MS_DH_NHAP_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("MS_DH_NHAP_PT").Width = 70
        'grdDanhsachvattu.Columns("MS_DH_NHAP_PT").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachvattu.Columns("MS_DH_NHAP_PT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        grdDanhsachvattu.Columns("SO_LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_LUONG", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("SO_LUONG").Width = 70
        grdDanhsachvattu.Columns("SO_LUONG").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachvattu.Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdDanhsachvattu.Columns("DON_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DON_GIA", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("DON_GIA").Width = 70
        grdDanhsachvattu.Columns("DON_GIA").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachvattu.Columns("DON_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        grdDanhsachvattu.Columns("NGOAI_TE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGOAI_TE", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("NGOAI_TE").Width = 70
        grdDanhsachvattu.Columns("NGOAI_TE").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachvattu.Columns("NGOAI_TE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        grdDanhsachvattu.Columns("TY_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TY_GIA", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("TY_GIA").Width = 70
        grdDanhsachvattu.Columns("TY_GIA").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachvattu.Columns("TY_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        grdDanhsachvattu.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THANH_TIEN", commons.Modules.TypeLanguage)
        grdDanhsachvattu.Columns("THANH_TIEN").Width = 80
        grdDanhsachvattu.Columns("THANH_TIEN").MinimumWidth = 80
        grdDanhsachvattu.Columns("THANH_TIEN").DefaultCellStyle.Format = "###,###,##0.00"
        grdDanhsachvattu.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdDanhsachvattu.Columns("THANH_TIEN").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdDanhsachvattu.Columns("DVT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DVT", commons.Modules.TypeLanguage)

        grdDanhsachvattu.Columns("DVT").Width = 60
        grdDanhsachvattu.Columns("DON_GIA").DefaultCellStyle.BackColor = Color.LightGray
        grdDanhsachvattu.Columns("SO_LUONG").DefaultCellStyle.BackColor = Color.LightGray
        Try
            Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

        txtTongCPNC.Text = Format(TongCPNC(), "###,###,##0.00")
        txtTongCPVT.Text = Format(TongCPVT(), "###,###,##0.00")
        txtTongCPNV1.Text = Format(TongCPNC1(), "###,###,##0.00")
        txtTongCPVT1.Text = Format(TongCPVT1(), "###,###,##0.00")
    End Sub
    Function TongCPNC() As Double
        Dim tmp As Double = 0
        For i As Integer = 0 To grdNhanvien.Rows.Count - 1
            If grdNhanvien.Rows(i).Cells("THANH_TIEN").Value.ToString <> "" Then
                tmp += grdNhanvien.Rows(i).Cells("THANH_TIEN").Value
            End If
        Next
        Return Math.Round(tmp, 2)
    End Function
    Function TongCPNC1() As Double
        Dim tmp As Double = 0
        For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
            If grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_NC").Value.ToString <> "" Then
                tmp += grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_NC").Value
            End If
        Next
        Return Math.Round(tmp, 2)
    End Function
    Function TongCPVT() As Double
        Dim tmp As Double = 0
        For i As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
            If grdDanhsachvattu.Rows(i).Cells("THANH_TIEN").Value.ToString <> "" Then
                tmp += grdDanhsachvattu.Rows(i).Cells("THANH_TIEN").Value
            End If
        Next
        Return Math.Round(tmp, 2)
    End Function
    Function TongCPCT(ByVal MS_MAY As String) As Double
        Dim tmp As Double = 0
        Dim str As String = ""
        If BtnGhi.Visible Then
            str = "SELECT SUM(ISNULL(THANH_TIEN,0))AS THANH_TIEN FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE MS_MAY='" & MS_MAY & "'"
        Else
            str = "SELECT SUM(THANH_TIEN) AS THANH_TIEN FROM CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT WHERE STT_CV=" & cboLan.SelectedValue & " AND MS_MAY='" & MS_MAY & "'"
        End If
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While objReader.Read
            If objReader.Item("THANH_TIEN").ToString <> "" Then
                tmp = objReader.Item("THANH_TIEN")
                objReader.Close()
                Return tmp
            End If
        End While
        objReader.Close()
        Return Math.Round(tmp, 2)
    End Function
    Function TongCPVT1() As Double
        grdDanhsachthietbi.EndEdit()
        Dim tmp As Double = 0
        For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
            If grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value.ToString <> "" Then
                tmp += grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value
            End If
        Next
        Return Math.Round(tmp, 2)
    End Function
    Private bChon As Boolean = True
    Private Sub BtnPBVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPBVT.Click
        If grdDanhsachthietbi.Rows.Count = 0 Then
            'XtraMessageBox.Show("chọn thiết bị bảo trì trước khi phân bổ chi tiết")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgChuaChonThietBi", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If txtTongCPNC.Text <> txtTongCPNV1.Text Or txtTongCPVT.Text <> txtTongCPVT1.Text Then
            'XtraMessageBox.Show("phân bổ chưa đều")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgPhanBoKhongDeuThietBi", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim str As String = ""
        If bChon Then
            Try
                str = "drop table CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "CREATE TABLE dbo.CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & _
                        "(MS_MAY NVARCHAR(30),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(150), MS_DH_XUAT_PT NVARCHAR(30), MS_DH_NHAP_PT NVARCHAR(30), " & _
                        " SO_LUONG FLOAT,DVT NVARCHAR(30),DON_GIA FLOAT,THANH_TIEN FLOAT,ID INT)"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            Try
                str = "drop PROC InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "CREATE PROC [DBO].[InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "]" & _
                " @MS_MAY  NVARCHAR(30),@MS_PT  NVARCHAR(25), @TEN_PT  NVARCHAR(255), MS_DH_XUAT_PT NVARCHAR(30), MS_DH_NHAP_PT NVARCHAR(30),  " & _
                " @SO_LUONG FLOAT,@DVT NVARCHAR(50),@DON_GIA FLOAT,@THANH_TIEN FLOAT,@TY_GIA FLOAT,@ID INT " & _
                " AS INSERT INTO CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_PT,TEN_PT,  " & _
                " SO_LUONG,DVT,DON_GIA,THANH_TIEN,TY_GIA,ID ) " & _
                " VALUES( @MS_MAY,@MS_PT,@TEN_PT,@MS_DH_XUAT_PT,@MS_DH_NHAP_PT,@SO_LUONG,@DVT,@DON_GIA,@THANH_TIEN,@TY_GIA,@ID)"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
                For j As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
                    If Not IsDBNull(grdDanhsachvattu.Rows(j).Cells("THANH_TIEN").Value) Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName, grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value, _
                        grdDanhsachvattu.Rows(j).Cells("MS_PT").Value, grdDanhsachvattu.Rows(j).Cells("TEN_PT").Value, grdDanhsachvattu.Rows(j).Cells("MS_DH_XUAT_PT").Value, grdDanhsachvattu.Rows(j).Cells("MS_DH_NHAP_PT").Value, Nothing, grdDanhsachvattu.Rows(j).Cells("DVT").Value, grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value, Nothing, grdDanhsachvattu.Rows(j).Cells("TY_GIA").Value)
                    Else
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName, grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value, _
                                           grdDanhsachvattu.Rows(j).Cells("MS_PT").Value, grdDanhsachvattu.Rows(j).Cells("TEN_PT").Value, grdDanhsachvattu.Rows(j).Cells("MS_DH_XUAT_PT").Value, grdDanhsachvattu.Rows(j).Cells("MS_DH_NHAP_PT").Value, Nothing, grdDanhsachvattu.Rows(j).Cells("DVT").Value, Nothing, Nothing, Nothing)
                    End If
                Next
            Next
        End If
        Dim frm As New frmCongViecHangNgayTBCTVT()
        Dim k As Integer = 0
        Dim tb As New DataTable()
        tb = TBThietBi.Clone()
        For i As Integer = 0 To TBThietBi.Rows.Count - 1
            If IsDBNull(TBThietBi.Rows(i).Item("CHI_PHI_VT")) Then
                str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET THANH_TIEN=NULL WHERE MS_MAY='" & TBThietBi.Rows(i).Item("MS_MAY") & "' "
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Else
                Dim dr As DataRow
                dr = tb.NewRow
                dr.Item("STT_CV") = TBThietBi.Rows(i).Item("STT_CV")
                dr.Item("MS_MAY") = TBThietBi.Rows(i).Item("MS_MAY")
                dr.Item("NOI_DUNG") = TBThietBi.Rows(i).Item("NOI_DUNG")
                dr.Item("CHI_PHI_NC") = TBThietBi.Rows(i).Item("CHI_PHI_NC")
                dr.Item("CHI_PHI_VT") = TBThietBi.Rows(i).Item("CHI_PHI_VT")
                tb.Rows.Add(dr)
            End If
        Next
        frm.TBThietBi = tb
        frm.TBVatTu = TBVatTu
        frm.BXem = True
        frm.ShowDialog()

    End Sub
    Sub LoadcboLan(ByVal NGAY As String)
        cboLan.Display = "STT"
        cboLan.Value = "STT_CV"
        cboLan.StoreName = "QL_SEARCH"
        cboLan.Param = "SELECT STT_CV,STT FROM CONG_VIEC_HANG_NGAY WHERE NGAY_TH=CONVERT(DATETIME,'" & NGAY & "',103) ORDER BY STT_CV desc"
        cboLan.BindDataSource()
    End Sub
    Private Sub dtNgay_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtNgay.CloseUp
        cboLan.Text = ""
        LoadcboLan(Format(dtNgay.Value, "Short date"))
        If cboLan.SelectedValue Is Nothing Then
            BindData(0)
        Else
            BindData(cboLan.SelectedValue)
        End If
    End Sub

    Private Sub cboLan_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLan.SelectionChangeCommitted
        If cboLan.SelectedValue Is Nothing Then
            BindData(0)
        Else
            BindData(cboLan.SelectedValue)
        End If
    End Sub

    Private Sub BtnNVBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNVBD.Click
        Dim frm As New frmChonNhanvienbaoduong()
        frm.TBCongNhan = TBNhanVien
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            'TBNhanVien = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCONG_VIEC_HANG_NGAY_NV", 0).Tables(0)
            Dim tmp As Double = 0
            For i As Integer = 0 To frm.TBCongNhan.Rows.Count - 1
                If Not frm.TBCongNhan.Rows(i)("SO_GIO") Is Nothing Then
                    If frm.TBCongNhan.Rows(i)("LUONG").ToString <> "" Then
                        Dim SoGio As Double = frm.TBCongNhan.Rows(i)("SO_GIO")

                        If Commons.Modules.iPhutGioPBT = 1 Then
                            SoGio = SoGio / 60
                            grdNhanvien.Columns("SO_GIO").DefaultCellStyle.Format = "###,###,###"
                        Else
                            grdNhanvien.Columns("SO_GIO").DefaultCellStyle.Format = "###,###,##0.00"
                        End If


                        frm.TBCongNhan.Rows(i)("THANH_TIEN") = Math.Round(SoGio * frm.TBCongNhan.Rows(i)("LUONG") / (26 * 8), 0)
                        tmp = tmp + frm.TBCongNhan.Rows(i)("THANH_TIEN")
                    Else
                        frm.TBCongNhan.Rows(i)("THANH_TIEN") = System.DBNull.Value
                    End If
                End If
            Next
            'grdNhanvien.DataSource = TBNhanVien
            TBNhanVien = frm.TBCongNhan
            grdNhanvien.DataSource = TBNhanVien
            txtTongCPNC.Text = Format(tmp, "###,###,##0.00")

        End If
    End Sub

    Private Sub BtnVTBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVTBD.Click

        Dim frm As New FrmChonVTCongViecHangNgay()

        frm.vEvents = vEvent
        frm.vSttCV = cboLan.SelectedValue
        frm.ShowDialog()

        If frm.vEvents = "OK" Then

            Dim vtb As New DataTable
            vtb = frm.vChiTietVT
            TBVatTu.Rows.Clear()
            For Each vrow As DataRow In vtb.Rows
                Dim vtt As Double = 0
                Try
                    vtt = vrow("SO_LUONG_XUAT") * vrow("DON_GIA") * vrow("TY_GIA")
                Catch ex As Exception
                End Try

                If vrow("SO_LUONG_XUAT").ToString <> "0" And vrow("SO_LUONG_XUAT").ToString <> "" Then
                    TBVatTu.Rows.Add(0, vrow("MS_PT"), vrow("TEN_PT"), vrow("MS_DH_XUAT_PT"), vrow("MS_DH_NHAP_PT"), vrow("SO_LUONG_XUAT"), vrow("DVT"), vrow("DON_GIA"), vrow("NGOAI_TE"), vrow("TY_GIA"), vtt, vrow("IDCT"))
                End If
            Next






        End If



        ''Dim frm As New frmChonvattubaoduong
        ''frm.TBVattu = TBVatTu

        ''frm.STT_CV = cboLan.SelectedValue
        ''If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
        ''    'TBVatTu = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetCONG_VIEC_HANG_NGAY_VT", 0, 0).Tables(0)
        Dim tmp As Double = 0

        For i As Integer = 0 To TBVatTu.Rows.Count - 1
            If Not TBVatTu.Rows(i).IsNull("SO_LUONG") Then
                If TBVatTu.Rows(i).IsNull("DON_GIA") Then
                    TBVatTu.Rows(i)("DON_GIA") = System.DBNull.Value
                    TBVatTu.Rows(i)("THANH_TIEN") = System.DBNull.Value
                Else
                    If Not TBVatTu.Rows(i).IsNull("DON_GIA") Then
                        TBVatTu.Rows(i)("DON_GIA") = Math.Round(Double.Parse(TBVatTu.Rows(i)("DON_GIA")), 1)
                        TBVatTu.Rows(i)("THANH_TIEN") = TBVatTu.Rows(i)("DON_GIA") * TBVatTu.Rows(i)("SO_LUONG") * TBVatTu.Rows(i)("TY_GIA")
                        tmp += TBVatTu.Rows(i)("THANH_TIEN")
                    End If
                End If
            End If
            grdDanhsachvattu.DataSource = TBVatTu
            txtTongCPVT.Text = Format(tmp, "###,###,##0.00")
        Next

        If grdDanhsachthietbi.Rows.Count > 0 Then
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM  CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName)
            For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
                For j As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
                    If Not IsDBNull(grdDanhsachvattu.Rows(j).Cells("THANH_TIEN").Value) Then
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName, grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value, _
                        grdDanhsachvattu.Rows(j).Cells("MS_PT").Value, grdDanhsachvattu.Rows(j).Cells("TEN_PT").Value, _
                        grdDanhsachvattu.Rows(j).Cells("MS_DH_XUAT_PT").Value, grdDanhsachvattu.Rows(j).Cells("MS_DH_NHAP_PT").Value, Nothing, _
                        grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value, Nothing, grdDanhsachvattu.Rows(j).Cells("TY_GIA").Value, _
                        grdDanhsachvattu.Rows(j).Cells("ID").Value)
                    Else
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName, grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value, _
                                           grdDanhsachvattu.Rows(j).Cells("MS_PT").Value, grdDanhsachvattu.Rows(j).Cells("TEN_PT").Value, _
                                           Nothing, Nothing, Nothing, Nothing, Nothing, grdDanhsachvattu.Rows(j).Cells("ID").Value)
                    End If
                Next
            Next
            BindDataChiTiet(0)
        End If
    End Sub

    Private Sub grdDanhsachvattu_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachvattu.CellValidated
        If BtnGhi.Visible Then
        End If
    End Sub

    Private Sub grdDanhsachvattu_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhsachvattu.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If grdDanhsachvattu.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                        'XtraMessageBox.Show("gia1 tri khong hop le")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue < 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    Else
                        If grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value.ToString <> "" Then
                            grdDanhsachvattu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = Math.Round(grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value * e.FormattedValue, 2)
                        End If
                    End If
                Else
                    grdDanhsachvattu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = System.DBNull.Value
                End If
                txtTongCPVT.Text = Format(TongCPVT(), "###,###,##0.00")
            ElseIf grdDanhsachvattu.Columns(e.ColumnIndex).Name = "DON_GIA" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                        'XtraMessageBox.Show("gia1 tri khong hop le")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDonGiaLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue < 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        grdDanhsachvattu.Rows(e.RowIndex).ErrorText = "Error"
                        'XtraMessageBox.Show("gia1 tri khong hop le")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgDonGiaLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    Else
                        If grdDanhsachvattu.Rows(e.RowIndex).Cells("SO_LUONG").Value.ToString <> "" Then
                            grdDanhsachvattu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = Math.Round(grdDanhsachvattu.Rows(e.RowIndex).Cells("SO_LUONG").Value * e.FormattedValue, 2)
                        End If
                    End If
                Else
                    grdDanhsachvattu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = System.DBNull.Value
                End If
                txtTongCPVT.Text = Format(TongCPVT(), "###,###,##0.00")
            End If
            grdDanhsachvattu.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub

    Private Sub BtnTBBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTBBD.Click
        Dim frm As New frmChonThietBiBaoDuong
        frm.TBThietBi = TBThietBi
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            TBThietBi = frm.TBThietBi
            grdDanhsachthietbi.DataSource = TBThietBi

            txtTongCPNV1.Text = Format(TongCPNC1(), "###,###,##0.00")
            txtTongCPVT1.Text = Format(TongCPVT1(), "###,###,##0.00")
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "DELETE FROM  CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName)
            For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
                For j As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
                    If Not IsDBNull(grdDanhsachvattu.Rows(j).Cells("THANH_TIEN").Value) Then
                        Dim tt As String = grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName, _
                        grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value, _
                        grdDanhsachvattu.Rows(j).Cells("MS_PT").Value, _
                        grdDanhsachvattu.Rows(j).Cells("TEN_PT").Value, _
                        grdDanhsachvattu.Rows(j).Cells("MS_DH_XUAT_PT").Value, _
                         grdDanhsachvattu.Rows(j).Cells("MS_DH_NHAP_PT").Value, _
                        DBNull.Value, _
                        grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value, _
                        DBNull.Value, _
                        grdDanhsachvattu.Rows(j).Cells("TY_GIA").Value, _
                        grdDanhsachvattu.Rows(j).Cells("ID").Value)

                    Else
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName, grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value, _
                                           grdDanhsachvattu.Rows(j).Cells("MS_PT").Value, grdDanhsachvattu.Rows(j).Cells("TEN_PT").Value, Nothing, Nothing, Nothing, Nothing, grdDanhsachvattu.Rows(j).Cells("ID").Value)
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub grdDanhsachthietbi_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachthietbi.CellValidated
        txtTongCPNV1.Text = Format(TongCPNC1(), "###,###,##0.00")
        txtTongCPVT1.Text = Format(TongCPVT1(), "###,###,##0.00")
    End Sub

    Private Sub grdDanhsachthietbi_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdDanhsachthietbi.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If grdDanhsachthietbi.Columns(e.ColumnIndex).Name = "CHI_PHI_NC" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        grdDanhsachthietbi.Rows(e.RowIndex).ErrorText = "Error"
                        'XtraMessageBox.Show("gia1 tri khong hop le")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCPNCLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue < 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "-0" Then
                        grdDanhsachthietbi.Rows(e.RowIndex).ErrorText = "Error"
                        'XtraMessageBox.Show("gia1 tri khong hop le")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCPNCLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                txtTongCPNV1.Text = Format(TongCPNC1(), "###,###,##0.00")
            ElseIf grdDanhsachthietbi.Columns(e.ColumnIndex).Name = "CHI_PHI_VT" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        grdDanhsachthietbi.Rows(e.RowIndex).ErrorText = "Error"
                        'XtraMessageBox.Show("gia1 tri khong hop le")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCPVTLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue < 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                        grdDanhsachthietbi.Rows(e.RowIndex).ErrorText = "Error"
                        'XtraMessageBox.Show("gia1 tri khong hop le")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgCPVTLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    Dim str As String = ""
                    str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=NULL , THANH_TIEN=NULL WHERE MS_MAY ='" & grdDanhsachthietbi.Rows(e.RowIndex).Cells("MS_MAY").Value & "'"
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
                txtTongCPVT1.Text = Format(TongCPVT1(), "###,###,##0.00")
            End If
            grdDanhsachthietbi.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub

    Private Sub BtnPBdenNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPBdenNC.Click
        If txtTongCPNC.Text = "0" Or txtTongCPNC.Text = "" Then
            Exit Sub
        End If
        If grdDanhsachthietbi.Rows.Count = 0 Then
            'XtraMessageBox.Show("chọn thiết bị bảo trì trước khi phân bổ nhân công")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonThietBi", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        PhanBoDeuNC()
        txtTongCPNV1.Text = txtTongCPNC.Text
    End Sub

    Sub PhanBoDeuNC()
        Dim tmp As Double = 0
        tmp = Double.Parse(txtTongCPNC.Text) / grdDanhsachthietbi.Rows.Count
        For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
            grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_NC").Value = tmp
        Next
    End Sub
    Sub PhanBoDeuVT()
        Dim tmp As Double = 0
        tmp = Double.Parse(txtTongCPVT.Text) / grdDanhsachthietbi.Rows.Count
        For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
            grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value = tmp
        Next
    End Sub
    Sub PhanBoChiTietVT()
        Dim str As String = ""
        Dim TongTB As Integer = grdDanhsachthietbi.Rows.Count
        For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
            For j As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
                If Not IsDBNull(grdDanhsachvattu.Rows(j).Cells("THANH_TIEN").Value) Then
                    If Not grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value Is Nothing And Not grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value Is Nothing And Not grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value.ToString().Trim().Equals("") And Not grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value.ToString().Trim().Equals("") Then
                        str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=" & grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value / TongTB & ",DON_GIA=" & grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value & _
                                    ",THANH_TIEN=" & grdDanhsachvattu.Rows(j).Cells("DON_GIA").Value * grdDanhsachvattu.Rows(j).Cells("SO_LUONG").Value * grdDanhsachvattu.Rows(j).Cells("TY_GIA").Value / TongTB & _
                                    " WHERE MS_MAY= '" & grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value & "' " & _
                                    " AND MS_PT='" & grdDanhsachvattu.Rows(j).Cells("MS_PT").Value & "' " & _
                                    " AND ID= " & grdDanhsachvattu.Rows(j).Cells("ID").Value & " " & _
                                    " AND MS_DH_XUAT_PT ='" & grdDanhsachvattu.Rows(j).Cells("MS_DH_XUAT_PT").Value & "' " & _
                                    " AND MS_DH_NHAP_PT ='" & grdDanhsachvattu.Rows(j).Cells("MS_DH_NHAP_PT").Value & "'"
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub BtnPBdeuCPVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPBdeuCPVT.Click
        If txtTongCPVT.Text = "0" Or txtTongCPVT.Text = "" Then
            Exit Sub
        End If
        If grdDanhsachthietbi.Rows.Count = 0 Then
            'XtraMessageBox.Show("chọn thiết bị bảo trì trước khi phân bổ vật tư")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonThietBi", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        PhanBoDeuVT()
        PhanBoChiTietVT()
        txtTongCPVT1.Text = txtTongCPVT.Text
        BindDataChiTiet(0)
    End Sub

    Private Sub BtnXemPBVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXemPBVT.Click
        If grdDanhsachthietbi.Rows.Count > 0 Then
            Dim str As String = ""
            Try
                str = "drop table CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "CREATE TABLE dbo.CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "(MS_MAY NVARCHAR(30),MS_PT NVARCHAR(25), " & _
                    " TEN_PT NVARCHAR(150),SO_LUONG FLOAT,DVT NVARCHAR(30),DON_GIA FLOAT,THANH_TIEN FLOAT,ID INT)"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            Try
                str = "drop PROC InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "INSERT INTO CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & _
                      " SELECT MS_MAY,IC_PHU_TUNG.MS_PT,TEN_PT,SO_LUONG,CASE " & Commons.Modules.TypeLanguage & _
                      " WHEN 0 THEN TEN_1 WHEN 1 THEN TEN_2 ELSE TEN_3 END AS DVT, DON_GIA,THANH_TIEN,TY_GIA,CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT.ID " & _
                      " FROM CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT INNER JOIN IC_PHU_TUNG ON " & _
                     " CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT.MS_PT=IC_PHU_TUNG.MS_PT LEFT JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT=DON_VI_TINH.DVT WHERE STT_CV=" & cboLan.SelectedValue
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Dim frm As New frmCongViecHangNgayTBCTVT()
            frm.TBThietBi = TBThietBi
            frm.TBVatTu = TBVatTu
            frm.BXem = False
            frm.grdDanhsachvattu.ReadOnly = True
            frm.ShowDialog()
            Try
                str = "DROP TABLE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Try
            MS_PHIEU_CV = cboLan.SelectedValue
        Catch ex As Exception
            MS_PHIEU_CV = -1
        End Try
        Dim str As String = ""

        dtNgay.Value = Format(Now, "short date")
        Try
            str = "drop table [CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "]"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE [CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "] (MS_MAY NVARCHAR(30),MS_PT NVARCHAR(25), " & _
                    " MS_DH_XUAT_PT NVARCHAR(30), MS_DH_NHAP_PT NVARCHAR(30),TEN_PT NVARCHAR(255),SO_LUONG FLOAT,DON_GIA FLOAT,THANH_TIEN FLOAT, " & _
                    " TY_GIA FLOAT,ID INT)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "drop PROC InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE PROC [DBO].[InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "]" & _
                " @MS_MAY  NVARCHAR(30),@MS_PT  NVARCHAR(25), @TEN_PT  NVARCHAR(255),@MS_DH_XUAT_PT NVARCHAR(30), @MS_DH_NHAP_PT NVARCHAR(30),@SO_LUONG FLOAT,@DON_GIA FLOAT,@THANH_TIEN FLOAT,@TY_GIA FLOAT,@ID INT " & _
                " AS INSERT INTO CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_PT,TEN_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA,THANH_TIEN,TY_GIA,ID ) " & _
                " VALUES( @MS_MAY,@MS_PT,@TEN_PT,@MS_DH_XUAT_PT,@MS_DH_NHAP_PT,@SO_LUONG,@DON_GIA,@THANH_TIEN,@TY_GIA,@ID )"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        VisibleButton(False)
        VisibleButtonGhi(True)
        EnableControl(False)
        BThem = True
        vEvent = ""
        BindData(0)
        grdNhanvien.Columns("MS_CONG_NHAN").ReadOnly = True
        grdNhanvien.Columns("HO_TEN").ReadOnly = True
        grdNhanvien.Columns("THANH_TIEN").ReadOnly = True

        grdDanhsachvattu.Columns("MS_PT").ReadOnly = True
        grdDanhsachvattu.Columns("TEN_PT").ReadOnly = True
        grdDanhsachvattu.Columns("DVT").ReadOnly = True
        grdDanhsachvattu.Columns("THANH_TIEN").ReadOnly = True

        grdDanhsachthietbi.Columns("MS_MAY").ReadOnly = True
        rtxtNoidung.Text = ""
        rtxtNoidung.Focus()
        grdNhanvien.AllowUserToDeleteRows = True
        grdDanhsachthietbi.AllowUserToDeleteRows = True
        grdDanhsachvattu.AllowUserToDeleteRows = True
        AddHandler grdPhanBoVatTu.CellValidating, AddressOf Me.grdPhanBoVatTu_CellValidating
    End Sub
    Private BThem As Boolean = False
    Sub Ghi()
        Dim objCongViecHangNgayController As New clsCONG_VIEC_HANG_NGAYController()
        Dim TongNC As Double = TongCPNC()
        Dim TongNC1 As Double = TongCPNC1()
        Dim TongVT As Double = TongCPVT()
        Dim TongVT1 As Double = TongCPVT1()
        Dim TongCT As Double = 0
        Dim str As String = ""
        Try
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, _
                            "SELECT SUM(ISNULL(THANH_TIEN,0))AS THANH_TIEN FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & _
                            " where  DON_GIA IS NOT NULL AND THANH_TIEN IS NOT NULL")
            While objReader.Read
                If Not IsDBNull(objReader.Item("THANH_TIEN")) Then
                    TongCT = Math.Round(objReader.Item("THANH_TIEN"), 2)
                End If
            End While
            objReader.Close()
        Catch ex As Exception
        End Try
        If TongNC <> TongNC1 Or TongVT <> TongVT1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPhanBoKhongDeuThietBi", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        Else
            If TongCT <> TongVT1 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPhanBoKhongDeuThietBiCT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
                If grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value.ToString <> "" Then
                    Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT sum(THANH_TIEN) AS THANH_TIEN FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE  MS_MAY='" & grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value & "'")
                    Dim tmp As Double = 0
                    While objReader.Read
                        If objReader.Item("THANH_TIEN").ToString <> "" Then
                            tmp = Math.Round(objReader.Item("THANH_TIEN"), 2)
                        End If
                    End While
                    objReader.Close()
                    If Math.Round(grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value, 2) <> tmp Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgPhanBoKhongDeuThietBiCT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                End If
            Next
        End If
        Dim stt As Integer = 0
        Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
        objConnection.Open()
        Dim objTrans As SqlTransaction = objConnection.BeginTransaction
        Try
            If BThem Then
                stt = objCongViecHangNgayController.AddCONG_VIEC_HANG_NGAY(Format(dtNgay.Value, "Short date"), rtxtNoidung.Text, Commons.Modules.UserName, objTrans)
                objCongViecHangNgayController.InsertCONG_VIEC_HANG_NGAY(stt, Me.Name, Commons.Modules.UserName, 1, objTrans)
                MS_PHIEU_CV = stt
            Else
                stt = cboLan.SelectedValue
                objCongViecHangNgayController.InsertCONG_VIEC_HANG_NGAY(stt, Me.Name, Commons.Modules.UserName, 2, objTrans)
                objCongViecHangNgayController.UpdateCONG_VIEC_HANG_NGAY(stt, rtxtNoidung.Text, objTrans)
                Dim sql As String
                Dim vtb As New DataTable
                sql = "select STT_CV , MS_MAY , MS_PT  FROM CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT WHERE STT_CV=" & stt
                vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql))
                For Each vr As DataRow In vtb.Rows
                    sql = "exec UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT_LOG '" & stt & "','" & vr("MS_MAY").ToString & "','" & vr("MS_PT").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    SqlHelper.ExecuteScalar(objTrans, CommandType.Text, sql)
                Next
                vtb = New DataTable
                sql = "SELECT STT_CV,MS_MAY FROM CONG_VIEC_HANG_NGAY_THIET_BI  WHERE STT_CV=" & stt
                vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql))
                For Each vr1 As DataRow In vtb.Rows
                    sql = "exec UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_LOG '" & stt & "','" & vr1("MS_MAY").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    SqlHelper.ExecuteScalar(objTrans, CommandType.Text, sql)
                Next

                vtb = New DataTable
                sql = "select STT_CV,MS_PT FROM CONG_VIEC_HANG_NGAY_VT WHERE STT_CV=" & stt
                vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql))
                For Each vr2 As DataRow In vtb.Rows
                    sql = "exec UPDATE_CONG_VIEC_HANG_NGAY_VT_LOG '" & stt & "','" & vr2("MS_PT").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    SqlHelper.ExecuteScalar(objTrans, CommandType.Text, sql)
                Next

                vtb = New DataTable
                sql = "select STT_CV,MS_CONG_NHAN FROM CONG_VIEC_HANG_NGAY_NV WHERE STT_CV=" & stt
                vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql))
                For Each vr3 As DataRow In vtb.Rows
                    sql = "exec UPDATE_CONG_VIEC_HANG_NGAY_NV_LOG '" & stt & "','" & vr3("MS_CONG_NHAN").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',3"
                    SqlHelper.ExecuteScalar(objTrans, CommandType.Text, sql)
                Next
                objCongViecHangNgayController.DeleteCONG_VIEC_HANG_NGAY_CT(stt, objTrans)
            End If
            Dim i As Integer
            For i = 0 To grdNhanvien.Rows.Count - 1
                If Not IsDBNull(grdNhanvien.Rows(i).Cells("SO_GIO").Value) Then 'IsDBNull(grdNhanvien.Rows(i).Cells("THANH_TIEN").Value) 
                    Dim objCongViecHangNgayInfo As New clsCONG_VIEC_HANG_NGAYInfo()
                    objCongViecHangNgayInfo.STT_CV = stt
                    objCongViecHangNgayInfo.MS_CONG_NHAN = grdNhanvien.Rows(i).Cells("MS_CONG_NHAN").Value
                    objCongViecHangNgayInfo.SO_GIO = grdNhanvien.Rows(i).Cells("SO_GIO").Value
                    If grdNhanvien.Rows(i).Cells("LUONG").Value.ToString = "" Then
                        objCongViecHangNgayInfo.LUONG = -1
                        objCongViecHangNgayInfo.THANH_TIEN = -1
                    Else
                        objCongViecHangNgayInfo.LUONG = grdNhanvien.Rows(i).Cells("LUONG").Value
                        objCongViecHangNgayInfo.THANH_TIEN = grdNhanvien.Rows(i).Cells("THANH_TIEN").Value
                    End If
                    objCongViecHangNgayController.AddCONG_VIEC_HANG_NGAY_NV(objCongViecHangNgayInfo, objTrans, Me.Name)

                End If
            Next
            For i = 0 To grdDanhsachvattu.Rows.Count - 1
                If Not IsDBNull(grdDanhsachvattu.Rows(i).Cells("SO_LUONG").Value) Then 'THANH_TIEN

                    Dim objCongViecVT As New clsCONG_VIEC_HANG_NGAY_VTInfo()
                    objCongViecVT.STT_CV = stt
                    objCongViecVT.MS_PT = grdDanhsachvattu.Rows(i).Cells("MS_PT").Value
                    objCongViecVT.SO_LUONG = grdDanhsachvattu.Rows(i).Cells("SO_LUONG").Value
                    objCongViecVT.MS_DH_XUAT = grdDanhsachvattu.Rows(i).Cells("MS_DH_XUAT_PT").Value
                    objCongViecVT.MS_DH_NHAP = grdDanhsachvattu.Rows(i).Cells("MS_DH_NHAP_PT").Value
                    objCongViecVT.ID = grdDanhsachvattu.Rows(i).Cells("ID").Value

                    objCongViecHangNgayController.AddCONG_VIEC_HANG_NGAY_VT(objCongViecVT, objTrans, Me.Name)
                End If
            Next
            For i = 0 To grdDanhsachthietbi.Rows.Count - 1
                Dim objCongViecTB As New clsCONG_VIEC_HANG_NGAY_TBInfo()
                objCongViecTB.STT_CV = stt
                objCongViecTB.MS_MAY = grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value
                objCongViecTB.NOI_DUNG = grdDanhsachthietbi.Rows(i).Cells("NOI_DUNG").Value.ToString
                If IsDBNull(grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_NC").Value) Then
                    objCongViecTB.CHI_PHI_NC = -1
                Else
                    objCongViecTB.CHI_PHI_NC = grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_NC").Value
                End If
                If IsDBNull(grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value) Then
                    objCongViecTB.CHI_PHI_VT = -1
                Else
                    objCongViecTB.CHI_PHI_VT = grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value
                End If
                objCongViecHangNgayController.AddCONG_VIEC_HANG_NGAY_THIET_BI(objCongViecTB, objTrans, Me.Name)
                
                'End If
            Next
            If BThem Or TongCT > 0 Then
                Try
                    Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_MAY FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE THANH_TIEN IS not NULL")
                    Dim bco As Boolean = False
                    While objReader.Read
                        bco = True
                        objReader.Close()
                        Exit While
                    End While
                    objReader.Close()
                    If bco Then
                        str = "INSERT INTO CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT(STT_CV,MS_MAY,MS_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA,THANH_TIEN,ID) " & _
                              " SELECT " & stt & " ,MS_MAY,MS_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA,THANH_TIEN,ID FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE THANH_TIEN IS NOT NULL"
                        SqlHelper.ExecuteScalar(objTrans, CommandType.Text, str)
                        Try
                            Dim vtb As New DataTable
                            Dim sql As String
                            sql = " SELECT " & stt & " ,MS_MAY,MS_PT,isnull(MS_DH_XUAT_PT,'') as MS_DH_XUAT_PT ,isnull(MS_DH_NHAP_PT,'') as MS_DH_NHAP_PT , " & _
                                        " isnull(SO_LUONG,0) as SO_LUONG ,isnull(DON_GIA,0) as DON_GIA ,isnull(THANH_TIEN,0) as THANH_TIEN, ID " & _
                                        " FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE THANH_TIEN IS NOT NULL"
                            vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql))
                            For Each vr As DataRow In vtb.Rows
                                sql = "exec UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT_LOG '" & stt & "','" & vr("MS_MAY").ToString & "','" & vr("MS_PT").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                                SqlHelper.ExecuteScalar(objTrans, CommandType.Text, sql)
                            Next
                        Catch ex As Exception

                        End Try
                    Else
                        PhanBoChiTietVT()

                        str = "INSERT INTO CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT(STT_CV,MS_MAY,MS_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA, " & _
                                " THANH_TIEN,ID) SELECT " & stt & " ,MS_MAY,MS_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA,THANH_TIEN,ID " & _
                                " FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE THANH_TIEN IS NOT NULL"
                        SqlHelper.ExecuteScalar(objTrans, CommandType.Text, str)
                        Try
                            Dim vtb As New DataTable
                            Dim sql As String
                            sql = " SELECT " & stt & " ,MS_MAY,MS_PT,isnull(MS_DH_XUAT_PT,'') as MS_DH_XUAT_PT ,isnull(MS_DH_NHAP_PT,'') as MS_DH_NHAP_PT , " & _
                                        " isnull(SO_LUONG,0) as SO_LUONG ,isnull(DON_GIA,0) as DON_GIA ,isnull(THANH_TIEN,0) as THANH_TIEN, ID " & _
                                        " FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE THANH_TIEN IS NOT NULL"
                            vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql))
                            For Each vr As DataRow In vtb.Rows
                                sql = "exec UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT _LOG '" & stt & "','" & vr("MS_MAY").ToString & "','" & vr("MS_PT").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                                SqlHelper.ExecuteScalar(objTrans, CommandType.Text, sql)
                            Next
                        Catch ex As Exception

                        End Try
                    End If
                Catch ex As Exception
                    PhanBoChiTietVT()
                    str = "INSERT INTO CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT(STT_CV,MS_MAY,MS_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA, " & _
                                " THANH_TIEN,TY_GIA, ID ) SELECT " & stt & " ,MS_MAY,MS_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA, " & _
                                " THANH_TIEN,TY_GIA,ID FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & _
                                " WHERE THANH_TIEN IS NOT NULL"
                    SqlHelper.ExecuteScalar(objTrans, CommandType.Text, str)
                    Try
                        Dim vtb As New DataTable
                        Dim sql As String
                        sql = " SELECT " & stt & " ,MS_MAY,MS_PT,isnull(MS_DH_XUAT_PT,'') as MS_DH_XUAT_PT ,isnull(MS_DH_NHAP_PT,'') as MS_DH_NHAP_PT ,isnull(SO_LUONG,0) as SO_LUONG ,isnull(DON_GIA,0) as DON_GIA ,isnull(THANH_TIEN,0) as THANH_TIEN FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE THANH_TIEN IS NOT NULL"
                        vtb.Load(SqlHelper.ExecuteReader(objTrans, CommandType.Text, sql))
                        For Each vr As DataRow In vtb.Rows
                            sql = "exec UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT _LOG '" & stt & "','" & vr("MS_MAY").ToString & "','" & vr("MS_PT").ToString & "','" & Me.Name & "','" & Commons.Modules.UserName & "',1"
                            SqlHelper.ExecuteScalar(objTrans, CommandType.Text, sql)
                        Next
                    Catch exx As Exception

                    End Try
                End Try
                objTrans.Commit()
            End If
        Catch ex1 As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLuuKhongThanhCong", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            objTrans.Rollback()
            Exit Sub
        Finally
            objConnection.Close()
        End Try
        vEvent = "N"
        VisibleButton(True)
        VisibleButtonGhi(False)
        EnableControl(True)
        LoadcboLan(Format(dtNgay.Value, "Short date"))
        BindData(cboLan.SelectedValue)
        BThem = False
        Try
            str = "DROP TABLE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        bChon = True
        RemoveHandler grdPhanBoVatTu.CellValidating, AddressOf Me.grdPhanBoVatTu_CellValidating
    End Sub
    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Ghi()
        grdNhanvien.AllowUserToDeleteRows = False
        grdDanhsachthietbi.AllowUserToDeleteRows = False
        grdDanhsachvattu.AllowUserToDeleteRows = False
        If MS_PHIEU_CV <> -1 Then
            cboLan.SelectedValue = MS_PHIEU_CV
        End If
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        RemoveHandler grdPhanBoVatTu.CellValidating, AddressOf Me.grdPhanBoVatTu_CellValidating
        Dim str As String = ""
        Try
            str = "DROP TABLE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        bChon = True
        VisibleButton(True)
        VisibleButtonGhi(False)
        EnableControl(True)
        rtxtNoidung.Text = ""
        vEvent = "N"

        If cboLan.SelectedValue Is Nothing Then
            BindData(0)
        Else
            BindData(cboLan.SelectedValue)
        End If
        grdNhanvien.AllowUserToDeleteRows = False
        grdDanhsachthietbi.AllowUserToDeleteRows = False
        grdDanhsachvattu.AllowUserToDeleteRows = False
        If MS_PHIEU_CV <> -1 Then
            cboLan.SelectedValue = MS_PHIEU_CV
        End If
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdNhanvien_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdNhanvien.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            If grdNhanvien.Columns(e.ColumnIndex).Name = "SO_GIO" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        'XtraMessageBox.Show("không phải số")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoGioLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNhanvien.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue = "0-" Or e.FormattedValue = "-0" Or e.FormattedValue < 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoGioLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNhanvien.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    Else
                        If grdNhanvien.Rows(e.RowIndex).Cells("LUONG").Value.ToString <> "" Then
                            grdNhanvien.Rows(e.RowIndex).Cells("THANH_TIEN").Value = Math.Round(grdNhanvien.Rows(e.RowIndex).Cells("LUONG").Value * e.FormattedValue / (26 * 8), 1)
                        End If
                    End If
                Else
                    grdNhanvien.Rows(e.RowIndex).Cells("THANH_TIEN").Value = System.DBNull.Value
                End If
                txtTongCPNC.Text = Format(TongCPNC(), "###,###,##0.00")
            ElseIf grdNhanvien.Columns(e.ColumnIndex).Name = "LUONG" Then
                If e.FormattedValue <> "" Then
                    If Not IsNumeric(e.FormattedValue) Then
                        'XtraMessageBox.Show("không phải số")
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNhanvien.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    ElseIf e.FormattedValue = "0-" Or e.FormattedValue = "-0" Or e.FormattedValue < 0 Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                        grdNhanvien.Rows(e.RowIndex).ErrorText = "Error"
                        e.Cancel = True
                        Exit Sub
                    Else

                        If grdNhanvien.Rows(e.RowIndex).Cells("SO_GIO").Value.ToString <> "" Then
                            grdNhanvien.Rows(e.RowIndex).Cells("THANH_TIEN").Value = Math.Round(grdNhanvien.Rows(e.RowIndex).Cells("SO_GIO").Value * e.FormattedValue / (26 * 8), 1)
                        End If
                    End If
                Else
                    grdNhanvien.Rows(e.RowIndex).Cells("THANH_TIEN").Value = System.DBNull.Value
                End If
                txtTongCPNC.Text = Format(TongCPNC(), "###,###,##0.00")
            End If
            grdNhanvien.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        Try
            MS_PHIEU_CV = cboLan.SelectedValue.ToString()
        Catch ex As Exception
            MS_PHIEU_CV = -1
        End Try

        ''''''''''
        Dim str As String = ""
        Try
            str = "drop table CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        str = "SELECT DISTINCT CONG_VIEC_HANG_NGAY_VT.MS_PT, convert(nvarchar(150),'') AS TEN_PT,CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY,   " & _
                    " CONG_VIEC_HANG_NGAY_VT.MS_DH_XUAT_PT,CONG_VIEC_HANG_NGAY_VT.MS_DH_NHAP_PT, " & _
                    " (SELECT SO_LUONG FROM CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT VTCT  " & _
                    " WHERE VTCT.STT_CV=CONG_VIEC_HANG_NGAY_VT.STT_CV AND VTCT.MS_MAY=CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY   " & _
                    " AND VTCT.MS_PT=CONG_VIEC_HANG_NGAY_VT.MS_PT AND VTCT.ID=CONG_VIEC_HANG_NGAY_VT.ID AND VTCT.MS_DH_XUAT_PT =CONG_VIEC_HANG_NGAY_VT.MS_DH_XUAT_PT  " & _
                    " AND VTCT.MS_DH_NHAP_PT =CONG_VIEC_HANG_NGAY_VT.MS_DH_NHAP_PT )  AS SO_LUONG, dbo.IC_DON_HANG_NHAP_VAT_TU.DON_GIA, " & _
                    " (SELECT THANH_TIEN FROM CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT  VTCT WHERE VTCT.STT_CV=CONG_VIEC_HANG_NGAY_VT.STT_CV AND  " & _
                    " VTCT.MS_MAY=CONG_VIEC_HANG_NGAY_THIET_BI.MS_MAY   AND VTCT.MS_PT=CONG_VIEC_HANG_NGAY_VT.MS_PT AND VTCT.ID=CONG_VIEC_HANG_NGAY_VT.ID AND  " & _
                    " VTCT.MS_DH_XUAT_PT = CONG_VIEC_HANG_NGAY_VT.MS_DH_XUAT_PT AND VTCT.MS_DH_NHAP_PT =CONG_VIEC_HANG_NGAY_VT.MS_DH_NHAP_PT) AS THANH_TIEN ,  " & _
                    " TY_GIA, CONG_VIEC_HANG_NGAY_VT.ID INTO DBO.CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & _
                    " FROM CONG_VIEC_HANG_NGAY_VT INNER JOIN  CONG_VIEC_HANG_NGAY_THIET_BI ON  " & _
                    " CONG_VIEC_HANG_NGAY_VT.STT_CV = CONG_VIEC_HANG_NGAY_THIET_BI.STT_CV  INNER JOIN " & _
                    " dbo.IC_DON_HANG_NHAP_VAT_TU ON dbo.CONG_VIEC_HANG_NGAY_VT.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND " & _
                    " dbo.CONG_VIEC_HANG_NGAY_VT.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT AND dbo.CONG_VIEC_HANG_NGAY_VT.ID = dbo.IC_DON_HANG_NHAP_VAT_TU.ID " & _
        " WHERE(CONG_VIEC_HANG_NGAY_VT.STT_CV = " & cboLan.SelectedValue & ")"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Try
            str = "drop PROC InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE PROC [DBO].[InsertCONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "]" & _
                " @MS_MAY  NVARCHAR(30),@MS_PT  NVARCHAR(25), @TEN_PT  NVARCHAR(255),@MS_DH_XUAT_PT NVARCHAR(30), @MS_DH_NHAP_PT NVARCHAR(30),@SO_LUONG FLOAT,@DON_GIA FLOAT,@THANH_TIEN FLOAT,@TY_GIA FLOAT, @ID INT " & _
                " AS INSERT INTO CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & "(MS_MAY,MS_PT,TEN_PT,MS_DH_XUAT_PT,MS_DH_NHAP_PT,SO_LUONG,DON_GIA,THANH_TIEN,TY_GIA,ID) " & _
                " VALUES( @MS_MAY,@MS_PT,@TEN_PT,@MS_DH_XUAT_PT,@MS_DH_NHAP_PT,@SO_LUONG,@DON_GIA,@THANH_TIEN,@TY_GIA,@ID)"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        VisibleButton(False)
        VisibleButtonGhi(True)
        EnableControl(False)
        BThem = False
        grdNhanvien.Columns("MS_CONG_NHAN").ReadOnly = True
        grdNhanvien.Columns("HO_TEN").ReadOnly = True
        grdNhanvien.Columns("THANH_TIEN").ReadOnly = True

        grdDanhsachvattu.Columns("MS_PT").ReadOnly = True
        grdDanhsachvattu.Columns("TEN_PT").ReadOnly = True
        grdDanhsachvattu.Columns("DVT").ReadOnly = True
        grdDanhsachvattu.Columns("THANH_TIEN").ReadOnly = True
        grdDanhsachvattu.Columns("SO_LUONG").ReadOnly = True
        grdDanhsachvattu.Columns("MS_DH_XUAT_PT").ReadOnly = True
        grdDanhsachvattu.Columns("MS_DH_NHAP_PT").ReadOnly = True

        grdPhanBoVatTu.Columns("MS_DH_XUAT_PT").ReadOnly = True
        grdPhanBoVatTu.Columns("MS_DH_NHAP_PT").ReadOnly = True

        grdDanhsachvattu.Columns("DON_GIA").ReadOnly = True
        grdDanhsachvattu.Columns("NGOAI_TE").ReadOnly = True
        grdDanhsachvattu.Columns("TY_GIA").ReadOnly = True


        grdDanhsachthietbi.Columns("MS_MAY").ReadOnly = True
        rtxtNoidung.Focus()
        If grdDanhsachthietbi.Rows.Count > 0 Then
            BindDataChiTiet(0)
        End If
        grdNhanvien.AllowUserToDeleteRows = True
        grdDanhsachthietbi.AllowUserToDeleteRows = True
        grdDanhsachvattu.AllowUserToDeleteRows = True
        vEvent = "E"

        AddHandler grdPhanBoVatTu.CellValidating, AddressOf Me.grdPhanBoVatTu_CellValidating
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        If cboLan.SelectedValue Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongCoDuLieuXoa", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim traloi As String
        traloi = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa5", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, Me.Text)
        If traloi = vbYes Then
            Dim objCongViecHangNgay As New clsCONG_VIEC_HANG_NGAYController()

            Try

                Dim SQL As String
                Dim vtb As New DataTable

                SQL = " SELECT  STT_CV,MS_MAY,MS_PT,ISNULL(SO_LUONG,0) AS SO_LUONG, ISNULL(DON_GIA,0) AS DON_GIA, ISNULL(THANH_TIEN,0) AS THANH_TIEN, ISNULL(MS_DH_XUAT_PT,'') AS MS_DH_XUAT_PT , ISNULL(MS_DH_NHAP_PT,'') AS MS_DH_NHAP_PT FROM CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT WHERE STT_CV='" & cboLan.SelectedValue & "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
                Try
                    For Each VR As DataRow In vtb.Rows
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT_LOG", VR("STT"), VR("MS_MAY"), VR("MS_PT"), Me.Name, Commons.Modules.UserName, 3)
                    Next
                Catch ex As Exception

                End Try
                vtb = New DataTable
                SQL = " SELECT STT_CV,MS_MAY,isnull(NOI_DUNG,'') as NOI_DUNG ,isnull(CHI_PHI_NC,0) as CHI_PHI_NC ,isnull(CHI_PHI_VT,0) as CHI_PHI_VT FROM CONG_VIEC_HANG_NGAY_THIET_BI  WHERE STT_CV='" & cboLan.SelectedValue & "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
                Try

                    For Each vr As DataRow In vtb.Rows
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_HANG_NGAY_THIET_BI_LOG", vr("STT"), vr("MS_MAY"), Me.Name, Commons.Modules.UserName, 3)
                    Next
                Catch ex As Exception

                End Try
                vtb = New DataTable
                SQL = " SELECT STT_CV,MS_PT , ISNULL(SO_LUONG,0) AS SO_LUONG , ISNULL(DON_GIA,0) AS DON_GIA ," & _
                      " ISNULL(THANH_TIEN,0) AS THANH_TIEN ,ISNULL(MS_DH_XUAT_PT,'') AS MS_DH_XUAT_PT , ISNULL(MS_DH_NHAP_PT,'') AS MS_DH_NHAP_PT " & _
                      " FROM CONG_VIEC_HANG_NGAY_VT  WHERE STT_CV='" & cboLan.SelectedValue & "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
                Try
                    For Each vr As DataRow In vtb.Rows
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_HANG_NGAY_VT_LOG", vr("STT_CV"), vr("MS_PT"), Me.Name, Commons.Modules.UserName, 3)
                    Next
                Catch ex As Exception

                End Try
                vtb = New DataTable
                SQL = " SELECT STT_CV,MS_CONG_NHAN,ISNULL(SO_GIO,0) AS SO_GIO , ISNULL(LUONG,0) AS LUONG ,ISNULL(THANH_TIEN,0) AS THANH_TIEN FROM CONG_VIEC_HANG_NGAY_NV WHERE STT_CV='" & cboLan.SelectedValue & "'"
                vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL))
                Try
                    For Each VR As DataRow In vtb.Rows
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_HANG_NGAY_NV_LOG", VR("STT_CV"), VR("MS_CONG_NHAN"), Me.Name, Commons.Modules.UserName, 3)
                    Next
                Catch ex As Exception

                End Try

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_VIEC_HANG_NGAY_LOG", cboLan.SelectedValue, Me.Name, Commons.Modules.UserName, 3)
            Catch ex As Exception

            End Try
            objCongViecHangNgay.DeleteCONG_VIEC_HANG_NGAY(cboLan.SelectedValue)
        End If
        rtxtNoidung.Text = ""
        cboLan.Text = ""
        LoadcboLan(Format(dtNgay.Value, "Short date"))
        If cboLan.SelectedValue Is Nothing Then
            BindData(0)
        Else
            BindData(cboLan.SelectedValue)
        End If
    End Sub
    Sub BindDataChiTiet(ByVal intRow As Integer)
        If grdDanhsachthietbi.Rows.Count > 0 Then
            Dim str As String = ""
            If BtnGhi.Visible Then
                'grdPhanBoVatTu.DataSource = TBVatTu
                str = "SELECT MS_MAY,MS_PT,MS_DH_XUAT_PT, MS_DH_NHAP_PT ,SO_LUONG,DON_GIA,THANH_TIEN,TY_GIA, ID FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE MS_MAY='" & grdDanhsachthietbi.Rows(intRow).Cells("MS_MAY").Value & "'"
            Else
                str = " SELECT MS_MAY,IC_PHU_TUNG.MS_PT,MS_DH_XUAT_PT, MS_DH_NHAP_PT ,SO_LUONG, DON_GIA,THANH_TIEN, ID " & _
                                      " FROM CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT INNER JOIN IC_PHU_TUNG ON " & _
                                     " CONG_VIEC_HANG_NGAY_THIET_BI_VT_CT.MS_PT=IC_PHU_TUNG.MS_PT LEFT JOIN DON_VI_TINH ON IC_PHU_TUNG.DVT=DON_VI_TINH.DVT WHERE STT_CV=" & cboLan.SelectedValue & " AND MS_MAY='" & grdDanhsachthietbi.Rows(intRow).Cells("MS_MAY").Value & "'"
            End If
            grdPhanBoVatTu.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)

            grdPhanBoVatTu.Columns("MS_MAY").Visible = False
            Try
                grdPhanBoVatTu.Columns("TY_GIA").Visible = False
            Catch ex As Exception

            End Try
            Me.grdPhanBoVatTu.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
            Me.grdPhanBoVatTu.Columns("MS_PT").Width = 150
            Me.grdPhanBoVatTu.Columns("SO_LUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG", commons.Modules.TypeLanguage)
            Me.grdPhanBoVatTu.Columns("SO_LUONG").Width = 80
            Me.grdPhanBoVatTu.Columns("SO_LUONG").DefaultCellStyle.BackColor = Color.LightGray
            Me.grdPhanBoVatTu.Columns("SO_LUONG").DefaultCellStyle.Format = "###,###,##0.00"
            Me.grdPhanBoVatTu.Columns("SO_LUONG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.grdPhanBoVatTu.Columns("DON_GIA").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA", commons.Modules.TypeLanguage)
            Me.grdPhanBoVatTu.Columns("DON_GIA").Width = 83
            Me.grdPhanBoVatTu.Columns("DON_GIA").DefaultCellStyle.Format = "###,###,##0.00"
            Me.grdPhanBoVatTu.Columns("DON_GIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.grdPhanBoVatTu.Columns("MS_DH_XUAT_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_XUAT_PT", commons.Modules.TypeLanguage)
            Me.grdPhanBoVatTu.Columns("MS_DH_XUAT_PT").Width = 83
            Me.grdPhanBoVatTu.Columns("MS_DH_XUAT_PT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Me.grdPhanBoVatTu.Columns("MS_DH_NHAP_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", commons.Modules.TypeLanguage)
            Me.grdPhanBoVatTu.Columns("MS_DH_NHAP_PT").Width = 83
            Me.grdPhanBoVatTu.Columns("MS_DH_NHAP_PT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.grdPhanBoVatTu.Columns("THANH_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_TIEN", commons.Modules.TypeLanguage)
            Me.grdPhanBoVatTu.Columns("THANH_TIEN").Width = 92
            Me.grdPhanBoVatTu.Columns("THANH_TIEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.grdPhanBoVatTu.Columns("THANH_TIEN").DefaultCellStyle.Format = "###,###,##0.00"
            Me.grdPhanBoVatTu.Columns("THANH_TIEN").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Try
                Me.grdPhanBoVatTu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdPhanBoVatTu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try
            If BtnGhi.Visible Then
                grdPhanBoVatTu.Columns("MS_PT").ReadOnly = True
                grdPhanBoVatTu.Columns("THANH_TIEN").ReadOnly = True
                grdPhanBoVatTu.Columns("DON_GIA").ReadOnly = True
                grdPhanBoVatTu.Columns("SO_LUONG").ReadOnly = False
                grdPhanBoVatTu.Columns("MS_DH_XUAT_PT").ReadOnly = True
                grdPhanBoVatTu.Columns("MS_DH_NHAP_PT").ReadOnly = True

            Else
                grdPhanBoVatTu.Columns("MS_PT").ReadOnly = True
                grdPhanBoVatTu.Columns("THANH_TIEN").ReadOnly = True
                grdPhanBoVatTu.Columns("DON_GIA").ReadOnly = True
                grdPhanBoVatTu.Columns("SO_LUONG").ReadOnly = True
                grdPhanBoVatTu.Columns("MS_DH_XUAT_PT").ReadOnly = True
                grdPhanBoVatTu.Columns("MS_DH_NHAP_PT").ReadOnly = True


            End If
            txtTongCPCT.Text = Format(TongCPCT(grdDanhsachthietbi.Rows(intRow).Cells("MS_MAY").Value), "###,###,###.00")
        End If
    End Sub
    Private Sub grdDanhsachthietbi_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachthietbi.RowEnter
        grdDanhsachthietbi.Columns("CHI_PHI_VT").ReadOnly = True
        BindDataChiTiet(e.RowIndex)
    End Sub

    Private Sub grdPhanBoVatTu_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles grdPhanBoVatTu.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If grdPhanBoVatTu.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
            If e.FormattedValue <> "" Then
                If Not IsNumeric(e.FormattedValue) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdPhanBoVatTu.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                ElseIf e.FormattedValue < 0 Or e.FormattedValue = "-0" Or e.FormattedValue = "0-" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoLuongLaSoKhongAm", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    grdPhanBoVatTu.Rows(e.RowIndex).ErrorText = "Error"
                    e.Cancel = True
                    Exit Sub
                Else
                    grdPhanBoVatTu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = Math.Round(e.FormattedValue * grdPhanBoVatTu.Rows(e.RowIndex).Cells("DON_GIA").Value, 2)
                    Dim str As String = ""
                    str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=" & e.FormattedValue & _
                                ",THANH_TIEN=" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("THANH_TIEN").Value & _
                                " WHERE MS_MAY='" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_MAY").Value & "' " & _
                                " AND MS_PT='" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_PT").Value & "' " & _
                                " AND ID = " & grdPhanBoVatTu.Rows(e.RowIndex).Cells("ID").Value
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                End If
            Else
                Dim str As String = ""
                str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG=NULL,THANH_TIEN=NULL " & _
                        " WHERE MS_MAY='" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_MAY").Value & "' " & _
                        " AND MS_PT='" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_PT").Value & "' " & _
                        " AND ID = " & grdPhanBoVatTu.Rows(e.RowIndex).Cells("ID").Value
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdPhanBoVatTu.Rows(e.RowIndex).Cells("THANH_TIEN").Value = System.DBNull.Value
            End If
            txtTongCPCT.Text = Format(TongCPCT(grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_MAY").Value), "###,###,##0.00")
            grdPhanBoVatTu.Rows(e.RowIndex).ErrorText = ""
        End If
    End Sub

    Private Sub grdDanhsachvattu_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachvattu.CellValueChanged
        On Error Resume Next
        If grdDanhsachvattu.Rows.Count = 0 Or e.RowIndex = -1 Then Exit Sub

        If e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then
            If Not grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value Is Nothing And Not grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value.ToString().Trim().Equals("") Then
                Dim str As String
                str = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET THANH_TIEN = SO_LUONG * " & grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value & " , DON_GIA = " & grdDanhsachvattu.Rows(e.RowIndex).Cells("DON_GIA").Value & _
                            " WHERE MS_PT = '" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value.ToString().Trim() & "' " & _
                            " AND ID = " & grdDanhsachvattu.Rows(e.RowIndex).Cells("ID").Value.ToString().Trim()
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdDanhsachvattu.CurrentRow.Cells("THANH_TIEN").Value = grdDanhsachvattu.CurrentRow.Cells("SO_LUONG").Value * grdDanhsachvattu.CurrentRow.Cells("DON_GIA").Value
            Else
                Dim str As String = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG = NULL , THANH_TIEN = NULL , DON_GIA = NULL WHERE MS_PT = '" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value.ToString().Trim() & "' "
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                grdDanhsachvattu.CurrentRow.Cells("THANH_TIEN").Value = 0

            End If
            BindDataChiTiet(0)
            UpdateChiPhiVT()
            txtTongCPNC.Text = Format(TongCPNC(), "###,###,##0.00")
            txtTongCPVT.Text = Format(TongCPVT(), "###,###,##0.00")
            txtTongCPNV1.Text = Format(TongCPNC1(), "###,###,##0.00")
            txtTongCPVT1.Text = Format(TongCPVT1(), "###,###,##0.00")

        End If
    End Sub

    Private Sub grdDanhsachvattu_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDanhsachvattu.EditingControlShowing
        Try
            txtBaoTri = e.Control
            If grdDanhsachvattu.CurrentCell.OwningColumn.Name = "SO_LUONG" Or grdDanhsachvattu.CurrentCell.OwningColumn.Name = "DON_GIA" Or grdDanhsachvattu.CurrentCell.OwningColumn.Name = "THANH_TIEN" Then
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdPhanBoVatTu_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPhanBoVatTu.CellValidated
        If grdPhanBoVatTu.Rows.Count > 0 Then
            grdPhanBoVatTu.Columns("SO_LUONG").DefaultCellStyle.Format = "###,###,##0.00"
        End If
    End Sub

    Private Sub grdPhanBoVatTu_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdPhanBoVatTu.EditingControlShowing
        Try
            txtBaoTri = e.Control
            If grdPhanBoVatTu.CurrentCell.OwningColumn.Name = "SO_LUONG" Or grdPhanBoVatTu.CurrentCell.OwningColumn.Name = "DON_GIA" Or grdPhanBoVatTu.CurrentCell.OwningColumn.Name = "THANH_TIEN" Then
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdNhanvien_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdNhanvien.EditingControlShowing
        Try
            txtBaoTri = e.Control
            If grdNhanvien.CurrentCell.OwningColumn.Name = "SO_GIO" Or grdNhanvien.CurrentCell.OwningColumn.Name = "LUONG" Then
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDanhsachthietbi_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDanhsachthietbi.EditingControlShowing
        Try
            txtBaoTri = e.Control
            If grdDanhsachthietbi.CurrentCell.OwningColumn.Name = "CHI_PHI_NC" Or grdDanhsachthietbi.CurrentCell.OwningColumn.Name = "CHI_PHI_VT" Then
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtBaoTri.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdNhanvien_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNhanvien.RowEnter
        grdNhanvien.Columns("LUONG").ReadOnly = True
    End Sub

    Private Sub grdDanhsachvattu_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachvattu.RowEnter
        grdDanhsachvattu.Columns("THANH_TIEN").ReadOnly = True
    End Sub

    Private Sub grdNhanvien_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdNhanvien.UserDeletedRow
        Try
            txtTongCPNC.Text = Format(TongCPNC(), "###,###,##0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDanhsachthietbi_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdDanhsachthietbi.UserDeletedRow
        Try
            txtTongCPNV1.Text = Format(TongCPNC1(), "###,###,##0.00")
            txtTongCPVT1.Text = Format(TongCPVT1(), "###,###,##0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDanhsachvattu_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdDanhsachvattu.UserDeletedRow
        Try
            txtTongCPVT.Text = Format(TongCPVT(), "###,###,##0.00")
            grdDanhsachthietbi.Focus()
            grdDanhsachvattu.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDanhsachvattu_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdDanhsachvattu.UserDeletingRow
        Try
            Dim str As String = "DELETE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE MS_PT = '" & grdDanhsachvattu.CurrentRow.Cells("MS_PT").Value.ToString().Trim() & "' AND ID = " & grdDanhsachvattu.CurrentRow.Cells("ID").Value.ToString().Trim()
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, str)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDanhsachthietbi_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdDanhsachthietbi.UserDeletingRow
        Try
            Dim str As String = "DELETE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE MS_MAY = '" & grdDanhsachthietbi.CurrentRow.Cells("MS_MAY").Value.ToString().Trim() & "' "
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString(), CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdPhanBoVatTu_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPhanBoVatTu.CellValueChanged
        Try
            If (BtnGhi.Visible) Then
                If (e.ColumnIndex = 4) Then
                    Try
                        If (Not grdPhanBoVatTu.Rows(e.RowIndex).Cells("SO_LUONG").Value Is Nothing And Not grdPhanBoVatTu.Rows(e.RowIndex).Cells("DON_GIA").Value Is Nothing) Then
                            Dim str As String = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & _
                                    " SET SO_LUONG = " & grdPhanBoVatTu.Rows(e.RowIndex).Cells("SO_LUONG").Value & ", " & _
                                    " DON_GIA = " & grdPhanBoVatTu.Rows(e.RowIndex).Cells("DON_GIA").Value & " ,  " & _
                                    " THANH_TIEN = " & grdPhanBoVatTu.Rows(e.RowIndex).Cells("SO_LUONG").Value * grdPhanBoVatTu.Rows(e.RowIndex).Cells("DON_GIA").Value * grdPhanBoVatTu.Rows(e.RowIndex).Cells("TY_GIA").Value & _
                                    " WHERE MS_PT = '" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_PT").Value.ToString().Trim() & "'  " & _
                                    " AND MS_MAY = '" & grdDanhsachthietbi.CurrentRow.Cells("MS_MAY").Value & "' " & _
                                    " AND ID = '" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("ID").Value.ToString().Trim() & "'  " & _
                                    " AND MS_DH_XUAT_PT = '" + grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_DH_XUAT_PT").Value + "' " & _
                                    " AND MS_DH_NHAP_PT = '" + grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_DH_NHAP_PT").Value + "' "

                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                            BindDataChiTiet(grdDanhsachthietbi.CurrentRow.Index)
                        Else
                            If Not grdPhanBoVatTu.Rows(e.RowIndex).Cells("SO_LUONG").Value Is Nothing Then
                                Dim str As String = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG = " & grdPhanBoVatTu.Rows(e.RowIndex).Cells("SO_LUONG").Value & " , THANH_TIEN =  NULL  WHERE MS_PT = '" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_PT").Value.ToString().Trim() & "' AND MS_MAY = '" & grdDanhsachthietbi.CurrentRow.Cells("MS_MAY").Value & "' "
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                BindDataChiTiet(grdDanhsachthietbi.CurrentRow.Index)
                            Else
                                Dim str As String = "UPDATE CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " SET SO_LUONG = NULL , THANH_TIEN =  NULL  WHERE MS_PT = '" & grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_PT").Value.ToString().Trim() & "' AND MS_MAY = '" & grdDanhsachthietbi.CurrentRow.Cells("MS_MAY").Value & "' " & _
                                 " AND MS_DH_XUAT_PT = '" + grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_DH_XUAT_PT").Value + "' AND MS_DH_NHAP_PT = '" + grdPhanBoVatTu.Rows(e.RowIndex).Cells("MS_DH_NHAP_PT").Value + "' "
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
                                BindDataChiTiet(grdDanhsachthietbi.CurrentRow.Index)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    UpdateChiPhiVT()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Hàm tính chi phí vật tư
    Private Function ChiPhiVatTu(ByVal MS_MAY As String) As Double
        Try
            Dim tbChiPhi As DataTable = New DataTable()
            tbChiPhi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, " SELECT SUM (THANH_TIEN) AS CHI_PHI_VT FROM CONG_VIEC_HANG_NGAY_TB_VT_CT_TMP" & Commons.Modules.UserName & " WHERE MS_MAY = '" & MS_MAY & "'"))
            Return Convert.ToDouble(tbChiPhi.Rows(0)(0))
        Catch ex As Exception
            Return -1
        End Try
    End Function
    'Hàm updata chi phí
    Private Sub UpdateChiPhiVT()
        For i As Integer = 0 To grdDanhsachthietbi.Rows.Count - 1
            Dim chiphivt As Double = ChiPhiVatTu(grdDanhsachthietbi.Rows(i).Cells("MS_MAY").Value.ToString().Trim())
            If (chiphivt <> -1) Then
                grdDanhsachthietbi.Rows(i).Cells("CHI_PHI_VT").Value = chiphivt
            End If        
        Next i
    End Sub

End Class