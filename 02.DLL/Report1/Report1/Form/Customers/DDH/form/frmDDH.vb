
Imports System.Data.SqlClient
Imports Commons

Public Class frmDDH

#Region "Thông tin chung "

    Private vTbDDH As DataTable = New DataTable()
    Private vEvent As String = "N"
    Private vIndex As Integer = -1
    Private vMS_DDH As String = Nothing

    Private Sub frmDDH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        tb_Control.SelectedIndex = 0
        vTabCurrent = 0

        LockInPut(True)
        If (Load_Data()) Then
            LockControl()
            Bind_Data()
        End If

        Load_ChuaDuyet()
        Bind_Data()
        LockControl()
        chxChuaDuyet.Checked = True
    End Sub
    'Khóa nhập liệu trên Control 
    Private Sub LockInPut(ByVal flag As Boolean)
        txt_Ma_DDH.ReadOnly = True
        'txt_GhiChu.ReadOnly = flag
        'txt_HT_TT.ReadOnly = flag
        txt_maKHg.ReadOnly = flag
        txt_SoDeXuat.ReadOnly = flag
        txt_TG_BH.ReadOnly = flag
        txt_DC_Giao.ReadOnly = flag
        mtxt_DienThoai.ReadOnly = flag
        mtxt_Fax.ReadOnly = flag
        mtxt_NgayGiao.ReadOnly = flag
        mtxt_NgayLap.ReadOnly = flag
        txt_NguoiDH.ReadOnly = flag
        txt_NoiDung.ReadOnly = flag
        txt_NguoiDuyet.ReadOnly = flag
        txt_nguoiXNhan.ReadOnly = flag
        txt_SoDDH.ReadOnly = flag
        txt_nguoiLH.ReadOnly = flag
        txt_DiaChi.ReadOnly = flag
        txt_CanCu.ReadOnly = flag
        gv_List_DDH.Enabled = flag

    End Sub
    'Điều khiển button
    Private Sub LockControl()
        If (vEvent.Equals("Add") Or vEvent.Equals("Edit")) Then
            bt_Them.Enabled = False
            bt_Xoa.Enabled = False
            bt_Sua.Enabled = False
            bt_In.Enabled = False
            bt_Thoat.Enabled = False
            bt_Luu.Enabled = True
            bt_Huy.Enabled = True
            chxDaDuyet.Enabled = False
            chxChuaDuyet.Enabled = False
            mtxt_NgayBD.Enabled = False
            mtxt_NgayKT.Enabled = False
        Else
            chxDaDuyet.Enabled = True
            chxChuaDuyet.Enabled = True
            mtxt_NgayBD.Enabled = True
            mtxt_NgayKT.Enabled = True
            If (gv_List_DDH.Rows.Count > 0) Then

                bt_Them.Enabled = True
                bt_Xoa.Enabled = True
                bt_Sua.Enabled = True
                bt_In.Enabled = True
                bt_Thoat.Enabled = True
                bt_Luu.Enabled = False
                bt_Huy.Enabled = False
            Else
                bt_Them.Enabled = True
                bt_Xoa.Enabled = False
                bt_Sua.Enabled = False
                bt_In.Enabled = False
                bt_Thoat.Enabled = True
                bt_Luu.Enabled = False
                bt_Huy.Enabled = False
            End If
            LockInPut(True)
        End If

    End Sub
    'Lấy thông tin chung
    Private Function Load_Data() As Boolean
        Try
            Dim s As String = ""
            If DateTime.Now.Month < 11 And DateTime.Now.Month > 1 Then
                s = "01/" & "0" & (DateTime.Now.Month - 1) & "/" & DateTime.Now.Year.ToString()
            Else
                If DateTime.Now.Month = 1 Then
                    s = "01/" & "12/" & DateTime.Now.Year.ToString() - 1
                Else
                    s = "01/" & (DateTime.Now.Month - 1) & "/" & DateTime.Now.Year.ToString()
                End If
            End If
            Dim vDauThang As Date = Date.ParseExact(s, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)
            Dim vNgayHientai As Date = Date.Now
            mtxt_NgayBD.Text = vDauThang.ToString("dd/MM/yyyy")
            mtxt_NgayKT.Text = vNgayHientai.ToString("dd/MM/yyyy")

            vTbDDH = clsMain1.GetDataDayToDay(vDauThang.ToString("MM/dd/yyyy"), vNgayHientai.ToString("MM/dd/yyyy"))
            gv_List_DDH.AutoGenerateColumns = False
            gv_List_DDH.DataSource = vTbDDH
            gv_List_DDH.Columns(clsTbDDH.MS_DDH).DataPropertyName = clsTbDDH.MS_DDH
            gv_List_DDH.Columns(clsTbDDH.TEN_CONG_TY).DataPropertyName = clsTbDDH.TEN_CONG_TY
            gv_List_DDH.Columns(clsTbDDH.NGAY_LAP).DataPropertyName = clsTbDDH.NGAY_LAP
            gv_List_DDH.Columns(clsTbDDH.SO_DDH).DataPropertyName = clsTbDDH.SO_DDH

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ' Đẩy dữ liệu vào control
    Private Sub Bind_Data()

        txt_Ma_DDH.Text = ""
        txt_maKHg.Text = ""
        txt_SoDeXuat.Text = ""
        txt_TenKHg.Text = ""

        txt_NguoiDH.Text = ""
        txt_nguoiXNhan.Text = ""
        txt_NguoiDuyet.Text = ""
        ' txt_HT_TT.Text = ""

        ' txt_GhiChu.Text = ""

        txt_TG_BH.Text = ""
        'txt_TG_BH.Enabled = flag
        txt_DC_Giao.Text = ""

        mtxt_DienThoai.Text = ""
        mtxt_Fax.Text = ""

        mtxt_NgayLap.Text = ""

        mtxt_NgayGiao.Text = ""

        txt_SoDDH.Text = ""

        'chx_DuyetMua.Text = ""

        txt_TenKHg.Text = ""

        txt_DiaChi.Text = ""

        txt_nguoiLH.Text = ""

        txt_NoiDung.Text = ""

        'chx_DuyetMua.Text = ""

        'chx_DuyetMua2.Text = ""
        'chx_DuyetMua3.Text = ""
        'chx_DuyetMua4.Text = ""
        txt_YKien.Text = ""
        txt_YKien2.Text = ""
        txt_YKien3.Text = ""
        txt_YKien4.Text = ""






        txt_Ma_DDH.DataBindings.Clear()
        txt_Ma_DDH.DataBindings.Add("Text", vTbDDH, clsTbDDH.MS_DDH, True, DataSourceUpdateMode.OnValidation)

        'txt_GhiChu.Enabled = flag
        'txt_HT_TT.Enabled = flag

        txt_maKHg.DataBindings.Clear()
        txt_maKHg.DataBindings.Add("Text", vTbDDH, clsTbDDH.MS_KH, True, DataSourceUpdateMode.OnValidation)
        txt_SoDeXuat.DataBindings.Clear()
        txt_SoDeXuat.DataBindings.Add("Text", vTbDDH, clsTbDDH.SO_DE_XUAT, True, DataSourceUpdateMode.OnValidation)

        txt_TenKHg.DataBindings.Clear()
        txt_TenKHg.DataBindings.Add("Text", vTbDDH, clsTbDDH.TEN_CONG_TY, True, DataSourceUpdateMode.OnValidation)

        txt_NguoiDH.DataBindings.Clear()
        txt_NguoiDH.DataBindings.Add("Text", vTbDDH, clsTbDDH.NGUOI_DAT_HANG, True, DataSourceUpdateMode.OnValidation)
        txt_nguoiXNhan.DataBindings.Clear()
        txt_nguoiXNhan.DataBindings.Add("Text", vTbDDH, clsTbDDH.NGUOI_XAC_NHAN, True, DataSourceUpdateMode.OnPropertyChanged)
        txt_NguoiDuyet.DataBindings.Clear()
        txt_NguoiDuyet.DataBindings.Add("Text", vTbDDH, clsTbDDH.NGUOI_DUYET, True, DataSourceUpdateMode.OnPropertyChanged)
        'txt_HT_TT.DataBindings.Clear()
        'txt_HT_TT.DataBindings.Add("Text", vTbDDH, clsTbDDH.HINH_THUC_TT)

        txt_CanCu.DataBindings.Clear()
        txt_CanCu.DataBindings.Add("Text", vTbDDH, clsTbDDH.CAN_CU, True, DataSourceUpdateMode.OnValidation)

        txt_TG_BH.DataBindings.Clear()
        txt_TG_BH.DataBindings.Add("Text", vTbDDH, clsTbDDH.BAO_HANH, True, DataSourceUpdateMode.OnValidation)

        'txt_TG_BH.Enabled = flag
        txt_DC_Giao.DataBindings.Clear()
        txt_DC_Giao.DataBindings.Add("Text", vTbDDH, clsTbDDH.DIA_CHI_GIAO_HANG, True, DataSourceUpdateMode.OnValidation)

        mtxt_DienThoai.DataBindings.Clear()
        mtxt_DienThoai.DataBindings.Add("Text", vTbDDH, clsTbDDH.DIEN_THOAI, True, DataSourceUpdateMode.OnValidation)
        mtxt_Fax.DataBindings.Clear()
        mtxt_Fax.DataBindings.Add("Text", vTbDDH, clsTbDDH.FAX, True, DataSourceUpdateMode.OnValidation)

        mtxt_NgayLap.DataBindings.Clear()
        mtxt_NgayLap.DataBindings.Add("Text", vTbDDH, clsTbDDH.NGAY_LAP, True, DataSourceUpdateMode.OnValidation)

        mtxt_NgayGiao.DataBindings.Clear()
        mtxt_NgayGiao.DataBindings.Add("Text", vTbDDH, clsTbDDH.NGAY_GIAO, True, DataSourceUpdateMode.OnValidation)

        txt_SoDDH.DataBindings.Clear()
        txt_SoDDH.DataBindings.Add("Text", vTbDDH, clsTbDDH.SO_DDH, True, DataSourceUpdateMode.OnValidation)

        chx_DuyetMua.DataBindings.Clear()
        chx_DuyetMua.DataBindings.Add("Checked", vTbDDH, clsTbDDH.DUYET)

        txt_TenKHg.DataBindings.Clear()
        txt_TenKHg.DataBindings.Add("Text", vTbDDH, clsTbDDH.TEN_CONG_TY, True, DataSourceUpdateMode.OnValidation)

        txt_DiaChi.DataBindings.Clear()
        txt_DiaChi.DataBindings.Add("Text", vTbDDH, clsTbDDH.DIA_CHI, True, DataSourceUpdateMode.OnValidation)


        txt_nguoiLH.DataBindings.Clear()
        txt_nguoiLH.DataBindings.Add("Text", vTbDDH, clsTbDDH.NGUOI_LIEN_HE, True, DataSourceUpdateMode.OnValidation)


        txt_NoiDung.DataBindings.Clear()
        txt_NoiDung.DataBindings.Add("Text", vTbDDH, clsTbDDH.NOI_DUNG_DDH, True, DataSourceUpdateMode.OnValidation)

        chx_DuyetMua.DataBindings.Clear()
        chx_DuyetMua.DataBindings.Add("Checked", vTbDDH, clsTbDDH.DUYET1)

        chx_DuyetMua2.DataBindings.Clear()
        chx_DuyetMua2.DataBindings.Add("Checked", vTbDDH, clsTbDDH.DUYET2)

        chx_DuyetMua3.DataBindings.Clear()
        chx_DuyetMua3.DataBindings.Add("Checked", vTbDDH, clsTbDDH.DUYET3)

        chx_DuyetMua4.DataBindings.Clear()
        chx_DuyetMua4.DataBindings.Add("Checked", vTbDDH, clsTbDDH.DUYET4)

        txt_YKien.DataBindings.Clear()
        txt_YKien.DataBindings.Add("Text", vTbDDH, clsTbDDH.YKIEN_DUYET)

        txt_YKien2.DataBindings.Clear()
        txt_YKien2.DataBindings.Add("Text", vTbDDH, clsTbDDH.YKIEN_DUYET2)

        txt_YKien3.DataBindings.Clear()
        txt_YKien3.DataBindings.Add("Text", vTbDDH, clsTbDDH.YKIEN_DUYET3)

        txt_YKien4.DataBindings.Clear()
        txt_YKien4.DataBindings.Add("Text", vTbDDH, clsTbDDH.YKIEN_DUYET4)


    End Sub
    ' Thêm mới một Đơn đặt hàng 
    Private Function Check_SoDeXuat(ByVal vmadx As String) As Boolean
        Try
            Dim vtbDXTem As DataTable = New DataTable()
            vtbDXTem = clsMain1.GetInfo("get_DeXuatDatHang")
            Dim vRowTem As DataRow
            For Each vRowTem In vtbDXTem.Rows
                If (vmadx.Equals(vRowTem("SO_DE_XUAT").ToString())) Then
                    Return False
                    'Exit Function
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Kiểm tra trạng thái ddh
    Private Function ChecDDHTinhTrang(ByVal vma As String) As Boolean
        Try
            Dim vTbtem As DataTable = clsMain1.GetDDhbyMDDH(vma)
            If (vTbtem.Rows.Count < 0) Then
                Return False
            End If
            'MessageBox.Show(vTbtem.Rows(0)("TRANGTHAI"))
            If vTbtem.Rows(0)("TRANGTHAI") = True Then
                Return True
            End If
            Return False
        Catch ex As Exception
        End Try
    End Function

    Private Sub bt_Them_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Them.Click
        txt_Ma_DDH.Focus()
        vEvent = "Add"

        mtxt_NgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy")

        Try
            vIndex = gv_List_DDH.CurrentRow.Index
        Catch ex As Exception
            vIndex = -1
        End Try
        LockControl()
        vTbDDH.Rows.Add()
        For i As Integer = 0 To gv_List_DDH.Rows.Count - 1
            If (gv_List_DDH.Rows(i).Cells("MS_DDH").Value.Equals(DBNull.Value)) Then
                gv_List_DDH.CurrentCell = gv_List_DDH.Rows(i).Cells(0)
                Exit For
            End If
        Next
        LockInPut(False)
        LockControl()
        txt_Ma_DDH.Text = Commons.clsTaoMa.RandomId("proTem", "DON_DAT_HANG", "MS_DDH", "DDH-")

    End Sub
    ' Lưu dữ liệu
    Private Sub bt_Luu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Luu.Click

        If (txt_Ma_DDH.Text.Equals("")) Then
            MessageBox.Show("Mã đơn đặt hàng không được để trống !", "Thông báo", MessageBoxButtons.OK)
            txt_Ma_DDH.Focus()
            Exit Sub
        End If

        If (txt_SoDDH.Text.Equals("")) Then
            MessageBox.Show("Số đơn đặt hàng không được để trống !", "Thông báo", MessageBoxButtons.OK)
            txt_SoDDH.Focus()
            Exit Sub
        End If

        'Kiểm tra ngày lập phiếu

        Dim vNgayLapPhieu As DateTime
        Dim vNgayGiao As DateTime = Nothing

        If (Not mtxt_NgayLap.Text.Trim().Equals("/  /")) Then
            Try
                vNgayLapPhieu = DateTime.ParseExact(mtxt_NgayLap.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)
                If vEvent = "Edit" Then
                    Exit Try
                End If

                If (vNgayLapPhieu > DateTime.Now()) Then
                    MessageBox.Show("Ngày lập phiếu phải nhỏ hơn hoặc bằng ngày hiện tại !", "Thông báo", MessageBoxButtons.OK)
                    mtxt_NgayLap.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Định dạng ngày/tháng/năm chưa đúng. hoặc không được để trống ! " & vbCrLf & "bạn vui lòng nhập lại theo đúng qui định ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                mtxt_NgayLap.Focus()
                Exit Sub
            End Try
        Else
            MessageBox.Show("Ngày lập phiếu không được để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mtxt_NgayLap.Focus()
            Exit Sub
        End If
        'Kiểm tra nội dung
        If (txt_NoiDung.Text.Trim().Equals("")) Then
            MessageBox.Show("Nội dung không được để trống !", "Thông báo", MessageBoxButtons.OK)
            txt_NoiDung.Focus()
            Exit Sub
        End If

        If (txt_maKHg.Text.Trim().Equals("")) Then
            MessageBox.Show("Mã khách hàng không được để trống !", "Thông báo", MessageBoxButtons.OK)
            txt_maKHg.Focus()
            Exit Sub
        End If

        ' Kiem tra Dữ liệu trong dự trù
        If (Not txt_SoDeXuat.Text.Trim().Equals("")) Then
            If (Check_SoDeXuat(txt_SoDeXuat.Text)) Then
                MessageBox.Show("Số đề xuất này chưa được tạo. " & vbCrLf & " Bạn vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK)
                txt_Ma_DDH.Focus()
                Exit Sub
            End If
        End If

        'Kiểm tra người đặt hàng
        If (txt_NguoiDH.Text.Trim().Equals("")) Then
            MessageBox.Show("Người đặt hàng không được để trống", "Thông báo", MessageBoxButtons.OK)
            txt_NguoiDH.Focus()
            Exit Sub
        End If
        'Ngay giao hang
        If mtxt_NgayGiao.Text.Trim().Equals("/  /") Then
            MessageBox.Show("Ngày giao không được để trống", "Thông báo", MessageBoxButtons.OK)
            mtxt_NgayGiao.Focus()
            Exit Sub
        Else
            Try
                vNgayGiao = DateTime.ParseExact(mtxt_NgayGiao.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)
                If (vNgayGiao < DateTime.ParseExact(mtxt_NgayLap.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)) Then
                    If vEvent = "Edit" Then
                        Exit Try
                    End If
                    MessageBox.Show("Ngày giao hàng phải lớn hơn ngày Lập Phiếu", "Thông báo", MessageBoxButtons.OK)
                    mtxt_NgayGiao.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Ngày Giao - Định dạng ngày/tháng/năm chưa đúng.! " & vbCrLf & "bạn vui lòng nhập lại theo đúng qui định ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                mtxt_NgayGiao.Focus()
                Exit Sub
            End Try
        End If
        'kiem tra Dia chi giao hang
        If txt_DC_Giao.Text.Trim().Equals("") Then
            MessageBox.Show("Địa chỉ giao hàng không được bỏ trống", "Thông báo", MessageBoxButtons.OK)
            txt_DC_Giao.Focus()
            Exit Sub
        End If
        'Kiem tra Hinh thức thanh toan
        'If (txt_HT_TT.Text.Trim().Equals("")) Then
        '    MessageBox.Show("Hình thức thanh toán không được bỏ trống", "Thông báo", MessageBoxButtons.OK)
        '    txt_HT_TT.Focus()
        '    Exit Sub
        'End If

        If (vEvent.Equals("Add")) Then
            If (clsMain1.InsertDDH(txt_Ma_DDH.Text, vNgayLapPhieu, txt_SoDeXuat.Text, txt_maKHg.Text, 0, txt_nguoiXNhan.Text, txt_NguoiDuyet.Text, txt_NguoiDH.Text, mtxt_Fax.Text, mtxt_DienThoai.Text, txt_DC_Giao.Text, "", txt_nguoiLH.Text, 0, 0, "", txt_TG_BH.Text, "", vNgayGiao, txt_SoDDH.Text, txt_NoiDung.Text, txt_DiaChi.Text, txt_CanCu.Text, "insert_DON_DAT_HANG")) Then
                Load_Data()
                Bind_Data()
                vTbDDH.AcceptChanges()
                gv_List_DDH.Refresh()
                vEvent = "N"
                LockControl()
            Else
                MessageBox.Show("Có lỗi xảy ra trong quá trình thêm " & vbCrLf & "Bạn vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            If (vEvent.Equals("Edit")) Then
                If (clsMain1.InsertDDH(txt_Ma_DDH.Text, vNgayLapPhieu, txt_SoDeXuat.Text, txt_maKHg.Text, 0, txt_nguoiXNhan.Text, txt_NguoiDuyet.Text, txt_NguoiDH.Text, mtxt_Fax.Text, mtxt_DienThoai.Text, txt_DC_Giao.Text, "", txt_nguoiLH.Text, 0, 0, "", txt_TG_BH.Text, "", vNgayGiao, txt_SoDDH.Text, txt_NoiDung.Text, txt_DiaChi.Text, txt_CanCu.Text, "update_DON_DAT_HANG")) Then
                    vTbDDH.AcceptChanges()
                    gv_List_DDH.Refresh()
                    vEvent = "N"
                    LockControl()
                Else
                    MessageBox.Show("Có lỗi xảy ra trong quá trình sửa dữ liệu " & vbCrLf & "Bạn vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub bt_Sua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Sua.Click
        Try
            vEvent = "Edit"
            LockInPut(False)
            vMS_DDH = gv_List_DDH.CurrentRow.Cells("MS_DDH").Value.ToString().Trim()
            vIndex = gv_List_DDH.CurrentRow.Index
            gv_List_DDH.CurrentCell = gv_List_DDH.Rows(vIndex).Cells(0)
            LockControl()
            If ChecDDHTinhTrang(vMS_DDH) Then
                MessageBox.Show("Đơn đặt hàng đã được phê duyệt ! bạn không thể sửa ", "Thông báo", MessageBoxButtons.OK)
                Try
                    vEvent = "N"
                    vTbDDH.RejectChanges()
                    LockControl()
                    If (vIndex < gv_List_DDH.Rows.Count) Then
                        gv_List_DDH.CurrentCell = gv_List_DDH.Rows(vIndex).Cells(0)
                    End If
                    gv_List_DDH.CurrentRow.Selected = True
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub bt_Thoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Thoat.Click
        ' chua kiem tra tinh trang truoc khi đóng form

        Me.Close()
    End Sub

    Private Sub bt_Xoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Xoa.Click
        Try
            If (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                If (clsMain1.DeleteDDH(txt_Ma_DDH.Text) = False) Then
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xóa. Bạn vui lòng kiểm tra lại ?", "Thông báo", MessageBoxButtons.OK)
                Else
                    For Each vRow As DataRow In vTbDDH.Rows
                        If (vRow("MS_DDH").ToString().Trim().Equals(gv_List_DDH.CurrentRow.Cells("MS_DDH").Value.ToString().Trim())) Then
                            vTbDDH.Rows.Remove(vRow)

                            Exit For
                        End If
                    Next
                    vEvent = "N"
                End If
            End If
            If ChecDDHTinhTrang(txt_Ma_DDH.Text) Then
                MessageBox.Show("Đơn đặt hàng đã được phê duyệt ! bạn không thể sửa ", "Thông báo", MessageBoxButtons.OK)
                Try
                    vEvent = "N"
                    vTbDDH.RejectChanges()
                    LockControl()
                    If (vIndex < gv_List_DDH.Rows.Count) Then
                        gv_List_DDH.CurrentCell = gv_List_DDH.Rows(vIndex).Cells(0)
                    End If
                    gv_List_DDH.CurrentRow.Selected = True
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bt_Huy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Huy.Click
        Try
            vEvent = "N"
            vTbDDH.RejectChanges()
            LockControl()
            If (vIndex < gv_List_DDH.Rows.Count) Then
                gv_List_DDH.CurrentCell = gv_List_DDH.Rows(vIndex).Cells(0)
            End If
            gv_List_DDH.CurrentRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private vTabCurrent As Integer = 0

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_Control.SelectedIndexChanged
        Select Case tb_Control.SelectedTab.Name
            Case "tb_CT_DHVT"
                If (vEventDV = "N" And vEvent = "N") Then
                    Load_DataVT()
                    TinhToan()
                    lockControlCT_VT()
                    'lockInputCT_VT(True)
                    vTabCurrent = tb_Control.SelectedIndex
                Else
                    tb_Control.SelectedIndex = vTabCurrent
                    Exit Sub
                End If
            Case "tb_CT_DHDV"
                If (vEventVT = "N" And vEvent = "N") Then

                    If (Load_Data_DV()) Then
                        LockControl_CTDV()
                        TinhToan_DV()
                        LockInputDV(True)
                        Load_DVT()
                        vTabCurrent = tb_Control.SelectedIndex
                        ' tinh gia tri luc load
                    End If

                Else
                    tb_Control.SelectedIndex = vTabCurrent
                    Exit Sub
                End If

            Case "tb_TT_CHUNG"
                If (vEventVT = "N" And vEventDV = "N") Then
                    'If (Load_Data_DV()) Then
                    '    'LockControl_CTDV()
                    '    'TinhToan_DV()
                    '    'LockInputDV(True)
                    vTabCurrent = tb_Control.SelectedIndex
                    'End If
                Else
                    tb_Control.SelectedIndex = vTabCurrent
                End If
            Case "tb_PHE_DUYET"

                If (vEventVT = "N" And vEventDV = "N" And vEvent = "N") Then

                    If (chxChuaDuyet.Checked = True) Then
                        bt_DuyetMua.Enabled = True
                        chx_DuyetMua.Enabled = True
                        chx_DuyetMua2.Enabled = True
                        chx_DuyetMua3.Enabled = True
                        chx_DuyetMua4.Enabled = True
                        txt_YKien.Enabled = True
                        txt_YKien2.Enabled = True
                        txt_YKien3.Enabled = True
                        txt_YKien4.Enabled = True
                    Else

                        txt_YKien.Enabled = False
                        txt_YKien2.Enabled = False
                        txt_YKien3.Enabled = False
                        txt_YKien4.Enabled = False
                        chx_DuyetMua.Enabled = False
                        chx_DuyetMua2.Enabled = False
                        chx_DuyetMua3.Enabled = False
                        chx_DuyetMua4.Enabled = False

                    End If

                    vTabCurrent = tb_Control.SelectedIndex
                    loadDuyet()
                Else
                    tb_Control.SelectedIndex = vTabCurrent
                End If
        End Select

        ' MessageBox.Show(TabControl1.SelectedTab.Name)

    End Sub

#End Region

#Region " Chi tiết Đơn Đặt Hàng Vật Tư "
    Private tbCTVT As DataTable = New DataTable()
    Private vEventVT As String = "N"

    Private Sub lockInputCT_VT(ByVal flag As Boolean)
        ' gv_ChiTietVT.Enabled = Not flag
        'MS_PT.ReadOnly = Not flag
        'TEN_PT.ReadOnly = Not flag
        SO_LUONG.ReadOnly = Not flag
        DON_GIA.ReadOnly = Not flag
        'DVT.ReadOnly = Not flag
        NGOAI_TE.ReadOnly = Not flag
        TI_GIA.ReadOnly = Not flag
        THANH_TIEN.ReadOnly = Not flag
        THANH_TIEN_NT.ReadOnly = Not flag
    End Sub

    Private Sub Load_DataVT()
        gv_ChiTietVT.AutoGenerateColumns = False
        'gv_ChiTietVT.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'gv_ChiTietVT.EndEdit()
        'gv_ChiTietVT.DataSource = DBNull.Value
        gv_ChiTietVT.DataSource = clsMain1.GetCT_DDH_VT(txt_Ma_DDH.Text)


        gv_ChiTietVT.Columns("MS_PT").DataPropertyName = "MS_PT"
        gv_ChiTietVT.Columns("TEN_PT").DataPropertyName = "TEN_PT"
        gv_ChiTietVT.Columns("DVT").DataPropertyName = "DVT"
        gv_ChiTietVT.Columns("MAY").DataPropertyName = "MS_MAY"
        gv_ChiTietVT.Columns("SO_LUONG").DataPropertyName = "SO_LUONG"
        gv_ChiTietVT.Columns("DON_GIA").DataPropertyName = "DON_GIA"
        gv_ChiTietVT.Columns("NGOAI_TE").DataPropertyName = "NGOAI_TE"
        gv_ChiTietVT.Columns("TI_GIA").DataPropertyName = "TI_GIA"
        gv_ChiTietVT.Columns("THANH_TIEN").DataPropertyName = "THANH_TIEN"
        gv_ChiTietVT.Columns("THANH_TIEN_NT").DataPropertyName = "THANH_TIEN_NT"

        Load_NgoaiTe()
        CType(gv_ChiTietVT.DataSource, DataTable).AcceptChanges()
    End Sub

    Protected Overridable Function SetCurrentCellAddressCore(ByVal columnIndex As Integer, ByVal rowIndex As Integer, ByVal setAnchorCellAddress As Boolean, ByVal validateCurrentCell As Boolean, ByVal throughMouseClick As Boolean) As Boolean


    End Function


    Private Sub Load_NgoaiTe()
        NGOAI_TE.DataSource = clsMain1.GetNgoaite()
        NGOAI_TE.ValueMember = "NGOAI_TE"
        NGOAI_TE.DisplayMember = "NGOAI_TE"
    End Sub

    'Su kien sort tren Gridview 

    Private Sub SortData()

        'Dim reader4 As IDataReader = Task.FetchAll(SubSonic.OrderBy.Asc(Task.Columns.Subject))
        'Dim reader2 As IDataReader = Task.FetchAll(SubSonic.OrderBy.Desc(Task.Columns.Subject))

        'gv_ChiTietVT.Columns("SO_LUONG").SortMode = DataGridViewColumnSortMode.NotSortable
        'gv_ChiTietVT.Columns("DON_GIA").SortMode = DataGridViewColumnSortMode.Programmatic

    End Sub


    Private Sub lockControlCT_VT()
        If (vEventVT.Equals("Add")) Then
            bt_SuaVT.Enabled = False
            bt_ChonCT.Enabled = True
            bt_LuuVT.Enabled = True
            bt_HuyVT.Enabled = True
            bt_ThoatVT.Enabled = False
        Else
            If (vEventVT.Equals("Select")) Then
                bt_SuaVT.Enabled = False
                bt_ChonCT.Enabled = True
                bt_LuuVT.Enabled = True
                bt_HuyVT.Enabled = True
                bt_ThoatVT.Enabled = False
            Else
                If (gv_ChiTietVT.Rows.Count > 0) Then
                    bt_SuaVT.Enabled = True
                    bt_ChonCT.Enabled = False
                    bt_LuuVT.Enabled = False
                    bt_HuyVT.Enabled = False
                    bt_ThoatVT.Enabled = True
                Else
                    bt_SuaVT.Enabled = True
                    bt_ChonCT.Enabled = False
                    bt_LuuVT.Enabled = False
                    bt_HuyVT.Enabled = False
                    bt_ThoatVT.Enabled = True
                End If
            End If
            lockInputCT_VT(False)
        End If

    End Sub

    Private Sub bt_ThemVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_SuaVT.Click
        vEventVT = "Add"
        lockControlCT_VT()
        lockInputCT_VT(True)

        '  THANH_TIEN.ReadOnly = True
        ' THANH_TIEN_NT.ReadOnly = True

        If ChecDDHTinhTrang(txt_Ma_DDH.Text) Then
            MessageBox.Show("Đơn đặt hàng đã được phê duyệt ! bạn không thể sửa ", "Thông báo", MessageBoxButtons.OK)
            Try
                vEventVT = "N"
                lockControlCT_VT()
                Load_DataVT()
                lockInputCT_VT(False)


            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub bt_LuuVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_LuuVT.Click

        Try
            For Each gvRow As DataGridViewRow In gv_ChiTietVT.Rows
                If (gvRow.Cells("SO_LUONG").Value <= 0) Then
                    MessageBox.Show("Số lượng đặt hàng phải lớn  hơn 0 ", "Thông báo", MessageBoxButtons.OK)
                    gv_ChiTietVT.CurrentCell = gv_ChiTietVT.Rows(gvRow.Index).Cells("SO_LUONG")
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try

        Dim sqlCon As SqlConnection = New SqlConnection()

        If (clsConnect.OpenConnect(sqlCon)) Then
            Dim tranS As SqlTransaction = sqlCon.BeginTransaction()
            Dim cCmd As SqlCommand = New SqlCommand()
            Dim tbData As DataTable = CType(gv_ChiTietVT.DataSource, DataTable).Copy()

            Try
                cCmd.Connection = sqlCon
                cCmd.Transaction = tranS
                cCmd.CommandText = "Delete From DON_DAT_HANG_CHI_TIET WHERE MS_DDH = '" & txt_Ma_DDH.Text & "'"
                cCmd.ExecuteNonQuery()

                For Each rwData As DataRow In tbData.Rows
                    'If (clsMain1.InsertVT_PT(txt_Ma_DDH.Text, rwData("MS_PT"), rwData("SO_LUONG"), rwData("DON_GIA"), rwData("NGOAI_TE"), rwData("TI_GIA"), "insert_DON_DAT_HANG_CHI_TIET") = False) Then
                    '    tranS.Rollback()
                    'End If
                    cCmd.CommandText = "INSERT INTO DON_DAT_HANG_CHI_TIET (MS_DDH, MS_PT,SO_LUONG, DON_GIA, NGOAI_TE, TI_GIA ,NGAY_GIAO) " & _
                                          "VALUES(N'" & txt_Ma_DDH.Text & "','" & rwData("MS_PT") & "','" & rwData("SO_LUONG") & "','" & rwData("DON_GIA") & "','" & rwData("NGOAI_TE") & "','" & rwData("TI_GIA") & "', '' )"
                    cCmd.ExecuteNonQuery()
                Next
                vEventVT = "N"
                lockControlCT_VT()
                tranS.Commit()
            Catch ex As Exception
                tranS.Rollback()
                lockControlCT_VT()
            End Try
        Else
            MessageBox.Show("Có lỗi kết nối xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub bt_HuyVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_HuyVT.Click
        vEventVT = "N"
        lockControlCT_VT()
        Load_DataVT()
        TinhToan()


    End Sub

    Private Sub bt_XoaVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If (MessageBox.Show("Bạn có chắc chắn muốn xóa không !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
            If (clsMain1.DeleteItemCT_DDH(txt_Ma_DDH.Text, gv_ChiTietVT.Rows(eIndex).Cells("MS_PT").Value) = False) Then
                MessageBox.Show("Có lỗi xảy ra trong quá trình xóa. Bạn vui lòng kiểm tra lại ?", "Thông báo", MessageBoxButtons.OK)
            Else
                For Each vRow As DataRow In tbCTVT.Rows
                    If (vRow("MS_PT").ToString().Trim().Equals(gv_ChiTietVT.CurrentRow.Cells("MS_PT").Value.ToString().Trim())) Then
                        tbCTVT.Rows.Remove(vRow)
                        tbCTVT.AcceptChanges()
                        tb_CT_DHDV.Refresh()
                        lockControlCT_VT()
                        Exit For
                    End If
                Next
            End If

        End If


    End Sub

    Private Sub bt_ChonCT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ChonCT.Click

        vEventVT = "Select"
        lockControlCT_VT()
        lockInputCT_VT(True)
        'THANH_TIEN.ReadOnly = True
        'THANH_TIEN_NT.ReadOnly = True

        Dim frmVT_PT As frmDS_VT_PT = New frmDS_VT_PT()
        frmDS_VT_PT.vtbPT = CType(gv_ChiTietVT.DataSource, DataTable).Copy()
        frmVT_PT.ShowDialog()
        gv_ChiTietVT.DataSource = frmDS_VT_PT.vtbPT
        Load_NgoaiTe()
        TinhToan()
        ' MessageBox.Show(frmDS_VT_PT.vtbPT.Rows.Count.ToString())
    End Sub

    'Hàm tính toán đơn hàng
    Private Sub TinhToan()
        Try
            Dim vtongCong As Double
            For Each gvrow As DataGridViewRow In gv_ChiTietVT.Rows
                Dim vtigia As Double
                ' Dim vTigiaNT As Double
                If (Not gv_ChiTietVT.Rows(gvrow.Index).Cells("NGOAI_TE").Value.Equals("")) Then
                    'For Each vrow As DataRow In clsMain1.GetNgoaite().Select("NGOAI_TE = '" & gv_ChiTietVT.Rows(gvrow.Index).Cells("NGOAI_TE").Value & "'")
                    '    vtigia = vrow("TI_GIA")
                    'Next
                    'gv_ChiTietVT.Rows(gvrow.Index).Cells("TI_GIA").Value = vtigia
                    If (gv_ChiTietVT.Rows(gvrow.Index).Cells("NGOAI_TE").Value.Equals("VND")) Then
                        gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("TI_GIA").Value, Double)
                        gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("TI_GIA").Value, Double)
                    Else
                        gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("TI_GIA").Value, Double)
                        gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double)
                    End If
                Else
                    gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                    gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN_NT").Value = 0
                    gv_ChiTietVT.Rows(gvrow.Index).Cells("TI_GIA").Value = vtigia
                End If
            Next
            For Each gvrow As DataGridViewRow In gv_ChiTietVT.Rows
                vtongCong = vtongCong + CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN").Value, Double)
            Next
            txt_TongCong.Text = vtongCong.ToString("###,###,###.##")
        Catch ex As Exception
            'MessageBox.Show(ex, "dd")
        End Try
    End Sub

    Private Sub gv_ChiTietVT_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_ChiTietVT.CellValueChanged, gv_ChiTietVT.CellClick
        'TinhToan()
    End Sub

    Private eIndex As Integer = -1

    Private Sub gv_ChiTietVT_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        eIndex = e.RowIndex
    End Sub

#End Region

#Region " Chi tiết đơn Đặt hàng dịch vụ "

    Private vTbCT_Dv As DataTable = New DataTable()
    Private vIndexDV As Integer = -1
    Private vEventDV As String = "N"
    Private vMs_DV As String = Nothing

    Private Sub LockInputDV(ByVal flag As Boolean)
        ' gv_CTDV.Enabled = Not flag
        TEN_DICH_VU.ReadOnly = flag
        SO_LUONG_DV.ReadOnly = flag
        DON_GIA_DV.ReadOnly = flag
        DVT_DV.ReadOnly = flag
        NGOAI_TE_DV.ReadOnly = flag
        TI_GIA_DV.ReadOnly = flag
        'THANH_TIEN_DV.ReadOnly = flag
        'THANH_TIEN_QD_DV.ReadOnly = flag

    End Sub

    Private Sub LockControl_CTDV()

        If (vEventDV.Equals("Add") Or vEventDV.Equals("Edit")) Then
            bt_ThemDV.Enabled = False
            bt_XoaDV.Enabled = False
            bt_SuaDV.Enabled = False
            bt_LuuDV.Enabled = True
            bt_HuyDV.Enabled = True
            bt_ThoatDV.Enabled = False
        Else
            If (gv_CTDV.Rows.Count > 1) Then

                bt_ThemDV.Enabled = True
                bt_XoaDV.Enabled = True
                bt_SuaDV.Enabled = True
                bt_LuuDV.Enabled = False
                bt_HuyDV.Enabled = False
                bt_ThoatDV.Enabled = True
            Else
                bt_ThemDV.Enabled = True
                bt_XoaDV.Enabled = False
                bt_SuaDV.Enabled = False
                bt_LuuDV.Enabled = False
                bt_HuyDV.Enabled = False
                bt_ThoatDV.Enabled = True
            End If
            LockInputDV(False)
        End If
    End Sub
    Private Function Load_Data_DV() As Boolean
        Try
            vTbCT_Dv = clsMain1.GetData_DichVu(txt_Ma_DDH.Text)
            gv_CTDV.AutoGenerateColumns = False

            gv_CTDV.DataSource = vTbCT_Dv

            gv_CTDV.Columns("MS_DDH_DV").DataPropertyName = "MS_DDH_DV"
            gv_CTDV.Columns("TEN_DICH_VU").DataPropertyName = "TEN_DICHVU"
            gv_CTDV.Columns("DVT_DV").DataPropertyName = "DVT"
            gv_CTDV.Columns("NGOAI_TE_DV").DataPropertyName = "NGOAI_TE"
            gv_CTDV.Columns("TI_GIA_DV").DataPropertyName = "TI_GIA"
            gv_CTDV.Columns("SO_LUONG_DV").DataPropertyName = "SO_LUONG"
            gv_CTDV.Columns("DON_GIA_DV").DataPropertyName = "DON_GIA"
            gv_CTDV.Columns("THANH_TIEN_DV").DataPropertyName = "THANH_TIEN"
            gv_CTDV.Columns("THANH_TIEN_QD_DV").DataPropertyName = "THANH_TIEN_QD"

            NGOAI_TE_DV.DataSource = clsMain1.GetNgoaite()
            NGOAI_TE_DV.ValueMember = "NGOAI_TE"
            NGOAI_TE_DV.DisplayMember = "NGOAI_TE"

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub bt_ThemDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ThemDV.Click
        vEventDV = "Add"
        gv_CTDV.AllowUserToAddRows = True

        Try
            vIndexDV = gv_CTDV.CurrentRow.Index
        Catch ex As Exception
            vIndexDV = -1
        End Try
        vTbCT_Dv.Rows.Add()
        For i As Integer = 0 To gv_CTDV.Rows.Count - 2
            If (gv_CTDV.Rows(i).Cells("MS_DDH_DV").Value.Equals(DBNull.Value)) Then
                gv_CTDV.CurrentCell = gv_CTDV.Rows(i).Cells(1)
            End If
        Next
        LockInputDV(False)
        LockControl_CTDV()
        If ChecDDHTinhTrang(txt_Ma_DDH.Text) Then
            MessageBox.Show("Đơn đặt hàng đã được phê duyệt ! bạn không thể sửa ", "Thông báo", MessageBoxButtons.OK)
            Try
                vEventDV = "N"
                vTbCT_Dv.RejectChanges()
                gv_CTDV.AllowUserToAddRows = False
                LockControl_CTDV()
                If (vIndexDV < gv_CTDV.Rows.Count) Then
                    gv_CTDV.CurrentCell = gv_CTDV.Rows(vIndex).Cells(1)
                End If
                gv_CTDV.CurrentRow.Selected = True

            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Function GetDataFromGrid(ByVal gvControl As DataGridView) As DataTable
        Dim tbTem As DataTable = CType(gvControl.DataSource, DataTable).Copy()
        Try
            For Each gvRowCtr As DataGridViewRow In gvControl.Rows
                Dim rowTem As DataRow = tbTem.NewRow()
                For Each gvColCtr As DataGridViewColumn In gvControl.Columns
                    ' MessageBox.Show(gvColCtr.DataPropertyName & gvColCtr.Name & gvRowCtr.Cells(gvColCtr.Name).FormattedValue)
                    Try
                        rowTem(gvColCtr.DataPropertyName) = gvRowCtr.Cells(gvColCtr.Name).FormattedValue
                    Catch ex As Exception

                    End Try
                Next
                tbTem.Rows.Add()
            Next
        Catch ex As Exception

        End Try
        Return tbTem
    End Function

    Private Sub Load_DVT()
        DVT_DV.DataSource = clsMain1.GetDVT()
        DVT_DV.DisplayMember = "TEN"
        DVT_DV.ValueMember = "DVT"
    End Sub

    Private Sub TinhToan_DV()
        Try
            Dim vtongCong As Double
            gv_CTDV.EndEdit()
            For Each gvrow As DataGridViewRow In gv_CTDV.Rows
                'Dim vtigia As Double
                ' Dim vTigiaNT As Double

                If (Not gv_CTDV.Rows(gvrow.Index).Cells("NGOAI_TE_DV").Value.Equals("")) Then
                    'For Each vrow As DataRow In clsMain.GetNgoaite().Select("NGOAI_TE = '" & gv_CTDV.Rows(gvrow.Index).Cells("NGOAI_TE_DV").FormattedValue & "'")
                    '    vtigia = vrow("TI_GIA")
                    'Next
                    'gv_CTDV.Rows(gvrow.Index).Cells("TI_GIA_DV").Value = vtigia

                    If (gv_CTDV.Rows(gvrow.Index).Cells("NGOAI_TE_DV").Value.Equals("VND")) Then
                        gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.Rows(gvrow.Index).Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.Rows(gvrow.Index).Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.Rows(gvrow.Index).Cells("TI_GIA_DV").FormattedValue, Double)
                        gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.Rows(gvrow.Index).Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.Rows(gvrow.Index).Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.Rows(gvrow.Index).Cells("TI_GIA_DV").FormattedValue, Double)
                    Else
                        gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.Rows(gvrow.Index).Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.Rows(gvrow.Index).Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.Rows(gvrow.Index).Cells("TI_GIA_DV").FormattedValue, Double)
                        gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.Rows(gvrow.Index).Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.Rows(gvrow.Index).Cells("DON_GIA_DV").FormattedValue, Double)
                    End If

                Else

                    gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_DV").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                    gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_QD_DV").Value = 0
                    gv_CTDV.Rows(gvrow.Index).Cells("TI_GIA_DV").Value = 0

                End If
            Next
            For Each gvrow As DataGridViewRow In gv_CTDV.Rows
                vtongCong = vtongCong + CType(gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_DV").Value, Double)
            Next
            txt_tongcongDV.Text = vtongCong.ToString("###,###,###.##")
        Catch ex As Exception
            'MessageBox.Show(ex, "dd")
        End Try
    End Sub
    Private Sub bt_LuuDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_LuuDV.Click
        Try
            For i As Integer = 0 To gv_CTDV.Rows.Count - 2


                If gv_CTDV.Rows(i).Cells("TEN_DICH_VU").FormattedValue.Equals("") Then
                    MessageBox.Show("Tên dịch vụ không được để trống", "Thông báo", MessageBoxButtons.OK)
                    gv_CTDV.CurrentCell = gv_CTDV.Rows(gv_CTDV.Rows(i).Index).Cells("TEN_DICH_VU")
                    Exit Sub
                End If
                If (gv_CTDV.Rows(i).Cells("SO_LUONG_DV").FormattedValue <= 0) Then
                    MessageBox.Show("Số lượng đặt hàng phải lớn  hơn 0 ", "Thông báo", MessageBoxButtons.OK)
                    gv_CTDV.CurrentCell = gv_CTDV.Rows(gv_CTDV.Rows(i).Index).Cells("SO_LUONG_DV")
                    Exit Sub
                End If

                If (gv_CTDV.Rows(i).Cells("DVT_DV").FormattedValue.Equals("")) Then
                    MessageBox.Show("Đơn vị tính không được để trống", "Thông báo", MessageBoxButtons.OK)
                    gv_CTDV.CurrentCell = gv_CTDV.Rows(gv_CTDV.Rows(i).Index).Cells("DVT_DV")
                    Exit Sub
                End If

                If (gv_CTDV.Rows(i).Cells("NGOAI_TE_DV").FormattedValue.Equals("")) Then
                    MessageBox.Show("Ngoại tệ không được để trống", "Thông báo", MessageBoxButtons.OK)
                    gv_CTDV.CurrentCell = gv_CTDV.Rows(gv_CTDV.Rows(i).Index).Cells("NGOAI_TE_DV")
                    Exit Sub
                End If

            Next
        Catch ex As Exception
        End Try
        ' LockControl_CTDV()



        Dim sqlCon As SqlConnection = New SqlConnection()

        If (clsConnect.OpenConnect(sqlCon)) Then
            Dim tranS As SqlTransaction = sqlCon.BeginTransaction()
            Dim cCmd As SqlCommand = New SqlCommand()

            Dim tbData As DataTable = GetDataFromGrid(gv_CTDV)
            Try
                cCmd.Connection = sqlCon
                cCmd.Transaction = tranS
                cCmd.CommandText = "Delete From DON_DAT_HANG_CHI_TIET_DICHVU WHERE MS_DDH = '" & txt_Ma_DDH.Text & "'"
                cCmd.ExecuteNonQuery()

                Dim i As Integer = 1
                For Each rwData As DataRow In tbData.Rows

                    If (Not rwData("NGOAI_TE").ToString() = "") Then
                        Dim vMa_ddh = txt_Ma_DDH.Text & i
                        i = i + 1
                        cCmd.CommandText = "INSERT INTO DON_DAT_HANG_CHI_TIET_DICHVU (MS_DDH_DV, MS_DDH, TEN_DICHVU, SO_LUONG, DON_GIA, NGOAI_TE, TI_GIA,DVT) " & _
                        " VALUES(N'" & vMa_ddh & "',N'" & txt_Ma_DDH.Text & "',N'" & rwData("TEN_DICHVU") & "','" & rwData("SO_LUONG") & "','" & rwData("DON_GIA") & "','" & rwData("NGOAI_TE") & "','" & rwData("TI_GIA") & "',N'" & rwData("DVT") & "')"
                        cCmd.ExecuteNonQuery()
                    End If
                Next
                tranS.Commit()
                vEventDV = "N"
                gv_CTDV.AllowUserToAddRows = False

                LockControl_CTDV()
                LockInputDV(True)
            Catch ex As Exception
                'tranS.Rollback()
                'vEventDV = "N"
                'LockControl_CTDV()
            End Try
        Else
            MessageBox.Show("Có lỗi kết nối xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub bt_HuyDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_HuyDV.Click
        Try
            vEventDV = "N"
            vTbCT_Dv.RejectChanges()
            TinhToan_DV()
            gv_CTDV.AllowUserToAddRows = False
            LockControl_CTDV()
            LockInputDV(True)
            If (vIndexDV < gv_CTDV.Rows.Count) Then
                gv_CTDV.CurrentCell = gv_CTDV.Rows(vIndex).Cells(1)
            End If
            gv_CTDV.CurrentRow.Selected = True

        Catch ex As Exception
        End Try


    End Sub

    Private Sub bt_XoaDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_XoaDV.Click
        Try
            If ChecDDHTinhTrang(txt_Ma_DDH.Text) Then
                MessageBox.Show("Đơn đặt hàng đã được phê duyệt ! bạn không thể xóa ", "Thông báo", MessageBoxButtons.OK)
                Try
                    vEventDV = "N"
                    vTbCT_Dv.RejectChanges()
                    gv_CTDV.AllowUserToAddRows = False
                    LockControl_CTDV()
                    If (vIndexDV < gv_CTDV.Rows.Count) Then
                        gv_CTDV.CurrentCell = gv_CTDV.Rows(vIndex).Cells(1)
                    End If
                    gv_CTDV.CurrentRow.Selected = True

                Catch ex As Exception
                End Try
            End If

            MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.OK)
            If (clsMain1.DeleteItem_DichVu(txt_Ma_DDH.Text, gv_CTDV.CurrentRow.Cells("MS_DDH_DV").Value.ToString()) = False) Then
                MessageBox.Show("Có lỗi xảy ra trong quá trình xóa. Bạn vui lòng kiểm tra lại ?", "Thông báo", MessageBoxButtons.OKCancel)
            Else
                For Each vRow As DataRow In vTbCT_Dv.Rows
                    If (vRow("MS_DDH_DV").ToString().Trim().Equals(gv_CTDV.CurrentRow.Cells("MS_DDH_DV").Value.ToString().Trim())) Then
                        vTbCT_Dv.Rows.Remove(vRow)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bt_SuaDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_SuaDV.Click
        Try
            vEventDV = "Edit"
            LockInputDV(False)

            vMs_DV = gv_CTDV.CurrentRow.Cells("MS_DDH_DV").Value.ToString().Trim()
            vIndexDV = gv_CTDV.CurrentRow.Index
            LockControl_CTDV()
            If ChecDDHTinhTrang(txt_Ma_DDH.Text) Then
                MessageBox.Show("Đơn đặt hàng đã được phê duyệt ! bạn không thể sửa ", "Thông báo", MessageBoxButtons.OK)
                Try
                    vEventDV = "N"
                    vTbCT_Dv.RejectChanges()
                    gv_CTDV.AllowUserToAddRows = False
                    LockControl_CTDV()
                    If (vIndexDV < gv_CTDV.Rows.Count) Then
                        gv_CTDV.CurrentCell = gv_CTDV.Rows(vIndex).Cells(1)
                    End If
                    gv_CTDV.CurrentRow.Selected = True

                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Phê duyệt"
    Dim vEventD As String = "N"
    Private Sub bt_DuyetMua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub loadDuyet()
        If (chx_DuyetMua.Checked = True) Then
            txt_YKien.ReadOnly = False
        Else
            txt_YKien.ReadOnly = True
        End If
        If (chx_DuyetMua2.Checked = True) Then
            txt_YKien2.ReadOnly = False
        Else
            txt_YKien2.ReadOnly = True
        End If
        If (chx_DuyetMua3.Checked = True) Then
            txt_YKien3.ReadOnly = False
        Else
            txt_YKien3.ReadOnly = True
        End If
        If (chx_DuyetMua4.Checked = True) Then
            txt_YKien4.ReadOnly = False
        Else
            txt_YKien4.ReadOnly = True
        End If

    End Sub

    Private Sub chx_DuyetMua_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chx_DuyetMua.CheckedChanged
        If (chx_DuyetMua.Checked = True) Then
            txt_YKien.ReadOnly = False
        Else
            txt_YKien.Text = ""
            txt_YKien.ReadOnly = True

        End If
    End Sub

    Private Sub chx_DuyetMua2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chx_DuyetMua2.CheckedChanged
        If (chx_DuyetMua2.Checked = True) Then
            txt_YKien2.ReadOnly = False
        Else
            txt_YKien2.Text = ""
            txt_YKien2.ReadOnly = True
        End If
    End Sub

    Private Sub chx_DuyetMua3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chx_DuyetMua3.CheckedChanged
        If (chx_DuyetMua3.Checked = True) Then
            txt_YKien3.ReadOnly = False
        Else
            txt_YKien3.Text = ""
            txt_YKien3.ReadOnly = True
        End If
    End Sub

    Private Sub chx_DuyetMua4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chx_DuyetMua4.CheckedChanged
        If (chx_DuyetMua4.Checked = True) Then
            txt_YKien4.ReadOnly = False
        Else
            txt_YKien4.Text = ""
            txt_YKien4.ReadOnly = True
        End If
    End Sub
#End Region

#Region " Lọc dữ liệu từ ngày tới ngày (Chưa duyệt)"
    Private Sub Load_Daduyet()
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()
        Dim vNgay_BD As String = DateTime.ParseExact(mtxt_NgayBD.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture).ToString("MM/dd/yyyy")
        Dim vNgay_KT As String = DateTime.ParseExact(mtxt_NgayKT.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture).ToString("MM/dd/yyyy")
        Try
            Dim sqlStr As String = "SELECT DON_DAT_HANG.MS_DDH, DON_DAT_HANG.NGAY_LAP, DON_DAT_HANG.SO_DE_XUAT, DON_DAT_HANG.MS_KH, DON_DAT_HANG.THANH_TIEN, " & _
            " DON_DAT_HANG.NGUOI_XAC_NHAN, DON_DAT_HANG.NGUOI_DUYET, DON_DAT_HANG.NGUOI_DAT_HANG, DON_DAT_HANG.FAX, " & _
            " DON_DAT_HANG.DIEN_THOAI, DON_DAT_HANG.DIA_CHI_GIAO_HANG, DON_DAT_HANG.THOI_HAN_THANH_TOAN, DON_DAT_HANG.NGUOI_LIEN_HE, " & _
            " DON_DAT_HANG.DUYET, DON_DAT_HANG.VAT,DON_DAT_HANG.HINH_THUC_TT,DON_DAT_HANG.BAO_HANH,DON_DAT_HANG.GHI_CHU,DON_DAT_HANG.NGAY_GIAO,DON_DAT_HANG.SO_DDH, KHACH_HANG.TEN_CONG_TY,KHACH_HANG.TEL,KHACH_HANG.FAX,KHACH_HANG.DIA_CHI,KHACH_HANG.TEN_NDD,DON_DAT_HANG.NOI_DUNG_DDH,DON_DAT_HANG.YKIEN_DUYET2, DON_DAT_HANG.YKIEN_DUYET3, DON_DAT_HANG.YKIEN_DUYET4, DON_DAT_HANG.DUYET1, " & _
            " DON_DAT_HANG.DUYET2, DON_DAT_HANG.DUYET3, DON_DAT_HANG.DUYET4, DON_DAT_HANG.TRANGTHAI, DON_DAT_HANG.YKIEN_DUYET , DON_DAT_HANG.CAN_CU" & _
            " FROM DON_DAT_HANG INNER JOIN KHACH_HANG ON DON_DAT_HANG.MS_KH = KHACH_HANG.MS_KH" & _
            " WHERE  DON_DAT_HANG.NGAY_LAP BETWEEN '" & vNgay_BD & "' AND '" & vNgay_KT & "'AND DON_DAT_HANG.DUYET = 1"
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)

                gv_List_DDH.DataSource = vtbTem
                vTbDDH = vtbTem
                vTbDDH.AcceptChanges()
                Bind_Data()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Load_ChuaDuyet()
        Dim vtbTem As DataTable = New DataTable()
        Dim vCon As SqlConnection = New SqlConnection()


        Try

            Dim vNgay_BD As String = DateTime.ParseExact(mtxt_NgayBD.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture).ToString("MM/dd/yyyy")
            Dim vNgay_KT As String = DateTime.ParseExact(mtxt_NgayKT.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture).ToString("MM/dd/yyyy")

            Dim sqlStr As String = "SELECT DON_DAT_HANG.MS_DDH, DON_DAT_HANG.NGAY_LAP, DON_DAT_HANG.SO_DE_XUAT, DON_DAT_HANG.MS_KH, DON_DAT_HANG.THANH_TIEN, " & _
            " DON_DAT_HANG.NGUOI_XAC_NHAN, DON_DAT_HANG.NGUOI_DUYET, DON_DAT_HANG.NGUOI_DAT_HANG, DON_DAT_HANG.FAX, " & _
            " DON_DAT_HANG.DIEN_THOAI, DON_DAT_HANG.DIA_CHI_GIAO_HANG, DON_DAT_HANG.THOI_HAN_THANH_TOAN, DON_DAT_HANG.NGUOI_LIEN_HE, " & _
            " DON_DAT_HANG.DUYET, DON_DAT_HANG.VAT,DON_DAT_HANG.HINH_THUC_TT,DON_DAT_HANG.BAO_HANH,DON_DAT_HANG.GHI_CHU,DON_DAT_HANG.NGAY_GIAO,DON_DAT_HANG.SO_DDH, KHACH_HANG.TEN_CONG_TY,KHACH_HANG.TEL,KHACH_HANG.FAX,KHACH_HANG.DIA_CHI,KHACH_HANG.TEN_NDD,DON_DAT_HANG.NOI_DUNG_DDH,DON_DAT_HANG.YKIEN_DUYET2, DON_DAT_HANG.YKIEN_DUYET3, DON_DAT_HANG.YKIEN_DUYET4, DON_DAT_HANG.DUYET1, " & _
            " DON_DAT_HANG.DUYET2, DON_DAT_HANG.DUYET3, DON_DAT_HANG.DUYET4, DON_DAT_HANG.TRANGTHAI, DON_DAT_HANG.YKIEN_DUYET , DON_DAT_HANG.CAN_CU" & _
            " FROM DON_DAT_HANG INNER JOIN KHACH_HANG ON DON_DAT_HANG.MS_KH = KHACH_HANG.MS_KH" & _
            " WHERE  DON_DAT_HANG.NGAY_LAP BETWEEN '" & vNgay_BD & "' AND '" & vNgay_KT & "'AND DON_DAT_HANG.DUYET = 0"
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vAdpt As SqlDataAdapter = New SqlDataAdapter()
                vAdpt.SelectCommand = New SqlCommand(sqlStr, vCon)
                vAdpt.Fill(vtbTem)

                gv_List_DDH.DataSource = vtbTem
                vTbDDH = vtbTem
                vTbDDH.AcceptChanges()
                Bind_Data()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chxDaDuyet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxDaDuyet.CheckedChanged

        If (chxDaDuyet.Focused = True) Then
            If chxDaDuyet.Checked = True Then
                Load_Daduyet()
                LockControl()
                Bind_Data()
                chxChuaDuyet.Checked = False
                bt_Them.Enabled = False
                bt_Xoa.Enabled = False
                bt_Sua.Enabled = False
                bt_ThemDV.Enabled = False
                bt_XoaDV.Enabled = False
                bt_SuaVT.Enabled = False
                bt_SuaDV.Enabled = False
                bt_DuyetMua.Enabled = False

            Else
            End If
        End If

    End Sub

    Private Sub chxChuaDuyet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chxChuaDuyet.CheckedChanged

        If (chxChuaDuyet.Focused = True) Then

            If chxChuaDuyet.Checked = True Then
                chxDaDuyet.Checked = False
                bt_Them.Enabled = True
                bt_Xoa.Enabled = True
                bt_Sua.Enabled = True

                bt_ThemDV.Enabled = True
                bt_XoaDV.Enabled = True
                bt_SuaVT.Enabled = True
                bt_SuaDV.Enabled = True
                bt_DuyetMua.Enabled = True

                Load_ChuaDuyet()
                Bind_Data()
                LockControl()
            End If
        End If
        'If chxDaDuyet.Checked = False And chxChuaDuyet.Checked = False Then
        '    Load_Data()
        '    Bind_Data()
        'End If
    End Sub

    Private Sub txt_maKHg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_maKHg.KeyDown
        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (e.KeyCode = Keys.Enter) Then
                Dim frmKH As frmKhachHang = New frmKhachHang()
                frmKhachHang.vMaKH = txt_maKHg.Text
                frmKhachHang.vTenKH = txt_TenKHg.Text
                frmKH.ShowDialog()
                txt_TenKHg.Text = frmKhachHang.vTenKH
                txt_maKHg.Text = frmKhachHang.vMaKH
                If (Not frmKhachHang.vTenKH.Trim.Equals("")) Then
                    Check_KhachHang(frmKhachHang.vMaKH)
                End If
            End If
        End If
    End Sub

    Private Sub mtxt_NgayKT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxt_NgayKT.Validating
        clsCheckDate.ChecKed_Value_Date(sender, e)
        Try
            If (Not mtxt_NgayBD.Text.Trim().Equals("/  /")) Then
                If (DateTime.ParseExact(mtxt_NgayBD.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture) > DateTime.ParseExact(mtxt_NgayKT.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)) Then
                    MessageBox.Show("Ngày - Phải lớn hơn ngày Bắt đầu")
                    mtxt_NgayKT.Focus()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mtxt_NgayBD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxt_NgayBD.Validating
        ' MessageBox.Show(DateTime.ParseExact(mtxt_NgayBD.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture))
        clsCheckDate.ChecKed_Value_Date(sender, e)
        If (Not mtxt_NgayKT.Text.Trim().Equals("/  /")) Then
            Try
                If (DateTime.ParseExact(mtxt_NgayBD.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture) > DateTime.ParseExact(mtxt_NgayKT.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)) Then
                    MessageBox.Show("Từ ngày phải nhỏ hơn Đến ngày")
                    mtxt_NgayBD.Focus()
                End If
            Catch ex As Exception
                e.Cancel = True
            End Try

        End If
    End Sub

    Private Sub mtxt_NgayBD_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxt_NgayBD.Validated
        If (vEvent = "Edit" Or vEvent = "Add") Then
            Exit Sub
        Else
            Try
                If (chxDaDuyet.Checked = True) Then
                    Load_Daduyet()
                    Bind_Data()
                End If
                If chxChuaDuyet.Checked Then
                    Load_ChuaDuyet()
                    'Bind_Data()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub mtxt_NgayKT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxt_NgayKT.Validated
        If (vEvent = "Edit" Or vEvent = "Add") Then
            Exit Sub
        Else
            Try
                If (chxDaDuyet.Checked = True) Then
                    Load_Daduyet()
                    Bind_Data()
                End If
                If chxChuaDuyet.Checked Then
                    Load_ChuaDuyet()
                    Bind_Data()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub


#End Region

#Region "Kiem tra rang buoc du lieu "

    'Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
    '    Select Case (keyData And Keys.KeyCode)
    '        Case Keys.Return
    '            gv_ChiTietVT.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '            gv_ChiTietVT.EndEdit()
    '            ' gv_ChiTietVT.OnRowValidating(New DataGridViewCellCancelEventArgs(gv_ChiTietVT.CurrentCell.ColumnIndex, gv_ChiTietVT.CurrentCell.RowIndex))
    '            ' gv_ChiTietVT.OnRowValidated(New DataGridViewCellEventArgs(gv_ChiTietVT.CurrentCell.ColumnIndex, gv_ChiTietVT.CurrentCell.RowIndex))
    '            Exit Select
    '        Case Keys.Tab
    '            gv_ChiTietVT.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '            gv_ChiTietVT.EndEdit()
    '            ' gv_ChiTietVT.OnRowValidating(New DataGridViewCellCancelEventArgs(gv_ChiTietVT.CurrentCell.ColumnIndex, gv_ChiTietVT.CurrentCell.RowIndex))
    '            ' gv_ChiTietVT.OnRowValidated(New DataGridViewCellEventArgs(gv_ChiTietVT.CurrentCell.ColumnIndex, gv_ChiTietVT.CurrentCell.RowIndex))
    '            Exit Select
    '    End Select

    'End Function



    Private Sub gv_ChiTietVT_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_ChiTietVT.CellValidating
        Try



            '    gv_ChiTietVT.CommitEdit(DataGridViewDataErrorContexts.Commit)
            '    gv_ChiTietVT.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1


            '    Exit Sub
            'End If
            ' Kiểm tra số lượng
            If Not bt_HuyVT.Focused Then
                If (gv_ChiTietVT.CurrentCell.Selected = gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").Selected) Then

                    Try

                        If clsCheckValuecell.Check_Value_CellUpO(sender, e) = False Then
                            Exit Sub
                        End If
                        gv_ChiTietVT.EndEdit()
                        If gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").FormattedValue.Equals("") Then
                            MessageBox.Show(gv_ChiTietVT.Columns("NGOAI_TE").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                            e.Cancel = True
                            Exit Sub
                        Else
                            If (Not gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Value.Equals("")) Then
                                If (gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Value.Equals("VND")) Then
                                    gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Value = 1
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double)
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("TI_GIA").FormattedValue, Double)
                                Else
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("TI_GIA").FormattedValue, Double)
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double)
                                End If

                            Else

                                gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                                gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = 0
                                gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Value = 0

                            End If

                        End If
                        '  End If
                    Catch ex As Exception
                        e.Cancel = True
                    End Try
                End If


                If (gv_ChiTietVT.CurrentCell.Selected = gv_ChiTietVT.CurrentRow.Cells("DVT").Selected) Then
                    gv_ChiTietVT.EndEdit()
                    If gv_ChiTietVT.CurrentRow.Cells("DVT").FormattedValue.Equals("") Then
                        MessageBox.Show(gv_ChiTietVT.Columns("DVT").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                ' Kiểm tra đơn giá
                If (gv_ChiTietVT.CurrentCell.Selected = gv_ChiTietVT.CurrentRow.Cells("DON_GIA").Selected) Then
                    Try

                        If clsCheckValuecell.Check_Value_CellUpO(sender, e) = False Then
                            Exit Sub
                        End If
                        ' If (gv_ChiTietVT.CurrentCell.Selected = gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Selected) Then
                        gv_ChiTietVT.EndEdit()
                        If gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").FormattedValue.Equals("") Then
                            MessageBox.Show(gv_ChiTietVT.Columns("NGOAI_TE").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                            e.Cancel = True
                            Exit Sub
                        Else

                            If (Not gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Value.Equals("")) Then
                                If (gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Value.Equals("VND")) Then
                                    gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Value = 1
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double)
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("TI_GIA").FormattedValue, Double)
                                Else
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("TI_GIA").FormattedValue, Double)
                                    gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double)
                                End If

                            Else
                                gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                                gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = 0
                                gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Value = 0

                            End If

                        End If
                        '  End If
                    Catch ex As Exception
                        e.Cancel = True
                    End Try


                End If

                ' Kiểm tra ngoại tệ
                If (gv_ChiTietVT.CurrentCell.Selected = gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Selected Or gv_ChiTietVT.CurrentCell.Selected = gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Selected) Then
                    If clsCheckValuecell.Check_Value_CellUpO(sender, e) = False Then
                        Exit Sub
                    End If

                    Dim vtigia As Double = 0
                    If (Not gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Value.Equals("")) Then
                        Dim vNTT As String = gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").FormattedValue
                        gv_ChiTietVT.EndEdit()
                        Dim vNTS As String = gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").FormattedValue
                        If vNTT <> vNTS Then
                            For Each vrow As DataRow In clsMain1.GetNgoaite().Select("NGOAI_TE = '" & gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").FormattedValue & "'")
                                vtigia = vrow("TI_GIA")
                            Next
                            gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Value = vtigia
                        End If
                        If gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").FormattedValue.Equals("") Then
                            MessageBox.Show(gv_CTDV.Columns("NGOAI_TE").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                            e.Cancel = True
                            Exit Sub
                        End If
                        If (gv_ChiTietVT.CurrentRow.Cells("NGOAI_TE").Value.Equals("VND")) Then
                            gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Value = 1
                            gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double)
                            gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("TI_GIA").FormattedValue, Double)
                        Else
                            gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("TI_GIA").FormattedValue, Double)
                            gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = CType(gv_ChiTietVT.CurrentRow.Cells("SO_LUONG").FormattedValue, Double) * CType(gv_ChiTietVT.CurrentRow.Cells("DON_GIA").FormattedValue, Double)
                        End If
                    Else
                        gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                        gv_ChiTietVT.CurrentRow.Cells("THANH_TIEN_NT").Value = 0
                        gv_ChiTietVT.CurrentRow.Cells("TI_GIA").Value = 0

                    End If
                    'End If
                    Try
                        Dim vtongCong As Double = 0
                        For Each gvrow As DataGridViewRow In gv_ChiTietVT.Rows
                            vtongCong = vtongCong + CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("THANH_TIEN").Value, Double)
                        Next
                        txt_TongCong.Text = vtongCong.ToString("###,###,###.##")

                        ' gv_ChiTietVT.Update()
                        'gv_ChiTietVT.EndEdit()
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub gv_CTDV_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gv_CTDV.CellValidating

        If Not bt_HuyDV.Focused Then


            Try
                ' Kiểm tra Tên dịch vụ
                If (gv_CTDV.CurrentCell.Selected = gv_CTDV.CurrentRow.Cells("TEN_DICH_VU").Selected) Then
                    gv_CTDV.EndEdit()
                    If gv_CTDV.CurrentRow.Cells("TEN_DICH_VU").FormattedValue.Equals("") Then
                        MessageBox.Show(gv_CTDV.Columns("TEN_DICH_VU").HeaderText & " không được được để trống!", "Thông báo", MessageBoxButtons.OK)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                ' Kiểm tra số lượng
                If (gv_CTDV.CurrentCell.Selected = gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").Selected) Then
                    Try
                        If clsCheckValuecell.Check_Value_CellUpO(sender, e) = False Then
                            Exit Sub
                        End If

                        gv_CTDV.EndEdit()
                        If gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").FormattedValue.Equals("") Then
                            'MessageBox.Show(gv_CTDV.Columns("NGOAI_TE_DV").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                            'e.Cancel = True
                            'Exit Sub
                        Else
                            If (Not gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Value.Equals("")) Then

                                If (gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Value.Equals("VND")) Then
                                    gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = 1
                                    gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double)
                                    gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("TI_GIA_DV").FormattedValue, Double)
                                Else
                                    gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("TI_GIA_DV").FormattedValue, Double)
                                    gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double)
                                End If
                            Else
                                gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                                gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = 0
                                gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = 0

                            End If
                        End If
                    Catch ex As Exception
                        e.Cancel = True
                    End Try
                End If

                If (gv_CTDV.CurrentCell.Selected = gv_CTDV.CurrentRow.Cells("DVT_DV").Selected) Then
                    gv_CTDV.EndEdit()
                    If gv_CTDV.CurrentRow.Cells("DVT_DV").FormattedValue.Equals("") Then
                        MessageBox.Show(gv_CTDV.Columns("DVT_DV").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                ' Kiểm tra đơn giá
                If (gv_CTDV.CurrentCell.Selected = gv_CTDV.CurrentRow.Cells("DON_GIA_DV").Selected) Then
                    If clsCheckValuecell.Check_Value_CellUpO(sender, e) = False Then
                        Exit Sub
                    End If

                    gv_CTDV.EndEdit()
                    If gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").FormattedValue.Equals("") Then
                        'MessageBox.Show(gv_CTDV.Columns("NGOAI_TE_DV").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                        'e.Cancel = True
                        'Exit Sub
                    Else
                        Dim vtigia As Double = 0
                        If (Not gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Value.Equals("")) Then

                            If (gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Value.Equals("VND")) Then
                                gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = 1
                                gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double)
                                gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("TI_GIA_DV").FormattedValue, Double)
                            Else
                                gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("TI_GIA_DV").FormattedValue, Double)
                                gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double)
                            End If

                        Else

                            gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                            gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = 0
                            gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = 0

                        End If

                    End If
                End If


                ' Kiểm tra ngoại tệ
                If (gv_CTDV.CurrentCell.Selected = gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Selected Or gv_CTDV.CurrentCell.Selected = gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Selected) Then
                    If clsCheckValuecell.Check_Value_CellUpO(sender, e) = False Then
                        Exit Sub
                    End If

                    Dim vtigia As Double = 0
                    If (Not gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Value.Equals("")) Then
                        Dim vNTT As String = gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").FormattedValue
                        gv_CTDV.EndEdit()
                        Dim vNTS As String = gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").FormattedValue
                        If vNTT <> vNTS Then
                            For Each vrow As DataRow In clsMain1.GetNgoaite().Select("NGOAI_TE = '" & gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").FormattedValue & "'")
                                vtigia = vrow("TI_GIA")
                            Next
                            gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = vtigia
                        End If
                        If gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").FormattedValue.Equals("") Then
                            MessageBox.Show(gv_CTDV.Columns("NGOAI_TE_DV").HeaderText & " không được để trống ", "Thông báo", MessageBoxButtons.OK)
                            e.Cancel = True
                            Exit Sub
                        End If
                        If (gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Value.Equals("VND")) Then
                            gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = 1
                            gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double)
                            gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("TI_GIA_DV").FormattedValue, Double)
                        Else
                            gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("TI_GIA_DV").FormattedValue, Double)
                            gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = CType(gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").FormattedValue, Double) * CType(gv_CTDV.CurrentRow.Cells("DON_GIA_DV").FormattedValue, Double)
                        End If
                    Else
                        gv_CTDV.CurrentRow.Cells("THANH_TIEN_DV").Value = 0 'CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("SO_LUONG").Value, Double) * CType(gv_ChiTietVT.Rows(gvrow.Index).Cells("DON_GIA").Value, Double) * vtigia
                        gv_CTDV.CurrentRow.Cells("THANH_TIEN_QD_DV").Value = 0
                        gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = 0

                    End If
                    'End If

                End If
                Try
                    Dim vtongCong As Double = 0
                    For Each gvrow As DataGridViewRow In gv_CTDV.Rows
                        vtongCong = vtongCong + CType(gv_CTDV.Rows(gvrow.Index).Cells("THANH_TIEN_DV").Value, Double)
                    Next
                    txt_tongcongDV.Text = vtongCong.ToString("###,###,###.##")

                Catch ex As Exception
                End Try

            Catch ex As Exception
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub mtxt_NgayLap_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxt_NgayLap.Validating
        If bt_Huy.Focused = True Then
            Exit Sub
        End If

        If (vEvent = "Add" Or vEvent = "Edit") Then
            clsCheckDate.ChecKed_Value_Date(sender, e)
            Try
                If (DateTime.ParseExact(mtxt_NgayLap.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture) > DateTime.Now()) Then
                    MessageBox.Show("Ngày lập phiếu phải nhỏ hơn ngày hiện tại", "thông báo", MessageBoxButtons.OK)
                    e.Cancel = True
                End If
            Catch ex As Exception
                e.Cancel = True
            End Try

        End If
    End Sub

    Private Sub txt_maKHg_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_maKHg.Validating
        If bt_Huy.Focused = True Then
            Exit Sub
        End If
        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (txt_maKHg.Text.Trim().Equals("")) Then
                MessageBox.Show("Khách hàng không đuợc để trống " & vbCrLf & "-Bạn vui lòng kiểm tra lại!" & vbCrLf & "Nhấn Enter để mở form chọn khách hàng", "Thông báo", MessageBoxButtons.OK)
                e.Cancel = True
                txt_maKHg.Focus()
            Else
                If (Check_KhachHang(txt_maKHg.Text) = False) Then
                    MessageBox.Show("Mã Khách hàng này chưa đúng!" & vbCrLf & "-Bạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK)
                    e.Cancel = True
                    txt_maKHg.Focus()
                    txt_DiaChi.Text = ""
                    txt_nguoiLH.Text = ""
                    mtxt_DienThoai.Text = ""
                    mtxt_Fax.Text = ""

                End If
            End If
        End If
    End Sub

    Private Function Check_KhachHang(ByVal vmadx As String) As Boolean
        Try
            Dim vCon As SqlConnection = New SqlConnection()
            Dim sql As String = "Select * FROM Khach_hang "
            Dim tbTem As DataTable = New DataTable()
            If (clsConnect.OpenConnect(vCon)) Then
                Dim vCmd As SqlDataAdapter = New SqlDataAdapter()
                vCmd.SelectCommand = New SqlCommand(sql, vCon)
                vCmd.Fill(tbTem)
            End If

            Dim vRowTem As DataRow
            For Each vRowTem In tbTem.Rows
                If (vmadx = vRowTem("MS_KH").ToString()) Then
                    Try
                        txt_TenKHg.Text = vRowTem("TEN_CONG_TY")
                        txt_DiaChi.Text = vRowTem("DIA_CHI")
                        txt_nguoiLH.Text = vRowTem("TEN_NDD")
                        mtxt_DienThoai.Text = vRowTem("TEL")
                        mtxt_Fax.Text = vRowTem("FAX")
                    Catch ex As Exception
                    End Try
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub txt_SoDeXuat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_SoDeXuat.Validating

        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (Not txt_SoDeXuat.Text.Trim().Equals("")) Then
                If (Check_SoDeXuat(txt_SoDeXuat.Text) = True) Then
                    MessageBox.Show("Số đề xuất này chưa có!" & vbCrLf & "-Nếu không nhớ bạn có thể để trống ! " & vbCrLf & "Hoặc Nhấn Enter để lựa chọn ", "Thông báo", MessageBoxButtons.OK)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub txt_SoDeXuat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SoDeXuat.KeyDown
        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (e.KeyValue = Keys.Enter) Then
                Dim frmform As frmDeXuat = New frmDeXuat()

                frmform.ShowDialog()
                txt_SoDeXuat.Text = frmDeXuat.vSoDX
                'MessageBox.Show(frmDeXuat.vSoDX)

            End If
        End If
    End Sub

    Private Sub txt_NoiDung_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_NoiDung.Validating
        If bt_Huy.Focused = True Then
            Exit Sub
        End If
        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (txt_NoiDung.Text.Trim().Equals("")) Then
                MessageBox.Show("Nội dung không được để trống", "Thông báo", MessageBoxButtons.OK)
                e.Cancel = True
            End If
        Else
        End If
    End Sub

    Private Sub txt_SoDDH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_SoDDH.Validating
        If (bt_Huy.Focused = True) Then
            Exit Sub
        End If

        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (txt_SoDDH.Text.Trim().Equals("")) Then
                MessageBox.Show("Số đơn đặt hàng không được để trống", "Thông báo", MessageBoxButtons.OK)
                txt_SoDDH.Focus()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txt_NguoiDH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_NguoiDH.Validating
        If bt_Huy.Focused = True Then
            Exit Sub
        End If

        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (txt_NguoiDH.Text.Trim().Equals("")) Then
                MessageBox.Show("Người đặt hàng không được để trống", "Thông báo", MessageBoxButtons.OK)
                txt_NguoiDH.Focus()
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub mtxt_NgayGiao_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxt_NgayGiao.Validating
        If bt_Huy.Focused = True Then
            Exit Sub
        End If
        If (vEvent = "Add" Or vEvent = "Edit") Then
            clsCheckDate.ChecKed_Value_Date(sender, e)
            Try
                If (DateTime.ParseExact(mtxt_NgayLap.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture) > DateTime.ParseExact(mtxt_NgayGiao.Text, "dd/MM/yyyy", Globalization.CultureInfo.CurrentUICulture)) Then
                    MessageBox.Show("Ngày giao phải lớn hơn Ngày lập phiếu", "thông báo", MessageBoxButtons.OK)
                    e.Cancel = True
                End If
            Catch ex As Exception
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub txt_DC_Giao_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DC_Giao.Validating
        If bt_Huy.Focused = True Then
            Exit Sub
        End If
        If (vEvent = "Add" Or vEvent = "Edit") Then
            If (txt_DC_Giao.Text.Trim().Equals("")) Then
                MessageBox.Show("Địa chỉ giao không được bỏ trống", "Thông báo", MessageBoxButtons.OK)
                e.Cancel = True
            End If
        End If
    End Sub

    'Private Sub txt_HT_TT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If bt_Huy.Focused = True Then
    '        Exit Sub
    '    End If

    '    If (vEvent = "Add" Or vEvent = "Edit") Then
    '        If (txt_HT_TT.Text.Trim().Equals("")) Then
    '            MessageBox.Show("Hình thức thanh toán không được bỏ trống", "Thông báo", MessageBoxButtons.OK)
    '            e.Cancel = True
    '        End If
    '    End If
    'End Sub

    Private Sub gv_CTDV_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gv_CTDV.EditingControlShowing

        'If (gv_CTDV.CurrentCell.Selected = gv_CTDV.CurrentRow.Cells("SO_LUONG_DV").Selected) Then
        '    AddHandler e.Control.KeyPress, AddressOf Me.gvKey_KeyPress
        'End If
    End Sub

    Private Sub gvKey_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Not Char.IsControl(e.KeyChar)) Then
            If (Not Char.IsSeparator(e.KeyChar)) Then
                If (Not Char.IsDigit(e.KeyChar)) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub bt_In_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_In.Click
        Try
            Dim vDSTem As DataSet = New DataSet()
            Dim vConect As SqlConnection = New SqlConnection()
            Dim vCmd As SqlCommand = New SqlCommand()
            Dim CMD As SqlCommand = New SqlCommand()
            Dim CMD1 As SqlCommand = New SqlCommand()
            Try
                If (clsConnect.OpenConnect(vConect)) Then
                    vCmd.Connection = vConect
                    vCmd.CommandType = CommandType.StoredProcedure
                    vCmd.CommandText = "prtDonDatHang"
                    vCmd.Parameters.Add(New SqlParameter("@MS_DDH", SqlDbType.NVarChar, 30)).Value = txt_Ma_DDH.Text
                    Dim vAdapter As SqlDataAdapter = New SqlDataAdapter(vCmd)
                    vAdapter.Fill(vDSTem, "CHI_TIET_DDH")
                    'Lay thong tin chung 
                    CMD.Connection = vConect
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.CommandText = "getThongTinChung"
                    vAdapter = New SqlDataAdapter(CMD)
                    vAdapter.Fill(vDSTem, "THONG_TIN_CHUNG")

                    CMD1.Connection = vConect
                    CMD1.CommandType = CommandType.StoredProcedure
                    CMD1.CommandText = "GetDON_DAT_HANG"
                    CMD1.Parameters.Add(New SqlParameter("@MS_DDH", SqlDbType.NVarChar, 30)).Value = txt_Ma_DDH.Text
                    Dim vAdapter1 As SqlDataAdapter = New SqlDataAdapter(CMD1)
                    vAdapter1.Fill(vDSTem, "DON_DAT_HANG")
                    'Ghi file XML 
                    'vDSTem.WriteXmlSchema("XML\xmlDonDatHang.xml")

                    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    rpt.Load(Application.StartupPath & "\reports\rptDonDatHang.rpt")
                    rpt.SetDataSource(vDSTem)

                    Dim frmRP As frmReport = New frmReport()
                    frmRP.WindowState = FormWindowState.Maximized
                    frmRP.rptView.ReportSource = rpt
                    frmRP.Show()

                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_Control_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tb_Control.Selecting

        If vEventDV <> "N" Or vEvent <> "N" Or vEventVT <> "N" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub txt_SoDDH_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SoDDH.Validated
        txt_SoDDH.Text = txt_SoDDH.Text.Trim()
    End Sub

    Private Sub txt_NoiDung_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NoiDung.Validated
        txt_NoiDung.Text = txt_NoiDung.Text.Trim()
    End Sub

    Private Sub txt_maKHg_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_maKHg.Validated
        txt_maKHg.Text = txt_maKHg.Text.Trim()
    End Sub

    Private Sub txt_NguoiDH_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NguoiDH.Validated
        txt_NguoiDH.Text = txt_NguoiDH.Text.Trim()
    End Sub

    Private Sub txt_nguoiXNhan_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nguoiXNhan.Validated
        txt_nguoiXNhan.Text = txt_nguoiXNhan.Text.Trim()
    End Sub

    Private Sub txt_NguoiDuyet_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NguoiDuyet.Validated
        txt_NguoiDuyet.Text = txt_NguoiDuyet.Text.Trim()
    End Sub

    Private Sub txt_TG_BH_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_TG_BH.Validated
        txt_TG_BH.Text = txt_TG_BH.Text.Trim()
    End Sub

    'Private Sub txt_GhiChu_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txt_GhiChu.Text = txt_GhiChu.Text.Trim()
    'End Sub

    Private Sub txt_nguoiLH_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nguoiLH.Validated
        txt_nguoiLH.Text = txt_nguoiLH.Text.Trim()
    End Sub

    Private Sub gv_CTDV_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_CTDV.CellValueChanged
        'Try
        '    If gv_CTDV.Rows(e.RowIndex).Cells("NGOAI_TE_DV").Selected Then
        '        Dim vtigia As Double = 0

        '        'MessageBox.Show(gv_CTDV.Rows(e.RowIndex).Cells("NGOAI_TE_DV").Value)
        '        'gv_CTDV.EndEdit()
        '        'MessageBox.Show(gv_CTDV.Rows(e.RowIndex).Cells("NGOAI_TE_DV").FormattedValue)

        '        If (Not gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").Value.Equals("")) Then
        '            For Each vrow As DataRow In clsMain.GetNgoaite().Select("NGOAI_TE = '" & gv_CTDV.CurrentRow.Cells("NGOAI_TE_DV").FormattedValue & "'")
        '                vtigia = vrow("TI_GIA")
        '            Next
        '            gv_CTDV.CurrentRow.Cells("TI_GIA_DV").Value = vtigia


        '        End If
        '    End If

        'Catch ex As Exception

        'End Try  
    End Sub

#End Region

    Private Sub gv_ChiTietVT_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gv_ChiTietVT.ColumnHeaderMouseClick
        Try
            gv_ChiTietVT.SelectionMode = DataGridViewSelectionMode.CellSelect
        Catch ex As Exception

        End Try


    End Sub

    Private Sub gv_ChiTietVT_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_ChiTietVT.CellEnter
        Try
            'If e.ColumnIndex = 0 Then
            '    gv_ChiTietVT.CurrentCell = gv_ChiTietVT.Rows(e.RowIndex).Cells(1)
            'End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_ChiTietVT_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gv_ChiTietVT.DataError
        Try
            If bt_HuyVT.Focused Then
                CType(gv_ChiTietVT.DataSource, DataTable).RejectChanges()
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_CTDV_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles gv_CTDV.DataError
        Try
            If bt_HuyDV.Focused Then
                ' CType(gv_CTDV.DataSource, DataTable).RejectChanges()
                'vTbCT_Dv.RejectChanges()
                'TinhToan_DV()
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bt_ThoatDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ThoatDV.Click
        Me.Close()
    End Sub

    Private Sub bt_ThoatVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ThoatVT.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_DuyetMua.Click
        Try
            Dim vD As Integer = 0
            Dim vD1 As Integer = 0
            Dim vD2 As Integer = 0
            Dim vD3 As Integer = 0
            Dim vD4 As Integer = 0
            Dim vTT As Integer = 0

            If (chx_DuyetMua.Checked) Then
                vD1 = 1
                vTT = 1
            Else
                vD1 = 0
            End If
            If (chx_DuyetMua2.Checked) Then
                vD2 = 1
                vTT = 1
            Else
                vD2 = 0
            End If
            If (chx_DuyetMua3.Checked) Then
                vD3 = 1
                vTT = 1
            Else
                vD3 = 0
            End If
            If (chx_DuyetMua4.Checked) Then
                vD4 = 1
                vTT = 1
                vD = 1
            Else
                vD4 = 0
                vTT = 1
                vD = 0
            End If

            If chx_DuyetMua.Checked = False And chx_DuyetMua2.Checked = False And chx_DuyetMua3.Checked = False And chx_DuyetMua4.Checked = False Then
                vTT = 0
                vD = 0
            End If

            Dim str As String = " UPDATE  DON_DAT_HANG" & _
                    " SET DUYET1 = '" & vD1 & "', YKIEN_DUYET =  N'" & txt_YKien.Text & "', DUYET2 = '" & vD2 & "', YKIEN_DUYET2 = N'" & txt_YKien2.Text & "'" & _
                    " , DUYET3 = '" & vD3 & "', YKIEN_DUYET3 = N'" & txt_YKien3.Text & "', DUYET4 = '" & vD4 & "', YKIEN_DUYET4 = N'" & txt_YKien4.Text & " '" & _
                    " , DUYET = '" & vD & "',TRANGTHAI  = '" & vTT & "'" & _
                    "  WHERE MS_DDH = '" & txt_Ma_DDH.Text & "'"

            'Dim vsqlStr As String = "UPDATE DON_DAT_HANG  SET DUYET = '" & vD & "',YKIEN_DUYET = '" & txt_YKien.Text & "' WHERE (MS_DDH = '" & txt_Ma_DDH.Text & "' )"
            Dim vSqlcon As SqlConnection = New SqlConnection()
            If (clsConnect.OpenConnect(vSqlcon)) Then
                Dim vCmd As SqlCommand = New SqlCommand(str, vSqlcon)
                vCmd.ExecuteNonQuery()
                MessageBox.Show("Bạn đã duyệt thành công !", "Thông báo", MessageBoxButtons.OK)

                If chx_DuyetMua4.Checked = True Then
                    bt_DuyetMua.Enabled = False
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bt_ThoatDuyet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ThoatDuyet.Click
        Me.Close()
    End Sub

    Private Sub txt_GhiChu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class