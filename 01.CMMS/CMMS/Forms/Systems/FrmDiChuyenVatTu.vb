Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Windows.Forms
Imports Commons.VS.Classes.Catalogue
Imports Commons.QL.Events
Imports Commons.QL.Common.Data
Imports Commons.VS.Classes.Admin
Imports System.Linq
Imports DevExpress.XtraEditors

Public Class FrmDiChuyenVatTu
    Private objDiChuyenVatTuController As New DI_CHUYEN_KHO_VAT_TU_Controller
    'Private lstSourceVatTu As New List(Of DiChuyenVatTu)
    Private lstDestinationVatTu As New List(Of DiChuyenVatTu)
    Private actionButton As Boolean = False
    Dim dtSourceVatTu As New DataTable()

    Private Sub FrmDiChuyenVatTu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LOAD_FORM()
        btnMove.Enabled = False
        btnMoveAl.Enabled = False
        BtnRemove.Enabled = False
        BtnRemoveAl.Enabled = False
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
    End Sub

    Dim tb As New DataTable()

    Sub CreateTable()
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, "Select MS_DH_NHAP_PT,MS_PT, SL_VT, 0.00 AS SL_DC, 0.00 AS ID_DC FROM VI_TRI_KHO_VAT_TU WHERE MS_KHO=0 AND  MS_VI_TRI=0").Tables(0)
    End Sub

    Public Sub LOAD_FORM()
        Me.cboNgayGio.BindDataSource()

        Commons.Modules.ObjSystems.DinhDang()
        Me.cboFromStock.Param = Commons.Modules.UserName
        Me.cboFromStock.BindDataSource()
        Me.cboToStock.Param = Commons.Modules.UserName
        Me.cboToStock.BindDataSource()
        AddHandler cboFromPosition.SelectedIndexChanged, AddressOf cboFromPosition_SelectedIndexChanged
        Load_Vi_Tri_From_Stock()
        Load_Vi_Tri_To_Stock()
        VisibleButton(False)
        VisibleButtonGhi(False)
        SetEnableButton(False)
        CreateTable()
        Me.txtgio.Text = Format(Date.Now, "long time")
        AddHandler cboFromStock.SelectedIndexChanged, AddressOf cboFromStock_SelectedIndexChanged
        AddHandler cboToStock.SelectedIndexChanged, AddressOf cboToStock_SelectedIndexChanged
        Show()
        Check_User_Form()

    End Sub

    Function Check_User_Form() As Boolean
        Dim authorized As String
        authorized = ""
        authorized = Me.objDiChuyenVatTuController.Load_Authorized_User_Form(Name)
        Select Case authorized
            Case "Full access"
                EnableButton(True)
                actionButton = True
                Exit Select
            Case "Read only"
                EnableButton(False)
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

    Sub EnableButton(ByVal bln As Boolean)
        'btnMoveEd.Enabled = bln
        btnMove.Enabled = bln
        btnMoveAl.Enabled = bln
        btnStart.Enabled = bln
        btnLanDiChuyenMoi.Enabled = bln
    End Sub

    Sub Load_Vi_Tri_From_Stock()
        If Me.cboFromStock.SelectedValue IsNot Nothing Then
            RemoveHandler cboFromPosition.SelectedIndexChanged, AddressOf cboFromPosition_SelectedIndexChanged
            Me.cboFromPosition.Param = Me.cboFromStock.SelectedValue.ToString
            Me.cboFromPosition.BindDataSource()
            Load_Vat_Tu_Kho_Vi_Tri()
            AddHandler cboFromPosition.SelectedIndexChanged, AddressOf cboFromPosition_SelectedIndexChanged
        End If
    End Sub

    Sub Load_Vi_Tri_To_Stock()
        If Me.cboToStock.SelectedValue IsNot Nothing Then
            Me.cboToPosition.Param = Me.cboToStock.SelectedValue.ToString
            Me.cboToPosition.BindDataSource()
        End If
    End Sub


    Sub Load_Vat_Tu_Kho_Vi_Tri()
        Dim MS_KHO As Integer = 0
        Dim MS_VI_TRI As Integer = 0
        If Me.cboFromStock.SelectedValue IsNot Nothing Then
            MS_KHO = Integer.Parse(cboFromStock.SelectedValue.ToString)
        End If
        If Me.cboFromPosition.SelectedValue IsNot Nothing Then
            MS_VI_TRI = Integer.Parse(cboFromPosition.SelectedValue.ToString)
        End If
        dtSourceVatTu = New DataTable()
        dtSourceVatTu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                    "QL_LOAD_VAT_TU_KHO_VI_TRI_NEW", MS_KHO, MS_VI_TRI))
        FormatGridFromStock()
    End Sub

    Sub Load_DC(ByVal Ngay As String, ByVal Gio As String)
        Dim MS_KHO As Integer = 0
        Dim MS_VI_TRI As Integer = 0

        Dim MS_KHO1 As Integer = 0
        Dim MS_VI_TRI1 As Integer = 0

        'Dim Ngay As String = ""
        'Dim Gio As String = ""
        Try
            If Me.cboFromStock.SelectedValue IsNot Nothing Then
                MS_KHO = Integer.Parse(cboFromStock.SelectedValue.ToString)
            End If
        Catch ex As Exception

        End Try

        Try
            If Me.cboFromPosition.SelectedValue IsNot Nothing Then
                MS_VI_TRI = Integer.Parse(cboFromPosition.SelectedValue.ToString)
            End If
        Catch ex As Exception
        End Try

        Try
            If Me.cboToStock.SelectedValue IsNot Nothing Then
                MS_KHO1 = Integer.Parse(cboToStock.SelectedValue.ToString)
            End If
        Catch ex As Exception
        End Try


        Try
            If Me.cboToPosition.SelectedValue IsNot Nothing Then
                MS_VI_TRI1 = Integer.Parse(cboToPosition.SelectedValue.ToString)
            End If
        Catch ex As Exception
        End Try
        tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString,
                    "MashjLoadDiChuyen", MS_KHO, MS_VI_TRI, MS_KHO1, MS_VI_TRI1, Ngay, Gio).Tables(0)

        Me.FormatGridToStock()
    End Sub

    Sub FormatGridFromStock()


        dtSourceVatTu.Columns("SL_DC").ReadOnly = False

        Dim dv As DataView = dtSourceVatTu.DefaultView
        dv.Sort = "MS_PT ASC"
        dtSourceVatTu = dv.ToTable()

        grdFromVatTu.ReadOnly = True
        grdFromVatTu.DataSource = dtSourceVatTu ' lstSourceVatTu.OrderBy(Function(t) t.MS_PT).ToList()

        grdFromVatTu.Columns("MS_PT").DataPropertyName = "MS_PT"
        grdFromVatTu.Columns("MS_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)

        grdFromVatTu.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        grdFromVatTu.Columns("TEN_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_PT", Commons.Modules.TypeLanguage)
        grdFromVatTu.Columns("TEN_PT").Width = 200

        grdFromVatTu.Columns("QUY_CACH").DataPropertyName = "QUY_CACH"
        grdFromVatTu.Columns("QUY_CACH").Width = 250
        grdFromVatTu.Columns("QUY_CACH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "QUY_CACH", Commons.Modules.TypeLanguage)

        grdFromVatTu.Columns("MS_DH_NHAP_PT").DataPropertyName = "MS_DH_NHAP_PT"
        grdFromVatTu.Columns("MS_DH_NHAP_PT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)

        grdFromVatTu.Columns("ID_DC").DataPropertyName = "ID_DC"
        grdFromVatTu.Columns("ID_DC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ID_DC", Commons.Modules.TypeLanguage)
        grdFromVatTu.Columns("ID_DC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFromVatTu.Columns("ID_DC").Visible = False

        grdFromVatTu.Columns("SL_DC").DataPropertyName = "SL_DC"
        grdFromVatTu.Columns("SL_DC").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_DC", Commons.Modules.TypeLanguage)
        grdFromVatTu.Columns("SL_DC").Visible = False

        grdFromVatTu.Columns("MS_PT_NCC").Visible = False
        grdFromVatTu.Columns("MS_PT_CTY").Visible = False

        grdFromVatTu.Columns("SL_VT").DataPropertyName = "SL_VT"
        grdFromVatTu.Columns("SL_VT").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_VT", Commons.Modules.TypeLanguage)
        grdFromVatTu.Columns("SL_VT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFromVatTu.Columns("SL_VT").DisplayIndex = 2


        Try
            Me.grdFromVatTu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdFromVatTu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
        'grdFromVatTu.Columns("ID_DC").Visible = False
        'grdFromVatTu.Columns("@ID_DC@").Visible = False

    End Sub

    Sub FormatGridToStock()
        grdToVatTu.Columns.Clear()
        Dim column As New DataGridViewTextBoxColumn
        column.Name = "MS_PT"
        column.DataPropertyName = "MS_PT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_PT", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        grdToVatTu.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "MS_DH_NHAP_PT"
        column.DataPropertyName = "MS_DH_NHAP_PT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage)
        column.ReadOnly = True
        grdToVatTu.Columns.Add(column)
        column = New DataGridViewTextBoxColumn
        column.Name = "SL_DC"
        column.DataPropertyName = "SL_DC"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_DC", Commons.Modules.TypeLanguage)
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdToVatTu.Columns.Add(column)




        column = New DataGridViewTextBoxColumn
        column.Name = "SL_VT"
        column.DataPropertyName = "SL_VT"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SL_VT", Commons.Modules.TypeLanguage)
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdToVatTu.Columns.Add(column)

        column = New DataGridViewTextBoxColumn
        column.Name = "ID_DC"
        column.DataPropertyName = "ID_DC"
        column.HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ID_DC", Commons.Modules.TypeLanguage)
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdToVatTu.Columns.Add(column)



        grdToVatTu.DataSource = tb ' lstDestiNationVatTu
        'grdToVatTu.Columns("SL_VT").Visible = False
        grdToVatTu.Columns("ID_DC").Visible = False

        grdToVatTu.Columns("SL_VT").DisplayIndex = 2

        Try
            Me.grdToVatTu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdToVatTu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try
    End Sub
    Sub VisibleButton(ByVal Flag As Boolean)
        'Me.btnStart.Visible = Flag
        ''Me.btnExit.Visible = Flag  
        'Me.btnLanDiChuyenMoi.Visible = Not Flag

    End Sub
    Sub VisibleButtonGhi(ByVal Flag As Boolean)
        Me.btnGhi.Visible = Flag
        Me.btnKhongGhi.Visible = Flag
        Me.btnStart.Visible = Not Flag
        Me.btnExit.Visible = Not Flag
        btnIn.Visible = Not Flag
    End Sub
    Sub SetEnableButton(ByVal Flag As Boolean)
        Me.btnGhi.Enabled = Flag
        Me.btnKhongGhi.Enabled = Flag
        Me.btnMove.Enabled = Flag
        Me.btnMoveAl.Enabled = Flag
        'Me.btnMoveEd.Enabled = Flag
        Me.btnStart.Enabled = Not Flag
        Me.cboFromStock.Enabled = Not Flag
        Me.cboFromPosition.Enabled = Not Flag
        Me.cboToStock.Enabled = Not Flag
        Me.cboToPosition.Enabled = Not Flag
        'Me.btnExit.Enabled = Not Flag
        Me.BtnRemove.Enabled = Flag
        Me.BtnRemoveAl.Enabled = Flag
        Me.dtpGio.Enabled = Not Flag
        Me.dtpNgay.Enabled = Not Flag
        cboNgayGio.Enabled = Not Flag
    End Sub

#Region "Event Handle Controls"

    'Private Sub btnMoveEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If grdFromVatTu.RowCount < 1 Then
    '        Return
    '    Else
    '        Dim objSourceDCVT As New DiChuyenVatTu
    '        objSourceDCVT.MS_DH_NHAP_PT = dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("MS_DH_NHAP_PT").ToString
    '        objSourceDCVT.MS_PT = dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("MS_PT").ToString
    '        objSourceDCVT.SL_VT = dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("SL_VT").ToString
    '        objSourceDCVT.ID_DC = dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("ID_DC").ToString

    '        For i As Integer = 0 To tb.Rows.Count - 1
    '            If objSourceDCVT.ID_DC = tb.Rows(i).Item("ID_DC") And objSourceDCVT.MS_PT = tb.Rows(i).Item("MS_PT") And objSourceDCVT.MS_DH_NHAP_PT = tb.Rows(i).Item("MS_DH_NHAP_PT") Then
    '                Return
    '            End If
    '        Next
    '        Dim dr As DataRow
    '        dr = tb.NewRow
    '        dr.Item("MS_DH_NHAP_PT") = objSourceDCVT.MS_DH_NHAP_PT
    '        dr.Item("MS_PT") = objSourceDCVT.MS_PT
    '        dr.Item("SL_VT") = objSourceDCVT.SL_VT
    '        dr.Item("ID_DC") = objSourceDCVT.ID_DC
    '        If objSourceDCVT.SL_DC Is Nothing Then
    '            dr.Item("SL_DC") = System.DBNull.Value
    '        Else
    '            dr.Item("SL_DC") = objSourceDCVT.SL_DC
    '        End If


    '        tb.Rows.Add(dr)
    '        Me.FormatGridToStock()
    '    End If

    'End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        If grdFromVatTu.RowCount < 1 Then
            Return
        Else
            Dim objSourceDCVT As DataRow = dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)
            Dim Flag As Boolean = True
            For i As Integer = 0 To tb.Rows.Count - 1
                If objSourceDCVT("ID_DC") = tb.Rows(i).Item("ID_DC") And objSourceDCVT("MS_PT") = tb.Rows(i).Item("MS_PT") And objSourceDCVT("MS_DH_NHAP_PT") = tb.Rows(i).Item("MS_DH_NHAP_PT") Then
                    If tb.Rows(i).Item("SL_DC").ToString = "" Then
                        tb.Rows(i).Item("SL_DC") = objSourceDCVT("SL_VT")
                    Else
                        tb.Rows(i).Item("SL_DC") = tb.Rows(i).Item("SL_DC") + objSourceDCVT("SL_VT")

                    End If
                    tb.Rows(i).Item("SL_VT") = 0
                    dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("SL_DC") = tb.Rows(i).Item("SL_DC")
                    dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("SL_VT") = 0
                    Flag = False
                End If
            Next
            If Flag Then
                Dim dr As DataRow
                dr = tb.NewRow
                dr.Item("MS_DH_NHAP_PT") = objSourceDCVT("MS_DH_NHAP_PT")
                dr.Item("MS_PT") = objSourceDCVT("MS_PT")
                dr.Item("SL_VT") = 0
                dr.Item("SL_DC") = objSourceDCVT("SL_VT")
                dr.Item("ID_DC") = objSourceDCVT("ID_DC")
                tb.Rows.Add(dr)
                dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("SL_DC") = objSourceDCVT("SL_VT")
                dtSourceVatTu.Rows(Me.grdFromVatTu.CurrentRow.Index)("SL_VT") = 0
            End If

            Me.FormatGridToStock()

            Me.FormatGridFromStock()
        End If
    End Sub

    Private Sub btnMoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveAl.Click
        flagGrid = 2
        If (BackgroundWorker1.IsBusy) Then Exit Sub
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub MoveAll()
        For k As Integer = 0 To dtSourceVatTu.Rows.Count - 1
            Dim objSourceDCVT As DataRow = dtSourceVatTu.Rows(k)
            Dim tmp As Double = 0
            If Not String.IsNullOrEmpty(objSourceDCVT("SL_DC")) Then
                tmp = objSourceDCVT("SL_DC")

            End If

            Dim Flag As Boolean = True
            For i As Integer = 0 To tb.Rows.Count - 1
                If objSourceDCVT("ID_DC") = tb.Rows(i).Item("ID_DC") And objSourceDCVT("MS_PT") = tb.Rows(i).Item("MS_PT") And objSourceDCVT("MS_DH_NHAP_PT") = tb.Rows(i).Item("MS_DH_NHAP_PT") Then
                    If tb.Rows(i).Item("SL_DC").ToString = "" Then
                        tb.Rows(i).Item("SL_DC") = objSourceDCVT("SL_VT")
                    Else
                        tb.Rows(i).Item("SL_DC") = tb.Rows(i).Item("SL_DC") + tb.Rows(i).Item("SL_VT")
                    End If
                    tb.Rows(i).Item("SL_VT") = 0
                    'tb.Rows(i).Item("SL_DC") = tb.Rows(i).Item("SL_DC") + objSourceDCVT("SL_VT
                    Flag = False
                    Exit For
                End If
            Next
            If Flag Then
                Dim dr As DataRow
                dr = tb.NewRow
                dr.Item("MS_DH_NHAP_PT") = objSourceDCVT("MS_DH_NHAP_PT")
                dr.Item("MS_PT") = objSourceDCVT("MS_PT")
                dr.Item("SL_VT") = 0
                dr.Item("SL_DC") = objSourceDCVT("SL_VT") + tmp
                dr.Item("ID_DC") = objSourceDCVT("ID_DC")
                tb.Rows.Add(dr)
            End If
            dtSourceVatTu.Rows(k)("SL_DC") = dtSourceVatTu.Rows(k)("SL_VT") + tmp
            dtSourceVatTu.Rows(k)("SL_VT") = 0
            'End While
        Next

        Dim dv As DataView = tb.DefaultView
        dv.Sort = "MS_PT ASC"
        tb = dv.ToTable()


        Me.FormatGridToStock()
        Me.FormatGridFromStock()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If Me.cboFromStock.SelectedValue Is Nothing Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_KHO_CAN_DI_CHUYEN_DI", Commons.Modules.TypeLanguage))
            Me.cboFromStock.Focus()
            Return
        Else
            If Me.cboToStock.SelectedValue Is Nothing Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_KHO_CAN_DI_CHUYEN_DEN", Commons.Modules.TypeLanguage))
                Me.cboToStock.Focus()
                Return
            Else
                If Me.cboFromStock.SelectedValue.ToString = Me.cboToStock.SelectedValue.ToString Then
                    If Me.cboFromPosition.SelectedValue Is Nothing Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_VI_TRI_DI_CHUYEN", Commons.Modules.TypeLanguage))
                        Me.cboFromPosition.Focus()
                        Return
                    Else
                        If Me.cboToPosition.SelectedValue Is Nothing Then
                            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_VI_TRI_CAN_DI_CHUYEN_DEN", Commons.Modules.TypeLanguage))
                            Me.cboToPosition.Focus()
                            Return
                        Else
                            If Me.cboToPosition.SelectedValue.ToString = Me.cboFromPosition.SelectedValue.ToString Then
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_VI_TRI_KHAC_CAN_DI_CHUYEN_DEN", Commons.Modules.TypeLanguage))
                                Me.cboToPosition.Focus()
                                Return
                            End If
                        End If
                    End If
                Else
                    If Me.cboToPosition.SelectedValue Is Nothing Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_VI_TRI_CAN_DI_CHUYEN_DEN", Commons.Modules.TypeLanguage))
                        Me.cboToPosition.Focus()
                        Return
                    End If
                End If
            End If
        End If
        If Me.grdFromVatTu.RowCount < 1 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "LOAD_VAT_TU_CAN_DI_CHUYEN_DEN", Commons.Modules.TypeLanguage))
            Me.cboToPosition.Focus()
            Return
        End If
        dtpGio.Value = Now
        Me.txtgio.Text = Format(dtpGio.Value, "long time")
        dtpNgay.Value = Now

        Load_DC(dtpNgay.Text, txtgio.Text)
        'Load_Vat_Tu_Kho_Vi_Tri()
        FormatGridToStock()
        Me.SetEnableButton(True)
        VisibleButton(False)
        btnLanDiChuyenMoi.Visible = False
        VisibleButtonGhi(True)
    End Sub

    Private Sub btnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi.Click
        Try
            For i As Integer = 0 To Me.lstDestinationVatTu.Count - 1
                If Me.lstDestinationVatTu.Item(i).SL_DC Is Nothing Or Me.lstDestinationVatTu.Item(i).SL_DC = "" Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHAP_SO_LUONG_CAN_CHUYEN", Commons.Modules.TypeLanguage))
                    Me.grdToVatTu.Rows(i).Cells("SL_DC").Selected = True
                    Return
                End If
            Next

            For i As Integer = 0 To Me.grdToVatTu.RowCount - 1
                If IsDBNull(grdToVatTu.Rows(i).Cells("SL_DC").Value) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NHAP_SO_LUONG_CAN_CHUYEN", Commons.Modules.TypeLanguage))
                    Me.grdToVatTu.Rows(i).Cells("SL_DC").Selected = True
                    Return
                    'ElseIf Me.grdToVatTu.Rows(i).Cells("SL_DC").Value Is Nothing Or Me.grdToVatTu.Rows(i).Cells("SL_DC").Value = "" Then
                    '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NHAP_SO_LUONG_CAN_CHUYEN", commons.Modules.TypeLanguage))
                    '    Me.grdToVatTu.Rows(i).Cells("SL_DC").Selected = True
                    '    Return
                End If
            Next

            If Add_Di_Chuyen_Vi_Tri_Trong_Kho(Me.dtpNgay.Value, Me.dtpGio.Value,
                    Integer.Parse(Me.cboFromStock.SelectedValue.ToString),
                    Integer.Parse(cboFromPosition.SelectedValue.ToString),
                    Integer.Parse(cboToStock.SelectedValue.ToString),
                    Integer.Parse(cboToPosition.SelectedValue.ToString), tb) Then


                'For j As Integer = 0 To Me.grdFromVatTu.RowCount - 1
                '    If Double.Parse(Me.grdFromVatTu.Rows(j).Cells("SL_VT").Value) > 0 Then

                '        Using connection As New SqlConnection(Commons.IConnections.ConnectionString)
                '            Dim command As New SqlCommand("QL_UPDATE_VI_TRI_KHO_VAT_TU", connection)
                '            command.CommandType = CommandType.StoredProcedure
                '            command.Parameters.AddWithValue("@MS_KHO", cboFromStock.SelectedValue)
                '            command.Parameters.AddWithValue("@MS_VI_TRI", cboFromPosition.SelectedValue)
                '            command.Parameters.AddWithValue("@MS_PT", Me.grdFromVatTu.Rows(j).Cells("MS_PT").Value)
                '            command.Parameters.AddWithValue("@MS_DH_NHAP_PT", Me.grdFromVatTu.Rows(j).Cells("MS_DH_NHAP_PT").Value)
                '            command.Parameters.AddWithValue("@SL_VT", Me.grdFromVatTu.Rows(j).Cells("SL_VT").Value)
                '            command.Parameters.AddWithValue("@ID_DC", Me.grdFromVatTu.Rows(j).Cells("ID_DC").Value)
                '            command.CommandTimeout = 99999


                '            Try
                '                If (connection.State = ConnectionState.Closed) Then
                '                    connection.Open()
                '                End If
                '                command.ExecuteNonQuery()
                '                connection.Close()
                '            Catch ex As Exception
                '            End Try
                '        End Using

                '    End If
                'Next
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ADD_DI_CHUYEN_VI_TRI,TRONG_KHO_SUCCESS", Commons.Modules.TypeLanguage))
                Me.SetEnableButton(False)
                Load_Vat_Tu_Kho_Vi_Tri()
                CreateTable()
                FormatGridToStock()
                VisibleButton(False)
                VisibleButtonGhi(False)
            Else
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ADD_DI_CHUYEN_VI_TRI,TRONG_KHO_NOT_SUCCESS", Commons.Modules.TypeLanguage))
            End If
            Me.cboNgayGio.BindDataSource()

            Load_DC(dtpNgay.Text, txtgio.Text)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ADD_DI_CHUYEN_VI_TRI,TRONG_KHO_NOT_SUCCESS", Commons.Modules.TypeLanguage))
        End Try
    End Sub

    Private Sub btnKhongGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKhongGhi.Click
        CreateTable()
        FormatGridToStock()
        Load_Vat_Tu_Kho_Vi_Tri()
        Me.SetEnableButton(False)
        VisibleButton(False)
        VisibleButtonGhi(False)
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SetEnableButton(False)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Dispose()
    End Sub

    Private Sub btnLanDiChuyenMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLanDiChuyenMoi.Click
        'dtpGio.Value = Now
        'Me.txtgio.Text = Format(Date.Now, "long time")
        'dtpNgay.Value = Now
        'Load_Vat_Tu_Kho_Vi_Tri()
        ''lstDestinationVatTu.Clear()
        'FormatGridToStock()
        'Me.SetEnableButton(False)
        'VisibleButton(True)
        'VisibleButtonGhi(False)

    End Sub

    Private Sub btnXEM_HINH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXEM_HINH.Click
        If Me.grdFromVatTu.RowCount < 0 Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHON_VAT_TU_CAN_XEM_HINH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Name)
            Exit Sub
        End If
        Try
            Dim objPTUNG As IC_PHU_TUNG_Info = Me.objDiChuyenVatTuController.Load_Phu_Tung(Me.grdFromVatTu.CurrentRow.Cells("MS_PT").Value.ToString)
            If objPTUNG.ANH_PT Is Nothing Or objPTUNG.ANH_PT = "" Then
                MsgBox(objPTUNG.MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUA_CO_DUONG_DAN_HINH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Name)
                Return
            End If
            System.Diagnostics.Process.Start(objPTUNG.ANH_PT)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgINVALID_PATH", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Name)
        End Try
    End Sub

    Private Sub cboFromStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        flagGrid = 1
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub cboToStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Vi_Tri_To_Stock()
    End Sub
    Private Sub cboFromPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Vat_Tu_Kho_Vi_Tri()
    End Sub

    Private Sub cboToPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Load_Vat_Tu_Kho_Vi_Tri()
    End Sub
    Private Sub grdFromVatTu_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFromVatTu.CellClick
        If e.RowIndex < 0 Then
            Return
        Else
            grdFromVatTu.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub grdToVatTu_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdToVatTu.CellBeginEdit
        grdFromVatTu.Enabled = False
    End Sub

    Private Sub grdToVatTu_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToVatTu.CellClick
        If grdToVatTu.Rows.Count < 1 Then
            Exit Sub
        End If
    End Sub

    Private Sub grdToVatTu_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdToVatTu.CellValidating
        Dim cell As DataGridViewCell = grdToVatTu.Item(e.ColumnIndex, e.RowIndex)
        If cell.IsInEditMode Then
            Dim ctrl As Control = grdToVatTu.EditingControl
            If grdToVatTu.Columns(e.ColumnIndex).Name = "SL_DC" Then
                Try
                    Dim SL_DC As Double = Double.Parse(ctrl.Text)
                    If SL_DC <= 0 Then
                        ctrl.Text = ""
                        e.Cancel = True
                        Return
                    End If
                    Dim objDestinationDCVT As DataRow = dtSourceVatTu.NewRow ' = Me.lstDestinationVatTu.Item(e.RowIndex)
                    Dim tmpSL_DC As Double = 0
                    If grdToVatTu.Rows(e.RowIndex).Cells("SL_DC").Value.ToString <> "" Then
                        tmpSL_DC = grdToVatTu.Rows(e.RowIndex).Cells("SL_DC").Value
                    End If
                    objDestinationDCVT("MS_DH_NHAP_PT") = grdToVatTu.Rows(e.RowIndex).Cells("MS_DH_NHAP_PT").Value
                    objDestinationDCVT("MS_PT") = grdToVatTu.Rows(e.RowIndex).Cells("MS_PT").Value
                    objDestinationDCVT("SL_DC") = e.FormattedValue
                    objDestinationDCVT("SL_VT") = grdToVatTu.Rows(e.RowIndex).Cells("SL_VT").Value
                    objDestinationDCVT("ID_DC") = grdToVatTu.Rows(e.RowIndex).Cells("ID_DC").Value
                    If objDestinationDCVT("SL_VT") + tmpSL_DC < SL_DC Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgSoluongkhongdung", Commons.Modules.TypeLanguage))
                        e.Cancel = True
                        Return
                    Else
                        If objDestinationDCVT("SL_VT") + tmpSL_DC = SL_DC Then
                            Dim result As DialogResult = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DO_YOU_WANT_TO_DELETE", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If result = Windows.Forms.DialogResult.Yes Then
                                grdToVatTu.Rows(e.RowIndex).Cells("SL_VT").Value = 0
                                For i As Integer = 0 To dtSourceVatTu.Rows.Count - 1
                                    If dtSourceVatTu.Rows(i)("MS_PT") = objDestinationDCVT("MS_PT") And dtSourceVatTu.Rows(i)("MS_DH_NHAP_PT") = objDestinationDCVT("MS_DH_NHAP_PT") Then
                                        'Me.lstSourceVatTu.RemoveAt(i)
                                        dtSourceVatTu.Rows(i)("SL_VT") = 0
                                        dtSourceVatTu.Rows(i)("SL_DC") = SL_DC
                                        Me.FormatGridFromStock()
                                        Exit For
                                    End If
                                Next
                            Else
                                e.Cancel = True
                                Return
                            End If
                        Else
                            Dim Flag As Boolean = True
                            For i As Integer = 0 To dtSourceVatTu.Rows.Count - 1
                                If dtSourceVatTu.Rows(i)("MS_PT") = objDestinationDCVT("MS_PT") And dtSourceVatTu.Rows(i)("MS_DH_NHAP_PT") = objDestinationDCVT("MS_DH_NHAP_PT") Then
                                    dtSourceVatTu.Rows(i)("SL_VT") = objDestinationDCVT("SL_VT") + tmpSL_DC - Double.Parse(SL_DC)
                                    dtSourceVatTu.Rows(i)("SL_DC") = Double.Parse(SL_DC)
                                    dtSourceVatTu.Rows(i)("ID_DC") = Double.Parse(objDestinationDCVT("ID_DC"))
                                    grdToVatTu.Rows(e.RowIndex).Cells("SL_VT").Value = grdToVatTu.Rows(e.RowIndex).Cells("SL_VT").Value + tmpSL_DC - SL_DC
                                    Me.FormatGridFromStock()
                                    Flag = False
                                    Exit For
                                End If
                            Next
                            If Flag Then
                                objDestinationDCVT("SL_VT") = objDestinationDCVT("SL_VT") - SL_DC
                                grdToVatTu.Rows(e.RowIndex).Cells("SL_VT").Value = grdToVatTu.Rows(e.RowIndex).Cells("SL_VT").Value - SL_DC
                                dtSourceVatTu.Rows.Add(objDestinationDCVT)
                                FormatGridFromStock()
                            End If
                        End If
                    End If
                Catch ex As Exception
                    ctrl.Text = ""
                    e.Cancel = True
                End Try
            End If
        End If
    End Sub
#End Region

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        If grdToVatTu.RowCount < 1 Then
            Return
        Else
            Dim objSourceDCVT As DataRow = dtSourceVatTu.NewRow  '= Me.lstDestinationVatTu.Item(Me.grdToVatTu.CurrentRow.Index)
            objSourceDCVT("MS_DH_NHAP_PT") = grdToVatTu.CurrentRow.Cells("MS_DH_NHAP_PT").Value
            objSourceDCVT("MS_PT") = grdToVatTu.CurrentRow.Cells("MS_PT").Value
            objSourceDCVT("ID_DC") = grdToVatTu.CurrentRow.Cells("ID_DC").Value
            If grdToVatTu.CurrentRow.Cells("SL_DC").Value.ToString = "" Then
                objSourceDCVT("SL_DC") = Nothing
            Else
                objSourceDCVT("SL_DC") = grdToVatTu.CurrentRow.Cells("SL_DC").Value
            End If
            objSourceDCVT("SL_VT") = grdToVatTu.CurrentRow.Cells("SL_VT").Value
            Dim Flag As Boolean = True
            For i As Integer = 0 To dtSourceVatTu.Rows.Count - 1
                If objSourceDCVT("ID_DC") = dtSourceVatTu.Rows(i)("ID_DC") And
                        objSourceDCVT("MS_PT") = dtSourceVatTu.Rows(i)("MS_PT") And
                        objSourceDCVT("MS_DH_NHAP_PT") = dtSourceVatTu.Rows(i)("MS_DH_NHAP_PT") Then
                    Dim tmp As Double = 0
                    If objSourceDCVT("SL_DC") <> Nothing Then
                        tmp = objSourceDCVT("SL_DC")
                    End If
                    dtSourceVatTu.Rows(i)("SL_VT") = dtSourceVatTu.Rows(i)("SL_VT") + tmp
                    dtSourceVatTu.Rows(i)("SL_DC") = DBNull.Value
                    Flag = False
                End If
            Next
            If Flag Then
                If objSourceDCVT("SL_DC") <> Nothing Then
                    objSourceDCVT("SL_VT") = objSourceDCVT("SL_VT")
                    objSourceDCVT("SL_DC") = Nothing
                End If
                dtSourceVatTu.Rows.Add(objSourceDCVT)
            End If
            Me.FormatGridFromStock()
            Dim j As Integer = Me.grdToVatTu.CurrentRow.Index
            grdToVatTu.Rows.RemoveAt(j)

        End If
    End Sub

    Private Sub BtnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemoveAl.Click
        CreateTable()
        FormatGridToStock()
        Load_Vat_Tu_Kho_Vi_Tri()
    End Sub

    Private Sub grdToVatTu_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdToVatTu.DataError

    End Sub
    Dim intRowTo As Integer = 0
    Private Sub grdToVatTu_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToVatTu.RowEnter
        intRowTo = e.RowIndex
    End Sub

    Private Sub dtpNgay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpNgay.Validating
        If dtpNgay.Value > Now() Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNgayDiChuyenLonHonHienTai", Commons.Modules.TypeLanguage))
            dtpNgay.Value = Now
            e.Cancel = True
        Else
            Me.txtgio.Text = Format(Date.Now, "long time")
            dtpGio.Value = Now
        End If
    End Sub

    Private Sub dtpGio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpGio.Validating
        If Not IsDate(dtpGio.Value) Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGioKhongHopLe", Commons.Modules.TypeLanguage))
            dtpGio.Value = Now
            e.Cancel = True
        End If
    End Sub
    Dim txtDiChuyen As TextBox
    Sub HandleKeyPressFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 37 And Asc(e.KeyChar) <> 39 And Asc(e.KeyChar) <> 188 Then
                e.Handled = True
                Exit Sub
            End If
            e.Handled = False
        End If
    End Sub
    Private Sub grdToVatTu_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdToVatTu.EditingControlShowing
        Try
            If Me.grdToVatTu.CurrentCellAddress.X = 2 Then
                txtDiChuyen = e.Control

                RemoveHandler txtDiChuyen.KeyPress, AddressOf Me.HandleKeyPressFloat
                AddHandler txtDiChuyen.KeyPress, AddressOf Me.HandleKeyPressFloat
            Else
                RemoveHandler txtDiChuyen.KeyPress, AddressOf Me.HandleKeyPressFloat
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtMS_PT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub txtTen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For i As Integer = 0 To grdFromVatTu.Rows.Count - 1
    '        Try
    '            If grdFromVatTu.Rows(i).Cells("TEN_PT").Value.ToString().Trim().ToUpper().IndexOf(txtTen.Text.Trim().ToUpper()) <> -1 Then
    '                grdFromVatTu.CurrentCell = grdFromVatTu.Rows(i).Cells("TEN_PT")
    '                Exit Sub
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    Next
    'End Sub

    Private Sub grdToVatTu_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToVatTu.CellEndEdit
        grdFromVatTu.Enabled = True
    End Sub

    Private Sub cboToPosition_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboToPosition.SelectedValueChanged

    End Sub

    Private Sub cboToPosition_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboToPosition.SelectedIndexChanged
        Dim Ngay As String = ""
        Dim Gio As String = ""
        Try
            If Me.cboNgayGio.SelectedValue IsNot Nothing Then
                Ngay = cboNgayGio.SelectedValue.ToString()
                Ngay = Format(Convert.ToDateTime(Ngay), "dd/MM/yyyy")


                Gio = cboNgayGio.SelectedValue.ToString()
                Gio = Format(Convert.ToDateTime(Gio), "HH:mm:ss")
            End If
        Catch ex As Exception

        End Try

        Load_DC(Ngay, Gio)
    End Sub

    Private Sub cboNgayGio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNgayGio.SelectedIndexChanged
        Dim Ngay As String = ""
        Dim Gio As String = ""
        Try
            If Me.cboNgayGio.SelectedValue IsNot Nothing Then
                Ngay = cboNgayGio.SelectedValue.ToString()
                Ngay = Format(Convert.ToDateTime(Ngay), "dd/MM/yyyy")

                Gio = cboNgayGio.SelectedValue.ToString()
                Gio = Format(Convert.ToDateTime(Gio), "HH:mm:ss")
            End If
        Catch ex As Exception
            Ngay = Now
            Gio = Format(Date.Now, "long time")
        End Try

        dtpNgay.Text = Ngay
        txtgio.Text = Gio
        Load_DC(Ngay, Gio)
    End Sub


    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Load_DC(dtpNgay.Text, txtgio.Text)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim dtTmp1 As New DataTable
        dtTmp1 = CType(grdFromVatTu.DataSource, DataTable)

        Try
            dtTmp1.DefaultView.RowFilter = "MS_PT like '%" & txtSearch.Text.Trim() & "%' OR TEN_PT LIKE '%" & txtSearch.Text.Trim() & "%'"
        Catch ex As Exception
            dtTmp1.DefaultView.RowFilter = ""

        End Try
    End Sub


    Private Delegate Sub setDataGridInvoker(ByVal grd As DataGridView, ByVal flag As Integer)
    '1 lưới trái, 2 lưới phải
    Private Sub setDataGrid(ByVal grd As DataGridView, ByVal flag As Integer)
        Try
            If grd.InvokeRequired Then
                grd.Invoke(New setDataGridInvoker(AddressOf setDataGrid), grd, flag)
            Else
                If (flag = 1) Then
                    Load_Vi_Tri_From_Stock()
                Else
                    MoveAll()
                End If

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim flagGrid As Integer
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If (flagGrid = 1) Then

            loadPhuTungToLeftGrid()
        Else
            loadPhuTungToRightGrid()
        End If

    End Sub
    Private Sub loadPhuTungToLeftGrid()
        setDataGrid(grdFromVatTu, flagGrid)
        Threading.Thread.Sleep(500)
    End Sub

    Private Sub loadPhuTungToRightGrid()
        setDataGrid(grdToVatTu, flagGrid)
        Threading.Thread.Sleep(500)
    End Sub

    Public Function Add_Di_Chuyen_Vi_Tri_Trong_Kho(ByVal NGAY_CHUYEN As Date, ByVal GIO_CHUYEN As Date,
        ByVal MS_KHO As Integer, ByVal MS_VI_TRI As Integer, ByVal MS_KHO_1 As Integer,
        ByVal MS_VI_TRI_1 As Integer, ByVal tb As DataTable) As Boolean
        Try
            For i As Integer = 0 To tb.Rows.Count - 1
                If Not IsDBNull(tb.Rows(i).Item("SL_DC")) Then


                    Using connection As New SqlConnection(Commons.IConnections.ConnectionString)
                        Dim command As New SqlCommand("QL_ADD_DI_CHUYEN_VI_TRI_TRONG_KHO", connection)
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@NGAY_CHUYEN", NGAY_CHUYEN)
                        command.Parameters.AddWithValue("@GIO_CHUYEN", GIO_CHUYEN)
                        command.Parameters.AddWithValue("@MS_KHO", MS_KHO)
                        command.Parameters.AddWithValue("@MS_VI_TRI", MS_VI_TRI)
                        command.Parameters.AddWithValue("@MS_PT", tb.Rows(i).Item("MS_PT"))
                        command.Parameters.AddWithValue("@MS_DH_NHAP_PT", tb.Rows(i).Item("MS_DH_NHAP_PT"))
                        command.Parameters.AddWithValue("@MS_KHO_1", MS_KHO_1)
                        command.Parameters.AddWithValue("@MS_VI_TRI_1", MS_VI_TRI_1)
                        command.Parameters.AddWithValue("@SL_CHUYEN", Double.Parse(tb.Rows(i).Item("SL_DC")))
                        command.Parameters.AddWithValue("@SL_VT", tb.Rows(i).Item("SL_VT"))
                        command.Parameters.AddWithValue("@ID_DC", Double.Parse(tb.Rows(i).Item("ID_DC")))
                        command.CommandTimeout = 99999
                        Try
                            If (connection.State = ConnectionState.Closed) Then
                                connection.Open()
                            End If

                            command.ExecuteNonQuery()
                            connection.Close()
                        Catch ex As Exception
                        End Try

                        Dim objVTKVT As New VI_TRI_KHO_VAT_TU_Info
                        objVTKVT.MS_DH_NHAP_PT = tb.Rows(i).Item("MS_DH_NHAP_PT")
                        objVTKVT.MS_KHO = MS_KHO_1
                        objVTKVT.MS_VI_TRI = MS_VI_TRI_1
                        objVTKVT.MS_PT = tb.Rows(i).Item("MS_PT")
                        objVTKVT.SL_VT = Double.Parse(tb.Rows(i).Item("SL_DC"))
                        objVTKVT.ID = Double.Parse(tb.Rows(i).Item("ID_DC"))


                        command = New SqlCommand("QL_LOAD_VI_TRI_KHO_VAT_TU", connection)
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@MS_KHO", objVTKVT.MS_KHO)
                        command.Parameters.AddWithValue("@MS_PT", objVTKVT.MS_PT)
                        command.Parameters.AddWithValue("@MS_VI_TRI", objVTKVT.MS_VI_TRI)
                        command.Parameters.AddWithValue("@MS_DH_NHAP_PT", objVTKVT.MS_DH_NHAP_PT)
                        command.Parameters.AddWithValue("@ID", objVTKVT.ID)

                        command.CommandTimeout = 99999

                        If (connection.State = ConnectionState.Closed) Then
                            connection.Open()
                        End If

                        Dim dtReader As New DataTable
                        dtReader.Load(command.ExecuteReader())
                        connection.Close()

                        Dim Flag As Boolean = True
                        For Each row As DataRow In dtReader.Rows
                            objVTKVT.SL_VT = objVTKVT.SL_VT + Double.Parse(row("SL_VT").ToString)
                            command = New SqlCommand("QL_UPDATE_VI_TRI_KHO_VAT_TU", connection)
                            command.CommandType = CommandType.StoredProcedure
                            command.Parameters.AddWithValue("@MS_KHO", objVTKVT.MS_KHO)
                            command.Parameters.AddWithValue("@MS_PT", objVTKVT.MS_PT)
                            command.Parameters.AddWithValue("@MS_VI_TRI", objVTKVT.MS_VI_TRI)
                            command.Parameters.AddWithValue("@MS_DH_NHAP_PT", objVTKVT.MS_DH_NHAP_PT)
                            command.Parameters.AddWithValue("@SL_VT", objVTKVT.SL_VT)
                            command.Parameters.AddWithValue("@ID", objVTKVT.ID)

                            command.CommandTimeout = 99999

                            If (connection.State = ConnectionState.Closed) Then
                                connection.Open()
                            End If
                            command.ExecuteNonQuery()
                            connection.Close()
                            Flag = False
                        Next


                        If Flag Then

                            command = New SqlCommand("QL_ADD_VI_TRI_KHO_VAT_TU", connection)
                            command.CommandType = CommandType.StoredProcedure
                            command.Parameters.AddWithValue("@MS_KHO", objVTKVT.MS_KHO)
                            command.Parameters.AddWithValue("@MS_PT", objVTKVT.MS_PT)
                            command.Parameters.AddWithValue("@MS_VI_TRI", objVTKVT.MS_VI_TRI)
                            command.Parameters.AddWithValue("@MS_DH_NHAP_PT", objVTKVT.MS_DH_NHAP_PT)
                            command.Parameters.AddWithValue("@SL_VT", objVTKVT.SL_VT)
                            command.Parameters.AddWithValue("@ID", objVTKVT.ID)

                            command.CommandTimeout = 99999

                            If (connection.State = ConnectionState.Closed) Then
                                connection.Open()
                            End If
                            command.ExecuteNonQuery()
                            connection.Close()
                        End If
                    End Using
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True
    End Function

    Private Sub btnIn_Click(sender As Object, e As EventArgs) Handles btnIn.Click
        Dim frm As VietShape.frmInDSDiChuyenKho = New VietShape.frmInDSDiChuyenKho()
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog()
    End Sub
End Class

