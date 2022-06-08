
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Common.Data
Imports Commons.QL.Events
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Commons
Imports DevExpress.XtraEditors

Public Class FrmPhieuNhapKhoVatTu

    Private callback As New QLCallBackEvent
    Dim objDonHangNhapPT As IC_DON_HANG_NHAP_Info = New IC_DON_HANG_NHAP_Info
    Dim objDonHangNhapPTController As New IC_DON_HANG_NHAP_Controller
    Dim lstDonHangNhapVatTu As List(Of IC_DON_HANG_NHAP_VAT_TU_Info) = New List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
    Dim hasListVTSL As New Hashtable
    Dim hasTmp As New Hashtable
    Dim MaPT As String = ""
    Dim status As Boolean = True
    Dim actionButton As Boolean = False
    Dim blnTT As Boolean = False

    Private blnLoad As Boolean = False
    Private intRowDHN As Integer = -1
    Private MS_PT_Current As String
    Private iTrangThai As Integer = -1          '1: thêm        2: sửa

    Private Sub FrmPhieuNhapKhoVatTu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub FrmPhieuNhapKhoVatTu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LOAD_FORM()
    End Sub

#Region "Function Local"

    Public Sub LOAD_FORM()
        If Check_User_Form() Then
            LoadDiem()
            Commons.Modules.ObjSystems.DinhDang()
            Commons.Modules.ObjSystems.ThayDoiNN(Me)
            lblCURRENT_DATE_VALUE.Text = Now.Day.ToString + "/" + Now.Month.ToString + "/" + Now.Year.ToString
            cboKHO.ClassName = "frmKho"
            cboKHO.Param = Commons.Modules.UserName
            cboKHO.BindDataSource()
            cboKHO.SelectedValue = 2
            cboDANG_NHAP.BindDataSource()
            'cboDiem1.BindDataSource()
            cboFilter.BindDataSource()
            cboLockho.Param = Commons.Modules.UserName
            cboLockho.BindDataSource()
            Me.utcTextTiGia.Text = objDonHangNhapPTController.Load_Ngoai_Te
            Load_Nguoi_Nhap()
            AddHandler cboDANG_NHAP.SelectedValueChanged, AddressOf Me.cboDANG_NHAP_SelectedValueChanged
            AddHandler cboLockho.SelectedIndexChanged, AddressOf Me.utcComboStock_SelectedIndexChanged
            AddHandler cboFilter.SelectedIndexChanged, AddressOf Me.cboFilter_SelectedIndexChanged
            AddHandler callback.OnCallBack, AddressOf CallBack_Data
            cboLockho.SelectedValue = 2
            Load_Danh_Sach_PN(CreateQuery())
            Dim iijj As Integer = grdDanhsachNhapkhoPT.RowCount

            Show()
            SetVisibleButton(True)
            EnableControl(False)
            If grdDanhsachNhapkhoPT.RowCount <= 0 Then
                Enable_Button(False)
            Else
                Enable_Button(True)
            End If
            blnLoad = True
            Try
                Load_Phieu_Nhap(0, False)
            Catch ex As Exception

            End Try
            FormatGridViTriKho()
            FormatGridNhapKhoPTCT()
            SetReadOnlyColumn(True)
            If cboLockho.Items.Count > 0 Then cboLockho.SelectedIndex = 0
            lblSHOW_TIEN_TE.Text = lblSHOW_TIEN_TE.Text & ": " & utcTextTiGia.Text
        End If
    End Sub

    Sub LoadDiem()
        Dim vtbdiem As New DataTable
        vtbdiem.Columns.Add("DIEM", Type.GetType("System.Int16"))
        Dim vr As DataRow
        vr = vtbdiem.NewRow

        vr("DIEM") = 1
        vtbdiem.Rows.Add(vr)
        vr = vtbdiem.NewRow
        vr("DIEM") = 2
        vtbdiem.Rows.Add(vr)
        vr = vtbdiem.NewRow
        vr("DIEM") = 3
        vtbdiem.Rows.Add(vr)
        vr = vtbdiem.NewRow
        vr("DIEM") = 4
        vtbdiem.Rows.Add(vr)
        vr = vtbdiem.NewRow
        vr("DIEM") = 5
        vtbdiem.Rows.Add(vr)

        cboDiem1.DataSource = vtbdiem.Copy()
        cboDiem1.DisplayMember = "DIEM"
        cboDiem1.ValueMember = "DIEM"

        cboDiem2.DataSource = vtbdiem.Copy()
        cboDiem2.DisplayMember = "DIEM"
        cboDiem2.ValueMember = "DIEM"

        cboDiem3.DataSource = vtbdiem.Copy()
        cboDiem3.DisplayMember = "DIEM"
        cboDiem3.ValueMember = "DIEM"




    End Sub

    Function Check_User_Form() As Boolean
        Dim authorized As String = objDonHangNhapPTController.Load_Authorized_User_Form(Name)
        Select Case authorized
            Case "Full access"
                EnableButoon_permission(True)
                actionButton = True
                Me.menuItemDelete.Visible = True
                Exit Select
            Case "Read only"
                EnableButoon_permission(False)
                Exit Select
            Case "No access"
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoAccess", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Dispose()
                Return False
                Exit Select
            Case Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoAccess1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                Dispose()
                Return False
                Exit Select
        End Select
        Return True
    End Function

    Sub LoadcboDDH()
        Try
            cboDDH.Display = "MS_DDH"
            cboDDH.Value = "MS_DDH"
            cboDDH.StoreName = "GetDON_DAT_HANG1"
            cboDDH.Param = txtMS_DH_NHAP.Text
            cboDDH.BindDataSource()
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadcboDXMH()
        cboDDH.Display = "MS_DDH"
        cboDDH.Value = "MS_DDH"
        cboDDH.StoreName = "GetDE_XUAT_MUA_HANG1"
        cboDDH.Param = txtMS_DH_NHAP.Text
        cboDDH.BindDataSource()
    End Sub

    Sub CallBack_Data(ByVal hasData As Hashtable)
        For i As Integer = 0 To hasData.Count - 1
            Dim objDonHangNhapVatTuInfo As New IC_DON_HANG_NHAP_VAT_TU_Info
            Dim flag As Boolean = True
            For j As Integer = 0 To lstDonHangNhapVatTu.Count - 1
                If hasData.Item(i).ToString.Equals(lstDonHangNhapVatTu.Item(j).MS_PT) Then
                    flag = False
                    Exit For
                End If
            Next
            If flag Then
                objDonHangNhapVatTuInfo.MS_PT = hasData.Item(i).ToString
                objDonHangNhapVatTuInfo.MS_DH_NHAP_PT = Me.txtMS_DH_NHAP.Text
                objDonHangNhapVatTuInfo.TY_GIA = Me.objDonHangNhapPTController.Load_Ty_Gia
                '--------------------
                objDonHangNhapVatTuInfo.TY_GIA_USD = Me.objDonHangNhapPTController.Load_Ty_Gia_USD
                objDonHangNhapVatTuInfo.NGOAI_TE = Me.objDonHangNhapPTController.Load_Ngoai_Te
                Dim objPhuTung As IC_PHU_TUNG_Info = Me.objDonHangNhapPTController.Load_Phu_Tung(objDonHangNhapVatTuInfo.MS_PT)
                objDonHangNhapVatTuInfo.TEN_PT = objPhuTung.TEN_PT
                objDonHangNhapVatTuInfo.DON_VI_TINH = objDonHangNhapPTController.Load_DON_VI_TINH(objPhuTung.DVT)
                objDonHangNhapVatTuInfo.DON_GIA = 0
                objDonHangNhapVatTuInfo.MS_VT_NCC = Nothing
                objDonHangNhapVatTuInfo.XUAT_XU = Nothing
                objDonHangNhapVatTuInfo.THANH_TIEN = 0
                objDonHangNhapVatTuInfo.SO_LUONG_CTU = 0
                objDonHangNhapVatTuInfo.SL_THUC_NHAP = 0
                lstDonHangNhapVatTu.Add(objDonHangNhapVatTuInfo)
                'Me.hasListVTSL.Add(objDonHangNhapVatTuInfo.MS_PT, Load_Vi_Tri_Kho(objDonHangNhapVatTuInfo.MS_PT))
            End If
        Next
        hasListVTSL.Clear()

        For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
            Dim tb As New DataTable()
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI," & lstDonHangNhapVatTu.Item(i).SL_THUC_NHAP & " AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "'").Tables(0)
            Me.hasListVTSL.Add(lstDonHangNhapVatTu.Item(i).MS_PT, tb)
        Next

        Me.grdNhapkhoPTCT.DataSource = Me.lstDonHangNhapVatTu

        Dim mc As CurrencyManager
        Me.grdNhapkhoPTCT.DataSource = Me.lstDonHangNhapVatTu
        mc = CType(Me.BindingContext(Me.grdNhapkhoPTCT.DataSource), CurrencyManager)
        If mc.Position < 0 Then
            mc.Position = mc.Position + 1
            mc.Refresh()
        End If
        Me.FormatGridNhapKhoPTCT()
        Me.SetReadOnlyColumn(False)
        'If lstDonHangNhapVatTu.Count > 0 Then
        '    MaPT = lstDonHangNhapVatTu.Item(0).MS_PT
        '    Me.grdSLtheoViTri.DataSource = Load_Vi_Tri_Kho(MaPT)
        'Else
        '    Me.grdSLtheoViTri.DataSource = Load_Vi_Tri_Kho("-1")
        'End If
    End Sub

    Sub FormatGridNhapKhoPTCT()
        If blnLoad And Me.grdNhapkhoPTCT.RowCount > 0 Then
            With Me.grdNhapkhoPTCT
                .Columns("MS_PT").Visible = False
                .Columns("SO_LUONG_CTU").Visible = False
                .Columns("SL_THUC_NHAP").Visible = False
                .Columns("DON_VI_TINH").Visible = False
                .Columns("MS_VT_NCC").Visible = False
                .Columns("XUAT_XU").Visible = False
                .Columns("BAO_HANH_DEN_NGAY").Visible = False
                .Columns("DON_GIA").Visible = False
                .Columns("NGOAI_TE").Visible = False
                .Columns("TY_GIA").Visible = False
                .Columns("TY_GIA_USD").Visible = False
                .Columns("THANH_TIEN").Visible = False
                .Columns("TEN_PT").Visible = False
                .Columns("MS_DH_NHAP_PT").Visible = False
                .Columns("SL_DA_SD").Visible = False
                .Columns("GHI_CHU").Visible = False
            End With
        Else
            grdNhapkhoPTCT.Columns.Clear()
        End If
        'het sua
        blnLoad = False

        Dim column As New DataGridViewTextBoxColumn
        Try
            column.Name = "MS_PT"
            column.DataPropertyName = "MS_PT"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.Width = 100
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "MS_VT_NCC"
            column.DataPropertyName = "MS_VT_NCC"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VT_NCC", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.Width = 100
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try
        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "TEN_PT"
            column.DataPropertyName = "TEN_PT"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.Width = 200
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "SO_LUONG_CTU"
            column.DataPropertyName = "SO_LUONG_CTU"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG_CTU", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            column.Width = 80
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "SL_THUC_NHAP"
            column.DataPropertyName = "SL_THUC_NHAP"
            column.DefaultCellStyle.Format = "N2"
            column.DefaultCellStyle.Format = "###.##"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_THUC_NHAP", Commons.Modules.TypeLanguage)
            ' column.ReadOnly = True
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            column.Width = 80
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "DON_VI_TINH"
            column.DataPropertyName = "DON_VI_TINH"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_VI_TINH", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            column.Width = 60
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "DON_GIA"
            column.DataPropertyName = "DON_GIA"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            column.DefaultCellStyle.Format = "#,##0.00"
            column.DefaultCellStyle.ForeColor = Color.Red
            column.Width = 100
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            Dim cboColumn = New Commons.QLGridComboBoxColumn
            cboColumn.Name = "NGOAI_TE"
            cboColumn.DataPropertyName = "NGOAI_TE"
            cboColumn.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGOAI_TE", Commons.Modules.TypeLanguage)
            cboColumn.DataSource = Me.objDonHangNhapPTController.Load_List_Ngoai_Te
            cboColumn.DisplayMember = "TEN_NGOAI_TE"
            cboColumn.ValueMember = "NGOAI_TE"
            Me.grdNhapkhoPTCT.Columns.Add(cboColumn)
        Catch ex As Exception
        End Try
        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "TY_GIA"
            column.DataPropertyName = "TY_GIA"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            column.Width = 65
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try
        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "TY_GIA_USD"
            column.DataPropertyName = "TY_GIA_USD"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TY_GIA_USD", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            column.Width = 80
            column.DefaultCellStyle.Format = "N2"
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "THANH_TIEN"
            column.DataPropertyName = "THANH_TIEN"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "THANH_TIEN", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            column.DefaultCellStyle.Format = "#,##0.00"
            column.Width = 100
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try
        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "XUAT_XU"
            column.DataPropertyName = "XUAT_XU"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "XUAT_XU", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.Width = 100
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try
        Try
            Dim dateColumn As New Commons.QLGridMaskedTextBoxColumn
            dateColumn.Name = "BAO_HANH_DEN_NGAY"
            dateColumn.Mask = "00/00/0000"
            dateColumn.DefaultCellStyle.Format = Nothing
            dateColumn.DataPropertyName = "BAO_HANH_DEN_NGAY"
            dateColumn.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "BAO_HANH_DEN_NGAY", Commons.Modules.TypeLanguage)
            Me.grdNhapkhoPTCT.Columns.Add(dateColumn)
        Catch ex As Exception
        End Try
        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "GHI_CHU"
            column.DataPropertyName = "GHI_CHU"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
            column.ReadOnly = True
            column.Width = 200
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try
        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "MS_DH_NHAP_PT"
            column.DataPropertyName = "MS_DH_NHAP_PT"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
            column.Visible = False
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try
        Try
            column = New DataGridViewTextBoxColumn
            column.Name = "SL_DA_SD"
            column.DataPropertyName = "SL_DA_SD"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_DA_SD", Commons.Modules.TypeLanguage)
            column.Visible = False
            Me.grdNhapkhoPTCT.Columns.Add(column)
        Catch ex As Exception
        End Try

        Try
            Me.grdNhapkhoPTCT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdNhapkhoPTCT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            grdNhapkhoPTCT.Columns("TY_GIA_USD").DefaultCellStyle.Format = "N6"
        Catch ex As Exception
        End Try
    End Sub

    Sub FormatGridViTriKho()
        Try


            Me.grdSLtheoViTri.Columns.Clear()

            Dim cboColumn = New Commons.QLGridComboBoxColumn
            cboColumn.Name = "MS_VI_TRI"
            cboColumn.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_VI_TRI", Commons.Modules.TypeLanguage)
            cboColumn.AutoComplete = True
            cboColumn.DataPropertyName = "MS_VI_TRI"
            If (cboKHO.SelectedValue) Is Nothing Then
                cboColumn.DataSource = Me.objDonHangNhapPTController.Load_Vi_Tri_Kho(-1)
            Else
                cboColumn.DataSource = Me.objDonHangNhapPTController.Load_Vi_Tri_Kho(Integer.Parse(cboKHO.SelectedValue.ToString))
            End If
            'Dim rNull As DataRow = CType(cboColumn.DataSource, DataTable).NewRow()
            'rNull("MS_VI_TRI") = DBNull.Value
            'rNull("TEN_VI_TRI") = DBNull.Value
            'CType(cboColumn.DataSource, DataTable).Rows.Add(rNull)
            cboColumn.DisplayMember = "TEN_VI_TRI"
            cboColumn.ValueMember = "MS_VI_TRI"
            cboColumn.ReadOnly = False
            Me.grdSLtheoViTri.Columns.Add(cboColumn)

            Dim column As New DataGridViewTextBoxColumn
            column = New DataGridViewTextBoxColumn
            column.Name = "SL_VT"
            column.DataPropertyName = "SL_VT"
            'column.DefaultCellStyle.Format = "###.##"
            column.DefaultCellStyle.Format = "N2"
            column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_LUONG", Commons.Modules.TypeLanguage)
            column.ReadOnly = False
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Me.grdSLtheoViTri.Columns.Add(column)
            column = New DataGridViewTextBoxColumn
            column.Name = "MS_DH_NHAP_PT"
            column.DataPropertyName = "MS_DH_NHAP_PT"
            column.Visible = False
            Me.grdSLtheoViTri.Columns.Add(column)
            column = New DataGridViewTextBoxColumn
            column.Name = "MS_PT"
            column.DataPropertyName = "MS_PT"
            column.Visible = False
            Me.grdSLtheoViTri.Columns.Add(column)
            column = New DataGridViewTextBoxColumn
            column.Name = "TEN_VI_TRI"
            column.DataPropertyName = "TEN_VI_TRI"
            column.Visible = False
            Me.grdSLtheoViTri.Columns.Add(column)
            Try
                Me.grdSLtheoViTri.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdSLtheoViTri.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
        If btnGhi.Visible Then
            Me.grdSLtheoViTri.ReadOnly = False
        Else
            Me.grdSLtheoViTri.ReadOnly = True
        End If
    End Sub

    Function CreateQuery() As String
        Dim dang_nhap As String = "DANG_NHAP_VIET"
        Select Case dang_nhap
            Case 1
                dang_nhap = "DANG_NHAP_ANH"
                Exit Select
            Case 2
                dang_nhap = "DANG_NHAP_HOA"
                Exit Select
        End Select
        Dim str As String = ""
        str = "SELECT PN.MS_DH_NHAP_PT,PN.SO_PHIEU_XN,KHCN.TEN_NGUOI_NHAP," + dang_nhap + " AS DANG_NHAP,CONVERT(CHAR(10),PN.NGAY,103) + ' ' + CONVERT(CHAR(8),PN.GIO,8) AS NGAY_NHAP,MS_DDH " & _
              "FROM IC_DON_HANG_NHAP PN INNER JOIN DANG_NHAP DN ON DN.MS_DANG_NHAP = PN.MS_DANG_NHAP INNER JOIN " & _
                     "KHACH_HANG_CONG_NHAN KHCN ON PN.MS_DANG_NHAP = KHCN.MS_DANG_NHAP AND PN.NGUOI_NHAP = KHCN.NGUOI_NHAP INNER JOIN " & _
                     "NHOM_KHO ON PN.MS_KHO = NHOM_KHO.MS_KHO INNER JOIN USERS ON NHOM_KHO.GROUP_ID = USERS.GROUP_ID WHERE 1=1 "
        '        " FROM IC_DON_HANG_NHAP PN INNER JOIN DANG_NHAP DN ON DN.MS_DANG_NHAP=PN.MS_DANG_NHAP " & _
        '       " INNER JOIN KHACH_HANG_CONG_NHAN KHCN  ON PN.MS_DANG_NHAP=KHCN.MS_DANG_NHAP AND PN.NGUOI_NHAP=KHCN.NGUOI_NHAP "
        If Me.cboLockho.SelectedValue IsNot Nothing Then
            If rdbDalock.Checked = True Then
                str += " AND PN.LOCK= 1"
            Else
                str += " AND PN.LOCK= 0"
            End If
            str += " AND PN.MS_KHO=" + Me.cboLockho.SelectedValue.ToString
            Dim temp As String = ""
            If Me.cboFilter.SelectedValue IsNot Nothing Then
                temp = Me.cboFilter.SelectedValue.ToString()
            End If
            If temp.Length > 0 Then
                Dim element() As String = temp.Split("/")
                str += " AND MONTH(NGAY)=" + element(0).ToString + " AND YEAR(NGAY)=" + element(1).ToString
            End If
        End If
        str += " AND USERS.USERNAME='" & Commons.Modules.UserName & "' ORDER BY PN.MS_DH_NHAP_PT DESC "

        Return str
    End Function

    Sub Load_Danh_Sach_PN(ByVal strQuery As String)
        'Dim tmp As Integer = intRowDHN
        Me.grdDanhsachNhapkhoPT.Columns.Clear()
        grdNhapkhoPTCT.Columns.Clear()
        grdSLtheoViTri.Columns.Clear()
        Me.grdDanhsachNhapkhoPT.DataSource = objDonHangNhapPTController.Load_Danh_Sach_DH_Nhap(strQuery)
        Me.grdDanhsachNhapkhoPT.Columns("MS_DH_NHAP_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
        Me.grdDanhsachNhapkhoPT.Columns("SO_PHIEU_XN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_PHIEU_NHAP", Commons.Modules.TypeLanguage)
        Me.grdDanhsachNhapkhoPT.Columns("TEN_NGUOI_NHAP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_NHAP", Commons.Modules.TypeLanguage)
        Me.grdDanhsachNhapkhoPT.Columns("TEN_NGUOI_NHAP").Width = 250
        Me.grdDanhsachNhapkhoPT.Columns("DANG_NHAP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DANG_NHAP", Commons.Modules.TypeLanguage)
        Me.grdDanhsachNhapkhoPT.Columns("NGAY_NHAP").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_NHAP", Commons.Modules.TypeLanguage)
        Me.grdDanhsachNhapkhoPT.Columns("MS_DDH").Visible = False
        If Me.grdDanhsachNhapkhoPT.RowCount > 0 Then
            'grdDanhsachNhapkhoPT.Rows(tmp).Cells(0).Selected = True
            BtnIn.Enabled = True
            Load_Phieu_Nhap(0, False)
            Me.grdDanhsachNhapkhoPT.Rows(0).Selected = True
        End If
        Try
            Me.grdDanhsachNhapkhoPT.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachNhapkhoPT.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            grdNhapkhoPTCT.Columns("TY_GIA_USD").DefaultCellStyle.Format = "N6"
        Catch ex As Exception
        End Try
    End Sub

    Sub Load_Phieu_Nhap(ByVal RowIndex As Integer, ByVal tabChanged As Boolean)
        If Me.grdDanhsachNhapkhoPT.RowCount > RowIndex Then
            If RowIndex < 0 Then
                objDonHangNhapPT = objDonHangNhapPTController.Load_Phieu_Nhap(txtMS_DH_NHAP.Text)
            Else
                objDonHangNhapPT = objDonHangNhapPTController.Load_Phieu_Nhap(Me.grdDanhsachNhapkhoPT.Rows(RowIndex).Cells("MS_DH_NHAP_PT").Value.ToString)

                Me.chkLock.Checked = objDonHangNhapPT.LOCK
                Me.txtMS_DH_NHAP.Text = objDonHangNhapPT.MS_DH_NHAP_PT
                Me.txtSO_PHIEU_NHAP.Text = objDonHangNhapPT.SO_PHIEU_XN
                Me.cboKHO.SelectedValue = objDonHangNhapPT.MS_KHO
                Dim time As String = ""
                If objDonHangNhapPT.GIO.Hour < 10 Then
                    time += "0" + objDonHangNhapPT.GIO.Hour.ToString + ":"
                Else
                    time += objDonHangNhapPT.GIO.Hour.ToString + ":"
                End If
                If objDonHangNhapPT.GIO.Minute < 10 Then
                    time += "0" + objDonHangNhapPT.GIO.Minute.ToString
                Else
                    time += objDonHangNhapPT.GIO.Minute.ToString
                End If
                Me.txtGIO_NHAP.Text = time
                Me.dtpNGAY_NHAP.Value = objDonHangNhapPT.NGAY
                Me.cboDANG_NHAP.SelectedValue = objDonHangNhapPT.MS_DANG_NHAP
                Load_Nguoi_Nhap()
                Me.cboNGUOI_NHAP.SelectedValue = objDonHangNhapPT.NGUOI_NHAP
                Me.dtpNGAY_CHUNG_TU.Value = objDonHangNhapPT.NGAY_CHUNG_TU
                Me.txtSO_CHUNG_TU.Text = objDonHangNhapPT.SO_CHUNG_TU
                Me.cboDiem1.SelectedValue = objDonHangNhapPT.DIEM
                Me.txtDANH_GIA.Text = objDonHangNhapPT.DANH_GIA
                Me.txtGhi_Chu.Text = objDonHangNhapPT.GHI_CHU

                Me.cboDiem2.SelectedValue = objDonHangNhapPT.DIEM1
                Me.cboDiem3.SelectedValue = objDonHangNhapPT.DIEM2


                If cboDANG_NHAP.SelectedValue = 21 Then
                    LoadcboDDH()
                ElseIf cboDANG_NHAP.SelectedValue = 28 Then
                    LoadcboDXMH()
                    Dim dtReader As SqlDataReader
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT * FROM IC_DON_HANG_NHAP WHERE MS_DH_NHAP_PT='" & txtMS_DH_NHAP.Text & "'")
                    While dtReader.Read
                        objDonHangNhapPT.MS_DDH = dtReader.Item("SO_DE_XUAT")
                    End While
                    dtReader.Close()
                End If

                ' LoadcboDDH()
                Me.cboDDH.SelectedValue = objDonHangNhapPT.MS_DDH
            End If

            If tabChanged = False Then GoTo NOT_CHANGED

            Me.lstDonHangNhapVatTu = Me.objDonHangNhapPTController.Load_Danh_Sach_DH_Nhap_Vat_Tu(Me.txtMS_DH_NHAP.Text)
            Me.hasListVTSL.Clear()
            For i As Integer = 0 To Me.lstDonHangNhapVatTu.Count - 1
                Dim tb As New DataTable()
                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "QL_LOAD_DON_HANG_NHAP_VT_CT_1", txtMS_DH_NHAP.Text, Me.lstDonHangNhapVatTu.Item(i).MS_PT).Tables(0)
                If hasListVTSL.Item(Me.lstDonHangNhapVatTu(i).MS_PT) Is Nothing Then
                    Me.hasListVTSL.Add(Me.lstDonHangNhapVatTu(i).MS_PT, tb)
                End If
                If i = 0 Then
                    grdSLtheoViTri.DataSource = tb
                    Dim s As String = tb.Columns("SL_VT").DataType.ToString
                    Dim dt As DataTable = New DataTable()
                    dt = CType(Me.grdSLtheoViTri.DataSource, DataTable)
                    Dim ss As String = dt.Columns("SL_VT").DataType.ToString

                    FormatGridViTriKho()

                End If
            Next

NOT_CHANGED:

            'Try
            '    Dim sssssssss As String = Me.lstDonHangNhapVatTu.Item(0).SL_THUC_NHAP.GetType().ToString
            '    Dim ss As Int16
            'Catch ex As Exception

            'End Try

            Me.grdNhapkhoPTCT.DataSource = Me.lstDonHangNhapVatTu

            Me.FormatGridNhapKhoPTCT()
            'Try
            '    Dim dtss As DataTable = CType(Me.grdNhapkhoPTCT.DataSource, DataTable)
            '    Dim ss As String = dtss.Columns("SL_VT").DataType.ToString
            'Catch ex As Exception

            'End Try

            Me.SetReadOnlyColumn(True)
            Try
                If objDonHangNhapPT.LOCK = True Then
                    Me.btnLock_PN.Enabled = False
                    Me.btnSua.Enabled = False
                    Me.BtnXoa.Enabled = False
                Else
                    Me.btnLock_PN.Enabled = True And Me.objDonHangNhapPTController.Load_Authorized_Lock
                    Me.btnSua.Enabled = True And Me.objDonHangNhapPTController.Load_Authorized_Lock
                    Me.BtnXoa.Enabled = True And Me.objDonHangNhapPTController.Load_Authorized_Lock
                End If
            Catch ex As Exception

            End Try

        Else
            Enable_Button(False)
            Me.btnLock_PN.Enabled = False
        End If
        Me.menuItemDelete.Enabled = False

    End Sub

    Sub Load_Nguoi_Nhap()
        Try

            Dim lstNGUOINHAP As List(Of NGUOINHAP_Info) = New List(Of NGUOINHAP_Info)
            'Dim dangNhap As String = Me.cboDANG_NHAP.SelectedIndex.ToString
            Dim dangNhap As String = Me.cboDANG_NHAP.SelectedValue
            Select Case dangNhap
                Case "21"
                    lstNGUOINHAP = Load_List("QL_LIST_KHACH_HANG")
                    Exit Select
                Case "13"
                    lstNGUOINHAP = Load_List("QL_LIST_CONG_NHAN")
                    Exit Select
                Case Else
                    lstNGUOINHAP = Load_List("QL_LIST_KHACH_HANG")
                    Dim lstTemp As New List(Of NGUOINHAP_Info)
                    lstTemp = Load_List("QL_LIST_CONG_NHAN")
                    lstNGUOINHAP.AddRange(lstTemp)
                    Exit Select
            End Select
            Me.cboNGUOI_NHAP.DataSource = lstNGUOINHAP
            Me.cboNGUOI_NHAP.ValueMember = "MA"
            Me.cboNGUOI_NHAP.DisplayMember = "TEN"

            If dangNhap <> 21 Then cboNGUOI_NHAP.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Sub EnableButoon_permission(ByVal bln As Boolean)
        BtnThem.Enabled = bln
        btnSua.Enabled = bln
        BtnXoa.Enabled = bln
        btnChonPT.Enabled = bln
        btnLock_PN.Enabled = bln
    End Sub

    Function Load_List(ByVal storeName As String) As List(Of NGUOINHAP_Info)
        Dim lstData As List(Of NGUOINHAP_Info) = QLBusinessDataController.FillCollection(Of NGUOINHAP_Info)(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, storeName))
        Return lstData
    End Function
    Function LoadViTriKho(ByVal MS_PT As String) As DataTable
        Try
            Dim tb As New DataTable()

            If grdNhapkhoPTCT.Rows.Count > 0 Then
                tb = CType(hasListVTSL.Item(MS_PT), DataTable)
                If tb Is Nothing Then
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "QL_LOAD_DON_HANG_NHAP_VT_CT_1", txtMS_DH_NHAP.Text, MS_PT).Tables(0)
                End If
            Else
                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "QL_LOAD_DON_HANG_NHAP_VT_CT_1", txtMS_DH_NHAP.Text, "").Tables(0)
            End If

            If btnGhi.Visible Then
                Dim vitris As String = ""
                For i As Integer = 0 To tb.Rows.Count - 1
                    vitris += "'" & tb.Rows(i)("MS_VI_TRI") & "',"
                Next
                vitris += "''"
                Dim query As String = "SELECT '' AS  MS_DH_NHAP_PT,'" & MS_PT & "' AS MS_PT,MS_VI_TRI,0.00 AS SL_VT,'' AS TEN_VI_TRI FROM VI_TRI_KHO AS V JOIN IC_KHO K ON K.MS_KHO = V.MS_KHO WHERE V.MS_VI_TRI NOT IN (" & vitris & ") AND V.MS_KHO = " & IIf(cboKHO.SelectedValue Is Nothing, -1, cboKHO.SelectedValue)
                Dim tb1 As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)
                For index As Integer = 0 To tb.Rows.Count - 1
                    Dim row As DataRow = tb1.NewRow
                    row(0) = tb.Rows(index)(0)
                    row(1) = tb.Rows(index)(1)
                    row(2) = tb.Rows(index)(2)
                    row(3) = tb.Rows(index)(3)
                    row(4) = tb.Rows(index)(4)
                    tb1.Rows.InsertAt(row, 0)
                Next
                grdSLtheoViTri.Columns("SL_VT").ReadOnly = False
                grdSLtheoViTri.DataSource = tb1
            Else
                grdSLtheoViTri.DataSource = tb
            End If

            Dim s As String = tb.Columns("SL_VT").DataType.ToString
            Dim dt As DataTable = New DataTable()
            dt = CType(Me.grdSLtheoViTri.DataSource, DataTable)
            Dim ss As String = dt.Columns("SL_VT").DataType.ToString

            Return tb

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Sub SetReadOnlyColumn(ByVal flag As Boolean)
        Try
            Me.grdNhapkhoPTCT.Columns("SL_THUC_NHAP").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("BAO_HANH_DEN_NGAY").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("DON_GIA").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("NGOAI_TE").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("MS_VT_NCC").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("XUAT_XU").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("TY_GIA").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("TY_GIA_USD").ReadOnly = flag
            Me.grdNhapkhoPTCT.Columns("GHI_CHU").ReadOnly = flag
        Catch ex As Exception

        End Try

    End Sub

    Sub Enable_Button(ByVal Flag As Boolean)
        Me.BtnXoa.Enabled = Flag
        Me.btnSua.Enabled = Flag
    End Sub
    Sub EnableControl(ByVal Flag As Boolean)
        Me.cboKHO.Enabled = Flag
        Me.txtSO_PHIEU_NHAP.ReadOnly = Not Flag
        Me.txtSO_CHUNG_TU.ReadOnly = Not Flag
        Me.txtGhi_Chu.ReadOnly = Not Flag
        Me.txtDANH_GIA.ReadOnly = Not Flag
        Me.dtpNGAY_CHUNG_TU.Enabled = Flag
        Me.cboDiem1.Enabled = Flag
        Me.cboDANG_NHAP.Enabled = Flag
        Me.cboNGUOI_NHAP.Enabled = Flag
        Me.dtpNGAY_NHAP.Enabled = Flag
        Me.txtMS_DH_NHAP.ReadOnly = Not Flag
        txtTim.Enabled = Not Flag
        cboDDH.Enabled = Flag
        Me.cboDiem2.Enabled = Flag
        Me.cboDiem3.Enabled = Flag
    End Sub

    Sub SetVisibleButton(ByVal Flag As Boolean)
        Me.btnChonPT.Enabled = Not Flag
        Me.btnGhi.Enabled = Not Flag
        Me.BtnThem.Visible = Flag
        Me.btnSua.Visible = Flag
        Me.BtnIn.Visible = Flag
        Me.BtnXoa.Visible = Flag
        Me.btnTRO_VE.Visible = Flag
        Me.cboKHO.Enabled = Flag
        Me.btnLock_PN.Visible = Flag
        Me.objDonHangNhapPTController.Load_Authorized_Lock()
        btnChonPT.Visible = Not Flag
        btnGhi.Visible = Not Flag
        btnKhongGhi.Visible = Not Flag
    End Sub

    Sub Clear()
        Dim time As String = ""
        Me.txtMS_DH_NHAP.Text = ""
        Me.txtGIO_NHAP.Text = time
        Me.dtpNGAY_NHAP.Value = Now
        dtpNGAY_CHUNG_TU.Value = Now
        Me.txtSO_PHIEU_NHAP.Text = ""
        Me.txtSO_CHUNG_TU.Text = ""
        Me.txtGhi_Chu.Text = ""
        Me.txtDANH_GIA.Text = ""
        Me.chkLock.Checked = False
        cboDiem1.SelectedIndex = -1
        cboDiem2.SelectedIndex = -1
        cboDiem3.SelectedIndex = -1
        cboDDH.SelectedValue = -1
        MaPT = ""
    End Sub

    Function ValidatedForm() As Boolean
        Dim flag As Boolean = True
        If Me.txtSO_PHIEU_NHAP.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_PHIEU_NHAP_NOT_NULL", Commons.Modules.TypeLanguage))
            Me.txtSO_PHIEU_NHAP.Focus()
            Return False
        Else
            If Me.objDonHangNhapPTController.CHECK_SO_PHIEU_NHAP_EXISTS(Me.txtSO_PHIEU_NHAP.Text, Me.txtMS_DH_NHAP.Text, Me.status) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_PHIEU_NHAP_EXISTS", Commons.Modules.TypeLanguage))
                Me.txtSO_PHIEU_NHAP.Focus()
                Return False
            End If
        End If
        If Val(txtGIO_NHAP.Text) = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_NHAP_NULL", Commons.Modules.TypeLanguage))
            Me.txtGIO_NHAP.Focus()
            Return False
        ElseIf Not IsDate(txtGIO_NHAP.Text) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_NHAP_ERROR", Commons.Modules.TypeLanguage))
            Me.txtGIO_NHAP.Focus()
            Return False
        End If

        If dtpNGAY_NHAP.Value > Date.Now Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_NHAP_ERROR", Commons.Modules.TypeLanguage))
            Return False
        End If
        If Me.txtSO_CHUNG_TU.Text <> "" Then
            If Me.objDonHangNhapPTController.CHECK_SO_CHUNG_TU_EXISTS(Me.txtSO_CHUNG_TU.Text, Me.txtMS_DH_NHAP.Text, status) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_CHUNG_TU_EXISTS", Commons.Modules.TypeLanguage))
                Me.txtSO_CHUNG_TU.Focus()
                Return False
            End If
        End If
        If Me.cboKHO.SelectedIndex = -1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHO_NULL", Commons.Modules.TypeLanguage))
            Me.cboKHO.Focus()
            Return False
        End If
        If cboDANG_NHAP.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DANG_NHAP_NULL", Commons.Modules.TypeLanguage))
            Me.cboDANG_NHAP.Focus()
            Return False
        End If
        If cboNGUOI_NHAP.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_NHAP_NULL", Commons.Modules.TypeLanguage))
            Me.cboNGUOI_NHAP.Focus()
            Return False
        End If
        If Not cboDDH.IsValidated And cboDANG_NHAP.SelectedValue = 21 Then
            cboDDH.Focus()
            Return False
        End If
        flag = Check_Can_Doi_So_Luong()
        Return flag
    End Function

    Function Check_Can_Doi_So_Luong() As Boolean
        Dim blnLoi As Boolean = True
        Dim strLoi As String = ""
        Dim dtReader As DataTable = New DataTable()

        strLoi = "SELECT ISNULL(COUNT(*),0) FROM IC_DON_HANG_NHAP_VAT_TU WHERE MS_DH_NHAP_PT='" & txtMS_DH_NHAP.Text.Trim & "'"
        dtReader.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, strLoi))
        'dtReader.Read()
        'If lstDonHangNhapVatTu Is Nothing Or Me.grdNhapkhoPTCT.RowCount < 1 Then
        If dtReader.Rows.Count < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_HANH_NHAP_CHUA_CO_CHI_TIET", Commons.Modules.TypeLanguage))
            Return False
        End If
        'dtReader.Close()

        Dim k As Integer = 0
        For k = 0 To Me.grdNhapkhoPTCT.RowCount - 1
            If Me.grdNhapkhoPTCT.Rows(k).Cells("SO_LUONG_CTU").Value Is Nothing Then
                ' Số lượng chứng từ không được rỗng, vui long nhập số lượng chứng từ !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_CHUNG_TU_RONG", Commons.Modules.TypeLanguage))
                Me.grdNhapkhoPTCT.Rows(k).Cells("SO_LUONG_CTU").Selected = True
                Return False
            End If
        Next
        For i As Integer = 0 To Me.lstDonHangNhapVatTu.Count - 1
            Dim objDHNHAP_VatTu As IC_DON_HANG_NHAP_VAT_TU_Info = Me.lstDonHangNhapVatTu.Item(i)
            If objDHNHAP_VatTu.SL_THUC_NHAP <> "" Then
                Dim lstDonHangNhapVTCT As New DataTable()
                lstDonHangNhapVTCT = CType(Me.hasListVTSL.Item(objDHNHAP_VatTu.MS_PT), DataTable)
                Dim SUM_SLVTRI As Double = 0
                If lstDonHangNhapVTCT IsNot Nothing Then
                    For j As Integer = 0 To lstDonHangNhapVTCT.Rows.Count - 1
                        SUM_SLVTRI += IIf(lstDonHangNhapVTCT.Rows(j).Item("SL_VT").ToString = "", 0, lstDonHangNhapVTCT.Rows(j).Item("SL_VT"))
                    Next
                End If
                objDHNHAP_VatTu.SL_THUC_NHAP = SUM_SLVTRI
                'If Double.Parse(objDHNHAP_VatTu.SL_THUC_NHAP) <> SUM_SLVTRI Then
                '    blnLoi = False
                '    If strLoi = "" Then
                '        strLoi = objDHNHAP_VatTu.MS_PT
                '    Else
                '        strLoi = strLoi + "; " + objDHNHAP_VatTu.MS_PT
                '    End If
                'End If
            End If
        Next
        If blnLoi = False Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_THUC_NHAP_VA_SLCT_KHONG_CAN_DOI", Commons.Modules.TypeLanguage) & strLoi)
            Return False
        End If
        Return True
    End Function
#End Region

#Region "EVENT FUNCTION"
    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        'intDanhsachNhapkhoPT = grdDanhsachNhapkhoPT.RowCount
        'grdDanhsachNhapkhoPT.AllowUserToDeleteRows = True
        'intNhapkhoPTCT = grdNhapkhoPTCT.RowCount
        'grdNhapkhoPTCT.AllowUserToDeleteRows = True
        'intSLtheoViTri = grdSLtheoViTri.RowCount
        'grdSLtheoViTri.AllowUserToDeleteRows = True
        iTrangThai = 1

        status = True
        blnTT = True
        Me.tabNhapkhoPT.TabPages.Remove(Me.tabDanhSachPT)

        Dim time As String = ""
        If Now.Hour < 10 Then
            time += "0" + Now.Hour.ToString + ":"
        Else
            time += Now.Hour.ToString + ":"
        End If
        If Now.Minute < 10 Then
            time += "0" + Now.Minute.ToString
        Else
            time += Now.Minute.ToString
        End If

        Clear()
        Me.txtGIO_NHAP.Text = time
        '  Me.txtMS_DH_NHAP.Text = objDonHangNhapPTController.Create_MS_DH_NHAP_PT
        Vietsoft.Admin.Adminvs.ConnectionString = Commons.IConnections.ConnectionString
        Me.txtMS_DH_NHAP.Text = Vietsoft.Admin.IDvs.CREATE_ID("PN")

        hasListVTSL.Clear()
        Me.lstDonHangNhapVatTu.Clear()

        Me.grdNhapkhoPTCT.DataSource = Me.objDonHangNhapPTController.Load_Danh_Sach_DH_Nhap_Vat_Tu(Me.txtMS_DH_NHAP.Text)
        Me.FormatGridNhapKhoPTCT()
        Me.grdSLtheoViTri.DataSource = New List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
        Me.FormatGridViTriKho()
        SetVisibleButton(False)
        SetReadOnlyColumn(False)
        Enable_Button(False)
        EnableControl(True)
        Me.btnLock_PN.Enabled = False
        Me.MaPT = ""
        txtTim.Text = ""
        Me.menuItemDelete.Enabled = True And actionButton
        LoadcboDDH()
        If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
            cboDDH.SelectedIndex = -1
            cboDDH.Enabled = False
        Else
            cboDDH.Enabled = True
            cboDDH_SelectionChangeCommitted(sender, e)
            If cboDDH.Items.Count > 0 Then cboDDH.SelectedIndex = 0
        End If
        Me.txtSO_PHIEU_NHAP.Focus()
        AddHandler cboKHO.SelectedIndexChanged, AddressOf Me.cboKHO_SelectedIndexChanged

        cboKHO.SelectedValue = -1
        cboDANG_NHAP.SelectedValue = -1
        cboNGUOI_NHAP.SelectedValue = -1
        cboDDH.SelectedValue = -1

        grdNhapkhoPTCT.Columns.Clear()
        grdSLtheoViTri.Columns.Clear()

    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        RemoveHandler cboKHO.SelectedIndexChanged, AddressOf Me.cboKHO_SelectedIndexChanged
        iTrangThai = -1
        errProvider.Clear()
        Clear()
        SetVisibleButton(True)
        Me.tabNhapkhoPT.TabPages.Insert(0, Me.tabDanhSachPT)
        Me.tabNhapkhoPT.SelectedTab = Me.tabDanhSachPT
        If Me.grdDanhsachNhapkhoPT.RowCount > 0 Then
            Load_Phieu_Nhap(Me.grdDanhsachNhapkhoPT.CurrentRow.Cells("MS_DH_NHAP_PT").RowIndex, False)
        Else
            Load_Phieu_Nhap(-1, False)
        End If
        blnTT = False
        Me.FormatGridViTriKho()
        Me.grdSLtheoViTri.DataSource = New List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
        intRowCT = -1
        SetReadOnlyColumn(True)
        Me.Enable_Button(True)
        EnableControl(False)
        Load_Phieu_Nhap(0, False)
        If Me.grdDanhsachNhapkhoPT.RowCount > 0 Then
            If Me.chkLock.Checked Then
                Me.btnSua.Enabled = False
                Me.BtnXoa.Enabled = False
                Me.btnLock_PN.Enabled = False
            Else
                Me.btnSua.Enabled = True
                Me.BtnXoa.Enabled = True
                Me.btnLock_PN.Enabled = True
            End If
            Me.BtnIn.Enabled = True
        Else
            Me.btnSua.Enabled = False
            Me.BtnXoa.Enabled = False
            Me.BtnIn.Enabled = False
        End If
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Dim i As Integer
        Try
            grdNhapkhoPTCT.EndEdit()
        Catch ex As Exception

        End Try

        If grdSLtheoViTri.Rows.Count > 0 Then
            ' Dim s As String = grdNhapkhoPTCT.Rows(2).Cells("SL_THUC_NHAP").Value

            If iTrangThai = 1 Then
                hasListVTSL.Remove(grdNhapkhoPTCT.Rows(intRowCT).Cells("MS_PT").Value)
                hasListVTSL.Add(grdNhapkhoPTCT.Rows(intRowCT).Cells("MS_PT").Value, CType(Me.grdSLtheoViTri.DataSource, DataTable))
            ElseIf iTrangThai = 2 Then
                hasListVTSL.Clear()
                For i = 0 To lstDonHangNhapVatTu.Count - 1
                    Dim tb As New DataTable()
                    Dim tb1 As New DataTable
                    '                Dim query As String = "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI," & lstDonHangNhapVatTu.Item(i).SL_THUC_NHAP & " AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "'"
                    Dim query As String = "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI, SL_VT,NULL AS TEN_VI_TRI FROM IC_DON_HANG_NHAP_VAT_TU_CHI_TIET WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "' AND MS_DH_NHAP_PT='" & txtMS_DH_NHAP.Text & "'"
                    tb1 = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)

                    query = "SELECT NULL AS  MS_DH_NHAP_PT,'" & lstDonHangNhapVatTu.Item(i).MS_PT & "' AS MS_PT,MS_VI_TRI,0 AS SL_VT,NULL AS TEN_VI_TRI FROM VI_TRI_KHO AS V JOIN IC_KHO K ON K.MS_KHO = V.MS_KHO WHERE V.MS_VI_TRI NOT IN (SELECT MS_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "') AND V.MS_KHO = " & cboKHO.SelectedValue
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)
                    For index As Integer = 0 To tb1.Rows.Count - 1
                        Dim row As DataRow = tb.NewRow
                        row(0) = tb1.Rows(index)(0)
                        row(1) = tb1.Rows(index)(1)
                        row(2) = tb1.Rows(index)(2)
                        row(3) = tb1.Rows(index)(3)
                        row(4) = tb1.Rows(index)(4)
                        tb.Rows.InsertAt(row, 0)
                    Next

                    Me.hasListVTSL.Add(lstDonHangNhapVatTu.Item(i).MS_PT, tb)
                Next
                grdNhapkhoPTCT.DataSource = lstDonHangNhapVatTu
                If grdNhapkhoPTCT.Rows.Count > 0 Then
                    FormatGridViTriKho()
                    LoadViTriKho(grdNhapkhoPTCT.Rows(0).Cells("MS_PT").Value)
                    intRowCT = 0
                End If
            End If
        End If

        If Not ValidatedForm() Then
            Return
        End If
        RemoveHandler cboKHO.SelectedIndexChanged, AddressOf Me.cboKHO_SelectedIndexChanged
        Dim bSoLuong As Boolean = False
        Dim tmp As Double = 0
        For j As Integer = 0 To grdNhapkhoPTCT.RowCount - 1
            tmp = tmp + grdNhapkhoPTCT.Rows(j).Cells("SL_THUC_NHAP").Value
            If grdNhapkhoPTCT.Rows(j).Cells("SL_THUC_NHAP").Value = 0 And Not bSoLuong Then
                bSoLuong = True
            End If
        Next
        If tmp = 0 Then
            Dim result As DialogResult = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChuaNhapSoLuong", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                Exit Sub
            Else
                GoTo KetThuc
            End If
        Else
            If bSoLuong Then
                Dim result As DialogResult = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgConPTChuaNhapSoLuong", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If

        For j As Integer = 0 To grdNhapkhoPTCT.RowCount - 1
            If grdNhapkhoPTCT.Rows(j).Cells("DON_GIA").Value = 0 Then
                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_NHAP_DON_GIA_CO_MUON_TT_KO", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Exit Sub
                Else
                    Exit For
                End If
            End If
        Next


        objDonHangNhapPT = New IC_DON_HANG_NHAP_Info
        objDonHangNhapPT.LOCK = Me.chkLock.Checked
        objDonHangNhapPT.MS_DH_NHAP_PT = Me.txtMS_DH_NHAP.Text
        objDonHangNhapPT.SO_PHIEU_XN = Me.txtSO_PHIEU_NHAP.Text
        objDonHangNhapPT.GIO = Date.Parse(Me.txtGIO_NHAP.Text)
        objDonHangNhapPT.NGAY = Me.dtpNGAY_NHAP.Value
        objDonHangNhapPT.MS_KHO = Integer.Parse(Me.cboKHO.SelectedValue.ToString)
        objDonHangNhapPT.MS_DANG_NHAP = Integer.Parse(Me.cboDANG_NHAP.SelectedValue.ToString)
        objDonHangNhapPT.NGUOI_NHAP = Me.cboNGUOI_NHAP.SelectedValue
        objDonHangNhapPT.NGAY_CHUNG_TU = Me.dtpNGAY_CHUNG_TU.Value
        objDonHangNhapPT.GHI_CHU = Me.txtGhi_Chu.Text
        objDonHangNhapPT.THU_KHO = Commons.Modules.UserName
        objDonHangNhapPT.MS_DDH = cboDDH.SelectedValue
        objDonHangNhapPT.SO_CHUNG_TU = txtSO_CHUNG_TU.Text

        Try
            objDonHangNhapPT.DIEM = Integer.Parse(Me.cboDiem1.Text.Trim)
        Catch ex As Exception
            objDonHangNhapPT.DIEM = -1
        End Try

        Try
            objDonHangNhapPT.DIEM1 = Integer.Parse(Me.cboDiem2.Text.Trim)
        Catch ex As Exception
            objDonHangNhapPT.DIEM1 = -1
        End Try

        Try
            objDonHangNhapPT.DIEM2 = Integer.Parse(Me.cboDiem3.Text.Trim)
        Catch ex As Exception
            objDonHangNhapPT.DIEM2 = -1
        End Try

        objDonHangNhapPT.DANH_GIA = Me.txtDANH_GIA.Text
        For i = 0 To Me.grdNhapkhoPTCT.RowCount - 1
            If IsDBNull(grdNhapkhoPTCT.Rows(i).Cells("DON_GIA").Value) Or grdNhapkhoPTCT.Rows(i).Cells("DON_GIA").Value Is Nothing Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_GIA_NULL", Commons.Modules.TypeLanguage))
                Exit Sub
            End If
        Next

        If cboDANG_NHAP.SelectedValue <> 28 Then
            If status = True Then
                If objDonHangNhapPTController.Add_Don_Hang_Nhap(objDonHangNhapPT, Me.lstDonHangNhapVatTu, Me.hasListVTSL) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ADD_DON_HANG_NHAP_SUCCESS", Commons.Modules.TypeLanguage))
                End If
            Else
                If objDonHangNhapPTController.Update_Don_Hang_Nhap(objDonHangNhapPT, Me.lstDonHangNhapVatTu, Me.hasListVTSL) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "UPDATE_DON_HANG_NHAP_SUCCESS", Commons.Modules.TypeLanguage))
                End If
            End If
        ElseIf cboDANG_NHAP.SelectedValue = 28 Then
            If status = True Then
                If objDonHangNhapPTController.Add_Don_Hang_Nhap_DXMH(objDonHangNhapPT, Me.lstDonHangNhapVatTu, Me.hasListVTSL) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ADD_DON_HANG_NHAP_SUCCESS", Commons.Modules.TypeLanguage))
                End If
            Else
                If objDonHangNhapPTController.Update_Don_Hang_Nhap_DXMH(objDonHangNhapPT, Me.lstDonHangNhapVatTu, Me.hasListVTSL) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "UPDATE_DON_HANG_NHAP_SUCCESS", Commons.Modules.TypeLanguage))
                End If
            End If
        End If

        Dim iKhoIndex As Integer = objDonHangNhapPT.MS_KHO
KetThuc:
        SetVisibleButton(True)
        blnTT = False
        Clear()
        Me.tabNhapkhoPT.TabPages.Insert(0, Me.tabDanhSachPT)
        Me.tabNhapkhoPT.SelectedTab = Me.tabDanhSachPT
        Me.grdSLtheoViTri.Columns.Clear()
        Me.FormatGridViTriKho()
        intRowCT = -1
        Me.btnLock_PN.Enabled = True

        Me.Load_Danh_Sach_PN(CreateQuery())
        Me.Enable_Button(True)
        EnableControl(False)
        SetReadOnlyColumn(True)
        cboFilter.BindDataSource()
        'tabNhapkhoPT_IndexChange(tabNhapkhoPT.SelectedIndex)
        iTrangThai = -1
        cboLockho.SelectedValue = iKhoIndex 'objDonHangNhapPT.MS_KHO
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Click
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME='" & Commons.Modules.UserName & "' AND STT=4")
        Dim bQuyen As Boolean = False
        Dim strDDH As String = cboDDH.SelectedValue
        While objReader.Read
            bQuyen = True
        End While
        objReader.Close()
        If bQuyen Then
            iTrangThai = 2
            'intDanhsachNhapkhoPT = grdDanhsachNhapkhoPT.RowCount
            'grdDanhsachNhapkhoPT.AllowUserToDeleteRows = True
            'intNhapkhoPTCT = grdNhapkhoPTCT.RowCount
            'grdNhapkhoPTCT.AllowUserToDeleteRows = True
            'intSLtheoViTri = grdSLtheoViTri.RowCount
            'grdSLtheoViTri.AllowUserToDeleteRows = True
            status = False
            blnTT = True
            Try
                tabNhapkhoPT.SelectedIndex = 1
            Catch ex As Exception
            End Try
            FormatGridNhapKhoPTCT()
            'SetReadOnlyColumn(False)
            Me.SetVisibleButton(False)
            Me.Enable_Button(False)
            EnableControl(True)
            Me.tabNhapkhoPT.TabPages.Remove(Me.tabDanhSachPT)
            If grdNhapkhoPTCT.Rows.Count > 0 Then Load_VTVT(intRowCT) ' Load_VTVT(0)
            hasListVTSL.Clear()
            lstDonHangNhapVatTu = Me.objDonHangNhapPTController.Load_Danh_Sach_DH_Nhap_Vat_Tu(txtMS_DH_NHAP.Text)
            Me.menuItemDelete.Enabled = True And actionButton
            Me.cboKHO.Enabled = False
            txtTim.Text = ""
            LoadcboDDH()
            If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
                Try
                    cboDDH.SelectedValue = strDDH
                Catch ex As Exception
                    cboDDH.SelectedIndex = -1
                End Try
                cboDDH.Enabled = False
            Else
                Try
                    cboDDH.SelectedValue = strDDH
                Catch ex As Exception
                    cboDDH.SelectedIndex = -1
                End Try
                cboDDH.Enabled = True
            End If
            Me.txtSO_PHIEU_NHAP.Focus()
            SetReadOnlyColumn(False)
            Me.callback.Called(Commons.Modules.HasTableVT)
            iTrangThai = 1
            AddHandler cboKHO.SelectedIndexChanged, AddressOf Me.cboKHO_SelectedIndexChanged
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenSua", Commons.Modules.TypeLanguage))
        End If
        If grdNhapkhoPTCT.Rows.Count > 0 Then
            cboDANG_NHAP.Enabled = False
        End If
    End Sub

    Private Sub btnTRO_VE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTRO_VE.Click
        Dispose()
    End Sub
    Sub CreateTitleReport()
        Dim SqlText As String = ""
        Try
            SqlText = " DROP TABLE rptTIEU_DE_NHAP_KHO_VAT_TU"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)
        Catch ex As Exception

        End Try
        Dim sTieudeReport As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "TieudeReport", Commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "STT", Commons.Modules.TypeLanguage)
        Dim sNgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "Ngayin", Commons.Modules.TypeLanguage)
        Dim sTrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "Trangin", Commons.Modules.TypeLanguage)
        Dim sSoPhieuXN As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "SoPhieuXN", Commons.Modules.TypeLanguage)
        Dim sNo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "sNo", Commons.Modules.TypeLanguage)
        Dim sCo As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "sCo", Commons.Modules.TypeLanguage)
        Dim sNoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "NoiGiao", Commons.Modules.TypeLanguage)
        Dim sSoChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "SochungTu", Commons.Modules.TypeLanguage)
        Dim sDangNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "DangNhap", Commons.Modules.TypeLanguage)
        Dim sNgayNhap As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "NgayNhap", Commons.Modules.TypeLanguage)
        Dim sGhiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "GhiChu", Commons.Modules.TypeLanguage)
        Dim sKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "Kho", Commons.Modules.TypeLanguage)
        Dim sSoLuongChungTu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "SoLuongChungTu", Commons.Modules.TypeLanguage)
        Dim sMaPhuTung As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "MaPhuTung", Commons.Modules.TypeLanguage)
        Dim sQuyCach As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "QuyCach", Commons.Modules.TypeLanguage)
        Dim sDonViTinh As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "DonViTinh", Commons.Modules.TypeLanguage)
        Dim sViTriKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "ViTriKho", Commons.Modules.TypeLanguage)
        Dim sSoLuongVattu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "SoLuongVatTu", Commons.Modules.TypeLanguage)
        Dim sDonGia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "DonGia", Commons.Modules.TypeLanguage)
        Dim sNgoaiTe As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "NgoaiTe", Commons.Modules.TypeLanguage)
        Dim sThanhTien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "ThanhTien", Commons.Modules.TypeLanguage)
        Dim sTong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "Tong", Commons.Modules.TypeLanguage)
        Dim sThoiGian As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "ThoiGian", Commons.Modules.TypeLanguage)
        Dim sPhuTrachBoPhanSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "PhuTrachBoPhanSD", Commons.Modules.TypeLanguage)
        Dim sPhuTrachcungTieu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "PhuTrachcungTieu", Commons.Modules.TypeLanguage)
        Dim sNguoiGiao As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "NguoiGiao", Commons.Modules.TypeLanguage)
        Dim sThuKho As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "ThuKho", Commons.Modules.TypeLanguage)
        Dim sKyTen As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "KyTen", Commons.Modules.TypeLanguage)
        Dim ThanhTienUSD As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "ThanhTienUSD", Commons.Modules.TypeLanguage)


        Dim msPT As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "msPT", Commons.Modules.TypeLanguage)
        Dim Soluong As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "soLuong", Commons.Modules.TypeLanguage)
        Dim ghiChu As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "GHI_CHU_CT", Commons.Modules.TypeLanguage)
        Dim mauso As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "MAUSO", Commons.Modules.TypeLanguage)
        Dim Lien As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "LIEN", Commons.Modules.TypeLanguage)
        Dim tygia As String = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "TYGIA", Commons.Modules.TypeLanguage)

        'Dim MS_PT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "MS_PT", commons.Modules.TypeLanguage)
        'Dim MAU_SO As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "MAU_SO", commons.Modules.TypeLanguage)



        Dim sDonDH As String = ""

        If cboDANG_NHAP.SelectedValue = 21 Then
            sDonDH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "MS_DDH", Commons.Modules.TypeLanguage)
        ElseIf cboDANG_NHAP.SelectedValue = 28 Then
            sDonDH = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptNHAP_KHO_VAT_TU", "MS_DXMH", Commons.Modules.TypeLanguage)
        End If

        SqlText = "CREATE TABLE DBO.rptTIEU_DE_NHAP_KHO_VAT_TU (TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(120),TrangIn nvarchar(120),SoPhieuXuatNhap nvarchar(150),sNo nvarchar(110),sCo nvarchar(110),NoiGiao nvarchar(120),SoChungTu nvarchar(130), " & _
       " DangNhap nvarchar(130),NgayNhap nvarchar(120),GhiChu nvarchar(120),Kho nvarchar(120),SoLuongChungTu nvarchar(150), " & _
       " STT nvarchar(115),MaPhuTung nvarchar(130),QuyCach nvarchar(130),DonViTinh nvarchar(115),ViTrikho nvarchar(150),SoLuongVatTu nvarchar(150),DonGia nvarchar(130),NgoaiTe nvarchar(120),ThanhTien nvarchar(120),Tong nvarchar(130), " & _
       " msPT nvarchar(160), soLuong nvarchar(160), ghiChu_CT nvarchar(160), MAUSO nvarchar(60), LIEN nvarchar(160),TYGIA nvarchar(160), ThoiGian nvarchar(160),PhuTrachBoPhanSD nvarchar(110),PhuTrachCungTieu nvarchar(160),NguoiGiao nvarchar(130), ThuKho nvarchar(130),KyTen nvarchar(130),ThanhTienUSD nvarchar(130),DonDH nvarchar(130)) "
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

        SqlText = "INSERT INTO rptTIEU_DE_NHAP_KHO_VAT_TU(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,SoPhieuXuatNhap,sNo,sCo,NoiGiao,SoChungTu, " & _
        "DangNhap,NgayNhap,GhiChu,Kho,SoLuongChungTu,STT,MaPhuTung,QuyCach,DonviTinh,ViTriKho,SoLuongVatTu,DonGia,NgoaiTe,ThanhTien,Tong, " & _
        "ThoiGian,PhuTrachBoPhanSD,PhuTrachCungTieu,NguoiGiao,ThuKho,KyTen,ThanhTienUSD,DonDH, msPT,soLuong,ghiChu_CT,MAUSO,LIEN,TYGIA) " & _
        "VALUES(" & Commons.Modules.TypeLanguage & ",N'" & sTieudeReport & "',N'" & sNgayIn & "',N'" & sTrangIn & "'," & _
        "N'" & sSoPhieuXN & "',N'" & sNo & "',N'" & sCo & "',N'" & sNoiGiao & "',N'" & sSoChungTu & "',N'" & sDangNhap & "',N'" & sNgayNhap & "',N'" & sGhiChu & "',N'" & sKho & "'," & _
        "N'" & sSoLuongChungTu & "',N'" & sSTT & "',N'" & sMaPhuTung & "',N'" & sQuyCach & "',N'" & sDonViTinh & "',N'" & sViTriKho & "',N'" & sSoLuongVattu & "',N'" & sDonGia & "'," & _
        "N'" & sNgoaiTe & "',N'" & sThanhTien & "',N'" & sTong & "',N'" & sThoiGian & "',N'" & sPhuTrachBoPhanSD & "',N'" & sPhuTrachcungTieu & "',N'" & sNguoiGiao & "',N'" & sThuKho & "',N'" & sKyTen & "',N'" & ThanhTienUSD & "',N'" & sDonDH & "',N'" & msPT & "',N'" & Soluong & "',N'" & ghiChu & "',N'" & mauso & "',N'" & Lien & "',N'" & tygia & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText)

    End Sub

    Private Sub BtnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIn.Click
        If txtMS_DH_NHAP.Text <> "" Then
            Me.Cursor = Cursors.WaitCursor
            Dim str As String = ""
            Try
                str = "DROP TABLE rptPHIEU_NHAP_KHO_VAT_TU"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "CREATE TABLE DBO.rptPHIEU_NHAP_KHO_VAT_TU (SO_PHIEU_XN NVARCHAR(250),TEN_CONG_TY NVARCHAR(250),SO_CHUNG_TU NVARCHAR(250),DANG_NHAP NVARCHAR(250),NGAY DATETIME,GHI_CHU NVARCHAR(255),TEN_KHO NVARCHAR(255),SO_LUONG_CTU FLOAT,MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255),QUY_CACH NVARCHAR(255),DVT NVARCHAR(10),VI_TRI NVARCHAR(255),SL_VT FLOAT, DON_GIA FLOAT, NGOAI_TE NVARCHAR(10),THANH_TIEN FLOAT,THANH_TIEN_USD FLOAT,THU_KHO NVARCHAR(50),GHI_CHU_CT nvarchar(255),TY_GIA float ,MS_DDH NVARCHAR(30))" & _
            " INSERT INTO DBO.rptPHIEU_NHAP_KHO_VAT_TU " & _
            " SELECT * FROM(SELECT SO_PHIEU_XN,(SELECT TEN_CONG_TY FROM KHACH_HANG WHERE MS_KH = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP UNION SELECT HO + ' ' + TEN AS HO_TEN " & _
            " FROM CONG_NHAN WHERE MS_CONG_NHAN = dbo.IC_DON_HANG_NHAP.NGUOI_NHAP) AS TEN_CONG_TY,SO_CHUNG_TU, " & _
            " (CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN dbo.DANG_NHAP.DANG_NHAP_VIET  WHEN 1 THEN dbo.DANG_NHAP.DANG_NHAP_ANH  END)AS TEN_DANG_NHAP, " & _
           " NGAY,IC_DON_HANG_NHAP.GHI_CHU,TEN_KHO,SO_LUONG_CTU,dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT,dbo.IC_PHU_TUNG.TEN_PT AS TEN_PT,QUY_CACH,(CASE " & Commons.Modules.TypeLanguage & " WHEN 0 THEN TEN_1  WHEN 1 THEN TEN_2  END)AS TEN, " & _
           " TEN_VI_TRI,SL_VT,DON_GIA,NGOAI_TE, SL_VT*ISNULL(DON_GIA,0)*TY_GIA AS THANH_TIEN,SL_VT*ISNULL(DON_GIA,0)*TY_GIA_USD AS THANH_TIEN_USD " & _
           ",(SELECT FULL_NAME FROM USERS WHERE USERNAME= IC_DON_HANG_NHAP.THU_KHO) AS THU_KHO , dbo.IC_DON_HANG_NHAP_VAT_TU.GHI_CHU AS GHI_CHU_CT, dbo.IC_DON_HANG_NHAP_VAT_TU.TY_GIA,  " & IIf(cboDANG_NHAP.SelectedValue = 28, "SO_DE_XUAT", "MS_DDH") & " AS MS_DDH " & _
           " FROM dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET INNER JOIN " & _
               " dbo.IC_DON_HANG_NHAP_VAT_TU ON  " & _
               " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT AND  " & _
               " dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_PT = dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT INNER JOIN " & _
               " dbo.IC_DON_HANG_NHAP ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_DH_NHAP_PT = dbo.IC_DON_HANG_NHAP.MS_DH_NHAP_PT INNER JOIN " & _
               " dbo.IC_PHU_TUNG ON dbo.IC_DON_HANG_NHAP_VAT_TU.MS_PT = dbo.IC_PHU_TUNG.MS_PT INNER JOIN " & _
               " dbo.VI_TRI_KHO ON dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_VI_TRI = dbo.VI_TRI_KHO.MS_VI_TRI INNER JOIN " & _
               " dbo.IC_KHO ON dbo.IC_DON_HANG_NHAP.MS_KHO = dbo.IC_KHO.MS_KHO AND dbo.VI_TRI_KHO.MS_KHO = dbo.IC_KHO.MS_KHO INNER JOIN " & _
               " dbo.DON_VI_TINH ON dbo.IC_PHU_TUNG.DVT = dbo.DON_VI_TINH.DVT INNER JOIN " & _
               " dbo.DANG_NHAP ON dbo.IC_DON_HANG_NHAP.MS_DANG_NHAP = dbo.DANG_NHAP.MS_DANG_NHAP " & _
            " WHERE     (dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET.MS_DH_NHAP_PT ='" & txtMS_DH_NHAP.Text & "')) TMP WHERE SO_LUONG_CTU>0 OR SL_VT>0"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            CreateTitleReport()
            Try
                Dim query As String = "SELECT * FROM THONG_TIN_CHUNG"
                Dim tb1 As DataTable = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)
                Dim s As String = tb1.Rows(0)("PHIEU_NHAP_VTPT").ToString
                If s.Trim() = "rptNHAP_KHO_VAT_TU_VMPACK.rpt" Then
                    Commons.mdShowReport.ReportPreview("reports\rptNHAP_KHO_VAT_TU_VMPACK.rpt")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Commons.mdShowReport.ReportPreview("reports\rptNHAP_KHO_VAT_TU.rpt")
            Me.Cursor = Cursors.Default
            'Try
            '    str = "DROP TABLE rptPHIEU_NHAP_KHO_VAT_TU"
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            '    str = " DROP TABLE rptTIEU_DE_NHAP_KHO_VAT_TU"
            '    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            'Catch ex As Exception
            'End Try
        End If
    End Sub

    Private Sub btnLock_PN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLock_PN.Click
        If txtSO_PHIEU_NHAP.Text.Trim <> "" Then


            If Check_Can_Doi_So_Luong() Then
                If cboDiem1.SelectedValue Is Nothing Then
                    If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KIEM_TRA_DK_LOCK_DIEM", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Message", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
                End If
                If txtDANH_GIA.Text = "" Then
                    If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KIEM_TRA_DK_LOCK_DANH_GIA", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Message", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo) = vbNo Then Exit Sub
                End If
                If XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DO_YOU_WANT_TO_LOCK_DON_HANG_NHAP", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Message", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.objDonHangNhapPTController.Lock_Don_Hang_Nhap(Me.txtMS_DH_NHAP.Text)
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DON_HANG_NHAP_DA_DUOC_LOCK", Commons.Modules.TypeLanguage))
                    Clear()
                    Enable_Button(True)
                    Me.Load_Danh_Sach_PN(CreateQuery())
                End If
            End If
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CHON_PHIEU_NHAP", Commons.Modules.TypeLanguage))
        End If
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT STT FROM USER_CHUC_NANG WHERE USERNAME='" & Commons.Modules.UserName & "' AND STT=10")
        Dim bQuyen As Boolean = False
        While objReader.Read
            bQuyen = True
        End While
        objReader.Close()
        If bQuyen Then
            Dim result As DialogResult = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoaDonHangNhap", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                If Me.objDonHangNhapPTController.Delete_Don_Hang_Nhap(Me.txtMS_DH_NHAP.Text) = True Then
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDaXoaDonHangNhap", Commons.Modules.TypeLanguage))
                    cboFilter.BindDataSource()
                    intRowCT = -1
                    Me.Load_Danh_Sach_PN(CreateQuery())
                    If (grdDanhsachNhapkhoPT.RowCount > 0) Then
                        intRowCT = 0
                        Load_Phieu_Nhap(intRowCT, True)
                    End If
                End If
            End If
        Else
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa", Commons.Modules.TypeLanguage))
        End If
    End Sub

    Private Sub btnChonPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChonPT.Click
        If cboKHO.SelectedIndex = -1 Or cboKHO.SelectedValue Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHO_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
            cboKHO.Focus()
            Return
        End If
        If Me.cboDANG_NHAP.SelectedIndex = -1 Or cboDANG_NHAP.SelectedValue Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DANG_NHAP_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
            cboDANG_NHAP.Focus()
            Return
        End If

        If Me.cboNGUOI_NHAP.SelectedIndex = -1 Or cboNGUOI_NHAP.SelectedValue Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_NHAP_KHO_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Information, Me.Text)
            cboNGUOI_NHAP.Focus()
            Return
        End If

        If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
            Dim frmCVT As New frmChonPT(callback)
            frmCVT.ShowDialog()
            hasListVTSL.Clear()
            iTrangThai = 1
            For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
                Dim tb As New DataTable()
                Dim tb1 As New DataTable
                'Dim query As String = "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI," & lstDonHangNhapVatTu.Item(i).SL_THUC_NHAP & " AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "'"
                Dim query As String = "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI, SL_VT,NULL AS TEN_VI_TRI FROM IC_DON_HANG_NHAP_VAT_TU_CHI_TIET WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "' AND MS_DH_NHAP_PT='" & txtMS_DH_NHAP.Text & "'"
                tb1 = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)

                query = "SELECT NULL AS  MS_DH_NHAP_PT,'" & lstDonHangNhapVatTu.Item(i).MS_PT & "' AS MS_PT,MS_VI_TRI,0 AS SL_VT,NULL AS TEN_VI_TRI FROM VI_TRI_KHO AS V JOIN IC_KHO K ON K.MS_KHO = V.MS_KHO WHERE V.MS_VI_TRI NOT IN (SELECT MS_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "') AND V.MS_KHO = " & cboKHO.SelectedValue
                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)
                For index As Integer = 0 To tb1.Rows.Count - 1
                    Dim row As DataRow = tb.NewRow
                    row(0) = tb1.Rows(index)(0)
                    row(1) = tb1.Rows(index)(1)
                    row(2) = tb1.Rows(index)(2)
                    row(3) = tb1.Rows(index)(3)
                    row(4) = tb1.Rows(index)(4)
                    tb.Rows.InsertAt(row, 0)
                Next
                Me.hasListVTSL.Add(lstDonHangNhapVatTu.Item(i).MS_PT, tb)
            Next

            'For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
            '    Dim tb As New DataTable()
            '    Dim tb1 As New DataTable
            '    Dim query As String = "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI," & lstDonHangNhapVatTu.Item(i).SL_THUC_NHAP & " AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "'"
            '    tb1 = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)

            '    query = "SELECT NULL AS  MS_DH_NHAP_PT,'" & lstDonHangNhapVatTu.Item(i).MS_PT & "' AS MS_PT,MS_VI_TRI,0 AS SL_VT,NULL AS TEN_VI_TRI FROM VI_TRI_KHO AS V JOIN IC_KHO K ON K.MS_KHO = V.MS_KHO WHERE V.MS_VI_TRI NOT IN (SELECT MS_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "') AND V.MS_KHO = " & cboKHO.SelectedValue
            '    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, query).Tables(0)
            '    For index As Integer = 0 To tb1.Rows.Count - 1
            '        Dim row As DataRow = tb.NewRow
            '        row(0) = tb1.Rows(index)(0)
            '        row(1) = tb1.Rows(index)(1)
            '        row(2) = tb1.Rows(index)(2)
            '        row(3) = tb1.Rows(index)(3)
            '        row(4) = tb1.Rows(index)(4)
            '        tb.Rows.InsertAt(row, 0)
            '    Next

            '    Me.hasListVTSL.Add(lstDonHangNhapVatTu.Item(i).MS_PT, tb)
            'Next
            grdNhapkhoPTCT.DataSource = lstDonHangNhapVatTu
            If grdNhapkhoPTCT.Rows.Count > 0 Then
                Try
                    FormatGridViTriKho()
                    LoadViTriKho(grdNhapkhoPTCT.Rows(0).Cells("MS_PT").Value)
                    intRowCT = 0
                Catch ex As Exception
                End Try
            Else
                grdNhapkhoPTCT.Columns.Clear()
            End If
            cboKHO.Enabled = IIf(grdNhapkhoPTCT.Rows.Count > 0, False, True)
            cboDANG_NHAP.Enabled = cboKHO.Enabled
            'grdNhapkhoPTCT.ReadOnly = False
            'grdSLtheoViTri.ReadOnly = False
        Else
            cboKHO.Enabled = IIf(grdNhapkhoPTCT.Rows.Count > 0, False, True)
            cboDANG_NHAP.Enabled = cboKHO.Enabled
            'grdNhapkhoPTCT.ReadOnly = True
            'grdSLtheoViTri.ReadOnly = True
        End If
    End Sub

    Private Sub cboDANG_NHAP_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Nguoi_Nhap()
    End Sub

    Private Sub utcComboStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Danh_Sach_PN(CreateQuery())
        EnableButton()
    End Sub

    Private Sub cboFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Danh_Sach_PN(CreateQuery())
        EnableButton()

    End Sub

    'Private Sub grdDanhsachNhapkhoPT_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachNhapkhoPT.CellClick
    '    intRowCT = -1
    '    Me.FormatGridViTriKho()
    '    Me.grdSLtheoViTri.DataSource = New List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
    '    If e.RowIndex >= 0 Then
    '        Load_Phieu_Nhap(e.RowIndex)
    '    End If
    'End Sub

    Private Sub grdDanhsachNhapkhoPT_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachNhapkhoPT.RowEnter
        'intRowCT = -1
        Me.FormatGridViTriKho()
        Me.grdSLtheoViTri.DataSource = New List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
        If e.RowIndex >= 0 Then
            intRowDHN = e.RowIndex
            Load_Phieu_Nhap(e.RowIndex, False)
        Else
            intRowDHN = -1
        End If
    End Sub

    Private Sub grdDanhsachNhapkhoPT_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachNhapkhoPT.RowHeaderMouseClick
        Load_Phieu_Nhap(e.RowIndex, False)
    End Sub
    Function GetMS_VI_TRI(ByVal MS_PT As String)
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMS_VI_TRI", MS_PT)
        Dim tmp As Integer = 0
        While objReader.Read
            tmp = objReader.Item("MS_VI_TRI")
        End While
        objReader.Close()
        Return tmp
    End Function
    Private Sub grdNhapkhoPTCT_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNhapkhoPTCT.CellClick
        'Load_VTVT(e.RowIndex)
        Try
            If grdNhapkhoPTCT.Rows.Count > 0 Then
                grdNhapkhoPTCT.Rows(grdNhapkhoPTCT.CurrentCell.RowIndex).Cells("SL_THUC_NHAP").ReadOnly = True
                grdNhapkhoPTCT.Rows(grdNhapkhoPTCT.CurrentCell.RowIndex).Cells("SO_LUONG_CTU").ReadOnly = Not btnGhi.Visible
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Load_VTVT(ByVal RowIndex As Integer)
        If RowIndex >= 0 Then
            Try
                If intRowCT >= 0 Then
                    hasListVTSL.Remove(MS_PT_Current)
                    hasListVTSL.Add(MS_PT_Current, CType(Me.grdSLtheoViTri.DataSource, DataTable))
                End If
            Catch ex As Exception
            End Try
            intRowCT = RowIndex
            If RowIndex >= 0 Then
                FormatGridViTriKho()
                MS_PT_Current = grdNhapkhoPTCT.Rows(intRowCT).Cells("MS_PT").Value
                LoadViTriKho(MS_PT_Current)
            End If
        End If

        'If cboDANG_NHAP.SelectedValue = 21 Then
        '    For j As Integer = grdSLtheoViTri.RowCount - 1 To 0 Step -1
        '        If Integer.Parse(grdSLtheoViTri.Rows(j).Cells("SL_VT").Value) = 0 Then
        '            grdSLtheoViTri.Rows.RemoveAt(j)
        '        End If
        '    Next
        'End If
    End Sub
    Private Sub grdSLtheoViTri_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdSLtheoViTri.DataError
        e.Cancel = True
    End Sub

    Private Sub grdNhapkhoPTCT_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdNhapkhoPTCT.DataError
        If e.Context = 768 Then
            grdNhapkhoPTCT.BeginEdit(True)
            grdNhapkhoPTCT.Rows(e.RowIndex).Cells("BAO_HANH_DEN_NGAY").Value = "01/01/0001"
            grdNhapkhoPTCT.RefreshEdit()
            grdNhapkhoPTCT.EndEdit(True)
            Exit Sub
        End If

        e.Cancel = True
    End Sub

    Private Sub menuContext_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles menuContext.ItemClicked
        If e.ClickedItem.Name = "menuItemDelete" Then
            If actionButton And BtnXoa.Visible = False Then
                Dim result As DialogResult = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDelete_Don_Hang_Nhap_Vat_Tu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Message_Title", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = Windows.Forms.DialogResult.Yes Then
                    For i As Integer = 0 To Me.lstDonHangNhapVatTu.Count - 1
                        If Me.lstDonHangNhapVatTu.Item(i).MS_PT = MaPT Then
                            Me.lstDonHangNhapVatTu.RemoveAt(i)
                            Me.hasListVTSL.Remove(MaPT)
                            Exit For
                        End If
                    Next
                    Me.grdNhapkhoPTCT.DataSource = lstDonHangNhapVatTu
                    Me.FormatGridNhapKhoPTCT()
                    Me.SetReadOnlyColumn(False)
                    Try
                        If Me.grdNhapkhoPTCT.RowCount > 0 Then
                            MaPT = Me.grdNhapkhoPTCT.Item("MS_PT", Me.grdNhapkhoPTCT.CurrentRow.Index).Value.ToString
                            Me.FormatGridViTriKho()
                            Me.grdSLtheoViTri.DataSource = CType(Me.hasListVTSL.Item(MaPT), List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info))
                            Me.grdSLtheoViTri.Refresh()
                        Else
                            Me.FormatGridViTriKho()
                            Me.grdSLtheoViTri.DataSource = New List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
                            Me.grdSLtheoViTri.Refresh()
                        End If
                    Catch
                    End Try
                End If
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ban_khong_co_quyen_xoa_du_lieu_nay", Commons.Modules.TypeLanguage))
            End If
        End If
        If grdNhapkhoPTCT.Rows.Count > 0 Then Load_VTVT(0)
        cboKHO.Enabled = IIf(grdNhapkhoPTCT.Rows.Count > 0, False, True)
        cboDANG_NHAP.Enabled = cboKHO.Enabled
    End Sub

    Private Sub grdNhapkhoPTCT_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdNhapkhoPTCT.CellValidating
        'Dim dt As DataTable = New DataTable()
        'dt = CType(Me.grdSLtheoViTri.DataSource, DataTable)
        'Dim ss As String = dt.Columns("SL_VT").DataType.ToString


        If btnKhongGhi.Focused Then
            Exit Sub
        End If
        Dim cell As DataGridViewCell = Me.grdNhapkhoPTCT.Item(e.ColumnIndex, e.RowIndex)
        If cell.IsInEditMode Then
            Dim ctr As Control = Me.grdNhapkhoPTCT.EditingControl
            Select Case Me.grdNhapkhoPTCT.Columns(e.ColumnIndex).Name
                Case "SO_LUONG_CTU"
                    Try
                        'Dim s As String = tb.Columns("SL_VT").DataType.ToString

                        If ctr.Text <> "" Then
                            Dim SL_CTU As Double = Double.Parse(ctr.Text)
                            If SL_CTU < 0 Then
                                ctr.Text = 0
                                e.Cancel = True
                            Else
                                Me.grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value = SL_CTU
                                grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = SL_CTU * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("TY_GIA").Value
                            End If
                            If grdSLtheoViTri.Rows.Count > 0 Then
                                'grdSLtheoViTri.Rows(0).Cells("SL_VT").Value = SL_CTU

                                'tìm vị trí trong kho của vật tư và chọn vào vị trí đó, nếu không có vị trí thì chọn vị trí là "-"
                                Dim dtReader As SqlDataReader
                                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT IC_PHU_TUNG.MS_PT, IC_PHU_TUNG.MS_VI_TRI,VI_TRI_KHO.TEN_VI_TRI FROM IC_PHU_TUNG INNER JOIN VI_TRI_KHO ON IC_PHU_TUNG.MS_VI_TRI=VI_TRI_KHO.MS_VI_TRI WHERE VI_TRI_KHO.MS_KHO=" & cboKHO.SelectedValue & " AND IC_PHU_TUNG.MS_PT='" & grdNhapkhoPTCT.Rows(e.RowIndex).Cells("MS_PT").Value & "'")
                                dtReader.Read()
                                If dtReader.HasRows Then    'NẾU CÓ VỊ TRÍ THÌ GÁN SL VÀO VỊ TRÍ ĐÓ TRONG KHO
                                    For i As Integer = 0 To grdSLtheoViTri.Rows.Count - 1
                                        If grdSLtheoViTri.Rows(i).Cells("MS_VI_TRI").Value = dtReader.Item("MS_VI_TRI") Then
                                            ' Dim ssss As String = grdSLtheoViTri.Columns("SL_VT").DefaultCellStyle.Format
                                            grdSLtheoViTri.Rows(i).Cells("SL_VT").Value = SL_CTU
                                            'Dim sadh As Double = grdSLtheoViTri.Rows(0).Cells("SL_VT").Value
                                            ' Dim dtgg As DataTable = CType(grdSLtheoViTri.DataSource, DataTable)
                                            ' Dim ssssss As String = dtgg.Columns("SL_VT").DataType.ToString
                                            'Dim sstype As String = grdSLtheoViTri.Columns("SL_VT").DefaultCellStyle ';GetType().ToString
                                            Exit For
                                        End If
                                    Next
                                Else    'NẾU KHÔNG CÓ VỊ TRÍ THÌ GÁN LÀ 1 -> KHÔNG CÓ VỊ TRÍ
                                    For i As Integer = 0 To grdSLtheoViTri.Rows.Count - 1
                                        If grdSLtheoViTri.Rows(i).Cells("MS_VI_TRI").Value = 1 Then
                                            grdSLtheoViTri.Rows(i).Cells("SL_VT").Value = SL_CTU
                                            Exit For
                                        End If
                                    Next
                                End If

                                'tính lại tổng số lượng ở tất cả các vị trí của vật tư trong kho
                                Dim SL_THUC_NHAP As Double = 0

                                Dim sad As Double = grdSLtheoViTri.Rows(0).Cells("SL_VT").Value
                                ' Dim sada As Double = grdSLtheoViTri.Rows(1).Cells("SL_VT").Value
                                For i As Integer = 0 To grdSLtheoViTri.Rows.Count - 1
                                    Dim s As Double = grdSLtheoViTri.Rows(i).Cells("SL_VT").Value
                                    If grdSLtheoViTri.Rows(i).Cells("SL_VT").Value > 0 Then SL_THUC_NHAP = SL_THUC_NHAP + grdSLtheoViTri.Rows(i).Cells("SL_VT").Value
                                Next
                                grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value = SL_THUC_NHAP

                                If grdSLtheoViTri.Rows.Count > 0 Then
                                    hasListVTSL.Remove(grdNhapkhoPTCT.Rows(intRowCT).Cells("MS_PT").Value)
                                    hasListVTSL.Add(grdNhapkhoPTCT.Rows(intRowCT).Cells("MS_PT").Value, CType(Me.grdSLtheoViTri.DataSource, DataTable))
                                End If
                            End If
                        Else

                            e.Cancel = True
                        End If
                    Catch ex As Exception
                        ctr.Text = ""
                        e.Cancel = True
                    End Try
                    Exit Select
                Case "SL_THUC_NHAP"
                    Try
                        If ctr.Text <> "" Then
                            Dim SL_THUC_NHAP As Double = Double.Parse(ctr.Text)
                            If SL_THUC_NHAP < 0 Then
                                ctr.Text = 0
                                e.Cancel = True
                            Else
                                grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = SL_THUC_NHAP * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("TY_GIA").Value
                            End If
                            If grdSLtheoViTri.Rows.Count > 0 Then
                                grdSLtheoViTri.Rows(0).Cells("SL_VT").Value = SL_THUC_NHAP
                            End If
                        Else
                            ctr.Text = 0
                            'Try
                            '    ctr.Text = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SO_LUONG_CTU").Value
                            'Catch ex As Exception
                            '    e.Cancel = True
                            'End Try
                            If grdSLtheoViTri.Rows.Count > 0 Then
                                grdSLtheoViTri.Rows(0).Cells("SL_VT").Value = 0
                            End If

                        End If
                    Catch ex As Exception
                        e.Cancel = True
                    End Try
                    Exit Select
                Case "BAO_HANH_DEN_NGAY"
                    If ctr.Text.ToString = "" Or ctr.Text.ToString = "  /  /" Then Exit Sub

                    If IsDate(ctr.Text) Then
                        If ctr.Text.ToString = "01/01/0001" Then
                            ctr.Text = ""
                            Exit Sub
                        Else
                            If Format(ctr.Text, "short date") < Format(dtpNGAY_NHAP.Value, "short date") Then
                                If MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaybaohanhnhohonngaynhap", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, "VietSoft") = Windows.Forms.DialogResult.No Then
                                    ctr.Text = ""
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgaybaohankhonghople", Commons.Modules.TypeLanguage))
                        ctr.Text = ""
                        e.Cancel = True
                        Exit Sub
                    End If
                    Exit Select
                Case "DON_GIA"
                    Try
                        If ctr.Text <> "" Then
                            If IsNumeric(ctr.Text) Then
                                If Double.Parse(ctr.Text) < 0 Then
                                    ' Đơn giá phải lớn hơn 0 ! Bạn vui lòng nhập lại !
                                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDongianhohonkhong", Commons.Modules.TypeLanguage))
                                    ctr.Text = 0
                                    grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("TY_GIA").Value
                                    e.Cancel = True
                                Else
                                    grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("TY_GIA").Value
                                End If
                            Else
                                ' Đơn giá phải là kiểu số ! Bạn vui lòng nhập lại !
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDongiasai", Commons.Modules.TypeLanguage))
                                ctr.Text = 0
                                grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("TY_GIA").Value
                                e.Cancel = True
                            End If
                        End If
                    Catch ex As Exception
                        ctr.Text = 0
                        e.Cancel = True
                    End Try
                    Exit Select
                Case "NGOAI_TE"
                    Dim CTRL As DataGridViewComboBoxEditingControl = CType(ctr, DataGridViewComboBoxEditingControl)
                    Me.grdNhapkhoPTCT.Item("TY_GIA", e.RowIndex).Value = Me.objDonHangNhapPTController.Load_Ty_Gia_Theo_Ngoai_Te(CTRL.SelectedValue.ToString)
                    Me.grdNhapkhoPTCT.Item("TY_GIA_USD", e.RowIndex).Value = Me.objDonHangNhapPTController.Load_Ty_Gia_USD_Theo_Ngoai_Te(CTRL.SelectedValue.ToString)

                    grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("TY_GIA").Value

                    Exit Select
                Case "TY_GIA"
                    If ctr.Text = "" Then
                        e.Cancel = True
                    Else
                        If IsNumeric(ctr.Text) Then
                            If Double.Parse(ctr.Text) < 0 Then
                                ' Tỷ giá phải lớn hơn 0 ! Bạn vui lòng nhập lại !
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiaam", Commons.Modules.TypeLanguage))
                                ctr.Text = 0
                                grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value
                                e.Cancel = True
                            Else
                                grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value
                            End If
                        Else
                            ' Tỷ giá phải là kiểu số ! Bạn vui lòng nhập lại !
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiasai", Commons.Modules.TypeLanguage))
                            ctr.Text = 0
                            grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value
                            e.Cancel = True
                        End If
                    End If
                Case "TY_GIA_USD"
                    If ctr.Text = "" Then
                        e.Cancel = True
                    Else
                        If IsNumeric(ctr.Text) Then
                            If Double.Parse(ctr.Text) < 0 Then
                                ' Tỷ giá USD phải lớn hơn 0 ! Bạn vui lòng nhập lại !
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiaUSDam", Commons.Modules.TypeLanguage))
                                ctr.Text = 0
                                'grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value
                                e.Cancel = True
                            Else
                                'grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value
                            End If
                        Else
                            ' Tỷ giá USD phải là kiểu số ! Bạn vui lòng nhập lại !
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTygiaUSDsai", Commons.Modules.TypeLanguage))
                            ctr.Text = 0
                            'grdNhapkhoPTCT.Rows(e.RowIndex).Cells("THANH_TIEN").Value = grdNhapkhoPTCT.Rows(e.RowIndex).Cells("SL_THUC_NHAP").Value * Double.Parse(ctr.Text) * grdNhapkhoPTCT.Rows(e.RowIndex).Cells("DON_GIA").Value
                            e.Cancel = True
                        End If
                    End If
            End Select
        End If

    End Sub

    Private Sub grdSLtheoViTri_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdSLtheoViTri.CellValidating
        Dim cell As DataGridViewCell = Me.grdSLtheoViTri.Item(e.ColumnIndex, e.RowIndex)
        If cell.IsInEditMode Then
            Dim ctr As Control = Me.grdSLtheoViTri.EditingControl
            Select Case Me.grdSLtheoViTri.Columns(e.ColumnIndex).Name
                Case "SL_VT"
                    Try
                        Dim SL_NHAP As Double = 0
                        If ctr.Text <> "" Then
                            SL_NHAP = Double.Parse(ctr.Text)
                            If SL_NHAP < 0 Then
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KT_SL_NHAP_CHI_TIET_1", Commons.Modules.TypeLanguage))
                                ctr.Text = ""
                                e.Cancel = True
                            End If

                            'For i As Integer = 0 To Me.grdSLtheoViTri.RowCount - 1
                            '    If i <> e.RowIndex Then
                            '        If Me.grdSLtheoViTri.Rows(i).Cells("SL_VT").Value IsNot Nothing Then
                            '            SL_NHAP += Double.Parse(Me.grdSLtheoViTri.Rows(i).Cells("SL_VT").Value.ToString)
                            '        End If
                            '    End If
                            'Next
                            'For i As Integer = 0 To Me.lstDonHangNhapVatTu.Count - 1
                            '    If Me.lstDonHangNhapVatTu.Item(i).MS_PT = Me.grdSLtheoViTri.Rows(0).Cells("MS_PT").Value.ToString Then
                            '        If SL_NHAP > Double.Parse(Me.lstDonHangNhapVatTu.Item(i).SL_THUC_NHAP) Then
                            '            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "KT_SL_NHAP_CHI_TIET_2", commons.Modules.TypeLanguage))
                            '            ctr.Text = ""
                            '            e.Cancel = True
                            '            Return
                            '        End If
                            '    End If
                            'Next

                        End If
                        For i As Integer = 0 To Me.grdSLtheoViTri.RowCount - 1
                            If i <> e.RowIndex Then
                                SL_NHAP += IIf(grdSLtheoViTri.Rows(i).Cells("SL_VT").Value Is Nothing, 0, grdSLtheoViTri.Rows(i).Cells("SL_VT").Value)
                            End If
                        Next
                        grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value = SL_NHAP
                        'grdNhapkhoPTCT.Rows(intRowCT).Cells("SO_LUONG_CTU").Value = SL_NHAP
                    Catch ex As Exception
                        e.Cancel = True
                    End Try
                    Exit Select
            End Select
        End If

    End Sub
#End Region

#Region "Sub Class"
    Class NGUOINHAP_Info
        Dim _ma As String = ""
        Dim _ten As String = ""
        Public Sub New()

        End Sub
        Public Property MA() As String
            Get
                Return _ma
            End Get
            Set(ByVal value As String)
                _ma = value
            End Set
        End Property
        Public Property TEN() As String
            Get
                Return _ten
            End Get
            Set(ByVal value As String)
                _ten = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return _ten
        End Function
    End Class
#End Region

    Private Sub cboKHO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboKHO.SelectedIndexChanged
        If Me.grdNhapkhoPTCT.RowCount > 0 Then
            hasListVTSL.Clear()
            Me.FormatGridNhapKhoPTCT()
            FormatGridViTriKho()
            Me.SetReadOnlyColumn(False)
            If cboDANG_NHAP.SelectedValue = 21 Or cboDANG_NHAP.SelectedValue = 28 Then
                cboDDH.Enabled = True
                Try
                    cboDDH.SelectedIndex = 0
                Catch ex As Exception
                End Try
                lstDonHangNhapVatTu.Clear()
                SoLuongViTri()
            Else
                cboDDH.SelectedValue = "-1"
                cboDDH.Enabled = False
                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
                    Dim tb As New DataTable()
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI," & lstDonHangNhapVatTu.Item(i).SL_THUC_NHAP & " AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "'").Tables(0)
                    Me.hasListVTSL.Add(lstDonHangNhapVatTu.Item(i).MS_PT, tb)
                    lstDonHangNhapVatTu.Item(i).SO_LUONG_CTU = 0
                Next
            End If
            grdNhapkhoPTCT.DataSource = lstDonHangNhapVatTu
            If grdNhapkhoPTCT.Rows.Count > 0 Then
                LoadViTriKho(grdNhapkhoPTCT.Rows(0).Cells("MS_PT").Value)
                intRowCT = 0
            End If
        Else
            If cboDANG_NHAP.SelectedValue = 21 Or cboDANG_NHAP.SelectedValue = 28 Then
                cboDDH.Enabled = True
                Try
                    cboDDH.SelectedIndex = 0
                Catch ex As Exception
                End Try
                SoLuongViTri()
                FormatGridViTriKho()
            Else
                cboDDH.SelectedIndex = -1
                cboDDH.Enabled = False
            End If
        End If
    End Sub

    Private Sub cboLockho_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLockho.SelectionChangeCommitted
        Me.grdSLtheoViTri.DataSource = System.DBNull.Value
        Me.grdNhapkhoPTCT.DataSource = System.DBNull.Value
        Clear()
        txtMS_DH_NHAP.Text = ""
        txtGIO_NHAP.Text = ""
        Load_Danh_Sach_PN(CreateQuery())
        FormatGridViTriKho()
        FormatGridNhapKhoPTCT()

    End Sub

    Private Sub chkLock_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLock.CheckedChanged
        If Me.chkLock.Checked Then
            Me.btnSua.Enabled = False
            Me.BtnXoa.Enabled = False
            Me.btnLock_PN.Enabled = False
        Else
            Me.btnSua.Enabled = True
            Me.BtnXoa.Enabled = True
            Me.btnLock_PN.Enabled = True
        End If
    End Sub
    Dim intRowCT As Integer = -1
    Private Sub grdNhapkhoPTCT_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNhapkhoPTCT.RowEnter
        intRowCT = e.RowIndex
        MaPT = Me.grdNhapkhoPTCT.Item("MS_PT", e.RowIndex).Value.ToString
        Load_VTVT(e.RowIndex)
    End Sub
    Dim txtNhapKho As TextBox
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
    Private Sub grdNhapkhoPTCT_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdNhapkhoPTCT.EditingControlShowing
        Try
            If Me.grdNhapkhoPTCT.CurrentCellAddress.X = 1 Or Me.grdNhapkhoPTCT.CurrentCellAddress.X = 2 Then
                txtNhapKho = e.Control

                RemoveHandler txtNhapKho.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtNhapKho.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtNhapKho.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdSLtheoViTri_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdSLtheoViTri.EditingControlShowing
        Try
            If Me.grdSLtheoViTri.CurrentCellAddress.X = 2 Then
                txtNhapKho = e.Control
                RemoveHandler txtNhapKho.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtNhapKho.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtNhapKho.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboNGUOI_NHAP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboNGUOI_NHAP.Validating
        If btnKhongGhi.Focused() Then
            Exit Sub
        End If
        'If cboNGUOI_NHAP.SelectedValue Is Nothing Then
        '    e.Cancel = True
        'End If
    End Sub
    Function TimPhieuNhap(ByVal GiaTri As String) As String
        Dim dang_nhap As String = "DANG_NHAP_VIET"
        Select Case dang_nhap
            Case 1
                dang_nhap = "DANG_NHAP_ANH"
                Exit Select
            Case 2
                dang_nhap = "DANG_NHAP_HOA"
                Exit Select
        End Select
        Dim str As String = ""
        str = "SELECT PN.MS_DH_NHAP_PT,PN.SO_PHIEU_XN,KHCN.TEN_NGUOI_NHAP," + dang_nhap + " AS DANG_NHAP,CONVERT(CHAR(10),PN.NGAY,103) + ' ' + CONVERT(CHAR(8),PN.GIO,8) AS NGAY_NHAP ,MS_DDH" & _
        " FROM IC_DON_HANG_NHAP PN INNER JOIN DANG_NHAP DN ON DN.MS_DANG_NHAP=PN.MS_DANG_NHAP " & _
        " INNER JOIN KHACH_HANG_CONG_NHAN KHCN  ON PN.MS_DANG_NHAP=KHCN.MS_DANG_NHAP AND PN.NGUOI_NHAP=KHCN.NGUOI_NHAP " & _
       " where Pn.SO_PHIEU_XN LIKE '%'+ '" & GiaTri & "'+ '%'" & _
       " order by PN.NGAY"
        Return str
    End Function
    Private Sub txtTim_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTim.KeyDown
        If e.KeyValue <> 21 Then
            Load_Danh_Sach_PN(TimPhieuNhap(txtTim.Text))
        End If
    End Sub
    Sub SoLuongViTri()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_DAT_HANG_CHI_TIETs1", txtMS_DH_NHAP.Text, cboDDH.SelectedValue.ToString, Commons.Modules.TypeLanguage)
            lstDonHangNhapVatTu = New List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
            Dim i As Integer = 0

            Me.hasListVTSL.Clear()
            While objReader.Read
                Dim TbKho As DataTable = New DataTable()
                TbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "Select Vi_Tri_Kho.* From  dbo.IC_PHU_TUNG INNER JOIN dbo.VI_TRI_KHO ON dbo.IC_PHU_TUNG.MS_VI_TRI = dbo.VI_TRI_KHO.MS_VI_TRI Where IC_PHU_TUNG.MS_PT = '" & objReader.Item("MS_PT") & "' AND VI_TRI_KHO.MS_KHO <> " & Me.cboKHO.SelectedValue & ""))
                If (TbKho.Rows.Count > 0) Then
                    If (XtraMessageBox.Show("Phụ tùng " & objReader.Item("MS_PT").ToString() & " Không thộc kho bạn chọn, bạn có muốn thêm phụ tùng này không?", "Vietsoft", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                        Dim objDonHangNhapVatTuInfo As New IC_DON_HANG_NHAP_VAT_TU_Info
                        objDonHangNhapVatTuInfo.MS_PT = objReader.Item("MS_PT")
                        objDonHangNhapVatTuInfo.MS_DH_NHAP_PT = Me.txtMS_DH_NHAP.Text
                        objDonHangNhapVatTuInfo.TY_GIA = Me.objDonHangNhapPTController.Load_Ty_Gia
                        '--------------------
                        objDonHangNhapVatTuInfo.TY_GIA_USD = Me.objDonHangNhapPTController.Load_Ty_Gia_USD
                        objDonHangNhapVatTuInfo.NGOAI_TE = Me.objDonHangNhapPTController.Load_Ngoai_Te
                        Dim objPhuTung As IC_PHU_TUNG_Info = Me.objDonHangNhapPTController.Load_Phu_Tung(objDonHangNhapVatTuInfo.MS_PT)
                        objDonHangNhapVatTuInfo.TEN_PT = objReader.Item("TEN_PT")
                        objDonHangNhapVatTuInfo.DON_VI_TINH = objReader.Item("DVT")
                        objDonHangNhapVatTuInfo.DON_GIA = objReader.Item("DON_GIA")
                        objDonHangNhapVatTuInfo.MS_VT_NCC = Nothing
                        objDonHangNhapVatTuInfo.XUAT_XU = Nothing
                        objDonHangNhapVatTuInfo.THANH_TIEN = objReader.Item("SL_THUC_NHAP") * objReader.Item("DON_GIA")
                        objDonHangNhapVatTuInfo.SO_LUONG_CTU = objReader.Item("SO_LUONG_CTU")

                        If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
                            objDonHangNhapVatTuInfo.SL_THUC_NHAP = IIf(grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value > 0, grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value, objReader.Item("SL_THUC_NHAP"))
                        Else
                            objDonHangNhapVatTuInfo.SL_THUC_NHAP = objReader.Item("SL_THUC_NHAP")
                        End If

                        lstDonHangNhapVatTu.Add(objDonHangNhapVatTuInfo)
                        Dim tb As New DataTable()
                        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1 NULL AS MS_DH_NHAP_PT,'" & objReader.Item("MS_PT").ToString().Trim() & "',MS_VI_TRI,CONVERT(FLOAT,NULL) AS SL_VT,NULL AS TEN_VI_TRI FROM VI_TRI_KHO WHERE MS_KHO =" & cboKHO.SelectedValue).Tables(0)
                        For i = 0 To tb.Rows.Count - 1
                            tb.Rows(i).Item("SL_VT") = objReader.Item("SO_LUONG_CTU")
                        Next
                        Me.hasListVTSL.Add(objReader.Item("MS_PT"), tb)
                    End If
                Else
                    Dim objDonHangNhapVatTuInfo As New IC_DON_HANG_NHAP_VAT_TU_Info
                    objDonHangNhapVatTuInfo.MS_PT = objReader.Item("MS_PT")
                    objDonHangNhapVatTuInfo.MS_DH_NHAP_PT = Me.txtMS_DH_NHAP.Text
                    objDonHangNhapVatTuInfo.TY_GIA = Me.objDonHangNhapPTController.Load_Ty_Gia
                    '--------------------
                    objDonHangNhapVatTuInfo.TY_GIA_USD = Me.objDonHangNhapPTController.Load_Ty_Gia_USD
                    objDonHangNhapVatTuInfo.NGOAI_TE = Me.objDonHangNhapPTController.Load_Ngoai_Te
                    Dim objPhuTung As IC_PHU_TUNG_Info = Me.objDonHangNhapPTController.Load_Phu_Tung(objDonHangNhapVatTuInfo.MS_PT)
                    objDonHangNhapVatTuInfo.TEN_PT = objReader.Item("TEN_PT")
                    objDonHangNhapVatTuInfo.DON_VI_TINH = objReader.Item("DVT")
                    objDonHangNhapVatTuInfo.DON_GIA = objReader.Item("DON_GIA")
                    objDonHangNhapVatTuInfo.MS_VT_NCC = Nothing
                    objDonHangNhapVatTuInfo.XUAT_XU = Nothing
                    objDonHangNhapVatTuInfo.THANH_TIEN = objReader.Item("SL_THUC_NHAP") * objReader.Item("DON_GIA")
                    objDonHangNhapVatTuInfo.SO_LUONG_CTU = objReader.Item("SO_LUONG_CTU")

                    If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
                        objDonHangNhapVatTuInfo.SL_THUC_NHAP = IIf(grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value > 0, grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value, objReader.Item("SL_THUC_NHAP"))
                    Else
                        objDonHangNhapVatTuInfo.SL_THUC_NHAP = objReader.Item("SL_THUC_NHAP")
                    End If

                    lstDonHangNhapVatTu.Add(objDonHangNhapVatTuInfo)
                    Dim tb As New DataTable()
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI,CONVERT(FLOAT,NULL) AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & objReader.Item("MS_PT") & "'").Tables(0)
                    For i = 0 To tb.Rows.Count - 1
                        tb.Rows(i).Item("SL_VT") = objReader.Item("SO_LUONG_CTU")
                    Next
                    Me.hasListVTSL.Add(objReader.Item("MS_PT"), tb)
                End If
            End While
            objReader.Close()
            grdNhapkhoPTCT.DataSource = lstDonHangNhapVatTu
            If grdNhapkhoPTCT.Rows.Count > 0 Then
                LoadViTriKho(grdNhapkhoPTCT.Rows(0).Cells("MS_PT").Value)
                intRowCT = 0
            End If
            Me.FormatGridNhapKhoPTCT()
            SetReadOnlyColumn(False)
        Catch ex As Exception

        End Try
        'If cboDANG_NHAP.SelectedValue <> 21 Then
        '    grdNhapkhoPTCT.ReadOnly = False
        '    grdSLtheoViTri.ReadOnly = False
        'Else
        '    grdNhapkhoPTCT.ReadOnly = True
        '    grdSLtheoViTri.ReadOnly = True
        'End If
        Me.Cursor = Cursors.Default
    End Sub

    Sub SoLuongViTri_DXMH()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDE_XUAT_MUA_HANG_CHI_TIETs1", txtMS_DH_NHAP.Text, cboDDH.SelectedValue.ToString, Commons.Modules.TypeLanguage)
            lstDonHangNhapVatTu = New List(Of IC_DON_HANG_NHAP_VAT_TU_Info)
            Dim i As Integer = 0

            Me.hasListVTSL.Clear()
            While objReader.Read
                Dim TbKho As DataTable = New DataTable()
                TbKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString(), CommandType.Text, "Select Vi_Tri_Kho.* From  dbo.IC_PHU_TUNG INNER JOIN dbo.VI_TRI_KHO ON dbo.IC_PHU_TUNG.MS_VI_TRI = dbo.VI_TRI_KHO.MS_VI_TRI Where IC_PHU_TUNG.MS_PT = '" & objReader.Item("MS_PT") & "' AND VI_TRI_KHO.MS_KHO <> " & Me.cboKHO.SelectedValue & ""))
                If (TbKho.Rows.Count > 0) Then
                    If (XtraMessageBox.Show("Phụ tùng " & objReader.Item("MS_PT").ToString() & " Không thuộc kho bạn chọn, bạn có muốn thêm phụ tùng này không?", "Vietsoft", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                        Dim objDonHangNhapVatTuInfo As New IC_DON_HANG_NHAP_VAT_TU_Info
                        objDonHangNhapVatTuInfo.MS_PT = objReader.Item("MS_PT")
                        objDonHangNhapVatTuInfo.MS_DH_NHAP_PT = Me.txtMS_DH_NHAP.Text
                        objDonHangNhapVatTuInfo.TY_GIA = Me.objDonHangNhapPTController.Load_Ty_Gia
                        '--------------------
                        objDonHangNhapVatTuInfo.TY_GIA_USD = Me.objDonHangNhapPTController.Load_Ty_Gia_USD
                        objDonHangNhapVatTuInfo.NGOAI_TE = Me.objDonHangNhapPTController.Load_Ngoai_Te
                        Dim objPhuTung As IC_PHU_TUNG_Info = Me.objDonHangNhapPTController.Load_Phu_Tung(objDonHangNhapVatTuInfo.MS_PT)
                        objDonHangNhapVatTuInfo.TEN_PT = objReader.Item("TEN_PT")
                        objDonHangNhapVatTuInfo.DON_VI_TINH = objReader.Item("DVT")
                        objDonHangNhapVatTuInfo.DON_GIA = objReader.Item("DON_GIA")
                        objDonHangNhapVatTuInfo.MS_VT_NCC = Nothing
                        objDonHangNhapVatTuInfo.XUAT_XU = Nothing
                        objDonHangNhapVatTuInfo.THANH_TIEN = objReader.Item("SL_THUC_NHAP") * objReader.Item("DON_GIA")
                        objDonHangNhapVatTuInfo.SO_LUONG_CTU = objReader.Item("SO_LUONG_CTU")

                        If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
                            objDonHangNhapVatTuInfo.SL_THUC_NHAP = IIf(grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value > 0, grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value, objReader.Item("SL_THUC_NHAP"))
                        Else
                            objDonHangNhapVatTuInfo.SL_THUC_NHAP = objReader.Item("SL_THUC_NHAP")
                        End If

                        lstDonHangNhapVatTu.Add(objDonHangNhapVatTuInfo)
                        Dim tb As New DataTable()
                        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI,CONVERT(FLOAT,NULL) AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & objReader.Item("MS_PT") & "'").Tables(0)
                        For i = 0 To tb.Rows.Count - 1
                            tb.Rows(i).Item("SL_VT") = objReader.Item("SO_LUONG_CTU")
                        Next
                        Me.hasListVTSL.Add(objReader.Item("MS_PT"), tb)
                    End If
                Else
                    Dim objDonHangNhapVatTuInfo As New IC_DON_HANG_NHAP_VAT_TU_Info
                    objDonHangNhapVatTuInfo.MS_PT = objReader.Item("MS_PT")
                    objDonHangNhapVatTuInfo.MS_DH_NHAP_PT = Me.txtMS_DH_NHAP.Text
                    objDonHangNhapVatTuInfo.TY_GIA = Me.objDonHangNhapPTController.Load_Ty_Gia
                    '--------------------
                    objDonHangNhapVatTuInfo.TY_GIA_USD = Me.objDonHangNhapPTController.Load_Ty_Gia_USD
                    objDonHangNhapVatTuInfo.NGOAI_TE = Me.objDonHangNhapPTController.Load_Ngoai_Te
                    Dim objPhuTung As IC_PHU_TUNG_Info = Me.objDonHangNhapPTController.Load_Phu_Tung(objDonHangNhapVatTuInfo.MS_PT)
                    objDonHangNhapVatTuInfo.TEN_PT = objReader.Item("TEN_PT")
                    objDonHangNhapVatTuInfo.DON_VI_TINH = objReader.Item("DVT")
                    objDonHangNhapVatTuInfo.DON_GIA = objReader.Item("DON_GIA")
                    objDonHangNhapVatTuInfo.MS_VT_NCC = Nothing
                    objDonHangNhapVatTuInfo.XUAT_XU = Nothing
                    objDonHangNhapVatTuInfo.THANH_TIEN = objReader.Item("SL_THUC_NHAP") * objReader.Item("DON_GIA")
                    objDonHangNhapVatTuInfo.SO_LUONG_CTU = objReader.Item("SO_LUONG_CTU")

                    If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
                        objDonHangNhapVatTuInfo.SL_THUC_NHAP = IIf(grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value > 0, grdNhapkhoPTCT.Rows(intRowCT).Cells("SL_THUC_NHAP").Value, objReader.Item("SL_THUC_NHAP"))
                    Else
                        objDonHangNhapVatTuInfo.SL_THUC_NHAP = objReader.Item("SL_THUC_NHAP")
                    End If

                    lstDonHangNhapVatTu.Add(objDonHangNhapVatTuInfo)
                    Dim tb As New DataTable()
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI,CONVERT(FLOAT,NULL) AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & objReader.Item("MS_PT") & "'").Tables(0)
                    For i = 0 To tb.Rows.Count - 1
                        tb.Rows(i).Item("SL_VT") = objReader.Item("SO_LUONG_CTU")
                    Next
                    Me.hasListVTSL.Add(objReader.Item("MS_PT"), tb)
                End If

            End While
            objReader.Close()
            grdNhapkhoPTCT.DataSource = lstDonHangNhapVatTu
            If grdNhapkhoPTCT.Rows.Count > 0 Then
                LoadViTriKho(grdNhapkhoPTCT.Rows(0).Cells("MS_PT").Value)
                intRowCT = 0
            End If
            Me.FormatGridNhapKhoPTCT()
            SetReadOnlyColumn(False)
        Catch ex As Exception

        End Try
        'If cboDANG_NHAP.SelectedValue <> 21 Then
        '    grdNhapkhoPTCT.ReadOnly = False
        '    grdSLtheoViTri.ReadOnly = False
        'Else
        '    grdNhapkhoPTCT.ReadOnly = True
        '    grdSLtheoViTri.ReadOnly = True
        'End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboDDH_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDDH.SelectionChangeCommitted
        If btnGhi.Visible Then
            If cboDANG_NHAP.SelectedValue = 21 Then
                Commons.Modules.SQLString = "SELECT MS_KH FROM DON_DAT_HANG WHERE MS_DDH='" & cboDDH.SelectedValue & "'"
                Dim dtReader As SqlDataReader
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    cboNGUOI_NHAP.SelectedValue = dtReader.Item(0)
                End While
                dtReader.Close()
                lstDonHangNhapVatTu.Clear()
                SoLuongViTri()

                'For j As Integer = grdSLtheoViTri.RowCount - 1 To 0 Step -1
                '    If grdSLtheoViTri.Rows(j).Cells("SL_VT").Value = 0 Then grdSLtheoViTri.Rows.RemoveAt(j)
                'Next
            ElseIf cboDANG_NHAP.SelectedValue = 28 Then
                Commons.Modules.SQLString = "SELECT MS_KH FROM DE_XUAT_MUA_HANG_CHI_TIET WHERE SO_DE_XUAT='" & cboDDH.SelectedValue & "'"
                Dim dtReader As SqlDataReader
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Commons.Modules.SQLString)
                While dtReader.Read
                    cboNGUOI_NHAP.SelectedValue = dtReader.Item(0)
                End While
                dtReader.Close()
                lstDonHangNhapVatTu.Clear()
                SoLuongViTri_DXMH()
            End If
        End If
    End Sub
    Private Sub cboDDH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboDDH.Validating
        'If btnGhi.Visible Then
        '    If cboDANG_NHAP.SelectedValue <> 13 Then
        '        SoLuongViTri()
        '    End If
        'End If
    End Sub


    Private Sub grdSLtheoViTri_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdSLtheoViTri.RowValidating
        ' dùng để kiểm tra trường hợp nhập số lượng nhưng không nhập ms_vi_tri
        'If btnKhongGhi.Focused() Then
        '    Exit Sub
        'ElseIf btnGhi.Visible Then
        '    If e.RowIndex < grdSLtheoViTri.RowCount - 1 Then
        '        Try
        '            If grdSLtheoViTri.Rows(e.RowIndex).Cells("MS_VI_TRI").Value.ToString = "" Then
        '                grdSLtheoViTri.CurrentCell() = grdSLtheoViTri.Rows(e.RowIndex).Cells("MS_VI_TRI")
        '                grdSLtheoViTri.Focus()
        '                e.Cancel = True
        '            End If
        '        Catch ex As Exception
        '        End Try
        '    End If
        'End If
    End Sub

    Private Sub grdSLtheoViTri_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSLtheoViTri.KeyDown
        ''trường hợp cho nhập nhiều vị trí kho
        'If e.KeyCode = Keys.Escape Then
        '    If grdSLtheoViTri.RowCount > 2 Then
        '        If Not grdSLtheoViTri.CurrentRow.IsNewRow Then
        '            grdSLtheoViTri.Rows.RemoveAt(Me.grdSLtheoViTri.CurrentRow.Index)
        '        End If
        '    Else
        '        LoadViTriKho(grdNhapkhoPTCT.Rows(intRowCT).Cells("MS_PT").Value)
        '    End If
        'End If
    End Sub

    Private Sub cboDANG_NHAP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDANG_NHAP.SelectedIndexChanged
        Try
            If cboDANG_NHAP.SelectedValue = 28 Then
                'LoadcboDXMH()
                lblDonDatHang.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LBL_DE_XUAT_MUA_HANG", Commons.Modules.TypeLanguage)
            Else 'If cboDANG_NHAP.SelectedValue = 21 Then
                lblDonDatHang.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LBL_DON_DAT_HANG", Commons.Modules.TypeLanguage)
                'LoadcboDDH()
            End If
        Catch
        End Try
    End Sub

    Private Sub cboDANG_NHAP_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDANG_NHAP.SelectionChangeCommitted
        If cboDANG_NHAP.SelectedValue <> 21 And cboDANG_NHAP.SelectedValue <> 28 Then
            btnChonPT.Enabled = True
            grdNhapkhoPTCT.ReadOnly = False
            grdSLtheoViTri.ReadOnly = False
        Else
            btnChonPT.Enabled = False
            grdNhapkhoPTCT.ReadOnly = True
            grdSLtheoViTri.ReadOnly = True
            If cboKHO.SelectedValue Is Nothing Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "KHO_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Critical, Me.Text)
                cboKHO.Focus()
                Exit Sub
            End If
        End If
        grdSLtheoViTri.Columns.Clear()
        grdNhapkhoPTCT.Columns.Clear()
        lstDonHangNhapVatTu.Clear()

        If Me.grdNhapkhoPTCT.RowCount > 0 Then
            hasListVTSL.Clear()
            Me.FormatGridNhapKhoPTCT()
            FormatGridViTriKho()
            Me.SetReadOnlyColumn(False)
            'CallBack_Data(commons.Modules.HasTableVT)
            If cboDANG_NHAP.SelectedValue = 21 Then
                LoadcboDDH()
                cboDDH.Enabled = True
                Try
                    cboDDH.SelectedIndex = 0
                Catch ex As Exception
                End Try
                lstDonHangNhapVatTu.Clear()
                SoLuongViTri()
                If cboDDH.Items.Count > 0 Then cboDDH.SelectedIndex = 0
            ElseIf cboDANG_NHAP.SelectedValue = 28 Then
                LoadcboDXMH()
                cboDDH.Enabled = True
                Try
                    cboDDH.SelectedIndex = 0
                Catch ex As Exception
                End Try
                lstDonHangNhapVatTu.Clear()
                SoLuongViTri_DXMH()
                If cboDDH.Items.Count > 0 Then cboDDH.SelectedIndex = 0
            Else
                cboDDH.SelectedValue = "-1"
                cboDDH.Enabled = False
                For i As Integer = 0 To lstDonHangNhapVatTu.Count - 1
                    Dim tb As New DataTable()
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NULL AS MS_DH_NHAP_PT,MS_PT,MS_VI_TRI," & lstDonHangNhapVatTu.Item(i).SL_THUC_NHAP & " AS SL_VT,NULL AS TEN_VI_TRI FROM IC_PHU_TUNG WHERE MS_PT='" & lstDonHangNhapVatTu.Item(i).MS_PT & "'").Tables(0)
                    Me.hasListVTSL.Add(lstDonHangNhapVatTu.Item(i).MS_PT, tb)
                    lstDonHangNhapVatTu.Item(i).SO_LUONG_CTU = 0
                Next
            End If
            grdNhapkhoPTCT.DataSource = lstDonHangNhapVatTu
            If grdNhapkhoPTCT.Rows.Count > 0 Then
                LoadViTriKho(grdNhapkhoPTCT.Rows(0).Cells("MS_PT").Value)
                intRowCT = 0
            End If
        Else
            If cboDANG_NHAP.SelectedValue = 21 Then
                LoadcboDDH()
                cboDDH.Enabled = True
                'cboNGUOI_NHAP.Enabled = False
                Try
                    cboDDH.SelectedIndex = 0
                Catch ex As Exception
                End Try
                lstDonHangNhapVatTu.Clear()
                SoLuongViTri()
                FormatGridViTriKho()
            ElseIf cboDANG_NHAP.SelectedValue = 28 Then
                LoadcboDXMH()
                cboDDH.Enabled = True
                'cboNGUOI_NHAP.Enabled = False
                Try
                    cboDDH.SelectedIndex = 0
                Catch ex As Exception
                End Try
                lstDonHangNhapVatTu.Clear()
                SoLuongViTri_DXMH()
                FormatGridViTriKho()
            Else
                cboDDH.SelectedValue = "-1"
                cboDDH.Enabled = False
                'cboNGUOI_NHAP.Enabled = True
            End If
        End If
    End Sub

    Private Sub tabNhapkhoPT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabNhapkhoPT.SelectedIndexChanged
        tabNhapkhoPT_IndexChange(tabNhapkhoPT.SelectedIndex)
    End Sub


    Private Sub tabNhapkhoPT_IndexChange(ByVal tabIndex As Integer)
        'If tabNhapkhoPT.SelectedIndex = 1 Then
        Me.Cursor = Cursors.WaitCursor
        Me.grdSLtheoViTri.DataSource = New List(Of IC_DON_HANG_NHAP_VAT_TU_CHI_TIET_Info)
        Me.FormatGridViTriKho()
        Try
            If grdDanhsachNhapkhoPT.CurrentCell.RowIndex >= 0 Then
                Load_Phieu_Nhap(grdDanhsachNhapkhoPT.CurrentCell.RowIndex, True)
                If (grdNhapkhoPTCT.RowCount > 0) Then
                    MS_PT_Current = grdNhapkhoPTCT.CurrentRow.Cells("MS_PT").Value.ToString()
                End If
            End If
        Catch
        End Try
        If grdNhapkhoPTCT.RowCount = 0 Then grdNhapkhoPTCT.Columns.Clear()
        Me.Cursor = Cursors.Default
        'End If
    End Sub

    'Private intDanhsachNhapkhoPT As Integer
    'Private Sub grdDanhsachNhapkhoPT_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdDanhsachNhapkhoPT.UserDeletingRow
    '    If e.Row.Index < intDanhsachNhapkhoPT Then
    '        MsgBox("Đây là dữ liệu cũ, bạn không thể xóa !", MsgBoxStyle.Information, "Thông báo ")
    '        e.Cancel = True
    '    End If
    'End Sub

    'Private intNhapkhoPTCT As Integer
    'Private Sub grdNhapkhoPTCT_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdNhapkhoPTCT.UserDeletingRow
    '    If e.Row.Index < intNhapkhoPTCT Then
    '        MsgBox("Đây là dữ liệu cũ, bạn không thể xóa !", MsgBoxStyle.Information, "Thông báo ")
    '        e.Cancel = True
    '    End If
    'End Sub

    'Private intSLtheoViTri As Integer
    'Private Sub grdSLtheoViTri_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdSLtheoViTri.UserDeletingRow
    '    If e.Row.Index < intSLtheoViTri Then
    '        MsgBox("Đây là dữ liệu cũ, bạn không thể xóa !", MsgBoxStyle.Information, "Thông báo ")
    '        e.Cancel = True
    '    End If
    'End SuB

    Private Sub grdNhapkhoPTCT_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNhapkhoPTCT.DataSourceChanged
        If grdNhapkhoPTCT.RowCount = 0 Then grdSLtheoViTri.DataSource = Nothing
    End Sub

    Private Sub rdbDalock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDalock.CheckedChanged
        Load_Danh_Sach_PN(CreateQuery())
        EnableControl(False)
        SetVisibleButton(True)
        EnableButton()
    End Sub

    Sub EnableButton()
        If rdbDalock.Checked = True Then
            BtnThem.Enabled = False
            btnSua.Enabled = False
            BtnXoa.Enabled = False
            btnLock_PN.Enabled = False

            If grdDanhsachNhapkhoPT.Rows.Count > 0 Then
                BtnIn.Enabled = True
            Else
                BtnIn.Enabled = False
            End If
        Else
            If grdDanhsachNhapkhoPT.Rows.Count > 0 Then
                BtnThem.Enabled = True
                btnSua.Enabled = True
                BtnXoa.Enabled = True
                BtnIn.Enabled = True
                btnLock_PN.Enabled = True
            Else
                BtnThem.Enabled = True
                btnSua.Enabled = False
                BtnXoa.Enabled = False
                BtnIn.Enabled = False
                btnLock_PN.Enabled = False
            End If
        End If
    End Sub




End Class