
Imports Microsoft.ApplicationBlocks.Data
Imports Excel
Imports System.Windows.Forms

Public Class frmrptThongKeThoiGianNgungMayTheoNguyenNhan
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime
    Dim v_all As System.Data.DataTable = New System.Data.DataTable()
    Private Sub frmrptThongKeThoiGianNgungMayTheoNguyenNhan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoadNhaXuong()
        LoadCity()
        'LoadHeThong()

        vDenNgay = DateTime.Now.Date
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        AddHandler cboNhaxuong.SelectedIndexChanged, AddressOf Me.cboNhaxuong_SelectedIndexChanged

    End Sub

    Sub LoadNhaXuong()
        'cboNhaxuong.Value = "MS_N_XUONG"
        'cboNhaxuong.Display = "TEN_N_XUONG"
        'cboNhaxuong.StoreName = "H_TGNM_GET_NX"
        'cboNhaxuong.BindDataSource()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", Commons.Modules.UserName, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString()))
        cboNhaxuong.DisplayMember = "TEN_N_XUONG"
        cboNhaxuong.ValueMember = "MS_N_XUONG"
        cboNhaxuong.DataSource = _table
    End Sub

    Sub LoadHeThong()
        v_all = New System.Data.DataTable()
        'cboHeThong.Value = "MS_HE_THONG"
        'cboHeThong.Display = "TEN_HE_THONG"
        'cboHeThong.StoreName = "H_TGNM_GET_HT"
        'cboHeThong.Param = cboNhaxuong.SelectedValue.ToString()
        'cboHeThong.BindDataSource()
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table = Get_HT(cboNhaxuong.SelectedValue.ToString(), cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
        If _table.Rows.Count > 0 Then
            _table = _table.DefaultView.ToTable(True, "MS_HE_THONG", "TEN_HE_THONG")
            cboHeThong.DataSource = _table
            cboHeThong.ValueMember = "MS_HE_THONG"
            cboHeThong.DisplayMember = "TEN_HE_THONG"
        Else
            cboHeThong.DataSource = _table
            cboHeThong.ValueMember = "MS_HE_THONG"
            cboHeThong.DisplayMember = "TEN_HE_THONG"
        End If
    End Sub

    Private Sub cboNhaxuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNhaxuong.SelectedIndexChanged 'Handles cboNhaxuong.SelectedIndexChanged
        LoadHeThong()
    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating
        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Try
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "CHUA_DUNG_DINH_DANG", Commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TN_PHAI_NHO_HON_DN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If
        Dim ms_ht As Integer = -1
        Try
            ms_ht = cboHeThong.SelectedValue.ToString()
        Catch ex As Exception
            ms_ht = -1
        End Try
        Dim vtbData As New System.Data.DataTable
        ' vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_TGNM_THONG_KE_THEO_NN", vTuNgay, vDenNgay, cboNhaxuong.SelectedValue, cboHeThong.SelectedValue))
        v_all = New System.Data.DataTable()
        vtbData = Get_DataTable(cboNhaxuong.SelectedValue.ToString(), vTuNgay, vDenNgay, ms_ht, cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString(), cmbStreet.SelectedValue.ToString())
        If (vtbData.Rows.Count = 0) Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "KO_CO_DL_DE_IN", Commons.Modules.TypeLanguage))
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

        With ExcelSheets

            '.Columns(2).ColumnWidth = 15
            '.Columns(3).ColumnWidth = 20
            .Columns(3).ColumnWidth = 20
            '.Columns(5).ColumnWidth = 20
            '.Columns(6).ColumnWidth = 20
            '.Columns(7).ColumnWidth = 6
            '.Columns(8).ColumnWidth = 6
            '.Columns(9).ColumnWidth = 8
            '.Columns(10).ColumnWidth = 8
            '.Columns(11).ColumnWidth = 8
        End With

        With ExcelSheets
            .Range("A1", "B1").Font.Bold = True
            .Range("A1", "B1").Merge(True)
            .Range("A1", "B1").MergeCells = True
            .Range("A1", "B1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TD1", Commons.Modules.TypeLanguage)
            .Range("A2", "B2").Font.Bold = True
            .Range("A2", "B2").Merge(True)
            .Range("A2", "B2").MergeCells = True
            .Range("A2", "B2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TD2", Commons.Modules.TypeLanguage)
            .Range("A3", "B3").Font.Bold = True
            .Range("A3", "B3").Merge(True)
            .Range("A3", "B3").MergeCells = True
            .Range("A3", "B3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TD3", Commons.Modules.TypeLanguage)
            .Range("A1", "B3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A1", "B3").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A1", "B3").HorizontalAlignment = XlHAlign.xlHAlignCenter

            .Range("C1", "G2").Font.Bold = True
            .Range("C1", "G2").Merge(True)
            .Range("C1", "G2").MergeCells = True
            .Range("C1", "G2").Font.Size = 14
            .Range("C1", "G2").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("C1", "G2").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("C1", "G2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "THONG_KE_TGNM_THEO_NN", Commons.Modules.TypeLanguage)

            .Range("C3", "G3").Font.Bold = True
            .Range("C3", "G3").Merge(True)
            .Range("C3", "G3").MergeCells = True
            .Range("C3", "G3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TU_NGAY", Commons.Modules.TypeLanguage) + "  " + mtxtTuNgay.Text + _
             "  " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "DEN_NGAT", Commons.Modules.TypeLanguage) + " " + mtxtDenNgay.Text
            .Range("C1", "G3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("C1", "G3").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("C1", "G3").HorizontalAlignment = XlHAlign.xlHAlignCenter

            .Range("H1", "H1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "LBCODE", Commons.Modules.TypeLanguage)
            .Range("H1", "H1").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("H2", "H2").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "VDATE", Commons.Modules.TypeLanguage)
            .Range("H2", "H2").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("H3", "H3").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "VPAGE", Commons.Modules.TypeLanguage)
            .Range("H3", "H3").HorizontalAlignment = XlHAlign.xlHAlignLeft

            .Range("I1", "I1").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "CODE", Commons.Modules.TypeLanguage)
            .Range("I1", "I1").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("I2", "I2").Value = DateTime.Now.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            .Range("I2", "I2").HorizontalAlignment = XlHAlign.xlHAlignLeft

            .Range("H1", "I3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            .Range("A5", "I5").Font.Bold = True
            .Range("A5", "I5").Merge(True)
            .Range("A5", "I5").MergeCells = True
            .Range("A5", "I5").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("A5", "I5").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "DIA_DIEM", Commons.Modules.TypeLanguage) + "  " + cboNhaxuong.Text


            .Range("A7", "C7").Font.Bold = True
            .Range("A7", "C7").Merge(True)
            .Range("A7", "C7").MergeCells = True
            .Range("A7", "C7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A7", "C7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A7", "C7").WrapText = True
            .Range("A7", "C7").RowHeight = 26
            .Range("A7", "C7").Interior.Color = RGB(220, 220, 220)
            .Range("A7", "C7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A7", "C7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "NGUYEN_NHAN", Commons.Modules.TypeLanguage)

            .Range("D7", "E7").Font.Bold = True
            .Range("D7", "E7").Merge(True)
            .Range("D7", "E7").MergeCells = True
            .Range("D7", "E7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("D7", "E7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("D7", "E7").WrapText = True
            .Range("D7", "E7").RowHeight = 26
            .Range("D7", "E7").Interior.Color = RGB(220, 220, 220)
            .Range("D7", "E7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("D7", "E7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TAN_SUAT", Commons.Modules.TypeLanguage)


            .Range("F7", "G7").Font.Bold = True
            .Range("F7", "G7").Merge(True)
            .Range("F7", "G7").MergeCells = True
            .Range("F7", "G7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("F7", "G7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("F7", "G7").WrapText = True
            .Range("F7", "G7").RowHeight = 26
            .Range("F7", "G7").Interior.Color = RGB(220, 220, 220)
            .Range("F7", "G7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F7", "G7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "THOI_GIAN_CHO", Commons.Modules.TypeLanguage)


            .Range("H7", "I7").Font.Bold = True
            .Range("H7", "I7").Merge(True)
            .Range("H7", "I7").MergeCells = True
            .Range("H7", "I7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("H7", "I7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("H7", "I7").WrapText = True
            .Range("H7", "I7").RowHeight = 26
            .Range("H7", "I7").Interior.Color = RGB(220, 220, 220)
            .Range("H7", "I7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H7", "I7").Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "THOI_GIAN_NGUNG", Commons.Modules.TypeLanguage)

        End With

        ''''''''''''PRINT DATA'''''''''''''''''''''''''
        'H_TGNM_GET_DATA_REPORT


        Dim vtbHeThong As New System.Data.DataTable
        vtbHeThong = vtbData.DefaultView.ToTable(True, "MS_HE_THONG", "TEN_HE_THONG")

        Dim vDong As Integer = 8


        Dim vTongDiaDiemCho As Double = 0
        Dim vTongDiaDiemN As Double = 0
        Dim vTongTanSuat As Double = 0

        For Each vrowHT As DataRow In vtbHeThong.Rows
            Dim dvLoaiNN As New System.Data.DataView(vtbData, " MS_HE_THONG = '" + vrowHT("MS_HE_THONG").ToString + "'", "THOI_GIAN_SUA_CHUA", DataViewRowState.CurrentRows)

            Dim vTongHTCho As Double = 0
            Dim vTongHTN As Double = 0
            Dim vTongHTTS As Double = 0

            With ExcelSheets
                .Range("A" & vDong, "I" & vDong).Font.Bold = True
                .Range("A" & vDong, "I" & vDong).Merge(True)
                .Range("A" & vDong, "I" & vDong).MergeCells = True
                .Range("A" & vDong, "I" & vDong).Font.Color = RGB(227, 105, 32)
                .Range("A" & vDong, "I" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                .Range("A" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A" & vDong, "I" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "HE_THONG", Commons.Modules.TypeLanguage) + " " + vrowHT("TEN_HE_THONG").ToString
            End With

            Dim vtbLoaiNN As New System.Data.DataTable
            vtbLoaiNN = dvLoaiNN.ToTable(True, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN")

            For Each vrowLNN As DataRow In vtbLoaiNN.Rows

                vDong = vDong + 1
                With ExcelSheets

                    .Range("A" & vDong, "C" & vDong).Merge(True)
                    .Range("A" & vDong, "C" & vDong).MergeCells = True
                    .Range("A" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("A" & vDong, "C" & vDong).HorizontalAlignment = XlHAlign.xlHAlignRight
                    .Range("A" & vDong, "C" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("A" & vDong, "C" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "LOAI_NGUNG_MAY", Commons.Modules.TypeLanguage) + " " + vrowLNN("TEN_NGUYEN_NHAN").ToString

                    .Range("D" & vDong, "I" & vDong).Font.Bold = True
                    .Range("D" & vDong, "I" & vDong).Merge(True)
                    .Range("D" & vDong, "I" & vDong).MergeCells = True
                    .Range("D" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                End With

                Dim vdataList As New DataView(dvLoaiNN.ToTable(), "MS_NGUYEN_NHAN = '" + vrowLNN("MS_NGUYEN_NHAN").ToString + "'", "THOI_GIAN_SUA_CHUA", DataViewRowState.CurrentRows)

                Dim vTongChoLoai As Double = 0
                Dim vTongNgungLoai As Double = 0
                Dim vTongTSLoai As Double = 0

                For Each vr As DataRow In vdataList.ToTable().Rows

                    vDong = vDong + 1
                    With ExcelSheets
                        .Range("A" & vDong, "C" & vDong).Font.Bold = True
                        .Range("A" & vDong, "C" & vDong).Merge(True)
                        .Range("A" & vDong, "C" & vDong).MergeCells = True
                        .Range("A" & vDong, "C" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        .Range("A" & vDong, "C" & vDong).WrapText = True
                        .Range("A" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("A" & vDong, "C" & vDong).Value = vr("NGUYEN_NHAN")

                        .Range("D" & vDong, "E" & vDong).Merge(True)
                        .Range("D" & vDong, "E" & vDong).MergeCells = True
                        .Range("D" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("D" & vDong, "E" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("D" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("D" & vDong, "E" & vDong).WrapText = True
                        .Range("D" & vDong, "E" & vDong).Value = vr("TAN_SUAT").ToString

                        If vr("THOI_GIAN_CHO").ToString <> "" Then
                            vTongTSLoai = vTongTSLoai + vr("TAN_SUAT")
                            vTongHTTS = vTongHTTS + vr("TAN_SUAT")
                            vTongTanSuat = vTongTanSuat + vr("TAN_SUAT")
                        End If

                        .Range("F" & vDong, "G" & vDong).Merge(True)
                        .Range("F" & vDong, "G" & vDong).MergeCells = True
                        .Range("F" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("F" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("F" & vDong, "G" & vDong).WrapText = True
                        .Range("F" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("F" & vDong, "G" & vDong).Value = vr("THOI_GIAN_CHO")

                        If vr("THOI_GIAN_CHO").ToString <> "" Then
                            vTongChoLoai = vTongChoLoai + vr("THOI_GIAN_CHO")
                            vTongHTCho = vTongHTCho + vr("THOI_GIAN_CHO")
                            vTongDiaDiemCho = vTongDiaDiemCho + vr("THOI_GIAN_CHO")
                        End If

                        .Range("H" & vDong, "I" & vDong).Merge(True)
                        .Range("H" & vDong, "I" & vDong).MergeCells = True
                        .Range("H" & vDong, "I" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("H" & vDong, "I" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("H" & vDong, "I" & vDong).WrapText = True
                        .Range("H" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("H" & vDong, "I" & vDong).Value = vr("THOI_GIAN_SUA_CHUA")

                        If vr("THOI_GIAN_SUA_CHUA").ToString <> "" Then
                            vTongNgungLoai = vTongNgungLoai + vr("THOI_GIAN_SUA_CHUA")
                            vTongHTN = vTongHTN + vr("THOI_GIAN_SUA_CHUA")
                            vTongDiaDiemN = vTongDiaDiemN + vr("THOI_GIAN_SUA_CHUA")
                        End If
                    End With
                Next
                vDong = vDong + 1

                With ExcelSheets
                    .Range("A" & vDong, "C" & vDong).Merge(True)
                    .Range("A" & vDong, "C" & vDong).MergeCells = True
                    .Range("A" & vDong, "C" & vDong).Font.Bold = True
                    .Range("A" & vDong, "C" & vDong).Merge(True)
                    .Range("A" & vDong, "C" & vDong).MergeCells = True
                    .Range("A" & vDong, "C" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("A" & vDong, "C" & vDong).HorizontalAlignment = XlHAlign.xlHAlignRight
                    .Range("A" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("A" & vDong, "C" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TONG_NGUNG_THEO_NN", Commons.Modules.TypeLanguage)

                    .Range("D" & vDong, "E" & vDong).Merge(True)
                    .Range("D" & vDong, "E" & vDong).MergeCells = True
                    .Range("D" & vDong, "E" & vDong).Font.Bold = True
                    .Range("D" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("D" & vDong, "E" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("D" & vDong, "E" & vDong).WrapText = True
                    .Range("D" & vDong, "E" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("D" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("D" & vDong, "E" & vDong).Value = vTongTSLoai.ToString


                    .Range("F" & vDong, "G" & vDong).Merge(True)
                    .Range("F" & vDong, "G" & vDong).MergeCells = True
                    .Range("F" & vDong, "G" & vDong).Font.Bold = True
                    .Range("F" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("F" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("F" & vDong, "G" & vDong).WrapText = True
                    .Range("F" & vDong, "G" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("F" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("F" & vDong, "G" & vDong).Value = vTongChoLoai.ToString

                    .Range("H" & vDong, "I" & vDong).Merge(True)
                    .Range("H" & vDong, "I" & vDong).MergeCells = True
                    .Range("H" & vDong, "I" & vDong).Font.Bold = True
                    .Range("H" & vDong, "I" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("H" & vDong, "I" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("H" & vDong, "I" & vDong).WrapText = True
                    .Range("H" & vDong, "I" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("H" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("H" & vDong, "I" & vDong).Value = vTongNgungLoai.ToString
                End With
            Next ' loainn

            vDong = vDong + 1

            With ExcelSheets
                .Range("A" & vDong, "C" & vDong).Merge(True)
                .Range("A" & vDong, "C" & vDong).MergeCells = True
                .Range("A" & vDong, "C" & vDong).Font.Bold = True
                .Range("A" & vDong, "C" & vDong).Merge(True)
                .Range("A" & vDong, "C" & vDong).MergeCells = True
                .Range("A" & vDong, "C" & vDong).Font.Color = RGB(220, 12, 26)
                .Range("A" & vDong, "C" & vDong).HorizontalAlignment = XlHAlign.xlHAlignRight
                .Range("A" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A" & vDong, "C" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TONG_NGUNG_THEO_DAY_CHUYEN", Commons.Modules.TypeLanguage)

                .Range("D" & vDong, "E" & vDong).Merge(True)
                .Range("D" & vDong, "E" & vDong).MergeCells = True
                .Range("D" & vDong, "E" & vDong).Font.Bold = True
                .Range("D" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("D" & vDong, "E" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("D" & vDong, "E" & vDong).WrapText = True
                .Range("D" & vDong, "E" & vDong).Font.Color = RGB(220, 12, 26)
                .Range("D" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("D" & vDong, "E" & vDong).Value = vTongHTTS.ToString


                .Range("F" & vDong, "G" & vDong).Merge(True)
                .Range("F" & vDong, "G" & vDong).MergeCells = True
                .Range("F" & vDong, "G" & vDong).Font.Bold = True
                .Range("F" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("F" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("F" & vDong, "G" & vDong).WrapText = True
                .Range("F" & vDong, "G" & vDong).Font.Color = RGB(220, 12, 26)
                .Range("F" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("F" & vDong, "G" & vDong).Value = vTongHTCho.ToString

                .Range("H" & vDong, "I" & vDong).Merge(True)
                .Range("H" & vDong, "I" & vDong).MergeCells = True
                .Range("H" & vDong, "I" & vDong).Font.Bold = True
                .Range("H" & vDong, "I" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("H" & vDong, "I" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("H" & vDong, "I" & vDong).WrapText = True
                .Range("H" & vDong, "I" & vDong).Font.Color = RGB(220, 12, 26)
                .Range("H" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("H" & vDong, "I" & vDong).Value = vTongHTN.ToString
                .Range("H" & vDong, "I" & vDong).Font.Bold = True


            End With
            vDong = vDong + 1

        Next ' he thong

        ' vDong = vDong + 1
        With ExcelSheets
            .Range("A" & vDong, "C" & vDong).Merge(True)
            .Range("A" & vDong, "C" & vDong).MergeCells = True
            .Range("A" & vDong, "C" & vDong).Font.Bold = True
            .Range("A" & vDong, "C" & vDong).Merge(True)
            .Range("A" & vDong, "C" & vDong).MergeCells = True
            .Range("A" & vDong, "C" & vDong).Font.Color = RGB(181, 37, 192)
            .Range("A" & vDong, "C" & vDong).HorizontalAlignment = XlHAlign.xlHAlignRight
            .Range("A" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A" & vDong, "C" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptThongKeThoiGianNgungMayTheoNguyenNhan", "TONG_NGUNG_THEO_DIA_DIEM", Commons.Modules.TypeLanguage)

            .Range("D" & vDong, "E" & vDong).Merge(True)
            .Range("D" & vDong, "E" & vDong).MergeCells = True
            .Range("D" & vDong, "E" & vDong).Font.Bold = True
            .Range("D" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("D" & vDong, "E" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("D" & vDong, "E" & vDong).WrapText = True
            .Range("D" & vDong, "E" & vDong).Font.Color = RGB(181, 37, 192)
            .Range("D" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("D" & vDong, "E" & vDong).Value = vTongTanSuat.ToString



            .Range("F" & vDong, "G" & vDong).Merge(True)
            .Range("F" & vDong, "G" & vDong).MergeCells = True
            .Range("F" & vDong, "G" & vDong).Font.Bold = True
            .Range("F" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("F" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("F" & vDong, "G" & vDong).WrapText = True
            .Range("F" & vDong, "G" & vDong).Font.Color = RGB(181, 37, 192)
            .Range("F" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F" & vDong, "G" & vDong).Value = vTongDiaDiemCho.ToString

            .Range("H" & vDong, "I" & vDong).Merge(True)
            .Range("H" & vDong, "I" & vDong).MergeCells = True
            .Range("H" & vDong, "I" & vDong).Font.Bold = True
            .Range("H" & vDong, "I" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("H" & vDong, "I" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("H" & vDong, "I" & vDong).WrapText = True
            .Range("H" & vDong, "I" & vDong).Font.Color = RGB(181, 37, 192)
            .Range("H" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H" & vDong, "I" & vDong).Value = vTongDiaDiemN.ToString

            '.Range("H" & vDong, "M" & vDong).Font.Bold = True
            '.Range("H" & vDong, "M" & vDong).Merge(True)
            '.Range("H" & vDong, "M" & vDong).MergeCells = True
            '.Range("H" & vDong, "M" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        End With
        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

#Region "Nhu Y"
    Private Sub LoadCity()

        Try
            cmbCity.ValueMember = "ma_qg"
            cmbCity.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"))
            cmbCity.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDistrict()

        Try
            cmbDistrict.ValueMember = "ma_qg"
            cmbDistrict.DisplayMember = "ten_qg"
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_District", cmbCity.SelectedValue.ToString()))
            cmbDistrict.DataSource = _table
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadStreet()

        Try

            'cmbStreet.StoreName = "S_Duong"
            'cmbStreet.Param = cmbCity.SelectedValue.ToString()
            'If cmbDistrict.SelectedValue = Nothing Then
            'Else
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            'End If
            'cmbStreet.Param = cmbDistrict.SelectedValue.ToString()
            Dim _table As System.Data.DataTable = New System.Data.DataTable()
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Duong", cmbCity.SelectedValue.ToString(), cmbDistrict.SelectedValue.ToString()))
            cmbStreet.DataSource = _table
            cmbStreet.ValueMember = "MS_Duong"
            cmbStreet.DisplayMember = "Duong_TV"
        Catch ex As Exception

        End Try

    End Sub
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_ht As Integer) As System.Data.DataTable


        If MS_N_Xuong <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_TGNM_THONG_KE_THEO_NN_NEW]", tungay, denngay, ms_ht))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_Xuong + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY_FINAL").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_DataTable(vr("MS_N_Xuong_Final"), tungay, denngay, ms_ht)
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all.Rows.Count <= 0) Then
                                v_all = vDataParent.ToTable().Copy()
                                v_all.Clear()
                            End If
                            v_all.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If
                Next

                'v_all.Merge(temp.ToTable())

                Return v_all
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_TGNM_THONG_KE_THEO_NN_NEW]", tungay, denngay, ms_ht))
            Return objDataTable
        End If
    End Function
    Function Get_DataTable(ByVal MS_N_Xuong As String, ByVal tungay As Date, ByVal denngay As Date, ByVal ms_ht As Integer, ByVal city As String, _
                           ByVal district As String, ByVal street As String)
        Dim _table As System.Data.DataTable = New System.Data.DataTable
        _table = Get_DataTable(MS_N_Xuong, tungay, denngay, ms_ht)
        Dim _city As String = ""
        Dim _district As String = ""
        Dim _street As String = ""
        If _table.Rows.Count > 0 Then


            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY_FINAL<>'' and MS_MAY_FINAL <> ' ' and MS_MAY_FINAL is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table
    End Function
    Private Function Get_HT(ByVal MS_N_XUONG As String)
        If MS_N_XUONG <> "-1" Then
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable()
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_TGNM_GET_HT_NEW]"))
            Dim vDataParent As New DataView(objDataTable, "MS_CHA ='" + MS_N_XUONG + "'", "", DataViewRowState.CurrentRows)
            Dim vDataDetail As New DataView(objDataTable, "MS_N_XUONG_FINAL ='" + MS_N_XUONG + "'", "", DataViewRowState.CurrentRows)
            Dim nhom_may As String = vDataDetail(0)("MS_MAY_FINAL").ToString()
            Dim temp As DataView = vDataParent
            If String.IsNullOrEmpty(nhom_may) Then
                For Each vr As DataRow In vDataParent.ToTable().Rows
                    If String.IsNullOrEmpty(vr("MS_MAY").ToString()) Then
                        Try
                            temp.Table.TableName = "test"
                            temp.Table = Get_HT(vr("MS_N_XUONG_FINAL"))
                        Catch ex As Exception

                        End Try

                    Else
                        Try
                            If (v_all.Rows.Count <= 0) Then
                                v_all = vDataParent.ToTable().Copy()
                                v_all.Clear()
                            End If
                            v_all.Rows.Add(vr.ItemArray)
                        Catch ex As Exception

                        End Try

                    End If
                Next
                'v_all_may.Merge(temp.ToTable())


                Return v_all
            Else
                temp = vDataDetail
                Return temp.ToTable()
                'vDataParent.
            End If
        Else
            Dim objDataTable As System.Data.DataTable = New System.Data.DataTable()
            objDataTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[H_TGNM_GET_HT_NEW]"))
            Return objDataTable
        End If
    End Function
    Public Function Get_HT(ByVal MS_N_XUONG As String, ByVal city As String, ByVal district As String, ByVal street As String) As System.Data.DataTable
        Dim _table As System.Data.DataTable = New System.Data.DataTable()
        _table = Get_HT(MS_N_XUONG)
        If _table.Rows.Count > 0 Then


            Dim t As System.Data.DataTable = New System.Data.DataTable()
            Dim _city As String = ""
            Dim _district As String = ""
            Dim _street As String = ""
            If city <> "-1" Then
                _city = "MS_TINH = '" + city + "'"
                _table.DefaultView.RowFilter = _city
                _table = _table.DefaultView.ToTable()
            End If
            If district <> "-1" Then
                _district = "MS_QUAN = '" + district + "'"
                _table.DefaultView.RowFilter = _district
                _table = _table.DefaultView.ToTable()
            End If
            If street <> "-1" Then
                _street = "MS_DUONG = '" + street + "'"
                _table.DefaultView.RowFilter = _street
                _table = _table.DefaultView.ToTable()
            End If
            Dim _ms_may As String = ""
            _ms_may = "MS_MAY<>'' and MS_MAY <> ' ' and MS_MAY is not null"
            _table.DefaultView.RowFilter = _ms_may
            _table = _table.DefaultView.ToTable()
        End If
        Return _table

    End Function
#End Region
    Private Sub cmbCity_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCity.SelectedValueChanged
        LoadDistrict()
    End Sub

    Private Sub cmbDistrict_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrict.SelectedValueChanged
        LoadStreet()
    End Sub

    Private Sub cmbStreet_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStreet.SelectedValueChanged
        LoadNhaXuong()
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
