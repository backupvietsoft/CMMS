Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Common.Data
Imports Commons.QL.Events
Imports System.Data
Imports System.data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Public Class frmChonVatTuTrongKho

    Private bSua As Boolean = False

    Private Sub frmChonVatTuTrongKho_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub frmChonVatTuTrongKho_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        Try
            cboTimvattu.SelectedIndex = 0
        Catch ex As Exception
        End Try
        LoadcboLan()
        LoadcboKho()
        VisibleDieuKien(True)
        txtUsername.Text = Commons.Modules.UserName
        dtThoigianchon.Value = Now()
        BindData()
        VisibleButton(True)
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
        EnableControl(True)
        AddHandler cboLanChon.SelectedValueChanged, AddressOf Me.cboLanChon_SelectedValueChanged
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        Else
            EnableButton(True)
        End If
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub

#Region "private"
    Sub VisibleDieuKien(ByVal chon As Boolean)
        cboLanChon.Visible = chon
        lblLanChon.Visible = chon
        lblThoiGianChon.Visible = chon
        dtThoigianchon.Visible = chon
        lblUsername.Visible = chon
        txtUsername.Visible = chon
    End Sub

    Sub EnableControl(ByVal chon As Boolean)
        'cboLanChon.Enabled = chon
        cboKho.Enabled = Not chon
        cboTimvattu.Enabled = Not chon
        txtGiaTri.Enabled = Not chon
        llblBotatca.Enabled = Not chon
        llblChonAll.Enabled = Not chon
    End Sub

    Sub BindData()
        If Not cboLanChon.SelectedValue Is Nothing Then
            grdDanhsachvattu.Columns.Clear()
            grdDanhsachvattu.DataSource = New clsChonVatTuTrongKhoController().GetPICK_LIST_CHI_TIETs(cboLanChon.SelectedValue)
            grdDanhsachvattu.Columns("MS_KHO").Visible = False
            grdDanhsachvattu.Columns("MS_VI_TRI").Visible = False
            Try
                Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try
            FormatDataGrid()
            BtnSua.Enabled = True
            BtnXoa.Enabled = True
            BtnIn.Enabled = True
        Else
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
            BtnIn.Enabled = False
        End If
    End Sub

    Sub LoadcboLan()
        cboLanChon.Display = "PICK_NO"
        cboLanChon.Value = "PICK_NO"
        cboLanChon.StoreName = "GetPICK_LISTs"
        cboLanChon.Param = Commons.Modules.UserName
        cboLanChon.BindDataSource()
    End Sub

    Sub LoadcboKho()
        cboKho.Display = "TEN_KHO"
        cboKho.Value = "MS_KHO"
        cboKho.StoreName = "GetPICK_LIST_KHO"
        cboKho.Param = Commons.Modules.UserName
        cboKho.BindDataSource()
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Sub VisibleButton(ByVal chon As Boolean)
        BtnThem.Visible = chon
        BtnXoa.Visible = chon
        BtnSua.Visible = chon
        BtnIn.Visible = chon
        BtnThoat.Visible = chon
    End Sub

    Sub VisibleButtonGhi(ByVal chon As Boolean)
        BtnGhi.Visible = chon
        BtnKhongghi.Visible = chon
    End Sub

    Sub VisibleButtonXoa(ByVal chon As Boolean)
        BtnXoaAll.Visible = chon
        BtnXoa1Dong.Visible = chon
        BtnTrove.Visible = chon
    End Sub

    Sub LoadData()
        grdDanhsachvattu.Columns.Clear()
        If cboKho.SelectedValue = "-1" Then
            grdDanhsachvattu.DataSource = New clsChonVatTuTrongKhoController().GetPICK_LIST_CHI_TIET_KHO(0, Commons.Modules.UserName)
        Else
            grdDanhsachvattu.DataSource = New clsChonVatTuTrongKhoController().GetPICK_LIST_CHI_TIET_KHO(cboKho.SelectedValue, Commons.Modules.UserName)
        End If
        Try
            Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        grdDanhsachvattu.Columns("MS_KHO").Visible = False
        grdDanhsachvattu.Columns("MS_VI_TRI").Visible = False
        Dim chkGiatri As New DataGridViewCheckBoxColumn()
        chkGiatri.Name = "CHON"
        grdDanhsachvattu.Columns.Insert(9, chkGiatri)
        FormatDataGrid()
        If bThem > 0 Then
            Dim str As String = ""
            Dim tb As New DataTable()
            str = "SELECT DISTINCT MS_KHO,MS_VI_TRI,MS_DH_NHAP_PT,MS_PT  FROM CHON_VAT_TU_TMP" & Commons.Modules.UserName
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            For i As Integer = 0 To tb.Rows.Count - 1
                For j As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
                    If grdDanhsachvattu.Rows(j).Cells("MS_KHO").Value = tb.Rows(i).Item("MS_KHO") And grdDanhsachvattu.Rows(j).Cells("MS_VI_TRI").Value = tb.Rows(i).Item("MS_VI_TRI") And grdDanhsachvattu.Rows(j).Cells("MS_DH_NHAP_PT").Value = tb.Rows(i).Item("MS_DH_NHAP_PT") And grdDanhsachvattu.Rows(j).Cells("MS_PT").Value = tb.Rows(i).Item("MS_PT") Then
                        grdDanhsachvattu.Rows(j).Cells("CHON").Value = True
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub

    Sub LoadData1()
        grdDanhsachvattu.Columns.Clear()
        If cboKho.SelectedValue = "-1" Then
            grdDanhsachvattu.DataSource = New clsChonVatTuTrongKhoController().GetPICK_LIST_CHI_TIET_KHO_CHI_TIET(0, Commons.Modules.UserName, cboTimvattu.SelectedIndex, txtGiaTri.Text)
        Else
            grdDanhsachvattu.DataSource = New clsChonVatTuTrongKhoController().GetPICK_LIST_CHI_TIET_KHO_CHI_TIET(cboKho.SelectedValue, Commons.Modules.UserName, cboTimvattu.SelectedIndex, txtGiaTri.Text)
        End If
        Try
            Me.grdDanhsachvattu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachvattu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        grdDanhsachvattu.Columns("MS_KHO").Visible = False
        grdDanhsachvattu.Columns("MS_VI_TRI").Visible = False
        Dim chkGiatri As New DataGridViewCheckBoxColumn()
        chkGiatri.Name = "CHON"
        grdDanhsachvattu.Columns.Insert(9, chkGiatri)
        FormatDataGrid()
        If bThem > 0 Then
            Dim str As String = ""
            Dim tb As New DataTable()
            str = "SELECT DISTINCT MS_KHO,MS_VI_TRI,MS_DH_NHAP_PT,MS_PT  FROM CHON_VAT_TU_TMP" & Commons.Modules.UserName
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
            For i As Integer = 0 To tb.Rows.Count - 1
                For j As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
                    If grdDanhsachvattu.Rows(j).Cells("MS_KHO").Value = tb.Rows(i).Item("MS_KHO") And grdDanhsachvattu.Rows(j).Cells("MS_VI_TRI").Value = tb.Rows(i).Item("MS_VI_TRI") And grdDanhsachvattu.Rows(j).Cells("MS_DH_NHAP_PT").Value = tb.Rows(i).Item("MS_DH_NHAP_PT") And grdDanhsachvattu.Rows(j).Cells("MS_PT").Value = tb.Rows(i).Item("MS_PT") Then
                        grdDanhsachvattu.Rows(j).Cells("CHON").Value = True
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub

    Sub FormatDataGrid()
        With grdDanhsachvattu
            .Columns("MS_PT").Width = 100
            .Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT", commons.Modules.TypeLanguage)
            .Columns("TEN_PT").Width = 200
            .Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_PT", commons.Modules.TypeLanguage)
            .Columns("TEN_KHO").Width = 100
            .Columns("TEN_KHO").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_KHO", commons.Modules.TypeLanguage)
            .Columns("MS_DH_NHAP_PT").Width = 100
            .Columns("MS_DH_NHAP_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", commons.Modules.TypeLanguage)
            .Columns("TEN_VI_TRI").Width = 150
            .Columns("TEN_VI_TRI").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TEN_VI_TRI", commons.Modules.TypeLanguage)
            .Columns("NGAY").Width = 80
            .Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGAY", commons.Modules.TypeLanguage)
            .Columns("NGAY").DefaultCellStyle.Format = "dd/MM/yyyy"
            Try
                .Columns("CHON").Width = 60
                .Columns("CHON").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHON", commons.Modules.TypeLanguage)
            Catch ex As Exception

            End Try
            .Columns("SL_VT").Width = 100
            .Columns("SL_VT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SL_VT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "SL_VT", commons.Modules.TypeLanguage)
            .Columns("MS_PT_NCC").Width = 200
            .Columns("MS_PT_NCC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT_NCC", commons.Modules.TypeLanguage)
            .Columns("MS_PT_CTY").Width = 200
            .Columns("MS_PT_CTY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MS_PT_CTY", commons.Modules.TypeLanguage)
        End With
    End Sub
#End Region
#Region "event"

    Private Sub BtnThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        AddHandler cboKho.SelectionChangeCommitted, AddressOf Me.cboKho_SelectionChangeCommitted
        EnableControl(False)
        VisibleDieuKien(False)
        bThem = 1
        Dim str As String = ""
        Try
            str = "drop table CHON_VAT_TU_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "CREATE TABLE DBO.CHON_VAT_TU_TMP" & Commons.Modules.UserName & "( MS_KHO INT,MS_VI_TRI INT,MS_DH_NHAP_PT NVARCHAR(30),MS_PT NVARCHAR(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        LoadData()
        VisibleButton(False)
        VisibleButtonGhi(True)
        VisibleButtonXoa(False)
        AddHandler grdDanhsachvattu.CellBeginEdit, AddressOf Me.grdDanhsachvattu_CellBeginEdit
        AddHandler grdDanhsachvattu.CellEndEdit, AddressOf Me.grdDanhsachvattu_CellEndEdit
    End Sub

    Private Sub cboKho_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles cboKho.SelectionChangeCommitted
        LoadData()
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim str As String = ""
        Dim tb As New DataTable()
        Dim objChonVatTu As New clsChonVatTuTrongKhoController()
        Dim tmp As Integer = 0
        If bThem = 1 Then
            objChonVatTu.AddPICK_LIST(dtThoigianchon.Value, txtUsername.Text)
            tmp = objChonVatTu.GetPICK_NO()
        Else
            tmp = cboLanChon.SelectedValue
            str = "DELETE FROM PICK_LIST_CHI_TIET WHERE PICK_NO=" & tmp
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        End If
        str = "SELECT DISTINCT MS_KHO,MS_VI_TRI,MS_DH_NHAP_PT,MS_PT FROM CHON_VAT_TU_TMP" & Commons.Modules.UserName
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables(0)
        For i As Integer = 0 To tb.Rows.Count - 1
            objChonVatTu.AddPICK_LIST_CHI_TIET(tmp, tb.Rows(i).Item("MS_KHO"), tb.Rows(i).Item("MS_VI_TRI"), tb.Rows(i).Item("MS_DH_NHAP_PT"), tb.Rows(i).Item("MS_PT"))
        Next
        bThem = 0
        LoadcboLan()
        VisibleButton(True)
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
        EnableControl(True)
        VisibleDieuKien(True)
        txtGiaTri.Text = ""
        Try
            str = "drop table CHON_VAT_TU_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        RemoveHandler cboKho.SelectionChangeCommitted, AddressOf Me.cboKho_SelectionChangeCommitted
        RemoveHandler grdDanhsachvattu.CellBeginEdit, AddressOf Me.grdDanhsachvattu_CellBeginEdit
        RemoveHandler grdDanhsachvattu.CellEndEdit, AddressOf Me.grdDanhsachvattu_CellEndEdit
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        VisibleButton(True)
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
        LoadcboLan()
        bThem = 0
        EnableControl(True)
        VisibleDieuKien(True)
        Dim str As String = ""
        Try
            str = "drop table CHON_VAT_TU_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        txtGiaTri.Text = ""
        RemoveHandler cboKho.SelectionChangeCommitted, AddressOf Me.cboKho_SelectionChangeCommitted
        RemoveHandler grdDanhsachvattu.CellBeginEdit, AddressOf Me.grdDanhsachvattu_CellBeginEdit
        RemoveHandler grdDanhsachvattu.CellEndEdit, AddressOf Me.grdDanhsachvattu_CellEndEdit
    End Sub

    Private Sub txtGiaTri_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGiaTri.KeyDown
        If e.KeyValue = 13 Then
            LoadData1()
        End If
    End Sub
    Dim bCo As Boolean = False
    Private Sub cboLanChon_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboLanChon.SelectedValueChanged
        If cboLanChon.SelectedValue Is Nothing Then
            Exit Sub
        End If
        Dim str As String = ""
        str = "SELECT THOI_GIAN FROM PICK_LIST WHERE PICK_NO=" & cboLanChon.SelectedValue
        Dim objReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
        While objReader.Read
            dtThoigianchon.Value = objReader.Item("THOI_GIAN")
        End While
        objReader.Close()
        BindData()
    End Sub

    Dim bThem As Byte = 0

    Private Sub BtnSua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        AddHandler cboKho.SelectionChangeCommitted, AddressOf Me.cboKho_SelectionChangeCommitted
        EnableControl(False)
        VisibleDieuKien(False)
        bThem = 2
        Dim str As String = ""
        Try
            str = "drop table CHON_VAT_TU_TMP" & Commons.Modules.UserName
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception

        End Try
        str = "SELECT DISTINCT MS_KHO,MS_VI_TRI,MS_DH_NHAP_PT,MS_PT INTO DBO.CHON_VAT_TU_TMP" & Commons.Modules.UserName & " FROM PICK_LIST_CHI_TIET WHERE PICK_NO=" & cboLanChon.SelectedValue
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        LoadData()
        VisibleButton(False)
        VisibleButtonGhi(True)
        VisibleButtonXoa(False)
        AddHandler grdDanhsachvattu.CellBeginEdit, AddressOf Me.grdDanhsachvattu_CellBeginEdit
        AddHandler grdDanhsachvattu.CellEndEdit, AddressOf Me.grdDanhsachvattu_CellEndEdit
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        VisibleButton(False)
        VisibleButtonGhi(False)
        VisibleButtonXoa(True)
    End Sub

    Private Sub BtnXoaAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoaAll.Click
        If cboLanChon.SelectedValue Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNulldata", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoaAll", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim objChonVatTu As New clsChonVatTuTrongKhoController()
            objChonVatTu.DeletePICK_LIST(cboLanChon.SelectedValue)
            grdDanhsachvattu.Columns.Clear()
            cboLanChon.ResetText()
            LoadcboLan()
        End If
    End Sub


    Private Sub BtnXoa1Dong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnXoa1Dong.Click

        If grdDanhsachvattu.Rows.Count = 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNulldata", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgXoaDong", commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim objChonVatTu As New clsChonVatTuTrongKhoController()
            objChonVatTu.DeletePICK_LIST_CHI_TIET(cboLanChon.SelectedValue, grdDanhsachvattu.Rows(intRow).Cells("MS_KHO").Value, grdDanhsachvattu.Rows(intRow).Cells("MS_VI_TRI").Value, grdDanhsachvattu.Rows(intRow).Cells("MS_DH_NHAP_PT").Value, grdDanhsachvattu.Rows(intRow).Cells("MS_PT").Value)
            If grdDanhsachvattu.Rows.Count = 1 Then
                LoadcboLan()
            Else
                BindData()
            End If
        End If
    End Sub

    Dim intRow As Integer = 0

    Private Sub grdDanhsachvattu_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachvattu.RowEnter
        intRow = e.RowIndex

    End Sub

    Private Sub BtnTrove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTrove.Click
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
        VisibleButton(True)
    End Sub

    Private Sub llblBotatca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblBotatca.LinkClicked
        Dim str As String = ""
        str = "DELETE FROM CHON_VAT_TU_TMP" & Commons.Modules.UserName
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        LoadData()
    End Sub

    Private Sub llblChonAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblChonAll.LinkClicked
        Dim str As String = ""
        str = "DELETE FROM CHON_VAT_TU_TMP" & Commons.Modules.UserName
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        For i As Integer = 0 To grdDanhsachvattu.Rows.Count - 1
            str = "INSERT INTO CHON_VAT_TU_TMP" & Commons.Modules.UserName & " VALUES(" & grdDanhsachvattu.Rows(i).Cells("MS_KHO").Value & "," & grdDanhsachvattu.Rows(i).Cells("MS_VI_TRI").Value & ",'" & grdDanhsachvattu.Rows(i).Cells("MS_DH_NHAP_PT").Value & "','" & grdDanhsachvattu.Rows(i).Cells("MS_PT").Value & "')"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Next
        LoadData()
    End Sub

    Private Sub BtnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIn.Click
        If grdDanhsachvattu.Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            CreateTitleReport()
            Commons.clsXuLy.CreateTitleReport()
            Dim str As String = ""
            Try
                str = "drop table rptPICK_LIST_CHI_TIET"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            Catch ex As Exception
            End Try
            str = "SELECT DISTINCT  PICK_LIST_CHI_TIET.MS_PT, IC_PHU_TUNG.TEN_PT, IC_PHU_TUNG.MS_PT_NCC, " & _
                  " IC_PHU_TUNG.MS_PT_CTY, PICK_LIST_CHI_TIET.MS_KHO, IC_KHO.TEN_KHO, PICK_LIST_CHI_TIET.MS_DH_NHAP_PT, " & _
                  " PICK_LIST_CHI_TIET.MS_VI_TRI, (select TEN_VI_TRI FROM VI_TRI_KHO WHERE VI_TRI_KHO.MS_KHO=PICK_LIST_CHI_TIET.MS_KHO AND PICK_LIST_CHI_TIET.MS_VI_TRI=VI_TRI_KHO.MS_VI_TRI)AS TEN_VI_TRI " & _
                  " INTO DBO.rptPICK_LIST_CHI_TIET " & _
                  " FROM PICK_LIST_CHI_TIET INNER JOIN IC_DON_HANG_NHAP ON  " & _
                  " IC_DON_HANG_NHAP.MS_DH_NHAP_PT = PICK_LIST_CHI_TIET.MS_DH_NHAP_PT INNER JOIN " & _
                  " IC_KHO ON PICK_LIST_CHI_TIET.MS_KHO = IC_KHO.MS_KHO  INNER JOIN  " & _
                  " IC_PHU_TUNG ON PICK_LIST_CHI_TIET.MS_PT = IC_PHU_TUNG.MS_PT  " & _
                  " WHERE PICK_LIST_CHI_TIET.PICK_NO =" & cboLanChon.SelectedValue & " order by PICK_LIST_CHI_TIET.MS_PT"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)

            Commons.mdShowReport.ReportPreview("reports/rptPICK_LIST_CHI_TIET.rpt")
            Me.Cursor = Cursors.Default
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNulldataIn", commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
        End If

    End Sub
    Sub CreateTitleReport()
        Dim str As String = ""
        Try
            str = " DROP TABLE rptTIEU_DE_PICK_LIST_CHI_TIET"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_PICK_LIST_CHI_TIET (TypeLanguage int,TieuDe nvarchar(255),NgayIn nvarchar(20),TrangIn nvarchar(20),MaKho nvarchar(20),TenKho nvarchar(50),sSTT nvarchar(5),MaPT nvarchar(50),TenPT nvarchar(50)," & _
            " PartNo nvarchar(20),ItemCode nvarchar(20),DHNhap nvarchar(30),ViTri nvarchar(30),SoLuong nvarchar(30))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "TieuDe", commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "Ngayin", commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "Trangin", commons.Modules.TypeLanguage)
        Dim MaKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "MaKho", commons.Modules.TypeLanguage)
        Dim TenKho As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "TenKho", commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "STT", commons.Modules.TypeLanguage)
        Dim MaPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "MaPT", commons.Modules.TypeLanguage)
        Dim TenPT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "TenPT", commons.Modules.TypeLanguage)
        Dim PartNo As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "PartNo", commons.Modules.TypeLanguage)
        Dim ItemCode As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "ItemCode", commons.Modules.TypeLanguage)
        Dim DHNhap As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "DHNhap", commons.Modules.TypeLanguage)
        Dim ViTri As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "ViTri", commons.Modules.TypeLanguage)
        Dim SoLuong As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptPICK_LIST_CHI_TIET", "SoLuong", commons.Modules.TypeLanguage)
        str = "INSERT INTO rptTIEU_DE_PICK_LIST_CHI_TIET(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,MaKho,TenKho,sSTT,MaPT,TenPT,PartNo,ItemCode,DHNhap,ViTri,SoLuong) values (" & _
        commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & MaKho & "',N'" & TenKho & _
        "',N'" & sSTT & "',N'" & MaPT & "',N'" & TenPT & "',N'" & PartNo & "',N'" & ItemCode & "',N'" & DHNhap & "',N'" & ViTri & "',N'" & SoLuong & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub CreaterptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI()
        Dim str As String = ""
        Try
            str = " DROP TABLE rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        str = "CREATE TABLE DBO.rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI(TypeLanguage int, TrangIn nvarchar(20),NgayIn nvarchar(20),TieuDe nvarchar(255)," & _
            "sSTT nvarchar(5),ThietBi nvarchar(30),BoPhan nvarchar(50),ThongSo nvarchar(50),ChuKy nvarchar(50),NgayCuoi nvarchar(30),GiaTri nvarchar(50))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Dim TieuDe As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TieuDeP", commons.Modules.TypeLanguage)
        Dim NgayIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "Ngayin", commons.Modules.TypeLanguage)
        Dim TrangIn As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "Trangin", commons.Modules.TypeLanguage)
        Dim sSTT As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "STT", commons.Modules.TypeLanguage)
        Dim ThietBi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "ThietBi", commons.Modules.TypeLanguage)
        Dim BoPhan As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "BoPhan", commons.Modules.TypeLanguage)
        Dim ThongSo As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "ThongSo", commons.Modules.TypeLanguage)
        Dim ChuKy As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "ChuKy", commons.Modules.TypeLanguage)
        Dim NgayCuoi As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NgayCuoi", commons.Modules.TypeLanguage)
        Dim GiaTri As String = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GiaTri", commons.Modules.TypeLanguage)
        str = "INSERT INTO rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI(commons.Modules.TypeLanguage,TieuDe,NgayIn,TrangIn,sSTT,ThietBi,BoPhan,ThongSo,ChuKy,NgayCuoi,GiaTri) values (" & _
        commons.Modules.TypeLanguage & ",N'" & TieuDe & "',N'" & NgayIn & "',N'" & TrangIn & "',N'" & sSTT & "',N'" & ThietBi & "',N'" & BoPhan & _
        "',N'" & ThongSo & "',N'" & ChuKy & "',N'" & NgayCuoi & "',N'" & GiaTri & "')"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
    End Sub
    Sub ShowrptQUI_DINH_VE_GSTT_THIET_BI()
        Dim str As String = ""
        Try
            str = "DROP TABLE rptQUI_DINH_VE_GSTT_THIET_BI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
        CreaterptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI()
        str = "CREATE TABLE DBO.rptQUI_DINH_VE_GSTT_THIET_BI(MS_MAY NVARCHAR(30),TEN_BO_PHAN NVARCHAR(100),TEN_TS_GSTT NVARCHAR(100),CHU_KY_DO NVARCHAR(50),NGAY DATETIME,GIA_TRI NVARCHAR(255))"
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetrptQUI_DINH_VE_GSTT_THIET_BI", "", commons.Modules.TypeLanguage)
        Commons.mdShowReport.ReportPreview("reports/rptQUI_DINH_VE_GSTT_THIET_BI.rpt")
        Try
            str = "DROP TABLE rptQUI_DINH_VE_GSTT_THIET_BI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            str = " DROP TABLE rptTIEU_DE_QUI_DINH_VE_GSTT_THIET_BI"
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cboTimvattu_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTimvattu.SelectionChangeCommitted
        txtGiaTri.Text = ""
        txtGiaTri.Focus()
    End Sub


    Private Sub grdDanhsachvattu_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If grdDanhsachvattu.Rows(e.RowIndex).Cells("CHON").Value Then
            bCo = True
        Else
            bCo = False
        End If
    End Sub

    Private Sub grdDanhsachvattu_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim str As String = ""
        If grdDanhsachvattu.Rows(e.RowIndex).Cells("CHON").Value Then
            If Not bCo Then
                str = "INSERT INTO CHON_VAT_TU_TMP" & Commons.Modules.UserName & " VALUES(" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_KHO").Value & "," & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_VI_TRI").Value & ",N'" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_DH_NHAP_PT").Value & "',N'" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value & "')"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        Else
            If bCo Then
                str = "DELETE FROM CHON_VAT_TU_TMP" & Commons.Modules.UserName & " WHERE MS_KHO=" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_KHO").Value & _
                " AND MS_VI_TRI=" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_VI_TRI").Value & " AND MS_DH_NHAP_PT='" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_DH_NHAP_PT").Value & _
                "' AND MS_PT='" & grdDanhsachvattu.Rows(e.RowIndex).Cells("MS_PT").Value & "'"
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str)
            End If
        End If
    End Sub

    Private Sub grdDanhsachvattu_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grdDanhsachvattu.UserDeletingRow

    End Sub

#End Region
    
End Class