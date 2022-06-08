
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports System.Convert
Imports Commons.VS.Classes.Admin
Imports Microsoft.VisualBasic.DateAndTime
Imports DevExpress.XtraEditors

Public Class frmYeucaucuaNSD_Duyet

#Region "bien"

    Private tab As Boolean = False
    Private blnThem As Byte = 0
    Private row As Integer = 0
    Private flage As Boolean = True
    Private intSTT, intSTT_TMP As Integer
    Private intRowchon, intRowDS As Integer
    Private TBChitietyeucau As New DataTable()

    Private intSTT_VAN_DE, intSTT_HINH As Integer
    Private strMS_MAY As String = ""
    Private bChuyen As Boolean = True
    Private TBHinh As New DataTable()
    Private tb As New DataTable()
    Private intHinh As Integer = 0
    Private arrHinh As New ArrayList()
    Private intChiTiet As Integer = 0
    Private ArrChiTiet As New ArrayList()
    Private TBDONG As New DataTable()
    Dim stt As Integer = 0
    Dim strDUONG_DAN_HINH_YEU_CAU_NSD As String = ""
#End Region

    Private Sub frmYeucaucuaNSD_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub
    Private Sub frmYeucaucuaNSD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            If Commons.Modules.PermisString.Equals("Read only") Then
                dtTungay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 7)
                LoadcboTennguoiyeucau()
                LockData(True)
                LockData1(False)
                LockData2(True)
                LockData3(True)
                LoadDanhsachyeucau()
                RefeshLanguage()
                VisibleButton(True)
                VisibleButtonGhi(False)
                VisibleButtonXoa(False)

                Try
                    grdHinh.Columns("DUONG_DAN").ReadOnly = True
                Catch ex As Exception
                End Try
                AddHandler grdHinh.CellValidating, AddressOf Me.grdHinh_CellValidating
                'EnableButton(False)
            Else
                'EnableButton(True)
                dtTungay.Value = DateSerial(Year(Format(Now(), "short date")), Month(Format(Now(), "short date")), Day(Format(Now(), "short date")) - 7)
                LoadcboTennguoiyeucau()
                LockData(True)
                LockData1(False)
                LockData2(True)
                LockData3(True)
                LoadDanhsachyeucau()
                RefeshLanguage()
                VisibleButton(True)
                VisibleButtonGhi(False)
                VisibleButtonXoa(False)
                Try
                    If grdDanhsachyeucau.Rows.Count <> 0 Then
                        Me.grdDanhsachyeucau.Rows(0).Cells("NGAY").Selected = True
                    End If
                Catch ex As Exception
                End Try
                Try
                    grdHinh.Columns("DUONG_DAN").ReadOnly = True
                Catch ex As Exception
                End Try
                AddHandler grdHinh.CellValidating, AddressOf Me.grdHinh_CellValidating
                AddHandler grdHinh.CellMouseDoubleClick, AddressOf grdHinh_CellMouseDoubleClick
            End If

            If Commons.Modules.PermisString.Equals("Read only") Then
                btnXacNhan.Enabled = False
                chkNguoiduyet.Enabled = False
            End If
        Catch ex As Exception

        End Try
        Commons.Modules.ObjSystems.DinhDang()
        Commons.Modules.ObjSystems.ThayDoiNN(Me)

    End Sub

#Region "kiem tra ngay"
    Private Sub dtNgayyeucau_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles dtNgayyeucau.ValueChanged
        txtNgayyeucau.Text = Format(dtNgayyeucau.Value, "Short date")
    End Sub



    Private Sub dtNgayhoanthanh_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles dtNgayhoanthanh.ValueChanged
        txtNgayhoanthanh.Text = Format(dtNgayhoanthanh.Value, "Short date")
    End Sub


    Private Sub BtnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtNgayhoanthanh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtNgayhoanthanh.Validating
        If txtNgayhoanthanh.Text <> "" And txtNgayhoanthanh.Text <> "  /  /" Then
            If Not IsDate(txtNgayhoanthanh.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra1", Commons.Modules.TypeLanguage), _
                                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayhoanthanh.Text = ""
                e.Cancel = True
                Exit Sub
            Else
                If Date.Parse(txtNgayyeucau.Text) > Date.Parse(txtNgayhoanthanh.Text) Then
                    'Ngày hoàn thành không du?c nh? hon ngày yêu c?u
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra4", Commons.Modules.TypeLanguage), _
                                                                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtNgayhoanthanh.Text = ""
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub



    Private Sub txtNgayyeucau_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtNgayyeucau.Validating
        If txtNgayyeucau.Text <> "" And txtNgayyeucau.Text <> "  /  /" Then
            If Not IsDate(txtNgayyeucau.Text) Then
                ' Ngày tháng ki?u dd/mm/yyyy
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra1", Commons.Modules.TypeLanguage), _
                            MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                txtNgayyeucau.Text = ""
                e.Cancel = True
                Exit Sub
            Else
                If CDate(txtNgayyeucau.Text) > Format(Date.Now, "short date") Then
                    ' Ngày yêu c?u ph?i nh? hay b?ng ngày hi?n t?i
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra2", Commons.Modules.TypeLanguage), _
                                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtNgayyeucau.Text = ""
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Else
            'txtNgayyeucau.Text = Format(Now(), "Short date")
        End If
    End Sub

    Private Sub txtGioyeucau_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) ' Handles txtGioyeucau.Validating
        If txtGioyeucau.Text <> "  :" Then
            If Not IsDate(txtGioyeucau.Text) Then
                ' Gi? không h?p l? ! Gi? ph?i có ki?u HH:MM (24h) !
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra6", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtGioyeucau.Text = ""
                e.Cancel = True
                txtGioyeucau.Focus()
                Exit Sub
            End If
        Else
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra7", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtGioyeucau.Text = ""
            e.Cancel = True
            txtGioyeucau.Focus()
            Exit Sub
        End If
    End Sub
#End Region
#Region "event"
    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RemoveHandler grdHinh.CellValidating, AddressOf Me.grdHinh_CellValidating
        RemoveHandler grdHinh.CellMouseDoubleClick, AddressOf Me.grdHinh_CellMouseDoubleClick
        grdHinh.Columns.Clear()
        tab = True
        blnThem = 1
        chkNguoiduyet.Text = "Check"
        LockData(False)
        LockData1(True)
        LockData2(False)
        LockData3(False)
        VisibleButton(False)
        VisibleButtonGhi(True)

        Refesh()
        txtNgayyeucau.Text = Format(Now(), "Short date")
        txtGioyeucau.Text = Format(Now(), "HH:mm")
        SetTabYeucau(1)
        ShowChichitietyeucau(intSTT)

        txtNgayyeucau.Focus()
        AddHandler txtNgayyeucau.Validating, AddressOf Me.txtNgayyeucau_Validating
        AddHandler txtNgayhoanthanh.Validating, AddressOf Me.txtNgayhoanthanh_Validating
        AddHandler txtGioyeucau.Validating, AddressOf Me.txtGioyeucau_Validating
        AddHandler dtNgayyeucau.ValueChanged, AddressOf Me.dtNgayyeucau_ValueChanged
        AddHandler dtNgayhoanthanh.ValueChanged, AddressOf Me.dtNgayhoanthanh_ValueChanged
        AddHandler grdChitietyeucau.RowValidating, AddressOf Me.grdChitietyeucau_RowValidating
        AddHandler grdChitietyeucau.CellValidating, AddressOf Me.grdChitietyeucau_CellValidating
        AddHandler chkNguoiduyet.CheckedChanged, AddressOf Me.chkNguoiduyet_CheckedChanged
        AddHandler grdChitietyeucau.EditingControlShowing, AddressOf Me.grdChitietyeucau_EditingControlShowing
        AddHandler grdChitietyeucau.DataSourceChanged, AddressOf Me.grdChitietyeucau_DataSourceChanged
        AddHandler grdChitietyeucau.CellValueChanged, AddressOf Me.grdChitietyeucau_CellValueChanged
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RemoveHandler grdHinh.CellValidating, AddressOf Me.grdHinh_CellValidating
        RemoveHandler grdHinh.CellMouseDoubleClick, AddressOf Me.grdHinh_CellMouseDoubleClick
        rtxtReviewer.Enabled = True
        tab = True
        LockData(False)
        LockData1(True)
        If txtUsername.Text = "" Then
            LockData2(False)
        Else
            LockData2(True)
        End If

        LockData3(False)

        blnThem = 2
        VisibleButton(False)
        VisibleButtonGhi(True)
        SetTabYeucau(1)
        ShowChichitietyeucau(intSTT)
        txtNgayyeucau.Focus()

        grdHinh.AllowUserToAddRows = False
        AddHandler txtNgayyeucau.Validating, AddressOf Me.txtNgayyeucau_Validating
        AddHandler txtNgayhoanthanh.Validating, AddressOf Me.txtNgayhoanthanh_Validating
        AddHandler txtGioyeucau.Validating, AddressOf Me.txtGioyeucau_Validating
        AddHandler dtNgayyeucau.ValueChanged, AddressOf Me.dtNgayyeucau_ValueChanged
        AddHandler dtNgayhoanthanh.ValueChanged, AddressOf Me.dtNgayhoanthanh_ValueChanged
        AddHandler grdChitietyeucau.RowValidating, AddressOf Me.grdChitietyeucau_RowValidating
        AddHandler grdChitietyeucau.CellValidating, AddressOf Me.grdChitietyeucau_CellValidating
        AddHandler chkNguoiduyet.CheckedChanged, AddressOf Me.chkNguoiduyet_CheckedChanged
        AddHandler grdChitietyeucau.EditingControlShowing, AddressOf Me.grdChitietyeucau_EditingControlShowing
        AddHandler grdChitietyeucau.DataSourceChanged, AddressOf Me.grdChitietyeucau_DataSourceChanged
        AddHandler grdChitietyeucau.CellValueChanged, AddressOf Me.grdChitietyeucau_CellValueChanged
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        If txtNgayyeucau.Text = "  /  /" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra7", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtNgayyeucau.Focus()
            Exit Sub
        End If
        If txtGioyeucau.Text = "  :" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra10", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtGioyeucau.Focus()
            Exit Sub
        End If
        If txtNguoiyeucau.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra8", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            txtNguoiyeucau.Focus()
            Exit Sub
        End If
        If txtNgayhoanthanh.Text <> "  /  /" Then
            If Date.Parse(txtNgayyeucau.Text) > Date.Parse(txtNgayhoanthanh.Text) Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra4", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                txtNgayhoanthanh.Focus()
                Exit Sub
            End If
        End If
        If grdChitietyeucau.Rows.Count <= 0 Then
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeucaucuaNSD", "Msgghi", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Exit Sub
            Else
                blnThem = 0
                Refesh()
                tab = False
                LoadDanhsachyeucau()
                LockData(True)
                LockData1(False)
                LockData2(True)
                LockData3(True)
                VisibleButton(True)
                Exit Sub
            End If
        End If


        For i As Integer = 0 To grdChitietyeucau.Rows.Count - 2
            If grdChitietyeucau.Rows(i).Cells("MO_TA_TINH_TRANG").Value.ToString = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                grdChitietyeucau.CurrentCell() = grdChitietyeucau.Rows(i).Cells("MO_TA_TINH_TRANG")
                grdChitietyeucau.Focus()
                Exit Sub
            End If
        Next


        For i As Integer = 0 To grdChitietyeucau.Rows.Count - 2
            If grdChitietyeucau.Rows(i).Cells("cboMUC_UU_TIEN").Value.ToString = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "UU_TIEN_KO_DC_TRONG", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                grdChitietyeucau.CurrentCell() = grdChitietyeucau.Rows(i).Cells("cboMUC_UU_TIEN")
                grdChitietyeucau.Focus()
                Exit Sub
            End If
        Next


        Dim s As String = ""
        s = strMS_MAY
        'Dim t As Integer
        't = intSTT_VAN_DE
        't = intRowchon
        't = intSTT
        ' ShowChichitietyeucau(intSTT)

        If AddYeucau() Then
            'grdHinh.DataSource = System.DBNull.Value
            tab = False
            blnThem = 0

            Dim stt, stt_vd As Integer
            Dim MS_MAY As String = ""
            stt = intSTT
            stt_vd = intSTT_VAN_DE
            MS_MAY = strMS_MAY
            'Refesh()
            intSTT = stt
            intSTT_VAN_DE = stt_vd
            strMS_MAY = MS_MAY
            LoadcboTennguoiyeucau()
            LoadDanhsachyeucau()
            For i As Integer = 0 To grdDanhsachyeucau.Rows.Count - 1
                If grdDanhsachyeucau.Rows(i).Cells("STT").Value = stt Then
                    'Me.grdDanhsachyeucau.Rows(i).Cells("NGAY").Selected = True
                    Me.grdDanhsachyeucau.Focus()
                    ShowData(i)
                    Exit For
                Else
                    Me.grdDanhsachyeucau.Rows(i).Selected = False
                End If
            Next

            ShowChichitietyeucau(stt)
            'ShowHinh(stt, strMS_MAY, intSTT_VAN_DE, 0)
            LockData(True)
            LockData1(False)
            LockData2(True)
            LockData3(True)
            VisibleButton(True)

        End If
        btnXacNhan.Visible = True
        bCo = False
        rtxtReviewer.Enabled = True
        RemoveHandler txtNgayyeucau.Validating, AddressOf Me.txtNgayyeucau_Validating
        RemoveHandler txtNgayhoanthanh.Validating, AddressOf Me.txtNgayhoanthanh_Validating
        RemoveHandler txtGioyeucau.Validating, AddressOf Me.txtGioyeucau_Validating
        RemoveHandler dtNgayyeucau.ValueChanged, AddressOf Me.dtNgayyeucau_ValueChanged
        RemoveHandler dtNgayhoanthanh.ValueChanged, AddressOf Me.dtNgayhoanthanh_ValueChanged
        RemoveHandler grdChitietyeucau.RowValidating, AddressOf Me.grdChitietyeucau_RowValidating
        RemoveHandler grdChitietyeucau.CellValidating, AddressOf Me.grdChitietyeucau_CellValidating
        RemoveHandler chkNguoiduyet.CheckedChanged, AddressOf Me.chkNguoiduyet_CheckedChanged
        RemoveHandler grdChitietyeucau.EditingControlShowing, AddressOf Me.grdChitietyeucau_EditingControlShowing
        RemoveHandler grdChitietyeucau.DataSourceChanged, AddressOf Me.grdChitietyeucau_DataSourceChanged
        RemoveHandler grdChitietyeucau.CellValueChanged, AddressOf Me.grdChitietyeucau_CellValueChanged
        AddHandler grdHinh.CellValidating, AddressOf Me.grdHinh_CellValidating
        AddHandler grdHinh.CellMouseDoubleClick, AddressOf Me.grdHinh_CellMouseDoubleClick
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RemoveHandler txtNgayyeucau.Validating, AddressOf Me.txtNgayyeucau_Validating
        RemoveHandler txtNgayhoanthanh.Validating, AddressOf Me.txtNgayhoanthanh_Validating
        RemoveHandler txtGioyeucau.Validating, AddressOf Me.txtGioyeucau_Validating
        RemoveHandler dtNgayyeucau.ValueChanged, AddressOf Me.dtNgayyeucau_ValueChanged
        RemoveHandler dtNgayhoanthanh.ValueChanged, AddressOf Me.dtNgayhoanthanh_ValueChanged
        RemoveHandler grdChitietyeucau.RowValidating, AddressOf Me.grdChitietyeucau_RowValidating
        RemoveHandler grdChitietyeucau.CellValidating, AddressOf Me.grdChitietyeucau_CellValidating
        RemoveHandler chkNguoiduyet.CheckedChanged, AddressOf Me.chkNguoiduyet_CheckedChanged
        RemoveHandler grdChitietyeucau.EditingControlShowing, AddressOf Me.grdChitietyeucau_EditingControlShowing
        RemoveHandler grdChitietyeucau.DataSourceChanged, AddressOf Me.grdChitietyeucau_DataSourceChanged
        RemoveHandler grdChitietyeucau.CellValueChanged, AddressOf Me.grdChitietyeucau_CellValueChanged
        AddHandler grdHinh.CellValidating, AddressOf Me.grdHinh_CellValidating
        AddHandler grdHinh.CellMouseDoubleClick, AddressOf Me.grdHinh_CellMouseDoubleClick
        Refesh()
        bCo = False
        rtxtReviewer.Enabled = True
        tab = False
        VisibleButton(True)
        VisibleButtonGhi(False)
        VisibleButtonXoa(False)
        blnThem = 0
        ShowData(intRowDS)
        ShowChichitietyeucau(intSTT)
        ShowHinh(intSTT, strMS_MAY, intSTT_VAN_DE, intRowchon)
        LockData(True)
        LockData1(False)
        LockData2(True)
        LockData3(True)

    End Sub
    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        VisibleButton(False)
        VisibleButtonGhi(False)
        VisibleButtonXoa(True)
    End Sub
    Private Sub TabYeucau_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabYeucau.SelectedIndexChanged

        If tab Then
            SetTabYeucau(1)
        Else
            If TabYeucau.SelectedIndex = 0 Then
                intSTT_TMP = intSTT
                LoadDanhsachyeucau()
                For i As Integer = 0 To grdDanhsachyeucau.Rows.Count - 1
                    If grdDanhsachyeucau.Rows(i).Cells("STT").Value = intSTT_TMP Then
                        grdDanhsachyeucau.CurrentCell() = Me.grdDanhsachyeucau.Rows(i).Cells("NGAY")
                        grdDanhsachyeucau.Focus()
                        ShowData(i)
                        Exit For
                    Else
                        Me.grdDanhsachyeucau.Rows(i).Selected = False
                    End If
                Next
                'If BtnXoaCTyeucau.Visible Or BtnXoahinh.Visible Then
                '    BtnXoaCTyeucau.Enabled = False
                '    BtnXoahinh.Enabled = False
                '    BtnXoaYC.Enabled = True
                'Else
                '    BtnXoaCTyeucau.Enabled = True
                '    BtnXoahinh.Enabled = True
                '    BtnXoaYC.Enabled = False
                'End If
            Else
                ShowChichitietyeucau(intSTT)
                ShowHinh(intSTT, strMS_MAY, intSTT_VAN_DE, intRowchon)
                'If BtnXoaCTyeucau.Visible Or BtnXoahinh.Visible Then
                '    BtnXoaCTyeucau.Enabled = True
                '    BtnXoahinh.Enabled = True
                '    BtnXoaYC.Enabled = False
                'Else
                '    BtnXoaCTyeucau.Enabled = False
                '    BtnXoahinh.Enabled = False
                '    BtnXoaYC.Enabled = True
            End If
        End If
        'End If
        If TabYeucau.SelectedTab.Name = "TabChitietyeucau" Then
            btnXemHinh.Visible = True
        Else
            btnXemHinh.Visible = False
        End If
    End Sub
    Private Sub grdDanhsachyeucau_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachyeucau.RowEnter
        ShowData(e.RowIndex)
        ShowChichitietyeucau(intSTT)
        intRowDS = e.RowIndex

    End Sub

    Private Sub grdDanhsachyeucau_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachyeucau.RowHeaderMouseClick
        ShowData(e.RowIndex)
        ShowChichitietyeucau(intSTT)
        intRowDS = e.RowIndex
    End Sub
    Private Sub grdChitietyeucau_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles grdChitietyeucau.CellValidating

        'Try


        '    If BtnGhi.Visible And BtnThem.Visible = False Then
        '        grdChitietyeucau.EndEdit()
        '        If grdChitietyeucau.Columns(e.ColumnIndex).Name = "cboMS_MAY" Then


        '            Dim vtbtmp As New DataTable
        '            vtbtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_MAY,TEN_MAY FROM dbo.MAY WHERE MS_MAY = N'" + grdChitietyeucau.Rows(e.RowIndex).Cells("MS_MAY").Value.ToString + "'"))

        '            grdChitietyeucau.Rows(e.RowIndex).Cells("TEN_MAY").Value = vtbtmp.Rows(0)("TEN_MAY")
        '            grdChitietyeucau.Columns("TEN_MAY").ReadOnly = True
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try


        If e.ColumnIndex = 1 And blnThem > 0 And e.RowIndex < grdChitietyeucau.Rows.Count - 2 Then
            strMS_MAY = e.FormattedValue
            If strMS_MAY = "" Then
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "Msgnullmsmay", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Selected = True
                e.Cancel = True
            End If
        End If

        If grdChitietyeucau.Columns(e.ColumnIndex).Name = "MO_TA_TINH_TRANG" Then
            If e.FormattedValue = "" And grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Value.ToString() <> "" Then
                grdChitietyeucau.Rows(e.RowIndex).ErrorText = "Error"
                'c?t này b?t b?ôc ph?i nh?p d? li?u
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                grdChitietyeucau.Rows(e.RowIndex).Cells("MO_TA_TINH_TRANG").Selected = True
                grdChitietyeucau.Focus()
                e.Cancel = True
                Exit Sub
            Else
                grdChitietyeucau.Rows(e.RowIndex).ErrorText = ""
            End If
        End If
    End Sub

    Private Sub grdChitietyeucau_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChitietyeucau.CellClick
        If BtnGhi.Visible Then
            Try
                If grdChitietyeucau.Columns(e.ColumnIndex).Name = "cboNHANVIEN" Or grdChitietyeucau.Columns(e.ColumnIndex).Name = "NOI_DUNG_XAC_NHAN" Then
                    grdChitietyeucau.ReadOnly = False
                Else
                    grdChitietyeucau.ReadOnly = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdChitietyeucau_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles grdChitietyeucau.CellValueChanged
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            If dgv.Columns(e.ColumnIndex).Name = "cboMS_MAY" Or dgv.Columns(e.ColumnIndex).Name = "cboNHANVIEN" Then
                Dim val As String = dgv(e.ColumnIndex, e.RowIndex).Value
                If Not String.IsNullOrEmpty(val) AndAlso _
                     Not Me.autoCompleteSource.Contains(val) Then
                    autoCompleteSource.Add(val)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdChitietyeucau_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChitietyeucau.CellValidated
        If BtnTrove.Focused() Then
            Exit Sub
        Else
            If grdChitietyeucau.Columns(e.ColumnIndex).Name = "cboMS_MAY" Then
                If IsDBNull(grdChitietyeucau.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    grdChitietyeucau.CurrentCell() = grdChitietyeucau.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdChitietyeucau.Focus()
                    Exit Sub
                End If
            ElseIf grdChitietyeucau.Columns(e.ColumnIndex).Name = "cboNHANVIEN" Then
                If IsDBNull(grdChitietyeucau.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    grdChitietyeucau.CurrentCell() = grdChitietyeucau.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdChitietyeucau.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                    grdChitietyeucau.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub grdChitietyeucau_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdChitietyeucau.DataError
        If e.RowIndex < grdChitietyeucau.Rows.Count - 1 Then
            If e.Context = DataGridViewDataErrorContexts.Commit Then
                'If grdChitietyeucau.Rows(e.RowIndex).Cells("MO_TA_TINH_TRANG").Value.ToString = "" Then
                '    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "MsgNoData1", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                '    grdChitietyeucau.Rows(e.RowIndex).Cells("MO_TA_TINH_TRANG").Selected = True
                '    grdChitietyeucau.Focus()
                '    e.Cancel = True
                '    Exit Sub
                'Else
                If grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Value.ToString = "" Then
                    grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Selected = True

                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grdChitietyeucau_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles grdChitietyeucau.DataSourceChanged
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            Me.autoCompleteSource.Clear()
            Dim r As DataGridViewRow
            If dgv.CurrentCell.OwningColumn.Name = "cboMS_MAY" Then
                For Each r In dgv.Rows
                    Dim val As String = r.Cells("cboMS_MAY").Value
                    If Not String.IsNullOrEmpty(val) AndAlso _
                        Not Me.autoCompleteSource.Contains(val) Then
                        autoCompleteSource.Add(val)
                    End If
                Next r
            ElseIf dgv.CurrentCell.OwningColumn.Name = "cboNHANVIEN" Then
                For Each r In dgv.Rows
                    Dim val As String = r.Cells("cboNHANVIEN").Value
                    If Not String.IsNullOrEmpty(val) AndAlso _
                        Not Me.autoCompleteSource.Contains(val) Then
                        autoCompleteSource.Add(val)
                    End If
                Next r
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdChitietyeucau_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdChitietyeucau.DefaultValuesNeeded
        e.Row.Cells("STT").Value = intSTT
    End Sub
    Dim autoCompleteSource As New AutoCompleteStringCollection()
    Private Sub grdChitietyeucau_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) 'Handles grdChitietyeucau.EditingControlShowing
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If TypeOf e.Control Is System.Windows.Forms.ComboBox Then
            Dim tb As System.Windows.Forms.ComboBox = CType(e.Control, System.Windows.Forms.ComboBox)
            If dgv.CurrentCell.OwningColumn.Name = "cboMS_MAY" Or dgv.CurrentCell.OwningColumn.Name = "cboNHANVIEN" Then
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                tb.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
                tb.AutoCompleteCustomSource = Me.autoCompleteSource
                tb.DropDownStyle = ComboBoxStyle.DropDown
            Else
                tb.AutoCompleteMode = AutoCompleteMode.None
            End If
        End If
    End Sub

    Private Sub grdChitietyeucau_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdChitietyeucau.KeyDown
        If e.KeyCode = Keys.Escape Then
            If grdChitietyeucau.RowCount > 1 Then
                If grdChitietyeucau.RowCount - 1 > rowCount And Not grdChitietyeucau.CurrentRow.IsNewRow Then
                    grdChitietyeucau.Rows.RemoveAt(Me.grdChitietyeucau.CurrentRow.Index)
                End If
            Else
                ShowChichitietyeucau(intSTT)
            End If
        End If
    End Sub

    Private Sub grdChitietyeucau_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdChitietyeucau.RowEnter
        If BtnGhi.Visible Then
            grdHinh.AllowUserToAddRows = False
        Else
            grdHinh.AllowUserToAddRows = True
        End If
        intRowchon = e.RowIndex
        intSTT_VAN_DE = grdChitietyeucau.Rows(e.RowIndex).Cells("STT_VAN_DE").Value
        Try
            strMS_MAY = IIf(IsDBNull(grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Value), System.String.Empty, grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Value)
        Catch ex As Exception
            'If e.RowIndex < grdChitietyeucau.Rows.Count - 2 Then
            '    strMS_MAY = grdChitietyeucau.Rows(e.RowIndex).Cells("MS_MAY").Value
            'End If
        End Try

        ShowHinh(intSTT, strMS_MAY, intSTT_VAN_DE, e.RowIndex)
        grdHinh.Columns("DUONG_DAN").ReadOnly = True

    End Sub

    Private Sub grdChitietyeucau_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdChitietyeucau.RowHeaderMouseClick
        intRowchon = e.RowIndex
        intSTT_VAN_DE = grdChitietyeucau.Rows(e.RowIndex).Cells("STT_VAN_DE").Value
        strMS_MAY = IIf(IsDBNull(grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Value), System.String.Empty, grdChitietyeucau.Rows(e.RowIndex).Cells("cboMS_MAY").Value)
        ShowHinh(intSTT, strMS_MAY, intSTT_VAN_DE, e.RowIndex)

    End Sub
#End Region
#Region "private"
    Function isValidated() As Boolean
        If Not txtNguoiyeucau.IsValidated Then
            Return False
        End If
        Return True
    End Function
    Sub SetTabYeucau(ByVal intTab As Byte)
        TabYeucau.SelectedIndex = intTab
    End Sub
    Sub LockData(ByVal chon As Boolean)
        txtNgayyeucau.ReadOnly = True
        dtNgayyeucau.Enabled = False
        txtNguoiyeucau.ReadOnly = True
        txtGioyeucau.ReadOnly = True
        txtNguoiyeucau.ReadOnly = True
        txtNgayhoanthanh.ReadOnly = True
        dtNgayhoanthanh.Enabled = False
        rtxtUsercomment.ReadOnly = False
        grdChitietyeucau.ReadOnly = True

    End Sub
    Sub LockData2(ByVal chon As Boolean)
        rtxtReviewer.ReadOnly = chon
    End Sub
    Sub LockData3(ByVal chon As Boolean)
        rtxtUsercomment.ReadOnly = chon
    End Sub
    Sub LockData1(ByVal chon As Boolean)
        chkNguoiduyet.Enabled = chon
    End Sub
    Function AddYeucau() As Boolean
        Dim objYEU_CAU_NSDInfo As New YEU_CAU_NSDInfo()
        objYEU_CAU_NSDInfo.NGAY = txtNgayyeucau.Text
        objYEU_CAU_NSDInfo.GIO_YEU_CAU = txtGioyeucau.Text
        objYEU_CAU_NSDInfo.NGUOI_YEU_CAU = txtNguoiyeucau.Text.Trim().ToString() 'Commons.Modules.ObjSystems.SplitString(txtNguoiyeucau.Text)
        objYEU_CAU_NSDInfo.HOAN_THANH = txtNgayhoanthanh.Text
        objYEU_CAU_NSDInfo.USER_COMMENT = rtxtUsercomment.Text
        objYEU_CAU_NSDInfo.DA_KIEM_TRA = chkNguoiduyet.Checked
        objYEU_CAU_NSDInfo.USERNAME = txtUsername.Text
        objYEU_CAU_NSDInfo.REVIEWER_COMMENT = rtxtReviewer.Text
        objYEU_CAU_NSDInfo.USER_LAP = txtNguoiLap.Text.Trim
        Dim objYC_CTInfo As New YEU_CAU_NSD_CHI_TIETInfo()
        Dim objYC_CTController As New clsYEU_CAU_NSD_CHI_TIETController()
        Dim str As String = ""
        If blnThem = 1 Then
            Dim objYEU_CAU_NSDController As New clsYEU_CAU_NSDController()
            intSTT = objYEU_CAU_NSDController.AddYEU_CAU_NSD(objYEU_CAU_NSDInfo)
            'intSTT = New clsYEU_CAU_NSDController().getSTT_YC_NSD()
            Dim tam As Integer = 0
            While tam < grdChitietyeucau.Rows.Count - 1
                objYC_CTInfo.STT = intSTT
                objYC_CTInfo.MS_MAY = grdChitietyeucau.Rows(tam).Cells("cboMS_MAY").Value
                objYC_CTInfo.YEU_CAU = grdChitietyeucau.Rows(tam).Cells("YEU_CAU").Value.ToString()
                objYC_CTInfo.MO_TA_TINH_TRANG = grdChitietyeucau.Rows(tam).Cells("MO_TA_TINH_TRANG").Value.ToString()
                objYC_CTInfo.NGUOI_XAC_NHAN = grdChitietyeucau.Rows(tam).Cells("NGUOI_XAC_NHAN").Value.ToString()
                objYC_CTInfo.NOI_DUNG_XAC_NHAN = grdChitietyeucau.Rows(tam).Cells("NOI_DUNG_XAC_NHAN").Value.ToString()
                objYC_CTInfo.UU_TIEN = grdChitietyeucau.Rows(tam).Cells("cboMUC_UU_TIEN").Value.ToString()
                objYC_CTController.AddYEU_CAU_NSD_CHI_TIET(objYC_CTInfo)
                'intSTT_VAN_DE = objYC_CTController.getSTT_VAN_DE_YC_NSD()              
                tam = tam + 1
            End While
        Else
            'trường hợp cập nhật thông tin yêu cầu
            If blnThem = 2 Then
                objYEU_CAU_NSDInfo.STT = intSTT
                Dim objYEU_CAU_NSDController As New clsYEU_CAU_NSDController()
                objYEU_CAU_NSDController.UpdateYEU_CAU_NSD(objYEU_CAU_NSDInfo)
                Dim tmp As Integer = 0
                While tmp < grdChitietyeucau.Rows.Count
                    objYC_CTInfo.STT = intSTT
                    objYC_CTInfo.MS_MAY = grdChitietyeucau.Rows(tmp).Cells("cboMS_MAY").Value.ToString()
                    objYC_CTInfo.YEU_CAU = grdChitietyeucau.Rows(tmp).Cells("YEU_CAU").Value.ToString()
                    objYC_CTInfo.MO_TA_TINH_TRANG = grdChitietyeucau.Rows(tmp).Cells("MO_TA_TINH_TRANG").Value.ToString()
                    objYC_CTInfo.NGUOI_XAC_NHAN = grdChitietyeucau.Rows(tmp).Cells("NGUOI_XAC_NHAN").Value.ToString()
                    objYC_CTInfo.NOI_DUNG_XAC_NHAN = grdChitietyeucau.Rows(tmp).Cells("NOI_DUNG_XAC_NHAN").Value.ToString()
                    objYC_CTInfo.UU_TIEN = grdChitietyeucau.Rows(tmp).Cells("cboMUC_UU_TIEN").Value.ToString()
                    If tmp <= intChiTiet Then
                        'update trường hợp thay đổi yêu cầu
                        objYC_CTInfo.STT_VAN_DE = grdChitietyeucau.Rows(tmp).Cells("STT_VAN_DE").Value.ToString()
                        Try
                            objYC_CTInfo.MS_MAY_TMP = ArrChiTiet(tmp).ToString
                        Catch ex As Exception
                            objYC_CTInfo.MS_MAY_TMP = ArrChiTiet(tmp - 1).ToString
                        End Try
                        objYC_CTController.UpdateYEU_CAU_NSD_CHI_TIET(objYC_CTInfo)
                    Else
                        'trường hợp chọn sửa nhưng trong sửa có thêm chi tiết yêu cầu mới 
                        objYC_CTController.AddYEU_CAU_NSD_CHI_TIET(objYC_CTInfo)
                        intSTT_VAN_DE = objYC_CTController.getSTT_VAN_DE_YC_NSD()
                    End If
                    tmp = tmp + 1
                End While
            End If
        End If
        Return True
    End Function
    Sub Refesh()
        txtNgayyeucau.Text = ""
        txtNgayhoanthanh.Text = ""
        txtNguoiyeucau.Text = ""
        txtGioyeucau.Text = ""
        rtxtUsercomment.Text = ""
        chkNguoiduyet.Checked = False
        txtUsername.Text = ""
        rtxtReviewer.Text = ""
        intSTT = -1
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)

        'BtnThem.Visible = blnVisible
        'BtnXoa.Visible = blnVisible
        'BtnSua.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        'BtnKhongghi.Visible = Not blnVisible
        If grdDanhsachyeucau.Rows.Count = 0 And blnVisible Then
            'BtnXoa.Enabled = False
            'BtnSua.Enabled = False
        Else
            'BtnXoa.Enabled = True
            'BtnSua.Enabled = True
        End If
        If TabYeucau.SelectedTab.Name = "TabChitietyeucau" And blnVisible Then
            btnXemHinh.Visible = True
        Else
            btnXemHinh.Visible = False
        End If
        BtnThoat.Visible = blnVisible
        grdChitietyeucau.AllowUserToAddRows = Not blnVisible

        grdHinh.AllowUserToAddRows = True
        'grdHinh.ReadOnly = Not blnVisible
        cboTennguoiYC.Enabled = blnVisible
        dtTungay.Enabled = blnVisible
        dtDenngay.Enabled = blnVisible
        Try
            grdHinh.Columns("DUONG_DAN").ReadOnly = True
            grdHinh.Columns("GHI_CHU").ReadOnly = Not blnVisible
        Catch ex As Exception
        End Try

        'BtnThem.Visible = False
        'BtnXoa.Visible = False
        'BtnSua.Visible = False
        'BtnKhongghi.Visible = False

    End Sub
    Sub VisibleButtonGhi(ByVal blnVisible As Boolean)
        BtnGhi.Visible = blnVisible
        'BtnKhongghi.Visible = blnVisible
        grdHinh.AllowUserToAddRows = Not blnVisible
        'grdDanhsachyeucau.Enabled = blnVisible
        'grdChitietyeucau.AllowUserToAddRows = Not blnVisible
        'BtnHinh.Visible = blnVisible
    End Sub
    Sub VisibleButtonXoa(ByVal blnVisible As Boolean)
        'BtnXoahinh.Visible = blnVisible
        'BtnXoaCTyeucau.Visible = blnVisible
        'BtnXoaYC.Visible = blnVisible
        grdDanhsachyeucau.AllowUserToAddRows = False
        grdChitietyeucau.AllowUserToAddRows = False
        'grdHinh.AllowUserToAddRows = False
        'If TabYeucau.SelectedIndex = 0 Then
        '    BtnXoaYC.Enabled = True
        '    BtnXoahinh.Enabled = False
        '    BtnXoaCTyeucau.Enabled = False
        'Else
        '    BtnXoaYC.Enabled = False
        '    BtnXoahinh.Enabled = True
        '    BtnXoaCTyeucau.Enabled = True
        'End If
    End Sub
    Private Sub RefeshLanguage()
        Try

            Me.grdDanhsachyeucau.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            Me.grdDanhsachyeucau.Columns("GIO_YEU_CAU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GIO_YEU_CAU", Commons.Modules.TypeLanguage)
            Me.grdDanhsachyeucau.Columns("GIO_YEU_CAU").DefaultCellStyle.Format = "HH:mm"
            Me.grdDanhsachyeucau.Columns("NGUOI_YEU_CAU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_YEU_CAU", Commons.Modules.TypeLanguage)
            Me.grdDanhsachyeucau.Columns("NGAY_HOAN_THANH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_HOAN_THANH", Commons.Modules.TypeLanguage)
            Me.grdDanhsachyeucau.Columns("NGAY_XU_LY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY_XU_LY", Commons.Modules.TypeLanguage)
        Catch ex As Exception

        End Try

    End Sub
    Sub LoadMS_MAY()
        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        comboBoxColumn.AutoComplete = True
        comboBoxColumn.Name = "cboMS_MAY"
        comboBoxColumn.ValueMember = "MS_MAY"
        comboBoxColumn.DisplayMember = "MS_MAY"
        comboBoxColumn.DataPropertyName = "MS_MAY"
        comboBoxColumn.DataSource = New MAYController().GetMAY_PQ(Commons.Modules.UserName) 'Commons.Modules.UserName
        grdChitietyeucau.Columns.Insert(0, comboBoxColumn)
    End Sub

    Sub LoadcboTennguoiyeucau()
        cboTennguoiYC.StoreName = "GetNGUOI_YEU_CAUs"
        cboTennguoiYC.Value = "NGUOI_YEU_CAU"
        cboTennguoiYC.Display = "HO_TEN"
        cboTennguoiYC.BindDataSource()

    End Sub
    Sub LoadDanhsachyeucau1()
        Try
            Dim obj As New Commons.clsprintnhanvien
            Dim dt As New DataTable

            dt = New clsYEU_CAU_NSD_CHI_TIETController().getYEU_CAU_NSD_CHI_TIET(intSTT)
            If dt.Rows.Count > 0 Then
                If cboTennguoiYC.SelectedValue = "-1" Then
                    grdDanhsachyeucau.DataSource = New clsYEU_CAU_NSDController().GetYEU_CAU_NSD("", Format(dtTungay.Value, "Short date"), Format(dtDenngay.Value, "Short date"), Commons.Modules.UserName)
                Else
                    grdDanhsachyeucau.DataSource = New clsYEU_CAU_NSDController().GetYEU_CAU_NSD(cboTennguoiYC.SelectedValue, dtTungay.Value, dtDenngay.Value, Commons.Modules.UserName)
                End If
            Else
                grdChitietyeucau.DataSource = obj.CheckYeucauNSD(1.7666)
            End If

            grdDanhsachyeucau.Columns("STT").Visible = False
            Try
                Me.grdDanhsachyeucau.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdDanhsachyeucau.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try
            grdDanhsachyeucau.Columns("NGAY").Width = 120
            grdDanhsachyeucau.Columns("GIO_YEU_CAU").Width = 120
            grdDanhsachyeucau.Columns("NGUOI_YEU_CAU").Width = 170
            grdDanhsachyeucau.Columns("USER_COMMENT").Visible = False
            grdDanhsachyeucau.Columns("DA_KIEM_TRA").Visible = False
            grdDanhsachyeucau.Columns("USERNAME").Visible = False
            grdDanhsachyeucau.Columns("REVIEWER_COMMENT").Visible = False
            'If BtnThem.Enabled Then
            '    If grdDanhsachyeucau.RowCount > 0 Then
            '        BtnSua.Enabled = True
            '        BtnXoa.Enabled = True
            '    Else
            '        BtnSua.Enabled = False
            '        BtnXoa.Enabled = False
            '    End If
            'End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        'If Commons.Modules.PermisString.Equals("Read only") Then
        '    EnableButton(False)
        'End If
    End Sub
    Sub LoadDanhsachyeucau()
        Try
            Dim vtbData As New DataTable

            If cboTennguoiYC.SelectedValue = "-1" Then
                vtbData = New clsYEU_CAU_NSDController().GetYEU_CAU_NSD("", Format(dtTungay.Value, "Short date"), Format(dtDenngay.Value, "Short date"), Commons.Modules.UserName)
                grdDanhsachyeucau.DataSource = vtbData
            Else
                vtbData = New clsYEU_CAU_NSDController().GetYEU_CAU_NSD(cboTennguoiYC.SelectedValue, dtTungay.Value, dtDenngay.Value, Commons.Modules.UserName)
                grdDanhsachyeucau.DataSource = vtbData
            End If

            grdDanhsachyeucau.Columns("STT").Visible = False
            Try
                Me.grdDanhsachyeucau.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdDanhsachyeucau.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try
            grdDanhsachyeucau.Columns("NGAY").Width = 120
            grdDanhsachyeucau.Columns("GIO_YEU_CAU").Width = 120
            grdDanhsachyeucau.Columns("NGUOI_YEU_CAU").Width = 170
            grdDanhsachyeucau.Columns("USER_COMMENT").Visible = False
            grdDanhsachyeucau.Columns("DA_KIEM_TRA").Visible = False
            grdDanhsachyeucau.Columns("USERNAME").Visible = False

            txtNguoiLap.DataBindings.Clear()
            txtNguoiLap.DataBindings.Add("Text", vtbData, "USER_LAP", True, DataSourceUpdateMode.OnPropertyChanged, "")
            txtNguoiLap.ReadOnly = True

            grdDanhsachyeucau.Columns("REVIEWER_COMMENT").Visible = False
            'If BtnThem.Enabled Then
            '    If grdDanhsachyeucau.RowCount > 0 Then
            '        BtnSua.Enabled = True
            '        BtnXoa.Enabled = True
            '    Else
            '        BtnSua.Enabled = False
            '        BtnXoa.Enabled = False
            '    End If
            'End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        'If Commons.Modules.PermisString.Equals("Read only") Then
        '    EnableButton(False)
        'End If
    End Sub
    Sub ShowData(ByVal intdong As Integer)
        If grdDanhsachyeucau.Rows.Count > 0 Then
            Dim Ngaygio As New DateTime

            txtNgayyeucau.Text = grdDanhsachyeucau.Rows(intdong).Cells("NGAY").Value
            'Ngaygio = Convert.ToDateTime(grdDanhsachyeucau.Rows(intdong).Cells("GIO_YEU_CAU").Value)
            'txtGioyeucau.Text = Ngaygio.Hour & ":" & Ngaygio.Minute
            txtGioyeucau.Text = Format(grdDanhsachyeucau.Rows(intdong).Cells("GIO_YEU_CAU").Value, "long time")
            'txtGioyeucau.Text = Format(Now(), "HH:mm")
            txtNguoiyeucau.Text = grdDanhsachyeucau.Rows(intdong).Cells("NGUOI_YEU_CAU").Value
            rtxtUsercomment.Text = grdDanhsachyeucau.Rows(intdong).Cells("USER_COMMENT").Value.ToString
            txtUsername.Text = grdDanhsachyeucau.Rows(intdong).Cells("USERNAME").Value.ToString

            If grdDanhsachyeucau.Rows(intdong).Cells("USERNAME").Value.ToString() = "" Then
                chkNguoiduyet.Text = "Check"
                chkNguoiduyet.Checked = False
            Else
                If grdDanhsachyeucau.Rows(intdong).Cells("DA_KIEM_TRA").Value Then
                    chkNguoiduyet.Text = "Checked"
                    chkNguoiduyet.Checked = grdDanhsachyeucau.Rows(intdong).Cells("DA_KIEM_TRA").Value
                Else
                    chkNguoiduyet.Text = "UnChecked"
                    chkNguoiduyet.Checked = grdDanhsachyeucau.Rows(intdong).Cells("DA_KIEM_TRA").Value
                End If
            End If

            rtxtReviewer.Text = grdDanhsachyeucau.Rows(intdong).Cells("REVIEWER_COMMENT").Value.ToString
            If IsDBNull(grdDanhsachyeucau.Rows(intdong).Cells("NGAY_HOAN_THANH").Value) Then
                txtNgayhoanthanh.Text = ""
            Else
                txtNgayhoanthanh.Text = grdDanhsachyeucau.Rows(intdong).Cells("NGAY_HOAN_THANH").Value
            End If
            intSTT = grdDanhsachyeucau.Rows(intdong).Cells("STT").Value
        End If
    End Sub
    Dim rowCount As Integer = 0
    Sub ShowChichitietyeucau(ByVal STT As Integer)
        Try

            Dim vtb As New DataTable
            vtb = New clsYEU_CAU_NSD_CHI_TIETController().getYEU_CAU_NSD_CHI_TIET(STT)
            vtb.Columns("MS_UU_TIEN").AllowDBNull = True

            grdChitietyeucau.DataSource = vtb

            rowCount = grdChitietyeucau.Rows.Count - 2
            If flage Then
                LoadMS_MAY()
                LoadNhanVien()
                LoadMucUuTien()
                flage = False
            End If

            grdChitietyeucau.ReadOnly = True
            grdChitietyeucau.Columns("STT").Visible = False
            grdChitietyeucau.Columns("STT_VAN_DE").Visible = False
            grdChitietyeucau.Columns("MS_MAY").Visible = False
            grdChitietyeucau.Columns("NGUOI_XAC_NHAN").Visible = False
            grdChitietyeucau.Columns("TEN_MAY").DisplayIndex = 1
            grdChitietyeucau.Columns("MS_UU_TIEN").Visible = False
            'grdChitietyeucau.Columns("TEN_UU_TIEN").Visible = False

            ' grdChitietyeucau.Columns("MO_TA_TINH_TRANG").DefaultCellStyle.M  

            intChiTiet = grdChitietyeucau.Rows.Count - 2
            For j As Integer = 0 To ArrChiTiet.Count - 1
                ArrChiTiet.RemoveAt(j)
            Next
            For i As Integer = 0 To intChiTiet
                ArrChiTiet.Add(grdChitietyeucau.Rows(i).Cells("MS_MAY").Value)
            Next
            Try
                Me.grdChitietyeucau.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
                Me.grdChitietyeucau.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
            Catch ex As Exception
            End Try

            'Try
            '    If grdChitietyeucau.Rows.Count > 1 Then
            '        grdChitietyeucau.Rows(0).Selected = True
            '        'grdChitietyeucau.Focus()
            '    End If

            'Catch ex As Exception
            'End Try
            Me.grdChitietyeucau.Columns("cboMS_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "cboMS_MAY", Commons.Modules.TypeLanguage)
            Me.grdChitietyeucau.Columns("MO_TA_TINH_TRANG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MO_TA_TINH_TRANG", Commons.Modules.TypeLanguage)
            Me.grdChitietyeucau.Columns("YEU_CAU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "YEU_CAU", Commons.Modules.TypeLanguage)
            Me.grdChitietyeucau.Columns("cboNHANVIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_XAC_NHAN", Commons.Modules.TypeLanguage)
            Me.grdChitietyeucau.Columns("NOI_DUNG_XAC_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NOI_DUNG_XAC_NHAN", Commons.Modules.TypeLanguage)

            Me.grdChitietyeucau.Columns("TEN_MAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_MAY", Commons.Modules.TypeLanguage)
            Me.grdChitietyeucau.Columns("cboMUC_UU_TIEN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MUC_UU_TIEN", Commons.Modules.TypeLanguage)



            grdChitietyeucau.Columns("cboMS_MAY").Width = 150
            grdChitietyeucau.Columns("TEN_MAY").Width = 250

            grdChitietyeucau.Columns("MO_TA_TINH_TRANG").Width = 300
            grdChitietyeucau.Columns("YEU_CAU").Width = 200
            grdChitietyeucau.Columns("cboNHANVIEN").Width = 130
            grdChitietyeucau.Columns("NOI_DUNG_XAC_NHAN").Width = 200
            'grdChitietyeucau.Columns("NGUOI_XAC_NHAN").ReadOnly = True
            'grdChitietyeucau.Columns("NOI_DUNG_XAC_NHAN").ReadOnly = True
            If grdChitietyeucau.Rows.Count = 0 Then
                grdHinh.AllowUserToAddRows = False
            Else
                grdHinh.AllowUserToAddRows = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadNhanVien()

        Dim cboColumn = New Commons.QLGridComboBoxColumn()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs1"))
        Dim row As DataRow
        row = dtTable.NewRow()
        row("MS_CONG_NHAN") = "1"
        row("HO_TEN_CONG_NHAN") = " "
        dtTable.Rows.Add(row)
        cboColumn.AutoComplete = True
        cboColumn.Name = "cboNHANVIEN"
        cboColumn.ValueMember = "MS_CONG_NHAN"
        cboColumn.DisplayMember = "HO_TEN_CONG_NHAN"
        cboColumn.DataPropertyName = "NGUOI_XAC_NHAN"
        cboColumn.DataSource = dtTable
        grdChitietyeucau.Columns.Insert(5, cboColumn)
    End Sub

    Sub LoadMucUuTien()
        Dim cboColumn = New Commons.QLGridComboBoxColumn()
        Dim dtTable As New DataTable
        dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_YEU_CAU_NSD_MUC_UU_TIEN"))
        cboColumn.AutoComplete = True
        cboColumn.Name = "cboMUC_UU_TIEN"
        cboColumn.ValueMember = "MS_UU_TIEN"
        cboColumn.DisplayMember = "TEN_UU_TIEN"
        cboColumn.DataPropertyName = "MS_UU_TIEN"
        cboColumn.DataSource = dtTable
        grdChitietyeucau.Columns.Add(cboColumn)
    End Sub

    Sub ShowHinh(ByVal intSTT As Integer, ByVal strMS_MAY As String, ByVal intSTT_VAN_DE As Integer, ByVal intRow As Integer)

        grdHinh.DataSource = New clsYEU_CAU_NSD_CHI_TIET_HINHController().GetYEU_CAU_NSD_CHI_TIET_HINHs(intSTT, strMS_MAY, intSTT_VAN_DE)
        Try
            Me.grdHinh.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdHinh.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception
        End Try

        grdHinh.Columns("STT").Visible = False
        grdHinh.Columns("STT_VAN_DE").Visible = False
        grdHinh.Columns("MS_MAY").Visible = False
        grdHinh.Columns("STT_HINH").Visible = False
        Me.grdHinh.Columns("HINH").Visible = False
        Me.grdHinh.Columns("DUONG_DAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DUONG_DAN", Commons.Modules.TypeLanguage)
        Me.grdHinh.Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
    End Sub
#End Region
    Sub grdHinh_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) 'Handles grdHinh.CellMouseDoubleClick
        If blnThem = 0 And grdChitietyeucau.Rows.Count > 0 Then
            If e.ColumnIndex = 4 Then
                ofdDuongdan.Multiselect = True
                ofdDuongdan.ShowDialog()
            End If
        End If
    End Sub

    Sub LayDuongDan()
        Dim FILE_PATHs As String()
        FILE_PATHs = ofdDuongdan.FileNames()
        strDUONG_DAN_HINH_YEU_CAU_NSD = Commons.Modules.ObjSystems.CapnhatTL(False, strMS_MAY)
        Dim str As String = ""
        str = "SELECT TOP 1 DUONG_DAN FROM YEU_CAU_NSD_CHI_TIET_HINH WHERE  MS_MAY=N'" & strMS_MAY & "' ORDER BY STT_HINH DESC"
        Dim stt As Integer = Commons.Modules.ObjSystems.LaySTTChoTaiLieu(str)
        For i As Integer = 0 To FILE_PATHs.Length - 1
            Dim NEW_FILE_PATH As String
            NEW_FILE_PATH = strDUONG_DAN_HINH_YEU_CAU_NSD & "\" & "YCNSD" & "_" & strMS_MAY & "_" & Day(Now()) & Month(Now()) & Year(Now()) & "_" & stt & Commons.Modules.ObjSystems.LayDuoiFile(FILE_PATHs(i))
            Commons.Modules.ObjSystems.LuuDuongDan(FILE_PATHs(i), NEW_FILE_PATH)
            Dim objHinhInfo As New clsYEU_CAU_NSD_CHI_TIET_HINHInfo()
            objHinhInfo.STT = intSTT
            objHinhInfo.MS_MAY = strMS_MAY
            objHinhInfo.STT_VAN_DE = intSTT_VAN_DE
            objHinhInfo.DUONG_DAN = NEW_FILE_PATH
            objHinhInfo.GHI_CHU = ""
            Dim objHinhController As New clsYEU_CAU_NSD_CHI_TIET_HINHController()
            objHinhController.AddYEU_CAU_NSD_CHI_TIET_HINH(objHinhInfo)
            stt = stt + 1
        Next
        grdHinh.DataSource = New clsYEU_CAU_NSD_CHI_TIET_HINHController().GetYEU_CAU_NSD_CHI_TIET_HINHs(intSTT, strMS_MAY, intSTT_VAN_DE)
    End Sub

    Private Sub grdHinh_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) ' Handles grdHinh.CellValidating
        If blnThem = 0 And grdChitietyeucau.Rows.Count > 0 Then '
            If e.ColumnIndex = 5 Then
                Dim objHinhInfo As New clsYEU_CAU_NSD_CHI_TIET_HINHInfo()
                objHinhInfo.STT = intSTT
                objHinhInfo.MS_MAY = strMS_MAY
                objHinhInfo.STT_VAN_DE = intSTT_VAN_DE
                objHinhInfo.STT_HINH = intSTT_HINH
                objHinhInfo.DUONG_DAN = ""
                objHinhInfo.GHI_CHU = e.FormattedValue
                Dim objHinhController As New clsYEU_CAU_NSD_CHI_TIET_HINHController()
                objHinhController.UpdateYEU_CAU_NSD_CHI_TIET_HINH_GHI_CHU(objHinhInfo)
                'grdHinh.DataSource = New clsYEU_CAU_NSD_CHI_TIET_HINHController().GetYEU_CAU_NSD_CHI_TIET_HINHs(intSTT, strMS_MAY, intSTT_VAN_DE)
            End If

        End If

    End Sub

    Private Sub grdHinh_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdHinh.CellBeginEdit
        If e.ColumnIndex = 5 And blnThem = 0 Then
            If grdHinh.Rows.Count > 1 And Not IsDBNull(grdHinh.Rows(e.RowIndex).Cells("DUONG_DAN").Value) Then
                grdHinh.Columns("GHI_CHU").ReadOnly = False
                Exit Sub
            Else
                grdHinh.Columns("GHI_CHU").ReadOnly = True
                e.Cancel = True
            End If
        Else
            grdHinh.Columns("GHI_CHU").ReadOnly = True
            e.Cancel = True
        End If

    End Sub

    Private Sub grdHinh_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdHinh.CellMouseDown
        'If e.ColumnIndex = 5 And blnThem = 0 Then
        '    If grdHinh.Rows.Count = 1 Then
        '        grdHinh.Columns("GHI_CHU").ReadOnly = True
        '    Else
        '        grdHinh.Columns("GHI_CHU").ReadOnly = False
        '    End If
        'End If
    End Sub



    Private Sub grdHinh_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdHinh.DefaultValuesNeeded
        e.Row.Cells("STT").Value = intSTT
        e.Row.Cells("MS_MAY").Value = strMS_MAY
        e.Row.Cells("STT_VAN_DE").Value = intSTT_VAN_DE
    End Sub

    Private Sub ofdDuongdan_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdDuongdan.FileOk
        LayDuongDan()
    End Sub


    Private Sub grdChitietyeucau_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) 'Handles grdChitietyeucau.RowValidating
        Me.KeyPreview = True
        'If Me.ProcessMnemonic("K") Then
        '    XtraMessageBox.Show("fgdfg")
        'End If       
        If e.RowIndex < grdChitietyeucau.Rows.Count - 1 Then
            Try
                If Not BtnGhi.Focused() Then
                    If grdChitietyeucau.Rows(e.RowIndex).Cells("MO_TA_TINH_TRANG").Value.ToString = "" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdChitietyeucau.Rows(e.RowIndex).Cells("MO_TA_TINH_TRANG").Selected = True
                        grdChitietyeucau.Focus()
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    If grdChitietyeucau.Rows(e.RowIndex).Cells("MO_TA_TINH_TRANG").Value.ToString = "" Then
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData1", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        grdChitietyeucau.Rows(e.RowIndex).Cells("MO_TA_TINH_TRANG").Selected = True
                        grdChitietyeucau.Focus()
                        Exit Sub
                    End If
                End If
            Catch ex As Exception

            End Try

        End If
        'BtnGhi.UseMnemonic = True
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ofdDuongdan.Multiselect = True
        ofdDuongdan.ShowDialog()

    End Sub

    Private Sub BtnXoaCTyeucau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grdChitietyeucau.RowCount <= 0 Then
            'thông báo không có d? li?u d? xóa
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        Else
            ' xóa chi tiêt cả thông tin hình 
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                For i As Integer = 0 To grdHinh.Rows.Count - 1
                    Commons.Modules.ObjSystems.Xoahinh(grdHinh.Rows(i).Cells("DUONG_DAN").Value)
                Next
                Dim dong As Integer = grdChitietyeucau.Rows.Count - 1
                Dim objYC_CTController As New clsYEU_CAU_NSD_CHI_TIETController()
                objYC_CTController.DeleteYEU_CAU_NSD_CHI_TIET(intSTT, grdChitietyeucau.Rows(intRowchon).Cells("MS_MAY").Value, grdChitietyeucau.Rows(intRowchon).Cells("STT_VAN_DE").Value)
                grdHinh.DataSource = System.DBNull.Value
                If dong = 0 Then
                    LoadDanhsachyeucau1()
                    LoadcboTennguoiyeucau()
                    If grdDanhsachyeucau.RowCount = 0 Then
                        Refesh()
                        ShowChichitietyeucau(0)
                    End If
                Else

                    Dim tmp As Integer = intRowchon
                    ShowChichitietyeucau(intSTT)
                    If grdChitietyeucau.Rows.Count > 0 Then
                        If grdChitietyeucau.Rows.Count = tmp Then
                            grdChitietyeucau.CurrentCell() = grdChitietyeucau.Rows(tmp - 1).Cells("cboMS_MAY")
                            grdChitietyeucau.Focus()
                        Else
                            grdChitietyeucau.CurrentCell() = grdChitietyeucau.Rows(tmp).Cells("cboMS_MAY")
                            grdChitietyeucau.Focus()
                        End If
                    End If
                End If

                SetTabYeucau(1)
            End If
        End If

        If grdChitietyeucau.RowCount = 0 Then
            txtUsername.Text = ""
            rtxtReviewer.Text = ""
            rtxtUsercomment.Text = ""
        End If
    End Sub

    Private Sub BtnXoaYC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grdDanhsachyeucau.RowCount <= 0 Then
            'thông báo không có d? li?u d? xóa
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        Else
            'B?n có mu?n xóa toàn b? thông tin ngu?i yêu c?u không? N?u có nh?n "Yes", n?u mu?n xoá chi ti?t yêu c?u nh?n "No".
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkCancel + MsgBoxStyle.Information, Me.Text)
            Dim tmp As New DataTable()
            If Traloi = 1 Then
                For i As Integer = 0 To grdChitietyeucau.Rows.Count - 1
                    tmp = New clsYEU_CAU_NSD_CHI_TIET_HINHController().GetYEU_CAU_NSD_CHI_TIET_HINHs(grdChitietyeucau.Rows(i).Cells("STT").Value, grdChitietyeucau.Rows(i).Cells("MS_MAY").Value, grdChitietyeucau.Rows(i).Cells("STT_VAN_DE").Value)
                    For j As Integer = 0 To tmp.Rows.Count - 1
                        Commons.Modules.ObjSystems.Xoahinh(tmp.Rows(j).Item("DUONG_DAN"))
                    Next
                Next
                Dim tmp1 As Integer = intRowDS
                Dim objYC_NSDController As New clsYEU_CAU_NSDController()
                objYC_NSDController.DeleteYEU_CAU_NSD(intSTT)
                grdHinh.DataSource = System.DBNull.Value
                LoadDanhsachyeucau()
                LoadcboTennguoiyeucau()
                If grdDanhsachyeucau.RowCount = 0 Then
                    Refesh()
                End If
                SetTabYeucau(0)
                If grdDanhsachyeucau.Rows.Count > 0 Then
                    If tmp1 > 0 Then
                        grdDanhsachyeucau.CurrentCell() = grdDanhsachyeucau.Rows(tmp1 - 1).Cells("NGAY")
                        grdDanhsachyeucau.Focus()
                    Else
                        grdDanhsachyeucau.CurrentCell() = grdDanhsachyeucau.Rows(tmp1).Cells("NGAY")
                        grdDanhsachyeucau.Focus()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub BtnXoahinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grdHinh.RowCount <= 1 Then
            'thông báo không có d? li?u d? xóa
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgNoData", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
        Else
            Dim str As String = ""
            str = "SELECT STT_YC_NSD FROM EOR_REFFERENCE WHERE STT_YC_NSD=" & grdHinh.Rows(row).Cells("STT_HINH").Value & " UNION  SELECT STT_GSTT FROM PHIEU_BAO_TRI_HINH WHERE STT_YC_NSD=" & grdHinh.Rows(row).Cells("STT_HINH").Value
            Dim obj As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str)
            While obj.Read
                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTonTai", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                obj.Close()
                Exit Sub
            End While
            obj.Close()
            Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
            If Traloi = vbYes Then
                Commons.Modules.ObjSystems.Xoahinh(grdHinh.Rows(row).Cells("DUONG_DAN").Value)
                Dim objHinhController As New clsYEU_CAU_NSD_CHI_TIET_HINHController()
                objHinhController.DeleteYEU_CAU_NSD_CHI_TIET_HINH(intSTT, grdHinh.Rows(row).Cells("MS_MAY").Value, grdHinh.Rows(row).Cells("STT_VAN_DE").Value, grdHinh.Rows(row).Cells("STT_HINH").Value)
                ShowChichitietyeucau(intSTT)
                'ShowHinh(intSTT, strMS_MAY, intSTT_VAN_DE, intRowchon)
                SetTabYeucau(1)
            End If
        End If

    End Sub


    Private Sub grdHinh_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdHinh.RowEnter
        row = e.RowIndex
        intSTT_HINH = grdHinh.Rows(e.RowIndex).Cells("STT_HINH").Value
    End Sub

    Private Sub grdHinh_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdHinh.RowHeaderMouseClick
        row = e.RowIndex
        intSTT_HINH = grdHinh.Rows(e.RowIndex).Cells("STT_HINH").Value
    End Sub

    Private Sub BtnTrove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTrove.Click
        VisibleButtonXoa(False)
        VisibleButton(True)
        VisibleButtonGhi(False)
        tab = False
        SetTabYeucau(0)
        btnXacNhan.Visible = True
    End Sub

    Private Sub cboTennguoiYC_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTennguoiYC.SelectionChangeCommitted
        Refesh()
        LoadDanhsachyeucau()
    End Sub

    Private Sub dtNgayyeucau_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtNgayyeucau.CloseUp
        txtNgayyeucau.Text = Format(dtNgayyeucau.Value, "Short date")
        txtNgayyeucau.Focus()
    End Sub


    Private Sub dtNgayhoanthanh_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtNgayhoanthanh.CloseUp
        txtNgayhoanthanh.Text = Format(dtNgayhoanthanh.Value, "Short date")
        txtNgayhoanthanh.Focus()
    End Sub

    Private Sub dtTungay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtTungay.Validating
        Refresh()
        LoadDanhsachyeucau()
    End Sub

    Private Sub dtDenngay_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDenngay.CloseUp
        Refresh()
        LoadDanhsachyeucau()
    End Sub

    Private Sub dtDenngay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtDenngay.Validating
        Refresh()
        LoadDanhsachyeucau()
    End Sub

    Private Sub btnXemHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemHinh.Click
        If grdHinh.Rows.Count = 0 Or grdHinh.Rows.Count = 1 Then
            Exit Sub
        End If
        Try
            System.Diagnostics.Process.Start(grdHinh.Rows(row).Cells("DUONG_DAN").Value)
        Catch ex As Exception
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKiemtra9", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            'File đã bị thay đổi đường dẫn, hay không xem được định dạng file này trên máy người dùng! Vui lòng kiểm tra lại
        End Try
    End Sub


    Private bCo As Boolean = False
    Private Sub chkNguoiduyet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles chkNguoiduyet.CheckedChanged
        Dim obj As New clsPHAN_QUYEN_GIAI_QUYETController()
        If obj.GetCHUC_NANG_1(Commons.Modules.UserName) Then
            LockData2(False)
            'LockData3(True)
            If rtxtReviewer.Text.Trim <> "" Then
                If chkNguoiduyet.Checked Then
                    If txtUsername.Text = "" Then
                        txtUsername.Text = Commons.Modules.UserName
                        chkNguoiduyet.Text = "Checked"
                        bCo = False
                    Else
                        If txtUsername.Text = Commons.Modules.UserName Then
                            chkNguoiduyet.Text = "Checked"
                            rtxtReviewer.Enabled = True
                            bCo = False
                        Else
                            If Not bCo Then
                                bCo = True
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongTrungUsername", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                chkNguoiduyet.Text = "UnChecked"
                                rtxtReviewer.Enabled = False
                                chkNguoiduyet.Checked = False
                            End If
                        End If
                    End If
                Else
                    If txtUsername.Text <> "" Then
                        If txtUsername.Text = Commons.Modules.UserName Then
                            txtUsername.Text = ""
                            chkNguoiduyet.Text = "UnChecked"
                            rtxtReviewer.Enabled = True
                            bCo = False
                        Else
                            If Not bCo Then
                                bCo = True
                                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgKhongTrungUsername", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                                chkNguoiduyet.Checked = True
                                chkNguoiduyet.Text = "Checked"
                                rtxtReviewer.Enabled = False
                            End If
                        End If
                    End If

                End If
            Else
                If chkNguoiduyet.Checked And BtnGhi.Visible Then
                    chkNguoiduyet.Checked = False
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "ND_KT_NULL", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, Me.Text)
                    rtxtReviewer.Focus()
                End If
            End If
        Else
        End If
    End Sub

    Private Sub chkNguoiduyet_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkNguoiduyet.MouseDown
        Dim obj As New clsPHAN_QUYEN_GIAI_QUYETController()
        If Not obj.GetCHUC_NANG_1(Commons.Modules.UserName) Then
            chkNguoiduyet.CheckState = CheckState.Unchecked
        End If
    End Sub


    Private Sub dtTungay_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTungay.CloseUp
        Refresh()
        LoadDanhsachyeucau()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer

        While i < grdChitietyeucau.Rows.Count - 1
            XtraMessageBox.Show(grdChitietyeucau.Rows(i).Cells("YEU_CAU").Value.ToString())
            i = i + 1

        End While
    End Sub


    Private Sub btnXacNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXacNhan.Click
        RemoveHandler grdHinh.CellValidating, AddressOf Me.grdHinh_CellValidating
        RemoveHandler grdHinh.CellMouseDoubleClick, AddressOf Me.grdHinh_CellMouseDoubleClick

        rtxtReviewer.Enabled = True
        tab = True
        LockData(False)
        LockData1(True)
        If txtUsername.Text = "" Then
            LockData2(False)
        Else
            LockData2(True)
        End If

        LockData3(False)

        blnThem = 2
        VisibleButton(False)
        VisibleButtonGhi(True)
        SetTabYeucau(1)
        ShowChichitietyeucau(intSTT)
        txtNgayyeucau.Focus()

        grdHinh.AllowUserToAddRows = False
        grdChitietyeucau.AllowUserToAddRows = False

        rtxtUsercomment.ReadOnly = True
        btnXacNhan.Visible = False

        AddHandler txtNgayyeucau.Validating, AddressOf Me.txtNgayyeucau_Validating
        AddHandler txtNgayhoanthanh.Validating, AddressOf Me.txtNgayhoanthanh_Validating
        AddHandler txtGioyeucau.Validating, AddressOf Me.txtGioyeucau_Validating
        AddHandler dtNgayyeucau.ValueChanged, AddressOf Me.dtNgayyeucau_ValueChanged
        AddHandler dtNgayhoanthanh.ValueChanged, AddressOf Me.dtNgayhoanthanh_ValueChanged
        AddHandler grdChitietyeucau.RowValidating, AddressOf Me.grdChitietyeucau_RowValidating
        AddHandler grdChitietyeucau.CellValidating, AddressOf Me.grdChitietyeucau_CellValidating
        AddHandler chkNguoiduyet.CheckedChanged, AddressOf Me.chkNguoiduyet_CheckedChanged
        AddHandler grdChitietyeucau.EditingControlShowing, AddressOf Me.grdChitietyeucau_EditingControlShowing
        AddHandler grdChitietyeucau.DataSourceChanged, AddressOf Me.grdChitietyeucau_DataSourceChanged
        AddHandler grdChitietyeucau.CellValueChanged, AddressOf Me.grdChitietyeucau_CellValueChanged

    End Sub

    Sub LockControlXacNhan()
        rtxtUsercomment.ReadOnly = True


    End Sub



End Class