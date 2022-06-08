Imports Commons.VS.Classes.Admin
Imports Commons

Public Class frmrptNhanVien

    Private Sub btnThucHien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThucHien.Click
        Dim obj As New Commons.clsprintnhanvien
        Dim obj1 As New Commons.OSystems
        Dim dt As New DataTable
        obj1.XoaTable("dbo.rptBaocaocongnhan")
        If cbodonvi.SelectedValue = "-1" Then
            dt = obj.Getbaocaonhanvien(cbodonvi.SelectedValue, cboban.SelectedValue, 1)
        Else
            dt = obj.Getbaocaonhanvien(cbodonvi.SelectedValue, cboban.SelectedValue, 0)
        End If
        XuatExcel()
    End Sub
    Public Sub XuatExcel()
        Dim ExcelApp As New Excel.Application
        Dim ExcelBooks As Excel.Workbook
        Dim ExcelSheets As Excel.Worksheet
        Dim colums As Excel.Range
        Try

            Dim xR As Int32 = 2 'Excel Row Number
            ExcelApp.Visible = True
            ExcelBooks = ExcelApp.Workbooks.Add
            ExcelSheets = CType(ExcelBooks.Worksheets(1), Excel.Worksheet)

            With ExcelSheets
                .Range("A4:H4").Merge()
                .Range("A4:H4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("A4:H4").Font.Bold = True

                .Cells(4, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcTDDanhSachNhanVien", Commons.Modules.TypeLanguage) '"DANH SÁCH NHÂN VIÊN"

                Dim i As Integer
                Dim j As Integer
                Dim hang As Integer
                Dim hang1 As Integer
                Dim dtdonvi As New DataTable
                Dim rowdv As DataRow
                Dim rowban As DataRow
                Dim dtban As New DataTable
                Dim obj As New Commons.clsprintnhanvien
                hang = 7
                dtdonvi = obj.Getbaocaodonvi()
                colums = ExcelSheets.Columns("A")
                colums.ColumnWidth = 12

                colums = ExcelSheets.Columns("B")
                colums.ColumnWidth = 32
                colums = ExcelSheets.Columns("C")
                colums.ColumnWidth = 28
                colums = ExcelSheets.Columns("D")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("E")
                colums.ColumnWidth = 15
                colums = ExcelSheets.Columns("F")
                colums.ColumnWidth = 32
                colums = ExcelSheets.Columns("G")
                colums.ColumnWidth = 24
                colums = ExcelSheets.Columns("S")
                colums.ColumnWidth = 24
                colums = ExcelSheets.Columns("T")
                colums.ColumnWidth = 24
                colums = ExcelSheets.Columns("U")
                colums.ColumnWidth = 17
                colums = ExcelSheets.Columns("V")
                colums.ColumnWidth = 29
                colums = ExcelSheets.Columns("W")
                colums.ColumnWidth = 29

                .Cells(hang, 1) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcSTT", Commons.Modules.TypeLanguage) '"STT"
                .Cells(hang, 1).Font.Bold = True
                .Range(.Cells(hang, 1), .Cells(hang, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 1), .Cells(hang, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 2) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcMSNV", Commons.Modules.TypeLanguage) '"Mã NV"
                .Cells(hang, 2).Font.Bold = True
                .Range(.Cells(hang, 2), .Cells(hang, 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 2), .Cells(hang, 2)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 3) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcHoTen", Commons.Modules.TypeLanguage) '"Họ và tên "
                .Cells(hang, 3).Font.Bold = True
                .Range(.Cells(hang, 3), .Cells(hang, 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 3), .Cells(hang, 3)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 4) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcNgaySinh", Commons.Modules.TypeLanguage) '"Ngày sinh "
                .Cells(hang, 4).Font.Bold = True
                .Range(.Cells(hang, 4), .Cells(hang, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 4), .Cells(hang, 4)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 5) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcNoiSinh", Commons.Modules.TypeLanguage) '"Nơi sinh "
                .Cells(hang, 5).Font.Bold = True
                .Range(.Cells(hang, 5), .Cells(hang, 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 5), .Cells(hang, 5)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 6) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcDiaChi", Commons.Modules.TypeLanguage) '"Địa chỉ "
                .Cells(hang, 6).Font.Bold = True
                .Range(.Cells(hang, 6), .Cells(hang, 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 6), .Cells(hang, 6)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 7) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcSoCMND", Commons.Modules.TypeLanguage) '"SO CMND"
                .Cells(hang, 7).Font.Bold = True
                .Range(.Cells(hang, 7), .Cells(hang, 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 7), .Cells(hang, 7)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 8) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcNgayCap", Commons.Modules.TypeLanguage) '"Ngày cấp"
                .Cells(hang, 8).Font.Bold = True
                .Range(.Cells(hang, 8), .Cells(hang, 8)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 8), .Cells(hang, 8)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 9) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcNoiCap", Commons.Modules.TypeLanguage) '"Nơi cấp"
                .Cells(hang, 9).Font.Bold = True
                .Range(.Cells(hang, 9), .Cells(hang, 9)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 9), .Cells(hang, 9)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 10) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcDTDD", Commons.Modules.TypeLanguage) '"DTDĐ"
                .Cells(hang, 10).Font.Bold = True
                .Range(.Cells(hang, 10), .Cells(hang, 10)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 10), .Cells(hang, 10)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 11) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcDTNha", Commons.Modules.TypeLanguage) '"ĐT nhà"
                .Cells(hang, 11).Font.Bold = True
                .Range(.Cells(hang, 11), .Cells(hang, 11)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 11), .Cells(hang, 11)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 12) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcTrinhDo", Commons.Modules.TypeLanguage) '"Trình độ"
                .Cells(hang, 12).Font.Bold = True
                .Range(.Cells(hang, 12), .Cells(hang, 11)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 12), .Cells(hang, 11)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 13) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcBCap", Commons.Modules.TypeLanguage) '"Bằng cấp"
                .Cells(hang, 13).Font.Bold = True
                .Range(.Cells(hang, 13), .Cells(hang, 13)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 13), .Cells(hang, 13)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 14) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcChuyenMon", Commons.Modules.TypeLanguage) '"Chuyên môn"
                .Cells(hang, 14).Font.Bold = True
                .Range(.Cells(hang, 14), .Cells(hang, 14)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 14), .Cells(hang, 14)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 15) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcBacTho", Commons.Modules.TypeLanguage) '"Bậc thợ"
                .Cells(hang, 15).Font.Bold = True
                .Range(.Cells(hang, 15), .Cells(hang, 15)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 15), .Cells(hang, 15)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 16) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcNgayVLam", Commons.Modules.TypeLanguage) '"Ngày vào làm"
                .Cells(hang, 16).Font.Bold = True
                .Range(.Cells(hang, 16), .Cells(hang, 15)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 16), .Cells(hang, 15)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 17) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcChucVu", Commons.Modules.TypeLanguage) '"Chức vụ"
                .Cells(hang, 17).Font.Bold = True
                .Range(.Cells(hang, 17), .Cells(hang, 17)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 17), .Cells(hang, 17)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 18) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcLuongCB", Commons.Modules.TypeLanguage) '"Lương CB"
                .Cells(hang, 18).Font.Bold = True
                .Range(.Cells(hang, 18), .Cells(hang, 18)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 18), .Cells(hang, 18)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 19) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcNguoiThan", Commons.Modules.TypeLanguage) '"Người thân"
                .Cells(hang, 19).Font.Bold = True
                .Range(.Cells(hang, 19), .Cells(hang, 19)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 19), .Cells(hang, 19)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 20) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcQuanHe", Commons.Modules.TypeLanguage) '"Quan hệ"
                .Cells(hang, 20).Font.Bold = True
                .Range(.Cells(hang, 20), .Cells(hang, 20)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 20), .Cells(hang, 20)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 21) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcNghiViec", Commons.Modules.TypeLanguage) '"Nghỉ việc"
                .Cells(hang, 21).Font.Bold = True
                .Range(.Cells(hang, 21), .Cells(hang, 21)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 21), .Cells(hang, 21)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 22) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcLyDoNghi", Commons.Modules.TypeLanguage) '"Lý do nghỉ"
                .Cells(hang, 22).Font.Bold = True
                .Range(.Cells(hang, 22), .Cells(hang, 22)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 22), .Cells(hang, 22)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 23) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcTaiNan", Commons.Modules.TypeLanguage) '"Tai nạn"
                .Cells(hang, 23).Font.Bold = True
                .Range(.Cells(hang, 23), .Cells(hang, 23)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 23), .Cells(hang, 23)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                .Cells(hang, 24) = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcGhiChu", Commons.Modules.TypeLanguage) '"Ghi chú"
                .Cells(hang, 24).Font.Bold = True
                .Range(.Cells(hang, 24), .Cells(hang, 24)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range(.Cells(hang, 24), .Cells(hang, 24)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                Dim sDvi As String
                Dim sBoPhan As String
                sBoPhan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcBoPhan", Commons.Modules.TypeLanguage) '"Bộ phận "
                sDvi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptNhanVien", "bcDonVi", Commons.Modules.TypeLanguage) '"Đơn vị "

                For i = 0 To dtdonvi.Rows.Count - 1
                    rowdv = dtdonvi.Rows(i)
                    .Cells(hang - 1, 1) = sDvi & " " & "   " & rowdv("ten_don_vi").ToString    '"Đơn vị " & "   " & rowdv("ten_don_vi").ToString
                    .Cells(hang - 1, 1).Font.Bold = True
                    .Cells(hang - 1, 1).Font.Color = RGB(200, 1, 1)

                    dtban = obj.GetbaocaoToban(rowdv("ms_don_vi"))
                    hang = hang + 1
                    For j = 0 To dtban.Rows.Count - 1
                        rowban = dtban.Rows(j)
                        hang1 = hang + 1
                        Dim dtnhanvien As New DataTable
                        dtnhanvien = obj.Getnhanvienbaocao(rowban("ms_to").ToString)
                        ExcelSheets.Cells(hang1, 1).value = sBoPhan & " " & " " & rowban("ten_to").ToString     '"Bộ phận " & " " & rowban("ten_to").ToString
                        .Cells(hang1, 1).Font.Color = RGB(0, 1, 200)
                        .Cells(hang1, 1).Font.Bold = True
                        Dim dem As Integer
                        dem = 0

                        For Each dr As DataRow In dtnhanvien.Rows
                            hang1 = hang1 + 1
                            dem = dem + 1

                            'ExcelSheets.Cells(xR, 1).value = "'" & i
                            '.Range(.Cells(xR, 1), .Cells(xR, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            ExcelSheets.Cells(hang1, 1).value = dem
                            .Range(.Cells(hang1, 1), .Cells(hang1, 1)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 1), .Cells(hang1, 1)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                            ExcelSheets.Cells(hang1, 2).value = "'" & dr.Item("ms_cong_nhan")
                            .Range(.Cells(hang1, 2), .Cells(hang1, 2)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 2), .Cells(hang1, 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 3).value = "'" & dr.Item("ho") + "  " + dr.Item("ten")
                            .Range(.Cells(hang1, 3), .Cells(hang1, 2)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 3), .Cells(hang1, 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 4).value = "'" & dr.Item("ngay_sinh")
                            .Range(.Cells(hang1, 4), .Cells(hang1, 4)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 4), .Cells(hang1, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 5).value = "'" & dr.Item("noi_sinh")
                            .Range(.Cells(hang1, 5), .Cells(hang1, 5)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 5), .Cells(hang1, 5)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 6).value = "'" & dr.Item("dia_chi_thuong_tru")
                            .Range(.Cells(hang1, 6), .Cells(hang1, 6)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 6), .Cells(hang1, 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 7).value = "'" & dr.Item("so_cmnd")
                            .Range(.Cells(hang1, 7), .Cells(hang1, 7)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 7), .Cells(hang1, 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 8).value = "'" & dr.Item("ngay_cap")
                            .Range(.Cells(hang1, 8), .Cells(hang1, 8)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 8), .Cells(hang1, 8)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 9).value = "'" & dr.Item("noi_cap")
                            .Range(.Cells(hang1, 9), .Cells(hang1, 9)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 9), .Cells(hang1, 9)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 10).value = "'" & dr.Item("so_dtdd")
                            .Range(.Cells(hang1, 10), .Cells(hang1, 10)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 10), .Cells(hang1, 10)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 11).value = "'" & dr.Item("so_dt_nha_rieng")
                            .Range(.Cells(hang1, 11), .Cells(hang1, 11)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 11), .Cells(hang1, 11)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 12).value = "'" & dr.Item("ten_goi")
                            .Range(.Cells(hang1, 12), .Cells(hang1, 12)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 12), .Cells(hang1, 12)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                            ExcelSheets.Cells(hang1, 13).value = "'" & dr.Item("bang_cap")
                            .Range(.Cells(hang1, 13), .Cells(hang1, 13)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 13), .Cells(hang1, 13)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 14).value = "'" & dr.Item("chuyenmon")
                            .Range(.Cells(hang1, 14), .Cells(hang1, 14)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 14), .Cells(hang1, 14)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 15).value = "'" & dr.Item("bactho")
                            .Range(.Cells(hang1, 15), .Cells(hang1, 15)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 15), .Cells(hang1, 15)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 16).value = "'" & dr.Item("ngay_vao_lam")
                            .Range(.Cells(hang1, 16), .Cells(hang1, 16)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 16), .Cells(hang1, 16)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 16).value = "'" & dr.Item("ngay_vao_lam")
                            .Range(.Cells(hang1, 16), .Cells(hang1, 16)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 16), .Cells(hang1, 16)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            Dim tenchucvu As String = ""
                            Dim bacluong As String = ""
                            Dim dt1 As New DataTable
                            Dim row1 As DataRow
                            dt1 = obj.Getchucvu_cn(dr.Item("ms_cong_nhan"))
                            If dt1.Rows.Count > 0 Then
                                row1 = dt1.Rows(0)
                                tenchucvu = row1("ten_chuc_vu")
                            End If
                            Dim dt2 As New DataTable
                            Dim row2 As DataRow
                            dt2 = obj.PrintBacluong(dr.Item("ms_cong_nhan"))
                            If dt2.Rows.Count > 0 Then
                                row2 = dt2.Rows(0)
                                bacluong = row2("luong_co_ban") & " " & row2("NGOAI_TE")
                            End If
                            ExcelSheets.Cells(hang1, 17).value = tenchucvu
                            .Range(.Cells(hang1, 17), .Cells(hang1, 17)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 17), .Cells(hang1, 17)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 18).value = bacluong
                            .Range(.Cells(hang1, 18), .Cells(hang1, 18)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 18), .Cells(hang1, 18)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 19).value = dr.Item("ten_nguoi_than")
                            .Range(.Cells(hang1, 19), .Cells(hang1, 19)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 19), .Cells(hang1, 19)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 20).value = dr.Item("quan_he")
                            .Range(.Cells(hang1, 20), .Cells(hang1, 20)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 20), .Cells(hang1, 20)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 21).value = dr.Item("ngay_nghi_viec")
                            .Range(.Cells(hang1, 21), .Cells(hang1, 21)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 21), .Cells(hang1, 21)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 22).value = "'" & dr.Item("ly_do_nghi")
                            .Range(.Cells(hang1, 22), .Cells(hang1, 22)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 22), .Cells(hang1, 22)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            ExcelSheets.Cells(hang1, 23).value = dr.Item("tainan")
                            .Range(.Cells(hang1, 23), .Cells(hang1, 23)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                            .Range(.Cells(hang1, 23), .Cells(hang1, 23)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            .Range(.Cells(hang1, 24), .Cells(hang1, 24)).BorderAround(ColorIndex:=1, Weight:=Excel.XlBorderWeight.xlThin)
                        Next
                        hang = hang1 + 1
                    Next
                Next

            End With
        Catch
        End Try
    End Sub

    Private Sub frmrptNhanVien_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Commons.Modules.ObjSystems.XoaTable("rptBaocaocongnhan")
    End Sub
    Private Sub frmtabNhanVien_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDOnvi()
        cbodonvi.SelectedIndex = 0
        Loadban()
    End Sub

    Public Sub LoadDOnvi()
        Dim obj As New Commons.clsprintnhanvien
        Dim dt As New DataTable
        dt = obj.Getdonvibaocao()
        cbodonvi.DataSource = dt
        cbodonvi.ValueMember = "ms_don_vi"
        cbodonvi.DisplayMember = "ten_don_vi"
    End Sub

    Public Sub Loadban()
        Dim obj As New Commons.clsprintnhanvien
        Dim dt As New DataTable
        dt = obj.Gettophongbanbaocao(cbodonvi.SelectedValue)
        cboban.DataSource = dt
        cboban.ValueMember = "ms_to"
        cboban.DisplayMember = "ten_to"
    End Sub

    Private Sub btnThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Click
        Me.ParentForm.Close()
    End Sub
End Class
