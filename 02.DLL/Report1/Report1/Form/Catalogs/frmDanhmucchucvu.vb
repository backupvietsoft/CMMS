
Imports Commons.VS.Classes
Imports Commons.VS.Classes.Catalogue
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Imports Commons.VS.Classes.Admin
Imports Commons

Public Class frmDanhmucchucvu
    'Member Class
    Private blnThem As Boolean
    Private ID As Integer = 0
    Private SQL_TMP As String
    Private dtReader As SqlDataReader
    Private Ngay_tmp As DateTime
    Private Ten_tmp As String

    Private _MS_CN, _MS_CN_TMP As String
    Public tennhanvien As String

    Public Property MS_CN() As String
        Get
            Return _MS_CN
        End Get
        Set(ByVal value As String)
            _MS_CN = value
        End Set
    End Property

    Public Property MS_CN_TMP() As String
        Get
            Return _MS_CN_TMP
        End Get
        Set(ByVal value As String)
            _MS_CN_TMP = value
        End Set
    End Property

#Region "Control Event"

    Private Sub frmDanhmucchucvu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Commons.Modules.ObjSystems.DinhDang()
        LoadcboCONG_NHAN()

        cboCONG_NHAN.SelectedValue = _MS_CN
        If cboCONG_NHAN.SelectedValue Is Nothing Then
            cboCONG_NHAN.SelectedIndex = 0
        End If

        BindData(cboCONG_NHAN.SelectedValue.ToString)
        RefeshLanguage()
        VisibleButton(True)
        LockData(True)
        Try
            grdDanhsachchucvu.Rows(0).Cells(1).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Sub EnableButton(ByVal chon As Boolean)
        BtnThem.Enabled = chon
        BtnXoa.Enabled = chon
        BtnSua.Enabled = chon
    End Sub
    Private Sub RefeshLanguage()
        Me.lblTieude.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblTieude.Name, Commons.Modules.TypeLanguage)
        Me.lblChucvu.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblChucvu.Name, Commons.Modules.TypeLanguage)
        Me.lblNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblNgay.Name, Commons.Modules.TypeLanguage)
        Me.lblNhanvien.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, lblNhanvien.Name, Commons.Modules.TypeLanguage)
        Me.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, Me.Name, Commons.Modules.TypeLanguage)
        Me.BtnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnGhi.Name, Commons.Modules.TypeLanguage)
        Me.BtnKhongghi.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnKhongghi.Name, Commons.Modules.TypeLanguage)
        Me.BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnSua.Name, Commons.Modules.TypeLanguage)
        Me.BtnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThem.Name, Commons.Modules.TypeLanguage)
        Me.BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnThoat.Name, Commons.Modules.TypeLanguage)
        Me.BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, BtnXoa.Name, Commons.Modules.TypeLanguage)
        Me.grpDanhsachchucvu.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpDanhsachchucvu.Name, Commons.Modules.TypeLanguage)
        Me.grpNhapchucvu.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, grpNhapchucvu.Name, Commons.Modules.TypeLanguage)
        Try
            Me.grdDanhsachchucvu.Columns("NGAY").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGAY", Commons.Modules.TypeLanguage)
            Me.grdDanhsachchucvu.Columns("TEN_CHUC_VU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CHUC_VU", Commons.Modules.TypeLanguage)
            Me.grdDanhsachchucvu.Columns("TEN_CONG_NHAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_CONG_NHAN", Commons.Modules.TypeLanguage)

            Me.grdDanhsachchucvu.Columns("NGAY").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Me.grdDanhsachchucvu.Columns("NGAY").Width = 100

            Me.grdDanhsachchucvu.Columns("TEN_CHUC_VU").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.grdDanhsachchucvu.Columns("TEN_CONG_NHAN").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

        End Try



    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        Refesh()
        VisibleButton(False)
        LockData(False)
        blnThem = True
        dtpNGAY.Focus()
        grdDanhsachchucvu.Enabled = False
        AddHandler dtpNGAY.Validated, AddressOf Me.dtpNGAY_Validated
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click

        Ngay_tmp = Format(dtpNGAY.Value, "short date")
        Ten_tmp = txtTEN_CHUC_VU.Text
        VisibleButton(False)
        LockData(False)
        dtpNGAY.Focus()
        grdDanhsachchucvu.Enabled = False
        AddHandler dtpNGAY.Validated, AddressOf Me.dtpNGAY_Validated
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click

        If grdDanhsachchucvu.RowCount <= 0 Then
            'MsgBox("Không có dữ liệu để xóa!", MsgBoxStyle.OkOnly, "Thông báo")
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        'Dim Traloi As String = MsgBox("Bạn có muốn xóa chức vụ này không?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Thông báo")
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then

            ' Xóa chức vụ

            Dim objChucvuController As New clsCHUC_VUController()
            objChucvuController.DeleteCHUC_VU(cboCONG_NHAN.SelectedValue.ToString, dtpNGAY.Text)

            Refesh()
            Dim tmp As Integer = intRow
            BindData(cboCONG_NHAN.SelectedValue.ToString)
            If grdDanhsachchucvu.Rows.Count > 0 Then
                If grdDanhsachchucvu.Rows.Count = tmp Then
                    grdDanhsachchucvu.CurrentCell() = grdDanhsachchucvu.Rows(tmp - 1).Cells(0)
                    grdDanhsachchucvu.Focus()
                Else
                    grdDanhsachchucvu.CurrentCell() = grdDanhsachchucvu.Rows(tmp).Cells(0)
                    grdDanhsachchucvu.Focus()
                End If
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim i As Integer = 0
        Dim tmp As String = Trim(txtTEN_CHUC_VU.Text)
        If cboCONG_NHAN.Text = "" Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi", Commons.Modules.TypeLanguage), _
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            cboCONG_NHAN.Focus()
            Exit Sub
        End If

        SQL_TMP = "SELECT * FROM CHUC_VU WHERE MS_CONG_NHAN = '" & cboCONG_NHAN.SelectedValue.ToString.Replace("'", "''") _
                                            & "' AND NGAY = convert(datetime,'" & Format(dtpNGAY.Value, "short date") & "',103)"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            If blnThem Then
                If Not BtnKhongghi.Focused Then
                    ' Ngày này đã tồn tại ! Vui lòng nhập lại ngày khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    dtpNGAY.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            Else
                If Not BtnKhongghi.Focused And Format(dtpNGAY.Value, "short date") <> Ngay_tmp Then
                    ' Ngày này đã tồn tại ! Vui lòng nhập lại ngày khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    dtpNGAY.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            End If
        End While

        SQL_TMP = "SELECT * FROM CHUC_VU WHERE MS_CONG_NHAN = '" & cboCONG_NHAN.SelectedValue.ToString.Replace("'", "''") _
                                                   & "' AND TEN_CHUC_VU = '" & txtTEN_CHUC_VU.Text.Replace("'", "''") & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            If blnThem Then
                If Not BtnKhongghi.Focused Then
                    ' Tên chức vụ này đã tồn tại ! Vui lòng nhập lại tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi333", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTEN_CHUC_VU.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            Else
                If Not BtnKhongghi.Focused And txtTEN_CHUC_VU.Text <> Ten_tmp Then
                    ' Tên chức vụ này đã tồn tại ! Vui lòng nhập lại tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi333", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    txtTEN_CHUC_VU.Focus()
                    dtReader.Close()
                    Exit Sub
                End If
            End If
        End While
        If isValidated() Then
            AddChucvu()

            ' Xử lý load lại dữ liệu cho combobox đơn vị đo trong Form Thông số thiết bị.
            'frmThongsoGSTT.Load_cboDonvido()

            BindData(cboCONG_NHAN.SelectedValue.ToString)
            blnThem = False
            VisibleButton(True)
            LockData(True)
            grdDanhsachchucvu.Enabled = True
            While i < grdDanhsachchucvu.RowCount
                If grdDanhsachchucvu.Rows(i).Cells("TEN_CHUC_VU").Value.ToString = tmp Then
                    grdDanhsachchucvu.CurrentCell() = grdDanhsachchucvu.Rows(i).Cells("TEN_CONG_NHAN")
                    grdDanhsachchucvu.Focus()
                    Exit While
                Else
                    i = i + 1
                End If
            End While
        Else
            Exit Sub
        End If

        RemoveHandler dtpNGAY.Validated, AddressOf Me.dtpNGAY_Validated
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        Try
            If grdDanhsachchucvu.RowCount <> 0 Then
                ShowChucvu(grdDanhsachchucvu.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            ShowChucvu(0)
        End Try
        blnThem = False
        VisibleButton(True)
        LockData(True)
        grdDanhsachchucvu.Enabled = True
        RemoveHandler dtpNGAY.Validated, AddressOf Me.dtpNGAY_Validated
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub

    Private Sub grdDanhsachdonvido_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDanhsachchucvu.RowHeaderMouseClick
        ShowChucvu(e.RowIndex)
    End Sub
    Dim intRow As Integer
    Private Sub grddanhsachdonvido_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDanhsachchucvu.RowEnter
        ShowChucvu(e.RowIndex)
        intRow = e.RowIndex
    End Sub

    Private Sub cboCONG_NHAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCONG_NHAN.KeyPress
        Try

            AutoCompleteCbo(cboCONG_NHAN, e)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboCONG_NHAN_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONG_NHAN.SelectionChangeCommitted
        Refesh()
        BindData(cboCONG_NHAN.SelectedValue.ToString)
    End Sub

    Private Sub dtpNGAY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles dtpNGAY.Validated
        If Not BtnGhi.Visible Then Exit Sub

        If Not IsDate(Format(dtpNGAY.Value, "short date")) And Not BtnKhongghi.Focused Then
            ' Ngày tháng không hợp lệ ! Ngày tháng phải có kiểu dd/mm/yyyy !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), _
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtpNGAY.Focus()
            'Exit Sub
        Else
            Dim SQL_TMP As String = "SELECT * FROM CHUC_VU WHERE MS_CONG_NHAN = '" & cboCONG_NHAN.SelectedValue.ToString _
                                    & "' AND NGAY = convert(datetime,'" & Format(dtpNGAY.Value, "short date") & "',103)"
            Dim dtReader As SqlDataReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
            While dtReader.Read
                If blnThem Then
                    If Not BtnKhongghi.Focused Then
                        ' Ngày này đã tồn tại ! Vui lòng nhập lại ngày khác !
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        dtpNGAY.Focus()
                        dtReader.Close()
                        Exit While
                    Else
                        Exit While
                    End If
                Else
                    If Not BtnKhongghi.Focused And Format(dtpNGAY.Value, "short date") <> Ngay_tmp Then
                        ' Ngày này đã tồn tại ! Vui lòng nhập lại ngày khác !
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                        dtpNGAY.Focus()
                        dtReader.Close()
                        Exit While
                    Else
                        Exit While
                    End If
                End If
            End While
        End If
    End Sub
#End Region

#Region "Private Methods"
    Sub Refesh()
        dtpNGAY.Text = Format(Date.Now, "short date")
        txtTEN_CHUC_VU.Text = ""
    End Sub
    Sub ShowChucvu(ByVal RowIndex As Integer)
        cboCONG_NHAN.Text = grdDanhsachchucvu.Rows(RowIndex).Cells("TEN_CONG_NHAN").Value.ToString
        dtpNGAY.Text = grdDanhsachchucvu.Rows(RowIndex).Cells("NGAY").Value.ToString
        txtTEN_CHUC_VU.Text = grdDanhsachchucvu.Rows(RowIndex).Cells("TEN_CHUC_VU").Value.ToString
    End Sub
    Sub LoadcboCONG_NHAN()
        Dim obj As New Commons.clsprintnhanvien
        Dim dt As New DataTable
        dt = obj.Getbocongnhanbyma(_MS_CN)
        cboCONG_NHAN.DataSource = dt
        cboCONG_NHAN.Value = "MS_CONG_NHAN"
        cboCONG_NHAN.Display = "TEN_CONG_NHAN"
        cboCONG_NHAN.StoreName = "Getbocongnhanbyma"
        cboCONG_NHAN.Param = _MS_CN
        cboCONG_NHAN.ClassName = "frmQuanlynhanvien"
        cboCONG_NHAN.BindDataSource()
    End Sub

    Sub BindData(ByVal sMsCN As String)
        Dim dt As New DataTable
        Dim row As DataRow

        Try
            Me.grdDanhsachchucvu.DataSource = New clsCHUC_VUController().GetCHUC_VUs(sMsCN)
            grdDanhsachchucvu.Columns(0).Width = 180
            grdDanhsachchucvu.Columns(1).Width = 220
            grdDanhsachchucvu.Columns(2).Width = 80
            grdDanhsachchucvu.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            If grdDanhsachchucvu.RowCount > 0 Then
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
            Else
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
            End If
            dt = New clsCHUC_VUController().GetCHUC_VUs(sMsCN)
            If dt.Rows.Count > 0 Then
                row = dt.Rows(0)
                tennhanvien = row("TEN_CHUC_VU")
            End If


            Me.grdDanhsachchucvu.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1
            Me.grdDanhsachchucvu.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2
        Catch ex As Exception

        End Try
    End Sub
    Function isValidated()
        If Not cboCONG_NHAN.IsValidated Then
            cboCONG_NHAN.Focus()
            Return False
        End If
        If Not txtTEN_CHUC_VU.IsValidated Then
            txtTEN_CHUC_VU.Focus()
            Return False
        End If
        Return True
    End Function

    Sub AddChucvu()
        Dim objChucvuInfo As New CHUC_VUInfo
        Dim objChucvuController As New clsCHUC_VUController()
        objChucvuInfo.MS_CONG_NHAN = cboCONG_NHAN.SelectedValue.ToString
        objChucvuInfo.NGAY = dtpNGAY.Text
        objChucvuInfo.TEN_CHUC_VU = Trim(txtTEN_CHUC_VU.Text)
        If Not blnThem Then
            objChucvuInfo.NGAY_Tmp = Ngay_tmp
            objChucvuController.UpdateCHUC_VU(objChucvuInfo)
        Else
            objChucvuController.AddCHUC_VU(objChucvuInfo)
        End If
        Refesh()
    End Sub
    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
        BtnGhi.Visible = Not blnVisible
        BtnKhongghi.Visible = Not blnVisible
    End Sub
    Sub LockData(ByVal blnLock As Boolean)
        txtTEN_CHUC_VU.ReadOnly = blnLock
        dtpNGAY.Enabled = Not blnLock
        cboCONG_NHAN.Enabled = blnLock
    End Sub

    ' Hàm này dùng để tìm kiếm tự động khi người sử dụng nhập vào.
    Public Sub AutoCompleteCbo(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim strFindStr As String

        If e.KeyChar = Chr(8) Then  'Backspace
            If cb.SelectionStart <= 1 Then
                cb.Text = ""
                Exit Sub
            End If
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
            End If
        Else
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text & e.KeyChar
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
            End If
        End If

        Dim intIdx As Integer = -1

        ' Search the string in the Combo Box List.
        intIdx = cb.FindString(strFindStr)

        If intIdx <> -1 Then ' String found in the List.
            cb.SelectedText = ""
            cb.SelectedIndex = intIdx
            cb.SelectionStart = strFindStr.Length
            cb.SelectionLength = cb.Text.Length
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
#End Region

    Private Sub lblTieude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTieude.Click

    End Sub

    Private Sub cboCONG_NHAN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCONG_NHAN.SelectedIndexChanged

    End Sub
End Class