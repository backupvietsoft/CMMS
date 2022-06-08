
Imports Microsoft.ApplicationBlocks.Data

Public Class FrmChonThamDinhTB

    Private vDenNgay As DateTime
    Private vTuNgay As DateTime

    Private Sub FrmChonThamDinhTB_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Commons.Modules.ObjSystems.XoaTable("THAM_DINH_THIET_BI_TMP")
    End Sub

    Private Sub FrmChonThamDinhTB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mtxtTuNgay.Text = DateTime.Now.AddYears(-1).Date.ToString("dd/MM/yyyy")
        mtxtDenNgay.Text = DateTime.Now.Date.ToString("dd/MM/yyyy")
        load_NhaXuong()
    End Sub

    Sub load_NhaXuong()
        cbxNhaXuong.Value = "MS_N_XUONG"
        cbxNhaXuong.Display = "TEN_N_XUONG"
        cbxNhaXuong.StoreName = "GetNHA_XUONGs"
        cbxNhaXuong.Param = Commons.Modules.UserName
        cbxNhaXuong.BindDataSource()

    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Try
            'kiểm tra nhà xưởng
            Try
                If cbxNhaXuong.Text.ToString.Trim.Equals("") Then
                    'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "ChuaChonN_XUONG", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    MessageBox.Show("Bạn chưa chọn nhà xưởng")
                    cbxNhaXuong.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
            'kiểm tra Từ ngày 
            Try
                If mtxtTuNgay.Text.ToString.Trim.Equals("/  /") Then
                    'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TuNgayChuaChonNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    MessageBox.Show("Bạn chưa chọn Từ ngày")
                    mtxtTuNgay.Focus()
                    Exit Sub
                Else
                    vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                End If
            Catch ex As Exception
                'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TuNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                MessageBox.Show("Từ ngày chưa đúng định dạng")
                mtxtTuNgay.Focus()
                Exit Sub
            End Try
            'kiểm tra đến ngày 
            Try
                If mtxtDenNgay.Text.ToString.Trim.Equals("/  /") Then
                    'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TuNgayChuaChonNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                    MessageBox.Show("Bạn chưa chọn Đến ngày")
                    mtxtDenNgay.Focus()
                    Exit Sub
                Else
                    vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
                End If
            Catch ex As Exception
                'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DenNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                MessageBox.Show("Đến ngày chưa đúng định dạng")
                mtxtDenNgay.Focus()
                Exit Sub
            End Try

            Dim vTbData As System.Data.DataTable = New System.Data.DataTable("vTbData")
            vTbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_getThamDinhThietBi", vTuNgay, vDenNgay, cbxNhaXuong.SelectedValue.ToString))
            If vTbData.Rows.Count > 0 Then
                Dim frm As frmShowXMLReport = New frmShowXMLReport()
                frm.AddDataTableSource(vTbData)
                frm.AddDataTableSource(RefeshLanguageReport())
                frm.rptName = "rptThamDinhThietBi"
                frm.Show()
            Else
                MessageBox.Show("Không có dữ liệu để In")
                Exit Sub
            End If

            ' cbxChonXuong.DataSource = vTbData

        Catch ex As Exception
        End Try
    End Sub

    Function RefeshLanguageReport() As DataTable
        Dim TEN_CTY, PHONG_BAN, TIEU_DE, TU_NGAY, DEN_NGAY, TDE_XUONG, TENXUONG, STT, TEN_MAY, MS_MAY, NGAY, THAM_DINH, NGUOI_TD, SAN_PHAM, SOLO, GHI_CHU As String

        Dim vTBNgonNgu As DataTable = New DataTable()

        TEN_CTY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "TEN_CTY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TEN_CTY", Type.GetType("System.String"))

        PHONG_BAN = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "PHONG_BAN", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("PHONG_BAN", Type.GetType("System.String"))

        TIEU_DE = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "TIEU_DE", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TIEU_DE", Type.GetType("System.String"))

        TU_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "TU_NGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TU_NGAY", Type.GetType("System.String"))

        DEN_NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "DEN_NGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("DEN_NGAY", Type.GetType("System.String"))

        TDE_XUONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "TDE_XUONG", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TDE_XUONG", Type.GetType("System.String"))

        TENXUONG = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "TENXUONG", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TENXUONG", Type.GetType("System.String"))

        'TUNGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "TUNGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TUNGAY", Type.GetType("System.String"))

        'DENNGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptKeHoachPhanCongBT", "DENNGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("DENNGAY", Type.GetType("System.String"))

        STT = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "STT", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("STT", Type.GetType("System.String"))

        TEN_MAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "TEN_MAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("TEN_MAY", Type.GetType("System.String"))

        MS_MAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "MS_MAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("MS_MAY", Type.GetType("System.String"))

        NGAY = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "NGAY", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("NGAY", Type.GetType("System.String"))

        THAM_DINH = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "THAM_DINH", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("THAM_DINH", Type.GetType("System.String"))

        NGUOI_TD = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "NGUOI_TD", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("NGUOI_TD", Type.GetType("System.String"))

        SAN_PHAM = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "SAN_PHAM", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("SAN_PHAM", Type.GetType("System.String"))

        SOLO = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "SOLO", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("SOLO", Type.GetType("System.String"))

        GHI_CHU = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, "rptThamDinhThietBi", "GHI_CHU", commons.Modules.TypeLanguage)
        vTBNgonNgu.Columns.Add("GHI_CHU", Type.GetType("System.String"))

        Dim rowNew As DataRow = vTBNgonNgu.NewRow()

        rowNew("TEN_CTY") = TEN_CTY
        rowNew("PHONG_BAN") = PHONG_BAN
        rowNew("TIEU_DE") = TIEU_DE
        rowNew("TU_NGAY") = TU_NGAY
        rowNew("DEN_NGAY") = DEN_NGAY
        rowNew("TDE_XUONG") = TDE_XUONG
        rowNew("TENXUONG") = cbxNhaXuong.Text
        rowNew("TUNGAY") = mtxtTuNgay.Text
        rowNew("DENNGAY") = mtxtDenNgay.Text
        rowNew("STT") = STT
        rowNew("TEN_MAY") = TEN_MAY
        rowNew("MS_MAY") = MS_MAY
        rowNew("NGAY") = NGAY
        rowNew("THAM_DINH") = THAM_DINH
        rowNew("NGUOI_TD") = NGUOI_TD
        rowNew("SAN_PHAM") = SAN_PHAM
        rowNew("SOLO") = SOLO
        rowNew("GHI_CHU") = GHI_CHU
        vTBNgonNgu.Rows.Add(rowNew)
        Return vTBNgonNgu
    End Function

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating

        If btnThoat.Focused = True Then
            Me.Close()
            Exit Sub
        End If
        If mtxtTuNgay.Text.ToString.Trim.Equals("/  /") Then
            Exit Sub
        End If

        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TuNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            MessageBox.Show("Từ ngày chưa đúng định dạng")
            e.Cancel = True
        End Try


        Try
            Dim vDenNgay As DateTime = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            If vTuNgay > vDenNgay Then
                'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TuNgayPhaiNhoHonDenNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                MessageBox.Show("Từ ngày phải nhỏ hơn đến ngày")
                e.Cancel = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        If btnThoat.Focused = True Then
            Me.Close()
            Exit Sub
        End If
        If mtxtDenNgay.Text.ToString.Trim.Equals("/  /") Then
            Exit Sub
        End If
        Try
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DenNgayChuaDungDD", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
            MessageBox.Show("Đến ngày chưa đúng định dạng")
            e.Cancel = True
        End Try

        Try
            If vDenNgay > DateTime.Now.Date Then
                'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TuNgayPhaiLonHonNgayHienTai", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                MessageBox.Show("Đến ngày phải nhỏ hơn ngày hiện tại !")
                e.Cancel = True
            End If
        Catch ex As Exception
        End Try
        Try
            Dim vTuNgay As DateTime = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            If vTuNgay > vDenNgay Then
                'MsgBox(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DenNgayPhaiLonHonTuNgay", commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation)
                MessageBox.Show("Đến ngày phải lớn hơn từ ngày")
                e.Cancel = True
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class