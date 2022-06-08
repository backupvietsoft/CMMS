
Imports Commons.VS.Classes.Catalogue
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports Commons.VS.Classes.Admin
Imports Commons
Imports DevExpress.XtraEditors

Public Class frmNhacungcap

#Region "Private Member"
    Private blnThem As Boolean
    Private blnSua As Boolean
    Private ID As Integer = 0
    Private MS_KH_TMP As String
    Private TEN_NGAN As String
    Private SQL_TMP As String = ""
    Private dtReader As SqlDataReader
    Private rowcount As Integer = 0
    Private rindex As Integer = 0
    Private DSKhachHang As New DataTable
#End Region

#Region "Control Event"

    Private Sub frmNhacungcap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TableLayoutPanel1.ColumnStyles(0).Width = 0
        TableLayoutPanel1.ColumnStyles(TableLayoutPanel1.ColumnCount - 1).Width = 0
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        LoadQG()
        If Commons.Modules.PermisString.Equals("Read only") Then
            BindData()
            VisibleButton(True)
            VisibleXoa(False)
            visibleGhi(False)
            LockData(True)
            If Me.grvKhachHang.RowCount > 0 Then
                grvKhachHang.FocusedRowHandle = 0
                formatgridNguoidaidien()
            End If
            EnableButton(False)
        Else
            EnableButton(True)

            BindData()
            VisibleButton(True)
            VisibleXoa(False)
            visibleGhi(False)
            LockData(True)
            If Me.grvKhachHang.RowCount > 0 Then
                grvKhachHang.FocusedRowHandle = 0
                formatgridNguoidaidien()
            End If
        End If
        Commons.Modules.ObjSystems.DinhDang()
    End Sub

    Sub EnableButton(ByVal bln As Boolean)
        BtnThem.Enabled = bln
        BtnSua.Enabled = bln
        BtnXoa.Enabled = bln
    End Sub

    Private Sub BtnThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnThem.Click
        blnThem = True
        VisibleButton(False)
        visibleGhi(True)
        LockData(False)
        bindDataNguoidaidien(Me.txtMakh.Text)
        txtMakh.Focus()
        Refesh()
        'AddHandler txtMakh.Validating, AddressOf Me.txtMakh_Validating
        'AddHandler TxtTencongty.Validating, AddressOf Me.TxtTencongty_Validating
        'AddHandler txtTenviettat.Validating, AddressOf Me.txtTenviettat_Validating
    End Sub

    Private Sub BtnSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSua.Click
        Try

            blnSua = True
            VisibleButton(False)
            visibleGhi(True)
            MS_KH_TMP = txtMakh.Text
            TEN_NGAN = txtTenviettat.Text.Trim()
            rowcount = Me.grdNguoidaidien.RowCount
            LockData(False)
            bindDataNguoidaidien(txtMakh.Text.Trim())
            rindex = grvKhachHang.FocusedRowHandle

            'AddHandler txtMakh.Validating, AddressOf Me.txtMakh_Validating
            'AddHandler TxtTencongty.Validating, AddressOf Me.TxtTencongty_Validating
            'AddHandler txtTenviettat.Validating, AddressOf Me.txtTenviettat_Validating
            txtMakh.Properties.ReadOnly = True
            txtTenviettat.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXoa.Click
        VisibleButton(False)
        visibleGhi(False)
        VisibleXoa(True)
    End Sub

    Private Sub btnXoaKH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaKH.Click

        ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng DDH_MUA không.

        SQL_TMP = "SELECT * FROM DDH_MUA WHERE MS_KH = '" & txtMakh.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa3", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng MAY không.
        SQL_TMP = "SELECT * FROM MAY WHERE MS_KH = '" & txtMakh.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa4", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng IC_DON_HANG_NHAP không.
        SQL_TMP = "SELECT * FROM IC_DON_HANG_NHAP INNER JOIN KHACH_HANG_CONG_NHAN ON IC_DON_HANG_NHAP.NGUOI_NHAP = KHACH_HANG_CONG_NHAN.NGUOI_NHAP WHERE KHACH_HANG_CONG_NHAN.NGUOI_NHAP = '" & txtMakh.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa10", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng IC_DON_HANG_XUAT không.
        SQL_TMP = "SELECT * FROM IC_DON_HANG_XUAT INNER JOIN KHACH_HANG_CONG_NHAN ON IC_DON_HANG_XUAT.NGUOI_NHAN = KHACH_HANG_CONG_NHAN.NGUOI_NHAP WHERE KHACH_HANG_CONG_NHAN.NGUOI_NHAP = '" & txtMakh.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa11", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()
        ' Kiểm tra xem khách hàng này có đang được sử dụng trong bảng IC_PHU_TUNG không.

        SQL_TMP = "SELECT * FROM IC_PHU_TUNG WHERE MS_KH = '" & txtMakh.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa5", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        SQL_TMP = "SELECT * FROM NGUOI_DAI_DIEN WHERE MS_KH = '" & txtMakh.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            ' Mã khách hàng này đang được sử dụng trong người đại diện ! Bạn khôhg thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa6", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()


        SQL_TMP = "SELECT * FROM PHIEU_BAO_TRI_SERVICE WHERE MS_KH = '" & txtMakh.Text & "'"
        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP)
        While dtReader.Read
            ' Mã khách hàng này đang được sử dụng trong người đại diện ! Bạn khôhg thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa9", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            dtReader.Close()
            Exit Sub
        End While
        dtReader.Close()

        ' Xóa khách hàng
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbYes Then
            Dim objNhaCungCapController As New KHACH_HANGController()
            objNhaCungCapController.InsertKHACH_HANG_LOG(txtMakh.Text, Me.Name, Commons.Modules.UserName, 3)
            objNhaCungCapController.DeleteKHACH_HANG(txtMakh.Text)
            Refesh()
            Dim tmp As Integer = intRow
            BindData()
            If grvKhachHang.RowCount > 0 Then
                If grvKhachHang.RowCount = tmp Then
                    grvKhachHang.FocusedRowHandle = intRow - 1
                Else
                    grvKhachHang.FocusedRowHandle = intRow
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnXoaNDD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoaNDD.Click
        Dim Traloi As String = MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa11", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If Traloi = vbNo Then Exit Sub
        Dim objNDD As New KHACH_HANGController
        If objNDD.CheckNguoidaidien(txtMakh.Text, Me.grdNguoidaidien.CurrentRow.Cells("STT").Value) Then
            ' Người này đang tồn tại trong EOR ! Bạn không thể xóa !
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgXoa15", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        deletNguoidaidien()
        bindDataNguoidaidien(txtMakh.Text)
    End Sub

    Private Sub btnTrove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrove.Click
        VisibleXoa(False)
        VisibleButton(True)
    End Sub

    Private Sub BtnGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGhi.Click
        Dim objKhachHangController As New KHACH_HANGController()
        If (Commons.Modules.ObjSystems.SplitString(txtMakh.Text.Trim) <> MS_KH_TMP) And (objKhachHangController.CheckMS_KH(Commons.Modules.ObjSystems.SplitString(Me.txtMakh.Text.Trim))).Read Then
            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMS_KH", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Me.txtMakh.Focus()
            Exit Sub
        End If

        If isValidated() Then
            Dim i As Integer
            Dim TEMP As String = Commons.Modules.ObjSystems.SplitString(Me.txtMakh.Text.Trim)
            If blnThem Then
                If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "MS_KH", " LTRIM(RTRIM(MS_KH)) = N'" + txtMakh.Text.Trim() + "'", txtMakh.Text.Trim()) And Not BtnKhongghi.Focused Then
                    ' Mã khách hàng này đã tồn tại, bạn vui lòng nhập mã khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi01", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtMakh.Focus()
                    txtMakh.SelectAll()
                    Exit Sub
                End If

                If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "TEN_RUT_GON", " LTRIM(RTRIM(TEN_RUT_GON)) = N'" + txtTenviettat.Text.Trim() + "'", txtTenviettat.Text.Trim()) And Not BtnKhongghi.Focused Then
                    ' Tên ngắn này đã tồn tại, bạn vui lòng nhập tên khác !
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi02", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    txtTenviettat.Focus()
                    txtTenviettat.SelectAll()
                    Exit Sub
                End If
            Else
                If txtMakh.Text.Trim <> MS_KH_TMP.Trim Then
                    If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "MS_KH", " LTRIM(RTRIM(MS_KH)) = N'" + txtMakh.Text.Trim() + "'", txtMakh.Text.Trim()) And Not BtnKhongghi.Focused Then
                        ' Mã khách hàng này đã tồn tại, bạn vui lòng nhập mã khác !
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi01", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        txtMakh.Focus()
                        txtMakh.SelectAll()
                        Exit Sub
                    End If
                End If
                If txtTenviettat.Text.Trim <> TEN_NGAN.Trim Then
                    If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "TEN_RUT_GON", " LTRIM(RTRIM(TEN_RUT_GON)) = N'" + txtTenviettat.Text.Trim() + "'", txtTenviettat.Text.Trim()) And Not BtnKhongghi.Focused Then
                        ' Tên ngắn này đã tồn tại, bạn vui lòng nhập tên khác !
                        MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi02", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                        txtTenviettat.Focus()
                        txtTenviettat.SelectAll()
                        Exit Sub
                    End If
                End If

            End If
            If (Commons.Modules.sPrivate = "SHISEIDO") Then
                Dim dt As DataTable = CType(grdNguoidaidien.DataSource, DataTable).Copy()
                dt.DefaultView.RowFilter = " NGUOI_HUONG = TRUE "
                If (dt.Rows.Count > 1 And dt.DefaultView.ToTable().Rows.Count = 0) Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChonNguoiHuong", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    Return
                ElseIf (dt.Rows.Count = 1 And dt.DefaultView.ToTable().Rows.Count = 0) Then
                    grdNguoidaidien.Rows(0).Cells(0).Value = True
                End If
            End If


            AddKhachhang()
            VisibleButton(True)
            visibleGhi(False)
            While i < Me.grvKhachHang.RowCount
                If Me.grvKhachHang.GetDataRow(i)(0) = TEMP Then
                    grvKhachHang.FocusedRowHandle = i
                    ShowKhachhang()
                    bindDataNguoidaidien(Me.grvKhachHang.GetDataRow(i)("MS_KH"))
                    Exit While
                Else
                    i = i + 1
                End If
            End While
            blnThem = False
            blnSua = False
            LockData(True)
        End If
        'MessageBox.Show(grvKhachHang.ScrollBars)
    End Sub

    Private Sub BtnKhongghi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKhongghi.Click
        Refesh()
        BindData()
        If Not isValidated() Then
            ErrorProvider.Clear()
        End If
        Try
            If grvKhachHang.RowCount <> 0 Then
                ShowKhachhang()
            End If
        Catch ex As Exception
            ShowKhachhang()
        End Try
        visibleGhi(False)
        VisibleButton(True)
        blnThem = False
        blnSua = False
        LockData(True)
        If grvKhachHang.RowCount <> 0 Then
            grvKhachHang.FocusedRowHandle = rindex
        End If
        If Me.grvKhachHang.RowCount = 0 Then
            BtnSua.Enabled = False
            BtnXoa.Enabled = False
        End If
        bindDataNguoidaidien(txtMakh.Text)
        'RemoveHandler txtMakh.Validating, AddressOf Me.txtMakh_Validating
        'RemoveHandler TxtTencongty.Validating, AddressOf Me.TxtTencongty_Validating
        'RemoveHandler txtTenviettat.Validating, AddressOf Me.txtTenviettat_Validating
    End Sub

    Private Sub BtnThoat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnThoat.Click
        Me.Close()
    End Sub



    'Private Sub grvKhachHang_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grvKhachHang.RowHeaderMouseClick
    '    ShowKhachhang()
    '    bindDataNguoidaidien(Me.txtMakh.Text)
    'End Sub
    Dim intRow As Integer
    'Private Sub grvKhachHang_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvKhachHang.RowEnter
    '    Try
    '        ShowKhachhang()

    '    Catch
    '    End Try

    '    bindDataNguoidaidien(Me.txtMakh.Text)
    '    intRow = e.RowIndex
    'End Sub
#End Region

#Region "Private Methods"

    Sub Refesh()
        txtMakh.Text = ""
        txtTenviettat.Text = ""
        TxtTencongty.Text = ""
        TxtDiachi.Text = ""
        TxtWebsite.Text = ""
        TxtDienthoai.Text = 0
        TxtFax.Text = 0
        TxtNguoidaidien.Text = ""
        txtMaSoThue.Text = ""
        txtTaiKhoan.Text = ""
        'cboQUOC_GIA.SelectedIndex = 0
        CType(grdNguoidaidien.DataSource, DataTable).Clear()
    End Sub

    Sub ShowKhachhang()
        txtMakh.Text = grvKhachHang.GetFocusedDataRow()("MS_KH")
        txtTenviettat.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("TEN_RUT_GON")), Nothing, grvKhachHang.GetFocusedDataRow()("TEN_RUT_GON"))
        TxtTencongty.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("TEN_CONG_TY")), Nothing, grvKhachHang.GetFocusedDataRow()("TEN_CONG_TY"))
        TxtDiachi.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("DIA_CHI")), Nothing, grvKhachHang.GetFocusedDataRow()("DIA_CHI"))
        TxtDienthoai.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("TEL")), Nothing, grvKhachHang.GetFocusedDataRow()("TEL"))
        TxtFax.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("FAX")), Nothing, grvKhachHang.GetFocusedDataRow()("FAX"))
        TxtNguoidaidien.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("TEN_NDD")), Nothing, grvKhachHang.GetFocusedDataRow()("TEN_NDD"))
        TxtWebsite.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("EMAIL")), Nothing, grvKhachHang.GetFocusedDataRow()("EMAIL"))
        Try
            cboQUOC_GIA.EditValue = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("QUOCGIA")), Nothing, grvKhachHang.GetFocusedDataRow()("QUOCGIA"))
        Catch ex As Exception
        End Try

        txtTaiKhoan.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("TAI_KHOAN_ANH")), Nothing, grvKhachHang.GetFocusedDataRow()("TAI_KHOAN_ANH"))
        txtMaSoThue.Text = IIf(IsDBNull(grvKhachHang.GetFocusedDataRow()("MS_THUE")), Nothing, grvKhachHang.GetFocusedDataRow()("MS_THUE"))
    End Sub
    Sub BindData()
        Try

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdKhachHang, grvKhachHang, New KHACH_HANGController().GetKHACH_HANGs, False, False, True, True, True, "")



            grvKhachHang.Columns("MS_KH").Width = 100
            grvKhachHang.Columns("TEN_CONG_TY").Width = 320
            grvKhachHang.Columns("TEN_RUT_GON").Width = 160
            grvKhachHang.Columns(3).Visible = False
            grvKhachHang.Columns(4).Visible = False
            grvKhachHang.Columns(5).Visible = False
            grvKhachHang.Columns(7).Visible = False
            grvKhachHang.Columns("DIA_CHI").Visible = False
            grvKhachHang.Columns("TEN_NDD").Visible = False
            grvKhachHang.Columns("QUOCGIA").Visible = False
            grvKhachHang.Columns("TAI_KHOAN_ANH").Visible = False
            grvKhachHang.Columns("MS_THUE").Visible = False
            grvKhachHang.Columns("QUOCGIA").Visible = False
            grvKhachHang.Columns("DC_TEL_FAX").Visible = False




            If grvKhachHang.RowCount > 0 Then
                BtnSua.Enabled = True
                BtnXoa.Enabled = True
                btnXoaKH.Enabled = True
            Else
                BtnSua.Enabled = False
                BtnXoa.Enabled = False
                btnXoaKH.Enabled = False
            End If
            If Commons.Modules.PermisString.Equals("Read only") Then
                EnableButton(False)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function isValidated()
        'If Not txtMakh.IsValidated Then
        '    txtMakh.Focus()
        '    Return False
        'End If
        'If Not txtTenviettat.IsValidated Then
        '    txtTenviettat.Focus()
        '    Return False
        'End If
        'If Not TxtTencongty.IsValidated Then
        '    TxtTencongty.Focus()
        '    Return False
        'End If
        Return True
    End Function
    Sub AddKhachhang()
        Dim objKhachHangController As New KHACH_HANGController()
        Dim objKhachHangInfo As New KHACH_HANGInfo
        objKhachHangInfo.MS_KH = Commons.Modules.ObjSystems.SplitString(txtMakh.Text.Trim)
        objKhachHangInfo.TEN_RUT_GON = txtTenviettat.Text.Trim
        objKhachHangInfo.TEN_CONG_TY = TxtTencongty.Text.Trim
        objKhachHangInfo.DIA_CHI = TxtDiachi.Text.Trim
        objKhachHangInfo.TEL = TxtDienthoai.Text.Trim
        objKhachHangInfo.FAX = TxtFax.Text.Trim
        objKhachHangInfo.EMAIL = TxtWebsite.Text.Trim
        objKhachHangInfo.TEN_NDD = TxtNguoidaidien.Text.Trim
        objKhachHangInfo.TAI_KHOAN_ANH = txtTaiKhoan.Text.Trim
        objKhachHangInfo.MS_THUE = txtMaSoThue.Text.Trim
        objKhachHangInfo.QUOCGIA = IIf(IsDBNull(cboQUOC_GIA.EditValue), Nothing, cboQUOC_GIA.EditValue)

        If blnSua Then
            objKhachHangInfo.MS_KH_tmp = MS_KH_TMP
            objKhachHangController.InsertKHACH_HANG_LOG(MS_KH_TMP, Me.Name, Commons.Modules.UserName, 2)
            objKhachHangController.InsertMay_LOG(objKhachHangInfo.MS_KH_tmp, Me.Name, Commons.Modules.UserName, 2)
            objKhachHangController.Update_KHACH_HANG_MAY(objKhachHangInfo)
            objKhachHangController.UpdateKHACH_HANG(objKhachHangInfo)
        End If

        If blnThem Then
            objKhachHangController.AddKHACH_HANG(objKhachHangInfo)
            objKhachHangController.InsertKHACH_HANG_LOG(objKhachHangInfo.MS_KH, Me.Name, Commons.Modules.UserName, 1)
        End If
        addNguoidaidien()
        BindData()
        Refesh()
    End Sub

    Sub VisibleButton(ByVal blnVisible As Boolean)
        BtnThem.Visible = blnVisible
        BtnSua.Visible = blnVisible
        BtnThoat.Visible = blnVisible
        BtnXoa.Visible = blnVisible
    End Sub

    Sub VisibleXoa(ByVal bln As Boolean)
        btnTrove.Visible = bln
        btnXoaNDD.Visible = bln
        btnXoaKH.Visible = bln
    End Sub

    Sub visibleGhi(ByVal bln As Boolean)
        BtnGhi.Visible = bln
        BtnKhongghi.Visible = bln
    End Sub

    Sub LockData(ByVal blnLock As Boolean)
        txtMakh.Properties.ReadOnly = blnLock
        txtTenviettat.Properties.ReadOnly = blnLock
        TxtTencongty.Properties.ReadOnly = blnLock
        TxtDiachi.Properties.ReadOnly = blnLock
        TxtDienthoai.Properties.ReadOnly = blnLock
        TxtNguoidaidien.Properties.ReadOnly = blnLock
        TxtFax.Properties.ReadOnly = blnLock
        TxtWebsite.Properties.ReadOnly = blnLock
        cboQUOC_GIA.Enabled = Not blnLock
        txtTaiKhoan.Properties.ReadOnly = blnLock
        txtMaSoThue.Properties.ReadOnly = blnLock

        Me.grdKhachHang.Enabled = blnLock

        If blnThem Or blnSua Then
            Me.grdNguoidaidien.AllowUserToAddRows = True
            Me.grdNguoidaidien.ReadOnly = False
        Else
            Me.grdNguoidaidien.AllowUserToAddRows = False
            Me.grdNguoidaidien.ReadOnly = True
        End If
    End Sub
#End Region
    Function KiemGhi() As Boolean
        Try
            If blnThem Then

            End If
            'XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTrungTenCa", Commons.Modules.TypeLanguage))
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            Return False
        End Try
        Return True

    End Function



    'Private Sub txtMakh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtMakh.Validating
    '    If BtnKhongghi.Focused() Then
    '        Exit Sub
    '    End If
    '    If BtnGhi.Visible Then
    '        If Not txtMakh.IsValidated Then
    '            txtMakh.Focus()
    '            e.Cancel = True
    '        End If
    '        If blnThem Then
    '            If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "MS_KH", "", txtMakh.Text) And Not BtnKhongghi.Focused Then
    '                ' Mã khách hàng này đã tồn tại, bạn vui lòng nhập mã khác !
    '                MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi01", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
    '                txtMakh.Focus()
    '                txtMakh.SelectAll()
    '                Exit Sub
    '            End If
    '        Else
    '            If txtMakh.Text.Trim <> MS_KH_TMP Then
    '                If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "MS_KH", "", txtMakh.Text) And Not BtnKhongghi.Focused Then
    '                    ' Mã khách hàng này đã tồn tại, bạn vui lòng nhập mã khác !
    '                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi01", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
    '                    txtMakh.Focus()
    '                    txtMakh.SelectAll()
    '                    Exit Sub
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub TxtTencongty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles TxtTencongty.Validating
    '    If Not TxtTencongty.IsValidated Then
    '        TxtTencongty.Focus()
    '        e.Cancel = True
    '    End If
    'End Sub

    'Private Sub txtTenviettat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtTenviettat.Validating
    '    If Not txtTenviettat.IsValidated Then
    '        txtTenviettat.Focus()
    '        e.Cancel = True
    '    End If
    '    If blnThem Then
    '        If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "TEN_RUT_GON", "", txtTenviettat.Text) And Not BtnKhongghi.Focused Then
    '            ' Tên ngắn này đã tồn tại, bạn vui lòng nhập tên khác !
    '            MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi02", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
    '            txtTenviettat.Focus()
    '            txtTenviettat.SelectAll()
    '            Exit Sub
    '        End If
    '    Else
    '        If txtTenviettat.Text.Trim <> TEN_NGAN Then
    '            Try
    '                If Commons.Modules.ObjSystems.KiemTraTrung("KHACH_HANG", "TEN_RUT_GON", " LTRIM(RTRIM(TEN_RUT_GON)) = N'" + txtTenviettat.Text.Trim() + "'", txtTenviettat.Text.Trim()) And Not BtnKhongghi.Focused Then
    '                    ' Tên ngắn này đã tồn tại, bạn vui lòng nhập tên khác !
    '                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhi02", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
    '                    txtTenviettat.Focus()
    '                    txtTenviettat.SelectAll()
    '                    Exit Sub
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        End If
    '    End If
    'End Sub




#Region "NGƯỜI ĐẠI DIỆN"
#Region "METHODS"
    Sub bindDataNguoidaidien(ByVal MS_KH As String)
        Dim tmp As Integer = introw1
        If (Commons.Modules.sPrivate = "SHISEIDO") Then
            Dim str As String = "SELECT NGUOI_HUONG, TEN_NDD, CHUC_VU,STT, SO_TAI_KHOAN, TEN_NH, SWIFT_CODE, DI_DONG,TEL,HOME_TEL,EMAIL,GHI_CHU,HOME_ADD
FROM NGUOI_DAI_DIEN WHERE MS_KH= '" + MS_KH + "'"
            Dim DT As DataTable = New DataTable()
            DT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str))
            Me.grdNguoidaidien.DataSource = DT
        Else
            Me.grdNguoidaidien.DataSource = New KHACH_HANGController().getNguoidaidien(MS_KH)
        End If
        For Each col As DataGridViewColumn In grdNguoidaidien.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next


        If Me.grdNguoidaidien.Rows.Count > 0 Then
            btnXoaNDD.Enabled = True
            If grdNguoidaidien.Rows.Count = tmp Then
                grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(tmp - 1).Cells("TEN_NDD")
                grdNguoidaidien.Focus()
            Else
                Try
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(tmp).Cells("TEN_NDD")
                    grdNguoidaidien.Focus()
                Catch ex As Exception
                End Try
            End If
        Else
            btnXoaNDD.Enabled = False
        End If
        If Commons.Modules.PermisString.Equals("Read only") Then
            EnableButton(False)
        End If
        'Me.grdNguoidaidien.Columns("CHUC_VU").Frozen = True
        formatgridNguoidaidien()
    End Sub

    Sub formatgridNguoidaidien()
        With Me.grdNguoidaidien
            .Columns("STT").Visible = False
            .Columns("TEN_NDD").Width = 250
            .Columns("CHUC_VU").Width = 180
            .Columns("DI_DONG").Width = 120
            .Columns("TEL").Width = 120
            .Columns("HOME_TEL").Width = 120
            .Columns("EMAIL").Width = 200
            .Columns("GHI_CHU").Width = 300
            .Columns("HOME_ADD").Width = 300

            If (Commons.Modules.sPrivate = "SHISEIDO") Then
                .Columns("NGUOI_HUONG").Width = 90
                .Columns("SO_TAI_KHOAN").Width = 120
                .Columns("TEN_NH").Width = 120
                .Columns("SWIFT_CODE").Width = 120
                .Columns("NGUOI_HUONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "NGUOI_HUONG", Commons.Modules.TypeLanguage)
                .Columns("SO_TAI_KHOAN").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SO_TAI_KHOAN", Commons.Modules.TypeLanguage)
                .Columns("TEN_NH").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NH", Commons.Modules.TypeLanguage)
                .Columns("SWIFT_CODE").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "SWIFT_CODE", Commons.Modules.TypeLanguage)
            End If
            .Columns("TEN_NDD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEN_NDD", Commons.Modules.TypeLanguage)
            .Columns("CHUC_VU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "CHUC_VU", Commons.Modules.TypeLanguage)
            .Columns("DI_DONG").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "DI_DONG", Commons.Modules.TypeLanguage)
            .Columns("TEL").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "TEL", Commons.Modules.TypeLanguage)
            .Columns("HOME_TEL").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HOME_TEL", Commons.Modules.TypeLanguage)
            .Columns("EMAIL").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "EMAIL", Commons.Modules.TypeLanguage)
            .Columns("GHI_CHU").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "GHI_CHU", Commons.Modules.TypeLanguage)
            .Columns("HOME_ADD").HeaderText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "HOME_ADD", Commons.Modules.TypeLanguage)
        End With
    End Sub

    Sub addNguoidaidien()
        Try

            Dim i As Integer
            Dim objkhachhangInfo As New KHACH_HANGInfo
            Dim objkhachhangController As New KHACH_HANGController

            objkhachhangInfo.MS_KH = txtMakh.Text.Trim
            If blnSua Then
                Dim tmp As Integer = rowcount
                For i = 0 To rowcount - 1
                    objkhachhangInfo.STT = Me.grdNguoidaidien.Rows(i).Cells("STT").Value.ToString
                    objkhachhangInfo.NGUOI_DAI_DIEN = Me.grdNguoidaidien.Rows(i).Cells("TEN_NDD").Value.ToString
                    objkhachhangInfo.CHUC_VU = Me.grdNguoidaidien.Rows(i).Cells("CHUC_VU").Value.ToString
                    objkhachhangInfo.DI_DONG = Me.grdNguoidaidien.Rows(i).Cells("DI_DONG").Value.ToString
                    objkhachhangInfo.DIEN_THOAI = Me.grdNguoidaidien.Rows(i).Cells("TEL").Value.ToString
                    objkhachhangInfo.DIEN_THOAI_NHA = Me.grdNguoidaidien.Rows(i).Cells("HOME_TEL").Value.ToString
                    objkhachhangInfo.EMAIL2 = Me.grdNguoidaidien.Rows(i).Cells("EMAIL").Value.ToString
                    objkhachhangInfo.GHI_CHU = Me.grdNguoidaidien.Rows(i).Cells("GHI_CHU").Value.ToString
                    objkhachhangInfo.DIA_CHI_NHA_RIENG = Me.grdNguoidaidien.Rows(i).Cells("HOME_ADD").Value.ToString
                    objkhachhangController.Update_Nguoidaidien(objkhachhangInfo, Me.Name)
                    If Commons.Modules.sPrivate = "SHISEIDO" Then
                        Dim STR As String = "UPDATE NGUOI_DAI_DIEN SET NGUOI_HUONG = '" & grdNguoidaidien.Rows(i).Cells("NGUOI_HUONG").Value.ToString & "', SO_TAI_KHOAN = '" & grdNguoidaidien.Rows(i).Cells("SO_TAI_KHOAN").Value.ToString & "', TEN_NH = '" & grdNguoidaidien.Rows(i).Cells("TEN_NH").Value.ToString & "', SWIFT_CODE = '" & grdNguoidaidien.Rows(i).Cells("SWIFT_CODE").Value.ToString & "' WHERE STT = '" & objkhachhangInfo.STT & "'"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
                    End If
                Next
                For i = tmp To Me.grdNguoidaidien.Rows.Count - 2
                    objkhachhangInfo.NGUOI_DAI_DIEN = Me.grdNguoidaidien.Rows(i).Cells("TEN_NDD").Value.ToString
                    objkhachhangInfo.CHUC_VU = Me.grdNguoidaidien.Rows(i).Cells("CHUC_VU").Value.ToString
                    objkhachhangInfo.DI_DONG = Me.grdNguoidaidien.Rows(i).Cells("DI_DONG").Value.ToString
                    objkhachhangInfo.DIEN_THOAI = Me.grdNguoidaidien.Rows(i).Cells("TEL").Value.ToString
                    objkhachhangInfo.DIEN_THOAI_NHA = Me.grdNguoidaidien.Rows(i).Cells("HOME_TEL").Value.ToString
                    objkhachhangInfo.EMAIL2 = Me.grdNguoidaidien.Rows(i).Cells("EMAIL").Value.ToString
                    objkhachhangInfo.GHI_CHU = Me.grdNguoidaidien.Rows(i).Cells("GHI_CHU").Value.ToString
                    objkhachhangInfo.DIA_CHI_NHA_RIENG = Me.grdNguoidaidien.Rows(i).Cells("HOME_ADD").Value.ToString
                    Dim stt = objkhachhangController.AddNguoidaidien(objkhachhangInfo, Me.Name)
                    If Commons.Modules.sPrivate = "SHISEIDO" Then
                        Dim STR As String = "UPDATE NGUOI_DAI_DIEN SET NGUOI_HUONG = '" & grdNguoidaidien.Rows(i).Cells("NGUOI_HUONG").Value.ToString & "', SO_TAI_KHOAN = '" & grdNguoidaidien.Rows(i).Cells("SO_TAI_KHOAN").Value.ToString & "', TEN_NH = '" & grdNguoidaidien.Rows(i).Cells("TEN_NH").Value.ToString & "', SWIFT_CODE = '" & grdNguoidaidien.Rows(i).Cells("SWIFT_CODE").Value.ToString & "' WHERE STT = '" & stt & "'"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
                    End If
                Next
            Else
                For i = 0 To Me.grdNguoidaidien.Rows.Count - 2
                    objkhachhangInfo.NGUOI_DAI_DIEN = Me.grdNguoidaidien.Rows(i).Cells("TEN_NDD").Value.ToString
                    objkhachhangInfo.CHUC_VU = Me.grdNguoidaidien.Rows(i).Cells("CHUC_VU").Value.ToString
                    objkhachhangInfo.DI_DONG = Me.grdNguoidaidien.Rows(i).Cells("DI_DONG").Value.ToString
                    objkhachhangInfo.DIEN_THOAI = Me.grdNguoidaidien.Rows(i).Cells("TEL").Value.ToString
                    objkhachhangInfo.DIEN_THOAI_NHA = Me.grdNguoidaidien.Rows(i).Cells("HOME_TEL").Value.ToString
                    objkhachhangInfo.EMAIL2 = Me.grdNguoidaidien.Rows(i).Cells("EMAIL").Value.ToString
                    objkhachhangInfo.GHI_CHU = Me.grdNguoidaidien.Rows(i).Cells("GHI_CHU").Value.ToString
                    objkhachhangInfo.DIA_CHI_NHA_RIENG = Me.grdNguoidaidien.Rows(i).Cells("HOME_ADD").Value.ToString
                    Dim stt = objkhachhangController.AddNguoidaidien(objkhachhangInfo, Me.Name)
                    If Commons.Modules.sPrivate = "SHISEIDO" Then
                        Dim STR As String = "UPDATE NGUOI_DAI_DIEN SET NGUOI_HUONG = '" & grdNguoidaidien.Rows(i).Cells("NGUOI_HUONG").Value.ToString & "', SO_TAI_KHOAN = '" & grdNguoidaidien.Rows(i).Cells("SO_TAI_KHOAN").Value.ToString & "', TEN_NH = '" & grdNguoidaidien.Rows(i).Cells("TEN_NH").Value.ToString & "', SWIFT_CODE = '" & grdNguoidaidien.Rows(i).Cells("SWIFT_CODE").Value.ToString & "' WHERE STT = '" & stt & "'"
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, STR)
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub deletNguoidaidien()
        Dim objkhachhangController As New KHACH_HANGController
        objkhachhangController.InsertNGUOI_DAI_DIEN_LOG(txtMakh.Text, Me.grdNguoidaidien.CurrentRow.Cells("STT").Value, Me.Name, Commons.Modules.UserName, 3)
        objkhachhangController.deleteNguoidaidien(txtMakh.Text, Me.grdNguoidaidien.CurrentRow.Cells("STT").Value, Me.Name)

    End Sub

#End Region
#End Region

    Private Sub grdNguoidaidien_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdNguoidaidien.CellValidating
        If BtnKhongghi.Focused() Then
            Exit Sub
        End If
        If BtnGhi.Visible Then
            Dim tb As New DataTable()
            tb = grdNguoidaidien.DataSource()
            If grdNguoidaidien.Columns(e.ColumnIndex).Name = "TEN_NDD" Then
                If e.FormattedValue.ToString.Length > tb.Columns("TEN_NDD").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTenNDDMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNguoidaidien.Columns(e.ColumnIndex).Name = "GHI_CHU" Then
                If e.FormattedValue.ToString.Length > tb.Columns("GHI_CHU").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgGhiChuMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNguoidaidien.Columns(e.ColumnIndex).Name = "CHUC_VU" Then
                If e.FormattedValue.ToString.Length > tb.Columns("CHUC_VU").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgChucVuMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNguoidaidien.Columns(e.ColumnIndex).Name = "DI_DONG" Then
                If e.FormattedValue.ToString.Length > tb.Columns("DI_DONG").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgDiDongMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNguoidaidien.Columns(e.ColumnIndex).Name = "TEL" Then
                If e.FormattedValue.ToString.Length > tb.Columns("TEL").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgTelMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNguoidaidien.Columns(e.ColumnIndex).Name = "HOME_TEL" Then
                If e.FormattedValue.ToString.Length > tb.Columns("HOME_TEL").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgHomeTelMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNguoidaidien.Columns(e.ColumnIndex).Name = "EMAIL" Then
                If e.FormattedValue.ToString.Length > tb.Columns("EMAIL").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgMailMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf grdNguoidaidien.Columns(e.ColumnIndex).Name = "HOME_ADD" Then
                If e.FormattedValue.ToString.Length > tb.Columns("HOME_ADD").MaxLength Then
                    MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Me.Name, "MsgHomeAddMax", Commons.Modules.TypeLanguage), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                    grdNguoidaidien.CurrentCell() = grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    grdNguoidaidien.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Dim introw1 As Integer
    Private Sub grdNguoidaidien_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdNguoidaidien.RowEnter
        introw1 = e.RowIndex
    End Sub

    Private Sub txtTenviettat_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenviettat.Validated
        Try
            txtTenviettat.Text = UCase(txtTenviettat.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadQG()
        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboQUOC_GIA, "GetQUOC_GIAs", "MA_QG", "TEN_QG", "", True)
    End Sub
    Private Sub cboQUOC_GIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQUOC_GIA.EditValueChanged
        Try
            Dim i As Integer
            i = cboQUOC_GIA.ItemIndex
            If i = -1 And cboQUOC_GIA.EditValue = -1 Then
                BindData()
                Try
                    If grvKhachHang.RowCount <> 0 Then
                        ShowKhachhang()
                    End If
                Catch ex As Exception
                    ShowKhachhang()
                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txtTenCTLoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTenCTLoc.TextChanged
        Dim chuoiloc As String
        Dim dt As New DataTable
        Try
            dt = CType(grdKhachHang.DataSource, DataTable)
            If txtTenCTLoc.Text.Trim <> "" Then
                chuoiloc = txtTenCTLoc.Text.Trim
                chuoiloc = chuoiloc.Replace("*", "%")
                dt.DefaultView.RowFilter = "MS_KH like '%" & chuoiloc & "%' OR TEN_CONG_TY like '%" & chuoiloc & "%' OR TEN_RUT_GON like '%" & chuoiloc & "%'"
                dt = dt.DefaultView.ToTable()
            Else
                dt.DefaultView.RowFilter = ""
                dt = dt.DefaultView.ToTable()
            End If
            If dt.DefaultView.ToTable.Rows.Count = 0 Then
                Refesh()
            End If
            txtTenCTLoc.Focus()
        Catch ex As Exception
            dt.DefaultView.RowFilter = ""
            dt = dt.DefaultView.ToTable()
        End Try
    End Sub



    Private Sub SplitContainerControl1_SizeChanged(sender As Object, e As EventArgs)
        grdNguoidaidien.Invalidate()
        grvKhachHang.Invalidate()
    End Sub

    Private Sub frmNhacungcap_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        grdNguoidaidien.Invalidate()
        grvKhachHang.Invalidate()
    End Sub

    Private Sub SplitContainerControl1_SplitterPositionChanged(sender As Object, e As EventArgs) Handles SplitContainerControl1.SplitterPositionChanged
        grdNguoidaidien.Invalidate()
        grvKhachHang.Invalidate()
    End Sub

    Private Sub grvKhachHang_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvKhachHang.FocusedRowChanged
        Try
            ShowKhachhang()
        Catch
        End Try
        bindDataNguoidaidien(Me.txtMakh.Text)
        intRow = e.FocusedRowHandle
    End Sub

    Private Sub grdNguoidaidien_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdNguoidaidien.CellEndEdit
        If Commons.Modules.SQLString = "0Load" Then Return
        If (Commons.Modules.sPrivate = "SHISEIDO") Then
            If e.ColumnIndex = 0 Then 'NGUOI_HUONG
                If (grdNguoidaidien.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "True") Then
                    For Each dr As DataGridViewRow In grdNguoidaidien.Rows
                        If grdNguoidaidien.Rows.IndexOf(dr) = e.RowIndex Then Continue For
                        Commons.Modules.SQLString = "0Load"
                        dr.Cells(e.ColumnIndex).Value = False
                        Commons.Modules.SQLString = ""
                    Next
                End If
            End If
        End If

    End Sub
End Class