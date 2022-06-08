

Imports Microsoft.ApplicationBlocks.Data
Imports Excel


Public Class FrmChonThoiGianNgungMay
    Private vTuNgay As DateTime
    Private vDenNgay As DateTime

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click

        If vTuNgay > vDenNgay Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TN_PHAI_NHO_HON_DN", commons.Modules.TypeLanguage))
            Exit Sub
        End If


        Dim vtbData As New System.Data.DataTable
        vtbData.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_TGNM_GET_DATA_REPORT", vTuNgay, vDenNgay, cboNhaxuong.SelectedValue, cboHeThong.SelectedValue))

        If (vtbData.Rows.Count = 0) Then
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "KO_CO_DL_DE_IN", commons.Modules.TypeLanguage))
            Exit Sub
        End If


        Me.Cursor = Cursors.WaitCursor
        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        ExcelApp.Visible = False
        ExcelBooks = ExcelApp.Workbooks.Add
        ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

        With ExcelSheets

            .Columns(2).ColumnWidth = 15
            .Columns(3).ColumnWidth = 20
            .Columns(4).ColumnWidth = 20
            .Columns(5).ColumnWidth = 20
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
            .Range("A1", "B1").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TD1", commons.Modules.TypeLanguage)
            .Range("A2", "B2").Font.Bold = True
            .Range("A2", "B2").Merge(True)
            .Range("A2", "B2").MergeCells = True
            .Range("A2", "B2").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TD2", commons.Modules.TypeLanguage)
            .Range("A3", "B3").Font.Bold = True
            .Range("A3", "B3").Merge(True)
            .Range("A3", "B3").MergeCells = True
            .Range("A3", "B3").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TD3", commons.Modules.TypeLanguage)
            .Range("A1", "B3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A1", "B3").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A1", "B3").HorizontalAlignment = XlHAlign.xlHAlignCenter

            .Range("C1", "L2").Font.Bold = True
            .Range("C1", "L2").Merge(True)
            .Range("C1", "L2").MergeCells = True
            .Range("C1", "L2").Font.Size = 14
            .Range("C1", "L2").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("C1", "L2").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("C1", "L2").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TIEU_DE_BC_TGNM", commons.Modules.TypeLanguage)

            .Range("C3", "L3").Font.Bold = True
            .Range("C3", "L3").Merge(True)
            .Range("C3", "L3").MergeCells = True
            .Range("C3", "L3").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TU_NGAY", commons.Modules.TypeLanguage) + "  " + mtxtTuNgay.Text + _
             "  " + Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DEN_NGAT", commons.Modules.TypeLanguage) + " " + mtxtDenNgay.Text
            .Range("C1", "L3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("C1", "L3").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("C1", "L3").HorizontalAlignment = XlHAlign.xlHAlignCenter

            .Range("M1", "M1").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LBCODE", commons.Modules.TypeLanguage)
            .Range("M1", "M1").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("M2", "M2").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "VDATE", commons.Modules.TypeLanguage)
            .Range("M2", "M2").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("M3", "M3").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "VPAGE", commons.Modules.TypeLanguage)
            .Range("M3", "M3").HorizontalAlignment = XlHAlign.xlHAlignLeft

            .Range("N1", "O1").Merge(True)
            .Range("N1", "O1").MergeCells = True
            .Range("M1", "O1").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N1", "O1").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CODE", commons.Modules.TypeLanguage)
            .Range("N1", "O1").HorizontalAlignment = XlHAlign.xlHAlignLeft

            .Range("N2", "O2").Merge(True)
            .Range("N2", "O2").MergeCells = True
            .Range("M2", "O2").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N2", "O2").Value = DateTime.Now.Date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
            .Range("N2", "O2").HorizontalAlignment = XlHAlign.xlHAlignLeft

            .Range("M3", "O3").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            .Range("A5", "M5").Font.Bold = True
            .Range("A5", "M5").Merge(True)
            .Range("A5", "M5").MergeCells = True
            .Range("A5", "M5").HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Range("A5", "M5").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "DIA_DIEM", commons.Modules.TypeLanguage) + "  " + cboNhaxuong.Text

            .Range("A7", "B7").Font.Bold = True
            .Range("A7", "B7").Merge(True)
            .Range("A7", "B7").MergeCells = True
            .Range("A7", "B7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("A7", "B7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("A7", "B7").WrapText = True
            .Range("A7", "B7").RowHeight = 26
            .Range("A7", "B7").Interior.Color = RGB(200, 200, 200)
            .Range("A7", "B7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A7", "B7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THIET_BI", commons.Modules.TypeLanguage)

            .Range("C7", "C7").Font.Bold = True
            .Range("C7", "C7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("C7", "C7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("C7", "C7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("C7", "C7").WrapText = True
            .Range("C7", "C7").Interior.Color = RGB(200, 200, 200)
            .Range("C7", "C7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GIO_YEU_CAU", commons.Modules.TypeLanguage)


            .Range("D7", "D7").Font.Bold = True
            .Range("D7", "D7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("D7", "D7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("D7", "D7").WrapText = True
            .Range("D7", "D7").Interior.Color = RGB(200, 200, 200)
            .Range("D7", "D7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("D7", "D7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GIO_GIO_SUA", commons.Modules.TypeLanguage)

            .Range("E7", "E7").Font.Bold = True
            .Range("E7", "E7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("E7", "E7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("E7", "E7").WrapText = True
            .Range("E7", "E7").Interior.Color = RGB(200, 200, 200)
            .Range("E7", "E7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("E7", "E7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GIO_KET_THUC", commons.Modules.TypeLanguage)

            .Range("F7", "F7").Font.Bold = True
            .Range("F7", "F7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("F7", "F7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("F7", "F7").WrapText = True
            .Range("F7", "F7").Interior.Color = RGB(200, 200, 200)
            .Range("F7", "F7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F7", "F7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THOI_GIAN_CHO", commons.Modules.TypeLanguage)

            .Range("G7", "G7").Font.Bold = True
            .Range("G7", "G7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("G7", "G7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("G7", "G7").WrapText = True
            .Range("G7", "G7").Interior.Color = RGB(200, 200, 200)
            .Range("G7", "G7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G7", "G7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "THOI_GIAN_NM", commons.Modules.TypeLanguage)

            .Range("H7", "I7").Font.Bold = True
            .Range("H7", "I7").Merge(True)
            .Range("H7", "I7").MergeCells = True
            .Range("H7", "I7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("H7", "I7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("H7", "I7").WrapText = True
            .Range("H7", "I7").Interior.Color = RGB(200, 200, 200)
            .Range("H7", "I7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("H7", "I7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGUYEN_NHAN_NM", commons.Modules.TypeLanguage)


            .Range("J7", "K7").Font.Bold = True
            .Range("J7", "K7").Merge(True)
            .Range("J7", "K7").MergeCells = True
            .Range("J7", "K7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("J7", "K7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("J7", "K7").WrapText = True
            .Range("J7", "K7").Interior.Color = RGB(200, 200, 200)
            .Range("J7", "K7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("J7", "K7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGUOI_GIAI_QUYET", commons.Modules.TypeLanguage)


            .Range("L7", "M7").Font.Bold = True
            .Range("L7", "M7").Merge(True)
            .Range("L7", "M7").MergeCells = True
            .Range("L7", "M7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("L7", "M7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("L7", "M7").WrapText = True
            .Range("L7", "M7").Interior.Color = RGB(200, 200, 200)
            .Range("L7", "M7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("L7", "M7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "NGUOI_DUNG_MAY", commons.Modules.TypeLanguage)


            .Range("N7", "O7").Font.Bold = True
            .Range("N7", "O7").Merge(True)
            .Range("N7", "O7").MergeCells = True
            .Range("N7", "O7").VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("N7", "O7").HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("N7", "O7").WrapText = True
            .Range("N7", "O7").Interior.Color = RGB(200, 200, 200)
            .Range("N7", "O7").BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("N7", "O7").Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "GHI_CHU", commons.Modules.TypeLanguage)

        End With
        ''''''''''''PRINT DATA'''''''''''''''''''''''''
        'H_TGNM_GET_DATA_REPORT


        Dim vtbHeThong As New System.Data.DataTable
        vtbHeThong = vtbData.DefaultView.ToTable(True, "MS_HE_THONG", "TEN_HE_THONG")

        Dim vDong As Integer = 8


        Dim vTongDiaDiemCho As Double = 0
        Dim vTongDiaDiemN As Double = 0

        For Each vrowHT As DataRow In vtbHeThong.Rows
            Dim dvLoaiNN As New System.Data.DataView(vtbData, " MS_HE_THONG = '" + vrowHT("MS_HE_THONG").ToString + "'", "GIO_YEU_CAU", DataViewRowState.CurrentRows)

            Dim vTongHTCho As Double = 0
            Dim vTongHTN As Double = 0

            With ExcelSheets
                .Range("A" & vDong, "O" & vDong).Font.Bold = True
                .Range("A" & vDong, "O" & vDong).Merge(True)
                .Range("A" & vDong, "O" & vDong).MergeCells = True
                .Range("A" & vDong, "O" & vDong).Font.Color = RGB(227, 105, 32)
                .Range("A" & vDong, "O" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                .Range("A" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A" & vDong, "O" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "HE_THONG", commons.Modules.TypeLanguage) + " " + vrowHT("TEN_HE_THONG").ToString
            End With

            Dim vtbLoaiNN As New System.Data.DataTable
            vtbLoaiNN = dvLoaiNN.ToTable(True, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN")

            For Each vrowLNN As DataRow In vtbLoaiNN.Rows

                vDong = vDong + 1
                With ExcelSheets

                    .Range("A" & vDong, "O" & vDong).Font.Bold = True
                    .Range("A" & vDong, "O" & vDong).Merge(True)
                    .Range("A" & vDong, "O" & vDong).MergeCells = True
                    .Range("A" & vDong, "O" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("A" & vDong, "O" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    .Range("A" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("A" & vDong, "O" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "LOAI_NGUNG_MAY", commons.Modules.TypeLanguage) + " " + vrowLNN("TEN_NGUYEN_NHAN").ToString
                End With

                Dim vdataList As New DataView(dvLoaiNN.ToTable(), "MS_NGUYEN_NHAN = '" + vrowLNN("MS_NGUYEN_NHAN").ToString + "'", "GIO_YEU_CAU", DataViewRowState.CurrentRows)

                Dim vTongChoLoai As Double = 0
                Dim vTongNgungLoai As Double = 0

                For Each vr As DataRow In vdataList.ToTable().Rows

                    vDong = vDong + 1
                    With ExcelSheets
                        '.Range("A" & vDong, "B" & vDong).Font.Bold = True
                        .Range("A" & vDong, "B" & vDong).Merge(True)
                        .Range("A" & vDong, "B" & vDong).MergeCells = True
                        .Range("A" & vDong, "B" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        .Range("A" & vDong, "B" & vDong).WrapText = True
                        .Range("A" & vDong, "B" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("A" & vDong, "B" & vDong).Value = vr("MS_MAY") + "-" + vr("TEN_MAY")

                        ' .Range("C" & vDong, "C" & vDong).Font.Bold = True
                        .Range("C" & vDong, "C" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("C" & vDong, "C" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("C" & vDong, "C" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("C" & vDong, "C" & vDong).WrapText = True
                        .Range("C" & vDong, "C" & vDong).Value = "'" + vr("GIO_YEU_CAU")


                        ' .Range("D" & vDong, "D" & vDong).Font.Bold = True
                        .Range("D" & vDong, "D" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("D" & vDong, "D" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("D" & vDong, "D" & vDong).WrapText = True
                        .Range("D" & vDong, "D" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("D" & vDong, "D" & vDong).Value = "'" + vr("GIO_SUA_CHUA")

                        '.Range("E" & vDong, "E" & vDong).Font.Bold = True
                        .Range("E" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("E" & vDong, "E" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("E" & vDong, "E" & vDong).WrapText = True
                        .Range("E" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("E" & vDong, "E" & vDong).Value = "'" + vr("GIO_KET_THUC")

                        ' .Range("F" & vDong, "F" & vDong).Font.Bold = True
                        .Range("F" & vDong, "F" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("F" & vDong, "F" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("F" & vDong, "F" & vDong).WrapText = True
                        .Range("F" & vDong, "F" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("F" & vDong, "F" & vDong).Value = vr("THOI_GIAN_CHO")

                        If vr("THOI_GIAN_CHO").ToString <> "" Then
                            vTongChoLoai = vTongChoLoai + vr("THOI_GIAN_CHO")
                            vTongHTCho = vTongHTCho + vr("THOI_GIAN_CHO")
                            vTongDiaDiemCho = vTongDiaDiemCho + vr("THOI_GIAN_CHO")
                        End If


                        ' .Range("G" & vDong, "G" & vDong).Font.Bold = True
                        .Range("G" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        .Range("G" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("G" & vDong, "G" & vDong).WrapText = True
                        .Range("G" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("G" & vDong, "G" & vDong).Value = vr("THOI_GIAN_SUA_CHUA")

                        If vr("THOI_GIAN_SUA_CHUA").ToString <> "" Then
                            vTongNgungLoai = vTongNgungLoai + vr("THOI_GIAN_SUA_CHUA")
                            vTongHTN = vTongHTN + vr("THOI_GIAN_SUA_CHUA")
                            vTongDiaDiemN = vTongDiaDiemN + vr("THOI_GIAN_SUA_CHUA")
                        End If


                        ' .Range("H" & vDong, "I" & vDong).Font.Bold = True
                        .Range("H" & vDong, "I" & vDong).Merge(True)
                        .Range("H" & vDong, "I" & vDong).MergeCells = True
                        .Range("H" & vDong, "I" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("H" & vDong, "I" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        .Range("H" & vDong, "I" & vDong).WrapText = True
                        .Range("H" & vDong, "I" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("H" & vDong, "I" & vDong).Value = vr("NGUYEN_NHAN")


                        '.Range("J" & vDong, "K" & vDong).Font.Bold = True
                        .Range("J" & vDong, "K" & vDong).Merge(True)
                        .Range("J" & vDong, "K" & vDong).MergeCells = True
                        .Range("J" & vDong, "K" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("J" & vDong, "K" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        .Range("J" & vDong, "K" & vDong).WrapText = True
                        .Range("J" & vDong, "K" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("J" & vDong, "K" & vDong).Value = vr("NGUOI_GIAI_QUYET")


                        '.Range("L" & vDong, "M" & vDong).Font.Bold = True
                        .Range("L" & vDong, "M" & vDong).Merge(True)
                        .Range("L" & vDong, "M" & vDong).MergeCells = True
                        .Range("L" & vDong, "M" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("L" & vDong, "M" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        .Range("L" & vDong, "M" & vDong).WrapText = True
                        .Range("L" & vDong, "M" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("L" & vDong, "M" & vDong).Value = vr("NGUOI_DUNG_MAY")


                        '.Range("L" & vDong, "M" & vDong).Font.Bold = True
                        .Range("N" & vDong, "O" & vDong).Merge(True)
                        .Range("N" & vDong, "O" & vDong).MergeCells = True
                        .Range("N" & vDong, "O" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                        .Range("N" & vDong, "O" & vDong).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        .Range("N" & vDong, "O" & vDong).WrapText = True
                        .Range("N" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        .Range("N" & vDong, "O" & vDong).Value = vr("GHI_CHU")

                    End With
                Next
                vDong = vDong + 1

                With ExcelSheets

                    .Range("A" & vDong, "E" & vDong).Font.Bold = True
                    .Range("A" & vDong, "E" & vDong).Merge(True)
                    .Range("A" & vDong, "E" & vDong).MergeCells = True
                    .Range("A" & vDong, "E" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("A" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignRight
                    .Range("A" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("A" & vDong, "E" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TONG_NGUNG_THEO_NN", commons.Modules.TypeLanguage)


                    .Range("F" & vDong, "F" & vDong).Font.Bold = True
                    .Range("F" & vDong, "F" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("F" & vDong, "F" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("F" & vDong, "F" & vDong).WrapText = True
                    .Range("F" & vDong, "F" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("F" & vDong, "F" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("F" & vDong, "F" & vDong).Value = vTongChoLoai.ToString

                    .Range("G" & vDong, "G" & vDong).Font.Bold = True
                    .Range("G" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    .Range("G" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                    .Range("G" & vDong, "G" & vDong).WrapText = True
                    .Range("G" & vDong, "G" & vDong).Font.Color = RGB(48, 12, 218)
                    .Range("G" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                    .Range("G" & vDong, "G" & vDong).Value = vTongNgungLoai.ToString

                    .Range("H" & vDong, "O" & vDong).Font.Bold = True
                    .Range("H" & vDong, "O" & vDong).Merge(True)
                    .Range("H" & vDong, "O" & vDong).MergeCells = True
                    .Range("H" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

                End With

            Next ' loainn
            vDong = vDong + 1

            With ExcelSheets

                .Range("A" & vDong, "E" & vDong).Font.Bold = True
                .Range("A" & vDong, "E" & vDong).Merge(True)
                .Range("A" & vDong, "E" & vDong).MergeCells = True
                .Range("A" & vDong, "E" & vDong).Font.Color = RGB(220, 12, 26)
                .Range("A" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignRight
                .Range("A" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("A" & vDong, "E" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TONG_NGUNG_THEO_DAY_CHUYEN", commons.Modules.TypeLanguage)


                .Range("F" & vDong, "F" & vDong).Font.Bold = True
                .Range("F" & vDong, "F" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("F" & vDong, "F" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("F" & vDong, "F" & vDong).WrapText = True
                .Range("F" & vDong, "F" & vDong).Font.Color = RGB(220, 12, 26)
                .Range("F" & vDong, "F" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("F" & vDong, "F" & vDong).Value = vTongHTCho.ToString

                .Range("G" & vDong, "G" & vDong).Font.Bold = True
                .Range("G" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
                .Range("G" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
                .Range("G" & vDong, "G" & vDong).WrapText = True
                .Range("G" & vDong, "G" & vDong).Font.Color = RGB(220, 12, 26)
                .Range("G" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Range("G" & vDong, "G" & vDong).Value = vTongHTN.ToString

                .Range("H" & vDong, "O" & vDong).Font.Bold = True
                .Range("H" & vDong, "O" & vDong).Merge(True)
                .Range("H" & vDong, "O" & vDong).MergeCells = True
                .Range("H" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

            End With
            vDong = vDong + 1

        Next ' he thong

        ' vDong = vDong + 1
        With ExcelSheets

            .Range("A" & vDong, "E" & vDong).Font.Bold = True
            .Range("A" & vDong, "E" & vDong).Merge(True)
            .Range("A" & vDong, "E" & vDong).MergeCells = True
            .Range("A" & vDong, "E" & vDong).Font.Color = RGB(181, 37, 192)
            .Range("A" & vDong, "E" & vDong).HorizontalAlignment = XlHAlign.xlHAlignRight
            .Range("A" & vDong, "E" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("A" & vDong, "E" & vDong).Value = Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "TONG_NGUNG_THEO_DIA_DIEM", commons.Modules.TypeLanguage)


            .Range("F" & vDong, "F" & vDong).Font.Bold = True
            .Range("F" & vDong, "F" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("F" & vDong, "F" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("F" & vDong, "F" & vDong).WrapText = True
            .Range("F" & vDong, "F" & vDong).Font.Color = RGB(181, 37, 192)
            .Range("F" & vDong, "F" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("F" & vDong, "F" & vDong).Value = vTongDiaDiemCho.ToString

            .Range("G" & vDong, "G" & vDong).Font.Bold = True
            .Range("G" & vDong, "G" & vDong).HorizontalAlignment = XlHAlign.xlHAlignCenter
            .Range("G" & vDong, "G" & vDong).VerticalAlignment = XlVAlign.xlVAlignCenter
            .Range("G" & vDong, "G" & vDong).WrapText = True
            .Range("G" & vDong, "G" & vDong).Font.Color = RGB(181, 37, 192)
            .Range("G" & vDong, "G" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
            .Range("G" & vDong, "G" & vDong).Value = vTongDiaDiemN.ToString

            .Range("H" & vDong, "O" & vDong).Font.Bold = True
            .Range("H" & vDong, "O" & vDong).Merge(True)
            .Range("H" & vDong, "O" & vDong).MergeCells = True
            .Range("H" & vDong, "O" & vDong).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)

        End With
        ExcelApp.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub FrmChonThoiGianNgungMay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadNhaXuong()
        LoadHeThong()

        vDenNgay = DateTime.Now.Date
        mtxtDenNgay.Text = vDenNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        vTuNgay = vDenNgay.AddMonths(-1)
        mtxtTuNgay.Text = vTuNgay.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Commons.Modules.ObjSystems.ThayDoiNN(Me)
        AddHandler cboNhaxuong.SelectedIndexChanged, AddressOf Me.cboNhaxuong_SelectedIndexChanged
    End Sub

    Sub LoadNhaXuong()
        cboNhaxuong.Value = "MS_N_XUONG"
        cboNhaxuong.Display = "TEN_N_XUONG"
        cboNhaxuong.StoreName = "H_TGNM_GET_NX"
        cboNhaxuong.BindDataSource()
    End Sub

    Sub LoadHeThong()
        cboHeThong.Value = "MS_HE_THONG"
        cboHeThong.Display = "TEN_HE_THONG"
        cboHeThong.StoreName = "H_TGNM_GET_HT"
        cboHeThong.Param = cboNhaxuong.SelectedValue
        cboHeThong.BindDataSource()
    End Sub

    Private Sub cboNhaxuong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cboNhaxuong.SelectedIndexChanged
        LoadHeThong()
    End Sub

    Private Sub mtxtTuNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtTuNgay.Validating
        Try
            vTuNgay = DateTime.ParseExact(mtxtTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DINH_DANG", commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub

    Private Sub mtxtDenNgay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtxtDenNgay.Validating
        Try
            vDenNgay = DateTime.ParseExact(mtxtDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)
        Catch ex As Exception
            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(commons.Modules.ModuleName, Me.Name, "CHUA_DUNG_DINH_DANG", commons.Modules.TypeLanguage))
            e.Cancel = True
        End Try
    End Sub
End Class