Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Public Class frmLocThoigianngungmay
    Dim TbTB As New System.Data.DataTable()
    Dim TbTenTB As New System.Data.DataTable()
    Dim _loc As Collection
    Dim _key As String
#Region "Prop"
    Private _diaDiem As String
    Public _mytable As DataTable = New DataTable()

    Public Property DiaDiem() As String
        Get
            Return _diaDiem
        End Get
        Set(ByVal value As String)
            _diaDiem = value
        End Set
    End Property
    Private _dayChuyen As String

    Public Property DayChuyen() As String
        Get
            Return _dayChuyen
        End Get
        Set(ByVal value As String)
            _dayChuyen = value
        End Set
    End Property
    Private _loaiDungmay As String

    Public Property LoaiDungMay() As String
        Get
            Return _loaiDungmay
        End Get
        Set(ByVal value As String)
            _loaiDungmay = value
        End Set
    End Property
    Private _thietbi As String

    Public Property Thietbi() As String
        Get
            Return _thietbi
        End Get
        Set(ByVal value As String)
            _thietbi = value
        End Set
    End Property
    Private _mathietbi As String

    Public Property MaThietbi() As String
        Get
            Return _mathietbi
        End Get
        Set(ByVal value As String)
            _mathietbi = value
        End Set
    End Property
    Private _tungay As DateTime

    Public Property Tungay() As DateTime
        Get
            Return _tungay
        End Get
        Set(ByVal value As DateTime)
            _tungay = value
        End Set
    End Property
    Private _denngay As DateTime

    Public Property Denngay() As DateTime
        Get
            Return _denngay
        End Get
        Set(ByVal value As DateTime)
            _denngay = value
        End Set
    End Property
    Private _city As String
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property
    Private _street As String
    Public Property Street() As String
        Get
            Return _street
        End Get
        Set(ByVal value As String)
            _street = value
        End Set
    End Property
    Private _district As String
    Public Property District() As String
        Get
            Return _district
        End Get
        Set(ByVal value As String)
            _district = value
        End Set
    End Property
#End Region
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal loc As Collection, ByVal key As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _loc = loc
        _key = key
    End Sub
    Sub LoadDiadiem()
        Dim _table As DataTable = New DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cboDiadiem.DisplayMember = "TEN_N_XUONG"
        cboDiadiem.ValueMember = "MS_N_XUONG"
        cboDiadiem.DataSource = _table
        _mytable = _table
        Try
            If _loc Is Nothing Then
                cboDiadiem.SelectedIndex = 0
            Else
                cboDiadiem.SelectedValue = _loc.Item(_key)(1).ToString()
            End If
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub LoadCity()

        Try
            cmbCity.ValueMember = "ma_qg"
            cmbCity.DisplayMember = "ten_qg"

            Dim _table As DataTable = New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"))
            cmbCity.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDistrict()

        Try
            cmbDistrict.ValueMember = "ma_qg"
            cmbDistrict.DisplayMember = "ten_qg"

            Dim _table As DataTable = New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District", cmbCity.SelectedValue.ToString()))
            cmbDistrict.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadStreet()

        Try
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"

            Dim _table As DataTable = New DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString()))
            cmbStreet.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThuchien.Click
        'frmThoiGianNgungMayNew.Loc.Add()
        _city = cmbCity.SelectedValue.ToString()
        _district = cmbDistrict.SelectedValue.ToString()
        _street = cmbStreet.SelectedValue.ToString()
        _diaDiem = cboDiadiem.SelectedValue.ToString()
        _dayChuyen = cboDaychuyen.SelectedValue.ToString()
        _loaiDungmay = cboLoaiDungmay.SelectedValue.ToString()
        _thietbi = cboThietbi.SelectedValue.ToString()
        _mathietbi = cboMaTB.SelectedValue.ToString()
        _tungay = dtpTungay.Value
        _denngay = dtpDenngay.Value
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmLocThoigianngungmay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            TbTB = New DataTable
            TbTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT MAY.MS_MAY, MAY.TEN_MAY FROM dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY ORDER BY TEN_MAY"))
            TbTenTB = TbTB.Copy
        Catch ex As Exception

        End Try

        Try

            LoadCity()
            LoadDiadiem()
            Loaddaychuyen()
            LoadTenThietbi()
            LoadThietbi()

            LoadLoaidungmay()
            RefeshLanguage()
            dtpDenngay.Value = DateTime.Now
            dtpTungay.Value = DateTime.Now.AddMonths(-1)
        Catch ex As Exception

        End Try

    End Sub

    Sub RefeshLanguage()
        Me.lblDaychuyen.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Day_chuyen", Commons.Modules.TypeLanguage)
        Me.lblDenngay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DEN_NGAY", Commons.Modules.TypeLanguage)
        Me.lblDiadiem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DIA_DIEM", Commons.Modules.TypeLanguage)
        Me.lblLoaidungmay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAI_DUNG_MAY", Commons.Modules.TypeLanguage)
        'Me.lblLocthoigianngungmay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOC_THOI_GIAN_NGUNG_MAY", Commons.Modules.TypeLanguage)
        Me.lblThietbi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THIET_BI", Commons.Modules.TypeLanguage)
        Me.lblMaTB.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblMaTB", Commons.Modules.TypeLanguage)
        Me.lblTungay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TU_NGAY", Commons.Modules.TypeLanguage)
        Me.lblCity.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblCity", Commons.Modules.TypeLanguage)
        Me.lblDistrict.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblDistrict", Commons.Modules.TypeLanguage)
        Me.lblStreet.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "lblStreet", Commons.Modules.TypeLanguage)
        Me.btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thoat", Commons.Modules.TypeLanguage)
        Me.btnThuchien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Thuchien", Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "frmLocthoigianngungmay", Commons.Modules.TypeLanguage)

    End Sub

    Private Sub LoadLoaidungmay()
        Try
            Dim SqlDeXuatMuaHang As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

            Dim Tb As New System.Data.DataTable()
            Tb.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY"))
            AddItemAll(cboLoaiDungmay, Tb, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN")
            Try
                If _loc Is Nothing Then
                    cboLoaiDungmay.SelectedIndex = 0
                Else
                    cboLoaiDungmay.SelectedValue = _loc.Item(_key)(3).ToString()
                End If
            Catch ex As Exception

            End Try
        Catch
        End Try
    End Sub

    'Private Sub LoadDiadiem()
    '    Dim Sqlin As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

    '    Dim Tbnhaxuong As New System.Data.DataTable()
    '    Tbnhaxuong.Load(Sqlin.ExecuteReader(CommandType.StoredProcedure, "GET_NHA_XUONG", Vietsoft.Information.Username))

    '    AddItemAll(cboDiadiem, Tbnhaxuong, "MS_N_XUONG", "Ten_N_XUONG")
    'End Sub

    Private Sub Loaddaychuyen()
        Dim Sqlin As New Vietsoft.SqlInfo(Commons.IConnections.ConnectionString)

        Dim Tbndaychuyen As New System.Data.DataTable()
        Tbndaychuyen.Load(Sqlin.ExecuteReader(CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG FROM DBO.HE_THONG UNION SELECT '0', ''"))
        AddItemAll(cboDaychuyen, Tbndaychuyen, "MS_HE_THONG", "TEN_HE_THONG")
        Try
            If _loc Is Nothing Then
                cboDaychuyen.SelectedIndex = 0
            Else
                cboDaychuyen.SelectedValue = _loc.Item(_key)(0).ToString()
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub LoadThietbi()

        'Dim Tb As New System.Data.DataTable()
        'Tb.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, "SELECT DISTINCT MAY.MS_MAY, MAY.TEN_MAY FROM dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY"))
        AddItemAll(cboThietbi, TbTB, "MS_MAY", "TEN_MAY")
        Try
            If _loc Is Nothing Then
                cboThietbi.SelectedIndex = 0
            Else
                cboThietbi.SelectedValue = _loc.Item(_key)(2).ToString()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadTenThietbi()

        'Dim Tb As New System.Data.DataTable()
        'Tb.Load(SqlDeXuatMuaHang.ExecuteReader(CommandType.Text, "SELECT DISTINCT MAY.MS_MAY, MAY.TEN_MAY FROM dbo.MAY INNER JOIN dbo.NHOM_MAY ON dbo.MAY.MS_NHOM_MAY = dbo.NHOM_MAY.MS_NHOM_MAY"))


        AddItemAll(cboMaTB, TbTenTB, "MS_MAY", "MS_MAY")
        Try
            If _loc Is Nothing Then
                cboMaTB.SelectedIndex = 0
            Else
                cboMaTB.SelectedValue = _loc.Item(_key)(4).ToString()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddItemAll(ByVal cbo As ComboBox, ByVal dt As DataTable, ByVal value As String, ByVal display As String)
        Dim dtRow As DataRow
        Dim _itemAll As String = "-- < ALL > --"
        If dt.Rows.Count > 0 Then
            dtRow = dt.NewRow()
            dtRow(value) = -1
            dtRow(display) = _itemAll
            dt.Rows.InsertAt(dtRow, 0)
        End If
        cbo.DataSource = dt
        cbo.ValueMember = value
        cbo.DisplayMember = display
        

    End Sub

    Private Sub cmbCity_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCity.SelectedValueChanged
        LoadDistrict()
    End Sub

    Private Sub cmbDistrict_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectedValueChanged
        LoadStreet()
    End Sub

    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStreet.SelectedValueChanged
        LoadDiadiem()
    End Sub
End Class