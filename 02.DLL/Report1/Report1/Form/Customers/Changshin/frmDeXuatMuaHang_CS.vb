
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Excel
Imports Office



Public Class frmDeXuatMuaHang_CS

    Private Sub frmDeXuatMuaHang_CS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            vThang = DateTime.ParseExact("01/" + cbxThang.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            vThang = DateTime.Now.Date
        End Try
        'Vietsoft.Admin.Adminvs.ConnectionString = Commons.IConnections.ConnectionString
        'MessageBox.Show(Vietsoft.Admin.IDvs.CREATE_ID("PN", DateTime.Now.AddMonths(-1)))
        LoadBoPhan()
        LoadThang()
        LoadData()
        BindData()
        LockControl()
        LockChiTiet()
        LockInput(True)
        AddHandler cbxThang.SelectedIndexChanged, AddressOf cbxThang_SelectedIndexChanged
        AddHandler rdbDaDuyet.CheckedChanged, AddressOf rdbDaDuyet_CheckedChanged
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Private Sub tabControl_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tabControl.Selecting
        If vEvent = "A" Or vEvent = "E" Then
            e.Cancel = True
            Exit Sub
        End If
        Select Case tabControl.SelectedTab.Name
            Case "tabChiTietDX"
                LoadChiTietDX(txtSoDeXuat.Text.Trim)
                LockControl()
            Case "tabDSDX"
                LockControl()
        End Select
    End Sub

#Region "Du Lieu Thanh phan"
    Private vtbListUP As New System.Data.DataTable()
    Private vIndex As Integer = -1
    Private vEvent As String = "N"
    Private vThang As DateTime
    Private vNgayLap As New DateTime
#End Region

#Region "Khoi Tao Form"

    Sub LockControl()
        If rdbChuaDuyet.Checked = True Then
            If vEvent = "A" Or vEvent = "E" Then
                btnThem.Enabled = False
                btnSua.Enabled = False
                btnXoa.Enabled = False
                btnIn.Enabled = False
                btnDuyet.Visible = False
                btnThoat.Enabled = False
                btnGhi.Enabled = True
                btnKhongGhi.Enabled = True
                btnChonVTPT.Visible = True
            Else
                If grdDsDeXuat.Rows.Count > 0 Then
                    btnThem.Enabled = True
                    btnSua.Enabled = True
                    btnXoa.Enabled = True
                    btnIn.Enabled = True
                    btnDuyet.Visible = True
                    btnThoat.Enabled = True
                    btnGhi.Enabled = False
                    btnKhongGhi.Enabled = False
                    btnChonVTPT.Visible = False
                    btnTM.Enabled = False
                Else
                    btnThem.Enabled = True
                    btnSua.Enabled = False
                    btnXoa.Enabled = False
                    btnIn.Enabled = False
                    btnDuyet.Visible = False
                    btnThoat.Enabled = True
                    btnGhi.Enabled = False
                    btnKhongGhi.Enabled = False
                    btnChonVTPT.Visible = False
                    btnTM.Enabled = False
                End If
            End If
        Else
            If grdDsDeXuat.Rows.Count > 0 Then
                btnThem.Enabled = False
                btnSua.Enabled = False
                btnXoa.Enabled = False
                btnIn.Enabled = True
                btnDuyet.Visible = False
                btnThoat.Enabled = True
                btnGhi.Enabled = False
                btnKhongGhi.Enabled = False
                btnChonVTPT.Visible = False
            Else
                btnThem.Enabled = False
                btnSua.Enabled = False
                btnXoa.Enabled = False
                btnIn.Enabled = False
                btnDuyet.Visible = False
                btnThoat.Enabled = True
                btnGhi.Enabled = False
                btnKhongGhi.Enabled = False
                btnChonVTPT.Visible = False
            End If
        End If
        If QuyenDuyet() = True And rdbChuaDuyet.Checked = True Then
            If grdDsDeXuat.Rows.Count > 0 Then
                btnDuyet.Visible = True
            Else
                btnDuyet.Visible = False
            End If
        Else
            btnDuyet.Visible = False
        End If
    End Sub

    Sub LockChiTiet()
        Try
            If vEvent = "A" Or vEvent = "E" Then
                grdChiTietDX.Columns("SO_LUONG").ReadOnly = False
                grdChiTietDX.Columns("DON_GIA").ReadOnly = False
                grdChiTietDX.Columns("NGOAI_TE").ReadOnly = False
                grdChiTietDX.Columns("TI_GIA").ReadOnly = False
                grdChiTietDX.Columns("GHI_CHU").ReadOnly = False

            Else
                grdChiTietDX.Columns("SO_LUONG").ReadOnly = True
                grdChiTietDX.Columns("DON_GIA").ReadOnly = True
                grdChiTietDX.Columns("NGOAI_TE").ReadOnly = True
                grdChiTietDX.Columns("TI_GIA").ReadOnly = True
                grdChiTietDX.Columns("GHI_CHU").ReadOnly = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function QuyenDuyet() As Boolean
        Dim vtb As New System.Data.DataTable
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_QUYEN_DUYET", Commons.Modules.UserName, 2))
        If vtb.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
        Return False
    End Function

    Sub LockInput(ByVal vFlag As Boolean)
        txtSoDeXuat.ReadOnly = vFlag
        txtNguoiDuyet.ReadOnly = vFlag
        txtGhiChu.ReadOnly = vFlag
        txtGiaoCho.ReadOnly = vFlag
        mtxtNgayLap.ReadOnly = vFlag
        mtxtNgayGiao.ReadOnly = vFlag
        cbxPhongYeuCau.Enabled = Not vFlag
        chxLapKH.Enabled = Not vFlag
        chxYeuCau.Enabled = Not vFlag
    End Sub

    'Load Bo Phan 
    Sub LoadBoPhan()
        Dim vtb As New System.Data.DataTable
        vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VIs"))
        cbxPhongYeuCau.DataSource = vtb
        cbxPhongYeuCau.DisplayMember = "TEN_DON_VI"
        cbxPhongYeuCau.ValueMember = "MS_DON_VI"
    End Sub

    Sub LoadData()
        vtbListUP = New System.Data.DataTable()
        grdDsDeXuat.DataSource = Nothing
        vtbListUP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_GET_DATA", IIf(rdbChuaDuyet.Checked = True, 0, 1), vThang))
        grdDsDeXuat.AutoGenerateColumns = False

        Dim vTBNgoaiTe As New System.Data.DataTable
        vTBNgoaiTe.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT  NGOAI_TE, TEN_NGOAI_TE FROM  dbo.NGOAI_TE"))
        NGOAI_TE.DataSource = vTBNgoaiTe
        NGOAI_TE.DisplayMember = "NGOAI_TE"
        NGOAI_TE.ValueMember = "NGOAI_TE"

        grdDsDeXuat.DataSource = vtbListUP
        grdDsDeXuat.Columns("SO_DE_XUAT").DataPropertyName = "SO_DE_XUAT"
        grdDsDeXuat.Columns("BO_PHAN").DataPropertyName = "TEN_DON_VI"
        grdDsDeXuat.Columns("NGAY_LAP").DataPropertyName = "NGAY"
        grdDsDeXuat.Columns("NGAY_GIAO").DataPropertyName = "NGAY_GIAO"
        ClearNull()
    End Sub
    Sub LoadChiTietDX(ByVal vSODX As String)

        Dim vtbDetail As New System.Data.DataTable
        vtbDetail.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_GET_DATA_CHI_TIET", txtSoDeXuat.Text.Trim))

        vtbDetail.Columns("THANH_TIENNT").ReadOnly = False
        vtbDetail.Columns("THANH_TIEN").ReadOnly = False
        grdChiTietDX.AutoGenerateColumns = False
        grdChiTietDX.DataSource = vtbDetail
        grdChiTietDX.Columns("MS_PT").DataPropertyName = "MS_PT"
        grdChiTietDX.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        grdChiTietDX.Columns("SO_LUONG").DataPropertyName = "SO_LUONG"
        grdChiTietDX.Columns("DVT").DataPropertyName = "DVT"
        grdChiTietDX.Columns("DON_GIA").DataPropertyName = "DON_GIA"
        grdChiTietDX.Columns("NGOAI_TE").DataPropertyName = "NGOAI_TE"
        grdChiTietDX.Columns("TI_GIA").DataPropertyName = "TI_GIA"
        grdChiTietDX.Columns("TON_MIN").DataPropertyName = "TON_MIN"
        grdChiTietDX.Columns("TON_MAX").DataPropertyName = "TON_MAX"
        grdChiTietDX.Columns("THANH_TIENNT").DataPropertyName = "THANH_TIENNT"
        grdChiTietDX.Columns("THANH_TIEN").DataPropertyName = "THANH_TIEN"
        grdChiTietDX.Columns("GHI_CHU").DataPropertyName = "GHI_CHU"
        grdChiTietDX.Columns("NGAY_DX_CUOI").DataPropertyName = "NGAY_DX_CUOI"


    End Sub

    Sub BindData()
        txtSoDeXuat.DataBindings.Clear()
        txtSoDeXuat.DataBindings.Add("Text", vtbListUP, "SO_DE_XUAT", True, DataSourceUpdateMode.OnPropertyChanged)

        txtGiaoCho.DataBindings.Clear()
        txtGiaoCho.DataBindings.Add("Text", vtbListUP, "NGUOI_NHAN", True, DataSourceUpdateMode.OnValidation)

        txtNguoiDuyet.DataBindings.Clear()
        txtNguoiDuyet.DataBindings.Add("Text", vtbListUP, "NGUOI_DUYET", True, DataSourceUpdateMode.OnValidation)

        txtGhiChu.DataBindings.Clear()
        txtGhiChu.DataBindings.Add("Text", vtbListUP, "GHI_CHU", True, DataSourceUpdateMode.OnValidation)

        cbxPhongYeuCau.DataBindings.Clear()
        cbxPhongYeuCau.DataBindings.Add("Text", vtbListUP, "TEN_DON_VI", True, DataSourceUpdateMode.OnPropertyChanged)

        chxLapKH.DataBindings.Clear()
        chxLapKH.DataBindings.Add("Checked", vtbListUP, "THEOKH", True, DataSourceUpdateMode.OnValidation)

        chxYeuCau.DataBindings.Clear()
        chxYeuCau.DataBindings.Add("Checked", vtbListUP, "THEOYEUCAU", True, DataSourceUpdateMode.OnValidation)

        mtxtNgayLap.DataBindings.Clear()
        mtxtNgayLap.DataBindings.Add("Text", vtbListUP, "NGAY", True, DataSourceUpdateMode.OnPropertyChanged, "  /  /    ", "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

        mtxtNgayGiao.DataBindings.Clear()
        mtxtNgayGiao.DataBindings.Add("Text", vtbListUP, "NGAY_GIAO", True, DataSourceUpdateMode.OnValidation, "  /  /    ", "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)

    End Sub

    'Load Thang co de xuat 
    Sub LoadThang()
        Try
            Dim vtb As New System.Data.DataTable
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_GET_THANG"))
            cbxThang.DataSource = vtb
            cbxThang.DisplayMember = "THANG_NAM"
            cbxThang.ValueMember = "THANG"
            cbxThang.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Sub ClearNull()
        If vtbListUP.Rows.Count = 0 Then
            txtSoDeXuat.Text = String.Empty
            txtNguoiDuyet.Text = String.Empty
            txtGhiChu.Text = String.Empty
            txtGiaoCho.Text = String.Empty
            mtxtNgayLap.Text = String.Empty
            mtxtNgayGiao.Text = String.Empty
            cbxPhongYeuCau.SelectedValue = DBNull.Value
            chxLapKH.Checked = False
            chxYeuCau.Checked = False
        End If
    End Sub

    Public Function GetTI_GIA_USD(ByVal NGOAI_TE As String) As Double
        Dim TY_GIA_USD As Double
        Dim reader As SqlDataReader
        reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA_USD", NGOAI_TE)
        If reader.Read Then
            TY_GIA_USD = reader.Item("TI_GIA_USD")
        End If
        reader.Close()
        Return TY_GIA_USD
    End Function

    Public Function GetTI_GIA(ByVal NGOAI_TE As String) As Double
        Dim TY_GIA As Double
        Dim reader As SqlDataReader
        reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTI_GIA", NGOAI_TE)
        If reader.Read Then
            TY_GIA = reader.Item("TI_GIA")
        End If
        reader.Close()
        Return TY_GIA
    End Function
#End Region

#Region "Event Form"

    Private Sub btnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Click

        tabControl.SelectedIndex = 1
        vEvent = "A"

        Try
            vIndex = grdDsDeXuat.CurrentRow.Index
        Catch ex As Exception
            vIndex = -1
        End Try
        vtbListUP.Columns("SO_DE_XUAT").AllowDBNull = True
        vtbListUP.Columns("TEN_DON_VI").AllowDBNull = True
        vtbListUP.Rows.Add()
        For i As Integer = 0 To grdDsDeXuat.Rows.Count
            If (grdDsDeXuat.Rows(i).Cells("SO_DE_XUAT").Value.Equals(DBNull.Value)) Then
                grdDsDeXuat.CurrentCell = grdDsDeXuat.Rows(i).Cells(0)
                Exit For
            End If
        Next

        LockControl()
        LockInput(False)
        btnTM.Enabled = True
        btnChonVTPT.Visible = True
        btnDuyet.Visible = False
        LockChiTiet()
        LoadChiTietDX("")
        mtxtNgayLap.Text = DateTime.Now.Date.ToString("dd/MM/yyyy")
        cbxPhongYeuCau.SelectedValue = DBNull.Value
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click

        If txtSoDeXuat.Text.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_TAO_SO_DE_XUAT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtSoDeXuat.Focus()
            Exit Sub
        End If
        If mtxtNgayLap.Text.Trim = "/  /" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_TAO_NGAY_LAP", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            mtxtNgayLap.Focus()
            Exit Sub
        End If
        Try
            If cbxPhongYeuCau.Text.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_CHON_PHONG_YEU_CAU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cbxPhongYeuCau.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try

        If grdChiTietDX.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_CHON_VTPT_DE_XUAT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Dim vNgayGiao As DateTime
        Try
            If mtxtNgayGiao.Text.Trim <> "/  /" Then
                vNgayGiao = DateTime.ParseExact(mtxtNgayGiao.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            End If
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_GIAO_CHUA_DUNG_DD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            mtxtNgayGiao.Focus()
            Exit Sub
        End Try

        Try
            vNgayLap = DateTime.ParseExact(mtxtNgayLap.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY_LAP_CHUA_DUNG_DD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            mtxtNgayLap.Focus()
            Exit Sub
        End Try

        For i As Integer = 0 To grdChiTietDX.Rows.Count - 1
            If IsDBNull(grdChiTietDX.Rows(i).Cells("SO_LUONG").Value) = True Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_SO_LUONG", commons.Modules.TypeLanguage))
                grdChiTietDX.Rows(i).Cells("SO_LUONG").Selected() = True
                Exit Sub
            End If
            If grdChiTietDX.Rows(i).Cells("SO_LUONG").Value = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SO_LUONG_LON_HON_KO", commons.Modules.TypeLanguage))
                grdChiTietDX.Rows(i).Cells("SO_LUONG").Selected() = True
                Exit Sub
            End If
        Next

        For i As Integer = 0 To grdChiTietDX.Rows.Count - 1
            If IsDBNull(grdChiTietDX.Rows(i).Cells("NGOAI_TE").Value) = True Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_NGOAI_TE", commons.Modules.TypeLanguage))
                grdChiTietDX.Rows(i).Cells("NGOAI_TE").Selected() = True
                Exit Sub
            End If
        Next

        For i As Integer = 0 To grdChiTietDX.Rows.Count - 1
            If IsDBNull(grdChiTietDX.Rows(i).Cells("TI_GIA").Value) = True Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_TI_GIA", commons.Modules.TypeLanguage))
                grdChiTietDX.Rows(i).Cells("TI_GIA").Selected() = True
                Exit Sub
            End If
            If grdChiTietDX.Rows(i).Cells("TI_GIA").Value = 0 Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TI_GIA_PHAI_LON_HON_KO", commons.Modules.TypeLanguage))
                grdChiTietDX.Rows(i).Cells("TI_GIA").Selected() = True
                Exit Sub
            End If
        Next

        If vEvent = "A" Then
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction

            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_INSERT", txtSoDeXuat.Text.Trim, cbxPhongYeuCau.SelectedValue, vNgayLap, _
                IIf(txtGiaoCho.Text.Trim = "", DBNull.Value, txtGiaoCho.Text), IIf(txtNguoiDuyet.Text.Trim = "", DBNull.Value, txtNguoiDuyet.Text), IIf(mtxtNgayGiao.Text.Trim = "/  /", DBNull.Value, vNgayGiao), _
                IIf(txtGhiChu.Text.Trim = "", DBNull.Value, txtGhiChu.Text.Trim), IIf(chxLapKH.Checked = True, 1, 0), IIf(chxYeuCau.Checked = True, 1, 0))

                For i As Integer = 0 To grdChiTietDX.Rows.Count - 1
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_INSERT_CHI_TIET", _
                    txtSoDeXuat.Text.Trim, grdChiTietDX.Rows(i).Cells("MS_PT").Value, grdChiTietDX.Rows(i).Cells("SO_LUONG").Value, grdChiTietDX.Rows(i).Cells("DON_GIA").Value, _
                    grdChiTietDX.Rows(i).Cells("TON_MIN").Value, grdChiTietDX.Rows(i).Cells("TON_MAX").Value, grdChiTietDX.Rows(i).Cells("NGOAI_TE").Value, grdChiTietDX.Rows(i).Cells("TI_GIA").Value, grdChiTietDX.Rows(i).Cells("NGAY_DX_CUOI").Value, grdChiTietDX.Rows(i).Cells("GHI_CHU").Value)
                Next

                vtbListUP.AcceptChanges()

                objTrans.Commit()
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CHUA_THEM_THANH_CONG", commons.Modules.TypeLanguage))
                objTrans.Rollback()
                Exit Sub
            End Try

        ElseIf vEvent = "E" Then
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_UPDATE", txtSoDeXuat.Text.Trim, cbxPhongYeuCau.SelectedValue, vNgayLap, _
                IIf(txtGiaoCho.Text.Trim = "", DBNull.Value, txtGiaoCho.Text), IIf(txtNguoiDuyet.Text.Trim = "", DBNull.Value, txtNguoiDuyet.Text), IIf(mtxtNgayGiao.Text.Trim = "/  /", DBNull.Value, vNgayGiao), _
                IIf(txtGhiChu.Text.Trim = "", DBNull.Value, txtGhiChu.Text.Trim), IIf(chxLapKH.Checked = True, 1, 0), IIf(chxYeuCau.Checked = True, 1, 0))

                Dim vListVT As String = ""
                For i As Integer = 0 To grdChiTietDX.Rows.Count - 1
                    Dim vTonTai As Object

                    vTonTai = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_CHECK_VTPT", txtSoDeXuat.Text.Trim, grdChiTietDX.Rows(i).Cells("MS_PT").Value)
                    If CType(vTonTai, Integer) = 0 Then
                        If vListVT = "" Then
                            vListVT = "'" + grdChiTietDX.Rows(i).Cells("MS_PT").Value.ToString + "'"
                        Else
                            vListVT = vListVT + ",'" + grdChiTietDX.Rows(i).Cells("MS_PT").Value + "'"
                        End If

                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_INSERT_CHI_TIET", _
                        txtSoDeXuat.Text.Trim, grdChiTietDX.Rows(i).Cells("MS_PT").Value, grdChiTietDX.Rows(i).Cells("SO_LUONG").Value, grdChiTietDX.Rows(i).Cells("DON_GIA").Value, _
                        grdChiTietDX.Rows(i).Cells("TON_MIN").Value, grdChiTietDX.Rows(i).Cells("TON_MAX").Value, grdChiTietDX.Rows(i).Cells("NGOAI_TE").Value, grdChiTietDX.Rows(i).Cells("TI_GIA").Value, grdChiTietDX.Rows(i).Cells("NGAY_DX_CUOI").Value, grdChiTietDX.Rows(i).Cells("GHI_CHU").Value)
                    Else
                        If vListVT = "" Then
                            vListVT = "'" + grdChiTietDX.Rows(i).Cells("MS_PT").Value + "'"
                        Else
                            vListVT = vListVT + ",'" + grdChiTietDX.Rows(i).Cells("MS_PT").Value + "'"
                        End If
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_UPDATE_CHI_TIET", _
                       txtSoDeXuat.Text.Trim, grdChiTietDX.Rows(i).Cells("MS_PT").Value, grdChiTietDX.Rows(i).Cells("SO_LUONG").Value, grdChiTietDX.Rows(i).Cells("DON_GIA").Value, _
                       grdChiTietDX.Rows(i).Cells("TON_MIN").Value, grdChiTietDX.Rows(i).Cells("TON_MAX").Value, grdChiTietDX.Rows(i).Cells("NGOAI_TE").Value, grdChiTietDX.Rows(i).Cells("TI_GIA").Value, grdChiTietDX.Rows(i).Cells("NGAY_DX_CUOI").Value, grdChiTietDX.Rows(i).Cells("GHI_CHU").Value)
                    End If

                Next
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_DELETE_VTPT", txtSoDeXuat.Text.Trim, vListVT)
                objTrans.Commit()
                vtbListUP.AcceptChanges()
            Catch ex As Exception
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CHUA_THEM_THANH_CONG", commons.Modules.TypeLanguage))
                objTrans.Rollback()
                Exit Sub
            End Try

        End If

        vEvent = "N"
        tabControl.SelectedIndex = 0
        LockControl()
        LockChiTiet()
        LockInput(True)
    End Sub

    Private Sub btnKhongGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        Try
            vEvent = "N"
            vtbListUP.RejectChanges()
            BindData()
            LockControl()
            LockChiTiet()
            LockInput(True)
            tabControl.SelectedIndex = 0
            If (vIndex < grdDsDeXuat.Rows.Count) Then
                grdDsDeXuat.CurrentCell = grdDsDeXuat.Rows(vIndex).Cells(0)
            End If
            grdDsDeXuat.CurrentRow.Selected = True

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        Try
            tabControl.SelectedIndex = 1
            vEvent = "E"
            vIndex = grdDsDeXuat.CurrentRow.Index
            grdDsDeXuat.CurrentCell = grdDsDeXuat.Rows(vIndex).Cells(0)
            LockControl()
            LockChiTiet()
            LockInput(False)
            txtSoDeXuat.ReadOnly = True
            btnTM.Enabled = False
            btnChonVTPT.Visible = True
            btnDuyet.Visible = False

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Click

        If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CO_CHAC_MUON_XOA_KO", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            tabControl.SelectedIndex = 0
            Dim objConnection As New SqlConnection(Commons.IConnections.ConnectionString)
            objConnection.Open()
            Dim objTrans As SqlTransaction = objConnection.BeginTransaction
            Try
                SqlHelper.ExecuteNonQuery(objTrans, "H_DE_XUAT_MUA_HANG_CS_DELETE", txtSoDeXuat.Text.Trim)
                For Each vRow As DataRow In vtbListUP.Rows
                    If (vRow("SO_DE_XUAT").ToString().Trim().Equals(grdDsDeXuat.CurrentRow.Cells("SO_DE_XUAT").Value.ToString().Trim())) Then
                        vtbListUP.Rows.Remove(vRow)
                        Exit For
                    End If
                Next
                vtbListUP.AcceptChanges()
                LockControl()
                objTrans.Commit()
            Catch ex As Exception
                objTrans.Rollback()
            End Try
        End If

    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        'If grdChiTietDX.Rows.Count = 0 Then
        '    Exit Sub
        'End If
        Me.Cursor = Cursors.WaitCursor
        'ShowrptDonDatHang()
        'Me.Cursor = Cursors.Default
        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)
        With ExcelSheets
            .Columns(1).ColumnWidth = 3
            .Columns(2).ColumnWidth = 15
            .Columns(3).ColumnWidth = 15
            .Columns(4).ColumnWidth = 4
            .Columns(5).ColumnWidth = 4
            .Columns(6).ColumnWidth = 4
            .Columns(7).ColumnWidth = 6
            .Columns(8).ColumnWidth = 6
            .Columns(9).ColumnWidth = 8
            .Columns(10).ColumnWidth = 8
            .Columns(11).ColumnWidth = 8
        End With

        Dim TenCty As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "TenCty", commons.Modules.TypeLanguage)
        Dim rgTenCty As Excel.Range
        rgTenCty = ExcelSheets.Range("A1", "D1")
        rgTenCty.Merge(True)
        rgTenCty.MergeCells() = True
        rgTenCty.Font.Bold = True
        rgTenCty.Value = TenCty
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "BoPhan", commons.Modules.TypeLanguage)
        Dim rgBoPhan As Excel.Range
        rgBoPhan = ExcelSheets.Range("A2", "D2")
        rgBoPhan.Merge(True)
        rgBoPhan.MergeCells() = True
        rgBoPhan.Font.Bold = True
        rgBoPhan.Value = BoPhan
        Dim Maso As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "Maso", commons.Modules.TypeLanguage)
        Dim rgMaSo As Excel.Range
        rgMaSo = ExcelSheets.Range("J1", "K1")
        rgMaSo.Merge(True)
        rgMaSo.MergeCells() = True
        rgMaSo.Font.Bold = True
        rgMaSo.Font.Color = RGB(255, 0, 255)
        rgMaSo.HorizontalAlignment = XlHAlign.xlHAlignRight
        rgMaSo.Value = Maso

        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "TieuDe", commons.Modules.TypeLanguage)
        Dim rgTieuDe As Excel.Range
        rgTieuDe = ExcelSheets.Range("A4", "L5")
        rgTieuDe.Merge(True)
        rgTieuDe.MergeCells() = True
        rgTieuDe.Font.Bold = True
        rgTieuDe.Font.Size = 16
        rgTieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter
        rgTieuDe.VerticalAlignment = XlVAlign.xlVAlignCenter
        rgTieuDe.Value = TieuDe

        Dim rgSoDX As Excel.Range
        rgSoDX = ExcelSheets.Range("J6", "K6")
        rgSoDX.Merge(True)
        rgSoDX.MergeCells() = True
        rgSoDX.Font.Bold = True
        rgSoDX.Font.Color = RGB(0, 0, 255)
        rgSoDX.HorizontalAlignment = XlHAlign.xlHAlignRight
        rgSoDX.Value = txtSoDeXuat.Text

        Dim From As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "From", commons.Modules.TypeLanguage)
        Dim rgFrom As Excel.Range
        rgFrom = ExcelSheets.Range("A10", "C10")
        rgFrom.Merge(True)
        rgFrom.MergeCells() = True
        rgFrom.Value = From & " : " & cbxPhongYeuCau.Text

        Dim NgayLap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "NgayLap", commons.Modules.TypeLanguage)
        Dim rgNgayLap As Excel.Range
        rgNgayLap = ExcelSheets.Range("A11", "C11")
        rgNgayLap.Merge(True)
        rgNgayLap.MergeCells() = True
        rgNgayLap.Value = NgayLap & " : " & mtxtNgayLap.Text

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 260, 78, 70, 15)
            .Name = "k11"
            .TextFrame.Characters.Text = "REQUESTER"
            .TextFrame.Characters.Font.Size = 10
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 260, 93, 70, 40)
            .Name = "k21"
        End With

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 330, 78, 70, 15)
            .Name = "k12"
            .TextFrame.Characters.Text = "SUPERVISOR"
            .TextFrame.Characters.Font.Size = 10
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 330, 93, 70, 40)
            .Name = "k22"
        End With

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 400, 78, 66, 15)
            .Name = "K13"
            .TextFrame.Characters.Text = "A.DIRECTOR"
            .TextFrame.Characters.Font.Size = 10
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 400, 93, 66, 40)
            .Name = "k23"
        End With

        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 260, 133, 70, 15)
            .Name = "K31"
            .TextFrame.Characters.Text = "S.MANAGER"
            .TextFrame.Characters.Font.Size = 10
            .TextFrame.Characters.Font.Bold = True
            .TextFrame.HorizontalAlignment = XlHAlign.xlHAlignCenter
            .TextFrame.VerticalAlignment = XlVAlign.xlVAlignCenter
        End With
        With ExcelSheets.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 260, 148, 70, 40)
            .Name = "k41"
        End With
        Dim ASGroup As Object() = New Object() {"k11", "k12", "k13", "k21", "k22", "k23", "k31", "k41"}
        ExcelSheets.Shapes.Range(ASGroup).Group()

        Dim rgUse As Excel.Range
        rgUse = ExcelSheets.Range("A14", "K14")
        rgUse.Merge(True)
        rgUse.MergeCells() = True
        rgUse.Font.Bold = True
        rgUse.Font.Size = 12
        rgUse.Font.Color = RGB(255, 0, 255)
        rgUse.HorizontalAlignment = XlHAlign.xlHAlignLeft
        rgUse.Value = txtGhiChu.Text

        'Ly do mua hang
        Dim rgLyDo As Excel.Range
        rgLyDo = ExcelSheets.Range("A16", "K16")
        rgLyDo.Merge(True)
        rgLyDo.MergeCells() = True
        rgLyDo.Font.Bold = True
        rgLyDo.Font.Size = 12
        rgLyDo.Font.Color = RGB(0, 0, 255)
        rgLyDo.HorizontalAlignment = XlHAlign.xlHAlignLeft
        rgLyDo.Value = "USE PURPOSE:"

        ' Tieu de columns
        Dim stt As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "NO", commons.Modules.TypeLanguage)
        Dim material As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "MATERIAL_NAME", commons.Modules.TypeLanguage)
        Dim spec As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "SPEC", commons.Modules.TypeLanguage)
        Dim unit As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "UNIT", commons.Modules.TypeLanguage)
        Dim Min As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "MIN", commons.Modules.TypeLanguage)
        Dim Max As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "MAX", commons.Modules.TypeLanguage)
        Dim inventory As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "INVENTORY", commons.Modules.TypeLanguage)
        Dim quantity As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "QUANTITY", commons.Modules.TypeLanguage)
        Dim remark As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "REMARK", commons.Modules.TypeLanguage)
        Dim unitprice As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "PRICE", commons.Modules.TypeLanguage)
        Dim amount As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "frmDeXuatMuaHang_CS", "AMOUNT", commons.Modules.TypeLanguage)

        With ExcelSheets
            .Range("A18", "A18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A18", "A18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A18", "A18").Font.Bold = True
            .Range("A18", "A18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A18", "A18").Value = stt

            .Range("B18", "B18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("B18", "B18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("B18", "B18").Font.Bold = True
            .Range("B18", "B18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("B18", "B18").Value = material

            .Range("C18", "C18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("C18", "C18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("C18", "C18").Font.Bold = True
            .Range("C18", "C18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("C18", "C18").Value = spec

            .Range("D18", "D18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("D18", "D18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("D18", "D18").Font.Bold = True
            .Range("D18", "D18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("D18", "D18").Value = unit

            .Range("E18", "E18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("E18", "E18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("E18", "E18").Font.Bold = True
            .Range("E18", "E18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E18", "E18").Value = Min

            .Range("F18", "F18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("F18", "F18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("F18", "F18").Font.Bold = True
            .Range("F18", "F18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F18", "F18").Value = Max

            .Range("G18", "G18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("G18", "G18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("G18", "G18").Font.Bold = True
            .Range("G18", "G18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G18", "G18").Value = inventory

            .Range("H18", "H18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("H18", "H18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("H18", "H18").Font.Bold = True
            .Range("H18", "H18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H18", "H18").Value = quantity

            .Range("I18", "I18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("I18", "I18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("I18", "I18").Font.Bold = True
            .Range("I18", "I18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("I18", "I18").Value = remark

            .Range("J18", "J18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("J18", "J18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("J18", "J18").Font.Bold = True
            .Range("J18", "J18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("J18", "J18").Value = unitprice

            .Range("K18", "K18").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("K18", "K18").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("K18", "K18").Font.Bold = True
            .Range("K18", "K18").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("K18", "K18").Value = amount
        End With

        Dim vtbData As New System.Data.DataTable()
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GET_DEXUAT_MUA_HANG_CS", txtSoDeXuat.Text.Trim))

        Dim row As Integer = 19
        For i As Integer = 0 To vtbData.Rows.Count - 1
            With ExcelSheets
                .Range("A" & row + i, "A" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("A" & row + i, "A" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("A" & row + i, "A" & row + i).Font.Bold = False
                .Range("A" & row + i, "A" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A" & row + i, "A" & row + i).Value = i + 1

                .Range("B" & row + i, "B" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("B" & row + i, "B" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("B" & row + i, "B" & row + i).Font.Bold = False
                .Range("B" & row + i, "B" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("B" & row + i, "B" & row + i).Value = vtbData.Rows(i)("TEN_PT")

                .Range("C" & row + i, "C" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("C" & row + i, "C" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("C" & row + i, "C" & row + i).Font.Bold = False
                .Range("C" & row + i, "C" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("C" & row + i, "C" & row + i).Value = vtbData.Rows(i)("QUY_CACH")

                .Range("D" & row + i, "D" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("D" & row + i, "D" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("D" & row + i, "D" & row + i).Font.Bold = False
                .Range("D" & row + i, "D" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("D" & row + i, "D" & row + i).Value = vtbData.Rows(i)("TEN_1")

                .Range("E" & row + i, "E" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("E" & row + i, "E" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("E" & row + i, "E" & row + i).Font.Bold = False

                .Range("E" & row + i, "E" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("E" & row + i, "E" & row + i).Value = vtbData.Rows(i)("TON_MIN")

                .Range("F" & row + i, "F" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("F" & row + i, "F" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("F" & row + i, "F" & row + i).Font.Bold = False
                .Range("F" & row + i, "F" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("F" & row + i, "F" & row + i).Value = vtbData.Rows(i)("TON_MAX")

                .Range("G" & row + i, "G" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("G" & row + i, "G" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("G" & row + i, "G" & row + i).Font.Bold = False
                .Range("G" & row + i, "G" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G" & row + i, "G" & row + i).Value = vtbData.Rows(i)("TON_KHO")

                .Range("H" & row + i, "H" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("H" & row + i, "H" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("H" & row + i, "H" & row + i).Font.Bold = False
                .Range("H" & row + i, "H" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("H" & row + i, "H" & row + i).Value = vtbData.Rows(i)("SO_LUONG")

                .Range("I" & row + i, "I" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("I" & row + i, "I" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("I" & row + i, "I" & row + i).Font.Bold = False
                .Range("I" & row + i, "I" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("I" & row + i, "I" & row + i).Value = vtbData.Rows(i)("GHI_CHU")

                .Range("J" & row + i, "J" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("J" & row + i, "J" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("J" & row + i, "J" & row + i).Font.Bold = False
                .Range("J" & row + i, "J" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("J" & row + i, "J" & row + i).Value = vtbData.Rows(i)("THANH_TIENNT")

                .Range("K" & row + i, "K" & row + i).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("K" & row + i, "K" & row + i).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("K" & row + i, "K" & row + i).Font.Bold = False
                .Range("K" & row + i, "K" & row + i).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("K" & row + i, "K" & row + i).Value = vtbData.Rows(i)("THANH_TIEN")

            End With
        Next
        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuyet.Click
        If QuyenDuyet() = True Then
            If MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CO_CHAC_MUON_DUYET_KO", commons.Modules.TypeLanguage), Me.Name, MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE dbo.DE_XUAT_MUA_HANG SET DUYET = 1 WHERE SO_DE_XUAT = '" + txtSoDeXuat.Text.Trim + "'")
                LoadData()
                BindData()
                LockControl()
                LockChiTiet()
                LockInput(True)
            Else
                Exit Sub
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "KHONG_CO_QUYEN_DUYET", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
    End Sub

    Private Sub btnChonVTPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonVTPT.Click

        If txtSoDeXuat.Text.Trim = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_TAO_SO_DE_XUAT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            txtSoDeXuat.Focus()
            Exit Sub
        End If


        If mtxtNgayLap.Text.Trim = "/  /" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_TAO_NGAY_LAP", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            mtxtNgayLap.Focus()
            Exit Sub
        End If


        Try
            If cbxPhongYeuCau.Text.Trim = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_CHON_PHONG_YEU_CAU", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                cbxPhongYeuCau.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try


        Dim str As String = ""
        Try
            str = "IF EXISTS ( SELECT * FROM dbo.SYSOBJECTS WHERE [NAME] = 'tmpChonPT" & Commons.Modules.UserName & "') drop table [dbo].[tmpChonPT" & Commons.Modules.UserName & "]"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Try
            str = "IF NOT EXISTS ( SELECT * FROM dbo.SYSOBJECTS WHERE [NAME] = 'tmpChonPT" & Commons.Modules.UserName & "') " & _
            " Create table dbo.tmpChonPT" & Commons.Modules.UserName & "(MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255),DVT NVARCHAR(20),SLTON FLOAT, TON_TOI_THIEU FLOAT ,NGAY_CUOI DATETIME ,SO_DE_XUAT NVARCHAR(30), " & _
            " SO_LUONG FLOAT, DON_GIA FLOAT,NGOAI_TE NVARCHAR(5), TI_GIA FLOAT , THANH_TIENNT FLOAT , THANH_TIEN FLOAT, GHI_CHU NVARCHAR(100) )"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        Dim vt As System.Data.DataTable = CType(grdChiTietDX.DataSource, System.Data.DataTable)
        For Each vrg As DataGridViewRow In grdChiTietDX.Rows
            '            Dim vs As String = "INSERT INTO tmpChonPT" + Commons.Modules.UserName & _
            '"(MS_PT, TEN_PT, DVT, SLTON, TON_TOI_THIEU, NGAY_CUOI, SO_DE_XUAT, SO_LUONG, DON_GIA, NGOAI_TE, TI_GIA, THANH_TIENNT, THANH_TIEN,GHI_CHU)" & _
            '" VALUES ('" + vrg.Cells("MS_PT").Value.ToString + "',N'" + vrg.Cells("TEN_PT").Value.ToString + "',N'" + vrg.Cells("DVT").Value.ToString + "','" + vrg.Cells("TON_MAX").Value.ToString & _
            '"','" + vrg.Cells("TON_MIN").Value.ToString + "','" + "" + "','" + txtSoDeXuat.Text.Trim & _
            '"','" + vrg.Cells("SO_LUONG").Value.ToString + "','" + vrg.Cells("DON_GIA").Value.ToString + "','" + vrg.Cells("NGOAI_TE").Value.ToString + "','" + vrg.Cells("TI_GIA").Value.ToString + "','" & _
            'vrg.Cells("THANH_TIEN_NT").Value.ToString + "','" + vrg.Cells("THANH_TIEN").Value.ToString + "',N'" + vrg.Cells("GHI_CHU").Value.ToString + "')"


            Dim SQL As String = "INSERT INTO tmpChonPT" + Commons.Modules.UserName & _
"(MS_PT, TEN_PT, DVT, SLTON, TON_TOI_THIEU, NGAY_CUOI, SO_DE_XUAT, SO_LUONG, DON_GIA, NGOAI_TE, TI_GIA, THANH_TIENNT, THANH_TIEN,GHI_CHU)" & _
" VALUES ('" + vrg.Cells("MS_PT").Value.ToString + "',N'" + vrg.Cells("TEN_PT").Value.ToString + "',N'" + vrg.Cells("DVT").Value.ToString + "','" + vrg.Cells("TON_MAX").Value.ToString & _
"','" + vrg.Cells("TON_MIN").Value.ToString + "','" + "" + "','" + txtSoDeXuat.Text.Trim & _
"','" + vrg.Cells("SO_LUONG").Value.ToString + "','" + vrg.Cells("DON_GIA").Value.ToString + "','" + vrg.Cells("NGOAI_TE").Value.ToString + "','" + vrg.Cells("TI_GIA").Value.ToString + "','" & _
vrg.Cells("THANH_TIENNT").Value.ToString + "','" + vrg.Cells("THANH_TIEN").Value.ToString + "',N'" + vrg.Cells("GHI_CHU").Value.ToString + "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SQL)
        Next

        Try
            str = "Delete dbo.tmpChonPT" & Commons.Modules.UserName & " WHERE SO_DE_XUAT <> '" + txtSoDeXuat.Text.Trim + "'"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try

        str = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPT" & Commons.Modules.UserName & "]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)" & _
        " drop procedure [dbo].[InsertPT" & Commons.Modules.UserName & "]"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        str = " CREATE PROCEDURE [dbo].[InsertPT" & Commons.Modules.UserName & "] @MS_PT NVARCHAR(25),@TEN_PT NVARCHAR(255),@DVT NVARCHAR(50),@SLTON FLOAT, @TON_TOI_THIEU FLOAT, @NGAY_CUOI DATETIME, @SO_DE_XUAT NVARCHAR(30)  AS " & _
        " INSERT INTO tmpChonPT" & Commons.Modules.UserName & " (MS_PT,TEN_PT,DVT,SLTON,TON_TOI_THIEU,NGAY_CUOI,SO_DE_XUAT) VALUES(@MS_PT,@TEN_PT,@DVT,@SLTON,@TON_TOI_THIEU,@NGAY_CUOI,@SO_DE_XUAT) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

        Dim frm As frmChonPTDeXuat_CS = New frmChonPTDeXuat_CS()
        frm.vSoDeXuat = txtSoDeXuat.Text.Trim
        frm.ShowDialog()
        If frm.vEventS = "OK" Then
            grdChiTietDX.DataSource = Nothing
            grdChiTietDX.DataSource = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "H_DE_XUAT_MUA_HANG_CS_CHON_VTPT_ADD", Commons.Modules.UserName).Tables(0)
        End If

    End Sub

    Private Sub btnTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTM.Click
        If txtSoDeXuat.Text.Trim.Length > 3 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_NHO_HON_3_KT", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        If txtSoDeXuat.Text.Trim.Length = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BAN_CHUA_NHAP_KI_HIEU_MA", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Vietsoft.Admin.Adminvs.ConnectionString = Commons.IConnections.ConnectionString
        Me.txtSoDeXuat.Text = Vietsoft.Admin.IDvs.CREATE_ID(txtSoDeXuat.Text.Trim.ToUpper)

    End Sub

    Private Sub mtxtNgayLap_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtNgayLap.Validating
        Try
            vNgayLap = DateTime.ParseExact(mtxtNgayLap.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
        End Try
    End Sub

    Private Sub mtxtNgayGiao_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtNgayGiao.Validating
        Try
            Dim vNG As New DateTime
            vNG = DateTime.ParseExact(mtxtNgayGiao.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
        End Try
    End Sub

    Private Sub grdChiTietDX_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdChiTietDX.CellValidating
        Try
            If Me.btnKhongGhi.Focused Then
                Exit Sub
            End If
            If btnGhi.Visible Then
                If e.RowIndex < grdChiTietDX.Rows.Count Then
                    'Me.grdChiTietDX.Columns("SO_LUONG").DefaultCellStyle.Format = "#,###"
                    'Me.grdChiTietDX.Columns("DON_GIA").DefaultCellStyle.Format = "#,###.##"
                    'Me.grdChiTietDX.Columns("TI_GIA").DefaultCellStyle.Format = "#,###.00"
                    'Me.grdChiTietDX.Columns("THANH_TIENNT").DefaultCellStyle.Format = "#,###.00"
                    'Me.grdChiTietDX.Columns("THANH_TIEN").DefaultCellStyle.Format = "#,###.00"

                    If grdChiTietDX.Columns(e.ColumnIndex).Name = "SO_LUONG" Then
                        If e.FormattedValue <> "" Then
                            If e.FormattedValue <= 0 Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SL_LON_HON_KO", commons.Modules.TypeLanguage))
                                e.Cancel = True
                                Exit Sub
                            Else
                                Me.grdChiTietDX.Rows(e.RowIndex).Cells("THANH_TIENNT").Value = e.FormattedValue * Me.grdChiTietDX.Rows(e.RowIndex).Cells("DON_GIA").Value * GetTI_GIA_USD(Me.grdChiTietDX.Rows(e.RowIndex).Cells("NGOAI_TE").Value)
                                Me.grdChiTietDX.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdChiTietDX.Rows(e.RowIndex).Cells("DON_GIA").Value * Me.grdChiTietDX.Rows(e.RowIndex).Cells("TI_GIA").Value
                            End If
                        End If
                    ElseIf grdChiTietDX.Columns(e.ColumnIndex).Name = "DON_GIA" Then
                        If e.FormattedValue <> "" Then
                            If e.FormattedValue < 0 Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DG_LON_HON_KO", commons.Modules.TypeLanguage))
                                e.Cancel = True
                                Exit Sub
                            Else
                                Me.grdChiTietDX.Rows(e.RowIndex).Cells("THANH_TIENNT").Value = e.FormattedValue * Me.grdChiTietDX.Rows(e.RowIndex).Cells("SO_LUONG").Value * GetTI_GIA_USD(Me.grdChiTietDX.Rows(e.RowIndex).Cells("NGOAI_TE").Value)
                                Me.grdChiTietDX.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdChiTietDX.Rows(e.RowIndex).Cells("SO_LUONG").Value * Me.grdChiTietDX.Rows(e.RowIndex).Cells("TI_GIA").Value
                            End If
                        End If
                    ElseIf grdChiTietDX.Columns(e.ColumnIndex).Name = "NGOAI_TE" Then
                        Me.grdChiTietDX.Rows(e.RowIndex).Cells("TI_GIA").Value = GetTI_GIA(e.FormattedValue)

                        Me.grdChiTietDX.Rows(e.RowIndex).Cells("THANH_TIENNT").Value = Me.grdChiTietDX.Rows(e.RowIndex).Cells("SO_LUONG").Value * Me.grdChiTietDX.Rows(e.RowIndex).Cells("DON_GIA").Value * GetTI_GIA_USD(e.FormattedValue)
                        Me.grdChiTietDX.Rows(e.RowIndex).Cells("THANH_TIEN").Value = Me.grdChiTietDX.Rows(e.RowIndex).Cells("SO_LUONG").Value * Me.grdChiTietDX.Rows(e.RowIndex).Cells("DON_GIA").Value * GetTI_GIA(e.FormattedValue)

                    ElseIf grdChiTietDX.Columns(e.ColumnIndex).Name = "TI_GIA" Then
                        If e.FormattedValue.Equals("") = False Then
                            If e.FormattedValue = 0 Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgTyGia", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                                e.Cancel = True
                                Exit Sub
                            Else
                                Me.grdChiTietDX.Rows(e.RowIndex).Cells("THANH_TIEN").Value = e.FormattedValue * Me.grdChiTietDX.Rows(e.RowIndex).Cells("DON_GIA").Value * Me.grdChiTietDX.Rows(e.RowIndex).Cells("SO_LUONG").Value
                            End If
                        Else
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgCheckTyGiaNull", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                            grdChiTietDX.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                            e.Cancel = True
                            Exit Sub
                        End If

                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdChiTietDX_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdChiTietDX.DataError
        If TypeOf e.Exception Is FormatException Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
            e.ThrowException = False
        End If
    End Sub

    Private Sub txtSoDeXuat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSoDeXuat.Validating

    End Sub
#End Region

    Private Sub cbxThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbxThang.SelectedIndexChanged
        Try
            vThang = DateTime.ParseExact("01/" + cbxThang.Text.Trim, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            vThang = DateTime.Now.Date
        End Try
        LoadData()
        BindData()
        LockControl()
    End Sub

    Private Sub rdbDaDuyet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles rdbDaDuyet.CheckedChanged
        LoadData()
        BindData()
        LockControl()
    End Sub

End Class